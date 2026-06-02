Option Strict Off
Option Explicit On
Module MODULOXLM
	
	Public Sub GrabarCampoXML(ByRef Nombre As String, ByRef Valor As String, ByRef Tipo As Short, ByRef Longitud As String, ByRef Nivel As Byte)
		Dim CampoImp As String
		If Valor = "30/12/1899" Then Valor = ""
		'
		'If Formato > "" Then
		'    CampoImp = Format(valor, Formato)
		'Else
		CampoImp = Valor
		'End If
		'If Tipo = 1 Then
		'    CampoImp = Left(CampoImp & Space(Longitud), Longitud)
		'Else
		If Tipo = 1 Then
			CampoImp = Left(Trim(CampoImp), CInt(Longitud))
		ElseIf Tipo = 2 Then 
			CampoImp = Right(VB6.Format(System.Math.Abs(Val(CampoImp)), "########0.00"), CInt(Longitud))
		ElseIf Tipo = 3 Then 
			CampoImp = Right("000000000000000" & Trim(CampoImp), CInt(Longitud))
		End If
		
		If Nivel = 1 Then
			PrintLine(1, "<" & Nombre & ">")
		ElseIf Nivel = 2 Then 
			PrintLine(1, "<" & Nombre & ">" & CampoImp & "</" & Nombre & ">")
		ElseIf Nivel = 3 Then 
			PrintLine(1, "</" & Nombre & ">")
		End If
	End Sub
End Module