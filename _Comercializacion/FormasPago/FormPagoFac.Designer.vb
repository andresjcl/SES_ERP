<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFormasPago
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFormasPago))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPlanes = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.mallaCuotas = New System.Windows.Forms.DataGridView()
        Me.ValorCuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechVence = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mallaPlanes = New System.Windows.Forms.DataGridView()
        Me.descripcionPlan = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.SriFormaPagoSriPlan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValorPlan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tabcheques = New System.Windows.Forms.TabPage()
        Me.mallaCheques = New System.Windows.Forms.DataGridView()
        Me.DescripciónCheques = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.SriFormaPagoCheques = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValorCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaVence = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NroCheque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Banco = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tabtarjetas = New System.Windows.Forms.TabPage()
        Me.mallaTarjetas = New System.Windows.Forms.DataGridView()
        Me.Descripciontarjeta = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.SriFormaPagoTarjeta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValorTarjeta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlanPago = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.NroTarjeta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FinancieraTarjeta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaVenceTarjeta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabDocumentos = New System.Windows.Forms.TabPage()
        Me.mallaDocumento = New System.Windows.Forms.DataGridView()
        Me.DescripcionDocumentos = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.sriFormaPagoSriDocumentos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valorcruce = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SUC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DOC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idclavedoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodigoCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.totalDocumentos = New System.Windows.Forms.Label()
        Me.totalTarjetas = New System.Windows.Forms.Label()
        Me.totalCheques = New System.Windows.Forms.Label()
        Me.totalplan = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.totalAplicacion = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPlanes.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.mallaCuotas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mallaPlanes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tabcheques.SuspendLayout()
        CType(Me.mallaCheques, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tabtarjetas.SuspendLayout()
        CType(Me.mallaTarjetas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabDocumentos.SuspendLayout()
        CType(Me.mallaDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.TabPlanes)
        Me.TabControl1.Controls.Add(Me.Tabcheques)
        Me.TabControl1.Controls.Add(Me.Tabtarjetas)
        Me.TabControl1.Controls.Add(Me.TabDocumentos)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 24)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(762, 133)
        Me.TabControl1.TabIndex = 0
        '
        'TabPlanes
        '
        Me.TabPlanes.Controls.Add(Me.Panel2)
        Me.TabPlanes.Controls.Add(Me.mallaPlanes)
        Me.TabPlanes.Location = New System.Drawing.Point(4, 28)
        Me.TabPlanes.Name = "TabPlanes"
        Me.TabPlanes.Padding = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.TabPlanes.Size = New System.Drawing.Size(754, 101)
        Me.TabPlanes.TabIndex = 1
        Me.TabPlanes.Text = "        PlanPagos         "
        Me.TabPlanes.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.mallaCuotas)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(419, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(332, 95)
        Me.Panel2.TabIndex = 2
        '
        'mallaCuotas
        '
        Me.mallaCuotas.AllowUserToAddRows = False
        Me.mallaCuotas.AllowUserToDeleteRows = False
        Me.mallaCuotas.AllowUserToOrderColumns = True
        Me.mallaCuotas.AllowUserToResizeColumns = False
        Me.mallaCuotas.AllowUserToResizeRows = False
        Me.mallaCuotas.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.mallaCuotas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.mallaCuotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.mallaCuotas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ValorCuota, Me.FechVence})
        Me.mallaCuotas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mallaCuotas.EnableHeadersVisualStyles = False
        Me.mallaCuotas.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.mallaCuotas.Location = New System.Drawing.Point(0, 0)
        Me.mallaCuotas.MultiSelect = False
        Me.mallaCuotas.Name = "mallaCuotas"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.mallaCuotas.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.mallaCuotas.RowHeadersWidth = 51
        Me.mallaCuotas.Size = New System.Drawing.Size(332, 95)
        Me.mallaCuotas.TabIndex = 0
        '
        'ValorCuota
        '
        Me.ValorCuota.HeaderText = "ValorCuota"
        Me.ValorCuota.MinimumWidth = 6
        Me.ValorCuota.Name = "ValorCuota"
        Me.ValorCuota.Width = 125
        '
        'FechVence
        '
        Me.FechVence.HeaderText = "FechVence"
        Me.FechVence.MinimumWidth = 6
        Me.FechVence.Name = "FechVence"
        Me.FechVence.Width = 125
        '
        'mallaPlanes
        '
        Me.mallaPlanes.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.mallaPlanes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.mallaPlanes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.mallaPlanes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.descripcionPlan, Me.SriFormaPagoSriPlan, Me.ValorPlan})
        Me.mallaPlanes.Dock = System.Windows.Forms.DockStyle.Left
        Me.mallaPlanes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.mallaPlanes.EnableHeadersVisualStyles = False
        Me.mallaPlanes.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.mallaPlanes.Location = New System.Drawing.Point(3, 3)
        Me.mallaPlanes.Name = "mallaPlanes"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.mallaPlanes.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.mallaPlanes.RowHeadersWidth = 51
        Me.mallaPlanes.Size = New System.Drawing.Size(416, 95)
        Me.mallaPlanes.TabIndex = 1
        '
        'descripcionPlan
        '
        Me.descripcionPlan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.descripcionPlan.HeaderText = "Descripción"
        Me.descripcionPlan.MinimumWidth = 6
        Me.descripcionPlan.Name = "descripcionPlan"
        Me.descripcionPlan.Width = 125
        '
        'SriFormaPagoSriPlan
        '
        Me.SriFormaPagoSriPlan.HeaderText = "SRI"
        Me.SriFormaPagoSriPlan.MinimumWidth = 6
        Me.SriFormaPagoSriPlan.Name = "SriFormaPagoSriPlan"
        Me.SriFormaPagoSriPlan.Width = 125
        '
        'ValorPlan
        '
        Me.ValorPlan.HeaderText = "ValorPlan"
        Me.ValorPlan.MinimumWidth = 6
        Me.ValorPlan.Name = "ValorPlan"
        Me.ValorPlan.Width = 125
        '
        'Tabcheques
        '
        Me.Tabcheques.Controls.Add(Me.mallaCheques)
        Me.Tabcheques.Location = New System.Drawing.Point(4, 28)
        Me.Tabcheques.Name = "Tabcheques"
        Me.Tabcheques.Padding = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.Tabcheques.Size = New System.Drawing.Size(754, 101)
        Me.Tabcheques.TabIndex = 0
        Me.Tabcheques.Text = "          Cheques         "
        Me.Tabcheques.UseVisualStyleBackColor = True
        '
        'mallaCheques
        '
        Me.mallaCheques.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.mallaCheques.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.mallaCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.mallaCheques.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DescripciónCheques, Me.SriFormaPagoCheques, Me.ValorCheque, Me.FechaVence, Me.NroCheque, Me.Cuenta, Me.Banco})
        Me.mallaCheques.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mallaCheques.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.mallaCheques.EnableHeadersVisualStyles = False
        Me.mallaCheques.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.mallaCheques.Location = New System.Drawing.Point(3, 3)
        Me.mallaCheques.Name = "mallaCheques"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.mallaCheques.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.mallaCheques.RowHeadersWidth = 51
        Me.mallaCheques.Size = New System.Drawing.Size(748, 95)
        Me.mallaCheques.TabIndex = 0
        '
        'DescripciónCheques
        '
        Me.DescripciónCheques.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DescripciónCheques.HeaderText = "Descripción"
        Me.DescripciónCheques.MinimumWidth = 6
        Me.DescripciónCheques.Name = "DescripciónCheques"
        Me.DescripciónCheques.Width = 125
        '
        'SriFormaPagoCheques
        '
        Me.SriFormaPagoCheques.HeaderText = "SRI"
        Me.SriFormaPagoCheques.MinimumWidth = 6
        Me.SriFormaPagoCheques.Name = "SriFormaPagoCheques"
        Me.SriFormaPagoCheques.Width = 125
        '
        'ValorCheque
        '
        Me.ValorCheque.HeaderText = "ValorCheque"
        Me.ValorCheque.MinimumWidth = 6
        Me.ValorCheque.Name = "ValorCheque"
        Me.ValorCheque.Width = 125
        '
        'FechaVence
        '
        Me.FechaVence.HeaderText = "FechaVence"
        Me.FechaVence.MinimumWidth = 6
        Me.FechaVence.Name = "FechaVence"
        Me.FechaVence.Width = 125
        '
        'NroCheque
        '
        Me.NroCheque.HeaderText = "NroCheque"
        Me.NroCheque.MinimumWidth = 6
        Me.NroCheque.Name = "NroCheque"
        Me.NroCheque.Width = 125
        '
        'Cuenta
        '
        Me.Cuenta.HeaderText = "Cuenta"
        Me.Cuenta.MinimumWidth = 6
        Me.Cuenta.Name = "Cuenta"
        Me.Cuenta.Width = 125
        '
        'Banco
        '
        Me.Banco.HeaderText = "Banco"
        Me.Banco.MinimumWidth = 6
        Me.Banco.Name = "Banco"
        Me.Banco.Width = 125
        '
        'Tabtarjetas
        '
        Me.Tabtarjetas.Controls.Add(Me.mallaTarjetas)
        Me.Tabtarjetas.Location = New System.Drawing.Point(4, 28)
        Me.Tabtarjetas.Name = "Tabtarjetas"
        Me.Tabtarjetas.Size = New System.Drawing.Size(754, 101)
        Me.Tabtarjetas.TabIndex = 2
        Me.Tabtarjetas.Text = "   TarjetasCrédito   "
        Me.Tabtarjetas.UseVisualStyleBackColor = True
        '
        'mallaTarjetas
        '
        Me.mallaTarjetas.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.mallaTarjetas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.mallaTarjetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.mallaTarjetas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Descripciontarjeta, Me.SriFormaPagoTarjeta, Me.ValorTarjeta, Me.PlanPago, Me.NroTarjeta, Me.FinancieraTarjeta, Me.FechaVenceTarjeta})
        Me.mallaTarjetas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mallaTarjetas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.mallaTarjetas.EnableHeadersVisualStyles = False
        Me.mallaTarjetas.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.mallaTarjetas.Location = New System.Drawing.Point(0, 0)
        Me.mallaTarjetas.Name = "mallaTarjetas"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.mallaTarjetas.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.mallaTarjetas.RowHeadersWidth = 51
        Me.mallaTarjetas.Size = New System.Drawing.Size(754, 101)
        Me.mallaTarjetas.TabIndex = 1
        '
        'Descripciontarjeta
        '
        Me.Descripciontarjeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Descripciontarjeta.HeaderText = "Descripción"
        Me.Descripciontarjeta.MinimumWidth = 6
        Me.Descripciontarjeta.Name = "Descripciontarjeta"
        Me.Descripciontarjeta.Width = 125
        '
        'SriFormaPagoTarjeta
        '
        Me.SriFormaPagoTarjeta.HeaderText = "SRI"
        Me.SriFormaPagoTarjeta.MinimumWidth = 6
        Me.SriFormaPagoTarjeta.Name = "SriFormaPagoTarjeta"
        Me.SriFormaPagoTarjeta.Width = 125
        '
        'ValorTarjeta
        '
        Me.ValorTarjeta.HeaderText = "ValorTarjeta"
        Me.ValorTarjeta.MinimumWidth = 6
        Me.ValorTarjeta.Name = "ValorTarjeta"
        Me.ValorTarjeta.Width = 125
        '
        'PlanPago
        '
        Me.PlanPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PlanPago.HeaderText = "PlanPago"
        Me.PlanPago.MinimumWidth = 6
        Me.PlanPago.Name = "PlanPago"
        Me.PlanPago.Width = 125
        '
        'NroTarjeta
        '
        Me.NroTarjeta.HeaderText = "NroTarjeta"
        Me.NroTarjeta.MinimumWidth = 6
        Me.NroTarjeta.Name = "NroTarjeta"
        Me.NroTarjeta.Width = 125
        '
        'FinancieraTarjeta
        '
        Me.FinancieraTarjeta.HeaderText = "Financiera"
        Me.FinancieraTarjeta.MinimumWidth = 6
        Me.FinancieraTarjeta.Name = "FinancieraTarjeta"
        Me.FinancieraTarjeta.Width = 125
        '
        'FechaVenceTarjeta
        '
        Me.FechaVenceTarjeta.HeaderText = "FechaVence"
        Me.FechaVenceTarjeta.MinimumWidth = 6
        Me.FechaVenceTarjeta.Name = "FechaVenceTarjeta"
        Me.FechaVenceTarjeta.Visible = False
        Me.FechaVenceTarjeta.Width = 125
        '
        'TabDocumentos
        '
        Me.TabDocumentos.Controls.Add(Me.mallaDocumento)
        Me.TabDocumentos.Location = New System.Drawing.Point(4, 28)
        Me.TabDocumentos.Name = "TabDocumentos"
        Me.TabDocumentos.Size = New System.Drawing.Size(754, 101)
        Me.TabDocumentos.TabIndex = 3
        Me.TabDocumentos.Text = "CruceDocumentos"
        Me.TabDocumentos.UseVisualStyleBackColor = True
        '
        'mallaDocumento
        '
        Me.mallaDocumento.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.mallaDocumento.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.mallaDocumento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.mallaDocumento.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DescripcionDocumentos, Me.sriFormaPagoSriDocumentos, Me.valorcruce, Me.SUC, Me.DOC, Me.Numero, Me.nombre, Me.idclavedoc, Me.CodigoCliente})
        Me.mallaDocumento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mallaDocumento.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.mallaDocumento.EnableHeadersVisualStyles = False
        Me.mallaDocumento.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.mallaDocumento.Location = New System.Drawing.Point(0, 0)
        Me.mallaDocumento.Name = "mallaDocumento"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.mallaDocumento.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.mallaDocumento.RowHeadersWidth = 51
        Me.mallaDocumento.Size = New System.Drawing.Size(754, 101)
        Me.mallaDocumento.TabIndex = 2
        '
        'DescripcionDocumentos
        '
        Me.DescripcionDocumentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DescripcionDocumentos.HeaderText = "Descripción"
        Me.DescripcionDocumentos.MinimumWidth = 6
        Me.DescripcionDocumentos.Name = "DescripcionDocumentos"
        Me.DescripcionDocumentos.Width = 125
        '
        'sriFormaPagoSriDocumentos
        '
        Me.sriFormaPagoSriDocumentos.HeaderText = "SRI"
        Me.sriFormaPagoSriDocumentos.MinimumWidth = 6
        Me.sriFormaPagoSriDocumentos.Name = "sriFormaPagoSriDocumentos"
        Me.sriFormaPagoSriDocumentos.Width = 125
        '
        'valorcruce
        '
        Me.valorcruce.HeaderText = "ValorCruce"
        Me.valorcruce.MinimumWidth = 6
        Me.valorcruce.Name = "valorcruce"
        Me.valorcruce.Width = 125
        '
        'SUC
        '
        Me.SUC.HeaderText = "SUC"
        Me.SUC.MinimumWidth = 6
        Me.SUC.Name = "SUC"
        Me.SUC.Width = 125
        '
        'DOC
        '
        Me.DOC.HeaderText = "DOC"
        Me.DOC.MinimumWidth = 6
        Me.DOC.Name = "DOC"
        Me.DOC.Width = 125
        '
        'Numero
        '
        Me.Numero.HeaderText = "Numero"
        Me.Numero.MinimumWidth = 6
        Me.Numero.Name = "Numero"
        Me.Numero.Width = 125
        '
        'nombre
        '
        Me.nombre.HeaderText = "Nombre"
        Me.nombre.MinimumWidth = 6
        Me.nombre.Name = "nombre"
        Me.nombre.ReadOnly = True
        Me.nombre.Width = 125
        '
        'idclavedoc
        '
        Me.idclavedoc.HeaderText = "idclavedoc"
        Me.idclavedoc.MinimumWidth = 6
        Me.idclavedoc.Name = "idclavedoc"
        Me.idclavedoc.ReadOnly = True
        Me.idclavedoc.Visible = False
        Me.idclavedoc.Width = 125
        '
        'CodigoCliente
        '
        Me.CodigoCliente.HeaderText = "CodigoCliente"
        Me.CodigoCliente.MinimumWidth = 6
        Me.CodigoCliente.Name = "CodigoCliente"
        Me.CodigoCliente.Visible = False
        Me.CodigoCliente.Width = 125
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DimGray
        Me.Panel1.Controls.Add(Me.totalDocumentos)
        Me.Panel1.Controls.Add(Me.totalTarjetas)
        Me.Panel1.Controls.Add(Me.totalCheques)
        Me.Panel1.Controls.Add(Me.totalplan)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(762, 24)
        Me.Panel1.TabIndex = 1
        '
        'totalDocumentos
        '
        Me.totalDocumentos.BackColor = System.Drawing.Color.Transparent
        Me.totalDocumentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.totalDocumentos.ForeColor = System.Drawing.Color.Black
        Me.totalDocumentos.Location = New System.Drawing.Point(402, 4)
        Me.totalDocumentos.Name = "totalDocumentos"
        Me.totalDocumentos.Size = New System.Drawing.Size(115, 15)
        Me.totalDocumentos.TabIndex = 3
        Me.totalDocumentos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'totalTarjetas
        '
        Me.totalTarjetas.BackColor = System.Drawing.Color.Transparent
        Me.totalTarjetas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.totalTarjetas.ForeColor = System.Drawing.Color.Black
        Me.totalTarjetas.Location = New System.Drawing.Point(269, 4)
        Me.totalTarjetas.Name = "totalTarjetas"
        Me.totalTarjetas.Size = New System.Drawing.Size(115, 15)
        Me.totalTarjetas.TabIndex = 2
        Me.totalTarjetas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'totalCheques
        '
        Me.totalCheques.BackColor = System.Drawing.Color.Transparent
        Me.totalCheques.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.totalCheques.ForeColor = System.Drawing.Color.Black
        Me.totalCheques.Location = New System.Drawing.Point(136, 4)
        Me.totalCheques.Name = "totalCheques"
        Me.totalCheques.Size = New System.Drawing.Size(115, 15)
        Me.totalCheques.TabIndex = 1
        Me.totalCheques.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'totalplan
        '
        Me.totalplan.BackColor = System.Drawing.Color.Transparent
        Me.totalplan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.totalplan.ForeColor = System.Drawing.Color.Black
        Me.totalplan.Location = New System.Drawing.Point(4, 4)
        Me.totalplan.Name = "totalplan"
        Me.totalplan.Size = New System.Drawing.Size(115, 15)
        Me.totalplan.TabIndex = 0
        Me.totalplan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DimGray
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Controls.Add(Me.btnCancelar)
        Me.Panel3.Controls.Add(Me.btnAceptar)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.totalAplicacion)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 157)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(762, 28)
        Me.Panel3.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(465, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(95, 21)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "&BorrarPagos"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCancelar.FlatAppearance.BorderSize = 0
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.ForeColor = System.Drawing.Color.White
        Me.btnCancelar.Location = New System.Drawing.Point(564, 3)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(95, 21)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnAceptar.FlatAppearance.BorderSize = 0
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAceptar.ForeColor = System.Drawing.Color.White
        Me.btnAceptar.Location = New System.Drawing.Point(662, 3)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(95, 21)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(198, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Total pagos"
        '
        'totalAplicacion
        '
        Me.totalAplicacion.BackColor = System.Drawing.Color.White
        Me.totalAplicacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.totalAplicacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.totalAplicacion.ForeColor = System.Drawing.Color.Black
        Me.totalAplicacion.Location = New System.Drawing.Point(264, 2)
        Me.totalAplicacion.Name = "totalAplicacion"
        Me.totalAplicacion.Size = New System.Drawing.Size(134, 23)
        Me.totalAplicacion.TabIndex = 4
        Me.totalAplicacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmFormasPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(762, 185)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "frmFormasPago"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REGISTRO FORMA DE PAGO EN DOCUMENTOS"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPlanes.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.mallaCuotas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mallaPlanes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tabcheques.ResumeLayout(False)
        CType(Me.mallaCheques, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tabtarjetas.ResumeLayout(False)
        CType(Me.mallaTarjetas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabDocumentos.ResumeLayout(False)
        CType(Me.mallaDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Tabcheques As System.Windows.Forms.TabPage
    Friend WithEvents mallaCheques As System.Windows.Forms.DataGridView
    Friend WithEvents TabPlanes As System.Windows.Forms.TabPage
    Friend WithEvents Tabtarjetas As System.Windows.Forms.TabPage
    Friend WithEvents TabDocumentos As System.Windows.Forms.TabPage
    Friend WithEvents mallaTarjetas As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents mallaPlanes As System.Windows.Forms.DataGridView
    Friend WithEvents mallaDocumento As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents mallaCuotas As System.Windows.Forms.DataGridView
    Friend WithEvents ValorCuota As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechVence As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents totalplan As System.Windows.Forms.Label
    Friend WithEvents totalCheques As System.Windows.Forms.Label
    Friend WithEvents totalDocumentos As System.Windows.Forms.Label
    Friend WithEvents totalTarjetas As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents totalAplicacion As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Descripciontarjeta As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents SriFormaPagoTarjeta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValorTarjeta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlanPago As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents NroTarjeta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FinancieraTarjeta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaVenceTarjeta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descripcionPlan As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents SriFormaPagoSriPlan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValorPlan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripciónCheques As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents SriFormaPagoCheques As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValorCheque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaVence As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NroCheque As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Banco As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionDocumentos As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents sriFormaPagoSriDocumentos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valorcruce As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SUC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DOC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idclavedoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodigoCliente As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
