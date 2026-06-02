Imports System.Data.SqlClient

Module ModuloLstDoc
    Friend conectar As New SqlConnection()
    Friend conectarSys As New SqlConnection()
    Friend SYSEMP As New AdcDax.DaxSofSys
    Friend EMP As AdcDax.Empresa
    Friend strcon As String = ""
    Friend strsys As String = ""
    Friend usr As New DaxUsr.DaxsofUsr
    Friend Sub conectarBDD()
        Dim coneccion As New DaxLib.DaxLibBases
        'SYSEMP = AdcDax.DaxSofSys
        EMP = SYSEMP.EmpresaAct
        If EMP.CODIGO = 0 Then MsgBox("No se ha conectado al servidor AdcomDx", MsgBoxStyle.Critical) : End
        coneccion.TipoBase = "10"
        conectar.ConnectionString = coneccion.StrAdcom
        strcon = coneccion.StrAdcom
        conectarSys.ConnectionString = coneccion.StrDaxsys
        strsys = coneccion.StrDaxsys
    End Sub
End Module
