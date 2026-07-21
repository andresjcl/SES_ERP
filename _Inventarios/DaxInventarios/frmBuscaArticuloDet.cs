using System;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;
using DattCom;
using ArtInvent;

namespace DaxInvent
{
    public partial class frmBuscaArticuloDet : Form
    {
        string Dedonde = "";
        string CodigoArt = "";
        string LaFecha = "";
        string LaBodega = "";
        string CodigoRet = "";

        public frmBuscaArticuloDet(string strConx, string strSys)
        {
            InitializeComponent();
            llenarCombos(strConx);
        }

        public void IniciaConsultaArt(string codigo, string DeDon, string ipo = "", string fecha = "", string Bodega = "")
        {
            Dedonde = DeDon;
            CodigoArt = codigo;
            txtDescripcion.Text = codigo;
            LaFecha = fecha;
            if (LaFecha == "") LaFecha = DateTime.Now.ToShortDateString();
            LaBodega = Bodega;
            this.Show();
            Clipboard.SetData(DataFormats.Text, (Object)CodigoRet);
        }

        public string IniciaBuscaArt(string codigo, string DeDon, string ipo = "", string fecha = "", string Bodega = "")
        {
            Dedonde = DeDon;
            CodigoArt = codigo;
            LaFecha = fecha;
            if (LaFecha == "") LaFecha = DateTime.Now.ToShortDateString();
            LaBodega = Bodega;
            txtDescripcion.Text = codigo;
            this.ShowDialog();
            return CodigoRet;
        }

        private void llenarCombos(string strConxAdcom)
        {
            DaxCombobx.CargCmbBox cmb = new DaxCombobx.CargCmbBox();
            cmb.DaxCombosCat("C", "I", strConxAdcom, ref cmbCategoria);
            cmb.DaxCombosCat("CL", "I", strConxAdcom, ref cmbClase);
            cmb.DaxCombosCat("G", "I", strConxAdcom, ref cmbGrupo);
            cmb.DaxCombosCat("S", "I", strConxAdcom, ref cmbSubgrupo);
        }

        #region Métodos para obtener nombres de bases de datos

        private string ObtenerBaseDatosMedidas()
        {
            try
            {
                // USAR DIRECTAMENTE LA VARIABLE GLOBAL nombreBaseSis
                if (!string.IsNullOrEmpty(datosEmpresa.nombreBaseSis))
                {
                    // Verificar que la tabla Medidas existe en esa base de datos
                    using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
                    {
                        conn.Open();

                        // Usar INFORMATION_SCHEMA.TABLES (funciona con cualquier base de datos)
                        string sql = @"
                            SELECT COUNT(*) 
                            FROM " + datosEmpresa.nombreBaseSis + @".INFORMATION_SCHEMA.TABLES 
                            WHERE TABLE_NAME = 'Medidas'";

                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            int count = (int)cmd.ExecuteScalar();
                            if (count > 0)
                            {
                                return datosEmpresa.nombreBaseSis;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Si hay error, continuar con el fallback
                System.Diagnostics.Debug.WriteLine($"Error en ObtenerBaseDatosMedidas: {ex.Message}");
            }

            // FALLBACK: Intentar con nombres comunes usando INFORMATION_SCHEMA
            try
            {
                string[] posiblesBDs = { "Daxsys" };

                using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
                {
                    conn.Open();

                    foreach (string bd in posiblesBDs)
                    {
                        try
                        {
                            string sql = @"
                                SELECT COUNT(*) 
                                FROM " + bd + @".INFORMATION_SCHEMA.TABLES 
                                WHERE TABLE_NAME = 'Medidas'";

                            using (SqlCommand cmd = new SqlCommand(sql, conn))
                            {
                                int count = (int)cmd.ExecuteScalar();
                                if (count > 0)
                                {
                                    return bd;
                                }
                            }
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
            }
            catch { }

            // Si todo falla, usar el valor por defecto
            return "DaxsysAsofarmadis";
        }

        private string ObtenerBaseDatosIva()
        {
            try
            {
                // USAR DIRECTAMENTE LA VARIABLE GLOBAL nombreBaseIvaret
                if (!string.IsNullOrEmpty(datosEmpresa.nombreBaseIvaret))
                {
                    using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
                    {
                        conn.Open();

                        string sql = @"
                            SELECT COUNT(*) 
                            FROM " + datosEmpresa.nombreBaseIvaret + @".INFORMATION_SCHEMA.TABLES 
                            WHERE TABLE_NAME = 'PorcentajeIva'";

                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            int count = (int)cmd.ExecuteScalar();
                            if (count > 0)
                            {
                                return datosEmpresa.nombreBaseIvaret;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en ObtenerBaseDatosIva: {ex.Message}");
            }

            // FALLBACK: Intentar con nombres comunes
            try
            {
                string[] posiblesBDs = { "IvaretDax", "Ivaret" };

                using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
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
                                {
                                    return bd;
                                }
                            }
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
            }
            catch { }

            return "IvaretDax";
        }

        #endregion

        private void ArreglaMalla()
        {
            string Dcatego = "";
            string Dgrupo = "";
            string Dsubgrupo = "";
            string Dclase = "";
            DataTable Rs = new DataTable();
            string codsql = "DaxInvbusses ";

            if (LaFecha == "") LaFecha = DateTime.Now.ToShortDateString();

            // ============================================
            // PARÁMETRO 1: Fecha
            // ============================================
            codsql += "'" + LaFecha + "'";

            // ============================================
            // PARÁMETRO 2: SoloVenta
            // ============================================
            if (chkSoloVenta.Checked) { codsql += ",'S'"; } else { codsql += ",''"; }

            // ============================================
            // PARÁMETRO 3: BODEGA
            // ============================================
            codsql += ",'" + LaBodega + "'";

            // ============================================
            // PARÁMETRO 4: CODIGO1 (vacío)
            // ============================================
            codsql += ",''";

            // ============================================
            // PARÁMETRO 5: Nombre (búsqueda)
            // ============================================
            codsql += ",'" + txtDescripcion.Text + "'";

            // ============================================
            // PARÁMETRO 6: soloCategoria
            // ============================================
            Dcatego = cmbCategoria.SelectedValue.ToString();
            if (Dcatego != "0") { codsql += ",'" + Dcatego + "'"; } else { codsql += ",''"; }

            // ============================================
            // PARÁMETRO 7: soloClase
            // ============================================
            Dclase = cmbClase.SelectedValue.ToString();
            if (Dclase != "0") { codsql += ",'" + Dclase + "'"; } else { codsql += ",''"; }

            // ============================================
            // PARÁMETRO 8: soloGrupo
            // ============================================
            Dgrupo = cmbGrupo.SelectedValue.ToString();
            if (Dgrupo != "0") { codsql += ",'" + Dgrupo + "'"; } else { codsql += ",''"; }

            // ============================================
            // PARÁMETRO 9: soloSubgrupo
            // ============================================
            Dsubgrupo = cmbSubgrupo.SelectedValue.ToString();
            if (Dsubgrupo != "0") { codsql += ",'" + Dsubgrupo + "'"; } else { codsql += ",''"; }

            // ============================================
            // PARÁMETRO 10: Orden
            // ============================================
            if (chkOrdenAlfabetico.Checked) { codsql += ",'N'"; } else { codsql += ",'C'"; }

            // ============================================
            // PARÁMETRO 11: Existencia
            // ============================================
            if (chkSoloExistencia.Checked) { codsql += ",'S'"; } else { codsql += ",''"; }

            // ============================================
            // PARÁMETRO 12: ConIva
            // ============================================
            if (chkConIva.Checked) { codsql += ",'S'"; } else { codsql += ",''"; }

            // ============================================
            // PARÁMETRO 13: sucursal (vacío)
            // ============================================
            codsql += ",''";

            // ============================================
            // PARÁMETRO 14: BaseDatosMedidas
            // ============================================
            string baseDatosMedidas = ObtenerBaseDatosMedidas();
            codsql += ",'" + baseDatosMedidas + "'";

            // ============================================
            // PARÁMETRO 15: BaseDatosIva
            // ============================================
            string baseDatosIva = ObtenerBaseDatosIva();
            codsql += ",'" + baseDatosIva + "'";

            
            //MessageBox.Show("Consulta SQL:\n" + codsql, "Depuración",
            //    MessageBoxButtons.OK, MessageBoxIcon.Information);

            SqlDataAdapter da = new SqlDataAdapter(codsql, datosEmpresa.strConxAdcom);
            da.Fill(Rs);
            malla.DataSource = Rs;
        }

        private void frmBuscaArticuloDet_Load(object sender, EventArgs e)
        {
            ArreglaMalla();
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkOrdenCodigo_CheckedChanged(object sender, EventArgs e)
        {
            ArreglaMalla();
        }

        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) ArreglaMalla();
        }

        private void malla_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                CodigoRet = malla.CurrentRow.Cells["Codigo"].Value.ToString();
                this.Close();
            }
            catch { CodigoRet = ""; }
        }

        private void btnPendientes_Click(object sender, EventArgs e)
        {
            EntregasPendientesClienteProv frm = new EntregasPendientesClienteProv(datosEmpresa.strConxAdcom, "", malla.CurrentRow.Cells["Codigo"].Value.ToString(), txtDescripcion.Text);
            frm.ShowDialog();
            frm.Dispose();
        }

        private void btnMovimiento_Click(object sender, EventArgs e)
        {
            frmMovArt prog = new frmMovArt(malla.CurrentRow.Cells["Codigo"].Value.ToString(), malla.CurrentRow.Cells["nombre"].Value.ToString());
            prog.ShowDialog();
            prog.Dispose();
        }

        private void btnPropieddades_Click(object sender, EventArgs e)
        {
            MantArticulo prog = new MantArticulo(malla.CurrentRow.Cells["Codigo"].Value.ToString(), true);
            prog.ShowDialog();
            prog.Dispose();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            try
            {
                if (malla.CurrentRow == null)
                {
                    MessageBox.Show("Por favor, seleccione un artículo de la lista.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string codigo = malla.CurrentRow.Cells["Codigo"].Value?.ToString();

                if (string.IsNullOrEmpty(codigo))
                {
                    MessageBox.Show("El artículo seleccionado no tiene un código válido.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string descripcion = codigo;
                if (malla.Columns.Contains("Nombre") && malla.CurrentRow.Cells["Nombre"].Value != null)
                {
                    descripcion = malla.CurrentRow.Cells["Nombre"].Value.ToString();
                }

                frmUltimasCompras frm = new frmUltimasCompras(
                    datosEmpresa.strConxAdcom,
                    codigo,
                    descripcion,
                    "V"
                );
                frm.ShowDialog();
                frm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el historial de ventas: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            try
            {
                if (malla.CurrentRow == null)
                {
                    MessageBox.Show("Por favor, seleccione un artículo de la lista.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string codigo = malla.CurrentRow.Cells["Codigo"].Value?.ToString();

                if (string.IsNullOrEmpty(codigo))
                {
                    MessageBox.Show("El artículo seleccionado no tiene un código válido.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string descripcion = codigo;
                if (malla.Columns.Contains("nombre") && malla.CurrentRow.Cells["Nombre"].Value != null)
                {
                    descripcion = malla.CurrentRow.Cells["Nombre"].Value.ToString();
                }

                frmUltimasCompras frm = new frmUltimasCompras(datosEmpresa.strConxAdcom,codigo,descripcion,"C");
                frm.ShowDialog();
                frm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el historial de compras: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {

        }

        private void btnCompatibles_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscaArticuloDet frm = new frmBuscaArticuloDet(datosEmpresa.strConxAdcom, "");
                string codigoSeleccionado = frm.IniciaBuscaArt("", "BUSQUEDA");

                if (!string.IsNullOrEmpty(codigoSeleccionado))
                {
                    txtDescripcion.Text = codigoSeleccionado;
                    ArreglaMalla();
                }

                frm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir la búsqueda de artículos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ArreglaMalla();
        }
    }
}