Imports System.Data.SqlClient

Public Class Novedades
    Public conectar As New SqlConnection()
    Public Doc_sucursal As String = ""
    Public Opc_documento As String = ""
    Public Doc_numero As Long = 0
    Public Codigo As String = ""
    Public FechaDocumento As Date = "0:0"
    Public FechaNovedad As Date = "0:0"
    Public TipoNovedad As String = ""
    Public NVvalorresidual As Double = 0.0
    Public NVvidautil As Double = 0.0
    Public NVdeterioro As Double = 0.0
    Public NVrevalorizacion As Double = 0.0
    Public NVvalorproduccionmes As Double = 0.0
    Public NVSucursalNueva As String = ""
    Public NvDepartamentoNvo As String = ""
    Public NvSeccionNvo As String = ""
    Public NvResponsable As String = ""
    Public Observaciones As String = ""
    Public FechaProduccion As Date = "0:0"

    Dim ssql As String = ""
    Dim cmd As New SqlCommand()
    Public Sub Guardar()
        ssql = "Insert into AdcAcfNov( "
        ssql += "Doc_sucursal,"
        ssql += "Opc_documento,"
        ssql += "Doc_numero,"
        ssql += "Codigo,"
        ssql += "FechaDocumento,"
        ssql += "FechaNovedad,"
        ssql += "TipoNovedad,"
        ssql += "NVvalorresidual,"
        ssql += "NVvidautil,"
        ssql += "NVdeterioro,"
        ssql += "NVrevalorizacion,"
        ssql += "NVvalorproduccionmes,"
        ssql += "NVSucursalNueva,"
        ssql += "NvDepartamentoNvo,"
        ssql += "NvSeccionNvo,"
        ssql += "NvResponsable,"
        ssql += "Observaciones,"
        ssql += "FechaProduccion)"
        ssql += " values("
        ssql += "'" & Doc_sucursal & "',"
        ssql += "'" & Opc_documento & "',"
        ssql += "'" & Doc_numero & "',"
        ssql += "'" & Codigo & "',"
        ssql += "'" & FechaDocumento & "',"
        ssql += "'" & FechaNovedad & "',"
        ssql += "'" & TipoNovedad & "',"
        ssql += "'" & NVvalorresidual & "',"
        ssql += "'" & NVvidautil & "',"
        ssql += "'" & NVdeterioro & "',"
        ssql += "'" & NVrevalorizacion & "',"
        ssql += "'" & NVvalorproduccionmes & "',"
        ssql += "'" & NVSucursalNueva & "',"
        ssql += "'" & NvDepartamentoNvo & "',"
        ssql += "'" & NvSeccionNvo & "',"
        ssql += "'" & NvResponsable & "',"
        ssql += "'" & Observaciones & "',"
        ssql += "'" & FechaProduccion & "')"
        EjecutarComando(ssql)
    End Sub
    Public Sub Actualizar(ByVal Cod As String)
        ssql = "Update AdcAcfNov set "
        ssql += "Doc_sucursal='" & Doc_sucursal & "',"
        ssql += "Opc_documento='" & Opc_documento & "',"
        ssql += "FechaDocumento='" & FechaDocumento & "',"
        ssql += "FechaNovedad='" & FechaNovedad & "',"
        ssql += "TipoNovedad='" & TipoNovedad & "',"
        ssql += "NVvalorresidual='" & NVvalorresidual & "',"
        ssql += "NVvidautil='" & NVvidautil & "',"
        ssql += "NVdeterioro='" & NVdeterioro & "',"
        ssql += "NVrevalorizacion='" & NVrevalorizacion & "',"
        ssql += "NVvalorproduccionmes='" & NVvalorproduccionmes & "',"
        ssql += "NVSucursalNueva='" & NVSucursalNueva & "',"
        ssql += "NvDepartamentoNvo='" & NvDepartamentoNvo & "',"
        ssql += "NvSeccionNvo='" & NvSeccionNvo & "',"
        ssql += "NvResponsable='" & NvResponsable & "',"
        ssql += "Observaciones='" & Observaciones & "',"
        ssql += "FechaProduccion='" & FechaProduccion & "'"
        If Cod <> "" Then ssql += " where codigo='" & Cod & "' and and Opc_documento='" & Opc_documento & "' and Doc_numero='" & Doc_numero & "'"
        EjecutarComando(ssql)
    End Sub
    Public Sub Eliminar(ByVal cod As String)
        ssql = "delete from adcacfNov"
        If cod <> "" Then ssql += " where Codigo='" & cod & "' and Opc_documento='" & Opc_documento & "' Doc_numero=" & Doc_numero & "' and TipoNovedad='MOV_ACT'"
        EjecutarComando(ssql)
    End Sub
    Private Sub EjecutarComando(ByVal comando As String)
        cmd.Connection = conectar
        cmd.CommandText = comando
        If conectar.State = ConnectionState.Open Then conectar.Close()
        conectar.Open()
        cmd.ExecuteNonQuery()
        conectar.Close()
    End Sub
End Class
