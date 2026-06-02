Option Strict Off
Option Explicit On
Module ArregloDeFormularios
	'Public Sub OrdenarTabIndex(Formulario As Form)
	'Dim Elemento As Control, i As Long, a As String
	'i = 0
	'For Each Elemento In Formulario
	'a = UCase$(TypeName(Elemento))
	'If a = "TEXTBOX" Or a = "LABEL" Or a = "OPTIONBUTTON" Or a = "CHECKBOX" Or a = "COMBOBOX" Then
	'Elemento.TabIndex = i
	''If a = "Label" Then If Control.BackStyle = 1 And BorderStyle = 1 Then Control =empty
	'i = i + 1
	'End If
	'Next
	'End Sub
	
	Public Sub LimpiarFormulario(ByRef Formulario As System.Windows.Forms.Form)
		Dim Control As System.Windows.Forms.Control
		Dim I As Short
		Dim a As String
		For	Each Control In Formulario.Controls
			'UPGRADE_WARNING: TypeName tiene un nuevo comportamiento. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			a = TypeName(Control)
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Control. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If a = "TextBox" Then Control = Nothing
			'UPGRADE_ISSUE: Control propiedad Control.BorderStyle no se actualizó. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Control.BackStyle. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If a = "Label" Then
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Control. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Control.BackStyle = 1 And Control.BorderStyle = 1 Then Control = Nothing
			End If
		Next Control
	End Sub
End Module