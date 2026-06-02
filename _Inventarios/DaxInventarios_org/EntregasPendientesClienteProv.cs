using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DaxInvent
{
    public partial class EntregasPendientesClienteProv : Form
    {
        public string docsuc="";
        public string docOpc="";
        public string docNumero = "";
        public double docIdclave=0;      
        string codConsulta = "";
        string strConxAdcom = "";
        Boolean esCliente = false;        
        public EntregasPendientesClienteProv(string conxadc,string clieOprod, string cod, string nom)
        {
            InitializeComponent();
            strConxAdcom = conxadc;
            esCliente = (clieOprod.ToUpper() == "C");
            codConsulta = cod;           
            cargarDatos(cod,nom,conxadc);
        }
        private void cargarDatos(string cod, string nom,string strConxAdcom)
        {
            if (cod == "") return;
            DataTable Rs = new DataTable();
            string ssql ="";
            string fecha = DateTime.Now.ToShortDateString ();
            if (esCliente )
            {
                this.Text = "Entregas pendientes de artículos para : " + cod + " - " + nom;
                ssql = "ADC_CNENTRG '','" + fecha + "','" + cod + "','','','',0";
            }
            else
            {  
                this.Text = "Entregas pendientes de : " + cod + " - " + nom;
                ssql = "ADC_CNENTRG '','" + fecha + "','','" + cod + "','','',0";
            }
            SqlDataAdapter da = new SqlDataAdapter(ssql, strConxAdcom);
               da.Fill (Rs);
               malla.DataSource=Rs;
               malla.Columns["Facturada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
               malla.Columns["Entregada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
               malla.Columns["Pendiente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
               malla.Columns["Excedente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
               malla.Columns["Facturada"].DefaultCellStyle.Format = "N2";
               malla.Columns["Entregada"].DefaultCellStyle.Format = "N2";
               malla.Columns["Pendiente"].DefaultCellStyle.Format = "N2";
               malla.Columns["Excedente"].DefaultCellStyle.Format = "N2";
               //malla.Columns["NÚMERO"].DefaultCellStyle.Format  = "N2";
        }

        private void malla_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            prepararSalida();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            prepararSalida();
            this.Close();
        }
        private void prepararSalida()
        {
            if (malla.CurrentRow == null || malla.CurrentRow.Cells["SUC"] == null) return;
            docsuc = malla.CurrentRow.Cells["SUC"].Value.ToString();
            docOpc  = malla.CurrentRow.Cells["DOC"].Value.ToString();
            docNumero = malla.CurrentRow.Cells["NÚMERO"].Value.ToString();
        }
        private void consultaEntregas()
        {
            prepararSalida();
            EntregasRealizadasClienteProv prog = new EntregasRealizadasClienteProv(docsuc, docOpc, docNumero, 0, strConxAdcom);
            prog.ShowDialog();
            prog.Dispose();
        }

        private void malla_KeyDown(object sender, KeyEventArgs e)
        {
            consultaEntregas();
        }
    }
}
