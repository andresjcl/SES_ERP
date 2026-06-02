Option Strict Off
Option Explicit On
Friend Class SRIVENTAS
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
	Const FORMATONUM As String = "########0.00"
	Dim SeqTran(25) As String
	Dim Documentos As String
	Dim NSeqTran As Short
	Dim NumClave As Double
	Dim opAlex As ManDirct.Directorio
	Public DocClave As Double
	Private Sub BtContable_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BtContable.Click
		txtFecRegCont.Text = CStr(QueFecha)
	End Sub
	
	Private Sub BtEmision_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BtEmision.Click
		txtFecEmiCom.Text = CStr(QueFecha)
	End Sub
	
	Private Sub btnenviar_Click()
		
	End Sub
	
	Private Sub btncancelar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btncancelar.Click
		If ConfirmaCancelar Then btnnuevo_Click(btnnuevo, New System.EventArgs())
	End Sub
	
	'UPGRADE_WARNING: El evento CantCpbtes.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub CantCpbtes_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CantCpbtes.TextChanged
		If Val(CantCpbtes.Text) > 1 Then
			txtFecEmiCom.Text = CStr(FechaFinMes(Year(CDate(txtFecEmiCom.Text)), Month(CDate(txtFecEmiCom.Text))))
			txtFecRegCont.Text = CStr(FechaFinMes(Year(CDate(txtFecRegCont.Text)), Month(CDate(txtFecRegCont.Text))))
		End If
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
	
	Private Sub Command1_Click()
		btnnuevo_Click(btnnuevo, New System.EventArgs())
	End Sub
	
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		Me.Close()
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
	
	Private Sub txtAutCom_KeyPress(ByRef KeyAscii As Short)
		KeyAscii = IngresaSoloNumero(KeyAscii)
	End Sub
	
	Private Sub TipoComprobante_Change(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TipoComprobante.Change
		If IsDate(txtFecEmiCom.Text) And IsDate(txtFecRegCont.Text) Then
			CargarPorcentajeIva()
			CargarPorcentajeICE()
			CargarPorRetencioIvaBienes()
			CargarPorRetencioIvaServicios()
			CargarPorRetencionFuente()
		End If
		If txtPro.Text > "" Then muestra()
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
		''cambiar on error Resume Next
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
			ElseIf a = "DataCombo" Then 
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
		'txtNumSer.Locked = False
		'TxtSerEmision.Locked = False
		'txtNumSec.Locked = False
	End Sub
	
	Private Sub btPro_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btPro.Click
		buscarclientes()
	End Sub
	
	Public Sub buscarclientes()
		''cambiar on error Resume Next
		Dim buscaclien As New ManDirct.BuscaClien
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto buscaclien.IniBuscaCliOPro. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		txtCod = buscaclien.IniBuscaCliOPro("C", txtCod)
		'UPGRADE_NOTE: El objeto buscaclien no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		buscaclien = Nothing
		buscacli()
	End Sub
	
	Public Sub buscacli()
		opAlex = New ManDirct.Directorio
		''cambiar on error Resume Next
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto opAlex.CargarAlex. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If opAlex.CargarAlex(txtCod, True) = False Then
			txtCod = ""
			txtPro.Text = ""
			Iden = ""
			lbNomP.Text = ""
			MsgBox("No existe el cliente registrado")
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
			txtFecRegCont.Focus()
		End If
		
	End Sub
	Private Sub SRIVENTAS_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		''cambiar on error Resume Next
		Dim cod As String
		txtFecEmiCom.Text = CStr(FechaFinMes(Year(Today), Month(Today)))
		txtFecRegCont.Text = txtFecEmiCom.Text
		centrarforma(Me)
		titulo(Me)
		CargarTransacciones()
		CargarTipoDocumento()
		If DocClave > 0 Then
			muestra()
		Else
			btnnuevo_Click(btnnuevo, New System.EventArgs())
		End If
	End Sub
	
	Private Sub CargarTransacciones()
		Dim claves As String
		Dim rs As New ADODB.Recordset
		Dim i As Short
		For i = 0 To 25
			SeqTran(i) = ""
		Next i
		rs.Open("Select * from SriSecuencialesTransacciones where CodigoTipoTransaccion = 2", ConxSyscod, ADOR.CursorTypeEnum.adOpenKeyset, ADOR.LockTypeEnum.adLockOptimistic)
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
		Dim RAux As New ADODB.Recordset
		RAux = New ADODB.Recordset
		RAux.Open("SELECT * FROM SriTipoDeTransaccion WHERE CODIGO = 2", ConxSyscod, ADOR.CursorTypeEnum.adOpenKeyset, ADOR.LockTypeEnum.adLockOptimistic)
		If RAux.EOF Then
			MsgBox("No se ha definido la tabla de Tipos de Transaccion")
			RAux.Close()
			Exit Sub
		End If
		
		claves = RAux.Fields("TipoComprobante").Value
		If claves = "" Then
			MsgBox("En tabla de tipo de transacciones, codigo 2 " & " el tipo de documentos esta mal definido")
			RAux.Close()
			Exit Sub
		End If
		claves = SepararClaves(claves, "codigo")
		With dtCom
			.CommandType = ADODB.CommandTypeEnum.adCmdText
			.ConnectionString = StrConxsysemp
			.RecordSource = "Select *  From sritipodecomprobante Where  " & claves & " order by codigo "
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
				'     If .Recordset.RecordCount > 1 Then .Recordset.MoveNext
				dcPorIvaBie.BoundText = .Recordset.Fields("codigo").Value
				'dcPorIva.Text = dtPorIva.Recordset!porcentajeiva
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
				'     If .Recordset.RecordCount > 1 Then .Recordset.MoveNext
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CodRetFteImpRent(0).BoundText = CorrijeNulo(.Recordset.Fields("codigo"))
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CodRetFteImpRent(1).BoundText = CorrijeNulo(.Recordset.Fields("codigo"))
				'dcPorIva.Text = dtPorIva.Recordset!porcentajeiva
			End If
		End With
	End Sub
	
	Private Sub btnmodificar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnmodificar.Click
		''cambiar on error GoTo HayErrores
		
		fprincipal.Enabled = True
		
		txtPro.ReadOnly = True
		'    txtNumSer.Locked = True
		'    TxtSerEmision.Locked = True
		'    txtNumSec.Locked = True
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
		fprincipal.Enabled = True
		esnuevo = True
		F2.Visible = True
		f3.Visible = False
		CargarTipoDocumento()
	End Sub
	
	Private Sub btnsalir_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnsalir.Click
		Me.Close()
	End Sub
	
	Private Sub SRIVENTAS_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		'UPGRADE_ISSUE: No se actualizó el parámetro Event Cancel. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"'
		If ConfirmaSalir = False Then Cancel = 1
		If RsSRI.State = 1 Then RsSRI.Close()
	End Sub
	
	Private Sub btngrabar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btngrabar.Click
		Dim sSQL As String
		'If txtPro = "" Or Val(txtNumSer) = 0 Or Val(TxtSerEmision) = 0 Or Val(txtNumSec) = 0 Then
		'    MsgBox "No se puede grabar este registro, No tiene los datos suficientes", vbCritical
		'    Exit Sub
		''else validarcompras
		'End If
		'''cambiar on error GoTo HayErrores
		'If Not esnuevo Then EliminaParaRegrabar
		'cambiar on error GoTo 0
		sSQL = "select * From  Ventas WHere  clave=" & NumClave
		RsSRI = New ADODB.Recordset
		With RsSRI
			.Open(sSQL, ConxSri, ADOR.CursorTypeEnum.adOpenKeyset, ADOR.LockTypeEnum.adLockOptimistic)
			If .EOF Then .AddNew()
			.Fields("CL_CodigoCliente").Value = txtPro.Text
			opAlex = New ManDirct.Directorio
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto opAlex.CargarAlex. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			opAlex.CargarAlex(txtPro, True, "S")
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto opAlex.TipoId. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Fields("CL_TipoId").Value = CorrijeTipoId(opAlex.TipoId)
			.Fields("CL_NroDeComprobantes").Value = Val(CantCpbtes.Text)
			.Fields("Cl_TipoComprobante").Value = TipoComprobante.BoundText
			.Fields("CL_FechaRegContable").Value = txtFecRegCont.Text
			.Fields("CL_FechaComprobante").Value = txtFecEmiCom.Text
			.Fields("CL_IvaPresuntivo").Value = IIf(IvaPresunt.CheckState = 1, "S", "N")
			
			.Fields("CL_BaseImpTarCero").Value = txtBasImpTar0.Text
			
			
			.Fields("CL_BaseImpGravadaIva").Value = txtBasImpGra.Text
			.Fields("CL_CodigoPorIva").Value = CorrijeNuloN((dcPorIva.BoundText))
			.Fields("CL_RetencionPresuntiva").Value = IIf(Check1(0).CheckState = 1, "S", "N")
			'CL_CodRetFteImpRenta1   CL_BaseImponibleIR1 CL_CodPorcRetIR1    CL_MontoRetIR1  CL_CodRetFteImpRenta2   CL_BaseImponibleIR2 CL_CodPorcRetIR2    CL_MontoRetIR2  Clave
			
			.Fields("CL_MontoIva").Value = TxtMonIva.Text
			.Fields("CL_BaseImpICE").Value = TxtBasImpICE.Text
			.Fields("CL_CodigoPorcICE").Value = CorrijeNuloN((DcPorICE.BoundText))
			.Fields("CL_MontoICE").Value = Val(TxtMonIce.Text)
			.Fields("CL_MontoIvaBienes").Value = Val(txtMonIvaBie.Text)
			.Fields("CL_CodPorcRetIvaBienes").Value = Val(dcPorIvaBie.BoundText)
			.Fields("CL_MontoRetIvaBienes").Value = Val(TxtMonRetBie.Text)
			.Fields("CL_MontoIvaServ").Value = Val(TxtMonIvaSer.Text)
			.Fields("CL_CodPorRetIvaServicios").Value = Val(DcPorIvaServ.BoundText)
			.Fields("CL_MontoRetIvaServicios").Value = CorrijeNuloN(TxtMonRetSer)
			.Fields("CL_CodRetFteImpRenta1").Value = CodRetFteImpRent(0).BoundText
			.Fields("CL_BaseImponibleIR1").Value = TxtBasImpIR(0).Text
			.Fields("CL_CodPorcRetIR1").Value = TxtPorcRetIR(0).Text
			.Fields("CL_MontoRetIR1").Value = TxtMonRetRen(0).Text
			
			.Fields("CL_CodRetFteImpRenta2").Value = CodRetFteImpRent(1).BoundText
			.Fields("CL_BaseImponibleIR2").Value = TxtBasImpIR(1).Text
			.Fields("CL_CodPorcRetIR2").Value = TxtPorcRetIR(1).Text
			.Fields("CL_MontoRetIR2").Value = TxtMonRetRen(1).Text
			
			
			.Fields("CL_NroDeComprobantes").Value = CorrijeNuloN(CantCpbtes)
			.Fields("CL_IvaPresuntivo").Value = IIf(IvaPresunt.CheckState, "S", "N")
			.Fields("CL_RetencionPresuntiva").Value = IIf(Check1(0).CheckState, "S", "N")
			.Update()
			.Close()
		End With
		btnnuevo_Click(btnnuevo, New System.EventArgs())
		Exit Sub
HayErrores: 
		ControlaErrores("Grabando ventas")
	End Sub
	
	Private Sub muestra()
		Dim sSQL As String
		'If txtCod = "" Or Val(txtNumSer) = 0 Or Val(TxtSerEmision) = 0 Or Val(txtNumSec) = 0 Then
		'    MsgBox ""
		'''cambiar on error Resume Next
		Sw = True
		If DocClave > 0 Then
			sSQL = "select * From  VENTAS WHere clave = " & DocClave
		Else
			sSQL = "select * From  VENTAS WHere Cl_CodigoCliente = '" & txtPro.Text & "' AND Cl_TipoComprobante = '" & TipoComprobante.BoundText & "'"
		End If
		RsSRI = New ADODB.Recordset
		RsSRI.Open(sSQL, ConxSri, ADOR.CursorTypeEnum.adOpenKeyset, ADOR.LockTypeEnum.adLockOptimistic)
		If RsSRI.EOF Then esnuevo = True : Exit Sub
		If RsSRI.State = 0 Then esnuevo = True : Exit Sub
		With RsSRI
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtPro.Text = CorrijeNulo(.Fields("CL_CodigoCliente"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Iden = CorrijeNulo(.Fields("CL_TipoId"))
			'txtNumSer = CorrijeNulo(!CL_NroSerieEstablec)
			'TxtSerEmision = CorrijeNulo(!CL_NroSeriePtoEmision)
			'txtNumSec = CorrijeNulo(!CL_NroSecuencial)
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TipoComprobante.BoundText = CorrijeNulo(.Fields("Cl_TipoComprobante"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtFecRegCont.Text = CorrijeNulo(.Fields("CL_FechaRegContable"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtFecEmiCom.Text = CorrijeNulo(.Fields("CL_FechaComprobante"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtBasImpTar0.Text = CorrijeNulo(.Fields("CL_BaseImpTarCero"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtBasImpGra.Text = CorrijeNulo(.Fields("CL_BaseImpGravadaIva"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dcPorIva.BoundText = CorrijeNulo(.Fields("CL_CodigoPorIva"))
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
			CodRetFteImpRent(0).BoundText = CorrijeNulo(.Fields("CL_CodRetFteImpRenta1"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(RsSRI!CL_BaseImponibleIR1). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtBasImpIR(0).Text = CorrijeNulo(.Fields("CL_BaseImponibleIR1"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(RsSRI!CL_CodPorcRetIR1). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtPorcRetIR(0).Text = CorrijeNulo(.Fields("CL_CodPorcRetIR1"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(RsSRI!CL_MontoRetIR1). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtMonRetRen(0).Text = CorrijeNulo(.Fields("CL_MontoRetIR1"))
			
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CodRetFteImpRent(1).BoundText = CorrijeNulo(.Fields("CL_CodRetFteImpRenta2"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(RsSRI!CL_BaseImponibleIR2). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtBasImpIR(1).Text = CorrijeNulo(.Fields("CL_BaseImponibleIR2"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(RsSRI!CL_CodPorcRetIR2). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtPorcRetIR(1).Text = CorrijeNulo(.Fields("CL_CodPorcRetIR2"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(RsSRI!CL_MontoRetIR2). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtMonRetRen(1).Text = CorrijeNulo(.Fields("CL_MontoRetIR2"))
			
			CantCpbtes.Text = CStr(CorrijeNuloN(.Fields("CL_NroDeComprobantes")))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			IvaPresunt.CheckState = IIf(CorrijeNulo(.Fields("CL_IvaPresuntivo")) = "S", True, False)
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(RsSRI!CL_RetencionPresuntiva). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Check1(0).CheckState = IIf(CorrijeNulo(.Fields("CL_RetencionPresuntiva")) = "S", True, False)
			'Check1(0) = IIf(CorrijeNulo(!CL_RetencionPresuntiva2) = "S", True, False)
			NumClave = .Fields("Clave").Value
			fprincipal.Enabled = False
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
			sSQL = "DELETE * From  COMPRAS WHere  clave= " & NumClave
			ConxSri.Execute(sSQL)
			btnnuevo_Click(btnnuevo, New System.EventArgs())
		End If
	End Sub
	Private Sub EliminaParaRegrabar()
		'Dim sieli As Byte, Ssql As String
		'''cambiar on error Resume Next
		'If RsSRI.State = 1 Then RsSRI.Close
		'Ssql = "DELETE * From  COMPRAS WHere  CL_CodigoProveedor = '" & txtPro & "' and CL_NroSerieEstablec = '" & txtNumSer & "' and CL_NroSeriePtoEmision = '" & TxtSerEmision & "' and CL_NroSecuencial = '" & txtNumSec & "' "
		'ConxSri.Execute Ssql
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
		Dim Index As Short = TxtBasImpIR.GetIndex(eventSender)
		CalcularMontoRenta(Index)
	End Sub
	
	Private Sub TxtBasImpIR_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TxtBasImpIR.Enter
		Dim Index As Short = TxtBasImpIR.GetIndex(eventSender)
		PonerSel(TxtBasImpIR(Index))
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
	
	Private Sub txtFecEmiCom_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtFecEmiCom.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = IngresaSoloFechas(KeyAscii, txtFecEmiCom)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'UPGRADE_WARNING: El evento txtFecRegCont.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtFecRegCont_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFecRegCont.TextChanged
		' verificar parametros que tienen que ver con esta fecha
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
		Dim Variable As String
		'Variable = txtFecRegCont
		KeyAscii = IngresaSoloFechas(KeyAscii, txtFecRegCont)
		'txtFecRegCont = Variable
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
	
	Private Sub txtNumSec_KeyDown(ByRef keycode As Short, ByRef Shift As Short)
		If keycode = System.Windows.Forms.Keys.Return Then
			muestra()
			'If esnuevo Then BuscaAutorizacionSri: txtAutCom.SetFocus
		End If
	End Sub
	
	Private Sub txtNumSec_KeyPress(ByRef KeyAscii As Short)
		KeyAscii = IngresaSoloNumero(KeyAscii)
	End Sub
	
	'Private Sub txtNumSer_Change()
	'If Len(txtNumSer) = 3 Then TxtSerEmision.SetFocus
	'End Sub
	'
	'Private Sub txtNumSer_KeyPress(KeyAscii As Integer)
	'KeyAscii = IngresaSoloNumero(KeyAscii)
	'End Sub
	
	'UPGRADE_WARNING: El evento TxtPorcRetIR.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub TxtPorcRetIR_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TxtPorcRetIR.TextChanged
		Dim Index As Short = TxtPorcRetIR.GetIndex(eventSender)
		CalcularMontoRenta(Index)
	End Sub
	Private Sub CalcularMontoRenta(ByRef Index As Short)
		TxtMonRetRen(Index).Text = VB6.Format(Val(TxtPorcRetIR(Index).Text) * Val(TxtBasImpIR(Index).Text) / 100, FORMATONUM)
	End Sub
	
	Private Sub TxtPorcRetIR_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TxtPorcRetIR.Enter
		Dim Index As Short = TxtPorcRetIR.GetIndex(eventSender)
		PonerSel(TxtPorcRetIR(Index))
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
		CargarTipoDocumento()
	End Sub
	
	Private Sub txtPro_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtPro.KeyDown
		Dim keycode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If keycode = System.Windows.Forms.Keys.Return Then txtCod = txtPro.Text : buscacli()
	End Sub
	
	'Private Sub TxtSerEmision_Change()
	'If Len(TxtSerEmision) = 3 Then txtNumSec.SetFocus
	'End Sub
	'
	'Private Sub TxtSerEmision_KeyPress(KeyAscii As Integer)
	'KeyAscii = IngresaSoloNumero(KeyAscii)
	'End Sub
End Class