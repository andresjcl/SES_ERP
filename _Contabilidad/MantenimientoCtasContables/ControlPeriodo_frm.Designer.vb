<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class ControlPeriodo
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
    Public WithEvents keycrear As System.Windows.Forms.ToolStripButton
    Public WithEvents keygrabar As System.Windows.Forms.ToolStripButton
    Public WithEvents keycancelar As System.Windows.Forms.ToolStripButton
    Public WithEvents keyeliminar As System.Windows.Forms.ToolStripButton
    Public WithEvents keyimprimir As System.Windows.Forms.ToolStripButton
    Public WithEvents _Toolbar1_Button6 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents keyactivar As System.Windows.Forms.ToolStripButton
    Public WithEvents keycerrar As System.Windows.Forms.ToolStripButton
    Public WithEvents btnExcepto As System.Windows.Forms.ToolStripButton
    Public WithEvents _Toolbar1_Button10 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents btnsalir As System.Windows.Forms.ToolStripButton
    Public WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar mediante el Diseñador de Windows Forms.
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ControlPeriodo))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.keycrear = New System.Windows.Forms.ToolStripButton()
        Me.keygrabar = New System.Windows.Forms.ToolStripButton()
        Me.keycancelar = New System.Windows.Forms.ToolStripButton()
        Me.keyimprimir = New System.Windows.Forms.ToolStripButton()
        Me.keyeliminar = New System.Windows.Forms.ToolStripButton()
        Me._Toolbar1_Button6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExcepto = New System.Windows.Forms.ToolStripButton()
        Me.keyactivar = New System.Windows.Forms.ToolStripButton()
        Me.keycerrar = New System.Windows.Forms.ToolStripButton()
        Me._Toolbar1_Button10 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnsalir = New System.Windows.Forms.ToolStripButton()
        Me.Malla = New System.Windows.Forms.DataGridView()
        Me.Toolbar1.SuspendLayout()
        CType(Me.Malla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ImageList1.Images.SetKeyName(0, "imgCancelar")
        Me.ImageList1.Images.SetKeyName(1, "imgEliminar")
        Me.ImageList1.Images.SetKeyName(2, "imgSalir")
        Me.ImageList1.Images.SetKeyName(3, "imgGuardar")
        Me.ImageList1.Images.SetKeyName(4, "imgCerrar")
        Me.ImageList1.Images.SetKeyName(5, "imgNuevo")
        Me.ImageList1.Images.SetKeyName(6, "imgAbrir")
        Me.ImageList1.Images.SetKeyName(7, "imgExcepto")
        Me.ImageList1.Images.SetKeyName(8, "imgExc")
        Me.ImageList1.Images.SetKeyName(9, "imgE")
        Me.ImageList1.Images.SetKeyName(10, "imgimprimir")
        '
        'Toolbar1
        '
        Me.Toolbar1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Toolbar1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Toolbar1.ImageList = Me.ImageList1
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.keycrear, Me.keygrabar, Me.keycancelar, Me.keyimprimir, Me.keyeliminar, Me._Toolbar1_Button6, Me.btnExcepto, Me.keyactivar, Me.keycerrar, Me._Toolbar1_Button10, Me.btnsalir})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(1000, 59)
        Me.Toolbar1.TabIndex = 1
        '
        'keycrear
        '
        Me.keycrear.ForeColor = System.Drawing.Color.White
        Me.keycrear.Image = CType(resources.GetObject("keycrear.Image"), System.Drawing.Image)
        Me.keycrear.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.keycrear.Name = "keycrear"
        Me.keycrear.Size = New System.Drawing.Size(48, 56)
        Me.keycrear.Text = "Crear"
        Me.keycrear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.keycrear.ToolTipText = "Crear periodos de un año"
        '
        'keygrabar
        '
        Me.keygrabar.ForeColor = System.Drawing.Color.White
        Me.keygrabar.Image = CType(resources.GetObject("keygrabar.Image"), System.Drawing.Image)
        Me.keygrabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.keygrabar.Name = "keygrabar"
        Me.keygrabar.Size = New System.Drawing.Size(66, 56)
        Me.keygrabar.Text = "Guardar"
        Me.keygrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.keygrabar.ToolTipText = "Guardar datos"
        '
        'keycancelar
        '
        Me.keycancelar.ForeColor = System.Drawing.Color.White
        Me.keycancelar.Image = CType(resources.GetObject("keycancelar.Image"), System.Drawing.Image)
        Me.keycancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.keycancelar.Name = "keycancelar"
        Me.keycancelar.Size = New System.Drawing.Size(70, 56)
        Me.keycancelar.Text = "Cancelar"
        Me.keycancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'keyimprimir
        '
        Me.keyimprimir.ForeColor = System.Drawing.Color.White
        Me.keyimprimir.Image = CType(resources.GetObject("keyimprimir.Image"), System.Drawing.Image)
        Me.keyimprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.keyimprimir.Name = "keyimprimir"
        Me.keyimprimir.Size = New System.Drawing.Size(70, 56)
        Me.keyimprimir.Text = "Imprimir"
        Me.keyimprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.keyimprimir.ToolTipText = "Imprimir malla de periodos"
        '
        'keyeliminar
        '
        Me.keyeliminar.ForeColor = System.Drawing.Color.White
        Me.keyeliminar.Image = CType(resources.GetObject("keyeliminar.Image"), System.Drawing.Image)
        Me.keyeliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.keyeliminar.Name = "keyeliminar"
        Me.keyeliminar.Size = New System.Drawing.Size(67, 56)
        Me.keyeliminar.Text = "Eliminar"
        Me.keyeliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.keyeliminar.ToolTipText = "Eliminar períodos de un año"
        '
        '_Toolbar1_Button6
        '
        Me._Toolbar1_Button6.ForeColor = System.Drawing.Color.White
        Me._Toolbar1_Button6.Name = "_Toolbar1_Button6"
        Me._Toolbar1_Button6.Size = New System.Drawing.Size(6, 59)
        '
        'btnExcepto
        '
        Me.btnExcepto.ForeColor = System.Drawing.Color.White
        Me.btnExcepto.Image = CType(resources.GetObject("btnExcepto.Image"), System.Drawing.Image)
        Me.btnExcepto.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExcepto.Name = "btnExcepto"
        Me.btnExcepto.Size = New System.Drawing.Size(66, 56)
        Me.btnExcepto.Text = "Excepto"
        Me.btnExcepto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnExcepto.ToolTipText = "Registrar usuarios con excepción"
        '
        'keyactivar
        '
        Me.keyactivar.ForeColor = System.Drawing.Color.White
        Me.keyactivar.Image = CType(resources.GetObject("keyactivar.Image"), System.Drawing.Image)
        Me.keyactivar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.keyactivar.Name = "keyactivar"
        Me.keyactivar.Size = New System.Drawing.Size(63, 56)
        Me.keyactivar.Text = "Abierto"
        Me.keyactivar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.keyactivar.ToolTipText = "Activar periodos marcados"
        '
        'keycerrar
        '
        Me.keycerrar.ForeColor = System.Drawing.Color.White
        Me.keycerrar.Image = CType(resources.GetObject("keycerrar.Image"), System.Drawing.Image)
        Me.keycerrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.keycerrar.Name = "keycerrar"
        Me.keycerrar.Size = New System.Drawing.Size(66, 56)
        Me.keycerrar.Text = "Cerrado"
        Me.keycerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.keycerrar.ToolTipText = "Cerrar periodos marcados"
        '
        '_Toolbar1_Button10
        '
        Me._Toolbar1_Button10.ForeColor = System.Drawing.Color.White
        Me._Toolbar1_Button10.Name = "_Toolbar1_Button10"
        Me._Toolbar1_Button10.Size = New System.Drawing.Size(6, 59)
        '
        'btnsalir
        '
        Me.btnsalir.ForeColor = System.Drawing.Color.White
        Me.btnsalir.Image = CType(resources.GetObject("btnsalir.Image"), System.Drawing.Image)
        Me.btnsalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(42, 56)
        Me.btnsalir.Text = "Salir"
        Me.btnsalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Malla
        '
        Me.Malla.AllowUserToAddRows = False
        Me.Malla.AllowUserToDeleteRows = False
        Me.Malla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Malla.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Malla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Malla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Malla.DefaultCellStyle = DataGridViewCellStyle2
        Me.Malla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Malla.GridColor = System.Drawing.Color.Gainsboro
        Me.Malla.Location = New System.Drawing.Point(0, 59)
        Me.Malla.Margin = New System.Windows.Forms.Padding(4)
        Me.Malla.Name = "Malla"
        Me.Malla.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Malla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Malla.RowHeadersWidth = 51
        Me.Malla.Size = New System.Drawing.Size(1000, 441)
        Me.Malla.TabIndex = 2
        '
        'ControlPeriodo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(1000, 500)
        Me.ControlBox = False
        Me.Controls.Add(Me.Malla)
        Me.Controls.Add(Me.Toolbar1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Location = New System.Drawing.Point(3, 22)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ControlPeriodo"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONTROL DE PERIODOS CONTABLES"
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        CType(Me.Malla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Malla As System.Windows.Forms.DataGridView
#End Region 
End Class