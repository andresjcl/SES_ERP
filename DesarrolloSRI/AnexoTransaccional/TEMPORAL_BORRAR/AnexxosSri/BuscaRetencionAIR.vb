Option Strict Off
Option Explicit On
Friend Class BuscaRetencionAIR
	Inherits System.Windows.Forms.Form
	Private Const MARGIN_SIZE As Short = 60 ' en twips
	' variables para enlace de datos
	Private RsDocumentos As ADODB.Recordset
	
	' variables para permitir el orden de columnas
	Private m_iSortCol As Short
	Private m_iSortType As Short
	Private Nombre, codigo, Tipo As String
	Private Porcentaje As Double
	Dim tipbus As Short
	Dim Retencion As Boolean
	
	Public Sub Busca(ByRef QUECODIGO As String, ByRef QUENOMBRE As String, ByRef QUEPORCENTAJE As Double)
		Me.ShowDialog()
		QUECODIGO = codigo
		QUENOMBRE = Nombre
		QUEPORCENTAJE = Porcentaje
	End Sub
	Private Sub BuscaRetencionAIR_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim i As Object
		Dim Sw As Object
		Dim sSQL As String
		Dim Codi As Short
		sSQL = "Select * From SriConceptosRetencion "
		RsDocumentos = New ADODB.Recordset
		With RsDocumentos
			.Open(sSQL, ConxSyscod, ADOR.CursorTypeEnum.adOpenKeyset, ADOR.LockTypeEnum.adLockReadOnly)
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Sw. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Sw = True
			If .State = 0 Then
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Sw. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Sw = False
			ElseIf .EOF Then 
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Sw. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Sw = False
			End If
		End With
		Malla.DataSource = RsDocumentos
		With Malla
			.Redraw = False
			' establecer anchos de columna de cuadrícula
			
			.set_ColWidth(0,  , 300)
			.set_ColWidth(1,  , 400)
			.set_ColWidth(2,  , 5000)
			.set_ColWidth(3,  , -1)
			.set_ColWidth(4,  , -1)
			.set_ColWidth(5,  , -1)
			
			' establecer tipo de cuadrícula
			.AllowBigSelection = True
			.FillStyle = MSFlexGridLib.FillStyleSettings.flexFillRepeat
			
			' encabezado en negrita
			.set_TextMatrix(0, 0, "Nro")
			.set_TextMatrix(0, 1, "Cod")
			.set_TextMatrix(0, 2, "Concepto de la Retención")
			.set_TextMatrix(0, 3, "Porcentaje ")
			.set_TextMatrix(0, 4, "FechIni")
			.set_TextMatrix(0, 5, "FechFin")
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
		
	End Sub
	
	'UPGRADE_WARNING: El evento BuscaRetencionAIR.Resize se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub BuscaRetencionAIR_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		Malla.SetBounds(VB6.TwipsToPixelsX(100), VB6.TwipsToPixelsY(100), VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.Width) - 300), VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.Height) - 300 - VB6.PixelsToTwipsY(cmdClose.Height)))
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
			Porcentaje = CorrijeNuloN(.get_TextMatrix(.Row, 3))
		End With
		
		Me.Close()
		
	End Sub
End Class