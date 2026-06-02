Option Strict Off
Option Explicit On
Module RutinasSri
	
	Public Sub ArreglaPeriodo(ByRef año As Short, ByRef mes As Short)
		'cambiar on error Resume Next
		PerAnio = año
		PerMes = mes
		PerPeriodo = Right("00" & PerMes, 2) & PerAnio
		FecPeriodo = VB6.Format("01/" & PerMes & "/" & PerAnio, "long date")
	End Sub
	
	Public Function SepararClaves(ByRef Clave As String, ByRef Campo As String) As String
		Dim i, j As Short
		Dim Tt As Single
		Dim a As String
		Dim Cadena As String
		i = Len(Clave)
		If i = 0 Or Campo = "" Then SepararClaves = "" : Exit Function
		Cadena = " " & Campo & " = "
		Tt = 0
		For j = 1 To i
			a = Mid(Clave, j, 1)
			If a = "," Then
				Cadena = Cadena & " OR " & Campo & " = "
			Else
				Cadena = Cadena & a
			End If
		Next j
		SepararClaves = Cadena
	End Function
	
	'Public Function BuscaAutDoc(Proveedor As String, Tipo As String, Emision As String, Establec As String, numero As String, ByRef Autorizacion As String, ByRef Caduca As Date, ByRef TipoDocOrg As String) As Boolean
	'Dim rs As New ADODB.Recordset, Ssql As String
	'If Proveedor = "" Or IsNull(Proveedor) Then Proveedor = "EE0E"
	'Ssql = " Select * from autorizaciones where CodigoProveedor = '" & Proveedor & _
	''    "' and TipoComprobante = '" & Tipo & "' and  SerieComprobante = '" & Establec & _
	''    "' and  SerieCPbteEmision = '" & Emision & "' and NumeroInicial <= '" & numero & _
	''    "' and NumeroFinal >= '" & numero & "'"
	'    ', NroAutorizacion FechaTope   TipoComprobanteAdcom
	'Autorizacion = ""
	'Caduca = "0:0"
	'TipoDocOrg = ""
	'BuscaAutDoc = False
	'rs.Open Ssql, ConxSri, adOpenForwardOnly, adLockOptimistic
	'If rs.State = 0 Then Exit Function
	'If rs.EOF Then rs.Close: Exit Function
	'Autorizacion = rs!nroautorizacion
	'Caduca = rs!fechatope
	'TipoDocOrg = rs!tipocomprobanteadcom
	'BuscaAutDoc = True
	'rs.Close
	'End Function
	
	'
	'Public Function CargarSustento(codigo As Long) As Boolean
	'Dim SrRec As New ADODB.Recordset
	'Dim sSQL As String, Codi As Integer
	'
	'sSQL = "Select * From SriSustentoComprobante where"
	'Set SrRec = New ADODB.Recordset
	'CargarSustento = False
	'    sSQL = "Select * From SriSustentoComprobante where codigo = " & codigo
	'    Set SrRec = New ADODB.Recordset
	'    SrRec.CursorLocation = adUseClient
	'    SrRec.Open sSQL, ConxSyscod, adOpenForwardOnly, adLockReadOnly
	'If SrRec.State = 0 Then Exit Function
	'If SrRec.EOF = False Then CargarSustento = True
	'SrRec.Close
	'End Function
	'
	Public Function CargarIva(ByRef CodIva As Short) As Double
		Dim Sw As Boolean
		Dim SrRec As New ADODB.Recordset
		Dim sSQL As String
		Dim codi As Short
		SrRec = New ADODB.Recordset
		CargarIva = 0
		sSQL = "Select * From SriPorcentajesDelIva where codigo = " & CodIva
		SrRec = New ADODB.Recordset
		SrRec.CursorLocation = ADOR.CursorLocationEnum.adUseClient
		SrRec.Open(sSQL, ConxSyscod, ADOR.CursorTypeEnum.adOpenForwardOnly, ADOR.LockTypeEnum.adLockReadOnly)
		If SrRec.State = 0 Then Exit Function
		If SrRec.EOF = False Then CargarIva = SrRec.Fields("PorcentajeIva").Value
		SrRec.Close()
		
	End Function
	
	Public Function CargarIce(ByRef CodIce As Short) As Double
		Dim Sw As Boolean
		Dim SrRec As New ADODB.Recordset
		Dim sSQL As String
		Dim codi As Short
		SrRec = New ADODB.Recordset
		
		CargarIce = 0
		sSQL = "Select * From SriPorcentajesDelIce where codigo = " & CodIce
		SrRec = New ADODB.Recordset
		SrRec.CursorLocation = ADOR.CursorLocationEnum.adUseClient
		SrRec.Open(sSQL, ConxSyscod, ADOR.CursorTypeEnum.adOpenForwardOnly, ADOR.LockTypeEnum.adLockReadOnly)
		If SrRec.State = 0 Then Exit Function
		If SrRec.EOF = False Then CargarIce = SrRec.Fields("Porcentaje_Ice").Value
		SrRec.Close()
	End Function
	
	'Public Function CargarRetIvaBienes(CodRIB As Integer) As Double
	'Dim Sw As Boolean, SrRec As New ADODB.Recordset
	'Dim sSQL As String, Codi As Integer
	'Set SrRec = New ADODB.Recordset
	'
	'CargarRetIvaBienes = 0
	'    sSQL = "Select * From SriPorcentajesRetencionIvaBienes where codigo = '" & CodRIB & "'"
	'    Set SrRec = New ADODB.Recordset
	'    SrRec.CursorLocation = adUseClient
	'    SrRec.Open sSQL, ConxSyscod, adOpenForwardOnly, adLockReadOnly
	'If SrRec.State = 0 Then Exit Function
	'If SrRec.EOF = False Then CargarRetIvaBienes = SrRec!Valor1
	'SrRec.Close
	'End Function
	'Public Function CargarRetIvaServicios(CodRIS As Integer) As Double
	'Dim Sw As Boolean, SrRec As New ADODB.Recordset
	'Dim sSQL As String, Codi As Integer
	'Set SrRec = New ADODB.Recordset
	'
	'CargarRetIvaServicios = 0
	'    sSQL = "Select * From SriPorcentajesRetencionIvaServicios where codigo = '" & CodRIS & "'"
	'    Set SrRec = New ADODB.Recordset
	'    SrRec.CursorLocation = adUseClient
	'    SrRec.Open sSQL, ConxSyscod, adOpenForwardOnly, adLockReadOnly
	'If SrRec.State = 0 Then Exit Function
	'If SrRec.EOF = False Then CargarRetIvaServicios = SrRec!Valor1
	'SrRec.Close
	'End Function
	'
	'Public Function CargarRetIR(CodIRA As String) As Double
	'Dim Sw As Boolean, SrRec As New ADODB.Recordset
	'Dim sSQL As String, Codi As Integer
	'Set SrRec = New ADODB.Recordset
	'
	'CargarRetIR = 0
	'
	'    sSQL = "Select * From SriConceptosRetencion where codigo = " & CodIRA
	'    Set SrRec = New ADODB.Recordset
	'    SrRec.CursorLocation = adUseClient
	'    SrRec.Open sSQL, ConxSyscod, adOpenForwardOnly, adLockReadOnly
	'If SrRec.State = 0 Then Exit Function
	'If SrRec.EOF = False Then CargarRetIR = SrRec!porretencion
	'SrRec.Close
	'End Function
	'
	'Public Function CargarDocumentoSri(periodo As String, TipoTran As Integer, TipSus As Integer, TipoId As String, Optional codDoc As String) As Boolean
	'Dim Aux As String, SrRec As New ADODB.Recordset
	'Dim sSQL As String, Codi As Integer
	'Dim HastaFec As Date, TipoTransaccion As Integer
	'Dim claves As String, SeqTransacc As Integer
	'Dim TxSustento As String, TxSeqTra As String
	'Dim CodigoDoc As String
	''cambiar on error GoTo 0
	'CargarDocumentoSri = False
	'Retencion = Reten
	'Aux = CorrijeTipoId(TipoId)
	'TipoTransaccion = TipoTran
	'TipoSustento = TipSus
	'TxSustento = ""
	'TxSeqTra = ""
	'
	'Set SrRec = New ADODB.Recordset
	'
	'If TipoTran = 3 Or TipoTran = 4 Then
	'    SeqTransacc = TipoTran + 4
	'Else
	'    If TipoIdentificacion > "" Then
	'        sSQL = "Select * From SriSecuencialesTransacciones where CodigoTipoTransaccion = " & TipoTransaccion & " and CodigoIdentificacion = '" & TipoIdentificacion & "'"
	'        SrRec.Open sSQL, ConxSyscod, adOpenForwardOnly, adLockOptimistic
	'        If SrRec.State = 0 Then
	'            Sw = False
	'        ElseIf SrRec.EOF Then
	'            Sw = False
	'        Else
	'            SeqTransacc = SrRec!codigo
	'        End If
	'        If SrRec.State = 1 Then SrRec.Close
	'        TxSeqTra = " and (CodigoSecuencialTransaccion LIKE '%" & Right("00" & SeqTransacc, 2) & "%')"
	'    End If
	'End If
	'
	'If TipoSustento > 0 Then
	'    TxSustento = "(SustentoTributario LIKE '%" & Right("00" & TipoSustento, 2) & "%') "
	'Else
	'    TxSustento = " SustentoTributario > '' "
	'End If
	'If codDoc > "" Then CodigoDoc = " and codigo = " & codDoc & " " Else CodigoDoc = ""
	'sSQL = "Select * From sritipodecomprobante Where " & TxSustento & TxSeqTra & CodigoDoc & " order by codigo "
	'    ' abrir conexión
	'    ' crear un conjunto de registros con la colección proporcionada
	'    Set SrRec = New ADODB.Recordset
	'    SrRec.CursorLocation = adUseClient
	''cambiar on error GoTo 0
	'    SrRec.Open sSQL, ConxSyscod, adOpenForwardOnly, adLockReadOnly
	'If SrRec.State = 0 Then Exit Function
	'If SrRec.EOF = False Then CargarDocumentoSri = True
	'SrRec.Close
	'End Function
	'
	Public Sub ArreglaMalla(ByRef Malla As Object, ByRef TipTra As Short)
		'cambiar on error Resume Next
		Dim i, j As Integer
		Dim L As Integer
		Dim autoriza As New AutorizacionSri
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Malla.ColWidth(0) = 600
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.AllowUserResizing. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Malla.AllowUserResizing = MSFlexGridLib.AllowUserResizeSettings.flexResizeColumns
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Malla.Rows < 3 Then Malla.Rows = 3 ': Malla.FixedRows = 1
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.FixedRows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Malla.FixedRows = 2
		With Malla
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(0, 0) = "Nro."
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(1, 0) = ""
			If TipTra = 1 Then
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Cols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Malla.Cols = 45
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 1) = "Sustento"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 1) = "Tributario"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 2) = "Tipo"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 2) = "Ident."
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 3) = "Nro.Cedula"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 3) = "O Ruc"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 4) = "Tipo"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 4) = "Cpbte"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 5) = "Tipo"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 5) = "Provee"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 6) = "Parte"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 6) = "Relacion"
				
				
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 7) = "Fecha"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 7) = "Contabiliza"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 8) = "Serie"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 8) = "Estbl."
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 9) = "Serie"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 9) = "Emis."
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 10) = "Número"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 10) = "Compbte"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 11) = "Fecha"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 11) = "Emision"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 12) = "Número"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 12) = "Autoriza"
				
				
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 13) = "BaseNoGraba"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 13) = "IVA"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 14) = "BaseTarifa"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 14) = "IvaCero"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 15) = "BaseGrabada"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 15) = "IVA"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 16) = "Monto"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 16) = "ICE"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 17) = "Monto"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 17) = "IVA"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 18) = "IvaBienes"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 18) = "MontoRetenido"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 19) = "IvaServicios"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 19) = "MontoRetenido"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 20) = "IvaServicios100"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 20) = "MontoRetenido"
				
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 21) = "Pago"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 21) = "LocExt"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 22) = "País"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 22) = "Pago"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 23) = "Doble"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 23) = "Tibut"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 24) = "Sujeto"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 24) = "Retenc"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 25) = "Forma"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 25) = "Pago"
				
				
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 26) = "Retción. AIR-1"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 26) = "Concepto"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 27) = "Retción. AIR-1"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 27) = "BaseImponible"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 28) = "Retción. AIR-1"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 28) = "porcentaje"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 29) = "Retción. AIR-1"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 29) = "ValorMonto"
				
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 30) = "Retción. AIR-2"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 30) = "Concepto"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 31) = "Retción. AIR-2"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 31) = "BaseImponible"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 32) = "Retción. AIR-2"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 32) = "porcentaje"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 33) = "Retción. AIR-2"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 33) = "ValorMonto"
				
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 34) = "SerieRet"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 34) = "Estb."
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 35) = "SerieRet"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 35) = "P.Emis."
				
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 36) = "Retencion"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 36) = "Número"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 37) = "Retencion"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 37) = "NroAutorizac"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 38) = "Retencion"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 38) = "Fecha"
				
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 39) = "DocModifica"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 39) = "Tipo"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 40) = "DocModifica"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 40) = "SerieEstbl."
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 41) = "DocModifica"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 41) = "SerieP.Emis"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 42) = "DocModifica"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 42) = "Número"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 43) = "DocModifica"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 43) = "Nro.Autoriza"
				
				'            .TextMatrix(0, 36) = "Reembolso"
				'            .TextMatrix(1, 36) = "TipoDoc"
				'            .TextMatrix(0, 36) = "TipoId"
				'            .TextMatrix(1, 36) = "Proveedor"
				'            .TextMatrix(0, 36) = "Reembolso"
				'            .TextMatrix(1, 36) = "Id.Proveedor"
				'            .TextMatrix(0, 36) = "SerieEstabl"
				'            .TextMatrix(1, 36) = "DocReembolso"
				'            .TextMatrix(0, 36) = "SerieEmisión"
				'            .TextMatrix(1, 36) = "DocReembolso"
				'            .TextMatrix(0, 36) = "NroSecuencial"
				'            .TextMatrix(1, 36) = "DocReembolso"
				'            .TextMatrix(0, 36) = "FechaEmisión"
				'            .TextMatrix(1, 36) = "DocReembolso"
				'            .TextMatrix(0, 36) = "Autorización"
				'            .TextMatrix(1, 36) = "DocReembolso"
				'            .TextMatrix(0, 36) = "BaseImp.0%Iva"
				'            .TextMatrix(1, 36) = "DocReembolso"
				'            .TextMatrix(0, 36) = "BaseImp.ConIva"
				'            .TextMatrix(1, 36) = "DocReembolso"
				'            .TextMatrix(0, 36) = "BaseImp.NoIva"
				'            .TextMatrix(1, 36) = "DocReembolso"
				'            .TextMatrix(0, 36) = "Monto_ICE"
				'            .TextMatrix(1, 36) = "DocReembolso"
				'            .TextMatrix(0, 36) = "Monto_IVA"
				'            .TextMatrix(1, 36) = "DocReembolso"
				
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Redraw. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Redraw = False
			ElseIf TipTra = 2 Then 
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Cols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Cols = 12
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 1) = "Tipo"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 1) = "Iden"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 2) = "Cedula Id."
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 2) = "O RUC"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 3) = "Tipo"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 3) = "Cpbte"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 4) = "Número"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 4) = "Cpbte."
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 5) = "BaseGravada"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 5) = "Sin Iva"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 6) = "BaseTarifa"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 6) = "IvaCero"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 7) = "BaseGravada"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 7) = "Con Iva"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 8) = "MontoIva"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 8) = ""
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 9) = "MontoRetenido"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 9) = "IVA"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 10) = "MontoRetenido"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 10) = "Renta"
				
			ElseIf TipTra = 4 Then 
				
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Cols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Cols = 19
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 1) = "Exportación"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 1) = "De:"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 2) = "Tipo"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 2) = "Comprobante"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 3) = "Referendo"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 3) = "Distrito"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 4) = "Referendo"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 4) = "Año"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 5) = "Referendo"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 5) = "Règimen"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 6) = "Referendo"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 6) = "Correlativo"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 7) = "Referendo"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 7) = "Verificador"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 8) = "Nro.Documento"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 8) = "Transporte"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 9) = "Fecha"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 9) = "Transacción"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 10) = "Nro. FUE"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 10) = ""
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 11) = "ValorFOB"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 11) = ""
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 12) = "ValorFOB"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 12) = "Comprobante"
				
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 13) = "Serie"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 13) = "Estbl."
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 14) = "Serie"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 14) = "Emis."
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 15) = "Número"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 15) = "CpbteVenta"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 16) = "Número"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 16) = "Autoriza"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 17) = "Fecha"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 17) = "Emisión"
				
			ElseIf TipTra = 3 Then 
				
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Cols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Cols = 26
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 1) = "Sustento"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 1) = "Tributario"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 2) = "Importación"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 2) = "De:"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 3) = "Fecha"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 3) = "Liquidaciòn"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 4) = "Tipo"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 4) = "Comprobante"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 5) = "Referendo"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 5) = "Distrito"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 6) = "Referendo"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 6) = "Año"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 7) = "Referendo"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 7) = "Règimen"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 8) = "Referendo"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 8) = "Correlativo"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 9) = "Referendo"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 9) = "Verificador"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 10) = "Codigo"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 10) = "Proveedor"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 11) = "ValorCIF"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 11) = ""
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 12) = "Proveedor"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 12) = "RazonSocial"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 13) = "Proveedor"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 13) = "TipoSujeto"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 14) = "BaseImponible"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 14) = "TarifaCero"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 15) = "BaseImponible"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 15) = "GravadaIVA"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 16) = "Codigo"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 16) = "% IVA"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 17) = "MontoIVA"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 18) = "ICE"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 18) = "BaseImponible"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 19) = "ICE"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 19) = "Código %"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 20) = "ICE"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 20) = "Monto"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 21) = "ConcRetención"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 21) = "FuenteI.Renta"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 22) = "BaseImponible"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 22) = "ImpuestoRenta"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 23) = "Codigo"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 23) = "% Renta"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 24) = "RetencionRenta"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 24) = "Monto"
				
			ElseIf TipTra = 5 Then 
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Cols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Cols = 8
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 1) = "Tipo"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 1) = "Cpbte."
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 2) = "Serie"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 2) = "Estbl."
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 3) = "Serie"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 3) = "Emis."
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 4) = "NúmeroInicial"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 4) = "CpbteAnulado"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 5) = "NúmeroFinal"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 5) = "CpbteAnulado"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 6) = "Número"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 6) = "Autorizacion"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 7) = "FechaDe"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 7) = "Anulación"
			ElseIf TipTra = 6 Then 
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Cols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Malla.Cols = 21
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 1) = "Tipo"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 1) = "Ident."
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 2) = "Nro.Cedula"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 2) = "O Ruc"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 3) = "Tipo"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 3) = "Cpbte"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 4) = "Número"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 4) = "Autoriza"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 5) = "Serie"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 5) = "Estbl."
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 6) = "Serie"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 6) = "Emis."
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 7) = "Número"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 7) = "Compbte"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 8) = "Fecha"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 8) = "Emision"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 9) = "Retción. AIR"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 9) = "Concepto"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 10) = "Retción. AIR"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 10) = "porcentaje"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 11) = "BaseTarifa"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 11) = "IvaCero"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 12) = "BaseGrabada"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 12) = "IVA"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 13) = "BaseNoGraba"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 13) = "IVA"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 14) = "Retción. AIR-1"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 14) = "ValorMonto"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 15) = "Retencion"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 15) = "NroAutorizac"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 16) = "Serie"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 16) = "Estb."
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 17) = "Serie"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 17) = "P.Emis."
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 18) = "Retencion"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 18) = "Número"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(0, 19) = "Retencion"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(1, 19) = "Fecha"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Redraw. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Redraw = False
			End If
			' establecer combinación y orden de columna de cuadrícula
			If TipTra = 2 Then
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.MergeCol. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.MergeCol(2) = True
			ElseIf TipTra = 1 Or TipTra = 6 Then 
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Cols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				For i = 1 To .Cols - 1
					'.MergeCol(i) = True
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.ColData. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.ColData(i) = 50
				Next i
				'            If TipTra = 1 Then
				'                .ColData(12) = 40
				'                .ColData(37) = 40
				'                .ColData(43) = 40
				'            End If
			End If
			'.Sort = flexSortGenericAscending
			
			' establecer tipo de cuadrícula
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.AllowBigSelection. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.AllowBigSelection = True
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.FillStyle. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.FillStyle = MSFlexGridLib.FillStyleSettings.flexFillRepeat
			
			' encabezado en negrita
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Row. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Row = 0
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Col. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Col = 0
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.RowSel. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.FixedRows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.RowSel = .FixedRows - 1
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.ColSel. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Cols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColSel = .Cols - 1
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.CellFontBold. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.CellFontBold = True
			
			' atenuar otra columna
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Cols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.FixedCols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			For i = .FixedCols To .Cols() - 1
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Col. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Col = i
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Row. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.FixedRows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Row = .FixedRows
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.RowSel. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.RowSel = .Rows - 1
				'6 12 20 25 29 33 38 43
				If TipTra = 1 Then
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.CellBackColor. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If i > 0 And i <= 6 Then .CellBackColor = &HF7E7E1 '&HC0C0C0   ' gris claro
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.CellBackColor. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If i > 6 And i <= 12 Then .CellBackColor = &HC0FFFF '&HC0C0C0   ' gris claro
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.CellBackColor. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If i > 12 And i <= 20 Then .CellBackColor = &HC0C0FF '&HC0C0C0   ' gris claro
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.CellBackColor. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If i > 20 And i <= 25 Then .CellBackColor = &HB7E7E1 '&HC0C0C0   ' gris claro
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.CellBackColor. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If i > 25 And i <= 29 Then .CellBackColor = &HC0E0FF '&HC0C0C0   ' gris claro
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.CellBackColor. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If i > 29 And i <= 33 Then .CellBackColor = &HFFC0C0 '&HC0C0C0   ' gris claro
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.CellBackColor. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If i > 33 And i <= 38 Then .CellBackColor = &HC0FFC0 '&HC0C0C0   ' gris claro
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.CellBackColor. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If i > 38 Then .CellBackColor = &HE0E0E0 '&HC0C0C0   ' gris claro
				Else
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.CellBackColor. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Int(i / 2) = i / 2 Then .CellBackColor = &HC0C0C0 ' gris claro
				End If
			Next i
			
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.AllowBigSelection. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.AllowBigSelection = False
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.FillStyle. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.FillStyle = MSFlexGridLib.FillStyleSettings.flexFillSingle
			
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Cols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColWidth(Malla.Cols - 1) = 0
			'    ' NUMERAR COLUMNAS
			j = 0
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.FixedRows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			For i = .FixedRows To .Rows - 1
				j = j + 1
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(i, 0) = j
				'''' chequear la autorizacion solo para importaciones ADCOM
				
				If TipTra = 1 Then
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If .TextMatrix(i, 10) > "" And .TextMatrix(i, 12) = "" Then
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						autoriza = BuscarAutorizacionesSRI(.TextMatrix(i, 3), .TextMatrix(i, 4), .TextMatrix(i, 8), .TextMatrix(i, 9), .TextMatrix(i, 10), Malla.TextMatrix(i, 11), .TextMatrix(i, 10))
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						.TextMatrix(i, 12) = autoriza.AutNroAut
						'UPGRADE_NOTE: El objeto autoriza no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
						autoriza = Nothing
					End If
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If .TextMatrix(i, 32) = "" Then
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						autoriza = BuscarAutorizacionesSRI((Emp.ruc), "RTP", .TextMatrix(i, 29), .TextMatrix(i, 30), .TextMatrix(i, 31), .TextMatrix(i, 33), .TextMatrix(i, 31))
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						.TextMatrix(i, 32) = autoriza.AutNroAut
						'UPGRADE_NOTE: El objeto autoriza no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
						autoriza = Nothing
					End If
					
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.TextMatrix(i, 13) = VB6.Format(.TextMatrix(i, 13), "########0.00")
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.TextMatrix(i, 14) = VB6.Format(.TextMatrix(i, 14), "########0.00")
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.TextMatrix(i, 15) = VB6.Format(.TextMatrix(i, 15), "########0.00")
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.TextMatrix(i, 16) = VB6.Format(.TextMatrix(i, 16), "########0.00")
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.TextMatrix(i, 17) = VB6.Format(.TextMatrix(i, 17), "########0.00")
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.TextMatrix(i, 18) = VB6.Format(.TextMatrix(i, 18), "########0.00")
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.TextMatrix(i, 19) = VB6.Format(.TextMatrix(i, 19), "########0.00")
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.TextMatrix(i, 20) = VB6.Format(.TextMatrix(i, 20), "########0.00")
					
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.TextMatrix(i, 27) = VB6.Format(.TextMatrix(i, 27), "########0.00")
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.TextMatrix(i, 28) = VB6.Format(.TextMatrix(i, 28), "########0.00")
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.TextMatrix(i, 29) = VB6.Format(.TextMatrix(i, 29), "########0.00")
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.TextMatrix(i, 31) = VB6.Format(.TextMatrix(i, 31), "########0.00")
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.TextMatrix(i, 32) = VB6.Format(.TextMatrix(i, 32), "########0.00")
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.TextMatrix(i, 33) = VB6.Format(.TextMatrix(i, 33), "########0.00")
					
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.ColAlignment(13) = 7
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.ColAlignment(14) = 7
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.ColAlignment(15) = 7
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.ColAlignment(16) = 7
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.ColAlignment(17) = 7
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.ColAlignment(18) = 7
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.ColAlignment(19) = 7
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.ColAlignment(20) = 7
					
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.ColAlignment(27) = 7
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.ColAlignment(28) = 7
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.ColAlignment(29) = 7
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.ColAlignment(31) = 7
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.ColAlignment(32) = 7
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.ColAlignment(33) = 7
					
					
				ElseIf TipTra = 6 Then 
					
					
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.TextMatrix(i, 11) = VB6.Format(.TextMatrix(i, 11), "########0.00")
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.TextMatrix(i, 12) = VB6.Format(.TextMatrix(i, 12), "########0.00")
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.TextMatrix(i, 13) = VB6.Format(.TextMatrix(i, 13), "########0.00")
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.TextMatrix(i, 14) = VB6.Format(.TextMatrix(i, 14), "########0.00")
					
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.ColAlignment(11) = 7
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.ColAlignment(12) = 7
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.ColAlignment(13) = 7
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.ColAlignment(14) = 7
					
					
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Not (.TextMatrix(i, 4) > "") Then
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						autoriza = BuscarAutorizacionesSRI(Malla.TextMatrix(i, 2), Malla.TextMatrix(i, 3), Malla.TextMatrix(i, 5), Malla.TextMatrix(i, 6), Malla.TextMatrix(i, 7), Malla.TextMatrix(i, 8))
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						.TextMatrix(i, 4) = autoriza.AutNroAut
					End If
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If .TextMatrix(i, 18) > "" And .TextMatrix(i, 15) = "" Then
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						autoriza = BuscarAutorizacionesSRI((Emp.ruc), "RTP", Malla.TextMatrix(i, 16), Malla.TextMatrix(i, 17), Malla.TextMatrix(i, 18), Malla.TextMatrix(i, 19))
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						.TextMatrix(i, 15) = autoriza.AutNroAut
						'UPGRADE_NOTE: El objeto autoriza no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
						autoriza = Nothing
					End If
					
				ElseIf TipTra = 2 Then 
					
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.TextMatrix(i, 6) = VB6.Format(.TextMatrix(i, 6), "########0.00")
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.TextMatrix(i, 7) = VB6.Format(.TextMatrix(i, 7), "########0.00")
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.TextMatrix(i, 8) = VB6.Format(.TextMatrix(i, 8), "########0.00")
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.TextMatrix(i, 9) = VB6.Format(.TextMatrix(i, 9), "########0.00")
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.TextMatrix(i, 10) = VB6.Format(.TextMatrix(i, 10), "########0.00")
					
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.ColAlignment(5) = 7
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.ColAlignment(6) = 7
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.ColAlignment(7) = 7
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.ColAlignment(8) = 7
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.ColAlignment(9) = 7
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.ColAlignment(10) = 7
					
				End If
				
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Cols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				For L = 1 To Malla.Cols - 1
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If IsDate(.TextMatrix(i, L)) Then
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If CDate(.TextMatrix(i, L)) <= CDate("1899-12-30") Then .TextMatrix(i, L) = ""
					End If
				Next L
			Next 
			
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Redraw. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Redraw = True
			
		End With
		'SELECT Ventas.Cl_CodigoCliente, Ventas.Cl_TipoComprobante, Ventas.CL_NroSerieEstablec, Ventas.CL_NroSeriePtoEmision, Ventas.CL_NroSecuencial, Ventas.CL_FechaComprobante, Ventas.CL_FechaRegContable, Ventas.CL_NroDeComprobantes, Ventas.CL_BaseImpTarCero, Ventas.CL_BaseImpGravadaIva, Ventas.CL_CodigoPorcIva, Ventas.CL_IvaPresuntivo, Ventas.CL_BaseImpICE, Ventas.CL_CodigoPorcICE, Ventas.CL_MontoIvaBienes, Ventas.CL_CodPorcRetIvaBienes, Ventas.CL_MontoRetIvaBienes, Ventas.CL_CodPorRetIvaServicios, Ventas.CL_RetencionPresuntiva1, Ventas.CL_CodRetFteImpRenta1, Ventas.CL_BaseImponibleIR1, Ventas.CL_RetencionPresuntiva2, Ventas.CL_CodRetFteImpRenta2, Ventas.CL_BaseImponibleIR2
		'FROM Ventas;
		
	End Sub
	
	Public Function EspecialesCompras(ByRef keycode As Short, ByRef Fila As Short, ByRef Columna As Short, ByRef Malla As AxMSHierarchicalFlexGridLib.AxMSHFlexGrid) As String
		Dim ccol, Rrow As Short
		Dim Aux As String
		Dim QUENOMBRE, QUECODIGO, Campo As String
		Dim QUEVALOR As Double
		Dim HastaFecha As Date
		Dim Alx As New ManDirct.DirectorioAlex
		Dim autoriza As New AutorizacionSri
		Dim BuscaClient As New ManDirct.BuscaClien
		Dim BusCod As New Syscod.ManSysnetClass
		'BusCod.ConectarSyscod = ConxSysemp
		Dim codCodigo As String
		Dim codNombre As String
		Dim codRef As String
		ccol = Columna
		Rrow = Fila
		Campo = Malla.Text
		
		Select Case keycode
			Case System.Windows.Forms.Keys.F2 'buscavalores
				Select Case ccol
					Case 1
						BuscaSustento.Busca(QUECODIGO, QUENOMBRE)
						'UPGRADE_NOTE: El objeto BuscaSustento no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
						BuscaSustento = Nothing
						Campo = QUECODIGO
					Case 2
						'                Set Alx = New Directorio
						'                Aux = BuscaClien.IniBuscaCliOPro("C", "")
						'                If Aux = "" Then Aux = Malla.TextMatrix(Rrow, 3)
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Alx.CargarAlex. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Alx.CargarAlex(Malla.get_TextMatrix(Rrow, 3), True)
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Alx.CiRuc. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Malla.set_TextMatrix(Rrow, 3, Alx.CiRuc)
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Alx.TipoId. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Campo = CorrijeTipoId(Alx.TipoId)
						BuscaTipoId.BuscaDoc(1, QUECODIGO, QUENOMBRE)
						Campo = QUECODIGO
					Case 3
						Alx = New ManDirct.DirectorioAlex
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto BuscaClient.IniBuscaCliOPro. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Aux = BuscaClient.IniBuscaCliOPro("C", "")
						If Aux = "" Then Aux = Campo
						'                Alx.CargarAlex Aux, True
						'                Campo = Alx.CiRuc
						Malla.set_TextMatrix(Rrow, 2, CorrijeTipoId(Campo))
					Case 4
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Alx.CargarAlex. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Alx.CargarAlex(Malla.get_TextMatrix(Rrow, 4), True, "S")
						BuscDocSri.BuscaDoc(PerPeriodo, 1, Val(Malla.get_TextMatrix(Rrow, 1)), CorrijeTipoId(Malla.get_TextMatrix(Rrow, 2)), QUECODIGO, QUENOMBRE)
						Campo = QUECODIGO
					Case 5
						''''                'campo = buscar tipo de proveedor
					Case 34, 35, 40, 41, 8, 9
						Campo = "001"
					Case 7, 11, 38
						Campo = CStr(QueFecha)
					Case 12
						'Set Alx = New Directorio
						'Alx.CargarAlex Malla.TextMatrix(Rrow, 3), True, "S"
						autoriza = BuscarAutorizacionesSRI(Malla.get_TextMatrix(Rrow, 3), Malla.get_TextMatrix(Rrow, 4), Malla.get_TextMatrix(Rrow, 8), Malla.get_TextMatrix(Rrow, 9), Malla.get_TextMatrix(Rrow, 10), Malla.get_TextMatrix(Rrow, 11))
						Campo = autoriza.AutNroAut
						'UPGRADE_NOTE: El objeto autoriza no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
						autoriza = Nothing
					Case 21
						'blic Function BuscarTipoRef(ByVal tipoRef As String, ByRef Codigoref As String, ByRef Descripcionref As String) As String
						codRef = "formapagosri"
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto BusCod.BuscarReferencia. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						BusCod.BuscarReferencia(codRef, codCodigo, codNombre)
						Campo = codCodigo
					Case 22
						codRef = "paises"
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto BusCod.BuscarReferencia. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						BusCod.BuscarReferencia(codRef, codCodigo, codNombre)
						Campo = codCodigo
					Case 25
						codRef = "tipopagosri"
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto BusCod.BuscarReferencia. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						BusCod.BuscarReferencia(codRef, codCodigo, codNombre)
						Campo = codCodigo
					Case 37
						Alx = New ManDirct.DirectorioAlex
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Alx.CargarAlex. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Alx.CargarAlex(Malla.get_TextMatrix(Rrow, 3), True, "S")
						autoriza = BuscarAutorizacionesSRI((Emp.ruc), "RTP", Malla.get_TextMatrix(Rrow, 34), Malla.get_TextMatrix(Rrow, 35), Malla.get_TextMatrix(Rrow, 36), Malla.get_TextMatrix(Rrow, 38))
						Campo = autoriza.AutNroAut
						'UPGRADE_NOTE: El objeto autoriza no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
						autoriza = Nothing
						'            Case 36
						'                Set Alx = New Directorio
						'                Alx.CargarAlex Malla.TextMatrix(Rrow, 3), True, "S"
						'                 Set autoriza = BuscarAutorizacionesSRI(Emp.ruc, "RTP", Malla.TextMatrix(Rrow, 27), Malla.TextMatrix(Rrow, 28), Malla.TextMatrix(Rrow, 29), Malla.TextMatrix(Rrow, 31))
						'                Campo = autoriza.AutNroAut
						'                Set autoriza = Nothing
					Case 26
						BuscaRetencionAIR.Busca(QUECODIGO, QUENOMBRE, QUEVALOR)
						Campo = QUECODIGO
						Malla.set_TextMatrix(Rrow, 28, Val(CStr(QUEVALOR)))
						Malla.set_TextMatrix(Rrow, 29, System.Math.Round(Val(CStr(QUEVALOR)) * Val(Malla.get_TextMatrix(Rrow, 27)) / 100, 2))
					Case 30
						BuscaRetencionAIR.Busca(QUECODIGO, QUENOMBRE, QUEVALOR)
						Campo = QUECODIGO
						Malla.set_TextMatrix(Rrow, 32, Val(CStr(QUEVALOR)))
						Malla.set_TextMatrix(Rrow, 33, System.Math.Round(Val(CStr(QUEVALOR)) * CorrijeNuloN(Malla.get_TextMatrix(Rrow, 31)) / 100, 2))
				End Select
				'Case vbKeyF4
				'        Select Case ccol
				'            Case 2
				'                Campo = "9999999999999"
				'                Malla.TextMatrix(Rrow, 3) = "F"
				'            Case 2
				'                Campo = IIf(Campo = "S", "N", "S")
				'            Case 7, 8, 17, 18, 20, 21
				'                Campo = "001"
				'            Case 4
				'                Campo = Malla.TextMatrix(Rrow, ccol - 1)
				'        End Select
		End Select
		EspecialesCompras = Campo
	End Function
	Public Function EspecialesVentas(ByRef keycode As Short, ByRef Fila As Short, ByRef Columna As Short, ByRef Malla As AxMSHierarchicalFlexGridLib.AxMSHFlexGrid) As String
		Dim buscaclien As Object
		Dim ccol, Rrow As Short
		Dim Aux As String
		Dim QUENOMBRE, QUECODIGO, Campo As String
		Dim QUEVALOR As Double
		Dim HastaFecha As Date
		Dim Alx As New ManDirct.Directorio
		
		ccol = Columna
		Rrow = Fila
		Campo = Malla.Text
		
		Select Case keycode
			Case System.Windows.Forms.Keys.F2 'buscavalores
				Select Case ccol
					Case 1
						'                Set Alx = New Directorio
						'                Aux = BuscaClien.IniBuscaCliOPro("C", "")
						'                Alx.CargarAlex Aux, True
						'                Malla.TextMatrix(rrow, 2) = Alx.CiRuc
						'                Campo = CorrijeTipoId(Alx.TipoId)
						BuscaTipoId.BuscaDoc(2, QUECODIGO, QUENOMBRE)
						Campo = QUECODIGO
					Case 2
						Alx = New ManDirct.Directorio
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto buscaclien.IniBuscaCliOPro. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Aux = buscaclien.IniBuscaCliOPro("C", "")
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Alx.CargarAlex. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Alx.CargarAlex(Aux, True)
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Alx.CiRuc. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Campo = Alx.CiRuc
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Alx.TipoId. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Malla.set_TextMatrix(Rrow, 1, CorrijeTipoId(Alx.TipoId))
					Case 3
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Alx.CargarAlex. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Alx.CargarAlex(Malla.get_TextMatrix(Rrow, 2), True, "S")
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Alx.TipoId. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						BuscDocSri.BuscaDoc(PerPeriodo, 2, 0, CorrijeTipoId(Alx.TipoId), QUECODIGO, QUENOMBRE)
						Campo = QUECODIGO
						'            Case 4, 6
						'                Campo = QueFecha
						'                Campo = FechaFinMes(Year(Campo), Month(Campo))
						'            Case 8, 21, 26
						'                Campo = IIf(Malla = "N", "S", "N")
						'            Case 10
						'                BuscaIVA.BuscaDoc Str(PerPeriodo), QUECODIGO, QueNombre, QUEVALOR
						'                Campo = QUECODIGO
						'            Case 11
						'                Campo = Round(CargarIva(CorrijeNuloN(Malla.TextMatrix(Rrow, 10))) * Val(Malla.TextMatrix(Rrow, 9)) / 100, 2)
						'            Case 13
						'                BuscaIce.BuscaDoc Str(PerPeriodo), QUECODIGO, QueNombre, QUEVALOR
						'                Campo = QUECODIGO
						'                Malla.TextMatrix(Rrow, 14) = Round(QUEVALOR * Val(Malla.TextMatrix(Rrow, 12)) / 100, 2)
						'            Case 14
						'                Campo = Round(CargarIce(Malla.TextMatrix(Rrow, 13)) * Val(Malla.TextMatrix(Rrow, 12)) / 100, 2)
						'            Case 15
						'                Campo = Malla.TextMatrix(Rrow, 11)
						'                Malla.TextMatrix(Rrow, 18) = 0
						'            Case 16
						'                BuscaRetIvaBienes.BuscaRet PerPeriodo, QUECODIGO, QueNombre, QUEVALOR
						'                Campo = QUECODIGO
						'                Malla.TextMatrix(Rrow, 17) = Round(QUEVALOR * Val(Malla.TextMatrix(Rrow, 15)) / 100, 2)
						'            Case 18
						'                Campo = Val(Malla.TextMatrix(Rrow, 11)) - Val(Malla.TextMatrix(Rrow, 15))
						'            Case 19
						'                BuscaRetIvaServicios.BuscaRet PerPeriodo, QUECODIGO, QueNombre, QUEVALOR
						'                Campo = QUECODIGO
						'                Malla.TextMatrix(Rrow, 20) = Round(QUEVALOR * Val(Malla.TextMatrix(Rrow, 18)) / 100, 2)
						'            Case 22
						'                BuscaRetencionAIR.Busca QUECODIGO, QueNombre, QUEVALOR
						'                Campo = QUECODIGO
						'                Malla.TextMatrix(Rrow, 24) = Val(QUEVALOR)
						'                Malla.TextMatrix(Rrow, 25) = Round(Val(QUEVALOR) * Val(Malla.TextMatrix(Rrow, 23)) / 100, 2)
						'            Case 26
						'                BuscaRetencionAIR.Busca QUECODIGO, QueNombre, QUEVALOR
						'                Campo = QUECODIGO
						'                Malla.TextMatrix(Rrow, 28) = Val(QUEVALOR)
						'                Malla.TextMatrix(Rrow, 29) = Round(Val(QUEVALOR) * Val(Malla.TextMatrix(Rrow, 27)) / 100, 2)
				End Select
			Case System.Windows.Forms.Keys.F4
				Select Case ccol
					Case 2
						Campo = "9999999999999"
						Malla.set_TextMatrix(Rrow, 1, "F")
					Case 1
						Campo = "F"
						Malla.set_TextMatrix(Rrow, 2, "9999999999999")
				End Select
		End Select
		EspecialesVentas = Campo
	End Function
	
	Public Function EspecialesImportaciones(ByRef keycode As Short, ByRef Fila As Short, ByRef Columna As Short, ByRef Malla As AxMSHierarchicalFlexGridLib.AxMSHFlexGrid) As String
		Dim BuscaIce As Object
		Dim BuscaIVA As Object
		Dim buscaclien As Object
		Dim buscadistritoaduanero As Object
		Dim ccol, Rrow As Short
		Dim Aux As String
		Dim QUENOMBRE, QUECODIGO, Campo As String
		Dim QUEVALOR As Double
		Dim HastaFecha As Date
		Dim Alx As New ManDirct.Directorio
		
		ccol = Columna
		Rrow = Fila
		Campo = Malla.Text
		
		Select Case keycode
			Case System.Windows.Forms.Keys.F2 'buscavalores
				Select Case ccol
					Case 1
						BuscaSustento.Busca(QUECODIGO, QUENOMBRE)
						'UPGRADE_NOTE: El objeto BuscaSustento no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
						BuscaSustento = Nothing
						Campo = QUECODIGO
					Case 2
						BuscaTipoImportacion.BuscaDoc(PerPeriodo, QUECODIGO, QUENOMBRE, QUEVALOR)
						'UPGRADE_NOTE: El objeto BuscaTipoImportacion no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
						BuscaTipoImportacion = Nothing
						Campo = QUECODIGO
					Case 3
						Campo = CStr(QueFecha)
					Case 4
						BuscDocSri.BuscaDoc(PerPeriodo, 3, CShort(Malla.get_TextMatrix(Rrow, 1)), "", QUECODIGO, QUENOMBRE)
						Campo = QUECODIGO
					Case 5
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto buscadistritoaduanero.BuscaDoc. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						buscadistritoaduanero.BuscaDoc("", QUECODIGO, QUENOMBRE)
						Campo = QUECODIGO
					Case 10
						Alx = New ManDirct.Directorio
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto buscaclien.IniBuscaCliOPro. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Aux = buscaclien.IniBuscaCliOPro("P", "")
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Alx.CargarAlex. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Alx.CargarAlex(Aux, True)
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Alx.CiRuc. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Campo = Alx.CiRuc
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Alx.NombreImpresion. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Malla.set_TextMatrix(Rrow, 12, Alx.NombreImpresion)
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Alx.TipoPersona. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Malla.set_TextMatrix(Rrow, 13, Alx.TipoPersona)
					Case 11
						Alx = New ManDirct.Directorio
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto buscaclien.IniBuscaCliOPro. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Aux = buscaclien.IniBuscaCliOPro("P", "")
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Alx.CargarAlex. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Alx.CargarAlex(Aux, True)
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Alx.NombreImpresion. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Campo = Alx.NombreImpresion
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Alx.CiRuc. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Malla.set_TextMatrix(Rrow, 12, Alx.CiRuc)
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Alx.TipoPersona. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Malla.set_TextMatrix(Rrow, 13, Alx.TipoPersona)
					Case 16
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto BuscaIVA.BuscaDoc. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						BuscaIVA.BuscaDoc(Str(CDbl(PerPeriodo)), QUECODIGO, QUENOMBRE, QUEVALOR)
						Campo = QUECODIGO
					Case 17
						Campo = CStr(System.Math.Round(CargarIva(CShort(Malla.get_TextMatrix(Rrow, 16))) * Val(Malla.get_TextMatrix(Rrow, 15)) / 100, 2))
					Case 19
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto BuscaIce.BuscaDoc. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						BuscaIce.BuscaDoc(Str(CDbl(PerPeriodo)), QUECODIGO, QUENOMBRE, QUEVALOR)
						Campo = QUECODIGO
						Malla.set_TextMatrix(Rrow, 20, System.Math.Round(QUEVALOR * Val(Malla.get_TextMatrix(Rrow, 18)) / 100, 2))
					Case 20
						Campo = CStr(System.Math.Round(CargarIce(CShort(Malla.get_TextMatrix(Rrow, 19))) * Val(Malla.get_TextMatrix(Rrow, 18)) / 100, 2))
					Case 21
						BuscaRetencionAIR.Busca(QUECODIGO, QUENOMBRE, QUEVALOR)
						Campo = QUECODIGO
						Malla.set_TextMatrix(Rrow, 23, Val(CStr(QUEVALOR)))
						Malla.set_TextMatrix(Rrow, 24, System.Math.Round(Val(CStr(QUEVALOR)) * Val(Malla.get_TextMatrix(Rrow, 22)) / 100, 2))
					Case 23
						BuscaRetencionAIR.Busca(QUECODIGO, QUENOMBRE, QUEVALOR)
						Campo = CStr(QUEVALOR)
						Malla.set_TextMatrix(Rrow, 21, Val(QUECODIGO))
						Malla.set_TextMatrix(Rrow, 24, System.Math.Round(Val(CStr(QUEVALOR)) * Val(Malla.get_TextMatrix(Rrow, 22)) / 100, 2))
				End Select
		End Select
		EspecialesImportaciones = Campo
	End Function
	
	Public Function EspecialesReoc(ByRef keycode As Short, ByRef Fila As Short, ByRef Columna As Short, ByRef Malla As AxMSHierarchicalFlexGridLib.AxMSHFlexGrid) As String
		Dim buscaclien As Object
		Dim ccol, Rrow As Short
		Dim Aux As String
		Dim QUENOMBRE, QUECODIGO, Campo As String
		Dim QUEVALOR As Double
		Dim HastaFecha As Date
		Dim Alx As New ManDirct.Directorio
		Dim autoriza As New AutorizacionSri
		ccol = Columna
		Rrow = Fila
		Campo = Malla.Text
		
		Select Case keycode
			Case System.Windows.Forms.Keys.F2 'buscavalores
				Select Case ccol
					'            Case 1
					'                BuscaSustento.Busca QUECODIGO, QUENOMBRE
					'                Set BuscaSustento = Nothing
					'                Campo = QUECODIGO
					'            Case 2
					'                Campo = IIf(Malla = "S", "N", "S")
					Case 1
						'                Set Alx = New Directorio
						'                Aux = BuscaClien.IniBuscaCliOPro("C", "")
						'                If Aux = "" Then Aux = malla.TextMatrix(rrow, 4)
						'                Alx.CargarAlex Aux, True
						'                malla.TextMatrix(rrow, 4) = Alx.CiRuc
						'                Campo = CorrijeTipoId(Alx.TipoId)
						BuscaTipoId.BuscaDoc(1, QUECODIGO, QUENOMBRE)
						Campo = QUECODIGO
					Case 2
						Alx = New ManDirct.Directorio
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto buscaclien.IniBuscaCliOPro. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Aux = buscaclien.IniBuscaCliOPro("C", "")
						If Aux = "" Then Aux = Campo
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Alx.CargarAlex. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Alx.CargarAlex(Aux, True)
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Alx.CiRuc. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Campo = Alx.CiRuc
						'                Malla.TextMatrix(Rrow, 2) = CorrijeTipoId(Alx.TipoId)
					Case 3
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Alx.CargarAlex. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Alx.CargarAlex(Malla.get_TextMatrix(Rrow, 2), True, "S")
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Alx.TipoId. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						BuscDocSri.BuscaDoc(PerPeriodo, 1, 1, CorrijeTipoId(Alx.TipoId), QUECODIGO, QUENOMBRE)
						Campo = QUECODIGO
					Case 5, 6, 16, 17
						Campo = "001"
					Case 8, 19
						Campo = CStr(QueFecha)
					Case 4
						'                Set Alx = New Directorio
						'                Alx.CargarAlex malla.TextMatrix(Rrow, 4), True, "S"
						autoriza = BuscarAutorizacionesSRI(Malla.get_TextMatrix(Rrow, 2), Malla.get_TextMatrix(Rrow, 1), Malla.get_TextMatrix(Rrow, 5), Malla.get_TextMatrix(Rrow, 6), Malla.get_TextMatrix(Rrow, 7), Malla.get_TextMatrix(Rrow, 8), Malla.get_TextMatrix(Rrow, 7))
						Campo = autoriza.AutNroAut
						If Val(Campo) = 0 Then
							Campo = AdcAutorizacionesSri.INICreaAutDoc(Malla.get_TextMatrix(Rrow, 2), Malla.get_TextMatrix(Rrow, 1), "", Malla.get_TextMatrix(Rrow, 5), Malla.get_TextMatrix(Rrow, 6))
						End If
						'Malla.TextMatrix(Rrow, 12) = autoriza.AutFechaVence
					Case 15
						'                Set Alx = New Directorio
						'                Alx.CargarAlex malla.TextMatrix(Rrow, 4), True, "S"
						autoriza = BuscarAutorizacionesSRI(Malla.get_TextMatrix(Rrow, 2), Malla.get_TextMatrix(Rrow, 1), Malla.get_TextMatrix(Rrow, 16), Malla.get_TextMatrix(Rrow, 17), Malla.get_TextMatrix(Rrow, 18), Malla.get_TextMatrix(Rrow, 19), Malla.get_TextMatrix(Rrow, 18))
						'Malla.TextMatrix(Rrow, 11) = autoriza.AutNroAut
						Campo = autoriza.AutNroAut 'autoriza.AutFechaVence
						'            Case 15
						'                BuscaIVA.BuscaDoc Str(PerPeriodo), QUECODIGO, QUENOMBRE, QUEVALOR
						'                Campo = QUECODIGO
						'            Case 16
						'                Campo = Round(CargarIva(Malla.TextMatrix(Rrow, 15)) * Val(Malla.TextMatrix(Rrow, 14)) / 100, 2)
						'            Case 18
						'                BuscaIce.BuscaDoc Str(PerPeriodo), QUECODIGO, QUENOMBRE, QUEVALOR
						'                Campo = QUECODIGO
						'                Malla.TextMatrix(Rrow, 19) = Round(QUEVALOR * CorrijeNuloN(Malla.TextMatrix(Rrow, 17)) / 100, 2)
						'            Case 19
						'                Campo = Round(CargarIce(CorrijeNuloN(Malla.TextMatrix(Rrow, 18))) * CorrijeNuloN(Malla.TextMatrix(Rrow, 17)) / 100, 2)
						'            Case 20
						'                Campo = Malla.TextMatrix(Rrow, 16)
						'                Malla.TextMatrix(Rrow, 23) = 0
						'            Case 23
						'                Campo = Val(Malla.TextMatrix(Rrow, 16)) - Val(Malla.TextMatrix(Rrow, 20))
						'            Case 21
						'                BuscaRetIvaBienes.BuscaRet PerPeriodo, QUECODIGO, QUENOMBRE, QUEVALOR
						'                Campo = QUECODIGO
						'                Malla.TextMatrix(Rrow, 22) = Round(QUEVALOR * Malla.TextMatrix(Rrow, 20) / 100, 2)
						'            Case 24
						'                BuscaRetIvaServicios.BuscaRet PerPeriodo, QUECODIGO, QUENOMBRE, QUEVALOR
						'                Campo = QUECODIGO
						'                Malla.TextMatrix(Rrow, 25) = Round(QUEVALOR * Malla.TextMatrix(Rrow, 23) / 100, 2)
						'            Case 26
						'                BuscaRetencionAIR.Busca QUECODIGO, QUENOMBRE, QUEVALOR
						'                Campo = QUECODIGO
						'                Malla.TextMatrix(Rrow, 28) = Val(QUEVALOR)
						'                Malla.TextMatrix(Rrow, 29) = Round(Val(QUEVALOR) * Val(Malla.TextMatrix(Rrow, 27)) / 100, 2)
						'            Case 30
						'                BuscaRetencionAIR.Busca QUECODIGO, QUENOMBRE, QUEVALOR
						'                Campo = QUECODIGO
						'                Malla.TextMatrix(Rrow, 32) = Val(QUEVALOR)
						'                Malla.TextMatrix(Rrow, 33) = Round(Val(QUEVALOR) * CorrijeNuloN(Malla.TextMatrix(Rrow, 31)) / 100, 2)
						'            Case 37
						''                Set Alx = New Directorio
						''                Alx.CargarAlex "0", True, "S"
						''                Campo = BuscaAutorizacionSri(Alx.CiRuc, "98", Malla.TextMatrix(Rrow, 34), Malla.TextMatrix(Rrow, 35), CorrijeNuloN(Malla.TextMatrix(Rrow, 36)), HastaFecha)
						'                Set autoriza = BuscarAutorizacionesSRI(Emp.ruc, "RTP", Malla.TextMatrix(Rrow, 34), Malla.TextMatrix(Rrow, 35), Malla.TextMatrix(Rrow, 36), Malla.TextMatrix(Rrow, 38), Malla.TextMatrix(Rrow, 36))
						'                Campo = autoriza.AutNroAut
						'                'Malla.TextMatrix(Rrow, 12) = autoriza.AutFechaVence
						'            Case 39
						'                Set Alx = New Directorio
						'                Alx.CargarAlex Malla.TextMatrix(Rrow, 1), True, "S"
						'                BuscDocSri.BuscaDoc Str(PerPeriodo), 1, 0, Alx.TipoId, QUECODIGO, QUENOMBRE
						'                Campo = QUECODIGO
						'            Case 43
						'                Set Alx = New Directorio
						'                Alx.CargarAlex Malla.TextMatrix(Rrow, 4), True, "S"
						''                Campo = BuscaAutorizacionSri(Alx.CiRuc, Malla.TextMatrix(Rrow, 39), Malla.TextMatrix(Rrow, 40), Malla.TextMatrix(Rrow, 41), CorrijeNuloN(Malla.TextMatrix(Rrow, 42)), HastaFecha)
				End Select
			Case System.Windows.Forms.Keys.F4
				Select Case ccol
					Case 2
						Campo = "9999999999999"
						Malla.set_TextMatrix(Rrow, 1, "F")
					Case 5, 6, 16, 17
						Campo = "001"
					Case 4
						Campo = Malla.get_TextMatrix(Rrow, ccol - 1)
				End Select
		End Select
		EspecialesReoc = Campo
	End Function
End Module