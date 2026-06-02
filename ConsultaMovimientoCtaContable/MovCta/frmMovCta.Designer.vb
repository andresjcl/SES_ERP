<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMovCta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMovCta))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnProcesar = New System.Windows.Forms.ToolStripButton()
        Me.btnEnviar = New System.Windows.Forms.ToolStripSplitButton()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PDFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.cboDetClas = New System.Windows.Forms.ComboBox()
        Me.cboClas = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboTipoDoc = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbl_Movimiento = New System.Windows.Forms.Label()
        Me.lblSaldoFin = New System.Windows.Forms.Label()
        Me.lblCreditos = New System.Windows.Forms.Label()
        Me.lblDebitos = New System.Windows.Forms.Label()
        Me.lblSaldoIni = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFechaFin = New System.Windows.Forms.MaskedTextBox()
        Me.txtFechaIni = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblctanom = New System.Windows.Forms.Label()
        Me.btnCta = New System.Windows.Forms.Button()
        Me.txtcta = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.malla = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.malla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnProcesar, Me.btnEnviar, Me.ToolStripSeparator1, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(844, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnProcesar
        '
        Me.btnProcesar.ForeColor = System.Drawing.Color.White
        Me.btnProcesar.Image = CType(resources.GetObject("btnProcesar.Image"), System.Drawing.Image)
        Me.btnProcesar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(72, 22)
        Me.btnProcesar.Text = "Procesar"
        '
        'btnEnviar
        '
        Me.btnEnviar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimirToolStripMenuItem, Me.WordToolStripMenuItem, Me.ExcelToolStripMenuItem, Me.PDFToolStripMenuItem})
        Me.btnEnviar.ForeColor = System.Drawing.Color.White
        Me.btnEnviar.Image = CType(resources.GetObject("btnEnviar.Image"), System.Drawing.Image)
        Me.btnEnviar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(71, 22)
        Me.btnEnviar.Text = "Enviar"
        '
        'ImprimirToolStripMenuItem
        '
        Me.ImprimirToolStripMenuItem.Image = CType(resources.GetObject("ImprimirToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        Me.ImprimirToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.ImprimirToolStripMenuItem.Text = "Imprimir"
        '
        'WordToolStripMenuItem
        '
        Me.WordToolStripMenuItem.Image = CType(resources.GetObject("WordToolStripMenuItem.Image"), System.Drawing.Image)
        Me.WordToolStripMenuItem.Name = "WordToolStripMenuItem"
        Me.WordToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.WordToolStripMenuItem.Text = "Word"
        '
        'ExcelToolStripMenuItem
        '
        Me.ExcelToolStripMenuItem.Image = CType(resources.GetObject("ExcelToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExcelToolStripMenuItem.Name = "ExcelToolStripMenuItem"
        Me.ExcelToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.ExcelToolStripMenuItem.Text = "Excel"
        '
        'PDFToolStripMenuItem
        '
        Me.PDFToolStripMenuItem.Image = CType(resources.GetObject("PDFToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PDFToolStripMenuItem.Name = "PDFToolStripMenuItem"
        Me.PDFToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.PDFToolStripMenuItem.Text = "PDF"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnSalir
        '
        Me.btnSalir.ForeColor = System.Drawing.Color.White
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(49, 22)
        Me.btnSalir.Text = "Salir"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboDetClas)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboClas)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboTipoDoc)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.malla)
        Me.SplitContainer1.Size = New System.Drawing.Size(844, 505)
        Me.SplitContainer1.SplitterDistance = 118
        Me.SplitContainer1.TabIndex = 1
        '
        'cboDetClas
        '
        Me.cboDetClas.FormattingEnabled = True
        Me.cboDetClas.Location = New System.Drawing.Point(403, 7)
        Me.cboDetClas.Name = "cboDetClas"
        Me.cboDetClas.Size = New System.Drawing.Size(248, 21)
        Me.cboDetClas.TabIndex = 13
        '
        'cboClas
        '
        Me.cboClas.FormattingEnabled = True
        Me.cboClas.Location = New System.Drawing.Point(314, 7)
        Me.cboClas.Name = "cboClas"
        Me.cboClas.Size = New System.Drawing.Size(88, 21)
        Me.cboClas.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(250, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Clasificador:"
        '
        'cboTipoDoc
        '
        Me.cboTipoDoc.FormattingEnabled = True
        Me.cboTipoDoc.Location = New System.Drawing.Point(95, 7)
        Me.cboTipoDoc.Name = "cboTipoDoc"
        Me.cboTipoDoc.Size = New System.Drawing.Size(137, 21)
        Me.cboTipoDoc.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Documento Tipo:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lbl_Movimiento)
        Me.GroupBox1.Controls.Add(Me.lblSaldoFin)
        Me.GroupBox1.Controls.Add(Me.lblCreditos)
        Me.GroupBox1.Controls.Add(Me.lblDebitos)
        Me.GroupBox1.Controls.Add(Me.lblSaldoIni)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtFechaFin)
        Me.GroupBox1.Controls.Add(Me.txtFechaIni)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblctanom)
        Me.GroupBox1.Controls.Add(Me.btnCta)
        Me.GroupBox1.Controls.Add(Me.txtcta)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(826, 83)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'lbl_Movimiento
        '
        Me.lbl_Movimiento.BackColor = System.Drawing.Color.White
        Me.lbl_Movimiento.ForeColor = System.Drawing.Color.DimGray
        Me.lbl_Movimiento.Location = New System.Drawing.Point(474, 53)
        Me.lbl_Movimiento.Name = "lbl_Movimiento"
        Me.lbl_Movimiento.Size = New System.Drawing.Size(90, 18)
        Me.lbl_Movimiento.TabIndex = 17
        Me.lbl_Movimiento.Text = "0"
        Me.lbl_Movimiento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSaldoFin
        '
        Me.lblSaldoFin.BackColor = System.Drawing.Color.White
        Me.lblSaldoFin.ForeColor = System.Drawing.Color.DimGray
        Me.lblSaldoFin.Location = New System.Drawing.Point(568, 53)
        Me.lblSaldoFin.Name = "lblSaldoFin"
        Me.lblSaldoFin.Size = New System.Drawing.Size(90, 18)
        Me.lblSaldoFin.TabIndex = 16
        Me.lblSaldoFin.Text = "0"
        Me.lblSaldoFin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCreditos
        '
        Me.lblCreditos.BackColor = System.Drawing.Color.White
        Me.lblCreditos.ForeColor = System.Drawing.Color.DimGray
        Me.lblCreditos.Location = New System.Drawing.Point(380, 53)
        Me.lblCreditos.Name = "lblCreditos"
        Me.lblCreditos.Size = New System.Drawing.Size(90, 18)
        Me.lblCreditos.TabIndex = 15
        Me.lblCreditos.Text = "0"
        Me.lblCreditos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDebitos
        '
        Me.lblDebitos.BackColor = System.Drawing.Color.White
        Me.lblDebitos.ForeColor = System.Drawing.Color.DimGray
        Me.lblDebitos.Location = New System.Drawing.Point(286, 53)
        Me.lblDebitos.Name = "lblDebitos"
        Me.lblDebitos.Size = New System.Drawing.Size(90, 18)
        Me.lblDebitos.TabIndex = 14
        Me.lblDebitos.Text = "0"
        Me.lblDebitos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSaldoIni
        '
        Me.lblSaldoIni.BackColor = System.Drawing.Color.White
        Me.lblSaldoIni.ForeColor = System.Drawing.Color.DimGray
        Me.lblSaldoIni.Location = New System.Drawing.Point(192, 53)
        Me.lblSaldoIni.Name = "lblSaldoIni"
        Me.lblSaldoIni.Size = New System.Drawing.Size(90, 18)
        Me.lblSaldoIni.TabIndex = 13
        Me.lblSaldoIni.Text = "0"
        Me.lblSaldoIni.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(489, 40)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 13)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Movimiento"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(580, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 13)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Saldo Final:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(403, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 13)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Creditos"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(312, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Débitos"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(205, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Saldo Inicial:"
        '
        'txtFechaFin
        '
        Me.txtFechaFin.Location = New System.Drawing.Point(102, 53)
        Me.txtFechaFin.Mask = "00/00/0000"
        Me.txtFechaFin.Name = "txtFechaFin"
        Me.txtFechaFin.Size = New System.Drawing.Size(67, 20)
        Me.txtFechaFin.TabIndex = 7
        Me.txtFechaFin.ValidatingType = GetType(Date)
        '
        'txtFechaIni
        '
        Me.txtFechaIni.Location = New System.Drawing.Point(29, 53)
        Me.txtFechaIni.Mask = "00/00/0000"
        Me.txtFechaIni.Name = "txtFechaIni"
        Me.txtFechaIni.Size = New System.Drawing.Size(67, 20)
        Me.txtFechaIni.TabIndex = 5
        Me.txtFechaIni.ValidatingType = GetType(Date)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(26, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Período:"
        '
        'lblctanom
        '
        Me.lblctanom.BackColor = System.Drawing.Color.White
        Me.lblctanom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblctanom.Location = New System.Drawing.Point(194, 13)
        Me.lblctanom.Name = "lblctanom"
        Me.lblctanom.Size = New System.Drawing.Size(442, 20)
        Me.lblctanom.TabIndex = 3
        '
        'btnCta
        '
        Me.btnCta.Location = New System.Drawing.Point(173, 13)
        Me.btnCta.Name = "btnCta"
        Me.btnCta.Size = New System.Drawing.Size(21, 21)
        Me.btnCta.TabIndex = 2
        Me.btnCta.Text = "..."
        Me.btnCta.UseVisualStyleBackColor = True
        '
        'txtcta
        '
        Me.txtcta.Location = New System.Drawing.Point(83, 13)
        Me.txtcta.Name = "txtcta"
        Me.txtcta.Size = New System.Drawing.Size(90, 20)
        Me.txtcta.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(26, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cuenta:"
        '
        'malla
        '
        Me.malla.AllowUserToAddRows = False
        Me.malla.AllowUserToDeleteRows = False
        Me.malla.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.malla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.malla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.NullValue = Nothing
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.malla.DefaultCellStyle = DataGridViewCellStyle2
        Me.malla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.malla.EnableHeadersVisualStyles = False
        Me.malla.GridColor = System.Drawing.Color.Gainsboro
        Me.malla.Location = New System.Drawing.Point(0, 0)
        Me.malla.Name = "malla"
        Me.malla.ReadOnly = True
        Me.malla.RowHeadersVisible = False
        Me.malla.RowHeadersWidth = 20
        Me.malla.Size = New System.Drawing.Size(844, 383)
        Me.malla.TabIndex = 0
        '
        'frmMovCta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(844, 530)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMovCta"
        Me.Text = "CONSULTA DE MOVIMIENTOS DE CUENTAS"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.malla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnProcesar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEnviar As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PDFToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtcta As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents malla As System.Windows.Forms.DataGridView
    Friend WithEvents btnCta As System.Windows.Forms.Button
    Friend WithEvents lblctanom As System.Windows.Forms.Label
    Friend WithEvents txtFechaFin As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtFechaIni As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboTipoDoc As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDetClas As System.Windows.Forms.ComboBox
    Friend WithEvents cboClas As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbl_Movimiento As System.Windows.Forms.Label
    Friend WithEvents lblSaldoFin As System.Windows.Forms.Label
    Friend WithEvents lblCreditos As System.Windows.Forms.Label
    Friend WithEvents lblDebitos As System.Windows.Forms.Label
    Friend WithEvents lblSaldoIni As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label

End Class
