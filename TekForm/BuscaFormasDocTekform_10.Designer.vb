<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class BuscaFormasDoc
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BuscaFormasDoc))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btncancelarbusca = New System.Windows.Forms.Button()
        Me.btnbuscar = New System.Windows.Forms.Button()
        Me.btNuevo = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtnombre = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolTip1
        '
        '
        'btncancelarbusca
        '
        Me.btncancelarbusca.BackColor = System.Drawing.Color.SteelBlue
        Me.btncancelarbusca.Cursor = System.Windows.Forms.Cursors.Default
        Me.btncancelarbusca.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btncancelarbusca.ForeColor = System.Drawing.Color.White
        Me.btncancelarbusca.Location = New System.Drawing.Point(197, 15)
        Me.btncancelarbusca.Name = "btncancelarbusca"
        Me.btncancelarbusca.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btncancelarbusca.Size = New System.Drawing.Size(69, 25)
        Me.btncancelarbusca.TabIndex = 6
        Me.btncancelarbusca.Text = "&Cancelar"
        Me.ToolTip1.SetToolTip(Me.btncancelarbusca, "Elija para ingresar un nuevo nivel")
        Me.btncancelarbusca.UseVisualStyleBackColor = False
        '
        'btnbuscar
        '
        Me.btnbuscar.BackColor = System.Drawing.Color.SteelBlue
        Me.btnbuscar.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnbuscar.ForeColor = System.Drawing.Color.White
        Me.btnbuscar.Location = New System.Drawing.Point(106, 15)
        Me.btnbuscar.Name = "btnbuscar"
        Me.btnbuscar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnbuscar.Size = New System.Drawing.Size(69, 25)
        Me.btnbuscar.TabIndex = 5
        Me.btnbuscar.Text = "&Aceptar"
        Me.ToolTip1.SetToolTip(Me.btnbuscar, "Realiza la busqueda")
        Me.btnbuscar.UseVisualStyleBackColor = False
        '
        'btNuevo
        '
        Me.btNuevo.BackColor = System.Drawing.Color.SteelBlue
        Me.btNuevo.Cursor = System.Windows.Forms.Cursors.Default
        Me.btNuevo.ForeColor = System.Drawing.Color.White
        Me.btNuevo.Location = New System.Drawing.Point(13, 15)
        Me.btNuevo.Name = "btNuevo"
        Me.btNuevo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btNuevo.Size = New System.Drawing.Size(69, 25)
        Me.btNuevo.TabIndex = 4
        Me.btNuevo.Text = "&Nuevo"
        Me.ToolTip1.SetToolTip(Me.btNuevo, "Realiza la busqueda")
        Me.btNuevo.UseVisualStyleBackColor = False
        Me.btNuevo.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(275, 373)
        Me.DataGridView1.TabIndex = 6
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtnombre)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(275, 43)
        Me.Panel1.TabIndex = 7
        '
        'txtnombre
        '
        Me.txtnombre.AcceptsReturn = True
        Me.txtnombre.BackColor = System.Drawing.SystemColors.Window
        Me.txtnombre.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtnombre.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtnombre.Location = New System.Drawing.Point(58, 17)
        Me.txtnombre.MaxLength = 30
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtnombre.Size = New System.Drawing.Size(215, 20)
        Me.txtnombre.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(13, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Buscar"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btncancelarbusca)
        Me.Panel2.Controls.Add(Me.btnbuscar)
        Me.Panel2.Controls.Add(Me.btNuevo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 318)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(275, 55)
        Me.Panel2.TabIndex = 8
        '
        'BuscaFormasDoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(275, 373)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BuscaFormasDoc"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Formatos para impresion de documentos"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents txtnombre As System.Windows.Forms.TextBox
    Public WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Public WithEvents btncancelarbusca As System.Windows.Forms.Button
    Public WithEvents btnbuscar As System.Windows.Forms.Button
    Public WithEvents btNuevo As System.Windows.Forms.Button
#End Region 
End Class