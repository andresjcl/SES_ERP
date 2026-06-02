<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAcumulados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAcumulados))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.btnEliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.gridDatos = New System.Windows.Forms.DataGridView()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DepreciacionF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RevalorizacionF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeterioroF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DepreciacionT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RevalorizacionT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeterioroT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMes = New System.Windows.Forms.MaskedTextBox()
        Me.txtAño = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolTipCeldas = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStrip1.SuspendLayout()
        CType(Me.gridDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.btnCancelar, Me.btnEliminar, Me.ToolStripSeparator1, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(844, 38)
        Me.ToolStrip1.TabIndex = 50
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnGuardar
        '
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.Image = Global.SaldosIniciales.My.Resources.Resources.Grabar
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(53, 35)
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnGuardar.ToolTipText = "Guardar Acumulados"
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.White
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(57, 35)
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnCancelar.ToolTipText = "Cancelar Ingreso"
        '
        'btnEliminar
        '
        Me.btnEliminar.ForeColor = System.Drawing.Color.White
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(54, 35)
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnEliminar.ToolTipText = "Eliminar Acumulados"
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
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(33, 35)
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'gridDatos
        '
        Me.gridDatos.AllowUserToAddRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.InfoText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridDatos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gridDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.Nombre, Me.DepreciacionF, Me.RevalorizacionF, Me.DeterioroF, Me.DepreciacionT, Me.RevalorizacionT, Me.DeterioroT})
        Me.gridDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridDatos.EnableHeadersVisualStyles = False
        Me.gridDatos.Location = New System.Drawing.Point(0, 38)
        Me.gridDatos.Name = "gridDatos"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridDatos.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gridDatos.Size = New System.Drawing.Size(844, 244)
        Me.gridDatos.TabIndex = 51
        '
        'Codigo
        '
        Me.Codigo.HeaderText = "Codigo"
        Me.Codigo.Name = "Codigo"
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        '
        'DepreciacionF
        '
        Me.DepreciacionF.HeaderText = "Depreciacion Financiera"
        Me.DepreciacionF.Name = "DepreciacionF"
        '
        'RevalorizacionF
        '
        Me.RevalorizacionF.HeaderText = "Revalorizacion Financiera"
        Me.RevalorizacionF.Name = "RevalorizacionF"
        '
        'DeterioroF
        '
        Me.DeterioroF.HeaderText = "Deterioro Financiero"
        Me.DeterioroF.Name = "DeterioroF"
        '
        'DepreciacionT
        '
        Me.DepreciacionT.HeaderText = "Depreciacion Tributaria"
        Me.DepreciacionT.Name = "DepreciacionT"
        '
        'RevalorizacionT
        '
        Me.RevalorizacionT.HeaderText = "Revalorización Tributaria"
        Me.RevalorizacionT.Name = "RevalorizacionT"
        '
        'DeterioroT
        '
        Me.DeterioroT.HeaderText = "Deterioro Tributario"
        Me.DeterioroT.Name = "DeterioroT"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(702, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "Mes:"
        '
        'txtMes
        '
        Me.txtMes.Location = New System.Drawing.Point(738, 7)
        Me.txtMes.Mask = "##"
        Me.txtMes.Name = "txtMes"
        Me.txtMes.Size = New System.Drawing.Size(20, 20)
        Me.txtMes.TabIndex = 53
        '
        'txtAño
        '
        Me.txtAño.Location = New System.Drawing.Point(800, 7)
        Me.txtAño.Mask = "####"
        Me.txtAño.Name = "txtAño"
        Me.txtAño.Size = New System.Drawing.Size(32, 20)
        Me.txtAño.TabIndex = 56
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(764, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "Año:"
        '
        'frmAcumulados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(844, 282)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtAño)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtMes)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gridDatos)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frmAcumulados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingreso de Valores Acumulados Iniciales"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.gridDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents gridDatos As System.Windows.Forms.DataGridView
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DepreciacionF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevalorizacionF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeterioroF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DepreciacionT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevalorizacionT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeterioroT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMes As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtAño As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolTipCeldas As System.Windows.Forms.ToolTip

End Class
