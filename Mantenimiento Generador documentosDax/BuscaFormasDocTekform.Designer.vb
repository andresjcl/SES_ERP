<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class BuscaFormasDoc
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
	Public WithEvents txtnombre As System.Windows.Forms.TextBox
	Public WithEvents btncancelarbusca As System.Windows.Forms.Button
	Public WithEvents btnbuscar As System.Windows.Forms.Button
	Public WithEvents btNuevo As System.Windows.Forms.Button
    Public WithEvents Label10 As System.Windows.Forms.Label
    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar mediante el Diseñador de Windows Forms.
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BuscaFormasDoc))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btncancelarbusca = New System.Windows.Forms.Button()
        Me.btnbuscar = New System.Windows.Forms.Button()
        Me.btNuevo = New System.Windows.Forms.Button()
        Me.txtnombre = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ListNombre = New System.Windows.Forms.DataGridView()
        CType(Me.ListNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btncancelarbusca
        '
        Me.btncancelarbusca.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btncancelarbusca.Cursor = System.Windows.Forms.Cursors.Default
        Me.btncancelarbusca.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btncancelarbusca.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btncancelarbusca.Location = New System.Drawing.Point(216, 344)
        Me.btncancelarbusca.Name = "btncancelarbusca"
        Me.btncancelarbusca.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btncancelarbusca.Size = New System.Drawing.Size(69, 25)
        Me.btncancelarbusca.TabIndex = 3
        Me.btncancelarbusca.Text = "&Cancelar"
        Me.ToolTip1.SetToolTip(Me.btncancelarbusca, "Elija para ingresar un nuevo nivel")
        Me.btncancelarbusca.UseVisualStyleBackColor = False
        '
        'btnbuscar
        '
        Me.btnbuscar.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnbuscar.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnbuscar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnbuscar.Location = New System.Drawing.Point(136, 344)
        Me.btnbuscar.Name = "btnbuscar"
        Me.btnbuscar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnbuscar.Size = New System.Drawing.Size(69, 25)
        Me.btnbuscar.TabIndex = 2
        Me.btnbuscar.Text = "&Aceptar"
        Me.ToolTip1.SetToolTip(Me.btnbuscar, "Realiza la busqueda")
        Me.btnbuscar.UseVisualStyleBackColor = False
        '
        'btNuevo
        '
        Me.btNuevo.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btNuevo.Cursor = System.Windows.Forms.Cursors.Default
        Me.btNuevo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btNuevo.Location = New System.Drawing.Point(8, 344)
        Me.btNuevo.Name = "btNuevo"
        Me.btNuevo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btNuevo.Size = New System.Drawing.Size(69, 25)
        Me.btNuevo.TabIndex = 1
        Me.btNuevo.Text = "&Nuevo"
        Me.ToolTip1.SetToolTip(Me.btNuevo, "Realiza la busqueda")
        Me.btNuevo.UseVisualStyleBackColor = False
        Me.btNuevo.Visible = False
        '
        'txtnombre
        '
        Me.txtnombre.AcceptsReturn = True
        Me.txtnombre.BackColor = System.Drawing.Color.AliceBlue
        Me.txtnombre.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtnombre.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtnombre.Location = New System.Drawing.Point(56, 8)
        Me.txtnombre.MaxLength = 30
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtnombre.Size = New System.Drawing.Size(193, 20)
        Me.txtnombre.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(0, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Buscar"
        '
        'ListNombre
        '
        Me.ListNombre.AllowUserToAddRows = False
        Me.ListNombre.AllowUserToDeleteRows = False
        Me.ListNombre.AllowUserToResizeRows = False
        Me.ListNombre.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader
        Me.ListNombre.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ListNombre.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.ListNombre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.AliceBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ListNombre.DefaultCellStyle = DataGridViewCellStyle2
        Me.ListNombre.EnableHeadersVisualStyles = False
        Me.ListNombre.Location = New System.Drawing.Point(8, 46)
        Me.ListNombre.Name = "ListNombre"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ListNombre.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.ListNombre.RowHeadersWidth = 21
        Me.ListNombre.Size = New System.Drawing.Size(277, 292)
        Me.ListNombre.TabIndex = 6
        '
        'BuscaFormasDoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.CancelButton = Me.btncancelarbusca
        Me.ClientSize = New System.Drawing.Size(294, 377)
        Me.Controls.Add(Me.ListNombre)
        Me.Controls.Add(Me.txtnombre)
        Me.Controls.Add(Me.btncancelarbusca)
        Me.Controls.Add(Me.btnbuscar)
        Me.Controls.Add(Me.btNuevo)
        Me.Controls.Add(Me.Label10)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BuscaFormasDoc"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Formas de impresion de Documentos"
        CType(Me.ListNombre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListNombre As System.Windows.Forms.DataGridView
#End Region 
End Class