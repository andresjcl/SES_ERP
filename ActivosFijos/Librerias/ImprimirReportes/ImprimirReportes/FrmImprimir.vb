Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class FrmImprimir
    Public titulo As String
    Public cad As String
    Public reporte As String
    Dim strConxAdcom As String = ""
    Dim conectar As New SqlConnection()

    Private Sub FrmImprimir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim coneccion As New DaxLib.DaxLibBases
        Dim SYSEMP As New AdcDax.DaxsofSys
        Dim EMP = SYSEMP.EmpresaAct
        coneccion.TipoBase = "10"
        conectar.ConnectionString = coneccion.StrAdcom
        Dim rds As New ReportDataSource()
        Dim nombre As New ReportParameter("Titulo", titulo)
        rds.Name = "DataSet1"
        rds.Value = CalcularDataSet(cad).Tables(0)
        ReportViewer1.Visible = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewer1.LocalReport.ReportPath = EMP.PatAppl & "binNET\REP\" & reporte
        ReportViewer1.LocalReport.SetParameters(nombre)
        Me.ReportViewer1.RefreshReport()

    End Sub
    Public Function CalcularDataSet(ByVal cadena As String) As DataSet
        Dim ssql As String = cadena
        Dim sqlAdap As New SqlDataAdapter(ssql, conectar)
        conectar.Open()
        Dim datS As New DataSet()
        sqlAdap.Fill(datS, "Activos")
        conectar.Close()
        Return datS
    End Function
    Public Sub Impresion(ByVal cadena As String, ByVal tit As String, ByVal repor As String)
        Me.titulo = tit
        Me.cad = cadena
        reporte = repor
        Me.Show()
    End Sub
End Class
