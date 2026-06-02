<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IngresaServidor
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
        Me.TxtServidor = New System.Windows.Forms.TextBox()
        Me.TxtUsuario = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtPassword = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtPasswordc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtUrl = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Command2 = New System.Windows.Forms.Button()
        Me.Command3 = New System.Windows.Forms.Button()
        Me.Command1 = New System.Windows.Forms.Button()
        Me.Command4 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(23, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(260, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre del servidor de Base de Datos o dirección  IP"
        '
        'TxtServidor
        '
        Me.TxtServidor.Location = New System.Drawing.Point(289, 58)
        Me.TxtServidor.Name = "TxtServidor"
        Me.TxtServidor.Size = New System.Drawing.Size(138, 20)
        Me.TxtServidor.TabIndex = 1
        '
        'TxtUsuario
        '
        Me.TxtUsuario.Location = New System.Drawing.Point(289, 88)
        Me.TxtUsuario.Name = "TxtUsuario"
        Me.TxtUsuario.Size = New System.Drawing.Size(138, 20)
        Me.TxtUsuario.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(161, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Identificación de usuario"
        '
        'TxtPassword
        '
        Me.TxtPassword.Location = New System.Drawing.Point(289, 121)
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(35)
        Me.TxtPassword.Size = New System.Drawing.Size(138, 20)
        Me.TxtPassword.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(79, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(204, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Contraseña de acceso a la base de datos"
        '
        'TxtPasswordc
        '
        Me.TxtPasswordc.Location = New System.Drawing.Point(289, 139)
        Me.TxtPasswordc.Name = "TxtPasswordc"
        Me.TxtPasswordc.PasswordChar = Global.Microsoft.VisualBasic.ChrW(35)
        Me.TxtPasswordc.Size = New System.Drawing.Size(138, 20)
        Me.TxtPasswordc.TabIndex = 7
        Me.TxtPasswordc.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(133, 142)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(150, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Confirmación de la contraseña"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.Visible = False
        '
        'TxtUrl
        '
        Me.TxtUrl.Location = New System.Drawing.Point(20, 192)
        Me.TxtUrl.Name = "TxtUrl"
        Me.TxtUrl.Size = New System.Drawing.Size(511, 20)
        Me.TxtUrl.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(17, 176)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(272, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Dirección URL del directorio del AdcomDx en el servidor"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.Color.DimGray
        Me.Command2.FlatAppearance.BorderSize = 0
        Me.Command2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Command2.ForeColor = System.Drawing.Color.White
        Me.Command2.Location = New System.Drawing.Point(88, 230)
        Me.Command2.Name = "Command2"
        Me.Command2.Size = New System.Drawing.Size(109, 40)
        Me.Command2.TabIndex = 10
        Me.Command2.Text = "Continuar"
        Me.Command2.UseVisualStyleBackColor = False
        '
        'Command3
        '
        Me.Command3.BackColor = System.Drawing.Color.DimGray
        Me.Command3.FlatAppearance.BorderSize = 0
        Me.Command3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Command3.ForeColor = System.Drawing.Color.White
        Me.Command3.Location = New System.Drawing.Point(203, 230)
        Me.Command3.Name = "Command3"
        Me.Command3.Size = New System.Drawing.Size(109, 40)
        Me.Command3.TabIndex = 11
        Me.Command3.Text = "Cancelar"
        Me.Command3.UseVisualStyleBackColor = False
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.Color.DimGray
        Me.Command1.FlatAppearance.BorderSize = 0
        Me.Command1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Command1.ForeColor = System.Drawing.Color.White
        Me.Command1.Location = New System.Drawing.Point(318, 230)
        Me.Command1.Name = "Command1"
        Me.Command1.Size = New System.Drawing.Size(109, 40)
        Me.Command1.TabIndex = 12
        Me.Command1.Text = "Probar Conexión"
        Me.Command1.UseVisualStyleBackColor = False
        '
        'Command4
        '
        Me.Command4.BackColor = System.Drawing.Color.DimGray
        Me.Command4.FlatAppearance.BorderSize = 0
        Me.Command4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Command4.ForeColor = System.Drawing.Color.White
        Me.Command4.Location = New System.Drawing.Point(433, 230)
        Me.Command4.Name = "Command4"
        Me.Command4.Size = New System.Drawing.Size(109, 40)
        Me.Command4.TabIndex = 13
        Me.Command4.Text = "Recuperar última Conexión exitosa"
        Me.Command4.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(9, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(533, 27)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Directorio de arranque del sistema"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'IngresaServidor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.ClientSize = New System.Drawing.Size(551, 279)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Command4)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.Command3)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me.TxtUrl)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtPasswordc)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtPassword)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtUsuario)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtServidor)
        Me.Controls.Add(Me.Label1)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Name = "IngresaServidor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de datos de coneccion al servidor de base de datos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtServidor As System.Windows.Forms.TextBox
    Friend WithEvents TxtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtPasswordc As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtUrl As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Command2 As System.Windows.Forms.Button
    Friend WithEvents Command3 As System.Windows.Forms.Button
    Friend WithEvents Command1 As System.Windows.Forms.Button
    Friend WithEvents Command4 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
