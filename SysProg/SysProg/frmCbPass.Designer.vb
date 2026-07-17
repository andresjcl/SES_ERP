<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCbPass
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
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPassAnt = New System.Windows.Forms.TextBox()
        Me.txtNuePass = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtConfirma = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnAeptar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(25, 57)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Usuario:"
        '
        'lblUsuario
        '
        Me.lblUsuario.ForeColor = System.Drawing.Color.White
        Me.lblUsuario.Location = New System.Drawing.Point(25, 77)
        Me.lblUsuario.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(379, 16)
        Me.lblUsuario.TabIndex = 1
        Me.lblUsuario.Text = "Label2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(25, 100)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Contraseña Anterior:"
        '
        'txtPassAnt
        '
        Me.txtPassAnt.Location = New System.Drawing.Point(29, 120)
        Me.txtPassAnt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPassAnt.MaxLength = 15
        Me.txtPassAnt.Name = "txtPassAnt"
        Me.txtPassAnt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassAnt.Size = New System.Drawing.Size(303, 22)
        Me.txtPassAnt.TabIndex = 3
        '
        'txtNuePass
        '
        Me.txtNuePass.Location = New System.Drawing.Point(29, 169)
        Me.txtNuePass.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNuePass.MaxLength = 15
        Me.txtNuePass.Name = "txtNuePass"
        Me.txtNuePass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNuePass.Size = New System.Drawing.Size(303, 22)
        Me.txtNuePass.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(25, 150)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(130, 17)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Nueva Contraseña:"
        '
        'txtConfirma
        '
        Me.txtConfirma.Location = New System.Drawing.Point(28, 217)
        Me.txtConfirma.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtConfirma.MaxLength = 15
        Me.txtConfirma.Name = "txtConfirma"
        Me.txtConfirma.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirma.Size = New System.Drawing.Size(304, 22)
        Me.txtConfirma.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(24, 199)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(150, 17)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Confirmar Contraseña:"
        '
        'btnAeptar
        '
        Me.btnAeptar.BackColor = System.Drawing.Color.SteelBlue
        Me.btnAeptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAeptar.ForeColor = System.Drawing.Color.White
        Me.btnAeptar.Location = New System.Drawing.Point(135, 249)
        Me.btnAeptar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAeptar.Name = "btnAeptar"
        Me.btnAeptar.Size = New System.Drawing.Size(116, 28)
        Me.btnAeptar.TabIndex = 9
        Me.btnAeptar.Text = "Aceptar"
        Me.btnAeptar.UseVisualStyleBackColor = False
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.SteelBlue
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.ForeColor = System.Drawing.Color.White
        Me.btnSalir.Location = New System.Drawing.Point(288, 249)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(116, 28)
        Me.btnSalir.TabIndex = 10
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(561, 57)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Cambiar contraseña de usuario"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmCbPass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(561, 308)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnAeptar)
        Me.Controls.Add(Me.txtConfirma)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtNuePass)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtPassAnt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblUsuario)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.Name = "frmCbPass"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPassAnt As System.Windows.Forms.TextBox
    Friend WithEvents txtNuePass As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtConfirma As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnAeptar As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents Label2 As Label
End Class
