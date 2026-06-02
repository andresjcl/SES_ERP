using System.Windows.Forms;
using System;
using Microsoft.Office.Interop.Excel;
namespace SalidasDeMalla
{
    internal class ExportarExcel
    {
        internal bool Exportar_Excel(DataGridView MallaDatos, string Empresa, string titulo, string NombreArchivo)
        {
            int i = 0;
            //    Microsoft.Office.Interop.Excel.Application AplicacionExcel = new Microsoft.Office.Interop.Excel.Application();
            //    Microsoft.Office.Interop.Excel.Workbook LibroTrabajoExcel;//= new Microsoft.Office.Interop.Excel.Workbook();
            //    Microsoft.Office.Interop.Excel.Worksheet HojaTrabajoExcel;// = new Microsoft.Office.Interop.Excel.Worksheet();
            //    LibroTrabajoExcel = AplicacionExcel.Workbooks.Add();
            //    HojaTrabajoExcel = LibroTrabajoExcel.Worksheets.Add();
            //    HojaTrabajoExcel.Activate();
            Microsoft.Office.Interop.Excel.Application AplicacionExcel = new Microsoft.Office.Interop.Excel.Application();
            Workbook LibroTrabajoExcel;
            Worksheet HojaTrabajoExcel;
            long Fila;
            int Columna;
            //AplicacionExcel = (Microsoft.Office.Interop.Excel.Application)Interaction.CreateObject("Excel.Application");
            LibroTrabajoExcel = AplicacionExcel.Workbooks.Add();
            HojaTrabajoExcel = (Worksheet)LibroTrabajoExcel.Worksheets.Add();
            // o_Hoja.Visible = Excel.XlSheetVisibility.xlSheetVisible
            HojaTrabajoExcel.Activate();
            Range objRangoDet;
            objRangoDet = HojaTrabajoExcel.Range[HojaTrabajoExcel.Cells[(object)4, (object)1], HojaTrabajoExcel.Cells[(object)(MallaDatos.Rows.Count + 4), (object)MallaDatos.ColumnCount]];
            //objRangoDet = HojaTrabajoExcel.Range[HojaTrabajoExcel.Cells[(object)4, (object)1], HojaTrabajoExcel.Cells[(object)(MallaDatos.Rows.Count + 4), (object)(MallaDatos.ColumnCount + 2)]];
            // objRangoDet.NumberFormat = "@"
            // objRangoDet.Borders.LineStyle = Excel.XlBorderWeight.

            // -- Bucle para Exportar los datos   
            HojaTrabajoExcel.Cells[(object)1, (object)1].Value = Empresa;
            HojaTrabajoExcel.Cells[(object)2, (object)1].Value = titulo;
            AplicacionExcel.ErrorCheckingOptions.NumberAsText = false;
            var loopTo = MallaDatos.ColumnCount - 1;
            for (Columna = 0; Columna <= loopTo; Columna++)
            {
                formato(HojaTrabajoExcel, 3, Columna + 1, 3, Columna + 1, 1);
                HojaTrabajoExcel.Cells[(object)3, (object)(Columna + 1)].Value = MallaDatos.Columns[Columna].HeaderText;
                var loopTo1 = (long)(MallaDatos.RowCount - 1);
                for (Fila = 0L; Fila <= loopTo1; Fila++)
                {
                    try
                    {
                        if (MallaDatos.Columns[Columna].ValueType.ToString() == "System.String")
                        {
                            if (IsNumeric(MallaDatos.Rows[(int)Fila].Cells[Columna].Value))
                            {
                                HojaTrabajoExcel.Cells[(object)(Fila + 4L), (object)(Columna + 1)].Value = "'" + MallaDatos.Rows[(int)Fila].Cells[Columna].Value.ToString();
                            }
                            else if (MallaDatos.Columns[Columna].ValueType.ToString() == "System.Date" | MallaDatos.Columns[Columna].ValueType.ToString() == "System.DateTime")
                            {
                                HojaTrabajoExcel.Cells[(object)(Fila + 4L), (object)(Columna + 1)].Value = MallaDatos.Rows[(int)Fila].Cells[Columna].FormattedValue;
                            }
                            else
                            {
                                HojaTrabajoExcel.Cells[(object)(Fila + 4L), (object)(Columna + 1)].Value = MallaDatos.Rows[(int)Fila].Cells[Columna].Value.ToString();
                            }
                        }
                        else
                        {
                            HojaTrabajoExcel.Cells[(object)(Fila + 4L), (object)(Columna + 1)].Value = MallaDatos.Rows[(int)Fila].Cells[Columna].Value;
                        }
                    }
                    catch
                    {
                    }
                }
            }

            HojaTrabajoExcel.Columns.AutoFit();
            try
            {
                LibroTrabajoExcel.SaveAs(NombreArchivo);
                MessageBox.Show("Exportación a Excel correcta \nSu archivo a sido guardado como: " + NombreArchivo);
            }
            catch
            {
                MessageBox.Show("Exportación a Excel no terminada \nSu archivo NO PUDO grabarse todavía ");
            }       // -- Terminar instancias   
            
            objRangoDet = HojaTrabajoExcel.Range[HojaTrabajoExcel.Cells[(object)4, (object)1], HojaTrabajoExcel.Cells[(object)(MallaDatos.Rows.Count + 4), (object)MallaDatos.ColumnCount]];
            objRangoDet.BorderAround((object)1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin);
            objRangoDet = null;
            AplicacionExcel.Visible = true;
            AplicacionExcel = null;
            LibroTrabajoExcel = null;
            HojaTrabajoExcel = null;
            return true;
        }

        //internal bool Exportar_Excel(DataGridView MallaDatos, string Empresa, string titulo, string NombreArchivo)
        //{
        //    bool resp = false;
        //    Microsoft.Office.Interop.Excel.Application AplicacionExcel = new Microsoft.Office.Interop.Excel.Application();
        //    Microsoft.Office.Interop.Excel.Workbook LibroTrabajoExcel;//= new Microsoft.Office.Interop.Excel.Workbook();
        //    Microsoft.Office.Interop.Excel.Worksheet HojaTrabajoExcel;// = new Microsoft.Office.Interop.Excel.Worksheet();
        //    LibroTrabajoExcel = AplicacionExcel.Workbooks.Add();
        //    HojaTrabajoExcel = LibroTrabajoExcel.Worksheets.Add();
        //    HojaTrabajoExcel.Activate();

        //    Microsoft.Office.Interop.Excel.Range objRangoDet;
        //    objRangoDet = HojaTrabajoExcel.Range[HojaTrabajoExcel.Cells[4, 1], HojaTrabajoExcel.Cells[MallaDatos.Rows.Count + 4, MallaDatos.ColumnCount + 2]];
        //    //objRangoDet.NumberFormat = "@"
        //    //objRangoDet.Borders.LineStyle = Excel.XlBorderWeight.

        //    HojaTrabajoExcel.Cells[1, 1].Value = Empresa;
        //    HojaTrabajoExcel.Cells[2, 1].Value = titulo;
        //    AplicacionExcel.ErrorCheckingOptions.NumberAsText = false;
        //    Int32 indCol = 0;
        //    Int32 indFil = 0;
        //    for (Int32 Columna = 0; Columna < MallaDatos.ColumnCount; Columna++)
        //    {
        //        indCol = Columna + 1;
        //        formato(HojaTrabajoExcel, 3, Columna + 1, 3, Columna + 1, 1);
        //        HojaTrabajoExcel.Cells[3, Columna + 1].Value = MallaDatos.Columns[Columna].HeaderText;
        //        for (Int32 Fila = 0; Fila < MallaDatos.RowCount; Fila++)
        //        {
        //        indFil = Fila + 4;
        //            try
        //            {
        //                if (MallaDatos.Rows[Fila].Cells[Columna].Value != null)
        //                {
        //                    if (MallaDatos.Columns[Columna].ValueType.ToString() == "System.String")
        //                    {
        //                        if (IsNumeric(MallaDatos.Rows[Fila].Cells[Columna].Value))
        //                        {
        //                            HojaTrabajoExcel.Cells[indFil , indCol].Value = "'" + MallaDatos.Rows[Fila].Cells[Columna].Value.ToString();
        //                        }
        //                        else if (MallaDatos.Columns[Columna].ValueType.ToString() == "System.Date" || MallaDatos.Columns[Columna].ValueType.ToString() == "System.DateTime")
        //                        {
        //                            HojaTrabajoExcel.Cells[indFil, indCol].Value = MallaDatos.Rows[Fila].Cells[Columna].FormattedValue;
        //                        }
        //                        else
        //                        {
        //                            HojaTrabajoExcel.Cells[indFil, indCol].Value = MallaDatos.Rows[Fila].Cells[Columna].Value.ToString();
        //                        }
        //                    }
        //                    else
        //                    {
        //                        HojaTrabajoExcel.Cells[indFil, indCol].Value = MallaDatos.Rows[Fila].Cells[Columna].Value;
        //                    }
        //                }

        //            }
        //            catch { }
        //        }
        //    }

        //    HojaTrabajoExcel.Columns.AutoFit();
        //    objRangoDet = HojaTrabajoExcel.Range[HojaTrabajoExcel.Cells[4, 1], HojaTrabajoExcel.Cells[MallaDatos.Rows.Count + 4, MallaDatos.ColumnCount]];
        //    objRangoDet.BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin);
        //    objRangoDet = null;
        //    try
        //    {
        //        LibroTrabajoExcel.SaveAs(NombreArchivo);
        //        MessageBox.Show("Exportación a Excel correcta \n Su archivo a sido guardado como: " + NombreArchivo, "Exportacion datos a Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        resp = true;
        //    }
        //    catch
        //    {
        //        MessageBox.Show ("Exportación a Excel no terminada \n Su archivo NO PUDO grabarse todavía ","Exportación datos a Excel" ,MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }

        //    AplicacionExcel.Visible = true;
        //    AplicacionExcel = null;
        //    LibroTrabajoExcel = null;
        //    HojaTrabajoExcel = null;
        //    return resp;
        //}
        public static System.Boolean IsNumeric(System.Object Expression)
        {
            if (Expression == null || Expression is DateTime)
                return false;

            if (Expression is Int16 || Expression is Int32 || Expression is Int64 || Expression is Decimal || Expression is Single || Expression is Double || Expression is Boolean)
                return true;

            try
            {
                if (Expression is string)
                    Double.Parse(Expression as string);
                else
                    Double.Parse(Expression.ToString());
                return true;
            }
            catch { } // just dismiss errors but return false
            return false;
        }

        private void formato(Microsoft.Office.Interop.Excel.Worksheet o_hoja, long fila, int columna, long fila1, int columna1, int op)
        {
            Microsoft.Office.Interop.Excel.Range objRangoDet;
            objRangoDet = o_hoja.Range[o_hoja.Cells[fila, columna], o_hoja.Cells[fila1, columna1]];
            if (op == 1) objRangoDet.BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium);
            if (op == 2) objRangoDet.BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin);
        }
    }
}
