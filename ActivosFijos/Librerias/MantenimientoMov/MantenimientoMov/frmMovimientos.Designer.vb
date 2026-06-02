<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMovimientos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMovimientos))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btnAbrir = New System.Windows.Forms.ToolStripButton()
        Me.btnCerrar = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btnEliminar = New System.Windows.Forms.ToolStripButton()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFechaDoc = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtSeccionAct = New System.Windows.Forms.Label()
        Me.txtDptoAct = New System.Windows.Forms.Label()
        Me.txtSucursalAct = New System.Windows.Forms.Label()
        Me.txtResAct = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.labNombreActivo = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabFinanciero = New System.Windows.Forms.TabPage()
        Me.txtNValProd = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtNReval = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtNDeter = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtNViadUtil = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtNValorRes = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TabProduccion = New System.Windows.Forms.TabPage()
        Me.txtFechaProduccion = New System.Windows.Forms.DateTimePicker()
        Me.txtUnidadesProducidas = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TabFisico = New System.Windows.Forms.TabPage()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboResponsable = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboSeccionNva = New System.Windows.Forms.ComboBox()
        Me.cboDptoNvo = New System.Windows.Forms.ComboBox()
        Me.cboSucursalNva = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboDocumento = New System.Windows.Forms.ComboBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnCodAct = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cmbSucursalDoc = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabFinanciero.SuspendLayout()
        Me.TabProduccion.SuspendLayout()
        Me.TabFisico.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.btnAbrir, Me.btnCerrar, Me.btnGuardar, Me.btnEliminar, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(761, 38)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(46, 35)
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnAbrir
        '
        Me.btnAbrir.Image = CType(resources.GetObject("btnAbrir.Image"), System.Drawing.Image)
        Me.btnAbrir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.Size = New System.Drawing.Size(37, 35)
        Me.btnAbrir.Text = "Abrir"
        Me.btnAbrir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(43, 35)
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnCerrar.Visible = False
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(53, 35)
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnGuardar.Visible = False
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(54, 35)
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnEliminar.Visible = False
        '
        'btnSalir
        '
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(33, 35)
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(472, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nro."
        '
        'txtNumDoc
        '
        Me.txtNumDoc.Enabled = False
        Me.txtNumDoc.Location = New System.Drawing.Point(501, 44)
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.Size = New System.Drawing.Size(91, 20)
        Me.txtNumDoc.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(610, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Fecha:"
        '
        'txtFechaDoc
        '
        Me.txtFechaDoc.Enabled = False
        Me.txtFechaDoc.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaDoc.Location = New System.Drawing.Point(652, 45)
        Me.txtFechaDoc.Name = "txtFechaDoc"
        Me.txtFechaDoc.Size = New System.Drawing.Size(101, 20)
        Me.txtFechaDoc.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.txtSeccionAct)
        Me.GroupBox1.Controls.Add(Me.txtDptoAct)
        Me.GroupBox1.Controls.Add(Me.txtSucursalAct)
        Me.GroupBox1.Controls.Add(Me.txtResAct)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 116)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(738, 61)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ubicación actual del activo fijo"
        '
        'txtSeccionAct
        '
        Me.txtSeccionAct.AutoSize = True
        Me.txtSeccionAct.Location = New System.Drawing.Point(521, 38)
        Me.txtSeccionAct.Name = "txtSeccionAct"
        Me.txtSeccionAct.Size = New System.Drawing.Size(0, 13)
        Me.txtSeccionAct.TabIndex = 11
        '
        'txtDptoAct
        '
        Me.txtDptoAct.AutoSize = True
        Me.txtDptoAct.Location = New System.Drawing.Point(321, 38)
        Me.txtDptoAct.Name = "txtDptoAct"
        Me.txtDptoAct.Size = New System.Drawing.Size(0, 13)
        Me.txtDptoAct.TabIndex = 10
        '
        'txtSucursalAct
        '
        Me.txtSucursalAct.AutoSize = True
        Me.txtSucursalAct.Location = New System.Drawing.Point(93, 38)
        Me.txtSucursalAct.Name = "txtSucursalAct"
        Me.txtSucursalAct.Size = New System.Drawing.Size(0, 13)
        Me.txtSucursalAct.TabIndex = 9
        '
        'txtResAct
        '
        Me.txtResAct.AutoSize = True
        Me.txtResAct.Location = New System.Drawing.Point(93, 18)
        Me.txtResAct.Name = "txtResAct"
        Me.txtResAct.Size = New System.Drawing.Size(0, 13)
        Me.txtResAct.TabIndex = 8
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(13, 18)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 13)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "Responsable:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(451, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Sección:"
        '
        'labNombreActivo
        '
        Me.labNombreActivo.Location = New System.Drawing.Point(254, 93)
        Me.labNombreActivo.Name = "labNombreActivo"
        Me.labNombreActivo.Size = New System.Drawing.Size(499, 13)
        Me.labNombreActivo.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Sucursal:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TabControl1)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 181)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(734, 163)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Movimiento"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabFinanciero)
        Me.TabControl1.Controls.Add(Me.TabProduccion)
        Me.TabControl1.Controls.Add(Me.TabFisico)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(3, 16)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(728, 144)
        Me.TabControl1.TabIndex = 0
        '
        'TabFinanciero
        '
        Me.TabFinanciero.BackColor = System.Drawing.Color.LightSteelBlue
        Me.TabFinanciero.Controls.Add(Me.txtNValProd)
        Me.TabFinanciero.Controls.Add(Me.Label18)
        Me.TabFinanciero.Controls.Add(Me.txtNReval)
        Me.TabFinanciero.Controls.Add(Me.Label17)
        Me.TabFinanciero.Controls.Add(Me.txtNDeter)
        Me.TabFinanciero.Controls.Add(Me.Label16)
        Me.TabFinanciero.Controls.Add(Me.txtNViadUtil)
        Me.TabFinanciero.Controls.Add(Me.Label15)
        Me.TabFinanciero.Controls.Add(Me.txtNValorRes)
        Me.TabFinanciero.Controls.Add(Me.Label14)
        Me.TabFinanciero.Location = New System.Drawing.Point(4, 22)
        Me.TabFinanciero.Name = "TabFinanciero"
        Me.TabFinanciero.Padding = New System.Windows.Forms.Padding(3)
        Me.TabFinanciero.Size = New System.Drawing.Size(720, 118)
        Me.TabFinanciero.TabIndex = 1
        Me.TabFinanciero.Text = "Financiero"
        '
        'txtNValProd
        '
        Me.txtNValProd.Enabled = False
        Me.txtNValProd.Location = New System.Drawing.Point(422, 45)
        Me.txtNValProd.Name = "txtNValProd"
        Me.txtNValProd.Size = New System.Drawing.Size(129, 20)
        Me.txtNValProd.TabIndex = 20
        Me.txtNValProd.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(290, 48)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(126, 13)
        Me.Label18.TabIndex = 21
        Me.Label18.Text = "Nuevo Valor Producción:"
        Me.Label18.Visible = False
        '
        'txtNReval
        '
        Me.txtNReval.Enabled = False
        Me.txtNReval.Location = New System.Drawing.Point(422, 21)
        Me.txtNReval.Name = "txtNReval"
        Me.txtNReval.Size = New System.Drawing.Size(129, 20)
        Me.txtNReval.TabIndex = 18
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(290, 24)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(115, 13)
        Me.Label17.TabIndex = 19
        Me.Label17.Text = "Nueva Revalorización:"
        '
        'txtNDeter
        '
        Me.txtNDeter.Enabled = False
        Me.txtNDeter.Location = New System.Drawing.Point(127, 70)
        Me.txtNDeter.Name = "txtNDeter"
        Me.txtNDeter.Size = New System.Drawing.Size(129, 20)
        Me.txtNDeter.TabIndex = 16
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(8, 73)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(115, 13)
        Me.Label16.TabIndex = 17
        Me.Label16.Text = "Nuevo Valor Deterioro:"
        '
        'txtNViadUtil
        '
        Me.txtNViadUtil.Enabled = False
        Me.txtNViadUtil.Location = New System.Drawing.Point(127, 45)
        Me.txtNViadUtil.Name = "txtNViadUtil"
        Me.txtNViadUtil.Size = New System.Drawing.Size(129, 20)
        Me.txtNViadUtil.TabIndex = 14
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(8, 45)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(84, 13)
        Me.Label15.TabIndex = 15
        Me.Label15.Text = "Nueva Vida Util:"
        '
        'txtNValorRes
        '
        Me.txtNValorRes.Enabled = False
        Me.txtNValorRes.Location = New System.Drawing.Point(127, 21)
        Me.txtNValorRes.Name = "txtNValorRes"
        Me.txtNValorRes.Size = New System.Drawing.Size(129, 20)
        Me.txtNValorRes.TabIndex = 12
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(8, 24)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(113, 13)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "Nuevo Valor Residual:"
        '
        'TabProduccion
        '
        Me.TabProduccion.BackColor = System.Drawing.Color.LightSteelBlue
        Me.TabProduccion.Controls.Add(Me.txtFechaProduccion)
        Me.TabProduccion.Controls.Add(Me.txtUnidadesProducidas)
        Me.TabProduccion.Controls.Add(Me.Label20)
        Me.TabProduccion.Controls.Add(Me.Label19)
        Me.TabProduccion.Location = New System.Drawing.Point(4, 22)
        Me.TabProduccion.Name = "TabProduccion"
        Me.TabProduccion.Padding = New System.Windows.Forms.Padding(3)
        Me.TabProduccion.Size = New System.Drawing.Size(720, 118)
        Me.TabProduccion.TabIndex = 2
        Me.TabProduccion.Text = "Producción"
        '
        'txtFechaProduccion
        '
        Me.txtFechaProduccion.Enabled = False
        Me.txtFechaProduccion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaProduccion.Location = New System.Drawing.Point(150, 25)
        Me.txtFechaProduccion.Name = "txtFechaProduccion"
        Me.txtFechaProduccion.Size = New System.Drawing.Size(105, 20)
        Me.txtFechaProduccion.TabIndex = 5
        '
        'txtUnidadesProducidas
        '
        Me.txtUnidadesProducidas.Enabled = False
        Me.txtUnidadesProducidas.Location = New System.Drawing.Point(150, 61)
        Me.txtUnidadesProducidas.Name = "txtUnidadesProducidas"
        Me.txtUnidadesProducidas.Size = New System.Drawing.Size(65, 20)
        Me.txtUnidadesProducidas.TabIndex = 4
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 31)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(112, 13)
        Me.Label20.TabIndex = 1
        Me.Label20.Text = "Fecha de Producción:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(3, 64)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(141, 13)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Unidades Prodicidas al Mes:"
        '
        'TabFisico
        '
        Me.TabFisico.BackColor = System.Drawing.Color.LightSteelBlue
        Me.TabFisico.Controls.Add(Me.Label12)
        Me.TabFisico.Controls.Add(Me.txtObservaciones)
        Me.TabFisico.Controls.Add(Me.Label4)
        Me.TabFisico.Controls.Add(Me.cboResponsable)
        Me.TabFisico.Controls.Add(Me.Label10)
        Me.TabFisico.Controls.Add(Me.Label9)
        Me.TabFisico.Controls.Add(Me.Label8)
        Me.TabFisico.Controls.Add(Me.cboSeccionNva)
        Me.TabFisico.Controls.Add(Me.cboDptoNvo)
        Me.TabFisico.Controls.Add(Me.cboSucursalNva)
        Me.TabFisico.Location = New System.Drawing.Point(4, 22)
        Me.TabFisico.Name = "TabFisico"
        Me.TabFisico.Padding = New System.Windows.Forms.Padding(3)
        Me.TabFisico.Size = New System.Drawing.Size(720, 118)
        Me.TabFisico.TabIndex = 0
        Me.TabFisico.Text = "Nueva ubicación física"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(9, 68)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(81, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Observaciones:"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Enabled = False
        Me.txtObservaciones.Location = New System.Drawing.Point(90, 68)
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(529, 20)
        Me.txtObservaciones.TabIndex = 19
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Responsable::"
        '
        'cboResponsable
        '
        Me.cboResponsable.Enabled = False
        Me.cboResponsable.FormattingEnabled = True
        Me.cboResponsable.Location = New System.Drawing.Point(90, 14)
        Me.cboResponsable.Name = "cboResponsable"
        Me.cboResponsable.Size = New System.Drawing.Size(327, 21)
        Me.cboResponsable.TabIndex = 13
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(434, 45)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Sección:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(220, 45)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Departamento:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 45)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Sucursal:"
        '
        'cboSeccionNva
        '
        Me.cboSeccionNva.Enabled = False
        Me.cboSeccionNva.FormattingEnabled = True
        Me.cboSeccionNva.Location = New System.Drawing.Point(500, 41)
        Me.cboSeccionNva.Name = "cboSeccionNva"
        Me.cboSeccionNva.Size = New System.Drawing.Size(119, 21)
        Me.cboSeccionNva.TabIndex = 17
        '
        'cboDptoNvo
        '
        Me.cboDptoNvo.Enabled = False
        Me.cboDptoNvo.FormattingEnabled = True
        Me.cboDptoNvo.Location = New System.Drawing.Point(298, 41)
        Me.cboDptoNvo.Name = "cboDptoNvo"
        Me.cboDptoNvo.Size = New System.Drawing.Size(119, 21)
        Me.cboDptoNvo.TabIndex = 15
        '
        'cboSucursalNva
        '
        Me.cboSucursalNva.Enabled = False
        Me.cboSucursalNva.FormattingEnabled = True
        Me.cboSucursalNva.Location = New System.Drawing.Point(90, 41)
        Me.cboSucursalNva.Name = "cboSucursalNva"
        Me.cboSucursalNva.Size = New System.Drawing.Size(119, 21)
        Me.cboSucursalNva.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(219, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Documento:"
        '
        'cboDocumento
        '
        Me.cboDocumento.Enabled = False
        Me.cboDocumento.FormattingEnabled = True
        Me.cboDocumento.Location = New System.Drawing.Point(286, 43)
        Me.cboDocumento.Name = "cboDocumento"
        Me.cboDocumento.Size = New System.Drawing.Size(180, 21)
        Me.cboDocumento.TabIndex = 12
        '
        'txtCodigo
        '
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Location = New System.Drawing.Point(98, 89)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(129, 20)
        Me.txtCodigo.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(20, 93)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 13)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Codigo activo:"
        '
        'btnCodAct
        '
        Me.btnCodAct.Enabled = False
        Me.btnCodAct.Location = New System.Drawing.Point(227, 88)
        Me.btnCodAct.Name = "btnCodAct"
        Me.btnCodAct.Size = New System.Drawing.Size(23, 23)
        Me.btnCodAct.TabIndex = 1
        Me.btnCodAct.Text = "..."
        Me.btnCodAct.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(2, 47)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(77, 13)
        Me.Label21.TabIndex = 23
        Me.Label21.Text = "Sucursal Doc.:"
        '
        'cmbSucursalDoc
        '
        Me.cmbSucursalDoc.FormattingEnabled = True
        Me.cmbSucursalDoc.Location = New System.Drawing.Point(79, 43)
        Me.cmbSucursalDoc.Name = "cmbSucursalDoc"
        Me.cmbSucursalDoc.Size = New System.Drawing.Size(128, 21)
        Me.cmbSucursalDoc.TabIndex = 22
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(239, 38)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(80, 13)
        Me.Label22.TabIndex = 25
        Me.Label22.Text = "Departamento :"
        '
        'frmMovimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(761, 354)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.cmbSucursalDoc)
        Me.Controls.Add(Me.btnCodAct)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.labNombreActivo)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cboDocumento)
        Me.Controls.Add(Me.txtFechaDoc)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNumDoc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMovimientos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de movimiento físco y cambios  de activos fijos"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabFinanciero.ResumeLayout(False)
        Me.TabFinanciero.PerformLayout()
        Me.TabProduccion.ResumeLayout(False)
        Me.TabProduccion.PerformLayout()
        Me.TabFisico.ResumeLayout(False)
        Me.TabFisico.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnAbrir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFechaDoc As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents labNombreActivo As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnCodAct As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtResAct As System.Windows.Forms.Label
    Friend WithEvents txtSucursalAct As System.Windows.Forms.Label
    Friend WithEvents txtSeccionAct As System.Windows.Forms.Label
    Friend WithEvents txtDptoAct As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabFisico As System.Windows.Forms.TabPage
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboResponsable As System.Windows.Forms.ComboBox
    Friend WithEvents cboDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboSeccionNva As System.Windows.Forms.ComboBox
    Friend WithEvents cboDptoNvo As System.Windows.Forms.ComboBox
    Friend WithEvents cboSucursalNva As System.Windows.Forms.ComboBox
    Friend WithEvents TabFinanciero As System.Windows.Forms.TabPage
    Friend WithEvents txtNValProd As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtNReval As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtNDeter As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtNViadUtil As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtNValorRes As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TabProduccion As System.Windows.Forms.TabPage
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtUnidadesProducidas As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaProduccion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cmbSucursalDoc As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label

End Class
