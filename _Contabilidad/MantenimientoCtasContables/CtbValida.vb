Public Class CtbValida
    Private Sub imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        Dim imp As New DataGridViewPrinterApplication1.frmMain
        imp.imprimir(Malla, "Errores en configuración del plan de cuentas contables " + Format(Date.Now, "dd/MMM/yyyy"), , DattCom.datosEmpresa.Emp_Nombre)
        imp.Dispose()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class