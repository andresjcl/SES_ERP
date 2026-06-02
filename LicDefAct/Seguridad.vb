Public Class Seguridad
    Public Shared Function DeCodificar(ByVal TextoCod As String) As String
        Dim TextoAux1 As String = TextoCod
        Dim i As Integer
        Dim TEXTO As String = ""
        For i = 1 To Len(TextoAux1)
            TEXTO = Chr(((Asc(Mid$(TextoAux1, i, 1)) - 10) Xor 46) + 3) + TEXTO
        Next i
        DeCodificar = TEXTO
    End Function

    Public Shared Function Codificar(ByVal TextoCod As String) As String
        Dim TextoAux1 As String = TextoCod
        Dim i As Integer
        Dim TEXTO As String = ""
        For i = 1 To Len(TextoAux1)
            TEXTO = Chr(((Asc(Mid$(TextoAux1, i, 1)) - 3) Xor 46) + 10) + TEXTO
        Next i
        Codificar = TEXTO
    End Function

    Public Shared Function CodificarUsuario(ByVal TextoCod As String) As String
        Dim i As Integer, TEXTO As String, bb As String, b As Long
        TEXTO = ""
        For i = 1 To Len(TextoCod) Step 2
            b = ((Asc(Mid$(TextoCod, i, 2)) - 3) Xor 46) + 10
            If b < 91 And b > 64 Then
                bb = Chr(CInt(b))
            ElseIf b + 97 < 123 Then
                bb = Chr(CInt(b + 97))
            Else
                bb = Mid$(TextoCod, i, 2)
            End If
            TEXTO = TEXTO & bb
        Next i
        CodificarUsuario = TEXTO
    End Function

    Public Shared Function CodificarRegistroAnt(ByVal TEXTO As String) As String
        Dim Fechas As String, i As Integer, b As String, bb As String
        Dim Dias As Decimal
        Dim TexTot As String, Texto2 As String

        Fechas = "99" & Mid$(Format(Now, "ddmmyyyy") & Format(Now, "mmddyyyy"), 1, 12)
        Dias = DateDiff("D", "23/03/1957", Now)

        TexTot = CStr(CDbl(Fechas) + CDbl(TEXTO) - Dias)
        i = Len(TexTot)
        Texto2 = ""
        For i = 1 To i Step 2
            b = CStr(Val(Mid$(TexTot, i, 2)))
            If CDbl(b) < 91 And CDbl(b) > 64 Then
                bb = Chr(CInt(b))
            ElseIf CDbl(b) + 97 < 123 Then
                bb = Chr(CInt(CDbl(b) + 97))
            Else
                bb = Mid$(TexTot, i, 2)
            End If
            Texto2 = Texto2 & bb
        Next i
        CodificarRegistroAnt = CStr(Texto2)
    End Function

    Public Shared Function DeCodificarRegistroAnt(ByVal TEXTO As String) As String
        Dim Fechas As String, i As Integer, m As Byte, bb As String
        Dim Dias As Decimal, Texto2 As String
        Dim TexTot As String
        Dias = DateDiff("D", "23/03/1957", Now)
        Texto2 = ""
        For i = 1 To Len(TEXTO)
            bb = Mid$(TEXTO, i, 1)
            m = CByte(Asc(bb))
            If m > 64 And m < 91 Then
                bb = CStr(m)
            ElseIf m > 96 And m < 123 Then
                bb = CStr(m - 97)
                If Len(bb) < 2 Then bb = Mid$("00", 1, 2 - Len(bb)) & bb
            End If
            Texto2 = Texto2 & bb
        Next i
        Texto2 = Trim(Texto2)
        TexTot = ""
        Fechas = "99" & Mid$(Format(Now, "ddmmyyyy") & Format(Now, "mmddyyyy"), 1, 12)
        TexTot = CStr(CDbl(Texto2) - CDbl(Fechas) + Dias)
        DeCodificarRegistroAnt = TexTot
    End Function

End Class
