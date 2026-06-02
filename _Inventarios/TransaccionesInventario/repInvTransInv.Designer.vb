<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class repInvTransInv
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(repInvTransInv))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnOpciones = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Actualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.txtFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.txtFechaIni = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Ordenarporsoporte = New System.Windows.Forms.RadioButton()
        Me.Ordenarporprincipal = New System.Windows.Forms.RadioButton()
        Me.CboSoporte = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtcodDir = New System.Windows.Forms.TextBox()
        Me.cboDocumentos = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkPorDocumento = New System.Windows.Forms.RadioButton()
        Me.chkPorArticulo = New System.Windows.Forms.RadioButton()
        Me.TotalDoc = New System.Windows.Forms.CheckBox()
        Me.ArticulosGrupos = New System.Windows.Forms.GroupBox()
        Me.btnCodFin = New System.Windows.Forms.Button()
        Me.txtCodFin = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnCodIni = New System.Windows.Forms.Button()
        Me.txtcodIni = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkSubg = New System.Windows.Forms.CheckBox()
        Me.chkGrupo = New System.Windows.Forms.CheckBox()
        Me.chkClase = New System.Windows.Forms.CheckBox()
        Me.chkCategoria = New System.Windows.Forms.CheckBox()
        Me.cboSubg = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboClase = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboCategoria = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.cboBodega = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkOrden = New System.Windows.Forms.CheckBox()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ArticulosGrupos.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOpciones, Me.ToolStripSeparator2, Me.Actualizar, Me.ToolStripSeparator4, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(974, 38)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnOpciones
        '
        Me.btnOpciones.CheckOnClick = True
        Me.btnOpciones.Image = CType(resources.GetObject("btnOpciones.Image"), System.Drawing.Image)
        Me.btnOpciones.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOpciones.Name = "btnOpciones"
        Me.btnOpciones.Size = New System.Drawing.Size(61, 35)
        Me.btnOpciones.Text = "Opciones"
        Me.btnOpciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 38)
        '
        'Actualizar
        '
        Me.Actualizar.Checked = True
        Me.Actualizar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Actualizar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Actualizar.Image = CType(resources.GetObject("Actualizar.Image"), System.Drawing.Image)
        Me.Actualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Actualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Actualizar.Name = "Actualizar"
        Me.Actualizar.Size = New System.Drawing.Size(52, 35)
        Me.Actualizar.Text = "Generar"
        Me.Actualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Actualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 38)
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
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 38)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtFechaFin)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtFechaIni)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label16)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1MinSize = 20
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ReportViewer1)
        Me.SplitContainer1.Size = New System.Drawing.Size(974, 526)
        Me.SplitContainer1.SplitterDistance = 300
        Me.SplitContainer1.TabIndex = 3
        '
        'txtFechaFin
        '
        Me.txtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaFin.Location = New System.Drawing.Point(153, 12)
        Me.txtFechaFin.Name = "txtFechaFin"
        Me.txtFechaFin.Size = New System.Drawing.Size(80, 20)
        Me.txtFechaFin.TabIndex = 30
        '
        'txtFechaIni
        '
        Me.txtFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaIni.Location = New System.Drawing.Point(70, 12)
        Me.txtFechaIni.Name = "txtFechaIni"
        Me.txtFechaIni.Size = New System.Drawing.Size(80, 20)
        Me.txtFechaIni.TabIndex = 29
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(7, 14)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(63, 13)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "Periodo del:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.Ordenarporsoporte)
        Me.GroupBox4.Controls.Add(Me.Ordenarporprincipal)
        Me.GroupBox4.Controls.Add(Me.CboSoporte)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.txtcodDir)
        Me.GroupBox4.Controls.Add(Me.cboDocumentos)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 110)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(288, 160)
        Me.GroupBox4.TabIndex = 39
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Selección de documentos"
        Me.ToolTip1.SetToolTip(Me.GroupBox4, resources.GetString("GroupBox4.ToolTip"))
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Destino/Origen"
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(10, 138)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(269, 13)
        Me.Label18.TabIndex = 5
        Me.Label18.Text = "Nombre:"
        '
        'Ordenarporsoporte
        '
        Me.Ordenarporsoporte.AutoSize = True
        Me.Ordenarporsoporte.Location = New System.Drawing.Point(231, 68)
        Me.Ordenarporsoporte.Name = "Ordenarporsoporte"
        Me.Ordenarporsoporte.Size = New System.Drawing.Size(54, 17)
        Me.Ordenarporsoporte.TabIndex = 26
        Me.Ordenarporsoporte.Text = "Orden"
        Me.ToolTip1.SetToolTip(Me.Ordenarporsoporte, "Para ordenar documento por soporte/ referencia")
        Me.Ordenarporsoporte.UseVisualStyleBackColor = True
        Me.Ordenarporsoporte.Visible = False
        '
        'Ordenarporprincipal
        '
        Me.Ordenarporprincipal.AutoSize = True
        Me.Ordenarporprincipal.Checked = True
        Me.Ordenarporprincipal.Location = New System.Drawing.Point(231, 32)
        Me.Ordenarporprincipal.Name = "Ordenarporprincipal"
        Me.Ordenarporprincipal.Size = New System.Drawing.Size(54, 17)
        Me.Ordenarporprincipal.TabIndex = 25
        Me.Ordenarporprincipal.TabStop = True
        Me.Ordenarporprincipal.Text = "Orden"
        Me.ToolTip1.SetToolTip(Me.Ordenarporprincipal, "Para ordenar el reporte por documento principal")
        Me.Ordenarporprincipal.UseVisualStyleBackColor = True
        Me.Ordenarporprincipal.Visible = False
        '
        'CboSoporte
        '
        Me.CboSoporte.FormattingEnabled = True
        Me.CboSoporte.Location = New System.Drawing.Point(4, 67)
        Me.CboSoporte.Name = "CboSoporte"
        Me.CboSoporte.Size = New System.Drawing.Size(218, 21)
        Me.CboSoporte.TabIndex = 24
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(8, 54)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(96, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Soporte/referencia"
        '
        'txtcodDir
        '
        Me.txtcodDir.Location = New System.Drawing.Point(11, 113)
        Me.txtcodDir.Name = "txtcodDir"
        Me.txtcodDir.Size = New System.Drawing.Size(247, 20)
        Me.txtcodDir.TabIndex = 0
        '
        'cboDocumentos
        '
        Me.cboDocumentos.FormattingEnabled = True
        Me.cboDocumentos.Location = New System.Drawing.Point(5, 29)
        Me.cboDocumentos.Name = "cboDocumentos"
        Me.cboDocumentos.Size = New System.Drawing.Size(218, 21)
        Me.cboDocumentos.TabIndex = 22
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(11, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Principal"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.chkOrden)
        Me.Panel1.Controls.Add(Me.chkPorDocumento)
        Me.Panel1.Controls.Add(Me.chkPorArticulo)
        Me.Panel1.Controls.Add(Me.TotalDoc)
        Me.Panel1.Controls.Add(Me.ArticulosGrupos)
        Me.Panel1.Location = New System.Drawing.Point(6, 39)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(291, 476)
        Me.Panel1.TabIndex = 27
        '
        'chkPorDocumento
        '
        Me.chkPorDocumento.AutoSize = True
        Me.chkPorDocumento.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPorDocumento.Location = New System.Drawing.Point(137, 14)
        Me.chkPorDocumento.Name = "chkPorDocumento"
        Me.chkPorDocumento.Size = New System.Drawing.Size(101, 17)
        Me.chkPorDocumento.TabIndex = 46
        Me.chkPorDocumento.Text = "por Documento "
        Me.ToolTip1.SetToolTip(Me.chkPorDocumento, "Para ordenar el reporte por documento principal")
        Me.chkPorDocumento.UseVisualStyleBackColor = True
        '
        'chkPorArticulo
        '
        Me.chkPorArticulo.AutoSize = True
        Me.chkPorArticulo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPorArticulo.Checked = True
        Me.chkPorArticulo.Location = New System.Drawing.Point(14, 14)
        Me.chkPorArticulo.Name = "chkPorArticulo"
        Me.chkPorArticulo.Size = New System.Drawing.Size(117, 17)
        Me.chkPorArticulo.TabIndex = 45
        Me.chkPorArticulo.TabStop = True
        Me.chkPorArticulo.Text = "Lista por :  Artículo "
        Me.ToolTip1.SetToolTip(Me.chkPorArticulo, "Para ordenar el reporte por documento principal")
        Me.chkPorArticulo.UseVisualStyleBackColor = True
        '
        'TotalDoc
        '
        Me.TotalDoc.AutoSize = True
        Me.TotalDoc.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.TotalDoc.Location = New System.Drawing.Point(16, 30)
        Me.TotalDoc.Name = "TotalDoc"
        Me.TotalDoc.Size = New System.Drawing.Size(134, 17)
        Me.TotalDoc.TabIndex = 44
        Me.TotalDoc.Text = "Incluir totales internos :"
        Me.TotalDoc.UseVisualStyleBackColor = True
        '
        'ArticulosGrupos
        '
        Me.ArticulosGrupos.Controls.Add(Me.btnCodFin)
        Me.ArticulosGrupos.Controls.Add(Me.txtCodFin)
        Me.ArticulosGrupos.Controls.Add(Me.Label8)
        Me.ArticulosGrupos.Controls.Add(Me.btnCodIni)
        Me.ArticulosGrupos.Controls.Add(Me.txtcodIni)
        Me.ArticulosGrupos.Controls.Add(Me.Label7)
        Me.ArticulosGrupos.Controls.Add(Me.chkSubg)
        Me.ArticulosGrupos.Controls.Add(Me.chkGrupo)
        Me.ArticulosGrupos.Controls.Add(Me.chkClase)
        Me.ArticulosGrupos.Controls.Add(Me.chkCategoria)
        Me.ArticulosGrupos.Controls.Add(Me.cboSubg)
        Me.ArticulosGrupos.Controls.Add(Me.Label6)
        Me.ArticulosGrupos.Controls.Add(Me.cboGrupo)
        Me.ArticulosGrupos.Controls.Add(Me.Label5)
        Me.ArticulosGrupos.Controls.Add(Me.cboClase)
        Me.ArticulosGrupos.Controls.Add(Me.Label4)
        Me.ArticulosGrupos.Controls.Add(Me.cboCategoria)
        Me.ArticulosGrupos.Controls.Add(Me.Label3)
        Me.ArticulosGrupos.Location = New System.Drawing.Point(1, 237)
        Me.ArticulosGrupos.Name = "ArticulosGrupos"
        Me.ArticulosGrupos.Size = New System.Drawing.Size(287, 166)
        Me.ArticulosGrupos.TabIndex = 22
        Me.ArticulosGrupos.TabStop = False
        Me.ArticulosGrupos.Text = "Opciones de selección de artículos"
        '
        'btnCodFin
        '
        Me.btnCodFin.Location = New System.Drawing.Point(217, 130)
        Me.btnCodFin.Name = "btnCodFin"
        Me.btnCodFin.Size = New System.Drawing.Size(21, 21)
        Me.btnCodFin.TabIndex = 36
        Me.btnCodFin.Text = "..."
        Me.btnCodFin.UseVisualStyleBackColor = True
        '
        'txtCodFin
        '
        Me.txtCodFin.Location = New System.Drawing.Point(63, 130)
        Me.txtCodFin.Name = "txtCodFin"
        Me.txtCodFin.Size = New System.Drawing.Size(155, 20)
        Me.txtCodFin.TabIndex = 35
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 133)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 13)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Final:"
        '
        'btnCodIni
        '
        Me.btnCodIni.Location = New System.Drawing.Point(216, 107)
        Me.btnCodIni.Name = "btnCodIni"
        Me.btnCodIni.Size = New System.Drawing.Size(21, 21)
        Me.btnCodIni.TabIndex = 33
        Me.btnCodIni.Text = "..."
        Me.btnCodIni.UseVisualStyleBackColor = True
        '
        'txtcodIni
        '
        Me.txtcodIni.Location = New System.Drawing.Point(63, 107)
        Me.txtcodIni.Name = "txtcodIni"
        Me.txtcodIni.Size = New System.Drawing.Size(155, 20)
        Me.txtcodIni.TabIndex = 32
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 110)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "Inicial:"
        '
        'chkSubg
        '
        Me.chkSubg.AutoSize = True
        Me.chkSubg.Location = New System.Drawing.Point(225, 87)
        Me.chkSubg.Name = "chkSubg"
        Me.chkSubg.Size = New System.Drawing.Size(60, 17)
        Me.chkSubg.TabIndex = 30
        Me.chkSubg.Text = "Agrupa"
        Me.chkSubg.UseVisualStyleBackColor = True
        '
        'chkGrupo
        '
        Me.chkGrupo.AutoSize = True
        Me.chkGrupo.Location = New System.Drawing.Point(225, 65)
        Me.chkGrupo.Name = "chkGrupo"
        Me.chkGrupo.Size = New System.Drawing.Size(60, 17)
        Me.chkGrupo.TabIndex = 29
        Me.chkGrupo.Text = "Agrupa"
        Me.chkGrupo.UseVisualStyleBackColor = True
        '
        'chkClase
        '
        Me.chkClase.AutoSize = True
        Me.chkClase.Location = New System.Drawing.Point(225, 42)
        Me.chkClase.Name = "chkClase"
        Me.chkClase.Size = New System.Drawing.Size(60, 17)
        Me.chkClase.TabIndex = 28
        Me.chkClase.Text = "Agrupa"
        Me.chkClase.UseVisualStyleBackColor = True
        '
        'chkCategoria
        '
        Me.chkCategoria.AutoSize = True
        Me.chkCategoria.Location = New System.Drawing.Point(225, 20)
        Me.chkCategoria.Name = "chkCategoria"
        Me.chkCategoria.Size = New System.Drawing.Size(60, 17)
        Me.chkCategoria.TabIndex = 27
        Me.chkCategoria.Text = "Agrupa"
        Me.chkCategoria.UseVisualStyleBackColor = True
        '
        'cboSubg
        '
        Me.cboSubg.FormattingEnabled = True
        Me.cboSubg.Location = New System.Drawing.Point(62, 84)
        Me.cboSubg.Name = "cboSubg"
        Me.cboSubg.Size = New System.Drawing.Size(157, 21)
        Me.cboSubg.TabIndex = 26
        Me.cboSubg.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 87)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Subgrupo:"
        Me.Label6.Visible = False
        '
        'cboGrupo
        '
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Location = New System.Drawing.Point(62, 62)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(157, 21)
        Me.cboGrupo.TabIndex = 24
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Grupo:"
        '
        'cboClase
        '
        Me.cboClase.FormattingEnabled = True
        Me.cboClase.Location = New System.Drawing.Point(62, 40)
        Me.cboClase.Name = "cboClase"
        Me.cboClase.Size = New System.Drawing.Size(157, 21)
        Me.cboClase.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Clase:"
        '
        'cboCategoria
        '
        Me.cboCategoria.FormattingEnabled = True
        Me.cboCategoria.Location = New System.Drawing.Point(62, 18)
        Me.cboCategoria.Name = "cboCategoria"
        Me.cboCategoria.Size = New System.Drawing.Size(157, 21)
        Me.cboCategoria.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Categoria:"
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(670, 526)
        Me.ReportViewer1.TabIndex = 1
        '
        'cboBodega
        '
        Me.cboBodega.FormattingEnabled = True
        Me.cboBodega.Location = New System.Drawing.Point(474, 11)
        Me.cboBodega.Name = "cboBodega"
        Me.cboBodega.Size = New System.Drawing.Size(163, 21)
        Me.cboBodega.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(424, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Bodega:"
        '
        'chkOrden
        '
        Me.chkOrden.AutoSize = True
        Me.chkOrden.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkOrden.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkOrden.Location = New System.Drawing.Point(16, 48)
        Me.chkOrden.Name = "chkOrden"
        Me.chkOrden.Size = New System.Drawing.Size(142, 17)
        Me.chkOrden.TabIndex = 50
        Me.chkOrden.Text = "Ordenar alfabeticamente"
        Me.chkOrden.UseVisualStyleBackColor = True
        '
        'repInvTransInv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(974, 564)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.cboBodega)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "repInvTransInv"
        Me.Text = "LISTA DE TRANSACCIONES DE INVENTARIO"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ArticulosGrupos.ResumeLayout(False)
        Me.ArticulosGrupos.PerformLayout()
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
    Friend WithEvents ArticulosGrupos As System.Windows.Forms.GroupBox
    Friend WithEvents cboSubg As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboClase As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDocumentos As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents CboSoporte As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Ordenarporsoporte As System.Windows.Forms.RadioButton
    Friend WithEvents Ordenarporprincipal As System.Windows.Forms.RadioButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtcodDir As System.Windows.Forms.TextBox
    Friend WithEvents TotalDoc As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents txtFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkGrupo As System.Windows.Forms.CheckBox
    Friend WithEvents chkClase As System.Windows.Forms.CheckBox
    Friend WithEvents chkCategoria As System.Windows.Forms.CheckBox
    Friend WithEvents chkSubg As System.Windows.Forms.CheckBox
    Friend WithEvents chkPorDocumento As System.Windows.Forms.RadioButton
    Friend WithEvents chkPorArticulo As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCodFin As System.Windows.Forms.Button
    Friend WithEvents txtCodFin As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnCodIni As System.Windows.Forms.Button
    Friend WithEvents txtcodIni As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkOrden As System.Windows.Forms.CheckBox

End Class
