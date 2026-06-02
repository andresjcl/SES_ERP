<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class CTBP21
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
    Public WithEvents ImageList1 As System.Windows.Forms.ImageList
    Public WithEvents btnactualizar As System.Windows.Forms.ToolStripButton
    Public WithEvents btnsalir As System.Windows.Forms.ToolStripButton
    Public WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar mediante el Diseñador de Windows Forms.
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CTBP21))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.Nivel = New System.Windows.Forms.ToolStripSplitButton()
        Me.Nivel6ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Nivel5ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Nivel4ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Nivel3ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Nivel2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Nivel1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CuentaCtas = New System.Windows.Forms.ToolStripSplitButton()
        Me.todas = New System.Windows.Forms.ToolStripMenuItem()
        Me.movimiento = New System.Windows.Forms.ToolStripMenuItem()
        Me.comodines = New System.Windows.Forms.ToolStripMenuItem()
        Me.clasificadores = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnactualizar = New System.Windows.Forms.ToolStripButton()
        Me.btnimprimir = New System.Windows.Forms.ToolStripSplitButton()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PDFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnsalir = New System.Windows.Forms.ToolStripButton()
        Me.MALLA = New System.Windows.Forms.DataGridView()
        Me.Toolbar1.SuspendLayout()
        CType(Me.MALLA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ImageList1.Images.SetKeyName(0, "imgactualizar")
        Me.ImageList1.Images.SetKeyName(1, "imgimprimir")
        Me.ImageList1.Images.SetKeyName(2, "imgsalir")
        '
        'Toolbar1
        '
        Me.Toolbar1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Toolbar1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Toolbar1.ImageList = Me.ImageList1
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Nivel, Me.CuentaCtas, Me.btnactualizar, Me.btnimprimir, Me.btnsalir})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(968, 59)
        Me.Toolbar1.TabIndex = 13
        '
        'Nivel
        '
        Me.Nivel.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Nivel6ToolStripMenuItem, Me.Nivel5ToolStripMenuItem, Me.Nivel4ToolStripMenuItem, Me.Nivel3ToolStripMenuItem, Me.Nivel2ToolStripMenuItem, Me.Nivel1ToolStripMenuItem})
        Me.Nivel.ForeColor = System.Drawing.Color.White
        Me.Nivel.Image = CType(resources.GetObject("Nivel.Image"), System.Drawing.Image)
        Me.Nivel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Nivel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Nivel.Name = "Nivel"
        Me.Nivel.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.Nivel.Size = New System.Drawing.Size(76, 56)
        Me.Nivel.Text = "Nivel-6"
        Me.Nivel.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Nivel.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.Nivel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Nivel.ToolTipText = "Imprimir hasta el nivel deseado"
        '
        'Nivel6ToolStripMenuItem
        '
        Me.Nivel6ToolStripMenuItem.Name = "Nivel6ToolStripMenuItem"
        Me.Nivel6ToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.Nivel6ToolStripMenuItem.Text = "Nivel-6"
        '
        'Nivel5ToolStripMenuItem
        '
        Me.Nivel5ToolStripMenuItem.Name = "Nivel5ToolStripMenuItem"
        Me.Nivel5ToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.Nivel5ToolStripMenuItem.Text = "Nivel-5"
        '
        'Nivel4ToolStripMenuItem
        '
        Me.Nivel4ToolStripMenuItem.Name = "Nivel4ToolStripMenuItem"
        Me.Nivel4ToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.Nivel4ToolStripMenuItem.Text = "Nivel-4"
        '
        'Nivel3ToolStripMenuItem
        '
        Me.Nivel3ToolStripMenuItem.Name = "Nivel3ToolStripMenuItem"
        Me.Nivel3ToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.Nivel3ToolStripMenuItem.Text = "Nivel-3"
        '
        'Nivel2ToolStripMenuItem
        '
        Me.Nivel2ToolStripMenuItem.Name = "Nivel2ToolStripMenuItem"
        Me.Nivel2ToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.Nivel2ToolStripMenuItem.Text = "Nivel-2"
        '
        'Nivel1ToolStripMenuItem
        '
        Me.Nivel1ToolStripMenuItem.Name = "Nivel1ToolStripMenuItem"
        Me.Nivel1ToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.Nivel1ToolStripMenuItem.Text = "Nivel-1"
        '
        'CuentaCtas
        '
        Me.CuentaCtas.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.todas, Me.movimiento, Me.comodines, Me.clasificadores})
        Me.CuentaCtas.ForeColor = System.Drawing.Color.White
        Me.CuentaCtas.Image = CType(resources.GetObject("CuentaCtas.Image"), System.Drawing.Image)
        Me.CuentaCtas.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CuentaCtas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CuentaCtas.Name = "CuentaCtas"
        Me.CuentaCtas.Size = New System.Drawing.Size(67, 56)
        Me.CuentaCtas.Text = "Todas"
        Me.CuentaCtas.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CuentaCtas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.CuentaCtas.ToolTipText = "Todas las Cuentas"
        '
        'todas
        '
        Me.todas.Name = "todas"
        Me.todas.Size = New System.Drawing.Size(224, 26)
        Me.todas.Text = "Ctas.Todas"
        '
        'movimiento
        '
        Me.movimiento.Name = "movimiento"
        Me.movimiento.Size = New System.Drawing.Size(224, 26)
        Me.movimiento.Text = "Ctas.Movimiento"
        '
        'comodines
        '
        Me.comodines.Name = "comodines"
        Me.comodines.Size = New System.Drawing.Size(224, 26)
        Me.comodines.Text = "Comodines"
        '
        'clasificadores
        '
        Me.clasificadores.Name = "clasificadores"
        Me.clasificadores.Size = New System.Drawing.Size(224, 26)
        Me.clasificadores.Text = "ConClasificadores"
        '
        'btnactualizar
        '
        Me.btnactualizar.ForeColor = System.Drawing.Color.White
        Me.btnactualizar.Image = CType(resources.GetObject("btnactualizar.Image"), System.Drawing.Image)
        Me.btnactualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnactualizar.Name = "btnactualizar"
        Me.btnactualizar.Size = New System.Drawing.Size(79, 56)
        Me.btnactualizar.Text = "&Actualizar"
        Me.btnactualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnimprimir
        '
        Me.btnimprimir.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimirToolStripMenuItem, Me.WordToolStripMenuItem, Me.ExcelToolStripMenuItem, Me.PDFToolStripMenuItem})
        Me.btnimprimir.ForeColor = System.Drawing.Color.White
        Me.btnimprimir.Image = CType(resources.GetObject("btnimprimir.Image"), System.Drawing.Image)
        Me.btnimprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnimprimir.Name = "btnimprimir"
        Me.btnimprimir.Size = New System.Drawing.Size(68, 56)
        Me.btnimprimir.Text = "&Enviar"
        Me.btnimprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.ImprimirToolStripMenuItem.Text = "Imprimir"
        '
        'WordToolStripMenuItem
        '
        Me.WordToolStripMenuItem.Name = "WordToolStripMenuItem"
        Me.WordToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.WordToolStripMenuItem.Text = "Word"
        '
        'ExcelToolStripMenuItem
        '
        Me.ExcelToolStripMenuItem.Name = "ExcelToolStripMenuItem"
        Me.ExcelToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.ExcelToolStripMenuItem.Text = "Excel"
        '
        'PDFToolStripMenuItem
        '
        Me.PDFToolStripMenuItem.Name = "PDFToolStripMenuItem"
        Me.PDFToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.PDFToolStripMenuItem.Text = "PDF"
        '
        'btnsalir
        '
        Me.btnsalir.ForeColor = System.Drawing.Color.White
        Me.btnsalir.Image = CType(resources.GetObject("btnsalir.Image"), System.Drawing.Image)
        Me.btnsalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(42, 56)
        Me.btnsalir.Text = "&Salir"
        Me.btnsalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MALLA
        '
        Me.MALLA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.MALLA.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MALLA.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.MALLA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.MALLA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MALLA.EnableHeadersVisualStyles = False
        Me.MALLA.GridColor = System.Drawing.Color.Gainsboro
        Me.MALLA.Location = New System.Drawing.Point(0, 59)
        Me.MALLA.Margin = New System.Windows.Forms.Padding(4)
        Me.MALLA.Name = "MALLA"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSlateGray
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MALLA.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.MALLA.RowHeadersWidth = 21
        Me.MALLA.Size = New System.Drawing.Size(968, 659)
        Me.MALLA.TabIndex = 14
        '
        'CTBP21
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(968, 718)
        Me.ControlBox = False
        Me.Controls.Add(Me.MALLA)
        Me.Controls.Add(Me.Toolbar1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "CTBP21"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "LISTADO DEL PLAN DE CUENTAS"
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.MALLA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Nivel As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents Nivel1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Nivel2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Nivel3ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Nivel4ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Nivel5ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Nivel6ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CuentaCtas As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents movimiento As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents todas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents comodines As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents clasificadores As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MALLA As System.Windows.Forms.DataGridView
    Public WithEvents btnimprimir As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PDFToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
#End Region 
End Class