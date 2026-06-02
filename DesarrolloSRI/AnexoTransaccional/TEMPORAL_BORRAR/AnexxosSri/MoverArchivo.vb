Option Strict Off
Option Explicit On
Module MoverArchivo
	Public Function MoverRegistro(ByRef RecAdo As ADODB.Recordset, ByRef QueHace As String) As Boolean
		'cambiar on error GoTo Errores
		If RecAdo Is Nothing Then MoverRegistro = False : Exit Function
		With RecAdo
			Select Case QueHace
				Case "S"
					If Not .EOF Then .MoveNext()
					If .EOF Then MsgBox("Se encuentra al final del archivo", MsgBoxStyle.Information, "Ubicación en archivo") : .MoveLast()
				Case "U"
					.MoveLast()
				Case "I"
					.MoveFirst()
				Case "A"
					If Not .BOF Then .MovePrevious()
					If .BOF Then MsgBox("Se encuentra al inicio del archivo", MsgBoxStyle.Information, "Ubicación en archivo") : .MoveFirst()
			End Select
			If .BOF Or .EOF Then MoverRegistro = False Else MoverRegistro = True
		End With
		Exit Function
Errores: 
		MoverRegistro = False
	End Function
End Module