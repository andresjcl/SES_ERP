Option Strict On
Option Explicit On
Imports System.Data.SqlClient
Imports DattCom
Friend Class frmUsuarios
	Inherits System.Windows.Forms.Form
	Dim ListUsuarios As String
	
	Public Function iniciaUsuario(ByRef user As String) As String
		ListUsuarios = ""
		cargaUsuarios()
		comparaSelect((user))
		Me.ShowDialog()
		iniciaUsuario = ListUsuarios
	End Function

    Private Sub cargaUsuarios()
        Dim sSql As String = " select idusuario from sys_usuario where fechacaduca>'" & Today & "'"
        Dim i As Int32
        Dim TablaAux As SqlDataReader
        List1.Items.Clear()
        i = 0
        TablaAux = DattCom.SqlDatos.leerBase(sSql, datosEmpresa.strConxSyscod)
        Do Until TablaAux.Read = False
            List1.Items.Insert(i, TablaAux.Item("idusuario"))
            i = i + 1
        Loop
        TablaAux.Close()
    End Sub

    Private Sub comparaSelect(ByRef us As String)
		Dim usuario() As String
        Dim i As Int32
        Dim j As Int32
        usuario = Split(us, ";")
        For i = 0 To usuario.Length - 1
            For j = 0 To List1.Items.Count - 1
                If usuario(i) = List1.Items(j).ToString Then List1.SetItemChecked(j, True)
            Next j
        Next i
    End Sub
	
	Private Sub cmdAceptar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAceptar.Click
        Dim i As Int32
        For i = 0 To List1.Items.Count - 1
            If List1.GetItemChecked(i) = True Then ListUsuarios = ListUsuarios & List1.Items(i).ToString() & ";"
        Next i
		Me.Close()
	End Sub
End Class