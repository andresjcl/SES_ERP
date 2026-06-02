Imports System.Data.SqlClient
Imports DattCom
Imports Microsoft.Reporting.WinForms
Public Class FrmImpr
    Dim cadena As String = ""
    Dim titul As String = ""
    Dim empr As String = ""
    Private Sub FrmImpr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim rds As New ReportDataSource()
        rds.Name = "DataSet1"
        rds.Value = CalcularDataSet(cadena)
        ReportViewer1.Visible = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(rds)
        Dim titulo1 As New ReportParameter("Titulo", titul)
        Dim empresa1 As New ReportParameter("Empresa", datosEmpresa.nomEmpresa)
        ReportViewer1.LocalReport.ReportPath = datosEmpresa.pathAppl & "binNET\REP\RepNivServ.rdlc"
        ReportViewer1.LocalReport.SetParameters(titulo1)
        ReportViewer1.LocalReport.SetParameters(empresa1)
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Function CalcularDataSet(ByVal cadena As String) As DataTable
        Dim ssql As String = cadena
        Dim sqlAdap As New SqlDataAdapter(ssql, datosEmpresa.strConxAdcom)
        Dim datS As New DataTable()
        sqlAdap.Fill(datS)
        sqlAdap.Dispose()
        Return datS
    End Function
    Public Sub Imprimir(ByVal cad As String, ByVal tit As String, ByVal emp As String)
        titul = tit
        empr = emp
        cadena = cad
        Me.Show()
    End Sub

    Private Sub FrmImpr_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ReportViewer1.RefreshReport()
    End Sub

End Class