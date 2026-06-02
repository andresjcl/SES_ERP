<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Depreciacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Depreciacion))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCod = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnDepreciar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbMesFinaliza = New System.Windows.Forms.ComboBox()
        Me.cmbMesInicial = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAñoFinaliza = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAñoInicia = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnActivo = New System.Windows.Forms.Button()
        Me.txtDesc = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Activo"
        '
        'txtCod
        '
        Me.txtCod.Location = New System.Drawing.Point(48, 18)
        Me.txtCod.Name = "txtCod"
        Me.txtCod.Size = New System.Drawing.Size(82, 20)
        Me.txtCod.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Año inicio:"
        '
        'btnDepreciar
        '
        Me.btnDepreciar.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnDepreciar.Location = New System.Drawing.Point(200, 144)
        Me.btnDepreciar.Name = "btnDepreciar"
        Me.btnDepreciar.Size = New System.Drawing.Size(85, 33)
        Me.btnDepreciar.TabIndex = 8
        Me.btnDepreciar.Text = "Depreciar"
        Me.btnDepreciar.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnCancelar.Location = New System.Drawing.Point(291, 144)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(84, 33)
        Me.btnCancelar.TabIndex = 9
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbMesFinaliza)
        Me.GroupBox1.Controls.Add(Me.cmbMesInicial)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtAñoFinaliza)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtAñoInicia)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(367, 74)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cmbMesFinaliza
        '
        Me.cmbMesFinaliza.FormattingEnabled = True
        Me.cmbMesFinaliza.Items.AddRange(New Object() {"enero", "febrero", "marzo", "abril", "mayo", "junio", "julio", "agosto", "septiembre", "octubre", "noviembre", "diciembre"})
        Me.cmbMesFinaliza.Location = New System.Drawing.Point(200, 41)
        Me.cmbMesFinaliza.Name = "cmbMesFinaliza"
        Me.cmbMesFinaliza.Size = New System.Drawing.Size(147, 21)
        Me.cmbMesFinaliza.TabIndex = 13
        '
        'cmbMesInicial
        '
        Me.cmbMesInicial.FormattingEnabled = True
        Me.cmbMesInicial.Items.AddRange(New Object() {"enero", "febrero", "marzo", "abril", "mayo", "junio", "julio", "agosto", "septiembre", "octubre", "noviembre", "diciembre"})
        Me.cmbMesInicial.Location = New System.Drawing.Point(200, 16)
        Me.cmbMesInicial.Name = "cmbMesInicial"
        Me.cmbMesInicial.Size = New System.Drawing.Size(147, 21)
        Me.cmbMesInicial.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(136, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Mes fin:"
        '
        'txtAñoFinaliza
        '
        Me.txtAñoFinaliza.Location = New System.Drawing.Point(84, 41)
        Me.txtAñoFinaliza.Name = "txtAñoFinaliza"
        Me.txtAñoFinaliza.Size = New System.Drawing.Size(44, 20)
        Me.txtAñoFinaliza.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Año fin:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(136, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Mes inicio:"
        '
        'txtAñoInicia
        '
        Me.txtAñoInicia.Location = New System.Drawing.Point(84, 16)
        Me.txtAñoInicia.Name = "txtAñoInicia"
        Me.txtAñoInicia.Size = New System.Drawing.Size(44, 20)
        Me.txtAñoInicia.TabIndex = 6
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnActivo)
        Me.GroupBox2.Controls.Add(Me.txtDesc)
        Me.GroupBox2.Controls.Add(Me.txtCod)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 86)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(367, 49)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Depreciar Solo Un Activo"
        '
        'btnActivo
        '
        Me.btnActivo.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnActivo.Location = New System.Drawing.Point(337, 17)
        Me.btnActivo.Name = "btnActivo"
        Me.btnActivo.Size = New System.Drawing.Size(21, 21)
        Me.btnActivo.TabIndex = 7
        Me.btnActivo.Text = "..."
        Me.btnActivo.UseVisualStyleBackColor = False
        '
        'txtDesc
        '
        Me.txtDesc.Location = New System.Drawing.Point(136, 18)
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.Size = New System.Drawing.Size(211, 20)
        Me.txtDesc.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Gray
        Me.Label6.Location = New System.Drawing.Point(380, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(189, 166)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = resources.GetString("Label6.Text")
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Depreciacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(572, 184)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnDepreciar)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Name = "Depreciacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Depreciación"
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        Me.GroupBox2.ResumeLayout(false)
        Me.GroupBox2.PerformLayout
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCod As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnDepreciar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnActivo As System.Windows.Forms.Button
    Friend WithEvents txtDesc As System.Windows.Forms.TextBox
    Friend WithEvents cmbMesFinaliza As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMesInicial As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAñoFinaliza As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAñoInicia As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
