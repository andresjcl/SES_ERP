Option Strict Off
Option Explicit On
Module DelUsuario
	Public Function AutorizarIngreso(ByRef NombreOpcion As String, Optional ByRef CodUsu As String = "", Optional ByRef codemp As Short = 0) As String
		Dim auxiliar As String
		Dim RecClv As New ADODB.Recordset
		On Error Resume Next
		'UPGRADE_NOTE: IsMissing() ha cambiado a IsNothing(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"'
		If IsNothing(CodUsu) Or CodUsu = "" Then CodUsu = ControlUsuario.Identifica
		'UPGRADE_NOTE: IsMissing() ha cambiado a IsNothing(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"'
		If IsNothing(codemp) Or codemp = 0 Then codemp = ControlUsuario.empresa
		If UCase(CodUsu) = "ADMINISTRADOR" Or UCase(ControlUsuario.Identifica) = "CONTROL" Then AutorizarIngreso = "T" : Exit Function
		auxiliar = "SELECT * FROM sys_Accesos WHERE IdUsuario = '" & CodUsu & "'" & " AND IdEmpresa = " & codemp & " AND Idopcion = '" & NombreOpcion & "'"
		AutorizarIngreso = ""
		RecClv = New ADODB.Recordset
		RecClv.Open(auxiliar, ConxSysemp, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly, ADODB.CommandTypeEnum.adCmdText)
		With RecClv
			If .EOF = True Then
				.Close()
				'UPGRADE_NOTE: El objeto RecClv no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
				RecClv = Nothing : Exit Function
			End If
			.MoveFirst()
			'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			If Not IsDbNull(.Fields("Accesos").Value) Then AutorizarIngreso = .Fields("Accesos").Value Else AutorizarIngreso = ""
			.Close()
		End With
		'UPGRADE_NOTE: El objeto RecClv no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		RecClv = Nothing
	End Function
	
	Public Sub GuardarUsuSuc(ByRef IdUsu As String, ByRef codemp As Short, ByRef codSuc As String, Optional ByRef Aut As String = "")
		Dim cod As String
		On Error Resume Next
		Dim recuser As New ADODB.Recordset
		'If recuser.State = 1 Then recuser.Close
		cod = "SELECT * FROM sys_Sucursales WHERE IdUsuario='" & IdUsu & "' AND IdEmpresa=" & codemp
		recuser.Open(cod, ConxSysemp, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
		With recuser
			.AddNew()
			.Fields("idusuario").Value = Trim(IdUsu)
			.Fields("idempresa").Value = codemp
			.Fields("CODSUCURSAL").Value = Trim(codSuc)
			'UPGRADE_NOTE: IsMissing() ha cambiado a IsNothing(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"'
			If Not IsNothing(Aut) Then .Fields("AutorizaSuc").Value = Trim(Aut)
			.Update()
			.Close()
		End With
	End Sub
	
	Public Sub GuardarUsuBod(ByRef IdUsu As String, ByRef codemp As Short, ByRef codSuc As String, ByRef codBod As String, Optional ByRef Aut As String = "")
		Dim cod As String
		Dim recuser As New ADODB.Recordset
		On Error Resume Next
		cod = "SELECT * FROM sys_Bodegas WHERE IdUsuario='" & IdUsu & "' AND CodBodega='" & codBod & "' AND CodSucursal='" & codSuc & "' AND IdEmpresa=" & codemp
		recuser.Open(cod, ConxSysemp, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
		With recuser
			If .RecordCount = 0 Then .AddNew()
			.Fields("idusuario").Value = Trim(IdUsu)
			.Fields("idempresa").Value = codemp
			.Fields("CODSUCURSAL").Value = Trim(codSuc)
			.Fields("CODbodega").Value = Trim(codBod)
			'UPGRADE_NOTE: IsMissing() ha cambiado a IsNothing(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"'
			If Not IsNothing(Aut) Then .Fields("Autorizabod").Value = Trim(Aut)
			.Update()
			.Close()
		End With
	End Sub
	
	Public Sub GuardarUsuDoc(ByRef IdUsu As String, ByRef codemp As Short, ByRef codDoc As String, Optional ByRef Cam As String = "")
		Dim cod As String
		Dim recuser As New ADODB.Recordset
		' aqui reemplazo *****************************
		cod = "SELECT * FROM sys_Documentos WHERE IdUsuario='" & IdUsu & "' AND CodDocumento='" & codDoc & "' AND IdEmpresa=" & codemp
		recuser.Open(cod, ConxSysemp, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
		With recuser
			If .RecordCount = 0 Then .AddNew()
			.Fields("idusuario").Value = Trim(IdUsu)
			.Fields("idempresa").Value = codemp
			.Fields("CodDocumento").Value = Trim(codDoc)
			'UPGRADE_NOTE: IsMissing() ha cambiado a IsNothing(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"'
			If Not IsNothing(Cam) Then .Fields("Cambios").Value = Trim(Cam)
			.Update()
			.Close()
		End With
	End Sub
End Module