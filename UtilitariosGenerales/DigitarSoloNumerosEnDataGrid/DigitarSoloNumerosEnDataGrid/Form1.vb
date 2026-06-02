Public Class EditarMallas

    Private Sub Malla_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles Malla.EditingControlShowing
        Dim ValidarNro As TextBox = e.Control
        RemoveHandler ValidarNro.KeyPress, AddressOf ValidaNro_KeyPress
        AddHandler ValidarNro.KeyPress, AddressOf ValidaNro_KeyPress
    End Sub

    Private Sub ValidaNro_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' debe definirse un formato, en definir stilo de las columnas, SOLO para las columnas que deban aceptar números
        Dim FormatoColumna As String = Malla.Columns(Malla.CurrentCell.ColumnIndex).DefaultCellStyle.Format.ToString
        If FormatoColumna = "" Then Exit Sub

        Select Case e.KeyChar
            Case "0" To "9", vbBack
                e.Handled = False
            Case "."
                If FormatoColumna.Contains(".") Or Val(Mid(FormatoColumna, 2, 1)) > 0 Then
                    e.Handled = CType(sender, TextBox).Text.Contains(".")   ' verifica si ya tiene un punto decimal
                Else
                    e.Handled = True
                End If
            Case Else
                e.Handled = True
        End Select
    End Sub
End Class
