Imports System.Data.SqlClient

Module ModuleAnlCta
    Public conectar As New SqlConnection()
    Public conectarSys As New SqlConnection()
    Public SYSEMP As New AdcDaxx.DaxSofSys()
    Public EMP As AdcDaxx.Empresa
    Dim strcon As String = ""
    Public usr As New DaxUsr.DaxsofUsr
    Public Sub conectarBDD()
        On Error Resume Next
        EMP = SYSEMP.EmpresaAct
        Dim coneccion As New daaxLib.DaxLibBases
        If EMP.CODIGO = 0 Then MsgBox("No se ha conectado al servidor AdcomDx", MsgBoxStyle.Critical) : End
        coneccion.TipoBase = "10"
        conectar.ConnectionString = coneccion.StrAdcom
        strcon = coneccion.StrAdcom
        conectarSys.ConnectionString = coneccion.StrDaxsys
        coneccion = Nothing
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
