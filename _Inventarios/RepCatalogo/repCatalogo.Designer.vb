<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class repCatalogo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(repCatalogo))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnOpciones = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Actualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ArticulosGrupos = New System.Windows.Forms.GroupBox()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboClase = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboCategoria = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkUbicacion = New System.Windows.Forms.CheckBox()
        Me.Orden = New System.Windows.Forms.CheckBox()
        Me.chkArtExis = New System.Windows.Forms.CheckBox()
        Me.ValoracionInventario = New System.Windows.Forms.GroupBox()
        Me.optSinCost = New System.Windows.Forms.RadioButton()
        Me.optPvp4 = New System.Windows.Forms.RadioButton()
        Me.optPvp2 = New System.Windows.Forms.RadioButton()
        Me.optUltCost = New System.Windows.Forms.RadioButton()
        Me.optPvp5 = New System.Windows.Forms.RadioButton()
        Me.optPvp3 = New System.Windows.Forms.RadioButton()
        Me.optPvp1 = New System.Windows.Forms.RadioButton()
        Me.optCostoPro = New System.Windows.Forms.RadioButton()
        Me.txtMedidas = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnMed = New System.Windows.Forms.Button()
        Me.txtFecha = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.cboBodega = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkPiezas = New System.Windows.Forms.CheckBox()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ArticulosGrupos.SuspendLayout()
        Me.ValoracionInventario.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOpciones, Me.ToolStripSeparator2, Me.ToolStripSeparator1, Me.Actualizar, Me.ToolStripSeparator4, Me.btnSalir})
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 38)
        '
        'Actualizar
        '
        Me.Actualizar.Checked = True
        Me.Actualizar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Actualizar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Actualizar.Image = CType(resources.GetObject("Actualizar.Image"), System.Drawing.Image)
        Me.Actualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Actualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Actualizar.Name = "Actualizar"
        Me.Actualizar.Size = New System.Drawing.Size(52, 35)
        Me.Actualizar.Text = "Generar"
        Me.Actualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Actualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkPiezas)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ArticulosGrupos)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkUbicacion)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Orden)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkArtExis)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ValoracionInventario)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtMedidas)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnMed)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtFecha)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1MinSize = 20
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ReportViewer1)
        Me.SplitContainer1.Size = New System.Drawing.Size(974, 526)
        Me.SplitContainer1.SplitterDistance = 300
        Me.SplitContainer1.TabIndex = 3
        '
        'ArticulosGrupos
        '
        Me.ArticulosGrupos.Controls.Add(Me.cboGrupo)
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
        Me.ArticulosGrupos.Controls.Add(Me.Label5)
        Me.ArticulosGrupos.Controls.Add(Me.cboClase)
        Me.ArticulosGrupos.Controls.Add(Me.Label4)
        Me.ArticulosGrupos.Controls.Add(Me.cboCategoria)
        Me.ArticulosGrupos.Controls.Add(Me.Label3)
        Me.ArticulosGrupos.Location = New System.Drawing.Point(3, 133)
        Me.ArticulosGrupos.Name = "ArticulosGrupos"
        Me.ArticulosGrupos.Size = New System.Drawing.Size(287, 166)
        Me.ArticulosGrupos.TabIndex = 51
        Me.ArticulosGrupos.TabStop = False
        Me.ArticulosGrupos.Text = "Opciones de selección de artículos"
        '
        'cboGrupo
        '
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Location = New System.Drawing.Point(62, 62)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(157, 21)
        Me.cboGrupo.TabIndex = 24
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
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 87)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Subgrupo:"
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
        'chkUbicacion
        '
        Me.chkUbicacion.AutoSize = True
        Me.chkUbicacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkUbicacion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkUbicacion.Location = New System.Drawing.Point(45, 81)
        Me.chkUbicacion.Name = "chkUbicacion"
        Me.chkUbicacion.Size = New System.Drawing.Size(144, 17)
        Me.chkUbicacion.TabIndex = 50
        Me.chkUbicacion.Text = "Incluir ubicación general:"
        Me.chkUbicacion.UseVisualStyleBackColor = True
        '
        'Orden
        '
        Me.Orden.AutoSize = True
        Me.Orden.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Orden.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Orden.Location = New System.Drawing.Point(47, 64)
        Me.Orden.Name = "Orden"
        Me.Orden.Size = New System.Drawing.Size(142, 17)
        Me.Orden.TabIndex = 49
        Me.Orden.Text = "Ordenar alfabeticamente"
        Me.Orden.UseVisualStyleBackColor = True
        '
        'chkArtExis
        '
        Me.chkArtExis.AutoSize = True
        Me.chkArtExis.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkArtExis.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkArtExis.Location = New System.Drawing.Point(46, 48)
        Me.chkArtExis.Name = "chkArtExis"
        Me.chkArtExis.Size = New System.Drawing.Size(168, 17)
        Me.chkArtExis.TabIndex = 45
        Me.chkArtExis.Text = "Incluir artículos sin Existencia:"
        Me.chkArtExis.UseVisualStyleBackColor = True
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
        Me.ValoracionInventario.Location = New System.Drawing.Point(40, 305)
        Me.ValoracionInventario.Name = "ValoracionInventario"
        Me.ValoracionInventario.Size = New System.Drawing.Size(221, 112)
        Me.ValoracionInventario.TabIndex = 44
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
        'txtMedidas
        '
        Me.txtMedidas.Location = New System.Drawing.Point(101, 457)
        Me.txtMedidas.Name = "txtMedidas"
        Me.txtMedidas.Size = New System.Drawing.Size(125, 20)
        Me.txtMedidas.TabIndex = 47
        Me.txtMedidas.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(52, 460)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 13)
        Me.Label9.TabIndex = 46
        Me.Label9.Text = "Medidas:"
        Me.Label9.Visible = False
        '
        'btnMed
        '
        Me.btnMed.Location = New System.Drawing.Point(226, 457)
        Me.btnMed.Name = "btnMed"
        Me.btnMed.Size = New System.Drawing.Size(21, 21)
        Me.btnMed.TabIndex = 48
        Me.btnMed.Text = "..."
        Me.btnMed.UseVisualStyleBackColor = True
        Me.btnMed.Visible = False
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(74, 6)
        Me.txtFecha.Mask = "00/00/0000"
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(67, 20)
        Me.txtFecha.TabIndex = 4
        Me.txtFecha.ValidatingType = GetType(Date)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "A la Fecha:"
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
        Me.cboBodega.Location = New System.Drawing.Point(457, 11)
        Me.cboBodega.Name = "cboBodega"
        Me.cboBodega.Size = New System.Drawing.Size(163, 21)
        Me.cboBodega.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(407, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Bodega:"
        '
        'chkPiezas
        '
        Me.chkPiezas.AutoSize = True
        Me.chkPiezas.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPiezas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkPiezas.Location = New System.Drawing.Point(44, 98)
        Me.chkPiezas.Name = "chkPiezas"
        Me.chkPiezas.Size = New System.Drawing.Size(145, 17)
        Me.chkPiezas.TabIndex = 52
        Me.chkPiezas.Text = "Incluir columna de piezas"
        Me.chkPiezas.UseVisualStyleBackColor = True
        '
        'repCatalogo
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
        Me.Name = "repCatalogo"
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
        Me.ValoracionInventario.ResumeLayout(False)
        Me.ValoracionInventario.PerformLayout()
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
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents chkUbicacion As System.Windows.Forms.CheckBox
    Friend WithEvents Orden As System.Windows.Forms.CheckBox
    Friend WithEvents chkArtExis As System.Windows.Forms.CheckBox
    Friend WithEvents ValoracionInventario As System.Windows.Forms.GroupBox
    Friend WithEvents optSinCost As System.Windows.Forms.RadioButton
    Friend WithEvents optPvp4 As System.Windows.Forms.RadioButton
    Friend WithEvents optPvp2 As System.Windows.Forms.RadioButton
    Friend WithEvents optUltCost As System.Windows.Forms.RadioButton
    Friend WithEvents optPvp5 As System.Windows.Forms.RadioButton
    Friend WithEvents optPvp3 As System.Windows.Forms.RadioButton
    Friend WithEvents optPvp1 As System.Windows.Forms.RadioButton
    Friend WithEvents optCostoPro As System.Windows.Forms.RadioButton
    Friend WithEvents txtMedidas As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnMed As System.Windows.Forms.Button
    Friend WithEvents ArticulosGrupos As System.Windows.Forms.GroupBox
    Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents btnCodFin As System.Windows.Forms.Button
    Friend WithEvents txtCodFin As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnCodIni As System.Windows.Forms.Button
    Friend WithEvents txtcodIni As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkSubg As System.Windows.Forms.CheckBox
    Friend WithEvents chkGrupo As System.Windows.Forms.CheckBox
    Friend WithEvents chkClase As System.Windows.Forms.CheckBox
    Friend WithEvents chkCategoria As System.Windows.Forms.CheckBox
    Friend WithEvents cboSubg As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboClase As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkPiezas As CheckBox
End Class
