<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class BuscDocSri
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
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents Malla As AxMSHierarchicalFlexGridLib.AxMSHFlexGrid
	'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
	'Se puede modificar mediante el Diseñador de Windows Forms.
	'No lo modifique con el editor de código.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(BuscDocSri))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.cmdClose = New System.Windows.Forms.Button
		Me.Malla = New AxMSHierarchicalFlexGridLib.AxMSHFlexGrid
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.Malla, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "Comprobantes SRI"
		Me.ClientSize = New System.Drawing.Size(386, 317)
		Me.Location = New System.Drawing.Point(74, 23)
		Me.ControlBox = False
		Me.KeyPreview = True
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.Enabled = True
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "BuscDocSri"
		Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CancelButton = Me.cmdClose
		Me.cmdClose.Text = "&Aceptar"
		Me.cmdClose.Size = New System.Drawing.Size(72, 20)
		Me.cmdClose.Location = New System.Drawing.Point(312, 296)
		Me.cmdClose.TabIndex = 0
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.TabStop = True
		Me.cmdClose.Name = "cmdClose"
		Malla.OcxState = CType(resources.GetObject("Malla.OcxState"), System.Windows.Forms.AxHost.State)
		Me.Malla.Size = New System.Drawing.Size(368, 309)
		Me.Malla.Location = New System.Drawing.Point(8, 8)
		Me.Malla.TabIndex = 1
		Me.Malla.Name = "Malla"
		Me.Controls.Add(cmdClose)
		Me.Controls.Add(Malla)
		CType(Me.Malla, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class