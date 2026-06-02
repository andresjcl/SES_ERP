Option Strict Off
Option Explicit On
Module MensajesError
	Public Sub MensajeFecha()
		MsgBox("La fecha del documento es menor a un período establecido" & vbCr & " debe digitar una fecha mayor o igual a " & Emp.RolCodMay, MsgBoxStyle.Critical)
	End Sub
	Public Function ConfirmaNuevoDocumento() As Boolean
		ConfirmaNuevoDocumento = False
		If MsgBox("El número de documento digitado no existe" & vbCr & "Confirma crear un nuevo documento ?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then ConfirmaNuevoDocumento = True
	End Function
	
	Public Function ConfirmaAnular() As Boolean
		ConfirmaAnular = False
		If MsgBox("Confirma Anular el registro actual ?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then ConfirmaAnular = True
	End Function
	
	Public Function ConfirmaEliminar() As Boolean
		ConfirmaEliminar = False
		If MsgBox("Confirma eliminar todo el registro actual ?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then ConfirmaEliminar = True
	End Function
	
	Public Function ConfirmaCancelar() As Boolean
		ConfirmaCancelar = False
		If MsgBox("Confirma cancelar la operación ? " & vbCr & " se perderán los cambios realizados", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then ConfirmaCancelar = True
	End Function
	
	Public Function ConfirmaCerrar() As Boolean
		ConfirmaCerrar = False
		If MsgBox("Confirma cerrar el documento ? " & vbCr & " se perderán los cambios realizados", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then ConfirmaCerrar = True
	End Function
	
	Public Function ConfirmaSalir() As Boolean
		ConfirmaSalir = False
		If MsgBox("Confirma SALIR ?" & vbCr & " si no guardo los cambios realizados, se perderán ", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then ConfirmaSalir = True
	End Function
	
	Public Function ConfirmaSobreescribir(ByRef QueArchivo As String) As Boolean
		ConfirmaSobreescribir = True
		'UPGRADE_WARNING: Dir tiene un nuevo comportamiento. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
		If Dir(QueArchivo) > "" Then
			If MsgBox("El archivo ya existe, los datos actuales reemplazarán a los existentes", MsgBoxStyle.OKCancel + MsgBoxStyle.Critical + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then ConfirmaSobreescribir = False
		End If
	End Function
	Public Function ConfirmaReemplazarDatos() As Boolean
		ConfirmaReemplazarDatos = False
		If MsgBox("El número de documento digitado ya existe, desea visualizar el los datos del documento que existe ? " & vbCr & " los datos registrados en la pantalla se perderán ", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then ConfirmaReemplazarDatos = True
	End Function
	
	Public Function ConfirmaReemplazarDatosNuevos() As Boolean
		ConfirmaReemplazarDatosNuevos = False
		If MsgBox("El número de documento digitado ya existe, desea visualizar el los datos del documento que existe ? " & vbCr & " los datos registrados en la pantalla se perderán ", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then ConfirmaReemplazarDatosNuevos = True
	End Function
	
	Public Function ConfirmaReemplazarDatosModifica() As Boolean
		ConfirmaReemplazarDatosModifica = False
		If MsgBox("El número de documento digitado ya existe, desea visualizar el los datos del documento que existe ? " & vbCr & " Los cambios del documento actual se perderán ", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then ConfirmaReemplazarDatosModifica = True
	End Function
	
	Public Function ConfirmaGrabarRegistro() As Boolean
		ConfirmaGrabarRegistro = False
		If MsgBox("Confirma Grabar el registro antes de salir ? ", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then ConfirmaGrabarRegistro = True
	End Function
	
	Public Sub NoexisteRegistro()
		MsgBox("El Registro buscado no existe", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly + MsgBoxStyle.ApplicationModal)
	End Sub
	
	Public Sub MensajeNumeroDoc()
		MsgBox("El número de documento se encuentra errado, registre uno diferente", MsgBoxStyle.Critical)
	End Sub
	
	Public Sub MensajeFechaErrada()
		MsgBox("La fecha digitada es invalida", MsgBoxStyle.Critical)
	End Sub
	
	Public Sub ElCodigoNoExiste(ByRef Tip As String)
		Dim Men As String
		If UCase(Tip) = "C" Then
			Men = " CLIENTE "
		ElseIf UCase(Tip) = "P" Then 
			Men = " PROVEEDOR "
		ElseIf UCase(Tip) = "B" Then 
			Men = " BANCO "
		ElseIf UCase(Tip) = "A" Then 
			Men = " ARTICULO "
		ElseIf UCase(Tip) = "O" Then 
			Men = " PRODUCTO "
		ElseIf UCase(Tip) = "S" Then 
			Men = " SUCURSAL "
		End If
		MsgBox(" EL CODIGO DE" & Men & "NO EXISTE, DIGITE UNO VALIDO ", MsgBoxStyle.Critical, "MENSAJE DE ERROR")
	End Sub
	
	Public Sub ControlaErrores(Optional ByRef Donde As String = "")
		Dim msj As String
		Select Case Err.Number
			Case 3022
				msj = "No se puede ingresar valores duplicados"
			Case Else
				msj = Err.Number & " " & Err.Description
		End Select
		'UPGRADE_WARNING: MsgBox No se admite el parámetro 'context' y se ha quitado. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="54413EB8-EB35-481C-89BE-32525CFC7903"'
		'UPGRADE_WARNING: MsgBox No se admite el parámetro 'helpfile' y se ha quitado. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="54413EB8-EB35-481C-89BE-32525CFC7903"'
		MsgBox(msj, MsgBoxStyle.Critical, "Error " & Donde)
	End Sub
	
	Public Function AdcomConSri() As Boolean
		If Emp.Sri = False Then
			MsgBox("Esta versión del sistema no acepta funciones especiales para el SRI" & vbCr & "Consulte al proveedor del sistema o a DAXSOF - www.daxsof.com.ec - jorgeg@daxsof.com.ec 099906974", MsgBoxStyle.Critical)
			AdcomConSri = False
		Else
			AdcomConSri = True
		End If
	End Function
	
	Public Function SinAdicionales() As Boolean
		SinAdicionales = False
		If MsgBox("No se ha ingresado los datos adicionales del SRI o están errados", MsgBoxStyle.Critical + MsgBoxStyle.RetryCancel) = MsgBoxResult.Retry Then Exit Function
		SinAdicionales = True
	End Function
	
	Public Function SinAutorizacion() As Boolean
		SinAutorizacion = False
		If MsgBox("La autorización SRI para emisión del documento está errada o no existe, Desea Continuar ", MsgBoxStyle.Critical + MsgBoxStyle.RetryCancel) = MsgBoxResult.Retry Then Exit Function
		SinAutorizacion = True
	End Function
	
	Public Sub GrabarError(ByRef Mensaje As String)
		Dim filespec As String
		Dim menj As String
		Dim ext As Boolean
		filespec = Emp.PatAppl & Emp.Sistema & ".err"
		Const ForReading As Short = 1
		Const ForWriting As Short = 2
		Const ForAppending As Short = 8
		Const TristateUseDefault As Short = -2
		Const TristateTrue As Short = -1
		Const TristateFalse As Short = 0
		Dim ts, fs, f, S As Object
		fs = CreateObject("Scripting.FileSystemObject")
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto fs.FileExists. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ext = fs.FileExists(filespec)
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto fs.CreateTextFile. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Not ext Then fs.CreateTextFile(filespec) 'Crear un archivo
		If Not ext Then
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto fs.CreateTextFile. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			fs.CreateTextFile(filespec) 'Crear un archivo
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto fs.GetFile. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			f = fs.GetFile(filespec)
		Else
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto fs.GetFile. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			f = fs.GetFile(filespec)
		End If
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto f.OpenAsTextStream. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ts = f.OpenAsTextStream(ForAppending, TristateUseDefault)
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ts.WriteBlankLines. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ts.WriteBlankLines(0)
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ts.WriteLine. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ts.WriteLine(Now & " - " & Mensaje)
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ts.Close. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ts.Close()
		'        Open filespec For Append As #7
		'        Print #7, Now & " - " & Mensaje
		'        Close #7
	End Sub
	
	Public Sub MensajePeriodo()
		MsgBox("El documento no se encuentra dentro de un período valido", MsgBoxStyle.Critical)
	End Sub
End Module