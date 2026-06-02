using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql ;
using System.Data.SqlClient ;
namespace analisisFacRet
{
    public partial class FrmFacSinRet : Form
    {
        string strConxAdcom = "";
        AdcDax.DaxSofSys SYSEMP = new AdcDax.DaxSofSys();
        DaxLib.DaxLibBases  dxlib = new DaxLib.DaxLibBases() ;
        DataGridView mallaDatos;
        string tit1 = "";
        string tit2 = "";      
        public FrmFacSinRet()
        {
            InitializeComponent();
        }

        private void FrmFacSinRet_Load(object sender, EventArgs e)
        {
            DateTime lafecha = new DateTime (DateTime.Now.Year,DateTime.Now.Month,1);
            txtFechaIni.Text  = lafecha.ToShortDateString ();
            txtFechaFin.Text = lafecha.AddMonths(1).AddDays(-1).ToShortDateString() ;
            dxlib.TipoBase ="10";
            strConxAdcom=dxlib.StrAdcom() ;

        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
//@compraVenta as varchar(10), @fechaini as date, @fechafin as date,@tipo as varchar(10)
            string compras ="venta";
            if (radcompras.Checked ) compras = "compra";
            SqlConnection coneccion = new SqlConnection(strConxAdcom);
            
            coneccion.Open() ;
            string ssql = "exec Dax_Anafacret '" + compras + "','" + txtFechaIni.Text + "','" + txtFechaFin.Text + "','facret'"; 
            SqlCommand cmd3 = new SqlCommand(ssql, coneccion);
            SqlDataAdapter DaRec2 = new SqlDataAdapter(cmd3);
            DataTable dt = new DataTable();
            DaRec2.Fill(dt);
            mallafacret.DataSource = dt;
            
            ssql = "exec Dax_Anafacret '" + compras + "','" + txtFechaIni.Text + "','" + txtFechaFin.Text + "','retfac'";
            cmd3 = new SqlCommand(ssql, coneccion);
            DaRec2 = new SqlDataAdapter(cmd3);
            dt = new DataTable();
            DaRec2.Fill(dt);
            mallaretfac.DataSource = dt;

            ssql = "exec Dax_Anafacret '" + compras + "','" + txtFechaIni.Text + "','" + txtFechaFin.Text + "',''";
            cmd3 = new SqlCommand(ssql, coneccion);
            DaRec2 = new SqlDataAdapter(cmd3);
            dt = new DataTable();
            DaRec2.Fill(dt);
            mallaexcentas.DataSource = dt;

        }

        private void ImprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quemalla();
            if (mallaDatos.RowCount == 0) return;
            DataGridViewPrinterApplication1.frmMain imp = new DataGridViewPrinterApplication1.frmMain();
            preparaTitulo();
            imp.imprimir(mallaDatos, tit1, tit2, SYSEMP.EmpresaAct.nombre);
        }

        private void WordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quemalla();
            if (mallaDatos.RowCount == 0) return;
            ExportarGrid.Form1 exp = new ExportarGrid.Form1();
            preparaTitulo();
            exp.Exportar(mallaDatos, "W", SYSEMP.EmpresaAct.nombre, tit1 + "\r\n" + tit2);
        }

        private void ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quemalla();
            if (mallaDatos.RowCount == 0) return;
            ExportarGrid.Form1 exp = new ExportarGrid.Form1();
            preparaTitulo();
            exp.Exportar(mallaDatos, "E", SYSEMP.EmpresaAct.nombre, tit1 + "\r\n" + tit2);
        }

        private void PDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quemalla();
            if (mallaDatos.RowCount == 0) return;
            ExportarGrid.Form1 exp = new ExportarGrid.Form1();
            preparaTitulo();
            exp.Exportar(mallaDatos, "P", SYSEMP.EmpresaAct.nombre, tit1 + "\r\n" + tit2);
        }

        private void preparaTitulo()
        {
            tit2 = "Del: " + txtFechaIni.Text + " Al: " + txtFechaFin.Text;
            tit1 = "Analisis facturas y retenciones : ";
        }
        private void Quemalla()
        {
            if (tabControl1.SelectedIndex == 0) mallaDatos = mallafacret;
            if (tabControl1.SelectedIndex == 1) mallaDatos = mallaretfac;
            if (tabControl1.SelectedIndex == 2) mallaDatos = mallaexcentas ;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();            
        }
        
    }
}
