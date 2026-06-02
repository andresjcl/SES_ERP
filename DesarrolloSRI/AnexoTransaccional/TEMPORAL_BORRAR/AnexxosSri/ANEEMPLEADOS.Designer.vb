<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class ANEEMPLEADOS
#Region "Código generado por el Diseñador de Windows Forms "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'Llamada necesaria para el Diseñador de Windows Forms.
		InitializeComponent()
	End Sub
	'Form invalida a Dispose para limpiar la lista de componentes.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Requerido por el Diseñador de Windows Forms
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents txtValRet As System.Windows.Forms.TextBox
	Public WithEvents txtApoIes As System.Windows.Forms.TextBox
	Public WithEvents txtBasImp As System.Windows.Forms.TextBox
	Public WithEvents txtIngLiq As System.Windows.Forms.TextBox
	Public WithEvents txtNumRet As System.Windows.Forms.TextBox
	Public WithEvents txtCod As System.Windows.Forms.TextBox
	Public WithEvents btPro As System.Windows.Forms.Button
	Public WithEvents txtPro As System.Windows.Forms.TextBox
	Public WithEvents dtTipSal As VB6.ADODC
	Public WithEvents Label12 As System.Windows.Forms.Label
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents lbNomP As System.Windows.Forms.Label
	Public WithEvents lbClioPro As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents fprincipal As System.Windows.Forms.Panel
	Public WithEvents fprincipal1 As System.Windows.Forms.GroupBox
	Public WithEvents btInicio As System.Windows.Forms.Button
	Public WithEvents btUltimo As System.Windows.Forms.Button
	Public WithEvents btsiguiente As System.Windows.Forms.Button
	Public WithEvents btAnterior As System.Windows.Forms.Button
	Public WithEvents btnenviar As System.Windows.Forms.Button
	Public WithEvents btneliminar As System.Windows.Forms.Button
	Public WithEvents btnbuscar As System.Windows.Forms.Button
	Public WithEvents btnnuevo As System.Windows.Forms.Button
	Public WithEvents btnmodificar As System.Windows.Forms.Button
	Public WithEvents btnsalir As System.Windows.Forms.Button
	Public WithEvents f3 As System.Windows.Forms.GroupBox
	Public WithEvents btncancelar As System.Windows.Forms.Button
	Public WithEvents btngrabar As System.Windows.Forms.Button
	Public WithEvents F2 As System.Windows.Forms.GroupBox
	Public WithEvents btncancelarbusca As System.Windows.Forms.Button
	Public WithEvents f5 As System.Windows.Forms.GroupBox
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents f1 As System.Windows.Forms.GroupBox
	'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
	'Se puede modificar mediante el Diseñador de Windows Forms.
	'No lo modifique con el editor de código.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ANEEMPLEADOS))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.fprincipal1 = New System.Windows.Forms.GroupBox
		Me.fprincipal = New System.Windows.Forms.Panel
		Me.txtValRet = New System.Windows.Forms.TextBox
		Me.txtApoIes = New System.Windows.Forms.TextBox
		Me.txtBasImp = New System.Windows.Forms.TextBox
		Me.txtIngLiq = New System.Windows.Forms.TextBox
		Me.txtNumRet = New System.Windows.Forms.TextBox
		Me.txtCod = New System.Windows.Forms.TextBox
		Me.btPro = New System.Windows.Forms.Button
		Me.txtPro = New System.Windows.Forms.TextBox
		Me.dtTipSal = New VB6.ADODC
		Me.Label12 = New System.Windows.Forms.Label
		Me.Label10 = New System.Windows.Forms.Label
		Me.Label9 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.lbNomP = New System.Windows.Forms.Label
		Me.lbClioPro = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.f3 = New System.Windows.Forms.GroupBox
		Me.btInicio = New System.Windows.Forms.Button
		Me.btUltimo = New System.Windows.Forms.Button
		Me.btsiguiente = New System.Windows.Forms.Button
		Me.btAnterior = New System.Windows.Forms.Button
		Me.btnenviar = New System.Windows.Forms.Button
		Me.btneliminar = New System.Windows.Forms.Button
		Me.btnbuscar = New System.Windows.Forms.Button
		Me.btnnuevo = New System.Windows.Forms.Button
		Me.btnmodificar = New System.Windows.Forms.Button
		Me.btnsalir = New System.Windows.Forms.Button
		Me.F2 = New System.Windows.Forms.GroupBox
		Me.btncancelar = New System.Windows.Forms.Button
		Me.btngrabar = New System.Windows.Forms.Button
		Me.f5 = New System.Windows.Forms.GroupBox
		Me.btncancelarbusca = New System.Windows.Forms.Button
		Me.f1 = New System.Windows.Forms.GroupBox
		Me.Command1 = New System.Windows.Forms.Button
		Me.Command2 = New System.Windows.Forms.Button
		Me.fprincipal1.SuspendLayout()
		Me.fprincipal.SuspendLayout()
		Me.f3.SuspendLayout()
		Me.F2.SuspendLayout()
		Me.f5.SuspendLayout()
		Me.f1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.FromARGB(176, 196, 222)
		Me.Text = "Empleados"
		Me.ClientSize = New System.Drawing.Size(587, 257)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.Icon = CType(resources.GetObject("ANEEMPLEADOS.Icon"), System.Drawing.Icon)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
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
		Me.Name = "ANEEMPLEADOS"
		Me.fprincipal1.BackColor = System.Drawing.Color.FromARGB(176, 196, 222)
		Me.fprincipal1.Text = "Retención en relación de dependencia"
		Me.fprincipal1.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.fprincipal1.Size = New System.Drawing.Size(569, 185)
		Me.fprincipal1.Location = New System.Drawing.Point(8, 8)
		Me.fprincipal1.TabIndex = 25
		Me.fprincipal1.Enabled = True
		Me.fprincipal1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fprincipal1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fprincipal1.Visible = True
		Me.fprincipal1.Padding = New System.Windows.Forms.Padding(0)
		Me.fprincipal1.Name = "fprincipal1"
		Me.fprincipal.BackColor = System.Drawing.Color.FromARGB(176, 196, 222)
		Me.fprincipal.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.fprincipal.Font = New System.Drawing.Font("Times New Roman", 18!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.fprincipal.Size = New System.Drawing.Size(545, 145)
		Me.fprincipal.Location = New System.Drawing.Point(8, 32)
		Me.fprincipal.TabIndex = 26
		Me.fprincipal.Enabled = True
		Me.fprincipal.ForeColor = System.Drawing.SystemColors.ControlText
		Me.fprincipal.Cursor = System.Windows.Forms.Cursors.Default
		Me.fprincipal.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.fprincipal.Visible = True
		Me.fprincipal.Name = "fprincipal"
		Me.txtValRet.AutoSize = False
		Me.txtValRet.Size = New System.Drawing.Size(105, 19)
		Me.txtValRet.Location = New System.Drawing.Point(440, 112)
		Me.txtValRet.Maxlength = 12
		Me.txtValRet.TabIndex = 13
		Me.ToolTip1.SetToolTip(Me.txtValRet, "Valor retenido")
		Me.txtValRet.AcceptsReturn = True
		Me.txtValRet.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtValRet.BackColor = System.Drawing.SystemColors.Window
		Me.txtValRet.CausesValidation = True
		Me.txtValRet.Enabled = True
		Me.txtValRet.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtValRet.HideSelection = True
		Me.txtValRet.ReadOnly = False
		Me.txtValRet.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtValRet.MultiLine = False
		Me.txtValRet.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtValRet.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtValRet.TabStop = True
		Me.txtValRet.Visible = True
		Me.txtValRet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtValRet.Name = "txtValRet"
		Me.txtApoIes.AutoSize = False
		Me.txtApoIes.Size = New System.Drawing.Size(105, 19)
		Me.txtApoIes.Location = New System.Drawing.Point(440, 88)
		Me.txtApoIes.Maxlength = 15
		Me.txtApoIes.TabIndex = 9
		Me.ToolTip1.SetToolTip(Me.txtApoIes, "Aporte pagado al Iess")
		Me.txtApoIes.AcceptsReturn = True
		Me.txtApoIes.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtApoIes.BackColor = System.Drawing.SystemColors.Window
		Me.txtApoIes.CausesValidation = True
		Me.txtApoIes.Enabled = True
		Me.txtApoIes.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtApoIes.HideSelection = True
		Me.txtApoIes.ReadOnly = False
		Me.txtApoIes.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtApoIes.MultiLine = False
		Me.txtApoIes.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtApoIes.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtApoIes.TabStop = True
		Me.txtApoIes.Visible = True
		Me.txtApoIes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtApoIes.Name = "txtApoIes"
		Me.txtBasImp.AutoSize = False
		Me.txtBasImp.Size = New System.Drawing.Size(105, 19)
		Me.txtBasImp.Location = New System.Drawing.Point(136, 112)
		Me.txtBasImp.Maxlength = 15
		Me.txtBasImp.TabIndex = 11
		Me.ToolTip1.SetToolTip(Me.txtBasImp, "Base imponible para la retención")
		Me.txtBasImp.AcceptsReturn = True
		Me.txtBasImp.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtBasImp.BackColor = System.Drawing.SystemColors.Window
		Me.txtBasImp.CausesValidation = True
		Me.txtBasImp.Enabled = True
		Me.txtBasImp.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtBasImp.HideSelection = True
		Me.txtBasImp.ReadOnly = False
		Me.txtBasImp.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtBasImp.MultiLine = False
		Me.txtBasImp.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtBasImp.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtBasImp.TabStop = True
		Me.txtBasImp.Visible = True
		Me.txtBasImp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtBasImp.Name = "txtBasImp"
		Me.txtIngLiq.AutoSize = False
		Me.txtIngLiq.Size = New System.Drawing.Size(105, 19)
		Me.txtIngLiq.Location = New System.Drawing.Point(136, 88)
		Me.txtIngLiq.Maxlength = 12
		Me.txtIngLiq.TabIndex = 7
		Me.ToolTip1.SetToolTip(Me.txtIngLiq, "Total ingresos líquidos")
		Me.txtIngLiq.AcceptsReturn = True
		Me.txtIngLiq.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtIngLiq.BackColor = System.Drawing.SystemColors.Window
		Me.txtIngLiq.CausesValidation = True
		Me.txtIngLiq.Enabled = True
		Me.txtIngLiq.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtIngLiq.HideSelection = True
		Me.txtIngLiq.ReadOnly = False
		Me.txtIngLiq.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtIngLiq.MultiLine = False
		Me.txtIngLiq.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtIngLiq.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtIngLiq.TabStop = True
		Me.txtIngLiq.Visible = True
		Me.txtIngLiq.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtIngLiq.Name = "txtIngLiq"
		Me.txtNumRet.AutoSize = False
		Me.txtNumRet.Size = New System.Drawing.Size(57, 19)
		Me.txtNumRet.Location = New System.Drawing.Point(136, 64)
		Me.txtNumRet.Maxlength = 15
		Me.txtNumRet.TabIndex = 5
		Me.ToolTip1.SetToolTip(Me.txtNumRet, "Número de retenciones")
		Me.txtNumRet.AcceptsReturn = True
		Me.txtNumRet.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtNumRet.BackColor = System.Drawing.SystemColors.Window
		Me.txtNumRet.CausesValidation = True
		Me.txtNumRet.Enabled = True
		Me.txtNumRet.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtNumRet.HideSelection = True
		Me.txtNumRet.ReadOnly = False
		Me.txtNumRet.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNumRet.MultiLine = False
		Me.txtNumRet.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtNumRet.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtNumRet.TabStop = True
		Me.txtNumRet.Visible = True
		Me.txtNumRet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtNumRet.Name = "txtNumRet"
		Me.txtCod.AutoSize = False
		Me.txtCod.Size = New System.Drawing.Size(17, 19)
		Me.txtCod.Location = New System.Drawing.Point(232, 32)
		Me.txtCod.Maxlength = 12
		Me.txtCod.TabIndex = 32
		Me.txtCod.Visible = False
		Me.txtCod.AcceptsReturn = True
		Me.txtCod.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtCod.BackColor = System.Drawing.SystemColors.Window
		Me.txtCod.CausesValidation = True
		Me.txtCod.Enabled = True
		Me.txtCod.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtCod.HideSelection = True
		Me.txtCod.ReadOnly = False
		Me.txtCod.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCod.MultiLine = False
		Me.txtCod.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtCod.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtCod.TabStop = True
		Me.txtCod.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtCod.Name = "txtCod"
		Me.btPro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btPro.BackColor = System.Drawing.Color.FromARGB(225, 231, 247)
		Me.btPro.Text = ".."
		Me.btPro.Font = New System.Drawing.Font("Arial Black", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btPro.Size = New System.Drawing.Size(17, 17)
		Me.btPro.Location = New System.Drawing.Point(216, 32)
		Me.btPro.TabIndex = 2
		Me.ToolTip1.SetToolTip(Me.btPro, "Busqueda, creación de empleados")
		Me.btPro.CausesValidation = True
		Me.btPro.Enabled = True
		Me.btPro.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btPro.Cursor = System.Windows.Forms.Cursors.Default
		Me.btPro.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btPro.TabStop = True
		Me.btPro.Name = "btPro"
		Me.txtPro.AutoSize = False
		Me.txtPro.Size = New System.Drawing.Size(105, 19)
		Me.txtPro.Location = New System.Drawing.Point(112, 32)
		Me.txtPro.Maxlength = 13
		Me.txtPro.TabIndex = 1
		Me.ToolTip1.SetToolTip(Me.txtPro, "Número de cédula o pasaporte")
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
		Me.dtTipSal.Size = New System.Drawing.Size(80, 22)
		Me.dtTipSal.Location = New System.Drawing.Point(448, 0)
		Me.dtTipSal.Visible = 0
		Me.dtTipSal.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		Me.dtTipSal.ConnectionTimeout = 15
		Me.dtTipSal.CommandTimeout = 30
		Me.dtTipSal.CursorType = ADODB.CursorTypeEnum.adOpenStatic
		Me.dtTipSal.LockType = ADODB.LockTypeEnum.adLockOptimistic
		Me.dtTipSal.CommandType = ADODB.CommandTypeEnum.adCmdText
		Me.dtTipSal.CacheSize = 50
		Me.dtTipSal.MaxRecords = 0
		Me.dtTipSal.BOFAction = Microsoft.VisualBasic.Compatibility.VB6.ADODC.BOFActionEnum.adDoMoveFirst
		Me.dtTipSal.EOFAction = Microsoft.VisualBasic.Compatibility.VB6.ADODC.EOFActionEnum.adDoMoveLast
		Me.dtTipSal.BackColor = System.Drawing.SystemColors.Window
		Me.dtTipSal.ForeColor = System.Drawing.SystemColors.WindowText
		Me.dtTipSal.Orientation = Microsoft.VisualBasic.Compatibility.VB6.ADODC.OrientationEnum.adHorizontal
		Me.dtTipSal.Enabled = True
		Me.dtTipSal.UserName = ""
		Me.dtTipSal.RecordSource = ""
		Me.dtTipSal.Text = ""
		Me.dtTipSal.ConnectionString = ""
		Me.dtTipSal.Name = "dtTipSal"
		Me.Label12.Text = "Valor Retenido"
		Me.Label12.Size = New System.Drawing.Size(70, 13)
		Me.Label12.Location = New System.Drawing.Point(360, 120)
		Me.Label12.TabIndex = 12
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
		Me.Label10.Text = "Aporte al IESS Pagado por empleado"
		Me.Label10.Size = New System.Drawing.Size(176, 13)
		Me.Label10.Location = New System.Drawing.Point(256, 96)
		Me.Label10.TabIndex = 8
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
		Me.Label9.Text = "Base Imponible"
		Me.Label9.Size = New System.Drawing.Size(72, 13)
		Me.Label9.Location = New System.Drawing.Point(56, 120)
		Me.Label9.TabIndex = 10
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
		Me.Label4.Text = "Ingresos Líquidos Pagados"
		Me.Label4.Size = New System.Drawing.Size(129, 13)
		Me.Label4.Location = New System.Drawing.Point(0, 96)
		Me.Label4.TabIndex = 6
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
		Me.Label3.Text = "Número de Retenciónes"
		Me.Label3.Size = New System.Drawing.Size(115, 13)
		Me.Label3.Location = New System.Drawing.Point(16, 72)
		Me.Label3.TabIndex = 4
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
		Me.lbNomP.BackColor = System.Drawing.SystemColors.ControlLight
		Me.lbNomP.Text = "N&"
		Me.lbNomP.Size = New System.Drawing.Size(292, 17)
		Me.lbNomP.Location = New System.Drawing.Point(240, 32)
		Me.lbNomP.TabIndex = 3
		Me.lbNomP.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lbNomP.Enabled = True
		Me.lbNomP.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lbNomP.Cursor = System.Windows.Forms.Cursors.Default
		Me.lbNomP.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lbNomP.UseMnemonic = True
		Me.lbNomP.Visible = True
		Me.lbNomP.AutoSize = True
		Me.lbNomP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lbNomP.Name = "lbNomP"
		Me.lbClioPro.Text = "Cédula o Pasaporte"
		Me.lbClioPro.Size = New System.Drawing.Size(93, 13)
		Me.lbClioPro.Location = New System.Drawing.Point(8, 40)
		Me.lbClioPro.TabIndex = 0
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
		Me.Label5.Size = New System.Drawing.Size(4, 20)
		Me.Label5.Location = New System.Drawing.Point(488, 280)
		Me.Label5.TabIndex = 27
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
		Me.f3.BackColor = System.Drawing.Color.FromARGB(176, 196, 222)
		Me.f3.Size = New System.Drawing.Size(569, 57)
		Me.f3.Location = New System.Drawing.Point(8, 200)
		Me.f3.TabIndex = 28
		Me.f3.Enabled = True
		Me.f3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.f3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.f3.Visible = True
		Me.f3.Padding = New System.Windows.Forms.Padding(0)
		Me.f3.Name = "f3"
		Me.btInicio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btInicio.BackColor = System.Drawing.Color.FromARGB(225, 231, 247)
		Me.btInicio.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btInicio.Size = New System.Drawing.Size(34, 34)
		Me.btInicio.Location = New System.Drawing.Point(424, 12)
		Me.btInicio.TabIndex = 36
		Me.ToolTip1.SetToolTip(Me.btInicio, "Anterior registro")
		Me.btInicio.CausesValidation = True
		Me.btInicio.Enabled = True
		Me.btInicio.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btInicio.Cursor = System.Windows.Forms.Cursors.Default
		Me.btInicio.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btInicio.TabStop = True
		Me.btInicio.Name = "btInicio"
		Me.btUltimo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btUltimo.BackColor = System.Drawing.Color.FromARGB(225, 231, 247)
		Me.btUltimo.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btUltimo.Size = New System.Drawing.Size(34, 34)
		Me.btUltimo.Location = New System.Drawing.Point(524, 12)
		Me.btUltimo.TabIndex = 35
		Me.ToolTip1.SetToolTip(Me.btUltimo, "Ultimo registro")
		Me.btUltimo.CausesValidation = True
		Me.btUltimo.Enabled = True
		Me.btUltimo.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btUltimo.Cursor = System.Windows.Forms.Cursors.Default
		Me.btUltimo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btUltimo.TabStop = True
		Me.btUltimo.Name = "btUltimo"
		Me.btsiguiente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btsiguiente.BackColor = System.Drawing.Color.FromARGB(225, 231, 247)
		Me.btsiguiente.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btsiguiente.Size = New System.Drawing.Size(34, 34)
		Me.btsiguiente.Location = New System.Drawing.Point(490, 12)
		Me.btsiguiente.TabIndex = 34
		Me.ToolTip1.SetToolTip(Me.btsiguiente, "Siguiente registro")
		Me.btsiguiente.CausesValidation = True
		Me.btsiguiente.Enabled = True
		Me.btsiguiente.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btsiguiente.Cursor = System.Windows.Forms.Cursors.Default
		Me.btsiguiente.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btsiguiente.TabStop = True
		Me.btsiguiente.Name = "btsiguiente"
		Me.btAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btAnterior.BackColor = System.Drawing.Color.FromARGB(225, 231, 247)
		Me.btAnterior.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btAnterior.Size = New System.Drawing.Size(34, 34)
		Me.btAnterior.Location = New System.Drawing.Point(457, 12)
		Me.btAnterior.TabIndex = 33
		Me.ToolTip1.SetToolTip(Me.btAnterior, "Anterior registro")
		Me.btAnterior.CausesValidation = True
		Me.btAnterior.Enabled = True
		Me.btAnterior.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btAnterior.Cursor = System.Windows.Forms.Cursors.Default
		Me.btAnterior.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btAnterior.TabStop = True
		Me.btAnterior.Name = "btAnterior"
		Me.btnenviar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnenviar.BackColor = System.Drawing.Color.FromARGB(225, 231, 247)
		Me.btnenviar.Text = "En&viar"
		Me.btnenviar.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnenviar.Size = New System.Drawing.Size(54, 34)
		Me.btnenviar.Location = New System.Drawing.Point(232, 13)
		Me.btnenviar.TabIndex = 23
		Me.ToolTip1.SetToolTip(Me.btnenviar, "Imprimir registros")
		Me.btnenviar.CausesValidation = True
		Me.btnenviar.Enabled = True
		Me.btnenviar.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnenviar.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnenviar.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnenviar.TabStop = True
		Me.btnenviar.Name = "btnenviar"
		Me.btneliminar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btneliminar.BackColor = System.Drawing.Color.FromARGB(225, 231, 247)
		Me.btneliminar.Text = "&Eliminar"
		Me.btneliminar.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btneliminar.Size = New System.Drawing.Size(54, 34)
		Me.btneliminar.Location = New System.Drawing.Point(176, 13)
		Me.btneliminar.TabIndex = 22
		Me.ToolTip1.SetToolTip(Me.btneliminar, "Elimina un registro")
		Me.btneliminar.CausesValidation = True
		Me.btneliminar.Enabled = True
		Me.btneliminar.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btneliminar.Cursor = System.Windows.Forms.Cursors.Default
		Me.btneliminar.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btneliminar.TabStop = True
		Me.btneliminar.Name = "btneliminar"
		Me.btnbuscar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnbuscar.BackColor = System.Drawing.Color.FromARGB(225, 231, 247)
		Me.btnbuscar.Text = "&Buscar"
		Me.btnbuscar.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnbuscar.Size = New System.Drawing.Size(54, 34)
		Me.btnbuscar.Location = New System.Drawing.Point(120, 13)
		Me.btnbuscar.TabIndex = 21
		Me.ToolTip1.SetToolTip(Me.btnbuscar, "Busca un registro")
		Me.btnbuscar.CausesValidation = True
		Me.btnbuscar.Enabled = True
		Me.btnbuscar.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnbuscar.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnbuscar.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnbuscar.TabStop = True
		Me.btnbuscar.Name = "btnbuscar"
		Me.btnnuevo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnnuevo.BackColor = System.Drawing.Color.FromARGB(225, 231, 247)
		Me.btnnuevo.Text = "&Nuevo"
		Me.btnnuevo.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnnuevo.Size = New System.Drawing.Size(54, 34)
		Me.btnnuevo.Location = New System.Drawing.Point(64, 13)
		Me.btnnuevo.TabIndex = 20
		Me.ToolTip1.SetToolTip(Me.btnnuevo, "Nuevo registro")
		Me.btnnuevo.CausesValidation = True
		Me.btnnuevo.Enabled = True
		Me.btnnuevo.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnnuevo.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnnuevo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnnuevo.TabStop = True
		Me.btnnuevo.Name = "btnnuevo"
		Me.btnmodificar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnmodificar.BackColor = System.Drawing.Color.FromARGB(225, 231, 247)
		Me.btnmodificar.Text = "&Modificar"
		Me.btnmodificar.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnmodificar.Size = New System.Drawing.Size(54, 34)
		Me.btnmodificar.Location = New System.Drawing.Point(8, 13)
		Me.btnmodificar.TabIndex = 19
		Me.ToolTip1.SetToolTip(Me.btnmodificar, "Modifica el registro actual")
		Me.btnmodificar.CausesValidation = True
		Me.btnmodificar.Enabled = True
		Me.btnmodificar.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnmodificar.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnmodificar.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnmodificar.TabStop = True
		Me.btnmodificar.Name = "btnmodificar"
		Me.btnsalir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnsalir.BackColor = System.Drawing.Color.FromARGB(225, 231, 247)
		Me.btnsalir.Text = "&Salir"
		Me.btnsalir.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnsalir.Size = New System.Drawing.Size(54, 34)
		Me.btnsalir.Location = New System.Drawing.Point(288, 13)
		Me.btnsalir.TabIndex = 24
		Me.ToolTip1.SetToolTip(Me.btnsalir, "Regresa al menu principal")
		Me.btnsalir.CausesValidation = True
		Me.btnsalir.Enabled = True
		Me.btnsalir.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnsalir.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnsalir.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnsalir.TabStop = True
		Me.btnsalir.Name = "btnsalir"
		Me.F2.BackColor = System.Drawing.Color.FromARGB(176, 196, 222)
		Me.F2.Size = New System.Drawing.Size(129, 50)
		Me.F2.Location = New System.Drawing.Point(8, 200)
		Me.F2.TabIndex = 30
		Me.F2.Enabled = True
		Me.F2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.F2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.F2.Visible = True
		Me.F2.Padding = New System.Windows.Forms.Padding(0)
		Me.F2.Name = "F2"
		Me.btncancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btncancelar.BackColor = System.Drawing.SystemColors.Control
		Me.CancelButton = Me.btncancelar
		Me.btncancelar.Text = "&Cancelar"
		Me.btncancelar.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btncancelar.Size = New System.Drawing.Size(54, 34)
		Me.btncancelar.Location = New System.Drawing.Point(64, 13)
		Me.btncancelar.TabIndex = 15
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
		Me.btngrabar.TabIndex = 14
		Me.ToolTip1.SetToolTip(Me.btngrabar, "Graba el registro")
		Me.btngrabar.CausesValidation = True
		Me.btngrabar.Enabled = True
		Me.btngrabar.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btngrabar.Cursor = System.Windows.Forms.Cursors.Default
		Me.btngrabar.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btngrabar.TabStop = True
		Me.btngrabar.Name = "btngrabar"
		Me.f5.BackColor = System.Drawing.Color.FromARGB(176, 196, 222)
		Me.f5.Size = New System.Drawing.Size(73, 50)
		Me.f5.Location = New System.Drawing.Point(8, 200)
		Me.f5.TabIndex = 31
		Me.f5.Visible = False
		Me.f5.Enabled = True
		Me.f5.ForeColor = System.Drawing.SystemColors.ControlText
		Me.f5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.f5.Padding = New System.Windows.Forms.Padding(0)
		Me.f5.Name = "f5"
		Me.btncancelarbusca.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btncancelarbusca.BackColor = System.Drawing.Color.FromARGB(225, 231, 247)
		Me.btncancelarbusca.Text = "&Cancelar"
		Me.btncancelarbusca.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btncancelarbusca.Size = New System.Drawing.Size(54, 34)
		Me.btncancelarbusca.Location = New System.Drawing.Point(8, 13)
		Me.btncancelarbusca.TabIndex = 16
		Me.ToolTip1.SetToolTip(Me.btncancelarbusca, "Cancela acción")
		Me.btncancelarbusca.CausesValidation = True
		Me.btncancelarbusca.Enabled = True
		Me.btncancelarbusca.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btncancelarbusca.Cursor = System.Windows.Forms.Cursors.Default
		Me.btncancelarbusca.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btncancelarbusca.TabStop = True
		Me.btncancelarbusca.Name = "btncancelarbusca"
		Me.f1.BackColor = System.Drawing.Color.FromARGB(176, 196, 222)
		Me.f1.Size = New System.Drawing.Size(129, 50)
		Me.f1.Location = New System.Drawing.Point(8, 200)
		Me.f1.TabIndex = 29
		Me.f1.Visible = False
		Me.f1.Enabled = True
		Me.f1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.f1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.f1.Padding = New System.Windows.Forms.Padding(0)
		Me.f1.Name = "f1"
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.BackColor = System.Drawing.Color.FromARGB(225, 231, 247)
		Me.Command1.Text = "&Nuevo"
		Me.Command1.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Command1.Size = New System.Drawing.Size(54, 34)
		Me.Command1.Location = New System.Drawing.Point(8, 13)
		Me.Command1.TabIndex = 17
		Me.ToolTip1.SetToolTip(Me.Command1, "Nuevo registro")
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.TabStop = True
		Me.Command1.Name = "Command1"
		Me.Command2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command2.BackColor = System.Drawing.Color.FromARGB(225, 231, 247)
		Me.Command2.Text = "&Salir"
		Me.Command2.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Command2.Size = New System.Drawing.Size(54, 34)
		Me.Command2.Location = New System.Drawing.Point(64, 13)
		Me.Command2.TabIndex = 18
		Me.ToolTip1.SetToolTip(Me.Command2, "Regresa al menu principal")
		Me.Command2.CausesValidation = True
		Me.Command2.Enabled = True
		Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command2.TabStop = True
		Me.Command2.Name = "Command2"
		Me.Controls.Add(fprincipal1)
		Me.Controls.Add(f3)
		Me.Controls.Add(F2)
		Me.Controls.Add(f5)
		Me.Controls.Add(f1)
		Me.fprincipal1.Controls.Add(fprincipal)
		Me.fprincipal.Controls.Add(txtValRet)
		Me.fprincipal.Controls.Add(txtApoIes)
		Me.fprincipal.Controls.Add(txtBasImp)
		Me.fprincipal.Controls.Add(txtIngLiq)
		Me.fprincipal.Controls.Add(txtNumRet)
		Me.fprincipal.Controls.Add(txtCod)
		Me.fprincipal.Controls.Add(btPro)
		Me.fprincipal.Controls.Add(txtPro)
		Me.fprincipal.Controls.Add(dtTipSal)
		Me.fprincipal.Controls.Add(Label12)
		Me.fprincipal.Controls.Add(Label10)
		Me.fprincipal.Controls.Add(Label9)
		Me.fprincipal.Controls.Add(Label4)
		Me.fprincipal.Controls.Add(Label3)
		Me.fprincipal.Controls.Add(lbNomP)
		Me.fprincipal.Controls.Add(lbClioPro)
		Me.fprincipal.Controls.Add(Label5)
		Me.f3.Controls.Add(btInicio)
		Me.f3.Controls.Add(btUltimo)
		Me.f3.Controls.Add(btsiguiente)
		Me.f3.Controls.Add(btAnterior)
		Me.f3.Controls.Add(btnenviar)
		Me.f3.Controls.Add(btneliminar)
		Me.f3.Controls.Add(btnbuscar)
		Me.f3.Controls.Add(btnnuevo)
		Me.f3.Controls.Add(btnmodificar)
		Me.f3.Controls.Add(btnsalir)
		Me.F2.Controls.Add(btncancelar)
		Me.F2.Controls.Add(btngrabar)
		Me.f5.Controls.Add(btncancelarbusca)
		Me.f1.Controls.Add(Command1)
		Me.f1.Controls.Add(Command2)
		Me.fprincipal1.ResumeLayout(False)
		Me.fprincipal.ResumeLayout(False)
		Me.f3.ResumeLayout(False)
		Me.F2.ResumeLayout(False)
		Me.f5.ResumeLayout(False)
		Me.f1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class