Option Strict Off
Option Explicit On
Module NumLetra
	Public Function Cnl(ByRef numero As Double, ByRef ConDecimal As String) As String
		Dim Unidades(19) As String
		Dim Decenas(9) As String
		Dim Centenas(9) As String
		Dim Miles(4) As String
		Dim Par3 As Short
		Dim Entero As New VB6.FixedLengthString(12)
		Dim Ndecimal As New VB6.FixedLengthString(2)
		Dim Sauxil As New VB6.FixedLengthString(3)
		Dim P3, p1, j, P2, P4 As Short
		Dim pasar As String
		
		Unidades(1) = "UN"
		Unidades(2) = "DOS"
		Unidades(3) = "TRES"
		Unidades(4) = "CUATRO"
		Unidades(5) = "CINCO"
		Unidades(6) = "SEIS"
		Unidades(7) = "SIETE"
		Unidades(8) = "OCHO"
		Unidades(9) = "NUEVE"
		Unidades(10) = "DIEZ"
		Unidades(11) = "ONCE"
		Unidades(12) = "DOCE"
		Unidades(13) = "TRECE"
		Unidades(14) = "CATORCE"
		Unidades(15) = "QUINCE"
		Unidades(16) = "DIECISEIS"
		Unidades(17) = "DIECISIETE"
		Unidades(18) = "DIECIOCHO"
		Unidades(19) = "DIECINUEVE"
		
		Decenas(1) = "DIEZ"
		Decenas(2) = "VEINTE"
		Decenas(3) = "TREINTA"
		Decenas(4) = "CUARENTA"
		Decenas(5) = "CINCUENTA"
		Decenas(6) = "SESENTA"
		Decenas(7) = "SETENTA"
		Decenas(8) = "OCHENTA"
		Decenas(9) = "NOVENTA"
		
		Centenas(1) = "CIENTO"
		Centenas(2) = "DOSCIENTOS"
		Centenas(3) = "TRESCIENTOS"
		Centenas(4) = "CUATROCIENTOS"
		Centenas(5) = "QUINIENTOS"
		Centenas(6) = "SEISCIENTOS"
		Centenas(7) = "SETECIENTOS"
		Centenas(8) = "OCHOCIENTOS"
		Centenas(9) = "NOVECIENTOS"
		
		Miles(1) = "MIL"
		Miles(2) = "MILLON"
		Miles(3) = "MIL"
		Miles(4) = " "
		
		
		Entero.Value = Right("000000000000" & Trim(Str(Int(numero))), 12)
		Par3 = (numero - Int(numero)) * 100
		Ndecimal.Value = Trim(Str(Par3))
		If Par3 < 10 Then Ndecimal.Value = "0" & Ndecimal.Value
		If Val(Entero.Value) = 0 Then
			pasar = "CERO "
		Else
			For j = 1 To 4
				Sauxil.Value = Mid(Entero.Value, j + 2 * (j - 1), 3)
				Par3 = Val(Sauxil.Value)
				If Par3 > 0 Then
					p1 = CShort(Mid(Sauxil.Value, 1, 1))
					P2 = CShort(Mid(Sauxil.Value, 2, 2))
					P3 = CShort(Mid(Sauxil.Value, 2, 1))
					P4 = CShort(Mid(Sauxil.Value, 3, 1))
					Centenas(1) = IIf(Par3 = 100, "CIEN", "CIENTO")
					If Par3 > 99 Then pasar = pasar & Centenas(p1) & " "
					If P2 > 19 Then
						pasar = pasar & Decenas(P3)
						If P4 > 0 Then pasar = pasar & " Y " & Unidades(P4)
					End If
					If P2 > 0 And P2 < 20 Then pasar = pasar & Unidades(P2)
					If j < 4 Then
						pasar = pasar & " " & Miles(j)
						If j < 2 And Par3 > 1 Then pasar = pasar & "ES"
					Else
						If P4 = 1 And P2 <> 11 Then pasar = pasar & "O"
					End If
					pasar = pasar & " "
				End If
			Next j
		End If
		If ConDecimal = "S" Or ConDecimal = "Y" Then
			Cnl = pasar & " CON " & Ndecimal.Value & "/100 "
		Else
			Cnl = pasar
		End If
	End Function
End Module