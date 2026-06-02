Option Strict Off
Option Explicit On
Friend Class AdcAutorizacionesSri
	Inherits System.Windows.Forms.Form
	Dim TablaSriPro As ADODB.Recordset
	Dim CampoValido As Boolean
	Dim Nrodatos As Short
	Dim DocEstab, TipoDocSri, codigo, TipoDocAdc, DocEmis As String
	Dim DocSecuencial As Integer
	Dim Saltar As Boolean
	Dim DatoAnt As String
	Dim ActColumna, ActPosicion As Short
	Dim DatoSalida, DatoControl As Short
	Dim opAlex As New ManDirct.DirectorioAlex
	Dim NombreDat As String
	Dim entrada As Boolean
	Dim SinIvaret As Boolean
	Dim Act1 As Boolean
	Dim queauto As String
	Dim DondeCrea As Integer
	Public Function INICreaAutDoc(ByRef QUECODIGO As String, ByRef TipDocSri As String, ByRef TipDocAdc As String, ByRef Estab As String, ByRef Emis As String) As String
		If Emp.Sri Then
			codigo = QUECODIGO
			TipoDocSri = TipDocSri
			TipoDocAdc = TipDocAdc
			DocEstab = Estab
			DocEmis = Emis
			entrada = True
			Me.ShowDialog()
			INICreaAutDoc = queauto
		End If
	End Function
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		If ConfirmaSalir Then Me.Close()
	End Sub
	
	Private Sub LeerDocumentoSRI(ByRef DocTip As String)
		Dim rs As New ADODB.Recordset
		Dim sSQL As String
		'cambiar on error Resume Next
		If rs.State = 1 Then rs.Close()
		sSQL = "Select *  From  sritipoDEcomprobante Where  CODIGO = " & DocTip & " "
		' ssql = "select Opc_documento,Opc_nombre from AdcOpc where opc_documento = '" & DocTip & "'"
		rs.Open(sSQL, ConxSyscod, ADOR.CursorTypeEnum.adOpenForwardOnly, ADOR.LockTypeEnum.adLockReadOnly)
		If rs.EOF Then rs.Close() : NombreDat = "" : Exit Sub
		NombreDat = rs.Fields("TipoComprobante").Value
		rs.Close()
	End Sub
	
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		Dim prog As New PrntDax.ImpMalla
		prog.ImprimirMalla(Malla, 66, 10, "Autorizaciones del SRI Proveedor: " & txtcodigo.Text & " " & txtnom.Text, 60, 0)
		'UPGRADE_NOTE: El objeto prog no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		prog = Nothing
	End Sub
	
	Private Sub AdcAutorizacionesSri_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		TablaSriPro = New ADODB.Recordset
		Dim i As Short
		Dim prog As New DaxLib.DaxLibMalla
		prog.ColorF(Me)
		'UPGRADE_NOTE: El objeto prog no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		prog = Nothing
		
		'cambiar on error Resume Next
		
		With Malla
			.DatoControl = 1
			Nrodatos = 10
			DatoSalida = 9
			With Malla
				.Cols = Nrodatos + 1
				.Rows = 2
				.FixedCols = 1
				.FixedRows = 1
				.Row = 0
				For i = 0 To .Cols - 1
					.Col = i
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.LaMalla.CellFontBold. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.LaMalla.CellFontBold = True
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.LaMalla.CellAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.LaMalla.CellAlignment = 4
					.set_ColWidth(i, 0)
					.set_ColPick(i, False)
				Next i
				
				.set_ColAlignment(0, 7)
				
				.set_ColWidth(0, 400)
				.set_ColWidth(1, 500)
				.set_ColWidth(2, 3500)
				.set_ColWidth(3, 1000)
				.set_ColWidth(4, 500)
				.set_ColWidth(5, 500)
				.set_ColWidth(6, 1000)
				.set_ColWidth(7, 1000)
				.set_ColWidth(8, 1000)
				.set_ColWidth(9, 0)
				
				' si es mayor que 1000 es para que no sea editable es 1000 + el numero de caracterse de input
				.set_ColData(1, 10)
				.set_ColData(2, 1060)
				.set_ColData(3, 10)
				.set_ColData(4, 3)
				.set_ColData(5, 3)
				.set_ColData(6, 7)
				.set_ColData(7, 7)
				.set_ColData(8, 10)
				.set_ColData(9, 12)
				
				
				.set_TextMatrix(0, 0, "Nro")
				.set_TextMatrix(0, 1, "Tipo")
				.set_TextMatrix(0, 2, "Comprobante SRI")
				.set_TextMatrix(0, 3, "Autoriz.")
				.set_TextMatrix(0, 4, "Estb.")
				.set_TextMatrix(0, 5, "Emis.")
				.set_TextMatrix(0, 6, "Inicia")
				.set_TextMatrix(0, 7, "Final")
				.set_TextMatrix(0, 8, "ValeHasta")
				.set_TextMatrix(0, 9, "DocAdcom")
				
				.Row = 1
				.Col = 1
				.NumerarMalla(True, False)
			End With
			
			If entrada Then
				txtcodigo.Text = codigo
				buscacli()
				Frame2.Enabled = False
				If TipoDocSri > "" Then
					With Malla
						.Rows = .Rows + 1
						.Row = .Rows - 1
						.set_TextMatrix(.Row, 1, TipoDocSri)
						LeerDocumentoSRI((TipoDocSri))
						.set_TextMatrix(.Row, 2, NombreDat)
						.set_TextMatrix(.Row, 4, DocEstab)
						.set_TextMatrix(.Row, 5, DocEmis)
						.set_TextMatrix(.Row, 4, DocEstab)
						.set_TextMatrix(.Row, 9, TipoDocAdc)
						.Col = 3
						.Focus()
					End With
				End If
			End If
		End With
		ReordenaMalla(Malla)
		
Saliendo: 
	End Sub
	
	Private Sub CargarDatos()
		'cambiar on error Resume Next
		
		Dim i As Short
		With Malla
			.Rows = 2
			.Row = 1
			.set_TextMatrix(1, 0, 1)
			For i = 1 To .Cols - 1
				.set_TextMatrix(1, i, "")
			Next i
		End With
		'BorraLineaMalla
		TablaSriPro = New ADODB.Recordset
		If TablaSriPro.State = 1 Then TablaSriPro.Close()
		TablaSriPro.Open("select * from autorizaciones WHERE  codigoproveedor = '" & codigo & "'", ConxSri, ADOR.CursorTypeEnum.adOpenDynamic, ADOR.LockTypeEnum.adLockOptimistic)
		With TablaSriPro
			i = Malla.FixedRows
			Do While Not .EOF
				Malla.Rows = i + 1
				Malla.set_TextMatrix(i, 0, i + 1)
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Malla.set_TextMatrix(i, 1, CorrijeNulo(.Fields("TipoComprobante"))) : LeerDocumentoSRI((CorrijeNulo(.Fields("TipoComprobante")))) : Malla.set_TextMatrix(i, 2, NombreDat)
				Malla.set_TextMatrix(i, 3, CorrijeNuloN(.Fields("NroAutorizacion")))
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Malla.set_TextMatrix(i, 4, CorrijeNulo(.Fields("SerieComprobante")))
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Malla.set_TextMatrix(i, 5, CorrijeNulo(.Fields("SerieCPbteEmision")))
				Malla.set_TextMatrix(i, 6, CorrijeNuloN(.Fields("NumeroInicial")))
				Malla.set_TextMatrix(i, 7, CorrijeNuloN(.Fields("NumeroFinal")))
				Malla.set_TextMatrix(i, 8, CorrijeNuloF(.Fields("FechaTope")))
				'malla.TextMatrix(i, 9) = CorrijeNulo(!tipocomprobanteadcom)
				i = i + 1
				.MoveNext()
			Loop 
			.Close()
			
		End With
		Malla.NumerarMalla(True, False)
	End Sub
	
	Private Sub btAceptar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btAceptar.Click
		'cambiar on error Resume Next
		'cambiar on error GoTo 0
		Dim i As Short
		If txtcodigo.Text = "" Then MsgBox("Debe registrar el proveedor", MsgBoxStyle.Critical, "Autorizacion SRI  ") : txtcodigo.Focus() : Exit Sub
		ConxSri.Execute("delete from autorizaciones  Where codigoproveedor='" & codigo & "'  ")
		If TablaSriPro.State = 1 Then TablaSriPro.Close()
		TablaSriPro.Open("select * from autorizaciones WHERE  codigoproveedor = '" & codigo & "'", ConxSri, ADOR.CursorTypeEnum.adOpenDynamic, ADOR.LockTypeEnum.adLockOptimistic)
		With TablaSriPro
			For i = Malla.FixedRows To Malla.Rows - 1
				If Malla.get_TextMatrix(i, 1) > "" Then
					.AddNew()
					.Fields("CodigoProveedor").Value = codigo
					.Fields("TipoComprobante").Value = Malla.get_TextMatrix(i, 1)
					.Fields("SerieComprobante").Value = Malla.get_TextMatrix(i, 4)
					.Fields("SerieCPbteEmision").Value = Malla.get_TextMatrix(i, 5)
					.Fields("NroAutorizacion").Value = Malla.get_TextMatrix(i, 3)
					.Fields("NumeroInicial").Value = Malla.get_TextMatrix(i, 6)
					.Fields("NumeroFinal").Value = Malla.get_TextMatrix(i, 7)
					.Fields("FechaTope").Value = CorrijeNuloF(Malla.get_TextMatrix(i, 8))
					'!tipocomprobanteadcom = malla.TextMatrix(i, 9)
					.Update()
				End If
			Next i
			.Close()
		End With
		Limpiar()
		If entrada Then Me.Close()
	End Sub
	Private Sub Limpiar()
		Dim i, j As Short
		With Malla
			For i = 1 To .Rows - 1
				For j = 0 To .Cols - 1
					Malla.set_TextMatrix(i, j, "")
				Next j
			Next i
		End With
		txtcodigo.Text = ""
		txtnom.Text = ""
		Malla.Rows = 2
	End Sub
	Private Sub btncliente_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btncliente.Click
		'AuxAlf3 = TxtCodigo.Text
		buscarclientes()
	End Sub
	
	Private Sub AdcAutorizacionesSri_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
		'cambiar on error Resume Next
		'Dim i As Long
		'If Val(Malla.TextMatrix(Malla.Rows - 2, 1)) > 0 Then i = Malla.Rows - 1 Else If Malla.Rows - 1 > 2 Then i = Malla.Rows - 2
		'If i = 0 Then i = 1
		If DondeCrea > Malla.Rows - 1 Then DondeCrea = Malla.Rows - 1
		queauto = Malla.get_TextMatrix(DondeCrea, 3)
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub malla_CambiaMalla(ByVal eventSender As System.Object, ByVal eventArgs As AxDaxGrid.__DaxGridIn_CambiaMallaEvent) Handles malla.CambiaMalla
		DondeCrea = eventArgs.Row
	End Sub
	
	Sub malla_KeyDownEvent(ByVal eventSender As System.Object, ByVal eventArgs As AxDaxGrid.__DaxGridIn_KeyDownEvent) Handles malla.KeyDownEvent
		If Malla.Rows < 2 Then Exit Sub
		If eventArgs.keycode >= System.Windows.Forms.Keys.F1 And eventArgs.keycode <= System.Windows.Forms.Keys.F12 Then FuncionesEspeciales((Malla.Col), eventArgs.keycode, eventArgs.dato)
	End Sub
	
	Private Sub txtCodigo_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown
		Dim keycode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If keycode = System.Windows.Forms.Keys.F2 Then buscarclientes()
		If keycode = System.Windows.Forms.Keys.Return Then buscacli()
	End Sub
	Public Sub buscarclientes()
		Dim buscaclien As New ManDirct.BuscaClien
		
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto buscaclien.IniBuscaCliOPro. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		codigo = buscaclien.IniBuscaCliOPro("P", codigo)
		'UPGRADE_NOTE: El objeto buscaclien no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		buscaclien = Nothing
		buscacli()
		'UPGRADE_NOTE: El objeto buscaclien no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		buscaclien = Nothing
	End Sub
	
	Public Sub buscacli()
		'cambiar on error Resume Next
		Dim sW1 As Boolean
		If codigo = "" Then codigo = txtcodigo.Text
		If codigo = "0" Then
			txtcodigo.Visible = False
			txtcodigo.Text = "0"
			btncliente.Visible = 0
			txtnom.Text = Emp.Nombre
		Else
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto opAlex.CargarAlex. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			sW1 = opAlex.CargarAlex(codigo, False)
			If sW1 = False Then
				txtnom.Text = ""
				txtcodigo.Text = ""
				codigo = ""
				Exit Sub
			End If
			
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto opAlex.CiRuc. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtcodigo.Text = opAlex.CiRuc
			codigo = txtcodigo.Text 'opAlex.codigo
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto opAlex.NombreImpresion. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			txtnom.Text = opAlex.NombreImpresion
		End If
		CargarDatos()
	End Sub
	
	
	'
	''' Rutinas para manejo de mallas
	'
	
	'Private Function ValidarDato(Index As Integer) As Boolean
	'Dim i As Integer, Posicion As Integer, Aux As String
	'ValidarDato = True
	'Aux = ""
	''cambiar on error  Resume Next
	''Dim Articulo As String, mal As Integer
	'Select Case Index
	'Case 1
	'If dato = "" Then If ActPosicion < Malla.Rows - 1 Then ValidarDato = QuiereEliminar: Exit Function
	'If dato = "" And ActPosicion = Malla.Rows - 1 Then BorraLineaMalla: ValidarDato = True: Exit Function
	'        LeerDocumentoSRI dato
	'        If NombreDat = "" Then
	'           ValidarDato = False
	'           MsgBox "Tipo de comprobante del SRI no existe", vbCritical
	'           BorraLineaMalla
	'        Else
	'           Malla.TextMatrix(ActPosicion, 2) = NombreDat
	'        End If
	'Case 7
	'        If val(dato) < val(Malla.TextMatrix(Malla.Row, 6)) Then ValidarDato = False: MsgBox "El intervalo de númeración del documento esta errado"
	'Case 8
	'        If Not IsDate(dato) Then
	'            ValidarDato = False
	'            MsgBox "Fecha de valides de autorizacion errada", vbCritical, "Autorizaciones SRI"
	'            Malla.TextMatrix(ActPosicion, 7) = ""
	'        End If
	''Case 8
	''        LeerDocumentoAdcom dato
	''        If NombreDat = "" Then
	''           MsgBox "Tipo de documento del sistema no existe", vbCritical, "Autorizaciones SRI"
	''           ValidarDato = False
	''           malla.TextMatrix(ActPosicion, 8) = ""
	''           malla.TextMatrix(ActPosicion, 9) = ""
	''        Else
	''           malla.TextMatrix(ActPosicion, 9) = NombreDat
	''        End If
	'End Select
	'If ValidarDato = False Then dato.SetFocus: dato = "": Exit Function
	'End Function
	'
	Private Sub FuncionesEspeciales(ByRef Index As Short, ByRef keycode As Short, ByRef dato As String)
		Select Case Index
			Case 1
				If keycode = System.Windows.Forms.Keys.F2 Then dato = BuscarDocumentoSri
				If dato > "" Then keycode = System.Windows.Forms.Keys.Return
			Case 8
				If keycode = System.Windows.Forms.Keys.F2 Then dato = CStr(QueFecha)
			Case 9
				If keycode = System.Windows.Forms.Keys.F2 Then dato = BuscarDocumento
				If dato > "" Then keycode = System.Windows.Forms.Keys.Return
		End Select
	End Sub
	
	Private Function BuscarDocumentoSri() As String
		Dim DCodigo, DNombre As String
		'If Sistema = "ADC" Then
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto opAlex.TipoId. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		BuscDocSri.BuscaDoc(VB6.Format(Today, "mm/yyyy"), 1, 0, opAlex.TipoId, DCodigo, DNombre)
		BuscarDocumentoSri = DCodigo
		BuscDocSri.Close()
		'UPGRADE_NOTE: El objeto BuscDocSri no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		BuscDocSri = Nothing
		'End If
	End Function
	
	Private Sub dato_Change()
		Dim n As Short
		'If ActColumna = 1 And Dato = "" Then
		'   For n = 2 To Malla.Cols - 1
		'   Malla.TextMatrix(Malla.Row, n) = ""
		'   Next n
		'End If
	End Sub
	
	''***********************************************************************************
	''
	''
	'' rutinas de manejo de pantalla de ingreso de datos
	''
	''
	''***********************************************************************************
	'
	'Private Sub Form_KeyDown(KeyCode As Integer, Shift As Integer)
	'If KeyCode = vbKeyEscape Then If ConfirmaSalir = True Then Unload Me
	'End Sub
	'
	'Sub Dato_KeyPress(KeyAscii As Integer)
	'   ' Elimina los retornos para quitar los pitidos.
	'   If KeyAscii = Asc(vbCr) Then KeyAscii = 0
	'   If Malla.ColAlignment(Malla.Col) = 7 Then KeyAscii = SoloNumeros(KeyAscii)
	'   'If malla.col = 1 Then Label1.Visible = True: dcTipCom.Visible = True
	'End Sub
	'
	'Sub dato_KeyDown(KeyCode As Integer, Shift As Integer)
	'Dim Index As Integer
	'If KeyCode >= vbKeyF1 And KeyCode <= vbKeyF12 Then FuncionesEspeciales Malla.Col, KeyCode: If KeyCode <> vbKeyReturn Then Exit Sub
	'EditKeyCode Malla, dato, KeyCode, Shift, DatoControl, DatoSalida
	'End Sub
	'
	'Private Sub dato_LostFocus()
	'If Saltar = False And dato.Visible = True Then
	'   Malla = dato
	'   If ValidarDato(ActColumna) = False Then
	'        dato.Visible = True
	'        dato.SetFocus
	'        DoEvents
	'   Else
	'        dato.Visible = False
	'        'If ActColumna = 1 Then Label1.Visible = False: dcTipCom.Visible = False
	'   End If
	'End If
	'End Sub
	'
	'Sub malla_Scroll()
	'If dato.Visible = True Then dato_KeyDown vbKeyReturn, 0
	'End Sub
	'Sub malla_LeaveCell()
	'   If dato.Visible = False Then Exit Sub
	'   Malla = dato
	'   dato.Visible = False
	'End Sub
	
	'Sub malla_KeyDown(KeyCode As Integer, Shift As Integer)
	'Dim codigo As String
	'If Malla.Rows = 0 Then Exit Sub
	''ActPosicion = malla.Row
	''ActColumna = malla.col
	'codigo = Malla.TextMatrix(Malla.Row, 1)
	'If KeyCode = vbKeyDelete Then
	'    BorrarLineaMalla Malla
	'ElseIf KeyCode = vbKeyInsert Then
	'    InsertarLineaMalla Malla, DatoControl
	'ElseIf KeyCode >= vbKeyF2 And KeyCode <= vbKeyF12 Then
	'    Malla_DblClick
	'    DoEvents
	'    dato_KeyDown KeyCode, 0
	'End If
	'End Sub
	'Sub Malla_KeyPress(KeyAscii As Integer)
	'   MallaEdit Malla, dato, KeyAscii, DatoControl
	'   ActPosicion = Malla.Row
	'   ActColumna = Malla.col
	'End Sub
	'Sub Malla_DblClick()
	'   Malla_KeyPress 32
	'End Sub
	'Function Fgi(R As Integer, C As Integer) As Integer
	'   Fgi = C + Malla.Cols * R
	'End Function
	'Sub BorraLineaMalla()
	'Dim Pos As Integer, i As Integer
	'Pos = Malla.Row
	'For i = Malla.FixedCols To Malla.Cols - 1
	' Malla.TextMatrix(Pos, i) = ""
	'Next
	'End Sub
	
	'Private Sub dcTipCom_Change()
	'If Malla.Row > 0 And Malla.Row < Malla.Rows And Malla.col = 1 Then
	'Malla.textmatrix(Malla.col, 1) = dcTipCom.BoundText
	'Malla.textmatrix(Malla.col, 2) = dcTipCom.Text
	''dcTipCom.Visible = False
	'Malla_DblClick
	''dato.Visible = True
	''dato.SetFocus
	'End If
	'End Sub
	
	'Private Sub LeerDocumentoAdcom(DocTip As String)
	'Dim rs As New ADODB.Recordset, sSQL As String
	''cambiar on error Resume Next
	' If Not ConxAdcom Is Nothing And ConxAdcom > "" Then
	' If rs.State = 1 Then rs.Close
	' sSQL = "select Opc_documento,Opc_nombre from AdcOpc where opc_documento = '" & DocTip & "'"
	' rs.Open sSQL, ConxAdcom, adOpenForwardOnly, adLockReadOnly
	'If rs.EOF Then rs.Close: NombreDat = "": Exit Sub
	'NombreDat = rs!opc_nombre
	'rs.Close
	'End If
	'End Sub
	
	'dtTipCom.CommandType = adCmdText
	'dtTipCom.ConnectionString = strconxdaxsys
	'dtTipCom.RecordSource = "Select *  From  sritipocomprobante Where  idsritipocomprobante <>'16' or idsritipocomprobante <>'17' or idsritipocomprobante <>'18' "
	'dtTipCom.Refresh
	'
	'If dtTipCom.Recordset.RecordCount > 0 Then
	'     dcTipCom.BoundText = dtTipCom.Recordset!idsritipocomprobante
	'     dcTipCom.Text = dtTipCom.Recordset!Descripcion
	'End If
	
	Private Function BuscarDocumento() As String
		Dim DCodigo, DNombre As String
		If Sistema = "ADC" Or Sistema = "ADS" Or Sistema = "ERP" Then
			BuscDocAdcom.BuscaDocAdcom("C", DCodigo, DNombre)
			BuscarDocumento = DCodigo
			BuscDocAdcom.Close()
			'UPGRADE_NOTE: El objeto BuscDocAdcom no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			BuscDocAdcom = Nothing
		End If
	End Function
	
	'UPGRADE_WARNING: Form evento AdcAutorizacionesSri.Activate tiene un nuevo comportamiento. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
	Private Sub AdcAutorizacionesSri_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		If AdcomConSri = False And Act1 = False Then Me.Close()
		Act1 = True
	End Sub
End Class