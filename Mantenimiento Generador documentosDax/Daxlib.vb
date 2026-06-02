Public Class Daxlib

    Friend Function CorrijeNuloN(valor As Object) As Double
        Dim resp As Double
        Try
            resp = Convert.ToDouble(valor)
        Catch ex As Exception
            resp = 0
        End Try
        Return resp
    End Function
    Friend Function CorrijeNulo(valor As Object) As String
        Dim resp As String
        Try
            resp = Convert.ToString(valor)
        Catch ex As Exception
            resp = ""
        End Try
        Return resp
    End Function

End Class
