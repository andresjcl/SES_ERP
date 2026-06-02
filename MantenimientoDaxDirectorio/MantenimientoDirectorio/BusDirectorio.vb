Option Strict Off
Option Explicit On
Public Class BusDirectorio

    Public Function BusDirect(ByRef codigo As String, ByRef CEDULA As String, ByRef Nombre As String, ByRef NombreAlias As String, Optional ByRef Tipo As String = "", Optional ByRef ConNuevo As String = "") As String
        Dim ElCodigo As String = ""
        Mainn()
        Try
            Dim PROG As New BuscaClien
            ElCodigo = PROG.IniBuscaCliOPro(Tipo, Nombre, NombreAlias, ConNuevo)
            PROG.Dispose()
        Catch ee As Exception
            MsgBox("excepción busDirect: " & ee.Message)
        End Try
        Return ElCodigo
    End Function
    Public Function BusDirect(codigo As String, CEDULA As String, ByRef Nombre As String, NombreAlias As String, Optional Tipo As String = "", Optional ConNuevo As String = "", Optional neutro As String = "") As String
        Dim ElCodigo As String = ""
        Mainn()
        Try
            Dim PROG As New BuscaClien
            ElCodigo = PROG.IniBuscaCliOPro(Tipo, Nombre, NombreAlias, ConNuevo)
            PROG.Dispose()
        Catch ee As Exception
            MsgBox("excepción busDirect: " & ee.Message)
        End Try
        Return ElCodigo
    End Function
    Public Function BusDirect(codigo As String, cedula As String, nombre As String, nomAlias As String) As String
        Dim ElCodigo As String = ""
        Mainn()
        Try
            Dim PROG As New BuscaClien
            ElCodigo = PROG.IniBuscaCliOPro("", nombre, nomAlias, "")
            PROG.Dispose()
        Catch ee As Exception
            MsgBox("excepción busDirect: " & ee.Message)
        End Try
        Return ElCodigo
    End Function


    Public Sub ManDir(ByRef ConCodigo As String)
        Mainn()
        'Try
        'Dim ConxAdcomNet As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
        'ConxAdcomNet.Open()
        'Dim rs As SqlClient.SqlDataReader
        'Dim comm As New SqlClient.SqlCommand("select top 1 codigo from identificacion", ConxAdcomNet)
        'rs = comm.ExecuteReader
        'If rs.Read = False Then MsgBox("Esta version del ADCOMDX no admite mantenimiento del DIRECTORIO") : Exit Sub
        'rs.Close()
        'comm.Dispose()
        'ConxAdcomNet.Dispose()
        Dim PROG As New DEEP01
        '            PROG.Autorizacion = datosEmpresa.auto
        If ConCodigo = "&&" Then
            PROG.QUECODIGO = ""
            PROG.IniciaNuevo()
        Else
            PROG.QUECODIGO = ConCodigo
            PROG.Show()
        End If
        'PROG.Close()
        'PROG.Dispose()
        'Catch ee As Exception
        'MsgBox("excepción manDir: " & ee.Message)
        'End Try
    End Sub

End Class

