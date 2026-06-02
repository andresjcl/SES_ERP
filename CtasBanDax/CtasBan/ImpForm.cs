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
            public ImpForm()
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
                rds.Name = "DataSet1";
                rds.Value = DattCom.SqlDatos.leerTablaAdcom(consulta);
                mostrarreportViewer.LocalReport.DataSources.Clear();
                mostrarreportViewer.LocalReport.DataSources.Add(rds);
                this.mostrarreportViewer.LocalReport.ReportPath = DattCom.datosEmpresa.pathAppl + "BinNet\\Rep\\CtasBco.rdlc";
                mostrarreportViewer.LocalReport.SetParameters(Empresa);
                this.mostrarreportViewer.RefreshReport();
            }
        }
 }

