
private bool Exportar_Excel(DataGridView MallaDatos, string Empresa, string titulo)
{
    int i = 0;
    Microsoft.Office.Interop.Excel.Application AplicacionExcel;
    Microsoft.Office.Interop.Excel.Workbook LibroTrabajoExcel;
    Microsoft.Office.Interop.Excel.Worksheet HojaTrabajoExcel;
    long Fila;
    int Columna;
    AplicacionExcel = (Microsoft.Office.Interop.Excel.Application)Interaction.CreateObject("Excel.Application");
    LibroTrabajoExcel = AplicacionExcel.Workbooks.Add();
    HojaTrabajoExcel = (Microsoft.Office.Interop.Excel.Worksheet)LibroTrabajoExcel.Worksheets.Add();
    // o_Hoja.Visible = Excel.XlSheetVisibility.xlSheetVisible
    HojaTrabajoExcel.Activate();
    Microsoft.Office.Interop.Excel.Range objRangoDet;
    objRangoDet = HojaTrabajoExcel.get_Range(HojaTrabajoExcel.Cells[(object)4, (object)1], HojaTrabajoExcel.Cells[(object)(MallaDatos.Rows.Count + 4), (object)(MallaDatos.ColumnCount + 2)]);
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
                    if (Information.IsNumeric(MallaDatos.Rows[(int)Fila].Cells[Columna].Value))
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
        Interaction.MsgBox("Exportación a Excel correcta " + Constants.vbCr + "Su archivo a sido guardado como: " + NombreArchivo, MsgBoxStyle.Information);
    }
    catch
    {
        Interaction.MsgBox("Exportación a Excel no terminada " + Constants.vbCr + "Su archivo NO PUDO grabarse todavía ", MsgBoxStyle.Information);
    }       // -- Terminar instancias   

    objRangoDet = HojaTrabajoExcel.get_Range(HojaTrabajoExcel.Cells[(object)4, (object)1], HojaTrabajoExcel.Cells[(object)(MallaDatos.Rows.Count + 4), (object)MallaDatos.ColumnCount]);
    objRangoDet.BorderAround((object)1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin);
    objRangoDet = null;
    AplicacionExcel.Visible = true;
    AplicacionExcel = null;
    LibroTrabajoExcel = null;
    HojaTrabajoExcel = null;
    return true;
}
