Imports System.Data.SqlClient
Module ModuloInventarios
    Public conectar As New SqlConnection()
    Public conectarSys As New SqlConnection()
    Public SYSEMP As New AdcDax.DaxSofSys
    Public strConxDaxsys As String = ""
    'Public EMP As AdcDax.Empresa = SYSEMP.EmpresaAct
    Dim strcon As String = ""

    Public Sub conectarBDD()
        If SYSEMP.EmpresaAct.codigo = 0 Or SYSEMP.EmpresaAct Is Nothing Then End
        Dim coneccion As New DaxLib.DaxLibBases
        coneccion.TipoBase = "10"
        strConxDaxsys = coneccion.StrAdcom
        conectar.ConnectionString = strConxDaxsys
        strcon = coneccion.StrAdcom
        conectarSys.ConnectionString = coneccion.StrDaxsys
    End Sub
    Public Sub cerrarConeccion(ByVal con As SqlConnection)
        If con.State = ConnectionState.Open Then con.Close()
    End Sub
    Public Function ConsultaArt() As String
        Dim art As String = ""
        Dim bus As New Buscar.frmBuscar
        art = bus.Buscar(strcon, "select Art_Codigo, Art_nombre, Art_unimed   from adcart ", "art_Codigo", "art_nombre", "Consulta", "Buscar Articulo")
        Return art
    End Function
End Module
