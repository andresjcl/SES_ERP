using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace DaxInvent
{
    public partial class Form1 : Form
    {
        string strConxAdcom = "";
        AdcDax.DaxSofSys SYSEMP = new AdcDax.DaxSofSys();
        DaxLib.DaxLibBases dxlib = new DaxLib.DaxLibBases();
        DataGridView mallaDatos;
        string tit1 = "";
        string tit2 = "";
        public Form1()
        {
            InitializeComponent();
        }


        private void FrmFacSinRet_Load(object sender, EventArgs e)
        {
            DateTime lafecha = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dxlib.TipoBase = "10";
            strConxAdcom = dxlib.StrAdcom();

        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            //@compraVenta as varchar(10), @fechaini as date, @fechafin as date,@tipo as varchar(10)
            string formato = "###,###,##0.00";
            SqlConnection coneccion = new SqlConnection(strConxAdcom);
            coneccion.Open();
            string ssql = "select * from adcLstPenEntr ";//+ compras + "','" + txtFechaIni.Text + "','" + txtFechaFin.Text + "','facret'";
            SqlCommand cmd3 = new SqlCommand(ssql, coneccion);
            SqlDataAdapter DaRec2 = new SqlDataAdapter(cmd3);
            DataTable dt = new DataTable();
            DaRec2.Fill(dt);
            mallaGeneral.DataSource = dt;
            if (dt.Rows.Count == 0) return;
            mallaGeneral.Columns["Facturada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            mallaGeneral.Columns["Entregada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            mallaGeneral.Columns["Pendiente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            mallaGeneral.Columns["Excedente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            mallaGeneral.Columns["Pendiente"].DefaultCellStyle.Format  = formato;
            mallaGeneral.Columns["Facturada"].DefaultCellStyle.Format  = formato;
            mallaGeneral.Columns["Entregada"].DefaultCellStyle.Format = formato;
            mallaGeneral.Columns["Excedente"].DefaultCellStyle.Format = formato;

            mallaGeneral.Columns["Facturada"].Width =100;
            mallaGeneral.Columns["Entregada"].Width = 100;
            mallaGeneral.Columns["Pendiente"].Width = 100;
            mallaGeneral.Columns["Excedente"].Width = 100;

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
            tit2 = "Del: ";
            tit1 = "Analisis facturas y retenciones : ";
        }
        private void Quemalla()
        {
            if (tabControl1.SelectedIndex == 0) mallaDatos = mallaGeneral;
            if (tabControl1.SelectedIndex == 1) mallaDatos = mallaDesglose;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mallaDesglose.Columns.Clear();
            if (tabControl1.SelectedIndex == 1)
            {
                string cliente ="";
                string fecha = null;
                string articulo = "";
                string docsuc ="";
                string doctip ="";
                string docnum ="0";

                foreach (DataGridViewCell cell in mallaGeneral.SelectedCells)
                {
                    string name = mallaGeneral.Columns[cell.ColumnIndex].Name;
                    DataGridViewRow row = mallaGeneral.Rows[cell.RowIndex];

                    if (name == "Articulo" || name == "Descripción") articulo = row.Cells["Articulo"].Value.ToString();
                 //   if (articulo == "") return;

                    if (name == "Cliente" || name == "Nombre") cliente = row.Cells["Cliente"].Value.ToString();
                    if (name == "DOC" || name == "Numero")
                    {
                        docsuc =  row.Cells ["SUC"].Value.ToString();
                        doctip = row.Cells["DOC"].Value.ToString();
                        docnum = row.Cells["Numero"].Value.ToString();
                    }
                }

                string formato = "###,###,##0.00";

                SqlConnection coneccion = new SqlConnection(strConxAdcom);
                coneccion.Open();
                string ssql = "ADC_MOVENTREG '31/12/2000','" + cliente + "','" + articulo + "','" + docsuc + "','" + doctip + "'," + docnum;
                SqlCommand cmd3 = new SqlCommand(ssql, coneccion);
                SqlDataAdapter DaRec2 = new SqlDataAdapter(cmd3);
                DataTable dt = new DataTable();
                DaRec2.Fill(dt);
                mallaDesglose.DataSource = dt;
                if (dt.Rows.Count == 0) return;

                mallaDesglose.Columns["Facturada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                mallaDesglose.Columns["Entregada"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                mallaDesglose.Columns["Facturada"].DefaultCellStyle.Format = formato;
                mallaDesglose.Columns["Entregada"].DefaultCellStyle.Format = formato;

                mallaDesglose.Columns["Facturada"].Width = 100;
                mallaDesglose.Columns["Entregada"].Width = 100;
            }            
        }    

        private void btnSumar_MouseDown(object sender, MouseEventArgs e)
        {
            double sumaFacturado = 0;
            double sumaPendiente = 0;
            double sumaEntregado = 0;
            double sumaExcedente = 0;
            Int64 col = 0;
            if (tabControl1.SelectedIndex == 0)
            {
                col=mallaGeneral.SelectedCells [0].ColumnIndex ;
                foreach (DataGridViewCell cell in mallaGeneral.SelectedCells)
                {
                    if (cell.ColumnIndex == col)
                    {
                        DataGridViewRow row = mallaGeneral.Rows[cell.RowIndex];
                        sumaFacturado += Convert.ToDouble(row.Cells["Facturada"].Value);
                        sumaPendiente += Convert.ToDouble(row.Cells["Pendiente"].Value);
                        sumaEntregado += Convert.ToDouble(row.Cells["Entregada"].Value);
                        sumaExcedente += Convert.ToDouble(row.Cells["Excedente"].Value);
                    }
                }

                label1.Text = " Tot.Facturado: " + Convert.ToString(sumaFacturado);
                label1.Text += " Tot.Entregado: " + Convert.ToString(sumaEntregado);
                label1.Text += " Tot.Pendiente: " + Convert.ToString(sumaPendiente);
                label1.Text += " Tot.Excedente: " + Convert.ToString(sumaExcedente);
                label1.Visible = true;
            }
            else
            {
                col = mallaDesglose.SelectedCells[0].ColumnIndex;
                foreach (DataGridViewCell cell in mallaDesglose.SelectedCells)
                {
                    if (cell.ColumnIndex == col)
                    {
                        DataGridViewRow row = mallaDesglose.Rows[cell.RowIndex];
                        sumaFacturado += Convert.ToDouble(row.Cells["Facturada"].Value);
                        sumaEntregado += Convert.ToDouble(row.Cells["CantidadEntregada"].Value);
                    }
                }
                label1.Text = " Tot.Facturado: " + Convert.ToString(sumaFacturado);
                label1.Text += " Tot.Entregado: " + Convert.ToString(sumaEntregado);
                label1.Visible = true;
            }
        }

        private void btnSumar_MouseUp(object sender, MouseEventArgs e)
        {
            label1.Visible = false;
        }
    }
}
