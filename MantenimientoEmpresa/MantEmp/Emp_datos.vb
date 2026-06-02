Imports System.Data.SqlClient
Public Class Emp_datos
    Public Emp_codigo As Integer = 0
    Public Emp_Nombre As String = ""
    Public Emp_Pais As String = ""
    Public Emp_Provincia As String = ""
    Public Emp_Ciudad As String = ""
    Public Emp_Cantón As String = ""
    Public Emp_Dirección As String = ""
    Public Emp_Telefono_1 As String = ""
    Public Emp_Telefono_2 As String = ""
    Public Emp_Fax As String = ""
    Public Emp_Casilla As String = ""
    Public Emp_Email As String = ""
    Public Emp_RUC As String = ""
    Public Emp_SegSocial As String = ""
    Public Emp_Presidente As String = ""
    Public Emp_Gerente As String = ""
    Public Emp_RepLegal As String = ""
    Public Emp_Contador As String = ""
    Public Emp_Logotipo As String = ""
    Public Emp_Defecto As Boolean = False
    Public Emp_Lic1 As String = ""
    Public Emp_Lic2 As String = ""
    Public Emp_Lic3 As String = ""
    Public Emp_PathImagenes As String = ""
    Public Emp_Lic4 As String = ""
    Public Emp_Lic5 As String = ""
    Public Emp_Lic6 As String = ""
    Public Emp_TipoBase As String = ""
    Public Emp_Conta As Boolean = False        'bit
    Public Emp_AgeRet As String = ""          'varchar(50)
    Public Emp_ContrBuyEsp As String = ""     'varchar(50)
    Public Emp_Regimen As String = ""

    Dim ssql As String = ""

    Public Sub Guardar()
        ssql = "insert into Emp_Datos ("
        ssql += " Emp_codigo ,"
        ssql += " Emp_Nombre ,"
        ssql += " Emp_Pais ,"
        ssql += " Emp_Provincia ,"
        ssql += " Emp_Ciudad ,"
        ssql += " Emp_Cantón ,"
        ssql += " Emp_Dirección ,"
        ssql += " Emp_Telefono_1 ,"
        ssql += " Emp_Telefono_2 ,"
        ssql += " Emp_Fax ,"
        ssql += " Emp_Casilla ,"
        ssql += " Emp_Email ,"
        ssql += " Emp_RUC ,"
        ssql += " Emp_SegSocial ,"
        ssql += " Emp_Presidente ,"
        ssql += " Emp_Gerente ,"
        ssql += " Emp_RepLegal ,"
        ssql += " Emp_Contador ,"
        ssql += " Emp_Logotipo ,"
        ssql += " Emp_Defecto ,"
        ssql += " Emp_Lic1 ,"
        ssql += " Emp_Lic2 ,"
        ssql += " Emp_Lic3 ,"
        ssql += " Emp_Lic4 ,"
        ssql += " Emp_Lic5 ,"
        ssql += " Emp_Lic6 ,"
        ssql += " Emp_TipoBase ,"
        ssql += " Emp_Conta ,"
        ssql += " Emp_AgeRet ,"
        ssql += " Emp_ContrBuyEsp ,"
        ssql += " Emp_Regimen )"
        ssql += " values ("
        ssql += " " & Emp_codigo & ","
        ssql += "'" & Emp_Nombre & "',"
        ssql += "'" & Emp_Pais & "',"
        ssql += "'" & Emp_Provincia & "',"
        ssql += "'" & Emp_Ciudad & "',"
        ssql += "'" & Emp_Cantón & "',"
        ssql += "'" & Emp_Dirección & "',"
        ssql += "'" & Emp_Telefono_1 & "',"
        ssql += "'" & Emp_Telefono_2 & "',"
        ssql += "'" & Emp_Fax & "',"
        ssql += "'" & Emp_Casilla & "',"
        ssql += "'" & Emp_Email & "',"
        ssql += "'" & Emp_RUC & "',"
        ssql += "'" & Emp_SegSocial & "',"
        ssql += "'" & Emp_Presidente & "',"
        ssql += "'" & Emp_Gerente & "',"
        ssql += "'" & Emp_RepLegal & "',"
        ssql += "'" & Emp_Contador & "',"
        ssql += "'" & Emp_Logotipo & "',"
        If Emp_Defecto = True Then ssql += " 1," Else ssql += " 0,"
        ssql += "'" & Emp_Lic1 & "',"
        ssql += "'" & Emp_Lic2 & "',"
        ssql += "'" & Emp_Lic3 & "',"
        ssql += "'" & Emp_Lic4 & "',"
        ssql += "'" & Emp_Lic5 & "',"
        ssql += "'" & Emp_Lic6 & "',"
        ssql += "'" & Emp_TipoBase & "',"
        If Emp_Conta Then ssql += "1," Else ssql += "0,"
        ssql += "'" & Emp_AgeRet & "',"
        ssql += "'" & Emp_ContrBuyEsp & "',"
        ssql += "'" & Emp_Regimen & "')"

        DattCom.SqlDatos.ejecutarComandoIniSis(ssql)
    End Sub

    Public Sub Actualizar(ByVal EmpCod As String)
        ssql += "update Emp_Datos set "
        ssql += " Emp_Nombre  ='" & Emp_Nombre & "',"
        ssql += " Emp_Pais  ='" & Emp_Pais & "',"
        ssql += " Emp_Provincia  ='" & Emp_Provincia & "',"
        ssql += " Emp_Ciudad  ='" & Emp_Ciudad & "',"
        ssql += " Emp_Cantón  ='" & Emp_Cantón & "',"
        ssql += " Emp_Dirección  ='" & Emp_Dirección & "',"
        ssql += " Emp_Telefono_1  ='" & Emp_Telefono_1 & "',"
        ssql += " Emp_Telefono_2  ='" & Emp_Telefono_2 & "',"
        ssql += " Emp_Fax  ='" & Emp_Fax & "',"
        ssql += " Emp_Casilla  ='" & Emp_Casilla & "',"
        ssql += " Emp_Email  ='" & Emp_Email & "',"
        ssql += " Emp_RUC  ='" & Emp_RUC & "',"
        ssql += " Emp_SegSocial  ='" & Emp_SegSocial & "',"
        ssql += " Emp_Presidente  ='" & Emp_Presidente & "',"
        ssql += " Emp_Gerente  ='" & Emp_Gerente & "',"
        ssql += " Emp_RepLegal  ='" & Emp_RepLegal & "',"
        ssql += " Emp_Contador  ='" & Emp_Contador & "',"
        ssql += " Emp_Logotipo  ='" & Emp_Logotipo & "',"
        If Emp_Defecto = True Then ssql += " Emp_Defecto  =1," Else ssql += " Emp_Defecto  =0,"
        ssql += " Emp_Lic1  ='" & Emp_Lic1 & "',"
        ssql += " Emp_Lic2  ='" & Emp_Lic2 & "',"
        ssql += " Emp_Lic3  ='" & Emp_Lic3 & "',"
        ssql += " Emp_PathImagenes  ='" & Emp_PathImagenes & "',"
        ssql += " Emp_Lic4  ='" & Emp_Lic4 & "',"
        ssql += " Emp_Lic5  ='" & Emp_Lic5 & "',"
        ssql += " Emp_Lic6  ='" & Emp_Lic6 & "',"
        ssql += " Emp_TipoBase  ='" & Emp_TipoBase & "',"

        If Emp_Conta Then ssql += " Emp_Conta = 1," Else ssql += " Emp_Conta = 0,"
        ssql += " Emp_AgeRet  ='" & Emp_AgeRet & "',"
        ssql += " Emp_ContrBuyEsp  ='" & Emp_ContrBuyEsp & "',"
        ssql += " Emp_Regimen  ='" & Emp_Regimen & "'"

        ssql += " Where Emp_codigo  =" & EmpCod
        DattCom.SqlDatos.ejecutarComandoIniSis(ssql)
    End Sub

    Public Sub Eliminar(ByVal EmpCod As String)
        ssql += " delete from Emp_Datos where  Emp_codigo  =" & EmpCod
        DattCom.SqlDatos.ejecutarComandoIniSis(ssql)
    End Sub
    Public Sub Consultar(ByVal empCod As String)
        Dim ssql As String = "select * from Emp_Datos where Emp_codigo  =" & empCod
        'Dim cmd As New SqlCommand(ssql, ConSys)
        Dim dat As SqlDataReader = DattCom.SqlDatos.leerBaseIniSis(ssql)
        'ConSys.Open()
        'dat = cmd.ExecuteReader()
        If dat.Read Then
            If Not IsDBNull(dat("Emp_Nombre")) Then Emp_Nombre = CStr(dat("Emp_Nombre"))
            If Not IsDBNull(dat("Emp_Pais")) Then Emp_Pais = CStr(dat("Emp_Pais"))
            If Not IsDBNull(dat("Emp_Provincia")) Then Emp_Provincia = CStr(dat("Emp_Provincia"))
            If Not IsDBNull(dat("Emp_Ciudad")) Then Emp_Ciudad = CStr(dat("Emp_Ciudad"))
            If Not IsDBNull(dat("Emp_Cantón")) Then Emp_Cantón = CStr(dat("Emp_Cantón"))
            If Not IsDBNull(dat("Emp_Dirección")) Then Emp_Dirección = CStr(dat("Emp_Dirección"))
            If Not IsDBNull(dat("Emp_Telefono_1")) Then Emp_Telefono_1 = CStr(dat("Emp_Telefono_1"))
            If Not IsDBNull(dat("Emp_Telefono_2")) Then Emp_Telefono_2 = CStr(dat("Emp_Telefono_2"))
            If Not IsDBNull(dat("Emp_Fax")) Then Emp_Fax = CStr(dat("Emp_Fax"))
            If Not IsDBNull(dat("Emp_Casilla")) Then Emp_Casilla = CStr(dat("Emp_Casilla"))
            If Not IsDBNull(dat("Emp_Email")) Then Emp_Email = CStr(dat("Emp_Email"))
            If Not IsDBNull(dat("Emp_RUC")) Then Emp_RUC = CStr(dat("Emp_RUC"))
            If Not IsDBNull(dat("Emp_SegSocial")) Then Emp_SegSocial = CStr(dat("Emp_SegSocial"))
            If Not IsDBNull(dat("Emp_Presidente")) Then Emp_Presidente = CStr(dat("Emp_Presidente"))
            If Not IsDBNull(dat("Emp_Gerente")) Then Emp_Gerente = CStr(dat("Emp_Gerente"))
            If Not IsDBNull(dat("Emp_RepLegal")) Then Emp_RepLegal = CStr(dat("Emp_RepLegal"))
            If Not IsDBNull(dat("Emp_Contador")) Then Emp_Contador = CStr(dat("Emp_Contador"))
            If Not IsDBNull(dat("Emp_Logotipo")) Then Emp_Logotipo = CStr(dat("Emp_Logotipo"))
            If Not IsDBNull(dat("Emp_Defecto")) Then Emp_Defecto = CBool(dat("Emp_Defecto"))
            If Not IsDBNull(dat("Emp_Lic1")) Then Emp_Lic1 = CStr(dat("Emp_Lic1"))
            If Not IsDBNull(dat("Emp_Lic2")) Then Emp_Lic2 = CStr(dat("Emp_Lic2"))
            If Not IsDBNull(dat("Emp_Lic3")) Then Emp_Lic3 = CStr(dat("Emp_Lic3"))
            If Not IsDBNull(dat("Emp_PathImagenes")) Then Emp_PathImagenes = CStr(dat("Emp_PathImagenes"))
            If Not IsDBNull(dat("Emp_Lic4")) Then Emp_Lic4 = CStr(dat("Emp_Lic4"))
            If Not IsDBNull(dat("Emp_Lic5")) Then Emp_Lic5 = CStr(dat("Emp_Lic5"))
            If Not IsDBNull(dat("Emp_Lic6")) Then Emp_Lic6 = CStr(dat("Emp_Lic6"))
            If Not IsDBNull(dat("Emp_TipoBase")) Then Emp_TipoBase = CStr(dat("Emp_TipoBase"))
            If Not IsDBNull(dat("Emp_Conta")) Then Emp_Conta = CBool(dat("Emp_Conta"))
            If Not IsDBNull(dat("Emp_AgeRet")) Then Emp_AgeRet = CStr(dat("Emp_AgeRet"))
            If Not IsDBNull(dat("Emp_ContrBuyEsp")) Then Emp_ContrBuyEsp = CStr(dat("Emp_ContrBuyEsp"))
            If Not IsDBNull(dat("Emp_Regimen")) Then Emp_Regimen = CStr(dat("Emp_Regimen"))
        End If
        'ConSys.Close()
    End Sub
End Class
