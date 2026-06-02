<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class IngresaRegistro
#Region "Código generado por el Diseñador de Windows Forms "
	<System.Diagnostics.DebuggerNonUserCode()> public Sub New()
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
	public ToolTip1 As System.Windows.Forms.ToolTip
	public WithEvents label2 As System.Windows.Forms.TextBox
	public WithEvents IngresaRegistro As System.Windows.Forms.TextBox
	public WithEvents Cancelar As System.Windows.Forms.Button
	public WithEvents Continuar As System.Windows.Forms.Button
	public WithEvents Label6 As System.Windows.Forms.Label
	public WithEvents Label5 As System.Windows.Forms.Label
	public WithEvents Label4 As System.Windows.Forms.Label
	public WithEvents Label3 As System.Windows.Forms.Label
	public WithEvents Label1 As System.Windows.Forms.Label
	'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
	'Se puede modificar mediante el Diseñador de Windows Forms.
	'No lo modifique con el editor de código.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IngresaRegistro))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.label2 = New System.Windows.Forms.TextBox()
        Me.Cancelar = New System.Windows.Forms.Button()
        Me.Continuar = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'label2
        '
        Me.label2.AcceptsReturn = True
        Me.label2.BackColor = System.Drawing.SystemColors.Window
        Me.label2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.label2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.label2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.label2.Location = New System.Drawing.Point(32, 104)
        Me.label2.MaxLength = 0
        Me.label2.Name = "label2"
        Me.label2.ReadOnly = True
        Me.label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label2.Size = New System.Drawing.Size(513, 13)
        Me.label2.TabIndex = 8
        '
        'Cancelar
        '
        Me.Cancelar.BackColor = System.Drawing.SystemColors.Control
        Me.Cancelar.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cancelar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cancelar.Location = New System.Drawing.Point(480, 264)
        Me.Cancelar.Name = "Cancelar"
        Me.Cancelar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cancelar.Size = New System.Drawing.Size(89, 25)
        Me.Cancelar.TabIndex = 4
        Me.Cancelar.Text = "C&ancelar"
        Me.Cancelar.UseVisualStyleBackColor = False
        '
        'Continuar
        '
        Me.Continuar.BackColor = System.Drawing.SystemColors.Control
        Me.Continuar.Cursor = System.Windows.Forms.Cursors.Default
        Me.Continuar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Continuar.Location = New System.Drawing.Point(384, 264)
        Me.Continuar.Name = "Continuar"
        Me.Continuar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Continuar.Size = New System.Drawing.Size(89, 25)
        Me.Continuar.TabIndex = 3
        Me.Continuar.Text = "&Continuar"
        Me.Continuar.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(16, 272)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(135, 16)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "www.daxsof.com.ec"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(8, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(140, 16)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Su clave de registro es:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(8, 208)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(286, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Digite la clave de activación tal como la recibió :"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(56, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(465, 49)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "  Envíe esta clave a:  daxsof@daxsof.com.ec    daxsoporte@daxsof.com.ec      o co" &
    "muniquese a los  teléfonos  09-9906974  09-9906974  en Quito-Ecuador Recibirá su" &
    " clave de activación."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(32, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(509, 56)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(12, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(469, 35)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Para uso del siguiente software necesita una licencia de uso."
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(12, 88)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(546, 40)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Envíe esta clave a su proveedor del sistema para su respectiva activacion.  Ya se" &
    "a por correo soporte@sebemisof.com o al número +593 991068007 "
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(22, 156)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(442, 22)
        Me.TextBox1.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(22, 44)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(148, 16)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Su clave de registro es:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(22, 138)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(294, 16)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Digite la clave de activación tal como la recibió :"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(97, 184)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(94, 25)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Cancelar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(339, 184)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(83, 25)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Continuar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.White
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(25, 63)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(442, 22)
        Me.TextBox2.TabIndex = 8
        '
        'IngresaRegistro
        '
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.ClientSize = New System.Drawing.Size(580, 223)
        Me.ControlBox = False
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Name = "IngresaRegistro"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
#End Region
End Class