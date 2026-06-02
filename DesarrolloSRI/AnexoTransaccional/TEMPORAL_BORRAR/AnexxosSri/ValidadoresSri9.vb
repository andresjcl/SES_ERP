Option Strict Off
Option Explicit On
Module ValidadoresSria
	Public Function ValidaIdSri(ByRef IdRuc As String) As Boolean
		ValidaIdSri = False
		If Len(IdRuc) <> 7 Then Exit Function
		If Mid(IdRuc, 4, 1) <> "-" Then Exit Function
		If Val(Mid(IdRuc, 1, 3)) = 0 Then Exit Function
		If Val(Mid(IdRuc, 5, 3)) = 0 Then Exit Function
		ValidaIdSri = True
	End Function
	
	Public Function ValidaRucInformante(ByRef RucInf As String, ByRef TipoId As String) As Boolean
		If Len(RucInf) = 13 And Right(RucInf, 3) = "001" Then
			ValidaRucInformante = True
			Exit Function
		Else
			ValidaRucInformante = False
		End If
	End Function
	
	Public Function ValidaRazonSocial(ByRef RazonSocial As String) As Boolean
		If Len(RazonSocial) > 0 Then
			ValidaRazonSocial = True
			Exit Function
		Else
			ValidaRazonSocial = False
		End If
	End Function
	
	Public Function ValidaDireccion(ByRef direccion As String) As Boolean
		If Len(direccion) > 0 Then
			ValidaDireccion = True
			Exit Function
		Else
			ValidaDireccion = False
		End If
	End Function
	
	
	Public Function ValidaFax(ByRef fax As String) As Boolean
		
	End Function
	Public Function ValidaEmail(ByRef email As String) As Boolean
		
	End Function
	Public Function ValidaIdRepreLegal(ByRef IdRepLeg As String) As Boolean
		
	End Function
	Public Function ValidaRucContador(ByRef RucContad As String) As Boolean
		
	End Function
	Public Function ValidaAñoPeriodo(ByRef AñoPer As String) As Boolean
		
	End Function
	Public Function ValidaMesPeriodo(ByRef MesPer As String) As Boolean
		
	End Function
	
	Public Function CorrijeTipoId(ByRef Tipo As String) As String
		Dim Tipon As Short
		Dim TI As String
		If Tipo = "" Then Tipo = "R"
		Select Case Trim(Tipo)
			Case "0"
				TI = "O"
			Case "1"
				TI = "R"
			Case "2"
				TI = "C"
			Case "3"
				TI = "P"
			Case "4"
				TI = "F"
			Case "O", "R", "C", "F", "P"
				TI = Tipo
			Case Else
				TI = "O"
		End Select
		CorrijeTipoId = TI
	End Function
	'    01  Compra a proveedor con RUC
	'    02  Compra a proveedor Cédula de Identidad
	'    03  Compra a proveedor Pasaporte
	'    04  Venta a cliente con RUC
	'    05  Venta a cliente Cédula de identidad
	'    06  Venta a cliente Pasaporte
	'    07  Venta a cliente Consumid$or Final
	'8       Importación
	'9       Exportación
	
	Public Function TipoIdSri(ByRef Tipo As String, ByRef ComVtas As String) As String
		Dim Tipon As Short
		Dim TI As String
		If Tipo = "0" Or Tipo = "O" Then TipoIdSri = "0" : Exit Function
		If ComVtas = "V" Then
			Select Case Trim(Tipo)
				Case "R", "1", "01"
					TI = "04"
				Case "C", "2", "02"
					TI = "05"
				Case "P", "03", "3"
					TI = "06"
				Case "F", "7", "07"
					TI = "07"
				Case Else
					TI = Tipo
			End Select
		ElseIf ComVtas = "C" Then 
			Select Case Trim(Tipo)
				Case "R", "1", "01"
					TI = "01"
				Case "C", "2", "02"
					TI = "02"
				Case "P", "03", "3"
					TI = "03"
				Case Else
					TI = Tipo
			End Select
		ElseIf ComVtas = "I" Then 
			TI = "8"
		ElseIf ComVtas = "E" Then 
			TI = "9"
		End If
		TipoIdSri = CStr(Val(TI))
	End Function
	
	Public Function ValidaId(ByRef NumeroId As String, ByRef TipoId As String) As Boolean
		Dim Validador As New aiValidaciones.clsValidador
		Dim Largo As Short
		Dim Aux As String
		Dim Tipo As Boolean
		'cambiar on error Resume Next
		ValidaId = False
		If TipoId = "P" Then
			ValidaId = True
			Exit Function
		ElseIf TipoId = "F" Then 
			If NumeroId = "9999999999999" Then ValidaId = True
			Exit Function
		End If
		Largo = Len(NumeroId)
		If Not IsNumeric(NumeroId) Then Exit Function
		If TipoId = "R" Then
			If Largo <> 13 Or Mid(NumeroId, 11) <> "001" Then Exit Function
		ElseIf TipoId = "C" Then 
			If Largo <> 10 Then Exit Function
		End If
		Largo = Val(Mid(NumeroId, 3, 1))
		ValidaId = True
		If TipoId = "C" Then
			ValidaId = Validador.validarCedula(NumeroId)
		ElseIf Largo >= 0 And Largo <= 5 Then 
			ValidaId = Validador.validarRUCNaturales(NumeroId)
		ElseIf Largo = 6 Then 
			ValidaId = Validador.validarRUCPublicas(NumeroId)
		ElseIf Largo = 9 Then 
			ValidaId = Validador.validarRUCPrivadas(NumeroId)
		End If
		'UPGRADE_NOTE: El objeto Validador no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		Validador = Nothing
	End Function
	
	Public Function ValidaSri(ByRef ComVta As String, ByRef ATS As Boolean, ByRef DocTipo As String, ByRef Autorizacion As String, ByRef Sustento As String, ByRef FecContab As Date, ByRef FecDoc As Date, ByRef FechaAuto As Date, ByRef AutoIni As String, ByRef AutoFin As String, ByRef NumDoc As String) As String
		ValidaSri = ""
		If ComVta = "C" Then
			If Len(Trim(DocTipo)) = 0 Then ValidaSri = "Tipo de documento errado" : Exit Function
			If Len(Trim(Autorizacion)) = 0 Then ValidaSri = "Numero de autorización errada" : Exit Function
			If FechaAuto < FecDoc Then ValidaSri = "Fecha de autorización errada" : Exit Function
			If Val(AutoIni) >= Val(AutoFin) Or Val(AutoIni) = 0 Then ValidaSri = "Números de autorización errada" : Exit Function
			If Val(NumDoc) < Val(AutoIni) Or Val(NumDoc) > Val(AutoFin) Then ValidaSri = "El Número de la factura esta fuera de números autorizados" : Exit Function
			If ATS Then
				If Len(Trim(Sustento)) = 0 Then ValidaSri = "Codigo de sustento errado" : Exit Function
				If FecDoc > FecContab Then ValidaSri = "Fecha de registro contable errada" : Exit Function
			End If
		ElseIf ComVta = "V" Then 
			If ATS Then
				If Len(Trim(DocTipo)) = 0 Then ValidaSri = "Tipo de documento errado" : Exit Function
			End If
		End If
	End Function
	
	'Public Function Validatercero6(numero As String) As Boolean
	'Dim i As Integer, SUMAR As Double, PREVIO As Single, Res As Single
	'Dim Mul(10) As Single, Aux As String
	''If IsNull(Mensaje) Or IsMissing(Mensaje) Then Mensaje = True
	'Validatercero6 = False
	'Mul(1) = 3
	'Mul(2) = 2
	'Mul(3) = 7
	'Mul(4) = 6
	'Mul(5) = 5
	'Mul(6) = 4
	'Mul(7) = 3
	'Mul(8) = 2
	'Mul(9) = 0
	'Mul(10) = 0
	'SUMAR = 0
	'For i = 1 To 8
	'PREVIO = Val(mid$(numero, i, 1)) * Mul(i)
	'SUMAR = PREVIO + SUMAR
	'Next i
	'Res = Int(SUMAR / 11) * 11
	'If Res <> SUMAR Then
	'        Res = SUMAR - Res
	'        Aux = 11 - Res
	'Else
	'        Aux = 0
	'End If
	'
	''Aux = 11 - Res
	''If Aux = 11 Then Aux = 0
	''VerificaRuc = Aux
	'
	'If Aux <> mid$(numero, 10, 1) Then Exit Function
	''   Aux = MsgBox(" El número de RUC no es válido, verifique su valor ? ")
	''   VerificaRuc = "X"
	''   'If Aux = vbYes Then Numero.SetFocus
	''End If
	'Validatercero6 = True
	'End Function
	'Public Function Validatercero9(numero As String) As Boolean
	'Dim i As Integer, SUMAR As Double, PREVIO As Single, Res As Single
	'Dim Mul(10) As Single, Aux As String
	'
	''If IsNull(Mensaje) Or IsMissing(Mensaje) Then Mensaje = True
	'Validatercero9 = False
	'Mul(1) = 4
	'Mul(2) = 3
	'Mul(3) = 2
	'Mul(4) = 7
	'Mul(5) = 6
	'Mul(6) = 5
	'Mul(7) = 4
	'Mul(8) = 3
	'Mul(9) = 2
	'Mul(10) = 0
	'SUMAR = 0
	'For i = 1 To 9
	'PREVIO = Val(mid$(numero, i, 1)) * Mul(i)
	'SUMAR = PREVIO + SUMAR
	'Next i
	'Res = Int(SUMAR / 11) * 11
	'If Res <> SUMAR Then
	'        Res = SUMAR - Res
	'        Aux = 11 - Res
	'Else
	'        Aux = 0
	'End If
	''VerificaRuc = Aux
	'If Aux <> mid$(numero, 10, 1) Then Exit Function 'And Mensaje <> False Then
	''   Aux = MsgBox(" El número de RUC no es válido, verifique su valor ? ")
	''   VerificaRuc = "X"
	'   'If Aux = vbYes Then Numero.SetFocus
	''End If
	'Validatercero9 = True
	'End Function
	'
	'Public Function ValidarCedula(numero As String) As Boolean
	'Dim i As Integer, SUMAR As Double, PREVIO As Single, Aux As String, j As Integer
	'Dim Mul(10) As Single
	'numero = trim(numero)
	'ValidarCedula = False
	'i = Val(mid$(numero, 1, 2))
	'If i < 1 Or i > 22 Then Exit Function
	'SUMAR = 0
	''If IsNull(Mensaje) Or IsMissing(Mensaje) Then Mensaje = True
	'Mul(1) = 2
	'Mul(2) = 1
	'Mul(3) = 2
	'Mul(4) = 1
	'Mul(5) = 2
	'Mul(6) = 1
	'Mul(7) = 2
	'Mul(8) = 1
	'Mul(9) = 2
	'Mul(10) = 0
	'
	'For i = 1 To 9
	'PREVIO = Val(mid$(numero, i, 1)) * Mul(i)
	'If PREVIO > 9 Then PREVIO = PREVIO - 9
	'SUMAR = PREVIO + SUMAR
	'Next i
	'Aux = mid$(trim(Str(SUMAR)), 2, 1)
	'If Aux = "0" Then
	'   Aux = "0"
	'Else
	'   Aux = 10 - Val(mid$(SUMAR, 2, 1))
	'End If
	'
	'If Aux <> mid$(numero, 10, 1) Then Exit Function
	'
	'ValidarCedula = True
	'
	'End Function
	
	Public Function ValidaNumProv(ByRef numero As String, ByRef Prov As String) As Boolean
		Dim Telefono, NumProv As String
		Dim Largo As Short
		Largo = Len(numero)
		If Largo <> 9 Or Not IsNumeric(numero) Then
			ValidaNumProv = False
			Exit Function
		End If
		ValidaNumProv = True
		Telefono = Mid(numero, 3)
		NumProv = Mid(numero, 1, 2)
		If NumProv = "09" Then Exit Function
		If (Prov = "01" Or Prov = "03" Or Prov = "07" Or Prov = "11" Or Prov = "14" Or Prov = "19") And (NumProv = "07") Then Exit Function
		If (Prov = "02" Or Prov = "05" Or Prov = "06" Or Prov = "16" Or Prov = "18") And (NumProv = "03") Then Exit Function
		If (Prov = "04" Or Prov = "08" Or Prov = "10" Or Prov = "15" Or Prov = "21" Or Prov = "22") And (NumProv = "06") Then Exit Function
		If (Prov = "09") And (NumProv = "04") Then Exit Function
		If (Prov = "12" Or Prov = "13" Or Prov = "20") And (NumProv = "05") Then Exit Function
		If (Prov = "17") And (NumProv = "02") Then Exit Function
		ValidaNumProv = False
	End Function
	
	Public Function ValidaPeriodo(ByRef FechaDoc As String, ByRef PerAnio As Short, ByRef PerMes As Short) As Boolean
		Dim LaFecha As Date
		ValidaPeriodo = False
		If Not IsDate(FechaDoc) Then Exit Function
		'If Len(FechaDoc) <> 10 Then Exit Function
		LaFecha = CDate(FechaDoc)
		If PerAnio <> Year(LaFecha) Then Exit Function
		If PerMes <> Month(LaFecha) Then Exit Function
		ValidaPeriodo = True
	End Function
	
	Public Function ValidaAutorización(ByRef FechaDoc As String, ByRef NumAutoriza As String, ByRef FechaCaduca As String, ByRef linea As Short) As Boolean
		If Not IsDate(FechaDoc) Then ExisteErrores("La fecha del documento no es válida", linea) : Exit Function
		If Not IsDate(FechaCaduca) Then ExisteErrores("La fecha que caduca autorización no es válida", linea) : Exit Function
		If CDate(FechaCaduca) < CDate(FechaDoc) Then ExisteErrores("La fecha de autorización esta caducada", linea) : Exit Function
		If Val(NumAutoriza) = 0 Then ExisteErrores("No existe numero de autorización", linea) : Exit Function
	End Function
	
	Public Function ValidaIva(ByRef CodIva As String, ByRef FechaDoc As Date) As Boolean
		Dim Sw As Boolean
		Dim SrRec As New ADODB.Recordset
		Dim sSQL As String
		Dim codi As Short
		
		SrRec = New ADODB.Recordset
		ValidaIva = False
		sSQL = "Select * From SriPorcentajesDelIva where codigo = " & CodIva
		SrRec = New ADODB.Recordset
		SrRec.CursorLocation = ADOR.CursorLocationEnum.adUseClient
		SrRec.Open(sSQL, ConxSyscod, ADOR.CursorTypeEnum.adOpenForwardOnly, ADOR.LockTypeEnum.adLockReadOnly)
		If SrRec.State = 0 Then Exit Function
		If SrRec.EOF = False Then
			If FechaDoc > SrRec.Fields("fechainicio").Value And FechaDoc <= SrRec.Fields("FechaFin").Value Then
				ValidaIva = True
			End If
		End If
		SrRec.Close()
	End Function
	Public Function ValidaIce(ByRef CodIce As Short) As Boolean
		Dim Sw As Boolean
		Dim SrRec As New ADODB.Recordset
		Dim sSQL As String
		Dim codi As Short
		SrRec = New ADODB.Recordset
		
		ValidaIce = False
		sSQL = "Select * From SriPorcentajesDelIce where codigo = " & CodIce
		SrRec = New ADODB.Recordset
		SrRec.CursorLocation = ADOR.CursorLocationEnum.adUseClient
		SrRec.Open(sSQL, ConxSyscod, ADOR.CursorTypeEnum.adOpenForwardOnly, ADOR.LockTypeEnum.adLockReadOnly)
		If SrRec.State = 0 Then Exit Function
		If SrRec.EOF = False Then ValidaIce = True
		SrRec.Close()
	End Function
	
	
	Public Sub ExisteErrores(ByRef Mensaje As String, ByRef linea As Short)
		Dim NroErrores As Object
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto NroErrores. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		NroErrores = NroErrores + 1
		PrintLine(1, linea & " -  ERROR --> " & Mensaje)
	End Sub
	
	Public Function ValidaTipoComprobante(ByVal periodo As String, ByVal TipoTran As Short, ByVal TipSus As Short, ByRef TipoId As String, ByRef QUECODIGO As String, ByRef QUENOMBRE As String) As Boolean
		
		Dim RsDocumentos As ADODB.Recordset
		'Private Codigo As String, Nombre As String, Tipo As String
		Dim TipoTransaccion As Short ', Retencion As Boolean
		Dim TipoSustento As Short
		Dim TipoIdentificacion As String
		Dim Hasta As Date
		'Dim fechaa As Date
		Dim Sw As Boolean
		Dim SrRec As New ADODB.Recordset
		Dim sSQL As String
		Dim codi As Short
		Dim HastaFec As Date
		Dim claves As String
		Dim SeqTransacc As Short
		Dim TxSustento, TxSeqTra As String
		
		'Retencion = Reten
		TipoIdentificacion = CorrijeTipoId(TipoId)
		TipoTransaccion = TipoTran
		TipoSustento = TipSus
		'HASTA = FechaFinMes(Val(PerAnio), Val(PerMes))
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
		If SeqTransacc > 0 Then TxSeqTra = "  (CodigoSecuencialTransaccion LIKE '%" & Right("00" & SeqTransacc, 2) & "%')"
		If TipoSustento > 0 Then TxSustento = "(SustentoTributario LIKE '%" & Right("00" & TipoSustento, 2) & "%') "
		If TxSustento > "" And TxSeqTra > "" Then TxSustento = TxSustento & " AND "
		sSQL = "Select * From sritipodecomprobante Where " & TxSustento & TxSeqTra & " and codigo = " & QUECODIGO & " order by codigo "
		RsDocumentos = New ADODB.Recordset
		RsDocumentos.CursorLocation = ADOR.CursorLocationEnum.adUseClient
		RsDocumentos.Open(sSQL, ConxSyscod, ADOR.CursorTypeEnum.adOpenForwardOnly, ADOR.LockTypeEnum.adLockReadOnly)
		If RsDocumentos.EOF Then ValidaTipoComprobante = False Else ValidaTipoComprobante = True
		
	End Function
	
	'Public Function ValidaAdicionales(ElAdicional As Adicionales) As Boolean
	'Dim ex As Boolean
	'ex = True
	'ValidaAdicionales = ex
	'With ElAdicional
	'If .ConDatos = False Then
	'    ex = False
	'ElseIf Not IsDate(.FechaContabilidad) Or .FechaContabilidad = "0:00:00" Then
	'    ex = False
	'ElseIf .TipoComprobante = "" Then
	'    ex = False
	'End If
	'If ex = False Then
	'    ex = SinAdicionales
	'Else
	'    If ValidaAutorizacion(.AutoSri) = False Then ex = False
	'End If
	'ValidaAdicionales = ex
	'End With
	'End Function
	
	Public Function ValidaAutorizacion(ByRef LaAutorizacion As AutorizacionSri) As Boolean
		Dim ex As Boolean
		ex = True
		ValidaAutorizacion = ex
		If LaAutorizacion Is Nothing Then
			LaAutorizacion = New AutorizacionSri
		End If
		With LaAutorizacion
			If Val(.AutNroAut) = 0 Then
				ex = False
			ElseIf Not IsDate(.AutFechaVence) Or .AutFechaVence = CDate("0:00:00") Then 
				ex = False
			ElseIf Val(.AutNroIni) >= Val(.AutNroFin) Or Val(.AutNroIni) = 0 Or Val(.AutNroFin) = 0 Then 
				ex = False
			End If
		End With
		If ex = False Then ex = SinAutorizacion()
		ValidaAutorizacion = ex
	End Function
End Module