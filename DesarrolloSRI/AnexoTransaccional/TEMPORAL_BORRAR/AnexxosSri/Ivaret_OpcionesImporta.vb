Option Strict Off
Option Explicit On
Friend Class OpcionesImporta
	Inherits System.Windows.Forms.Form
	Dim QueBase As Short
	Dim RecSet As New ADODB.Recordset
	Dim Malla As AxMSHierarchicalFlexGridLib.AxMSHFlexGrid
	Dim QueError As Single
	Dim TipTra As Short
	Dim NumDat(10) As Short
	Dim Saltar As Boolean
	
	Public Function ImportarDatos(ByRef MallaDatos As AxMSHierarchicalFlexGridLib.AxMSHFlexGrid, ByRef TipoTran As Short) As Boolean
		On Error GoTo hayError
		Malla = MallaDatos
		TipTra = TipoTran
		Malla.Clear()
		Malla.Col = 0
		Malla.Rows = 2
		ImportarDatos = False
		Me.ShowDialog()
		'MallaDatos = malla
		If Malla.Col > 1 Then ImportarDatos = True
		Exit Function
hayError: 
		ControlaErrores(("importar Datos"))
	End Function
	
	Private Sub BtFechaINI_Click()
		TxtFechaIni.Text = CStr(QueFecha)
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		If MsgBox("CONFIRMA CANCELAR LA IMPORTACION DE ARCHIVOS", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
		Me.Close()
	End Sub
	
	Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
		'cambiar on error GoTo HayErrores
		'If WbHojaSri Is Nothing And Donde = "E" Then
		'    Setup Text3
		'    LlenarHojas Text1
		'End If
		'UPGRADE_WARNING: Screen propiedad Screen.MousePointer tiene un nuevo comportamiento. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		CargarArchivo()
		'UPGRADE_WARNING: Screen propiedad Screen.MousePointer tiene un nuevo comportamiento. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		If QueError = 1 Then
			MsgBox("Existe error en la importación del archivo" & vbCr & "Registre los datos de conexión", MsgBoxStyle.Critical)
			Malla.Clear()
			Malla.set_Cols( , 2)
			Malla.Rows = 2
			Exit Sub
		End If
		ArreglaMalla(Malla, TipTra)
		'If QueError = 2 Then
		'   Ms" & vbCr & "Revise loas datos importados y las bases de datos de origen ", vbCritical
		'End If
		Me.Close()
		Exit Sub
HayErrores: 
		MsgBox("Error Ingreso inicial" & Err.Number & "-" & Err.Description)
		Resume Next
	End Sub
	
	Private Sub CargarArchivo()
		Dim ConxAccess As New ADODB.Connection
		Dim rs As New ADODB.Recordset
		Dim fechass, Consulta, Conectar As String
		Dim Consulta2 As String
		'cambiar on error GoTo HayErrores
		If TipTra = 0 Then MsgBox("No se ha escojido ningun tipo de datos para importar") : Exit Sub
		QueError = 0
		Malla.Rows = 3
		Malla.FixedRows = 2
		Malla.FixedCols = 1
		Consulta = ""
		TxtFechaIni.Text = VB6.Format(TxtFechaIni.Text, "dd/mm/yyyy")
		If IsDate(TxtFechaIni.Text) And IsDate(TxtFechaFin.Text) Then
			fechass = ArmFormatoFecha(TxtFechaIni.Text) & "," & ArmFormatoFecha(TxtFechaFin.Text)
		End If
		If Option1(0).Checked Then
			ConxAccess = New ADODB.Connection
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ArmStr(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ConxAccess.ConnectionString = ArmStr((Emp.NombreBaseAdcom), Emp.servidor, "SQL", Emp.ClaveBD, Emp.UsuarioBd)
			ConxAccess.Open()
			If TipTra = 1 Then
				Consulta = "DaxSriCompras2013 " & fechass
			ElseIf TipTra = 2 Then 
				Consulta = "DaxSriVtas " & fechass & "," & Emp.codigo
			ElseIf TipTra = 3 Then 
				Consulta = "DaxSriImport " & fechass
			ElseIf TipTra = 4 Then 
				''''''''  activar cuando se tenga grabados los datos en documentos      Consulta = "DaxSriExport " & fechass
			ElseIf TipTra = 5 Then 
				Consulta = "DaxSriAnula " & fechass
			ElseIf TipTra = 6 Then 
				Consulta = "DaxSriReoc " & fechass
			End If
			If Consulta > "" Then rs.Open(Consulta, ConxAccess, ADOR.CursorTypeEnum.adOpenDynamic, ADOR.LockTypeEnum.adLockOptimistic) Else Exit Sub
			If rs.State = 0 Then MsgBox("No se pudo accesar a la base de datos del Adcom" & vbCr & Err.Description, MsgBoxStyle.Critical) : Exit Sub
			Malla.DataSource = rs
			rs.Close()
			ArreglaMalla(Malla, TipTra)
			GrabarMallaDatos(TipTra, Malla)
		ElseIf Option1(1).Checked Then 
			LlenarMalla(Text1.Text, Malla, Val(DeLinea.Text), Val(ALinea.Text))
			CleanUp()
		ElseIf Option1(2).Checked Then 
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ArmStr(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ConxAccess.ConnectionString = ArmStr(Text2.Text, Text4.Text, "SQL", TxtPasswSql.Text, TxtUserSql.Text)
			ConxAccess.Open()
			If Option5.Checked Then
				rs = ConxAccess.Execute(Text5.Text & " " & fechass)
			Else
				Consulta = "SELECT * FROM " & Text5.Text & " where mes = " & PerMes & " and anio = " & PerAnio
				'         Consulta = "select * from consulta" 'where mes = 03 and anio = 2013"
				rs.CursorLocation = ADOR.CursorLocationEnum.adUseClient
				rs.Open(Consulta, ConxAccess, ADOR.CursorTypeEnum.adOpenForwardOnly, ADOR.LockTypeEnum.adLockReadOnly)
				'       Set rs = ConxAdcom.Execute(Consulta)
			End If
			Malla.DataSource = rs
		ElseIf Option1(3).Checked Then 
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ArmStr(). Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ConxAccess.ConnectionString = ArmStr(ArchivoAccess.Text, "", "ACC", TxtPasswAccess.Text, TxtUserAccess.Text)
			ConxAccess.Open()
			Consulta = "SELECT * FROM " & TablaAccess.Text
			rs.Open(Consulta, ConxAccess, ADOR.CursorTypeEnum.adOpenForwardOnly, ADOR.LockTypeEnum.adLockOptimistic)
			Malla.DataSource = rs
		End If
		If Malla.get_Cols() > NumDat(TipTra) Then QueError = 2
		Exit Sub
HayErrores: 
		MsgBox("Error cargar archivo" & Err.Description)
		QueError = 2
		Resume Next
	End Sub
	
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		'UPGRADE_WARNING: La variable CommonDialog no se actualizó Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="671167DC-EA81-475D-B690-7A40C7BF4A23"'
		With dialogo
			.Title = "Ubicacion de archivo Access de compras "
			'UPGRADE_WARNING: Filter tiene un nuevo comportamiento. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			.Filter = "Access (*.mdb;)|*.mdb;"
			.InitialDirectory = "c:\"
			.ShowDialog()
			ArchivoAccess.Text = ""
			If dialogoOpen.FileName <> "" Then
				ArchivoAccess.Text = .FileName
			End If
		End With
	End Sub
	
	Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
		'UPGRADE_WARNING: La variable CommonDialog no se actualizó Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="671167DC-EA81-475D-B690-7A40C7BF4A23"'
		With dialogo
			.Title = "Ubicacion de archivo Excel de compras "
			'UPGRADE_WARNING: Filter tiene un nuevo comportamiento. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
			.Filter = "Excel (*.xls;)|*.xls;"
			.InitialDirectory = "c:\"
			.ShowDialog()
			Text3.Text = .FileName
		End With
	End Sub
	
	Private Sub FechaFin_Click()
		TxtFechaFin.Text = CStr(QueFecha)
	End Sub
	
	Private Sub OpcionesImporta_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim dsection As String
		Dim OpcionIni As Short
		On Error GoTo hayError
		Saltar = True
		'dsection = "Excell" & TipTra
		'centrar el formulario
		NumDat(1) = 33
		NumDat(2) = 26
		NumDat(3) = 26
		NumDat(4) = 26
		dsection = "Excell" & TipTra
		Me.SetBounds(VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width)) / 2), VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.Height)) / 2), 0, 0, Windows.Forms.BoundsSpecified.X Or Windows.Forms.BoundsSpecified.Y)
		Option1(0).Checked = True
		Text3.Text = GetSetting("SRI", dsection, "ARCHIVO", "")
		If Text3.Text > "" Then
			Setup(Text3.Text)
			LlenarHojas(Text1)
		End If
		Text1.Text = GetSetting("SRI", dsection, "HOJA", "")
		If Text1.Text = "" Then Text1.Text = VB6.GetItemString(Text1, 0)
		
		DeLinea.Text = GetSetting("SRI", dsection, "DELINEA", "1")
		ALinea.Text = GetSetting("SRI", dsection, "ALINEA", "")
		
		
		dsection = "Sql" & TipTra
		Text4.Text = GetSetting("SRI", dsection, "Servidor", "")
		Text2.Text = GetSetting("SRI", dsection, "Base", "")
		Text5.Text = GetSetting("SRI", dsection, "Tabla", "")
		TxtUserSql.Text = GetSetting("SRI", dsection, "Usuario", "")
		TxtPasswSql.Text = GetSetting("SRI", dsection, "Password", "")
		Option5.Checked = CBool(GetSetting("SRI", dsection, "Tipo", CStr(False)))
		
		dsection = "Access" & TipTra
		ArchivoAccess.Text = GetSetting("SRI", dsection, "Archivo", "")
		TablaAccess.Text = GetSetting("SRI", dsection, "Tabla", "")
		TxtUserAccess.Text = GetSetting("SRI", dsection, "Usuario", "")
		TxtPasswAccess.Text = GetSetting("SRI", dsection, "Password", "")
		
		dsection = "Adcom" & TipTra
		TxtFechaIni.Text = "01/" & PerMes & "/" & PerAnio
		TxtFechaFin.Text = CStr(FechaFinMes(Val(CStr(PerAnio)), PerMes))
		Saltar = False
		OpcionIni = CShort(GetSetting("SRI", "Option", "numero", CStr(0)))
		Option1(OpcionIni).Checked = 1
		Option1_CheckedChanged(Option1.Item(OpcionIni), New System.EventArgs())
		Exit Sub
hayError: 
		ControlaErrores(("load OpcionesImporta "))
	End Sub
	
	Private Sub OpcionesImporta_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		
		Dim dsection As String
		dsection = "Excell" & TipTra
		SaveSetting("SRI", dsection, "ARCHIVO", Text3.Text)
		SaveSetting("SRI", dsection, "HOJA", Text1.Text)
		SaveSetting("SRI", dsection, "DELINEA", DeLinea.Text)
		SaveSetting("SRI", dsection, "ALINEA", ALinea.Text)
		
		dsection = "Sql" & TipTra
		SaveSetting("SRI", dsection, "Servidor", Text4.Text)
		SaveSetting("SRI", dsection, "Base", Text2.Text)
		SaveSetting("SRI", dsection, "Tabla", Text5.Text)
		SaveSetting("SRI", dsection, "Usuario", TxtUserSql.Text)
		SaveSetting("SRI", dsection, "Password", TxtPasswSql.Text)
		SaveSetting("SRI", dsection, "Tipo", CStr(Option5.Checked))
		
		
		dsection = "Access" & TipTra
		SaveSetting("SRI", dsection, "Archivo", ArchivoAccess.Text)
		SaveSetting("SRI", dsection, "Tabla", TablaAccess.Text)
		SaveSetting("SRI", dsection, "Usuario", TxtUserAccess.Text)
		SaveSetting("SRI", dsection, "Password", TxtPasswAccess.Text)
		
		dsection = "Adcom" & TipTra
		SaveSetting("SRI", dsection, "Fecini", TxtFechaIni.Text)
		SaveSetting("SRI", dsection, "Fecfin", TxtFechaFin.Text)
		
		If Option1(0).Checked Then
			SaveSetting("SRI", "Option", "numero", CStr(0))
		ElseIf Option1(2).Checked Then 
			SaveSetting("SRI", "Option", "numero", CStr(2))
		End If
		
	End Sub
	
	'UPGRADE_WARNING: El evento Option1.CheckedChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub Option1_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Option1.CheckedChanged
		If eventSender.Checked Then
			Dim Index As Short = Option1.GetIndex(eventSender)
			FrAdcom.Visible = Option1(0).Checked
			FrExcel.Visible = Option1(1).Checked
			FrSql.Visible = Option1(2).Checked
			FrAccess.Visible = Option1(3).Checked
			
		End If
	End Sub
	
	Function Fgi(ByRef R As Short, ByRef C As Short) As Integer
		Fgi = C + Malla.get_Cols() * R
	End Function
	
	'UPGRADE_WARNING: El evento Text3.TextChanged se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub Text3_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text3.TextChanged
		If Saltar = False Then
			Setup(Text3.Text)
			LlenarHojas(Text1)
		End If
		
	End Sub
End Class