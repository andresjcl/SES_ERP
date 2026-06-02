Option Strict Off
Option Explicit On
Module RutinasExcel
	
	Public AppExcel As Microsoft.Office.Interop.Excel.Application
	Public WbHojaSri As Microsoft.Office.Interop.Excel.Workbook
	'
	'Public shtWorld As Excel.Worksheet
	Dim Saltar As Boolean
	Sub Setup(ByRef NomHoja As String)
		'cambiar on error Resume Next
		' IMPORTANTE: si su equipo no tiene Excel 97 instalado,
		' debe cambiar la referencia a la biblioteca de objetos de Excel 95.
		' Después, en la sección de declaraciones, cambie la declaración de
		' variable "WbHojaSri as Workbook" a "shtWorld As Worksheet."
		' Finalmente, cambie todas las referencias de "WbHojaSri" a "shtWorld."
		
		'cambiar on error Resume Next 'ignorar errores
		AppExcel = GetObject( , "Excel.Application") 'buscar una copia de Excel en ejecución
		If Err.Number <> 0 Then 'Si no se ejecuta Excel
			AppExcel = CreateObject("Excel.Application") 'ejcutarlo
		End If
		Err.Clear() ' Borrar el objeto Err si se produce un error.
		
		''cambiar on error GoTo 0 'Reaunudar el procesamiento normal de errores
		
		WbHojaSri = AppExcel.Workbooks.Open(NomHoja)
		
	End Sub
	
	' Establece los objetos a Nothing.
	Sub CleanUp()
		' Esto fuerza la descarga de Microsoft Excel,
		' suponiendo que no lo hayan cargado otras aplicaciones u otros usuarios.
		'UPGRADE_NOTE: El objeto AppExcel no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		AppExcel = Nothing
		'UPGRADE_NOTE: El objeto WbHojaSri no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		WbHojaSri = Nothing
	End Sub
	
	Sub LlenarHojas(ByRef ListaHoja As System.Windows.Forms.ComboBox)
		Dim QueHojas As Microsoft.Office.Interop.Excel.Worksheet
		'cambiar on error Resume Next
		'cambiar on error Resume Next
		ListaHoja.Items.Clear()
		' Recorre la colección de hojas y agrega
		' el nombre de cada hoja al cuadro combinado.
		For	Each QueHojas In WbHojaSri.Sheets
			ListaHoja.Items.Add(QueHojas.Name)
		Next QueHojas
		' Selecciona el primer elemento y lo muestra en el cuadro combinado.
		ListaHoja.Text = VB6.GetItemString(ListaHoja, 0)
		
		'UPGRADE_NOTE: El objeto QueHojas no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		QueHojas = Nothing
	End Sub
	
	Sub LlenarMalla(ByRef NombreHoja As String, ByRef Malla As AxMSHierarchicalFlexGridLib.AxMSHFlexGrid, ByRef linea As Integer, ByRef Columna As Integer)
		Dim QueHojas As Microsoft.Office.Interop.Excel.Worksheet
		Dim QueLinea As Microsoft.Office.Interop.Excel.Range
		Dim j As Short
		Dim i As Short
		Dim TerminaLin As Boolean
		Dim TerminaCol As Boolean
		Dim UlLinVacia, UlColVacia As Integer
		Dim ImprimeLinea As Boolean
		'   Dim fini As Date, ffin As Date
		Dim ii As Short
		Dim Aux As String
		Dim rr, cc As Short
		QueHojas = WbHojaSri.Sheets(NombreHoja)
		
		If linea = 0 Then linea = 640000
		If Columna = 0 Then Columna = 254
		i = 0
		j = i
		UlLinVacia = i
		UlColVacia = i
		ImprimeLinea = False
		'fini = Now
		
		With Malla
			.set_Cols( , 255)
			.Redraw = False
			For i = 1 To Columna
				If ImprimeLinea Then UlLinVacia = 0 Else UlLinVacia = UlLinVacia + 1 : If UlLinVacia > 10 Then Exit For
				UlColVacia = 0
				ImprimeLinea = False
				ii = i + 1
				If ii >= .Rows Then .Rows = i + 2
				For j = 1 To Columna
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto QueHojas.Cells(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Aux = QueHojas.Cells._Default(i, j)
					If Aux > "" Then
						'If J >= .Cols Then .Cols = J + 1
						.set_TextMatrix(ii, j, Aux)
						UlColVacia = 0
						ImprimeLinea = True
					Else
						UlColVacia = UlColVacia + 1
					End If
					If UlColVacia > 15 Then Exit For
				Next 
			Next 
			.Redraw = True
		End With
		
		'ffin = Now
		'MsgBox DateDiff("s", fini, ffin)
		'    For i = 1 To 2000
		'    For j = 1 To 40
		'        MsgBox i & " " & j & " " & rngFeatureList.Cells(i, j)
		''           frmGeoFacts.cmbFeatures.AddItem rngFeatureList.Cells(1, loop1)
		'    Next
		'    Next
		'    ' Selecciona el primer elemento y lo muestra en el cuadro combinado.
		'    frmGeoFacts.cmbFeatures.Text = frmGeoFacts.cmbFeatures.List(0)
		
		' Limpiar.
		'UPGRADE_NOTE: El objeto QueHojas no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		QueHojas = Nothing
		'UPGRADE_NOTE: El objeto QueLinea no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		QueLinea = Nothing
	End Sub
	
	'' Llena la lista de elementos por rango.
	'Sub FillTopRankingList()
	'    Dim QueHojas As Excel.Worksheet
	'    Dim intColumOfFeature As Integer
	'    Dim rngRankedList As Excel.Range
	'    Dim intFirstBlankCell As Integer
	'    Dim loop1 As Integer
	'
	'    ' Obtiene la hoja cuyo nombre es el del continente seleccionado en el cuadro combinado Continentes.
	'    Set QueHojas = WbHojaSri.Sheets(frmGeoFacts.cmbContinents.Text)
	'
	'    ' Borra el contenido anterior del cuadro de lista lstTopRanking.
	'    frmGeoFacts.lstTopRanking.Clear
	'
	'    ' Si la selección de Característica del continente está vacía, no hace nada.
	'    If (frmGeoFacts.cmbFeatures <> "") Then
	'
	'        ' Busca la columna de la característica seleccionada en la primera fila de la hoja de cálculo.
	'        intColumOfFeature = QueHojas.Rows(1).Find(frmGeoFacts.cmbFeatures.Text).Column
	'
	'        ' Asigna la columna a un objeto.
	'         Set rngRankedList = QueHojas.Columns(intColumOfFeature)
	'
	'        ' Comprueba si es una lista vacía.
	'        If (rngRankedList.Cells(1, 1) = "") Then
	'            intFirstBlankCell = 0
	'        Else
	'            ' Busca la primera celda en blanco de la fila.
	'            intFirstBlankCell = rngRankedList.Find("").Row
	'        End If
	'
	'        ' Agrega los elementos en el cuadro de lista lstTopRanking.
	'        For loop1 = 2 To intFirstBlankCell
	'            frmGeoFacts.lstTopRanking.AddItem rngRankedList.Cells(loop1, 1)
	'        Next
	'
	'        ' Muestra la nueva lista.
	'        frmGeoFacts.lstTopRanking.Visible = True
	'
	'    End If
	'
	'    ' Limpiar.
	'    Set QueHojas = Nothing
	'    Set rngRankedList = Nothing
	'End Sub
	'
End Module