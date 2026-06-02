<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class SRIGENARCHIVOSCOA
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
	Public WithEvents Text3 As System.Windows.Forms.TextBox
	Public WithEvents Command3 As System.Windows.Forms.Button
	Public WithEvents Anios As System.Windows.Forms.ComboBox
	Public WithEvents Meses As System.Windows.Forms.ComboBox
	Public WithEvents Avance As AxComctlLib.AxProgressBar
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents CmbAnio As System.Windows.Forms.Label
	Public WithEvents CmbMes As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents btngenerar As System.Windows.Forms.Button
	Public WithEvents btnsalir As System.Windows.Forms.Button
	Public WithEvents f3 As System.Windows.Forms.GroupBox
	Public dialogoOpen As System.Windows.Forms.OpenFileDialog
	'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
	'Se puede modificar mediante el Diseñador de Windows Forms.
	'No lo modifique con el editor de código.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SRIGENARCHIVOSCOA))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Frame1 = New System.Windows.Forms.GroupBox
		Me.Text3 = New System.Windows.Forms.TextBox
		Me.Command3 = New System.Windows.Forms.Button
		Me.Anios = New System.Windows.Forms.ComboBox
		Me.Meses = New System.Windows.Forms.ComboBox
		Me.Avance = New AxComctlLib.AxProgressBar
		Me.Label2 = New System.Windows.Forms.Label
		Me.CmbAnio = New System.Windows.Forms.Label
		Me.CmbMes = New System.Windows.Forms.Label
		Me.f3 = New System.Windows.Forms.GroupBox
		Me.btngenerar = New System.Windows.Forms.Button
		Me.btnsalir = New System.Windows.Forms.Button
		Me.dialogoOpen = New System.Windows.Forms.OpenFileDialog
		Me.Frame1.SuspendLayout()
		Me.f3.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.Avance, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.FromARGB(176, 196, 222)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
		Me.Text = "Generación de ANEXO TRANSACCIONAL"
		Me.ClientSize = New System.Drawing.Size(451, 229)
		Me.Location = New System.Drawing.Point(4, 20)
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
		Me.Name = "SRIGENARCHIVOSCOA"
		Me.Frame1.BackColor = System.Drawing.Color.FromARGB(176, 196, 222)
		Me.Frame1.Size = New System.Drawing.Size(433, 177)
		Me.Frame1.Location = New System.Drawing.Point(8, 0)
		Me.Frame1.TabIndex = 3
		Me.Frame1.Enabled = True
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Visible = True
		Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame1.Name = "Frame1"
		Me.Text3.AutoSize = False
		Me.Text3.Size = New System.Drawing.Size(265, 19)
		Me.Text3.Location = New System.Drawing.Point(136, 104)
		Me.Text3.TabIndex = 10
		Me.Text3.AcceptsReturn = True
		Me.Text3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.Text3.BackColor = System.Drawing.SystemColors.Window
		Me.Text3.CausesValidation = True
		Me.Text3.Enabled = True
		Me.Text3.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Text3.HideSelection = True
		Me.Text3.ReadOnly = False
		Me.Text3.Maxlength = 0
		Me.Text3.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.Text3.MultiLine = False
		Me.Text3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Text3.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.Text3.TabStop = True
		Me.Text3.Visible = True
		Me.Text3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Text3.Name = "Text3"
		Me.Command3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command3.BackColor = System.Drawing.Color.FromARGB(225, 231, 247)
		Me.Command3.Text = ".."
		Me.Command3.Size = New System.Drawing.Size(17, 21)
		Me.Command3.Location = New System.Drawing.Point(400, 104)
		Me.Command3.TabIndex = 9
		Me.Command3.CausesValidation = True
		Me.Command3.Enabled = True
		Me.Command3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command3.TabStop = True
		Me.Command3.Name = "Command3"
		Me.Anios.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Anios.ForeColor = System.Drawing.Color.Black
		Me.Anios.Size = New System.Drawing.Size(105, 24)
		Me.Anios.Location = New System.Drawing.Point(288, 48)
		Me.Anios.TabIndex = 6
		Me.Anios.Text = "Combo1"
		Me.Anios.BackColor = System.Drawing.SystemColors.Window
		Me.Anios.CausesValidation = True
		Me.Anios.Enabled = True
		Me.Anios.IntegralHeight = True
		Me.Anios.Cursor = System.Windows.Forms.Cursors.Default
		Me.Anios.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Anios.Sorted = False
		Me.Anios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.Anios.TabStop = True
		Me.Anios.Visible = True
		Me.Anios.Name = "Anios"
		Me.Meses.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Meses.ForeColor = System.Drawing.Color.Black
		Me.Meses.Size = New System.Drawing.Size(129, 24)
		Me.Meses.Location = New System.Drawing.Point(72, 48)
		Me.Meses.TabIndex = 5
		Me.Meses.Text = "Combo1"
		Me.Meses.BackColor = System.Drawing.SystemColors.Window
		Me.Meses.CausesValidation = True
		Me.Meses.Enabled = True
		Me.Meses.IntegralHeight = True
		Me.Meses.Cursor = System.Windows.Forms.Cursors.Default
		Me.Meses.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Meses.Sorted = False
		Me.Meses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.Meses.TabStop = True
		Me.Meses.Visible = True
		Me.Meses.Name = "Meses"
		Avance.OcxState = CType(resources.GetObject("Avance.OcxState"), System.Windows.Forms.AxHost.State)
		Me.Avance.Size = New System.Drawing.Size(417, 17)
		Me.Avance.Location = New System.Drawing.Point(8, 144)
		Me.Avance.TabIndex = 4
		Me.Avance.Visible = False
		Me.Avance.Name = "Avance"
		Me.Label2.Text = "Generar archivo:"
		Me.Label2.Size = New System.Drawing.Size(116, 16)
		Me.Label2.Location = New System.Drawing.Point(8, 104)
		Me.Label2.TabIndex = 11
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
		Me.CmbAnio.Text = "AÑO :"
		Me.CmbAnio.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CmbAnio.ForeColor = System.Drawing.Color.Black
		Me.CmbAnio.Size = New System.Drawing.Size(36, 16)
		Me.CmbAnio.Location = New System.Drawing.Point(256, 50)
		Me.CmbAnio.TabIndex = 8
		Me.CmbAnio.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.CmbAnio.BackColor = System.Drawing.Color.Transparent
		Me.CmbAnio.Enabled = True
		Me.CmbAnio.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmbAnio.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmbAnio.UseMnemonic = True
		Me.CmbAnio.Visible = True
		Me.CmbAnio.AutoSize = True
		Me.CmbAnio.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.CmbAnio.Name = "CmbAnio"
		Me.CmbMes.Text = "MES:"
		Me.CmbMes.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CmbMes.ForeColor = System.Drawing.Color.Black
		Me.CmbMes.Size = New System.Drawing.Size(33, 16)
		Me.CmbMes.Location = New System.Drawing.Point(32, 51)
		Me.CmbMes.TabIndex = 7
		Me.CmbMes.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.CmbMes.BackColor = System.Drawing.Color.Transparent
		Me.CmbMes.Enabled = True
		Me.CmbMes.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmbMes.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmbMes.UseMnemonic = True
		Me.CmbMes.Visible = True
		Me.CmbMes.AutoSize = True
		Me.CmbMes.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.CmbMes.Name = "CmbMes"
		Me.f3.BackColor = System.Drawing.Color.FromARGB(176, 196, 222)
		Me.f3.Size = New System.Drawing.Size(129, 50)
		Me.f3.Location = New System.Drawing.Point(8, 176)
		Me.f3.TabIndex = 0
		Me.f3.Enabled = True
		Me.f3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.f3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.f3.Visible = True
		Me.f3.Padding = New System.Windows.Forms.Padding(0)
		Me.f3.Name = "f3"
		Me.btngenerar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btngenerar.BackColor = System.Drawing.Color.FromARGB(225, 231, 247)
		Me.btngenerar.Text = "&Generar"
		Me.btngenerar.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btngenerar.Size = New System.Drawing.Size(54, 34)
		Me.btngenerar.Location = New System.Drawing.Point(8, 13)
		Me.btngenerar.TabIndex = 2
		Me.ToolTip1.SetToolTip(Me.btngenerar, "Imprimir registros")
		Me.btngenerar.CausesValidation = True
		Me.btngenerar.Enabled = True
		Me.btngenerar.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btngenerar.Cursor = System.Windows.Forms.Cursors.Default
		Me.btngenerar.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btngenerar.TabStop = True
		Me.btngenerar.Name = "btngenerar"
		Me.btnsalir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnsalir.BackColor = System.Drawing.Color.FromARGB(225, 231, 247)
		Me.btnsalir.Text = "&Salir"
		Me.btnsalir.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnsalir.Size = New System.Drawing.Size(54, 34)
		Me.btnsalir.Location = New System.Drawing.Point(64, 13)
		Me.btnsalir.TabIndex = 1
		Me.ToolTip1.SetToolTip(Me.btnsalir, "Regresa al menu principal")
		Me.btnsalir.CausesValidation = True
		Me.btnsalir.Enabled = True
		Me.btnsalir.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnsalir.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnsalir.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnsalir.TabStop = True
		Me.btnsalir.Name = "btnsalir"
		Me.Controls.Add(Frame1)
		Me.Controls.Add(f3)
		Me.Frame1.Controls.Add(Text3)
		Me.Frame1.Controls.Add(Command3)
		Me.Frame1.Controls.Add(Anios)
		Me.Frame1.Controls.Add(Meses)
		Me.Frame1.Controls.Add(Avance)
		Me.Frame1.Controls.Add(Label2)
		Me.Frame1.Controls.Add(CmbAnio)
		Me.Frame1.Controls.Add(CmbMes)
		Me.f3.Controls.Add(btngenerar)
		Me.f3.Controls.Add(btnsalir)
		CType(Me.Avance, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Frame1.ResumeLayout(False)
		Me.f3.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class