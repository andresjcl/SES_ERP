<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ActualizaDirectorio
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
        Me.chkEmpresa = New System.Windows.Forms.RadioButton()
        Me.TipoIdent = New System.Windows.Forms.ComboBox()
        Me.fTipo = New System.Windows.Forms.GroupBox()
        Me.chkPersona = New System.Windows.Forms.RadioButton()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.fprincipal1 = New System.Windows.Forms.GroupBox()
        Me.fprincipal = New System.Windows.Forms.Panel()
        Me.txtSector = New System.Windows.Forms.TextBox()
        Me.lbsector = New System.Windows.Forms.Label()
        Me.TxtEmail = New System.Windows.Forms.TextBox()
        Me.TxtTelefono2 = New System.Windows.Forms.TextBox()
        Me.TxtDireccion = New System.Windows.Forms.TextBox()
        Me.TxtApellidos = New System.Windows.Forms.TextBox()
        Me.TxtNombres = New System.Windows.Forms.TextBox()
        Me.TxtTelefono1 = New System.Windows.Forms.TextBox()
        Me.TxtNombreImpresion = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.rr = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtRucCi = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btncontinuar = New System.Windows.Forms.Button()
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
        Me.Label75.Location = New System.Drawing.Point(218, 16)
        Me.Label75.Name = "Label75"
        Me.Label75.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label75.Size = New System.Drawing.Size(107, 18)
        Me.Label75.TabIndex = 2
        Me.Label75.Text = "Tipo identificacion"
        Me.Label75.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkEmpresa
        '
        Me.chkEmpresa.BackColor = System.Drawing.Color.DarkGray
        Me.chkEmpresa.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkEmpresa.ForeColor = System.Drawing.Color.White
        Me.chkEmpresa.Location = New System.Drawing.Point(96, 16)
        Me.chkEmpresa.Name = "chkEmpresa"
        Me.chkEmpresa.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkEmpresa.Size = New System.Drawing.Size(81, 17)
        Me.chkEmpresa.TabIndex = 29
        Me.chkEmpresa.TabStop = True
        Me.chkEmpresa.Text = "Juridica"
        Me.chkEmpresa.UseVisualStyleBackColor = False
        '
        'TipoIdent
        '
        Me.TipoIdent.BackColor = System.Drawing.SystemColors.Window
        Me.TipoIdent.Cursor = System.Windows.Forms.Cursors.Default
        Me.TipoIdent.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TipoIdent.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TipoIdent.Items.AddRange(New Object() {"Registro U Contribuyente", "Cédula Identidad", "Pasaporte"})
        Me.TipoIdent.Location = New System.Drawing.Point(212, 34)
        Me.TipoIdent.Name = "TipoIdent"
        Me.TipoIdent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TipoIdent.Size = New System.Drawing.Size(117, 21)
        Me.TipoIdent.TabIndex = 3
        '
        'fTipo
        '
        Me.fTipo.BackColor = System.Drawing.Color.DarkGray
        Me.fTipo.Controls.Add(Me.chkEmpresa)
        Me.fTipo.Controls.Add(Me.chkPersona)
        Me.fTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.fTipo.ForeColor = System.Drawing.Color.White
        Me.fTipo.Location = New System.Drawing.Point(16, 16)
        Me.fTipo.Name = "fTipo"
        Me.fTipo.Padding = New System.Windows.Forms.Padding(0)
        Me.fTipo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fTipo.Size = New System.Drawing.Size(185, 41)
        Me.fTipo.TabIndex = 1
        Me.fTipo.TabStop = False
        Me.fTipo.Text = "Tipo de persona"
        '
        'chkPersona
        '
        Me.chkPersona.BackColor = System.Drawing.Color.DarkGray
        Me.chkPersona.Checked = True
        Me.chkPersona.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkPersona.ForeColor = System.Drawing.Color.White
        Me.chkPersona.Location = New System.Drawing.Point(8, 16)
        Me.chkPersona.Name = "chkPersona"
        Me.chkPersona.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkPersona.Size = New System.Drawing.Size(73, 17)
        Me.chkPersona.TabIndex = 28
        Me.chkPersona.TabStop = True
        Me.chkPersona.Text = "Natural"
        Me.chkPersona.UseVisualStyleBackColor = False
        '
        'btncancelar
        '
        Me.btncancelar.BackColor = System.Drawing.Color.Gray
        Me.btncancelar.Cursor = System.Windows.Forms.Cursors.Default
        Me.btncancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btncancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncancelar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncancelar.ForeColor = System.Drawing.Color.White
        Me.btncancelar.Location = New System.Drawing.Point(575, 208)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btncancelar.Size = New System.Drawing.Size(77, 51)
        Me.btncancelar.TabIndex = 36
        Me.btncancelar.Text = "Canc&elar"
        Me.btncancelar.UseVisualStyleBackColor = False
        '
        'fprincipal1
        '
        Me.fprincipal1.BackColor = System.Drawing.Color.DarkGray
        Me.fprincipal1.Controls.Add(Me.TipoIdent)
        Me.fprincipal1.Controls.Add(Me.fTipo)
        Me.fprincipal1.Controls.Add(Me.fprincipal)
        Me.fprincipal1.Controls.Add(Me.TxtRucCi)
        Me.fprincipal1.Controls.Add(Me.Label1)
        Me.fprincipal1.Controls.Add(Me.Label75)
        Me.fprincipal1.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fprincipal1.ForeColor = System.Drawing.Color.White
        Me.fprincipal1.Location = New System.Drawing.Point(2, 2)
        Me.fprincipal1.Name = "fprincipal1"
        Me.fprincipal1.Padding = New System.Windows.Forms.Padding(0)
        Me.fprincipal1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fprincipal1.Size = New System.Drawing.Size(654, 204)
        Me.fprincipal1.TabIndex = 34
        Me.fprincipal1.TabStop = False
        '
        'fprincipal
        '
        Me.fprincipal.BackColor = System.Drawing.Color.DarkGray
        Me.fprincipal.Controls.Add(Me.txtSector)
        Me.fprincipal.Controls.Add(Me.lbsector)
        Me.fprincipal.Controls.Add(Me.TxtEmail)
        Me.fprincipal.Controls.Add(Me.TxtTelefono2)
        Me.fprincipal.Controls.Add(Me.TxtDireccion)
        Me.fprincipal.Controls.Add(Me.TxtApellidos)
        Me.fprincipal.Controls.Add(Me.TxtNombres)
        Me.fprincipal.Controls.Add(Me.TxtTelefono1)
        Me.fprincipal.Controls.Add(Me.TxtNombreImpresion)
        Me.fprincipal.Controls.Add(Me.Label7)
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
        Me.fprincipal.Size = New System.Drawing.Size(632, 126)
        Me.fprincipal.TabIndex = 25
        '
        'txtSector
        '
        Me.txtSector.AcceptsReturn = True
        Me.txtSector.BackColor = System.Drawing.SystemColors.Window
        Me.txtSector.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSector.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtSector.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSector.Location = New System.Drawing.Point(99, 103)
        Me.txtSector.MaxLength = 180
        Me.txtSector.Name = "txtSector"
        Me.txtSector.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSector.Size = New System.Drawing.Size(524, 20)
        Me.txtSector.TabIndex = 26
        '
        'lbsector
        '
        Me.lbsector.AutoSize = True
        Me.lbsector.BackColor = System.Drawing.Color.Transparent
        Me.lbsector.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbsector.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lbsector.ForeColor = System.Drawing.Color.White
        Me.lbsector.Location = New System.Drawing.Point(5, 107)
        Me.lbsector.Name = "lbsector"
        Me.lbsector.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbsector.Size = New System.Drawing.Size(95, 13)
        Me.lbsector.TabIndex = 25
        Me.lbsector.Text = "&Sector/Referencia"
        '
        'TxtEmail
        '
        Me.TxtEmail.AcceptsReturn = True
        Me.TxtEmail.BackColor = System.Drawing.SystemColors.Window
        Me.TxtEmail.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtEmail.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtEmail.Location = New System.Drawing.Point(62, 78)
        Me.TxtEmail.MaxLength = 180
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtEmail.Size = New System.Drawing.Size(561, 20)
        Me.TxtEmail.TabIndex = 24
        '
        'TxtTelefono2
        '
        Me.TxtTelefono2.AcceptsReturn = True
        Me.TxtTelefono2.BackColor = System.Drawing.SystemColors.Window
        Me.TxtTelefono2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtTelefono2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtTelefono2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtTelefono2.Location = New System.Drawing.Point(530, 51)
        Me.TxtTelefono2.MaxLength = 13
        Me.TxtTelefono2.Name = "TxtTelefono2"
        Me.TxtTelefono2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtTelefono2.Size = New System.Drawing.Size(89, 20)
        Me.TxtTelefono2.TabIndex = 22
        '
        'TxtDireccion
        '
        Me.TxtDireccion.AcceptsReturn = True
        Me.TxtDireccion.BackColor = System.Drawing.SystemColors.Window
        Me.TxtDireccion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtDireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtDireccion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtDireccion.Location = New System.Drawing.Point(62, 54)
        Me.TxtDireccion.MaxLength = 150
        Me.TxtDireccion.Name = "TxtDireccion"
        Me.TxtDireccion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtDireccion.Size = New System.Drawing.Size(307, 20)
        Me.TxtDireccion.TabIndex = 18
        '
        'TxtApellidos
        '
        Me.TxtApellidos.AcceptsReturn = True
        Me.TxtApellidos.BackColor = System.Drawing.SystemColors.Window
        Me.TxtApellidos.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtApellidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtApellidos.ForeColor = System.Drawing.Color.Black
        Me.TxtApellidos.Location = New System.Drawing.Point(372, 6)
        Me.TxtApellidos.MaxLength = 50
        Me.TxtApellidos.Name = "TxtApellidos"
        Me.TxtApellidos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtApellidos.Size = New System.Drawing.Size(249, 20)
        Me.TxtApellidos.TabIndex = 11
        '
        'TxtNombres
        '
        Me.TxtNombres.AcceptsReturn = True
        Me.TxtNombres.BackColor = System.Drawing.SystemColors.Window
        Me.TxtNombres.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtNombres.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtNombres.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtNombres.Location = New System.Drawing.Point(62, 6)
        Me.TxtNombres.MaxLength = 80
        Me.TxtNombres.Name = "TxtNombres"
        Me.TxtNombres.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtNombres.Size = New System.Drawing.Size(249, 20)
        Me.TxtNombres.TabIndex = 9
        '
        'TxtTelefono1
        '
        Me.TxtTelefono1.AcceptsReturn = True
        Me.TxtTelefono1.BackColor = System.Drawing.SystemColors.Window
        Me.TxtTelefono1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtTelefono1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtTelefono1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtTelefono1.Location = New System.Drawing.Point(402, 51)
        Me.TxtTelefono1.MaxLength = 13
        Me.TxtTelefono1.Name = "TxtTelefono1"
        Me.TxtTelefono1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtTelefono1.Size = New System.Drawing.Size(89, 20)
        Me.TxtTelefono1.TabIndex = 20
        '
        'TxtNombreImpresion
        '
        Me.TxtNombreImpresion.BackColor = System.Drawing.SystemColors.Window
        Me.TxtNombreImpresion.Cursor = System.Windows.Forms.Cursors.Default
        Me.TxtNombreImpresion.Enabled = False
        Me.TxtNombreImpresion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtNombreImpresion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtNombreImpresion.Location = New System.Drawing.Point(62, 31)
        Me.TxtNombreImpresion.Name = "TxtNombreImpresion"
        Me.TxtNombreImpresion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtNombreImpresion.Size = New System.Drawing.Size(410, 17)
        Me.TxtNombreImpresion.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(2, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "&Impresión:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(5, 82)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(59, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "&Correo Elc."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(498, 55)
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
        Me.Label2.Location = New System.Drawing.Point(5, 58)
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
        Me.Label6.Location = New System.Drawing.Point(2, 10)
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
        Me.rr.Location = New System.Drawing.Point(375, 55)
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
        Me.Label4.Location = New System.Drawing.Point(315, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "&Apellidos :"
        '
        'TxtRucCi
        '
        Me.TxtRucCi.AcceptsReturn = True
        Me.TxtRucCi.BackColor = System.Drawing.SystemColors.Window
        Me.TxtRucCi.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtRucCi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtRucCi.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtRucCi.Location = New System.Drawing.Point(349, 34)
        Me.TxtRucCi.MaxLength = 13
        Me.TxtRucCi.Name = "TxtRucCi"
        Me.TxtRucCi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtRucCi.Size = New System.Drawing.Size(131, 20)
        Me.TxtRucCi.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(349, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(130, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Nro. Documento identifica" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btncontinuar
        '
        Me.btncontinuar.BackColor = System.Drawing.Color.Gray
        Me.btncontinuar.Cursor = System.Windows.Forms.Cursors.Default
        Me.btncontinuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncontinuar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncontinuar.ForeColor = System.Drawing.Color.White
        Me.btncontinuar.Location = New System.Drawing.Point(494, 208)
        Me.btncontinuar.Name = "btncontinuar"
        Me.btncontinuar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btncontinuar.Size = New System.Drawing.Size(77, 51)
        Me.btncontinuar.TabIndex = 35
        Me.btncontinuar.Text = "&Continuar"
        Me.btncontinuar.UseVisualStyleBackColor = False
        '
        'ActualizaDirectorio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.ClientSize = New System.Drawing.Size(657, 263)
        Me.Controls.Add(Me.btncancelar)
        Me.Controls.Add(Me.fprincipal1)
        Me.Controls.Add(Me.btncontinuar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ActualizaDirectorio"
        Me.Text = "ACTUALIZAR DATOS DE IDENTIFICACION "
        Me.fTipo.ResumeLayout(False)
        Me.fprincipal1.ResumeLayout(False)
        Me.fprincipal1.PerformLayout()
        Me.fprincipal.ResumeLayout(False)
        Me.fprincipal.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents Label75 As Windows.Forms.Label
    Public WithEvents chkEmpresa As Windows.Forms.RadioButton
    Public WithEvents TipoIdent As Windows.Forms.ComboBox
    Public WithEvents fTipo As Windows.Forms.GroupBox
    Public WithEvents chkPersona As Windows.Forms.RadioButton
    Public WithEvents btncancelar As Windows.Forms.Button
    Public WithEvents fprincipal1 As Windows.Forms.GroupBox
    Public WithEvents fprincipal As Windows.Forms.Panel
    Public WithEvents TxtEmail As Windows.Forms.TextBox
    Public WithEvents TxtTelefono2 As Windows.Forms.TextBox
    Public WithEvents TxtDireccion As Windows.Forms.TextBox
    Public WithEvents TxtRucCi As Windows.Forms.TextBox
    Public WithEvents TxtApellidos As Windows.Forms.TextBox
    Public WithEvents TxtNombres As Windows.Forms.TextBox
    Public WithEvents TxtTelefono1 As Windows.Forms.TextBox
    Public WithEvents TxtNombreImpresion As Windows.Forms.Label
    Public WithEvents Label7 As Windows.Forms.Label
    Public WithEvents Label9 As Windows.Forms.Label
    Public WithEvents Label5 As Windows.Forms.Label
    Public WithEvents Label2 As Windows.Forms.Label
    Public WithEvents Label6 As Windows.Forms.Label
    Public WithEvents rr As Windows.Forms.Label
    Public WithEvents Label4 As Windows.Forms.Label
    Public WithEvents btncontinuar As Windows.Forms.Button
    Public WithEvents Label1 As Windows.Forms.Label
    Public WithEvents txtSector As Windows.Forms.TextBox
    Public WithEvents lbsector As Windows.Forms.Label
End Class
