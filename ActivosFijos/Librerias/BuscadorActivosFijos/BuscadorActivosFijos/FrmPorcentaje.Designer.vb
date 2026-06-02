<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPorcentaje
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
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.txtPorcTodos = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.optPorcentaje = New System.Windows.Forms.RadioButton()
        Me.optValor = New System.Windows.Forms.RadioButton()
        Me.txtValor = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(41, 77)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(71, 22)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(165, 77)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(71, 22)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'txtPorcTodos
        '
        Me.txtPorcTodos.Location = New System.Drawing.Point(60, 41)
        Me.txtPorcTodos.Name = "txtPorcTodos"
        Me.txtPorcTodos.Size = New System.Drawing.Size(43, 20)
        Me.txtPorcTodos.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(109, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "%"
        '
        'optPorcentaje
        '
        Me.optPorcentaje.AutoSize = True
        Me.optPorcentaje.Checked = True
        Me.optPorcentaje.Location = New System.Drawing.Point(36, 14)
        Me.optPorcentaje.Name = "optPorcentaje"
        Me.optPorcentaje.Size = New System.Drawing.Size(76, 17)
        Me.optPorcentaje.TabIndex = 6
        Me.optPorcentaje.TabStop = True
        Me.optPorcentaje.Text = "Porcentaje"
        Me.optPorcentaje.UseVisualStyleBackColor = True
        '
        'optValor
        '
        Me.optValor.AutoSize = True
        Me.optValor.Location = New System.Drawing.Point(165, 14)
        Me.optValor.Name = "optValor"
        Me.optValor.Size = New System.Drawing.Size(49, 17)
        Me.optValor.TabIndex = 7
        Me.optValor.Text = "Valor"
        Me.optValor.UseVisualStyleBackColor = True
        '
        'txtValor
        '
        Me.txtValor.Enabled = False
        Me.txtValor.Location = New System.Drawing.Point(174, 41)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Size = New System.Drawing.Size(77, 20)
        Me.txtValor.TabIndex = 8
        '
        'FrmPorcentaje
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(293, 121)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtValor)
        Me.Controls.Add(Me.optValor)
        Me.Controls.Add(Me.optPorcentaje)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPorcTodos)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Name = "FrmPorcentaje"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Porcentaje"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtPorcTodos As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents optPorcentaje As System.Windows.Forms.RadioButton
    Friend WithEvents optValor As System.Windows.Forms.RadioButton
    Friend WithEvents txtValor As System.Windows.Forms.TextBox
End Class
