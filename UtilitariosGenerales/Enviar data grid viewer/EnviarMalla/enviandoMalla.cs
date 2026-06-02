using System;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SalidasDeMalla
{
    public partial class enviandoMalla : Form
    {
        DataGridViewPrinter MyDataGridViewPrinter;
        DataGridView datos;
        string LaEmpresa = "";
        string ElTitulo1 = "";
        string ElTitulo2 = "";
        

        public enviandoMalla(DataGridView malla,  string Titulo, string Empresa)
        {
            InitializeComponent();
            datos = malla;
            LaEmpresa = Empresa;
            ElTitulo1 = Titulo;
        }

        private void btnImprime_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting(datos))
            {
                Text = "IMPRIMIENDO DATOS";
                MyPrintDocument.Print();
                Text = "";
                Close();
                Dispose();
            }
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {          
            string NombreArchivo = archivoGrabar("XLS");
            if (NombreArchivo != "")
            {
                WaitMensaje.WMensaje.verMensaje("Exportando datos a Excell");
                Cursor = Cursors.WaitCursor;
            //    Text = "EXPORTANDO A EXCEL";
                ExportarExcel exp = new ExportarExcel();
                if (exp.Exportar_Excel(datos, LaEmpresa, ElTitulo1, NombreArchivo) == true)
                {
                    Close(); Dispose(); 
                }
                exp = null;
                WaitMensaje.WMensaje.cierraMensaje();
            }
            Text = "";
            Cursor = Cursors.Default;
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            //Text = "EXPORTANDO A WORD";
            //using (ExportarGrid.Form1 exp = new ExportarGrid.Form1())
            //{
            //    if (exp.Exportar(datos, "W", LaEmpresa, ElTitulo1).Length > 0) Close(); Dispose(); Text = "";
            //}
            //Text = "";
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {

            //Text = "";
            //string NombreArchivo = archivoGrabar("PDF");
            //if (NombreArchivo != "")
            //{
            //    Cursor = Cursors.WaitCursor;
            //    Text = "EXPORTANDO A PDF";
            //    ExportarPdf exp = new ExportarPdf();
            //    //if (exp.Exportar_PDF(datos, "P", LaEmpresa, ElTitulo1, archivoGrabar).Length > 0) Close(); Dispose(); Text = "";
            //    if (exp.Exportar_PDF(datos, LaEmpresa, ElTitulo1,"", NombreArchivo) == true)
            //    {
            //        Close(); Dispose();
            //    }
            //    exp = null;
            //}
            //Text = "";
            //Cursor = Cursors.Default;
        }
        //private string ArchivoDestino(string tipo)
        //{
        //    string filename = "";
        //    sfd.Filter = tipo + " (*." + tipo + ")|*." + tipo;
        //    sfd.FileName = "Output." + tipo;
        //    if (sfd.ShowDialog() == DialogResult.OK)
        //    {
        //        filename = sfd.FileName;
        //        if (File.Exists(filename))
        //        {
        //            try
        //            {
        //                File.Delete(filename);
        //            }
        //            catch (IOException ex)
        //            {
        //                MessageBox.Show("No es posible guardar los datos en el archivo especificado " + ex.Message);
        //                filename = "";
        //            }
        //        }
        //    }
        //    return filename;
        //}
        private string archivoGrabar(string opcion)
        {

            try
            {
                opcion = opcion.Substring(0, 1);
            }catch { }

            string filename = "";
            string Extencion = "Archivos tipo excel(*.xls) | *.xls";
            if (opcion == "W") Extencion = "Archivos tipo word (*.doc)|*.doc";
            if (opcion == "P") Extencion = "Archivos tipo pdf (*.pdf)|*.pdf";
            if (opcion == "C") Extencion = "Archivos tipo pdf (*.pdf)|*.CSV";

            //SaveFileDialog sfd = new SaveFileDialog();
            sfd.OverwritePrompt = true;
            sfd.Title = "Registrar nombre de archivo para exportar información";
            sfd.InitialDirectory = "\tmp";
            sfd.Filter = Extencion;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                filename = sfd.FileName;
                if (File.Exists(filename))
                {
                    try
                    {
                        File.Delete(filename);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("No es posible guardar los datos en el archivo especificado " + ex.Message);
                        filename = "";
                    }
                }
            }
            else { filename = ""; }
            return filename;
        }

        private bool SetupThePrinting(DataGridView MyDataGridView)
        {
            PrintDialog MyPrintDialog = new PrintDialog();
            string Encabezado = LaEmpresa;
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;
            if (MyPrintDialog.ShowDialog() != DialogResult.OK) return false;
            MyPrintDocument.DocumentName = "Report";
            MyPrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            MyPrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            MyPrintDocument.DefaultPageSettings.Margins.Bottom = 40;
            MyPrintDocument.DefaultPageSettings.Margins.Right = 40;
            MyPrintDocument.DefaultPageSettings.Margins.Left = 40;
            MyPrintDocument.DefaultPageSettings.Margins.Top = 40;

            MyDataGridViewPrinter = new DataGridViewPrinter(MyDataGridView, MyPrintDocument, false, true, Encabezado, ElTitulo1, ElTitulo2, new Font("Tahoma", 10, FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);
            return true;
    }
        private void MyPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more) e.HasMorePages = true; 
        }

       private void btnCsv_Click_1(object sender, EventArgs e)
        {
            ExportarCsv exp = new ExportarCsv();
            string separador = ",";
            bool conTitulos = false;
            if (chkEncabezado.Checked) conTitulos = true;
            if (chkPuntoComa.Checked) separador = ";";
            if (chkTab.Checked) separador = "\t";
            //Text = "EXPORTANDO A CSV";
            if (exp.SaveToCSV(datos, separador,conTitulos,sfd)) Close(); Dispose(); 
            exp = null;
            Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
