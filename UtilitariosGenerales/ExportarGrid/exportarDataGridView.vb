Imports System.IO
Imports Microsoft.Office.Interop
Imports iTextSharp.text
Imports iTextSharp.text.pdf


Public Class exportarDataGridView

    Dim NombreArchivo As String = ""
    Private Function Exportar_Excel(ByVal MallaDatos As DataGridView, ByVal Empresa As String, ByVal titulo As String) As Boolean
        Dim i As Integer = 0
        Dim AplicacionExcel As Excel.Application
        Dim LibroTrabajoExcel As Excel.Workbook
        Dim HojaTrabajoExcel As Excel.Worksheet
        Dim Fila As Long
        Dim Columna As Integer
        AplicacionExcel = CreateObject("Excel.Application")
        LibroTrabajoExcel = AplicacionExcel.Workbooks.Add
        HojaTrabajoExcel = LibroTrabajoExcel.Worksheets.Add
        'o_Hoja.Visible = Excel.XlSheetVisibility.xlSheetVisible
        HojaTrabajoExcel.Activate()

        Dim objRangoDet As Excel.Range
        objRangoDet = HojaTrabajoExcel.Range(HojaTrabajoExcel.Cells(4, 1), HojaTrabajoExcel.Cells(MallaDatos.Rows.Count + 4, MallaDatos.ColumnCount + 2))
        'objRangoDet.NumberFormat = "@"
        'objRangoDet.Borders.LineStyle = Excel.XlBorderWeight.

        ' -- Bucle para Exportar los datos   
        With MallaDatos
            HojaTrabajoExcel.Cells(1, 1).Value = Empresa
            HojaTrabajoExcel.Cells(2, 1).Value = titulo
            AplicacionExcel.ErrorCheckingOptions.NumberAsText = False
            For Columna = 0 To .ColumnCount - 1
                formato(HojaTrabajoExcel, 3, Columna + 1, 3, Columna + 1, 1)
                HojaTrabajoExcel.Cells(3, Columna + 1).Value = .Columns(Columna).HeaderText
                For Fila = 0 To .RowCount - 1
                    Try
                        If .Columns(Columna).ValueType.ToString() = "System.String" Then
                            If IsNumeric(.Rows(Fila).Cells(Columna).Value) Then
                                HojaTrabajoExcel.Cells(Fila + 4, Columna + 1).Value = "'" + .Rows(Fila).Cells(Columna).Value.ToString()
                            ElseIf .Columns(Columna).ValueType.ToString() = "System.Date" Or .Columns(Columna).ValueType.ToString() = "System.DateTime" Then
                                HojaTrabajoExcel.Cells(Fila + 4, Columna + 1).Value = .Rows(Fila).Cells(Columna).FormattedValue()
                            Else
                                HojaTrabajoExcel.Cells(Fila + 4, Columna + 1).Value = .Rows(Fila).Cells(Columna).Value.ToString()
                            End If
                        Else
                            HojaTrabajoExcel.Cells(Fila + 4, Columna + 1).Value = .Rows(Fila).Cells(Columna).Value
                        End If
                    Catch
                    End Try
                Next
            Next
        End With
        HojaTrabajoExcel.Columns.AutoFit()
        Try
            LibroTrabajoExcel.SaveAs(NombreArchivo)
            MsgBox("Exportación a Excel correcta " & vbCr & "Su archivo a sido guardado como: " & NombreArchivo, MsgBoxStyle.Information)
        Catch
            MsgBox("Exportación a Excel no terminada " & vbCr & "Su archivo NO PUDO grabarse todavía ", MsgBoxStyle.Information)
        End Try       ' -- Terminar instancias   
        objRangoDet = HojaTrabajoExcel.Range(HojaTrabajoExcel.Cells(4, 1), HojaTrabajoExcel.Cells(MallaDatos.Rows.Count + 4, MallaDatos.ColumnCount))
        objRangoDet.BorderAround(1, Excel.XlBorderWeight.xlThin)
        objRangoDet = Nothing
        AplicacionExcel.Visible = True
        AplicacionExcel = Nothing
        LibroTrabajoExcel = Nothing
        HojaTrabajoExcel = Nothing
        Return True
    End Function
    Private Sub formato(ByVal o_hoja As Object, ByVal fila As Integer, ByVal columna As Integer, ByVal fila1 As Integer, ByVal columna1 As Integer, ByVal op As Integer)
        Dim objRangoDet As Excel.Range
        objRangoDet = o_hoja.Range(o_hoja.Cells(fila, columna), o_hoja.Cells(fila1, columna1))
        If op = 1 Then
            objRangoDet.BorderAround(1, Excel.XlBorderWeight.xlMedium)
        ElseIf op = 2 Then
            objRangoDet.BorderAround(1, Excel.XlBorderWeight.xlThin)
        End If
    End Sub
    Private Sub Exportar_Word(ByVal datos As DataGridView, ByVal Empresa As String, ByVal titulo As String)
        ''cambiar 'CAMIBIAR ON ERROR GoTo Error_Handler
        Dim dato As String = ""
        Dim o_Word As Word.Application
        Dim Documento As Word.Document
        Dim Parrafo As Word.Table

        Dim filas As Integer

        o_Word = CType(CreateObject("Word.Application"), Word.Application)
        filas = datos.RowCount
        Documento = o_Word.Documents.Add
        Parrafo = Documento.Tables.Add(Documento.Range(0, 0), filas + 2, datos.Columns.Count)
        For C = 0 To datos.Columns.Count - 1
            Parrafo.Cell(1, C + 1).Range.InsertAfter(datos.Columns(C).HeaderText)
            For F = 0 To datos.RowCount - 2
                dato = ""
                Try
                    dato = datos.Rows(F).Cells(C).Value.ToString
                    Parrafo.Cell(F + 2, C + 1).Range.InsertAfter(dato)
                Catch
                    dato = ""
                End Try
            Next F
        Next C
        Try
            Documento.SaveAs(NombreArchivo)
            MsgBox("Exportación a Word correcta " & vbCr & "Su archivo a sido guardado como: " & NombreArchivo, MsgBoxStyle.Information)
        Catch            'o_Libro.Close()
            MsgBox("Exportación a Word no terminada " & vbCr & "Su archivo NO PUDO grabarse todavía ", MsgBoxStyle.Information)
        End Try       ' -- Terminar instancias   
        o_Word.Visible = True
        o_Word = Nothing
        Documento = Nothing
        Parrafo = Nothing
    End Sub

    Private Sub Exportar_PDF(ByVal datos As DataGridView, ByVal emp As String, Optional tit1 As String = "", Optional tit2 As String = "")
        'Try
        'Intentar generar el documento.
        Dim malla As New DataGridView
        malla = datos
        Dim salida As Boolean = False
        Do While salida = False
            salida = True
            For Each columna As DataGridViewColumn In malla.Columns
                If columna.Visible = False Then malla.Columns.Remove(columna.Name) : salida = False : Exit For
            Next
        Loop
        Dim doc As New Document(PageSize.A4.Rotate(), 10, 10, 10, 10)
        'Path que guarda el reporte en el escritorio de windows (Desktop).
        Dim filename As String = NombreArchivo
        Dim file As New FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite)
        PdfWriter.GetInstance(doc, file)
        doc.Open()
        ExportarDatosPDF(doc, malla, emp, tit1, tit2)
        doc.Close()
        Process.Start(filename)
        ' Catch ex As Exception
        'Si el intento es fallido, mostrar MsgBox.
        'MessageBox.Show("No se puede generar el documento PDF.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ' End Try
    End Sub

    Private Sub ExportarDatosPDF(ByVal document As Document, ByVal datos As DataGridView, ByVal emp As String, tit1 As String, tit2 As String)

        Dim encabezado As New Paragraph(emp, New Font("Tahoma", 14, Font.BOLD))
        Dim texto As New Phrase(tit1, New Font("Tahoma", 12, Font.BOLD))
        Dim texto2 As New Phrase(tit2, New Font("Tahoma", 12, Font.BOLD))

        'Se crea un objeto PDFTable con el numero de columnas del DataGridView.  
        Dim datatable As New PdfPTable(datos.ColumnCount)
        'Se asignan algunas propiedades para el diseño del PDF.
        datatable.DefaultCell.Padding = 1
        Dim headerwidths As Single() = GetColumnasSize(datos)
        datatable.SetWidths(headerwidths)
        datatable.WidthPercentage = 100
        datatable.DefaultCell.BorderWidth = 2
        datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT
        'Se capturan los nombres de las columnas del DataGridView.

        For i As Integer = 0 To datos.ColumnCount - 1
            Try
                datatable.AddCell(preparaCelda(datos.Columns(i).HeaderText, 1))
            Catch
                datatable.AddCell("")
            End Try

        Next
        datatable.HeaderRows = 1
        datatable.DefaultCell.BorderWidth = 1

        'Se generan las columnas del DataGridView.  
        For i As Integer = 0 To datos.RowCount - 1
            For j As Integer = 0 To datos.ColumnCount - 1
                Try
                    datatable.AddCell(preparaCelda(datos(j, i).EditedFormattedValue, datos.Columns(j).DefaultCellStyle.Alignment, datos(j, i)))
                    '                    datatable.AddCell(preparaCelda(datos(j, i).EditedFormattedValue, datos.Columns(j).DefaultCellStyle.Alignment))
                Catch
                    datatable.AddCell("")
                End Try
            Next
            'datatable.DefaultCell.Width = Len((datos(j, i).Value))
            datatable.CompleteRow()
        Next
        'Se agrega el PDFTable al documento. 
        document.Add(encabezado)
        document.Add(texto)
        If tit2.Length > 0 Then document.Add(texto2)
        document.Add(datatable)
    End Sub
    Private Function preparaCelda(texto As String, Optional alinear As Int16 = 0, Optional celdaView As DataGridViewCell = Nothing) As pdf.PdfPCell
        Dim parrafo As New Paragraph
        parrafo.Font = New Font(FontFactory.GetFont("Arial", 9))
        If alinear = 0 Then
            parrafo.Alignment = Element.ALIGN_LEFT
        ElseIf alinear = 1 Then
            parrafo.Alignment = Element.ALIGN_CENTER
        Else
            parrafo.Alignment = Element.ALIGN_RIGHT
        End If
        parrafo.Add(texto)
        Dim cell2 As New PdfPCell()
        'cell2.Border = Rectangle.NO_BORDER
        'cell2.PaddingTop = -7
        cell2.AddElement(parrafo)
        'cell2.Colspan = 3
        If Not IsNothing(celdaView) Then
            If celdaView.Style.BackColor.R <> 0 Then cell2.BackgroundColor = New iTextSharp.text.BaseColor(celdaView.Style.BackColor.R, celdaView.Style.BackColor.G, celdaView.Style.BackColor.B)
        End If

        Return cell2

    End Function
    Private Function GetColumnasSize(ByVal dg As DataGridView) As Single()
        Dim values As Single() = New Single(dg.ColumnCount - 1) {}
        For i As Integer = 0 To dg.ColumnCount - 1
            values(i) = CSng(dg.Columns(i).Width)
        Next
        Return values
    End Function
    ' grid es el malla que va ha ser exportada 
    'opcion: E ---> Excel
    '        W ---> Word
    '        P ---> PDF
    Public Function Exportar(ByVal grid As DataGridView, ByVal opcion As String, ByVal emp As String, ByVal tit As String) As String
        Dim Extencion As String = ""
        Dim SaveFileDialog1 As SaveFileDialog = New SaveFileDialog()

        Select Case opcion
            Case "E"
                Extencion = "Archivos tipo excel (*.xls)|*.xls"
            Case "W"
                Extencion = "Archivos tipo word (*.doc)|*.doc"
            Case "P"
                Extencion = "Archivos tipo pdf (*.pdf)|*.pdf"
            Case "C"
                Extencion = "Archivos tipo pdf (*.pdf)|*.CSV"
        End Select
        With SaveFileDialog1
            .OverwritePrompt = True
            .Title = "Registrar nombre de archivo para exportar información"
            .InitialDirectory = "\tmp"
            .Filter = Extencion

            If (.ShowDialog() = DialogResult.OK) Then
                NombreArchivo = .FileName
            Else
                NombreArchivo = ""
            End If
        End With
        If Len(Trim(NombreArchivo)) = 0 Then Return ""
        Select Case opcion
            Case "E"
                Exportar_Excel(grid, emp, tit)
            Case "W"
                Exportar_Word(grid, emp, tit)
            Case "P"
                Exportar_PDF(grid, emp, tit)
        End Select
        Return NombreArchivo
    End Function

End Class
