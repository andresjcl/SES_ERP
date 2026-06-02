Imports System.Data.SqlClient
Imports DattCom

Public Class emp_Arch
    Public Emp_Codigo As Integer = 0
    Public Arch_Tipo As String = ""
    Public Arch_Nom As String = ""
    Dim ssql As String = ""

    Public Sub Guardar()
        ssql = "insert into emp_Arch ("
        ssql += "Emp_Codigo,"
        ssql += "Arch_Tipo,"
        ssql += "Arch_Nom)"
        ssql += " values ("
        ssql += "'" & Emp_Codigo & "',"
        ssql += "'" & Arch_Tipo & "',"
        ssql += "'" & Arch_Nom & "')"
        DattCom.SqlDatos.ejecutarComandoIniSis(ssql)
    End Sub
    Public Sub Actualizar(ByVal EmpCod As String)
        ssql = " update emp_Arch set "
        ssql += "Arch_Nom ='" & Arch_Nom & "'"
        ssql += " where Emp_Codigo =" & EmpCod & "and Arch_Tipo ='" & Arch_Tipo & "'"
        SqlDatos.ejecutarComandoIniSis(ssql)
    End Sub
    Public Sub eliminar(ByVal EmpCod As String)
        ssql = "delete from emp_Arch Emp_Codigo =" & EmpCod
        SqlDatos.ejecutarComandoIniSis(ssql)
    End Sub
    Public Function Consultar(ByVal empCodigo As String, ByVal tipo As String) As String
        Dim nom As String = ""
        ssql = "select Arch_Nom from Emp_Arch where Emp_Codigo=" & empCodigo & " and Arch_Tipo ='" & tipo & "'"
        'Dim cmd As New SqlCommand(ssql, ConSys)
        Dim dat As SqlDataReader = DattCom.SqlDatos.leerBaseIniSis(ssql)
        'ConSys.Open()
        'dat = cmd.ExecuteReader()
        If dat.Read Then
            If Not IsDBNull(dat(0)) Then nom = CStr(dat(0))
        End If
        'ConSys.Close()
        Return nom
    End Function
End Class
