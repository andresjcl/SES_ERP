Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports DattCom

Public Class frmRepDoc
    Dim botonOp As Boolean = False
    Dim fecHasta As Date = Date.Now
    Dim fecDesde As Date = New Date(fecHasta.Year, fecHasta.Month, 1)
    Dim opSoloTot As Boolean = False
    'Dim imprimeDetalleDocumento As Boolean = False
    'Dim imprimeConsignatario As Boolean = False
    Dim codClienteIni As String = ""
    Dim codClienteFin As String = ""
    Dim tipo As String = "I"
    Dim suc As String = ""
    Dim bod As String = ""
    Dim doc As String = ""
    Dim vend As String = ""
    Dim det As String = ""
    Dim tipoDoc As String = ""
    Dim ImprimeRenglones As Boolean
#Region "Datos Iniciales"
    Private Sub frmRepDoc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DatosIniciales()
    End Sub
    Private Sub DatosIniciales()
        Dim mes As Integer = 0
        Dim dia As Integer = 0
        Dim año As Integer = 0
        ImprimeRenglones = False
        DocDetalle.Text = ImpDocumento.Text
        LlenarCombos()
        txtFechaAl.Text = fecHasta.ToShortDateString

        'If Month(Now) = 1 Then mes = 12 : año = Year(Now) - 1 Else mes = Month(Now) - 1 : año = Year(Now)
        'dia = txtFechaAl.Text.Substring(0, 2)
        'If dia = 31 And mes = 2 Then
        '    dia = 28
        'ElseIf dia = 31 And mes <> 8 Then : dia = 30
        'End If
        txtFechaDel.Text = fecDesde.ToShortDateString
    End Sub

    Private Sub LlenarCombos()
        Dim c As New DaxCombobx.CargCmbBox
        c.DaxCombosDoc("", "", True, datosEmpresa.strConxAdcom, cboDoc)
        c.DaxCombosSuc(CStr(datosEmpresa.Emp_codigo), True, datosEmpresa.strConIniSis, cboSucursal)
        'cboSucursal.SelectedValue = " "
        cboSucursal.SelectedValue = "0"
        c.DaxCombosBods(datosEmpresa.suc, True, datosEmpresa.strConIniSis, cboBodega)
        'cboBodega.SelectedValue = " "
        cboBodega.SelectedValue = "0"
        c.DaxCombosVend(datosEmpresa.strConxAdcom, cboVendedor, True)
        'cboVendedor.SelectedValue = " "
        cboVendedor.SelectedValue = "0"
    End Sub
    Private Sub txtFechaDel_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If txtFechaDel.Text <> "  /  /" Then
            If Not IsDate(txtFechaDel.Text) Then
                MsgBox("Ingrese una fecha válida", MsgBoxStyle.Information)
                txtFechaDel.Text = ""
                txtFechaDel.Focus()
            End If
        End If
    End Sub
    Private Sub txtFechaAl_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If txtFechaAl.Text <> "  /  /" Then
            If Not IsDate(txtFechaAl.Text) Then
                MsgBox("Ingrese una fecha válida", MsgBoxStyle.Information)
                txtFechaAl.Text = ""
                txtFechaAl.Focus()
            ElseIf txtFechaDel.Value > txtFechaAl.Value Then
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
        bod = ""
        doc = ""
        vend = ""
        suc = ""
        codClienteIni = txtCodIni.Text
        codClienteFin = txtCodFin.Text
        fecDesde = CDate(txtFechaDel.Text)
        fecHasta = CDate(txtFechaAl.Text)

        If cboSucursal.SelectedValue.ToString() <> "0" Then suc = CStr(cboSucursal.SelectedValue)

        If cboDoc.SelectedValue.ToString() <> "0" Then doc = CStr(cboDoc.SelectedValue) : det += "DOCUMENTO:" & cboDoc.Text.Trim : esp = "    "
        Try
            Select Case tipo
                Case "C", "CC", "V", "CP"
                    If cboVendedor.SelectedValue.ToString() <> "0" Then vend = CStr(cboVendedor.SelectedValue) : det += "VENDEDOR:" & cboVendedor.Text.Trim: esp = "    "
                Case "I"
                    If cboBodega.SelectedValue.ToString() > "0" Then bod = CStr(cboBodega.SelectedValue)
            End Select
        Catch ex As Exception
        End Try

    End Sub
    Private Sub Ocultar(ByVal op As String)
        cboBodega.Visible = False
        cboVendedor.Visible = False
        Label2.Visible = False
        Label4.Visible = False
        Select Case op
            Case "I"
                cboBodega.Visible = True
                Label2.Visible = True
            Case "C", "CC", "V", "CP"
                cboVendedor.Visible = True
                Label4.Visible = True
        End Select
    End Sub
    Private Sub Reporte()
        Dim cad As String = ""
        leerOpciones()
        Dim iDetalle As String = "N"
        If ImprimeRenglones Then iDetalle = "S"

        cad = "exec Adc_ReptDocIva '" & fecDesde & "','" & fecHasta & "','" & tipo & "','" & codClienteIni & "','" & codClienteFin & "','" & suc & "','" & bod & "','" & doc & "','" & vend & "','" & iDetalle & "'"

        Dim rds As New ReportDataSource()
        Dim Empresa As New ReportParameter("Empresa", datosEmpresa.nomEmpresa)
        Dim nombre As New ReportParameter("Titulo", "REPORTE DE DOCUMENTOS DE " & tipoDoc)
        Dim FechaD As New ReportParameter("FecDesde", txtFechaDel.Text)
        Dim FechaH As New ReportParameter("FecHasta", txtFechaAl.Text)
        Dim FechaE As New ReportParameter("FecEmision", Now.ToShortDateString)
        Dim tot As New ReportParameter("SoloTot", CStr(opSoloTot))
        'Dim opDet As New ReportParameter("ConDetalle", CStr(chkDetalle.Checked))
        Dim Detalle As New ReportParameter("DetalleRep", det)
        Dim Consignatario As New ReportParameter("ConConsignatario", CStr(chkConsignatario.Checked))
        Dim Tipor As New ReportParameter("Tipor", tipo)

        rds.Name = "DataSet1"
        rds.Value = SqlDatos.leerTablaAdcom(cad)  ' CalcularDataSet(cad).Tables("Activos")
        ReportViewer1.Visible = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(rds)
        If ImprimeRenglones = False Then
            ReportViewer1.LocalReport.ReportPath = datosEmpresa.pathAppl & "Rep\RepDocIva.rdlc"
        Else
            ReportViewer1.LocalReport.ReportPath = datosEmpresa.pathAppl & "Rep\RepDocDet.rdlc"
        End If

        ReportViewer1.LocalReport.SetParameters(Empresa)
        ReportViewer1.LocalReport.SetParameters(nombre)
        ReportViewer1.LocalReport.SetParameters(FechaD)
        ReportViewer1.LocalReport.SetParameters(FechaH)
        ReportViewer1.LocalReport.SetParameters(FechaE)
        ReportViewer1.LocalReport.SetParameters(tot)
        'ReportViewer1.LocalReport.SetParameters(opDet)
        'ReportViewer1.LocalReport.SetParameters(Consignatario)
        ReportViewer1.LocalReport.SetParameters(Detalle)
        'ReportViewer1.LocalReport.SetParameters(Tipor)
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub optInv_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optInv.CheckedChanged
        If optInv.Checked = True Then tipo = "I"
        ReportViewer1.Clear()
        tipoDoc = "INVENTARIO"
        Ocultar(tipo)
    End Sub
    Private Sub optVentas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optVentas.CheckedChanged
        If optVentas.Checked = True Then tipo = "V"
        ReportViewer1.Clear()
        tipoDoc = "VENTAS"
        Ocultar(tipo)
    End Sub

    Private Sub optCompras_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCompras.CheckedChanged
        If optCompras.Checked = True Then tipo = "C"
        ReportViewer1.Clear()
        tipoDoc = "COMPRAS"
        Ocultar(tipo)
    End Sub

    Private Sub optBancos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optBancos.CheckedChanged
        If optBancos.Checked = True Then tipo = "B"
        ReportViewer1.Clear()
        tipoDoc = "BANCOS"
        Ocultar(tipo)
    End Sub

    Private Sub optCtasCob_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCtasCob.CheckedChanged
        If optCtasCob.Checked = True Then tipo = "CC"
        ReportViewer1.Clear()
        tipoDoc = "CUENTAS POR COBRAR"
        Ocultar(tipo)
    End Sub

    Private Sub optCtaPag_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCtaPag.CheckedChanged
        If optCtaPag.Checked = True Then tipo = "CP"
        ReportViewer1.Clear()
        tipoDoc = "CUENTAS POR PAGAR"
        Ocultar(tipo)
    End Sub
    Private Sub optTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTodos.CheckedChanged
        If optTodos.Checked = True Then tipo = "T"
        ReportViewer1.Clear()
        tipoDoc = "TODOS LOS DOCUMENTOS"
        Ocultar(tipo)
    End Sub

    Private Sub optAnulados_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optAnulados.CheckedChanged
        If optAnulados.Checked = True Then tipo = "A"
        ReportViewer1.Clear()
        tipoDoc = "ANULADOS"
        Ocultar(tipo)
    End Sub

    Private Sub txtFechaDel_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ReportViewer1.Clear()
    End Sub

    Private Sub txtFechaAl_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ReportViewer1.Clear()
    End Sub
    Private Sub chkSoloTotal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSoloTotal.CheckedChanged
        opSoloTot = chkSoloTotal.Checked
        ReportViewer1.Clear()
    End Sub
    Private Sub txtCodIni_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodIni.TextChanged, txtCodFin.TextChanged
        ReportViewer1.Clear()
    End Sub

    'Private Sub txtCodFin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodFin.TextChanged
    '    ReportViewer1.Clear()
    'End Sub
    Private Sub cboSucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSucursal.SelectedIndexChanged
        ReportViewer1.Clear()
    End Sub

    Private Sub cboBodega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBodega.SelectedIndexChanged
        ReportViewer1.Clear()
    End Sub

    Private Sub cboDoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDoc.SelectedIndexChanged
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


    Private Sub btnOpciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpciones.Click
        If botonOp = False Then
            btnOpciones.Checked = False
            botonOp = True
        Else
            btnOpciones.Checked = True
            botonOp = False
        End If
        SplitContainer1.Panel1Collapsed = Not btnOpciones.Checked
    End Sub
    Private Function BuscaCliente(ByVal nom As String) As String
        Dim cod As String = ""
        Dim b As New directMnt.BusDirectorio
        cod = b.BusDirect(cod, "", nom, "", "T", "")
        BuscaCliente = cod
    End Function
    Private Sub btnCodIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCodIni.Click
        txtCodIni.Text = BuscaCliente(txtCodIni.Text)
    End Sub

    Private Sub btnCodFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCodFin.Click
        txtCodFin.Text = BuscaCliente(txtCodFin.Text)
    End Sub

    Private Sub txtCodIni_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodIni.KeyDown
        If e.KeyCode = Keys.F2 Then
            txtCodIni.Text = BuscaCliente(txtCodIni.Text)
        End If
    End Sub

    Private Sub txtCodFin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodFin.KeyDown
        If e.KeyCode = Keys.F2 Then
            txtCodFin.Text = BuscaCliente(txtCodFin.Text)
        End If
    End Sub
   

#Region "Salir"
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub
#End Region


    Private Sub ImpDocumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImpDocumento.Click
        ImprimeRenglones = False
        DocDetalle.Text = ImpDocumento.Text
        ReportViewer1.Clear()
    End Sub

    Private Sub ImpDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImpDetalle.Click
        ImprimeRenglones = True
        DocDetalle.Text = ImpDetalle.Text
        ReportViewer1.Clear()
    End Sub

    Private Sub chkDetalle_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkDetalle.CheckedChanged
        'imprimeDetalleDocumento = chkDetalle.Checked
        ReportViewer1.Clear()
    End Sub

    Private Sub DocDetalle_Click(sender As Object, e As EventArgs) Handles DocDetalle.Click

    End Sub
End Class
