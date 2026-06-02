<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class repInv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(repInv))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnOpciones = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmbReportes = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Actualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.chkUbicacion = New System.Windows.Forms.CheckBox()
        Me.Orden = New System.Windows.Forms.CheckBox()
        Me.chkArtExis = New System.Windows.Forms.CheckBox()
        Me.chkSaldoFec = New System.Windows.Forms.CheckBox()
        Me.txtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.cboBodega = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMedidas = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnMed = New System.Windows.Forms.Button()
        Me.cboTipoIngreso = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtFechaFin = New System.Windows.Forms.MaskedTextBox()
        Me.txtFechaIni = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ArticulosGrupos = New System.Windows.Forms.GroupBox()
        Me.cboSubg = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboClase = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboCategoria = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCodFin = New System.Windows.Forms.Button()
        Me.txtCodFin = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnCodIni = New System.Windows.Forms.Button()
        Me.txtcodIni = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Agrupacion = New System.Windows.Forms.GroupBox()
        Me.chkSubg = New System.Windows.Forms.CheckBox()
        Me.chkClase = New System.Windows.Forms.CheckBox()
        Me.chkGrupo = New System.Windows.Forms.CheckBox()
        Me.chkCategoria = New System.Windows.Forms.CheckBox()
        Me.ValoracionInventario = New System.Windows.Forms.GroupBox()
        Me.optSinCost = New System.Windows.Forms.RadioButton()
        Me.optPvp4 = New System.Windows.Forms.RadioButton()
        Me.optPvp2 = New System.Windows.Forms.RadioButton()
        Me.optUltCost = New System.Windows.Forms.RadioButton()
        Me.optPvp5 = New System.Windows.Forms.RadioButton()
        Me.optPvp3 = New System.Windows.Forms.RadioButton()
        Me.optPvp1 = New System.Windows.Forms.RadioButton()
        Me.optCostoPro = New System.Windows.Forms.RadioButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btnArtFin = New System.Windows.Forms.Button()
        Me.txtArtFin = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnArtIni = New System.Windows.Forms.Button()
        Me.txtArtIni = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TotalDoc = New System.Windows.Forms.CheckBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnDir = New System.Windows.Forms.Button()
        Me.lblnombre = New System.Windows.Forms.Label()
        Me.txtcodDir = New System.Windows.Forms.TextBox()
        Me.chkCst = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Ordenarporsoporte = New System.Windows.Forms.RadioButton()
        Me.Ordenarporprincipal = New System.Windows.Forms.RadioButton()
        Me.CboSoporte = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboDocumentos = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ArticulosGrupos.SuspendLayout()
        Me.Agrupacion.SuspendLayout()
        Me.ValoracionInventario.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOpciones, Me.ToolStripSeparator2, Me.cmbReportes, Me.ToolStripSeparator1, Me.Actualizar, Me.ToolStripSeparator4, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(974, 39)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnOpciones
        '
        Me.btnOpciones.CheckOnClick = True
        Me.btnOpciones.Image = CType(resources.GetObject("btnOpciones.Image"), System.Drawing.Image)
        Me.btnOpciones.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOpciones.Name = "btnOpciones"
        Me.btnOpciones.Size = New System.Drawing.Size(61, 36)
        Me.btnOpciones.Text = "Opciones"
        Me.btnOpciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'cmbReportes
        '
        Me.cmbReportes.AutoSize = False
        Me.cmbReportes.BackColor = System.Drawing.Color.White
        Me.cmbReportes.DropDownWidth = 200
        Me.cmbReportes.Name = "cmbReportes"
        Me.cmbReportes.Size = New System.Drawing.Size(200, 23)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'Actualizar
        '
        Me.Actualizar.Checked = True
        Me.Actualizar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Actualizar.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Actualizar.Image = CType(resources.GetObject("Actualizar.Image"), System.Drawing.Image)
        Me.Actualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Actualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Actualizar.Name = "Actualizar"
        Me.Actualizar.Size = New System.Drawing.Size(132, 36)
        Me.Actualizar.Text = "GenerarReporte"
        Me.Actualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 39)
        '
        'btnSalir
        '
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(33, 36)
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 39)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkUbicacion)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Orden)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkArtExis)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkSaldoFec)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtFecha)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboBodega)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtMedidas)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnMed)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cboTipoIngreso)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtFechaFin)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtFechaIni)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label16)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ArticulosGrupos)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Agrupacion)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ValoracionInventario)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1MinSize = 20
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ReportViewer1)
        Me.SplitContainer1.Size = New System.Drawing.Size(974, 525)
        Me.SplitContainer1.SplitterDistance = 238
        Me.SplitContainer1.TabIndex = 3
        '
        'chkUbicacion
        '
        Me.chkUbicacion.AutoSize = True
        Me.chkUbicacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkUbicacion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkUbicacion.Location = New System.Drawing.Point(11, 82)
        Me.chkUbicacion.Name = "chkUbicacion"
        Me.chkUbicacion.Size = New System.Drawing.Size(144, 17)
        Me.chkUbicacion.TabIndex = 43
        Me.chkUbicacion.Text = "Incluir ubicación general:"
        Me.chkUbicacion.UseVisualStyleBackColor = True
        '
        'Orden
        '
        Me.Orden.AutoSize = True
        Me.Orden.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Orden.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Orden.Location = New System.Drawing.Point(11, 65)
        Me.Orden.Name = "Orden"
        Me.Orden.Size = New System.Drawing.Size(142, 17)
        Me.Orden.TabIndex = 42
        Me.Orden.Text = "Ordenar alfabeticamente"
        Me.Orden.UseVisualStyleBackColor = True
        '
        'chkArtExis
        '
        Me.chkArtExis.AutoSize = True
        Me.chkArtExis.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkArtExis.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkArtExis.Location = New System.Drawing.Point(10, 49)
        Me.chkArtExis.Name = "chkArtExis"
        Me.chkArtExis.Size = New System.Drawing.Size(168, 17)
        Me.chkArtExis.TabIndex = 23
        Me.chkArtExis.Text = "Incluir artículos sin Existencia:"
        Me.chkArtExis.UseVisualStyleBackColor = True
        '
        'chkSaldoFec
        '
        Me.chkSaldoFec.AutoSize = True
        Me.chkSaldoFec.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkSaldoFec.Location = New System.Drawing.Point(14, 469)
        Me.chkSaldoFec.Name = "chkSaldoFec"
        Me.chkSaldoFec.Size = New System.Drawing.Size(153, 17)
        Me.chkSaldoFec.TabIndex = 19
        Me.chkSaldoFec.Text = "Visualizar Saldo a la Fecha"
        Me.chkSaldoFec.UseVisualStyleBackColor = True
        Me.chkSaldoFec.Visible = False
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(74, 28)
        Me.txtFecha.Mask = "00/00/0000"
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(67, 20)
        Me.txtFecha.TabIndex = 4
        Me.txtFecha.ValidatingType = GetType(Date)
        '
        'cboBodega
        '
        Me.cboBodega.FormattingEnabled = True
        Me.cboBodega.Location = New System.Drawing.Point(67, 5)
        Me.cboBodega.Name = "cboBodega"
        Me.cboBodega.Size = New System.Drawing.Size(163, 21)
        Me.cboBodega.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Bodega:"
        '
        'txtMedidas
        '
        Me.txtMedidas.Location = New System.Drawing.Point(65, 445)
        Me.txtMedidas.Name = "txtMedidas"
        Me.txtMedidas.Size = New System.Drawing.Size(125, 20)
        Me.txtMedidas.TabIndex = 25
        Me.txtMedidas.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 448)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Medidas:"
        Me.Label9.Visible = False
        '
        'btnMed
        '
        Me.btnMed.Location = New System.Drawing.Point(190, 445)
        Me.btnMed.Name = "btnMed"
        Me.btnMed.Size = New System.Drawing.Size(21, 21)
        Me.btnMed.TabIndex = 26
        Me.btnMed.Text = "..."
        Me.btnMed.UseVisualStyleBackColor = True
        Me.btnMed.Visible = False
        '
        'cboTipoIngreso
        '
        Me.cboTipoIngreso.FormattingEnabled = True
        Me.cboTipoIngreso.Location = New System.Drawing.Point(83, 471)
        Me.cboTipoIngreso.Name = "cboTipoIngreso"
        Me.cboTipoIngreso.Size = New System.Drawing.Size(148, 21)
        Me.cboTipoIngreso.TabIndex = 21
        Me.cboTipoIngreso.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 474)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Tipo Ingreso:"
        Me.Label10.Visible = False
        '
        'txtFechaFin
        '
        Me.txtFechaFin.Location = New System.Drawing.Point(155, 28)
        Me.txtFechaFin.Mask = "00/00/0000"
        Me.txtFechaFin.Name = "txtFechaFin"
        Me.txtFechaFin.Size = New System.Drawing.Size(67, 20)
        Me.txtFechaFin.TabIndex = 28
        Me.txtFechaFin.ValidatingType = GetType(Date)
        '
        'txtFechaIni
        '
        Me.txtFechaIni.Location = New System.Drawing.Point(75, 28)
        Me.txtFechaIni.Mask = "00/00/0000"
        Me.txtFechaIni.Name = "txtFechaIni"
        Me.txtFechaIni.Size = New System.Drawing.Size(67, 20)
        Me.txtFechaIni.TabIndex = 27
        Me.txtFechaIni.ValidatingType = GetType(Date)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "A la Fecha:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(14, 30)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(63, 13)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "Periodo del:"
        '
        'ArticulosGrupos
        '
        Me.ArticulosGrupos.Controls.Add(Me.cboSubg)
        Me.ArticulosGrupos.Controls.Add(Me.Label6)
        Me.ArticulosGrupos.Controls.Add(Me.cboGrupo)
        Me.ArticulosGrupos.Controls.Add(Me.Label5)
        Me.ArticulosGrupos.Controls.Add(Me.cboClase)
        Me.ArticulosGrupos.Controls.Add(Me.Label4)
        Me.ArticulosGrupos.Controls.Add(Me.cboCategoria)
        Me.ArticulosGrupos.Controls.Add(Me.Label3)
        Me.ArticulosGrupos.Controls.Add(Me.btnCodFin)
        Me.ArticulosGrupos.Controls.Add(Me.txtCodFin)
        Me.ArticulosGrupos.Controls.Add(Me.Label8)
        Me.ArticulosGrupos.Controls.Add(Me.btnCodIni)
        Me.ArticulosGrupos.Controls.Add(Me.txtcodIni)
        Me.ArticulosGrupos.Controls.Add(Me.Label7)
        Me.ArticulosGrupos.Location = New System.Drawing.Point(7, 176)
        Me.ArticulosGrupos.Name = "ArticulosGrupos"
        Me.ArticulosGrupos.Size = New System.Drawing.Size(223, 166)
        Me.ArticulosGrupos.TabIndex = 22
        Me.ArticulosGrupos.TabStop = False
        Me.ArticulosGrupos.Text = "Opciones de selección"
        '
        'cboSubg
        '
        Me.cboSubg.FormattingEnabled = True
        Me.cboSubg.Location = New System.Drawing.Point(73, 139)
        Me.cboSubg.Name = "cboSubg"
        Me.cboSubg.Size = New System.Drawing.Size(140, 21)
        Me.cboSubg.TabIndex = 26
        Me.cboSubg.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 142)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Subgrupo:"
        Me.Label6.Visible = False
        '
        'cboGrupo
        '
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Location = New System.Drawing.Point(73, 113)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(140, 21)
        Me.cboGrupo.TabIndex = 24
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(27, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Grupo:"
        '
        'cboClase
        '
        Me.cboClase.FormattingEnabled = True
        Me.cboClase.Location = New System.Drawing.Point(73, 87)
        Me.cboClase.Name = "cboClase"
        Me.cboClase.Size = New System.Drawing.Size(140, 21)
        Me.cboClase.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(30, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Clase:"
        '
        'cboCategoria
        '
        Me.cboCategoria.FormattingEnabled = True
        Me.cboCategoria.Location = New System.Drawing.Point(73, 62)
        Me.cboCategoria.Name = "cboCategoria"
        Me.cboCategoria.Size = New System.Drawing.Size(140, 21)
        Me.cboCategoria.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Categoria:"
        '
        'btnCodFin
        '
        Me.btnCodFin.Location = New System.Drawing.Point(201, 37)
        Me.btnCodFin.Name = "btnCodFin"
        Me.btnCodFin.Size = New System.Drawing.Size(21, 21)
        Me.btnCodFin.TabIndex = 13
        Me.btnCodFin.Text = "..."
        Me.btnCodFin.UseVisualStyleBackColor = True
        '
        'txtCodFin
        '
        Me.txtCodFin.Location = New System.Drawing.Point(75, 37)
        Me.txtCodFin.Name = "txtCodFin"
        Me.txtCodFin.Size = New System.Drawing.Size(125, 20)
        Me.txtCodFin.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Artículo Final:"
        '
        'btnCodIni
        '
        Me.btnCodIni.Location = New System.Drawing.Point(200, 14)
        Me.btnCodIni.Name = "btnCodIni"
        Me.btnCodIni.Size = New System.Drawing.Size(21, 21)
        Me.btnCodIni.TabIndex = 10
        Me.btnCodIni.Text = "..."
        Me.btnCodIni.UseVisualStyleBackColor = True
        '
        'txtcodIni
        '
        Me.txtcodIni.Location = New System.Drawing.Point(75, 14)
        Me.txtcodIni.Name = "txtcodIni"
        Me.txtcodIni.Size = New System.Drawing.Size(125, 20)
        Me.txtcodIni.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Artículo Inicial:"
        '
        'Agrupacion
        '
        Me.Agrupacion.Controls.Add(Me.chkSubg)
        Me.Agrupacion.Controls.Add(Me.chkClase)
        Me.Agrupacion.Controls.Add(Me.chkGrupo)
        Me.Agrupacion.Controls.Add(Me.chkCategoria)
        Me.Agrupacion.Location = New System.Drawing.Point(7, 103)
        Me.Agrupacion.Name = "Agrupacion"
        Me.Agrupacion.Size = New System.Drawing.Size(223, 69)
        Me.Agrupacion.TabIndex = 2
        Me.Agrupacion.TabStop = False
        Me.Agrupacion.Text = "Agrupación"
        '
        'chkSubg
        '
        Me.chkSubg.AutoSize = True
        Me.chkSubg.Location = New System.Drawing.Point(118, 41)
        Me.chkSubg.Name = "chkSubg"
        Me.chkSubg.Size = New System.Drawing.Size(72, 17)
        Me.chkSubg.TabIndex = 3
        Me.chkSubg.Text = "Subgrupo"
        Me.chkSubg.UseVisualStyleBackColor = True
        '
        'chkClase
        '
        Me.chkClase.AutoSize = True
        Me.chkClase.Location = New System.Drawing.Point(118, 19)
        Me.chkClase.Name = "chkClase"
        Me.chkClase.Size = New System.Drawing.Size(52, 17)
        Me.chkClase.TabIndex = 2
        Me.chkClase.Text = "Clase"
        Me.chkClase.UseVisualStyleBackColor = True
        '
        'chkGrupo
        '
        Me.chkGrupo.AutoSize = True
        Me.chkGrupo.Location = New System.Drawing.Point(16, 41)
        Me.chkGrupo.Name = "chkGrupo"
        Me.chkGrupo.Size = New System.Drawing.Size(55, 17)
        Me.chkGrupo.TabIndex = 1
        Me.chkGrupo.Text = "Grupo"
        Me.chkGrupo.UseVisualStyleBackColor = True
        '
        'chkCategoria
        '
        Me.chkCategoria.AutoSize = True
        Me.chkCategoria.Location = New System.Drawing.Point(16, 18)
        Me.chkCategoria.Name = "chkCategoria"
        Me.chkCategoria.Size = New System.Drawing.Size(71, 17)
        Me.chkCategoria.TabIndex = 0
        Me.chkCategoria.Text = "Categoria"
        Me.chkCategoria.UseVisualStyleBackColor = True
        '
        'ValoracionInventario
        '
        Me.ValoracionInventario.Controls.Add(Me.optSinCost)
        Me.ValoracionInventario.Controls.Add(Me.optPvp4)
        Me.ValoracionInventario.Controls.Add(Me.optPvp2)
        Me.ValoracionInventario.Controls.Add(Me.optUltCost)
        Me.ValoracionInventario.Controls.Add(Me.optPvp5)
        Me.ValoracionInventario.Controls.Add(Me.optPvp3)
        Me.ValoracionInventario.Controls.Add(Me.optPvp1)
        Me.ValoracionInventario.Controls.Add(Me.optCostoPro)
        Me.ValoracionInventario.Location = New System.Drawing.Point(9, 348)
        Me.ValoracionInventario.Name = "ValoracionInventario"
        Me.ValoracionInventario.Size = New System.Drawing.Size(221, 112)
        Me.ValoracionInventario.TabIndex = 18
        Me.ValoracionInventario.TabStop = False
        Me.ValoracionInventario.Text = "Valoración del inventario:"
        '
        'optSinCost
        '
        Me.optSinCost.AutoSize = True
        Me.optSinCost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.optSinCost.Location = New System.Drawing.Point(117, 89)
        Me.optSinCost.Name = "optSinCost"
        Me.optSinCost.Size = New System.Drawing.Size(97, 17)
        Me.optSinCost.TabIndex = 7
        Me.optSinCost.Text = "Sin Costo         "
        Me.optSinCost.UseVisualStyleBackColor = True
        '
        'optPvp4
        '
        Me.optPvp4.AutoSize = True
        Me.optPvp4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.optPvp4.Location = New System.Drawing.Point(116, 65)
        Me.optPvp4.Name = "optPvp4"
        Me.optPvp4.Size = New System.Drawing.Size(98, 17)
        Me.optPvp4.TabIndex = 6
        Me.optPvp4.Text = "Precio Venta 4 "
        Me.optPvp4.UseVisualStyleBackColor = True
        '
        'optPvp2
        '
        Me.optPvp2.AutoSize = True
        Me.optPvp2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.optPvp2.Location = New System.Drawing.Point(116, 42)
        Me.optPvp2.Name = "optPvp2"
        Me.optPvp2.Size = New System.Drawing.Size(98, 17)
        Me.optPvp2.TabIndex = 5
        Me.optPvp2.Text = "Precio Venta 2 "
        Me.optPvp2.UseVisualStyleBackColor = True
        '
        'optUltCost
        '
        Me.optUltCost.AutoSize = True
        Me.optUltCost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.optUltCost.Location = New System.Drawing.Point(115, 19)
        Me.optUltCost.Name = "optUltCost"
        Me.optUltCost.Size = New System.Drawing.Size(99, 17)
        Me.optUltCost.TabIndex = 4
        Me.optUltCost.Text = "Ultimo Costo     "
        Me.optUltCost.UseVisualStyleBackColor = True
        '
        'optPvp5
        '
        Me.optPvp5.AutoSize = True
        Me.optPvp5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.optPvp5.Location = New System.Drawing.Point(5, 88)
        Me.optPvp5.Name = "optPvp5"
        Me.optPvp5.Size = New System.Drawing.Size(98, 17)
        Me.optPvp5.TabIndex = 3
        Me.optPvp5.Text = "Precio Venta 5 "
        Me.optPvp5.UseVisualStyleBackColor = True
        '
        'optPvp3
        '
        Me.optPvp3.AutoSize = True
        Me.optPvp3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.optPvp3.Location = New System.Drawing.Point(5, 65)
        Me.optPvp3.Name = "optPvp3"
        Me.optPvp3.Size = New System.Drawing.Size(98, 17)
        Me.optPvp3.TabIndex = 2
        Me.optPvp3.Text = "Precio Venta 3 "
        Me.optPvp3.UseVisualStyleBackColor = True
        '
        'optPvp1
        '
        Me.optPvp1.AutoSize = True
        Me.optPvp1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.optPvp1.Location = New System.Drawing.Point(5, 42)
        Me.optPvp1.Name = "optPvp1"
        Me.optPvp1.Size = New System.Drawing.Size(98, 17)
        Me.optPvp1.TabIndex = 1
        Me.optPvp1.Text = "Precio Venta 1 "
        Me.optPvp1.UseVisualStyleBackColor = True
        '
        'optCostoPro
        '
        Me.optCostoPro.AutoSize = True
        Me.optCostoPro.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.optCostoPro.Checked = True
        Me.optCostoPro.Location = New System.Drawing.Point(4, 19)
        Me.optCostoPro.Name = "optCostoPro"
        Me.optCostoPro.Size = New System.Drawing.Size(99, 17)
        Me.optCostoPro.TabIndex = 0
        Me.optCostoPro.TabStop = True
        Me.optCostoPro.Text = "Costo Promedio"
        Me.optCostoPro.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btnArtFin)
        Me.GroupBox5.Controls.Add(Me.txtArtFin)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.btnArtIni)
        Me.GroupBox5.Controls.Add(Me.txtArtIni)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 234)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(229, 75)
        Me.GroupBox5.TabIndex = 40
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Artículos"
        '
        'btnArtFin
        '
        Me.btnArtFin.Location = New System.Drawing.Point(203, 43)
        Me.btnArtFin.Name = "btnArtFin"
        Me.btnArtFin.Size = New System.Drawing.Size(21, 21)
        Me.btnArtFin.TabIndex = 35
        Me.btnArtFin.Text = "..."
        Me.btnArtFin.UseVisualStyleBackColor = True
        '
        'txtArtFin
        '
        Me.txtArtFin.Location = New System.Drawing.Point(77, 43)
        Me.txtArtFin.Name = "txtArtFin"
        Me.txtArtFin.Size = New System.Drawing.Size(125, 20)
        Me.txtArtFin.TabIndex = 34
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(5, 46)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 13)
        Me.Label13.TabIndex = 33
        Me.Label13.Text = "Codigo Final:"
        '
        'btnArtIni
        '
        Me.btnArtIni.Location = New System.Drawing.Point(202, 19)
        Me.btnArtIni.Name = "btnArtIni"
        Me.btnArtIni.Size = New System.Drawing.Size(21, 21)
        Me.btnArtIni.TabIndex = 32
        Me.btnArtIni.Text = "..."
        Me.btnArtIni.UseVisualStyleBackColor = True
        '
        'txtArtIni
        '
        Me.txtArtIni.Location = New System.Drawing.Point(77, 19)
        Me.txtArtIni.Name = "txtArtIni"
        Me.txtArtIni.Size = New System.Drawing.Size(125, 20)
        Me.txtArtIni.TabIndex = 31
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(5, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(73, 13)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "Codigo Inicial:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TotalDoc)
        Me.Panel1.Controls.Add(Me.GroupBox6)
        Me.Panel1.Controls.Add(Me.chkCst)
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Location = New System.Drawing.Point(6, 49)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(228, 465)
        Me.Panel1.TabIndex = 27
        Me.Panel1.Visible = False
        '
        'TotalDoc
        '
        Me.TotalDoc.AutoSize = True
        Me.TotalDoc.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.TotalDoc.Location = New System.Drawing.Point(101, 11)
        Me.TotalDoc.Name = "TotalDoc"
        Me.TotalDoc.Size = New System.Drawing.Size(124, 17)
        Me.TotalDoc.TabIndex = 44
        Me.TotalDoc.Text = "Total por documento"
        Me.TotalDoc.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label18)
        Me.GroupBox6.Controls.Add(Me.Label17)
        Me.GroupBox6.Controls.Add(Me.btnDir)
        Me.GroupBox6.Controls.Add(Me.lblnombre)
        Me.GroupBox6.Controls.Add(Me.txtcodDir)
        Me.GroupBox6.Location = New System.Drawing.Point(0, 262)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(226, 72)
        Me.GroupBox6.TabIndex = 43
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Destino/Origen"
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(8, 48)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(212, 13)
        Me.Label18.TabIndex = 5
        Me.Label18.Text = "Nombre:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(13, 22)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(43, 13)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "Codigo:"
        '
        'btnDir
        '
        Me.btnDir.Location = New System.Drawing.Point(197, 18)
        Me.btnDir.Name = "btnDir"
        Me.btnDir.Size = New System.Drawing.Size(21, 21)
        Me.btnDir.TabIndex = 3
        Me.btnDir.Text = "..."
        Me.btnDir.UseVisualStyleBackColor = True
        '
        'lblnombre
        '
        Me.lblnombre.AutoSize = True
        Me.lblnombre.Location = New System.Drawing.Point(65, 48)
        Me.lblnombre.Name = "lblnombre"
        Me.lblnombre.Size = New System.Drawing.Size(0, 13)
        Me.lblnombre.TabIndex = 2
        '
        'txtcodDir
        '
        Me.txtcodDir.Location = New System.Drawing.Point(62, 19)
        Me.txtcodDir.Name = "txtcodDir"
        Me.txtcodDir.Size = New System.Drawing.Size(135, 20)
        Me.txtcodDir.TabIndex = 0
        '
        'chkCst
        '
        Me.chkCst.AutoSize = True
        Me.chkCst.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCst.Checked = True
        Me.chkCst.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCst.Location = New System.Drawing.Point(7, 11)
        Me.chkCst.Name = "chkCst"
        Me.chkCst.Size = New System.Drawing.Size(90, 17)
        Me.chkCst.TabIndex = 36
        Me.chkCst.Text = "Incluye Costo"
        Me.chkCst.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Ordenarporsoporte)
        Me.GroupBox4.Controls.Add(Me.Ordenarporprincipal)
        Me.GroupBox4.Controls.Add(Me.CboSoporte)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.cboDocumentos)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Location = New System.Drawing.Point(0, 54)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(228, 128)
        Me.GroupBox4.TabIndex = 39
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Tipo Documentos"
        Me.ToolTip1.SetToolTip(Me.GroupBox4, resources.GetString("GroupBox4.ToolTip"))
        '
        'Ordenarporsoporte
        '
        Me.Ordenarporsoporte.AutoSize = True
        Me.Ordenarporsoporte.Location = New System.Drawing.Point(138, 72)
        Me.Ordenarporsoporte.Name = "Ordenarporsoporte"
        Me.Ordenarporsoporte.Size = New System.Drawing.Size(84, 17)
        Me.Ordenarporsoporte.TabIndex = 26
        Me.Ordenarporsoporte.Text = "Ordenar por:"
        Me.Ordenarporsoporte.UseVisualStyleBackColor = True
        '
        'Ordenarporprincipal
        '
        Me.Ordenarporprincipal.AutoSize = True
        Me.Ordenarporprincipal.Checked = True
        Me.Ordenarporprincipal.Location = New System.Drawing.Point(134, 22)
        Me.Ordenarporprincipal.Name = "Ordenarporprincipal"
        Me.Ordenarporprincipal.Size = New System.Drawing.Size(84, 17)
        Me.Ordenarporprincipal.TabIndex = 25
        Me.Ordenarporprincipal.TabStop = True
        Me.Ordenarporprincipal.Text = "Ordenar por:"
        Me.Ordenarporprincipal.UseVisualStyleBackColor = True
        '
        'CboSoporte
        '
        Me.CboSoporte.FormattingEnabled = True
        Me.CboSoporte.Location = New System.Drawing.Point(4, 91)
        Me.CboSoporte.Name = "CboSoporte"
        Me.CboSoporte.Size = New System.Drawing.Size(218, 21)
        Me.CboSoporte.TabIndex = 24
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(8, 74)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(96, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Soporte/referencia"
        '
        'cboDocumentos
        '
        Me.cboDocumentos.FormattingEnabled = True
        Me.cboDocumentos.Location = New System.Drawing.Point(5, 42)
        Me.cboDocumentos.Name = "cboDocumentos"
        Me.cboDocumentos.Size = New System.Drawing.Size(218, 21)
        Me.cboDocumentos.TabIndex = 22
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(11, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Principal"
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(732, 525)
        Me.ReportViewer1.TabIndex = 1
        '
        'repInv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(974, 564)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "repInv"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REPORTES DE INVENTARIO"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ArticulosGrupos.ResumeLayout(False)
        Me.ArticulosGrupos.PerformLayout()
        Me.Agrupacion.ResumeLayout(False)
        Me.Agrupacion.PerformLayout()
        Me.ValoracionInventario.ResumeLayout(False)
        Me.ValoracionInventario.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnOpciones As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Actualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents cboBodega As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Agrupacion As System.Windows.Forms.GroupBox
    Friend WithEvents btnCodFin As System.Windows.Forms.Button
    Friend WithEvents txtCodFin As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnCodIni As System.Windows.Forms.Button
    Friend WithEvents txtcodIni As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ValoracionInventario As System.Windows.Forms.GroupBox
    Friend WithEvents optSinCost As System.Windows.Forms.RadioButton
    Friend WithEvents optPvp4 As System.Windows.Forms.RadioButton
    Friend WithEvents optPvp2 As System.Windows.Forms.RadioButton
    Friend WithEvents optUltCost As System.Windows.Forms.RadioButton
    Friend WithEvents optPvp5 As System.Windows.Forms.RadioButton
    Friend WithEvents optPvp3 As System.Windows.Forms.RadioButton
    Friend WithEvents optPvp1 As System.Windows.Forms.RadioButton
    Friend WithEvents optCostoPro As System.Windows.Forms.RadioButton
    Friend WithEvents chkSaldoFec As System.Windows.Forms.CheckBox
    Friend WithEvents cboTipoIngreso As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ArticulosGrupos As System.Windows.Forms.GroupBox
    Friend WithEvents chkArtExis As System.Windows.Forms.CheckBox
    Friend WithEvents cboSubg As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboClase As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkSubg As System.Windows.Forms.CheckBox
    Friend WithEvents chkClase As System.Windows.Forms.CheckBox
    Friend WithEvents chkGrupo As System.Windows.Forms.CheckBox
    Friend WithEvents chkCategoria As System.Windows.Forms.CheckBox
    Friend WithEvents btnMed As System.Windows.Forms.Button
    Friend WithEvents txtMedidas As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDocumentos As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents chkCst As System.Windows.Forms.CheckBox
    Friend WithEvents btnArtFin As System.Windows.Forms.Button
    Friend WithEvents txtArtFin As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnArtIni As System.Windows.Forms.Button
    Friend WithEvents txtArtIni As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtFechaFin As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtFechaIni As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents CboSoporte As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Ordenarporsoporte As System.Windows.Forms.RadioButton
    Friend WithEvents Ordenarporprincipal As System.Windows.Forms.RadioButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnDir As System.Windows.Forms.Button
    Friend WithEvents lblnombre As System.Windows.Forms.Label
    Friend WithEvents txtcodDir As System.Windows.Forms.TextBox
    Friend WithEvents TotalDoc As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmbReportes As System.Windows.Forms.ToolStripComboBox
    Private WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents chkUbicacion As System.Windows.Forms.CheckBox
    Friend WithEvents Orden As System.Windows.Forms.CheckBox

End Class
