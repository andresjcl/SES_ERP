Imports System.Data.SqlClient
Imports DattCom


Public Class Niveles
    Public Tabla As String = ""
    Public Niv_Categoria As String = ""
    Public Niv_nombre As String = ""
    Public Niv_abrevia As String = ""
    Public Niv_IdCta As String = ""
    Public Niv_IdCta2 As String = ""
    Public Niv_IdCta3 As String = ""
    Public Niv_Grafico As String = ""
    Public Niv_Destino As String = ""
    Public Nandina As String = ""
    Public HTS As String = ""
    Dim ssql As String = ""
    Public Sub guardar()
        ssql = "insert into " & Tabla & "("
        ssql += " Niv_categor ,"
        ssql += " Niv_nombre ,"
        ssql += " Niv_abrevia ,"
        ssql += " Niv_IdCta ,"
        ssql += " Niv_IdCta2 ,"
        ssql += " Niv_IdCta3 ,"
        ssql += " Nandina ,"
        ssql += " HTS ,"
        ssql += " Niv_grafico )"
        ssql += " values ("
        ssql += " '" & Niv_Categoria & "',"
        ssql += " '" & Niv_nombre & "',"
        ssql += " '" & Niv_abrevia & "',"
        ssql += " '" & Niv_IdCta & "',"
        ssql += " '" & Niv_IdCta2 & "',"
        ssql += " '" & Niv_IdCta3 & "',"
        ssql += " '" & Nandina & "',"
        ssql += " '" & HTS & "',"
        ssql += " '" & Niv_Grafico & "')"
        EjecutarComandos(ssql)
    End Sub
    Public Sub actualizar(ByVal categor As String, ByVal abrevia As String, ByVal dest As String)
        ssql = "update " & Tabla & " set"
        ssql += "  Niv_categor = '" & Niv_Categoria & "',"
        ssql += "  Niv_nombre = '" & Niv_nombre & "',"
        ssql += "  Niv_IdCta = '" & Niv_IdCta & "',"
        ssql += "  Niv_IdCta2 = '" & Niv_IdCta2 & "',"
        ssql += "  Niv_IdCta3 = '" & Niv_IdCta3 & "',"
        ssql += "  Nandina = '" & Nandina & "',"
        ssql += "  HTS = '" & HTS & "',"
        ssql += "  Niv_Grafico = '" & Niv_Grafico & "'"
        ssql += " where Niv_Categoria = '" & categor & "' "
        If abrevia <> "" Then ssql += " and Niv_abrevia = '" & abrevia & "'"
        EjecutarComandos(ssql)
    End Sub
    Public Sub eliminar(ByVal categor As String, ByVal abrevia As String, ByVal dest As String)
        ssql = "delete from " & Tabla
        ssql += " where Niv_categor = '" & categor & "'"
        If abrevia <> "" Then ssql += " and Niv_abrevia = '" & abrevia & "'"
        EjecutarComandos(ssql)
    End Sub
    Private Sub EjecutarComandos(ssql As String)
        Dim conectar As New SqlConnection(datosEmpresa.strConxAdcom)
        conectar.Open()
        Dim comm = New SqlCommand(ssql, conectar)
        comm.ExecuteNonQuery()
        conectar.Close()
        comm.Dispose()
        conectar.Dispose()
    End Sub
End Class
