Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class PropDatos
	Inherits System.Windows.Forms.Form
	Dim QueDato As System.Windows.Forms.Label
	Dim QueTipo As String
	Dim Cambios(11) As Boolean
	
	Public Sub PropDato(ByRef Dato As System.Windows.Forms.Label, ByRef Tipo As String, ByRef SiCambia() As Boolean)
		Dim Printer As New Printer
		Dim f As Integer
		Dim prog As New DaxLib.DaxLibMalla
		prog.ColorF(Me)
		'UPGRADE_NOTE: Object prog may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		prog = Nothing
		
		QueDato = Dato
		For f = 0 To 11
			Cambios(f) = False
		Next f
		Me.Text = Me.Text & IIf(Tipo = "D", "PROPIEDADES DE DATOS ", " PROPIEDADES DE ETIQUETAS ")
		'Datoxi.Caption = valor
		Datoxi.Text = QueDato.Text
		'Datox.Caption = valor
		Label4.Text = "0.00"
		Combo2.Text = QueDato.Font.Name
		Combo3.Text = CStr(QueDato.Font.SizeInPoints)
		QueTipo = Tipo
		With Datox
			.Text = QueDato.Text
			Option1(QueDato.TextAlign).Checked = True
			.TextAlign = QueDato.TextAlign
			.Font = VB6.FontChangeBold(.Font, QueDato.Font.Bold)
			Check1.CheckState = IIf(.Font.Bold = True, 1, 0)
			.Font = VB6.FontChangeUnderline(.Font, QueDato.Font.Underline)
			Check2.CheckState = IIf(.Font.Underline = True, 1, 0)
			.Font = VB6.FontChangeItalic(.Font, QueDato.Font.Italic)
			Check3.CheckState = IIf(.Font.Italic = True, 1, 0)
			.Font = VB6.FontChangeName(.Font, QueDato.Font.Name)
			.Font = VB6.FontChangeSize(.Font, QueDato.Font.SizeInPoints)
			Text1.Text = ToolTip1.GetToolTip(QueDato)
			
			If Val(QueDato.Tag) > 1 Then
				Frame2.Enabled = True
				'UPGRADE_ISSUE: Label property QueDato.DataMember was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				'UPGRADE_ISSUE: Label property QueDato.DataField was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				If Val(QueDato.DataField) = 0 And Val(QueDato.DataMember) = 0 Then
					Option3.Checked = True
				Else
					Option2.Checked = True
					'UPGRADE_ISSUE: Label property QueDato.DataField was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					Text2.Text = QueDato.DataField
					'UPGRADE_ISSUE: Label property QueDato.DataMember was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
					Text3.Text = QueDato.DataMember
				End If
			Else
				Text2.Text = "0"
				Text3.Text = "0"
				Frame2.Enabled = False
			End If
		End With
		
		For f = 0 To Printer.FontCount - 1
			Combo2.Items.Add((Printer.Fonts(f)))
		Next f
		Label1.Enabled = IIf(Tipo = "D", True, False)
		Text1.Enabled = Label1.Enabled
		Label4.Enabled = Label1.Enabled
		'Label4.Enabled = Label1.Enabled
		
		VB6.ShowForm(Me, (1))
		For f = 0 To 11
			SiCambia(f) = Cambios(f)
		Next f
	End Sub
	
	Private Sub CancelButton_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CancelButton_Renamed.Click
		Me.Close()
	End Sub
	
	'UPGRADE_WARNING: Event Check1.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub Check1_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Check1.CheckStateChanged
		Datox.Font = VB6.FontChangeBold(Datox.Font, IIf(Check1.CheckState, True, False))
		Label4.Font = VB6.FontChangeBold(Label4.Font, Datox.Font.Bold)
	End Sub
	
	'UPGRADE_WARNING: Event Check2.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub Check2_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Check2.CheckStateChanged
		Datox.Font = VB6.FontChangeUnderline(Datox.Font, IIf(Check2.CheckState, True, False))
		Label4.Font = VB6.FontChangeUnderline(Label4.Font, Datox.Font.Underline)
	End Sub
	
	'UPGRADE_WARNING: Event Check3.CheckStateChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub Check3_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Check3.CheckStateChanged
		Datox.Font = VB6.FontChangeItalic(Datox.Font, IIf(Check3.CheckState, True, False))
		Label4.Font = VB6.FontChangeItalic(Label4.Font, Datox.Font.Underline)
	End Sub
	
	'UPGRADE_WARNING: Event Combo2.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	'UPGRADE_WARNING: ComboBox event Combo2.Change was upgraded to Combo2.TextChanged which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
	Private Sub Combo2_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Combo2.TextChanged
		Combo2_SelectedIndexChanged(Combo2, New System.EventArgs())
	End Sub
	'UPGRADE_WARNING: Event Combo2.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub Combo2_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Combo2.SelectedIndexChanged
		On Error Resume Next
		Datox.Font = VB6.FontChangeName(Datox.Font, Combo2.Text)
		Label4.Font = VB6.FontChangeName(Label4.Font, Datox.Font.Name)
	End Sub
	
	'UPGRADE_WARNING: Event Combo3.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	'UPGRADE_WARNING: ComboBox event Combo3.Change was upgraded to Combo3.TextChanged which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
	Private Sub Combo3_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Combo3.TextChanged
		Combo3_SelectedIndexChanged(Combo3, New System.EventArgs())
	End Sub
	
	'UPGRADE_WARNING: Event Combo3.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub Combo3_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Combo3.SelectedIndexChanged
		On Error Resume Next
		Datox.Font = VB6.FontChangeSize(Datox.Font, Val(Combo3.Text))
		Label4.Font = VB6.FontChangeSize(Label4.Font, Datox.Font.SizeInPoints)
	End Sub
	
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		Ejemplos.Visible = Not Ejemplos.Visible
		Command1.Text = IIf(Ejemplos.Visible = True, "&Sin Ejemplos", "&Ver Ejemplos")
	End Sub
	
	Private Sub Datoxi_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Datoxi.DoubleClick
		Pasar = ""
		If QueTipo = "D" Then
			VB6.ShowForm(Datos, (1))
			If Pasar > "" Then Datoxi.Text = Pasar
		Else
			DatoxT.Text = Datox.Text
			DatoxT.Enabled = True
			DatoxT.Visible = True
			DatoxT.Focus()
			Datoxi.Visible = False
			Datoxi.Enabled = False
		End If
	End Sub
	
	'UPGRADE_WARNING: Event DatoxT.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub DatoxT_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DatoxT.TextChanged
		Datoxi.Text = DatoxT.Text
		Datox.Text = DatoxT.Text
	End Sub
	
	Private Sub DatoxT_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DatoxT.Leave
		Datoxi.Visible = True
		Datoxi.Enabled = True
		DatoxT.Visible = False
		DatoxT.Enabled = False
	End Sub
	
	Private Sub PropDatos_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
		'UPGRADE_NOTE: Object PropDatos may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		Me = Nothing
	End Sub
	
	Private Sub OKButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OKButton.Click
		With QueDato
			If .TextAlign <> Datox.TextAlign Then
				Cambios(0) = True
				.TextAlign = Datox.TextAlign
			End If
			If .Font.Bold <> Datox.Font.Bold Then
				Cambios(1) = True
				.Font = VB6.FontChangeBold(.Font, Datox.Font.Bold)
			End If
			If .Font.Italic <> Datox.Font.Italic Then
				Cambios(2) = True
				.Font = VB6.FontChangeItalic(.Font, Datox.Font.Italic)
			End If
			If .Font.Name <> Datox.Font.Name Then
				Cambios(3) = True
				.Font = VB6.FontChangeName(.Font, Datox.Font.Name)
			End If
			If .Font.SizeInPoints <> Datox.Font.SizeInPoints Then
				Cambios(4) = True
				.Font = VB6.FontChangeSize(.Font, Datox.Font.SizeInPoints)
			End If
			If .Font.Underline <> Datox.Font.Underline Then
				Cambios(5) = True
				.Font = VB6.FontChangeUnderline(.Font, Datox.Font.Underline)
			End If
			If ToolTip1.GetToolTip(QueDato) <> Text1.Text Then
				Cambios(6) = True
				ToolTip1.SetToolTip(QueDato, Text1.Text)
			End If
			'UPGRADE_ISSUE: Label property QueDato.DataField was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			If .DataField <> Text2.Text Then
				Cambios(7) = True
				'UPGRADE_ISSUE: Label property QueDato.DataField was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				.DataField = Text2.Text
			End If
			'UPGRADE_ISSUE: Label property QueDato.DataMember was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
			If .DataMember <> Text3.Text Then
				Cambios(8) = True
				'UPGRADE_ISSUE: Label property QueDato.DataMember was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"'
				.DataMember = Text3.Text
			End If
			If .Text <> Datoxi.Text Then
				Cambios(9) = True
				.Text = Datoxi.Text
			End If
			
		End With
		Me.Close()
	End Sub
	
	'UPGRADE_WARNING: Event Option1.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub Option1_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Option1.CheckedChanged
		If eventSender.Checked Then
			Dim index As Short = Option1.GetIndex(eventSender)
			Datox.TextAlign = index
			Label4.TextAlign = index
		End If
	End Sub
	
	'UPGRADE_WARNING: Event Option2.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub Option2_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Option2.CheckedChanged
		If eventSender.Checked Then
			Option3_CheckedChanged(Option3, New System.EventArgs())
		End If
	End Sub
	
	'UPGRADE_WARNING: Event Option3.CheckedChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub Option3_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Option3.CheckedChanged
		If eventSender.Checked Then
			If Option3.Checked Then Text2.Text = "0" : Text3.Text = "0"
		End If
	End Sub
	
	'UPGRADE_WARNING: Event Text1.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	'UPGRADE_WARNING: ComboBox event Text1.Change was upgraded to Text1.TextChanged which has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="DFCDE711-9694-47D7-9C50-45A99CD8E91E"'
	Private Sub Text1_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text1.TextChanged
		text1_SelectedIndexChanged(text1, New System.EventArgs())
	End Sub
	
	'UPGRADE_WARNING: Event text1.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub text1_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles text1.SelectedIndexChanged
		Dim Formato As String
		On Error Resume Next
		If Text1.Text > "" Then
			If Text1.Text = "CódigoBarras" Then
				ProBarras.Visible = True
			Else
				ProBarras.Visible = False
				If VB.Right(Text1.Text, 1) = "B" Then
					Formato = VB.Left(Text1.Text, Len(Text1.Text) - 1)
					Label4.Text = ""
				Else : Formato = Text1.Text
					Label4.Text = VB6.Format("0.00", Formato)
				End If
				Datox.Text = VB6.Format("123456789.90", Formato)
			End If
		End If
	End Sub
	
	'UPGRADE_WARNING: Event Text2.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub Text2_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text2.TextChanged
		If Val(Text2.Text) > 0 Then Text3.Text = "0"
	End Sub
	'UPGRADE_WARNING: Event Text3.TextChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
	Private Sub Text3_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Text3.TextChanged
		If Val(Text3.Text) > 0 Then Text2.Text = "0"
	End Sub
End Class