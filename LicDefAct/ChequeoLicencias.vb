Imports System.Windows.Forms
Imports DattCom


Public Class ChequeoLicencias

    Public Shared Function ChequearLicencias(major As Int32, PathServidor As String, PathAppl As String, QueSistema As String, Autorizaciones As String, FF As String) As Long
        'Dim Proglib As New daaxLib.DaxLibDigDato
        Dim n As String = ""
        Dim V As String = ""
        Dim Sh As String = ""
        Dim datex As Date
        Dim NombrePcX As String = ""
        Dim ConxDaxSys As New SqlClient.SqlConnection(datosEmpresa.strConxSyscod)
        ConxDaxSys.Open()
        Dim rsUsr As SqlClient.SqlDataReader
        Dim rsEmp As SqlClient.SqlDataReader

        Dim a As Integer
        Dim b As Integer
        Dim Licencias As Integer
        Dim EmpNombre As String
        Dim EmpNombreBase As String = ""
        Dim EmpRuc As String
        Dim EmpClave As Long
        Dim Opciones As String = ""
        Dim ClaveFinal() As String
        Dim AUX1 As String
        Dim Valido As Integer
        Dim FechaServ As Date = CDate("0:0")
        datex = CDate("17/09/3007")
        ChequearLicencias = 0
        a = Len(Dir(PathServidor & QueSistema) & ".xml")
        If a = 0 Then MsgBox("La dirección URL de directorios en el servidor está errada, registrela nuevamente") : Return 0

        NuevaCodificacion.DatosPc(PathServidor, NombrePcX, V, n, Sh)
        'If Len(n) = 0 Then
        '    n = CNNV(NuevaCodificacion.ValorStr(Sh), NuevaCodificacion.ValorStr(QueSistema) * CDbl(major), 3, 2, QueSistema)
        'Else
        '    n = NuevaCodificacion.ValorStr(n).ToString()
        'End If
        'NombrePcX = CStr(Val(n) * CDbl(major))
        Valido = 1
        Dim Comm As New SqlClient.SqlCommand("Select * from emp_datos where emp_defecto <> 0 ", ConxDaxSys)
        rsEmp = Comm.ExecuteReader
        If rsEmp.Read = False Then Valido = 0
        If Valido = 0 Then MsgBox("Antes de continuar debe registrar la empresa principal en el sistema ") : Return 0
        EmpNombre = rsEmp.Item("Emp_Nombre").ToString()
        EmpNombreBase = "BdAdcomDx"
        EmpClave = CLng(rsEmp.Item("Emp_Codigo").ToString())
        EmpRuc = Left(rsEmp.Item("Emp_RUC").ToString(), 10)
        If rsEmp.IsClosed = False Then rsEmp.Close()
        Valido = 0
        Comm.CommandText = "select *,getdate() as FechaServ  FROM SYS_ACCESOS where (idusuario = 'Adm' or idusuario = 'Ctrl' ) and idopcion <> 'mnuoa' and idempresa = 0 and idsistema = '" & QueSistema & "'"
        Comm.Connection = ConxDaxSys
        rsUsr = Comm.ExecuteReader
        ReDim ClaveFinal(0 To 6)
        With rsUsr
            Do While rsUsr.Read
                Valido = 1
                FechaServ = CDate(rsUsr.Item("FechaServ"))
                If .Item("idusuario").ToString() = "Adm" Then
                    ClaveFinal(2) = .Item("Accesos").ToString()
                    ClaveFinal(4) = .Item("IdOpcion").ToString()
                    ClaveFinal(6) = .Item("IdNomOpcion").ToString()
                ElseIf .Item("idusuario").ToString() = "Ctrl" Then
                    ClaveFinal(1) = .Item("Accesos").ToString()
                    ClaveFinal(3) = .Item("IdOpcion").ToString()
                    ClaveFinal(5) = .Item("IdNomOpcion").ToString()
                End If
            Loop
            .Close()
        End With
        If Valido = 0 Then GoTo SinClave Else Valido = 0

        AUX1 = ""
        For i = 1 To 6
            If AUX1 > "" Then AUX1 += "-"
            AUX1 += ClaveFinal(i)
        Next i
        ReDim ClaveFinal(0)
        If rsUsr.IsClosed = False Then rsUsr.Close()
        Licencias = CInt(NuevaCodificacion.DeCodificarLicencia(AUX1, datex, CStr(NuevaCodificacion.ValorStr(EmpNombre)), EmpRuc, n, CStr(NuevaCodificacion.ValorStr(NombrePcX)), CStr(NuevaCodificacion.ValorStr(QueSistema)), Opciones, a, b))
        'Licencias = 1
        ChequearLicencias = Licencias

        datosEmpresa.auto = Opciones
        If Licencias > 99 Then
            Dim aa As String
            '        If Date <> FechaServ Then
            '            aa = "La fecha de su computador," & Format(Date, "dd/mmm/yyyy") & vbCr
            '            aa = aa & "es diferente de la fecha del sistema, " & Format(FechaServ, "dd/mmm/yyyy")
            '            aa = aa & "Debe correjir la fecha para continuar"
            '            MsgBox aa
            '        End
            '        End If
            aa = CFV(Val(n), NuevaCodificacion.ValorStr(EmpNombre), a, b, QueSistema)
            If IsDate(aa) = True Then
                'If CDate(aa) <> FechaServ Then
                '    aa = ""
                If Licencias > 400 Then
                    If Math.Abs(DateDiff("d", FechaServ, aa)) > 60 Then aa = ""
                    Licencias -= 400
                ElseIf Licencias > 300 Then
                    If Math.Abs(DateDiff("d", FechaServ, aa)) > 30 Then aa = ""
                    Licencias -= 300
                ElseIf Licencias > 200 Then
                    If Math.Abs(DateDiff("d", FechaServ, aa)) > 15 Then aa = ""
                    Licencias -= 200
                Else
                    If Math.Abs(DateDiff("d", FechaServ, aa)) > 8 Then aa = ""
                    Licencias -= 100
                End If
            Else
                aa = ""
            End If
            If aa = "" Then
                Comm.CommandText = "update sys_accesos set idnomopcion = '' where (idusuario = 'Adm' or idusuario = 'Ctrl') "
                Comm.ExecuteNonQuery()
                MsgBox("Su Licencia de acceso al sistema no es válida")
                Return 0
            End If
        End If

        If Licencias > 0 Then Return Licencias


        ' 99 LICENCIAS SIN LIMITE DE USUARIOS
        ' 98 LICENCIA DE DEMOSTRACION UTILIZA SOLAMENTE 1 EMPRESA Y 1 USUARIO
        ' 1 LICENCIA MONOUSUARIO

SinClave:
        Dim progin As New IngresaRegistro
        AUX1 = NuevaCodificacion.ClaveParaEnviar(EmpNombre, EmpRuc, n, NombrePcX, V, QueSistema, EmpNombreBase, Now.Date)
        AUX1 = progin.IngresaClave(AUX1)
        If AUX1 = "" Then
            Licencias = 0
            Autorizaciones = Strings.StrDup(35, "0")
        Else
            Licencias = CInt(NuevaCodificacion.DeCodificarLicencia(AUX1, Now.Date, CStr(NuevaCodificacion.ValorStr(EmpNombre)), EmpRuc, n, CStr(NuevaCodificacion.ValorStr(NombrePcX)), CStr(NuevaCodificacion.ValorStr(QueSistema)), Opciones, a, b))
            Autorizaciones = Opciones
            If Licencias > 0 Then

                AUX1 = NuevaCodificacion.CodificarLicenciaFinal(Str(Licencias), Opciones, datex, CStr(NuevaCodificacion.ValorStr(EmpNombre)), EmpRuc, n, CStr(NuevaCodificacion.ValorStr(NombrePcX)), CStr(NuevaCodificacion.ValorStr(QueSistema)), a, b)
                Comm.CommandText = "DELETE FROM SYS_ACCESOS where (idusuario = 'Adm' or idusuario = 'Ctrl' ) and idopcion <> 'mnuoa' and idempresa = 0 and idsistema = '" & QueSistema & "'"
                Comm.ExecuteNonQuery()
                ClaveFinal = Split(AUX1, "-")
                ReDim Preserve ClaveFinal(6)
                AUX1 = " INSERT INTO SYS_ACCESOS ( "
                AUX1 += "idusuario "
                AUX1 += ",idempresa "
                AUX1 += ",idsistema "
                AUX1 += ",Accesos"
                AUX1 += ",IdOpcion"
                AUX1 += ",IdNomOpcion )"
                AUX1 += " VALUES ("
                AUX1 += "'Adm'"
                AUX1 += ",0"
                AUX1 += ",'" & QueSistema & "'"
                AUX1 += ",'" & ClaveFinal(1) & "'"
                AUX1 += ",'" & ClaveFinal(3) & "'"
                AUX1 += ",'" & ClaveFinal(5) & "'"
                AUX1 += ")"
                Comm.CommandText = AUX1
                Comm.ExecuteNonQuery()

                AUX1 = " INSERT INTO SYS_ACCESOS ( "
                AUX1 += "idusuario "
                AUX1 += ",idempresa "
                AUX1 += ",idsistema "
                AUX1 += ",Accesos"
                AUX1 += ",IdOpcion"
                AUX1 += ",IdNomOpcion )"
                AUX1 += " VALUES ("
                AUX1 += "'Ctrl'"
                AUX1 += ",0"
                AUX1 += ",'" & QueSistema & "'"
                AUX1 += ",'" & ClaveFinal(0) & "'"
                AUX1 += ",'" & ClaveFinal(2) & "'"
                AUX1 += ",'" & ClaveFinal(4) & "'"
                AUX1 += ")"
                Comm.CommandText = AUX1
                Comm.ExecuteNonQuery()
            End If
            rsUsr.Close()
            rsEmp.Close()
            Comm.Dispose()
            ConxDaxSys.Dispose()

            If Licencias > 100 Then CF(CStr(Now.Date), Val(n), NuevaCodificacion.ValorStr(EmpNombre), a, b, QueSistema)
            If Licencias > 0 Then cnn(n, NuevaCodificacion.ValorStr(PathServidor), NuevaCodificacion.ValorStr(QueSistema) * CDbl(major), 3, 1, QueSistema)
        End If
        Return Licencias
erroresingresoclave:
        MsgBox("Error registro clave: " & Err.Description & " Nro: " & Err.Number)
        Application.ExitThread()
    End Function
    Private Shared Function CR(ByVal TEXTO As String) As String
        Dim i As Integer, b As String, bb As String
        Dim TexTot As String, Texto2 As String

        TexTot = TEXTO
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
            Texto2 += bb
        Next i
        CR = Texto2
    End Function

    Private Shared Function DCR(ByVal TEXTO As String) As String
        Dim i As Integer, m As Byte, bb As String
        Dim Texto2 As String
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
            Texto2 += bb
        Next i
        Texto2 = Trim(Texto2)
        'TexTot = ""
        'Fechas = "99" & Mid$(Format(Date, "ddmmyyyy") & Format(Date, "mmddyyyy"), 1, 12)
        'TexTot = CDbl(Texto2) - CDbl(Fechas) + Dias
        DCR = Texto2
    End Function

    Public Shared Function CFV(ByVal n As Double, ByVal S As Double, ByVal a As Integer, ByVal b As Integer, Sistema As String) As String
        Dim sSQL As String
        Dim V1 As Long
        Dim V2 As Long
        Dim rs As SqlClient.SqlDataReader
        Dim ConxDaxSys As New SqlClient.SqlConnection(datosEmpresa.strConxSyscod)
        ConxDaxSys.Open()
        sSQL = " where "
        sSQL += " idusuario = 'System' "
        sSQL &= " and IdEmpresa = 0 "
        sSQL &= " and SUBSTRING (IDOPCION,1,4) <> 'mnuo' "
        sSQL &= " and IdSistema = '" & Sistema & "'"

        CFV = ""
        Dim Comm As New SqlClient.SqlCommand("Select * from sys_accesos " & sSQL, ConxDaxSys)
        rs = Comm.ExecuteReader
        '        rs.Open(, ConxDaxSys, adOpenDynamic, adLockOptimistic)
        '       If Rs.EOF = False Then
        If rs.Read = True Then
            CFV = rs.Item("IdOpcion").ToString() & rs.Item("Accesos").ToString() & rs.Item("IdNomOpcion").ToString()
            rs.Close()
            rs = Nothing
            CFV = DCR(CFV)
            V2 = CLng(Left(CFV, 12))
            V1 = CLng(Mid(CFV, 13, 12))

            V2 = CLng(V2 - (Val(StrReverse(CStr(Int(S)))) * a))
            V2 = CLng(V2 / b)

            V1 = CLng(V1 - (n * b))
            V1 = CLng(V1 / a)
            V1 = CLng(Val(StrReverse(Mid(CStr(V1), 2))))
            If V1 = V2 Then CFV = Mid(CStr(V1), 1, 2) & "/" & Mid(CStr(V1), 3, 2) & "/" & Mid(CStr(V1), 5, 4) Else CFV = ""
        End If
        rs = Nothing
        ConxDaxSys.Dispose()
        Comm.Dispose()
    End Function

    Public Shared Sub CF(ByVal f As String, ByVal n As Double, ByVal S As Double, ByVal a As Integer, ByVal b As Integer, sistema As String)
        Dim V1 As Long
        Dim V2 As Long
        Dim T As String
        Dim V3 As String
        Dim ConxDaxSys As New SqlClient.SqlConnection(datosEmpresa.strConxSyscod)
        ConxDaxSys.Open()
        Dim sSQL As String = ""
        Dim Aux1 As String = ""
        Dim FF As String
        FF = Mid(f, 1, 2) & Mid(f, 4, 2) & Mid(f, 7, 4)
        V1 = CLng((Val("1" & StrReverse(FF)) * a) + (n * b))
        V2 = CLng((Val(FF) * b) + (Val(StrReverse(CStr(Int(S)))) * a))
        T = Right(Strings.StrDup(12, "0") & Trim(Str(V2)), 12) & Right(Strings.StrDup(12, "0") & Trim(Str(V1)), 12)
        V3 = CR(T)

        sSQL = " where "
        sSQL &= " idusuario = 'System' "
        sSQL &= " and IdEmpresa = 0 "
        sSQL &= " and SUBSTRING (IDOPCION,1,4) <> 'mnuo' "
        sSQL &= " and IdSistema = '" & sistema & "'"


        Dim comm As New SqlClient.SqlCommand("delete from sys_accesos " & sSQL, ConxDaxSys)
        comm.ExecuteNonQuery()
        Aux1 = " INSERT INTO SYS_ACCESOS ( "
        Aux1 += "idusuario "
        Aux1 += ",idempresa "
        Aux1 += ",idsistema "
        Aux1 += ",Accesos"
        Aux1 += ",IdOpcion"
        Aux1 += ",IdNomOpcion )"
        Aux1 += " VALUES ("
        Aux1 += "'System'"
        Aux1 += ",0"
        Aux1 += ",'" & sistema & "'"
        Aux1 += ",'" & Mid(V3, 6, 5) & "'"
        Aux1 += ",'" & Left(V3, 5) & "'"
        Aux1 += ",'" & Mid(V3, 11) & "'"
        Aux1 += ")"
        comm.CommandText = Aux1
        comm.ExecuteNonQuery()
        comm.Dispose()
        ConxDaxSys.Dispose()
    End Sub

    Public Shared Function CNNV(ByVal n As Double, ByVal S As Double, ByVal a As Integer, ByVal b As Integer, sistema As String) As String
        Dim sSQL As String
        Dim V1 As Long
        Dim V2 As Long
        Dim rs As SqlClient.SqlDataReader
        Dim ConxDaxSys As New SqlClient.SqlConnection(datosEmpresa.strConxSyscod)
        ConxDaxSys.Open()
        sSQL = " where "
        sSQL += " idusuario = 'Sys' "
        sSQL += " and IdEmpresa = 0 "
        sSQL += " and SUBSTRING (IDOPCION,1,4) <> 'mnuo' "
        sSQL += " and IdSistema = '" & sistema & "'"

        CNNV = ""

        Dim comm As New SqlClient.SqlCommand("Select * from sys_accesos " & sSQL, ConxDaxSys)
        rs = comm.ExecuteReader
        If rs.Read = True Then
            CNNV = CStr(rs.Item("IdNomOpcion"))
            rs.Close()
            rs = Nothing
            CNNV = DCR(CNNV)
            V2 = CLng(Left(CNNV, 12))
            V1 = CLng(Mid(CNNV, 13, 12))

            V2 = CLng(Val(V2) - (Val(StrReverse(CStr(S))) * a))
            V2 = CLng(Val(V2) / b)

            V1 = CLng(Val(V1) - (n * b))
            V1 = CLng(Val(V1) / a)
            V1 = CLng(StrReverse(Mid(CStr(V1), 2)))
            If V1 = V2 Then CNNV = CStr(V2) Else CNNV = CStr(V1)
        End If
        rs = Nothing
        comm.Dispose()
        ConxDaxSys.Dispose()
    End Function

    Public Shared Sub cnn(ByVal f As String, ByVal n As Double, ByVal S As Double, ByVal a As Integer, ByVal b As Integer, sistema As String)
        Dim V1 As Long
        Dim V2 As Long
        Dim T As String
        Dim V3 As String
        'Dim Rss As New SqlClient.SqlDataReader
        Dim sSQL As String
        Dim FF As String
        Dim Aux1 As String
        Dim ConxDaxSys As New SqlClient.SqlConnection(datosEmpresa.strConxSyscod)
        ConxDaxSys.Open()

        FF = f
        V1 = CLng((Val("1" & StrReverse(FF)) * a) + (n * b))
        V2 = CLng((Val(FF) * b) + (Val(StrReverse(CStr(S))) * a))
        T = Right(Strings.StrDup(12, "0") & Trim(Str(V2)), 12) & Right(Strings.StrDup(12, "0") & Trim(Str(V1)), 12)
        V3 = CR(T)

        sSQL = " where "
        sSQL += " idusuario = 'Sys' "
        sSQL += " and IdEmpresa = 0 "
        sSQL += " and SUBSTRING (IDOPCION,1,4) <> 'mnuo' "
        sSQL += " and IdSistema = '" & sistema & "'"

        'Rs.Open("Select * from sys_accesos " & sSQL, ConxDaxSys, adOpenDynamic, adLockOptimistic)
        'If Rs.EOF = True Then Rs.AddNew()
        'Rs!idusuario = "Sys"
        'Rs!idempresa = 0
        'Rs!idsistema = Sistema
        'Rs!IdOpcion = ""
        'Rs!IdNomOpcion = V3
        'Rs!Accesos = ""
        'Rs.Update()

        Dim comm As New SqlClient.SqlCommand("delete from sys_accesos " & sSQL, ConxDaxSys)
        comm.ExecuteNonQuery()
        Aux1 = " INSERT INTO SYS_ACCESOS ( "
        Aux1 += "idusuario "
        Aux1 += ",idempresa "
        Aux1 += ",idsistema "
        Aux1 += ",Accesos"
        Aux1 += ",IdOpcion"
        Aux1 += ",IdNomOpcion )"
        Aux1 += " VALUES ("
        Aux1 += "'Sys'"
        Aux1 += ",0"
        Aux1 += ",'" & sistema & "'"
        Aux1 += ",''"
        Aux1 += ",''"
        Aux1 += ",'" & V3 & "'"
        Aux1 += ")"
        comm.CommandText = Aux1
        comm.ExecuteNonQuery()
        '        Rss = Nothing
        comm.Dispose()
        ConxDaxSys.Dispose()
    End Sub
End Class
