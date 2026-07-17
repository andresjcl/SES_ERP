<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSuc
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lst = New System.Windows.Forms.ListBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnConectar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(21, 21)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(305, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "CAMBIAR SUCURSAL ACTIVA EN EL SISTEMA"
        '
        'lst
        '
        Me.lst.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lst.FormattingEnabled = True
        Me.lst.ItemHeight = 18
        Me.lst.Location = New System.Drawing.Point(16, 40)
        Me.lst.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lst.Name = "lst"
        Me.lst.Size = New System.Drawing.Size(352, 184)
        Me.lst.TabIndex = 2
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.SteelBlue
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.ForeColor = System.Drawing.Color.White
        Me.btnSalir.Location = New System.Drawing.Point(180, 230)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(147, 31)
        Me.btnSalir.TabIndex = 12
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnConectar
        '
        Me.btnConectar.BackColor = System.Drawing.Color.SteelBlue
        Me.btnConectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConectar.ForeColor = System.Drawing.Color.White
        Me.btnConectar.Location = New System.Drawing.Point(25, 230)
        Me.btnConectar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnConectar.Name = "btnConectar"
        Me.btnConectar.Size = New System.Drawing.Size(147, 31)
        Me.btnConectar.TabIndex = 11
        Me.btnConectar.Text = "Conectar Sucursal"
        Me.btnConectar.UseVisualStyleBackColor = False
        '
        'frmSuc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(385, 266)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnConectar)
        Me.Controls.Add(Me.lst)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.Name = "frmSuc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lst As System.Windows.Forms.ListBox
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnConectar As Button
End Class
