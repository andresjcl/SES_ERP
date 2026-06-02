Imports System.Data.SqlClient
Public Class Emp_Bod

    Public Emp_Codigo As Integer = 0
    Public Suc_Codigo As String = ""
    Public Bod_codigo As String = ""
    Public Bod_nombre As String = ""
    Public Bod_IdCta As String = ""
    Dim ssql As String

    Public Sub Guardar()
        ssql = "insert into Emp_Bod ("
        ssql += "Emp_Codigo ,"
        ssql += "Suc_Codigo ,"
        ssql += "Bod_codigo ,"
        ssql += "Bod_nombre ,"
        ssql += "Bod_IdCta )"
        ssql += " values("
        ssql += " " & Emp_Codigo & " ,"
        ssql += "'" & Suc_Codigo & "',"
        ssql += "'" & Bod_codigo & "',"
        ssql += "'" & Bod_nombre & "',"
        ssql += "'" & Bod_IdCta & "')"
        DattCom.SqlDatos.ejecutarComandoIniSis(ssql)
    End Sub

    Public Sub Actualizar(ByVal emp As String, ByVal suc As String, ByVal bod As String)
        ssql = "update emp_Bod set"
        ssql += " Bod_nombre ='" & Bod_nombre & "',"
        ssql += " Bod_IdCta ='" & Bod_IdCta & "'"
        ssql += " where Emp_Codigo =" & emp & " and Suc_Codigo ='" & suc & "' and Bod_codigo ='" & bod & "'"
        DattCom.SqlDatos.ejecutarComandoIniSis(ssql)
    End Sub
    Public Sub Eliminar(ByVal emp As String, ByVal suc As String, ByVal bod As String)
        ssql = "delete from emp_Bod where Emp_Codigo =" & emp & " and Suc_Codigo ='" & suc & "'"
        If bod <> "" Then ssql += " and Bod_codigo ='" & bod & "'"
        DattCom.SqlDatos.ejecutarComandoIniSis(ssql)
    End Sub
    Public Sub Consultar(ByVal emp As String, ByVal suc As String, ByVal bod As String)
        ssql = " select * from emp_Bod where Emp_Codigo =" & emp & " and Suc_Codigo ='" & suc & "' and Bod_codigo ='" & bod & "'"
        'Dim cmd As New SqlCommand(ssql, ConSys)
        Dim dat As SqlDataReader = DattCom.SqlDatos.leerBaseIniSis(ssql)
        'ConSys.Open()
        'dat = cmd.ExecuteReader()
        If dat.Read Then
            If Not IsDBNull(dat("Emp_Codigo")) Then Emp_Codigo = CInt(dat("Emp_Codigo"))
            If Not IsDBNull(dat("Suc_Codigo")) Then Suc_Codigo = CStr(dat("Suc_Codigo"))
            If Not IsDBNull(dat("Bod_codigo")) Then Bod_codigo = CStr(dat("Bod_codigo"))
            If Not IsDBNull(dat("Bod_nombre")) Then Bod_nombre = CStr(dat("Bod_nombre"))
            If Not IsDBNull(dat("Bod_IdCta")) Then Bod_IdCta = CStr(dat("Bod_IdCta"))
        End If
        'ConSys.Close()
    End Sub
End Class
