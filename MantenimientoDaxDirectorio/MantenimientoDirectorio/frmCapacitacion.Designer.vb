<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCapacitacion
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
        Me.NivelEstudio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LabEmpleado = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Retirado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Especializacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EnCurso = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.CursosCarrera = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Graduado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Titulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaFinal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Institucion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Pais = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.malla = New System.Windows.Forms.DataGridView()
        Me.CursosAprobados = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.malla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NivelEstudio
        '
        Me.NivelEstudio.HeaderText = "Nivel Estudio"
        Me.NivelEstudio.Name = "NivelEstudio"
        Me.NivelEstudio.Width = 87
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DimGray
        Me.Panel1.Controls.Add(Me.LabEmpleado)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(936, 43)
        Me.Panel1.TabIndex = 3
        '
        'LabEmpleado
        '
        Me.LabEmpleado.BackColor = System.Drawing.SystemColors.Window
        Me.LabEmpleado.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabEmpleado.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabEmpleado.Location = New System.Drawing.Point(68, 13)
        Me.LabEmpleado.Name = "LabEmpleado"
        Me.LabEmpleado.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabEmpleado.Size = New System.Drawing.Size(569, 17)
        Me.LabEmpleado.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(5, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(65, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Empleado:"
        '
        'Retirado
        '
        Me.Retirado.HeaderText = "Retirado"
        Me.Retirado.Name = "Retirado"
        Me.Retirado.Width = 53
        '
        'Especializacion
        '
        Me.Especializacion.HeaderText = "Especialización"
        Me.Especializacion.Name = "Especializacion"
        Me.Especializacion.Width = 105
        '
        'EnCurso
        '
        Me.EnCurso.HeaderText = "En Curso"
        Me.EnCurso.Name = "EnCurso"
        Me.EnCurso.Width = 50
        '
        'CursosCarrera
        '
        Me.CursosCarrera.HeaderText = "Cursos de la Carrerra"
        Me.CursosCarrera.Name = "CursosCarrera"
        Me.CursosCarrera.Width = 86
        '
        'Graduado
        '
        Me.Graduado.HeaderText = "Graduado"
        Me.Graduado.Name = "Graduado"
        Me.Graduado.Width = 60
        '
        'Titulo
        '
        Me.Titulo.HeaderText = "Título"
        Me.Titulo.Name = "Titulo"
        Me.Titulo.Width = 60
        '
        'FechaFinal
        '
        Me.FechaFinal.HeaderText = "Fecha Final"
        Me.FechaFinal.Name = "FechaFinal"
        Me.FechaFinal.Width = 80
        '
        'Institucion
        '
        Me.Institucion.HeaderText = "Institución"
        Me.Institucion.Name = "Institucion"
        Me.Institucion.Width = 80
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkGray
        Me.Panel2.Controls.Add(Me.btnGuardar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 300)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(936, 44)
        Me.Panel2.TabIndex = 4
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.BackColor = System.Drawing.Color.DimGray
        Me.btnGuardar.FlatAppearance.BorderSize = 0
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.ForeColor = System.Drawing.Color.White
        Me.btnGuardar.Location = New System.Drawing.Point(839, 9)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(89, 27)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'Pais
        '
        Me.Pais.HeaderText = "País"
        Me.Pais.Name = "Pais"
        Me.Pais.Width = 54
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.malla)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 43)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(936, 301)
        Me.Panel3.TabIndex = 5
        '
        'malla
        '
        Me.malla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.malla.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.malla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.malla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.malla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Pais, Me.Institucion, Me.Titulo, Me.Especializacion, Me.NivelEstudio, Me.Retirado, Me.EnCurso, Me.Graduado, Me.FechaFinal, Me.CursosCarrera, Me.CursosAprobados})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.malla.DefaultCellStyle = DataGridViewCellStyle2
        Me.malla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.malla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.malla.EnableHeadersVisualStyles = False
        Me.malla.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.malla.Location = New System.Drawing.Point(0, 0)
        Me.malla.Name = "malla"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.malla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.malla.RowHeadersWidth = 45
        Me.malla.Size = New System.Drawing.Size(936, 301)
        Me.malla.TabIndex = 3
        '
        'CursosAprobados
        '
        Me.CursosAprobados.HeaderText = "Cursos Aprobados"
        Me.CursosAprobados.Name = "CursosAprobados"
        Me.CursosAprobados.Width = 108
        '
        'frmCapacitacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(936, 344)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmCapacitacion"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ADCOMDAX - MANTENIMIENTO CAPACITACION DEL PERSONAL"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.malla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NivelEstudio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents LabEmpleado As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Retirado As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Especializacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EnCurso As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents CursosCarrera As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Graduado As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Titulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaFinal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Institucion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Pais As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents malla As System.Windows.Forms.DataGridView
    Friend WithEvents CursosAprobados As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
