Imports System.Data.SqlClient

Public Class Conversion
    Public Cnv_DeMedida As String = ""
    Public Cnv_Amedida As String = ""
    Public Cnv_Multiplo As Double = 0.0
    Dim ssql As String = ""
    Dim conectaSys As New SqlConnection()
    Public Sub Guardar(ByVal strSysc As String)
        ssql = "insert into conversion("
        ssql += "Cnv_DeMedida ,"
        ssql += "Cnv_Amedida ,"
        ssql += "Cnv_Multiplo )"
        ssql += " values ( "
        ssql += "'" & Cnv_DeMedida & "',"
        ssql += "'" & Cnv_Amedida & "',"
        ssql += " " & Cnv_Multiplo & ")"
        EjecutarComandos(ssql, strSysc)
    End Sub
    Public Sub Actualizar(ByVal cod As String, ByVal strSysc As String)
        ssql = "update conversion set "
        ssql += "Cnv_Amedida ='" & Cnv_Amedida & "',"
        ssql += "Cnv_Multiplo ='" & Cnv_Multiplo & "'"
        ssql += " where Cnv_DeMedida ='" & cod & "'"
        EjecutarComandos(ssql, strSysc)
    End Sub
    Public Sub Eliminar(ByVal cod As String, ByVal strSysc As String)
        ssql = "delete from conversion"
        ssql += " where Cnv_DeMedida ='" & cod & "'"
        EjecutarComandos(ssql, strSysc)
    End Sub
    Private Sub EjecutarComandos(ByVal sql As String, ByVal strSys As String)
        conectaSys.ConnectionString = strSys
        Dim cmd As New SqlCommand(sql, conectaSys)
        conectaSys.Open()
        cmd.ExecuteNonQuery()
        conectaSys.Close()
    End Sub
End Class
