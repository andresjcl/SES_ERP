Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Friend Class Previsual
	Inherits System.Windows.Forms.Form
	Dim Por(4) As Single
	
	Private Sub Previsual_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Por(0) = 100
		Por(1) = 75
		Por(2) = 50
		Por(3) = 25
		Por(4) = 10
		ArreglarBarras()
	End Sub
	
	Public Sub TA_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TA.Click
		Dim index As Short = TA.GetIndex(eventSender)
		Dim Printer As New Printer
		Dim W, H As Integer
		If index = 0 Then
			W = Printer.Width : H = Printer.Height
		Else
			W = Printer.Width * Por(index) / 100
			H = Printer.Height * Por(index) / 100
		End If
		
		Soporte.SetBounds(0, 0, VB6.TwipsToPixelsX(W), VB6.TwipsToPixelsY(H))
		'UPGRADE_ISSUE: PictureBox property papelito.Image was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		'UPGRADE_ISSUE: PictureBox method Soporte.PaintPicture was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
		Soporte.PaintPicture(papelito.Image, 0, 0, W, H)
		ArreglarBarras()
	End Sub
	
	'UPGRADE_NOTE: VScroll1.Change was changed from an event to a procedure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="4E2DC008-5EDA-4547-8317-C9316952674F"'
	'UPGRADE_WARNING: VScrollBar event VScroll1.Change has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
	Private Sub VScroll1_Change(ByVal newScrollValue As Integer)
		Soporte.Top = VB6.TwipsToPixelsY(0 - newScrollValue)
	End Sub
	
	Private Sub VScroll1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles VScroll1.Enter
		VScroll1_Change(0)
	End Sub
	
	'UPGRADE_NOTE: HScroll1.Change was changed from an event to a procedure. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="4E2DC008-5EDA-4547-8317-C9316952674F"'
	'UPGRADE_WARNING: HScrollBar event HScroll1.Change has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
	Private Sub HScroll1_Change(ByVal newScrollValue As Integer)
		Soporte.Left = VB6.TwipsToPixelsX(0 - newScrollValue)
	End Sub
	
	Private Sub HScroll1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles HScroll1.Enter
		HScroll1_Change(0)
	End Sub
	Private Sub ArreglarBarras()
		Dim NewLargeChange As Short
		On Error Resume Next
		If VB6.PixelsToTwipsY(Soporte.Height) > VB6.PixelsToTwipsY(Me.Height) Then
			VScroll1.Maximum = (VB6.PixelsToTwipsY(Soporte.Height) - VB6.PixelsToTwipsY(Me.Height) + 100 + VScroll1.LargeChange - 1)
		Else
			VScroll1.Maximum = (0 + VScroll1.LargeChange - 1)
		End If
		
		If VB6.PixelsToTwipsX(Soporte.Width) > VB6.PixelsToTwipsX(Me.Width) Then
			HScroll1.Maximum = (VB6.PixelsToTwipsX(Soporte.Width) - VB6.PixelsToTwipsX(Me.Width) + 100 + HScroll1.LargeChange - 1)
		Else
			HScroll1.Maximum = (0 + HScroll1.LargeChange - 1)
		End If
		NewLargeChange = VB6.PixelsToTwipsY(Me.Height)
		VScroll1.Maximum = VScroll1.Maximum + NewLargeChange - VScroll1.LargeChange
		VScroll1.LargeChange = NewLargeChange
		NewLargeChange = VB6.PixelsToTwipsX(Me.Width)
		HScroll1.Maximum = HScroll1.Maximum + NewLargeChange - HScroll1.LargeChange
		HScroll1.LargeChange = NewLargeChange
		VScroll1.SmallChange = VB6.PixelsToTwipsY(Soporte.Height) / VB6.PixelsToTwipsY(Me.Height)
		HScroll1.SmallChange = VB6.PixelsToTwipsX(Soporte.Width) / VB6.PixelsToTwipsX(Me.Width)
		
	End Sub
	Private Sub VScroll1_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles VScroll1.Scroll
		Select Case eventArgs.type
			Case System.Windows.Forms.ScrollEventType.EndScroll
				VScroll1_Change(eventArgs.newValue)
		End Select
	End Sub
	Private Sub HScroll1_Scroll(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.ScrollEventArgs) Handles HScroll1.Scroll
		Select Case eventArgs.type
			Case System.Windows.Forms.ScrollEventType.EndScroll
				HScroll1_Change(eventArgs.newValue)
		End Select
	End Sub
End Class