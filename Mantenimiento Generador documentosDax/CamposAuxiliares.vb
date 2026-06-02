Imports System.Data.SqlClient
Imports System.Data

Public Class CamposAuxiliares
    Dim ssql As String = ""
    Public Abreviación As String = ""
    Public Descripción As String = ""
    Public TipoDato As String = ""
    Public Longitud As Long = 0
    Public Decimales As Long = 0
    Public Origen As String = ""
    Public CampoAsignado As String = ""
    Public conectar As New SqlConnection()

    Public Sub Guardar()
        ssql = "Insert into CamposAuxiliares( "
        ssql += "Abreviación,"
        ssql += "Descripción,"
        ssql += "TipoDato,"
        ssql += "Longitud,"
        ssql += "Decimales,"
        ssql += "Origen,"
        ssql += "CampoAsignado) "
        ssql += "Values ( "
        ssql += "'" & Abreviación & "',"
        ssql += "'" & Descripción & "',"
        ssql += "'" & TipoDato & "',"
        ssql += " " & Longitud & ","
        ssql += " " & Decimales & ","
        ssql += "'" & Origen & "',"
        ssql += "'" & CampoAsignado & "')"
        EjecutarComnados(ssql)
    End Sub
    Public Sub Actualizar(ByVal cod As String)
        ssql = "Update CamposAuxiliares set "
        ssql += "Descripción='" & Descripción & "',"
        ssql += "TipoDato='" & TipoDato & "',"
        ssql += "Longitud=" & Longitud & ","
        ssql += "Decimales=" & Decimales & ","
        ssql += "Origen='" & Origen & "',"
        ssql += "CampoAsignado='" & CampoAsignado & "' "
        ssql += "where Abreviación='" & cod & "'"
    End Sub
    Public Sub Eliminar(ByVal cod As String)
        ssql = "Delete from CamposAuxiliares"
        ssql += "where Abreviación='" & cod & "'"
    End Sub
    Private Sub EjecutarComnados(ByVal comando As String)
        Dim cmd As New SqlCommand(comando, conectar)
        If conectar.State = ConnectionState.Open Then conectar.Close()
        conectar.Open()
        cmd.ExecuteNonQuery()
    End Sub
End Class
