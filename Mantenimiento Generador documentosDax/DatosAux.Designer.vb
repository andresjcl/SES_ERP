<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DatosAux
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DatosAux))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btnAbrir = New System.Windows.Forms.ToolStripButton()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btnEliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAbreviación = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboTipoDato = New System.Windows.Forms.ComboBox()
        Me.txtLongitud = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDecimales = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ClasContable = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ClasSimple = New System.Windows.Forms.CheckBox()
        Me.txtCampoAsignado = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtUltNum = New System.Windows.Forms.TextBox()
        Me.txtUltFec = New System.Windows.Forms.TextBox()
        Me.txtUltLog = New System.Windows.Forms.TextBox()
        Me.txtUltVar = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.optProduccion = New System.Windows.Forms.RadioButton()
        Me.optServicios = New System.Windows.Forms.RadioButton()
        Me.optArticulos = New System.Windows.Forms.RadioButton()
        Me.optManual = New System.Windows.Forms.RadioButton()
        Me.optSyscod = New System.Windows.Forms.RadioButton()
        Me.optDirectorio = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboClaseCampo = New System.Windows.Forms.ComboBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNuevo, Me.btnAbrir, Me.btnCancelar, Me.btnGuardar, Me.btnEliminar, Me.ToolStripSeparator1, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(737, 38)
        Me.ToolStrip1.TabIndex = 1
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
        'btnCancelar
        '
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(57, 35)
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(53, 35)
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(54, 35)
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 38)
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(11, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Nombre:"
        '
        'txtAbreviación
        '
        Me.txtAbreviación.BackColor = System.Drawing.Color.AliceBlue
        Me.txtAbreviación.Location = New System.Drawing.Point(12, 33)
        Me.txtAbreviación.Name = "txtAbreviación"
        Me.txtAbreviación.Size = New System.Drawing.Size(135, 20)
        Me.txtAbreviación.TabIndex = 3
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDescripcion.Location = New System.Drawing.Point(151, 33)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(319, 20)
        Me.txtDescripcion.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(148, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Detalle"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(13, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Tipo de Dato:"
        '
        'cboTipoDato
        '
        Me.cboTipoDato.BackColor = System.Drawing.Color.AliceBlue
        Me.cboTipoDato.FormattingEnabled = True
        Me.cboTipoDato.Items.AddRange(New Object() {"Alfanumérico", "Numérico Entero", "Numérico Decimal", "Datetime", "Boolean"})
        Me.cboTipoDato.Location = New System.Drawing.Point(14, 81)
        Me.cboTipoDato.Name = "cboTipoDato"
        Me.cboTipoDato.Size = New System.Drawing.Size(135, 21)
        Me.cboTipoDato.TabIndex = 7
        '
        'txtLongitud
        '
        Me.txtLongitud.BackColor = System.Drawing.Color.AliceBlue
        Me.txtLongitud.Location = New System.Drawing.Point(153, 81)
        Me.txtLongitud.Name = "txtLongitud"
        Me.txtLongitud.Size = New System.Drawing.Size(52, 20)
        Me.txtLongitud.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(154, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Longitud:"
        '
        'txtDecimales
        '
        Me.txtDecimales.BackColor = System.Drawing.Color.AliceBlue
        Me.txtDecimales.Location = New System.Drawing.Point(211, 81)
        Me.txtDecimales.Name = "txtDecimales"
        Me.txtDecimales.Size = New System.Drawing.Size(50, 20)
        Me.txtDecimales.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(208, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Decimales:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(11, 210)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Campo Asignado:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.txtCampoAsignado)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cboClaseCampo)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtDecimales)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtLongitud)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cboTipoDato)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtDescripcion)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtAbreviación)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(1, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(736, 244)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Definición Del Campo:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ClasContable)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.ComboBox1)
        Me.GroupBox4.Controls.Add(Me.ClasSimple)
        Me.GroupBox4.Location = New System.Drawing.Point(486, 19)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(233, 175)
        Me.GroupBox4.TabIndex = 26
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Función clasificador"
        '
        'ClasContable
        '
        Me.ClasContable.AutoSize = True
        Me.ClasContable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClasContable.Location = New System.Drawing.Point(25, 19)
        Me.ClasContable.Name = "ClasContable"
        Me.ClasContable.Size = New System.Drawing.Size(68, 17)
        Me.ClasContable.TabIndex = 31
        Me.ClasContable.Text = "Contable"
        Me.ClasContable.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(59, 71)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(92, 13)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "Clasificador Padre"
        '
        'ComboBox1
        '
        Me.ComboBox1.BackColor = System.Drawing.Color.AliceBlue
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Añadir campo por Documento", "Añadir campo por Item"})
        Me.ComboBox1.Location = New System.Drawing.Point(25, 87)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(163, 21)
        Me.ComboBox1.TabIndex = 29
        '
        'ClasSimple
        '
        Me.ClasSimple.AutoSize = True
        Me.ClasSimple.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClasSimple.Location = New System.Drawing.Point(25, 41)
        Me.ClasSimple.Name = "ClasSimple"
        Me.ClasSimple.Size = New System.Drawing.Size(57, 17)
        Me.ClasSimple.TabIndex = 28
        Me.ClasSimple.Text = "Simple"
        Me.ClasSimple.UseVisualStyleBackColor = True
        Me.ClasSimple.Visible = False
        '
        'txtCampoAsignado
        '
        Me.txtCampoAsignado.Location = New System.Drawing.Point(109, 200)
        Me.txtCampoAsignado.Name = "txtCampoAsignado"
        Me.txtCampoAsignado.Size = New System.Drawing.Size(152, 20)
        Me.txtCampoAsignado.TabIndex = 25
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtUltNum)
        Me.GroupBox2.Controls.Add(Me.txtUltFec)
        Me.GroupBox2.Controls.Add(Me.txtUltLog)
        Me.GroupBox2.Controls.Add(Me.txtUltVar)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 226)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(660, 18)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Últimos Campos Asignados:"
        Me.GroupBox2.Visible = False
        '
        'txtUltNum
        '
        Me.txtUltNum.Location = New System.Drawing.Point(483, 24)
        Me.txtUltNum.Name = "txtUltNum"
        Me.txtUltNum.Size = New System.Drawing.Size(41, 20)
        Me.txtUltNum.TabIndex = 10
        '
        'txtUltFec
        '
        Me.txtUltFec.Location = New System.Drawing.Point(337, 24)
        Me.txtUltFec.Name = "txtUltFec"
        Me.txtUltFec.Size = New System.Drawing.Size(41, 20)
        Me.txtUltFec.TabIndex = 9
        '
        'txtUltLog
        '
        Me.txtUltLog.Location = New System.Drawing.Point(200, 24)
        Me.txtUltLog.Name = "txtUltLog"
        Me.txtUltLog.Size = New System.Drawing.Size(41, 20)
        Me.txtUltLog.TabIndex = 8
        '
        'txtUltVar
        '
        Me.txtUltVar.Location = New System.Drawing.Point(69, 24)
        Me.txtUltVar.Name = "txtUltVar"
        Me.txtUltVar.Size = New System.Drawing.Size(41, 20)
        Me.txtUltVar.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(422, 32)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 13)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Numérico:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(291, 31)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Fecha:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(152, 31)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Lógico:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(26, 31)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Texto:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ComboBox2)
        Me.GroupBox3.Controls.Add(Me.optProduccion)
        Me.GroupBox3.Controls.Add(Me.optServicios)
        Me.GroupBox3.Controls.Add(Me.optArticulos)
        Me.GroupBox3.Controls.Add(Me.optManual)
        Me.GroupBox3.Controls.Add(Me.optSyscod)
        Me.GroupBox3.Controls.Add(Me.optDirectorio)
        Me.GroupBox3.Location = New System.Drawing.Point(11, 117)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(466, 77)
        Me.GroupBox3.TabIndex = 22
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Origen del dato:"
        '
        'optProduccion
        '
        Me.optProduccion.AutoSize = True
        Me.optProduccion.ForeColor = System.Drawing.Color.Black
        Me.optProduccion.Location = New System.Drawing.Point(184, 42)
        Me.optProduccion.Name = "optProduccion"
        Me.optProduccion.Size = New System.Drawing.Size(79, 17)
        Me.optProduccion.TabIndex = 25
        Me.optProduccion.Text = "Producción"
        Me.optProduccion.UseVisualStyleBackColor = True
        '
        'optServicios
        '
        Me.optServicios.AutoSize = True
        Me.optServicios.ForeColor = System.Drawing.Color.Black
        Me.optServicios.Location = New System.Drawing.Point(92, 42)
        Me.optServicios.Name = "optServicios"
        Me.optServicios.Size = New System.Drawing.Size(76, 17)
        Me.optServicios.TabIndex = 24
        Me.optServicios.Text = "Conceptos"
        Me.optServicios.UseVisualStyleBackColor = True
        '
        'optArticulos
        '
        Me.optArticulos.AutoSize = True
        Me.optArticulos.ForeColor = System.Drawing.Color.Black
        Me.optArticulos.Location = New System.Drawing.Point(9, 42)
        Me.optArticulos.Name = "optArticulos"
        Me.optArticulos.Size = New System.Drawing.Size(67, 17)
        Me.optArticulos.TabIndex = 23
        Me.optArticulos.Text = "Artículos"
        Me.optArticulos.UseVisualStyleBackColor = True
        '
        'optManual
        '
        Me.optManual.AutoSize = True
        Me.optManual.ForeColor = System.Drawing.Color.Black
        Me.optManual.Location = New System.Drawing.Point(8, 19)
        Me.optManual.Name = "optManual"
        Me.optManual.Size = New System.Drawing.Size(98, 17)
        Me.optManual.TabIndex = 22
        Me.optManual.Text = "Ingreso Manual"
        Me.optManual.UseVisualStyleBackColor = True
        '
        'optSyscod
        '
        Me.optSyscod.AutoSize = True
        Me.optSyscod.ForeColor = System.Drawing.Color.Black
        Me.optSyscod.Location = New System.Drawing.Point(149, 20)
        Me.optSyscod.Name = "optSyscod"
        Me.optSyscod.Size = New System.Drawing.Size(114, 17)
        Me.optSyscod.TabIndex = 21
        Me.optSyscod.Text = "Códigos Generales"
        Me.optSyscod.UseVisualStyleBackColor = True
        '
        'optDirectorio
        '
        Me.optDirectorio.AutoSize = True
        Me.optDirectorio.Checked = True
        Me.optDirectorio.ForeColor = System.Drawing.Color.Black
        Me.optDirectorio.Location = New System.Drawing.Point(326, 19)
        Me.optDirectorio.Name = "optDirectorio"
        Me.optDirectorio.Size = New System.Drawing.Size(110, 17)
        Me.optDirectorio.TabIndex = 20
        Me.optDirectorio.TabStop = True
        Me.optDirectorio.Text = "Directorio General"
        Me.optDirectorio.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(281, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(149, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Registrar en el documento en:"
        '
        'cboClaseCampo
        '
        Me.cboClaseCampo.BackColor = System.Drawing.Color.AliceBlue
        Me.cboClaseCampo.FormattingEnabled = True
        Me.cboClaseCampo.Items.AddRange(New Object() {"Añadir campo por Documento", "Añadir campo por Item"})
        Me.cboClaseCampo.Location = New System.Drawing.Point(267, 80)
        Me.cboClaseCampo.Name = "cboClaseCampo"
        Me.cboClaseCampo.Size = New System.Drawing.Size(184, 21)
        Me.cboClaseCampo.TabIndex = 20
        '
        'ComboBox2
        '
        Me.ComboBox2.BackColor = System.Drawing.Color.AliceBlue
        Me.ComboBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"Cliente", "Empleado", "Financiero", "Proveedor", "Vendedor"})
        Me.ComboBox2.Location = New System.Drawing.Point(321, 36)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(115, 21)
        Me.ComboBox2.TabIndex = 30
        '
        'DatosAux
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(737, 297)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DatosAux"
        Me.Text = "Definicion de datos adicionales"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnAbrir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAbreviación As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboTipoDato As System.Windows.Forms.ComboBox
    Friend WithEvents txtLongitud As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDecimales As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboClaseCampo As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtUltNum As System.Windows.Forms.TextBox
    Friend WithEvents txtUltFec As System.Windows.Forms.TextBox
    Friend WithEvents txtUltLog As System.Windows.Forms.TextBox
    Friend WithEvents txtUltVar As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCampoAsignado As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents optProduccion As System.Windows.Forms.RadioButton
    Friend WithEvents optServicios As System.Windows.Forms.RadioButton
    Friend WithEvents optArticulos As System.Windows.Forms.RadioButton
    Friend WithEvents optManual As System.Windows.Forms.RadioButton
    Friend WithEvents optSyscod As System.Windows.Forms.RadioButton
    Friend WithEvents optDirectorio As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents ClasContable As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents ClasSimple As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
End Class
