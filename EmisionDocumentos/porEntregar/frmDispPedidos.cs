using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace porEntregar
{
    public partial class frmDispPedidos : Form
    {
        public string Cliente="";
        public string NomCliente="";
        public string Artículo="";
        public string NomArticulo="";
        public DateTime fecha=DateTime.Now ;
        public string strConxAdcom = "";

        public frmDispPedidos(string strconx)
        {
            InitializeComponent();
            strConxAdcom = strconx;
            llenarCombos();
            ultimaOpcion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmDispPedidos_Load(object sender, EventArgs e)
        {
            cargarMalla();
        }
        private void malla_DoubleClick(object sender, EventArgs e)
        {
        }

        private void malla_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F2)
            {
            }
        }
        private void llenarCombos()
        {
            this.cmbCategoria.SelectedIndexChanged -= new System.EventHandler(this.cmbCategoria_SelectedIndexChanged);
            DaxCombobx.CargCmbBox cmb = new DaxCombobx.CargCmbBox();
            cmb.DaxCombosCat("C", "I", strConxAdcom, ref cmbCategoria);
            cmb.DaxCombosCat("CL", "I", strConxAdcom, ref cmbClase);
            //cmb.DaxCombosCat("G", "I", ClassArt.strConxAdcom, ref cmbGrupo);
            //cmb.DaxCombosCat("S", "I", ClassArt.strConxAdcom, ref cmbSubgrupo);
            //cmb.DaxCombosReferencia("Medidas", ClassArt.strConxSyscod, ref cmbMedida, false);
            this.cmbCategoria.SelectedIndexChanged += new System.EventHandler(this.cmbCategoria_SelectedIndexChanged);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            cargarMalla();
        }


        private void cmbClase_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cargarMalla();

        }

        private void cmbCategoria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cargarMalla();

        }
        private void cargarMalla()
        {
            //            ModuloActual = this.Name;
            string strCategoria = "";
            string strClase = "";
            if (cmbCategoria.SelectedValue!= null) strCategoria = cmbCategoria.SelectedValue.ToString();
            if (cmbClase.SelectedValue!=null) strClase = cmbClase.SelectedValue.ToString();
            string ssql = "DaxDispArtPed '" + DateTime.Now.ToShortDateString() + "','" + "" + "','" + strCategoria + "','" + strClase + "'"; //,'','',0";
            SqlDataAdapter da = new SqlDataAdapter(ssql, strConxAdcom);
            DataTable dt = new DataTable();
            da.Fill(dt);

            malla.DataSource = dt;
            malla.RowHeadersWidth = 20;

            if (dt.Rows.Count == 0) return;
            if (dt.Columns.Count == 0) return;

            string formaGrid = "#,##0.00;(#,##0.00);#";
            this.Cursor = Cursors.WaitCursor;
            for (int i = 2; i < malla.Columns.Count; i++)
            {
                malla.Columns[i].DefaultCellStyle.Format = formaGrid;
                malla.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }


            //double SumarColumna = 0;
            decimal SumarFila = 0;
            foreach  (DataRow fila in dt.Rows)
            {
                SumarFila = 0;
                for (int i = 3; i < dt.Columns.Count - 1; i++)
                {
                    try
                    {
                        SumarFila += Convert.ToDecimal("0" + fila[i].ToString());
                    }catch { }
                }
                fila["Total"] = SumarFila;
                //fila["Fulls"] = SumarFila * Convert.ToDecimal("0" + fila["Factor"].ToString());
            }
            this.Cursor = Cursors.Default;
            dt.Dispose();
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                AdcHisOpc.AdcHistOpc regopc = new AdcHisOpc.AdcHistOpc();
                regopc.GrabarOpcionHis(strConxAdcom, "", "flor", Environment.MachineName, "coord", "disp", cmbCategoria.SelectedValue.ToString(), DateTime.Now);
                regopc = null;
            }
            catch { }
        }
        private void ultimaOpcion()
        {
            string resp = "";
            AdcHisOpc.AdcHistOpc regopc = new AdcHisOpc.AdcHistOpc();
            resp = regopc.CargarOpcionHis (strConxAdcom, "", "flor", Environment.MachineName, "coord", "disp");
            if (resp != "") cmbCategoria.SelectedValue = resp; 
        }

    }
}




