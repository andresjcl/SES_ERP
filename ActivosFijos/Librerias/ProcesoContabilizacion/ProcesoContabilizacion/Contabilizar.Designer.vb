<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contabilizar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contabilizar))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnOpciones = New System.Windows.Forms.ToolStripButton()
        Me.btnGenerar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtMes = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAño = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtDocNumero = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboDoc = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkDepTribut = New System.Windows.Forms.CheckBox()
        Me.chkDiferencia = New System.Windows.Forms.CheckBox()
        Me.chkDepFinan = New System.Windows.Forms.CheckBox()
        Me.chkDet = New System.Windows.Forms.CheckBox()
        Me.chkReval = New System.Windows.Forms.CheckBox()
        Me.malla = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.malla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOpciones, Me.btnGenerar, Me.ToolStripSeparator1, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(861, 38)
        Me.ToolStrip1.TabIndex = 0
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
        'btnGenerar
        '
        Me.btnGenerar.Image = CType(resources.GetObject("btnGenerar.Image"), System.Drawing.Image)
        Me.btnGenerar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(52, 35)
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 38)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.malla)
        Me.SplitContainer1.Size = New System.Drawing.Size(861, 453)
        Me.SplitContainer1.SplitterDistance = 256
        Me.SplitContainer1.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtMes)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtAño)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(150, 40)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Emitir Contabilidad"
        '
        'txtMes
        '
        Me.txtMes.Location = New System.Drawing.Point(107, 14)
        Me.txtMes.Mask = "99"
        Me.txtMes.Name = "txtMes"
        Me.txtMes.Size = New System.Drawing.Size(23, 20)
        Me.txtMes.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(78, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Mes:"
        '
        'txtAño
        '
        Me.txtAño.Location = New System.Drawing.Point(33, 14)
        Me.txtAño.Mask = "9999"
        Me.txtAño.Name = "txtAño"
        Me.txtAño.Size = New System.Drawing.Size(33, 20)
        Me.txtAño.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Año:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtDocNumero)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.cboDoc)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 168)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(231, 119)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Documento "
        '
        'txtDocNumero
        '
        Me.txtDocNumero.Location = New System.Drawing.Point(9, 78)
        Me.txtDocNumero.Name = "txtDocNumero"
        Me.txtDocNumero.Size = New System.Drawing.Size(31, 20)
        Me.txtDocNumero.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Número de Documento:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Documento a Generar:"
        '
        'cboDoc
        '
        Me.cboDoc.FormattingEnabled = True
        Me.cboDoc.Location = New System.Drawing.Point(7, 38)
        Me.cboDoc.Name = "cboDoc"
        Me.cboDoc.Size = New System.Drawing.Size(211, 21)
        Me.cboDoc.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkDepTribut)
        Me.GroupBox2.Controls.Add(Me.chkDiferencia)
        Me.GroupBox2.Controls.Add(Me.chkDepFinan)
        Me.GroupBox2.Controls.Add(Me.chkDet)
        Me.GroupBox2.Controls.Add(Me.chkReval)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 61)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(231, 96)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Contabilizar:"
        '
        'chkDepTribut
        '
        Me.chkDepTribut.AutoSize = True
        Me.chkDepTribut.Checked = True
        Me.chkDepTribut.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDepTribut.Location = New System.Drawing.Point(130, 38)
        Me.chkDepTribut.Name = "chkDepTribut"
        Me.chkDepTribut.Size = New System.Drawing.Size(88, 17)
        Me.chkDepTribut.TabIndex = 4
        Me.chkDepTribut.Text = "Depre. Tribut"
        Me.chkDepTribut.UseVisualStyleBackColor = True
        '
        'chkDiferencia
        '
        Me.chkDiferencia.AutoSize = True
        Me.chkDiferencia.Checked = True
        Me.chkDiferencia.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDiferencia.Location = New System.Drawing.Point(7, 61)
        Me.chkDiferencia.Name = "chkDiferencia"
        Me.chkDiferencia.Size = New System.Drawing.Size(140, 17)
        Me.chkDiferencia.TabIndex = 3
        Me.chkDiferencia.Text = "Diferencia Depreciación"
        Me.chkDiferencia.UseVisualStyleBackColor = True
        '
        'chkDepFinan
        '
        Me.chkDepFinan.AutoSize = True
        Me.chkDepFinan.Checked = True
        Me.chkDepFinan.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDepFinan.Location = New System.Drawing.Point(7, 38)
        Me.chkDepFinan.Name = "chkDepFinan"
        Me.chkDepFinan.Size = New System.Drawing.Size(93, 17)
        Me.chkDepFinan.TabIndex = 2
        Me.chkDepFinan.Text = "Depre. Financ"
        Me.chkDepFinan.UseVisualStyleBackColor = True
        '
        'chkDet
        '
        Me.chkDet.AutoSize = True
        Me.chkDet.Checked = True
        Me.chkDet.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDet.Location = New System.Drawing.Point(130, 15)
        Me.chkDet.Name = "chkDet"
        Me.chkDet.Size = New System.Drawing.Size(69, 17)
        Me.chkDet.TabIndex = 1
        Me.chkDet.Text = "Deterioro"
        Me.chkDet.UseVisualStyleBackColor = True
        '
        'chkReval
        '
        Me.chkReval.AutoSize = True
        Me.chkReval.Checked = True
        Me.chkReval.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkReval.Location = New System.Drawing.Point(7, 15)
        Me.chkReval.Name = "chkReval"
        Me.chkReval.Size = New System.Drawing.Size(96, 17)
        Me.chkReval.TabIndex = 0
        Me.chkReval.Text = "Revalorización"
        Me.chkReval.UseVisualStyleBackColor = True
        '
        'malla
        '
        Me.malla.AllowUserToAddRows = False
        Me.malla.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.malla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.malla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.malla.EnableHeadersVisualStyles = False
        Me.malla.Location = New System.Drawing.Point(0, 0)
        Me.malla.Name = "malla"
        Me.malla.RowHeadersWidth = 21
        Me.malla.Size = New System.Drawing.Size(601, 453)
        Me.malla.TabIndex = 0
        '
        'Contabilizar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(861, 491)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Contabilizar"
        Me.Text = "Realizar  Contabilización"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.malla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMes As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAño As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDoc As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkDepTribut As System.Windows.Forms.CheckBox
    Friend WithEvents chkDiferencia As System.Windows.Forms.CheckBox
    Friend WithEvents chkDepFinan As System.Windows.Forms.CheckBox
    Friend WithEvents chkDet As System.Windows.Forms.CheckBox
    Friend WithEvents chkReval As System.Windows.Forms.CheckBox
    Friend WithEvents btnOpciones As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGenerar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtDocNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents malla As System.Windows.Forms.DataGridView

End Class
