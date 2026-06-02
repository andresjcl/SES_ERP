<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfiguracion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfiguracion))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextGenerados = New System.Windows.Forms.TextBox()
        Me.btnGenerados = New System.Windows.Forms.Button()
        Me.btnFirmados = New System.Windows.Forms.Button()
        Me.TextFirmados = New System.Windows.Forms.TextBox()
        Me.btnAutorizados = New System.Windows.Forms.Button()
        Me.TextAutorizados = New System.Windows.Forms.TextBox()
        Me.btnNAutorizados = New System.Windows.Forms.Button()
        Me.TextNoAutorizados = New System.Windows.Forms.TextBox()
        Me.btnPathFirmaElectronica = New System.Windows.Forms.Button()
        Me.TextPathFirmaElectronica = New System.Windows.Forms.TextBox()
        Me.chkProduccion = New System.Windows.Forms.RadioButton()
        Me.chkPruebas = New System.Windows.Forms.RadioButton()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TextClave = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtConsumidorFinal = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label1.Location = New System.Drawing.Point(37, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(171, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "COMPROBANTES GENERADOS:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label2.Location = New System.Drawing.Point(49, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(159, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "COMPROBANTES FIRMADOS:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label3.Location = New System.Drawing.Point(28, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(181, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "COMPROBANTES AUTORIZADOS:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label4.Location = New System.Drawing.Point(10, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(200, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "COMPROBANTES NO AUTORIZADOS:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label6.Location = New System.Drawing.Point(14, 223)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(221, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "CERTIFICADO CON FIRMA ELECTRÓNICA:"
        '
        'TextGenerados
        '
        Me.TextGenerados.Location = New System.Drawing.Point(218, 23)
        Me.TextGenerados.Name = "TextGenerados"
        Me.TextGenerados.Size = New System.Drawing.Size(637, 20)
        Me.TextGenerados.TabIndex = 1
        '
        'btnGenerados
        '
        Me.btnGenerados.Image = CType(resources.GetObject("btnGenerados.Image"), System.Drawing.Image)
        Me.btnGenerados.Location = New System.Drawing.Point(855, 22)
        Me.btnGenerados.Name = "btnGenerados"
        Me.btnGenerados.Size = New System.Drawing.Size(22, 22)
        Me.btnGenerados.TabIndex = 2
        Me.btnGenerados.UseVisualStyleBackColor = True
        '
        'btnFirmados
        '
        Me.btnFirmados.Image = CType(resources.GetObject("btnFirmados.Image"), System.Drawing.Image)
        Me.btnFirmados.Location = New System.Drawing.Point(855, 53)
        Me.btnFirmados.Name = "btnFirmados"
        Me.btnFirmados.Size = New System.Drawing.Size(22, 22)
        Me.btnFirmados.TabIndex = 9
        Me.btnFirmados.UseVisualStyleBackColor = True
        '
        'TextFirmados
        '
        Me.TextFirmados.Location = New System.Drawing.Point(218, 54)
        Me.TextFirmados.Name = "TextFirmados"
        Me.TextFirmados.Size = New System.Drawing.Size(637, 20)
        Me.TextFirmados.TabIndex = 4
        '
        'btnAutorizados
        '
        Me.btnAutorizados.Image = CType(resources.GetObject("btnAutorizados.Image"), System.Drawing.Image)
        Me.btnAutorizados.Location = New System.Drawing.Point(855, 85)
        Me.btnAutorizados.Name = "btnAutorizados"
        Me.btnAutorizados.Size = New System.Drawing.Size(22, 22)
        Me.btnAutorizados.TabIndex = 11
        Me.btnAutorizados.UseVisualStyleBackColor = True
        '
        'TextAutorizados
        '
        Me.TextAutorizados.Location = New System.Drawing.Point(218, 86)
        Me.TextAutorizados.Name = "TextAutorizados"
        Me.TextAutorizados.Size = New System.Drawing.Size(637, 20)
        Me.TextAutorizados.TabIndex = 6
        '
        'btnNAutorizados
        '
        Me.btnNAutorizados.Image = CType(resources.GetObject("btnNAutorizados.Image"), System.Drawing.Image)
        Me.btnNAutorizados.Location = New System.Drawing.Point(855, 115)
        Me.btnNAutorizados.Name = "btnNAutorizados"
        Me.btnNAutorizados.Size = New System.Drawing.Size(22, 22)
        Me.btnNAutorizados.TabIndex = 13
        Me.btnNAutorizados.UseVisualStyleBackColor = True
        '
        'TextNoAutorizados
        '
        Me.TextNoAutorizados.Location = New System.Drawing.Point(218, 116)
        Me.TextNoAutorizados.Name = "TextNoAutorizados"
        Me.TextNoAutorizados.Size = New System.Drawing.Size(637, 20)
        Me.TextNoAutorizados.TabIndex = 8
        '
        'btnPathFirmaElectronica
        '
        Me.btnPathFirmaElectronica.Image = CType(resources.GetObject("btnPathFirmaElectronica.Image"), System.Drawing.Image)
        Me.btnPathFirmaElectronica.Location = New System.Drawing.Point(774, 219)
        Me.btnPathFirmaElectronica.Name = "btnPathFirmaElectronica"
        Me.btnPathFirmaElectronica.Size = New System.Drawing.Size(22, 22)
        Me.btnPathFirmaElectronica.TabIndex = 13
        Me.btnPathFirmaElectronica.UseVisualStyleBackColor = True
        '
        'TextPathFirmaElectronica
        '
        Me.TextPathFirmaElectronica.Location = New System.Drawing.Point(241, 220)
        Me.TextPathFirmaElectronica.Name = "TextPathFirmaElectronica"
        Me.TextPathFirmaElectronica.Size = New System.Drawing.Size(533, 20)
        Me.TextPathFirmaElectronica.TabIndex = 12
        '
        'chkProduccion
        '
        Me.chkProduccion.AutoSize = True
        Me.chkProduccion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkProduccion.ForeColor = System.Drawing.Color.SteelBlue
        Me.chkProduccion.Location = New System.Drawing.Point(17, 190)
        Me.chkProduccion.Name = "chkProduccion"
        Me.chkProduccion.Size = New System.Drawing.Size(306, 17)
        Me.chkProduccion.TabIndex = 9
        Me.chkProduccion.TabStop = True
        Me.chkProduccion.Text = "TIPO DE AMBIENTE EN OPERACIÓN :      PRODUCCIÓN"
        Me.chkProduccion.UseVisualStyleBackColor = True
        '
        'chkPruebas
        '
        Me.chkPruebas.AutoSize = True
        Me.chkPruebas.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPruebas.ForeColor = System.Drawing.Color.SteelBlue
        Me.chkPruebas.Location = New System.Drawing.Point(340, 190)
        Me.chkPruebas.Name = "chkPruebas"
        Me.chkPruebas.Size = New System.Drawing.Size(76, 17)
        Me.chkPruebas.TabIndex = 10
        Me.chkPruebas.TabStop = True
        Me.chkPruebas.Text = "PRUEBAS"
        Me.chkPruebas.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnNAutorizados)
        Me.GroupBox1.Controls.Add(Me.TextNoAutorizados)
        Me.GroupBox1.Controls.Add(Me.btnAutorizados)
        Me.GroupBox1.Controls.Add(Me.TextAutorizados)
        Me.GroupBox1.Controls.Add(Me.btnFirmados)
        Me.GroupBox1.Controls.Add(Me.TextFirmados)
        Me.GroupBox1.Controls.Add(Me.btnGenerados)
        Me.GroupBox1.Controls.Add(Me.TextGenerados)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(891, 158)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "UBICACION DE COMPROBANTES"
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.Color.SteelBlue
        Me.btnAceptar.ForeColor = System.Drawing.Color.White
        Me.btnAceptar.Location = New System.Drawing.Point(614, 284)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(131, 32)
        Me.btnAceptar.TabIndex = 16
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.SteelBlue
        Me.btnSalir.ForeColor = System.Drawing.Color.White
        Me.btnSalir.Location = New System.Drawing.Point(761, 284)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(131, 32)
        Me.btnSalir.TabIndex = 17
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TextClave
        '
        Me.TextClave.Location = New System.Drawing.Point(218, 258)
        Me.TextClave.Name = "TextClave"
        Me.TextClave.Size = New System.Drawing.Size(231, 20)
        Me.TextClave.TabIndex = 15
        Me.TextClave.UseSystemPasswordChar = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label5.Location = New System.Drawing.Point(56, 261)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(158, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "CLAVE FIRMA ELECTRONICA:"
        '
        'txtConsumidorFinal
        '
        Me.txtConsumidorFinal.Location = New System.Drawing.Point(194, 286)
        Me.txtConsumidorFinal.Name = "txtConsumidorFinal"
        Me.txtConsumidorFinal.Size = New System.Drawing.Size(231, 20)
        Me.txtConsumidorFinal.TabIndex = 20
        Me.txtConsumidorFinal.UseSystemPasswordChar = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label7.Location = New System.Drawing.Point(12, 289)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(177, 13)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "CODIGO DE CONSUMIDOR FINAL"
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(154, 309)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(311, 30)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Si registra este codigo los documentos electrónicos se enviarán a autorizar pero " & _
    "no se enviarán al correo electrónico del cliente"
        '
        'frmConfiguracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(904, 340)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtConsumidorFinal)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextClave)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chkPruebas)
        Me.Controls.Add(Me.chkProduccion)
        Me.Controls.Add(Me.btnPathFirmaElectronica)
        Me.Controls.Add(Me.TextPathFirmaElectronica)
        Me.Controls.Add(Me.Label6)
        Me.Name = "frmConfiguracion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONFIGURACION FACTURACION ELECTRONICA"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextGenerados As System.Windows.Forms.TextBox
    Friend WithEvents btnGenerados As System.Windows.Forms.Button
    Friend WithEvents btnFirmados As System.Windows.Forms.Button
    Friend WithEvents TextFirmados As System.Windows.Forms.TextBox
    Friend WithEvents btnAutorizados As System.Windows.Forms.Button
    Friend WithEvents TextAutorizados As System.Windows.Forms.TextBox
    Friend WithEvents btnNAutorizados As System.Windows.Forms.Button
    Friend WithEvents TextNoAutorizados As System.Windows.Forms.TextBox
    Friend WithEvents btnPathFirmaElectronica As System.Windows.Forms.Button
    Friend WithEvents TextPathFirmaElectronica As System.Windows.Forms.TextBox
    Friend WithEvents chkProduccion As System.Windows.Forms.RadioButton
    Friend WithEvents chkPruebas As System.Windows.Forms.RadioButton
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TextClave As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtConsumidorFinal As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
