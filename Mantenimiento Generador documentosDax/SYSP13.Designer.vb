<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class SYSP13
#Region "Código generado por el Diseñador de Windows Forms "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'Llamada necesaria para el Diseñador de Windows Forms.
		InitializeComponent()
        '		VB6_AddADODataBinding()
	End Sub
	'Form invalida a Dispose para limpiar la lista de componentes.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
            '			VB6_RemoveADODataBinding()
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Requerido por el Diseñador de Windows Forms
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
    Private ADOBind_dtCom As Collection
    Private ADOBind_dtdoc As Collection
    Public WithEvents btnabrir As System.Windows.Forms.ToolStripButton
    Public WithEvents btnguardar As System.Windows.Forms.ToolStripButton
    Public WithEvents btncerrar As System.Windows.Forms.ToolStripButton
    Public WithEvents btneliminar As System.Windows.Forms.ToolStripButton
    Public WithEvents btnsalir As System.Windows.Forms.ToolStripButton
    Public WithEvents Toolbar1 As System.Windows.Forms.ToolStrip
    Public WithEvents txtAbr As System.Windows.Forms.TextBox
    Public WithEvents txtDes As System.Windows.Forms.TextBox
    Public dgRutasOpen As System.Windows.Forms.OpenFileDialog
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label15 As System.Windows.Forms.Label
    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar mediante el Diseñador de Windows Forms.
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SYSP13))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtValVenOIvaD = New System.Windows.Forms.TextBox()
        Me.txtValVenOIvaH = New System.Windows.Forms.TextBox()
        Me.txtValTotDocD = New System.Windows.Forms.TextBox()
        Me.txtValTotDocH = New System.Windows.Forms.TextBox()
        Me.txtValVenInvD = New System.Windows.Forms.TextBox()
        Me.txtSubVenCIvaD = New System.Windows.Forms.TextBox()
        Me.txtSubVenCIvaH = New System.Windows.Forms.TextBox()
        Me.txtValDesD = New System.Windows.Forms.TextBox()
        Me.txtValDesH = New System.Windows.Forms.TextBox()
        Me.txtValNetVenD = New System.Windows.Forms.TextBox()
        Me.txtValNetVenH = New System.Windows.Forms.TextBox()
        Me.txtIvaD = New System.Windows.Forms.TextBox()
        Me.txtIvaH = New System.Windows.Forms.TextBox()
        Me.txtOtrSIvaD = New System.Windows.Forms.TextBox()
        Me.txtOtrSIvaH = New System.Windows.Forms.TextBox()
        Me.txtTotDesIndD = New System.Windows.Forms.TextBox()
        Me.txtTotDesIndH = New System.Windows.Forms.TextBox()
        Me.txtCtaCosH = New System.Windows.Forms.TextBox()
        Me.txtCtaCosD = New System.Windows.Forms.TextBox()
        Me.txtValVenInvH = New System.Windows.Forms.TextBox()
        Me.txtRetBieD = New System.Windows.Forms.TextBox()
        Me.txtRetBieH = New System.Windows.Forms.TextBox()
        Me.txtRetSerD = New System.Windows.Forms.TextBox()
        Me.txtRetSerH = New System.Windows.Forms.TextBox()
        Me.txtRetFteD = New System.Windows.Forms.TextBox()
        Me.txtRetFteH = New System.Windows.Forms.TextBox()
        Me.txtRetFte1H = New System.Windows.Forms.TextBox()
        Me.txtRetFte1D = New System.Windows.Forms.TextBox()
        Me.txtRetFte2H = New System.Windows.Forms.TextBox()
        Me.txtRetFte2D = New System.Windows.Forms.TextBox()
        Me.OpCosLiq = New System.Windows.Forms.RadioButton()
        Me.Toolbar1 = New System.Windows.Forms.ToolStrip()
        Me.btnnuevo = New System.Windows.Forms.ToolStripButton()
        Me.btnabrir = New System.Windows.Forms.ToolStripButton()
        Me.btncerrar = New System.Windows.Forms.ToolStripButton()
        Me.btnguardar = New System.Windows.Forms.ToolStripButton()
        Me.btneliminar = New System.Windows.Forms.ToolStripButton()
        Me.btnsalir = New System.Windows.Forms.ToolStripButton()
        Me.txtAbr = New System.Windows.Forms.TextBox()
        Me.txtDes = New System.Windows.Forms.TextBox()
        Me.dgRutasOpen = New System.Windows.Forms.OpenFileDialog()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.LabGeneral = New System.Windows.Forms.Label()
        Me.LabInventario = New System.Windows.Forms.Label()
        Me.LabContabilidad = New System.Windows.Forms.Label()
        Me.TabGeneral = New System.Windows.Forms.GroupBox()
        Me.txtFormulasPVP = New System.Windows.Forms.TextBox()
        Me.btnBuscaFormulaPVP = New System.Windows.Forms.Button()
        Me.ComandoSQL = New System.Windows.Forms.TextBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Command8 = New System.Windows.Forms.Button()
        Me.BtnDocSop = New System.Windows.Forms.Button()
        Me.TxtTipSop = New System.Windows.Forms.TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.LbNomSoporte = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.frFac = New System.Windows.Forms.GroupBox()
        Me.chFacSer = New System.Windows.Forms.CheckBox()
        Me.chFacArt = New System.Windows.Forms.CheckBox()
        Me.chFacAcf = New System.Windows.Forms.CheckBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.chkElectronico = New System.Windows.Forms.CheckBox()
        Me.chkRegistraImportaciones = New System.Windows.Forms.CheckBox()
        Me.chkNoBajoCosto = New System.Windows.Forms.CheckBox()
        Me.frImpFor = New System.Windows.Forms.GroupBox()
        Me.chkImprimirRIDE = New System.Windows.Forms.RadioButton()
        Me.chkImprimirTicket = New System.Windows.Forms.RadioButton()
        Me.btnFormatoElec = New System.Windows.Forms.Button()
        Me.FormatoElec = New System.Windows.Forms.TextBox()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.btnFormatoCtb = New System.Windows.Forms.Button()
        Me.FormatoCtb = New System.Windows.Forms.TextBox()
        Me.opImpForNin = New System.Windows.Forms.RadioButton()
        Me.opImpForGen = New System.Windows.Forms.RadioButton()
        Me.txtFormato = New System.Windows.Forms.TextBox()
        Me.btnFormatoGeneral = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TipoComprobanteSri = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Check8 = New System.Windows.Forms.CheckBox()
        Me.dbDoc = New System.Windows.Forms.ComboBox()
        Me.ChGenTipGas = New System.Windows.Forms.CheckBox()
        Me.Chpuedeconsolidar = New System.Windows.Forms.CheckBox()
        Me.chRefAcf = New System.Windows.Forms.CheckBox()
        Me.fImpuestos = New System.Windows.Forms.GroupBox()
        Me.ChImp2 = New System.Windows.Forms.CheckBox()
        Me.ChImp1 = New System.Windows.Forms.CheckBox()
        Me.ChImp3 = New System.Windows.Forms.CheckBox()
        Me.chImp4 = New System.Windows.Forms.CheckBox()
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me.Command3 = New System.Windows.Forms.Button()
        Me.Command2 = New System.Windows.Forms.Button()
        Me.Command1 = New System.Windows.Forms.Button()
        Me.Impresora_1 = New System.Windows.Forms.TextBox()
        Me.Impresora_2 = New System.Windows.Forms.TextBox()
        Me.Impresora_3 = New System.Windows.Forms.TextBox()
        Me.BtRut3 = New System.Windows.Forms.Button()
        Me.FormatoAux1 = New System.Windows.Forms.TextBox()
        Me.BtRut4 = New System.Windows.Forms.Button()
        Me.FormatoAux2 = New System.Windows.Forms.TextBox()
        Me.BtRut5 = New System.Windows.Forms.Button()
        Me.FormatoAux3 = New System.Windows.Forms.TextBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Frame4 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ChkNumerar = New System.Windows.Forms.CheckBox()
        Me.Check3 = New System.Windows.Forms.CheckBox()
        Me.Check5 = New System.Windows.Forms.CheckBox()
        Me.Check6 = New System.Windows.Forms.CheckBox()
        Me.Check7 = New System.Windows.Forms.CheckBox()
        Me.chRefInv = New System.Windows.Forms.CheckBox()
        Me.chRefCon = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabDatos = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Frame5 = New System.Windows.Forms.GroupBox()
        Me.ListItems = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ListCabecera = New System.Windows.Forms.CheckedListBox()
        Me.TabInventario = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ComboDoc1 = New System.Windows.Forms.ComboBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.GeneraSalidaMP = New System.Windows.Forms.CheckBox()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.CmbClasificadorCosteo = New System.Windows.Forms.ComboBox()
        Me.OpCosLiqClas = New System.Windows.Forms.RadioButton()
        Me.opCosNin = New System.Windows.Forms.RadioButton()
        Me.opCosDig = New System.Windows.Forms.RadioButton()
        Me.opCosUlt = New System.Windows.Forms.RadioButton()
        Me.opCosPro = New System.Windows.Forms.RadioButton()
        Me.chGenSinExi = New System.Windows.Forms.CheckBox()
        Me.chRepCodFil = New System.Windows.Forms.CheckBox()
        Me.chGuaUltCom = New System.Windows.Forms.CheckBox()
        Me.RegistraCantCero = New System.Windows.Forms.CheckBox()
        Me.TabContabilidad = New System.Windows.Forms.GroupBox()
        Me.chKNoEnLinea = New System.Windows.Forms.CheckBox()
        Me.ChkCdreNOUSADO = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lbValVtaOIva = New System.Windows.Forms.Label()
        Me.Text1 = New System.Windows.Forms.TextBox()
        Me.ChkCdreTotal = New System.Windows.Forms.TextBox()
        Me.Reconta = New System.Windows.Forms.CheckBox()
        Me.frConInd = New System.Windows.Forms.GroupBox()
        Me.chOtrSIva = New System.Windows.Forms.CheckBox()
        Me.chOtrCIva = New System.Windows.Forms.CheckBox()
        Me.chDes = New System.Windows.Forms.CheckBox()
        Me.chArt = New System.Windows.Forms.CheckBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.FrmSri = New System.Windows.Forms.Panel()
        Me.ChkCdreRetFte2 = New System.Windows.Forms.TextBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.ChkCdreRetFte1 = New System.Windows.Forms.TextBox()
        Me.ChkCdreRetFte = New System.Windows.Forms.TextBox()
        Me.ChkCdreRetIvaServ = New System.Windows.Forms.TextBox()
        Me.ChkCdreRetIvaBien = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.FrmOtros = New System.Windows.Forms.Panel()
        Me.ChkCdreCostoArticulos = New System.Windows.Forms.TextBox()
        Me.ChkCdreImpuestos = New System.Windows.Forms.TextBox()
        Me.ChkCdreDescuentosServicios = New System.Windows.Forms.TextBox()
        Me.ChkCdreDescuentoArticulos = New System.Windows.Forms.TextBox()
        Me.ChkCdreActivos = New System.Windows.Forms.TextBox()
        Me.ChkCdreNOUTILIZADO2 = New System.Windows.Forms.TextBox()
        Me.ChkCdreConceptos = New System.Windows.Forms.TextBox()
        Me.ChkCdreArticulos = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.LbValVtaInv = New System.Windows.Forms.Label()
        Me.lbSubVtaCIva = New System.Windows.Forms.Label()
        Me.lbValDes = New System.Windows.Forms.Label()
        Me.lbValNetoVta = New System.Windows.Forms.Label()
        Me.lbIva = New System.Windows.Forms.Label()
        Me.LbOtrSIva = New System.Windows.Forms.Label()
        Me.lbTotDesInd = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chGenComDes = New System.Windows.Forms.CheckBox()
        Me.LabDatos = New System.Windows.Forms.Label()
        Me.Numeracion = New System.Windows.Forms.Button()
        Me.impresora = New System.Windows.Forms.PrintDialog()
        Me.Toolbar1.SuspendLayout()
        Me.TabGeneral.SuspendLayout()
        Me.frFac.SuspendLayout()
        Me.frImpFor.SuspendLayout()
        Me.fImpuestos.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me.Frame4.SuspendLayout()
        Me.TabDatos.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Frame5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabInventario.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.TabContabilidad.SuspendLayout()
        Me.frConInd.SuspendLayout()
        Me.FrmSri.SuspendLayout()
        Me.FrmOtros.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolTip1
        '
        Me.ToolTip1.BackColor = System.Drawing.Color.LightSteelBlue
        '
        'txtValVenOIvaD
        '
        Me.txtValVenOIvaD.AcceptsReturn = True
        Me.txtValVenOIvaD.BackColor = System.Drawing.SystemColors.Window
        Me.txtValVenOIvaD.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValVenOIvaD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtValVenOIvaD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtValVenOIvaD.Location = New System.Drawing.Point(208, 132)
        Me.txtValVenOIvaD.Margin = New System.Windows.Forms.Padding(4)
        Me.txtValVenOIvaD.MaxLength = 30
        Me.txtValVenOIvaD.Name = "txtValVenOIvaD"
        Me.txtValVenOIvaD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtValVenOIvaD.Size = New System.Drawing.Size(147, 15)
        Me.txtValVenOIvaD.TabIndex = 305
        Me.ToolTip1.SetToolTip(Me.txtValVenOIvaD, "Presione F2 para buscar la cuenta contable o el comodin")
        Me.txtValVenOIvaD.Visible = False
        '
        'txtValVenOIvaH
        '
        Me.txtValVenOIvaH.AcceptsReturn = True
        Me.txtValVenOIvaH.BackColor = System.Drawing.SystemColors.Window
        Me.txtValVenOIvaH.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValVenOIvaH.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtValVenOIvaH.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtValVenOIvaH.Location = New System.Drawing.Point(613, 132)
        Me.txtValVenOIvaH.Margin = New System.Windows.Forms.Padding(4)
        Me.txtValVenOIvaH.MaxLength = 30
        Me.txtValVenOIvaH.Name = "txtValVenOIvaH"
        Me.txtValVenOIvaH.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtValVenOIvaH.Size = New System.Drawing.Size(147, 15)
        Me.txtValVenOIvaH.TabIndex = 304
        Me.ToolTip1.SetToolTip(Me.txtValVenOIvaH, "Presione F2 para buscar la cuenta contable o el comodin")
        Me.txtValVenOIvaH.Visible = False
        '
        'txtValTotDocD
        '
        Me.txtValTotDocD.AcceptsReturn = True
        Me.txtValTotDocD.BackColor = System.Drawing.SystemColors.Window
        Me.txtValTotDocD.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValTotDocD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtValTotDocD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtValTotDocD.Location = New System.Drawing.Point(208, 101)
        Me.txtValTotDocD.Margin = New System.Windows.Forms.Padding(4)
        Me.txtValTotDocD.MaxLength = 30
        Me.txtValTotDocD.Name = "txtValTotDocD"
        Me.txtValTotDocD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtValTotDocD.Size = New System.Drawing.Size(147, 15)
        Me.txtValTotDocD.TabIndex = 287
        Me.ToolTip1.SetToolTip(Me.txtValTotDocD, "Presione F2 para buscar la cuenta contable o el comodin")
        '
        'txtValTotDocH
        '
        Me.txtValTotDocH.AcceptsReturn = True
        Me.txtValTotDocH.BackColor = System.Drawing.SystemColors.Window
        Me.txtValTotDocH.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValTotDocH.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtValTotDocH.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtValTotDocH.Location = New System.Drawing.Point(613, 101)
        Me.txtValTotDocH.Margin = New System.Windows.Forms.Padding(4)
        Me.txtValTotDocH.MaxLength = 30
        Me.txtValTotDocH.Name = "txtValTotDocH"
        Me.txtValTotDocH.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtValTotDocH.Size = New System.Drawing.Size(147, 15)
        Me.txtValTotDocH.TabIndex = 286
        Me.ToolTip1.SetToolTip(Me.txtValTotDocH, "Presione F2 para buscar la cuenta contable o el comodin")
        '
        'txtValVenInvD
        '
        Me.txtValVenInvD.AcceptsReturn = True
        Me.txtValVenInvD.BackColor = System.Drawing.SystemColors.Window
        Me.txtValVenInvD.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValVenInvD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtValVenInvD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtValVenInvD.Location = New System.Drawing.Point(163, 0)
        Me.txtValVenInvD.Margin = New System.Windows.Forms.Padding(4)
        Me.txtValVenInvD.MaxLength = 30
        Me.txtValVenInvD.Name = "txtValVenInvD"
        Me.txtValVenInvD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtValVenInvD.Size = New System.Drawing.Size(147, 15)
        Me.txtValVenInvD.TabIndex = 143
        Me.ToolTip1.SetToolTip(Me.txtValVenInvD, "Presione F2 para buscar la cuenta contable o el comodin")
        '
        'txtSubVenCIvaD
        '
        Me.txtSubVenCIvaD.AcceptsReturn = True
        Me.txtSubVenCIvaD.BackColor = System.Drawing.SystemColors.Window
        Me.txtSubVenCIvaD.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSubVenCIvaD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSubVenCIvaD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSubVenCIvaD.Location = New System.Drawing.Point(164, 31)
        Me.txtSubVenCIvaD.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSubVenCIvaD.MaxLength = 30
        Me.txtSubVenCIvaD.Name = "txtSubVenCIvaD"
        Me.txtSubVenCIvaD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSubVenCIvaD.Size = New System.Drawing.Size(147, 15)
        Me.txtSubVenCIvaD.TabIndex = 136
        Me.ToolTip1.SetToolTip(Me.txtSubVenCIvaD, "Presione F2 para buscar la cuenta contable o el comodin")
        '
        'txtSubVenCIvaH
        '
        Me.txtSubVenCIvaH.AcceptsReturn = True
        Me.txtSubVenCIvaH.BackColor = System.Drawing.SystemColors.Window
        Me.txtSubVenCIvaH.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSubVenCIvaH.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSubVenCIvaH.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSubVenCIvaH.Location = New System.Drawing.Point(569, 31)
        Me.txtSubVenCIvaH.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSubVenCIvaH.MaxLength = 30
        Me.txtSubVenCIvaH.Name = "txtSubVenCIvaH"
        Me.txtSubVenCIvaH.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSubVenCIvaH.Size = New System.Drawing.Size(147, 15)
        Me.txtSubVenCIvaH.TabIndex = 135
        Me.ToolTip1.SetToolTip(Me.txtSubVenCIvaH, "Presione F2 para buscar la cuenta contable o el comodin")
        '
        'txtValDesD
        '
        Me.txtValDesD.AcceptsReturn = True
        Me.txtValDesD.BackColor = System.Drawing.SystemColors.Window
        Me.txtValDesD.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValDesD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtValDesD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtValDesD.Location = New System.Drawing.Point(164, 92)
        Me.txtValDesD.Margin = New System.Windows.Forms.Padding(4)
        Me.txtValDesD.MaxLength = 30
        Me.txtValDesD.Name = "txtValDesD"
        Me.txtValDesD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtValDesD.Size = New System.Drawing.Size(147, 15)
        Me.txtValDesD.TabIndex = 132
        Me.ToolTip1.SetToolTip(Me.txtValDesD, "Presione F2 para buscar la cuenta contable o el comodin")
        Me.txtValDesD.Visible = False
        '
        'txtValDesH
        '
        Me.txtValDesH.AcceptsReturn = True
        Me.txtValDesH.BackColor = System.Drawing.SystemColors.Window
        Me.txtValDesH.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValDesH.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtValDesH.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtValDesH.Location = New System.Drawing.Point(571, 92)
        Me.txtValDesH.Margin = New System.Windows.Forms.Padding(4)
        Me.txtValDesH.MaxLength = 30
        Me.txtValDesH.Name = "txtValDesH"
        Me.txtValDesH.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtValDesH.Size = New System.Drawing.Size(147, 15)
        Me.txtValDesH.TabIndex = 131
        Me.ToolTip1.SetToolTip(Me.txtValDesH, "Presione F2 para buscar la cuenta contable o el comodin")
        Me.txtValDesH.Visible = False
        '
        'txtValNetVenD
        '
        Me.txtValNetVenD.AcceptsReturn = True
        Me.txtValNetVenD.BackColor = System.Drawing.SystemColors.Window
        Me.txtValNetVenD.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValNetVenD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtValNetVenD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtValNetVenD.Location = New System.Drawing.Point(164, 62)
        Me.txtValNetVenD.Margin = New System.Windows.Forms.Padding(4)
        Me.txtValNetVenD.MaxLength = 30
        Me.txtValNetVenD.Name = "txtValNetVenD"
        Me.txtValNetVenD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtValNetVenD.Size = New System.Drawing.Size(147, 15)
        Me.txtValNetVenD.TabIndex = 128
        Me.ToolTip1.SetToolTip(Me.txtValNetVenD, "Presione F2 para buscar la cuenta contable o el comodin")
        '
        'txtValNetVenH
        '
        Me.txtValNetVenH.AcceptsReturn = True
        Me.txtValNetVenH.BackColor = System.Drawing.SystemColors.Window
        Me.txtValNetVenH.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValNetVenH.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtValNetVenH.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtValNetVenH.Location = New System.Drawing.Point(571, 62)
        Me.txtValNetVenH.Margin = New System.Windows.Forms.Padding(4)
        Me.txtValNetVenH.MaxLength = 30
        Me.txtValNetVenH.Name = "txtValNetVenH"
        Me.txtValNetVenH.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtValNetVenH.Size = New System.Drawing.Size(147, 15)
        Me.txtValNetVenH.TabIndex = 127
        Me.ToolTip1.SetToolTip(Me.txtValNetVenH, "Presione F2 para buscar la cuenta contable o el comodin")
        '
        'txtIvaD
        '
        Me.txtIvaD.AcceptsReturn = True
        Me.txtIvaD.BackColor = System.Drawing.SystemColors.Window
        Me.txtIvaD.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIvaD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtIvaD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtIvaD.Location = New System.Drawing.Point(164, 123)
        Me.txtIvaD.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIvaD.MaxLength = 30
        Me.txtIvaD.Name = "txtIvaD"
        Me.txtIvaD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtIvaD.Size = New System.Drawing.Size(147, 15)
        Me.txtIvaD.TabIndex = 124
        Me.ToolTip1.SetToolTip(Me.txtIvaD, "Presione F2 para buscar la cuenta contable o el comodin")
        '
        'txtIvaH
        '
        Me.txtIvaH.AcceptsReturn = True
        Me.txtIvaH.BackColor = System.Drawing.SystemColors.Window
        Me.txtIvaH.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtIvaH.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtIvaH.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtIvaH.Location = New System.Drawing.Point(571, 123)
        Me.txtIvaH.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIvaH.MaxLength = 30
        Me.txtIvaH.Name = "txtIvaH"
        Me.txtIvaH.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtIvaH.Size = New System.Drawing.Size(147, 15)
        Me.txtIvaH.TabIndex = 123
        Me.ToolTip1.SetToolTip(Me.txtIvaH, "Presione F2 para buscar la cuenta contable o el comodin")
        '
        'txtOtrSIvaD
        '
        Me.txtOtrSIvaD.AcceptsReturn = True
        Me.txtOtrSIvaD.BackColor = System.Drawing.SystemColors.Window
        Me.txtOtrSIvaD.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtOtrSIvaD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOtrSIvaD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOtrSIvaD.Location = New System.Drawing.Point(164, 154)
        Me.txtOtrSIvaD.Margin = New System.Windows.Forms.Padding(4)
        Me.txtOtrSIvaD.MaxLength = 30
        Me.txtOtrSIvaD.Name = "txtOtrSIvaD"
        Me.txtOtrSIvaD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtOtrSIvaD.Size = New System.Drawing.Size(147, 15)
        Me.txtOtrSIvaD.TabIndex = 120
        Me.ToolTip1.SetToolTip(Me.txtOtrSIvaD, "Presione F2 para buscar la cuenta contable o el comodin")
        '
        'txtOtrSIvaH
        '
        Me.txtOtrSIvaH.AcceptsReturn = True
        Me.txtOtrSIvaH.BackColor = System.Drawing.SystemColors.Window
        Me.txtOtrSIvaH.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtOtrSIvaH.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOtrSIvaH.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOtrSIvaH.Location = New System.Drawing.Point(571, 154)
        Me.txtOtrSIvaH.Margin = New System.Windows.Forms.Padding(4)
        Me.txtOtrSIvaH.MaxLength = 30
        Me.txtOtrSIvaH.Name = "txtOtrSIvaH"
        Me.txtOtrSIvaH.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtOtrSIvaH.Size = New System.Drawing.Size(147, 15)
        Me.txtOtrSIvaH.TabIndex = 119
        Me.ToolTip1.SetToolTip(Me.txtOtrSIvaH, "Presione F2 para buscar la cuenta contable o el comodin")
        '
        'txtTotDesIndD
        '
        Me.txtTotDesIndD.AcceptsReturn = True
        Me.txtTotDesIndD.BackColor = System.Drawing.SystemColors.Window
        Me.txtTotDesIndD.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotDesIndD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotDesIndD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTotDesIndD.Location = New System.Drawing.Point(164, 185)
        Me.txtTotDesIndD.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotDesIndD.MaxLength = 30
        Me.txtTotDesIndD.Name = "txtTotDesIndD"
        Me.txtTotDesIndD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTotDesIndD.Size = New System.Drawing.Size(147, 15)
        Me.txtTotDesIndD.TabIndex = 116
        Me.ToolTip1.SetToolTip(Me.txtTotDesIndD, "Presione F2 para buscar la cuenta contable o el comodin")
        '
        'txtTotDesIndH
        '
        Me.txtTotDesIndH.AcceptsReturn = True
        Me.txtTotDesIndH.BackColor = System.Drawing.SystemColors.Window
        Me.txtTotDesIndH.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotDesIndH.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotDesIndH.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTotDesIndH.Location = New System.Drawing.Point(571, 185)
        Me.txtTotDesIndH.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTotDesIndH.MaxLength = 30
        Me.txtTotDesIndH.Name = "txtTotDesIndH"
        Me.txtTotDesIndH.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTotDesIndH.Size = New System.Drawing.Size(147, 15)
        Me.txtTotDesIndH.TabIndex = 115
        Me.ToolTip1.SetToolTip(Me.txtTotDesIndH, "Presione F2 para buscar la cuenta contable o el comodin")
        '
        'txtCtaCosH
        '
        Me.txtCtaCosH.AcceptsReturn = True
        Me.txtCtaCosH.BackColor = System.Drawing.SystemColors.Window
        Me.txtCtaCosH.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCtaCosH.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCtaCosH.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCtaCosH.Location = New System.Drawing.Point(571, 215)
        Me.txtCtaCosH.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCtaCosH.MaxLength = 30
        Me.txtCtaCosH.Name = "txtCtaCosH"
        Me.txtCtaCosH.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCtaCosH.Size = New System.Drawing.Size(147, 15)
        Me.txtCtaCosH.TabIndex = 109
        Me.ToolTip1.SetToolTip(Me.txtCtaCosH, "Presione F2 para buscar la cuenta contable o el comodin")
        '
        'txtCtaCosD
        '
        Me.txtCtaCosD.AcceptsReturn = True
        Me.txtCtaCosD.BackColor = System.Drawing.SystemColors.Window
        Me.txtCtaCosD.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCtaCosD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCtaCosD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCtaCosD.Location = New System.Drawing.Point(164, 215)
        Me.txtCtaCosD.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCtaCosD.MaxLength = 30
        Me.txtCtaCosD.Name = "txtCtaCosD"
        Me.txtCtaCosD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCtaCosD.Size = New System.Drawing.Size(147, 15)
        Me.txtCtaCosD.TabIndex = 108
        Me.ToolTip1.SetToolTip(Me.txtCtaCosD, "Presione F2 para buscar la cuenta contable o el comodin")
        '
        'txtValVenInvH
        '
        Me.txtValVenInvH.AcceptsReturn = True
        Me.txtValVenInvH.BackColor = System.Drawing.SystemColors.Window
        Me.txtValVenInvH.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtValVenInvH.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtValVenInvH.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtValVenInvH.Location = New System.Drawing.Point(568, 0)
        Me.txtValVenInvH.Margin = New System.Windows.Forms.Padding(4)
        Me.txtValVenInvH.MaxLength = 30
        Me.txtValVenInvH.Name = "txtValVenInvH"
        Me.txtValVenInvH.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtValVenInvH.Size = New System.Drawing.Size(147, 15)
        Me.txtValVenInvH.TabIndex = 107
        Me.ToolTip1.SetToolTip(Me.txtValVenInvH, "Presione F2 para buscar la cuenta contable o el comodin")
        '
        'txtRetBieD
        '
        Me.txtRetBieD.AcceptsReturn = True
        Me.txtRetBieD.BackColor = System.Drawing.SystemColors.Window
        Me.txtRetBieD.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRetBieD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRetBieD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRetBieD.Location = New System.Drawing.Point(168, 96)
        Me.txtRetBieD.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRetBieD.MaxLength = 30
        Me.txtRetBieD.Name = "txtRetBieD"
        Me.txtRetBieD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRetBieD.Size = New System.Drawing.Size(147, 15)
        Me.txtRetBieD.TabIndex = 93
        Me.ToolTip1.SetToolTip(Me.txtRetBieD, "Presione F2 para buscar la cuenta contable o el comodin")
        '
        'txtRetBieH
        '
        Me.txtRetBieH.AcceptsReturn = True
        Me.txtRetBieH.BackColor = System.Drawing.SystemColors.Window
        Me.txtRetBieH.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRetBieH.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRetBieH.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRetBieH.Location = New System.Drawing.Point(573, 96)
        Me.txtRetBieH.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRetBieH.MaxLength = 30
        Me.txtRetBieH.Name = "txtRetBieH"
        Me.txtRetBieH.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRetBieH.Size = New System.Drawing.Size(147, 15)
        Me.txtRetBieH.TabIndex = 92
        Me.ToolTip1.SetToolTip(Me.txtRetBieH, "Presione F2 para buscar la cuenta contable o el comodin")
        '
        'txtRetSerD
        '
        Me.txtRetSerD.AcceptsReturn = True
        Me.txtRetSerD.BackColor = System.Drawing.SystemColors.Window
        Me.txtRetSerD.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRetSerD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRetSerD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRetSerD.Location = New System.Drawing.Point(168, 127)
        Me.txtRetSerD.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRetSerD.MaxLength = 30
        Me.txtRetSerD.Name = "txtRetSerD"
        Me.txtRetSerD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRetSerD.Size = New System.Drawing.Size(147, 15)
        Me.txtRetSerD.TabIndex = 89
        Me.ToolTip1.SetToolTip(Me.txtRetSerD, "Presione F2 para buscar la cuenta contable o el comodin")
        '
        'txtRetSerH
        '
        Me.txtRetSerH.AcceptsReturn = True
        Me.txtRetSerH.BackColor = System.Drawing.SystemColors.Window
        Me.txtRetSerH.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRetSerH.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRetSerH.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRetSerH.Location = New System.Drawing.Point(573, 127)
        Me.txtRetSerH.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRetSerH.MaxLength = 30
        Me.txtRetSerH.Name = "txtRetSerH"
        Me.txtRetSerH.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRetSerH.Size = New System.Drawing.Size(147, 15)
        Me.txtRetSerH.TabIndex = 88
        Me.ToolTip1.SetToolTip(Me.txtRetSerH, "Presione F2 para buscar la cuenta contable o el comodin")
        '
        'txtRetFteD
        '
        Me.txtRetFteD.AcceptsReturn = True
        Me.txtRetFteD.BackColor = System.Drawing.SystemColors.Window
        Me.txtRetFteD.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRetFteD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRetFteD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRetFteD.Location = New System.Drawing.Point(168, 4)
        Me.txtRetFteD.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRetFteD.MaxLength = 30
        Me.txtRetFteD.Name = "txtRetFteD"
        Me.txtRetFteD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRetFteD.Size = New System.Drawing.Size(147, 15)
        Me.txtRetFteD.TabIndex = 85
        Me.ToolTip1.SetToolTip(Me.txtRetFteD, "Presione F2 para buscar la cuenta contable o el comodin")
        '
        'txtRetFteH
        '
        Me.txtRetFteH.AcceptsReturn = True
        Me.txtRetFteH.BackColor = System.Drawing.SystemColors.Window
        Me.txtRetFteH.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRetFteH.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRetFteH.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRetFteH.Location = New System.Drawing.Point(573, 4)
        Me.txtRetFteH.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRetFteH.MaxLength = 30
        Me.txtRetFteH.Name = "txtRetFteH"
        Me.txtRetFteH.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRetFteH.Size = New System.Drawing.Size(147, 15)
        Me.txtRetFteH.TabIndex = 84
        Me.ToolTip1.SetToolTip(Me.txtRetFteH, "Presione F2 para buscar la cuenta contable o el comodin")
        '
        'txtRetFte1H
        '
        Me.txtRetFte1H.AcceptsReturn = True
        Me.txtRetFte1H.BackColor = System.Drawing.SystemColors.Window
        Me.txtRetFte1H.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRetFte1H.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRetFte1H.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRetFte1H.Location = New System.Drawing.Point(573, 34)
        Me.txtRetFte1H.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRetFte1H.MaxLength = 30
        Me.txtRetFte1H.Name = "txtRetFte1H"
        Me.txtRetFte1H.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRetFte1H.Size = New System.Drawing.Size(147, 15)
        Me.txtRetFte1H.TabIndex = 79
        Me.ToolTip1.SetToolTip(Me.txtRetFte1H, "Presione F2 para buscar la cuenta contable o el comodin")
        '
        'txtRetFte1D
        '
        Me.txtRetFte1D.AcceptsReturn = True
        Me.txtRetFte1D.BackColor = System.Drawing.SystemColors.Window
        Me.txtRetFte1D.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRetFte1D.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRetFte1D.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRetFte1D.Location = New System.Drawing.Point(168, 34)
        Me.txtRetFte1D.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRetFte1D.MaxLength = 30
        Me.txtRetFte1D.Name = "txtRetFte1D"
        Me.txtRetFte1D.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRetFte1D.Size = New System.Drawing.Size(147, 15)
        Me.txtRetFte1D.TabIndex = 78
        Me.ToolTip1.SetToolTip(Me.txtRetFte1D, "Presione F2 para buscar la cuenta contable o el comodin")
        '
        'txtRetFte2H
        '
        Me.txtRetFte2H.AcceptsReturn = True
        Me.txtRetFte2H.BackColor = System.Drawing.SystemColors.Window
        Me.txtRetFte2H.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRetFte2H.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRetFte2H.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRetFte2H.Location = New System.Drawing.Point(573, 65)
        Me.txtRetFte2H.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRetFte2H.MaxLength = 30
        Me.txtRetFte2H.Name = "txtRetFte2H"
        Me.txtRetFte2H.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRetFte2H.Size = New System.Drawing.Size(147, 15)
        Me.txtRetFte2H.TabIndex = 224
        Me.ToolTip1.SetToolTip(Me.txtRetFte2H, "Presione F2 para buscar la cuenta contable o el comodin")
        '
        'txtRetFte2D
        '
        Me.txtRetFte2D.AcceptsReturn = True
        Me.txtRetFte2D.BackColor = System.Drawing.SystemColors.Window
        Me.txtRetFte2D.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRetFte2D.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRetFte2D.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRetFte2D.Location = New System.Drawing.Point(168, 65)
        Me.txtRetFte2D.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRetFte2D.MaxLength = 30
        Me.txtRetFte2D.Name = "txtRetFte2D"
        Me.txtRetFte2D.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRetFte2D.Size = New System.Drawing.Size(147, 15)
        Me.txtRetFte2D.TabIndex = 223
        Me.ToolTip1.SetToolTip(Me.txtRetFte2D, "Presione F2 para buscar la cuenta contable o el comodin")
        '
        'OpCosLiq
        '
        Me.OpCosLiq.BackColor = System.Drawing.Color.Transparent
        Me.OpCosLiq.Cursor = System.Windows.Forms.Cursors.Default
        Me.OpCosLiq.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OpCosLiq.Location = New System.Drawing.Point(21, 96)
        Me.OpCosLiq.Margin = New System.Windows.Forms.Padding(4)
        Me.OpCosLiq.Name = "OpCosLiq"
        Me.OpCosLiq.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OpCosLiq.Size = New System.Drawing.Size(428, 49)
        Me.OpCosLiq.TabIndex = 184
        Me.OpCosLiq.TabStop = True
        Me.OpCosLiq.Text = "Liquidar el costo con el precio de adquisición mas gastos registrados en document" &
    "os referenciados"
        Me.ToolTip1.SetToolTip(Me.OpCosLiq, "El sistema suma el valor de los artículos más el valor total" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "de los documentos  " &
        "que tengan registrado en la referencia " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "el tipo y número de este tipo de docume" &
        "nto")
        Me.OpCosLiq.UseVisualStyleBackColor = False
        '
        'Toolbar1
        '
        Me.Toolbar1.BackColor = System.Drawing.Color.DimGray
        Me.Toolbar1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Toolbar1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.Toolbar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnnuevo, Me.btnabrir, Me.btncerrar, Me.btnguardar, Me.btneliminar, Me.btnsalir})
        Me.Toolbar1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.Toolbar1.Name = "Toolbar1"
        Me.Toolbar1.Size = New System.Drawing.Size(1147, 59)
        Me.Toolbar1.Stretch = True
        Me.Toolbar1.TabIndex = 234
        '
        'btnnuevo
        '
        Me.btnnuevo.ForeColor = System.Drawing.Color.White
        Me.btnnuevo.Image = CType(resources.GetObject("btnnuevo.Image"), System.Drawing.Image)
        Me.btnnuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnnuevo.Name = "btnnuevo"
        Me.btnnuevo.Size = New System.Drawing.Size(56, 56)
        Me.btnnuevo.Text = "Nuevo"
        Me.btnnuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnnuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnnuevo.ToolTipText = "Nuevo"
        '
        'btnabrir
        '
        Me.btnabrir.ForeColor = System.Drawing.Color.White
        Me.btnabrir.Image = CType(resources.GetObject("btnabrir.Image"), System.Drawing.Image)
        Me.btnabrir.Name = "btnabrir"
        Me.btnabrir.Size = New System.Drawing.Size(46, 56)
        Me.btnabrir.Text = "Abrir"
        Me.btnabrir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnabrir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btncerrar
        '
        Me.btncerrar.ForeColor = System.Drawing.Color.White
        Me.btncerrar.Image = CType(resources.GetObject("btncerrar.Image"), System.Drawing.Image)
        Me.btncerrar.Name = "btncerrar"
        Me.btncerrar.Size = New System.Drawing.Size(53, 56)
        Me.btncerrar.Text = "Cerrar"
        Me.btncerrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btncerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnguardar
        '
        Me.btnguardar.ForeColor = System.Drawing.Color.White
        Me.btnguardar.Image = CType(resources.GetObject("btnguardar.Image"), System.Drawing.Image)
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.Size = New System.Drawing.Size(66, 56)
        Me.btnguardar.Text = "Guardar"
        Me.btnguardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnguardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btneliminar
        '
        Me.btneliminar.ForeColor = System.Drawing.Color.White
        Me.btneliminar.Image = CType(resources.GetObject("btneliminar.Image"), System.Drawing.Image)
        Me.btneliminar.Name = "btneliminar"
        Me.btneliminar.Size = New System.Drawing.Size(67, 56)
        Me.btneliminar.Text = "Eliminar"
        Me.btneliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btneliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnsalir
        '
        Me.btnsalir.ForeColor = System.Drawing.Color.White
        Me.btnsalir.Image = CType(resources.GetObject("btnsalir.Image"), System.Drawing.Image)
        Me.btnsalir.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnsalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(90, 56)
        Me.btnsalir.Text = "Salir"
        Me.btnsalir.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'txtAbr
        '
        Me.txtAbr.AcceptsReturn = True
        Me.txtAbr.BackColor = System.Drawing.Color.White
        Me.txtAbr.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtAbr.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAbr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAbr.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAbr.Location = New System.Drawing.Point(120, 69)
        Me.txtAbr.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAbr.MaxLength = 3
        Me.txtAbr.Name = "txtAbr"
        Me.txtAbr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAbr.Size = New System.Drawing.Size(55, 19)
        Me.txtAbr.TabIndex = 19
        '
        'txtDes
        '
        Me.txtDes.AcceptsReturn = True
        Me.txtDes.BackColor = System.Drawing.Color.White
        Me.txtDes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDes.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDes.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDes.Location = New System.Drawing.Point(304, 70)
        Me.txtDes.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDes.MaxLength = 40
        Me.txtDes.Name = "txtDes"
        Me.txtDes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDes.Size = New System.Drawing.Size(488, 19)
        Me.txtDes.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(8, 69)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(111, 16)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Abreviación"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(193, 70)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(104, 20)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = "Descripción:"
        '
        'LabGeneral
        '
        Me.LabGeneral.BackColor = System.Drawing.Color.DimGray
        Me.LabGeneral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabGeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabGeneral.ForeColor = System.Drawing.Color.White
        Me.LabGeneral.Location = New System.Drawing.Point(15, 100)
        Me.LabGeneral.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabGeneral.Name = "LabGeneral"
        Me.LabGeneral.Size = New System.Drawing.Size(239, 28)
        Me.LabGeneral.TabIndex = 236
        Me.LabGeneral.Text = "Propiedades generales"
        Me.LabGeneral.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabInventario
        '
        Me.LabInventario.BackColor = System.Drawing.Color.DimGray
        Me.LabInventario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabInventario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabInventario.ForeColor = System.Drawing.Color.White
        Me.LabInventario.Location = New System.Drawing.Point(255, 100)
        Me.LabInventario.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabInventario.Name = "LabInventario"
        Me.LabInventario.Size = New System.Drawing.Size(239, 28)
        Me.LabInventario.TabIndex = 237
        Me.LabInventario.Text = "Registro en inventario"
        Me.LabInventario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabContabilidad
        '
        Me.LabContabilidad.BackColor = System.Drawing.Color.DimGray
        Me.LabContabilidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabContabilidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabContabilidad.ForeColor = System.Drawing.Color.White
        Me.LabContabilidad.Location = New System.Drawing.Point(495, 100)
        Me.LabContabilidad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabContabilidad.Name = "LabContabilidad"
        Me.LabContabilidad.Size = New System.Drawing.Size(239, 28)
        Me.LabContabilidad.TabIndex = 248
        Me.LabContabilidad.Text = "Registro en Contabilidad"
        Me.LabContabilidad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabGeneral
        '
        Me.TabGeneral.BackColor = System.Drawing.Color.Transparent
        Me.TabGeneral.Controls.Add(Me.txtFormulasPVP)
        Me.TabGeneral.Controls.Add(Me.btnBuscaFormulaPVP)
        Me.TabGeneral.Controls.Add(Me.ComandoSQL)
        Me.TabGeneral.Controls.Add(Me.Label55)
        Me.TabGeneral.Controls.Add(Me.Command8)
        Me.TabGeneral.Controls.Add(Me.BtnDocSop)
        Me.TabGeneral.Controls.Add(Me.TxtTipSop)
        Me.TabGeneral.Controls.Add(Me.Label46)
        Me.TabGeneral.Controls.Add(Me.Label45)
        Me.TabGeneral.Controls.Add(Me.LbNomSoporte)
        Me.TabGeneral.Controls.Add(Me.Label44)
        Me.TabGeneral.Controls.Add(Me.frFac)
        Me.TabGeneral.Controls.Add(Me.Label56)
        Me.TabGeneral.Controls.Add(Me.chkElectronico)
        Me.TabGeneral.Controls.Add(Me.chkRegistraImportaciones)
        Me.TabGeneral.Controls.Add(Me.chkNoBajoCosto)
        Me.TabGeneral.Controls.Add(Me.frImpFor)
        Me.TabGeneral.Controls.Add(Me.TipoComprobanteSri)
        Me.TabGeneral.Controls.Add(Me.Label13)
        Me.TabGeneral.Controls.Add(Me.Check8)
        Me.TabGeneral.Controls.Add(Me.dbDoc)
        Me.TabGeneral.Controls.Add(Me.ChGenTipGas)
        Me.TabGeneral.Controls.Add(Me.Chpuedeconsolidar)
        Me.TabGeneral.Controls.Add(Me.chRefAcf)
        Me.TabGeneral.Controls.Add(Me.fImpuestos)
        Me.TabGeneral.Controls.Add(Me.Frame2)
        Me.TabGeneral.Controls.Add(Me.Frame4)
        Me.TabGeneral.Controls.Add(Me.Check7)
        Me.TabGeneral.Controls.Add(Me.chRefInv)
        Me.TabGeneral.Controls.Add(Me.chRefCon)
        Me.TabGeneral.Controls.Add(Me.Label1)
        Me.TabGeneral.ForeColor = System.Drawing.Color.White
        Me.TabGeneral.Location = New System.Drawing.Point(15, 122)
        Me.TabGeneral.Margin = New System.Windows.Forms.Padding(4)
        Me.TabGeneral.Name = "TabGeneral"
        Me.TabGeneral.Padding = New System.Windows.Forms.Padding(4)
        Me.TabGeneral.Size = New System.Drawing.Size(1132, 537)
        Me.TabGeneral.TabIndex = 250
        Me.TabGeneral.TabStop = False
        '
        'txtFormulasPVP
        '
        Me.txtFormulasPVP.AcceptsReturn = True
        Me.txtFormulasPVP.BackColor = System.Drawing.SystemColors.Window
        Me.txtFormulasPVP.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFormulasPVP.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFormulasPVP.Location = New System.Drawing.Point(17, 351)
        Me.txtFormulasPVP.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFormulasPVP.MaxLength = 20
        Me.txtFormulasPVP.Name = "txtFormulasPVP"
        Me.txtFormulasPVP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFormulasPVP.Size = New System.Drawing.Size(483, 22)
        Me.txtFormulasPVP.TabIndex = 361
        '
        'btnBuscaFormulaPVP
        '
        Me.btnBuscaFormulaPVP.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscaFormulaPVP.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnBuscaFormulaPVP.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscaFormulaPVP.Location = New System.Drawing.Point(501, 350)
        Me.btnBuscaFormulaPVP.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBuscaFormulaPVP.Name = "btnBuscaFormulaPVP"
        Me.btnBuscaFormulaPVP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnBuscaFormulaPVP.Size = New System.Drawing.Size(29, 27)
        Me.btnBuscaFormulaPVP.TabIndex = 359
        Me.btnBuscaFormulaPVP.Text = ".."
        Me.btnBuscaFormulaPVP.UseVisualStyleBackColor = False
        '
        'ComandoSQL
        '
        Me.ComandoSQL.Location = New System.Drawing.Point(17, 491)
        Me.ComandoSQL.Margin = New System.Windows.Forms.Padding(4)
        Me.ComandoSQL.Name = "ComandoSQL"
        Me.ComandoSQL.Size = New System.Drawing.Size(477, 22)
        Me.ComandoSQL.TabIndex = 356
        '
        'Label55
        '
        Me.Label55.BackColor = System.Drawing.Color.Transparent
        Me.Label55.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label55.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label55.Location = New System.Drawing.Point(13, 474)
        Me.Label55.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label55.Name = "Label55"
        Me.Label55.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label55.Size = New System.Drawing.Size(487, 22)
        Me.Label55.TabIndex = 355
        Me.Label55.Text = "Comando SQL que debe ejecutarse al terminar la grabación del documento" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Command8
        '
        Me.Command8.BackColor = System.Drawing.SystemColors.Control
        Me.Command8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command8.Location = New System.Drawing.Point(500, 443)
        Me.Command8.Margin = New System.Windows.Forms.Padding(4)
        Me.Command8.Name = "Command8"
        Me.Command8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command8.Size = New System.Drawing.Size(29, 27)
        Me.Command8.TabIndex = 349
        Me.Command8.Text = ".."
        Me.Command8.UseVisualStyleBackColor = False
        '
        'BtnDocSop
        '
        Me.BtnDocSop.BackColor = System.Drawing.SystemColors.Control
        Me.BtnDocSop.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtnDocSop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnDocSop.Location = New System.Drawing.Point(501, 393)
        Me.BtnDocSop.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnDocSop.Name = "BtnDocSop"
        Me.BtnDocSop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BtnDocSop.Size = New System.Drawing.Size(29, 27)
        Me.BtnDocSop.TabIndex = 344
        Me.BtnDocSop.Text = ".."
        Me.BtnDocSop.UseVisualStyleBackColor = False
        '
        'TxtTipSop
        '
        Me.TxtTipSop.AcceptsReturn = True
        Me.TxtTipSop.BackColor = System.Drawing.SystemColors.Window
        Me.TxtTipSop.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtTipSop.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtTipSop.Location = New System.Drawing.Point(16, 394)
        Me.TxtTipSop.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtTipSop.MaxLength = 3
        Me.TxtTipSop.Name = "TxtTipSop"
        Me.TxtTipSop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtTipSop.Size = New System.Drawing.Size(43, 22)
        Me.TxtTipSop.TabIndex = 343
        '
        'Label46
        '
        Me.Label46.BackColor = System.Drawing.Color.White
        Me.Label46.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label46.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label46.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label46.Location = New System.Drawing.Point(15, 444)
        Me.Label46.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label46.Name = "Label46"
        Me.Label46.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label46.Size = New System.Drawing.Size(484, 23)
        Me.Label46.TabIndex = 348
        '
        'Label45
        '
        Me.Label45.BackColor = System.Drawing.Color.Transparent
        Me.Label45.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label45.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label45.Location = New System.Drawing.Point(16, 427)
        Me.Label45.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label45.Name = "Label45"
        Me.Label45.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label45.Size = New System.Drawing.Size(471, 22)
        Me.Label45.TabIndex = 347
        Me.Label45.Text = "En este documento se pueden consolidar los documentos siguientes:"
        '
        'LbNomSoporte
        '
        Me.LbNomSoporte.BackColor = System.Drawing.Color.White
        Me.LbNomSoporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LbNomSoporte.Cursor = System.Windows.Forms.Cursors.Default
        Me.LbNomSoporte.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LbNomSoporte.Location = New System.Drawing.Point(63, 394)
        Me.LbNomSoporte.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LbNomSoporte.Name = "LbNomSoporte"
        Me.LbNomSoporte.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LbNomSoporte.Size = New System.Drawing.Size(439, 23)
        Me.LbNomSoporte.TabIndex = 346
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.Color.Transparent
        Me.Label44.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label44.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label44.Location = New System.Drawing.Point(15, 374)
        Me.Label44.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label44.Name = "Label44"
        Me.Label44.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label44.Size = New System.Drawing.Size(472, 22)
        Me.Label44.TabIndex = 345
        Me.Label44.Text = "Debe registrarse obligatoriamente la referencia al documento:"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frFac
        '
        Me.frFac.BackColor = System.Drawing.Color.Transparent
        Me.frFac.Controls.Add(Me.chFacSer)
        Me.frFac.Controls.Add(Me.chFacArt)
        Me.frFac.Controls.Add(Me.chFacAcf)
        Me.frFac.ForeColor = System.Drawing.Color.Gray
        Me.frFac.Location = New System.Drawing.Point(29, 506)
        Me.frFac.Margin = New System.Windows.Forms.Padding(4)
        Me.frFac.Name = "frFac"
        Me.frFac.Padding = New System.Windows.Forms.Padding(0)
        Me.frFac.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frFac.Size = New System.Drawing.Size(247, 42)
        Me.frFac.TabIndex = 339
        Me.frFac.TabStop = False
        Me.frFac.Text = "Permite detalle de documento con :"
        Me.frFac.Visible = False
        '
        'chFacSer
        '
        Me.chFacSer.BackColor = System.Drawing.Color.Transparent
        Me.chFacSer.Cursor = System.Windows.Forms.Cursors.Default
        Me.chFacSer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chFacSer.Location = New System.Drawing.Point(11, 48)
        Me.chFacSer.Margin = New System.Windows.Forms.Padding(4)
        Me.chFacSer.Name = "chFacSer"
        Me.chFacSer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chFacSer.Size = New System.Drawing.Size(116, 21)
        Me.chFacSer.TabIndex = 198
        Me.chFacSer.Text = "Conceptos"
        Me.chFacSer.UseVisualStyleBackColor = False
        '
        'chFacArt
        '
        Me.chFacArt.BackColor = System.Drawing.Color.Transparent
        Me.chFacArt.Cursor = System.Windows.Forms.Cursors.Default
        Me.chFacArt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chFacArt.Location = New System.Drawing.Point(11, 20)
        Me.chFacArt.Margin = New System.Windows.Forms.Padding(4)
        Me.chFacArt.Name = "chFacArt"
        Me.chFacArt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chFacArt.Size = New System.Drawing.Size(173, 21)
        Me.chFacArt.TabIndex = 197
        Me.chFacArt.Text = "Articulos inventario"
        Me.chFacArt.UseVisualStyleBackColor = False
        '
        'chFacAcf
        '
        Me.chFacAcf.BackColor = System.Drawing.Color.Transparent
        Me.chFacAcf.Cursor = System.Windows.Forms.Cursors.Default
        Me.chFacAcf.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chFacAcf.Location = New System.Drawing.Point(11, 76)
        Me.chFacAcf.Margin = New System.Windows.Forms.Padding(4)
        Me.chFacAcf.Name = "chFacAcf"
        Me.chFacAcf.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chFacAcf.Size = New System.Drawing.Size(116, 21)
        Me.chFacAcf.TabIndex = 196
        Me.chFacAcf.Text = "Activos Fijos"
        Me.chFacAcf.UseVisualStyleBackColor = False
        '
        'Label56
        '
        Me.Label56.BackColor = System.Drawing.Color.Transparent
        Me.Label56.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label56.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label56.Location = New System.Drawing.Point(13, 330)
        Me.Label56.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label56.Name = "Label56"
        Me.Label56.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label56.Size = New System.Drawing.Size(472, 22)
        Me.Label56.TabIndex = 360
        Me.Label56.Text = "Fórmulas para recalcular en línea el precio de venta"
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkElectronico
        '
        Me.chkElectronico.BackColor = System.Drawing.Color.Transparent
        Me.chkElectronico.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkElectronico.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkElectronico.Location = New System.Drawing.Point(16, 306)
        Me.chkElectronico.Margin = New System.Windows.Forms.Padding(4)
        Me.chkElectronico.Name = "chkElectronico"
        Me.chkElectronico.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkElectronico.Size = New System.Drawing.Size(224, 21)
        Me.chkElectronico.TabIndex = 363
        Me.chkElectronico.Text = "Es documento electrónico"
        Me.chkElectronico.UseVisualStyleBackColor = False
        '
        'chkRegistraImportaciones
        '
        Me.chkRegistraImportaciones.BackColor = System.Drawing.Color.Transparent
        Me.chkRegistraImportaciones.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkRegistraImportaciones.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkRegistraImportaciones.Location = New System.Drawing.Point(345, 159)
        Me.chkRegistraImportaciones.Margin = New System.Windows.Forms.Padding(4)
        Me.chkRegistraImportaciones.Name = "chkRegistraImportaciones"
        Me.chkRegistraImportaciones.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkRegistraImportaciones.Size = New System.Drawing.Size(327, 22)
        Me.chkRegistraImportaciones.TabIndex = 362
        Me.chkRegistraImportaciones.Text = "Documento registra importaciones"
        Me.chkRegistraImportaciones.UseVisualStyleBackColor = False
        Me.chkRegistraImportaciones.Visible = False
        '
        'chkNoBajoCosto
        '
        Me.chkNoBajoCosto.BackColor = System.Drawing.Color.Transparent
        Me.chkNoBajoCosto.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkNoBajoCosto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkNoBajoCosto.Location = New System.Drawing.Point(345, 138)
        Me.chkNoBajoCosto.Margin = New System.Windows.Forms.Padding(4)
        Me.chkNoBajoCosto.Name = "chkNoBajoCosto"
        Me.chkNoBajoCosto.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkNoBajoCosto.Size = New System.Drawing.Size(357, 22)
        Me.chkNoBajoCosto.TabIndex = 357
        Me.chkNoBajoCosto.Text = "No se permite PVP menor a útimo costo de compra"
        Me.chkNoBajoCosto.UseVisualStyleBackColor = False
        '
        'frImpFor
        '
        Me.frImpFor.BackColor = System.Drawing.Color.Transparent
        Me.frImpFor.Controls.Add(Me.chkImprimirRIDE)
        Me.frImpFor.Controls.Add(Me.chkImprimirTicket)
        Me.frImpFor.Controls.Add(Me.btnFormatoElec)
        Me.frImpFor.Controls.Add(Me.FormatoElec)
        Me.frImpFor.Controls.Add(Me.Label54)
        Me.frImpFor.Controls.Add(Me.btnFormatoCtb)
        Me.frImpFor.Controls.Add(Me.FormatoCtb)
        Me.frImpFor.Controls.Add(Me.opImpForNin)
        Me.frImpFor.Controls.Add(Me.opImpForGen)
        Me.frImpFor.Controls.Add(Me.txtFormato)
        Me.frImpFor.Controls.Add(Me.btnFormatoGeneral)
        Me.frImpFor.Controls.Add(Me.Label12)
        Me.frImpFor.ForeColor = System.Drawing.Color.White
        Me.frImpFor.Location = New System.Drawing.Point(643, 192)
        Me.frImpFor.Margin = New System.Windows.Forms.Padding(4)
        Me.frImpFor.Name = "frImpFor"
        Me.frImpFor.Padding = New System.Windows.Forms.Padding(0)
        Me.frImpFor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frImpFor.Size = New System.Drawing.Size(473, 183)
        Me.frImpFor.TabIndex = 335
        Me.frImpFor.TabStop = False
        Me.frImpFor.Text = "Formato TEKFORM para impresión"
        Me.frImpFor.Visible = False
        '
        'chkImprimirRIDE
        '
        Me.chkImprimirRIDE.BackColor = System.Drawing.Color.Transparent
        Me.chkImprimirRIDE.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkImprimirRIDE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkImprimirRIDE.Location = New System.Drawing.Point(9, 72)
        Me.chkImprimirRIDE.Margin = New System.Windows.Forms.Padding(4)
        Me.chkImprimirRIDE.Name = "chkImprimirRIDE"
        Me.chkImprimirRIDE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkImprimirRIDE.Size = New System.Drawing.Size(217, 31)
        Me.chkImprimirRIDE.TabIndex = 56
        Me.chkImprimirRIDE.Text = "Impresión Ride"
        Me.chkImprimirRIDE.UseVisualStyleBackColor = False
        '
        'chkImprimirTicket
        '
        Me.chkImprimirTicket.BackColor = System.Drawing.Color.Transparent
        Me.chkImprimirTicket.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkImprimirTicket.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkImprimirTicket.Location = New System.Drawing.Point(9, 99)
        Me.chkImprimirTicket.Margin = New System.Windows.Forms.Padding(4)
        Me.chkImprimirTicket.Name = "chkImprimirTicket"
        Me.chkImprimirTicket.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkImprimirTicket.Size = New System.Drawing.Size(217, 31)
        Me.chkImprimirTicket.TabIndex = 55
        Me.chkImprimirTicket.Text = "Impresión ticket"
        Me.chkImprimirTicket.UseVisualStyleBackColor = False
        '
        'btnFormatoElec
        '
        Me.btnFormatoElec.BackColor = System.Drawing.SystemColors.Control
        Me.btnFormatoElec.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnFormatoElec.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnFormatoElec.Location = New System.Drawing.Point(439, 151)
        Me.btnFormatoElec.Margin = New System.Windows.Forms.Padding(4)
        Me.btnFormatoElec.Name = "btnFormatoElec"
        Me.btnFormatoElec.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnFormatoElec.Size = New System.Drawing.Size(29, 27)
        Me.btnFormatoElec.TabIndex = 53
        Me.btnFormatoElec.Text = ".."
        Me.btnFormatoElec.UseVisualStyleBackColor = False
        '
        'FormatoElec
        '
        Me.FormatoElec.AcceptsReturn = True
        Me.FormatoElec.BackColor = System.Drawing.SystemColors.Window
        Me.FormatoElec.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.FormatoElec.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormatoElec.Location = New System.Drawing.Point(231, 153)
        Me.FormatoElec.Margin = New System.Windows.Forms.Padding(4)
        Me.FormatoElec.MaxLength = 20
        Me.FormatoElec.Name = "FormatoElec"
        Me.FormatoElec.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FormatoElec.Size = New System.Drawing.Size(205, 22)
        Me.FormatoElec.TabIndex = 52
        '
        'Label54
        '
        Me.Label54.BackColor = System.Drawing.Color.Transparent
        Me.Label54.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label54.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label54.Location = New System.Drawing.Point(8, 149)
        Me.Label54.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label54.Name = "Label54"
        Me.Label54.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label54.Size = New System.Drawing.Size(217, 31)
        Me.Label54.TabIndex = 54
        Me.Label54.Text = "Formato documento electrónico"
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnFormatoCtb
        '
        Me.btnFormatoCtb.BackColor = System.Drawing.SystemColors.Control
        Me.btnFormatoCtb.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnFormatoCtb.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnFormatoCtb.Location = New System.Drawing.Point(439, 124)
        Me.btnFormatoCtb.Margin = New System.Windows.Forms.Padding(4)
        Me.btnFormatoCtb.Name = "btnFormatoCtb"
        Me.btnFormatoCtb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnFormatoCtb.Size = New System.Drawing.Size(29, 27)
        Me.btnFormatoCtb.TabIndex = 50
        Me.btnFormatoCtb.Text = ".."
        Me.btnFormatoCtb.UseVisualStyleBackColor = False
        '
        'FormatoCtb
        '
        Me.FormatoCtb.AcceptsReturn = True
        Me.FormatoCtb.BackColor = System.Drawing.SystemColors.Window
        Me.FormatoCtb.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.FormatoCtb.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormatoCtb.Location = New System.Drawing.Point(231, 126)
        Me.FormatoCtb.Margin = New System.Windows.Forms.Padding(4)
        Me.FormatoCtb.MaxLength = 20
        Me.FormatoCtb.Name = "FormatoCtb"
        Me.FormatoCtb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FormatoCtb.Size = New System.Drawing.Size(205, 22)
        Me.FormatoCtb.TabIndex = 49
        '
        'opImpForNin
        '
        Me.opImpForNin.BackColor = System.Drawing.Color.Transparent
        Me.opImpForNin.Cursor = System.Windows.Forms.Cursors.Default
        Me.opImpForNin.ForeColor = System.Drawing.SystemColors.ControlText
        Me.opImpForNin.Location = New System.Drawing.Point(9, 22)
        Me.opImpForNin.Margin = New System.Windows.Forms.Padding(4)
        Me.opImpForNin.Name = "opImpForNin"
        Me.opImpForNin.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.opImpForNin.Size = New System.Drawing.Size(217, 31)
        Me.opImpForNin.TabIndex = 48
        Me.opImpForNin.Text = "No imprimir"
        Me.opImpForNin.UseVisualStyleBackColor = False
        '
        'opImpForGen
        '
        Me.opImpForGen.BackColor = System.Drawing.Color.Transparent
        Me.opImpForGen.Checked = True
        Me.opImpForGen.Cursor = System.Windows.Forms.Cursors.Default
        Me.opImpForGen.ForeColor = System.Drawing.SystemColors.ControlText
        Me.opImpForGen.Location = New System.Drawing.Point(9, 43)
        Me.opImpForGen.Margin = New System.Windows.Forms.Padding(4)
        Me.opImpForGen.Name = "opImpForGen"
        Me.opImpForGen.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.opImpForGen.Size = New System.Drawing.Size(217, 31)
        Me.opImpForGen.TabIndex = 47
        Me.opImpForGen.TabStop = True
        Me.opImpForGen.Text = "Impresión general"
        Me.opImpForGen.UseVisualStyleBackColor = False
        '
        'txtFormato
        '
        Me.txtFormato.AcceptsReturn = True
        Me.txtFormato.BackColor = System.Drawing.SystemColors.Window
        Me.txtFormato.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFormato.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFormato.Location = New System.Drawing.Point(231, 47)
        Me.txtFormato.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFormato.MaxLength = 20
        Me.txtFormato.Name = "txtFormato"
        Me.txtFormato.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFormato.Size = New System.Drawing.Size(205, 22)
        Me.txtFormato.TabIndex = 46
        '
        'btnFormatoGeneral
        '
        Me.btnFormatoGeneral.BackColor = System.Drawing.SystemColors.Control
        Me.btnFormatoGeneral.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnFormatoGeneral.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnFormatoGeneral.Location = New System.Drawing.Point(439, 45)
        Me.btnFormatoGeneral.Margin = New System.Windows.Forms.Padding(4)
        Me.btnFormatoGeneral.Name = "btnFormatoGeneral"
        Me.btnFormatoGeneral.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnFormatoGeneral.Size = New System.Drawing.Size(29, 27)
        Me.btnFormatoGeneral.TabIndex = 45
        Me.btnFormatoGeneral.Text = ".."
        Me.btnFormatoGeneral.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(8, 122)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(217, 31)
        Me.Label12.TabIndex = 51
        Me.Label12.Text = "Formato  asientos contables"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TipoComprobanteSri
        '
        Me.TipoComprobanteSri.FormattingEnabled = True
        Me.TipoComprobanteSri.Location = New System.Drawing.Point(15, 273)
        Me.TipoComprobanteSri.Margin = New System.Windows.Forms.Padding(4)
        Me.TipoComprobanteSri.Name = "TipoComprobanteSri"
        Me.TipoComprobanteSri.Size = New System.Drawing.Size(619, 24)
        Me.TipoComprobanteSri.TabIndex = 352
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label13.Location = New System.Drawing.Point(12, 257)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(269, 16)
        Me.Label13.TabIndex = 351
        Me.Label13.Text = "Registrar movimiento en el SRI como:"
        '
        'Check8
        '
        Me.Check8.BackColor = System.Drawing.Color.Transparent
        Me.Check8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Check8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Check8.Location = New System.Drawing.Point(345, 117)
        Me.Check8.Margin = New System.Windows.Forms.Padding(4)
        Me.Check8.Name = "Check8"
        Me.Check8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Check8.Size = New System.Drawing.Size(340, 22)
        Me.Check8.TabIndex = 342
        Me.Check8.Text = "Documento necesita autorización para pago"
        Me.Check8.UseVisualStyleBackColor = False
        '
        'dbDoc
        '
        Me.dbDoc.FormattingEnabled = True
        Me.dbDoc.Location = New System.Drawing.Point(157, 20)
        Me.dbDoc.Margin = New System.Windows.Forms.Padding(4)
        Me.dbDoc.Name = "dbDoc"
        Me.dbDoc.Size = New System.Drawing.Size(544, 24)
        Me.dbDoc.TabIndex = 341
        '
        'ChGenTipGas
        '
        Me.ChGenTipGas.BackColor = System.Drawing.Color.Transparent
        Me.ChGenTipGas.Cursor = System.Windows.Forms.Cursors.Default
        Me.ChGenTipGas.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ChGenTipGas.Location = New System.Drawing.Point(345, 75)
        Me.ChGenTipGas.Margin = New System.Windows.Forms.Padding(4)
        Me.ChGenTipGas.Name = "ChGenTipGas"
        Me.ChGenTipGas.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ChGenTipGas.Size = New System.Drawing.Size(340, 22)
        Me.ChGenTipGas.TabIndex = 334
        Me.ChGenTipGas.Text = "Diario tipo liquidación de gastos"
        Me.ChGenTipGas.UseVisualStyleBackColor = False
        '
        'Chpuedeconsolidar
        '
        Me.Chpuedeconsolidar.BackColor = System.Drawing.Color.Transparent
        Me.Chpuedeconsolidar.Cursor = System.Windows.Forms.Cursors.Default
        Me.Chpuedeconsolidar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Chpuedeconsolidar.Location = New System.Drawing.Point(345, 96)
        Me.Chpuedeconsolidar.Margin = New System.Windows.Forms.Padding(4)
        Me.Chpuedeconsolidar.Name = "Chpuedeconsolidar"
        Me.Chpuedeconsolidar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Chpuedeconsolidar.Size = New System.Drawing.Size(340, 22)
        Me.Chpuedeconsolidar.TabIndex = 340
        Me.Chpuedeconsolidar.Text = "El documento puede ser consolidado"
        Me.Chpuedeconsolidar.UseVisualStyleBackColor = False
        '
        'chRefAcf
        '
        Me.chRefAcf.BackColor = System.Drawing.Color.Transparent
        Me.chRefAcf.Cursor = System.Windows.Forms.Cursors.Default
        Me.chRefAcf.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chRefAcf.Location = New System.Drawing.Point(13, 95)
        Me.chRefAcf.Margin = New System.Windows.Forms.Padding(4)
        Me.chRefAcf.Name = "chRefAcf"
        Me.chRefAcf.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chRefAcf.Size = New System.Drawing.Size(327, 22)
        Me.chRefAcf.TabIndex = 338
        Me.chRefAcf.Text = "Registrar movimiento en Activos Fijos"
        Me.chRefAcf.UseVisualStyleBackColor = False
        Me.chRefAcf.Visible = False
        '
        'fImpuestos
        '
        Me.fImpuestos.BackColor = System.Drawing.Color.Transparent
        Me.fImpuestos.Controls.Add(Me.ChImp2)
        Me.fImpuestos.Controls.Add(Me.ChImp1)
        Me.fImpuestos.Controls.Add(Me.ChImp3)
        Me.fImpuestos.Controls.Add(Me.chImp4)
        Me.fImpuestos.ForeColor = System.Drawing.Color.White
        Me.fImpuestos.Location = New System.Drawing.Point(13, 143)
        Me.fImpuestos.Margin = New System.Windows.Forms.Padding(4)
        Me.fImpuestos.Name = "fImpuestos"
        Me.fImpuestos.Padding = New System.Windows.Forms.Padding(0)
        Me.fImpuestos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.fImpuestos.Size = New System.Drawing.Size(119, 100)
        Me.fImpuestos.TabIndex = 337
        Me.fImpuestos.TabStop = False
        Me.fImpuestos.Text = "Impuestos"
        Me.fImpuestos.Visible = False
        '
        'ChImp2
        '
        Me.ChImp2.BackColor = System.Drawing.Color.Transparent
        Me.ChImp2.Cursor = System.Windows.Forms.Cursors.Default
        Me.ChImp2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ChImp2.Location = New System.Drawing.Point(11, 39)
        Me.ChImp2.Margin = New System.Windows.Forms.Padding(4)
        Me.ChImp2.Name = "ChImp2"
        Me.ChImp2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ChImp2.Size = New System.Drawing.Size(85, 21)
        Me.ChImp2.TabIndex = 193
        Me.ChImp2.UseVisualStyleBackColor = False
        '
        'ChImp1
        '
        Me.ChImp1.BackColor = System.Drawing.Color.Transparent
        Me.ChImp1.Cursor = System.Windows.Forms.Cursors.Default
        Me.ChImp1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ChImp1.Location = New System.Drawing.Point(11, 20)
        Me.ChImp1.Margin = New System.Windows.Forms.Padding(4)
        Me.ChImp1.Name = "ChImp1"
        Me.ChImp1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ChImp1.Size = New System.Drawing.Size(85, 21)
        Me.ChImp1.TabIndex = 192
        Me.ChImp1.Text = "Iva"
        Me.ChImp1.UseVisualStyleBackColor = False
        '
        'ChImp3
        '
        Me.ChImp3.BackColor = System.Drawing.Color.Transparent
        Me.ChImp3.Cursor = System.Windows.Forms.Cursors.Default
        Me.ChImp3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ChImp3.Location = New System.Drawing.Point(11, 59)
        Me.ChImp3.Margin = New System.Windows.Forms.Padding(4)
        Me.ChImp3.Name = "ChImp3"
        Me.ChImp3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ChImp3.Size = New System.Drawing.Size(85, 21)
        Me.ChImp3.TabIndex = 191
        Me.ChImp3.UseVisualStyleBackColor = False
        '
        'chImp4
        '
        Me.chImp4.BackColor = System.Drawing.Color.Transparent
        Me.chImp4.Cursor = System.Windows.Forms.Cursors.Default
        Me.chImp4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chImp4.Location = New System.Drawing.Point(11, 79)
        Me.chImp4.Margin = New System.Windows.Forms.Padding(4)
        Me.chImp4.Name = "chImp4"
        Me.chImp4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chImp4.Size = New System.Drawing.Size(85, 21)
        Me.chImp4.TabIndex = 190
        Me.chImp4.UseVisualStyleBackColor = False
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.Color.Transparent
        Me.Frame2.Controls.Add(Me.Command3)
        Me.Frame2.Controls.Add(Me.Command2)
        Me.Frame2.Controls.Add(Me.Command1)
        Me.Frame2.Controls.Add(Me.Impresora_1)
        Me.Frame2.Controls.Add(Me.Impresora_2)
        Me.Frame2.Controls.Add(Me.Impresora_3)
        Me.Frame2.Controls.Add(Me.BtRut3)
        Me.Frame2.Controls.Add(Me.FormatoAux1)
        Me.Frame2.Controls.Add(Me.BtRut4)
        Me.Frame2.Controls.Add(Me.FormatoAux2)
        Me.Frame2.Controls.Add(Me.BtRut5)
        Me.Frame2.Controls.Add(Me.FormatoAux3)
        Me.Frame2.Controls.Add(Me.Label47)
        Me.Frame2.Controls.Add(Me.Label7)
        Me.Frame2.ForeColor = System.Drawing.Color.White
        Me.Frame2.Location = New System.Drawing.Point(592, 379)
        Me.Frame2.Margin = New System.Windows.Forms.Padding(4)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(528, 141)
        Me.Frame2.TabIndex = 336
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Impresiones Adicionales"
        '
        'Command3
        '
        Me.Command3.BackColor = System.Drawing.SystemColors.Control
        Me.Command3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command3.Location = New System.Drawing.Point(495, 96)
        Me.Command3.Margin = New System.Windows.Forms.Padding(4)
        Me.Command3.Name = "Command3"
        Me.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command3.Size = New System.Drawing.Size(29, 27)
        Me.Command3.TabIndex = 69
        Me.Command3.Text = ".."
        Me.Command3.UseVisualStyleBackColor = False
        '
        'Command2
        '
        Me.Command2.BackColor = System.Drawing.SystemColors.Control
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command2.Location = New System.Drawing.Point(495, 67)
        Me.Command2.Margin = New System.Windows.Forms.Padding(4)
        Me.Command2.Name = "Command2"
        Me.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command2.Size = New System.Drawing.Size(29, 27)
        Me.Command2.TabIndex = 68
        Me.Command2.Text = ".."
        Me.Command2.UseVisualStyleBackColor = False
        '
        'Command1
        '
        Me.Command1.BackColor = System.Drawing.SystemColors.Control
        Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Command1.Location = New System.Drawing.Point(495, 37)
        Me.Command1.Margin = New System.Windows.Forms.Padding(4)
        Me.Command1.Name = "Command1"
        Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Command1.Size = New System.Drawing.Size(29, 27)
        Me.Command1.TabIndex = 67
        Me.Command1.Text = ".."
        Me.Command1.UseVisualStyleBackColor = False
        '
        'Impresora_1
        '
        Me.Impresora_1.AcceptsReturn = True
        Me.Impresora_1.BackColor = System.Drawing.SystemColors.Window
        Me.Impresora_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Impresora_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Impresora_1.Location = New System.Drawing.Point(172, 39)
        Me.Impresora_1.Margin = New System.Windows.Forms.Padding(4)
        Me.Impresora_1.MaxLength = 0
        Me.Impresora_1.Name = "Impresora_1"
        Me.Impresora_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Impresora_1.Size = New System.Drawing.Size(319, 22)
        Me.Impresora_1.TabIndex = 64
        '
        'Impresora_2
        '
        Me.Impresora_2.AcceptsReturn = True
        Me.Impresora_2.BackColor = System.Drawing.SystemColors.Window
        Me.Impresora_2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Impresora_2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Impresora_2.Location = New System.Drawing.Point(172, 69)
        Me.Impresora_2.Margin = New System.Windows.Forms.Padding(4)
        Me.Impresora_2.MaxLength = 0
        Me.Impresora_2.Name = "Impresora_2"
        Me.Impresora_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Impresora_2.Size = New System.Drawing.Size(319, 22)
        Me.Impresora_2.TabIndex = 63
        '
        'Impresora_3
        '
        Me.Impresora_3.AcceptsReturn = True
        Me.Impresora_3.BackColor = System.Drawing.SystemColors.Window
        Me.Impresora_3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Impresora_3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Impresora_3.Location = New System.Drawing.Point(172, 98)
        Me.Impresora_3.Margin = New System.Windows.Forms.Padding(4)
        Me.Impresora_3.MaxLength = 0
        Me.Impresora_3.Name = "Impresora_3"
        Me.Impresora_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Impresora_3.Size = New System.Drawing.Size(319, 22)
        Me.Impresora_3.TabIndex = 62
        '
        'BtRut3
        '
        Me.BtRut3.BackColor = System.Drawing.SystemColors.Control
        Me.BtRut3.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtRut3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtRut3.Location = New System.Drawing.Point(140, 38)
        Me.BtRut3.Margin = New System.Windows.Forms.Padding(4)
        Me.BtRut3.Name = "BtRut3"
        Me.BtRut3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BtRut3.Size = New System.Drawing.Size(27, 25)
        Me.BtRut3.TabIndex = 61
        Me.BtRut3.Text = ".."
        Me.BtRut3.UseVisualStyleBackColor = False
        '
        'FormatoAux1
        '
        Me.FormatoAux1.AcceptsReturn = True
        Me.FormatoAux1.BackColor = System.Drawing.SystemColors.Window
        Me.FormatoAux1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.FormatoAux1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormatoAux1.Location = New System.Drawing.Point(12, 39)
        Me.FormatoAux1.Margin = New System.Windows.Forms.Padding(4)
        Me.FormatoAux1.MaxLength = 20
        Me.FormatoAux1.Name = "FormatoAux1"
        Me.FormatoAux1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FormatoAux1.Size = New System.Drawing.Size(128, 22)
        Me.FormatoAux1.TabIndex = 60
        '
        'BtRut4
        '
        Me.BtRut4.BackColor = System.Drawing.SystemColors.Control
        Me.BtRut4.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtRut4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtRut4.Location = New System.Drawing.Point(140, 68)
        Me.BtRut4.Margin = New System.Windows.Forms.Padding(4)
        Me.BtRut4.Name = "BtRut4"
        Me.BtRut4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BtRut4.Size = New System.Drawing.Size(27, 25)
        Me.BtRut4.TabIndex = 59
        Me.BtRut4.Text = ".."
        Me.BtRut4.UseVisualStyleBackColor = False
        '
        'FormatoAux2
        '
        Me.FormatoAux2.AcceptsReturn = True
        Me.FormatoAux2.BackColor = System.Drawing.SystemColors.Window
        Me.FormatoAux2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.FormatoAux2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormatoAux2.Location = New System.Drawing.Point(12, 69)
        Me.FormatoAux2.Margin = New System.Windows.Forms.Padding(4)
        Me.FormatoAux2.MaxLength = 20
        Me.FormatoAux2.Name = "FormatoAux2"
        Me.FormatoAux2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FormatoAux2.Size = New System.Drawing.Size(128, 22)
        Me.FormatoAux2.TabIndex = 58
        '
        'BtRut5
        '
        Me.BtRut5.BackColor = System.Drawing.SystemColors.Control
        Me.BtRut5.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtRut5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtRut5.Location = New System.Drawing.Point(140, 97)
        Me.BtRut5.Margin = New System.Windows.Forms.Padding(4)
        Me.BtRut5.Name = "BtRut5"
        Me.BtRut5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BtRut5.Size = New System.Drawing.Size(27, 25)
        Me.BtRut5.TabIndex = 57
        Me.BtRut5.Text = ".."
        Me.BtRut5.UseVisualStyleBackColor = False
        '
        'FormatoAux3
        '
        Me.FormatoAux3.AcceptsReturn = True
        Me.FormatoAux3.BackColor = System.Drawing.SystemColors.Window
        Me.FormatoAux3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.FormatoAux3.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FormatoAux3.Location = New System.Drawing.Point(12, 98)
        Me.FormatoAux3.Margin = New System.Windows.Forms.Padding(4)
        Me.FormatoAux3.MaxLength = 20
        Me.FormatoAux3.Name = "FormatoAux3"
        Me.FormatoAux3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FormatoAux3.Size = New System.Drawing.Size(128, 22)
        Me.FormatoAux3.TabIndex = 56
        '
        'Label47
        '
        Me.Label47.BackColor = System.Drawing.Color.Transparent
        Me.Label47.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label47.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label47.Location = New System.Drawing.Point(289, 23)
        Me.Label47.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label47.Name = "Label47"
        Me.Label47.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label47.Size = New System.Drawing.Size(77, 16)
        Me.Label47.TabIndex = 66
        Me.Label47.Text = "Impresora"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(23, 23)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(116, 16)
        Me.Label7.TabIndex = 65
        Me.Label7.Text = "Formato Tekform"
        '
        'Frame4
        '
        Me.Frame4.BackColor = System.Drawing.Color.Transparent
        Me.Frame4.Controls.Add(Me.Label3)
        Me.Frame4.Controls.Add(Me.ChkNumerar)
        Me.Frame4.Controls.Add(Me.Check3)
        Me.Frame4.Controls.Add(Me.Check5)
        Me.Frame4.Controls.Add(Me.Check6)
        Me.Frame4.ForeColor = System.Drawing.Color.White
        Me.Frame4.Location = New System.Drawing.Point(840, 25)
        Me.Frame4.Margin = New System.Windows.Forms.Padding(4)
        Me.Frame4.Name = "Frame4"
        Me.Frame4.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame4.Size = New System.Drawing.Size(273, 159)
        Me.Frame4.TabIndex = 333
        Me.Frame4.TabStop = False
        Me.Frame4.Text = "Reglas para la numeración "
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(5, 63)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(273, 34)
        Me.Label3.TabIndex = 260
        Me.Label3.Text = "Campos adicionales para controlar el número único"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ChkNumerar
        '
        Me.ChkNumerar.BackColor = System.Drawing.Color.Transparent
        Me.ChkNumerar.Cursor = System.Windows.Forms.Cursors.Default
        Me.ChkNumerar.ForeColor = System.Drawing.Color.Black
        Me.ChkNumerar.Location = New System.Drawing.Point(12, 28)
        Me.ChkNumerar.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkNumerar.Name = "ChkNumerar"
        Me.ChkNumerar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ChkNumerar.Size = New System.Drawing.Size(273, 25)
        Me.ChkNumerar.TabIndex = 259
        Me.ChkNumerar.Text = "Asignar el número automáticamente"
        Me.ChkNumerar.UseVisualStyleBackColor = False
        '
        'Check3
        '
        Me.Check3.BackColor = System.Drawing.Color.Transparent
        Me.Check3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Check3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Check3.Location = New System.Drawing.Point(12, 100)
        Me.Check3.Margin = New System.Windows.Forms.Padding(4)
        Me.Check3.Name = "Check3"
        Me.Check3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Check3.Size = New System.Drawing.Size(108, 21)
        Me.Check3.TabIndex = 35
        Me.Check3.Text = "Propietario"
        Me.Check3.UseVisualStyleBackColor = False
        '
        'Check5
        '
        Me.Check5.BackColor = System.Drawing.Color.Transparent
        Me.Check5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Check5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Check5.Location = New System.Drawing.Point(139, 127)
        Me.Check5.Margin = New System.Windows.Forms.Padding(4)
        Me.Check5.Name = "Check5"
        Me.Check5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Check5.Size = New System.Drawing.Size(117, 21)
        Me.Check5.TabIndex = 37
        Me.Check5.Text = "Id.Tributario"
        Me.Check5.UseVisualStyleBackColor = False
        '
        'Check6
        '
        Me.Check6.BackColor = System.Drawing.Color.Transparent
        Me.Check6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Check6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Check6.Location = New System.Drawing.Point(12, 126)
        Me.Check6.Margin = New System.Windows.Forms.Padding(4)
        Me.Check6.Name = "Check6"
        Me.Check6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Check6.Size = New System.Drawing.Size(89, 21)
        Me.Check6.TabIndex = 36
        Me.Check6.Text = "Bodega"
        Me.Check6.UseVisualStyleBackColor = False
        '
        'Check7
        '
        Me.Check7.BackColor = System.Drawing.Color.Transparent
        Me.Check7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Check7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Check7.Location = New System.Drawing.Point(345, 53)
        Me.Check7.Margin = New System.Windows.Forms.Padding(4)
        Me.Check7.Name = "Check7"
        Me.Check7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Check7.Size = New System.Drawing.Size(351, 22)
        Me.Check7.TabIndex = 332
        Me.Check7.Text = "Documento necesita aprobación para activarse"
        Me.Check7.UseVisualStyleBackColor = False
        '
        'chRefInv
        '
        Me.chRefInv.BackColor = System.Drawing.Color.Transparent
        Me.chRefInv.Cursor = System.Windows.Forms.Cursors.Default
        Me.chRefInv.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chRefInv.Location = New System.Drawing.Point(13, 75)
        Me.chRefInv.Margin = New System.Windows.Forms.Padding(4)
        Me.chRefInv.Name = "chRefInv"
        Me.chRefInv.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chRefInv.Size = New System.Drawing.Size(339, 22)
        Me.chRefInv.TabIndex = 331
        Me.chRefInv.Text = "Registrar movimiento en Inventario de artículos"
        Me.chRefInv.UseVisualStyleBackColor = False
        Me.chRefInv.Visible = False
        '
        'chRefCon
        '
        Me.chRefCon.BackColor = System.Drawing.Color.Transparent
        Me.chRefCon.Cursor = System.Windows.Forms.Cursors.Default
        Me.chRefCon.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chRefCon.Location = New System.Drawing.Point(13, 55)
        Me.chRefCon.Margin = New System.Windows.Forms.Padding(4)
        Me.chRefCon.Name = "chRefCon"
        Me.chRefCon.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chRefCon.Size = New System.Drawing.Size(261, 22)
        Me.chRefCon.TabIndex = 330
        Me.chRefCon.Text = "Registrar movimiento contable"
        Me.chRefCon.UseVisualStyleBackColor = False
        Me.chRefCon.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(36, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(121, 21)
        Me.Label1.TabIndex = 350
        Me.Label1.Text = "Grupo funcional:"
        '
        'TabDatos
        '
        Me.TabDatos.Controls.Add(Me.TableLayoutPanel1)
        Me.TabDatos.Location = New System.Drawing.Point(15, 122)
        Me.TabDatos.Margin = New System.Windows.Forms.Padding(4)
        Me.TabDatos.Name = "TabDatos"
        Me.TabDatos.Padding = New System.Windows.Forms.Padding(4)
        Me.TabDatos.Size = New System.Drawing.Size(1132, 529)
        Me.TabDatos.TabIndex = 251
        Me.TabDatos.TabStop = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Frame5, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox2, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(4, 19)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1124, 506)
        Me.TableLayoutPanel1.TabIndex = 245
        '
        'Frame5
        '
        Me.Frame5.BackColor = System.Drawing.Color.Transparent
        Me.Frame5.Controls.Add(Me.ListItems)
        Me.Frame5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Frame5.ForeColor = System.Drawing.Color.White
        Me.Frame5.Location = New System.Drawing.Point(4, 257)
        Me.Frame5.Margin = New System.Windows.Forms.Padding(4)
        Me.Frame5.Name = "Frame5"
        Me.Frame5.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame5.Size = New System.Drawing.Size(1116, 245)
        Me.Frame5.TabIndex = 207
        Me.Frame5.TabStop = False
        Me.Frame5.Text = "Datos adicionales para registrar en cada item de detalle del documento"
        '
        'ListItems
        '
        Me.ListItems.BackColor = System.Drawing.Color.White
        Me.ListItems.CheckOnClick = True
        Me.ListItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListItems.ForeColor = System.Drawing.Color.Black
        Me.ListItems.Location = New System.Drawing.Point(0, 15)
        Me.ListItems.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.ListItems.Name = "ListItems"
        Me.ListItems.Size = New System.Drawing.Size(1116, 230)
        Me.ListItems.TabIndex = 216
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.ListCabecera)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(7, 6)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox2.Size = New System.Drawing.Size(1110, 241)
        Me.GroupBox2.TabIndex = 206
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos adicionales para registrar en la cabecera del documento"
        '
        'ListCabecera
        '
        Me.ListCabecera.BackColor = System.Drawing.Color.White
        Me.ListCabecera.CheckOnClick = True
        Me.ListCabecera.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListCabecera.ForeColor = System.Drawing.Color.Black
        Me.ListCabecera.Location = New System.Drawing.Point(0, 15)
        Me.ListCabecera.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.ListCabecera.MultiColumn = True
        Me.ListCabecera.Name = "ListCabecera"
        Me.ListCabecera.Size = New System.Drawing.Size(1110, 226)
        Me.ListCabecera.TabIndex = 213
        '
        'TabInventario
        '
        Me.TabInventario.Controls.Add(Me.GroupBox1)
        Me.TabInventario.Controls.Add(Me.Frame1)
        Me.TabInventario.Controls.Add(Me.chGenSinExi)
        Me.TabInventario.Controls.Add(Me.chRepCodFil)
        Me.TabInventario.Controls.Add(Me.chGuaUltCom)
        Me.TabInventario.Controls.Add(Me.RegistraCantCero)
        Me.TabInventario.Location = New System.Drawing.Point(16, 122)
        Me.TabInventario.Margin = New System.Windows.Forms.Padding(4)
        Me.TabInventario.Name = "TabInventario"
        Me.TabInventario.Padding = New System.Windows.Forms.Padding(4)
        Me.TabInventario.Size = New System.Drawing.Size(1131, 522)
        Me.TabInventario.TabIndex = 252
        Me.TabInventario.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ComboDoc1)
        Me.GroupBox1.Controls.Add(Me.Label50)
        Me.GroupBox1.Controls.Add(Me.GeneraSalidaMP)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(19, 187)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(536, 167)
        Me.GroupBox1.TabIndex = 205
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Productos Compuestos"
        '
        'ComboDoc1
        '
        Me.ComboDoc1.FormattingEnabled = True
        Me.ComboDoc1.Location = New System.Drawing.Point(15, 103)
        Me.ComboDoc1.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboDoc1.Name = "ComboDoc1"
        Me.ComboDoc1.Size = New System.Drawing.Size(508, 24)
        Me.ComboDoc1.TabIndex = 196
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.ForeColor = System.Drawing.Color.Black
        Me.Label50.Location = New System.Drawing.Point(11, 84)
        Me.Label50.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(176, 17)
        Me.Label50.TabIndex = 195
        Me.Label50.Text = "Tipo documento a generar"
        '
        'GeneraSalidaMP
        '
        Me.GeneraSalidaMP.BackColor = System.Drawing.Color.Transparent
        Me.GeneraSalidaMP.Cursor = System.Windows.Forms.Cursors.Default
        Me.GeneraSalidaMP.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GeneraSalidaMP.Location = New System.Drawing.Point(28, 36)
        Me.GeneraSalidaMP.Margin = New System.Windows.Forms.Padding(4)
        Me.GeneraSalidaMP.Name = "GeneraSalidaMP"
        Me.GeneraSalidaMP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GeneraSalidaMP.Size = New System.Drawing.Size(507, 22)
        Me.GeneraSalidaMP.TabIndex = 193
        Me.GeneraSalidaMP.Text = "Registrar en inventarios la salida de componentes del producto fabricado"
        Me.GeneraSalidaMP.UseVisualStyleBackColor = False
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.Color.Transparent
        Me.Frame1.Controls.Add(Me.CmbClasificadorCosteo)
        Me.Frame1.Controls.Add(Me.OpCosLiqClas)
        Me.Frame1.Controls.Add(Me.OpCosLiq)
        Me.Frame1.Controls.Add(Me.opCosNin)
        Me.Frame1.Controls.Add(Me.opCosDig)
        Me.Frame1.Controls.Add(Me.opCosUlt)
        Me.Frame1.Controls.Add(Me.opCosPro)
        Me.Frame1.ForeColor = System.Drawing.Color.White
        Me.Frame1.Location = New System.Drawing.Point(584, 36)
        Me.Frame1.Margin = New System.Windows.Forms.Padding(4)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(536, 236)
        Me.Frame1.TabIndex = 204
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Tipo de registro de costos"
        '
        'CmbClasificadorCosteo
        '
        Me.CmbClasificadorCosteo.Enabled = False
        Me.CmbClasificadorCosteo.FormattingEnabled = True
        Me.CmbClasificadorCosteo.Location = New System.Drawing.Point(43, 182)
        Me.CmbClasificadorCosteo.Margin = New System.Windows.Forms.Padding(4)
        Me.CmbClasificadorCosteo.Name = "CmbClasificadorCosteo"
        Me.CmbClasificadorCosteo.Size = New System.Drawing.Size(268, 24)
        Me.CmbClasificadorCosteo.TabIndex = 190
        '
        'OpCosLiqClas
        '
        Me.OpCosLiqClas.BackColor = System.Drawing.Color.Transparent
        Me.OpCosLiqClas.Cursor = System.Windows.Forms.Cursors.Default
        Me.OpCosLiqClas.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OpCosLiqClas.Location = New System.Drawing.Point(21, 139)
        Me.OpCosLiqClas.Margin = New System.Windows.Forms.Padding(4)
        Me.OpCosLiqClas.Name = "OpCosLiqClas"
        Me.OpCosLiqClas.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OpCosLiqClas.Size = New System.Drawing.Size(501, 49)
        Me.OpCosLiqClas.TabIndex = 189
        Me.OpCosLiqClas.TabStop = True
        Me.OpCosLiqClas.Text = "Liquidar el costo con el precio de adquisición mas gastos registrados contablemen" &
    "te en el siguiente clasificador:"
        Me.OpCosLiqClas.UseVisualStyleBackColor = False
        '
        'opCosNin
        '
        Me.opCosNin.BackColor = System.Drawing.Color.Transparent
        Me.opCosNin.Cursor = System.Windows.Forms.Cursors.Default
        Me.opCosNin.ForeColor = System.Drawing.SystemColors.ControlText
        Me.opCosNin.Location = New System.Drawing.Point(21, 75)
        Me.opCosNin.Margin = New System.Windows.Forms.Padding(4)
        Me.opCosNin.Name = "opCosNin"
        Me.opCosNin.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.opCosNin.Size = New System.Drawing.Size(400, 25)
        Me.opCosNin.TabIndex = 188
        Me.opCosNin.TabStop = True
        Me.opCosNin.Text = "Los artículos se registran con costo cero"
        Me.opCosNin.UseVisualStyleBackColor = False
        '
        'opCosDig
        '
        Me.opCosDig.BackColor = System.Drawing.Color.Transparent
        Me.opCosDig.Cursor = System.Windows.Forms.Cursors.Default
        Me.opCosDig.ForeColor = System.Drawing.SystemColors.ControlText
        Me.opCosDig.Location = New System.Drawing.Point(21, 49)
        Me.opCosDig.Margin = New System.Windows.Forms.Padding(4)
        Me.opCosDig.Name = "opCosDig"
        Me.opCosDig.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.opCosDig.Size = New System.Drawing.Size(400, 25)
        Me.opCosDig.TabIndex = 187
        Me.opCosDig.TabStop = True
        Me.opCosDig.Text = "El costo debe ser digitado por el usuario"
        Me.opCosDig.UseVisualStyleBackColor = False
        '
        'opCosUlt
        '
        Me.opCosUlt.BackColor = System.Drawing.Color.Transparent
        Me.opCosUlt.Cursor = System.Windows.Forms.Cursors.Default
        Me.opCosUlt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.opCosUlt.Location = New System.Drawing.Point(43, 126)
        Me.opCosUlt.Margin = New System.Windows.Forms.Padding(4)
        Me.opCosUlt.Name = "opCosUlt"
        Me.opCosUlt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.opCosUlt.Size = New System.Drawing.Size(400, 25)
        Me.opCosUlt.TabIndex = 186
        Me.opCosUlt.TabStop = True
        Me.opCosUlt.Text = "El sistema registra el último costo de adquisición "
        Me.opCosUlt.UseVisualStyleBackColor = False
        Me.opCosUlt.Visible = False
        '
        'opCosPro
        '
        Me.opCosPro.BackColor = System.Drawing.Color.Transparent
        Me.opCosPro.Checked = True
        Me.opCosPro.Cursor = System.Windows.Forms.Cursors.Default
        Me.opCosPro.ForeColor = System.Drawing.SystemColors.ControlText
        Me.opCosPro.Location = New System.Drawing.Point(21, 25)
        Me.opCosPro.Margin = New System.Windows.Forms.Padding(4)
        Me.opCosPro.Name = "opCosPro"
        Me.opCosPro.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.opCosPro.Size = New System.Drawing.Size(400, 25)
        Me.opCosPro.TabIndex = 185
        Me.opCosPro.TabStop = True
        Me.opCosPro.Text = "El sistema registra el costo promedio "
        Me.opCosPro.UseVisualStyleBackColor = False
        '
        'chGenSinExi
        '
        Me.chGenSinExi.BackColor = System.Drawing.Color.Transparent
        Me.chGenSinExi.Checked = True
        Me.chGenSinExi.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chGenSinExi.Cursor = System.Windows.Forms.Cursors.Default
        Me.chGenSinExi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chGenSinExi.Location = New System.Drawing.Point(51, 64)
        Me.chGenSinExi.Margin = New System.Windows.Forms.Padding(4)
        Me.chGenSinExi.Name = "chGenSinExi"
        Me.chGenSinExi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chGenSinExi.Size = New System.Drawing.Size(400, 31)
        Me.chGenSinExi.TabIndex = 203
        Me.chGenSinExi.Text = "Permitir saldos negativos en inventario"
        Me.chGenSinExi.UseVisualStyleBackColor = False
        Me.chGenSinExi.Visible = False
        '
        'chRepCodFil
        '
        Me.chRepCodFil.BackColor = System.Drawing.Color.Transparent
        Me.chRepCodFil.Cursor = System.Windows.Forms.Cursors.Default
        Me.chRepCodFil.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chRepCodFil.Location = New System.Drawing.Point(51, 89)
        Me.chRepCodFil.Margin = New System.Windows.Forms.Padding(4)
        Me.chRepCodFil.Name = "chRepCodFil"
        Me.chRepCodFil.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chRepCodFil.Size = New System.Drawing.Size(400, 31)
        Me.chRepCodFil.TabIndex = 202
        Me.chRepCodFil.Text = "Permite Repetir artículos en documentos "
        Me.chRepCodFil.UseVisualStyleBackColor = False
        Me.chRepCodFil.Visible = False
        '
        'chGuaUltCom
        '
        Me.chGuaUltCom.BackColor = System.Drawing.Color.Transparent
        Me.chGuaUltCom.Cursor = System.Windows.Forms.Cursors.Default
        Me.chGuaUltCom.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chGuaUltCom.Location = New System.Drawing.Point(51, 138)
        Me.chGuaUltCom.Margin = New System.Windows.Forms.Padding(4)
        Me.chGuaUltCom.Name = "chGuaUltCom"
        Me.chGuaUltCom.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chGuaUltCom.Size = New System.Drawing.Size(400, 31)
        Me.chGuaUltCom.TabIndex = 201
        Me.chGuaUltCom.Text = "El valor de los artículos guardar como último costo"
        Me.chGuaUltCom.UseVisualStyleBackColor = False
        Me.chGuaUltCom.Visible = False
        '
        'RegistraCantCero
        '
        Me.RegistraCantCero.BackColor = System.Drawing.Color.Transparent
        Me.RegistraCantCero.Cursor = System.Windows.Forms.Cursors.Default
        Me.RegistraCantCero.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RegistraCantCero.Location = New System.Drawing.Point(51, 113)
        Me.RegistraCantCero.Margin = New System.Windows.Forms.Padding(4)
        Me.RegistraCantCero.Name = "RegistraCantCero"
        Me.RegistraCantCero.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RegistraCantCero.Size = New System.Drawing.Size(400, 31)
        Me.RegistraCantCero.TabIndex = 200
        Me.RegistraCantCero.Text = "Permitir registro de cantidad de artículos en cero"
        Me.RegistraCantCero.UseVisualStyleBackColor = False
        '
        'TabContabilidad
        '
        Me.TabContabilidad.Controls.Add(Me.chKNoEnLinea)
        Me.TabContabilidad.Controls.Add(Me.ChkCdreNOUSADO)
        Me.TabContabilidad.Controls.Add(Me.txtValVenOIvaD)
        Me.TabContabilidad.Controls.Add(Me.txtValVenOIvaH)
        Me.TabContabilidad.Controls.Add(Me.Label42)
        Me.TabContabilidad.Controls.Add(Me.Label17)
        Me.TabContabilidad.Controls.Add(Me.lbValVtaOIva)
        Me.TabContabilidad.Controls.Add(Me.Text1)
        Me.TabContabilidad.Controls.Add(Me.ChkCdreTotal)
        Me.TabContabilidad.Controls.Add(Me.txtValTotDocD)
        Me.TabContabilidad.Controls.Add(Me.Reconta)
        Me.TabContabilidad.Controls.Add(Me.txtValTotDocH)
        Me.TabContabilidad.Controls.Add(Me.frConInd)
        Me.TabContabilidad.Controls.Add(Me.Label29)
        Me.TabContabilidad.Controls.Add(Me.Label30)
        Me.TabContabilidad.Controls.Add(Me.Label31)
        Me.TabContabilidad.Controls.Add(Me.Label14)
        Me.TabContabilidad.Controls.Add(Me.Label19)
        Me.TabContabilidad.Controls.Add(Me.Label48)
        Me.TabContabilidad.Controls.Add(Me.Label49)
        Me.TabContabilidad.Controls.Add(Me.FrmSri)
        Me.TabContabilidad.Controls.Add(Me.FrmOtros)
        Me.TabContabilidad.Controls.Add(Me.chGenComDes)
        Me.TabContabilidad.Location = New System.Drawing.Point(16, 122)
        Me.TabContabilidad.Margin = New System.Windows.Forms.Padding(4)
        Me.TabContabilidad.Name = "TabContabilidad"
        Me.TabContabilidad.Padding = New System.Windows.Forms.Padding(4)
        Me.TabContabilidad.Size = New System.Drawing.Size(1131, 518)
        Me.TabContabilidad.TabIndex = 253
        Me.TabContabilidad.TabStop = False
        '
        'chKNoEnLinea
        '
        Me.chKNoEnLinea.BackColor = System.Drawing.Color.Transparent
        Me.chKNoEnLinea.Checked = True
        Me.chKNoEnLinea.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chKNoEnLinea.Cursor = System.Windows.Forms.Cursors.Default
        Me.chKNoEnLinea.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chKNoEnLinea.Location = New System.Drawing.Point(24, 34)
        Me.chKNoEnLinea.Margin = New System.Windows.Forms.Padding(4)
        Me.chKNoEnLinea.Name = "chKNoEnLinea"
        Me.chKNoEnLinea.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chKNoEnLinea.Size = New System.Drawing.Size(400, 25)
        Me.chKNoEnLinea.TabIndex = 310
        Me.chKNoEnLinea.Text = "No contabilizar en Linea"
        Me.chKNoEnLinea.UseVisualStyleBackColor = False
        '
        'ChkCdreNOUSADO
        '
        Me.ChkCdreNOUSADO.AcceptsReturn = True
        Me.ChkCdreNOUSADO.BackColor = System.Drawing.SystemColors.Window
        Me.ChkCdreNOUSADO.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChkCdreNOUSADO.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ChkCdreNOUSADO.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ChkCdreNOUSADO.Location = New System.Drawing.Point(1032, 132)
        Me.ChkCdreNOUSADO.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkCdreNOUSADO.MaxLength = 1
        Me.ChkCdreNOUSADO.Name = "ChkCdreNOUSADO"
        Me.ChkCdreNOUSADO.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ChkCdreNOUSADO.Size = New System.Drawing.Size(23, 15)
        Me.ChkCdreNOUSADO.TabIndex = 309
        Me.ChkCdreNOUSADO.Visible = False
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label42.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label42.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label42.Location = New System.Drawing.Point(768, 132)
        Me.Label42.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label42.Name = "Label42"
        Me.Label42.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label42.Size = New System.Drawing.Size(240, 27)
        Me.Label42.TabIndex = 308
        Me.Label42.Visible = False
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label17.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label17.Location = New System.Drawing.Point(364, 132)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(240, 27)
        Me.Label17.TabIndex = 307
        Me.Label17.Visible = False
        '
        'lbValVtaOIva
        '
        Me.lbValVtaOIva.AutoSize = True
        Me.lbValVtaOIva.BackColor = System.Drawing.Color.Transparent
        Me.lbValVtaOIva.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbValVtaOIva.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbValVtaOIva.Location = New System.Drawing.Point(45, 132)
        Me.lbValVtaOIva.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbValVtaOIva.Name = "lbValVtaOIva"
        Me.lbValVtaOIva.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbValVtaOIva.Size = New System.Drawing.Size(82, 17)
        Me.lbValVtaOIva.TabIndex = 306
        Me.lbValVtaOIva.Text = "No utilizado"
        Me.lbValVtaOIva.Visible = False
        '
        'Text1
        '
        Me.Text1.AcceptsReturn = True
        Me.Text1.BackColor = System.Drawing.SystemColors.Window
        Me.Text1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Text1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Text1.Location = New System.Drawing.Point(1000, 20)
        Me.Text1.Margin = New System.Windows.Forms.Padding(4)
        Me.Text1.MaxLength = 0
        Me.Text1.Name = "Text1"
        Me.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text1.Size = New System.Drawing.Size(75, 22)
        Me.Text1.TabIndex = 301
        '
        'ChkCdreTotal
        '
        Me.ChkCdreTotal.AcceptsReturn = True
        Me.ChkCdreTotal.BackColor = System.Drawing.SystemColors.Window
        Me.ChkCdreTotal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChkCdreTotal.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ChkCdreTotal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ChkCdreTotal.Location = New System.Drawing.Point(1031, 101)
        Me.ChkCdreTotal.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkCdreTotal.MaxLength = 1
        Me.ChkCdreTotal.Name = "ChkCdreTotal"
        Me.ChkCdreTotal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ChkCdreTotal.Size = New System.Drawing.Size(23, 15)
        Me.ChkCdreTotal.TabIndex = 298
        '
        'Reconta
        '
        Me.Reconta.BackColor = System.Drawing.Color.Transparent
        Me.Reconta.Checked = True
        Me.Reconta.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Reconta.Cursor = System.Windows.Forms.Cursors.Default
        Me.Reconta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Reconta.Location = New System.Drawing.Point(24, 15)
        Me.Reconta.Margin = New System.Windows.Forms.Padding(4)
        Me.Reconta.Name = "Reconta"
        Me.Reconta.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Reconta.Size = New System.Drawing.Size(400, 25)
        Me.Reconta.TabIndex = 283
        Me.Reconta.Text = "Permitir Recontabilización en grupo"
        Me.Reconta.UseVisualStyleBackColor = False
        '
        'frConInd
        '
        Me.frConInd.BackColor = System.Drawing.Color.Transparent
        Me.frConInd.Controls.Add(Me.chOtrSIva)
        Me.frConInd.Controls.Add(Me.chOtrCIva)
        Me.frConInd.Controls.Add(Me.chDes)
        Me.frConInd.Controls.Add(Me.chArt)
        Me.frConInd.ForeColor = System.Drawing.Color.DarkGray
        Me.frConInd.Location = New System.Drawing.Point(45, 449)
        Me.frConInd.Margin = New System.Windows.Forms.Padding(4)
        Me.frConInd.Name = "frConInd"
        Me.frConInd.Padding = New System.Windows.Forms.Padding(0)
        Me.frConInd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frConInd.Size = New System.Drawing.Size(127, 55)
        Me.frConInd.TabIndex = 288
        Me.frConInd.TabStop = False
        Me.frConInd.Text = "Realizar un asiento contable por cada:"
        Me.frConInd.Visible = False
        '
        'chOtrSIva
        '
        Me.chOtrSIva.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chOtrSIva.Checked = True
        Me.chOtrSIva.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chOtrSIva.Cursor = System.Windows.Forms.Cursors.Default
        Me.chOtrSIva.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chOtrSIva.Location = New System.Drawing.Point(459, 20)
        Me.chOtrSIva.Margin = New System.Windows.Forms.Padding(4)
        Me.chOtrSIva.Name = "chOtrSIva"
        Me.chOtrSIva.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chOtrSIva.Size = New System.Drawing.Size(161, 16)
        Me.chOtrSIva.TabIndex = 76
        Me.chOtrSIva.Text = "Servicio/Otro sin IVA"
        Me.chOtrSIva.UseVisualStyleBackColor = False
        '
        'chOtrCIva
        '
        Me.chOtrCIva.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chOtrCIva.Checked = True
        Me.chOtrCIva.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chOtrCIva.Cursor = System.Windows.Forms.Cursors.Default
        Me.chOtrCIva.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chOtrCIva.Location = New System.Drawing.Point(704, 20)
        Me.chOtrCIva.Margin = New System.Windows.Forms.Padding(4)
        Me.chOtrCIva.Name = "chOtrCIva"
        Me.chOtrCIva.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chOtrCIva.Size = New System.Drawing.Size(172, 16)
        Me.chOtrCIva.TabIndex = 75
        Me.chOtrCIva.Text = "Servicios/Otro con IVA"
        Me.chOtrCIva.UseVisualStyleBackColor = False
        '
        'chDes
        '
        Me.chDes.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chDes.Checked = True
        Me.chDes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chDes.Cursor = System.Windows.Forms.Cursors.Default
        Me.chDes.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chDes.Location = New System.Drawing.Point(224, 20)
        Me.chDes.Margin = New System.Windows.Forms.Padding(4)
        Me.chDes.Name = "chDes"
        Me.chDes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chDes.Size = New System.Drawing.Size(108, 16)
        Me.chDes.TabIndex = 74
        Me.chDes.Text = "Descuento"
        Me.chDes.UseVisualStyleBackColor = False
        '
        'chArt
        '
        Me.chArt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chArt.Checked = True
        Me.chArt.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chArt.Cursor = System.Windows.Forms.Cursors.Default
        Me.chArt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chArt.Location = New System.Drawing.Point(11, 20)
        Me.chArt.Margin = New System.Windows.Forms.Padding(4)
        Me.chArt.Name = "chArt"
        Me.chArt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chArt.Size = New System.Drawing.Size(76, 16)
        Me.chArt.TabIndex = 73
        Me.chArt.Text = "Artículo"
        Me.chArt.UseVisualStyleBackColor = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label29.ForeColor = System.Drawing.Color.Gray
        Me.Label29.Location = New System.Drawing.Point(637, 79)
        Me.Label29.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label29.Size = New System.Drawing.Size(348, 17)
        Me.Label29.TabIndex = 295
        Me.Label29.Text = "CUENTA CONTABLE A REGISTRAR EN EL CRÉDITO"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label30.ForeColor = System.Drawing.Color.Gray
        Me.Label30.Location = New System.Drawing.Point(237, 79)
        Me.Label30.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label30.Size = New System.Drawing.Size(338, 17)
        Me.Label30.TabIndex = 294
        Me.Label30.Text = "CUENTA CONTABLE A REGISTRAR EN EL DÉBITO"
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label31.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label31.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label31.Location = New System.Drawing.Point(768, 101)
        Me.Label31.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label31.Name = "Label31"
        Me.Label31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label31.Size = New System.Drawing.Size(240, 27)
        Me.Label31.TabIndex = 293
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label14.Location = New System.Drawing.Point(364, 101)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(240, 27)
        Me.Label14.TabIndex = 292
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(45, 101)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label19.Size = New System.Drawing.Size(146, 17)
        Me.Label19.TabIndex = 291
        Me.Label19.Text = "Valor total documento"
        '
        'Label48
        '
        Me.Label48.BackColor = System.Drawing.Color.Transparent
        Me.Label48.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label48.ForeColor = System.Drawing.Color.Gray
        Me.Label48.Location = New System.Drawing.Point(989, 50)
        Me.Label48.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label48.Name = "Label48"
        Me.Label48.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label48.Size = New System.Drawing.Size(104, 50)
        Me.Label48.TabIndex = 297
        Me.Label48.Text = "Prioridad Cuadre Automático"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label49
        '
        Me.Label49.BackColor = System.Drawing.Color.Transparent
        Me.Label49.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label49.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label49.Location = New System.Drawing.Point(557, 20)
        Me.Label49.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label49.Name = "Label49"
        Me.Label49.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label49.Size = New System.Drawing.Size(448, 25)
        Me.Label49.TabIndex = 300
        Me.Label49.Text = "Cuadra los asientos contables si el descuadre es menor o igual a:"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmSri
        '
        Me.FrmSri.BackColor = System.Drawing.Color.Transparent
        Me.FrmSri.Controls.Add(Me.ChkCdreRetFte2)
        Me.FrmSri.Controls.Add(Me.txtRetFte2H)
        Me.FrmSri.Controls.Add(Me.txtRetFte2D)
        Me.FrmSri.Controls.Add(Me.Label51)
        Me.FrmSri.Controls.Add(Me.Label52)
        Me.FrmSri.Controls.Add(Me.Label53)
        Me.FrmSri.Controls.Add(Me.ChkCdreRetFte1)
        Me.FrmSri.Controls.Add(Me.ChkCdreRetFte)
        Me.FrmSri.Controls.Add(Me.ChkCdreRetIvaServ)
        Me.FrmSri.Controls.Add(Me.ChkCdreRetIvaBien)
        Me.FrmSri.Controls.Add(Me.txtRetBieD)
        Me.FrmSri.Controls.Add(Me.txtRetBieH)
        Me.FrmSri.Controls.Add(Me.txtRetSerD)
        Me.FrmSri.Controls.Add(Me.txtRetSerH)
        Me.FrmSri.Controls.Add(Me.txtRetFteD)
        Me.FrmSri.Controls.Add(Me.txtRetFteH)
        Me.FrmSri.Controls.Add(Me.Label28)
        Me.FrmSri.Controls.Add(Me.txtRetFte1H)
        Me.FrmSri.Controls.Add(Me.txtRetFte1D)
        Me.FrmSri.Controls.Add(Me.Label9)
        Me.FrmSri.Controls.Add(Me.Label10)
        Me.FrmSri.Controls.Add(Me.Label11)
        Me.FrmSri.Controls.Add(Me.Label26)
        Me.FrmSri.Controls.Add(Me.Label27)
        Me.FrmSri.Controls.Add(Me.Label32)
        Me.FrmSri.Controls.Add(Me.Label33)
        Me.FrmSri.Controls.Add(Me.Label34)
        Me.FrmSri.Controls.Add(Me.Label4)
        Me.FrmSri.Controls.Add(Me.Label5)
        Me.FrmSri.Controls.Add(Me.Label6)
        Me.FrmSri.Cursor = System.Windows.Forms.Cursors.Default
        Me.FrmSri.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FrmSri.Location = New System.Drawing.Point(40, 127)
        Me.FrmSri.Margin = New System.Windows.Forms.Padding(4)
        Me.FrmSri.Name = "FrmSri"
        Me.FrmSri.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FrmSri.Size = New System.Drawing.Size(1036, 160)
        Me.FrmSri.TabIndex = 289
        '
        'ChkCdreRetFte2
        '
        Me.ChkCdreRetFte2.AcceptsReturn = True
        Me.ChkCdreRetFte2.BackColor = System.Drawing.SystemColors.Window
        Me.ChkCdreRetFte2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChkCdreRetFte2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ChkCdreRetFte2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ChkCdreRetFte2.Location = New System.Drawing.Point(992, 65)
        Me.ChkCdreRetFte2.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkCdreRetFte2.MaxLength = 1
        Me.ChkCdreRetFte2.Name = "ChkCdreRetFte2"
        Me.ChkCdreRetFte2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ChkCdreRetFte2.Size = New System.Drawing.Size(23, 15)
        Me.ChkCdreRetFte2.TabIndex = 228
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label51.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label51.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label51.Location = New System.Drawing.Point(728, 65)
        Me.Label51.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label51.Name = "Label51"
        Me.Label51.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label51.Size = New System.Drawing.Size(240, 27)
        Me.Label51.TabIndex = 227
        '
        'Label52
        '
        Me.Label52.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label52.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label52.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label52.Location = New System.Drawing.Point(324, 65)
        Me.Label52.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label52.Name = "Label52"
        Me.Label52.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label52.Size = New System.Drawing.Size(240, 27)
        Me.Label52.TabIndex = 226
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.BackColor = System.Drawing.Color.Transparent
        Me.Label53.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label53.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label53.Location = New System.Drawing.Point(5, 65)
        Me.Label53.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label53.Name = "Label53"
        Me.Label53.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label53.Size = New System.Drawing.Size(152, 17)
        Me.Label53.TabIndex = 225
        Me.Label53.Text = "Retención Imp. Renta2"
        '
        'ChkCdreRetFte1
        '
        Me.ChkCdreRetFte1.AcceptsReturn = True
        Me.ChkCdreRetFte1.BackColor = System.Drawing.SystemColors.Window
        Me.ChkCdreRetFte1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChkCdreRetFte1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ChkCdreRetFte1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ChkCdreRetFte1.Location = New System.Drawing.Point(991, 34)
        Me.ChkCdreRetFte1.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkCdreRetFte1.MaxLength = 1
        Me.ChkCdreRetFte1.Name = "ChkCdreRetFte1"
        Me.ChkCdreRetFte1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ChkCdreRetFte1.Size = New System.Drawing.Size(23, 15)
        Me.ChkCdreRetFte1.TabIndex = 222
        '
        'ChkCdreRetFte
        '
        Me.ChkCdreRetFte.AcceptsReturn = True
        Me.ChkCdreRetFte.BackColor = System.Drawing.SystemColors.Window
        Me.ChkCdreRetFte.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChkCdreRetFte.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ChkCdreRetFte.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ChkCdreRetFte.Location = New System.Drawing.Point(991, 4)
        Me.ChkCdreRetFte.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkCdreRetFte.MaxLength = 1
        Me.ChkCdreRetFte.Name = "ChkCdreRetFte"
        Me.ChkCdreRetFte.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ChkCdreRetFte.Size = New System.Drawing.Size(23, 15)
        Me.ChkCdreRetFte.TabIndex = 221
        '
        'ChkCdreRetIvaServ
        '
        Me.ChkCdreRetIvaServ.AcceptsReturn = True
        Me.ChkCdreRetIvaServ.BackColor = System.Drawing.SystemColors.Window
        Me.ChkCdreRetIvaServ.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChkCdreRetIvaServ.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ChkCdreRetIvaServ.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ChkCdreRetIvaServ.Location = New System.Drawing.Point(992, 127)
        Me.ChkCdreRetIvaServ.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkCdreRetIvaServ.MaxLength = 1
        Me.ChkCdreRetIvaServ.Name = "ChkCdreRetIvaServ"
        Me.ChkCdreRetIvaServ.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ChkCdreRetIvaServ.Size = New System.Drawing.Size(23, 15)
        Me.ChkCdreRetIvaServ.TabIndex = 220
        '
        'ChkCdreRetIvaBien
        '
        Me.ChkCdreRetIvaBien.AcceptsReturn = True
        Me.ChkCdreRetIvaBien.BackColor = System.Drawing.SystemColors.Window
        Me.ChkCdreRetIvaBien.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChkCdreRetIvaBien.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ChkCdreRetIvaBien.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ChkCdreRetIvaBien.Location = New System.Drawing.Point(992, 96)
        Me.ChkCdreRetIvaBien.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkCdreRetIvaBien.MaxLength = 1
        Me.ChkCdreRetIvaBien.Name = "ChkCdreRetIvaBien"
        Me.ChkCdreRetIvaBien.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ChkCdreRetIvaBien.Size = New System.Drawing.Size(23, 15)
        Me.ChkCdreRetIvaBien.TabIndex = 219
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label28.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label28.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label28.Location = New System.Drawing.Point(324, 4)
        Me.Label28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label28.Size = New System.Drawing.Size(240, 27)
        Me.Label28.TabIndex = 100
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(5, 97)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(141, 17)
        Me.Label9.TabIndex = 105
        Me.Label9.Text = "Retención Iva Bienes"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(5, 127)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(148, 17)
        Me.Label10.TabIndex = 104
        Me.Label10.Text = "Retención Iva Servicio"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(5, 4)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(158, 17)
        Me.Label11.TabIndex = 103
        Me.Label11.Text = "Reten. Imp. Renta Total"
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label26.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label26.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label26.Location = New System.Drawing.Point(324, 96)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label26.Size = New System.Drawing.Size(240, 27)
        Me.Label26.TabIndex = 102
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label27.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label27.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label27.Location = New System.Drawing.Point(324, 127)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label27.Size = New System.Drawing.Size(240, 27)
        Me.Label27.TabIndex = 101
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label32.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label32.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label32.Location = New System.Drawing.Point(728, 4)
        Me.Label32.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label32.Size = New System.Drawing.Size(240, 27)
        Me.Label32.TabIndex = 99
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label33.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label33.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label33.Location = New System.Drawing.Point(728, 127)
        Me.Label33.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label33.Name = "Label33"
        Me.Label33.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label33.Size = New System.Drawing.Size(240, 27)
        Me.Label33.TabIndex = 98
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label34.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label34.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label34.Location = New System.Drawing.Point(728, 96)
        Me.Label34.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label34.Name = "Label34"
        Me.Label34.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label34.Size = New System.Drawing.Size(240, 27)
        Me.Label34.TabIndex = 97
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label4.Location = New System.Drawing.Point(728, 34)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(240, 27)
        Me.Label4.TabIndex = 96
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label5.Location = New System.Drawing.Point(324, 34)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(240, 27)
        Me.Label5.TabIndex = 95
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(5, 34)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(152, 17)
        Me.Label6.TabIndex = 94
        Me.Label6.Text = "Retención Imp. Renta1"
        '
        'FrmOtros
        '
        Me.FrmOtros.BackColor = System.Drawing.Color.Transparent
        Me.FrmOtros.Controls.Add(Me.ChkCdreCostoArticulos)
        Me.FrmOtros.Controls.Add(Me.ChkCdreImpuestos)
        Me.FrmOtros.Controls.Add(Me.ChkCdreDescuentosServicios)
        Me.FrmOtros.Controls.Add(Me.ChkCdreDescuentoArticulos)
        Me.FrmOtros.Controls.Add(Me.ChkCdreActivos)
        Me.FrmOtros.Controls.Add(Me.ChkCdreNOUTILIZADO2)
        Me.FrmOtros.Controls.Add(Me.ChkCdreConceptos)
        Me.FrmOtros.Controls.Add(Me.ChkCdreArticulos)
        Me.FrmOtros.Controls.Add(Me.txtValVenInvD)
        Me.FrmOtros.Controls.Add(Me.txtSubVenCIvaD)
        Me.FrmOtros.Controls.Add(Me.txtSubVenCIvaH)
        Me.FrmOtros.Controls.Add(Me.txtValDesD)
        Me.FrmOtros.Controls.Add(Me.txtValDesH)
        Me.FrmOtros.Controls.Add(Me.txtValNetVenD)
        Me.FrmOtros.Controls.Add(Me.txtValNetVenH)
        Me.FrmOtros.Controls.Add(Me.txtIvaD)
        Me.FrmOtros.Controls.Add(Me.txtIvaH)
        Me.FrmOtros.Controls.Add(Me.txtOtrSIvaD)
        Me.FrmOtros.Controls.Add(Me.txtOtrSIvaH)
        Me.FrmOtros.Controls.Add(Me.txtTotDesIndD)
        Me.FrmOtros.Controls.Add(Me.txtTotDesIndH)
        Me.FrmOtros.Controls.Add(Me.txtCtaCosH)
        Me.FrmOtros.Controls.Add(Me.txtCtaCosD)
        Me.FrmOtros.Controls.Add(Me.txtValVenInvH)
        Me.FrmOtros.Controls.Add(Me.Label43)
        Me.FrmOtros.Controls.Add(Me.Label41)
        Me.FrmOtros.Controls.Add(Me.Label40)
        Me.FrmOtros.Controls.Add(Me.Label39)
        Me.FrmOtros.Controls.Add(Me.Label38)
        Me.FrmOtros.Controls.Add(Me.Label37)
        Me.FrmOtros.Controls.Add(Me.Label36)
        Me.FrmOtros.Controls.Add(Me.Label35)
        Me.FrmOtros.Controls.Add(Me.Label25)
        Me.FrmOtros.Controls.Add(Me.Label24)
        Me.FrmOtros.Controls.Add(Me.Label23)
        Me.FrmOtros.Controls.Add(Me.Label22)
        Me.FrmOtros.Controls.Add(Me.Label21)
        Me.FrmOtros.Controls.Add(Me.Label20)
        Me.FrmOtros.Controls.Add(Me.Label18)
        Me.FrmOtros.Controls.Add(Me.Label16)
        Me.FrmOtros.Controls.Add(Me.LbValVtaInv)
        Me.FrmOtros.Controls.Add(Me.lbSubVtaCIva)
        Me.FrmOtros.Controls.Add(Me.lbValDes)
        Me.FrmOtros.Controls.Add(Me.lbValNetoVta)
        Me.FrmOtros.Controls.Add(Me.lbIva)
        Me.FrmOtros.Controls.Add(Me.LbOtrSIva)
        Me.FrmOtros.Controls.Add(Me.lbTotDesInd)
        Me.FrmOtros.Controls.Add(Me.Label8)
        Me.FrmOtros.Cursor = System.Windows.Forms.Cursors.Default
        Me.FrmOtros.ForeColor = System.Drawing.SystemColors.WindowText
        Me.FrmOtros.Location = New System.Drawing.Point(45, 133)
        Me.FrmOtros.Margin = New System.Windows.Forms.Padding(4)
        Me.FrmOtros.Name = "FrmOtros"
        Me.FrmOtros.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FrmOtros.Size = New System.Drawing.Size(1036, 278)
        Me.FrmOtros.TabIndex = 290
        '
        'ChkCdreCostoArticulos
        '
        Me.ChkCdreCostoArticulos.AcceptsReturn = True
        Me.ChkCdreCostoArticulos.BackColor = System.Drawing.SystemColors.Window
        Me.ChkCdreCostoArticulos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChkCdreCostoArticulos.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ChkCdreCostoArticulos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ChkCdreCostoArticulos.Location = New System.Drawing.Point(985, 215)
        Me.ChkCdreCostoArticulos.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkCdreCostoArticulos.MaxLength = 1
        Me.ChkCdreCostoArticulos.Name = "ChkCdreCostoArticulos"
        Me.ChkCdreCostoArticulos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ChkCdreCostoArticulos.Size = New System.Drawing.Size(23, 15)
        Me.ChkCdreCostoArticulos.TabIndex = 231
        '
        'ChkCdreImpuestos
        '
        Me.ChkCdreImpuestos.AcceptsReturn = True
        Me.ChkCdreImpuestos.BackColor = System.Drawing.SystemColors.Window
        Me.ChkCdreImpuestos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChkCdreImpuestos.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ChkCdreImpuestos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ChkCdreImpuestos.Location = New System.Drawing.Point(985, 185)
        Me.ChkCdreImpuestos.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkCdreImpuestos.MaxLength = 1
        Me.ChkCdreImpuestos.Name = "ChkCdreImpuestos"
        Me.ChkCdreImpuestos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ChkCdreImpuestos.Size = New System.Drawing.Size(23, 15)
        Me.ChkCdreImpuestos.TabIndex = 230
        '
        'ChkCdreDescuentosServicios
        '
        Me.ChkCdreDescuentosServicios.AcceptsReturn = True
        Me.ChkCdreDescuentosServicios.BackColor = System.Drawing.SystemColors.Window
        Me.ChkCdreDescuentosServicios.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChkCdreDescuentosServicios.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ChkCdreDescuentosServicios.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ChkCdreDescuentosServicios.Location = New System.Drawing.Point(985, 154)
        Me.ChkCdreDescuentosServicios.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkCdreDescuentosServicios.MaxLength = 1
        Me.ChkCdreDescuentosServicios.Name = "ChkCdreDescuentosServicios"
        Me.ChkCdreDescuentosServicios.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ChkCdreDescuentosServicios.Size = New System.Drawing.Size(23, 15)
        Me.ChkCdreDescuentosServicios.TabIndex = 229
        '
        'ChkCdreDescuentoArticulos
        '
        Me.ChkCdreDescuentoArticulos.AcceptsReturn = True
        Me.ChkCdreDescuentoArticulos.BackColor = System.Drawing.SystemColors.Window
        Me.ChkCdreDescuentoArticulos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChkCdreDescuentoArticulos.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ChkCdreDescuentoArticulos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ChkCdreDescuentoArticulos.Location = New System.Drawing.Point(985, 123)
        Me.ChkCdreDescuentoArticulos.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkCdreDescuentoArticulos.MaxLength = 1
        Me.ChkCdreDescuentoArticulos.Name = "ChkCdreDescuentoArticulos"
        Me.ChkCdreDescuentoArticulos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ChkCdreDescuentoArticulos.Size = New System.Drawing.Size(23, 15)
        Me.ChkCdreDescuentoArticulos.TabIndex = 228
        '
        'ChkCdreActivos
        '
        Me.ChkCdreActivos.AcceptsReturn = True
        Me.ChkCdreActivos.BackColor = System.Drawing.SystemColors.Window
        Me.ChkCdreActivos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChkCdreActivos.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ChkCdreActivos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ChkCdreActivos.Location = New System.Drawing.Point(987, 62)
        Me.ChkCdreActivos.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkCdreActivos.MaxLength = 1
        Me.ChkCdreActivos.Name = "ChkCdreActivos"
        Me.ChkCdreActivos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ChkCdreActivos.Size = New System.Drawing.Size(23, 15)
        Me.ChkCdreActivos.TabIndex = 227
        '
        'ChkCdreNOUTILIZADO2
        '
        Me.ChkCdreNOUTILIZADO2.AcceptsReturn = True
        Me.ChkCdreNOUTILIZADO2.BackColor = System.Drawing.SystemColors.Window
        Me.ChkCdreNOUTILIZADO2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChkCdreNOUTILIZADO2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ChkCdreNOUTILIZADO2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ChkCdreNOUTILIZADO2.Location = New System.Drawing.Point(985, 92)
        Me.ChkCdreNOUTILIZADO2.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkCdreNOUTILIZADO2.MaxLength = 1
        Me.ChkCdreNOUTILIZADO2.Name = "ChkCdreNOUTILIZADO2"
        Me.ChkCdreNOUTILIZADO2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ChkCdreNOUTILIZADO2.Size = New System.Drawing.Size(23, 15)
        Me.ChkCdreNOUTILIZADO2.TabIndex = 226
        Me.ChkCdreNOUTILIZADO2.Visible = False
        '
        'ChkCdreConceptos
        '
        Me.ChkCdreConceptos.AcceptsReturn = True
        Me.ChkCdreConceptos.BackColor = System.Drawing.SystemColors.Window
        Me.ChkCdreConceptos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChkCdreConceptos.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ChkCdreConceptos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ChkCdreConceptos.Location = New System.Drawing.Point(987, 31)
        Me.ChkCdreConceptos.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkCdreConceptos.MaxLength = 1
        Me.ChkCdreConceptos.Name = "ChkCdreConceptos"
        Me.ChkCdreConceptos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ChkCdreConceptos.Size = New System.Drawing.Size(23, 15)
        Me.ChkCdreConceptos.TabIndex = 225
        '
        'ChkCdreArticulos
        '
        Me.ChkCdreArticulos.AcceptsReturn = True
        Me.ChkCdreArticulos.BackColor = System.Drawing.SystemColors.Window
        Me.ChkCdreArticulos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ChkCdreArticulos.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ChkCdreArticulos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ChkCdreArticulos.Location = New System.Drawing.Point(985, 0)
        Me.ChkCdreArticulos.Margin = New System.Windows.Forms.Padding(4)
        Me.ChkCdreArticulos.MaxLength = 1
        Me.ChkCdreArticulos.Name = "ChkCdreArticulos"
        Me.ChkCdreArticulos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ChkCdreArticulos.Size = New System.Drawing.Size(23, 15)
        Me.ChkCdreArticulos.TabIndex = 223
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label43.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label43.Font = New System.Drawing.Font("Lucida Sans Unicode", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label43.Location = New System.Drawing.Point(723, 0)
        Me.Label43.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label43.Name = "Label43"
        Me.Label43.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label43.Size = New System.Drawing.Size(240, 27)
        Me.Label43.TabIndex = 170
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label41.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label41.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label41.Location = New System.Drawing.Point(723, 31)
        Me.Label41.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label41.Name = "Label41"
        Me.Label41.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label41.Size = New System.Drawing.Size(240, 27)
        Me.Label41.TabIndex = 168
        '
        'Label40
        '
        Me.Label40.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label40.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label40.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label40.Location = New System.Drawing.Point(723, 92)
        Me.Label40.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label40.Name = "Label40"
        Me.Label40.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label40.Size = New System.Drawing.Size(240, 27)
        Me.Label40.TabIndex = 167
        Me.Label40.Visible = False
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label39.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label39.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label39.Location = New System.Drawing.Point(723, 62)
        Me.Label39.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label39.Name = "Label39"
        Me.Label39.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label39.Size = New System.Drawing.Size(240, 27)
        Me.Label39.TabIndex = 166
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label38.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label38.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label38.Location = New System.Drawing.Point(723, 123)
        Me.Label38.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label38.Name = "Label38"
        Me.Label38.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label38.Size = New System.Drawing.Size(240, 27)
        Me.Label38.TabIndex = 165
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label37.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label37.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label37.Location = New System.Drawing.Point(723, 154)
        Me.Label37.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label37.Name = "Label37"
        Me.Label37.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label37.Size = New System.Drawing.Size(240, 27)
        Me.Label37.TabIndex = 164
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label36.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label36.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label36.Location = New System.Drawing.Point(723, 185)
        Me.Label36.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label36.Name = "Label36"
        Me.Label36.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label36.Size = New System.Drawing.Size(240, 27)
        Me.Label36.TabIndex = 163
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label35.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label35.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label35.Location = New System.Drawing.Point(723, 215)
        Me.Label35.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label35.Name = "Label35"
        Me.Label35.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label35.Size = New System.Drawing.Size(240, 27)
        Me.Label35.TabIndex = 162
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label25.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label25.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label25.Location = New System.Drawing.Point(319, 215)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label25.Size = New System.Drawing.Size(240, 27)
        Me.Label25.TabIndex = 161
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label24.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label24.Location = New System.Drawing.Point(319, 185)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label24.Size = New System.Drawing.Size(240, 27)
        Me.Label24.TabIndex = 160
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label23.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label23.Location = New System.Drawing.Point(319, 154)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label23.Size = New System.Drawing.Size(240, 27)
        Me.Label23.TabIndex = 159
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label22.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label22.Location = New System.Drawing.Point(319, 123)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label22.Size = New System.Drawing.Size(240, 27)
        Me.Label22.TabIndex = 158
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label21.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label21.Location = New System.Drawing.Point(319, 62)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label21.Size = New System.Drawing.Size(240, 27)
        Me.Label21.TabIndex = 157
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label20.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label20.Location = New System.Drawing.Point(319, 92)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label20.Size = New System.Drawing.Size(240, 27)
        Me.Label20.TabIndex = 156
        Me.Label20.Visible = False
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label18.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label18.Location = New System.Drawing.Point(319, 31)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label18.Size = New System.Drawing.Size(240, 27)
        Me.Label18.TabIndex = 155
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label16.Font = New System.Drawing.Font("Lucida Sans Unicode", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label16.Location = New System.Drawing.Point(319, 0)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label16.Size = New System.Drawing.Size(240, 27)
        Me.Label16.TabIndex = 153
        '
        'LbValVtaInv
        '
        Me.LbValVtaInv.AutoSize = True
        Me.LbValVtaInv.BackColor = System.Drawing.Color.Transparent
        Me.LbValVtaInv.Cursor = System.Windows.Forms.Cursors.Default
        Me.LbValVtaInv.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LbValVtaInv.Location = New System.Drawing.Point(0, 0)
        Me.LbValVtaInv.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LbValVtaInv.Name = "LbValVtaInv"
        Me.LbValVtaInv.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LbValVtaInv.Size = New System.Drawing.Size(62, 17)
        Me.LbValVtaInv.TabIndex = 152
        Me.LbValVtaInv.Text = "Artículos"
        '
        'lbSubVtaCIva
        '
        Me.lbSubVtaCIva.AutoSize = True
        Me.lbSubVtaCIva.BackColor = System.Drawing.Color.Transparent
        Me.lbSubVtaCIva.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbSubVtaCIva.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbSubVtaCIva.Location = New System.Drawing.Point(0, 31)
        Me.lbSubVtaCIva.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbSubVtaCIva.Name = "lbSubVtaCIva"
        Me.lbSubVtaCIva.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbSubVtaCIva.Size = New System.Drawing.Size(75, 17)
        Me.lbSubVtaCIva.TabIndex = 150
        Me.lbSubVtaCIva.Text = "Conceptos"
        '
        'lbValDes
        '
        Me.lbValDes.AutoSize = True
        Me.lbValDes.BackColor = System.Drawing.Color.Transparent
        Me.lbValDes.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbValDes.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbValDes.Location = New System.Drawing.Point(0, 92)
        Me.lbValDes.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbValDes.Name = "lbValDes"
        Me.lbValDes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbValDes.Size = New System.Drawing.Size(80, 17)
        Me.lbValDes.TabIndex = 149
        Me.lbValDes.Text = "no utilizado"
        Me.lbValDes.Visible = False
        '
        'lbValNetoVta
        '
        Me.lbValNetoVta.AutoSize = True
        Me.lbValNetoVta.BackColor = System.Drawing.Color.Transparent
        Me.lbValNetoVta.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbValNetoVta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbValNetoVta.Location = New System.Drawing.Point(0, 62)
        Me.lbValNetoVta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbValNetoVta.Name = "lbValNetoVta"
        Me.lbValNetoVta.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbValNetoVta.Size = New System.Drawing.Size(90, 17)
        Me.lbValNetoVta.TabIndex = 148
        Me.lbValNetoVta.Text = "Activos Fijos:"
        '
        'lbIva
        '
        Me.lbIva.AutoSize = True
        Me.lbIva.BackColor = System.Drawing.Color.Transparent
        Me.lbIva.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbIva.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbIva.Location = New System.Drawing.Point(0, 123)
        Me.lbIva.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbIva.Name = "lbIva"
        Me.lbIva.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbIva.Size = New System.Drawing.Size(145, 17)
        Me.lbIva.TabIndex = 147
        Me.lbIva.Text = "Descuentos Articulos:"
        '
        'LbOtrSIva
        '
        Me.LbOtrSIva.AutoSize = True
        Me.LbOtrSIva.BackColor = System.Drawing.Color.Transparent
        Me.LbOtrSIva.Cursor = System.Windows.Forms.Cursors.Default
        Me.LbOtrSIva.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LbOtrSIva.Location = New System.Drawing.Point(0, 154)
        Me.LbOtrSIva.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LbOtrSIva.Name = "LbOtrSIva"
        Me.LbOtrSIva.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LbOtrSIva.Size = New System.Drawing.Size(148, 17)
        Me.LbOtrSIva.TabIndex = 146
        Me.LbOtrSIva.Text = "Descuentos Servicios:"
        '
        'lbTotDesInd
        '
        Me.lbTotDesInd.AutoSize = True
        Me.lbTotDesInd.BackColor = System.Drawing.Color.Transparent
        Me.lbTotDesInd.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbTotDesInd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbTotDesInd.Location = New System.Drawing.Point(0, 185)
        Me.lbTotDesInd.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbTotDesInd.Name = "lbTotDesInd"
        Me.lbTotDesInd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbTotDesInd.Size = New System.Drawing.Size(76, 17)
        Me.lbTotDesInd.TabIndex = 145
        Me.lbTotDesInd.Text = "Impuestos:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(0, 215)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(138, 17)
        Me.Label8.TabIndex = 144
        Me.Label8.Text = "Costo Total Artículos"
        '
        'chGenComDes
        '
        Me.chGenComDes.BackColor = System.Drawing.Color.Transparent
        Me.chGenComDes.Cursor = System.Windows.Forms.Cursors.Default
        Me.chGenComDes.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chGenComDes.Location = New System.Drawing.Point(24, 55)
        Me.chGenComDes.Margin = New System.Windows.Forms.Padding(4)
        Me.chGenComDes.Name = "chGenComDes"
        Me.chGenComDes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chGenComDes.Size = New System.Drawing.Size(377, 25)
        Me.chGenComDes.TabIndex = 296
        Me.chGenComDes.Text = "Permitir guardar comprobante contable descuadrado"
        Me.chGenComDes.UseVisualStyleBackColor = False
        '
        'LabDatos
        '
        Me.LabDatos.BackColor = System.Drawing.Color.DimGray
        Me.LabDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabDatos.ForeColor = System.Drawing.Color.White
        Me.LabDatos.Location = New System.Drawing.Point(735, 100)
        Me.LabDatos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabDatos.Name = "LabDatos"
        Me.LabDatos.Size = New System.Drawing.Size(239, 28)
        Me.LabDatos.TabIndex = 249
        Me.LabDatos.Text = "Datos adicionales"
        Me.LabDatos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Numeracion
        '
        Me.Numeracion.BackColor = System.Drawing.Color.DimGray
        Me.Numeracion.Cursor = System.Windows.Forms.Cursors.Default
        Me.Numeracion.ForeColor = System.Drawing.Color.White
        Me.Numeracion.Location = New System.Drawing.Point(935, 55)
        Me.Numeracion.Margin = New System.Windows.Forms.Padding(4)
        Me.Numeracion.Name = "Numeracion"
        Me.Numeracion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Numeracion.Size = New System.Drawing.Size(204, 37)
        Me.Numeracion.TabIndex = 262
        Me.Numeracion.Text = "Administrar Numeración"
        Me.Numeracion.UseVisualStyleBackColor = False
        '
        'impresora
        '
        Me.impresora.UseEXDialog = True
        '
        'SYSP13
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.ClientSize = New System.Drawing.Size(1147, 673)
        Me.Controls.Add(Me.LabContabilidad)
        Me.Controls.Add(Me.LabDatos)
        Me.Controls.Add(Me.Numeracion)
        Me.Controls.Add(Me.LabInventario)
        Me.Controls.Add(Me.LabGeneral)
        Me.Controls.Add(Me.Toolbar1)
        Me.Controls.Add(Me.txtAbr)
        Me.Controls.Add(Me.txtDes)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TabGeneral)
        Me.Controls.Add(Me.TabInventario)
        Me.Controls.Add(Me.TabDatos)
        Me.Controls.Add(Me.TabContabilidad)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 27)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SYSP13"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "MANTENIMIENTO FUNCIONALIDAD DE DOCUMENTOS"
        Me.Toolbar1.ResumeLayout(False)
        Me.Toolbar1.PerformLayout()
        Me.TabGeneral.ResumeLayout(False)
        Me.TabGeneral.PerformLayout()
        Me.frFac.ResumeLayout(False)
        Me.frImpFor.ResumeLayout(False)
        Me.frImpFor.PerformLayout()
        Me.fImpuestos.ResumeLayout(False)
        Me.Frame2.ResumeLayout(False)
        Me.Frame2.PerformLayout()
        Me.Frame4.ResumeLayout(False)
        Me.TabDatos.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Frame5.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.TabInventario.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Frame1.ResumeLayout(False)
        Me.TabContabilidad.ResumeLayout(False)
        Me.TabContabilidad.PerformLayout()
        Me.frConInd.ResumeLayout(False)
        Me.FrmSri.ResumeLayout(False)
        Me.FrmSri.PerformLayout()
        Me.FrmOtros.ResumeLayout(False)
        Me.FrmOtros.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
#Region "Upgrade Support"
    'Public Sub VB6_AddADODataBinding()
    '    ADOBind_dtCom = New VB6.MBindingCollection()
    '    ADOBind_dtdoc = New VB6.MBindingCollection()
    '    ADOBind_dtCom.UpdateMode = VB6.UpdateMode.vbUpdateWhenPropertyChanges
    '    ADOBind_dtCom.UpdateControls()
    '    ADOBind_dtdoc.UpdateMode = VB6.UpdateMode.vbUpdateWhenPropertyChanges
    '    ADOBind_dtdoc.UpdateControls()
    'End Sub
    'Public Sub VB6_RemoveADODataBinding()
    '    ADOBind_dtCom.Clear()
    '    ADOBind_dtCom.Dispose()
    '    ADOBind_dtCom = Nothing
    '    ADOBind_dtdoc.Clear()
    '    ADOBind_dtdoc.Dispose()
    '    ADOBind_dtdoc = Nothing
    'End Sub
    Friend WithEvents btnnuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents LabGeneral As System.Windows.Forms.Label
    Friend WithEvents LabInventario As System.Windows.Forms.Label
    Friend WithEvents LabContabilidad As System.Windows.Forms.Label
    Friend WithEvents TabGeneral As System.Windows.Forms.GroupBox
    Public WithEvents Command8 As System.Windows.Forms.Button
    Public WithEvents BtnDocSop As System.Windows.Forms.Button
    Public WithEvents TxtTipSop As System.Windows.Forms.TextBox
    Public WithEvents Label46 As System.Windows.Forms.Label
    Public WithEvents Label45 As System.Windows.Forms.Label
    Public WithEvents LbNomSoporte As System.Windows.Forms.Label
    Public WithEvents Label44 As System.Windows.Forms.Label
    Public WithEvents Check8 As System.Windows.Forms.CheckBox
    Friend WithEvents dbDoc As System.Windows.Forms.ComboBox
    Public WithEvents ChGenTipGas As System.Windows.Forms.CheckBox
    Public WithEvents Chpuedeconsolidar As System.Windows.Forms.CheckBox
    Public WithEvents frFac As System.Windows.Forms.GroupBox
    Public WithEvents chFacSer As System.Windows.Forms.CheckBox
    Public WithEvents chFacArt As System.Windows.Forms.CheckBox
    Public WithEvents chFacAcf As System.Windows.Forms.CheckBox
    Public WithEvents chRefAcf As System.Windows.Forms.CheckBox
    Public WithEvents fImpuestos As System.Windows.Forms.GroupBox
    Public WithEvents ChImp2 As System.Windows.Forms.CheckBox
    Public WithEvents ChImp1 As System.Windows.Forms.CheckBox
    Public WithEvents ChImp3 As System.Windows.Forms.CheckBox
    Public WithEvents chImp4 As System.Windows.Forms.CheckBox
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents Impresora_1 As System.Windows.Forms.TextBox
    Public WithEvents Impresora_2 As System.Windows.Forms.TextBox
    Public WithEvents Impresora_3 As System.Windows.Forms.TextBox
    Public WithEvents BtRut3 As System.Windows.Forms.Button
    Public WithEvents FormatoAux1 As System.Windows.Forms.TextBox
    Public WithEvents BtRut4 As System.Windows.Forms.Button
    Public WithEvents FormatoAux2 As System.Windows.Forms.TextBox
    Public WithEvents BtRut5 As System.Windows.Forms.Button
    Public WithEvents FormatoAux3 As System.Windows.Forms.TextBox
    Public WithEvents Label47 As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents frImpFor As System.Windows.Forms.GroupBox
    Public WithEvents btnFormatoCtb As System.Windows.Forms.Button
    Public WithEvents FormatoCtb As System.Windows.Forms.TextBox
    Public WithEvents opImpForNin As System.Windows.Forms.RadioButton
    Public WithEvents opImpForGen As System.Windows.Forms.RadioButton
    Public WithEvents txtFormato As System.Windows.Forms.TextBox
    Public WithEvents btnFormatoGeneral As System.Windows.Forms.Button
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents Frame4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents ChkNumerar As System.Windows.Forms.CheckBox
    Public WithEvents Check3 As System.Windows.Forms.CheckBox
    Public WithEvents Check5 As System.Windows.Forms.CheckBox
    Public WithEvents Check6 As System.Windows.Forms.CheckBox
    Public WithEvents Check7 As System.Windows.Forms.CheckBox
    Public WithEvents chRefInv As System.Windows.Forms.CheckBox
    Public WithEvents chRefCon As System.Windows.Forms.CheckBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabDatos As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TabInventario As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents GeneraSalidaMP As System.Windows.Forms.CheckBox
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents OpCosLiq As System.Windows.Forms.RadioButton
    Public WithEvents opCosNin As System.Windows.Forms.RadioButton
    Public WithEvents opCosDig As System.Windows.Forms.RadioButton
    Public WithEvents opCosUlt As System.Windows.Forms.RadioButton
    Public WithEvents opCosPro As System.Windows.Forms.RadioButton
    Public WithEvents chGenSinExi As System.Windows.Forms.CheckBox
    Public WithEvents chRepCodFil As System.Windows.Forms.CheckBox
    Public WithEvents chGuaUltCom As System.Windows.Forms.CheckBox
    Public WithEvents RegistraCantCero As System.Windows.Forms.CheckBox
    Friend WithEvents TabContabilidad As System.Windows.Forms.GroupBox
    Public WithEvents Text1 As System.Windows.Forms.TextBox
    Public WithEvents Label49 As System.Windows.Forms.Label
    Public WithEvents ChkCdreTotal As System.Windows.Forms.TextBox
    Public WithEvents chGenComDes As System.Windows.Forms.CheckBox
    Public WithEvents txtValTotDocD As System.Windows.Forms.TextBox
    Public WithEvents Reconta As System.Windows.Forms.CheckBox
    Public WithEvents txtValTotDocH As System.Windows.Forms.TextBox
    Public WithEvents frConInd As System.Windows.Forms.GroupBox
    Public WithEvents chOtrSIva As System.Windows.Forms.CheckBox
    Public WithEvents chOtrCIva As System.Windows.Forms.CheckBox
    Public WithEvents chDes As System.Windows.Forms.CheckBox
    Public WithEvents chArt As System.Windows.Forms.CheckBox
    Public WithEvents FrmSri As System.Windows.Forms.Panel
    Public WithEvents ChkCdreRetFte1 As System.Windows.Forms.TextBox
    Public WithEvents ChkCdreRetFte As System.Windows.Forms.TextBox
    Public WithEvents ChkCdreRetIvaServ As System.Windows.Forms.TextBox
    Public WithEvents ChkCdreRetIvaBien As System.Windows.Forms.TextBox
    Public WithEvents txtRetBieD As System.Windows.Forms.TextBox
    Public WithEvents txtRetBieH As System.Windows.Forms.TextBox
    Public WithEvents txtRetSerD As System.Windows.Forms.TextBox
    Public WithEvents txtRetSerH As System.Windows.Forms.TextBox
    Public WithEvents txtRetFteD As System.Windows.Forms.TextBox
    Public WithEvents txtRetFteH As System.Windows.Forms.TextBox
    Public WithEvents Label28 As System.Windows.Forms.Label
    Public WithEvents txtRetFte1H As System.Windows.Forms.TextBox
    Public WithEvents txtRetFte1D As System.Windows.Forms.TextBox
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents Label26 As System.Windows.Forms.Label
    Public WithEvents Label27 As System.Windows.Forms.Label
    Public WithEvents Label32 As System.Windows.Forms.Label
    Public WithEvents Label33 As System.Windows.Forms.Label
    Public WithEvents Label34 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Label48 As System.Windows.Forms.Label
    Public WithEvents Label29 As System.Windows.Forms.Label
    Public WithEvents Label30 As System.Windows.Forms.Label
    Public WithEvents Label31 As System.Windows.Forms.Label
    Public WithEvents Label14 As System.Windows.Forms.Label
    Public WithEvents Label19 As System.Windows.Forms.Label
    Public WithEvents FrmOtros As System.Windows.Forms.Panel
    Public WithEvents ChkCdreCostoArticulos As System.Windows.Forms.TextBox
    Public WithEvents ChkCdreImpuestos As System.Windows.Forms.TextBox
    Public WithEvents ChkCdreDescuentosServicios As System.Windows.Forms.TextBox
    Public WithEvents ChkCdreDescuentoArticulos As System.Windows.Forms.TextBox
    Public WithEvents ChkCdreActivos As System.Windows.Forms.TextBox
    Public WithEvents ChkCdreNOUTILIZADO2 As System.Windows.Forms.TextBox
    Public WithEvents ChkCdreConceptos As System.Windows.Forms.TextBox
    Public WithEvents ChkCdreArticulos As System.Windows.Forms.TextBox
    Public WithEvents txtValVenInvD As System.Windows.Forms.TextBox
    Public WithEvents txtSubVenCIvaD As System.Windows.Forms.TextBox
    Public WithEvents txtSubVenCIvaH As System.Windows.Forms.TextBox
    Public WithEvents txtValDesD As System.Windows.Forms.TextBox
    Public WithEvents txtValDesH As System.Windows.Forms.TextBox
    Public WithEvents txtValNetVenD As System.Windows.Forms.TextBox
    Public WithEvents txtValNetVenH As System.Windows.Forms.TextBox
    Public WithEvents txtIvaD As System.Windows.Forms.TextBox
    Public WithEvents txtIvaH As System.Windows.Forms.TextBox
    Public WithEvents txtOtrSIvaD As System.Windows.Forms.TextBox
    Public WithEvents txtOtrSIvaH As System.Windows.Forms.TextBox
    Public WithEvents txtTotDesIndD As System.Windows.Forms.TextBox
    Public WithEvents txtTotDesIndH As System.Windows.Forms.TextBox
    Public WithEvents txtCtaCosH As System.Windows.Forms.TextBox
    Public WithEvents txtCtaCosD As System.Windows.Forms.TextBox
    Public WithEvents txtValVenInvH As System.Windows.Forms.TextBox
    Public WithEvents Label43 As System.Windows.Forms.Label
    Public WithEvents Label41 As System.Windows.Forms.Label
    Public WithEvents Label40 As System.Windows.Forms.Label
    Public WithEvents Label39 As System.Windows.Forms.Label
    Public WithEvents Label38 As System.Windows.Forms.Label
    Public WithEvents Label37 As System.Windows.Forms.Label
    Public WithEvents Label36 As System.Windows.Forms.Label
    Public WithEvents Label35 As System.Windows.Forms.Label
    Public WithEvents Label25 As System.Windows.Forms.Label
    Public WithEvents Label24 As System.Windows.Forms.Label
    Public WithEvents Label23 As System.Windows.Forms.Label
    Public WithEvents Label22 As System.Windows.Forms.Label
    Public WithEvents Label21 As System.Windows.Forms.Label
    Public WithEvents Label20 As System.Windows.Forms.Label
    Public WithEvents Label18 As System.Windows.Forms.Label
    Public WithEvents Label16 As System.Windows.Forms.Label
    Public WithEvents LbValVtaInv As System.Windows.Forms.Label
    Public WithEvents lbSubVtaCIva As System.Windows.Forms.Label
    Public WithEvents lbValDes As System.Windows.Forms.Label
    Public WithEvents lbValNetoVta As System.Windows.Forms.Label
    Public WithEvents lbIva As System.Windows.Forms.Label
    Public WithEvents LbOtrSIva As System.Windows.Forms.Label
    Public WithEvents lbTotDesInd As System.Windows.Forms.Label
    Public WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LabDatos As System.Windows.Forms.Label
    Public WithEvents Numeracion As System.Windows.Forms.Button
    Friend WithEvents TipoComprobanteSri As System.Windows.Forms.ComboBox
    Public WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents ChkCdreNOUSADO As System.Windows.Forms.TextBox
    Public WithEvents txtValVenOIvaD As System.Windows.Forms.TextBox
    Public WithEvents txtValVenOIvaH As System.Windows.Forms.TextBox
    Public WithEvents Label42 As System.Windows.Forms.Label
    Public WithEvents Label17 As System.Windows.Forms.Label
    Public WithEvents lbValVtaOIva As System.Windows.Forms.Label
    Friend WithEvents ComboDoc1 As System.Windows.Forms.ComboBox
    Public WithEvents Frame5 As System.Windows.Forms.GroupBox
    Public WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ListItems As System.Windows.Forms.CheckedListBox
    Friend WithEvents ListCabecera As System.Windows.Forms.CheckedListBox
    Public WithEvents ChkCdreRetFte2 As System.Windows.Forms.TextBox
    Public WithEvents txtRetFte2H As System.Windows.Forms.TextBox
    Public WithEvents txtRetFte2D As System.Windows.Forms.TextBox
    Public WithEvents Label51 As System.Windows.Forms.Label
    Public WithEvents Label52 As System.Windows.Forms.Label
    Public WithEvents Label53 As System.Windows.Forms.Label
    Public WithEvents OpCosLiqClas As System.Windows.Forms.RadioButton
    Friend WithEvents CmbClasificadorCosteo As System.Windows.Forms.ComboBox
    Public WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents ComandoSQL As System.Windows.Forms.TextBox
    Public WithEvents Command3 As System.Windows.Forms.Button
    Public WithEvents Command2 As System.Windows.Forms.Button
    Public WithEvents Command1 As System.Windows.Forms.Button
    Public WithEvents chkNoBajoCosto As System.Windows.Forms.CheckBox
    Friend WithEvents impresora As System.Windows.Forms.PrintDialog
    Public WithEvents chKNoEnLinea As System.Windows.Forms.CheckBox
    Public WithEvents btnBuscaFormulaPVP As System.Windows.Forms.Button
    Public WithEvents Label56 As System.Windows.Forms.Label
    Public WithEvents txtFormulasPVP As System.Windows.Forms.TextBox
    Public WithEvents chkRegistraImportaciones As System.Windows.Forms.CheckBox
    Public WithEvents chkElectronico As System.Windows.Forms.CheckBox
    Public WithEvents btnFormatoElec As Button
    Public WithEvents FormatoElec As TextBox
    Public WithEvents Label54 As Label
    Public WithEvents chkImprimirRIDE As RadioButton
    Public WithEvents chkImprimirTicket As RadioButton
#End Region
End Class
