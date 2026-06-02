Option Strict Off
Option Explicit On
Module ModMallas
	Public Sub ReubicaObjetoEnMalla(ByRef Contenedor As AxMSHierarchicalFlexGridLib.AxMSHFlexGrid, ByRef Objetoo As Object, ByRef Fila As Short, ByRef Columna As Short)
		With Contenedor
			.Row = Fila
			.Col = Columna
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Objetoo.Left. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Objetoo.Left = VB6.PixelsToTwipsX(.Left) + .CellLeft
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Objetoo.Top. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Objetoo.Top = VB6.PixelsToTwipsY(.Top) + .CellTop
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Objetoo.Height. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Objetoo.Height = .CellHeight
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Objetoo.Width. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Objetoo.Width = .CellWidth
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Objetoo.Visible. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Objetoo.Visible = True
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Objetoo.SetFocus. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			Objetoo.SetFocus()
		End With
	End Sub
	
	Public Sub AumentaMalla(ByRef Malla As AxMSFlexGridLib.AxMSFlexGrid, ByRef ArtCodigo As String, ByRef ArtNombre As String, ByRef cantidad As Object, ByRef Talla As String, ByRef Color As String, ByRef Serie As String)
		Dim j As Short
		With Malla
			.Rows = .Rows + 1
			j = .Rows - 1
			.set_TextMatrix(j, 0, "")
			.set_TextMatrix(j, 1, ArtCodigo)
			.set_TextMatrix(j, 2, ArtNombre)
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto cantidad. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.set_TextMatrix(j, 3, cantidad)
			.set_TextMatrix(j, 4, Talla)
			.set_TextMatrix(j, 5, Color)
			.set_TextMatrix(j, 6, Serie)
			
		End With
	End Sub
	
	Public Sub AumentaMallaCierreCaja(ByRef Malla As AxMSFlexGridLib.AxMSFlexGrid, ByRef Registro As ADODB.Recordset, ByRef Tipo As String)
		Dim i As Object
		'/////// tipo
		'  0 = efectivo ,otros
		'  1 = tarjeta
		'  2 = documento
		'  3 = cheque
		With Registro
			
			Malla.Rows = Malla.Rows + 1
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto i. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			i = Malla.Rows - 1
			'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto i. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If Not IsDbNull(.Fields("doc_venabre").Value) Then Malla.set_TextMatrix(i, 0, .Fields("doc_venabre").Value)
			'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto i. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If Not IsDbNull(.Fields("doc_tipodoc").Value) Then Malla.set_TextMatrix(i, 1, .Fields("doc_tipodoc").Value)
			'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto i. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If Not IsDbNull(.Fields("doc_numero").Value) Then Malla.set_TextMatrix(i, 2, .Fields("doc_numero").Value)
			'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto i. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If Not IsDbNull(.Fields("Doc_fecha").Value) Then Malla.set_TextMatrix(i, 3, .Fields("Doc_fecha").Value)
			'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto i. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If Not IsDbNull(.Fields("DOC_HORAGRA").Value) Then Malla.set_TextMatrix(i, 4, .Fields("DOC_HORAGRA").Value)
			If Tipo = "0" Then
				'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto i. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Not IsDbNull(.Fields("doc_efectiv").Value) Then Malla.set_TextMatrix(i, 5, VB6.Format(System.Math.Round(CDbl(.Fields("doc_efectiv").Value * .Fields("doc_sygno").Value * -1), 2), "####,###,##0.00"))
			Else
				'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto i. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Not IsDbNull(.Fields("PAG_DESCRIP").Value) Then Malla.set_TextMatrix(i, 5, .Fields("PAG_DESCRIP").Value)
				'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto i. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Not IsDbNull(.Fields("pag_institu").Value) Then Malla.set_TextMatrix(i, 6, .Fields("pag_institu").Value)
				If Tipo = "1" Then
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto i. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Not IsDbNull(.Fields("pag_plan").Value) Then Malla.set_TextMatrix(i, 7, .Fields("pag_plan").Value)
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto i. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Not IsDbNull(.Fields("pag_numdoc").Value) Then Malla.set_TextMatrix(i, 8, .Fields("pag_numdoc").Value)
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto i. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Not IsDbNull(.Fields("pag_valor").Value) Then Malla.set_TextMatrix(i, 9, VB6.Format(System.Math.Round(CDbl(.Fields("pag_valor").Value), 2), "####,###,##0.00"))
				Else
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto i. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Not IsDbNull(.Fields("pag_numdoc").Value) Then Malla.set_TextMatrix(i, 7, .Fields("pag_numdoc").Value)
					'UPGRADE_WARNING: Se detectó el uso de Null/IsNull(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto i. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If Not IsDbNull(.Fields("pag_valor").Value) Then Malla.set_TextMatrix(i, 8, VB6.Format(System.Math.Round(CDbl(.Fields("pag_valor").Value), 2), "####,###,##0.00"))
				End If
			End If
		End With
	End Sub
	Public Function numcol(ByRef Malla As AxMSFlexGridLib.AxMSFlexGrid, ByRef nombre As String) As Short
		Dim nomcol As Object
		Dim i As Object
		Dim nom As String
		nom = UCase(nombre)
		numcol = 0
		For i = 1 To Malla.Cols - 1
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto i. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If UCase(Malla.get_TextMatrix(0, i)) = nom Then
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto i. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto nomcol. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				nomcol = i : Exit For
			End If
		Next i
	End Function
End Module