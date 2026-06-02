Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class SRIANULADOS
	Inherits System.Windows.Forms.Form
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
	Dim mbChangedByCode As Boolean
	Dim mvBookMark As Object
	Dim mbEditFlag As Boolean
	Dim mbAddNewFlag As Boolean
	Dim mbDataChanged As Boolean
	
	Private Sub SRIANULADOS_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim i As Short
		Dim sSQL As String
		Dim fechass As String
		Dim fechasi As String
		fechass = CStr(FechaFinMes(CInt(PerAnio), PerMes))
		fechasi = "01/" & VB.Left("0" & PerMes, 2) & "/" & PerAnio
		''cambiar on error Resume Next
		
		adoPrimaryRS = New ADODB.Recordset
		If adoPrimaryRS.State = 1 Then adoPrimaryRS.Close()
		ConxSri.CursorLocation = ADOR.CursorLocationEnum.adUseClient
		sSQL = "select Cl_TipoComprobante as TipoComprobante,CL_NroSerieEstableci as NroSerieEstableci,CL_NroSerieEmision as NroSerieEmision, " & " CL_NroSecuencialDesde as NroSecuencialDesde,CL_NroSecuencialHasta as NroSecuencialHasta,CL_NroAUtorizacion as NroAUtorizacion, " & " CL_FechaAnulacion as FechaAnulacion from Anulados where CL_FechaAnulacion <= " & ArmFormatoFecha(fechass) & " and CL_FechaAnulacion >= " & ArmFormatoFecha(fechasi) & " Order by Cl_TipoComprobante"
		adoPrimaryRS.Open(sSQL, ConxSri, ADOR.CursorTypeEnum.adOpenStatic, ADOR.LockTypeEnum.adLockOptimistic)
		Malla.DataSource = adoPrimaryRS
		mbDataChanged = False
		With Malla
			.Columns(0).Button = True
			.Columns(1).Button = True
			.Columns(2).Button = True
			.Columns(6).Button = True
		End With
		
	End Sub
	
	'UPGRADE_WARNING: El evento SRIANULADOS.Resize se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub SRIANULADOS_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		'cambiar on error Resume Next
		'Esto cambiará el tamaño de la cuadrícula al cambiar el tamaño del formulario
		Malla.Height = VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.ClientRectangle.Height) - 30 - VB6.PixelsToTwipsY(picButtons.Height)) '- picStatBox.Height
		'  lblStatus.Width = Me.Width - 1500
		'  cmdNext.Left = lblStatus.Width + 700
		'  cmdLast.Left = cmdNext.Left + 340
	End Sub
	
	Private Sub SRIANULADOS_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
	
	Private Sub SRIANULADOS_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		'UPGRADE_WARNING: Screen propiedad Screen.MousePointer tiene un nuevo comportamiento. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
	End Sub
	
	'Private Sub adoPrimaryRS_MoveComplete(ByVal adReason As ADODB.EventReasonEnum, ByVal pError As ADODB.Error, adStatus As ADODB.EventStatusEnum, ByVal pRecordset As ADODB.Recordset)
	'  'Esto mostrará la posición de registro actual para este Recordset
	'  ''cambiar on error Resume Next
	'  'lblStatus.Caption = "Record: " & CStr(adoPrimaryRS.AbsolutePosition)
	'End Sub
	
	Private Sub adoPrimaryRS_WillChangeRecord(ByVal adReason As ADODB.EventReasonEnum, ByVal cRecords As Integer, ByRef adStatus As ADODB.EventStatusEnum, ByVal pRecordset As ADODB.Recordset) Handles adoPrimaryRS.WillChangeRecord
		'Aquí se coloca el código de validación
		'Se llama a este evento cuando ocurre la siguiente acción
		Dim bCancel As Boolean
		'cambiar on error Resume Next
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
				If ValidaLinea(1) = False Then bCancel = True
		End Select
		
		If bCancel Then adStatus = ADODB.EventStatusEnum.adStatusCancel
	End Sub
	
	Private Sub cmdAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAdd.Click
		'cambiar on error GoTo AddErr
		adoPrimaryRS.MoveLast()
		adoPrimaryRS.AddNew()
		Malla.Focus()
		SetButtons(False)
		Exit Sub
AddErr: 
		MsgBox(Err.Description)
	End Sub
	
	Private Sub cmdDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdDelete.Click
		'cambiar on error GoTo DeleteErr
		With adoPrimaryRS
			.Delete()
			.MoveNext()
			If .EOF Then .MoveLast()
		End With
		Exit Sub
DeleteErr: 
		MsgBox(Err.Description)
	End Sub
	
	Private Sub cmdEdit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEdit.Click
		'cambiar on error GoTo EditErr
		
		'lblStatus.Caption = "Modificar registro"
		mbEditFlag = True
		SetButtons(False)
		Exit Sub
		
EditErr: 
		MsgBox(Err.Description)
	End Sub
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		'cambiar on error Resume Next
		
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
		'cambiar on error GoTo UpdateErr
		
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
		'cambiar on error GoTo GoFirstError
		
		adoPrimaryRS.MoveFirst()
		mbDataChanged = False
		
		Exit Sub
		
GoFirstError: 
		MsgBox(Err.Description)
	End Sub
	
	Private Sub cmdLast_Click()
		'cambiar on error GoTo GoLastError
		
		adoPrimaryRS.MoveLast()
		mbDataChanged = False
		
		Exit Sub
		
GoLastError: 
		MsgBox(Err.Description)
	End Sub
	
	Private Sub cmdNext_Click()
		'cambiar on error GoTo GoNextError
		
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
		'cambiar on error GoTo GoPrevError
		
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
		cmdAdd.Visible = bVal
		cmdEdit.Visible = bVal
		cmdUpdate.Visible = Not bVal
		cmdCancel.Visible = Not bVal
		cmdDelete.Visible = bVal
		cmdClose.Visible = bVal
		'  cmdNext.Enabled = bVal
		'  cmdFirst.Enabled = bVal
		'  cmdLast.Enabled = bVal
		'  cmdPrevious.Enabled = bVal
	End Sub
	Private Sub FuncionesEspeciales(ByRef keycode As Short, ByRef Shift As Short)
		
		Dim ccol, Rrow As Short
		Dim Aux As String
		Dim QUENOMBRE, QUECODIGO, Campo As String
		Dim QUEVALOR As Double
		Dim HastaFecha As Date
		Dim Alx As New ManDirct.Directorio
		'cambiar on error Resume Next
		If keycode < System.Windows.Forms.Keys.F2 Or keycode > System.Windows.Forms.Keys.F10 Then Exit Sub
		
		ccol = Malla.Col
		Rrow = Malla.Row
		Campo = Malla.Text
		
		Select Case keycode
			Case System.Windows.Forms.Keys.F2 'buscavalores
				Select Case ccol
					Case 0
						BuscDocSri.BuscaDoc(PerPeriodo, 2, 0, "R", QUECODIGO, QUENOMBRE)
						Campo = QUECODIGO
					Case 1, 2
						Campo = "001"
					Case 6
						Campo = CStr(QueFecha)
						Campo = CStr(FechaFinMes(Year(CDate(Campo)), Month(CDate(Campo))))
				End Select
			Case System.Windows.Forms.Keys.F3
				Malla.Row = Malla.Row - 1
				Campo = Malla.Text
				Malla.Row = Rrow
		End Select
		Malla.Text = Campo
		
	End Sub
	
	Private Sub Malla_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As AxMSDataGridLib.DDataGridEvents_ButtonClickEvent) Handles Malla.ButtonClick
		malla_KeyDownEvent(malla, New AxMSDataGridLib.DDataGridEvents_KeyDownEvent(System.Windows.Forms.Keys.F2, 0))
	End Sub
	
	Private Sub malla_KeyDownEvent(ByVal eventSender As System.Object, ByVal eventArgs As AxMSDataGridLib.DDataGridEvents_KeyDownEvent) Handles malla.KeyDownEvent
		FuncionesEspeciales(eventArgs.keycode, eventArgs.Shift)
	End Sub
	
	Private Function ValidaLinea(ByRef Rrow As Integer) As Boolean
		Dim fechass As Object
		Dim fechasi As Object
		Dim i As Integer
		Dim Mensaje As String
		Mensaje = ""
		With Malla
			If ValidaTipoComprobante(PerPeriodo, 2, 0, "R", (.Columns(0).Text), "") = False Then Mensaje = "El Tipo de Comprobante esta errado"
			If Val(.Columns(1).Text) = 0 Then Mensaje = "El número de serie de establecimiento no puede ser cero"
			If Val(.Columns(2).Text) = 0 Then Mensaje = "El número de serie de punto de emision no puede ser cero"
			If Val(.Columns(3).Text) = 0 Then Mensaje = "El número secuencial desde no puede ser cero"
			If Val(.Columns(4).Text) = 0 Then Mensaje = "El número secuencial hasta no puede ser cero"
			If Val(.Columns(4).Text) < Val(.Columns(3).Text) Then Mensaje = "El número secuencial desde no puede ser mayor que el numero secuencial hasta "
			If Val(.Columns(5).Text) = 0 Then Mensaje = "El número de autorización no puede ser cero"
			If Not IsDate(.Columns(6).Text) Then Mensaje = "La fecha de anulación esta errada"
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto fechass. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto fechasi. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			If CDate(.Columns(6).Text) < CDate(fechasi) Or CDate(.Columns(6).Text) > CDate(fechass) Then Mensaje = "La fecha de anulación no corresponde al período actual"
		End With
		If Mensaje > "" Then
			MsgBox(Mensaje, MsgBoxStyle.Critical, "VALIDACION DOCUMENTOS ANULADOS")
			ValidaLinea = False
		Else
			ValidaLinea = True
		End If
	End Function
End Class