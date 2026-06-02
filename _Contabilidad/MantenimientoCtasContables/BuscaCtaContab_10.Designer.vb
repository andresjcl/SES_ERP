<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class BuscaCtaContab
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
	Public WithEvents OpCentrosCosto As System.Windows.Forms.CheckBox
	Public WithEvents PorInicial As System.Windows.Forms.CheckBox
	Public WithEvents OpComodines As System.Windows.Forms.CheckBox
	Public WithEvents btncancelarbusca As System.Windows.Forms.Button
	Public WithEvents btAceptar As System.Windows.Forms.Button
	Public WithEvents btNuevo As System.Windows.Forms.Button
    Public WithEvents Optcodigo As System.Windows.Forms.RadioButton
    Public WithEvents OptNombre As System.Windows.Forms.RadioButton
    Public WithEvents TxtNombre As System.Windows.Forms.TextBox
    Public WithEvents TextCodigo As System.Windows.Forms.TextBox
    Public WithEvents TxtGrupo As System.Windows.Forms.TextBox
    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar mediante el Diseñador de Windows Forms.
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BuscaCtaContab))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btncancelarbusca = New System.Windows.Forms.Button()
        Me.btAceptar = New System.Windows.Forms.Button()
        Me.btNuevo = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.OpCentrosCosto = New System.Windows.Forms.CheckBox()
        Me.PorInicial = New System.Windows.Forms.CheckBox()
        Me.OpComodines = New System.Windows.Forms.CheckBox()
        Me.Optcodigo = New System.Windows.Forms.RadioButton()
        Me.OptNombre = New System.Windows.Forms.RadioButton()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.TextCodigo = New System.Windows.Forms.TextBox()
        Me.TxtGrupo = New System.Windows.Forms.TextBox()
        Me.ListNombre = New System.Windows.Forms.DataGridView()
        CType(Me.ListNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btncancelarbusca
        '
        Me.btncancelarbusca.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btncancelarbusca.Cursor = System.Windows.Forms.Cursors.Default
        Me.btncancelarbusca.FlatAppearance.BorderSize = 0
        Me.btncancelarbusca.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncancelarbusca.ForeColor = System.Drawing.Color.White
        Me.btncancelarbusca.Location = New System.Drawing.Point(96, 502)
        Me.btncancelarbusca.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btncancelarbusca.Name = "btncancelarbusca"
        Me.btncancelarbusca.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btncancelarbusca.Size = New System.Drawing.Size(81, 34)
        Me.btncancelarbusca.TabIndex = 9
        Me.btncancelarbusca.Text = "&Cancelar"
        Me.ToolTip1.SetToolTip(Me.btncancelarbusca, "Elija para ingresar un nuevo nivel")
        Me.btncancelarbusca.UseVisualStyleBackColor = False
        '
        'btAceptar
        '
        Me.btAceptar.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btAceptar.Cursor = System.Windows.Forms.Cursors.Default
        Me.btAceptar.FlatAppearance.BorderSize = 0
        Me.btAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btAceptar.ForeColor = System.Drawing.Color.White
        Me.btAceptar.Location = New System.Drawing.Point(11, 502)
        Me.btAceptar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btAceptar.Name = "btAceptar"
        Me.btAceptar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btAceptar.Size = New System.Drawing.Size(81, 34)
        Me.btAceptar.TabIndex = 8
        Me.btAceptar.Text = "&Aceptar"
        Me.ToolTip1.SetToolTip(Me.btAceptar, "Elija para ingresar un nuevo nivel")
        Me.btAceptar.UseVisualStyleBackColor = False
        '
        'btNuevo
        '
        Me.btNuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btNuevo.Cursor = System.Windows.Forms.Cursors.Default
        Me.btNuevo.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btNuevo.FlatAppearance.BorderSize = 0
        Me.btNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btNuevo.ForeColor = System.Drawing.Color.White
        Me.btNuevo.Location = New System.Drawing.Point(181, 502)
        Me.btNuevo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btNuevo.Name = "btNuevo"
        Me.btNuevo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btNuevo.Size = New System.Drawing.Size(81, 34)
        Me.btNuevo.TabIndex = 7
        Me.btNuevo.Text = "&Nueva"
        Me.ToolTip1.SetToolTip(Me.btNuevo, "Elija para ingresar un nuevo nivel")
        Me.btNuevo.UseVisualStyleBackColor = False
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnImprimir.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnImprimir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnImprimir.FlatAppearance.BorderSize = 0
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.ForeColor = System.Drawing.Color.White
        Me.btnImprimir.Location = New System.Drawing.Point(271, 502)
        Me.btnImprimir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnImprimir.Size = New System.Drawing.Size(81, 34)
        Me.btnImprimir.TabIndex = 14
        Me.btnImprimir.Text = "&Imprimir"
        Me.ToolTip1.SetToolTip(Me.btnImprimir, "Elija para ingresar un nuevo nivel")
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'OpCentrosCosto
        '
        Me.OpCentrosCosto.BackColor = System.Drawing.Color.Transparent
        Me.OpCentrosCosto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.OpCentrosCosto.Cursor = System.Windows.Forms.Cursors.Default
        Me.OpCentrosCosto.ForeColor = System.Drawing.Color.White
        Me.OpCentrosCosto.Location = New System.Drawing.Point(592, 12)
        Me.OpCentrosCosto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.OpCentrosCosto.Name = "OpCentrosCosto"
        Me.OpCentrosCosto.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OpCentrosCosto.Size = New System.Drawing.Size(241, 21)
        Me.OpCentrosCosto.TabIndex = 12
        Me.OpCentrosCosto.Text = "Cuentas con clasificadores"
        Me.OpCentrosCosto.UseVisualStyleBackColor = False
        '
        'PorInicial
        '
        Me.PorInicial.BackColor = System.Drawing.Color.Transparent
        Me.PorInicial.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.PorInicial.Cursor = System.Windows.Forms.Cursors.Default
        Me.PorInicial.ForeColor = System.Drawing.Color.White
        Me.PorInicial.Location = New System.Drawing.Point(380, 2)
        Me.PorInicial.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PorInicial.Name = "PorInicial"
        Me.PorInicial.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PorInicial.Size = New System.Drawing.Size(151, 20)
        Me.PorInicial.TabIndex = 11
        Me.PorInicial.Text = "Busca con nicial"
        Me.PorInicial.UseVisualStyleBackColor = False
        '
        'OpComodines
        '
        Me.OpComodines.BackColor = System.Drawing.Color.Transparent
        Me.OpComodines.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.OpComodines.Cursor = System.Windows.Forms.Cursors.Default
        Me.OpComodines.ForeColor = System.Drawing.Color.White
        Me.OpComodines.Location = New System.Drawing.Point(593, 33)
        Me.OpComodines.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.OpComodines.Name = "OpComodines"
        Me.OpComodines.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OpComodines.Size = New System.Drawing.Size(241, 21)
        Me.OpComodines.TabIndex = 10
        Me.OpComodines.Text = "Comodines para contabilización"
        Me.OpComodines.UseVisualStyleBackColor = False
        '
        'Optcodigo
        '
        Me.Optcodigo.BackColor = System.Drawing.Color.Transparent
        Me.Optcodigo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Optcodigo.Checked = True
        Me.Optcodigo.Cursor = System.Windows.Forms.Cursors.Default
        Me.Optcodigo.ForeColor = System.Drawing.Color.White
        Me.Optcodigo.Location = New System.Drawing.Point(16, 4)
        Me.Optcodigo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Optcodigo.Name = "Optcodigo"
        Me.Optcodigo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Optcodigo.Size = New System.Drawing.Size(161, 20)
        Me.Optcodigo.TabIndex = 4
        Me.Optcodigo.TabStop = True
        Me.Optcodigo.Text = "Ordenar por có&digo"
        Me.Optcodigo.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.Optcodigo.UseVisualStyleBackColor = False
        Me.Optcodigo.Visible = False
        '
        'OptNombre
        '
        Me.OptNombre.BackColor = System.Drawing.Color.Transparent
        Me.OptNombre.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.OptNombre.Cursor = System.Windows.Forms.Cursors.Default
        Me.OptNombre.ForeColor = System.Drawing.Color.White
        Me.OptNombre.Location = New System.Drawing.Point(188, 5)
        Me.OptNombre.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.OptNombre.Name = "OptNombre"
        Me.OptNombre.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OptNombre.Size = New System.Drawing.Size(97, 20)
        Me.OptNombre.TabIndex = 3
        Me.OptNombre.TabStop = True
        Me.OptNombre.Text = "&Nombre"
        Me.OptNombre.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.OptNombre.UseVisualStyleBackColor = False
        Me.OptNombre.Visible = False
        '
        'TxtNombre
        '
        Me.TxtNombre.AcceptsReturn = True
        Me.TxtNombre.BackColor = System.Drawing.SystemColors.Window
        Me.TxtNombre.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtNombre.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtNombre.Location = New System.Drawing.Point(160, 30)
        Me.TxtNombre.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtNombre.MaxLength = 0
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtNombre.Size = New System.Drawing.Size(369, 22)
        Me.TxtNombre.TabIndex = 2
        '
        'TextCodigo
        '
        Me.TextCodigo.AcceptsReturn = True
        Me.TextCodigo.BackColor = System.Drawing.SystemColors.Window
        Me.TextCodigo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextCodigo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextCodigo.Location = New System.Drawing.Point(43, 30)
        Me.TextCodigo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextCodigo.MaxLength = 0
        Me.TextCodigo.Name = "TextCodigo"
        Me.TextCodigo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextCodigo.Size = New System.Drawing.Size(117, 22)
        Me.TextCodigo.TabIndex = 1
        '
        'TxtGrupo
        '
        Me.TxtGrupo.AcceptsReturn = True
        Me.TxtGrupo.BackColor = System.Drawing.SystemColors.Window
        Me.TxtGrupo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtGrupo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtGrupo.Location = New System.Drawing.Point(11, 30)
        Me.TxtGrupo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtGrupo.MaxLength = 0
        Me.TxtGrupo.Name = "TxtGrupo"
        Me.TxtGrupo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtGrupo.Size = New System.Drawing.Size(32, 22)
        Me.TxtGrupo.TabIndex = 0
        '
        'ListNombre
        '
        Me.ListNombre.AllowUserToResizeRows = False
        Me.ListNombre.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        Me.ListNombre.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSlateGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ListNombre.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.ListNombre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ListNombre.EnableHeadersVisualStyles = False
        Me.ListNombre.Location = New System.Drawing.Point(11, 62)
        Me.ListNombre.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ListNombre.Name = "ListNombre"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSlateGray
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ListNombre.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.ListNombre.RowHeadersWidth = 21
        Me.ListNombre.Size = New System.Drawing.Size(824, 433)
        Me.ListNombre.TabIndex = 13
        '
        'BuscaCtaContab
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.CancelButton = Me.btNuevo
        Me.ClientSize = New System.Drawing.Size(847, 546)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.OpComodines)
        Me.Controls.Add(Me.ListNombre)
        Me.Controls.Add(Me.PorInicial)
        Me.Controls.Add(Me.OpCentrosCosto)
        Me.Controls.Add(Me.btncancelarbusca)
        Me.Controls.Add(Me.btAceptar)
        Me.Controls.Add(Me.btNuevo)
        Me.Controls.Add(Me.Optcodigo)
        Me.Controls.Add(Me.OptNombre)
        Me.Controls.Add(Me.TxtNombre)
        Me.Controls.Add(Me.TextCodigo)
        Me.Controls.Add(Me.TxtGrupo)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 29)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "BuscaCtaContab"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "BUSCAR CUENTAS CONTABLES"
        CType(Me.ListNombre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListNombre As System.Windows.Forms.DataGridView
    Public WithEvents btnImprimir As System.Windows.Forms.Button
#End Region
End Class