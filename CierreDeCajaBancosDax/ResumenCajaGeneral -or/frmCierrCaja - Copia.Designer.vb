<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCierrCaja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCierrCaja))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GrupoFiltros = New System.Windows.Forms.GroupBox()
        Me.cmbSucursal = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboPtoVta = New System.Windows.Forms.ComboBox()
        Me.GrupoEntregaCaja = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.Label()
        Me.NroLoteTarjetas = New System.Windows.Forms.TextBox()
        Me.txtCantTarjetas = New System.Windows.Forms.TextBox()
        Me.txtTarjetas = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCantCheques = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtEfectivo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCheques = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Grupo = New System.Windows.Forms.GroupBox()
        Me.txtFechaAl = New System.Windows.Forms.DateTimePicker()
        Me.txtFechaDel = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.btnOpciones = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnActualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnResumenGeneral = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnAbrir = New System.Windows.Forms.ToolStripButton()
        Me.btnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.btnPdfOriginal = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnMovimientos = New System.Windows.Forms.ToolStripButton()
        Me.btnConfimaCierre = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.GrupoRecumenGenerarl = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GrupoFiltros.SuspendLayout()
        Me.GrupoEntregaCaja.SuspendLayout()
        Me.Grupo.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GrupoRecumenGenerarl.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 50)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GrupoFiltros)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GrupoEntregaCaja)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Grupo)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ReportViewer1)
        Me.SplitContainer1.Size = New System.Drawing.Size(917, 481)
        Me.SplitContainer1.SplitterDistance = 250
        Me.SplitContainer1.TabIndex = 1
        '
        'GrupoFiltros
        '
        Me.GrupoFiltros.Controls.Add(Me.cmbSucursal)
        Me.GrupoFiltros.Controls.Add(Me.Label3)
        Me.GrupoFiltros.Controls.Add(Me.Label9)
        Me.GrupoFiltros.Controls.Add(Me.cboPtoVta)
        Me.GrupoFiltros.Location = New System.Drawing.Point(6, 102)
        Me.GrupoFiltros.Name = "GrupoFiltros"
        Me.GrupoFiltros.Size = New System.Drawing.Size(241, 109)
        Me.GrupoFiltros.TabIndex = 8
        Me.GrupoFiltros.TabStop = False
        Me.GrupoFiltros.Text = "Filtros"
        '
        'cmbSucursal
        '
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.Location = New System.Drawing.Point(8, 38)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(231, 21)
        Me.cmbSucursal.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "PuntoVenta:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Sucursal :"
        '
        'cboPtoVta
        '
        Me.cboPtoVta.FormattingEnabled = True
        Me.cboPtoVta.Location = New System.Drawing.Point(5, 80)
        Me.cboPtoVta.Name = "cboPtoVta"
        Me.cboPtoVta.Size = New System.Drawing.Size(231, 21)
        Me.cboPtoVta.TabIndex = 5
        '
        'GrupoEntregaCaja
        '
        Me.GrupoEntregaCaja.Controls.Add(Me.GrupoRecumenGenerarl)
        Me.GrupoEntregaCaja.Controls.Add(Me.Label13)
        Me.GrupoEntregaCaja.Controls.Add(Me.txtTotal)
        Me.GrupoEntregaCaja.Controls.Add(Me.NroLoteTarjetas)
        Me.GrupoEntregaCaja.Controls.Add(Me.txtCantTarjetas)
        Me.GrupoEntregaCaja.Controls.Add(Me.txtTarjetas)
        Me.GrupoEntregaCaja.Controls.Add(Me.Label4)
        Me.GrupoEntregaCaja.Controls.Add(Me.txtCantCheques)
        Me.GrupoEntregaCaja.Controls.Add(Me.Label8)
        Me.GrupoEntregaCaja.Controls.Add(Me.Label7)
        Me.GrupoEntregaCaja.Controls.Add(Me.txtEfectivo)
        Me.GrupoEntregaCaja.Controls.Add(Me.Label1)
        Me.GrupoEntregaCaja.Controls.Add(Me.txtCheques)
        Me.GrupoEntregaCaja.Controls.Add(Me.Label2)
        Me.GrupoEntregaCaja.Controls.Add(Me.Label11)
        Me.GrupoEntregaCaja.Location = New System.Drawing.Point(6, 224)
        Me.GrupoEntregaCaja.Name = "GrupoEntregaCaja"
        Me.GrupoEntregaCaja.Size = New System.Drawing.Size(241, 182)
        Me.GrupoEntregaCaja.TabIndex = 1
        Me.GrupoEntregaCaja.TabStop = False
        Me.GrupoEntregaCaja.Text = "Entregado por caja"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(65, 155)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(45, 13)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "TOTAL:"
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.White
        Me.txtTotal.Location = New System.Drawing.Point(122, 155)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(81, 13)
        Me.txtTotal.TabIndex = 18
        Me.txtTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'NroLoteTarjetas
        '
        Me.NroLoteTarjetas.Location = New System.Drawing.Point(53, 124)
        Me.NroLoteTarjetas.Name = "NroLoteTarjetas"
        Me.NroLoteTarjetas.Size = New System.Drawing.Size(67, 20)
        Me.NroLoteTarjetas.TabIndex = 16
        '
        'txtCantTarjetas
        '
        Me.txtCantTarjetas.Location = New System.Drawing.Point(84, 100)
        Me.txtCantTarjetas.Name = "txtCantTarjetas"
        Me.txtCantTarjetas.Size = New System.Drawing.Size(36, 20)
        Me.txtCantTarjetas.TabIndex = 15
        '
        'txtTarjetas
        '
        Me.txtTarjetas.Location = New System.Drawing.Point(122, 100)
        Me.txtTarjetas.Name = "txtTarjetas"
        Me.txtTarjetas.Size = New System.Drawing.Size(81, 20)
        Me.txtTarjetas.TabIndex = 14
        Me.txtTarjetas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Tarjetas :"
        '
        'txtCantCheques
        '
        Me.txtCantCheques.Location = New System.Drawing.Point(84, 74)
        Me.txtCantCheques.Name = "txtCantCheques"
        Me.txtCantCheques.Size = New System.Drawing.Size(36, 20)
        Me.txtCantCheques.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(138, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Valor"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(84, 29)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Cant."
        '
        'txtEfectivo
        '
        Me.txtEfectivo.Location = New System.Drawing.Point(122, 48)
        Me.txtEfectivo.Name = "txtEfectivo"
        Me.txtEfectivo.Size = New System.Drawing.Size(81, 20)
        Me.txtEfectivo.TabIndex = 7
        Me.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Efectivo :"
        '
        'txtCheques
        '
        Me.txtCheques.Location = New System.Drawing.Point(122, 74)
        Me.txtCheques.Name = "txtCheques"
        Me.txtCheques.Size = New System.Drawing.Size(81, 20)
        Me.txtCheques.TabIndex = 9
        Me.txtCheques.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Cheques :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 127)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 13)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Nro.Lote"
        '
        'Grupo
        '
        Me.Grupo.Controls.Add(Me.txtFechaAl)
        Me.Grupo.Controls.Add(Me.txtFechaDel)
        Me.Grupo.Controls.Add(Me.Label6)
        Me.Grupo.Controls.Add(Me.Label5)
        Me.Grupo.Location = New System.Drawing.Point(1, 7)
        Me.Grupo.Name = "Grupo"
        Me.Grupo.Size = New System.Drawing.Size(247, 86)
        Me.Grupo.TabIndex = 0
        Me.Grupo.TabStop = False
        Me.Grupo.Text = "Rango de Fechas:"
        '
        'txtFechaAl
        '
        Me.txtFechaAl.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.txtFechaAl.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaAl.Location = New System.Drawing.Point(30, 49)
        Me.txtFechaAl.Name = "txtFechaAl"
        Me.txtFechaAl.Size = New System.Drawing.Size(144, 20)
        Me.txtFechaAl.TabIndex = 17
        '
        'txtFechaDel
        '
        Me.txtFechaDel.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.txtFechaDel.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaDel.Location = New System.Drawing.Point(30, 23)
        Me.txtFechaDel.Name = "txtFechaDel"
        Me.txtFechaDel.Size = New System.Drawing.Size(144, 20)
        Me.txtFechaDel.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(19, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Al:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Del:"
        '
        'ReportViewer1
        '
        Me.ReportViewer1.AutoSize = True
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(663, 481)
        Me.ReportViewer1.TabIndex = 0
        '
        'btnOpciones
        '
        Me.btnOpciones.Image = CType(resources.GetObject("btnOpciones.Image"), System.Drawing.Image)
        Me.btnOpciones.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOpciones.Name = "btnOpciones"
        Me.btnOpciones.Size = New System.Drawing.Size(89, 47)
        Me.btnOpciones.Text = "Opciones"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 50)
        '
        'btnActualizar
        '
        Me.btnActualizar.Image = CType(resources.GetObject("btnActualizar.Image"), System.Drawing.Image)
        Me.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(94, 47)
        Me.btnActualizar.Text = "Actualizar "
        Me.btnActualizar.ToolTipText = "Actualizar reporte de caja con datos visibles"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 50)
        '
        'btnSalir
        '
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(61, 47)
        Me.btnSalir.Text = "Salir"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(28, 28)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOpciones, Me.BtnResumenGeneral, Me.ToolStripSeparator6, Me.btnAbrir, Me.btnCerrar, Me.btnPdfOriginal, Me.ToolStripSeparator5, Me.btnActualizar, Me.ToolStripSeparator2, Me.btnMovimientos, Me.ToolStripSeparator1, Me.btnConfimaCierre, Me.ToolStripSeparator3, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(917, 50)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtnResumenGeneral
        '
        Me.BtnResumenGeneral.Image = CType(resources.GetObject("BtnResumenGeneral.Image"), System.Drawing.Image)
        Me.BtnResumenGeneral.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnResumenGeneral.Name = "BtnResumenGeneral"
        Me.BtnResumenGeneral.Size = New System.Drawing.Size(159, 47)
        Me.BtnResumenGeneral.Text = "Actualizar información"
        Me.BtnResumenGeneral.ToolTipText = "Cuadre Caja General"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 50)
        '
        'btnAbrir
        '
        Me.btnAbrir.Image = CType(resources.GetObject("btnAbrir.Image"), System.Drawing.Image)
        Me.btnAbrir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.Size = New System.Drawing.Size(37, 47)
        Me.btnAbrir.Text = "Abrir"
        Me.btnAbrir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnAbrir.ToolTipText = "Abrir ciere de caja anteriormente registrado"
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(43, 47)
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnCerrar.ToolTipText = "Cerrar cierre de caja abierto"
        '
        'btnPdfOriginal
        '
        Me.btnPdfOriginal.Image = CType(resources.GetObject("btnPdfOriginal.Image"), System.Drawing.Image)
        Me.btnPdfOriginal.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPdfOriginal.Name = "btnPdfOriginal"
        Me.btnPdfOriginal.Size = New System.Drawing.Size(71, 47)
        Me.btnPdfOriginal.Text = "PdfOriginal"
        Me.btnPdfOriginal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnPdfOriginal.ToolTipText = "Ver copia de cierre de caja original"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 50)
        '
        'btnMovimientos
        '
        Me.btnMovimientos.Image = CType(resources.GetObject("btnMovimientos.Image"), System.Drawing.Image)
        Me.btnMovimientos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMovimientos.Name = "btnMovimientos"
        Me.btnMovimientos.Size = New System.Drawing.Size(142, 47)
        Me.btnMovimientos.Text = "Editar movimientos"
        Me.btnMovimientos.ToolTipText = "Ver ingresos y egresos de caja con eliminación"
        '
        'btnConfimaCierre
        '
        Me.btnConfimaCierre.Image = CType(resources.GetObject("btnConfimaCierre.Image"), System.Drawing.Image)
        Me.btnConfimaCierre.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnConfimaCierre.Name = "btnConfimaCierre"
        Me.btnConfimaCierre.Size = New System.Drawing.Size(88, 47)
        Me.btnConfimaCierre.Text = "RegistrarCierre"
        Me.btnConfimaCierre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnConfimaCierre.ToolTipText = "Registrar cierre de caja definitivo"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 50)
        '
        'GrupoRecumenGenerarl
        '
        Me.GrupoRecumenGenerarl.Controls.Add(Me.Label10)
        Me.GrupoRecumenGenerarl.Controls.Add(Me.Label12)
        Me.GrupoRecumenGenerarl.Controls.Add(Me.TextBox1)
        Me.GrupoRecumenGenerarl.Controls.Add(Me.TextBox2)
        Me.GrupoRecumenGenerarl.Controls.Add(Me.TextBox3)
        Me.GrupoRecumenGenerarl.Controls.Add(Me.Label14)
        Me.GrupoRecumenGenerarl.Controls.Add(Me.TextBox4)
        Me.GrupoRecumenGenerarl.Controls.Add(Me.Label15)
        Me.GrupoRecumenGenerarl.Controls.Add(Me.Label16)
        Me.GrupoRecumenGenerarl.Controls.Add(Me.TextBox5)
        Me.GrupoRecumenGenerarl.Controls.Add(Me.Label17)
        Me.GrupoRecumenGenerarl.Controls.Add(Me.TextBox6)
        Me.GrupoRecumenGenerarl.Controls.Add(Me.Label18)
        Me.GrupoRecumenGenerarl.Controls.Add(Me.Label19)
        Me.GrupoRecumenGenerarl.Location = New System.Drawing.Point(1, 0)
        Me.GrupoRecumenGenerarl.Name = "GrupoRecumenGenerarl"
        Me.GrupoRecumenGenerarl.Size = New System.Drawing.Size(241, 182)
        Me.GrupoRecumenGenerarl.TabIndex = 20
        Me.GrupoRecumenGenerarl.TabStop = False
        Me.GrupoRecumenGenerarl.Text = "Entregado por caja"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(65, 155)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "TOTAL:"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(122, 155)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(81, 13)
        Me.Label12.TabIndex = 18
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(53, 124)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(67, 20)
        Me.TextBox1.TabIndex = 16
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(84, 100)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(36, 20)
        Me.TextBox2.TabIndex = 15
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(122, 100)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(81, 20)
        Me.TextBox3.TabIndex = 14
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 103)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(51, 13)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "Tarjetas :"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(84, 74)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(36, 20)
        Me.TextBox4.TabIndex = 12
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(138, 29)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(31, 13)
        Me.Label15.TabIndex = 11
        Me.Label15.Text = "Valor"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(84, 29)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(32, 13)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "Cant."
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(122, 48)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(81, 20)
        Me.TextBox5.TabIndex = 7
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 51)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(52, 13)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "Efectivo :"
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(122, 74)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(81, 20)
        Me.TextBox6.TabIndex = 9
        Me.TextBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 77)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(55, 13)
        Me.Label18.TabIndex = 8
        Me.Label18.Text = "Cheques :"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(7, 127)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(48, 13)
        Me.Label19.TabIndex = 17
        Me.Label19.Text = "Nro.Lote"
        '
        'frmCierrCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(917, 531)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frmCierrCaja"
        Me.ShowIcon = False
        Me.Text = "CIERRE DE CAJA DE PUNTOS DE VENTA"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GrupoFiltros.ResumeLayout(False)
        Me.GrupoFiltros.PerformLayout()
        Me.GrupoEntregaCaja.ResumeLayout(False)
        Me.GrupoEntregaCaja.PerformLayout()
        Me.Grupo.ResumeLayout(False)
        Me.Grupo.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GrupoRecumenGenerarl.ResumeLayout(False)
        Me.GrupoRecumenGenerarl.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents cboPtoVta As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnOpciones As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Grupo As System.Windows.Forms.GroupBox
    Friend WithEvents txtFechaAl As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtFechaDel As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents GrupoEntregaCaja As GroupBox
    Friend WithEvents NroLoteTarjetas As TextBox
    Friend WithEvents txtCantTarjetas As TextBox
    Friend WithEvents txtTarjetas As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCantCheques As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtEfectivo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCheques As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtTotal As Label
    Friend WithEvents btnMovimientos As ToolStripButton
    Friend WithEvents btnConfimaCierre As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents btnAbrir As ToolStripButton
    Friend WithEvents btnCerrar As ToolStripButton
    Friend WithEvents cmbSucursal As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents btnPdfOriginal As ToolStripButton
    Friend WithEvents HelpProvider1 As HelpProvider
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents GrupoFiltros As GroupBox
    Friend WithEvents BtnResumenGeneral As ToolStripButton
    Friend WithEvents GrupoRecumenGenerarl As GroupBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
End Class
