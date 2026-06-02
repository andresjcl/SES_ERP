Option Strict Off
Option Explicit On
Module PonerFormatos
	Public Function PonerFormatoNumero(ByRef ValorRetorna As Object) As String
		Dim numero As Double
		'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(ValorRetorna) Then numero = 0
		If Not IsNumeric(ValorRetorna) Then
			numero = 0
		Else
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ValorRetorna. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			numero = ValorRetorna
		End If
		If numero = 0 Then
			PonerFormatoNumero = CStr(Nothing)
		Else
			PonerFormatoNumero = VB6.Format(numero, "##########0." & New String("0", Emp.NumeroDigitos))
		End If
	End Function
	
	Public Function PonerFormatoVentas(ByRef ValorRetorna As Object) As String
		Dim numero As Double
		'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(ValorRetorna) Then numero = 0
		If Not IsNumeric(ValorRetorna) Then
			numero = 0
		Else
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ValorRetorna. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			numero = ValorRetorna
		End If
		PonerFormatoVentas = VB6.Format(numero, "##########0." & New String("0", Emp.DigitosPrecios))
	End Function
	
	Public Function PonerFormatoCostos(ByRef ValorRetorna As Object) As String
		Dim numero As Double
		'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(ValorRetorna) Then numero = 0
		If Not IsNumeric(ValorRetorna) Then
			numero = 0
		Else
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ValorRetorna. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			numero = ValorRetorna
		End If
		PonerFormatoCostos = VB6.Format(numero, "##########0." & New String("0", Emp.DigitosCostos))
	End Function
	
	Public Function PonFormatNumComas(ByRef ValorRetorna As Object) As String
		Dim numero As Double
		'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(ValorRetorna) Then numero = 0
		If Not IsNumeric(ValorRetorna) Then
			numero = 0
		Else
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ValorRetorna. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			numero = ValorRetorna
		End If
		PonFormatNumComas = VB6.Format(numero, "####,###,##0." & New String("0", CShort(Emp.NumeroDecimales)))
	End Function
End Module