Option Strict Off
Option Explicit On
Friend Class BuscaCentrosCosto
	Inherits System.Windows.Forms.Form
	Dim MovAgr As Boolean
	Dim CodigoArt As String
	Dim CodigoRet As String
	Dim Sw As Boolean
	Dim Ini, fin As Date
	
	Private Sub btnbuscar_Click()
		Retorna()
	End Sub
	
	Public Function IniciaCtas(Optional ByRef PriCta As String = "") As String
		
		'UPGRADE_NOTE: IsMissing() ha cambiado a IsNothing(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"'
		If Not IsNothing(PriCta) Then
			CodigoArt = PriCta
		Else
			CodigoArt = ""
		End If
		Me.ShowDialog()
		IniciaCtas = CodigoRet
		
	End Function
	
	Private Sub btAceptar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btAceptar.Click
		listnombre_DblClick(listnombre, New System.EventArgs())
	End Sub
	
	Private Sub btncancelarbusca_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btncancelarbusca.Click
		CodigoRet = ""
		Sw = False
		Me.Close()
	End Sub
	
	Private Sub BuscaCentrosCosto_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		SaveSetting("ADCOM", "BUSCAR", "Ccosto", IIf(OptNombre.Checked, 1, 0))
	End Sub
	
	Private Sub btNuevo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btNuevo.Click
		IngresoCCosto.ShowDialog()
		IngresoCCosto.Close()
		'UPGRADE_NOTE: El objeto IngresoCCosto no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		IngresoCCosto = Nothing
	End Sub
	
	'UPGRADE_WARNING: Form evento BuscaCentrosCosto.Activate tiene un nuevo comportamiento. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
	Private Sub BuscaCentrosCosto_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		'quitar en todo el proyecto  'cambiar on error Resume Next
		TxtNombre.Focus()
		' by Victor
		ListNombre.col = 1
		ListNombre.Row = 1
		If ListNombre.Rows > 2 Then ListNombre.Focus()
	End Sub
	
	Private Sub BuscaCentrosCosto_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Sw = False
		'Me.Caption = "Busqueda de Artículos"
		If CDbl(GetSetting("ADCOM", "BUSCAR", "Ccosto", CStr(0))) = 1 Then
			OptNombre.Checked = True
		Else
			Optcodigo.Checked = True
		End If
		TxtNombre.Text = CodigoArt
		Sw = True
		ArreglaMalla()
	End Sub
	
	Private Sub listnombre_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles listnombre.DblClick
		If ListNombre.Rows = 0 Then Exit Sub
		With ListNombre
			If .get_TextMatrix(.Row, 1) > "" Then Retorna()
		End With
	End Sub
	'Private Sub Botones_Click(Index As Integer)
	'Dim J As Integer
	'J = Index + vbKeyF5
	'listnombre_KeyDown J, 0
	'End Sub
	
	Private Sub OpCentrosCosto_Click()
		ArreglaMalla()
	End Sub
	
	'Private Sub listnombre_KeyDown(KeyCode As Integer, Shift As Integer)
	' If KeyCode = vbKeyReturn Then listnombre_DblClick
	'    If ListNombre.Rows = 0 Then Exit Sub
	'    If KeyCode = vbKeyF5 Then
	'        DetalleArt.ConsultaDetalle ListNombre.TextMatrix(ListNombre.Row, 1), ListNombre.TextMatrix(ListNombre.Row, 2)
	'        ListNombre.SetFocus
	'        Set DetalleArt = Nothing
	'    ElseIf KeyCode = vbKeyF6 Then
	'        Compatibles.ConsultarCompatibles ListNombre.TextMatrix(ListNombre.Row, 1), ListNombre.TextMatrix(ListNombre.Row, 2)
	'        ListNombre.SetFocus
	'        Set Compatibles = Nothing
	'    ElseIf KeyCode = vbKeyF7 Then
	'        ExistenciasArt.INIExistencia ListNombre.TextMatrix(ListNombre.Row, 1), "", "", Date, ""
	'        Set ExistenciasArt = Nothing
	'    End If
	'
	'End Sub
	
	'UPGRADE_WARNING: El evento optcodigo.CheckedChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub optcodigo_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optcodigo.CheckedChanged
		If eventSender.Checked Then
			ArreglaMalla()
			TxtNombre.Focus()
		End If
	End Sub
	
	'UPGRADE_WARNING: El evento OptNombre.CheckedChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub OptNombre_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OptNombre.CheckedChanged
		If eventSender.Checked Then
			'quitar en todo el proyecto  'cambiar on error Resume Next
			'TxtNombre.Text = ""
			'Label2.Caption = ""
			ArreglaMalla()
			TxtNombre.Focus()
		End If
	End Sub
	
	Private Sub ArreglaMalla()
		Dim NomCod, codsql As String
		Dim rs As ADODB.Recordset
		Dim I As Short
		Dim busca As String
		Dim Seleccion As String
		If Sw = False Then Exit Sub
		''quitar en todo el proyecto  'cambiar on error Resume Next
		
		'busca = txtnombre.Text    'almaceno lo que tiene la caja de textto
		Seleccion = "CCO_Id AS CODIGO, CCO_Nombre AS Nombre "
		
		NomCod = ""
		If OptNombre.Checked = True Then
			NomCod = "CCO_nombre"
		Else
			NomCod = "CCO_Id"
		End If
		
		codsql = "SELECT " & Seleccion & " From adcccosto where CCO_Id > '' "
		If TextCodigo.Text > "" Then
			codsql = codsql & " AND CCO_Id LIKE '%" & TextCodigo.Text & "%' "
		End If
		If TxtNombre.Text > "" Then
			codsql = codsql & " AND CCO_Nombre LIKE '%" & TxtNombre.Text & "%' "
		End If
		
		codsql = codsql & busca & " ORDER BY " & NomCod & " ; "
		'& Categorias & ") ORDER BY " & NomCod & " ; "
		
		rs = New ADODB.Recordset
		
		rs.CursorLocation = ADODB.CursorLocationEnum.adUseServer
		ListNombre.Rows = 2
		ListNombre.FixedRows = 1
		'ListNombre.FixedCols = 1
		ListNombre.set_Cols( , 2)
		
		'ListNombre.Redraw = False
		rs.Open(codsql, ConxAdcom, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
		If rs.EOF Then
			'    MsgBox "No existen Cuentas con las condiciones solicitadas"
			rs.Close()
			ListNombre.Redraw = True
			Exit Sub
		End If
		
		ListNombre.DataSource = rs
		
		rs.Close()
		Ini = TimeOfDay
		
		With ListNombre
			
			.set_ColWidth(0,  , VB6.PixelsToTwipsX(TextCodigo.Width))
			.set_ColWidth(1,  , VB6.PixelsToTwipsX(TxtNombre.Width))
			.set_TextMatrix(0, 0, "Codigo")
			.set_TextMatrix(0, 1, "Nombre")
			.Row = 1
			.col = 1
			.Redraw = True
			.TopRow = .Rows - 1
			.TopRow = 1
		End With
		fin = TimeOfDay
		'MsgBox ini & "  " & fin & " list "
		
	End Sub
	
	Private Sub Retorna()
		CodigoRet = ListNombre.get_TextMatrix(ListNombre.Row, 0)
		Sw = False
		Me.Close()
	End Sub
	
	Private Sub TextCodigo_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TextCodigo.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KeyCode = System.Windows.Forms.Keys.Return Then ArreglaMalla()
	End Sub
	
	Private Sub TextCodigo_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TextCodigo.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = Asc(vbCr) Then KeyAscii = 0
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	
	Private Sub txtnombre_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtnombre.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KeyCode = System.Windows.Forms.Keys.Return Then ArreglaMalla()
	End Sub
	
	Private Sub TxtNombre_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TxtNombre.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If KeyAscii = Asc(vbCr) Then KeyAscii = 0
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class