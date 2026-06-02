<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class CTBP01_1
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
	Public WithEvents chkDeAgrupacion As System.Windows.Forms.CheckBox
    Public WithEvents Formatodetalle As System.Windows.Forms.TextBox
	Public WithEvents DcModulo As System.Windows.Forms.ComboBox
	Public WithEvents Option1 As System.Windows.Forms.RadioButton
	Public WithEvents opbienes As System.Windows.Forms.RadioButton
	Public WithEvents chiva As System.Windows.Forms.CheckBox
	Public WithEvents chkegresobanco As System.Windows.Forms.CheckBox
	Public WithEvents Chkingresobanco As System.Windows.Forms.CheckBox
	Public WithEvents chkfacturacion As System.Windows.Forms.CheckBox
	Public WithEvents Chkcompras As System.Windows.Forms.CheckBox
	Public WithEvents Frconceptos As System.Windows.Forms.GroupBox
	Public WithEvents CtaAlterna As System.Windows.Forms.TextBox
    Public WithEvents txtNomCta As System.Windows.Forms.TextBox
    Public WithEvents Label14 As System.Windows.Forms.Label
	Public WithEvents Label13 As System.Windows.Forms.Label
	Public WithEvents Label15 As System.Windows.Forms.Label
	Public WithEvents Label16 As System.Windows.Forms.Label
	Public WithEvents Frame3 As System.Windows.Forms.GroupBox
	Public WithEvents opMenVar As System.Windows.Forms.RadioButton
	Public WithEvents opSinPre As System.Windows.Forms.RadioButton
	Public WithEvents opMenFij As System.Windows.Forms.RadioButton
	Public WithEvents Frame6 As System.Windows.Forms.GroupBox
    Public WithEvents dcGruCon As System.Windows.Forms.ComboBox
	Public WithEvents ImageList1 As System.Windows.Forms.ImageList
    Public WithEvents guardar As System.Windows.Forms.ToolStripButton
    Public WithEvents salir As System.Windows.Forms.ToolStripButton
    Public WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    '   Public WithEvents txtCodCta As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar mediante el Diseñador de Windows Forms.
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CTBP01_1))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.chkDeAgrupacion = New System.Windows.Forms.CheckBox()
        Me.Formatodetalle = New System.Windows.Forms.TextBox()
        Me.DcModulo = New System.Windows.Forms.ComboBox()
        Me.Frconceptos = New System.Windows.Forms.GroupBox()
        Me.chkegresobanco = New System.Windows.Forms.CheckBox()
        Me.Option1 = New System.Windows.Forms.RadioButton()
        Me.opbienes = New System.Windows.Forms.RadioButton()
        Me.chiva = New System.Windows.Forms.CheckBox()
        Me.Chkingresobanco = New System.Windows.Forms.CheckBox()
        Me.chkfacturacion = New System.Windows.Forms.CheckBox()
        Me.Chkcompras = New System.Windows.Forms.CheckBox()
        Me.CtaAlterna = New System.Windows.Forms.TextBox()
        Me.txtNomCta = New System.Windows.Forms.TextBox()
        Me.Frame3 = New System.Windows.Forms.GroupBox()
        Me.txtC2 = New System.Windows.Forms.ComboBox()
        Me.txtC4 = New System.Windows.Forms.ComboBox()
        Me.txtC1 = New System.Windows.Forms.ComboBox()
        Me.txtC3 = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Frame6 = New System.Windows.Forms.GroupBox()
        Me.opMenVar = New System.Windows.Forms.RadioButton()
        Me.opMenFij = New System.Windows.Forms.RadioButton()
        Me.opSinPre = New System.Windows.Forms.RadioButton()
        Me.dcGruCon = New System.Windows.Forms.ComboBox()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.guardar = New System.Windows.Forms.ToolStripButton()
        Me.salir = New System.Windows.Forms.ToolStripButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Clasificadores = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnNoProduccion = New System.Windows.Forms.RadioButton()
        Me.btnCI = New System.Windows.Forms.RadioButton()
        Me.btnCD = New System.Windows.Forms.RadioButton()
        Me.btnMO = New System.Windows.Forms.RadioButton()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Frconceptos.SuspendLayout()
        Me.Frame3.SuspendLayout()
        Me.Frame6.SuspendLayout()
        Me.Toolbar1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.SteelBlue
        Me.Button1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Button1.Location = New System.Drawing.Point(135, 21)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(27, 14)
        Me.Button1.TabIndex = 41
        Me.ToolTip1.SetToolTip(Me.Button1, "Numeración automática")
        Me.Button1.UseVisualStyleBackColor = False
        '
        'chkDeAgrupacion
        '
        Me.chkDeAgrupacion.BackColor = System.Drawing.Color.Transparent
        Me.chkDeAgrupacion.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkDeAgrupacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDeAgrupacion.ForeColor = System.Drawing.Color.DarkOrange
        Me.chkDeAgrupacion.Location = New System.Drawing.Point(576, 10)
        Me.chkDeAgrupacion.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkDeAgrupacion.Name = "chkDeAgrupacion"
        Me.chkDeAgrupacion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkDeAgrupacion.Size = New System.Drawing.Size(241, 25)
        Me.chkDeAgrupacion.TabIndex = 38
        Me.chkDeAgrupacion.Text = "Es cuenta de agrupación"
        Me.chkDeAgrupacion.UseVisualStyleBackColor = False
        '
        'Formatodetalle
        '
        Me.Formatodetalle.AcceptsReturn = True
        Me.Formatodetalle.BackColor = System.Drawing.SystemColors.Window
        Me.Formatodetalle.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Formatodetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Formatodetalle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Formatodetalle.Location = New System.Drawing.Point(10, 28)
        Me.Formatodetalle.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Formatodetalle.MaxLength = 0
        Me.Formatodetalle.Name = "Formatodetalle"
        Me.Formatodetalle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Formatodetalle.Size = New System.Drawing.Size(843, 23)
        Me.Formatodetalle.TabIndex = 30
        Me.Formatodetalle.Text = "Valor  [nrodoc] "
        Me.Formatodetalle.Visible = False
        '
        'DcModulo
        '
        Me.DcModulo.BackColor = System.Drawing.SystemColors.Window
        Me.DcModulo.Cursor = System.Windows.Forms.Cursors.Default
        Me.DcModulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DcModulo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DcModulo.Location = New System.Drawing.Point(531, 75)
        Me.DcModulo.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.DcModulo.Name = "DcModulo"
        Me.DcModulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DcModulo.Size = New System.Drawing.Size(286, 25)
        Me.DcModulo.TabIndex = 28
        '
        'Frconceptos
        '
        Me.Frconceptos.BackColor = System.Drawing.Color.DimGray
        Me.Frconceptos.Controls.Add(Me.chkegresobanco)
        Me.Frconceptos.Controls.Add(Me.Option1)
        Me.Frconceptos.Controls.Add(Me.opbienes)
        Me.Frconceptos.Controls.Add(Me.chiva)
        Me.Frconceptos.Controls.Add(Me.Chkingresobanco)
        Me.Frconceptos.Controls.Add(Me.chkfacturacion)
        Me.Frconceptos.Controls.Add(Me.Chkcompras)
        Me.Frconceptos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Frconceptos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frconceptos.ForeColor = System.Drawing.Color.Black
        Me.Frconceptos.Location = New System.Drawing.Point(3, 145)
        Me.Frconceptos.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Frconceptos.Name = "Frconceptos"
        Me.Frconceptos.Padding = New System.Windows.Forms.Padding(0)
        Me.Frconceptos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frconceptos.Size = New System.Drawing.Size(857, 158)
        Me.Frconceptos.TabIndex = 27
        Me.Frconceptos.TabStop = False
        Me.Frconceptos.Text = "Propiedades como concepto:"
        '
        'chkegresobanco
        '
        Me.chkegresobanco.BackColor = System.Drawing.Color.Transparent
        Me.chkegresobanco.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkegresobanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkegresobanco.ForeColor = System.Drawing.Color.White
        Me.chkegresobanco.Location = New System.Drawing.Point(19, 72)
        Me.chkegresobanco.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkegresobanco.Name = "chkegresobanco"
        Me.chkegresobanco.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkegresobanco.Size = New System.Drawing.Size(269, 22)
        Me.chkegresobanco.TabIndex = 42
        Me.chkegresobanco.Text = "Concepto para egreso de bancos"
        Me.chkegresobanco.UseVisualStyleBackColor = False
        '
        'Option1
        '
        Me.Option1.BackColor = System.Drawing.Color.Transparent
        Me.Option1.Checked = True
        Me.Option1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Option1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Option1.ForeColor = System.Drawing.Color.White
        Me.Option1.Location = New System.Drawing.Point(505, 39)
        Me.Option1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Option1.Name = "Option1"
        Me.Option1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Option1.Size = New System.Drawing.Size(205, 22)
        Me.Option1.TabIndex = 45
        Me.Option1.TabStop = True
        Me.Option1.Text = "Es tipo servicio para el SRI"
        Me.Option1.UseVisualStyleBackColor = False
        '
        'opbienes
        '
        Me.opbienes.BackColor = System.Drawing.Color.Transparent
        Me.opbienes.Cursor = System.Windows.Forms.Cursors.Default
        Me.opbienes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opbienes.ForeColor = System.Drawing.Color.White
        Me.opbienes.Location = New System.Drawing.Point(505, 67)
        Me.opbienes.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.opbienes.Name = "opbienes"
        Me.opbienes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.opbienes.Size = New System.Drawing.Size(205, 22)
        Me.opbienes.TabIndex = 44
        Me.opbienes.TabStop = True
        Me.opbienes.Text = "Es tipo Bienes para el SRI"
        Me.opbienes.UseVisualStyleBackColor = False
        '
        'chiva
        '
        Me.chiva.BackColor = System.Drawing.Color.Transparent
        Me.chiva.Checked = True
        Me.chiva.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chiva.Cursor = System.Windows.Forms.Cursors.Default
        Me.chiva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chiva.ForeColor = System.Drawing.Color.White
        Me.chiva.Location = New System.Drawing.Point(352, 39)
        Me.chiva.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chiva.Name = "chiva"
        Me.chiva.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chiva.Size = New System.Drawing.Size(145, 22)
        Me.chiva.TabIndex = 43
        Me.chiva.Text = "Gravado con IVA"
        Me.chiva.UseVisualStyleBackColor = False
        '
        'Chkingresobanco
        '
        Me.Chkingresobanco.BackColor = System.Drawing.Color.Transparent
        Me.Chkingresobanco.Cursor = System.Windows.Forms.Cursors.Default
        Me.Chkingresobanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chkingresobanco.ForeColor = System.Drawing.Color.White
        Me.Chkingresobanco.Location = New System.Drawing.Point(19, 96)
        Me.Chkingresobanco.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Chkingresobanco.Name = "Chkingresobanco"
        Me.Chkingresobanco.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Chkingresobanco.Size = New System.Drawing.Size(246, 23)
        Me.Chkingresobanco.TabIndex = 41
        Me.Chkingresobanco.Text = "Concepto para Ingreso a bancos"
        Me.Chkingresobanco.UseVisualStyleBackColor = False
        '
        'chkfacturacion
        '
        Me.chkfacturacion.BackColor = System.Drawing.Color.Transparent
        Me.chkfacturacion.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkfacturacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkfacturacion.ForeColor = System.Drawing.Color.White
        Me.chkfacturacion.Location = New System.Drawing.Point(19, 48)
        Me.chkfacturacion.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkfacturacion.Name = "chkfacturacion"
        Me.chkfacturacion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkfacturacion.Size = New System.Drawing.Size(194, 22)
        Me.chkfacturacion.TabIndex = 40
        Me.chkfacturacion.Text = "Servicio para facturación"
        Me.chkfacturacion.UseVisualStyleBackColor = False
        '
        'Chkcompras
        '
        Me.Chkcompras.BackColor = System.Drawing.Color.Transparent
        Me.Chkcompras.Cursor = System.Windows.Forms.Cursors.Default
        Me.Chkcompras.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chkcompras.ForeColor = System.Drawing.Color.White
        Me.Chkcompras.Location = New System.Drawing.Point(19, 24)
        Me.Chkcompras.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Chkcompras.Name = "Chkcompras"
        Me.Chkcompras.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Chkcompras.Size = New System.Drawing.Size(194, 22)
        Me.Chkcompras.TabIndex = 39
        Me.Chkcompras.Text = "Servicio para compras"
        Me.Chkcompras.UseVisualStyleBackColor = False
        '
        'CtaAlterna
        '
        Me.CtaAlterna.AcceptsReturn = True
        Me.CtaAlterna.BackColor = System.Drawing.SystemColors.Window
        Me.CtaAlterna.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CtaAlterna.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CtaAlterna.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CtaAlterna.Location = New System.Drawing.Point(364, 11)
        Me.CtaAlterna.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CtaAlterna.MaxLength = 45
        Me.CtaAlterna.Name = "CtaAlterna"
        Me.CtaAlterna.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CtaAlterna.Size = New System.Drawing.Size(161, 23)
        Me.CtaAlterna.TabIndex = 25
        '
        'txtNomCta
        '
        Me.txtNomCta.AcceptsReturn = True
        Me.txtNomCta.BackColor = System.Drawing.SystemColors.Window
        Me.txtNomCta.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNomCta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNomCta.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtNomCta.Location = New System.Drawing.Point(70, 48)
        Me.txtNomCta.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtNomCta.MaxLength = 45
        Me.txtNomCta.Name = "txtNomCta"
        Me.txtNomCta.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNomCta.Size = New System.Drawing.Size(457, 23)
        Me.txtNomCta.TabIndex = 19
        '
        'Frame3
        '
        Me.Frame3.BackColor = System.Drawing.Color.DimGray
        Me.Frame3.Controls.Add(Me.txtC2)
        Me.Frame3.Controls.Add(Me.txtC4)
        Me.Frame3.Controls.Add(Me.txtC1)
        Me.Frame3.Controls.Add(Me.txtC3)
        Me.Frame3.Controls.Add(Me.Label14)
        Me.Frame3.Controls.Add(Me.Label13)
        Me.Frame3.Controls.Add(Me.Label15)
        Me.Frame3.Controls.Add(Me.Label16)
        Me.Frame3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Frame3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame3.ForeColor = System.Drawing.Color.Black
        Me.Frame3.Location = New System.Drawing.Point(3, 123)
        Me.Frame3.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Frame3.Name = "Frame3"
        Me.Frame3.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Size = New System.Drawing.Size(857, 249)
        Me.Frame3.TabIndex = 12
        Me.Frame3.TabStop = False
        Me.Frame3.Text = "Claves Agrupación NIIFS - SRI"
        '
        'txtC2
        '
        Me.txtC2.FormattingEnabled = True
        Me.txtC2.Location = New System.Drawing.Point(420, 100)
        Me.txtC2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtC2.Name = "txtC2"
        Me.txtC2.Size = New System.Drawing.Size(326, 25)
        Me.txtC2.TabIndex = 39
        '
        'txtC4
        '
        Me.txtC4.FormattingEnabled = True
        Me.txtC4.Items.AddRange(New Object() {"01-Recalcular a valor presente"})
        Me.txtC4.Location = New System.Drawing.Point(11, 100)
        Me.txtC4.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtC4.Name = "txtC4"
        Me.txtC4.Size = New System.Drawing.Size(326, 25)
        Me.txtC4.TabIndex = 38
        '
        'txtC1
        '
        Me.txtC1.AutoCompleteCustomSource.AddRange(New String() {"01-Ingreso por ventas", "02-Costo de productos vendidos", "03-Gastos comerciales y_o producció", "04-Movimientos Financieros", "05-Impuesto a las Ganancias"})
        Me.txtC1.FormattingEnabled = True
        Me.txtC1.Items.AddRange(New Object() {"INGRESOS POR VENTAS NETAS", "COSTO DE PRODUCTOS VENDIDOS", "GANANCIA BRUTA", "GASTOS DE COMERCIALIZACIÓN Y ADMINISTRACIÓN", "RESULTADO OPERATIVO", "MOVIMIENTOS FINANCIEROS", "IMPUESTO A LAS GANANCIAS"})
        Me.txtC1.Location = New System.Drawing.Point(11, 40)
        Me.txtC1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtC1.Name = "txtC1"
        Me.txtC1.Size = New System.Drawing.Size(326, 25)
        Me.txtC1.TabIndex = 37
        '
        'txtC3
        '
        Me.txtC3.FormattingEnabled = True
        Me.txtC3.Items.AddRange(New Object() {"01-Actv.Operación (Rec.Cliente)", "02-Actv.Operación (Pag.Proveedor)", "03-Actv.Operación (Otros)", "04-Actv.Inversión", "05-Actv.Financiamiento"})
        Me.txtC3.Location = New System.Drawing.Point(420, 47)
        Me.txtC3.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtC3.Name = "txtC3"
        Me.txtC3.Size = New System.Drawing.Size(326, 25)
        Me.txtC3.TabIndex = 36
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(8, 85)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(302, 17)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "Variacion para presentacion de  balances Niifs"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(8, 25)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(226, 17)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "Grupo para Balance de resultados"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(417, 32)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(182, 17)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "Grupo para el Flujo de Caja"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(419, 85)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label16.Size = New System.Drawing.Size(220, 17)
        Me.Label16.TabIndex = 16
        Me.Label16.Text = "Identificativo formulario SRI F-101"
        '
        'Frame6
        '
        Me.Frame6.BackColor = System.Drawing.Color.DimGray
        Me.Frame6.Controls.Add(Me.opMenVar)
        Me.Frame6.Controls.Add(Me.opMenFij)
        Me.Frame6.Controls.Add(Me.opSinPre)
        Me.Frame6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Frame6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame6.ForeColor = System.Drawing.Color.Black
        Me.Frame6.Location = New System.Drawing.Point(3, 3)
        Me.Frame6.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Frame6.Name = "Frame6"
        Me.Frame6.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame6.Size = New System.Drawing.Size(857, 59)
        Me.Frame6.TabIndex = 8
        Me.Frame6.TabStop = False
        Me.Frame6.Text = "Tipo de presupuesto"
        Me.Frame6.Visible = False
        '
        'opMenVar
        '
        Me.opMenVar.BackColor = System.Drawing.Color.Transparent
        Me.opMenVar.Cursor = System.Windows.Forms.Cursors.Default
        Me.opMenVar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opMenVar.ForeColor = System.Drawing.Color.White
        Me.opMenVar.Location = New System.Drawing.Point(400, 21)
        Me.opMenVar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.opMenVar.Name = "opMenVar"
        Me.opMenVar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.opMenVar.Size = New System.Drawing.Size(169, 22)
        Me.opMenVar.TabIndex = 11
        Me.opMenVar.TabStop = True
        Me.opMenVar.Text = "Mensual Variable"
        Me.opMenVar.UseVisualStyleBackColor = False
        '
        'opMenFij
        '
        Me.opMenFij.BackColor = System.Drawing.Color.Transparent
        Me.opMenFij.Cursor = System.Windows.Forms.Cursors.Default
        Me.opMenFij.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opMenFij.ForeColor = System.Drawing.Color.White
        Me.opMenFij.Location = New System.Drawing.Point(244, 21)
        Me.opMenFij.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.opMenFij.Name = "opMenFij"
        Me.opMenFij.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.opMenFij.Size = New System.Drawing.Size(129, 22)
        Me.opMenFij.TabIndex = 9
        Me.opMenFij.TabStop = True
        Me.opMenFij.Text = "Mensual Fijo"
        Me.opMenFij.UseVisualStyleBackColor = False
        '
        'opSinPre
        '
        Me.opSinPre.BackColor = System.Drawing.Color.Transparent
        Me.opSinPre.Checked = True
        Me.opSinPre.Cursor = System.Windows.Forms.Cursors.Default
        Me.opSinPre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opSinPre.ForeColor = System.Drawing.Color.White
        Me.opSinPre.Location = New System.Drawing.Point(62, 21)
        Me.opSinPre.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.opSinPre.Name = "opSinPre"
        Me.opSinPre.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.opSinPre.Size = New System.Drawing.Size(174, 22)
        Me.opSinPre.TabIndex = 10
        Me.opSinPre.TabStop = True
        Me.opSinPre.Text = "Sin Presupuesto"
        Me.opSinPre.UseVisualStyleBackColor = False
        '
        'dcGruCon
        '
        Me.dcGruCon.BackColor = System.Drawing.SystemColors.Window
        Me.dcGruCon.Cursor = System.Windows.Forms.Cursors.Default
        Me.dcGruCon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dcGruCon.ForeColor = System.Drawing.SystemColors.WindowText
        Me.dcGruCon.Items.AddRange(New Object() {"Activos", "Pasivos", "Patrimonio", "Resultados", "Ctas. de Orden"})
        Me.dcGruCon.Location = New System.Drawing.Point(128, 75)
        Me.dcGruCon.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.dcGruCon.Name = "dcGruCon"
        Me.dcGruCon.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dcGruCon.Size = New System.Drawing.Size(192, 25)
        Me.dcGruCon.TabIndex = 1
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ImageList1.Images.SetKeyName(0, "imggrabar")
        Me.ImageList1.Images.SetKeyName(1, "imgsalir")
        '
        'Toolbar1
        '
        Me.Toolbar1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Toolbar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Toolbar1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Toolbar1.ImageList = Me.ImageList1
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.guardar, Me.salir})
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(871, 56)
        Me.Toolbar1.TabIndex = 0
        '
        'guardar
        '
        Me.guardar.Image = CType(resources.GetObject("guardar.Image"), System.Drawing.Image)
        Me.guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.guardar.Name = "guardar"
        Me.guardar.Size = New System.Drawing.Size(65, 53)
        Me.guardar.Text = "Guardar"
        Me.guardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.guardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'salir
        '
        Me.salir.Image = CType(resources.GetObject("salir.Image"), System.Drawing.Image)
        Me.salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.salir.Name = "salir"
        Me.salir.Size = New System.Drawing.Size(40, 53)
        Me.salir.Text = "Salir"
        Me.salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(13, 10)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(388, 24)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Plantilla para detalle en contabilización automática:"
        Me.Label4.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(391, 83)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(136, 17)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Modulo relaciónado:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(281, 14)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(82, 17)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Cod.Alterno"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(85, 17)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Código  Cta."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(8, 52)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(62, 17)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Nombre:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(8, 83)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(112, 17)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Grupo Contable:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Clasificadores)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox1.Size = New System.Drawing.Size(857, 142)
        Me.GroupBox1.TabIndex = 39
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Clasificadores contables"
        '
        'Clasificadores
        '
        Me.Clasificadores.BackColor = System.Drawing.Color.DimGray
        Me.Clasificadores.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Clasificadores.ColumnWidth = 353
        Me.Clasificadores.Cursor = System.Windows.Forms.Cursors.Default
        Me.Clasificadores.Dock = System.Windows.Forms.DockStyle.Top
        Me.Clasificadores.ForeColor = System.Drawing.Color.White
        Me.Clasificadores.IntegralHeight = False
        Me.Clasificadores.Location = New System.Drawing.Point(4, 19)
        Me.Clasificadores.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Clasificadores.MultiColumn = True
        Me.Clasificadores.Name = "Clasificadores"
        Me.Clasificadores.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Clasificadores.Size = New System.Drawing.Size(849, 141)
        Me.Clasificadores.TabIndex = 37
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.DimGray
        Me.GroupBox2.Controls.Add(Me.btnNoProduccion)
        Me.GroupBox2.Controls.Add(Me.btnCI)
        Me.GroupBox2.Controls.Add(Me.btnCD)
        Me.GroupBox2.Controls.Add(Me.btnMO)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(3, 62)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox2.Size = New System.Drawing.Size(857, 61)
        Me.GroupBox2.TabIndex = 42
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "En producción el valor es de:"
        '
        'btnNoProduccion
        '
        Me.btnNoProduccion.AutoSize = True
        Me.btnNoProduccion.BackColor = System.Drawing.Color.Transparent
        Me.btnNoProduccion.Checked = True
        Me.btnNoProduccion.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnNoProduccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNoProduccion.ForeColor = System.Drawing.Color.White
        Me.btnNoProduccion.Location = New System.Drawing.Point(20, 25)
        Me.btnNoProduccion.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnNoProduccion.Name = "btnNoProduccion"
        Me.btnNoProduccion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnNoProduccion.Size = New System.Drawing.Size(82, 21)
        Me.btnNoProduccion.TabIndex = 43
        Me.btnNoProduccion.TabStop = True
        Me.btnNoProduccion.Text = "Ninguno"
        Me.btnNoProduccion.UseVisualStyleBackColor = False
        '
        'btnCI
        '
        Me.btnCI.AutoSize = True
        Me.btnCI.BackColor = System.Drawing.Color.Transparent
        Me.btnCI.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCI.ForeColor = System.Drawing.Color.White
        Me.btnCI.Location = New System.Drawing.Point(588, 25)
        Me.btnCI.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnCI.Name = "btnCI"
        Me.btnCI.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCI.Size = New System.Drawing.Size(137, 21)
        Me.btnCI.TabIndex = 11
        Me.btnCI.Text = "Costos indirectos"
        Me.btnCI.UseVisualStyleBackColor = False
        '
        'btnCD
        '
        Me.btnCD.AutoSize = True
        Me.btnCD.BackColor = System.Drawing.Color.Transparent
        Me.btnCD.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnCD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCD.ForeColor = System.Drawing.Color.White
        Me.btnCD.Location = New System.Drawing.Point(363, 25)
        Me.btnCD.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnCD.Name = "btnCD"
        Me.btnCD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCD.Size = New System.Drawing.Size(126, 21)
        Me.btnCD.TabIndex = 9
        Me.btnCD.Text = "Costos directos"
        Me.btnCD.UseVisualStyleBackColor = False
        '
        'btnMO
        '
        Me.btnMO.AutoSize = True
        Me.btnMO.BackColor = System.Drawing.Color.Transparent
        Me.btnMO.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnMO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMO.ForeColor = System.Drawing.Color.White
        Me.btnMO.Location = New System.Drawing.Point(179, 25)
        Me.btnMO.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnMO.Name = "btnMO"
        Me.btnMO.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnMO.Size = New System.Drawing.Size(120, 21)
        Me.btnMO.TabIndex = 10
        Me.btnMO.Text = "Mano de Obra"
        Me.btnMO.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 177)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(871, 405)
        Me.TabControl1.TabIndex = 43
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.DimGray
        Me.TabPage1.Controls.Add(Me.Frconceptos)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.Panel2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 26)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(863, 375)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Funciones adicionales"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.DimGray
        Me.TabPage2.Controls.Add(Me.Frame3)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.Frame6)
        Me.TabPage2.Location = New System.Drawing.Point(4, 26)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(863, 375)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Relacion otros aplicativos"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.chkDeAgrupacion)
        Me.Panel1.Controls.Add(Me.DcModulo)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.CtaAlterna)
        Me.Panel1.Controls.Add(Me.txtNomCta)
        Me.Panel1.Controls.Add(Me.dcGruCon)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 56)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(871, 121)
        Me.Panel1.TabIndex = 44
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Formatodetalle)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 303)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(857, 69)
        Me.Panel2.TabIndex = 40
        '
        'CTBP01_1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(871, 582)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Toolbar1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 22)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CTBP01_1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "MANTENIMIENTO CUENTAS CONTABLES"
        Me.Frconceptos.ResumeLayout(False)
        Me.Frame3.ResumeLayout(False)
        Me.Frame3.PerformLayout()
        Me.Frame6.ResumeLayout(False)
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents Clasificadores As System.Windows.Forms.CheckedListBox
    Friend WithEvents txtC3 As System.Windows.Forms.ComboBox
    Friend WithEvents txtC1 As System.Windows.Forms.ComboBox
    Friend WithEvents txtC2 As System.Windows.Forms.ComboBox
    Friend WithEvents txtC4 As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Public WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Public WithEvents btnCI As System.Windows.Forms.RadioButton
    Public WithEvents btnCD As System.Windows.Forms.RadioButton
    Public WithEvents btnMO As System.Windows.Forms.RadioButton
    Public WithEvents btnNoProduccion As System.Windows.Forms.RadioButton
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
#End Region
End Class