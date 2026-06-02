<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSuc
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSuc))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtPrecioVta = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnIdCont = New System.Windows.Forms.Button()
        Me.txtRuc = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabBod = New System.Windows.Forms.TabPage()
        Me.mallaBod = New System.Windows.Forms.DataGridView()
        Me.BOD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdCont = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabPto = New System.Windows.Forms.TabPage()
        Me.mallaPtoVta = New System.Windows.Forms.DataGridView()
        Me.PTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NomPto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idCtb = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdTrib = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoPunto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnSuc = New System.Windows.Forms.Button()
        Me.txtIdCont = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtIdTrib = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSegSoc = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDir = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNom = New System.Windows.Forms.TextBox()
        Me.txtSuc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEmpresa = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btnModificar = New System.Windows.Forms.ToolStripButton()
        Me.btnEliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabBod.SuspendLayout()
        CType(Me.mallaBod, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPto.SuspendLayout()
        CType(Me.mallaPtoVta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.DarkGray
        Me.GroupBox1.Controls.Add(Me.txtPrecioVta)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.btnIdCont)
        Me.GroupBox1.Controls.Add(Me.txtRuc)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TabControl1)
        Me.GroupBox1.Controls.Add(Me.btnSuc)
        Me.GroupBox1.Controls.Add(Me.txtIdCont)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtIdTrib)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtSegSoc)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtDir)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtNom)
        Me.GroupBox1.Controls.Add(Me.txtSuc)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtEmpresa)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(817, 373)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtPrecioVta
        '
        Me.txtPrecioVta.Location = New System.Drawing.Point(143, 227)
        Me.txtPrecioVta.Name = "txtPrecioVta"
        Me.txtPrecioVta.Size = New System.Drawing.Size(69, 20)
        Me.txtPrecioVta.TabIndex = 22
        Me.txtPrecioVta.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(6, 230)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(131, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Precio de venta asignado:"
        Me.Label9.Visible = False
        '
        'btnIdCont
        '
        Me.btnIdCont.BackColor = System.Drawing.Color.DimGray
        Me.btnIdCont.ForeColor = System.Drawing.Color.White
        Me.btnIdCont.Location = New System.Drawing.Point(209, 198)
        Me.btnIdCont.Name = "btnIdCont"
        Me.btnIdCont.Size = New System.Drawing.Size(21, 21)
        Me.btnIdCont.TabIndex = 20
        Me.btnIdCont.Text = "..."
        Me.btnIdCont.UseVisualStyleBackColor = False
        '
        'txtRuc
        '
        Me.txtRuc.Location = New System.Drawing.Point(72, 117)
        Me.txtRuc.Mask = "#############"
        Me.txtRuc.Name = "txtRuc"
        Me.txtRuc.Size = New System.Drawing.Size(140, 20)
        Me.txtRuc.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(6, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Nombre:"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tabBod)
        Me.TabControl1.Controls.Add(Me.tabPto)
        Me.TabControl1.Location = New System.Drawing.Point(269, 38)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(545, 350)
        Me.TabControl1.TabIndex = 17
        '
        'tabBod
        '
        Me.tabBod.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tabBod.Controls.Add(Me.mallaBod)
        Me.tabBod.Location = New System.Drawing.Point(4, 22)
        Me.tabBod.Name = "tabBod"
        Me.tabBod.Padding = New System.Windows.Forms.Padding(3)
        Me.tabBod.Size = New System.Drawing.Size(537, 324)
        Me.tabBod.TabIndex = 0
        Me.tabBod.Text = "Bodegas"
        '
        'mallaBod
        '
        Me.mallaBod.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.mallaBod.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.mallaBod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.mallaBod.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BOD, Me.Nombre, Me.IdCont})
        Me.mallaBod.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mallaBod.EnableHeadersVisualStyles = False
        Me.mallaBod.Location = New System.Drawing.Point(3, 3)
        Me.mallaBod.Name = "mallaBod"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.mallaBod.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.mallaBod.RowHeadersWidth = 21
        Me.mallaBod.Size = New System.Drawing.Size(531, 318)
        Me.mallaBod.TabIndex = 0
        '
        'BOD
        '
        Me.BOD.HeaderText = "BOD"
        Me.BOD.MaxInputLength = 3
        Me.BOD.Name = "BOD"
        Me.BOD.Width = 120
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre-Bodega"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Width = 119
        '
        'IdCont
        '
        Me.IdCont.HeaderText = "Id-Contable"
        Me.IdCont.Name = "IdCont"
        Me.IdCont.Width = 120
        '
        'tabPto
        '
        Me.tabPto.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tabPto.Controls.Add(Me.mallaPtoVta)
        Me.tabPto.Location = New System.Drawing.Point(4, 22)
        Me.tabPto.Name = "tabPto"
        Me.tabPto.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPto.Size = New System.Drawing.Size(537, 324)
        Me.tabPto.TabIndex = 1
        Me.tabPto.Text = "PuntoVenta/Atención"
        '
        'mallaPtoVta
        '
        Me.mallaPtoVta.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.mallaPtoVta.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.mallaPtoVta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.mallaPtoVta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PTO, Me.NomPto, Me.idCtb, Me.IdTrib, Me.TipoPunto})
        Me.mallaPtoVta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mallaPtoVta.EnableHeadersVisualStyles = False
        Me.mallaPtoVta.Location = New System.Drawing.Point(3, 3)
        Me.mallaPtoVta.Name = "mallaPtoVta"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.mallaPtoVta.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.mallaPtoVta.RowHeadersWidth = 21
        Me.mallaPtoVta.Size = New System.Drawing.Size(531, 318)
        Me.mallaPtoVta.TabIndex = 0
        '
        'PTO
        '
        Me.PTO.HeaderText = "PTO"
        Me.PTO.MaxInputLength = 3
        Me.PTO.Name = "PTO"
        '
        'NomPto
        '
        Me.NomPto.HeaderText = "Nombre-Punto-Vta"
        Me.NomPto.Name = "NomPto"
        '
        'idCtb
        '
        Me.idCtb.HeaderText = "Id-Contable"
        Me.idCtb.Name = "idCtb"
        Me.idCtb.ReadOnly = True
        '
        'IdTrib
        '
        Me.IdTrib.HeaderText = "Id-Tributario"
        Me.IdTrib.Name = "IdTrib"
        '
        'TipoPunto
        '
        Me.TipoPunto.HeaderText = "TipoPtoAcceso"
        Me.TipoPunto.MaxInputLength = 15
        Me.TipoPunto.Name = "TipoPunto"
        Me.TipoPunto.ReadOnly = True
        '
        'btnSuc
        '
        Me.btnSuc.BackColor = System.Drawing.Color.DimGray
        Me.btnSuc.ForeColor = System.Drawing.Color.White
        Me.btnSuc.Location = New System.Drawing.Point(135, 39)
        Me.btnSuc.Name = "btnSuc"
        Me.btnSuc.Size = New System.Drawing.Size(21, 21)
        Me.btnSuc.TabIndex = 16
        Me.btnSuc.Text = "..."
        Me.btnSuc.UseVisualStyleBackColor = False
        '
        'txtIdCont
        '
        Me.txtIdCont.Location = New System.Drawing.Point(127, 198)
        Me.txtIdCont.Name = "txtIdCont"
        Me.txtIdCont.Size = New System.Drawing.Size(85, 20)
        Me.txtIdCont.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(6, 201)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(115, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Identificativo Contable:"
        '
        'txtIdTrib
        '
        Me.txtIdTrib.Location = New System.Drawing.Point(127, 169)
        Me.txtIdTrib.Name = "txtIdTrib"
        Me.txtIdTrib.Size = New System.Drawing.Size(85, 20)
        Me.txtIdTrib.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(6, 172)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Identificativo Tributario:"
        '
        'txtSegSoc
        '
        Me.txtSegSoc.Location = New System.Drawing.Point(127, 143)
        Me.txtSegSoc.Name = "txtSegSoc"
        Me.txtSegSoc.Size = New System.Drawing.Size(85, 20)
        Me.txtSegSoc.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(6, 146)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Nro. Seguro Social:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(6, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Ruc:"
        '
        'txtDir
        '
        Me.txtDir.Location = New System.Drawing.Point(72, 91)
        Me.txtDir.Name = "txtDir"
        Me.txtDir.Size = New System.Drawing.Size(191, 20)
        Me.txtDir.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(6, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Dirección:"
        '
        'txtNom
        '
        Me.txtNom.Location = New System.Drawing.Point(72, 65)
        Me.txtNom.Name = "txtNom"
        Me.txtNom.Size = New System.Drawing.Size(191, 20)
        Me.txtNom.TabIndex = 5
        '
        'txtSuc
        '
        Me.txtSuc.Location = New System.Drawing.Point(72, 39)
        Me.txtSuc.MaxLength = 3
        Me.txtSuc.Name = "txtSuc"
        Me.txtSuc.Size = New System.Drawing.Size(65, 20)
        Me.txtSuc.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(6, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Sucursal:"
        '
        'txtEmpresa
        '
        Me.txtEmpresa.Location = New System.Drawing.Point(72, 13)
        Me.txtEmpresa.Name = "txtEmpresa"
        Me.txtEmpresa.Size = New System.Drawing.Size(586, 20)
        Me.txtEmpresa.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Empresa:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.DimGray
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.btnModificar, Me.btnEliminar, Me.ToolStripSeparator1, Me.btnGuardar, Me.btnCancelar, Me.ToolStripSeparator2, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(817, 46)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(46, 43)
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnModificar
        '
        Me.btnModificar.Image = CType(resources.GetObject("btnModificar.Image"), System.Drawing.Image)
        Me.btnModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(62, 43)
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(54, 43)
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 46)
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(53, 43)
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(57, 43)
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 46)
        '
        'btnSalir
        '
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(33, 43)
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'frmSuc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(817, 419)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSuc"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ADCOMDAX - ADMINISTRACIÓN DE SUCURSALES"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tabBod.ResumeLayout(False)
        CType(Me.mallaBod, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPto.ResumeLayout(False)
        CType(Me.mallaPtoVta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSuc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSuc As System.Windows.Forms.Button
    Friend WithEvents txtIdCont As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtIdTrib As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSegSoc As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDir As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNom As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabBod As System.Windows.Forms.TabPage
    Friend WithEvents tabPto As System.Windows.Forms.TabPage
    Friend WithEvents txtRuc As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mallaBod As System.Windows.Forms.DataGridView
    Friend WithEvents mallaPtoVta As System.Windows.Forms.DataGridView
    Friend WithEvents btnIdCont As System.Windows.Forms.Button
    Friend WithEvents BOD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdCont As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtPrecioVta As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PTO As DataGridViewTextBoxColumn
    Friend WithEvents NomPto As DataGridViewTextBoxColumn
    Friend WithEvents idCtb As DataGridViewTextBoxColumn
    Friend WithEvents IdTrib As DataGridViewTextBoxColumn
    Friend WithEvents TipoPunto As DataGridViewTextBoxColumn
End Class
