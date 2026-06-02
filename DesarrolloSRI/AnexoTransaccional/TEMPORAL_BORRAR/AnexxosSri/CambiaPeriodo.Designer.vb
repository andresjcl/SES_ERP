<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class CambiaPeriodo
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
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents Meses As System.Windows.Forms.ComboBox
	Public WithEvents Anios As System.Windows.Forms.ComboBox
	Public WithEvents CmbMes As System.Windows.Forms.Label
	Public WithEvents CmbAnio As System.Windows.Forms.Label
	'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
	'Se puede modificar mediante el Diseñador de Windows Forms.
	'No lo modifique con el editor de código.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CambiaPeriodo))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Command1 = New System.Windows.Forms.Button
		Me.Meses = New System.Windows.Forms.ComboBox
		Me.Anios = New System.Windows.Forms.ComboBox
		Me.CmbMes = New System.Windows.Forms.Label
		Me.CmbAnio = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.BackColor = System.Drawing.Color.FromARGB(225, 231, 247)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.Text = "CAMBIAR PERIODO DE OPERACION"
		Me.ClientSize = New System.Drawing.Size(444, 54)
		Me.Location = New System.Drawing.Point(0, 0)
		Me.ControlBox = False
		Me.KeyPreview = True
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.Enabled = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "CambiaPeriodo"
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.BackColor = System.Drawing.Color.FromARGB(225, 231, 247)
		Me.Command1.Text = "Continua"
		Me.Command1.Size = New System.Drawing.Size(57, 25)
		Me.Command1.Location = New System.Drawing.Point(376, 16)
		Me.Command1.TabIndex = 4
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.TabStop = True
		Me.Command1.Name = "Command1"
		Me.Meses.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Meses.ForeColor = System.Drawing.Color.Black
		Me.Meses.Size = New System.Drawing.Size(129, 24)
		Me.Meses.Location = New System.Drawing.Point(232, 16)
		Me.Meses.TabIndex = 1
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
		Me.Anios.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Anios.ForeColor = System.Drawing.Color.Black
		Me.Anios.Size = New System.Drawing.Size(105, 24)
		Me.Anios.Location = New System.Drawing.Point(56, 16)
		Me.Anios.TabIndex = 0
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
		Me.CmbMes.Text = "MES:"
		Me.CmbMes.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CmbMes.ForeColor = System.Drawing.Color.Blue
		Me.CmbMes.Size = New System.Drawing.Size(32, 16)
		Me.CmbMes.Location = New System.Drawing.Point(192, 19)
		Me.CmbMes.TabIndex = 3
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
		Me.CmbAnio.Text = "AÑO :"
		Me.CmbAnio.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CmbAnio.ForeColor = System.Drawing.Color.Blue
		Me.CmbAnio.Size = New System.Drawing.Size(36, 16)
		Me.CmbAnio.Location = New System.Drawing.Point(16, 18)
		Me.CmbAnio.TabIndex = 2
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
		Me.Controls.Add(Command1)
		Me.Controls.Add(Meses)
		Me.Controls.Add(Anios)
		Me.Controls.Add(CmbMes)
		Me.Controls.Add(CmbAnio)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class