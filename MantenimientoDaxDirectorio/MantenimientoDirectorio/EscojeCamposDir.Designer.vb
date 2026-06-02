<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EscojeCamposDir
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Command3 = New System.Windows.Forms.Button()
        Me.Command2 = New System.Windows.Forms.Button()
        Me.Command1 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.malla = New System.Windows.Forms.CheckedListBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.Controls.Add(Me.Command3)
        Me.Panel1.Controls.Add(Me.Command2)
        Me.Panel1.Controls.Add(Me.Command1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 285)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(608, 34)
        Me.Panel1.TabIndex = 7
        '
        'Command3
        '
        Me.Command3.BackColor = System.Drawing.Color.DimGray
        Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Command3.ForeColor = System.Drawing.Color.White
        Me.Command3.Location = New System.Drawing.Point(325, 5)
        Me.Command3.Name = "Command3"
        Me.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command3.Size = New System.Drawing.Size(145, 24)
        Me.Command3.TabIndex = 10
        Me.Command3.Text = "Cancelar"
        Me.Command3.UseVisualStyleBackColor = False
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.Color.DimGray
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Command2.ForeColor = System.Drawing.Color.White
        Me.Command2.Location = New System.Drawing.Point(173, 5)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(145, 24)
        Me.Command2.TabIndex = 9
        Me.Command2.Text = "Aceptar opciones"
        Me.Command2.UseVisualStyleBackColor = False
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.Color.DimGray
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Command1.ForeColor = System.Drawing.Color.White
        Me.Command1.Location = New System.Drawing.Point(21, 5)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(145, 24)
        Me.Command1.TabIndex = 8
        Me.Command1.Text = "Prederminados"
        Me.Command1.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.malla)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(608, 285)
        Me.Panel2.TabIndex = 8
        '
        'malla
        '
        Me.malla.BackColor = System.Drawing.SystemColors.Window
        Me.malla.ColumnWidth = 198
        Me.malla.Cursor = System.Windows.Forms.Cursors.Default
        Me.malla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.malla.ForeColor = System.Drawing.SystemColors.WindowText
        Me.malla.Location = New System.Drawing.Point(0, 0)
        Me.malla.MultiColumn = True
        Me.malla.Name = "malla"
        Me.malla.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.malla.Size = New System.Drawing.Size(608, 285)
        Me.malla.Sorted = True
        Me.malla.TabIndex = 5
        '
        'EscojeCamposDir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(608, 319)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "EscojeCamposDir"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ADCOMDAX - SELECCIONAR CAMPOS PARA VISUALIZAR EL DIRECTORIO"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents Command3 As System.Windows.Forms.Button
    Public WithEvents Command2 As System.Windows.Forms.Button
    Public WithEvents Command1 As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Public WithEvents malla As System.Windows.Forms.CheckedListBox
End Class
