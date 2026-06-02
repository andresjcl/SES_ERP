Imports System.Data.SqlClient
Module ModTransInv
    Public conectar As New SqlConnection()
    Public conectarSys As New SqlConnection()
    Public strConxDaxsys As String = ""
    Dim strcon As String = ""

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
