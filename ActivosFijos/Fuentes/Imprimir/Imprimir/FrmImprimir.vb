Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Public Class FrmImprimir
    Dim conectarBDD As New SqlConnection()
    Public cad, titulo, titRep As String
    Private Sub FrmImprimir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim rds As New ReportDataSource()
        rds.Name = "DataSet1"
        rds.Value = CalcularDataSet(cad).Tables(0)
        ReportViewer1.Visible = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewer1.LocalReport.ReportPath = "\\DAXSERVER\Sistemas\DesarrolloNet\Imprimir\Imprimir\" & titulo & ".rdlc"
        If titulo = "REP003" Then
            Dim nombre As New ReportParameter("Titulo", titRep)
            ReportViewer1.LocalReport.SetParameters(nombre)
        End If
        Me.ReportViewer1.RefreshReport()
    End Sub
    Private Function CalcularDataSet(ByVal cadena As String) As DataSet
        Dim coneccion As New DaxLib.DaxLibBases
        coneccion.TipoBase = "10"
        conectarBDD.ConnectionString = coneccion.StrAdcom
        Dim ssql As String = cadena
        Dim sqlAdap As New SqlDataAdapter(ssql, conectarBDD)
        conectarBDD.Open()
        Dim datS As New DataSet()
        sqlAdap.Fill(datS, "Activos")
        conectarBDD.Close()
        Return datS
    End Function
    Public Sub Impresion(ByVal cadena As String, ByVal tit As String, ByVal titR As String)
        Me.titulo = tit
        Me.titRep = titR
        Me.cad = cadena
        Me.Show()
    End Sub
End Class
