Imports System.Data.SqlClient
Imports DattCom

Public Class frmPar
    Dim empresaCod As Integer = 0
    Dim Emp_Codigo As Integer = 0
    Dim DefCta_NumNiveles As Integer = 0
    Dim DefCta_NumGrupos As Integer = 0
    Dim DefCta_NumDigNivel As Integer = 0
    Dim DefCta_NumNiveles1 As Integer = 0
    Dim DefCta_NumGrupos1 As Integer = 0
    Dim DefCta_NumDigNivel1 As String = ""
    Dim Par_ConTipCierre As String = ""
    Dim Par_InvTipCierre As String = ""
    Dim Par_VenIVA As String = ""
    Dim Par_VenSNEmp As Boolean = False
    Dim Par_VenSNAcuDoc As Boolean = False
    Dim Par_ComIVA As String = ""
    Dim Par_ComSNEmp As Boolean = False
    Dim Par_ComSNAcuDoc As Boolean = False
    Dim Par_AcfNumNiv As Integer = 0
    Dim Par_RolCodMay As String = ""
    Dim Par_RolTur As Integer = 0
    Dim Par_SucPri As String = ""
    Dim Par_ClvDsc As String = ""
    Dim Par_ClvIVA As String = ""
    Dim Par_AcumHis As Boolean = False
    Dim Par_FecDes As Integer = 0
    Dim Par_Numerodigitos As Integer = 0
    Dim Par_LimAtrasoEntrada As Integer = 0
    Dim Par_LimExtraSalida As Integer = 0
    Dim Par_LimExtraEntrada As Integer = 0
    Dim Par_DocPrincipalVta As String = ""
    Dim Par_Cheques As Integer = 0
    Dim Par_PagoCompras As String = ""
    Dim DefCtaV As Integer = 0
    Dim Par_DigitosCostos As Integer = 0
    Dim Par_DigitosPrecios As Integer = 0
    Dim Par_CruceDocSucursal As Integer = 0
    Dim Emp_PathImagenes As String = ""
    Dim CtaLocalEmail As String = ""
    Dim Emp_DiasMensualesAcf As Integer = 0
    Dim conectar As New SqlConnection()
    Dim path_tmpServer As String = ""
    Dim LongCodDirectorio As Int32 = 0
    Dim par_ValiDir As Integer = 0
    Dim par_ValiSRI As Int32 = 0
    Dim par_UrlSRI As String = ""


#Region "Datos Iniciales"

    Private Sub frmPar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarCombos()
        cargarDatos(CStr(empresaCod))
        CargarDatCie(CStr(empresaCod))
    End Sub
    Private Sub CargarCombos()
        Dim cbo As New DaxCombobx.CargCmbBox

        cbo.DaxCombosSuc(CStr(empresaCod), False, DattCom.datosEmpresa.strConIniSis, cboSuc)
        Try
            cbo.DaxCombosFormPago(DattCom.datosEmpresa.strConxAdcom, cboFrmPagCmp)
            cbo.DaxCombosFormPago(DattCom.datosEmpresa.strConxAdcom, cboFrmPagVta)
            '            cbo.DaxCombosDoc("ING", "", False, DattCom.datosEmpresa.strConxAdcom, cboTarjeta)
        Catch EE As Exception
            MsgBox("Revise la base de datos registrada, no se puede accesar")
        End Try
    End Sub
    Private Sub btnNuevSuc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevSuc.Click
        Dim suc As New frmSuc
        suc.Sucursales(empresaCod, DattCom.datosEmpresa.Emp_Nombre)
    End Sub
    Private Sub cboNiveles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNiveles.SelectedIndexChanged
        Niveles(CInt(cboNiveles.Text))
    End Sub
    Private Sub cboNivelesPresp_SelectedIndexChanged(sender As Object, e As EventArgs)
        NivelesPre(CInt(cboNivelesPresp.Text))
    End Sub

    Private Sub txtUltCierre_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If txtUltCierre.Text <> "  /  /" Then
            If Not IsDate(txtUltCierre.Text) Then
                MsgBox("Ingrese una fecha válida", MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub txtRegDocFech_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If txtRegDocFech.Text <> "  /  /" Then
            If Not IsDate(txtRegDocFech.Text) Then
                MsgBox("Ingrese una fecha válida", MsgBoxStyle.Information)
                txtRegDocFech.Text = ""
            End If
        End If
    End Sub
    Private Sub Niveles(ByVal num As Integer)
        Select Case num
            Case 4
                txtN5.Visible = False
                txtN6.Visible = False
                txtN7.Visible = False
                txtN8.Visible = False
            Case 5
                txtN5.Visible = True
                txtN6.Visible = False
                txtN7.Visible = False
                txtN8.Visible = False
            Case 6
                txtN5.Visible = True
                txtN6.Visible = True
                txtN7.Visible = False
                txtN8.Visible = False
            Case 7
                txtN5.Visible = True
                txtN6.Visible = True
                txtN7.Visible = True
                txtN8.Visible = False
            Case 8
                txtN5.Visible = True
                txtN6.Visible = True
                txtN7.Visible = True
                txtN8.Visible = True
        End Select
    End Sub
    Private Sub NivelesPre(ByVal num As Integer)
        Select Case num
            Case 4
                txtN5P.Visible = False
                txtN6P.Visible = False
                txtN7P.Visible = False
                txtN8P.Visible = False
            Case 5
                txtN5P.Visible = True
                txtN6P.Visible = False
                txtN7P.Visible = False
                txtN8P.Visible = False
            Case 6
                txtN5P.Visible = True
                txtN6P.Visible = True
                txtN7P.Visible = False
                txtN8P.Visible = False
            Case 7
                txtN5P.Visible = True
                txtN6P.Visible = True
                txtN7P.Visible = True
                txtN8P.Visible = False
            Case 8
                txtN5P.Visible = True
                txtN6P.Visible = True
                txtN7P.Visible = True
                txtN8P.Visible = True
        End Select
    End Sub
#End Region

#Region "Cargar Parametros"

    Private Sub leerPar(ByVal emp As String)
        Try
            Dim p As daxClassEmp.Emp_Par = daxClassEmp.Emp_Par.Buscar(" emp_codigo = " & emp)

            If p Is Nothing Then
                ' Si no se encontró el objeto, puedes registrar, mostrar mensaje o simplemente salir
                Exit Sub
            End If

            Emp_Codigo = p.Emp_Codigo
            DefCta_NumNiveles = p.DefCta_NumNiveles
            DefCta_NumGrupos = p.DefCta_NumGrupos
            DefCta_NumDigNivel = Convert.ToInt32("0" & p.DefCta_NumDigNivel)
            DefCta_NumNiveles1 = p.DefCta_NumNiveles1
            DefCta_NumGrupos1 = p.DefCta_NumGrupos1
            DefCta_NumDigNivel1 = p.DefCta_NumDigNivel1
            Par_ConTipCierre = p.Par_ConTipCierre
            Par_InvTipCierre = p.Par_InvTipCierre
            Par_VenIVA = p.Par_VenIVA
            Par_VenSNEmp = p.Par_VenSNEmp
            Par_VenSNAcuDoc = p.Par_VenSNAcuDoc
            Par_ComIVA = p.Par_ComIVA
            Par_ComSNEmp = p.Par_ComSNEmp
            Par_ComSNAcuDoc = p.Par_ComSNAcuDoc
            Par_AcfNumNiv = p.Par_AcfNumNiv
            Par_RolCodMay = p.Par_RolCodMay
            Par_RolTur = p.Par_RolTur
            Par_SucPri = p.Par_SucPri
            Par_ClvDsc = p.Par_ClvDsc
            Par_ClvIVA = p.Par_ClvIVA
            Par_AcumHis = p.Par_AcumHis
            Par_FecDes = p.Par_FecDes
            Par_Numerodigitos = p.Par_Numerodigitos
            Par_LimAtrasoEntrada = p.Par_LimAtrasoEntrada
            Par_LimExtraSalida = p.Par_LimExtraSalida
            Par_LimExtraEntrada = p.Par_LimExtraEntrada
            Par_DocPrincipalVta = p.Par_DocPrincipalVta
            Par_Cheques = p.Par_Cheques
            Par_PagoCompras = p.Par_PagoCompras
            DefCtaV = Convert.ToInt16(p.DefCtaV)
            Par_DigitosCostos = p.Par_DigitosCostos
            Par_DigitosPrecios = p.Par_DigitosPrecios
            Par_CruceDocSucursal = p.Par_CruceDocSucursal
            Emp_PathImagenes = p.Emp_PathImagenes
            CtaLocalEmail = p.CtaLocalEmail
            path_tmpServer = p.path_tmpServer
            Emp_DiasMensualesAcf = p.Emp_DiasMensualesAcf
            LongCodDirectorio = p.LongCodDirectorio
            par_ValiDir = p.par_ValiDir
            par_UrlSRI = p.par_UrlSRI
            par_ValiSRI = p.par_ValiSRI

        Catch ex As Exception
            ' Aquí puedes registrar el error o ignorarlo según necesidad
            ' Ejemplo: LogError("Error en leerPar: " & ex.Message)
        End Try
    End Sub
    Private Sub cargarDatos(ByVal emp As String)
        leerPar(emp)
        If DefCta_NumNiveles > 0 Then cboNiveles.Text = CStr(DefCta_NumNiveles) Else cboNiveles.Text = CStr(4)
        If Len(DefCta_NumDigNivel.ToString.Trim) <= 1 Then
            txtN1.Text = "1"
            txtN2.Text = "1"
            txtN3.Text = "1"
            txtN4.Text = "2"
            txtN5.Text = "2"
            txtN6.Text = "3"
        Else
            If Len(DefCta_NumDigNivel.ToString.Trim) > 0 Then txtN1.Text = DefCta_NumDigNivel.ToString.Substring(0, 1)
            If Len(DefCta_NumDigNivel.ToString.Trim) > 1 Then txtN2.Text = DefCta_NumDigNivel.ToString.Substring(1, 1)
            If Len(DefCta_NumDigNivel.ToString.Trim) > 2 Then txtN3.Text = DefCta_NumDigNivel.ToString.Substring(2, 1)
            If Len(DefCta_NumDigNivel.ToString.Trim) > 3 Then txtN4.Text = DefCta_NumDigNivel.ToString.Substring(3, 1)
            If Len(DefCta_NumDigNivel.ToString.Trim) > 4 Then txtN5.Text = DefCta_NumDigNivel.ToString.Substring(4, 1)
            If Len(DefCta_NumDigNivel.ToString.Trim) > 5 Then txtN6.Text = DefCta_NumDigNivel.ToString.Substring(5, 1)
            If Len(DefCta_NumDigNivel.ToString.Trim) > 6 Then txtN7.Text = DefCta_NumDigNivel.ToString.Substring(6, 1)
            If Len(DefCta_NumDigNivel.ToString.Trim) > 7 Then txtN8.Text = DefCta_NumDigNivel.ToString.Substring(7, 1)
        End If

        If DefCta_NumNiveles1 > 0 Then cboNivelesPresp.Text = CStr(DefCta_NumNiveles1) Else cboNivelesPresp.Text = CStr(4)
        If Len(DefCta_NumDigNivel.ToString.Trim) <= 1 Then
            txtN1P.Text = "1"
            txtN2P.Text = "1"
            txtN3P.Text = "1"
            txtN4P.Text = "2"
            txtN5P.Text = "2"
            txtN6P.Text = "3"
        Else
            If Len(DefCta_NumDigNivel1.ToString.Trim) > 0 Then txtN1P.Text = DefCta_NumDigNivel1.ToString.Substring(0, 1)
            If Len(DefCta_NumDigNivel1.ToString.Trim) > 1 Then txtN2P.Text = DefCta_NumDigNivel1.ToString.Substring(1, 1)
            If Len(DefCta_NumDigNivel1.ToString.Trim) > 2 Then txtN3P.Text = DefCta_NumDigNivel1.ToString.Substring(2, 1)
            If Len(DefCta_NumDigNivel1.ToString.Trim) > 3 Then txtN4P.Text = DefCta_NumDigNivel1.ToString.Substring(3, 1)
            If Len(DefCta_NumDigNivel1.ToString.Trim) > 4 Then txtN5P.Text = DefCta_NumDigNivel1.ToString.Substring(4, 1)
            If Len(DefCta_NumDigNivel1.ToString.Trim) > 5 Then txtN6P.Text = DefCta_NumDigNivel1.ToString.Substring(5, 1)
            If Len(DefCta_NumDigNivel1.ToString.Trim) > 6 Then txtN7P.Text = DefCta_NumDigNivel1.ToString.Substring(6, 1)
            If Len(DefCta_NumDigNivel1.ToString.Trim) > 7 Then txtN8P.Text = DefCta_NumDigNivel1.ToString.Substring(7, 1)
        End If

        'txtRegDocFech.Text = Par_RolCodMay
        'txtRegDocFech.Value = CDate(Par_RolCodMay)
        ' ✅ Solución en donde realmente ocurre el error:
        If Not String.IsNullOrEmpty(Par_RolCodMay) AndAlso IsDate(Par_RolCodMay) Then
            txtRegDocFech.Value = CDate(Par_RolCodMay)
        Else
            txtRegDocFech.Value = Date.Today  ' O Nothing
        End If
        If Par_SucPri <> "" Then cboSuc.SelectedValue = Par_SucPri
        TxtLongCodigoDirectorio.Value = Convert.ToDecimal(LongCodDirectorio)
        txtPassDesc.Text = Par_ClvDsc
        txtPassImp.Text = Par_ClvIVA
        If Par_AcumHis = True Then chkApell.Checked = True Else chkApell.Checked = False
        If Par_Numerodigitos > 0 Then txtDecimGen.Text = CStr(Par_Numerodigitos) Else txtDecimGen.Text = "2"
        cboFrmPagVta.SelectedValue = Par_DocPrincipalVta
        cboFrmPagCmp.SelectedValue = Par_PagoCompras
        If Par_DigitosCostos > 0 Then txtDecimInv.Text = CStr(Par_DigitosCostos) Else txtDecimInv.Text = "2"
        If Par_DigitosPrecios > 0 Then txtDecimPvp.Text = CStr(Par_DigitosPrecios) Else txtDecimPvp.Text = "2"
        If Par_CruceDocSucursal = 1 Then chkDifSuc.Checked = True Else chkDifSuc.Checked = False
        txtUrlImagenes.Text = Emp_PathImagenes
        TxtCtaCorreo.Text = CtaLocalEmail
        If Emp_DiasMensualesAcf = 1 Then chkAcf30d.Checked = True Else chkAcf30d.Checked = False
        If Par_RolTur = 99 Then chkSaldos.Checked = True Else chkSaldos.Checked = False
        TextNroDescuentos.Text = CStr(Par_AcfNumNiv)
        txtTemporal.Text = path_tmpServer
        If par_ValiDir = 1 Then chkValidarOnlineDirectorio.Checked = True Else chkValidarOnlineDirectorio.Checked = False

        If par_ValiSRI = 1 Then chkValidarOnlineSRI.Checked = True Else chkValidarOnlineSRI.Checked = False
        txtUrlWeb.Text = par_UrlSRI

    End Sub
#End Region

#Region "Cargar DatosCierre"
    'Private Sub CargarDatCie(ByVal empCod As String)
    '    Dim c As New AdcCie
    '    c.conectar = conectar
    '    c.Consultar()
    '    If IsDate(c.Cie_ComUltAnu) Then txtUltCierre.Value = c.Cie_ComUltAnu Else txtUltCierre.Value = New Date(1900, 1, 1)
    '    If IsDate(txtRegDocFech.Text) Then txtRegDocFech.Value = DateAdd("d", 1, c.Cie_ComUltAnu)
    'End Sub

    'Private Sub CargarDatCie(ByVal empCod As String)

    '    Dim c As New AdcCie
    '    c.conectar = conectar
    '    c.Consultar()

    '    If c.Cie_ComUltAnu > New Date(1900, 1, 1) Then
    '        txtUltCierre.Value = c.Cie_ComUltAnu
    '    Else
    '        txtUltCierre.Value = Date.Today
    '    End If

    '    txtRegDocFech.Value = DateAdd(DateInterval.Day, 1, txtUltCierre.Value)

    'End Sub

    Private Sub CargarDatCie(ByVal empCod As String)
        Dim c As New AdcCie
        c.conectar = conectar
        c.Consultar()

        ' Validar que Cie_ComUltAnu tenga valor válido (usar comparación de fecha, no IsNot)
        If c.Cie_ComUltAnu > #1/1/1900# Then
            txtUltCierre.Value = c.Cie_ComUltAnu
        Else
            txtUltCierre.Value = Date.Today
        End If

        ' Validar antes de hacer DateAdd (sin IsNot Nothing)
        If IsDate(txtUltCierre.Value) AndAlso txtUltCierre.Value > #1/1/1900# Then
            txtRegDocFech.Value = DateAdd(DateInterval.Day, 1, txtUltCierre.Value)
        Else
            txtRegDocFech.Value = Date.Today
        End If
    End Sub
#End Region

#Region "Guardar"
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        GuardarParametros(CStr(empresaCod))
        GuardarDatCierre()
        Me.Close()
    End Sub
    Private Sub ObtenerInf()
        If cboNiveles.Text <> "" Then DefCta_NumNiveles = CInt(cboNiveles.Text) Else DefCta_NumNiveles = 6
        If cboNivelesPresp.Text <> "" Then DefCta_NumNiveles1 = CInt(cboNivelesPresp.Text) Else DefCta_NumNiveles1 = 3

        Par_RolCodMay = txtRegDocFech.Text

        DefCta_NumDigNivel = CInt(txtN1.Text & txtN2.Text & txtN3.Text & txtN4.Text & txtN5.Text & txtN6.Text & txtN7.Text & txtN8.Text)
        DefCta_NumDigNivel1 = txtN1P.Text & txtN2P.Text & txtN3P.Text & txtN4P.Text & txtN5P.Text & txtN6P.Text & txtN7P.Text & txtN8P.Text

        If txtN1.Text = "_" And txtN2.Text = "_" Then DefCta_NumDigNivel = 111223
        If txtN1P.Text = "_" And txtN2P.Text = "_" Then DefCta_NumDigNivel = 123

        Par_SucPri = CStr(cboSuc.SelectedValue)
        LongCodDirectorio = Convert.ToInt32(TxtLongCodigoDirectorio.Value)
        Par_ClvDsc = txtPassDesc.Text
        Par_ClvIVA = txtPassImp.Text
        If chkApell.Checked = True Then Par_AcumHis = True Else Par_AcumHis = False
        Par_Numerodigitos = CInt(txtDecimGen.Text)
        If Not IsNothing(cboFrmPagVta.SelectedValue) Then Par_DocPrincipalVta = CStr(cboFrmPagVta.SelectedValue)
        If Not IsNothing(cboFrmPagCmp.SelectedValue) Then Par_PagoCompras = CStr(cboFrmPagCmp.SelectedValue)
        Par_DigitosCostos = CInt(txtDecimInv.Text)
        Par_DigitosPrecios = CInt(txtDecimPvp.Text)
        If chkDifSuc.Checked = True Then Par_CruceDocSucursal = 1 Else Par_CruceDocSucursal = 0
        If chkAcf30d.Checked = True Then Emp_DiasMensualesAcf = 1 Else Emp_DiasMensualesAcf = 0
        If chkSaldos.Checked = True Then Par_RolTur = 99 Else Par_RolTur = 0
        Par_AcfNumNiv = CInt(Val(TextNroDescuentos.Text))

        path_tmpServer = txtTemporal.Text
        Emp_PathImagenes = txtUrlImagenes.Text
        CtaLocalEmail = TxtCtaCorreo.Text
        If path_tmpServer.Length > 0 Then If path_tmpServer.Substring(path_tmpServer.Length - 1, 1) <> "\" Then path_tmpServer += "\"
        If Emp_PathImagenes.Length > 0 Then If Emp_PathImagenes.Substring(Emp_PathImagenes.Length - 1, 1) <> "\" Then Emp_PathImagenes += "\"

        If chkValidarOnlineDirectorio.Checked = True Then par_ValiDir = 1 Else par_ValiDir = 0

        If chkValidarOnlineSRI.Checked = True Then par_ValiSRI = 1 Else par_ValiSRI = 0
        par_UrlSRI = txtUrlWeb.Text

    End Sub
    Private Sub GuardarParametros(ByVal empCod As String)
        Dim p As New daxClassEmp.Emp_Par
        ObtenerInf()
        p.Emp_Codigo = CInt(empCod)
        p.DefCta_NumNiveles = DefCta_NumNiveles
        p.DefCta_NumGrupos = DefCta_NumGrupos
        p.DefCta_NumDigNivel = DefCta_NumDigNivel.ToString()
        p.DefCta_NumNiveles1 = DefCta_NumNiveles1
        p.DefCta_NumGrupos1 = DefCta_NumGrupos1
        p.DefCta_NumDigNivel1 = DefCta_NumDigNivel1
        p.Par_ConTipCierre = Par_ConTipCierre
        p.Par_InvTipCierre = Par_InvTipCierre
        p.Par_VenIVA = Par_VenIVA
        p.Par_VenSNEmp = Par_VenSNEmp
        p.Par_VenSNAcuDoc = Par_VenSNAcuDoc
        p.Par_ComIVA = Par_ComIVA
        p.Par_ComSNEmp = Par_ComSNEmp
        p.Par_ComSNAcuDoc = Par_ComSNAcuDoc
        p.Par_AcfNumNiv = Par_AcfNumNiv
        p.Par_RolCodMay = Par_RolCodMay
        p.Par_RolTur = Par_RolTur
        p.Par_SucPri = Par_SucPri
        p.Par_ClvDsc = Par_ClvDsc
        p.Par_ClvIVA = Par_ClvIVA
        p.Par_AcumHis = Par_AcumHis
        p.Par_FecDes = Par_FecDes
        p.Par_Numerodigitos = Par_Numerodigitos
        p.Par_LimAtrasoEntrada = Par_LimAtrasoEntrada
        p.Par_LimExtraSalida = Par_LimExtraSalida
        p.Par_LimExtraEntrada = Par_LimExtraEntrada
        p.Par_DocPrincipalVta = Par_DocPrincipalVta
        p.Par_Cheques = Convert.ToByte(Par_Cheques)
        p.Par_PagoCompras = Par_PagoCompras
        p.DefCtaV = DefCtaV
        p.Par_DigitosCostos = Par_DigitosCostos
        p.Par_DigitosPrecios = Par_DigitosPrecios
        p.Par_CruceDocSucursal = Convert.ToByte(Par_CruceDocSucursal)
        p.Emp_DiasMensualesAcf = Emp_DiasMensualesAcf
        p.Par_ConTipCierre = "A"
        p.Par_InvTipCierre = "X"

        p.Emp_PathImagenes = Emp_PathImagenes
        p.CtaLocalEmail = CtaLocalEmail
        p.path_tmpServer = path_tmpServer
        p.LongCodDirectorio = LongCodDirectorio
        p.par_ValiDir = Convert.ToByte(par_ValiDir)
        p.par_ValiSRI = par_ValiSRI
        p.par_UrlSRI = par_UrlSRI
        p.Actualizar()
    End Sub
    'Private Sub GuardarDatCierre()
    '    Dim c As New AdcCie
    '    c.conectar = conectar
    '    c.Consultar()

    '    'Try
    '    '    txtUltCierre.Text = CDate(txtUltCierre.Text).ToShortDateString()
    '    'Catch
    '    '    txtUltCierre.Text = "01/01/1900"
    '    'End Try

    '    Dim fecha As Date

    '    If Date.TryParse(txtUltCierre.Text, fecha) Then
    '        c.Cie_ConUltMen = fecha
    '    Else
    '        c.Cie_ConUltMen = Nothing
    '    End If
    '    If IsDate(txtUltCierre.Text) Then
    '        c.Cie_ConUltMen = CDate(txtUltCierre.Text)
    '    Else
    '        c.Cie_ConUltMen = Date.MinValue
    '    End If


    '    'c.Cie_ConUltMen = CDate(txtUltCierre.Text)
    '    c.Cie_ConUltAnu = CDate(txtUltCierre.Text)
    '    c.Cie_ConUltAct = CDate(txtUltCierre.Text)
    '    c.Cie_InvUltMen = CDate(txtUltCierre.Text)
    '    c.Cie_InvUltAnu = CDate(txtUltCierre.Text)
    '    c.Cie_InvUltAct = CDate(txtUltCierre.Text)
    '    c.Cie_VenUltMen = CDate(txtUltCierre.Text)
    '    c.Cie_VenUltAnu = CDate(txtUltCierre.Text)
    '    c.Cie_VenUltAct = CDate(txtUltCierre.Text)
    '    c.Cie_ComUltMen = CDate(txtUltCierre.Text)
    '    c.Cie_ComUltAnu = CDate(txtUltCierre.Text)
    '    c.Cie_ComUltAct = CDate(txtUltCierre.Text)
    '    c.Cie_AcfIncDep = CDate(txtUltCierre.Text)
    '    c.Cie_AcfUltDep = CDate(txtUltCierre.Text)
    '    c.Cie_AcfIncRex = CDate(txtUltCierre.Text)
    '    c.Cie_AcfUltRex = CDate(txtUltCierre.Text)
    '    c.Cie_RolUlt = CDate(txtUltCierre.Text)
    '    c.Cie_RolUltAct = CDate(txtUltCierre.Text)
    '    c.Eliminar()
    '    c.Guardar()
    'End Sub

    Private Sub GuardarDatCierre()

        Dim c As New AdcCie
        c.conectar = conectar
        c.Consultar()

        Dim fecha As Date = txtUltCierre.Value

        c.Cie_ConUltMen = fecha
        c.Cie_ConUltAnu = fecha
        c.Cie_ConUltAct = fecha
        c.Cie_InvUltMen = fecha
        c.Cie_InvUltAnu = fecha
        c.Cie_InvUltAct = fecha
        c.Cie_VenUltMen = fecha
        c.Cie_VenUltAnu = fecha
        c.Cie_VenUltAct = fecha
        c.Cie_ComUltMen = fecha
        c.Cie_ComUltAnu = fecha
        c.Cie_ComUltAct = fecha
        c.Cie_AcfIncDep = fecha
        c.Cie_AcfUltDep = fecha
        c.Cie_AcfIncRex = fecha
        c.Cie_AcfUltRex = fecha
        c.Cie_RolUlt = fecha
        c.Cie_RolUltAct = fecha

        c.Eliminar()
        c.Guardar()

    End Sub
#End Region

#Region "Cancelar"
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
#End Region

    Public Sub Parametros(ByVal emp As String, ByVal strcon As String)
        conectar.ConnectionString = strcon
        empresaCod = CInt(emp)
        Me.ShowDialog()
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextNroDescuentos.TextChanged
        If Val(TextNroDescuentos.Text) > 3 Then TextNroDescuentos.Text = CStr(3)
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub TxtCtaCorreo_TextChanged(sender As Object, e As EventArgs) Handles TxtCtaCorreo.TextChanged

    End Sub

    Private Sub Label43_Click(sender As Object, e As EventArgs) Handles Label43.Click

    End Sub
End Class