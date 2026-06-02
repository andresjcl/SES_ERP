<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BuscaClien
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
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.chkAsociacion = New System.Windows.Forms.RadioButton()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.ConInicio = New System.Windows.Forms.CheckBox()
        Me.NombImpresion = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btncancelarbusca = New System.Windows.Forms.Button()
        Me.btnbuscar = New System.Windows.Forms.Button()
        Me.btNuevo = New System.Windows.Forms.Button()
        Me.chkOperador = New System.Windows.Forms.RadioButton()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.chkMedico = New System.Windows.Forms.RadioButton()
        Me.chkTransporte = New System.Windows.Forms.RadioButton()
        Me.chkFinanciera = New System.Windows.Forms.RadioButton()
        Me.chkVendedor = New System.Windows.Forms.RadioButton()
        Me.chkEmpleado = New System.Windows.Forms.RadioButton()
        Me.chkProveedor = New System.Windows.Forms.RadioButton()
        Me.chkCliente = New System.Windows.Forms.RadioButton()
        Me.chkTodos = New System.Windows.Forms.RadioButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ListNombre = New System.Windows.Forms.DataGridView()
        Me.Panel5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.ListNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(512, 75)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 17)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Teléfono"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(615, 71)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(137, 22)
        Me.TextBox2.TabIndex = 13
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(615, 43)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(137, 22)
        Me.TextBox1.TabIndex = 11
        '
        'chkAsociacion
        '
        Me.chkAsociacion.AutoSize = True
        Me.chkAsociacion.ForeColor = System.Drawing.Color.White
        Me.chkAsociacion.Location = New System.Drawing.Point(383, 38)
        Me.chkAsociacion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkAsociacion.Name = "chkAsociacion"
        Me.chkAsociacion.Size = New System.Drawing.Size(97, 21)
        Me.chkAsociacion.TabIndex = 11
        Me.chkAsociacion.Text = "&Asociación"
        Me.chkAsociacion.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.DarkGray
        Me.Panel5.Controls.Add(Me.TxtNombre)
        Me.Panel5.Controls.Add(Me.ConInicio)
        Me.Panel5.Controls.Add(Me.NombImpresion)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 106)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(775, 58)
        Me.Panel5.TabIndex = 19
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(133, 27)
        Me.TxtNombre.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(616, 22)
        Me.TxtNombre.TabIndex = 10
        '
        'ConInicio
        '
        Me.ConInicio.AutoSize = True
        Me.ConInicio.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ConInicio.Location = New System.Drawing.Point(5, 30)
        Me.ConInicio.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ConInicio.Name = "ConInicio"
        Me.ConInicio.Size = New System.Drawing.Size(110, 21)
        Me.ConInicio.TabIndex = 9
        Me.ConInicio.Text = "Buscar inicio"
        Me.ConInicio.UseVisualStyleBackColor = True
        '
        'NombImpresion
        '
        Me.NombImpresion.AutoSize = True
        Me.NombImpresion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.NombImpresion.Location = New System.Drawing.Point(5, 4)
        Me.NombImpresion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.NombImpresion.Name = "NombImpresion"
        Me.NombImpresion.Size = New System.Drawing.Size(230, 21)
        Me.NombImpresion.TabIndex = 8
        Me.NombImpresion.Text = "Visualizar Nombre de Impresión"
        Me.NombImpresion.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(512, 47)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 17)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Ficha Médica"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkGray
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.btncancelarbusca)
        Me.Panel2.Controls.Add(Me.btnbuscar)
        Me.Panel2.Controls.Add(Me.btNuevo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 507)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(775, 53)
        Me.Panel2.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(204, 41)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Señale el cliente y presione F3 para escojer un alias"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label3.Visible = False
        '
        'btncancelarbusca
        '
        Me.btncancelarbusca.BackColor = System.Drawing.Color.DimGray
        Me.btncancelarbusca.ForeColor = System.Drawing.Color.White
        Me.btncancelarbusca.Location = New System.Drawing.Point(615, 12)
        Me.btncancelarbusca.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btncancelarbusca.Name = "btncancelarbusca"
        Me.btncancelarbusca.Size = New System.Drawing.Size(137, 28)
        Me.btncancelarbusca.TabIndex = 2
        Me.btncancelarbusca.Text = "Cancelar"
        Me.btncancelarbusca.UseVisualStyleBackColor = False
        '
        'btnbuscar
        '
        Me.btnbuscar.BackColor = System.Drawing.Color.DimGray
        Me.btnbuscar.ForeColor = System.Drawing.Color.White
        Me.btnbuscar.Location = New System.Drawing.Point(466, 12)
        Me.btnbuscar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnbuscar.Name = "btnbuscar"
        Me.btnbuscar.Size = New System.Drawing.Size(131, 28)
        Me.btnbuscar.TabIndex = 1
        Me.btnbuscar.Text = "Aceptar"
        Me.btnbuscar.UseVisualStyleBackColor = False
        '
        'btNuevo
        '
        Me.btNuevo.BackColor = System.Drawing.Color.DimGray
        Me.btNuevo.ForeColor = System.Drawing.Color.White
        Me.btNuevo.Location = New System.Drawing.Point(248, 12)
        Me.btNuevo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btNuevo.Name = "btNuevo"
        Me.btNuevo.Size = New System.Drawing.Size(123, 28)
        Me.btNuevo.TabIndex = 0
        Me.btNuevo.Text = "&Nuevo eExpress"
        Me.btNuevo.UseVisualStyleBackColor = False
        Me.btNuevo.Visible = False
        '
        'chkOperador
        '
        Me.chkOperador.AutoSize = True
        Me.chkOperador.ForeColor = System.Drawing.Color.White
        Me.chkOperador.Location = New System.Drawing.Point(383, 15)
        Me.chkOperador.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkOperador.Name = "chkOperador"
        Me.chkOperador.Size = New System.Drawing.Size(90, 21)
        Me.chkOperador.TabIndex = 10
        Me.chkOperador.Text = "&Operador"
        Me.chkOperador.UseVisualStyleBackColor = True
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.Color.DimGray
        Me.Frame1.Controls.Add(Me.chkMedico)
        Me.Frame1.Controls.Add(Me.chkTransporte)
        Me.Frame1.Controls.Add(Me.Label2)
        Me.Frame1.Controls.Add(Me.TextBox2)
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.Controls.Add(Me.TextBox1)
        Me.Frame1.Controls.Add(Me.chkAsociacion)
        Me.Frame1.Controls.Add(Me.chkOperador)
        Me.Frame1.Controls.Add(Me.chkFinanciera)
        Me.Frame1.Controls.Add(Me.chkVendedor)
        Me.Frame1.Controls.Add(Me.chkEmpleado)
        Me.Frame1.Controls.Add(Me.chkProveedor)
        Me.Frame1.Controls.Add(Me.chkCliente)
        Me.Frame1.Controls.Add(Me.chkTodos)
        Me.Frame1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Frame1.Location = New System.Drawing.Point(0, 0)
        Me.Frame1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Frame1.Size = New System.Drawing.Size(775, 106)
        Me.Frame1.TabIndex = 3
        Me.Frame1.TabStop = False
        '
        'chkMedico
        '
        Me.chkMedico.AutoSize = True
        Me.chkMedico.ForeColor = System.Drawing.Color.White
        Me.chkMedico.Location = New System.Drawing.Point(516, 15)
        Me.chkMedico.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkMedico.Name = "chkMedico"
        Me.chkMedico.Size = New System.Drawing.Size(74, 21)
        Me.chkMedico.TabIndex = 16
        Me.chkMedico.Text = "&Médico"
        Me.chkMedico.UseVisualStyleBackColor = True
        '
        'chkTransporte
        '
        Me.chkTransporte.AutoSize = True
        Me.chkTransporte.ForeColor = System.Drawing.Color.White
        Me.chkTransporte.Location = New System.Drawing.Point(381, 64)
        Me.chkTransporte.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkTransporte.Name = "chkTransporte"
        Me.chkTransporte.Size = New System.Drawing.Size(99, 21)
        Me.chkTransporte.TabIndex = 15
        Me.chkTransporte.Text = "&Transporte"
        Me.chkTransporte.UseVisualStyleBackColor = True
        '
        'chkFinanciera
        '
        Me.chkFinanciera.AutoSize = True
        Me.chkFinanciera.ForeColor = System.Drawing.Color.White
        Me.chkFinanciera.Location = New System.Drawing.Point(191, 15)
        Me.chkFinanciera.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkFinanciera.Name = "chkFinanciera"
        Me.chkFinanciera.Size = New System.Drawing.Size(95, 21)
        Me.chkFinanciera.TabIndex = 9
        Me.chkFinanciera.Text = "&Financiera"
        Me.chkFinanciera.UseVisualStyleBackColor = True
        '
        'chkVendedor
        '
        Me.chkVendedor.AutoSize = True
        Me.chkVendedor.ForeColor = System.Drawing.Color.White
        Me.chkVendedor.Location = New System.Drawing.Point(191, 62)
        Me.chkVendedor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkVendedor.Name = "chkVendedor"
        Me.chkVendedor.Size = New System.Drawing.Size(91, 21)
        Me.chkVendedor.TabIndex = 8
        Me.chkVendedor.Text = "&Vendedor"
        Me.chkVendedor.UseVisualStyleBackColor = True
        '
        'chkEmpleado
        '
        Me.chkEmpleado.AutoSize = True
        Me.chkEmpleado.ForeColor = System.Drawing.Color.White
        Me.chkEmpleado.Location = New System.Drawing.Point(191, 38)
        Me.chkEmpleado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkEmpleado.Name = "chkEmpleado"
        Me.chkEmpleado.Size = New System.Drawing.Size(92, 21)
        Me.chkEmpleado.TabIndex = 7
        Me.chkEmpleado.Text = "E&mpleado"
        Me.chkEmpleado.UseVisualStyleBackColor = True
        '
        'chkProveedor
        '
        Me.chkProveedor.AutoSize = True
        Me.chkProveedor.ForeColor = System.Drawing.Color.White
        Me.chkProveedor.Location = New System.Drawing.Point(21, 62)
        Me.chkProveedor.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkProveedor.Name = "chkProveedor"
        Me.chkProveedor.Size = New System.Drawing.Size(95, 21)
        Me.chkProveedor.TabIndex = 5
        Me.chkProveedor.Text = "P&roveedor"
        Me.chkProveedor.UseVisualStyleBackColor = True
        '
        'chkCliente
        '
        Me.chkCliente.AutoSize = True
        Me.chkCliente.ForeColor = System.Drawing.Color.White
        Me.chkCliente.Location = New System.Drawing.Point(21, 38)
        Me.chkCliente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkCliente.Name = "chkCliente"
        Me.chkCliente.Size = New System.Drawing.Size(72, 21)
        Me.chkCliente.TabIndex = 4
        Me.chkCliente.Text = "C&liente"
        Me.chkCliente.UseVisualStyleBackColor = True
        '
        'chkTodos
        '
        Me.chkTodos.AutoSize = True
        Me.chkTodos.Checked = True
        Me.chkTodos.ForeColor = System.Drawing.Color.White
        Me.chkTodos.Location = New System.Drawing.Point(21, 15)
        Me.chkTodos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkTodos.Name = "chkTodos"
        Me.chkTodos.Size = New System.Drawing.Size(69, 21)
        Me.chkTodos.TabIndex = 3
        Me.chkTodos.TabStop = True
        Me.chkTodos.Text = "To&dos"
        Me.chkTodos.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel4.Controls.Add(Me.Frame1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(775, 106)
        Me.Panel4.TabIndex = 18
        '
        'ListNombre
        '
        Me.ListNombre.AllowUserToAddRows = False
        Me.ListNombre.AllowUserToDeleteRows = False
        Me.ListNombre.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.ListNombre.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle25.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ListNombre.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle25
        Me.ListNombre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ListNombre.DefaultCellStyle = DataGridViewCellStyle26
        Me.ListNombre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListNombre.EnableHeadersVisualStyles = False
        Me.ListNombre.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ListNombre.Location = New System.Drawing.Point(0, 164)
        Me.ListNombre.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ListNombre.MultiSelect = False
        Me.ListNombre.Name = "ListNombre"
        Me.ListNombre.ReadOnly = True
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ListNombre.RowHeadersDefaultCellStyle = DataGridViewCellStyle27
        Me.ListNombre.RowHeadersVisible = False
        Me.ListNombre.RowHeadersWidth = 21
        DataGridViewCellStyle28.BackColor = System.Drawing.Color.White
        Me.ListNombre.RowsDefaultCellStyle = DataGridViewCellStyle28
        Me.ListNombre.Size = New System.Drawing.Size(775, 343)
        Me.ListNombre.TabIndex = 20
        '
        'BuscaClien
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(775, 560)
        Me.ControlBox = False
        Me.Controls.Add(Me.ListNombre)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "BuscaClien"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BUSCAR CONTACTOS DEL DIRECTORIO"
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.ListNombre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents chkAsociacion As System.Windows.Forms.RadioButton
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents ConInicio As System.Windows.Forms.CheckBox
    Friend WithEvents NombImpresion As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Public WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btncancelarbusca As System.Windows.Forms.Button
    Friend WithEvents btnbuscar As System.Windows.Forms.Button
    Friend WithEvents btNuevo As System.Windows.Forms.Button
    Friend WithEvents chkOperador As System.Windows.Forms.RadioButton
    Friend WithEvents Frame1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkFinanciera As System.Windows.Forms.RadioButton
    Friend WithEvents chkVendedor As System.Windows.Forms.RadioButton
    Friend WithEvents chkEmpleado As System.Windows.Forms.RadioButton
    Friend WithEvents chkProveedor As System.Windows.Forms.RadioButton
    Friend WithEvents chkCliente As System.Windows.Forms.RadioButton
    Friend WithEvents chkTodos As System.Windows.Forms.RadioButton
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents ListNombre As System.Windows.Forms.DataGridView
    Friend WithEvents chkTransporte As System.Windows.Forms.RadioButton
    Friend WithEvents chkMedico As Windows.Forms.RadioButton
End Class
