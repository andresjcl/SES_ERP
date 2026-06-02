<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class repInventario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(repInventario))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnOpciones = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCatalogo = New System.Windows.Forms.ToolStripButton()
        Me.btnAntiguedadPrd = New System.Windows.Forms.ToolStripButton()
        Me.btnMinMax = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Actualizar = New System.Windows.Forms.ToolStripButton()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.btnMed = New System.Windows.Forms.Button()
        Me.txtMedidas = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkArtExis = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cboSubg = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboClase = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboCategoria = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCodFin = New System.Windows.Forms.Button()
        Me.txtCodFin = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnCodIni = New System.Windows.Forms.Button()
        Me.txtcodIni = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboTipoIngreso = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.chkSaldoFec = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.optSinCost = New System.Windows.Forms.RadioButton()
        Me.optPvp4 = New System.Windows.Forms.RadioButton()
        Me.optPvp2 = New System.Windows.Forms.RadioButton()
        Me.optUltCost = New System.Windows.Forms.RadioButton()
        Me.optPvp5 = New System.Windows.Forms.RadioButton()
        Me.optPvp3 = New System.Windows.Forms.RadioButton()
        Me.optPvp1 = New System.Windows.Forms.RadioButton()
        Me.optCostoPro = New System.Windows.Forms.RadioButton()
        Me.txtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkSubg = New System.Windows.Forms.CheckBox()
        Me.chkClase = New System.Windows.Forms.CheckBox()
        Me.chkGrupo = New System.Windows.Forms.CheckBox()
        Me.chkCategoria = New System.Windows.Forms.CheckBox()
        Me.cboBodega = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOpciones, Me.ToolStripSeparator2, Me.btnCatalogo, Me.btnAntiguedadPrd, Me.btnMinMax, Me.ToolStripSeparator3, Me.Actualizar, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(879, 38)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnOpciones
        '
        Me.btnOpciones.Image = CType(resources.GetObject("btnOpciones.Image"), System.Drawing.Image)
        Me.btnOpciones.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOpciones.Name = "btnOpciones"
        Me.btnOpciones.Size = New System.Drawing.Size(61, 35)
        Me.btnOpciones.Text = "Opciones"
        Me.btnOpciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 38)
        '
        'btnCatalogo
        '
        Me.btnCatalogo.CheckOnClick = True
        Me.btnCatalogo.Image = CType(resources.GetObject("btnCatalogo.Image"), System.Drawing.Image)
        Me.btnCatalogo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCatalogo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnCatalogo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCatalogo.Name = "btnCatalogo"
        Me.btnCatalogo.Size = New System.Drawing.Size(133, 35)
        Me.btnCatalogo.Text = "Catalogo Artículos"
        '
        'btnAntiguedadPrd
        '
        Me.btnAntiguedadPrd.CheckOnClick = True
        Me.btnAntiguedadPrd.Image = CType(resources.GetObject("btnAntiguedadPrd.Image"), System.Drawing.Image)
        Me.btnAntiguedadPrd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAntiguedadPrd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnAntiguedadPrd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAntiguedadPrd.Name = "btnAntiguedadPrd"
        Me.btnAntiguedadPrd.Size = New System.Drawing.Size(146, 35)
        Me.btnAntiguedadPrd.Text = "Antiguedad Productos"
        '
        'btnMinMax
        '
        Me.btnMinMax.CheckOnClick = True
        Me.btnMinMax.Image = CType(resources.GetObject("btnMinMax.Image"), System.Drawing.Image)
        Me.btnMinMax.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMinMax.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnMinMax.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMinMax.Name = "btnMinMax"
        Me.btnMinMax.Size = New System.Drawing.Size(142, 35)
        Me.btnMinMax.Text = "Máximos y Mínimos"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 38)
        '
        'Actualizar
        '
        Me.Actualizar.Image = CType(resources.GetObject("Actualizar.Image"), System.Drawing.Image)
        Me.Actualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Actualizar.Name = "Actualizar"
        Me.Actualizar.Size = New System.Drawing.Size(63, 35)
        Me.Actualizar.Text = "Actualizar"
        Me.Actualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 38)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnMed)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtMedidas)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkArtExis)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboTipoIngreso)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkSaldoFec)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtFecha)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboBodega)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1MinSize = 20
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ReportViewer1)
        Me.SplitContainer1.Size = New System.Drawing.Size(879, 504)
        Me.SplitContainer1.SplitterDistance = 238
        Me.SplitContainer1.TabIndex = 3
        '
        'btnMed
        '
        Me.btnMed.Location = New System.Drawing.Point(190, 445)
        Me.btnMed.Name = "btnMed"
        Me.btnMed.Size = New System.Drawing.Size(21, 21)
        Me.btnMed.TabIndex = 26
        Me.btnMed.Text = "..."
        Me.btnMed.UseVisualStyleBackColor = True
        Me.btnMed.Visible = False
        '
        'txtMedidas
        '
        Me.txtMedidas.Location = New System.Drawing.Point(65, 445)
        Me.txtMedidas.Name = "txtMedidas"
        Me.txtMedidas.Size = New System.Drawing.Size(125, 20)
        Me.txtMedidas.TabIndex = 25
        Me.txtMedidas.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 448)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Medidas:"
        Me.Label9.Visible = False
        '
        'chkArtExis
        '
        Me.chkArtExis.AutoSize = True
        Me.chkArtExis.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkArtExis.Location = New System.Drawing.Point(11, 58)
        Me.chkArtExis.Name = "chkArtExis"
        Me.chkArtExis.Size = New System.Drawing.Size(138, 17)
        Me.chkArtExis.TabIndex = 23
        Me.chkArtExis.Text = "Artículos sin Existencia:"
        Me.chkArtExis.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboSubg)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.cboGrupo)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.cboClase)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.cboCategoria)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.btnCodFin)
        Me.GroupBox3.Controls.Add(Me.txtCodFin)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.btnCodIni)
        Me.GroupBox3.Controls.Add(Me.txtcodIni)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 75)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(223, 166)
        Me.GroupBox3.TabIndex = 22
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Opciones"
        '
        'cboSubg
        '
        Me.cboSubg.FormattingEnabled = True
        Me.cboSubg.Location = New System.Drawing.Point(73, 139)
        Me.cboSubg.Name = "cboSubg"
        Me.cboSubg.Size = New System.Drawing.Size(140, 21)
        Me.cboSubg.TabIndex = 26
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 142)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Subgrupo:"
        '
        'cboGrupo
        '
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Location = New System.Drawing.Point(73, 113)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(140, 21)
        Me.cboGrupo.TabIndex = 24
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(27, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Grupo:"
        '
        'cboClase
        '
        Me.cboClase.FormattingEnabled = True
        Me.cboClase.Location = New System.Drawing.Point(73, 87)
        Me.cboClase.Name = "cboClase"
        Me.cboClase.Size = New System.Drawing.Size(140, 21)
        Me.cboClase.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(30, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Clase:"
        '
        'cboCategoria
        '
        Me.cboCategoria.FormattingEnabled = True
        Me.cboCategoria.Location = New System.Drawing.Point(73, 62)
        Me.cboCategoria.Name = "cboCategoria"
        Me.cboCategoria.Size = New System.Drawing.Size(140, 21)
        Me.cboCategoria.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Categoria:"
        '
        'btnCodFin
        '
        Me.btnCodFin.Location = New System.Drawing.Point(201, 37)
        Me.btnCodFin.Name = "btnCodFin"
        Me.btnCodFin.Size = New System.Drawing.Size(21, 21)
        Me.btnCodFin.TabIndex = 13
        Me.btnCodFin.Text = "..."
        Me.btnCodFin.UseVisualStyleBackColor = True
        '
        'txtCodFin
        '
        Me.txtCodFin.Location = New System.Drawing.Point(75, 37)
        Me.txtCodFin.Name = "txtCodFin"
        Me.txtCodFin.Size = New System.Drawing.Size(125, 20)
        Me.txtCodFin.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Codigo Final:"
        '
        'btnCodIni
        '
        Me.btnCodIni.Location = New System.Drawing.Point(200, 14)
        Me.btnCodIni.Name = "btnCodIni"
        Me.btnCodIni.Size = New System.Drawing.Size(21, 21)
        Me.btnCodIni.TabIndex = 10
        Me.btnCodIni.Text = "..."
        Me.btnCodIni.UseVisualStyleBackColor = True
        '
        'txtcodIni
        '
        Me.txtcodIni.Location = New System.Drawing.Point(75, 14)
        Me.txtcodIni.Name = "txtcodIni"
        Me.txtcodIni.Size = New System.Drawing.Size(125, 20)
        Me.txtcodIni.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Codigo Inicial:"
        '
        'cboTipoIngreso
        '
        Me.cboTipoIngreso.FormattingEnabled = True
        Me.cboTipoIngreso.Location = New System.Drawing.Point(83, 471)
        Me.cboTipoIngreso.Name = "cboTipoIngreso"
        Me.cboTipoIngreso.Size = New System.Drawing.Size(148, 21)
        Me.cboTipoIngreso.TabIndex = 21
        Me.cboTipoIngreso.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 474)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Tipo Ingreso:"
        Me.Label10.Visible = False
        '
        'chkSaldoFec
        '
        Me.chkSaldoFec.AutoSize = True
        Me.chkSaldoFec.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkSaldoFec.Location = New System.Drawing.Point(14, 469)
        Me.chkSaldoFec.Name = "chkSaldoFec"
        Me.chkSaldoFec.Size = New System.Drawing.Size(153, 17)
        Me.chkSaldoFec.TabIndex = 19
        Me.chkSaldoFec.Text = "Visualizar Saldo a la Fecha"
        Me.chkSaldoFec.UseVisualStyleBackColor = True
        Me.chkSaldoFec.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.optSinCost)
        Me.GroupBox2.Controls.Add(Me.optPvp4)
        Me.GroupBox2.Controls.Add(Me.optPvp2)
        Me.GroupBox2.Controls.Add(Me.optUltCost)
        Me.GroupBox2.Controls.Add(Me.optPvp5)
        Me.GroupBox2.Controls.Add(Me.optPvp3)
        Me.GroupBox2.Controls.Add(Me.optPvp1)
        Me.GroupBox2.Controls.Add(Me.optCostoPro)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 321)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(221, 112)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Costos/Precios"
        '
        'optSinCost
        '
        Me.optSinCost.AutoSize = True
        Me.optSinCost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.optSinCost.Location = New System.Drawing.Point(117, 89)
        Me.optSinCost.Name = "optSinCost"
        Me.optSinCost.Size = New System.Drawing.Size(97, 17)
        Me.optSinCost.TabIndex = 7
        Me.optSinCost.Text = "Sin Costo         "
        Me.optSinCost.UseVisualStyleBackColor = True
        '
        'optPvp4
        '
        Me.optPvp4.AutoSize = True
        Me.optPvp4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.optPvp4.Location = New System.Drawing.Point(116, 65)
        Me.optPvp4.Name = "optPvp4"
        Me.optPvp4.Size = New System.Drawing.Size(98, 17)
        Me.optPvp4.TabIndex = 6
        Me.optPvp4.Text = "Precio Venta 4 "
        Me.optPvp4.UseVisualStyleBackColor = True
        '
        'optPvp2
        '
        Me.optPvp2.AutoSize = True
        Me.optPvp2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.optPvp2.Location = New System.Drawing.Point(116, 42)
        Me.optPvp2.Name = "optPvp2"
        Me.optPvp2.Size = New System.Drawing.Size(98, 17)
        Me.optPvp2.TabIndex = 5
        Me.optPvp2.Text = "Precio Venta 2 "
        Me.optPvp2.UseVisualStyleBackColor = True
        '
        'optUltCost
        '
        Me.optUltCost.AutoSize = True
        Me.optUltCost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.optUltCost.Location = New System.Drawing.Point(115, 19)
        Me.optUltCost.Name = "optUltCost"
        Me.optUltCost.Size = New System.Drawing.Size(99, 17)
        Me.optUltCost.TabIndex = 4
        Me.optUltCost.Text = "Ultimo Costo     "
        Me.optUltCost.UseVisualStyleBackColor = True
        '
        'optPvp5
        '
        Me.optPvp5.AutoSize = True
        Me.optPvp5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.optPvp5.Location = New System.Drawing.Point(5, 88)
        Me.optPvp5.Name = "optPvp5"
        Me.optPvp5.Size = New System.Drawing.Size(98, 17)
        Me.optPvp5.TabIndex = 3
        Me.optPvp5.Text = "Precio Venta 5 "
        Me.optPvp5.UseVisualStyleBackColor = True
        '
        'optPvp3
        '
        Me.optPvp3.AutoSize = True
        Me.optPvp3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.optPvp3.Location = New System.Drawing.Point(5, 65)
        Me.optPvp3.Name = "optPvp3"
        Me.optPvp3.Size = New System.Drawing.Size(98, 17)
        Me.optPvp3.TabIndex = 2
        Me.optPvp3.Text = "Precio Venta 3 "
        Me.optPvp3.UseVisualStyleBackColor = True
        '
        'optPvp1
        '
        Me.optPvp1.AutoSize = True
        Me.optPvp1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.optPvp1.Location = New System.Drawing.Point(5, 42)
        Me.optPvp1.Name = "optPvp1"
        Me.optPvp1.Size = New System.Drawing.Size(98, 17)
        Me.optPvp1.TabIndex = 1
        Me.optPvp1.Text = "Precio Venta 1 "
        Me.optPvp1.UseVisualStyleBackColor = True
        '
        'optCostoPro
        '
        Me.optCostoPro.AutoSize = True
        Me.optCostoPro.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.optCostoPro.Checked = True
        Me.optCostoPro.Location = New System.Drawing.Point(4, 19)
        Me.optCostoPro.Name = "optCostoPro"
        Me.optCostoPro.Size = New System.Drawing.Size(99, 17)
        Me.optCostoPro.TabIndex = 0
        Me.optCostoPro.TabStop = True
        Me.optCostoPro.Text = "Costo Promedio"
        Me.optCostoPro.UseVisualStyleBackColor = True
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(82, 32)
        Me.txtFecha.Mask = "00/00/0000"
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(67, 20)
        Me.txtFecha.TabIndex = 4
        Me.txtFecha.ValidatingType = GetType(Date)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "A la Fecha:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkSubg)
        Me.GroupBox1.Controls.Add(Me.chkClase)
        Me.GroupBox1.Controls.Add(Me.chkGrupo)
        Me.GroupBox1.Controls.Add(Me.chkCategoria)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 245)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(223, 69)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Agrupación"
        '
        'chkSubg
        '
        Me.chkSubg.AutoSize = True
        Me.chkSubg.Location = New System.Drawing.Point(118, 41)
        Me.chkSubg.Name = "chkSubg"
        Me.chkSubg.Size = New System.Drawing.Size(72, 17)
        Me.chkSubg.TabIndex = 3
        Me.chkSubg.Text = "Subgrupo"
        Me.chkSubg.UseVisualStyleBackColor = True
        '
        'chkClase
        '
        Me.chkClase.AutoSize = True
        Me.chkClase.Location = New System.Drawing.Point(118, 19)
        Me.chkClase.Name = "chkClase"
        Me.chkClase.Size = New System.Drawing.Size(52, 17)
        Me.chkClase.TabIndex = 2
        Me.chkClase.Text = "Clase"
        Me.chkClase.UseVisualStyleBackColor = True
        '
        'chkGrupo
        '
        Me.chkGrupo.AutoSize = True
        Me.chkGrupo.Location = New System.Drawing.Point(16, 41)
        Me.chkGrupo.Name = "chkGrupo"
        Me.chkGrupo.Size = New System.Drawing.Size(55, 17)
        Me.chkGrupo.TabIndex = 1
        Me.chkGrupo.Text = "Grupo"
        Me.chkGrupo.UseVisualStyleBackColor = True
        '
        'chkCategoria
        '
        Me.chkCategoria.AutoSize = True
        Me.chkCategoria.Location = New System.Drawing.Point(16, 18)
        Me.chkCategoria.Name = "chkCategoria"
        Me.chkCategoria.Size = New System.Drawing.Size(71, 17)
        Me.chkCategoria.TabIndex = 0
        Me.chkCategoria.Text = "Categoria"
        Me.chkCategoria.UseVisualStyleBackColor = True
        '
        'cboBodega
        '
        Me.cboBodega.FormattingEnabled = True
        Me.cboBodega.Location = New System.Drawing.Point(83, 8)
        Me.cboBodega.Name = "cboBodega"
        Me.cboBodega.Size = New System.Drawing.Size(147, 21)
        Me.cboBodega.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Bodega:"
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(637, 504)
        Me.ReportViewer1.TabIndex = 1
        '
        'repInventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(879, 542)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "repInventario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REPORTES DE INVENTARIO"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnOpciones As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCatalogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnAntiguedadPrd As System.Windows.Forms.ToolStripButton
    Friend WithEvents Actualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents btnMinMax As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cboBodega As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCodFin As System.Windows.Forms.Button
    Friend WithEvents txtCodFin As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnCodIni As System.Windows.Forms.Button
    Friend WithEvents txtcodIni As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents optSinCost As System.Windows.Forms.RadioButton
    Friend WithEvents optPvp4 As System.Windows.Forms.RadioButton
    Friend WithEvents optPvp2 As System.Windows.Forms.RadioButton
    Friend WithEvents optUltCost As System.Windows.Forms.RadioButton
    Friend WithEvents optPvp5 As System.Windows.Forms.RadioButton
    Friend WithEvents optPvp3 As System.Windows.Forms.RadioButton
    Friend WithEvents optPvp1 As System.Windows.Forms.RadioButton
    Friend WithEvents optCostoPro As System.Windows.Forms.RadioButton
    Friend WithEvents chkSaldoFec As System.Windows.Forms.CheckBox
    Friend WithEvents cboTipoIngreso As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkArtExis As System.Windows.Forms.CheckBox
    Friend WithEvents cboSubg As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboClase As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkSubg As System.Windows.Forms.CheckBox
    Friend WithEvents chkClase As System.Windows.Forms.CheckBox
    Friend WithEvents chkGrupo As System.Windows.Forms.CheckBox
    Friend WithEvents chkCategoria As System.Windows.Forms.CheckBox
    Friend WithEvents btnMed As System.Windows.Forms.Button
    Friend WithEvents txtMedidas As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label

End Class
