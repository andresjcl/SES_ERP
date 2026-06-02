using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SalidasDeMalla
{
    class ExportarPdf
    {

        internal bool Exportar_PDF(DataGridView datos, string emp, string tit1, string tit2,string NombreArchivo)
        {
            DataGridView malla = new DataGridView();
            malla = datos;
            bool resp = true;
            bool salida = false;
            while ((salida == false))
            {
                salida = true;
                foreach (DataGridViewColumn columna in malla.Columns)
                {
                    if ((columna.Visible == false))
                    {
                        malla.Columns.Remove(columna.Name);
                    }

                    salida = false;
                    break;
                }
            }

            Document doc = new Document(PageSize.A4.Rotate(), 10, 10, 10, 10);
            // Path que guarda el reporte en el escritorio de windows (Desktop).
            string filename = NombreArchivo;
            FileStream file = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            PdfWriter.GetInstance(doc, file);
            doc.Open();
            ExportarDatosPDF(doc, malla, emp, tit1, tit2);
            doc.Close();
            System.Diagnostics.Process.Start(filename);
            //  Catch ex As Exception
            // Si el intento es fallido, mostrar MsgBox.
            // MessageBox.Show("No se puede generar el documento PDF.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            //  End Try
            return resp;
        }

        private void ExportarDatosPDF(Document document, DataGridView datos, string emp, string tit1, string tit2, string NombreArchivo = ""
)
        {
            Paragraph encabezado = new Paragraph(emp, new Font(Font.FontFamily.COURIER, 14, Font.BOLD));
            Phrase texto = new Phrase(tit1, new Font(Font.FontFamily.COURIER, 12, Font.BOLD));
            Phrase texto2 = new Phrase(tit2, new Font(Font.FontFamily.COURIER, 12, Font.BOLD));
            // Se crea un objeto PDFTable con el numero de columnas del DataGridView.  
            PdfPTable datatable = new PdfPTable(datos.ColumnCount);
            // Se asignan algunas propiedades para el dise�o del PDF.
            datatable.DefaultCell.Padding = 1;
            float[] headerwidths = GetColumnasSize(datos);
            datatable.SetWidths(headerwidths);
            datatable.WidthPercentage = 100;
            datatable.DefaultCell.BorderWidth = 2;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            // Se capturan los nombres de las columnas del DataGridView.
            for (int i = 0; (i <= (datos.ColumnCount - 1)); i++)
            {
                try
                {
                    datatable.AddCell(preparaCelda(datos.Columns[i].HeaderText, 1));
                }
                catch { datatable.AddCell(""); }
            }

            datatable.HeaderRows = 1;
            datatable.DefaultCell.BorderWidth = 1;
            // Se generan las columnas del DataGridView.  
            for (int i = 0; (i <= (datos.RowCount - 1)); i++)
            {
                for (int j = 0; (j
                            <= (datos.ColumnCount - 1)); j++)
                {
                    try
                    {
                        datatable.AddCell(preparaCelda(datos[j, i].EditedFormattedValue.ToString(),Convert.ToInt16( datos.Columns[j].DefaultCellStyle.Alignment), datos[j, i]));
                        //                     datatable.AddCell(preparaCelda(datos(j, i).EditedFormattedValue, datos.Columns(j).DefaultCellStyle.Alignment))
                    }
                    catch { datatable.AddCell(""); }
                }
                // datatable.DefaultCell.Width = Len((datos(j, i).Value))
                datatable.CompleteRow();
            }
               // Se agrega el PDFTable al documento. 
                document.Add(encabezado);
                document.Add(texto);
                if ((tit2.Length > 0)) {document.Add(texto2);                }         
                document.Add(datatable);            
        }
     
         private  PdfPCell preparaCelda(string texto, Int16 alinear=0, DataGridViewCell celdaView=null)
        {
            Paragraph parrafo = new Paragraph();
            parrafo.Font = new Font(FontFactory.GetFont("Arial", 9));
            if ((alinear == 0))
            {
                parrafo.Alignment = Element.ALIGN_LEFT;
            }
            else if ((alinear == 1))
            {
                parrafo.Alignment = Element.ALIGN_CENTER;
            }
            else
            {
                parrafo.Alignment = Element.ALIGN_RIGHT;
            }

            parrafo.Add(texto);
            PdfPCell cell2 = new PdfPCell();
            // cell2.Border = Rectangle.NO_BORDER
            // cell2.PaddingTop = -7
            cell2.AddElement(parrafo);
            // cell2.Colspan = 3
            if (!(celdaView == null))
            {
                if ((celdaView.Style.BackColor.R != 0))
                {
                    cell2.BackgroundColor = new iTextSharp.text.BaseColor(celdaView.Style.BackColor.R, celdaView.Style.BackColor.G, celdaView.Style.BackColor.B);
                }
            }
            return cell2;
        }

        private float[] GetColumnasSize(DataGridView dg)
        {
            float[] values = new float[] {
                         (dg.ColumnCount - 1)};
            for (int i = 0; (i
                        <= (dg.ColumnCount - 1)); i++)
            {
                values[i] = (dg.Columns[i].Width);
            }
            return values;
        }
    }


}
