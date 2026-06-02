<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPago
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPago))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnNuevo = New System.Windows.Forms.ToolStripButton()
        Me.btnAbrir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btnEliminar = New System.Windows.Forms.ToolStripButton()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAbreviacion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optRolPag = New System.Windows.Forms.RadioButton()
        Me.optGarFecha = New System.Windows.Forms.RadioButton()
        Me.optCruceDoc = New System.Windows.Forms.RadioButton()
        Me.optPlanCuotas = New System.Windows.Forms.RadioButton()
        Me.optCheque = New System.Windows.Forms.RadioButton()
        Me.optTarjeta = New System.Windows.Forms.RadioButton()
        Me.optEfectivo = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtNumCuotas = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.optVariable = New System.Windows.Forms.RadioButton()
        Me.optPlazoFijo = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkGenerarIngreso = New System.Windows.Forms.CheckBox()
        Me.optCredito = New System.Windows.Forms.RadioButton()
        Me.optContado = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtIdCont1 = New System.Windows.Forms.TextBox()
        Me.txtIdCont2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnIdc1 = New System.Windows.Forms.Button()
        Me.btnIdc2 = New System.Windows.Forms.Button()
        Me.lblCuenta1 = New System.Windows.Forms.Label()
        Me.lblCuenta2 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtDiasCuotasfijas = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtCuo12 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtCuo11 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtCuo10 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtCuo9 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCuo8 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtCuo7 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtCuo6 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCuo5 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCuo4 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCuo3 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCuo2 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCuo1 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TxtContadoSRI = New System.Windows.Forms.CheckBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.chkSujetoARetencion = New System.Windows.Forms.CheckBox()
        Me.chkDobleTributacion = New System.Windows.Forms.CheckBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cmbSriPais = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cmbSriFormaDePago = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbSriTipoDePago = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnNuevo, Me.btnAbrir, Me.ToolStripSeparator1, Me.btnGuardar, Me.btnEliminar, Me.btnCancelar, Me.ToolStripSeparator2, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1239, 42)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtnNuevo
        '
        Me.BtnNuevo.ForeColor = System.Drawing.Color.White
        Me.BtnNuevo.Image = CType(resources.GetObject("BtnNuevo.Image"), System.Drawing.Image)
        Me.BtnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(46, 39)
        Me.BtnNuevo.Text = "Nuevo"
        Me.BtnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnAbrir
        '
        Me.btnAbrir.ForeColor = System.Drawing.Color.White
        Me.btnAbrir.Image = CType(resources.GetObject("btnAbrir.Image"), System.Drawing.Image)
        Me.btnAbrir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.Size = New System.Drawing.Size(37, 39)
        Me.btnAbrir.Text = "Abrir"
        Me.btnAbrir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 42)
        '
        'btnGuardar
        '
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(53, 39)
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnEliminar
        '
        Me.btnEliminar.ForeColor = System.Drawing.Color.White
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(54, 39)
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.White
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(57, 39)
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 42)
        '
        'btnSalir
        '
        Me.btnSalir.ForeColor = System.Drawing.Color.White
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(33, 39)
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 61)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Abreviación:"
        '
        'txtAbreviacion
        '
        Me.txtAbreviacion.Location = New System.Drawing.Point(95, 58)
        Me.txtAbreviacion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtAbreviacion.MaxLength = 3
        Me.txtAbreviacion.Name = "txtAbreviacion"
        Me.txtAbreviacion.Size = New System.Drawing.Size(67, 22)
        Me.txtAbreviacion.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(173, 61)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Descripción:"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(269, 58)
        Me.txtDescripcion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(493, 22)
        Me.txtDescripcion.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optRolPag)
        Me.GroupBox1.Controls.Add(Me.optGarFecha)
        Me.GroupBox1.Controls.Add(Me.optCruceDoc)
        Me.GroupBox1.Controls.Add(Me.optPlanCuotas)
        Me.GroupBox1.Controls.Add(Me.optCheque)
        Me.GroupBox1.Controls.Add(Me.optTarjeta)
        Me.GroupBox1.Controls.Add(Me.optEfectivo)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(8, 84)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(535, 97)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo"
        '
        'optRolPag
        '
        Me.optRolPag.AutoSize = True
        Me.optRolPag.ForeColor = System.Drawing.Color.White
        Me.optRolPag.Location = New System.Drawing.Point(392, 62)
        Me.optRolPag.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.optRolPag.Name = "optRolPag"
        Me.optRolPag.Size = New System.Drawing.Size(108, 20)
        Me.optRolPag.TabIndex = 6
        Me.optRolPag.Text = "Rol de pagos"
        Me.ToolTip1.SetToolTip(Me.optRolPag, "Para ventas a empleados ue deberán ser descontadas en rol de pagos")
        Me.optRolPag.UseVisualStyleBackColor = True
        '
        'optGarFecha
        '
        Me.optGarFecha.AutoSize = True
        Me.optGarFecha.ForeColor = System.Drawing.Color.White
        Me.optGarFecha.Location = New System.Drawing.Point(207, 62)
        Me.optGarFecha.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.optGarFecha.Name = "optGarFecha"
        Me.optGarFecha.Size = New System.Drawing.Size(124, 20)
        Me.optGarFecha.TabIndex = 5
        Me.optGarFecha.Text = "Garantía a fecha"
        Me.ToolTip1.SetToolTip(Me.optGarFecha, "Pago con documentos que se vencen a una fecha dada (cheques postfechados)")
        Me.optGarFecha.UseVisualStyleBackColor = True
        '
        'optCruceDoc
        '
        Me.optCruceDoc.AutoSize = True
        Me.optCruceDoc.ForeColor = System.Drawing.Color.White
        Me.optCruceDoc.Location = New System.Drawing.Point(8, 62)
        Me.optCruceDoc.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.optCruceDoc.Name = "optCruceDoc"
        Me.optCruceDoc.Size = New System.Drawing.Size(133, 20)
        Me.optCruceDoc.TabIndex = 4
        Me.optCruceDoc.Text = "Cruce Documento"
        Me.ToolTip1.SetToolTip(Me.optCruceDoc, "Pagos que se cruzan con anticipos, facturas, notas de crédito u otros documentos")
        Me.optCruceDoc.UseVisualStyleBackColor = True
        '
        'optPlanCuotas
        '
        Me.optPlanCuotas.AutoSize = True
        Me.optPlanCuotas.ForeColor = System.Drawing.Color.White
        Me.optPlanCuotas.Location = New System.Drawing.Point(392, 23)
        Me.optPlanCuotas.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.optPlanCuotas.Name = "optPlanCuotas"
        Me.optPlanCuotas.Size = New System.Drawing.Size(96, 20)
        Me.optPlanCuotas.TabIndex = 3
        Me.optPlanCuotas.Text = "Plan cuotas"
        Me.ToolTip1.SetToolTip(Me.optPlanCuotas, "1 o varios pagos a plazos en dias determinados")
        Me.optPlanCuotas.UseVisualStyleBackColor = True
        '
        'optCheque
        '
        Me.optCheque.AutoSize = True
        Me.optCheque.ForeColor = System.Drawing.Color.White
        Me.optCheque.Location = New System.Drawing.Point(265, 23)
        Me.optCheque.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.optCheque.Name = "optCheque"
        Me.optCheque.Size = New System.Drawing.Size(73, 20)
        Me.optCheque.TabIndex = 2
        Me.optCheque.Text = "Cheque"
        Me.ToolTip1.SetToolTip(Me.optCheque, "Pagos con cheques a la fecha")
        Me.optCheque.UseVisualStyleBackColor = True
        '
        'optTarjeta
        '
        Me.optTarjeta.AutoSize = True
        Me.optTarjeta.ForeColor = System.Drawing.Color.White
        Me.optTarjeta.Location = New System.Drawing.Point(132, 23)
        Me.optTarjeta.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.optTarjeta.Name = "optTarjeta"
        Me.optTarjeta.Size = New System.Drawing.Size(69, 20)
        Me.optTarjeta.TabIndex = 1
        Me.optTarjeta.Text = "Tarjeta"
        Me.ToolTip1.SetToolTip(Me.optTarjeta, "Para pagos con tarjetas de crédito")
        Me.optTarjeta.UseVisualStyleBackColor = True
        '
        'optEfectivo
        '
        Me.optEfectivo.AutoSize = True
        Me.optEfectivo.Checked = True
        Me.optEfectivo.ForeColor = System.Drawing.Color.White
        Me.optEfectivo.Location = New System.Drawing.Point(8, 23)
        Me.optEfectivo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.optEfectivo.Name = "optEfectivo"
        Me.optEfectivo.Size = New System.Drawing.Size(74, 20)
        Me.optEfectivo.TabIndex = 0
        Me.optEfectivo.TabStop = True
        Me.optEfectivo.Text = "Efectivo"
        Me.ToolTip1.SetToolTip(Me.optEfectivo, "Pago estrictamente de contado, la factura queda cancelada")
        Me.optEfectivo.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtNumCuotas)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.optVariable)
        Me.GroupBox2.Controls.Add(Me.optPlazoFijo)
        Me.GroupBox2.Location = New System.Drawing.Point(551, 84)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(283, 97)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Visible = False
        '
        'txtNumCuotas
        '
        Me.txtNumCuotas.Location = New System.Drawing.Point(148, 58)
        Me.txtNumCuotas.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNumCuotas.Name = "txtNumCuotas"
        Me.txtNumCuotas.Size = New System.Drawing.Size(83, 22)
        Me.txtNumCuotas.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.txtNumCuotas, "En cuantas cuotas de divide el pago")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(24, 65)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Número cuotas:"
        '
        'optVariable
        '
        Me.optVariable.AutoSize = True
        Me.optVariable.ForeColor = System.Drawing.Color.White
        Me.optVariable.Location = New System.Drawing.Point(148, 23)
        Me.optVariable.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.optVariable.Name = "optVariable"
        Me.optVariable.Size = New System.Drawing.Size(77, 20)
        Me.optVariable.TabIndex = 1
        Me.optVariable.Text = "Variable"
        Me.ToolTip1.SetToolTip(Me.optVariable, "Los dias entre cuotas de pago pueden variar")
        Me.optVariable.UseVisualStyleBackColor = True
        '
        'optPlazoFijo
        '
        Me.optPlazoFijo.AutoSize = True
        Me.optPlazoFijo.ForeColor = System.Drawing.Color.White
        Me.optPlazoFijo.Location = New System.Drawing.Point(19, 23)
        Me.optPlazoFijo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.optPlazoFijo.Name = "optPlazoFijo"
        Me.optPlazoFijo.Size = New System.Drawing.Size(80, 20)
        Me.optPlazoFijo.TabIndex = 0
        Me.optPlazoFijo.Text = "Plazo fijo"
        Me.ToolTip1.SetToolTip(Me.optPlazoFijo, "Los dias entre cuotas de pago son fijos")
        Me.optPlazoFijo.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkGenerarIngreso)
        Me.GroupBox3.Controls.Add(Me.optCredito)
        Me.GroupBox3.Controls.Add(Me.optContado)
        Me.GroupBox3.Location = New System.Drawing.Point(4, 190)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(535, 87)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Forma que afecta a la factura"
        '
        'chkGenerarIngreso
        '
        Me.chkGenerarIngreso.AutoSize = True
        Me.chkGenerarIngreso.ForeColor = System.Drawing.Color.White
        Me.chkGenerarIngreso.Location = New System.Drawing.Point(303, 23)
        Me.chkGenerarIngreso.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkGenerarIngreso.Name = "chkGenerarIngreso"
        Me.chkGenerarIngreso.Size = New System.Drawing.Size(183, 20)
        Me.chkGenerarIngreso.TabIndex = 2
        Me.chkGenerarIngreso.Text = "Generar ingreso a bancos"
        Me.chkGenerarIngreso.UseVisualStyleBackColor = True
        '
        'optCredito
        '
        Me.optCredito.AutoSize = True
        Me.optCredito.ForeColor = System.Drawing.Color.White
        Me.optCredito.Location = New System.Drawing.Point(13, 53)
        Me.optCredito.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.optCredito.Name = "optCredito"
        Me.optCredito.Size = New System.Drawing.Size(298, 20)
        Me.optCredito.TabIndex = 1
        Me.optCredito.Text = "Credito   (La factura queda con saldo a pagar)"
        Me.ToolTip1.SetToolTip(Me.optCredito, "La factura queda por pagarse ")
        Me.optCredito.UseVisualStyleBackColor = True
        '
        'optContado
        '
        Me.optContado.AutoSize = True
        Me.optContado.Checked = True
        Me.optContado.ForeColor = System.Drawing.Color.White
        Me.optContado.Location = New System.Drawing.Point(12, 23)
        Me.optContado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.optContado.Name = "optContado"
        Me.optContado.Size = New System.Drawing.Size(232, 20)
        Me.optContado.TabIndex = 0
        Me.optContado.TabStop = True
        Me.optContado.Text = "Contado   (Abono directo a factura)"
        Me.ToolTip1.SetToolTip(Me.optContado, "El pago cancela la factura inmediatamente")
        Me.optContado.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(5, 303)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Id_Contable_1:"
        '
        'txtIdCont1
        '
        Me.txtIdCont1.Location = New System.Drawing.Point(115, 299)
        Me.txtIdCont1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtIdCont1.Name = "txtIdCont1"
        Me.txtIdCont1.Size = New System.Drawing.Size(144, 22)
        Me.txtIdCont1.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.txtIdCont1, "Primera cuenta contable o identificativo contable que se toma como Comodin para l" &
        "a contabilización ")
        '
        'txtIdCont2
        '
        Me.txtIdCont2.Location = New System.Drawing.Point(115, 343)
        Me.txtIdCont2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtIdCont2.Name = "txtIdCont2"
        Me.txtIdCont2.Size = New System.Drawing.Size(144, 22)
        Me.txtIdCont2.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.txtIdCont2, "Segunda cuenta contable o identificativo contable que se toma como Comodin para l" &
        "a contabilización ")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(5, 347)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 16)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Id_Contable_2:"
        '
        'btnIdc1
        '
        Me.btnIdc1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnIdc1.FlatAppearance.BorderSize = 0
        Me.btnIdc1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIdc1.ForeColor = System.Drawing.Color.White
        Me.btnIdc1.Location = New System.Drawing.Point(259, 299)
        Me.btnIdc1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnIdc1.Name = "btnIdc1"
        Me.btnIdc1.Size = New System.Drawing.Size(24, 25)
        Me.btnIdc1.TabIndex = 12
        Me.btnIdc1.Text = "..."
        Me.btnIdc1.UseVisualStyleBackColor = False
        '
        'btnIdc2
        '
        Me.btnIdc2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnIdc2.FlatAppearance.BorderSize = 0
        Me.btnIdc2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIdc2.ForeColor = System.Drawing.Color.White
        Me.btnIdc2.Location = New System.Drawing.Point(259, 342)
        Me.btnIdc2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnIdc2.Name = "btnIdc2"
        Me.btnIdc2.Size = New System.Drawing.Size(24, 25)
        Me.btnIdc2.TabIndex = 13
        Me.btnIdc2.Text = "..."
        Me.btnIdc2.UseVisualStyleBackColor = False
        '
        'lblCuenta1
        '
        Me.lblCuenta1.BackColor = System.Drawing.Color.White
        Me.lblCuenta1.Location = New System.Drawing.Point(292, 300)
        Me.lblCuenta1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCuenta1.Name = "lblCuenta1"
        Me.lblCuenta1.Size = New System.Drawing.Size(251, 25)
        Me.lblCuenta1.TabIndex = 14
        '
        'lblCuenta2
        '
        Me.lblCuenta2.BackColor = System.Drawing.Color.White
        Me.lblCuenta2.Location = New System.Drawing.Point(288, 345)
        Me.lblCuenta2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCuenta2.Name = "lblCuenta2"
        Me.lblCuenta2.Size = New System.Drawing.Size(255, 25)
        Me.lblCuenta2.TabIndex = 15
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtDiasCuotasfijas)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Location = New System.Drawing.Point(547, 194)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox4.Size = New System.Drawing.Size(283, 53)
        Me.GroupBox4.TabIndex = 16
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Visible = False
        '
        'txtDiasCuotasfijas
        '
        Me.txtDiasCuotasfijas.Location = New System.Drawing.Point(191, 21)
        Me.txtDiasCuotasfijas.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDiasCuotasfijas.MaxLength = 4
        Me.txtDiasCuotasfijas.Name = "txtDiasCuotasfijas"
        Me.txtDiasCuotasfijas.Size = New System.Drawing.Size(44, 22)
        Me.txtDiasCuotasfijas.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 26)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(173, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Dias plazo para cuotas fijas"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox5)
        Me.Panel1.Location = New System.Drawing.Point(547, 194)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(287, 201)
        Me.Panel1.TabIndex = 17
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtCuo12)
        Me.GroupBox5.Controls.Add(Me.Label18)
        Me.GroupBox5.Controls.Add(Me.txtCuo11)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.txtCuo10)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.txtCuo9)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Controls.Add(Me.txtCuo8)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.txtCuo7)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.txtCuo6)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.txtCuo5)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.txtCuo4)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.txtCuo3)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Controls.Add(Me.txtCuo2)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.txtCuo1)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Location = New System.Drawing.Point(0, -5)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox5.Size = New System.Drawing.Size(283, 202)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Dias plazo para cuotas variable:"
        '
        'txtCuo12
        '
        Me.txtCuo12.Location = New System.Drawing.Point(213, 148)
        Me.txtCuo12.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCuo12.Name = "txtCuo12"
        Me.txtCuo12.Size = New System.Drawing.Size(63, 22)
        Me.txtCuo12.TabIndex = 23
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(191, 153)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(22, 16)
        Me.Label18.TabIndex = 22
        Me.Label18.Text = "12"
        '
        'txtCuo11
        '
        Me.txtCuo11.Location = New System.Drawing.Point(213, 111)
        Me.txtCuo11.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCuo11.Name = "txtCuo11"
        Me.txtCuo11.Size = New System.Drawing.Size(63, 22)
        Me.txtCuo11.TabIndex = 21
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(191, 114)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(22, 16)
        Me.Label17.TabIndex = 20
        Me.Label17.Text = "11"
        '
        'txtCuo10
        '
        Me.txtCuo10.Location = New System.Drawing.Point(213, 74)
        Me.txtCuo10.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCuo10.Name = "txtCuo10"
        Me.txtCuo10.Size = New System.Drawing.Size(63, 22)
        Me.txtCuo10.TabIndex = 19
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(191, 78)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(22, 16)
        Me.Label16.TabIndex = 18
        Me.Label16.Text = "10"
        '
        'txtCuo9
        '
        Me.txtCuo9.Location = New System.Drawing.Point(213, 33)
        Me.txtCuo9.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCuo9.Name = "txtCuo9"
        Me.txtCuo9.Size = New System.Drawing.Size(63, 22)
        Me.txtCuo9.TabIndex = 17
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(191, 37)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(15, 16)
        Me.Label15.TabIndex = 16
        Me.Label15.Text = "9"
        '
        'txtCuo8
        '
        Me.txtCuo8.Location = New System.Drawing.Point(125, 148)
        Me.txtCuo8.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCuo8.Name = "txtCuo8"
        Me.txtCuo8.Size = New System.Drawing.Size(63, 22)
        Me.txtCuo8.TabIndex = 15
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(103, 153)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(15, 16)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "8"
        '
        'txtCuo7
        '
        Me.txtCuo7.Location = New System.Drawing.Point(125, 110)
        Me.txtCuo7.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCuo7.Name = "txtCuo7"
        Me.txtCuo7.Size = New System.Drawing.Size(63, 22)
        Me.txtCuo7.TabIndex = 13
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(103, 113)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(15, 16)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "7"
        '
        'txtCuo6
        '
        Me.txtCuo6.Location = New System.Drawing.Point(125, 70)
        Me.txtCuo6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCuo6.Name = "txtCuo6"
        Me.txtCuo6.Size = New System.Drawing.Size(63, 22)
        Me.txtCuo6.TabIndex = 11
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(103, 74)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(15, 16)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "6"
        '
        'txtCuo5
        '
        Me.txtCuo5.Location = New System.Drawing.Point(125, 33)
        Me.txtCuo5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCuo5.Name = "txtCuo5"
        Me.txtCuo5.Size = New System.Drawing.Size(63, 22)
        Me.txtCuo5.TabIndex = 9
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(103, 37)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(15, 16)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "5"
        '
        'txtCuo4
        '
        Me.txtCuo4.Location = New System.Drawing.Point(32, 148)
        Me.txtCuo4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCuo4.Name = "txtCuo4"
        Me.txtCuo4.Size = New System.Drawing.Size(63, 22)
        Me.txtCuo4.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(9, 153)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(15, 16)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "4"
        '
        'txtCuo3
        '
        Me.txtCuo3.Location = New System.Drawing.Point(32, 107)
        Me.txtCuo3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCuo3.Name = "txtCuo3"
        Me.txtCuo3.Size = New System.Drawing.Size(63, 22)
        Me.txtCuo3.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(9, 111)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(15, 16)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "3"
        '
        'txtCuo2
        '
        Me.txtCuo2.Location = New System.Drawing.Point(32, 70)
        Me.txtCuo2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCuo2.Name = "txtCuo2"
        Me.txtCuo2.Size = New System.Drawing.Size(63, 22)
        Me.txtCuo2.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(9, 74)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(15, 16)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "2"
        '
        'txtCuo1
        '
        Me.txtCuo1.Location = New System.Drawing.Point(32, 33)
        Me.txtCuo1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCuo1.Name = "txtCuo1"
        Me.txtCuo1.Size = New System.Drawing.Size(63, 22)
        Me.txtCuo1.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(9, 37)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(15, 16)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "1"
        '
        'TxtContadoSRI
        '
        Me.TxtContadoSRI.AutoSize = True
        Me.TxtContadoSRI.ForeColor = System.Drawing.Color.White
        Me.TxtContadoSRI.Location = New System.Drawing.Point(16, 265)
        Me.TxtContadoSRI.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtContadoSRI.Name = "TxtContadoSRI"
        Me.TxtContadoSRI.Size = New System.Drawing.Size(295, 20)
        Me.TxtContadoSRI.TabIndex = 18
        Me.TxtContadoSRI.Text = "Registrar como pago al contado (FORM-104)"
        Me.TxtContadoSRI.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.chkSujetoARetencion)
        Me.GroupBox6.Controls.Add(Me.chkDobleTributacion)
        Me.GroupBox6.Controls.Add(Me.Label21)
        Me.GroupBox6.Controls.Add(Me.cmbSriPais)
        Me.GroupBox6.Controls.Add(Me.Label20)
        Me.GroupBox6.Controls.Add(Me.TxtContadoSRI)
        Me.GroupBox6.Controls.Add(Me.cmbSriFormaDePago)
        Me.GroupBox6.Controls.Add(Me.Label19)
        Me.GroupBox6.Controls.Add(Me.cmbSriTipoDePago)
        Me.GroupBox6.Location = New System.Drawing.Point(841, 90)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox6.Size = New System.Drawing.Size(381, 304)
        Me.GroupBox6.TabIndex = 19
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Datos Sri"
        '
        'chkSujetoARetencion
        '
        Me.chkSujetoARetencion.AutoSize = True
        Me.chkSujetoARetencion.ForeColor = System.Drawing.Color.White
        Me.chkSujetoARetencion.Location = New System.Drawing.Point(16, 234)
        Me.chkSujetoARetencion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkSujetoARetencion.Name = "chkSujetoARetencion"
        Me.chkSujetoARetencion.Size = New System.Drawing.Size(134, 20)
        Me.chkSujetoARetencion.TabIndex = 22
        Me.chkSujetoARetencion.Text = "Sujeto a retención"
        Me.chkSujetoARetencion.UseVisualStyleBackColor = True
        '
        'chkDobleTributacion
        '
        Me.chkDobleTributacion.AutoSize = True
        Me.chkDobleTributacion.ForeColor = System.Drawing.Color.White
        Me.chkDobleTributacion.Location = New System.Drawing.Point(16, 203)
        Me.chkDobleTributacion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkDobleTributacion.Name = "chkDobleTributacion"
        Me.chkDobleTributacion.Size = New System.Drawing.Size(230, 20)
        Me.chkDobleTributacion.TabIndex = 21
        Me.chkDobleTributacion.Text = "Con convenio de doble tributación"
        Me.chkDobleTributacion.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(12, 142)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(35, 16)
        Me.Label21.TabIndex = 20
        Me.Label21.Text = "País"
        '
        'cmbSriPais
        '
        Me.cmbSriPais.FormattingEnabled = True
        Me.cmbSriPais.Location = New System.Drawing.Point(12, 159)
        Me.cmbSriPais.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbSriPais.Name = "cmbSriPais"
        Me.cmbSriPais.Size = New System.Drawing.Size(360, 24)
        Me.cmbSriPais.TabIndex = 19
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(5, 85)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(101, 16)
        Me.Label20.TabIndex = 3
        Me.Label20.Text = "Forma de pago"
        '
        'cmbSriFormaDePago
        '
        Me.cmbSriFormaDePago.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbSriFormaDePago.FormattingEnabled = True
        Me.cmbSriFormaDePago.Location = New System.Drawing.Point(12, 102)
        Me.cmbSriFormaDePago.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbSriFormaDePago.Name = "cmbSriFormaDePago"
        Me.cmbSriFormaDePago.Size = New System.Drawing.Size(360, 24)
        Me.cmbSriFormaDePago.TabIndex = 2
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(8, 28)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(90, 16)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "Tipo de pago"
        '
        'cmbSriTipoDePago
        '
        Me.cmbSriTipoDePago.FormattingEnabled = True
        Me.cmbSriTipoDePago.Location = New System.Drawing.Point(8, 46)
        Me.cmbSriTipoDePago.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbSriTipoDePago.Name = "cmbSriTipoDePago"
        Me.cmbSriTipoDePago.Size = New System.Drawing.Size(364, 24)
        Me.cmbSriTipoDePago.TabIndex = 0
        '
        'FormPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(1239, 410)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.lblCuenta2)
        Me.Controls.Add(Me.lblCuenta1)
        Me.Controls.Add(Me.btnIdc2)
        Me.Controls.Add(Me.btnIdc1)
        Me.Controls.Add(Me.txtIdCont2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtIdCont1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtAbreviacion)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPago"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DEFINICION FORMAS DE PAGO"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnAbrir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAbreviacion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optRolPag As System.Windows.Forms.RadioButton
    Friend WithEvents optGarFecha As System.Windows.Forms.RadioButton
    Friend WithEvents optCruceDoc As System.Windows.Forms.RadioButton
    Friend WithEvents optPlanCuotas As System.Windows.Forms.RadioButton
    Friend WithEvents optCheque As System.Windows.Forms.RadioButton
    Friend WithEvents optTarjeta As System.Windows.Forms.RadioButton
    Friend WithEvents optEfectivo As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNumCuotas As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents optVariable As System.Windows.Forms.RadioButton
    Friend WithEvents optPlazoFijo As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkGenerarIngreso As System.Windows.Forms.CheckBox
    Friend WithEvents optCredito As System.Windows.Forms.RadioButton
    Friend WithEvents optContado As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtIdCont1 As System.Windows.Forms.TextBox
    Friend WithEvents txtIdCont2 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnIdc1 As System.Windows.Forms.Button
    Friend WithEvents btnIdc2 As System.Windows.Forms.Button
    Friend WithEvents lblCuenta1 As System.Windows.Forms.Label
    Friend WithEvents lblCuenta2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDiasCuotasfijas As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCuo1 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCuo9 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtCuo8 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtCuo7 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtCuo6 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCuo5 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCuo4 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCuo3 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCuo2 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCuo12 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtCuo11 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtCuo10 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TxtContadoSRI As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmbSriTipoDePago As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cmbSriPais As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cmbSriFormaDePago As System.Windows.Forms.ComboBox
    Friend WithEvents chkSujetoARetencion As System.Windows.Forms.CheckBox
    Friend WithEvents chkDobleTributacion As System.Windows.Forms.CheckBox

End Class
