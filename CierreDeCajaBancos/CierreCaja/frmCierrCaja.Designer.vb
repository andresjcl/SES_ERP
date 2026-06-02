<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCierrCaja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCierrCaja))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ResumenVertical = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtHorafin = New System.Windows.Forms.MaskedTextBox()
        Me.txtHoraini = New System.Windows.Forms.MaskedTextBox()
        Me.txtFechaAl = New System.Windows.Forms.MaskedTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFechaDel = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboVendedor = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboPtoVta = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboSucursal = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkretencion = New System.Windows.Forms.CheckBox()
        Me.chkdevolucion = New System.Windows.Forms.CheckBox()
        Me.chkfacturas = New System.Windows.Forms.CheckBox()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.btnOpciones = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.pagosAbiertos = New System.Windows.Forms.CheckBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.pagosAbiertos)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ResumenVertical)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboVendedor)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboPtoVta)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboSucursal)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ReportViewer1)
        Me.SplitContainer1.Size = New System.Drawing.Size(917, 506)
        Me.SplitContainer1.SplitterDistance = 250
        Me.SplitContainer1.TabIndex = 1
        '
        'ResumenVertical
        '
        Me.ResumenVertical.AutoSize = True
        Me.ResumenVertical.Location = New System.Drawing.Point(9, 102)
        Me.ResumenVertical.Name = "ResumenVertical"
        Me.ResumenVertical.Size = New System.Drawing.Size(155, 17)
        Me.ResumenVertical.TabIndex = 10
        Me.ResumenVertical.Text = "Resumen de pagos vertical"
        Me.ResumenVertical.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtHorafin)
        Me.GroupBox1.Controls.Add(Me.txtHoraini)
        Me.GroupBox1.Controls.Add(Me.txtFechaAl)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtFechaDel)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(1, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(247, 79)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Rango de Fechas:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(115, 54)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "hasta"
        Me.Label10.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(2, 54)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Hora desde:"
        Me.Label9.Visible = False
        '
        'txtHorafin
        '
        Me.txtHorafin.Location = New System.Drawing.Point(152, 51)
        Me.txtHorafin.Mask = "00:00"
        Me.txtHorafin.Name = "txtHorafin"
        Me.txtHorafin.Size = New System.Drawing.Size(40, 20)
        Me.txtHorafin.TabIndex = 13
        Me.txtHorafin.ValidatingType = GetType(Date)
        Me.txtHorafin.Visible = False
        '
        'txtHoraini
        '
        Me.txtHoraini.Location = New System.Drawing.Point(69, 51)
        Me.txtHoraini.Mask = "00:00"
        Me.txtHoraini.Name = "txtHoraini"
        Me.txtHoraini.Size = New System.Drawing.Size(38, 20)
        Me.txtHoraini.TabIndex = 12
        Me.txtHoraini.ValidatingType = GetType(Date)
        Me.txtHoraini.Visible = False
        '
        'txtFechaAl
        '
        Me.txtFechaAl.Location = New System.Drawing.Point(152, 23)
        Me.txtFechaAl.Mask = "00/00/0000"
        Me.txtFechaAl.Name = "txtFechaAl"
        Me.txtFechaAl.Size = New System.Drawing.Size(69, 20)
        Me.txtFechaAl.TabIndex = 11
        Me.txtFechaAl.ValidatingType = GetType(Date)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(124, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(19, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Al:"
        '
        'txtFechaDel
        '
        Me.txtFechaDel.Location = New System.Drawing.Point(41, 23)
        Me.txtFechaDel.Mask = "00/00/0000"
        Me.txtFechaDel.Name = "txtFechaDel"
        Me.txtFechaDel.Size = New System.Drawing.Size(66, 20)
        Me.txtFechaDel.TabIndex = 9
        Me.txtFechaDel.ValidatingType = GetType(Date)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Del:"
        '
        'cboVendedor
        '
        Me.cboVendedor.FormattingEnabled = True
        Me.cboVendedor.Location = New System.Drawing.Point(9, 200)
        Me.cboVendedor.Name = "cboVendedor"
        Me.cboVendedor.Size = New System.Drawing.Size(228, 21)
        Me.cboVendedor.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 189)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Vendedor:"
        '
        'cboPtoVta
        '
        Me.cboPtoVta.FormattingEnabled = True
        Me.cboPtoVta.Location = New System.Drawing.Point(6, 237)
        Me.cboPtoVta.Name = "cboPtoVta"
        Me.cboPtoVta.Size = New System.Drawing.Size(231, 21)
        Me.cboPtoVta.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 225)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "PuntoVenta:"
        '
        'cboSucursal
        '
        Me.cboSucursal.FormattingEnabled = True
        Me.cboSucursal.Location = New System.Drawing.Point(9, 165)
        Me.cboSucursal.Name = "cboSucursal"
        Me.cboSucursal.Size = New System.Drawing.Size(228, 21)
        Me.cboSucursal.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 153)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sucursal:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkretencion)
        Me.GroupBox2.Controls.Add(Me.chkdevolucion)
        Me.GroupBox2.Controls.Add(Me.chkfacturas)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 269)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(228, 167)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Documentos a imprimir"
        '
        'chkretencion
        '
        Me.chkretencion.AutoSize = True
        Me.chkretencion.Checked = True
        Me.chkretencion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkretencion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkretencion.ForeColor = System.Drawing.Color.White
        Me.chkretencion.Location = New System.Drawing.Point(9, 99)
        Me.chkretencion.Name = "chkretencion"
        Me.chkretencion.Size = New System.Drawing.Size(157, 17)
        Me.chkretencion.TabIndex = 11
        Me.chkretencion.Text = "Retenciones de cliente"
        Me.chkretencion.UseVisualStyleBackColor = True
        '
        'chkdevolucion
        '
        Me.chkdevolucion.AutoSize = True
        Me.chkdevolucion.Checked = True
        Me.chkdevolucion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkdevolucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdevolucion.ForeColor = System.Drawing.Color.White
        Me.chkdevolucion.Location = New System.Drawing.Point(9, 64)
        Me.chkdevolucion.Name = "chkdevolucion"
        Me.chkdevolucion.Size = New System.Drawing.Size(204, 17)
        Me.chkdevolucion.TabIndex = 10
        Me.chkdevolucion.Text = "Devoluciones/Notas de Crédito"
        Me.chkdevolucion.UseVisualStyleBackColor = True
        '
        'chkfacturas
        '
        Me.chkfacturas.AutoSize = True
        Me.chkfacturas.Checked = True
        Me.chkfacturas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkfacturas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkfacturas.ForeColor = System.Drawing.Color.White
        Me.chkfacturas.Location = New System.Drawing.Point(11, 32)
        Me.chkfacturas.Name = "chkfacturas"
        Me.chkfacturas.Size = New System.Drawing.Size(129, 17)
        Me.chkfacturas.TabIndex = 9
        Me.chkfacturas.Text = "Facturas de venta"
        Me.chkfacturas.UseVisualStyleBackColor = True
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(663, 506)
        Me.ReportViewer1.TabIndex = 0
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
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOpciones, Me.ToolStripSeparator2, Me.btnActualizar, Me.ToolStripSeparator1, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(917, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'pagosAbiertos
        '
        Me.pagosAbiertos.AutoSize = True
        Me.pagosAbiertos.Location = New System.Drawing.Point(11, 127)
        Me.pagosAbiertos.Name = "pagosAbiertos"
        Me.pagosAbiertos.Size = New System.Drawing.Size(153, 17)
        Me.pagosAbiertos.TabIndex = 11
        Me.pagosAbiertos.Text = "Formas de pago detallados"
        Me.pagosAbiertos.UseVisualStyleBackColor = True
        '
        'frmCierrCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(917, 531)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCierrCaja"
        Me.Text = "REPORTE DE CIERRE DE CAJA"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFechaAl As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFechaDel As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboVendedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboPtoVta As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtHorafin As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtHoraini As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btnOpciones As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkretencion As System.Windows.Forms.CheckBox
    Friend WithEvents chkdevolucion As System.Windows.Forms.CheckBox
    Friend WithEvents chkfacturas As System.Windows.Forms.CheckBox
    Friend WithEvents ResumenVertical As System.Windows.Forms.CheckBox
    Friend WithEvents pagosAbiertos As System.Windows.Forms.CheckBox

End Class
