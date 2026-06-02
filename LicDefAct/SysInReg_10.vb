Option Strict On
Option Explicit On
Imports System.Windows.Forms



Friend Class IngresaRegistro
	Inherits System.Windows.Forms.Form
	Dim ClEntra As String
	Dim ClSale As String
	public Function IngresaClave(ByRef ClViene As String) As String
		ClEntra = ClViene
        ClSale = ""
        'Me.Parent = AdcomDx
        Me.ShowDialog()
        IngresaClave = ClSale
    End Function

    Private Sub IngresaRegistro_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        TextBox2.Text = ClEntra
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If MsgBox("Seguro que desea cancelar la activación del sistema ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then application.exitthread
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ClSale = TextBox1.Text
        Me.Close()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub
End Class