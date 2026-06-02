<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeterioroRev
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDeterioroRev))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnImportar = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnPropiedades = New System.Windows.Forms.ToolStripButton()
        Me.btnImprime = New System.Windows.Forms.ToolStripSplitButton()
        Me.EnviarAExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnviarAWordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnviarAPdfToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnviarAExelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnPorcDet = New System.Windows.Forms.ToolStripButton()
        Me.btnPorcReval = New System.Windows.Forms.ToolStripButton()
        Me.btnDepreciar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.gridDatos = New System.Windows.Forms.DataGridView()
        Me.txtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.mnuMouse = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DepreciacionesAnualesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.gridDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuMouse.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnImportar, Me.btnGuardar, Me.ToolStripSeparator1, Me.btnPropiedades, Me.btnImprime, Me.btnPorcDet, Me.btnPorcReval, Me.btnDepreciar, Me.ToolStripSeparator2, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(904, 38)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnImportar
        '
        Me.btnImportar.Image = Global.BuscadorActivosFijos.My.Resources.Resources.Contenido
        Me.btnImportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(37, 35)
        Me.btnImportar.Text = "&Abrir"
        Me.btnImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.BuscadorActivosFijos.My.Resources.Resources.grabar
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(53, 35)
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnGuardar.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 38)
        '
        'btnPropiedades
        '
        Me.btnPropiedades.Image = CType(resources.GetObject("btnPropiedades.Image"), System.Drawing.Image)
        Me.btnPropiedades.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPropiedades.Name = "btnPropiedades"
        Me.btnPropiedades.Size = New System.Drawing.Size(65, 35)
        Me.btnPropiedades.Text = "&Propiedad"
        Me.btnPropiedades.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnPropiedades.Visible = False
        '
        'btnImprime
        '
        Me.btnImprime.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnviarAExcelToolStripMenuItem, Me.EnviarAWordToolStripMenuItem, Me.EnviarAPdfToolStripMenuItem, Me.EnviarAExelToolStripMenuItem})
        Me.btnImprime.Image = CType(resources.GetObject("btnImprime.Image"), System.Drawing.Image)
        Me.btnImprime.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImprime.Name = "btnImprime"
        Me.btnImprime.Size = New System.Drawing.Size(55, 35)
        Me.btnImprime.Text = "&Enviar"
        Me.btnImprime.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'EnviarAExcelToolStripMenuItem
        '
        Me.EnviarAExcelToolStripMenuItem.Image = Global.BuscadorActivosFijos.My.Resources.Resources.Printer_Green
        Me.EnviarAExcelToolStripMenuItem.Name = "EnviarAExcelToolStripMenuItem"
        Me.EnviarAExcelToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.EnviarAExcelToolStripMenuItem.Text = "Imprimir"
        '
        'EnviarAWordToolStripMenuItem
        '
        Me.EnviarAWordToolStripMenuItem.Image = Global.BuscadorActivosFijos.My.Resources.Resources.doc_excel_table
        Me.EnviarAWordToolStripMenuItem.Name = "EnviarAWordToolStripMenuItem"
        Me.EnviarAWordToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.EnviarAWordToolStripMenuItem.Text = "Enviar a Excel"
        '
        'EnviarAPdfToolStripMenuItem
        '
        Me.EnviarAPdfToolStripMenuItem.Image = Global.BuscadorActivosFijos.My.Resources.Resources.page_word
        Me.EnviarAPdfToolStripMenuItem.Name = "EnviarAPdfToolStripMenuItem"
        Me.EnviarAPdfToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.EnviarAPdfToolStripMenuItem.Text = "Enviar a Word"
        '
        'EnviarAExelToolStripMenuItem
        '
        Me.EnviarAExelToolStripMenuItem.Image = Global.BuscadorActivosFijos.My.Resources.Resources.page_white_acrobat
        Me.EnviarAExelToolStripMenuItem.Name = "EnviarAExelToolStripMenuItem"
        Me.EnviarAExelToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.EnviarAExelToolStripMenuItem.Text = "Enviar a Pdf"
        '
        'btnPorcDet
        '
        Me.btnPorcDet.Image = CType(resources.GetObject("btnPorcDet.Image"), System.Drawing.Image)
        Me.btnPorcDet.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPorcDet.Name = "btnPorcDet"
        Me.btnPorcDet.Size = New System.Drawing.Size(55, 35)
        Me.btnPorcDet.Text = "Calc.&Det"
        Me.btnPorcDet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnPorcDet.ToolTipText = "Cálculo de Deterioro"
        Me.btnPorcDet.Visible = False
        '
        'btnPorcReval
        '
        Me.btnPorcReval.Image = CType(resources.GetObject("btnPorcReval.Image"), System.Drawing.Image)
        Me.btnPorcReval.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPorcReval.Name = "btnPorcReval"
        Me.btnPorcReval.Size = New System.Drawing.Size(56, 35)
        Me.btnPorcReval.Text = "Calc.&Rev"
        Me.btnPorcReval.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnPorcReval.ToolTipText = "Cálculo de Revalorización"
        Me.btnPorcReval.Visible = False
        '
        'btnDepreciar
        '
        Me.btnDepreciar.Image = CType(resources.GetObject("btnDepreciar.Image"), System.Drawing.Image)
        Me.btnDepreciar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDepreciar.Name = "btnDepreciar"
        Me.btnDepreciar.Size = New System.Drawing.Size(61, 35)
        Me.btnDepreciar.Text = "D&epreciar"
        Me.btnDepreciar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnDepreciar.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 38)
        '
        'btnSalir
        '
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(33, 35)
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'gridDatos
        '
        Me.gridDatos.AllowUserToAddRows = False
        Me.gridDatos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridDatos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gridDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridDatos.DefaultCellStyle = DataGridViewCellStyle2
        Me.gridDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridDatos.EnableHeadersVisualStyles = False
        Me.gridDatos.Location = New System.Drawing.Point(0, 38)
        Me.gridDatos.Name = "gridDatos"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridDatos.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.gridDatos.Size = New System.Drawing.Size(904, 477)
        Me.gridDatos.TabIndex = 2
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(795, 12)
        Me.txtFecha.Mask = "00/00/0000"
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(70, 20)
        Me.txtFecha.TabIndex = 0
        Me.txtFecha.ValidatingType = GetType(Date)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(727, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Fecha:"
        '
        'mnuMouse
        '
        Me.mnuMouse.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DepreciacionesAnualesToolStripMenuItem})
        Me.mnuMouse.Name = "mnuMouse"
        Me.mnuMouse.ShowImageMargin = False
        Me.mnuMouse.Size = New System.Drawing.Size(175, 26)
        '
        'DepreciacionesAnualesToolStripMenuItem
        '
        Me.DepreciacionesAnualesToolStripMenuItem.Name = "DepreciacionesAnualesToolStripMenuItem"
        Me.DepreciacionesAnualesToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.DepreciacionesAnualesToolStripMenuItem.Text = "Depreciaciones Anuales"
        '
        'frmDeterioroRev
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(904, 515)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.gridDatos)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frmDeterioroRev"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Revalorización y Deterioro"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.gridDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuMouse.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnPropiedades As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnImportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents gridDatos As System.Windows.Forms.DataGridView
    Friend WithEvents txtFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnPorcDet As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPorcReval As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDepreciar As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents mnuMouse As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DepreciacionesAnualesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnImprime As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents EnviarAExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnviarAWordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnviarAPdfToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnviarAExelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
