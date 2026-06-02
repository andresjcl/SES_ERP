<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class AdcAutorizacionesSri
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
	Public WithEvents Malla As AxDaxGrid.AxDaxGridIn
	Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents txtcodigo As System.Windows.Forms.TextBox
	Public WithEvents btncliente As System.Windows.Forms.Button
	Public WithEvents txtnom As System.Windows.Forms.TextBox
	Public WithEvents Label13 As System.Windows.Forms.Label
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents btAceptar As System.Windows.Forms.Button
	'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
	'Se puede modificar mediante el Diseñador de Windows Forms.
	'No lo modifique con el editor de código.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AdcAutorizacionesSri))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Malla = New AxDaxGrid.AxDaxGridIn
		Me.Command2 = New System.Windows.Forms.Button
		Me.Command1 = New System.Windows.Forms.Button
		Me.Frame2 = New System.Windows.Forms.GroupBox
		Me.txtcodigo = New System.Windows.Forms.TextBox
		Me.btncliente = New System.Windows.Forms.Button
		Me.txtnom = New System.Windows.Forms.TextBox
		Me.Label13 = New System.Windows.Forms.Label
		Me.btAceptar = New System.Windows.Forms.Button
		Me.Frame2.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.Malla, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.FromARGB(128, 128, 255)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Registro de autorizaciones del SRI para emisión de documentos"
		Me.ClientSize = New System.Drawing.Size(728, 300)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.Icon = CType(resources.GetObject("AdcAutorizacionesSri.Icon"), System.Drawing.Icon)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "AdcAutorizacionesSri"
		Malla.OcxState = CType(resources.GetObject("Malla.OcxState"), System.Windows.Forms.AxHost.State)
		Me.Malla.Size = New System.Drawing.Size(713, 201)
		Me.Malla.Location = New System.Drawing.Point(8, 64)
		Me.Malla.TabIndex = 8
		Me.Malla.Name = "Malla"
		Me.Command2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command2.BackColor = System.Drawing.Color.FromARGB(73, 133, 186)
		Me.Command2.Text = "&Imprimir"
		Me.Command2.Size = New System.Drawing.Size(55, 25)
		Me.Command2.Location = New System.Drawing.Point(576, 272)
		Me.Command2.TabIndex = 7
		Me.ToolTip1.SetToolTip(Me.Command2, "Salir dela opción")
		Me.Command2.CausesValidation = True
		Me.Command2.Enabled = True
		Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command2.TabStop = True
		Me.Command2.Name = "Command2"
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.BackColor = System.Drawing.Color.FromARGB(73, 133, 186)
		Me.Command1.Text = "&Salir"
		Me.Command1.Size = New System.Drawing.Size(55, 25)
		Me.Command1.Location = New System.Drawing.Point(640, 272)
		Me.Command1.TabIndex = 6
		Me.ToolTip1.SetToolTip(Me.Command1, "Salir dela opción")
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.TabStop = True
		Me.Command1.Name = "Command1"
		Me.Frame2.BackColor = System.Drawing.Color.FromARGB(128, 128, 255)
		Me.Frame2.Text = "&Emisor del documento"
		Me.Frame2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Frame2.Size = New System.Drawing.Size(582, 57)
		Me.Frame2.Location = New System.Drawing.Point(8, 0)
		Me.Frame2.TabIndex = 1
		Me.Frame2.Enabled = True
		Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame2.Visible = True
		Me.Frame2.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame2.Name = "Frame2"
		Me.txtcodigo.AutoSize = False
		Me.txtcodigo.Size = New System.Drawing.Size(97, 19)
		Me.txtcodigo.Location = New System.Drawing.Point(56, 24)
		Me.txtcodigo.Maxlength = 15
		Me.txtcodigo.TabIndex = 4
		Me.ToolTip1.SetToolTip(Me.txtcodigo, "Ingrese el código del proveedor , F2 Busca el proveedor")
		Me.txtcodigo.AcceptsReturn = True
		Me.txtcodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtcodigo.BackColor = System.Drawing.SystemColors.Window
		Me.txtcodigo.CausesValidation = True
		Me.txtcodigo.Enabled = True
		Me.txtcodigo.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtcodigo.HideSelection = True
		Me.txtcodigo.ReadOnly = False
		Me.txtcodigo.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtcodigo.MultiLine = False
		Me.txtcodigo.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtcodigo.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtcodigo.TabStop = True
		Me.txtcodigo.Visible = True
		Me.txtcodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtcodigo.Name = "txtcodigo"
		Me.btncliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btncliente.Text = ".."
		Me.btncliente.Size = New System.Drawing.Size(17, 17)
		Me.btncliente.Location = New System.Drawing.Point(152, 24)
		Me.btncliente.TabIndex = 3
		Me.ToolTip1.SetToolTip(Me.btncliente, "Permite buscar los proveedores")
		Me.btncliente.BackColor = System.Drawing.SystemColors.Control
		Me.btncliente.CausesValidation = True
		Me.btncliente.Enabled = True
		Me.btncliente.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btncliente.Cursor = System.Windows.Forms.Cursors.Default
		Me.btncliente.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btncliente.TabStop = True
		Me.btncliente.Name = "btncliente"
		Me.txtnom.AutoSize = False
		Me.txtnom.Size = New System.Drawing.Size(369, 19)
		Me.txtnom.Location = New System.Drawing.Point(176, 24)
		Me.txtnom.Maxlength = 60
		Me.txtnom.TabIndex = 2
		Me.ToolTip1.SetToolTip(Me.txtnom, "Digíte el nombre deseado para la impreción de la factura")
		Me.txtnom.AcceptsReturn = True
		Me.txtnom.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtnom.BackColor = System.Drawing.SystemColors.Window
		Me.txtnom.CausesValidation = True
		Me.txtnom.Enabled = True
		Me.txtnom.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtnom.HideSelection = True
		Me.txtnom.ReadOnly = False
		Me.txtnom.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtnom.MultiLine = False
		Me.txtnom.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtnom.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtnom.TabStop = True
		Me.txtnom.Visible = True
		Me.txtnom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtnom.Name = "txtnom"
		Me.Label13.Text = "CI/RUC"
		Me.Label13.ForeColor = System.Drawing.Color.FromARGB(64, 64, 64)
		Me.Label13.Size = New System.Drawing.Size(38, 13)
		Me.Label13.Location = New System.Drawing.Point(8, 32)
		Me.Label13.TabIndex = 5
		Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label13.BackColor = System.Drawing.Color.Transparent
		Me.Label13.Enabled = True
		Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label13.UseMnemonic = True
		Me.Label13.Visible = True
		Me.Label13.AutoSize = True
		Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label13.Name = "Label13"
		Me.btAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btAceptar.BackColor = System.Drawing.Color.FromARGB(73, 133, 186)
		Me.btAceptar.Text = "&Grabar"
		Me.btAceptar.Size = New System.Drawing.Size(55, 25)
		Me.btAceptar.Location = New System.Drawing.Point(512, 272)
		Me.btAceptar.TabIndex = 0
		Me.ToolTip1.SetToolTip(Me.btAceptar, "Salir dela opción")
		Me.btAceptar.CausesValidation = True
		Me.btAceptar.Enabled = True
		Me.btAceptar.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btAceptar.Cursor = System.Windows.Forms.Cursors.Default
		Me.btAceptar.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btAceptar.TabStop = True
		Me.btAceptar.Name = "btAceptar"
		Me.Controls.Add(Malla)
		Me.Controls.Add(Command2)
		Me.Controls.Add(Command1)
		Me.Controls.Add(Frame2)
		Me.Controls.Add(btAceptar)
		Me.Frame2.Controls.Add(txtcodigo)
		Me.Frame2.Controls.Add(btncliente)
		Me.Frame2.Controls.Add(txtnom)
		Me.Frame2.Controls.Add(Label13)
		CType(Me.Malla, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Frame2.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class