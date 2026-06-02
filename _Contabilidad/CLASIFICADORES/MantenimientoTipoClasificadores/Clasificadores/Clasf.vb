Imports System.Data.SqlClient
Friend Class frmClasf
    Dim conectar As New SqlConnection()
    Dim accion As String = ""
    Dim codigo As String = ""
    Dim opGuardar As Boolean = False
    Dim cambios As Integer = 0
    '    Dim strConxAdcom As String = ""
    Dim opc As Integer = 0
    Dim existe As Boolean = False
    ' campos de la tabla
    Dim nombre As String = ""
    Dim Descripción As String = ""
    Dim regPorConcepto As Boolean = False
    Dim campotra As String = ""
    Dim campodia As String = ""
    Dim origenvalores As String = ""
    Dim status As Boolean = False
    Dim IDCLAVE As Integer = 0
    Dim TipoDirectorio As String = ""
    Dim GrupoDirectorio As String = ""
    Dim TipoDato As String = ""
    Dim Longitud As Integer = 0
    Dim Decimales As Integer = 0
    Dim EsClasificador As Boolean = False
    Dim EsClasificadorSimple As Boolean = False
    Dim padre As String = "0"
    Dim CreadoUsuario As Boolean = False
    Dim org As String = ""
    Friend strConxAdcom As String
    Friend StrCod As String

#Region "Inicializar Datos"
    Private Sub limpiar(ByVal Obj As Object)
        'Dim Control1 As System.Windows.Forms.Control
        Dim a As String
        For Each Control1 As Control In Me.Controls()
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
        btnCancelar.Enabled = Not op
        GroupBox1.Enabled = Not op
        GroupBox3.Enabled = Not op

        BloqPred(True)
    End Sub

    Private Sub Clasf_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If cambios > 0 Then
            If MsgBox("Desea guardar los cambios", MsgBoxStyle.YesNo) = vbYes Then
                Guardar()
                If opGuardar = True Then
                    cancelar()
                End If
            Else : cancelar()
            End If
        Else : cancelar()
        End If
    End Sub
    Private Sub DatosAuxiliares_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conectar.ConnectionString = strConxAdcom
        conectar.Open()
        If StrCod <> "" Then accion = "Abrir" : codigo = StrCod Else accion = "Nuevo"
        bloquearDesbloquear(True)
        If accion = "Abrir" Then abrir(codigo)
    End Sub
    Private Sub optManual_CheckedChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles optManual.CheckedChanged
        org = "manual"
    End Sub

    Private Sub optSyscod_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optSyscod.CheckedChanged
        org = "general"
    End Sub

    Private Sub optDirectorio_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optDirectorio.CheckedChanged
        org = "directorio"
    End Sub

    Private Sub optArticulos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optArticulos.CheckedChanged
        org = "articulos"
    End Sub

    Private Sub optServicios_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optServicios.CheckedChanged
        org = "servicios"
    End Sub

    Private Sub optProduccion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optProduccion.CheckedChanged
        org = "produccion"
    End Sub
#End Region

#Region "Nuevo"
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        nuevo()
        CreadoUsuario = True
    End Sub
    Private Sub nuevo()
        limpiar(Me)
        bloquearDesbloquear(False)
        LlenarClasfPadre("")
        cambios = 0
        accion = "Guardar"
        opGuardar = False
    End Sub
    Private Sub cboTipoDato_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoDato.SelectedIndexChanged
        cambios += 1
        HabilitarCampos(cboTipoDato.Text)
        If cboTipoDato.Text <> "" Then buscaUltCampo(cboTipoDato.Text)
    End Sub
    Private Sub LlenarClasfPadre(ByVal cod As String)
        Dim ssql As String = "select '' as nombre union all select nombre from  adcclasfctb where nombre <>'" & cod & "'"
        Dim datS As New DataSet()
        Dim datA As New SqlDataAdapter(ssql, conectar)
        If conectar.State = 0 Then conectar.Open()
        datA.Fill(datS, "Datos")
        cboClafPadre.DataSource = datS.Tables(0)
        cboClafPadre.DisplayMember = "nombre"
        cboClafPadre.ValueMember = "nombre"
        conectar.Close()
    End Sub
    Private Sub HabilitarCampos(ByVal tipoDato As String)
        If tipoDato = "Alfanumérico" Then
            txtLongitud.Enabled = True
            txtDecimales.Enabled = False
        ElseIf tipoDato = "Numérico Entero" Then
            txtLongitud.Enabled = False
            txtDecimales.Enabled = False
        ElseIf tipoDato = "Numérico Decimal" Then
            txtLongitud.Enabled = True
            txtDecimales.Enabled = True
        ElseIf tipoDato = "Datetime" Then
            txtLongitud.Enabled = False
            txtDecimales.Enabled = False
        ElseIf tipoDato = "Boolean" Then
            txtLongitud.Enabled = False
            txtDecimales.Enabled = False
        End If
    End Sub
#End Region

#Region "Abrir"
    Private Sub btnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrir.Click
        Dim busk As New Buscar.frmBuscar
        Dim cod As String = ""
        cod = busk.Buscar(strConxAdcom, "select Nombre,Descripción from adcclasfctb where nombre <>'' ", "Nombre", "Descripción", "Consulta", "Campos Auxiliares")
        If cod <> "" Then LlenarClasfPadre(txtAbreviación.Text) : abrir(cod) : accion = "Abrir"
        cambios = 0
    End Sub

    Private Sub abrir(ByVal cod As String)
        limpiar(Me)
        bloquearDesbloquear(False)
        If CreadoUsuario = False Then BloqPred(False)
        CargarDatos(cod)
    End Sub

    Private Sub BloqPred(ByVal op As Boolean)
        txtAbreviación.Enabled = op
        cboTipoDato.Enabled = op
        txtLongitud.Enabled = op
        txtDecimales.Enabled = op
        cboClaseCampo.Enabled = op
        GroupBox3.Enabled = op
        GroupBox4.Enabled = Not EsClasificador
    End Sub

    Private Sub leerDatosBd(ByVal cod As String)
        Dim cmp As New ClsDatAux
        cmp.CargarCamp(cod, strConxAdcom)
        nombre = cmp.nombre
        Descripción = cmp.Descripción
        regPorConcepto = cmp.regPorConcepto
        campotra = cmp.campotra
        campodia = cmp.campodia
        origenvalores = cmp.origenvalores
        status = cmp.status
        IDCLAVE = cmp.IDCLAVE
        TipoDirectorio = cmp.TipoDirectorio
        GrupoDirectorio = cmp.GrupoDirectorio
        TipoDato = cmp.TipoDato
        Longitud = cmp.Longitud
        Decimales = cmp.Decimales
        EsClasificador = cmp.EsClasificador
        EsClasificadorSimple = cmp.EsClasificadorSimple
        padre = cmp.padre
        CreadoUsuario = cmp.CreadoUsuario
    End Sub

    Private Sub CargarDatos(ByVal cod As String)
        leerDatosBd(cod)
        Dim orig As String = origenvalores.ToUpper
        txtAbreviación.Text = cod
        txtDescripcion.Text = Descripción
        If CInt(regPorConcepto) = 0 Then cboClaseCampo.Text = "Añadir campo por Documento" : existe = True Else cboClaseCampo.Text = "Añadir campo por Item" : existe = True
        cboTipoDato.Text = TipoDato
        txtLongitud.Text = CStr(Longitud)
        txtDecimales.Text = CStr(Decimales)
        Select Case orig
            Case "GENERALES"
                optSyscod.Checked = True
            Case "DIRECTORIO"
                optDirectorio.Checked = True
                cboGrupDir.Text = GrupoDirectorio
            Case "MANUAL"
                optManual.Checked = True
            Case "ARTICULOS"
                optArticulos.Checked = True
            Case "CONCEPTOS"
                optServicios.Checked = True
            Case "PRODUCCION"
                optProduccion.Checked = True
        End Select
        If EsClasificador = True Then ClasContable.Checked = True Else ClasContable.Checked = False
        If EsClasificadorSimple = True Then ClasSimple.Checked = True Else ClasSimple.Checked = False
        cboClafPadre.SelectedValue = padre
        txtCampoAsignado.Text = campodia
        cambios = 0
    End Sub
    Private Sub demarcarOpr()
        optArticulos.Checked = False
        optDirectorio.Checked = False
        optManual.Checked = False
        optProduccion.Checked = False
        optServicios.Checked = False
        optSyscod.Checked = False
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
            If CreadoUsuario = True Then MsgBox("Es necesario que escoja el tipo de dato", MsgBoxStyle.Information) : bandera = True : cboTipoDato.Focus()
        ElseIf cboClaseCampo.Text = "" Then
            MsgBox("Es necesario que ingrese la ubicación del campo ", MsgBoxStyle.Information) : bandera = True : cboClaseCampo.Focus()
        ElseIf cboTipoDato.Text = "Alfanumérico" Or cboTipoDato.Text = "Numérico Decimal" Then
            If txtLongitud.Text = "" Then MsgBox("Es necesario que ingrese la longitud del campo ", MsgBoxStyle.Information) : bandera = True : txtLongitud.Focus()
        End If
        Return bandera
    End Function
    Private Function ObtenerIdClave() As Integer
        Dim clave As Integer = 0
        Dim ssql As String = "select max(IDCLAVE) as clave from adcclasfctb"
        Dim cmd As New SqlCommand(ssql, conectar)
        Dim dat As SqlDataReader = Nothing
        If conectar.State = ConnectionState.Open Then conectar.Close()
        conectar.Open()
        dat = cmd.ExecuteReader()
        If dat.Read Then
            If Not IsDBNull(dat(0)) Then clave = CInt(dat(0).ToString()) + 1 Else clave = 1
        Else
            clave = 1
        End If
        conectar.Close()
        Return clave
    End Function
    Private Sub LeerOpciones()
        nombre = txtAbreviación.Text
        Descripción = txtDescripcion.Text
        IDCLAVE = ObtenerIdClave()
        If cboClaseCampo.Text = "Añadir campo por Documento" Then regPorConcepto = CBool(0) Else regPorConcepto = CBool(1)
        TipoDato = CStr(cboTipoDato.SelectedItem)
        Longitud = CInt(Val(txtLongitud.Text))
        Decimales = CInt(Val(txtDecimales.Text))
        origenvalores = org
        GrupoDirectorio = cboGrupDir.Text
        If ClasContable.Checked = True Then EsClasificador = CBool(1) Else EsClasificador = CBool(0)
        If ClasSimple.Checked = True Then EsClasificadorSimple = CBool(1) Else EsClasificadorSimple = CBool(0)
        padre = cboClafPadre.SelectedValue.ToString
    End Sub
    Private Sub Guardar()
        If VerificarInformación() = True Then Exit Sub
        LeerOpciones()
        Dim cmp As New ClsDatAux
        cmp.nombre = nombre
        cmp.Descripción = Descripción
        cmp.regPorConcepto = regPorConcepto
        cmp.campotra = campotra
        cmp.campodia = campodia
        cmp.origenvalores = origenvalores
        cmp.status = status
        cmp.IDCLAVE = IDCLAVE
        cmp.TipoDirectorio = TipoDirectorio
        cmp.GrupoDirectorio = GrupoDirectorio
        cmp.TipoDato = TipoDato
        cmp.Longitud = Longitud
        cmp.Decimales = Decimales
        cmp.EsClasificador = EsClasificador
        cmp.EsClasificadorSimple = EsClasificadorSimple
        cmp.padre = padre
        cmp.CreadoUsuario = CreadoUsuario
        If accion = "Abrir" Then cmp.Actualizar(txtAbreviación.Text, strConxAdcom) Else cmp.Guardar(strConxAdcom)
        opGuardar = True
    End Sub
#End Region

#Region "Busca Ultimo Campo"

    Private Sub buscaUltCampo(ByVal tipo As String)
        Dim campo As String = ""
        Dim num As String = ""
        Dim ssql As String = ""
        Select Case tipo
            Case "Alfanumérico"
                campo = "AuxVar"
            Case "Numérico Entero"
                campo = "AuxNum"
            Case "Numérico Decimal"
                campo = "AuxNum"
            Case "Datetime"
                campo = "AuxFec"
            Case "Boolean"
                campo = "AuxLog"
        End Select
        num = RetornaCampo("select top 1 campotra from adcclasfctb where campotra like'" & campo & "%' order by campotra desc")
        campotra = campo & num
        num = RetornaCampo("select top 1 campodia from adcclasfctb where campotra like'" & campo & "%' order by campotra desc")
        campodia = campo & num
        txtCampoAsignado.Text = campodia
    End Sub
    Private Function RetornaCampo(ByVal cmdstr As String) As String
        Dim cmp As String = ""
        Dim res As String = ""
        Dim cmd As New SqlCommand(cmdstr, conectar)
        Dim dat As SqlDataReader
        conectar.Open()
        dat = cmd.ExecuteReader
        If dat.Read Then
            If Not IsDBNull(dat(0)) Then res = dat(0).ToString()
        End If
        If res <> "" Then cmp = CStr(Val(Strings.Right(res, 1)) + 1) Else cmp = "1"
        conectar.Close()
        Return cmp
    End Function
#End Region

#Region "Cancelar/Salir"
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If cambios > 0 Then
            If MsgBox("Desea guardar los cambios", MsgBoxStyle.YesNo) = vbYes Then
                Guardar()
                If opGuardar = True Then
                    cancelar()
                End If
            Else : cancelar()
            End If
        Else : cancelar()
        End If
    End Sub
    Private Sub cancelar()
        limpiar(Me)
        bloquearDesbloquear(True)
        cambios = 0
        opGuardar = False
        accion = ""
        existe = False
    End Sub
#End Region

#Region "Cambios"

    Private Sub txtAbreviación_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAbreviación.LostFocus
        abrir(txtAbreviación.Text)

        accion = "Abrir"
    End Sub
    Private Sub txtAbreviación_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAbreviación.TextChanged
        cambios += 1
    End Sub

    Private Sub txtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged
        cambios += 1
    End Sub

    Private Sub txtDecimales_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDecimales.KeyPress
        If InStr(1, "0123456789" & Chr(8) & Chr(13), e.KeyChar) = 0 Then e.KeyChar = CChar("")
    End Sub

    Private Sub txtDecimales_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDecimales.TextChanged
        cambios += 1
    End Sub

    Private Sub optDirectorio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios += 1
    End Sub

    Private Sub optSyscod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios += 1
    End Sub

    Private Sub optManual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios += 1
    End Sub

    Private Sub txtCampoAsignado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios += 1
    End Sub
#End Region


    Private Sub ClasSimple_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClasSimple.CheckedChanged
        If ClasSimple.Checked Then ClasContable.Checked = False
    End Sub

    Private Sub ClasContable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClasContable.CheckedChanged
        If ClasContable.Checked Then ClasSimple.Checked = False
    End Sub

    Private Sub txtLongitud_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLongitud.KeyPress
        If InStr(1, "0123456789" & Chr(8) & Chr(13), e.KeyChar) = 0 Then e.KeyChar = CChar("")
    End Sub

    Private Sub txtLongitud_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLongitud.TextChanged

    End Sub
End Class
