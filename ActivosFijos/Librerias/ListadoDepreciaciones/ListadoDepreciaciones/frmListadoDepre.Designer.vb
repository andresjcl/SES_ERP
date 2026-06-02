<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListadoDepre
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListadoDepre))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.cboTipo = New System.Windows.Forms.ToolStripComboBox()
        Me.btnImprimir = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnviarAExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnviarAWordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnviarAPdfToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.gridListado = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.gridListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cboTipo, Me.btnImprimir, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(909, 38)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'cboTipo
        '
        Me.cboTipo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(90, 38)
        '
        'btnImprimir
        '
        Me.btnImprimir.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimirToolStripMenuItem, Me.EnviarAExcelToolStripMenuItem, Me.EnviarAWordToolStripMenuItem, Me.EnviarAPdfToolStripMenuItem})
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(66, 35)
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Image = Global.ListadoDepreciaciones.My.Resources.Resources.Printer_Green
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ImprimirToolStripMenuItem.Text = "Imprimir"
        '
        'EnviarAExcelToolStripMenuItem
        '
        Me.EnviarAExcelToolStripMenuItem.Image = Global.ListadoDepreciaciones.My.Resources.Resources.doc_excel_table
        Me.EnviarAExcelToolStripMenuItem.Name = "EnviarAExcelToolStripMenuItem"
        Me.EnviarAExcelToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.EnviarAExcelToolStripMenuItem.Text = "Enviar a Excel"
        '
        'EnviarAWordToolStripMenuItem
        '
        Me.EnviarAWordToolStripMenuItem.Image = Global.ListadoDepreciaciones.My.Resources.Resources.page_word
        Me.EnviarAWordToolStripMenuItem.Name = "EnviarAWordToolStripMenuItem"
        Me.EnviarAWordToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.EnviarAWordToolStripMenuItem.Text = "Enviar a Word"
        '
        'EnviarAPdfToolStripMenuItem
        '
        Me.EnviarAPdfToolStripMenuItem.Image = Global.ListadoDepreciaciones.My.Resources.Resources.page_white_acrobat
        Me.EnviarAPdfToolStripMenuItem.Name = "EnviarAPdfToolStripMenuItem"
        Me.EnviarAPdfToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.EnviarAPdfToolStripMenuItem.Text = "Enviar a Pdf"
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
        'gridListado
        '
        Me.gridListado.AllowUserToAddRows = False
        Me.gridListado.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridListado.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gridListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridListado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridListado.EnableHeadersVisualStyles = False
        Me.gridListado.Location = New System.Drawing.Point(0, 38)
        Me.gridListado.Name = "gridListado"
        Me.gridListado.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridListado.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gridListado.Size = New System.Drawing.Size(909, 451)
        Me.gridListado.TabIndex = 1
        '
        'frmListadoDepre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(909, 489)
        Me.Controls.Add(Me.gridListado)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frmListadoDepre"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listado de Depreciaciones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.gridListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents gridListado As System.Windows.Forms.DataGridView
    Friend WithEvents cboTipo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnviarAExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnviarAWordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnviarAPdfToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
