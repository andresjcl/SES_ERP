Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.IO
Imports SysEmpDatt
Public Class frmCierrCaja
    Dim botonOp As Boolean = False
    Dim fecHasta As DateTime = Now
    Dim fecDesde As DateTime = Now
    Dim fechaLim As DateTime = New DateTime(1900, 1, 1, 0, 0, 0)
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
    Dim CierreConfirmado As Boolean
    Dim valorEfectivo As Decimal
    Dim valorCheques As Decimal
    Dim valorTarjetas As Decimal
    Dim nroCheques As Decimal
    Dim nroTarjetas As Decimal
    Dim DatosCierre As New DaxCiecaj
    Dim proceso As Integer = 0  ' 0 sin operacion 1 actualizado  2 consultando
    Dim esgeneral As Boolean = False
    Dim c As New DaxCombobx.CargCmbBox

#Region "Datos Iniciales"
    Public Sub New(dc As DaxCiecaj, Optional general As Boolean = False)
        MyBase.New()
        InitializeComponent()
        DatosCierre = dc
        esgeneral = general
    End Sub
    Private Sub frmCierrCaja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conectarBDD()
        DatosIniciales()
        'Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub DatosIniciales()
        Dim mes As Integer = 0
        Dim dia As Integer = 0
        Dim año As Integer = 0
        ImprimeDetalle = False
        LlenarCombos()

        cmbSucursal.SelectedValue = DatosCierre.Sucursal
        cboPtoVta.Text = DatosCierre.PuntoDeVenta
        If DatosCierre.FechaIni.Year = 1900 Then
        End If

        If (DatosCierre.FechaIni > fechaLim) Then
            txtFechaDel.Value = DatosCierre.FechaIni
            txtFechaAl.Value = Now
        End If

        'btnConfimaCierre.Enabled = False
        proceso = 0
        organizarBotones()
        Text = "PUNTTO - CIERRES DE CAJA DE PUNTOS DE VENTA"
        BtnResumenGeneral.Visible = False
        If esgeneral Then
            Text = "PUNTTO - CUADRE DE CAJA GENERAL"
            BtnResumenGeneral.Visible = True
            GrupoEntregaCaja.Visible = False
            '            GrupoFiltros.Visible = False
            btnAbrir.Visible = False
            btnActualizar.Visible = False
            btnCerrar.Visible = False
            btnConfimaCierre.Visible = False
            'btnHorarios.Visible = False
            btnMovimientos.Visible = False
            btnPdfOriginal.Visible = False


        End If
    End Sub
    Private Sub LlenarCombos()
        c.DaxCombosPtoVtaReg(datosEmpresa.strConxAdcom, cboPtoVta, True, datosEmpresa.suc)
        llenarComboPtoVta()
    End Sub

    Private Sub llenarComboPtoVta()
        c.DaxCombosSuc(datosEmpresa.codEmpresa.ToString(), True, datosEmpresa.strConxSyscod, cmbSucursal, True)
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
            ElseIf txtFechaDel.Text > txtFechaAl.Text Then
                MsgBox("La fecha final debe ser mayor a la inicial", MsgBoxStyle.Information)
                txtFechaAl.Text = ""
                txtFechaAl.Focus()
            End If
        End If
    End Sub
#End Region

#Region "Reporte"
    Private Sub Reporte()
        Dim cad As String = ""
        leerOpciones()
        cad = "exec Adc_CieCajDax '" & txtFechaDel.Text + "','" & txtFechaAl.Text & "','" & suc & "','" & ptovta & "','0" & txtEfectivo.Text & "','0" & txtCheques.Text & "','0" & txtTarjetas.Text & "'"
        ValoresRecibidos.valorEfectivo = valorNumero(txtEfectivo.Text)
        ValoresRecibidos.valorCheques = valorNumero(txtCheques.Text)
        ValoresRecibidos.valorTarjetas = valorNumero(txtTarjetas.Text)
        ValoresRecibidos.nroCheques = valorNumero(txtCantCheques.Text)
        ValoresRecibidos.nroTarjetas = valorNumero(txtCantTarjetas.Text)

        Dim rds As New ReportDataSource()
        Dim Empresa As New ReportParameter("Empresa", datosEmpresa.nomEmpresa.ToString())
        Dim nombre As New ReportParameter("Titulo", "RESUMEN CIERRE DE CAJA ")
        Dim FechaD As New ReportParameter("FecDesde", txtFechaDel.Text)
        Dim FechaH As New ReportParameter("FecHasta", txtFechaAl.Text)
        Dim FechaE As New ReportParameter("FecEmision", Now.Date.ToShortDateString)
        Dim tot As New ReportParameter("SoloTot", opSoloTot.ToString())
        Dim Detalle As New ReportParameter("DetalleRep", det)
        Dim Tipor As New ReportParameter("Tipor", tipo)
        Dim opcionesreporte As New ReportParameter("opcionesreporte", opcionreporte)


        Dim ValEfectivo As New ReportParameter("ValEfectivo", ValoresRecibidos.valorEfectivo.ToString())
        Dim ValCheques As New ReportParameter("ValCheques", ValoresRecibidos.valorCheques.ToString())
        Dim CantCheques As New ReportParameter("CantCheques", ValoresRecibidos.nroCheques.ToString())
        Dim ValTarjetas As New ReportParameter("ValTarjetas", ValoresRecibidos.valorTarjetas.ToString())
        Dim CantTarjetas As New ReportParameter("CantTarjetas", ValoresRecibidos.nroTarjetas.ToString())
        Dim LoteTarjetas As New ReportParameter("LoteTarjetas", NroLoteTarjetas.Text)


        rds.Name = "DataSet1"
        rds.Value = SqlDatos.leerTablaAdcom(cad)

        ReportViewer1.Visible = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(rds)

        ReportViewer1.LocalReport.ReportPath = datosEmpresa.pathAppl & "BinNet\Rep\CierrCajTirllPtoVta.rdlc"

        ReportViewer1.LocalReport.SetParameters(Empresa)
        ReportViewer1.LocalReport.SetParameters(nombre)
        ReportViewer1.LocalReport.SetParameters(FechaD)
        ReportViewer1.LocalReport.SetParameters(FechaH)
        ReportViewer1.LocalReport.SetParameters(FechaE)
        ReportViewer1.LocalReport.SetParameters(tot)
        ReportViewer1.LocalReport.SetParameters(Detalle)
        ReportViewer1.LocalReport.SetParameters(Tipor)
        ReportViewer1.LocalReport.SetParameters(opcionesreporte)
        ReportViewer1.LocalReport.SetParameters(ValEfectivo)
        ReportViewer1.LocalReport.SetParameters(ValCheques)
        ReportViewer1.LocalReport.SetParameters(CantCheques)
        ReportViewer1.LocalReport.SetParameters(ValTarjetas)
        ReportViewer1.LocalReport.SetParameters(CantTarjetas)
        ReportViewer1.LocalReport.SetParameters(LoteTarjetas)

        Me.ReportViewer1.RefreshReport()
        btnConfimaCierre.Enabled = True
        If proceso < 2 Then proceso = 1
    End Sub
    Private Sub CierreGeneral()
        Dim cad As String = ""
        leerOpciones()
        cad = "exec Adc_CieCajGenDax '" & txtFechaDel.Text + "','" & txtFechaAl.Text & "','" & suc & "','" & ptovta & "'"

        Dim rds As New ReportDataSource()
        Dim Empresa As New ReportParameter("Empresa", datosEmpresa.nomEmpresa.ToString())
        Dim nombre As New ReportParameter("Titulo", "RESUMEN CIERRE DE CAJA ")
        Dim FechaD As New ReportParameter("FecDesde", txtFechaDel.Text)
        Dim FechaH As New ReportParameter("FecHasta", txtFechaAl.Text)
        Dim FechaE As New ReportParameter("FecEmision", Now.Date.ToShortDateString)
        Dim tot As New ReportParameter("SoloTot", opSoloTot.ToString())
        Dim Detalle As New ReportParameter("DetalleRep", det)
        Dim Tipor As New ReportParameter("Tipor", tipo)
        Dim opcionesreporte As New ReportParameter("opcionesreporte", opcionreporte)


        Dim ValEfectivo As New ReportParameter("ValEfectivo", ValoresRecibidos.valorEfectivo.ToString())
        Dim ValCheques As New ReportParameter("ValCheques", ValoresRecibidos.valorCheques.ToString())
        Dim CantCheques As New ReportParameter("CantCheques", ValoresRecibidos.nroCheques.ToString())
        Dim ValTarjetas As New ReportParameter("ValTarjetas", ValoresRecibidos.valorTarjetas.ToString())
        Dim CantTarjetas As New ReportParameter("CantTarjetas", ValoresRecibidos.nroTarjetas.ToString())
        Dim LoteTarjetas As New ReportParameter("LoteTarjetas", NroLoteTarjetas.Text)


        rds.Name = "DataSet1"
        rds.Value = SqlDatos.leerTablaAdcom(cad)

        ReportViewer1.Visible = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(rds)

        ReportViewer1.LocalReport.ReportPath = datosEmpresa.pathAppl & "BinNet\Rep\CierrCajGeneral.rdlc"
        ReportViewer1.LocalReport.SetParameters(Empresa)
        ReportViewer1.LocalReport.SetParameters(nombre)
        ReportViewer1.LocalReport.SetParameters(FechaD)
        ReportViewer1.LocalReport.SetParameters(FechaH)
        ReportViewer1.LocalReport.SetParameters(FechaE)
        ReportViewer1.LocalReport.SetParameters(tot)
        ReportViewer1.LocalReport.SetParameters(Detalle)
        ReportViewer1.LocalReport.SetParameters(Tipor)
        ReportViewer1.LocalReport.SetParameters(opcionesreporte)
        ReportViewer1.LocalReport.SetParameters(ValEfectivo)
        ReportViewer1.LocalReport.SetParameters(ValCheques)
        ReportViewer1.LocalReport.SetParameters(CantCheques)
        ReportViewer1.LocalReport.SetParameters(ValTarjetas)
        ReportViewer1.LocalReport.SetParameters(CantTarjetas)
        ReportViewer1.LocalReport.SetParameters(LoteTarjetas)

        Me.ReportViewer1.RefreshReport()
        btnConfimaCierre.Enabled = True
        If proceso < 2 Then proceso = 1
    End Sub
    Private Function valorNumero(numero As String) As Decimal
        If Val(numero) = 0 Then Return 0
        'numero.Replace(".", ".")
        Return Convert.ToDecimal(numero)
    End Function
    Private Sub leerOpciones()
        Dim esp As String = ""
        det = ""
        vend = ""
        suc = ""
        ptovta = ""
        codfac = ""
        coddev = ""
        codret = ""
        fecDesde = txtFechaDel.Value
        fecHasta = txtFechaAl.Value
        opcionreporte = ""
        If cboPtoVta.SelectedValue Is Nothing Then cboPtoVta.SelectedValue = "0"
        If cboPtoVta.SelectedValue.ToString() = "0" Then
            ptovta = ""
            opcionreporte = "TODOS"
        Else
            ptovta = cboPtoVta.Text
            opcionreporte = ptovta
        End If
    End Sub

    Private Function CalcularDataSet(ByVal cadena As String) As DataSet
        Dim ssql As String = cadena
        Dim sqlAdap As New SqlDataAdapter(ssql, datosEmpresa.strConxAdcom)
        'If conectar.State = ConnectionState.Closed Then conectar.Open()
        Dim datS As New DataSet()
        sqlAdap.Fill(datS, "Activos")
        'conectar.Close()
        sqlAdap.Dispose()
        Return datS
    End Function

    Private Sub txtFechaDel_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ReportViewer1.Clear()
    End Sub

    Private Sub txtFechaAl_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ReportViewer1.Clear()
    End Sub

    'Private Sub txtCodFin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodFin.TextChanged
    '    ReportViewer1.Clear()
    'End Sub
    Private Sub cboSucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSucursal.SelectedIndexChanged
        ReportViewer1.Clear()
    End Sub

    Private Sub cboDoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPtoVta.SelectedIndexChanged
        ReportViewer1.Clear()
    End Sub

    Private Sub cboVendedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
        Dim b As New DaxMantDirectorio.BusDirectorio
        cod = b.BusDirect(cod, "", nom, "", "T", "")
        BuscaCliente = cod
    End Function
    Private Function nombre(ByVal cod As String) As String
        Dim nom As String = ""
        Dim conectar As New SqlConnection(datosEmpresa.strConxAdcom)
        conectar.Open()
        Dim cmd As New SqlCommand("select nombreImpresion from identificacion where codigo='" & cod & "'", conectar)
        Dim dat As SqlDataReader = Nothing
        dat = cmd.ExecuteReader()
        If dat.Read Then
            If Not IsDBNull(dat(0)) Then nom = dat(0).ToString()
        End If
        conectar.Close()
        conectar.Dispose()
        cmd.Dispose()
        dat.Close()
        Return nom
    End Function
#End Region

#Region "Salir"
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub
#End Region

    Private Sub txtEfectivo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEfectivo.KeyPress, txtTarjetas.KeyPress, txtCheques.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not (e.KeyChar = ".")
    End Sub

    Private Sub txtEfectivo_TextChanged(sender As Object, e As EventArgs) Handles txtEfectivo.TextChanged, txtTarjetas.TextChanged, txtCheques.TextChanged
        txtTotal.Text = (Val(txtEfectivo.Text) + Val(txtCheques.Text) + Val(txtTarjetas.Text)).ToString()
    End Sub

    Private Sub btnMovimientos_Click(sender As Object, e As EventArgs) Handles btnMovimientos.Click
        If (datosEmpresa.usr.ToUpper() <> "ADMINISTRADOR") Then Return
        Dim prog As New DaxMovCaja.frmEdit()
        prog.ShowDialog()
        prog.Dispose()
    End Sub

    Private Sub btnConfirmaCierre_Click(sender As Object, e As EventArgs) Handles btnConfimaCierre.Click
        If CierreConfirmado = True Then MessageBox.Show("El cierre de caja para este período ya fue realizado ? ", "Cierre de caja", MessageBoxButtons.OK, MessageBoxIcon.Error) : Return
        CierreConfirmado = RegistroCierresCaja.RegistrarcierreCaja(DatosCierre)
        If CierreConfirmado = False Then
            MessageBox.Show("El cierre de caja no pudo registrarse ? ", "Cierre de caja", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        saveImagen(DatosCierre.IdClave)
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub saveImagen(idclave As Decimal)
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        Dim Warnings As Warning() = Nothing
        Dim streamdIds As String() = Nothing
        Dim mimeType As String = Nothing
        Dim encoding As String = Nothing
        Dim extension As String = Nothing

        Dim bytes As Byte() = ReportViewer1.LocalReport.Render("PDF", Nothing, mimeType, encoding, extension, streamdIds, Warnings)
        Dim k As Integer = UBound(bytes)
        If k = 0 Then Return
        Dim pathFile As String = Path.Combine(PathDeImagenes, "CierresCaja\F" + DatosCierre.Sucursal + DatosCierre.PuntoDeVenta + DatosCierre.IdClave.ToString() + ".PDF")
        Dim fs As New FileStream(pathFile, FileMode.Create, FileAccess.Write)
        fs.Write(bytes, 0, k)
        fs.Close()

    End Sub
    Private Function PathDeImagenes() As String

        Dim pathImagenes As String = ""
        Dim dt As New DataTable
        dt = datosEmpresa.leeParametrosEmp("Emp_PathImagenes")
        If (dt.Rows.Count > 0) Then

            pathImagenes = "" + dt.Rows(0)("Emp_PathImagenes").ToString()
            dt.Dispose()

            If (pathImagenes.Length > 2) Then
                If (pathImagenes.Substring(pathImagenes.Length - 1, 1) <> "\") Then pathImagenes += "\"
            End If
        End If
        Return pathImagenes
    End Function
    Private Sub btnAbrir_Click(sender As Object, e As EventArgs) Handles btnAbrir.Click
        Dim prog As New Buscar.frmBuscar()
        Dim ssql As String = "SELECT cast(IdClave as varchar(20)) +' | '+ sucursal + ' | ' + PuntoDeVenta as Idclave, convert(varchar(17) ,FechaIni,13) as fechaini "
        ssql += ", case when (isnull(FechaFin,'1900/01/01') < '1900/12/12') then '' else convert(varchar(17) ,FechaFin, 13 ) end as Fechafin "
        ssql += " From DaxCiecaj "
        'ssql += " where isnull(FechaFin,'1900/01/01') > '1900/30/12'"
        If (datosEmpresa.usr.ToUpper() <> "ADMINISTRADOR") Then
            ssql += " where PuntoDeVenta = '" + cboPtoVta.Text + "' "
        End If
        ssql += " order by fecha desc , FechaIni desc, sucursal, PuntoDeVenta "
        Dim Ind As String = prog.Buscar(datosEmpresa.strConxAdcom, ssql, "IdClave", "Descripción", "", "BUSQUEDA DE CIERRES DE CAJA")
        Dim par() As String = Ind.Split(CType("|", Char()))

        If par.Length > 1 Then
            DatosCierre = RegistroCierresCaja.CargarDatosCaja(Trim(par(1)), Trim(par(2)), Convert.ToDecimal(Trim(par(0))))
            cargarCierreLeido()
            proceso = 2
            organizarBotones()
        End If

    End Sub
    Private Sub organizarBotones()


        cmbSucursal.Enabled = (proceso < 2)
        cboPtoVta.Enabled = cmbSucursal.Enabled
        Grupo.Enabled = cmbSucursal.Enabled
        GrupoEntregaCaja.Enabled = cmbSucursal.Enabled
        btnAbrir.Enabled = (proceso = 0)
        'btnActualizar.Enabled = False
        btnCerrar.Enabled = (proceso > 0)
        btnConfimaCierre.Enabled = (proceso = 1)
        btnOpciones.Enabled = False
        btnPdfOriginal.Enabled = (proceso = 2)
        If (datosEmpresa.usr.ToUpper <> "ADMINISTRADOR") Then
            Grupo.Enabled = False
            cboPtoVta.Enabled = False
            cmbSucursal.Enabled = False
            btnMovimientos.Visible = False
            'btnHorarios.Visible = False
        End If
    End Sub
    Private Sub cargarCierreLeido()
        With DatosCierre
            txtCantCheques.Text = .RecibidoNroCheques.ToString()
            txtCantTarjetas.Text = .RecibidoNroTarjetas.ToString()
            txtCheques.Text = .RecibidoCheques.ToString()
            txtEfectivo.Text = .RecibidoEfectivo.ToString()
            txtFechaAl.Value = .FechaFin
            txtFechaDel.Value = .FechaIni
            txtTarjetas.Text = .RecibidoTarjetas.ToString()
            cboPtoVta.SelectedValue = .PuntoDeVenta
            cmbSucursal.SelectedValue = datosEmpresa.suc
            CierreConfirmado = True
            Reporte()
        End With
    End Sub

    Private Sub btnPdfOriginal_Click(sender As Object, e As EventArgs) Handles btnPdfOriginal.Click
        Dim pathFile As String = Path.Combine(PathDeImagenes, "CierresCaja\F" + DatosCierre.Sucursal + DatosCierre.PuntoDeVenta + DatosCierre.IdClave.ToString() + ".PDF")
        Try
            Process.Start(pathFile)
        Catch ex As Exception
            MessageBox.Show("excepción : " + pathFile + vbCr + ex.Message)
        End Try
    End Sub

    Private Sub txtFechaAl_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaAl.ValueChanged

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        DatosIniciales()
    End Sub

    Private Sub btnHorarios_Click(sender As Object, e As EventArgs)
        Dim prog As New PtoVentaDefinicion.frmHorarios
        prog.ShowDialog()
        prog.Dispose()
    End Sub

    Private Sub frmCierrCaja_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If (CierreConfirmado = False And esgeneral = False) Then
            If MessageBox.Show("Confirma salir sin registrar el cierre de caja ? ", "Cierre de caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub btnResumenGeneral_Click(sender As Object, e As EventArgs) Handles BtnResumenGeneral.Click
        CierreGeneral()
    End Sub
End Class

