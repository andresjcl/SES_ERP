Public Class CtbVal
    Private Sub imprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imprimir.Click
        Dim imp As New DataGridViewPrinterApplication1.frmMain
        imp.imprimir(Malla, "Errores en configuración del plan de cuentas contables " + Format(Date.Now, "dd/MMM/yyyy"), , Emp.nombre)
        imp.Dispose()
    End Sub
End Class