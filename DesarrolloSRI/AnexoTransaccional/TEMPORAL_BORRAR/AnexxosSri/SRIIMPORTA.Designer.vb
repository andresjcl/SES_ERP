<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class SRIIMPORTA
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
	Private ADOBind_DtPorRetIR As VB6.MBindingCollection
	Private ADOBind_dtCodSus As VB6.MBindingCollection
	Private ADOBind_dtCom As VB6.MBindingCollection
	Private ADOBind_dtPorIva As VB6.MBindingCollection
	Public WithEvents txtBasImpGra As System.Windows.Forms.TextBox
	Public WithEvents TxtBasImpICE As System.Windows.Forms.TextBox
	Public WithEvents txtMonIvaBie As System.Windows.Forms.TextBox
	Public WithEvents txtBasImpTar0 As System.Windows.Forms.TextBox
	Public WithEvents btpro As System.Windows.Forms.Button
	Public WithEvents txtPro As System.Windows.Forms.TextBox
	Public WithEvents Option1 As System.Windows.Forms.RadioButton
	Public WithEvents Option2 As System.Windows.Forms.RadioButton
	Public WithEvents TxtAnio As System.Windows.Forms.TextBox
	Public WithEvents TxtDistritoAd As System.Windows.Forms.TextBox
	Public WithEvents TxtRegimen As System.Windows.Forms.TextBox
	Public WithEvents TxtCorrelativo As System.Windows.Forms.TextBox
	Public WithEvents TxtVerificador As System.Windows.Forms.TextBox
	Public WithEvents BtEmision As System.Windows.Forms.Button
	Public WithEvents txtFecLiquidacion As System.Windows.Forms.TextBox
	Public WithEvents TxtValCif As System.Windows.Forms.TextBox
	Public WithEvents TxtBasImpIR As System.Windows.Forms.TextBox
	Public WithEvents TxtPorcRetIR As System.Windows.Forms.TextBox
	Public WithEvents CodRetFteImpRent As AxMSDataListLib.AxDataCombo
	Public WithEvents Label33 As System.Windows.Forms.Label
	Public WithEvents Label34 As System.Windows.Forms.Label
	Public WithEvents Label35 As System.Windows.Forms.Label
	Public WithEvents Label36 As System.Windows.Forms.Label
	Public WithEvents TxtMonRetRen As System.Windows.Forms.Label
	Public WithEvents Frame3 As System.Windows.Forms.GroupBox
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents btncancelar As System.Windows.Forms.Button
	Public WithEvents btngrabar As System.Windows.Forms.Button
	Public WithEvents F2 As System.Windows.Forms.Panel
	Public WithEvents DcPorICE As AxMSDataListLib.AxDataCombo
	Public WithEvents dtCodSus As VB6.ADODC
	Public WithEvents DtPorIvaServ As VB6.ADODC
	Public WithEvents dtCom As VB6.ADODC
	Public WithEvents dtPorIva As VB6.ADODC
	Public WithEvents DtPorICE As VB6.ADODC
	Public WithEvents dcPorIva As AxMSDataListLib.AxDataCombo
	Public WithEvents TipoComprobante As AxMSDataListLib.AxDataCombo
	Public WithEvents DatSustento As AxMSDataListLib.AxDataCombo
	Public WithEvents DtPorRetIR As VB6.ADODC
	Public WithEvents btneliminar As System.Windows.Forms.Button
	Public WithEvents btnbuscar As System.Windows.Forms.Button
	Public WithEvents btnnuevo As System.Windows.Forms.Button
	Public WithEvents btnmodificar As System.Windows.Forms.Button
	Public WithEvents btnsalir As System.Windows.Forms.Button
	Public WithEvents f3 As System.Windows.Forms.Panel
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label22 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label19 As System.Windows.Forms.Label
	Public WithEvents Label16 As System.Windows.Forms.Label
	Public WithEvents Label12 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents TxtMonIce As System.Windows.Forms.Label
	Public WithEvents TxtMonIva As System.Windows.Forms.Label
	Public WithEvents TxtMonIvaSer As System.Windows.Forms.Label
	Public WithEvents Label48 As System.Windows.Forms.Label
	Public WithEvents TxtPorcIce As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents lbNomP As System.Windows.Forms.Label
	Public WithEvents lbClioPro As System.Windows.Forms.Label
	Public WithEvents Label40 As System.Windows.Forms.Label
	Public WithEvents Label49 As System.Windows.Forms.Label
	Public WithEvents Label14 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
	'Se puede modificar mediante el Diseñador de Windows Forms.
	'No lo modifique con el editor de código.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SRIIMPORTA))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.txtBasImpGra = New System.Windows.Forms.TextBox
		Me.TxtBasImpICE = New System.Windows.Forms.TextBox
		Me.txtMonIvaBie = New System.Windows.Forms.TextBox
		Me.txtBasImpTar0 = New System.Windows.Forms.TextBox
		Me.btpro = New System.Windows.Forms.Button
		Me.txtPro = New System.Windows.Forms.TextBox
		Me.Option1 = New System.Windows.Forms.RadioButton
		Me.Option2 = New System.Windows.Forms.RadioButton
		Me.TxtAnio = New System.Windows.Forms.TextBox
		Me.TxtDistritoAd = New System.Windows.Forms.TextBox
		Me.TxtRegimen = New System.Windows.Forms.TextBox
		Me.TxtCorrelativo = New System.Windows.Forms.TextBox
		Me.TxtVerificador = New System.Windows.Forms.TextBox
		Me.BtEmision = New System.Windows.Forms.Button
		Me.txtFecLiquidacion = New System.Windows.Forms.TextBox
		Me.TxtValCif = New System.Windows.Forms.TextBox
		Me.Frame3 = New System.Windows.Forms.GroupBox
		Me.TxtBasImpIR = New System.Windows.Forms.TextBox
		Me.TxtPorcRetIR = New System.Windows.Forms.TextBox
		Me.CodRetFteImpRent = New AxMSDataListLib.AxDataCombo
		Me.Label33 = New System.Windows.Forms.Label
		Me.Label34 = New System.Windows.Forms.Label
		Me.Label35 = New System.Windows.Forms.Label
		Me.Label36 = New System.Windows.Forms.Label
		Me.TxtMonRetRen = New System.Windows.Forms.Label
		Me.F2 = New System.Windows.Forms.Panel
		Me.Command2 = New System.Windows.Forms.Button
		Me.btncancelar = New System.Windows.Forms.Button
		Me.btngrabar = New System.Windows.Forms.Button
		Me.DcPorICE = New AxMSDataListLib.AxDataCombo
		Me.dtCodSus = New VB6.ADODC
		Me.DtPorIvaServ = New VB6.ADODC
		Me.dtCom = New VB6.ADODC
		Me.dtPorIva = New VB6.ADODC
		Me.DtPorICE = New VB6.ADODC
		Me.dcPorIva = New AxMSDataListLib.AxDataCombo
		Me.TipoComprobante = New AxMSDataListLib.AxDataCombo
		Me.DatSustento = New AxMSDataListLib.AxDataCombo
		Me.DtPorRetIR = New VB6.ADODC
		Me.f3 = New System.Windows.Forms.Panel
		Me.btneliminar = New System.Windows.Forms.Button
		Me.btnbuscar = New System.Windows.Forms.Button
		Me.btnnuevo = New System.Windows.Forms.Button
		Me.btnmodificar = New System.Windows.Forms.Button
		Me.btnsalir = New System.Windows.Forms.Button
		Me.Label6 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label8 = New System.Windows.Forms.Label
		Me.Label22 = New System.Windows.Forms.Label
		Me.Label9 = New System.Windows.Forms.Label
		Me.Label19 = New System.Windows.Forms.Label
		Me.Label16 = New System.Windows.Forms.Label
		Me.Label12 = New System.Windows.Forms.Label
		Me.Label7 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.TxtMonIce = New System.Windows.Forms.Label
		Me.TxtMonIva = New System.Windows.Forms.Label
		Me.TxtMonIvaSer = New System.Windows.Forms.Label
		Me.Label48 = New System.Windows.Forms.Label
		Me.TxtPorcIce = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.lbNomP = New System.Windows.Forms.Label
		Me.lbClioPro = New System.Windows.Forms.Label
		Me.Label40 = New System.Windows.Forms.Label
		Me.Label49 = New System.Windows.Forms.Label
		Me.Label14 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Frame3.SuspendLayout()
		Me.F2.SuspendLayout()
		Me.f3.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.CodRetFteImpRent, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.DcPorICE, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dcPorIva, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.TipoComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.DatSustento, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Importaciones"
		Me.ClientSize = New System.Drawing.Size(742, 381)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.ForeColor = System.Drawing.Color.Black
		Me.Icon = CType(resources.GetObject("SRIIMPORTA.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "SRIIMPORTA"
		Me.txtBasImpGra.AutoSize = False
		Me.txtBasImpGra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtBasImpGra.BackColor = System.Drawing.Color.White
		Me.txtBasImpGra.ForeColor = System.Drawing.Color.Black
		Me.txtBasImpGra.Size = New System.Drawing.Size(89, 19)
		Me.txtBasImpGra.Location = New System.Drawing.Point(392, 184)
		Me.txtBasImpGra.Maxlength = 12
		Me.txtBasImpGra.TabIndex = 34
		Me.ToolTip1.SetToolTip(Me.txtBasImpGra, "Base imponible grabada")
		Me.txtBasImpGra.AcceptsReturn = True
		Me.txtBasImpGra.CausesValidation = True
		Me.txtBasImpGra.Enabled = True
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
		Me.TxtBasImpICE.AutoSize = False
		Me.TxtBasImpICE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.TxtBasImpICE.Size = New System.Drawing.Size(89, 19)
		Me.TxtBasImpICE.Location = New System.Drawing.Point(360, 152)
		Me.TxtBasImpICE.Maxlength = 12
		Me.TxtBasImpICE.TabIndex = 33
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
		Me.txtMonIvaBie.AutoSize = False
		Me.txtMonIvaBie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtMonIvaBie.BackColor = System.Drawing.Color.White
		Me.txtMonIvaBie.ForeColor = System.Drawing.Color.Black
		Me.txtMonIvaBie.Size = New System.Drawing.Size(89, 19)
		Me.txtMonIvaBie.Location = New System.Drawing.Point(392, 216)
		Me.txtMonIvaBie.TabIndex = 32
		Me.ToolTip1.SetToolTip(Me.txtMonIvaBie, "Monto Iva por transferencia de bienes")
		Me.txtMonIvaBie.AcceptsReturn = True
		Me.txtMonIvaBie.CausesValidation = True
		Me.txtMonIvaBie.Enabled = True
		Me.txtMonIvaBie.HideSelection = True
		Me.txtMonIvaBie.ReadOnly = False
		Me.txtMonIvaBie.Maxlength = 0
		Me.txtMonIvaBie.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtMonIvaBie.MultiLine = False
		Me.txtMonIvaBie.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtMonIvaBie.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtMonIvaBie.TabStop = True
		Me.txtMonIvaBie.Visible = True
		Me.txtMonIvaBie.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtMonIvaBie.Name = "txtMonIvaBie"
		Me.txtBasImpTar0.AutoSize = False
		Me.txtBasImpTar0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtBasImpTar0.BackColor = System.Drawing.Color.White
		Me.txtBasImpTar0.ForeColor = System.Drawing.Color.Black
		Me.txtBasImpTar0.Size = New System.Drawing.Size(89, 19)
		Me.txtBasImpTar0.Location = New System.Drawing.Point(152, 184)
		Me.txtBasImpTar0.Maxlength = 12
		Me.txtBasImpTar0.TabIndex = 31
		Me.ToolTip1.SetToolTip(Me.txtBasImpTar0, "Base imponible tarifa cero")
		Me.txtBasImpTar0.AcceptsReturn = True
		Me.txtBasImpTar0.CausesValidation = True
		Me.txtBasImpTar0.Enabled = True
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
		Me.btpro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.btpro.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.btpro.Size = New System.Drawing.Size(17, 19)
		Me.btpro.Location = New System.Drawing.Point(272, 96)
		Me.btpro.Image = CType(resources.GetObject("btpro.Image"), System.Drawing.Image)
		Me.btpro.TabIndex = 30
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
		Me.txtPro.Location = New System.Drawing.Point(168, 96)
		Me.txtPro.Maxlength = 13
		Me.txtPro.TabIndex = 29
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
		Me.Option1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.Option1.Text = "Importación de Bienes"
		Me.Option1.Size = New System.Drawing.Size(137, 17)
		Me.Option1.Location = New System.Drawing.Point(16, 16)
		Me.Option1.TabIndex = 28
		Me.Option1.Checked = True
		Me.Option1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.Option1.BackColor = System.Drawing.SystemColors.Control
		Me.Option1.CausesValidation = True
		Me.Option1.Enabled = True
		Me.Option1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Option1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Option1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Option1.Appearance = System.Windows.Forms.Appearance.Normal
		Me.Option1.TabStop = True
		Me.Option1.Visible = True
		Me.Option1.Name = "Option1"
		Me.Option2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.Option2.Text = "Importación de Servicios"
		Me.Option2.Size = New System.Drawing.Size(137, 17)
		Me.Option2.Location = New System.Drawing.Point(16, 40)
		Me.Option2.TabIndex = 27
		Me.Option2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.Option2.BackColor = System.Drawing.SystemColors.Control
		Me.Option2.CausesValidation = True
		Me.Option2.Enabled = True
		Me.Option2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Option2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Option2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Option2.Appearance = System.Windows.Forms.Appearance.Normal
		Me.Option2.TabStop = True
		Me.Option2.Checked = False
		Me.Option2.Visible = True
		Me.Option2.Name = "Option2"
		Me.TxtAnio.AutoSize = False
		Me.TxtAnio.Size = New System.Drawing.Size(41, 19)
		Me.TxtAnio.Location = New System.Drawing.Point(296, 24)
		Me.TxtAnio.Maxlength = 4
		Me.TxtAnio.TabIndex = 26
		Me.TxtAnio.Text = "2005"
		Me.ToolTip1.SetToolTip(Me.TxtAnio, "número de serie del comprobante")
		Me.TxtAnio.AcceptsReturn = True
		Me.TxtAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TxtAnio.BackColor = System.Drawing.SystemColors.Window
		Me.TxtAnio.CausesValidation = True
		Me.TxtAnio.Enabled = True
		Me.TxtAnio.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtAnio.HideSelection = True
		Me.TxtAnio.ReadOnly = False
		Me.TxtAnio.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtAnio.MultiLine = False
		Me.TxtAnio.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtAnio.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtAnio.TabStop = True
		Me.TxtAnio.Visible = True
		Me.TxtAnio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtAnio.Name = "TxtAnio"
		Me.TxtDistritoAd.AutoSize = False
		Me.TxtDistritoAd.Size = New System.Drawing.Size(33, 19)
		Me.TxtDistritoAd.Location = New System.Drawing.Point(264, 24)
		Me.TxtDistritoAd.Maxlength = 3
		Me.TxtDistritoAd.TabIndex = 25
		Me.TxtDistritoAd.Text = "123"
		Me.ToolTip1.SetToolTip(Me.TxtDistritoAd, "número de serie del comprobante")
		Me.TxtDistritoAd.AcceptsReturn = True
		Me.TxtDistritoAd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TxtDistritoAd.BackColor = System.Drawing.SystemColors.Window
		Me.TxtDistritoAd.CausesValidation = True
		Me.TxtDistritoAd.Enabled = True
		Me.TxtDistritoAd.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtDistritoAd.HideSelection = True
		Me.TxtDistritoAd.ReadOnly = False
		Me.TxtDistritoAd.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtDistritoAd.MultiLine = False
		Me.TxtDistritoAd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtDistritoAd.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtDistritoAd.TabStop = True
		Me.TxtDistritoAd.Visible = True
		Me.TxtDistritoAd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtDistritoAd.Name = "TxtDistritoAd"
		Me.TxtRegimen.AutoSize = False
		Me.TxtRegimen.Size = New System.Drawing.Size(33, 19)
		Me.TxtRegimen.Location = New System.Drawing.Point(336, 24)
		Me.TxtRegimen.Maxlength = 2
		Me.TxtRegimen.TabIndex = 24
		Me.TxtRegimen.Text = "10"
		Me.TxtRegimen.AcceptsReturn = True
		Me.TxtRegimen.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TxtRegimen.BackColor = System.Drawing.SystemColors.Window
		Me.TxtRegimen.CausesValidation = True
		Me.TxtRegimen.Enabled = True
		Me.TxtRegimen.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtRegimen.HideSelection = True
		Me.TxtRegimen.ReadOnly = False
		Me.TxtRegimen.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtRegimen.MultiLine = False
		Me.TxtRegimen.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtRegimen.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtRegimen.TabStop = True
		Me.TxtRegimen.Visible = True
		Me.TxtRegimen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtRegimen.Name = "TxtRegimen"
		Me.TxtCorrelativo.AutoSize = False
		Me.TxtCorrelativo.Size = New System.Drawing.Size(52, 19)
		Me.TxtCorrelativo.Location = New System.Drawing.Point(368, 24)
		Me.TxtCorrelativo.Maxlength = 10
		Me.TxtCorrelativo.TabIndex = 23
		Me.TxtCorrelativo.Text = "123456"
		Me.TxtCorrelativo.AcceptsReturn = True
		Me.TxtCorrelativo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TxtCorrelativo.BackColor = System.Drawing.SystemColors.Window
		Me.TxtCorrelativo.CausesValidation = True
		Me.TxtCorrelativo.Enabled = True
		Me.TxtCorrelativo.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtCorrelativo.HideSelection = True
		Me.TxtCorrelativo.ReadOnly = False
		Me.TxtCorrelativo.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtCorrelativo.MultiLine = False
		Me.TxtCorrelativo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtCorrelativo.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtCorrelativo.TabStop = True
		Me.TxtCorrelativo.Visible = True
		Me.TxtCorrelativo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtCorrelativo.Name = "TxtCorrelativo"
		Me.TxtVerificador.AutoSize = False
		Me.TxtVerificador.Size = New System.Drawing.Size(21, 19)
		Me.TxtVerificador.Location = New System.Drawing.Point(416, 24)
		Me.TxtVerificador.Maxlength = 1
		Me.TxtVerificador.TabIndex = 22
		Me.TxtVerificador.Text = "1"
		Me.TxtVerificador.AcceptsReturn = True
		Me.TxtVerificador.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TxtVerificador.BackColor = System.Drawing.SystemColors.Window
		Me.TxtVerificador.CausesValidation = True
		Me.TxtVerificador.Enabled = True
		Me.TxtVerificador.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtVerificador.HideSelection = True
		Me.TxtVerificador.ReadOnly = False
		Me.TxtVerificador.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtVerificador.MultiLine = False
		Me.TxtVerificador.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtVerificador.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtVerificador.TabStop = True
		Me.TxtVerificador.Visible = True
		Me.TxtVerificador.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtVerificador.Name = "TxtVerificador"
		Me.BtEmision.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.BtEmision.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.BtEmision.Size = New System.Drawing.Size(17, 19)
		Me.BtEmision.Location = New System.Drawing.Point(664, 24)
		Me.BtEmision.Image = CType(resources.GetObject("BtEmision.Image"), System.Drawing.Image)
		Me.BtEmision.TabIndex = 21
		Me.ToolTip1.SetToolTip(Me.BtEmision, "Escojer de una lista")
		Me.BtEmision.CausesValidation = True
		Me.BtEmision.Enabled = True
		Me.BtEmision.ForeColor = System.Drawing.SystemColors.ControlText
		Me.BtEmision.Cursor = System.Windows.Forms.Cursors.Default
		Me.BtEmision.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.BtEmision.TabStop = True
		Me.BtEmision.Name = "BtEmision"
		Me.txtFecLiquidacion.AutoSize = False
		Me.txtFecLiquidacion.Size = New System.Drawing.Size(65, 19)
		Me.txtFecLiquidacion.Location = New System.Drawing.Point(600, 24)
		Me.txtFecLiquidacion.Maxlength = 10
		Me.txtFecLiquidacion.TabIndex = 20
		Me.ToolTip1.SetToolTip(Me.txtFecLiquidacion, "Fecha de emisión del comprobante")
		Me.txtFecLiquidacion.AcceptsReturn = True
		Me.txtFecLiquidacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtFecLiquidacion.BackColor = System.Drawing.SystemColors.Window
		Me.txtFecLiquidacion.CausesValidation = True
		Me.txtFecLiquidacion.Enabled = True
		Me.txtFecLiquidacion.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtFecLiquidacion.HideSelection = True
		Me.txtFecLiquidacion.ReadOnly = False
		Me.txtFecLiquidacion.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtFecLiquidacion.MultiLine = False
		Me.txtFecLiquidacion.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtFecLiquidacion.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtFecLiquidacion.TabStop = True
		Me.txtFecLiquidacion.Visible = True
		Me.txtFecLiquidacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtFecLiquidacion.Name = "txtFecLiquidacion"
		Me.TxtValCif.AutoSize = False
		Me.TxtValCif.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.TxtValCif.Size = New System.Drawing.Size(89, 19)
		Me.TxtValCif.Location = New System.Drawing.Point(584, 120)
		Me.TxtValCif.Maxlength = 12
		Me.TxtValCif.TabIndex = 19
		Me.ToolTip1.SetToolTip(Me.TxtValCif, "Base imponible grabada")
		Me.TxtValCif.AcceptsReturn = True
		Me.TxtValCif.BackColor = System.Drawing.SystemColors.Window
		Me.TxtValCif.CausesValidation = True
		Me.TxtValCif.Enabled = True
		Me.TxtValCif.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtValCif.HideSelection = True
		Me.TxtValCif.ReadOnly = False
		Me.TxtValCif.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtValCif.MultiLine = False
		Me.TxtValCif.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtValCif.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtValCif.TabStop = True
		Me.TxtValCif.Visible = True
		Me.TxtValCif.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtValCif.Name = "TxtValCif"
		Me.Frame3.Text = "RETENCION EN LA FUENTE"
		Me.Frame3.ForeColor = System.Drawing.Color.Black
		Me.Frame3.Size = New System.Drawing.Size(721, 89)
		Me.Frame3.Location = New System.Drawing.Point(8, 248)
		Me.Frame3.TabIndex = 10
		Me.Frame3.BackColor = System.Drawing.SystemColors.Control
		Me.Frame3.Enabled = True
		Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame3.Visible = True
		Me.Frame3.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame3.Name = "Frame3"
		Me.TxtBasImpIR.AutoSize = False
		Me.TxtBasImpIR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.TxtBasImpIR.Size = New System.Drawing.Size(89, 19)
		Me.TxtBasImpIR.Location = New System.Drawing.Point(152, 56)
		Me.TxtBasImpIR.Maxlength = 12
		Me.TxtBasImpIR.TabIndex = 12
		Me.ToolTip1.SetToolTip(Me.TxtBasImpIR, "Base imponible tarifa cero")
		Me.TxtBasImpIR.AcceptsReturn = True
		Me.TxtBasImpIR.BackColor = System.Drawing.SystemColors.Window
		Me.TxtBasImpIR.CausesValidation = True
		Me.TxtBasImpIR.Enabled = True
		Me.TxtBasImpIR.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtBasImpIR.HideSelection = True
		Me.TxtBasImpIR.ReadOnly = False
		Me.TxtBasImpIR.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtBasImpIR.MultiLine = False
		Me.TxtBasImpIR.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtBasImpIR.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtBasImpIR.TabStop = True
		Me.TxtBasImpIR.Visible = True
		Me.TxtBasImpIR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtBasImpIR.Name = "TxtBasImpIR"
		Me.TxtPorcRetIR.AutoSize = False
		Me.TxtPorcRetIR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.TxtPorcRetIR.Size = New System.Drawing.Size(65, 19)
		Me.TxtPorcRetIR.Location = New System.Drawing.Point(400, 56)
		Me.TxtPorcRetIR.Maxlength = 7
		Me.TxtPorcRetIR.TabIndex = 11
		Me.ToolTip1.SetToolTip(Me.TxtPorcRetIR, "Número secuencial del comprobante")
		Me.TxtPorcRetIR.AcceptsReturn = True
		Me.TxtPorcRetIR.BackColor = System.Drawing.SystemColors.Window
		Me.TxtPorcRetIR.CausesValidation = True
		Me.TxtPorcRetIR.Enabled = True
		Me.TxtPorcRetIR.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtPorcRetIR.HideSelection = True
		Me.TxtPorcRetIR.ReadOnly = False
		Me.TxtPorcRetIR.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtPorcRetIR.MultiLine = False
		Me.TxtPorcRetIR.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtPorcRetIR.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtPorcRetIR.TabStop = True
		Me.TxtPorcRetIR.Visible = True
		Me.TxtPorcRetIR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtPorcRetIR.Name = "TxtPorcRetIR"
		CodRetFteImpRent.OcxState = CType(resources.GetObject("CodRetFteImpRent.OcxState"), System.Windows.Forms.AxHost.State)
		Me.CodRetFteImpRent.Size = New System.Drawing.Size(353, 21)
		Me.CodRetFteImpRent.Location = New System.Drawing.Point(208, 24)
		Me.CodRetFteImpRent.TabIndex = 13
		Me.CodRetFteImpRent.Name = "CodRetFteImpRent"
		Me.Label33.Text = "Base Imponible  para Renta"
		Me.Label33.Size = New System.Drawing.Size(131, 13)
		Me.Label33.Location = New System.Drawing.Point(8, 64)
		Me.Label33.TabIndex = 18
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
		Me.Label34.Text = "Porcentaje Retención Renta "
		Me.Label34.Size = New System.Drawing.Size(138, 13)
		Me.Label34.Location = New System.Drawing.Point(256, 64)
		Me.Label34.TabIndex = 17
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
		Me.Label35.Text = "Monto Retención Renta"
		Me.Label35.Size = New System.Drawing.Size(114, 13)
		Me.Label35.Location = New System.Drawing.Point(488, 64)
		Me.Label35.TabIndex = 16
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
		Me.Label36.Text = "Concepto de Retención Impuesto Renta"
		Me.Label36.Size = New System.Drawing.Size(191, 13)
		Me.Label36.Location = New System.Drawing.Point(8, 32)
		Me.Label36.TabIndex = 15
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
		Me.TxtMonRetRen.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.TxtMonRetRen.BackColor = System.Drawing.Color.White
		Me.TxtMonRetRen.Size = New System.Drawing.Size(102, 19)
		Me.TxtMonRetRen.Location = New System.Drawing.Point(608, 56)
		Me.TxtMonRetRen.TabIndex = 14
		Me.TxtMonRetRen.Enabled = True
		Me.TxtMonRetRen.ForeColor = System.Drawing.SystemColors.ControlText
		Me.TxtMonRetRen.Cursor = System.Windows.Forms.Cursors.Default
		Me.TxtMonRetRen.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtMonRetRen.UseMnemonic = True
		Me.TxtMonRetRen.Visible = True
		Me.TxtMonRetRen.AutoSize = False
		Me.TxtMonRetRen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtMonRetRen.Name = "TxtMonRetRen"
		Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.F2.Size = New System.Drawing.Size(177, 50)
		Me.F2.Location = New System.Drawing.Point(8, 328)
		Me.F2.TabIndex = 9
		Me.F2.BackColor = System.Drawing.SystemColors.Control
		Me.F2.Enabled = True
		Me.F2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.F2.Cursor = System.Windows.Forms.Cursors.Default
		Me.F2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.F2.Visible = True
		Me.F2.Name = "F2"
		Me.Command2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command2.BackColor = System.Drawing.SystemColors.Control
		Me.Command2.Text = "&Salir"
		Me.Command2.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Command2.Size = New System.Drawing.Size(54, 34)
		Me.Command2.Location = New System.Drawing.Point(120, 13)
		Me.Command2.TabIndex = 2
		Me.ToolTip1.SetToolTip(Me.Command2, "Regresa al menu principal")
		Me.Command2.CausesValidation = True
		Me.Command2.Enabled = True
		Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command2.TabStop = True
		Me.Command2.Name = "Command2"
		Me.btncancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btncancelar.BackColor = System.Drawing.SystemColors.Control
		Me.CancelButton = Me.btncancelar
		Me.btncancelar.Text = "&Cancelar"
		Me.btncancelar.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btncancelar.Size = New System.Drawing.Size(54, 34)
		Me.btncancelar.Location = New System.Drawing.Point(64, 13)
		Me.btncancelar.TabIndex = 1
		Me.ToolTip1.SetToolTip(Me.btncancelar, "Cancela acción")
		Me.btncancelar.CausesValidation = True
		Me.btncancelar.Enabled = True
		Me.btncancelar.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btncancelar.Cursor = System.Windows.Forms.Cursors.Default
		Me.btncancelar.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btncancelar.TabStop = True
		Me.btncancelar.Name = "btncancelar"
		Me.btngrabar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btngrabar.BackColor = System.Drawing.SystemColors.Control
		Me.btngrabar.Text = "&Grabar"
		Me.btngrabar.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btngrabar.Size = New System.Drawing.Size(54, 34)
		Me.btngrabar.Location = New System.Drawing.Point(8, 13)
		Me.btngrabar.TabIndex = 0
		Me.ToolTip1.SetToolTip(Me.btngrabar, "Graba el registro")
		Me.btngrabar.CausesValidation = True
		Me.btngrabar.Enabled = True
		Me.btngrabar.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btngrabar.Cursor = System.Windows.Forms.Cursors.Default
		Me.btngrabar.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btngrabar.TabStop = True
		Me.btngrabar.Name = "btngrabar"
		DcPorICE.OcxState = CType(resources.GetObject("DcPorICE.OcxState"), System.Windows.Forms.AxHost.State)
		Me.DcPorICE.Size = New System.Drawing.Size(177, 21)
		Me.DcPorICE.Location = New System.Drawing.Point(96, 152)
		Me.DcPorICE.TabIndex = 35
		Me.DcPorICE.Name = "DcPorICE"
		Me.dtCodSus.Size = New System.Drawing.Size(80, 22)
		Me.dtCodSus.Location = New System.Drawing.Point(656, 8)
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
		Me.DtPorIvaServ.Location = New System.Drawing.Point(656, 72)
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
		Me.dtCom.Location = New System.Drawing.Point(656, 56)
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
		Me.dtPorIva.Location = New System.Drawing.Point(656, 40)
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
		Me.DtPorICE.Location = New System.Drawing.Point(656, 24)
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
		dcPorIva.OcxState = CType(resources.GetObject("dcPorIva.OcxState"), System.Windows.Forms.AxHost.State)
		Me.dcPorIva.Size = New System.Drawing.Size(65, 21)
		Me.dcPorIva.Location = New System.Drawing.Point(600, 184)
		Me.dcPorIva.TabIndex = 36
		Me.dcPorIva.Name = "dcPorIva"
		TipoComprobante.OcxState = CType(resources.GetObject("TipoComprobante.OcxState"), System.Windows.Forms.AxHost.State)
		Me.TipoComprobante.Size = New System.Drawing.Size(353, 21)
		Me.TipoComprobante.Location = New System.Drawing.Point(136, 120)
		Me.TipoComprobante.TabIndex = 37
		Me.TipoComprobante.Name = "TipoComprobante"
		DatSustento.OcxState = CType(resources.GetObject("DatSustento.OcxState"), System.Windows.Forms.AxHost.State)
		Me.DatSustento.Size = New System.Drawing.Size(353, 21)
		Me.DatSustento.Location = New System.Drawing.Point(168, 64)
		Me.DatSustento.TabIndex = 38
		Me.DatSustento.Name = "DatSustento"
		Me.DtPorRetIR.Size = New System.Drawing.Size(80, 22)
		Me.DtPorRetIR.Location = New System.Drawing.Point(672, 88)
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
		Me.f3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.f3.ForeColor = System.Drawing.SystemColors.Control
		Me.f3.Size = New System.Drawing.Size(297, 50)
		Me.f3.Location = New System.Drawing.Point(8, 328)
		Me.f3.TabIndex = 8
		Me.f3.BackColor = System.Drawing.SystemColors.Control
		Me.f3.Enabled = True
		Me.f3.Cursor = System.Windows.Forms.Cursors.Default
		Me.f3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.f3.Visible = True
		Me.f3.Name = "f3"
		Me.btneliminar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btneliminar.Text = "&Eliminar"
		Me.btneliminar.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btneliminar.Size = New System.Drawing.Size(54, 34)
		Me.btneliminar.Location = New System.Drawing.Point(176, 13)
		Me.btneliminar.TabIndex = 6
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
		Me.btnbuscar.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnbuscar.Size = New System.Drawing.Size(54, 34)
		Me.btnbuscar.Location = New System.Drawing.Point(120, 13)
		Me.btnbuscar.TabIndex = 5
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
		Me.btnnuevo.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnnuevo.Size = New System.Drawing.Size(54, 34)
		Me.btnnuevo.Location = New System.Drawing.Point(64, 13)
		Me.btnnuevo.TabIndex = 4
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
		Me.btnmodificar.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnmodificar.Size = New System.Drawing.Size(54, 34)
		Me.btnmodificar.Location = New System.Drawing.Point(8, 13)
		Me.btnmodificar.TabIndex = 3
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
		Me.btnsalir.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnsalir.Size = New System.Drawing.Size(54, 34)
		Me.btnsalir.Location = New System.Drawing.Point(232, 13)
		Me.btnsalir.TabIndex = 7
		Me.ToolTip1.SetToolTip(Me.btnsalir, "Regresa al menu principal")
		Me.btnsalir.BackColor = System.Drawing.SystemColors.Control
		Me.btnsalir.CausesValidation = True
		Me.btnsalir.Enabled = True
		Me.btnsalir.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnsalir.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnsalir.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnsalir.TabStop = True
		Me.btnsalir.Name = "btnsalir"
		Me.Label6.Text = "Base Imponible Grabada IVA"
		Me.Label6.ForeColor = System.Drawing.Color.Black
		Me.Label6.Size = New System.Drawing.Size(136, 13)
		Me.Label6.Location = New System.Drawing.Point(248, 192)
		Me.Label6.TabIndex = 61
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label6.BackColor = System.Drawing.Color.Transparent
		Me.Label6.Enabled = True
		Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label6.UseMnemonic = True
		Me.Label6.Visible = True
		Me.Label6.AutoSize = True
		Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label6.Name = "Label6"
		Me.Label2.Text = "Porcentaje  IVA"
		Me.Label2.ForeColor = System.Drawing.Color.Black
		Me.Label2.Size = New System.Drawing.Size(74, 13)
		Me.Label2.Location = New System.Drawing.Point(512, 192)
		Me.Label2.TabIndex = 60
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.Color.Transparent
		Me.Label2.Enabled = True
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = True
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label8.Text = "Monto  IVA Base Imponible"
		Me.Label8.ForeColor = System.Drawing.Color.Black
		Me.Label8.Size = New System.Drawing.Size(128, 13)
		Me.Label8.Location = New System.Drawing.Point(24, 224)
		Me.Label8.TabIndex = 59
		Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label8.BackColor = System.Drawing.Color.Transparent
		Me.Label8.Enabled = True
		Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label8.UseMnemonic = True
		Me.Label8.Visible = True
		Me.Label8.AutoSize = True
		Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label8.Name = "Label8"
		Me.Label22.Text = "Base Imponible"
		Me.Label22.Size = New System.Drawing.Size(72, 13)
		Me.Label22.Location = New System.Drawing.Point(280, 160)
		Me.Label22.TabIndex = 58
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
		Me.Label9.Text = "Concepto ICE"
		Me.Label9.Size = New System.Drawing.Size(66, 13)
		Me.Label9.Location = New System.Drawing.Point(24, 160)
		Me.Label9.TabIndex = 57
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
		Me.Label19.Text = "Monto IVA Bienes"
		Me.Label19.ForeColor = System.Drawing.Color.Black
		Me.Label19.Size = New System.Drawing.Size(85, 13)
		Me.Label19.Location = New System.Drawing.Point(296, 224)
		Me.Label19.TabIndex = 56
		Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label19.BackColor = System.Drawing.Color.Transparent
		Me.Label19.Enabled = True
		Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label19.UseMnemonic = True
		Me.Label19.Visible = True
		Me.Label19.AutoSize = True
		Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label19.Name = "Label19"
		Me.Label16.Text = "Monto IVA Servicios"
		Me.Label16.ForeColor = System.Drawing.Color.Black
		Me.Label16.Size = New System.Drawing.Size(96, 13)
		Me.Label16.Location = New System.Drawing.Point(512, 224)
		Me.Label16.TabIndex = 55
		Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label16.BackColor = System.Drawing.Color.Transparent
		Me.Label16.Enabled = True
		Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label16.UseMnemonic = True
		Me.Label16.Visible = True
		Me.Label16.AutoSize = True
		Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label16.Name = "Label16"
		Me.Label12.Text = "Monto  ICE"
		Me.Label12.Size = New System.Drawing.Size(53, 13)
		Me.Label12.Location = New System.Drawing.Point(568, 160)
		Me.Label12.TabIndex = 54
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
		Me.Label7.Text = "BaseImponibleTarifa 0%"
		Me.Label7.ForeColor = System.Drawing.Color.Black
		Me.Label7.Size = New System.Drawing.Size(113, 13)
		Me.Label7.Location = New System.Drawing.Point(24, 192)
		Me.Label7.TabIndex = 53
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label7.BackColor = System.Drawing.Color.Transparent
		Me.Label7.Enabled = True
		Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label7.UseMnemonic = True
		Me.Label7.Visible = True
		Me.Label7.AutoSize = True
		Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label7.Name = "Label7"
		Me.Label5.Size = New System.Drawing.Size(4, 20)
		Me.Label5.Location = New System.Drawing.Point(496, 152)
		Me.Label5.TabIndex = 52
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
		Me.Label3.Text = "&Tipo de Comprobante"
		Me.Label3.Size = New System.Drawing.Size(102, 13)
		Me.Label3.Location = New System.Drawing.Point(24, 128)
		Me.Label3.TabIndex = 51
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
		Me.TxtMonIce.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.TxtMonIce.BackColor = System.Drawing.Color.White
		Me.TxtMonIce.Size = New System.Drawing.Size(102, 19)
		Me.TxtMonIce.Location = New System.Drawing.Point(632, 152)
		Me.TxtMonIce.TabIndex = 50
		Me.TxtMonIce.Enabled = True
		Me.TxtMonIce.ForeColor = System.Drawing.SystemColors.ControlText
		Me.TxtMonIce.Cursor = System.Windows.Forms.Cursors.Default
		Me.TxtMonIce.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtMonIce.UseMnemonic = True
		Me.TxtMonIce.Visible = True
		Me.TxtMonIce.AutoSize = False
		Me.TxtMonIce.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtMonIce.Name = "TxtMonIce"
		Me.TxtMonIva.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.TxtMonIva.ForeColor = System.Drawing.Color.Black
		Me.TxtMonIva.Size = New System.Drawing.Size(102, 19)
		Me.TxtMonIva.Location = New System.Drawing.Point(160, 216)
		Me.TxtMonIva.TabIndex = 49
		Me.TxtMonIva.BackColor = System.Drawing.SystemColors.Control
		Me.TxtMonIva.Enabled = True
		Me.TxtMonIva.Cursor = System.Windows.Forms.Cursors.Default
		Me.TxtMonIva.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtMonIva.UseMnemonic = True
		Me.TxtMonIva.Visible = True
		Me.TxtMonIva.AutoSize = False
		Me.TxtMonIva.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtMonIva.Name = "TxtMonIva"
		Me.TxtMonIvaSer.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.TxtMonIvaSer.BackColor = System.Drawing.Color.White
		Me.TxtMonIvaSer.Size = New System.Drawing.Size(102, 19)
		Me.TxtMonIvaSer.Location = New System.Drawing.Point(616, 216)
		Me.TxtMonIvaSer.TabIndex = 48
		Me.TxtMonIvaSer.Enabled = True
		Me.TxtMonIvaSer.ForeColor = System.Drawing.SystemColors.ControlText
		Me.TxtMonIvaSer.Cursor = System.Windows.Forms.Cursors.Default
		Me.TxtMonIvaSer.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtMonIvaSer.UseMnemonic = True
		Me.TxtMonIvaSer.Visible = True
		Me.TxtMonIvaSer.AutoSize = False
		Me.TxtMonIvaSer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtMonIvaSer.Name = "TxtMonIvaSer"
		Me.Label48.Text = "%ICE"
		Me.Label48.Size = New System.Drawing.Size(25, 13)
		Me.Label48.Location = New System.Drawing.Point(464, 160)
		Me.Label48.TabIndex = 47
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
		Me.TxtPorcIce.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.TxtPorcIce.BackColor = System.Drawing.Color.White
		Me.TxtPorcIce.Size = New System.Drawing.Size(62, 19)
		Me.TxtPorcIce.Location = New System.Drawing.Point(496, 152)
		Me.TxtPorcIce.TabIndex = 46
		Me.TxtPorcIce.Enabled = True
		Me.TxtPorcIce.ForeColor = System.Drawing.SystemColors.ControlText
		Me.TxtPorcIce.Cursor = System.Windows.Forms.Cursors.Default
		Me.TxtPorcIce.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtPorcIce.UseMnemonic = True
		Me.TxtPorcIce.Visible = True
		Me.TxtPorcIce.AutoSize = False
		Me.TxtPorcIce.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtPorcIce.Name = "TxtPorcIce"
		Me.Label1.Text = "&Sustento Tributario o gasto"
		Me.Label1.Size = New System.Drawing.Size(127, 13)
		Me.Label1.Location = New System.Drawing.Point(24, 72)
		Me.Label1.TabIndex = 45
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
		Me.lbNomP.Location = New System.Drawing.Point(296, 96)
		Me.lbNomP.TabIndex = 44
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
		Me.lbClioPro.Location = New System.Drawing.Point(24, 104)
		Me.lbClioPro.TabIndex = 43
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
		Me.Label40.Text = "Nro.Referendo"
		Me.Label40.Size = New System.Drawing.Size(70, 13)
		Me.Label40.Location = New System.Drawing.Point(184, 32)
		Me.Label40.TabIndex = 42
		Me.Label40.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label40.BackColor = System.Drawing.Color.Transparent
		Me.Label40.Enabled = True
		Me.Label40.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label40.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label40.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label40.UseMnemonic = True
		Me.Label40.Visible = True
		Me.Label40.AutoSize = True
		Me.Label40.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label40.Name = "Label40"
		Me.Label49.Text = "dd/mm/aaaa"
		Me.Label49.Enabled = False
		Me.Label49.ForeColor = System.Drawing.Color.FromARGB(128, 128, 128)
		Me.Label49.Size = New System.Drawing.Size(52, 13)
		Me.Label49.Location = New System.Drawing.Point(608, 40)
		Me.Label49.TabIndex = 41
		Me.Label49.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label49.BackColor = System.Drawing.Color.Transparent
		Me.Label49.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label49.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label49.UseMnemonic = True
		Me.Label49.Visible = True
		Me.Label49.AutoSize = True
		Me.Label49.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label49.Name = "Label49"
		Me.Label14.Text = "&Fecha de liquidación o Pago"
		Me.Label14.Size = New System.Drawing.Size(135, 13)
		Me.Label14.Location = New System.Drawing.Point(456, 32)
		Me.Label14.TabIndex = 40
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
		Me.Label4.Text = "Valor CIF"
		Me.Label4.Size = New System.Drawing.Size(43, 13)
		Me.Label4.Location = New System.Drawing.Point(528, 128)
		Me.Label4.TabIndex = 39
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label4.BackColor = System.Drawing.Color.Transparent
		Me.Label4.Enabled = True
		Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = True
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.Controls.Add(txtBasImpGra)
		Me.Controls.Add(TxtBasImpICE)
		Me.Controls.Add(txtMonIvaBie)
		Me.Controls.Add(txtBasImpTar0)
		Me.Controls.Add(btpro)
		Me.Controls.Add(txtPro)
		Me.Controls.Add(Option1)
		Me.Controls.Add(Option2)
		Me.Controls.Add(TxtAnio)
		Me.Controls.Add(TxtDistritoAd)
		Me.Controls.Add(TxtRegimen)
		Me.Controls.Add(TxtCorrelativo)
		Me.Controls.Add(TxtVerificador)
		Me.Controls.Add(BtEmision)
		Me.Controls.Add(txtFecLiquidacion)
		Me.Controls.Add(TxtValCif)
		Me.Controls.Add(Frame3)
		Me.Controls.Add(F2)
		Me.Controls.Add(DcPorICE)
		Me.Controls.Add(dtCodSus)
		Me.Controls.Add(DtPorIvaServ)
		Me.Controls.Add(dtCom)
		Me.Controls.Add(dtPorIva)
		Me.Controls.Add(DtPorICE)
		Me.Controls.Add(dcPorIva)
		Me.Controls.Add(TipoComprobante)
		Me.Controls.Add(DatSustento)
		Me.Controls.Add(DtPorRetIR)
		Me.Controls.Add(f3)
		Me.Controls.Add(Label6)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label8)
		Me.Controls.Add(Label22)
		Me.Controls.Add(Label9)
		Me.Controls.Add(Label19)
		Me.Controls.Add(Label16)
		Me.Controls.Add(Label12)
		Me.Controls.Add(Label7)
		Me.Controls.Add(Label5)
		Me.Controls.Add(Label3)
		Me.Controls.Add(TxtMonIce)
		Me.Controls.Add(TxtMonIva)
		Me.Controls.Add(TxtMonIvaSer)
		Me.Controls.Add(Label48)
		Me.Controls.Add(TxtPorcIce)
		Me.Controls.Add(Label1)
		Me.Controls.Add(lbNomP)
		Me.Controls.Add(lbClioPro)
		Me.Controls.Add(Label40)
		Me.Controls.Add(Label49)
		Me.Controls.Add(Label14)
		Me.Controls.Add(Label4)
		Me.Frame3.Controls.Add(TxtBasImpIR)
		Me.Frame3.Controls.Add(TxtPorcRetIR)
		Me.Frame3.Controls.Add(CodRetFteImpRent)
		Me.Frame3.Controls.Add(Label33)
		Me.Frame3.Controls.Add(Label34)
		Me.Frame3.Controls.Add(Label35)
		Me.Frame3.Controls.Add(Label36)
		Me.Frame3.Controls.Add(TxtMonRetRen)
		Me.F2.Controls.Add(Command2)
		Me.F2.Controls.Add(btncancelar)
		Me.F2.Controls.Add(btngrabar)
		Me.f3.Controls.Add(btneliminar)
		Me.f3.Controls.Add(btnbuscar)
		Me.f3.Controls.Add(btnnuevo)
		Me.f3.Controls.Add(btnmodificar)
		Me.f3.Controls.Add(btnsalir)
		CType(Me.DatSustento, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.TipoComprobante, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.dcPorIva, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.DcPorICE, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.CodRetFteImpRent, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Frame3.ResumeLayout(False)
		Me.F2.ResumeLayout(False)
		Me.f3.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
#Region "Upgrade Support"
	Public Sub VB6_AddADODataBinding()
		ADOBind_DtPorRetIR = New VB6.MBindingCollection()
		ADOBind_dtCodSus = New VB6.MBindingCollection()
		ADOBind_dtCom = New VB6.MBindingCollection()
		ADOBind_dtPorIva = New VB6.MBindingCollection()
		ADOBind_DtPorRetIR.DataSource = CType(DtPorRetIR, msdatasrc.DataSource)
		ADOBind_dtCodSus.DataSource = CType(dtCodSus, msdatasrc.DataSource)
		ADOBind_dtCom.DataSource = CType(dtCom, msdatasrc.DataSource)
		ADOBind_dtPorIva.DataSource = CType(dtPorIva, msdatasrc.DataSource)
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