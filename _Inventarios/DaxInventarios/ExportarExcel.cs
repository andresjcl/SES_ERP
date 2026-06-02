using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DaxInvent
{
    internal class ExportarExcel
    {
        internal bool Exportar_Excel(DataGridView MallaDatos, string Empresa, string titulo, string NombreArchivo)
        {
            int i = 0;
            Microsoft.Office.Interop.Excel.Application AplicacionExcel = new Microsoft.Office.Interop.Excel.Application();
            Workbook LibroTrabajoExcel;
            Worksheet HojaTrabajoExcel;
            long Fila;
            int Columna;
            LibroTrabajoExcel = AplicacionExcel.Workbooks.Add();
            HojaTrabajoExcel = (Worksheet)LibroTrabajoExcel.Worksheets.Add();
            HojaTrabajoExcel.Activate();
            Range objRangoDet;
            objRangoDet = HojaTrabajoExcel.Range[HojaTrabajoExcel.Cells[(object)4, (object)1], HojaTrabajoExcel.Cells[(object)(MallaDatos.Rows.Count + 4), (object)MallaDatos.ColumnCount]];


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
