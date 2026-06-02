using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using SysEmpDatt;

namespace adcArticulosPrecios
{
    public partial class frmImprime : Form
    {
        public string NombreEmpresa = "dfsdafdf";
        public string CodigoInicial = "";
        public string CodigoFinal = "";
        public string strConxAdcom = "";
        public string Patappl="";
        public string conCategoria = "";
        public string conClase = "";
        public string conGrupo = "";
        public string conSubgrupo = "";
        public string ConIva = "S";
        public string Pv1 = "S";
        public string Pv2 = "S";
        public string Pv3 = "S";
        public string Pv4 = "S";
        public string Pv5 = "S";
        public string Desc = "S";
        public string Lim = "S";
        public string orden = "N";
        string TituloReporte = "";
        string DetalleReporte = "";
        public frmImprime()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {


            string cad = "SELECT Codigo, nombre, Medida,NomCategoria ,NomCLase, NomGrupo, NomSubgrupo, Art_precvta1, Art_precvta2, Art_precvta3, Art_precvta4, Art_precvta5, NomCategoria, Art_descuen, ";
            cad += " art_limDescuento, Art_precvta1_inc, Art_precvta2_inc, Art_precvta3_inc,";
            cad += " Art_precvta4_inc, Art_precvta5_inc";
            cad += " FROM ArticulosGrupos";

            if (ConIva == "S") { TituloReporte = " LISTA DE PRECIOS INCLUIDO EL IVA "; } else { TituloReporte = " LISTA DE PRECIOS SIN INCLUIR IVA "; }

            string where = " where Codigo > '' ";
            string order = "";
            if (orden == "N")
            {            
                order = " order by nombre ";
                DetalleReporte = " Orden Alfabético ";
                if (CodigoFinal != "") where += " and nombre >= '" + CodigoInicial + "' and nombre <= '" + CodigoFinal + "' ";
            }
            else 
            {
                order = " order by codigo ";
                DetalleReporte  = " Orden por código ";
                if (CodigoFinal != "") where += " and codigo >= '" + CodigoInicial + "' and codigo <= '" + CodigoFinal + "' ";
            }

            if (conCategoria != "") { where += " and NomCategoria = '" + conCategoria + "' "; }
            if (conClase != "") { where += " and NomClase = '" + conClase  + "' "; }
            if (conGrupo != "") { where += " and NomGrupo = '" + conGrupo  + "' "; }
            if (conSubgrupo != "") { where += " and NomSubgrupo = '" + conSubgrupo + "' "; }

            if (CodigoFinal != "") { DetalleReporte += "De: " + CodigoInicial.Trim()  + " a: " + CodigoFinal.Trim() ;}
            if (conCategoria != "") DetalleReporte  += "," + conCategoria;
            if (conClase != "") DetalleReporte += "," + conClase;
            if (conGrupo != "") DetalleReporte += "," + conGrupo;

            cad += where + order;

            ReportDataSource rds =  new ReportDataSource();
            ReportParameter Empresa = new ReportParameter("Empresa", NombreEmpresa);
            ReportParameter Titulo = new ReportParameter("Titulo", TituloReporte );
            ReportParameter opcionesreporte = new ReportParameter("opcionesreporte", DetalleReporte);
            ReportParameter conIva = new ReportParameter("conIva", ConIva);
            ReportParameter pv1 = new ReportParameter("pv1", Pv1);
            ReportParameter pv2 = new ReportParameter("pv2", Pv2);
            ReportParameter pv3 = new ReportParameter("pv3", Pv3);
            ReportParameter pv4 = new ReportParameter("pv4", Pv4);
            ReportParameter pv5 = new ReportParameter("pv5", Pv5);
            ReportParameter desc = new ReportParameter("desc", Desc);
            ReportParameter lim = new ReportParameter("lim", Lim);

            rds.Name = "DataSet1";
            rds.Value = SqlDatos.leerTablaAdcom(cad);

            //reportViewer1.Visible = true ;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.LocalReport.ReportPath = Patappl + "BinNet\\Rep\\Precsvta.rdlc";

            reportViewer1.LocalReport.SetParameters(Empresa);
            reportViewer1.LocalReport.SetParameters(Titulo);
            reportViewer1.LocalReport.SetParameters(opcionesreporte);
            reportViewer1.LocalReport.SetParameters(conIva);
            reportViewer1.LocalReport.SetParameters(pv1);
            reportViewer1.LocalReport.SetParameters(pv2);
            reportViewer1.LocalReport.SetParameters(pv3);
            reportViewer1.LocalReport.SetParameters(pv4);
            reportViewer1.LocalReport.SetParameters(pv5);
            reportViewer1.LocalReport.SetParameters(desc);
            reportViewer1.LocalReport.SetParameters(lim);
            
            this.reportViewer1.RefreshReport();
        }
        //private  DataSet CalcularDataSet(string cadena) 
        //{
        //    DaxLib.DaxLibBases dlib = new DaxLib.DaxLibBases();
        //    dlib.TipoBase = "10";
        //SqlConnection conectar =  new SqlConnection (dlib.StrAdcom());
        //conectar.Open ();
        //SqlDataAdapter sqlAdap = new SqlDataAdapter(cadena, conectar);
        //DataSet datS = new DataSet();
        //sqlAdap.Fill(datS, "precios");
        //conectar.Close();
        //return datS;
        //}
    }
}
