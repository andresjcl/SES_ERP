Option Strict Off
Option Explicit On
Module DigitacionDatos
	
	Public Function VerificarFormatoFecha(ByRef ObjetoText As System.Windows.Forms.TextBox) As Boolean
		If Not IsDate(ObjetoText.Text) Then
			'ObjetoText = Format(ObjetoText, "dd/mm/yyyy")
			MsgBox("Fecha mal ingresada , formato 'dd/mm/yyyy'", MsgBoxStyle.Information)
			'ObjetoText.SetFocus
			VerificarFormatoFecha = False
			ObjetoText.Text = VB6.Format(Today, "dd/mm/yyyy")
		Else
			ObjetoText.Text = VB6.Format(ObjetoText.Text, "dd/mm/yyyy")
			VerificarFormatoFecha = True
		End If
	End Function
	
	Public Function SoloNumeros(ByRef KeyAscii As Short) As Short
		Select Case KeyAscii
			Case 48 To 57, 8, 46, 44, 45, 22, 3
				SoloNumeros = KeyAscii
			Case Else
				SoloNumeros = 0
		End Select
	End Function
	
	Public Function SoloEnteros(ByRef KeyAscii As Short) As Short
		Select Case KeyAscii
			Case 48 To 57, 8
				SoloEnteros = KeyAscii
			Case Else
				SoloEnteros = 0
		End Select
	End Function
	
	Public Sub PonerSel(ByRef TXT As System.Windows.Forms.TextBox)
		TXT.SelectionStart = 0
		TXT.SelectionLength = Len(TXT.Text)
	End Sub
	
	Public Sub QuitarSel(ByRef TXT As System.Windows.Forms.TextBox)
		TXT.SelectionStart = 0
		TXT.SelectionLength = 0
	End Sub
	
	Public Sub PonerFecTxt(ByRef TXT As System.Windows.Forms.TextBox, ByRef KCode As Short)
		If KCode = System.Windows.Forms.Keys.F3 Then
			TXT.Text = CStr(Today)
		End If
	End Sub
	
	
	Public Function CorrijeNulo(ByRef Valor As Object) As Object
		'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(Valor) Then
			If IsNumeric(Valor) Then
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CorrijeNulo = 0
			ElseIf IsDate(Valor) Then 
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CorrijeNulo = "01/01/1800"
			Else
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				CorrijeNulo = ""
			End If
		Else
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Valor. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CorrijeNulo = Valor
		End If
	End Function
	
	Public Function CorrijeNuloN(ByRef Valor As Object) As Double
		'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Valor. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If IsDbNull(Valor) Then Valor = 0
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Valor. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Not IsNumeric(Valor) Then Valor = 0
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Valor. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Valor = "" Then
			CorrijeNuloN = 0
		Else
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Valor. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CorrijeNuloN = CDbl(Valor)
		End If
	End Function
	
	Public Function CorrijeNuloF(ByRef Valor As Object) As Date
		Dim falla As Boolean
		falla = False
		'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
		If IsDbNull(Valor) Or Not IsDate(Valor) Then
			falla = True
		Else
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Valor. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If CDate(Valor) < CDate("31/12/1901") Then falla = True
		End If
		If falla Then
			CorrijeNuloF = CDate("00:00:00")
		Else
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Valor. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CorrijeNuloF = Valor
		End If
	End Function
End Module