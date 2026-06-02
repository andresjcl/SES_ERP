Option Strict Off
Option Explicit On
Module RetornaNombres
	Public Function RetornaNombreSucursal(ByRef CodigoSuc As String) As String
		Dim RsSuc As New ADODB.Recordset
		Dim cod As String
		
		RsSuc.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
		RsSuc.LockType = ADODB.LockTypeEnum.adLockOptimistic
		
		cod = " SELECT * FROM emp_suc where emp_codigo= " & Emp.codigo & " and Suc_codigo='" & CodigoSuc & "'  "
		RsSuc.Open(cod, ConxSysemp,  ,  , ADODB.CommandTypeEnum.adCmdText)
		If RsSuc.RecordCount > 0 Then
			RetornaNombreSucursal = RsSuc.Fields("Suc_Nombre").Value
		End If
		
		RsSuc.Close()
		
	End Function
	
	Public Function RetornaNombreBodega(ByRef CodigoSuc As String, ByRef CodigoBod As String) As String
		Dim RsBod As New ADODB.Recordset
		Dim cod As String
		
		RsBod.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
		RsBod.LockType = ADODB.LockTypeEnum.adLockOptimistic
		
		cod = " SELECT * FROM emp_Bod where emp_codigo= " & Emp.codigo & " and Bod_codigo='" & CodigoBod & "'  "
		RsBod.Open(cod, ConxSysemp,  ,  , ADODB.CommandTypeEnum.adCmdText)
		If RsBod.RecordCount > 0 Then
			RetornaNombreBodega = RsBod.Fields("Bod_Nombre").Value
		End If
		RsBod.Close()
	End Function
	
	Public Function RetornaNombreBanco(ByRef codigo As String) As String
		Dim RsBanco As New ADODB.Recordset
		Dim cod As String
		RsBanco.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
		RsBanco.LockType = ADODB.LockTypeEnum.adLockOptimistic
		
		cod = " SELECT * FROM adcCtabco where bco_codigo= '" & codigo & "'"
		RsBanco.Open(cod, ConxAdcom,  ,  , ADODB.CommandTypeEnum.adCmdText)
		If RsBanco.RecordCount > 0 Then
			RetornaNombreBanco = RsBanco.Fields("Bco_Nombre").Value
		End If
		RsBanco.Close()
		
	End Function
	
	Public Function RetornaNombrePago(ByRef codigo As String) As String
		Dim RsPago As New ADODB.Recordset
		Dim cod As String
		RsPago.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
		RsPago.LockType = ADODB.LockTypeEnum.adLockOptimistic
		
		cod = " SELECT * FROM formasdepago where IdFormasDePago = '" & codigo & "'"
		RsPago.Open(cod, ConxAdcom,  ,  , ADODB.CommandTypeEnum.adCmdText)
		If RsPago.EOF = False Then
			RetornaNombrePago = RsPago.Fields("Descripcion").Value
		End If
		RsPago.Close()
		'UPGRADE_NOTE: El objeto RsPago no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		RsPago = Nothing
	End Function
	
	Public Function RetornaCodigoPago(ByRef codigo As String) As String
		Dim RsPago As New ADODB.Recordset
		Dim cod As String
		RsPago.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
		RsPago.LockType = ADODB.LockTypeEnum.adLockOptimistic
		cod = " SELECT * FROM formasdepago where descripcion = '" & codigo & "'"
		RsPago.Open(cod, ConxAdcom,  ,  , ADODB.CommandTypeEnum.adCmdText)
		If RsPago.EOF = False Then
			RetornaCodigoPago = RsPago.Fields("IdFormasDePago").Value
		End If
		RsPago.Close()
	End Function
	
	Public Function RetornaNombreNivel(ByRef Abrevia As String) As String
		Dim RsNiv As New ADODB.Recordset
		Dim cod As String
		cod = "SELECT * FROM AdcNiv Where Niv_abrevia= '" & Abrevia & "' "
		
		With RsNiv
			.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
			.LockType = ADODB.LockTypeEnum.adLockOptimistic
			.Open(cod, ConxAdcom,  ,  , ADODB.CommandTypeEnum.adCmdText)
			If .RecordCount > 0 Then
				RetornaNombreNivel = .Fields("niv_nombre").Value
			Else
				RetornaNombreNivel = "Desconocido"
			End If
			.Close()
		End With
		
	End Function
	
	Public Function LeerMedida(ByRef QueMed As String) As String
		Dim Rs As New ADODB.Recordset
		Rs.Open("Select * from Syscod where tiporeferencia ='Medidas' and abreviación = '" & QueMed & "'", ConxSyscod, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
		LeerMedida = QueMed
		If Rs.State = 0 Then Exit Function
		If Rs.EOF = False Then LeerMedida = Rs.Fields("Descripcion").Value
		Rs.Close()
	End Function
	
	Public Function NombreCuentaContable(ByRef codigo As String) As String
		Dim RsAux As New ADODB.Recordset
		Dim cod As String
		cod = "SELECT Cta_Codigo,Cta_Nombre FROM AdcCta WHERE Cta_Codigo='" & Trim(codigo) & "'"
		RsAux.Open(cod, ConxAdcom, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
		If RsAux.EOF = False Then
			NombreCuentaContable = RsAux.Fields("CTA_NOMBRE").Value
		Else
			NombreCuentaContable = CStr(Nothing)
		End If
		If RsAux.State = 1 Then RsAux.Close()
	End Function
	
	Public Function NombreDirectorio(ByRef codigo As String) As String
		Dim RsAux As New ADODB.Recordset
		Dim cod As String
		cod = "SELECT NombreImpresion FROM identificacion WHERE codigo='" & Trim(codigo) & "'"
		RsAux.Open(cod, ConxAdcom, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
		If RsAux.EOF = False Then
			NombreDirectorio = RsAux.Fields("NombreImpresion").Value
		Else
			NombreDirectorio = CStr(Nothing)
		End If
		If RsAux.State = 1 Then RsAux.Close()
	End Function
End Module