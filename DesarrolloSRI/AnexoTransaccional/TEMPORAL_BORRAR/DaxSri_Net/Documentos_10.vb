Option Strict Off
Option Explicit On
Module Documentos
	' arreglado grabacion de tra con unidad de medida 18/11/2005
	Dim libfec As New DaxLib.DaxLibBases
	Dim libdat As New DaxLib.DaxLibDigDato
	Public DocNuevo As Boolean
	
	Public Sub GuardarAcfMov(ByRef SucDes As String, ByRef Doc As String, ByRef Num As String, ByRef Fec As String, ByRef SucOri As String, ByRef DepOri As String, ByRef DepDes As String, ByRef ResOri As String, ByRef ResDes As String)
		Dim RsAcf As New ADODB.Recordset
		Dim cod As String
		Dim Veces As Integer
		cod = "Select * from AdcAcfMov Where doc_sucursal='" & SucOri & "' and Opc_Documento='" & Doc & "' and Doc_Numero= " & Num
		With RsAcf
			.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
			.LockType = ADODB.LockTypeEnum.adLockOptimistic
			.Open(cod, ConxAdcom,  ,  , ADODB.CommandTypeEnum.adCmdText)
			If .EOF Then .AddNew()
			.Fields("Doc_sucursal").Value = Trim(SucOri)
			.Fields("Opc_documento").Value = Trim(Doc)
			.Fields("Doc_numero").Value = Num
			.Fields("Mac_fecha").Value = Fec
			.Fields("mac_sucorig").Value = Trim(SucDes)
			.Fields("Mac_DepOrig").Value = Trim(DepOri)
			.Fields("Mac_DepDest").Value = Trim(DepDes)
			.Fields("Mac_ResOrig").Value = Trim(ResOri)
			.Fields("Mac_ResDest").Value = Trim(ResDes)
			.Update()
			.Close()
		End With
	End Sub
	
	'UPGRADE_NOTE: Dir se actualizó a Dir_Renamed. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Public Sub Guardar(ByRef IdClaveDoc As Double, ByRef IdClaveDocSop As Double, ByRef NombreTabla As String, ByRef Suc As String, ByRef Doc As String, ByRef Num As Double, ByRef DocNom As String, ByRef DocTip As String, ByRef Fec As Date, ByRef ext As String, ByRef CodUsu As String, ByRef Valor As Double, Optional ByRef CodPer As String = "", Optional ByRef NomI As String = "", Optional ByRef CI As String = "", Optional ByRef Dir_Renamed As String = "", Optional ByRef Telf1 As String = "", Optional ByRef Telf2 As String = "", Optional ByRef Ven As String = "", Optional ByRef PorIva As Double = 0, Optional ByRef ValIva As Double = 0, Optional ByRef TotCiva As Double = 0, Optional ByRef TotSiva As Double = 0, Optional ByRef NomDes1 As String = "", Optional ByRef NomDes2 As String = "", Optional ByRef NomDes3 As String = "", Optional ByRef PorDes1 As Double = 0, Optional ByRef Pordes2 As Double = 0, Optional ByRef PorDes3 As Double = 0, Optional ByRef ValDes1 As Double = 0, Optional ByRef ValDes2 As Double = 0, Optional ByRef ValDes3 As Double = 0, Optional ByRef ValAbo As Double = 0, Optional ByRef Det As String = "", Optional ByRef Bod As String = "", Optional ByRef Departamento As String = "", Optional ByRef DocSop As String = "", Optional ByRef NumSop As Double = 0, Optional ByRef TotDesArt As Double = 0, Optional ByRef TotDesSer As Double = 0, Optional ByRef TotArtCIva As Double = 0, Optional ByRef TotArtSIva As Double = 0, Optional ByRef TotSerCIva As Double = 0, Optional ByRef TotSerSIva As Double = 0, Optional ByRef TotAcf As Double = 0, Optional ByRef contado As Double = 0, Optional ByRef FecEfe As Date = #12:00:00 AM#, Optional ByRef Estado As Double = 0, Optional ByRef Oculto As Double = 0, Optional ByRef Contabilidad As Double = 0, Optional ByRef Banco As Double = 0, Optional ByRef INVENTARIO As Double = 0, Optional ByRef Ventas As Double = 0, Optional ByRef Compras As Double = 0, Optional ByRef Activo As Double = 0, Optional ByRef Adicional1 As Double = 0, Optional ByRef Adicional2 As Double = 0, Optional ByRef NumeroExterno As Double = 0, Optional ByRef NroIdDoc As String = "", Optional ByRef LoteDoc As String = "")
		
		Dim Veces As Integer
		Dim Rs1doc As New ADODB.Recordset
		' para traer departamento y centro de costo unidos y separado por coma
		Dim DepCosto() As String
		Dim ElDepartamento, ElCentro As String
		Dim codsql As String
		Dim resp As String
		DepCosto = Split(Departamento, ",")
		ReDim Preserve DepCosto(2)
		ElDepartamento = DepCosto(0)
		ElCentro = DepCosto(1)
		
		Veces = 0
		On Error Resume Next
PruebaOtraVez: 
		If Rs1doc.State = 1 Then Rs1doc.Close()
		If Veces > 40 Then GoTo yaexiste
		Rs1doc = New ADODB.Recordset
		If IdClaveDoc > 0 Then
			codsql = "SELECT * FROM " & NombreTabla & " WHERE doc_sucursal='" & Suc & "' and opc_documento='" & Doc & "' and idclavedoc =" & IdClaveDoc
		ElseIf DocTip = "FAP" Or Doc = "RTC" Or DocTip = "RTC" Then 
			codsql = "SELECT * FROM " & NombreTabla & " WHERE doc_sucursal='" & Suc & "' and Doc_codper='" & CodPer & "' and opc_documento='" & Doc & "' and doc_numero=" & Num & " and Doc_NroIdDoc = '" & NroIdDoc & "' "
		Else
			codsql = "SELECT * FROM " & NombreTabla & " WHERE doc_sucursal='" & Suc & "' and opc_documento='" & Doc & "' and doc_numero=" & Num
		End If
		
		Rs1doc.Open(codsql, ConxAdcom, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
		If Rs1doc.EOF = False Then
			If DocNuevo Then
				resp = CStr(MsgBox("El documento que intenta grabar ya existe, DESEA SOBREESCRIBIR EL EXISTENTE " & vbCr & "(Si contesta que no se grabará con un nuevo número)", MsgBoxStyle.Critical + MsgBoxStyle.YesNoCancel))
				If resp = CStr(MsgBoxResult.Cancel) Then
					If Rs1doc.State = 1 Then Rs1doc.Close()
					Num = 0
					Exit Sub
				ElseIf resp = CStr(MsgBoxResult.No) Then 
					Num = Num + 1
					Veces = Veces + 1
					GoTo PruebaOtraVez
				ElseIf resp = CStr(MsgBoxResult.Yes) Then 
					DocNuevo = False
				End If
			End If
		End If
		
		If DocNuevo Or Rs1doc.EOF Then Rs1doc.AddNew() : IdClaveDoc = 0
GraboOtro: 
		With Rs1doc
			.Fields("Doc_sucursal").Value = Trim(Suc)
			.Fields("Doc_Bodega").Value = Trim(Bod)
			.Fields("Opc_documento").Value = Trim(Doc)
			.Fields("Doc_numero").Value = Num
			.Fields("Doc_docnombre").Value = Trim(DocNom)
			.Fields("Doc_TipoDoc").Value = Trim(DocTip)
			.Fields("Doc_DocSop").Value = DocSop
			.Fields("Doc_NumSop").Value = libdat.CorrijeNuloN(NumSop)
			If IsDate(Fec) Then .Fields("Doc_fecha").Value = Fec Else .Fields("Doc_fecha").Value = Now
			If IsDate(FecEfe) Then .Fields("Doc_FechaEfe").Value = FecEfe Else .Fields("Doc_FechaEfe").Value = .Fields("Doc_fecha").Value
			.Fields("Doc_Hora").Value = TimeOfDay
			'!Doc_Extension = TRIM$(ext)
			.Fields("Doc_codper").Value = Trim(CodPer)
			.Fields("Doc_codusu").Value = Mid(Trim(CodUsu), 1, 12)
			.Fields("Doc_venabre").Value = Trim(Ven)
			.Fields("Doc_porceniva").Value = PorIva
			.Fields("Doc_valoriva").Value = ValIva
			.Fields("Doc_totciva").Value = TotCiva
			.Fields("Doc_totsiva").Value = TotSiva
			.Fields("Doc_nombredes1").Value = Trim(NomDes1)
			.Fields("Doc_nombredes2").Value = Trim(NomDes2)
			.Fields("Doc_nombredes3").Value = Trim(NomDes3)
			.Fields("Doc_nombredes4").Value = Nothing 'TRIM$(NomDes4)
			.Fields("Doc_porcendes1").Value = PorDes1
			.Fields("Doc_porcendes2").Value = Pordes2
			.Fields("Doc_porcendes3").Value = PorDes3
			.Fields("Doc_porcendes4").Value = 0 'PorDes4
			.Fields("Doc_valordes1").Value = ValDes1
			.Fields("Doc_valordes2").Value = ValDes2
			.Fields("Doc_valordes3").Value = ValDes3
			.Fields("Doc_ValorDes4").Value = 0 'ValDes4
			.Fields("Doc_valor").Value = Valor
			.Fields("Doc_valorabon").Value = ValAbo
			.Fields("Doc_detalle").Value = Trim(Det)
			.Fields("Doc_NombreImp").Value = Trim(NomI)
			.Fields("Doc_CiRuc").Value = Trim(CI)
			.Fields("Doc_Direccion").Value = Trim(Dir_Renamed)
			.Fields("Doc_Telefono1").Value = Trim(Telf1)
			.Fields("Doc_Telefono2").Value = Trim(Telf2)
			.Fields("Doc_DepDes").Value = Trim(ElDepartamento)
			.Fields("Doc_TotDesArt").Value = TotDesArt
			.Fields("Doc_TotDesSer").Value = TotDesSer
			.Fields("Doc_TotArtCIva").Value = TotArtCIva
			.Fields("Doc_TotArtSIva").Value = TotArtSIva
			.Fields("Doc_TotSerCIva").Value = TotSerCIva
			.Fields("Doc_TotSerSIva").Value = TotSerSIva
			.Fields("Doc_TotAcf").Value = TotAcf
			.Fields("Doc_Contado").Value = contado
			
			.Fields("Doc_Estado").Value = Estado
			.Fields("Doc_Oculto").Value = Oculto
			.Fields("Doc_Contabilidad").Value = Contabilidad
			.Fields("Doc_Banco").Value = Banco
			.Fields("Doc_Inventario").Value = INVENTARIO
			.Fields("Doc_Ventas").Value = Ventas
			.Fields("Doc_Compras").Value = Compras
			.Fields("Doc_Activo").Value = Activo
			.Fields("Doc_Adicional1").Value = Adicional1
			.Fields("Doc_Adicional2").Value = Adicional2
			.Fields("Doc_NumeroExterno").Value = NumeroExterno
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto libdat.CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Fields("Doc_NroIdDoc").Value = libdat.CorrijeNulo(NroIdDoc)
			'        If Banco Then
			'           !Doc_SaldoActualCli = SaldoCliente(TRIM$(CodPer), suc, Str(Fec))
			'           !Doc_SaldoFinalCli = !Doc_SaldoActualCli - Valor
			'        End If
			.Fields("Doc_CentroCosto").Value = ElCentro
			.Fields("IdClaveDocSop").Value = IdClaveDocSop
			.Fields("Doc_FechaModifica").Value = Now
			If IdClaveDoc = 0 Then
				.Fields("IdClaveDoc").Value = NumeroClave(NombreTabla, Suc, Doc, Num)
			End If
			.Fields("Doc_NroLoteDoc").Value = LoteDoc
			IdClaveDoc = .Fields("IdClaveDoc").Value
			.Update()
			.Close()
		End With
		If Veces > 0 Then MsgBox("El número del documento ya existe..el nuevo número asignado es " & Num & " ", MsgBoxStyle.Information)
		Exit Sub
		'If Banco = 0 And Contabilidad = 1 And DocTip <> "DIA" And DocTip <> "NCC" And DocTip <> "NDC" And DocTip <> "NCP" And DocTip <> "NDP" Then GuardarDiaDeInv suc, doc, NUM, Fec, valor, ValIva, TotSiva, TotCiva, _
		'ValDes1 + ValDes2 + ValDes3 + ValDes4, TotDesArt + TotDesSer, TotSiva + TotCiva, TotArtSIva + TotArtCIva, TotSerCIva
yaexiste: 
		Num = Num + 1
		Veces = Veces + 1
		If Veces > 40 Then MsgBox("El Documento no pudo ser guardado, intente con otro número", MsgBoxStyle.Critical) : Num = 0 : Exit Sub
		'GoTo GraboOtro
	End Sub
	
	Public Sub EliminarING(ByRef Doc As String, ByRef Num As Double, ByRef IdClaveDocSop As Double)
		Dim RsDoc As New ADODB.Recordset
		Dim RsApl As New ADODB.Recordset
		Dim cod As String
		cod = "SELECT * FROM AdcDoc WHERE Doc_DocSop='" & Doc & "' AND Doc_Sucursal='" & Emp.SucActual & "' AND IdClaveDocSop = " & IdClaveDocSop & " AND Doc_TipoDoc='GAR'"
		RsDoc.Open(cod, ConxAdcom, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
		Do While Not RsDoc.EOF
			RsDoc.Fields("Doc_DocSop").Value = Nothing
			RsDoc.Fields("Doc_NumSop").Value = 0
			'        rsodc!Doc_detalle =empty
			RsDoc.Fields("IdClaveDocSop").Value = 0
			RsDoc.Update()
			cod = "SELECT * FROM AdcApl WHERE Opc_Documento='" & Doc & "' AND Doc_Sucursal='" & Emp.SucActual & "' AND IdClaveDoc =" & IdClaveDocSop
			RsApl.Open(cod, ConxAdcom, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
			Do While Not RsApl.EOF
				RsApl.Fields("Opc_documento").Value = RsApl.Fields("Apl_DocGar").Value
				RsApl.Fields("Doc_numero").Value = RsApl.Fields("Apl_NumGar").Value
				RsApl.Fields("IdClaveDoc").Value = RsApl.Fields("IdClaveDocgar").Value
				RsApl.Fields("Apl_docfecha").Value = RsDoc.Fields("Doc_fecha").Value
				RsApl.Fields("Apl_DocGar").Value = Nothing
				RsApl.Fields("Apl_NumGar").Value = -1
				RsApl.Fields("IdClaveDocgar").Value = 0
				RsApl.Fields("CodConcepto").Value = Nothing
				RsApl.Update()
				RsApl.MoveNext()
			Loop 
			RsDoc.MoveNext()
			RsApl.Close()
		Loop 
		RsDoc.Close()
	End Sub
	
	Public Sub GuardarPagos(ByRef IdClaveDoc As Double, ByRef tabla As String, ByRef Sucursal As String, ByRef Documento As String, ByRef numero As String, ByRef fecha As String, ByRef ClasePagos As DocPagos, ByRef ValorDoc As Double, Optional ByRef Cliente As String = "", Optional ByRef NomCli As String = "")
		'UPGRADE_ISSUE: Pago objeto no se actualizó. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
		Dim rspag As New ADODB.Recordset
		Dim pagos As New Pago
		Dim ClasePag As New DocPagos
		Dim I As Short
		Dim RsDiaE As New ADODB.Recordset
		Dim Cuotas As New Cuota
		Dim RsCuo As New ADODB.Recordset
		Dim ValorOtro As Double
		Dim Sw As Boolean
		Dim Extencion, ClaveDoc As String
		Dim QueNum As Double
		'UPGRADE_ISSUE: Opcdoc objeto no se actualizó. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
		Dim OpOpc As New Opcdoc
		Dim TablaCuotas As String
		Dim TipoDoc As String
		Dim COMM As String
		On Error Resume Next
		If Mid(tabla, 1, 6) <> "AdcPag" Then MsgBox("Error en tabla de pagos: " & tabla) : Exit Sub
		ConxAdcom.Execute("DELETE FROM " & tabla & " WHERE doc_sucursal = '" & Sucursal & "' AND opc_documento='" & Documento & "'  and IdClaveDoc=" & IdClaveDoc)
		ConxAdcom.Execute("DELETE FROM ADCCHEQUES WHERE CHE_DOCSOP = '" & Documento & "' and CHE_NUMSOP = '" & IdClaveDoc & "' AND CHE_SUCSOP = '" & Sucursal & "'")
		
		ClasePag = ClasePagos
		OpOpc = New Opcdoc
		Sw = False
		If tabla = "AdcPagPro" Then TablaCuotas = "AdcCuotasPro" Else TablaCuotas = "AdcCuotas"
		ValorOtro = 0
		On Error GoTo 0
		rspag = New ADODB.Recordset
		rspag.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
		rspag.LockType = ADODB.LockTypeEnum.adLockOptimistic
		rspag.Open(tabla, ConxAdcom,  ,  , ADODB.CommandTypeEnum.adCmdTable)
		With rspag
			For I = 1 To ClasePag.CountPagos
				pagos = ClasePag.ItemPago(I)
				Sw = True
				.AddNew()
				.Fields("Doc_sucursal").Value = Sucursal
				.Fields("Opc_documento").Value = Documento
				.Fields("Doc_numero").Value = numero
				.Fields("Doc_fecha").Value = fecha
				.Fields("pag_numero").Value = I
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.TipoPag. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Fields("PAG_TIPOPAGO").Value = pagos.TipoPag
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.Descripcion. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Fields("Pag_descripcion").Value = pagos.Descripcion
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.Valor. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Fields("Pag_Valor").Value = pagos.Valor
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.DocInstitucion. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Fields("pag_Docinstitucion").Value = pagos.DocInstitucion
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.DocPagoTipo. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Fields("pag_docpagotipo").Value = pagos.DocPagoTipo
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.DocPagoNumero. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Fields("pag_DocPagoNumero").Value = pagos.DocPagoNumero
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.NumCtaBanco. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Fields("pag_NumCtaBanco").Value = pagos.NumCtaBanco
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.PlanTarjeta. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Fields("pag_plantarjeta").Value = pagos.PlanTarjeta
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.ComisionTarjeta. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Fields("pag_comisiontarjeta").Value = pagos.ComisionTarjeta
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.autoriza. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Fields("pag_Autoriza").Value = pagos.autoriza
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.NroCuotas. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Fields("pag_cuotas").Value = pagos.NroCuotas
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.PagoACredito. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Fields("pag_formapago").Value = IIf(pagos.PagoACredito = 2, 2, 1)
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.InteresTarjeta. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Fields("Pag_InteresTarjeta").Value = pagos.InteresTarjeta
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.IdFormaDePago. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Fields("Pag_Idpago").Value = pagos.IdFormaDePago
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.FechaVence. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: IsEmpty se actualizó a IsNothing y tiene un nuevo comportamiento. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
				'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.FechaVence. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If IsDbNull(pagos.FechaVence) Or IsNothing(pagos.FechaVence) Then pagos.FechaVence = fecha
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.FechaVence. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Fields("Pag_Vence").Value = pagos.FechaVence
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.Beneficiario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Fields("pag_Beneficiario").Value = pagos.Beneficiario
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.Valor. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ValorOtro = ValorOtro + pagos.Valor
				.Fields("IdClaveDoc").Value = IdClaveDoc
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.RetencionTarjeta. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Fields("Pag_Retencion").Value = pagos.RetencionTarjeta
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.RetIva. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Fields("Pag_RetIva").Value = pagos.RetIva
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.TipoRetencioIva. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Fields("Pag_TipoRet").Value = pagos.TipoRetencioIva
				.Fields("PAG_STATUS").Value = "R"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.IdclavedocPago. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Fields("IdclaveDocPag").Value = pagos.IdclavedocPago
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.DocPagoSucursal. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Fields("pag_docpagosucursal").Value = pagos.DocPagoSucursal
				.Update()
				
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.TipoPag. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If pagos.TipoPag = "5" Then
					'                OpOpc.Cargar pagos.IdFormaDePago
					'                TipoDoc = OpOpc.TipoDoc
					'                Extencion = OpOpc.Extenciones
					'                ClaveDoc = OpOpc.ClaveDoc
					'                QueNum = val(pagos.DocPagoNumero)
					'                DocNuevo = 1
					If RsDiaE.State = 1 Then RsDiaE.Close()
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.NumCtaBanco. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.DocPagoNumero. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.IdFormaDePago. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					RsDiaE.Open("select * FROM ADCCHEQUES WHERE CHE_TIPO = '" & pagos.IdFormaDePago & "'  " & " AND CHE_NUMERO = '" & pagos.DocPagoNumero & "' AND CHE_NUMCTABANCO = '" & pagos.NumCtaBanco & "'", ConxAdcom, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
					With RsDiaE
						If RsDiaE.EOF Then .AddNew()
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.IdFormaDePago. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						.Fields("Che_Tipo").Value = pagos.IdFormaDePago
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.DocPagoNumero. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						.Fields("Che_numero").Value = pagos.DocPagoNumero
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.NumCtaBanco. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						.Fields("Che_NumCtaBanco").Value = pagos.NumCtaBanco
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.DocInstitucion. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						.Fields("Che_DocInstitucion").Value = pagos.DocInstitucion
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.Beneficiario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						.Fields("Che_Beneficiario").Value = pagos.Beneficiario
						.Fields("Che_Fecha").Value = fecha
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.FechaVence. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						.Fields("Che_Vence").Value = pagos.FechaVence
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.Valor. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						.Fields("che_valor").Value = pagos.Valor
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto pagos.autoriza. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						.Fields("Che_Autoriza").Value = pagos.autoriza
						.Fields("Che_SucSOP").Value = Sucursal
						.Fields("Che_DocSop").Value = Documento
						.Fields("Che_NumSop").Value = numero
						.Fields("Che_codper").Value = Cliente
						.Fields("Che_venabre").Value = Nothing
						.Fields("Che_detalle").Value = Nothing
						.Fields("Che_NombreImp").Value = NomCli
						.Fields("Che_CiRuc").Value = Nothing
						.Fields("Che_Status").Value = "A"
						.Fields("Che_NroDif").Value = 0
						.Fields("Che_FecDif").Value = libdat.CorrijeNuloF("")
						.Fields("che_abonos").Value = 0
						.Fields("Che_AboNro").Value = Nothing
						.Fields("che_efectivo").Value = 0
						.Fields("Che_FechaDep").Value = libdat.CorrijeNuloF("")
						.Fields("Che_FechaAbono").Value = libdat.CorrijeNuloF("")
						.Fields("IdClaveDocSop").Value = IdClaveDoc
						.Update()
						.Close()
					End With
				End If
				
				'                Guardar "AdcDoc", Sucursal, "CHP", QueNum, OpOpc.nombre, OpOpc.TipoDoc, CDate(fecha), _
				''                       "", ControlUsuario.nombre, cdbl(pagos.valor), Cliente, NomCli, "", , "", "", "", _
				''                       , , , , , , , , , , , , , , , , , "", , , pagos.DocPagoTipo _
				''                       , pagos.DocPagoNumero, , , , , , , , , CDate(pagos.FechaVence), _
				''                       ArmarExtencionDocumento(Extencion, ClaveDoc, , 1), _
				''                       ArmarExtencionDocumento(Extencion, ClaveDoc, , 2), ArmarExtencionDocumento(Extencion, ClaveDoc, , 3), ArmarExtencionDocumento(Extencion, ClaveDoc, , 4), _
				''                       ArmarExtencionDocumento(Extencion, ClaveDoc, , 5), ArmarExtencionDocumento(Extencion, ClaveDoc, , 6), _
				''                       ArmarExtencionDocumento(Extencion, ClaveDoc, , 7), ArmarExtencionDocumento(Extencion, ClaveDoc, , 8)
				'
			Next I
			.Close()
		End With
		COMM = "update adcpag set pag_vence = dv.vencimiento from("
		COMM = COMM & " select dateadd(day,case isnull(diascuotafijas,0) when 0 then diascuotavar0 else diascuotafijas end, doc_fecha) as vencimiento,*"
		COMM = COMM & " from adcpag left join formasdepago"
		COMM = COMM & " on adcpag.pag_idpago = formasdepago.idformasdepago"
		COMM = COMM & " Where pag_formapago = 2 And (diascuotafijas > 0 Or diascuotavar0 > 0)"
		COMM = COMM & " and doc_sucursal = '" & Sucursal & "' AND opc_documento='" & Documento & "'  and IdClaveDoc=" & IdClaveDoc
		COMM = COMM & " ) dv"
		COMM = COMM & " Where dv.Doc_sucursal = adcpag.Doc_sucursal And dv.Opc_documento = adcpag.Opc_documento And dv.IdClaveDoc = adcpag.IdClaveDoc And dv.pag_numero = adcpag.pag_numero "
		COMM = COMM & " and adcpag.doc_sucursal = '" & Sucursal & "' AND adcpag.opc_documento='" & Documento & "'  and adcpag.IdClaveDoc=" & IdClaveDoc
		ConxAdcom.Execute(COMM)
		If tabla = "AdcPagPro" Then Exit Sub
		ConxAdcom.Execute("DELETE  FROM " & TablaCuotas & " WHERE Cuo_DocSuc= '" & Sucursal & "' AND Cuo_DocTipo='" & Documento & "'  and idclavedoc=" & IdClaveDoc)
		If RsCuo.State = 1 Then RsCuo.Close()
		'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(RsCuo.Fields) Then Exit Sub
		If ClasePag.CountCuotas = 0 Then GoTo terminando
		'PROPIEDADES QUE PERMITEN ABRIR Y AGREGAR O QUITAR UN NUEVO REGISTRO A UNA TABLA
		
		RsCuo.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
		RsCuo.LockType = ADODB.LockTypeEnum.adLockOptimistic
		RsCuo.Open(TablaCuotas, ConxAdcom,  ,  , ADODB.CommandTypeEnum.adCmdTable)
		With RsCuo
			For I = 1 To ClasePag.CountCuotas
				Cuotas = ClasePag.ItemCuota(I)
				If Cuotas.Valor <> 0 Then
					.AddNew()
					.Fields("Cuo_DocSuc").Value = Sucursal
					.Fields("Cuo_DocTipo").Value = Documento
					.Fields("Cuo_DocNumero").Value = numero
					.Fields("cuo_Numero").Value = I
					.Fields("cuo_Valor").Value = Cuotas.Valor
					.Fields("Cuo_FechaVence").Value = Cuotas.FechaVence
					.Fields("IdClaveDoc").Value = IdClaveDoc
					.Update()
				End If
			Next I
			.Close()
		End With
		
		
		
terminando: 
		'ClasePag.Cls
		
	End Sub
	
	
	'Public Sub GuardarAutorizaciones(LaAutorizacion As AutorizacionSri)
	'Dim rs As New ADODB.Recordset
	'If LaAutorizacion Is Nothing Then Exit Sub
	'With LaAutorizacion
	'rs.Open "select * from autorizaciones where NroAutorizacion = '" & .AutNroAut & "' and CodigoProveedor = '" & .AutCiRuc & _
	''    "' and TipoComprobante = '" & .AutTipDocSri & "' AND SerieComprobante = '" & .AutIdEstab & _
	''    "' AND SerieCPbteEmision = '" & .AutIdPtoVta & "'", ConxSri, adOpenKeyset, adLockOptimistic
	''rs.Open "autorizaciones", ConxSri, adOpenKeyset, adLockOptimistic, adCmdTable
	'If rs.EOF Then rs.AddNew
	'        rs!CodigoProveedor = .AutCiRuc
	'        rs!TipoComprobante = .AutTipDocSri
	'        rs!SerieComprobante = .AutIdEstab
	'        rs!SerieCPbteEmision = .AutIdPtoVta
	'        rs!NumeroInicial = .AutNroIni
	'        rs!NumeroFinal = .AutNroFin
	'        rs!NroAutorizacion = .AutNroAut
	'        rs!FechaTope = .AutFechaVence
	'        rs.Update
	'rs.Close
	'End With
	'End Sub
	
	Public Sub AnularDocumento(ByRef IdClaveDoc As Double, ByRef Suc As String, ByRef Doc As String, ByRef Num As Double)
		Dim cod As String
		Dim Rs1doc As ADODB.Recordset
		Dim Motivo As String
		Rs1doc = New ADODB.Recordset
		On Error Resume Next
		Motivo = InputBox("Registre el motivo porqué se anula el documento:", "ANULACION DE DOCUMENTO", "NO REGISTRA MOTIVO")
		cod = "SELECT * FROM AdcDoc WHERE doc_sucursal='" & Suc & "' and opc_documento='" & Doc & "' and IdClaveDoc=" & IdClaveDoc
		Rs1doc.Open(cod, ConxAdcom, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
		If Rs1doc.EOF Then Exit Sub
		With Rs1doc
			.Fields("Doc_Estado").Value = 0
			.Fields("Doc_valor").Value = 0
			.Fields("Doc_porceniva").Value = 0
			.Fields("Doc_valoriva").Value = 0
			.Fields("Doc_totciva").Value = 0
			.Fields("Doc_totsiva").Value = 0
			.Fields("Doc_porcendes1").Value = 0
			.Fields("Doc_porcendes2").Value = 0
			.Fields("Doc_porcendes3").Value = 0
			.Fields("Doc_porcendes4").Value = 0
			.Fields("Doc_valordes1").Value = 0
			.Fields("Doc_valordes2").Value = 0
			.Fields("Doc_valordes3").Value = 0
			.Fields("Doc_ValorDes4").Value = 0
			.Fields("Doc_valorabon").Value = 0
			.Fields("MotivoAnulacion").Value = Motivo
			.Fields("doc_Doc_FechaModifica").Value = Today
			.Update()
			.Close()
		End With
		AnularContabilidad(IdClaveDoc, Suc, Doc, Num)
		
	End Sub
	
	Public Function AnularContabilidad(ByRef IdClaveDoc As Double, ByRef Suc As String, ByRef Doc As String, ByRef Num As Double) As Boolean
		Dim cod As String
		Dim Rs1doc As New ADODB.Recordset
		cod = "SELECT * FROM AdcDia WHERE doc_sucursal='" & Suc & "' and opc_documento='" & Doc & "' and IdClaveDoc=" & IdClaveDoc
		Rs1doc.Open(cod, ConxAdcom, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
		With Rs1doc
			If Not .EOF Then
				Do While Not .EOF
					.Fields("Dia_signo").Value = 0
					.Fields("Dia_valor").Value = 0
					'                !Dia_detalle = "ANULADO"
					.Update()
					.MoveNext()
				Loop 
			End If
			.Close()
		End With
		PonerHistorico("CTB Se anula contabilidad ", (ControlUsuario.Nombre), Today, Suc, Doc, Num)
		AnularContabilidad = True
	End Function
	
	Public Function eliminardocumento(ByRef IdClaveDoc As Double, ByRef tabla As String, ByRef Bod As String, ByRef Doc As String, ByRef Num As Double, Optional ByRef Sucu As String = "") As Boolean
		Dim RegHisOpc As Object
		Dim sel As String
		Dim codsql As String
		
		On Error Resume Next
		eliminardocumento = False
		If Trim("" & Sucu) <> "" Then
			sel = "doc_Sucursal='" & Sucu & "' "
		Else
			sel = "doc_Sucursal='" & Emp.SucActual & "' "
		End If
		'If Bod <> "" Then SEL = SEL & "and doc_bodega='" & Bod & "' "
		If IdClaveDoc <> 0 Then
			codsql = "DELETE  FROM " & tabla & " WHERE " & sel & " AND opc_documento='" & Doc & "'  and IdClaveDoc=" & IdClaveDoc
			ConxAdcom.Execute(codsql)
			eliminardocumento = True
		End If
		'PROPIEDADES QUE PERMITEN ABRIR Y AGREGAR O QUITAR UN NUEVO REGISTRO A UNA TABLA
		'UPGRADE_ISSUE: RegHisOpc.AdcHistOpc objeto no se actualizó. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
		Dim reghis As RegHisOpc.AdcHistOpc = New RegHisOpc.AdcHistOpc
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto reghis.GrabarAuditoria. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		reghis.GrabarAuditoria("", ControlUsuario.Identifica, Sistema.Value, "", "DocComercialInv", "Eliminar Documento", tabla & " " & sel & " sucActual: " & Emp.SucActual & " " & Doc & " nro: " & Num & " id: " & IdClaveDoc)
		'UPGRADE_NOTE: El objeto reghis no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		reghis = Nothing
		'GrabarAuditoria(ByVal Str As String, ByVal Usuario As String, ByVal Rsistm As String, ByVal Rmaq As String, ByVal Rmodulo As String, ByVal Rprocess As String, ByVal Valor As String, Optional ByVal Rfecha As DateTime = #1/1/1900#)
	End Function
	
	'Public Function eliminarAplFac(IdClaveDoc As Double, Suc As String, Doc As String, Num As Double) As Boolean
	'Dim sel As String
	'Dim codsql As String
	'    codsql = "DELETE FROM AdcApl WHERE Apl_SucApli='" & Suc & "' AND Apl_docApli='" & Doc & "' " & sel & " AND IdClaveDoc=" & IdClaveDoc
	'    ConxAdcom.Execute (codsql)
	'    eliminarAplFac = True
	'
	'End Function
	
	Public Sub EliminarDocAdjuntos(ByRef DocSuc As String, ByRef DocTip As String, ByRef DocNumero As String, ByRef IdClaveDoc As Double)
		Dim ssql As String
		ssql = "DELETE From dbo.AdcDoc"
		ssql = ssql & " WHERE  Doc_DocSop = '" & DocTip & "' AND Doc_NumSop = " & DocNumero
		ConxAdcom.Execute(ssql)
	End Sub
	
	
	Public Function EliminarSucDocNumAcf(ByRef IdClaveDoc As Double, ByRef Suc As String, ByRef Doc As String, ByRef Num As Double) As Boolean
		Dim sel As String
		Dim codsql As String
		codsql = "DELETE FROM  adcDoc WHERE doc_sucursal='" & Suc & "'  and opc_documento='" & Doc & "' and IdClaveDoc=" & IdClaveDoc
		'PROPIEDADES QUE PERMITEN ABRIR Y AGREGAR O QUITAR UN NUEVO REGISTRO A UNA TABLA
		ConxAdcom.Execute(codsql)
		EliminarSucDocNumAcf = True
	End Function
	
	Public Sub EliminarRegistro(ByRef IdClaveDoc As Double, ByRef Suc As String, ByRef Doc As String, ByRef Num As Double)
		Dim RegHisOpc As Object
		Dim codsql As String
		'UPGRADE_ISSUE: RegHisOpc.AdcHistOpc objeto no se actualizó. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
		Dim reghis As RegHisOpc.AdcHistOpc = New RegHisOpc.AdcHistOpc
		If IdClaveDoc <> 0 Then
			codsql = "DELETE  FROM AdcDia WHERE doc_sucursal='" & Suc & "' and opc_documento='" & Doc & "' and IdClaveDoc=" & IdClaveDoc
			'PROPIEDADES QUE PERMITEN ABRIR Y AGREGAR O QUITAR UN NUEVO REGISTRO A UNA TABLA
			ConxAdcom.Execute(codsql)
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto reghis.GrabarAuditoria. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			reghis.GrabarAuditoria("", ControlUsuario.Identifica, Sistema.Value, "", moduloActual, "Eliminar Documento", "adcdia" & " " & Suc & " sucActual: " & Emp.SucActual & " " & Doc & " nro: " & Num & " id: " & IdClaveDoc)
			'UPGRADE_NOTE: El objeto reghis no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			reghis = Nothing
		End If
	End Sub
	
	Public Function GuardarDia(ByRef IdClaveDoc As Double, ByRef Malla As Object, ByRef Suc As String, ByRef Doc As String, ByRef Num As Double, ByRef Fec As Date, Optional ByRef Ccosto As String = "", Optional ByRef Manual As String = "", Optional ByRef Predefinido As String = "") As Boolean
		Dim I As Short
		Dim Rs1doc As New ADODB.Recordset
		Dim cod As String
		Dim TotalReg As Integer
		On Error Resume Next
		Dim Debitos, Creditos As Double
		'UPGRADE_ISSUE: ColClasificador objeto no se actualizó. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
		Dim ColClasifica As New ColClasificador
		'UPGRADE_ISSUE: clasificador objeto no se actualizó. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
		Dim CampClasifica As New clasificador
		'Dim CamClasifica As New Clasificador
		'UPGRADE_ISSUE: ClasificaCtb objeto no se actualizó. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
		Dim cca As New ClasificaCtb
		Dim tabla As String
		Dim cl As Short
		Dim Campo As String
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Cols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Malla.Cols < 52 Then Malla.Cols = 52
		tabla = "Adcdia"
		If Predefinido > "" Then
			tabla = "EstandarDia"
			cod = "SELECT * FROM " & tabla & " WHERE est_documento='" & Predefinido & "' "
			ConxAdcom.Execute("delete from estandardia WHERE est_documento='" & Predefinido & "' ")
		Else
			cod = "SELECT * FROM " & tabla & " WHERE doc_sucursal='" & Suc & "' and opc_documento='" & Doc & "' and IdClaveDoc=" & IdClaveDoc
			EliminarRegistro(IdClaveDoc, Suc, Doc, Num)
		End If
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto cca.Cargar. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ColClasifica = cca.Cargar
		
		Rs1doc = New ADODB.Recordset
		
		Rs1doc.Open(cod, ConxAdcom, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
		TotalReg = 0
		Debitos = 0
		Creditos = 0
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.FixedRows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Malla.Rows - 1 > Malla.FixedRows Then
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.FixedRows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			For I = Malla.FixedRows To (Malla.Rows - 1)
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Malla.TextMatrix(I, 1) > "" And (Val(Malla.TextMatrix(I, 4)) > 0 Or Val(Malla.TextMatrix(I, 5)) > 0) Then
					With Rs1doc
						TotalReg = TotalReg + 1
						.AddNew()
						If tabla = "Adcdia" Then
							.Fields("Doc_sucursal").Value = Suc
							.Fields("Opc_documento").Value = Doc
							.Fields("Doc_numero").Value = Num
							.Fields("DIA_STATUS").Value = Manual
							.Fields("IdClaveDoc").Value = IdClaveDoc
							If IsDate(Fec) Then .Fields("DIA_FECHA").Value = VB6.Format(Fec, "dd/mm/yyyy") Else .Fields("DIA_FECHA").Value = VB6.Format(Now, "dd/mm/yyyy")
						Else
							.Fields("Est_Documento").Value = Predefinido
						End If
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.FixedRows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						.Fields("Dia_Linea").Value = I + 1 - Malla.FixedRows
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						.Fields("CTA_CODIGO").Value = Malla.TextMatrix(I, 1)
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						.Fields("Dia_ctanombre").Value = Malla.TextMatrix(I, 2)
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						.Fields("Dia_detalle").Value = Malla.TextMatrix(I, 3)
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If CDbl(Val(Malla.TextMatrix(I, 4))) > 0 Then
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							If IsNumeric(Malla.TextMatrix(I, 4)) Then .Fields("Dia_valor").Value = CDbl(Malla.TextMatrix(I, 4))
							.Fields("Dia_signo").Value = "1"
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							Debitos = Debitos + Val(Malla.TextMatrix(I, 4))
						Else
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							If IsNumeric(Malla.TextMatrix(I, 5)) Then .Fields("Dia_valor").Value = CDbl(Malla.TextMatrix(I, 5))
							.Fields("Dia_signo").Value = "-1"
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							Creditos = Creditos + Val(Malla.TextMatrix(I, 5))
						End If
						'        If malla.Cols > 6 Then !Dia_Costo = libdat.CorrijeNulo(malla.TextMatrix(i, 6))
						'        If malla.Cols > 7 Then !Dia_empleado = libdat.CorrijeNulo(malla.TextMatrix(i, 7))
						'        If malla.Cols > 8 Then !Dia_departamento = libdat.CorrijeNulo(malla.TextMatrix(i, 8))
						'        If malla.Cols > 9 Then !Dia_Centroproduccion = libdat.CorrijeNulo(malla.TextMatrix(i, 9))
						'        If malla.Cols > 10 Then !Dia_zona = libdat.CorrijeNulo(malla.TextMatrix(i, 10))
						'        If malla.Cols > 11 Then !Dia_Producto = libdat.CorrijeNulo(malla.TextMatrix(i, 11))
						'        If malla.Cols > 12 Then !Dia_articulo = libdat.CorrijeNulo(malla.TextMatrix(i, 12))
						'        If malla.Cols > 13 Then !Dia_Proyecto = libdat.CorrijeNulo(malla.TextMatrix(i, 13))
						'        If malla.Cols > 14 Then !Dia_esempleado = IIf(UCASE$(libdat.CorrijeNulo(malla.TextMatrix(i, 14))) = "S", 1, 0)
						'        If malla.Cols > 15 Then !Dia_esrelacionado = IIf(UCASE$(libdat.CorrijeNulo(malla.TextMatrix(i, 15))) = "S", 1, 0)
						'        If malla.Cols > 16 Then !Dia_rubros = libdat.CorrijeNulo(malla.TextMatrix(i, 16))
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ColClasifica.Count. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If ColClasifica.Count > 0 Then
							For cl = 26 To 50
								'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto libdat.CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								Campo = libdat.CorrijeNulo(Malla.TextMatrix(I, cl))
								If Campo > "" Then
									'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
									'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ColClasifica.Item. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
									CampClasifica = ColClasifica.Item("C" & Trim(Malla.TextMatrix(0, cl)))
									'                            'Debug.Print CampClasifica.campodia
									'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CampClasifica.campodia. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
									If CampClasifica.campodia > "" Then .Fields(CampClasifica.campodia).Value = Campo
									'                            'Debug.Print .Fields(CampClasifica.campodia)
								End If
							Next cl
						End If
						.Update()
						
					End With
				End If
			Next 
			Rs1doc.Close()
			ConxAdcom.Execute("update adcdoc set Dia_Status='" & Manual & "' where Doc_sucursal='" & Suc & "' AND Opc_documento ='" & Doc & "' and idclavedoc = " & IdClaveDoc)
			Debitos = System.Math.Round(Debitos, 2) - System.Math.Round(Creditos, 2)
			If Debitos <> 0 Then
				PonerHistorico("CTBComprobante descuadrado ", (ControlUsuario.Nombre), Today, Suc, Doc, Num, Debitos)
			End If
		End If
		If TotalReg = 0 Then
			PonerHistorico("CTBComprobante sin contabilidad ", (ControlUsuario.Nombre), Today, Suc, Doc, Num, 0)
		End If
		'UPGRADE_NOTE: El objeto ColClasifica no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		ColClasifica = Nothing
		'Set CamClasifica = Nothing
		'UPGRADE_NOTE: El objeto cca no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		cca = Nothing
		
	End Function
	
	
	Public Sub GuardarTra(ByRef IdClaveDoc As Double, ByVal Malla As Object, ByRef NombreTablaTra As String, ByRef TablaSerie As String, ByRef Suc As String, ByRef Doc As String, ByRef Num As Double, ByRef TipDoc As String, ByRef Fec As Date, ByRef ext As String, ByRef valo As Double, Optional ByRef numP As String = "", Optional ByRef Desd As String = "", Optional ByRef PorD As Double = 0, Optional ByRef Bod As String = "", Optional ByRef Departamento As String = "", Optional ByRef DocSop As String = "", Optional ByRef NumSop As Double = 0, Optional ByRef ClaseSerie As Collection = Nothing, Optional ByRef Estado As Double = 0, Optional ByRef Oculto As Double = 0, Optional ByRef INVENTARIO As Double = 0, Optional ByRef Ventas As Double = 0, Optional ByRef Compras As Double = 0, Optional ByRef Activo As Double = 0, Optional ByRef TipoCosto As String = "", Optional ByRef LoteDoc As String = "", Optional ByRef EsProduccion As Boolean = False, Optional ByRef ColClasifica As ColClasificador = Nothing, Optional ByRef sucdestino As String = "", Optional ByRef boddestino As String = "")
		On Error Resume Next
		
		Dim ClaseSer As Collection
		ClaseSer = ClaseSerie
		Dim ElTipo As String
		Dim cl As Short
		Dim Campo As String
		'UPGRADE_ISSUE: clasificador objeto no se actualizó. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
		Dim CampClasifica As New clasificador
		Dim cod As String
		Dim RsTra As New ADODB.Recordset
		
		RsTra = New ADODB.Recordset
		If UCase(Mid(NombreTablaTra, 1, 6)) <> "ADCTRA" Then MsgBox("ERROR en nombre de tablatra:" & NombreTablaTra) : Exit Sub
		cod = "SELECT * From " & NombreTablaTra & " WHERE  doc_sucursal= '" & Suc & "' AND opc_documento='" & Doc & "' AND IdClaveDoc = " & IdClaveDoc
		ConxAdcom.Execute(" delete From " & NombreTablaTra & " WHERE  doc_sucursal= '" & Suc & "' AND opc_documento='" & Doc & "' AND IdClaveDoc = " & IdClaveDoc)
		RsTra.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
		RsTra.LockType = ADODB.LockTypeEnum.adLockOptimistic
		RsTra.Open(cod, ConxAdcom,  ,  , ADODB.CommandTypeEnum.adCmdText)
		'VerificarExistente NombreTablaTra, suc, Doc, NUM
		Dim I As Short
		
		With RsTra
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.FixedRows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			For I = Malla.FixedRows To (Malla.Rows - 1)
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Malla.TextMatrix(I, 1) > "" Then
					.AddNew()
					.Fields("Doc_sucursal").Value = Suc ' almacen
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Malla.TextMatrix(I, 20) > "" And Emp.Lote = True Then .Fields("Doc_Bodega").Value = Malla.TextMatrix(I, 20) Else .Fields("Doc_Bodega").Value = Trim(Bod)
					.Fields("Opc_documento").Value = Doc 'tipo de documento
					.Fields("Doc_numero").Value = Num 'numero de documento
					.Fields("tra_tipodoc").Value = Trim(TipDoc)
					.Fields("Tra_DocSop").Value = Trim(DocSop)
					.Fields("Tra_NumSop").Value = NumSop
					.Fields("tra_fecha").Value = Trim(CStr(Fec))
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.FixedRows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.Fields("TRA_NUMLINEA").Value = I + 1 - Malla.FixedRows 'linea
					
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Malla.TextMatrix(I, 1) <> "" Then .Fields("Tra_Codigo").Value = Trim(Malla.TextMatrix(I, 1)) 'codigo de servicio o articulo, activo
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Malla.TextMatrix(I, 2) <> "" Then .Fields("tra_nombre").Value = Trim(Malla.TextMatrix(I, 2))
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.Fields("TRA_CANTIDAD").Value = libdat.CorrijeNuloN(Malla.TextMatrix(I, 3))
					
					If EsProduccion = False Then
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto libdat.CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						.Fields("Tra_medida").Value = libdat.CorrijeNulo(Malla.TextMatrix(I, 4))
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						.Fields("Tra_precuni").Value = libdat.CorrijeNuloN(Malla.TextMatrix(I, 5))
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						.Fields("Tra_prectot").Value = libdat.CorrijeNuloN(Malla.TextMatrix(I, 7))
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						.Fields("tra_porcendes").Value = libdat.CorrijeNuloN(Malla.TextMatrix(I, 6))
					Else
						
						.Fields("Tra_medida").Value = Nothing
						.Fields("Tra_precuni").Value = 0
						.Fields("Tra_prectot").Value = 0
						.Fields("tra_porcendes").Value = 0
						
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						.Fields("HorasUnidad").Value = Val(Malla.TextMatrix(I, 4))
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						.Fields("CostoHora").Value = Val(Malla.TextMatrix(I, 10))
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						.Fields("CostoMatPrima").Value = Val(Malla.TextMatrix(I, 7))
					End If
					
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto libdat.CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ElTipo = libdat.CorrijeNulo(Malla.TextMatrix(I, 8))
					'UPGRADE_WARNING: IsEmpty se actualizó a IsNothing y tiene un nuevo comportamiento. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If IsNothing(ElTipo) Then ElTipo = TipoRegistro(Trim(Malla.TextMatrix(I, 1)))
					
					.Fields("tra_quetipo").Value = ElTipo
					
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.Fields("tra_valordes").Value = libdat.CorrijeNuloN(Malla.TextMatrix(I, 11))
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.Fields("tra_costuni").Value = libdat.CorrijeNuloN(Malla.TextMatrix(I, 12))
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.Fields("Tra_CostTot").Value = libdat.CorrijeNuloN(Malla.TextMatrix(I, 13))
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.Fields("tra_piezas").Value = libdat.CorrijeNuloN(Malla.TextMatrix(I, 17))
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.Fields("tra_peso").Value = libdat.CorrijeNuloN(Malla.TextMatrix(I, 16))
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.Fields("tra_multiplo").Value = libdat.CorrijeNuloN(Malla.TextMatrix(I, 18))
					'!tra_Inmediato = libdat.CorrijeNuloN(Malla.TextMatrix(i, 18))
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					If .Fields("tra_multiplo").Value = 0 Or IsDbNull(.Fields("tra_multiplo").Value) Then .Fields("tra_multiplo").Value = 1
					If numP <> "" Then .Fields("tra_numprecio").Value = Trim(numP)
					If Desd <> "" Then .Fields("tra_descdes").Value = Trim(Desd)
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.Fields("tra_nrolote").Value = Malla.TextMatrix(I, 19)
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.Fields("Despacho").Value = Val(Malla.TextMatrix(I, 51))
					
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If UCase(Malla.TextMatrix(I, 10)) = "SI" Then
						.Fields("TRA_SNIVA").Value = 1
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					ElseIf UCase(Malla.TextMatrix(I, 10)) = "NO" Then 
						.Fields("TRA_SNIVA").Value = 0
					Else
						.Fields("TRA_SNIVA").Value = 0
					End If
					
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Malla.TextMatrix(I, 9) <> "" Then .Fields("Tra_individual").Value = Trim(Malla.TextMatrix(I, 9))
					
					.Fields("tra_estado").Value = Estado
					.Fields("TRa_Oculto").Value = Oculto
					.Fields("Tra_Inventario").Value = INVENTARIO
					.Fields("TRa_Ventas").Value = Ventas
					.Fields("TRa_Compras").Value = Compras
					.Fields("TRa_Activo").Value = Activo
					
					.Fields("tra_valor").Value = CDbl(valo)
					If Departamento <> "" Then .Fields("tra_depdes").Value = Trim(Departamento)
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Cols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Malla.Cols > 19 Then .Fields("Tra_serie").Value = Trim(Malla.TextMatrix(I, 20))
					.Fields("tra_NroLoteDoc").Value = LoteDoc
					.Fields("TipoCosto").Value = TipoCosto
					
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Cols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Malla.Cols > 25 Then
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						.Fields("FacDesde").Value = libdat.CorrijeNuloF(Malla.TextMatrix(I, 24))
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						.Fields("FacHasta").Value = libdat.CorrijeNuloF(Malla.TextMatrix(I, 25))
					End If
					.Fields("tra_SucDestino").Value = sucdestino
					.Fields("tra_BodDestino").Value = boddestino
					'        !tra_costo = libdat.CorrijeNulo(malla.TextMatrix(i, 26))
					'        !tra_empleado = libdat.CorrijeNulo(malla.TextMatrix(i, 27))
					'        !TRA_Centroproduccion = libdat.CorrijeNulo(malla.TextMatrix(i, 28))
					'        !tra_centrodistribucion = libdat.CorrijeNulo(malla.TextMatrix(i, 29))
					'        !tra_proyecto = libdat.CorrijeNulo(malla.TextMatrix(i, 30))
					'        !tra_proyecto = libdat.CorrijeNulo(malla.TextMatrix(i, 31))
					
					If Not ColClasifica Is Nothing Then
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ColClasifica.Count. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If ColClasifica.Count > 0 Then
							For cl = 26 To 50
								'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto libdat.CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								Campo = libdat.CorrijeNulo(Malla.TextMatrix(I, cl))
								If Campo > "" Then
									'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
									'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ColClasifica.Item. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
									CampClasifica = ColClasifica.Item("C" & Trim(Malla.TextMatrix(0, cl)))
									'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CampClasifica.CAMPOTRA. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
									RsTra.Fields(CampClasifica.CAMPOTRA).Value = Campo
								End If
							Next cl
						End If
					End If
					'        !HorasUnidad = HorasUnidad
					'        !CostoHora = CostoHora
					'        !CostoMatPrima = CostoMatPrima
					
					.Fields("IdClaveDoc").Value = IdClaveDoc
					
					.Update()
				End If
			Next I
			.Close()
			ext = CStr(INVENTARIO)
			'If ClaseSer.ClsTotal > 0 Then GuardarTallaSerie TablaSerie, Suc, Bod, Doc, Num, ext, ClaseSer, Fec, malla, SnBorraTS
			'If Emp.VenSNEmp = True And INVENTARIO <> 0 Then CrearAscci malla, Num, Doc
		End With
	End Sub
	Private Function TipoRegistro(ByRef codigo As String) As String
		Dim RsDoc As New ADODB.Recordset
		Dim cod As String
		On Error Resume Next
		cod = "SELECT art_codigo fROM adcart WHERE Art_codigo = '" & codigo & "' "
		TipoRegistro = "A"
		If RsDoc.State = 1 Then RsDoc.Close()
		RsDoc.Open(cod, ConxAdcom, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		If RsDoc.EOF = False Then RsDoc.Close() : Exit Function
		
		cod = "SELECT Sev_codigo fROM AdcServ WHERE SEV_codigo = '" & codigo & "' "
		
		TipoRegistro = "S"
		If RsDoc.State = 1 Then RsDoc.Close()
		RsDoc.Open(cod, ConxAdcom, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		If RsDoc.EOF = False Then RsDoc.Close() : Exit Function
		
		TipoRegistro = CStr(Nothing)
		If RsDoc.State = 1 Then RsDoc.Close()
		
	End Function
	
	'Private Sub CrearAscci(ByVal malla As MSFlexGrid, ByVal Num As Double, ByVal Tip As String)
	'Dim RsArtPro As New ADODB.Recordset, CodAnt As String, PreAnt As double, codigoext As String, NomAnt As String
	'Dim TotPre As double, PreAct As double
	'Dim TotCantidad As double
	'on error Resume Next
	'TotCantidad = 0
	'malla.Cols = malla.Cols + 1
	'ColDatos = malla.Cols - 1
	'Open PathAppl & "export\" & "E" & Format(Num, "0000000") For Output As #5
	'Dim i As Long
	'CodAnt =empty
	'
	'With malla
	'For i = malla.FixedRows To .Rows - 1
	'If .TextMatrix(i, 1) > "" Then
	'    If RsArtPro.State Then RsArtPro.Close
	'    RsArtPro.Open "Select Art_codpro,Art_CodigoBase,Art_precvta1 from adcart where Art_codigo = '" & .TextMatrix(i, 1) & "'", ConxAdcom, adOpenForwardOnly, adLockReadOnly
	'    If RsArtPro.EOF = True Then
	'       codigoext = TRIM$(.TextMatrix(i, 1))
	'    Else
	'       If TRIM$(libdat.CorrijeNulo(RsArtPro!art_codpro)) > "" Then
	'          codigoext = libdat.CorrijeNulo(RsArtPro!art_codpro)
	'       ElseIf TRIM$(libdat.CorrijeNulo(RsArtPro!art_codigobase)) > "" Then
	'          codigoext = TRIM$(RsArtPro!art_codigobase)
	'       Else
	'          codigoext = TRIM$(.TextMatrix(i, 1))
	'       End If
	'    End If
	'    .TextMatrix(i, ColDatos) = codigoext
	'End If
	'Next i
	'.col = ColDatos
	'.Row = 0
	'.Sort = 5
	'For i = .FixedRows To .Rows - 1
	'    codigoext = TRIM$(.TextMatrix(i, ColDatos))
	'    If codigoext > "" Then
	'        If CodAnt =empty Then CodAnt = TRIM$(codigoext): PreAnt = PreAct
	'        If CodAnt <> codigoext Then
	'           Print #5, mid$(CodAnt + Space(15), 1, 15) & mid$(NomAnt + Space(40), 1, 40) & Format(TotCantidad, "00000.00") & Format(TotPre, "000000000.00")
	'           TotCantidad = 0
	'           PreAnt = PreAct
	'           TotPre = 0
	'           CodAnt = TRIM$(codigoext)
	'        End If
	'        TotCantidad = TotCantidad + libdat.CorrijeNuloN(.TextMatrix(i, 3))
	'        TotPre = libdat.CorrijeNuloN(.TextMatrix(i, 3)) * PreAct + TotPre
	'        NomAnt = .TextMatrix(i, 2)
	'    End If
	'Next i
	'If TotCantidad <> 0 Then Print #5, mid$(CodAnt + Space(15), 1, 15) & mid$(NomAnt + Space(40), 1, 40) & Format(TotCantidad, "00000.00") & Format(TotPre, "000000000.00")
	'End With
	'If RsArtPro.State Then RsArtPro.Close
	'Close #5
	'malla.Cols = malla.Cols - 1
	'End Sub
	'
	'Private Function RecuperarNumLinea(CodigoArti As String, MallaN As MSFlexGrid, Optional SerieOTalla As String) As Integer
	'Dim i As Integer
	'For i = MallaN.FixedRows To (MallaN.Rows - 1)
	'    If UCASE$(MallaN.TextMatrix(i, 1)) = UCASE$(CodigoArti) Then
	'            RecuperarNumLinea = val(MallaN.TextMatrix(i, 0))
	'            i = MallaN.Rows
	'    End If
	'Next i
	'End Function
	
	
	'Public Sub GuardarTallaSerie(TablaSer As String, Suc As String, Bod As String, Doc As String, Num As Double, _
	''                             ExtTra As String, ArticuloSerie As SeriesArticulo, fecha As Date, Optional MallaST As MSFlexGrid, _
	''                            Optional SnBorraTalSer As String)
	''ELIMINO LA TABLA TALLA TRA
	'Dim i As Integer, j As Integer, Signo As String
	'Dim ClaseSerie As SeriesArticulo
	'Dim Series As New Serie
	'Dim RsSerie1 As ADODB.Recordset
	'Dim NumLinea As Integer, ArticuloAnt As String
	'on error Resume Next
	'Signo = "1"
	'If TRIM$(ExtTra) = "-1" Then Signo = "-1"
	'If TRIM$(ExtTra) = "0" Then Signo = "0"
	''Set ClaseTal = Clase
	'Set ClaseSerie = ArticuloSerie
	'
	'
	'        '*****************************
	'        'hacer la clase de series
	'        Set RsSerie1 = New ADODB.Recordset
	'        If RsSerie1.State = 1 Then RsSerie1.Close
	'        RsSerie1.CursorType = adOpenKeyset
	'        RsSerie1.LockType = adLockOptimistic
	'        If UCASE$(TablaSer) = "ADCSERTRAPRO" Then
	'            RsSerie1.Open "adcsertraPro", ConxAdcom, , , adCmdTable
	'        Else
	'            RsSerie1.Open "AdcSerTra", ConxAdcom, , , adCmdTable
	'        End If
	'
	'  With RsSerie1
	'    ArticuloAnt =empty
	'    NumLinea = 0
	'     For i = 1 To ClaseSerie.CountTotal
	'        Set Series = ClaseSerie.Item(i)
	'        If Series.Disponible <> "" Then
	'          .AddNew
	'          !doc_Sucursal = Suc                                          ' Almacen
	'          !Doc_bodega = TRIM$(Bod)                                ' Bodega
	'          !Opc_documento = Doc                                     ' Tipo de documento
	'          !doc_numero = Num                                         ' Numero de documento
	'          !Tra_fecha = TRIM$(fecha)
	'          If UCASE$(ArticuloAnt) <> UCASE$(Series.Articulo) Then
	'                  NumLinea = RecuperarNumLinea(Series.Articulo, MallaST, "S")
	'          End If
	'          !TRA_NUMLINEA = NumLinea
	'          !tra_codigo = Series.Articulo
	'          !Ser_Serie = Series.Serie
	'          !Ser_Signo = Signo
	'
	'          .Update
	'          ArticuloAnt = TRIM$(Series.Articulo)
	'        End If
	'     Next i
	'     .Close
	'  End With
	' If SnBorraTalSer =empty Then
	'    ClaseSerie.ClsTotal
	' End If
	'End Sub
	
	Public Sub NoGraboDocumento()
		MsgBox("No se pudo grabar el documento solicitado, Intente con otro número", MsgBoxStyle.Critical, "Errores grabando documento")
	End Sub
	
	Public Function ArmarExtencionDocumento(ByRef Extencion As String, ByRef clave As String, Optional ByRef QueTipoEs As Boolean = False, Optional ByRef Posicion As Byte = 0) As Double
		Dim Extenciones, ArmarExtDoc, ClaveDoc As String
		
		'QueTipoEs =true Es unEgreso de Bodega o para Banco
		'QueTipoEs =false Es un ingreso a Bodega o para banco
		ArmarExtDoc = CStr(Nothing)
		Extenciones = Extencion
		ClaveDoc = clave
		
		Select Case Posicion
			
			Case 1
				ArmarExtDoc = CStr(1) ' Estado 1 = activo  2 =  anulado
			Case 2
				ArmarExtDoc = Mid(Extencion, 7, 1) ' Doc. Oculto  1 = No oculto 0= Oculto
			Case 3
				ArmarExtDoc = Mid(Extencion, 4, 1) ' Afecta a Ctb 0 = No 1= Si
			Case 4
				ArmarExtDoc = Mid(ClaveDoc, 2, 1) ' afecta  a Bancos 0=No , 1=si
			Case 5
				If Val(Mid(Extencion, 5, 1)) = 0 Then
					ArmarExtDoc = CStr(0)
				Else
					If Trim(Mid(ClaveDoc, 3, 1)) = "3" Then
						If QueTipoEs = True Then
							ArmarExtDoc = Trim(ArmarExtDoc & 2)
						Else
							ArmarExtDoc = Trim(ArmarExtDoc & 1)
						End If
					Else
						ArmarExtDoc = Mid(ClaveDoc, 3, 1) ' Afecta a Inv  0 = No ,1= Si y suma en inventario , 2=resta en inventario ,3 = transferenciai
					End If
				End If
				
			Case 6
				ArmarExtDoc = Mid(ClaveDoc, 4, 1) ' Ventas a 0 = No 1= Si  y suma , 2 = resta
			Case 7
				ArmarExtDoc = Mid(ClaveDoc, 5, 1) ' Compras a 0 = No 1= Si
			Case 8
				ArmarExtDoc = Mid(Extencion, 6, 1) ' Afecta a Activo fijo  a 0 = No 1= Si
		End Select
		
		If ArmarExtDoc = "2" Then ArmarExtDoc = CStr(-1)
		ArmarExtencionDocumento = CDbl(Val(ArmarExtDoc))
		
		
		'ArmarExtDoc = "1"    ' Estado 1 = activo  2 =  anulado
		'   ArmarExtDoc = ArmarExtDoc & mid$(Extencion, 7, 1)               ' Doc. Oculto  1 = No oculto 0= Oculto
		'   ArmarExtDoc = ArmarExtDoc & mid$(Extencion, 4, 1)               ' Afecta a Ctb 0 = No 1= Si
		'   ArmarExtDoc = ArmarExtDoc & mid$(ClaveDoc, 2, 1)                ' afecta  a Bancos 0=No , 1=si
		'   If TRIM$(mid$(ClaveDoc, 3, 1)) = "3" Then
		'                If QueTipoEs = True Then
		'                      ArmarExtDoc = TRIM$(ArmarExtDoc & 2)
		'                Else
		'                      ArmarExtDoc = TRIM$(ArmarExtDoc & 1)
		'                End If
		'   Else
		'               ArmarExtDoc = ArmarExtDoc & mid$(ClaveDoc, 3, 1)               ' Afecta a Inv  0 = No ,1= Si y suma en inventario , 2=resta en inventario ,3 = transferenciai
		'   End If
		'   ArmarExtDoc = ArmarExtDoc & mid$(ClaveDoc, 4, 1)     ' Ventas a 0 = No 1= Si  y suma , 2 = resta
		'   ArmarExtDoc = ArmarExtDoc & mid$(ClaveDoc, 5, 1)                ' Compras a 0 = No 1= Si
		'   ArmarExtDoc = ArmarExtDoc & mid$(Extencion, 6, 1)               ' Afecta a Activo fijo  a 0 = No 1= Si
		'   ArmarExtencionDocumento = ArmarExtDoc
	End Function
	Public Function ArmarExtencionDocTra(ByRef Extencion As String, ByRef clave As String, Optional ByRef QueTipoEs As Boolean = False, Optional ByRef Posicion As Byte = 0) As Double
		Dim Extenciones, ArmarExtTra, ClaveDoc As String
		'QueTipoEs =true Es unEgreso de Bodega o para Banco
		'QueTipoEs =false Es un ingreso a Bodega o para banco
		
		Extenciones = Extencion
		ClaveDoc = clave
		Select Case Posicion
			Case 1
				ArmarExtTra = CStr(1) ' Estado 1 = activo  2= anulado
			Case 2
				ArmarExtTra = Mid(Extencion, 7, 1) ' Doc. Oculto  0 = No oculto 1= Oculto
			Case 3
				If Trim(Mid(Extencion, 5, 1)) = "1" Then
					If Trim(Mid(ClaveDoc, 3, 1)) = "3" Then
						If QueTipoEs = True Then
							ArmarExtTra = Trim(ArmarExtTra & 2)
						Else
							ArmarExtTra = Trim(ArmarExtTra & 1)
						End If
					Else
						ArmarExtTra = Mid(ClaveDoc, 3, 1) ' Afecta a Inv  0 = No ,1= Si y suma en inventario , 2=resta en inventario ,3 = transferenciai
					End If
				Else
					ArmarExtTra = "0"
				End If
			Case 4
				ArmarExtTra = Mid(ClaveDoc, 4, 1) ' Ventas a 0 = No 1= Si  y suma , 2 = resta
			Case 5
				ArmarExtTra = Mid(ClaveDoc, 5, 1) ' Compras a 0 = No 1= Si y suma , 2= resta
			Case 6
				ArmarExtTra = Mid(ClaveDoc, 6, 1) ' Afecta a Activo fijo  a 0 = No 1= Si
				
		End Select
		If ArmarExtTra = "2" Then ArmarExtTra = CStr(-1)
		ArmarExtencionDocTra = Val(ArmarExtTra)
		
	End Function
	Public Function ArmarSigno(ByRef TipoDoc As String, ByRef extension As String, Optional ByRef Pos As Short = 0) As String
		
		If CBool(TipoDoc) = ("FAC" Or TipoDoc = "DEV") And Pos <> 0 Then
			Pos = 4
		ElseIf TipoDoc = "IBG" Or TipoDoc = "EBG" Or TipoDoc = "AJI" Or TipoDoc = "AJE" Or TipoDoc = "TRF" Then 
			
			ArmarSigno = CStr((CDbl(Right(Left(extension, 3), 1)) - 1.5) * -2)
		End If
	End Function
	
	Public Function NumeroDeRetencion(ByRef IdClaveDocSop As Double, ByRef SucSop As String, ByRef DocSop As String, ByRef NumSop As Double, ByRef TipDoc As String) As Double
		Dim rs As New ADODB.Recordset
		Dim cod As String
		cod = "from AdcDOC  where DOC_SUCURSAL = '" & SucSop & "' and DOC_DOCSOP = '" & DocSop & "' and IdClaveDocSop = " & IdClaveDocSop & " AND doc_tipOdoc IN ('RTP','RTC')"
		cod = cod & " and doc_estado = 1"
		'Debug.Print cod
		rs = New ADODB.Recordset
		rs.Open("select * " & cod, ConxAdcom, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
		If rs.EOF Then NumeroDeRetencion = 0 Else NumeroDeRetencion = rs.Fields("IdClaveDoc").Value : TipDoc = rs.Fields("Opc_documento").Value
		If rs.State = 1 Then rs.Close()
	End Function
	
	Public Function NumeroClave(ByRef tabla As String, ByRef Suc As String, ByRef Tipo As String, Optional ByRef NumDoc As Double = 0) As Double
		Dim rs As New ADODB.Recordset
		Dim cod As String
		If Tipo = "IPT" Then
			NumeroClave = NumDoc
		Else
			If UCase(tabla) = "ADCDOCPED" Then
				cod = "SELECT MAX(Doc_Clave) AS CLAVE FROM ADCDOCPED where doc_sucursal = '" & Suc & "' and Opc_documento = '" & Tipo & "' "
			Else
				cod = "SELECT MAX(IdClaveDoc) AS CLAVE FROM " & tabla & " where doc_sucursal = '" & Suc & "' and Opc_documento = '" & Tipo & "' "
			End If
			rs = New ADODB.Recordset
			rs.Open(cod, ConxAdcom, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
			If rs.EOF Then NumeroClave = 1 Else NumeroClave = libdat.CorrijeNuloN(rs.Fields("clave")) + 1
			If rs.State = 1 Then rs.Close()
		End If
	End Function
	
	
	'Private Function ArreglarCosto()
	'Dim TotalPorUnidad As Double, TotalPorValor As Double, TotalPorPeso As Double
	'Dim TotalUnidad As Double, TotalValor As Double, TotalPeso As Double
	'Dim PorPeso As Double, PorUnidad As Double, PorValor As Double
	'Dim i As Integer
	'TotalPorValor = 0
	'TotalPorUnidad = 0
	'TotalPorPeso = 0
	'TotalUnidad = 0
	'TotalValor = 0
	'TotalPeso = 0
	'PorUnidad = 0
	'PorPeso = 0
	'PorValor = 0
	'ArreglarCosto = vbYes
	'
	'With Malla
	'
	'For i = .FixedRows To .Rows - 1
	'    If UCASE$(.TextMatrix(i, 8)) = "S" Then
	'       OpServicio.Cargar .TextMatrix(i, 1)
	'       If OpServicio.AfectaCosto = "U" Then
	'            TotalPorUnidad = TotalPorUnidad + CDbl(.TextMatrix(i, 7))
	'       ElseIf OpServicio.AfectaCosto = "P" Then
	'            TotalPorPeso = TotalPorPeso + val(.TextMatrix(i, 7))
	'       ElseIf OpServicio.AfectaCosto > "" Then
	'            TotalPorValor = TotalPorValor + CDbl(.TextMatrix(i, 7))
	'       End If
	'    ElseIf UCASE$(.TextMatrix(i, 8)) = "A" Then
	'       TotalUnidad = TotalUnidad + val(.TextMatrix(i, 3))
	'       TotalValor = TotalValor + val(.TextMatrix(i, 7))
	'       TotalPeso = TotalPeso + val(.TextMatrix(i, 3)) * opArt.Peso
	'    End If
	'Next i
	'
	'If TotalUnidad > 0 Then PorUnidad = round(TotalPorUnidad / TotalUnidad, Emp.DigitosCostos)
	'If TotalPeso > 0 Then PorPeso = round(TotalPorPeso / TotalPeso, Emp.DigitosCostos)
	'If TotalValor > 0 Then PorValor = round(TotalPorValor / TotalValor, Emp.DigitosCostos)
	'
	'If PorUnidad <> 0 Or PorPeso <> 0 Or PorValor <> 0 Then
	'If MsgBox("Ha registrado Servicios que afectan al costo de sus artículos en inventario " & vbCr & _
	''        " confirma recalcular el costo en base a los servicios adicionales ? ", vbYesNo + vbQuestion) = vbYes Then
	'    For i = .FixedRows To .Rows - 1
	'        If UCASE$(.TextMatrix(i, 8)) <> "S" Then
	'            .TextMatrix(i, 12) = round(CDbl(libdat.CorrijeNuloN(.TextMatrix(i, 5))) + PorUnidad + PorValor + PorPeso, Emp.DigitosCostos)
	'            .TextMatrix(i, 13) = round(CDbl(libdat.CorrijeNuloN(.TextMatrix(i, 12))) * CDbl(libdat.CorrijeNuloN(.TextMatrix(i, 3))), Emp.DigitosCostos)
	'        End If
	'    Next i
	'    ArreglarCosto = VerCostosNuevos.Inicia(Malla.LaMalla, PorValor, Str(DocNumero))
	'Else
	'    ArreglarCosto = vbYes
	'End If
	'End If
	'End With
	'End Function
	Public Sub PonerHistorico(ByRef Accion As String, ByRef Usuario As String, ByRef fecha As Date, ByRef Suc As String, ByRef Doc As String, ByRef Num As Double, Optional ByRef Valor As Double = 0)
		Dim filespec As String
		Dim menj As String
		Dim ext As Boolean
		Dim Archivo As String
		Archivo = "ADCOM.log"
		If Mid(Accion, 1, 3) = "CTB" Then Archivo = "ADCOMCTB.log" : Accion = Mid(Accion, 4)
		If Right(PathAppl, 1) <> "\" Then Archivo = "\" & Archivo
		'CONTROLA SI TIENE LA OPCION ABILITADA
		Dim ts, fs, f, S As Object
		Const TristateUseDefault As Short = -2
		Const TristateTrue As Short = -1
		Const TristateFalse As Short = 0
		Const ForReading As Short = 1
		Const ForWriting As Short = 2
		Const ForAppending As Short = 8
		If Emp.AcumHis Then
			menj = Accion & "Documento: " & Doc & "-" & Num & " Sucursal: " & Suc & " FechaDoc " & fecha & " Usuario: " & Usuario & " cuando: " & VB6.Format(Today, "dd/mm/yyyy") & " hora: " & VB6.Format(TimeOfDay, "hh:mm:ss") & " Valor " & VB6.Format(Valor, "###,###,##0.00")
			filespec = PathAppl & Archivo
			fs = CreateObject("Scripting.FileSystemObject")
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto fs.FileExists. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ext = fs.FileExists(filespec)
			If Not ext Then
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto fs.CreateTextFile. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				fs.CreateTextFile(filespec) 'Crear un archivo
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto fs.GetFile. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				f = fs.GetFile(filespec)
			Else
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto fs.GetFile. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				f = fs.GetFile(filespec)
			End If
			
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto f.OpenAsTextStream. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ts = f.OpenAsTextStream(ForAppending, TristateUseDefault)
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ts.WriteBlankLines. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ts.WriteBlankLines(0)
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ts.WriteLine. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ts.WriteLine(menj)
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ts.Close. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ts.Close()
		End If
	End Sub
	
	Public Sub GuardarDetalleDoc(ByRef IdClaveDoc As Double, ByVal Doc As String, ByVal Num As Double, ByVal Fec As Date, ByVal CodPer As String, ByVal Malla As AxDaxGrid.AxDaxGridIn, ByRef Sucursal As String, ByRef ColClasifica As ColClasificador)
		
		Dim Campo As String
		'UPGRADE_ISSUE: clasificador objeto no se actualizó. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
		Dim CampClasifica As New clasificador
		
		Dim codsql As String
		Dim Rs1doc As New ADODB.Recordset
		Dim LaSuc As String
		Dim cl As Short
		'UPGRADE_WARNING: IsEmpty se actualizó a IsNothing y tiene un nuevo comportamiento. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		If IsNothing(Sucursal) Then LaSuc = Emp.SucActual Else LaSuc = Sucursal
		Dim I As Integer
		codsql = " FROM AdcApl WHERE doc_sucursal='" & LaSuc & "' and opc_documento='" & Doc & "' and idclavedoc=" & IdClaveDoc
		ConxAdcom.Execute("DELETE " & codsql)
		
		Rs1doc = New ADODB.Recordset
		codsql = "SELECT * " & codsql
		'PROPIEDADES QUE PERMITEN ABRIR Y AGREGAR UN NUEVO REGISTRO A UNA TABLA
		Rs1doc.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
		Rs1doc.LockType = ADODB.LockTypeEnum.adLockOptimistic
		Rs1doc.Open(codsql, ConxAdcom,  ,  , ADODB.CommandTypeEnum.adCmdText)
		For I = 1 To Malla.Rows - 1
			If Malla.get_TextMatrix(I, 1) <> "" And Val(Malla.get_TextMatrix(I, 3)) <> 0 Then
				With Rs1doc
					.AddNew()
					.Fields("Doc_sucursal").Value = LaSuc
					.Fields("Doc_numero").Value = Num
					.Fields("Opc_documento").Value = Doc
					.Fields("apl_docapli").Value = Trim(Malla.get_TextMatrix(I, 6))
					.Fields("APL_NUMAPLI").Value = Val(Malla.get_TextMatrix(I, 7))
					.Fields("apl_sucapli").Value = Trim(Malla.get_TextMatrix(I, 5))
					.Fields("idClaveDocapl").Value = Val(Malla.get_TextMatrix(I, 8))
					.Fields("Apl_fecha").Value = Fec
					.Fields("Apl_docfecha").Value = Fec 'CDate(malla.TextMatrix(i, 2))
					.Fields("Apl_valorapl").Value = Val(Malla.get_TextMatrix(I, 3))
					'UPGRADE_WARNING: IsEmpty se actualizó a IsNothing y tiene un nuevo comportamiento. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
					.Fields("Apl_codbenef").Value = IIf(IsNothing(Trim(Malla.get_TextMatrix(I, 4))), CodPer, Trim(Malla.get_TextMatrix(I, 4)))
					.Fields("Apl_SNContado").Value = 0
					.Fields("IdClaveDoc").Value = IdClaveDoc
					.Fields("CodConcepto").Value = Trim(Malla.get_TextMatrix(I, 1))
					.Fields("descripcionconcepto").Value = Malla.get_TextMatrix(I, 2)
					.Fields("TRa_Ventas").Value = Val(Malla.get_TextMatrix(I, 10))
					.Fields("TRa_Compras").Value = Val(Malla.get_TextMatrix(I, 11))
					.Fields("tra_esanticipo").Value = Val(Malla.get_TextMatrix(I, 12))
					.Fields("tra_Banco").Value = Val(Malla.get_TextMatrix(I, 14))
					.Fields("tra_escontable").Value = Val(Malla.get_TextMatrix(I, 13))
					.Fields("tra_CtasCobrar").Value = Val(Malla.get_TextMatrix(I, 15))
					.Fields("tra_CtasPagar").Value = Val(Malla.get_TextMatrix(I, 16))
					
					.Fields("numLinApl").Value = I
					
					.Fields("idclaveapl").Value = IIf(Val(Malla.get_TextMatrix(I, 18)) > 0, Val(Malla.get_TextMatrix(I, 18)), I)
					.Fields("idclaveaplapl").Value = 0
					' ----------------------------------------------------------------------------------------
					'  futuro para otras cuentas por cobrar y otras por pagar para ayudar a presentar las cuentas pendientes
					' como en proveedores y clientes pero directamentee de contabilidad
					'-----------------------------------------------------------------------------------------
					
					
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ColClasifica.Count. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If ColClasifica.Count > 0 Then
						For cl = 26 To 50
							'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto libdat.CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							Campo = libdat.CorrijeNulo(Malla.get_TextMatrix(I, cl))
							If Campo > "" Then
								'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ColClasifica.Item. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								CampClasifica = ColClasifica.Item("C" & Trim(Malla.get_TextMatrix(0, cl)))
								'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CampClasifica.CAMPOTRA. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								.Fields(CampClasifica.CAMPOTRA).Value = Campo
							End If
						Next cl
					End If
					
					
					.Update()
				End With
			End If
		Next 
		Rs1doc.Close()
	End Sub
	
	Public Sub CargarDetalleDoc(ByRef IdClaveDoc As Double, ByVal Doc As String, ByVal Num As Double, ByVal Fec As Date, ByVal CodPer As String, ByRef Malla As Object, ByRef Sucursal As String, ByRef ColClasifica As ColClasificador)
		Dim Campo As String
		'UPGRADE_ISSUE: clasificador objeto no se actualizó. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
		Dim CampClasifica As New clasificador
		
		Dim codsql As String
		Dim Rs1doc As New ADODB.Recordset
		Dim LaSuc As String
		
		'UPGRADE_WARNING: IsEmpty se actualizó a IsNothing y tiene un nuevo comportamiento. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		If IsNothing(Sucursal) Then LaSuc = Emp.SucActual Else LaSuc = Sucursal
		On Error Resume Next
		Dim I As Integer
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Malla.Rows = 2
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Cols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Malla.Cols < 60 Then Malla.Cols = 60
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Cols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		For I = 0 To Malla.Cols - 1
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Malla.TextMatrix(1, I) = Nothing
		Next I
		codsql = " FROM AdcApl WHERE doc_sucursal='" & LaSuc & "' and opc_documento='" & Doc & "' and idclavedoc=" & IdClaveDoc
		'Debug.Print codsql
		Rs1doc = New ADODB.Recordset
		codsql = "SELECT * " & codsql
		Rs1doc.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
		Rs1doc.LockType = ADODB.LockTypeEnum.adLockOptimistic
		Rs1doc.Open(codsql, ConxAdcom,  ,  , ADODB.CommandTypeEnum.adCmdText)
		I = 1
		With Rs1doc
			Do Until .EOF
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Malla.Rows = I + 1
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Malla.TextMatrix(I, 6) = .Fields("apl_docapli").Value
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Malla.TextMatrix(I, 7) = .Fields("APL_NUMAPLI").Value
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Malla.TextMatrix(I, 5) = .Fields("apl_sucapli").Value
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Malla.TextMatrix(I, 3) = .Fields("Apl_valorapl").Value
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Malla.TextMatrix(I, 4) = .Fields("Apl_codbenef").Value
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Malla.TextMatrix(I, 8) = .Fields("idClaveDocapl").Value
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Malla.TextMatrix(I, 4) > "" Then Malla.TextMatrix(I, 17) = NombreDirectorio(Malla.TextMatrix(I, 4))
				'If !idClaveDocapl > 0 Then malla.ColWidth(6) = 1200: malla.ColWidth(7) = 1200: malla.ColWidth(5) = 1200
				'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Not IsDbNull(.Fields("CodConcepto").Value) Then Malla.TextMatrix(I, 1) = .Fields("CodConcepto").Value
				'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Not IsDbNull(.Fields("descripcionconcepto").Value) Then Malla.TextMatrix(I, 2) = .Fields("descripcionconcepto").Value
				'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Not IsDbNull(.Fields("TRa_Ventas").Value) Then Malla.TextMatrix(I, 10) = IIf(.Fields("TRa_Ventas").Value, "1", "")
				'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Not IsDbNull(.Fields("TRa_Compras").Value) Then Malla.TextMatrix(I, 11) = IIf(.Fields("TRa_Compras").Value, "1", "")
				'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Not IsDbNull(.Fields("tra_esanticipo").Value) Then Malla.TextMatrix(I, 12) = IIf(.Fields("tra_esanticipo").Value, "1", "")
				'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Not IsDbNull(.Fields("tra_Banco").Value) Then Malla.TextMatrix(I, 14) = IIf(.Fields("tra_Banco").Value, "1", "")
				'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Not IsDbNull(.Fields("tra_escontable").Value) Then Malla.TextMatrix(I, 13) = IIf(.Fields("tra_escontable").Value, "1", "")
				'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Not IsDbNull(.Fields("tra_CtasCobrar").Value) Then Malla.TextMatrix(I, 15) = IIf(.Fields("tra_CtasCobrar").Value, "1", "")
				'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Not IsDbNull(.Fields("tra_CtasPagar").Value) Then Malla.TextMatrix(I, 16) = IIf(.Fields("tra_CtasPagar").Value, "1", "")
				
				'-            If Not IsNull(!idclaveaplapl) Then malla.TextMatrix(i, 18) = LibDigDat.CorrijeNuloN(!idclaveapl)
				'-            If Not IsNull(!idclaveaplapl) Then malla.TextMatrix(i, 19) = LibDigDat.CorrijeNuloN(!idclaveaplapl)
				
				' ----------------------------------------------------------------------------------------
				'  futuro para otras cuentas por cobrar y otras por pagar para ayudar a presentar las cuentas pendientes
				' como en proveedores y clientes pero directamentee de contabilidad
				'-----------------------------------------------------------------------------------------
				' 9 nombre del cliente
				' 10 cliente 0,1
				' 11 proveedor 0,1
				' 12 anticipo 0,1
				' 13 es transferencia
				'   18 clave de concepto adcapl
				'   19 clave de item adcapl que afecta en el cruce entre conceptos
				'            MsgBox NomClasifica.Count
				
				'            malla.TextMatrix(i, 9) = !tra_CtasCobrar
				'            malla.TextMatrix(i, 9) = !tra_CtasPagar
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ColClasifica.Count. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If ColClasifica.Count > 0 Then
					For	Each CampClasifica In ColClasifica
						'MsgBox CampClasifica.CAMPOTRA & " -- " & CampClasifica.Nombre
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CampClasifica.idclave. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CampClasifica.CAMPOTRA. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto libdat.CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Malla.TextMatrix(I, CampClasifica.idclave + 20) = libdat.CorrijeNulo(Rs1doc.Fields(CampClasifica.CAMPOTRA))
						'                 If malla.TextMatrix(i, CamClasifica.Idclave + 20) > "" Then malla.ColWidth(CamClasifica.Idclave + 20) = 1100
					Next CampClasifica
				End If
				I = I + 1
				.MoveNext()
				
			Loop 
		End With
		Rs1doc.Close()
	End Sub
	
	Public Sub GuardarColAplicaciones(ByRef IdClaveDoc As Double, ByVal Doc As String, ByVal Num As Double, ByVal Fec As Date, ByVal CodPer As String, ByRef Aplicaciones As Collection, ByRef Sucursal As String) ', ColClasifica As ColClasificador)
		
		Dim codsql As String
		Dim Rs1doc As New ADODB.Recordset
		Dim LaSuc As String
		Dim LosDatos() As String
		'UPGRADE_WARNING: IsEmpty se actualizó a IsNothing y tiene un nuevo comportamiento. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		If IsNothing(Sucursal) Then LaSuc = Emp.SucActual Else LaSuc = Sucursal
		If Aplicaciones Is Nothing Then Exit Sub
		If Aplicaciones.Count() = 0 Then Exit Sub
		Dim I As Integer
		
		codsql = " FROM AdcApl WHERE doc_sucursal='" & LaSuc & "' and opc_documento='" & Doc & "' and idclavedoc=" & IdClaveDoc
		ConxAdcom.Execute("DELETE " & codsql)
		
		If Aplicaciones Is Nothing Then Exit Sub
		If Aplicaciones.Count() = 0 Then Exit Sub
		
		Rs1doc = New ADODB.Recordset
		codsql = "SELECT * " & codsql
		Rs1doc.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
		Rs1doc.LockType = ADODB.LockTypeEnum.adLockOptimistic
		Rs1doc.Open(codsql, ConxAdcom,  ,  , ADODB.CommandTypeEnum.adCmdText)
		For I = 1 To Aplicaciones.Count()
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Aplicaciones.Item(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			LosDatos = Split(Aplicaciones.Item(I), ";")
			If Val(LosDatos(0)) <> 0 And Val(LosDatos(4)) <> 0 Then
				'.TextMatrix(0, 7)0 = "Abono"
				'.TextMatrix(0, 3) 1= "SUC"
				'.TextMatrix(0, 4) 2= "TIP"
				'.TextMatrix(0, 5) 3= "Número"
				'.TextMatrix(0, 10) 4= "idclave"
				'.TextMatrix(0, 9) 5= "codcliente"
				'.TextMatrix(0, 2) 6= "Fecha"
				With Rs1doc
					.AddNew()
					.Fields("Doc_sucursal").Value = LaSuc
					.Fields("Doc_numero").Value = Num
					.Fields("Opc_documento").Value = Doc
					.Fields("apl_docapli").Value = LosDatos(2)
					.Fields("APL_NUMAPLI").Value = LosDatos(3)
					.Fields("apl_sucapli").Value = LosDatos(1)
					.Fields("idClaveDocapl").Value = Val(LosDatos(4))
					.Fields("Apl_fecha").Value = Fec
					.Fields("Apl_docfecha").Value = LosDatos(6)
					.Fields("Apl_valorapl").Value = Val(LosDatos(0))
					.Fields("Apl_codbenef").Value = LosDatos(5)
					.Fields("Apl_SNContado").Value = 0
					.Fields("IdClaveDoc").Value = IdClaveDoc
					.Fields("CodConcepto").Value = ""
					.Fields("descripcionconcepto").Value = ""
					.Fields("TRa_Ventas").Value = 0
					.Fields("TRa_Compras").Value = 0
					.Fields("tra_esanticipo").Value = 0
					.Fields("tra_Banco").Value = 0
					.Fields("tra_CtasCobrar").Value = 0
					.Fields("tra_CtasPagar").Value = 0
					.Fields("numLinApl").Value = I
					
					.Update()
				End With
			End If
		Next 
		Rs1doc.Close()
	End Sub
	
	Public Sub CargarColAplicaciones(ByRef IdClaveDoc As Double, ByVal Doc As String, ByVal Num As Double, ByRef Aplicaciones As Collection, ByRef Sucursal As String, ByRef totalAbonos As Double) ', ColClasifica As ColClasificador)
		
		Dim codsql As String
		Dim Rs1doc As New ADODB.Recordset
		Dim LaSuc As String
		Dim LosDatos As String
		'UPGRADE_WARNING: IsEmpty se actualizó a IsNothing y tiene un nuevo comportamiento. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		If IsNothing(Sucursal) Then LaSuc = Emp.SucActual Else LaSuc = Sucursal
		Aplicaciones = New Collection
		Dim I As Integer
		totalAbonos = 0
		codsql = " FROM AdcApl WHERE isnull(espago,'') <> 'S' AND doc_sucursal='" & LaSuc & "' and opc_documento='" & Doc & "' and idclavedoc=" & IdClaveDoc
		Rs1doc = New ADODB.Recordset
		codsql = "SELECT * " & codsql
		Rs1doc.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
		Rs1doc.LockType = ADODB.LockTypeEnum.adLockOptimistic
		Rs1doc.Open(codsql, ConxAdcom,  ,  , ADODB.CommandTypeEnum.adCmdText)
		With Rs1doc
			If .EOF Then .Close() : Exit Sub
			Do Until .EOF
				LosDatos = .Fields("Apl_valorapl").Value & ";" & .Fields("apl_sucapli").Value & ";" & .Fields("apl_docapli").Value & ";" & .Fields("APL_NUMAPLI").Value & ";" & .Fields("idClaveDocapl").Value & ";" & .Fields("Apl_codbenef").Value & ";" & .Fields("Apl_docfecha").Value
				Aplicaciones.Add(LosDatos)
				totalAbonos = totalAbonos + .Fields("Apl_valorapl").Value
				.MoveNext()
			Loop 
		End With
		Rs1doc.Close()
	End Sub
	
	'+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	'' REPITE METODOS CON MATRICES EN LUGAR DE MALLAS PARA RECONTABILIZACIÓN AUTOMÀTICA
	'+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	
	
	Public Sub CargarDetalleDocRecon(ByRef IdClaveDoc As Double, ByVal Doc As String, ByVal Num As Double, ByVal Fec As Date, ByVal CodPer As String, ByRef Malla() As String, ByRef Sucursal As String, ByRef ColClasifica As ColClasificador)
		
		Dim Campo As String
		'UPGRADE_ISSUE: clasificador objeto no se actualizó. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
		Dim CampClasifica As New clasificador
		
		Dim codsql As String
		Dim Rs1doc As New ADODB.Recordset
		Dim LaSuc As String
		
		'UPGRADE_WARNING: IsEmpty se actualizó a IsNothing y tiene un nuevo comportamiento. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		If IsNothing(Sucursal) Then LaSuc = Emp.SucActual Else LaSuc = Sucursal
		On Error Resume Next
		Dim I As Integer
		codsql = " FROM AdcApl WHERE doc_sucursal='" & LaSuc & "' and opc_documento='" & Doc & "' and idclavedoc=" & IdClaveDoc
		
		Rs1doc = New ADODB.Recordset
		codsql = "SELECT * " & codsql
		Rs1doc.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
		Rs1doc.LockType = ADODB.LockTypeEnum.adLockOptimistic
		Rs1doc.Open(codsql, ConxAdcom,  ,  , ADODB.CommandTypeEnum.adCmdText)
		I = 1
		With Rs1doc
			ReDim Malla(Rs1doc.RecordCount + 1, 60)
			Do Until .EOF
				Malla(I, 6) = .Fields("apl_docapli").Value
				Malla(I, 7) = .Fields("APL_NUMAPLI").Value
				Malla(I, 5) = .Fields("apl_sucapli").Value
				Malla(I, 3) = .Fields("Apl_valorapl").Value
				Malla(I, 4) = .Fields("Apl_codbenef").Value
				Malla(I, 8) = .Fields("idClaveDocapl").Value
				'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(.Fields("CodConcepto").Value) Then Malla(I, 1) = .Fields("CodConcepto").Value
				'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(.Fields("descripcionconcepto").Value) Then Malla(I, 2) = .Fields("descripcionconcepto").Value
				'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(.Fields("TRa_Ventas").Value) Then Malla(I, 10) = IIf(.Fields("TRa_Ventas").Value, "1", "")
				'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(.Fields("TRa_Compras").Value) Then Malla(I, 11) = IIf(.Fields("TRa_Compras").Value, "1", "")
				'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(.Fields("tra_Banco").Value) Then Malla(I, 13) = IIf(.Fields("tra_Banco").Value, "1", "")
				'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				If Not IsDbNull(.Fields("tra_esanticipo").Value) Then Malla(I, 12) = IIf(.Fields("tra_esanticipo").Value, "1", "")
				' ----------------------------------------------------------------------------------------
				'  futuro para otras cuentas por cobrar y otras por pagar para ayudar a presentar las cuentas pendientes
				' como en proveedores y clientes pero directamentee de contabilidad
				'-----------------------------------------------------------------------------------------
				' 9 nombre del cliente
				' 10 cliente 0,1
				' 11 proveedor 0,1
				' 12 anticipo 0,1
				' 13 es transferencia
				
				'            MsgBox NomClasifica.Count
				
				'            malla(i, 9) = !tra_CtasCobrar
				'            malla(i, 9) = !tra_CtasPagar
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ColClasifica.Count. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If ColClasifica.Count > 0 Then
					For	Each CampClasifica In ColClasifica
						'MsgBox CamClasifica.CAMPOTRA
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CampClasifica.idclave. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CampClasifica.CAMPOTRA. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto libdat.CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Malla(I, CampClasifica.idclave + 20) = libdat.CorrijeNulo(Rs1doc.Fields(CampClasifica.CAMPOTRA))
						'                 If malla(i, CamClasifica.Idclave + 20) > "" Then malla.ColWidth(CamClasifica.Idclave + 20) = 1100
					Next CampClasifica
				End If
				I = I + 1
				.MoveNext()
				
			Loop 
		End With
		Rs1doc.Close()
	End Sub
	
	
	
	
	
	
	'-------------------------------------- para guardar con recontabilizacion sin mallas
	
	Public Function GuardarDia2(ByRef IdClaveDoc As Double, ByRef Malla() As String, ByRef Suc As String, ByRef Doc As String, ByRef Num As Double, ByRef Fec As Date, Optional ByRef Ccosto As String = "", Optional ByRef Manual As String = "", Optional ByRef Predefinido As String = "") As Boolean
		Dim I As Short
		Dim Rs1doc As New ADODB.Recordset
		Dim cod As String
		Dim TotalReg As Integer
		On Error Resume Next
		Dim Debitos, Creditos As Double
		'UPGRADE_ISSUE: ColClasificador objeto no se actualizó. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
		Dim ColClasifica As New ColClasificador
		'UPGRADE_ISSUE: clasificador objeto no se actualizó. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
		Dim CamClasifica As New clasificador
		Dim cl As Short
		'UPGRADE_ISSUE: ClasificaCtb objeto no se actualizó. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
		Dim cca As New ClasificaCtb
		Dim tabla As String
		Dim RowsMalla As Integer
		Dim Campo As String
		RowsMalla = UBound(Malla)
		tabla = "Adcdia"
		If Predefinido > "" Then
			tabla = "EstandarDia"
			cod = "SELECT * FROM " & tabla & " WHERE est_documento='" & Predefinido & "' "
			ConxAdcom.Execute("delete from estandardia WHERE est_documento='" & Predefinido & "' ")
		Else
			cod = "SELECT * FROM " & tabla & " WHERE doc_sucursal='" & Suc & "' and opc_documento='" & Doc & "' and IdClaveDoc=" & IdClaveDoc
			EliminarRegistro(IdClaveDoc, Suc, Doc, Num)
		End If
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto cca.Cargar. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ColClasifica = cca.Cargar
		
		Rs1doc = New ADODB.Recordset
		
		Rs1doc.Open(cod, ConxAdcom, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
		TotalReg = 0
		
		If RowsMalla > 0 Then
			For I = 1 To RowsMalla
				If Malla(I, 1) > "" And (Val(Malla(I, 4)) > 0 Or Val(Malla(I, 5)) > 0) Then
					With Rs1doc
						TotalReg = TotalReg + 1
						.AddNew()
						If tabla = "Adcdia" Then
							.Fields("Doc_sucursal").Value = Suc
							.Fields("Opc_documento").Value = Doc
							.Fields("Doc_numero").Value = Num
							.Fields("DIA_STATUS").Value = Manual
							.Fields("IdClaveDoc").Value = IdClaveDoc
							.Fields("DIA_FECHA").Value = VB6.Format(Fec, "dd/mm/yyyy")
						Else
							.Fields("Est_Documento").Value = Predefinido
						End If
						.Fields("Dia_Linea").Value = I
						.Fields("CTA_CODIGO").Value = Malla(I, 1)
						.Fields("Dia_ctanombre").Value = Malla(I, 2)
						.Fields("Dia_detalle").Value = Malla(I, 3)
						If CDbl(Val(Malla(I, 4))) > 0 Then
							If IsNumeric(Malla(I, 4)) Then .Fields("Dia_valor").Value = CDbl(Malla(I, 4))
							.Fields("Dia_signo").Value = "1"
							Debitos = Debitos + CDbl(Val(Malla(I, 4)))
						Else
							If IsNumeric(Malla(I, 5)) Then .Fields("Dia_valor").Value = CDbl(Malla(I, 5))
							.Fields("Dia_signo").Value = "-1"
							Creditos = Creditos + CDbl(Val(Malla(I, 5)))
						End If
						
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ColClasifica.Count. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If ColClasifica.Count > 0 Then
							For cl = 26 To 50
								'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto libdat.CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								Campo = libdat.CorrijeNulo(Malla(I, cl))
								If Campo > "" Then
									'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ColClasifica.Item. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
									CamClasifica = ColClasifica.Item("C" & Trim(Malla(0, cl)))
									'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CamClasifica.campodia. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
									If CamClasifica.campodia > "" Then .Fields(CamClasifica.campodia).Value = Campo
								End If
							Next cl
						End If
						
						.Update()
						
					End With
				End If
			Next 
			Rs1doc.Close()
			ConxAdcom.Execute("update adcdoc set Dia_Status='" & Manual & "' where Doc_sucursal='" & Suc & "' AND Opc_documento ='" & Doc & "' and idclavedoc = " & IdClaveDoc)
			Debitos = System.Math.Round(Debitos, 2) - System.Math.Round(Creditos, 2)
			If Debitos <> 0 Then
				PonerHistorico("CTBComprobante descuadrado ", (ControlUsuario.Nombre), Today, (Emp.SucActual), Doc, Num, Debitos)
			End If
		End If
		If TotalReg = 0 Then
			PonerHistorico("CTBComprobante sin contabilidad ", (ControlUsuario.Nombre), Today, (Emp.SucActual), Doc, Num, 0)
		End If
		'UPGRADE_NOTE: El objeto ColClasifica no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		ColClasifica = Nothing
		'UPGRADE_NOTE: El objeto CamClasifica no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		CamClasifica = Nothing
		'UPGRADE_NOTE: El objeto cca no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		cca = Nothing
		
	End Function
End Module