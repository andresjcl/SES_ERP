<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class SRIANULADOS
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
	Public WithEvents malla As AxMSDataGridLib.AxDataGrid
	Public WithEvents Importar As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdUpdate As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents cmdDelete As System.Windows.Forms.Button
	Public WithEvents cmdEdit As System.Windows.Forms.Button
	Public WithEvents cmdAdd As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
	'Se puede modificar mediante el Diseñador de Windows Forms.
	'No lo modifique con el editor de código.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SRIANULADOS))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.malla = New AxMSDataGridLib.AxDataGrid
		Me.picButtons = New System.Windows.Forms.Panel
		Me.Importar = New System.Windows.Forms.Button
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.cmdUpdate = New System.Windows.Forms.Button
		Me.cmdClose = New System.Windows.Forms.Button
		Me.cmdDelete = New System.Windows.Forms.Button
		Me.cmdEdit = New System.Windows.Forms.Button
		Me.cmdAdd = New System.Windows.Forms.Button
		Me.picButtons.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.malla, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "Anulados"
		Me.ClientSize = New System.Drawing.Size(671, 396)
		Me.Location = New System.Drawing.Point(74, 23)
		Me.Icon = CType(resources.GetObject("SRIANULADOS.Icon"), System.Drawing.Icon)
		Me.KeyPreview = True
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.ControlBox = True
		Me.Enabled = True
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "SRIANULADOS"
		malla.OcxState = CType(resources.GetObject("malla.OcxState"), System.Windows.Forms.AxHost.State)
		Me.malla.Dock = System.Windows.Forms.DockStyle.Top
		Me.malla.Size = New System.Drawing.Size(671, 353)
		Me.malla.Location = New System.Drawing.Point(0, 0)
		Me.malla.TabIndex = 0
		Me.malla.Name = "malla"
		Me.picButtons.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.picButtons.ForeColor = System.Drawing.SystemColors.WindowText
		Me.picButtons.Size = New System.Drawing.Size(671, 36)
		Me.picButtons.Location = New System.Drawing.Point(0, 360)
		Me.picButtons.TabIndex = 1
		Me.picButtons.BackColor = System.Drawing.SystemColors.Control
		Me.picButtons.CausesValidation = True
		Me.picButtons.Enabled = True
		Me.picButtons.Cursor = System.Windows.Forms.Cursors.Default
		Me.picButtons.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.picButtons.TabStop = True
		Me.picButtons.Visible = True
		Me.picButtons.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.picButtons.Name = "picButtons"
		Me.Importar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Importar.Text = "Importar"
		Me.Importar.Size = New System.Drawing.Size(73, 34)
		Me.Importar.Location = New System.Drawing.Point(360, 0)
		Me.Importar.TabIndex = 8
		Me.Importar.Visible = False
		Me.Importar.BackColor = System.Drawing.SystemColors.Control
		Me.Importar.CausesValidation = True
		Me.Importar.Enabled = True
		Me.Importar.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Importar.Cursor = System.Windows.Forms.Cursors.Default
		Me.Importar.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Importar.TabStop = True
		Me.Importar.Name = "Importar"
		Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCancel.Text = "&Cancelar"
		Me.cmdCancel.Size = New System.Drawing.Size(73, 34)
		Me.cmdCancel.Location = New System.Drawing.Point(96, 0)
		Me.cmdCancel.TabIndex = 7
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
		Me.cmdUpdate.Text = "Grabar"
		Me.cmdUpdate.Size = New System.Drawing.Size(73, 34)
		Me.cmdUpdate.Location = New System.Drawing.Point(8, 0)
		Me.cmdUpdate.TabIndex = 6
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
		Me.cmdClose.Text = "&Salir"
		Me.cmdClose.Size = New System.Drawing.Size(73, 34)
		Me.cmdClose.Location = New System.Drawing.Point(272, 0)
		Me.cmdClose.TabIndex = 5
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
		Me.cmdDelete.Size = New System.Drawing.Size(73, 34)
		Me.cmdDelete.Location = New System.Drawing.Point(184, 0)
		Me.cmdDelete.TabIndex = 4
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
		Me.cmdEdit.Size = New System.Drawing.Size(73, 34)
		Me.cmdEdit.Location = New System.Drawing.Point(96, 0)
		Me.cmdEdit.TabIndex = 3
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
		Me.cmdAdd.Size = New System.Drawing.Size(73, 34)
		Me.cmdAdd.Location = New System.Drawing.Point(8, 0)
		Me.cmdAdd.TabIndex = 2
		Me.cmdAdd.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAdd.CausesValidation = True
		Me.cmdAdd.Enabled = True
		Me.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAdd.TabStop = True
		Me.cmdAdd.Name = "cmdAdd"
		Me.Controls.Add(malla)
		Me.Controls.Add(picButtons)
		Me.picButtons.Controls.Add(Importar)
		Me.picButtons.Controls.Add(cmdCancel)
		Me.picButtons.Controls.Add(cmdUpdate)
		Me.picButtons.Controls.Add(cmdClose)
		Me.picButtons.Controls.Add(cmdDelete)
		Me.picButtons.Controls.Add(cmdEdit)
		Me.picButtons.Controls.Add(cmdAdd)
		CType(Me.malla, System.ComponentModel.ISupportInitialize).EndInit()
		Me.picButtons.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class