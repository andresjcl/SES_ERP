Option Strict Off
Option Explicit On
Friend Class IngresaNombreformato
	Inherits System.Windows.Forms.Form
	Dim nom As String
	Dim Desc As String
	
	Public Sub IngresaNombre(ByRef Nombre As String, ByRef Descripcion As String)
		'Dim prog As New DaxLibMalla
		'prog.ColorF Me
		'Set prog = Nothing
		
		Text1.Text = Nombre
		Text2.Text = Descripcion
		Me.ShowDialog()
		Nombre = nom
		Descripcion = Desc
	End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		nom = Text1.Text
		Desc = Text2.Text
		Me.Close()
	End Sub
End Class