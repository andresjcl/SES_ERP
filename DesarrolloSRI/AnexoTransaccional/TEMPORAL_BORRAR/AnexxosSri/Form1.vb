Option Strict Off
Option Explicit On
Friend Class Form1
	Inherits System.Windows.Forms.Form
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
	Dim mbChangedByCode As Boolean
	Dim mvBookMark As Object
	Dim mbEditFlag As Boolean
	Dim mbAddNewFlag As Boolean
	Dim mbDataChanged As Boolean
	Public mes As Short
	Public año As Short
	Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim Sqll As String
		
		adoPrimaryRS = New ADODB.Recordset
		Sqll = "SELECT  * From resVentas where mes = " & mes & " and anio = " & año
		adoPrimaryRS.Open(Sqll, ConxSri, ADOR.CursorTypeEnum.adOpenStatic, ADOR.LockTypeEnum.adLockOptimistic)
		
		grdDataGrid.DataSource = adoPrimaryRS
		
		'With grdDataGrid
		'    .Columns(0).Locked = True
		'    .Columns(1).Locked = True
		'End With
		mbDataChanged = False
	End Sub
	
	'UPGRADE_WARNING: El evento Form1.Resize se puede desencadenar cuando se inicializa el formulario. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub Form1_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
		'cambiar on error Resume Next
		'This will resize the grid when the form is resized
		grdDataGrid.SetBounds(VB6.TwipsToPixelsX(50), VB6.TwipsToPixelsY(50), VB6.TwipsToPixelsX(VB6.PixelsToTwipsX(Me.Width) - 100), VB6.TwipsToPixelsY(VB6.PixelsToTwipsY(Me.Height) - 500 - VB6.PixelsToTwipsY(cmdClose.Height)))
		'grdDataGrid.Height = Me.ScaleHeight - 30 - picButtons.Height - picStatBox.Height
		'  lblStatus.Width = Me.Width - 1500
		'  cmdNext.Left = lblStatus.Width + 700
		'  cmdLast.Left = cmdNext.Left + 340
	End Sub
	
	Private Sub Form1_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim keycode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If mbEditFlag Or mbAddNewFlag Then Exit Sub
		
		Select Case keycode
			Case System.Windows.Forms.Keys.Escape
				cmdClose_Click(cmdClose, New System.EventArgs())
			Case System.Windows.Forms.Keys.End
				'      cmdLast_Click
			Case System.Windows.Forms.Keys.Home
				'      cmdFirst_Click
			Case System.Windows.Forms.Keys.Up, System.Windows.Forms.Keys.PageUp
				If Shift = VB6.ShiftConstants.CtrlMask Then
					'        cmdFirst_Click
				Else
					'        cmdPrevious_Click
				End If
			Case System.Windows.Forms.Keys.Down, System.Windows.Forms.Keys.PageDown
				If Shift = VB6.ShiftConstants.CtrlMask Then
					'      cmdLast_Click
				Else
					'       cmdNext_Click
				End If
		End Select
	End Sub
	
	Private Sub Form1_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		'UPGRADE_WARNING: Screen propiedad Screen.MousePointer tiene un nuevo comportamiento. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
	End Sub
	
	Private Sub adoPrimaryRS_MoveComplete(ByVal adReason As ADODB.EventReasonEnum, ByVal pError As ADODB.Error, ByRef adStatus As ADODB.EventStatusEnum, ByVal pRecordset As ADODB.Recordset) Handles adoPrimaryRS.MoveComplete
		'This will display the current record position for this recordset
		
		' lblStatus.Caption = "Registro : " & CStr(adoPrimaryRS.AbsolutePosition)
	End Sub
	
	Private Sub adoPrimaryRS_WillChangeRecord(ByVal adReason As ADODB.EventReasonEnum, ByVal cRecords As Integer, ByRef adStatus As ADODB.EventStatusEnum, ByVal pRecordset As ADODB.Recordset) Handles adoPrimaryRS.WillChangeRecord
		'This is where you put validation code
		'This event gets called when the following actions occur
		
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
	
	'Private Sub cmdEdit_Click()
	'  'cambiar on error  GoTo EditErr
	'
	'  lblStatus.Caption = "Edit record"
	'  mbEditFlag = True
	'  SetButtons False
	'  Exit Sub
	'
	'EditErr:
	'  MsgBox err.Description
	'End Sub
	Private Sub cmdCancel_Click()
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
	
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		Me.Close()
	End Sub
	
	Private Sub SetButtons(ByRef bVal As Boolean)
		Dim CmdPrevious As Object
		Dim CmdLast As Object
		Dim CmdFirst As Object
		Dim CmdNext As Object
		Dim cmdCancel As Object
		Dim cmdUpdate As Object
		Dim cmdEdit As Object
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto cmdEdit.Visible. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		cmdEdit.Visible = bVal
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto cmdUpdate.Visible. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		cmdUpdate.Visible = Not bVal
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto cmdCancel.Visible. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		cmdCancel.Visible = Not bVal
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
	
	Private Sub grdDataGrid_KeyDownEvent(ByVal eventSender As System.Object, ByVal eventArgs As AxMSDataGridLib.DDataGridEvents_KeyDownEvent) Handles grdDataGrid.KeyDownEvent
		Dim COLAN, ROWANT As Short
		Dim TEXTANT As String
		With grdDataGrid
			COLAN = .Col
			ROWANT = .Row
			
			If eventArgs.keycode = System.Windows.Forms.Keys.F3 And .Col > 1 Then
				.Col = .Col - 1
				TEXTANT = .Text
				.Col = COLAN
				.Text = TEXTANT
			ElseIf eventArgs.keycode = System.Windows.Forms.Keys.F4 And .Row > 1 Then 
				.Row = .Row - 1
				TEXTANT = .Text
				.Row = ROWANT
				.Text = TEXTANT
			End If
		End With
	End Sub
End Class