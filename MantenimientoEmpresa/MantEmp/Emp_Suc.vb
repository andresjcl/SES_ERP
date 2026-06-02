Imports System.Data.SqlClient
Public Class Emp_Suc
    Public Emp_Codigo As Integer = 0
    Public Suc_Codigo As String = ""
    Public Suc_Nombre As String = ""
    Public Suc_Direccion As String = ""
    Public Suc_RUC As String = ""
    Public Suc_SegSocial As String = ""
    Public Suc_IdCta As String = ""
    Public Bod_Codigo As String = ""
    Public precioVta As Double = 0
    Public Suc_IdTributario As String = ""
    Dim ssql As String = ""

    Public Sub Guardar()
        ssql = "Insert into Emp_Suc ("
        ssql += "Emp_Codigo ,"
        ssql += "Suc_Codigo ,"
        ssql += "Suc_Nombre ,"
        ssql += "Suc_Direccion ,"
        ssql += "Suc_RUC ,"
        ssql += "Suc_SegSocial ,"
        ssql += "Suc_IdCta ,"
        ssql += "Bod_Codigo ,"
        ssql += "precioVta ,"
        ssql += "Suc_IdTributario )"
        ssql += " values ("
        ssql += " " & Emp_Codigo & ","
        ssql += "'" & Suc_Codigo & "',"
        ssql += "'" & Suc_Nombre & "',"
        ssql += "'" & Suc_Direccion & "',"
        ssql += "'" & Suc_RUC & "',"
        ssql += "'" & Suc_SegSocial & "',"
        ssql += "'" & Suc_IdCta & "',"
        ssql += "'" & Bod_Codigo & "',"
        ssql += "'" & precioVta & "',"
        ssql += "'" & Suc_IdTributario & "')"
        DattCom.SqlDatos.ejecutarComandoIniSis(ssql)
    End Sub
    Public Sub Actualizar(ByVal emp As Integer, ByVal suc As String)
        ssql = "update Emp_Suc set "
        ssql += "Suc_Nombre ='" & Suc_Nombre & "',"
        ssql += "Suc_Direccion ='" & Suc_Direccion & "',"
        ssql += "Suc_RUC ='" & Suc_RUC & "',"
        ssql += "Suc_SegSocial ='" & Suc_SegSocial & "',"
        ssql += "Suc_IdCta ='" & Suc_IdCta & "',"
        ssql += "Bod_Codigo ='" & Bod_Codigo & "',"
        ssql += "precioVta ='" & precioVta & "',"
        ssql += "Suc_IdTributario ='" & Suc_IdTributario & "'"
        ssql += " where Emp_Codigo=" & emp & " and Suc_Codigo='" & suc & "'"
        DattCom.SqlDatos.ejecutarComandoIniSis(ssql)
    End Sub
    Public Sub Eliminar(ByVal emp As Integer, ByVal suc As String)
        ssql = "delete from Emp_Suc where Emp_Codigo=" & emp & " and Suc_Codigo='" & suc & "'"
        DattCom.SqlDatos.ejecutarComandoIniSis(ssql)
    End Sub
    Public Sub Consultar(ByVal emp As Integer, ByVal suc As String)
        ssql = "select * from Emp_Suc where Emp_Codigo=" & emp & " and Suc_Codigo='" & suc & "'"
        'Dim cmd As New SqlCommand(ssql, ConSys)
        Dim dat As SqlDataReader = DattCom.SqlDatos.leerBaseIniSis(ssql)
        'ConSys.Open()
        'dat = cmd.ExecuteReader()
        If dat.Read Then
            If Not IsDBNull(dat("Emp_Codigo")) Then Emp_Codigo = CInt(dat("Emp_Codigo"))
            If Not IsDBNull(dat("Suc_Codigo")) Then Suc_Codigo = CStr(dat("Suc_Codigo"))
            If Not IsDBNull(dat("Suc_Nombre")) Then Suc_Nombre = CStr(dat("Suc_Nombre"))
            If Not IsDBNull(dat("Suc_Direccion")) Then Suc_Direccion = CStr(dat("Suc_Direccion"))
            If Not IsDBNull(dat("Suc_RUC")) Then Suc_RUC = CStr(dat("Suc_RUC"))
            If Not IsDBNull(dat("Suc_SegSocial")) Then Suc_SegSocial = CStr(dat("Suc_SegSocial"))
            If Not IsDBNull(dat("Suc_IdCta")) Then Suc_IdCta = CStr(dat("Suc_IdCta"))
            If Not IsDBNull(dat("Bod_Codigo")) Then Bod_Codigo = CStr(dat("Bod_Codigo"))
            If Not IsDBNull(dat("precioVta")) Then precioVta = CDbl(dat("preciovta"))
            If Not IsDBNull(dat("Suc_IdTributario")) Then Suc_IdTributario = CStr(dat("Suc_IdTributario"))
        End If
        'ConSys.Close()
    End Sub
End Class
