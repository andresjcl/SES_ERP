<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAnlMovCta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAnlMovCta))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnOpciones = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnEnviar = New System.Windows.Forms.ToolStripSplitButton()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PDFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDetalle = New System.Windows.Forms.ToolStripButton()
        Me.btnActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.añoanalisis = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optMovimientos = New System.Windows.Forms.RadioButton()
        Me.optCreditos = New System.Windows.Forms.RadioButton()
        Me.optDebitos = New System.Windows.Forms.RadioButton()
        Me.chkCtaMov = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboNivel = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboClasDet = New System.Windows.Forms.ComboBox()
        Me.cboClas = New System.Windows.Forms.ComboBox()
        Me.lblCtaFin = New System.Windows.Forms.Label()
        Me.lblctaIni = New System.Windows.Forms.Label()
        Me.chkAuxiliares = New System.Windows.Forms.CheckBox()
        Me.btnCtaFin = New System.Windows.Forms.Button()
        Me.txtCtaFin = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCtaIni = New System.Windows.Forms.Button()
        Me.txtctaIni = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.malla = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MovimientoDeLaCuentaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.malla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOpciones, Me.ToolStripSeparator2, Me.btnEnviar, Me.btnDetalle, Me.btnActualizar, Me.ToolStripSeparator1, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1081, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnOpciones
        '
        Me.btnOpciones.Image = CType(resources.GetObject("btnOpciones.Image"), System.Drawing.Image)
        Me.btnOpciones.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOpciones.Name = "btnOpciones"
        Me.btnOpciones.Size = New System.Drawing.Size(77, 22)
        Me.btnOpciones.Text = "Opciones"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnEnviar
        '
        Me.btnEnviar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimirToolStripMenuItem, Me.WordToolStripMenuItem, Me.ExcelToolStripMenuItem, Me.PDFToolStripMenuItem})
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
        'btnDetalle
        '
        Me.btnDetalle.Image = CType(resources.GetObject("btnDetalle.Image"), System.Drawing.Image)
        Me.btnDetalle.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDetalle.Name = "btnDetalle"
        Me.btnDetalle.Size = New System.Drawing.Size(63, 22)
        Me.btnDetalle.Text = "Detalle"
        '
        'btnActualizar
        '
        Me.btnActualizar.Image = CType(resources.GetObject("btnActualizar.Image"), System.Drawing.Image)
        Me.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(79, 22)
        Me.btnActualizar.Text = "Actualizar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnSalir
        '
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(49, 22)
        Me.btnSalir.Text = "Salir"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.añoanalisis)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkCtaMov)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboNivel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboClasDet)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboClas)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblCtaFin)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblctaIni)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkAuxiliares)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnCtaFin)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtCtaFin)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnCtaIni)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtctaIni)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.malla)
        Me.SplitContainer1.Size = New System.Drawing.Size(1081, 544)
        Me.SplitContainer1.SplitterDistance = 256
        Me.SplitContainer1.TabIndex = 1
        '
        'añoanalisis
        '
        Me.añoanalisis.Location = New System.Drawing.Point(183, 6)
        Me.añoanalisis.Name = "añoanalisis"
        Me.añoanalisis.Size = New System.Drawing.Size(53, 20)
        Me.añoanalisis.TabIndex = 22
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(152, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Año:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optMovimientos)
        Me.GroupBox1.Controls.Add(Me.optCreditos)
        Me.GroupBox1.Controls.Add(Me.optDebitos)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 95)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(246, 94)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Analizar con valores de:"
        '
        'optMovimientos
        '
        Me.optMovimientos.AutoSize = True
        Me.optMovimientos.Checked = True
        Me.optMovimientos.Location = New System.Drawing.Point(18, 19)
        Me.optMovimientos.Name = "optMovimientos"
        Me.optMovimientos.Size = New System.Drawing.Size(79, 17)
        Me.optMovimientos.TabIndex = 11
        Me.optMovimientos.TabStop = True
        Me.optMovimientos.Text = "Movimiento"
        Me.optMovimientos.UseVisualStyleBackColor = True
        '
        'optCreditos
        '
        Me.optCreditos.AutoSize = True
        Me.optCreditos.Location = New System.Drawing.Point(18, 65)
        Me.optCreditos.Name = "optCreditos"
        Me.optCreditos.Size = New System.Drawing.Size(63, 17)
        Me.optCreditos.TabIndex = 10
        Me.optCreditos.Text = "Créditos"
        Me.optCreditos.UseVisualStyleBackColor = True
        '
        'optDebitos
        '
        Me.optDebitos.AutoSize = True
        Me.optDebitos.Location = New System.Drawing.Point(18, 42)
        Me.optDebitos.Name = "optDebitos"
        Me.optDebitos.Size = New System.Drawing.Size(61, 17)
        Me.optDebitos.TabIndex = 9
        Me.optDebitos.Text = "Débitos"
        Me.optDebitos.UseVisualStyleBackColor = True
        '
        'chkCtaMov
        '
        Me.chkCtaMov.AutoSize = True
        Me.chkCtaMov.Location = New System.Drawing.Point(8, 37)
        Me.chkCtaMov.Name = "chkCtaMov"
        Me.chkCtaMov.Size = New System.Drawing.Size(161, 17)
        Me.chkCtaMov.TabIndex = 19
        Me.chkCtaMov.Text = "Solo Cuentas de Movimiento"
        Me.chkCtaMov.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Nivel de Cuenta:"
        '
        'cboNivel
        '
        Me.cboNivel.FormattingEnabled = True
        Me.cboNivel.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6"})
        Me.cboNivel.Location = New System.Drawing.Point(98, 6)
        Me.cboNivel.Name = "cboNivel"
        Me.cboNivel.Size = New System.Drawing.Size(46, 21)
        Me.cboNivel.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 326)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Clasificadores:"
        Me.Label3.Visible = False
        '
        'cboClasDet
        '
        Me.cboClasDet.FormattingEnabled = True
        Me.cboClasDet.Location = New System.Drawing.Point(5, 361)
        Me.cboClasDet.Name = "cboClasDet"
        Me.cboClasDet.Size = New System.Drawing.Size(247, 21)
        Me.cboClasDet.TabIndex = 15
        Me.cboClasDet.Visible = False
        '
        'cboClas
        '
        Me.cboClas.FormattingEnabled = True
        Me.cboClas.Location = New System.Drawing.Point(4, 339)
        Me.cboClas.Name = "cboClas"
        Me.cboClas.Size = New System.Drawing.Size(129, 21)
        Me.cboClas.TabIndex = 14
        Me.cboClas.Visible = False
        '
        'lblCtaFin
        '
        Me.lblCtaFin.BackColor = System.Drawing.Color.White
        Me.lblCtaFin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCtaFin.Location = New System.Drawing.Point(5, 299)
        Me.lblCtaFin.Name = "lblCtaFin"
        Me.lblCtaFin.Size = New System.Drawing.Size(247, 20)
        Me.lblCtaFin.TabIndex = 13
        '
        'lblctaIni
        '
        Me.lblctaIni.BackColor = System.Drawing.Color.White
        Me.lblctaIni.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblctaIni.Location = New System.Drawing.Point(4, 237)
        Me.lblctaIni.Name = "lblctaIni"
        Me.lblctaIni.Size = New System.Drawing.Size(248, 20)
        Me.lblctaIni.TabIndex = 12
        '
        'chkAuxiliares
        '
        Me.chkAuxiliares.AutoSize = True
        Me.chkAuxiliares.Location = New System.Drawing.Point(8, 62)
        Me.chkAuxiliares.Name = "chkAuxiliares"
        Me.chkAuxiliares.Size = New System.Drawing.Size(151, 17)
        Me.chkAuxiliares.TabIndex = 8
        Me.chkAuxiliares.Text = "Detallar Cuentas Auxiliares"
        Me.chkAuxiliares.UseVisualStyleBackColor = True
        '
        'btnCtaFin
        '
        Me.btnCtaFin.Location = New System.Drawing.Point(112, 278)
        Me.btnCtaFin.Name = "btnCtaFin"
        Me.btnCtaFin.Size = New System.Drawing.Size(21, 21)
        Me.btnCtaFin.TabIndex = 6
        Me.btnCtaFin.Text = "..."
        Me.btnCtaFin.UseVisualStyleBackColor = True
        '
        'txtCtaFin
        '
        Me.txtCtaFin.Location = New System.Drawing.Point(5, 278)
        Me.txtCtaFin.Name = "txtCtaFin"
        Me.txtCtaFin.Size = New System.Drawing.Size(107, 20)
        Me.txtCtaFin.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 266)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Cuenta Final:"
        '
        'btnCtaIni
        '
        Me.btnCtaIni.Location = New System.Drawing.Point(112, 216)
        Me.btnCtaIni.Name = "btnCtaIni"
        Me.btnCtaIni.Size = New System.Drawing.Size(21, 21)
        Me.btnCtaIni.TabIndex = 2
        Me.btnCtaIni.Text = "..."
        Me.btnCtaIni.UseVisualStyleBackColor = True
        '
        'txtctaIni
        '
        Me.txtctaIni.Location = New System.Drawing.Point(5, 216)
        Me.txtctaIni.Name = "txtctaIni"
        Me.txtctaIni.Size = New System.Drawing.Size(107, 20)
        Me.txtctaIni.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 204)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cuenta Inicial:"
        '
        'malla
        '
        Me.malla.AllowUserToAddRows = False
        Me.malla.AllowUserToDeleteRows = False
        Me.malla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
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
        Me.malla.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.malla.DefaultCellStyle = DataGridViewCellStyle2
        Me.malla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.malla.EnableHeadersVisualStyles = False
        Me.malla.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.malla.Location = New System.Drawing.Point(0, 0)
        Me.malla.Name = "malla"
        Me.malla.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.malla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.malla.RowHeadersWidth = 21
        Me.malla.Size = New System.Drawing.Size(821, 544)
        Me.malla.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MovimientoDeLaCuentaToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(207, 26)
        '
        'MovimientoDeLaCuentaToolStripMenuItem
        '
        Me.MovimientoDeLaCuentaToolStripMenuItem.Name = "MovimientoDeLaCuentaToolStripMenuItem"
        Me.MovimientoDeLaCuentaToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.MovimientoDeLaCuentaToolStripMenuItem.Text = "Movimiento de la cuenta"
        '
        'FrmAnlMovCta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1081, 569)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmAnlMovCta"
        Me.Text = "ANÁLISIS DE MOVIMIENTOS DE CUENTAS"
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
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnDetalle As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnCtaIni As System.Windows.Forms.Button
    Friend WithEvents txtctaIni As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents malla As System.Windows.Forms.DataGridView
    Friend WithEvents lblCtaFin As System.Windows.Forms.Label
    Friend WithEvents lblctaIni As System.Windows.Forms.Label
    Friend WithEvents optMovimientos As System.Windows.Forms.RadioButton
    Friend WithEvents optCreditos As System.Windows.Forms.RadioButton
    Friend WithEvents optDebitos As System.Windows.Forms.RadioButton
    Friend WithEvents chkAuxiliares As System.Windows.Forms.CheckBox
    Friend WithEvents btnCtaFin As System.Windows.Forms.Button
    Friend WithEvents txtCtaFin As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnEnviar As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PDFToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboClasDet As System.Windows.Forms.ComboBox
    Friend WithEvents cboClas As System.Windows.Forms.ComboBox
    Friend WithEvents chkCtaMov As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboNivel As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOpciones As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MovimientoDeLaCuentaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents añoanalisis As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
