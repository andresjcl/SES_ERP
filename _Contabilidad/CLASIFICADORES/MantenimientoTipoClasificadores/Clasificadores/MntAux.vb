Public Class MntAux
    Public Sub Clasificadores(ByVal cod As String, ByVal str As String)
        Dim prog As New frmClasf
        If str = "" Then Exit Sub
        prog.StrCod = cod
        prog.strConxAdcom = str
        prog.ShowDialog()
    End Sub
End Class
