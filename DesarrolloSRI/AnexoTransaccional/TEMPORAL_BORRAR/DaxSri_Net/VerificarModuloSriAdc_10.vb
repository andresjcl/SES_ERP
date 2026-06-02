Option Strict Off
Option Explicit On
Module VerificarModuloSri
	
	
	Public Function BuscarAutorizacionesSRI(ByRef CiRucProov As String, ByRef TipCodSri As String, ByRef Estab As String, ByRef Emision As String, ByRef NumeroDoc As String, ByRef fecha As String, Optional ByRef EsNumExterno As String = "") As AutorizacionSri
		Dim FechaCaduca As Object
		' enviar datos del documento y buscar en base al ID y el tipo del sri
		Dim rs As New ADODB.Recordset
		Dim NoEx As Boolean
		Dim FechaCad As Date
		Dim ElCodigo As String
		Dim ConTipoCod As String
		Dim ConTipoAdcom As String
		Dim ConSeries As String
		Dim BusNum As String
		Dim valcod As Integer
		ConTipoCod = ""
		ConSeries = ""
		valcod = Val(TipCodSri)
		If valcod = 0 Then valcod = 7
		BuscarAutorizacionesSRI = New AutorizacionSri
		If Val(NumeroDoc) = 0 Then Exit Function
		If Emp.Sri = False Then Exit Function
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(EsNumExterno). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If CorrijeNulo(EsNumExterno) > "" Then BusNum = EsNumExterno Else BusNum = NumeroDoc
		ConTipoCod = " and (TipoComprobante =  '" & CStr(valcod) & "' OR TipoComprobante =  " & valcod & ") " '& TipCodSri & "' "
		If CiRucProov = "" Then ElCodigo = Emp.ruc Else ElCodigo = CiRucProov
		ConSeries = " and SerieComprobante = '" & Estab & "' and SerieCPbteEmision = '" & Emision & "' "
		rs = New ADODB.Recordset
		'MsgBox ConxSri.State
		rs.Open(" select * from autorizaciones where CodigoProveedor = '" & ElCodigo & "' " & ConTipoCod & ConSeries & " and NumeroInicial <= " & BusNum & " and numerofinal >= " & BusNum & " and FechaTope > = " & ArmFormatoFecha(fecha, ""), ConxSri, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		NoEx = True
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto FechaCaduca. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		FechaCaduca = "0:00:00"
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
End Module