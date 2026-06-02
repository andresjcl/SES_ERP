<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class ImportaExcel
#Region "Código generado por el Diseñador de Windows Forms "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'Llamada necesaria para el Diseñador de Windows Forms.
		InitializeComponent()
		'Éste es un formulario MDI secundario.
		'Este código simula la funcionalidad de VB6 
		' de cargar automáticamente
		' y mostrar el formulario primario de
		' un MDI secundario.
		Me.MDIParent = IVARETdx.MdTransacciones
		IVARETdx.MdTransacciones.Show
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
	Public WithEvents malla As AxDaxGridnvo.AxDaxGridInNv
	Public WithEvents _estado_Panel1 As System.Windows.Forms.ToolStripStatusLabel
	Public WithEvents _estado_Panel2 As System.Windows.Forms.ToolStripStatusLabel
	Public WithEvents _estado_Panel3 As System.Windows.Forms.ToolStripStatusLabel
	Public WithEvents estado As System.Windows.Forms.StatusStrip
	'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
	'Se puede modificar mediante el Diseñador de Windows Forms.
	'No lo modifique con el editor de código.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ImportaExcel))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.malla = New AxDaxGridnvo.AxDaxGridInNv
		Me.estado = New System.Windows.Forms.StatusStrip
		Me._estado_Panel1 = New System.Windows.Forms.ToolStripStatusLabel
		Me._estado_Panel2 = New System.Windows.Forms.ToolStripStatusLabel
		Me._estado_Panel3 = New System.Windows.Forms.ToolStripStatusLabel
		Me.estado.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.malla, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.BackColor = System.Drawing.Color.FromARGB(225, 231, 247)
		Me.Text = "EDICION DE REGISTROS DE COMPRAS"
		Me.ClientSize = New System.Drawing.Size(859, 438)
		Me.Location = New System.Drawing.Point(74, 23)
		Me.Icon = CType(resources.GetObject("ImportaExcel.Icon"), System.Drawing.Icon)
		Me.KeyPreview = True
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
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
		Me.Name = "ImportaExcel"
		malla.OcxState = CType(resources.GetObject("malla.OcxState"), System.Windows.Forms.AxHost.State)
		Me.malla.Size = New System.Drawing.Size(529, 249)
		Me.malla.Location = New System.Drawing.Point(96, 64)
		Me.malla.TabIndex = 1
		Me.malla.Name = "malla"
		Me.estado.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.estado.Size = New System.Drawing.Size(859, 17)
		Me.estado.Location = New System.Drawing.Point(0, 421)
		Me.estado.TabIndex = 0
		Me.estado.Name = "estado"
		Me._estado_Panel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
		Me._estado_Panel1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me._estado_Panel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._estado_Panel1.ToolTipText = "Total de registros"
		Me._estado_Panel1.BorderSides = CType(System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom, System.Windows.Forms.ToolStripStatusLabelBorderSides)
		Me._estado_Panel1.Margin = New System.Windows.Forms.Padding(0)
		Me._estado_Panel1.Size = New System.Drawing.Size(96, 17)
		Me._estado_Panel1.AutoSize = False
		Me._estado_Panel2.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
		Me._estado_Panel2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me._estado_Panel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._estado_Panel2.BorderSides = CType(System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom, System.Windows.Forms.ToolStripStatusLabelBorderSides)
		Me._estado_Panel2.Margin = New System.Windows.Forms.Padding(0)
		Me._estado_Panel2.Size = New System.Drawing.Size(96, 17)
		Me._estado_Panel2.AutoSize = False
		Me._estado_Panel3.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
		Me._estado_Panel3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
		Me._estado_Panel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._estado_Panel3.BorderSides = CType(System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom, System.Windows.Forms.ToolStripStatusLabelBorderSides)
		Me._estado_Panel3.Margin = New System.Windows.Forms.Padding(0)
		Me._estado_Panel3.Size = New System.Drawing.Size(96, 17)
		Me._estado_Panel3.AutoSize = False
		CType(Me.malla, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Controls.Add(malla)
		Me.Controls.Add(estado)
		Me.estado.Items.AddRange(New System.Windows.Forms.ToolStripItem(){Me._estado_Panel1})
		Me.estado.Items.AddRange(New System.Windows.Forms.ToolStripItem(){Me._estado_Panel2})
		Me.estado.Items.AddRange(New System.Windows.Forms.ToolStripItem(){Me._estado_Panel3})
		Me.estado.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class