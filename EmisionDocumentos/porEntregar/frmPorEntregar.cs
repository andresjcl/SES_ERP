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
    public partial class frmPorEntregar : Form
    {
        public string Cliente="";
        public string NomCliente="";
        public string Artículo="";
        public string NomArticulo="";
        public DateTime fecha=DateTime.Now ;
        public string strConxAdcom = "";
        string NumeroDocumento ="";

        public frmPorEntregar()
        {
            InitializeComponent();
        }

        public string EscojeDoc()
        {
        this.ShowDialog();
        return NumeroDocumento;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            RegresarValor();
        }
        private void RegresarValor()
        {
            try
            {
                NumeroDocumento = malla.Rows[malla.CurrentCell.RowIndex].Cells["numero"].Value.ToString();
            }
            catch { NumeroDocumento = ""; }
            this.Close();        
        }

        private void frmPorEntregar_Load(object sender, EventArgs e)
        {
//            ModuloActual = this.Name;
            if (Artículo.Length  > 0 )
            {
                this.Text  = "Entregas pendientes de : " + Artículo + " - " + NomArticulo;
            }
            else if (Cliente.Length  > 0)
            {
                this.Text  = "Entregas pendientes de artículos para : " + Cliente + " - " + NomCliente;
            }

            string ssql ="ADC_CNENTRG '" + fecha + "','" + Cliente + "','" + Artículo + "','','',0";
            SqlDataAdapter da = new SqlDataAdapter(ssql, strConxAdcom);
            DataTable rs = new DataTable ();
            da.Fill(rs);
            malla.DataSource = rs;
        }

        private void malla_DoubleClick(object sender, EventArgs e)
        {
            RegresarValor();
        }

        private void malla_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F2)
            {
                frmPorEntgDetalle prog = new frmPorEntgDetalle();
                prog.DocSuc = malla.Rows[malla.CurrentCell.RowIndex].Cells["suc"].Value.ToString();
                prog.Doctipo = malla.Rows[malla.CurrentCell.RowIndex].Cells["tip"].Value.ToString();
                prog.DocNumero = Convert.ToDouble (malla.Rows[malla.CurrentCell.RowIndex].Cells["numero"].Value);
                prog.strConxAdcom = strConxAdcom;
                prog.ShowDialog();
            }
        }
    }
}




