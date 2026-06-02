Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Public Class frmReporte
    Public periodo, cad As String
    Dim conectar As New SqlConnection()
    Dim titulo, empresa, fecha, año, año1, expresar As String
    Dim colRef, colCod, colNota, colAño, colAño1, colDiferencia, colPorce As Boolean
    Dim expresarEn As Integer
    Dim reporte As Integer
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim coneccion As New DaxLib.DaxLibBases
        Dim SYSEMP As New AdcDax.DaxsofSys
        Dim EMP = SYSEMP.EmpresaAct
        coneccion.TipoBase = "10"
        conectar.ConnectionString = coneccion.StrAdcom
        empresa = SYSEMP.EmpresaAct.nombre
        Dim rds As New ReportDataSource()
        If reporte = 1 Then

            Dim titulo1 As New ReportParameter("Titulo", titulo)
            Dim empresa1 As New ReportParameter("Empresa", empresa)
            Dim fecha1 As New ReportParameter("Fecha", fecha)
            Dim años As New ReportParameter("Año", año)
            Dim años1 As New ReportParameter("Año1", año1)
            Dim colRe As New ReportParameter("ColReferencia", colRef)
            Dim colCodi As New ReportParameter("ColCodigo", colCod)
            Dim colNot As New ReportParameter("ColNota", colNota)
            Dim colAñ As New ReportParameter("ColAño", colAño)
            Dim colAñ1 As New ReportParameter("ColAño1", colAño1)
            Dim colDif As New ReportParameter("ColDiferencia", colDiferencia)
            Dim colPor As New ReportParameter("ColPorcentaje", colPorce)
            Dim ExpEn As New ReportParameter("expresar", expresarEn)
            Dim ExpresEn As New ReportParameter("ExpresadoEn", expresar)
            rds.Name = "DataSet1"
            rds.Value = CalcularDataSet(cad).Tables(0)
            ReportViewer1.Visible = True
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(rds)
            ReportViewer1.LocalReport.ReportPath = EMP.PatAppl & "binNET\REP\ReporteBalanceSit.rdlc"
            ReportViewer1.LocalReport.SetParameters(titulo1)
            ReportViewer1.LocalReport.SetParameters(empresa1)
            ReportViewer1.LocalReport.SetParameters(colCodi)
            ReportViewer1.LocalReport.SetParameters(años)
            ReportViewer1.LocalReport.SetParameters(años1)
            ReportViewer1.LocalReport.SetParameters(colRe)
            ReportViewer1.LocalReport.SetParameters(colCodi)
            ReportViewer1.LocalReport.SetParameters(colNot)
            ReportViewer1.LocalReport.SetParameters(colAñ)
            ReportViewer1.LocalReport.SetParameters(colAñ1)
            ReportViewer1.LocalReport.SetParameters(colDif)
            ReportViewer1.LocalReport.SetParameters(colPor)
            ReportViewer1.LocalReport.SetParameters(ExpEn)
            ReportViewer1.LocalReport.SetParameters(ExpresEn)
        ElseIf reporte = 2 Then
            rds.Name = "DataSet1"
            rds.Value = CalcularDataSet(cad).Tables(0)
            ReportViewer1.Visible = True
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(rds)
            ReportViewer1.LocalReport.ReportPath = EMP.PatAppl & "binNet\REP\ReporteNotas.rdlc"
        End If
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Function CalcularDataSet(ByVal cadena As String) As DataSet
        Dim ssql As String = cadena
        Dim sqlAdap As New SqlDataAdapter(ssql, conectar)
        conectar.Open()
        Dim datS As New DataSet()
        sqlAdap.Fill(datS, "Inventario")
        conectar.Close()
        Return datS
    End Function
    Public Sub Impresion(ByVal cadena As String, ByVal titul As String, ByVal fech As String, ByVal col() As Boolean, ByVal exp As Integer, ByVal expresar As String)
        Me.cad = cadena
        Me.titulo = titul
        Me.fecha = fech
        año = Year(fecha) - 1
        año1 = Year(fecha)
        colRef = col(0)
        colCod = col(1)
        colNota = col(2)
        colAño = col(3)
        colAño1 = col(4)
        colDiferencia = col(5)
        colPorce = col(6)
        expresarEn = exp
        reporte = 1
        Me.expresar = expresar
        Me.Show()
    End Sub
    Public Sub ImprimirNota(ByVal cadena As String)
        reporte = 2
        cad = cadena
        Me.Show()
    End Sub
End Class
