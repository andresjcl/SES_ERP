Option Strict Off
Option Explicit On
Module ConexionBaseDeDatos
	'Public cnn As New ADODB.Connection
	Public Function ArmStr(ByRef Path As String, Optional ByRef Serv As String = "", Optional ByRef Tipo As String = "", Optional ByRef Passw As String = "", Optional ByRef Usuario As String = "", Optional ByRef Version As Short = 0) As String
		Dim Clave As String
		Dim User As String
		If Tipo = "ACC" Then
			ArmStr = "DRIVER={Microsoft Access Driver (*.mdb)};" & "DBQ=" & Path & ";" & "UID=" & Usuario & ";PWD=" & Passw & ";"
		Else
			Clave = IIf(UCase(Passw) = "ADCOM", "", Passw)
			User = IIf(Clave > "", Passw, "")
			
			ArmStr = "Provider=MSDASQL;DRIVER=SQL Server;"
			ArmStr = ArmStr & "SERVER=" & Serv & ";"
			ArmStr = ArmStr & "UID=" & Trim(Usuario) & ";"
			ArmStr = ArmStr & "PWD=" & Passw & ";"
			ArmStr = ArmStr & "APP=AdcomDx;"
			ArmStr = ArmStr & "WSID=" & UCase(Serv) & ";"
			ArmStr = ArmStr & "DATABASE=" & Path & ";"
			
			' Provider=MSDASQL.1;Extended Properties='DRIVER=SQL Server Native Client 10.0;SERVER=daxserver;
			' UID=sa;PWD=123qweASDZXC;APP=Visual Basic;WSID=DAXSOFJG;DATABASE=adcomdaxsof;'
			
		End If
	End Function
	
	Public Function ArmCodSQL(ByRef Campo As String, ByRef lug As String, ByRef Num As Short, Optional ByRef con As String = "", Optional ByRef SNWhere As Boolean = False) As String
		
		' campo: nombre de la tabla
		' lug: todos las suc, bod o doc
		' num: numero de lugares
		' con: conector logico OR o  AND
		
		Dim Temp As String
		Dim cont As Short : cont = 1
		Dim contLargo As Short : contLargo = 1
		Dim contPos As Short : contPos = 1
		ArmCodSQL = ""
		If SNWhere Then Temp = " WHERE "
		
		If UCase(ControlUsuario.Identifica) = "ADMINISTRADOR" Or UCase(ControlUsuario.Identifica) = "CONTROL" Then
			Temp = Temp & "(" & Campo & " <> ';') "
			Num = 1
		Else
			Do While cont <= Num
				If contPos = Len(lug) And cont = 1 Then
					Temp = Temp & Campo & "='" & Mid(lug, contPos - contLargo + 1, contLargo) & "' "
					contLargo = 1
					cont = cont + 1
				ElseIf Mid(lug, contPos, 1) = " " Or contPos = Len(lug) Then 
					If cont = 1 Then
						Temp = Temp & "(" & Campo & "='" & Mid(lug, contPos - contLargo + 1, contLargo - 1) & "' "
					ElseIf contPos < Len(lug) Then 
						Temp = Temp & "OR " & Campo & "='" & Mid(lug, contPos - contLargo + 2, contLargo - 2) & "' "
					ElseIf contPos = Len(lug) Then 
						Temp = Temp & "OR " & Campo & "='" & Mid(lug, contPos - contLargo + 2, contLargo - 1) & "') "
					End If
					contLargo = 1
					cont = cont + 1
				End If
				contPos = contPos + 1
				contLargo = contLargo + 1
			Loop 
		End If
		
		'CUANDO NO TENGA ACCESA A NADA
		
		If Num = 0 Then Temp = Temp & Campo & "='XXXX' "
		
		'UPGRADE_NOTE: IsMissing() ha cambiado a IsNothing(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"'
		If Temp <> " WHERE " And Not IsNothing(con) Then
			ArmCodSQL = Temp & con & " "
			'UPGRADE_NOTE: IsMissing() ha cambiado a IsNothing(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"'
		ElseIf Temp = " WHERE " And Not IsNothing(con) Then 
			ArmCodSQL = Temp
			'UPGRADE_NOTE: IsMissing() ha cambiado a IsNothing(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"'
		ElseIf Temp = " WHERE " And IsNothing(con) Then 
			ArmCodSQL = ""
		End If
	End Function
	
	Public Function ArmFormatoFecha(ByRef fecha As String, Optional ByRef Tipbase As String = "") As String
		'Dim sSQL As String
		If Tipbase = "ACC" Then
			ArmFormatoFecha = "#" & VB6.Format(fecha, "mm/dd/yyyy") & "#"
		Else
			ArmFormatoFecha = "'" & VB6.Format(Trim(fecha), "dd/mm/yyyy") & "'"
		End If
	End Function
End Module