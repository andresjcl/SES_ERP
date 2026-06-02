Option Strict Off
Option Explicit On
Friend Class MdTransacciones
	Inherits System.Windows.Forms.Form
	
	Dim ConNombres As Boolean
	Public Sub CopCol_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CopCol.Click
		If ActiveMDIChild Is Nothing Then Exit Sub
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ActiveForm.FuncionesEspeciales. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ActiveMDIChild.FuncionesEspeciales(System.Windows.Forms.Keys.F11, 0)
	End Sub
	
	Public Sub CopySup_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CopySup.Click
		If ActiveMDIChild Is Nothing Then Exit Sub
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ActiveForm.FuncionesEspeciales. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ActiveMDIChild.FuncionesEspeciales(System.Windows.Forms.Keys.F3, 0)
	End Sub
	
	Public Sub EdiLin_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles EdiLin.Click
		If ActiveMDIChild Is Nothing Then Exit Sub
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ActiveForm.propiedades. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ActiveMDIChild.propiedades()
	End Sub
	
	Public Sub EliFila_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles EliFila.Click
		If ActiveMDIChild Is Nothing Then Exit Sub
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ActiveForm.EliminaLinea. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ActiveMDIChild.EliminaLinea()
	End Sub
	
	Private Sub Sumatoria()
		If ActiveMDIChild Is Nothing Then Exit Sub
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ActiveForm.Sumatorias. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ActiveMDIChild.Sumatorias()
	End Sub
	
	Public Sub generar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles generar.Click
		Dim prog As New SRIGENARCHIVOSCOA
		prog.ShowDialog()
		prog.Close()
		'UPGRADE_NOTE: El objeto prog no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		prog = Nothing
	End Sub
	
	Public Sub InFila_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles InFila.Click
		If ActiveMDIChild Is Nothing Then Exit Sub
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ActiveForm.Malla. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		InsertarLinea(ActiveMDIChild.Malla.LaMalla)
	End Sub
	
	Private Sub MdTransacciones_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		MenuPop.Visible = False
		Me.Left = VB6.TwipsToPixelsX(CSng(GetSetting(My.Application.Info.Title, "Settings", "MainLeft", CStr(1000))))
		Me.Top = VB6.TwipsToPixelsY(CSng(GetSetting(My.Application.Info.Title, "Settings", "MainTop", CStr(1000))))
		Me.Width = VB6.TwipsToPixelsX(CSng(GetSetting(My.Application.Info.Title, "Settings", "MainWidth", CStr(6500))))
		Me.Height = VB6.TwipsToPixelsY(CSng(GetSetting(My.Application.Info.Title, "Settings", "MainHeight", CStr(6500))))
		'UPGRADE_WARNING: El límite inferior de la colección sbStatusBar.Panels cambió de 1 a 0. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
		sbStatusBar.Items.Item(1).Text = " PERIODO EN PROCESO : " & UCase(VB6.Format("01/" & PerMes & "/" & PerAnio, "MMMM")) & " DE " & PerAnio
	End Sub
	
	
	Private Sub LoadNewDoc()
		Static lDocumentCount As Integer
		Dim frmD As ImportaExcel
		Dim Tt As Short
		Dim NomTipoTra(10) As String
		On Error GoTo hayError
		NomTipoTra(1) = "COMPRAS LOCALES "
		NomTipoTra(2) = "VENTAS LOCALES "
		NomTipoTra(3) = "IMPORTACIONES O PAGOS AL EXTERIOR "
		NomTipoTra(4) = "EXPORTACIONES O INGRESOS DEL EXTERIOR "
		NomTipoTra(5) = "DOCUMENTOS ANULADOS "
		NomTipoTra(6) = "REOC"
		
		If Reocc = False Then
			Tt = EscojeTipoTra.QueTransaccion
		Else
			Tt = 6
		End If
		lDocumentCount = lDocumentCount + 1
		frmD = New ImportaExcel
		frmD.TIPOTRA = Tt
		
		frmD.Text = "Registro" & lDocumentCount & " de " & NomTipoTra(Tt) & UCase(VB6.Format("  01/" & PerMes & "/" & PerAnio, "MMMM")) & " DE " & PerAnio
		'    ArreglaMalla frmD.malla, frmD.TIPOTRA
		frmD.Show()
		Exit Sub
hayError: 
		ControlaErrores(("Load NewDoc"))
	End Sub
	
	
	Private Sub MdTransacciones_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
		Dim resp As Integer
		If Reocc Then
			resp = MsgBox("Confirma salir del ANEXO REOC ? ", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo)
		Else
			resp = MsgBox("Confirma salir del ANEXO TRANSACCIONAL ? ", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo)
		End If
		If resp = MsgBoxResult.No Then
			Cancel = 1
		Else
			'UPGRADE_WARNING: Instrucción no traducida en MDIForm_QueryUnload. Compruebe el código fuente.
		End If
		
		eventArgs.Cancel = Cancel
	End Sub
	
	Private Sub MdTransacciones_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		If Me.WindowState <> System.Windows.Forms.FormWindowState.Minimized Then
			SaveSetting(My.Application.Info.Title, "Settings", "MainLeft", CStr(VB6.PixelsToTwipsX(Me.Left)))
			SaveSetting(My.Application.Info.Title, "Settings", "MainTop", CStr(VB6.PixelsToTwipsY(Me.Top)))
			SaveSetting(My.Application.Info.Title, "Settings", "MainWidth", CStr(VB6.PixelsToTwipsX(Me.Width)))
			SaveSetting(My.Application.Info.Title, "Settings", "MainHeight", CStr(VB6.PixelsToTwipsY(Me.Height)))
		End If
	End Sub
	
	Public Sub MnuValida_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MnuValida.Click
		If ActiveMDIChild Is Nothing Then Exit Sub
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ActiveForm.ValidarDatos. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ActiveMDIChild.ValidarDatos()
	End Sub
	
	Public Sub MovCol_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MovCol.Click
		If ActiveMDIChild Is Nothing Then Exit Sub
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ActiveForm.FuncionesEspeciales. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ActiveMDIChild.FuncionesEspeciales(System.Windows.Forms.Keys.F10, 0)
		
	End Sub
	
	Public Sub Ordena_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Ordena.Click
		If ActiveMDIChild Is Nothing Then Exit Sub
		'If ConSumatoria > 0 Then MsgBox "Para ordenar la malla debe quitar la Sumatoria ", vbExclamation: Exit Sub
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ActiveForm.ordenar_malla. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ActiveMDIChild.ordenar_malla()
	End Sub
	
	Public Sub RemCol_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles RemCol.Click
		If ActiveMDIChild Is Nothing Then Exit Sub
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ActiveForm.FuncionesEspeciales. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ActiveMDIChild.FuncionesEspeciales(System.Windows.Forms.Keys.F8, 0)
	End Sub
	
	Private Sub sbStatusBar_PanelClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _sbStatusBar_Panel1.Click, _sbStatusBar_Panel2.Click, _sbStatusBar_Panel3.Click, _sbStatusBar_Panel4.Click
		Dim Panel As System.Windows.Forms.ToolStripStatusLabel = CType(eventSender, System.Windows.Forms.ToolStripStatusLabel)
		Dim QueAnio, QueMes As Short
		'UPGRADE_ISSUE: MSComctlLib.Panel propiedad Panel.Index no se actualizó. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		Select Case Panel.Index
			Case 1
				CambiaPeriodo.CambiaPeriodo_Renamed(QueAnio, QueMes)
				ArreglaPeriodo(QueAnio, QueMes)
				'UPGRADE_WARNING: El límite inferior de la colección sbStatusBar.Panels cambió de 1 a 0. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A3B628A0-A810-4AE2-BFA2-9E7A29EB9AD0"'
				sbStatusBar.Items.Item(1).Text = " PERIODO EN PROCESO : " & UCase(VB6.Format("01/" & PerMes & "/" & PerAnio, "MMMM")) & " DE " & PerAnio
		End Select
	End Sub
	
	Private Sub tbToolBar_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles _tbToolBar_Button1.Click, _tbToolBar_Button2.Click, _tbToolBar_Button3.Click, _tbToolBar_Button4.Click, _tbToolBar_Button5.Click, _tbToolBar_Button6.Click, _tbToolBar_Button7.Click, _tbToolBar_Button8.Click, _tbToolBar_Button9.Click, _tbToolBar_Button10.Click, _tbToolBar_Button11.Click, _tbToolBar_Button12.Click, _tbToolBar_Button13.Click, _tbToolBar_Button14.Click, _tbToolBar_Button15.Click, _tbToolBar_Button16.Click, _tbToolBar_Button17.Click, _tbToolBar_Button18.Click, _tbToolBar_Button19.Click, _tbToolBar_Button20.Click, _tbToolBar_Button21.Click, _tbToolBar_Button22.Click, _tbToolBar_Button23.Click, _tbToolBar_Button24.Click, _tbToolBar_Button25.Click, _tbToolBar_Button26.Click
		Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
		'cambiar on error Resume Next
		Select Case UCase(Button.Name)
			Case "NUEVO"
				LoadNewDoc()
			Case "ABRIR"
				mnuFileOpen_Click(mnuFileOpen, New System.EventArgs())
			Case "GUARDAR"
				BorrarSumatoria()
				mnuFileSave_Click(mnuFileSave, New System.EventArgs())
			Case "IMPRIMIR"
				BorrarSumatoria()
				mnuFilePrint_Click(mnuFilePrint, New System.EventArgs())
			Case "UNIRLINEAS"
				BorrarSumatoria()
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ActiveForm.CambiarMerge. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Not ActiveMDIChild Is Nothing Then ActiveMDIChild.CambiarMerge()
			Case "PERSONA"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ActiveForm.propiedades. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Not ActiveMDIChild Is Nothing Then ActiveMDIChild.propiedades()
			Case "IMPORTAR"
				mnuFileSaveAs_Click(mnuFileSaveAs, New System.EventArgs())
			Case "GENERAR"
				BorrarSumatoria()
				generar_Click(generar, New System.EventArgs())
			Case "COPIARLINEA"
				BorrarSumatoria()
				CopySup_Click(CopySup, New System.EventArgs())
			Case "COPIARCOL"
				BorrarSumatoria()
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ActiveForm.FuncionesEspeciales. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Not ActiveMDIChild Is Nothing Then ActiveMDIChild.FuncionesEspeciales(System.Windows.Forms.Keys.F11, 0)
			Case "MOVERCOL"
				BorrarSumatoria()
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ActiveForm.FuncionesEspeciales. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Not ActiveMDIChild Is Nothing Then ActiveMDIChild.FuncionesEspeciales(System.Windows.Forms.Keys.F10, 0)
			Case "FORMATO"
				BorrarSumatoria()
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ActiveForm.FuncionesEspeciales. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Not ActiveMDIChild Is Nothing Then ActiveMDIChild.FuncionesEspeciales(System.Windows.Forms.Keys.F9, 0)
			Case "REEMPLAZAR"
				BorrarSumatoria()
				RemCol_Click(RemCol, New System.EventArgs())
			Case "ELIMINARLINEA"
				BorrarSumatoria()
				EliFila_Click(EliFila, New System.EventArgs())
			Case "INSERTARLINEA"
				BorrarSumatoria()
				InFila_Click(InFila, New System.EventArgs())
			Case "COPIAR"
				BorrarSumatoria()
				generar_Click(generar, New System.EventArgs())
				'ImportaExcel.Malla.MergeCells = flexMergeFree
			Case "ORDENAR"
				BorrarSumatoria()
				Ordena_Click(Ordena, New System.EventArgs())
			Case "DETALLAR"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ActiveForm.Detalles. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Not ActiveMDIChild Is Nothing Then ActiveMDIChild.Detalles()
			Case "SALIR"
				Me.Close()
			Case "BTNSUMAR"
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ActiveForm.Sumatoriass. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If Not ActiveMDIChild Is Nothing Then ActiveMDIChild.Sumatoriass()
			Case "NOMBRES"
				ActivarNombresColumna1()
			Case "TOTALVENTAS"
				RegistrarTotalesVentas()
		End Select
	End Sub
	Private Sub BorrarSumatoria()
		If ActiveMDIChild Is Nothing Then Exit Sub
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ActiveForm.BorraLaSumatoria. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ActiveMDIChild.BorraLaSumatoria()
	End Sub
	
	Private Sub RegistrarTotalesVentas()
		'cambiar on error Resume Next
		If ActiveMDIChild Is Nothing Then Exit Sub
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ActiveForm.RegistrarTotalesVentas. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ActiveMDIChild.RegistrarTotalesVentas()
	End Sub
	
	Public Sub mnuWindowArrangeIcons_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuWindowArrangeIcons.Click
		Me.LayoutMDI(System.Windows.Forms.MDILayout.ArrangeIcons)
	End Sub
	
	Public Sub mnuWindowTileVertical_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuWindowTileVertical.Click
		Me.LayoutMDI(System.Windows.Forms.MDILayout.TileVertical)
	End Sub
	
	Public Sub mnuWindowTileHorizontal_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuWindowTileHorizontal.Click
		Me.LayoutMDI(System.Windows.Forms.MDILayout.TileHorizontal)
	End Sub
	
	Public Sub mnuWindowCascade_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuWindowCascade.Click
		Me.LayoutMDI(System.Windows.Forms.MDILayout.Cascade)
	End Sub
	
	Public Sub mnuWindowNewWindow_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuWindowNewWindow.Click
		LoadNewDoc()
	End Sub
	
	Private Sub mnuViewWebBrowser_Click()
		'TareasPendientes: Agregar código 'mnuViewWebBrowser_Click'.
		MsgBox("Agregar código 'mnuViewWebBrowser_Click'.")
	End Sub
	
	Public Sub mnuViewStatusBar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuViewStatusBar.Click
		mnuViewStatusBar.Checked = Not mnuViewStatusBar.Checked
		sbStatusBar.Visible = mnuViewStatusBar.Checked
	End Sub
	
	Public Sub mnuViewToolbar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuViewToolbar.Click
		mnuViewToolbar.Checked = Not mnuViewToolbar.Checked
		tbToolBar.Visible = mnuViewToolbar.Checked
	End Sub
	
	Public Sub mnuFileExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileExit.Click
		'descargar el formulario
		Me.Close()
	End Sub
	
	Public Sub mnuFilePrint_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFilePrint.Click
		'cambiar on error Resume Next
		If ActiveMDIChild Is Nothing Then Exit Sub
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ActiveForm.ImprimirLaMalla. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		ActiveMDIChild.ImprimirLaMalla()
	End Sub
	
	Public Sub mnuFilePageSetup_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFilePageSetup.Click
		'cambiar on error Resume Next
		'UPGRADE_WARNING: La variable CommonDialog no se actualizó Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="671167DC-EA81-475D-B690-7A40C7BF4A23"'
		With dlgCommonDialog
			.Title = "Configurar impresora"
			'UPGRADE_WARNING: La propiedad CancelError de CommonDialog no se admite en Visual Basic .NET. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="8B377936-3DF7-4745-AA26-DD00FA5B9BE1"'
			.CancelError = True
			.ShowDialog()
		End With
		
	End Sub
	
	Public Sub mnuFileSaveAll_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileSaveAll.Click
		'TareasPendientes: Agregar código 'mnuFileSaveAll_Click'.
		MsgBox("Agregar código 'mnuFileSaveAll_Click'.")
	End Sub
	
	Public Sub mnuFileSaveAs_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileSaveAs.Click
		Dim importa As Boolean
		LoadNewDoc()
		On Error GoTo hayError
		'if malla.cols > 2 and malla.rows > 2 then msgbox "
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ActiveForm.TIPOTRA. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ActiveForm.Malla. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		importa = OpcionesImporta.ImportarDatos(ActiveMDIChild.Malla.LaMalla3, ActiveMDIChild.TIPOTRA)
		If importa = False Then ActiveMDIChild.Close()
		Exit Sub
hayError: 
		ControlaErrores(("File save as "))
	End Sub
	
	Public Sub mnuFileSave_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileSave.Click
		If ActiveMDIChild Is Nothing Then Exit Sub
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ActiveForm.Malla. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ActiveForm.TIPOTRA. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		GrabarMallaDatos(ActiveMDIChild.TIPOTRA, ActiveMDIChild.Malla.LaMalla)
	End Sub
	
	Public Sub mnuFileClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileClose.Click
		'TareasPendientes: Agregar código 'mnuFileClose_Click'.
		MsgBox("Agregar código 'mnuFileClose_Click'.")
	End Sub
	
	Public Sub mnuFileOpen_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileOpen.Click
		Dim sFile As String
		Dim Tt As Short
		sFile = CStr(Month(System.Date.FromOADate(PerMes)))
		If MsgBox("Confirma abrir los datos del período " & UCase(VB6.Format("01/" & PerMes & "/" & PerAnio, "MMMM")) & " DE " & PerAnio, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
			LoadNewDoc()
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ActiveForm.Malla. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ActiveForm.TIPOTRA. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			CargarMallaDatos(ActiveMDIChild.TIPOTRA, ActiveMDIChild.Malla.LaMalla3)
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ActiveForm.TIPOTRA. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ActiveForm.Malla. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			ArreglaMalla(ActiveMDIChild.Malla.LaMalla, ActiveMDIChild.TIPOTRA)
		End If
	End Sub
	
	Public Sub mnuFileNew_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuFileNew.Click
		LoadNewDoc()
	End Sub
	
	Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
		'cambiar on error GoTo fin
		If Emp.servidor = "" Then End
		Exit Sub
fin: 
		End
	End Sub
	
	Private Sub ActivarNombresColumna1()
		If Not ActiveMDIChild Is Nothing Then
			If ConNombres Then
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ActiveForm.PonerNumeros. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ActiveMDIChild.PonerNumeros()
				ConNombres = False
			Else
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto ActiveForm.PonerNombres. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ActiveMDIChild.PonerNombres()
				ConNombres = True
			End If
		End If
	End Sub
End Class