Option Strict Off
Option Explicit On
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Friend Class PropFormato
	Inherits System.Windows.Forms.Form
	Const CoefiMedida As Integer = 567
	
	Private Sub CancelButton_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CancelButton_Renamed.Click
		APapel = IIf(APapel > 0, APapel, Val(Text1.Text) * CoefiMedida)
		LPapel = IIf(LPapel > 0, LPapel, Val(Text2.Text) * CoefiMedida)
		NroCopias = IIf(NroCopias > 0, NroCopias, Val(Combo3.Text))
		EsMultihoja = Multihoja.CheckState
		Me.Close()
		'UPGRADE_NOTE: Object PropFormato may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		Me = Nothing
	End Sub
	
	Private Sub PropFormato_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim Printer As New Printer
		Dim i As Short
		Dim prog As New DaxLib.DaxLibMalla
		prog.ColorF(Me)
		'UPGRADE_NOTE: Object prog may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		prog = Nothing
		
		Combo3.Text = IIf(NroCopias > 0, NroCopias, 1)
		Text1.Text = CStr((IIf(APapel > 0, APapel, Printer.Width)) / CoefiMedida)
		Text2.Text = CStr((IIf(LPapel > 0, LPapel, Printer.Height)) / CoefiMedida)
		Tacordeon.CheckState = Acordeon
		For i = 0 To 3
			CarEsp(i).Text = CStr(CEsp(i))
		Next 
		CajaDinero.Text = CStr(MaqDin)
		Text3.Text = NombreConsulta
		Text4.Text = DescripcionArchivo
		Check1.CheckState = IIf(SiImprimeRegistros, 1, 0)
		Multihoja.CheckState = EsMultihoja
		BaseDatos(BaseConsulta).Checked = True
	End Sub
	
	Private Sub OKButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OKButton.Click
		Dim i As Short
		NroCopias = Val(Combo3.Text)
		EsMultihoja = Multihoja.CheckState
		APapel = Val(Text1.Text) * CoefiMedida
		LPapel = Val(Text2.Text) * CoefiMedida
		For i = 0 To 3
			CEsp(i) = Val(CarEsp(i).Text)
		Next 
		MaqDin = Val(CajaDinero.Text)
		Acordeon = Val(CStr(Tacordeon.CheckState))
		NombreConsulta = Text3.Text
		DescripcionArchivo = Text4.Text
		SiImprimeRegistros = Val(CStr(Check1.CheckState))
		
		For i = 0 To 4
			If BaseDatos(i).Checked <> 0 Then BaseConsulta = i
		Next i
		Me.Close()
		'UPGRADE_NOTE: Object PropFormato may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		Me = Nothing
		
	End Sub
End Class