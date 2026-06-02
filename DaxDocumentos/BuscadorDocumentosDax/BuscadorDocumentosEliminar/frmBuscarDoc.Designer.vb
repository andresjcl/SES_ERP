<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarDoc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuscarDoc))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnAceptar = New System.Windows.Forms.ToolStripButton()
        Me.btnBuscar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmbAutorizaciones = New System.Windows.Forms.ToolStripComboBox()
        Me.cmbActivos = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.txtvalor = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDetalle = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtArticuloNombre = New System.Windows.Forms.TextBox()
        Me.btnArticuloCod = New System.Windows.Forms.Button()
        Me.txtArtCodigo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cboPtoVenta = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.txtFechaIn = New System.Windows.Forms.DateTimePicker()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboTipoDoc = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboSucursal = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboBodega = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnServicioCod = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtClienteCod = New System.Windows.Forms.TextBox()
        Me.txtClienteNombre = New System.Windows.Forms.TextBox()
        Me.btnClienteCod = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.malla = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.malla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.35294!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.64706!))
        Me.TableLayoutPanel1.Controls.Add(Me.ToolStrip1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(848, 38)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.btnAceptar, Me.btnBuscar, Me.ToolStripSeparator3, Me.cmbAutorizaciones, Me.cmbActivos, Me.ToolStripSeparator1, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(848, 38)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 38)
        '
        'btnAceptar
        '
        Me.btnAceptar.ForeColor = System.Drawing.Color.White
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(52, 35)
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnBuscar
        '
        Me.btnBuscar.ForeColor = System.Drawing.Color.White
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(46, 35)
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.ForeColor = System.Drawing.Color.White
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 38)
        '
        'cmbAutorizaciones
        '
        Me.cmbAutorizaciones.Items.AddRange(New Object() {"Todos los documentos", "Documentos sin autorización", "Documentos autorizados"})
        Me.cmbAutorizaciones.Name = "cmbAutorizaciones"
        Me.cmbAutorizaciones.Size = New System.Drawing.Size(160, 38)
        '
        'cmbActivos
        '
        Me.cmbActivos.AutoCompleteCustomSource.AddRange(New String() {"Todos los documentos", "Documentos activos", "Documentos anulados"})
        Me.cmbActivos.Items.AddRange(New Object() {"Todos los documentos", "Documentos activos", "Documentos anulados"})
        Me.cmbActivos.Name = "cmbActivos"
        Me.cmbActivos.Size = New System.Drawing.Size(160, 38)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.ForeColor = System.Drawing.Color.White
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 38)
        '
        'btnSalir
        '
        Me.btnSalir.ForeColor = System.Drawing.Color.White
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 35)
        Me.btnSalir.Text = "   Salir   "
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'txtvalor
        '
        Me.txtvalor.Location = New System.Drawing.Point(439, 71)
        Me.txtvalor.Name = "txtvalor"
        Me.txtvalor.Size = New System.Drawing.Size(81, 20)
        Me.txtvalor.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(399, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 13)
        Me.Label9.TabIndex = 57
        Me.Label9.Text = "Valor:"
        '
        'txtDetalle
        '
        Me.txtDetalle.Location = New System.Drawing.Point(54, 71)
        Me.txtDetalle.Multiline = True
        Me.txtDetalle.Name = "txtDetalle"
        Me.txtDetalle.Size = New System.Drawing.Size(341, 19)
        Me.txtDetalle.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "Detalle:"
        '
        'txtArticuloNombre
        '
        Me.txtArticuloNombre.Location = New System.Drawing.Point(243, 51)
        Me.txtArticuloNombre.Name = "txtArticuloNombre"
        Me.txtArticuloNombre.Size = New System.Drawing.Size(277, 20)
        Me.txtArticuloNombre.TabIndex = 7
        '
        'btnArticuloCod
        '
        Me.btnArticuloCod.Image = CType(resources.GetObject("btnArticuloCod.Image"), System.Drawing.Image)
        Me.btnArticuloCod.Location = New System.Drawing.Point(101, 50)
        Me.btnArticuloCod.Name = "btnArticuloCod"
        Me.btnArticuloCod.Size = New System.Drawing.Size(21, 20)
        Me.btnArticuloCod.TabIndex = 43
        Me.btnArticuloCod.UseVisualStyleBackColor = True
        '
        'txtArtCodigo
        '
        Me.txtArtCodigo.Location = New System.Drawing.Point(124, 51)
        Me.txtArtCodigo.Name = "txtArtCodigo"
        Me.txtArtCodigo.Size = New System.Drawing.Size(97, 20)
        Me.txtArtCodigo.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 13)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Articulo/Servicio:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.cboPtoVenta)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtFechaFin)
        Me.Panel1.Controls.Add(Me.txtFechaIn)
        Me.Panel1.Controls.Add(Me.txtNumDoc)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.cboTipoDoc)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.cboSucursal)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.cboBodega)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.btnServicioCod)
        Me.Panel1.Controls.Add(Me.txtvalor)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.btnArticuloCod)
        Me.Panel1.Controls.Add(Me.txtArticuloNombre)
        Me.Panel1.Controls.Add(Me.txtDetalle)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtArtCodigo)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtClienteCod)
        Me.Panel1.Controls.Add(Me.txtClienteNombre)
        Me.Panel1.Controls.Add(Me.btnClienteCod)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(0, 38)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(848, 108)
        Me.Panel1.TabIndex = 5
        '
        'cboPtoVenta
        '
        Me.cboPtoVenta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboPtoVenta.FormattingEnabled = True
        Me.cboPtoVenta.Location = New System.Drawing.Point(699, 85)
        Me.cboPtoVenta.Name = "cboPtoVenta"
        Me.cboPtoVenta.Size = New System.Drawing.Size(143, 21)
        Me.cboPtoVenta.TabIndex = 77
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(642, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 78
        Me.Label2.Text = "PuntoVta:"
        '
        'txtFechaFin
        '
        Me.txtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaFin.Location = New System.Drawing.Point(161, 6)
        Me.txtFechaFin.Name = "txtFechaFin"
        Me.txtFechaFin.Size = New System.Drawing.Size(90, 20)
        Me.txtFechaFin.TabIndex = 76
        '
        'txtFechaIn
        '
        Me.txtFechaIn.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaIn.Location = New System.Drawing.Point(66, 6)
        Me.txtFechaIn.Name = "txtFechaIn"
        Me.txtFechaIn.Size = New System.Drawing.Size(90, 20)
        Me.txtFechaIn.TabIndex = 75
        '
        'txtNumDoc
        '
        Me.txtNumDoc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNumDoc.Location = New System.Drawing.Point(699, 65)
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.Size = New System.Drawing.Size(143, 20)
        Me.txtNumDoc.TabIndex = 74
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(631, 67)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 13)
        Me.Label10.TabIndex = 73
        Me.Label10.Text = "Nro. de lote:"
        '
        'cboTipoDoc
        '
        Me.cboTipoDoc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboTipoDoc.FormattingEnabled = True
        Me.cboTipoDoc.Location = New System.Drawing.Point(699, 2)
        Me.cboTipoDoc.Name = "cboTipoDoc"
        Me.cboTipoDoc.Size = New System.Drawing.Size(143, 21)
        Me.cboTipoDoc.TabIndex = 67
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(627, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 70
        Me.Label6.Text = "Tipo de Doc."
        '
        'cboSucursal
        '
        Me.cboSucursal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSucursal.FormattingEnabled = True
        Me.cboSucursal.Location = New System.Drawing.Point(699, 23)
        Me.cboSucursal.Name = "cboSucursal"
        Me.cboSucursal.Size = New System.Drawing.Size(143, 21)
        Me.cboSucursal.TabIndex = 68
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(642, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 71
        Me.Label7.Text = "Sucursal:"
        '
        'cboBodega
        '
        Me.cboBodega.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboBodega.FormattingEnabled = True
        Me.cboBodega.Location = New System.Drawing.Point(699, 44)
        Me.cboBodega.Name = "cboBodega"
        Me.cboBodega.Size = New System.Drawing.Size(143, 21)
        Me.cboBodega.TabIndex = 69
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(649, 47)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 72
        Me.Label8.Text = "Bodega:"
        '
        'btnServicioCod
        '
        Me.btnServicioCod.Image = CType(resources.GetObject("btnServicioCod.Image"), System.Drawing.Image)
        Me.btnServicioCod.Location = New System.Drawing.Point(221, 51)
        Me.btnServicioCod.Name = "btnServicioCod"
        Me.btnServicioCod.Size = New System.Drawing.Size(21, 20)
        Me.btnServicioCod.TabIndex = 63
        Me.btnServicioCod.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Período :"
        '
        'txtClienteCod
        '
        Me.txtClienteCod.Location = New System.Drawing.Point(124, 31)
        Me.txtClienteCod.Name = "txtClienteCod"
        Me.txtClienteCod.Size = New System.Drawing.Size(97, 20)
        Me.txtClienteCod.TabIndex = 5
        '
        'txtClienteNombre
        '
        Me.txtClienteNombre.Location = New System.Drawing.Point(222, 31)
        Me.txtClienteNombre.Name = "txtClienteNombre"
        Me.txtClienteNombre.Size = New System.Drawing.Size(298, 20)
        Me.txtClienteNombre.TabIndex = 6
        '
        'btnClienteCod
        '
        Me.btnClienteCod.Image = CType(resources.GetObject("btnClienteCod.Image"), System.Drawing.Image)
        Me.btnClienteCod.Location = New System.Drawing.Point(102, 30)
        Me.btnClienteCod.Name = "btnClienteCod"
        Me.btnClienteCod.Size = New System.Drawing.Size(21, 20)
        Me.btnClienteCod.TabIndex = 39
        Me.btnClienteCod.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 13)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Cliente/Proveedor:"
        '
        'malla
        '
        Me.malla.AllowUserToAddRows = False
        Me.malla.AllowUserToDeleteRows = False
        Me.malla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.malla.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.malla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.malla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.malla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.malla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.malla.EnableHeadersVisualStyles = False
        Me.malla.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.malla.Location = New System.Drawing.Point(0, 146)
        Me.malla.Name = "malla"
        Me.malla.ReadOnly = True
        Me.malla.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.malla.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.malla.RowHeadersWidth = 20
        Me.malla.ShowCellToolTips = False
        Me.malla.ShowEditingIcon = False
        Me.malla.Size = New System.Drawing.Size(848, 416)
        Me.malla.TabIndex = 6
        '
        'frmBuscarDoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(848, 562)
        Me.Controls.Add(Me.malla)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBuscarDoc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Documentos"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.malla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAceptar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtDetalle As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtArticuloNombre As System.Windows.Forms.TextBox
    Friend WithEvents btnArticuloCod As System.Windows.Forms.Button
    Friend WithEvents txtArtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtvalor As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtClienteCod As System.Windows.Forms.TextBox
    Friend WithEvents txtClienteNombre As System.Windows.Forms.TextBox
    Friend WithEvents btnClienteCod As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnServicioCod As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents malla As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtFechaIn As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboTipoDoc As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboBodega As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents cmbAutorizaciones As ToolStripComboBox
    Friend WithEvents cmbActivos As ToolStripComboBox
    Friend WithEvents cboPtoVenta As ComboBox
    Friend WithEvents Label2 As Label
End Class
