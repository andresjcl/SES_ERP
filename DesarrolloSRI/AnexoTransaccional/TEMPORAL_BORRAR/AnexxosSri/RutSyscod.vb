Option Strict Off
Option Explicit On
Module RutSyscod
	Public Function NombreSyscod(ByRef Referencia As String, ByRef Abreviacion As String) As String
		Dim rs As New ADODB.Recordset
		rs = New ADODB.Recordset
		NombreSyscod = ""
		rs.Open(" Select * from syscod where tiporeferencia =  '" & Referencia & "' and abreviación = '" & Abreviacion & "'", ConxSysemp, ADOR.CursorTypeEnum.adOpenForwardOnly, ADOR.LockTypeEnum.adLockReadOnly)
		If rs.EOF = False Then NombreSyscod = rs.Fields("descripcion").Value Else NombreSyscod = Abreviacion
		If rs.State = 1 Then rs.Close()
	End Function
	
	Public Function QueNombreSyscod(ByRef Tipo As String, ByRef QUECODIGO As String) As String
		Dim BusCod As New Syscod.ManSysnetClass
		'Set BusCod = New BuscaSyscod
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto BusCod.ConectarSyscod. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		BusCod.ConectarSyscod = ConxSysemp.ConnectionString
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto BusCod.TipoCodigo. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		BusCod.TipoCodigo = Tipo
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto BusCod.Nombre. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		QueNombreSyscod = Trim(BusCod.Nombre)
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto BusCod.codigo. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		QUECODIGO = Trim(BusCod.codigo)
		'UPGRADE_NOTE: El objeto BusCod no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		BusCod = Nothing
	End Function
End Module