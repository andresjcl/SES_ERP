<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContabilidad
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmContabilidad))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.bntCancelar = New System.Windows.Forms.ToolStripButton()
        Me.btnGrabar = New System.Windows.Forms.ToolStripButton()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.malla = New System.Windows.Forms.DataGridView()
        Me.chkValidos = New System.Windows.Forms.CheckBox()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.malla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(30, 30)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.bntCancelar, Me.btnGrabar, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(801, 37)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'bntCancelar
        '
        Me.bntCancelar.ForeColor = System.Drawing.Color.White
        Me.bntCancelar.Image = CType(resources.GetObject("bntCancelar.Image"), System.Drawing.Image)
        Me.bntCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.bntCancelar.Name = "bntCancelar"
        Me.bntCancelar.Size = New System.Drawing.Size(87, 34)
        Me.bntCancelar.Text = "Cancelar"
        '
        'btnGrabar
        '
        Me.btnGrabar.ForeColor = System.Drawing.Color.White
        Me.btnGrabar.Image = CType(resources.GetObject("btnGrabar.Image"), System.Drawing.Image)
        Me.btnGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(76, 34)
        Me.btnGrabar.Text = "Grabar"
        '
        'btnSalir
        '
        Me.btnSalir.ForeColor = System.Drawing.Color.White
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(63, 34)
        Me.btnSalir.Text = "Salir"
        '
        'malla
        '
        Me.malla.AllowUserToAddRows = False
        Me.malla.AllowUserToDeleteRows = False
        Me.malla.AllowUserToResizeRows = False
        Me.malla.BackgroundColor = System.Drawing.Color.White
        Me.malla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.malla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.malla.GridColor = System.Drawing.Color.Silver
        Me.malla.Location = New System.Drawing.Point(0, 37)
        Me.malla.Name = "malla"
        Me.malla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.malla.Size = New System.Drawing.Size(801, 326)
        Me.malla.TabIndex = 1
        '
        'chkValidos
        '
        Me.chkValidos.AutoSize = True
        Me.chkValidos.BackColor = System.Drawing.Color.SteelBlue
        Me.chkValidos.Checked = True
        Me.chkValidos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkValidos.ForeColor = System.Drawing.Color.White
        Me.chkValidos.Location = New System.Drawing.Point(533, 12)
        Me.chkValidos.Name = "chkValidos"
        Me.chkValidos.Size = New System.Drawing.Size(133, 17)
        Me.chkValidos.TabIndex = 2
        Me.chkValidos.Text = "Solo válidos a la fecha"
        Me.chkValidos.UseVisualStyleBackColor = False
        '
        'frmContabilidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(801, 363)
        Me.Controls.Add(Me.chkValidos)
        Me.Controls.Add(Me.malla)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frmContabilidad"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Registrar cuentas contables para el SRI"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.malla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents bntCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents malla As System.Windows.Forms.DataGridView
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents chkValidos As System.Windows.Forms.CheckBox
End Class
