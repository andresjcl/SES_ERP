Imports System.Data.SqlClient
Public Class Emp_ptoVta

    Public Emp_Codigo As String = ""
    Public Suc_Codigo As String = ""
    Public Pto_codigo As String = ""
    Public Pto_nombre As String = ""
    Public Pto_IDTributario As String = ""
    Public Pto_IdCta As String = ""
    Public TipoPunto As String = ""
    Dim ssql As String = ""

    Public Sub Guardar()
        ssql = "insert into Emp_ptoVta ("
        ssql += " Emp_Codigo,"
        ssql += " Suc_Codigo,"
        ssql += " Pto_codigo,"
        ssql += " Pto_nombre,"
        ssql += " Pto_IDTributario,"
        ssql += " TipoPunto,"
        ssql += " Pto_IdCta)"
        ssql += " values("
        ssql += " " & Emp_Codigo & " ,"
        ssql += "'" & Suc_Codigo & "',"
        ssql += "'" & Pto_codigo & "',"
        ssql += "'" & Pto_nombre & "',"
        ssql += "'" & Pto_IDTributario & "',"
        ssql += "'" & TipoPunto & "',"
        ssql += "'" & Pto_IdCta & "')"
        DattCom.SqlDatos.ejecutarComandoIniSis(ssql)
    End Sub

    Public Sub Actualizar(ByVal emp As String, ByVal suc As String, ByVal pto As String)
        ssql = "update emp_ptovta set "
        ssql += "Pto_nombre ='" & Pto_nombre & "',"
        ssql += "Pto_IDTributario ='" & Pto_IDTributario & "',"
        ssql += "Pto_IdCta ='" & Pto_IdCta & "',"
        ssql += "TipoPunto ='" & TipoPunto & "',"
        ssql += " where Emp_Codigo ='" & emp & "' and Suc_Codigo ='" & suc & "' and Pto_codigo ='" & pto & "'"
        DattCom.SqlDatos.ejecutarComandoIniSis(ssql)
    End Sub
    Public Sub Eliminar(ByVal emp As String, ByVal suc As String, ByVal pto As String)
        ssql = "delete from emp_ptovta  where Emp_Codigo ='" & emp & "' and Suc_Codigo ='" & suc & "'"
        If pto <> "" Then ssql += " and Pto_codigo ='" & pto & "'"
        DattCom.SqlDatos.ejecutarComandoIniSis(ssql)
    End Sub
    Public Sub Consultar(ByVal emp As String, ByVal suc As String, ByVal pto As String)
        ssql = " select * from emp_ptovta where Emp_Codigo =" & emp & " and Suc_Codigo ='" & suc & "' and Pto_codigo ='" & pto & "'"
        'Dim cmd As New SqlCommand(ssql, ConSys)
        Dim dat As SqlDataReader = DattCom.SqlDatos.leerBaseIniSis(ssql)
        'ConSys.Open()
        'dat = cmd.ExecuteReader()
        If dat.Read Then
            If Not IsDBNull(dat("Emp_Codigo")) Then Emp_Codigo = CStr(dat("Emp_Codigo"))
            If Not IsDBNull(dat("Suc_Codigo")) Then Suc_Codigo = CStr(dat("Suc_Codigo"))
            If Not IsDBNull(dat("Pto_codigo")) Then Pto_codigo = CStr(dat("Pto_codigo"))
            If Not IsDBNull(dat("Pto_nombre")) Then Pto_nombre = CStr(dat("Pto_nombre"))
            If Not IsDBNull(dat("Pto_IDTributario")) Then Pto_IDTributario = CStr(dat("Pto_IDTributario"))
            If Not IsDBNull(dat("TipoPunto")) Then TipoPunto = CStr(dat("TipoPunto"))

        End If
        'ConSys.Close()
    End Sub
End Class
