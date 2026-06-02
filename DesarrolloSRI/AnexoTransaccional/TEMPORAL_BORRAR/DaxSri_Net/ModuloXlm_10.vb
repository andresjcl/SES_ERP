Option Strict Off
Option Explicit On
Module MODULOXLM
	
	Public Sub GrabarCampoXML(ByRef Nombre As String, ByRef Valor As String, ByRef Tipo As Short, ByRef Longitud As String, ByRef Nivel As Byte, Optional ByRef cNumero As String = "")
		Dim CampoImp As String
		CampoImp = Valor
		If Tipo = 1 Then
			CampoImp = Left(Trim(CampoImp), CInt(Longitud))
		ElseIf Tipo = 2 Then 
			CampoImp = Right(VB6.Format(Val(CampoImp), "########0.00"), CInt(Longitud))
		ElseIf Tipo = 3 Then 
			CampoImp = Right("000000000000000" & Trim(CampoImp), CInt(Longitud))
		ElseIf Tipo = 4 Then 
			CampoImp = Trim(CampoImp)
		End If
		
		If Nivel = 1 Then
			PrintLine(1, "<" & Nombre & ">")
		ElseIf Nivel = 2 Then 
			PrintLine(1, "<" & Nombre & ">" & CampoImp & "</" & Nombre & ">")
		ElseIf Nivel = 3 Then 
			PrintLine(1, "</" & Nombre & ">")
		ElseIf Nivel = 4 Then 
			PrintLine(1, "<" & Nombre & " numero=" & """" & Trim(cNumero) & """" & ">" & CampoImp & "</" & Nombre & ">")
		End If
		'  <campo numero="101">6</campo>
		
	End Sub
	
	Public Function DarFormato(ByRef dato As Object, ByRef Longitud As Object, ByRef Tipo As Object, ByRef ALinea As Object, ByRef Valor As Object) As Object
		Dim I As Object
		Dim fecha As String
		'cambiar on error Resume Next
		'dato = Dato al que se dara formato
		'Longitud = Longitud ala que quedará el dato  (5)
		'tipo = Tipo de dato  (S = String , F = Fecha, N = Numero)
		'Alinea =  Tipo de alineacion (I = Izquierda, D = Derecha)
		'Valor  = Valor Con el que se completara al dato para alcanzar la longitud deseada(" ", 0)
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
			For I = 1 To Longitud + 2
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto I. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dato. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto I. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dato. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Mid(dato, I, 1) <> "/" Then fecha = fecha & Mid(dato, I, 1)
			Next I
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dato. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dato = fecha
		End If
		
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Tipo. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dato. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Tipo = "N" Then dato = VB6.Format(roundd(CDbl(dato), 2), "#########0.00")
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Longitud. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Len(dato) < Longitud Then
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Longitud. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			For I = 1 To Longitud - Len(dato)
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ALinea. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If ALinea = "I" Then
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Valor. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dato. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					dato = dato & Valor
				Else
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dato. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Valor. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					dato = Valor & dato
				End If
			Next I
		End If
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Longitud. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Len(dato) > Longitud Then
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Longitud. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dato. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			dato = Mid(dato, 1, Longitud)
		End If
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto dato. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto DarFormato. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		DarFormato = dato
	End Function
End Module