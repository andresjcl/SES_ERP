Option Strict Off
Option Explicit On
Friend Class ImportaExcel
	Inherits System.Windows.Forms.Form
	Private Const MARGIN_SIZE As Short = 60 ' en twips
	Public TIPOTRA As Short
	Dim NomTipoTra(10) As String
	Dim NombreArch As String
	Dim Numerror As Short
	Dim fechass As String
	Dim fechasi As String
	Private m_iSortCol As Short
	Private m_iSortCol2 As Short
	Private m_iSortType As Short
	Public ConSumatoria As Integer
	
	Dim Cambiado As Boolean
	
	Private Sub ImportaExcel_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
		Dim i As Object
		Dim resp As Integer
		With Malla
			For i = 0 To .Cols - 1
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto i. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				SaveSetting("Ivaret", CStr(TIPOTRA), i, CStr(.get_ColWidth(i)))
			Next i
		End With
		If Cambiado = True Then
			resp = MsgBox("Desea grabar los datos de " & Me.Text & " antes de continuar ? ", MsgBoxStyle.YesNoCancel)
			If resp = MsgBoxResult.Cancel Then
				Cancel = 1
			ElseIf resp = MsgBoxResult.Yes Then 
				End
			End If
		End If
		eventArgs.Cancel = Cancel
	End Sub
	
	'UPGRADE_WARNING: El evento ImportaExcel.Resize se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub ImportaExcel_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		Dim sngButtonTop As Object
		
		Dim sngScaleWidth As Single
		Dim sngScaleHeight As Single
		On Error GoTo Form_Resize_Error
		With Me
			sngScaleWidth = VB6.PixelsToTwipsX(.ClientRectangle.Width)
			sngScaleHeight = VB6.PixelsToTwipsY(.ClientRectangle.Height)
			
			'        mueve el botón Cerrar a la esquina superior derecha
			'        With .cmdClose
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto sngButtonTop. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			sngButtonTop = sngScaleHeight - (MARGIN_SIZE)
			'                .Move sngScaleWidth - (.Width + MARGIN_SIZE), sngButtonTop
			'        End With
			
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto sngButtonTop. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Malla.SetBounds(VB6.TwipsToPixelsX(MARGIN_SIZE), VB6.TwipsToPixelsY(MARGIN_SIZE), VB6.TwipsToPixelsX(sngScaleWidth - (2 * MARGIN_SIZE)), VB6.TwipsToPixelsY(sngButtonTop - (4 * MARGIN_SIZE)))
			
		End With
		Exit Sub
		
Form_Resize_Error: 
		' evita errores en valores negativos
		Resume Next
		
	End Sub
	
	Private Sub cmdClose_Click()
		Me.Close()
	End Sub
	
	Sub FuncionesEspeciales(ByRef keycode As Short, ByRef Shift As Short)
		Dim Rrow, ccol As Integer
		Dim Campo, QUENOMBRE As String
		Dim QCol As Short
		Dim i As Integer
		Dim Ini, Finn As Integer
		Dim resp As Integer
		Rrow = Malla.Row
		ccol = Malla.Col
		If keycode = System.Windows.Forms.Keys.F3 Then
			If Rrow > 1 Then
				Malla.set_TextMatrix(Malla.Row, Malla.Col, Malla.get_TextMatrix(Rrow - 1, ccol))
			End If
			'    GrabarLinea Malla, TIPOTRA, Rrow
		ElseIf keycode = System.Windows.Forms.Keys.F5 Then 
			If Rrow > 1 Then
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Malla = Val(Malla.get_TextMatrix(Rrow - 1, ccol)) + Val(CStr(Malla))
			End If
			'    GrabarLinea Malla, TIPOTRA, Rrow
		ElseIf keycode = System.Windows.Forms.Keys.F8 Then 
			QUENOMBRE = Malla.get_TextMatrix(Rrow, ccol)
			Campo = InputBox("CAMBIAR EL VALOR ACTUAL : [" & QUENOMBRE & "] POR EL NUEVO VALOR: ", "CAMBIAR VALORES DE LA COLUMNA")
			resp = MsgBox("CONFIRMA EFECTUAR EL CAMBIO EN TODA LA COLUMNA ? " & vbCr & "Si presiona <NO>, se cambiará todo lo resaltado", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel)
			If resp <> MsgBoxResult.Cancel Then
				
				With Malla
					If resp = MsgBoxResult.No Then
						Ini = .Row
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.LaMalla.RowSel. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Finn = .LaMalla.RowSel
						For i = Ini To Finn
							.set_TextMatrix(i, ccol, Campo)
						Next i
					Else
						Ini = .FixedRows
						Finn = .Rows - 1
						For i = Ini To Finn
							If .get_TextMatrix(i, ccol) = QUENOMBRE Then .set_TextMatrix(i, ccol, Campo)
						Next i
					End If
				End With
				'GrabarMallaDatos TIPOTRA, Malla
			End If
		ElseIf keycode = System.Windows.Forms.Keys.F4 Then 
			QUENOMBRE = Malla.get_TextMatrix(Rrow, ccol)
			Campo = InputBox("CAMBIAR TODOS LOS VALORES ACTUALES DE LA COLUMNA POR:")
			If MsgBox("CONFIRMA EFECTUAR EL CAMBIO EN TODA LA COLUMNA ? " & vbCr & "No podrá deshacer este cambio", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
				With Malla
					Malla.Redraw = False
					For i = .FixedRows To .Rows - 1
						.set_TextMatrix(i, ccol, Campo)
					Next i
				End With
				'GrabarMallaDatos TIPOTRA, Malla
				Malla.Redraw = True
			End If
		ElseIf keycode = System.Windows.Forms.Keys.F10 Then 
			QUENOMBRE = InputBox("MOVER SELECCION DE LA COLUMNA " & Malla.Col & " A LA COLUMNA NRO:", "MOVER VALORES DE COLUMNAS", "O")
			Ini = Malla.Row
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.LaMalla.RowSel. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Finn = Malla.LaMalla.RowSel
			QCol = Val(QUENOMBRE)
			If QCol > 0 Then
				If MsgBox("CONFIRMA MOVER COLUMNA ACTUAL A COLUMNA " & QCol, MsgBoxStyle.YesNo, "MOVER COLUMNAS") = MsgBoxResult.Yes Then
					Malla.Redraw = False
					With Malla
						For i = Ini To Finn
							.set_TextMatrix(i, QCol, .get_TextMatrix(i, ccol))
							.set_TextMatrix(i, ccol, "")
						Next i
					End With
					'GrabarMallaDatos TIPOTRA, Malla
					Malla.Redraw = True
				End If
			End If
		ElseIf keycode = System.Windows.Forms.Keys.F9 Then 
			ccol = Malla.Col
			QUENOMBRE = InputBox("DIGITE FORMATO PARA EL CAMBIO :", "CAMBIAR VALORES CON FORMATO", "######0.00")
			If QUENOMBRE > "" Then
				If MsgBox("CONFIRMA CAMBIAR DATOS CON FORMATO EN TODA LA COLUMNA ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
					Malla.Redraw = False
					With Malla
						For i = .FixedRows To .Rows - 1
							.set_TextMatrix(i, ccol, VB6.Format(.get_TextMatrix(i, ccol), QUENOMBRE))
						Next i
					End With
					'GrabarMallaDatos TIPOTRA, Malla
					Malla.Redraw = True
				End If
			End If
		ElseIf keycode = System.Windows.Forms.Keys.F11 Then 
			QUENOMBRE = InputBox("COPIAR SELECCION DE LA COLUMNA " & Malla.Col & " A LA COLUMNA NRO:", "COPIAR VALORES DE COLUMNAS", "O")
			Ini = Malla.Row
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.LaMalla.RowSel. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Finn = Malla.LaMalla.RowSel
			QCol = Val(QUENOMBRE)
			If QCol > 0 Then
				If MsgBox("CONFIRMA COPIAR COLUMNA ACTUAL A COLUMNA " & QCol, MsgBoxStyle.YesNo, "COPIAR COLUMNAS") = MsgBoxResult.Yes Then
					Malla.Redraw = False
					'                If Ini = Finn Then
					'                    With Malla
					'                        For i = .FixedRows To .Rows - 1
					'                             .TextMatrix(i, QCol) = .TextMatrix(i, ccol)
					'                        Next i
					'                    End With
					'                Else
					With Malla
						For i = Ini To Finn
							.set_TextMatrix(i, QCol, .get_TextMatrix(i, ccol))
						Next i
					End With
					'                End If
					Malla.Redraw = True
				End If
			End If
		Else
			If TIPOTRA = 1 Then
				Campo = EspecialesCompras(keycode, (Malla.Row), (Malla.Col), (Malla.LaMalla))
			ElseIf TIPOTRA = 6 Then 
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Campo = EspecialesReoc(keycode, (Malla.Row), (Malla.Col), Malla)
			ElseIf TIPOTRA = 2 Then 
				Campo = EspecialesVentas(keycode, (Malla.Row), (Malla.Col), (Malla.LaMalla))
			ElseIf TIPOTRA = 3 Then 
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Campo = EspecialesImportaciones(keycode, (Malla.Row), (Malla.Col), Malla)
			End If
			If Campo > "" Then Malla.set_TextMatrix(Malla.Row, Malla.Col, Campo) : ' GrabarLinea Malla, TIPOTRA, Rrow
		End If
		If Campo > "" Then keycode = System.Windows.Forms.Keys.Return
	End Sub
	Public Sub Detalles()
		'If Val(Malla.TextMatrix(Malla.Row, Malla.Cols - 1)) = 0 Then MsgBox "No puede visualizarse este registro, grabe los datos y carguelos nuevamente": Exit Sub
		If TIPOTRA = 1 Then
			SRICOMPRAS.ClaveDoc = CStr(Val(Malla.get_TextMatrix(Malla.Row, Malla.Cols - 1)))
			SRICOMPRAS.ShowDialog()
			SRICOMPRAS.Close()
			'UPGRADE_NOTE: El objeto SRICOMPRAS no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			SRICOMPRAS = Nothing
		ElseIf TIPOTRA = 2 Then 
			SRIVENTAS.DocClave = Val(Malla.get_TextMatrix(Malla.Row, Malla.Cols - 1))
			SRIVENTAS.ShowDialog()
			SRIVENTAS.Close()
			'UPGRADE_NOTE: El objeto SRIVENTAS no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			SRIVENTAS = Nothing
		ElseIf TIPOTRA = 4 Then 
			SRIEXPORTA.IdClaveDoc = Val(Malla.get_TextMatrix(Malla.Row, Malla.Cols - 1))
			SRIEXPORTA.Fila = Malla.Row
			SRIEXPORTA.PasaMalla = Malla.LaMalla
			SRIEXPORTA.ShowDialog()
			SRIEXPORTA.Close()
			'UPGRADE_NOTE: El objeto SRIEXPORTA no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			SRIEXPORTA = Nothing
		End If
	End Sub
	
	Public Sub EliminaLinea()
		Dim LaLinea, LaCol As Integer
		Dim i, j As Integer
		If ConSumatoria > 0 Then
			If (Malla.Row = ConSumatoria Or Malla.Row = ConSumatoria - 1) Then Exit Sub
		End If
		If Malla.Rows = 2 Then For j = 1 To Malla.Cols - 1 : Malla.set_TextMatrix(1, j, "") : Next  : Exit Sub
		If Malla.Row = Malla.Rows - 1 Then LaLinea = Malla.Rows - 2 Else LaLinea = Malla.Row
		LaCol = Malla.Col
		malla_KeyDownEvent(malla, New AxDaxGridnvo.__DaxGridInNv_KeyDownEvent(46, 1, ""))
		Malla.Row = LaLinea
		Malla.Col = LaCol
	End Sub
	
	Public Sub Sumatoriass()
		Dim i, j As Integer
		If TIPOTRA = 5 Then Exit Sub
		If ConSumatoria > 0 Then ConSumatoria = 0 : Malla.Rows = Malla.Rows - 2 : Exit Sub
		With Malla
			
			If ConSumatoria = 0 Then .Rows = .Rows + 2 : ConSumatoria = .Rows - 1
			
			i = .Rows - 1
			For j = 1 To .Cols - 1
				If .get_ColAlignment(j) = 7 Then .set_TextMatrix(i, j, "")
			Next j
			
			For i = 2 To .Rows - 3
				For j = 1 To .Cols - 1
					If .get_ColAlignment(j) = 7 Then .set_TextMatrix(.Rows - 1, j, Val(.get_TextMatrix(.Rows - 1, j)) + Val(.get_TextMatrix(i, j)))
				Next j
			Next i
			i = .Rows - 1
			For j = 1 To .Cols - 1
				If .get_ColAlignment(j) = 7 Then .set_TextMatrix(i, j, VB6.Format(.get_TextMatrix(i, j), "####,###,##0.00"))
			Next j
			
		End With
	End Sub
	
	Public Sub BorraLaSumatoria()
		If ConSumatoria > 0 Then ConSumatoria = 0 : Malla.Rows = Malla.Rows - 2
	End Sub
	Public Sub ImprimirLaMalla()
		Dim prog As New PrntDax.ImpMalla
		'Dim mm As DaxGridIn
		'Dim hh As MSHFlexGrid
		''Set mm = Malla
		'Set hh = Malla.LaMalla
		Dim i As Integer
		For i = 0 To Malla.Cols - 1
			If Malla.get_ColWidth(i) < 0 Then Malla.set_ColWidth(i, 1200)
		Next i
		prog.ImprimirMalla((Malla.LaMalla), 62, 10, Me.Text & " Periodo ", 120, 0,  , True, True)
		'UPGRADE_NOTE: El objeto prog no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		prog = Nothing
	End Sub
	
	Private Sub ImportaExcel_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim TxtEdit As Object
		Dim i As Short
		On Error GoTo hayError
		NomTipoTra(1) = "COMPRAS LOCALES"
		NomTipoTra(2) = "VENTAS LOCALES"
		NomTipoTra(3) = "IMPORTACIONES O PAGOS AL EXTERIOR"
		NomTipoTra(4) = "EXPORTACIONES O INGRESOS DEL EXTERIOR"
		NomTipoTra(5) = "DOCUMENTOS ANULADOS"
		
		' Inicializar el cuadro de edición (lo carga ahora).
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto TxtEdit. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		TxtEdit = ""
		Me.Text = NomTipoTra(TIPOTRA)
		Cambiado = False
		Exit Sub
hayError: 
		ControlaErrores(("Load importaEx"))
	End Sub
	
	Function Fgi(ByRef R As Short, ByRef C As Short) As Short
		Fgi = C + Malla.Cols * R
	End Function
	
	Private Sub malla_KeyDownEvent(ByVal eventSender As System.Object, ByVal eventArgs As AxDaxGridnvo.__DaxGridInNv_KeyDownEvent) Handles malla.KeyDownEvent
		
		If eventArgs.keycode <= System.Windows.Forms.Keys.F12 And eventArgs.keycode >= System.Windows.Forms.Keys.F2 Then
			FuncionesEspeciales(eventArgs.keycode, eventArgs.Shift)
			'ElseIf keycode = 46 And Shift = 1 Then
			'    EliminarLinea malla.LaMalla, TIPOTRA
			'    ArreglaMalla malla.LaMalla, TIPOTRA
			'ElseIf keycode = 45 And Shift = 1 Then
			'    InsertarLinea malla.LaMalla
			''    ArreglaMalla Malla, TIPOTRA
		End If
		'malla.SetFocus
		
	End Sub
	
	'Private Sub Malla_KeyPress(KeyAscii As Integer)
	'   MSHFlexGridEdit malla, TxtEdit, KeyAscii
	'End Sub
	'
	'Private Sub malla_DblClick()
	'   MSHFlexGridEdit malla, TxtEdit, 32 ' Simula un espacio.
	'End Sub
	
	'Private Sub MSHFlexGridEdit(MSHFlexGrid As Control, _
	''Edt As Control, KeyAscii As Integer)
	''cambiar on error Resume Next
	'   ' Usar el carácter escrito.
	'   Select Case KeyAscii
	'
	'   ' Un espacio significa modificar el texto actual.
	'   Case 0 To 32
	'      Edt = MSHFlexGrid
	'      Edt.SelStart = 1000
	'
	'   ' Otro carácter reemplaza el texto actual.
	'   Case Else
	'      Edt = Chr(KeyAscii)
	'      Edt.SelStart = 1
	'   End Select
	'
	'   ' Mostrar Edt en la posición correcta.
	'   Edt.Move MSHFlexGrid.Left + MSHFlexGrid.CellLeft, _
	''      MSHFlexGrid.Top + MSHFlexGrid.CellTop, _
	''      MSHFlexGrid.CellWidth - 8, _
	''      MSHFlexGrid.CellHeight - 8
	'   Edt.Visible = True
	'
	'   ' Y hacer que funcione.
	'   Edt.SetFocus
	'End Sub
	
	Public Sub propiedades()
		Dim Alx As New ManDirct.DirectorioAlex
		Dim Aux As String
		Dim existe As Boolean
		Dim Rrow As Short
		Dim nom As String
		Rrow = 0
		If TIPOTRA = 1 Then Rrow = 3
		If TIPOTRA = 2 Or TIPOTRA = 6 Then Rrow = 2
		nom = Malla.get_TextMatrix(Malla.Row, Rrow)
		If Rrow > 0 Then
			Alx = New ManDirct.DirectorioAlex
			Aux = nom
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Alx.CargarAlex. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			existe = Alx.CargarAlex(Aux, True)
			If existe = False Then
				Aux = " No existe este numero de identificacion"
			Else
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Alx.NombreImpresion. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Aux = Alx.NombreImpresion
			End If
			MsgBox(nom & "  " & Aux, MsgBoxStyle.OKOnly, "Nombre del codigo de identificacion")
		End If
	End Sub
	
	Public Sub PonerNombres()
		Dim Alx As New ManDirct.DirectorioAlex
		Dim existe As Boolean
		Dim Rrow As Short
		Dim nom As String
		Dim i As Short
		
		Rrow = 0
		If TIPOTRA = 1 Then Rrow = 3
		If TIPOTRA = 2 Or TIPOTRA = 6 Then Rrow = 2
		If Rrow = 0 Then Exit Sub
		Alx = New ManDirct.DirectorioAlex
		With Malla
			.Redraw = False
			For i = 2 To .Rows - 1
				nom = Malla.get_TextMatrix(i, Rrow)
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Alx.CargarAlex. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				existe = Alx.CargarAlex(nom, True)
				If existe = False Then
					.set_TextMatrix(i, 0, nom)
				Else
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Alx.NombreImpresion. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.set_TextMatrix(i, 0, Alx.NombreImpresion)
				End If
			Next i
			.set_ColWidth(0, 3000)
			.Redraw = True
		End With
		'UPGRADE_NOTE: El objeto Alx no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		Alx = Nothing
	End Sub
	
	Public Sub PonerNumeros()
		Dim i As Short
		With Malla
			.Redraw = False
			For i = 2 To .Rows - 1
				.set_TextMatrix(i, 0, i - 1)
			Next i
			.set_ColWidth(0, 500)
			.Redraw = True
		End With
		
	End Sub
	'Private Sub malla_RowColChange()
	'ArreglaEstado
	'End Sub
	'
	'Sub txtEdit_KeyPress(KeyAscii As Integer)
	'   ' Elimina los retornos para quitar los pitidos.
	'   If KeyAscii = Asc(vbCr) Then KeyAscii = 0
	'End Sub
	'
	'Sub txtEdit_KeyDown(keycode As Integer, _
	''Shift As Integer)
	'   EditKeyCode Malla, TxtEdit, keycode, Shift
	'End Sub
	'
	'Sub EditKeyCode(MSHFlexGrid As Control, Edt As _
	''Control, keycode As Integer, Shift As Integer)
	'
	'   ' Procesamiento del control de edición estándar.
	'   Select Case keycode
	'
	'   Case 27   ' ESC: ocultar, devuelve el enfoque a            ' MSFlexGrid.
	'      Edt.Visible = False
	'      MSHFlexGrid.SetFocus
	'   Case 13   ' ENTRAR devuelve el enfoque a MSHFlexGrid.
	'      MSHFlexGrid.SetFocus
	'      DoEvents
	'      If Malla.Col < Malla.Cols - 1 Then Malla.Col = Malla.Col + 1
	'   Case 37      ' izquierda
	'      If TxtEdit.SelStart < 1 And Malla.Col > 1 Then
	'        MSHFlexGrid.SetFocus
	'        DoEvents
	'        Malla.Col = Malla.Col - 1
	'      End If
	'   Case 38      ' Arriba.
	'      MSHFlexGrid.SetFocus
	'      DoEvents
	'      If MSHFlexGrid.Row > MSHFlexGrid.FixedRows Then
	'         MSHFlexGrid.Row = MSHFlexGrid.Row - 1
	'      End If
	'   Case 39      'derecha
	'      If TxtEdit.SelStart = Len(TxtEdit) And Malla.Col < Malla.Cols - 1 Then
	'        MSHFlexGrid.SetFocus
	'        DoEvents
	'        MSHFlexGrid.SetFocus: Malla.Col = Malla.Col + 1
	'      End If
	'   Case 40      ' Abajo.
	'      MSHFlexGrid.SetFocus
	'      DoEvents
	'      If MSHFlexGrid.Row < MSHFlexGrid.Rows - 1 Then
	'         MSHFlexGrid.Row = MSHFlexGrid.Row + 1
	'      End If
	'   End Select
	'End Sub
	
	'Sub malla_GotFocus()
	'   If TxtEdit.Visible = False Then Exit Sub
	'   If Malla.LaMalla <> TxtEdit Then
	'        Malla.LaMalla = TxtEdit
	'        CambiaMalla
	'   End If
	'   TxtEdit.Visible = False
	'End Sub
	
	'Sub malla_LeaveCell()
	'   If TxtEdit.Visible = False Then Exit Sub
	'   If Malla.LaMalla <> TxtEdit Then
	'        Malla.LaMalla = TxtEdit
	'        CambiaMalla
	'   End If
	'   TxtEdit.Visible = False
	'End Sub
	
	Sub ValidarDatos()
		Dim NroErrores As Object
		Dim PrevisualPro As Object
		Dim Autor, TipDoc As String
		Dim Caduca As Date
		Dim i As Short
		Dim ValVal As Object
		Exit Sub
		i = Rnd(10) * 1000
		NombreArch = "\tmp\IVARET" & i & ".ERR"
		FileOpen(1, NombreArch, OpenMode.Output)
		
		' cambiar 'cambiar on error GoTo 0 'Resume Next
		Numerror = 0
		With Malla
			If TIPOTRA = 1 Then
				With Malla
					For i = 1 To Malla.Rows - 1
						'            If CargarSustento(Val(.TextMatrix(i, 1))) = False Then ExisteErrores "Codigo de sustento tributario invalido", i
						If Not (.get_TextMatrix(i, 2) = "S" Or .get_TextMatrix(i, 2) = "N") Then ExisteErrores("Devolucion de Iva solo se acepta 'S' o 'N'", i)
						If ValidaId(.get_TextMatrix(i, 4), .get_TextMatrix(i, 3)) = False Then ExisteErrores("Tipo o Numero de ifdentificación errado", i)
						If Not IsDate(.get_TextMatrix(i, 10)) Then
							ExisteErrores("Fecha de documento errada", i)
						Else
							ValidaAutorización(.get_TextMatrix(i, 10), .get_TextMatrix(i, 11), .get_TextMatrix(i, 12), i)
						End If
						If Not IsDate(.get_TextMatrix(i, 6)) Then ExisteErrores("Fecha de contabilizacion errada", i)
						If ValidaPeriodo(.get_TextMatrix(i, 6), PerAnio, PerMes) = False Then ExisteErrores("El documento no corresponde al periodo " & VB6.Format("01/" & PerMes & "/1990", "mmmm") & " " & PerAnio, i)
						
						'            If CargarDocumentoSri(PerPeriodo, 1, Val(.TextMatrix(i, 1)), .TextMatrix(i, 3), .TextMatrix(i, 5)) = False Then ExisteErrores "El tipo de documento esta errado ", i
						If ValidaIva(.get_TextMatrix(i, 15), CDate(.get_TextMatrix(i, 10))) = False Then ExisteErrores("El tipo de porcentaje de IVA está errado", i)
						If ValidaIce(CShort(.get_TextMatrix(i, 18))) = False Then ExisteErrores("El tipo de porcentaje de ICE está errado", i)
						
CONTINUA: 
					Next 
				End With
			End If
		End With
		FileClose(1)
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto NroErrores. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If NroErrores > 0 Then
			If MsgBox("EXISTEN ERRORES EN LA VALIDACION " & vbCr & "DESEA REVISARLOS ? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto PrevisualPro.TA_Click. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				PrevisualPro.TA_Click(NombreArch)
			End If
		End If
		Kill(NombreArch)
	End Sub
	
	
	Sub ordenar_malla()
		'-------------------------------------------------------------------------------------------
		' el código del evento DblClick de la cuadrícula permite ordenar columnas
		'-------------------------------------------------------------------------------------------
		
		Dim i As Integer
		Dim j As Integer
		Dim Col As Short
		Dim Com As String
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.LaMalla.ColSel. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		m_iSortCol2 = Malla.LaMalla.ColSel
		' sólo ordena cuando se hace clic en una fila
		'If malla.MouseRow >= malla.FixedRows Then Exit Sub
		'        If PorCliente = False Then Exit Sub
		
		i = m_iSortCol ' guarda la columna antigua
		m_iSortCol = Malla.Col ' establece la nueva columna
		
		' incrementa el tipo de orden
		If i <> m_iSortCol Then
			' si hace clic en una columna nueva, inicia con orden ascendente
			m_iSortType = 1
		Else
			' si hace clic en la misma columna, alterna entre orden ascendente y orden descendente
			m_iSortType = m_iSortType + 1
			If m_iSortType = 3 Then m_iSortType = 1
		End If
		
		DoColumnSort()
		
	End Sub
	
	Private Sub DoColumnSort()
		'-------------------------------------------------------------------------------------------
		' orden de tipo intercambio en la columna m_iSortCol
		'-------------------------------------------------------------------------------------------
		'cambiar on error Resume Next
		Dim Tipo As Short
		With Malla
			.Redraw = False
			.Row = 2
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.LaMalla.RowSel. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.LaMalla.RowSel = .Rows - 1
			.Col = m_iSortCol
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.LaMalla.ColSel. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.LaMalla.ColSel = m_iSortCol2
			'        Select Case TIPOTRA
			'        Case 2
			'            Tipo = IIf(.Col = 2, m_iSortType + 4, m_iSortType)
			'        Case 1
			'            If .Col = 5 Then
			'                Tipo = m_iSortType + 4
			'            ElseIf .Col = 3 Then
			'                Tipo = m_iSortType + 6
			'            Else
			'                Tipo = m_iSortType
			'            End If
			''           .Sort = IIf(.Col = 5, , m_iSortType)
			'        End Select
			If .get_ColAlignment(m_iSortCol) = 7 Then Tipo = m_iSortType + 3 Else Tipo = m_iSortType + 6
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.LaMalla.Sort. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.LaMalla.Sort = Tipo
			.Row = 2
			.Redraw = True
		End With
		
	End Sub
	
	Private Sub Malla_MouseDown(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		'-------------------------------------------------------------------------------------------
		' el código de los eventos DragDrop, MouseDown, MouseMove y MouseUp permite arrastrar columnas
		'-------------------------------------------------------------------------------------------
		'  If Button = 2 Then PopupMenu MdTransacciones.MenuPop: Exit Sub
		
	End Sub
	
	Private Sub ArreglaEstado()
		'UPGRADE_WARNING: El límite inferior de la colección estado.Panels cambió de 1 a 0. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		estado.Items.Item(1).Text = "Registros: " & Malla.Rows - 2
		'UPGRADE_WARNING: El límite inferior de la colección estado.Panels cambió de 1 a 0. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		estado.Items.Item(2).Text = "Linea: " & Malla.Row
		'UPGRADE_WARNING: El límite inferior de la colección estado.Panels cambió de 1 a 0. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		estado.Items.Item(3).Text = "Columna: " & Malla.Col
	End Sub
	Sub CambiarMerge()
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.LaMalla.MergeCells. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Malla.LaMalla.MergeCells <> MSFlexGridLib.MergeCellsSettings.flexMergeNever Then
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.LaMalla.MergeCells. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Malla.LaMalla.MergeCells = MSFlexGridLib.MergeCellsSettings.flexMergeNever
		Else
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.LaMalla.MergeCells. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Malla.LaMalla.MergeCells = MSFlexGridLib.MergeCellsSettings.flexMergeFree
		End If
	End Sub
	
	Private Sub CambiaMalla()
		'Dim rs As New ADODB.Recordset
		Cambiado = True
		'GrabarLinea Malla, TIPOTRA
	End Sub
	
	Public Sub RegistrarTotalesVentas()
		Dim prog As New Form1
		Dim año As Short
		Dim mes As Short
		año = PerAnio
		mes = PerMes
		prog.año = año
		prog.mes = mes
		prog.ShowDialog()
		'UPGRADE_NOTE: El objeto prog no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		prog = Nothing
		
	End Sub
End Class