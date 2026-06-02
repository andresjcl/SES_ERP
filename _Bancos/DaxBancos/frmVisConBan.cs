using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DaxBan
{
    internal partial class frmVisConBan : Form
    {
        public string textBoxFechaDesde;
        public string textBoxFechaHasta;
        public string comboCuentaBanco;
        public string Nombre;
        public string comboBanco;
        public SqlConnection conexion ;  //= new SqlConnection();
        public string pathappl;
        public string textSaldoSistema;
        public string textSaldoBanco;
        public string textDiferencia;
        internal  frmVisConBan()
        {
            InitializeComponent();
        }
        
        internal  void  form2_load() 
        //private void reporte()
        {
            string consulta = "";
            reportViewer1.Visible = true;
            ReportDataSource rds = new ReportDataSource();
            consulta = "EXEC Dax_Conbc '" + textBoxFechaDesde + "', '" + textBoxFechaHasta + "', '" + comboCuentaBanco + "', 'n' ";
            ReportParameter FechaInicial = new ReportParameter("FechaInicial", textBoxFechaDesde);
            ReportParameter FechaFinal = new ReportParameter("FechaFinal", textBoxFechaHasta);
            ReportParameter SaldoSistema = new ReportParameter("SaldoSistema", textSaldoSistema);
            ReportParameter SaldoBanco = new ReportParameter("SaldoBanco", textSaldoBanco);
            ReportParameter Diferencia = new ReportParameter("Diferencia", textDiferencia);
            ReportParameter empresa = new ReportParameter("Empresa", Nombre);
            ReportParameter banco = new ReportParameter("Banco", comboBanco);
            ReportParameter cuenta = new ReportParameter("Cuenta", comboCuentaBanco);
            try
            {
                rds.Name = "DataSet1";
                rds.Value = CalcularDataSet(consulta).Tables[0];
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.LocalReport.ReportPath = pathappl + "BinNet\\Rep\\Cnclbc.rdlc";
                reportViewer1.LocalReport.SetParameters(FechaInicial);
                reportViewer1.LocalReport.SetParameters(FechaFinal);
                reportViewer1.LocalReport.SetParameters(empresa);
                reportViewer1.LocalReport.SetParameters(banco);
                reportViewer1.LocalReport.SetParameters(cuenta);
                reportViewer1.LocalReport.SetParameters(SaldoBanco);
                reportViewer1.LocalReport.SetParameters(SaldoSistema);
                reportViewer1.LocalReport.SetParameters(Diferencia);
                reportViewer1.RefreshReport();
                this.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message );
            }

        }
        private DataSet CalcularDataSet(String consulta)
        {
            SqlDataAdapter misqlDa = new SqlDataAdapter(consulta, conexion);
            DataSet dato = new DataSet();
            misqlDa.Fill(dato);
            return dato;
        }

        private void frmVisConBan_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}

