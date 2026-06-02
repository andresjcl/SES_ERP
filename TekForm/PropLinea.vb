Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks
Friend Class PropLinea
	Inherits System.Windows.Forms.Form
	Dim QueLinea As Object
	Public Sub ProLinea(ByRef linea As Object)
		Dim prog As New DaxLib.DaxLibMalla
		prog.ColorF(Me)
		'UPGRADE_NOTE: Object prog may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		prog = Nothing
		
		QueLinea = linea
		'UPGRADE_WARNING: Couldn't resolve default property of object QueLinea.BorderWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Text1.Text = QueLinea.BorderWidth
		'UPGRADE_WARNING: Couldn't resolve default property of object QueLinea.BorderStyle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		Text2.Text = QueLinea.BorderStyle
		VB6.ShowForm(Me, (1))
	End Sub
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		'UPGRADE_WARNING: Couldn't resolve default property of object QueLinea.BorderStyle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		QueLinea.BorderStyle = Line1.BorderStyle
		'UPGRADE_WARNING: Couldn't resolve default property of object QueLinea.BorderWidth. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		QueLinea.BorderWidth = Line1.BorderWidth
		Me.Close()
		'UPGRADE_NOTE: Object PropLinea may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		Me = Nothing
	End Sub
	
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		Me.Close()
		'UPGRADE_NOTE: Object PropLinea may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		Me = Nothing
	End Sub
	
	'UPGRADE_WARNING: Event Text1.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub Text1_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text1.TextChanged
		On Error Resume Next
		Line1.BorderWidth = CShort(Text1.Text)
		If Val(Text1.Text) > 1 Then Text2.Enabled = False
	End Sub
	
	'UPGRADE_WARNING: Event Text2.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub Text2_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text2.TextChanged
		On Error Resume Next
		If Val(Text2.Text) > 6 Then Text2.Text = "1"
		Line1.BorderStyle = CShort(Text2.Text)
	End Sub
End Class