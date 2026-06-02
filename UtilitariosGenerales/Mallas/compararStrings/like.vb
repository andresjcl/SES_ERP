Public Class comparar
    Public Function likke(buscarEn As String, buscar As String) As Boolean
        Return (buscarEn Like "*" + buscar + "*")
    End Function
End Class
