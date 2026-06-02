Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class FormImpr

    Public Sub Reporte(ByVal ssql As String, ByVal txtFechaDel As DateTime, ByVal txtFechaAl As DateTime, ByVal saldoInicia As Double, ByVal Titular As String)

        Dim rds As New ReportDataSource()
        rds.Name = "DataSet2"
        rds.Value = CalcularDataSet("select * from AdcCctmp").Tables("Activos")

        Dim Empresa_par As New ReportParameter("Empresa", SYSEMP.EmpresaAct.nombre)
        Dim Titulo_par As New ReportParameter("Titulo", Titular)
        Dim FecDesde_par As New ReportParameter("FecDesde", txtFechaDel.ToLongDateString())
        Dim FecHasta_par As New ReportParameter("FecHasta", txtFechaAl.ToLongDateString())
        Dim FecEmision_par As New ReportParameter("FecEmision", Now.Date.ToLongDateString())
        Dim saldoInicial_par As New ReportParameter("saldoInicial", Convert.ToString(saldoInicia))
        ReportViewer1.Visible = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewer1.LocalReport.ReportPath = EMP.PatAppl + "BinNet\Rep\Repmovcta.rdlc"
        ReportViewer1.LocalReport.SetParameters(Empresa_par)
        ReportViewer1.LocalReport.SetParameters(Titulo_par)
        ReportViewer1.LocalReport.SetParameters(FecDesde_par)
        ReportViewer1.LocalReport.SetParameters(FecHasta_par)
        ReportViewer1.LocalReport.SetParameters(FecEmision_par)
        ReportViewer1.LocalReport.SetParameters(saldoInicial_par)
        Me.ReportViewer1.RefreshReport()
        Me.ShowDialog()
    End Sub
    Private Function CalcularDataSet(ByVal cadena As String) As DataSet
        Dim ssql As String = cadena
        Dim sqlAdap As New SqlDataAdapter(ssql, conectar)
        If conectar.State = ConnectionState.Closed Then conectar.Open()
        Dim datS As New DataSet()
        sqlAdap.Fill(datS, "Activos")
        conectar.Close()
        Return datS
    End Function


End Class