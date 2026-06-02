Option Strict Off
Option Explicit On
Friend Class IngresoCCosto
	Inherits System.Windows.Forms.Form
	
	Dim WithEvents adoPrimaryRS As ADODB.Recordset
	Dim mbChangedByCode As Boolean
	Dim mvBookMark As Object
	Dim mbEditFlag As Boolean
	Dim mbAddNewFlag As Boolean
	Dim mbDataChanged As Boolean
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		Dim ManDirct As Object
		'UPGRADE_ISSUE: ManDirct.BuscaClien objeto no se actualizó. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
		Dim BuscaClien As ManDirct.BuscaClien = New ManDirct.BuscaClien
		'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto BuscaClien.IniBuscaCliOPro. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		txtFields(0).Text = BuscaClien.IniBuscaCliOPro("C", txtFields(0))
		'UPGRADE_ISSUE: BuscaClien de descarga no se actualizó. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="875EBAD7-D704-4539-9969-BC7DBDAA62A2"'
		Unload(BuscaClien)
		'UPGRADE_NOTE: El objeto BuscaClien no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		BuscaClien = Nothing
		buscacli()
	End Sub
	
	Private Sub buscacli()
		'Dim prog As New daxdirect
		Dim opAlex As New DaxDirect.DirectorioAlex
		Dim codigo As String
		codigo = txtFields(0).Text
		If opAlex.CargarAlex(codigo, True) = True Then
			txtFields(1).Text = opAlex.NombreImpresion
			txtFields(2).Text = opAlex.codigo
		Else
			txtFields(2).Text = ""
		End If
		'UPGRADE_NOTE: El objeto opAlex no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		opAlex = Nothing
	End Sub
	Private Sub txtFields_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtFields.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = txtFields.GetIndex(eventSender)
		If Index = 0 Then
			If KeyCode = System.Windows.Forms.Keys.Return Then
				buscacli()
			End If
		End If
	End Sub
	
	Private Sub IngresoCCosto_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		'  Dim db As Connection
		'  Set db = New Connection
		ConxAdcom.CursorLocation = ADODB.CursorLocationEnum.adUseClient
		'  db.Open "PROVIDER=MSDASQL;driver={SQL Server};server=daxsofpc;uid=;pwd=;database=BdAdcomw;"
		
		adoPrimaryRS = New ADODB.Recordset
		adoPrimaryRS.Open("select CCO_Id,CCO_Nombre,CCO_ALEX,CCO_PorcDistr from AdcCcosto Order by CCO_Id", ConxAdcom, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
		
		Dim oText As System.Windows.Forms.TextBox
		'Enlaza los cuadros de texto con el proveedor de datos
		For	Each oText In Me.txtFields
			'UPGRADE_ISSUE: TextBox propiedad oText.DataSource no se actualizó. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			oText.DataSource = adoPrimaryRS
		Next oText
		
		mbDataChanged = False
	End Sub
	
	'Private Sub Form_Resize()
	'  'cambiar on error  Resume Next
	'  'lblStatus.Width = Me.Width - 1500
	'  cmdNext.Left = lblStatus.Width + 700
	'  cmdLast.Left = cmdNext.Left + 340
	'End Sub
	
	Private Sub IngresoCCosto_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If mbEditFlag Or mbAddNewFlag Then Exit Sub
		
		Select Case KeyCode
			Case System.Windows.Forms.Keys.Escape
				cmdClose_Click(cmdClose, New System.EventArgs())
			Case System.Windows.Forms.Keys.End
				cmdLast_Click(cmdLast, New System.EventArgs())
			Case System.Windows.Forms.Keys.Home
				cmdFirst_Click(cmdFirst, New System.EventArgs())
			Case System.Windows.Forms.Keys.Up, System.Windows.Forms.Keys.PageUp
				If Shift = VB6.ShiftConstants.CtrlMask Then
					cmdFirst_Click(cmdFirst, New System.EventArgs())
				Else
					cmdPrevious_Click(cmdPrevious, New System.EventArgs())
				End If
			Case System.Windows.Forms.Keys.Down, System.Windows.Forms.Keys.PageDown
				If Shift = VB6.ShiftConstants.CtrlMask Then
					cmdLast_Click(cmdLast, New System.EventArgs())
				Else
					cmdNext_Click(cmdNext, New System.EventArgs())
				End If
		End Select
	End Sub
	
	Private Sub IngresoCCosto_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		'UPGRADE_WARNING: Screen propiedad Screen.MousePointer tiene un nuevo comportamiento. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
	End Sub
	
	Private Sub adoPrimaryRS_MoveComplete(ByVal adReason As ADODB.EventReasonEnum, ByVal pError As ADODB.Error, ByRef adStatus As ADODB.EventStatusEnum, ByVal pRecordset As ADODB.Recordset) Handles adoPrimaryRS.MoveComplete
		'Esto mostrará la posición de registro actual para este Recordset
		'me.Caption = "Record: " & CStr(adoPrimaryRS.AbsolutePosition)
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
		'cambiar on error GoTo AddErr
		With adoPrimaryRS
			If Not (.BOF And .EOF) Then
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto adoPrimaryRS.Bookmark. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				'UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto mvBookMark. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				mvBookMark = .Bookmark
			End If
			.AddNew()
			'    lblStatus.Caption = "Agregar registro"
			mbAddNewFlag = True
			SetButtons(False)
		End With
		
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
		
		'  lblStatus.Caption = "Modificar registro"
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
		
		adoPrimaryRS.UpdateBatch(ADODB.AffectEnum.adAffectAll)
		
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
	
	Private Sub cmdFirst_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFirst.Click
		'cambiar on error GoTo GoFirstError
		
		adoPrimaryRS.MoveFirst()
		mbDataChanged = False
		
		Exit Sub
		
GoFirstError: 
		MsgBox(Err.Description)
	End Sub
	
	Private Sub cmdLast_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLast.Click
		'cambiar on error GoTo GoLastError
		
		adoPrimaryRS.MoveLast()
		mbDataChanged = False
		
		Exit Sub
		
GoLastError: 
		MsgBox(Err.Description)
	End Sub
	
	Private Sub cmdNext_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNext.Click
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
	
	Private Sub cmdPrevious_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPrevious.Click
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
		cmdNext.Enabled = bVal
		cmdFirst.Enabled = bVal
		cmdLast.Enabled = bVal
		cmdPrevious.Enabled = bVal
		Frame1.Enabled = Not bVal
	End Sub
	
	Private Sub txtFields_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtFields.Leave
		Dim Index As Short = txtFields.GetIndex(eventSender)
		If Index = 0 Then buscacli()
	End Sub
End Class