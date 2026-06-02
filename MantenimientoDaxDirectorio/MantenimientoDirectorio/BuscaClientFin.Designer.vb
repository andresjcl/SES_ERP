<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BuscaClientFin
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BuscaClientFin))
        Me.chkTodos = New System.Windows.Forms.RadioButton()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.NomClienePrincipal = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btncancelarbusca = New System.Windows.Forms.Button()
        Me.btnbuscar = New System.Windows.Forms.Button()
        Me.btNuevo = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TxtNombre = New System.Windows.Forms.TextBox()
        Me.ConInicio = New System.Windows.Forms.CheckBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ListNombre = New System.Windows.Forms.DataGridView()
        Me.Frame1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.ListNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkTodos
        '
        Me.chkTodos.AutoSize = True
        Me.chkTodos.ForeColor = System.Drawing.Color.White
        Me.chkTodos.Location = New System.Drawing.Point(12, 53)
        Me.chkTodos.Name = "chkTodos"
        Me.chkTodos.Size = New System.Drawing.Size(143, 17)
        Me.chkTodos.TabIndex = 3
        Me.chkTodos.Text = "To&dos los clientes finales"
        Me.chkTodos.UseVisualStyleBackColor = True
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.Color.SteelBlue
        Me.Frame1.Controls.Add(Me.Button1)
        Me.Frame1.Controls.Add(Me.NomClienePrincipal)
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.Controls.Add(Me.chkTodos)
        Me.Frame1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Frame1.Location = New System.Drawing.Point(0, 0)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Size = New System.Drawing.Size(574, 86)
        Me.Frame1.TabIndex = 3
        Me.Frame1.TabStop = False
        '
        'Button1
        '
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(509, 49)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(53, 24)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Buscar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'NomClienePrincipal
        '
        Me.NomClienePrincipal.ForeColor = System.Drawing.Color.White
        Me.NomClienePrincipal.Location = New System.Drawing.Point(157, 25)
        Me.NomClienePrincipal.Name = "NomClienePrincipal"
        Me.NomClienePrincipal.Size = New System.Drawing.Size(374, 13)
        Me.NomClienePrincipal.TabIndex = 5
        Me.NomClienePrincipal.Text = ".."
        Me.NomClienePrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Cliente Principal/Operador :"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(9, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(153, 33)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Señale el cliente y presione F3 para escojer un alias"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btncancelarbusca
        '
        Me.btncancelarbusca.BackColor = System.Drawing.Color.SteelBlue
        Me.btncancelarbusca.ForeColor = System.Drawing.Color.White
        Me.btncancelarbusca.Location = New System.Drawing.Point(360, 8)
        Me.btncancelarbusca.Name = "btncancelarbusca"
        Me.btncancelarbusca.Size = New System.Drawing.Size(75, 23)
        Me.btncancelarbusca.TabIndex = 2
        Me.btncancelarbusca.Text = "Cancelar"
        Me.btncancelarbusca.UseVisualStyleBackColor = False
        '
        'btnbuscar
        '
        Me.btnbuscar.BackColor = System.Drawing.Color.SteelBlue
        Me.btnbuscar.ForeColor = System.Drawing.Color.White
        Me.btnbuscar.Location = New System.Drawing.Point(284, 8)
        Me.btnbuscar.Name = "btnbuscar"
        Me.btnbuscar.Size = New System.Drawing.Size(74, 23)
        Me.btnbuscar.TabIndex = 1
        Me.btnbuscar.Text = "Aceptar"
        Me.btnbuscar.UseVisualStyleBackColor = False
        '
        'btNuevo
        '
        Me.btNuevo.BackColor = System.Drawing.Color.SteelBlue
        Me.btNuevo.ForeColor = System.Drawing.Color.White
        Me.btNuevo.Location = New System.Drawing.Point(191, 8)
        Me.btNuevo.Name = "btNuevo"
        Me.btNuevo.Size = New System.Drawing.Size(92, 23)
        Me.btNuevo.TabIndex = 0
        Me.btNuevo.Text = "&Nuevo Express"
        Me.btNuevo.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.btncancelarbusca)
        Me.Panel2.Controls.Add(Me.btnbuscar)
        Me.Panel2.Controls.Add(Me.btNuevo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 376)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(574, 43)
        Me.Panel2.TabIndex = 21
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(100, 5)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(463, 20)
        Me.TxtNombre.TabIndex = 10
        '
        'ConInicio
        '
        Me.ConInicio.AutoSize = True
        Me.ConInicio.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ConInicio.Location = New System.Drawing.Point(4, 7)
        Me.ConInicio.Name = "ConInicio"
        Me.ConInicio.Size = New System.Drawing.Size(86, 17)
        Me.ConInicio.TabIndex = 9
        Me.ConInicio.Text = "Buscar inicio"
        Me.ConInicio.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel5.Controls.Add(Me.TxtNombre)
        Me.Panel5.Controls.Add(Me.ConInicio)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 86)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(574, 31)
        Me.Panel5.TabIndex = 23
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel4.Controls.Add(Me.Frame1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(574, 86)
        Me.Panel4.TabIndex = 22
        '
        'ListNombre
        '
        Me.ListNombre.AllowUserToAddRows = False
        Me.ListNombre.AllowUserToDeleteRows = False
        Me.ListNombre.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.ListNombre.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ListNombre.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.ListNombre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ListNombre.DefaultCellStyle = DataGridViewCellStyle2
        Me.ListNombre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListNombre.EnableHeadersVisualStyles = False
        Me.ListNombre.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ListNombre.Location = New System.Drawing.Point(0, 117)
        Me.ListNombre.MultiSelect = False
        Me.ListNombre.Name = "ListNombre"
        Me.ListNombre.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ListNombre.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.ListNombre.RowHeadersVisible = False
        Me.ListNombre.RowHeadersWidth = 21
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        Me.ListNombre.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.ListNombre.Size = New System.Drawing.Size(574, 259)
        Me.ListNombre.TabIndex = 24
        '
        'BuscaClientFin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(574, 419)
        Me.ControlBox = False
        Me.Controls.Add(Me.ListNombre)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "BuscaClientFin"
        Me.ShowIcon = False
        Me.Text = "ADCOMDAX - Busca cliente final"
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.ListNombre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chkTodos As System.Windows.Forms.RadioButton
    Friend WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btncancelarbusca As System.Windows.Forms.Button
    Friend WithEvents btnbuscar As System.Windows.Forms.Button
    Friend WithEvents btNuevo As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents ConInicio As System.Windows.Forms.CheckBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents NomClienePrincipal As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ListNombre As System.Windows.Forms.DataGridView
End Class
