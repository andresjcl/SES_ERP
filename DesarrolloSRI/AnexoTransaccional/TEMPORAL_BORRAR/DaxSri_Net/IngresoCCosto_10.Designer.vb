<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class IngresoCCosto
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
	Public WithEvents _txtFields_3 As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_2 As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_1 As System.Windows.Forms.TextBox
	Public WithEvents _txtFields_0 As System.Windows.Forms.TextBox
	Public WithEvents _lblLabels_3 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_1 As System.Windows.Forms.Label
	Public WithEvents _lblLabels_0 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents cmdLast As System.Windows.Forms.Button
	Public WithEvents cmdNext As System.Windows.Forms.Button
	Public WithEvents cmdPrevious As System.Windows.Forms.Button
	Public WithEvents cmdFirst As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdUpdate As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents cmdDelete As System.Windows.Forms.Button
	Public WithEvents cmdEdit As System.Windows.Forms.Button
	Public WithEvents cmdAdd As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents lblLabels As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents txtFields As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
	'Se puede modificar mediante el Diseñador de Windows Forms.
	'No lo modifique con el editor de código.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(IngresoCCosto))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Frame1 = New System.Windows.Forms.GroupBox
		Me.Command1 = New System.Windows.Forms.Button
		Me._txtFields_3 = New System.Windows.Forms.TextBox
		Me._txtFields_2 = New System.Windows.Forms.TextBox
		Me._txtFields_1 = New System.Windows.Forms.TextBox
		Me._txtFields_0 = New System.Windows.Forms.TextBox
		Me._lblLabels_3 = New System.Windows.Forms.Label
		Me._lblLabels_1 = New System.Windows.Forms.Label
		Me._lblLabels_0 = New System.Windows.Forms.Label
		Me.picButtons = New System.Windows.Forms.Panel
		Me.cmdLast = New System.Windows.Forms.Button
		Me.cmdNext = New System.Windows.Forms.Button
		Me.cmdPrevious = New System.Windows.Forms.Button
		Me.cmdFirst = New System.Windows.Forms.Button
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.cmdUpdate = New System.Windows.Forms.Button
		Me.cmdClose = New System.Windows.Forms.Button
		Me.cmdDelete = New System.Windows.Forms.Button
		Me.cmdEdit = New System.Windows.Forms.Button
		Me.cmdAdd = New System.Windows.Forms.Button
		Me.lblLabels = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.txtFields = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(components)
		Me.Frame1.SuspendLayout()
		Me.picButtons.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtFields, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Definición de centros de costo"
		Me.ClientSize = New System.Drawing.Size(469, 169)
		Me.Location = New System.Drawing.Point(73, 29)
		Me.Icon = CType(resources.GetObject("IngresoCCosto.Icon"), System.Drawing.Icon)
		Me.KeyPreview = True
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "IngresoCCosto"
		Me.Frame1.Size = New System.Drawing.Size(449, 129)
		Me.Frame1.Location = New System.Drawing.Point(8, 8)
		Me.Frame1.TabIndex = 11
		Me.Frame1.BackColor = System.Drawing.SystemColors.Control
		Me.Frame1.Enabled = True
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Visible = True
		Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
		Me.Frame1.Name = "Frame1"
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.Text = "Buscar en directorio"
		Me.Command1.Size = New System.Drawing.Size(129, 21)
		Me.Command1.Location = New System.Drawing.Point(304, 16)
		Me.Command1.TabIndex = 19
		Me.Command1.BackColor = System.Drawing.SystemColors.Control
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.TabStop = True
		Me.Command1.Name = "Command1"
		Me._txtFields_3.AutoSize = False
		Me._txtFields_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me._txtFields_3.Size = New System.Drawing.Size(65, 19)
		Me._txtFields_3.Location = New System.Drawing.Point(200, 72)
		Me._txtFields_3.Maxlength = 5
		Me._txtFields_3.TabIndex = 18
		Me._txtFields_3.AcceptsReturn = True
		Me._txtFields_3.BackColor = System.Drawing.SystemColors.Window
		Me._txtFields_3.CausesValidation = True
		Me._txtFields_3.Enabled = True
		Me._txtFields_3.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtFields_3.HideSelection = True
		Me._txtFields_3.ReadOnly = False
		Me._txtFields_3.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtFields_3.MultiLine = False
		Me._txtFields_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtFields_3.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtFields_3.TabStop = True
		Me._txtFields_3.Visible = True
		Me._txtFields_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtFields_3.Name = "_txtFields_3"
		Me._txtFields_2.AutoSize = False
		Me._txtFields_2.Size = New System.Drawing.Size(49, 19)
		Me._txtFields_2.Location = New System.Drawing.Point(296, 72)
		Me._txtFields_2.TabIndex = 16
		Me._txtFields_2.Visible = False
		Me._txtFields_2.AcceptsReturn = True
		Me._txtFields_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtFields_2.BackColor = System.Drawing.SystemColors.Window
		Me._txtFields_2.CausesValidation = True
		Me._txtFields_2.Enabled = True
		Me._txtFields_2.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtFields_2.HideSelection = True
		Me._txtFields_2.ReadOnly = False
		Me._txtFields_2.Maxlength = 0
		Me._txtFields_2.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtFields_2.MultiLine = False
		Me._txtFields_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtFields_2.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtFields_2.TabStop = True
		Me._txtFields_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtFields_2.Name = "_txtFields_2"
		Me._txtFields_1.AutoSize = False
		Me._txtFields_1.Size = New System.Drawing.Size(377, 19)
		Me._txtFields_1.Location = New System.Drawing.Point(64, 49)
		Me._txtFields_1.Maxlength = 50
		Me._txtFields_1.TabIndex = 15
		Me._txtFields_1.AcceptsReturn = True
		Me._txtFields_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtFields_1.BackColor = System.Drawing.SystemColors.Window
		Me._txtFields_1.CausesValidation = True
		Me._txtFields_1.Enabled = True
		Me._txtFields_1.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtFields_1.HideSelection = True
		Me._txtFields_1.ReadOnly = False
		Me._txtFields_1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtFields_1.MultiLine = False
		Me._txtFields_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtFields_1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtFields_1.TabStop = True
		Me._txtFields_1.Visible = True
		Me._txtFields_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtFields_1.Name = "_txtFields_1"
		Me._txtFields_0.AutoSize = False
		Me._txtFields_0.Size = New System.Drawing.Size(97, 19)
		Me._txtFields_0.Location = New System.Drawing.Point(88, 16)
		Me._txtFields_0.Maxlength = 15
		Me._txtFields_0.TabIndex = 13
		Me._txtFields_0.AcceptsReturn = True
		Me._txtFields_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me._txtFields_0.BackColor = System.Drawing.SystemColors.Window
		Me._txtFields_0.CausesValidation = True
		Me._txtFields_0.Enabled = True
		Me._txtFields_0.ForeColor = System.Drawing.SystemColors.WindowText
		Me._txtFields_0.HideSelection = True
		Me._txtFields_0.ReadOnly = False
		Me._txtFields_0.Cursor = System.Windows.Forms.Cursors.IBeam
		Me._txtFields_0.MultiLine = False
		Me._txtFields_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._txtFields_0.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me._txtFields_0.TabStop = True
		Me._txtFields_0.Visible = True
		Me._txtFields_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me._txtFields_0.Name = "_txtFields_0"
		Me._lblLabels_3.Text = "Porcentaje de distribucion de costos"
		Me._lblLabels_3.Size = New System.Drawing.Size(171, 13)
		Me._lblLabels_3.Location = New System.Drawing.Point(16, 76)
		Me._lblLabels_3.TabIndex = 17
		Me._lblLabels_3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblLabels_3.BackColor = System.Drawing.SystemColors.Control
		Me._lblLabels_3.Enabled = True
		Me._lblLabels_3.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_3.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_3.UseMnemonic = True
		Me._lblLabels_3.Visible = True
		Me._lblLabels_3.AutoSize = False
		Me._lblLabels_3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_3.Name = "_lblLabels_3"
		Me._lblLabels_1.Text = "Nombre:"
		Me._lblLabels_1.Size = New System.Drawing.Size(40, 13)
		Me._lblLabels_1.Location = New System.Drawing.Point(16, 49)
		Me._lblLabels_1.TabIndex = 14
		Me._lblLabels_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblLabels_1.BackColor = System.Drawing.SystemColors.Control
		Me._lblLabels_1.Enabled = True
		Me._lblLabels_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_1.UseMnemonic = True
		Me._lblLabels_1.Visible = True
		Me._lblLabels_1.AutoSize = True
		Me._lblLabels_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_1.Name = "_lblLabels_1"
		Me._lblLabels_0.Text = "Identificativo"
		Me._lblLabels_0.Size = New System.Drawing.Size(60, 13)
		Me._lblLabels_0.Location = New System.Drawing.Point(16, 16)
		Me._lblLabels_0.TabIndex = 12
		Me._lblLabels_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._lblLabels_0.BackColor = System.Drawing.SystemColors.Control
		Me._lblLabels_0.Enabled = True
		Me._lblLabels_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._lblLabels_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._lblLabels_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._lblLabels_0.UseMnemonic = True
		Me._lblLabels_0.Visible = True
		Me._lblLabels_0.AutoSize = False
		Me._lblLabels_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._lblLabels_0.Name = "_lblLabels_0"
		Me.picButtons.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.picButtons.ForeColor = System.Drawing.SystemColors.WindowText
		Me.picButtons.Size = New System.Drawing.Size(469, 28)
		Me.picButtons.Location = New System.Drawing.Point(0, 141)
		Me.picButtons.TabIndex = 0
		Me.picButtons.BackColor = System.Drawing.SystemColors.Control
		Me.picButtons.CausesValidation = True
		Me.picButtons.Enabled = True
		Me.picButtons.Cursor = System.Windows.Forms.Cursors.Default
		Me.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picButtons.TabStop = True
		Me.picButtons.Visible = True
		Me.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.picButtons.Name = "picButtons"
		Me.cmdLast.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.cmdLast.Size = New System.Drawing.Size(27, 27)
		Me.cmdLast.Location = New System.Drawing.Point(432, 0)
		Me.cmdLast.Image = CType(resources.GetObject("cmdLast.Image"), System.Drawing.Image)
		Me.cmdLast.TabIndex = 10
		Me.cmdLast.BackColor = System.Drawing.SystemColors.Control
		Me.cmdLast.CausesValidation = True
		Me.cmdLast.Enabled = True
		Me.cmdLast.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdLast.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdLast.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdLast.TabStop = True
		Me.cmdLast.Name = "cmdLast"
		Me.cmdNext.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.cmdNext.Size = New System.Drawing.Size(27, 27)
		Me.cmdNext.Location = New System.Drawing.Point(400, 0)
		Me.cmdNext.Image = CType(resources.GetObject("cmdNext.Image"), System.Drawing.Image)
		Me.cmdNext.TabIndex = 9
		Me.cmdNext.BackColor = System.Drawing.SystemColors.Control
		Me.cmdNext.CausesValidation = True
		Me.cmdNext.Enabled = True
		Me.cmdNext.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdNext.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdNext.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdNext.TabStop = True
		Me.cmdNext.Name = "cmdNext"
		Me.cmdPrevious.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.cmdPrevious.Size = New System.Drawing.Size(27, 27)
		Me.cmdPrevious.Location = New System.Drawing.Point(368, 0)
		Me.cmdPrevious.Image = CType(resources.GetObject("cmdPrevious.Image"), System.Drawing.Image)
		Me.cmdPrevious.TabIndex = 8
		Me.cmdPrevious.BackColor = System.Drawing.SystemColors.Control
		Me.cmdPrevious.CausesValidation = True
		Me.cmdPrevious.Enabled = True
		Me.cmdPrevious.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdPrevious.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdPrevious.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdPrevious.TabStop = True
		Me.cmdPrevious.Name = "cmdPrevious"
		Me.cmdFirst.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		Me.cmdFirst.Size = New System.Drawing.Size(27, 27)
		Me.cmdFirst.Location = New System.Drawing.Point(336, 0)
		Me.cmdFirst.Image = CType(resources.GetObject("cmdFirst.Image"), System.Drawing.Image)
		Me.cmdFirst.TabIndex = 7
		Me.cmdFirst.BackColor = System.Drawing.SystemColors.Control
		Me.cmdFirst.CausesValidation = True
		Me.cmdFirst.Enabled = True
		Me.cmdFirst.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdFirst.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdFirst.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdFirst.TabStop = True
		Me.cmdFirst.Name = "cmdFirst"
		Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCancel.Text = "&Cancelar"
		Me.cmdCancel.Size = New System.Drawing.Size(68, 27)
		Me.cmdCancel.Location = New System.Drawing.Point(80, 0)
		Me.cmdCancel.TabIndex = 6
		Me.cmdCancel.Visible = False
		Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCancel.CausesValidation = True
		Me.cmdCancel.Enabled = True
		Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCancel.TabStop = True
		Me.cmdCancel.Name = "cmdCancel"
		Me.cmdUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdUpdate.Text = "&Guardar"
		Me.cmdUpdate.Size = New System.Drawing.Size(68, 27)
		Me.cmdUpdate.Location = New System.Drawing.Point(8, 0)
		Me.cmdUpdate.TabIndex = 5
		Me.cmdUpdate.Visible = False
		Me.cmdUpdate.BackColor = System.Drawing.SystemColors.Control
		Me.cmdUpdate.CausesValidation = True
		Me.cmdUpdate.Enabled = True
		Me.cmdUpdate.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdUpdate.TabStop = True
		Me.cmdUpdate.Name = "cmdUpdate"
		Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdClose.Text = "&Cerrar"
		Me.cmdClose.Size = New System.Drawing.Size(68, 27)
		Me.cmdClose.Location = New System.Drawing.Point(224, 0)
		Me.cmdClose.TabIndex = 4
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.TabStop = True
		Me.cmdClose.Name = "cmdClose"
		Me.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDelete.Text = "&Eliminar"
		Me.cmdDelete.Size = New System.Drawing.Size(68, 27)
		Me.cmdDelete.Location = New System.Drawing.Point(152, 0)
		Me.cmdDelete.TabIndex = 3
		Me.cmdDelete.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDelete.CausesValidation = True
		Me.cmdDelete.Enabled = True
		Me.cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDelete.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDelete.TabStop = True
		Me.cmdDelete.Name = "cmdDelete"
		Me.cmdEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdEdit.Text = "&Modificar"
		Me.cmdEdit.Size = New System.Drawing.Size(68, 27)
		Me.cmdEdit.Location = New System.Drawing.Point(81, 0)
		Me.cmdEdit.TabIndex = 2
		Me.cmdEdit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdEdit.CausesValidation = True
		Me.cmdEdit.Enabled = True
		Me.cmdEdit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdEdit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdEdit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdEdit.TabStop = True
		Me.cmdEdit.Name = "cmdEdit"
		Me.cmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAdd.Text = "&Nuevo"
		Me.cmdAdd.Size = New System.Drawing.Size(68, 27)
		Me.cmdAdd.Location = New System.Drawing.Point(8, 0)
		Me.cmdAdd.TabIndex = 1
		Me.cmdAdd.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAdd.CausesValidation = True
		Me.cmdAdd.Enabled = True
		Me.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAdd.TabStop = True
		Me.cmdAdd.Name = "cmdAdd"
		Me.Controls.Add(Frame1)
		Me.Controls.Add(picButtons)
		Me.Frame1.Controls.Add(Command1)
		Me.Frame1.Controls.Add(_txtFields_3)
		Me.Frame1.Controls.Add(_txtFields_2)
		Me.Frame1.Controls.Add(_txtFields_1)
		Me.Frame1.Controls.Add(_txtFields_0)
		Me.Frame1.Controls.Add(_lblLabels_3)
		Me.Frame1.Controls.Add(_lblLabels_1)
		Me.Frame1.Controls.Add(_lblLabels_0)
		Me.picButtons.Controls.Add(cmdLast)
		Me.picButtons.Controls.Add(cmdNext)
		Me.picButtons.Controls.Add(cmdPrevious)
		Me.picButtons.Controls.Add(cmdFirst)
		Me.picButtons.Controls.Add(cmdCancel)
		Me.picButtons.Controls.Add(cmdUpdate)
		Me.picButtons.Controls.Add(cmdClose)
		Me.picButtons.Controls.Add(cmdDelete)
		Me.picButtons.Controls.Add(cmdEdit)
		Me.picButtons.Controls.Add(cmdAdd)
		Me.lblLabels.SetIndex(_lblLabels_3, CType(3, Short))
		Me.lblLabels.SetIndex(_lblLabels_1, CType(1, Short))
		Me.lblLabels.SetIndex(_lblLabels_0, CType(0, Short))
		Me.txtFields.SetIndex(_txtFields_3, CType(3, Short))
		Me.txtFields.SetIndex(_txtFields_2, CType(2, Short))
		Me.txtFields.SetIndex(_txtFields_1, CType(1, Short))
		Me.txtFields.SetIndex(_txtFields_0, CType(0, Short))
		CType(Me.txtFields, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.lblLabels, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Frame1.ResumeLayout(False)
		Me.picButtons.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class