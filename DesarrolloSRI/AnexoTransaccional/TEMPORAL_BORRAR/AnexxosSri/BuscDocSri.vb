Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class BuscDocSri
	Inherits System.Windows.Forms.Form
	Private Const MARGIN_SIZE As Short = 60 ' en twips
	' variables para enlace de datos
	Private RsDocumentos As ADODB.Recordset
	
	' variables para permitir el orden de columnas
	Private m_iSortCol As Short
	Private m_iSortType As Short
	Private Nombre, codigo, Tipo As String
	Dim TipoTransaccion As Short
	Dim Retencion As Boolean
	Dim TipoSustento As Short
	Dim TipoIdentificacion As String
	Dim Hasta As Date
	Dim SinDoc As Boolean
	
	Public Sub BuscaDoc(ByVal periodo As String, ByVal TipoTran As Short, ByVal TipSus As Short, ByRef TipoId As String, ByRef QUECODIGO As String, ByRef QUENOMBRE As String)
		Dim Reten As Object
		Dim Aux As String
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Reten. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Retencion = Reten
		TipoIdentificacion = CorrijeTipoId(TipoId)
		TipoTransaccion = TipoTran
		TipoSustento = TipSus
		Hasta = FechaFinMes(Val(CStr(PerAnio)), Val(CStr(PerMes)))
		Me.ShowDialog()
		QUECODIGO = codigo
		QUENOMBRE = Nombre
		
	End Sub
	
	
	Private Sub BuscDocSri_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim i As Object
		Dim fechaa As Date
		
		Dim Sw As Boolean
		Dim SrRec As New ADODB.Recordset
		'   Dim sConnect As String
		Dim sSQL As String
		Dim codi As Short
		Dim HastaFec As Date
		Dim claves As String
		Dim SeqTransacc As Short
		Dim TxSustento, TxSeqTra As String
		''cambiar on error GoTo errores
		TxSustento = ""
		TxSeqTra = ""
		
		SrRec = New ADODB.Recordset
		Sw = True
		If TipoTransaccion = 3 Or TipoTransaccion = 4 Then
			SeqTransacc = TipoTransaccion + 5
		Else
			If TipoIdentificacion > "" Then
				sSQL = "Select * From SriSecuencialesTransacciones where CodigoTipoTransaccion = " & TipoTransaccion & " and CodigoIdentificacion = '" & TipoIdentificacion & "'"
				SrRec.Open(sSQL, ConxSyscod, ADOR.CursorTypeEnum.adOpenForwardOnly, ADOR.LockTypeEnum.adLockOptimistic)
				If SrRec.State = 0 Then
					Sw = False
				ElseIf SrRec.EOF Then 
					Sw = False
				Else
					SeqTransacc = SrRec.Fields("codigo").Value
				End If
				If SrRec.State = 1 Then SrRec.Close()
			End If
		End If
		If SeqTransacc > 0 Then TxSeqTra = "  (CodigoSecuencialTransaccion LIKE '%" & VB.Right("00" & SeqTransacc, 2) & "%')"
		
		If Sw = False Then
			MsgBox("No existen valores para el tipo de identificación [" & TipoIdentificacion & "] requerido", MsgBoxStyle.Critical)
		Else
			If TipoSustento > 0 Then TxSustento = "(SustentoTributario LIKE '%" & VB.Right("00" & TipoSustento, 2) & "%') "
			
			'Else
			'    TxSustento = " SustentoTributario > '' "
			If TxSustento > "" Then
				TxSustento = " where " & TxSustento
				If TxSeqTra > "" Then TxSustento = TxSustento & " AND "
			ElseIf TxSeqTra > "" Then 
				TxSeqTra = " where " & TxSeqTra
			End If
			
			sSQL = "Select * From sritipodecomprobante " & TxSustento & TxSeqTra & " order by codigo "
			' abrir conexión
			
			' crear un conjunto de registros con la colección proporcionada
			RsDocumentos = New ADODB.Recordset
			RsDocumentos.CursorLocation = ADOR.CursorLocationEnum.adUseClient
			RsDocumentos.Open(sSQL, ConxSyscod, ADOR.CursorTypeEnum.adOpenForwardOnly, ADOR.LockTypeEnum.adLockReadOnly)
			Malla.DataSource = RsDocumentos
			
			With Malla
				'        If Retencion Then
				'            .Rows = .Rows + 1
				'            .TextMatrix(.Rows - 1, 1) = 98
				'            .TextMatrix(.Rows - 1, 2) = "Retencion a proveedores"
				'        End If
				.Redraw = False
				' establecer anchos de columna de cuadrícula
				For i = 0 To .get_Cols() - 1
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto i. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.set_ColWidth(i,  , 0)
				Next 
				.set_ColWidth(0,  , 300)
				.set_ColWidth(1,  , 400)
				.set_ColWidth(2,  , 5000)
				
				' establecer tipo de cuadrícula
				.AllowBigSelection = True
				.FillStyle = MSFlexGridLib.FillStyleSettings.flexFillRepeat
				
				' encabezado en negrita
				.set_TextMatrix(0, 0, "Nro")
				.set_TextMatrix(0, 1, "Cod")
				.set_TextMatrix(0, 2, "Tipo de Comprobante")
				.Row = 0
				.Col = 0
				.RowSel = .FixedRows - 1
				.ColSel = .get_Cols() - 1
				.CellFontBold = True
				
				.AllowBigSelection = False
				.FillStyle = MSFlexGridLib.FillStyleSettings.flexFillSingle
				'        Sw = False
				'        i = 1
				'        Do Until Sw = True
				'        If InStr(.TextMatrix(i, 3), TipoTransaccion) = 0 Then
				'            .RemoveItem (i)
				'        Else
				'            If i = .Rows - 1 Then Sw = True: Exit Do
				'        i = i + 1
				'        End If
				'        Loop
				HastaFec = FechaFinMes(CInt(Mid(PerPeriodo, 3, 4)), CShort(Mid(PerPeriodo, 1, 2)))
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto i. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				i = 1
				If Malla.Rows > 1 Then
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto i. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Do Until i = 0
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto i. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If Not IsDate(.get_TextMatrix(i, 4)) Then
							fechaa = CDate("31/12/9999")
						Else
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto i. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							fechaa = CDate(.get_TextMatrix(i, 4))
						End If
						If HastaFec >= fechaa Then
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto i. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							If i < Malla.Rows And Malla.Rows > 2 Then Malla.RemoveItem((i)) Else Exit Do
						Else
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto i. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							.set_TextMatrix(i, 0, i)
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto i. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							i = i + 1
						End If
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto i. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If i > Malla.Rows - 1 Then i = 0
					Loop 
				End If
				.Redraw = True
			End With
		End If
		Exit Sub
Errores: 
		MsgBox("Existe un error")
	End Sub
	
	'UPGRADE_WARNING: El evento BuscDocSri.Resize se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub BuscDocSri_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		Malla.SetBounds(VB6.TwipsToPixelsX(100), VB6.TwipsToPixelsY(100), VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.Width) - 300), VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.Height) - 300 - VB6.PixelsToTwipsY(cmdClose.Height)))
		cmdClose.SetBounds(VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.Width) - 100 - VB6.PixelsToTwipsX(cmdClose.Width)), VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.Height) - 50 - VB6.PixelsToTwipsY(cmdClose.Height)), 0, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)
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
End Class