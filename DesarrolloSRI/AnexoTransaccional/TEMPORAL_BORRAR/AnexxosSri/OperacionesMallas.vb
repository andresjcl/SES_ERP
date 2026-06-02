Option Strict Off
Option Explicit On
Module OperacionesMallas
	Public Sub AcumularLineasMalla(ByRef Malla As Object, ByVal Col1 As Short, ByVal Col2 As Short, Optional ByRef ConSigno As Boolean = False)
		Dim j, i, S As Short
		Dim SS As Short
		Dim QueSigno As Integer
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If Malla.Rows < 3 Then Exit Sub
		With Malla
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Cols. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			SS = .Cols - 1
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Col. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Col = Col1
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Sort. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Sort = 7
			'.Refresh
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.FixedRows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			i = .FixedRows
			j = i + 1
			S = 0
			Do Until S = 1
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If ConSigno Then .TextMatrix(i, Col2) = Val(.TextMatrix(i, Col2)) * Val(.TextMatrix(i, SS))
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If .TextMatrix(i, Col1) = "" Then
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.RemoveItem. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.RemoveItem(i)
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf .TextMatrix(i, Col1) = .TextMatrix(j, Col1) Then 
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If .TextMatrix(i, Col2) = "" Then .TextMatrix(i, Col2) = 0
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					If .TextMatrix(j, Col2) = "" Then .TextMatrix(j, Col2) = 0
					If ConSigno Then
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						QueSigno = Val(.TextMatrix(j, SS))
						If QueSigno = 0 Then QueSigno = 1
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						.TextMatrix(i, Col2) = Val(.TextMatrix(i, Col2)) + Val(.TextMatrix(j, Col2)) * QueSigno
					Else
						'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						.TextMatrix(i, Col2) = CDbl(.TextMatrix(i, Col2)) + CDbl(.TextMatrix(j, Col2))
					End If
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.RemoveItem. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.RemoveItem(j)
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Refresh. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.Refresh()
				Else
					i = i + 1
					j = i + 1
				End If
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If j > .Rows - 1 Then S = 1
			Loop 
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ReordenaMalla(Malla)
		End With
	End Sub
	
	Public Sub ReordenaMalla(ByRef Malla As System.Windows.Forms.Control)
		Dim i As Short
		With Malla
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Redraw. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Redraw = False
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Rows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.FixedRows. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			For i = .FixedRows To .Rows - 1
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.TextMatrix. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				.TextMatrix(i, 0) = i
			Next 
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.Redraw. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			.Redraw = True
		End With
	End Sub
End Module