Public Class Class1
    Public Function DeCodificar(TextoCod As String) As String
        Dim TextoAux1 As String, i As Integer, TEXTO As String
        TextoAux1 = TextoCod
        TEXTO = ""
        For i = 1 To Len(TextoAux1)
            TEXTO = Chr(((Asc(Mid$(TextoAux1, i, 1)) - 10) Xor 46) + 3) + TEXTO
        Next i
        'If Mid(TEXTO, 1, 3) = "DaX" Then DeCodificar = Mid(TEXTO, 4) Else DeCodificar = TEXTO
        DeCodificar = Mid(TEXTO, 3)
        DeCodificar = Mid(DeCodificar, 1, Len(DeCodificar) - 2)
        DeCodificar = Replace(DeCodificar, "|", "0")
    End Function

    Public Function Codificar(TextoCod As String) As String
        Dim TextoAux1 As String, i As Integer, TEXTO As String
        TextoAux1 = Replace(TextoCod, "0", "|")
        'If IsNumeric(Mid(TextoAux1, 1, 1)) Then 
        TextoAux1 = "dD" & TextoAux1 & "xX"
        'end if
        TEXTO = ""
        For i = 1 To Len(TextoAux1)
            TEXTO = Chr(((Asc(Mid$(TextoAux1, i, 1)) - 3) Xor 46) + 10) + TEXTO
        Next i
        Codificar = TEXTO
    End Function
End Class
