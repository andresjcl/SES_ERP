Option Strict Off
Option Explicit On
Module RutinasSri
	
	Public Sub ArreglaPeriodo(ByRef Año As Short, ByRef Mes As Short)
		Dim FecPeriodo As Object
		Dim PerPeriodo As Object
		Dim PerMes As Object
		Dim PerAnio As Object
		'cambiar on error Resume Next
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto PerAnio. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		PerAnio = Año
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto PerMes. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		PerMes = Mes
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto PerAnio. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto PerMes. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto PerPeriodo. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		PerPeriodo = Right("00" & PerMes, 2) & PerAnio
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto PerAnio. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto PerMes. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto FecPeriodo. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		FecPeriodo = VB6.Format("01/" & PerMes & "/" & PerAnio, "long date")
	End Sub
	
	Public Function SepararClaves(ByRef clave As String, ByRef Campo As String) As String
		Dim I, j As Short
		Dim Tt As Single
		Dim a As String
		Dim Cadena As String
		I = Len(clave)
		If I = 0 Or Campo = "" Then SepararClaves = "" : Exit Function
		Cadena = " " & Campo & " = "
		Tt = 0
		For j = 1 To I
			a = Mid(clave, j, 1)
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
		Dim ssql As String
		Dim codi As Short
		SrRec = New ADODB.Recordset
		CargarIva = 0
		ssql = "Select * From SriPorcentajesDelIva where codigo = " & CodIva
		SrRec = New ADODB.Recordset
		SrRec.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		SrRec.Open(ssql, ConxSyscod, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		If SrRec.State = 0 Then Exit Function
		If SrRec.EOF = False Then CargarIva = SrRec.Fields("PorcentajeIva").Value
		SrRec.Close()
		
	End Function
	
	Public Function CargarIce(ByRef CodIce As Short) As Double
		Dim Sw As Boolean
		Dim SrRec As New ADODB.Recordset
		Dim ssql As String
		Dim codi As Short
		SrRec = New ADODB.Recordset
		
		CargarIce = 0
		ssql = "Select * From SriPorcentajesDelIce where codigo = " & CodIce
		SrRec = New ADODB.Recordset
		SrRec.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		SrRec.Open(ssql, ConxSyscod, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
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
	' 'cambiar on error GoTo 0
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
	'        TxSeqTra = " and (CodigoSecuencialTransaccion LIKE '%" & RIGHT$("00" & SeqTransacc, 2) & "%')"
	'    End If
	'End If
	'
	'If TipoSustento > 0 Then
	'    TxSustento = "(SustentoTributario LIKE '%" & RIGHT$("00" & TipoSustento, 2) & "%') "
	'Else
	'    TxSustento = " SustentoTributario > '' "
	'End If
	'If codDoc > "" Then CodigoDoc = " and codigo = " & codDoc & " " Else CodigoDoc = ""
	'sSQL = "Select * From sritipodecomprobante Where " & TxSustento & TxSeqTra & CodigoDoc & " order by codigo "
	'    ' abrir conexión
	'    ' crear un conjunto de registros con la colección proporcionada
	'    Set SrRec = New ADODB.Recordset
	'    SrRec.CursorLocation = adUseClient
	' 'cambiar on error GoTo 0
	'    SrRec.Open sSQL, ConxSyscod, adOpenForwardOnly, adLockReadOnly
	'If SrRec.State = 0 Then Exit Function
	'If SrRec.EOF = False Then CargarDocumentoSri = True
	'SrRec.Close
	'End Function
	'
	Public Sub ArreglaMalla(ByRef Malla As AxMSHierarchicalFlexGridLib.AxMSHFlexGrid, ByRef TipTra As Short)
		'cambiar on error Resume Next
		Dim I, j As Short
		Dim L As Integer
		Dim autoriza As New AutorizacionSri
		Malla.set_ColWidth(0,  , 600)
		If Malla.Rows < 3 Then Malla.Rows = 3 ': Malla.FixedRows = 1
		Malla.FixedRows = 2
		With Malla
			.set_TextMatrix(0, 0, "Nro.")
			.set_TextMatrix(1, 0, "")
			If TipTra = 1 Then
				Malla.set_Cols( , 38)
				.set_TextMatrix(0, 1, "Sustento")
				.set_TextMatrix(1, 1, "Tributario")
				.set_TextMatrix(0, 2, "Tipo")
				.set_TextMatrix(1, 2, "Ident.")
				.set_TextMatrix(0, 3, "Nro.Cedula")
				.set_TextMatrix(1, 3, "O Ruc")
				.set_TextMatrix(0, 4, "Tipo")
				.set_TextMatrix(1, 4, "Cpbte")
				
				.set_TextMatrix(0, 5, "Fecha")
				.set_TextMatrix(1, 5, "Contabiliza")
				.set_TextMatrix(0, 6, "Serie")
				.set_TextMatrix(1, 6, "Estbl.")
				.set_TextMatrix(0, 7, "Serie")
				.set_TextMatrix(1, 7, "Emis.")
				.set_TextMatrix(0, 8, "Número")
				.set_TextMatrix(1, 8, "Compbte")
				.set_TextMatrix(0, 9, "Fecha")
				.set_TextMatrix(1, 9, "Emision")
				.set_TextMatrix(0, 10, "Número")
				.set_TextMatrix(1, 10, "Autoriza")
				.set_TextMatrix(0, 11, "BaseNoGraba")
				.set_TextMatrix(1, 11, "IVA")
				.set_TextMatrix(0, 12, "BaseTarifa")
				.set_TextMatrix(1, 12, "IvaCero")
				.set_TextMatrix(0, 13, "BaseGrabada")
				.set_TextMatrix(1, 13, "IVA")
				.set_TextMatrix(0, 14, "Monto")
				.set_TextMatrix(1, 14, "ICE")
				.set_TextMatrix(0, 15, "Monto")
				.set_TextMatrix(1, 15, "IVA")
				.set_TextMatrix(0, 16, "IvaBienes")
				.set_TextMatrix(1, 16, "MontoRetenido")
				.set_TextMatrix(0, 17, "IvaServicios")
				.set_TextMatrix(1, 17, "MontoRetenido")
				.set_TextMatrix(0, 18, "IvaServicios100")
				.set_TextMatrix(1, 18, "MontoRetenido")
				
				.set_TextMatrix(0, 19, "Retción. AIR-1")
				.set_TextMatrix(1, 19, "Concepto")
				.set_TextMatrix(0, 20, "Retción. AIR-1")
				.set_TextMatrix(1, 20, "BaseImponible")
				.set_TextMatrix(0, 21, "Retción. AIR-1")
				.set_TextMatrix(1, 21, "porcentaje")
				.set_TextMatrix(0, 22, "Retción. AIR-1")
				.set_TextMatrix(1, 22, "ValorMonto")
				
				.set_TextMatrix(0, 23, "Retción. AIR-2")
				.set_TextMatrix(1, 23, "Concepto")
				.set_TextMatrix(0, 24, "Retción. AIR-2")
				.set_TextMatrix(1, 24, "BaseImponible")
				.set_TextMatrix(0, 25, "Retción. AIR-2")
				.set_TextMatrix(1, 25, "porcentaje")
				.set_TextMatrix(0, 26, "Retción. AIR-2")
				.set_TextMatrix(1, 26, "ValorMonto")
				
				.set_TextMatrix(0, 27, "SerieRet")
				.set_TextMatrix(1, 27, "Estb.")
				.set_TextMatrix(0, 28, "SerieRet")
				.set_TextMatrix(1, 28, "P.Emis.")
				
				.set_TextMatrix(0, 29, "Retencion")
				.set_TextMatrix(1, 29, "Número")
				.set_TextMatrix(0, 30, "Retencion")
				.set_TextMatrix(1, 30, "NroAutorizac")
				.set_TextMatrix(0, 31, "Retencion")
				.set_TextMatrix(1, 31, "Fecha")
				
				.set_TextMatrix(0, 32, "DocModifica")
				.set_TextMatrix(1, 32, "Tipo")
				.set_TextMatrix(0, 33, "DocModifica")
				.set_TextMatrix(1, 33, "SerieEstbl.")
				.set_TextMatrix(0, 34, "DocModifica")
				.set_TextMatrix(1, 34, "SerieP.Emis")
				.set_TextMatrix(0, 35, "DocModifica")
				.set_TextMatrix(1, 35, "Número")
				.set_TextMatrix(0, 36, "DocModifica")
				.set_TextMatrix(1, 36, "Nro.Autoriza")
				
				.Redraw = False
			ElseIf TipTra = 2 Then 
				.set_Cols( , 12)
				.set_TextMatrix(0, 1, "Tipo")
				.set_TextMatrix(1, 1, "Iden")
				.set_TextMatrix(0, 2, "Cedula Id.")
				.set_TextMatrix(1, 2, "O RUC")
				.set_TextMatrix(0, 3, "Tipo")
				.set_TextMatrix(1, 3, "Cpbte")
				.set_TextMatrix(0, 4, "Número")
				.set_TextMatrix(1, 4, "Cpbte.")
				.set_TextMatrix(0, 5, "BaseGravada")
				.set_TextMatrix(1, 5, "Sin Iva")
				.set_TextMatrix(0, 6, "BaseTarifa")
				.set_TextMatrix(1, 6, "IvaCero")
				.set_TextMatrix(0, 7, "BaseGravada")
				.set_TextMatrix(1, 7, "Con Iva")
				.set_TextMatrix(0, 8, "MontoIva")
				.set_TextMatrix(1, 8, "")
				.set_TextMatrix(0, 9, "MontoRetenido")
				.set_TextMatrix(1, 9, "IVA")
				.set_TextMatrix(0, 10, "MontoRetenido")
				.set_TextMatrix(1, 10, "Renta")
				
			ElseIf TipTra = 4 Then 
				
				.set_Cols( , 19)
				.set_TextMatrix(0, 1, "Exportación")
				.set_TextMatrix(1, 1, "De:")
				.set_TextMatrix(0, 2, "Tipo")
				.set_TextMatrix(1, 2, "Comprobante")
				.set_TextMatrix(0, 3, "Referendo")
				.set_TextMatrix(1, 3, "Distrito")
				.set_TextMatrix(0, 4, "Referendo")
				.set_TextMatrix(1, 4, "Año")
				.set_TextMatrix(0, 5, "Referendo")
				.set_TextMatrix(1, 5, "Règimen")
				.set_TextMatrix(0, 6, "Referendo")
				.set_TextMatrix(1, 6, "Correlativo")
				.set_TextMatrix(0, 7, "Referendo")
				.set_TextMatrix(1, 7, "Verificador")
				.set_TextMatrix(0, 8, "Nro.Documento")
				.set_TextMatrix(1, 8, "Transporte")
				.set_TextMatrix(0, 9, "Fecha")
				.set_TextMatrix(1, 9, "Transacción")
				.set_TextMatrix(0, 10, "Nro. FUE")
				.set_TextMatrix(1, 10, "")
				.set_TextMatrix(0, 11, "ValorFOB")
				.set_TextMatrix(1, 11, "")
				.set_TextMatrix(0, 12, "ValorFOB")
				.set_TextMatrix(1, 12, "Comprobante")
				
				.set_TextMatrix(0, 13, "Serie")
				.set_TextMatrix(1, 13, "Estbl.")
				.set_TextMatrix(0, 14, "Serie")
				.set_TextMatrix(1, 14, "Emis.")
				.set_TextMatrix(0, 15, "Número")
				.set_TextMatrix(1, 15, "CpbteVenta")
				.set_TextMatrix(0, 16, "Número")
				.set_TextMatrix(1, 16, "Autoriza")
				.set_TextMatrix(0, 17, "Fecha")
				.set_TextMatrix(1, 17, "Emisión")
				
			ElseIf TipTra = 3 Then 
				
				.set_Cols( , 26)
				.set_TextMatrix(0, 1, "Sustento")
				.set_TextMatrix(1, 1, "Tributario")
				.set_TextMatrix(0, 2, "Importación")
				.set_TextMatrix(1, 2, "De:")
				.set_TextMatrix(0, 3, "Fecha")
				.set_TextMatrix(1, 3, "Liquidaciòn")
				.set_TextMatrix(0, 4, "Tipo")
				.set_TextMatrix(1, 4, "Comprobante")
				.set_TextMatrix(0, 5, "Referendo")
				.set_TextMatrix(1, 5, "Distrito")
				.set_TextMatrix(0, 6, "Referendo")
				.set_TextMatrix(1, 6, "Año")
				.set_TextMatrix(0, 7, "Referendo")
				.set_TextMatrix(1, 7, "Règimen")
				.set_TextMatrix(0, 8, "Referendo")
				.set_TextMatrix(1, 8, "Correlativo")
				.set_TextMatrix(0, 9, "Referendo")
				.set_TextMatrix(1, 9, "Verificador")
				.set_TextMatrix(0, 10, "Codigo")
				.set_TextMatrix(1, 10, "Proveedor")
				.set_TextMatrix(0, 11, "ValorCIF")
				.set_TextMatrix(1, 11, "")
				.set_TextMatrix(0, 12, "Proveedor")
				.set_TextMatrix(1, 12, "RazonSocial")
				.set_TextMatrix(0, 13, "Proveedor")
				.set_TextMatrix(1, 13, "TipoSujeto")
				.set_TextMatrix(0, 14, "BaseImponible")
				.set_TextMatrix(1, 14, "TarifaCero")
				.set_TextMatrix(0, 15, "BaseImponible")
				.set_TextMatrix(1, 15, "GravadaIVA")
				.set_TextMatrix(0, 16, "Codigo")
				.set_TextMatrix(1, 16, "% IVA")
				.set_TextMatrix(0, 17, "MontoIVA")
				.set_TextMatrix(0, 18, "ICE")
				.set_TextMatrix(0, 18, "BaseImponible")
				.set_TextMatrix(0, 19, "ICE")
				.set_TextMatrix(1, 19, "Código %")
				.set_TextMatrix(0, 20, "ICE")
				.set_TextMatrix(1, 20, "Monto")
				.set_TextMatrix(0, 21, "ConcRetención")
				.set_TextMatrix(1, 21, "FuenteI.Renta")
				.set_TextMatrix(0, 22, "BaseImponible")
				.set_TextMatrix(1, 22, "ImpuestoRenta")
				.set_TextMatrix(0, 23, "Codigo")
				.set_TextMatrix(1, 23, "% Renta")
				.set_TextMatrix(0, 24, "RetencionRenta")
				.set_TextMatrix(1, 24, "Monto")
				
			ElseIf TipTra = 5 Then 
				.set_Cols( , 8)
				.set_TextMatrix(0, 1, "Tipo")
				.set_TextMatrix(1, 1, "Cpbte.")
				.set_TextMatrix(0, 2, "Serie")
				.set_TextMatrix(1, 2, "Estbl.")
				.set_TextMatrix(0, 3, "Serie")
				.set_TextMatrix(1, 3, "Emis.")
				.set_TextMatrix(0, 4, "NúmeroInicial")
				.set_TextMatrix(1, 4, "CpbteAnulado")
				.set_TextMatrix(0, 5, "NúmeroFinal")
				.set_TextMatrix(1, 5, "CpbteAnulado")
				.set_TextMatrix(1, 6, "Número")
				.set_TextMatrix(0, 6, "Autorizacion")
				.set_TextMatrix(1, 7, "FechaDe")
				.set_TextMatrix(0, 7, "Anulación")
			ElseIf TipTra = 6 Then 
				Malla.set_Cols( , 27)
				.set_TextMatrix(0, 1, "Tipo")
				.set_TextMatrix(1, 1, "Ident.")
				.set_TextMatrix(0, 2, "Nro.Cedula")
				.set_TextMatrix(1, 2, "O Ruc")
				.set_TextMatrix(0, 3, "Tipo")
				.set_TextMatrix(1, 3, "Cpbte")
				.set_TextMatrix(0, 4, "Número")
				.set_TextMatrix(1, 4, "Autoriza")
				.set_TextMatrix(0, 5, "Serie")
				.set_TextMatrix(1, 5, "Estbl.")
				.set_TextMatrix(0, 6, "Serie")
				.set_TextMatrix(1, 6, "Emis.")
				.set_TextMatrix(0, 7, "Número")
				.set_TextMatrix(1, 7, "Compbte")
				.set_TextMatrix(0, 8, "Fecha")
				.set_TextMatrix(1, 8, "Emision")
				
				.set_TextMatrix(0, 9, "Ret.AIR-1")
				.set_TextMatrix(1, 9, "Concepto")
				.set_TextMatrix(0, 10, "Ret.AIR-1")
				.set_TextMatrix(1, 10, "porcentaje")
				.set_TextMatrix(0, 11, "BaseTarifa-1")
				.set_TextMatrix(1, 11, "IvaCero")
				.set_TextMatrix(0, 12, "BaseGrabada-1")
				.set_TextMatrix(1, 12, "IVA")
				.set_TextMatrix(0, 13, "BaseNoGraba-1")
				.set_TextMatrix(1, 13, "IVA")
				.set_TextMatrix(0, 14, "Ret.AIR-1")
				.set_TextMatrix(1, 14, "ValorMonto")
				
				.set_TextMatrix(0, 15, "Ret.AIR-2")
				.set_TextMatrix(1, 15, "Concepto")
				.set_TextMatrix(0, 16, "Ret.AIR-2")
				.set_TextMatrix(1, 16, "porcentaje")
				.set_TextMatrix(0, 17, "BaseTarifa-2")
				.set_TextMatrix(1, 17, "IvaCero")
				.set_TextMatrix(0, 18, "BaseGrabada-2")
				.set_TextMatrix(1, 18, "IVA")
				.set_TextMatrix(0, 19, "BaseNoGraba-2")
				.set_TextMatrix(1, 19, "IVA")
				.set_TextMatrix(0, 20, "Ret.AIR-2")
				.set_TextMatrix(1, 20, "ValorMonto")
				
				
				.set_TextMatrix(0, 21, "Retencion")
				.set_TextMatrix(1, 21, "NroAutorizac")
				.set_TextMatrix(0, 22, "Serie")
				.set_TextMatrix(1, 22, "Estb.")
				.set_TextMatrix(0, 23, "Serie")
				.set_TextMatrix(1, 23, "P.Emis.")
				.set_TextMatrix(0, 24, "Retencion")
				.set_TextMatrix(1, 24, "Número")
				.set_TextMatrix(0, 25, "Retencion")
				.set_TextMatrix(1, 25, "Fecha")
				.Redraw = False
			End If
			' establecer combinación y orden de columna de cuadrícula
			If TipTra = 2 Then
				.set_MergeCol(2, True)
			ElseIf TipTra = 1 Or TipTra = 6 Then 
				For I = 1 To .get_Cols() - 1
					.set_MergeCol(I, True)
				Next I
			End If
			'.Sort = flexSortGenericAscending
			
			' establecer tipo de cuadrícula
			.AllowBigSelection = True
			.FillStyle = MSFlexGridLib.FillStyleSettings.flexFillRepeat
			
			' encabezado en negrita
			.Row = 0
			.Col = 0
			.RowSel = .FixedRows - 1
			.ColSel = .get_Cols() - 1
			.CellFontBold = True
			
			' atenuar otra columna
			For I = .FixedCols To .get_Cols() - 1 Step 2
				.Col = I
				.Row = .FixedRows
				.RowSel = .Rows - 1
				.CellBackColor = System.Drawing.ColorTranslator.FromOle(&HC0C0C0) ' gris claro
			Next I
			
			.AllowBigSelection = False
			.FillStyle = MSFlexGridLib.FillStyleSettings.flexFillSingle
			
			.set_ColWidth(Malla.get_Cols() - 1,  , 0)
			'    ' NUMERAR COLUMNAS
			j = 0
			For I = .FixedRows To .Rows - 1
				j = j + 1
				.set_TextMatrix(I, 0, j)
				'''' chequear la autorizacion solo para importaciones ADCOM
				
				If TipTra = 1 Then
					If .get_TextMatrix(I, 8) > "" And .get_TextMatrix(I, 10) = "" Then
						autoriza = BuscarAutorizacionesSRI(.get_TextMatrix(I, 3), .get_TextMatrix(I, 4), .get_TextMatrix(I, 6), .get_TextMatrix(I, 7), .get_TextMatrix(I, 8), Malla.get_TextMatrix(I, 9), .get_TextMatrix(I, 8))
						.set_TextMatrix(I, 10, autoriza.AutNroAut)
						'UPGRADE_NOTE: El objeto autoriza no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
						autoriza = Nothing
					End If
					If .get_TextMatrix(I, 30) = "" Then
						autoriza = BuscarAutorizacionesSRI((Emp.ruc), "RTP", .get_TextMatrix(I, 27), .get_TextMatrix(I, 28), .get_TextMatrix(I, 29), .get_TextMatrix(I, 31), .get_TextMatrix(I, 29))
						.set_TextMatrix(I, 30, autoriza.AutNroAut)
						'UPGRADE_NOTE: El objeto autoriza no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
						autoriza = Nothing
					End If
					
					.set_TextMatrix(I, 11, VB6.Format(.get_TextMatrix(I, 11), "########0.00"))
					.set_TextMatrix(I, 12, VB6.Format(.get_TextMatrix(I, 12), "########0.00"))
					.set_TextMatrix(I, 13, VB6.Format(.get_TextMatrix(I, 13), "########0.00"))
					.set_TextMatrix(I, 14, VB6.Format(.get_TextMatrix(I, 14), "########0.00"))
					.set_TextMatrix(I, 15, VB6.Format(.get_TextMatrix(I, 15), "########0.00"))
					.set_TextMatrix(I, 16, VB6.Format(.get_TextMatrix(I, 16), "########0.00"))
					.set_TextMatrix(I, 17, VB6.Format(.get_TextMatrix(I, 17), "########0.00"))
					.set_TextMatrix(I, 18, VB6.Format(.get_TextMatrix(I, 18), "########0.00"))
					.set_TextMatrix(I, 20, VB6.Format(.get_TextMatrix(I, 20), "########0.00"))
					.set_TextMatrix(I, 21, VB6.Format(.get_TextMatrix(I, 21), "########0.00"))
					.set_TextMatrix(I, 22, VB6.Format(.get_TextMatrix(I, 22), "########0.00"))
					.set_TextMatrix(I, 24, VB6.Format(.get_TextMatrix(I, 24), "########0.00"))
					.set_TextMatrix(I, 25, VB6.Format(.get_TextMatrix(I, 25), "########0.00"))
					.set_TextMatrix(I, 26, VB6.Format(.get_TextMatrix(I, 26), "########0.00"))
					
					.set_ColAlignment(11, 7)
					.set_ColAlignment(12, 7)
					.set_ColAlignment(13, 7)
					.set_ColAlignment(14, 7)
					.set_ColAlignment(15, 7)
					.set_ColAlignment(16, 7)
					.set_ColAlignment(17, 7)
					.set_ColAlignment(18, 7)
					.set_ColAlignment(20, 7)
					.set_ColAlignment(21, 7)
					.set_ColAlignment(22, 7)
					.set_ColAlignment(24, 7)
					.set_ColAlignment(25, 7)
					.set_ColAlignment(26, 7)
					
					
				ElseIf TipTra = 6 Then 
					
					
					.set_TextMatrix(I, 11, VB6.Format(.get_TextMatrix(I, 11), "########0.00"))
					.set_TextMatrix(I, 12, VB6.Format(.get_TextMatrix(I, 12), "########0.00"))
					.set_TextMatrix(I, 13, VB6.Format(.get_TextMatrix(I, 13), "########0.00"))
					.set_TextMatrix(I, 14, VB6.Format(.get_TextMatrix(I, 14), "########0.00"))
					
					.set_ColAlignment(11, 7)
					.set_ColAlignment(12, 7)
					.set_ColAlignment(13, 7)
					.set_ColAlignment(14, 7)
					
					.set_TextMatrix(I, 17, VB6.Format(.get_TextMatrix(I, 17), "########0.00"))
					.set_TextMatrix(I, 18, VB6.Format(.get_TextMatrix(I, 18), "########0.00"))
					.set_TextMatrix(I, 19, VB6.Format(.get_TextMatrix(I, 19), "########0.00"))
					.set_TextMatrix(I, 20, VB6.Format(.get_TextMatrix(I, 20), "########0.00"))
					
					.set_ColAlignment(17, 7)
					.set_ColAlignment(18, 7)
					.set_ColAlignment(19, 7)
					.set_ColAlignment(20, 7)
					
					
					If Not (.get_TextMatrix(I, 4) > "") Then
						autoriza = BuscarAutorizacionesSRI(Malla.get_TextMatrix(I, 2), Malla.get_TextMatrix(I, 3), Malla.get_TextMatrix(I, 5), Malla.get_TextMatrix(I, 6), Malla.get_TextMatrix(I, 7), Malla.get_TextMatrix(I, 8))
						.set_TextMatrix(I, 4, autoriza.AutNroAut)
					End If
					If .get_TextMatrix(I, 24) > "" And .get_TextMatrix(I, 21) = "" Then
						autoriza = BuscarAutorizacionesSRI((Emp.ruc), "RTP", Malla.get_TextMatrix(I, 22), Malla.get_TextMatrix(I, 23), Malla.get_TextMatrix(I, 24), Malla.get_TextMatrix(I, 25))
						.set_TextMatrix(I, 21, autoriza.AutNroAut)
						'UPGRADE_NOTE: El objeto autoriza no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
						autoriza = Nothing
					End If
					
				ElseIf TipTra = 2 Then 
					
					.set_TextMatrix(I, 6, VB6.Format(.get_TextMatrix(I, 6), "########0.00"))
					.set_TextMatrix(I, 7, VB6.Format(.get_TextMatrix(I, 7), "########0.00"))
					.set_TextMatrix(I, 8, VB6.Format(.get_TextMatrix(I, 8), "########0.00"))
					.set_TextMatrix(I, 9, VB6.Format(.get_TextMatrix(I, 9), "########0.00"))
					.set_TextMatrix(I, 10, VB6.Format(.get_TextMatrix(I, 10), "########0.00"))
					
					.set_ColAlignment(5, 7)
					.set_ColAlignment(6, 7)
					.set_ColAlignment(7, 7)
					.set_ColAlignment(8, 7)
					.set_ColAlignment(9, 7)
					.set_ColAlignment(10, 7)
					
				End If
				
				For L = 1 To Malla.get_Cols() - 1
					If IsDate(.get_TextMatrix(I, L)) Then
						If CDate(.get_TextMatrix(I, L)) <= CDate("1899-12-30") Then .set_TextMatrix(I, L, "")
					End If
				Next L
			Next 
			
			.Redraw = True
			
		End With
		'SELECT Ventas.Cl_CodigoCliente, Ventas.Cl_TipoComprobante, Ventas.CL_NroSerieEstablec, Ventas.CL_NroSeriePtoEmision, Ventas.CL_NroSecuencial, Ventas.CL_FechaComprobante, Ventas.CL_FechaRegContable, Ventas.CL_NroDeComprobantes, Ventas.CL_BaseImpTarCero, Ventas.CL_BaseImpGravadaIva, Ventas.CL_CodigoPorcIva, Ventas.CL_IvaPresuntivo, Ventas.CL_BaseImpICE, Ventas.CL_CodigoPorcICE, Ventas.CL_MontoIvaBienes, Ventas.CL_CodPorcRetIvaBienes, Ventas.CL_MontoRetIvaBienes, Ventas.CL_CodPorRetIvaServicios, Ventas.CL_RetencionPresuntiva1, Ventas.CL_CodRetFteImpRenta1, Ventas.CL_BaseImponibleIR1, Ventas.CL_RetencionPresuntiva2, Ventas.CL_CodRetFteImpRenta2, Ventas.CL_BaseImponibleIR2
		'FROM Ventas;
		
	End Sub
	
	Public Function EspecialesCompras(ByRef KeyCode As Short, ByRef Fila As Short, ByRef Columna As Short, ByRef Malla As AxMSHierarchicalFlexGridLib.AxMSHFlexGrid) As String
		Dim BuscaRetencionAIR As Object
		Dim PerPeriodo As Object
		Dim BuscaClien As Object
		Dim BuscaTipoId As Object
		Dim BuscaSustento As Object
		Dim ccol, Rrow As Short
		Dim Aux As String
		Dim QUENOMBRE, QUECODIGO, Campo As String
		Dim QUEVALOR As Double
		Dim HastaFecha As Date
		Dim Alx As New Directorio
		Dim autoriza As New AutorizacionSri
		ccol = Columna
		Rrow = Fila
		Campo = Malla.Text
		
		Select Case KeyCode
			Case System.Windows.Forms.Keys.F2 'buscavalores
				Select Case ccol
					Case 1
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto BuscaSustento.busca. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						BuscaSustento.busca(QUECODIGO, QUENOMBRE)
						'UPGRADE_NOTE: El objeto BuscaSustento no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
						BuscaSustento = Nothing
						Campo = QUECODIGO
					Case 2
						'                Set Alx = New Directorio
						'                Aux = BuscaClien.IniBuscaCliOPro("C", "")
						'                If Aux = "" Then Aux = Malla.TextMatrix(Rrow, 3)
						Alx.CargarAlex(Malla.get_TextMatrix(Rrow, 3), True)
						Malla.set_TextMatrix(Rrow, 3, Alx.CiRuc)
						Campo = CorrijeTipoId((Alx.TipoId))
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto BuscaTipoId.BuscaDoc. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						BuscaTipoId.BuscaDoc(1, QUECODIGO, QUENOMBRE)
						Campo = QUECODIGO
					Case 3
						Alx = New Directorio
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto BuscaClien.IniBuscaCliOPro. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Aux = BuscaClien.IniBuscaCliOPro("C", "")
						If Aux = "" Then Aux = Campo
						Alx.CargarAlex(Aux, True)
						Campo = Alx.CiRuc
						Malla.set_TextMatrix(Rrow, 2, CorrijeTipoId((Alx.TipoId)))
					Case 4
						Alx.CargarAlex(Malla.get_TextMatrix(Rrow, 4), True, "S")
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto PerPeriodo. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						BuscDocSri.BuscaDoc(PerPeriodo, 1, Val(Malla.get_TextMatrix(Rrow, 1)), CorrijeTipoId(Malla.get_TextMatrix(Rrow, 2)), QUECODIGO, QUENOMBRE)
						Campo = QUECODIGO
					Case 27, 28, 33, 34, 6, 7
						Campo = "001"
					Case 5, 9, 31
						Campo = CStr(QueFecha)
					Case 10
						'Set Alx = New Directorio
						'Alx.CargarAlex Malla.TextMatrix(Rrow, 3), True, "S"
						autoriza = BuscarAutorizacionesSRI(Malla.get_TextMatrix(Rrow, 3), Malla.get_TextMatrix(Rrow, 4), Malla.get_TextMatrix(Rrow, 6), Malla.get_TextMatrix(Rrow, 7), Malla.get_TextMatrix(Rrow, 8), Malla.get_TextMatrix(Rrow, 9))
						Campo = autoriza.AutNroAut
						'UPGRADE_NOTE: El objeto autoriza no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
						autoriza = Nothing
					Case 30
						Alx = New Directorio
						Alx.CargarAlex(Malla.get_TextMatrix(Rrow, 3), True, "S")
						autoriza = BuscarAutorizacionesSRI((Emp.ruc), "RTP", Malla.get_TextMatrix(Rrow, 27), Malla.get_TextMatrix(Rrow, 28), Malla.get_TextMatrix(Rrow, 29), Malla.get_TextMatrix(Rrow, 31))
						Campo = autoriza.AutNroAut
						'UPGRADE_NOTE: El objeto autoriza no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
						autoriza = Nothing
						'            Case 36
						'                Set Alx = New Directorio
						'                Alx.CargarAlex Malla.TextMatrix(Rrow, 3), True, "S"
						'                 Set autoriza = BuscarAutorizacionesSRI(Emp.ruc, "RTP", Malla.TextMatrix(Rrow, 27), Malla.TextMatrix(Rrow, 28), Malla.TextMatrix(Rrow, 29), Malla.TextMatrix(Rrow, 31))
						'                Campo = autoriza.AutNroAut
						'                Set autoriza = Nothing
					Case 19
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto BuscaRetencionAIR.busca. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						BuscaRetencionAIR.busca(QUECODIGO, QUENOMBRE, QUEVALOR)
						Campo = QUECODIGO
						Malla.set_TextMatrix(Rrow, 21, Val(CStr(QUEVALOR)))
						Malla.set_TextMatrix(Rrow, 22, roundd(Val(CStr(QUEVALOR)) * Val(Malla.get_TextMatrix(Rrow, 20)) / 100, 2))
					Case 23
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto BuscaRetencionAIR.busca. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						BuscaRetencionAIR.busca(QUECODIGO, QUENOMBRE, QUEVALOR)
						Campo = QUECODIGO
						Malla.set_TextMatrix(Rrow, 25, Val(CStr(QUEVALOR)))
						Malla.set_TextMatrix(Rrow, 26, roundd(Val(CStr(QUEVALOR)) * CorrijeNuloN(Malla.get_TextMatrix(Rrow, 24)) / 100, 2))
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
	Public Function EspecialesVentas(ByRef KeyCode As Short, ByRef Fila As Short, ByRef Columna As Short, ByRef Malla As AxMSHierarchicalFlexGridLib.AxMSHFlexGrid) As String
		Dim PerPeriodo As Object
		Dim BuscaClien As Object
		Dim BuscaTipoId As Object
		Dim ccol, Rrow As Short
		Dim Aux As String
		Dim QUENOMBRE, QUECODIGO, Campo As String
		Dim QUEVALOR As Double
		Dim HastaFecha As Date
		Dim Alx As New Directorio
		
		ccol = Columna
		Rrow = Fila
		Campo = Malla.Text
		
		Select Case KeyCode
			Case System.Windows.Forms.Keys.F2 'buscavalores
				Select Case ccol
					Case 1
						'                Set Alx = New Directorio
						'                Aux = BuscaClien.IniBuscaCliOPro("C", "")
						'                Alx.CargarAlex Aux, True
						'                Malla.TextMatrix(rrow, 2) = Alx.CiRuc
						'                Campo = CorrijeTipoId(Alx.TipoId)
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto BuscaTipoId.BuscaDoc. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						BuscaTipoId.BuscaDoc(2, QUECODIGO, QUENOMBRE)
						Campo = QUECODIGO
					Case 2
						Alx = New Directorio
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto BuscaClien.IniBuscaCliOPro. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Aux = BuscaClien.IniBuscaCliOPro("C", "")
						Alx.CargarAlex(Aux, True)
						Campo = Alx.CiRuc
						Malla.set_TextMatrix(Rrow, 1, CorrijeTipoId((Alx.TipoId)))
					Case 3
						Alx.CargarAlex(Malla.get_TextMatrix(Rrow, 2), True, "S")
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto PerPeriodo. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						BuscDocSri.BuscaDoc(PerPeriodo, 2, 0, CorrijeTipoId((Alx.TipoId)), QUECODIGO, QUENOMBRE)
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
						'                Campo = roundd(CargarIva(CorrijeNuloN(Malla.TextMatrix(Rrow, 10))) * Val(Malla.TextMatrix(Rrow, 9)) / 100, 2)
						'            Case 13
						'                BuscaIce.BuscaDoc Str(PerPeriodo), QUECODIGO, QueNombre, QUEVALOR
						'                Campo = QUECODIGO
						'                Malla.TextMatrix(Rrow, 14) = roundd(QUEVALOR * Val(Malla.TextMatrix(Rrow, 12)) / 100, 2)
						'            Case 14
						'                Campo = roundd(CargarIce(Malla.TextMatrix(Rrow, 13)) * Val(Malla.TextMatrix(Rrow, 12)) / 100, 2)
						'            Case 15
						'                Campo = Malla.TextMatrix(Rrow, 11)
						'                Malla.TextMatrix(Rrow, 18) = 0
						'            Case 16
						'                BuscaRetIvaBienes.BuscaRet PerPeriodo, QUECODIGO, QueNombre, QUEVALOR
						'                Campo = QUECODIGO
						'                Malla.TextMatrix(Rrow, 17) = roundd(QUEVALOR * Val(Malla.TextMatrix(Rrow, 15)) / 100, 2)
						'            Case 18
						'                Campo = Val(Malla.TextMatrix(Rrow, 11)) - Val(Malla.TextMatrix(Rrow, 15))
						'            Case 19
						'                BuscaRetIvaServicios.BuscaRet PerPeriodo, QUECODIGO, QueNombre, QUEVALOR
						'                Campo = QUECODIGO
						'                Malla.TextMatrix(Rrow, 20) = roundd(QUEVALOR * Val(Malla.TextMatrix(Rrow, 18)) / 100, 2)
						'            Case 22
						'                BuscaRetencionAIR.Busca QUECODIGO, QueNombre, QUEVALOR
						'                Campo = QUECODIGO
						'                Malla.TextMatrix(Rrow, 24) = Val(QUEVALOR)
						'                Malla.TextMatrix(Rrow, 25) = roundd(Val(QUEVALOR) * Val(Malla.TextMatrix(Rrow, 23)) / 100, 2)
						'            Case 26
						'                BuscaRetencionAIR.Busca QUECODIGO, QueNombre, QUEVALOR
						'                Campo = QUECODIGO
						'                Malla.TextMatrix(Rrow, 28) = Val(QUEVALOR)
						'                Malla.TextMatrix(Rrow, 29) = roundd(Val(QUEVALOR) * Val(Malla.TextMatrix(Rrow, 27)) / 100, 2)
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
	
	Public Function EspecialesImportaciones(ByRef KeyCode As Short, ByRef Fila As Short, ByRef Columna As Short, ByRef Malla As AxMSHierarchicalFlexGridLib.AxMSHFlexGrid) As String
		Dim BuscaRetencionAIR As Object
		Dim BuscaIce As Object
		Dim BuscaIVA As Object
		Dim BuscaClien As Object
		Dim buscadistritoaduanero As Object
		Dim PerPeriodo As Object
		Dim BuscaTipoImportacion As Object
		Dim BuscaSustento As Object
		Dim ccol, Rrow As Short
		Dim Aux As String
		Dim QUENOMBRE, QUECODIGO, Campo As String
		Dim QUEVALOR As Double
		Dim HastaFecha As Date
		Dim Alx As New Directorio
		
		ccol = Columna
		Rrow = Fila
		Campo = Malla.Text
		
		Select Case KeyCode
			Case System.Windows.Forms.Keys.F2 'buscavalores
				Select Case ccol
					Case 1
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto BuscaSustento.busca. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						BuscaSustento.busca(QUECODIGO, QUENOMBRE)
						'UPGRADE_NOTE: El objeto BuscaSustento no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
						BuscaSustento = Nothing
						Campo = QUECODIGO
					Case 2
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto BuscaTipoImportacion.BuscaDoc. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						BuscaTipoImportacion.BuscaDoc(PerPeriodo, QUECODIGO, QUENOMBRE, QUEVALOR)
						'UPGRADE_NOTE: El objeto BuscaTipoImportacion no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
						BuscaTipoImportacion = Nothing
						Campo = QUECODIGO
					Case 3
						Campo = CStr(QueFecha)
					Case 4
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto PerPeriodo. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						BuscDocSri.BuscaDoc(PerPeriodo, 3, CShort(Malla.get_TextMatrix(Rrow, 1)), "", QUECODIGO, QUENOMBRE)
						Campo = QUECODIGO
					Case 5
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto buscadistritoaduanero.BuscaDoc. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						buscadistritoaduanero.BuscaDoc("", QUECODIGO, QUENOMBRE)
						Campo = QUECODIGO
					Case 10
						Alx = New Directorio
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto BuscaClien.IniBuscaCliOPro. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Aux = BuscaClien.IniBuscaCliOPro("P", "")
						Alx.CargarAlex(Aux, True)
						Campo = Alx.CiRuc
						Malla.set_TextMatrix(Rrow, 12, Alx.NombreImpresion)
						Malla.set_TextMatrix(Rrow, 13, Alx.TipoPersona)
					Case 11
						Alx = New Directorio
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto BuscaClien.IniBuscaCliOPro. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Aux = BuscaClien.IniBuscaCliOPro("P", "")
						Alx.CargarAlex(Aux, True)
						Campo = Alx.NombreImpresion
						Malla.set_TextMatrix(Rrow, 12, Alx.CiRuc)
						Malla.set_TextMatrix(Rrow, 13, Alx.TipoPersona)
					Case 16
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto PerPeriodo. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto BuscaIVA.BuscaDoc. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						BuscaIVA.BuscaDoc(Str(PerPeriodo), QUECODIGO, QUENOMBRE, QUEVALOR)
						Campo = QUECODIGO
					Case 17
						Campo = CStr(roundd(CargarIva(CShort(Malla.get_TextMatrix(Rrow, 16))) * Val(Malla.get_TextMatrix(Rrow, 15)) / 100, 2))
					Case 19
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto PerPeriodo. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto BuscaIce.BuscaDoc. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						BuscaIce.BuscaDoc(Str(PerPeriodo), QUECODIGO, QUENOMBRE, QUEVALOR)
						Campo = QUECODIGO
						Malla.set_TextMatrix(Rrow, 20, roundd(QUEVALOR * Val(Malla.get_TextMatrix(Rrow, 18)) / 100, 2))
					Case 20
						Campo = CStr(roundd(CargarIce(CShort(Malla.get_TextMatrix(Rrow, 19))) * Val(Malla.get_TextMatrix(Rrow, 18)) / 100, 2))
					Case 21
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto BuscaRetencionAIR.busca. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						BuscaRetencionAIR.busca(QUECODIGO, QUENOMBRE, QUEVALOR)
						Campo = QUECODIGO
						Malla.set_TextMatrix(Rrow, 23, Val(CStr(QUEVALOR)))
						Malla.set_TextMatrix(Rrow, 24, roundd(Val(CStr(QUEVALOR)) * Val(Malla.get_TextMatrix(Rrow, 22)) / 100, 2))
					Case 23
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto BuscaRetencionAIR.busca. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						BuscaRetencionAIR.busca(QUECODIGO, QUENOMBRE, QUEVALOR)
						Campo = CStr(QUEVALOR)
						Malla.set_TextMatrix(Rrow, 21, Val(QUECODIGO))
						Malla.set_TextMatrix(Rrow, 24, roundd(Val(CStr(QUEVALOR)) * Val(Malla.get_TextMatrix(Rrow, 22)) / 100, 2))
				End Select
		End Select
		EspecialesImportaciones = Campo
	End Function
	
	Public Function EspecialesReoc(ByRef KeyCode As Short, ByRef Fila As Short, ByRef Columna As Short, ByRef Malla As AxMSHierarchicalFlexGridLib.AxMSHFlexGrid) As String
		Dim PerPeriodo As Object
		Dim BuscaClien As Object
		Dim BuscaTipoId As Object
		Dim ccol, Rrow As Short
		Dim Aux As String
		Dim QUENOMBRE, QUECODIGO, Campo As String
		Dim QUEVALOR As Double
		Dim HastaFecha As Date
		Dim Alx As New Directorio
		Dim autoriza As New AutorizacionSri
		ccol = Columna
		Rrow = Fila
		Campo = Malla.Text
		
		Select Case KeyCode
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
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto BuscaTipoId.BuscaDoc. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						BuscaTipoId.BuscaDoc(1, QUECODIGO, QUENOMBRE)
						Campo = QUECODIGO
					Case 2
						Alx = New Directorio
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto BuscaClien.IniBuscaCliOPro. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Aux = BuscaClien.IniBuscaCliOPro("C", "")
						If Aux = "" Then Aux = Campo
						Alx.CargarAlex(Aux, True)
						Campo = Alx.CiRuc
						'                Malla.TextMatrix(Rrow, 2) = CorrijeTipoId(Alx.TipoId)
					Case 3
						Alx.CargarAlex(Malla.get_TextMatrix(Rrow, 2), True, "S")
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto PerPeriodo. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						BuscDocSri.BuscaDoc(PerPeriodo, 1, 1, CorrijeTipoId((Alx.TipoId)), QUECODIGO, QUENOMBRE)
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
						'                Campo = roundd(CargarIva(Malla.TextMatrix(Rrow, 15)) * Val(Malla.TextMatrix(Rrow, 14)) / 100, 2)
						'            Case 18
						'                BuscaIce.BuscaDoc Str(PerPeriodo), QUECODIGO, QUENOMBRE, QUEVALOR
						'                Campo = QUECODIGO
						'                Malla.TextMatrix(Rrow, 19) = roundd(QUEVALOR * CorrijeNuloN(Malla.TextMatrix(Rrow, 17)) / 100, 2)
						'            Case 19
						'                Campo = roundd(CargarIce(CorrijeNuloN(Malla.TextMatrix(Rrow, 18))) * CorrijeNuloN(Malla.TextMatrix(Rrow, 17)) / 100, 2)
						'            Case 20
						'                Campo = Malla.TextMatrix(Rrow, 16)
						'                Malla.TextMatrix(Rrow, 23) = 0
						'            Case 23
						'                Campo = Val(Malla.TextMatrix(Rrow, 16)) - Val(Malla.TextMatrix(Rrow, 20))
						'            Case 21
						'                BuscaRetIvaBienes.BuscaRet PerPeriodo, QUECODIGO, QUENOMBRE, QUEVALOR
						'                Campo = QUECODIGO
						'                Malla.TextMatrix(Rrow, 22) = roundd(QUEVALOR * Malla.TextMatrix(Rrow, 20) / 100, 2)
						'            Case 24
						'                BuscaRetIvaServicios.BuscaRet PerPeriodo, QUECODIGO, QUENOMBRE, QUEVALOR
						'                Campo = QUECODIGO
						'                Malla.TextMatrix(Rrow, 25) = roundd(QUEVALOR * Malla.TextMatrix(Rrow, 23) / 100, 2)
						'            Case 26
						'                BuscaRetencionAIR.Busca QUECODIGO, QUENOMBRE, QUEVALOR
						'                Campo = QUECODIGO
						'                Malla.TextMatrix(Rrow, 28) = Val(QUEVALOR)
						'                Malla.TextMatrix(Rrow, 29) = roundd(Val(QUEVALOR) * Val(Malla.TextMatrix(Rrow, 27)) / 100, 2)
						'            Case 30
						'                BuscaRetencionAIR.Busca QUECODIGO, QUENOMBRE, QUEVALOR
						'                Campo = QUECODIGO
						'                Malla.TextMatrix(Rrow, 32) = Val(QUEVALOR)
						'                Malla.TextMatrix(Rrow, 33) = roundd(Val(QUEVALOR) * CorrijeNuloN(Malla.TextMatrix(Rrow, 31)) / 100, 2)
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