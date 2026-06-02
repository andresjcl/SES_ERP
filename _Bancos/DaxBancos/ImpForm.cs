using System;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;

namespace DaxBan
{
    internal partial class ImpForm : Form
    {

        CtasBanForm ctasBanForm = new CtasBanForm();
        String consulta = "";
        private SqlParameter[] SearchValue = new SqlParameter[1];
        internal ImpForm()
        {
            InitializeComponent();
            reporte();
        }

        private void ImpForm_Load(object sender, EventArgs e)
        {
            this.mostrarreportViewer.RefreshReport();
        }

        private void reporte()
        {
            consulta = "SELECT * FROM AdcCtaBco";
            ReportDataSource rds = new ReportDataSource();
            ReportParameter Empresa = new ReportParameter("Empresa", DattCom.datosEmpresa.Emp_Nombre);
            rds.Name = "DataSetCtas";
            rds.Value = DattCom.SqlDatos.leerTablaAdcom(consulta);
            mostrarreportViewer.LocalReport.DataSources.Clear();
            mostrarreportViewer.LocalReport.DataSources.Add(rds);
            this.mostrarreportViewer.LocalReport.ReportPath = DattCom.datosEmpresa.pathAppl + "BinNet\\Rep\\CtasBco.rdlc";
            mostrarreportViewer.LocalReport.SetParameters(Empresa);
            this.mostrarreportViewer.RefreshReport();
        }
    }
}
