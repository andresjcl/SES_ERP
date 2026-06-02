using DattCom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DaxInvent
{
	public partial class frmBuscarPreferenciaPlato : Form
	{
        string CodigoRet = "";
        string Dedonde = "";
        string CodigoArt = "";
        public frmBuscarPreferenciaPlato()
		{
			InitializeComponent();
		}

		private void frmBuscarPreferenciaPlato_Load(object sender, EventArgs e)
		{
			ArreglaMalla();
		}
        private void ArreglaMalla()
        {
            string Dcatego = "";
            string Dgrupo = "";
            string Dclase = "";
            DataTable Rs = new DataTable();
            string codsql = "select Abreviación,Descripcion from syscod where tiporeferencia='CambioPlatos' and Abreviación<>'#' ";
           
            SqlDataAdapter da = new SqlDataAdapter(codsql, datosEmpresa.strConxAdcom);
            da.Fill(Rs);
            malla.DataSource = Rs;
        }
        public string IniciaBuscaPlato(string codigo, string DeDon, string ipo = "", string fecha = "", string Bodega = "")
        {
            Dedonde = DeDon;
            CodigoArt = codigo;
            txtDescripcion.Text = codigo;
            this.ShowDialog();
            return CodigoRet;
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
                CodigoRet = malla.CurrentRow.Cells["Abreviación"].Value.ToString();
                this.Close();
            }
            catch { CodigoRet = ""; }
        }

		private void btnBuscar_Click(object sender, EventArgs e)
		{
            ArreglaMalla();
        }
	}
}
