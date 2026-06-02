<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmp))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btnModificar = New System.Windows.Forms.ToolStripButton()
        Me.btnEliminar = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.btnIdentificacion = New System.Windows.Forms.ToolStripButton()
        Me.btnBaseD = New System.Windows.Forms.ToolStripButton()
        Me.btnSuc = New System.Windows.Forms.ToolStripButton()
        Me.btnParam = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnEmp = New System.Windows.Forms.Button()
        Me.txtEmp = New System.Windows.Forms.TextBox()
        Me.chkEmpDef = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlIdentificacion = New System.Windows.Forms.Panel()
        Me.pnlBdd = New System.Windows.Forms.Panel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cboDaxp = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cboIvar = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cboRolP = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cboAdcom = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnProbarCon = New System.Windows.Forms.Button()
        Me.txtConfirma = New System.Windows.Forms.TextBox()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtUrs = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtservidor = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtSegSoc = New System.Windows.Forms.MaskedTextBox()
        Me.txtRuc = New System.Windows.Forms.MaskedTextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblContNom = New System.Windows.Forms.Label()
        Me.lblGerentNom = New System.Windows.Forms.Label()
        Me.lblRepLNom = New System.Windows.Forms.Label()
        Me.lblPresNom = New System.Windows.Forms.Label()
        Me.btnCont = New System.Windows.Forms.Button()
        Me.txtContCod = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnGerent = New System.Windows.Forms.Button()
        Me.txtGerent = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnRepL = New System.Windows.Forms.Button()
        Me.txtRepLCod = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnPres = New System.Windows.Forms.Button()
        Me.txtPresCod = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtCorreo = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.imgEmp = New System.Windows.Forms.PictureBox()
        Me.txtTelf2 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTelf1 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCasilla = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtFax = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDomicilio = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnCiudad = New System.Windows.Forms.Button()
        Me.txtCiudad = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnProv = New System.Windows.Forms.Button()
        Me.txtProv = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnCanton = New System.Windows.Forms.Button()
        Me.txtCanton = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnPais = New System.Windows.Forms.Button()
        Me.txtPais = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblpathIma = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlIdentificacion.SuspendLayout()
        Me.pnlBdd.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.imgEmp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.DimGray
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.btnNuevo, Me.btnModificar, Me.btnEliminar, Me.btnGuardar, Me.btnCancelar, Me.btnIdentificacion, Me.btnBaseD, Me.btnSuc, Me.btnParam, Me.ToolStripSeparator1, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(678, 46)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 46)
        '
        'btnNuevo
        '
        Me.btnNuevo.ForeColor = System.Drawing.Color.White
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(46, 43)
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnModificar
        '
        Me.btnModificar.ForeColor = System.Drawing.Color.White
        Me.btnModificar.Image = CType(resources.GetObject("btnModificar.Image"), System.Drawing.Image)
        Me.btnModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(62, 43)
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnEliminar
        '
        Me.btnEliminar.ForeColor = System.Drawing.Color.White
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(54, 43)
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnGuardar
        '
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(53, 43)
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.White
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(57, 43)
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnIdentificacion
        '
        Me.btnIdentificacion.Checked = True
        Me.btnIdentificacion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnIdentificacion.ForeColor = System.Drawing.Color.White
        Me.btnIdentificacion.Image = CType(resources.GetObject("btnIdentificacion.Image"), System.Drawing.Image)
        Me.btnIdentificacion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnIdentificacion.Name = "btnIdentificacion"
        Me.btnIdentificacion.Size = New System.Drawing.Size(83, 43)
        Me.btnIdentificacion.Text = "Identificación"
        Me.btnIdentificacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnBaseD
        '
        Me.btnBaseD.ForeColor = System.Drawing.Color.White
        Me.btnBaseD.Image = CType(resources.GetObject("btnBaseD.Image"), System.Drawing.Image)
        Me.btnBaseD.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBaseD.Name = "btnBaseD"
        Me.btnBaseD.Size = New System.Drawing.Size(65, 43)
        Me.btnBaseD.Text = "BaseDatos"
        Me.btnBaseD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnSuc
        '
        Me.btnSuc.ForeColor = System.Drawing.Color.White
        Me.btnSuc.Image = CType(resources.GetObject("btnSuc.Image"), System.Drawing.Image)
        Me.btnSuc.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSuc.Name = "btnSuc"
        Me.btnSuc.Size = New System.Drawing.Size(66, 43)
        Me.btnSuc.Text = "Sucursales"
        Me.btnSuc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnParam
        '
        Me.btnParam.ForeColor = System.Drawing.Color.White
        Me.btnParam.Image = CType(resources.GetObject("btnParam.Image"), System.Drawing.Image)
        Me.btnParam.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnParam.Name = "btnParam"
        Me.btnParam.Size = New System.Drawing.Size(71, 43)
        Me.btnParam.Text = "Parámetros"
        Me.btnParam.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 46)
        '
        'btnSalir
        '
        Me.btnSalir.ForeColor = System.Drawing.Color.White
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(57, 43)
        Me.btnSalir.Text = "Salir"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnEmp)
        Me.Panel1.Controls.Add(Me.txtEmp)
        Me.Panel1.Controls.Add(Me.chkEmpDef)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 46)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(678, 38)
        Me.Panel1.TabIndex = 4
        '
        'btnEmp
        '
        Me.btnEmp.Location = New System.Drawing.Point(368, 11)
        Me.btnEmp.Name = "btnEmp"
        Me.btnEmp.Size = New System.Drawing.Size(21, 21)
        Me.btnEmp.TabIndex = 8
        Me.btnEmp.Text = "..."
        Me.btnEmp.UseVisualStyleBackColor = True
        '
        'txtEmp
        '
        Me.txtEmp.Location = New System.Drawing.Point(124, 11)
        Me.txtEmp.Name = "txtEmp"
        Me.txtEmp.Size = New System.Drawing.Size(247, 20)
        Me.txtEmp.TabIndex = 7
        '
        'chkEmpDef
        '
        Me.chkEmpDef.AutoSize = True
        Me.chkEmpDef.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEmpDef.ForeColor = System.Drawing.Color.White
        Me.chkEmpDef.Location = New System.Drawing.Point(433, 15)
        Me.chkEmpDef.Name = "chkEmpDef"
        Me.chkEmpDef.Size = New System.Drawing.Size(176, 17)
        Me.chkEmpDef.TabIndex = 6
        Me.chkEmpDef.Text = "EMPRESA POR DEFECTO"
        Me.chkEmpDef.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(10, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Nombre de la Empresa:"
        '
        'pnlIdentificacion
        '
        Me.pnlIdentificacion.Controls.Add(Me.pnlBdd)
        Me.pnlIdentificacion.Controls.Add(Me.txtSegSoc)
        Me.pnlIdentificacion.Controls.Add(Me.txtRuc)
        Me.pnlIdentificacion.Controls.Add(Me.GroupBox2)
        Me.pnlIdentificacion.Controls.Add(Me.GroupBox1)
        Me.pnlIdentificacion.Controls.Add(Me.Label3)
        Me.pnlIdentificacion.Controls.Add(Me.Label2)
        Me.pnlIdentificacion.Controls.Add(Me.lblpathIma)
        Me.pnlIdentificacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlIdentificacion.Location = New System.Drawing.Point(0, 84)
        Me.pnlIdentificacion.Name = "pnlIdentificacion"
        Me.pnlIdentificacion.Size = New System.Drawing.Size(678, 347)
        Me.pnlIdentificacion.TabIndex = 6
        '
        'pnlBdd
        '
        Me.pnlBdd.BackColor = System.Drawing.Color.DarkGray
        Me.pnlBdd.Controls.Add(Me.GroupBox3)
        Me.pnlBdd.Controls.Add(Me.GroupBox4)
        Me.pnlBdd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBdd.Location = New System.Drawing.Point(0, 0)
        Me.pnlBdd.Name = "pnlBdd"
        Me.pnlBdd.Size = New System.Drawing.Size(678, 347)
        Me.pnlBdd.TabIndex = 22
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.cboDaxp)
        Me.GroupBox4.Controls.Add(Me.Label25)
        Me.GroupBox4.Controls.Add(Me.cboIvar)
        Me.GroupBox4.Controls.Add(Me.Label24)
        Me.GroupBox4.Controls.Add(Me.cboRolP)
        Me.GroupBox4.Controls.Add(Me.Label23)
        Me.GroupBox4.Controls.Add(Me.cboAdcom)
        Me.GroupBox4.Controls.Add(Me.Label22)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 127)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(667, 206)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Nombres de las bases de datos"
        '
        'cboDaxp
        '
        Me.cboDaxp.FormattingEnabled = True
        Me.cboDaxp.Location = New System.Drawing.Point(188, 118)
        Me.cboDaxp.Name = "cboDaxp"
        Me.cboDaxp.Size = New System.Drawing.Size(412, 21)
        Me.cboDaxp.TabIndex = 7
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(73, 126)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(99, 13)
        Me.Label25.TabIndex = 6
        Me.Label25.Text = "DAXPRO / HOTEL"
        '
        'cboIvar
        '
        Me.cboIvar.FormattingEnabled = True
        Me.cboIvar.Location = New System.Drawing.Point(188, 91)
        Me.cboIvar.Name = "cboIvar"
        Me.cboIvar.Size = New System.Drawing.Size(412, 21)
        Me.cboIvar.TabIndex = 5
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(126, 98)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(46, 13)
        Me.Label24.TabIndex = 4
        Me.Label24.Text = "IVARET"
        '
        'cboRolP
        '
        Me.cboRolP.FormattingEnabled = True
        Me.cboRolP.Location = New System.Drawing.Point(188, 63)
        Me.cboRolP.Name = "cboRolP"
        Me.cboRolP.Size = New System.Drawing.Size(412, 21)
        Me.cboRolP.TabIndex = 3
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(62, 69)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(110, 13)
        Me.Label23.TabIndex = 2
        Me.Label23.Text = "ROLPAG / DAXTIME"
        '
        'cboAdcom
        '
        Me.cboAdcom.FormattingEnabled = True
        Me.cboAdcom.Location = New System.Drawing.Point(188, 36)
        Me.cboAdcom.Name = "cboAdcom"
        Me.cboAdcom.Size = New System.Drawing.Size(412, 21)
        Me.cboAdcom.TabIndex = 1
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(118, 39)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(54, 13)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "ADCOMw"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.btnProbarCon)
        Me.GroupBox3.Controls.Add(Me.txtConfirma)
        Me.GroupBox3.Controls.Add(Me.txtPass)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.txtUrs)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.txtservidor)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(670, 111)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Servidor"
        '
        'btnProbarCon
        '
        Me.btnProbarCon.BackColor = System.Drawing.Color.DimGray
        Me.btnProbarCon.FlatAppearance.BorderSize = 0
        Me.btnProbarCon.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProbarCon.ForeColor = System.Drawing.Color.White
        Me.btnProbarCon.Location = New System.Drawing.Point(416, 69)
        Me.btnProbarCon.Name = "btnProbarCon"
        Me.btnProbarCon.Size = New System.Drawing.Size(122, 21)
        Me.btnProbarCon.TabIndex = 8
        Me.btnProbarCon.Text = "Probar Conexión"
        Me.btnProbarCon.UseVisualStyleBackColor = False
        '
        'txtConfirma
        '
        Me.txtConfirma.Location = New System.Drawing.Point(381, 22)
        Me.txtConfirma.Name = "txtConfirma"
        Me.txtConfirma.PasswordChar = Global.Microsoft.VisualBasic.ChrW(36)
        Me.txtConfirma.Size = New System.Drawing.Size(202, 20)
        Me.txtConfirma.TabIndex = 7
        '
        'txtPass
        '
        Me.txtPass.Location = New System.Drawing.Point(381, 22)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(36)
        Me.txtPass.Size = New System.Drawing.Size(202, 20)
        Me.txtPass.TabIndex = 5
        Me.txtPass.Visible = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(302, 25)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(64, 13)
        Me.Label20.TabIndex = 4
        Me.Label20.Text = "Contraseña:"
        Me.Label20.Visible = False
        '
        'txtUrs
        '
        Me.txtUrs.Location = New System.Drawing.Point(59, 50)
        Me.txtUrs.Name = "txtUrs"
        Me.txtUrs.Size = New System.Drawing.Size(208, 20)
        Me.txtUrs.TabIndex = 3
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(8, 53)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(46, 13)
        Me.Label19.TabIndex = 2
        Me.Label19.Text = "Usuario:"
        '
        'txtservidor
        '
        Me.txtservidor.Location = New System.Drawing.Point(59, 22)
        Me.txtservidor.Name = "txtservidor"
        Me.txtservidor.Size = New System.Drawing.Size(209, 20)
        Me.txtservidor.TabIndex = 1
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(8, 27)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(49, 13)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Servidor:"
        '
        'txtSegSoc
        '
        Me.txtSegSoc.Location = New System.Drawing.Point(386, 9)
        Me.txtSegSoc.Mask = "#############"
        Me.txtSegSoc.Name = "txtSegSoc"
        Me.txtSegSoc.Size = New System.Drawing.Size(90, 20)
        Me.txtSegSoc.TabIndex = 21
        Me.txtSegSoc.Visible = False
        '
        'txtRuc
        '
        Me.txtRuc.Location = New System.Drawing.Point(74, 6)
        Me.txtRuc.Mask = "#############"
        Me.txtRuc.Name = "txtRuc"
        Me.txtRuc.Size = New System.Drawing.Size(90, 20)
        Me.txtRuc.TabIndex = 20
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblContNom)
        Me.GroupBox2.Controls.Add(Me.lblGerentNom)
        Me.GroupBox2.Controls.Add(Me.lblRepLNom)
        Me.GroupBox2.Controls.Add(Me.lblPresNom)
        Me.GroupBox2.Controls.Add(Me.btnCont)
        Me.GroupBox2.Controls.Add(Me.txtContCod)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.btnGerent)
        Me.GroupBox2.Controls.Add(Me.txtGerent)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.btnRepL)
        Me.GroupBox2.Controls.Add(Me.txtRepLCod)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.btnPres)
        Me.GroupBox2.Controls.Add(Me.txtPresCod)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 209)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(606, 136)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Autoridades"
        '
        'lblContNom
        '
        Me.lblContNom.BackColor = System.Drawing.Color.White
        Me.lblContNom.Location = New System.Drawing.Point(255, 104)
        Me.lblContNom.Name = "lblContNom"
        Me.lblContNom.Size = New System.Drawing.Size(325, 17)
        Me.lblContNom.TabIndex = 18
        '
        'lblGerentNom
        '
        Me.lblGerentNom.BackColor = System.Drawing.Color.White
        Me.lblGerentNom.Location = New System.Drawing.Point(255, 79)
        Me.lblGerentNom.Name = "lblGerentNom"
        Me.lblGerentNom.Size = New System.Drawing.Size(325, 17)
        Me.lblGerentNom.TabIndex = 17
        '
        'lblRepLNom
        '
        Me.lblRepLNom.BackColor = System.Drawing.Color.White
        Me.lblRepLNom.Location = New System.Drawing.Point(255, 53)
        Me.lblRepLNom.Name = "lblRepLNom"
        Me.lblRepLNom.Size = New System.Drawing.Size(325, 17)
        Me.lblRepLNom.TabIndex = 16
        '
        'lblPresNom
        '
        Me.lblPresNom.BackColor = System.Drawing.Color.White
        Me.lblPresNom.Location = New System.Drawing.Point(255, 27)
        Me.lblPresNom.Name = "lblPresNom"
        Me.lblPresNom.Size = New System.Drawing.Size(325, 17)
        Me.lblPresNom.TabIndex = 15
        '
        'btnCont
        '
        Me.btnCont.BackColor = System.Drawing.Color.DimGray
        Me.btnCont.FlatAppearance.BorderSize = 0
        Me.btnCont.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCont.ForeColor = System.Drawing.Color.White
        Me.btnCont.Location = New System.Drawing.Point(230, 101)
        Me.btnCont.Name = "btnCont"
        Me.btnCont.Size = New System.Drawing.Size(20, 20)
        Me.btnCont.TabIndex = 14
        Me.btnCont.Text = "..."
        Me.btnCont.UseVisualStyleBackColor = False
        '
        'txtContCod
        '
        Me.txtContCod.Location = New System.Drawing.Point(88, 101)
        Me.txtContCod.Name = "txtContCod"
        Me.txtContCod.Size = New System.Drawing.Size(142, 20)
        Me.txtContCod.TabIndex = 13
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(8, 104)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(50, 13)
        Me.Label16.TabIndex = 12
        Me.Label16.Text = "Contador"
        '
        'btnGerent
        '
        Me.btnGerent.BackColor = System.Drawing.Color.DimGray
        Me.btnGerent.FlatAppearance.BorderSize = 0
        Me.btnGerent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGerent.ForeColor = System.Drawing.Color.White
        Me.btnGerent.Location = New System.Drawing.Point(230, 75)
        Me.btnGerent.Name = "btnGerent"
        Me.btnGerent.Size = New System.Drawing.Size(20, 20)
        Me.btnGerent.TabIndex = 10
        Me.btnGerent.Text = "..."
        Me.btnGerent.UseVisualStyleBackColor = False
        '
        'txtGerent
        '
        Me.txtGerent.Location = New System.Drawing.Point(88, 75)
        Me.txtGerent.Name = "txtGerent"
        Me.txtGerent.Size = New System.Drawing.Size(142, 20)
        Me.txtGerent.TabIndex = 9
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(8, 80)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 13)
        Me.Label15.TabIndex = 8
        Me.Label15.Text = "Gerente:"
        '
        'btnRepL
        '
        Me.btnRepL.BackColor = System.Drawing.Color.DimGray
        Me.btnRepL.FlatAppearance.BorderSize = 0
        Me.btnRepL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRepL.ForeColor = System.Drawing.Color.White
        Me.btnRepL.Location = New System.Drawing.Point(230, 49)
        Me.btnRepL.Name = "btnRepL"
        Me.btnRepL.Size = New System.Drawing.Size(20, 20)
        Me.btnRepL.TabIndex = 6
        Me.btnRepL.Text = "..."
        Me.btnRepL.UseVisualStyleBackColor = False
        '
        'txtRepLCod
        '
        Me.txtRepLCod.Location = New System.Drawing.Point(88, 49)
        Me.txtRepLCod.Name = "txtRepLCod"
        Me.txtRepLCod.Size = New System.Drawing.Size(142, 20)
        Me.txtRepLCod.TabIndex = 5
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(8, 46)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(82, 26)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "Representante Legal:"
        '
        'btnPres
        '
        Me.btnPres.BackColor = System.Drawing.Color.DimGray
        Me.btnPres.FlatAppearance.BorderSize = 0
        Me.btnPres.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPres.ForeColor = System.Drawing.Color.White
        Me.btnPres.Location = New System.Drawing.Point(230, 23)
        Me.btnPres.Name = "btnPres"
        Me.btnPres.Size = New System.Drawing.Size(20, 20)
        Me.btnPres.TabIndex = 2
        Me.btnPres.Text = "..."
        Me.btnPres.UseVisualStyleBackColor = False
        '
        'txtPresCod
        '
        Me.txtPresCod.Location = New System.Drawing.Point(88, 23)
        Me.txtPresCod.Name = "txtPresCod"
        Me.txtPresCod.Size = New System.Drawing.Size(142, 20)
        Me.txtPresCod.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(8, 26)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(60, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Presidente:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtCorreo)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.imgEmp)
        Me.GroupBox1.Controls.Add(Me.txtTelf2)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtTelf1)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtCasilla)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtFax)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtDomicilio)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.btnCiudad)
        Me.GroupBox1.Controls.Add(Me.txtCiudad)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.btnProv)
        Me.GroupBox1.Controls.Add(Me.txtProv)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.btnCanton)
        Me.GroupBox1.Controls.Add(Me.txtCanton)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btnPais)
        Me.GroupBox1.Controls.Add(Me.txtPais)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(607, 171)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ubicación "
        '
        'txtCorreo
        '
        Me.txtCorreo.Location = New System.Drawing.Point(67, 145)
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.Size = New System.Drawing.Size(330, 20)
        Me.txtCorreo.TabIndex = 24
        '
        'Label17
        '
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(4, 141)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(63, 28)
        Me.Label17.TabIndex = 23
        Me.Label17.Text = "Correo Electrónico:"
        '
        'imgEmp
        '
        Me.imgEmp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.imgEmp.Location = New System.Drawing.Point(424, 25)
        Me.imgEmp.Name = "imgEmp"
        Me.imgEmp.Size = New System.Drawing.Size(157, 124)
        Me.imgEmp.TabIndex = 22
        Me.imgEmp.TabStop = False
        '
        'txtTelf2
        '
        Me.txtTelf2.Location = New System.Drawing.Point(272, 120)
        Me.txtTelf2.Name = "txtTelf2"
        Me.txtTelf2.Size = New System.Drawing.Size(125, 20)
        Me.txtTelf2.TabIndex = 21
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(208, 122)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 13)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Teléfono2:"
        '
        'txtTelf1
        '
        Me.txtTelf1.Location = New System.Drawing.Point(67, 120)
        Me.txtTelf1.Name = "txtTelf1"
        Me.txtTelf1.Size = New System.Drawing.Size(121, 20)
        Me.txtTelf1.TabIndex = 19
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(2, 121)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 13)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "Teléfono1:"
        '
        'txtCasilla
        '
        Me.txtCasilla.Location = New System.Drawing.Point(272, 92)
        Me.txtCasilla.Name = "txtCasilla"
        Me.txtCasilla.Size = New System.Drawing.Size(125, 20)
        Me.txtCasilla.TabIndex = 17
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(229, 99)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 13)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Casilla"
        '
        'txtFax
        '
        Me.txtFax.Location = New System.Drawing.Point(67, 92)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(121, 20)
        Me.txtFax.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(28, 95)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "FAX:"
        '
        'txtDomicilio
        '
        Me.txtDomicilio.Location = New System.Drawing.Point(67, 67)
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.Size = New System.Drawing.Size(330, 20)
        Me.txtDomicilio.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(6, 70)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Domicilio:"
        '
        'btnCiudad
        '
        Me.btnCiudad.BackColor = System.Drawing.Color.DimGray
        Me.btnCiudad.FlatAppearance.BorderSize = 0
        Me.btnCiudad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCiudad.ForeColor = System.Drawing.Color.White
        Me.btnCiudad.Location = New System.Drawing.Point(398, 40)
        Me.btnCiudad.Name = "btnCiudad"
        Me.btnCiudad.Size = New System.Drawing.Size(20, 20)
        Me.btnCiudad.TabIndex = 11
        Me.btnCiudad.Text = "..."
        Me.btnCiudad.UseVisualStyleBackColor = False
        '
        'txtCiudad
        '
        Me.txtCiudad.Location = New System.Drawing.Point(272, 40)
        Me.txtCiudad.Name = "txtCiudad"
        Me.txtCiudad.Size = New System.Drawing.Size(125, 20)
        Me.txtCiudad.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(223, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Ciudad:"
        '
        'btnProv
        '
        Me.btnProv.BackColor = System.Drawing.Color.DimGray
        Me.btnProv.FlatAppearance.BorderSize = 0
        Me.btnProv.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProv.ForeColor = System.Drawing.Color.White
        Me.btnProv.Location = New System.Drawing.Point(398, 13)
        Me.btnProv.Name = "btnProv"
        Me.btnProv.Size = New System.Drawing.Size(20, 20)
        Me.btnProv.TabIndex = 8
        Me.btnProv.Text = "..."
        Me.btnProv.UseVisualStyleBackColor = False
        '
        'txtProv
        '
        Me.txtProv.Location = New System.Drawing.Point(272, 13)
        Me.txtProv.Name = "txtProv"
        Me.txtProv.Size = New System.Drawing.Size(125, 20)
        Me.txtProv.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(212, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Provincia:"
        '
        'btnCanton
        '
        Me.btnCanton.BackColor = System.Drawing.Color.DimGray
        Me.btnCanton.FlatAppearance.BorderSize = 0
        Me.btnCanton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCanton.ForeColor = System.Drawing.Color.White
        Me.btnCanton.Location = New System.Drawing.Point(188, 40)
        Me.btnCanton.Name = "btnCanton"
        Me.btnCanton.Size = New System.Drawing.Size(20, 20)
        Me.btnCanton.TabIndex = 5
        Me.btnCanton.Text = "..."
        Me.btnCanton.UseVisualStyleBackColor = False
        '
        'txtCanton
        '
        Me.txtCanton.Location = New System.Drawing.Point(67, 40)
        Me.txtCanton.Name = "txtCanton"
        Me.txtCanton.Size = New System.Drawing.Size(120, 20)
        Me.txtCanton.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(14, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Cantón:"
        '
        'btnPais
        '
        Me.btnPais.BackColor = System.Drawing.Color.DimGray
        Me.btnPais.FlatAppearance.BorderSize = 0
        Me.btnPais.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPais.ForeColor = System.Drawing.Color.White
        Me.btnPais.Location = New System.Drawing.Point(188, 13)
        Me.btnPais.Name = "btnPais"
        Me.btnPais.Size = New System.Drawing.Size(20, 20)
        Me.btnPais.TabIndex = 2
        Me.btnPais.Text = "..."
        Me.btnPais.UseVisualStyleBackColor = False
        '
        'txtPais
        '
        Me.txtPais.Location = New System.Drawing.Point(67, 13)
        Me.txtPais.Name = "txtPais"
        Me.txtPais.Size = New System.Drawing.Size(120, 20)
        Me.txtPais.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(26, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "País:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(281, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Nro. Seguro Social:"
        Me.Label3.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "RUC:"
        '
        'lblpathIma
        '
        Me.lblpathIma.BackColor = System.Drawing.Color.White
        Me.lblpathIma.Location = New System.Drawing.Point(79, 337)
        Me.lblpathIma.Name = "lblpathIma"
        Me.lblpathIma.Size = New System.Drawing.Size(325, 17)
        Me.lblpathIma.TabIndex = 19
        Me.lblpathIma.Visible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmEmp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.ClientSize = New System.Drawing.Size(678, 431)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlIdentificacion)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEmp"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ADCOMDAX - ADMINISTRACIÓN EMPRESAS"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlIdentificacion.ResumeLayout(False)
        Me.pnlIdentificacion.PerformLayout()
        Me.pnlBdd.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.imgEmp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents chkEmpDef As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnEmp As System.Windows.Forms.Button
    Friend WithEvents txtEmp As System.Windows.Forms.TextBox
    Friend WithEvents pnlIdentificacion As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents imgEmp As System.Windows.Forms.PictureBox
    Friend WithEvents txtTelf2 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTelf1 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCasilla As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnCiudad As System.Windows.Forms.Button
    Friend WithEvents txtCiudad As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnProv As System.Windows.Forms.Button
    Friend WithEvents txtProv As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnCanton As System.Windows.Forms.Button
    Friend WithEvents txtCanton As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnPais As System.Windows.Forms.Button
    Friend WithEvents txtPais As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnIdentificacion As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnBaseD As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSuc As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnParam As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCont As System.Windows.Forms.Button
    Friend WithEvents txtContCod As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btnGerent As System.Windows.Forms.Button
    Friend WithEvents txtGerent As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnRepL As System.Windows.Forms.Button
    Friend WithEvents txtRepLCod As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnPres As System.Windows.Forms.Button
    Friend WithEvents txtPresCod As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtCorreo As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblContNom As System.Windows.Forms.Label
    Friend WithEvents lblGerentNom As System.Windows.Forms.Label
    Friend WithEvents lblRepLNom As System.Windows.Forms.Label
    Friend WithEvents lblPresNom As System.Windows.Forms.Label
    Friend WithEvents btnModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblpathIma As System.Windows.Forms.Label
    Friend WithEvents txtSegSoc As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtRuc As System.Windows.Forms.MaskedTextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents pnlBdd As System.Windows.Forms.Panel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtConfirma As System.Windows.Forms.TextBox
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtUrs As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtservidor As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents btnProbarCon As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDaxp As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cboIvar As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cboRolP As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cboAdcom As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label

End Class
