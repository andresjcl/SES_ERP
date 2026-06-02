Option Strict Off
Option Explicit On
Module CargarHistoriaSri
	
	Public Function CargarOpcionSri(ByRef Sistema As String, ByRef RucCi As String, ByRef TipDoc As String, ByRef Auxil1 As String, ByRef AUXIL2 As Object) As String
		Dim rs As New ADODB.Recordset
		'cambiar on error Resume Next
		CargarOpcionSri = ""
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto AUXIL2. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		rs.Open("select * from sysopc where sys0 = '" & Sistema & "' and sys1 = '" & RucCi & "' AND sys2 = '" & TipDoc & "' AND sys3 = '" & Auxil1 & "'  AND sys4 = '" & AUXIL2 & "' ", ConxSysemp, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
		If rs.State = 0 Then Exit Function
		If rs.EOF = False Then CargarOpcionSri = rs.Fields("Valor").Value
		rs.Close()
	End Function
	
	Public Sub GrabarOpcionSri(ByRef Sistema As String, ByRef RucCi As String, ByRef TipDoc As String, ByRef Auxil1 As String, ByRef AUXIL2 As String, ByRef Valor As String)
		Dim rs As New ADODB.Recordset
		'cambiar on error Resume Next
		rs.Open("select * from sysopc where sys0 = '" & Sistema & "' and sys1 = '" & RucCi & "' AND sys2 = '" & TipDoc & "' AND sys3 = '" & Auxil1 & "'  AND sys4 = '" & AUXIL2 & "' ", ConxSysemp, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		If rs.State = 0 Then Exit Sub
		If rs.EOF = True Then rs.AddNew()
		With rs
			.Fields("sys0").Value = Sistema
			.Fields("sys1").Value = RucCi
			.Fields("sys2").Value = TipDoc
			.Fields("sys3").Value = Auxil1
			.Fields("sys4").Value = AUXIL2
			.Fields("Valor").Value = Valor
			.Update()
		End With
		rs.Close()
	End Sub
End Module