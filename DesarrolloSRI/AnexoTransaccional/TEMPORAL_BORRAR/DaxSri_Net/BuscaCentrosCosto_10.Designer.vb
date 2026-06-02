<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class BuscaCentrosCosto
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
	Public WithEvents btncancelarbusca As System.Windows.Forms.Button
	Public WithEvents btAceptar As System.Windows.Forms.Button
	Public WithEvents btNuevo As System.Windows.Forms.Button
	Public WithEvents ListNombre As AxMSHierarchicalFlexGridLib.AxMSHFlexGrid
	Public WithEvents Optcodigo As System.Windows.Forms.RadioButton
	Public WithEvents OptNombre As System.Windows.Forms.RadioButton
	Public WithEvents TxtNombre As System.Windows.Forms.TextBox
	Public WithEvents TextCodigo As System.Windows.Forms.TextBox
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
	'Se puede modificar mediante el Diseñador de Windows Forms.
	'No lo modifique con el editor de código.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(BuscaCentrosCosto))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.btncancelarbusca = New System.Windows.Forms.Button
		Me.btAceptar = New System.Windows.Forms.Button
		Me.btNuevo = New System.Windows.Forms.Button
		Me.ListNombre = New AxMSHierarchicalFlexGridLib.AxMSHFlexGrid
		Me.Optcodigo = New System.Windows.Forms.RadioButton
		Me.OptNombre = New System.Windows.Forms.RadioButton
		Me.TxtNombre = New System.Windows.Forms.TextBox
		Me.TextCodigo = New System.Windows.Forms.TextBox
		Me.Label1 = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.ListNombre, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.Text = "Buscar Centro de costo"
		Me.ClientSize = New System.Drawing.Size(438, 431)
		Me.Location = New System.Drawing.Point(3, 29)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "BuscaCentrosCosto"
		Me.btncancelarbusca.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btncancelarbusca.Text = "&Cancelar"
		Me.btncancelarbusca.Size = New System.Drawing.Size(61, 25)
		Me.btncancelarbusca.Location = New System.Drawing.Point(72, 400)
		Me.btncancelarbusca.TabIndex = 8
		Me.ToolTip1.SetToolTip(Me.btncancelarbusca, "Elija para ingresar un nuevo nivel")
		Me.btncancelarbusca.BackColor = System.Drawing.SystemColors.Control
		Me.btncancelarbusca.CausesValidation = True
		Me.btncancelarbusca.Enabled = True
		Me.btncancelarbusca.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btncancelarbusca.Cursor = System.Windows.Forms.Cursors.Default
		Me.btncancelarbusca.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btncancelarbusca.TabStop = True
		Me.btncancelarbusca.Name = "btncancelarbusca"
		Me.btAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btAceptar.Text = "&Aceptar"
		Me.btAceptar.Size = New System.Drawing.Size(61, 25)
		Me.btAceptar.Location = New System.Drawing.Point(8, 400)
		Me.btAceptar.TabIndex = 7
		Me.ToolTip1.SetToolTip(Me.btAceptar, "Elija para ingresar un nuevo nivel")
		Me.btAceptar.BackColor = System.Drawing.SystemColors.Control
		Me.btAceptar.CausesValidation = True
		Me.btAceptar.Enabled = True
		Me.btAceptar.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btAceptar.Cursor = System.Windows.Forms.Cursors.Default
		Me.btAceptar.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btAceptar.TabStop = True
		Me.btAceptar.Name = "btAceptar"
		Me.btNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CancelButton = Me.btNuevo
		Me.btNuevo.Text = "&Nuevo"
		Me.btNuevo.Size = New System.Drawing.Size(61, 25)
		Me.btNuevo.Location = New System.Drawing.Point(136, 400)
		Me.btNuevo.TabIndex = 6
		Me.ToolTip1.SetToolTip(Me.btNuevo, "Elija para ingresar un nuevo nivel")
		Me.btNuevo.BackColor = System.Drawing.SystemColors.Control
		Me.btNuevo.CausesValidation = True
		Me.btNuevo.Enabled = True
		Me.btNuevo.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btNuevo.Cursor = System.Windows.Forms.Cursors.Default
		Me.btNuevo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btNuevo.TabStop = True
		Me.btNuevo.Name = "btNuevo"
		ListNombre.OcxState = CType(resources.GetObject("ListNombre.OcxState"), System.Windows.Forms.AxHost.State)
		Me.ListNombre.Size = New System.Drawing.Size(425, 329)
		Me.ListNombre.Location = New System.Drawing.Point(8, 64)
		Me.ListNombre.TabIndex = 5
		Me.ListNombre.Name = "ListNombre"
		Me.Optcodigo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.Optcodigo.Text = "Có&digo"
		Me.Optcodigo.Size = New System.Drawing.Size(65, 17)
		Me.Optcodigo.Location = New System.Drawing.Point(80, 16)
		Me.Optcodigo.TabIndex = 3
		Me.Optcodigo.Checked = True
		Me.Optcodigo.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.Optcodigo.BackColor = System.Drawing.SystemColors.Control
		Me.Optcodigo.CausesValidation = True
		Me.Optcodigo.Enabled = True
		Me.Optcodigo.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Optcodigo.Cursor = System.Windows.Forms.Cursors.Default
		Me.Optcodigo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Optcodigo.Appearance = System.Windows.Forms.Appearance.Normal
		Me.Optcodigo.TabStop = True
		Me.Optcodigo.Visible = True
		Me.Optcodigo.Name = "Optcodigo"
		Me.OptNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.OptNombre.Text = "&Nombre"
		Me.OptNombre.Size = New System.Drawing.Size(73, 17)
		Me.OptNombre.Location = New System.Drawing.Point(144, 16)
		Me.OptNombre.TabIndex = 2
		Me.OptNombre.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.OptNombre.BackColor = System.Drawing.SystemColors.Control
		Me.OptNombre.CausesValidation = True
		Me.OptNombre.Enabled = True
		Me.OptNombre.ForeColor = System.Drawing.SystemColors.ControlText
		Me.OptNombre.Cursor = System.Windows.Forms.Cursors.Default
		Me.OptNombre.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.OptNombre.Appearance = System.Windows.Forms.Appearance.Normal
		Me.OptNombre.TabStop = True
		Me.OptNombre.Checked = False
		Me.OptNombre.Visible = True
		Me.OptNombre.Name = "OptNombre"
		Me.TxtNombre.AutoSize = False
		Me.TxtNombre.Size = New System.Drawing.Size(305, 19)
		Me.TxtNombre.Location = New System.Drawing.Point(104, 40)
		Me.TxtNombre.TabIndex = 1
		Me.TxtNombre.AcceptsReturn = True
		Me.TxtNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TxtNombre.BackColor = System.Drawing.SystemColors.Window
		Me.TxtNombre.CausesValidation = True
		Me.TxtNombre.Enabled = True
		Me.TxtNombre.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TxtNombre.HideSelection = True
		Me.TxtNombre.ReadOnly = False
		Me.TxtNombre.Maxlength = 0
		Me.TxtNombre.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TxtNombre.MultiLine = False
		Me.TxtNombre.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TxtNombre.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TxtNombre.TabStop = True
		Me.TxtNombre.Visible = True
		Me.TxtNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TxtNombre.Name = "TxtNombre"
		Me.TextCodigo.AutoSize = False
		Me.TextCodigo.Size = New System.Drawing.Size(97, 19)
		Me.TextCodigo.Location = New System.Drawing.Point(8, 40)
		Me.TextCodigo.TabIndex = 0
		Me.TextCodigo.AcceptsReturn = True
		Me.TextCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.TextCodigo.BackColor = System.Drawing.SystemColors.Window
		Me.TextCodigo.CausesValidation = True
		Me.TextCodigo.Enabled = True
		Me.TextCodigo.ForeColor = System.Drawing.SystemColors.WindowText
		Me.TextCodigo.HideSelection = True
		Me.TextCodigo.ReadOnly = False
		Me.TextCodigo.Maxlength = 0
		Me.TextCodigo.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TextCodigo.MultiLine = False
		Me.TextCodigo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.TextCodigo.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.TextCodigo.TabStop = True
		Me.TextCodigo.Visible = True
		Me.TextCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.TextCodigo.Name = "TextCodigo"
		Me.Label1.Text = "Ordenado por:"
		Me.Label1.Size = New System.Drawing.Size(68, 13)
		Me.Label1.Location = New System.Drawing.Point(8, 16)
		Me.Label1.TabIndex = 4
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(btncancelarbusca)
		Me.Controls.Add(btAceptar)
		Me.Controls.Add(btNuevo)
		Me.Controls.Add(ListNombre)
		Me.Controls.Add(Optcodigo)
		Me.Controls.Add(OptNombre)
		Me.Controls.Add(TxtNombre)
		Me.Controls.Add(TextCodigo)
		Me.Controls.Add(Label1)
		CType(Me.ListNombre, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class