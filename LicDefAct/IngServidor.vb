Imports DattCom
Public Class IngresaServidor
    Dim EsOk As Boolean
    Dim sistema As String = ""
    Dim PathAppl As String = ""
    Public Sub New(sistem As String, pthAppl As String)
        InitializeComponent()
        sistema = sistem
        PathAppl = pthAppl
        Label6.Text = pthAppl
    End Sub

    Private Function ValidaClave(ByVal Cl1 As String, ByVal Cl2 As String) As Boolean
        'If Cl1 </value> Cl2 Then
        '    MsgBox("No coinciden las contraseñas", vbCritical)
        '    ValidaClave = False
        '    TxtPassword.Focus()
        '    Exit Function
        'End If
        ValidaClave = True
    End Function

    Private Sub Command4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command4.Click
        If MsgBox("Confirma recuperar la última conexión exitosa al servidor del sistema ?", CType(vbCritical + vbYesNo, MsgBoxStyle)) = vbYes Then
            leerArchivoConfiguracion("bin\")

            'TxtServidor.Text = progini.ProfileGetItem("Conecciones", "Servidor", TxtServidor.Text, PathAppl & "bin\" & Sistema & ".bk")
            'TxtUsuario.Text = progini.ProfileGetItem("Conecciones", "Usuario", TxtUsuario.Text, PathAppl & "bin\" & Sistema & ".bk")
            'TxtPassword.Text = progini.ProfileGetItem("Conecciones", "Clave", TxtPassword.Text, PathAppl & "bin\" & Sistema & ".bk")
            'TxtUrl.Text = progini.ProfileGetItem("Conecciones", "URL", TxtUrl.Text, PathAppl & "bin\" & Sistema & ".bk")
            'TxtPasswordc.Text = TxtPassword.Text
        End If
    End Sub
    Private Sub leerArchivoConfiguracion(bak As String)

        Dim dt As New DataTable()
        Try
            dt.ReadXml(Environment.CurrentDirectory + bak + sistema + ".xml")
            TxtServidor.Text = dt.Rows(0)("Servidor").ToString()
            TxtUsuario.Text = dt.Rows(0)("Usuario").ToString()
            TxtPassword.Text = dt.Rows(0)("Clave").ToString()
            TxtUrl.Text = dt.Rows(0)("URL").ToString()
            TxtPasswordc.Text = TxtPassword.Text
        Catch
        End Try


    End Sub

    Private Sub Command1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command1.Click
        Dim cnn As New SqlClient.SqlConnection
        Dim Conx As String

        Dim II As String
        On Error Resume Next
        If ValidaClave(TxtPassword.Text, TxtPasswordc.Text) = False Then Exit Sub
        If TxtServidor.Text >= "" Then
            Conx = CStr(IngresoApp.ArmStr("master", TxtServidor.Text, "10", TxtPassword.Text, TxtUsuario.Text))
            cnn.ConnectionString = Conx
            cnn.Open()
        End If
        EsOk = False
        If cnn.State = 0 Then MsgBox("No se pudo efectuar la conexión al servidor de base de datos", MsgBoxStyle.Critical) : Exit Sub
        MsgBox("Conexión al servidor de base de datos exitosa !!", MsgBoxStyle.Exclamation)
        cnn.Close()
        Conx = CStr(IngresoApp.ArmStr("Daxsys", TxtServidor.Text, "10", TxtPassword.Text, TxtUsuario.Text))
        cnn.ConnectionString = Conx
        cnn.Open()
        If cnn.State = 0 Then MsgBox("No se ha instalado la base de datos control del sistema AdcomDx en el servidor", MsgBoxStyle.Critical) : Exit Sub
        II = Dir(TxtUrl.Text)
        If Len(II) = 0 Then MsgBox("El directorio, en el servidor, donde se encuentra instalado el sistema es inaccesible") : Exit Sub
        EsOk = True

        If Strings.Right(TxtUrl.Text, 1) <> "\" Then TxtUrl.Text = TxtUrl.Text & "\"

        grabarConfiguracionSistema()
    End Sub
    Private Sub grabarConfiguracionSistema()
        Dim dt As New DataTable
        dt.Columns.Add("Servidor")
        dt.Columns.Add("Usuario")
        dt.Columns.Add("Clave")
        dt.Columns.Add("URL")
        dt.TableName = "config"
        Dim row As DataRow = dt.NewRow()
        row("Servidor") = TxtServidor.Text
        row("Usuario") = TxtUsuario.Text
        row("Clave") = TxtPassword.Text
        row("URL") = TxtUrl.Text
        dt.Rows.Add(row)
        dt.WriteXml(PathAppl & sistema & ".xml")
        dt.WriteXml(PathAppl & "bin\" & sistema & ".xml")
        dt.Dispose()
    End Sub
    Private Sub Command3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command3.Click
        Me.Close()
    End Sub

    Private Sub Command2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command2.Click
        Command1_Click(Command1, e)
        If EsOk Then Me.Close()
        MsgBox("Ingrese al sistema nuevamente para activar los nuevos parámetros")
        Environment.Exit(0)
    End Sub
End Class