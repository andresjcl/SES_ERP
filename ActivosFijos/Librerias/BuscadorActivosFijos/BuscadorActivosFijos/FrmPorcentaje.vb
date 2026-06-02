Public Class FrmPorcentaje
    Dim porTodos = 0,valor As Double = 0
    Dim tipo As String = ""
    Dim cancelar As Integer = 0
    Dim respuesta(3) As String
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        cancelar = 1
        respuesta(0) = cancelar
        Me.Dispose()
    End Sub

    Private Sub txtPorcTodos_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPorcTodos.KeyPress
        If InStr(1, "0123456789.," & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub


    Private Sub txtPorcTodos_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPorcTodos.TextChanged
        If txtPorcTodos.Text <> "" Then
            If CInt(txtPorcTodos.Text) < 0 Or CInt(txtPorcTodos.Text) > 100 Then
                MsgBox("El Porcentaje debe ser mayor a 0 y menor a 100!!", MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim confirmar As Integer
        respuesta(0) = cancelar
        If tipo = "PORC" Then
            If txtPorcTodos.Text <> "" Then
                porTodos = txtPorcTodos.Text
            Else
                porTodos = 0
            End If
            If porTodos = 0 Then
                confirmar = MessageBox.Show("Esta seguro que desae ingresar 0 % ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                If confirmar = vbYes Then
                    Me.Dispose()
                Else
                    txtPorcTodos.Focus()
                    Exit Sub
                End If
            Else
                respuesta(1) = 0
                respuesta(2) = porTodos
                Me.Dispose()
            End If
        ElseIf tipo = "VALOR" Then
            If txtValor.Text <> "" Then
                valor = txtValor.Text
            Else
                valor = 0
            End If
            If valor = 0 Then
                confirmar = MessageBox.Show("Esta seguro que quiere ingresar el valor 0 ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                If confirmar = vbYes Then
                    Me.Dispose()
                Else
                    txtValor.Focus()
                    Exit Sub
                End If
            Else
                respuesta(1) = 1
                respuesta(2) = valor
                Me.Dispose()
            End If
        End If
    End Sub

    Private Sub FrmPorcentaje_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtPorcTodos.Focus()
        txtPorcTodos.SelectionStart = 0
    End Sub

    Private Sub optPorcentaje_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPorcentaje.CheckedChanged
        If optPorcentaje.Checked = True Then
            txtPorcTodos.Enabled = True
            txtValor.Enabled = False
            txtValor.Text = ""
            tipo = "PORC"
        Else
            txtPorcTodos.Enabled = False
            txtValor.Enabled = True
            txtPorcTodos.Text = ""
        End If
    End Sub

    Private Sub optValor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optValor.CheckedChanged
        If optValor.Checked = True Then
            txtPorcTodos.Enabled = False
            txtValor.Enabled = True
            txtPorcTodos.Text = ""
            tipo = "VALOR"
            txtValor.Focus()
        Else
            txtPorcTodos.Enabled = True
            txtValor.Enabled = False
            txtValor.Text = ""
        End If
    End Sub
    Public Function Abrir() As String()
        Me.ShowDialog()
        Return respuesta
    End Function
    Private Sub txtValor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtValor.KeyPress
        If InStr(1, "0123456789.," & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub
End Class