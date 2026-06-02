Public Class MvtoCtas
    Public Sub MvCtas(ByVal Cta As String, ByVal Fec1 As Date, ByVal fec2 As Date, ByVal ConStr As String)
        Dim prog As New frmMovCta
        CodigoEntrada = Cta
        fechaFin = fec2
        fechaIni = Fec1
        If Cta > "" Then prog.ShowDialog() : prog.Dispose() Else prog.Show()
    End Sub
End Class
