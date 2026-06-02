Option Strict Off
Option Explicit On
Friend Class CambiaPeriodo
	Inherits System.Windows.Forms.Form
	
	Dim ELANIO As Short
	Dim ELMES As Short
	
	'UPGRADE_NOTE: CambiaPeriodo se actualizó a CambiaPeriodo_Renamed. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Public Sub CambiaPeriodo_Renamed(ByRef QueAnio As Short, ByRef QueMes As Short)
		ELANIO = QueAnio
		ELMES = QueMes
		Me.ShowDialog()
		QueAnio = ELANIO
		QueMes = ELMES
	End Sub
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		ELANIO = CShort(Anios.Text)
		ELMES = Meses.SelectedIndex + 1
		Me.Close()
	End Sub
	
	Private Sub CambiaPeriodo_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Dim keycode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		If keycode = System.Windows.Forms.Keys.Return Or keycode = System.Windows.Forms.Keys.Escape Then
			ELANIO = CShort(Anios.Text)
			ELMES = Meses.SelectedIndex + 1
			Me.Close()
		End If
	End Sub
	
	Private Sub CambiaPeriodo_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim i As Short
		'cambiar on error Resume Next
		With Anios
			For i = 0 To 20
				.Items.Insert(i, Str(i + 2002))
			Next 
		End With
		
		With Meses
			For i = 0 To 11
				.Items.Insert(i, VB6.Format("01/" & i + 1 & "/0001", "Mmmm"))
			Next 
		End With
		Anios.Text = CStr(PerAnio)
		Meses.SelectedIndex = PerMes - 1
	End Sub
End Class