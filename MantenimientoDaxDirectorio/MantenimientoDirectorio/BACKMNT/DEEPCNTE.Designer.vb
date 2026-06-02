<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DEEPCNTE
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DEEPCNTE))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btnAbrir = New System.Windows.Forms.ToolStripButton()
        Me.btnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btnEliminar = New System.Windows.Forms.ToolStripButton()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.Command5 = New System.Windows.Forms.Button()
        Me.txtLimiteCredito = New System.Windows.Forms.TextBox()
        Me.Command1 = New System.Windows.Forms.Button()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.observacli = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.txtDescuentoAsociacion = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.txtContacto = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.entregarmer = New System.Windows.Forms.TextBox()
        Me.txtPorcDescuento = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.btnFormaPago = New System.Windows.Forms.Button()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.btnPrecioVenta = New System.Windows.Forms.Button()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.btnBuscaCobrador = New System.Windows.Forms.Button()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.btnBuscaZonaCobro = New System.Windows.Forms.Button()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.btnBuscaVendedor = New System.Windows.Forms.Button()
        Me.malla = New System.Windows.Forms.DataGridView()
        Me.Nro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CedulaId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombres = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Parentesco = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.FechaNacim = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sexo1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.EstadoCivil = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Direccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Teléfono_1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Teléfono_2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ocupación = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Depend = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Minusv = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.tabFamiliares = New System.Windows.Forms.TabPage()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.txtHistoriaclinica = New System.Windows.Forms.TextBox()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.Apellidos = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TxtData9 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TxtData8 = New System.Windows.Forms.TextBox()
        Me.TxtData6 = New System.Windows.Forms.TextBox()
        Me.label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtTelefono3 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtTelefono2 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTelefono1 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtNroDomicilio = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtnomDireccion = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.DatosDirectorio = New System.Windows.Forms.TabControl()
        Me.tabIdentificación = New System.Windows.Forms.TabPage()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.cmbRegionDomicilio = New System.Windows.Forms.ComboBox()
        Me.cmbCantonDomicilio = New System.Windows.Forms.ComboBox()
        Me.cmbCiudadDomicilio = New System.Windows.Forms.ComboBox()
        Me.cmbParroquiaDomicilio = New System.Windows.Forms.ComboBox()
        Me.cmbProvinciaDomicilio = New System.Windows.Forms.ComboBox()
        Me.cmbPaisDomicilio = New System.Windows.Forms.ComboBox()
        Me.txtSector = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.chkRegimenMicroempresas = New System.Windows.Forms.CheckBox()
        Me.TxtResolucionAR = New System.Windows.Forms.TextBox()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.txtContribuyenteEspecial = New System.Windows.Forms.TextBox()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.chkRise = New System.Windows.Forms.CheckBox()
        Me.chkObligaContabilidad = New System.Windows.Forms.CheckBox()
        Me.ExoneradoIva = New System.Windows.Forms.CheckBox()
        Me.foto = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.impresion = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tabDatosPer = New System.Windows.Forms.TabPage()
        Me.cmbEspecialidad2 = New System.Windows.Forms.ComboBox()
        Me.cmbEspecialidad = New System.Windows.Forms.ComboBox()
        Me.cmbProfesion = New System.Windows.Forms.ComboBox()
        Me.cmbNacionalidadPersonal = New System.Windows.Forms.ComboBox()
        Me.cmbTipoSangre = New System.Windows.Forms.ComboBox()
        Me.Label93 = New System.Windows.Forms.Label()
        Me.Label89 = New System.Windows.Forms.Label()
        Me.txtPorcDiscapacidad = New System.Windows.Forms.TextBox()
        Me.Label91 = New System.Windows.Forms.Label()
        Me.txtDiscapacidad = New System.Windows.Forms.TextBox()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.cmbRegionNace = New System.Windows.Forms.ComboBox()
        Me.cmbCiudadNace = New System.Windows.Forms.ComboBox()
        Me.cmbProvinciaNace = New System.Windows.Forms.ComboBox()
        Me.cmbPaisNace = New System.Windows.Forms.ComboBox()
        Me.fechanaci = New System.Windows.Forms.DateTimePicker()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.Label85 = New System.Windows.Forms.Label()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.Lugarnaci = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.asociadoa = New System.Windows.Forms.GroupBox()
        Me.CbuscaDir3 = New System.Windows.Forms.Button()
        Me.LDir3 = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtLugTra = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtNumTar = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtCodTar = New System.Windows.Forms.TextBox()
        Me.hobbys = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtReferirseComo = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cmbEstadoCivil = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.mujer = New System.Windows.Forms.RadioButton()
        Me.hombre = New System.Windows.Forms.RadioButton()
        Me.tabCliente = New System.Windows.Forms.TabPage()
        Me.btnBuscaZonaVentas = New System.Windows.Forms.Button()
        Me.CBuscador3 = New System.Windows.Forms.Button()
        Me.txtOperador = New System.Windows.Forms.Label()
        Me.btnBuscaOperador = New System.Windows.Forms.Button()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.Cuenta4 = New System.Windows.Forms.Label()
        Me.Cuenta0 = New System.Windows.Forms.Label()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.btnTransportadora = New System.Windows.Forms.Button()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.txtTransportadora = New System.Windows.Forms.TextBox()
        Me.txtPaisEntrega = New System.Windows.Forms.Label()
        Me.btnPuertoEntrega = New System.Windows.Forms.Button()
        Me.Label94 = New System.Windows.Forms.Label()
        Me.btnPaísEntrega = New System.Windows.Forms.Button()
        Me.Label95 = New System.Windows.Forms.Label()
        Me.txtCobrador = New System.Windows.Forms.Label()
        Me.txtVendedor = New System.Windows.Forms.Label()
        Me.txtZonaCobranzas = New System.Windows.Forms.Label()
        Me.txtZonaVentas = New System.Windows.Forms.Label()
        Me.txtTipoCliente = New System.Windows.Forms.Label()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.txtPrecioVenta = New System.Windows.Forms.Label()
        Me.txtFormaPago = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Codigo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TipoIdent = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtCedulaRuc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtNombres = New System.Windows.Forms.TextBox()
        Me.dialogoOpen = New System.Windows.Forms.OpenFileDialog()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.malla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabFamiliares.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.DatosDirectorio.SuspendLayout()
        Me.tabIdentificación.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.foto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDatosPer.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.asociadoa.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.tabCliente.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.DimGray
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.btnAbrir, Me.btnCerrar, Me.btnGuardar, Me.btnEliminar, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(1012, 38)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnNuevo
        '
        Me.btnNuevo.ForeColor = System.Drawing.Color.White
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(46, 35)
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnAbrir
        '
        Me.btnAbrir.ForeColor = System.Drawing.Color.White
        Me.btnAbrir.Image = CType(resources.GetObject("btnAbrir.Image"), System.Drawing.Image)
        Me.btnAbrir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.Size = New System.Drawing.Size(37, 35)
        Me.btnAbrir.Text = "Abrir"
        Me.btnAbrir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.White
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(43, 35)
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnGuardar
        '
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(53, 35)
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnEliminar
        '
        Me.btnEliminar.ForeColor = System.Drawing.Color.White
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(54, 35)
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnSalir
        '
        Me.btnSalir.ForeColor = System.Drawing.Color.White
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(33, 35)
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.ForeColor = System.Drawing.Color.White
        Me.Label75.Location = New System.Drawing.Point(359, 287)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(121, 13)
        Me.Label75.TabIndex = 36
        Me.Label75.Text = "Identificativo Contable-2"
        '
        'Command5
        '
        Me.Command5.BackColor = System.Drawing.Color.DimGray
        Me.Command5.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Command5.FlatAppearance.BorderSize = 0
        Me.Command5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Command5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command5.ForeColor = System.Drawing.Color.White
        Me.Command5.Location = New System.Drawing.Point(485, 285)
        Me.Command5.Name = "Command5"
        Me.Command5.Size = New System.Drawing.Size(18, 18)
        Me.Command5.TabIndex = 38
        Me.Command5.Text = "..."
        Me.Command5.UseVisualStyleBackColor = False
        '
        'txtLimiteCredito
        '
        Me.txtLimiteCredito.ForeColor = System.Drawing.Color.Black
        Me.txtLimiteCredito.Location = New System.Drawing.Point(107, 46)
        Me.txtLimiteCredito.Name = "txtLimiteCredito"
        Me.txtLimiteCredito.Size = New System.Drawing.Size(132, 20)
        Me.txtLimiteCredito.TabIndex = 28
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.Color.DimGray
        Me.Command1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Command1.FlatAppearance.BorderSize = 0
        Me.Command1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Command1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command1.ForeColor = System.Drawing.Color.White
        Me.Command1.Location = New System.Drawing.Point(127, 286)
        Me.Command1.Name = "Command1"
        Me.Command1.Size = New System.Drawing.Size(18, 18)
        Me.Command1.TabIndex = 35
        Me.Command1.Text = "..."
        Me.Command1.UseVisualStyleBackColor = False
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.ForeColor = System.Drawing.Color.White
        Me.Label46.Location = New System.Drawing.Point(16, 49)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(87, 13)
        Me.Label46.TabIndex = 27
        Me.Label46.Text = "Límite de Credito"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.ForeColor = System.Drawing.Color.White
        Me.Label45.Location = New System.Drawing.Point(3, 288)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(121, 13)
        Me.Label45.TabIndex = 31
        Me.Label45.Text = "Identificativo Contable-1"
        '
        'observacli
        '
        Me.observacli.Location = New System.Drawing.Point(91, 316)
        Me.observacli.Name = "observacli"
        Me.observacli.Size = New System.Drawing.Size(351, 20)
        Me.observacli.TabIndex = 40
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.ForeColor = System.Drawing.Color.White
        Me.Label44.Location = New System.Drawing.Point(7, 320)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(78, 13)
        Me.Label44.TabIndex = 39
        Me.Label44.Text = "Observaciones"
        '
        'txtDescuentoAsociacion
        '
        Me.txtDescuentoAsociacion.ForeColor = System.Drawing.Color.Black
        Me.txtDescuentoAsociacion.Location = New System.Drawing.Point(605, 45)
        Me.txtDescuentoAsociacion.MaxLength = 6
        Me.txtDescuentoAsociacion.Name = "txtDescuentoAsociacion"
        Me.txtDescuentoAsociacion.Size = New System.Drawing.Size(99, 20)
        Me.txtDescuentoAsociacion.TabIndex = 30
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.ForeColor = System.Drawing.Color.White
        Me.Label43.Location = New System.Drawing.Point(456, 48)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(143, 13)
        Me.Label43.TabIndex = 29
        Me.Label43.Text = "Decuento  como  asociación"
        '
        'txtContacto
        '
        Me.txtContacto.Location = New System.Drawing.Point(86, 74)
        Me.txtContacto.Name = "txtContacto"
        Me.txtContacto.Size = New System.Drawing.Size(425, 20)
        Me.txtContacto.TabIndex = 26
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.ForeColor = System.Drawing.Color.White
        Me.Label42.Location = New System.Drawing.Point(16, 78)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(50, 13)
        Me.Label42.TabIndex = 25
        Me.Label42.Text = "Contacto"
        '
        'entregarmer
        '
        Me.entregarmer.ForeColor = System.Drawing.Color.Black
        Me.entregarmer.Location = New System.Drawing.Point(318, 17)
        Me.entregarmer.Name = "entregarmer"
        Me.entregarmer.Size = New System.Drawing.Size(326, 20)
        Me.entregarmer.TabIndex = 24
        '
        'txtPorcDescuento
        '
        Me.txtPorcDescuento.ForeColor = System.Drawing.Color.Black
        Me.txtPorcDescuento.Location = New System.Drawing.Point(604, 21)
        Me.txtPorcDescuento.MaxLength = 5
        Me.txtPorcDescuento.Name = "txtPorcDescuento"
        Me.txtPorcDescuento.Size = New System.Drawing.Size(48, 20)
        Me.txtPorcDescuento.TabIndex = 22
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.ForeColor = System.Drawing.Color.White
        Me.Label40.Location = New System.Drawing.Point(490, 24)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(113, 13)
        Me.Label40.TabIndex = 21
        Me.Label40.Text = "Porcentaje Descuento"
        '
        'btnFormaPago
        '
        Me.btnFormaPago.BackColor = System.Drawing.Color.DimGray
        Me.btnFormaPago.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnFormaPago.FlatAppearance.BorderSize = 0
        Me.btnFormaPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFormaPago.ForeColor = System.Drawing.Color.White
        Me.btnFormaPago.Location = New System.Drawing.Point(336, 23)
        Me.btnFormaPago.Name = "btnFormaPago"
        Me.btnFormaPago.Size = New System.Drawing.Size(18, 18)
        Me.btnFormaPago.TabIndex = 20
        Me.btnFormaPago.Text = "..."
        Me.btnFormaPago.UseVisualStyleBackColor = False
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.ForeColor = System.Drawing.Color.White
        Me.Label39.Location = New System.Drawing.Point(257, 24)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(79, 13)
        Me.Label39.TabIndex = 18
        Me.Label39.Text = "Forma de Pago"
        '
        'btnPrecioVenta
        '
        Me.btnPrecioVenta.BackColor = System.Drawing.Color.DimGray
        Me.btnPrecioVenta.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnPrecioVenta.FlatAppearance.BorderSize = 0
        Me.btnPrecioVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrecioVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrecioVenta.ForeColor = System.Drawing.Color.White
        Me.btnPrecioVenta.Location = New System.Drawing.Point(96, 23)
        Me.btnPrecioVenta.Name = "btnPrecioVenta"
        Me.btnPrecioVenta.Size = New System.Drawing.Size(18, 18)
        Me.btnPrecioVenta.TabIndex = 17
        Me.btnPrecioVenta.Text = "..."
        Me.btnPrecioVenta.UseVisualStyleBackColor = False
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.ForeColor = System.Drawing.Color.White
        Me.Label38.Location = New System.Drawing.Point(14, 24)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(83, 13)
        Me.Label38.TabIndex = 15
        Me.Label38.Text = "Precio de Venta"
        '
        'btnBuscaCobrador
        '
        Me.btnBuscaCobrador.BackColor = System.Drawing.Color.DimGray
        Me.btnBuscaCobrador.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnBuscaCobrador.FlatAppearance.BorderSize = 0
        Me.btnBuscaCobrador.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscaCobrador.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscaCobrador.ForeColor = System.Drawing.Color.White
        Me.btnBuscaCobrador.Location = New System.Drawing.Point(337, 53)
        Me.btnBuscaCobrador.Name = "btnBuscaCobrador"
        Me.btnBuscaCobrador.Size = New System.Drawing.Size(18, 18)
        Me.btnBuscaCobrador.TabIndex = 14
        Me.btnBuscaCobrador.Text = "..."
        Me.btnBuscaCobrador.UseVisualStyleBackColor = False
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.ForeColor = System.Drawing.Color.White
        Me.Label37.Location = New System.Drawing.Point(278, 55)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(50, 13)
        Me.Label37.TabIndex = 12
        Me.Label37.Text = "Cobrador"
        '
        'btnBuscaZonaCobro
        '
        Me.btnBuscaZonaCobro.BackColor = System.Drawing.Color.DimGray
        Me.btnBuscaZonaCobro.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnBuscaZonaCobro.FlatAppearance.BorderSize = 0
        Me.btnBuscaZonaCobro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscaZonaCobro.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscaZonaCobro.ForeColor = System.Drawing.Color.White
        Me.btnBuscaZonaCobro.Location = New System.Drawing.Point(105, 51)
        Me.btnBuscaZonaCobro.Name = "btnBuscaZonaCobro"
        Me.btnBuscaZonaCobro.Size = New System.Drawing.Size(18, 18)
        Me.btnBuscaZonaCobro.TabIndex = 11
        Me.btnBuscaZonaCobro.Text = "..."
        Me.btnBuscaZonaCobro.UseVisualStyleBackColor = False
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.ForeColor = System.Drawing.Color.White
        Me.Label36.Location = New System.Drawing.Point(2, 55)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(100, 13)
        Me.Label36.TabIndex = 9
        Me.Label36.Text = "Zona de Cobranzas"
        '
        'btnBuscaVendedor
        '
        Me.btnBuscaVendedor.BackColor = System.Drawing.Color.DimGray
        Me.btnBuscaVendedor.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnBuscaVendedor.FlatAppearance.BorderSize = 0
        Me.btnBuscaVendedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscaVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscaVendedor.ForeColor = System.Drawing.Color.White
        Me.btnBuscaVendedor.Location = New System.Drawing.Point(337, 32)
        Me.btnBuscaVendedor.Name = "btnBuscaVendedor"
        Me.btnBuscaVendedor.Size = New System.Drawing.Size(18, 18)
        Me.btnBuscaVendedor.TabIndex = 8
        Me.btnBuscaVendedor.Text = "..."
        Me.btnBuscaVendedor.UseVisualStyleBackColor = False
        '
        'malla
        '
        Me.malla.AllowUserToResizeRows = False
        Me.malla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.malla.BackgroundColor = System.Drawing.Color.White
        Me.malla.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.malla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.malla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.malla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Nro, Me.CedulaId, Me.Nombres, Me.Parentesco, Me.FechaNacim, Me.Sexo1, Me.EstadoCivil, Me.Direccion, Me.Teléfono_1, Me.Teléfono_2, Me.Ocupación, Me.Depend, Me.Minusv})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.malla.DefaultCellStyle = DataGridViewCellStyle2
        Me.malla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.malla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.malla.EnableHeadersVisualStyles = False
        Me.malla.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.malla.Location = New System.Drawing.Point(0, 0)
        Me.malla.Name = "malla"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.malla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.malla.RowHeadersWidth = 50
        Me.malla.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.malla.Size = New System.Drawing.Size(867, 404)
        Me.malla.TabIndex = 0
        '
        'Nro
        '
        Me.Nro.HeaderText = "Nro."
        Me.Nro.Name = "Nro"
        Me.Nro.Width = 52
        '
        'CedulaId
        '
        Me.CedulaId.HeaderText = "Celuda Id."
        Me.CedulaId.Name = "CedulaId"
        Me.CedulaId.Width = 80
        '
        'Nombres
        '
        Me.Nombres.HeaderText = "Nombres"
        Me.Nombres.Name = "Nombres"
        Me.Nombres.Width = 74
        '
        'Parentesco
        '
        Me.Parentesco.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.Parentesco.HeaderText = "Parentesco"
        Me.Parentesco.Items.AddRange(New Object() {"Conyuge", "Hijo", "Hija", "Papá", "Mamá", "Hermano", "Hermana", "Suegro", "Suegra", "Tío", "Tía", "Primo", "Prima", "Cuñado", "Cuñada"})
        Me.Parentesco.Name = "Parentesco"
        Me.Parentesco.Width = 67
        '
        'FechaNacim
        '
        Me.FechaNacim.HeaderText = "FechaNacim."
        Me.FechaNacim.Name = "FechaNacim"
        Me.FechaNacim.Width = 95
        '
        'Sexo1
        '
        Me.Sexo1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.Sexo1.HeaderText = "Sexo"
        Me.Sexo1.Items.AddRange(New Object() {"Masculino", "Femenino"})
        Me.Sexo1.Name = "Sexo1"
        Me.Sexo1.Width = 39
        '
        'EstadoCivil
        '
        Me.EstadoCivil.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.EstadoCivil.HeaderText = "EstadoCivil"
        Me.EstadoCivil.Items.AddRange(New Object() {"Soltero/a", "Casado/a", "Divorciado/a", "Viudo/a", "Unión Libre"})
        Me.EstadoCivil.Name = "EstadoCivil"
        Me.EstadoCivil.Width = 65
        '
        'Direccion
        '
        Me.Direccion.HeaderText = "Direccion"
        Me.Direccion.Name = "Direccion"
        Me.Direccion.Width = 77
        '
        'Teléfono_1
        '
        Me.Teléfono_1.HeaderText = "Teléfono_1"
        Me.Teléfono_1.Name = "Teléfono_1"
        Me.Teléfono_1.Width = 86
        '
        'Teléfono_2
        '
        Me.Teléfono_2.HeaderText = "Teléfono_2"
        Me.Teléfono_2.Name = "Teléfono_2"
        Me.Teléfono_2.Width = 86
        '
        'Ocupación
        '
        Me.Ocupación.HeaderText = "Ocupación"
        Me.Ocupación.Name = "Ocupación"
        Me.Ocupación.Width = 84
        '
        'Depend
        '
        Me.Depend.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.Depend.HeaderText = "Depend."
        Me.Depend.Items.AddRange(New Object() {"Si", "No"})
        Me.Depend.Name = "Depend"
        Me.Depend.Width = 54
        '
        'Minusv
        '
        Me.Minusv.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.Minusv.HeaderText = "Discapac."
        Me.Minusv.Items.AddRange(New Object() {"Si", "No"})
        Me.Minusv.Name = "Minusv"
        Me.Minusv.Width = 61
        '
        'tabFamiliares
        '
        Me.tabFamiliares.BackColor = System.Drawing.Color.AliceBlue
        Me.tabFamiliares.Controls.Add(Me.malla)
        Me.tabFamiliares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabFamiliares.Location = New System.Drawing.Point(4, 28)
        Me.tabFamiliares.Name = "tabFamiliares"
        Me.tabFamiliares.Size = New System.Drawing.Size(867, 404)
        Me.tabFamiliares.TabIndex = 8
        Me.tabFamiliares.Text = "Familiares"
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.SteelBlue
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(581, 212)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(243, 26)
        Me.Button4.TabIndex = 95
        Me.Button4.Text = "Imprimir hoja de datos"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'txtHistoriaclinica
        '
        Me.txtHistoriaclinica.Location = New System.Drawing.Point(594, 2)
        Me.txtHistoriaclinica.Name = "txtHistoriaclinica"
        Me.txtHistoriaclinica.Size = New System.Drawing.Size(106, 20)
        Me.txtHistoriaclinica.TabIndex = 93
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Location = New System.Drawing.Point(531, 6)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(61, 13)
        Me.Label79.TabIndex = 94
        Me.Label79.Text = "Hist.Clínica"
        '
        'Apellidos
        '
        Me.Apellidos.Location = New System.Drawing.Point(371, 27)
        Me.Apellidos.Name = "Apellidos"
        Me.Apellidos.Size = New System.Drawing.Size(329, 20)
        Me.Apellidos.TabIndex = 4
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(319, 28)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(49, 13)
        Me.Label32.TabIndex = 84
        Me.Label32.Text = "Apellidos"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(8, 57)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(93, 13)
        Me.Label20.TabIndex = 83
        Me.Label20.Text = "Correo electrónico"
        '
        'TxtData9
        '
        Me.TxtData9.Location = New System.Drawing.Point(75, 97)
        Me.TxtData9.Name = "TxtData9"
        Me.TxtData9.Size = New System.Drawing.Size(389, 20)
        Me.TxtData9.TabIndex = 20
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(8, 100)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(66, 13)
        Me.Label19.TabIndex = 80
        Me.Label19.Text = "Página Web"
        '
        'TxtData8
        '
        Me.TxtData8.Location = New System.Drawing.Point(116, 51)
        Me.TxtData8.Name = "TxtData8"
        Me.TxtData8.Size = New System.Drawing.Size(437, 20)
        Me.TxtData8.TabIndex = 19
        '
        'TxtData6
        '
        Me.TxtData6.Location = New System.Drawing.Point(116, 74)
        Me.TxtData6.Name = "TxtData6"
        Me.TxtData6.Size = New System.Drawing.Size(436, 20)
        Me.TxtData6.TabIndex = 18
        '
        'label17
        '
        Me.label17.AutoSize = True
        Me.label17.BackColor = System.Drawing.Color.Transparent
        Me.label17.ForeColor = System.Drawing.Color.White
        Me.label17.Location = New System.Drawing.Point(6, 78)
        Me.label17.Name = "label17"
        Me.label17.Size = New System.Drawing.Size(105, 13)
        Me.label17.TabIndex = 76
        Me.label17.Text = "Correo electrónico_2"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(7, 48)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(52, 13)
        Me.Label16.TabIndex = 74
        Me.Label16.Text = "Parroquia"
        '
        'txtTelefono3
        '
        Me.txtTelefono3.Location = New System.Drawing.Point(324, 29)
        Me.txtTelefono3.Name = "txtTelefono3"
        Me.txtTelefono3.Size = New System.Drawing.Size(115, 20)
        Me.txtTelefono3.TabIndex = 16
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(279, 33)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 13)
        Me.Label15.TabIndex = 72
        Me.Label15.Text = "Telef-3"
        '
        'txtTelefono2
        '
        Me.txtTelefono2.Location = New System.Drawing.Point(184, 28)
        Me.txtTelefono2.Name = "txtTelefono2"
        Me.txtTelefono2.Size = New System.Drawing.Size(89, 20)
        Me.txtTelefono2.TabIndex = 15
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(139, 32)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 13)
        Me.Label14.TabIndex = 70
        Me.Label14.Text = "Telef-2"
        '
        'txtTelefono1
        '
        Me.txtTelefono1.Location = New System.Drawing.Point(53, 28)
        Me.txtTelefono1.Name = "txtTelefono1"
        Me.txtTelefono1.Size = New System.Drawing.Size(81, 20)
        Me.txtTelefono1.TabIndex = 14
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(8, 32)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 13)
        Me.Label13.TabIndex = 68
        Me.Label13.Text = "Telef-1"
        '
        'TxtNroDomicilio
        '
        Me.TxtNroDomicilio.ForeColor = System.Drawing.Color.Black
        Me.TxtNroDomicilio.Location = New System.Drawing.Point(344, 99)
        Me.TxtNroDomicilio.Name = "TxtNroDomicilio"
        Me.TxtNroDomicilio.Size = New System.Drawing.Size(90, 20)
        Me.TxtNroDomicilio.TabIndex = 13
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(316, 103)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(24, 13)
        Me.Label12.TabIndex = 66
        Me.Label12.Text = "No."
        '
        'txtnomDireccion
        '
        Me.txtnomDireccion.ForeColor = System.Drawing.Color.Black
        Me.txtnomDireccion.Location = New System.Drawing.Point(62, 99)
        Me.txtnomDireccion.Name = "txtnomDireccion"
        Me.txtnomDireccion.Size = New System.Drawing.Size(240, 20)
        Me.txtnomDireccion.TabIndex = 12
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(8, 102)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 13)
        Me.Label11.TabIndex = 64
        Me.Label11.Text = "Dirección"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(295, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 13)
        Me.Label10.TabIndex = 62
        Me.Label10.Text = "Canton"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(18, 75)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 59
        Me.Label9.Text = "Ciudad"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(285, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 56
        Me.Label8.Text = "Provincia"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(30, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 53
        Me.Label7.Text = "País"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 38)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.DimGray
        Me.SplitContainer1.Panel1Collapsed = True
        Me.SplitContainer1.Panel1MinSize = 0
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DatosDirectorio)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1012, 485)
        Me.SplitContainer1.SplitterDistance = 25
        Me.SplitContainer1.TabIndex = 3
        '
        'DatosDirectorio
        '
        Me.DatosDirectorio.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.DatosDirectorio.Controls.Add(Me.tabIdentificación)
        Me.DatosDirectorio.Controls.Add(Me.tabDatosPer)
        Me.DatosDirectorio.Controls.Add(Me.tabCliente)
        Me.DatosDirectorio.Controls.Add(Me.tabFamiliares)
        Me.DatosDirectorio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DatosDirectorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatosDirectorio.Location = New System.Drawing.Point(0, 49)
        Me.DatosDirectorio.Name = "DatosDirectorio"
        Me.DatosDirectorio.SelectedIndex = 0
        Me.DatosDirectorio.Size = New System.Drawing.Size(1012, 436)
        Me.DatosDirectorio.TabIndex = 0
        '
        'tabIdentificación
        '
        Me.tabIdentificación.BackColor = System.Drawing.Color.Gray
        Me.tabIdentificación.Controls.Add(Me.GroupBox13)
        Me.tabIdentificación.Controls.Add(Me.GroupBox5)
        Me.tabIdentificación.Controls.Add(Me.Button4)
        Me.tabIdentificación.Controls.Add(Me.Label20)
        Me.tabIdentificación.Controls.Add(Me.foto)
        Me.tabIdentificación.Controls.Add(Me.TxtData9)
        Me.tabIdentificación.Controls.Add(Me.Label19)
        Me.tabIdentificación.Controls.Add(Me.TxtData8)
        Me.tabIdentificación.Controls.Add(Me.TxtData6)
        Me.tabIdentificación.Controls.Add(Me.txtTelefono3)
        Me.tabIdentificación.Controls.Add(Me.Label15)
        Me.tabIdentificación.Controls.Add(Me.txtTelefono2)
        Me.tabIdentificación.Controls.Add(Me.Label14)
        Me.tabIdentificación.Controls.Add(Me.txtTelefono1)
        Me.tabIdentificación.Controls.Add(Me.Label13)
        Me.tabIdentificación.Controls.Add(Me.Label6)
        Me.tabIdentificación.Controls.Add(Me.impresion)
        Me.tabIdentificación.Controls.Add(Me.Label5)
        Me.tabIdentificación.Controls.Add(Me.label17)
        Me.tabIdentificación.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabIdentificación.ForeColor = System.Drawing.Color.White
        Me.tabIdentificación.Location = New System.Drawing.Point(4, 28)
        Me.tabIdentificación.Name = "tabIdentificación"
        Me.tabIdentificación.Size = New System.Drawing.Size(1004, 404)
        Me.tabIdentificación.TabIndex = 7
        Me.tabIdentificación.Text = "Identificación"
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.cmbRegionDomicilio)
        Me.GroupBox13.Controls.Add(Me.cmbCantonDomicilio)
        Me.GroupBox13.Controls.Add(Me.cmbCiudadDomicilio)
        Me.GroupBox13.Controls.Add(Me.cmbParroquiaDomicilio)
        Me.GroupBox13.Controls.Add(Me.cmbProvinciaDomicilio)
        Me.GroupBox13.Controls.Add(Me.cmbPaisDomicilio)
        Me.GroupBox13.Controls.Add(Me.txtSector)
        Me.GroupBox13.Controls.Add(Me.Label18)
        Me.GroupBox13.Controls.Add(Me.TxtNroDomicilio)
        Me.GroupBox13.Controls.Add(Me.Label12)
        Me.GroupBox13.Controls.Add(Me.txtnomDireccion)
        Me.GroupBox13.Controls.Add(Me.Label11)
        Me.GroupBox13.Controls.Add(Me.Label88)
        Me.GroupBox13.Controls.Add(Me.Label16)
        Me.GroupBox13.Controls.Add(Me.Label10)
        Me.GroupBox13.Controls.Add(Me.Label9)
        Me.GroupBox13.Controls.Add(Me.Label8)
        Me.GroupBox13.Controls.Add(Me.Label7)
        Me.GroupBox13.ForeColor = System.Drawing.Color.Black
        Me.GroupBox13.Location = New System.Drawing.Point(11, 244)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(547, 152)
        Me.GroupBox13.TabIndex = 101
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "Ubicación domiciliaria "
        '
        'cmbRegionDomicilio
        '
        Me.cmbRegionDomicilio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbRegionDomicilio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbRegionDomicilio.ForeColor = System.Drawing.Color.Black
        Me.cmbRegionDomicilio.FormattingEnabled = True
        Me.cmbRegionDomicilio.Items.AddRange(New Object() {"Soltero", "Unión Libre", "Casado", "Divorciado", "Viudo"})
        Me.cmbRegionDomicilio.Location = New System.Drawing.Point(338, 72)
        Me.cmbRegionDomicilio.Name = "cmbRegionDomicilio"
        Me.cmbRegionDomicilio.Size = New System.Drawing.Size(202, 21)
        Me.cmbRegionDomicilio.TabIndex = 115
        '
        'cmbCantonDomicilio
        '
        Me.cmbCantonDomicilio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbCantonDomicilio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCantonDomicilio.ForeColor = System.Drawing.Color.Black
        Me.cmbCantonDomicilio.FormattingEnabled = True
        Me.cmbCantonDomicilio.Items.AddRange(New Object() {"Soltero", "Unión Libre", "Casado", "Divorciado", "Viudo"})
        Me.cmbCantonDomicilio.Location = New System.Drawing.Point(338, 44)
        Me.cmbCantonDomicilio.Name = "cmbCantonDomicilio"
        Me.cmbCantonDomicilio.Size = New System.Drawing.Size(202, 21)
        Me.cmbCantonDomicilio.TabIndex = 114
        '
        'cmbCiudadDomicilio
        '
        Me.cmbCiudadDomicilio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbCiudadDomicilio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCiudadDomicilio.ForeColor = System.Drawing.Color.Black
        Me.cmbCiudadDomicilio.FormattingEnabled = True
        Me.cmbCiudadDomicilio.Items.AddRange(New Object() {"Soltero", "Unión Libre", "Casado", "Divorciado", "Viudo"})
        Me.cmbCiudadDomicilio.Location = New System.Drawing.Point(62, 71)
        Me.cmbCiudadDomicilio.Name = "cmbCiudadDomicilio"
        Me.cmbCiudadDomicilio.Size = New System.Drawing.Size(202, 21)
        Me.cmbCiudadDomicilio.TabIndex = 113
        '
        'cmbParroquiaDomicilio
        '
        Me.cmbParroquiaDomicilio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbParroquiaDomicilio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbParroquiaDomicilio.ForeColor = System.Drawing.Color.Black
        Me.cmbParroquiaDomicilio.FormattingEnabled = True
        Me.cmbParroquiaDomicilio.Location = New System.Drawing.Point(62, 44)
        Me.cmbParroquiaDomicilio.Name = "cmbParroquiaDomicilio"
        Me.cmbParroquiaDomicilio.Size = New System.Drawing.Size(202, 21)
        Me.cmbParroquiaDomicilio.TabIndex = 112
        '
        'cmbProvinciaDomicilio
        '
        Me.cmbProvinciaDomicilio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbProvinciaDomicilio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbProvinciaDomicilio.ForeColor = System.Drawing.Color.Black
        Me.cmbProvinciaDomicilio.FormattingEnabled = True
        Me.cmbProvinciaDomicilio.Items.AddRange(New Object() {"Soltero", "Unión Libre", "Casado", "Divorciado", "Viudo"})
        Me.cmbProvinciaDomicilio.Location = New System.Drawing.Point(338, 17)
        Me.cmbProvinciaDomicilio.Name = "cmbProvinciaDomicilio"
        Me.cmbProvinciaDomicilio.Size = New System.Drawing.Size(202, 21)
        Me.cmbProvinciaDomicilio.TabIndex = 111
        '
        'cmbPaisDomicilio
        '
        Me.cmbPaisDomicilio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbPaisDomicilio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPaisDomicilio.ForeColor = System.Drawing.Color.Black
        Me.cmbPaisDomicilio.FormattingEnabled = True
        Me.cmbPaisDomicilio.Items.AddRange(New Object() {"Soltero", "Unión Libre", "Casado", "Divorciado", "Viudo"})
        Me.cmbPaisDomicilio.Location = New System.Drawing.Point(62, 17)
        Me.cmbPaisDomicilio.Name = "cmbPaisDomicilio"
        Me.cmbPaisDomicilio.Size = New System.Drawing.Size(202, 21)
        Me.cmbPaisDomicilio.TabIndex = 110
        '
        'txtSector
        '
        Me.txtSector.ForeColor = System.Drawing.Color.Black
        Me.txtSector.Location = New System.Drawing.Point(61, 124)
        Me.txtSector.Name = "txtSector"
        Me.txtSector.Size = New System.Drawing.Size(241, 20)
        Me.txtSector.TabIndex = 99
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(21, 127)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(38, 13)
        Me.Label18.TabIndex = 100
        Me.Label18.Text = "Sector"
        '
        'Label88
        '
        Me.Label88.AutoSize = True
        Me.Label88.BackColor = System.Drawing.Color.Transparent
        Me.Label88.ForeColor = System.Drawing.Color.White
        Me.Label88.Location = New System.Drawing.Point(295, 76)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(41, 13)
        Me.Label88.TabIndex = 102
        Me.Label88.Text = "Región"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chkRegimenMicroempresas)
        Me.GroupBox5.Controls.Add(Me.TxtResolucionAR)
        Me.GroupBox5.Controls.Add(Me.Label82)
        Me.GroupBox5.Controls.Add(Me.txtContribuyenteEspecial)
        Me.GroupBox5.Controls.Add(Me.Label83)
        Me.GroupBox5.Controls.Add(Me.chkRise)
        Me.GroupBox5.Controls.Add(Me.chkObligaContabilidad)
        Me.GroupBox5.Controls.Add(Me.ExoneradoIva)
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(11, 127)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(547, 111)
        Me.GroupBox5.TabIndex = 98
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Características fiscales"
        '
        'chkRegimenMicroempresas
        '
        Me.chkRegimenMicroempresas.AutoSize = True
        Me.chkRegimenMicroempresas.BackColor = System.Drawing.Color.Transparent
        Me.chkRegimenMicroempresas.ForeColor = System.Drawing.Color.White
        Me.chkRegimenMicroempresas.Location = New System.Drawing.Point(284, 45)
        Me.chkRegimenMicroempresas.Name = "chkRegimenMicroempresas"
        Me.chkRegimenMicroempresas.Size = New System.Drawing.Size(199, 17)
        Me.chkRegimenMicroempresas.TabIndex = 33
        Me.chkRegimenMicroempresas.Text = "Pertenece al régimen microempresas"
        Me.chkRegimenMicroempresas.UseVisualStyleBackColor = False
        '
        'TxtResolucionAR
        '
        Me.TxtResolucionAR.ForeColor = System.Drawing.Color.Black
        Me.TxtResolucionAR.Location = New System.Drawing.Point(250, 81)
        Me.TxtResolucionAR.Name = "TxtResolucionAR"
        Me.TxtResolucionAR.Size = New System.Drawing.Size(178, 20)
        Me.TxtResolucionAR.TabIndex = 32
        '
        'Label82
        '
        Me.Label82.AutoSize = True
        Me.Label82.BackColor = System.Drawing.Color.Transparent
        Me.Label82.ForeColor = System.Drawing.Color.White
        Me.Label82.Location = New System.Drawing.Point(247, 69)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(178, 13)
        Me.Label82.TabIndex = 31
        Me.Label82.Text = "Nro. Resolución Agente Retención :"
        '
        'txtContribuyenteEspecial
        '
        Me.txtContribuyenteEspecial.ForeColor = System.Drawing.Color.Black
        Me.txtContribuyenteEspecial.Location = New System.Drawing.Point(15, 81)
        Me.txtContribuyenteEspecial.Name = "txtContribuyenteEspecial"
        Me.txtContribuyenteEspecial.Size = New System.Drawing.Size(162, 20)
        Me.txtContribuyenteEspecial.TabIndex = 30
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.BackColor = System.Drawing.Color.Transparent
        Me.Label83.ForeColor = System.Drawing.Color.White
        Me.Label83.Location = New System.Drawing.Point(15, 68)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(132, 13)
        Me.Label83.TabIndex = 29
        Me.Label83.Text = "NroContribuyenteEspecial:"
        '
        'chkRise
        '
        Me.chkRise.AutoSize = True
        Me.chkRise.BackColor = System.Drawing.Color.Transparent
        Me.chkRise.ForeColor = System.Drawing.Color.White
        Me.chkRise.Location = New System.Drawing.Point(18, 45)
        Me.chkRise.Name = "chkRise"
        Me.chkRise.Size = New System.Drawing.Size(232, 17)
        Me.chkRise.TabIndex = 5
        Me.chkRise.Text = "Pertenece al régimen impositivo simplificado"
        Me.chkRise.UseVisualStyleBackColor = False
        '
        'chkObligaContabilidad
        '
        Me.chkObligaContabilidad.AutoSize = True
        Me.chkObligaContabilidad.BackColor = System.Drawing.Color.Transparent
        Me.chkObligaContabilidad.ForeColor = System.Drawing.Color.White
        Me.chkObligaContabilidad.Location = New System.Drawing.Point(284, 22)
        Me.chkObligaContabilidad.Name = "chkObligaContabilidad"
        Me.chkObligaContabilidad.Size = New System.Drawing.Size(165, 17)
        Me.chkObligaContabilidad.TabIndex = 4
        Me.chkObligaContabilidad.Text = "Obligado a llevar contabilidad"
        Me.chkObligaContabilidad.UseVisualStyleBackColor = False
        '
        'ExoneradoIva
        '
        Me.ExoneradoIva.AutoSize = True
        Me.ExoneradoIva.BackColor = System.Drawing.Color.Transparent
        Me.ExoneradoIva.ForeColor = System.Drawing.Color.White
        Me.ExoneradoIva.Location = New System.Drawing.Point(19, 22)
        Me.ExoneradoIva.Name = "ExoneradoIva"
        Me.ExoneradoIva.Size = New System.Drawing.Size(158, 17)
        Me.ExoneradoIva.TabIndex = 3
        Me.ExoneradoIva.Text = "Exonerado del pago del IVA"
        Me.ExoneradoIva.UseVisualStyleBackColor = False
        '
        'foto
        '
        Me.foto.BackColor = System.Drawing.Color.White
        Me.foto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.foto.InitialImage = Global.DaxMantDirectorio.My.Resources.Resources._025
        Me.foto.Location = New System.Drawing.Point(581, 8)
        Me.foto.Name = "foto"
        Me.foto.Size = New System.Drawing.Size(243, 203)
        Me.foto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.foto.TabIndex = 82
        Me.foto.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(6, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "Impresión"
        '
        'impresion
        '
        Me.impresion.Location = New System.Drawing.Point(73, 7)
        Me.impresion.Name = "impresion"
        Me.impresion.Size = New System.Drawing.Size(481, 20)
        Me.impresion.TabIndex = 51
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "Nombres de"
        '
        'tabDatosPer
        '
        Me.tabDatosPer.BackColor = System.Drawing.Color.Gray
        Me.tabDatosPer.Controls.Add(Me.cmbEspecialidad2)
        Me.tabDatosPer.Controls.Add(Me.cmbEspecialidad)
        Me.tabDatosPer.Controls.Add(Me.cmbProfesion)
        Me.tabDatosPer.Controls.Add(Me.cmbNacionalidadPersonal)
        Me.tabDatosPer.Controls.Add(Me.cmbTipoSangre)
        Me.tabDatosPer.Controls.Add(Me.Label93)
        Me.tabDatosPer.Controls.Add(Me.Label89)
        Me.tabDatosPer.Controls.Add(Me.txtPorcDiscapacidad)
        Me.tabDatosPer.Controls.Add(Me.Label91)
        Me.tabDatosPer.Controls.Add(Me.txtDiscapacidad)
        Me.tabDatosPer.Controls.Add(Me.GroupBox12)
        Me.tabDatosPer.Controls.Add(Me.Label80)
        Me.tabDatosPer.Controls.Add(Me.Label77)
        Me.tabDatosPer.Controls.Add(Me.asociadoa)
        Me.tabDatosPer.Controls.Add(Me.Label31)
        Me.tabDatosPer.Controls.Add(Me.txtLugTra)
        Me.tabDatosPer.Controls.Add(Me.Label30)
        Me.tabDatosPer.Controls.Add(Me.txtNumTar)
        Me.tabDatosPer.Controls.Add(Me.Label29)
        Me.tabDatosPer.Controls.Add(Me.Label24)
        Me.tabDatosPer.Controls.Add(Me.txtCodTar)
        Me.tabDatosPer.Controls.Add(Me.hobbys)
        Me.tabDatosPer.Controls.Add(Me.Label27)
        Me.tabDatosPer.Controls.Add(Me.txtReferirseComo)
        Me.tabDatosPer.Controls.Add(Me.Label26)
        Me.tabDatosPer.Controls.Add(Me.Label25)
        Me.tabDatosPer.Controls.Add(Me.cmbEstadoCivil)
        Me.tabDatosPer.Controls.Add(Me.Label21)
        Me.tabDatosPer.Controls.Add(Me.GroupBox4)
        Me.tabDatosPer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabDatosPer.Location = New System.Drawing.Point(4, 28)
        Me.tabDatosPer.Name = "tabDatosPer"
        Me.tabDatosPer.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDatosPer.Size = New System.Drawing.Size(867, 404)
        Me.tabDatosPer.TabIndex = 0
        Me.tabDatosPer.Text = "Datos Personales"
        '
        'cmbEspecialidad2
        '
        Me.cmbEspecialidad2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbEspecialidad2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbEspecialidad2.ForeColor = System.Drawing.Color.Black
        Me.cmbEspecialidad2.FormattingEnabled = True
        Me.cmbEspecialidad2.Items.AddRange(New Object() {"Soltero", "Unión Libre", "Casado", "Divorciado", "Viudo"})
        Me.cmbEspecialidad2.Location = New System.Drawing.Point(489, 186)
        Me.cmbEspecialidad2.Name = "cmbEspecialidad2"
        Me.cmbEspecialidad2.Size = New System.Drawing.Size(303, 21)
        Me.cmbEspecialidad2.TabIndex = 116
        '
        'cmbEspecialidad
        '
        Me.cmbEspecialidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbEspecialidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbEspecialidad.ForeColor = System.Drawing.Color.Black
        Me.cmbEspecialidad.FormattingEnabled = True
        Me.cmbEspecialidad.Items.AddRange(New Object() {"Soltero", "Unión Libre", "Casado", "Divorciado", "Viudo"})
        Me.cmbEspecialidad.Location = New System.Drawing.Point(94, 186)
        Me.cmbEspecialidad.Name = "cmbEspecialidad"
        Me.cmbEspecialidad.Size = New System.Drawing.Size(292, 21)
        Me.cmbEspecialidad.TabIndex = 115
        '
        'cmbProfesion
        '
        Me.cmbProfesion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbProfesion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbProfesion.ForeColor = System.Drawing.Color.Black
        Me.cmbProfesion.FormattingEnabled = True
        Me.cmbProfesion.Items.AddRange(New Object() {"Soltero", "Unión Libre", "Casado", "Divorciado", "Viudo"})
        Me.cmbProfesion.Location = New System.Drawing.Point(68, 161)
        Me.cmbProfesion.Name = "cmbProfesion"
        Me.cmbProfesion.Size = New System.Drawing.Size(319, 21)
        Me.cmbProfesion.TabIndex = 114
        '
        'cmbNacionalidadPersonal
        '
        Me.cmbNacionalidadPersonal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbNacionalidadPersonal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbNacionalidadPersonal.ForeColor = System.Drawing.Color.Black
        Me.cmbNacionalidadPersonal.FormattingEnabled = True
        Me.cmbNacionalidadPersonal.Items.AddRange(New Object() {"Soltero", "Unión Libre", "Casado", "Divorciado", "Viudo"})
        Me.cmbNacionalidadPersonal.Location = New System.Drawing.Point(658, 35)
        Me.cmbNacionalidadPersonal.Name = "cmbNacionalidadPersonal"
        Me.cmbNacionalidadPersonal.Size = New System.Drawing.Size(134, 21)
        Me.cmbNacionalidadPersonal.TabIndex = 81
        '
        'cmbTipoSangre
        '
        Me.cmbTipoSangre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbTipoSangre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTipoSangre.ForeColor = System.Drawing.Color.Black
        Me.cmbTipoSangre.FormattingEnabled = True
        Me.cmbTipoSangre.Items.AddRange(New Object() {"A RH+", "A RH-", "B RH+", "B RH-", "AB RH+", "AB RH-", "O RH+", "O RH-"})
        Me.cmbTipoSangre.Location = New System.Drawing.Point(291, 36)
        Me.cmbTipoSangre.Name = "cmbTipoSangre"
        Me.cmbTipoSangre.Size = New System.Drawing.Size(68, 21)
        Me.cmbTipoSangre.TabIndex = 80
        '
        'Label93
        '
        Me.Label93.AutoSize = True
        Me.Label93.ForeColor = System.Drawing.Color.White
        Me.Label93.Location = New System.Drawing.Point(407, 189)
        Me.Label93.Name = "Label93"
        Me.Label93.Size = New System.Drawing.Size(76, 13)
        Me.Label93.TabIndex = 77
        Me.Label93.Text = "Especialidad 2"
        '
        'Label89
        '
        Me.Label89.AutoSize = True
        Me.Label89.ForeColor = System.Drawing.Color.White
        Me.Label89.Location = New System.Drawing.Point(18, 298)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(72, 13)
        Me.Label89.TabIndex = 76
        Me.Label89.Text = "Discapacidad"
        '
        'txtPorcDiscapacidad
        '
        Me.txtPorcDiscapacidad.Location = New System.Drawing.Point(386, 296)
        Me.txtPorcDiscapacidad.Name = "txtPorcDiscapacidad"
        Me.txtPorcDiscapacidad.Size = New System.Drawing.Size(52, 20)
        Me.txtPorcDiscapacidad.TabIndex = 74
        '
        'Label91
        '
        Me.Label91.AutoSize = True
        Me.Label91.ForeColor = System.Drawing.Color.White
        Me.Label91.Location = New System.Drawing.Point(253, 298)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(126, 13)
        Me.Label91.TabIndex = 75
        Me.Label91.Text = "Porcentaje Discapacidad"
        '
        'txtDiscapacidad
        '
        Me.txtDiscapacidad.Location = New System.Drawing.Point(100, 295)
        Me.txtDiscapacidad.Name = "txtDiscapacidad"
        Me.txtDiscapacidad.Size = New System.Drawing.Size(134, 20)
        Me.txtDiscapacidad.TabIndex = 73
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.cmbRegionNace)
        Me.GroupBox12.Controls.Add(Me.cmbCiudadNace)
        Me.GroupBox12.Controls.Add(Me.cmbProvinciaNace)
        Me.GroupBox12.Controls.Add(Me.cmbPaisNace)
        Me.GroupBox12.Controls.Add(Me.fechanaci)
        Me.GroupBox12.Controls.Add(Me.Label28)
        Me.GroupBox12.Controls.Add(Me.Label84)
        Me.GroupBox12.Controls.Add(Me.Label85)
        Me.GroupBox12.Controls.Add(Me.Label86)
        Me.GroupBox12.Controls.Add(Me.Lugarnaci)
        Me.GroupBox12.Controls.Add(Me.Label23)
        Me.GroupBox12.Controls.Add(Me.Label22)
        Me.GroupBox12.ForeColor = System.Drawing.Color.Black
        Me.GroupBox12.Location = New System.Drawing.Point(13, 64)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(810, 83)
        Me.GroupBox12.TabIndex = 69
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Nacimiento :"
        '
        'cmbRegionNace
        '
        Me.cmbRegionNace.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbRegionNace.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbRegionNace.ForeColor = System.Drawing.Color.Black
        Me.cmbRegionNace.FormattingEnabled = True
        Me.cmbRegionNace.Items.AddRange(New Object() {"Soltero", "Unión Libre", "Casado", "Divorciado", "Viudo"})
        Me.cmbRegionNace.Location = New System.Drawing.Point(282, 46)
        Me.cmbRegionNace.Name = "cmbRegionNace"
        Me.cmbRegionNace.Size = New System.Drawing.Size(171, 21)
        Me.cmbRegionNace.TabIndex = 114
        '
        'cmbCiudadNace
        '
        Me.cmbCiudadNace.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbCiudadNace.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCiudadNace.ForeColor = System.Drawing.Color.Black
        Me.cmbCiudadNace.FormattingEnabled = True
        Me.cmbCiudadNace.Items.AddRange(New Object() {"Soltero", "Unión Libre", "Casado", "Divorciado", "Viudo"})
        Me.cmbCiudadNace.Location = New System.Drawing.Point(48, 47)
        Me.cmbCiudadNace.Name = "cmbCiudadNace"
        Me.cmbCiudadNace.Size = New System.Drawing.Size(184, 21)
        Me.cmbCiudadNace.TabIndex = 113
        '
        'cmbProvinciaNace
        '
        Me.cmbProvinciaNace.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbProvinciaNace.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbProvinciaNace.ForeColor = System.Drawing.Color.Black
        Me.cmbProvinciaNace.FormattingEnabled = True
        Me.cmbProvinciaNace.Items.AddRange(New Object() {"Soltero", "Unión Libre", "Casado", "Divorciado", "Viudo"})
        Me.cmbProvinciaNace.Location = New System.Drawing.Point(431, 15)
        Me.cmbProvinciaNace.Name = "cmbProvinciaNace"
        Me.cmbProvinciaNace.Size = New System.Drawing.Size(195, 21)
        Me.cmbProvinciaNace.TabIndex = 112
        '
        'cmbPaisNace
        '
        Me.cmbPaisNace.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbPaisNace.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPaisNace.ForeColor = System.Drawing.Color.Black
        Me.cmbPaisNace.FormattingEnabled = True
        Me.cmbPaisNace.Items.AddRange(New Object() {"Soltero", "Unión Libre", "Casado", "Divorciado", "Viudo"})
        Me.cmbPaisNace.Location = New System.Drawing.Point(169, 18)
        Me.cmbPaisNace.Name = "cmbPaisNace"
        Me.cmbPaisNace.Size = New System.Drawing.Size(195, 21)
        Me.cmbPaisNace.TabIndex = 111
        '
        'fechanaci
        '
        Me.fechanaci.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fechanaci.Location = New System.Drawing.Point(48, 19)
        Me.fechanaci.Name = "fechanaci"
        Me.fechanaci.Size = New System.Drawing.Size(80, 20)
        Me.fechanaci.TabIndex = 76
        Me.fechanaci.Value = New Date(1900, 1, 1, 0, 0, 0, 0)
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.ForeColor = System.Drawing.Color.White
        Me.Label28.Location = New System.Drawing.Point(238, 54)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(41, 13)
        Me.Label28.TabIndex = 71
        Me.Label28.Text = "Región"
        '
        'Label84
        '
        Me.Label84.AutoSize = True
        Me.Label84.ForeColor = System.Drawing.Color.White
        Me.Label84.Location = New System.Drawing.Point(7, 53)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(40, 13)
        Me.Label84.TabIndex = 68
        Me.Label84.Text = "Ciudad"
        '
        'Label85
        '
        Me.Label85.AutoSize = True
        Me.Label85.ForeColor = System.Drawing.Color.White
        Me.Label85.Location = New System.Drawing.Point(374, 22)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(51, 13)
        Me.Label85.TabIndex = 67
        Me.Label85.Text = "Provincia"
        '
        'Label86
        '
        Me.Label86.AutoSize = True
        Me.Label86.ForeColor = System.Drawing.Color.White
        Me.Label86.Location = New System.Drawing.Point(138, 23)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(29, 13)
        Me.Label86.TabIndex = 66
        Me.Label86.Text = "País"
        '
        'Lugarnaci
        '
        Me.Lugarnaci.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.Lugarnaci.ForeColor = System.Drawing.Color.Black
        Me.Lugarnaci.Location = New System.Drawing.Point(500, 45)
        Me.Lugarnaci.Name = "Lugarnaci"
        Me.Lugarnaci.Size = New System.Drawing.Size(225, 20)
        Me.Lugarnaci.TabIndex = 4
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(459, 49)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(37, 13)
        Me.Label23.TabIndex = 5
        Me.Label23.Text = "Lugar:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(9, 23)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(37, 13)
        Me.Label22.TabIndex = 3
        Me.Label22.Text = "Fecha"
        '
        'Label80
        '
        Me.Label80.AutoSize = True
        Me.Label80.ForeColor = System.Drawing.Color.White
        Me.Label80.Location = New System.Drawing.Point(207, 39)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(80, 13)
        Me.Label80.TabIndex = 27
        Me.Label80.Text = "Tipo de Sangre"
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.ForeColor = System.Drawing.Color.White
        Me.Label77.Location = New System.Drawing.Point(12, 189)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(76, 13)
        Me.Label77.TabIndex = 23
        Me.Label77.Text = "Especialidad 1"
        '
        'asociadoa
        '
        Me.asociadoa.Controls.Add(Me.CbuscaDir3)
        Me.asociadoa.Controls.Add(Me.LDir3)
        Me.asociadoa.ForeColor = System.Drawing.Color.Black
        Me.asociadoa.Location = New System.Drawing.Point(14, 322)
        Me.asociadoa.Name = "asociadoa"
        Me.asociadoa.Size = New System.Drawing.Size(345, 46)
        Me.asociadoa.TabIndex = 2
        Me.asociadoa.TabStop = False
        Me.asociadoa.Text = "Asociado a la Empresa"
        '
        'CbuscaDir3
        '
        Me.CbuscaDir3.BackColor = System.Drawing.Color.DimGray
        Me.CbuscaDir3.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.CbuscaDir3.FlatAppearance.BorderSize = 0
        Me.CbuscaDir3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbuscaDir3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbuscaDir3.ForeColor = System.Drawing.Color.White
        Me.CbuscaDir3.Location = New System.Drawing.Point(13, 18)
        Me.CbuscaDir3.Name = "CbuscaDir3"
        Me.CbuscaDir3.Size = New System.Drawing.Size(20, 20)
        Me.CbuscaDir3.TabIndex = 10
        Me.CbuscaDir3.Text = "..."
        Me.CbuscaDir3.UseVisualStyleBackColor = False
        '
        'LDir3
        '
        Me.LDir3.Location = New System.Drawing.Point(33, 18)
        Me.LDir3.Name = "LDir3"
        Me.LDir3.Size = New System.Drawing.Size(306, 20)
        Me.LDir3.TabIndex = 0
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.ForeColor = System.Drawing.Color.White
        Me.Label31.Location = New System.Drawing.Point(10, 250)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(91, 13)
        Me.Label31.TabIndex = 22
        Me.Label31.Text = "Tarjeta de Credito"
        '
        'txtLugTra
        '
        Me.txtLugTra.Location = New System.Drawing.Point(124, 272)
        Me.txtLugTra.Name = "txtLugTra"
        Me.txtLugTra.Size = New System.Drawing.Size(412, 20)
        Me.txtLugTra.TabIndex = 10
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.ForeColor = System.Drawing.Color.White
        Me.Label30.Location = New System.Drawing.Point(14, 272)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(106, 13)
        Me.Label30.TabIndex = 20
        Me.Label30.Text = "Dirección de Trabajo"
        '
        'txtNumTar
        '
        Me.txtNumTar.Location = New System.Drawing.Point(343, 248)
        Me.txtNumTar.Name = "txtNumTar"
        Me.txtNumTar.Size = New System.Drawing.Size(162, 20)
        Me.txtNumTar.TabIndex = 9
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.Location = New System.Drawing.Point(257, 250)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(80, 13)
        Me.Label29.TabIndex = 18
        Me.Label29.Text = "Número Tarjeta"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(583, 39)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(69, 13)
        Me.Label24.TabIndex = 7
        Me.Label24.Text = "Nacionalidad"
        '
        'txtCodTar
        '
        Me.txtCodTar.Location = New System.Drawing.Point(107, 248)
        Me.txtCodTar.Name = "txtCodTar"
        Me.txtCodTar.Size = New System.Drawing.Size(134, 20)
        Me.txtCodTar.TabIndex = 8
        '
        'hobbys
        '
        Me.hobbys.Location = New System.Drawing.Point(61, 216)
        Me.hobbys.Name = "hobbys"
        Me.hobbys.Size = New System.Drawing.Size(325, 20)
        Me.hobbys.TabIndex = 7
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(12, 218)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(43, 13)
        Me.Label27.TabIndex = 14
        Me.Label27.Text = "Hobbys"
        '
        'txtReferirseComo
        '
        Me.txtReferirseComo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.txtReferirseComo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.txtReferirseComo.FormattingEnabled = True
        Me.txtReferirseComo.Items.AddRange(New Object() {"Sr.", "Sra.", "Srta.", "Ing.", "Dr.", "Dra.", "Arq."})
        Me.txtReferirseComo.Location = New System.Drawing.Point(496, 161)
        Me.txtReferirseComo.Name = "txtReferirseComo"
        Me.txtReferirseComo.Size = New System.Drawing.Size(107, 21)
        Me.txtReferirseComo.TabIndex = 13
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(412, 164)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(78, 13)
        Me.Label26.TabIndex = 12
        Me.Label26.Text = "Referirse como"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(11, 165)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(51, 13)
        Me.Label25.TabIndex = 10
        Me.Label25.Text = "Profesión"
        '
        'cmbEstadoCivil
        '
        Me.cmbEstadoCivil.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbEstadoCivil.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbEstadoCivil.ForeColor = System.Drawing.Color.Black
        Me.cmbEstadoCivil.FormattingEnabled = True
        Me.cmbEstadoCivil.Items.AddRange(New Object() {"Soltero", "Unión Libre", "Casado", "Divorciado", "Viudo"})
        Me.cmbEstadoCivil.Location = New System.Drawing.Point(431, 35)
        Me.cmbEstadoCivil.Name = "cmbEstadoCivil"
        Me.cmbEstadoCivil.Size = New System.Drawing.Size(134, 21)
        Me.cmbEstadoCivil.TabIndex = 1
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(365, 39)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(62, 13)
        Me.Label21.TabIndex = 1
        Me.Label21.Text = "Estado Civil"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.mujer)
        Me.GroupBox4.Controls.Add(Me.hombre)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(15, 19)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(187, 39)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Sexo"
        '
        'mujer
        '
        Me.mujer.AutoSize = True
        Me.mujer.ForeColor = System.Drawing.Color.White
        Me.mujer.Location = New System.Drawing.Point(95, 15)
        Me.mujer.Name = "mujer"
        Me.mujer.Size = New System.Drawing.Size(71, 17)
        Me.mujer.TabIndex = 1
        Me.mujer.Text = "Femenino"
        Me.mujer.UseVisualStyleBackColor = True
        '
        'hombre
        '
        Me.hombre.AutoSize = True
        Me.hombre.Checked = True
        Me.hombre.ForeColor = System.Drawing.Color.White
        Me.hombre.Location = New System.Drawing.Point(16, 15)
        Me.hombre.Name = "hombre"
        Me.hombre.Size = New System.Drawing.Size(73, 17)
        Me.hombre.TabIndex = 0
        Me.hombre.TabStop = True
        Me.hombre.Text = "Masculino"
        Me.hombre.UseVisualStyleBackColor = True
        '
        'tabCliente
        '
        Me.tabCliente.BackColor = System.Drawing.Color.Gray
        Me.tabCliente.Controls.Add(Me.btnBuscaZonaVentas)
        Me.tabCliente.Controls.Add(Me.CBuscador3)
        Me.tabCliente.Controls.Add(Me.txtOperador)
        Me.tabCliente.Controls.Add(Me.btnBuscaOperador)
        Me.tabCliente.Controls.Add(Me.Label90)
        Me.tabCliente.Controls.Add(Me.Cuenta4)
        Me.tabCliente.Controls.Add(Me.Cuenta0)
        Me.tabCliente.Controls.Add(Me.GroupBox15)
        Me.tabCliente.Controls.Add(Me.txtCobrador)
        Me.tabCliente.Controls.Add(Me.txtVendedor)
        Me.tabCliente.Controls.Add(Me.txtZonaCobranzas)
        Me.tabCliente.Controls.Add(Me.txtZonaVentas)
        Me.tabCliente.Controls.Add(Me.txtTipoCliente)
        Me.tabCliente.Controls.Add(Me.GroupBox11)
        Me.tabCliente.Controls.Add(Me.Command5)
        Me.tabCliente.Controls.Add(Me.Label75)
        Me.tabCliente.Controls.Add(Me.Command1)
        Me.tabCliente.Controls.Add(Me.Label45)
        Me.tabCliente.Controls.Add(Me.observacli)
        Me.tabCliente.Controls.Add(Me.Label44)
        Me.tabCliente.Controls.Add(Me.txtContacto)
        Me.tabCliente.Controls.Add(Me.Label42)
        Me.tabCliente.Controls.Add(Me.btnBuscaCobrador)
        Me.tabCliente.Controls.Add(Me.Label37)
        Me.tabCliente.Controls.Add(Me.btnBuscaZonaCobro)
        Me.tabCliente.Controls.Add(Me.Label36)
        Me.tabCliente.Controls.Add(Me.btnBuscaVendedor)
        Me.tabCliente.Controls.Add(Me.Label35)
        Me.tabCliente.Controls.Add(Me.Label34)
        Me.tabCliente.Controls.Add(Me.Label33)
        Me.tabCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabCliente.Location = New System.Drawing.Point(4, 28)
        Me.tabCliente.Name = "tabCliente"
        Me.tabCliente.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCliente.Size = New System.Drawing.Size(867, 404)
        Me.tabCliente.TabIndex = 1
        Me.tabCliente.Text = "Cliente  "
        '
        'btnBuscaZonaVentas
        '
        Me.btnBuscaZonaVentas.BackColor = System.Drawing.Color.DimGray
        Me.btnBuscaZonaVentas.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnBuscaZonaVentas.FlatAppearance.BorderSize = 0
        Me.btnBuscaZonaVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscaZonaVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscaZonaVentas.ForeColor = System.Drawing.Color.White
        Me.btnBuscaZonaVentas.Location = New System.Drawing.Point(105, 30)
        Me.btnBuscaZonaVentas.Name = "btnBuscaZonaVentas"
        Me.btnBuscaZonaVentas.Size = New System.Drawing.Size(18, 18)
        Me.btnBuscaZonaVentas.TabIndex = 124
        Me.btnBuscaZonaVentas.Text = "..."
        Me.btnBuscaZonaVentas.UseVisualStyleBackColor = False
        '
        'CBuscador3
        '
        Me.CBuscador3.BackColor = System.Drawing.Color.DimGray
        Me.CBuscador3.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.CBuscador3.FlatAppearance.BorderSize = 0
        Me.CBuscador3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CBuscador3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBuscador3.ForeColor = System.Drawing.Color.White
        Me.CBuscador3.Location = New System.Drawing.Point(105, 9)
        Me.CBuscador3.Name = "CBuscador3"
        Me.CBuscador3.Size = New System.Drawing.Size(18, 18)
        Me.CBuscador3.TabIndex = 123
        Me.CBuscador3.Text = "..."
        Me.CBuscador3.UseVisualStyleBackColor = False
        '
        'txtOperador
        '
        Me.txtOperador.BackColor = System.Drawing.Color.White
        Me.txtOperador.Location = New System.Drawing.Point(356, 11)
        Me.txtOperador.Name = "txtOperador"
        Me.txtOperador.Size = New System.Drawing.Size(300, 18)
        Me.txtOperador.TabIndex = 122
        '
        'btnBuscaOperador
        '
        Me.btnBuscaOperador.BackColor = System.Drawing.Color.DimGray
        Me.btnBuscaOperador.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnBuscaOperador.FlatAppearance.BorderSize = 0
        Me.btnBuscaOperador.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscaOperador.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscaOperador.ForeColor = System.Drawing.Color.White
        Me.btnBuscaOperador.Location = New System.Drawing.Point(337, 11)
        Me.btnBuscaOperador.Name = "btnBuscaOperador"
        Me.btnBuscaOperador.Size = New System.Drawing.Size(18, 18)
        Me.btnBuscaOperador.TabIndex = 121
        Me.btnBuscaOperador.Text = "..."
        Me.btnBuscaOperador.UseVisualStyleBackColor = False
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.ForeColor = System.Drawing.Color.White
        Me.Label90.Location = New System.Drawing.Point(285, 14)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(51, 13)
        Me.Label90.TabIndex = 120
        Me.Label90.Text = "Operador"
        '
        'Cuenta4
        '
        Me.Cuenta4.BackColor = System.Drawing.Color.White
        Me.Cuenta4.Location = New System.Drawing.Point(504, 285)
        Me.Cuenta4.Name = "Cuenta4"
        Me.Cuenta4.Size = New System.Drawing.Size(125, 18)
        Me.Cuenta4.TabIndex = 119
        '
        'Cuenta0
        '
        Me.Cuenta0.BackColor = System.Drawing.Color.White
        Me.Cuenta0.Location = New System.Drawing.Point(147, 286)
        Me.Cuenta0.Name = "Cuenta0"
        Me.Cuenta0.Size = New System.Drawing.Size(119, 18)
        Me.Cuenta0.TabIndex = 118
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.btnTransportadora)
        Me.GroupBox15.Controls.Add(Me.Label41)
        Me.GroupBox15.Controls.Add(Me.txtTransportadora)
        Me.GroupBox15.Controls.Add(Me.txtPaisEntrega)
        Me.GroupBox15.Controls.Add(Me.btnPuertoEntrega)
        Me.GroupBox15.Controls.Add(Me.Label94)
        Me.GroupBox15.Controls.Add(Me.btnPaísEntrega)
        Me.GroupBox15.Controls.Add(Me.Label95)
        Me.GroupBox15.Controls.Add(Me.entregarmer)
        Me.GroupBox15.ForeColor = System.Drawing.Color.Black
        Me.GroupBox15.Location = New System.Drawing.Point(9, 176)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(817, 84)
        Me.GroupBox15.TabIndex = 117
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "Entrega de productos"
        '
        'btnTransportadora
        '
        Me.btnTransportadora.BackColor = System.Drawing.Color.DimGray
        Me.btnTransportadora.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnTransportadora.FlatAppearance.BorderSize = 0
        Me.btnTransportadora.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTransportadora.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransportadora.ForeColor = System.Drawing.Color.White
        Me.btnTransportadora.Location = New System.Drawing.Point(130, 46)
        Me.btnTransportadora.Name = "btnTransportadora"
        Me.btnTransportadora.Size = New System.Drawing.Size(18, 18)
        Me.btnTransportadora.TabIndex = 117
        Me.btnTransportadora.Text = "..."
        Me.btnTransportadora.UseVisualStyleBackColor = False
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.ForeColor = System.Drawing.Color.White
        Me.Label41.Location = New System.Drawing.Point(6, 48)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(123, 13)
        Me.Label41.TabIndex = 115
        Me.Label41.Text = "Agencia transportadora :"
        '
        'txtTransportadora
        '
        Me.txtTransportadora.ForeColor = System.Drawing.Color.Black
        Me.txtTransportadora.Location = New System.Drawing.Point(149, 45)
        Me.txtTransportadora.Name = "txtTransportadora"
        Me.txtTransportadora.Size = New System.Drawing.Size(326, 20)
        Me.txtTransportadora.TabIndex = 116
        '
        'txtPaisEntrega
        '
        Me.txtPaisEntrega.BackColor = System.Drawing.Color.White
        Me.txtPaisEntrega.ForeColor = System.Drawing.Color.Black
        Me.txtPaisEntrega.Location = New System.Drawing.Point(52, 19)
        Me.txtPaisEntrega.Name = "txtPaisEntrega"
        Me.txtPaisEntrega.Size = New System.Drawing.Size(191, 18)
        Me.txtPaisEntrega.TabIndex = 114
        '
        'btnPuertoEntrega
        '
        Me.btnPuertoEntrega.BackColor = System.Drawing.Color.DimGray
        Me.btnPuertoEntrega.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnPuertoEntrega.FlatAppearance.BorderSize = 0
        Me.btnPuertoEntrega.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPuertoEntrega.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPuertoEntrega.ForeColor = System.Drawing.Color.White
        Me.btnPuertoEntrega.Location = New System.Drawing.Point(299, 19)
        Me.btnPuertoEntrega.Name = "btnPuertoEntrega"
        Me.btnPuertoEntrega.Size = New System.Drawing.Size(18, 18)
        Me.btnPuertoEntrega.TabIndex = 20
        Me.btnPuertoEntrega.Text = "..."
        Me.btnPuertoEntrega.UseVisualStyleBackColor = False
        '
        'Label94
        '
        Me.Label94.AutoSize = True
        Me.Label94.ForeColor = System.Drawing.Color.White
        Me.Label94.Location = New System.Drawing.Point(257, 24)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(44, 13)
        Me.Label94.TabIndex = 18
        Me.Label94.Text = "Puerto :"
        '
        'btnPaísEntrega
        '
        Me.btnPaísEntrega.BackColor = System.Drawing.Color.DimGray
        Me.btnPaísEntrega.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnPaísEntrega.FlatAppearance.BorderSize = 0
        Me.btnPaísEntrega.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPaísEntrega.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPaísEntrega.ForeColor = System.Drawing.Color.White
        Me.btnPaísEntrega.Location = New System.Drawing.Point(33, 19)
        Me.btnPaísEntrega.Name = "btnPaísEntrega"
        Me.btnPaísEntrega.Size = New System.Drawing.Size(18, 18)
        Me.btnPaísEntrega.TabIndex = 17
        Me.btnPaísEntrega.Text = "..."
        Me.btnPaísEntrega.UseVisualStyleBackColor = False
        '
        'Label95
        '
        Me.Label95.AutoSize = True
        Me.Label95.ForeColor = System.Drawing.Color.White
        Me.Label95.Location = New System.Drawing.Point(5, 24)
        Me.Label95.Name = "Label95"
        Me.Label95.Size = New System.Drawing.Size(27, 13)
        Me.Label95.TabIndex = 15
        Me.Label95.Text = "Pais"
        '
        'txtCobrador
        '
        Me.txtCobrador.BackColor = System.Drawing.Color.White
        Me.txtCobrador.Location = New System.Drawing.Point(356, 53)
        Me.txtCobrador.Name = "txtCobrador"
        Me.txtCobrador.Size = New System.Drawing.Size(300, 18)
        Me.txtCobrador.TabIndex = 116
        '
        'txtVendedor
        '
        Me.txtVendedor.BackColor = System.Drawing.Color.White
        Me.txtVendedor.Location = New System.Drawing.Point(356, 32)
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.Size = New System.Drawing.Size(300, 18)
        Me.txtVendedor.TabIndex = 115
        '
        'txtZonaCobranzas
        '
        Me.txtZonaCobranzas.BackColor = System.Drawing.Color.White
        Me.txtZonaCobranzas.Location = New System.Drawing.Point(124, 51)
        Me.txtZonaCobranzas.Name = "txtZonaCobranzas"
        Me.txtZonaCobranzas.Size = New System.Drawing.Size(142, 18)
        Me.txtZonaCobranzas.TabIndex = 114
        '
        'txtZonaVentas
        '
        Me.txtZonaVentas.BackColor = System.Drawing.Color.White
        Me.txtZonaVentas.Location = New System.Drawing.Point(124, 30)
        Me.txtZonaVentas.Name = "txtZonaVentas"
        Me.txtZonaVentas.Size = New System.Drawing.Size(142, 18)
        Me.txtZonaVentas.TabIndex = 113
        '
        'txtTipoCliente
        '
        Me.txtTipoCliente.BackColor = System.Drawing.Color.White
        Me.txtTipoCliente.Location = New System.Drawing.Point(124, 9)
        Me.txtTipoCliente.Name = "txtTipoCliente"
        Me.txtTipoCliente.Size = New System.Drawing.Size(142, 18)
        Me.txtTipoCliente.TabIndex = 112
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.txtPrecioVenta)
        Me.GroupBox11.Controls.Add(Me.txtFormaPago)
        Me.GroupBox11.Controls.Add(Me.txtLimiteCredito)
        Me.GroupBox11.Controls.Add(Me.Label46)
        Me.GroupBox11.Controls.Add(Me.txtDescuentoAsociacion)
        Me.GroupBox11.Controls.Add(Me.Label43)
        Me.GroupBox11.Controls.Add(Me.txtPorcDescuento)
        Me.GroupBox11.Controls.Add(Me.Label40)
        Me.GroupBox11.Controls.Add(Me.btnFormaPago)
        Me.GroupBox11.Controls.Add(Me.Label39)
        Me.GroupBox11.Controls.Add(Me.btnPrecioVenta)
        Me.GroupBox11.Controls.Add(Me.Label38)
        Me.GroupBox11.ForeColor = System.Drawing.Color.Black
        Me.GroupBox11.Location = New System.Drawing.Point(8, 98)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(817, 72)
        Me.GroupBox11.TabIndex = 42
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Características comerciales"
        '
        'txtPrecioVenta
        '
        Me.txtPrecioVenta.BackColor = System.Drawing.Color.White
        Me.txtPrecioVenta.ForeColor = System.Drawing.Color.Black
        Me.txtPrecioVenta.Location = New System.Drawing.Point(115, 23)
        Me.txtPrecioVenta.Name = "txtPrecioVenta"
        Me.txtPrecioVenta.Size = New System.Drawing.Size(125, 18)
        Me.txtPrecioVenta.TabIndex = 114
        '
        'txtFormaPago
        '
        Me.txtFormaPago.BackColor = System.Drawing.Color.White
        Me.txtFormaPago.ForeColor = System.Drawing.Color.Black
        Me.txtFormaPago.Location = New System.Drawing.Point(355, 23)
        Me.txtFormaPago.Name = "txtFormaPago"
        Me.txtFormaPago.Size = New System.Drawing.Size(125, 18)
        Me.txtFormaPago.TabIndex = 113
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.ForeColor = System.Drawing.Color.White
        Me.Label35.Location = New System.Drawing.Point(283, 35)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(53, 13)
        Me.Label35.TabIndex = 6
        Me.Label35.Text = "Vendedor"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.ForeColor = System.Drawing.Color.White
        Me.Label34.Location = New System.Drawing.Point(20, 33)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(82, 13)
        Me.Label34.TabIndex = 3
        Me.Label34.Text = "Zona de ventas"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.Location = New System.Drawing.Point(24, 13)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(78, 13)
        Me.Label33.TabIndex = 0
        Me.Label33.Text = "Tipo de Cliente"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DimGray
        Me.Panel1.Controls.Add(Me.Apellidos)
        Me.Panel1.Controls.Add(Me.txtHistoriaclinica)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label79)
        Me.Panel1.Controls.Add(Me.Codigo)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TipoIdent)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TxtCedulaRuc)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.TxtNombres)
        Me.Panel1.Controls.Add(Me.Label32)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1012, 49)
        Me.Panel1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Código"
        '
        'Codigo
        '
        Me.Codigo.Location = New System.Drawing.Point(46, 3)
        Me.Codigo.MaxLength = 15
        Me.Codigo.Name = "Codigo"
        Me.Codigo.Size = New System.Drawing.Size(88, 20)
        Me.Codigo.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(138, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(131, 13)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Documento Identificación:"
        '
        'TipoIdent
        '
        Me.TipoIdent.FormattingEnabled = True
        Me.TipoIdent.Items.AddRange(New Object() {"No aplica", "Registro U Contribuyente", "Cédula Identidad", "Pasaporte", "Consumidor Final"})
        Me.TipoIdent.Location = New System.Drawing.Point(272, 2)
        Me.TipoIdent.Name = "TipoIdent"
        Me.TipoIdent.Size = New System.Drawing.Size(119, 21)
        Me.TipoIdent.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(396, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Nro:"
        '
        'TxtCedulaRuc
        '
        Me.TxtCedulaRuc.Location = New System.Drawing.Point(425, 4)
        Me.TxtCedulaRuc.Name = "TxtCedulaRuc"
        Me.TxtCedulaRuc.Size = New System.Drawing.Size(101, 20)
        Me.TxtCedulaRuc.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(2, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "Nombres"
        '
        'TxtNombres
        '
        Me.TxtNombres.Location = New System.Drawing.Point(55, 25)
        Me.TxtNombres.Name = "TxtNombres"
        Me.TxtNombres.Size = New System.Drawing.Size(262, 20)
        Me.TxtNombres.TabIndex = 3
        '
        'dialogoOpen
        '
        Me.dialogoOpen.FileName = "OpenFileDialog1"
        '
        'DEEPCNTE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1012, 523)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "DEEPCNTE"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DAXMED - REGISTRO DE PACIENTES"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.malla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabFamiliares.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.DatosDirectorio.ResumeLayout(False)
        Me.tabIdentificación.ResumeLayout(False)
        Me.tabIdentificación.PerformLayout()
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox13.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.foto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDatosPer.ResumeLayout(False)
        Me.tabDatosPer.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.asociadoa.ResumeLayout(False)
        Me.asociadoa.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.tabCliente.ResumeLayout(False)
        Me.tabCliente.PerformLayout()
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox15.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnAbrir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents Command5 As System.Windows.Forms.Button
    Friend WithEvents txtLimiteCredito As System.Windows.Forms.TextBox
    Friend WithEvents Command1 As System.Windows.Forms.Button
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents observacli As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents txtDescuentoAsociacion As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents txtContacto As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents entregarmer As System.Windows.Forms.TextBox
    Friend WithEvents txtPorcDescuento As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents btnFormaPago As System.Windows.Forms.Button
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents btnPrecioVenta As System.Windows.Forms.Button
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents btnBuscaCobrador As System.Windows.Forms.Button
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents btnBuscaZonaCobro As System.Windows.Forms.Button
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents btnBuscaVendedor As System.Windows.Forms.Button
    Friend WithEvents malla As System.Windows.Forms.DataGridView
    Friend WithEvents tabFamiliares As System.Windows.Forms.TabPage
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents txtHistoriaclinica As System.Windows.Forms.TextBox
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents Apellidos As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents foto As System.Windows.Forms.PictureBox
    Friend WithEvents TxtData9 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TxtData8 As System.Windows.Forms.TextBox
    Friend WithEvents TxtData6 As System.Windows.Forms.TextBox
    Friend WithEvents label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtTelefono3 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtTelefono2 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtTelefono1 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtNroDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtnomDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents DatosDirectorio As System.Windows.Forms.TabControl
    Friend WithEvents tabIdentificación As System.Windows.Forms.TabPage
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents impresion As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtNombres As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtCedulaRuc As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TipoIdent As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Codigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tabDatosPer As System.Windows.Forms.TabPage
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents asociadoa As System.Windows.Forms.GroupBox
    Friend WithEvents CbuscaDir3 As System.Windows.Forms.Button
    Friend WithEvents LDir3 As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtLugTra As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtNumTar As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtCodTar As System.Windows.Forms.TextBox
    Friend WithEvents hobbys As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtReferirseComo As System.Windows.Forms.ComboBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Lugarnaci As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cmbEstadoCivil As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents mujer As System.Windows.Forms.RadioButton
    Friend WithEvents hombre As System.Windows.Forms.RadioButton
    Friend WithEvents tabCliente As System.Windows.Forms.TabPage
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents dialogoOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Nro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CedulaId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombres As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Parentesco As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents FechaNacim As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sexo1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents EstadoCivil As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Direccion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Teléfono_1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Teléfono_2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ocupación As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Depend As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Minusv As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtContribuyenteEspecial As System.Windows.Forms.TextBox
    Friend WithEvents Label83 As System.Windows.Forms.Label
    Friend WithEvents chkRise As System.Windows.Forms.CheckBox
    Friend WithEvents chkObligaContabilidad As System.Windows.Forms.CheckBox
    Friend WithEvents ExoneradoIva As System.Windows.Forms.CheckBox
    Friend WithEvents txtSector As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label84 As System.Windows.Forms.Label
    Friend WithEvents Label85 As System.Windows.Forms.Label
    Friend WithEvents Label86 As System.Windows.Forms.Label
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents Label88 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtCobrador As System.Windows.Forms.Label
    Friend WithEvents txtVendedor As System.Windows.Forms.Label
    Friend WithEvents txtZonaCobranzas As System.Windows.Forms.Label
    Friend WithEvents txtZonaVentas As System.Windows.Forms.Label
    Friend WithEvents txtTipoCliente As System.Windows.Forms.Label
    Friend WithEvents txtPrecioVenta As System.Windows.Forms.Label
    Friend WithEvents txtFormaPago As System.Windows.Forms.Label
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPaisEntrega As System.Windows.Forms.Label
    Friend WithEvents btnPuertoEntrega As System.Windows.Forms.Button
    Friend WithEvents Label94 As System.Windows.Forms.Label
    Friend WithEvents btnPaísEntrega As System.Windows.Forms.Button
    Friend WithEvents Label95 As System.Windows.Forms.Label
    Friend WithEvents Cuenta4 As System.Windows.Forms.Label
    Friend WithEvents Cuenta0 As System.Windows.Forms.Label
    Friend WithEvents btnTransportadora As System.Windows.Forms.Button
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents txtTransportadora As System.Windows.Forms.TextBox
    Friend WithEvents txtOperador As System.Windows.Forms.Label
    Friend WithEvents btnBuscaOperador As System.Windows.Forms.Button
    Friend WithEvents Label90 As System.Windows.Forms.Label
    Friend WithEvents Label89 As System.Windows.Forms.Label
    Friend WithEvents txtPorcDiscapacidad As System.Windows.Forms.TextBox
    Friend WithEvents Label91 As System.Windows.Forms.Label
    Friend WithEvents txtDiscapacidad As System.Windows.Forms.TextBox
    Friend WithEvents Label93 As Windows.Forms.Label
    Friend WithEvents CBuscador3 As Windows.Forms.Button
    Friend WithEvents btnBuscaZonaVentas As Windows.Forms.Button
    Friend WithEvents TxtResolucionAR As Windows.Forms.TextBox
    Friend WithEvents Label82 As Windows.Forms.Label
    Friend WithEvents chkRegimenMicroempresas As Windows.Forms.CheckBox
    Friend WithEvents cmbPaisDomicilio As Windows.Forms.ComboBox
    Friend WithEvents cmbProvinciaDomicilio As Windows.Forms.ComboBox
    Friend WithEvents cmbParroquiaDomicilio As Windows.Forms.ComboBox
    Friend WithEvents cmbRegionDomicilio As Windows.Forms.ComboBox
    Friend WithEvents cmbCantonDomicilio As Windows.Forms.ComboBox
    Friend WithEvents cmbCiudadDomicilio As Windows.Forms.ComboBox
    Friend WithEvents cmbTipoSangre As Windows.Forms.ComboBox
    Friend WithEvents fechanaci As Windows.Forms.DateTimePicker
    Friend WithEvents cmbPaisNace As Windows.Forms.ComboBox
    Friend WithEvents cmbRegionNace As Windows.Forms.ComboBox
    Friend WithEvents cmbCiudadNace As Windows.Forms.ComboBox
    Friend WithEvents cmbProvinciaNace As Windows.Forms.ComboBox
    Friend WithEvents ColorDialog1 As Windows.Forms.ColorDialog
    Friend WithEvents cmbNacionalidadPersonal As Windows.Forms.ComboBox
    Friend WithEvents cmbEspecialidad2 As Windows.Forms.ComboBox
    Friend WithEvents cmbEspecialidad As Windows.Forms.ComboBox
    Friend WithEvents cmbProfesion As Windows.Forms.ComboBox
End Class
