Option Strict Off
Option Explicit On
Friend Class SRIEXPORTA
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
	Const FORMATONUM As String = "###,###,##0.00"
	Dim SeqTran(25) As String
	Dim Documentos As String
	Dim NSeqTran As Short
	Dim opAlex As ManDirct.Directorio
	Public IdClaveDoc As Double
	Public Fila As Integer
	Public PasaMalla As AxMSHierarchicalFlexGridLib.AxMSHFlexGrid
	Dim MODIFICADO As Boolean
	Private Sub BtEmision_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles BtEmision.Click
		txtFecLiquidacion.Text = CStr(QueFecha)
	End Sub
	
	Private Sub btncancelar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btncancelar.Click
		If ConfirmaCancelar Then btnnuevo_Click(btnnuevo, New System.EventArgs())
	End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		txtFecEmiCom.Text = CStr(QueFecha)
	End Sub
	
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		Me.Close()
	End Sub
	
	Private Sub DatSustento_Change()
		If IsDate(txtFecLiquidacion.Text) Then
			CargarTipoDocumento()
		End If
	End Sub
	
	Private Sub txtAutCom_KeyPress(ByRef KeyAscii As Short)
		KeyAscii = IngresaSoloNumero(KeyAscii)
	End Sub
	
	Private Sub TxtAutorizaMod_KeyPress(ByRef KeyAscii As Short)
		KeyAscii = IngresaSoloNumero(KeyAscii)
	End Sub
	
	'UPGRADE_WARNING: El evento TxtAnio.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub TxtAnio_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TxtAnio.TextChanged
		'cambiar on error Resume Next
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
	End Sub
	
	'Private Sub btPro_Click()
	'buscarclientes
	'End Sub
	'
	'Private Sub buscarclientes()
	'''cambiar on error Resume Next
	'    txtCod = BuscaClien.IniBuscaCliOPro("P", txtCod)
	'    Set BuscaClien = Nothing
	'    buscacli
	'End Sub
	'
	'Private Sub buscacli()
	'Set opAlex = New Directorio
	'''cambiar on error Resume Next
	'If opAlex.CargarAlex(txtCod, False, "S") = False Then
	'    txtCod = ""
	'    txtPro = ""
	'    Iden = ""
	'    MsgBox "No existe el proveedor registrado"
	'    txtPro.SetFocus
	'Else
	'    txtCod = opAlex.codigo
	''    lbNomP = opAlex.NombreImpresion
	'    txtPro = opAlex.CiRuc
	'    Iden = opAlex.TipoId
	'End If
	'End Sub
	'
	Private Sub SRIEXPORTA_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		''cambiar on error Resume Next
		Dim cod As String
		centrarforma(Me)
		titulo(Me)
		CargarTransacciones()
		CargarTipoDocumento()
		If IdClaveDoc > 0 Then muestra() Else btnnuevo_Click(btnnuevo, New System.EventArgs())
	End Sub
	
	Private Sub CargarTransacciones()
		Dim claves As String
		Dim rs As New ADODB.Recordset
		Dim i As Short
		For i = 0 To 25
			SeqTran(i) = ""
		Next i
		rs.Open("Select * from SriSecuencialesTransacciones where CodigoTipoTransaccion = 4", ConxSyscod, ADOR.CursorTypeEnum.adOpenKeyset, ADOR.LockTypeEnum.adLockOptimistic)
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
		'claves = DatSustento.BoundText
		'If claves = "" Then Exit Sub
		'dtCodSus.Recordset.MoveFirst
		'dtCodSus.Recordset.Find "codigo=" & claves
		'claves = SepararClaves(dtCodSus.Recordset!CodigoTipoComprobante, "codigo")
		With dtCom
			.CommandType = ADODB.CommandTypeEnum.adCmdText
			.ConnectionString = StrConxsysemp
			.RecordSource = "Select * From sritipodecomprobante Where (CodigoSecuencialTransaccion LIKE '%09%' )  order by codigo "
			.Refresh()
			If .Recordset.RecordCount > 0 Then
				.Recordset.MoveFirst()
				TipoComprobante.BoundText = .Recordset.Fields("codigo").Value
			End If
		End With
		
		'With DtTipoCliente
		'.CommandType = adCmdText
		'.ConnectionString = StrConxsysemp
		'.RecordSource = "Select *  From SriTipoSujetoImportExport "
		'.Refresh
		'If .Recordset.RecordCount > 0 Then
		'   .Recordset.MoveFirst
		'   DcTipoCliente.BoundText = .Recordset!tiposujeto
		'End If
		'End With
		
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
	
	Private Sub SRIEXPORTA_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		If MODIFICADO Then
			'UPGRADE_ISSUE: No se actualizó el parámetro Event Cancel. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="FB723E3C-1C06-4D2B-B083-E6CD0D334DA8"'
			If ConfirmaSalir = False Then Cancel = 1
			If RsSRI.State = 1 Then RsSRI.Close()
		End If
	End Sub
	
	Private Sub btngrabar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btngrabar.Click
		Dim sSQL As String
		'If txtPro = "" Or Val(txtNumSer) = 0 Or Val(TxtSerEstablec) = 0 Or Val(txtNumSec) = 0 Then
		'    MsgBox "No se puede grabar este registro, No tiene los datos suficientes", vbCritical
		'    Exit Sub
		'End If
		'''cambiar on error GoTo HayErrores
		'ConxSri.Execute "delete from exportacion where clave = " & IdClaveDoc
		If IdClaveDoc = 0 Then
			sSQL = "select * From  exportacion WHere  CL_ReferendoDistrito = '" & TxtDistritoAd.Text & "' and CL_ReferendoAño = '" & TxtAnio.Text & "' and CL_ReferendoRegimen = '" & TxtRegimen.Text & "' and CL_ReferendoCorrelativo = '" & TxtCorrelativo.Text & "' and CL_ReferendoVerificador = '" & TxtVerificador.Text & "'" & " and CL_NroSerieCpbteEstablec = '" & txtNumSer.Text & "' and  CL_NroSerieCpbteEmision = '" & TxtSerEstablec.Text & "' and  CL_NroSecuencialCpbte = '" & txtNumSec.Text & "'"
			RsSRI = New ADODB.Recordset
		Else
			sSQL = "select * From  exportacion WHere clave = " & IdClaveDoc
		End If
		RsSRI = New ADODB.Recordset
		With RsSRI
			.Open(sSQL, ConxSri, ADOR.CursorTypeEnum.adOpenKeyset, ADOR.LockTypeEnum.adLockOptimistic)
			If .EOF Then .AddNew()
			.Fields("CL_ExportaciónDe").Value = IIf(ConRefrendo.CheckState = 0, 2, 1)
			.Fields("Cl_TipoComprobante").Value = TipoComprobante.BoundText
			.Fields("CL_ReferendoDistrito").Value = TxtDistritoAd.Text
			.Fields("CL_ReferendoAño").Value = TxtAnio.Text
			.Fields("CL_ReferendoRegimen").Value = TxtRegimen.Text
			.Fields("CL_ReferendoCorrelativo").Value = TxtCorrelativo.Text
			.Fields("CL_ReferendoVerificador").Value = TxtVerificador.Text
			.Fields("CL_NroDocTransporte").Value = TxtNroTransporte.Text
			.Fields("CL_FechaTransaccion").Value = CorrijeNuloF(txtFecLiquidacion)
			.Fields("CL_NroFue").Value = TxtFue.Text
			.Fields("CL_ValorFOB").Value = TxtValCif.Text
			.Fields("CL_ValorComprobante").Value = ValorDocumento.Text
			.Fields("CL_NroSerieCpbteEstablec").Value = txtNumSer.Text
			.Fields("CL_NroSerieCpbteEmision").Value = TxtSerEstablec.Text
			.Fields("CL_NroSecuencialCpbte").Value = txtNumSec.Text
			.Fields("CL_NroAutorizacion").Value = NroAutorización.Text
			.Fields("CL_FechaEmision").Value = CorrijeNuloF(txtFecEmiCom)
			.Fields("mes").Value = PerMes
			.Fields("Anio").Value = PerAnio
			.Update()
			If IdClaveDoc = 0 Then IdClaveDoc = .Fields("Clave").Value
			.Close()
			PonerEnMalla()
		End With
		Me.Close()
		Exit Sub
HayErrores: 
		ControlaErrores("Grabando Compras")
	End Sub
	
	Private Sub PonerEnMalla()
		If Fila = 0 Then Fila = Malla.Rows : Malla.Rows = Malla.Rows + 1
		'Set Malla = PasaMalla
		With PasaMalla
			.set_TextMatrix(Fila, 1, IIf(ConRefrendo.CheckState = 0, 2, 1))
			.set_TextMatrix(Fila, 2, TipoComprobante.BoundText)
			.set_TextMatrix(Fila, 3, TxtDistritoAd.Text)
			.set_TextMatrix(Fila, 4, TxtAnio.Text)
			.set_TextMatrix(Fila, 5, TxtRegimen.Text)
			.set_TextMatrix(Fila, 6, TxtCorrelativo.Text)
			.set_TextMatrix(Fila, 7, TxtVerificador.Text)
			.set_TextMatrix(Fila, 8, TxtNroTransporte.Text)
			.set_TextMatrix(Fila, 9, txtFecLiquidacion.Text)
			.set_TextMatrix(Fila, 10, TxtFue.Text)
			.set_TextMatrix(Fila, 11, TxtValCif.Text)
			.set_TextMatrix(Fila, 12, ValorDocumento.Text)
			.set_TextMatrix(Fila, 13, txtNumSer.Text)
			.set_TextMatrix(Fila, 14, TxtSerEstablec.Text)
			.set_TextMatrix(Fila, 15, txtNumSec.Text)
			.set_TextMatrix(Fila, 16, NroAutorización.Text)
			.set_TextMatrix(Fila, 17, txtFecEmiCom.Text)
			.set_TextMatrix(Fila, .get_Cols() - 1, IdClaveDoc)
		End With
	End Sub
	Private Sub muestra()
		Dim sSQL As String
		'If txtCod = "" Or Val(txtNumSer) = 0 Or Val(TxtSerEstablec) = 0 Or Val(txtNumSec) = 0 Then
		'    MsgBox ""
		'''cambiar on error Resume Next
		Sw = True
		sSQL = "select * From  exportacion WHere  CLave = " & IdClaveDoc
		RsSRI = New ADODB.Recordset
		RsSRI.Open(sSQL, ConxSri, ADOR.CursorTypeEnum.adOpenKeyset, ADOR.LockTypeEnum.adLockOptimistic)
		If RsSRI.State = 0 Then esnuevo = True : Exit Sub
		If RsSRI.EOF Then esnuevo = True : Exit Sub
		With RsSRI
			ConRefrendo.CheckState = CorrijeNuloN(Mid(.Fields("CL_ExportaciónDe").Value, 1, 1))
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
			TxtNroTransporte.Text = CStr(CorrijeNuloN(.Fields("CL_NroDocTransporte")))
			txtFecLiquidacion.Text = CStr(CorrijeNuloF(.Fields("CL_FechaTransaccion")))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtFue.Text = CorrijeNulo(.Fields("CL_NroFue"))
			TxtValCif.Text = CStr(CorrijeNuloN(.Fields("CL_ValorFOB")))
			ValorDocumento.Text = CStr(CorrijeNuloN(.Fields("CL_ValorComprobante")))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtNumSer.Text = CorrijeNulo(.Fields("CL_NroSerieCpbteEstablec"))
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TxtSerEstablec.Text = CorrijeNulo(.Fields("CL_NroSerieCpbteEmision"))
			txtNumSec.Text = CStr(CorrijeNuloN(.Fields("CL_NroSecuencialCpbte")))
			NroAutorización.Text = CStr(CorrijeNuloN(.Fields("CL_NroAutorizacion")))
			txtFecEmiCom.Text = CStr(CorrijeNuloF(.Fields("CL_FechaEmision")))
			f3.Visible = False
			F2.Visible = True
			esnuevo = False
		End With
	End Sub
	
	'Private Sub btneliminar_Click()
	'Dim sieli As Byte, sSQL As String
	'''cambiar on error Resume Next
	'sieli = ConfirmaEliminar
	'If sieli = vbYes Then
	'   sSQL = "DELETE * From  importacion WHere  CL_CodigoProveedor = '" & txtPro & "' and CL_ReferendoDistrito = '" & TxtDistritoAd & "' and CL_ReferendoAño = '" & TxtAnio & "' and CL_ReferendoRegimen = '" & TxtRegimen & "' and CL_ReferendoCorrelativo = '" & TxtCorrelativo & "' and CL_ReferendoVerificador = '" & TxtVerificador & "'"
	'   ConxSri.Execute sSQL
	'   btnnuevo_Click
	'End If
	'End Sub
	'Private Sub EliminaParaRegrabar()
	'Dim sieli As Byte, sSQL As String
	'''cambiar on error Resume Next
	'If RsSRI.State = 1 Then RsSRI.Close
	'sSQL = "DELETE * From  importacion WHere  CL_CodigoProveedor = '" & txtPro & "' and CL_ReferendoDistrito = '" & TxtDistritoAd & "' and CL_ReferendoAño = '" & TxtAnio & "' and CL_ReferendoRegimen = '" & TxtRegimen & "' and CL_ReferendoCorrelativo = '" & TxtCorrelativo & "' and CL_ReferendoVerificador = '" & TxtVerificador & "'"
	'ConxSri.Execute sSQL
	'End Sub
	
	Private Sub txtAutCom_KeyDown(ByRef keycode As Short, ByRef Shift As Short)
		'If KeyCode = vbKeyF2 Then BuscarAutorización
	End Sub
	
	'UPGRADE_WARNING: El evento TxtCorrelativo.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub TxtCorrelativo_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TxtCorrelativo.TextChanged
		'cambiar on error Resume Next
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
		'If Len(TxtDistritoAd) = 3 Then TxtAnio.SetFocus
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
	
	Private Sub TxtNroAutorizaIR_KeyPress(ByRef KeyAscii As Short)
		KeyAscii = IngresaSoloNumero(KeyAscii)
	End Sub
	
	Private Sub TxtNumeroSecuencialMod_KeyPress(ByRef KeyAscii As Short)
		KeyAscii = IngresaSoloNumero(KeyAscii)
	End Sub
	
	'Private Sub txtNumSec_KeyDown(KeyCode As Integer, Shift As Integer)
	'If KeyCode = vbKeyReturn Then
	'    muestra
	'  '  If esnuevo Then BuscaAutorizacionSri: txtAutCom.SetFocus
	'End If
	'End Sub
	
	Private Sub txtNumSec_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtNumSec.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = IngresaSoloNumero(KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtNumSer_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtNumSer.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = IngresaSoloNumero(KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'Private Sub txtPro_KeyDown(KeyCode As Integer, Shift As Integer)
	'If KeyCode = vbKeyReturn Then txtCod = txtPro: buscacli
	'End Sub
	
	Private Sub TxtSecuencialIR_KeyPress(ByRef KeyAscii As Short)
		KeyAscii = IngresaSoloNumero(KeyAscii)
	End Sub
	
	Private Sub TxtSerEstablec_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TxtSerEstablec.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		KeyAscii = IngresaSoloNumero(KeyAscii)
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
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
		'cambiar on error Resume Next
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
		'cambiar on error Resume Next
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