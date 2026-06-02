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
using SysEmpDatt;
namespace IvaRett
{
    public partial class FrmlistaReten : Form
    {
        string strConxAdcom = "";
        DataGridView mallaDatos;
        string tit1 = "";
        string tit2 = "";      
        public FrmlistaReten()
        {
            InitializeComponent();
        }

        private void FrmFacSinRet_Load(object sender, EventArgs e)
        {
            DateTime lafecha = new DateTime (DateTime.Now.Year,DateTime.Now.Month,1);
            txtFechaIni.Text  = lafecha.ToShortDateString ();
            txtFechaFin.Text = lafecha.AddMonths(1).AddDays(-1).ToShortDateString() ;
            strConxAdcom=datosEmpresa.strConxAdcom ;
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
//@compraVenta as varchar(10), @fechaini as date, @fechafin as date,@tipo as varchar(10)
            SqlConnection coneccion = new SqlConnection(strConxAdcom);            
            coneccion.Open() ;
            string opcion ="";
            string opcionTot="";
            string VentaCompra="";
            
            string DEL = "";
            string AL = "";
            try 
            {
                DEL = txtFechaIni.Text ;
                AL = txtFechaFin.Text ;
            }
            catch
            {
            }
            
            if (radventas.Checked == true)
            {
                VentaCompra = "RTC";
            }
            else 
            {
                VentaCompra = "RTP";
            }


            if (btnDocumento.Checked == true) 
            {
                opcionTot=  "Dax_SriLisRetAr '" + VentaCompra + "','" + DEL + "','" + AL + "'";
                opcion = "Dax_SriLisRetA '" + VentaCompra + "','" + DEL + "','" + AL + "'";
            }
            else
            {
                opcionTot=  "Dax_SriLisRetr '" + VentaCompra + "','" + DEL + "','" + AL + "'";
                opcion = "Dax_SriLisRet '" + VentaCompra + "','" + DEL + "','" + AL + "'";
            }

            SqlCommand cmd3 = new SqlCommand(opcion , coneccion);
            SqlDataAdapter DaRec2 = new SqlDataAdapter(cmd3);
            DataTable dt = new DataTable();
            DaRec2.Fill(dt);
            mallaListado.DataSource = dt;
            
            cmd3 = new SqlCommand(opcionTot, coneccion);
            DaRec2 = new SqlDataAdapter(cmd3);
            dt = new DataTable();
            DaRec2.Fill(dt);
            mallaTotales.DataSource = dt;
            diseñarMalla();
        }

        private void ImprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quemalla();
            if (mallaDatos.RowCount == 0) return;
            DataGridViewPrinterApplication1.frmMain imp = new DataGridViewPrinterApplication1.frmMain();
            preparaTitulo();
            imp.imprimir(mallaDatos, tit1, tit2, datosEmpresa.Emp_Nombre);
        }

        private void WordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quemalla();
            if (mallaDatos.RowCount == 0) return;
            ExportarGrid.Form1 exp = new ExportarGrid.Form1();
            preparaTitulo();
            exp.Exportar(mallaDatos, "W", datosEmpresa.Emp_Nombre , tit1 + "\r\n" + tit2);
        }

        private void ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quemalla();
            if (mallaDatos.RowCount == 0) return;
            ExportarGrid.Form1 exp = new ExportarGrid.Form1();
            preparaTitulo();
            exp.Exportar(mallaDatos, "E", datosEmpresa.Emp_Nombre, tit1 + "\r\n" + tit2);
        }

        private void PDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quemalla();
            if (mallaDatos.RowCount == 0) return;
            ExportarGrid.Form1 exp = new ExportarGrid.Form1();
            preparaTitulo();
            exp.Exportar(mallaDatos, "P", datosEmpresa.Emp_Nombre, tit1 + "\r\n" + tit2);
        }

        private void preparaTitulo()
        {
            tit2 = "Del: " + txtFechaIni.Text + " Al: " + txtFechaFin.Text;
            tit1 = "Analisis facturas y retenciones : ";
        }
        private void Quemalla()
        {
            if (tabControl1.SelectedIndex == 0) mallaDatos = mallaListado;
            if (tabControl1.SelectedIndex == 1) mallaDatos = mallaTotales;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();            
        }
        private void btnTipoRetencion_Click(object sender, EventArgs e)
        {
            this.Text = "LISTA DE RETENCIONES POR TIPO DE RETENCION";
            btnDocumento.Checked = false;
            limpiarMalla();
        }

        private void btnDocumento_Click(object sender, EventArgs e)
        {
            this.Text = "LISTA DE RETENCIONES POR DOCUMENTOS";
            btnTipoRetencion.Checked = false;
            limpiarMalla();
        }

        private void radventas_CheckedChanged(object sender, EventArgs e)
        {
            limpiarMalla();
        }
        private void diseñarMalla()
        {
            string formato = "#,#0.00;;";
            if (btnDocumento.Checked == true)
            {
                mallaListado.Columns["Monto"].DefaultCellStyle.Format = formato;
                mallaListado.Columns["Retención"].DefaultCellStyle.Format = formato;
                mallaListado.Columns["Por"].DefaultCellStyle.Format = formato;
                mallaListado.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                mallaListado.Columns["Retención"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                mallaListado.Columns["Por"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                mallaTotales.Columns["Mon"].DefaultCellStyle.Format = formato;
                mallaTotales.Columns["Retencion"].DefaultCellStyle.Format = formato;
                mallaTotales.Columns["Mon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                mallaTotales.Columns["Retencion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            else
            {
                mallaListado.Columns["valBasRenta_1"].DefaultCellStyle.Format = formato;
                mallaListado.Columns["valBasRenta_1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                mallaListado.Columns["por_1"].DefaultCellStyle.Format = formato;
                mallaListado.Columns["por_1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                mallaListado.Columns["valReten_1"].DefaultCellStyle.Format = formato;
                mallaListado.Columns["valReten_1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                mallaListado.Columns["valBasRenta_2"].DefaultCellStyle.Format = formato;
                mallaListado.Columns["valBasRenta_2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                mallaListado.Columns["por_2"].DefaultCellStyle.Format = formato;
                mallaListado.Columns["por_2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                mallaListado.Columns["valReten_2"].DefaultCellStyle.Format = formato;
                mallaListado.Columns["valReten_2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                mallaListado.Columns["valBasBienes"].DefaultCellStyle.Format = formato;
                mallaListado.Columns["valBasBienes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                mallaListado.Columns["Por"].DefaultCellStyle.Format = formato;
                mallaListado.Columns["Por"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                mallaListado.Columns["valRete"].DefaultCellStyle.Format = formato;
                mallaListado.Columns["valRete"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                mallaListado.Columns["valBasServicio"].DefaultCellStyle.Format = formato;
                mallaListado.Columns["valBasServicio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                mallaListado.Columns["valRete"].DefaultCellStyle.Format = formato;
                mallaListado.Columns["valRete"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                mallaListado.Columns["valBasServicio"].DefaultCellStyle.Format = formato;
                mallaListado.Columns["valBasServicio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                mallaListado.Columns["Por1"].DefaultCellStyle.Format = formato;
                mallaListado.Columns["Por1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                mallaListado.Columns["valRete1"].DefaultCellStyle.Format = formato;
                mallaListado.Columns["valRete1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                mallaTotales.Columns["MontoBase"].DefaultCellStyle.Format = formato;
                mallaTotales.Columns["MontoBase"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                mallaTotales.Columns["%Reten."].DefaultCellStyle.Format = formato;
                mallaTotales.Columns["%Reten."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                mallaTotales.Columns["ValorRetenido"].DefaultCellStyle.Format = formato;
                mallaTotales.Columns["ValorRetenido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                mallaListado.Rows[mallaListado.Rows.Count - 1].Frozen = true;
                mallaListado.Rows[mallaListado.Rows.Count - 1].HeaderCell.Value = "TOT";
            }
        }
        private void limpiarMalla()
        {
            mallaListado.Columns.Clear();
            mallaTotales.Columns.Clear();
        }        
    }
}
