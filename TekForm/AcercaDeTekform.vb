Option Strict On
Option Explicit On
Friend Class AcercaDe
	Inherits System.Windows.Forms.Form
    Private Sub AcercaDe_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Me.Close()
    End Sub

    Private Sub Frame1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Frame1.Click
		Me.Close()
	End Sub
End Class