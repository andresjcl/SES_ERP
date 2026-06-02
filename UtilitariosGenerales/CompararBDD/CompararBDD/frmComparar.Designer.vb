<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComparar
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboBdd1 = New System.Windows.Forms.ComboBox()
        Me.cboBdd2 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.dgvMalla = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvMalla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Base de Datos Original"
        '
        'cboBdd1
        '
        Me.cboBdd1.FormattingEnabled = True
        Me.cboBdd1.Location = New System.Drawing.Point(133, 20)
        Me.cboBdd1.Name = "cboBdd1"
        Me.cboBdd1.Size = New System.Drawing.Size(179, 21)
        Me.cboBdd1.TabIndex = 1
        '
        'cboBdd2
        '
        Me.cboBdd2.FormattingEnabled = True
        Me.cboBdd2.Location = New System.Drawing.Point(436, 22)
        Me.cboBdd2.Name = "cboBdd2"
        Me.cboBdd2.Size = New System.Drawing.Size(179, 21)
        Me.cboBdd2.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(321, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Base datos Comprobar"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(15, 57)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(124, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Comparar Tablas"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(154, 57)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(124, 23)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Comparar Campos"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button6)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cboBdd2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.cboBdd1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(867, 87)
        Me.Panel1.TabIndex = 6
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(598, 56)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(195, 24)
        Me.Button6.TabIndex = 9
        Me.Button6.Text = "Copiar datos a base original"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(295, 57)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(124, 24)
        Me.Button5.TabIndex = 8
        Me.Button5.Text = "Cambiar Base Datos"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(133, 6)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(124, 24)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = "Desmarcar Todo"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(3, 6)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(124, 24)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "Marcar todo"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'dgvMalla
        '
        Me.dgvMalla.AllowUserToAddRows = False
        Me.dgvMalla.AllowUserToDeleteRows = False
        Me.dgvMalla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvMalla.BackgroundColor = System.Drawing.Color.White
        Me.dgvMalla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMalla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMalla.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvMalla.Location = New System.Drawing.Point(0, 87)
        Me.dgvMalla.Name = "dgvMalla"
        Me.dgvMalla.ReadOnly = True
        Me.dgvMalla.Size = New System.Drawing.Size(867, 239)
        Me.dgvMalla.TabIndex = 7
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Button4)
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 326)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(867, 40)
        Me.Panel2.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(263, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(598, 28)
        Me.Label3.TabIndex = 8
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmComparar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(867, 366)
        Me.Controls.Add(Me.dgvMalla)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmComparar"
        Me.Text = "Comparar"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvMalla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboBdd1 As System.Windows.Forms.ComboBox
    Friend WithEvents cboBdd2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgvMalla As System.Windows.Forms.DataGridView
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
