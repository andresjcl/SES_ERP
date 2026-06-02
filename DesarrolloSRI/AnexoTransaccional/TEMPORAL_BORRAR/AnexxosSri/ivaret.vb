Option Strict Off
Option Explicit On
Module Moduleivaret
	Public NumeroDeDigitos, NumeroDecimales As Short
	Public SiNocierre As Boolean
	Public auxcostotot, auxcostounit As Double
	Public TITULOS As String
	Public sql, COD_USUARIO As String
	Public impresora As Short
	Public PerAnio, PerMes As Short
	Public PerPeriodo, FecPeriodo As String
	Public Reocc As Boolean
	
	Public Sub CierraMódulos()
		Dim i As Short
		For i = My.Application.OpenForms.Count - 1 To 1 Step -1
			'UPGRADE_ISSUE: Forms() de descarga no se actualizó. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="875EBAD7-D704-4539-9969-BC7DBDAA62A2"'
			Unload(My.Application.OpenForms(i))
		Next i
	End Sub
	
	Public Sub salirform(ByRef forma As Object)
		'Dim esnuevo As Integer
		'Dim salir As Integer
		'Dim sisale As Integer
		'esnuevo = auxvec1(0)
		'salir = auxvec1(1)
		'If salir <> 1 Then
		'   If esnuevo = 0 Or esnuevo = 1 Then
		'      sisale = MsgBox("Desea grabar el registro actual", 36)
		'       If sisale = vbYes Then
		'           forma.Grabar
		'       End If
		'   End If
		'End If
		
	End Sub
	Public Sub centrarforma(ByRef forma As System.Windows.Forms.Form)
		titulo(forma)
	End Sub
	Public Sub titulo(ByRef forma As System.Windows.Forms.Form)
		Dim a As String
		Dim Control As System.Windows.Forms.Control
		a = forma.Text
		'cambiar on error Resume Next
		forma.Text = forma.Text & " - " & Emp.SucNomActual & VB6.Format("01/" & PerMes & "/" & PerAnio, "MMMM") & " " & PerAnio
	End Sub
	
	Public Function rehacermalla(ByRef forma As Object, ByRef rowsmalla As Short) As Object
		Dim i As Short
		For i = 0 To rowsmalla
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto forma.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			forma.TextMatrix(i, 0) = i + 1
		Next i
	End Function
	
	Public Sub PonerFecTxt(ByRef TXT As System.Windows.Forms.TextBox, ByRef KCode As Short)
		If KCode = System.Windows.Forms.Keys.F3 Then
			TXT.Text = CStr(Today)
		End If
	End Sub
	
	Public Function ArmCodSQL(ByRef Campo As String, ByRef lug As String, ByRef Num As Short, Optional ByRef con As String = "", Optional ByRef SNWhere As Boolean = False) As String
		' campo: nombre de la tabla
		' lug: todos las suc, bod o doc
		' num: numero de lugares
		' con: conector logico OR o  AND
		Dim Temp As String
		Dim cont As Short : cont = 1
		Dim contLargo As Short : contLargo = 1
		Dim contPos As Short : contPos = 1
		If SNWhere Then Temp = " WHERE "
		
		
		Do While cont <= Num
			If contPos = Len(lug) And cont = 1 Then
				Temp = Temp & Campo & "='" & Mid(lug, contPos - contLargo + 1, contLargo) & "' "
				contLargo = 1
				cont = cont + 1
			ElseIf Mid(lug, contPos, 1) = " " Or contPos = Len(lug) Then 
				If cont = 1 Then
					Temp = Temp & "(" & Campo & "='" & Mid(lug, contPos - contLargo + 1, contLargo - 1) & "' "
				ElseIf contPos < Len(lug) Then 
					Temp = Temp & "OR " & Campo & "='" & Mid(lug, contPos - contLargo + 2, contLargo - 2) & "' "
				ElseIf contPos = Len(lug) Then 
					Temp = Temp & "OR " & Campo & "='" & Mid(lug, contPos - contLargo + 2, contLargo - 1) & "') "
				End If
				contLargo = 1
				cont = cont + 1
			End If
			contPos = contPos + 1
			contLargo = contLargo + 1
		Loop 
		
		'CUANDO NO TENGA ACCESA A NADA
		If Num = 0 Then Temp = Temp & Campo & "='XXXX' "
		
		'UPGRADE_NOTE: IsMissing() ha cambiado a IsNothing(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"'
		If Temp <> " WHERE " And Not IsNothing(con) Then
			ArmCodSQL = Temp & con & " "
			'UPGRADE_NOTE: IsMissing() ha cambiado a IsNothing(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"'
		ElseIf Temp = " WHERE " And Not IsNothing(con) Then 
			ArmCodSQL = Temp
			'UPGRADE_NOTE: IsMissing() ha cambiado a IsNothing(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"'
		ElseIf Temp = " WHERE " And IsNothing(con) Then 
			ArmCodSQL = ""
		End If
	End Function
	
	Public Function solonumero(ByRef KeyAscii As Short) As Short
		Select Case KeyAscii
			Case 48 To 57, 8, 46, 44, 45, 46
				solonumero = KeyAscii
			Case Else
				solonumero = 0
		End Select
		'  If Not ((Keyascii >= 48 And Keyascii <= 59) Or (Keyascii = 8) Or (Keyascii = 46) Or (Keyascii = 44)) Then Keyascii = 0
		'     SoloNumeros = Keyascii
	End Function
	
	Public Function IngresaSoloNumero(ByRef KeyAscii As Short) As Short
		Select Case KeyAscii
			'44 ,  45 - 46 .  8 <--
			Case 48 To 57, 8
				IngresaSoloNumero = KeyAscii
			Case Else
				IngresaSoloNumero = 0
		End Select
	End Function
	Public Function IngresaSoloValores(ByRef KeyAscii As Short, ByRef Variable As String) As Short
		Select Case KeyAscii
			Case 48 To 57, 8
				IngresaSoloValores = KeyAscii
			Case 45, 46
				If InStr(1, Variable, Chr(KeyAscii)) = 0 Then
					IngresaSoloValores = KeyAscii
				Else
					IngresaSoloValores = 0
				End If
			Case Else
				IngresaSoloValores = 0
		End Select
		
	End Function
	
	Public Function IngresaSoloFechas(ByRef KeyAscii As Short, ByRef Variable As System.Windows.Forms.TextBox) As Short
		Dim i As Short
		i = Len(Variable.Text)
		Select Case KeyAscii
			Case 48 To 57
				If i = 2 Or i = 5 Then
					Variable.Text = Variable.Text & "/"
					Variable.SelectionStart = i + 1
				End If
				IngresaSoloFechas = KeyAscii
			Case 47
				If i <> 2 And i <> 5 Then IngresaSoloFechas = 0 Else IngresaSoloFechas = KeyAscii
			Case 8
				IngresaSoloFechas = KeyAscii
			Case Else
				IngresaSoloFechas = 0
		End Select
	End Function
	
	Public Sub CargarFlechas(ByRef forma As System.Windows.Forms.Form)
		With forma
			'UPGRADE_ISSUE: Control btInicio no se pudo resolver porque está dentro del espacio de nombres genérico Form. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
			.btInicio.Picture = My.Resources.ico112
			'UPGRADE_ISSUE: Control btAnterior no se pudo resolver porque está dentro del espacio de nombres genérico Form. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
			.btAnterior.Picture = My.Resources.ico113
			'UPGRADE_ISSUE: Control btsiguiente no se pudo resolver porque está dentro del espacio de nombres genérico Form. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
			.btsiguiente.Picture = My.Resources.ico114
			'UPGRADE_ISSUE: Control btUltimo no se pudo resolver porque está dentro del espacio de nombres genérico Form. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"'
			.btUltimo.Picture = My.Resources.ico115
		End With
	End Sub
	
	Public Function PonerFormatoNumeroSRI(ByRef ValorRetorna As Object) As Object
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ValorRetorna. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Not IsNumeric(ValorRetorna) Then ValorRetorna = 0
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ValorRetorna. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		PonerFormatoNumeroSRI = VB6.Format(System.Math.Round(ValorRetorna, 2), "#########0.00")
	End Function
	
	Public Function QuitarMarca(ByRef Auxil As String) As String
		Dim m As Short
		m = InStr(1, Auxil, "&")
		If m > 0 Then
			QuitarMarca = Left(Auxil, m - 1) & Mid(Auxil, m + 1)
		Else : QuitarMarca = Auxil
		End If
	End Function
	
	Public Function Calculadora() As Double
		Dim calc As calculador.Calcula
		calc = New calculador.Calcula
		Calculadora = calc.Valor
		'UPGRADE_NOTE: El objeto calc no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		calc = Nothing
	End Function
	
	Public Function QueFecha() As Date
		Dim fecha As New fecha.Calendario
		'Set fecha = New Calendario
		QueFecha = fecha.fecha
		'UPGRADE_NOTE: El objeto fecha no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		fecha = Nothing
	End Function
	
	'Public Function ArmFormatoFecha(fecha As String, Optional Tipbase As String) As String
	'Dim sSQL As String
	'        ArmFormatoFecha = "'" & Format(fecha, "dd/mm/yyyy") & "'"
	'End Function
	
	Public Function ClienteMovimiento(ByRef codigo As String) As Boolean
		Dim cod As String
		Dim rs As New ADODB.Recordset
		ClienteMovimiento = False
		If ConxAdcom.State = 1 Then
			cod = " SELECT AdcDoc.Doc_codper " & " From AdcDoc " & " Where AdcDoc.Doc_codper = '" & codigo & "' "
			rs = New ADODB.Recordset
			rs.Open(cod, ConxAdcom, ADOR.CursorTypeEnum.adOpenForwardOnly, ADOR.LockTypeEnum.adLockOptimistic)
			If rs.State = 1 Then
				If rs.EOF = False Then ClienteMovimiento = True
				rs.Close()
			End If
		End If
	End Function
	
	Public Sub EliminarLinea(ByRef Malla As AxMSHierarchicalFlexGridLib.AxMSHFlexGrid, ByRef TIPOTRA As Object)
		Dim i As Short
		'cambiar on error Resume Next
		If MsgBox("Confirma Eliminar la Linea Actual ", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
			If Val(Malla.get_TextMatrix(Malla.Row, Malla.get_Cols() - 1)) > 0 Then
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto TIPOTRA. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If TIPOTRA = 1 Then
					ConxSri.Execute("DELETE FROM COMPRAS WHERE CLAVE = " & Malla.get_TextMatrix(Malla.Row, Malla.get_Cols() - 1))
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto TIPOTRA. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf TIPOTRA = 2 Then 
					ConxSri.Execute("DELETE FROM ventas WHERE CLAVE = " & Malla.get_TextMatrix(Malla.Row, Malla.get_Cols() - 1))
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto TIPOTRA. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf TIPOTRA = 3 Then 
					ConxSri.Execute("DELETE FROM importacion WHERE CLAVE = " & Malla.get_TextMatrix(Malla.Row, Malla.get_Cols() - 1))
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto TIPOTRA. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf TIPOTRA = 4 Then 
					ConxSri.Execute("DELETE FROM anulados WHERE CLAVE = " & Malla.get_TextMatrix(Malla.Row, Malla.get_Cols() - 1))
				End If
			End If
			If Malla.Rows > Malla.FixedRows + 1 Then
				Malla.RemoveItem((Malla.Row))
			Else
				For i = 0 To Malla.get_Cols() - 1
					Malla.set_TextMatrix(Malla.Row, i, "")
				Next i
			End If
			RenumerarMalla(Malla)
		End If
		
	End Sub
	
	Public Sub InsertarLinea(ByRef Malla As AxMSHierarchicalFlexGridLib.AxMSHFlexGrid)
		Dim i As Short
		Malla.Redraw = False
		With Malla
			If .Row = .Rows - 1 Then
				.Rows = .Rows + 1
				.Row = .Rows - 1
			Else
				.AddItem("", .Row + 1)
				.Row = .Row + 1
				
			End If
			.Col = 1
			For i = .FixedCols To .get_Cols() - 1 Step 2
				.Col = i
				.CellBackColor = System.Drawing.ColorTranslator.FromOle(&HF7E7E1) '&HC0C0C0   ' gris claro
			Next i
			RenumerarMalla(Malla)
			'UPGRADE_NOTE: Refresh se actualizó a CtlRefresh. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			.CtlRefresh()
		End With
		Malla.Redraw = True
		
	End Sub
	Public Sub RenumerarMalla(ByRef Malla As AxMSHierarchicalFlexGridLib.AxMSHFlexGrid)
		Dim i As Short
		For i = 1 To Malla.Rows - 1
			If Val(Malla.get_TextMatrix(i, 0)) = 0 Then Malla.set_TextMatrix(i, 0, i)
		Next i
		
	End Sub
	
	Public Function FechaFinMes(ByRef Anio As Integer, ByRef mes As Short) As Date
		Dim FEB, DiaFinal As Short
		FEB = IIf(DatePart(Microsoft.VisualBasic.DateInterval.DayOfYear, CDate("31/12/" & Anio)) > 365, 29, 28)
		Select Case mes
			Case 1, 3, 5, 7, 8, 10, 12
				DiaFinal = 31
			Case 2
				DiaFinal = FEB
			Case Else
				DiaFinal = 30
		End Select
		FechaFinMes = DateSerial(Anio, mes, DiaFinal)
	End Function
	
	Public Function BuscarAutorizacionesSRI(ByRef CiRucProov As String, ByRef TipCodSri As String, ByRef Estab As String, ByRef Emision As String, ByRef NumeroDoc As String, ByRef fecha As String, Optional ByRef EsNumExterno As String = "") As AutorizacionSri
		' enviar datos del documento y buscar en base al ID y el tipo del sri
		Dim rs As New ADODB.Recordset
		Dim NoEx As Boolean
		Dim FechaCad As Date
		Dim ElCodigo As String
		Dim ConTipoCod As String
		Dim ConTipoAdcom As String
		Dim ConSeries As String
		Dim BusNum As String
		BuscarAutorizacionesSRI = New AutorizacionSri
		BuscarAutorizacionesSRI.AutNroAut = CStr(0)
		If TipCodSri = "" Then Exit Function
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(EsNumExterno). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If CorrijeNulo(EsNumExterno) > "" Then BusNum = EsNumExterno Else BusNum = NumeroDoc
		ConTipoCod = " and TipoComprobante = '" & TipCodSri & "' "
		ElCodigo = CiRucProov
		If Estab = "" Or Emision = "" Then Exit Function : 'MsgBox "Digite el identificativo de Sri": Exit Function
		ConSeries = " and SerieComprobante = '" & Estab & "' and SerieCPbteEmision = '" & Emision & "' "
		rs.Open(" select * from autorizaciones where CodigoProveedor = '" & ElCodigo & "' " & ConTipoCod & ConSeries & " and NumeroInicial <= " & BusNum & " and numerofinal >= " & BusNum & " and FechaTope > = " & ArmFormatoFecha(fecha, ""), ConxSri, ADOR.CursorTypeEnum.adOpenForwardOnly, ADOR.LockTypeEnum.adLockReadOnly)
		NoEx = True
		If rs.State = 0 Then
			NoEx = False
		ElseIf rs.EOF Then 
			NoEx = False
		End If
		With BuscarAutorizacionesSRI
			If NoEx = False Then
				.AutNroAut = CStr(0)
			Else
				.AutFechaVence = CorrijeNuloF(rs.Fields("FechaTope"))
				.AutIdEstab = Estab
				.AutIdPtoVta = Emision
				.AutNroAut = rs.Fields("NroAutorizacion").Value
				.AutNroDoc = NumeroDoc
				.AutNroIni = rs.Fields("NumeroInicial").Value
				.AutNroFin = rs.Fields("NumeroFinal").Value
				.AutTipDocAdc = ""
				.AutTipDocSri = TipCodSri
				.AutNroExterno = EsNumExterno
				.AutCiRuc = ElCodigo
			End If
		End With
finalizar: 
		rs.Close()
	End Function
	
	Public Function AutorizacionSRI(ByRef CiRucProov As String, ByRef TipCodSri As String, ByRef IdSri As String, ByRef NumeroDoc As String, ByRef fecha As String) As String
		
		Dim rs As New ADODB.Recordset
		Dim NoEx As Boolean
		Dim FechaCad As Date
		Dim ConTipoCod As String
		Dim Campos() As String
		Dim Estab, Emision As String
		Campos = Split(IdSri, "-")
		ReDim Preserve Campos(2)
		Estab = Campos(0)
		Emision = Campos(1)
		ConTipoCod = " and TipoComprobante = '" & TipCodSri & "' and SerieComprobante = '" & Estab & "' and SerieCPbteEmision = '" & Emision & "' "
		rs.Open(" select * from autorizaciones where CodigoProveedor = '" & CiRucProov & "' " & ConTipoCod & " and NumeroInicial <= " & NumeroDoc & " and numerofinal >= " & NumeroDoc & " and FechaTope > = " & ArmFormatoFecha(fecha, ""), ConxSri, ADOR.CursorTypeEnum.adOpenForwardOnly, ADOR.LockTypeEnum.adLockReadOnly)
		NoEx = True
		If rs.State = 0 Then
			NoEx = False
		ElseIf rs.EOF Then 
			NoEx = False
		End If
		If NoEx = False Then AutorizacionSRI = CStr(0) Else AutorizacionSRI = rs.Fields("NroAutorizacion").Value
finalizar: 
		If rs.State = 1 Then rs.Close()
		'UPGRADE_NOTE: El objeto rs no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rs = Nothing
		
	End Function
	
	
	Public Function roundd(ByVal numero As Double, ByVal par As Short) As Double
		roundd = System.Math.Round(numero + 0.0000000001, par)
	End Function
End Module