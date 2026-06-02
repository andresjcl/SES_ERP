Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class SRICOMPRAS
	Inherits System.Windows.Forms.Form
	Dim RsSRI As New ADODB.Recordset
	Dim RsTemp As New ADODB.Recordset
	Dim Control As Short
	Dim Sw, SwSn As Boolean
	Dim esnuevo As Boolean
	Dim salir As Short
	Dim mes, Anio, identificacion As String
	Dim num_Secue As Integer
	Dim Iden, txtCod As String
	Const FORMATONUM As String = "###,###,##0.00"
	Dim SeqTran(25) As String
	Dim Documentos As String
	Dim NSeqTran As Short
	Dim opAlex As ManDirct.Directorio
	Dim SeqTransacc As Short
	Dim Fechac As Date
	Dim txtClv As Double
	Public ClaveDoc As String
	
	Private Sub BtCaduca_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BtCaduca.Click
		FechaCaduca.Text = CStr(QueFecha)
	End Sub
	
	Private Sub BtContable_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BtContable.Click
		txtFecRegCont.Text = CStr(QueFecha)
	End Sub
	
	Private Sub BtEmision_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BtEmision.Click
		txtFecEmiCom.Text = CStr(QueFecha)
	End Sub
	
	Private Sub btncancelar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btncancelar.Click
		If ConfirmaCancelar Then btnnuevo_Click(btnnuevo, New System.EventArgs())
	End Sub
	
	Private Sub BtnFechEmitRete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BtnFechEmitRete.Click
		TxtFechaEmicionIR.Text = CStr(QueFecha)
	End Sub
	
	Private Sub BtRemision_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BtRemision.Click
		TxtFechaModifica.Text = CStr(QueFecha)
	End Sub
	
	Private Sub CodRetFteImpRent_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CodRetFteImpRent.Change
		Dim Index As Short = CodRetFteImpRent.GetIndex(eventSender)
		Dim claves As String
		claves = CodRetFteImpRent(Index).BoundText
		If claves = "" Then Exit Sub
		TxtPorcRetIR(Index).ReadOnly = False
		If claves = "401" Then
			TxtPorcRetIR(Index).Text = ""
		Else
			With DtPorRetIR
				.Recordset.MoveFirst()
				.Recordset.Find("codigo=" & claves)
				TxtPorcRetIR(Index).Text = .Recordset.Fields("porretencion").Value
				TxtPorcRetIR(Index).ReadOnly = True
			End With
		End If
	End Sub
	
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		Me.Close()
	End Sub
	
	Private Sub CargarCombos()
		If IsDate(txtFecEmiCom.Text) And IsDate(txtFecRegCont.Text) Then
			CargarTipoDocumento()
			CargarPorcentajeIva()
			CargarPorcentajeICE()
			CargarPorRetencioIvaBienes()
			CargarPorRetencioIvaServicios()
			CargarPorRetencionFuente()
		End If
		
	End Sub
	
	Private Sub DatSustento_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DatSustento.Change
		CargarCombos()
	End Sub
	
	Private Sub DcPorICE_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DcPorICE.Change
		Dim claves As String
		claves = DcPorICE.BoundText
		If claves = "" Then Exit Sub
		With DtPorICE
			.Recordset.MoveFirst()
			.Recordset.Find("codigo=" & claves)
			TxtPorcIce.Text = .Recordset.Fields("Porcentaje_Ice").Value
		End With
	End Sub
	
	Private Sub dcPorIva_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dcPorIva.Change
		CalcularMontoIva()
	End Sub
	
	Private Sub dcPorIvaBie_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dcPorIvaBie.Change
		CalcularMontoRetBienes()
	End Sub
	Private Sub CalcularMontoRetBienes()
		TxtMonRetBie.Text = VB6.Format(Val(txtMonIvaBie.Text) * Val(dcPorIvaBie.defText) / 100, FORMATONUM)
	End Sub
	Private Sub DcPorIvaServ_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DcPorIvaServ.Change
		CalcularMontoRetServicios()
	End Sub
	Private Sub CalcularMontoRetServicios()
		TxtMonRetSer.Text = VB6.Format(Val(TxtMonIvaSer.Text) * Val(DcPorIvaServ.defText) / 100, FORMATONUM)
	End Sub
	
	Private Sub FechaCaduca_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles FechaCaduca.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = IngresaSoloFechas(KeyAscii, FechaCaduca)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtAutCom_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtAutCom.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = IngresaSoloNumero(KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub TxtAutorizaMod_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TxtAutorizaMod.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = IngresaSoloNumero(KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'UPGRADE_WARNING: El evento txtBasImpGra.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtBasImpGra_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtBasImpGra.TextChanged
		CalcularMontoIva()
	End Sub
	
	Private Sub txtBasImpGra_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtBasImpGra.Enter
		PonerSel(txtBasImpGra)
	End Sub
	
	Private Sub txtBasImpGra_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtBasImpGra.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = IngresaSoloValores(KeyAscii, txtBasImpGra.Text)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'UPGRADE_WARNING: El evento TxtBasImpICE.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub TxtBasImpICE_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TxtBasImpICE.TextChanged
		CalcularMontoIce()
	End Sub
	
	Private Sub CalcularMontoIce()
		TxtMonIce.Text = VB6.Format(Val(TxtBasImpICE.Text) * Val(TxtPorcIce.Text) / 100, FORMATONUM)
	End Sub
	Private Sub CalcularMontoIva()
		TxtMonIva.Text = VB6.Format(Val(txtBasImpGra.Text) * Val(dcPorIva.defText) / 100, FORMATONUM)
	End Sub
	
	Private Sub FechaCaduca_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles FechaCaduca.KeyDown
		Dim keycode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If keycode = System.Windows.Forms.Keys.F3 Then
			FechaCaduca.Text = CStr(Today)
		ElseIf keycode = System.Windows.Forms.Keys.F2 Then 
			FechaCaduca.Text = CStr(QueFecha)
		End If
	End Sub
	
	Private Sub limpia()
		'cambiar on error Resume Next
		Dim Control As System.Windows.Forms.Control
		Dim a As String
		For	Each Control In Me.Controls
			'UPGRADE_WARNING: TypeName tiene un nuevo comportamiento. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			a = TypeName(Control)
			If a = "Label" Then
				'UPGRADE_ISSUE: Control propiedad Control.BorderStyle no se actualizó. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Control.Alignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Control.BorderStyle = 1 Then
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Control. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Control.Alignment = 1 Then
						Control = "0.00"
					Else
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Control. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						Control = ""
					End If
				End If
			ElseIf a = "DataCombo" And Control.Name <> "DatSustento" Then 
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Control.BoundText. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Control.BoundText = ""
			ElseIf a = "TextBox" Then 
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Control.Alignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Control. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Control.Alignment = 1 Then
					Control = "0.00"
				Else
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Control. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					Control = ""
				End If
			End If
		Next Control
		Sw = False
		TxtPorcRetIR(0).ReadOnly = False
		TxtPorcRetIR(1).ReadOnly = False
		txtPro.ReadOnly = False
		txtNumSer.ReadOnly = False
		TxtSerEstablec.ReadOnly = False
		txtNumSec.ReadOnly = False
		txtFecEmiCom.Text = ("01/" & PerMes & "/" & PerAnio)
		txtFecRegCont.Text = txtFecEmiCom.Text
		TxtFechaEmicionIR.Text = txtFecRegCont.Text
	End Sub
	
	Private Sub btPro_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btPro.Click
		buscarclientes()
	End Sub
	
	Private Sub buscarclientes()
		''cambiar on error Resume Next
		Dim buscaclien As New ManDirct.BuscaClien
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto buscaclien.IniBuscaCliOPro. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		txtCod = buscaclien.IniBuscaCliOPro("P", txtCod)
		'UPGRADE_NOTE: El objeto buscaclien no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		buscaclien = Nothing
		buscacli()
	End Sub
	
	Private Sub buscacli()
		opAlex = New ManDirct.Directorio
		''cambiar on error Resume Next
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto opAlex.CargarAlex. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If opAlex.CargarAlex(txtCod, False, "S") = False Then
			txtCod = ""
			txtPro.Text = ""
			Iden = ""
			lbNomP.Text = ""
			MsgBox("No existe el proveedor registrado")
			txtPro.Focus()
		Else
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto opAlex.codigo. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtCod = opAlex.codigo
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto opAlex.NombreImpresion. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lbNomP.Text = opAlex.NombreImpresion
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto opAlex.CiRuc. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtPro.Text = opAlex.CiRuc
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto opAlex.TipoId. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Iden = CorrijeTipoId(opAlex.TipoId)
			txtFecRegCont.Focus()
		End If
	End Sub
	
	Private Sub SRICOMPRAS_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		''cambiar on error Resume Next
		Dim cod As String
		centrarforma(Me)
		Me.Text = "COMPRAS LOCALES"
		titulo(Me)
		CargarSustento()
		If ClaveDoc > "" Then
			CargarDeLinea()
		Else
			btnnuevo_Click(btnnuevo, New System.EventArgs())
		End If
	End Sub
	
	Private Sub CargarSustento()
		
		With dtCodSus
			.CommandType = ADODB.CommandTypeEnum.adCmdText
			.ConnectionString = StrConxsysemp
			.RecordSource = "Select * From  SriSustentoComprobante order by codigo"
			.Refresh()
			.Recordset.MoveFirst()
		End With
		
		With DatSustento
			.ListField = "TipoSustento"
			.BoundText = dtCodSus.Recordset.Fields("codigo").Value
			'UPGRADE_NOTE: Refresh se actualizó a CtlRefresh. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
			.CtlRefresh()
		End With
		
	End Sub
	
	'Private Sub CargarTransacciones()
	'Dim claves As String
	'Dim rs As New ADODB.Recordset, i As Integer
	'For i = 0 To 25
	'SeqTran(i) = ""
	'Next i
	'rs.Open "Select * from SriSecuencialesTransacciones where CodigoTipoTransaccion = 1", ConxSyscod, adOpenKeyset, adLockOptimistic
	'If rs.EOF Then Exit Sub
	'NSeqTran = 0
	'rs.MoveFirst
	'Do Until rs.EOF = True
	'    NSeqTran = NSeqTran + 1
	'    SeqTran(NSeqTran) = Format(rs!Codigo, "00")
	'    rs.MoveNext
	'Loop
	'End Sub
	
	Private Sub CargarTipoDocumento()
		Dim SrRec As New ADODB.Recordset
		'   Dim sConnect As String
		Dim sSQL As String
		Dim codi As Short
		Dim HastaFec As Date
		Dim TxSustento, TxSeqTra As String
		If Not IsDate(txtFecRegCont.Text) Then Exit Sub
		
		TxSustento = ""
		TxSeqTra = ""
		
		SrRec = New ADODB.Recordset
		If Iden > "" Then
			sSQL = "Select * From SriSecuencialesTransacciones where CodigoTipoTransaccion = 1 and CodigoIdentificacion = '" & Iden & "'"
			SrRec.Open(sSQL, ConxSyscod, ADOR.CursorTypeEnum.adOpenForwardOnly, ADOR.LockTypeEnum.adLockOptimistic)
			If SrRec.State = 0 Then
				Sw = False
			ElseIf SrRec.EOF Then 
				Sw = False
			Else
				SeqTransacc = SrRec.Fields("codigo").Value
			End If
			If SrRec.State = 1 Then SrRec.Close()
			TxSeqTra = " and (CodigoSecuencialTransaccion LIKE '%" & VB.Right("00" & SeqTransacc, 2) & "%')"
		End If
		
		TxSustento = "(SustentoTributario LIKE '%" & VB.Right("00" & DatSustento.BoundText, 2) & "%') "
		sSQL = "Select * From sritipodecomprobante Where " & TxSustento & TxSeqTra & " and FechaVigencia > " & ArmFormatoFecha(txtFecRegCont.Text) & " order by codigo "
		With dtCom
			.CommandType = ADODB.CommandTypeEnum.adCmdText
			.ConnectionString = StrConxsysemp
			.RecordSource = sSQL
			.Refresh()
		End With
		With TipoComprobante
			If dtCom.Recordset.RecordCount > 0 Then
				dtCom.Recordset.MoveFirst()
				.BoundText = dtCom.Recordset.Fields("codigo").Value
				'   .Text = dtCom.Recordset!TipoComprobante
			End If
		End With
	End Sub
	
	Private Sub CargarDocumentoModifica()
		Dim claves As String
		claves = DatSustento.BoundText
		dtCodSus.Recordset.MoveFirst()
		dtCodSus.Recordset.Find("codigo=" & claves)
		claves = SepararClaves(dtCodSus.Recordset.Fields("CodigoTipoComprobante").Value, "codigo")
		With DtComMod
			.CommandType = ADODB.CommandTypeEnum.adCmdText
			.ConnectionString = StrConxsysemp
			.RecordSource = "Select *  From sritipodecomprobante Where ( " & claves & ") and codigo <> 4 and codigo <> 5 order by codigo "
			.Refresh()
		End With
		With DcCodModificado
			If DtComMod.Recordset.RecordCount > 0 Then
				DtComMod.Recordset.MoveFirst()
				.BoundText = DtComMod.Recordset.Fields("codigo").Value
				'   .Text = dtCom.Recordset!TipoComprobante
			End If
		End With
	End Sub
	Private Sub CargarPorcentajeIva()
		With dtPorIva
			.CommandType = ADODB.CommandTypeEnum.adCmdText
			.ConnectionString = StrConxsysemp
			.RecordSource = "select * from SriPorcentajesDelIva where fechainicio <= " & ArmFormatoFecha(txtFecEmiCom.Text) & " AND fechafin >= " & ArmFormatoFecha(txtFecEmiCom.Text) & " ORDER BY CODIGO DESC"
			.Refresh()
			If .Recordset.RecordCount > 0 Then
				.Recordset.MoveFirst()
				dcPorIva.BoundText = .Recordset.Fields("codigo").Value
				'dcPorIva.Text = dtPorIva.Recordset!porcentajeiva
			End If
		End With
	End Sub
	Private Sub CargarPorcentajeICE()
		Dim claves As String
		With DtPorICE
			.CommandType = ADODB.CommandTypeEnum.adCmdText
			.ConnectionString = StrConxsysemp
			.RecordSource = "select * from SriPorcentajesDelIce where fechainicio <= " & ArmFormatoFecha(txtFecEmiCom.Text) & " AND fechafin >= " & ArmFormatoFecha(txtFecEmiCom.Text) & " ORDER BY CODIGO DESC"
			.Refresh()
			
			If .Recordset.RecordCount > 0 Then
				.Recordset.MoveFirst()
				'    DTPORICE .Recordset.Find "codigo=" & claves
				DcPorICE.BoundText = .Recordset.Fields("codigo").Value
				TxtPorcIce.Text = .Recordset.Fields("Porcentaje_Ice").Value
				'dcPorIva.Text = dtPorIva.Recordset!porcentajeiva
			End If
		End With
	End Sub
	Private Sub CargarPorRetencioIvaBienes()
		With dtPorIvaBie
			.CommandType = ADODB.CommandTypeEnum.adCmdText
			.ConnectionString = StrConxsysemp
			.RecordSource = " Select * From  SriPorcentajesRetencionIvaBienes order by valor1 "
			.Refresh()
			If .Recordset.RecordCount > 0 Then
				.Recordset.MoveFirst()
				dcPorIvaBie.BoundText = .Recordset.Fields("codigo").Value
			End If
		End With
		
	End Sub
	Private Sub CargarPorRetencioIvaServicios()
		With DtPorIvaServ
			.CommandType = ADODB.CommandTypeEnum.adCmdText
			.ConnectionString = StrConxsysemp
			.RecordSource = " Select * From  SriPorcentajesRetencionIvaservicios order by valor1 "
			.Refresh()
			
			If .Recordset.RecordCount > 0 Then
				.Recordset.MoveFirst()
				'     If .Recordset.RecordCount > 1 Then .Recordset.MoveNext
				DcPorIvaServ.BoundText = .Recordset.Fields("codigo").Value
				'dcPorIva.Text = dtPorIva.Recordset!porcentajeiva
			End If
		End With
	End Sub
	Private Sub CargarPorRetencionFuente()
		With DtPorRetIR
			.CommandType = ADODB.CommandTypeEnum.adCmdText
			.ConnectionString = StrConxsysemp
			.RecordSource = " Select * From SriConceptosRetencion where fechainicio <= " & ArmFormatoFecha(txtFecEmiCom.Text) & " AND fechafin >= " & ArmFormatoFecha(txtFecEmiCom.Text) & " ORDER BY CODIGO "
			.Refresh()
			
			If .Recordset.RecordCount > 0 Then
				.Recordset.MoveFirst()
				CodRetFteImpRent(0).BoundText = .Recordset.Fields("codigo").Value
			End If
			
		End With
		
	End Sub
	
	Private Sub btnmodificar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnmodificar.Click
		''cambiar on error GoTo HayErrores
		
		fprincipal.Enabled = True
		Frame2.Enabled = True
		
		txtPro.ReadOnly = True
		txtNumSer.ReadOnly = True
		TxtSerEstablec.ReadOnly = True
		txtNumSec.ReadOnly = True
		f3.Visible = False
		F2.Visible = True
		Exit Sub
HayErrores: 
		ControlaErrores()
	End Sub
	'
	Private Sub btnnuevo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnnuevo.Click
		''cambiar on error Resume Next
		limpia()
		Frame2.Enabled = True
		fprincipal.Enabled = True
		esnuevo = True
		F2.Visible = True
		f3.Visible = False
		SSTab1.SelectedIndex = 0
		CargarTipoDocumento()
	End Sub
	
	Private Sub btnsalir_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnsalir.Click
		Me.Close()
	End Sub
	
	Private Sub SRICOMPRAS_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		'UPGRADE_ISSUE: No se actualizó el parámetro Event Cancel. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"'
		If ConfirmaSalir = False Then Cancel = 1
		If RsSRI.State = 1 Then RsSRI.Close()
	End Sub
	
	Private Sub btngrabar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btngrabar.Click
		Dim sSQL As String
		'If ValidarRegistroCompra = False Then
		'    MsgBox "El registro está errado, No se puede grabar", vbCritical
		'    Exit Sub
		' else validarcompras
		'End If
		'''cambiar on error GoTo HayErrores
		'If Not esnuevo Then EliminaParaRegrabar
		sSQL = "select * From  COMPRAS WHere  clave = " & txtClv
		RsSRI = New ADODB.Recordset
		With RsSRI
			.Open(sSQL, ConxSri, ADOR.CursorTypeEnum.adOpenKeyset, ADOR.LockTypeEnum.adLockOptimistic)
			If .EOF Then .AddNew()
			.Fields("CL_CodigoProveedor").Value = txtPro.Text
			.Fields("CL_TipoIdProveedor").Value = Iden
			.Fields("CL_NroSerieEstablec").Value = txtNumSer.Text
			.Fields("CL_NroSeriePtoEmision").Value = TxtSerEstablec.Text
			.Fields("CL_NroSecuencial").Value = txtNumSec.Text
			.Fields("CL_SusTributario").Value = DatSustento.BoundText
			.Fields("CL_TransDevIva").Value = IIf(DerochoIva.CheckState, "S", "N")
			.Fields("Cl_TipoComprobante").Value = TipoComprobante.BoundText
			.Fields("CL_FechaRegContable").Value = txtFecRegCont.Text
			.Fields("CL_FechaComprobante").Value = txtFecEmiCom.Text
			.Fields("CL_NroAutorizacion").Value = txtAutCom.Text
			.Fields("CL_FechaCaducidad").Value = FechaCaduca.Text
			.Fields("CL_BaseImpTarCero").Value = CorrijeNuloN(txtBasImpTar0)
			.Fields("CL_BaseImpGravadaIva").Value = txtBasImpGra.Text
			.Fields("CL_CodigoPorcIva").Value = CorrijeNuloN((dcPorIva.BoundText))
			.Fields("CL_MontoIva").Value = TxtMonIva.Text
			.Fields("CL_BaseImpICE").Value = CorrijeNuloN(TxtBasImpICE)
			.Fields("CL_CodigoPorcICE").Value = DcPorICE.BoundText
			.Fields("CL_MontoICE").Value = TxtMonIce.Text
			.Fields("CL_MontoIvaBienes").Value = txtMonIvaBie.Text
			.Fields("CL_CodPorcRetIvaBienes").Value = dcPorIvaBie.BoundText
			.Fields("CL_MontoRetIvaBienes").Value = TxtMonRetBie.Text
			.Fields("CL_MontoIvaServ").Value = TxtMonIvaSer.Text
			.Fields("CL_CodPorRetIvaServicios").Value = DcPorIvaServ.BoundText
			.Fields("CL_MontoRetIvaServicios").Value = TxtMonRetSer.Text
			.Fields("CL_CodRetFteImpRenta0").Value = CodRetFteImpRent(0).BoundText
			.Fields("CL_BaseImponibleIR0").Value = TxtBasImpIR(0).Text
			.Fields("CL_CodPorcRetIR0").Value = TxtPorcRetIR(0).Text
			.Fields("CL_MontoRetIR0").Value = TxtMonRetRen(0).Text
			.Fields("CL_CodRetFteImpRenta1").Value = CodRetFteImpRent(1).BoundText
			.Fields("CL_BaseImponibleIR1").Value = TxtBasImpIR(1).Text
			.Fields("CL_CodPorcRetIR1").Value = TxtPorcRetIR(1).Text
			.Fields("CL_MontoRetIR1").Value = TxtMonRetRen(1).Text
			.Fields("CL_NroSerieCpbteRetEmision").Value = TxtSerieEmision.Text
			.Fields("CL_NroSerieCpbteRetEstable").Value = TxtSerieEstblIR.Text
			.Fields("CL_NroSecuencialCpbteRet").Value = TxtSecuencialIR.Text
			.Fields("CL_NroAutorizaCpbteRete").Value = TxtNroAutorizaIR.Text
			.Fields("CL_FechaEmisionCpbteRete").Value = CorrijeNuloF(TxtFechaEmicionIR)
			.Fields("CL_CodigoTipoModificado").Value = DcCodModificado.BoundText
			.Fields("CL_FechaEmisionModificado").Value = CorrijeNuloF(TxtFechaModifica)
			.Fields("CL_NroSerieModificadoEstab").Value = TxtserieEstableceMod.Text
			.Fields("CL_NroSerieModificadoEmision").Value = TxtSerieEmicionMod.Text
			.Fields("CL_NroSecuencialModificado").Value = TxtNumeroSecuencialMod.Text
			.Fields("CL_NroAutorizaModificado").Value = TxtAutorizaMod.Text
			.Fields("CL_NroContrato").Value = TxtNroContrato.Text
			.Fields("CL_MontoOneroso").Value = TxtMontoOneroso.Text
			.Fields("CL_MontoGratutito").Value = TxtMontoGratuito.Text
			.Update()
			.Close()
		End With
		btnnuevo_Click(btnnuevo, New System.EventArgs())
		Exit Sub
HayErrores: 
		ControlaErrores("Grabando Compras")
	End Sub
	Private Sub CargarDeLinea()
		muestra()
	End Sub
	Private Sub muestra()
		Dim sSQL As String
		'If txtCod = "" Or Val(txtNumSer) = 0 Or Val(TxtSerEstablec) = 0 Or Val(txtNumSec) = 0 Then
		'    MsgBox ""
		'cambiar on error Resume Next
		Sw = True
		If CDbl(ClaveDoc) > 0 Then
			sSQL = "select * From  COMPRAS WHere  clave = " & ClaveDoc
		Else
			sSQL = "select * From  COMPRAS WHere  CL_CodigoProveedor = '" & txtPro.Text & "' and CL_NroSerieEstablec = '" & txtNumSer.Text & "' and CL_NroSeriePtoEmision = '" & TxtSerEstablec.Text & "' and CL_NroSecuencial = '" & txtNumSec.Text & "' "
		End If
		RsSRI = New ADODB.Recordset
		RsSRI.Open(sSQL, ConxSri, ADOR.CursorTypeEnum.adOpenKeyset, ADOR.LockTypeEnum.adLockOptimistic)
		If RsSRI.EOF Then esnuevo = True : Exit Sub
		If RsSRI.State = 0 Then esnuevo = True : Exit Sub
		With RsSRI
			txtClv = .Fields("Clave").Value
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtPro.Text = CorrijeNulo(.Fields("CL_CodigoProveedor"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Iden = CorrijeNulo(.Fields("CL_TipoIdProveedor"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtNumSer.Text = CorrijeNulo(.Fields("CL_NroSerieEstablec"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtSerEstablec.Text = CorrijeNulo(.Fields("CL_NroSeriePtoEmision"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtNumSec.Text = CorrijeNulo(.Fields("CL_NroSecuencial"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DatSustento.BoundText = CorrijeNulo(.Fields("CL_SusTributario"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DerochoIva.CheckState = IIf(CorrijeNulo(.Fields("CL_TransDevIva")) = "S", True, False)
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TipoComprobante.BoundText = CorrijeNulo(.Fields("Cl_TipoComprobante"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtFecRegCont.Text = CorrijeNulo(.Fields("CL_FechaRegContable"))
			txtFecEmiCom.Text = CStr(CorrijeNuloF(.Fields("CL_FechaComprobante")))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtAutCom.Text = CorrijeNulo(.Fields("CL_NroAutorizacion"))
			FechaCaduca.Text = CStr(CorrijeNuloF(.Fields("CL_FechaCaducidad")))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtBasImpTar0.Text = CorrijeNulo(.Fields("CL_BaseImpTarCero"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtBasImpGra.Text = CorrijeNulo(.Fields("CL_BaseImpGravadaIva"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dcPorIva.BoundText = CorrijeNulo(.Fields("CL_CodigoPorcIva"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtMonIva.Text = CorrijeNulo(.Fields("CL_MontoIva"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtBasImpICE.Text = CorrijeNulo(.Fields("CL_BaseImpICE"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Me.DcPorICE.BoundText = CorrijeNulo(.Fields("CL_CodigoPorcICE"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtMonIce.Text = CorrijeNulo(.Fields("CL_MontoICE"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtMonIvaBie.Text = CorrijeNulo(.Fields("CL_MontoIvaBienes"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dcPorIvaBie.BoundText = CorrijeNulo(.Fields("CL_CodPorcRetIvaBienes"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtMonRetBie.Text = CorrijeNulo(.Fields("CL_MontoRetIvaBienes"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtMonIvaSer.Text = CorrijeNulo(.Fields("CL_MontoIvaServ"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DcPorIvaServ.BoundText = CorrijeNulo(.Fields("CL_CodPorRetIvaServicios"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtMonRetSer.Text = CorrijeNulo(.Fields("CL_MontoRetIvaServicios"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CodRetFteImpRent(0).BoundText = CorrijeNulo(.Fields("CL_CodRetFteImpRenta0"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(RsSRI!CL_BaseImponibleIR0). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtBasImpIR(0).Text = CorrijeNulo(.Fields("CL_BaseImponibleIR0"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(RsSRI!CL_CodPorcRetIR0). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtPorcRetIR(0).Text = CorrijeNulo(.Fields("CL_CodPorcRetIR0"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(RsSRI!CL_MontoRetIR0). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtMonRetRen(0).Text = CorrijeNulo(.Fields("CL_MontoRetIR0"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CodRetFteImpRent(1).BoundText = CorrijeNulo(.Fields("CL_CodRetFteImpRenta1"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(RsSRI!CL_BaseImponibleIR1). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtBasImpIR(1).Text = CorrijeNulo(.Fields("CL_BaseImponibleIR1"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(RsSRI!CL_CodPorcRetIR1). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtPorcRetIR(1).Text = CorrijeNulo(.Fields("CL_CodPorcRetIR1"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(RsSRI!CL_MontoRetIR1). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtMonRetRen(1).Text = CorrijeNulo(.Fields("CL_MontoRetIR1"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtSerieEmision.Text = CorrijeNulo(.Fields("CL_NroSerieCpbteRetEmision"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtSerieEstblIR.Text = CorrijeNulo(.Fields("CL_NroSerieCpbteRetEstable"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtSecuencialIR.Text = CorrijeNulo(.Fields("CL_NroSecuencialCpbteRet"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtNroAutorizaIR.Text = CorrijeNulo(.Fields("CL_NroAutorizaCpbteRete"))
			TxtFechaEmicionIR.Text = CStr(CorrijeNuloF(.Fields("CL_FechaEmisionCpbteRete")))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DcCodModificado.BoundText = CorrijeNulo(.Fields("CL_CodigoTipoModificado"))
			TxtFechaModifica.Text = CStr(CorrijeNuloF(.Fields("CL_FechaEmisionModificado")))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtserieEstableceMod.Text = CorrijeNulo(.Fields("CL_NroSerieModificadoEstab"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtSerieEmicionMod.Text = CorrijeNulo(.Fields("CL_NroSerieModificadoEmision"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtNumeroSecuencialMod.Text = CorrijeNulo(.Fields("CL_NroSecuencialModificado"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtAutorizaMod.Text = CorrijeNulo(.Fields("CL_NroAutorizaModificado"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtNroContrato.Text = CorrijeNulo(.Fields("CL_NroContrato"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtMontoOneroso.Text = CorrijeNulo(.Fields("CL_MontoOneroso"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtMontoGratuito.Text = CorrijeNulo(.Fields("CL_MontoGratutito"))
			fprincipal.Enabled = False
			Frame2.Enabled = False
			F2.Visible = False
			f3.Visible = True
			esnuevo = False
		End With
	End Sub
	
	Private Sub btneliminar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btneliminar.Click
		Dim sieli As Byte
		Dim sSQL As String
		''cambiar on error Resume Next
		sieli = ConfirmaAnular
		If sieli = MsgBoxResult.Yes Then
			sSQL = "DELETE * From  COMPRAS WHere  clave = " & txtClv
			ConxSri.Execute(sSQL)
			btnnuevo_Click(btnnuevo, New System.EventArgs())
		End If
	End Sub
	Private Sub EliminaParaRegrabar()
		Dim sieli As Byte
		Dim sSQL As String
		''cambiar on error Resume Next
		If RsSRI.State = 1 Then RsSRI.Close()
		sSQL = "DELETE * From  COMPRAS WHere  CL_CodigoProveedor = '" & txtPro.Text & "' and CL_NroSerieEstablec = '" & txtNumSer.Text & "' and CL_NroSeriePtoEmision = '" & TxtSerEstablec.Text & "' and CL_NroSecuencial = '" & txtNumSec.Text & "' "
		ConxSri.Execute(sSQL)
	End Sub
	
	Private Sub TipoComprobante_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As AxMSDataListLib.DDataComboEvents_ClickEvent) Handles TipoComprobante.ClickEvent
		If TipoComprobante.BoundText = "4" Or TipoComprobante.BoundText = "5" Then
			FrModifica.Enabled = True
			CargarDocumentoModifica()
		Else
			FrModifica.Enabled = False
			DcCodModificado.BoundText = ""
			TxtFechaModifica.Text = ""
			TxtserieEstableceMod.Text = ""
			TxtSerieEmicionMod.Text = ""
			TxtNumeroSecuencialMod.Text = ""
			TxtAutorizaMod.Text = ""
		End If
		
	End Sub
	
	Private Sub txtAutCom_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtAutCom.KeyDown
		Dim keycode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		'If KeyCode = vbKeyF2 Then BuscarAutorización
	End Sub
	
	Private Sub TxtBasImpICE_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TxtBasImpICE.Enter
		PonerSel(TxtBasImpICE)
	End Sub
	
	Private Sub TxtBasImpICE_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TxtBasImpICE.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = IngresaSoloValores(KeyAscii, TxtBasImpICE.Text)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'UPGRADE_WARNING: El evento TxtBasImpIR.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub TxtBasImpIR_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TxtBasImpIR.TextChanged
		Dim Index As Short = TxtBasImpIR.GetIndex(eventSender)
		CalcularMontoRenta()
	End Sub
	
	Private Sub TxtBasImpIR_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TxtBasImpIR.Enter
		Dim Index As Short = TxtBasImpIR.GetIndex(eventSender)
		PonerSel(TxtBasImpIR(Index))
	End Sub
	
	Private Sub TxtBasImpIR_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TxtBasImpIR.KeyDown
		Dim keycode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = TxtBasImpIR.GetIndex(eventSender)
		If keycode = System.Windows.Forms.Keys.F2 Then
			If Index = 0 Then
				TxtBasImpIR(Index).Text = txtBasImpGra.Text
			ElseIf Index = 1 And Val(TxtBasImpIR(0).Text) > 0 Then 
				TxtBasImpIR(Index).Text = CStr(CDbl(txtBasImpGra.Text) - Val(TxtBasImpIR(0).Text))
			End If
		End If
	End Sub
	
	Private Sub TxtBasImpIR_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TxtBasImpIR.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = TxtBasImpIR.GetIndex(eventSender)
		KeyAscii = IngresaSoloValores(KeyAscii, TxtBasImpIR(Index).Text)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtBasImpTar0_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtBasImpTar0.Enter
		PonerSel(txtBasImpTar0)
	End Sub
	
	Private Sub txtBasImpTar0_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtBasImpTar0.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = IngresaSoloValores(KeyAscii, txtBasImpTar0.Text)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'UPGRADE_WARNING: El evento txtFecEmiCom.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtFecEmiCom_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFecEmiCom.TextChanged
		If IsDate(txtFecEmiCom.Text) Then CargarCombos()
	End Sub
	
	Private Sub txtFecEmiCom_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFecEmiCom.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = IngresaSoloFechas(KeyAscii, txtFecEmiCom)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub TxtFechaEmicionIR_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TxtFechaEmicionIR.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = IngresaSoloFechas(KeyAscii, TxtFechaEmicionIR)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub TxtFechaModifica_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TxtFechaModifica.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = IngresaSoloFechas(KeyAscii, TxtFechaModifica)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'UPGRADE_WARNING: El evento txtFecRegCont.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtFecRegCont_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFecRegCont.TextChanged
		If IsDate(txtFecRegCont.Text) Then CargarCombos()
	End Sub
	
	Private Sub txtFecRegCont_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtFecRegCont.KeyDown
		Dim keycode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If keycode = System.Windows.Forms.Keys.F3 Then
			txtFecRegCont.Text = txtFecEmiCom.Text
		End If
	End Sub
	
	Private Sub txtFecRegCont_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFecRegCont.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = IngresaSoloFechas(KeyAscii, txtFecRegCont)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'UPGRADE_WARNING: El evento txtMonIvaBie.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtMonIvaBie_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMonIvaBie.TextChanged
		TxtMonIvaSer.Text = CStr(Val(TxtMonIva.Text) - Val(txtMonIvaBie.Text))
		If Val(TxtMonIvaSer.Text) < 0 Then txtMonIvaBie.Text = CStr(0)
		CalcularMontoRetBienes()
	End Sub
	
	Private Sub txtMonIvaBie_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMonIvaBie.Enter
		PonerSel(txtMonIvaBie)
	End Sub
	
	Private Sub txtMonIvaBie_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtMonIvaBie.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = IngresaSoloValores(KeyAscii, txtMonIvaBie.Text)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'UPGRADE_ISSUE: El evento Label TxtMonIvaSer.Change no se actualizó. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="ABD9AF39-7E24-4AFF-AD8D-3675C1AA3054"'
	Private Sub TxtMonIvaSer_Change()
		CalcularMontoRetServicios()
	End Sub
	
	
	Private Sub TxtMontoGratuito_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TxtMontoGratuito.Enter
		PonerSel(TxtMontoGratuito)
	End Sub
	
	Private Sub TxtMontoOneroso_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TxtMontoOneroso.Enter
		PonerSel(TxtMontoOneroso)
	End Sub
	
	Private Sub TxtNroAutorizaIR_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TxtNroAutorizaIR.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = IngresaSoloNumero(KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub TxtNumeroSecuencialMod_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TxtNumeroSecuencialMod.KeyDown
		Dim keycode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		'UPGRADE_ISSUE: No se actualizó la constante vbEnter. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"'
		If keycode = vbEnter Then
			TxtAutorizaMod.Focus()
		End If
	End Sub
	
	Private Sub TxtNumeroSecuencialMod_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TxtNumeroSecuencialMod.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = IngresaSoloNumero(KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtNumSec_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtNumSec.KeyDown
		Dim keycode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If keycode = System.Windows.Forms.Keys.Return Then
			muestra()
			If esnuevo Then
				txtNumSec_Leave(txtNumSec, New System.EventArgs())
				'        txtAutCom.SetFocus
			End If
		End If
	End Sub
	
	Private Sub txtNumSec_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtNumSec.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = IngresaSoloNumero(KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtNumSec_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtNumSec.Leave
		'UPGRADE_NOTE: Auto se actualizó a Auto_Renamed. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		Dim Auto_Renamed As New AutorizacionSri
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto opAlex.CiRuc. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Auto_Renamed = BuscarAutorizacionesSRI(opAlex.CiRuc, (TipoComprobante.BoundText), txtNumSer.Text, TxtSerEstablec.Text, txtNumSec.Text, txtFecEmiCom.Text)
		txtAutCom.Text = Auto_Renamed.AutNroAut
		FechaCaduca.Text = CStr(Auto_Renamed.AutFechaVence)
		'UPGRADE_NOTE: El objeto Auto_Renamed no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		Auto_Renamed = Nothing
	End Sub
	
	'UPGRADE_WARNING: El evento txtNumSer.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtNumSer_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtNumSer.TextChanged
		'cambiar on error Resume Next
		If Len(txtNumSer.Text) = 3 Then TxtSerEstablec.Focus()
	End Sub
	
	Private Sub txtNumSer_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtNumSer.KeyDown
		Dim keycode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If keycode = System.Windows.Forms.Keys.F2 Or keycode = System.Windows.Forms.Keys.F4 Then txtNumSer.Text = "001"
	End Sub
	
	Private Sub txtNumSer_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtNumSer.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = IngresaSoloNumero(KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'UPGRADE_WARNING: El evento TxtPorcRetIR.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub TxtPorcRetIR_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TxtPorcRetIR.TextChanged
		Dim Index As Short = TxtPorcRetIR.GetIndex(eventSender)
		CalcularMontoRenta()
	End Sub
	
	Private Sub CalcularMontoRenta()
		TxtMonRetRen(0).Text = VB6.Format(Val(TxtPorcRetIR(0).Text) * Val(TxtBasImpIR(0).Text) / 100, FORMATONUM)
		TxtMonRetRen(1).Text = VB6.Format(Val(TxtPorcRetIR(1).Text) * Val(TxtBasImpIR(1).Text) / 100, FORMATONUM)
	End Sub
	
	Private Sub TxtPorcRetIR_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TxtPorcRetIR.Enter
		Dim Index As Short = TxtPorcRetIR.GetIndex(eventSender)
		PonerSel(TxtPorcRetIR)
	End Sub
	
	Private Sub TxtPorcRetIR_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TxtPorcRetIR.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = TxtPorcRetIR.GetIndex(eventSender)
		KeyAscii = IngresaSoloValores(KeyAscii, TxtPorcRetIR(Index).Text)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'UPGRADE_WARNING: El evento txtPro.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtPro_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtPro.TextChanged
		CargarCombos()
	End Sub
	
	Private Sub txtPro_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtPro.KeyDown
		Dim keycode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If keycode = System.Windows.Forms.Keys.Return Then txtCod = txtPro.Text : buscacli()
		CargarCombos()
	End Sub
	
	Private Sub TxtSecuencialIR_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TxtSecuencialIR.KeyDown
		Dim keycode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If keycode = System.Windows.Forms.Keys.Return Then
			TxtNroAutorizaIR.Focus()
		End If
	End Sub
	
	Private Sub TxtSecuencialIR_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TxtSecuencialIR.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = IngresaSoloNumero(KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub TxtSecuencialIR_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TxtSecuencialIR.Leave
		TxtSecuencialIR_KeyDown(TxtSecuencialIR, New System.Windows.Forms.KeyEventArgs(32 Or 0 * &H10000))
	End Sub
	
	'UPGRADE_WARNING: El evento TxtSerEstablec.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub TxtSerEstablec_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TxtSerEstablec.TextChanged
		'cambiar on error Resume Next
		If Len(TxtSerEstablec.Text) = 3 Then txtNumSec.Focus()
	End Sub
	
	Private Sub TxtSerEstablec_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TxtSerEstablec.KeyDown
		Dim keycode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If keycode = System.Windows.Forms.Keys.F2 Or keycode = System.Windows.Forms.Keys.F4 Then TxtSerEstablec.Text = "001"
	End Sub
	
	Private Sub TxtSerEstablec_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TxtSerEstablec.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = IngresaSoloNumero(KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'UPGRADE_WARNING: El evento TxtSerieEmicionMod.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub TxtSerieEmicionMod_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TxtSerieEmicionMod.TextChanged
		If Len(TxtSerieEmicionMod.Text) = 3 Then TxtNumeroSecuencialMod.Focus()
	End Sub
	
	Private Sub TxtSerieEmicionMod_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TxtSerieEmicionMod.KeyDown
		Dim keycode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If keycode = System.Windows.Forms.Keys.F2 Or keycode = System.Windows.Forms.Keys.F4 Then TxtSerieEmicionMod.Text = "001"
	End Sub
	
	Private Sub TxtSerieEmicionMod_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TxtSerieEmicionMod.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = IngresaSoloNumero(KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'UPGRADE_WARNING: El evento TxtSerieEmision.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub TxtSerieEmision_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TxtSerieEmision.TextChanged
		'cambiar on error Resume Next
		If Len(TxtSerieEmision.Text) = 3 Then TxtSecuencialIR.Focus()
	End Sub
	
	Private Sub TxtSerieEmision_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TxtSerieEmision.KeyDown
		Dim keycode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If keycode = System.Windows.Forms.Keys.F2 Or keycode = System.Windows.Forms.Keys.F4 Then TxtSerieEmision.Text = "001"
	End Sub
	
	Private Sub TxtSerieEmision_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TxtSerieEmision.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = IngresaSoloNumero(KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'UPGRADE_WARNING: El evento TxtserieEstableceMod.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub TxtserieEstableceMod_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TxtserieEstableceMod.TextChanged
		If Len(TxtserieEstableceMod.Text) = 3 Then TxtSerieEmicionMod.Focus()
	End Sub
	
	Private Sub TxtserieEstableceMod_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TxtserieEstableceMod.KeyDown
		Dim keycode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If keycode = System.Windows.Forms.Keys.F2 Or keycode = System.Windows.Forms.Keys.F4 Then TxtserieEstableceMod.Text = "001"
	End Sub
	
	Private Sub TxtserieEstableceMod_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TxtserieEstableceMod.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = IngresaSoloNumero(KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'UPGRADE_WARNING: El evento TxtSerieEstblIR.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub TxtSerieEstblIR_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TxtSerieEstblIR.TextChanged
		'cambiar on error Resume Next
		If Len(TxtSerieEstblIR.Text) = 3 Then TxtSerieEmision.Focus()
	End Sub
	
	Private Sub TxtSerieEstblIR_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TxtSerieEstblIR.KeyDown
		Dim keycode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If keycode = System.Windows.Forms.Keys.F2 Or keycode = System.Windows.Forms.Keys.F4 Then TxtSerieEstblIR.Text = "001"
	End Sub
	
	Private Sub TxtSerieEstblIR_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TxtSerieEstblIR.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = IngresaSoloNumero(KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class