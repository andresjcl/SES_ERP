using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace DctosEmi
{ 
    public partial class frmVerDupli : Form
    {
        readonly DataTable dtt = new DataTable();
        double idclavedoc = 0;
        public frmVerDupli()
        {
            InitializeComponent();
        }
        public double SeleccionaDoc(string Suc, string Tipo,string numero,string strConx,string tabla="") 
        {
            if (numero == "") return 0;
            if ( tabla =="") tabla = "adcdoc";
            SqlConnection cnn = new SqlConnection(strConx);
            string sel = "SELECT Doc_sucursal , Opc_documento , Doc_numero ,Doc_NroIdDoc, Doc_NombreImp ,idclavedoc From "+tabla+" WHERE  doc_sucursal= '" + Suc + "' AND opc_documento='" + Tipo + "' AND doc_numero =" + numero;
            SqlDataAdapter da = new SqlDataAdapter(sel, cnn);
            da.Fill(dtt);
            if (dtt.Rows.Count == 0) return 0;
            if (dtt.Rows.Count == 1)
            {
                idclavedoc = Convert.ToDouble(dtt.Rows[0]["idclavedoc"]);
                return idclavedoc;
            }
            mallaDatos.DataSource = dtt;
            this.ShowDialog();
            return idclavedoc;    
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
            salirDelProceso();
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
