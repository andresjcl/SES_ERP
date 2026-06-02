<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBuscar
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
        Me.gridBuscarActivos = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optNombre = New System.Windows.Forms.RadioButton()
        Me.optCodigo = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSeccion = New System.Windows.Forms.Button()
        Me.txtSeccion = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnDpto = New System.Windows.Forms.Button()
        Me.txtDpto = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboSucursal = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnIdentCont = New System.Windows.Forms.Button()
        Me.txtIdentCont = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        CType(Me.gridBuscarActivos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridBuscarActivos
        '
        Me.gridBuscarActivos.AllowUserToAddRows = False
        Me.gridBuscarActivos.AllowUserToDeleteRows = False
        Me.gridBuscarActivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridBuscarActivos.Location = New System.Drawing.Point(12, 184)
        Me.gridBuscarActivos.Name = "gridBuscarActivos"
        Me.gridBuscarActivos.ReadOnly = True
        Me.gridBuscarActivos.Size = New System.Drawing.Size(531, 242)
        Me.gridBuscarActivos.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optNombre)
        Me.GroupBox1.Controls.Add(Me.optCodigo)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(240, 50)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ordenar Por:"
        '
        'optNombre
        '
        Me.optNombre.AutoSize = True
        Me.optNombre.Location = New System.Drawing.Point(105, 19)
        Me.optNombre.Name = "optNombre"
        Me.optNombre.Size = New System.Drawing.Size(62, 17)
        Me.optNombre.TabIndex = 1
        Me.optNombre.Text = "Nombre"
        Me.optNombre.UseVisualStyleBackColor = True
        '
        'optCodigo
        '
        Me.optCodigo.AutoSize = True
        Me.optCodigo.Checked = True
        Me.optCodigo.Location = New System.Drawing.Point(16, 19)
        Me.optCodigo.Name = "optCodigo"
        Me.optCodigo.Size = New System.Drawing.Size(58, 17)
        Me.optCodigo.TabIndex = 0
        Me.optCodigo.TabStop = True
        Me.optCodigo.Text = "Código"
        Me.optCodigo.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnSeccion)
        Me.GroupBox2.Controls.Add(Me.txtSeccion)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.btnDpto)
        Me.GroupBox2.Controls.Add(Me.txtDpto)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.cboSucursal)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(258, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(285, 109)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ubicación:"
        '
        'btnSeccion
        '
        Me.btnSeccion.Location = New System.Drawing.Point(220, 75)
        Me.btnSeccion.Name = "btnSeccion"
        Me.btnSeccion.Size = New System.Drawing.Size(24, 21)
        Me.btnSeccion.TabIndex = 7
        Me.btnSeccion.Text = "..."
        Me.btnSeccion.UseVisualStyleBackColor = True
        '
        'txtSeccion
        '
        Me.txtSeccion.Location = New System.Drawing.Point(74, 75)
        Me.txtSeccion.Name = "txtSeccion"
        Me.txtSeccion.Size = New System.Drawing.Size(140, 20)
        Me.txtSeccion.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Sección:"
        '
        'btnDpto
        '
        Me.btnDpto.Location = New System.Drawing.Point(220, 48)
        Me.btnDpto.Name = "btnDpto"
        Me.btnDpto.Size = New System.Drawing.Size(24, 21)
        Me.btnDpto.TabIndex = 4
        Me.btnDpto.Text = "..."
        Me.btnDpto.UseVisualStyleBackColor = True
        '
        'txtDpto
        '
        Me.txtDpto.Location = New System.Drawing.Point(74, 50)
        Me.txtDpto.Name = "txtDpto"
        Me.txtDpto.Size = New System.Drawing.Size(140, 20)
        Me.txtDpto.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Dpto :"
        '
        'cboSucursal
        '
        Me.cboSucursal.FormattingEnabled = True
        Me.cboSucursal.Location = New System.Drawing.Point(74, 21)
        Me.cboSucursal.Name = "cboSucursal"
        Me.cboSucursal.Size = New System.Drawing.Size(170, 21)
        Me.cboSucursal.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Suc :"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnIdentCont)
        Me.GroupBox3.Controls.Add(Me.txtIdentCont)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 68)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(240, 53)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Contabilidad"
        '
        'btnIdentCont
        '
        Me.btnIdentCont.Location = New System.Drawing.Point(210, 16)
        Me.btnIdentCont.Name = "btnIdentCont"
        Me.btnIdentCont.Size = New System.Drawing.Size(24, 24)
        Me.btnIdentCont.TabIndex = 2
        Me.btnIdentCont.Text = "..."
        Me.btnIdentCont.UseVisualStyleBackColor = True
        '
        'txtIdentCont
        '
        Me.txtIdentCont.Location = New System.Drawing.Point(76, 19)
        Me.txtIdentCont.Name = "txtIdentCont"
        Me.txtIdentCont.Size = New System.Drawing.Size(128, 20)
        Me.txtIdentCont.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ident. Cont."
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(12, 147)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(143, 20)
        Me.txtCodigo.TabIndex = 4
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(161, 147)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(382, 20)
        Me.txtNombre.TabIndex = 5
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(430, 432)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(103, 26)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'FrmBuscar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 464)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gridBuscarActivos)
        Me.Name = "FrmBuscar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Activos"
        CType(Me.gridBuscarActivos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gridBuscarActivos As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optNombre As System.Windows.Forms.RadioButton
    Friend WithEvents optCodigo As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSeccion As System.Windows.Forms.Button
    Friend WithEvents txtSeccion As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnDpto As System.Windows.Forms.Button
    Friend WithEvents txtDpto As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnIdentCont As System.Windows.Forms.Button
    Friend WithEvents txtIdentCont As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
End Class
