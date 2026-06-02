Imports System.Data.SqlClient
Module ModuloResumen
    Public Function ConsultaArt() As String
        Dim art As String = ""
        Dim bus As New Buscar.frmBuscar
        art = bus.Buscar(DattCom.datosEmpresa.strConxAdcom, "select Art_Codigo, Art_nombre, Art_unimed   from adcart ", "art_Codigo", "art_nombre", "Consulta", "Buscar Articulo")
        Return art
    End Function
End Module
