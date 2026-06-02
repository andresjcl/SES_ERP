<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class SRIVENTAS
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
	Private ADOBind_dtPorIvaBie As VB6.MBindingCollection
	Private ADOBind_DtPorIvaServ As VB6.MBindingCollection
	Private ADOBind_dtCom As VB6.MBindingCollection
	Private ADOBind_dtPorIva As VB6.MBindingCollection
	Public WithEvents BtEmision As System.Windows.Forms.Button
	Public WithEvents txtFecEmiCom As System.Windows.Forms.TextBox
	Public WithEvents CantCpbtes As System.Windows.Forms.TextBox
	Public WithEvents txtFecRegCont As System.Windows.Forms.TextBox
	Public WithEvents BtContable As System.Windows.Forms.Button
	Public WithEvents IvaPresunt As System.Windows.Forms.CheckBox
	Public WithEvents txtBasImpGra As System.Windows.Forms.TextBox
	Public WithEvents TxtBasImpICE As System.Windows.Forms.TextBox
	Public WithEvents txtMonIvaBie As System.Windows.Forms.TextBox
	Public WithEvents txtBasImpTar0 As System.Windows.Forms.TextBox
	Public WithEvents txtPro As System.Windows.Forms.TextBox
	Public WithEvents btpro As System.Windows.Forms.Button
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
	Public WithEvents _Check1_0 As System.Windows.Forms.CheckBox
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
	Public WithEvents DcPorICE As AxMSDataListLib.AxDataCombo
	Public WithEvents DtPorIvaServ As VB6.ADODC
	Public WithEvents dtCom As VB6.ADODC
	Public WithEvents dtPorIva As VB6.ADODC
	Public WithEvents DtPorICE As VB6.ADODC
	Public WithEvents dtPorIvaBie As VB6.ADODC
	Public WithEvents dcPorIva As AxMSDataListLib.AxDataCombo
	Public WithEvents DtPorRetIR As VB6.ADODC
	Public WithEvents TipoComprobante As AxMSDataListLib.AxDataCombo
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label13 As System.Windows.Forms.Label
	Public WithEvents Label25 As System.Windows.Forms.Label
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label22 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label19 As System.Windows.Forms.Label
	Public WithEvents Label16 As System.Windows.Forms.Label
	Public WithEvents Label12 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents lbClioPro As System.Windows.Forms.Label
	Public WithEvents lbNomP As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents TxtMonIce As System.Windows.Forms.Label
	Public WithEvents TxtMonIva As System.Windows.Forms.Label
	Public WithEvents TxtMonIvaSer As System.Windows.Forms.Label
	Public WithEvents Label48 As System.Windows.Forms.Label
	Public WithEvents TxtPorcIce As System.Windows.Forms.Label
	Public WithEvents fprincipal As System.Windows.Forms.Panel
	Public WithEvents btneliminar As System.Windows.Forms.Button
	Public WithEvents btnbuscar As System.Windows.Forms.Button
	Public WithEvents btnnuevo As System.Windows.Forms.Button
	Public WithEvents btnmodificar As System.Windows.Forms.Button
	Public WithEvents btnsalir As System.Windows.Forms.Button
	Public WithEvents f3 As System.Windows.Forms.Panel
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents btncancelar As System.Windows.Forms.Button
	Public WithEvents btngrabar As System.Windows.Forms.Button
	Public WithEvents F2 As System.Windows.Forms.Panel
	Public WithEvents Check1 As Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray
	Public WithEvents CodRetFteImpRent As AxDataComboArray
	Public WithEvents TxtBasImpIR As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	Public WithEvents TxtMonRetRen As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents TxtPorcRetIR As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
	'Se puede modificar mediante el Diseñador de Windows Forms.
	'No lo modifique con el editor de código.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SRIVENTAS))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.fprincipal = New System.Windows.Forms.Panel
		Me.BtEmision = New System.Windows.Forms.Button
		Me.txtFecEmiCom = New System.Windows.Forms.TextBox
		Me.CantCpbtes = New System.Windows.Forms.TextBox
		Me.txtFecRegCont = New System.Windows.Forms.TextBox
		Me.BtContable = New System.Windows.Forms.Button
		Me.IvaPresunt = New System.Windows.Forms.CheckBox
		Me.txtBasImpGra = New System.Windows.Forms.TextBox
		Me.TxtBasImpICE = New System.Windows.Forms.TextBox
		Me.txtMonIvaBie = New System.Windows.Forms.TextBox
		Me.txtBasImpTar0 = New System.Windows.Forms.TextBox
		Me.txtPro = New System.Windows.Forms.TextBox
		Me.btpro = New System.Windows.Forms.Button
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
		Me._Check1_0 = New System.Windows.Forms.CheckBox
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
		Me.DcPorICE = New AxMSDataListLib.AxDataCombo
		Me.DtPorIvaServ = New VB6.ADODC
		Me.dtCom = New VB6.ADODC
		Me.dtPorIva = New VB6.ADODC
		Me.DtPorICE = New VB6.ADODC
		Me.dtPorIvaBie = New VB6.ADODC
		Me.dcPorIva = New AxMSDataListLib.AxDataCombo
		Me.DtPorRetIR = New VB6.ADODC
		Me.TipoComprobante = New AxMSDataListLib.AxDataCombo
		Me.Label1 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label13 = New System.Windows.Forms.Label
		Me.Label25 = New System.Windows.Forms.Label
		Me.Label10 = New System.Windows.Forms.Label
		Me.Label6 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label8 = New System.Windows.Forms.Label
		Me.Label22 = New System.Windows.Forms.Label
		Me.Label9 = New System.Windows.Forms.Label
		Me.Label19 = New System.Windows.Forms.Label
		Me.Label16 = New System.Windows.Forms.Label
		Me.Label12 = New System.Windows.Forms.Label
		Me.Label7 = New System.Windows.Forms.Label
		Me.lbClioPro = New System.Windows.Forms.Label
		Me.lbNomP = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.TxtMonIce = New System.Windows.Forms.Label
		Me.TxtMonIva = New System.Windows.Forms.Label
		Me.TxtMonIvaSer = New System.Windows.Forms.Label
		Me.Label48 = New System.Windows.Forms.Label
		Me.TxtPorcIce = New System.Windows.Forms.Label
		Me.f3 = New System.Windows.Forms.Panel
		Me.btneliminar = New System.Windows.Forms.Button
		Me.btnbuscar = New System.Windows.Forms.Button
		Me.btnnuevo = New System.Windows.Forms.Button
		Me.btnmodificar = New System.Windows.Forms.Button
		Me.btnsalir = New System.Windows.Forms.Button
		Me.F2 = New System.Windows.Forms.Panel
		Me.Command2 = New System.Windows.Forms.Button
		Me.btncancelar = New System.Windows.Forms.Button
		Me.btngrabar = New System.Windows.Forms.Button
		Me.Check1 = New Microsoft.VisualBasic.Compatibility.VB6.CheckBoxArray(components)
		Me.CodRetFteImpRent = New AxDataComboArray(components)
		Me.TxtBasImpIR = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		Me.TxtMonRetRen = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.TxtPorcRetIR = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		Me.fprincipal.SuspendLayout()
		Me.Frame4.SuspendLayout()
		Me.Frame3.SuspendLayout()
		Me.f3.SuspendLayout()
		Me.F2.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.DcPorIvaServ, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dcPorIvaBie, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me._CodRetFteImpRent_0, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me._CodRetFteImpRent_1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.DcPorICE, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dcPorIva, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.TipoComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Check1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.CodRetFteImpRent, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.TxtBasImpIR, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.TxtMonRetRen, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.TxtPorcRetIR, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "VENTAS"
		Me.ClientSize = New System.Drawing.Size(749, 437)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.Icon = CType(resources.GetObject("SRIVENTAS.Icon"), System.Drawing.Icon)
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
		Me.Name = "SRIVENTAS"
		Me.fprincipal.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.fprincipal.Font = New System.Drawing.Font("Times New Roman", 18!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.fprincipal.ForeColor = System.Drawing.SystemColors.WindowText
		Me.fprincipal.Size = New System.Drawing.Size(745, 385)
		Me.fprincipal.Location = New System.Drawing.Point(0, 0)
		Me.fprincipal.TabIndex = 54
		Me.fprincipal.BackColor = System.Drawing.SystemColors.Control
		Me.fprincipal.Enabled = True
		Me.fprincipal.Cursor = System.Windows.Forms.Cursors.Default
		Me.fprincipal.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fprincipal.Visible = True
		Me.fprincipal.Name = "fprincipal"
		Me.BtEmision.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.BtEmision.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.BtEmision.Size = New System.Drawing.Size(17, 19)
		Me.BtEmision.Location = New System.Drawing.Point(240, 88)
		Me.BtEmision.Image = CType(resources.GetObject("BtEmision.Image"), System.Drawing.Image)
		Me.BtEmision.TabIndex = 69
		Me.ToolTip1.SetToolTip(Me.BtEmision, "Escojer de una lista")
		Me.BtEmision.CausesValidation = True
		Me.BtEmision.Enabled = True
		Me.BtEmision.ForeColor = System.Drawing.SystemColors.ControlText
		Me.BtEmision.Cursor = System.Windows.Forms.Cursors.Default
		Me.BtEmision.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.BtEmision.TabStop = True
		Me.BtEmision.Name = "BtEmision"
		Me.txtFecEmiCom.AutoSize = False
		Me.txtFecEmiCom.Size = New System.Drawing.Size(65, 19)
		Me.txtFecEmiCom.Location = New System.Drawing.Point(176, 88)
		Me.txtFecEmiCom.Maxlength = 10
		Me.txtFecEmiCom.TabIndex = 68
		Me.ToolTip1.SetToolTip(Me.txtFecEmiCom, "Fecha de registro contable")
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
		Me.CantCpbtes.AutoSize = False
		Me.CantCpbtes.Size = New System.Drawing.Size(57, 19)
		Me.CantCpbtes.Location = New System.Drawing.Point(648, 80)
		Me.CantCpbtes.Maxlength = 12
		Me.CantCpbtes.TabIndex = 60
		Me.ToolTip1.SetToolTip(Me.CantCpbtes, "Fecha de emisión del comprobante")
		Me.CantCpbtes.AcceptsReturn = True
		Me.CantCpbtes.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.CantCpbtes.BackColor = System.Drawing.SystemColors.Window
		Me.CantCpbtes.CausesValidation = True
		Me.CantCpbtes.Enabled = True
		Me.CantCpbtes.ForeColor = System.Drawing.SystemColors.WindowText
		Me.CantCpbtes.HideSelection = True
		Me.CantCpbtes.ReadOnly = False
		Me.CantCpbtes.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.CantCpbtes.MultiLine = False
		Me.CantCpbtes.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CantCpbtes.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.CantCpbtes.TabStop = True
		Me.CantCpbtes.Visible = True
		Me.CantCpbtes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.CantCpbtes.Name = "CantCpbtes"
		Me.txtFecRegCont.AutoSize = False
		Me.txtFecRegCont.Size = New System.Drawing.Size(65, 19)
		Me.txtFecRegCont.Location = New System.Drawing.Point(448, 80)
		Me.txtFecRegCont.Maxlength = 10
		Me.txtFecRegCont.TabIndex = 2
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
		Me.BtContable.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.BtContable.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.BtContable.Size = New System.Drawing.Size(17, 19)
		Me.BtContable.Location = New System.Drawing.Point(512, 80)
		Me.BtContable.Image = CType(resources.GetObject("BtContable.Image"), System.Drawing.Image)
		Me.BtContable.TabIndex = 3
		Me.ToolTip1.SetToolTip(Me.BtContable, "Escojer de una lista")
		Me.BtContable.CausesValidation = True
		Me.BtContable.Enabled = True
		Me.BtContable.ForeColor = System.Drawing.SystemColors.ControlText
		Me.BtContable.Cursor = System.Windows.Forms.Cursors.Default
		Me.BtContable.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.BtContable.TabStop = True
		Me.BtContable.Name = "BtContable"
		Me.IvaPresunt.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.IvaPresunt.Text = "IvaPresuntivo"
		Me.IvaPresunt.Size = New System.Drawing.Size(97, 17)
		Me.IvaPresunt.Location = New System.Drawing.Point(624, 152)
		Me.IvaPresunt.TabIndex = 18
		Me.IvaPresunt.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.IvaPresunt.BackColor = System.Drawing.SystemColors.Control
		Me.IvaPresunt.CausesValidation = True
		Me.IvaPresunt.Enabled = True
		Me.IvaPresunt.ForeColor = System.Drawing.SystemColors.ControlText
		Me.IvaPresunt.Cursor = System.Windows.Forms.Cursors.Default
		Me.IvaPresunt.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.IvaPresunt.Appearance = System.Windows.Forms.Appearance.Normal
		Me.IvaPresunt.TabStop = True
		Me.IvaPresunt.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.IvaPresunt.Visible = True
		Me.IvaPresunt.Name = "IvaPresunt"
		Me.txtBasImpGra.AutoSize = False
		Me.txtBasImpGra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtBasImpGra.Size = New System.Drawing.Size(89, 19)
		Me.txtBasImpGra.Location = New System.Drawing.Point(368, 152)
		Me.txtBasImpGra.Maxlength = 12
		Me.txtBasImpGra.TabIndex = 15
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
		Me.TxtBasImpICE.AutoSize = False
		Me.TxtBasImpICE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.TxtBasImpICE.Size = New System.Drawing.Size(89, 19)
		Me.TxtBasImpICE.Location = New System.Drawing.Point(352, 120)
		Me.TxtBasImpICE.Maxlength = 12
		Me.TxtBasImpICE.TabIndex = 7
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
		Me.txtMonIvaBie.Size = New System.Drawing.Size(89, 19)
		Me.txtMonIvaBie.Location = New System.Drawing.Point(376, 184)
		Me.txtMonIvaBie.Maxlength = 12
		Me.txtMonIvaBie.TabIndex = 22
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
		Me.txtBasImpTar0.AutoSize = False
		Me.txtBasImpTar0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtBasImpTar0.Size = New System.Drawing.Size(89, 19)
		Me.txtBasImpTar0.Location = New System.Drawing.Point(128, 152)
		Me.txtBasImpTar0.Maxlength = 12
		Me.txtBasImpTar0.TabIndex = 13
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
		Me.txtPro.AutoSize = False
		Me.txtPro.Size = New System.Drawing.Size(105, 19)
		Me.txtPro.Location = New System.Drawing.Point(136, 24)
		Me.txtPro.Maxlength = 13
		Me.txtPro.TabIndex = 56
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
		Me.btpro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.btpro.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.btpro.Size = New System.Drawing.Size(17, 19)
		Me.btpro.Location = New System.Drawing.Point(240, 24)
		Me.btpro.Image = CType(resources.GetObject("btpro.Image"), System.Drawing.Image)
		Me.btpro.TabIndex = 55
		Me.ToolTip1.SetToolTip(Me.btpro, "Escojer de una lista")
		Me.btpro.CausesValidation = True
		Me.btpro.Enabled = True
		Me.btpro.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btpro.Cursor = System.Windows.Forms.Cursors.Default
		Me.btpro.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btpro.TabStop = True
		Me.btpro.Name = "btpro"
		Me.Frame4.Text = "RETENCION AL IVA"
		Me.Frame4.Size = New System.Drawing.Size(721, 73)
		Me.Frame4.Location = New System.Drawing.Point(8, 208)
		Me.Frame4.TabIndex = 25
		Me.Frame4.BackColor = System.Drawing.SystemColors.Control
		Me.Frame4.Enabled = True
		Me.Frame4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame4.Visible = True
		Me.Frame4.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame4.Name = "Frame4"
		DcPorIvaServ.OcxState = CType(resources.GetObject("DcPorIvaServ.OcxState"), System.Windows.Forms.AxHost.State)
		Me.DcPorIvaServ.Size = New System.Drawing.Size(65, 21)
		Me.DcPorIvaServ.Location = New System.Drawing.Point(192, 40)
		Me.DcPorIvaServ.TabIndex = 31
		Me.DcPorIvaServ.Name = "DcPorIvaServ"
		dcPorIvaBie.OcxState = CType(resources.GetObject("dcPorIvaBie.OcxState"), System.Windows.Forms.AxHost.State)
		Me.dcPorIvaBie.Size = New System.Drawing.Size(65, 21)
		Me.dcPorIvaBie.Location = New System.Drawing.Point(192, 16)
		Me.dcPorIvaBie.TabIndex = 27
		Me.dcPorIvaBie.Name = "dcPorIvaBie"
		Me.TxtMonRetSer.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.TxtMonRetSer.BackColor = System.Drawing.Color.White
		Me.TxtMonRetSer.Size = New System.Drawing.Size(102, 19)
		Me.TxtMonRetSer.Location = New System.Drawing.Point(424, 40)
		Me.TxtMonRetSer.TabIndex = 33
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
		Me.TxtMonRetBie.Size = New System.Drawing.Size(102, 19)
		Me.TxtMonRetBie.Location = New System.Drawing.Point(424, 16)
		Me.TxtMonRetBie.TabIndex = 29
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
		Me.Label17.Location = New System.Drawing.Point(288, 48)
		Me.Label17.TabIndex = 32
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
		Me.Label18.Location = New System.Drawing.Point(16, 48)
		Me.Label18.TabIndex = 30
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
		Me.Label20.Location = New System.Drawing.Point(288, 24)
		Me.Label20.TabIndex = 28
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
		Me.Label21.Location = New System.Drawing.Point(16, 24)
		Me.Label21.TabIndex = 26
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
		Me.Frame3.Text = "RETENCION EN LA FUENTE"
		Me.Frame3.Size = New System.Drawing.Size(721, 89)
		Me.Frame3.Location = New System.Drawing.Point(8, 288)
		Me.Frame3.TabIndex = 34
		Me.Frame3.BackColor = System.Drawing.SystemColors.Control
		Me.Frame3.Enabled = True
		Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame3.Visible = True
		Me.Frame3.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame3.Name = "Frame3"
		Me._TxtBasImpIR_1.AutoSize = False
		Me._TxtBasImpIR_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._TxtBasImpIR_1.Size = New System.Drawing.Size(89, 19)
		Me._TxtBasImpIR_1.Location = New System.Drawing.Point(328, 56)
		Me._TxtBasImpIR_1.Maxlength = 12
		Me._TxtBasImpIR_1.TabIndex = 65
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
		Me._TxtPorcRetIR_1.Size = New System.Drawing.Size(65, 19)
		Me._TxtPorcRetIR_1.Location = New System.Drawing.Point(416, 56)
		Me._TxtPorcRetIR_1.Maxlength = 7
		Me._TxtPorcRetIR_1.TabIndex = 64
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
		Me._Check1_0.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
		Me._Check1_0.Text = "Ret. presuntiva"
		Me._Check1_0.Size = New System.Drawing.Size(113, 25)
		Me._Check1_0.Location = New System.Drawing.Point(592, 24)
		Me._Check1_0.TabIndex = 37
		Me._Check1_0.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me._Check1_0.BackColor = System.Drawing.SystemColors.Control
		Me._Check1_0.CausesValidation = True
		Me._Check1_0.Enabled = True
		Me._Check1_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Check1_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._Check1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Check1_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._Check1_0.TabStop = True
		Me._Check1_0.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me._Check1_0.Visible = True
		Me._Check1_0.Name = "_Check1_0"
		Me._TxtPorcRetIR_0.AutoSize = False
		Me._TxtPorcRetIR_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._TxtPorcRetIR_0.Size = New System.Drawing.Size(65, 19)
		Me._TxtPorcRetIR_0.Location = New System.Drawing.Point(416, 32)
		Me._TxtPorcRetIR_0.Maxlength = 7
		Me._TxtPorcRetIR_0.TabIndex = 41
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
		Me._TxtBasImpIR_0.Size = New System.Drawing.Size(89, 19)
		Me._TxtBasImpIR_0.Location = New System.Drawing.Point(328, 32)
		Me._TxtBasImpIR_0.Maxlength = 12
		Me._TxtBasImpIR_0.TabIndex = 39
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
		Me._CodRetFteImpRent_0.Size = New System.Drawing.Size(321, 21)
		Me._CodRetFteImpRent_0.Location = New System.Drawing.Point(8, 32)
		Me._CodRetFteImpRent_0.TabIndex = 36
		Me._CodRetFteImpRent_0.Name = "_CodRetFteImpRent_0"
		_CodRetFteImpRent_1.OcxState = CType(resources.GetObject("_CodRetFteImpRent_1.OcxState"), System.Windows.Forms.AxHost.State)
		Me._CodRetFteImpRent_1.Size = New System.Drawing.Size(321, 21)
		Me._CodRetFteImpRent_1.Location = New System.Drawing.Point(8, 56)
		Me._CodRetFteImpRent_1.TabIndex = 66
		Me._CodRetFteImpRent_1.Name = "_CodRetFteImpRent_1"
		Me._TxtMonRetRen_1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me._TxtMonRetRen_1.BackColor = System.Drawing.Color.White
		Me._TxtMonRetRen_1.Size = New System.Drawing.Size(102, 19)
		Me._TxtMonRetRen_1.Location = New System.Drawing.Point(480, 56)
		Me._TxtMonRetRen_1.TabIndex = 67
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
		Me._TxtMonRetRen_0.Location = New System.Drawing.Point(480, 32)
		Me._TxtMonRetRen_0.TabIndex = 43
		Me._TxtMonRetRen_0.Enabled = True
		Me._TxtMonRetRen_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._TxtMonRetRen_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._TxtMonRetRen_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._TxtMonRetRen_0.UseMnemonic = True
		Me._TxtMonRetRen_0.Visible = True
		Me._TxtMonRetRen_0.AutoSize = False
		Me._TxtMonRetRen_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._TxtMonRetRen_0.Name = "_TxtMonRetRen_0"
		Me.Label36.Text = "Concepto"
		Me.Label36.Size = New System.Drawing.Size(46, 13)
		Me.Label36.Location = New System.Drawing.Point(88, 16)
		Me.Label36.TabIndex = 35
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
		Me.Label35.Location = New System.Drawing.Point(536, 16)
		Me.Label35.TabIndex = 42
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
		Me.Label34.Text = "Porcentaje"
		Me.Label34.Size = New System.Drawing.Size(51, 13)
		Me.Label34.Location = New System.Drawing.Point(440, 16)
		Me.Label34.TabIndex = 40
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
		Me.Label33.Text = "Base Imponible"
		Me.Label33.Size = New System.Drawing.Size(72, 13)
		Me.Label33.Location = New System.Drawing.Point(352, 16)
		Me.Label33.TabIndex = 38
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
		DcPorICE.OcxState = CType(resources.GetObject("DcPorICE.OcxState"), System.Windows.Forms.AxHost.State)
		Me.DcPorICE.Size = New System.Drawing.Size(177, 21)
		Me.DcPorICE.Location = New System.Drawing.Point(88, 120)
		Me.DcPorICE.TabIndex = 5
		Me.DcPorICE.Name = "DcPorICE"
		Me.DtPorIvaServ.Size = New System.Drawing.Size(80, 22)
		Me.DtPorIvaServ.Location = New System.Drawing.Point(272, 0)
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
		Me.dtCom.Location = New System.Drawing.Point(360, 0)
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
		Me.dtPorIva.Location = New System.Drawing.Point(8, 0)
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
		Me.DtPorICE.Location = New System.Drawing.Point(184, 0)
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
		Me.dtPorIvaBie.Location = New System.Drawing.Point(96, 0)
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
		Me.dcPorIva.Size = New System.Drawing.Size(57, 21)
		Me.dcPorIva.Location = New System.Drawing.Point(552, 152)
		Me.dcPorIva.TabIndex = 17
		Me.dcPorIva.Name = "dcPorIva"
		Me.DtPorRetIR.Size = New System.Drawing.Size(80, 22)
		Me.DtPorRetIR.Location = New System.Drawing.Point(544, 0)
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
		TipoComprobante.OcxState = CType(resources.GetObject("TipoComprobante.OcxState"), System.Windows.Forms.AxHost.State)
		Me.TipoComprobante.Size = New System.Drawing.Size(361, 21)
		Me.TipoComprobante.Location = New System.Drawing.Point(120, 56)
		Me.TipoComprobante.TabIndex = 61
		Me.TipoComprobante.Name = "TipoComprobante"
		Me.Label1.Text = "F&echa Emision de Comprobantes"
		Me.Label1.Size = New System.Drawing.Size(155, 13)
		Me.Label1.Location = New System.Drawing.Point(16, 96)
		Me.Label1.TabIndex = 70
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
		Me.Label3.Text = "&Tipo de Comprobante"
		Me.Label3.Size = New System.Drawing.Size(102, 13)
		Me.Label3.Location = New System.Drawing.Point(8, 64)
		Me.Label3.TabIndex = 63
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
		Me.Label13.Text = "Cantidad de comprobantes"
		Me.Label13.Size = New System.Drawing.Size(71, 29)
		Me.Label13.Location = New System.Drawing.Point(568, 80)
		Me.Label13.TabIndex = 62
		Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label13.BackColor = System.Drawing.Color.Transparent
		Me.Label13.Enabled = True
		Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label13.UseMnemonic = True
		Me.Label13.Visible = True
		Me.Label13.AutoSize = False
		Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label13.Name = "Label13"
		Me.Label25.Text = "dd/mm/aaaa"
		Me.Label25.Enabled = False
		Me.Label25.ForeColor = System.Drawing.Color.FromARGB(128, 128, 128)
		Me.Label25.Size = New System.Drawing.Size(52, 13)
		Me.Label25.Location = New System.Drawing.Point(488, 104)
		Me.Label25.TabIndex = 1
		Me.Label25.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label25.BackColor = System.Drawing.Color.Transparent
		Me.Label25.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label25.UseMnemonic = True
		Me.Label25.Visible = True
		Me.Label25.AutoSize = True
		Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label25.Name = "Label25"
		Me.Label10.Text = "F&echa  Registro Contable"
		Me.Label10.Size = New System.Drawing.Size(120, 13)
		Me.Label10.Location = New System.Drawing.Point(320, 88)
		Me.Label10.TabIndex = 0
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
		Me.Label6.Text = "Base Imponible Grabada IVA"
		Me.Label6.Size = New System.Drawing.Size(136, 13)
		Me.Label6.Location = New System.Drawing.Point(224, 160)
		Me.Label6.TabIndex = 14
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
		Me.Label2.Text = "Porcentaje  IVA"
		Me.Label2.Size = New System.Drawing.Size(74, 13)
		Me.Label2.Location = New System.Drawing.Point(472, 160)
		Me.Label2.TabIndex = 16
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
		Me.Label8.Text = "Monto  IVA Base Imponible"
		Me.Label8.Size = New System.Drawing.Size(128, 13)
		Me.Label8.Location = New System.Drawing.Point(8, 192)
		Me.Label8.TabIndex = 19
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
		Me.Label22.Text = "Base Imponible"
		Me.Label22.Size = New System.Drawing.Size(72, 13)
		Me.Label22.Location = New System.Drawing.Point(272, 128)
		Me.Label22.TabIndex = 6
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
		Me.Label9.Location = New System.Drawing.Point(16, 128)
		Me.Label9.TabIndex = 59
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
		Me.Label19.Size = New System.Drawing.Size(85, 13)
		Me.Label19.Location = New System.Drawing.Point(280, 192)
		Me.Label19.TabIndex = 21
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
		Me.Label16.Text = "Monto IVA Servicios"
		Me.Label16.Size = New System.Drawing.Size(96, 13)
		Me.Label16.Location = New System.Drawing.Point(496, 192)
		Me.Label16.TabIndex = 23
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
		Me.Label12.Text = "Monto  ICE"
		Me.Label12.Size = New System.Drawing.Size(53, 13)
		Me.Label12.Location = New System.Drawing.Point(560, 128)
		Me.Label12.TabIndex = 10
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
		Me.Label7.Size = New System.Drawing.Size(113, 13)
		Me.Label7.Location = New System.Drawing.Point(8, 160)
		Me.Label7.TabIndex = 12
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
		Me.lbClioPro.Text = "&Identificación del Cliente"
		Me.lbClioPro.Size = New System.Drawing.Size(115, 13)
		Me.lbClioPro.Location = New System.Drawing.Point(8, 32)
		Me.lbClioPro.TabIndex = 4
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
		Me.lbNomP.BackColor = System.Drawing.Color.White
		Me.lbNomP.Size = New System.Drawing.Size(342, 19)
		Me.lbNomP.Location = New System.Drawing.Point(264, 24)
		Me.lbNomP.TabIndex = 58
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
		Me.Label5.Size = New System.Drawing.Size(4, 20)
		Me.Label5.Location = New System.Drawing.Point(488, 120)
		Me.Label5.TabIndex = 57
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
		Me.TxtMonIce.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.TxtMonIce.BackColor = System.Drawing.Color.White
		Me.TxtMonIce.Size = New System.Drawing.Size(102, 19)
		Me.TxtMonIce.Location = New System.Drawing.Point(624, 120)
		Me.TxtMonIce.TabIndex = 11
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
		Me.TxtMonIva.BackColor = System.Drawing.Color.White
		Me.TxtMonIva.Size = New System.Drawing.Size(102, 19)
		Me.TxtMonIva.Location = New System.Drawing.Point(144, 184)
		Me.TxtMonIva.TabIndex = 20
		Me.TxtMonIva.Enabled = True
		Me.TxtMonIva.ForeColor = System.Drawing.SystemColors.ControlText
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
		Me.TxtMonIvaSer.Location = New System.Drawing.Point(600, 184)
		Me.TxtMonIvaSer.TabIndex = 24
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
		Me.Label48.Location = New System.Drawing.Point(456, 128)
		Me.Label48.TabIndex = 8
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
		Me.TxtPorcIce.Location = New System.Drawing.Point(488, 120)
		Me.TxtPorcIce.TabIndex = 9
		Me.TxtPorcIce.Enabled = True
		Me.TxtPorcIce.ForeColor = System.Drawing.SystemColors.ControlText
		Me.TxtPorcIce.Cursor = System.Windows.Forms.Cursors.Default
		Me.TxtPorcIce.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtPorcIce.UseMnemonic = True
		Me.TxtPorcIce.Visible = True
		Me.TxtPorcIce.AutoSize = False
		Me.TxtPorcIce.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtPorcIce.Name = "TxtPorcIce"
		Me.f3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.f3.Size = New System.Drawing.Size(297, 50)
		Me.f3.Location = New System.Drawing.Point(8, 384)
		Me.f3.TabIndex = 52
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
		Me.btneliminar.Location = New System.Drawing.Point(176, 5)
		Me.btneliminar.TabIndex = 47
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
		Me.btnbuscar.Location = New System.Drawing.Point(120, 5)
		Me.btnbuscar.TabIndex = 46
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
		Me.btnnuevo.Location = New System.Drawing.Point(64, 5)
		Me.btnnuevo.TabIndex = 45
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
		Me.btnmodificar.Location = New System.Drawing.Point(8, 5)
		Me.btnmodificar.TabIndex = 44
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
		Me.btnsalir.Location = New System.Drawing.Point(232, 5)
		Me.btnsalir.TabIndex = 48
		Me.ToolTip1.SetToolTip(Me.btnsalir, "Regresa al menu principal")
		Me.btnsalir.BackColor = System.Drawing.SystemColors.Control
		Me.btnsalir.CausesValidation = True
		Me.btnsalir.Enabled = True
		Me.btnsalir.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnsalir.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnsalir.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnsalir.TabStop = True
		Me.btnsalir.Name = "btnsalir"
		Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.F2.Size = New System.Drawing.Size(177, 50)
		Me.F2.Location = New System.Drawing.Point(8, 384)
		Me.F2.TabIndex = 53
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
		Me.Command2.Location = New System.Drawing.Point(120, 5)
		Me.Command2.TabIndex = 51
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
		Me.btncancelar.Location = New System.Drawing.Point(64, 5)
		Me.btncancelar.TabIndex = 50
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
		Me.btngrabar.Location = New System.Drawing.Point(8, 5)
		Me.btngrabar.TabIndex = 49
		Me.ToolTip1.SetToolTip(Me.btngrabar, "Graba el registro")
		Me.btngrabar.BackColor = System.Drawing.SystemColors.Control
		Me.btngrabar.CausesValidation = True
		Me.btngrabar.Enabled = True
		Me.btngrabar.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btngrabar.Cursor = System.Windows.Forms.Cursors.Default
		Me.btngrabar.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btngrabar.TabStop = True
		Me.btngrabar.Name = "btngrabar"
		Me.Controls.Add(fprincipal)
		Me.Controls.Add(f3)
		Me.Controls.Add(F2)
		Me.fprincipal.Controls.Add(BtEmision)
		Me.fprincipal.Controls.Add(txtFecEmiCom)
		Me.fprincipal.Controls.Add(CantCpbtes)
		Me.fprincipal.Controls.Add(txtFecRegCont)
		Me.fprincipal.Controls.Add(BtContable)
		Me.fprincipal.Controls.Add(IvaPresunt)
		Me.fprincipal.Controls.Add(txtBasImpGra)
		Me.fprincipal.Controls.Add(TxtBasImpICE)
		Me.fprincipal.Controls.Add(txtMonIvaBie)
		Me.fprincipal.Controls.Add(txtBasImpTar0)
		Me.fprincipal.Controls.Add(txtPro)
		Me.fprincipal.Controls.Add(btpro)
		Me.fprincipal.Controls.Add(Frame4)
		Me.fprincipal.Controls.Add(Frame3)
		Me.fprincipal.Controls.Add(DcPorICE)
		Me.fprincipal.Controls.Add(DtPorIvaServ)
		Me.fprincipal.Controls.Add(dtCom)
		Me.fprincipal.Controls.Add(dtPorIva)
		Me.fprincipal.Controls.Add(DtPorICE)
		Me.fprincipal.Controls.Add(dtPorIvaBie)
		Me.fprincipal.Controls.Add(dcPorIva)
		Me.fprincipal.Controls.Add(DtPorRetIR)
		Me.fprincipal.Controls.Add(TipoComprobante)
		Me.fprincipal.Controls.Add(Label1)
		Me.fprincipal.Controls.Add(Label3)
		Me.fprincipal.Controls.Add(Label13)
		Me.fprincipal.Controls.Add(Label25)
		Me.fprincipal.Controls.Add(Label10)
		Me.fprincipal.Controls.Add(Label6)
		Me.fprincipal.Controls.Add(Label2)
		Me.fprincipal.Controls.Add(Label8)
		Me.fprincipal.Controls.Add(Label22)
		Me.fprincipal.Controls.Add(Label9)
		Me.fprincipal.Controls.Add(Label19)
		Me.fprincipal.Controls.Add(Label16)
		Me.fprincipal.Controls.Add(Label12)
		Me.fprincipal.Controls.Add(Label7)
		Me.fprincipal.Controls.Add(lbClioPro)
		Me.fprincipal.Controls.Add(lbNomP)
		Me.fprincipal.Controls.Add(Label5)
		Me.fprincipal.Controls.Add(TxtMonIce)
		Me.fprincipal.Controls.Add(TxtMonIva)
		Me.fprincipal.Controls.Add(TxtMonIvaSer)
		Me.fprincipal.Controls.Add(Label48)
		Me.fprincipal.Controls.Add(TxtPorcIce)
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
		Me.Frame3.Controls.Add(_Check1_0)
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
		Me.f3.Controls.Add(btneliminar)
		Me.f3.Controls.Add(btnbuscar)
		Me.f3.Controls.Add(btnnuevo)
		Me.f3.Controls.Add(btnmodificar)
		Me.f3.Controls.Add(btnsalir)
		Me.F2.Controls.Add(Command2)
		Me.F2.Controls.Add(btncancelar)
		Me.F2.Controls.Add(btngrabar)
		Me.Check1.SetIndex(_Check1_0, CType(0, Short))
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
		CType(Me.Check1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.TipoComprobante, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.dcPorIva, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.DcPorICE, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me._CodRetFteImpRent_1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me._CodRetFteImpRent_0, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.dcPorIvaBie, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.DcPorIvaServ, System.ComponentModel.ISupportInitialize).EndInit()
		Me.fprincipal.ResumeLayout(False)
		Me.Frame4.ResumeLayout(False)
		Me.Frame3.ResumeLayout(False)
		Me.f3.ResumeLayout(False)
		Me.F2.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
#Region "Upgrade Support"
	Public Sub VB6_AddADODataBinding()
		ADOBind_DtPorRetIR = New VB6.MBindingCollection()
		ADOBind_dtPorIvaBie = New VB6.MBindingCollection()
		ADOBind_DtPorIvaServ = New VB6.MBindingCollection()
		ADOBind_dtCom = New VB6.MBindingCollection()
		ADOBind_dtPorIva = New VB6.MBindingCollection()
		ADOBind_DtPorRetIR.DataSource = CType(DtPorRetIR, msdatasrc.DataSource)
		ADOBind_dtPorIvaBie.DataSource = CType(dtPorIvaBie, msdatasrc.DataSource)
		ADOBind_DtPorIvaServ.DataSource = CType(DtPorIvaServ, msdatasrc.DataSource)
		ADOBind_dtCom.DataSource = CType(dtCom, msdatasrc.DataSource)
		ADOBind_dtPorIva.DataSource = CType(dtPorIva, msdatasrc.DataSource)
		ADOBind_DtPorRetIR.UpdateMode = VB6.UpdateMode.vbUpdateWhenPropertyChanges
		ADOBind_DtPorRetIR.UpdateControls()
		ADOBind_dtPorIvaBie.UpdateMode = VB6.UpdateMode.vbUpdateWhenPropertyChanges
		ADOBind_dtPorIvaBie.UpdateControls()
		ADOBind_DtPorIvaServ.UpdateMode = VB6.UpdateMode.vbUpdateWhenPropertyChanges
		ADOBind_DtPorIvaServ.UpdateControls()
		ADOBind_dtCom.UpdateMode = VB6.UpdateMode.vbUpdateWhenPropertyChanges
		ADOBind_dtCom.UpdateControls()
		ADOBind_dtPorIva.UpdateMode = VB6.UpdateMode.vbUpdateWhenPropertyChanges
		ADOBind_dtPorIva.UpdateControls()
	End Sub
	Public Sub VB6_RemoveADODataBinding()
		ADOBind_DtPorRetIR.Clear()
		ADOBind_DtPorRetIR.Dispose()
		ADOBind_DtPorRetIR = Nothing
		ADOBind_dtPorIvaBie.Clear()
		ADOBind_dtPorIvaBie.Dispose()
		ADOBind_dtPorIvaBie = Nothing
		ADOBind_DtPorIvaServ.Clear()
		ADOBind_DtPorIvaServ.Dispose()
		ADOBind_DtPorIvaServ = Nothing
		ADOBind_dtCom.Clear()
		ADOBind_dtCom.Dispose()
		ADOBind_dtCom = Nothing
		ADOBind_dtPorIva.Clear()
		ADOBind_dtPorIva.Dispose()
		ADOBind_dtPorIva = Nothing
	End Sub
#End Region 
End Class