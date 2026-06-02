using System;
using System.Data;
using System.Drawing;
using System.Data.SqlClient ;
using System.Windows.Forms;
using SysEmpDatt;
namespace DaxInvent
{
    public partial class frmBuscaArticuloDet : Form
    {
        string Dedonde="";
        string CodigoArt ="";
        string LaFecha ="";
        string LaBodega ="";
        string CodigoRet="";
        public frmBuscaArticuloDet(string strConx,string strSys)
        {
            InitializeComponent();
            llenarCombos(strConx);
        }
        public void IniciaConsultaArt(string codigo, string DeDon, string ipo ="", string fecha ="", string Bodega ="") 
        {        
            Dedonde = DeDon;
            CodigoArt = codigo;
            txtDescripcion.Text = codigo;
            LaFecha = fecha;
            if (LaFecha == "") LaFecha = DateTime.Now.ToShortDateString ();
            LaBodega = Bodega;
            this.Show();
            Clipboard.SetData(DataFormats.Text, (Object)CodigoRet);
        }
        public string IniciaBuscaArt(string codigo, string DeDon, string ipo ="", string fecha ="", string Bodega ="") 
        {
            Dedonde = DeDon;
            CodigoArt = codigo;
            LaFecha = fecha;
            if (LaFecha == "") LaFecha = DateTime.Now.ToShortDateString ();
            LaBodega = Bodega;
            txtDescripcion.Text = codigo;
            this.ShowDialog  ();
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
        private void ArreglaMalla()
        {
            string Dcatego="";
            string Dgrupo="";
            string Dsubgrupo="";
            string Dclase="";
            DataTable  Rs = new DataTable();
            string codsql="DaxInvbus ";
           // if (sw == false) return;
            if (LaFecha == "") LaFecha = DateTime.Now.ToShortDateString ();
            codsql += "'" + LaFecha + "'";
            if (chkSoloVenta.Checked)  {codsql += ",'S'";}else{codsql += ",''";}
            codsql += ",'" + LaBodega + "'";
            codsql += ",''";
            codsql += ",'" + txtDescripcion.Text  + "'";

            Dcatego = cmbCategoria.SelectedValue.ToString();
            if( Dcatego != "0") {codsql += ",'" + Dcatego + "'" ;}else{codsql += ",''";}

            Dclase = cmbClase.SelectedValue.ToString();
            if( Dclase != "0") {codsql += ",'" + Dclase + "'" ;}else{codsql += ",''";}

            Dgrupo = cmbGrupo.SelectedValue.ToString();
            if( Dgrupo != "0") {codsql += ",'" + Dgrupo + "'" ;}else{codsql += ",''";}

            Dsubgrupo = cmbSubgrupo.SelectedValue.ToString();
            if( Dsubgrupo != "0") {codsql += ",'" + Dsubgrupo + "'" ;}else{codsql += ",''";}

            if (chkOrdenAlfabetico.Checked) { codsql += ",'N'"; } else { codsql += ",'C'"; }

            if (chkSoloExistencia.Checked) {codsql += ",'S'";}else{codsql += ",''";}
            if (chkConIva.Checked){codsql += ",'S'";}else{codsql += ",''";}

            SqlDataAdapter da = new SqlDataAdapter(codsql, datosEmpresa.strConxAdcom);
            da.Fill (Rs);
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
            catch { CodigoRet = "";}
        }

        private void btnPendientes_Click(object sender, EventArgs e)
        {
            EntregasPendientesClienteProv frm = new EntregasPendientesClienteProv(datosEmpresa.strConxAdcom, "", malla.CurrentRow.Cells["Codigo"].Value.ToString(), txtDescripcion.Text);
            frm.ShowDialog();
            frm.Dispose();
        }

        private void btnMovimiento_Click(object sender, EventArgs e)
        {
            frmMovArt prog = new frmMovArt(malla.CurrentRow.Cells["Codigo"].Value.ToString());
            prog.ShowDialog();
            prog.Dispose();
        }

        private void btnPropieddades_Click(object sender, EventArgs e)
        {
            MantArticulo prog = new MantArticulo(malla.CurrentRow.Cells["Codigo"].Value.ToString(),true);
            prog.ShowDialog();
            prog.Dispose();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {

        }

        private void btnCompras_Click(object sender, EventArgs e)
        {

        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {

        }

        private void btnCompatibles_Click(object sender, EventArgs e)
        {

        }
    }
}
