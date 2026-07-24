using System;
using System.Data;
using System.Drawing;
using System.Data.SqlClient ;
using System.Windows.Forms;
using DattCom;
namespace DaxInvent
{

    public partial class frmBuscaArticuloSimple : Form
    {
        string Dedonde = "";
        string CodigoArt = "";
        string LaFecha = "";
        string LaBodega = "";
        string CodigoRet = "";
        string laSucursal = "";
        string elCliente = "";
        string numeroDocumento = "";
        string tipoDocumento = "";
        public frmBuscaArticuloSimple(string sucursal, string cliente, string numDoc, string tipDoc)
        {
            //dato, StrConxAdcom_10, strConIniSis_10, "", "", "", "", CDate(TxtFecha)
            InitializeComponent();
            //strConxAdcom = strconx;
            //strConIniSis = strIniSis;
            //            MessageBox.Show(" uno " + datosEmpresa.strConxAdcom);
            DaxCombobx.CargCmbBox cmb = new DaxCombobx.CargCmbBox();
            cmb.DaxCombosCat("C", "I", datosEmpresa.strConxAdcom, ref cmbCategoria);
            cmb.DaxCombosCat("CL", "I", datosEmpresa.strConxAdcom, ref cmbClase);
            cmb.DaxCombosCat("G", "I", datosEmpresa.strConxAdcom, ref cmbGrupo);

//            llenarCombos(datosEmpresa.strConxAdcom);
            laSucursal = sucursal;
            elCliente = cliente;
            numeroDocumento = numDoc;
            tipoDocumento = tipDoc;
            cargarPreferencias();
        }
        private void llenarCombos(string strConxAdcom)
        {
            DaxCombobx.CargCmbBox cmb = new DaxCombobx.CargCmbBox();
            cmb.DaxCombosCat("C", "I", strConxAdcom, ref cmbCategoria);
            cmb.DaxCombosCat("CL", "I", strConxAdcom, ref cmbClase);
            cmb.DaxCombosCat("G", "I", strConxAdcom, ref cmbGrupo);
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
        private void ArreglaMalla()
        {
            string Dcatego = "";
            string Dgrupo = "";
            string Dclase = "";
            DataTable Rs = new DataTable();
            string codsql = "DaxInvbus2 ";
            // if (sw == false) return;
            if (LaFecha == "") LaFecha = DateTime.Now.ToShortDateString();
            codsql += "'" + LaFecha + "'";
            if (chkSoloVenta.Checked) { codsql += ",'S'"; } else { codsql += ",''"; }
            codsql += ",'" + LaBodega + "'";
            codsql += ",''";
            codsql += ",'" + txtDescripcion.Text + "'";

            if (cmbCategoria.SelectedValue != null) Dcatego = cmbCategoria.SelectedValue.ToString();
            if (Dcatego != "0") { codsql += ",'" + Dcatego + "'"; } else { codsql += ",''"; }

            if (cmbClase.SelectedValue!= null) Dclase = cmbClase.SelectedValue.ToString();
            if (Dclase != "0") { codsql += ",'" + Dclase + "'"; } else { codsql += ",''"; }

            if (cmbGrupo.SelectedValue != null) Dgrupo = cmbGrupo.SelectedValue.ToString();
            if (Dgrupo != "0") { codsql += ",'" + Dgrupo + "'"; } else { codsql += ",''"; }

            codsql += ",''";

            if (chkOrdenAlfabetico.Checked) { codsql += ",'N'"; } else { codsql += ",'C'"; }

            codsql += ",''";
            codsql += ",''";

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

        private void btnComercial_Click(object sender, EventArgs e)
        {
            frmDatosComerciales prog = new frmDatosComerciales(malla.CurrentRow.Cells["Codigo"].Value.ToString(), datosEmpresa.strConxAdcom, laSucursal, elCliente, LaFecha, tipoDocumento, numeroDocumento, LaBodega);
            prog.ShowDialog();
            prog.Dispose();
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            MantArticulo prog = new MantArticulo(malla.CurrentRow.Cells["Codigo"].Value.ToString(), true);
            prog.ShowDialog();
        }
        private void guardarPreferencias()
        {
            if (cmbCategoria.SelectedValue != null) AuditSis.registrar.registraPreferencia(datosEmpresa.strConxAdcom, datosEmpresa.codEmpresa.ToString(),Environment.MachineName, datosEmpresa.usr + Environment.MachineName,datosEmpresa.sistema, datosEmpresa.suc, "BUSART", "CategoriaArticulo", cmbCategoria.SelectedValue.ToString());
            if (cmbClase.SelectedValue != null) AuditSis.registrar.registraPreferencia(datosEmpresa.strConxAdcom, datosEmpresa.codEmpresa.ToString(),Environment.MachineName, datosEmpresa.usr + Environment.MachineName, datosEmpresa.sistema, datosEmpresa.suc, "BUSART", "ClaseArticulo", cmbClase.SelectedValue.ToString());
            if (cmbGrupo.SelectedValue != null) AuditSis.registrar.registraPreferencia(datosEmpresa.strConxAdcom, datosEmpresa.codEmpresa.ToString(),Environment.MachineName, datosEmpresa.usr + Environment.MachineName, datosEmpresa.sistema, datosEmpresa.suc, "BUSART", "GrupoArticulo", cmbGrupo.SelectedValue.ToString());
        }
        private void cargarPreferencias()
        {

            string op = AuditSis.registrar.obtenerPreferencia(datosEmpresa.strConxAdcom, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr + Environment.MachineName, datosEmpresa.sistema, datosEmpresa.suc, "BUSART", "CategoriaArticulo");
            if (op.Length > 0) cmbCategoria.SelectedValue = op; else cmbCategoria.SelectedIndex = 0;

            op = AuditSis.registrar.obtenerPreferencia(datosEmpresa.strConxAdcom, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr + Environment.MachineName, datosEmpresa.sistema, datosEmpresa.suc, "BUSART", "ClaseArticulo");
            if (op.Length > 0) cmbClase.SelectedValue = op; else cmbClase.SelectedIndex = 0;

            op = AuditSis.registrar.obtenerPreferencia(datosEmpresa.strConxAdcom, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr + Environment.MachineName, datosEmpresa.sistema, datosEmpresa.suc, "BUSART", "GrupoArticulo");
            if (op.Length > 0) cmbGrupo.SelectedValue = op; else cmbGrupo.SelectedIndex = 0;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ArreglaMalla();
        }

        private void frmBuscaArticuloSimple_FormClosing(object sender, FormClosingEventArgs e)
        {
            guardarPreferencias();
        }
    }
}
