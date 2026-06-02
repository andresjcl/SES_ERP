using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace daxEmiFacPv
{
    public partial class Form1 : Form
    {
        DataTable dtt = new DataTable();
        double idclavedoc = 0;
        public Form1()
        {
            InitializeComponent();            
        }
        public double SeleccionaDoc(string Suc, string Tipo,string numero,string strConx) 
        {

            SqlConnection cnn = new SqlConnection(strConx);
            string sel = "SELECT Doc_sucursal , Opc_documento , Doc_numero ,Doc_NroIdDoc, Doc_NombreImp ,idclavedoc From adcdoc WHERE  doc_sucursal= '" + Suc + "' AND opc_documento='" + Tipo + "' AND doc_numero =" + numero;
            SqlDataAdapter da = new SqlDataAdapter(sel, cnn);
            da.Fill(dtt);
            if (dtt.Rows.Count == 0) return 0;
            this.ShowDialog();
            return idclavedoc;    
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            mallaDatos.DataSource = dtt;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            idclavedoc = -1;
            this.Close();
            dtt.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            idclavedoc = Convert.ToDouble(mallaDatos.Rows[mallaDatos.CurrentCell.RowIndex].Cells["idclavedoc"].Value);
        }

        private void mallaDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            salirDelProceso();
        }

        private void mallaDatos_DoubleClick(object sender, EventArgs e)
        {
            idclavedoc = Convert.ToDouble(mallaDatos.Rows[mallaDatos.CurrentCell.RowIndex].Cells["idclavedoc"].Value);
            salirDelProceso();
        }
        private void salirDelProceso()
        {
            this.Close();
            dtt.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            salirDelProceso();
        }

    }
}
