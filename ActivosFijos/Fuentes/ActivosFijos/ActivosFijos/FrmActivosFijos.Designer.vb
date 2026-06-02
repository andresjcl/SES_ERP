<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmActivosFijos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmActivosFijos))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.mnuMouse = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DepreciaciesAnualesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComponentesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransformarEnComponeteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnVer = New System.Windows.Forms.ToolStripButton()
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btnActualizar = New System.Windows.Forms.ToolStripButton()
        Me.btnPropiedades = New System.Windows.Forms.ToolStripButton()
        Me.btnImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnDepreciar = New System.Windows.Forms.ToolStripButton()
        Me.btnDeterioro = New System.Windows.Forms.ToolStripButton()
        Me.btnMovimientos = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnReportes = New System.Windows.Forms.ToolStripSplitButton()
        Me.DepreciacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FinacieraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TributariaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DifernciaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DetalleDeDepreciacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCatalogoAct = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoivimierntoDeActivosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnContbiliza = New System.Windows.Forms.ToolStripButton()
        Me.btnPlantillaOtap = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnAbrir = New System.Windows.Forms.ToolStripButton()
        Me.btnAyuda = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.btnContabilizacion = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnNinguna = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chkCompTodos = New System.Windows.Forms.RadioButton()
        Me.chkPrincipal = New System.Windows.Forms.RadioButton()
        Me.chkComponente = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.optAmbosAct = New System.Windows.Forms.RadioButton()
        Me.optTangibles = New System.Windows.Forms.RadioButton()
        Me.optIntangibles = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.optAmbasDep = New System.Windows.Forms.RadioButton()
        Me.optTributaria = New System.Windows.Forms.RadioButton()
        Me.optFinanciera = New System.Windows.Forms.RadioButton()
        Me.txtHasta = New System.Windows.Forms.DateTimePicker()
        Me.txtDesde = New System.Windows.Forms.DateTimePicker()
        Me.cmbOperador = New System.Windows.Forms.ComboBox()
        Me.txtVidaUtil = New System.Windows.Forms.TextBox()
        Me.chkVidaUtil = New System.Windows.Forms.CheckBox()
        Me.cboResponsable = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkResponsable = New System.Windows.Forms.CheckBox()
        Me.cboSucursal = New System.Windows.Forms.ComboBox()
        Me.cboSeccion = New System.Windows.Forms.ComboBox()
        Me.chkSeccion = New System.Windows.Forms.CheckBox()
        Me.cboDepartamento = New System.Windows.Forms.ComboBox()
        Me.chkDepartamento = New System.Windows.Forms.CheckBox()
        Me.chkSucursal = New System.Windows.Forms.CheckBox()
        Me.CboSubgrupo = New System.Windows.Forms.ComboBox()
        Me.chkSubgrupo = New System.Windows.Forms.CheckBox()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.chkGrupo = New System.Windows.Forms.CheckBox()
        Me.cboClase = New System.Windows.Forms.ComboBox()
        Me.chkClase = New System.Windows.Forms.CheckBox()
        Me.cboCategoria = New System.Windows.Forms.ComboBox()
        Me.chkCategoria = New System.Windows.Forms.CheckBox()
        Me.gridActivos = New System.Windows.Forms.DataGridView()
        Me.DataSet11 = New ImprimirReportes.DataSet1()
        Me.mnuMouse.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.gridActivos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnuMouse
        '
        Me.mnuMouse.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DepreciaciesAnualesToolStripMenuItem, Me.ComponentesToolStripMenuItem, Me.TransformarEnComponeteToolStripMenuItem})
        Me.mnuMouse.Name = "mnuMouse"
        Me.mnuMouse.Size = New System.Drawing.Size(222, 70)
        '
        'DepreciaciesAnualesToolStripMenuItem
        '
        Me.DepreciaciesAnualesToolStripMenuItem.Name = "DepreciaciesAnualesToolStripMenuItem"
        Me.DepreciaciesAnualesToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.DepreciaciesAnualesToolStripMenuItem.Text = "Depreciacies Anuales"
        '
        'ComponentesToolStripMenuItem
        '
        Me.ComponentesToolStripMenuItem.Enabled = False
        Me.ComponentesToolStripMenuItem.Name = "ComponentesToolStripMenuItem"
        Me.ComponentesToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.ComponentesToolStripMenuItem.Text = "Componentes"
        '
        'TransformarEnComponeteToolStripMenuItem
        '
        Me.TransformarEnComponeteToolStripMenuItem.Enabled = False
        Me.TransformarEnComponeteToolStripMenuItem.Name = "TransformarEnComponeteToolStripMenuItem"
        Me.TransformarEnComponeteToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.TransformarEnComponeteToolStripMenuItem.Text = "Transformar en Componete"
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "F:\DesarrolloNET\Ayuda\ActivosFijos\Build\ActivosFijos.chm"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.ForeColor = System.Drawing.Color.White
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 46)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnVer, Me.ToolStripSeparator1, Me.btnNuevo, Me.btnActualizar, Me.btnPropiedades, Me.btnImprimir, Me.ToolStripSeparator2, Me.btnDepreciar, Me.btnDeterioro, Me.btnMovimientos, Me.ToolStripSeparator5, Me.btnReportes, Me.ToolStripSeparator6, Me.btnContbiliza, Me.btnPlantillaOtap, Me.ToolStripSeparator3, Me.btnAbrir, Me.btnAyuda, Me.ToolStripSeparator4, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(981, 46)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnVer
        '
        Me.btnVer.ForeColor = System.Drawing.Color.White
        Me.btnVer.Image = CType(resources.GetObject("btnVer.Image"), System.Drawing.Image)
        Me.btnVer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnVer.Name = "btnVer"
        Me.btnVer.Size = New System.Drawing.Size(50, 43)
        Me.btnVer.Text = "Opcion"
        Me.btnVer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnNuevo
        '
        Me.btnNuevo.ForeColor = System.Drawing.Color.White
        Me.btnNuevo.Image = Global.ActivosFijos.My.Resources.Resources.nuevo2
        Me.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(46, 43)
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnActualizar
        '
        Me.btnActualizar.ForeColor = System.Drawing.Color.White
        Me.btnActualizar.Image = CType(resources.GetObject("btnActualizar.Image"), System.Drawing.Image)
        Me.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(59, 43)
        Me.btnActualizar.Text = "Actualiza"
        Me.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnPropiedades
        '
        Me.btnPropiedades.ForeColor = System.Drawing.Color.White
        Me.btnPropiedades.Image = Global.ActivosFijos.My.Resources.Resources.propiedades
        Me.btnPropiedades.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPropiedades.Name = "btnPropiedades"
        Me.btnPropiedades.Size = New System.Drawing.Size(65, 43)
        Me.btnPropiedades.Text = "Propiedad"
        Me.btnPropiedades.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnPropiedades.ToolTipText = "Mantenimiento de datos del activo"
        '
        'btnImprimir
        '
        Me.btnImprimir.ForeColor = System.Drawing.Color.White
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(56, 43)
        Me.btnImprimir.Text = "Imprime"
        Me.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.ForeColor = System.Drawing.Color.White
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 46)
        '
        'btnDepreciar
        '
        Me.btnDepreciar.ForeColor = System.Drawing.Color.White
        Me.btnDepreciar.Image = CType(resources.GetObject("btnDepreciar.Image"), System.Drawing.Image)
        Me.btnDepreciar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDepreciar.Name = "btnDepreciar"
        Me.btnDepreciar.Size = New System.Drawing.Size(57, 43)
        Me.btnDepreciar.Text = "Deprecia"
        Me.btnDepreciar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnDepreciar.ToolTipText = "Calcula depreciaciones"
        '
        'btnDeterioro
        '
        Me.btnDeterioro.ForeColor = System.Drawing.Color.White
        Me.btnDeterioro.Image = CType(resources.GetObject("btnDeterioro.Image"), System.Drawing.Image)
        Me.btnDeterioro.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDeterioro.Name = "btnDeterioro"
        Me.btnDeterioro.Size = New System.Drawing.Size(60, 43)
        Me.btnDeterioro.Text = "Deterioro"
        Me.btnDeterioro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnMovimientos
        '
        Me.btnMovimientos.ForeColor = System.Drawing.Color.White
        Me.btnMovimientos.Image = CType(resources.GetObject("btnMovimientos.Image"), System.Drawing.Image)
        Me.btnMovimientos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMovimientos.Name = "btnMovimientos"
        Me.btnMovimientos.Size = New System.Drawing.Size(38, 43)
        Me.btnMovimientos.Text = "Mov."
        Me.btnMovimientos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnMovimientos.ToolTipText = "Movimientos del activo fijo"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.ForeColor = System.Drawing.Color.White
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 46)
        '
        'btnReportes
        '
        Me.btnReportes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DepreciacionToolStripMenuItem, Me.mnuCatalogoAct, Me.MoivimierntoDeActivosToolStripMenuItem})
        Me.btnReportes.ForeColor = System.Drawing.Color.White
        Me.btnReportes.Image = CType(resources.GetObject("btnReportes.Image"), System.Drawing.Image)
        Me.btnReportes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnReportes.Name = "btnReportes"
        Me.btnReportes.Size = New System.Drawing.Size(69, 43)
        Me.btnReportes.Text = "Reportes"
        Me.btnReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'DepreciacionToolStripMenuItem
        '
        Me.DepreciacionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FinacieraToolStripMenuItem, Me.TributariaToolStripMenuItem, Me.DifernciaToolStripMenuItem, Me.DetalleDeDepreciacionToolStripMenuItem})
        Me.DepreciacionToolStripMenuItem.Name = "DepreciacionToolStripMenuItem"
        Me.DepreciacionToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.DepreciacionToolStripMenuItem.Text = "Depreciaciones"
        '
        'FinacieraToolStripMenuItem
        '
        Me.FinacieraToolStripMenuItem.Name = "FinacieraToolStripMenuItem"
        Me.FinacieraToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.FinacieraToolStripMenuItem.Text = "Finaciera"
        '
        'TributariaToolStripMenuItem
        '
        Me.TributariaToolStripMenuItem.Name = "TributariaToolStripMenuItem"
        Me.TributariaToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.TributariaToolStripMenuItem.Text = "Tributaria"
        '
        'DifernciaToolStripMenuItem
        '
        Me.DifernciaToolStripMenuItem.Name = "DifernciaToolStripMenuItem"
        Me.DifernciaToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.DifernciaToolStripMenuItem.Text = "Diferncia"
        '
        'DetalleDeDepreciacionToolStripMenuItem
        '
        Me.DetalleDeDepreciacionToolStripMenuItem.Name = "DetalleDeDepreciacionToolStripMenuItem"
        Me.DetalleDeDepreciacionToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.DetalleDeDepreciacionToolStripMenuItem.Text = "Detalle de Depreciación"
        '
        'mnuCatalogoAct
        '
        Me.mnuCatalogoAct.Name = "mnuCatalogoAct"
        Me.mnuCatalogoAct.Size = New System.Drawing.Size(204, 22)
        Me.mnuCatalogoAct.Text = "Catalogo de Activos "
        '
        'MoivimierntoDeActivosToolStripMenuItem
        '
        Me.MoivimierntoDeActivosToolStripMenuItem.Name = "MoivimierntoDeActivosToolStripMenuItem"
        Me.MoivimierntoDeActivosToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.MoivimierntoDeActivosToolStripMenuItem.Text = "Moivimiernto de Activos"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.ForeColor = System.Drawing.Color.White
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 46)
        '
        'btnContbiliza
        '
        Me.btnContbiliza.ForeColor = System.Drawing.Color.White
        Me.btnContbiliza.Image = CType(resources.GetObject("btnContbiliza.Image"), System.Drawing.Image)
        Me.btnContbiliza.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnContbiliza.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnContbiliza.Name = "btnContbiliza"
        Me.btnContbiliza.Size = New System.Drawing.Size(102, 43)
        Me.btnContbiliza.Text = "Contabiliza"
        '
        'btnPlantillaOtap
        '
        Me.btnPlantillaOtap.ForeColor = System.Drawing.Color.White
        Me.btnPlantillaOtap.Image = CType(resources.GetObject("btnPlantillaOtap.Image"), System.Drawing.Image)
        Me.btnPlantillaOtap.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnPlantillaOtap.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPlantillaOtap.Name = "btnPlantillaOtap"
        Me.btnPlantillaOtap.Size = New System.Drawing.Size(85, 43)
        Me.btnPlantillaOtap.Text = "Plantilla"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.ForeColor = System.Drawing.Color.White
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 46)
        '
        'btnAbrir
        '
        Me.btnAbrir.ForeColor = System.Drawing.Color.White
        Me.btnAbrir.Image = Global.ActivosFijos.My.Resources.Resources.Aumentar
        Me.btnAbrir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.Size = New System.Drawing.Size(46, 43)
        Me.btnAbrir.Text = "Buscar"
        Me.btnAbrir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnAyuda
        '
        Me.btnAyuda.ForeColor = System.Drawing.Color.White
        Me.btnAyuda.Image = CType(resources.GetObject("btnAyuda.Image"), System.Drawing.Image)
        Me.btnAyuda.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAyuda.Name = "btnAyuda"
        Me.btnAyuda.Size = New System.Drawing.Size(45, 43)
        Me.btnAyuda.Text = "Ayuda"
        Me.btnAyuda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnAyuda.Visible = False
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.ForeColor = System.Drawing.Color.White
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 46)
        '
        'btnSalir
        '
        Me.btnSalir.ForeColor = System.Drawing.Color.White
        Me.btnSalir.Image = Global.ActivosFijos.My.Resources.Resources.Salir
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(33, 43)
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.SplitContainer1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 46)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(981, 492)
        Me.Panel1.TabIndex = 1
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnContabilizacion)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnCancelar)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnAceptar)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnNinguna)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.gridActivos)
        Me.SplitContainer1.Size = New System.Drawing.Size(981, 492)
        Me.SplitContainer1.SplitterDistance = 296
        Me.SplitContainer1.TabIndex = 3
        '
        'btnContabilizacion
        '
        Me.btnContabilizacion.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnContabilizacion.Location = New System.Drawing.Point(47, 460)
        Me.btnContabilizacion.Name = "btnContabilizacion"
        Me.btnContabilizacion.Size = New System.Drawing.Size(187, 28)
        Me.btnContabilizacion.TabIndex = 7
        Me.btnContabilizacion.Text = "Definir Contabilización"
        Me.btnContabilizacion.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(201, 416)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(81, 31)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "     Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(109, 416)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(83, 31)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'btnNinguna
        '
        Me.btnNinguna.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnNinguna.Image = CType(resources.GetObject("btnNinguna.Image"), System.Drawing.Image)
        Me.btnNinguna.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNinguna.Location = New System.Drawing.Point(13, 416)
        Me.btnNinguna.Name = "btnNinguna"
        Me.btnNinguna.Size = New System.Drawing.Size(86, 31)
        Me.btnNinguna.TabIndex = 4
        Me.btnNinguna.Text = "    Ninguna"
        Me.btnNinguna.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.txtHasta)
        Me.GroupBox1.Controls.Add(Me.txtDesde)
        Me.GroupBox1.Controls.Add(Me.cmbOperador)
        Me.GroupBox1.Controls.Add(Me.txtVidaUtil)
        Me.GroupBox1.Controls.Add(Me.chkVidaUtil)
        Me.GroupBox1.Controls.Add(Me.cboResponsable)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.chkResponsable)
        Me.GroupBox1.Controls.Add(Me.cboSucursal)
        Me.GroupBox1.Controls.Add(Me.cboSeccion)
        Me.GroupBox1.Controls.Add(Me.chkSeccion)
        Me.GroupBox1.Controls.Add(Me.cboDepartamento)
        Me.GroupBox1.Controls.Add(Me.chkDepartamento)
        Me.GroupBox1.Controls.Add(Me.chkSucursal)
        Me.GroupBox1.Controls.Add(Me.CboSubgrupo)
        Me.GroupBox1.Controls.Add(Me.chkSubgrupo)
        Me.GroupBox1.Controls.Add(Me.cboGrupo)
        Me.GroupBox1.Controls.Add(Me.chkGrupo)
        Me.GroupBox1.Controls.Add(Me.cboClase)
        Me.GroupBox1.Controls.Add(Me.chkClase)
        Me.GroupBox1.Controls.Add(Me.cboCategoria)
        Me.GroupBox1.Controls.Add(Me.chkCategoria)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(286, 400)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Seleccionar Activos :"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkCompTodos)
        Me.GroupBox4.Controls.Add(Me.chkPrincipal)
        Me.GroupBox4.Controls.Add(Me.chkComponente)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox4.Location = New System.Drawing.Point(6, 92)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(274, 39)
        Me.GroupBox4.TabIndex = 44
        Me.GroupBox4.TabStop = False
        '
        'chkCompTodos
        '
        Me.chkCompTodos.AutoSize = True
        Me.chkCompTodos.Location = New System.Drawing.Point(211, 16)
        Me.chkCompTodos.Name = "chkCompTodos"
        Me.chkCompTodos.Size = New System.Drawing.Size(55, 17)
        Me.chkCompTodos.TabIndex = 5
        Me.chkCompTodos.Text = "Todos"
        Me.chkCompTodos.UseVisualStyleBackColor = True
        '
        'chkPrincipal
        '
        Me.chkPrincipal.AutoSize = True
        Me.chkPrincipal.Checked = True
        Me.chkPrincipal.Location = New System.Drawing.Point(9, 16)
        Me.chkPrincipal.Name = "chkPrincipal"
        Me.chkPrincipal.Size = New System.Drawing.Size(60, 17)
        Me.chkPrincipal.TabIndex = 2
        Me.chkPrincipal.TabStop = True
        Me.chkPrincipal.Text = "Activos"
        Me.chkPrincipal.UseVisualStyleBackColor = True
        '
        'chkComponente
        '
        Me.chkComponente.AutoSize = True
        Me.chkComponente.Location = New System.Drawing.Point(74, 16)
        Me.chkComponente.Name = "chkComponente"
        Me.chkComponente.Size = New System.Drawing.Size(108, 17)
        Me.chkComponente.TabIndex = 3
        Me.chkComponente.Text = "Mejor/Adic/Repa"
        Me.chkComponente.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Location = New System.Drawing.Point(172, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 13)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "al"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.optAmbosAct)
        Me.GroupBox3.Controls.Add(Me.optTangibles)
        Me.GroupBox3.Controls.Add(Me.optIntangibles)
        Me.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox3.Location = New System.Drawing.Point(6, 11)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(274, 39)
        Me.GroupBox3.TabIndex = 42
        Me.GroupBox3.TabStop = False
        '
        'optAmbosAct
        '
        Me.optAmbosAct.AutoSize = True
        Me.optAmbosAct.Checked = True
        Me.optAmbosAct.Location = New System.Drawing.Point(191, 16)
        Me.optAmbosAct.Name = "optAmbosAct"
        Me.optAmbosAct.Size = New System.Drawing.Size(55, 17)
        Me.optAmbosAct.TabIndex = 5
        Me.optAmbosAct.TabStop = True
        Me.optAmbosAct.Text = "Todos"
        Me.optAmbosAct.UseVisualStyleBackColor = True
        '
        'optTangibles
        '
        Me.optTangibles.AutoSize = True
        Me.optTangibles.Location = New System.Drawing.Point(16, 16)
        Me.optTangibles.Name = "optTangibles"
        Me.optTangibles.Size = New System.Drawing.Size(71, 17)
        Me.optTangibles.TabIndex = 2
        Me.optTangibles.Text = "Tangibles"
        Me.optTangibles.UseVisualStyleBackColor = True
        '
        'optIntangibles
        '
        Me.optIntangibles.AutoSize = True
        Me.optIntangibles.Location = New System.Drawing.Point(97, 16)
        Me.optIntangibles.Name = "optIntangibles"
        Me.optIntangibles.Size = New System.Drawing.Size(76, 17)
        Me.optIntangibles.TabIndex = 3
        Me.optIntangibles.Text = "Intangibles"
        Me.optIntangibles.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.optAmbasDep)
        Me.GroupBox2.Controls.Add(Me.optTributaria)
        Me.GroupBox2.Controls.Add(Me.optFinanciera)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(8, 348)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(272, 39)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo depreciación"
        '
        'optAmbasDep
        '
        Me.optAmbasDep.AutoSize = True
        Me.optAmbasDep.Location = New System.Drawing.Point(187, 16)
        Me.optAmbasDep.Name = "optAmbasDep"
        Me.optAmbasDep.Size = New System.Drawing.Size(57, 17)
        Me.optAmbasDep.TabIndex = 28
        Me.optAmbasDep.Text = "Ambas"
        Me.optAmbasDep.UseVisualStyleBackColor = True
        '
        'optTributaria
        '
        Me.optTributaria.AutoSize = True
        Me.optTributaria.Location = New System.Drawing.Point(100, 16)
        Me.optTributaria.Name = "optTributaria"
        Me.optTributaria.Size = New System.Drawing.Size(69, 17)
        Me.optTributaria.TabIndex = 27
        Me.optTributaria.Text = "Tributaria"
        Me.optTributaria.UseVisualStyleBackColor = True
        '
        'optFinanciera
        '
        Me.optFinanciera.AutoSize = True
        Me.optFinanciera.Checked = True
        Me.optFinanciera.Location = New System.Drawing.Point(13, 16)
        Me.optFinanciera.Name = "optFinanciera"
        Me.optFinanciera.Size = New System.Drawing.Size(74, 17)
        Me.optFinanciera.TabIndex = 26
        Me.optFinanciera.TabStop = True
        Me.optFinanciera.Text = "Financiera"
        Me.optFinanciera.UseVisualStyleBackColor = True
        '
        'txtHasta
        '
        Me.txtHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtHasta.Location = New System.Drawing.Point(190, 66)
        Me.txtHasta.Name = "txtHasta"
        Me.txtHasta.Size = New System.Drawing.Size(89, 20)
        Me.txtHasta.TabIndex = 40
        '
        'txtDesde
        '
        Me.txtDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtDesde.Location = New System.Drawing.Point(83, 66)
        Me.txtDesde.Name = "txtDesde"
        Me.txtDesde.Size = New System.Drawing.Size(88, 20)
        Me.txtDesde.TabIndex = 39
        Me.txtDesde.Value = New Date(1900, 1, 1, 0, 0, 0, 0)
        '
        'cmbOperador
        '
        Me.cmbOperador.Enabled = False
        Me.cmbOperador.FormattingEnabled = True
        Me.cmbOperador.Items.AddRange(New Object() {"=", ">", "<", "<>"})
        Me.cmbOperador.Location = New System.Drawing.Point(103, 138)
        Me.cmbOperador.Name = "cmbOperador"
        Me.cmbOperador.Size = New System.Drawing.Size(42, 21)
        Me.cmbOperador.TabIndex = 38
        '
        'txtVidaUtil
        '
        Me.txtVidaUtil.Enabled = False
        Me.txtVidaUtil.Location = New System.Drawing.Point(151, 139)
        Me.txtVidaUtil.Name = "txtVidaUtil"
        Me.txtVidaUtil.Size = New System.Drawing.Size(47, 20)
        Me.txtVidaUtil.TabIndex = 37
        '
        'chkVidaUtil
        '
        Me.chkVidaUtil.AutoSize = True
        Me.chkVidaUtil.Location = New System.Drawing.Point(8, 142)
        Me.chkVidaUtil.Name = "chkVidaUtil"
        Me.chkVidaUtil.Size = New System.Drawing.Size(89, 17)
        Me.chkVidaUtil.TabIndex = 36
        Me.chkVidaUtil.Text = "Años vida util"
        Me.chkVidaUtil.UseVisualStyleBackColor = True
        '
        'cboResponsable
        '
        Me.cboResponsable.Enabled = False
        Me.cboResponsable.FormattingEnabled = True
        Me.cboResponsable.Location = New System.Drawing.Point(100, 321)
        Me.cboResponsable.Name = "cboResponsable"
        Me.cboResponsable.Size = New System.Drawing.Size(180, 21)
        Me.cboResponsable.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Location = New System.Drawing.Point(5, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Ingresados del"
        '
        'chkResponsable
        '
        Me.chkResponsable.AutoSize = True
        Me.chkResponsable.Location = New System.Drawing.Point(7, 324)
        Me.chkResponsable.Name = "chkResponsable"
        Me.chkResponsable.Size = New System.Drawing.Size(88, 17)
        Me.chkResponsable.TabIndex = 24
        Me.chkResponsable.Text = "Responsable"
        Me.chkResponsable.UseVisualStyleBackColor = True
        '
        'cboSucursal
        '
        Me.cboSucursal.Enabled = False
        Me.cboSucursal.FormattingEnabled = True
        Me.cboSucursal.Location = New System.Drawing.Point(100, 252)
        Me.cboSucursal.Name = "cboSucursal"
        Me.cboSucursal.Size = New System.Drawing.Size(180, 21)
        Me.cboSucursal.TabIndex = 19
        '
        'cboSeccion
        '
        Me.cboSeccion.Enabled = False
        Me.cboSeccion.FormattingEnabled = True
        Me.cboSeccion.Location = New System.Drawing.Point(100, 298)
        Me.cboSeccion.Name = "cboSeccion"
        Me.cboSeccion.Size = New System.Drawing.Size(180, 21)
        Me.cboSeccion.TabIndex = 23
        '
        'chkSeccion
        '
        Me.chkSeccion.AutoSize = True
        Me.chkSeccion.Location = New System.Drawing.Point(8, 300)
        Me.chkSeccion.Name = "chkSeccion"
        Me.chkSeccion.Size = New System.Drawing.Size(65, 17)
        Me.chkSeccion.TabIndex = 22
        Me.chkSeccion.Text = "Sección"
        Me.chkSeccion.UseVisualStyleBackColor = True
        '
        'cboDepartamento
        '
        Me.cboDepartamento.Enabled = False
        Me.cboDepartamento.FormattingEnabled = True
        Me.cboDepartamento.Location = New System.Drawing.Point(100, 275)
        Me.cboDepartamento.Name = "cboDepartamento"
        Me.cboDepartamento.Size = New System.Drawing.Size(180, 21)
        Me.cboDepartamento.TabIndex = 21
        '
        'chkDepartamento
        '
        Me.chkDepartamento.AutoSize = True
        Me.chkDepartamento.Location = New System.Drawing.Point(8, 278)
        Me.chkDepartamento.Name = "chkDepartamento"
        Me.chkDepartamento.Size = New System.Drawing.Size(93, 17)
        Me.chkDepartamento.TabIndex = 20
        Me.chkDepartamento.Text = "Departamento"
        Me.chkDepartamento.UseVisualStyleBackColor = True
        '
        'chkSucursal
        '
        Me.chkSucursal.AutoSize = True
        Me.chkSucursal.Location = New System.Drawing.Point(8, 255)
        Me.chkSucursal.Name = "chkSucursal"
        Me.chkSucursal.Size = New System.Drawing.Size(67, 17)
        Me.chkSucursal.TabIndex = 18
        Me.chkSucursal.Text = "Sucursal"
        Me.chkSucursal.UseVisualStyleBackColor = True
        '
        'CboSubgrupo
        '
        Me.CboSubgrupo.Enabled = False
        Me.CboSubgrupo.FormattingEnabled = True
        Me.CboSubgrupo.Location = New System.Drawing.Point(100, 229)
        Me.CboSubgrupo.Name = "CboSubgrupo"
        Me.CboSubgrupo.Size = New System.Drawing.Size(180, 21)
        Me.CboSubgrupo.TabIndex = 17
        '
        'chkSubgrupo
        '
        Me.chkSubgrupo.AutoSize = True
        Me.chkSubgrupo.Location = New System.Drawing.Point(8, 231)
        Me.chkSubgrupo.Name = "chkSubgrupo"
        Me.chkSubgrupo.Size = New System.Drawing.Size(72, 17)
        Me.chkSubgrupo.TabIndex = 16
        Me.chkSubgrupo.Text = "Subgrupo"
        Me.chkSubgrupo.UseVisualStyleBackColor = True
        '
        'cboGrupo
        '
        Me.cboGrupo.Enabled = False
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Location = New System.Drawing.Point(100, 206)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(180, 21)
        Me.cboGrupo.TabIndex = 15
        '
        'chkGrupo
        '
        Me.chkGrupo.AutoSize = True
        Me.chkGrupo.Location = New System.Drawing.Point(8, 208)
        Me.chkGrupo.Name = "chkGrupo"
        Me.chkGrupo.Size = New System.Drawing.Size(55, 17)
        Me.chkGrupo.TabIndex = 14
        Me.chkGrupo.Text = "Grupo"
        Me.chkGrupo.UseVisualStyleBackColor = True
        '
        'cboClase
        '
        Me.cboClase.Enabled = False
        Me.cboClase.FormattingEnabled = True
        Me.cboClase.Location = New System.Drawing.Point(100, 183)
        Me.cboClase.Name = "cboClase"
        Me.cboClase.Size = New System.Drawing.Size(180, 21)
        Me.cboClase.TabIndex = 13
        '
        'chkClase
        '
        Me.chkClase.AutoSize = True
        Me.chkClase.Location = New System.Drawing.Point(8, 186)
        Me.chkClase.Name = "chkClase"
        Me.chkClase.Size = New System.Drawing.Size(52, 17)
        Me.chkClase.TabIndex = 12
        Me.chkClase.Text = "Clase"
        Me.chkClase.UseVisualStyleBackColor = True
        '
        'cboCategoria
        '
        Me.cboCategoria.Enabled = False
        Me.cboCategoria.FormattingEnabled = True
        Me.cboCategoria.Location = New System.Drawing.Point(100, 160)
        Me.cboCategoria.Name = "cboCategoria"
        Me.cboCategoria.Size = New System.Drawing.Size(180, 21)
        Me.cboCategoria.TabIndex = 11
        '
        'chkCategoria
        '
        Me.chkCategoria.AutoSize = True
        Me.chkCategoria.Location = New System.Drawing.Point(8, 162)
        Me.chkCategoria.Name = "chkCategoria"
        Me.chkCategoria.Size = New System.Drawing.Size(73, 17)
        Me.chkCategoria.TabIndex = 10
        Me.chkCategoria.Text = "Categoría"
        Me.chkCategoria.UseVisualStyleBackColor = True
        '
        'gridActivos
        '
        Me.gridActivos.AllowUserToAddRows = False
        Me.gridActivos.AllowUserToDeleteRows = False
        Me.gridActivos.AllowUserToResizeColumns = False
        Me.gridActivos.AllowUserToResizeRows = False
        Me.gridActivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.gridActivos.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridActivos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.gridActivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridActivos.DefaultCellStyle = DataGridViewCellStyle5
        Me.gridActivos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridActivos.EnableHeadersVisualStyles = False
        Me.gridActivos.Location = New System.Drawing.Point(0, 0)
        Me.gridActivos.Name = "gridActivos"
        Me.gridActivos.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridActivos.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.gridActivos.RowHeadersWidth = 20
        Me.gridActivos.Size = New System.Drawing.Size(681, 492)
        Me.gridActivos.TabIndex = 2
        '
        'DataSet11
        '
        Me.DataSet11.DataSetName = "DataSet1"
        Me.DataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FrmActivosFijos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(981, 538)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.HelpButton = True
        Me.HelpProvider1.SetHelpKeyword(Me, "HelpProvider1")
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmActivosFijos"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Activos Fijos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.mnuMouse.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.gridActivos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents mnuMouse As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DepreciaciesAnualesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents ComponentesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransformarEnComponeteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnVer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPropiedades As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDepreciar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDeterioro As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnMovimientos As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnReportes As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents DepreciacionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FinacieraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TributariaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DifernciaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DetalleDeDepreciacionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCatalogoAct As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MoivimierntoDeActivosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAbrir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnNinguna As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboResponsable As System.Windows.Forms.ComboBox
    Friend WithEvents optAmbasDep As System.Windows.Forms.RadioButton
    Friend WithEvents optTributaria As System.Windows.Forms.RadioButton
    Friend WithEvents optFinanciera As System.Windows.Forms.RadioButton
    Friend WithEvents optAmbosAct As System.Windows.Forms.RadioButton
    Friend WithEvents optIntangibles As System.Windows.Forms.RadioButton
    Friend WithEvents optTangibles As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkResponsable As System.Windows.Forms.CheckBox
    Friend WithEvents cboSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents cboSeccion As System.Windows.Forms.ComboBox
    Friend WithEvents chkSeccion As System.Windows.Forms.CheckBox
    Friend WithEvents cboDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents chkDepartamento As System.Windows.Forms.CheckBox
    Friend WithEvents chkSucursal As System.Windows.Forms.CheckBox
    Friend WithEvents CboSubgrupo As System.Windows.Forms.ComboBox
    Friend WithEvents chkSubgrupo As System.Windows.Forms.CheckBox
    Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents chkGrupo As System.Windows.Forms.CheckBox
    Friend WithEvents cboClase As System.Windows.Forms.ComboBox
    Friend WithEvents chkClase As System.Windows.Forms.CheckBox
    Friend WithEvents cboCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents chkCategoria As System.Windows.Forms.CheckBox
    Friend WithEvents gridActivos As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnContabilizacion As System.Windows.Forms.Button
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnPlantillaOtap As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtVidaUtil As System.Windows.Forms.TextBox
    Friend WithEvents chkVidaUtil As System.Windows.Forms.CheckBox
    Friend WithEvents cmbOperador As System.Windows.Forms.ComboBox
    Friend WithEvents btnContbiliza As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataSet11 As ImprimirReportes.DataSet1
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents chkCompTodos As System.Windows.Forms.RadioButton
    Friend WithEvents chkPrincipal As System.Windows.Forms.RadioButton
    Friend WithEvents chkComponente As System.Windows.Forms.RadioButton

End Class
