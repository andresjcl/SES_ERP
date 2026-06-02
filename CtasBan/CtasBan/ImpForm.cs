using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;
using DaxLib;
namespace CtasBan
{
    public partial class ImpForm : Form
    {
        //ConeccionSQL coneccionSQL = new ConeccionSQL();
        CtasBanForm ctasBanForm = new CtasBanForm();
        String consulta = "";
        //SqlConnection conectarAdcom = new SqlConnection();

        //datos que van como parametros al reporte
        public SqlParameter[] SearchValue = new SqlParameter[1];
        //public Empresa emp;
        String coneccionString = "";
        string EmpresaNom = "";
        string pathappl = "";
        public ImpForm()
        {
            InitializeComponent();
            conectar();
            reporte();
        }

        public void conectar()
        {
            AdcDax.DaxSofSys dax = new AdcDax.DaxSofSys();
            AdcDax.Empresa emp = dax.EmpresaAct ;            
            coneccionString = ctasBanForm.conectar();
            EmpresaNom = emp.nombre;
            pathappl = emp.PatAppl;
            dax = null;
        }

        private void ImpForm_Load(object sender, EventArgs e)
        {          
            this.mostrarreportViewer.RefreshReport();
        }

        //calcula dataset para mostrar el report
        public DataSet CalcularDataSet(String consulta)
        {           
            SqlDataAdapter misqlDa = new SqlDataAdapter(consulta, coneccionString);
            DataSet dato = new DataSet();
            misqlDa.Fill(dato);
            return dato;
        }

        //select * from AdcCtaBco
        private void reporte() {
            consulta = "SELECT * FROM AdcCtaBco";
            ReportDataSource rds = new ReportDataSource();
            ReportParameter Empresa = new ReportParameter("Empresa",EmpresaNom);
            rds.Name = "DataSet1";
            //le otorga datos al report data source
            rds.Value = CalcularDataSet(consulta).Tables[0]; //.("datos");    
            //limpia el report data source
            mostrarreportViewer.LocalReport.DataSources.Clear();
            //le agrega el data source al report
            mostrarreportViewer.LocalReport.DataSources.Add(rds);
            //busca el reporte en donde se encuentre 
            this.mostrarreportViewer.LocalReport.ReportPath = pathappl + "BinNet\\Rep\\CtasBco.rdlc";
            mostrarreportViewer.LocalReport.SetParameters(Empresa);
            this.mostrarreportViewer.RefreshReport();
        }
    }
}
