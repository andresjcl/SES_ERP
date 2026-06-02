
Public Class MantClasf
    Public Sub clasificadores(ByVal strAdcom As String, ByVal strDaxsys As String)
        Dim cl As New FrmMantClasf
        cl.strcon = strAdcom
        cl.strsys = strDaxsys
        cl.Show()
    End Sub
End Class
