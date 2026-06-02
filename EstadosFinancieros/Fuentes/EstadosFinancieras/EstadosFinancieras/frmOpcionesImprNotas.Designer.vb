<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOpcionesImprNotas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOpcionesImprNotas))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnImprimir = New System.Windows.Forms.ToolStripButton()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtFecH = New System.Windows.Forms.MaskedTextBox()
        Me.txtFecD = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNumH = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNumD = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optFlujoE = New System.Windows.Forms.RadioButton()
        Me.optPatrimonial = New System.Windows.Forms.RadioButton()
        Me.optResultados = New System.Windows.Forms.RadioButton()
        Me.optSituacion = New System.Windows.Forms.RadioButton()
        Me.optTodos = New System.Windows.Forms.RadioButton()
        Me.RichTextBoxPrintCtrl1 = New RichTextBoxPrintCtrl.RichTextBoxPrintCtrl.RichTextBoxPrintCtrl()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnImprimir, Me.btnCancelar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(458, 38)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnImprimir
        '
        Me.btnImprimir.ForeColor = System.Drawing.Color.White
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(57, 35)
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.White
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(57, 35)
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtFecH)
        Me.GroupBox2.Controls.Add(Me.txtFecD)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtNumH)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtNumD)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 92)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(443, 77)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "OPCIONES"
        '
        'txtFecH
        '
        Me.txtFecH.Location = New System.Drawing.Point(224, 45)
        Me.txtFecH.Mask = "00/00/0000"
        Me.txtFecH.Name = "txtFecH"
        Me.txtFecH.Size = New System.Drawing.Size(61, 20)
        Me.txtFecH.TabIndex = 11
        Me.txtFecH.ValidatingType = GetType(Date)
        '
        'txtFecD
        '
        Me.txtFecD.Location = New System.Drawing.Point(115, 45)
        Me.txtFecD.Mask = "00/00/0000"
        Me.txtFecD.Name = "txtFecD"
        Me.txtFecD.Size = New System.Drawing.Size(61, 20)
        Me.txtFecD.TabIndex = 10
        Me.txtFecD.ValidatingType = GetType(Date)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(182, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Hasta"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Desde la fecha:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(182, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Hasta"
        '
        'txtNumH
        '
        Me.txtNumH.Location = New System.Drawing.Point(224, 19)
        Me.txtNumH.Name = "txtNumH"
        Me.txtNumH.Size = New System.Drawing.Size(61, 20)
        Me.txtNumH.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Desde la Nota No."
        '
        'txtNumD
        '
        Me.txtNumD.Location = New System.Drawing.Point(115, 19)
        Me.txtNumD.Name = "txtNumD"
        Me.txtNumD.Size = New System.Drawing.Size(61, 20)
        Me.txtNumD.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optFlujoE)
        Me.GroupBox1.Controls.Add(Me.optPatrimonial)
        Me.GroupBox1.Controls.Add(Me.optResultados)
        Me.GroupBox1.Controls.Add(Me.optSituacion)
        Me.GroupBox1.Controls.Add(Me.optTodos)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 44)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(443, 42)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "IMPRIMIR NOTAS DE BALANCES"
        '
        'optFlujoE
        '
        Me.optFlujoE.AutoSize = True
        Me.optFlujoE.Location = New System.Drawing.Point(308, 15)
        Me.optFlujoE.Name = "optFlujoE"
        Me.optFlujoE.Size = New System.Drawing.Size(104, 17)
        Me.optFlujoE.TabIndex = 4
        Me.optFlujoE.Text = "Flujo de Efectivo"
        Me.optFlujoE.UseVisualStyleBackColor = True
        '
        'optPatrimonial
        '
        Me.optPatrimonial.AutoSize = True
        Me.optPatrimonial.Location = New System.Drawing.Point(226, 15)
        Me.optPatrimonial.Name = "optPatrimonial"
        Me.optPatrimonial.Size = New System.Drawing.Size(76, 17)
        Me.optPatrimonial.TabIndex = 3
        Me.optPatrimonial.Text = "Patrimonial"
        Me.optPatrimonial.UseVisualStyleBackColor = True
        '
        'optResultados
        '
        Me.optResultados.AutoSize = True
        Me.optResultados.Location = New System.Drawing.Point(142, 15)
        Me.optResultados.Name = "optResultados"
        Me.optResultados.Size = New System.Drawing.Size(78, 17)
        Me.optResultados.TabIndex = 2
        Me.optResultados.Text = "Resultados"
        Me.optResultados.UseVisualStyleBackColor = True
        '
        'optSituacion
        '
        Me.optSituacion.AutoSize = True
        Me.optSituacion.Location = New System.Drawing.Point(67, 15)
        Me.optSituacion.Name = "optSituacion"
        Me.optSituacion.Size = New System.Drawing.Size(69, 17)
        Me.optSituacion.TabIndex = 1
        Me.optSituacion.Text = "Situación"
        Me.optSituacion.UseVisualStyleBackColor = True
        '
        'optTodos
        '
        Me.optTodos.AutoSize = True
        Me.optTodos.Checked = True
        Me.optTodos.Location = New System.Drawing.Point(6, 15)
        Me.optTodos.Name = "optTodos"
        Me.optTodos.Size = New System.Drawing.Size(55, 17)
        Me.optTodos.TabIndex = 0
        Me.optTodos.TabStop = True
        Me.optTodos.Text = "Todos"
        Me.optTodos.UseVisualStyleBackColor = True
        '
        'RichTextBoxPrintCtrl1
        '
        Me.RichTextBoxPrintCtrl1.Location = New System.Drawing.Point(361, 6)
        Me.RichTextBoxPrintCtrl1.Name = "RichTextBoxPrintCtrl1"
        Me.RichTextBoxPrintCtrl1.Size = New System.Drawing.Size(17, 31)
        Me.RichTextBoxPrintCtrl1.TabIndex = 5
        Me.RichTextBoxPrintCtrl1.Text = ""
        Me.RichTextBoxPrintCtrl1.Visible = False
        '
        'PrintDocument1
        '
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Document = Me.PrintDocument1
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'frmOpcionesImprNotas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(458, 183)
        Me.Controls.Add(Me.RichTextBoxPrintCtrl1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmOpcionesImprNotas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Opciones de Impresión de Notas"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFecH As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtFecD As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNumH As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNumD As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optFlujoE As System.Windows.Forms.RadioButton
    Friend WithEvents optPatrimonial As System.Windows.Forms.RadioButton
    Friend WithEvents optResultados As System.Windows.Forms.RadioButton
    Friend WithEvents optSituacion As System.Windows.Forms.RadioButton
    Friend WithEvents optTodos As System.Windows.Forms.RadioButton
    Friend WithEvents RichTextBoxPrintCtrl1 As RichTextBoxPrintCtrl.RichTextBoxPrintCtrl.RichTextBoxPrintCtrl
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
End Class
