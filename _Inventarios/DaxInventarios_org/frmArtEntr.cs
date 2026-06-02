using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace DaxInvent
{
    internal partial class frmArtEntr : Form
    {
        internal frmArtEntr(string docSuc,string docTip,string docNum,double docIdclave,string conxadc)
        {
            InitializeComponent();
            cargarDatos(docSuc,docTip,docNum,docIdclave,conxadc);
        }
        private void cargarDatos(string docSuc,string docTip,string docNum,double docIdclave,string strConxAdcom)
        {
            if (docSuc == "" || docTip == "" || docNum == "") return;
            DataTable Rs = new DataTable();
            string ssql ="";
            this.Text = "Entregas de artículos realizadas por documento : " + docSuc + " - "  + docTip + " - " + docNum;
            ssql = "ADC_CNENTRG '','','','" + docSuc + "','" + docTip + "'," + docNum;
            SqlDataAdapter da = new SqlDataAdapter(ssql, strConxAdcom);
            da.Fill(Rs);
            malla.DataSource = Rs;
            malla.Columns["Facturada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            malla.Columns["Entregada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            malla.Columns["Pendiente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            malla.Columns["Excedente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            malla.Columns["Facturada"].DefaultCellStyle.Format = "N2";
            malla.Columns["Entregada"].DefaultCellStyle.Format = "N2";
            malla.Columns["Pendiente"].DefaultCellStyle.Format = "N2";
            malla.Columns["Excedente"].DefaultCellStyle.Format = "N2";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmArtEntr_Load(object sender, EventArgs e)
        {

        }

        private void malla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
