Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Public Class frmCierrCaja
    Dim botonOp As Boolean = 0
    Dim fecHasta As Date = "0:0"
    Dim fecDesde As Date = "0:0"
    Dim opSoloTot As Boolean = False
    Dim codClienteIni As String = ""
    Dim codClienteFin As String = ""
    Dim tipo As String = "I"
    Dim suc As String = ""
    Dim ptovta As String = ""
    Dim vend As String = ""
    Dim det As String = ""
    Dim tipoDoc As String = ""
    Dim ImprimeDetalle As Boolean
    Dim codfac As String = ""
    Dim coddev As String = ""
    Dim codret As String = ""
    Dim opcionreporte As String

#Region "Datos Iniciales"
    Private Sub frmRepDoc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conectarBDD()
        DatosIniciales()
    End Sub

    Private Sub DatosIniciales()
        Dim mes As Integer = 0
        Dim dia As Integer = 0
        Dim año As Integer = 0
        ImprimeDetalle = False
        LlenarCombos()
        txtFechaAl.Text = Now
        If Month(Now) = 1 Then mes = 12 : año = Year(Now) - 1 Else mes = Month(Now) - 1 : año = Year(Now)
        dia = txtFechaAl.Text.Substring(0, 2)
        If dia = 31 And mes = 2 Then
            dia = 28
        ElseIf dia = 31 And mes <> 8 Then : dia = 30
        End If
        txtFechaDel.Text = CDate(dia & "/" & mes & "/" & año)
    End Sub
    Private Sub LlenarCombos()
        Dim c As New DaxCbos.DaxCombobx
        c.DaxCombosPtoVta(strcon, cboPtoVta, True)
        cboPtoVta.SelectedValue = "0"
        c.DaxCombosSuc(EMP.codigo, True, strsys, cboSucursal)
        cboSucursal.SelectedValue = "0"
        c.DaxCombosVend(strcon, cboVendedor, True)
        cboVendedor.SelectedValue = "0"
    End Sub
    Private Sub txtFechaDel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFechaDel.LostFocus
        If txtFechaDel.Text <> "  /  /" Then
            If Not IsDate(txtFechaDel.Text) Then
                MsgBox("Ingrese una fecha válida", MsgBoxStyle.Information)
                txtFechaDel.Text = ""
                txtFechaDel.Focus()
            End If
        End If
    End Sub
    Private Sub txtFechaAl_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFechaAl.LostFocus
        If txtFechaAl.Text <> "  /  /" Then
            If Not IsDate(txtFechaAl.Text) Then
                MsgBox("Ingrese una fecha válida", MsgBoxStyle.Information)
                txtFechaAl.Text = ""
                txtFechaAl.Focus()
            ElseIf txtFechaDel.Text > txtFechaAl.Text Then
                MsgBox("La fecha final debe ser mayor a la inicial", MsgBoxStyle.Information)
                txtFechaAl.Text = ""
                txtFechaAl.Focus()
            End If
        End If
    End Sub
#End Region

#Region "Reporte"
    Private Sub leerOpciones()
        Dim esp As String = ""
        det = ""
        vend = ""
        suc = ""
        ptovta = ""
        codfac = ""
        coddev = ""
        codret = ""
        fecDesde = txtFechaDel.Text
        fecHasta = txtFechaAl.Text
        opcionreporte = ""
        If cboSucursal.SelectedValue <> "0" Then suc = cboSucursal.SelectedValue
        opcionreporte = "SUCURSAL: " & cboSucursal.Text
        If cboVendedor.SelectedValue <> "0" Then vend = cboVendedor.SelectedValue
        opcionreporte &= "       VENDEDOR: " & cboVendedor.Text
        If cboPtoVta.SelectedValue <> "0" Then ptovta = cboPtoVta.SelectedValue
        opcionreporte &= "       PTOVTA: " & cboPtoVta.Text
        If chkfacturas.Checked Then codfac = "S"
        If chkdevolucion.Checked Then coddev = "S"
        If chkretencion.Checked Then codret = "S"
    End Sub
    Private Sub Reporte()
        Dim cad As String = ""
        leerOpciones()
        If ResumenVertical.Checked Then
            cad = "exec Adc_CieCaj '" & fecDesde & "','" & fecHasta & "','" & suc & "','" & "N" & "','" & vend & "','" & ptovta & "','" & codfac & "','" & coddev & "','" & codret & "'"
        Else
            cad = "exec Adc_CieCaj '" & fecDesde & "','" & fecHasta & "','" & suc & "','" & "N" & "','" & vend & "','" & ptovta & "','" & codfac & "','" & coddev & "','" & codret & "','" & IIf(pagosAbiertos.Checked, "S", "N") & "'"
        End If

        Dim rds As New ReportDataSource()
        Dim Empresa As New ReportParameter("Empresa", SYSEMP.EmpresaAct.nombre)
        Dim nombre As New ReportParameter("Titulo", "REPORTE CIERRE DE CAJA ")
        Dim FechaD As New ReportParameter("FecDesde", txtFechaDel.Text)
        Dim FechaH As New ReportParameter("FecHasta", txtFechaAl.Text)
        Dim FechaE As New ReportParameter("FecEmision", Now.Date)
        Dim tot As New ReportParameter("SoloTot", opSoloTot)
        Dim Detalle As New ReportParameter("DetalleRep", det)
        Dim Tipor As New ReportParameter("Tipor", tipo)
        Dim opcionesreporte As New ReportParameter("opcionesreporte", opcionreporte)
        rds.Name = "DataSet1"
        rds.Value = CalcularDataSet(cad).Tables("Activos")

        ReportViewer1.Visible = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(rds)

        If ResumenVertical.Checked Then
            ReportViewer1.LocalReport.ReportPath = EMP.PatAppl & "BinNet\Rep\CierrCajV.rdlc"
        Else
            ReportViewer1.LocalReport.ReportPath = EMP.PatAppl & "BinNet\Rep\CierrCaj.rdlc"
        End If

        ReportViewer1.LocalReport.SetParameters(Empresa)
        ReportViewer1.LocalReport.SetParameters(nombre)
        ReportViewer1.LocalReport.SetParameters(FechaD)
        ReportViewer1.LocalReport.SetParameters(FechaH)
        ReportViewer1.LocalReport.SetParameters(FechaE)
        ReportViewer1.LocalReport.SetParameters(tot)
        ReportViewer1.LocalReport.SetParameters(Detalle)
        ReportViewer1.LocalReport.SetParameters(Tipor)
        ReportViewer1.LocalReport.SetParameters(opcionesreporte)
        Me.ReportViewer1.RefreshReport()
    End Sub

    Public Function CalcularDataSet(ByVal cadena As String) As DataSet
        Dim ssql As String = cadena
        Dim sqlAdap As New SqlDataAdapter(ssql, conectar)
        If conectar.State = ConnectionState.Closed Then conectar.Open()
        Dim datS As New DataSet()
        sqlAdap.Fill(datS, "Activos")
        conectar.Close()
        Return datS
    End Function

    Private Sub txtFechaDel_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFechaDel.TextChanged
        ReportViewer1.Clear()
    End Sub

    Private Sub txtFechaAl_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFechaAl.TextChanged
        ReportViewer1.Clear()
    End Sub

    'Private Sub txtCodFin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodFin.TextChanged
    '    ReportViewer1.Clear()
    'End Sub
    Private Sub cboSucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSucursal.SelectedIndexChanged
        ReportViewer1.Clear()
    End Sub

    Private Sub cboDoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPtoVta.SelectedIndexChanged
        ReportViewer1.Clear()
    End Sub

    Private Sub cboVendedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVendedor.SelectedIndexChanged
        ReportViewer1.Clear()
    End Sub
#End Region

#Region "Actualizar"
    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        Reporte()
    End Sub
#End Region

#Region "Opciones"
    Private Sub btnOpciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpciones.Click
        If botonOp = 0 Then
            btnOpciones.Checked = False
            botonOp = 1
        Else
            btnOpciones.Checked = True
            botonOp = 0
        End If
        SplitContainer1.Panel1Collapsed = Not btnOpciones.Checked
    End Sub
    Private Function BuscaCliente(ByVal nom As String) As String
        Dim cod As String = ""
        Dim b As New MantenimientoDirectorio.BusDirectorio
        cod = b.BusDirect(cod, "", nom, "", "T")
        BuscaCliente = cod
    End Function
    Private Function nombre(ByVal cod As String)
        Dim nom As String = ""
        Dim cmd As New SqlCommand("select nombreImpresion from identificacion where codigo='" & cod & "'", conectar)
        Dim dat As SqlDataReader = Nothing
        conectar.Open()
        dat = cmd.ExecuteReader()
        If dat.Read Then
            If Not IsDBNull(dat(0)) Then nom = dat(0)
        End If
        conectar.Close()
        Return nom
    End Function
#End Region

#Region "Salir"
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub
#End Region

End Class
