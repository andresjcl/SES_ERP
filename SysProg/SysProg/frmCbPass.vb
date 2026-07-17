Imports System.Data.SqlClient
Imports DattCom
Imports SysEmpDatt

Public Class frmCbPass

#Region "Datos Iniciales"
    Private Sub frmCbPass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        limpiar()
        'lblUsuario.Text = DatosUsuario.Identifica + " - " + DatosUsuario.nombre
        lblUsuario.Text = DatosUsuario.Identifica.ToUpper()

    End Sub
    Private Sub limpiar()
        txtConfirma.Text = ""
        txtNuePass.Text = ""
        txtPassAnt.Text = ""
    End Sub
#End Region

#Region "Aceptar"
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAeptar.Click
        Dim msg As String = VerificarDatos()
        If msg <> "" Then MsgBox(msg, MsgBoxStyle.Information) : Exit Sub
        ActualizaPass()
        ' Mensaje de confirmación
        MsgBox("¡Contraseña cambiada correctamente!", MsgBoxStyle.Information, "Éxito")
        Me.Dispose()
    End Sub
    Private Function VerificarDatos() As String
        Dim msg As String = ""
        If txtPassAnt.Text = "" Then
            msg = "Ingrese la Contraseña Anterior"
        ElseIf txtNuePass.Text = "" Then
            msg = "Ingrese la Nueva Contraseña"
        ElseIf txtConfirma.Text = "" Then
            msg = "Ingrese la Confirmación de la Contraseña"
        ElseIf txtNuePass.Text <> txtConfirma.Text Then
            msg = "No Coincide la Verificación de Contraseña"
        ElseIf txtPassAnt.Text <> ConsulPassw(StrCon) Then
            msg = "La Contraseña Anterior no es Correcta"
        End If
        Return msg
    End Function
    Private Function ConsulPassw(ByVal strC As SqlConnection) As String
        Dim pass As String = ""
        Dim ssql As String = "select contraseña from sys_usuario where IdUsuario='" & lblUsuario.Text.Trim & "'"
        Dim con As New SqlConnection()
        con = strC
        Dim cmd As New SqlCommand(ssql, con)
        Dim dat As SqlDataReader = Nothing
        con.Open()
        dat = cmd.ExecuteReader()
        If dat.Read Then
            If Not IsDBNull(dat(0)) Then pass = dat(0).ToString()
        End If
        con.Close()
        Return pass
    End Function
    Private Sub ActualizaPass()
        Dim ssql As String = "update sys_usuario set Contraseña='" & txtNuePass.Text & "' where IdUsuario='" & lblUsuario.Text.Trim & "'"
        EjecutarComnados(ssql)
    End Sub
#End Region

#Region "Cancelar"
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        limpiar()
    End Sub
#End Region

#Region "Salir"
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Dispose()
    End Sub
#End Region

    Public Sub CmbPaswd(ByVal Str As String)
        StrCon.ConnectionString = Str
        'StrCon.Open()
        Me.Show()
    End Sub

End Class
