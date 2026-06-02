<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDocPend
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDocPend))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TotalAbono = New System.Windows.Forms.Label()
        Me.TotalDocumento = New System.Windows.Forms.Label()
        Me.ValorARepartir = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chkSoloAutorizados = New System.Windows.Forms.CheckBox()
        Me.chkCuentasPagar = New System.Windows.Forms.CheckBox()
        Me.chkCentasCobrar = New System.Windows.Forms.CheckBox()
        Me.MallaCorr = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnEnviar = New System.Windows.Forms.ToolStripSplitButton()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PDFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAplicaciones = New System.Windows.Forms.ToolStripButton()
        Me.btnAceptar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.MallaCorr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TotalAbono)
        Me.Panel1.Controls.Add(Me.TotalDocumento)
        Me.Panel1.Controls.Add(Me.ValorARepartir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 314)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(826, 43)
        Me.Panel1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(662, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Total Abonos"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(16, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Valor a repartir:"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(473, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Total documentos"
        '
        'TotalAbono
        '
        Me.TotalAbono.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TotalAbono.BackColor = System.Drawing.Color.White
        Me.TotalAbono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotalAbono.Location = New System.Drawing.Point(734, 11)
        Me.TotalAbono.Name = "TotalAbono"
        Me.TotalAbono.Size = New System.Drawing.Size(77, 23)
        Me.TotalAbono.TabIndex = 2
        Me.TotalAbono.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TotalDocumento
        '
        Me.TotalDocumento.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TotalDocumento.BackColor = System.Drawing.Color.White
        Me.TotalDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotalDocumento.Location = New System.Drawing.Point(571, 11)
        Me.TotalDocumento.Name = "TotalDocumento"
        Me.TotalDocumento.Size = New System.Drawing.Size(75, 23)
        Me.TotalDocumento.TabIndex = 1
        Me.TotalDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ValorARepartir
        '
        Me.ValorARepartir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ValorARepartir.Location = New System.Drawing.Point(100, 14)
        Me.ValorARepartir.MaxLength = 15
        Me.ValorARepartir.Name = "ValorARepartir"
        Me.ValorARepartir.Size = New System.Drawing.Size(80, 20)
        Me.ValorARepartir.TabIndex = 1
        Me.ValorARepartir.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel2
        '
        Me.Panel2.AutoSize = True
        Me.Panel2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel2.Controls.Add(Me.chkSoloAutorizados)
        Me.Panel2.Controls.Add(Me.chkCuentasPagar)
        Me.Panel2.Controls.Add(Me.chkCentasCobrar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 31)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(826, 26)
        Me.Panel2.TabIndex = 1
        '
        'chkSoloAutorizados
        '
        Me.chkSoloAutorizados.AutoSize = True
        Me.chkSoloAutorizados.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSoloAutorizados.ForeColor = System.Drawing.Color.DimGray
        Me.chkSoloAutorizados.Location = New System.Drawing.Point(413, 4)
        Me.chkSoloAutorizados.Name = "chkSoloAutorizados"
        Me.chkSoloAutorizados.Size = New System.Drawing.Size(189, 19)
        Me.chkSoloAutorizados.TabIndex = 4
        Me.chkSoloAutorizados.Text = "Solo documentos Autorizados"
        Me.chkSoloAutorizados.UseVisualStyleBackColor = True
        Me.chkSoloAutorizados.Visible = False
        '
        'chkCuentasPagar
        '
        Me.chkCuentasPagar.AutoSize = True
        Me.chkCuentasPagar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCuentasPagar.ForeColor = System.Drawing.Color.DimGray
        Me.chkCuentasPagar.Location = New System.Drawing.Point(160, 3)
        Me.chkCuentasPagar.Name = "chkCuentasPagar"
        Me.chkCuentasPagar.Size = New System.Drawing.Size(169, 19)
        Me.chkCuentasPagar.TabIndex = 1
        Me.chkCuentasPagar.Text = "Ctas x Pagar Proveedores"
        Me.chkCuentasPagar.UseVisualStyleBackColor = True
        '
        'chkCentasCobrar
        '
        Me.chkCentasCobrar.AutoSize = True
        Me.chkCentasCobrar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCentasCobrar.ForeColor = System.Drawing.Color.DimGray
        Me.chkCentasCobrar.Location = New System.Drawing.Point(7, 3)
        Me.chkCentasCobrar.Name = "chkCentasCobrar"
        Me.chkCentasCobrar.Size = New System.Drawing.Size(150, 19)
        Me.chkCentasCobrar.TabIndex = 0
        Me.chkCentasCobrar.Text = "Ctas x Cobrar Clientes"
        Me.chkCentasCobrar.UseVisualStyleBackColor = True
        '
        'MallaCorr
        '
        Me.MallaCorr.AllowUserToAddRows = False
        Me.MallaCorr.AllowUserToDeleteRows = False
        Me.MallaCorr.AllowUserToOrderColumns = True
        Me.MallaCorr.AllowUserToResizeColumns = False
        Me.MallaCorr.AllowUserToResizeRows = False
        Me.MallaCorr.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.MallaCorr.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MallaCorr.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.MallaCorr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.MallaCorr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MallaCorr.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.MallaCorr.EnableHeadersVisualStyles = False
        Me.MallaCorr.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.MallaCorr.Location = New System.Drawing.Point(0, 57)
        Me.MallaCorr.Name = "MallaCorr"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.NullValue = Nothing
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MallaCorr.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.MallaCorr.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.MallaCorr.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.MallaCorr.Size = New System.Drawing.Size(826, 257)
        Me.MallaCorr.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnEnviar, Me.btnAplicaciones, Me.btnAceptar, Me.ToolStripSeparator1, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(826, 31)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnEnviar
        '
        Me.btnEnviar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimirToolStripMenuItem, Me.WordToolStripMenuItem, Me.ExcelToolStripMenuItem, Me.PDFToolStripMenuItem})
        Me.btnEnviar.ForeColor = System.Drawing.Color.White
        Me.btnEnviar.Image = CType(resources.GetObject("btnEnviar.Image"), System.Drawing.Image)
        Me.btnEnviar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(55, 43)
        Me.btnEnviar.Text = "Enviar"
        Me.btnEnviar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnEnviar.Visible = False
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
        'btnAplicaciones
        '
        Me.btnAplicaciones.ForeColor = System.Drawing.Color.White
        Me.btnAplicaciones.Image = CType(resources.GetObject("btnAplicaciones.Image"), System.Drawing.Image)
        Me.btnAplicaciones.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAplicaciones.Name = "btnAplicaciones"
        Me.btnAplicaciones.Size = New System.Drawing.Size(102, 28)
        Me.btnAplicaciones.Text = "Aplicaciones"
        '
        'btnAceptar
        '
        Me.btnAceptar.ForeColor = System.Drawing.Color.White
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(76, 28)
        Me.btnAceptar.Text = "Aceptar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'btnSalir
        '
        Me.btnSalir.ForeColor = System.Drawing.Color.White
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(57, 28)
        Me.btnSalir.Text = "Salir"
        '
        'FormDocPend
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(826, 357)
        Me.Controls.Add(Me.MallaCorr)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormDocPend"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DOCUMENTOS PENDIENTES DE CUENTAS CORRIENTES"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.MallaCorr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TotalAbono As System.Windows.Forms.Label
    Friend WithEvents TotalDocumento As System.Windows.Forms.Label
    Friend WithEvents ValorARepartir As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents chkSoloAutorizados As System.Windows.Forms.CheckBox
    Friend WithEvents chkCuentasPagar As System.Windows.Forms.CheckBox
    Friend WithEvents chkCentasCobrar As System.Windows.Forms.CheckBox
    Friend WithEvents MallaCorr As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAceptar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEnviar As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PDFToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAplicaciones As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
