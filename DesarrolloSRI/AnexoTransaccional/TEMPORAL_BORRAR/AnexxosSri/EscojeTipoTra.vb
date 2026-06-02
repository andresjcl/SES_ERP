Option Strict Off
Option Explicit On
Friend Class EscojeTipoTra
	Inherits System.Windows.Forms.Form
	Public TIPOTRA As Short
	Public Function QueTransaccion() As Short
		Me.ShowDialog()
		QueTransaccion = TIPOTRA
	End Function
	
	Private Sub CancelButton_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CancelButton_Renamed.Click
		TIPOTRA = 0
		Me.Close()
	End Sub
	
	Private Sub OKButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OKButton.Click
		Dim i As Short
		TIPOTRA = 0
		For i = 0 To 4
			If Option1(i).Checked Then TIPOTRA = i + 1
		Next i
		Me.Close()
	End Sub
End Class