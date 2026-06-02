<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class AdcAutorizacionesSri
#Region "Código generado por el Diseñador de Windows Forms "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'Llamada necesaria para el Diseñador de Windows Forms.
		InitializeComponent()
	End Sub
	'Form invalida a Dispose para limpiar la lista de componentes.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Requerido por el Diseñador de Windows Forms
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents Command2 As System.Windows.Forms.Button
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents txtcodigo As System.Windows.Forms.TextBox
	Public WithEvents btncliente As System.Windows.Forms.Button
	Public WithEvents txtnom As System.Windows.Forms.TextBox
	Public WithEvents Label13 As System.Windows.Forms.Label
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents btAceptar As System.Windows.Forms.Button
	'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
	'Se puede modificar mediante el Diseñador de Windows Forms.
	'No lo modifique con el editor de código.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdcAutorizacionesSri))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Command2 = New System.Windows.Forms.Button
        Me.Command1 = New System.Windows.Forms.Button
        Me.txtcodigo = New System.Windows.Forms.TextBox
        Me.btncliente = New System.Windows.Forms.Button
        Me.txtnom = New System.Windows.Forms.TextBox
        Me.btAceptar = New System.Windows.Forms.Button
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Malla = New System.Windows.Forms.DataGridView
        Me.Frame2.SuspendLayout()
        CType(Me.Malla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.Color.SteelBlue
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.Color.White
        Me.Command2.Location = New System.Drawing.Point(576, 272)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(55, 25)
        Me.Command2.TabIndex = 7
        Me.Command2.Text = "&Imprimir"
        Me.ToolTip1.SetToolTip(Me.Command2, "Salir dela opción")
        Me.Command2.UseVisualStyleBackColor = False
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.Color.SteelBlue
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.Color.White
        Me.Command1.Location = New System.Drawing.Point(640, 272)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(55, 25)
        Me.Command1.TabIndex = 6
        Me.Command1.Text = "&Salir"
        Me.ToolTip1.SetToolTip(Me.Command1, "Salir dela opción")
        Me.Command1.UseVisualStyleBackColor = False
        '
        'txtcodigo
        '
        Me.txtcodigo.AcceptsReturn = True
        Me.txtcodigo.BackColor = System.Drawing.SystemColors.Window
        Me.txtcodigo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtcodigo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtcodigo.Location = New System.Drawing.Point(56, 24)
        Me.txtcodigo.MaxLength = 15
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtcodigo.Size = New System.Drawing.Size(97, 19)
        Me.txtcodigo.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.txtcodigo, "Ingrese el código del proveedor , F2 Busca el proveedor")
        '
        'btncliente
        '
        Me.btncliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.btncliente.Cursor = System.Windows.Forms.Cursors.Default
        Me.btncliente.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btncliente.Location = New System.Drawing.Point(152, 24)
        Me.btncliente.Name = "btncliente"
        Me.btncliente.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btncliente.Size = New System.Drawing.Size(17, 17)
        Me.btncliente.TabIndex = 3
        Me.btncliente.Text = ".."
        Me.ToolTip1.SetToolTip(Me.btncliente, "Permite buscar los proveedores")
        Me.btncliente.UseVisualStyleBackColor = False
        '
        'txtnom
        '
        Me.txtnom.AcceptsReturn = True
        Me.txtnom.BackColor = System.Drawing.SystemColors.Window
        Me.txtnom.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtnom.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtnom.Location = New System.Drawing.Point(176, 24)
        Me.txtnom.MaxLength = 60
        Me.txtnom.Name = "txtnom"
        Me.txtnom.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtnom.Size = New System.Drawing.Size(369, 19)
        Me.txtnom.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.txtnom, "Digíte el nombre deseado para la impreción de la factura")
        '
        'btAceptar
        '
        Me.btAceptar.BackColor = System.Drawing.Color.SteelBlue
        Me.btAceptar.Cursor = System.Windows.Forms.Cursors.Default
        Me.btAceptar.ForeColor = System.Drawing.Color.White
        Me.btAceptar.Location = New System.Drawing.Point(512, 272)
        Me.btAceptar.Name = "btAceptar"
        Me.btAceptar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btAceptar.Size = New System.Drawing.Size(55, 25)
        Me.btAceptar.TabIndex = 0
        Me.btAceptar.Text = "&Grabar"
        Me.ToolTip1.SetToolTip(Me.btAceptar, "Salir dela opción")
        Me.btAceptar.UseVisualStyleBackColor = False
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.Frame2.Controls.Add(Me.txtcodigo)
        Me.Frame2.Controls.Add(Me.btncliente)
        Me.Frame2.Controls.Add(Me.txtnom)
        Me.Frame2.Controls.Add(Me.Label13)
        Me.Frame2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(8, 0)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(582, 57)
        Me.Frame2.TabIndex = 1
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "&Emisor del documento"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(8, 32)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(62, 17)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "CI/RUC"
        '
        'Malla
        '
        Me.Malla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Malla.Location = New System.Drawing.Point(139, 99)
        Me.Malla.Name = "Malla"
        Me.Malla.Size = New System.Drawing.Size(404, 122)
        Me.Malla.TabIndex = 8
        '
        'AdcAutorizacionesSri
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(728, 300)
        Me.Controls.Add(Me.Malla)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.btAceptar)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AdcAutorizacionesSri"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Registro de autorizaciones del SRI para emisión de documentos"
        Me.Frame2.ResumeLayout(False)
        Me.Frame2.PerformLayout()
        CType(Me.Malla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Malla As System.Windows.Forms.DataGridView
#End Region 
End Class