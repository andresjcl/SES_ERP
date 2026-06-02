Option Strict Off
Option Explicit On
Module ModDaxSri
	'UPGRADE_ISSUE: SRIRETENDx objeto no se actualizó. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
	Public Adcomw As SRIRETENDx
	Public Function Calculadora() As Double
		Dim calc As New daxcalc.Calcula
		calc = New daxcalc.Calcula
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto calc.Valor. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Calculadora = calc.Valor
		'UPGRADE_NOTE: El objeto calc no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		calc = Nothing
	End Function
	
	Public Function QueFecha() As Date
		Dim fecha As fecha.Calendario
		fecha = New fecha.Calendario
		QueFecha = fecha.fecha
		'UPGRADE_NOTE: El objeto fecha no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		fecha = Nothing
	End Function
	
	Public Function FechaFinMes(ByRef Anio As Integer, ByRef Mes As Short) As Date
		Dim FEB, DiaFinal As Short
		FEB = IIf(DatePart(Microsoft.VisualBasic.DateInterval.DayOfYear, CDate("31/12/" & Anio)) > 365, 29, 28)
		Select Case Mes
			Case 1, 3, 5, 7, 8, 10, 12
				DiaFinal = 31
			Case 2
				DiaFinal = FEB
			Case Else
				DiaFinal = 30
		End Select
		FechaFinMes = DateSerial(Anio, Mes, DiaFinal)
	End Function
	
	Public Function QuitarMarca(ByRef Auxil As String) As String
		Dim m As Short
		m = InStr(1, Auxil, "&")
		If m > 0 Then
			QuitarMarca = Left(Auxil, m - 1) & Mid(Auxil, m + 1)
		Else : QuitarMarca = Auxil
		End If
		
	End Function
End Module