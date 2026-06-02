<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNivAcf
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNivAcf))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btnAgrupar = New System.Windows.Forms.ToolStripButton()
        Me.btnImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboNivel = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.malla = New System.Windows.Forms.DataGridView()
        Me.Abreviacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdCta1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idcta2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idcta3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Grafico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Imagen = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.malla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.btnAgrupar, Me.btnImprimir, Me.ToolStripSeparator1, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1288, 47)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(66, 44)
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnAgrupar
        '
        Me.btnAgrupar.Image = CType(resources.GetObject("btnAgrupar.Image"), System.Drawing.Image)
        Me.btnAgrupar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAgrupar.Name = "btnAgrupar"
        Me.btnAgrupar.Size = New System.Drawing.Size(67, 44)
        Me.btnAgrupar.Text = "Agrupar"
        Me.btnAgrupar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnAgrupar.ToolTipText = "Agrupar Artículos"
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(70, 44)
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 47)
        '
        'btnSalir
        '
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(42, 44)
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cboNivel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 47)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1288, 33)
        Me.Panel1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Escoja el Nivel:"
        '
        'cboNivel
        '
        Me.cboNivel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNivel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboNivel.FormattingEnabled = True
        Me.cboNivel.Items.AddRange(New Object() {"CATEGORIA", "CLASE", "GRUPO", "SUBGRUPO"})
        Me.cboNivel.Location = New System.Drawing.Point(149, 4)
        Me.cboNivel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboNivel.Name = "cboNivel"
        Me.cboNivel.Size = New System.Drawing.Size(220, 24)
        Me.cboNivel.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.malla)
        Me.Panel2.Location = New System.Drawing.Point(0, 75)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1016, 315)
        Me.Panel2.TabIndex = 2
        '
        'malla
        '
        Me.malla.AllowUserToResizeColumns = False
        Me.malla.AllowUserToResizeRows = False
        Me.malla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.malla.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.malla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.malla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.malla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Abreviacion, Me.Descripcion, Me.IdCta1, Me.idcta2, Me.idcta3, Me.Grafico})
        Me.malla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.malla.EnableHeadersVisualStyles = False
        Me.malla.Location = New System.Drawing.Point(0, 0)
        Me.malla.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.malla.Name = "malla"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.malla.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.malla.RowHeadersWidth = 25
        Me.malla.Size = New System.Drawing.Size(1016, 315)
        Me.malla.TabIndex = 3
        '
        'Abreviacion
        '
        Me.Abreviacion.HeaderText = "Abreviación"
        Me.Abreviacion.MaxInputLength = 5
        Me.Abreviacion.MinimumWidth = 6
        Me.Abreviacion.Name = "Abreviacion"
        Me.Abreviacion.Width = 111
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.MaxInputLength = 40
        Me.Descripcion.MinimumWidth = 6
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.Width = 111
        '
        'IdCta1
        '
        Me.IdCta1.HeaderText = "Id.Contable-1"
        Me.IdCta1.MaxInputLength = 15
        Me.IdCta1.MinimumWidth = 6
        Me.IdCta1.Name = "IdCta1"
        Me.IdCta1.Width = 121
        '
        'idcta2
        '
        Me.idcta2.HeaderText = "Id.Contable-2"
        Me.idcta2.MaxInputLength = 15
        Me.idcta2.MinimumWidth = 6
        Me.idcta2.Name = "idcta2"
        Me.idcta2.Width = 121
        '
        'idcta3
        '
        Me.idcta3.HeaderText = "Id.Contable-3"
        Me.idcta3.MaxInputLength = 15
        Me.idcta3.MinimumWidth = 6
        Me.idcta3.Name = "idcta3"
        Me.idcta3.Width = 121
        '
        'Grafico
        '
        Me.Grafico.HeaderText = "Grafico"
        Me.Grafico.MinimumWidth = 6
        Me.Grafico.Name = "Grafico"
        Me.Grafico.Visible = False
        Me.Grafico.Width = 125
        '
        'Imagen
        '
        Me.Imagen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Imagen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Imagen.Location = New System.Drawing.Point(1024, 158)
        Me.Imagen.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Imagen.Name = "Imagen"
        Me.Imagen.Size = New System.Drawing.Size(261, 237)
        Me.Imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Imagen.TabIndex = 3
        Me.Imagen.TabStop = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1123, 113)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Imagen:"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'FrmNivAcf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(1288, 395)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Imagen)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FrmNivAcf"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Administración de Niveles de Activos"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.malla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Imagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cboNivel As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents malla As System.Windows.Forms.DataGridView
    Friend WithEvents Imagen As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnAgrupar As System.Windows.Forms.ToolStripButton
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents Abreviacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdCta1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idcta2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idcta3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Grafico As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
