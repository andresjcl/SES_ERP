Option Strict Off
Option Explicit On
Friend Class SRIIMPORTA
	Inherits System.Windows.Forms.Form
	Dim RsSRI As New ADODB.Recordset
	Dim RsTemp As New ADODB.Recordset
	Dim Control As Short
	Dim Sw, SwSn As Boolean
	Dim esnuevo As Boolean
	Dim salir As Short
	Dim mes, Anio, identificacion As String
	Dim num_Secue As Integer
	Dim txtCod, Iden, RucCiProveedor As String
	Const FORMATONUM As String = "########0.00"
	Dim SeqTran(25) As String
	Dim Documentos As String
	Dim NSeqTran As Short
	Dim opAlex As New ManDirct.Directorio
	
	Private Sub BtEmision_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BtEmision.Click
		txtFecLiquidacion.Text = CStr(QueFecha)
	End Sub
	
	Private Sub btncancelar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btncancelar.Click
		If ConfirmaCancelar Then btnnuevo_Click(btnnuevo, New System.EventArgs())
	End Sub
	
	Private Sub CodRetFteImpRent_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CodRetFteImpRent.Change
		Dim claves As String
		claves = CodRetFteImpRent.BoundText
		If claves = "" Then Exit Sub
		TxtPorcRetIR.ReadOnly = False
		If claves = "401" Then
			TxtPorcRetIR.Text = ""
		Else
			With DtPorRetIR
				.Recordset.MoveFirst()
				.Recordset.Find("codigo=" & claves)
				TxtPorcRetIR.Text = .Recordset.Fields("porretencion").Value
				TxtPorcRetIR.ReadOnly = True
			End With
		End If
	End Sub
	
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		Me.Close()
	End Sub
	
	Private Sub DatSustento_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DatSustento.Change
		If IsDate(txtFecLiquidacion.Text) Then
			CargarTipoDocumento()
			CargarPorcentajeIva()
			CargarPorcentajeICE()
			CargarPorRetencionFuente()
		End If
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
	
	Private Sub txtAutCom_KeyPress(ByRef KeyAscii As Short)
		KeyAscii = IngresaSoloNumero(KeyAscii)
	End Sub
	
	Private Sub TxtAutorizaMod_KeyPress(ByRef KeyAscii As Short)
		KeyAscii = IngresaSoloNumero(KeyAscii)
	End Sub
	
	'UPGRADE_WARNING: El evento TxtAnio.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub TxtAnio_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TxtAnio.TextChanged
		If Len(TxtAnio.Text) = 4 Then TxtRegimen.Focus()
	End Sub
	
	Private Sub TxtAnio_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TxtAnio.KeyPress
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
		TxtPorcRetIR.ReadOnly = False
		txtPro.ReadOnly = False
	End Sub
	
	Private Sub btPro_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btPro.Click
		buscarclientes()
	End Sub
	
	Public Sub buscarclientes()
		''cambiar on error Resume Next
		Dim buscaclien As New ManDirct.BuscaClien
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto buscaclien.IniBuscaCliOPro. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		txtCod = buscaclien.IniBuscaCliOPro("P", txtCod)
		'UPGRADE_NOTE: El objeto buscaclien no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		buscaclien = Nothing
		buscacli()
	End Sub
	
	Public Sub buscacli()
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
			Iden = opAlex.TipoId
		End If
	End Sub
	
	Private Sub SRIIMPORTA_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		''cambiar on error Resume Next
		Dim cod As String
		txtFecLiquidacion.Text = VB6.Format(Today, "dd/mm/yyyy")
		centrarforma(Me)
		titulo(Me)
		CargarTransacciones()
		CargarSustento()
		btnnuevo_Click(btnnuevo, New System.EventArgs())
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
	
	Private Sub CargarTransacciones()
		Dim claves As String
		Dim rs As New ADODB.Recordset
		Dim i As Short
		For i = 0 To 25
			SeqTran(i) = ""
		Next i
		rs.Open("Select * from SriSecuencialesTransacciones where CodigoTipoTransaccion = 1", ConxSyscod, ADOR.CursorTypeEnum.adOpenKeyset, ADOR.LockTypeEnum.adLockOptimistic)
		If rs.EOF Then Exit Sub
		NSeqTran = 0
		rs.MoveFirst()
		Do Until rs.EOF = True
			NSeqTran = NSeqTran + 1
			SeqTran(NSeqTran) = VB6.Format(rs.Fields("codigo").Value, "00")
			rs.MoveNext()
		Loop 
	End Sub
	
	Private Sub CargarTipoDocumento()
		Dim claves As String
		claves = DatSustento.BoundText
		If claves = "" Then Exit Sub
		dtCodSus.Recordset.MoveFirst()
		dtCodSus.Recordset.Find("codigo=" & claves)
		claves = SepararClaves(dtCodSus.Recordset.Fields("CodigoTipoComprobante").Value, "codigo")
		With dtCom
			.CommandType = ADODB.CommandTypeEnum.adCmdText
			.ConnectionString = StrConxsysemp
			.RecordSource = "Select *  From sritipodecomprobante Where (CodigoSecuencialTransaccion LIKE '%08%' ) and (" & claves & ") order by codigo "
			.Refresh()
		End With
		
		With TipoComprobante
			If dtCom.Recordset.RecordCount > 0 Then
				dtCom.Recordset.MoveFirst()
				.BoundText = dtCom.Recordset.Fields("codigo").Value
			End If
		End With
		
	End Sub
	
	Private Sub CargarPorcentajeIva()
		With dtPorIva
			.CommandType = ADODB.CommandTypeEnum.adCmdText
			.ConnectionString = StrConxsysemp
			.RecordSource = "select * from SriPorcentajesDelIva where fechainicio <= " & ArmFormatoFecha(txtFecLiquidacion.Text) & " AND fechafin >= " & ArmFormatoFecha(txtFecLiquidacion.Text) & " ORDER BY CODIGO DESC"
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
			.RecordSource = "select * from SriPorcentajesDelIce where fechainicio <= " & ArmFormatoFecha(txtFecLiquidacion.Text) & " AND fechafin >= " & ArmFormatoFecha(txtFecLiquidacion.Text) & " ORDER BY CODIGO DESC"
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
	
	Private Sub CargarPorRetencionFuente()
		With DtPorRetIR
			.CommandType = ADODB.CommandTypeEnum.adCmdText
			.ConnectionString = StrConxsysemp
			.RecordSource = " Select * From SriConceptosRetencion where fechainicio <= " & ArmFormatoFecha(txtFecLiquidacion.Text) & " AND fechafin >= " & ArmFormatoFecha(txtFecLiquidacion.Text) & " ORDER BY CODIGO "
			.Refresh()
			
			If .Recordset.RecordCount > 0 Then
				.Recordset.MoveFirst()
				'     If .Recordset.RecordCount > 1 Then .Recordset.MoveNext
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CodRetFteImpRent.BoundText = CorrijeNulo(.Recordset.Fields("codigo"))
				'dcPorIva.Text = dtPorIva.Recordset!porcentajeiva
			End If
		End With
	End Sub
	
	Private Sub btnnuevo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnnuevo.Click
		''cambiar on error Resume Next
		limpia()
		esnuevo = True
		F2.Visible = True
		f3.Visible = False
		CargarTipoDocumento()
	End Sub
	
	Private Sub btnsalir_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnsalir.Click
		Me.Close()
	End Sub
	
	Private Sub SRIIMPORTA_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		'UPGRADE_ISSUE: No se actualizó el parámetro Event Cancel. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"'
		If ConfirmaSalir = False Then Cancel = 1
		If RsSRI.State = 1 Then RsSRI.Close()
	End Sub
	
	Private Sub btngrabar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btngrabar.Click
		Dim sSQL As String
		'If txtPro = "" Or Val(txtNumSer) = 0 Or Val(TxtSerEstablec) = 0 Or Val(txtNumSec) = 0 Then
		'    MsgBox "No se puede grabar este registro, No tiene los datos suficientes", vbCritical
		'    Exit Sub
		'End If
		'''cambiar on error GoTo HayErrores
		If Not esnuevo Then EliminaParaRegrabar()
		
		sSQL = "select * From  importacion WHere  CL_CodigoProveedor = '" & txtPro.Text & "' and CL_ReferendoDistrito = '" & TxtDistritoAd.Text & "' and CL_ReferendoAño = '" & TxtAnio.Text & "' and CL_ReferendoRegimen = '" & TxtRegimen.Text & "' and CL_ReferendoCorrelativo = '" & TxtCorrelativo.Text & "' and CL_ReferendoVerificador = '" & TxtVerificador.Text & "'"
		RsSRI = New ADODB.Recordset
		With RsSRI
			.Open(sSQL, ConxSri, ADOR.CursorTypeEnum.adOpenKeyset, ADOR.LockTypeEnum.adLockOptimistic)
			If .EOF Then .AddNew()
			'
			.Fields("CL_SusTributario").Value = DatSustento.BoundText
			.Fields("CL_ImportacionDe").Value = IIf(Option1.Checked, "1", "2")
			.Fields("CL_FechaLiquidacion").Value = txtFecLiquidacion.Text
			.Fields("Cl_TipoComprobante").Value = TipoComprobante.BoundText
			.Fields("CL_ReferendoDistrito").Value = TxtDistritoAd.Text
			.Fields("CL_ReferendoAño").Value = TxtAnio.Text
			.Fields("CL_ReferendoRegimen").Value = TxtRegimen.Text
			.Fields("CL_ReferendoCorrelativo").Value = TxtCorrelativo.Text
			.Fields("CL_ReferendoVerificador").Value = TxtVerificador.Text
			.Fields("CL_CodigoProveedor").Value = txtPro.Text
			'!CL_NroIdFiscalProveedor = RucCiProveedor
			.Fields("CL_ValorCIF").Value = TxtValCif.Text
			.Fields("CL_RazonSocialProveedor").Value = lbNomP.Text
			.Fields("CL_TipoSujetoProveedor").Value = Iden
			.Fields("CL_BaseImpTarifaCero").Value = txtBasImpTar0.Text
			.Fields("CL_BaseImpGravadaIva").Value = txtBasImpGra.Text
			.Fields("CL_CodPorcIVA").Value = CorrijeNuloN((dcPorIva.BoundText))
			.Fields("CL_MontoIva").Value = TxtMonIva.Text
			.Fields("CL_BaseImponibleICE").Value = TxtBasImpICE.Text
			.Fields("CL_CodPorcICE").Value = Val(DcPorICE.BoundText)
			.Fields("CL_MontoICE").Value = TxtMonIce.Text
			.Fields("CL_ConcRetFuenteRenta").Value = CodRetFteImpRent.BoundText
			.Fields("CL_BaseImponibleRenta").Value = TxtBasImpIR.Text
			.Fields("CL_CodigoPorcRenta").Value = TxtPorcRetIR.Text
			.Fields("CL_MontoRetencionRenta").Value = TxtMonRetRen.Text
			
			.Update()
			.Close()
			
		End With
		btnnuevo_Click(btnnuevo, New System.EventArgs())
		Exit Sub
HayErrores: 
		ControlaErrores("Grabando Compras")
	End Sub
	
	Private Sub muestra()
		Dim sSQL As String
		'If txtCod = "" Or Val(txtNumSer) = 0 Or Val(TxtSerEstablec) = 0 Or Val(txtNumSec) = 0 Then
		'    MsgBox ""
		'''cambiar on error Resume Next
		Sw = True
		sSQL = "select * From  importacion WHere  CL_CodigoProveedor = '" & txtPro.Text & "' and CL_ReferendoDistrito = '" & TxtDistritoAd.Text & "' and CL_ReferendoAño = '" & TxtAnio.Text & "' and CL_ReferendoRegimen = '" & TxtRegimen.Text & "' and CL_ReferendoCorrelativo = '" & TxtCorrelativo.Text & "' and CL_ReferendoVerificador = '" & TxtVerificador.Text & "'"
		RsSRI = New ADODB.Recordset
		RsSRI.Open(sSQL, ConxSri, ADOR.CursorTypeEnum.adOpenKeyset, ADOR.LockTypeEnum.adLockOptimistic)
		If RsSRI.EOF Then esnuevo = True : Exit Sub
		If RsSRI.State = 0 Then esnuevo = True : Exit Sub
		With RsSRI
			
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtPro.Text = CorrijeNulo(.Fields("CL_CodigoProveedor"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DatSustento.BoundText = CorrijeNulo(.Fields("CL_SusTributario"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Option1.Checked = (CorrijeNulo(.Fields("CL_ImportacionDe")) = "1")
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtFecLiquidacion.Text = CorrijeNulo(.Fields("CL_FechaLiquidacion"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TipoComprobante.BoundText = CorrijeNulo(.Fields("Cl_TipoComprobante"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtDistritoAd.Text = CorrijeNulo(.Fields("CL_ReferendoDistrito"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtAnio.Text = CorrijeNulo(.Fields("CL_ReferendoAño"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtRegimen.Text = CorrijeNulo(.Fields("CL_ReferendoRegimen"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtCorrelativo.Text = CorrijeNulo(.Fields("CL_ReferendoCorrelativo"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtVerificador.Text = CorrijeNulo(.Fields("CL_ReferendoVerificador"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			RucCiProveedor = CorrijeNulo(.Fields("CL_NroIdFiscalProveedor"))
			TxtValCif.Text = CStr(CorrijeNuloN(.Fields("CL_ValorCIF")))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			lbNomP.Text = CorrijeNulo(.Fields("CL_RazonSocialProveedor"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Iden = CorrijeNulo(.Fields("CL_TipoSujetoProveedor"))
			txtBasImpTar0.Text = CStr(CorrijeNuloN(.Fields("CL_BaseImpTarifaCero")))
			txtBasImpGra.Text = CStr(CorrijeNuloN(.Fields("CL_BaseImpGravadaIva")))
			dcPorIva.BoundText = CStr(CorrijeNuloN(.Fields("CL_CodigoPorcIva")))
			TxtMonIva.Text = CStr(CorrijeNuloN(.Fields("CL_MontoIva")))
			TxtBasImpICE.Text = CStr(CorrijeNuloN(.Fields("CL_BaseImpICE")))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			DcPorICE.BoundText = CorrijeNulo(.Fields("CL_CodPorcICE"))
			TxtMonIce.Text = CStr(CorrijeNuloN(.Fields("CL_MontoICE")))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CodRetFteImpRent.BoundText = CorrijeNulo(.Fields("CL_ConcRetFuenteRenta"))
			TxtBasImpIR.Text = CStr(CorrijeNuloN(.Fields("CL_BaseImponibleRenta")))
			TxtPorcRetIR.Text = CStr(CorrijeNuloN(.Fields("CL_CodigoPorcRenta")))
			TxtMonRetRen.Text = CStr(CorrijeNuloN(.Fields("CL_MontoRetencionRenta")))
			
			F2.Visible = False
			f3.Visible = True
			esnuevo = False
		End With
	End Sub
	
	Private Sub btneliminar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btneliminar.Click
		Dim sieli As Byte
		Dim sSQL As String
		''cambiar on error Resume Next
		sieli = ConfirmaEliminar
		If sieli = MsgBoxResult.Yes Then
			sSQL = "DELETE * From  importacion WHere  CL_CodigoProveedor = '" & txtPro.Text & "' and CL_ReferendoDistrito = '" & TxtDistritoAd.Text & "' and CL_ReferendoAño = '" & TxtAnio.Text & "' and CL_ReferendoRegimen = '" & TxtRegimen.Text & "' and CL_ReferendoCorrelativo = '" & TxtCorrelativo.Text & "' and CL_ReferendoVerificador = '" & TxtVerificador.Text & "'"
			ConxSri.Execute(sSQL)
			btnnuevo_Click(btnnuevo, New System.EventArgs())
		End If
	End Sub
	Private Sub EliminaParaRegrabar()
		Dim sieli As Byte
		Dim sSQL As String
		''cambiar on error Resume Next
		If RsSRI.State = 1 Then RsSRI.Close()
		sSQL = "DELETE * From  importacion WHere  CL_CodigoProveedor = '" & txtPro.Text & "' and CL_ReferendoDistrito = '" & TxtDistritoAd.Text & "' and CL_ReferendoAño = '" & TxtAnio.Text & "' and CL_ReferendoRegimen = '" & TxtRegimen.Text & "' and CL_ReferendoCorrelativo = '" & TxtCorrelativo.Text & "' and CL_ReferendoVerificador = '" & TxtVerificador.Text & "'"
		ConxSri.Execute(sSQL)
	End Sub
	
	Private Sub txtAutCom_KeyDown(ByRef keycode As Short, ByRef Shift As Short)
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
		CalcularMontoRenta()
	End Sub
	
	Private Sub TxtBasImpIR_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TxtBasImpIR.Enter
		PonerSel(TxtBasImpIR)
	End Sub
	
	Private Sub TxtBasImpIR_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TxtBasImpIR.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = IngresaSoloValores(KeyAscii, TxtBasImpIR.Text)
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
	
	'UPGRADE_WARNING: El evento TxtCorrelativo.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub TxtCorrelativo_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TxtCorrelativo.TextChanged
		If Len(TxtCorrelativo.Text) = 5 Then TxtVerificador.Focus()
	End Sub
	
	Private Sub TxtCorrelativo_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TxtCorrelativo.KeyDown
		Dim keycode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If keycode = System.Windows.Forms.Keys.Return Then TxtVerificador.Focus()
	End Sub
	
	Private Sub TxtCorrelativo_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TxtCorrelativo.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = IngresaSoloNumero(KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'UPGRADE_WARNING: El evento TxtDistritoAd.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub TxtDistritoAd_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TxtDistritoAd.TextChanged
		If Len(TxtDistritoAd.Text) = 3 Then TxtAnio.Focus()
	End Sub
	
	Private Sub TxtDistritoAd_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TxtDistritoAd.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = IngresaSoloNumero(KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtFecLiquidacion_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFecLiquidacion.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = IngresaSoloFechas(KeyAscii, txtFecLiquidacion)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'UPGRADE_WARNING: El evento txtMonIvaBie.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtMonIvaBie_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMonIvaBie.TextChanged
		TxtMonIvaSer.Text = CStr(Val(TxtMonIva.Text) - Val(txtMonIvaBie.Text))
		If Val(TxtMonIvaSer.Text) < 0 Then txtMonIvaBie.Text = CStr(0)
	End Sub
	
	Private Sub txtMonIvaBie_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMonIvaBie.Enter
		PonerSel(txtMonIvaBie)
	End Sub
	
	Private Sub txtMonIvaBie_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtMonIvaBie.KeyDown
		Dim keycode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If keycode = System.Windows.Forms.Keys.F2 Then txtMonIvaBie.Text = TxtMonIva.Text
	End Sub
	
	Private Sub txtMonIvaBie_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtMonIvaBie.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = IngresaSoloValores(KeyAscii, txtMonIvaBie.Text)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub TxtNroAutorizaIR_KeyPress(ByRef KeyAscii As Short)
		KeyAscii = IngresaSoloNumero(KeyAscii)
	End Sub
	
	Private Sub TxtNumeroSecuencialMod_KeyPress(ByRef KeyAscii As Short)
		KeyAscii = IngresaSoloNumero(KeyAscii)
	End Sub
	
	Private Sub txtNumSec_KeyDown(ByRef keycode As Short, ByRef Shift As Short)
		If keycode = System.Windows.Forms.Keys.Return Then
			muestra()
			'  If esnuevo Then BuscaAutorizacionSri: txtAutCom.SetFocus
		End If
	End Sub
	
	Private Sub txtNumSec_KeyPress(ByRef KeyAscii As Short)
		KeyAscii = IngresaSoloNumero(KeyAscii)
	End Sub
	
	Private Sub txtNumSer_KeyPress(ByRef KeyAscii As Short)
		KeyAscii = IngresaSoloNumero(KeyAscii)
	End Sub
	
	'UPGRADE_WARNING: El evento TxtPorcRetIR.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub TxtPorcRetIR_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TxtPorcRetIR.TextChanged
		CalcularMontoRenta()
	End Sub
	Private Sub CalcularMontoRenta()
		TxtMonRetRen.Text = VB6.Format(Val(TxtPorcRetIR.Text) * Val(TxtBasImpIR.Text) / 100, FORMATONUM)
	End Sub
	
	Private Sub TxtPorcRetIR_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TxtPorcRetIR.Enter
		PonerSel(TxtPorcRetIR)
	End Sub
	
	Private Sub TxtPorcRetIR_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TxtPorcRetIR.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = IngresaSoloValores(KeyAscii, TxtPorcRetIR.Text)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtPro_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtPro.KeyDown
		Dim keycode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If keycode = System.Windows.Forms.Keys.Return Then txtCod = txtPro.Text : buscacli()
	End Sub
	
	Private Sub TxtSecuencialIR_KeyPress(ByRef KeyAscii As Short)
		KeyAscii = IngresaSoloNumero(KeyAscii)
	End Sub
	
	Private Sub TxtSerEstablec_KeyPress(ByRef KeyAscii As Short)
		KeyAscii = IngresaSoloNumero(KeyAscii)
	End Sub
	
	Private Sub TxtSerieEmicionMod_KeyPress(ByRef KeyAscii As Short)
		KeyAscii = IngresaSoloNumero(KeyAscii)
	End Sub
	
	Private Sub TxtSerieEmision_KeyPress(ByRef KeyAscii As Short)
		KeyAscii = IngresaSoloNumero(KeyAscii)
	End Sub
	
	Private Sub TxtserieEstableceMod_KeyPress(ByRef KeyAscii As Short)
		KeyAscii = IngresaSoloNumero(KeyAscii)
	End Sub
	
	Private Sub TxtSerieEstblIR_KeyPress(ByRef KeyAscii As Short)
		KeyAscii = IngresaSoloNumero(KeyAscii)
	End Sub
	
	'UPGRADE_WARNING: El evento TxtRegimen.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub TxtRegimen_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TxtRegimen.TextChanged
		If Len(TxtRegimen.Text) = 2 Then TxtCorrelativo.Focus()
	End Sub
	
	Private Sub TxtRegimen_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TxtRegimen.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = IngresaSoloNumero(KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'UPGRADE_WARNING: El evento TxtVerificador.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub TxtVerificador_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TxtVerificador.TextChanged
		If Len(TxtVerificador.Text) = 1 Then txtFecLiquidacion.Focus()
	End Sub
	
	Private Sub TxtVerificador_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TxtVerificador.KeyDown
		Dim keycode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If keycode = System.Windows.Forms.Keys.Return Then txtFecLiquidacion.Focus()
	End Sub
	
	Private Sub TxtVerificador_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TxtVerificador.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = IngresaSoloNumero(KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class