<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class repAntig
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(repAntig))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.txtFecha = New System.Windows.Forms.DateTimePicker()
        Me.ArticulosGrupos = New System.Windows.Forms.GroupBox()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.btnCodFin = New System.Windows.Forms.Button()
        Me.txtCodFin = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnCodIni = New System.Windows.Forms.Button()
        Me.txtcodIni = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkSubg = New System.Windows.Forms.CheckBox()
        Me.chkGrupo = New System.Windows.Forms.CheckBox()
        Me.chkClase = New System.Windows.Forms.CheckBox()
        Me.chkCategoria = New System.Windows.Forms.CheckBox()
        Me.cboSubg = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboClase = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboCategoria = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Orden = New System.Windows.Forms.CheckBox()
        Me.chkArtExis = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.label10 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnOpciones = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Actualizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cboBodega = New System.Windows.Forms.ComboBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ArticulosGrupos.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 38)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtFecha)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ArticulosGrupos)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Orden)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkArtExis)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1MinSize = 20
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ReportViewer1)
        Me.SplitContainer1.Size = New System.Drawing.Size(770, 519)
        Me.SplitContainer1.SplitterDistance = 300
        Me.SplitContainer1.TabIndex = 12
        '
        'txtFecha
        '
        Me.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFecha.Location = New System.Drawing.Point(78, 7)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(101, 20)
        Me.txtFecha.TabIndex = 53
        '
        'ArticulosGrupos
        '
        Me.ArticulosGrupos.Controls.Add(Me.cboGrupo)
        Me.ArticulosGrupos.Controls.Add(Me.btnCodFin)
        Me.ArticulosGrupos.Controls.Add(Me.txtCodFin)
        Me.ArticulosGrupos.Controls.Add(Me.Label8)
        Me.ArticulosGrupos.Controls.Add(Me.btnCodIni)
        Me.ArticulosGrupos.Controls.Add(Me.txtcodIni)
        Me.ArticulosGrupos.Controls.Add(Me.Label7)
        Me.ArticulosGrupos.Controls.Add(Me.chkSubg)
        Me.ArticulosGrupos.Controls.Add(Me.chkGrupo)
        Me.ArticulosGrupos.Controls.Add(Me.chkClase)
        Me.ArticulosGrupos.Controls.Add(Me.chkCategoria)
        Me.ArticulosGrupos.Controls.Add(Me.cboSubg)
        Me.ArticulosGrupos.Controls.Add(Me.Label6)
        Me.ArticulosGrupos.Controls.Add(Me.Label5)
        Me.ArticulosGrupos.Controls.Add(Me.cboClase)
        Me.ArticulosGrupos.Controls.Add(Me.Label4)
        Me.ArticulosGrupos.Controls.Add(Me.cboCategoria)
        Me.ArticulosGrupos.Controls.Add(Me.Label3)
        Me.ArticulosGrupos.Location = New System.Drawing.Point(3, 133)
        Me.ArticulosGrupos.Name = "ArticulosGrupos"
        Me.ArticulosGrupos.Size = New System.Drawing.Size(287, 166)
        Me.ArticulosGrupos.TabIndex = 51
        Me.ArticulosGrupos.TabStop = False
        Me.ArticulosGrupos.Text = "Opciones de selección de artículos"
        '
        'cboGrupo
        '
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Location = New System.Drawing.Point(62, 62)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(157, 21)
        Me.cboGrupo.TabIndex = 24
        '
        'btnCodFin
        '
        Me.btnCodFin.Location = New System.Drawing.Point(217, 130)
        Me.btnCodFin.Name = "btnCodFin"
        Me.btnCodFin.Size = New System.Drawing.Size(21, 21)
        Me.btnCodFin.TabIndex = 36
        Me.btnCodFin.Text = "..."
        Me.btnCodFin.UseVisualStyleBackColor = True
        '
        'txtCodFin
        '
        Me.txtCodFin.Location = New System.Drawing.Point(63, 130)
        Me.txtCodFin.Name = "txtCodFin"
        Me.txtCodFin.Size = New System.Drawing.Size(155, 20)
        Me.txtCodFin.TabIndex = 35
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 133)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 13)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Final:"
        '
        'btnCodIni
        '
        Me.btnCodIni.Location = New System.Drawing.Point(216, 107)
        Me.btnCodIni.Name = "btnCodIni"
        Me.btnCodIni.Size = New System.Drawing.Size(21, 21)
        Me.btnCodIni.TabIndex = 33
        Me.btnCodIni.Text = "..."
        Me.btnCodIni.UseVisualStyleBackColor = True
        '
        'txtcodIni
        '
        Me.txtcodIni.Location = New System.Drawing.Point(63, 107)
        Me.txtcodIni.Name = "txtcodIni"
        Me.txtcodIni.Size = New System.Drawing.Size(155, 20)
        Me.txtcodIni.TabIndex = 32
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 110)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "Inicial:"
        '
        'chkSubg
        '
        Me.chkSubg.AutoSize = True
        Me.chkSubg.Location = New System.Drawing.Point(225, 87)
        Me.chkSubg.Name = "chkSubg"
        Me.chkSubg.Size = New System.Drawing.Size(60, 17)
        Me.chkSubg.TabIndex = 30
        Me.chkSubg.Text = "Agrupa"
        Me.chkSubg.UseVisualStyleBackColor = True
        '
        'chkGrupo
        '
        Me.chkGrupo.AutoSize = True
        Me.chkGrupo.Location = New System.Drawing.Point(225, 65)
        Me.chkGrupo.Name = "chkGrupo"
        Me.chkGrupo.Size = New System.Drawing.Size(60, 17)
        Me.chkGrupo.TabIndex = 29
        Me.chkGrupo.Text = "Agrupa"
        Me.chkGrupo.UseVisualStyleBackColor = True
        '
        'chkClase
        '
        Me.chkClase.AutoSize = True
        Me.chkClase.Location = New System.Drawing.Point(225, 42)
        Me.chkClase.Name = "chkClase"
        Me.chkClase.Size = New System.Drawing.Size(60, 17)
        Me.chkClase.TabIndex = 28
        Me.chkClase.Text = "Agrupa"
        Me.chkClase.UseVisualStyleBackColor = True
        '
        'chkCategoria
        '
        Me.chkCategoria.AutoSize = True
        Me.chkCategoria.Location = New System.Drawing.Point(225, 20)
        Me.chkCategoria.Name = "chkCategoria"
        Me.chkCategoria.Size = New System.Drawing.Size(60, 17)
        Me.chkCategoria.TabIndex = 27
        Me.chkCategoria.Text = "Agrupa"
        Me.chkCategoria.UseVisualStyleBackColor = True
        '
        'cboSubg
        '
        Me.cboSubg.FormattingEnabled = True
        Me.cboSubg.Location = New System.Drawing.Point(62, 84)
        Me.cboSubg.Name = "cboSubg"
        Me.cboSubg.Size = New System.Drawing.Size(157, 21)
        Me.cboSubg.TabIndex = 26
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 87)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Subgrupo:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Grupo:"
        '
        'cboClase
        '
        Me.cboClase.FormattingEnabled = True
        Me.cboClase.Location = New System.Drawing.Point(62, 40)
        Me.cboClase.Name = "cboClase"
        Me.cboClase.Size = New System.Drawing.Size(157, 21)
        Me.cboClase.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Clase:"
        '
        'cboCategoria
        '
        Me.cboCategoria.FormattingEnabled = True
        Me.cboCategoria.Location = New System.Drawing.Point(62, 18)
        Me.cboCategoria.Name = "cboCategoria"
        Me.cboCategoria.Size = New System.Drawing.Size(157, 21)
        Me.cboCategoria.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Categoria:"
        '
        'Orden
        '
        Me.Orden.AutoSize = True
        Me.Orden.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Orden.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Orden.Location = New System.Drawing.Point(47, 64)
        Me.Orden.Name = "Orden"
        Me.Orden.Size = New System.Drawing.Size(142, 17)
        Me.Orden.TabIndex = 49
        Me.Orden.Text = "Ordenar alfabeticamente"
        Me.Orden.UseVisualStyleBackColor = True
        '
        'chkArtExis
        '
        Me.chkArtExis.AutoSize = True
        Me.chkArtExis.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkArtExis.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.chkArtExis.Location = New System.Drawing.Point(46, 48)
        Me.chkArtExis.Name = "chkArtExis"
        Me.chkArtExis.Size = New System.Drawing.Size(168, 17)
        Me.chkArtExis.TabIndex = 45
        Me.chkArtExis.Text = "Incluir artículos sin Existencia:"
        Me.chkArtExis.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "A la Fecha:"
        '
        'ReportViewer1
        '
        Me.ReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(466, 519)
        Me.ReportViewer1.TabIndex = 1
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.BackColor = System.Drawing.Color.LightSteelBlue
        Me.label10.Location = New System.Drawing.Point(404, 15)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(47, 13)
        Me.label10.TabIndex = 13
        Me.label10.Text = "Bodega:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(407, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Bodega:"
        '
        'btnOpciones
        '
        Me.btnOpciones.CheckOnClick = True
        Me.btnOpciones.Image = CType(resources.GetObject("btnOpciones.Image"), System.Drawing.Image)
        Me.btnOpciones.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOpciones.Name = "btnOpciones"
        Me.btnOpciones.Size = New System.Drawing.Size(61, 35)
        Me.btnOpciones.Text = "Opciones"
        Me.btnOpciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 38)
        '
        'Actualizar
        '
        Me.Actualizar.Checked = True
        Me.Actualizar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Actualizar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Actualizar.Image = CType(resources.GetObject("Actualizar.Image"), System.Drawing.Image)
        Me.Actualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Actualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Actualizar.Name = "Actualizar"
        Me.Actualizar.Size = New System.Drawing.Size(52, 35)
        Me.Actualizar.Text = "Generar"
        Me.Actualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Actualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 38)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOpciones, Me.ToolStripSeparator2, Me.Actualizar, Me.ToolStripSeparator4, Me.btnSalir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(770, 38)
        Me.ToolStrip1.TabIndex = 11
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnSalir
        '
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(33, 35)
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'cboBodega
        '
        Me.cboBodega.FormattingEnabled = True
        Me.cboBodega.Location = New System.Drawing.Point(457, 11)
        Me.cboBodega.Name = "cboBodega"
        Me.cboBodega.Size = New System.Drawing.Size(163, 21)
        Me.cboBodega.TabIndex = 10
        '
        'repAntig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(770, 557)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.label10)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboBodega)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "repAntig"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ANTIGÜEDAD DE PRDUCTOS EN BODEGAS"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ArticulosGrupos.ResumeLayout(False)
        Me.ArticulosGrupos.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SplitContainer1 As SplitContainer
    Private WithEvents txtFecha As DateTimePicker
    Friend WithEvents ArticulosGrupos As GroupBox
    Friend WithEvents cboGrupo As ComboBox
    Friend WithEvents btnCodFin As Button
    Friend WithEvents txtCodFin As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents btnCodIni As Button
    Friend WithEvents txtcodIni As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents chkSubg As CheckBox
    Friend WithEvents chkGrupo As CheckBox
    Friend WithEvents chkClase As CheckBox
    Friend WithEvents chkCategoria As CheckBox
    Friend WithEvents cboSubg As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cboClase As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cboCategoria As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Orden As CheckBox
    Friend WithEvents chkArtExis As CheckBox
    Friend WithEvents Label2 As Label
    Private WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents label10 As Label
    Friend WithEvents Label1 As Label
    Private WithEvents btnOpciones As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Private WithEvents Actualizar As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToolStrip1 As ToolStrip
    Private WithEvents btnSalir As ToolStripButton
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents cboBodega As ComboBox
End Class
