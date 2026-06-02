<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNotas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNotas))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btnEliminar = New System.Windows.Forms.ToolStripButton()
        Me.btnImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnIzq = New System.Windows.Forms.ToolStripButton()
        Me.btnCentrar = New System.Windows.Forms.ToolStripButton()
        Me.btnDerecha = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.txtDelMes = New System.Windows.Forms.ToolStripTextBox()
        Me.lblA = New System.Windows.Forms.ToolStripLabel()
        Me.txtAlMes = New System.Windows.Forms.ToolStripTextBox()
        Me.txtAño = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.txtNumNota = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.bntSalir = New System.Windows.Forms.ToolStripButton()
        Me.txtNota = New RichTextBoxPrintCtrl.RichTextBoxPrintCtrl.RichTextBoxPrintCtrl()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.btnEliminar, Me.btnImprimir, Me.ToolStripSeparator1, Me.btnIzq, Me.btnCentrar, Me.btnDerecha, Me.ToolStripSeparator2, Me.ToolStripLabel3, Me.txtDelMes, Me.lblA, Me.txtAlMes, Me.txtAño, Me.ToolStripLabel1, Me.txtNumNota, Me.ToolStripLabel2, Me.bntSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(889, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnGuardar
        '
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(69, 22)
        Me.btnGuardar.Text = "&Guardar"
        '
        'btnEliminar
        '
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.ForeColor = System.Drawing.Color.White
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(70, 22)
        Me.btnEliminar.Text = "&Eliminar"
        '
        'btnImprimir
        '
        Me.btnImprimir.ForeColor = System.Drawing.Color.White
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(73, 22)
        Me.btnImprimir.Text = "&Imprimir"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.ForeColor = System.Drawing.Color.White
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnIzq
        '
        Me.btnIzq.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnIzq.ForeColor = System.Drawing.Color.White
        Me.btnIzq.Image = CType(resources.GetObject("btnIzq.Image"), System.Drawing.Image)
        Me.btnIzq.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnIzq.Name = "btnIzq"
        Me.btnIzq.Size = New System.Drawing.Size(23, 22)
        Me.btnIzq.Text = "Alinear a la Izquierda"
        '
        'btnCentrar
        '
        Me.btnCentrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCentrar.ForeColor = System.Drawing.Color.White
        Me.btnCentrar.Image = CType(resources.GetObject("btnCentrar.Image"), System.Drawing.Image)
        Me.btnCentrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCentrar.Name = "btnCentrar"
        Me.btnCentrar.Size = New System.Drawing.Size(23, 22)
        Me.btnCentrar.Text = "Centrar"
        '
        'btnDerecha
        '
        Me.btnDerecha.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDerecha.ForeColor = System.Drawing.Color.White
        Me.btnDerecha.Image = CType(resources.GetObject("btnDerecha.Image"), System.Drawing.Image)
        Me.btnDerecha.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDerecha.Name = "btnDerecha"
        Me.btnDerecha.Size = New System.Drawing.Size(23, 22)
        Me.btnDerecha.Text = "Derecha"
        Me.btnDerecha.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnDerecha.ToolTipText = "Alinear a la Derecha"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.ForeColor = System.Drawing.Color.White
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.ForeColor = System.Drawing.Color.White
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(132, 22)
        Me.ToolStripLabel3.Text = "   Periodo de Validez de:"
        '
        'txtDelMes
        '
        Me.txtDelMes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDelMes.ForeColor = System.Drawing.Color.White
        Me.txtDelMes.Name = "txtDelMes"
        Me.txtDelMes.Size = New System.Drawing.Size(60, 25)
        Me.txtDelMes.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblA
        '
        Me.lblA.ForeColor = System.Drawing.Color.White
        Me.lblA.Name = "lblA"
        Me.lblA.Size = New System.Drawing.Size(16, 22)
        Me.lblA.Text = "a:"
        '
        'txtAlMes
        '
        Me.txtAlMes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAlMes.ForeColor = System.Drawing.Color.White
        Me.txtAlMes.Name = "txtAlMes"
        Me.txtAlMes.Size = New System.Drawing.Size(60, 25)
        Me.txtAlMes.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtAño
        '
        Me.txtAño.ForeColor = System.Drawing.Color.White
        Me.txtAño.Name = "txtAño"
        Me.txtAño.Size = New System.Drawing.Size(23, 22)
        Me.txtAño.Text = "del"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.White
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(38, 22)
        Me.ToolStripLabel1.Text = "    No."
        Me.ToolStripLabel1.Visible = False
        '
        'txtNumNota
        '
        Me.txtNumNota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumNota.ForeColor = System.Drawing.Color.White
        Me.txtNumNota.Name = "txtNumNota"
        Me.txtNumNota.Size = New System.Drawing.Size(50, 25)
        Me.txtNumNota.Visible = False
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.ForeColor = System.Drawing.Color.White
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(37, 22)
        Me.ToolStripLabel2.Text = "          "
        '
        'bntSalir
        '
        Me.bntSalir.ForeColor = System.Drawing.Color.White
        Me.bntSalir.Image = CType(resources.GetObject("bntSalir.Image"), System.Drawing.Image)
        Me.bntSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.bntSalir.Name = "bntSalir"
        Me.bntSalir.Size = New System.Drawing.Size(49, 22)
        Me.bntSalir.Text = "&Salir"
        '
        'txtNota
        '
        Me.txtNota.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNota.Location = New System.Drawing.Point(0, 25)
        Me.txtNota.Name = "txtNota"
        Me.txtNota.Size = New System.Drawing.Size(889, 424)
        Me.txtNota.TabIndex = 1
        Me.txtNota.Text = ""
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
        'PrintDocument1
        '
        '
        'frmNotas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(889, 449)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtNota)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmNotas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar Nota"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents bntSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtNumNota As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnIzq As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCentrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDerecha As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtNota As RichTextBoxPrintCtrl.RichTextBoxPrintCtrl.RichTextBoxPrintCtrl
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtDelMes As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents lblA As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtAlMes As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents txtAño As System.Windows.Forms.ToolStripLabel
End Class
