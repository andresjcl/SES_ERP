Imports System.Data.SqlClient
Imports DattCom

Public Class FormPago
    Dim cargar As Boolean = False
    Dim cambios As Integer = 0
    Dim existe As Boolean = False
    Dim accion As String = "Nuevo"
    Dim fp As New FormasDePago
    Dim strConxIvaret As String
    Dim strConxAdcom As String
    Dim strConxDaxsys As String

    Public Sub FormPago(strconx As String, striva As String, strSys As String)

        strConxAdcom = strconx
        strConxIvaret = striva
        strConxDaxsys = strSys

    End Sub
#Region "Datos Iniciales"
    Private Sub FrmFormP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'conectarAdcomDx.ConnectionString = StrConxadcom
        'conectarAdcomDx.Open()
        bloquear(True)
        CargarCombos()
        cambios = 0
    End Sub
    Private Sub CargarCombos()
        Dim Prog As New DaxCombobx.CargCmbBox
        Prog.DaxCombosReferencia("paises", datosEmpresa.strConIniSis, cmbSriPais, False)
        Dim ssql As String = "SELECT cast(Código as varchar(5)) as Código, Descripción FROM FormasDePago"
        Dim dt As New DataTable()
        Dim da As New SqlDataAdapter(ssql, datosEmpresa.strConxIvaret)
        da.Fill(dt)
        cmbSriFormaDePago.DataSource = dt
        cmbSriFormaDePago.DisplayMember = "Descripción"
        cmbSriFormaDePago.ValueMember = "Código"

        ssql = "SELECT Código, Descripción FROM tiposPago"
        Dim tp As New DataTable()
        da = New SqlDataAdapter(ssql, datosEmpresa.strConxIvaret)
        da.Fill(tp)
        cmbSriTipoDePago.DataSource = tp
        cmbSriTipoDePago.DisplayMember = "Descripción"
        cmbSriTipoDePago.ValueMember = "Código"

        'dt.Dispose()
        'da.Dispose() 
        'Prog.DaxCombosReferencia("TipoPagoSri", StrConxDaxsys, cmbSriFormaDePago, False)
        'Prog.DaxCombosReferencia("FormaPagoSri", StrConxDaxsys, cmbSriTipoDePago, False)
    End Sub
    Private Sub bloquear(ByVal op As Boolean)
        btnAbrir.Enabled = op
        BtnNuevo.Enabled = op
        btnSalir.Enabled = op
        btnGuardar.Enabled = Not op
        btnEliminar.Enabled = Not op
        btnCancelar.Enabled = Not op
        txtAbreviacion.Enabled = Not op
        txtDescripcion.Enabled = Not op
        GroupBox1.Enabled = Not op
        GroupBox3.Enabled = Not op
        txtIdCont1.Enabled = Not op
        txtIdCont2.Enabled = Not op
        btnIdc1.Enabled = Not op
        btnIdc2.Enabled = Not op
    End Sub
    Private Sub limpiar(ByVal Obj As Object)
        txtAbreviacion.Text = ""
        TxtContadoSRI.CheckState = CheckState.Unchecked
        txtCuo1.Text = ""
        txtCuo2.Text = ""
        txtCuo3.Text = ""
        txtCuo4.Text = ""
        txtCuo5.Text = ""
        txtCuo6.Text = ""
        txtCuo7.Text = ""
        txtCuo8.Text = ""
        txtCuo9.Text = ""
        txtCuo10.Text = ""
        txtCuo11.Text = ""
        txtCuo12.Text = ""
        optCredito.Checked = True
        txtIdCont1.Text = ""
        txtIdCont2.Text = ""
        lblCuenta1.Text = ""
        lblCuenta2.Text = ""
        optPlazoFijo.Checked = True
        txtNumCuotas.Text = ""
        cmbSriTipoDePago.SelectedValue = ""
        cmbSriPais.SelectedValue = ""
        cmbSriFormaDePago.SelectedValue = ""
        txtDescripcion.Text = ""
        txtDiasCuotasfijas.Text = ""
        fp = New FormasDePago(datosEmpresa.strConxAdcom)
    End Sub
#End Region

#Region "Nuevo"
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        nuevo()
        cambios = 0
    End Sub
    Private Sub nuevo()
        'Dim fp As New FormasDePago(StrConxadcom)
        'fp = New FormasDePago(StrConxadcom)
        limpiar(Me)
        bloquear(False)
        GroupBox2.Visible = False
        GroupBox4.Visible = False
    End Sub

    Private Sub txtAbreviacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAbreviacion.KeyDown
        If e.KeyCode = Keys.Enter Then
            cargar = True
            CargarDatos(txtAbreviacion.Text)
            If existe = True Then accion = "Abrir" Else accion = "Nuevo"
            cargar = False
            cambios = 0
        End If
    End Sub

    Private Sub txtAbreviacion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAbreviacion.LostFocus
        cargar = True
        CargarDatos(txtAbreviacion.Text)
        If existe = True Then accion = "Abrir" Else accion = "Nuevo"
        cargar = False
        cambios = 0
    End Sub
    Private Sub txtAbreviacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAbreviacion.TextChanged
        cambios += 1
    End Sub
    Private Sub CargaCta(ByVal txtCta As TextBox, ByVal lbl As Label)
        Dim ctacte As String = ""
        Dim cta As New CtaMtn.BuscaCta
        ctacte = cta.BuscaCtaCtb("", "S")
        If ctacte <> "" Then txtCta.Text = ctacte : lbl.Text = nombre("select cta_nombre from adccta where cta_codigo='" & txtCta.Text & "'").ToString
    End Sub
    Private Function nombre(ByVal ssql As String) As String
        Dim nom As String = ""
        'Dim cmd As New SqlCommand(ssql, conectarAdcomDx)
        Dim dat As SqlDataReader = SqlDatos.leerBaseAdcom(ssql)
        'If conectarAdcomDx.State = ConnectionState.Closed Then conectarAdcomDx.Open()
        'dat = cmd.ExecuteReader()
        If dat.Read Then
            If Not IsDBNull(dat(0)) Then nom = dat(0).ToString
        End If
        'conectarAdcomDx.Close()
        dat.Close()
        'cmd.Dispose()
        Return nom
    End Function
    Private Sub btnIdc1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIdc1.Click
        CargaCta(txtIdCont1, lblCuenta1)
    End Sub

    Private Sub btnIdc2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIdc2.Click
        CargaCta(txtIdCont2, lblCuenta2)
    End Sub
#End Region

#Region "Opciones"
    Private Sub optPlazoFijo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPlazoFijo.CheckedChanged
        If optPlazoFijo.Checked = True Then
            GroupBox2.Visible = True
            GroupBox4.Visible = True
            fp.plazofv = 1
        Else
            GroupBox4.Visible = True
        End If
        cambios += 1
    End Sub
    Private Sub optVariable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optVariable.CheckedChanged
        If optVariable.Checked = True Then
            txtDiasCuotasfijas.Text = ""
            GroupBox4.Visible = False
            Panel1.Visible = True
            fp.plazofv = 2
        Else
            GroupBox4.Visible = True
            Panel1.Visible = False
        End If
        cambios += 1
    End Sub
    Private Sub optContado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optContado.CheckedChanged
        If optContado.Checked Then chkGenerarIngreso.Visible = True : fp.formadepago = 1 Else chkGenerarIngreso.Visible = False : fp.formadepago = 2
        cambios += 1
    End Sub
    Private Sub optEfectivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optEfectivo.CheckedChanged
        If optEfectivo.Checked = True Then fp.tipoformapago = 0 : desmarcarOp()
        cambios += 1
    End Sub
    Private Sub optTarjeta_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTarjeta.CheckedChanged
        If optTarjeta.Checked = True Then fp.tipoformapago = 1 : desmarcarOp()
        cambios += 1
    End Sub

    Private Sub optCruceDoc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCruceDoc.CheckedChanged
        If optCruceDoc.Checked = True Then fp.tipoformapago = 2 : desmarcarOp()
        cambios += 1
    End Sub

    Private Sub optCheque_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCheque.CheckedChanged
        If optCheque.Checked = True Then fp.tipoformapago = 3 : desmarcarOp()
        cambios += 1
    End Sub
    Private Sub optPlanCuotas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPlanCuotas.CheckedChanged
        If optPlanCuotas.Checked = True Then
            GroupBox2.Visible = True
            GroupBox4.Visible = True
            If cargar <> True Then optPlazoFijo.Checked = True
            fp.tipoformapago = 4
        Else
            GroupBox2.Visible = False
            GroupBox4.Visible = False
        End If
        cambios += 1
    End Sub

    Private Sub optGarFecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optGarFecha.CheckedChanged
        If optGarFecha.Checked = True Then fp.tipoformapago = 5 : desmarcarOp()
        cambios += 1
    End Sub

    Private Sub optRolPag_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optRolPag.CheckedChanged
        If optRolPag.Checked = True Then
            GroupBox2.Visible = True
            GroupBox4.Visible = False
            ' Panel1.Visible = False
            optPlazoFijo.Visible = False
            optVariable.Visible = False
            fp.tipoformapago = 6
        Else
            GroupBox2.Visible = False
            optPlazoFijo.Visible = True
            optVariable.Visible = True
        End If
        cambios += 1
    End Sub
    Private Sub chkGenerarIngreso_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGenerarIngreso.CheckedChanged
        If chkGenerarIngreso.Checked = True Then fp.GeneraIngreso = 1 Else fp.GeneraIngreso = 0
        cambios += 1
    End Sub

    Private Sub optCredito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCredito.CheckedChanged
        If optCredito.Checked = True Then fp.formadepago = 2 Else fp.formadepago = 1
        cambios += 1
    End Sub
    Private Sub desmarcarOp()
        optPlazoFijo.Checked = False
        optVariable.Checked = False
        GroupBox2.Visible = False
        GroupBox4.Visible = False
        Panel1.Visible = False
    End Sub

    Private Sub txtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged
        cambios += 1
    End Sub

    Private Sub txtNumCuotas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumCuotas.KeyPress
        If InStr(1, "0123456789.," & Chr(8), e.KeyChar) = 0 Then e.KeyChar = CChar("")
    End Sub
    Private Sub txtNumCuotas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumCuotas.TextChanged
        cambios += 1
    End Sub

    Private Sub txtIdCont1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIdCont1.TextChanged
        cambios += 1
    End Sub

    Private Sub txtIdCont2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIdCont2.TextChanged
        cambios += 1
    End Sub

    Private Sub txtCuo1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuo1.KeyPress
        If InStr(1, "0123456789.," & Chr(8), e.KeyChar) = 0 Then e.KeyChar = CChar("")
    End Sub

    Private Sub txtCuo1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCuo1.TextChanged
        cambios += 1
    End Sub

    Private Sub txtCuo2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuo2.KeyPress
        If InStr(1, "0123456789.," & Chr(8), e.KeyChar) = 0 Then e.KeyChar = CChar("")
    End Sub

    Private Sub txtCuo2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCuo2.TextChanged
        cambios += 1
    End Sub

    Private Sub txtCuo3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuo3.KeyPress
        If InStr(1, "0123456789.," & Chr(8), e.KeyChar) = 0 Then e.KeyChar = CChar("")
    End Sub

    Private Sub txtCuo3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCuo3.TextChanged
        cambios += 1
    End Sub

    Private Sub txtCuo4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuo4.KeyPress
        If InStr(1, "0123456789.," & Chr(8), e.KeyChar) = 0 Then e.KeyChar = CChar("")
    End Sub

    Private Sub txtCuo4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCuo4.TextChanged
        cambios += 1
    End Sub

    Private Sub txtCuo5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuo5.KeyPress
        If InStr(1, "0123456789.," & Chr(8), e.KeyChar) = 0 Then e.KeyChar = CChar("")
    End Sub

    Private Sub txtCuo5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCuo5.TextChanged
        cambios += 1
    End Sub

    Private Sub txtCuo6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuo6.KeyPress
        If InStr(1, "0123456789.," & Chr(8), e.KeyChar) = 0 Then e.KeyChar = CChar("")
    End Sub

    Private Sub txtCuo6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCuo6.TextChanged
        cambios += 1
    End Sub

    Private Sub txtCuo7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuo7.KeyPress
        If InStr(1, "0123456789.," & Chr(8), e.KeyChar) = 0 Then e.KeyChar = CChar("")
    End Sub

    Private Sub txtCuo7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCuo7.TextChanged
        cambios += 1
    End Sub

    Private Sub txtCuo8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuo8.KeyPress
        If InStr(1, "0123456789.," & Chr(8), e.KeyChar) = 0 Then e.KeyChar = CChar("")
    End Sub

    Private Sub txtCuo8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCuo8.TextChanged
        cambios += 1
    End Sub

    Private Sub txtCuo9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuo9.KeyPress
        If InStr(1, "0123456789.," & Chr(8), e.KeyChar) = 0 Then e.KeyChar = CChar("")
    End Sub

    Private Sub txtCuo9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCuo9.TextChanged
        cambios += 1
    End Sub

    Private Sub txtCuo10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuo10.KeyPress
        If InStr(1, "0123456789.," & Chr(8), e.KeyChar) = 0 Then e.KeyChar = CChar("")
    End Sub

    Private Sub txtCuo10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCuo10.TextChanged
        cambios += 1
    End Sub

    Private Sub txtCuo11_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuo11.KeyPress
        If InStr(1, "0123456789.," & Chr(8), e.KeyChar) = 0 Then e.KeyChar = CChar("")
    End Sub

    Private Sub txtCuo11_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCuo11.TextChanged
        cambios += 1
    End Sub

    Private Sub txtCuo12_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuo12.KeyPress
        If InStr(1, "0123456789.," & Chr(8), e.KeyChar) = 0 Then e.KeyChar = CChar("")
    End Sub
    Private Sub txtCuotasfijas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiasCuotasfijas.KeyPress
        If InStr(1, "0123456789.," & Chr(8), e.KeyChar) = 0 Then e.KeyChar = CChar("")
    End Sub
    Private Sub txtCuo12_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCuo12.TextChanged
        cambios += 1
    End Sub
#End Region

#Region "Abrir"
    ' FORMA DE PAGO:        1--> CONTADO
    '                       2--> CREDITO
    ' TIPO FORMA DE PAGO :  0--> EFECTIVO
    '                       1--> TARJETA
    '                       2--> CRUCE DOCUMENTO
    '                       3--> CHEQUE
    '                       4--> PLAN CUOTAS
    '                       5--> GARANTIAS A LA FECHA (cheques postfechados)
    '                       6--> ROL DE PAGOS
    Private Sub btnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrir.Click
        abrir()
    End Sub
    Private Sub abrir()
        cargar = True
        limpiar(Me)
        Dim busk As New Buscar.frmBuscar
        Dim cod As String = ""
        cod = busk.Buscar(datosEmpresa.strConxAdcom, "select IdFormasDePago as Codigo,Descripcion from formasDePago where IdFormasDePago <>'' ", "IdFormasDePago", "Descripcion", "Consulta", "Formas de Pago")
        If cod <> "" Then
            txtAbreviacion.Text = cod : CargarDatos(cod) : accion = "Abrir"
            bloquear(False)
            cambios = 0
        End If
        cargar = False
    End Sub

    Private Sub CargarDatos(ByVal idforma As String)
        fp = New comercP.FormasDePago(datosEmpresa.strConxAdcom)
        fp = FormasDePago.Buscar(" idformasdePago = '" & idforma & "' ")
        'cargarFormaPago(idforma)
        If fp Is Nothing Then fp = New comercP.FormasDePago(datosEmpresa.strConxAdcom) : Return
        If fp.Descripcion <> "" Then txtDescripcion.Text = fp.Descripcion : accion = "abrir"

        Select Case fp.tipoformapago
            Case 0
                optEfectivo.Checked = True : desmarcarOp()
            Case 1
                optTarjeta.Checked = True : desmarcarOp()
            Case 2
                optCruceDoc.Checked = True : desmarcarOp()
            Case 3
                optCheque.Checked = True : desmarcarOp()
            Case 4
                optPlanCuotas.Checked = True
                If fp.plazofv = 1 Then optPlazoFijo.Checked = True Else If fp.plazofv = 2 Then optVariable.Checked = True
                txtDiasCuotasfijas.Text = fp.DiasCuotaFijas.ToString
                txtCuo1.Text = fp.DiasCuotaVar0.ToString
                txtCuo2.Text = fp.DiasCuotaVar1.ToString
                txtCuo3.Text = fp.DiasCuotaVar2.ToString
                txtCuo4.Text = fp.DiasCuotaVar3.ToString
                txtCuo5.Text = fp.DiasCuotaVar4.ToString
                txtCuo6.Text = fp.DiasCuotaVar5.ToString
                txtCuo7.Text = fp.DiasCuotaVar6.ToString
                txtCuo8.Text = fp.DiasCuotaVar7.ToString
                txtCuo9.Text = fp.DiasCuotaVar8.ToString
                txtCuo10.Text = fp.DiasCuotaVar9.ToString
                txtCuo11.Text = fp.DiasCuotaVar10.ToString
                txtCuo12.Text = fp.DiasCuotaVar11.ToString

                'fp.NumeroDeCuotas = CShort(Val(txtNumCuotas.Text))
                'fp.DiasCuotaFijas = CShort(Val(txtCuo1.Text))
                'fp.DiasCuotaVar0 = CShort(Val(txtCuo1.Text))
                'fp.DiasCuotaVar1 = CShort(Val(txtCuo2.Text))
                'fp.DiasCuotaVar2 = CShort(Val(txtCuo3.Text))
                'fp.DiasCuotaVar3 = CShort(Val(txtCuo4.Text))
                'fp.DiasCuotaVar4 = CShort(Val(txtCuo5.Text))
                'fp.DiasCuotaVar5 = CShort(Val(txtCuo6.Text))
                'fp.DiasCuotaVar6 = CShort(Val(txtCuo7.Text))
                'fp.DiasCuotaVar7 = CShort(Val(txtCuo8.Text))
                'fp.DiasCuotaVar8 = CShort(Val(txtCuo9.Text))
                'fp.DiasCuotaVar9 = CShort(Val(txtCuo10.Text))
                'fp.DiasCuotaVar10 = CShort(Val(txtCuo11.Text))
                'fp.DiasCuotaVar11 = CShort(Val(txtCuo12.Text))
            Case 5
                optGarFecha.Checked = True
            Case 6
                optRolPag.Checked = True
        End Select

        If fp.formadepago = 1 Then optContado.Checked = True Else optCredito.Checked = True
        If fp.GeneraIngreso = 1 Then chkGenerarIngreso.Checked = True Else chkGenerarIngreso.Checked = False
        txtNumCuotas.Text = fp.NumeroDeCuotas.ToString
        txtDiasCuotasfijas.Text = fp.DiasCuotaFijas.ToString
        txtIdCont1.Text = fp.Id_Contable : lblCuenta1.Text = nombre("select cta_nombre from adccta where cta_codigo='" & txtIdCont1.Text & "'")
        txtIdCont2.Text = fp.Id_Contable2 : lblCuenta2.Text = nombre("select cta_nombre from adccta where cta_codigo='" & txtIdCont2.Text & "'")
        TxtContadoSRI.Checked = CBool(IIf(CInt(fp.ContadoSri) = 1, True, False))
        cmbSriTipoDePago.SelectedValue = fp.SRI_pagoLocExt
        Try
            cmbSriFormaDePago.SelectedValue = fp.SRI_formaDePago
        Catch
        End Try

        cmbSriPais.SelectedValue = fp.SRI_pagoPais
        chkDobleTributacion.CheckState = CType(IIf(fp.SRI_dobleTributacion = "SI", CheckState.Checked, CheckState.Unchecked), CheckState)
        chkSujetoARetencion.CheckState = CType(IIf(fp.SRI_pagoSujetoRetencion = "SI", CheckState.Checked, CheckState.Unchecked), CheckState)
    End Sub
    'Private Sub cargarFormaPago(ByVal idForma As String)
    '    Dim fp As New FormasDePago(StrConxadcom)
    '    FormasDePago.Buscar(" idFormasDePago = '" & idForma & "' ")
    '    Descripcion = fp.Descripcion
    '    formadepago = fp.formadepago
    '    NumeroDeCuotas = fp.NumeroDeCuotas
    '    Institucion = fp.Institucion
    '    tipoformapago = fp.tipoformapago
    '    plazofv = fp.plazofv
    '    DiasCuotaFijas = fp.DiasCuotaFijas
    '    DiasCuotaVar0 = fp.DiasCuotaVar0
    '    DiasCuotaVar1 = fp.DiasCuotaVar1
    '    DiasCuotaVar2 = fp.DiasCuotaVar2
    '    DiasCuotaVar3 = fp.DiasCuotaVar3
    '    DiasCuotaVar4 = fp.DiasCuotaVar4
    '    DiasCuotaVar5 = fp.DiasCuotaVar5
    '    DiasCuotaVar6 = fp.DiasCuotaVar6
    '    DiasCuotaVar7 = fp.DiasCuotaVar7
    '    DiasCuotaVar8 = fp.DiasCuotaVar8
    '    DiasCuotaVar9 = fp.DiasCuotaVar9
    '    DiasCuotaVar10 = fp.DiasCuotaVar10
    '    DiasCuotaVar11 = fp.DiasCuotaVar11
    '    GeneraIngreso = fp.GeneraIngreso
    '    CancelaFactura = fp.CancelaFactura
    '    ContadoSRI = fp.ContadoSRI
    '    Id_Contable = fp.Id_Contable
    '    Id_Contable2 = fp.Id_Contable2
    '    existe = IIf(fp.IdFormasDePago > "", True, False)
    'End Sub
#End Region

#Region "Guardar/Modificar"
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If txtAbreviacion.Text = "" Then MsgBox("Ingrese la abreviación", MsgBoxStyle.Information) : txtAbreviacion.Focus() : Exit Sub
        guardar()
        cancelar()
    End Sub

    Private Sub guardar()
        fp.IdFormasDePago = txtAbreviacion.Text
        fp.Descripcion = txtDescripcion.Text
        fp.formadepago = CShort(IIf(optCredito.Checked, 2, 1))
        fp.GeneraIngreso = CShort(IIf(chkGenerarIngreso.Checked, 1, 0))
        fp.plazofv = CByte(IIf(optPlazoFijo.Checked, 1, 2))
        fp.NumeroDeCuotas = CShort(Val(txtNumCuotas.Text))
        fp.DiasCuotaFijas = CShort(Val(txtDiasCuotasfijas.Text))
        fp.DiasCuotaVar0 = CShort(Val(txtCuo1.Text))
        fp.DiasCuotaVar1 = CShort(Val(txtCuo2.Text))
        fp.DiasCuotaVar2 = CShort(Val(txtCuo3.Text))
        fp.DiasCuotaVar3 = CShort(Val(txtCuo4.Text))
        fp.DiasCuotaVar4 = CShort(Val(txtCuo5.Text))
        fp.DiasCuotaVar5 = CShort(Val(txtCuo6.Text))
        fp.DiasCuotaVar6 = CShort(Val(txtCuo7.Text))
        fp.DiasCuotaVar7 = CShort(Val(txtCuo8.Text))
        fp.DiasCuotaVar8 = CShort(Val(txtCuo9.Text))
        fp.DiasCuotaVar9 = CShort(Val(txtCuo10.Text))
        fp.DiasCuotaVar10 = CShort(Val(txtCuo11.Text))
        fp.DiasCuotaVar11 = CShort(Val(txtCuo12.Text))
        fp.ContadoSri = CBool(IIf(TxtContadoSRI.Checked, 1, 0))
        fp.Id_Contable = txtIdCont1.Text
        fp.Id_Contable2 = txtIdCont2.Text
        fp.SRI_formaDePago = CStr(cmbSriFormaDePago.SelectedValue)
        fp.SRI_pagoLocExt = Strings.Right("00" & CStr(cmbSriTipoDePago.SelectedValue), 2)
        fp.SRI_pagoPais = Strings.Right("000" & CStr(cmbSriPais.SelectedValue), 3)
        fp.SRI_dobleTributacion = CStr(IIf(chkDobleTributacion.CheckState = CheckState.Checked, "SI", "NO"))
        fp.SRI_pagoSujetoRetencion = CStr(IIf(chkSujetoARetencion.CheckState = CheckState.Checked, "SI", "NO"))
        fp.Actualizar()
    End Sub
#End Region

#Region "Eliminar"
    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        eliminar()
    End Sub
    Private Sub eliminar()
        Dim ssql As String = "Select TOP (1) PAG_IDPAGO from adcpag where Pag_Idpago = '" & txtAbreviacion.Text & "' "
        ssql += " UNION ALL "
        ssql += " Select TOP (1) FORMAPAGO from CLIENTE where FORMAPAGO = '" & txtAbreviacion.Text & "' "
        ssql += " UNION ALL"
        ssql += " Select TOP (1) FORMAPAGO from PROVEEDOR where FORMAPAGO = '" & txtAbreviacion.Text & "' "
        Dim conn As New SqlConnection(datosEmpresa.strConxAdcom)
        conn.Open()
        Dim da As New SqlDataAdapter(ssql, datosEmpresa.strConxAdcom)
        Dim dt As New DataTable
        Dim r As Integer = da.Fill(dt)
        If r = 0 Then
            If MsgBox("Esta seguro que desea eliminar la forma de pago?", MsgBoxStyle.YesNo) = vbYes Then
                'Dim fp As New FormasDePago(StrConxadcom)
                fp.IdFormasDePago = txtAbreviacion.Text
                fp.Borrar()
                cancelar()
            End If
        Else
            MsgBox("No puede eliminar esta forma de pago, está siendo utilizada " & vbCr & "puede estar utilizada en documentos, clientes o proveedores")
        End If
        conn.Close()
        conn.Dispose()
        dt.Dispose()
        da.Dispose()
    End Sub
#End Region

#Region "Cancelar/Salir"
    Private Sub FrmFormP_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        salirCancelar()
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        salirCancelar()
    End Sub
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        salirCancelar()
        Me.Close()
    End Sub
    Private Sub salirCancelar()
        Dim conf As Integer = 0
        If cambios > 0 Then
            conf = MsgBox("Desea guardar los cambios?", MsgBoxStyle.YesNoCancel)
            If conf = vbYes Then
                guardar()
            ElseIf conf = vbNo Then : cancelar()
            Else : Exit Sub
            End If
        Else : cancelar()
        End If
    End Sub
    Private Sub cancelar()
        optEfectivo.Checked = True
        Panel1.Visible = False
        limpiar(Me)
        bloquear(True)
        cambios = 0
        accion = "Nuevo"
    End Sub
#End Region

End Class
