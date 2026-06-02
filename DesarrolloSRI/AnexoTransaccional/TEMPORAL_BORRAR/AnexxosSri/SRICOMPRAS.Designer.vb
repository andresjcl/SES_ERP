<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class SRICOMPRAS
#Region "Código generado por el Diseñador de Windows Forms "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'Llamada necesaria para el Diseñador de Windows Forms.
		InitializeComponent()
		VB6_AddADODataBinding()
	End Sub
	'Form invalida a Dispose para limpiar la lista de componentes.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			VB6_RemoveADODataBinding()
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Requerido por el Diseñador de Windows Forms
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Private ADOBind_dtPorIvaBie As VB6.MBindingCollection
	Private ADOBind_DtPorIvaServ As VB6.MBindingCollection
	Private ADOBind_DtPorRetIR As VB6.MBindingCollection
	Private ADOBind_dtCodSus As VB6.MBindingCollection
	Private ADOBind_dtCom As VB6.MBindingCollection
	Private ADOBind_dtPorIva As VB6.MBindingCollection
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents TxtNroAutorizaIR As System.Windows.Forms.TextBox
	Public WithEvents BtCaduca As System.Windows.Forms.Button
	Public WithEvents txtAutCom As System.Windows.Forms.TextBox
	Public WithEvents FechaCaduca As System.Windows.Forms.TextBox
	Public WithEvents btpro As System.Windows.Forms.Button
	Public WithEvents txtPro As System.Windows.Forms.TextBox
	Public WithEvents TxtSerEstablec As System.Windows.Forms.TextBox
	Public WithEvents txtNumSer As System.Windows.Forms.TextBox
	Public WithEvents txtNumSec As System.Windows.Forms.TextBox
	Public WithEvents BtContable As System.Windows.Forms.Button
	Public WithEvents BtEmision As System.Windows.Forms.Button
	Public WithEvents DerochoIva As System.Windows.Forms.CheckBox
	Public WithEvents TxtAutorizaMod As System.Windows.Forms.TextBox
	Public WithEvents BtRemision As System.Windows.Forms.Button
	Public WithEvents TxtNumeroSecuencialMod As System.Windows.Forms.TextBox
	Public WithEvents TxtserieEstableceMod As System.Windows.Forms.TextBox
	Public WithEvents TxtSerieEmicionMod As System.Windows.Forms.TextBox
	Public WithEvents TxtFechaModifica As System.Windows.Forms.TextBox
	Public WithEvents DcCodModificado As AxMSDataListLib.AxDataCombo
	Public WithEvents Label43 As System.Windows.Forms.Label
	Public WithEvents Label44 As System.Windows.Forms.Label
	Public WithEvents Label42 As System.Windows.Forms.Label
	Public WithEvents Label41 As System.Windows.Forms.Label
	Public WithEvents Label40 As System.Windows.Forms.Label
	Public WithEvents Label39 As System.Windows.Forms.Label
	Public WithEvents Label38 As System.Windows.Forms.Label
	Public WithEvents Label37 As System.Windows.Forms.Label
	Public WithEvents FrModifica As System.Windows.Forms.GroupBox
	Public WithEvents txtFecEmiCom As System.Windows.Forms.TextBox
	Public WithEvents txtFecRegCont As System.Windows.Forms.TextBox
	Public WithEvents txtBasImpTar0 As System.Windows.Forms.TextBox
	Public WithEvents txtMonIvaBie As System.Windows.Forms.TextBox
	Public WithEvents TxtBasImpICE As System.Windows.Forms.TextBox
	Public WithEvents txtBasImpGra As System.Windows.Forms.TextBox
	Public WithEvents DcPorICE As AxMSDataListLib.AxDataCombo
	Public WithEvents dtCodSus As VB6.ADODC
	Public WithEvents DtPorIvaServ As VB6.ADODC
	Public WithEvents dtCom As VB6.ADODC
	Public WithEvents dtPorIva As VB6.ADODC
	Public WithEvents DtPorICE As VB6.ADODC
	Public WithEvents dtPorIvaBie As VB6.ADODC
	Public WithEvents dcPorIva As AxMSDataListLib.AxDataCombo
	Public WithEvents TipoComprobante As AxMSDataListLib.AxDataCombo
	Public WithEvents DtComMod As VB6.ADODC
	Public WithEvents DtPorRetIR As VB6.ADODC
	Public WithEvents DatSustento As AxMSDataListLib.AxDataCombo
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents lbNomP As System.Windows.Forms.Label
	Public WithEvents lbClioPro As System.Windows.Forms.Label
	Public WithEvents Label15 As System.Windows.Forms.Label
	Public WithEvents Label24 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents lbfactor As System.Windows.Forms.Label
	Public WithEvents TxtPorcIce As System.Windows.Forms.Label
	Public WithEvents Label48 As System.Windows.Forms.Label
	Public WithEvents TxtMonIvaSer As System.Windows.Forms.Label
	Public WithEvents TxtMonIva As System.Windows.Forms.Label
	Public WithEvents TxtMonIce As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label49 As System.Windows.Forms.Label
	Public WithEvents Label14 As System.Windows.Forms.Label
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label12 As System.Windows.Forms.Label
	Public WithEvents Label25 As System.Windows.Forms.Label
	Public WithEvents Label16 As System.Windows.Forms.Label
	Public WithEvents Label19 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label22 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents fprincipal As System.Windows.Forms.Panel
	Public WithEvents _SSTab1_TabPage0 As System.Windows.Forms.TabPage
	Public WithEvents BtnFechEmitRete As System.Windows.Forms.Button
	Public WithEvents TxtSecuencialIR As System.Windows.Forms.TextBox
	Public WithEvents TxtSerieEstblIR As System.Windows.Forms.TextBox
	Public WithEvents TxtSerieEmision As System.Windows.Forms.TextBox
	Public WithEvents TxtFechaEmicionIR As System.Windows.Forms.TextBox
	Public WithEvents DcPorIvaServ As AxMSDataListLib.AxDataCombo
	Public WithEvents dcPorIvaBie As AxMSDataListLib.AxDataCombo
	Public WithEvents TxtMonRetSer As System.Windows.Forms.Label
	Public WithEvents TxtMonRetBie As System.Windows.Forms.Label
	Public WithEvents Label17 As System.Windows.Forms.Label
	Public WithEvents Label18 As System.Windows.Forms.Label
	Public WithEvents Label20 As System.Windows.Forms.Label
	Public WithEvents Label21 As System.Windows.Forms.Label
	Public WithEvents Frame4 As System.Windows.Forms.GroupBox
	Public WithEvents _TxtBasImpIR_1 As System.Windows.Forms.TextBox
	Public WithEvents _TxtPorcRetIR_1 As System.Windows.Forms.TextBox
	Public WithEvents _TxtPorcRetIR_0 As System.Windows.Forms.TextBox
	Public WithEvents _TxtBasImpIR_0 As System.Windows.Forms.TextBox
	Public WithEvents _CodRetFteImpRent_0 As AxMSDataListLib.AxDataCombo
	Public WithEvents _CodRetFteImpRent_1 As AxMSDataListLib.AxDataCombo
	Public WithEvents _TxtMonRetRen_1 As System.Windows.Forms.Label
	Public WithEvents _TxtMonRetRen_0 As System.Windows.Forms.Label
	Public WithEvents Label36 As System.Windows.Forms.Label
	Public WithEvents Label35 As System.Windows.Forms.Label
	Public WithEvents Label34 As System.Windows.Forms.Label
	Public WithEvents Label33 As System.Windows.Forms.Label
	Public WithEvents Frame3 As System.Windows.Forms.GroupBox
	Public WithEvents TxtMontoGratuito As System.Windows.Forms.TextBox
	Public WithEvents TxtMontoOneroso As System.Windows.Forms.TextBox
	Public WithEvents TxtNroContrato As System.Windows.Forms.TextBox
	Public WithEvents Label47 As System.Windows.Forms.Label
	Public WithEvents Label46 As System.Windows.Forms.Label
	Public WithEvents Label45 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents Label31 As System.Windows.Forms.Label
	Public WithEvents Label30 As System.Windows.Forms.Label
	Public WithEvents Label29 As System.Windows.Forms.Label
	Public WithEvents Label28 As System.Windows.Forms.Label
	Public WithEvents Label23 As System.Windows.Forms.Label
	Public WithEvents Label11 As System.Windows.Forms.Label
	Public WithEvents Frame2 As System.Windows.Forms.Panel
	Public WithEvents _SSTab1_TabPage1 As System.Windows.Forms.TabPage
	Public WithEvents SSTab1 As System.Windows.Forms.TabControl
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents btncancelar As System.Windows.Forms.Button
	Public WithEvents btngrabar As System.Windows.Forms.Button
	Public WithEvents F2 As System.Windows.Forms.Panel
	Public WithEvents btneliminar As System.Windows.Forms.Button
	Public WithEvents btnbuscar As System.Windows.Forms.Button
	Public WithEvents btnnuevo As System.Windows.Forms.Button
	Public WithEvents btnmodificar As System.Windows.Forms.Button
	Public WithEvents btnsalir As System.Windows.Forms.Button
	Public WithEvents f3 As System.Windows.Forms.Panel
	Public WithEvents Label32 As System.Windows.Forms.Label
	Public WithEvents Label13 As System.Windows.Forms.Label
	Public WithEvents Label26 As System.Windows.Forms.Label
	Public WithEvents CodRetFteImpRent As AxDataComboArray
	Public WithEvents TxtBasImpIR As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	Public WithEvents TxtMonRetRen As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents TxtPorcRetIR As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
	'Se puede modificar mediante el Diseñador de Windows Forms.
	'No lo modifique con el editor de código.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SRICOMPRAS))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Command1 = New System.Windows.Forms.Button
		Me.TxtNroAutorizaIR = New System.Windows.Forms.TextBox
		Me.BtCaduca = New System.Windows.Forms.Button
		Me.txtAutCom = New System.Windows.Forms.TextBox
		Me.FechaCaduca = New System.Windows.Forms.TextBox
		Me.SSTab1 = New System.Windows.Forms.TabControl
		Me._SSTab1_TabPage0 = New System.Windows.Forms.TabPage
		Me.fprincipal = New System.Windows.Forms.Panel
		Me.btpro = New System.Windows.Forms.Button
		Me.txtPro = New System.Windows.Forms.TextBox
		Me.TxtSerEstablec = New System.Windows.Forms.TextBox
		Me.txtNumSer = New System.Windows.Forms.TextBox
		Me.txtNumSec = New System.Windows.Forms.TextBox
		Me.BtContable = New System.Windows.Forms.Button
		Me.BtEmision = New System.Windows.Forms.Button
		Me.DerochoIva = New System.Windows.Forms.CheckBox
		Me.FrModifica = New System.Windows.Forms.GroupBox
		Me.TxtAutorizaMod = New System.Windows.Forms.TextBox
		Me.BtRemision = New System.Windows.Forms.Button
		Me.TxtNumeroSecuencialMod = New System.Windows.Forms.TextBox
		Me.TxtserieEstableceMod = New System.Windows.Forms.TextBox
		Me.TxtSerieEmicionMod = New System.Windows.Forms.TextBox
		Me.TxtFechaModifica = New System.Windows.Forms.TextBox
		Me.DcCodModificado = New AxMSDataListLib.AxDataCombo
		Me.Label43 = New System.Windows.Forms.Label
		Me.Label44 = New System.Windows.Forms.Label
		Me.Label42 = New System.Windows.Forms.Label
		Me.Label41 = New System.Windows.Forms.Label
		Me.Label40 = New System.Windows.Forms.Label
		Me.Label39 = New System.Windows.Forms.Label
		Me.Label38 = New System.Windows.Forms.Label
		Me.Label37 = New System.Windows.Forms.Label
		Me.txtFecEmiCom = New System.Windows.Forms.TextBox
		Me.txtFecRegCont = New System.Windows.Forms.TextBox
		Me.txtBasImpTar0 = New System.Windows.Forms.TextBox
		Me.txtMonIvaBie = New System.Windows.Forms.TextBox
		Me.TxtBasImpICE = New System.Windows.Forms.TextBox
		Me.txtBasImpGra = New System.Windows.Forms.TextBox
		Me.DcPorICE = New AxMSDataListLib.AxDataCombo
		Me.dtCodSus = New VB6.ADODC
		Me.DtPorIvaServ = New VB6.ADODC
		Me.dtCom = New VB6.ADODC
		Me.dtPorIva = New VB6.ADODC
		Me.DtPorICE = New VB6.ADODC
		Me.dtPorIvaBie = New VB6.ADODC
		Me.dcPorIva = New AxMSDataListLib.AxDataCombo
		Me.TipoComprobante = New AxMSDataListLib.AxDataCombo
		Me.DtComMod = New VB6.ADODC
		Me.DtPorRetIR = New VB6.ADODC
		Me.DatSustento = New AxMSDataListLib.AxDataCombo
		Me.Label1 = New System.Windows.Forms.Label
		Me.lbNomP = New System.Windows.Forms.Label
		Me.lbClioPro = New System.Windows.Forms.Label
		Me.Label15 = New System.Windows.Forms.Label
		Me.Label24 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.lbfactor = New System.Windows.Forms.Label
		Me.TxtPorcIce = New System.Windows.Forms.Label
		Me.Label48 = New System.Windows.Forms.Label
		Me.TxtMonIvaSer = New System.Windows.Forms.Label
		Me.TxtMonIva = New System.Windows.Forms.Label
		Me.TxtMonIce = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label49 = New System.Windows.Forms.Label
		Me.Label14 = New System.Windows.Forms.Label
		Me.Label10 = New System.Windows.Forms.Label
		Me.Label7 = New System.Windows.Forms.Label
		Me.Label12 = New System.Windows.Forms.Label
		Me.Label25 = New System.Windows.Forms.Label
		Me.Label16 = New System.Windows.Forms.Label
		Me.Label19 = New System.Windows.Forms.Label
		Me.Label9 = New System.Windows.Forms.Label
		Me.Label22 = New System.Windows.Forms.Label
		Me.Label8 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label6 = New System.Windows.Forms.Label
		Me._SSTab1_TabPage1 = New System.Windows.Forms.TabPage
		Me.Frame2 = New System.Windows.Forms.Panel
		Me.BtnFechEmitRete = New System.Windows.Forms.Button
		Me.TxtSecuencialIR = New System.Windows.Forms.TextBox
		Me.TxtSerieEstblIR = New System.Windows.Forms.TextBox
		Me.TxtSerieEmision = New System.Windows.Forms.TextBox
		Me.TxtFechaEmicionIR = New System.Windows.Forms.TextBox
		Me.Frame4 = New System.Windows.Forms.GroupBox
		Me.DcPorIvaServ = New AxMSDataListLib.AxDataCombo
		Me.dcPorIvaBie = New AxMSDataListLib.AxDataCombo
		Me.TxtMonRetSer = New System.Windows.Forms.Label
		Me.TxtMonRetBie = New System.Windows.Forms.Label
		Me.Label17 = New System.Windows.Forms.Label
		Me.Label18 = New System.Windows.Forms.Label
		Me.Label20 = New System.Windows.Forms.Label
		Me.Label21 = New System.Windows.Forms.Label
		Me.Frame3 = New System.Windows.Forms.GroupBox
		Me._TxtBasImpIR_1 = New System.Windows.Forms.TextBox
		Me._TxtPorcRetIR_1 = New System.Windows.Forms.TextBox
		Me._TxtPorcRetIR_0 = New System.Windows.Forms.TextBox
		Me._TxtBasImpIR_0 = New System.Windows.Forms.TextBox
		Me._CodRetFteImpRent_0 = New AxMSDataListLib.AxDataCombo
		Me._CodRetFteImpRent_1 = New AxMSDataListLib.AxDataCombo
		Me._TxtMonRetRen_1 = New System.Windows.Forms.Label
		Me._TxtMonRetRen_0 = New System.Windows.Forms.Label
		Me.Label36 = New System.Windows.Forms.Label
		Me.Label35 = New System.Windows.Forms.Label
		Me.Label34 = New System.Windows.Forms.Label
		Me.Label33 = New System.Windows.Forms.Label
		Me.Frame1 = New System.Windows.Forms.GroupBox
		Me.TxtMontoGratuito = New System.Windows.Forms.TextBox
		Me.TxtMontoOneroso = New System.Windows.Forms.TextBox
		Me.TxtNroContrato = New System.Windows.Forms.TextBox
		Me.Label47 = New System.Windows.Forms.Label
		Me.Label46 = New System.Windows.Forms.Label
		Me.Label45 = New System.Windows.Forms.Label
		Me.Label31 = New System.Windows.Forms.Label
		Me.Label30 = New System.Windows.Forms.Label
		Me.Label29 = New System.Windows.Forms.Label
		Me.Label28 = New System.Windows.Forms.Label
		Me.Label23 = New System.Windows.Forms.Label
		Me.Label11 = New System.Windows.Forms.Label
		Me.F2 = New System.Windows.Forms.Panel
		Me.Command2 = New System.Windows.Forms.Button
		Me.btncancelar = New System.Windows.Forms.Button
		Me.btngrabar = New System.Windows.Forms.Button
		Me.f3 = New System.Windows.Forms.Panel
		Me.btneliminar = New System.Windows.Forms.Button
		Me.btnbuscar = New System.Windows.Forms.Button
		Me.btnnuevo = New System.Windows.Forms.Button
		Me.btnmodificar = New System.Windows.Forms.Button
		Me.btnsalir = New System.Windows.Forms.Button
		Me.Label32 = New System.Windows.Forms.Label
		Me.Label13 = New System.Windows.Forms.Label
		Me.Label26 = New System.Windows.Forms.Label
		Me.CodRetFteImpRent = New AxDataComboArray(components)
		Me.TxtBasImpIR = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		Me.TxtMonRetRen = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.TxtPorcRetIR = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		Me.SSTab1.SuspendLayout()
		Me._SSTab1_TabPage0.SuspendLayout()
		Me.fprincipal.SuspendLayout()
		Me.FrModifica.SuspendLayout()
		Me._SSTab1_TabPage1.SuspendLayout()
		Me.Frame2.SuspendLayout()
		Me.Frame4.SuspendLayout()
		Me.Frame3.SuspendLayout()
		Me.Frame1.SuspendLayout()
		Me.F2.SuspendLayout()
		Me.f3.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.DcCodModificado, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.DcPorICE, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dcPorIva, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.TipoComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.DatSustento, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.DcPorIvaServ, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dcPorIvaBie, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me._CodRetFteImpRent_0, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me._CodRetFteImpRent_1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.CodRetFteImpRent, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.TxtBasImpIR, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.TxtMonRetRen, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.TxtPorcRetIR, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "Compras/Ventas"
		Me.ClientSize = New System.Drawing.Size(764, 443)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.Icon = CType(resources.GetObject("SRICOMPRAS.Icon"), System.Drawing.Icon)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "SRICOMPRAS"
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.Text = "&Imprimir Retencion"
		Me.Command1.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Command1.Size = New System.Drawing.Size(141, 33)
		Me.Command1.Location = New System.Drawing.Point(616, 400)
		Me.Command1.TabIndex = 119
		Me.ToolTip1.SetToolTip(Me.Command1, "Regresa al menu principal")
		Me.Command1.BackColor = System.Drawing.SystemColors.Control
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.TabStop = True
		Me.Command1.Name = "Command1"
		Me.TxtNroAutorizaIR.AutoSize = False
		Me.TxtNroAutorizaIR.Size = New System.Drawing.Size(89, 19)
		Me.TxtNroAutorizaIR.Location = New System.Drawing.Point(472, 416)
		Me.TxtNroAutorizaIR.Maxlength = 10
		Me.TxtNroAutorizaIR.TabIndex = 117
		Me.ToolTip1.SetToolTip(Me.TxtNroAutorizaIR, "Número de autorización del comprobante")
		Me.TxtNroAutorizaIR.Visible = False
		Me.TxtNroAutorizaIR.AcceptsReturn = True
		Me.TxtNroAutorizaIR.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TxtNroAutorizaIR.BackColor = System.Drawing.SystemColors.Window
		Me.TxtNroAutorizaIR.CausesValidation = True
		Me.TxtNroAutorizaIR.Enabled = True
		Me.TxtNroAutorizaIR.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtNroAutorizaIR.HideSelection = True
		Me.TxtNroAutorizaIR.ReadOnly = False
		Me.TxtNroAutorizaIR.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtNroAutorizaIR.MultiLine = False
		Me.TxtNroAutorizaIR.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtNroAutorizaIR.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtNroAutorizaIR.TabStop = True
		Me.TxtNroAutorizaIR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtNroAutorizaIR.Name = "TxtNroAutorizaIR"
		Me.BtCaduca.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.BtCaduca.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.BtCaduca.Size = New System.Drawing.Size(17, 19)
		Me.BtCaduca.Location = New System.Drawing.Point(720, 416)
		Me.BtCaduca.Image = CType(resources.GetObject("BtCaduca.Image"), System.Drawing.Image)
		Me.BtCaduca.TabIndex = 113
		Me.ToolTip1.SetToolTip(Me.BtCaduca, "Escojer de una lista")
		Me.BtCaduca.Visible = False
		Me.BtCaduca.CausesValidation = True
		Me.BtCaduca.Enabled = True
		Me.BtCaduca.ForeColor = System.Drawing.SystemColors.ControlText
		Me.BtCaduca.Cursor = System.Windows.Forms.Cursors.Default
		Me.BtCaduca.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.BtCaduca.TabStop = True
		Me.BtCaduca.Name = "BtCaduca"
		Me.txtAutCom.AutoSize = False
		Me.txtAutCom.Size = New System.Drawing.Size(89, 19)
		Me.txtAutCom.Location = New System.Drawing.Point(344, 416)
		Me.txtAutCom.Maxlength = 10
		Me.txtAutCom.TabIndex = 112
		Me.ToolTip1.SetToolTip(Me.txtAutCom, "Número de autorización del comprobante")
		Me.txtAutCom.Visible = False
		Me.txtAutCom.AcceptsReturn = True
		Me.txtAutCom.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtAutCom.BackColor = System.Drawing.SystemColors.Window
		Me.txtAutCom.CausesValidation = True
		Me.txtAutCom.Enabled = True
		Me.txtAutCom.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtAutCom.HideSelection = True
		Me.txtAutCom.ReadOnly = False
		Me.txtAutCom.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtAutCom.MultiLine = False
		Me.txtAutCom.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtAutCom.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtAutCom.TabStop = True
		Me.txtAutCom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtAutCom.Name = "txtAutCom"
		Me.FechaCaduca.AutoSize = False
		Me.FechaCaduca.Size = New System.Drawing.Size(65, 19)
		Me.FechaCaduca.Location = New System.Drawing.Point(656, 416)
		Me.FechaCaduca.Maxlength = 10
		Me.FechaCaduca.TabIndex = 111
		Me.ToolTip1.SetToolTip(Me.FechaCaduca, "Fecha de registro contable")
		Me.FechaCaduca.Visible = False
		Me.FechaCaduca.AcceptsReturn = True
		Me.FechaCaduca.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.FechaCaduca.BackColor = System.Drawing.SystemColors.Window
		Me.FechaCaduca.CausesValidation = True
		Me.FechaCaduca.Enabled = True
		Me.FechaCaduca.ForeColor = System.Drawing.SystemColors.WindowText
		Me.FechaCaduca.HideSelection = True
		Me.FechaCaduca.ReadOnly = False
		Me.FechaCaduca.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.FechaCaduca.MultiLine = False
		Me.FechaCaduca.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.FechaCaduca.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.FechaCaduca.TabStop = True
		Me.FechaCaduca.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.FechaCaduca.Name = "FechaCaduca"
		Me.SSTab1.Size = New System.Drawing.Size(753, 385)
		Me.SSTab1.Location = New System.Drawing.Point(8, 8)
		Me.SSTab1.TabIndex = 104
		Me.SSTab1.SelectedIndex = 1
		Me.SSTab1.ItemSize = New System.Drawing.Size(42, 18)
		Me.SSTab1.BackColor = System.Drawing.Color.FromARGB(230, 241, 242)
		Me.SSTab1.Name = "SSTab1"
		Me._SSTab1_TabPage0.Text = "DATOS DEL COMPROBANTE DE COMPRA"
		Me.fprincipal.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.fprincipal.Font = New System.Drawing.Font("Times New Roman", 18!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.fprincipal.ForeColor = System.Drawing.SystemColors.WindowText
		Me.fprincipal.Size = New System.Drawing.Size(737, 353)
		Me.fprincipal.Location = New System.Drawing.Point(8, 24)
		Me.fprincipal.TabIndex = 105
		Me.fprincipal.BackColor = System.Drawing.SystemColors.Control
		Me.fprincipal.Enabled = True
		Me.fprincipal.Cursor = System.Windows.Forms.Cursors.Default
		Me.fprincipal.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fprincipal.Visible = True
		Me.fprincipal.Name = "fprincipal"
		Me.btpro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.btpro.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.btpro.Size = New System.Drawing.Size(17, 19)
		Me.btpro.Location = New System.Drawing.Point(240, 56)
		Me.btpro.Image = CType(resources.GetObject("btpro.Image"), System.Drawing.Image)
		Me.btpro.TabIndex = 5
		Me.ToolTip1.SetToolTip(Me.btpro, "Escojer de una lista")
		Me.btpro.CausesValidation = True
		Me.btpro.Enabled = True
		Me.btpro.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btpro.Cursor = System.Windows.Forms.Cursors.Default
		Me.btpro.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btpro.TabStop = True
		Me.btpro.Name = "btpro"
		Me.txtPro.AutoSize = False
		Me.txtPro.Size = New System.Drawing.Size(105, 19)
		Me.txtPro.Location = New System.Drawing.Point(136, 56)
		Me.txtPro.Maxlength = 13
		Me.txtPro.TabIndex = 4
		Me.ToolTip1.SetToolTip(Me.txtPro, "Cédula , Ruc, Pasaporte del proveedor")
		Me.txtPro.AcceptsReturn = True
		Me.txtPro.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtPro.BackColor = System.Drawing.SystemColors.Window
		Me.txtPro.CausesValidation = True
		Me.txtPro.Enabled = True
		Me.txtPro.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPro.HideSelection = True
		Me.txtPro.ReadOnly = False
		Me.txtPro.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPro.MultiLine = False
		Me.txtPro.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPro.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPro.TabStop = True
		Me.txtPro.Visible = True
		Me.txtPro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPro.Name = "txtPro"
		Me.TxtSerEstablec.AutoSize = False
		Me.TxtSerEstablec.Size = New System.Drawing.Size(41, 19)
		Me.TxtSerEstablec.Location = New System.Drawing.Point(136, 88)
		Me.TxtSerEstablec.Maxlength = 3
		Me.TxtSerEstablec.TabIndex = 11
		Me.ToolTip1.SetToolTip(Me.TxtSerEstablec, "número de serie del comprobante")
		Me.TxtSerEstablec.AcceptsReturn = True
		Me.TxtSerEstablec.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TxtSerEstablec.BackColor = System.Drawing.SystemColors.Window
		Me.TxtSerEstablec.CausesValidation = True
		Me.TxtSerEstablec.Enabled = True
		Me.TxtSerEstablec.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtSerEstablec.HideSelection = True
		Me.TxtSerEstablec.ReadOnly = False
		Me.TxtSerEstablec.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtSerEstablec.MultiLine = False
		Me.TxtSerEstablec.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtSerEstablec.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtSerEstablec.TabStop = True
		Me.TxtSerEstablec.Visible = True
		Me.TxtSerEstablec.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtSerEstablec.Name = "TxtSerEstablec"
		Me.txtNumSer.AutoSize = False
		Me.txtNumSer.Size = New System.Drawing.Size(41, 19)
		Me.txtNumSer.Location = New System.Drawing.Point(88, 88)
		Me.txtNumSer.Maxlength = 3
		Me.txtNumSer.TabIndex = 8
		Me.ToolTip1.SetToolTip(Me.txtNumSer, "número de serie del comprobante")
		Me.txtNumSer.AcceptsReturn = True
		Me.txtNumSer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNumSer.BackColor = System.Drawing.SystemColors.Window
		Me.txtNumSer.CausesValidation = True
		Me.txtNumSer.Enabled = True
		Me.txtNumSer.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtNumSer.HideSelection = True
		Me.txtNumSer.ReadOnly = False
		Me.txtNumSer.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNumSer.MultiLine = False
		Me.txtNumSer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtNumSer.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtNumSer.TabStop = True
		Me.txtNumSer.Visible = True
		Me.txtNumSer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNumSer.Name = "txtNumSer"
		Me.txtNumSec.AutoSize = False
		Me.txtNumSec.Size = New System.Drawing.Size(65, 19)
		Me.txtNumSec.Location = New System.Drawing.Point(192, 88)
		Me.txtNumSec.Maxlength = 10
		Me.txtNumSec.TabIndex = 13
		Me.ToolTip1.SetToolTip(Me.txtNumSec, "Número secuencial del comprobante")
		Me.txtNumSec.AcceptsReturn = True
		Me.txtNumSec.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNumSec.BackColor = System.Drawing.SystemColors.Window
		Me.txtNumSec.CausesValidation = True
		Me.txtNumSec.Enabled = True
		Me.txtNumSec.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtNumSec.HideSelection = True
		Me.txtNumSec.ReadOnly = False
		Me.txtNumSec.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNumSec.MultiLine = False
		Me.txtNumSec.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtNumSec.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtNumSec.TabStop = True
		Me.txtNumSec.Visible = True
		Me.txtNumSec.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNumSec.Name = "txtNumSec"
		Me.BtContable.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.BtContable.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.BtContable.Size = New System.Drawing.Size(17, 19)
		Me.BtContable.Location = New System.Drawing.Point(704, 88)
		Me.BtContable.Image = CType(resources.GetObject("BtContable.Image"), System.Drawing.Image)
		Me.BtContable.TabIndex = 21
		Me.ToolTip1.SetToolTip(Me.BtContable, "Escojer de una lista")
		Me.BtContable.CausesValidation = True
		Me.BtContable.Enabled = True
		Me.BtContable.ForeColor = System.Drawing.SystemColors.ControlText
		Me.BtContable.Cursor = System.Windows.Forms.Cursors.Default
		Me.BtContable.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.BtContable.TabStop = True
		Me.BtContable.Name = "BtContable"
		Me.BtEmision.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.BtEmision.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.BtEmision.Size = New System.Drawing.Size(17, 19)
		Me.BtEmision.Location = New System.Drawing.Point(488, 88)
		Me.BtEmision.Image = CType(resources.GetObject("BtEmision.Image"), System.Drawing.Image)
		Me.BtEmision.TabIndex = 17
		Me.ToolTip1.SetToolTip(Me.BtEmision, "Escojer de una lista")
		Me.BtEmision.CausesValidation = True
		Me.BtEmision.Enabled = True
		Me.BtEmision.ForeColor = System.Drawing.SystemColors.ControlText
		Me.BtEmision.Cursor = System.Windows.Forms.Cursors.Default
		Me.BtEmision.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.BtEmision.TabStop = True
		Me.BtEmision.Name = "BtEmision"
		Me.DerochoIva.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.DerochoIva.Text = "Trans. con Derecho a Devolución de Iva"
		Me.DerochoIva.Size = New System.Drawing.Size(129, 33)
		Me.DerochoIva.Location = New System.Drawing.Point(592, 8)
		Me.DerochoIva.TabIndex = 2
		Me.ToolTip1.SetToolTip(Me.DerochoIva, "Tiene ó no derecho a devolucíon")
		Me.DerochoIva.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.DerochoIva.BackColor = System.Drawing.SystemColors.Control
		Me.DerochoIva.CausesValidation = True
		Me.DerochoIva.Enabled = True
		Me.DerochoIva.ForeColor = System.Drawing.SystemColors.ControlText
		Me.DerochoIva.Cursor = System.Windows.Forms.Cursors.Default
		Me.DerochoIva.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.DerochoIva.Appearance = System.Windows.Forms.Appearance.Normal
		Me.DerochoIva.TabStop = True
		Me.DerochoIva.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.DerochoIva.Visible = True
		Me.DerochoIva.Name = "DerochoIva"
		Me.FrModifica.Text = "MODIFICA DOCUMENTO"
		Me.FrModifica.Enabled = False
		Me.FrModifica.Size = New System.Drawing.Size(737, 73)
		Me.FrModifica.Location = New System.Drawing.Point(0, 272)
		Me.FrModifica.TabIndex = 107
		Me.FrModifica.BackColor = System.Drawing.SystemColors.Control
		Me.FrModifica.ForeColor = System.Drawing.SystemColors.ControlText
		Me.FrModifica.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.FrModifica.Visible = True
		Me.FrModifica.Padding = New System.Windows.Forms.Padding(0)
		Me.FrModifica.Name = "FrModifica"
		Me.TxtAutorizaMod.AutoSize = False
		Me.TxtAutorizaMod.Size = New System.Drawing.Size(217, 19)
		Me.TxtAutorizaMod.Location = New System.Drawing.Point(504, 40)
		Me.TxtAutorizaMod.Maxlength = 40
		Me.TxtAutorizaMod.TabIndex = 120
		Me.ToolTip1.SetToolTip(Me.TxtAutorizaMod, "Número de autorización del comprobante")
		Me.TxtAutorizaMod.AcceptsReturn = True
		Me.TxtAutorizaMod.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TxtAutorizaMod.BackColor = System.Drawing.SystemColors.Window
		Me.TxtAutorizaMod.CausesValidation = True
		Me.TxtAutorizaMod.Enabled = True
		Me.TxtAutorizaMod.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtAutorizaMod.HideSelection = True
		Me.TxtAutorizaMod.ReadOnly = False
		Me.TxtAutorizaMod.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtAutorizaMod.MultiLine = False
		Me.TxtAutorizaMod.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtAutorizaMod.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtAutorizaMod.TabStop = True
		Me.TxtAutorizaMod.Visible = True
		Me.TxtAutorizaMod.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtAutorizaMod.Name = "TxtAutorizaMod"
		Me.BtRemision.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.BtRemision.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.BtRemision.Size = New System.Drawing.Size(17, 19)
		Me.BtRemision.Location = New System.Drawing.Point(472, 40)
		Me.BtRemision.Image = CType(resources.GetObject("BtRemision.Image"), System.Drawing.Image)
		Me.BtRemision.TabIndex = 56
		Me.ToolTip1.SetToolTip(Me.BtRemision, "Escojer de una lista")
		Me.BtRemision.CausesValidation = True
		Me.BtRemision.Enabled = True
		Me.BtRemision.ForeColor = System.Drawing.SystemColors.ControlText
		Me.BtRemision.Cursor = System.Windows.Forms.Cursors.Default
		Me.BtRemision.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.BtRemision.TabStop = True
		Me.BtRemision.Name = "BtRemision"
		Me.TxtNumeroSecuencialMod.AutoSize = False
		Me.TxtNumeroSecuencialMod.Size = New System.Drawing.Size(57, 19)
		Me.TxtNumeroSecuencialMod.Location = New System.Drawing.Point(208, 40)
		Me.TxtNumeroSecuencialMod.Maxlength = 10
		Me.TxtNumeroSecuencialMod.TabIndex = 52
		Me.ToolTip1.SetToolTip(Me.TxtNumeroSecuencialMod, "Número secuencial del comprobante")
		Me.TxtNumeroSecuencialMod.AcceptsReturn = True
		Me.TxtNumeroSecuencialMod.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TxtNumeroSecuencialMod.BackColor = System.Drawing.SystemColors.Window
		Me.TxtNumeroSecuencialMod.CausesValidation = True
		Me.TxtNumeroSecuencialMod.Enabled = True
		Me.TxtNumeroSecuencialMod.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtNumeroSecuencialMod.HideSelection = True
		Me.TxtNumeroSecuencialMod.ReadOnly = False
		Me.TxtNumeroSecuencialMod.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtNumeroSecuencialMod.MultiLine = False
		Me.TxtNumeroSecuencialMod.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtNumeroSecuencialMod.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtNumeroSecuencialMod.TabStop = True
		Me.TxtNumeroSecuencialMod.Visible = True
		Me.TxtNumeroSecuencialMod.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtNumeroSecuencialMod.Name = "TxtNumeroSecuencialMod"
		Me.TxtserieEstableceMod.AutoSize = False
		Me.TxtserieEstableceMod.Size = New System.Drawing.Size(33, 19)
		Me.TxtserieEstableceMod.Location = New System.Drawing.Point(112, 40)
		Me.TxtserieEstableceMod.Maxlength = 3
		Me.TxtserieEstableceMod.TabIndex = 48
		Me.ToolTip1.SetToolTip(Me.TxtserieEstableceMod, "número de serie del comprobante")
		Me.TxtserieEstableceMod.AcceptsReturn = True
		Me.TxtserieEstableceMod.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TxtserieEstableceMod.BackColor = System.Drawing.SystemColors.Window
		Me.TxtserieEstableceMod.CausesValidation = True
		Me.TxtserieEstableceMod.Enabled = True
		Me.TxtserieEstableceMod.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtserieEstableceMod.HideSelection = True
		Me.TxtserieEstableceMod.ReadOnly = False
		Me.TxtserieEstableceMod.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtserieEstableceMod.MultiLine = False
		Me.TxtserieEstableceMod.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtserieEstableceMod.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtserieEstableceMod.TabStop = True
		Me.TxtserieEstableceMod.Visible = True
		Me.TxtserieEstableceMod.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtserieEstableceMod.Name = "TxtserieEstableceMod"
		Me.TxtSerieEmicionMod.AutoSize = False
		Me.TxtSerieEmicionMod.Size = New System.Drawing.Size(33, 19)
		Me.TxtSerieEmicionMod.Location = New System.Drawing.Point(160, 40)
		Me.TxtSerieEmicionMod.Maxlength = 3
		Me.TxtSerieEmicionMod.TabIndex = 50
		Me.ToolTip1.SetToolTip(Me.TxtSerieEmicionMod, "número de serie del comprobante")
		Me.TxtSerieEmicionMod.AcceptsReturn = True
		Me.TxtSerieEmicionMod.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TxtSerieEmicionMod.BackColor = System.Drawing.SystemColors.Window
		Me.TxtSerieEmicionMod.CausesValidation = True
		Me.TxtSerieEmicionMod.Enabled = True
		Me.TxtSerieEmicionMod.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtSerieEmicionMod.HideSelection = True
		Me.TxtSerieEmicionMod.ReadOnly = False
		Me.TxtSerieEmicionMod.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtSerieEmicionMod.MultiLine = False
		Me.TxtSerieEmicionMod.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtSerieEmicionMod.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtSerieEmicionMod.TabStop = True
		Me.TxtSerieEmicionMod.Visible = True
		Me.TxtSerieEmicionMod.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtSerieEmicionMod.Name = "TxtSerieEmicionMod"
		Me.TxtFechaModifica.AutoSize = False
		Me.TxtFechaModifica.Size = New System.Drawing.Size(65, 19)
		Me.TxtFechaModifica.Location = New System.Drawing.Point(408, 40)
		Me.TxtFechaModifica.Maxlength = 10
		Me.TxtFechaModifica.TabIndex = 55
		Me.ToolTip1.SetToolTip(Me.TxtFechaModifica, "Fecha de registro contable")
		Me.TxtFechaModifica.AcceptsReturn = True
		Me.TxtFechaModifica.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TxtFechaModifica.BackColor = System.Drawing.SystemColors.Window
		Me.TxtFechaModifica.CausesValidation = True
		Me.TxtFechaModifica.Enabled = True
		Me.TxtFechaModifica.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtFechaModifica.HideSelection = True
		Me.TxtFechaModifica.ReadOnly = False
		Me.TxtFechaModifica.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtFechaModifica.MultiLine = False
		Me.TxtFechaModifica.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtFechaModifica.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtFechaModifica.TabStop = True
		Me.TxtFechaModifica.Visible = True
		Me.TxtFechaModifica.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtFechaModifica.Name = "TxtFechaModifica"
		DcCodModificado.OcxState = CType(resources.GetObject("DcCodModificado.OcxState"), System.Windows.Forms.AxHost.State)
		Me.DcCodModificado.Size = New System.Drawing.Size(353, 21)
		Me.DcCodModificado.Location = New System.Drawing.Point(144, 16)
		Me.DcCodModificado.TabIndex = 45
		Me.DcCodModificado.Name = "DcCodModificado"
		Me.Label43.Text = "No.AutorizaciónModifica"
		Me.Label43.Size = New System.Drawing.Size(115, 13)
		Me.Label43.Location = New System.Drawing.Point(512, 16)
		Me.Label43.TabIndex = 121
		Me.Label43.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label43.BackColor = System.Drawing.Color.Transparent
		Me.Label43.Enabled = True
		Me.Label43.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label43.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label43.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label43.UseMnemonic = True
		Me.Label43.Visible = True
		Me.Label43.AutoSize = True
		Me.Label43.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label43.Name = "Label43"
		Me.Label44.Text = "&Tipo de Comprobante"
		Me.Label44.Size = New System.Drawing.Size(102, 13)
		Me.Label44.Location = New System.Drawing.Point(8, 24)
		Me.Label44.TabIndex = 44
		Me.Label44.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label44.BackColor = System.Drawing.Color.Transparent
		Me.Label44.Enabled = True
		Me.Label44.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label44.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label44.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label44.UseMnemonic = True
		Me.Label44.Visible = True
		Me.Label44.AutoSize = True
		Me.Label44.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label44.Name = "Label44"
		Me.Label42.Text = "No.CpbteModifica"
		Me.Label42.Size = New System.Drawing.Size(85, 13)
		Me.Label42.Location = New System.Drawing.Point(8, 48)
		Me.Label42.TabIndex = 46
		Me.Label42.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label42.BackColor = System.Drawing.Color.Transparent
		Me.Label42.Enabled = True
		Me.Label42.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label42.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label42.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label42.UseMnemonic = True
		Me.Label42.Visible = True
		Me.Label42.AutoSize = True
		Me.Label42.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label42.Name = "Label42"
		Me.Label41.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label41.BackColor = System.Drawing.Color.Transparent
		Me.Label41.Text = "Estblcmto"
		Me.Label41.ForeColor = System.Drawing.Color.FromARGB(128, 128, 128)
		Me.Label41.Size = New System.Drawing.Size(42, 13)
		Me.Label41.Location = New System.Drawing.Point(104, 56)
		Me.Label41.TabIndex = 47
		Me.Label41.Enabled = True
		Me.Label41.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label41.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label41.UseMnemonic = True
		Me.Label41.Visible = True
		Me.Label41.AutoSize = True
		Me.Label41.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label41.Name = "Label41"
		Me.Label40.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label40.BackColor = System.Drawing.Color.Transparent
		Me.Label40.Text = "PtoEmision"
		Me.Label40.ForeColor = System.Drawing.Color.FromARGB(128, 128, 128)
		Me.Label40.Size = New System.Drawing.Size(47, 13)
		Me.Label40.Location = New System.Drawing.Point(152, 56)
		Me.Label40.TabIndex = 49
		Me.Label40.Enabled = True
		Me.Label40.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label40.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label40.UseMnemonic = True
		Me.Label40.Visible = True
		Me.Label40.AutoSize = True
		Me.Label40.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label40.Name = "Label40"
		Me.Label39.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label39.BackColor = System.Drawing.Color.Transparent
		Me.Label39.Text = "Nro Secuencial"
		Me.Label39.ForeColor = System.Drawing.Color.FromARGB(128, 128, 128)
		Me.Label39.Size = New System.Drawing.Size(64, 13)
		Me.Label39.Location = New System.Drawing.Point(208, 56)
		Me.Label39.TabIndex = 51
		Me.Label39.Enabled = True
		Me.Label39.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label39.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label39.UseMnemonic = True
		Me.Label39.Visible = True
		Me.Label39.AutoSize = True
		Me.Label39.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label39.Name = "Label39"
		Me.Label38.Text = "F&echaEmisiónModificado"
		Me.Label38.Size = New System.Drawing.Size(118, 13)
		Me.Label38.Location = New System.Drawing.Point(288, 48)
		Me.Label38.TabIndex = 53
		Me.Label38.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label38.BackColor = System.Drawing.Color.Transparent
		Me.Label38.Enabled = True
		Me.Label38.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label38.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label38.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label38.UseMnemonic = True
		Me.Label38.Visible = True
		Me.Label38.AutoSize = True
		Me.Label38.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label38.Name = "Label38"
		Me.Label37.Text = "dd/mm/aaaa"
		Me.Label37.Enabled = False
		Me.Label37.ForeColor = System.Drawing.Color.FromARGB(128, 128, 128)
		Me.Label37.Size = New System.Drawing.Size(52, 13)
		Me.Label37.Location = New System.Drawing.Point(416, 56)
		Me.Label37.TabIndex = 54
		Me.Label37.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label37.BackColor = System.Drawing.Color.Transparent
		Me.Label37.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label37.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label37.UseMnemonic = True
		Me.Label37.Visible = True
		Me.Label37.AutoSize = True
		Me.Label37.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label37.Name = "Label37"
		Me.txtFecEmiCom.AutoSize = False
		Me.txtFecEmiCom.Size = New System.Drawing.Size(65, 19)
		Me.txtFecEmiCom.Location = New System.Drawing.Point(424, 88)
		Me.txtFecEmiCom.Maxlength = 10
		Me.txtFecEmiCom.TabIndex = 16
		Me.ToolTip1.SetToolTip(Me.txtFecEmiCom, "Fecha de emisión del comprobante")
		Me.txtFecEmiCom.AcceptsReturn = True
		Me.txtFecEmiCom.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtFecEmiCom.BackColor = System.Drawing.SystemColors.Window
		Me.txtFecEmiCom.CausesValidation = True
		Me.txtFecEmiCom.Enabled = True
		Me.txtFecEmiCom.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtFecEmiCom.HideSelection = True
		Me.txtFecEmiCom.ReadOnly = False
		Me.txtFecEmiCom.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtFecEmiCom.MultiLine = False
		Me.txtFecEmiCom.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtFecEmiCom.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtFecEmiCom.TabStop = True
		Me.txtFecEmiCom.Visible = True
		Me.txtFecEmiCom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtFecEmiCom.Name = "txtFecEmiCom"
		Me.txtFecRegCont.AutoSize = False
		Me.txtFecRegCont.Size = New System.Drawing.Size(65, 19)
		Me.txtFecRegCont.Location = New System.Drawing.Point(640, 88)
		Me.txtFecRegCont.Maxlength = 10
		Me.txtFecRegCont.TabIndex = 20
		Me.ToolTip1.SetToolTip(Me.txtFecRegCont, "Fecha de registro contable")
		Me.txtFecRegCont.AcceptsReturn = True
		Me.txtFecRegCont.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtFecRegCont.BackColor = System.Drawing.SystemColors.Window
		Me.txtFecRegCont.CausesValidation = True
		Me.txtFecRegCont.Enabled = True
		Me.txtFecRegCont.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtFecRegCont.HideSelection = True
		Me.txtFecRegCont.ReadOnly = False
		Me.txtFecRegCont.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtFecRegCont.MultiLine = False
		Me.txtFecRegCont.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtFecRegCont.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtFecRegCont.TabStop = True
		Me.txtFecRegCont.Visible = True
		Me.txtFecRegCont.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtFecRegCont.Name = "txtFecRegCont"
		Me.txtBasImpTar0.AutoSize = False
		Me.txtBasImpTar0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtBasImpTar0.Size = New System.Drawing.Size(89, 19)
		Me.txtBasImpTar0.Location = New System.Drawing.Point(136, 208)
		Me.txtBasImpTar0.Maxlength = 12
		Me.txtBasImpTar0.TabIndex = 33
		Me.ToolTip1.SetToolTip(Me.txtBasImpTar0, "Base imponible tarifa cero")
		Me.txtBasImpTar0.AcceptsReturn = True
		Me.txtBasImpTar0.BackColor = System.Drawing.SystemColors.Window
		Me.txtBasImpTar0.CausesValidation = True
		Me.txtBasImpTar0.Enabled = True
		Me.txtBasImpTar0.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtBasImpTar0.HideSelection = True
		Me.txtBasImpTar0.ReadOnly = False
		Me.txtBasImpTar0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtBasImpTar0.MultiLine = False
		Me.txtBasImpTar0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtBasImpTar0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtBasImpTar0.TabStop = True
		Me.txtBasImpTar0.Visible = True
		Me.txtBasImpTar0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtBasImpTar0.Name = "txtBasImpTar0"
		Me.txtMonIvaBie.AutoSize = False
		Me.txtMonIvaBie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtMonIvaBie.Size = New System.Drawing.Size(89, 19)
		Me.txtMonIvaBie.Location = New System.Drawing.Point(376, 240)
		Me.txtMonIvaBie.Maxlength = 12
		Me.txtMonIvaBie.TabIndex = 41
		Me.ToolTip1.SetToolTip(Me.txtMonIvaBie, "Monto Iva por transferencia de bienes")
		Me.txtMonIvaBie.AcceptsReturn = True
		Me.txtMonIvaBie.BackColor = System.Drawing.SystemColors.Window
		Me.txtMonIvaBie.CausesValidation = True
		Me.txtMonIvaBie.Enabled = True
		Me.txtMonIvaBie.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtMonIvaBie.HideSelection = True
		Me.txtMonIvaBie.ReadOnly = False
		Me.txtMonIvaBie.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMonIvaBie.MultiLine = False
		Me.txtMonIvaBie.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMonIvaBie.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMonIvaBie.TabStop = True
		Me.txtMonIvaBie.Visible = True
		Me.txtMonIvaBie.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMonIvaBie.Name = "txtMonIvaBie"
		Me.TxtBasImpICE.AutoSize = False
		Me.TxtBasImpICE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.TxtBasImpICE.Size = New System.Drawing.Size(89, 19)
		Me.TxtBasImpICE.Location = New System.Drawing.Point(336, 168)
		Me.TxtBasImpICE.Maxlength = 12
		Me.TxtBasImpICE.TabIndex = 27
		Me.ToolTip1.SetToolTip(Me.TxtBasImpICE, "Base imponible grabada")
		Me.TxtBasImpICE.AcceptsReturn = True
		Me.TxtBasImpICE.BackColor = System.Drawing.SystemColors.Window
		Me.TxtBasImpICE.CausesValidation = True
		Me.TxtBasImpICE.Enabled = True
		Me.TxtBasImpICE.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtBasImpICE.HideSelection = True
		Me.TxtBasImpICE.ReadOnly = False
		Me.TxtBasImpICE.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtBasImpICE.MultiLine = False
		Me.TxtBasImpICE.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtBasImpICE.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtBasImpICE.TabStop = True
		Me.TxtBasImpICE.Visible = True
		Me.TxtBasImpICE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtBasImpICE.Name = "TxtBasImpICE"
		Me.txtBasImpGra.AutoSize = False
		Me.txtBasImpGra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtBasImpGra.Size = New System.Drawing.Size(89, 19)
		Me.txtBasImpGra.Location = New System.Drawing.Point(376, 208)
		Me.txtBasImpGra.Maxlength = 12
		Me.txtBasImpGra.TabIndex = 35
		Me.ToolTip1.SetToolTip(Me.txtBasImpGra, "Base imponible grabada")
		Me.txtBasImpGra.AcceptsReturn = True
		Me.txtBasImpGra.BackColor = System.Drawing.SystemColors.Window
		Me.txtBasImpGra.CausesValidation = True
		Me.txtBasImpGra.Enabled = True
		Me.txtBasImpGra.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtBasImpGra.HideSelection = True
		Me.txtBasImpGra.ReadOnly = False
		Me.txtBasImpGra.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtBasImpGra.MultiLine = False
		Me.txtBasImpGra.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtBasImpGra.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtBasImpGra.TabStop = True
		Me.txtBasImpGra.Visible = True
		Me.txtBasImpGra.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtBasImpGra.Name = "txtBasImpGra"
		DcPorICE.OcxState = CType(resources.GetObject("DcPorICE.OcxState"), System.Windows.Forms.AxHost.State)
		Me.DcPorICE.Size = New System.Drawing.Size(177, 21)
		Me.DcPorICE.Location = New System.Drawing.Point(72, 168)
		Me.DcPorICE.TabIndex = 25
		Me.DcPorICE.Name = "DcPorICE"
		Me.dtCodSus.Size = New System.Drawing.Size(80, 22)
		Me.dtCodSus.Location = New System.Drawing.Point(648, 48)
		Me.dtCodSus.Visible = 0
		Me.dtCodSus.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		Me.dtCodSus.ConnectionTimeout = 15
		Me.dtCodSus.CommandTimeout = 30
		Me.dtCodSus.CursorType = ADODB.CursorTypeEnum.adOpenStatic
		Me.dtCodSus.LockType = ADODB.LockTypeEnum.adLockOptimistic
		Me.dtCodSus.CommandType = ADODB.CommandTypeEnum.adCmdText
		Me.dtCodSus.CacheSize = 50
		Me.dtCodSus.MaxRecords = 0
		Me.dtCodSus.BOFAction = Microsoft.VisualBasic.Compatibility.VB6.ADODC.BOFActionEnum.adDoMoveFirst
		Me.dtCodSus.EOFAction = Microsoft.VisualBasic.Compatibility.VB6.ADODC.EOFActionEnum.adDoMoveLast
		Me.dtCodSus.BackColor = System.Drawing.SystemColors.Window
		Me.dtCodSus.ForeColor = System.Drawing.SystemColors.WindowText
		Me.dtCodSus.Orientation = Microsoft.VisualBasic.Compatibility.VB6.ADODC.OrientationEnum.adHorizontal
		Me.dtCodSus.Enabled = True
		Me.dtCodSus.UserName = ""
		Me.dtCodSus.RecordSource = ""
		Me.dtCodSus.Text = ""
		Me.dtCodSus.ConnectionString = ""
		Me.dtCodSus.Name = "dtCodSus"
		Me.DtPorIvaServ.Size = New System.Drawing.Size(80, 22)
		Me.DtPorIvaServ.Location = New System.Drawing.Point(616, 136)
		Me.DtPorIvaServ.Visible = 0
		Me.DtPorIvaServ.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		Me.DtPorIvaServ.ConnectionTimeout = 15
		Me.DtPorIvaServ.CommandTimeout = 30
		Me.DtPorIvaServ.CursorType = ADODB.CursorTypeEnum.adOpenStatic
		Me.DtPorIvaServ.LockType = ADODB.LockTypeEnum.adLockOptimistic
		Me.DtPorIvaServ.CommandType = ADODB.CommandTypeEnum.adCmdText
		Me.DtPorIvaServ.CacheSize = 50
		Me.DtPorIvaServ.MaxRecords = 0
		Me.DtPorIvaServ.BOFAction = Microsoft.VisualBasic.Compatibility.VB6.ADODC.BOFActionEnum.adDoMoveFirst
		Me.DtPorIvaServ.EOFAction = Microsoft.VisualBasic.Compatibility.VB6.ADODC.EOFActionEnum.adDoMoveLast
		Me.DtPorIvaServ.BackColor = System.Drawing.SystemColors.Window
		Me.DtPorIvaServ.ForeColor = System.Drawing.SystemColors.WindowText
		Me.DtPorIvaServ.Orientation = Microsoft.VisualBasic.Compatibility.VB6.ADODC.OrientationEnum.adHorizontal
		Me.DtPorIvaServ.Enabled = True
		Me.DtPorIvaServ.UserName = ""
		Me.DtPorIvaServ.RecordSource = ""
		Me.DtPorIvaServ.Text = ""
		Me.DtPorIvaServ.ConnectionString = ""
		Me.DtPorIvaServ.Name = "DtPorIvaServ"
		Me.dtCom.Size = New System.Drawing.Size(80, 22)
		Me.dtCom.Location = New System.Drawing.Point(648, 128)
		Me.dtCom.Visible = 0
		Me.dtCom.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		Me.dtCom.ConnectionTimeout = 15
		Me.dtCom.CommandTimeout = 30
		Me.dtCom.CursorType = ADODB.CursorTypeEnum.adOpenStatic
		Me.dtCom.LockType = ADODB.LockTypeEnum.adLockOptimistic
		Me.dtCom.CommandType = ADODB.CommandTypeEnum.adCmdText
		Me.dtCom.CacheSize = 50
		Me.dtCom.MaxRecords = 0
		Me.dtCom.BOFAction = Microsoft.VisualBasic.Compatibility.VB6.ADODC.BOFActionEnum.adDoMoveFirst
		Me.dtCom.EOFAction = Microsoft.VisualBasic.Compatibility.VB6.ADODC.EOFActionEnum.adDoMoveLast
		Me.dtCom.BackColor = System.Drawing.SystemColors.Window
		Me.dtCom.ForeColor = System.Drawing.SystemColors.WindowText
		Me.dtCom.Orientation = Microsoft.VisualBasic.Compatibility.VB6.ADODC.OrientationEnum.adHorizontal
		Me.dtCom.Enabled = True
		Me.dtCom.UserName = ""
		Me.dtCom.RecordSource = ""
		Me.dtCom.Text = ""
		Me.dtCom.ConnectionString = ""
		Me.dtCom.Name = "dtCom"
		Me.dtPorIva.Size = New System.Drawing.Size(80, 22)
		Me.dtPorIva.Location = New System.Drawing.Point(648, 120)
		Me.dtPorIva.Visible = 0
		Me.dtPorIva.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		Me.dtPorIva.ConnectionTimeout = 15
		Me.dtPorIva.CommandTimeout = 30
		Me.dtPorIva.CursorType = ADODB.CursorTypeEnum.adOpenStatic
		Me.dtPorIva.LockType = ADODB.LockTypeEnum.adLockOptimistic
		Me.dtPorIva.CommandType = ADODB.CommandTypeEnum.adCmdText
		Me.dtPorIva.CacheSize = 50
		Me.dtPorIva.MaxRecords = 0
		Me.dtPorIva.BOFAction = Microsoft.VisualBasic.Compatibility.VB6.ADODC.BOFActionEnum.adDoMoveFirst
		Me.dtPorIva.EOFAction = Microsoft.VisualBasic.Compatibility.VB6.ADODC.EOFActionEnum.adDoMoveLast
		Me.dtPorIva.BackColor = System.Drawing.SystemColors.Window
		Me.dtPorIva.ForeColor = System.Drawing.SystemColors.WindowText
		Me.dtPorIva.Orientation = Microsoft.VisualBasic.Compatibility.VB6.ADODC.OrientationEnum.adHorizontal
		Me.dtPorIva.Enabled = True
		Me.dtPorIva.UserName = ""
		Me.dtPorIva.RecordSource = ""
		Me.dtPorIva.Text = ""
		Me.dtPorIva.ConnectionString = ""
		Me.dtPorIva.Name = "dtPorIva"
		Me.DtPorICE.Size = New System.Drawing.Size(80, 22)
		Me.DtPorICE.Location = New System.Drawing.Point(648, 112)
		Me.DtPorICE.Visible = 0
		Me.DtPorICE.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		Me.DtPorICE.ConnectionTimeout = 15
		Me.DtPorICE.CommandTimeout = 30
		Me.DtPorICE.CursorType = ADODB.CursorTypeEnum.adOpenStatic
		Me.DtPorICE.LockType = ADODB.LockTypeEnum.adLockOptimistic
		Me.DtPorICE.CommandType = ADODB.CommandTypeEnum.adCmdText
		Me.DtPorICE.CacheSize = 50
		Me.DtPorICE.MaxRecords = 0
		Me.DtPorICE.BOFAction = Microsoft.VisualBasic.Compatibility.VB6.ADODC.BOFActionEnum.adDoMoveFirst
		Me.DtPorICE.EOFAction = Microsoft.VisualBasic.Compatibility.VB6.ADODC.EOFActionEnum.adDoMoveLast
		Me.DtPorICE.BackColor = System.Drawing.SystemColors.Window
		Me.DtPorICE.ForeColor = System.Drawing.SystemColors.WindowText
		Me.DtPorICE.Orientation = Microsoft.VisualBasic.Compatibility.VB6.ADODC.OrientationEnum.adHorizontal
		Me.DtPorICE.Enabled = True
		Me.DtPorICE.UserName = ""
		Me.DtPorICE.RecordSource = ""
		Me.DtPorICE.Text = ""
		Me.DtPorICE.ConnectionString = ""
		Me.DtPorICE.Name = "DtPorICE"
		Me.dtPorIvaBie.Size = New System.Drawing.Size(80, 22)
		Me.dtPorIvaBie.Location = New System.Drawing.Point(648, 136)
		Me.dtPorIvaBie.Visible = 0
		Me.dtPorIvaBie.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		Me.dtPorIvaBie.ConnectionTimeout = 15
		Me.dtPorIvaBie.CommandTimeout = 30
		Me.dtPorIvaBie.CursorType = ADODB.CursorTypeEnum.adOpenStatic
		Me.dtPorIvaBie.LockType = ADODB.LockTypeEnum.adLockOptimistic
		Me.dtPorIvaBie.CommandType = ADODB.CommandTypeEnum.adCmdText
		Me.dtPorIvaBie.CacheSize = 50
		Me.dtPorIvaBie.MaxRecords = 0
		Me.dtPorIvaBie.BOFAction = Microsoft.VisualBasic.Compatibility.VB6.ADODC.BOFActionEnum.adDoMoveFirst
		Me.dtPorIvaBie.EOFAction = Microsoft.VisualBasic.Compatibility.VB6.ADODC.EOFActionEnum.adDoMoveLast
		Me.dtPorIvaBie.BackColor = System.Drawing.SystemColors.Window
		Me.dtPorIvaBie.ForeColor = System.Drawing.SystemColors.WindowText
		Me.dtPorIvaBie.Orientation = Microsoft.VisualBasic.Compatibility.VB6.ADODC.OrientationEnum.adHorizontal
		Me.dtPorIvaBie.Enabled = True
		Me.dtPorIvaBie.UserName = ""
		Me.dtPorIvaBie.RecordSource = ""
		Me.dtPorIvaBie.Text = ""
		Me.dtPorIvaBie.ConnectionString = ""
		Me.dtPorIvaBie.Name = "dtPorIvaBie"
		dcPorIva.OcxState = CType(resources.GetObject("dcPorIva.OcxState"), System.Windows.Forms.AxHost.State)
		Me.dcPorIva.Size = New System.Drawing.Size(65, 21)
		Me.dcPorIva.Location = New System.Drawing.Point(584, 208)
		Me.dcPorIva.TabIndex = 37
		Me.dcPorIva.Name = "dcPorIva"
		TipoComprobante.OcxState = CType(resources.GetObject("TipoComprobante.OcxState"), System.Windows.Forms.AxHost.State)
		Me.TipoComprobante.Size = New System.Drawing.Size(377, 21)
		Me.TipoComprobante.Location = New System.Drawing.Point(112, 120)
		Me.TipoComprobante.TabIndex = 23
		Me.TipoComprobante.Name = "TipoComprobante"
		Me.DtComMod.Size = New System.Drawing.Size(80, 22)
		Me.DtComMod.Location = New System.Drawing.Point(648, 128)
		Me.DtComMod.Visible = 0
		Me.DtComMod.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		Me.DtComMod.ConnectionTimeout = 15
		Me.DtComMod.CommandTimeout = 30
		Me.DtComMod.CursorType = ADODB.CursorTypeEnum.adOpenStatic
		Me.DtComMod.LockType = ADODB.LockTypeEnum.adLockOptimistic
		Me.DtComMod.CommandType = ADODB.CommandTypeEnum.adCmdText
		Me.DtComMod.CacheSize = 50
		Me.DtComMod.MaxRecords = 0
		Me.DtComMod.BOFAction = Microsoft.VisualBasic.Compatibility.VB6.ADODC.BOFActionEnum.adDoMoveFirst
		Me.DtComMod.EOFAction = Microsoft.VisualBasic.Compatibility.VB6.ADODC.EOFActionEnum.adDoMoveLast
		Me.DtComMod.BackColor = System.Drawing.SystemColors.Window
		Me.DtComMod.ForeColor = System.Drawing.SystemColors.WindowText
		Me.DtComMod.Orientation = Microsoft.VisualBasic.Compatibility.VB6.ADODC.OrientationEnum.adHorizontal
		Me.DtComMod.Enabled = True
		Me.DtComMod.UserName = ""
		Me.DtComMod.RecordSource = ""
		Me.DtComMod.Text = ""
		Me.DtComMod.ConnectionString = ""
		Me.DtComMod.Name = "DtComMod"
		Me.DtPorRetIR.Size = New System.Drawing.Size(80, 22)
		Me.DtPorRetIR.Location = New System.Drawing.Point(648, 48)
		Me.DtPorRetIR.Visible = 0
		Me.DtPorRetIR.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		Me.DtPorRetIR.ConnectionTimeout = 15
		Me.DtPorRetIR.CommandTimeout = 30
		Me.DtPorRetIR.CursorType = ADODB.CursorTypeEnum.adOpenStatic
		Me.DtPorRetIR.LockType = ADODB.LockTypeEnum.adLockOptimistic
		Me.DtPorRetIR.CommandType = ADODB.CommandTypeEnum.adCmdText
		Me.DtPorRetIR.CacheSize = 50
		Me.DtPorRetIR.MaxRecords = 0
		Me.DtPorRetIR.BOFAction = Microsoft.VisualBasic.Compatibility.VB6.ADODC.BOFActionEnum.adDoMoveFirst
		Me.DtPorRetIR.EOFAction = Microsoft.VisualBasic.Compatibility.VB6.ADODC.EOFActionEnum.adDoMoveLast
		Me.DtPorRetIR.BackColor = System.Drawing.SystemColors.Window
		Me.DtPorRetIR.ForeColor = System.Drawing.SystemColors.WindowText
		Me.DtPorRetIR.Orientation = Microsoft.VisualBasic.Compatibility.VB6.ADODC.OrientationEnum.adHorizontal
		Me.DtPorRetIR.Enabled = True
		Me.DtPorRetIR.UserName = ""
		Me.DtPorRetIR.RecordSource = ""
		Me.DtPorRetIR.Text = ""
		Me.DtPorRetIR.ConnectionString = ""
		Me.DtPorRetIR.Name = "DtPorRetIR"
		DatSustento.OcxState = CType(resources.GetObject("DatSustento.OcxState"), System.Windows.Forms.AxHost.State)
		Me.DatSustento.Size = New System.Drawing.Size(441, 21)
		Me.DatSustento.Location = New System.Drawing.Point(144, 16)
		Me.DatSustento.TabIndex = 1
		Me.DatSustento.Name = "DatSustento"
		Me.Label1.Text = "&Sustento Tributario o gasto"
		Me.Label1.Size = New System.Drawing.Size(127, 13)
		Me.Label1.Location = New System.Drawing.Point(8, 24)
		Me.Label1.TabIndex = 0
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.Color.Transparent
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = True
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.lbNomP.BackColor = System.Drawing.Color.White
		Me.lbNomP.Size = New System.Drawing.Size(366, 19)
		Me.lbNomP.Location = New System.Drawing.Point(264, 56)
		Me.lbNomP.TabIndex = 6
		Me.lbNomP.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbNomP.Enabled = True
		Me.lbNomP.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lbNomP.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbNomP.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbNomP.UseMnemonic = True
		Me.lbNomP.Visible = True
		Me.lbNomP.AutoSize = False
		Me.lbNomP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lbNomP.Name = "lbNomP"
		Me.lbClioPro.Text = "&Identificación del Proveedor"
		Me.lbClioPro.Size = New System.Drawing.Size(132, 13)
		Me.lbClioPro.Location = New System.Drawing.Point(0, 64)
		Me.lbClioPro.TabIndex = 3
		Me.lbClioPro.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbClioPro.BackColor = System.Drawing.Color.Transparent
		Me.lbClioPro.Enabled = True
		Me.lbClioPro.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lbClioPro.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbClioPro.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbClioPro.UseMnemonic = True
		Me.lbClioPro.Visible = True
		Me.lbClioPro.AutoSize = True
		Me.lbClioPro.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbClioPro.Name = "lbClioPro"
		Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label15.BackColor = System.Drawing.Color.Transparent
		Me.Label15.Text = "Nro Secuencial"
		Me.Label15.ForeColor = System.Drawing.Color.FromARGB(128, 128, 128)
		Me.Label15.Size = New System.Drawing.Size(64, 13)
		Me.Label15.Location = New System.Drawing.Point(189, 104)
		Me.Label15.TabIndex = 12
		Me.Label15.Enabled = True
		Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label15.UseMnemonic = True
		Me.Label15.Visible = True
		Me.Label15.AutoSize = True
		Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label15.Name = "Label15"
		Me.Label24.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label24.BackColor = System.Drawing.Color.Transparent
		Me.Label24.Text = "PtoEmision"
		Me.Label24.ForeColor = System.Drawing.Color.FromARGB(128, 128, 128)
		Me.Label24.Size = New System.Drawing.Size(47, 13)
		Me.Label24.Location = New System.Drawing.Point(136, 104)
		Me.Label24.TabIndex = 10
		Me.Label24.Enabled = True
		Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label24.UseMnemonic = True
		Me.Label24.Visible = True
		Me.Label24.AutoSize = True
		Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label24.Name = "Label24"
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label4.BackColor = System.Drawing.Color.Transparent
		Me.Label4.Text = "Estblcmto"
		Me.Label4.ForeColor = System.Drawing.Color.FromARGB(128, 128, 128)
		Me.Label4.Size = New System.Drawing.Size(42, 13)
		Me.Label4.Location = New System.Drawing.Point(88, 104)
		Me.Label4.TabIndex = 9
		Me.Label4.Enabled = True
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = True
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.lbfactor.Text = "NroComprobante"
		Me.lbfactor.Size = New System.Drawing.Size(80, 13)
		Me.lbfactor.Location = New System.Drawing.Point(0, 96)
		Me.lbfactor.TabIndex = 7
		Me.lbfactor.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbfactor.BackColor = System.Drawing.Color.Transparent
		Me.lbfactor.Enabled = True
		Me.lbfactor.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lbfactor.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbfactor.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbfactor.UseMnemonic = True
		Me.lbfactor.Visible = True
		Me.lbfactor.AutoSize = True
		Me.lbfactor.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbfactor.Name = "lbfactor"
		Me.TxtPorcIce.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.TxtPorcIce.BackColor = System.Drawing.Color.White
		Me.TxtPorcIce.Size = New System.Drawing.Size(62, 19)
		Me.TxtPorcIce.Location = New System.Drawing.Point(472, 168)
		Me.TxtPorcIce.TabIndex = 29
		Me.TxtPorcIce.Enabled = True
		Me.TxtPorcIce.ForeColor = System.Drawing.SystemColors.ControlText
		Me.TxtPorcIce.Cursor = System.Windows.Forms.Cursors.Default
		Me.TxtPorcIce.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtPorcIce.UseMnemonic = True
		Me.TxtPorcIce.Visible = True
		Me.TxtPorcIce.AutoSize = False
		Me.TxtPorcIce.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtPorcIce.Name = "TxtPorcIce"
		Me.Label48.Text = "%ICE"
		Me.Label48.Size = New System.Drawing.Size(25, 13)
		Me.Label48.Location = New System.Drawing.Point(440, 176)
		Me.Label48.TabIndex = 28
		Me.Label48.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label48.BackColor = System.Drawing.Color.Transparent
		Me.Label48.Enabled = True
		Me.Label48.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label48.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label48.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label48.UseMnemonic = True
		Me.Label48.Visible = True
		Me.Label48.AutoSize = True
		Me.Label48.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label48.Name = "Label48"
		Me.TxtMonIvaSer.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.TxtMonIvaSer.BackColor = System.Drawing.Color.White
		Me.TxtMonIvaSer.Size = New System.Drawing.Size(102, 19)
		Me.TxtMonIvaSer.Location = New System.Drawing.Point(600, 240)
		Me.TxtMonIvaSer.TabIndex = 43
		Me.TxtMonIvaSer.Enabled = True
		Me.TxtMonIvaSer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.TxtMonIvaSer.Cursor = System.Windows.Forms.Cursors.Default
		Me.TxtMonIvaSer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtMonIvaSer.UseMnemonic = True
		Me.TxtMonIvaSer.Visible = True
		Me.TxtMonIvaSer.AutoSize = False
		Me.TxtMonIvaSer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtMonIvaSer.Name = "TxtMonIvaSer"
		Me.TxtMonIva.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.TxtMonIva.BackColor = System.Drawing.Color.White
		Me.TxtMonIva.Size = New System.Drawing.Size(102, 19)
		Me.TxtMonIva.Location = New System.Drawing.Point(144, 240)
		Me.TxtMonIva.TabIndex = 39
		Me.TxtMonIva.Enabled = True
		Me.TxtMonIva.ForeColor = System.Drawing.SystemColors.ControlText
		Me.TxtMonIva.Cursor = System.Windows.Forms.Cursors.Default
		Me.TxtMonIva.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtMonIva.UseMnemonic = True
		Me.TxtMonIva.Visible = True
		Me.TxtMonIva.AutoSize = False
		Me.TxtMonIva.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtMonIva.Name = "TxtMonIva"
		Me.TxtMonIce.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.TxtMonIce.BackColor = System.Drawing.Color.White
		Me.TxtMonIce.Size = New System.Drawing.Size(102, 19)
		Me.TxtMonIce.Location = New System.Drawing.Point(608, 168)
		Me.TxtMonIce.TabIndex = 31
		Me.TxtMonIce.Enabled = True
		Me.TxtMonIce.ForeColor = System.Drawing.SystemColors.ControlText
		Me.TxtMonIce.Cursor = System.Windows.Forms.Cursors.Default
		Me.TxtMonIce.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtMonIce.UseMnemonic = True
		Me.TxtMonIce.Visible = True
		Me.TxtMonIce.AutoSize = False
		Me.TxtMonIce.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtMonIce.Name = "TxtMonIce"
		Me.Label3.Text = "&Tipo de Comprobante"
		Me.Label3.Size = New System.Drawing.Size(102, 13)
		Me.Label3.Location = New System.Drawing.Point(0, 128)
		Me.Label3.TabIndex = 22
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.Color.Transparent
		Me.Label3.Enabled = True
		Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = True
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Label5.Size = New System.Drawing.Size(4, 20)
		Me.Label5.Location = New System.Drawing.Point(472, 168)
		Me.Label5.TabIndex = 106
		Me.Label5.Visible = False
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label5.BackColor = System.Drawing.Color.Transparent
		Me.Label5.Enabled = True
		Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label5.UseMnemonic = True
		Me.Label5.AutoSize = True
		Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label5.Name = "Label5"
		Me.Label49.Text = "dd/mm/aaaa"
		Me.Label49.Enabled = False
		Me.Label49.ForeColor = System.Drawing.Color.FromARGB(128, 128, 128)
		Me.Label49.Size = New System.Drawing.Size(52, 13)
		Me.Label49.Location = New System.Drawing.Point(432, 104)
		Me.Label49.TabIndex = 15
		Me.Label49.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label49.BackColor = System.Drawing.Color.Transparent
		Me.Label49.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label49.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label49.UseMnemonic = True
		Me.Label49.Visible = True
		Me.Label49.AutoSize = True
		Me.Label49.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label49.Name = "Label49"
		Me.Label14.Text = "&Fecha Emisión del Comprobante"
		Me.Label14.Size = New System.Drawing.Size(152, 13)
		Me.Label14.Location = New System.Drawing.Point(264, 96)
		Me.Label14.TabIndex = 14
		Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label14.BackColor = System.Drawing.Color.Transparent
		Me.Label14.Enabled = True
		Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label14.UseMnemonic = True
		Me.Label14.Visible = True
		Me.Label14.AutoSize = True
		Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label14.Name = "Label14"
		Me.Label10.Text = "F&echaRegistroContable"
		Me.Label10.Size = New System.Drawing.Size(111, 13)
		Me.Label10.Location = New System.Drawing.Point(520, 96)
		Me.Label10.TabIndex = 18
		Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label10.BackColor = System.Drawing.Color.Transparent
		Me.Label10.Enabled = True
		Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label10.UseMnemonic = True
		Me.Label10.Visible = True
		Me.Label10.AutoSize = True
		Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label10.Name = "Label10"
		Me.Label7.Text = "BaseImponibleTarifa 0%"
		Me.Label7.Size = New System.Drawing.Size(113, 13)
		Me.Label7.Location = New System.Drawing.Point(8, 216)
		Me.Label7.TabIndex = 32
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label7.BackColor = System.Drawing.Color.Transparent
		Me.Label7.Enabled = True
		Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label7.UseMnemonic = True
		Me.Label7.Visible = True
		Me.Label7.AutoSize = True
		Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label7.Name = "Label7"
		Me.Label12.Text = "Monto  ICE"
		Me.Label12.Size = New System.Drawing.Size(53, 13)
		Me.Label12.Location = New System.Drawing.Point(544, 176)
		Me.Label12.TabIndex = 30
		Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label12.BackColor = System.Drawing.Color.Transparent
		Me.Label12.Enabled = True
		Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label12.UseMnemonic = True
		Me.Label12.Visible = True
		Me.Label12.AutoSize = True
		Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label12.Name = "Label12"
		Me.Label25.Text = "dd/mm/aaaa"
		Me.Label25.Enabled = False
		Me.Label25.ForeColor = System.Drawing.Color.FromARGB(128, 128, 128)
		Me.Label25.Size = New System.Drawing.Size(52, 13)
		Me.Label25.Location = New System.Drawing.Point(648, 104)
		Me.Label25.TabIndex = 19
		Me.Label25.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label25.BackColor = System.Drawing.Color.Transparent
		Me.Label25.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label25.UseMnemonic = True
		Me.Label25.Visible = True
		Me.Label25.AutoSize = True
		Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label25.Name = "Label25"
		Me.Label16.Text = "Monto IVA Servicios"
		Me.Label16.Size = New System.Drawing.Size(96, 13)
		Me.Label16.Location = New System.Drawing.Point(496, 248)
		Me.Label16.TabIndex = 42
		Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label16.BackColor = System.Drawing.Color.Transparent
		Me.Label16.Enabled = True
		Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label16.UseMnemonic = True
		Me.Label16.Visible = True
		Me.Label16.AutoSize = True
		Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label16.Name = "Label16"
		Me.Label19.Text = "Monto IVA Bienes"
		Me.Label19.Size = New System.Drawing.Size(85, 13)
		Me.Label19.Location = New System.Drawing.Point(280, 248)
		Me.Label19.TabIndex = 40
		Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label19.BackColor = System.Drawing.Color.Transparent
		Me.Label19.Enabled = True
		Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label19.UseMnemonic = True
		Me.Label19.Visible = True
		Me.Label19.AutoSize = True
		Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label19.Name = "Label19"
		Me.Label9.Text = "Concepto ICE"
		Me.Label9.Size = New System.Drawing.Size(66, 13)
		Me.Label9.Location = New System.Drawing.Point(0, 176)
		Me.Label9.TabIndex = 24
		Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label9.BackColor = System.Drawing.Color.Transparent
		Me.Label9.Enabled = True
		Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label9.UseMnemonic = True
		Me.Label9.Visible = True
		Me.Label9.AutoSize = True
		Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label9.Name = "Label9"
		Me.Label22.Text = "Base Imponible"
		Me.Label22.Size = New System.Drawing.Size(72, 13)
		Me.Label22.Location = New System.Drawing.Point(256, 176)
		Me.Label22.TabIndex = 26
		Me.Label22.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label22.BackColor = System.Drawing.Color.Transparent
		Me.Label22.Enabled = True
		Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label22.UseMnemonic = True
		Me.Label22.Visible = True
		Me.Label22.AutoSize = True
		Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label22.Name = "Label22"
		Me.Label8.Text = "Monto  IVA Base Imponible"
		Me.Label8.Size = New System.Drawing.Size(128, 13)
		Me.Label8.Location = New System.Drawing.Point(8, 248)
		Me.Label8.TabIndex = 38
		Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label8.BackColor = System.Drawing.Color.Transparent
		Me.Label8.Enabled = True
		Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label8.UseMnemonic = True
		Me.Label8.Visible = True
		Me.Label8.AutoSize = True
		Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label8.Name = "Label8"
		Me.Label2.Text = "Porcentaje  IVA"
		Me.Label2.Size = New System.Drawing.Size(74, 13)
		Me.Label2.Location = New System.Drawing.Point(496, 216)
		Me.Label2.TabIndex = 36
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.Color.Transparent
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = True
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label6.Text = "Base Imponible Grabada IVA"
		Me.Label6.Size = New System.Drawing.Size(136, 13)
		Me.Label6.Location = New System.Drawing.Point(232, 216)
		Me.Label6.TabIndex = 34
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label6.BackColor = System.Drawing.Color.Transparent
		Me.Label6.Enabled = True
		Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label6.UseMnemonic = True
		Me.Label6.Visible = True
		Me.Label6.AutoSize = True
		Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label6.Name = "Label6"
		Me._SSTab1_TabPage1.Text = "RETENCIONES"
		Me.Frame2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Frame2.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Frame2.Size = New System.Drawing.Size(745, 361)
		Me.Frame2.Location = New System.Drawing.Point(8, 24)
		Me.Frame2.TabIndex = 108
		Me.Frame2.BackColor = System.Drawing.SystemColors.Control
		Me.Frame2.Enabled = True
		Me.Frame2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame2.Visible = True
		Me.Frame2.Name = "Frame2"
		Me.BtnFechEmitRete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.BtnFechEmitRete.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.BtnFechEmitRete.Size = New System.Drawing.Size(17, 19)
		Me.BtnFechEmitRete.Location = New System.Drawing.Point(488, 16)
		Me.BtnFechEmitRete.Image = CType(resources.GetObject("BtnFechEmitRete.Image"), System.Drawing.Image)
		Me.BtnFechEmitRete.TabIndex = 67
		Me.ToolTip1.SetToolTip(Me.BtnFechEmitRete, "Escojer de una lista")
		Me.BtnFechEmitRete.CausesValidation = True
		Me.BtnFechEmitRete.Enabled = True
		Me.BtnFechEmitRete.ForeColor = System.Drawing.SystemColors.ControlText
		Me.BtnFechEmitRete.Cursor = System.Windows.Forms.Cursors.Default
		Me.BtnFechEmitRete.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.BtnFechEmitRete.TabStop = True
		Me.BtnFechEmitRete.Name = "BtnFechEmitRete"
		Me.TxtSecuencialIR.AutoSize = False
		Me.TxtSecuencialIR.Size = New System.Drawing.Size(57, 19)
		Me.TxtSecuencialIR.Location = New System.Drawing.Point(208, 16)
		Me.TxtSecuencialIR.Maxlength = 10
		Me.TxtSecuencialIR.TabIndex = 63
		Me.ToolTip1.SetToolTip(Me.TxtSecuencialIR, "Número secuencial del comprobante")
		Me.TxtSecuencialIR.AcceptsReturn = True
		Me.TxtSecuencialIR.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TxtSecuencialIR.BackColor = System.Drawing.SystemColors.Window
		Me.TxtSecuencialIR.CausesValidation = True
		Me.TxtSecuencialIR.Enabled = True
		Me.TxtSecuencialIR.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtSecuencialIR.HideSelection = True
		Me.TxtSecuencialIR.ReadOnly = False
		Me.TxtSecuencialIR.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtSecuencialIR.MultiLine = False
		Me.TxtSecuencialIR.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtSecuencialIR.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtSecuencialIR.TabStop = True
		Me.TxtSecuencialIR.Visible = True
		Me.TxtSecuencialIR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtSecuencialIR.Name = "TxtSecuencialIR"
		Me.TxtSerieEstblIR.AutoSize = False
		Me.TxtSerieEstblIR.Size = New System.Drawing.Size(33, 19)
		Me.TxtSerieEstblIR.Location = New System.Drawing.Point(112, 16)
		Me.TxtSerieEstblIR.Maxlength = 3
		Me.TxtSerieEstblIR.TabIndex = 59
		Me.ToolTip1.SetToolTip(Me.TxtSerieEstblIR, "número de serie del comprobante")
		Me.TxtSerieEstblIR.AcceptsReturn = True
		Me.TxtSerieEstblIR.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TxtSerieEstblIR.BackColor = System.Drawing.SystemColors.Window
		Me.TxtSerieEstblIR.CausesValidation = True
		Me.TxtSerieEstblIR.Enabled = True
		Me.TxtSerieEstblIR.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtSerieEstblIR.HideSelection = True
		Me.TxtSerieEstblIR.ReadOnly = False
		Me.TxtSerieEstblIR.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtSerieEstblIR.MultiLine = False
		Me.TxtSerieEstblIR.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtSerieEstblIR.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtSerieEstblIR.TabStop = True
		Me.TxtSerieEstblIR.Visible = True
		Me.TxtSerieEstblIR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtSerieEstblIR.Name = "TxtSerieEstblIR"
		Me.TxtSerieEmision.AutoSize = False
		Me.TxtSerieEmision.Size = New System.Drawing.Size(33, 19)
		Me.TxtSerieEmision.Location = New System.Drawing.Point(160, 16)
		Me.TxtSerieEmision.Maxlength = 3
		Me.TxtSerieEmision.TabIndex = 61
		Me.ToolTip1.SetToolTip(Me.TxtSerieEmision, "número de serie del comprobante")
		Me.TxtSerieEmision.AcceptsReturn = True
		Me.TxtSerieEmision.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TxtSerieEmision.BackColor = System.Drawing.SystemColors.Window
		Me.TxtSerieEmision.CausesValidation = True
		Me.TxtSerieEmision.Enabled = True
		Me.TxtSerieEmision.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtSerieEmision.HideSelection = True
		Me.TxtSerieEmision.ReadOnly = False
		Me.TxtSerieEmision.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtSerieEmision.MultiLine = False
		Me.TxtSerieEmision.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtSerieEmision.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtSerieEmision.TabStop = True
		Me.TxtSerieEmision.Visible = True
		Me.TxtSerieEmision.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtSerieEmision.Name = "TxtSerieEmision"
		Me.TxtFechaEmicionIR.AutoSize = False
		Me.TxtFechaEmicionIR.Size = New System.Drawing.Size(65, 19)
		Me.TxtFechaEmicionIR.Location = New System.Drawing.Point(424, 16)
		Me.TxtFechaEmicionIR.Maxlength = 10
		Me.TxtFechaEmicionIR.TabIndex = 66
		Me.TxtFechaEmicionIR.AcceptsReturn = True
		Me.TxtFechaEmicionIR.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TxtFechaEmicionIR.BackColor = System.Drawing.SystemColors.Window
		Me.TxtFechaEmicionIR.CausesValidation = True
		Me.TxtFechaEmicionIR.Enabled = True
		Me.TxtFechaEmicionIR.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtFechaEmicionIR.HideSelection = True
		Me.TxtFechaEmicionIR.ReadOnly = False
		Me.TxtFechaEmicionIR.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtFechaEmicionIR.MultiLine = False
		Me.TxtFechaEmicionIR.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtFechaEmicionIR.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtFechaEmicionIR.TabStop = True
		Me.TxtFechaEmicionIR.Visible = True
		Me.TxtFechaEmicionIR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtFechaEmicionIR.Name = "TxtFechaEmicionIR"
		Me.Frame4.Text = "RETENCION AL IVA"
		Me.Frame4.Size = New System.Drawing.Size(729, 97)
		Me.Frame4.Location = New System.Drawing.Point(8, 64)
		Me.Frame4.TabIndex = 110
		Me.Frame4.BackColor = System.Drawing.SystemColors.Control
		Me.Frame4.Enabled = True
		Me.Frame4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame4.Visible = True
		Me.Frame4.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame4.Name = "Frame4"
		DcPorIvaServ.OcxState = CType(resources.GetObject("DcPorIvaServ.OcxState"), System.Windows.Forms.AxHost.State)
		Me.DcPorIvaServ.Size = New System.Drawing.Size(65, 21)
		Me.DcPorIvaServ.Location = New System.Drawing.Point(192, 56)
		Me.DcPorIvaServ.TabIndex = 73
		Me.DcPorIvaServ.Name = "DcPorIvaServ"
		dcPorIvaBie.OcxState = CType(resources.GetObject("dcPorIvaBie.OcxState"), System.Windows.Forms.AxHost.State)
		Me.dcPorIvaBie.Size = New System.Drawing.Size(65, 21)
		Me.dcPorIvaBie.Location = New System.Drawing.Point(192, 24)
		Me.dcPorIvaBie.TabIndex = 69
		Me.dcPorIvaBie.Name = "dcPorIvaBie"
		Me.TxtMonRetSer.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.TxtMonRetSer.BackColor = System.Drawing.Color.White
		Me.TxtMonRetSer.Size = New System.Drawing.Size(94, 19)
		Me.TxtMonRetSer.Location = New System.Drawing.Point(424, 56)
		Me.TxtMonRetSer.TabIndex = 75
		Me.TxtMonRetSer.Enabled = True
		Me.TxtMonRetSer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.TxtMonRetSer.Cursor = System.Windows.Forms.Cursors.Default
		Me.TxtMonRetSer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtMonRetSer.UseMnemonic = True
		Me.TxtMonRetSer.Visible = True
		Me.TxtMonRetSer.AutoSize = False
		Me.TxtMonRetSer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtMonRetSer.Name = "TxtMonRetSer"
		Me.TxtMonRetBie.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.TxtMonRetBie.BackColor = System.Drawing.Color.White
		Me.TxtMonRetBie.Size = New System.Drawing.Size(94, 19)
		Me.TxtMonRetBie.Location = New System.Drawing.Point(424, 24)
		Me.TxtMonRetBie.TabIndex = 71
		Me.TxtMonRetBie.Enabled = True
		Me.TxtMonRetBie.ForeColor = System.Drawing.SystemColors.ControlText
		Me.TxtMonRetBie.Cursor = System.Windows.Forms.Cursors.Default
		Me.TxtMonRetBie.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtMonRetBie.UseMnemonic = True
		Me.TxtMonRetBie.Visible = True
		Me.TxtMonRetBie.AutoSize = False
		Me.TxtMonRetBie.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtMonRetBie.Name = "TxtMonRetBie"
		Me.Label17.Text = "Monto Retención Servicios"
		Me.Label17.Size = New System.Drawing.Size(128, 13)
		Me.Label17.Location = New System.Drawing.Point(288, 64)
		Me.Label17.TabIndex = 74
		Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label17.BackColor = System.Drawing.Color.Transparent
		Me.Label17.Enabled = True
		Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label17.UseMnemonic = True
		Me.Label17.Visible = True
		Me.Label17.AutoSize = True
		Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label17.Name = "Label17"
		Me.Label18.Text = "PorcentajeRetención  IVA Servicios"
		Me.Label18.Size = New System.Drawing.Size(169, 13)
		Me.Label18.Location = New System.Drawing.Point(16, 64)
		Me.Label18.TabIndex = 72
		Me.ToolTip1.SetToolTip(Me.Label18, "Porcentaje Iva por prestación de servicios")
		Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label18.BackColor = System.Drawing.Color.Transparent
		Me.Label18.Enabled = True
		Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label18.UseMnemonic = True
		Me.Label18.Visible = True
		Me.Label18.AutoSize = True
		Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label18.Name = "Label18"
		Me.Label20.Text = "Monto Retención Bienes"
		Me.Label20.Size = New System.Drawing.Size(117, 13)
		Me.Label20.Location = New System.Drawing.Point(288, 32)
		Me.Label20.TabIndex = 70
		Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label20.BackColor = System.Drawing.Color.Transparent
		Me.Label20.Enabled = True
		Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label20.UseMnemonic = True
		Me.Label20.Visible = True
		Me.Label20.AutoSize = True
		Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label20.Name = "Label20"
		Me.Label21.Text = "Porcentaje Retención IVA Bienes"
		Me.Label21.Size = New System.Drawing.Size(158, 13)
		Me.Label21.Location = New System.Drawing.Point(16, 32)
		Me.Label21.TabIndex = 68
		Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label21.BackColor = System.Drawing.Color.Transparent
		Me.Label21.Enabled = True
		Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label21.UseMnemonic = True
		Me.Label21.Visible = True
		Me.Label21.AutoSize = True
		Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label21.Name = "Label21"
		Me.Frame3.Text = "RETENCION  DE IMPUESTO A LA RENTA"
		Me.Frame3.Size = New System.Drawing.Size(729, 97)
		Me.Frame3.Location = New System.Drawing.Point(8, 168)
		Me.Frame3.TabIndex = 109
		Me.Frame3.BackColor = System.Drawing.SystemColors.Control
		Me.Frame3.Enabled = True
		Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame3.Visible = True
		Me.Frame3.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame3.Name = "Frame3"
		Me._TxtBasImpIR_1.AutoSize = False
		Me._TxtBasImpIR_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._TxtBasImpIR_1.Size = New System.Drawing.Size(105, 19)
		Me._TxtBasImpIR_1.Location = New System.Drawing.Point(376, 56)
		Me._TxtBasImpIR_1.Maxlength = 12
		Me._TxtBasImpIR_1.TabIndex = 84
		Me.ToolTip1.SetToolTip(Me._TxtBasImpIR_1, "Base imponible tarifa cero")
		Me._TxtBasImpIR_1.AcceptsReturn = True
		Me._TxtBasImpIR_1.BackColor = System.Drawing.SystemColors.Window
		Me._TxtBasImpIR_1.CausesValidation = True
		Me._TxtBasImpIR_1.Enabled = True
		Me._TxtBasImpIR_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._TxtBasImpIR_1.HideSelection = True
		Me._TxtBasImpIR_1.ReadOnly = False
		Me._TxtBasImpIR_1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._TxtBasImpIR_1.MultiLine = False
		Me._TxtBasImpIR_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._TxtBasImpIR_1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._TxtBasImpIR_1.TabStop = True
		Me._TxtBasImpIR_1.Visible = True
		Me._TxtBasImpIR_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._TxtBasImpIR_1.Name = "_TxtBasImpIR_1"
		Me._TxtPorcRetIR_1.AutoSize = False
		Me._TxtPorcRetIR_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._TxtPorcRetIR_1.Size = New System.Drawing.Size(89, 19)
		Me._TxtPorcRetIR_1.Location = New System.Drawing.Point(488, 56)
		Me._TxtPorcRetIR_1.Maxlength = 7
		Me._TxtPorcRetIR_1.TabIndex = 85
		Me.ToolTip1.SetToolTip(Me._TxtPorcRetIR_1, "Número secuencial del comprobante")
		Me._TxtPorcRetIR_1.AcceptsReturn = True
		Me._TxtPorcRetIR_1.BackColor = System.Drawing.SystemColors.Window
		Me._TxtPorcRetIR_1.CausesValidation = True
		Me._TxtPorcRetIR_1.Enabled = True
		Me._TxtPorcRetIR_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._TxtPorcRetIR_1.HideSelection = True
		Me._TxtPorcRetIR_1.ReadOnly = False
		Me._TxtPorcRetIR_1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._TxtPorcRetIR_1.MultiLine = False
		Me._TxtPorcRetIR_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._TxtPorcRetIR_1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._TxtPorcRetIR_1.TabStop = True
		Me._TxtPorcRetIR_1.Visible = True
		Me._TxtPorcRetIR_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._TxtPorcRetIR_1.Name = "_TxtPorcRetIR_1"
		Me._TxtPorcRetIR_0.AutoSize = False
		Me._TxtPorcRetIR_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._TxtPorcRetIR_0.Size = New System.Drawing.Size(89, 19)
		Me._TxtPorcRetIR_0.Location = New System.Drawing.Point(488, 32)
		Me._TxtPorcRetIR_0.Maxlength = 7
		Me._TxtPorcRetIR_0.TabIndex = 81
		Me.ToolTip1.SetToolTip(Me._TxtPorcRetIR_0, "Número secuencial del comprobante")
		Me._TxtPorcRetIR_0.AcceptsReturn = True
		Me._TxtPorcRetIR_0.BackColor = System.Drawing.SystemColors.Window
		Me._TxtPorcRetIR_0.CausesValidation = True
		Me._TxtPorcRetIR_0.Enabled = True
		Me._TxtPorcRetIR_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._TxtPorcRetIR_0.HideSelection = True
		Me._TxtPorcRetIR_0.ReadOnly = False
		Me._TxtPorcRetIR_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._TxtPorcRetIR_0.MultiLine = False
		Me._TxtPorcRetIR_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._TxtPorcRetIR_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._TxtPorcRetIR_0.TabStop = True
		Me._TxtPorcRetIR_0.Visible = True
		Me._TxtPorcRetIR_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._TxtPorcRetIR_0.Name = "_TxtPorcRetIR_0"
		Me._TxtBasImpIR_0.AutoSize = False
		Me._TxtBasImpIR_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._TxtBasImpIR_0.Size = New System.Drawing.Size(105, 19)
		Me._TxtBasImpIR_0.Location = New System.Drawing.Point(376, 32)
		Me._TxtBasImpIR_0.Maxlength = 12
		Me._TxtBasImpIR_0.TabIndex = 79
		Me.ToolTip1.SetToolTip(Me._TxtBasImpIR_0, "Base imponible tarifa cero")
		Me._TxtBasImpIR_0.AcceptsReturn = True
		Me._TxtBasImpIR_0.BackColor = System.Drawing.SystemColors.Window
		Me._TxtBasImpIR_0.CausesValidation = True
		Me._TxtBasImpIR_0.Enabled = True
		Me._TxtBasImpIR_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._TxtBasImpIR_0.HideSelection = True
		Me._TxtBasImpIR_0.ReadOnly = False
		Me._TxtBasImpIR_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._TxtBasImpIR_0.MultiLine = False
		Me._TxtBasImpIR_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._TxtBasImpIR_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._TxtBasImpIR_0.TabStop = True
		Me._TxtBasImpIR_0.Visible = True
		Me._TxtBasImpIR_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._TxtBasImpIR_0.Name = "_TxtBasImpIR_0"
		_CodRetFteImpRent_0.OcxState = CType(resources.GetObject("_CodRetFteImpRent_0.OcxState"), System.Windows.Forms.AxHost.State)
		Me._CodRetFteImpRent_0.Size = New System.Drawing.Size(337, 21)
		Me._CodRetFteImpRent_0.Location = New System.Drawing.Point(8, 32)
		Me._CodRetFteImpRent_0.TabIndex = 77
		Me._CodRetFteImpRent_0.Name = "_CodRetFteImpRent_0"
		_CodRetFteImpRent_1.OcxState = CType(resources.GetObject("_CodRetFteImpRent_1.OcxState"), System.Windows.Forms.AxHost.State)
		Me._CodRetFteImpRent_1.Size = New System.Drawing.Size(337, 21)
		Me._CodRetFteImpRent_1.Location = New System.Drawing.Point(8, 56)
		Me._CodRetFteImpRent_1.TabIndex = 83
		Me._CodRetFteImpRent_1.Name = "_CodRetFteImpRent_1"
		Me._TxtMonRetRen_1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._TxtMonRetRen_1.BackColor = System.Drawing.Color.White
		Me._TxtMonRetRen_1.Size = New System.Drawing.Size(102, 19)
		Me._TxtMonRetRen_1.Location = New System.Drawing.Point(584, 56)
		Me._TxtMonRetRen_1.TabIndex = 86
		Me._TxtMonRetRen_1.Enabled = True
		Me._TxtMonRetRen_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._TxtMonRetRen_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._TxtMonRetRen_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._TxtMonRetRen_1.UseMnemonic = True
		Me._TxtMonRetRen_1.Visible = True
		Me._TxtMonRetRen_1.AutoSize = False
		Me._TxtMonRetRen_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._TxtMonRetRen_1.Name = "_TxtMonRetRen_1"
		Me._TxtMonRetRen_0.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._TxtMonRetRen_0.BackColor = System.Drawing.Color.White
		Me._TxtMonRetRen_0.Size = New System.Drawing.Size(102, 19)
		Me._TxtMonRetRen_0.Location = New System.Drawing.Point(584, 32)
		Me._TxtMonRetRen_0.TabIndex = 93
		Me._TxtMonRetRen_0.Enabled = True
		Me._TxtMonRetRen_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._TxtMonRetRen_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._TxtMonRetRen_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._TxtMonRetRen_0.UseMnemonic = True
		Me._TxtMonRetRen_0.Visible = True
		Me._TxtMonRetRen_0.AutoSize = False
		Me._TxtMonRetRen_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._TxtMonRetRen_0.Name = "_TxtMonRetRen_0"
		Me.Label36.Text = "Concepto "
		Me.Label36.Size = New System.Drawing.Size(49, 13)
		Me.Label36.Location = New System.Drawing.Point(128, 16)
		Me.Label36.TabIndex = 76
		Me.Label36.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label36.BackColor = System.Drawing.Color.Transparent
		Me.Label36.Enabled = True
		Me.Label36.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label36.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label36.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label36.UseMnemonic = True
		Me.Label36.Visible = True
		Me.Label36.AutoSize = True
		Me.Label36.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label36.Name = "Label36"
		Me.Label35.Text = "Monto"
		Me.Label35.Size = New System.Drawing.Size(30, 13)
		Me.Label35.Location = New System.Drawing.Point(624, 16)
		Me.Label35.TabIndex = 82
		Me.Label35.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label35.BackColor = System.Drawing.Color.Transparent
		Me.Label35.Enabled = True
		Me.Label35.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label35.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label35.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label35.UseMnemonic = True
		Me.Label35.Visible = True
		Me.Label35.AutoSize = True
		Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label35.Name = "Label35"
		Me.Label34.Text = "Porcentaje "
		Me.Label34.Size = New System.Drawing.Size(54, 13)
		Me.Label34.Location = New System.Drawing.Point(512, 16)
		Me.Label34.TabIndex = 80
		Me.Label34.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label34.BackColor = System.Drawing.Color.Transparent
		Me.Label34.Enabled = True
		Me.Label34.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label34.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label34.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label34.UseMnemonic = True
		Me.Label34.Visible = True
		Me.Label34.AutoSize = True
		Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label34.Name = "Label34"
		Me.Label33.Text = "Base Imponible "
		Me.Label33.Size = New System.Drawing.Size(75, 13)
		Me.Label33.Location = New System.Drawing.Point(392, 16)
		Me.Label33.TabIndex = 78
		Me.Label33.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label33.BackColor = System.Drawing.Color.Transparent
		Me.Label33.Enabled = True
		Me.Label33.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label33.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label33.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label33.UseMnemonic = True
		Me.Label33.Visible = True
		Me.Label33.AutoSize = True
		Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label33.Name = "Label33"
		Me.Frame1.Text = "PARTIDOS POLITICOS"
		Me.Frame1.Size = New System.Drawing.Size(729, 57)
		Me.Frame1.Location = New System.Drawing.Point(8, 272)
		Me.Frame1.TabIndex = 116
		Me.Frame1.BackColor = System.Drawing.SystemColors.Control
		Me.Frame1.Enabled = True
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Visible = True
		Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame1.Name = "Frame1"
		Me.TxtMontoGratuito.AutoSize = False
		Me.TxtMontoGratuito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.TxtMontoGratuito.Size = New System.Drawing.Size(89, 19)
		Me.TxtMontoGratuito.Location = New System.Drawing.Point(624, 24)
		Me.TxtMontoGratuito.Maxlength = 10
		Me.TxtMontoGratuito.TabIndex = 92
		Me.ToolTip1.SetToolTip(Me.TxtMontoGratuito, "Número de autorización del comprobante")
		Me.TxtMontoGratuito.AcceptsReturn = True
		Me.TxtMontoGratuito.BackColor = System.Drawing.SystemColors.Window
		Me.TxtMontoGratuito.CausesValidation = True
		Me.TxtMontoGratuito.Enabled = True
		Me.TxtMontoGratuito.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtMontoGratuito.HideSelection = True
		Me.TxtMontoGratuito.ReadOnly = False
		Me.TxtMontoGratuito.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtMontoGratuito.MultiLine = False
		Me.TxtMontoGratuito.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtMontoGratuito.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtMontoGratuito.TabStop = True
		Me.TxtMontoGratuito.Visible = True
		Me.TxtMontoGratuito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtMontoGratuito.Name = "TxtMontoGratuito"
		Me.TxtMontoOneroso.AutoSize = False
		Me.TxtMontoOneroso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.TxtMontoOneroso.Size = New System.Drawing.Size(89, 19)
		Me.TxtMontoOneroso.Location = New System.Drawing.Point(368, 24)
		Me.TxtMontoOneroso.Maxlength = 10
		Me.TxtMontoOneroso.TabIndex = 90
		Me.ToolTip1.SetToolTip(Me.TxtMontoOneroso, "Número de autorización del comprobante")
		Me.TxtMontoOneroso.AcceptsReturn = True
		Me.TxtMontoOneroso.BackColor = System.Drawing.SystemColors.Window
		Me.TxtMontoOneroso.CausesValidation = True
		Me.TxtMontoOneroso.Enabled = True
		Me.TxtMontoOneroso.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtMontoOneroso.HideSelection = True
		Me.TxtMontoOneroso.ReadOnly = False
		Me.TxtMontoOneroso.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtMontoOneroso.MultiLine = False
		Me.TxtMontoOneroso.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtMontoOneroso.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtMontoOneroso.TabStop = True
		Me.TxtMontoOneroso.Visible = True
		Me.TxtMontoOneroso.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtMontoOneroso.Name = "TxtMontoOneroso"
		Me.TxtNroContrato.AutoSize = False
		Me.TxtNroContrato.Size = New System.Drawing.Size(89, 19)
		Me.TxtNroContrato.Location = New System.Drawing.Point(136, 24)
		Me.TxtNroContrato.Maxlength = 10
		Me.TxtNroContrato.TabIndex = 88
		Me.ToolTip1.SetToolTip(Me.TxtNroContrato, "Número de autorización del comprobante")
		Me.TxtNroContrato.AcceptsReturn = True
		Me.TxtNroContrato.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TxtNroContrato.BackColor = System.Drawing.SystemColors.Window
		Me.TxtNroContrato.CausesValidation = True
		Me.TxtNroContrato.Enabled = True
		Me.TxtNroContrato.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtNroContrato.HideSelection = True
		Me.TxtNroContrato.ReadOnly = False
		Me.TxtNroContrato.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtNroContrato.MultiLine = False
		Me.TxtNroContrato.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtNroContrato.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtNroContrato.TabStop = True
		Me.TxtNroContrato.Visible = True
		Me.TxtNroContrato.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtNroContrato.Name = "TxtNroContrato"
		Me.Label47.Text = "Monto Título Gratuito"
		Me.Label47.Size = New System.Drawing.Size(101, 13)
		Me.Label47.Location = New System.Drawing.Point(504, 32)
		Me.Label47.TabIndex = 91
		Me.Label47.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label47.BackColor = System.Drawing.Color.Transparent
		Me.Label47.Enabled = True
		Me.Label47.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label47.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label47.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label47.UseMnemonic = True
		Me.Label47.Visible = True
		Me.Label47.AutoSize = True
		Me.Label47.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label47.Name = "Label47"
		Me.Label46.Text = "Monto Titulo Oneroso"
		Me.Label46.Size = New System.Drawing.Size(102, 13)
		Me.Label46.Location = New System.Drawing.Point(248, 32)
		Me.Label46.TabIndex = 89
		Me.Label46.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label46.BackColor = System.Drawing.Color.Transparent
		Me.Label46.Enabled = True
		Me.Label46.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label46.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label46.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label46.UseMnemonic = True
		Me.Label46.Visible = True
		Me.Label46.AutoSize = True
		Me.Label46.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label46.Name = "Label46"
		Me.Label45.Text = "Nro.Contrato de sustento"
		Me.Label45.Size = New System.Drawing.Size(118, 13)
		Me.Label45.Location = New System.Drawing.Point(8, 32)
		Me.Label45.TabIndex = 87
		Me.Label45.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label45.BackColor = System.Drawing.Color.Transparent
		Me.Label45.Enabled = True
		Me.Label45.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label45.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label45.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label45.UseMnemonic = True
		Me.Label45.Visible = True
		Me.Label45.AutoSize = True
		Me.Label45.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label45.Name = "Label45"
		Me.Label31.Text = "No.CpbteRetencion"
		Me.Label31.Size = New System.Drawing.Size(94, 13)
		Me.Label31.Location = New System.Drawing.Point(8, 24)
		Me.Label31.TabIndex = 57
		Me.Label31.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label31.BackColor = System.Drawing.Color.Transparent
		Me.Label31.Enabled = True
		Me.Label31.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label31.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label31.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label31.UseMnemonic = True
		Me.Label31.Visible = True
		Me.Label31.AutoSize = True
		Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label31.Name = "Label31"
		Me.Label30.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label30.BackColor = System.Drawing.Color.Transparent
		Me.Label30.Text = "Estblcmto"
		Me.Label30.ForeColor = System.Drawing.Color.FromARGB(128, 128, 128)
		Me.Label30.Size = New System.Drawing.Size(42, 13)
		Me.Label30.Location = New System.Drawing.Point(104, 32)
		Me.Label30.TabIndex = 58
		Me.Label30.Enabled = True
		Me.Label30.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label30.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label30.UseMnemonic = True
		Me.Label30.Visible = True
		Me.Label30.AutoSize = True
		Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label30.Name = "Label30"
		Me.Label29.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label29.BackColor = System.Drawing.Color.Transparent
		Me.Label29.Text = "PtoEmision"
		Me.Label29.ForeColor = System.Drawing.Color.FromARGB(128, 128, 128)
		Me.Label29.Size = New System.Drawing.Size(47, 13)
		Me.Label29.Location = New System.Drawing.Point(152, 32)
		Me.Label29.TabIndex = 60
		Me.Label29.Enabled = True
		Me.Label29.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label29.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label29.UseMnemonic = True
		Me.Label29.Visible = True
		Me.Label29.AutoSize = True
		Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label29.Name = "Label29"
		Me.Label28.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label28.BackColor = System.Drawing.Color.Transparent
		Me.Label28.Text = "Nro Secuencial"
		Me.Label28.ForeColor = System.Drawing.Color.FromARGB(128, 128, 128)
		Me.Label28.Size = New System.Drawing.Size(64, 13)
		Me.Label28.Location = New System.Drawing.Point(205, 32)
		Me.Label28.TabIndex = 62
		Me.Label28.Enabled = True
		Me.Label28.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label28.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label28.UseMnemonic = True
		Me.Label28.Visible = True
		Me.Label28.AutoSize = True
		Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label28.Name = "Label28"
		Me.Label23.Text = "F&echaEmisiónRetención"
		Me.Label23.Size = New System.Drawing.Size(115, 13)
		Me.Label23.Location = New System.Drawing.Point(304, 24)
		Me.Label23.TabIndex = 64
		Me.Label23.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label23.BackColor = System.Drawing.Color.Transparent
		Me.Label23.Enabled = True
		Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label23.UseMnemonic = True
		Me.Label23.Visible = True
		Me.Label23.AutoSize = True
		Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label23.Name = "Label23"
		Me.Label11.Text = "dd/mm/aaaa"
		Me.Label11.Enabled = False
		Me.Label11.ForeColor = System.Drawing.Color.FromARGB(128, 128, 128)
		Me.Label11.Size = New System.Drawing.Size(52, 13)
		Me.Label11.Location = New System.Drawing.Point(432, 32)
		Me.Label11.TabIndex = 65
		Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label11.BackColor = System.Drawing.Color.Transparent
		Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label11.UseMnemonic = True
		Me.Label11.Visible = True
		Me.Label11.AutoSize = True
		Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label11.Name = "Label11"
		Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.F2.Size = New System.Drawing.Size(177, 50)
		Me.F2.Location = New System.Drawing.Point(8, 392)
		Me.F2.TabIndex = 103
		Me.F2.BackColor = System.Drawing.SystemColors.Control
		Me.F2.Enabled = True
		Me.F2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.F2.Cursor = System.Windows.Forms.Cursors.Default
		Me.F2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.F2.Visible = True
		Me.F2.Name = "F2"
		Me.Command2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command2.Text = "&Salir"
		Me.Command2.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Command2.Size = New System.Drawing.Size(54, 34)
		Me.Command2.Location = New System.Drawing.Point(120, 13)
		Me.Command2.TabIndex = 96
		Me.ToolTip1.SetToolTip(Me.Command2, "Regresa al menu principal")
		Me.Command2.BackColor = System.Drawing.SystemColors.Control
		Me.Command2.CausesValidation = True
		Me.Command2.Enabled = True
		Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command2.TabStop = True
		Me.Command2.Name = "Command2"
		Me.btncancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CancelButton = Me.btncancelar
		Me.btncancelar.Text = "&Cancelar"
		Me.btncancelar.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btncancelar.Size = New System.Drawing.Size(54, 34)
		Me.btncancelar.Location = New System.Drawing.Point(64, 13)
		Me.btncancelar.TabIndex = 95
		Me.ToolTip1.SetToolTip(Me.btncancelar, "Cancela acción")
		Me.btncancelar.BackColor = System.Drawing.SystemColors.Control
		Me.btncancelar.CausesValidation = True
		Me.btncancelar.Enabled = True
		Me.btncancelar.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btncancelar.Cursor = System.Windows.Forms.Cursors.Default
		Me.btncancelar.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btncancelar.TabStop = True
		Me.btncancelar.Name = "btncancelar"
		Me.btngrabar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btngrabar.Text = "&Grabar"
		Me.btngrabar.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btngrabar.Size = New System.Drawing.Size(54, 34)
		Me.btngrabar.Location = New System.Drawing.Point(8, 13)
		Me.btngrabar.TabIndex = 94
		Me.ToolTip1.SetToolTip(Me.btngrabar, "Graba el registro")
		Me.btngrabar.BackColor = System.Drawing.SystemColors.Control
		Me.btngrabar.CausesValidation = True
		Me.btngrabar.Enabled = True
		Me.btngrabar.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btngrabar.Cursor = System.Windows.Forms.Cursors.Default
		Me.btngrabar.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btngrabar.TabStop = True
		Me.btngrabar.Name = "btngrabar"
		Me.f3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.f3.Size = New System.Drawing.Size(297, 50)
		Me.f3.Location = New System.Drawing.Point(8, 392)
		Me.f3.TabIndex = 102
		Me.f3.BackColor = System.Drawing.SystemColors.Control
		Me.f3.Enabled = True
		Me.f3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.f3.Cursor = System.Windows.Forms.Cursors.Default
		Me.f3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.f3.Visible = True
		Me.f3.Name = "f3"
		Me.btneliminar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btneliminar.Text = "&Eliminar"
		Me.btneliminar.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btneliminar.Size = New System.Drawing.Size(54, 34)
		Me.btneliminar.Location = New System.Drawing.Point(176, 13)
		Me.btneliminar.TabIndex = 100
		Me.ToolTip1.SetToolTip(Me.btneliminar, "Elimina un registro")
		Me.btneliminar.BackColor = System.Drawing.SystemColors.Control
		Me.btneliminar.CausesValidation = True
		Me.btneliminar.Enabled = True
		Me.btneliminar.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btneliminar.Cursor = System.Windows.Forms.Cursors.Default
		Me.btneliminar.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btneliminar.TabStop = True
		Me.btneliminar.Name = "btneliminar"
		Me.btnbuscar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnbuscar.Text = "&Buscar"
		Me.btnbuscar.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnbuscar.Size = New System.Drawing.Size(54, 34)
		Me.btnbuscar.Location = New System.Drawing.Point(120, 13)
		Me.btnbuscar.TabIndex = 99
		Me.ToolTip1.SetToolTip(Me.btnbuscar, "Busca un registro")
		Me.btnbuscar.BackColor = System.Drawing.SystemColors.Control
		Me.btnbuscar.CausesValidation = True
		Me.btnbuscar.Enabled = True
		Me.btnbuscar.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnbuscar.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnbuscar.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnbuscar.TabStop = True
		Me.btnbuscar.Name = "btnbuscar"
		Me.btnnuevo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnnuevo.Text = "&Nuevo"
		Me.btnnuevo.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnnuevo.Size = New System.Drawing.Size(54, 34)
		Me.btnnuevo.Location = New System.Drawing.Point(64, 13)
		Me.btnnuevo.TabIndex = 98
		Me.ToolTip1.SetToolTip(Me.btnnuevo, "Nuevo registro")
		Me.btnnuevo.BackColor = System.Drawing.SystemColors.Control
		Me.btnnuevo.CausesValidation = True
		Me.btnnuevo.Enabled = True
		Me.btnnuevo.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnnuevo.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnnuevo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnnuevo.TabStop = True
		Me.btnnuevo.Name = "btnnuevo"
		Me.btnmodificar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnmodificar.Text = "&Modificar"
		Me.btnmodificar.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnmodificar.Size = New System.Drawing.Size(54, 34)
		Me.btnmodificar.Location = New System.Drawing.Point(8, 13)
		Me.btnmodificar.TabIndex = 97
		Me.ToolTip1.SetToolTip(Me.btnmodificar, "Modifica el registro actual")
		Me.btnmodificar.BackColor = System.Drawing.SystemColors.Control
		Me.btnmodificar.CausesValidation = True
		Me.btnmodificar.Enabled = True
		Me.btnmodificar.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnmodificar.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnmodificar.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnmodificar.TabStop = True
		Me.btnmodificar.Name = "btnmodificar"
		Me.btnsalir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnsalir.Text = "&Salir"
		Me.btnsalir.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnsalir.Size = New System.Drawing.Size(54, 34)
		Me.btnsalir.Location = New System.Drawing.Point(232, 13)
		Me.btnsalir.TabIndex = 101
		Me.ToolTip1.SetToolTip(Me.btnsalir, "Regresa al menu principal")
		Me.btnsalir.BackColor = System.Drawing.SystemColors.Control
		Me.btnsalir.CausesValidation = True
		Me.btnsalir.Enabled = True
		Me.btnsalir.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnsalir.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnsalir.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnsalir.TabStop = True
		Me.btnsalir.Name = "btnsalir"
		Me.Label32.Text = "No.AutorizaciónRetención"
		Me.Label32.Size = New System.Drawing.Size(124, 13)
		Me.Label32.Location = New System.Drawing.Point(352, 432)
		Me.Label32.TabIndex = 118
		Me.Label32.Visible = False
		Me.Label32.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label32.BackColor = System.Drawing.Color.Transparent
		Me.Label32.Enabled = True
		Me.Label32.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label32.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label32.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label32.UseMnemonic = True
		Me.Label32.AutoSize = True
		Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label32.Name = "Label32"
		Me.Label13.Text = "Nro.AutorizaciónComprobante"
		Me.Label13.Size = New System.Drawing.Size(141, 21)
		Me.Label13.Location = New System.Drawing.Point(528, 40)
		Me.Label13.TabIndex = 115
		Me.Label13.Visible = False
		Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label13.BackColor = System.Drawing.Color.Transparent
		Me.Label13.Enabled = True
		Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label13.UseMnemonic = True
		Me.Label13.AutoSize = True
		Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label13.Name = "Label13"
		Me.Label26.Text = "F&echa Caduca Cpbte."
		Me.Label26.Size = New System.Drawing.Size(104, 13)
		Me.Label26.Location = New System.Drawing.Point(560, 416)
		Me.Label26.TabIndex = 114
		Me.Label26.Visible = False
		Me.Label26.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label26.BackColor = System.Drawing.Color.Transparent
		Me.Label26.Enabled = True
		Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label26.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label26.UseMnemonic = True
		Me.Label26.AutoSize = True
		Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label26.Name = "Label26"
		Me.Controls.Add(Command1)
		Me.Controls.Add(TxtNroAutorizaIR)
		Me.Controls.Add(BtCaduca)
		Me.Controls.Add(txtAutCom)
		Me.Controls.Add(FechaCaduca)
		Me.Controls.Add(SSTab1)
		Me.Controls.Add(F2)
		Me.Controls.Add(f3)
		Me.Controls.Add(Label32)
		Me.Controls.Add(Label13)
		Me.Controls.Add(Label26)
		Me.SSTab1.Controls.Add(_SSTab1_TabPage0)
		Me.SSTab1.Controls.Add(_SSTab1_TabPage1)
		Me._SSTab1_TabPage0.Controls.Add(fprincipal)
		Me.fprincipal.Controls.Add(btpro)
		Me.fprincipal.Controls.Add(txtPro)
		Me.fprincipal.Controls.Add(TxtSerEstablec)
		Me.fprincipal.Controls.Add(txtNumSer)
		Me.fprincipal.Controls.Add(txtNumSec)
		Me.fprincipal.Controls.Add(BtContable)
		Me.fprincipal.Controls.Add(BtEmision)
		Me.fprincipal.Controls.Add(DerochoIva)
		Me.fprincipal.Controls.Add(FrModifica)
		Me.fprincipal.Controls.Add(txtFecEmiCom)
		Me.fprincipal.Controls.Add(txtFecRegCont)
		Me.fprincipal.Controls.Add(txtBasImpTar0)
		Me.fprincipal.Controls.Add(txtMonIvaBie)
		Me.fprincipal.Controls.Add(TxtBasImpICE)
		Me.fprincipal.Controls.Add(txtBasImpGra)
		Me.fprincipal.Controls.Add(DcPorICE)
		Me.fprincipal.Controls.Add(dtCodSus)
		Me.fprincipal.Controls.Add(DtPorIvaServ)
		Me.fprincipal.Controls.Add(dtCom)
		Me.fprincipal.Controls.Add(dtPorIva)
		Me.fprincipal.Controls.Add(DtPorICE)
		Me.fprincipal.Controls.Add(dtPorIvaBie)
		Me.fprincipal.Controls.Add(dcPorIva)
		Me.fprincipal.Controls.Add(TipoComprobante)
		Me.fprincipal.Controls.Add(DtComMod)
		Me.fprincipal.Controls.Add(DtPorRetIR)
		Me.fprincipal.Controls.Add(DatSustento)
		Me.fprincipal.Controls.Add(Label1)
		Me.fprincipal.Controls.Add(lbNomP)
		Me.fprincipal.Controls.Add(lbClioPro)
		Me.fprincipal.Controls.Add(Label15)
		Me.fprincipal.Controls.Add(Label24)
		Me.fprincipal.Controls.Add(Label4)
		Me.fprincipal.Controls.Add(lbfactor)
		Me.fprincipal.Controls.Add(TxtPorcIce)
		Me.fprincipal.Controls.Add(Label48)
		Me.fprincipal.Controls.Add(TxtMonIvaSer)
		Me.fprincipal.Controls.Add(TxtMonIva)
		Me.fprincipal.Controls.Add(TxtMonIce)
		Me.fprincipal.Controls.Add(Label3)
		Me.fprincipal.Controls.Add(Label5)
		Me.fprincipal.Controls.Add(Label49)
		Me.fprincipal.Controls.Add(Label14)
		Me.fprincipal.Controls.Add(Label10)
		Me.fprincipal.Controls.Add(Label7)
		Me.fprincipal.Controls.Add(Label12)
		Me.fprincipal.Controls.Add(Label25)
		Me.fprincipal.Controls.Add(Label16)
		Me.fprincipal.Controls.Add(Label19)
		Me.fprincipal.Controls.Add(Label9)
		Me.fprincipal.Controls.Add(Label22)
		Me.fprincipal.Controls.Add(Label8)
		Me.fprincipal.Controls.Add(Label2)
		Me.fprincipal.Controls.Add(Label6)
		Me.FrModifica.Controls.Add(TxtAutorizaMod)
		Me.FrModifica.Controls.Add(BtRemision)
		Me.FrModifica.Controls.Add(TxtNumeroSecuencialMod)
		Me.FrModifica.Controls.Add(TxtserieEstableceMod)
		Me.FrModifica.Controls.Add(TxtSerieEmicionMod)
		Me.FrModifica.Controls.Add(TxtFechaModifica)
		Me.FrModifica.Controls.Add(DcCodModificado)
		Me.FrModifica.Controls.Add(Label43)
		Me.FrModifica.Controls.Add(Label44)
		Me.FrModifica.Controls.Add(Label42)
		Me.FrModifica.Controls.Add(Label41)
		Me.FrModifica.Controls.Add(Label40)
		Me.FrModifica.Controls.Add(Label39)
		Me.FrModifica.Controls.Add(Label38)
		Me.FrModifica.Controls.Add(Label37)
		Me._SSTab1_TabPage1.Controls.Add(Frame2)
		Me.Frame2.Controls.Add(BtnFechEmitRete)
		Me.Frame2.Controls.Add(TxtSecuencialIR)
		Me.Frame2.Controls.Add(TxtSerieEstblIR)
		Me.Frame2.Controls.Add(TxtSerieEmision)
		Me.Frame2.Controls.Add(TxtFechaEmicionIR)
		Me.Frame2.Controls.Add(Frame4)
		Me.Frame2.Controls.Add(Frame3)
		Me.Frame2.Controls.Add(Frame1)
		Me.Frame2.Controls.Add(Label31)
		Me.Frame2.Controls.Add(Label30)
		Me.Frame2.Controls.Add(Label29)
		Me.Frame2.Controls.Add(Label28)
		Me.Frame2.Controls.Add(Label23)
		Me.Frame2.Controls.Add(Label11)
		Me.Frame4.Controls.Add(DcPorIvaServ)
		Me.Frame4.Controls.Add(dcPorIvaBie)
		Me.Frame4.Controls.Add(TxtMonRetSer)
		Me.Frame4.Controls.Add(TxtMonRetBie)
		Me.Frame4.Controls.Add(Label17)
		Me.Frame4.Controls.Add(Label18)
		Me.Frame4.Controls.Add(Label20)
		Me.Frame4.Controls.Add(Label21)
		Me.Frame3.Controls.Add(_TxtBasImpIR_1)
		Me.Frame3.Controls.Add(_TxtPorcRetIR_1)
		Me.Frame3.Controls.Add(_TxtPorcRetIR_0)
		Me.Frame3.Controls.Add(_TxtBasImpIR_0)
		Me.Frame3.Controls.Add(_CodRetFteImpRent_0)
		Me.Frame3.Controls.Add(_CodRetFteImpRent_1)
		Me.Frame3.Controls.Add(_TxtMonRetRen_1)
		Me.Frame3.Controls.Add(_TxtMonRetRen_0)
		Me.Frame3.Controls.Add(Label36)
		Me.Frame3.Controls.Add(Label35)
		Me.Frame3.Controls.Add(Label34)
		Me.Frame3.Controls.Add(Label33)
		Me.Frame1.Controls.Add(TxtMontoGratuito)
		Me.Frame1.Controls.Add(TxtMontoOneroso)
		Me.Frame1.Controls.Add(TxtNroContrato)
		Me.Frame1.Controls.Add(Label47)
		Me.Frame1.Controls.Add(Label46)
		Me.Frame1.Controls.Add(Label45)
		Me.F2.Controls.Add(Command2)
		Me.F2.Controls.Add(btncancelar)
		Me.F2.Controls.Add(btngrabar)
		Me.f3.Controls.Add(btneliminar)
		Me.f3.Controls.Add(btnbuscar)
		Me.f3.Controls.Add(btnnuevo)
		Me.f3.Controls.Add(btnmodificar)
		Me.f3.Controls.Add(btnsalir)
		Me.CodRetFteImpRent.SetIndex(_CodRetFteImpRent_0, CType(0, Short))
		Me.CodRetFteImpRent.SetIndex(_CodRetFteImpRent_1, CType(1, Short))
		Me.TxtBasImpIR.SetIndex(_TxtBasImpIR_1, CType(1, Short))
		Me.TxtBasImpIR.SetIndex(_TxtBasImpIR_0, CType(0, Short))
		Me.TxtMonRetRen.SetIndex(_TxtMonRetRen_1, CType(1, Short))
		Me.TxtMonRetRen.SetIndex(_TxtMonRetRen_0, CType(0, Short))
		Me.TxtPorcRetIR.SetIndex(_TxtPorcRetIR_1, CType(1, Short))
		Me.TxtPorcRetIR.SetIndex(_TxtPorcRetIR_0, CType(0, Short))
		CType(Me.TxtPorcRetIR, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.TxtMonRetRen, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.TxtBasImpIR, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.CodRetFteImpRent, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me._CodRetFteImpRent_1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me._CodRetFteImpRent_0, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.dcPorIvaBie, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.DcPorIvaServ, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.DatSustento, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.TipoComprobante, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.dcPorIva, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.DcPorICE, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.DcCodModificado, System.ComponentModel.ISupportInitialize).EndInit()
		Me.SSTab1.ResumeLayout(False)
		Me._SSTab1_TabPage0.ResumeLayout(False)
		Me.fprincipal.ResumeLayout(False)
		Me.FrModifica.ResumeLayout(False)
		Me._SSTab1_TabPage1.ResumeLayout(False)
		Me.Frame2.ResumeLayout(False)
		Me.Frame4.ResumeLayout(False)
		Me.Frame3.ResumeLayout(False)
		Me.Frame1.ResumeLayout(False)
		Me.F2.ResumeLayout(False)
		Me.f3.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
#Region "Upgrade Support"
	Public Sub VB6_AddADODataBinding()
		ADOBind_dtPorIvaBie = New VB6.MBindingCollection()
		ADOBind_DtPorIvaServ = New VB6.MBindingCollection()
		ADOBind_DtPorRetIR = New VB6.MBindingCollection()
		ADOBind_dtCodSus = New VB6.MBindingCollection()
		ADOBind_dtCom = New VB6.MBindingCollection()
		ADOBind_dtPorIva = New VB6.MBindingCollection()
		ADOBind_dtPorIvaBie.DataSource = CType(dtPorIvaBie, msdatasrc.DataSource)
		ADOBind_DtPorIvaServ.DataSource = CType(DtPorIvaServ, msdatasrc.DataSource)
		ADOBind_DtPorRetIR.DataSource = CType(DtPorRetIR, msdatasrc.DataSource)
		ADOBind_dtCodSus.DataSource = CType(dtCodSus, msdatasrc.DataSource)
		ADOBind_dtCom.DataSource = CType(dtCom, msdatasrc.DataSource)
		ADOBind_dtPorIva.DataSource = CType(dtPorIva, msdatasrc.DataSource)
		ADOBind_dtPorIvaBie.UpdateMode = VB6.UpdateMode.vbUpdateWhenPropertyChanges
		ADOBind_dtPorIvaBie.UpdateControls()
		ADOBind_DtPorIvaServ.UpdateMode = VB6.UpdateMode.vbUpdateWhenPropertyChanges
		ADOBind_DtPorIvaServ.UpdateControls()
		ADOBind_DtPorRetIR.UpdateMode = VB6.UpdateMode.vbUpdateWhenPropertyChanges
		ADOBind_DtPorRetIR.UpdateControls()
		ADOBind_dtCodSus.UpdateMode = VB6.UpdateMode.vbUpdateWhenPropertyChanges
		ADOBind_dtCodSus.UpdateControls()
		ADOBind_dtCom.UpdateMode = VB6.UpdateMode.vbUpdateWhenPropertyChanges
		ADOBind_dtCom.UpdateControls()
		ADOBind_dtPorIva.UpdateMode = VB6.UpdateMode.vbUpdateWhenPropertyChanges
		ADOBind_dtPorIva.UpdateControls()
	End Sub
	Public Sub VB6_RemoveADODataBinding()
		ADOBind_dtPorIvaBie.Clear()
		ADOBind_dtPorIvaBie.Dispose()
		ADOBind_dtPorIvaBie = Nothing
		ADOBind_DtPorIvaServ.Clear()
		ADOBind_DtPorIvaServ.Dispose()
		ADOBind_DtPorIvaServ = Nothing
		ADOBind_DtPorRetIR.Clear()
		ADOBind_DtPorRetIR.Dispose()
		ADOBind_DtPorRetIR = Nothing
		ADOBind_dtCodSus.Clear()
		ADOBind_dtCodSus.Dispose()
		ADOBind_dtCodSus = Nothing
		ADOBind_dtCom.Clear()
		ADOBind_dtCom.Dispose()
		ADOBind_dtCom = Nothing
		ADOBind_dtPorIva.Clear()
		ADOBind_dtPorIva.Dispose()
		ADOBind_dtPorIva = Nothing
	End Sub
#End Region 
End Class