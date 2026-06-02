<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmComponentes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmComponentes))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnPropiedades = New System.Windows.Forms.ToolStripButton()
        Me.btnEnviar = New System.Windows.Forms.ToolStripSplitButton()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnviarAExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnviarAWordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.gridListado = New System.Windows.Forms.DataGridView()
        Me.MnuMouse = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DepreciacionesAnualesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SepararComponenteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.gridListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MnuMouse.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnPropiedades, Me.btnEnviar, Me.ToolStripSeparator1, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(833, 38)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnPropiedades
        '
        Me.btnPropiedades.Image = CType(resources.GetObject("btnPropiedades.Image"), System.Drawing.Image)
        Me.btnPropiedades.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPropiedades.Name = "btnPropiedades"
        Me.btnPropiedades.Size = New System.Drawing.Size(76, 35)
        Me.btnPropiedades.Text = "Propiedades"
        Me.btnPropiedades.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnEnviar
        '
        Me.btnEnviar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimirToolStripMenuItem, Me.EnviarAExcelToolStripMenuItem, Me.EnviarAWordToolStripMenuItem, Me.EnToolStripMenuItem})
        Me.btnEnviar.Image = CType(resources.GetObject("btnEnviar.Image"), System.Drawing.Image)
        Me.btnEnviar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(55, 35)
        Me.btnEnviar.Text = "Enviar"
        Me.btnEnviar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Image = Global.MostrarComponentes.My.Resources.Resources.Printer_Green
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.ImprimirToolStripMenuItem.Text = "Imprimir"
        '
        'EnviarAExcelToolStripMenuItem
        '
        Me.EnviarAExcelToolStripMenuItem.Image = Global.MostrarComponentes.My.Resources.Resources.doc_excel_table
        Me.EnviarAExcelToolStripMenuItem.Name = "EnviarAExcelToolStripMenuItem"
        Me.EnviarAExcelToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.EnviarAExcelToolStripMenuItem.Text = "Exportar a Excel"
        '
        'EnviarAWordToolStripMenuItem
        '
        Me.EnviarAWordToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.EnviarAWordToolStripMenuItem.Image = Global.MostrarComponentes.My.Resources.Resources.page_word
        Me.EnviarAWordToolStripMenuItem.Name = "EnviarAWordToolStripMenuItem"
        Me.EnviarAWordToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.EnviarAWordToolStripMenuItem.Text = "Exportar a Word"
        '
        'EnToolStripMenuItem
        '
        Me.EnToolStripMenuItem.Image = Global.MostrarComponentes.My.Resources.Resources.page_white_acrobat
        Me.EnToolStripMenuItem.Name = "EnToolStripMenuItem"
        Me.EnToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.EnToolStripMenuItem.Text = "Exportar a PDF"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 38)
        '
        'btnSalir
        '
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(33, 35)
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'gridListado
        '
        Me.gridListado.AllowUserToAddRows = False
        Me.gridListado.AllowUserToDeleteRows = False
        Me.gridListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridListado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridListado.EnableHeadersVisualStyles = False
        Me.gridListado.Location = New System.Drawing.Point(0, 38)
        Me.gridListado.Name = "gridListado"
        Me.gridListado.ReadOnly = True
        Me.gridListado.Size = New System.Drawing.Size(833, 418)
        Me.gridListado.TabIndex = 1
        '
        'MnuMouse
        '
        Me.MnuMouse.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DepreciacionesAnualesToolStripMenuItem, Me.SepararComponenteToolStripMenuItem})
        Me.MnuMouse.Name = "ContextMenuStrip1"
        Me.MnuMouse.Size = New System.Drawing.Size(200, 48)
        '
        'DepreciacionesAnualesToolStripMenuItem
        '
        Me.DepreciacionesAnualesToolStripMenuItem.Name = "DepreciacionesAnualesToolStripMenuItem"
        Me.DepreciacionesAnualesToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.DepreciacionesAnualesToolStripMenuItem.Text = "Depreciaciones Anuales"
        '
        'SepararComponenteToolStripMenuItem
        '
        Me.SepararComponenteToolStripMenuItem.Name = "SepararComponenteToolStripMenuItem"
        Me.SepararComponenteToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.SepararComponenteToolStripMenuItem.Text = "Separar Componente"
        '
        'FrmComponentes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(833, 456)
        Me.Controls.Add(Me.gridListado)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrmComponentes"
        Me.Text = "Componentes del Activo"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.gridListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MnuMouse.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnPropiedades As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEnviar As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnviarAExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnviarAWordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents gridListado As System.Windows.Forms.DataGridView
    Friend WithEvents MnuMouse As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DepreciacionesAnualesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SepararComponenteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
