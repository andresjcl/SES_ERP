Imports System.Data.SqlClient
Public Class DatosAuxiliares
    Dim conectar As New SqlConnection()
    Dim accion As String = ""
    Dim codigo As String = ""
    Dim opGuardar As Boolean = False
    Dim cambios As Integer = 0
    Dim strConect As String = ""

#Region "Inicializar Datos"
    Private Sub ConectarBdd()
        Dim coneccion As New DaxLib.DaxLibBases
        coneccion.TipoBase = "10"
        conectar.ConnectionString = coneccion.StrAdcom
        strConect = coneccion.StrAdcom
    End Sub
    Private Sub limpiar(ByVal Obj As Object)
        Dim Control1 As System.Windows.Forms.Control
        Dim a As String
        For Each Control1 In Obj.Controls
            If Control1.Controls.Count > 0 Then limpiar(Control1)
            a = TypeName(Control1)
            If a = "TextBox" Then Control1.Text = ""
            If a = "ComboBox" Then Control1.Text = ""
            If a = "MaskedTextBox" Then Control1.Text = "  /  /"
        Next
    End Sub
    Private Sub bloquearDesbloquear(ByVal op As Boolean)
        btnNuevo.Enabled = op
        btnAbrir.Enabled = op
        btnSalir.Enabled = op
        btnGuardar.Enabled = Not op
        BtnEliminar.Enabled = Not op
        btnCancelar.Enabled = Not op
        GroupBox1.Enabled = Not op
    End Sub
    Private Sub DatosAuxiliares_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ConectarBdd()
        If accion = "Abrir" Then abrir(codigo) Else nuevo()
    End Sub
#End Region

#Region "Nuevo"
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        nuevo()
    End Sub
    Private Sub nuevo()
        limpiar(Me)
        bloquearDesbloquear(False)
        cambios = 0
        accion = "Guardar"
        opGuardar = False
    End Sub
    Private Sub cboTipoDato_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoDato.SelectedIndexChanged
        cambios += 1
        HabilitarCampos(cboTipoDato.Text)
    End Sub
    Private Sub HabilitarCampos(ByVal tipoDato As String)
        If tipoDato = "Alfanumérico" Then
            txtLongitud.Enabled = True
            txtDecimales.Enabled = False
        ElseIf "Numérico" Then
            txtLongitud.Enabled = True
            txtDecimales.Enabled = True
        ElseIf "DateTime" Then
            txtLongitud.Enabled = False
            txtDecimales.Enabled = False
        ElseIf "Bit" Then
            txtLongitud.Enabled = False
            txtDecimales.Enabled = False
        End If
    End Sub
#End Region

#Region "Abrir"
    Private Sub btnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrir.Click
        Dim busk As New Buscar.frmBuscar
        Dim cod As String = ""
        cod = busk.Buscar(strConect, "select", "Abreviación", "Descripcion", "Caonsulta", "Campos Auxiliares")
        If cod <> "" Then abrir(cod) : accion = "Abrir"
    End Sub
    Private Sub abrir(ByVal cod As String)
        limpiar(Me)
        bloquearDesbloquear(False)
        CargarDatos(cod)
    End Sub
    Private Sub CargarDatos(ByVal cod As String)
        Dim ssql As String = "select * from sp_columns CamposAuxiliares where Abreviación'" & cod & "'"
        Dim cmd As New SqlCommand(ssql, conectar)
        Dim dat As SqlDataReader = Nothing
        If conectar.State = Data.ConnectionState.Open Then conectar.Close()
            conectar.Open()
            dat = cmd.ExecuteReader()
            If dat.Read Then
                If Not IsDBNull(dat(0)) Then txtAbreviación = dat(0)
                If Not IsDBNull(dat(1)) Then txtDescripcion = dat(1)
                If Not IsDBNull(dat(2)) Then cboTipoDato.SelectedItem = dat(2)
                If Not IsDBNull(dat(3)) Then txtLongitud.Text = dat(3)
                If Not IsDBNull(dat(4)) Then txtDecimales.Text = dat(4)
                If Not IsDBNull(dat(5)) Then
                    If dat(5) = "Directorio" Then
                        optDirectorio.Checked = True
                    ElseIf dat(5) = "Syscod" Then
                        optSyscod.Checked = True
                    Else
                        optManual.Checked = True
                    End If
                End If
                If Not IsDBNull(dat(6)) Then txtCampoAsignado.Text = dat(6)
            End If
    End Sub

#End Region

#Region "Guardar"
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Guardar()
        If opGuardar = True Then
            cancelar()
        End If
    End Sub
    Private Function VerificarInformación() As Boolean
        Dim bandera As Boolean = False
        If txtAbreviación.Text = "" Then
            MsgBox("Es necesario que ingrese la Abreviación", MsgBoxStyle.Information) : bandera = True : txtAbreviación.Focus()
        ElseIf txtDescripcion.Text = "" Then
            MsgBox("Es necesario que ingrese la Descripción", MsgBoxStyle.Information) : bandera = True : txtDescripcion.Focus()
        ElseIf cboTipoDato.Text = "" Then
            MsgBox("Es necesario que escoja el tipo de dato", MsgBoxStyle.Information) : bandera = True : cboTipoDato.Focus()
        ElseIf txtCampoAsignado.Text = "" Then
            MsgBox("Es necesario que ingrese el campo asignado", MsgBoxStyle.Information) : bandera = True : txtCampoAsignado.Focus()
        End If
        Return bandera
    End Function
    Private Sub Guardar()
        If VerificarInformación() = True Then Exit Sub
        Dim aux As New CamposAuxiliares()
        aux.conectar = conectar
        aux.Abreviación = txtAbreviación.Text
        aux.Descripción = txtDescripcion.Text
        aux.TipoDato = cboTipoDato.Text
        If txtLongitud.Text <> "" Then aux.Longitud = CLng(txtLongitud.Text)
        If txtDecimales.Text <> "" Then aux.Decimales = CLng(txtDecimales.Text)
        If optDirectorio.Checked Then
            aux.Origen = "Directorio"
        ElseIf optSyscod.Checked Then
            aux.Origen = "Syscod"
        Else
            aux.Origen = "Manual"
        End If
        aux.CampoAsignado = txtCampoAsignado.Text
        If accion = "Abrir" Then aux.Actualizar(txtAbreviación.Text) Else aux.Guardar()
        opGuardar = True
    End Sub
#End Region

#Region "Eliminar"
    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim confirmar As Integer = MsgBox("Esta seguro que quiere eliminar el Campo " & txtAbreviación.Text & "-" & txtDescripcion.Text & "?", MsgBoxStyle.YesNo)
        If confirmar = vbYes Then
            eliminar(txtAbreviación.Text)
            limpiar(Me)
            bloquearDesbloquear(True)
        End If
    End Sub
    Private Sub eliminar(ByVal cod As String)
        Dim aux As New CamposAuxiliares
        aux.Eliminar(cod)
    End Sub
#End Region

#Region "Cancelar/Salir"
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Dispose()
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If cambios > 0 Then
            If MsgBox("Desea guardar los cambios") = vbYes Then
                Guardar()
                If opGuardar = True Then
                    cancelar()
                End If
            Else : cancelar()
            End If
            Else cancelar()
        End If
    End Sub
    Private Sub cancelar()
        limpiar(Me)
        bloquearDesbloquear(True)
        cambios = 0
        opGuardar = False
        accion = ""
    End Sub
#End Region

#Region "Cambios"
    Private Sub txtAbreviación_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAbreviación.TextChanged
        cambios += 1
    End Sub

    Private Sub txtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged
        cambios += 1
    End Sub

    Private Sub txtLongitud_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLongitud.TextChanged
        cambios += 1
    End Sub

    Private Sub txtDecimales_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDecimales.TextChanged
        cambios += 1
    End Sub

    Private Sub optDirectorio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optDirectorio.CheckedChanged
        cambios += 1
    End Sub

    Private Sub optSyscod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optSyscod.CheckedChanged
        cambios += 1
    End Sub

    Private Sub optManual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optManual.CheckedChanged
        cambios += 1
    End Sub

    Private Sub txtCampoAsignado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCampoAsignado.TextChanged
        cambios += 1
    End Sub
#End Region

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class