Option Strict Off
Option Explicit On
Friend Class ANEEMPLEADOS
	Inherits System.Windows.Forms.Form
	Dim RsSRI As New ADODB.Recordset
	Dim RsTemp As New ADODB.Recordset
	Dim Control As Short
	Dim Sw As Boolean
	Dim esnuevo As Object
	Dim salir As Short
	Dim ImportaExporta As String
	Private Sub limpia()
		Dim dcTipIde As Object
		Dim txtAno As Object
		Dim dcTipSal As Object
		
		'cambiar on error GoTo HayErrores
		'cambiar on error Resume Next
		
		txtValRet.Text = VB6.Format(roundd(CDbl(0), 2), "####,###,##0.00")
		txtIngLiq.Text = VB6.Format(roundd(CDbl(0), 2), "####,###,##0.00")
		txtBasImp.Text = VB6.Format(roundd(CDbl(0), 2), "####,###,##0.00")
		txtApoIes.Text = VB6.Format(roundd(CDbl(0), 2), "####,###,##0.00")
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dcTipSal.Text. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		dcTipSal.Text = ""
		txtPro.Text = ""
		txtCod.Text = ""
		lbNomP.Text = ""
		txtNumRet.Text = CStr(0)
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto txtAno. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		txtAno = Val(VB6.Format(Today, "yyyy"))
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dcTipIde.Text. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		dcTipIde.Text = ""
		Exit Sub
		
HayErrores: 
		ControlaErrores()
		
	End Sub
	
	Private Sub btngrabar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btngrabar.Click
		Grabar()
	End Sub
	
	Private Sub txtAno_LostFocus()
		Dim txtAno As Object
		Dim aa As Short
		'cambiar on error Resume Next
		
		aa = Val(VB6.Format(Today, "yyyy"))
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto txtAno.Text. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Val(txtAno.Text) > aa Or Val(txtAno.Text) < 2000 Then
			MsgBox("El año debe estar comprendido entre   2000 y " & aa & " ", MsgBoxStyle.Information)
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto txtAno. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtAno = ""
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto txtAno.SetFocus. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtAno.SetFocus()
			Exit Sub
		End If
	End Sub
	
	'UPGRADE_WARNING: El evento txtApoIes.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub txtApoIes_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtApoIes.TextChanged
		'cambiar on error Resume Next
		
		If txtApoIes.Text = "" Then Exit Sub
		txtBasImp.Text = VB6.Format(roundd(CDbl(CDbl(txtIngLiq.Text) - CDbl(txtApoIes.Text)), 2), "####,###,##0.00")
	End Sub
	
	Private Sub txtApoIes_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtApoIes.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If (KeyAscii >= 48 And KeyAscii <= 59) Or (KeyAscii = 8) Or (KeyAscii = 46) Or (KeyAscii = 44) Then
			txtApoIes.ReadOnly = False
		Else
			txtApoIes.ReadOnly = True
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtApoIes_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtApoIes.Leave
		'cambiar on error Resume Next
		
		If txtApoIes.Text = "" Then txtApoIes.Text = CStr(0)
		txtApoIes.Text = VB6.Format(roundd(CDbl(txtApoIes.Text), 2), "####,###,##0.00")
	End Sub
	
	Private Sub txtBasImp_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtBasImp.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If (KeyAscii >= 48 And KeyAscii <= 59) Or (KeyAscii = 8) Or (KeyAscii = 46) Or (KeyAscii = 44) Then
			txtBasImp.ReadOnly = False
		Else
			txtBasImp.ReadOnly = True
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtBasImp_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtBasImp.Leave
		If txtBasImp.Text = "" Then txtBasImp.Text = CStr(0)
		txtBasImp.Text = VB6.Format(roundd(CDbl(txtBasImp.Text), 2), "####,###,##0.00")
		
	End Sub
	
	Private Sub txtIngLiq_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtIngLiq.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If (KeyAscii >= 48 And KeyAscii <= 59) Or (KeyAscii = 8) Or (KeyAscii = 46) Or (KeyAscii = 44) Then
			txtIngLiq.ReadOnly = False
		Else
			txtIngLiq.ReadOnly = True
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtIngLiq_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtIngLiq.Leave
		'cambiar on error Resume Next
		
		If txtIngLiq.Text = "" Then txtIngLiq.Text = CStr(0)
		txtIngLiq.Text = VB6.Format(roundd(CDbl(txtIngLiq.Text), 2), "####,###,##0.00")
		
	End Sub
	
	Private Sub txtPro_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtPro.KeyDown
		Dim keycode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If keycode = System.Windows.Forms.Keys.F2 Then
			buscarclientes()
		End If
		If keycode = System.Windows.Forms.Keys.Return Then
			txtCod.Text = ""
			buscacli()
		End If
	End Sub
	Private Sub btPro_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btPro.Click
		buscarclientes()
	End Sub
	Public Sub buscarclientes()
		Dim comprasVentas As Object
		Dim buscaclien As Object
		'cambiar on error Resume Next
		
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto comprasVentas. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If comprasVentas = "C" Then
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto buscaclien.IniBuscaCliOPro. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtPro.Text = buscaclien.IniBuscaCliOPro("E", txtPro)
		Else
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto buscaclien.IniBuscaCliOPro. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtPro.Text = buscaclien.IniBuscaCliOPro("E", txtPro)
		End If
		'UPGRADE_NOTE: El objeto buscaclien no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		buscaclien = Nothing
		buscacli()
	End Sub
	
	Public Sub buscacli()
		'cambiar on error GoTo HayErrores
		'cambiar on error Resume Next
		Dim RsCli As New ADODB.Recordset
		Dim RsVen As New ADODB.Recordset
		Dim cod As String
		If RsCli.State = 1 Then RsCli.Close()
		
		cod = "SELECT * From identificacion  WHERE codigo ='" & txtPro.Text & "'  or cedulaidentidadruc = '" & txtPro.Text & "'  "
		RsCli.Open(cod, ConxAlex, ADOR.CursorTypeEnum.adOpenKeyset, ADOR.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
		txtCod.Text = ""
		txtPro.Text = ""
		lbNomP.Text = ""
		
		With RsCli
			
			If .RecordCount = 0 Then
				If .State = 1 Then .Close()
				Exit Sub
			End If
			
			'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(.Fields("CedulaIdentidadRuc").Value) Then
				txtPro.Text = .Fields("CedulaIdentidadRuc").Value
			End If
			
			lbNomP.Text = Trim(.Fields("apellidos").Value & " " & .Fields("nombres").Value)
			
		End With
		If RsCli.State = 1 Then RsCli.Close()
		
		Exit Sub
		
HayErrores: 
		ControlaErrores()
	End Sub
	Private Sub Command3_Click()
		Dim txtFecEmiCom As Object
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto txtFecEmiCom. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		txtFecEmiCom = QueFecha
	End Sub
	Public Function ChequeaString(ByRef dato As Object, ByRef Longitud As Object) As Object
		Dim i As Object
		Dim Cuantos As Object
		'cambiar on error Resume Next
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Longitud. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Len(dato) < Longitud Then
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Longitud. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Cuantos. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Cuantos = Longitud - Len(dato)
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Longitud. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			For i = 1 To Longitud - Len(dato)
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dato. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				dato = "0" & dato
			Next i
		End If
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dato. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ChequeaString. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ChequeaString = dato
	End Function
	Public Sub INIImportacionExportacion(ByRef QueEsImpExp As String)
		Dim SRIIMPOR As Object
		'I=Importación , E=E´portación
		ImportaExporta = QueEsImpExp
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto SRIIMPOR.Show. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		SRIIMPOR.Show(1)
	End Sub
	
	
	Private Sub ANEEMPLEADOS_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'cambiar on error GoTo HayErrores
		'cambiar on error Resume Next
		Dim cod As String
		CargarFlechas(Me)
		
		
		cod = "SELECT * From RetEmpleados WHere  Em_Empresa =" & Emp.codigo
		
		If RsSRI.State = 1 Then RsSRI.Close()
		RsSRI.CursorType = ADOR.CursorTypeEnum.adOpenKeyset
		RsSRI.LockType = ADOR.LockTypeEnum.adLockOptimistic
		RsSRI.Open(cod, ConxSri,  ,  , ADODB.CommandTypeEnum.adCmdText)
		
		
		fprincipal.Enabled = False
		'/******************
		CargarCombos()
		
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto esnuevo. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		esnuevo = 4
		Sw = True
		existenregistros()
		
		Exit Sub
		
HayErrores: 
		ControlaErrores()
		
	End Sub
	
	Private Sub CargarCombos()
		Dim dcTipSal As Object
		Dim dcTipIde As Object
		Dim StrConxDaxSys As Object
		Dim dtTipIde As Object
		'cambiar on error Resume Next
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dtTipIde.CommandType. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		dtTipIde.CommandType = ADODB.CommandTypeEnum.adCmdText
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dtTipIde.ConnectionString. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto StrConxDaxSys. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		dtTipIde.ConnectionString = StrConxDaxSys
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dtTipIde.RecordSource. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		dtTipIde.RecordSource = "SElect *  From SRITiposIdentificacion Where  idSRITiposIdentificacion <> '1'"
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dtTipIde.Refresh. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		dtTipIde.Refresh()
		
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dtTipIde.Recordset. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If dtTipIde.Recordset.RecordCount > 0 Then
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dcTipIde.BoundText. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dtTipIde.Recordset. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dcTipIde.BoundText = dtTipIde.Recordset!idSRITiposIdentificacion
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dcTipIde.Text. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dtTipIde.Recordset. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dcTipIde.Text = dtTipIde.Recordset!descripcion
		End If
		
		dtTipSal.CommandType = ADODB.CommandTypeEnum.adCmdText
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto StrConxDaxSys. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		dtTipSal.ConnectionString = StrConxDaxSys
		dtTipSal.RecordSource = "Select *  From  sriSistemaSalarioNeto "
		dtTipSal.Refresh()
		
		If dtTipSal.Recordset.RecordCount > 0 Then
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dcTipSal.BoundText. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dcTipSal.BoundText = dtTipSal.Recordset.Fields("idsriSistemaSalarioNeto").Value
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dcTipSal.Text. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dcTipSal.Text = dtTipSal.Recordset.Fields("descripcion").Value
		End If
		
		
		
	End Sub
	Private Sub controla()
		Dim txtniv_nombre As Object
		Dim txtniv_abrevia As Object
		Dim txtniv_categor As Object 'no controla
		'cambiar on error GoTo HayErrores
		'cambiar on error Resume Next
		Control = 0
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto txtniv_categor.Text. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Not IsNumeric(txtniv_categor.Text) Then
			MsgBox("Debe ingresar la categoria del nivel")
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto txtniv_categor.SetFocus. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtniv_categor.SetFocus()
			Control = 1
			Exit Sub
		End If
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto txtniv_abrevia.Text. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If txtniv_abrevia.Text = "" Then
			MsgBox("Debe ingresar la abreviacion del nivel")
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto txtniv_abrevia.SetFocus. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtniv_abrevia.SetFocus()
			Control = 1
			Exit Sub
		End If
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto txtniv_nombre.Text. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If txtniv_nombre.Text = "" Then
			MsgBox("Debe ingresar el nombre")
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto txtniv_nombre.SetFocus. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtniv_nombre.SetFocus()
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto txtniv_nombre.Text. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtniv_nombre.Text = ""
			Control = 1
			Exit Sub
		End If
		
		
		Exit Sub
		
HayErrores: 
		ControlaErrores()
		
		
	End Sub
	
	Private Sub muestra()
		Dim txtAno As Object
		Dim dcTipSal As Object
		Dim dcTipIde As Object
		'cambiar on error GoTo HayErrores
		'cambiar on error Resume Next
		Dim Aux As Object
		If Sw = True Then
			Aux = RsSRI
		Else
			Aux = RsTemp
		End If
		limpia()
		With Aux
			
			
			'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Aux!EM_NOMBRE. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If Not IsDbNull(!EM_NOMBRE) Then lbNomP.Text = !EM_NOMBRE
			'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Aux!EM_RUC. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If Not IsDbNull(!EM_RUC) Then txtPro.Text = !EM_RUC
			'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dcTipIde.BoundText. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Aux!EM_TIPO_IDENT. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If Not IsDbNull(!EM_TIPO_IDENT) Then dcTipIde.BoundText = !EM_TIPO_IDENT
			'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dcTipSal.BoundText. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Aux!EM_SALARIO. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If Not IsDbNull(!EM_SALARIO) Then dcTipSal.BoundText = !EM_SALARIO
			'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Aux!EM_ANO. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto txtAno. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If Not IsDbNull(!EM_ANO) Then txtAno = !EM_ANO
			'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Aux!EM_INGRESOS. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If Not IsDbNull(!EM_INGRESOS) Then txtIngLiq.Text = !EM_INGRESOS
			'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Aux!EM_APO_IESS. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If Not IsDbNull(!EM_APO_IESS) Then txtApoIes.Text = !EM_APO_IESS
			'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Aux!EM_BAS_IMP. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If Not IsDbNull(!EM_BAS_IMP) Then txtBasImp.Text = !EM_BAS_IMP
			'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Aux!EM_VAL_RET. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If Not IsDbNull(!EM_VAL_RET) Then txtValRet.Text = !EM_VAL_RET
			'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Aux!EM_NUM_RET. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If Not IsDbNull(!EM_NUM_RET) Then txtNumRet.Text = !EM_NUM_RET
			
			
		End With
		
		Exit Sub
		
HayErrores: 
		ControlaErrores()
		
	End Sub
	
	Private Sub btAnterior_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btAnterior.Click
		'cambiar on error GoTo HayErrores
		'cambiar on error Resume Next
		
		With RsSRI
			If .RecordCount > 0 Then
				.MovePrevious()
				If .BOF Then
					.MoveLast()
				End If
				muestra()
			End If
		End With
		
		
		Exit Sub
HayErrores: 
		ControlaErrores()
		
	End Sub
	
	
	Private Sub btnbuscar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnbuscar.Click
		'cambiar on error GoTo HayErrores
		'cambiar on error Resume Next
		
		limpia()
		fprincipal.Enabled = True
		f3.Visible = False
		f1.Visible = False
		F2.Visible = False
		f5.Visible = True
		
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto esnuevo. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		esnuevo = 3
		
		
		Exit Sub
HayErrores: 
		ControlaErrores()
		
	End Sub
	
	Private Sub btncancelarbusca_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btncancelarbusca.Click
		'cambiar on error GoTo HayErrores
		'cambiar on error Resume Next
		existenregistros()
		fprincipal.Enabled = False
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto esnuevo. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		esnuevo = 4
		Exit Sub
HayErrores: 
		ControlaErrores()
		
		
	End Sub
	
	Private Sub btneliminar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btneliminar.Click
		Dim sieli As Object
		'cambiar on error GoTo HayErrores
		'cambiar on error Resume Next
		
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto sieli. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		sieli = MsgBox("Esta seguro que desea eliminar el registro activo", 36)
		If sieli = MsgBoxResult.Yes Then
			'     Cod = "DELETE FROM pdvArt WHERE Art_artcodi='" & txtart_codigo & "' "
			'     ConxPuntto.Execute (Cod)
			RsSRI.Delete(ADOR.AffectEnum.adAffectCurrent)
			RsSRI.Requery()
			fprincipal.Enabled = True
			limpia()
			fprincipal.Enabled = False
			existenregistros()
		End If
		
		
		
		
		Exit Sub
HayErrores: 
		ControlaErrores()
		
	End Sub
	
	Private Sub btinicio_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btinicio.Click
		'cambiar on error GoTo HayErrores
		'cambiar on error Resume Next
		If RsSRI.RecordCount <> 0 Then
			RsSRI.MoveFirst()
			muestra()
		End If
		
		
		Exit Sub
HayErrores: 
		ControlaErrores()
		
	End Sub
	
	Private Sub btnmodificar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnmodificar.Click
		
		'cambiar on error GoTo HayErrores
		'cambiar on error Resume Next
		fprincipal.Enabled = True
		
		F2.Visible = True
		f1.Visible = False
		f3.Visible = False
		
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto esnuevo. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		esnuevo = 0
		
		
		Exit Sub
HayErrores: 
		ControlaErrores()
		
	End Sub
	
	Private Sub btnnuevo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnnuevo.Click
		'cambiar on error GoTo HayErrores
		'cambiar on error Resume Next
		
		fprincipal.Enabled = True
		limpia()
		
		F2.Visible = True
		f1.Visible = False
		f3.Visible = False
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto esnuevo. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		esnuevo = 1
		
		
		Exit Sub
HayErrores: 
		ControlaErrores()
	End Sub
	
	Private Sub btSiguiente_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btSiguiente.Click
		'cambiar on error GoTo HayErrores
		With RsSRI
			If .RecordCount > 0 Then
				.MoveNext()
				If .EOF Then
					.MoveFirst()
				End If
				muestra()
			End If
		End With
		Exit Sub
HayErrores: 
		ControlaErrores()
	End Sub
	
	
	Private Sub btUltimo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btUltimo.Click
		'cambiar on error GoTo HayErrores
		
		If RsSRI.RecordCount <> 0 Then
			RsSRI.MoveLast()
			muestra()
		End If
		
		
		Exit Sub
HayErrores: 
		ControlaErrores()
	End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		'cambiar on error GoTo HayErrores
		
		'lo mismo que btnnuevo
		
		fprincipal.Enabled = True
		limpia()
		f1.Visible = False
		F2.Visible = True
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto esnuevo. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		esnuevo = 1
		
		Exit Sub
HayErrores: 
		ControlaErrores()
	End Sub
	
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		Dim SRICOMP As Object
		'lo mismo que btnsalir
		salir = 1
		Me.Close()
		'UPGRADE_NOTE: El objeto SRICOMP no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		SRICOMP = Nothing
	End Sub
	Private Sub btncancelar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btncancelar.Click
		Dim sicanc As Object
		''cambiar on error   GoTo HayErrores
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto sicanc. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		sicanc = MsgBox("Esta seguro que desea cancelar ,se perdera toda la información", 36)
		If sicanc = MsgBoxResult.Yes Then
			limpia()
			fprincipal.Enabled = False
			existenregistros()
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto esnuevo. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			esnuevo = 4
		End If
		
		Exit Sub
HayErrores: 
		ControlaErrores()
		
	End Sub
	
	Private Sub btnsalir_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnsalir.Click
		Dim PDVI02 As Object
		salir = 1
		Me.Close()
		'UPGRADE_NOTE: El objeto PDVI02 no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		PDVI02 = Nothing
		
	End Sub
	
	Public Sub existenregistros()
		'cambiar on error Resume Next
		If RsSRI.RecordCount > 0 Then
			RsSRI.MoveFirst()
			muestra()
			f3.Visible = True
			f1.Visible = False
			F2.Visible = False
			f5.Visible = False
		Else
			f1.Visible = True
			F2.Visible = False
			f3.Visible = False
			f5.Visible = False
		End If
		
		
		Exit Sub
		
HayErrores: 
		ControlaErrores()
	End Sub
	Private Sub ANEEMPLEADOS_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		If RsSRI.State = 1 Then RsSRI.Close()
		salirform(Me)
	End Sub
	'Public Sub buscaarticulo()
	''cambiar on error GoTo HayErrores
	''cambiar on error Resume Next
	'   With RsTemp
	'            .CursorType = adOpenKeyset
	'            .LockType = adLockOptimistic
	'            .Open "SELECT * From TransaccionesLocales  where ART_ARTCODI = '" & txtart_codigo & "' ", ConxSri, , , adCmdText
	'            If .RecordCount = 0 Then Sw = True: .Close: Exit Sub
	'            Sw = False
	'            muestra
	'            .Close
	'            f3.Visible = True
	'            f5.Visible = False
	'            fprincipal.Enabled = False
	'            Sw = True
	'  End With
	'
	' Exit Sub
	'
	'HayErrores:
	'  ControlaErrores
	'
	'End Sub
	
	'Public Sub BuscarArticulos()
	'AuxAlf1 = "T"
	'  AuxAlf3 = txtart_codigo.Text
	'  BuscArti.Show vbModal
	'  txtart_codigo.Text = AuxAlf1
	'  buscaarticulo
	'End Sub
	Private Sub txtFecEmiCom_LostFocus()
		Dim dd As Object
		Dim txtFecEmiCom As Object
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto txtFecEmiCom.Text. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dd. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		dd = VB6.Format(txtFecEmiCom.Text, "dd/mm/yyyy")
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto txtFecEmiCom.Text. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dd. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		txtFecEmiCom.Text = dd
	End Sub
	
	Public Sub Grabar()
		Dim txtAno As Object
		Dim dcTipSal As Object
		Dim dcTipIde As Object
		'cambiar on error GoTo HayErrores
		
		'cambiar on error Resume Next
		
		
		If txtPro.Text = "" Then MsgBox("Ingrese el RUC/CI del Empleado ", MsgBoxStyle.Information) : txtPro.Focus() : Exit Sub
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dcTipIde.Text. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If dcTipIde.Text = "" Then
			MsgBox("Seleccione el Tipo de Identificación ", MsgBoxStyle.Information)
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dcTipIde.SetFocus. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dcTipIde.SetFocus() : Exit Sub
		End If
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dcTipSal.Text. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If dcTipSal.Text = "" Then
			MsgBox("Seleccione el Tipo de Identificación ", MsgBoxStyle.Information)
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dcTipSal.SetFocus. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dcTipSal.SetFocus() : Exit Sub
		End If
		
		With RsSRI
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto esnuevo. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If esnuevo = 1 Then
				.AddNew()
				
			End If
			
			.Fields("Em_Empresa").Value = Emp.codigo
			
			If lbNomP.Text <> "" Then .Fields("EM_NOMBRE").Value = lbNomP.Text
			If txtPro.Text <> "" Then .Fields("EM_RUC").Value = txtPro.Text
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dcTipIde.BoundText. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If dcTipIde.BoundText <> "" Then .Fields("EM_TIPO_IDENT").Value = dcTipIde.BoundText
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dcTipSal.BoundText. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If dcTipSal.BoundText <> "" Then .Fields("EM_SALARIO").Value = dcTipSal.BoundText
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto txtAno. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If txtAno <> "" Then .Fields("EM_ANO").Value = txtAno
			If txtIngLiq.Text <> "" Then .Fields("EM_INGRESOS").Value = txtIngLiq.Text
			If txtApoIes.Text <> "" Then .Fields("EM_APO_IESS").Value = txtApoIes.Text
			If txtBasImp.Text <> "" Then .Fields("EM_BAS_IMP").Value = txtBasImp.Text
			If txtValRet.Text <> "" Then .Fields("EM_VAL_RET").Value = txtValRet.Text
			If txtNumRet.Text <> "" Then .Fields("EM_NUM_RET").Value = txtNumRet.Text
			
			
			
			.Update()
			.Requery()
		End With
		F2.Visible = False
		f3.Visible = True
		
		fprincipal.Enabled = False
		
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto esnuevo. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		esnuevo = 4
		Exit Sub
		
HayErrores: 
		ControlaErrores()
		
	End Sub
	
	Private Sub txtValRet_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtValRet.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If (KeyAscii >= 48 And KeyAscii <= 59) Or (KeyAscii = 8) Or (KeyAscii = 46) Or (KeyAscii = 44) Then
			txtValRet.ReadOnly = False
		Else
			txtValRet.ReadOnly = True
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtValRet_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtValRet.Leave
		If txtValRet.Text = "" Then txtValRet.Text = CStr(0)
		txtValRet.Text = VB6.Format(roundd(CDbl(txtValRet.Text), 2), "####,###,##0.00")
	End Sub
End Class