<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBalanceSituacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBalanceSituacion))
        Me.mnuMouse = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditarNotaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtAlMes = New System.Windows.Forms.ComboBox()
        Me.txtDelMes = New System.Windows.Forms.ComboBox()
        Me.cboNivel = New System.Windows.Forms.ComboBox()
        Me.txtDelAño = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblMes = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chkAñoAnt = New System.Windows.Forms.CheckBox()
        Me.chkDiferencia = New System.Windows.Forms.CheckBox()
        Me.chkAño = New System.Windows.Forms.CheckBox()
        Me.chkNombre = New System.Windows.Forms.CheckBox()
        Me.chkCodigo = New System.Windows.Forms.CheckBox()
        Me.chkExcluirNifs = New System.Windows.Forms.CheckBox()
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.RichTextBoxPrintCtrl1 = New RichTextBoxPrintCtrl.RichTextBoxPrintCtrl.RichTextBoxPrintCtrl()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboExpresar = New System.Windows.Forms.ComboBox()
        Me.cboMoneda = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.btnOpciones = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnBalance = New System.Windows.Forms.ToolStripSplitButton()
        Me.BalanceDeSituaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BalanceDeResultadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VariaciónPatrimonialToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnVerNotas = New System.Windows.Forms.ToolStripButton()
        Me.txtCodNota = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnImprNota = New System.Windows.Forms.ToolStripButton()
        Me.btnActualizar = New System.Windows.Forms.ToolStripButton()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.mnuMouse.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuMouse
        '
        Me.mnuMouse.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditarNotaToolStripMenuItem})
        Me.mnuMouse.Name = "ContextMenuStrip1"
        Me.mnuMouse.Size = New System.Drawing.Size(134, 26)
        '
        'EditarNotaToolStripMenuItem
        '
        Me.EditarNotaToolStripMenuItem.AutoSize = False
        Me.EditarNotaToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.EditarNotaToolStripMenuItem.Name = "EditarNotaToolStripMenuItem"
        Me.EditarNotaToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.EditarNotaToolStripMenuItem.Text = "Editar Nota"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.SplitContainer1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 46)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1027, 398)
        Me.Panel2.TabIndex = 15
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ReportViewer1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1027, 398)
        Me.SplitContainer1.SplitterDistance = 198
        Me.SplitContainer1.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.txtAlMes)
        Me.Panel1.Controls.Add(Me.txtDelMes)
        Me.Panel1.Controls.Add(Me.cboNivel)
        Me.Panel1.Controls.Add(Me.txtDelAño)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lblMes)
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.cboTipo)
        Me.Panel1.Controls.Add(Me.RichTextBoxPrintCtrl1)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(198, 398)
        Me.Panel1.TabIndex = 14
        '
        'txtAlMes
        '
        Me.txtAlMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtAlMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlMes.FormattingEnabled = True
        Me.txtAlMes.Items.AddRange(New Object() {""})
        Me.txtAlMes.Location = New System.Drawing.Point(106, 69)
        Me.txtAlMes.Name = "txtAlMes"
        Me.txtAlMes.Size = New System.Drawing.Size(91, 23)
        Me.txtAlMes.TabIndex = 28
        '
        'txtDelMes
        '
        Me.txtDelMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtDelMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDelMes.FormattingEnabled = True
        Me.txtDelMes.Location = New System.Drawing.Point(106, 43)
        Me.txtDelMes.Name = "txtDelMes"
        Me.txtDelMes.Size = New System.Drawing.Size(91, 23)
        Me.txtDelMes.TabIndex = 27
        '
        'cboNivel
        '
        Me.cboNivel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboNivel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboNivel.FormattingEnabled = True
        Me.cboNivel.Items.AddRange(New Object() {"3", "4"})
        Me.cboNivel.Location = New System.Drawing.Point(134, 9)
        Me.cboNivel.Name = "cboNivel"
        Me.cboNivel.Size = New System.Drawing.Size(63, 24)
        Me.cboNivel.TabIndex = 2
        '
        'txtDelAño
        '
        Me.txtDelAño.BackColor = System.Drawing.Color.White
        Me.txtDelAño.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDelAño.Location = New System.Drawing.Point(36, 43)
        Me.txtDelAño.MaxLength = 4
        Me.txtDelAño.Name = "txtDelAño"
        Me.txtDelAño.Size = New System.Drawing.Size(40, 21)
        Me.txtDelAño.TabIndex = 24
        Me.txtDelAño.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(6, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "AÑO:"
        '
        'lblMes
        '
        Me.lblMes.AutoSize = True
        Me.lblMes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblMes.Location = New System.Drawing.Point(91, 74)
        Me.lblMes.Name = "lblMes"
        Me.lblMes.Size = New System.Drawing.Size(17, 13)
        Me.lblMes.TabIndex = 22
        Me.lblMes.Text = "A:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkAñoAnt)
        Me.GroupBox4.Controls.Add(Me.chkDiferencia)
        Me.GroupBox4.Controls.Add(Me.chkAño)
        Me.GroupBox4.Controls.Add(Me.chkNombre)
        Me.GroupBox4.Controls.Add(Me.chkCodigo)
        Me.GroupBox4.Controls.Add(Me.chkExcluirNifs)
        Me.GroupBox4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox4.Location = New System.Drawing.Point(12, 113)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(166, 146)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Columnas a imprimir"
        '
        'chkAñoAnt
        '
        Me.chkAñoAnt.AutoSize = True
        Me.chkAñoAnt.Checked = True
        Me.chkAñoAnt.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAñoAnt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkAñoAnt.Location = New System.Drawing.Point(16, 81)
        Me.chkAñoAnt.Name = "chkAñoAnt"
        Me.chkAñoAnt.Size = New System.Drawing.Size(120, 17)
        Me.chkAñoAnt.TabIndex = 6
        Me.chkAñoAnt.Text = "Valores año anterior"
        Me.chkAñoAnt.UseVisualStyleBackColor = True
        '
        'chkDiferencia
        '
        Me.chkDiferencia.AutoSize = True
        Me.chkDiferencia.Checked = True
        Me.chkDiferencia.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDiferencia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkDiferencia.Location = New System.Drawing.Point(16, 98)
        Me.chkDiferencia.Name = "chkDiferencia"
        Me.chkDiferencia.Size = New System.Drawing.Size(74, 17)
        Me.chkDiferencia.TabIndex = 4
        Me.chkDiferencia.Text = "Diferencia"
        Me.chkDiferencia.UseVisualStyleBackColor = True
        '
        'chkAño
        '
        Me.chkAño.AutoSize = True
        Me.chkAño.Checked = True
        Me.chkAño.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAño.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkAño.Location = New System.Drawing.Point(15, 63)
        Me.chkAño.Name = "chkAño"
        Me.chkAño.Size = New System.Drawing.Size(99, 17)
        Me.chkAño.TabIndex = 3
        Me.chkAño.Text = "Valores del año"
        Me.chkAño.UseVisualStyleBackColor = True
        '
        'chkNombre
        '
        Me.chkNombre.AutoSize = True
        Me.chkNombre.Checked = True
        Me.chkNombre.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkNombre.Location = New System.Drawing.Point(15, 45)
        Me.chkNombre.Name = "chkNombre"
        Me.chkNombre.Size = New System.Drawing.Size(92, 17)
        Me.chkNombre.TabIndex = 2
        Me.chkNombre.Text = "Nro. de Notas"
        Me.chkNombre.UseVisualStyleBackColor = True
        '
        'chkCodigo
        '
        Me.chkCodigo.AutoSize = True
        Me.chkCodigo.Checked = True
        Me.chkCodigo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCodigo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkCodigo.Location = New System.Drawing.Point(15, 28)
        Me.chkCodigo.Name = "chkCodigo"
        Me.chkCodigo.Size = New System.Drawing.Size(95, 17)
        Me.chkCodigo.TabIndex = 1
        Me.chkCodigo.Text = "Código cuenta"
        Me.chkCodigo.UseVisualStyleBackColor = True
        '
        'chkExcluirNifs
        '
        Me.chkExcluirNifs.AutoSize = True
        Me.chkExcluirNifs.Checked = True
        Me.chkExcluirNifs.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkExcluirNifs.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkExcluirNifs.Location = New System.Drawing.Point(16, 115)
        Me.chkExcluirNifs.Name = "chkExcluirNifs"
        Me.chkExcluirNifs.Size = New System.Drawing.Size(80, 17)
        Me.chkExcluirNifs.TabIndex = 7
        Me.chkExcluirNifs.Text = "Asientos N."
        Me.chkExcluirNifs.UseVisualStyleBackColor = True
        Me.chkExcluirNifs.Visible = False
        '
        'cboTipo
        '
        Me.cboTipo.BackColor = System.Drawing.Color.White
        Me.cboTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipo.ForeColor = System.Drawing.Color.Black
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Items.AddRange(New Object() {"Saldo", "Movimiento"})
        Me.cboTipo.Location = New System.Drawing.Point(36, 9)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(93, 24)
        Me.cboTipo.TabIndex = 1
        '
        'RichTextBoxPrintCtrl1
        '
        Me.RichTextBoxPrintCtrl1.Location = New System.Drawing.Point(0, 0)
        Me.RichTextBoxPrintCtrl1.Name = "RichTextBoxPrintCtrl1"
        Me.RichTextBoxPrintCtrl1.Size = New System.Drawing.Size(20, 14)
        Me.RichTextBoxPrintCtrl1.TabIndex = 14
        Me.RichTextBoxPrintCtrl1.Text = ""
        Me.RichTextBoxPrintCtrl1.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboExpresar)
        Me.GroupBox2.Controls.Add(Me.cboMoneda)
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(33, 151)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(119, 69)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Visible = False
        '
        'cboExpresar
        '
        Me.cboExpresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboExpresar.FormattingEnabled = True
        Me.cboExpresar.Items.AddRange(New Object() {"Ninguno", "Cientos", "Miles", "Millones"})
        Me.cboExpresar.Location = New System.Drawing.Point(-3, 42)
        Me.cboExpresar.Name = "cboExpresar"
        Me.cboExpresar.Size = New System.Drawing.Size(99, 21)
        Me.cboExpresar.TabIndex = 1
        '
        'cboMoneda
        '
        Me.cboMoneda.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboMoneda.FormattingEnabled = True
        Me.cboMoneda.Items.AddRange(New Object() {"Dolares"})
        Me.cboMoneda.Location = New System.Drawing.Point(9, 13)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(99, 21)
        Me.cboMoneda.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(5, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Tipo:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(82, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 13)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "DE:"
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(825, 398)
        Me.ReportViewer1.TabIndex = 1
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOpciones, Me.ToolStripSeparator1, Me.btnBalance, Me.ToolStripSeparator3, Me.btnVerNotas, Me.txtCodNota, Me.ToolStripSeparator2, Me.btnImprNota, Me.btnActualizar, Me.btnSalir})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1027, 46)
        Me.ToolStrip2.TabIndex = 21
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'btnOpciones
        '
        Me.btnOpciones.ForeColor = System.Drawing.Color.White
        Me.btnOpciones.Image = CType(resources.GetObject("btnOpciones.Image"), System.Drawing.Image)
        Me.btnOpciones.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOpciones.Name = "btnOpciones"
        Me.btnOpciones.Size = New System.Drawing.Size(61, 43)
        Me.btnOpciones.Text = "Opciones"
        Me.btnOpciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.ForeColor = System.Drawing.Color.White
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 46)
        '
        'btnBalance
        '
        Me.btnBalance.BackColor = System.Drawing.Color.SteelBlue
        Me.btnBalance.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BalanceDeSituaciónToolStripMenuItem, Me.BalanceDeResultadosToolStripMenuItem, Me.VariaciónPatrimonialToolStripMenuItem})
        Me.btnBalance.ForeColor = System.Drawing.Color.White
        Me.btnBalance.Image = CType(resources.GetObject("btnBalance.Image"), System.Drawing.Image)
        Me.btnBalance.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnBalance.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBalance.Name = "btnBalance"
        Me.btnBalance.Size = New System.Drawing.Size(64, 43)
        Me.btnBalance.Text = "Balance"
        Me.btnBalance.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnBalance.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.btnBalance.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BalanceDeSituaciónToolStripMenuItem
        '
        Me.BalanceDeSituaciónToolStripMenuItem.Checked = True
        Me.BalanceDeSituaciónToolStripMenuItem.CheckOnClick = True
        Me.BalanceDeSituaciónToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.BalanceDeSituaciónToolStripMenuItem.Name = "BalanceDeSituaciónToolStripMenuItem"
        Me.BalanceDeSituaciónToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.BalanceDeSituaciónToolStripMenuItem.Text = "Balance de Situación"
        '
        'BalanceDeResultadosToolStripMenuItem
        '
        Me.BalanceDeResultadosToolStripMenuItem.CheckOnClick = True
        Me.BalanceDeResultadosToolStripMenuItem.Name = "BalanceDeResultadosToolStripMenuItem"
        Me.BalanceDeResultadosToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.BalanceDeResultadosToolStripMenuItem.Text = "Balance de Resultados"
        '
        'VariaciónPatrimonialToolStripMenuItem
        '
        Me.VariaciónPatrimonialToolStripMenuItem.Name = "VariaciónPatrimonialToolStripMenuItem"
        Me.VariaciónPatrimonialToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.VariaciónPatrimonialToolStripMenuItem.Text = "Variación Patrimonial"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.ForeColor = System.Drawing.Color.White
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 46)
        '
        'btnVerNotas
        '
        Me.btnVerNotas.Image = CType(resources.GetObject("btnVerNotas.Image"), System.Drawing.Image)
        Me.btnVerNotas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVerNotas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnVerNotas.Name = "btnVerNotas"
        Me.btnVerNotas.Size = New System.Drawing.Size(89, 43)
        Me.btnVerNotas.Text = "Buscar nota"
        Me.btnVerNotas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCodNota
        '
        Me.txtCodNota.BackColor = System.Drawing.Color.White
        Me.txtCodNota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodNota.Name = "txtCodNota"
        Me.txtCodNota.Size = New System.Drawing.Size(100, 46)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.ForeColor = System.Drawing.Color.White
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 46)
        '
        'btnImprNota
        '
        Me.btnImprNota.Image = CType(resources.GetObject("btnImprNota.Image"), System.Drawing.Image)
        Me.btnImprNota.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprNota.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnImprNota.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImprNota.Name = "btnImprNota"
        Me.btnImprNota.Size = New System.Drawing.Size(123, 43)
        Me.btnImprNota.Text = "Imprimir Notas"
        '
        'btnActualizar
        '
        Me.btnActualizar.Image = CType(resources.GetObject("btnActualizar.Image"), System.Drawing.Image)
        Me.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(63, 43)
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnSalir
        '
        Me.btnSalir.ForeColor = System.Drawing.Color.White
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(33, 43)
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 23)
        '
        'frmBalanceSituacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1027, 444)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ToolStrip2)
        Me.ForeColor = System.Drawing.Color.White
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBalanceSituacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estados financieros NIIFS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.mnuMouse.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mnuMouse As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents chkAñoAnt As System.Windows.Forms.CheckBox
    Friend WithEvents chkDiferencia As System.Windows.Forms.CheckBox
    Friend WithEvents chkAño As System.Windows.Forms.CheckBox
    Friend WithEvents chkNombre As System.Windows.Forms.CheckBox
    Friend WithEvents chkCodigo As System.Windows.Forms.CheckBox
    Friend WithEvents chkExcluirNifs As System.Windows.Forms.CheckBox
    Friend WithEvents RichTextBoxPrintCtrl1 As RichTextBoxPrintCtrl.RichTextBoxPrintCtrl.RichTextBoxPrintCtrl
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboExpresar As System.Windows.Forms.ComboBox
    Friend WithEvents cboMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents cboNivel As System.Windows.Forms.ComboBox
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents EditarNotaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnOpciones As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnVerNotas As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtCodNota As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnImprNota As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnBalance As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents BalanceDeSituaciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BalanceDeResultadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VariaciónPatrimonialToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDelAño As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblMes As System.Windows.Forms.Label
    Friend WithEvents txtAlMes As System.Windows.Forms.ComboBox
    Friend WithEvents txtDelMes As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
