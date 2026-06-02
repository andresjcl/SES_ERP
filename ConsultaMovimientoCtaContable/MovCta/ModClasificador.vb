Module ModClasificador
    Public Function EscojeClasf(ByVal Clasif As String, ByRef campoctbdia As String) As String
        Dim LibBas As New daaxLib.DaxLibBases()

        Dim ClasificadorPadre As String = ""
        Dim Ssql As String = ""
        Dim SelectSql As String = ""
        Dim WhereSql As String = ""
        Dim NroReg As Integer = 0
        EscojeClasf = ""
        Dim Conxadcom As New SqlClient.SqlConnection(LibBas.StrAdcom)
        Conxadcom.Open()
        Dim Rs As SqlClient.SqlDataReader
        ClasificadorPadre = Clasif
        Dim Comm As New SqlClient.SqlCommand
        Dim campofinal As String = ""
        campoctbdia = ""
        ClasificadorPadre = Clasif
        Comm.Connection = Conxadcom
        Comm.CommandText = "SELECT nombre,isnull(padre,'') as padre,isnull(campodia,'') as campodia FROM AdcClasfctb WHERE nombre = '" & ClasificadorPadre & "' "
        Rs = Comm.ExecuteReader
        If Rs.Read Then
            ClasificadorPadre = Rs.Item("nombre").ToString
            campoctbdia = Rs.Item("campodia").ToString
        End If
        Rs.Close()
        Comm.Dispose()

        'Do Until ClasificadorPadre = ""
        '    NroReg += 1
        '    If Ssql > "" Then Ssql += " left join "
        '    Ssql += " (select Abreviación ,Caracteristica1  from syscod where ABREVIACIÓN <> '#' AND TipoReferencia  = '" & ClasificadorPadre & "' ) R" & NroReg
        '    If NroReg > 1 Then Ssql += " on r" & NroReg & ".Caracteristica1 = r" & NroReg - 1 & ".Abreviación "
        '    If SelectSql > "" Then SelectSql += ","
        '    SelectSql += "R" & NroReg & ".Abreviación as [" & ClasificadorPadre & "] "
        '    Comm.CommandText = "SELECT nombre,isnull(padre,'') as padre,isnull(campodia,'') as campodia FROM AdcClasfctb WHERE padre = '" & ClasificadorPadre & "' "
        '    Rs = Comm.ExecuteReader
        '    campofinal = ClasificadorPadre
        '    ClasificadorPadre = ""
        '    If Rs.Read Then
        '        ClasificadorPadre = Rs.Item("nombre").ToString
        '        campoctbdia = Rs.Item("campodia").ToString
        '    End If
        '    Rs.Close()
        '    Comm.Dispose()
        'Loop
        'If SelectSql > "" Then Ssql = " select " & SelectSql & " into [dx" & campofinal & "] from " & Ssql
        'Comm.CommandText = "IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dx" & campofinal & "]') AND type in (N'U')) DROP TABLE [dx" & campofinal & "]"
        'Comm.ExecuteNonQuery()
        ''Comm.CommandText = Ssql
        ''Comm.ExecuteNonQuery()
        'Comm.Dispose()
        'Conxadcom.Dispose()
        EscojeClasf = ClasificadorPadre

    End Function
End Module
