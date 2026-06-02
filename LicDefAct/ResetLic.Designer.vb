<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResetLic
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
        Me.OKButton = New System.Windows.Forms.Button()
        Me.CancelaButton = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'OKButton
        '
        Me.OKButton.BackColor = System.Drawing.Color.SteelBlue
        Me.OKButton.ForeColor = System.Drawing.Color.White
        Me.OKButton.Location = New System.Drawing.Point(33, 74)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(149, 30)
        Me.OKButton.TabIndex = 2
        Me.OKButton.Text = "Resetear Licencias"
        Me.OKButton.UseVisualStyleBackColor = False
        '
        'CancelaButton
        '
        Me.CancelaButton.BackColor = System.Drawing.Color.SteelBlue
        Me.CancelaButton.ForeColor = System.Drawing.Color.White
        Me.CancelaButton.Location = New System.Drawing.Point(229, 74)
        Me.CancelaButton.Name = "CancelaButton"
        Me.CancelaButton.Size = New System.Drawing.Size(137, 30)
        Me.CancelaButton.TabIndex = 3
        Me.CancelaButton.Text = "Salir"
        Me.CancelaButton.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(29, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(337, 62)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Label2"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ResetLic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(398, 116)
        Me.ControlBox = False
        Me.Controls.Add(Me.CancelaButton)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "ResetLic"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ADMINISTRACION DE LICENCIAS"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents CancelaButton As System.Windows.Forms.Button
    Friend WithEvents Label2 As Windows.Forms.Label
End Class
