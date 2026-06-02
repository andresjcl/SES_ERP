using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ConsAplicacion
{
    public partial class frmAplica : Form
    {
        string strConxAdcom = "";
        string FechaHasta = "";
        string Docum = "";
        string Num = "";
        string Sucursal="";
        double IdClaveDoc = 0;

        public frmAplica(string strcondax, double IdClaveDocC, string Documento, string  numero, string fecha = "", string DocSuc = "")
        {
            InitializeComponent();
            FechaHasta = fecha;
            Docum = Documento;
            Num = numero;
            Sucursal = DocSuc;
            IdClaveDoc = IdClaveDocC;
            strConxAdcom = strcondax;
            llenarMalla();
        }
            
        private void llenarMalla()
        {
            this.Text = "Documentos modificados (aplicados) por: " + Sucursal + " - " + Docum + "-" + Num;
            string cod = "";
            cod = "ConAPlica '" + Sucursal  + "','" + Docum + "'," + IdClaveDoc.ToString() + ",'" + FechaHasta + "'" ;

            DataTable dt = new DataTable ();
            SqlDataAdapter da = new SqlDataAdapter(cod, strConxAdcom);
            da.Fill(dt);
            malla.DataSource = dt;
            totalizar();
            malla.Columns["idclavedocapl"].Visible = false;
        }

        private void totalizar()
        {
            double TotalDoc = 0;
            TotalDoc = 0;
            foreach ( DataGridViewRow row in malla.Rows)
            {
                TotalDoc += Convert.ToDouble("0" + row.Cells ["ValorAplica"].Value.ToString());
            }
            Label1.Text = "Total aplicaciones: " + String.Format("{0,12:D2}", TotalDoc.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
