<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class SRITABA
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
	Public WithEvents MallaImp As AxMSHierarchicalFlexGridLib.AxMSHFlexGrid
	Public WithEvents Imprimir As System.Windows.Forms.Button
	Public WithEvents cmdDelete As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents cmdAdd As System.Windows.Forms.Button
	Public WithEvents cmdUpdate As System.Windows.Forms.Button
	Public WithEvents picButtons As System.Windows.Forms.Panel
	Public WithEvents Malla As AxMSDataGridLib.AxDataGrid
	'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
	'Se puede modificar mediante el Diseñador de Windows Forms.
	'No lo modifique con el editor de código.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SRITABA))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.MallaImp = New AxMSHierarchicalFlexGridLib.AxMSHFlexGrid
		Me.picButtons = New System.Windows.Forms.Panel
		Me.Imprimir = New System.Windows.Forms.Button
		Me.cmdDelete = New System.Windows.Forms.Button
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.cmdClose = New System.Windows.Forms.Button
		Me.cmdAdd = New System.Windows.Forms.Button
		Me.cmdUpdate = New System.Windows.Forms.Button
		Me.Malla = New AxMSDataGridLib.AxDataGrid
		Me.picButtons.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.MallaImp, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Malla, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "SriTipoTransaccion"
		Me.ClientSize = New System.Drawing.Size(591, 283)
		Me.Location = New System.Drawing.Point(74, 23)
		Me.Icon = CType(resources.GetObject("SRITABA.Icon"), System.Drawing.Icon)
		Me.KeyPreview = True
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
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
		Me.Name = "SRITABA"
		MallaImp.OcxState = CType(resources.GetObject("MallaImp.OcxState"), System.Windows.Forms.AxHost.State)
		Me.MallaImp.Size = New System.Drawing.Size(49, 17)
		Me.MallaImp.Location = New System.Drawing.Point(536, 264)
		Me.MallaImp.TabIndex = 8
		Me.MallaImp.Visible = False
		Me.MallaImp.Name = "MallaImp"
		Me.picButtons.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.picButtons.ForeColor = System.Drawing.SystemColors.WindowText
		Me.picButtons.Size = New System.Drawing.Size(591, 36)
		Me.picButtons.Location = New System.Drawing.Point(0, 247)
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
		Me.Imprimir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Imprimir.Text = "&Imprimir"
		Me.Imprimir.Size = New System.Drawing.Size(73, 28)
		Me.Imprimir.Location = New System.Drawing.Point(280, 0)
		Me.Imprimir.TabIndex = 7
		Me.Imprimir.BackColor = System.Drawing.SystemColors.Control
		Me.Imprimir.CausesValidation = True
		Me.Imprimir.Enabled = True
		Me.Imprimir.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Imprimir.Cursor = System.Windows.Forms.Cursors.Default
		Me.Imprimir.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Imprimir.TabStop = True
		Me.Imprimir.Name = "Imprimir"
		Me.cmdDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdDelete.Text = "&Eliminar"
		Me.cmdDelete.Size = New System.Drawing.Size(73, 28)
		Me.cmdDelete.Location = New System.Drawing.Point(104, 0)
		Me.cmdDelete.TabIndex = 3
		Me.cmdDelete.BackColor = System.Drawing.SystemColors.Control
		Me.cmdDelete.CausesValidation = True
		Me.cmdDelete.Enabled = True
		Me.cmdDelete.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdDelete.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdDelete.TabStop = True
		Me.cmdDelete.Name = "cmdDelete"
		Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCancel.Text = "&Cancelar"
		Me.cmdCancel.Size = New System.Drawing.Size(73, 28)
		Me.cmdCancel.Location = New System.Drawing.Point(104, 0)
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
		Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdClose.Text = "&Salir"
		Me.cmdClose.Size = New System.Drawing.Size(73, 28)
		Me.cmdClose.Location = New System.Drawing.Point(192, 0)
		Me.cmdClose.TabIndex = 4
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.TabStop = True
		Me.cmdClose.Name = "cmdClose"
		Me.cmdAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAdd.Text = "Nuevo"
		Me.cmdAdd.Size = New System.Drawing.Size(73, 28)
		Me.cmdAdd.Location = New System.Drawing.Point(16, 0)
		Me.cmdAdd.TabIndex = 2
		Me.cmdAdd.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAdd.CausesValidation = True
		Me.cmdAdd.Enabled = True
		Me.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAdd.TabStop = True
		Me.cmdAdd.Name = "cmdAdd"
		Me.cmdUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdUpdate.Text = "A&ctualizar"
		Me.cmdUpdate.Size = New System.Drawing.Size(73, 28)
		Me.cmdUpdate.Location = New System.Drawing.Point(16, 0)
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
		Malla.OcxState = CType(resources.GetObject("Malla.OcxState"), System.Windows.Forms.AxHost.State)
		Me.Malla.Dock = System.Windows.Forms.DockStyle.Top
		Me.Malla.Size = New System.Drawing.Size(591, 233)
		Me.Malla.Location = New System.Drawing.Point(0, 0)
		Me.Malla.TabIndex = 0
		Me.Malla.Name = "Malla"
		Me.Controls.Add(MallaImp)
		Me.Controls.Add(picButtons)
		Me.Controls.Add(Malla)
		Me.picButtons.Controls.Add(Imprimir)
		Me.picButtons.Controls.Add(cmdDelete)
		Me.picButtons.Controls.Add(cmdCancel)
		Me.picButtons.Controls.Add(cmdClose)
		Me.picButtons.Controls.Add(cmdAdd)
		Me.picButtons.Controls.Add(cmdUpdate)
		CType(Me.Malla, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.MallaImp, System.ComponentModel.ISupportInitialize).EndInit()
		Me.picButtons.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class