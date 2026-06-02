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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnNAutorizados = New System.Windows.Forms.Button()
        Me.TextNoAutorizados = New System.Windows.Forms.TextBox()
        Me.btnAutorizados = New System.Windows.Forms.Button()
        Me.TextAutorizados = New System.Windows.Forms.TextBox()
        Me.btnFirmados = New System.Windows.Forms.Button()
        Me.TextFirmados = New System.Windows.Forms.TextBox()
        Me.btnGenerados = New System.Windows.Forms.Button()
        Me.TextGenerados = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.TextClave = New System.Windows.Forms.TextBox()
        Me.chkPruebas = New System.Windows.Forms.RadioButton()
        Me.chkProduccion = New System.Windows.Forms.RadioButton()
        Me.btnPathFirmaElectronica = New System.Windows.Forms.Button()
        Me.TextPathFirmaElectronica = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCorreoPorDefecto = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtConsumidorFinal = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnConfiguracion = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.btnConfiguracion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label5.Location = New System.Drawing.Point(12, 332)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(201, 17)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "CLAVE FIRMA ELECTRONICA:"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnSalir.FlatAppearance.BorderSize = 0
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.ForeColor = System.Drawing.Color.White
        Me.btnSalir.Location = New System.Drawing.Point(1015, 364)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(175, 39)
        Me.btnSalir.TabIndex = 27
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnAceptar.FlatAppearance.BorderSize = 0
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAceptar.ForeColor = System.Drawing.Color.White
        Me.btnAceptar.Location = New System.Drawing.Point(819, 364)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(175, 39)
        Me.btnAceptar.TabIndex = 26
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = False
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
        Me.GroupBox1.Location = New System.Drawing.Point(8, 70)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(1188, 166)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "UBICACION DE COMPROBANTES"
        '
        'btnNAutorizados
        '
        Me.btnNAutorizados.BackColor = System.Drawing.Color.DimGray
        Me.btnNAutorizados.FlatAppearance.BorderSize = 0
        Me.btnNAutorizados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNAutorizados.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNAutorizados.ForeColor = System.Drawing.Color.White
        Me.btnNAutorizados.Location = New System.Drawing.Point(1126, 123)
        Me.btnNAutorizados.Margin = New System.Windows.Forms.Padding(4)
        Me.btnNAutorizados.Name = "btnNAutorizados"
        Me.btnNAutorizados.Size = New System.Drawing.Size(29, 27)
        Me.btnNAutorizados.TabIndex = 13
        Me.btnNAutorizados.Text = "..."
        Me.btnNAutorizados.UseVisualStyleBackColor = True
        '
        'TextNoAutorizados
        '
        Me.TextNoAutorizados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNoAutorizados.Location = New System.Drawing.Point(277, 125)
        Me.TextNoAutorizados.Margin = New System.Windows.Forms.Padding(4)
        Me.TextNoAutorizados.Name = "TextNoAutorizados"
        Me.TextNoAutorizados.Size = New System.Drawing.Size(848, 22)
        Me.TextNoAutorizados.TabIndex = 8
        '
        'btnAutorizados
        '
        Me.btnAutorizados.BackColor = System.Drawing.Color.DimGray
        Me.btnAutorizados.FlatAppearance.BorderSize = 0
        Me.btnAutorizados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAutorizados.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutorizados.ForeColor = System.Drawing.Color.White
        Me.btnAutorizados.Location = New System.Drawing.Point(1126, 94)
        Me.btnAutorizados.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAutorizados.Name = "btnAutorizados"
        Me.btnAutorizados.Size = New System.Drawing.Size(29, 27)
        Me.btnAutorizados.TabIndex = 11
        Me.btnAutorizados.Text = "..."
        Me.btnAutorizados.UseVisualStyleBackColor = True
        '
        'TextAutorizados
        '
        Me.TextAutorizados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextAutorizados.Location = New System.Drawing.Point(277, 95)
        Me.TextAutorizados.Margin = New System.Windows.Forms.Padding(4)
        Me.TextAutorizados.Name = "TextAutorizados"
        Me.TextAutorizados.Size = New System.Drawing.Size(848, 22)
        Me.TextAutorizados.TabIndex = 6
        '
        'btnFirmados
        '
        Me.btnFirmados.BackColor = System.Drawing.Color.DimGray
        Me.btnFirmados.FlatAppearance.BorderSize = 0
        Me.btnFirmados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFirmados.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFirmados.ForeColor = System.Drawing.Color.White
        Me.btnFirmados.Location = New System.Drawing.Point(1126, 62)
        Me.btnFirmados.Margin = New System.Windows.Forms.Padding(4)
        Me.btnFirmados.Name = "btnFirmados"
        Me.btnFirmados.Size = New System.Drawing.Size(29, 27)
        Me.btnFirmados.TabIndex = 9
        Me.btnFirmados.Text = "..."
        Me.btnFirmados.UseVisualStyleBackColor = True
        '
        'TextFirmados
        '
        Me.TextFirmados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextFirmados.Location = New System.Drawing.Point(277, 63)
        Me.TextFirmados.Margin = New System.Windows.Forms.Padding(4)
        Me.TextFirmados.Name = "TextFirmados"
        Me.TextFirmados.Size = New System.Drawing.Size(848, 22)
        Me.TextFirmados.TabIndex = 4
        '
        'btnGenerados
        '
        Me.btnGenerados.BackColor = System.Drawing.Color.DimGray
        Me.btnGenerados.FlatAppearance.BorderSize = 0
        Me.btnGenerados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerados.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerados.ForeColor = System.Drawing.Color.White
        Me.btnGenerados.Location = New System.Drawing.Point(1126, 31)
        Me.btnGenerados.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGenerados.Name = "btnGenerados"
        Me.btnGenerados.Size = New System.Drawing.Size(29, 27)
        Me.btnGenerados.TabIndex = 2
        Me.btnGenerados.Text = "..."
        Me.btnGenerados.UseVisualStyleBackColor = True
        '
        'TextGenerados
        '
        Me.TextGenerados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextGenerados.Location = New System.Drawing.Point(277, 32)
        Me.TextGenerados.Margin = New System.Windows.Forms.Padding(4)
        Me.TextGenerados.Name = "TextGenerados"
        Me.TextGenerados.Size = New System.Drawing.Size(848, 22)
        Me.TextGenerados.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label4.Location = New System.Drawing.Point(13, 124)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(257, 17)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "COMPROBANTES NO AUTORIZADOS:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label3.Location = New System.Drawing.Point(37, 95)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(232, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "COMPROBANTES AUTORIZADOS:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label2.Location = New System.Drawing.Point(65, 63)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(203, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "COMPROBANTES FIRMADOS:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label1.Location = New System.Drawing.Point(49, 32)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(220, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "COMPROBANTES GENERADOS:"
        '
        'TextClave
        '
        Me.TextClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextClave.Location = New System.Drawing.Point(227, 329)
        Me.TextClave.Margin = New System.Windows.Forms.Padding(4)
        Me.TextClave.Name = "TextClave"
        Me.TextClave.Size = New System.Drawing.Size(307, 22)
        Me.TextClave.TabIndex = 25
        Me.TextClave.UseSystemPasswordChar = True
        '
        'chkPruebas
        '
        Me.chkPruebas.AutoSize = True
        Me.chkPruebas.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPruebas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkPruebas.ForeColor = System.Drawing.Color.SteelBlue
        Me.chkPruebas.Location = New System.Drawing.Point(453, 15)
        Me.chkPruebas.Margin = New System.Windows.Forms.Padding(4)
        Me.chkPruebas.Name = "chkPruebas"
        Me.chkPruebas.Size = New System.Drawing.Size(93, 21)
        Me.chkPruebas.TabIndex = 20
        Me.chkPruebas.TabStop = True
        Me.chkPruebas.Text = "PRUEBAS"
        Me.chkPruebas.UseVisualStyleBackColor = True
        '
        'chkProduccion
        '
        Me.chkProduccion.AutoSize = True
        Me.chkProduccion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkProduccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkProduccion.ForeColor = System.Drawing.Color.SteelBlue
        Me.chkProduccion.Location = New System.Drawing.Point(23, 15)
        Me.chkProduccion.Margin = New System.Windows.Forms.Padding(4)
        Me.chkProduccion.Name = "chkProduccion"
        Me.chkProduccion.Size = New System.Drawing.Size(388, 21)
        Me.chkProduccion.TabIndex = 19
        Me.chkProduccion.TabStop = True
        Me.chkProduccion.Text = "TIPO DE AMBIENTE EN OPERACIÓN :      PRODUCCIÓN"
        Me.chkProduccion.UseVisualStyleBackColor = True
        '
        'btnPathFirmaElectronica
        '
        Me.btnPathFirmaElectronica.BackColor = System.Drawing.Color.DimGray
        Me.btnPathFirmaElectronica.FlatAppearance.BorderSize = 0
        Me.btnPathFirmaElectronica.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPathFirmaElectronica.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPathFirmaElectronica.ForeColor = System.Drawing.Color.White
        Me.btnPathFirmaElectronica.Location = New System.Drawing.Point(1027, 292)
        Me.btnPathFirmaElectronica.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPathFirmaElectronica.Name = "btnPathFirmaElectronica"
        Me.btnPathFirmaElectronica.Size = New System.Drawing.Size(22, 22)
        Me.btnPathFirmaElectronica.TabIndex = 23
        Me.btnPathFirmaElectronica.Text = "..."
        Me.btnPathFirmaElectronica.UseVisualStyleBackColor = False
        '
        'TextPathFirmaElectronica
        '
        Me.TextPathFirmaElectronica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextPathFirmaElectronica.Location = New System.Drawing.Point(316, 292)
        Me.TextPathFirmaElectronica.Margin = New System.Windows.Forms.Padding(4)
        Me.TextPathFirmaElectronica.Name = "TextPathFirmaElectronica"
        Me.TextPathFirmaElectronica.Size = New System.Drawing.Size(709, 22)
        Me.TextPathFirmaElectronica.TabIndex = 22
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label6.Location = New System.Drawing.Point(13, 295)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(281, 17)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "CERTIFICADO CON FIRMA ELECTRÓNICA:"
        '
        'txtCorreoPorDefecto
        '
        Me.txtCorreoPorDefecto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCorreoPorDefecto.Location = New System.Drawing.Point(385, 254)
        Me.txtCorreoPorDefecto.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCorreoPorDefecto.Name = "txtCorreoPorDefecto"
        Me.txtCorreoPorDefecto.Size = New System.Drawing.Size(803, 22)
        Me.txtCorreoPorDefecto.TabIndex = 30
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label7.Location = New System.Drawing.Point(11, 249)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(368, 41)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "UTILIZAR ESTE CORREO ELECTRÓNICO CUANDO EL DESTINATARIO NO TIENE UNO REGISTRADO :" &
    ""
        '
        'txtConsumidorFinal
        '
        Me.txtConsumidorFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConsumidorFinal.Location = New System.Drawing.Point(316, 369)
        Me.txtConsumidorFinal.Margin = New System.Windows.Forms.Padding(4)
        Me.txtConsumidorFinal.Name = "txtConsumidorFinal"
        Me.txtConsumidorFinal.Size = New System.Drawing.Size(217, 22)
        Me.txtConsumidorFinal.TabIndex = 32
        '
        'Label9
        '
        Me.Label9.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label9.Location = New System.Drawing.Point(24, 366)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(284, 38)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "CODIGO DE CONSUMIDOR FINAL PARA NO ENVIAR CORREO ELECTRÓNICO"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Controls.Add(Me.Button3)
        Me.GroupBox3.Controls.Add(Me.Button4)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 70)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(1188, 166)
        Me.GroupBox3.TabIndex = 28
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "UBICACION DE COMPROBANTES"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DimGray
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(1140, 121)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(22, 22)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.DimGray
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(1140, 91)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(22, 22)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.DimGray
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(1140, 59)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(22, 22)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "..."
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.DimGray
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(1140, 28)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(22, 22)
        Me.Button4.TabIndex = 2
        Me.Button4.Text = "..."
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label8.Location = New System.Drawing.Point(13, 124)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(257, 17)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "COMPROBANTES NO AUTORIZADOS:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label10.Location = New System.Drawing.Point(37, 95)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(232, 17)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "COMPROBANTES AUTORIZADOS:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label11.Location = New System.Drawing.Point(65, 63)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(203, 17)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "COMPROBANTES FIRMADOS:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label12.Location = New System.Drawing.Point(49, 32)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(220, 17)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "COMPROBANTES GENERADOS:"
        '
        'btnConfiguracion
        '
        Me.btnConfiguracion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConfiguracion.Image = CType(resources.GetObject("btnConfiguracion.Image"), System.Drawing.Image)
        Me.btnConfiguracion.Location = New System.Drawing.Point(1157, 9)
        Me.btnConfiguracion.Name = "btnConfiguracion"
        Me.btnConfiguracion.Size = New System.Drawing.Size(39, 43)
        Me.btnConfiguracion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnConfiguracion.TabIndex = 33
        Me.btnConfiguracion.TabStop = False
        '
        'frmConfiguracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1205, 432)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnConfiguracion)
        Me.Controls.Add(Me.txtConsumidorFinal)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtCorreoPorDefecto)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TextClave)
        Me.Controls.Add(Me.chkPruebas)
        Me.Controls.Add(Me.chkProduccion)
        Me.Controls.Add(Me.btnPathFirmaElectronica)
        Me.Controls.Add(Me.TextPathFirmaElectronica)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox3)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmConfiguracion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CONFIGURACION DE DOCUMENTOS ELECTRÓNICOS "
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.btnConfiguracion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnNAutorizados As System.Windows.Forms.Button
    Friend WithEvents TextNoAutorizados As System.Windows.Forms.TextBox
    Friend WithEvents btnAutorizados As System.Windows.Forms.Button
    Friend WithEvents TextAutorizados As System.Windows.Forms.TextBox
    Friend WithEvents btnFirmados As System.Windows.Forms.Button
    Friend WithEvents TextFirmados As System.Windows.Forms.TextBox
    Friend WithEvents btnGenerados As System.Windows.Forms.Button
    Friend WithEvents TextGenerados As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents TextClave As System.Windows.Forms.TextBox
    Friend WithEvents chkPruebas As System.Windows.Forms.RadioButton
    Friend WithEvents chkProduccion As System.Windows.Forms.RadioButton
    Friend WithEvents btnPathFirmaElectronica As System.Windows.Forms.Button
    Friend WithEvents TextPathFirmaElectronica As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCorreoPorDefecto As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtConsumidorFinal As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As Windows.Forms.GroupBox
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents Button2 As Windows.Forms.Button
    Friend WithEvents Button3 As Windows.Forms.Button
    Friend WithEvents Button4 As Windows.Forms.Button
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents Label11 As Windows.Forms.Label
    Friend WithEvents Label12 As Windows.Forms.Label
    Private WithEvents btnConfiguracion As Windows.Forms.PictureBox
End Class
