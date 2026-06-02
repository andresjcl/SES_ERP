using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using SysEmpDatt;

namespace ExistenciasPorBodega
{
    public partial class Form1 : Form
    {

        //Librerias inicializadas 
        //variables para la conexion
        SqlConnection conectarAdcom = new SqlConnection();
        String coneccionString = "";

        private string consulta;                                    //Consulta para mostrar en el datagridview o reportViewer
        private Boolean opcion = true; //variable para validar el panel de opciones  
        public Form1()
        {
            InitializeComponent();
        }
       
        //metodo muestra reportes en reportviewer
        private void reporte()
        {
            consulta = " select Doc_Bodega, Art_categor as CAT, Tra_Codigo as CodArticulo, Tra_nombre as Descripcion, "
                        + " SUM(Tra_Inventario*Tra_cantidad) as Total from AdcTra left join AdcArt on Art_codigo = Tra_Codigo "
                        + " group by Doc_Bodega, Art_categor, Tra_Codigo, Tra_nombre  ";
            ReportDataSource rds = new ReportDataSource();//instancia datasource
            ReportParameter empresa = new ReportParameter("Empresa", datosEmpresa.Emp_Nombre);//inicializa el parametro a enviar
            rds.Name = "DataSet1";//nombra el report datasource
            //le otorga datos al report data source
            rds.Value = SqlDatos.leerTablaAdcom(consulta); //.("datos");    
            //limpia el report data source
            mostrarreportViewer.LocalReport.DataSources.Clear();
            //le agrega el data source al report
            mostrarreportViewer.LocalReport.DataSources.Add(rds);
            //busca el reporte en donde se encuentre 
            this.mostrarreportViewer.LocalReport.ReportPath = "..\\..\\Imprimir.rdlc";
            mostrarreportViewer.LocalReport.SetParameters(empresa);//envia el parametro empresa al reporte
            this.mostrarreportViewer.RefreshReport();//refresca el reporte
        }


        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void actualizartoolStripButton6_Click(object sender, EventArgs e)
        {
            reporte();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (opcion == true)
            {
                opcion = panelOpciones.Visible = false;
                contenerdorsplitContainer.Panel1Collapsed = true;
            }
            else
            {
                opcion = panelOpciones.Visible = true;
                contenerdorsplitContainer.Panel1Collapsed = false;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) { this.Activate(); } else { contenerdorsplitContainer.SplitterDistance = 183; }//este activoa cuando este minimizada la forma
        } 

        private void Form1_Load(object sender, EventArgs e)
        {
            contenerdorsplitContainer.SplitterDistance = 183;//tamaño definido del panel opciones 
            this.reportViewer1.RefreshReport();
        }
    }
}
