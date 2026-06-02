<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BuscarAcf
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgListaAct = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optNombre = New System.Windows.Forms.RadioButton()
        Me.optCodigo = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSucursal = New System.Windows.Forms.Button()
        Me.txtSucursal = New System.Windows.Forms.TextBox()
        Me.btnSeccion = New System.Windows.Forms.Button()
        Me.btnDpto = New System.Windows.Forms.Button()
        Me.txtSeccion = New System.Windows.Forms.TextBox()
        Me.txtDpto = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.conInicial = New System.Windows.Forms.CheckBox()
        CType(Me.dgListaAct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgListaAct
        '
        Me.dgListaAct.AllowUserToAddRows = False
        Me.dgListaAct.AllowUserToDeleteRows = False
        Me.dgListaAct.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgListaAct.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgListaAct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgListaAct.EnableHeadersVisualStyles = False
        Me.dgListaAct.Location = New System.Drawing.Point(23, 142)
        Me.dgListaAct.Name = "dgListaAct"
        Me.dgListaAct.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgListaAct.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgListaAct.Size = New System.Drawing.Size(481, 252)
        Me.dgListaAct.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optNombre)
        Me.GroupBox1.Controls.Add(Me.optCodigo)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(231, 43)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ordenar Por:"
        '
        'optNombre
        '
        Me.optNombre.AutoSize = True
        Me.optNombre.Location = New System.Drawing.Point(141, 19)
        Me.optNombre.Name = "optNombre"
        Me.optNombre.Size = New System.Drawing.Size(62, 17)
        Me.optNombre.TabIndex = 1
        Me.optNombre.TabStop = True
        Me.optNombre.Text = "&Nombre"
        Me.optNombre.UseVisualStyleBackColor = True
        '
        'optCodigo
        '
        Me.optCodigo.AutoSize = True
        Me.optCodigo.Checked = True
        Me.optCodigo.Location = New System.Drawing.Point(26, 19)
        Me.optCodigo.Name = "optCodigo"
        Me.optCodigo.Size = New System.Drawing.Size(58, 17)
        Me.optCodigo.TabIndex = 0
        Me.optCodigo.TabStop = True
        Me.optCodigo.Text = "&Código"
        Me.optCodigo.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnSucursal)
        Me.GroupBox2.Controls.Add(Me.txtSucursal)
        Me.GroupBox2.Controls.Add(Me.btnSeccion)
        Me.GroupBox2.Controls.Add(Me.btnDpto)
        Me.GroupBox2.Controls.Add(Me.txtSeccion)
        Me.GroupBox2.Controls.Add(Me.txtDpto)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(261, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(243, 102)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ubicación"
        '
        'btnSucursal
        '
        Me.btnSucursal.Location = New System.Drawing.Point(199, 23)
        Me.btnSucursal.Name = "btnSucursal"
        Me.btnSucursal.Size = New System.Drawing.Size(24, 20)
        Me.btnSucursal.TabIndex = 9
        Me.btnSucursal.Text = "..."
        Me.btnSucursal.UseVisualStyleBackColor = True
        '
        'txtSucursal
        '
        Me.txtSucursal.Location = New System.Drawing.Point(58, 23)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.Size = New System.Drawing.Size(135, 20)
        Me.txtSucursal.TabIndex = 8
        '
        'btnSeccion
        '
        Me.btnSeccion.Location = New System.Drawing.Point(199, 67)
        Me.btnSeccion.Name = "btnSeccion"
        Me.btnSeccion.Size = New System.Drawing.Size(24, 20)
        Me.btnSeccion.TabIndex = 7
        Me.btnSeccion.Text = "..."
        Me.btnSeccion.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSeccion.UseVisualStyleBackColor = True
        '
        'btnDpto
        '
        Me.btnDpto.Location = New System.Drawing.Point(199, 45)
        Me.btnDpto.Name = "btnDpto"
        Me.btnDpto.Size = New System.Drawing.Size(24, 20)
        Me.btnDpto.TabIndex = 6
        Me.btnDpto.Text = "..."
        Me.btnDpto.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDpto.UseVisualStyleBackColor = True
        '
        'txtSeccion
        '
        Me.txtSeccion.Location = New System.Drawing.Point(58, 68)
        Me.txtSeccion.Name = "txtSeccion"
        Me.txtSeccion.Size = New System.Drawing.Size(135, 20)
        Me.txtSeccion.TabIndex = 5
        '
        'txtDpto
        '
        Me.txtDpto.Location = New System.Drawing.Point(58, 46)
        Me.txtDpto.Name = "txtDpto"
        Me.txtDpto.Size = New System.Drawing.Size(135, 20)
        Me.txtDpto.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Sección:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Dpto:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Suc:"
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(23, 116)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(109, 20)
        Me.txtCodigo.TabIndex = 4
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(138, 116)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(366, 20)
        Me.txtNombre.TabIndex = 5
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(409, 411)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(95, 26)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'conInicial
        '
        Me.conInicial.AutoSize = True
        Me.conInicial.Location = New System.Drawing.Point(23, 93)
        Me.conInicial.Name = "conInicial"
        Me.conInicial.Size = New System.Drawing.Size(85, 17)
        Me.conInicial.TabIndex = 7
        Me.conInicial.Text = "Con iniciales"
        Me.conInicial.UseVisualStyleBackColor = True
        '
        'BuscarAcf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(534, 449)
        Me.ControlBox = False
        Me.Controls.Add(Me.conInicial)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgListaAct)
        Me.Name = "BuscarAcf"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmBuscarActivo"
        CType(Me.dgListaAct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgListaAct As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optNombre As System.Windows.Forms.RadioButton
    Friend WithEvents optCodigo As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSeccion As System.Windows.Forms.TextBox
    Friend WithEvents txtDpto As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSeccion As System.Windows.Forms.Button
    Friend WithEvents btnDpto As System.Windows.Forms.Button
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents conInicial As System.Windows.Forms.CheckBox
    Friend WithEvents btnSucursal As System.Windows.Forms.Button
    Friend WithEvents txtSucursal As System.Windows.Forms.TextBox
End Class
