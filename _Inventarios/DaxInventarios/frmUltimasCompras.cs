using DattCom;
using DctosEmi;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ArtInvent
{
    public partial class frmUltimasCompras : Form
    {
        private string codigoArticulo;
        private string descripcionArticulo;
        private string strConx;
        private string tipoDocumento; // "C" = Compras, "V" = Ventas
        private decimal porcentajeIVA = 0.12m;
        private int digitosPrecios = 6;
        private int digitosCostos = 6;

        public frmUltimasCompras(string strConxAdcom, string codigo, string descripcion, string tipo)
        {
            InitializeComponent();
            this.strConx = strConxAdcom;
            this.codigoArticulo = codigo;
            this.descripcionArticulo = descripcion;
            this.tipoDocumento = tipo;

            // Cargar valores predefinidos de la empresa
            valoresPredefinidosEmpresa.cargaValores();

            // Obtener configuración de decimales
            ObtenerConfiguracionDecimales();

            // ============================================
            // ASIGNAR VALORES A LOS LABELS CON FORMATO COMPLETO
            // ============================================

            // Mostrar el código completo (incluyendo asterisco si existe)
            string codigoMostrar = codigo;
            lblCodigoValor.Text = codigoMostrar;
            lblCodigoValor.AutoSize = true;
            lblCodigoValor.MaximumSize = new System.Drawing.Size(300, 0);

            // Mostrar la descripción completa con ajuste de línea
            lblDescripcionValor.Text = descripcion;
            //lblDescripcionValor.AutoSize = true;
            //lblDescripcionValor.MaximumSize = new System.Drawing.Size(550, 0);

            // Asegurar que los labels padre también se ajusten
            panelSuperior.AutoSize = true;
            panelSuperior.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // Cambiar el título según el tipo
            if (tipo == "V")
            {
                this.Text = "Últimas Ventas por artículo";
                lblTitulo.Text = "Últimas ventas por artículo";
            }
            else
            {
                this.Text = "Últimas Compras por artículo";
                lblTitulo.Text = "Últimas compras por artículo";
            }

            // Obtener el porcentaje de IVA
            ObtenerPorcentajeIVA();

            // Ajustar el formulario
            this.AutoSize = false;
            this.AutoSizeMode = AutoSizeMode.GrowOnly;
        }

        #region Configuración de Decimales

        private void ObtenerConfiguracionDecimales()
        {
            try
            {
                digitosPrecios = valoresPredefinidosEmpresa.nroDigitosEnPrecios;
                digitosCostos = valoresPredefinidosEmpresa.nroDigitosEnCostos;
            }
            catch
            {
                digitosPrecios = 2;
                digitosCostos = 2;
            }
        }

        #endregion

        #region IVA

        private void ObtenerPorcentajeIVA()
        {
            try
            {
                string baseDatosIva = ObtenerBaseDatosIva();
                string sql = @"
                    SELECT TOP 1 porcentaje 
                    FROM " + baseDatosIva + @".dbo.PorcentajeIva
                    WHERE GETDATE() >= FechaInicio 
                    AND GETDATE() <= ISNULL(FechaFin, '31/12/2999')
                    ORDER BY FechaInicio";

                using (SqlConnection conn = new SqlConnection(strConx))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        object resultado = cmd.ExecuteScalar();
                        if (resultado != null && resultado != DBNull.Value)
                        {
                            decimal.TryParse(resultado.ToString(), out porcentajeIVA);
                        }
                        else
                        {
                            porcentajeIVA = 0.12m;
                        }
                    }
                }
            }
            catch
            {
                porcentajeIVA = 0.12m;
            }
        }

        private string ObtenerBaseDatosIva()
        {
            try
            {
                if (!string.IsNullOrEmpty(datosEmpresa.nombreBaseIvaret))
                {
                    return datosEmpresa.nombreBaseIvaret;
                }

                string[] posiblesBDs = { "IvaretDax", "Ivaret" };

                using (SqlConnection conn = new SqlConnection(strConx))
                {
                    conn.Open();

                    foreach (string bd in posiblesBDs)
                    {
                        try
                        {
                            string sql = @"
                                SELECT COUNT(*) 
                                FROM " + bd + @".INFORMATION_SCHEMA.TABLES 
                                WHERE TABLE_NAME = 'PorcentajeIva'";

                            using (SqlCommand cmd = new SqlCommand(sql, conn))
                            {
                                int count = (int)cmd.ExecuteScalar();
                                if (count > 0)
                                    return bd;
                            }
                        }
                        catch { continue; }
                    }
                }
            }
            catch { }

            return "IvaretDax";
        }

        #endregion

        #region Formato de Números

        private string FormatearPrecio(decimal valor)
        {
            string formato = "N" + digitosPrecios;
            return valor.ToString(formato);
        }

        private string FormatearCosto(decimal valor)
        {
            string formato = "N" + digitosCostos;
            return valor.ToString(formato);
        }

        private string FormatearCantidad(decimal valor)
        {
            // Siempre usar la misma cantidad de dígitos configurada
            string formato = "N" + digitosCostos;
            return valor.ToString(formato);
        }

        #endregion

        private void frmUltimasCompras_Load(object sender, EventArgs e)
        {
            CargarMovimientos();

            // Ajustar el formulario después de cargar los datos
            this.Refresh();
        }

        private void CargarMovimientos()
        {
            try
            {
                // Limpiar el DataGridView
                dgvCompras.Rows.Clear();
                dgvCompras.Columns.Clear();

                // Configurar columnas del DataGridView
                dgvCompras.Columns.Add("FechaComp", "FechaComp");
                dgvCompras.Columns.Add("Codigo", "Código");
                dgvCompras.Columns.Add("Proveedor", "Proveedor");
                dgvCompras.Columns.Add("TipoDoc", "TipoDoc");
                dgvCompras.Columns.Add("Numero", "Numero");
                dgvCompras.Columns.Add("PrecioUni", "PrecioUni");
                dgvCompras.Columns.Add("Cantidad", "Cantidad");
                //dgvCompras.Columns.Add("CostosIVA", "Costos con IVA");

                // Ajustar anchos de columnas para mejor visualización
                dgvCompras.Columns["FechaComp"].Width = 100;
                dgvCompras.Columns["Codigo"].Width = 120;
                dgvCompras.Columns["Proveedor"].Width = 250;
                dgvCompras.Columns["TipoDoc"].Width = 60;
                dgvCompras.Columns["Numero"].Width = 80;
                dgvCompras.Columns["PrecioUni"].Width = 120;
                dgvCompras.Columns["Cantidad"].Width = 100;
                //dgvCompras.Columns["CostosIVA"].Width = 140;

                // Alinear columnas numéricas a la derecha
                dgvCompras.Columns["PrecioUni"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvCompras.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //dgvCompras.Columns["CostosIVA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                // Configurar el DataGridView para mejor visualización
                dgvCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dgvCompras.RowHeadersWidth = 20;

                // Construir la consulta SQL según el tipo
                string sql = "";

                if (tipoDocumento == "V")
                {
                    sql = @"
                        SELECT TOP 20 
                            D.Doc_fecha as FechaComp,
                            T.Tra_Codigo AS Codigo,
                            D.Doc_NombreImp as Proveedor,
                            D.Opc_documento as TipoDoc,
                            D.Doc_numero as Numero,
                            T.Tra_precuni as PrecioUni,
                            T.Tra_cantidad as Cantidad
                        FROM ADCDOC D 
                        INNER JOIN ADCTRA T ON D.Opc_documento = T.Opc_documento 
                            AND D.IdClaveDoc = T.IdClaveDoc 
                            AND D.Doc_numero = T.Doc_numero 
                            AND T.Doc_sucursal = D.Doc_sucursal
                        WHERE T.Tra_Codigo = @CodigoArticulo
                            AND D.doc_ventas = 1
                            AND T.Tra_quetipo = 'A'
                            AND T.Tra_inventario <> 0
                        ORDER BY D.Doc_fecha DESC, D.Doc_numero DESC";
                }
                else
                {
                    sql = @"
                        SELECT TOP 20 
                            D.Doc_fecha as FechaComp,
                            T.Tra_Codigo AS Codigo,
                            D.Doc_NombreImp as Proveedor,
                            D.Opc_documento as TipoDoc,
                            D.Doc_numero as Numero,
                            T.Tra_precuni as PrecioUni,
                            T.Tra_cantidad as Cantidad
                        FROM ADCDOC D 
                        INNER JOIN ADCTRA T ON D.Opc_documento = T.Opc_documento 
                            AND D.IdClaveDoc = T.IdClaveDoc 
                            AND D.Doc_numero = T.Doc_numero 
                            AND T.Doc_sucursal = D.Doc_sucursal
                        WHERE T.Tra_Codigo = @CodigoArticulo
                            AND D.doc_compras = -1
                            AND T.Tra_quetipo = 'A'
                            AND T.Tra_inventario <> 0
                        ORDER BY D.Doc_fecha DESC, D.Doc_numero DESC";
                }

                SqlDataAdapter da = new SqlDataAdapter(sql, strConx);
                da.SelectCommand.Parameters.AddWithValue("@CodigoArticulo", codigoArticulo);

                DataTable dt = new DataTable();
                da.Fill(dt);

                // Llenar el DataGridView con formato
                foreach (DataRow row in dt.Rows)
                {
                    decimal precioUnitario = Convert.ToDecimal(row["PrecioUni"]);
                    decimal cantidad = Convert.ToDecimal(row["Cantidad"]);
                   // decimal costoConIVA = precioUnitario * (1 + porcentajeIVA);

                    dgvCompras.Rows.Add(
                        Convert.ToDateTime(row["FechaComp"]).ToString("dd/MM/yyyy"),
                        row["Codigo"].ToString(),
                        row["Proveedor"].ToString(),
                        row["TipoDoc"].ToString(),
                        row["Numero"].ToString(),
                        FormatearPrecio(precioUnitario),
                        FormatearCantidad(cantidad)
                        //FormatearCosto(costoConIVA)
                    );
                }

                // Actualizar total de registros
                string tipoTexto = tipoDocumento == "V" ? "ventas" : "compras";
                lblTotalRegistros.Text = $"Total {tipoTexto}: {dt.Rows.Count}";
                lblPorcentajeIVA.Text = $"IVA: {(porcentajeIVA * 100):N0}%";

                // Mostrar información de decimales
                try
                {
                    lblInfoDecimales.Text = $"Precios: {digitosPrecios} dec, Costos: {digitosCostos} dec";
                }
                catch { }

                if (dt.Rows.Count == 0)
                {
                    lblTotalRegistros.Text = $"Total {tipoTexto}: 0 - No se encontraron {tipoTexto}";
                }

                // Ajustar el DataGridView después de cargar
                dgvCompras.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarMovimientos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCompras_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvCompras.CurrentRow != null)
                {
                    string numeroDoc = dgvCompras.CurrentRow.Cells["Numero"].Value.ToString();
                    string proveedor = dgvCompras.CurrentRow.Cells["Proveedor"].Value.ToString();
                    string fecha = dgvCompras.CurrentRow.Cells["FechaComp"].Value.ToString();
                    string docTip = dgvCompras.CurrentRow.Cells["TipoDoc"].Value.ToString();
                    string precio = dgvCompras.CurrentRow.Cells["PrecioUni"].Value.ToString();
                    string cantidad = dgvCompras.CurrentRow.Cells["Cantidad"].Value.ToString();
                    string tipoTexto = tipoDocumento == "V" ? "Venta" : "Compra";

                    MessageBox.Show($"{tipoTexto}: {numeroDoc}\n" +
                                  $"Fecha: {fecha}\n" +
                                  $"Proveedor/Cliente: {proveedor}\n" +
                                  $"Tipo Documento: {docTip}\n" +
                                  $"Precio Unitario: {precio}\n" +
                                  $"Cantidad: {cantidad}\n" +
                                  $"IVA aplicado: {(porcentajeIVA * 100):N0}%\n" +
                                  $"Decimales: Precios={digitosPrecios}, Costos={digitosCostos}",
                        $"Detalle de {tipoTexto}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}