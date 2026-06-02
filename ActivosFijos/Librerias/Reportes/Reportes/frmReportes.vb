Imports System.Data.SqlClient

Public Class frmReportes
    Dim conectarBDD As New SqlConnection()
    Public cad, tit As String
    '***********************************************************BOTÓN SALIR********************************************************************
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Dispose()
        gridDatos.ClearSelection()
    End Sub
    '*********************************************************CARGAR LA MALLA***********************************************************************
    Public Sub CargarMalla(ByVal cadena As String)
        cad = cadena
        Dim coneccion As New DaxLib.DaxLibBases
        coneccion.TipoBase = "10"
        conectarBDD.ConnectionString = coneccion.StrAdcom
        Dim cmd As New SqlCommand()
        Dim bnd As New BindingSource()
        Dim datS As New DataSet()
        Dim datAd As New SqlDataAdapter(cadena, conectarBDD)
        datAd.Fill(datS, "Reporte")
        bnd.DataSource = datS
        bnd.DataMember = "Reporte"
        gridDatos.DataSource = bnd
        gridDatos.ClearSelection()
        Me.ShowDialog()
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Dim imp As New Imprimir.FrmImprimir
        imp.Impresion(cad, tit, tit)
    End Sub
End Class
