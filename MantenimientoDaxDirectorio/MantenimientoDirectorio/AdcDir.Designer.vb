<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdcDir
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdcDir))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btnBusca = New System.Windows.Forms.ToolStripButton()
        Me.btnAbrir = New System.Windows.Forms.ToolStripButton()
        Me.btnTodos = New System.Windows.Forms.ToolStripSplitButton()
        Me.TodosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RelaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmpresasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRelacion = New System.Windows.Forms.ToolStripSplitButton()
        Me.TodasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProveedoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FinancieraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmpleadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VendedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DirectaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AsociaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEnviar = New System.Windows.Forms.ToolStripSplitButton()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PDFToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.MallaDat = New System.Windows.Forms.DataGridView()
        Me.PropiedadesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.EscogerColumnasToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Submenu = New System.Windows.Forms.ContextMenuStrip()
        Me.NuevoRegistroToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.MallaDat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Submenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.btnBusca, Me.btnAbrir, Me.btnTodos, Me.btnRelacion, Me.btnEnviar, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(777, 38)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnNuevo
        '
        Me.btnNuevo.ForeColor = System.Drawing.Color.White
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(46, 35)
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnBusca
        '
        Me.btnBusca.ForeColor = System.Drawing.Color.White
        Me.btnBusca.Image = CType(resources.GetObject("btnBusca.Image"), System.Drawing.Image)
        Me.btnBusca.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBusca.Name = "btnBusca"
        Me.btnBusca.Size = New System.Drawing.Size(42, 35)
        Me.btnBusca.Text = "Busca"
        Me.btnBusca.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnAbrir
        '
        Me.btnAbrir.ForeColor = System.Drawing.Color.White
        Me.btnAbrir.Image = CType(resources.GetObject("btnAbrir.Image"), System.Drawing.Image)
        Me.btnAbrir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.Size = New System.Drawing.Size(33, 35)
        Me.btnAbrir.Text = "Abir"
        Me.btnAbrir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnTodos
        '
        Me.btnTodos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TodosToolStripMenuItem, Me.RelaciónToolStripMenuItem, Me.EmpresasToolStripMenuItem})
        Me.btnTodos.ForeColor = System.Drawing.Color.White
        Me.btnTodos.Image = CType(resources.GetObject("btnTodos.Image"), System.Drawing.Image)
        Me.btnTodos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnTodos.Name = "btnTodos"
        Me.btnTodos.Size = New System.Drawing.Size(55, 35)
        Me.btnTodos.Text = "Todos"
        Me.btnTodos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'TodosToolStripMenuItem
        '
        Me.TodosToolStripMenuItem.Name = "TodosToolStripMenuItem"
        Me.TodosToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.TodosToolStripMenuItem.Text = "Todos"
        '
        'RelaciónToolStripMenuItem
        '
        Me.RelaciónToolStripMenuItem.Name = "RelaciónToolStripMenuItem"
        Me.RelaciónToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.RelaciónToolStripMenuItem.Text = "Personas"
        '
        'EmpresasToolStripMenuItem
        '
        Me.EmpresasToolStripMenuItem.Name = "EmpresasToolStripMenuItem"
        Me.EmpresasToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.EmpresasToolStripMenuItem.Text = "Empresas"
        '
        'btnRelacion
        '
        Me.btnRelacion.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TodasToolStripMenuItem, Me.ClientesToolStripMenuItem, Me.ProveedoresToolStripMenuItem, Me.FinancieraToolStripMenuItem, Me.EmpleadoToolStripMenuItem, Me.VendedorToolStripMenuItem, Me.DirectaToolStripMenuItem, Me.AsociaciónToolStripMenuItem})
        Me.btnRelacion.ForeColor = System.Drawing.Color.White
        Me.btnRelacion.Image = CType(resources.GetObject("btnRelacion.Image"), System.Drawing.Image)
        Me.btnRelacion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRelacion.Name = "btnRelacion"
        Me.btnRelacion.Size = New System.Drawing.Size(68, 35)
        Me.btnRelacion.Text = "Relación"
        Me.btnRelacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'TodasToolStripMenuItem
        '
        Me.TodasToolStripMenuItem.Name = "TodasToolStripMenuItem"
        Me.TodasToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.TodasToolStripMenuItem.Text = "Todas"
        '
        'ClientesToolStripMenuItem
        '
        Me.ClientesToolStripMenuItem.Name = "ClientesToolStripMenuItem"
        Me.ClientesToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.ClientesToolStripMenuItem.Text = "Clientes"
        '
        'ProveedoresToolStripMenuItem
        '
        Me.ProveedoresToolStripMenuItem.Name = "ProveedoresToolStripMenuItem"
        Me.ProveedoresToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.ProveedoresToolStripMenuItem.Text = "Proveedores"
        '
        'FinancieraToolStripMenuItem
        '
        Me.FinancieraToolStripMenuItem.Name = "FinancieraToolStripMenuItem"
        Me.FinancieraToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.FinancieraToolStripMenuItem.Text = "Financiera"
        '
        'EmpleadoToolStripMenuItem
        '
        Me.EmpleadoToolStripMenuItem.Name = "EmpleadoToolStripMenuItem"
        Me.EmpleadoToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.EmpleadoToolStripMenuItem.Text = "Empleado"
        '
        'VendedorToolStripMenuItem
        '
        Me.VendedorToolStripMenuItem.Name = "VendedorToolStripMenuItem"
        Me.VendedorToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.VendedorToolStripMenuItem.Text = "Vendedor"
        '
        'DirectaToolStripMenuItem
        '
        Me.DirectaToolStripMenuItem.Name = "DirectaToolStripMenuItem"
        Me.DirectaToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.DirectaToolStripMenuItem.Text = "Directa"
        '
        'AsociaciónToolStripMenuItem
        '
        Me.AsociaciónToolStripMenuItem.Name = "AsociaciónToolStripMenuItem"
        Me.AsociaciónToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.AsociaciónToolStripMenuItem.Text = "Asociación"
        '
        'btnEnviar
        '
        Me.btnEnviar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimirToolStripMenuItem, Me.ExcelToolStripMenuItem, Me.WordToolStripMenuItem, Me.PDFToolStripMenuItem1})
        Me.btnEnviar.ForeColor = System.Drawing.Color.White
        Me.btnEnviar.Image = CType(resources.GetObject("btnEnviar.Image"), System.Drawing.Image)
        Me.btnEnviar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(55, 35)
        Me.btnEnviar.Text = "Enviar"
        Me.btnEnviar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Image = CType(resources.GetObject("ImprimirToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.ImprimirToolStripMenuItem.Text = "Imprimir"
        '
        'ExcelToolStripMenuItem
        '
        Me.ExcelToolStripMenuItem.Image = CType(resources.GetObject("ExcelToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExcelToolStripMenuItem.Name = "ExcelToolStripMenuItem"
        Me.ExcelToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.ExcelToolStripMenuItem.Text = "Excel"
        '
        'WordToolStripMenuItem
        '
        Me.WordToolStripMenuItem.Image = CType(resources.GetObject("WordToolStripMenuItem.Image"), System.Drawing.Image)
        Me.WordToolStripMenuItem.Name = "WordToolStripMenuItem"
        Me.WordToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.WordToolStripMenuItem.Text = "Word"
        '
        'PDFToolStripMenuItem1
        '
        Me.PDFToolStripMenuItem1.Image = CType(resources.GetObject("PDFToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.PDFToolStripMenuItem1.Name = "PDFToolStripMenuItem1"
        Me.PDFToolStripMenuItem1.Size = New System.Drawing.Size(120, 22)
        Me.PDFToolStripMenuItem1.Text = "PDF"
        '
        'btnSalir
        '
        Me.btnSalir.ForeColor = System.Drawing.Color.White
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(33, 35)
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MallaDat
        '
        Me.MallaDat.AllowUserToAddRows = False
        Me.MallaDat.AllowUserToDeleteRows = False
        Me.MallaDat.AllowUserToOrderColumns = True
        Me.MallaDat.AllowUserToResizeRows = False
        Me.MallaDat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.MallaDat.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MallaDat.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.MallaDat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CornflowerBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.MallaDat.DefaultCellStyle = DataGridViewCellStyle2
        Me.MallaDat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MallaDat.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.MallaDat.Location = New System.Drawing.Point(0, 38)
        Me.MallaDat.Name = "MallaDat"
        Me.MallaDat.ReadOnly = True
        Me.MallaDat.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MallaDat.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.RoyalBlue
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        Me.MallaDat.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.MallaDat.Size = New System.Drawing.Size(777, 403)
        Me.MallaDat.TabIndex = 4
        '
        'PropiedadesToolStripMenuItem1
        '
        Me.PropiedadesToolStripMenuItem1.Name = "PropiedadesToolStripMenuItem1"
        Me.PropiedadesToolStripMenuItem1.Size = New System.Drawing.Size(172, 22)
        Me.PropiedadesToolStripMenuItem1.Text = "&Propiedades"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(169, 6)
        '
        'EscogerColumnasToolStripMenuItem1
        '
        Me.EscogerColumnasToolStripMenuItem1.Name = "EscogerColumnasToolStripMenuItem1"
        Me.EscogerColumnasToolStripMenuItem1.Size = New System.Drawing.Size(172, 22)
        Me.EscogerColumnasToolStripMenuItem1.Text = "&Escoger Columnas"
        '
        'BuscarToolStripMenuItem1
        '
        Me.BuscarToolStripMenuItem1.Name = "BuscarToolStripMenuItem1"
        Me.BuscarToolStripMenuItem1.Size = New System.Drawing.Size(172, 22)
        Me.BuscarToolStripMenuItem1.Text = "&Buscar"
        '
        'Submenu
        '
        Me.Submenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BuscarToolStripMenuItem1, Me.EscogerColumnasToolStripMenuItem1, Me.ToolStripSeparator2, Me.PropiedadesToolStripMenuItem1, Me.NuevoRegistroToolStripMenuItem1})
        Me.Submenu.Name = "ContextMenuStrip1"
        Me.Submenu.Size = New System.Drawing.Size(173, 98)
        '
        'NuevoRegistroToolStripMenuItem1
        '
        Me.NuevoRegistroToolStripMenuItem1.Name = "NuevoRegistroToolStripMenuItem1"
        Me.NuevoRegistroToolStripMenuItem1.Size = New System.Drawing.Size(172, 22)
        Me.NuevoRegistroToolStripMenuItem1.Text = "&Nuevo Registro"
        '
        'AdcDir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(777, 441)
        Me.Controls.Add(Me.MallaDat)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "AdcDir"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ADCOMDAX - LISTA DEL DIRECTORIO GENERAL"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.MallaDat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Submenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnBusca As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnAbrir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnTodos As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents TodosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RelaciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmpresasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnRelacion As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents TodasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClientesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProveedoresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FinancieraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmpleadoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VendedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DirectaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AsociaciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnEnviar As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PDFToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents MallaDat As System.Windows.Forms.DataGridView
    Friend WithEvents PropiedadesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EscogerColumnasToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Submenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NuevoRegistroToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
End Class
