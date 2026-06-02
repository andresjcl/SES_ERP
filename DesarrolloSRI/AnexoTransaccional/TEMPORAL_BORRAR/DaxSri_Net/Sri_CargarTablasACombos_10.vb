Option Strict Off
Option Explicit On
Module Sri_CargarTablasACombos
	Dim dxlib As New DaxLib.DaxLibDigDato
	
	Public Function CargarSecuencial_transaccion(ByRef TIPID As String, ByRef TipoMov As String) As String
		Dim rs As New ADODB.Recordset
		Dim ssql As String
		ssql = "select Código from TipoIdentificacion where tipoTransaccion = '" & TipoMov & "' and códigoIdentificacion = '" & TIPID & "'"
		ssql = ssql & " order by cast(Código as numeric(6,0))"
		Debug.Print(ssql)
		CargarSecuencial_transaccion = "0"
		rs = CargarDatos(ssql, ConxSri)
		If rs.EOF = False Then CargarSecuencial_transaccion = Right("00" & rs.Fields("código").Value, 2)
		rs.Close()
		'UPGRADE_NOTE: El objeto rs no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rs = Nothing
	End Function
	
	Public Sub CargarSustento(ByRef DatSustento As System.Windows.Forms.Control, ByRef TipDoc As String)
		Dim Det As String
		Dim ind As String
		Dim fecha As Date
		fecha = Now
		Dim rs As New ADODB.Recordset
		Dim ssql As String
		ssql = "select Código,Descripción,tipoComprobante,isnull(FechaInicio,'01/01/1900') as FechaInicio,isnull(FechaFin,'31/12/2999') as FechaFin"
		ssql = ssql & " from SustentoComprobante"
		ssql = ssql & " where isnull(FechaInicio,'01/01/1900') <= '" & fecha & "' and isnull(FechaFin,'31/12/2999') >= '" & fecha & "'"
		If Val(TipDoc) > 0 Then ssql = ssql & " and patindex('%" & Val(TipDoc) & "%',tipoComprobante) > 0 "
		
		rs = CargarDatos(ssql, ConxSri)
		Do Until rs.EOF
			Det = rs.Fields("Descripción").Value
			ind = Right("00" & rs.Fields("código").Value, 2)
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto DatSustento.AddItem. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DatSustento.AddItem(ind & " - " & Det, ind)
			rs.MoveNext()
		Loop 
		rs.Close()
		'UPGRADE_NOTE: El objeto rs no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rs = Nothing
		
		
	End Sub
	
	Public Sub CargarTiposDocumento(ByRef CodSecuencialTransaccion As String, ByRef CmbTipoComp As System.Windows.Forms.Control)
		Dim Det As String
		Dim ind As String
		Dim rs As New ADODB.Recordset
		Dim ssql As String
		ssql = "select Código,Descripción,isnull(FechaFin,'31/12/2999') as FechaFin"
		ssql = ssql & " from ComprobantesAutorizados"
		If CodSecuencialTransaccion > "" Then ssql = ssql & " where patindex('%" & Val(CodSecuencialTransaccion) & "%',SecuencialTransaccion) > 0 "
		On Error Resume Next
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CmbTipoComp.Iniciar. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		CmbTipoComp.Iniciar(False)
		rs = CargarDatos(ssql, ConxSri)
		Do Until rs.EOF
			Det = rs.Fields("Descripción").Value
			ind = Right("00" & rs.Fields("código").Value, 2)
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CmbTipoComp.AddItem. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CmbTipoComp.AddItem(ind & " - " & Det, ind)
			rs.MoveNext()
		Loop 
		rs.Close()
		'UPGRADE_NOTE: El objeto rs no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rs = Nothing
	End Sub
	
	Public Sub CargarConceptosRetencion(ByRef FechaDoc As Date, ByRef CmbConcReten As System.Windows.Forms.Control, ByRef transac As String)
		Dim Det As String
		Dim ind As String
		'UPGRADE_NOTE: val se actualizó a val_Renamed. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim val_Renamed As String
		Dim fechini As String
		Dim fechfin As String
		Dim valido As Boolean
		Dim rs As New ADODB.Recordset
		rs = CargarDatos("select * from ConceptosRetencion", ConxSri)
		On Error Resume Next
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CmbConcReten.Iniciar. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		CmbConcReten.Iniciar(False)
		Do Until rs.EOF
			ind = rs.Fields("código").Value
			Det = rs.Fields("Descripción").Value
			val_Renamed = CStr(dxlib.CorrijeNuloN(rs.Fields("Porcentaje")))
			fechini = rs.Fields("fechainicio").Value
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dxlib.CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			fechfin = dxlib.CorrijeNulo(rs.Fields("FechaFin"))
			If Trim(fechfin) = "" Then fechfin = "31/12/9999"
			If Trim(fechini) = "" Then fechini = "01/01/1900"
			If FechaDoc >= CDate(fechini) And FechaDoc <= CDate(fechfin) Then
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CmbConcReten.AddItem. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CmbConcReten.AddItem(ind & " - " & Det, ind, val_Renamed)
			End If
			rs.MoveNext()
		Loop 
		
	End Sub
	Public Sub CargarTiposDeIvaRetenciones(ByRef CmbTipRet As System.Windows.Forms.Control)
		Dim rs As New ADODB.Recordset
		rs.Open("SElect codigo, codigo + ' - ' + descripcion as detalle  From SriTiposDeIvaEnRetenciones order by Codigo ", ConxSysemp, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		If rs.State = 0 Then Exit Sub
		Do Until rs.EOF
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CmbTipRet.AddItem. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CmbTipRet.AddItem(rs.Fields("Detalle"), rs.Fields("codigo"))
			rs.MoveNext()
		Loop 
	End Sub
	Public Sub CargarRetencionIvaBienes(ByRef FechaDoc As Date, ByRef CmbRetIvaBien As System.Windows.Forms.Control, ByRef CmbDetIvaBien As System.Windows.Forms.Control)
		Dim Det As String
		Dim ind As String
		Dim fechini As String
		Dim fechfin As String
		Dim rs As New ADODB.Recordset
		rs = CargarDatos("select * from retencionIvaBienes", ConxSri)
		Do Until rs.EOF
			ind = rs.Fields("código").Value
			Det = rs.Fields("Descripción").Value
			fechini = rs.Fields("fechainicio").Value
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dxlib.CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			fechfin = dxlib.CorrijeNulo(rs.Fields("FechaFin"))
			If Trim(fechfin) = "" Then fechfin = "31/12/9999"
			If Trim(fechini) = "" Then fechini = "01/01/1900"
			If FechaDoc >= CDate(fechini) And FechaDoc <= CDate(fechfin) Then
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CmbRetIvaBien.AddItem. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CmbRetIvaBien.AddItem(Det, ind)
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CmbDetIvaBien.AddItem. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CmbDetIvaBien.AddItem(ind & " - Retención iva bienes", ind, Det)
			End If
			rs.MoveNext()
		Loop 
		
	End Sub
	
	Public Sub CargarRetencionIvaServicios(ByRef FechaDoc As Date, ByRef CmbRetIvaServ As System.Windows.Forms.Control, ByRef CmbDetIvaServ As System.Windows.Forms.Control)
		Dim Det As String
		Dim ind As String
		Dim fechini As String
		Dim fechfin As String
		Dim rs As New ADODB.Recordset
		rs = CargarDatos("select * from retencionIvaServicios", ConxSri)
		Do Until rs.EOF
			ind = rs.Fields("código").Value
			Det = rs.Fields("Descripción").Value
			fechini = rs.Fields("fechainicio").Value
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dxlib.CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			fechfin = dxlib.CorrijeNulo(rs.Fields("FechaFin"))
			If Trim(fechfin) = "" Then fechfin = "31/12/9999"
			If Trim(fechini) = "" Then fechini = "01/01/1900"
			If FechaDoc >= CDate(fechini) And FechaDoc <= CDate(fechfin) Then
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CmbRetIvaServ.AddItem. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CmbRetIvaServ.AddItem(Det, ind)
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CmbDetIvaServ.AddItem. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CmbDetIvaServ.AddItem(ind & " - Retención iva servicios", ind, Det)
			End If
			rs.MoveNext()
		Loop 
	End Sub
	
	Public Function CargarDatos(ByRef ssql As String, ByRef Conexion As ADODB.Connection) As ADODB.Recordset
		Dim Sw As Boolean
		'Dim SrRec As New ADODB.Recordset
		Dim codi As Short
		CargarDatos = New ADODB.Recordset
		CargarDatos.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		Debug.Print(ssql)
		CargarDatos.Open(ssql, Conexion, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
	End Function
End Module