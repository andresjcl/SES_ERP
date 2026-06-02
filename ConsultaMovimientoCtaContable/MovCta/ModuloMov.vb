Imports System.Data.SqlClient
Module ModuloMov
    Public conectar As New SqlConnection()
    Public conectarSys As New SqlConnection()
    Public SYSEMP As New AdcDaxx.DaxSofSys
    Public EMP As AdcDaxx.Empresa
    Public CodigoEntrada As String
    Public fechaIni As Date
    Public fechaFin As Date
    Dim strcon As String = ""

    Public Sub conectarBDD()
        'Dim coneccion As New daaxLib.DaxLibBases()
        'If EMP.CODIGO = 0 Then MsgBox("No se ha conectado al servidor AdcomDx", MsgBoxStyle.Critical) : Exit Sub
        If conectar.State = ConnectionState.Closed Then
            'coneccion.TipoBase = "10"
            conectar.ConnectionString = varbleComun.VarCom.strConxAdcom ' coneccion.StrAdcom
            strcon = varbleComun.VarCom.strConxAdcom 'coneccion.StrAdcom
            conectarSys.ConnectionString = varbleComun.VarCom.strConxAdcom 'coneccion.StrDaxsys
        End If
    End Sub
    Public Sub cerrarConeccion()
        If conectar.State = ConnectionState.Open Then conectar.Close()
    End Sub
    Public Sub EjecutarComnados(ByVal comando As String)
        Dim cmd As New SqlCommand(comando, conectar)
        cerrarConeccion()
        conectar.Open()
        cmd.ExecuteNonQuery()
        conectar.Close()
    End Sub
End Module
