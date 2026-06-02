Option Strict Off
Option Explicit On
Friend Class SRITABA
	Inherits System.Windows.Forms.Form
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
	Dim mbChangedByCode As Boolean
	Dim mvBookMark As Object
	Dim mbEditFlag As Boolean
	Dim mbAddNewFlag As Boolean
	Dim mbDataChanged As Boolean
	Public QueTabla, NombreTabla As String
	
	'UPGRADE_WARNING: Form evento SRITABA.Activate tiene un nuevo comportamiento. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
	Private Sub SRITABA_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		If AdcomConSri = False Then Me.Close()
	End Sub
	
	Private Sub SRITABA_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim Comando As String
		'Dim db As Connection
		'Set db = New Connection
		'db.Open "PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=S:\SNT\lib\SYS\syscod2.mdb;"
		Me.Text = "MANTENIMIENTO TABLAS DEL SRI"
		Malla.Text = NombreTabla
		centrarforma(Me)
		adoPrimaryRS = New ADODB.Recordset
		Select Case QueTabla
			Case "a"
				Comando = "select * from SriTipoDeTransaccion Order by Codigo"
			Case "b"
				Comando = "select * from SriTipoImportExportación Order by Codigo"
			Case "1"
				Comando = "select * from SriSecuencialesTransacciones Order by Codigo"
			Case "2"
				Comando = "select * from SriTipoDeComprobante Order by Codigo"
			Case "3"
				Comando = "select * from SriSustentoComprobante Order by Codigo"
			Case "4"
				Comando = "select * from SriPorcentajesDelIva Order by Codigo"
			Case "5"
				Comando = "select * from SriPorcentajesRetencionIvaServicios Order by Codigo"
			Case "5a"
				Comando = "select * from SriPorcentajesRetencionIvaBienes Order by Codigo"
			Case "6"
				Comando = "select * from SriPorcentajesDelIce Order by Codigo"
			Case "7"
				Comando = "select * from SriTarjetasCredito Order by Codigo"
			Case "8"
				Comando = "select * from SriTiposDeIdentificacion Order by Codigo"
			Case "9"
				Comando = "select * from SriCodigoRegimen Order by Codigo"
			Case "10"
				Comando = "select * from SriConceptosRetencion  Order by Codigo"
			Case "11"
				Comando = "select * from SriTiposFideicomisos Order by Codigo"
			Case "12"
				Comando = "select * from SriDistritoAduanero Order by Codigo"
			Case "13"
				Comando = "select * from SriTipoSujetoImportExport Order by Codigo"
			Case Else
				MsgBox("No se ha definido la tabla para visualizar") : Exit Sub
		End Select
		'ConxSyscod.CursorLocation = adUseClient
		If Emp.Sri Then adoPrimaryRS.Open(Comando, ConxSyscod, ADOR.CursorTypeEnum.adOpenStatic, ADOR.LockTypeEnum.adLockOptimistic)
		mbDataChanged = False
		Malla.DataSource = adoPrimaryRS
	End Sub
	
	'UPGRADE_WARNING: El evento SRITABA.Resize se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub SRITABA_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		' 'quitar en todo el proyecto 'cambiar on error Resume Next
		'Esto cambiará el tamaño de la cuadrícula al cambiar el tamaño del formulario
		Malla.Height = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.ClientRectangle.Height) - 30 - VB6.PixelsToTwipsY(picButtons.Height))
		'  lblStatus.Width = Me.Width - 1500
		'cmdNext.Left = lblStatus.Width + 700
		'cmdLast.Left = cmdNext.Left + 340
	End Sub
	
	Private Sub SRITABA_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim keycode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If mbEditFlag Or mbAddNewFlag Then Exit Sub
		
		Select Case keycode
			Case System.Windows.Forms.Keys.Escape
				cmdClose_Click(cmdClose, New System.EventArgs())
			Case System.Windows.Forms.Keys.End
				cmdLast_Click()
			Case System.Windows.Forms.Keys.Home
				cmdFirst_Click()
			Case System.Windows.Forms.Keys.Up, System.Windows.Forms.Keys.PageUp
				If Shift = VB6.ShiftConstants.CtrlMask Then
					cmdFirst_Click()
				Else
					cmdPrevious_Click()
				End If
			Case System.Windows.Forms.Keys.Down, System.Windows.Forms.Keys.PageDown
				If Shift = VB6.ShiftConstants.CtrlMask Then
					cmdLast_Click()
				Else
					cmdNext_Click()
				End If
		End Select
	End Sub
	
	Private Sub SRITABA_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		'UPGRADE_WARNING: Screen propiedad Screen.MousePointer tiene un nuevo comportamiento. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
	End Sub
	
	Private Sub adoPrimaryRS_MoveComplete(ByVal adReason As ADODB.EventReasonEnum, ByVal pError As ADODB.Error, ByRef adStatus As ADODB.EventStatusEnum, ByVal pRecordset As ADODB.Recordset) Handles adoPrimaryRS.MoveComplete
		'Esto mostrará la posición de registro actual para este Recordset
		'  lblStatus.Caption = "Record: " & CStr(adoPrimaryRS.AbsolutePosition)
	End Sub
	
	Private Sub adoPrimaryRS_WillChangeRecord(ByVal adReason As ADODB.EventReasonEnum, ByVal cRecords As Integer, ByRef adStatus As ADODB.EventStatusEnum, ByVal pRecordset As ADODB.Recordset) Handles adoPrimaryRS.WillChangeRecord
		'Aquí se coloca el código de validación
		'Se llama a este evento cuando ocurre la siguiente acción
		Dim bCancel As Boolean
		
		Select Case adReason
			Case ADODB.EventReasonEnum.adRsnAddNew
			Case ADODB.EventReasonEnum.adRsnClose
			Case ADODB.EventReasonEnum.adRsnDelete
			Case ADODB.EventReasonEnum.adRsnFirstChange
			Case ADODB.EventReasonEnum.adRsnMove
			Case ADODB.EventReasonEnum.adRsnRequery
			Case ADODB.EventReasonEnum.adRsnResynch
			Case ADODB.EventReasonEnum.adRsnUndoAddNew
			Case ADODB.EventReasonEnum.adRsnUndoDelete
			Case ADODB.EventReasonEnum.adRsnUndoUpdate
			Case ADODB.EventReasonEnum.adRsnUpdate
		End Select
		
		If bCancel Then adStatus = ADODB.EventStatusEnum.adStatusCancel
	End Sub
	
	Private Sub cmdAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAdd.Click
		'quitar en todo el proyecto 'cambiar on error GoTo AddErr
		adoPrimaryRS.MoveLast()
		adoPrimaryRS.AddNew()
		Malla.Focus()
		
		Exit Sub
AddErr: 
		MsgBox(Err.Description)
	End Sub
	
	Private Sub cmdDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDelete.Click
		'quitar en todo el proyecto 'cambiar on error GoTo DeleteErr
		With adoPrimaryRS
			.Delete()
			.MoveNext()
			If .EOF Then .MoveLast()
		End With
		Exit Sub
DeleteErr: 
		MsgBox(Err.Description)
	End Sub
	
	Private Sub cmdEdit_Click()
		Dim lblStatus As Object
		'quitar en todo el proyecto 'cambiar on error GoTo EditErr
		
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto lblStatus.Caption. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		lblStatus.Caption = "Modificar registro"
		mbEditFlag = True
		SetButtons(False)
		Exit Sub
		
EditErr: 
		MsgBox(Err.Description)
	End Sub
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		'quitar en todo el proyecto 'cambiar on error Resume Next
		
		SetButtons(True)
		mbEditFlag = False
		mbAddNewFlag = False
		adoPrimaryRS.CancelUpdate()
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto mvBookMark. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		If mvBookMark > 0 Then
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto mvBookMark. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			adoPrimaryRS.Bookmark = mvBookMark
		Else
			adoPrimaryRS.MoveFirst()
		End If
		mbDataChanged = False
		
	End Sub
	
	Private Sub cmdUpdate_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUpdate.Click
		'quitar en todo el proyecto 'cambiar on error GoTo UpdateErr
		
		adoPrimaryRS.UpdateBatch(ADOR.AffectEnum.adAffectAll)
		
		If mbAddNewFlag Then
			adoPrimaryRS.MoveLast() 'va al nuevo registro
		End If
		
		mbEditFlag = False
		mbAddNewFlag = False
		SetButtons(True)
		mbDataChanged = False
		
		Exit Sub
UpdateErr: 
		MsgBox(Err.Description)
	End Sub
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Close()
	End Sub
	
	Private Sub cmdFirst_Click()
		'quitar en todo el proyecto 'cambiar on error GoTo GoFirstError
		
		adoPrimaryRS.MoveFirst()
		mbDataChanged = False
		
		Exit Sub
		
GoFirstError: 
		MsgBox(Err.Description)
	End Sub
	
	Private Sub cmdLast_Click()
		'quitar en todo el proyecto 'cambiar on error GoTo GoLastError
		
		adoPrimaryRS.MoveLast()
		mbDataChanged = False
		
		Exit Sub
		
GoLastError: 
		MsgBox(Err.Description)
	End Sub
	
	Private Sub cmdNext_Click()
		'quitar en todo el proyecto 'cambiar on error GoTo GoNextError
		
		If Not adoPrimaryRS.EOF Then adoPrimaryRS.MoveNext()
		If adoPrimaryRS.EOF And adoPrimaryRS.RecordCount > 0 Then
			Beep()
			'ha sobrepasado el final; vuelva atrás
			adoPrimaryRS.MoveLast()
		End If
		'muestra el registro actual
		mbDataChanged = False
		
		Exit Sub
GoNextError: 
		MsgBox(Err.Description)
	End Sub
	
	Private Sub cmdPrevious_Click()
		'quitar en todo el proyecto 'cambiar on error GoTo GoPrevError
		
		If Not adoPrimaryRS.BOF Then adoPrimaryRS.MovePrevious()
		If adoPrimaryRS.BOF And adoPrimaryRS.RecordCount > 0 Then
			Beep()
			'ha sobrepasado el final; vuelva atrás
			adoPrimaryRS.MoveFirst()
		End If
		'muestra el registro actual
		mbDataChanged = False
		
		Exit Sub
		
GoPrevError: 
		MsgBox(Err.Description)
	End Sub
	
	Private Sub SetButtons(ByRef bVal As Boolean)
		Dim CmdPrevious As Object
		Dim CmdLast As Object
		Dim CmdFirst As Object
		Dim CmdNext As Object
		cmdAdd.Visible = bVal
		cmdUpdate.Visible = Not bVal
		cmdCancel.Visible = Not bVal
		cmdDelete.Visible = bVal
		cmdClose.Visible = bVal
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CmdNext.Enabled. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		CmdNext.Enabled = bVal
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CmdFirst.Enabled. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		CmdFirst.Enabled = bVal
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CmdLast.Enabled. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		CmdLast.Enabled = bVal
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto CmdPrevious.Enabled. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		CmdPrevious.Enabled = bVal
	End Sub
	
	Private Sub Imprimir_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Imprimir.Click
		Dim i, j As Short
		'quitar en todo el proyecto 'cambiar on error Resume Next
		Dim prog As New PrntDax.ImpMalla
		With MallaImp
			.Clear()
			.set_Cols( , Malla.Columns.Count)
			.Rows = Malla.ApproxCount + 1
			
			For j = 0 To Malla.Columns.Count - 1
				.set_TextMatrix(0, j, Malla.Columns(j).Caption)
				.set_ColWidth(j,  , VB6.PixelsToTwipsX(Malla.Columns.Item(j).Width))
			Next j
			
			For i = 1 To .Rows - 1
				For j = 0 To .get_Cols() - 1
					Malla.Col = j
					Malla.Row = i - 1
					.set_TextMatrix(i, j, Malla.Text)
				Next j
			Next i
			prog.ImprimirMalla(MallaImp, 66, 10, Me.Text, 100, 0)
			'UPGRADE_NOTE: El objeto prog no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
			prog = Nothing
			.Clear()
			.Rows = 0
			.set_Cols( , 0)
		End With
	End Sub
End Class