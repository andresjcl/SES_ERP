Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports DattCom


Public Class ActualizaDirectorio

    'Dim RsAlex As New ADODB.Recordset
    Dim datosDir As Identificacion
    Dim Sicambio As Boolean = False
    Public Function Actualizacion(codigo As String, strConx As String) As Boolean
        datosDir = New Identificacion(strConx)
        datosDir = Identificacion.Buscar(" codigo = '" + codigo + "'")
        If datosDir IsNot Nothing Then

            With datosDir
                TxtRucCi.Text = .CedulaIdentidadRuc
                TxtNombres.Text = .Nombres
                TxtApellidos.Text = .Apellidos
                TxtDireccion.Text = .Domicilio
                TxtTelefono1.Text = .Telefono1
                TxtTelefono2.Text = .Telefono2
                TxtEmail.Text = .CorreoElectrónico
                TxtNombreImpresion.Text = .NombreImpresion
                txtSector.Text = .Sector
                TipoIdent.SelectedIndex = Convert.ToInt16(ArreglaId(.TipoIdentificacion))
                If datosDir.TipoPersona = "N" Then chkPersona.Checked = True Else chkEmpresa.Checked = True
            End With
        End If
        Me.ShowDialog()
        Return Sicambio
    End Function
    Private Sub apellidos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtApellidos.TextChanged, TxtNombres.TextChanged

        If  Emp.OrdenaPorApellidos = False Then
            TxtNombreImpresion.Text = Trim(TxtNombres.Text & " " & TxtApellidos.Text)
        Else
            TxtNombreImpresion.Text = Trim(TxtApellidos.Text & " " & TxtNombres.Text)
        End If
        Sicambio = True

    End Sub

    Private Sub btncontinuar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncontinuar.Click
        If Sicambio Then
            If validarDatos() Then Grabar() : Me.Close()
        End If
    End Sub
    Private Function validarDatos() As Boolean

        If TipoIdent.Text = "" Then MsgBox("Falta el tipo de identificación", MsgBoxStyle.Critical) : TipoIdent.Focus() : Return False
        If TxtRucCi.Text = "" Then MsgBox("Debe ingresar el RUC o CI", MsgBoxStyle.Information) : TxtRucCi.Focus() : Return False

        If ValidaNumeroId() = False Then
            MsgBox("El numero del documento de identificacion está errado ", MsgBoxStyle.Critical)
            TxtRucCi.Focus()
            Return False
        End If

        If TxtTelefono1.Text = "" Then MsgBox("Debe ingresar al menos un teléfono del cliente ", MsgBoxStyle.Information) : TxtTelefono1.Focus() : Return False
        If TxtNombres.Text = "" Then MsgBox("Debe ingresar el nombre ", MsgBoxStyle.Information) : TxtNombres.Focus() : Return False
        If TxtDireccion.Text = "" Then MsgBox("Debe ingresar la dirección ", MsgBoxStyle.Information) : TxtDireccion.Focus() : Return False

        If chkPersona.Checked Then
            If TxtApellidos.Text = "" Then TxtApellidos.Focus() : MsgBox("Debe ingresar el apellido", MsgBoxStyle.Information) : Return False
        End If

        Dim recIdOtr As New Identificacion(datosEmpresa.strConxAdcom)
        recIdOtr = Identificacion.Buscar("cedulaidentidadruc='" & TxtRucCi.Text & "' and codigo <> '" & datosDir.Codigo & "' ")
        If Not recIdOtr Is Nothing Then
            MsgBox("El Nro. ID (cédula o ruc) ya existe ", MsgBoxStyle.Critical)
            recIdOtr = Nothing
            Return False
        End If
        recIdOtr = Nothing
        Return True
    End Function
    Private Sub btncancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.Close()
    End Sub
    Private Sub btnsalir_Click()
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub ActualizaDir_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub Grabar()
        Dim resp As String = ""

        With datosDir
            If chkPersona.Checked = True Then
                .TipoPersona = "N"
            Else
                .TipoPersona = "J"
            End If
            .CedulaIdentidadRuc = TxtRucCi.Text
            .Nombres = TxtNombres.Text
            .Apellidos = TxtApellidos.Text
            .NombreImpresion = TxtNombreImpresion.Text
            .Telefono1 = TxtTelefono1.Text
            .Telefono2 = TxtTelefono2.Text
            .CorreoElectrónico = TxtEmail.Text

            .Domicilio = TxtDireccion.Text

            .TipoIdentificacion = TipoIdGeneral(TipoIdent.SelectedIndex.ToString())

            .Sector = txtSector.Text
            resp = .Actualizar()
        End With
        If resp.Substring(0, 5).ToUpper() = "ERROR" Then
            If (MessageBox.Show("El registro no se puede actualizar \n" + resp + "\n CONFIRMA SALIR ?", "Actualizar registro de directorio", MessageBoxButtons.YesNo, MessageBoxIcon.Error) = DialogResult.OK) Then
                Me.Close()
                Return
            End If
        End If
    End Sub
    Private Function ValidaNumeroId() As Boolean
        'Dim i As Integer
        Dim tipoId As String = ""
        Dim Persona As String = "P"
        On Error Resume Next

        Select Case TipoIdent.SelectedIndex
            Case 0
                tipoId = "R"
            Case 1
                tipoId = "C"
            Case 2
                tipoId = "P"
        End Select
        If chkEmpresa.Checked Then Persona = "E"
        Dim prog As New valIdcedru.valcedruc()
        ValidaNumeroId = prog.valCr(TxtRucCi.Text, tipoId, Persona)
    End Function

    Private Function ArreglaId(ByRef Ident As String) As String
        ArreglaId = Ident
        Select Case Ident
            Case "R"
                ArreglaId = CStr(0)
            Case "C"
                ArreglaId = CStr(1)
            Case "P"
                ArreglaId = CStr(2)
        End Select
    End Function

    Private Function TipoIdGeneral(ByRef Ident As String) As String
        TipoIdGeneral = "O"
        Select Case Ident
            Case "R", "0"
                TipoIdGeneral = "R"
            Case "C", "1"
                TipoIdGeneral = "C"
            Case "P", "2"
                TipoIdGeneral = "P"
        End Select
    End Function

    Private Sub TxtDireccion_TextChanged(sender As Object, e As EventArgs) Handles TxtDireccion.TextChanged
        Sicambio = True
    End Sub

    Private Sub TxtTelefono1_TextChanged(sender As Object, e As EventArgs) Handles TxtTelefono1.TextChanged
        Sicambio = True
    End Sub

    Private Sub TxtTelefono2_TextChanged(sender As Object, e As EventArgs) Handles TxtTelefono2.TextChanged
        Sicambio = True
    End Sub

    Private Sub TxtEmail_TextChanged(sender As Object, e As EventArgs) Handles TxtEmail.TextChanged
        Sicambio = True
    End Sub
End Class