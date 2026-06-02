Option Strict Off
Option Explicit On
Friend Class BuscaRetIvaServicios
	Inherits System.Windows.Forms.Form
	Private Const MARGIN_SIZE As Short = 60 ' en twips
	' variables para enlace de datos
	Private RsDocumentos As ADODB.Recordset
	
	' variables para permitir el orden de columnas
	Private m_iSortCol As Short
	Private m_iSortType As Short
	Private Codigo, Nombre As String
	Private valor As Double
	
	Public Sub BuscaRet(ByVal periodo As String, ByRef QUECODIGO As String, ByRef QUENOMBRE As String, ByRef QUEVALOR As Double)
		Dim Aux As String
		
		Me.ShowDialog()
		
		QUECODIGO = Codigo
		QUENOMBRE = Nombre
		QUEVALOR = valor
		
	End Sub
	
	Private Sub BuscaRetIvaServicios_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim i As Object
		Dim Sw As Boolean
		Dim SrRec As New ADODB.Recordset
		'   Dim sConnect As String
		Dim Ssql As String
		Dim Codi As Short
		Dim HastaFec As Date
		Dim claves As String
		Dim SeqTransacc As Short
		Dim TxSustento, TxSeqTra As String
		
		SrRec = New ADODB.Recordset
		Sw = True
		Ssql = "Select * From SriPorcentajesRetencionIvaServicios "
		RsDocumentos = New ADODB.Recordset
		RsDocumentos.CursorLocation = ADOR.CursorLocationEnum.adUseClient
		RsDocumentos.Open(Ssql, ConxSyscod, ADOR.CursorTypeEnum.adOpenForwardOnly, ADOR.LockTypeEnum.adLockReadOnly)
		
		malla.DataSource = RsDocumentos
		
		With malla
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
			.set_ColWidth(2,  , 500)
			
			' establecer tipo de cuadrícula
			.AllowBigSelection = True
			.FillStyle = MSFlexGridLib.FillStyleSettings.flexFillRepeat
			
			' encabezado en negrita
			.set_TextMatrix(0, 0, "Nro")
			.set_TextMatrix(0, 1, "Cod")
			.set_TextMatrix(0, 2, "Porc")
			.Row = 0
			.col = 0
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
			'        HastaFec = FechaFinMes(Mid(PerPeriodo, 5, 2), Mid(PerPeriodo, 1, 4))
			'        i = 1
			'        If Malla.Rows > 1 Then
			'        Do Until i = 0
			'           If HastaFec < CorrijeNuloF(.TextMatrix(i, 3)) Then
			'                  Malla.RemoveItem (i)
			'           ElseIf IsDate(.TextMatrix(i, 4)) Then
			'                  If HastaFec > CorrijeNuloF(.TextMatrix(i, 4)) Then
			'                      Malla.RemoveItem (i)
			'                  Else
			'                      .TextMatrix(i, 0) = i
			'                      i = i + 1
			'                  End If
			'           Else
			'                  .TextMatrix(i, 0) = i
			'                  i = i + 1
			'           End If
			'           If i > Malla.Rows - 1 Then i = 0
			'        Loop
			'        End If
			.Redraw = True
		End With
		
	End Sub
	
	'UPGRADE_WARNING: El evento BuscaRetIvaServicios.Resize se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub BuscaRetIvaServicios_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		malla.SetBounds(VB6.TwipsToPixelsX(100), VB6.TwipsToPixelsY(100), VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.Width) - 300), VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.Height) - 300 - VB6.PixelsToTwipsY(cmdClose.Height)))
		cmdClose.SetBounds(VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.Width) - 100 - VB6.PixelsToTwipsX(cmdClose.Width)), VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.Height) - 50 - VB6.PixelsToTwipsY(cmdClose.Height)), 0, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)
	End Sub
	
	Private Sub Malla_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Malla.DblClick
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
		
		With malla
			.Redraw = False
			.Row = 1
			.RowSel = .Rows - 1
			.col = m_iSortCol
			.Sort = m_iSortType
			.Redraw = True
		End With
		
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		With malla
			
			Codigo = .get_TextMatrix(.Row, 1)
			Nombre = .get_TextMatrix(.Row, 2)
			valor = Val(.get_TextMatrix(.Row, 2))
		End With
		
		Me.Close()
		
	End Sub
End Class