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
	Dim opAlex As New DirectorioAlex
	Dim NombreDat As String
	Dim entrada As Boolean
	Dim SinIvaret As Boolean
	Dim Act1 As Boolean
	Dim queauto As String
	Dim DondeCrea As Integer
	Dim LibDigDat As New DaxLib.DaxLibDigDato
	
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
		Dim ssql As String
		On Error Resume Next
		DocTip = CStr(Val(DocTip))
		If rs.State = 1 Then rs.Close()
		ssql = "Select *  From  sritipoDEcomprobante Where  CODIGO = " & DocTip & " "
		' ssql = "select Opc_documento,Opc_nombre from AdcOpc where opc_documento = '" & DocTip & "'"
		rs.Open(ssql, ConxSyscod, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)
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
		Dim I As Short
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
				For I = 0 To .Cols - 1
					.Col = I
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.LaMalla.CellFontBold. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.LaMalla.CellFontBold = True
					'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto Malla.LaMalla.CellAlignment. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					.LaMalla.CellAlignment = 4
					.set_ColWidth(I, 0)
					.set_ColPick(I, False)
				Next I
				
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
				.set_ColData(3, 40)
				.set_ColData(4, 3)
				.set_ColData(5, 3)
				.set_ColData(6, 12)
				.set_ColData(7, 12)
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
		'ReordenaMalla Malla
		
Saliendo: 
	End Sub
	
	Private Sub CargarDatos()
		'cambiar on error Resume Next
		
		Dim I As Short
		With Malla
			.Rows = 2
			.Row = 1
			.set_TextMatrix(1, 0, 1)
			For I = 1 To .Cols - 1
				.set_TextMatrix(1, I, "")
			Next I
		End With
		'BorraLineaMalla
		TablaSriPro = New ADODB.Recordset
		If TablaSriPro.State = 1 Then TablaSriPro.Close()
		TablaSriPro.Open("select * from autorizaciones WHERE  codigoproveedor = '" & codigo & "'", ConxSri, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		With TablaSriPro
			I = Malla.FixedRows
			Do While Not .EOF
				Malla.Rows = I + 1
				Malla.set_TextMatrix(I, 0, I + 1)
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto LibDigDat.CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Malla.set_TextMatrix(I, 1, LibDigDat.CorrijeNulo(.Fields("TipoComprobante"))) : LeerDocumentoSRI((CorrijeNulo(.Fields("TipoComprobante")))) : Malla.set_TextMatrix(I, 2, NombreDat)
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto LibDigDat.CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Malla.set_TextMatrix(I, 3, LibDigDat.CorrijeNulo(.Fields("NroAutorizacion")))
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto LibDigDat.CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Malla.set_TextMatrix(I, 4, LibDigDat.CorrijeNulo(.Fields("seriecomprobante")))
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto LibDigDat.CorrijeNulo(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				Malla.set_TextMatrix(I, 5, LibDigDat.CorrijeNulo(.Fields("seriecpbteemision")))
				Malla.set_TextMatrix(I, 6, LibDigDat.CorrijeNuloN(.Fields("NumeroInicial")))
				Malla.set_TextMatrix(I, 7, LibDigDat.CorrijeNuloN(.Fields("NumeroFinal")))
				Malla.set_TextMatrix(I, 8, LibDigDat.CorrijeNuloF(.Fields("FechaTope")))
				'malla.TextMatrix(i, 9) = libdigdat.CorrijeNulo(!tipocomprobanteadcom)
				I = I + 1
				.MoveNext()
			Loop 
			.Close()
			
		End With
		Malla.NumerarMalla(True, False)
	End Sub
	
	Private Sub btAceptar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btAceptar.Click
		'cambiar on error Resume Next
		'cambiar on error GoTo 0
		Dim I As Short
		If txtcodigo.Text = "" Then MsgBox("Debe registrar el proveedor", MsgBoxStyle.Critical, "Autorizacion SRI  ") : txtcodigo.Focus() : Exit Sub
		ConxSri.Execute("delete from autorizaciones  Where codigoproveedor='" & codigo & "'  ")
		If TablaSriPro.State = 1 Then TablaSriPro.Close()
		TablaSriPro.Open("select * from autorizaciones WHERE  codigoproveedor = '" & codigo & "'", ConxSri, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic)
		With TablaSriPro
			For I = Malla.FixedRows To Malla.Rows - 1
				If Malla.get_TextMatrix(I, 1) > "" Then
					.AddNew()
					.Fields("CodigoProveedor").Value = codigo
					.Fields("TipoComprobante").Value = Malla.get_TextMatrix(I, 1)
					.Fields("seriecomprobante").Value = Malla.get_TextMatrix(I, 4)
					.Fields("seriecpbteemision").Value = Malla.get_TextMatrix(I, 5)
					.Fields("NroAutorizacion").Value = Malla.get_TextMatrix(I, 3)
					.Fields("NumeroInicial").Value = Malla.get_TextMatrix(I, 6)
					.Fields("NumeroFinal").Value = Malla.get_TextMatrix(I, 7)
					.Fields("FechaTope").Value = LibDigDat.CorrijeNuloF(Malla.get_TextMatrix(I, 8))
					'!tipocomprobanteadcom = malla.TextMatrix(i, 9)
					.Update()
				End If
			Next I
			.Close()
		End With
		Limpiar()
		If entrada Then Me.Close()
	End Sub
	Private Sub Limpiar()
		Dim I, j As Short
		With Malla
			For I = 1 To .Rows - 1
				For j = 0 To .Cols - 1
					Malla.set_TextMatrix(I, j, "")
				Next j
			Next I
		End With
		txtcodigo.Text = ""
		txtnom.Text = ""
		Malla.Rows = 2
	End Sub
	Private Sub btncliente_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btncliente.Click
		buscarclientes()
	End Sub
	
	Private Sub AdcAutorizacionesSri_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
		'cambiar on error Resume Next
		If DondeCrea > Malla.Rows - 1 Then DondeCrea = Malla.Rows - 1
		queauto = Malla.get_TextMatrix(DondeCrea, 3)
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub malla_CambiaMalla(ByVal eventSender As System.Object, ByVal eventArgs As AxDaxGrid.__DaxGridIn_CambiaMallaEvent) Handles malla.CambiaMalla
		DondeCrea = eventArgs.Row
	End Sub
	
	Sub malla_KeyDownEvent(ByVal eventSender As System.Object, ByVal eventArgs As AxDaxGrid.__DaxGridIn_KeyDownEvent) Handles malla.KeyDownEvent
		If Malla.Rows < 2 Then Exit Sub
		If eventArgs.KeyCode >= System.Windows.Forms.Keys.F1 And eventArgs.KeyCode <= System.Windows.Forms.Keys.F12 Then FuncionesEspeciales((Malla.Col), eventArgs.KeyCode, eventArgs.dato)
	End Sub
	
	Private Sub txtCodigo_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If KeyCode = System.Windows.Forms.Keys.F2 Then buscarclientes()
		If KeyCode = System.Windows.Forms.Keys.Return Then buscacli()
	End Sub
	Public Sub buscarclientes()
		Dim ManDirct As Object
		'UPGRADE_ISSUE: ManDirct.BuscaClien objeto no se actualizó. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
		Dim BuscaClien As ManDirct.BuscaClien = New ManDirct.BuscaClien
		
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto BuscaClien.IniBuscaCliOPro. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		codigo = BuscaClien.IniBuscaCliOPro("T", codigo)
		'UPGRADE_NOTE: El objeto BuscaClien no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		BuscaClien = Nothing
		buscacli()
		'UPGRADE_NOTE: El objeto BuscaClien no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		BuscaClien = Nothing
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
			sW1 = opAlex.CargarAlex(codigo, False)
			If sW1 = False Then
				txtnom.Text = ""
				txtcodigo.Text = ""
				codigo = ""
				Exit Sub
			End If
			
			txtcodigo.Text = opAlex.CiRuc
			codigo = txtcodigo.Text 'opAlex.codigo
			txtnom.Text = opAlex.NombreImpresion
		End If
		CargarDatos()
	End Sub
	
	Private Sub FuncionesEspeciales(ByRef Index As Short, ByRef KeyCode As Short, ByRef dato As String)
		Select Case Index
			Case 1
				If KeyCode = System.Windows.Forms.Keys.F2 Then dato = BuscarDocumentoSri
				If dato > "" Then KeyCode = System.Windows.Forms.Keys.Return
			Case 8
				If KeyCode = System.Windows.Forms.Keys.F2 Then dato = CStr(QueFecha)
			Case 9
				If KeyCode = System.Windows.Forms.Keys.F2 Then dato = BuscarDocumento
				If dato > "" Then KeyCode = System.Windows.Forms.Keys.Return
		End Select
	End Sub
	
	Private Function BuscarDocumentoSri() As String
		Dim DCodigo, DNombre As String
		BuscDocSri.BuscaDoc(VB6.Format(Today, "mm/yyyy"), 1, 0, (opAlex.TipoId), DCodigo, DNombre)
		BuscarDocumentoSri = DCodigo
		BuscDocSri.Close()
		'UPGRADE_NOTE: El objeto BuscDocSri no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		BuscDocSri = Nothing
	End Function
	
	Private Function BuscarDocumento() As String
		Dim BuscDocAdcom As Object
		Dim DCodigo, DNombre As String
		If Sistema.Value = "ADC" Or Sistema.Value = "ADS" Or Sistema.Value = "ERP" Then
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto BuscDocAdcom.BuscaDocAdcom. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			BuscDocAdcom.BuscaDocAdcom("C", DCodigo, DNombre)
			BuscarDocumento = DCodigo
			'UPGRADE_ISSUE: BuscDocAdcom de descarga no se actualizó. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="875EBAD7-D704-4539-9969-BC7DBDAA62A2"'
			Unload(BuscDocAdcom)
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