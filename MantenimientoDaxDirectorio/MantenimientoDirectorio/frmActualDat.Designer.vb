<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmActualDat
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
        Me.Label75 = New System.Windows.Forms.Label()
        Me.OpE = New System.Windows.Forms.RadioButton()
        Me.TipoIdent = New System.Windows.Forms.ComboBox()
        Me.fTipo = New System.Windows.Forms.GroupBox()
        Me.OpP = New System.Windows.Forms.RadioButton()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.fprincipal1 = New System.Windows.Forms.GroupBox()
        Me.fprincipal = New System.Windows.Forms.Panel()
        Me.email = New System.Windows.Forms.TextBox()
        Me.telefono2 = New System.Windows.Forms.TextBox()
        Me.direccion = New System.Windows.Forms.TextBox()
        Me.apellidos = New System.Windows.Forms.TextBox()
        Me.nombres = New System.Windows.Forms.TextBox()
        Me.telefono1 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.rr = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ruc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btncontinuar = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.fTipo.SuspendLayout()
        Me.fprincipal1.SuspendLayout()
        Me.fprincipal.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label75
        '
        Me.Label75.BackColor = System.Drawing.Color.Transparent
        Me.Label75.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label75.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label75.ForeColor = System.Drawing.Color.White
        Me.Label75.Location = New System.Drawing.Point(214, 16)
        Me.Label75.Name = "Label75"
        Me.Label75.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label75.Size = New System.Drawing.Size(162, 18)
        Me.Label75.TabIndex = 2
        Me.Label75.Text = "Tipo Documento Identificación"
        Me.Label75.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'OpE
        '
        Me.OpE.BackColor = System.Drawing.Color.DimGray
        Me.OpE.Cursor = System.Windows.Forms.Cursors.Default
        Me.OpE.ForeColor = System.Drawing.Color.White
        Me.OpE.Location = New System.Drawing.Point(96, 16)
        Me.OpE.Name = "OpE"
        Me.OpE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OpE.Size = New System.Drawing.Size(81, 17)
        Me.OpE.TabIndex = 29
        Me.OpE.TabStop = True
        Me.OpE.Text = "Empresa"
        Me.OpE.UseVisualStyleBackColor = False
        '
        'TipoIdent
        '
        Me.TipoIdent.BackColor = System.Drawing.SystemColors.Window
        Me.TipoIdent.Cursor = System.Windows.Forms.Cursors.Default
        Me.TipoIdent.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TipoIdent.ForeColor = System.Drawing.Color.White
        Me.TipoIdent.Items.AddRange(New Object() {"No aplica", "Registro U Contribuyente", "Cédula Identidad", "Pasaporte", "Consumidor Final"})
        Me.TipoIdent.Location = New System.Drawing.Point(223, 35)
        Me.TipoIdent.Name = "TipoIdent"
        Me.TipoIdent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TipoIdent.Size = New System.Drawing.Size(145, 21)
        Me.TipoIdent.TabIndex = 3
        '
        'fTipo
        '
        Me.fTipo.BackColor = System.Drawing.Color.DimGray
        Me.fTipo.Controls.Add(Me.OpE)
        Me.fTipo.Controls.Add(Me.OpP)
        Me.fTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.fTipo.ForeColor = System.Drawing.Color.White
        Me.fTipo.Location = New System.Drawing.Point(16, 16)
        Me.fTipo.Name = "fTipo"
        Me.fTipo.Padding = New System.Windows.Forms.Padding(0)
        Me.fTipo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fTipo.Size = New System.Drawing.Size(185, 41)
        Me.fTipo.TabIndex = 1
        Me.fTipo.TabStop = False
        Me.fTipo.Text = "Tipo"
        '
        'OpP
        '
        Me.OpP.BackColor = System.Drawing.Color.DimGray
        Me.OpP.Checked = True
        Me.OpP.Cursor = System.Windows.Forms.Cursors.Default
        Me.OpP.ForeColor = System.Drawing.Color.White
        Me.OpP.Location = New System.Drawing.Point(8, 16)
        Me.OpP.Name = "OpP"
        Me.OpP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OpP.Size = New System.Drawing.Size(73, 17)
        Me.OpP.TabIndex = 28
        Me.OpP.TabStop = True
        Me.OpP.Text = "Persona"
        Me.OpP.UseVisualStyleBackColor = False
        '
        'btncancelar
        '
        Me.btncancelar.BackColor = System.Drawing.Color.DimGray
        Me.btncancelar.Cursor = System.Windows.Forms.Cursors.Default
        Me.btncancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btncancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncancelar.ForeColor = System.Drawing.Color.White
        Me.btncancelar.Location = New System.Drawing.Point(479, 253)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btncancelar.Size = New System.Drawing.Size(80, 43)
        Me.btncancelar.TabIndex = 36
        Me.btncancelar.Text = "Canc&elar"
        Me.btncancelar.UseVisualStyleBackColor = False
        '
        'fprincipal1
        '
        Me.fprincipal1.BackColor = System.Drawing.Color.DimGray
        Me.fprincipal1.Controls.Add(Me.TipoIdent)
        Me.fprincipal1.Controls.Add(Me.fTipo)
        Me.fprincipal1.Controls.Add(Me.fprincipal)
        Me.fprincipal1.Controls.Add(Me.Label75)
        Me.fprincipal1.Controls.Add(Me.ruc)
        Me.fprincipal1.Controls.Add(Me.Label1)
        Me.fprincipal1.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fprincipal1.ForeColor = System.Drawing.Color.White
        Me.fprincipal1.Location = New System.Drawing.Point(3, 22)
        Me.fprincipal1.Name = "fprincipal1"
        Me.fprincipal1.Padding = New System.Windows.Forms.Padding(0)
        Me.fprincipal1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fprincipal1.Size = New System.Drawing.Size(654, 223)
        Me.fprincipal1.TabIndex = 34
        Me.fprincipal1.TabStop = False
        '
        'fprincipal
        '
        Me.fprincipal.BackColor = System.Drawing.Color.DimGray
        Me.fprincipal.Controls.Add(Me.email)
        Me.fprincipal.Controls.Add(Me.telefono2)
        Me.fprincipal.Controls.Add(Me.direccion)
        Me.fprincipal.Controls.Add(Me.apellidos)
        Me.fprincipal.Controls.Add(Me.nombres)
        Me.fprincipal.Controls.Add(Me.telefono1)
        Me.fprincipal.Controls.Add(Me.Label9)
        Me.fprincipal.Controls.Add(Me.Label5)
        Me.fprincipal.Controls.Add(Me.Label2)
        Me.fprincipal.Controls.Add(Me.Label6)
        Me.fprincipal.Controls.Add(Me.rr)
        Me.fprincipal.Controls.Add(Me.Label4)
        Me.fprincipal.Cursor = System.Windows.Forms.Cursors.Default
        Me.fprincipal.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fprincipal.ForeColor = System.Drawing.Color.White
        Me.fprincipal.Location = New System.Drawing.Point(8, 64)
        Me.fprincipal.Name = "fprincipal"
        Me.fprincipal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fprincipal.Size = New System.Drawing.Size(632, 148)
        Me.fprincipal.TabIndex = 25
        '
        'email
        '
        Me.email.AcceptsReturn = True
        Me.email.BackColor = System.Drawing.SystemColors.Window
        Me.email.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.email.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.email.ForeColor = System.Drawing.Color.White
        Me.email.Location = New System.Drawing.Point(61, 117)
        Me.email.MaxLength = 120
        Me.email.Name = "email"
        Me.email.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.email.Size = New System.Drawing.Size(561, 20)
        Me.email.TabIndex = 24
        '
        'telefono2
        '
        Me.telefono2.AcceptsReturn = True
        Me.telefono2.BackColor = System.Drawing.SystemColors.Window
        Me.telefono2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.telefono2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.telefono2.ForeColor = System.Drawing.Color.White
        Me.telefono2.Location = New System.Drawing.Point(61, 73)
        Me.telefono2.MaxLength = 13
        Me.telefono2.Name = "telefono2"
        Me.telefono2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.telefono2.Size = New System.Drawing.Size(89, 20)
        Me.telefono2.TabIndex = 22
        '
        'direccion
        '
        Me.direccion.AcceptsReturn = True
        Me.direccion.BackColor = System.Drawing.SystemColors.Window
        Me.direccion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.direccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.direccion.ForeColor = System.Drawing.Color.White
        Me.direccion.Location = New System.Drawing.Point(62, 95)
        Me.direccion.MaxLength = 300
        Me.direccion.Name = "direccion"
        Me.direccion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.direccion.Size = New System.Drawing.Size(559, 20)
        Me.direccion.TabIndex = 18
        '
        'apellidos
        '
        Me.apellidos.AcceptsReturn = True
        Me.apellidos.BackColor = System.Drawing.SystemColors.Window
        Me.apellidos.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.apellidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.apellidos.ForeColor = System.Drawing.Color.White
        Me.apellidos.Location = New System.Drawing.Point(61, 30)
        Me.apellidos.MaxLength = 35
        Me.apellidos.Name = "apellidos"
        Me.apellidos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.apellidos.Size = New System.Drawing.Size(249, 20)
        Me.apellidos.TabIndex = 11
        '
        'nombres
        '
        Me.nombres.AcceptsReturn = True
        Me.nombres.BackColor = System.Drawing.SystemColors.Window
        Me.nombres.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.nombres.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.nombres.ForeColor = System.Drawing.Color.White
        Me.nombres.Location = New System.Drawing.Point(62, 8)
        Me.nombres.MaxLength = 80
        Me.nombres.Name = "nombres"
        Me.nombres.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.nombres.Size = New System.Drawing.Size(249, 20)
        Me.nombres.TabIndex = 9
        '
        'telefono1
        '
        Me.telefono1.AcceptsReturn = True
        Me.telefono1.BackColor = System.Drawing.SystemColors.Window
        Me.telefono1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.telefono1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.telefono1.ForeColor = System.Drawing.Color.White
        Me.telefono1.Location = New System.Drawing.Point(61, 52)
        Me.telefono1.MaxLength = 13
        Me.telefono1.Name = "telefono1"
        Me.telefono1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.telefono1.Size = New System.Drawing.Size(89, 20)
        Me.telefono1.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(24, 121)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(32, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "&Email"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(29, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Te&lf2"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(5, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "&Dirección"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(2, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "&Nombres :"
        '
        'rr
        '
        Me.rr.AutoSize = True
        Me.rr.BackColor = System.Drawing.Color.Transparent
        Me.rr.Cursor = System.Windows.Forms.Cursors.Default
        Me.rr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.rr.ForeColor = System.Drawing.Color.White
        Me.rr.Location = New System.Drawing.Point(34, 56)
        Me.rr.Name = "rr"
        Me.rr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rr.Size = New System.Drawing.Size(25, 13)
        Me.rr.TabIndex = 19
        Me.rr.Text = "&Telf"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(4, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "&Apellidos :"
        '
        'ruc
        '
        Me.ruc.AcceptsReturn = True
        Me.ruc.BackColor = System.Drawing.SystemColors.Window
        Me.ruc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ruc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ruc.ForeColor = System.Drawing.Color.White
        Me.ruc.Location = New System.Drawing.Point(380, 35)
        Me.ruc.MaxLength = 13
        Me.ruc.Name = "ruc"
        Me.ruc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ruc.Size = New System.Drawing.Size(140, 20)
        Me.ruc.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(403, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Nro.identificacion"
        '
        'btncontinuar
        '
        Me.btncontinuar.BackColor = System.Drawing.Color.DimGray
        Me.btncontinuar.Cursor = System.Windows.Forms.Cursors.Default
        Me.btncontinuar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncontinuar.ForeColor = System.Drawing.Color.White
        Me.btncontinuar.Location = New System.Drawing.Point(571, 252)
        Me.btncontinuar.Name = "btncontinuar"
        Me.btncontinuar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btncontinuar.Size = New System.Drawing.Size(80, 43)
        Me.btncontinuar.TabIndex = 35
        Me.btncontinuar.Text = "&Continuar"
        Me.btncontinuar.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(189, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(290, 13)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "ACTUALIZAR DATOS DE IDENTIFICACION DIRECTORIO"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmActualDat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.ClientSize = New System.Drawing.Size(657, 306)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btncancelar)
        Me.Controls.Add(Me.fprincipal1)
        Me.Controls.Add(Me.btncontinuar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmActualDat"
        Me.Text = "Actualizacion de datos del directorio"
        Me.fTipo.ResumeLayout(False)
        Me.fprincipal1.ResumeLayout(False)
        Me.fprincipal1.PerformLayout()
        Me.fprincipal.ResumeLayout(False)
        Me.fprincipal.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents Label75 As Windows.Forms.Label
    Public WithEvents OpE As Windows.Forms.RadioButton
    Public WithEvents TipoIdent As Windows.Forms.ComboBox
    Public WithEvents fTipo As Windows.Forms.GroupBox
    Public WithEvents OpP As Windows.Forms.RadioButton
    Public WithEvents btncancelar As Windows.Forms.Button
    Public WithEvents fprincipal1 As Windows.Forms.GroupBox
    Public WithEvents fprincipal As Windows.Forms.Panel
    Public WithEvents email As Windows.Forms.TextBox
    Public WithEvents telefono2 As Windows.Forms.TextBox
    Public WithEvents direccion As Windows.Forms.TextBox
    Public WithEvents ruc As Windows.Forms.TextBox
    Public WithEvents apellidos As Windows.Forms.TextBox
    Public WithEvents nombres As Windows.Forms.TextBox
    Public WithEvents telefono1 As Windows.Forms.TextBox
    Public WithEvents Label9 As Windows.Forms.Label
    Public WithEvents Label5 As Windows.Forms.Label
    Public WithEvents Label2 As Windows.Forms.Label
    Public WithEvents Label1 As Windows.Forms.Label
    Public WithEvents Label6 As Windows.Forms.Label
    Public WithEvents rr As Windows.Forms.Label
    Public WithEvents Label4 As Windows.Forms.Label
    Public WithEvents btncontinuar As Windows.Forms.Button
    Public WithEvents Label8 As Windows.Forms.Label
End Class
