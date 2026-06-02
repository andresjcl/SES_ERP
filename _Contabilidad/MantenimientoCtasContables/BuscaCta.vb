Option Strict Off
Option Explicit On

Public Class BuscaCta
    Public Function BuscaCtaCtb(ByRef Nombre As String, ByRef TipoMovimiento As String) As String
        Dim prog As New BuscaCtaContab
        prog.IniciaCtas(Nombre, TipoMovimiento)
        BuscaCtaCtb = CodigoCta
        Nombre = NombreCta
    End Function
    Public Sub ImprimePlanCtas()
        Dim prog As New CTBP21
        prog.ShowDialog()
        prog = Nothing
    End Sub

    Public Sub MantenCtas()
        Dim prog As New CTBP01
        prog.ShowDialog()
        prog = Nothing
    End Sub

End Class