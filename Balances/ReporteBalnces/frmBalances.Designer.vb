<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBalances
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBalances))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.txtFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.txtFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.CheckNiifs = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboNivel = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkFirmas = New System.Windows.Forms.CheckBox()
        Me.chkConSaldo0 = New System.Windows.Forms.CheckBox()
        Me.chkCtasOrden = New System.Windows.Forms.CheckBox()
        Me.optMovimiento = New System.Windows.Forms.RadioButton()
        Me.optSaldos = New System.Windows.Forms.RadioButton()
        Me.lblFechaFin = New System.Windows.Forms.Label()
        Me.lblFechaInicio = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.btnOpciones = New System.Windows.Forms.ToolStripButton()
        Me.BalanceDeComprobaciónToolStripMenuItem = New System.Windows.Forms.ToolStripButton()
        Me.BalanceGeneralToolStripMenuItem = New System.Windows.Forms.ToolStripButton()
        Me.BalanceResultadosToolStripMenuItem = New System.Windows.Forms.ToolStripButton()
        Me.BalancesAmpliadosToolStripMenuItem = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResultadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.Actualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.DimGray
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOpciones, Me.ToolStripSeparator2, Me.BalanceDeComprobaciónToolStripMenuItem, Me.BalanceGeneralToolStripMenuItem, Me.BalanceResultadosToolStripMenuItem, Me.BalancesAmpliadosToolStripMenuItem, Me.ToolStripSeparator1, Me.btnSalir, Me.Actualizar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1221, 47)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.ForeColor = System.Drawing.Color.White
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 47)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.ForeColor = System.Drawing.Color.White
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 47)
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.DimGray
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 47)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtFechaFin)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtFechaInicio)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CheckNiifs)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboNivel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblFechaFin)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblFechaInicio)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1MinSize = 20
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ReportViewer1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1221, 562)
        Me.SplitContainer1.SplitterDistance = 238
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 2
        '
        'txtFechaFin
        '
        Me.txtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaFin.Location = New System.Drawing.Point(122, 66)
        Me.txtFechaFin.Name = "txtFechaFin"
        Me.txtFechaFin.Size = New System.Drawing.Size(113, 22)
        Me.txtFechaFin.TabIndex = 23
        '
        'txtFechaInicio
        '
        Me.txtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaInicio.Location = New System.Drawing.Point(122, 38)
        Me.txtFechaInicio.Name = "txtFechaInicio"
        Me.txtFechaInicio.Size = New System.Drawing.Size(113, 22)
        Me.txtFechaInicio.TabIndex = 22
        '
        'CheckNiifs
        '
        Me.CheckNiifs.AutoSize = True
        Me.CheckNiifs.Checked = True
        Me.CheckNiifs.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckNiifs.Location = New System.Drawing.Point(29, 158)
        Me.CheckNiifs.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckNiifs.Name = "CheckNiifs"
        Me.CheckNiifs.Size = New System.Drawing.Size(128, 21)
        Me.CheckNiifs.TabIndex = 21
        Me.CheckNiifs.Text = "Incluir asientos "
        Me.CheckNiifs.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 116)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 17)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Nivel de las cuentas:"
        '
        'cboNivel
        '
        Me.cboNivel.FormattingEnabled = True
        Me.cboNivel.Items.AddRange(New Object() {"2", "3", "4", "5", "6"})
        Me.cboNivel.Location = New System.Drawing.Point(175, 112)
        Me.cboNivel.Margin = New System.Windows.Forms.Padding(4)
        Me.cboNivel.Name = "cboNivel"
        Me.cboNivel.Size = New System.Drawing.Size(73, 24)
        Me.cboNivel.TabIndex = 19
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.DarkGray
        Me.GroupBox2.Controls.Add(Me.chkFirmas)
        Me.GroupBox2.Controls.Add(Me.chkConSaldo0)
        Me.GroupBox2.Controls.Add(Me.chkCtasOrden)
        Me.GroupBox2.Controls.Add(Me.optMovimiento)
        Me.GroupBox2.Controls.Add(Me.optSaldos)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 207)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(284, 167)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Opciones a incluir en los balances"
        '
        'chkFirmas
        '
        Me.chkFirmas.AutoSize = True
        Me.chkFirmas.Location = New System.Drawing.Point(32, 122)
        Me.chkFirmas.Margin = New System.Windows.Forms.Padding(4)
        Me.chkFirmas.Name = "chkFirmas"
        Me.chkFirmas.Size = New System.Drawing.Size(72, 21)
        Me.chkFirmas.TabIndex = 13
        Me.chkFirmas.Text = "Firmas"
        Me.chkFirmas.UseVisualStyleBackColor = True
        '
        'chkConSaldo0
        '
        Me.chkConSaldo0.AutoSize = True
        Me.chkConSaldo0.Location = New System.Drawing.Point(32, 94)
        Me.chkConSaldo0.Margin = New System.Windows.Forms.Padding(4)
        Me.chkConSaldo0.Name = "chkConSaldo0"
        Me.chkConSaldo0.Size = New System.Drawing.Size(139, 21)
        Me.chkConSaldo0.TabIndex = 12
        Me.chkConSaldo0.Text = "Cuentas sin valor"
        Me.chkConSaldo0.UseVisualStyleBackColor = True
        '
        'chkCtasOrden
        '
        Me.chkCtasOrden.AutoSize = True
        Me.chkCtasOrden.Location = New System.Drawing.Point(32, 65)
        Me.chkCtasOrden.Margin = New System.Windows.Forms.Padding(4)
        Me.chkCtasOrden.Name = "chkCtasOrden"
        Me.chkCtasOrden.Size = New System.Drawing.Size(146, 21)
        Me.chkCtasOrden.TabIndex = 11
        Me.chkCtasOrden.Text = "Cuentas de Orden"
        Me.chkCtasOrden.UseVisualStyleBackColor = True
        '
        'optMovimiento
        '
        Me.optMovimiento.AutoSize = True
        Me.optMovimiento.Location = New System.Drawing.Point(121, 31)
        Me.optMovimiento.Margin = New System.Windows.Forms.Padding(4)
        Me.optMovimiento.Name = "optMovimiento"
        Me.optMovimiento.Size = New System.Drawing.Size(107, 21)
        Me.optMovimiento.TabIndex = 2
        Me.optMovimiento.TabStop = True
        Me.optMovimiento.Text = "Movimientos"
        Me.optMovimiento.UseVisualStyleBackColor = True
        '
        'optSaldos
        '
        Me.optSaldos.AutoSize = True
        Me.optSaldos.Checked = True
        Me.optSaldos.Location = New System.Drawing.Point(32, 31)
        Me.optSaldos.Margin = New System.Windows.Forms.Padding(4)
        Me.optSaldos.Name = "optSaldos"
        Me.optSaldos.Size = New System.Drawing.Size(72, 21)
        Me.optSaldos.TabIndex = 1
        Me.optSaldos.TabStop = True
        Me.optSaldos.Text = "Saldos"
        Me.optSaldos.UseVisualStyleBackColor = True
        '
        'lblFechaFin
        '
        Me.lblFechaFin.AutoSize = True
        Me.lblFechaFin.Location = New System.Drawing.Point(19, 71)
        Me.lblFechaFin.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFechaFin.Name = "lblFechaFin"
        Me.lblFechaFin.Size = New System.Drawing.Size(103, 17)
        Me.lblFechaFin.TabIndex = 4
        Me.lblFechaFin.Text = "Hasta la fecha:"
        '
        'lblFechaInicio
        '
        Me.lblFechaInicio.AutoSize = True
        Me.lblFechaInicio.Location = New System.Drawing.Point(16, 44)
        Me.lblFechaInicio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFechaInicio.Name = "lblFechaInicio"
        Me.lblFechaInicio.Size = New System.Drawing.Size(111, 17)
        Me.lblFechaInicio.TabIndex = 3
        Me.lblFechaInicio.Text = "Desde la fecha: "
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(238, 26)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Período para imprimir Balance"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Margin = New System.Windows.Forms.Padding(4)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(978, 562)
        Me.ReportViewer1.TabIndex = 1
        '
        'lblEstado
        '
        Me.lblEstado.BackColor = System.Drawing.Color.LightBlue
        Me.lblEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblEstado.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblEstado.Location = New System.Drawing.Point(0, 586)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Padding = New System.Windows.Forms.Padding(10, 5, 10, 5)
        Me.lblEstado.Size = New System.Drawing.Size(1221, 23)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblEstado.Visible = False
        '
        'btnOpciones
        '
        Me.btnOpciones.ForeColor = System.Drawing.Color.White
        Me.btnOpciones.Image = CType(resources.GetObject("btnOpciones.Image"), System.Drawing.Image)
        Me.btnOpciones.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOpciones.Name = "btnOpciones"
        Me.btnOpciones.Size = New System.Drawing.Size(75, 44)
        Me.btnOpciones.Text = "Opciones"
        Me.btnOpciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BalanceDeComprobaciónToolStripMenuItem
        '
        Me.BalanceDeComprobaciónToolStripMenuItem.CheckOnClick = True
        Me.BalanceDeComprobaciónToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.BalanceDeComprobaciónToolStripMenuItem.Image = CType(resources.GetObject("BalanceDeComprobaciónToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BalanceDeComprobaciónToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BalanceDeComprobaciónToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BalanceDeComprobaciónToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BalanceDeComprobaciónToolStripMenuItem.Name = "BalanceDeComprobaciónToolStripMenuItem"
        Me.BalanceDeComprobaciónToolStripMenuItem.Size = New System.Drawing.Size(155, 44)
        Me.BalanceDeComprobaciónToolStripMenuItem.Text = "DeComprobación"
        '
        'BalanceGeneralToolStripMenuItem
        '
        Me.BalanceGeneralToolStripMenuItem.CheckOnClick = True
        Me.BalanceGeneralToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.BalanceGeneralToolStripMenuItem.Image = CType(resources.GetObject("BalanceGeneralToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BalanceGeneralToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BalanceGeneralToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BalanceGeneralToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BalanceGeneralToolStripMenuItem.Name = "BalanceGeneralToolStripMenuItem"
        Me.BalanceGeneralToolStripMenuItem.Size = New System.Drawing.Size(88, 44)
        Me.BalanceGeneralToolStripMenuItem.Text = "General"
        '
        'BalanceResultadosToolStripMenuItem
        '
        Me.BalanceResultadosToolStripMenuItem.CheckOnClick = True
        Me.BalanceResultadosToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.BalanceResultadosToolStripMenuItem.Image = CType(resources.GetObject("BalanceResultadosToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BalanceResultadosToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BalanceResultadosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BalanceResultadosToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BalanceResultadosToolStripMenuItem.Name = "BalanceResultadosToolStripMenuItem"
        Me.BalanceResultadosToolStripMenuItem.Size = New System.Drawing.Size(128, 44)
        Me.BalanceResultadosToolStripMenuItem.Text = "DeResultados"
        '
        'BalancesAmpliadosToolStripMenuItem
        '
        Me.BalancesAmpliadosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ResultadosToolStripMenuItem})
        Me.BalancesAmpliadosToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.BalancesAmpliadosToolStripMenuItem.Image = CType(resources.GetObject("BalancesAmpliadosToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BalancesAmpliadosToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BalancesAmpliadosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BalancesAmpliadosToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BalancesAmpliadosToolStripMenuItem.Name = "BalancesAmpliadosToolStripMenuItem"
        Me.BalancesAmpliadosToolStripMenuItem.Size = New System.Drawing.Size(119, 44)
        Me.BalancesAmpliadosToolStripMenuItem.Text = "Ampliados"
        Me.BalancesAmpliadosToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(164, 26)
        Me.ToolStripMenuItem1.Text = "Patrimonio"
        '
        'ResultadosToolStripMenuItem
        '
        Me.ResultadosToolStripMenuItem.Name = "ResultadosToolStripMenuItem"
        Me.ResultadosToolStripMenuItem.Size = New System.Drawing.Size(164, 26)
        Me.ResultadosToolStripMenuItem.Text = "Resultados"
        '
        'btnSalir
        '
        Me.btnSalir.ForeColor = System.Drawing.Color.White
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(42, 44)
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Actualizar
        '
        Me.Actualizar.ForeColor = System.Drawing.Color.White
        Me.Actualizar.Image = CType(resources.GetObject("Actualizar.Image"), System.Drawing.Image)
        Me.Actualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Actualizar.Name = "Actualizar"
        Me.Actualizar.Size = New System.Drawing.Size(79, 44)
        Me.Actualizar.Text = "Actualizar"
        Me.Actualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'frmBalances
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1221, 609)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmBalances"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BALANCES"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnOpciones As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents optMovimiento As System.Windows.Forms.RadioButton
    Friend WithEvents optSaldos As System.Windows.Forms.RadioButton
    Friend WithEvents lblFechaFin As System.Windows.Forms.Label
    Friend WithEvents lblFechaInicio As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents BalancesAmpliadosToolStripMenuItem As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResultadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BalanceDeComprobaciónToolStripMenuItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BalanceGeneralToolStripMenuItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BalanceResultadosToolStripMenuItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents Actualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents CheckNiifs As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboNivel As System.Windows.Forms.ComboBox
    Friend WithEvents chkFirmas As System.Windows.Forms.CheckBox
    Friend WithEvents chkConSaldo0 As System.Windows.Forms.CheckBox
    Friend WithEvents chkCtasOrden As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtFechaFin As DateTimePicker
    Friend WithEvents txtFechaInicio As DateTimePicker
    Friend WithEvents lblEstado As Label
End Class
