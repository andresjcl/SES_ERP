<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepDoc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepDoc))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnOpciones = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.DocDetalle = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ImpDocumento = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImpDetalle = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.chkConsignatario = New System.Windows.Forms.CheckBox()
        Me.chkDetalle = New System.Windows.Forms.CheckBox()
        Me.chkSoloTotal = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnCodFin = New System.Windows.Forms.Button()
        Me.txtCodFin = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnCodIni = New System.Windows.Forms.Button()
        Me.txtCodIni = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.optAnulados = New System.Windows.Forms.RadioButton()
        Me.optTodos = New System.Windows.Forms.RadioButton()
        Me.optCtaPag = New System.Windows.Forms.RadioButton()
        Me.optCtasCob = New System.Windows.Forms.RadioButton()
        Me.optCompras = New System.Windows.Forms.RadioButton()
        Me.optVentas = New System.Windows.Forms.RadioButton()
        Me.optBancos = New System.Windows.Forms.RadioButton()
        Me.optInv = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtFechaAl = New System.Windows.Forms.DateTimePicker()
        Me.txtFechaDel = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboVendedor = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboDoc = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboBodega = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboSucursal = New System.Windows.Forms.ComboBox()
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
        Me.ToolStrip1.BackColor = System.Drawing.Color.DimGray
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOpciones, Me.ToolStripSeparator2, Me.DocDetalle, Me.ToolStripSeparator3, Me.btnActualizar, Me.ToolStripSeparator1, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1132, 39)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnOpciones
        '
        Me.btnOpciones.ForeColor = System.Drawing.Color.White
        Me.btnOpciones.Image = CType(resources.GetObject("btnOpciones.Image"), System.Drawing.Image)
        Me.btnOpciones.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOpciones.Name = "btnOpciones"
        Me.btnOpciones.Size = New System.Drawing.Size(107, 36)
        Me.btnOpciones.Text = "Opciones"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.ForeColor = System.Drawing.Color.White
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'DocDetalle
        '
        Me.DocDetalle.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImpDocumento, Me.ImpDetalle})
        Me.DocDetalle.ForeColor = System.Drawing.Color.White
        Me.DocDetalle.Image = CType(resources.GetObject("DocDetalle.Image"), System.Drawing.Image)
        Me.DocDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.DocDetalle.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DocDetalle.Name = "DocDetalle"
        Me.DocDetalle.Size = New System.Drawing.Size(121, 36)
        Me.DocDetalle.Text = "QueDatos"
        '
        'ImpDocumento
        '
        Me.ImpDocumento.Image = CType(resources.GetObject("ImpDocumento.Image"), System.Drawing.Image)
        Me.ImpDocumento.Name = "ImpDocumento"
        Me.ImpDocumento.Size = New System.Drawing.Size(238, 26)
        Me.ImpDocumento.Text = "Imprimir Documentos"
        '
        'ImpDetalle
        '
        Me.ImpDetalle.Image = CType(resources.GetObject("ImpDetalle.Image"), System.Drawing.Image)
        Me.ImpDetalle.Name = "ImpDetalle"
        Me.ImpDetalle.Size = New System.Drawing.Size(238, 26)
        Me.ImpDetalle.Text = "Imprime detalle items"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.ForeColor = System.Drawing.Color.White
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 39)
        '
        'btnActualizar
        '
        Me.btnActualizar.ForeColor = System.Drawing.Color.White
        Me.btnActualizar.Image = CType(resources.GetObject("btnActualizar.Image"), System.Drawing.Image)
        Me.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(111, 36)
        Me.btnActualizar.Text = "Actualizar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.ForeColor = System.Drawing.Color.White
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'btnSalir
        '
        Me.btnSalir.ForeColor = System.Drawing.Color.White
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(74, 36)
        Me.btnSalir.Text = "Salir"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 39)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.DimGray
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkConsignatario)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkDetalle)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkSoloTotal)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboVendedor)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboDoc)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboBodega)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboSucursal)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ReportViewer1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1132, 615)
        Me.SplitContainer1.SplitterDistance = 250
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 1
        '
        'chkConsignatario
        '
        Me.chkConsignatario.AutoSize = True
        Me.chkConsignatario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkConsignatario.ForeColor = System.Drawing.Color.White
        Me.chkConsignatario.Location = New System.Drawing.Point(4, 258)
        Me.chkConsignatario.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkConsignatario.Name = "chkConsignatario"
        Me.chkConsignatario.Size = New System.Drawing.Size(258, 24)
        Me.chkConsignatario.TabIndex = 14
        Me.chkConsignatario.Text = "Imprimir nombre consignatario"
        Me.chkConsignatario.UseVisualStyleBackColor = True
        '
        'chkDetalle
        '
        Me.chkDetalle.AutoSize = True
        Me.chkDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDetalle.ForeColor = System.Drawing.Color.White
        Me.chkDetalle.Location = New System.Drawing.Point(4, 226)
        Me.chkDetalle.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkDetalle.Name = "chkDetalle"
        Me.chkDetalle.Size = New System.Drawing.Size(233, 24)
        Me.chkDetalle.TabIndex = 13
        Me.chkDetalle.Text = "Imprimir detalle documento"
        Me.chkDetalle.UseVisualStyleBackColor = True
        '
        'chkSoloTotal
        '
        Me.chkSoloTotal.AutoSize = True
        Me.chkSoloTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSoloTotal.ForeColor = System.Drawing.Color.White
        Me.chkSoloTotal.Location = New System.Drawing.Point(4, 198)
        Me.chkSoloTotal.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkSoloTotal.Name = "chkSoloTotal"
        Me.chkSoloTotal.Size = New System.Drawing.Size(183, 24)
        Me.chkSoloTotal.TabIndex = 12
        Me.chkSoloTotal.Text = "Imprimir solo totales"
        Me.chkSoloTotal.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnCodFin)
        Me.GroupBox3.Controls.Add(Me.txtCodFin)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.btnCodIni)
        Me.GroupBox3.Controls.Add(Me.txtCodIni)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Location = New System.Drawing.Point(-1, 286)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(329, 94)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Cliente/Proveedor"
        '
        'btnCodFin
        '
        Me.btnCodFin.Location = New System.Drawing.Point(295, 57)
        Me.btnCodFin.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCodFin.Name = "btnCodFin"
        Me.btnCodFin.Size = New System.Drawing.Size(28, 26)
        Me.btnCodFin.TabIndex = 5
        Me.btnCodFin.Text = "..."
        Me.btnCodFin.UseVisualStyleBackColor = True
        '
        'txtCodFin
        '
        Me.txtCodFin.Location = New System.Drawing.Point(96, 57)
        Me.txtCodFin.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCodFin.MaxLength = 15
        Me.txtCodFin.Name = "txtCodFin"
        Me.txtCodFin.Size = New System.Drawing.Size(200, 22)
        Me.txtCodFin.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(4, 60)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 17)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Codigo Final:"
        '
        'btnCodIni
        '
        Me.btnCodIni.Location = New System.Drawing.Point(296, 22)
        Me.btnCodIni.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCodIni.Name = "btnCodIni"
        Me.btnCodIni.Size = New System.Drawing.Size(28, 26)
        Me.btnCodIni.TabIndex = 2
        Me.btnCodIni.Text = "..."
        Me.btnCodIni.UseVisualStyleBackColor = True
        '
        'txtCodIni
        '
        Me.txtCodIni.Location = New System.Drawing.Point(97, 22)
        Me.txtCodIni.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCodIni.MaxLength = 15
        Me.txtCodIni.Name = "txtCodIni"
        Me.txtCodIni.Size = New System.Drawing.Size(200, 22)
        Me.txtCodIni.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(5, 26)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 17)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Codigo Inicial:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.optAnulados)
        Me.GroupBox2.Controls.Add(Me.optTodos)
        Me.GroupBox2.Controls.Add(Me.optCtaPag)
        Me.GroupBox2.Controls.Add(Me.optCtasCob)
        Me.GroupBox2.Controls.Add(Me.optCompras)
        Me.GroupBox2.Controls.Add(Me.optVentas)
        Me.GroupBox2.Controls.Add(Me.optBancos)
        Me.GroupBox2.Controls.Add(Me.optInv)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 4)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(329, 113)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Documentos de:"
        '
        'optAnulados
        '
        Me.optAnulados.AutoSize = True
        Me.optAnulados.ForeColor = System.Drawing.Color.White
        Me.optAnulados.Location = New System.Drawing.Point(129, 80)
        Me.optAnulados.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.optAnulados.Name = "optAnulados"
        Me.optAnulados.Size = New System.Drawing.Size(88, 21)
        Me.optAnulados.TabIndex = 7
        Me.optAnulados.Text = "Anulados"
        Me.optAnulados.UseVisualStyleBackColor = True
        '
        'optTodos
        '
        Me.optTodos.AutoSize = True
        Me.optTodos.ForeColor = System.Drawing.Color.White
        Me.optTodos.Location = New System.Drawing.Point(233, 80)
        Me.optTodos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.optTodos.Name = "optTodos"
        Me.optTodos.Size = New System.Drawing.Size(69, 21)
        Me.optTodos.TabIndex = 6
        Me.optTodos.Text = "Todos"
        Me.optTodos.UseVisualStyleBackColor = True
        '
        'optCtaPag
        '
        Me.optCtaPag.AutoSize = True
        Me.optCtaPag.ForeColor = System.Drawing.Color.White
        Me.optCtaPag.Location = New System.Drawing.Point(129, 52)
        Me.optCtaPag.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.optCtaPag.Name = "optCtaPag"
        Me.optCtaPag.Size = New System.Drawing.Size(112, 21)
        Me.optCtaPag.TabIndex = 5
        Me.optCtaPag.Text = "Ctas X Pagar"
        Me.optCtaPag.UseVisualStyleBackColor = True
        '
        'optCtasCob
        '
        Me.optCtasCob.AutoSize = True
        Me.optCtasCob.ForeColor = System.Drawing.Color.White
        Me.optCtasCob.Location = New System.Drawing.Point(11, 52)
        Me.optCtasCob.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.optCtasCob.Name = "optCtasCob"
        Me.optCtasCob.Size = New System.Drawing.Size(107, 21)
        Me.optCtasCob.TabIndex = 4
        Me.optCtasCob.Text = "CtasXcobrar"
        Me.optCtasCob.UseVisualStyleBackColor = True
        '
        'optCompras
        '
        Me.optCompras.AutoSize = True
        Me.optCompras.ForeColor = System.Drawing.Color.White
        Me.optCompras.Location = New System.Drawing.Point(233, 23)
        Me.optCompras.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.optCompras.Name = "optCompras"
        Me.optCompras.Size = New System.Drawing.Size(85, 21)
        Me.optCompras.TabIndex = 2
        Me.optCompras.Text = "Compras"
        Me.optCompras.UseVisualStyleBackColor = True
        '
        'optVentas
        '
        Me.optVentas.AutoSize = True
        Me.optVentas.ForeColor = System.Drawing.Color.White
        Me.optVentas.Location = New System.Drawing.Point(129, 23)
        Me.optVentas.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.optVentas.Name = "optVentas"
        Me.optVentas.Size = New System.Drawing.Size(73, 21)
        Me.optVentas.TabIndex = 1
        Me.optVentas.Text = "Ventas"
        Me.optVentas.UseVisualStyleBackColor = True
        '
        'optBancos
        '
        Me.optBancos.AutoSize = True
        Me.optBancos.ForeColor = System.Drawing.Color.White
        Me.optBancos.Location = New System.Drawing.Point(13, 80)
        Me.optBancos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.optBancos.Name = "optBancos"
        Me.optBancos.Size = New System.Drawing.Size(76, 21)
        Me.optBancos.TabIndex = 3
        Me.optBancos.Text = "Bancos"
        Me.optBancos.UseVisualStyleBackColor = True
        '
        'optInv
        '
        Me.optInv.AutoSize = True
        Me.optInv.Checked = True
        Me.optInv.ForeColor = System.Drawing.Color.White
        Me.optInv.Location = New System.Drawing.Point(11, 23)
        Me.optInv.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.optInv.Name = "optInv"
        Me.optInv.Size = New System.Drawing.Size(91, 21)
        Me.optInv.TabIndex = 0
        Me.optInv.TabStop = True
        Me.optInv.Text = "Inventario"
        Me.optInv.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtFechaAl)
        Me.GroupBox1.Controls.Add(Me.txtFechaDel)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 128)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(329, 63)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Rango de Fechas:"
        '
        'txtFechaAl
        '
        Me.txtFechaAl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaAl.Location = New System.Drawing.Point(200, 30)
        Me.txtFechaAl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFechaAl.Name = "txtFechaAl"
        Me.txtFechaAl.Size = New System.Drawing.Size(119, 22)
        Me.txtFechaAl.TabIndex = 13
        '
        'txtFechaDel
        '
        Me.txtFechaDel.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaDel.Location = New System.Drawing.Point(43, 30)
        Me.txtFechaDel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFechaDel.Name = "txtFechaDel"
        Me.txtFechaDel.Size = New System.Drawing.Size(119, 22)
        Me.txtFechaDel.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(169, 32)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 17)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Al:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(7, 32)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 17)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Del:"
        '
        'cboVendedor
        '
        Me.cboVendedor.FormattingEnabled = True
        Me.cboVendedor.Location = New System.Drawing.Point(19, 514)
        Me.cboVendedor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboVendedor.Name = "cboVendedor"
        Me.cboVendedor.Size = New System.Drawing.Size(280, 24)
        Me.cboVendedor.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(20, 501)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 17)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Vendedor:"
        '
        'cboDoc
        '
        Me.cboDoc.FormattingEnabled = True
        Me.cboDoc.Location = New System.Drawing.Point(19, 459)
        Me.cboDoc.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboDoc.Name = "cboDoc"
        Me.cboDoc.Size = New System.Drawing.Size(280, 24)
        Me.cboDoc.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(19, 444)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Documento:"
        '
        'cboBodega
        '
        Me.cboBodega.FormattingEnabled = True
        Me.cboBodega.Location = New System.Drawing.Point(19, 571)
        Me.cboBodega.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboBodega.Name = "cboBodega"
        Me.cboBodega.Size = New System.Drawing.Size(280, 24)
        Me.cboBodega.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(20, 556)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Bodega:"
        '
        'cboSucursal
        '
        Me.cboSucursal.FormattingEnabled = True
        Me.cboSucursal.Location = New System.Drawing.Point(16, 409)
        Me.cboSucursal.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboSucursal.Name = "cboSucursal"
        Me.cboSucursal.Size = New System.Drawing.Size(280, 24)
        Me.cboSucursal.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(17, 394)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sucursal:"
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(877, 615)
        Me.ReportViewer1.TabIndex = 0
        '
        'frmRepDoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1132, 654)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmRepDoc"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de documentos "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(false)
        Me.ToolStrip1.PerformLayout
        Me.SplitContainer1.Panel1.ResumeLayout(false)
        Me.SplitContainer1.Panel1.PerformLayout
        Me.SplitContainer1.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer1.ResumeLayout(false)
        Me.GroupBox3.ResumeLayout(false)
        Me.GroupBox3.PerformLayout
        Me.GroupBox2.ResumeLayout(false)
        Me.GroupBox2.PerformLayout
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnOpciones As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkSoloTotal As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboVendedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboDoc As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboBodega As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents optCtaPag As System.Windows.Forms.RadioButton
    Friend WithEvents optCtasCob As System.Windows.Forms.RadioButton
    Friend WithEvents optCompras As System.Windows.Forms.RadioButton
    Friend WithEvents optVentas As System.Windows.Forms.RadioButton
    Friend WithEvents optBancos As System.Windows.Forms.RadioButton
    Friend WithEvents optInv As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCodFin As System.Windows.Forms.Button
    Friend WithEvents txtCodFin As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnCodIni As System.Windows.Forms.Button
    Friend WithEvents txtCodIni As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents optTodos As System.Windows.Forms.RadioButton
    Friend WithEvents DocDetalle As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ImpDocumento As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImpDetalle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents optAnulados As System.Windows.Forms.RadioButton
    Friend WithEvents txtFechaAl As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtFechaDel As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkConsignatario As System.Windows.Forms.CheckBox
    Friend WithEvents chkDetalle As System.Windows.Forms.CheckBox

End Class
