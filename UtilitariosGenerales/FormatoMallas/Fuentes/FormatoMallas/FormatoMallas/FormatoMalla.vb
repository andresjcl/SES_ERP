Public Class FormatoMalla
    Public Function ConfigurarMalla(ByRef Malla1 As Object, ByVal claseMalla As String)
        Dim Malla As New DataGridView
        Malla = Malla1
        Dim contador = 0, contador1 As Integer = 0
        For col = 0 To Malla.ColumnCount - 1 Step 1
            For fila = 0 To Malla.RowCount - 1 Step 1
                If IsNumeric(Malla.Rows(fila).Cells(col).Value) Then
                    contador += 1
                Else
                    contador1 += 1
                End If
            Next
            If contador > contador1 Then
                If Malla.Columns(col).DefaultCellStyle.Format <> "N2" Then Malla.Columns(col).DefaultCellStyle.Format = "N2" : Malla.Columns(col).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Else
                Malla.Columns(col).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            End If
            contador = 0
            contador1 = 0
            Malla.Columns(col).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Next
        Select Case (claseMalla)
            Case "Consulta"
                Malla.ColumnHeadersDefaultCellStyle.BackColor = Color.BurlyWood
                Malla.RowHeadersDefaultCellStyle.BackColor = Color.BurlyWood
                Malla.GridColor = Color.AntiqueWhite
                Malla.DefaultCellStyle.ForeColor = Color.Black
                Malla.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
            Case "Busqueda"
                Malla.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkKhaki
                Malla.RowHeadersDefaultCellStyle.BackColor = Color.DarkKhaki
                Malla.GridColor = Color.Khaki
                Malla.DefaultCellStyle.ForeColor = Color.Black
                Malla.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
            Case "IngresoDatos"
                Malla.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue
                Malla.RowHeadersDefaultCellStyle.BackColor = Color.RoyalBlue
                Malla.GridColor = Color.Lavender
                Malla.DefaultCellStyle.ForeColor = Color.Blue
                Malla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        End Select

        Return Malla
    End Function
End Class
