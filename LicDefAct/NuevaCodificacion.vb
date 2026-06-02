Imports System.IO
Imports DattCom
Imports System.Data.SqlClient

Public Class NuevaCodificacion

    Public Shared Sub DatosPc(ByRef Pathpc As String, ByRef NombrePc As String, ByRef NombreVolumen As String, ByRef SeriePc As String, ByRef PathServer As String)
        ' cambiar On Error Resume Next
        'Dim fs As New Scripting.FileSystemObject
        'Dim D As Scripting.Drive
        'D = fs.GetDrive(fs.GetDriveName(fs.GetAbsolutePathName(Pathpc)))
        'Dim cad1 As String = ""
        'Dim cad2 As String = ""
        ''Dim numSerie As Long
        ''Dim Longitud As Long
        ''Dim flag As Long
        'Dim Unidad As String
        ''
        'Unidad = D.Path
        ''Call GetVolumeInformation(Unidad, cad1, 256, numSerie, Longitud, flag, cad2, 256)
        ''    MsgBox "Numero de Serie de la unidad " & Unidad & " = " & numSerie

        'SeriePc = CStr(Math.Abs(D.SerialNumber))
        'NombreVolumen = UCase$(D.VolumeName)
        'PathServer = UCase$(D.ShareName)

        ''NombrePc = D.
        ''StrString = Space(255) 'StrDup(255, Chr(0))
        ''GetComputerName(StrString, 255)
        ''StrString = Left(StrString, InStr(1, StrString, Chr(0)) - 1)
        ''NombrePc = UCase$(StrString)
        ''        If NombrePc = "" Then
        ''If Mid(Pathpc, 1, 2) = "\\" Then
        ''    NombrePc = Mid(Pathpc, 3, InStr(3, Pathpc, "\") - 3)
        ''Else
        ''    NombrePc = My.Computer.Name
        ''End If
        ''        End If

        ''El volumen de la unidad C es Windows_2016
        ''El número de serie del volumen es:    1AAD-894E


        ''D = Nothing
        PathServer = QuitarServidor(Pathpc)
        Dim ssql As String = "Select @@ServerName as Server,host_name() as Estacion,@@SERVICENAME as SQL"
        Dim dr As SqlDataReader = SqlDatos.leerBaseIniSis(ssql)
        If (dr.Read) Then
            NombrePc = dr("Server").ToString()
        End If
        dr.Close()
        ssql = "exec xp_cmdshell 'vol'"
        Dim dt As DataTable = SqlDatos.leerTablaIniSis(ssql)
        If (dt.Rows.Count > 1) Then
            NombreVolumen = dt.Rows(0)(0).ToString()
            NombreVolumen = Right(NombreVolumen, 12)
            '    PathServer = dt.Rows(1)(0).ToString()
            '    PathServer = Right(PathServer, 12)
        End If
        'dt = New DataTable()
        ssql = "exec xp_cmdshell 'wmic bios get serialnumber'"
        dt = SqlDatos.leerTablaIniSis(ssql)
        If (dt.Rows.Count > 1) Then
            SeriePc = dt.Rows(1)(0).ToString()
            SeriePc = Trim(SeriePc.Replace(vbCr, ""))
            SeriePc = ValorStr(SeriePc).ToString()
        End If

    End Sub

    Public Shared Function ClaveParaEnviar(ByVal empresaClv As String, ByVal RucEmpresa As String, ByVal SeriePc As String,
                    ByVal NombrePc As String, ByVal EtiquetaDisco As String, ByVal Sistema As String, ByVal NomBaseDatos As String, ByVal datex As Date) As String
        '' para enviar clave a daxsof
        Dim AUX1 As String
        Dim a As Single
        Dim b As Single
        Randomize()
        a = Int(Int(Rnd() * 9) + 1)
        b = Int(Int(Rnd() * 9) + 1)
        If a = 0 Then a = 1
        If b = 0 Then b = 1

        '' Aux máximo 48 numeros
        If RucEmpresa.Length > 10 Then RucEmpresa = RucEmpresa.Substring(0, 10)
        AUX1 = ""
        AUX1 = AUX1 & Right(StrDup(5, "0") & ValorStr(NomBaseDatos), 5) ' 1,5
        AUX1 = AUX1 & Right(StrDup(10, "0") & RucEmpresa, 10) ' 6,15
        AUX1 = AUX1 & Right(StrDup(12, "0") & SeriePc, 12) ' 16, 27
        AUX1 = AUX1 & Right(StrDup(5, "0") & ValorStr(NombrePc), 5) ' 28 , 32
        AUX1 = AUX1 & Right(StrDup(5, "0") & ValorStr(EtiquetaDisco), 5) '33 , 37
        AUX1 = AUX1 & Right(StrDup(6, "0") & ValorStr(empresaClv), 6)  ' 38 , 43
        AUX1 = AUX1 & a '44, 44
        AUX1 = AUX1 & Right(StrDup(3, "0") & ValorStr(Sistema), 3)  ' 45, 47
        AUX1 = AUX1 & b ' 48,48

        ClaveParaEnviar = CodificarRegistro(AUX1, datex)
        'debug.Print AUX1
        'debug.Print ClaveParaEnviar
        'debug.Print DeCodificarRegistro(ClaveParaEnviar, datex)
    End Function

    Public Shared Sub DecodificarClaveRecibe(ByVal ClaveRecibida As String, ByRef empresaClvR As String, ByRef RucEmpresa As String, ByRef SeriePc As String,
                    ByRef SistemaX As String, ByRef NombrePc As String, ByRef a As Integer, ByRef b As Integer, ByRef datex As Date)
        Dim AUX1 As String
        '' sub para daxsof
        AUX1 = DeCodificarRegistro(ClaveRecibida, datex)
        'NomBaseDatos = mid$(aux1, 1, 5)
        RucEmpresa = Mid$(AUX1, 6, 10)
        SeriePc = Mid$(AUX1, 16, 12)
        NombrePc = Mid$(AUX1, 28, 5)
        'EtiquetaDisco = mid$(aux1, 33, 5)
        empresaClvR = Mid$(AUX1, 38, 6)
        a = CInt(Val(Mid$(AUX1, 44, 1)))
        SistemaX = CStr(CInt(Mid$(AUX1, 45, 3)))
        b = CInt(Val(Mid$(AUX1, 48, 1)))

    End Sub

    Public Shared Function CodificarLicencia(ByVal ClaveEnviada As String, ByVal Licencias As String, ByVal Opciones As String, ByVal datex As Date) As String
        Dim codEmpresa As String = ""
        Dim RucEmpresa As String = ""
        Dim SeriePc As String = ""
        Dim NombrePc As String = ""
        Dim SistemaX As String = ""
        Dim AUX1 As String
        Dim a As Integer
        Dim b As Integer
        'Dim opciones As String
        'Dim licencias As String
        Dim Valn As Long
        Dim Vale As Long
        Dim Valr As Long
        DecodificarClaveRecibe(ClaveEnviada, codEmpresa, RucEmpresa, SeriePc, SistemaX, NombrePc, a, b, datex)
        ''''''
        '
        ' Aqui se puede leer directamente desde el archivo de clientes, y comparar si existe o
        ' o esta correcto los datos recibidos
        ' para averiguar porque pid otra licencia  o porque cambio
        ' leer el registro con el RUC
        '
        Valr = CLng(Val(RucEmpresa) + Val(Licencias) * a)
        Valn = CLng(Val(NombrePc) + Val(SistemaX))
        Vale = CLng(Val(codEmpresa) + Val(Licencias) * b)
        AUX1 = ""
        AUX1 = AUX1 & Right(StrDup(10, "0") & Valr, 10) ' 1,10
        AUX1 = AUX1 & Right(StrDup(12, "0") & SeriePc, 12) ' 11, 22
        AUX1 = AUX1 & Right(StrDup(5, "0") & Valn, 5) ' 23 , 27
        AUX1 = AUX1 & Right(StrDup(14, "0") & BinarioDecimal(Opciones) * b * a, 14) '28, 41
        AUX1 = AUX1 & Right(StrDup(5, "0") & Vale, 5)  ' 42 , 46
        AUX1 = AUX1 & a ' 47,47
        AUX1 = AUX1 & b ' 48 , 48

        CodificarLicencia = CodificarRegistro(AUX1, datex)
        'debug.Print aux1
        'debug.Print ClaveParaEnviar
        'debug.Print DeCodificarRegistro(ClaveParaEnviar, Datex)
    End Function

    Public Shared Function CodificarLicenciaFinal(ByVal Licencias As String, ByVal Opciones As String, ByVal datex As Date,
        ByVal empresaLF As String, ByVal RucEmpresa As String, ByVal SeriePc As String, ByVal NombrePc As String, ByVal SistemaX As String,
        ByVal a As Integer, ByVal b As Integer) As String
        Dim AUX1 As String
        'Dim opciones As String
        'Dim licencias As String
        Dim Valn As Long
        Dim Vale As Long
        Dim Valr As Long
        If RucEmpresa.Length > 10 Then RucEmpresa = RucEmpresa.Substring(0, 10)
        Valr = CLng(Val(RucEmpresa) + Val(Licencias) * a)
        Valn = CLng(Val(NombrePc) + Val(SistemaX))
        Vale = CLng(Val(empresaLF) + Val(Licencias) * b)
        AUX1 = ""
        AUX1 = AUX1 & Right(StrDup(10, "0") & Valr, 10) ' 1,10
        AUX1 = AUX1 & Right(StrDup(12, "0") & SeriePc, 12) ' 11, 22
        AUX1 = AUX1 & Right(StrDup(5, "0") & Valn, 5) ' 23 , 27
        AUX1 = AUX1 & Right(StrDup(14, "0") & BinarioDecimal(Opciones) * b * a, 14) '28, 41
        AUX1 = AUX1 & Right(StrDup(5, "0") & Vale, 5)  ' 42 , 46
        AUX1 = AUX1 & a ' 47,47
        AUX1 = AUX1 & b ' 48 , 48

        CodificarLicenciaFinal = CodificarRegistro(AUX1, datex)
    End Function

    Public Shared Function DeCodificarLicencia(ByVal ClaveLicencia As String, ByVal datex As Date,
     ByVal empresaDL As String, ByVal RucEmpresa As String, ByVal SeriePc As String, ByVal NombrePc As String, ByVal SistemaX As String, ByRef Opciones As String, ByRef a As Integer, ByRef b As Integer) As Long
        Dim AUX1 As String
        Dim Licencias As Single
        Dim Licencias2 As Long
        Dim SistemaClv As String = ""
        Dim SeriePcClv As String = ""
        If RucEmpresa.Length > 10 Then RucEmpresa = RucEmpresa.Substring(0, 10)
        Licencias = 0
        Opciones = StrDup(35, "0")
        AUX1 = DeCodificarRegistro(ClaveLicencia, datex)
        a = CInt(Val(Mid$(AUX1, 47, 1)))
        b = CInt(Val(Mid$(AUX1, 48, 1)))
        If a > 0 And b > 0 And a < 10 And b < 10 Then
            ' cambiar On Error GoTo 0
            Licencias = CSng((Val(Mid$(AUX1, 1, 10)) - Val(RucEmpresa)) / a)
            Licencias2 = CLng((Val(Mid$(AUX1, 42, 5)) - Val(empresaDL)) / b)
            Opciones = Right(StrDup(35, "0") & DecimalBinario(CLng(Val(Mid$(AUX1, 28, 14)) / b / a)), 35)
            SistemaClv = CStr(Val(Mid$(AUX1, 23, 5)) - Val(NombrePc))
            SeriePcClv = Mid$(AUX1, 11, 12)
        End If
        If Val(Licencias) <> Val(Licencias2) Or Val(SistemaX) <> Val(SistemaClv) Or Val(SeriePcClv) <> Val(SeriePc) Then Licencias = 0 : Opciones = StrDup(35, "0")

        'debug.Print aux1
        'debug.Print ClaveParaEnviar
        'debug.Print DeCodificarRegistro(ClaveParaEnviar, Datex)
        DeCodificarLicencia = CLng(Licencias)
    End Function

    Private Shared Function CambiaANumerico(ByVal TEXTO As String, ByVal Limite As Long) As String
        Dim TexTot As String, Texto2 As String
        Dim b As Integer
        TexTot = Left(TEXTO & Space(CInt(Limite)), CInt(Limite))
        Texto2 = ""
        For i = 1 To Limite
            b = Asc(UCase$(Mid$(TexTot, CInt(i), 1))) - 32
            Texto2 = Texto2 & Right("00" & b, 2)
        Next
        CambiaANumerico = CStr(Texto2)
    End Function

    Private Shared Function DecodificarNumerico(ByVal TEXTO As String) As String
        Dim Texto2 As String
        Dim Valor As Long
        DecodificarNumerico = ""
        If TEXTO = "" Then Exit Function
        Texto2 = ""
        For i = 1 To Len(TEXTO) Step 2
            Valor = CLng(Val(Mid$(TEXTO, i, 2)))
            Texto2 = Texto2 & Chr(CInt(Valor + 32))
        Next
        DecodificarNumerico = Texto2
    End Function

    Public Shared Function BinarioDecimal(ByVal Binario As String) As Double
        Dim TOTAL As Double, i As Long, D As Long
        TOTAL = 0
        D = 1
        For i = Len(Binario) To 1 Step -1
            TOTAL = TOTAL + Val(Mid$(Binario, CInt(i), 1)) * D
            D = D * 2
        Next i
        BinarioDecimal = TOTAL
    End Function

    Public Shared Function DecimalBinario(ByVal numDec As Long) As String
        Dim TOTAL As String = ""
        Dim X As Long
        Do Until numDec = 0
            X = CLng(Int(numDec / 2))
            If numDec <> (X * 2) Then TOTAL = "1" + TOTAL Else TOTAL = "0" + TOTAL
            numDec = X
        Loop
        Return TOTAL
    End Function

    Public Shared Function CodificarRegistro(ByVal TEXTO As String, ByVal datex As Date) As String
        Dim Fechas As String
        Dim Dias As Long
        Dim TexTot(10) As String
        Dim R As Integer
        Dim TOTAL As Long, RESTO As Long, numero As Long
        Dim resp(6) As String

        Dias = DateDiff("D", "23/03/1957", datex)
        Fechas = Right("00" & datex.Day, 2) & Right("00" & datex.Month, 2) & Right("0000" & datex.Year, 4)
        TexTot(1) = CStr(CDbl("1" & Mid$(TEXTO, 17, 8)) + CDbl(StrReverse(Fechas)) + Dias)
        TexTot(2) = CStr(CDbl("1" & StrReverse(Mid$(TEXTO, 33, 8))) + CDbl(Fechas) + Dias)
        TexTot(3) = CStr(CDbl("1" & Mid$(TEXTO, 9, 8)) + CDbl(StrReverse(Fechas)) + Dias)
        TexTot(4) = CStr(CDbl("1" & StrReverse(Mid$(TEXTO, 1, 8))) + CDbl(Fechas) + Dias)
        TexTot(5) = CStr(CDbl("1" & Mid$(TEXTO, 25, 8)) + CDbl(StrReverse(Fechas)) + Dias)
        TexTot(6) = CStr(CDbl("1" & StrReverse(Mid$(TEXTO, 41, 8))) + CDbl(Fechas) + Dias)
        For R = 1 To 6
            TOTAL = CLng(Val(TexTot(R)))
            resp(R) = ""
            Do Until TOTAL = 0
                numero = CLng(Int(TOTAL / 62))
                RESTO = TOTAL - numero * 62
                resp(R) = QueDigito(RESTO) & resp(R)
                TOTAL = numero
            Loop
        Next R
        CodificarRegistro = MayMin(resp(1)) & "-" & MayMin(resp(2)) & "-" & MayMin(resp(3)) & "-" & MayMin(resp(4)) & "-" & MayMin(resp(5)) & "-" & MayMin(resp(6))

    End Function

    Private Shared Function MayMin(ByVal dato As String) As String
        Dim i As Integer
        Dim j As Integer
        Dim Nvo As String
        Dim Decm As Long
        j = Len(dato)
        Nvo = ""
        For i = 1 To j
            If Mid$(dato, i, 1) = UCase$(Mid$(dato, i, 1)) Then
                Nvo = Nvo & "0"
            Else
                Nvo = Nvo & "1"
            End If
        Next i
        Decm = CLng(BinarioDecimal(Nvo))
        If Decm < 10 Then
            Nvo = CStr(Decm)
        Else
            Nvo = Chr(CInt(Decm + 55))
        End If
        MayMin = Nvo & UCase$(dato)
    End Function
    Private Shared Function MinMay(ByVal dato As String) As String
        Dim i As Integer
        'Dim j As Integer
        Dim Nvo As String
        Dim Decm As Long
        Dim datonew As String
        ' cambiar On Error Resume Next
        Nvo = Mid$(dato, 1, 1)
        Decm = Asc(Nvo)
        If Nvo >= "A" Then Nvo = CStr(Decm - 55)

        'Decm = Asc(mid$(dato, 1, 1))
        '
        'If Decm < 55 Then
        '    Nvo = mid$(dato, 1, 1)
        'Else
        '    Nvo = Decm - 55
        'End If
        Nvo = Right(StrDup(5, "0") & DecimalBinario(CLng(Nvo)), 5)
        datonew = ""
        For i = 1 To 5
            If Mid$(Nvo, i, 1) = "1" Then
                datonew = datonew & LCase$(Mid$(dato, i + 1, 1))
            Else
                datonew = datonew & Mid$(dato, i + 1, 1)
            End If
        Next i
        MinMay = datonew
    End Function

    Public Shared Function DeCodificarRegistro(ByVal TEXTO As String, ByVal datex As Date) As String
        Dim Fechas As String, i As Integer
        ', b As Byte, 
        Dim m As Double, bb As Long
        Dim Dias As Long
        'Dim Texto2 As String
        Dim TexTot() As String
        Dim R As Integer
        Dim TOTAL As Double
        'dim RESTO As Long
        'dim numero As Double
        Dim resp(6) As String
        ' cambiar On Error GoTo 0
        DeCodificarRegistro = ""
        TexTot = Split(TEXTO, "-")
        If UBound(TexTot) <> 5 Then Exit Function
        For i = 0 To 5
            TexTot(i) = MinMay(TexTot(i))
        Next i
        'Dim aux As String
        'aux = datex
        Dias = DateDiff("D", "23/03/1957", datex)
        Fechas = Right("00" & datex.Day, 2) & Right("00" & datex.Month, 2) & Right("0000" & datex.Year, 4)
        For R = 0 To 5
            TOTAL = 0
            bb = Len(TexTot(R))
            For i = 1 To CInt(bb)
                m = QueNumero(Mid$(TexTot(R), i, 1))
                TOTAL = CLng(TOTAL + m * (62 ^ (bb - i)))
            Next i
            TexTot(R) = CStr(TOTAL)
        Next R
        TexTot(0) = CStr(CDbl(CDbl(TexTot(0)) - CDbl(StrReverse(Fechas))) - Dias)
        TexTot(1) = CStr(CDbl(TexTot(1)) - CDbl(Fechas) - Dias)
        TexTot(2) = CStr(CDbl(TexTot(2)) - CDbl(StrReverse(Fechas)) - Dias)
        TexTot(3) = CStr(CDbl(TexTot(3)) - CDbl(Fechas) - Dias)
        TexTot(4) = CStr(CDbl(TexTot(4)) - CDbl(StrReverse(Fechas)) - Dias)
        TexTot(5) = CStr(CDbl(TexTot(5)) - CDbl(Fechas) - Dias)
        DeCodificarRegistro = StrReverse(Mid$(TexTot(3), 2)) & Mid$(TexTot(2), 2) & Mid$(TexTot(0), 2) & Mid$(TexTot(4), 2) & StrReverse(Mid$(TexTot(1), 2)) & StrReverse(Mid$(TexTot(5), 2))
        'debug.Print DeCodificarRegistro
    End Function

    Private Shared Function QueDigito(ByVal numero As Long) As String
        If numero < 10 Then
            QueDigito = CStr(numero) : Exit Function
        ElseIf numero < 36 Then
            QueDigito = Chr(CInt(numero + 55)) : Exit Function
        Else
            QueDigito = Chr(CInt(numero + 61))
        End If
    End Function

    Private Shared Function QueNumero(ByVal Digito As String) As Long
        QueNumero = Asc(Digito)
        If QueNumero < 58 Then
            QueNumero = CLng(Val(Digito))
            Exit Function
        ElseIf QueNumero < 91 Then
            QueNumero = QueNumero - 55 : Exit Function
        Else
            QueNumero = QueNumero - 61
        End If
    End Function

    Public Shared Function ValorStr(ByVal dato As String) As Double
        ' cambiar On Error Resume Next
        Dim Valor As Long
        Dim L As Integer
        Dim j As Integer
        Valor = 0
        j = Len(dato)
        For L = 1 To j
            Valor = Valor + Asc(Mid(dato, L, 1)) * L + Asc(Mid(dato, j - L + 1, 1)) * L
        Next L
        If Valor > 99999 Then ValorStr = Val(Right(CStr((Valor)), 5)) Else ValorStr = Valor
    End Function
    Public Shared Function QuitarServidor(Path As String) As String

        Dim inicio As Integer = -1
        Dim resp As String = Path
        Dim i As Integer
        If (Path.Substring(0, 2) = "\\" Or Path.Substring(0, 2) = "//") Then
            For i = 2 To Len(Path) Step 1
                If (Path.Substring(i, 1) = "\" Or Path.Substring(i, 1) = "\") Then
                    inicio = i
                    Exit For
                End If
            Next
            If (inicio > -1) Then resp = Path.Substring(inicio)
        End If
        Return resp
    End Function
End Class
