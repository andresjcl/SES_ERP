Option Strict On
Option Explicit On
Friend Class BuscaFormasDoc
	Inherits System.Windows.Forms.Form
	Dim CodigoArt, Dedonde, CodigoRet As String
	Dim Sw As Boolean
	Dim SoloEspeciales As Boolean
    Private Sub btnbuscar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Retorna()
    End Sub
	
    Public Function IniciaBuscaClase(ByVal codigo As String, Optional ByVal Especial As Boolean = False, Optional ByVal DeDon As String = "") As String
        Dim OptNombre As Object
        Dedonde = DeDon
        CodigoArt = codigo
        SoloEspeciales = Especial
        VB6.ShowForm(Me, (1))
        IniciaBuscaClase = CodigoRet
        SaveSetting("ADCOM", "BUSCAR", "forma", IIf(OptNombre, 1, 0))
    End Function
	
    Private Sub btncancelarbusca_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        CodigoRet = CodigoArt
        Me.Close()
    End Sub
	
	'Private Sub btNuevo_Click()
	'Pro_Clases.Show vbModal
	'End Sub
	
	Private Sub BuscaFormasDoc_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'Me.Caption = "Buscar Clases Productos"
		Sw = False
		
		txtnombre.Text = CodigoArt
		ArreglaMalla()
		ListNombre.Redraw = True
		
	End Sub
	
	Private Sub listnombre_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles listnombre.DblClick
		If ListNombre.Rows = 0 Then Exit Sub
		With ListNombre
			If .get_TextMatrix(.Row, 1) > "" Then Retorna()
		End With
	End Sub
	
	Private Sub listnombre_KeyDownEvent(ByVal eventSender As System.Object, ByVal eventArgs As AxMSHierarchicalFlexGridLib.DMSHFlexGridEvents_KeyDownEvent) Handles listnombre.KeyDownEvent
		If eventArgs.KeyCode = System.Windows.Forms.Keys.Return Then listnombre_DblClick(listnombre, New System.EventArgs())
		If ListNombre.Rows = 0 Then Exit Sub
	End Sub
	
	Private Sub optcodigo_Click()
		txtnombre.Text = ""
		ArreglaMalla()
		ListNombre.Redraw = True
		
		txtnombre.Focus()
	End Sub
	
	Private Sub OptNombre_Click()
		On Error Resume Next
		txtnombre.Text = ""
		'Label2.Caption = ""
		ArreglaMalla()
        ListNombre.Redraw = True
        txtnombre.Focus()
	End Sub
	
	Private Sub ArreglaMalla()
		Dim Seleccion As Object
		Dim busca As Object
		Dim Dsubgrupo, Dcatego, Categorias, Dgrupo, Dclase As String
		Dim NomCod, codsql As String
		Dim rs As ADODB.Recordset
		Dim i As Short
		On Error Resume Next
		'UPGRADE_WARNING: Couldn't resolve default property of object busca. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		busca = txtnombre.Text 'almaceno lo que tiene la caja de textto
		'UPGRADE_WARNING: Couldn't resolve default property of object Seleccion. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Seleccion = "  l0 AS CODIGO, ISNULL(Ln, '') AS DESCRIPCION "
		If SoloEspeciales Then Categorias = " AND ISNULL(S2,'') = 'E' "
		NomCod = ""
		'UPGRADE_WARNING: Couldn't resolve default property of object busca. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: Couldn't resolve default property of object Seleccion. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		codsql = "SELECT " & Seleccion & " From sysforms WHERE l0 LIKE '%" & Trim(busca) & "%' and s1 = 'A' " & Categorias & " ORDER BY l0 "
		rs = New ADODB.Recordset
		rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		
		ListNombre.FixedRows = 1
		ListNombre.FixedCols = 1
		ListNombre.set_Cols( , 4)
		ListNombre.Redraw = False
		rs.Open(codsql, ConxAdcom, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		If rs.EOF Then Exit Sub
		ListNombre.DataSource = rs
		rs.Close()
		
		
		With ListNombre
			
			.set_ColWidth(0,  , 400)
			.set_TextMatrix(0, 1, "Codigo")
			.set_ColWidth(1,  , 1000)
			.set_TextMatrix(0, 2, "Descripción")
			.set_ColWidth(2,  , 3000)
			.Row = 1
			.Col = 1
			.Redraw = True
			.TopRow = .Rows - 1
			.TopRow = 1
		End With
		ListNombre.Redraw = True
		
	End Sub

    Private Sub btNuevo_Click(sender As Object, e As EventArgs) Handles btNuevo.Click

    End Sub

    Private Sub btncancelarbusca_Click_1(sender As Object, e As EventArgs) Handles btncancelarbusca.Click

    End Sub

    Private Sub btnbuscar_Click_1(sender As Object, e As EventArgs) Handles btnbuscar.Click

    End Sub

    Private Sub ToolTip1_Popup(sender As Object, e As PopupEventArgs) Handles ToolTip1.Popup

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub txtnombre_TextChanged(sender As Object, e As EventArgs) Handles txtnombre.TextChanged

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Retorna()
        If txtnombre.Text > "" Then
            CodigoRet = txtnombre.Text
        Else
            CodigoRet = ListNombre.get_TextMatrix(ListNombre.Row, 1)
        End If
        Me.Close()
    End Sub

    Private Sub txtnombre_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs)
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = System.Windows.Forms.Keys.Return Then ArreglaMalla()
        ListNombre.Redraw = True
    End Sub
End Class