using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Reporting.WinForms;
using System.Windows.Forms;
namespace CtasCorrientes
{
    public partial class frmVerEstdoCta : Form
    {
        string pathAppl = "";
        string conxAdcom = "";
        public frmVerEstdoCta(string path, string conxadc)
        {
            InitializeComponent();
            pathAppl = path;
            conxAdcom = conxadc;
        }
        private void frmVerEstdoCta_Load(object sender, EventArgs e)
        {
            string consulta = datoReporte.ssql;
            reportViewer1.Visible = true;
            
            ReportDataSource rds = new ReportDataSource();
            ReportParameter cliente = new ReportParameter("cliente", datoReporte.cliente );
            ReportParameter direccion = new ReportParameter("direccion", datoReporte.direccion );
            ReportParameter Disponible = new ReportParameter("Disponible", datoReporte.Disponible.ToString() );
            ReportParameter fechaSaldo = new ReportParameter("fechaSaldo", datoReporte.fechaSaldo);
            ReportParameter fechaDesde = new ReportParameter("fechaDesde", datoReporte.fechaDesde);
            ReportParameter limiteCredito = new ReportParameter("limiteCredito", datoReporte.limiteCredito.ToString());
            ReportParameter nombreEmpresa = new ReportParameter("nombreEmpresa", datoReporte.nombreEmpresa);
            ReportParameter saldo = new ReportParameter("saldo", datoReporte.saldo.ToString());
            ReportParameter telefono = new ReportParameter("telefono", datoReporte.telefono);
            try
            {
                rds.Name = "DataSet1";

                rds.Value = CalcularDataSet(consulta);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.LocalReport.ReportPath = pathAppl + "BinNet\\Rep\\estdCtaClt.rdlc";
                
                reportViewer1.LocalReport.SetParameters(cliente);
                reportViewer1.LocalReport.SetParameters(direccion);
                reportViewer1.LocalReport.SetParameters(Disponible);
                reportViewer1.LocalReport.SetParameters(fechaSaldo);
                reportViewer1.LocalReport.SetParameters(fechaDesde);
                reportViewer1.LocalReport.SetParameters(limiteCredito);
                reportViewer1.LocalReport.SetParameters(nombreEmpresa);
                reportViewer1.LocalReport.SetParameters(saldo);
                reportViewer1.LocalReport.SetParameters(telefono);
                reportViewer1.RefreshReport();
                this.Show();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }        
        private DataTable CalcularDataSet(String consulta)
        {
            SqlDataAdapter misqlDa = new SqlDataAdapter(consulta, conxAdcom);
            DataTable dato = new DataTable();
            misqlDa.Fill(dato);
            return dato;
        }
    }
}
