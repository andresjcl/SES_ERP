Option Strict Off
Option Explicit On
Friend Class BuscDocAdcom
	Inherits System.Windows.Forms.Form
	Private Const MARGIN_SIZE As Short = 60 ' en twips
	' variables para enlace de datos
	Private RsDocumentos As ADODB.Recordset
	
	' variables para permitir el orden de columnas
	Private m_iSortCol As Short
	Private m_iSortType As Short
	Private Nombre, codigo, Tipo As String
	Private ConError As Boolean
	
	Public Sub BuscaDocAdcom(ByVal ComVtaBancoInvTod As String, ByRef QUECODIGO As String, ByRef QUENOMBRE As String)
		Tipo = ComVtaBancoInvTod
		Me.ShowDialog()
		QUECODIGO = codigo
		QUENOMBRE = Nombre
	End Sub
	
	'UPGRADE_WARNING: Form evento BuscDocAdcom.Activate tiene un nuevo comportamiento. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
	Private Sub BuscDocAdcom_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		If ConError Then
			MsgBox("No existen parametros del ADCOM o no tiene instalado el sistema Administrativo ADCOMw")
			Me.Close()
		End If
	End Sub
	
	Private Sub BuscDocAdcom_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim i As Object
		
		Dim sConnect As String
		Dim sSQL, servidor As String
		ConError = False
		''cambiar on error GoTo Errores
		' establecer cadenas
		
		' sConnect = "Provider=Microsoft.Jet.OLEDB.4.0;Password='';User ID=Admin;Data Source=S:\SNT\ADCOMw\arch\bak\Adcbd3.mdb;Mode=Share Deny None;Extended Properties='';Jet OLEDB:System database='';Jet OLEDB:
		'Registry Path='';Jet OLEDB:Database Password='';Jet OLEDB:Engine Type=5;Jet OLEDB:Database Locking Mode=0;Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Global Bulk Transactions=1;Jet OLEDB:New Database Password='';Jet OLEDB:Create System Database=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:SFP=False"
		Select Case Tipo
			Case "V"
				sSQL = " opc_tipo in ('FAC','DEV', 'PRO', 'PEC') "
				Text = "Documentos de ventas"
			Case "T"
				sSQL = " opc_tipo > '' "
				Text = "Documentos activos del sistema"
			Case "C"
				sSQL = " OPC_TIPO IN ('FAC','DEV','FAP','DEP','EBG','IBG','TRN','PRC','PRP','PEC','PEP') "
				Text = "Documentos para consolidación"
			Case "I"
				sSQL = " substring(opc_extension,5,1) <> '0' "
				Text = "Documentos de inventarios"
			Case Else
				sSQL = " opc_tipo in ( 'FAP','DEP','NCP','NDP') "
				Text = "Documentos de compras"
		End Select
		
		' abrir conexión
		' crear un conjunto de registros con la colección proporcionada
		'If Sistema = "SRI" Then
		'   SERVIDOR = ""
		'   SERVIDOR = emp.ServidorADC
		'   AccessConnectData = ArmStr(emp.PathADCOM, SERVIDOR, emp.TipBDADC, CStr(ClaveAdcom))
		'   Set ConxAdcom = New ADODB.Connection
		'   ConxAdcom.ConnectionString = AccessConnectData
		'   ConxAdcom.Open
		'End If
		
		RsDocumentos = New ADODB.Recordset
		RsDocumentos.CursorLocation = ADOR.CursorLocationEnum.adUseClient
		RsDocumentos.Open("select Opc_documento,Opc_nombre from AdcOpc where " & sSQL, ConxAdcom, ADOR.CursorTypeEnum.adOpenForwardOnly, ADOR.LockTypeEnum.adLockReadOnly)
		
		Malla.DataSource = RsDocumentos
		
		With Malla
			
			.Redraw = False
			' establecer anchos de columna de cuadrícula
			.set_ColWidth(0,  , 300)
			.set_ColWidth(1,  , 450)
			.set_ColWidth(2,  , 3000)
			
			' establecer tipo de cuadrícula
			.AllowBigSelection = True
			.FillStyle = MSFlexGridLib.FillStyleSettings.flexFillRepeat
			
			' encabezado en negrita
			.set_TextMatrix(0, 0, "Nro")
			.set_TextMatrix(0, 1, "Cod")
			.set_TextMatrix(0, 2, "Descripción")
			.Row = 0
			.Col = 0
			.RowSel = .FixedRows - 1
			.ColSel = .get_Cols() - 1
			.CellFontBold = True
			
			.AllowBigSelection = False
			.FillStyle = MSFlexGridLib.FillStyleSettings.flexFillSingle
			For i = 1 To Malla.Rows - 1
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto i. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.set_TextMatrix(i, 0, i)
			Next i
			.Redraw = True
			
		End With
		Exit Sub
Errores: 
		ConError = True
	End Sub
	
	Private Sub malla_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles malla.DblClick
		''-------------------------------------------------------------------------------------------
		'' el código del evento DblClick de la cuadrícula permite ordenar columnas
		''-------------------------------------------------------------------------------------------
		'
		'    Dim i As Integer
		'
		'    ' sólo ordena cuando se hace clic en una fila
		'    If Malla.MouseRow >= Malla.FixedRows Then Exit Sub
		'
		'    i = m_iSortCol                  ' guarda la columna antigua
		'    m_iSortCol = Malla.col   ' establece la nueva columna
		'
		'    ' incrementa el tipo de orden
		'    If i <> m_iSortCol Then
		'        ' si hace clic en una columna nueva, inicia con orden ascendente
		'        m_iSortType = 1
		'    Else
		'        ' si hace clic en la misma columna, alterna entre orden ascendente y orden descendente
		'        m_iSortType = m_iSortType + 1
		'    If m_iSortType = 3 Then m_iSortType = 1
		'    End If
		'
		'    DoColumnSort
		'
		cmdClose_Click(cmdClose, New System.EventArgs())
	End Sub
	
	Sub DoColumnSort()
		'-------------------------------------------------------------------------------------------
		' orden de tipo intercambio en la columna m_iSortCol
		'-------------------------------------------------------------------------------------------
		
		With Malla
			.Redraw = False
			.Row = 1
			.RowSel = .Rows - 1
			.Col = m_iSortCol
			.Sort = m_iSortType
			.Redraw = True
		End With
		
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		With Malla
			
			codigo = .get_TextMatrix(.Row, 1)
			Nombre = .get_TextMatrix(.Row, 2)
		End With
		
		Me.Close()
		
	End Sub
	
	
	Private Sub BuscDocAdcom_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim keycode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If keycode = System.Windows.Forms.Keys.Escape Then Me.Close()
	End Sub
End Class