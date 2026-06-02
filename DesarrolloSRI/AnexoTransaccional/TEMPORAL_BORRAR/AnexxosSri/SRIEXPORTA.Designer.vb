<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class SRIEXPORTA
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
	Private ADOBind_dtCom As VB6.MBindingCollection
	Public WithEvents malla As AxMSHierarchicalFlexGridLib.AxMSHFlexGrid
	Public WithEvents btngrabar As System.Windows.Forms.Button
	Public WithEvents btncancelar As System.Windows.Forms.Button
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents F2 As System.Windows.Forms.Panel
	Public WithEvents btnsalir As System.Windows.Forms.Button
	Public WithEvents btnmodificar As System.Windows.Forms.Button
	Public WithEvents btnnuevo As System.Windows.Forms.Button
	Public WithEvents btnbuscar As System.Windows.Forms.Button
	Public WithEvents f3 As System.Windows.Forms.Panel
	Public WithEvents TxtFue As System.Windows.Forms.TextBox
	Public WithEvents ConRefrendo As System.Windows.Forms.CheckBox
	Public WithEvents ValorDocumento As System.Windows.Forms.TextBox
	Public WithEvents NroAutorización As System.Windows.Forms.TextBox
	Public WithEvents txtFecEmiCom As System.Windows.Forms.TextBox
	Public WithEvents TxtSerEstablec As System.Windows.Forms.TextBox
	Public WithEvents txtNumSer As System.Windows.Forms.TextBox
	Public WithEvents txtNumSec As System.Windows.Forms.TextBox
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents TxtNroTransporte As System.Windows.Forms.TextBox
	Public WithEvents TxtAnio As System.Windows.Forms.TextBox
	Public WithEvents TxtDistritoAd As System.Windows.Forms.TextBox
	Public WithEvents TxtRegimen As System.Windows.Forms.TextBox
	Public WithEvents TxtCorrelativo As System.Windows.Forms.TextBox
	Public WithEvents TxtVerificador As System.Windows.Forms.TextBox
	Public WithEvents BtEmision As System.Windows.Forms.Button
	Public WithEvents txtFecLiquidacion As System.Windows.Forms.TextBox
	Public WithEvents TxtValCif As System.Windows.Forms.TextBox
	Public WithEvents dtCom As VB6.ADODC
	Public WithEvents DtTipoCliente As VB6.ADODC
	Public WithEvents TipoComprobante As AxMSDataListLib.AxDataCombo
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label11 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label15 As System.Windows.Forms.Label
	Public WithEvents Label24 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents lbClioPro As System.Windows.Forms.Label
	Public WithEvents Label40 As System.Windows.Forms.Label
	Public WithEvents Label14 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
	'Se puede modificar mediante el Diseñador de Windows Forms.
	'No lo modifique con el editor de código.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SRIEXPORTA))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.malla = New AxMSHierarchicalFlexGridLib.AxMSHFlexGrid
		Me.F2 = New System.Windows.Forms.Panel
		Me.btngrabar = New System.Windows.Forms.Button
		Me.btncancelar = New System.Windows.Forms.Button
		Me.Command2 = New System.Windows.Forms.Button
		Me.f3 = New System.Windows.Forms.Panel
		Me.btnsalir = New System.Windows.Forms.Button
		Me.btnmodificar = New System.Windows.Forms.Button
		Me.btnnuevo = New System.Windows.Forms.Button
		Me.btnbuscar = New System.Windows.Forms.Button
		Me.TxtFue = New System.Windows.Forms.TextBox
		Me.ConRefrendo = New System.Windows.Forms.CheckBox
		Me.ValorDocumento = New System.Windows.Forms.TextBox
		Me.NroAutorización = New System.Windows.Forms.TextBox
		Me.txtFecEmiCom = New System.Windows.Forms.TextBox
		Me.TxtSerEstablec = New System.Windows.Forms.TextBox
		Me.txtNumSer = New System.Windows.Forms.TextBox
		Me.txtNumSec = New System.Windows.Forms.TextBox
		Me.Command1 = New System.Windows.Forms.Button
		Me.TxtNroTransporte = New System.Windows.Forms.TextBox
		Me.TxtAnio = New System.Windows.Forms.TextBox
		Me.TxtDistritoAd = New System.Windows.Forms.TextBox
		Me.TxtRegimen = New System.Windows.Forms.TextBox
		Me.TxtCorrelativo = New System.Windows.Forms.TextBox
		Me.TxtVerificador = New System.Windows.Forms.TextBox
		Me.BtEmision = New System.Windows.Forms.Button
		Me.txtFecLiquidacion = New System.Windows.Forms.TextBox
		Me.TxtValCif = New System.Windows.Forms.TextBox
		Me.dtCom = New VB6.ADODC
		Me.DtTipoCliente = New VB6.ADODC
		Me.TipoComprobante = New AxMSDataListLib.AxDataCombo
		Me.Label10 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label8 = New System.Windows.Forms.Label
		Me.Label11 = New System.Windows.Forms.Label
		Me.Label9 = New System.Windows.Forms.Label
		Me.Label7 = New System.Windows.Forms.Label
		Me.Label6 = New System.Windows.Forms.Label
		Me.Label15 = New System.Windows.Forms.Label
		Me.Label24 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.lbClioPro = New System.Windows.Forms.Label
		Me.Label40 = New System.Windows.Forms.Label
		Me.Label14 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.F2.SuspendLayout()
		Me.f3.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.malla, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.TipoComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "EXPORTACIONES"
		Me.ClientSize = New System.Drawing.Size(481, 297)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.Icon = CType(resources.GetObject("SRIEXPORTA.Icon"), System.Drawing.Icon)
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
		Me.Name = "SRIEXPORTA"
		malla.OcxState = CType(resources.GetObject("malla.OcxState"), System.Windows.Forms.AxHost.State)
		Me.malla.Size = New System.Drawing.Size(41, 17)
		Me.malla.Location = New System.Drawing.Point(424, 88)
		Me.malla.TabIndex = 44
		Me.malla.Visible = False
		Me.malla.Name = "malla"
		Me.F2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.F2.Size = New System.Drawing.Size(177, 41)
		Me.F2.Location = New System.Drawing.Point(8, 240)
		Me.F2.TabIndex = 37
		Me.F2.BackColor = System.Drawing.SystemColors.Control
		Me.F2.Enabled = True
		Me.F2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.F2.Cursor = System.Windows.Forms.Cursors.Default
		Me.F2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.F2.Visible = True
		Me.F2.Name = "F2"
		Me.btngrabar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btngrabar.BackColor = System.Drawing.SystemColors.Control
		Me.btngrabar.Text = "&Grabar"
		Me.btngrabar.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btngrabar.Size = New System.Drawing.Size(54, 34)
		Me.btngrabar.Location = New System.Drawing.Point(8, 5)
		Me.btngrabar.TabIndex = 40
		Me.ToolTip1.SetToolTip(Me.btngrabar, "Graba el registro")
		Me.btngrabar.CausesValidation = True
		Me.btngrabar.Enabled = True
		Me.btngrabar.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btngrabar.Cursor = System.Windows.Forms.Cursors.Default
		Me.btngrabar.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btngrabar.TabStop = True
		Me.btngrabar.Name = "btngrabar"
		Me.btncancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btncancelar.BackColor = System.Drawing.SystemColors.Control
		Me.CancelButton = Me.btncancelar
		Me.btncancelar.Text = "&Cancelar"
		Me.btncancelar.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btncancelar.Size = New System.Drawing.Size(54, 34)
		Me.btncancelar.Location = New System.Drawing.Point(64, 5)
		Me.btncancelar.TabIndex = 39
		Me.ToolTip1.SetToolTip(Me.btncancelar, "Cancela acción")
		Me.btncancelar.CausesValidation = True
		Me.btncancelar.Enabled = True
		Me.btncancelar.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btncancelar.Cursor = System.Windows.Forms.Cursors.Default
		Me.btncancelar.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btncancelar.TabStop = True
		Me.btncancelar.Name = "btncancelar"
		Me.Command2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command2.BackColor = System.Drawing.SystemColors.Control
		Me.Command2.Text = "&Salir"
		Me.Command2.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Command2.Size = New System.Drawing.Size(54, 34)
		Me.Command2.Location = New System.Drawing.Point(120, 5)
		Me.Command2.TabIndex = 38
		Me.ToolTip1.SetToolTip(Me.Command2, "Regresa al menu principal")
		Me.Command2.CausesValidation = True
		Me.Command2.Enabled = True
		Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command2.TabStop = True
		Me.Command2.Name = "Command2"
		Me.f3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.f3.Size = New System.Drawing.Size(241, 41)
		Me.f3.Location = New System.Drawing.Point(8, 240)
		Me.f3.TabIndex = 36
		Me.f3.BackColor = System.Drawing.SystemColors.Control
		Me.f3.Enabled = True
		Me.f3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.f3.Cursor = System.Windows.Forms.Cursors.Default
		Me.f3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.f3.Visible = True
		Me.f3.Name = "f3"
		Me.btnsalir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnsalir.Text = "&Salir"
		Me.btnsalir.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnsalir.Size = New System.Drawing.Size(54, 34)
		Me.btnsalir.Location = New System.Drawing.Point(176, 5)
		Me.btnsalir.TabIndex = 35
		Me.ToolTip1.SetToolTip(Me.btnsalir, "Regresa al menu principal")
		Me.btnsalir.BackColor = System.Drawing.SystemColors.Control
		Me.btnsalir.CausesValidation = True
		Me.btnsalir.Enabled = True
		Me.btnsalir.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnsalir.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnsalir.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnsalir.TabStop = True
		Me.btnsalir.Name = "btnsalir"
		Me.btnmodificar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnmodificar.Text = "&Modificar"
		Me.btnmodificar.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnmodificar.Size = New System.Drawing.Size(54, 34)
		Me.btnmodificar.Location = New System.Drawing.Point(8, 5)
		Me.btnmodificar.TabIndex = 32
		Me.ToolTip1.SetToolTip(Me.btnmodificar, "Modifica el registro actual")
		Me.btnmodificar.BackColor = System.Drawing.SystemColors.Control
		Me.btnmodificar.CausesValidation = True
		Me.btnmodificar.Enabled = True
		Me.btnmodificar.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnmodificar.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnmodificar.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnmodificar.TabStop = True
		Me.btnmodificar.Name = "btnmodificar"
		Me.btnnuevo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnnuevo.Text = "&Nuevo"
		Me.btnnuevo.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnnuevo.Size = New System.Drawing.Size(54, 34)
		Me.btnnuevo.Location = New System.Drawing.Point(64, 5)
		Me.btnnuevo.TabIndex = 33
		Me.ToolTip1.SetToolTip(Me.btnnuevo, "Nuevo registro")
		Me.btnnuevo.BackColor = System.Drawing.SystemColors.Control
		Me.btnnuevo.CausesValidation = True
		Me.btnnuevo.Enabled = True
		Me.btnnuevo.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnnuevo.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnnuevo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnnuevo.TabStop = True
		Me.btnnuevo.Name = "btnnuevo"
		Me.btnbuscar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnbuscar.Text = "&Buscar"
		Me.btnbuscar.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnbuscar.Size = New System.Drawing.Size(54, 34)
		Me.btnbuscar.Location = New System.Drawing.Point(120, 5)
		Me.btnbuscar.TabIndex = 34
		Me.ToolTip1.SetToolTip(Me.btnbuscar, "Busca un registro")
		Me.btnbuscar.BackColor = System.Drawing.SystemColors.Control
		Me.btnbuscar.CausesValidation = True
		Me.btnbuscar.Enabled = True
		Me.btnbuscar.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnbuscar.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnbuscar.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnbuscar.TabStop = True
		Me.btnbuscar.Name = "btnbuscar"
		Me.TxtFue.AutoSize = False
		Me.TxtFue.Size = New System.Drawing.Size(89, 19)
		Me.TxtFue.Location = New System.Drawing.Point(72, 120)
		Me.TxtFue.Maxlength = 13
		Me.TxtFue.TabIndex = 42
		Me.ToolTip1.SetToolTip(Me.TxtFue, "Fecha de emisión del comprobante")
		Me.TxtFue.AcceptsReturn = True
		Me.TxtFue.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TxtFue.BackColor = System.Drawing.SystemColors.Window
		Me.TxtFue.CausesValidation = True
		Me.TxtFue.Enabled = True
		Me.TxtFue.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtFue.HideSelection = True
		Me.TxtFue.ReadOnly = False
		Me.TxtFue.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtFue.MultiLine = False
		Me.TxtFue.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtFue.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtFue.TabStop = True
		Me.TxtFue.Visible = True
		Me.TxtFue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtFue.Name = "TxtFue"
		Me.ConRefrendo.Text = "Exportación con Refrendo"
		Me.ConRefrendo.Size = New System.Drawing.Size(153, 17)
		Me.ConRefrendo.Location = New System.Drawing.Point(16, 8)
		Me.ConRefrendo.TabIndex = 41
		Me.ConRefrendo.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.ConRefrendo.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.ConRefrendo.BackColor = System.Drawing.SystemColors.Control
		Me.ConRefrendo.CausesValidation = True
		Me.ConRefrendo.Enabled = True
		Me.ConRefrendo.ForeColor = System.Drawing.SystemColors.ControlText
		Me.ConRefrendo.Cursor = System.Windows.Forms.Cursors.Default
		Me.ConRefrendo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ConRefrendo.Appearance = System.Windows.Forms.Appearance.Normal
		Me.ConRefrendo.TabStop = True
		Me.ConRefrendo.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.ConRefrendo.Visible = True
		Me.ConRefrendo.Name = "ConRefrendo"
		Me.ValorDocumento.AutoSize = False
		Me.ValorDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.ValorDocumento.Size = New System.Drawing.Size(105, 19)
		Me.ValorDocumento.Location = New System.Drawing.Point(256, 144)
		Me.ValorDocumento.Maxlength = 12
		Me.ValorDocumento.TabIndex = 3
		Me.ToolTip1.SetToolTip(Me.ValorDocumento, "Base imponible grabada")
		Me.ValorDocumento.AcceptsReturn = True
		Me.ValorDocumento.BackColor = System.Drawing.SystemColors.Window
		Me.ValorDocumento.CausesValidation = True
		Me.ValorDocumento.Enabled = True
		Me.ValorDocumento.ForeColor = System.Drawing.SystemColors.WindowText
		Me.ValorDocumento.HideSelection = True
		Me.ValorDocumento.ReadOnly = False
		Me.ValorDocumento.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.ValorDocumento.MultiLine = False
		Me.ValorDocumento.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ValorDocumento.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.ValorDocumento.TabStop = True
		Me.ValorDocumento.Visible = True
		Me.ValorDocumento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.ValorDocumento.Name = "ValorDocumento"
		Me.NroAutorización.AutoSize = False
		Me.NroAutorización.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.NroAutorización.Size = New System.Drawing.Size(177, 19)
		Me.NroAutorización.Location = New System.Drawing.Point(288, 8)
		Me.NroAutorización.Maxlength = 40
		Me.NroAutorización.TabIndex = 18
		Me.ToolTip1.SetToolTip(Me.NroAutorización, "Base imponible grabada")
		Me.NroAutorización.AcceptsReturn = True
		Me.NroAutorización.BackColor = System.Drawing.SystemColors.Window
		Me.NroAutorización.CausesValidation = True
		Me.NroAutorización.Enabled = True
		Me.NroAutorización.ForeColor = System.Drawing.SystemColors.WindowText
		Me.NroAutorización.HideSelection = True
		Me.NroAutorización.ReadOnly = False
		Me.NroAutorización.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.NroAutorización.MultiLine = False
		Me.NroAutorización.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.NroAutorización.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.NroAutorización.TabStop = True
		Me.NroAutorización.Visible = True
		Me.NroAutorización.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.NroAutorización.Name = "NroAutorización"
		Me.txtFecEmiCom.AutoSize = False
		Me.txtFecEmiCom.Size = New System.Drawing.Size(65, 19)
		Me.txtFecEmiCom.Location = New System.Drawing.Point(112, 208)
		Me.txtFecEmiCom.Maxlength = 10
		Me.txtFecEmiCom.TabIndex = 30
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
		Me.TxtSerEstablec.AutoSize = False
		Me.TxtSerEstablec.Size = New System.Drawing.Size(33, 19)
		Me.TxtSerEstablec.Location = New System.Drawing.Point(184, 176)
		Me.TxtSerEstablec.Maxlength = 3
		Me.TxtSerEstablec.TabIndex = 25
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
		Me.txtNumSer.Size = New System.Drawing.Size(33, 19)
		Me.txtNumSer.Location = New System.Drawing.Point(136, 176)
		Me.txtNumSer.Maxlength = 3
		Me.txtNumSer.TabIndex = 23
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
		Me.txtNumSec.Size = New System.Drawing.Size(73, 19)
		Me.txtNumSec.Location = New System.Drawing.Point(232, 176)
		Me.txtNumSec.Maxlength = 10
		Me.txtNumSec.TabIndex = 27
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
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.Command1.BackColor = System.Drawing.Color.FromARGB(224, 224, 224)
		Me.Command1.Size = New System.Drawing.Size(17, 19)
		Me.Command1.Location = New System.Drawing.Point(176, 208)
		Me.Command1.Image = CType(resources.GetObject("Command1.Image"), System.Drawing.Image)
		Me.Command1.TabIndex = 31
		Me.ToolTip1.SetToolTip(Me.Command1, "Escojer de una lista")
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.TabStop = True
		Me.Command1.Name = "Command1"
		Me.TxtNroTransporte.AutoSize = False
		Me.TxtNroTransporte.Size = New System.Drawing.Size(89, 19)
		Me.TxtNroTransporte.Location = New System.Drawing.Point(120, 88)
		Me.TxtNroTransporte.Maxlength = 13
		Me.TxtNroTransporte.TabIndex = 14
		Me.ToolTip1.SetToolTip(Me.TxtNroTransporte, "Fecha de emisión del comprobante")
		Me.TxtNroTransporte.AcceptsReturn = True
		Me.TxtNroTransporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TxtNroTransporte.BackColor = System.Drawing.SystemColors.Window
		Me.TxtNroTransporte.CausesValidation = True
		Me.TxtNroTransporte.Enabled = True
		Me.TxtNroTransporte.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtNroTransporte.HideSelection = True
		Me.TxtNroTransporte.ReadOnly = False
		Me.TxtNroTransporte.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtNroTransporte.MultiLine = False
		Me.TxtNroTransporte.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtNroTransporte.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtNroTransporte.TabStop = True
		Me.TxtNroTransporte.Visible = True
		Me.TxtNroTransporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtNroTransporte.Name = "TxtNroTransporte"
		Me.TxtAnio.AutoSize = False
		Me.TxtAnio.Size = New System.Drawing.Size(33, 19)
		Me.TxtAnio.Location = New System.Drawing.Point(128, 64)
		Me.TxtAnio.Maxlength = 4
		Me.TxtAnio.TabIndex = 6
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
		Me.TxtDistritoAd.Size = New System.Drawing.Size(25, 19)
		Me.TxtDistritoAd.Location = New System.Drawing.Point(96, 64)
		Me.TxtDistritoAd.Maxlength = 3
		Me.TxtDistritoAd.TabIndex = 5
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
		Me.TxtRegimen.Size = New System.Drawing.Size(25, 19)
		Me.TxtRegimen.Location = New System.Drawing.Point(168, 64)
		Me.TxtRegimen.Maxlength = 2
		Me.TxtRegimen.TabIndex = 7
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
		Me.TxtCorrelativo.Size = New System.Drawing.Size(60, 19)
		Me.TxtCorrelativo.Location = New System.Drawing.Point(200, 64)
		Me.TxtCorrelativo.Maxlength = 10
		Me.TxtCorrelativo.TabIndex = 8
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
		Me.TxtVerificador.Size = New System.Drawing.Size(13, 19)
		Me.TxtVerificador.Location = New System.Drawing.Point(264, 64)
		Me.TxtVerificador.Maxlength = 1
		Me.TxtVerificador.TabIndex = 9
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
		Me.BtEmision.Location = New System.Drawing.Point(384, 88)
		Me.BtEmision.Image = CType(resources.GetObject("BtEmision.Image"), System.Drawing.Image)
		Me.BtEmision.TabIndex = 12
		Me.ToolTip1.SetToolTip(Me.BtEmision, "Escojer de una lista")
		Me.BtEmision.CausesValidation = True
		Me.BtEmision.Enabled = True
		Me.BtEmision.ForeColor = System.Drawing.SystemColors.ControlText
		Me.BtEmision.Cursor = System.Windows.Forms.Cursors.Default
		Me.BtEmision.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.BtEmision.TabStop = True
		Me.BtEmision.Name = "BtEmision"
		Me.txtFecLiquidacion.AutoSize = False
		Me.txtFecLiquidacion.Size = New System.Drawing.Size(73, 19)
		Me.txtFecLiquidacion.Location = New System.Drawing.Point(312, 88)
		Me.txtFecLiquidacion.Maxlength = 10
		Me.txtFecLiquidacion.TabIndex = 11
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
		Me.TxtValCif.Location = New System.Drawing.Point(72, 144)
		Me.TxtValCif.Maxlength = 12
		Me.TxtValCif.TabIndex = 16
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
		Me.dtCom.Size = New System.Drawing.Size(80, 22)
		Me.dtCom.Location = New System.Drawing.Point(384, 120)
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
		Me.DtTipoCliente.Size = New System.Drawing.Size(80, 22)
		Me.DtTipoCliente.Location = New System.Drawing.Point(384, 144)
		Me.DtTipoCliente.Visible = 0
		Me.DtTipoCliente.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		Me.DtTipoCliente.ConnectionTimeout = 15
		Me.DtTipoCliente.CommandTimeout = 30
		Me.DtTipoCliente.CursorType = ADODB.CursorTypeEnum.adOpenStatic
		Me.DtTipoCliente.LockType = ADODB.LockTypeEnum.adLockOptimistic
		Me.DtTipoCliente.CommandType = ADODB.CommandTypeEnum.adCmdText
		Me.DtTipoCliente.CacheSize = 50
		Me.DtTipoCliente.MaxRecords = 0
		Me.DtTipoCliente.BOFAction = Microsoft.VisualBasic.Compatibility.VB6.ADODC.BOFActionEnum.adDoMoveFirst
		Me.DtTipoCliente.EOFAction = Microsoft.VisualBasic.Compatibility.VB6.ADODC.EOFActionEnum.adDoMoveLast
		Me.DtTipoCliente.BackColor = System.Drawing.SystemColors.Window
		Me.DtTipoCliente.ForeColor = System.Drawing.SystemColors.WindowText
		Me.DtTipoCliente.Orientation = Microsoft.VisualBasic.Compatibility.VB6.ADODC.OrientationEnum.adHorizontal
		Me.DtTipoCliente.Enabled = True
		Me.DtTipoCliente.UserName = ""
		Me.DtTipoCliente.RecordSource = ""
		Me.DtTipoCliente.Text = ""
		Me.DtTipoCliente.ConnectionString = ""
		Me.DtTipoCliente.Name = "DtTipoCliente"
		TipoComprobante.OcxState = CType(resources.GetObject("TipoComprobante.OcxState"), System.Windows.Forms.AxHost.State)
		Me.TipoComprobante.Size = New System.Drawing.Size(329, 21)
		Me.TipoComprobante.Location = New System.Drawing.Point(128, 32)
		Me.TipoComprobante.TabIndex = 1
		Me.TipoComprobante.Name = "TipoComprobante"
		Me.Label10.Text = "Nro.FUE"
		Me.Label10.Size = New System.Drawing.Size(41, 13)
		Me.Label10.Location = New System.Drawing.Point(16, 128)
		Me.Label10.TabIndex = 43
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
		Me.Label3.Text = "&Tipo de Comprobante"
		Me.Label3.Size = New System.Drawing.Size(102, 13)
		Me.Label3.Location = New System.Drawing.Point(16, 40)
		Me.Label3.TabIndex = 0
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
		Me.Label8.Text = "Valor Documento"
		Me.Label8.Size = New System.Drawing.Size(82, 13)
		Me.Label8.Location = New System.Drawing.Point(168, 152)
		Me.Label8.TabIndex = 2
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
		Me.Label11.Text = "Factura de exportación"
		Me.Label11.Size = New System.Drawing.Size(121, 17)
		Me.Label11.Location = New System.Drawing.Point(16, 184)
		Me.Label11.TabIndex = 21
		Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label11.BackColor = System.Drawing.SystemColors.Control
		Me.Label11.Enabled = True
		Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label11.UseMnemonic = True
		Me.Label11.Visible = True
		Me.Label11.AutoSize = False
		Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label11.Name = "Label11"
		Me.Label9.Text = "Autorización"
		Me.Label9.Size = New System.Drawing.Size(58, 13)
		Me.Label9.Location = New System.Drawing.Point(224, 8)
		Me.Label9.TabIndex = 17
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
		Me.Label7.Text = "&Fecha EmisiónFact."
		Me.Label7.Size = New System.Drawing.Size(93, 13)
		Me.Label7.Location = New System.Drawing.Point(16, 216)
		Me.Label7.TabIndex = 28
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
		Me.Label6.Text = "dd/mm/aaaa"
		Me.Label6.Enabled = False
		Me.Label6.ForeColor = System.Drawing.Color.FromARGB(128, 128, 128)
		Me.Label6.Size = New System.Drawing.Size(52, 13)
		Me.Label6.Location = New System.Drawing.Point(120, 224)
		Me.Label6.TabIndex = 29
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label6.BackColor = System.Drawing.Color.Transparent
		Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label6.UseMnemonic = True
		Me.Label6.Visible = True
		Me.Label6.AutoSize = True
		Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label6.Name = "Label6"
		Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label15.BackColor = System.Drawing.Color.Transparent
		Me.Label15.Text = "Nro Secuencial"
		Me.Label15.ForeColor = System.Drawing.Color.FromARGB(128, 128, 128)
		Me.Label15.Size = New System.Drawing.Size(64, 13)
		Me.Label15.Location = New System.Drawing.Point(232, 192)
		Me.Label15.TabIndex = 26
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
		Me.Label24.Location = New System.Drawing.Point(176, 192)
		Me.Label24.TabIndex = 24
		Me.Label24.Enabled = True
		Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label24.UseMnemonic = True
		Me.Label24.Visible = True
		Me.Label24.AutoSize = True
		Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label24.Name = "Label24"
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label5.BackColor = System.Drawing.Color.Transparent
		Me.Label5.Text = "Estblcmto"
		Me.Label5.ForeColor = System.Drawing.Color.FromARGB(128, 128, 128)
		Me.Label5.Size = New System.Drawing.Size(42, 13)
		Me.Label5.Location = New System.Drawing.Point(128, 192)
		Me.Label5.TabIndex = 22
		Me.Label5.Enabled = True
		Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label5.UseMnemonic = True
		Me.Label5.Visible = True
		Me.Label5.AutoSize = True
		Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label5.Name = "Label5"
		Me.Label2.Text = "&Tipo de Cliente"
		Me.Label2.Size = New System.Drawing.Size(71, 9)
		Me.Label2.Location = New System.Drawing.Point(8, 248)
		Me.Label2.TabIndex = 20
		Me.Label2.Visible = False
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.Color.Transparent
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.AutoSize = True
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label1.Text = "Nro.Doc.Transporte"
		Me.Label1.Size = New System.Drawing.Size(94, 13)
		Me.Label1.Location = New System.Drawing.Point(16, 96)
		Me.Label1.TabIndex = 13
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
		Me.lbClioPro.Text = "&Identificación del Cliente"
		Me.lbClioPro.Size = New System.Drawing.Size(115, 13)
		Me.lbClioPro.Location = New System.Drawing.Point(8, 248)
		Me.lbClioPro.TabIndex = 19
		Me.lbClioPro.Visible = False
		Me.lbClioPro.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbClioPro.BackColor = System.Drawing.Color.Transparent
		Me.lbClioPro.Enabled = True
		Me.lbClioPro.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lbClioPro.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbClioPro.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbClioPro.UseMnemonic = True
		Me.lbClioPro.AutoSize = True
		Me.lbClioPro.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lbClioPro.Name = "lbClioPro"
		Me.Label40.Text = "Nro.Referendo"
		Me.Label40.Size = New System.Drawing.Size(70, 13)
		Me.Label40.Location = New System.Drawing.Point(16, 72)
		Me.Label40.TabIndex = 4
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
		Me.Label14.Text = "&Fecha Transacción"
		Me.Label14.Size = New System.Drawing.Size(92, 13)
		Me.Label14.Location = New System.Drawing.Point(216, 96)
		Me.Label14.TabIndex = 10
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
		Me.Label4.Text = "Valor FOB"
		Me.Label4.Size = New System.Drawing.Size(48, 13)
		Me.Label4.Location = New System.Drawing.Point(16, 152)
		Me.Label4.TabIndex = 15
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
		Me.Controls.Add(malla)
		Me.Controls.Add(F2)
		Me.Controls.Add(f3)
		Me.Controls.Add(TxtFue)
		Me.Controls.Add(ConRefrendo)
		Me.Controls.Add(ValorDocumento)
		Me.Controls.Add(NroAutorización)
		Me.Controls.Add(txtFecEmiCom)
		Me.Controls.Add(TxtSerEstablec)
		Me.Controls.Add(txtNumSer)
		Me.Controls.Add(txtNumSec)
		Me.Controls.Add(Command1)
		Me.Controls.Add(TxtNroTransporte)
		Me.Controls.Add(TxtAnio)
		Me.Controls.Add(TxtDistritoAd)
		Me.Controls.Add(TxtRegimen)
		Me.Controls.Add(TxtCorrelativo)
		Me.Controls.Add(TxtVerificador)
		Me.Controls.Add(BtEmision)
		Me.Controls.Add(txtFecLiquidacion)
		Me.Controls.Add(TxtValCif)
		Me.Controls.Add(dtCom)
		Me.Controls.Add(DtTipoCliente)
		Me.Controls.Add(TipoComprobante)
		Me.Controls.Add(Label10)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label8)
		Me.Controls.Add(Label11)
		Me.Controls.Add(Label9)
		Me.Controls.Add(Label7)
		Me.Controls.Add(Label6)
		Me.Controls.Add(Label15)
		Me.Controls.Add(Label24)
		Me.Controls.Add(Label5)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
		Me.Controls.Add(lbClioPro)
		Me.Controls.Add(Label40)
		Me.Controls.Add(Label14)
		Me.Controls.Add(Label4)
		Me.F2.Controls.Add(btngrabar)
		Me.F2.Controls.Add(btncancelar)
		Me.F2.Controls.Add(Command2)
		Me.f3.Controls.Add(btnsalir)
		Me.f3.Controls.Add(btnmodificar)
		Me.f3.Controls.Add(btnnuevo)
		Me.f3.Controls.Add(btnbuscar)
		CType(Me.TipoComprobante, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.malla, System.ComponentModel.ISupportInitialize).EndInit()
		Me.F2.ResumeLayout(False)
		Me.f3.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
#Region "Upgrade Support"
	Public Sub VB6_AddADODataBinding()
		ADOBind_dtCom = New VB6.MBindingCollection()
		ADOBind_dtCom.DataSource = CType(dtCom, msdatasrc.DataSource)
		ADOBind_dtCom.UpdateMode = VB6.UpdateMode.vbUpdateWhenPropertyChanges
		ADOBind_dtCom.UpdateControls()
	End Sub
	Public Sub VB6_RemoveADODataBinding()
		ADOBind_dtCom.Clear()
		ADOBind_dtCom.Dispose()
		ADOBind_dtCom = Nothing
	End Sub
#End Region 
End Class