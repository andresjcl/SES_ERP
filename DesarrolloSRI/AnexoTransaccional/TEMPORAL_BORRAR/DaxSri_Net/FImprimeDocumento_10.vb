Option Strict Off
Option Explicit On
Friend Class FImprimeDocumento
	Inherits System.Windows.Forms.Form
	Public correoElectronico As String
	
	Public Sub ImpDoc(ByRef IdClaveDocC As Double, ByRef Sucursal As String, ByRef TipoDocumento As String, ByRef NumeroDocumento As Double, Optional ByRef QueSystema As String = "", Optional ByRef FacturaProforma As String = "", Optional ByRef AuxManual As String = "", Optional ByRef otraimp As String = "", Optional ByRef ImpCtb As String = "")
		Dim ImprDoct As Object
		On Error GoTo hayError
		Dim pasar As String
		'UPGRADE_ISSUE: ImprDoct.ImprimirDoc objeto no se actualizó. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
		Dim prog As ImprDoct.ImprimirDoc = New ImprDoct.ImprimirDoc
		pasar = QueSystema & "," & FacturaProforma & "," & AuxManual & "," & otraimp & "," & ImpCtb
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto prog.ImprimeDoc. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		prog.ImprimeDoc(IdClaveDocC, Sucursal, TipoDocumento, NumeroDocumento, pasar)
		'UPGRADE_NOTE: El objeto prog no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		prog = Nothing
		Me.Close()
		Exit Sub
hayError: 
		MsgBox("error emidoc: " & Err.Description)
	End Sub
End Class