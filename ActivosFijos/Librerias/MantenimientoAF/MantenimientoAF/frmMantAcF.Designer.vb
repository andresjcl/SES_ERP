<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MantAF
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MantAF))
        Me.ToolStripMenu = New System.Windows.Forms.ToolStrip()
        Me.BtnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btnAbrir = New System.Windows.Forms.ToolStripButton()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.BtnEliminar = New System.Windows.Forms.ToolStripButton()
        Me.btnReporte = New System.Windows.Forms.ToolStripButton()
        Me.BtnSalir = New System.Windows.Forms.ToolStripButton()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkComponente = New System.Windows.Forms.CheckBox()
        Me.TabSeguro = New System.Windows.Forms.TabPage()
        Me.txtFechaFinS = New System.Windows.Forms.MaskedTextBox()
        Me.txtFechaInicioS = New System.Windows.Forms.MaskedTextBox()
        Me.txtAsegCod = New System.Windows.Forms.TextBox()
        Me.txtPagoM = New System.Windows.Forms.TextBox()
        Me.txtDeducible = New System.Windows.Forms.TextBox()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.txtContrato = New System.Windows.Forms.TextBox()
        Me.txtAseguradora = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TabContabilidad = New System.Windows.Forms.TabPage()
        Me.grupoSalida = New System.Windows.Forms.GroupBox()
        Me.Txtfechasal = New System.Windows.Forms.DateTimePicker()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.txtNDocSal = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtDocSal = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtFechaIng = New System.Windows.Forms.DateTimePicker()
        Me.txtNDocIng = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtValRes = New System.Windows.Forms.TextBox()
        Me.txtDocIng = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtCostoIng = New System.Windows.Forms.TextBox()
        Me.btnParidad = New System.Windows.Forms.Button()
        Me.txtParidad = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.cboMoneda = New System.Windows.Forms.ComboBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.grupoDepTributaria = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtTasaDeprecTrib = New System.Windows.Forms.TextBox()
        Me.cboTipoDepTribut = New System.Windows.Forms.ComboBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.txtVidaUtTribut = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.grupoDepFinanciera = New System.Windows.Forms.GroupBox()
        Me.txtUndProdConta = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtVidaUtConta = New System.Windows.Forms.TextBox()
        Me.cboTipoDepFinanc = New System.Windows.Forms.ComboBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtIdentifNombre4 = New System.Windows.Forms.TextBox()
        Me.txtIdentifCodigo4 = New System.Windows.Forms.TextBox()
        Me.txtIdentifNombre3 = New System.Windows.Forms.TextBox()
        Me.txtIdentifCodigo3 = New System.Windows.Forms.TextBox()
        Me.txtIdentifNombre2 = New System.Windows.Forms.TextBox()
        Me.txtIdentifCodigo2 = New System.Windows.Forms.TextBox()
        Me.txtIdentifNombre1 = New System.Windows.Forms.TextBox()
        Me.txtIdentifCodigo1 = New System.Windows.Forms.TextBox()
        Me.btnIdentifCont4 = New System.Windows.Forms.Button()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.btnIdentifCont3 = New System.Windows.Forms.Button()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.btnIdentifCont2 = New System.Windows.Forms.Button()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.btnIdentifCont1 = New System.Windows.Forms.Button()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.TabCaracteristicas = New System.Windows.Forms.TabPage()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.TxtLote = New System.Windows.Forms.TextBox()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.txtMarca = New System.Windows.Forms.TextBox()
        Me.txtActivoCmpstoNombre = New System.Windows.Forms.TextBox()
        Me.txtActivoCmpstoCod = New System.Windows.Forms.TextBox()
        Me.txtDescrip = New System.Windows.Forms.TextBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.grupoUbicacion = New System.Windows.Forms.GroupBox()
        Me.btnSucursal = New System.Windows.Forms.Button()
        Me.txtCCosto = New System.Windows.Forms.TextBox()
        Me.txtResp = New System.Windows.Forms.TextBox()
        Me.txtSucursal = New System.Windows.Forms.TextBox()
        Me.txtRespCod = New System.Windows.Forms.TextBox()
        Me.btnSeccion = New System.Windows.Forms.Button()
        Me.btnDpto = New System.Windows.Forms.Button()
        Me.txtSeccion = New System.Windows.Forms.TextBox()
        Me.txtDepartamento = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnResponsable = New System.Windows.Forms.Button()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.btnCCosto = New System.Windows.Forms.Button()
        Me.btnBuscaActivoCmpsto = New System.Windows.Forms.Button()
        Me.cboSubg = New System.Windows.Forms.ComboBox()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.cboClase = New System.Windows.Forms.ComboBox()
        Me.cboCategoria = New System.Windows.Forms.ComboBox()
        Me.cboTipoActivos = New System.Windows.Forms.ComboBox()
        Me.imgImagen = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.ToolStripMenu.SuspendLayout()
        Me.TabSeguro.SuspendLayout()
        Me.TabContabilidad.SuspendLayout()
        Me.grupoSalida.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.grupoDepTributaria.SuspendLayout()
        Me.grupoDepFinanciera.SuspendLayout()
        Me.TabCaracteristicas.SuspendLayout()
        Me.grupoUbicacion.SuspendLayout()
        CType(Me.imgImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripMenu
        '
        Me.ToolStripMenu.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStripMenu.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStripMenu.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ToolStripMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnNuevo, Me.btnAbrir, Me.btnCancelar, Me.btnGuardar, Me.BtnEliminar, Me.btnReporte, Me.BtnSalir})
        Me.ToolStripMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ToolStripMenu.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMenu.Name = "ToolStripMenu"
        Me.ToolStripMenu.Size = New System.Drawing.Size(935, 46)
        Me.ToolStripMenu.TabIndex = 0
        Me.ToolStripMenu.Text = "ToolStrip1"
        '
        'BtnNuevo
        '
        Me.BtnNuevo.ForeColor = System.Drawing.Color.White
        Me.BtnNuevo.Image = Global.MantenimientoAF.My.Resources.Resources.nuevo2
        Me.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(46, 43)
        Me.BtnNuevo.Text = "&Nuevo"
        Me.BtnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnAbrir
        '
        Me.btnAbrir.ForeColor = System.Drawing.Color.White
        Me.btnAbrir.Image = Global.MantenimientoAF.My.Resources.Resources._16__Open_
        Me.btnAbrir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.Size = New System.Drawing.Size(37, 43)
        Me.btnAbrir.Text = "&Abrir"
        Me.btnAbrir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAbrir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.White
        Me.btnCancelar.Image = Global.MantenimientoAF.My.Resources.Resources.cerrar
        Me.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(43, 43)
        Me.btnCancelar.Text = "&Cerrar"
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnGuardar
        '
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.Image = Global.MantenimientoAF.My.Resources.Resources.grabar
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(53, 43)
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'BtnEliminar
        '
        Me.BtnEliminar.ForeColor = System.Drawing.Color.White
        Me.BtnEliminar.Image = Global.MantenimientoAF.My.Resources.Resources.Eliminar_16
        Me.BtnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(54, 43)
        Me.BtnEliminar.Text = "&Eliminar"
        Me.BtnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnReporte
        '
        Me.btnReporte.ForeColor = System.Drawing.Color.White
        Me.btnReporte.Image = CType(resources.GetObject("btnReporte.Image"), System.Drawing.Image)
        Me.btnReporte.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(52, 43)
        Me.btnReporte.Text = "Reporte"
        Me.btnReporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnReporte.ToolTipText = "Reporte de Movimientos"
        Me.btnReporte.Visible = False
        '
        'BtnSalir
        '
        Me.BtnSalir.ForeColor = System.Drawing.Color.White
        Me.BtnSalir.Image = Global.MantenimientoAF.My.Resources.Resources._EXit
        Me.BtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(33, 43)
        Me.BtnSalir.Text = "&Salir"
        Me.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'chkComponente
        '
        Me.chkComponente.AutoSize = True
        Me.chkComponente.BackColor = System.Drawing.Color.Transparent
        Me.chkComponente.Location = New System.Drawing.Point(17, 104)
        Me.chkComponente.Name = "chkComponente"
        Me.chkComponente.Size = New System.Drawing.Size(152, 17)
        Me.chkComponente.TabIndex = 9
        Me.chkComponente.Text = "Es componente del  activo"
        Me.ToolTip1.SetToolTip(Me.chkComponente, "Permite registrar mejoras, adicines y reparaciones al activo")
        Me.chkComponente.UseVisualStyleBackColor = False
        '
        'TabSeguro
        '
        Me.TabSeguro.BackColor = System.Drawing.Color.LightSteelBlue
        Me.TabSeguro.Controls.Add(Me.txtFechaFinS)
        Me.TabSeguro.Controls.Add(Me.txtFechaInicioS)
        Me.TabSeguro.Controls.Add(Me.txtAsegCod)
        Me.TabSeguro.Controls.Add(Me.txtPagoM)
        Me.TabSeguro.Controls.Add(Me.txtDeducible)
        Me.TabSeguro.Controls.Add(Me.txtMonto)
        Me.TabSeguro.Controls.Add(Me.txtContrato)
        Me.TabSeguro.Controls.Add(Me.txtAseguradora)
        Me.TabSeguro.Controls.Add(Me.Label40)
        Me.TabSeguro.Controls.Add(Me.Label39)
        Me.TabSeguro.Controls.Add(Me.Label38)
        Me.TabSeguro.Controls.Add(Me.Label37)
        Me.TabSeguro.Controls.Add(Me.Label26)
        Me.TabSeguro.Controls.Add(Me.Label25)
        Me.TabSeguro.Controls.Add(Me.Button1)
        Me.TabSeguro.Controls.Add(Me.Label13)
        Me.TabSeguro.Location = New System.Drawing.Point(4, 22)
        Me.TabSeguro.Name = "TabSeguro"
        Me.TabSeguro.Padding = New System.Windows.Forms.Padding(3)
        Me.TabSeguro.Size = New System.Drawing.Size(927, 359)
        Me.TabSeguro.TabIndex = 3
        Me.TabSeguro.Text = "Seguro"
        '
        'txtFechaFinS
        '
        Me.txtFechaFinS.Location = New System.Drawing.Point(553, 81)
        Me.txtFechaFinS.Mask = "00/00/0000"
        Me.txtFechaFinS.Name = "txtFechaFinS"
        Me.txtFechaFinS.Size = New System.Drawing.Size(71, 20)
        Me.txtFechaFinS.TabIndex = 15
        Me.txtFechaFinS.ValidatingType = GetType(Date)
        '
        'txtFechaInicioS
        '
        Me.txtFechaInicioS.Location = New System.Drawing.Point(318, 79)
        Me.txtFechaInicioS.Mask = "00/00/0000"
        Me.txtFechaInicioS.Name = "txtFechaInicioS"
        Me.txtFechaInicioS.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaInicioS.TabIndex = 14
        Me.txtFechaInicioS.ValidatingType = GetType(Date)
        '
        'txtAsegCod
        '
        Me.txtAsegCod.Location = New System.Drawing.Point(115, 36)
        Me.txtAsegCod.Name = "txtAsegCod"
        Me.txtAsegCod.Size = New System.Drawing.Size(106, 20)
        Me.txtAsegCod.TabIndex = 0
        '
        'txtPagoM
        '
        Me.txtPagoM.Location = New System.Drawing.Point(115, 208)
        Me.txtPagoM.Name = "txtPagoM"
        Me.txtPagoM.Size = New System.Drawing.Size(106, 20)
        Me.txtPagoM.TabIndex = 8
        '
        'txtDeducible
        '
        Me.txtDeducible.Location = New System.Drawing.Point(115, 164)
        Me.txtDeducible.Name = "txtDeducible"
        Me.txtDeducible.Size = New System.Drawing.Size(106, 20)
        Me.txtDeducible.TabIndex = 7
        '
        'txtMonto
        '
        Me.txtMonto.Location = New System.Drawing.Point(115, 121)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(106, 20)
        Me.txtMonto.TabIndex = 6
        '
        'txtContrato
        '
        Me.txtContrato.Location = New System.Drawing.Point(115, 80)
        Me.txtContrato.Name = "txtContrato"
        Me.txtContrato.Size = New System.Drawing.Size(106, 20)
        Me.txtContrato.TabIndex = 3
        '
        'txtAseguradora
        '
        Me.txtAseguradora.Location = New System.Drawing.Point(227, 36)
        Me.txtAseguradora.Name = "txtAseguradora"
        Me.txtAseguradora.Size = New System.Drawing.Size(318, 20)
        Me.txtAseguradora.TabIndex = 1
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(18, 211)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(78, 13)
        Me.Label40.TabIndex = 13
        Me.Label40.Text = "Pago Mensual:"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(18, 167)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(85, 13)
        Me.Label39.TabIndex = 11
        Me.Label39.Text = "Valor Deducible:"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(18, 125)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(94, 13)
        Me.Label38.TabIndex = 9
        Me.Label38.Text = "Monto Asegurado:"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(426, 84)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(109, 13)
        Me.Label37.TabIndex = 7
        Me.Label37.Text = "Ficha de Finalización:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(231, 84)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(79, 13)
        Me.Label26.TabIndex = 5
        Me.Label26.Text = "Ficha de Inicio:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(19, 84)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(85, 13)
        Me.Label25.TabIndex = 3
        Me.Label25.Text = "No. de Contrato:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(538, 36)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(27, 21)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(18, 39)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Aseguradora:"
        '
        'TabContabilidad
        '
        Me.TabContabilidad.AllowDrop = True
        Me.TabContabilidad.BackColor = System.Drawing.Color.LightSteelBlue
        Me.TabContabilidad.Controls.Add(Me.grupoSalida)
        Me.TabContabilidad.Controls.Add(Me.GroupBox3)
        Me.TabContabilidad.Controls.Add(Me.grupoDepTributaria)
        Me.TabContabilidad.Controls.Add(Me.grupoDepFinanciera)
        Me.TabContabilidad.Controls.Add(Me.txtIdentifNombre4)
        Me.TabContabilidad.Controls.Add(Me.txtIdentifCodigo4)
        Me.TabContabilidad.Controls.Add(Me.txtIdentifNombre3)
        Me.TabContabilidad.Controls.Add(Me.txtIdentifCodigo3)
        Me.TabContabilidad.Controls.Add(Me.txtIdentifNombre2)
        Me.TabContabilidad.Controls.Add(Me.txtIdentifCodigo2)
        Me.TabContabilidad.Controls.Add(Me.txtIdentifNombre1)
        Me.TabContabilidad.Controls.Add(Me.txtIdentifCodigo1)
        Me.TabContabilidad.Controls.Add(Me.btnIdentifCont4)
        Me.TabContabilidad.Controls.Add(Me.Label32)
        Me.TabContabilidad.Controls.Add(Me.btnIdentifCont3)
        Me.TabContabilidad.Controls.Add(Me.Label31)
        Me.TabContabilidad.Controls.Add(Me.btnIdentifCont2)
        Me.TabContabilidad.Controls.Add(Me.Label30)
        Me.TabContabilidad.Controls.Add(Me.btnIdentifCont1)
        Me.TabContabilidad.Controls.Add(Me.Label29)
        Me.TabContabilidad.Location = New System.Drawing.Point(4, 22)
        Me.TabContabilidad.Name = "TabContabilidad"
        Me.TabContabilidad.Size = New System.Drawing.Size(927, 359)
        Me.TabContabilidad.TabIndex = 2
        Me.TabContabilidad.Text = "Contabilidad"
        '
        'grupoSalida
        '
        Me.grupoSalida.Controls.Add(Me.Txtfechasal)
        Me.grupoSalida.Controls.Add(Me.Label47)
        Me.grupoSalida.Controls.Add(Me.txtNDocSal)
        Me.grupoSalida.Controls.Add(Me.Label22)
        Me.grupoSalida.Controls.Add(Me.txtDocSal)
        Me.grupoSalida.Controls.Add(Me.Label23)
        Me.grupoSalida.Location = New System.Drawing.Point(494, 5)
        Me.grupoSalida.Name = "grupoSalida"
        Me.grupoSalida.Size = New System.Drawing.Size(425, 107)
        Me.grupoSalida.TabIndex = 47
        Me.grupoSalida.TabStop = False
        Me.grupoSalida.Text = "Datos de Salida"
        '
        'Txtfechasal
        '
        Me.Txtfechasal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Txtfechasal.Location = New System.Drawing.Point(310, 37)
        Me.Txtfechasal.Name = "Txtfechasal"
        Me.Txtfechasal.Size = New System.Drawing.Size(103, 20)
        Me.Txtfechasal.TabIndex = 6
        Me.Txtfechasal.Value = New Date(1900, 1, 1, 0, 0, 0, 0)
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(318, 21)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(72, 13)
        Me.Label47.TabIndex = 4
        Me.Label47.Text = "Fecha Salida:"
        '
        'txtNDocSal
        '
        Me.txtNDocSal.Location = New System.Drawing.Point(206, 37)
        Me.txtNDocSal.Name = "txtNDocSal"
        Me.txtNDocSal.Size = New System.Drawing.Size(98, 20)
        Me.txtNDocSal.TabIndex = 3
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(203, 23)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(50, 13)
        Me.Label22.TabIndex = 2
        Me.Label22.Text = "Nro Doc:"
        '
        'txtDocSal
        '
        Me.txtDocSal.Location = New System.Drawing.Point(13, 37)
        Me.txtDocSal.Name = "txtDocSal"
        Me.txtDocSal.Size = New System.Drawing.Size(184, 20)
        Me.txtDocSal.TabIndex = 1
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(9, 24)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(65, 13)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "Documento:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.txtFechaIng)
        Me.GroupBox3.Controls.Add(Me.txtNDocIng)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.txtValRes)
        Me.GroupBox3.Controls.Add(Me.txtDocIng)
        Me.GroupBox3.Controls.Add(Me.Label28)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Label27)
        Me.GroupBox3.Controls.Add(Me.txtCostoIng)
        Me.GroupBox3.Controls.Add(Me.btnParidad)
        Me.GroupBox3.Controls.Add(Me.txtParidad)
        Me.GroupBox3.Controls.Add(Me.Label43)
        Me.GroupBox3.Controls.Add(Me.cboMoneda)
        Me.GroupBox3.Controls.Add(Me.Label41)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(465, 105)
        Me.GroupBox3.TabIndex = 46
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Datos de Ingreso"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(306, 24)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(40, 13)
        Me.Label20.TabIndex = 4
        Me.Label20.Text = "Fecha:"
        '
        'txtFechaIng
        '
        Me.txtFechaIng.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaIng.Location = New System.Drawing.Point(307, 37)
        Me.txtFechaIng.Name = "txtFechaIng"
        Me.txtFechaIng.Size = New System.Drawing.Size(103, 20)
        Me.txtFechaIng.TabIndex = 5
        '
        'txtNDocIng
        '
        Me.txtNDocIng.Location = New System.Drawing.Point(196, 37)
        Me.txtNDocIng.Name = "txtNDocIng"
        Me.txtNDocIng.Size = New System.Drawing.Size(105, 20)
        Me.txtNDocIng.TabIndex = 3
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(193, 23)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(50, 13)
        Me.Label19.TabIndex = 2
        Me.Label19.Text = "Nro Doc:"
        '
        'txtValRes
        '
        Me.txtValRes.Location = New System.Drawing.Point(133, 74)
        Me.txtValRes.Name = "txtValRes"
        Me.txtValRes.Size = New System.Drawing.Size(89, 20)
        Me.txtValRes.TabIndex = 1
        '
        'txtDocIng
        '
        Me.txtDocIng.Location = New System.Drawing.Point(18, 36)
        Me.txtDocIng.Name = "txtDocIng"
        Me.txtDocIng.Size = New System.Drawing.Size(172, 20)
        Me.txtDocIng.TabIndex = 1
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(130, 61)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(78, 13)
        Me.Label28.TabIndex = 7
        Me.Label28.Text = "Valor Residual:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(15, 23)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(65, 13)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Documento:"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(16, 61)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(75, 13)
        Me.Label27.TabIndex = 5
        Me.Label27.Text = "Costo Ingreso:"
        '
        'txtCostoIng
        '
        Me.txtCostoIng.Location = New System.Drawing.Point(19, 74)
        Me.txtCostoIng.Name = "txtCostoIng"
        Me.txtCostoIng.Size = New System.Drawing.Size(89, 20)
        Me.txtCostoIng.TabIndex = 0
        '
        'btnParidad
        '
        Me.btnParidad.Location = New System.Drawing.Point(433, 74)
        Me.btnParidad.Name = "btnParidad"
        Me.btnParidad.Size = New System.Drawing.Size(25, 20)
        Me.btnParidad.TabIndex = 4
        Me.btnParidad.Text = "..."
        Me.btnParidad.UseVisualStyleBackColor = True
        Me.btnParidad.Visible = False
        '
        'txtParidad
        '
        Me.txtParidad.Location = New System.Drawing.Point(344, 74)
        Me.txtParidad.Name = "txtParidad"
        Me.txtParidad.Size = New System.Drawing.Size(89, 20)
        Me.txtParidad.TabIndex = 3
        Me.txtParidad.Visible = False
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(341, 60)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(96, 13)
        Me.Label43.TabIndex = 45
        Me.Label43.Text = "Paridad Monetaria:"
        Me.Label43.Visible = False
        '
        'cboMoneda
        '
        Me.cboMoneda.AutoCompleteCustomSource.AddRange(New String() {"No Deprecia", "Lineal", "Producción"})
        Me.cboMoneda.FormattingEnabled = True
        Me.cboMoneda.Location = New System.Drawing.Point(246, 73)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(89, 21)
        Me.cboMoneda.TabIndex = 2
        Me.cboMoneda.Visible = False
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(246, 59)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(49, 13)
        Me.Label41.TabIndex = 43
        Me.Label41.Text = "Moneda:"
        Me.Label41.Visible = False
        '
        'grupoDepTributaria
        '
        Me.grupoDepTributaria.Controls.Add(Me.Label21)
        Me.grupoDepTributaria.Controls.Add(Me.txtTasaDeprecTrib)
        Me.grupoDepTributaria.Controls.Add(Me.cboTipoDepTribut)
        Me.grupoDepTributaria.Controls.Add(Me.Label36)
        Me.grupoDepTributaria.Controls.Add(Me.Label42)
        Me.grupoDepTributaria.Controls.Add(Me.txtVidaUtTribut)
        Me.grupoDepTributaria.Controls.Add(Me.Label44)
        Me.grupoDepTributaria.Location = New System.Drawing.Point(8, 122)
        Me.grupoDepTributaria.Name = "grupoDepTributaria"
        Me.grupoDepTributaria.Size = New System.Drawing.Size(465, 63)
        Me.grupoDepTributaria.TabIndex = 8
        Me.grupoDepTributaria.TabStop = False
        Me.grupoDepTributaria.Text = "Depreciación Tributaria"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(378, 35)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(15, 13)
        Me.Label21.TabIndex = 8
        Me.Label21.Text = "%"
        '
        'txtTasaDeprecTrib
        '
        Me.txtTasaDeprecTrib.Location = New System.Drawing.Point(278, 31)
        Me.txtTasaDeprecTrib.Name = "txtTasaDeprecTrib"
        Me.txtTasaDeprecTrib.Size = New System.Drawing.Size(97, 20)
        Me.txtTasaDeprecTrib.TabIndex = 7
        '
        'cboTipoDepTribut
        '
        Me.cboTipoDepTribut.AutoCompleteCustomSource.AddRange(New String() {"No Deprecia", "Lineal F", "Producción", "Lineal Tasa"})
        Me.cboTipoDepTribut.FormattingEnabled = True
        Me.cboTipoDepTribut.Items.AddRange(New Object() {"No Deprecia", "Lineal Tasa"})
        Me.cboTipoDepTribut.Location = New System.Drawing.Point(19, 31)
        Me.cboTipoDepTribut.Name = "cboTipoDepTribut"
        Me.cboTipoDepTribut.Size = New System.Drawing.Size(116, 21)
        Me.cboTipoDepTribut.TabIndex = 6
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(16, 17)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(28, 13)
        Me.Label36.TabIndex = 41
        Me.Label36.Text = "Tipo"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(275, 17)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(100, 13)
        Me.Label42.TabIndex = 6
        Me.Label42.Text = "Tasa Depreciación:"
        '
        'txtVidaUtTribut
        '
        Me.txtVidaUtTribut.Location = New System.Drawing.Point(157, 31)
        Me.txtVidaUtTribut.Name = "txtVidaUtTribut"
        Me.txtVidaUtTribut.Size = New System.Drawing.Size(102, 20)
        Me.txtVidaUtTribut.TabIndex = 3
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(154, 18)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(49, 13)
        Me.Label44.TabIndex = 2
        Me.Label44.Text = "Vida Útil:"
        '
        'grupoDepFinanciera
        '
        Me.grupoDepFinanciera.Controls.Add(Me.txtUndProdConta)
        Me.grupoDepFinanciera.Controls.Add(Me.Label34)
        Me.grupoDepFinanciera.Controls.Add(Me.txtVidaUtConta)
        Me.grupoDepFinanciera.Controls.Add(Me.cboTipoDepFinanc)
        Me.grupoDepFinanciera.Controls.Add(Me.Label33)
        Me.grupoDepFinanciera.Controls.Add(Me.Label35)
        Me.grupoDepFinanciera.Location = New System.Drawing.Point(494, 122)
        Me.grupoDepFinanciera.Name = "grupoDepFinanciera"
        Me.grupoDepFinanciera.Size = New System.Drawing.Size(425, 63)
        Me.grupoDepFinanciera.TabIndex = 7
        Me.grupoDepFinanciera.TabStop = False
        Me.grupoDepFinanciera.Text = "Depreciación Financiera"
        '
        'txtUndProdConta
        '
        Me.txtUndProdConta.Location = New System.Drawing.Point(266, 28)
        Me.txtUndProdConta.Name = "txtUndProdConta"
        Me.txtUndProdConta.Size = New System.Drawing.Size(80, 20)
        Me.txtUndProdConta.TabIndex = 5
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(263, 16)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(83, 13)
        Me.Label34.TabIndex = 4
        Me.Label34.Text = "Unidades Prod.:"
        '
        'txtVidaUtConta
        '
        Me.txtVidaUtConta.Location = New System.Drawing.Point(166, 29)
        Me.txtVidaUtConta.Name = "txtVidaUtConta"
        Me.txtVidaUtConta.Size = New System.Drawing.Size(77, 20)
        Me.txtVidaUtConta.TabIndex = 3
        '
        'cboTipoDepFinanc
        '
        Me.cboTipoDepFinanc.AutoCompleteCustomSource.AddRange(New String() {"No Deprecia", "Lineal", "Producción"})
        Me.cboTipoDepFinanc.FormattingEnabled = True
        Me.cboTipoDepFinanc.ItemHeight = 13
        Me.cboTipoDepFinanc.Items.AddRange(New Object() {"No Deprecia", "Lineal", "Producción"})
        Me.cboTipoDepFinanc.Location = New System.Drawing.Point(28, 28)
        Me.cboTipoDepFinanc.Name = "cboTipoDepFinanc"
        Me.cboTipoDepFinanc.Size = New System.Drawing.Size(116, 21)
        Me.cboTipoDepFinanc.TabIndex = 5
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(167, 17)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(49, 13)
        Me.Label33.TabIndex = 2
        Me.Label33.Text = "Vida Útil:"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(25, 16)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(28, 13)
        Me.Label35.TabIndex = 40
        Me.Label35.Text = "Tipo"
        '
        'txtIdentifNombre4
        '
        Me.txtIdentifNombre4.Location = New System.Drawing.Point(286, 285)
        Me.txtIdentifNombre4.Name = "txtIdentifNombre4"
        Me.txtIdentifNombre4.Size = New System.Drawing.Size(339, 20)
        Me.txtIdentifNombre4.TabIndex = 20
        '
        'txtIdentifCodigo4
        '
        Me.txtIdentifCodigo4.Location = New System.Drawing.Point(136, 285)
        Me.txtIdentifCodigo4.Name = "txtIdentifCodigo4"
        Me.txtIdentifCodigo4.Size = New System.Drawing.Size(125, 20)
        Me.txtIdentifCodigo4.TabIndex = 18
        '
        'txtIdentifNombre3
        '
        Me.txtIdentifNombre3.Location = New System.Drawing.Point(286, 259)
        Me.txtIdentifNombre3.Name = "txtIdentifNombre3"
        Me.txtIdentifNombre3.Size = New System.Drawing.Size(339, 20)
        Me.txtIdentifNombre3.TabIndex = 17
        '
        'txtIdentifCodigo3
        '
        Me.txtIdentifCodigo3.Location = New System.Drawing.Point(136, 259)
        Me.txtIdentifCodigo3.Name = "txtIdentifCodigo3"
        Me.txtIdentifCodigo3.Size = New System.Drawing.Size(125, 20)
        Me.txtIdentifCodigo3.TabIndex = 15
        '
        'txtIdentifNombre2
        '
        Me.txtIdentifNombre2.Location = New System.Drawing.Point(286, 233)
        Me.txtIdentifNombre2.Name = "txtIdentifNombre2"
        Me.txtIdentifNombre2.Size = New System.Drawing.Size(339, 20)
        Me.txtIdentifNombre2.TabIndex = 14
        '
        'txtIdentifCodigo2
        '
        Me.txtIdentifCodigo2.Location = New System.Drawing.Point(136, 233)
        Me.txtIdentifCodigo2.Name = "txtIdentifCodigo2"
        Me.txtIdentifCodigo2.Size = New System.Drawing.Size(125, 20)
        Me.txtIdentifCodigo2.TabIndex = 12
        '
        'txtIdentifNombre1
        '
        Me.txtIdentifNombre1.Location = New System.Drawing.Point(286, 207)
        Me.txtIdentifNombre1.Name = "txtIdentifNombre1"
        Me.txtIdentifNombre1.Size = New System.Drawing.Size(339, 20)
        Me.txtIdentifNombre1.TabIndex = 11
        '
        'txtIdentifCodigo1
        '
        Me.txtIdentifCodigo1.Location = New System.Drawing.Point(136, 207)
        Me.txtIdentifCodigo1.Name = "txtIdentifCodigo1"
        Me.txtIdentifCodigo1.Size = New System.Drawing.Size(125, 20)
        Me.txtIdentifCodigo1.TabIndex = 9
        '
        'btnIdentifCont4
        '
        Me.btnIdentifCont4.Location = New System.Drawing.Point(258, 285)
        Me.btnIdentifCont4.Name = "btnIdentifCont4"
        Me.btnIdentifCont4.Size = New System.Drawing.Size(22, 20)
        Me.btnIdentifCont4.TabIndex = 19
        Me.btnIdentifCont4.Text = "..."
        Me.btnIdentifCont4.UseVisualStyleBackColor = True
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(9, 287)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(121, 13)
        Me.Label32.TabIndex = 22
        Me.Label32.Text = "Identificativo Contable4:"
        '
        'btnIdentifCont3
        '
        Me.btnIdentifCont3.Location = New System.Drawing.Point(258, 259)
        Me.btnIdentifCont3.Name = "btnIdentifCont3"
        Me.btnIdentifCont3.Size = New System.Drawing.Size(22, 20)
        Me.btnIdentifCont3.TabIndex = 16
        Me.btnIdentifCont3.Text = "..."
        Me.btnIdentifCont3.UseVisualStyleBackColor = True
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(9, 261)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(121, 13)
        Me.Label31.TabIndex = 18
        Me.Label31.Text = "Identificativo Contable3:"
        '
        'btnIdentifCont2
        '
        Me.btnIdentifCont2.Location = New System.Drawing.Point(258, 233)
        Me.btnIdentifCont2.Name = "btnIdentifCont2"
        Me.btnIdentifCont2.Size = New System.Drawing.Size(22, 20)
        Me.btnIdentifCont2.TabIndex = 13
        Me.btnIdentifCont2.Text = "..."
        Me.btnIdentifCont2.UseVisualStyleBackColor = True
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(9, 235)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(121, 13)
        Me.Label30.TabIndex = 14
        Me.Label30.Text = "Identificativo Contable2:"
        '
        'btnIdentifCont1
        '
        Me.btnIdentifCont1.Location = New System.Drawing.Point(258, 207)
        Me.btnIdentifCont1.Name = "btnIdentifCont1"
        Me.btnIdentifCont1.Size = New System.Drawing.Size(22, 20)
        Me.btnIdentifCont1.TabIndex = 10
        Me.btnIdentifCont1.Text = "..."
        Me.btnIdentifCont1.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(9, 209)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(121, 13)
        Me.Label29.TabIndex = 9
        Me.Label29.Text = "Identificativo Contable1:"
        '
        'TabCaracteristicas
        '
        Me.TabCaracteristicas.BackColor = System.Drawing.Color.LightSteelBlue
        Me.TabCaracteristicas.Controls.Add(Me.txtCantidad)
        Me.TabCaracteristicas.Controls.Add(Me.txtEstado)
        Me.TabCaracteristicas.Controls.Add(Me.TxtLote)
        Me.TabCaracteristicas.Controls.Add(Me.txtSerie)
        Me.TabCaracteristicas.Controls.Add(Me.txtMarca)
        Me.TabCaracteristicas.Controls.Add(Me.txtActivoCmpstoNombre)
        Me.TabCaracteristicas.Controls.Add(Me.txtActivoCmpstoCod)
        Me.TabCaracteristicas.Controls.Add(Me.txtDescrip)
        Me.TabCaracteristicas.Controls.Add(Me.txtCodigo)
        Me.TabCaracteristicas.Controls.Add(Me.grupoUbicacion)
        Me.TabCaracteristicas.Controls.Add(Me.chkComponente)
        Me.TabCaracteristicas.Controls.Add(Me.btnBuscaActivoCmpsto)
        Me.TabCaracteristicas.Controls.Add(Me.cboSubg)
        Me.TabCaracteristicas.Controls.Add(Me.cboGrupo)
        Me.TabCaracteristicas.Controls.Add(Me.cboClase)
        Me.TabCaracteristicas.Controls.Add(Me.cboCategoria)
        Me.TabCaracteristicas.Controls.Add(Me.cboTipoActivos)
        Me.TabCaracteristicas.Controls.Add(Me.imgImagen)
        Me.TabCaracteristicas.Controls.Add(Me.Label6)
        Me.TabCaracteristicas.Controls.Add(Me.Label5)
        Me.TabCaracteristicas.Controls.Add(Me.Label4)
        Me.TabCaracteristicas.Controls.Add(Me.Label3)
        Me.TabCaracteristicas.Controls.Add(Me.Label2)
        Me.TabCaracteristicas.Controls.Add(Me.Label11)
        Me.TabCaracteristicas.Controls.Add(Me.Label1)
        Me.TabCaracteristicas.Controls.Add(Me.Label12)
        Me.TabCaracteristicas.Controls.Add(Me.Label45)
        Me.TabCaracteristicas.Controls.Add(Me.Label10)
        Me.TabCaracteristicas.Controls.Add(Me.Label9)
        Me.TabCaracteristicas.Controls.Add(Me.Label8)
        Me.TabCaracteristicas.Location = New System.Drawing.Point(4, 22)
        Me.TabCaracteristicas.Name = "TabCaracteristicas"
        Me.TabCaracteristicas.Padding = New System.Windows.Forms.Padding(3)
        Me.TabCaracteristicas.Size = New System.Drawing.Size(927, 359)
        Me.TabCaracteristicas.TabIndex = 0
        Me.TabCaracteristicas.Text = "Caracteristicas"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(120, 150)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(96, 20)
        Me.txtCantidad.TabIndex = 8
        '
        'txtEstado
        '
        Me.txtEstado.Location = New System.Drawing.Point(544, 62)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.Size = New System.Drawing.Size(152, 20)
        Me.txtEstado.TabIndex = 16
        '
        'TxtLote
        '
        Me.TxtLote.Location = New System.Drawing.Point(492, 150)
        Me.TxtLote.Name = "TxtLote"
        Me.TxtLote.Size = New System.Drawing.Size(116, 20)
        Me.TxtLote.TabIndex = 15
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(361, 150)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(116, 20)
        Me.txtSerie.TabIndex = 14
        '
        'txtMarca
        '
        Me.txtMarca.Location = New System.Drawing.Point(230, 150)
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.Size = New System.Drawing.Size(116, 20)
        Me.txtMarca.TabIndex = 13
        '
        'txtActivoCmpstoNombre
        '
        Me.txtActivoCmpstoNombre.Enabled = False
        Me.txtActivoCmpstoNombre.Location = New System.Drawing.Point(292, 101)
        Me.txtActivoCmpstoNombre.Name = "txtActivoCmpstoNombre"
        Me.txtActivoCmpstoNombre.Size = New System.Drawing.Size(292, 20)
        Me.txtActivoCmpstoNombre.TabIndex = 12
        '
        'txtActivoCmpstoCod
        '
        Me.txtActivoCmpstoCod.Enabled = False
        Me.txtActivoCmpstoCod.Location = New System.Drawing.Point(192, 102)
        Me.txtActivoCmpstoCod.Name = "txtActivoCmpstoCod"
        Me.txtActivoCmpstoCod.Size = New System.Drawing.Size(97, 20)
        Me.txtActivoCmpstoCod.TabIndex = 10
        '
        'txtDescrip
        '
        Me.txtDescrip.Location = New System.Drawing.Point(120, 62)
        Me.txtDescrip.Name = "txtDescrip"
        Me.txtDescrip.Size = New System.Drawing.Size(413, 20)
        Me.txtDescrip.TabIndex = 6
        '
        'txtCodigo
        '
        Me.txtCodigo.AcceptsTab = True
        Me.txtCodigo.Location = New System.Drawing.Point(8, 62)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(96, 20)
        Me.txtCodigo.TabIndex = 5
        '
        'grupoUbicacion
        '
        Me.grupoUbicacion.Controls.Add(Me.btnSucursal)
        Me.grupoUbicacion.Controls.Add(Me.txtCCosto)
        Me.grupoUbicacion.Controls.Add(Me.txtResp)
        Me.grupoUbicacion.Controls.Add(Me.txtSucursal)
        Me.grupoUbicacion.Controls.Add(Me.txtRespCod)
        Me.grupoUbicacion.Controls.Add(Me.btnSeccion)
        Me.grupoUbicacion.Controls.Add(Me.btnDpto)
        Me.grupoUbicacion.Controls.Add(Me.txtSeccion)
        Me.grupoUbicacion.Controls.Add(Me.txtDepartamento)
        Me.grupoUbicacion.Controls.Add(Me.Label15)
        Me.grupoUbicacion.Controls.Add(Me.Label16)
        Me.grupoUbicacion.Controls.Add(Me.Label14)
        Me.grupoUbicacion.Controls.Add(Me.Label17)
        Me.grupoUbicacion.Controls.Add(Me.btnResponsable)
        Me.grupoUbicacion.Controls.Add(Me.Label24)
        Me.grupoUbicacion.Controls.Add(Me.btnCCosto)
        Me.grupoUbicacion.Location = New System.Drawing.Point(8, 193)
        Me.grupoUbicacion.Name = "grupoUbicacion"
        Me.grupoUbicacion.Size = New System.Drawing.Size(672, 144)
        Me.grupoUbicacion.TabIndex = 45
        Me.grupoUbicacion.TabStop = False
        Me.grupoUbicacion.Text = "Ubicación"
        '
        'btnSucursal
        '
        Me.btnSucursal.Location = New System.Drawing.Point(194, 25)
        Me.btnSucursal.Name = "btnSucursal"
        Me.btnSucursal.Size = New System.Drawing.Size(21, 20)
        Me.btnSucursal.TabIndex = 2
        Me.btnSucursal.Text = "..."
        Me.btnSucursal.UseVisualStyleBackColor = True
        '
        'txtCCosto
        '
        Me.txtCCosto.Location = New System.Drawing.Point(8, 71)
        Me.txtCCosto.Name = "txtCCosto"
        Me.txtCCosto.Size = New System.Drawing.Size(124, 20)
        Me.txtCCosto.TabIndex = 47
        '
        'txtResp
        '
        Me.txtResp.Location = New System.Drawing.Point(160, 112)
        Me.txtResp.Name = "txtResp"
        Me.txtResp.Size = New System.Drawing.Size(451, 20)
        Me.txtResp.TabIndex = 51
        '
        'txtSucursal
        '
        Me.txtSucursal.Location = New System.Drawing.Point(6, 25)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.Size = New System.Drawing.Size(191, 20)
        Me.txtSucursal.TabIndex = 1
        '
        'txtRespCod
        '
        Me.txtRespCod.Location = New System.Drawing.Point(9, 111)
        Me.txtRespCod.Name = "txtRespCod"
        Me.txtRespCod.Size = New System.Drawing.Size(127, 20)
        Me.txtRespCod.TabIndex = 49
        '
        'btnSeccion
        '
        Me.btnSeccion.Location = New System.Drawing.Point(635, 25)
        Me.btnSeccion.Name = "btnSeccion"
        Me.btnSeccion.Size = New System.Drawing.Size(21, 20)
        Me.btnSeccion.TabIndex = 6
        Me.btnSeccion.Text = "..."
        Me.btnSeccion.UseVisualStyleBackColor = True
        '
        'btnDpto
        '
        Me.btnDpto.Location = New System.Drawing.Point(415, 25)
        Me.btnDpto.Name = "btnDpto"
        Me.btnDpto.Size = New System.Drawing.Size(21, 20)
        Me.btnDpto.TabIndex = 4
        Me.btnDpto.Text = "..."
        Me.btnDpto.UseVisualStyleBackColor = True
        '
        'txtSeccion
        '
        Me.txtSeccion.Location = New System.Drawing.Point(444, 25)
        Me.txtSeccion.Name = "txtSeccion"
        Me.txtSeccion.Size = New System.Drawing.Size(191, 20)
        Me.txtSeccion.TabIndex = 5
        '
        'txtDepartamento
        '
        Me.txtDepartamento.Location = New System.Drawing.Point(224, 25)
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.Size = New System.Drawing.Size(191, 20)
        Me.txtDepartamento.TabIndex = 3
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(294, 12)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(77, 13)
        Me.Label15.TabIndex = 16
        Me.Label15.Text = "Departamento:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(512, 13)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(49, 13)
        Me.Label16.TabIndex = 18
        Me.Label16.Text = "Sección:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 12)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(51, 13)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "Sucursal:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(3, 98)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(72, 13)
        Me.Label17.TabIndex = 46
        Me.Label17.Text = "Responsable:"
        '
        'btnResponsable
        '
        Me.btnResponsable.Location = New System.Drawing.Point(136, 112)
        Me.btnResponsable.Name = "btnResponsable"
        Me.btnResponsable.Size = New System.Drawing.Size(21, 20)
        Me.btnResponsable.TabIndex = 50
        Me.btnResponsable.Text = "..."
        Me.btnResponsable.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(5, 59)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(55, 13)
        Me.Label24.TabIndex = 52
        Me.Label24.Text = "C. Costos:"
        '
        'btnCCosto
        '
        Me.btnCCosto.Location = New System.Drawing.Point(132, 71)
        Me.btnCCosto.Name = "btnCCosto"
        Me.btnCCosto.Size = New System.Drawing.Size(21, 20)
        Me.btnCCosto.TabIndex = 48
        Me.btnCCosto.Text = "..."
        Me.btnCCosto.UseVisualStyleBackColor = True
        '
        'btnBuscaActivoCmpsto
        '
        Me.btnBuscaActivoCmpsto.Enabled = False
        Me.btnBuscaActivoCmpsto.Location = New System.Drawing.Point(169, 101)
        Me.btnBuscaActivoCmpsto.Name = "btnBuscaActivoCmpsto"
        Me.btnBuscaActivoCmpsto.Size = New System.Drawing.Size(23, 21)
        Me.btnBuscaActivoCmpsto.TabIndex = 11
        Me.btnBuscaActivoCmpsto.Text = "..."
        Me.btnBuscaActivoCmpsto.UseVisualStyleBackColor = True
        '
        'cboSubg
        '
        Me.cboSubg.FormattingEnabled = True
        Me.cboSubg.Location = New System.Drawing.Point(727, 239)
        Me.cboSubg.Name = "cboSubg"
        Me.cboSubg.Size = New System.Drawing.Size(170, 21)
        Me.cboSubg.TabIndex = 4
        Me.cboSubg.Visible = False
        '
        'cboGrupo
        '
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Location = New System.Drawing.Point(465, 18)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(221, 21)
        Me.cboGrupo.TabIndex = 3
        '
        'cboClase
        '
        Me.cboClase.FormattingEnabled = True
        Me.cboClase.Location = New System.Drawing.Point(233, 18)
        Me.cboClase.Name = "cboClase"
        Me.cboClase.Size = New System.Drawing.Size(221, 21)
        Me.cboClase.TabIndex = 2
        '
        'cboCategoria
        '
        Me.cboCategoria.FormattingEnabled = True
        Me.cboCategoria.Location = New System.Drawing.Point(2, 18)
        Me.cboCategoria.Name = "cboCategoria"
        Me.cboCategoria.Size = New System.Drawing.Size(221, 21)
        Me.cboCategoria.TabIndex = 1
        '
        'cboTipoActivos
        '
        Me.cboTipoActivos.FormattingEnabled = True
        Me.cboTipoActivos.ItemHeight = 13
        Me.cboTipoActivos.Items.AddRange(New Object() {"Tangibles", "Intangibles"})
        Me.cboTipoActivos.Location = New System.Drawing.Point(8, 149)
        Me.cboTipoActivos.Name = "cboTipoActivos"
        Me.cboTipoActivos.Size = New System.Drawing.Size(96, 21)
        Me.cboTipoActivos.TabIndex = 7
        '
        'imgImagen
        '
        Me.imgImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgImagen.Location = New System.Drawing.Point(704, 21)
        Me.imgImagen.Name = "imgImagen"
        Me.imgImagen.Size = New System.Drawing.Size(217, 149)
        Me.imgImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgImagen.TabIndex = 28
        Me.imgImagen.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(777, 225)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Subgrupo:"
        Me.Label6.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(462, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Grupo:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(231, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Clase:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(3, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Categoría:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(117, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Descripción"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(541, 50)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 13)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Estado:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(117, 137)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 13)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "Cantidad:"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(4, 135)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(84, 13)
        Me.Label45.TabIndex = 30
        Me.Label45.Text = "Tipo de Activos:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(488, 137)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Nro Lot.:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(357, 137)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Serie:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(227, 138)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Marca:"
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabCaracteristicas)
        Me.TabControl.Controls.Add(Me.TabContabilidad)
        Me.TabControl.Controls.Add(Me.TabSeguro)
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl.Location = New System.Drawing.Point(0, 46)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(935, 385)
        Me.TabControl.TabIndex = 5
        '
        'MantAF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(935, 431)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl)
        Me.Controls.Add(Me.ToolStripMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MantAF"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento Activos Fijos"
        Me.ToolStripMenu.ResumeLayout(False)
        Me.ToolStripMenu.PerformLayout()
        Me.TabSeguro.ResumeLayout(False)
        Me.TabSeguro.PerformLayout()
        Me.TabContabilidad.ResumeLayout(False)
        Me.TabContabilidad.PerformLayout()
        Me.grupoSalida.ResumeLayout(False)
        Me.grupoSalida.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.grupoDepTributaria.ResumeLayout(False)
        Me.grupoDepTributaria.PerformLayout()
        Me.grupoDepFinanciera.ResumeLayout(False)
        Me.grupoDepFinanciera.PerformLayout()
        Me.TabCaracteristicas.ResumeLayout(False)
        Me.TabCaracteristicas.PerformLayout()
        Me.grupoUbicacion.ResumeLayout(False)
        Me.grupoUbicacion.PerformLayout()
        CType(Me.imgImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnAbrir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnReporte As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabSeguro As System.Windows.Forms.TabPage
    Friend WithEvents txtFechaFinS As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtFechaInicioS As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtAsegCod As System.Windows.Forms.TextBox
    Friend WithEvents txtPagoM As System.Windows.Forms.TextBox
    Friend WithEvents txtDeducible As System.Windows.Forms.TextBox
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents txtContrato As System.Windows.Forms.TextBox
    Friend WithEvents txtAseguradora As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TabContabilidad As System.Windows.Forms.TabPage
    Friend WithEvents grupoSalida As System.Windows.Forms.GroupBox
    Friend WithEvents Txtfechasal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents txtNDocSal As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtDocSal As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtFechaIng As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnParidad As System.Windows.Forms.Button
    Friend WithEvents txtNDocIng As System.Windows.Forms.TextBox
    Friend WithEvents txtParidad As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents txtDocIng As System.Windows.Forms.TextBox
    Friend WithEvents cboMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtCostoIng As System.Windows.Forms.TextBox
    Friend WithEvents grupoDepTributaria As System.Windows.Forms.GroupBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtTasaDeprecTrib As System.Windows.Forms.TextBox
    Friend WithEvents cboTipoDepTribut As System.Windows.Forms.ComboBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtVidaUtTribut As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents grupoDepFinanciera As System.Windows.Forms.GroupBox
    Friend WithEvents txtUndProdConta As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtVidaUtConta As System.Windows.Forms.TextBox
    Friend WithEvents cboTipoDepFinanc As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtIdentifNombre4 As System.Windows.Forms.TextBox
    Friend WithEvents txtIdentifCodigo4 As System.Windows.Forms.TextBox
    Friend WithEvents txtIdentifNombre3 As System.Windows.Forms.TextBox
    Friend WithEvents txtIdentifCodigo3 As System.Windows.Forms.TextBox
    Friend WithEvents txtIdentifNombre2 As System.Windows.Forms.TextBox
    Friend WithEvents txtIdentifCodigo2 As System.Windows.Forms.TextBox
    Friend WithEvents txtIdentifNombre1 As System.Windows.Forms.TextBox
    Friend WithEvents txtIdentifCodigo1 As System.Windows.Forms.TextBox
    Friend WithEvents txtValRes As System.Windows.Forms.TextBox
    Friend WithEvents btnIdentifCont4 As System.Windows.Forms.Button
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents btnIdentifCont3 As System.Windows.Forms.Button
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents btnIdentifCont2 As System.Windows.Forms.Button
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents btnIdentifCont1 As System.Windows.Forms.Button
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents TabCaracteristicas As System.Windows.Forms.TabPage
    Friend WithEvents txtCCosto As System.Windows.Forms.TextBox
    Friend WithEvents txtResp As System.Windows.Forms.TextBox
    Friend WithEvents txtRespCod As System.Windows.Forms.TextBox
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents TxtLote As System.Windows.Forms.TextBox
    Friend WithEvents txtSerie As System.Windows.Forms.TextBox
    Friend WithEvents txtMarca As System.Windows.Forms.TextBox
    Friend WithEvents txtActivoCmpstoNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtActivoCmpstoCod As System.Windows.Forms.TextBox
    Friend WithEvents txtDescrip As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents btnCCosto As System.Windows.Forms.Button
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents btnResponsable As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents grupoUbicacion As System.Windows.Forms.GroupBox
    Friend WithEvents btnSucursal As System.Windows.Forms.Button
    Friend WithEvents txtSucursal As System.Windows.Forms.TextBox
    Friend WithEvents btnSeccion As System.Windows.Forms.Button
    Friend WithEvents btnDpto As System.Windows.Forms.Button
    Friend WithEvents txtSeccion As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents chkComponente As System.Windows.Forms.CheckBox
    Friend WithEvents btnBuscaActivoCmpsto As System.Windows.Forms.Button
    Friend WithEvents cboSubg As System.Windows.Forms.ComboBox
    Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents cboClase As System.Windows.Forms.ComboBox
    Friend WithEvents cboCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents cboTipoActivos As System.Windows.Forms.ComboBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents imgImagen As System.Windows.Forms.PictureBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabControl As System.Windows.Forms.TabControl

End Class
