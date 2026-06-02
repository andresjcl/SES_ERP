Option Strict Off
Option Explicit On
Public Class ClsSysp13
    Public Sub SbSysp13()
        Dim prog As New SYSP13
        prog.Show()
        '        prog.Close()
        'prog.Dispose()
    End Sub

    Public Function BusOpcdoc(ByRef codigo As String, ByRef nombre As String, ByRef Tipo As String) As String
        Dim prog As New BuscDocAdcom
        prog.BuscaDocAdcom(Tipo, codigo, nombre)
        BusOpcdoc = Tipo
    End Function

    Public Sub Numeracion()
        Dim prog As New frmAdcDocnum
        prog.ShowDialog()
        prog = Nothing
    End Sub
End Class