Option Strict Off
Option Explicit On
Module CuentasPorCobrar
	
	'version definitiva 26/03/2014  grabar tambien como CuentasPorCobrar_10
	
	Dim libfec As New DaxLib.DaxLibBases
	Dim libdat As New DaxLib.DaxLibDigDato
	
	Public Sub LlenarMallaPagos(ByVal DocSuc As String, ByVal DocTip As String, ByVal DocNum As Double, ByRef malla As AxMSFlexGridLib.AxMSFlexGrid, ByVal FechaFin As String)
		
		Dim rstemp As New ADODB.Recordset
		Dim RsTemp2 As New ADODB.Recordset
		Dim cod As String
		Dim I As Short : I = 0
		Dim j As Short : j = 0
		'UPGRADE_NOTE: Cuota se actualizó a Cuota_Renamed. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim Cuota_Renamed As Double
		cod = "SELECT * FROM AdcCuotas WHERE Cuo_DocSuc='" & DocSuc & "' AND" & " Cuo_DocTipo='" & DocTip & "' AND Cuo_DocNumero=" & DocNum & " ORDER BY Cuo_FechaVence"
		
		rstemp.Open(cod, ConxAdcom, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
		
		If rstemp.EOF Then GoTo salida
		
		cod = "SELECT * FROM AdcApl WHERE (Apl_DocApli = '" & DocTip & "' AND " & " Apl_SucApli = '" & DocSuc & "' AND Apl_NumApli =" & DocNum & " ) or " & "(opc_Documento = '" & DocTip & "' AND " & " doc_Sucursal = '" & DocSuc & "' AND doc_Numero =" & DocNum & " )" & " and Apl_fecha <=" & libfec.ArmFormatoFecha(FechaFin) & " ORDER BY Apl_Fecha"
		
		RsTemp2.Open(cod, ConxAdcom, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
		
		With malla
			Do While Not rstemp.EOF
				.Rows = I + 1
				.set_TextMatrix(I, 0, rstemp.Fields("cuo_Numero").Value)
				.set_TextMatrix(I, 1, rstemp.Fields("cuo_Valor").Value)
				.set_TextMatrix(I, 2, rstemp.Fields("Cuo_FechaVence").Value)
				.set_TextMatrix(I, 3, 0)
				.set_TextMatrix(I, 4, "NO ABONADO")
				.set_TextMatrix(I, 5, rstemp.Fields("cuo_Valor").Value)
				.set_TextMatrix(I, 6, "--")
				rstemp.MoveNext()
				I = I + 1
			Loop 
			I = 0
			
			Do While Not RsTemp2.EOF
				Cuota_Renamed = RsTemp2.Fields("Apl_valorapl").Value
				For I = 0 To .Rows - 1
					If CDbl(.get_TextMatrix(I, 5)) <> 0 Then
						.set_TextMatrix(I, 4, RsTemp2.Fields("Apl_fecha").Value)
						.set_TextMatrix(I, 6, System.Date.FromOADate(CDate(RsTemp2.Fields("Apl_fecha").Value).ToOADate - CDate(.get_TextMatrix(I, 2)).ToOADate))
						.set_TextMatrix(I, 3, CDbl(.get_TextMatrix(I, 3)) + Cuota_Renamed)
						If CDbl(.get_TextMatrix(I, 3)) <= CDbl(.get_TextMatrix(I, 1)) Then
							.set_TextMatrix(I, 4, RsTemp2.Fields("Apl_fecha").Value)
							.set_TextMatrix(I, 6, System.Date.FromOADate(CDate(RsTemp2.Fields("Apl_fecha").Value).ToOADate - CDate(.get_TextMatrix(I, 2)).ToOADate))
							.set_TextMatrix(I, 5, (CDbl(.get_TextMatrix(I, 3)) - CDbl(.get_TextMatrix(I, 1))) * -1)
							I = .Rows + 1
						Else
							Cuota_Renamed = CDbl(.get_TextMatrix(I, 3)) - CDbl(.get_TextMatrix(I, 1))
							.set_TextMatrix(I, 3, CDbl(.get_TextMatrix(I, 1)))
							.set_TextMatrix(I, 5, (CDbl(.get_TextMatrix(I, 3)) - CDbl(.get_TextMatrix(I, 1))) * -1)
						End If
					End If
					
				Next I
				RsTemp2.MoveNext()
			Loop 
		End With
		
salida: 
		If rstemp.State = 1 Then rstemp.Close()
		If RsTemp2.State = 1 Then RsTemp2.Close()
		'UPGRADE_NOTE: El objeto rstemp no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rstemp = Nothing
		'UPGRADE_NOTE: El objeto RsTemp2 no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		RsTemp2 = Nothing
	End Sub
	
	'Public Function AbonoYVencimiento(ByVal DocSuc As String, ByVal DocTip As String, ByVal DocNum As Double, ByRef FechaVen As String, ByRef ValorVen As double, ByVal FechaFin As String, ByVal ValorDoc As Double, ByVal FechaDoc As String, Optional ByRef Abonos As Double) As double
	'
	'    Dim rstemp As New adodb.Recordset
	'    Dim RsTemp2 As New adodb.Recordset
	'    Dim cod As String
	'    Dim i As Integer: i = 0
	'    Dim J As Integer: J = 0
	'    Dim Cuota As double, Valor As Double
	''    Dim textmatrix(0 To 2000, 3) As double, textdate(0 To 2000) As Date
	'    Dim TotalAbonado As double
	'
	'    TotalAbonado = 0
	'    If IsMissing(Abonos) Then TotalAbonado = AbonosDocumento(DocSuc, DocTip, DocNum, "", FechaFin) Else TotalAbonado = Abonos
	'    ValorVen = ValorDoc - TotalAbonado
	'    If ValorVen = 0 Then FechaVen = "": Exit Function
	'
	'    cod = "SELECT * FROM AdcCuotas WHERE Cuo_DocSuc='" & DocSuc & "' AND" & _
	''    " Cuo_DocTipo='" & DocTip & "' AND Cuo_DocNumero=" & DocNum & _
	''    " and cuo_fechavence <= " & libfec.ArmFormatoFecha(FechaFin) & _
	''    " ORDER BY Cuo_FechaVence"
	'
	'    rstemp.Open cod, ConxAdcom, adOpenForwardOnly, adLockReadOnly
	'
	'If rstemp.EOF Then FechaVen = FechaDoc: Exit Function
	'
	'Valor = TotalAbonado
	'ValorVen = 0
	'FechaVen = ""
	'With rstemp
	''a = .RecordCount
	'    Do While Not .EOF
	'        Cuota = libdat.CorrijeNuloN(!cuo_Valor)
	'        If Valor >= Cuota Then
	'            Valor = Valor - Cuota
	'        Else
	'            If FechaVen = "" Then FechaVen = !Cuo_FechaVence
	'            ValorVen = ValorVen + Cuota - Valor: Valor = 0
	'        End If
	'        If Valor = 0 Then Exit Do
	'        .MoveNext
	'    Loop
	'    End With
	'
	'Salida:
	'rstemp.Close
	''RsTemp2.Close
	'Set rstemp = Nothing
	'Set RsTemp2 = Nothing
	'AbonoYVencimiento = round(TotalAbonado, Emp.NumeroDigitos)
	'End Function
	
	Public Function AbonosDocumento(ByVal DocSuc As String, ByVal DocTip As String, ByVal DocNum As Double, ByVal FechaIni As String, ByVal FechaFin As String, Optional ByRef ConGar As Boolean = False) As Double
		Dim SaldoMov As Double
		Dim Garantias As String
		Dim RsCxC2 As New ADODB.Recordset
		Dim inicial As String
		Dim cod As String
		inicial = ""
		Garantias = ""
		SaldoMov = 0
		If ConGar <> True Then ConGar = False
		If FechaIni > "" And IsDate(FechaIni) Then inicial = " and Apl_fecha >=" & libfec.ArmFormatoFecha(FechaIni)
		If FechaFin = "" Then FechaFin = CStr(Today)
		If ConGar = False Then Garantias = " AND ( Apl_numgar = 0 or apl_numgar is null ) "
		cod = " SELECT sum(Apl_ValorApl) as Abono " & " FROM adcdocabonos2 " & " WHERE Apl_SucApli = '" & DocSuc & "' AND Apl_DocApli ='" & DocTip & "'  " & " AND idclavedocapl = " & DocNum & inicial & "   AND Apl_fecha <=" & libfec.ArmFormatoFecha(FechaFin) & " " & Garantias & " Group by  Apl_SucApli, Apl_DocApli, idclavedocapl "
		
		With RsCxC2
			
			If .State = 1 Then .Close()
			.Open(cod, ConxAdcom, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
			If Not .EOF Then SaldoMov = .Fields("abono").Value
			
		End With
		
		If RsCxC2.State = 1 Then RsCxC2.Close()
		cod = "select doc_valorabon from adcdoc where doc_sucursal = '" & DocSuc & "' and opc_documento = '" & DocTip & "' and idclavedoc = " & DocNum
		RsCxC2.Open(cod, ConxAdcom, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		'If RsCxC2!contado <> 0 Then MsgBox "salod" & RsCxC2!doc_numero & RsCxC2!doc_valor
		If RsCxC2.EOF = False Then SaldoMov = libdat.CorrijeNuloN(RsCxC2.Fields("Doc_valorabon")) + SaldoMov
		RsCxC2.Close()
		'UPGRADE_NOTE: El objeto RsCxC2 no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		RsCxC2 = Nothing
		
		AbonosDocumento = System.Math.Round(SaldoMov, Emp.NumeroDigitos)
		
	End Function
	
	'Public Sub LLenarMultipleIngreso(ByVal DocSuc As String, ByVal DocTip As String, ByVal DocNum As Double _
	'', ByVal FechaIni As String, ByVal FechaFin As String, Optional ClienteMult As String, Optional Malla As MSFlexGrid)
	'Dim cod As String
	'Dim SaldoMUL As double, i As Integer
	'Dim RsCxCM As New adodb.Recordset
	'If FechaIni = "" Then FechaIni = "01/01/1970"
	'If FechaFin = "" Then FechaFin = Date
	'cod = " SELECT * " & _
	''              " FROM AdcApl " & _
	''              " WHERE Apl_SucApli = '" & DocSuc & "' AND Apl_DocApli ='" & DocTip & "'  " & _
	''              " AND Apl_NumApli = " & DocNum & " AND Apl_CodBenef = '0'  AND " & _
	''              " Apl_fecha >=" & libfec.ArmFormatoFecha(FechaIni) & " AND Apl_fecha <=" & libfec.ArmFormatoFecha(FechaFin) & "  " & _
	''              "order by  Doc_Sucursal, opc_Documento, Doc_Numero  "
	' With RsCxCM
	'            i = Malla.Rows
	'            If .State = 1 Then .Close
	'            .Open cod, ConxAdcom, adOpenKeyset, adLockOptimistic
	'            Do While Not .EOF
	'                Malla.Rows = Malla.Rows + 1
	'                Malla.TextMatrix(i, 0) = !Opc_documento
	'                Malla.TextMatrix(i, 1) = !doc_numero
	'                Malla.TextMatrix(i, 2) = !Apl_fecha
	'                Malla.TextMatrix(i, 3) = PonerFormatoNumero(cdbl(!Apl_valorapl) * -1)
	'                Malla.TextMatrix(i, 4) = PonerFormatoNumero(cdbl(!Apl_valorapl) * -1)
	'                Malla.TextMatrix(i, 5) = PonerFormatoNumero(cdbl(!Apl_valorapl) * -1)
	'                Malla.TextMatrix(i, 6) = 0 'PonerFormatoNumero(cdbl(!Apl_ValorApl) - cdbl(!Apl_ValorApl))
	''                If Not IsMissing(!Apl_codbenef) Then Malla.TextMatrix(i, 7) = -1
	''                If Not IsMissing(TipoDoc) Then Malla.TextMatrix(i, 8) = "ING"
	''                If Not IsMissing(Bodega) Then Malla.TextMatrix(i, 9) = ""
	'                i = i + 1
	'                .MoveNext
	'            Loop
	'End With
	'Set RsCxCM = Nothing
	'
	'End Sub
	
	Public Sub ActualizarGar(ByVal malla As AxMSFlexGridLib.AxMSFlexGrid, ByVal Doc As String, ByVal Num As String, ByVal Fec As Date)
		Dim RsAux As New ADODB.Recordset
		Dim I As Short
		Dim cod As String
		With malla
			For I = 0 To .Rows - 1
				If .get_TextMatrix(I, 0) = "X" Then
					cod = "SELECT * FROM AdcDoc WHERE Opc_Documento='" & .get_TextMatrix(I, 1) & "' AND Doc_Sucursal='" & Emp.SucActual & "' AND Doc_Numero=" & .get_TextMatrix(I, 3)
					RsAux.Open(cod, ConxAdcom, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
					RsAux.Fields("Doc_DocSop").Value = RsAux.Fields("Opc_documento").Value
					RsAux.Fields("Doc_NumSop").Value = RsAux.Fields("Doc_numero").Value
					
					RsAux.Fields("Opc_documento").Value = Doc
					RsAux.Fields("Doc_numero").Value = Num
					
					RsAux.Fields("Doc_detalle").Value = RsAux.Fields("Doc_detalle").Value & " Efe."
					RsAux.Update()
					RsAux.Close()
					cod = "SELECT * FROM AdcApl WHERE Opc_Documento='" & .get_TextMatrix(I, 1) & "' AND Doc_Sucursal='" & Emp.SucActual & "' AND Doc_Numero=" & .get_TextMatrix(I, 3)
					RsAux.Open(cod, ConxAdcom, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
					Do While Not RsAux.EOF
						RsAux.Fields("Apl_DocGar").Value = RsAux.Fields("Opc_documento").Value
						RsAux.Fields("Apl_NumGar").Value = RsAux.Fields("Doc_numero").Value
						RsAux.Fields("Opc_documento").Value = Trim(Doc)
						RsAux.Fields("Doc_numero").Value = Num
						RsAux.Fields("Apl_fecha").Value = CDate(Fec)
						RsAux.Fields("Apl_docfecha").Value = RsAux.Fields("Doc_fecha").Value
						RsAux.Fields("CodConcepto").Value = ""
						RsAux.Update()
						RsAux.MoveNext()
					Loop 
					RsAux.Close()
				End If
			Next 
		End With
	End Sub
	
	Public Sub GuardarAplicacionSimple(ByRef IdClaveDoc As Double, ByRef idClaveDocapl As Double, ByVal Doc As String, ByVal Num As Double, ByVal Fec As Date, ByVal CodPer As String, ByVal DocApli As String, ByVal NumApli As Integer, ByVal FecApli As String, ByVal ValoApli As Double, ByVal SNContado As Boolean, Optional ByRef SucDoc As String = "", Optional ByRef SucApl As String = "", Optional ByRef ESPAGO As String = "", Optional ByRef NumLinPag As Short = 0)
		Dim codsql As String
		Dim QSUCDOC, QSUCAPL As String
		Dim Rs1doc As New ADODB.Recordset
		On Error Resume Next
		If NumLinPag < 1 Then NumLinPag = Int(Rnd(3) * 100)
		If Len(SucDoc) = 0 Then QSUCDOC = Emp.SucActual Else QSUCDOC = SucDoc
		If Len(SucApl) = 0 Then QSUCAPL = Emp.SucActual Else QSUCAPL = SucApl
		
		' borra aplicacion en ambos sentidos para preveer duplicación de aplicacion
		
		codsql = " FROM AdcApl WHERE apl_sucapli='" & QSUCDOC & "' and apl_docapli='" & Doc & "' and idclavedocapl =" & IdClaveDoc & " and opc_documento = '" & DocApli & "' and idclavedoc = " & idClaveDocapl & " and doc_sucursal = '" & QSUCAPL & "'"
		ConxAdcom.Execute("DELETE " & codsql)
		
		
		codsql = " FROM AdcApl WHERE doc_sucursal='" & QSUCDOC & "' and opc_documento='" & Doc & "' and idclavedoc =" & IdClaveDoc & " and apl_docapli = '" & DocApli & "' and idclavedocapl = " & idClaveDocapl & " and apl_sucapli = '" & QSUCAPL & "'"
		'    codsql = " FROM AdcApl WHERE doc_sucursal='" & QSUCDOC & "' and opc_documento='" & Doc & "' and idclavedoc =" & IdClaveDoc
		
		ConxAdcom.Execute("DELETE " & codsql)
		
		
		Rs1doc = New ADODB.Recordset
		codsql = "SELECT * " & codsql
		'PROPIEDADES QUE PERMITEN ABRIR Y AGREGAR UN NUEVO REGISTRO A UNA TABLA
		Rs1doc.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
		Rs1doc.LockType = ADODB.LockTypeEnum.adLockOptimistic
		Rs1doc.Open(codsql, ConxAdcom,  ,  , ADODB.CommandTypeEnum.adCmdText)
		With Rs1doc
			.AddNew()
			.Fields("Doc_sucursal").Value = Trim(QSUCDOC)
			.Fields("Opc_documento").Value = Trim(Doc)
			.Fields("Doc_numero").Value = Num
			.Fields("IdClaveDoc").Value = IdClaveDoc
			.Fields("apl_sucapli").Value = Trim(QSUCAPL)
			.Fields("apl_docapli").Value = Trim(DocApli)
			.Fields("APL_NUMAPLI").Value = Trim(CStr(NumApli))
			.Fields("idClaveDocapl").Value = idClaveDocapl
			If Not IsDate(FecApli) Then FecApli = IIf(IsDate(Fec), Fec, Today)
			If Not IsDate(Fec) Then Fec = CDate(FecApli)
			.Fields("Apl_docfecha").Value = Fec
			.Fields("Apl_fecha").Value = FecApli
			.Fields("Apl_valorapl").Value = ValoApli
			.Fields("Apl_codbenef").Value = CodPer
			.Fields("Apl_SNContado").Value = SNContado
			.Fields("ESPAGO").Value = ESPAGO
			.Fields("numLinApl").Value = NumLinPag
			.Fields("CodConcepto").Value = ""
			.Update()
		End With
		Rs1doc.Close()
	End Sub
	
	'Public Sub GuardarAplicacion(IdClaveDoc As Double, ByVal Doc As String, ByVal Num As Double, ByVal Fec As Date, ByVal CodPer As String, ByVal Malla As MSFlexGrid, ByVal SNContado As Boolean, Optional Garantia As String)
	'Dim codsql As String
	'Dim codsql2 As String
	'Dim Rs1doc As New ADODB.Recordset
	'Dim i As Long
	'    codsql = "  FROM AdcApl WHERE doc_sucursal='" & Emp.SucActual & "' and opc_documento='" & Doc & "' and idclavedoc=" & IdClaveDoc
	'    ConxAdcom.Execute "DELETE " & codsql
	'    Set Rs1doc = New ADODB.Recordset
	'    codsql = "SELECT * " & codsql
	'        'PROPIEDADES QUE PERMITEN ABRIR Y AGREGAR UN NUEVO REGISTRO A UNA TABLA
	'    Rs1doc.CursorType = adOpenKeyset
	'    Rs1doc.LockType = adLockOptimistic
	'    Rs1doc.Open codsql, ConxAdcom, , , adCmdText
	'    For i = 0 To Malla.Rows - 1
	'        If Malla.TextMatrix(i, 5) <> "" Then
	'        With Rs1doc
	'            codsql2 = " FROM AdcApl WHERE apl_sucapli='" & Emp.SucActual & "' and apl_docapli='" & Doc & "' and idclavedocapl =" & IdClaveDoc & _
	''            " and opc_documento = '" & trim$(Malla.TextMatrix(i, 1)) & "' and idclavedoc = " & IdClaveDocApl & " and doc_sucursal = '" & QSUCAPL & "'"
	'            ConxAdcom.Execute "DELETE " & codsql2
	'
	'            .AddNew
	'            !Doc_sucursal = trim$(Emp.SucActual)
	'            !doc_numero = Num
	'            !Opc_documento = trim$(Doc)
	'            !Apl_docapli = trim$(Malla.TextMatrix(i, 1))
	'            !Apl_numapli = trim$(Malla.TextMatrix(i, 2))
	'            !Apl_sucapli = trim$(Emp.SucActual)
	'            !Apl_docfecha = Malla.TextMatrix(i, 3)
	'            !Apl_fecha = Fec
	'            !Apl_valorapl = CDbl(Malla.TextMatrix(i, 5))
	'            !Apl_codbenef = CodPer
	'            !Apl_SNContado = SNContado
	'            If Garantia = "GAR" Then !Apl_DocGar = Garantia Else !Apl_DocGar = " "
	'            .Update
	'        End With
	'        End If
	'    Next
	'    Rs1doc.Close
	'End Sub
	
	Public Sub GuardarAplicacionFac(ByRef IdClaveDoc As Double, ByVal Doc As String, ByVal Num As Double, ByVal Fec As Date, ByVal CodPer As String, ByVal malla As Object, ByVal SNContado As Boolean, Optional ByRef Sucursal As String = "")
		Dim codsql As String
		Dim Rs1doc As New ADODB.Recordset
		Dim LaSuc As String
		If Sucursal = "" Then LaSuc = Emp.SucActual Else LaSuc = Sucursal
		Dim I As Integer
		codsql = " FROM AdcApl WHERE doc_sucursal='" & LaSuc & "' and opc_documento='" & Doc & "' and idclavedoc=" & IdClaveDoc
		ConxAdcom.Execute("DELETE " & codsql)
		
		Rs1doc = New ADODB.Recordset
		codsql = "SELECT * " & codsql
		'PROPIEDADES QUE PERMITEN ABRIR Y AGREGAR UN NUEVO REGISTRO A UNA TABLA
		Rs1doc.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
		Rs1doc.LockType = ADODB.LockTypeEnum.adLockOptimistic
		Rs1doc.Open(codsql, ConxAdcom,  ,  , ADODB.CommandTypeEnum.adCmdText)
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		For I = 1 To malla.Rows - 1
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If malla.TextMatrix(I, 4) <> "" Then
				With Rs1doc
					
					.AddNew()
					.Fields("Doc_sucursal").Value = Trim(Emp.SucActual)
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.Fields("Doc_numero").Value = Trim(malla.TextMatrix(I, 1))
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.Fields("Opc_documento").Value = Trim(malla.TextMatrix(I, 0))
					.Fields("apl_docapli").Value = Trim(Doc)
					.Fields("APL_NUMAPLI").Value = Num
					.Fields("apl_sucapli").Value = Trim(Emp.SucActual)
					.Fields("Apl_fecha").Value = Fec
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.Fields("Apl_docfecha").Value = malla.TextMatrix(I, 2)
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.Fields("Apl_valorapl").Value = CDbl(malla.TextMatrix(I, 4))
					.Fields("Apl_codbenef").Value = CodPer
					.Fields("Apl_SNContado").Value = SNContado
					.Fields("IdClaveDoc").Value = IdClaveDoc
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.Fields("idClaveDocapl").Value = Val(malla.TextMatrix(I, 10))
					.Fields("CodConcepto").Value = ""
					.Fields("numLinApl").Value = I
					.Update()
				End With
			End If
		Next 
		Rs1doc.Close()
	End Sub
	
	Public Sub GuardarAplicacionNvo(ByRef IdClaveDoc As Double, ByVal Doc As String, ByVal Num As Double, ByVal Fec As Date, ByVal CodPer As String, ByVal malla As Object, ByVal SNContado As Boolean, Optional ByRef Garantia As String = "")
		Dim codsql As String
		Dim Codsql1 As String
		Dim Rs1doc As New ADODB.Recordset
		Dim RsApl As New ADODB.Recordset
		
		Dim I As Integer
		codsql = "  FROM AdcApl WHERE doc_sucursal='" & Emp.SucActual & "' and opc_documento='" & Doc & "' and idclavedoc=" & IdClaveDoc
		ConxAdcom.Execute("DELETE " & codsql)
		Rs1doc = New ADODB.Recordset
		codsql = "SELECT * " & codsql
		'PROPIEDADES QUE PERMITEN ABRIR Y AGREGAR UN NUEVO REGISTRO A UNA TABLA
		Rs1doc.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
		Rs1doc.LockType = ADODB.LockTypeEnum.adLockOptimistic
		Rs1doc.Open(codsql, ConxAdcom,  ,  , ADODB.CommandTypeEnum.adCmdText)
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		For I = 1 To malla.Rows - 1
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If malla.TextMatrix(I, 9) <> "" Then
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Codsql1 = "  FROM AdcApl WHERE apl_sucapli='" & Emp.SucActual & "' and apl_docapli='" & Doc & "' and idclavedocapl=" & IdClaveDoc & " and doc_sucursal = '" & Trim(malla.TextMatrix(I, 1)) & "' and opc_documento='" & malla.TextMatrix(I, 2) & "' and idclavedoc=" & malla.TextMatrix(I, 10)
				ConxAdcom.Execute("DELETE " & Codsql1)
				'        RsApl.Open "select * " & Codsql1, ConxAdcom, adOpenForwardOnly, adLockReadOnly, adCmdText
				'        If RsApl.EOF Then
				With Rs1doc
					.AddNew()
					.Fields("Doc_sucursal").Value = Trim(Emp.SucActual)
					.Fields("Doc_numero").Value = Num
					.Fields("Opc_documento").Value = Trim(Doc)
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.Fields("apl_docapli").Value = Trim(malla.TextMatrix(I, 2))
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.Fields("APL_NUMAPLI").Value = Trim(malla.TextMatrix(I, 3))
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.Fields("apl_sucapli").Value = Trim(malla.TextMatrix(I, 1))
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.Fields("Apl_docfecha").Value = malla.TextMatrix(I, 4)
					.Fields("Apl_fecha").Value = Fec
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.Fields("Apl_valorapl").Value = CDbl(malla.TextMatrix(I, 9))
					.Fields("Apl_codbenef").Value = CodPer
					.Fields("Apl_SNContado").Value = SNContado
					.Fields("CodConcepto").Value = ""
					.Fields("numLinApl").Value = I
					'NumLinPag < 1 Then NumLinPag = Int(Rnd(3) * 100)
					If Garantia = "GAR" Then .Fields("Apl_DocGar").Value = Garantia : .Fields("IdClaveDocgar").Value = IdClaveDoc Else .Fields("Apl_DocGar").Value = "" : .Fields("IdClaveDocgar").Value = 0
					.Fields("IdClaveDoc").Value = IdClaveDoc
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.Fields("idClaveDocapl").Value = malla.TextMatrix(I, 10)
					.Update()
				End With
				'        End If
				'        If RsApl.State = 1 Then RsApl.Close
			End If
		Next 
		Rs1doc.Close()
	End Sub
	
	Public Function ChequeaDocAplicado(ByRef DocSuc As String, ByRef DocTip As String, ByRef IdClaveDoc As Double, Optional ByRef DocQueAPLICA As String = "") As Boolean
		Dim cod As String
		Dim rs As New ADODB.Recordset
		cod = " SELECT * " & " FROM AdcApl " & " WHERE Apl_SucApli = '" & DocSuc & "' AND Apl_DocApli ='" & DocTip & "'  " & " AND idclavedocapl = " & IdClaveDoc
		rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		rs.Open(cod, ConxAdcom, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		If rs.EOF Then
			ChequeaDocAplicado = False
		Else
			ChequeaDocAplicado = True
			DocQueAPLICA = "Sucursal: " & rs.Fields("Doc_sucursal").Value & "    Tipo: " & rs.Fields("Opc_documento").Value & "   Numero: " & rs.Fields("Doc_numero").Value
		End If
		If rs.State Then rs.Close()
	End Function
	
	Public Function ChequeaConsolidado(ByRef DocSuc As String, ByRef DocTip As String, ByRef IdClaveDoc As Double, ByRef tabla As String, Optional ByRef DocQueAPLICA As String = "") As Boolean
		'Dim cod As String, Rs As New ADODB.Recordset
		'Dim ssql As String
		'    ssql = " SELECT NroDocConsolida, tipdocconsolida FROM " & tabla
		'    ssql = ssql & " where consolidar = 1 and NroDocConsolida > 0 and tipdocconsolida > '' "
		'    ssql = ssql & " AND DOC_SUCURSAL = '" & DocSuc & "' AND OPC_DOCUMENTO = '" & DocTip & "' AND IDCLAVEDOC = " & IdClaveDoc
		'
		'Rs.CursorLocation = adUseClient
		'Rs.Open ssql, ConxAdcom, adOpenForwardOnly, adLockReadOnly
		'If Rs.EOF Then
		ChequeaConsolidado = False
		'Else
		'    ChequeaConsolidado = True
		'    ssql = " SELECT doc_numero FROM adcdoc "
		'    ssql = ssql & " where "
		'    ssql = ssql & " DOC_SUCURSAL = '" & DocSuc & "' AND OPC_DOCUMENTO = '" & Rs!tipodocconsolida & "' AND IDCLAVEDOC = " & nrodocconsolida
		'    If Rs.State = 1 Then Rs.Close
		'    Rs.Open ssql, ConxAdcom, adOpenForwardOnly, adLockReadOnly
		'    If Rs.EOF Then
		'        Rs.Close
		'        ssql = " SELECT doc_numero FROM adcdoc "
		'        ssql = ssql & " where "
		'        ssql = ssql & " DOC_SUCURSAL = '" & DocSuc & "' AND OPC_DOCUMENTO = '" & Rs!tipodocconsolida & "' AND IDCLAVEDOC = " & nrodocconsolida
		'        If Rs.State = 1 Then Rs.Close
		'        Rs.Open ssql, ConxAdcom, adOpenForwardOnly, adLockReadOnly
		'    End If
		'        If Rs.EOF = False Then
		'            DocQueAPLICA = "Sucursal: " & Rs!Doc_sucursal & "    Tipo: " & Rs!tipdocconsolida & "   Numero: " & Rs!Doc_numero
		'        End If
		'End If
		'If Rs.State Then Rs.Close
	End Function
	
	Public Function ChequeaDocAdjuntos(ByRef DocSuc As String, ByRef DocTip As String, ByRef DocNumero As String, ByRef IdClaveDoc As Double) As Boolean
		Dim rs As New ADODB.Recordset
		Dim ssql As String
		ssql = "SELECT  Doc_sucursal, Opc_documento, Doc_numero, Doc_fecha, Doc_NombreImp, Doc_valor,idclavedoc From dbo.AdcDoc"
		ssql = ssql & " WHERE  Doc_DocSop = '" & DocTip & "' AND Doc_NumSop = " & DocNumero
		rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		rs.Open(ssql, ConxAdcom, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		If rs.EOF Then ChequeaDocAdjuntos = False Else ChequeaDocAdjuntos = True
		If rs.State Then rs.Close()
	End Function
	
	Public Function AplicacionesHor(ByVal DocSuc As String, ByVal DocTip As String, ByVal IdClaveDoc As Double, ByVal FechaIni As String, ByVal FechaFin As String, Optional ByRef ConGar As Boolean = False) As String
		Dim SaldoMov As Double
		Dim Garantias As String
		Dim RsCxC2 As New ADODB.Recordset
		Dim SUMAR As String
		Dim cod As String
		'FechaIni = ""
		Garantias = ""
		SUMAR = ""
		'UPGRADE_NOTE: IsMissing() ha cambiado a IsNothing(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"'
		If IsNothing(ConGar) Then ConGar = False
		If FechaIni = "" Then FechaIni = "01/01/1970"
		If FechaFin = "" Then FechaFin = CStr(Today)
		If ConGar = False Then Garantias = " AND Apl_numgar = 0 "
		cod = " SELECT * " & " FROM AdcApl " & " WHERE Apl_SucApli = '" & DocSuc & "' AND Apl_DocApli ='" & DocTip & "'  " & " AND idclavedocapl = " & IdClaveDoc & "  and " & " Apl_fecha >=" & libfec.ArmFormatoFecha(FechaIni) & "   AND Apl_fecha <=" & libfec.ArmFormatoFecha(FechaFin) & " " & Garantias
		
		With RsCxC2
			If .State = 1 Then .Close()
			.Open(cod, ConxAdcom, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
			If Not .EOF Then
				Do Until .EOF
					SUMAR = SUMAR & Trim(.Fields("Opc_documento").Value) & "-" & .Fields("Doc_numero").Value & " "
					.MoveNext()
				Loop 
			End If
			cod = " SELECT * " & " FROM AdcApl " & " WHERE doc_Sucursal = '" & DocSuc & "' AND opc_Documento ='" & DocTip & "'  " & " AND idclavedoc = " & IdClaveDoc & " and  " & " Apl_fecha >=" & libfec.ArmFormatoFecha(FechaIni) & "  and Apl_fecha <=" & libfec.ArmFormatoFecha(FechaFin) & " " & Garantias
			
			If .State = 1 Then .Close()
			.Open(cod, ConxAdcom, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
			If Not .EOF Then
				Do Until .EOF
					SUMAR = SUMAR & Trim(.Fields("apl_docapli").Value) & "-" & .Fields("APL_NUMAPLI").Value & " "
					.MoveNext()
				Loop 
			End If
			
		End With
		AplicacionesHor = SUMAR
	End Function
	
	Public Sub CalcularSoloCuotas(ByRef TipoPago As String, ByRef ValorPago As Double, ByRef DocFecha As Date, ByRef MallaCuotas As AxMSFlexGridLib.AxMSFlexGrid, Optional ByRef ValorCuota As Double = 0)
		Dim RecPago As ADODB.Recordset
		Dim Xfecha As Date
		Dim Xdias As Short
		Dim XvalorCuota As Double
		Dim total As Double
		Dim NumCuotas As Short
		Dim Auxil As String
		Dim I As Integer
		On Error Resume Next
		RecPago = New ADODB.Recordset
		MallaCuotas.Clear()
		MallaCuotas.Rows = 0
		Auxil = "SELECT * from FormasDePago wheRE IdFormasdePago = '" & TipoPago & "'"
		RecPago.Open(Auxil, ConxAdcom,  ,  , ADODB.CommandTypeEnum.adCmdText)
		If Not RecPago.EOF Then
			With RecPago
				.MoveFirst()
				'UPGRADE_NOTE: IsMissing() ha cambiado a IsNothing(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"'
				If (IsNothing(ValorCuota) Or ValorCuota = 0) And .Fields("numerodecuotas").Value = 99 Then ValorCuota = CDbl(Val(InputBox("Digite el valor de la cuota", .Fields("Descripcion").Value, "0")))
				
				If .Fields("formadepago").Value = 1 Or .Fields("numerodecuotas").Value = 0 Then RecPago.Close() : Exit Sub
				Xfecha = DocFecha
				If .Fields("numerodecuotas").Value = 99 And ValorCuota > 0 Then
					NumCuotas = ValorPago / ValorCuota
					total = ValorCuota * NumCuotas
					If ValorPago > total Then NumCuotas = NumCuotas + 1
					XvalorCuota = ValorCuota
				Else
					XvalorCuota = System.Math.Round(ValorPago / .Fields("numerodecuotas").Value, 2)
					NumCuotas = .Fields("numerodecuotas").Value
				End If
				total = 0
				For I = 1 To NumCuotas
					If .Fields("plazofv").Value = 2 Then
						Select Case I
							Case 1
								Xdias = .Fields("DiasCuotaVar0").Value
							Case 2
								Xdias = .Fields("DiasCuotaVar1").Value
							Case 3
								Xdias = .Fields("DiasCuotaVar2").Value
							Case 4
								Xdias = .Fields("DiasCuotaVar3").Value
							Case 5
								Xdias = .Fields("DiasCuotaVar4").Value
							Case 6
								Xdias = .Fields("DiasCuotaVar5").Value
							Case 7
								Xdias = .Fields("DiasCuotaVar6").Value
							Case 8
								Xdias = .Fields("DiasCuotaVar7").Value
							Case 9
								Xdias = .Fields("DiasCuotaVar8").Value
							Case 10
								Xdias = .Fields("DiasCuotaVar9").Value
							Case 11
								Xdias = .Fields("DiasCuotaVar10").Value
							Case 12
								Xdias = .Fields("DiasCuotaVar11").Value
						End Select
					Else : Xdias = .Fields("DiasCuotaFijas").Value
					End If
					If TipoPago = "MES" Then Xfecha = DateAdd(Microsoft.VisualBasic.DateInterval.Month, 1, Xfecha) Else Xfecha = DateAdd(Microsoft.VisualBasic.DateInterval.Day, Xdias, Xfecha)
					total = total + XvalorCuota
					MallaCuotas.Rows = I
					MallaCuotas.set_TextMatrix(I - 1, 0, XvalorCuota)
					MallaCuotas.set_TextMatrix(I - 1, 1, Xfecha)
				Next I
			End With
			If NumCuotas > 1 Then
				XvalorCuota = ValorPago - total
				MallaCuotas.set_TextMatrix(NumCuotas - 1, 0, CDbl(MallaCuotas.get_TextMatrix(NumCuotas - 1, 0)) + XvalorCuota)
			End If
		End If
		RecPago.Close()
	End Sub
	
	Public Function SaldoCheques(ByRef codCli As String, ByRef fecha As String) As Double
		Dim ConSucursal, cod, ConFecha As String
		Dim rs As New ADODB.Recordset
		ConSucursal = ""
		ConFecha = ""
		SaldoCheques = 0
		If fecha > "" Then ConFecha = " and Doc_fecha <= " & libfec.ArmFormatoFecha(fecha) & " "
		cod = " SELECT CHE_codper, Sum(Che_valor-CHE_ABONOS) AS valor " & " From Adccheques " & " Where che_codper = '" & codCli & "' " & " GROUP BY che_codper "
		rs = New ADODB.Recordset
		rs.Open(cod, ConxAdcom, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockOptimistic)
		If rs.EOF = False Then
			SaldoCheques = rs.Fields("Valor").Value
		End If
	End Function
	
	Public Function AbonosFecha(ByVal DocSuc As String, ByVal DocTip As String, ByVal DocNum As Double, ByVal FechaIni As String, ByVal FechaFin As String, Optional ByRef ConGar As Boolean = False) As Double
		Dim SaldoMov As Double
		Dim Garantias As String
		Dim RsCxC2 As New ADODB.Recordset
		Dim inicial As String
		Dim cod As String
		
		inicial = ""
		Garantias = ""
		If ConGar <> True Then ConGar = False
		If FechaIni > "" And IsDate(FechaIni) Then inicial = " and Apl_fecha >=" & libfec.ArmFormatoFecha(FechaIni)
		If FechaFin = "" Then FechaFin = CStr(Today)
		If ConGar = False Then Garantias = " AND ( Apl_numgar = 0 or apl_numgar is null ) "
		cod = " SELECT sum(Apl_ValorApl) as Abono " & " FROM AdcApl " & " WHERE Apl_SucApli = '" & DocSuc & "' AND Apl_DocApli ='" & DocTip & "'  " & " AND Apl_NumApli = " & DocNum & inicial & "   AND Apl_fecha <=" & libfec.ArmFormatoFecha(FechaFin) & " " & Garantias & " Group by  Apl_SucApli, Apl_DocApli, Apl_NumApli "
		With RsCxC2
			If .State = 1 Then .Close()
			'MsgBox Cod
			.Open(cod, ConxAdcom, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
			If Not .EOF Then SaldoMov = .Fields("abono").Value
			
			cod = " SELECT doc_sucursal,opc_documento,doc_numero,sum(Apl_ValorApl) as Abono " & " FROM AdcApl " & " WHERE doc_Sucursal = '" & DocSuc & "' AND opc_Documento ='" & DocTip & "'  " & " AND Doc_Numero = " & DocNum & inicial & "  and Apl_fecha <=" & libfec.ArmFormatoFecha(FechaFin) & " " & Garantias & "Group by  Doc_Sucursal, opc_Documento, Doc_Numero "
			
			If .State = 1 Then .Close()
			.Open(cod, ConxAdcom, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
			If Not .EOF Then SaldoMov = SaldoMov + .Fields("abono").Value
			
		End With
		
		If RsCxC2.State = 1 Then RsCxC2.Close()
		'UPGRADE_NOTE: El objeto RsCxC2 no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		RsCxC2 = Nothing
		
		AbonosFecha = SaldoMov
		
	End Function
	
	
	Public Function ClienteMovimiento(ByRef codigo As String) As Boolean
		Dim cod As String
		Dim rs As New ADODB.Recordset
		
		ClienteMovimiento = False
		If ConxAdcom.State = 1 Then
			cod = " SELECT Doc_codper " & " From AdcDoc " & " Where Doc_codper = '" & codigo & "' "
			rs = New ADODB.Recordset
			rs.Open(cod, ConxAdcom, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockOptimistic)
			If rs.State = 1 Then
				If rs.EOF = False Then ClienteMovimiento = True
				rs.Close()
			End If
		End If
	End Function
	
	Public Sub CargarPagosDocumento(ByRef IdClaveDoc As Double, ByRef TablaPag As String, ByRef Sucursal As String, ByRef Documento As String, ByRef numero As Double, ByRef malla As Object, ByRef MallaCuotas As Object)
		On Error Resume Next
		Dim cod As String
		Dim rspag As New ADODB.Recordset
		Dim SwCuo As Boolean
		Dim RsCuo As New ADODB.Recordset
		Dim JJ, I As Short
		Dim Jcol As Short
		' 0= Efectivo  1= Tarjeta 2= Documento
		' 3= Cheque    4= Credito solo Uno
		' 0  tipo tardocche,1 valor, 2 Descripción, 3 Autoriza, 4 DocInstitucion
		' 5  NumCtaBanco, 6 DocPagoTipo, 7 DocPagoNumero,8 PlanTarjeta ,9 Comisión Tarjeta
		' 10 NroCuotas, 11  Credito =true o false
		' ************************************************
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.Clear. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		malla.Clear()
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto MallaCuotas.Clear. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		MallaCuotas.Clear()
		
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.Cols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If malla.Cols < 30 Then malla.Cols = 30
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto MallaCuotas.Cols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If MallaCuotas.Cols < 4 Then MallaCuotas.Cols = 4
		If IdClaveDoc = 0 Then Exit Sub
		cod = " SELECT * From  " & TablaPag & "  WHERE  doc_sucursal= '" & Sucursal & "' AND  " & " opc_documento='" & Documento & "' AND idclavedoc =" & IdClaveDoc
		
		rspag.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
		rspag.LockType = ADODB.LockTypeEnum.adLockOptimistic
		rspag.Open(cod, ConxAdcom,  ,  , ADODB.CommandTypeEnum.adCmdText)
		If rspag.RecordCount > 0 Then
			With rspag
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.FixedRows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				I = malla.FixedRows
				SwCuo = True
				Do While Not .EOF
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					malla.Rows = I + 1
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					malla.TextMatrix(I, 0) = .Fields("PAG_TIPOPAGO").Value
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					malla.TextMatrix(I, 2) = .Fields("Pag_Valor").Value
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Not IsDbNull(.Fields("Pag_descripcion").Value) Then malla.TextMatrix(I, 1) = .Fields("Pag_descripcion").Value
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Not IsDbNull(.Fields("pag_Autoriza").Value) Then malla.TextMatrix(I, 3) = .Fields("pag_Autoriza").Value
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Not IsDbNull(.Fields("pag_Docinstitucion").Value) Then malla.TextMatrix(I, 4) = .Fields("pag_Docinstitucion").Value
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Not IsDbNull(.Fields("pag_NumCtaBanco").Value) Then malla.TextMatrix(I, 5) = .Fields("pag_NumCtaBanco").Value
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Not IsDbNull(.Fields("pag_docpagotipo").Value) Then malla.TextMatrix(I, 6) = .Fields("pag_docpagotipo").Value
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Not IsDbNull(.Fields("pag_DocPagoNumero").Value) Then malla.TextMatrix(I, 7) = .Fields("pag_DocPagoNumero").Value
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Not IsDbNull(.Fields("pag_plantarjeta").Value) Then malla.TextMatrix(I, 8) = .Fields("pag_plantarjeta").Value
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Not IsDbNull(.Fields("pag_comisiontarjeta").Value) Then malla.TextMatrix(I, 9) = .Fields("pag_comisiontarjeta").Value
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Not IsDbNull(.Fields("pag_cuotas").Value) Then malla.TextMatrix(I, 10) = .Fields("pag_cuotas").Value
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					malla.TextMatrix(I, 11) = libdat.CorrijeNuloN(.Fields("pag_formapago"))
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Not IsDbNull(.Fields("Pag_InteresTarjeta").Value) Then malla.TextMatrix(I, 14) = .Fields("Pag_InteresTarjeta").Value
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Not IsDbNull(.Fields("Pag_Idpago").Value) Then malla.TextMatrix(I, 15) = .Fields("Pag_Idpago").Value
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Not IsDbNull(.Fields("Pag_Vence").Value) Then malla.TextMatrix(I, 18) = .Fields("Pag_Vence").Value
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Not IsDbNull(.Fields("pag_Beneficiario").Value) Then malla.TextMatrix(I, 19) = .Fields("pag_Beneficiario").Value
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Not IsDbNull(.Fields("pag_Beneficiario").Value) Then malla.TextMatrix(I, 19) = .Fields("pag_Beneficiario").Value
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Not IsDbNull(.Fields("pag_docpagosucursal").Value) Then malla.TextMatrix(I, 25) = .Fields("pag_docpagosucursal").Value
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Not IsDbNull(.Fields("IdclaveDocPag").Value) Then malla.TextMatrix(I, 26) = .Fields("IdclaveDocPag").Value
					
					'                                    IdclaveDocPag   numeric(18, 0)  Checked
					'Pag_DocPagoSucursal char(3) Checked
					
					
					' 0  tipo tardocche, 1 Descripción,2 valor, 3 Autoriza, 4 DocInstitucion
					' 5  NumCtaBanco, 6 DocPagoTipo, 7 DocPagoNumero,8 PlanTarjeta ,9 Comisión Tarjeta
					' 10 NroCuotas, 11  Credito =true o false, 12 generaingreso, 13 cancelafactura, 14 interes de la tarjeta, 15 Idforma de pago
					' ************************************************
					' Solo unCredito
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto MallaCuotas.FixedRows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					JJ = MallaCuotas.FixedRows
					If .Fields("PAG_TIPOPAGO").Value = "4" Then
						cod = "SELECT * from ADCCUOTAS  Where cuo_docsuc='" & .Fields("Doc_sucursal").Value & "' AND Cuo_DocTipo='" & .Fields("Opc_documento").Value & "' and Cuo_DocNumero =" & .Fields("Doc_numero").Value
						RsCuo.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
						RsCuo.LockType = ADODB.LockTypeEnum.adLockOptimistic
						RsCuo.Open(cod, ConxAdcom,  ,  , ADODB.CommandTypeEnum.adCmdText)
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto MallaCuotas.Cols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If MallaCuotas.Cols < 3 Then MallaCuotas.Cols = 3
						Do While Not RsCuo.EOF
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto MallaCuotas.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							MallaCuotas.Rows = JJ + 1
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto MallaCuotas.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							MallaCuotas.TextMatrix(JJ, 0) = JJ
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto MallaCuotas.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							MallaCuotas.TextMatrix(JJ, 1) = RsCuo.Fields("cuo_Valor").Value
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto MallaCuotas.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							MallaCuotas.TextMatrix(JJ, 2) = RsCuo.Fields("Cuo_FechaVence").Value
							JJ = JJ + 1
							If JJ > 70 Then Exit Do
							RsCuo.MoveNext()
						Loop 
						RsCuo.Close()
					End If
					I = I + 1
					.MoveNext()
					
				Loop 
			End With
		End If
		rspag.Close()
	End Sub
	'Private Sub ArreglaEntrada()
	'
	'    dtFormaPago.Top = dato(2).Top
	'    dtFormaPago.Left = dato(2).Left
	'    dtFormaPago.Height = dato(2).Height
	'    dtFormaPago.Width = dato(2).Width
	'
	'End Sub
	
	Public Sub MuestraImpuestos(ByRef ImpPorcentaje() As Double, ByRef ImpSnIva() As String, ByRef ImpNombre() As String, ByRef OpOpc As PrySysp13.Opcdoc, Optional ByRef IvaCliente As Boolean = False)
		Dim PrySysp13 As Object
		'on error Resume Next
		Dim RsImp As New ADODB.Recordset
		Dim I As Short
		
		For I = 0 To 4
			ImpPorcentaje(I) = 0
			ImpSnIva(I) = ""
			ImpNombre(I) = ""
		Next I
		
		'If IvaCliente = False Then Exit Sub
		
		If RsImp.State = 1 Then RsImp.Close()
		RsImp.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
		RsImp.LockType = ADODB.LockTypeEnum.adLockOptimistic
		RsImp.Open("select * from syscod where TipoReferencia = 'impuestos' and abreviación <> '#' ", ConxSysemp,  ,  , ADODB.CommandTypeEnum.adCmdText)
		If RsImp.State = 0 Then Exit Sub
		I = 1
		With RsImp
			Do Until RsImp.EOF
				If UCase(Trim(.Fields("abreviación").Value)) = "IVA" Then
					ImpPorcentaje(0) = libdat.CorrijeNuloN(.Fields("Caracteristica1"))
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto libdat.CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ImpSnIva(0) = libdat.CorrijeNulo(.Fields("Caracteristica2"))
					ImpNombre(0) = .Fields("Descripcion").Value
				Else
					ImpPorcentaje(I) = libdat.CorrijeNuloN(.Fields("Caracteristica1"))
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto libdat.CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ImpSnIva(I) = libdat.CorrijeNulo(.Fields("Caracteristica2"))
					ImpNombre(I) = .Fields("Descripcion").Value
					I = I + 1
				End If
				RsImp.MoveNext()
			Loop 
			.Close()
			For I = 0 To 4
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto OpOpc.Impuestos. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Mid(OpOpc.Impuestos, I + 1, 1) = "0" Then
					ImpPorcentaje(I) = 0
					ImpSnIva(I) = ""
					ImpNombre(I) = ""
				End If
			Next 
		End With
	End Sub
	
	Public Sub CargarMallaSaldos(ByRef EsCliente As Boolean, ByRef malla As Object, ByRef txtCodPer As String, ByRef txtFec As String, Optional ByRef DocSuc As String = "", Optional ByRef DocTip As String = "", Optional ByRef DocNum As String = "", Optional ByRef IdClaveDoc As Double = 0, Optional ByRef NroLoteEx As String = "", Optional ByRef SoloAfectar As Boolean = False, Optional ByRef SignoDoc As Short = 0)
		Dim rs As New ADODB.Recordset
		Dim RA As New ADODB.Recordset
		Dim I As Integer
		Dim cod As String
		Dim StrSigno, StrComVen As String
		Dim FechEfec, CodigoPer As String
		Dim ConSaldo, Garantia As String
		Dim SinDocumento As String
		Dim SinAplicacion As String
		Dim ConLote As String
		Dim ELSIGNO As Short
		ELSIGNO = -1 * SignoDoc
		If txtFec = "" Then txtFec = CStr(Today)
		If NroLoteEx > "" Then ConLote = " and doc_nrolotedoc = '" & NroLoteEx & "' "
		If DocSuc > "" And DocTip > "" And IdClaveDoc > 0 Then
			SinDocumento = " and not ( doc_sucursal = '" & DocSuc & "' and opc_documento = '" & DocTip & "' and idclavedoc = " & IdClaveDoc & " )"
			SinAplicacion = " and not ( apl_sucapli = '" & DocSuc & "' and apl_docapli = '" & DocTip & "' and idclavedocapl = " & IdClaveDoc & " )"
		End If
		StrSigno = "AND (AdcDoc.doc_Ventas <> 0 OR AdcDoc.doc_Compras <> 0)"
		StrComVen = " (CASE Doc_Compras WHEN 0 THEN DOC_VENTAS else doc_compras END )"
		If ELSIGNO = 0 Then
			ConSaldo = " where round(Valor - signo * Doc_ValorAbon + ISNULL(abonado,0),2) <> 0 "
		Else
			ConSaldo = " where sign(round(Valor - signo * Doc_ValorAbon + ISNULL(abonado,0),2)) = " & ELSIGNO
		End If
		FechEfec = " Doc_Fecha "
		'If SoloAfectar Then
		'    If Tipo = "FAC" Then
		'        ConSaldo = " where round(Valor - signo * Doc_ValorAbon + ISNULL(abonado,0),2)  < 0 "
		'    Else
		'        ConSaldo = " where round(Valor - signo * Doc_ValorAbon + ISNULL(abonado,0),2)  > 0 "
		'    End If
		'End If
		If txtCodPer > "" And txtCodPer <> "0" Then
			CodigoPer = " And AdcDoc.Doc_Codper = '" & txtCodPer & "' "
		Else
			CodigoPer = ""
		End If
		Garantia = " AND AdcDoc.Doc_TipoDoc <>'GAR' "
		
		cod = "select Doc_sucursal as SUC, Opc_documento as TIP, Doc_numero AS Numero,Fecha, FechaVence,  Valor," & " round(Valor - signo * Doc_ValorAbon + ISNULL(abonado,0),2) as saldo , " & " Doc_NombreImp, Doc_TipoDoc, signo,t1.idclavedoc " & " from " & " (SELECT Doc_sucursal, Opc_documento,  Doc_numero,Doc_Fecha as Fecha, Doc_FechaEfe as FechaVence , " & " " & StrComVen & " * Doc_valor as Valor, " & StrComVen & "  as Signo, Doc_TipoDoc,Doc_Bodega,Doc_NombreImp , doc_detalle ," & " Doc_ValorAbon,idclavedoc" & " From AdcDoc " & " WHERE Doc_Sucursal > '' AND " & StrComVen & " <> 0 And " & FechEfec & " <=" & libfec.ArmFormatoFecha(txtFec) & CodigoPer & Garantia & " and AdcDoc.Doc_valor <> 0 " & ConLote & SinDocumento & "  ) t1 " & " Left  join " & " (SELECT idclavedocapl, Apl_sucapli as suc, SUM(isnull(Apl_valorapl,0)) AS Abonado, Apl_docapli as doc, APL_NUMAPLI as num " & " From AdcDocAbonos2 " & " WHERE apl_fecha <= " & libfec.ArmFormatoFecha(txtFec) & " " & SinDocumento & " GROUP BY Apl_sucapli, Apl_docapli, APL_NUMAPLI,idclavedocapl ) as t2 " & " ON t1.idclavedoc = t2.idclavedocapl AND t1.Opc_documento = t2.doc AND t1.Doc_sucursal = t2.suc " & ConSaldo & " order by Doc_NombreImp,fecha, doc_sucursal,opc_documento,doc_numero "
		Debug.Print(cod)
		rs.Open(cod, ConxAdcom, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		If rs.EOF Then Exit Sub
		With malla
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Rows = 2
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.Cols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Cols = 11
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			For I = 1 To malla.Rows - 1
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 0) = I
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 1) = ""
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 2) = ""
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 3) = ""
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 4) = ""
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 5) = ""
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 6) = ""
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 7) = ""
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 8) = ""
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 9) = ""
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 10) = ""
			Next 
		End With
		If rs.EOF Then
			'UPGRADE_NOTE: El objeto rs no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rs = Nothing : Exit Sub
		End If
		With malla
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.Redraw. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Redraw = False
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColAlignment(6) = 1
			I = 0
			Do Until rs.EOF
				I = I + 1
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Rows = I + 1
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 0) = I
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 1) = rs.Fields("Suc").Value
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 2) = rs.Fields("Tip").Value
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 3) = rs.Fields("numero").Value
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 4) = rs.Fields("fecha").Value
				If DocSuc > "" And DocTip > "" And DocNum > "" Then
					
					RA = New ADODB.Recordset
					SinDocumento = " doc_sucursal = '" & DocSuc & "' and opc_documento = '" & DocTip & "' and idclavedoc = " & IdClaveDoc & " and  " & " apl_sucapli = '" & rs.Fields("Suc").Value & "' and apl_docapli = '" & rs.Fields("Tip").Value & "' and idclavedocapl = " & rs.Fields("IdClaveDoc").Value & " "
					
					RA.Open("select * from adcdocabonos2 where " & SinDocumento, ConxAdcom, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
					If RA.EOF = False Then
						
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						.TextMatrix(I, 9) = VB6.Format(System.Math.Abs(RA.Fields("Apl_valorapl").Value), "########0.00")
						
					End If
					
					RA.Close()
					
				End If
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 5) = rs.Fields("FechaVence").Value
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 6) = rs.Fields("Doc_NombreImp").Value
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 7) = VB6.Format(rs.Fields("Valor").Value, "###,###,##0.00")
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 8) = VB6.Format(rs.Fields("Saldo").Value, "###,###,##0.00")
				'.ColWidth(6) = 1700
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.ColWidth(10) = 0
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 10) = rs.Fields("IdClaveDoc").Value
				rs.MoveNext()
			Loop 
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.Redraw. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Redraw = True
		End With
		rs.Close()
		'UPGRADE_NOTE: El objeto rs no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		rs = Nothing
	End Sub
	
	Public Sub CargarMallaSaldos2(ByRef EsCliente As Boolean, ByRef malla As Object, ByRef txtCodPer As String, ByRef txtFec As String, Optional ByRef DocSuc As String = "", Optional ByRef DocTip As String = "", Optional ByRef DocNum As String = "", Optional ByRef IdClaveDoc As Double = 0, Optional ByRef NroLoteEx As String = "", Optional ByRef Solocliente As Boolean = False, Optional ByRef coloproveedor As Boolean = False, Optional ByRef conanticipos As Boolean = False, Optional ByRef TipoDoc As String = "")
		Dim rs As New ADODB.Recordset
		Dim RA As New ADODB.Recordset
		Dim I As Integer
		Dim cod As String
		Dim StrSigno, StrComVen As String
		Dim FechEfec, CodigoPer As String
		Dim ConSaldo, Garantia As String
		Dim SinDocumento As String
		Dim SinAplicacion As String
		Dim ConLote As String
		Dim ELSIGNO As Short
		Dim union As String
		'Dim txtFec As String
		Dim conempleado As Short
		Dim sindocumentotipo As String
		If Not (Solocliente Or coloproveedor Or conanticipos) Then Exit Sub
		
		If txtFec = "" Then txtFec = CStr(Today)
		
		If NroLoteEx > "" Then ConLote = NroLoteEx
		
		' ,@hasta date ,@anticipos bit ,@garantias bit ,@movimiento bit ,@ventas varchar(2) ,@lotedoc varchar(20) ,@cheques bit ,@SUC varchar(3),@DOC varchar(3) ,@IDCLAVEDOC numeric(18,0)
		
		StrSigno = ""
		If Solocliente And coloproveedor Then
			
		ElseIf Solocliente Then 
			StrSigno = "C"
		ElseIf coloproveedor Then 
			StrSigno = "P"
		End If
		
		'EXEC    @return_value = [dbo].[ADC_CCIND]
		'        @Cliente = N'1703619138',
		'        @hasta = '10/10/2011',
		'        @anticipos = 1,
		'        @garantias = 0,
		'        @movimiento = 0,
		'        @ventas='',
		'        @LOTEDOC='',
		'        @cheques = 0,
		'        @SUC = N'PRI',
		'        @DOC = N'FAP',
		'        @IDCLAVEDOC = 2673
		Dim txtfec1 As String
		txtfec1 = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, 1, Emp.InvUltAnu))
		conempleado = 1
		sindocumentotipo = ""
		If txtCodPer = "0" Then conempleado = 0 : SinDocumento = DocTip
		cod = "exec ADC_CCIND '" & txtCodPer & "','" & txtfec1 & "','" & txtFec & "'," & IIf(conanticipos, 1, 0) & ",0,0,'" & StrSigno & "','" & NroLoteEx & "',0,'" & DocSuc & "','" & DocTip & "'," & IdClaveDoc & "," & conempleado & ",'" & sindocumentotipo & "'"
		'Rs.Open cod, ConxAdcom, adOpenForwardOnly, adLockReadOnly
		rs = ConxAdcom.Execute(cod)
		
		Debug.Print(cod)
		'Rs.Open cod, ConxAdcom, adOpenForwardOnly, adLockReadOnly
		If rs.EOF Then Exit Sub
		With malla
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.Redraw. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Redraw = False
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.Clear. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Clear()
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Rows = 2
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.Cols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Cols = 11
			
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(0, 0) = ""
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(0, 1) = "Nombre"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(0, 2) = "Fecha"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(0, 3) = "SUC"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(0, 4) = "TIP"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(0, 5) = "Número"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(0, 6) = "SaldoAct."
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(0, 7) = "Abono"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(0, 8) = ""
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(0, 9) = "codcliente"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.TextMatrix(0, 10) = "idclave"
			
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.ColLock. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColLock(0) = True
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.ColLock. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColLock(1) = True
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.ColLock. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColLock(2) = True
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.ColLock. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColLock(3) = True
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.ColLock. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColLock(4) = True
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.ColLock. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColLock(5) = True
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.ColLock. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColLock(6) = True
			
			
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.MallaFija. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.MallaFija = True
			
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColWidth(0) = 450
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If (txtCodPer > "" And txtCodPer <> "0") Then
				.ColWidth(1) = 0
			Else
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.ColWidth(1) = 3000
			End If
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColWidth(2) = 1200
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColWidth(3) = 500
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColWidth(4) = 500
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColWidth(5) = 1200
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColWidth(6) = 1200
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColWidth(7) = 1200
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColWidth(8) = 0
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColWidth(9) = 0
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.ColWidth. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColWidth(10) = 0
			
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColAlignment(6) = 7
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColAlignment(7) = 7
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColAlignment(2) = 1
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColAlignment(1) = 1
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.ColAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColAlignment(5) = 1
			
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.ColData. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.ColData(7) = 15
			
			If rs.EOF Then
				'UPGRADE_NOTE: El objeto rs no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				rs = Nothing : Exit Sub
			End If
			I = 0
			Do Until rs.EOF
				I = I + 1
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Rows = I + 1
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 0) = I
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 1) = "" & rs.Fields("Doc_NombreImp").Value
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 2) = rs.Fields("fecha").Value
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 3) = Trim(rs.Fields("Suc").Value)
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 4) = Trim(rs.Fields("Tip").Value)
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 5) = rs.Fields("numero").Value
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 6) = VB6.Format(rs.Fields("Saldo").Value, "########0.00")
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 9) = rs.Fields("Doc_codper").Value
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(I, 10) = rs.Fields("IdClaveDoc").Value
				
				rs.MoveNext()
			Loop 
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.Redraw. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Redraw = True
			rs.Close()
			'UPGRADE_NOTE: El objeto rs no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			rs = Nothing
			
			If DocSuc > "" And DocTip > "" And IdClaveDoc > 0 Then
				RA = New ADODB.Recordset
				SinDocumento = " doc_sucursal = '" & DocSuc & "' and opc_documento = '" & DocTip & "' and idclavedoc = " & IdClaveDoc '& |        '" and  " & " apl_sucapli = '" & Rs!Suc & "' and apl_docapli = '" & Rs!Tip & "' and idclavedocapl = " & Rs!IdClaveDoc & " "
				RA.Open("select * from adcdocabonos2 where apl_fecha <= '" & txtFec & "' and " & SinDocumento, ConxAdcom, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
				If RA.EOF Then RA.Close() : Exit Sub
				Do Until RA.EOF
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					For I = 1 To .Rows - 1
						'MsgBox Trim(.TextMatrix(i, 3)) & " " & Trim(.TextMatrix(i, 4)) & " " & RA!idClaveDocapl
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If Trim(.TextMatrix(I, 3)) = RA.Fields("apl_sucapli").Value And Trim(.TextMatrix(I, 4)) = RA.Fields("apl_docapli").Value And Val(.TextMatrix(I, 10)) = RA.Fields("idClaveDocapl").Value Then
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							.TextMatrix(I, 7) = VB6.Format(System.Math.Abs(RA.Fields("Apl_valorapl").Value), "########0.00")
						End If
					Next I
					RA.MoveNext()
				Loop 
				
			End If
			'    RA.Close
			'UPGRADE_NOTE: El objeto RA no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			RA = Nothing
		End With
	End Sub
	
	
	'Public Function RecordCtasCobrar(FechaIni As String, FechaFin As String, CodigoCliente As String, CodigoVendedor As String, _
	''        ConCheques As Boolean, ConGarantias As Boolean, Movimiento As Boolean, Orden As String, _
	''        FechaEfectiva As Boolean, CobrarPagar As String) As adodb.Recordset
	'
	'Dim SeleccionGar As String
	'Dim vendedor As String
	'Dim StrSigno As String
	'Dim StrComVen As String
	'Dim Garantias As String
	'Dim Cliente As String
	'Dim LasFechas As String
	'Dim FechEfec As String
	'Dim cod As String
	'Dim cod2 As String
	'Dim SoloMovimiento As String
	'Dim QueOrden As String
	'Dim rs As New adodb.Recordset
	'
	'    If CodigoVendedor > "" Then vendedor = " AND Doc_VenAbre ='" & CodigoVendedor & "' "
	'    If CodigoCliente > "" Then Cliente = " and Doc_codper='" & CodigoCliente & "' "
	'    If FechaEfectiva Then FechEfec = " Doc_FechaEFE " Else FechEfec = " Doc_Fecha "
	'    If ConGarantias = False Then Garantias = " and doc_tipodoc <> 'GAR' "
	'    If FechaFin > "" Then LasFechas = " and " & FechEfec & " <= " & libfec.ArmFormatoFecha(FechaFin) & " "
	'    If FechaIni > "" Then LasFechas = LasFechas & " and " & FechEfec & " >= " & libfec.ArmFormatoFecha(FechaIni) & " "
	'    If CobrarPagar = "C" Then
	'        StrSigno = " AND AdcDoc.doc_Ventas <> 0 "
	'    ElseIf CobrarPagar = "P" Then
	'        StrSigno = " AND AdcDoc.doc_Compras <> 0"
	'    Else
	'        StrSigno = "AND (AdcDoc.doc_Ventas <> 0 OR AdcDoc.doc_Compras <> 0)"
	'    End If
	'
	'    If Movimiento = False Then SoloMovimiento = " where saldodoc <> 0 "
	'    If Orden = "C" Then QueOrden = " order by doc_codper " Else QueOrden = " order by doc_nombreimp "
	'cod = "SELECT TOP 100 PERCENT * FROM (" & _
	''                "SELECT t1.*, adcDoc.Doc_docnombre, AdcDoc.Doc_TipoDoc, AdcDoc.Doc_fecha, AdcDoc.Doc_codper, AdcDoc.Doc_valorabon," & _
	''                   "AdcDoc.Doc_NombreImp, AdcDoc.IdClaveDoc, " & _
	''                   "(AdcDoc.Doc_valor * (CASE substring(adcdocumentos.clave, 8, 1) WHEN '1' THEN 1 WHEN '2' THEN - 1 ELSE 0 END) + t1.TotAbonos) " & _
	''                   " - AdcDoc.Doc_valorabon * (CASE substring(adcdocumentos.clave, 8, 1) WHEN '1' THEN 1 WHEN '2' THEN - 1 ELSE 0 END) AS SaldoDoc," & _
	''                   "AdcDoc.Doc_valor " & _
	''                 "FROM AdcDoc " & _
	''            "left OUTER JOIN AdcDocumentos " & _
	''            "ON AdcDoc.Opc_documento = AdcDocumentos.Opc_documento " & _
	''            "left OUTER JOIN " & _
	''                "(SELECT Apl_sucapli, Apl_docapli, idclavedocapl, SUM(apl_valorapl) AS TotAbonos " & _
	''                    "From AdcDocabonos2 " & _
	''                      "WHERE apl_fecha <= '31/12/2008' AND apl_codbenef <> '' " & _
	''                      "GROUP BY Apl_sucapli, Apl_docapli, idclavedocapl) t1 " & _
	''            "ON AdcDoc.IdClaveDoc = t1.idclavedocapl AND AdcDoc.Doc_sucursal = t1.Apl_sucapli And AdcDoc.Opc_documento = t1.Apl_docapli " & _
	''            " where doc_valor <> 0 " & ConGarantias & SoloMovimiento & Cliente & LasFechas & StrSigno & ") t2 " & _
	''        SoloMovimiento & Orden & ", Doc_fecha, Doc_TipoDoc "
	'
	''Cod2 = " SELECT '" & Emp.SucActual & "' AS SUCURSAL,[AdcIdentNombre.nombrecli] AS nombrecli, " & _
	'''       " Che_vence, CHE_TIPO AS TIPODOC, Che_numero,Che_venabre, " & _
	'''       " Che_Valor, 1 AS SIGNO, Che_codper, Che_Abonos, 0 as abonado, '0:0' AS FECHAAPL , '' AS VENDEDOR ,telefono1" & _
	'''       " From AdcCheques Left  join AdcIdentNombre on ADCCHEQUES.CHE_codper = AdcIdentNombre.Codigo" & _
	'''       " WHERE (Che_Valor <> CHE_ABONOS) and che_vence <=" & libfec.ArmFormatoFecha(FechaFin) & " and che_numero > '' AND Che_Status = 'A' "
	'If rs.State = 1 Then rs.Close
	'If ConCheques Then
	'    rs.Open " TABLE  (" & cod & ") UNION ALL (" & cod2 & ") " & _
	''    " ORDER BY nombrecli,Doc_fecha, Opc_Documento, Doc_Numero " _
	''    , ConxAdcom, adOpenKeyset, adLockOptimistic
	'Else
	'    rs.Open cod, ConxAdcom, adOpenKeyset, adLockOptimistic
	'End If
	'
	'Set RecordCtasCobrar = rs
	'
	'End Function
	
	Public Function CambiarVerdad(ByRef resp As Boolean) As String
		'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(resp) Then
			CambiarVerdad = "No"
		ElseIf resp = True Then 
			CambiarVerdad = "Si"
		Else
			CambiarVerdad = "No"
		End If
	End Function
	
	Public Function RegresarVerdad(ByRef resp As String) As Boolean
		'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(resp) Then
			RegresarVerdad = False
		ElseIf UCase(resp) = "FALSO" Or UCase(resp) = "FALSE" Or resp = "" Or UCase(resp) = "N" Or UCase(resp) = "NO" Then 
			RegresarVerdad = False
		ElseIf UCase(resp) = "SI" Or UCase(resp) = "VERDADERO" Or resp = "True" Or UCase(resp) = "S" Then 
			RegresarVerdad = True
		Else
			RegresarVerdad = False
		End If
	End Function
	
	'+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	'' REPITE METODOS CON MATRICES EN LUGAR DE MALLAS PARA RECONTABILIZACIÓN AUTOMÀTICA
	'+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	
	Public Sub CargarPagosDocumentoRecont(ByRef IdClaveDoc As Double, ByRef TablaPag As String, ByRef Sucursal As String, ByRef Documento As String, ByRef numero As Double, ByRef malla() As String, ByRef MallaCuotas() As String)
		'on error Resume Next
		Dim cod As String
		Dim rspag As New ADODB.Recordset
		Dim SwCuo As Boolean
		Dim RsCuo As New ADODB.Recordset
		Dim JJ, I As Short
		Dim Jcol As Short
		' 0= Efectivo  1= Tarjeta 2= Documento
		' 3= Cheque    4= Credito solo Uno
		' 0  tipo tardocche,1 valor, 2 Descripción, 3 Autoriza, 4 DocInstitucion
		' 5  NumCtaBanco, 6 DocPagoTipo, 7 DocPagoNumero,8 PlanTarjeta ,9 Comisión Tarjeta
		' 10 NroCuotas, 11  Credito =true o false
		' ************************************************
		If IdClaveDoc = 0 Then Exit Sub
		cod = " SELECT * From  " & TablaPag & "  WHERE  doc_sucursal= '" & Sucursal & "' AND  " & " opc_documento='" & Documento & "' AND idclavedoc =" & IdClaveDoc
		
		rspag.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
		rspag.LockType = ADODB.LockTypeEnum.adLockOptimistic
		rspag.Open(cod, ConxAdcom,  ,  , ADODB.CommandTypeEnum.adCmdText)
		If rspag.RecordCount > 0 Then
			With rspag
				I = 0
				ReDim malla(rspag.RecordCount + 1, 30)
				SwCuo = True
				Do While Not .EOF
					I = I + 1
					malla(I, 0) = .Fields("PAG_TIPOPAGO").Value
					malla(I, 2) = .Fields("Pag_Valor").Value
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(.Fields("Pag_descripcion").Value) Then malla(I, 1) = .Fields("Pag_descripcion").Value
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(.Fields("pag_Autoriza").Value) Then malla(I, 3) = .Fields("pag_Autoriza").Value
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(.Fields("pag_Docinstitucion").Value) Then malla(I, 4) = .Fields("pag_Docinstitucion").Value
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(.Fields("pag_NumCtaBanco").Value) Then malla(I, 5) = .Fields("pag_NumCtaBanco").Value
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(.Fields("pag_docpagotipo").Value) Then malla(I, 6) = .Fields("pag_docpagotipo").Value
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(.Fields("pag_DocPagoNumero").Value) Then malla(I, 7) = .Fields("pag_DocPagoNumero").Value
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(.Fields("pag_plantarjeta").Value) Then malla(I, 8) = .Fields("pag_plantarjeta").Value
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(.Fields("pag_comisiontarjeta").Value) Then malla(I, 9) = .Fields("pag_comisiontarjeta").Value
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(.Fields("pag_cuotas").Value) Then malla(I, 10) = .Fields("pag_cuotas").Value
					malla(I, 11) = CStr(libdat.CorrijeNuloN(.Fields("pag_formapago")))
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(.Fields("Pag_InteresTarjeta").Value) Then malla(I, 14) = .Fields("Pag_InteresTarjeta").Value
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(.Fields("Pag_Idpago").Value) Then malla(I, 15) = .Fields("Pag_Idpago").Value
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(.Fields("Pag_Vence").Value) Then malla(I, 18) = .Fields("Pag_Vence").Value
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(.Fields("pag_Beneficiario").Value) Then malla(I, 19) = .Fields("pag_Beneficiario").Value
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(.Fields("pag_docpagosucursal").Value) Then malla(I, 25) = .Fields("pag_docpagosucursal").Value
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If Not IsDbNull(.Fields("IdclaveDocPag").Value) Then malla(I, 26) = .Fields("IdclaveDocPag").Value
					
					
					' 0  tipo tardocche, 1 Descripción,2 valor, 3 Autoriza, 4 DocInstitucion
					' 5  NumCtaBanco, 6 DocPagoTipo, 7 DocPagoNumero,8 PlanTarjeta ,9 Comisión Tarjeta
					' 10 NroCuotas, 11  Credito =true o false, 12 generaingreso, 13 cancelafactura, 14 interes de la tarjeta, 15 Idforma de pago
					' ************************************************
					' Solo unCredito
					JJ = 0
					If .Fields("PAG_TIPOPAGO").Value = "4" Then
						cod = "SELECT * from ADCCUOTAS  Where cuo_docsuc='" & .Fields("Doc_sucursal").Value & "' AND Cuo_DocTipo='" & .Fields("Opc_documento").Value & "' and Cuo_DocNumero =" & .Fields("Doc_numero").Value
						RsCuo.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
						RsCuo.LockType = ADODB.LockTypeEnum.adLockOptimistic
						RsCuo.Open(cod, ConxAdcom,  ,  , ADODB.CommandTypeEnum.adCmdText)
						If RsCuo.EOF = False Then
							ReDim MallaCuotas(RsCuo.RecordCount + 1, 3)
							Do While Not RsCuo.EOF
								JJ = JJ + 1
								'MallaCuotas.Rows = JJ + 1
								MallaCuotas(JJ, 0) = CStr(JJ)
								MallaCuotas(JJ, 1) = RsCuo.Fields("cuo_Valor").Value
								MallaCuotas(JJ, 2) = RsCuo.Fields("Cuo_FechaVence").Value
								RsCuo.MoveNext()
							Loop 
						End If
						RsCuo.Close()
					End If
					I = I + 1
					.MoveNext()
				Loop 
			End With
		End If
		rspag.Close()
	End Sub
End Module