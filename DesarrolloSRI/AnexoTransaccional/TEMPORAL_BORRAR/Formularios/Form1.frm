VERSION 5.00
Object = "{CDE57A40-8B86-11D0-B3C6-00A0C90AEA82}#1.0#0"; "MSDATGRD.OCX"
Begin VB.Form Form1 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Totales de ventas"
   ClientHeight    =   3390
   ClientLeft      =   45
   ClientTop       =   375
   ClientWidth     =   5355
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   3390
   ScaleWidth      =   5355
   StartUpPosition =   3  'Windows Default
   Begin VB.PictureBox picButtons 
      Align           =   2  'Align Bottom
      Appearance      =   0  'Flat
      BorderStyle     =   0  'None
      ForeColor       =   &H80000008&
      Height          =   300
      Left            =   0
      ScaleHeight     =   300
      ScaleWidth      =   5355
      TabIndex        =   0
      Top             =   3090
      Width           =   5355
      Begin VB.CommandButton cmdClose 
         Caption         =   "&Cerrar"
         Height          =   300
         Left            =   0
         TabIndex        =   1
         Top             =   0
         Width           =   1095
      End
   End
   Begin MSDataGridLib.DataGrid grdDataGrid 
      Align           =   1  'Align Top
      Height          =   3975
      Left            =   0
      TabIndex        =   2
      Top             =   0
      Width           =   5355
      _ExtentX        =   9446
      _ExtentY        =   7011
      _Version        =   393216
      AllowUpdate     =   -1  'True
      AllowArrows     =   0   'False
      HeadLines       =   1
      RowHeight       =   15
      AllowAddNew     =   -1  'True
      AllowDelete     =   -1  'True
      BeginProperty HeadFont {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ColumnCount     =   2
      BeginProperty Column00 
         DataField       =   ""
         Caption         =   ""
         BeginProperty DataFormat {6D835690-900B-11D0-9484-00A0C91110ED} 
            Type            =   0
            Format          =   ""
            HaveTrueFalseNull=   0
            FirstDayOfWeek  =   0
            FirstWeekOfYear =   0
            LCID            =   3082
            SubFormatType   =   0
         EndProperty
      EndProperty
      BeginProperty Column01 
         DataField       =   ""
         Caption         =   ""
         BeginProperty DataFormat {6D835690-900B-11D0-9484-00A0C91110ED} 
            Type            =   0
            Format          =   ""
            HaveTrueFalseNull=   0
            FirstDayOfWeek  =   0
            FirstWeekOfYear =   0
            LCID            =   3082
            SubFormatType   =   0
         EndProperty
      EndProperty
      SplitCount      =   1
      BeginProperty Split0 
         BeginProperty Column00 
         EndProperty
         BeginProperty Column01 
         EndProperty
      EndProperty
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim WithEvents adoPrimaryRS As ADODB.Recordset
Attribute adoPrimaryRS.VB_VarHelpID = -1
Dim mbChangedByCode As Boolean
Dim mvBookMark As Variant
Dim mbEditFlag As Boolean
Dim mbAddNewFlag As Boolean
Dim mbDataChanged As Boolean
Public mes As Integer
Public año As Integer
Private Sub Form_Load()
Dim Sqll As String

  Set adoPrimaryRS = New ADODB.Recordset
  Sqll = "SELECT  * From resVentas where mes = " & mes & " and anio = " & año
  adoPrimaryRS.Open Sqll, ConxSri, adOpenStatic, adLockOptimistic

  Set grdDataGrid.DataSource = adoPrimaryRS

'With grdDataGrid
'    .Columns(0).Locked = True
'    .Columns(1).Locked = True
'End With
  mbDataChanged = False
End Sub

Private Sub Form_Resize()
  'cambiar on error Resume Next
  'This will resize the grid when the form is resized
   grdDataGrid.Move 50, 50, Me.Width - 100, Me.Height - 500 - cmdClose.Height
  'grdDataGrid.Height = Me.ScaleHeight - 30 - picButtons.Height - picStatBox.Height
'  lblStatus.Width = Me.Width - 1500
'  cmdNext.Left = lblStatus.Width + 700
'  cmdLast.Left = cmdNext.Left + 340
End Sub

Private Sub Form_KeyDown(keycode As Integer, Shift As Integer)
  If mbEditFlag Or mbAddNewFlag Then Exit Sub

  Select Case keycode
    Case vbKeyEscape
      cmdClose_Click
    Case vbKeyEnd
'      cmdLast_Click
    Case vbKeyHome
'      cmdFirst_Click
    Case vbKeyUp, vbKeyPageUp
      If Shift = vbCtrlMask Then
'        cmdFirst_Click
      Else
'        cmdPrevious_Click
      End If
    Case vbKeyDown, vbKeyPageDown
      If Shift = vbCtrlMask Then
  '      cmdLast_Click
      Else
 '       cmdNext_Click
      End If
  End Select
End Sub

Private Sub Form_Unload(Cancel As Integer)
  Screen.MousePointer = vbDefault
End Sub

Private Sub adoPrimaryRS_MoveComplete(ByVal adReason As ADODB.EventReasonEnum, ByVal pError As ADODB.Error, adStatus As ADODB.EventStatusEnum, ByVal pRecordset As ADODB.Recordset)
  'This will display the current record position for this recordset
  
 ' lblStatus.Caption = "Registro : " & CStr(adoPrimaryRS.AbsolutePosition)
End Sub

Private Sub adoPrimaryRS_WillChangeRecord(ByVal adReason As ADODB.EventReasonEnum, ByVal cRecords As Long, adStatus As ADODB.EventStatusEnum, ByVal pRecordset As ADODB.Recordset)
  'This is where you put validation code
  'This event gets called when the following actions occur
   
  Dim bCancel As Boolean

  Select Case adReason
  Case adRsnAddNew
  Case adRsnClose
  Case adRsnDelete
  Case adRsnFirstChange
  Case adRsnMove
  Case adRsnRequery
  Case adRsnResynch
  Case adRsnUndoAddNew
  Case adRsnUndoDelete
  Case adRsnUndoUpdate
  Case adRsnUpdate
  End Select

  If bCancel Then adStatus = adStatusCancel
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

  SetButtons True
  mbEditFlag = False
  mbAddNewFlag = False
  adoPrimaryRS.CancelUpdate
  If mvBookMark > 0 Then
    adoPrimaryRS.Bookmark = mvBookMark
  Else
    adoPrimaryRS.MoveFirst
  End If
  mbDataChanged = False

End Sub

Private Sub cmdClose_Click()
  Unload Me
End Sub

Private Sub SetButtons(bVal As Boolean)
  cmdEdit.Visible = bVal
  cmdUpdate.Visible = Not bVal
  cmdCancel.Visible = Not bVal
  cmdClose.Visible = bVal
  CmdNext.Enabled = bVal
  CmdFirst.Enabled = bVal
  CmdLast.Enabled = bVal
  CmdPrevious.Enabled = bVal
End Sub

Private Sub grdDataGrid_KeyDown(keycode As Integer, Shift As Integer)
With grdDataGrid
Dim COLAN As Integer, ROWANT As Integer, TEXTANT As String
COLAN = .Col
ROWANT = .Row

If keycode = vbKeyF3 And .Col > 1 Then
   .Col = .Col - 1
   TEXTANT = .Text
   .Col = COLAN
   .Text = TEXTANT
ElseIf keycode = vbKeyF4 And .Row > 1 Then
   .Row = .Row - 1
   TEXTANT = .Text
   .Row = ROWANT
   .Text = TEXTANT
End If
End With
End Sub

