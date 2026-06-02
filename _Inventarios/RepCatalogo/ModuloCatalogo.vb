Imports System.Data.SqlClient
Module ModuloCatalogo
    Public Function ConsultaArt() As String
        Dim art As String = ""
        Dim bus As New Buscar.frmBuscar
        art = bus.Buscar(SysEmpDatt.datosEmpresa.strConxAdcom, "select Art_Codigo, Art_nombre, Art_unimed   from adcart ", "art_Codigo", "art_nombre", "Consulta", "Buscar Articulo")
        Return art
    End Function
End Module
