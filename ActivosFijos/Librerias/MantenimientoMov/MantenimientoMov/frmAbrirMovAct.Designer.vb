<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbrirMovAct
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbrirMovAct))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSucursal = New System.Windows.Forms.Button()
        Me.txtSucursal = New System.Windows.Forms.TextBox()
        Me.btnSeccion = New System.Windows.Forms.Button()
        Me.btnDepto = New System.Windows.Forms.Button()
        Me.txtSeccion = New System.Windows.Forms.TextBox()
        Me.txtDpto = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.optNumero = New System.Windows.Forms.RadioButton()
        Me.optCodigo = New System.Windows.Forms.RadioButton()
        Me.gridListado = New System.Windows.Forms.DataGridView()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtDetalle = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.gridListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSucursal)
        Me.GroupBox1.Controls.Add(Me.txtSucursal)
        Me.GroupBox1.Controls.Add(Me.btnSeccion)
        Me.GroupBox1.Controls.Add(Me.btnDepto)
        Me.GroupBox1.Controls.Add(Me.txtSeccion)
        Me.GroupBox1.Controls.Add(Me.txtDpto)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(155, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(298, 107)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ubicación"
        '
        'btnSucursal
        '
        Me.btnSucursal.Location = New System.Drawing.Point(260, 22)
        Me.btnSucursal.Name = "btnSucursal"
        Me.btnSucursal.Size = New System.Drawing.Size(22, 19)
        Me.btnSucursal.TabIndex = 10
        Me.btnSucursal.Text = "..."
        Me.btnSucursal.UseVisualStyleBackColor = True
        '
        'txtSucursal
        '
        Me.txtSucursal.Location = New System.Drawing.Point(86, 21)
        Me.txtSucursal.Name = "txtSucursal"
        Me.txtSucursal.Size = New System.Drawing.Size(168, 20)
        Me.txtSucursal.TabIndex = 9
        '
        'btnSeccion
        '
        Me.btnSeccion.Location = New System.Drawing.Point(260, 71)
        Me.btnSeccion.Name = "btnSeccion"
        Me.btnSeccion.Size = New System.Drawing.Size(22, 19)
        Me.btnSeccion.TabIndex = 8
        Me.btnSeccion.Text = "..."
        Me.btnSeccion.UseVisualStyleBackColor = True
        '
        'btnDepto
        '
        Me.btnDepto.Location = New System.Drawing.Point(260, 46)
        Me.btnDepto.Name = "btnDepto"
        Me.btnDepto.Size = New System.Drawing.Size(22, 19)
        Me.btnDepto.TabIndex = 7
        Me.btnDepto.Text = "..."
        Me.btnDepto.UseVisualStyleBackColor = True
        '
        'txtSeccion
        '
        Me.txtSeccion.Location = New System.Drawing.Point(86, 73)
        Me.txtSeccion.Name = "txtSeccion"
        Me.txtSeccion.Size = New System.Drawing.Size(168, 20)
        Me.txtSeccion.TabIndex = 6
        '
        'txtDpto
        '
        Me.txtDpto.Location = New System.Drawing.Point(86, 46)
        Me.txtDpto.Name = "txtDpto"
        Me.txtDpto.Size = New System.Drawing.Size(168, 20)
        Me.txtDpto.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Sección"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Depto:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sucursal:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.optNumero)
        Me.GroupBox2.Controls.Add(Me.optCodigo)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(120, 107)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ordenar Por:"
        '
        'optNumero
        '
        Me.optNumero.AutoSize = True
        Me.optNumero.Location = New System.Drawing.Point(25, 61)
        Me.optNumero.Name = "optNumero"
        Me.optNumero.Size = New System.Drawing.Size(62, 17)
        Me.optNumero.TabIndex = 1
        Me.optNumero.Text = "Número"
        Me.optNumero.UseVisualStyleBackColor = True
        '
        'optCodigo
        '
        Me.optCodigo.AutoSize = True
        Me.optCodigo.Checked = True
        Me.optCodigo.Location = New System.Drawing.Point(25, 31)
        Me.optCodigo.Name = "optCodigo"
        Me.optCodigo.Size = New System.Drawing.Size(58, 17)
        Me.optCodigo.TabIndex = 0
        Me.optCodigo.TabStop = True
        Me.optCodigo.Text = "Código"
        Me.optCodigo.UseVisualStyleBackColor = True
        '
        'gridListado
        '
        Me.gridListado.AllowUserToAddRows = False
        Me.gridListado.AllowUserToDeleteRows = False
        Me.gridListado.BackgroundColor = System.Drawing.Color.White
        Me.gridListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridListado.GridColor = System.Drawing.Color.Gainsboro
        Me.gridListado.Location = New System.Drawing.Point(1, 150)
        Me.gridListado.MultiSelect = False
        Me.gridListado.Name = "gridListado"
        Me.gridListado.ReadOnly = True
        Me.gridListado.Size = New System.Drawing.Size(574, 336)
        Me.gridListado.TabIndex = 3
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.SteelBlue
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.ForeColor = System.Drawing.Color.White
        Me.btnCancelar.Location = New System.Drawing.Point(475, 76)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(100, 36)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(12, 124)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(107, 20)
        Me.txtCodigo.TabIndex = 0
        '
        'txtDetalle
        '
        Me.txtDetalle.Location = New System.Drawing.Point(139, 124)
        Me.txtDetalle.Name = "txtDetalle"
        Me.txtDetalle.Size = New System.Drawing.Size(436, 20)
        Me.txtDetalle.TabIndex = 1
        '
        'frmAbrirMovAct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(587, 487)
        Me.Controls.Add(Me.txtDetalle)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.gridListado)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAbrirMovAct"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar Movimientos de Activos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.gridListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents optNumero As System.Windows.Forms.RadioButton
    Friend WithEvents optCodigo As System.Windows.Forms.RadioButton
    Friend WithEvents gridListado As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtDetalle As System.Windows.Forms.TextBox
    Friend WithEvents btnSeccion As System.Windows.Forms.Button
    Friend WithEvents btnDepto As System.Windows.Forms.Button
    Friend WithEvents txtSeccion As System.Windows.Forms.TextBox
    Friend WithEvents txtDpto As System.Windows.Forms.TextBox
    Friend WithEvents btnSucursal As System.Windows.Forms.Button
    Friend WithEvents txtSucursal As System.Windows.Forms.TextBox
End Class
