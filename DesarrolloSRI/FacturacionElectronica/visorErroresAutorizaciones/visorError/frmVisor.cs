using System;
using System.Data;
using System.IO ;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace DaxValDocElec
{
    public partial class frmVisor : Form
    {
        //string pasarCodigoConsultas = "";
        //Int64 periodo = 0;
        //string strConect = "";
        //string[] opc;
        //AdcDax.DaxSofSys defemp = new AdcDax.DaxSofSys();
        //AdcDax.Empresa emp;
        public frmVisor(List<string> listaErrores,string Tit)
        {
            InitializeComponent();
            try
            {
                //emp = defemp.EmpresaAct;
                //opc = emp.String2.Split(new Char[] { '!' });
                //periodo = Convert.ToInt64(opc[0]);
                //strConect = opc[1];
                //emp.String2 = "";
                cargarMalla(listaErrores);
            }
            catch { this.Close(); return; }
        }

        private void cargarMalla(List<string> listaError)
        {

            mallaError.Columns.Clear();
            mallaError.Columns.Add("Error","Error");

            foreach (string err in listaError)
            {
                mallaError.Rows.Add();
                mallaError.Rows[mallaError.Rows.Count - 1].Cells[0].Value = err;
            }
        }

        //private void EjecutarProgramaExterno(string programa, string NombreOpcion)
        //{
        //    string OPCION = "";
        //    string codigo = mallaError.CurrentRow.Cells["idEmpleado"].ToString();
        //    if (programa.Substring(0, 1) == "(" && programa.Substring(3, 1) == ")") { OPCION = programa.Substring(1, 2); programa = programa.Substring(4); }
        //    string[] filePaths = Directory.GetFiles(emp.PatAppl, programa);
        //    if (filePaths[0].Length != 0)
        //    {
        //        try
        //        {
        //            System.Diagnostics.ProcessStartInfo pi = new System.Diagnostics.ProcessStartInfo();
        //            pi.FileName = programa;
        //            pi.Arguments = OPCION;
        //            pi.WorkingDirectory = emp.PatAppl;
        //            pi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
        //            //para pasar codigos a las consultas

        //            System.Diagnostics.Process.Start(pi);
        //        }
        //        catch { }
        //    }

        //}

        private void btnexcel_Click(object sender, EventArgs e)
        {
            mallExp.Form1 exp = new mallExp.Form1();
            String Empresa  = "";
            exp.Exportar(mallaError, "E", Empresa, "Directorio");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close ();
        }

        private void Imprimir_Click(object sender, EventArgs e)
        {
            DataGridViewPrinterApplication1.frmMain imp = new  DataGridViewPrinterApplication1.frmMain();
            imp.imprimir(mallaError );
        }

        private void btnpdf_Click(object sender, EventArgs e)
        {
            mallExp.Form1 exp = new mallExp.Form1();
            String Empresa = "";
            exp.Exportar(mallaError, "P", Empresa, "Directorio");
        }

        private void btnword_Click(object sender, EventArgs e)
        {
            mallExp.Form1 exp = new mallExp.Form1();
            String Empresa = "";
            exp.Exportar(mallaError, "W", Empresa, "Directorio");
        }
    }
}
