using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DaxLib;
using AdcDax;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace ExistenciasPorBodega
{
    public partial class Form1 : Form
    {

        //Librerias inicializadas 
        private AdcDax.DaxSofSys adcDaxx = new DaxSofSys();
        DaxLib.DaxLibBases coneccion = new DaxLibBases();
        //variables para la conexion
        SqlConnection conectarAdcom = new SqlConnection();
        String coneccionString = "";

        private string consulta;                                    //Consulta para mostrar en el datagridview o reportViewer
        private Boolean opcion = true; //variable para validar el panel de opciones  

        private Empresa emp;///variable que indica el nombre de la empresa

        public Form1()
        {
            InitializeComponent();
        }

        //conecta a la base de datos BdAdcomDx10
        public String conectar()
        {
            try
            {
                coneccion.TipoBase = "10";
                conectarAdcom.ConnectionString = coneccion.StrAdcom();
                coneccionString = coneccion.StrAdcom();
            }
            catch
            {
                MessageBox.Show("No se ha conectado al servidor AdcomDx");
            }
            return coneccionString;
        }
        
        //calcula dataset para mostrar el report
        public DataSet CalcularDataSet(String consulta)
        {
            SqlDataAdapter misqlDa = new SqlDataAdapter(consulta, coneccionString);
            DataSet dato = new DataSet();
            misqlDa.Fill(dato);
            return dato;
        }

        //metodo muestra reportes en reportviewer
        private void reporte()
        {
            consulta = " select Doc_Bodega, Art_categor as CAT, Tra_Codigo as CodArticulo, Tra_nombre as Descripcion, "
                        + " SUM(Tra_Inventario*Tra_cantidad) as Total from AdcTra left join AdcArt on Art_codigo = Tra_Codigo "
                        + " group by Doc_Bodega, Art_categor, Tra_Codigo, Tra_nombre  ";
            ReportDataSource rds = new ReportDataSource();//instancia datasource
            ReportParameter empresa = new ReportParameter("Empresa", emp.nombre);//inicializa el parametro a enviar
            rds.Name = "DataSet1";//nombra el report datasource
            //le otorga datos al report data source
            rds.Value = CalcularDataSet(consulta).Tables[0]; //.("datos");    
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
            emp = adcDaxx.EmpresaAct;
            try
            {
                conectar();
            }
            catch
            {
                MessageBox.Show("No se ha conectado al servidor AdcomDx");
            }
        }
    }
}
