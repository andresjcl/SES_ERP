<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class CTBP01
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
    Public WithEvents nueva As System.Windows.Forms.ToolStripButton
    Public WithEvents insertar As System.Windows.Forms.ToolStripButton
    Public WithEvents modificar As System.Windows.Forms.ToolStripButton
    Public WithEvents eliminar As System.Windows.Forms.ToolStripButton
    Public WithEvents listado As System.Windows.Forms.ToolStripButton
    Public WithEvents salir As System.Windows.Forms.ToolStripButton
    Public WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Public WithEvents imlSmallIcons As System.Windows.Forms.ImageList
    Public WithEvents trArbol As System.Windows.Forms.TreeView
    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar mediante el Diseñador de Windows Forms.
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CTBP01))
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Nodo0")
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.imlSmallIcons = New System.Windows.Forms.ImageList(Me.components)
        Me.nueva = New System.Windows.Forms.ToolStripButton()
        Me.insertar = New System.Windows.Forms.ToolStripButton()
        Me.modificar = New System.Windows.Forms.ToolStripButton()
        Me.eliminar = New System.Windows.Forms.ToolStripButton()
        Me.listado = New System.Windows.Forms.ToolStripButton()
        Me.Validar = New System.Windows.Forms.ToolStripButton()
        Me.salir = New System.Windows.Forms.ToolStripButton()
        Me.trArbol = New System.Windows.Forms.TreeView()
        Me.Toolbar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Toolbar1
        '
        Me.Toolbar1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Toolbar1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Toolbar1.ImageList = Me.imlSmallIcons
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.nueva, Me.insertar, Me.modificar, Me.eliminar, Me.listado, Me.Validar, Me.salir})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.Toolbar1.Size = New System.Drawing.Size(923, 59)
        Me.Toolbar1.TabIndex = 1
        '
        'imlSmallIcons
        '
        Me.imlSmallIcons.ImageStream = CType(resources.GetObject("imlSmallIcons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlSmallIcons.TransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.imlSmallIcons.Images.SetKeyName(0, "")
        Me.imlSmallIcons.Images.SetKeyName(1, "")
        Me.imlSmallIcons.Images.SetKeyName(2, "")
        Me.imlSmallIcons.Images.SetKeyName(3, "")
        Me.imlSmallIcons.Images.SetKeyName(4, "")
        Me.imlSmallIcons.Images.SetKeyName(5, "imgnueva")
        Me.imlSmallIcons.Images.SetKeyName(6, "imginsertar")
        Me.imlSmallIcons.Images.SetKeyName(7, "imgmodificar")
        Me.imlSmallIcons.Images.SetKeyName(8, "imgeliminar")
        Me.imlSmallIcons.Images.SetKeyName(9, "imglista")
        Me.imlSmallIcons.Images.SetKeyName(10, "imgsalir")
        Me.imlSmallIcons.Images.SetKeyName(11, "seleccionado.gif")
        '
        'nueva
        '
        Me.nueva.ForeColor = System.Drawing.Color.White
        Me.nueva.Image = CType(resources.GetObject("nueva.Image"), System.Drawing.Image)
        Me.nueva.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.nueva.Name = "nueva"
        Me.nueva.Size = New System.Drawing.Size(55, 56)
        Me.nueva.Text = "&Nueva"
        Me.nueva.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.nueva.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.nueva.ToolTipText = "Crear nueva cuenta al mismo nivel"
        '
        'insertar
        '
        Me.insertar.ForeColor = System.Drawing.Color.White
        Me.insertar.Image = CType(resources.GetObject("insertar.Image"), System.Drawing.Image)
        Me.insertar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.insertar.Name = "insertar"
        Me.insertar.Size = New System.Drawing.Size(62, 56)
        Me.insertar.Text = "&Insertar"
        Me.insertar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.insertar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.insertar.ToolTipText = "Crear nueva cuenta en el nivel inferior"
        '
        'modificar
        '
        Me.modificar.ForeColor = System.Drawing.Color.White
        Me.modificar.Image = CType(resources.GetObject("modificar.Image"), System.Drawing.Image)
        Me.modificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.modificar.Name = "modificar"
        Me.modificar.Size = New System.Drawing.Size(77, 56)
        Me.modificar.Text = "&Modificar"
        Me.modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.modificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.modificar.ToolTipText = "Cambiar datos de la cunta existente"
        '
        'eliminar
        '
        Me.eliminar.ForeColor = System.Drawing.Color.White
        Me.eliminar.Image = CType(resources.GetObject("eliminar.Image"), System.Drawing.Image)
        Me.eliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.eliminar.Name = "eliminar"
        Me.eliminar.Size = New System.Drawing.Size(67, 56)
        Me.eliminar.Text = "&Eliminar"
        Me.eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.eliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.eliminar.ToolTipText = "Elimina la cuenta contable"
        '
        'listado
        '
        Me.listado.ForeColor = System.Drawing.Color.White
        Me.listado.Image = CType(resources.GetObject("listado.Image"), System.Drawing.Image)
        Me.listado.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.listado.Name = "listado"
        Me.listado.Size = New System.Drawing.Size(43, 56)
        Me.listado.Text = "&Lista"
        Me.listado.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.listado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.listado.ToolTipText = "Lista del plan de cuentas"
        '
        'Validar
        '
        Me.Validar.ForeColor = System.Drawing.Color.White
        Me.Validar.Image = CType(resources.GetObject("Validar.Image"), System.Drawing.Image)
        Me.Validar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Validar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Validar.Name = "Validar"
        Me.Validar.Size = New System.Drawing.Size(54, 56)
        Me.Validar.Text = "&Valida"
        Me.Validar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Validar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Validar.ToolTipText = "Buscar inconsistencias en el plan de cuentas"
        '
        'salir
        '
        Me.salir.ForeColor = System.Drawing.Color.White
        Me.salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.salir.ImageKey = "imgsalir"
        Me.salir.Name = "salir"
        Me.salir.Size = New System.Drawing.Size(42, 56)
        Me.salir.Text = "&Salir"
        Me.salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'trArbol
        '
        Me.trArbol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.trArbol.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trArbol.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.trArbol.ImageKey = "seleccionado.gif"
        Me.trArbol.ImageList = Me.imlSmallIcons
        Me.trArbol.Indent = 40
        Me.trArbol.LineColor = System.Drawing.Color.SteelBlue
        Me.trArbol.Location = New System.Drawing.Point(0, 59)
        Me.trArbol.Margin = New System.Windows.Forms.Padding(4)
        Me.trArbol.Name = "trArbol"
        TreeNode1.Name = "Nodo0"
        TreeNode1.Text = "Nodo0"
        Me.trArbol.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.trArbol.RightToLeftLayout = True
        Me.trArbol.SelectedImageKey = "seleccionado.gif"
        Me.trArbol.ShowLines = False
        Me.trArbol.ShowPlusMinus = False
        Me.trArbol.Size = New System.Drawing.Size(923, 598)
        Me.trArbol.TabIndex = 0
        '
        'CTBP01
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(923, 657)
        Me.ControlBox = False
        Me.Controls.Add(Me.trArbol)
        Me.Controls.Add(Me.Toolbar1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(4, -135)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "CTBP01"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "MANTENIMIENTO DEL PLAN DE CUENTAS CONTABLES"
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Validar As System.Windows.Forms.ToolStripButton
#End Region 
End Class