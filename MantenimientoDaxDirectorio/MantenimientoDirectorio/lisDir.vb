Option Strict Off
Option Explicit On
Public Class lisDir
    Public Sub MallaDir(Optional queTipo As String = "")
        Dim PROG As New AdcDir
        Try
            Mainn()
            PROG.tipo = queTipo
            PROG.Show()
            'PROG.Dispose()
        Catch ee As Exception
            MsgBox("Excepción mallaDir: " & ee.Message)
        End Try
    End Sub
End Class
