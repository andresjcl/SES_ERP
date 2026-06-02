Imports System.Data.SqlClient

Public Class Contabilización

    Dim conectar As New SqlConnection()
    Dim cambios As Integer = 0
    Dim Activo As String = ""
    Dim opGuardar As Boolean = False ' esta variable cambia a true cundo la configuracion se ha guardado correctamente
    Dim ActCont As Boolean = False ' esta variable cambia de esta cuando un activo ya tiene contabilización
    Dim accion As String = ""
    Dim op As String = "I"

#Region "Inicialización de datos"
    Private Sub ConectarBdd()
        Dim coneccion As New DaxLib.DaxLibBases
        coneccion.TipoBase = "10"
        conectar.ConnectionString = coneccion.StrAdcom
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
        btnSalir.Enabled = op
        BtnGuaradar.Enabled = Not op
        btnModificar.Enabled = op
        BtnEliminar.Enabled = Not op
        BtnCopiar.Enabled = Not op
        btnCancelar.Enabled = Not op
        GroupBox1.Enabled = Not op
        GroupBox2.Enabled = Not op
    End Sub
    Private Sub Contabilización_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ConectarBdd()
        bloquearDesbloquear(True)
        CargarInf()
    End Sub
#End Region

#Region "Nuevo/Modificar"
    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        bloquearDesbloquear(False)
    End Sub
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        limpiar(Me)
        Nuevo()
        cambios = 0
    End Sub
    Private Sub Nuevo()
        bloquearDesbloquear(False)
    End Sub
#End Region

#Region "Cargar Inf. Ctas"

    Private Sub CargarInf()
        Dim ssql As String = ""
        Dim dat As SqlDataReader = Nothing
        ssql = "select CtaDebeRevalorizaF,CtaDebeDeterioroF,CtaDebeDepreciacionF,CtaDebeDiferenciaDepF,CtaDebeAux1F,CtaHaberRevalorizaF,CtaHaberDeterioroF,CtaHaberDepreciacionF,"
        ssql += " CtaHaberDiferenciaDepF,CtaHaberAux1F,CtaDebeDepreciacionT,CtaHaberDepreciacionT,CtaDebeAux1T,CtaDebeAux2T,CtaDebeAux3T,CtaDebeAux4T,CtaHaberAux1T,CtaHaberAux2T,"
        ssql += " CtaHaberAux3T,CtaHaberAux4T from adcacfconta "
        Dim cmd As New SqlCommand(ssql, conectar)
        If conectar.State = ConnectionState.Open Then conectar.Close()
        conectar.Open()
        dat = cmd.ExecuteReader()
        If dat.Read Then
            accion = "Cargar"
            op = "U"
            If Not IsDBNull(dat(0)) Then txtRevalCodDebe.Text = dat(0)
            If Not IsDBNull(dat(1)) Then txtDeterioroCodDebe.Text = dat(1)
            If Not IsDBNull(dat(2)) Then txtDepreCodDebe.Text = dat(2)
            If Not IsDBNull(dat(3)) Then txtDiferenciaDepCodDebe.Text = dat(3)
            If Not IsDBNull(dat(4)) Then txtAux1CodDebe.Text = dat(4)
            If Not IsDBNull(dat(5)) Then txtRevalCodHaber.Text = dat(5)
            If Not IsDBNull(dat(6)) Then txtDeterioroCodHaber.Text = dat(6)
            If Not IsDBNull(dat(7)) Then txtDepreCodHaber.Text = dat(7)
            If Not IsDBNull(dat(8)) Then txtDiferenciaDepCodHaber.Text = dat(8)
            If Not IsDBNull(dat(9)) Then txtAux1CodHaber.Text = dat(9)
            If Not IsDBNull(dat(10)) Then txtDepreTCodDebe.Text = dat(10)
            If Not IsDBNull(dat(11)) Then txtDepreTCodHaber.Text = dat(11)
            If Not IsDBNull(dat(12)) Then txtAux1TCodDebe.Text = dat(12)
            If Not IsDBNull(dat(13)) Then txtAux2TCodDebe.Text = dat(13)
            If Not IsDBNull(dat(14)) Then txtAux3TCodDebe.Text = dat(14)
            If Not IsDBNull(dat(15)) Then txtAux4TCodDebe.Text = dat(15)
            If Not IsDBNull(dat(16)) Then txtAux1TCodHaber.Text = dat(16)
            If Not IsDBNull(dat(17)) Then txtAux2TCodHaber.Text = dat(17)
            If Not IsDBNull(dat(18)) Then txtAux3TCodHaber.Text = dat(18)
            If Not IsDBNull(dat(19)) Then txtAux4TCodHaber.Text = dat(19)
            ActCont = True
        Else
            op = "I"
        End If
        conectar.Close()
        If txtRevalCodDebe.Text <> "" Then Descripciones(txtRevalCodDebe.Text, txtRevalDebe)
        If txtDeterioroCodDebe.Text <> "" Then Descripciones(txtDeterioroCodDebe.Text, txtDeterioroDebe)
        If txtDepreCodDebe.Text <> "" Then Descripciones(txtDepreCodDebe.Text, txtDepreDebe)
        If txtDiferenciaDepCodDebe.Text <> "" Then Descripciones(txtDiferenciaDepCodDebe.Text, txtDiferenciaDepDebe)
        If txtRevalCodHaber.Text <> "" Then Descripciones(txtRevalCodHaber.Text, txtRevalHaber)
        If txtDeterioroCodHaber.Text <> "" Then Descripciones(txtDeterioroCodHaber.Text, txtDeterioroHaber)
        If txtDepreCodHaber.Text <> "" Then Descripciones(txtDepreCodHaber.Text, txtDepreHaber)
        If txtDiferenciaDepCodHaber.Text <> "" Then Descripciones(txtDiferenciaDepCodHaber.Text, txtDiferenciaDepHaber)
        If txtAux1CodHaber.Text <> "" Then Descripciones(txtAux1CodHaber.Text, txtAux1Haber)
        If txtAux1CodDebe.Text <> "" Then Descripciones(txtAux1CodDebe.Text, txtAux1Debe)
        If txtDepreTCodDebe.Text <> "" Then Descripciones(txtDepreTCodDebe.Text, txtDepreTDebe)
        If txtAux1TCodDebe.Text <> "" Then Descripciones(txtAux1TCodDebe.Text, txtAux1TDebe)
        If txtAux2TCodDebe.Text <> "" Then Descripciones(txtAux2TCodDebe.Text, txtAux2TDebe)
        If txtAux3TCodDebe.Text <> "" Then Descripciones(txtAux3TCodDebe.Text, txtAux3TDebe)
        If txtAux4TCodDebe.Text <> "" Then Descripciones(txtAux4TCodDebe.Text, txtAux4TDebe)
        If txtDepreTCodHaber.Text <> "" Then Descripciones(txtDepreTCodHaber.Text, txtDepreTHaber)
        If txtAux1TCodHaber.Text <> "" Then Descripciones(txtAux1TCodHaber.Text, txtAux1THaber)
        If txtAux2TCodHaber.Text <> "" Then Descripciones(txtAux2TCodHaber.Text, txtAux2THaber)
        If txtAux3TCodHaber.Text <> "" Then Descripciones(txtAux3TCodHaber.Text, txtAux3THaber)
        If txtAux4TCodHaber.Text <> "" Then Descripciones(txtAux4TCodHaber.Text, txtAux4THaber)
        accion = ""
    End Sub
    Private Sub Descripciones(ByVal cod As String, ByVal txt As TextBox)
        Dim ssql As String = "select cta_nombre from adcCta where cta_codigo='" & cod & "'"
        Dim cmd As New SqlCommand(ssql, conectar)
        Dim dat As SqlDataReader = Nothing
        If conectar.State = ConnectionState.Open Then conectar.Close()
        conectar.Open()
        dat = cmd.ExecuteReader()
        If dat.Read Then
            If Not IsDBNull(dat(0)) Then txt.Text = dat(0) Else txt.Text = ""
        Else : txt.Text = ""
        End If
        conectar.Close()
    End Sub

    Private Sub txtRevalCodDebe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRevalCodDebe.TextChanged
        cambios += 1
        If accion <> "Cargar" Then Descripciones(txtRevalCodDebe.Text, txtRevalDebe)
    End Sub
    Private Sub txtRevalCodHaber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRevalCodHaber.TextChanged
        cambios += 1
        If accion <> "Cargar" Then Descripciones(txtRevalCodHaber.Text, txtRevalHaber)
    End Sub
    Private Sub txtDeterioroCodDebe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDeterioroCodDebe.TextChanged
        cambios += 1
        If accion <> "Cargar" Then Descripciones(txtDeterioroCodDebe.Text, txtDeterioroDebe)
    End Sub
    Private Sub txtDeterioroCodHaber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDeterioroCodHaber.TextChanged
        cambios += 1
        If accion <> "Cargar" Then Descripciones(txtDeterioroCodHaber.Text, txtDeterioroHaber)
    End Sub
    Private Sub txtDepreCodDebe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDepreCodDebe.TextChanged
        cambios += 1
        If accion <> "Cargar" Then Descripciones(txtDepreCodDebe.Text, txtDepreDebe)
    End Sub
    Private Sub txtDepreCodHaber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDepreCodHaber.TextChanged
        cambios += 1
        If accion <> "Cargar" Then Descripciones(txtDepreCodHaber.Text, txtDepreHaber)
    End Sub
    Private Sub txtAux1CodDebe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiferenciaDepCodDebe.TextChanged
        cambios += 1
        If accion <> "Cargar" Then Descripciones(txtDiferenciaDepCodDebe.Text, txtDiferenciaDepDebe)
    End Sub
    Private Sub txtAux1CodHaber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiferenciaDepCodHaber.TextChanged
        cambios += 1
        If accion <> "Cargar" Then Descripciones(txtDiferenciaDepCodHaber.Text, txtDiferenciaDepHaber)
    End Sub
    Private Sub txtAux2CodDebe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAux1CodDebe.TextChanged
        cambios += 1
        If accion <> "Cargar" Then Descripciones(txtAux1CodDebe.Text, txtAux1Debe)
    End Sub
    Private Sub txtAux2CodHaber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAux1CodHaber.TextChanged
        cambios += 1
        If accion <> "Cargar" Then Descripciones(txtAux1CodHaber.Text, txtAux1Haber)
    End Sub
    Private Sub txtDepreTCodDebe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDepreTCodDebe.TextChanged
        cambios += 1
        If accion <> "Cargar" Then Descripciones(txtDepreTCodDebe.Text, txtDepreTDebe)
    End Sub
    Private Sub txtDepreTCodHaber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDepreTCodHaber.TextChanged
        cambios += 1
        If accion <> "Cargar" Then Descripciones(txtDepreTCodHaber.Text, txtDepreTHaber)
    End Sub
    Private Sub txtAux1TCodDebe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAux1TCodDebe.TextChanged
        cambios += 1
        If accion <> "Cargar" Then Descripciones(txtAux1TCodDebe.Text, txtAux1TDebe)
    End Sub
    Private Sub txtAux1TCodHaber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAux1TCodHaber.TextChanged
        cambios += 1
        If accion <> "Cargar" Then Descripciones(txtAux1TCodHaber.Text, txtAux1THaber)
    End Sub
    Private Sub txtAux2TCodDebe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAux2TCodDebe.TextChanged
        cambios += 1
        If accion <> "Cargar" Then Descripciones(txtAux2TCodDebe.Text, txtAux2TDebe)
    End Sub
    Private Sub txtAux2TCodHaber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAux2TCodHaber.TextChanged
        cambios += 1
        If accion <> "Cargar" Then Descripciones(txtAux2TCodHaber.Text, txtAux2THaber)
    End Sub
    Private Sub txtAux3TCodDebe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAux3TCodDebe.TextChanged
        cambios += 1
        If accion <> "Cargar" Then Descripciones(txtAux3TCodDebe.Text, txtAux3TDebe)
    End Sub
    Private Sub txtAux3TCodHaber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAux3TCodHaber.TextChanged
        cambios += 1
        If accion <> "Cargar" Then Descripciones(txtAux3TCodHaber.Text, txtAux3THaber)
    End Sub
    Private Sub txtAux4TCodDebe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAux4TCodDebe.TextChanged
        cambios += 1
        If accion <> "Cargar" Then Descripciones(txtAux4TCodDebe.Text, txtAux4TDebe)
    End Sub
    Private Sub txtAux4TCodHaber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAux4TCodHaber.TextChanged
        cambios += 1
        If accion <> "Cargar" Then Descripciones(txtAux4TCodHaber.Text, txtAux4THaber)
    End Sub
#End Region

#Region "Buscador Cta"
    Private Sub btnRevalDebe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRevalDebe.Click
        buscadorCta(txtRevalCodDebe)
        If txtRevalCodDebe.Text <> "" Then Descripciones(txtRevalCodDebe.Text, txtRevalDebe)
    End Sub
    Private Sub btnRevalHaber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRevalHaber.Click
        buscadorCta(txtRevalCodHaber)
        If txtRevalCodHaber.Text <> "" Then Descripciones(txtRevalCodHaber.Text, txtRevalHaber)
    End Sub

    Private Sub btnDeterioroDebe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeterioroDebe.Click
        buscadorCta(txtDeterioroCodDebe)
        If txtDeterioroCodDebe.Text <> "" Then Descripciones(txtDeterioroCodDebe.Text, txtDeterioroDebe)
    End Sub

    Private Sub btnDeterioroHaber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeterioroHaber.Click
        buscadorCta(txtDeterioroCodHaber)
        If txtDeterioroCodHaber.Text <> "" Then Descripciones(txtDeterioroCodHaber.Text, txtDeterioroHaber)
    End Sub

    Private Sub btnDepreDebe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDepreDebe.Click
        buscadorCta(txtDepreCodDebe)
        If txtDepreCodDebe.Text <> "" Then Descripciones(txtDepreCodDebe.Text, txtDepreDebe)
    End Sub

    Private Sub btnDepreHaber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDepreHaber.Click
        buscadorCta(txtDepreCodHaber)
        If txtDepreCodHaber.Text <> "" Then Descripciones(txtDepreCodHaber.Text, txtDepreHaber)
    End Sub

    Private Sub btnDiferenciaDepDebe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDiferenciaDepDebe.Click
        buscadorCta(txtDiferenciaDepCodDebe)
        If txtDiferenciaDepCodDebe.Text <> "" Then Descripciones(txtDiferenciaDepCodDebe.Text, txtDiferenciaDepDebe)
    End Sub

    Private Sub btnDiferenciaDepHaber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDiferenciaDepHaber.Click
        buscadorCta(txtDiferenciaDepCodHaber)
        If txtDiferenciaDepCodHaber.Text <> "" Then Descripciones(txtDiferenciaDepCodHaber.Text, txtDiferenciaDepHaber)
    End Sub

    Private Sub btnAux2Debe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAux2Debe.Click
        buscadorCta(txtAux1CodDebe)
        If txtAux1CodDebe.Text <> "" Then Descripciones(txtAux1CodDebe.Text, txtAux1Debe)
    End Sub

    Private Sub btnAux2Haber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAux2Haber.Click
        buscadorCta(txtAux1CodHaber)
        If txtAux1CodHaber.Text <> "" Then Descripciones(txtAux1CodHaber.Text, txtAux1Haber)
    End Sub

    Private Sub btnDepreTDebe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDepreTDebe.Click
        buscadorCta(txtDepreTCodDebe)
        If txtDepreTCodDebe.Text <> "" Then Descripciones(txtDepreTCodDebe.Text, txtDepreTDebe)
    End Sub

    Private Sub btnDpreTHaber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDpreTHaber.Click
        buscadorCta(txtDepreTCodHaber)
        If txtDepreTCodHaber.Text <> "" Then Descripciones(txtDepreTCodHaber.Text, txtDepreTHaber)
    End Sub

    Private Sub btnAux1TDebe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAux1TDebe.Click
        buscadorCta(txtAux1TCodDebe)
        If txtAux1TCodDebe.Text <> "" Then Descripciones(txtAux1TCodDebe.Text, txtAux1TDebe)
    End Sub

    Private Sub btnAux1THaber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAux1THaber.Click
        buscadorCta(txtAux1TCodHaber)
        If txtAux1TCodHaber.Text <> "" Then Descripciones(txtAux1TCodHaber.Text, txtAux1THaber)
    End Sub

    Private Sub btnAux2TDebe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAux2TDebe.Click
        buscadorCta(txtAux2TCodDebe)
        If txtAux2TCodDebe.Text <> "" Then Descripciones(txtAux2TCodDebe.Text, txtAux2TDebe)
    End Sub

    Private Sub btnAux2THaber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAux2THaber.Click
        buscadorCta(txtAux2TCodHaber)
        If txtAux2TCodHaber.Text <> "" Then Descripciones(txtAux2TCodHaber.Text, txtAux2THaber)
    End Sub

    Private Sub btnAux3TDebe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAux3TDebe.Click
        buscadorCta(txtAux3TCodDebe)
        If txtAux3TCodDebe.Text <> "" Then Descripciones(txtAux3TCodDebe.Text, txtAux3TDebe)
    End Sub

    Private Sub btnAux3THaber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAux3THaber.Click
        buscadorCta(txtAux3TCodHaber)
        If txtAux3TCodHaber.Text <> "" Then Descripciones(txtAux3TCodHaber.Text, txtAux3THaber)
    End Sub

    Private Sub btnAux4TDebe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAux4TDebe.Click
        buscadorCta(txtAux4TCodDebe)
        If txtAux4TCodDebe.Text <> "" Then Descripciones(txtAux4TCodDebe.Text, txtAux4TDebe)
    End Sub

    Private Sub btnAux4THaber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAux4THaber.Click
        buscadorCta(txtAux4TCodHaber)
        If txtAux4TCodHaber.Text <> "" Then Descripciones(txtAux4TCodHaber.Text, txtAux4THaber)
    End Sub

    Private Sub buscadorCta(ByVal txt As TextBox)
        Dim nombre As String = ""
        Dim cta As New MantCtb.BuscaCta
        txt.Text = cta.BuscaCtaCtb(nombre, "I")
    End Sub
#End Region

#Region "Guardar/Eliminar"
    Private Sub BtnGuaradar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuaradar.Click
        Guardar()
        If opGuardar = True Then
            Cancelar()
        End If
    End Sub
    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        Dim confirmar As Integer = 0
        confirmar = MsgBox("Esta seguro que desea borrar la contabilización de los activos ?", MsgBoxStyle.YesNo)
        If confirmar = vbYes Then
            limpiar(Me)
            Dim ssql As String = "delete from adcacfconta "
            Dim cmd As New SqlCommand(ssql, conectar)
            If conectar.State = ConnectionState.Open Then conectar.Close()
            conectar.Open()
            cmd.ExecuteNonQuery()
            conectar.Close()
            MsgBox("Proceso realizado con éxito", MsgBoxStyle.Information)
            limpiar(Me)
            Cancelar()
        End If
    End Sub
    Private Sub Guardar()
        Dim ssql As String = ""
        If op = "U" Then
            ssql = "update AdcAcfConta set "
            ssql += "CtaDebeRevalorizaF= '" & txtRevalCodDebe.Text & "',"
            ssql += "CtaDebeDeterioroF= '" & txtDeterioroCodDebe.Text & "',"
            ssql += "CtaDebeDepreciacionF= '" & txtDepreCodDebe.Text & "',"
            ssql += "CtaDebeDiferenciaDepF= '" & txtDiferenciaDepCodDebe.Text & "',"
            ssql += "CtaDebeAux1F= '" & txtAux1CodDebe.Text & "',"
            ssql += "CtaHaberRevalorizaF= '" & txtRevalCodHaber.Text & "',"
            ssql += "CtaHaberDeterioroF= '" & txtDeterioroCodHaber.Text & "',"
            ssql += "CtaHaberDepreciacionF= '" & txtDepreCodHaber.Text & "',"
            ssql += "CtaHaberDiferenciaDepF= '" & txtDiferenciaDepCodHaber.Text & "',"
            ssql += "CtaHaberAux1F= '" & txtAux1CodHaber.Text & "',"
            ssql += "CtaDebeDepreciacionT= '" & txtDepreTCodDebe.Text & "',"
            ssql += "CtaHaberDepreciacionT= '" & txtDepreTCodHaber.Text & "',"
            ssql += "CtaDebeAux1T= '" & txtAux1TCodDebe.Text & "',"
            ssql += "CtaDebeAux2T= '" & txtAux2TCodDebe.Text & "',"
            ssql += "CtaDebeAux3T= '" & txtAux3TCodDebe.Text & "',"
            ssql += "CtaDebeAux4T= '" & txtAux4TCodDebe.Text & "',"
            ssql += "CtaHaberAux1T= '" & txtAux1TCodHaber.Text & "',"
            ssql += "CtaHaberAux2T= '" & txtAux2TCodHaber.Text & "',"
            ssql += "CtaHaberAux3T= '" & txtAux3TCodDebe.Text & "',"
            ssql += "CtaHaberAux4T= '" & txtAux4TCodHaber.Text & "' "
        Else
            ssql = "insert into AdcAcfConta ("
            ssql += "CtaDebeRevalorizaF,"
            ssql += "CtaDebeDeterioroF,"
            ssql += "CtaDebeDepreciacionF,"
            ssql += "CtaDebeDiferenciaDepF,"
            ssql += "CtaDebeAux1F,"
            ssql += "CtaHaberRevalorizaF,"
            ssql += "CtaHaberDeterioroF,"
            ssql += "CtaHaberDepreciacionF,"
            ssql += "CtaHaberDiferenciaDepF,"
            ssql += "CtaHaberAux1F,"
            ssql += "CtaDebeDepreciacionT,"
            ssql += "CtaHaberDepreciacionT,"
            ssql += "CtaDebeAux1T,"
            ssql += "CtaDebeAux2T,"
            ssql += "CtaDebeAux3T,"
            ssql += "CtaDebeAux4T,"
            ssql += "CtaHaberAux1T,"
            ssql += "CtaHaberAux2T,"
            ssql += "CtaHaberAux3T,"
            ssql += "CtaHaberAux4T)"
            ssql += "values ("
            ssql += "'" & txtRevalCodDebe.Text & "',"
            ssql += "'" & txtDeterioroCodDebe.Text & "',"
            ssql += "'" & txtDepreCodDebe.Text & "',"
            ssql += "'" & txtDiferenciaDepCodDebe.Text & "',"
            ssql += "'" & txtAux1CodDebe.Text & "',"
            ssql += "'" & txtRevalCodHaber.Text & "',"
            ssql += "'" & txtDeterioroCodHaber.Text & "',"
            ssql += "'" & txtDepreCodHaber.Text & "',"
            ssql += "'" & txtDiferenciaDepCodHaber.Text & "',"
            ssql += "'" & txtAux1CodHaber.Text & "',"
            ssql += "'" & txtDepreTCodDebe.Text & "',"
            ssql += "'" & txtDepreTCodHaber.Text & "',"
            ssql += "'" & txtAux1TCodDebe.Text & "',"
            ssql += "'" & txtAux2TCodDebe.Text & "',"
            ssql += "'" & txtAux3TCodDebe.Text & "',"
            ssql += "'" & txtAux4TCodDebe.Text & "',"
            ssql += "'" & txtAux1TCodHaber.Text & "',"
            ssql += "'" & txtAux2TCodHaber.Text & "',"
            ssql += "'" & txtAux3TCodDebe.Text & "',"
            ssql += "'" & txtAux4TCodHaber.Text & "')"

        End If
        Dim cmd As New SqlCommand(ssql, conectar)
        If conectar.State = ConnectionState.Open Then conectar.Close()
        conectar.Open()
        cmd.ExecuteNonQuery()
        conectar.Close()
        opGuardar = True
    End Sub
#End Region

#Region "Cancelar"
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If cambios > 0 Then
            Dim confirmar As Integer = MsgBox("Desea guaradr los cambios?", MsgBoxStyle.YesNoCancel)
            If confirmar > vbYes Then
                BtnGuaradar_Click(sender, e)
            Else
                Cancelar()
            End If
        Else : Cancelar()
        End If
    End Sub
    Private Sub Cancelar()
        'limpiar(Me)
        bloquearDesbloquear(True)
        opGuardar = False
        ActCont = False
        op = "I"
        cambios = 0
    End Sub
#End Region

#Region "Copiar"

    'Private Sub BtnCopiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCopiar.Click
    '    Copiar()
    'End Sub
    'Private Sub Copiar()
    '    Dim busk As New MantenimientoAF.Buscar
    '    Dim cod As String
    '    cod = busk.Cargar("")
    '    If cod <> "" Then
    '        CargarInf()
    '    End If
    'End Sub
#End Region

#Region "Salir"

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Dispose()
    End Sub

#End Region

#Region "Cambios"

    Private Sub txtActDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios += 1
    End Sub

    Private Sub txtRevalDebe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRevalDebe.TextChanged
        cambios += 1
    End Sub

    Private Sub txtRevalHaber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRevalHaber.TextChanged
        cambios += 1
    End Sub

    Private Sub txtDeterioroDebe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDeterioroDebe.TextChanged
        cambios += 1
    End Sub

    Private Sub txtDeterioroHaber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDeterioroHaber.TextChanged
        cambios += 1
    End Sub

    Private Sub txtDepreDebe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDepreDebe.TextChanged
        cambios += 1
    End Sub

    Private Sub txtDepreHaber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDepreHaber.TextChanged
        cambios += 1
    End Sub

    Private Sub txtAux1Debe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiferenciaDepDebe.TextChanged
        cambios += 1
    End Sub

    Private Sub txtAux1Haber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiferenciaDepHaber.TextChanged
        cambios += 1
    End Sub

    Private Sub txtAux2Debe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAux1Debe.TextChanged
        cambios += 1
    End Sub

    Private Sub txtAux2Haber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAux1Haber.TextChanged
        cambios += 1
    End Sub

    Private Sub txtDepreTDebe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDepreTDebe.TextChanged
        cambios += 1
    End Sub

    Private Sub txtDepreTHaber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDepreTHaber.TextChanged
        cambios += 1
    End Sub

    Private Sub txtAux1TDebe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAux1TDebe.TextChanged
        cambios += 1
    End Sub

    Private Sub txtAux1THaber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAux1THaber.TextChanged
        cambios += 1
    End Sub

    Private Sub txtAux2TDebe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAux2TDebe.TextChanged
        cambios += 1
    End Sub

    Private Sub txtAux2THaber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAux2THaber.TextChanged
        cambios += 1
    End Sub

    Private Sub txtAux3TDebe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAux3TDebe.TextChanged
        cambios += 1
    End Sub

    Private Sub txtAux3THaber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAux3THaber.TextChanged
        cambios += 1
    End Sub

    Private Sub txtAux4TDebe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAux4TDebe.TextChanged
        cambios += 1
    End Sub

    Private Sub txtAux4THaber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAux4THaber.TextChanged
        cambios += 1
    End Sub
#End Region

    Public Sub DefinirContab()
        Me.Show()
    End Sub


End Class
