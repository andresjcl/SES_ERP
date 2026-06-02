Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class SRIGENARCHIVOSCOA
	Inherits System.Windows.Forms.Form
	
	Dim RsSRI As New ADODB.Recordset
	Dim periodoaNIO, PERIODOmES As Short
	Dim año, mes As String
	Dim FechaIni, FechaFin As Date
	Dim ConError As Boolean
	
	Private Sub btngenerar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btngenerar.Click
		Dim nroEstablecimientos As Object
		Dim TOTALVENTAS As Object
		Dim periodo As Object
		''cambiar on error Resume Next
		Dim cod As String
		Dim Campo As String
		Dim NomComp(60) As String
		Dim NomVent(50) As String
		Dim NomImp(35) As String
		Dim NomAnu(15) As String
		Dim opAlex As New ManDirct.DirectorioAlex
		Dim sSQL As String
		If Reocc = True Then GenerarReoc() : Exit Sub
		NomComp(1) = "codSustento"
		NomComp(2) = "tpIdProv"
		NomComp(3) = "idProv"
		NomComp(4) = "tipoComprobante"
		NomComp(5) = "tipoProv"
		NomComp(6) = "parteRel"
		NomComp(7) = "fechaRegistro"
		NomComp(8) = "establecimiento"
		NomComp(9) = "puntoEmision"
		NomComp(10) = "secuencial"
		NomComp(11) = "fechaEmision"
		NomComp(12) = "autorizacion"
		NomComp(13) = "baseNoGraIva"
		NomComp(14) = "baseImponible"
		NomComp(15) = "baseImpGrav"
		NomComp(16) = "montoIce"
		NomComp(17) = "montoIva"
		NomComp(18) = "valorRetBienes"
		NomComp(19) = "valorRetServicios"
		NomComp(20) = "valRetServ100"
		NomComp(21) = "pagoLocExt"
		NomComp(22) = "paisEfecPago"
		NomComp(23) = "aplicConvDobTrib"
		NomComp(24) = "pagExtSujRetNorLeg"
		NomComp(25) = "formaPago"
		NomComp(26) = "codRetAir"
		NomComp(27) = "baseImpAir"
		NomComp(28) = "porcentajeAir"
		NomComp(29) = "valRetAir"
		NomComp(30) = "fechaPagoDiv"
		NomComp(31) = "imRentaSoc"
		NomComp(32) = "anioUtDiv"
		
		NomComp(33) = "estabRetencion1"
		NomComp(34) = "ptoEmiRetencion1"
		NomComp(35) = "secRetencion1"
		NomComp(36) = "autRetencion1"
		NomComp(37) = "fechaEmiRet1"
		NomComp(38) = "docModificado"
		NomComp(39) = "estabModificado"
		NomComp(40) = "ptoEmiModificado"
		NomComp(41) = "secModificado"
		NomComp(42) = "autModificado"
		
		NomComp(43) = "tipoComprobanteReemb"
		NomComp(44) = "tpIdProvReemb"
		NomComp(45) = "idProvReemb"
		NomComp(46) = "establecimientoReemb"
		NomComp(47) = "puntoEmisionReemb"
		NomComp(48) = "secuencialReemb"
		NomComp(49) = "fechaEmisionReemb"
		NomComp(50) = "autorizacionReemb"
		NomComp(51) = "baseImponibleReemb"
		NomComp(52) = "baseImpGravReemb"
		NomComp(53) = "baseNoGraIvaReemb"
		NomComp(54) = "montoIceReemb"
		NomComp(55) = "montoIvaRemb"
		
		
		NomVent(1) = "tpIdCliente"
		NomVent(2) = "idCliente"
		NomVent(3) = "tipoComprobante"
		NomVent(4) = "numeroComprobantes"
		NomVent(5) = "baseNoGraIva"
		NomVent(6) = "baseImponible"
		NomVent(7) = "baseImpGrav"
		NomVent(8) = "montoIva"
		NomVent(9) = "valorRetIva"
		NomVent(10) = "valorRetRenta"
		NomVent(11) = "codEstab"
		NomVent(12) = "ventasEstab"
		
		NomImp(1) = "exportacionDe"
		NomImp(2) = "tipoComprobante"
		NomImp(3) = "distAduanero"
		NomImp(4) = "anio"
		NomImp(5) = "regimen"
		NomImp(6) = "correlativo"
		NomImp(7) = "verificador"
		NomImp(8) = "docTransp"
		NomImp(9) = "fechaEmbarque"
		NomImp(10) = "fue"
		NomImp(11) = "valorFOB"
		NomImp(12) = "valorFOBComprobante"
		NomImp(13) = "establecimiento"
		NomImp(14) = "puntoEmision"
		NomImp(15) = "secuencial"
		NomImp(16) = "autorizacion"
		NomImp(17) = "fechaEmision"
		
		NomAnu(1) = "tipoComprobante"
		NomAnu(2) = "establecimiento"
		NomAnu(3) = "puntoEmision"
		NomAnu(4) = "secuencialInicio"
		NomAnu(5) = "secuencialFin"
		NomAnu(6) = "autorizacion"
		
		año = Anios.Text
		mes = CStr(Meses.SelectedIndex + 1)
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto periodo. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		periodo = mes & año
		Avance.Visible = True
		Avance.Value = 0
		FechaIni = CDate("01/" & mes & "/" & año)
		FechaFin = FechaFinMes(Val(año), Val(mes))
		CrearArchivos()
		If ConError = True Then MsgBox("El nombre del archivo no es válido ", MsgBoxStyle.Critical) : Exit Sub
		'/////////////////////////////////////////////////////////
		'Archivo Identificacion
		'///// grabacion de cabezera
		
		sSQL = "SELECT SUM((CL_BASENOGRABAIVA + CL_BASEIMPTARCERO+CL_BASEIMPGRAVADAIVA) ) AS TOTALVENTAS From ventas where cl_mes = " & mes & " and cl_anio = " & año
		If RsSRI.State = 1 Then RsSRI.Close()
		RsSRI.CursorType = ADOR.CursorTypeEnum.adOpenKeyset
		RsSRI.LockType = ADOR.LockTypeEnum.adLockOptimistic
		RsSRI.Open(sSQL, ConxSri,  ,  , ADODB.CommandTypeEnum.adCmdText)
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto TOTALVENTAS. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If RsSRI.EOF Then
			TOTALVENTAS = 0
		Else
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto TOTALVENTAS. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TOTALVENTAS = CorrijeNuloN(RsSRI.Fields("TOTALVENTAS"))
		End If
		RsSRI.Close()
		
		
		sSQL = "SELECT count(idestab) as totalestable From resVentas where mes = " & mes & " and anio = " & año
		If RsSRI.State = 1 Then RsSRI.Close()
		RsSRI.CursorType = ADOR.CursorTypeEnum.adOpenKeyset
		RsSRI.LockType = ADOR.LockTypeEnum.adLockOptimistic
		RsSRI.Open(sSQL, ConxSri,  ,  , ADODB.CommandTypeEnum.adCmdText)
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto nroEstablecimientos. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If RsSRI.EOF Then
			nroEstablecimientos = 0
		Else
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto nroEstablecimientos. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			nroEstablecimientos = CorrijeNuloN(RsSRI.Fields("TOTALestable"))
		End If
		RsSRI.Close()
		
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto opAlex.CargarAlex. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		opAlex.CargarAlex(Emp.ruc, True)
		Campo = ""
		GrabarCampoXML("iva", "", 1, CStr(12), 1)
		
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto opAlex.TipoId. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		GrabarCampoXML("TipoIDInformante", CorrijeTipoId(opAlex.TipoId), 1, CStr(1), 2)
		GrabarCampoXML("IdInformante", (Emp.ruc), 1, CStr(13), 2)
		GrabarCampoXML("razonSocial", (Emp.Nombre), 1, CStr(500), 2)
		GrabarCampoXML("Anio", Str(CDbl(año)), 3, CStr(4), 2)
		GrabarCampoXML("Mes", mes, 3, CStr(2), 2)
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto nroEstablecimientos. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		GrabarCampoXML("numEstabRuc", Str(nroEstablecimientos), 3, CStr(3), 2)
		GrabarCampoXML("totalVentas", Str(CorrijeNuloN(TOTALVENTAS)), 2, CStr(12), 2)
		GrabarCampoXML("codigoOperativo", "IVA", 1, CStr(3), 2)
		
		'/////////////////////////////////////////////////////////
		GrabarCampoXML("compras", "", 1, CStr(30), 1)
		
		cod = "SELECT * FROM Compras  where Cl_mes = " & PerMes & " and cl_anio = " & PerAnio
		
		If RsSRI.State = 1 Then RsSRI.Close()
		RsSRI.CursorType = ADOR.CursorTypeEnum.adOpenKeyset
		RsSRI.LockType = ADOR.LockTypeEnum.adLockOptimistic
		RsSRI.Open(cod, ConxSri,  ,  , ADODB.CommandTypeEnum.adCmdText)
		With RsSRI
			Do Until .EOF
				GrabarCampoXML("detalleCompras", "", 1, CStr(30), 1)
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto opAlex.CargarAlex. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				opAlex.CargarAlex(CorrijeNulo(.Fields("CL_CodigoProveedor")), True)
				Debug.Print(.Fields("CL_CodigoProveedor").Value)
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(RsSRI!CL_SusTributario). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				GrabarCampoXML(NomComp(1), CorrijeNulo(.Fields("CL_SusTributario")), 3, CStr(2), 2)
				GrabarCampoXML(NomComp(2), TipoIdSri(.Fields("CL_TipoIdProveedor").Value, "C"), 3, CStr(2), 2)
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(RsSRI!CL_CodigoProveedor). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				GrabarCampoXML(NomComp(3), CorrijeNulo(.Fields("CL_CodigoProveedor")), 1, CStr(13), 2)
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(RsSRI!Cl_TipoComprobante). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				GrabarCampoXML(NomComp(4), CorrijeNulo(.Fields("Cl_TipoComprobante")), 3, CStr(2), 2)
				If CDbl(TipoIdSri(.Fields("CL_TipoIdProveedor").Value, "C")) = 3 Then
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto opAlex.TipoId. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					GrabarCampoXML(NomComp(5), opAlex.TipoId, 3, CStr(2), 2)
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto opAlex.TipoPersona. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(opAlex.TipoPersona). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					GrabarCampoXML(NomComp(6), CorrijeNulo(opAlex.TipoPersona), 1, CStr(2), 2)
				End If
				GrabarCampoXML(NomComp(7), VB6.Format(.Fields("CL_FechaRegContable").Value, "dd/mm/yyyy"), 1, CStr(10), 2)
				GrabarCampoXML(NomComp(8), CStr(CorrijeNuloN(.Fields("CL_NroSerieEstablec"))), 3, CStr(3), 2)
				GrabarCampoXML(NomComp(9), CStr(CorrijeNuloN(.Fields("CL_NroSeriePtoEmision"))), 3, CStr(3), 2)
				GrabarCampoXML(NomComp(10), CStr(CorrijeNuloN(.Fields("CL_NroSecuencial"))), 1, CStr(9), 2)
				GrabarCampoXML(NomComp(11), VB6.Format(.Fields("CL_FechaComprobante").Value, "dd/mm/yyyy"), 1, CStr(10), 2)
				GrabarCampoXML(NomComp(12), .Fields("CL_NroAutorizacion").Value, 1, CStr(40), 2)
				GrabarCampoXML(NomComp(13), .Fields("CL_BaseNoGrabaIva").Value, 2, CStr(12), 2)
				GrabarCampoXML(NomComp(14), .Fields("CL_BaseImpTarCero").Value, 2, CStr(12), 2)
				GrabarCampoXML(NomComp(15), .Fields("CL_BaseImpGravadaIva").Value, 2, CStr(12), 2)
				GrabarCampoXML(NomComp(16), .Fields("CL_MontoICE").Value, 2, CStr(12), 2)
				GrabarCampoXML(NomComp(17), .Fields("CL_MontoIva").Value, 2, CStr(12), 2)
				GrabarCampoXML(NomComp(18), .Fields("CL_MontoRetIvaBienes").Value, 2, CStr(12), 2)
				GrabarCampoXML(NomComp(19), .Fields("CL_MontoRetIvaServicios").Value, 2, CStr(12), 2)
				GrabarCampoXML(NomComp(20), CStr(CorrijeNuloN(.Fields("CL_MontoRetIva100"))), 2, CStr(12), 2)
				
				GrabarCampoXML("pagoExterior", "", 1, CStr(30), 1)
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(RsSRI!CL_pagoLocExt). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				GrabarCampoXML(NomComp(21), CorrijeNulo(.Fields("CL_pagoLocExt")), 3, CStr(2), 2)
				If CorrijeNuloN(.Fields("CL_pagoLocExt")) = 2 Then
					GrabarCampoXML(NomComp(22), CStr(CorrijeNuloN(.Fields("CL_pagoPais"))), 1, CStr(50), 2)
					GrabarCampoXML(NomComp(23), CStr(CorrijeNuloN(.Fields("CL_dobleTributacion"))), 1, CStr(2), 2)
					GrabarCampoXML(NomComp(24), CStr(CorrijeNuloN(.Fields("CL_pagoSujetoRetencion"))), 1, CStr(2), 2)
				Else
					GrabarCampoXML(NomComp(22), "NA", 1, CStr(2), 2)
					GrabarCampoXML(NomComp(23), "NA", 1, CStr(2), 2)
					GrabarCampoXML(NomComp(24), "NA", 1, CStr(2), 2)
				End If
				GrabarCampoXML("pagoExterior", "", 1, CStr(30), 3)
				
				If .Fields("CL_BaseNoGrabaIva").Value + .Fields("CL_BaseImpTarCero").Value + .Fields("CL_BaseImpGravadaIva").Value + .Fields("CL_MontoICE").Value + .Fields("CL_MontoIva").Value >= 1000 Then
					
					GrabarCampoXML("formasDePago", "", 1, CStr(30), 1)
					'                    If !CL_formaDePago = 999 Then
					'                            sSQL = "select ISNULL(SRI_formaDePago,00),Pag_Idpago  from adcpag A LEFT JOIN FormasDePago F"
					'                            sSQL = sSQL & " ON A.Pag_Idpago  = F.IdFormasDePago"
					'                            sSQL = sSQL & " where Pag_Numero = 1 AND "
					'                            sSQL = sSQL & " a.Opc_documento = '" & FAP ' AND A.DOC_SUCURSAL = 'QUI' AND A.IdClaveDoc = 88082010"
					'                        Else
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(RsSRI!CL_formaDePago). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					GrabarCampoXML(NomComp(25), CorrijeNulo(.Fields("CL_formaDePago")), 3, CStr(2), 2)
					'                    End If
					GrabarCampoXML("formasDePago", "", 1, CStr(30), 3)
				End If
				
				GrabarCampoXML("air", "", 1, CStr(30), 1)
				If Val(.Fields("CL_CodRetFteImpRenta0").Value) > 0 Then
					GrabarCampoXML("detalleAir", "", 1, CStr(30), 1)
					GrabarCampoXML(NomComp(26), .Fields("CL_CodRetFteImpRenta0").Value, 1, CStr(3), 2)
					GrabarCampoXML(NomComp(27), .Fields("CL_BaseImponibleIR0").Value, 2, CStr(12), 2)
					GrabarCampoXML(NomComp(28), .Fields("CL_CodPorcRetIR0").Value, 1, CStr(5), 2)
					GrabarCampoXML(NomComp(29), .Fields("CL_MontoRetIR0").Value, 2, CStr(12), 2)
					If .Fields("CL_CodRetFteImpRenta0").Value = "345" Or .Fields("CL_CodRetFteImpRenta0").Value = "346" Then
						GrabarCampoXML(NomComp(30), VB6.Format(.Fields("CL_fecPagoDividendo").Value, "dd/mm/yyyy"), 1, CStr(10), 2)
						GrabarCampoXML(NomComp(31), .Fields("CL_impRentaPagadoSoc0").Value, 2, CStr(12), 2)
						GrabarCampoXML(NomComp(32), .Fields("CL_añoGeneraUtilidad0").Value, 2, CStr(2), 2)
					End If
					GrabarCampoXML("detalleAir", "", 1, CStr(30), 3)
				End If
				If Val(.Fields("CL_CodRetFteImpRenta1").Value) > 0 Then
					GrabarCampoXML("detalleAir", "", 1, CStr(30), 1)
					GrabarCampoXML(NomComp(26), .Fields("CL_CodRetFteImpRenta1").Value, 1, CStr(3), 2)
					GrabarCampoXML(NomComp(27), .Fields("CL_BaseImponibleIR1").Value, 2, CStr(12), 2)
					GrabarCampoXML(NomComp(28), .Fields("CL_CodPorcRetIR1").Value, 1, CStr(5), 2)
					GrabarCampoXML(NomComp(29), .Fields("CL_MontoRetIR1").Value, 2, CStr(12), 2)
					If .Fields("CL_CodRetFteImpRenta1").Value = "345" Or .Fields("CL_CodRetFteImpRenta1").Value = "346" Then
						GrabarCampoXML(NomComp(30), VB6.Format(CorrijeNuloF(.Fields("CL_fecPagoDividendo")), "dd/mm/yyyy"), 1, CStr(10), 2)
						GrabarCampoXML(NomComp(31), .Fields("CL_impRentaPagadoSoc1").Value, 2, CStr(12), 2)
						GrabarCampoXML(NomComp(32), .Fields("CL_añoGeneraUtilidad1").Value, 2, CStr(2), 2)
					End If
					GrabarCampoXML("detalleAir", "", 1, CStr(30), 3)
				End If
				GrabarCampoXML("air", "", 1, CStr(12), 3)
				If (Val(.Fields("CL_CodPorcRetIR0").Value) <> 0 Or Val(.Fields("CL_CodPorcRetIR1").Value) <> 0) And Val(.Fields("CL_NroSecuencialCpbteRet").Value) > 0 And Val(.Fields("CL_NroSerieCpbteRetEstable").Value) > 0 Then
					GrabarCampoXML(NomComp(33), .Fields("CL_NroSerieCpbteRetEstable").Value, 3, CStr(3), 2)
					GrabarCampoXML(NomComp(34), .Fields("CL_NroSerieCpbteRetEmision").Value, 3, CStr(3), 2)
					GrabarCampoXML(NomComp(35), .Fields("CL_NroSecuencialCpbteRet").Value, 1, CStr(9), 2)
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(RsSRI!CL_NroAutorizaCpbteRete). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					GrabarCampoXML(NomComp(36), CorrijeNulo(.Fields("CL_NroAutorizaCpbteRete")), 1, CStr(10), 2)
					If IsDate(.Fields("CL_FechaEmisionCpbteRete").Value) And .Fields("CL_FechaEmisionCpbteRete").Value <> "00:00:00" Then
						GrabarCampoXML(NomComp(37), VB6.Format(.Fields("CL_FechaEmisionCpbteRete").Value, "dd/mm/yyyy"), 1, CStr(10), 2)
					Else
						GrabarCampoXML(NomComp(37), "01/" & VB.Right("00" & PerMes, 2) & "/" & PerAnio, 1, CStr(10), 2)
					End If
				End If
				
				If Val(.Fields("Cl_TipoComprobante").Value) = 4 Or Val(.Fields("Cl_TipoComprobante").Value) = 5 Then
					GrabarCampoXML(NomComp(38), .Fields("CL_CodigoTipoModificado").Value, 3, CStr(2), 2)
					GrabarCampoXML(NomComp(39), .Fields("CL_NroSerieModificadoEstab").Value, 3, CStr(3), 2)
					GrabarCampoXML(NomComp(40), .Fields("CL_NroSerieModificadoEmision").Value, 3, CStr(3), 2)
					GrabarCampoXML(NomComp(41), .Fields("CL_NroSecuencialModificado").Value, 1, CStr(9), 2)
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(RsSRI!CL_NroAutorizaModificado). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					GrabarCampoXML(NomComp(42), CorrijeNulo(.Fields("CL_NroAutorizaModificado")), 1, CStr(37), 2)
				End If
				
				If .Fields("Cl_TipoComprobante").Value = "41" Then
					GrabarCampoXML("reembolsos", "", 1, CStr(30), 1)
					GrabarCampoXML("reembolso", "", 1, CStr(30), 1)
					
					GrabarCampoXML(NomComp(43), .Fields("CL_tipoComprobanteReemb").Value, 3, CStr(2), 2)
					GrabarCampoXML(NomComp(44), .Fields("CL_tpIdProvReemb").Value, 3, CStr(2), 2)
					GrabarCampoXML(NomComp(45), .Fields("CL_idProvReemb").Value, 1, CStr(13), 2)
					GrabarCampoXML(NomComp(46), .Fields("CL_establecimientoReemb").Value, 3, CStr(3), 2)
					GrabarCampoXML(NomComp(47), .Fields("CL_puntoEmisionReemb").Value, 3, CStr(3), 2)
					GrabarCampoXML(NomComp(48), .Fields("CL_secuencialReemb").Value, 3, CStr(9), 2)
					GrabarCampoXML(NomComp(49), VB6.Format(.Fields("CL_fechaEmisionReemb").Value, "dd/mm/yyyy"), 1, CStr(10), 2)
					GrabarCampoXML(NomComp(50), .Fields("CL_autorizacionReemb").Value, 1, CStr(37), 2)
					GrabarCampoXML(NomComp(51), .Fields("CL_baseImponibleReemb").Value, 2, CStr(12), 2)
					GrabarCampoXML(NomComp(52), .Fields("CL_baseImpGravReemb").Value, 2, CStr(12), 2)
					GrabarCampoXML(NomComp(53), .Fields("CL_baseNoGraIvaReemb").Value, 2, CStr(12), 2)
					GrabarCampoXML(NomComp(54), .Fields("CL_montoIceReemb").Value, 2, CStr(12), 2)
					GrabarCampoXML(NomComp(55), .Fields("CL_montoIvaRemb").Value, 2, CStr(12), 2)
					
					GrabarCampoXML("reembolso", "", 1, CStr(30), 3)
					GrabarCampoXML("reembolsos", "", 1, CStr(30), 3)
				End If
				GrabarCampoXML("detalleCompras", "", 1, CStr(30), 3)
				.MoveNext()
			Loop 
			.Close()
		End With
		
		GrabarCampoXML("compras", "", 1, CStr(12), 3)
		
		'/////////////////////////////////////////////////////////
		
		cod = "SELECT * From ventas where cl_mes = " & mes & " and cl_anio = " & año
		
		If RsSRI.State = 1 Then RsSRI.Close()
		RsSRI.CursorType = ADOR.CursorTypeEnum.adOpenKeyset
		RsSRI.LockType = ADOR.LockTypeEnum.adLockOptimistic
		RsSRI.Open(cod, ConxSri,  ,  , ADODB.CommandTypeEnum.adCmdText)
		GrabarCampoXML("ventas", "", 1, CStr(30), 1)
		With RsSRI
			Do Until .EOF
				GrabarCampoXML("detalleVentas", "", 1, CStr(30), 1)
				GrabarCampoXML(NomVent(1), TipoIdSri(.Fields("CL_TipoId").Value, "V"), 3, CStr(2), 2)
				GrabarCampoXML(NomVent(2), .Fields("CL_CodigoCliente").Value, 1, CStr(13), 2)
				GrabarCampoXML(NomVent(3), .Fields("Cl_TipoComprobante").Value, 3, CStr(2), 2)
				GrabarCampoXML(NomVent(4), .Fields("CL_NroDeComprobantes").Value, 1, CStr(12), 2)
				GrabarCampoXML(NomVent(5), .Fields("CL_BaseNoGrabaIva").Value, 2, CStr(12), 2)
				GrabarCampoXML(NomVent(6), .Fields("CL_BaseImpTarCero").Value, 2, CStr(12), 2)
				GrabarCampoXML(NomVent(7), .Fields("CL_BaseImpGravadaIva").Value, 2, CStr(12), 2)
				GrabarCampoXML(NomVent(8), .Fields("CL_MontoIva").Value, 2, CStr(12), 2)
				GrabarCampoXML(NomVent(9), .Fields("CL_ValorRetIva").Value, 2, CStr(12), 2)
				GrabarCampoXML(NomVent(10), .Fields("CL_ValorRetRenta").Value, 2, CStr(12), 2)
				GrabarCampoXML("detalleVentas", "", 1, CStr(30), 3)
				.MoveNext()
			Loop 
			GrabarCampoXML("ventas", "", 1, CStr(30), 3)
			.Close()
		End With
		
		
		cod = "SELECT * From resVentas where mes = " & mes & " and anio = " & año
		
		If RsSRI.State = 1 Then RsSRI.Close()
		RsSRI.CursorType = ADOR.CursorTypeEnum.adOpenKeyset
		RsSRI.LockType = ADOR.LockTypeEnum.adLockOptimistic
		RsSRI.Open(cod, ConxSri,  ,  , ADODB.CommandTypeEnum.adCmdText)
		
		With RsSRI
			If .State = 1 Then
				GrabarCampoXML("ventasEstablecimiento", "", 1, CStr(30), 1)
				Do Until .EOF
					GrabarCampoXML("ventaEst", "", 1, CStr(30), 1)
					
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(RsSRI!idEstab). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					GrabarCampoXML(NomVent(11), CorrijeNulo(.Fields("idEstab")), 3, CStr(3), 2)
					GrabarCampoXML(NomVent(12), CStr(CorrijeNuloN(.Fields("TotVenta"))), 2, CStr(12), 2)
					
					GrabarCampoXML("ventaEst", "", 1, CStr(30), 3)
					.MoveNext()
				Loop 
				GrabarCampoXML("ventasEstablecimiento", "", 1, CStr(30), 3)
			End If
		End With
		
		
		
		'/////////////////////////////////////////////////////////
		
		cod = "SELECT * From exportacion where month(CL_FechaEmision) = " & PerMes & " and year(CL_FechaEmision)= " & PerAnio
		
		If RsSRI.State = 1 Then RsSRI.Close()
		RsSRI.CursorType = ADOR.CursorTypeEnum.adOpenKeyset
		RsSRI.LockType = ADOR.LockTypeEnum.adLockOptimistic
		RsSRI.Open(cod, ConxSri,  ,  , ADODB.CommandTypeEnum.adCmdText)
		GrabarCampoXML("exportaciones", "", 1, CStr(30), 1)
		With RsSRI
			Do Until .EOF
				GrabarCampoXML("detalleExportaciones", "", 1, CStr(30), 1)
				GrabarCampoXML(NomImp(1), .Fields("CL_ExportaciónDe").Value, 3, CStr(2), 2)
				GrabarCampoXML(NomImp(2), .Fields("Cl_TipoComprobante").Value, 3, CStr(2), 2)
				If .Fields("CL_ReferendoDistrito").Value > "" Then GrabarCampoXML(NomImp(3), .Fields("CL_ReferendoDistrito").Value, 3, CStr(3), 2)
				If .Fields("CL_ReferendoAño").Value > "" Then GrabarCampoXML(NomImp(4), .Fields("CL_ReferendoAño").Value, 1, CStr(4), 2)
				If .Fields("CL_ReferendoRegimen").Value > "" Then GrabarCampoXML(NomImp(5), .Fields("CL_ReferendoRegimen").Value, 3, CStr(2), 2)
				If .Fields("CL_ReferendoCorrelativo").Value > "" Then GrabarCampoXML(NomImp(6), .Fields("CL_ReferendoCorrelativo").Value, 3, CStr(8), 2)
				If .Fields("CL_ReferendoVerificador").Value > "" Then GrabarCampoXML(NomImp(7), .Fields("CL_ReferendoVerificador").Value, 1, CStr(1), 2)
				GrabarCampoXML(NomImp(8), .Fields("CL_NroDocTransporte").Value, 3, CStr(13), 2)
				GrabarCampoXML(NomImp(9), .Fields("CL_FechaTransaccion").Value, 1, CStr(10), 2)
				'GrabarCampoXML NomImp(10), !CL_NroFue, 3, 13, 2
				GrabarCampoXML(NomImp(11), .Fields("CL_ValorFOB").Value, 2, CStr(12), 2)
				GrabarCampoXML(NomImp(12), .Fields("CL_ValorComprobante").Value, 2, CStr(12), 2)
				GrabarCampoXML(NomImp(13), .Fields("CL_NroSerieCpbteEstablec").Value, 3, CStr(3), 2)
				GrabarCampoXML(NomImp(14), .Fields("CL_NroSerieCpbteEmision").Value, 3, CStr(3), 2)
				GrabarCampoXML(NomImp(15), .Fields("CL_NroSecuencialCpbte").Value, 3, CStr(9), 2)
				GrabarCampoXML(NomImp(16), .Fields("CL_NroAutorizacion").Value, 3, CStr(37), 2)
				GrabarCampoXML(NomImp(17), .Fields("CL_FechaEmision").Value, 1, CStr(10), 2)
				GrabarCampoXML("detalleExportaciones", "", 1, CStr(12), 3)
				.MoveNext()
			Loop 
			GrabarCampoXML("exportaciones", "", 1, CStr(30), 3)
			.Close()
		End With
		
		cod = "SELECT * From anulados where mes = " & mes & " and anio = " & año
		GrabarCampoXML("anulados", "", 1, CStr(30), 1)
		If RsSRI.State = 1 Then RsSRI.Close()
		RsSRI.CursorType = ADOR.CursorTypeEnum.adOpenKeyset
		RsSRI.LockType = ADOR.LockTypeEnum.adLockOptimistic
		RsSRI.Open(cod, ConxSri,  ,  , ADODB.CommandTypeEnum.adCmdText)
		With RsSRI
			Do Until .EOF
				GrabarCampoXML("detalleAnulados", "", 1, CStr(30), 1)
				GrabarCampoXML(NomAnu(1), .Fields("Cl_TipoComprobante").Value, 3, CStr(2), 2)
				GrabarCampoXML(NomAnu(2), .Fields("CL_NroSerieEstableci").Value, 3, CStr(3), 2)
				GrabarCampoXML(NomAnu(3), .Fields("CL_NroSerieEmision").Value, 3, CStr(3), 2)
				GrabarCampoXML(NomAnu(4), .Fields("CL_NroSecuencialDesde").Value, 1, CStr(9), 2)
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(RsSRI!CL_NroSecuencialHasta). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				GrabarCampoXML(NomAnu(5), CorrijeNulo(.Fields("CL_NroSecuencialHasta")), 1, CStr(9), 2)
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(RsSRI!CL_NroAutorizacion). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				GrabarCampoXML(NomAnu(6), CorrijeNulo(.Fields("CL_NroAutorizacion")), 3, CStr(37), 2)
				'   GrabarCampoXML NomAnu(7), !CL_FechaAnulacion, 1, 10, 2
				GrabarCampoXML("detalleAnulados", "", 1, CStr(30), 3)
				.MoveNext()
			Loop 
			GrabarCampoXML("anulados", "", 1, CStr(30), 3)
			.Close()
		End With
		GrabarCampoXML("iva", "", 1, CStr(12), 3)
		FileClose(1)
		Avance.Value = Avance.Max
		Avance.Visible = False
		MsgBox("El archivo del anexo Transaccional se genéro exitosamente", MsgBoxStyle.Information)
		
	End Sub
	
	Private Sub GenerarReoc()
		Dim periodo As Object
		Dim cod As String
		Dim Campo As String
		Dim NomComp(45) As String
		Dim NomVent(35) As String
		Dim NomImp(30) As String
		Dim NomAnu(10) As String
		Dim opAlex As New ManDirct.Directorio
		
		'numeroRuc
		'anio
		'Mes
		'tpIdProv
		'idProv
		'tipoComp
		'aut
		'Estab
		'ptoEmi
		'sec
		'fechaEmiCom
		'codRetAir
		'Porcentaje
		'base0
		'baseGrav
		'baseNoGrav
		'valRetAir
		'autRet
		'estabRet
		'ptoEmiRet
		'secRet
		'fechaEmiRet
		'autRet1
		'estabRet1
		'ptoEmiRet1
		'secRet1
		'fechaEmiRet1
		
		NomComp(1) = "tpIdProv"
		NomComp(2) = "idProv"
		NomComp(3) = "tipoComp"
		NomComp(4) = "aut"
		NomComp(5) = "estab"
		NomComp(6) = "ptoEmi"
		NomComp(7) = "sec"
		NomComp(8) = "fechaEmiCom"
		NomComp(9) = "codRetAir"
		NomComp(10) = "porcentaje"
		NomComp(11) = "base0"
		NomComp(12) = "baseGrav"
		NomComp(13) = "baseNoGrav"
		NomComp(14) = "valRetAir"
		NomComp(15) = "autRet"
		NomComp(16) = "estabRet"
		NomComp(17) = "ptoEmiRet"
		NomComp(18) = "secRet"
		NomComp(19) = "fechaEmiRet"
		
		
		año = Anios.Text
		mes = CStr(Meses.SelectedIndex + 1)
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto periodo. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		periodo = mes & año
		Avance.Visible = True
		Avance.Value = 0
		FechaIni = CDate("01/" & mes & "/" & año)
		FechaFin = FechaFinMes(Val(año), Val(mes))
		CrearArchivos()
		
		'/////////////////////////////////////////////////////////
		'Archivo Identificacion
		'///// grabacion de cabezera
		
		Campo = ""
		GrabarCampoXML("reoc", "", 1, CStr(12), 1)
		
		'numeroRuc
		'anio
		'Mes
		
		GrabarCampoXML("numeroRuc", (Emp.ruc), 1, CStr(13), 2)
		'GrabarCampoXML "razonSocial", Emp.Nombre, 1, 60, 2
		'GrabarCampoXML "direccionMatriz", Emp.direccion, 1, 60, 2
		'GrabarCampoXML "telefono", Emp.telefono1, 3, 9, 2
		'GrabarCampoXML "fax", Emp.fax, 3, 9, 2
		'GrabarCampoXML "email", Emp.email, 1, 60, 2
		'opAlex.CargarAlex Emp.RepLegal, True, ""
		'GrabarCampoXML "tpIdRepre", CorrijeTipoId(opAlex.TipoId), 1, 1, 2
		'GrabarCampoXML "idRepre", opAlex.CiRuc, 1, 10, 2
		'opAlex.CargarAlex Emp.Contador, True, ""
		'GrabarCampoXML "rucContador", opAlex.CiRuc, 1, 13, 2
		GrabarCampoXML("anio", Str(CDbl(año)), 3, CStr(4), 2)
		GrabarCampoXML("mes", mes, 3, CStr(2), 2)
		
		'/////////////////////////////////////////////////////////
		
		
		'/////////////////////////////////////////////////////////
		GrabarCampoXML("compras", "", 1, CStr(30), 1)
		
		cod = "SELECT * FROM ComprasR  where month(fechaEmiCom) = " & mes & " and year(fechaEmiCom)= " & año
		
		If RsSRI.State = 1 Then RsSRI.Close()
		RsSRI.CursorType = ADOR.CursorTypeEnum.adOpenKeyset
		RsSRI.LockType = ADOR.LockTypeEnum.adLockOptimistic
		RsSRI.Open(cod, ConxSri,  ,  , ADODB.CommandTypeEnum.adCmdText)
		With RsSRI
			Do Until .EOF
				GrabarCampoXML("detalleCompras", "", 1, CStr(30), 1)
				
				GrabarCampoXML(NomComp(1), .Fields("tpidProv").Value, 3, CStr(2), 2)
				GrabarCampoXML(NomComp(2), .Fields("idProv").Value, 1, CStr(13), 2)
				GrabarCampoXML(NomComp(3), .Fields("tipoComp").Value, 1, CStr(2), 2)
				GrabarCampoXML(NomComp(4), .Fields("aut").Value, 1, CStr(10), 2)
				GrabarCampoXML(NomComp(5), .Fields("Estab").Value, 3, CStr(3), 2)
				GrabarCampoXML(NomComp(6), .Fields("ptoEmi").Value, 3, CStr(3), 2)
				GrabarCampoXML(NomComp(7), .Fields("sec").Value, 1, CStr(7), 2)
				GrabarCampoXML(NomComp(8), VB6.Format(.Fields("fechaEmiCom").Value, "dd/mm/yyyy"), 1, CStr(10), 2)
				
				GrabarCampoXML("air", "", 1, CStr(30), 1)
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(RsSRI!codRetAir). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If CorrijeNulo(.Fields("codRetAir")) > "" Then
					GrabarCampoXML("detalleAir", "", 1, CStr(30), 1)
					GrabarCampoXML(NomComp(9), .Fields("codRetAir").Value, 1, CStr(5), 2)
					GrabarCampoXML(NomComp(10), .Fields("Porcentaje").Value, 1, CStr(5), 2)
					GrabarCampoXML(NomComp(11), .Fields("base0").Value, 2, CStr(12), 2)
					GrabarCampoXML(NomComp(12), .Fields("baseGrav").Value, 2, CStr(12), 2)
					GrabarCampoXML(NomComp(13), .Fields("baseNoGrav").Value, 2, CStr(12), 2)
					GrabarCampoXML(NomComp(14), .Fields("valRetAir").Value, 2, CStr(12), 2)
					GrabarCampoXML("detalleAir", "", 1, CStr(30), 3)
				End If
				
				GrabarCampoXML("air", "", 1, CStr(12), 3)
				If Val(.Fields("codRetAir").Value) > 0 Then
					GrabarCampoXML(NomComp(15), .Fields("autRet").Value, 3, CStr(10), 2)
					GrabarCampoXML(NomComp(16), .Fields("estabRet").Value, 3, CStr(3), 2)
					GrabarCampoXML(NomComp(17), .Fields("ptoEmiRet").Value, 3, CStr(3), 2)
					GrabarCampoXML(NomComp(18), .Fields("secRet").Value, 1, CStr(7), 2)
					If IsDate(.Fields("FECHAEMIRET").Value) Then 'And !FECHAEMIRET > CDate("31/12/1900") Then
						GrabarCampoXML(NomComp(19), VB6.Format(.Fields("FECHAEMIRET").Value, "dd/mm/yyyy"), 1, CStr(10), 2)
					Else
						GrabarCampoXML(NomComp(19), "01/" & VB.Right("00" & PerMes, 2) & "/" & PerAnio, 1, CStr(10), 2)
					End If
				End If
				GrabarCampoXML("detalleCompras", "", 1, CStr(30), 3)
				.MoveNext()
				'Avance.Value = Avance.Value + 1
			Loop 
			.Close()
		End With
		
		GrabarCampoXML("compras", "", 1, CStr(12), 3)
		GrabarCampoXML("reoc", "", 1, CStr(12), 3)
		FileClose(1)
		Avance.Value = Avance.Max
		Avance.Visible = False
		MsgBox("El archivo del anexo Transaccional se genéro exitosamente", MsgBoxStyle.Information)
		
	End Sub
	Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
		Dim PathFuente As Object
		'UPGRADE_WARNING: La variable CommonDialog no se actualizó Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="671167DC-EA81-475D-B690-7A40C7BF4A23"'
		With dialogo
			.Title = "Ubicacion del archivo  "
			'UPGRADE_WARNING: Filter tiene un nuevo comportamiento. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			.Filter = "(*.xml;)|*.xml;"
			.InitialDirectory = "\TMP"
			.FileName = Text3.Text
			.ShowDialog()
			If dialogoOpen.FileName <> "" Then
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto PathFuente. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				PathFuente = .FileName
			End If
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto PathFuente. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Text3.Text = PathFuente
		End With
	End Sub
	
	Private Sub SRIGENARCHIVOSCOA_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim i As Object
		'cambiar on error Resume Next
		'Titulo (Me)
		With Anios
			For i = 0 To 20
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto i. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Items.Insert(i, Str(i + 2002))
			Next 
			.SelectedIndex = PerAnio - 2002
		End With
		
		With Meses
			For i = 0 To 11
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto i. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.Items.Insert(i, VB6.Format("01/" & i + 1 & "/0001", "Mmmm"))
			Next 
			.SelectedIndex = PerMes - 1
		End With
		If Reocc Then
			Text3.Text = GetSetting("adcomw", "genreoc", "Direc", "\tmp\" & "REOC" & PerPeriodo & ".xml")
			Me.Text = "Generación de archivo de ANEXO REOC"
		Else
			Text3.Text = GetSetting("adcomw", "genats", "Direc", "\tmp\" & "ATS" & PerPeriodo & ".xml")
			Me.Text = "Generación de archivo de ANEXO TRANSACCIONAL"
		End If
	End Sub
	
	Private Sub btnsalir_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnsalir.Click
		Me.Close()
	End Sub
	
	Public Function DarFormato(ByRef dato As Object, ByRef Longitud As Object, ByRef Tipo As Object, ByRef ALinea As Object, ByRef Valor As String) As Object
		Dim i As Object
		Dim fecha As String
		'dato = Dato al que se dara formato
		'Longitud = Longitud ala que quedará el dato  (5)
		'tipo = Tipo de dato  (S = String , F = Fecha, N = Numero)
		'Alinea =  Tipo de alineacion (I = Izquierda, D = Derecha)
		'Valor  = Valor Con el que se completara al dato para alcanzar la longitud deseada(" ", 0)
		'cambiar on error Resume Next
		'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(dato) Then
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Tipo. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If Tipo = "N" Then
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dato. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				dato = 0
			Else
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dato. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				dato = ""
			End If
		End If
		
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Tipo. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Tipo = "F" Then
			fecha = ""
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Longitud. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			For i = 1 To Longitud + 2
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto i. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dato. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto i. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dato. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Mid(dato, i, 1) <> "/" Then fecha = fecha & Mid(dato, i, 1)
			Next i
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dato. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dato = fecha
		End If
		
		
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Tipo. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dato. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Tipo = "N" Then dato = VB6.Format(System.Math.Round(CDbl(dato), 2), "#########0.00")
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Longitud. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Len(dato) < Longitud Then
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Longitud. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			For i = 1 To Longitud - Len(dato)
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ALinea. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If ALinea = "I" Then
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dato. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					dato = dato & Valor
				Else
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dato. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					dato = Valor & dato
				End If
			Next i
		End If
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dato. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto DarFormato. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DarFormato = dato
	End Function
	
	Public Sub CrearArchivos()
		Dim ext As String
		'cambiar on error GoTo errorcreando
		ConError = False
		ext = ""
		If UCase(VB.Right(Text3.Text, 4)) <> ".XML" Then ext = ".XML"
		FileOpen(1, Text3.Text & ext, OpenMode.Output)
		Exit Sub
errorcreando: 
		ConError = True
	End Sub
	
	Private Sub SRIGENARCHIVOSCOA_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		If Reocc Then
			SaveSetting("adcomw", "genreoc", "Direc", Text3.Text)
		Else
			SaveSetting("adcomw", "genats", "Direc", Text3.Text)
		End If
	End Sub
End Class