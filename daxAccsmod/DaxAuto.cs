using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace daxAccs
{
    public class propiedadesDaxAuto
    {
        // ==============================================
        // PROPIEDADES EXISTENTES
        // ==============================================
        public bool sinRegistro = false;

        // Permisos básicos
        public bool NúmeroDocumento { get; set; }
        public bool Modificar { get; set; }
        public bool Crear { get; set; }
        public bool FechaDocumento { get; set; }
        public bool Bodega { get; set; }
        public bool Vendedor { get; set; }
        public bool FormaDePago { get; set; }
        public bool Contabilidad { get; set; }
        public bool Impuestos { get; set; }
        public bool DescuentoDocumento { get; set; }
        public bool Imprimir { get; set; }
        public bool Eliminar { get; set; }
        public bool Anular { get; set; }
        public bool Consultar { get; set; }
        public bool DetalleProducto { get; set; }
        public bool PrecioUnitario { get; set; }
        public bool DescuentoUnitario { get; set; }


        // Valores fijos
        public int NroImpresiones { get; set; }
        public string BodegaFija { get; set; }
        public string VendedorFijo { get; set; }
        public string FormaDePagoFijo { get; set; }

        public decimal DescuentoDocumentoPorcMinimo { get; set; }
        public decimal DescuentoDocumentoPorcMaximo { get; set; }
        public decimal DescuentoDocumentoPorcFijo { get; set; }

        // Para DescuentoUnitario
        public decimal DescuentoUnitarioPorcMinimo { get; set; }
        public decimal DescuentoUnitarioPorcMaximo { get; set; }
        public decimal DescuentoUnitarioPorcFijo { get; set; }

        public string PrecioUnitarioFijo { get; set; }

        // Para la malla de elementos
        public int InicioElementosMalla = 9;
        public int nroElementos = 21;
        public string[] ELEMENTOS = new string[] {
            "Crear", "Modificar", "Anular", "Eliminar", "Consultar",
            "Ingresos", "Gastos", "CierreCaja", "EntregaExpress",
            "NúmeroDocumento", "FechaDocumento", "Bodega", "Vendedor",
            "PrecioUnitario", "DescuentoUnitario", "Impuestos",
            "DescuentoDocumento", "FormaDePago", "Contabilidad",
            "Imprimir", "DetalleProducto"
        };

        // Variables para la conexión
        private string _strConxSyscod = "";
        private int _codEmpresa = 0;
        private string _usuario = "";
        private string _tipoDocumentoActual = "";

        // ==============================================
        // MÉTODO INICIAR
        // ==============================================
        public void iniciar(Int32 codEmp, string coduser, string strSys)
        {
            _codEmpresa = codEmp;
            _usuario = coduser;
            _strConxSyscod = strSys;

            try
            {
                string ssql = "SELECT COUNT(*) as existe FROM sysdocaccs WHERE empresa = " + codEmp + " AND idusuario = '" + coduser + "'";
                using (SqlConnection conn = new SqlConnection(strSys))
                {
                    conn.Open();
                    using (SqlCommand comm = new SqlCommand(ssql, conn))
                    {
                        int existe = Convert.ToInt32(comm.ExecuteScalar());
                        sinRegistro = (existe == 0);
                    }
                }
            }
            catch
            {
                sinRegistro = true;
            }
        }

        public void cargarAccesoDoc(string tipoDoc)
        {
            _tipoDocumentoActual = tipoDoc;

            // Inicializar valores por defecto
            InicializarValoresDefault();

            if (sinRegistro) return;

            try
            {
                string ssql = @"SELECT opcion, Abierto, Cantidad, Minimo, Maximo, ValorFijo, AuxStr1, AuxStr2 
                               FROM sysdocaccs 
                               WHERE empresa = @empresa AND idusuario = @usuario AND opc_documento = @documento";

                using (SqlConnection conn = new SqlConnection(_strConxSyscod))
                {
                    conn.Open();
                    using (SqlCommand comm = new SqlCommand(ssql, conn))
                    {
                        comm.Parameters.AddWithValue("@empresa", _codEmpresa);
                        comm.Parameters.AddWithValue("@usuario", _usuario);
                        comm.Parameters.AddWithValue("@documento", tipoDoc);

                        using (SqlDataReader dr = comm.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                string opcion = dr["opcion"].ToString();
                                bool abierto = Convert.ToBoolean(dr["Abierto"]);

                                switch (opcion)
                                {
                                    case "NúmeroDocumento": NúmeroDocumento = abierto; break;
                                    case "Modificar": Modificar = abierto; break;
                                    case "Crear": Crear = abierto; break;
                                    case "FechaDocumento": FechaDocumento = abierto; break;
                                    case "Bodega": Bodega = abierto; break;
                                    case "Vendedor": Vendedor = abierto; break;
                                    case "FormaDePago": FormaDePago = abierto; break;
                                    case "Contabilidad": Contabilidad = abierto; break;
                                    case "Impuestos": Impuestos = abierto; break;
                                    case "DescuentoDocumento":
                                        DescuentoDocumento = abierto;
                                        CargarValoresDescuentoDocumento(dr);
                                        break;
                                    case "Imprimir":
                                        Imprimir = abierto;
                                        CargarValoresImpresion(dr);
                                        break;
                                    case "Eliminar": Eliminar = abierto; break;
                                    case "Anular": Anular = abierto; break;
                                    case "Consultar": Consultar = abierto; break;
                                    case "DetalleProducto": DetalleProducto = abierto; break;
                                    case "PrecioUnitario":
                                        PrecioUnitario = abierto;
                                        PrecioUnitarioFijo = dr["ValorFijo"]?.ToString() ?? "";
                                        break;
                                    case "DescuentoUnitario":
                                        DescuentoUnitario = abierto;
                                        CargarValoresDescuentoUnitario(dr);
                                        break;
                                    case "BodegaFija": BodegaFija = dr["ValorFijo"]?.ToString() ?? ""; break;
                                    case "VendedorFijo": VendedorFijo = dr["ValorFijo"]?.ToString() ?? ""; break;
                                    case "FormaDePagoFijo": FormaDePagoFijo = dr["ValorFijo"]?.ToString() ?? ""; break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error cargando accesos para {tipoDoc}: {ex.Message}");
                sinRegistro = true;
            }
        }

        private void InicializarValoresDefault()
        {
            NúmeroDocumento = false;
            Modificar = false;
            Crear = false;
            FechaDocumento = false;
            Bodega = false;
            Vendedor = false;
            FormaDePago = false;
            Contabilidad = false;
            Impuestos = false;
            DescuentoDocumento = false;
            Imprimir = false;
            Eliminar = false;
            Anular = false;
            Consultar = false;
            DetalleProducto = false;
            PrecioUnitario = false;
            DescuentoUnitario = false;
            BodegaFija = "";
            VendedorFijo = "";
            FormaDePagoFijo = "";
            NroImpresiones = 0;
            PrecioUnitarioFijo = "";
            DescuentoDocumentoPorcMinimo = 0;
            DescuentoDocumentoPorcMaximo = 0;
            DescuentoDocumentoPorcFijo = 0;
            DescuentoUnitarioPorcMinimo = 0;
            DescuentoUnitarioPorcMaximo = 0;
            DescuentoUnitarioPorcFijo = 0;
        }

        private void CargarValoresDescuentoDocumento(SqlDataReader dr)
        {
            try
            {
                DescuentoDocumentoPorcFijo = Convert.ToDecimal("0" + dr["ValorFijo"]?.ToString());
            }
            catch { DescuentoDocumentoPorcFijo = 0; }

            DescuentoDocumentoPorcMinimo = Convert.ToDecimal("0" + dr["Minimo"]?.ToString());
            DescuentoDocumentoPorcMaximo = Convert.ToDecimal("0" + dr["Maximo"]?.ToString());
        }

        private void CargarValoresDescuentoUnitario(SqlDataReader dr)
        {
            try
            {
                DescuentoUnitarioPorcFijo = Convert.ToDecimal("0" + dr["ValorFijo"]?.ToString());
            }
            catch { DescuentoUnitarioPorcFijo = 0; }

            DescuentoUnitarioPorcMinimo = Convert.ToDecimal("0" + dr["Minimo"]?.ToString());
            DescuentoUnitarioPorcMaximo = Convert.ToDecimal("0" + dr["Maximo"]?.ToString());
        }

        private void CargarValoresImpresion(SqlDataReader dr)
        {
            int.TryParse(dr["Maximo"]?.ToString(), out int nro);
            NroImpresiones = nro;
        }

        // ==============================================
        // MÉTODO PARA APLICAR PERMISOS A FORMULARIO
        // ==============================================
        public void AplicarPermisosAlFormulario(Form formulario, bool esAdmin)
        {
            if (sinRegistro) return;

            if (esAdmin)
            {
                HabilitarControlesEnFormulario(formulario, true);
            }
            else
            {
                AplicarPermisosUsuarioNormal(formulario);
            }
        }

        private void HabilitarControlesEnFormulario(Form form, bool habilitado)
        {
            // Controles comunes
            var txtnumero = form.Controls.Find("txtnumero", true).FirstOrDefault() as TextBox;
            var txtNroID = form.Controls.Find("txtNroID", true).FirstOrDefault() as TextBox;
            var txtfecha = form.Controls.Find("txtfecha", true).FirstOrDefault() as DateTimePicker;
            var cmbBodega = form.Controls.Find("cmbBodega", true).FirstOrDefault() as ComboBox;
            var cmbVendedor = form.Controls.Find("cmbVendedor", true).FirstOrDefault() as ComboBox;
            var cmbDocumento = form.Controls.Find("cmbDocumento", true).FirstOrDefault() as ComboBox;

            if (txtnumero != null) txtnumero.Enabled = habilitado;
            if (txtNroID != null) txtNroID.Enabled = habilitado;
            if (txtfecha != null) txtfecha.Enabled = habilitado;
            if (cmbBodega != null) cmbBodega.Enabled = habilitado;
            if (cmbVendedor != null) cmbVendedor.Enabled = habilitado;
            if (cmbDocumento != null) cmbDocumento.Enabled = habilitado;

            HabilitarToolStripButtons(form, habilitado);
        }

        private void HabilitarToolStripButtons(Form form, bool habilitado)
        {
            foreach (Control ctrl in form.Controls)
            {
                if (ctrl is ToolStrip toolStrip)
                {
                    foreach (ToolStripItem item in toolStrip.Items)
                    {
                        if (item is ToolStripButton btn)
                        {
                            if (btn.Name == "btnPagos" || btn.Name == "btnContabiliza" ||
                                btn.Name == "btnPorcentajeIva" || btn.Name == "btnDescuentos")
                            {
                                btn.Enabled = habilitado;
                            }
                        }
                    }
                }
            }
        }

        private void AplicarPermisosUsuarioNormal(Form form)
        {
            // Controles comunes
            var txtnumero = form.Controls.Find("txtnumero", true).FirstOrDefault() as TextBox;
            var txtNroID = form.Controls.Find("txtNroID", true).FirstOrDefault() as TextBox;
            var txtfecha = form.Controls.Find("txtfecha", true).FirstOrDefault() as DateTimePicker;
            var cmbBodega = form.Controls.Find("cmbBodega", true).FirstOrDefault() as ComboBox;
            var cmbVendedor = form.Controls.Find("cmbVendedor", true).FirstOrDefault() as ComboBox;

            if (txtnumero != null) txtnumero.Enabled = this.NúmeroDocumento;
            if (txtNroID != null) txtNroID.Enabled = this.NúmeroDocumento;
            if (txtfecha != null) txtfecha.Enabled = this.FechaDocumento;

            if (cmbBodega != null)
            {
                cmbBodega.Enabled = this.Bodega;
                if (!string.IsNullOrEmpty(this.BodegaFija))
                {
                    try { cmbBodega.SelectedValue = this.BodegaFija; }
                    catch { }
                    cmbBodega.Enabled = false;
                }
            }

            if (cmbVendedor != null)
            {
                cmbVendedor.Enabled = this.Vendedor;
                if (!string.IsNullOrEmpty(this.VendedorFijo))
                {
                    try { cmbVendedor.SelectedValue = this.VendedorFijo; }
                    catch { }
                    cmbVendedor.Enabled = false;
                }
            }

            AplicarVisibilidadBotones(form);
        }

        private void AplicarVisibilidadBotones(Form form)
        {
            foreach (Control ctrl in form.Controls)
            {
                if (ctrl is ToolStrip toolStrip)
                {
                    foreach (ToolStripItem item in toolStrip.Items)
                    {
                        if (item is ToolStripButton btn)
                        {
                            switch (btn.Name)
                            {
                                case "btnPagos":
                                    btn.Visible = this.FormaDePago;
                                    break;
                                case "btnContabiliza":
                                    btn.Visible = this.Contabilidad;
                                    break;
                                case "btnPorcentajeIva":
                                    btn.Visible = this.Impuestos;
                                    break;
                                case "btnDescuentos":
                                    btn.Visible = this.DescuentoDocumento;
                                    break;
                            }
                        }
                    }
                }
            }
        }

        // ==============================================
        // MÉTODO PARA OBTENER TIPO DE DOCUMENTO DESDE ADCOPC
        // ==============================================
        public static string TipoDocumento(string strConxAdcom, string codigoDocumento)
        {
            try
            {
                string ssql = "SELECT opc_tipo FROM adcopc WHERE opc_documento = '" + codigoDocumento + "'";
                using (SqlConnection conn = new SqlConnection(strConxAdcom))
                {
                    conn.Open();
                    using (SqlCommand comm = new SqlCommand(ssql, conn))
                    {
                        object result = comm.ExecuteScalar();
                        if (result != null && !string.IsNullOrEmpty(result.ToString()))
                        {
                            return result.ToString();
                        }
                        // Si no encuentra, retorna el mismo código (por compatibilidad)
                        return codigoDocumento;
                    }
                }
            }
            catch
            {
                // En caso de error, retorna el código original
                return codigoDocumento;
            }
        }

        public void registrarAccesosLocalizadosDocumento(Form formulario, dynamic datosEmpresa)
        {
            bool esAdmin = datosEmpresa.usr.ToUpper() == "ADMINISTRADOR";

            if (esAdmin)
            {
                HabilitarControlesEnFormulario(formulario, true);
            }
            else
            {
                AplicarPermisosUsuarioNormal(formulario);
            }
        }
    }
}