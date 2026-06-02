Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports DattCom

Public Class CreaCliAlex
    'Dim RsAlex As New ADODB.Recordset
    Dim ClienteProve, CodigoCli As String
    Dim EsNuevo As Object
    Dim Salir As Short
    Dim TipCod As String
    'Dim Act1 As Boolean
    Dim IniciarConCodigo As String

    Private Sub limpia()
        Dim telefono3 As String = ""
        On Error GoTo HayErrores
        nombres.Text = ""
        apellidos.Text = CStr(0)
        NombreImpresion.Text = ""
        telefono1.Text = ""
        telefono2.Text = ""
        telefono3 = ""
        codigo.Text = ""
        ruc.Text = ""
        codigo.ReadOnly = False
        Exit Sub

HayErrores:
        '  ControlaErrores
    End Sub

    Private Sub apellidos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles apellidos.TextChanged

        If Emp.OrdenaPorApellidos = False Then
            NombreImpresion.Text = Trim(nombres.Text & " " & apellidos.Text)
        Else
            NombreImpresion.Text = Trim(apellidos.Text & " " & nombres.Text)
        End If

    End Sub

    Private Sub btncontinuar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncontinuar.Click
        Grabar()
    End Sub

    Private Sub btncancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        On Error GoTo HayErrores
        Me.Close()
        Exit Sub
HayErrores:
        '  ControlaErrores
    End Sub
    Private Sub btnsalir_Click()
        Salir = 1
        Me.Close()
        Me.Dispose()
    End Sub
    Public Function IniCrearAlex(ByRef Tipo As String, Optional ByRef CodigoInicia As String = "") As String
        'Try
        ClienteProve = Tipo
        IniciarConCodigo = CodigoInicia
        Me.ShowDialog()
        'Catch ee As Exception
        'MsgBox("Excepción iniCrAlex: " & ee.Message)
        'End Try
        Return CodigoCli
    End Function

    Private Sub CBuscador_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBuscador.Click
        Me.UseWaitCursor = True
        Me.Cursor = Cursors.WaitCursor
        Dim ElNombre As String = ""
        Dim ElCodigo As String = ""
        Dim Buscod As New Syscod.ManSysnetClass
        TipCod = Buscod.BuscarReferencia("Ciudades", ElCodigo, ElNombre)
        Lcod.Text = ElNombre
        Me.UseWaitCursor = False
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub codigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles codigo.KeyDown
        Dim KeyCode As Short = CShort(e.KeyCode)
        Dim Shift As Short = CShort(e.KeyData \ &H10000)
        If KeyCode = System.Windows.Forms.Keys.F2 Then codigo.Text = ruc.Text
    End Sub

    'Private Sub CreaCliAlex_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    '    Dim Seleccion As String = ""
    '    If Act1 = False Then

    '        RsAlex.CursorType = ADODB.CursorTypeEnum.adOpenKeyset
    '        RsAlex.Open("select * from identificacion  " & Seleccion & "  order by codigo ", ConxAdcom, , ADODB.CommandTypeEnum.adCmdText)
    '        If RsAlex.State = 0 Then
    '            MsgBox("La configuración del sistema no acepta esta opción", MsgBoxStyle.Critical) : Me.Close()
    '        End If
    '        If IniciarConCodigo > "" Then codigo.Text = IniciarConCodigo : ruc.Text = codigo.Text : nombres.Focus()
    '        Act1 = True
    '    End If
    'End Sub

    Private Sub CreaCliAlex_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub CreaCliAlex_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Seleccion As Object
        'Dim i As Short
        On Error Resume Next
        Mainn()
        Seleccion = ""
        Select Case UCase(ClienteProve)
            Case "C"
                Me.Text = "Cliente"
                Seleccion = "escliente <> 0"
            Case "P"
                Me.Text = "Proveedor"
                Seleccion = "esproveedor<> 0"
            Case "E"
                Me.Text = "Empleado"
                Seleccion = "esempleado<> 0"
            Case "V"
                Me.Text = "Vendedor"
                Seleccion = "esvendedor<> 0"
            Case "F"
                Me.Text = "Institución Financiera"
                Seleccion = "esbanco <> 0"
        End Select
        TipoIdent.SelectedIndex = 2
        System.Windows.Forms.Application.DoEvents()
        If IniciarConCodigo > "" Then codigo.Text = IniciarConCodigo : ruc.Text = codigo.Text : nombres.Focus()

        'fprincipal1.Caption = CreaCliAlex.Caption
        Exit Sub
HayErrores:
        '  ControlaErrores
    End Sub
    Private Sub Grabar()
        'On Error Resume Next
        Dim cod As String

        'Dim ConxAdcom As New ADODB.Connection
        'ConxAdcom.ConnectionString = datosEmpresa.strConxAdcom_6
        'ConxAdcom.Open()

        'Dim RECIDE As New ADODB.Recordset
        'RECIDE = New ADODB.Recordset
        Dim Tip As String
        If codigo.Text = "" Then
            MsgBox("Debe ingresar un código", MsgBoxStyle.Information)
            codigo.Focus()
            Exit Sub
        End If
        If DattCom.datosEmpresa.LongCodDirectorio > 0 And codigo.Text.Length <> DattCom.datosEmpresa.LongCodDirectorio Then MsgBox("El código debe tener la longitud correcta (" + DattCom.datosEmpresa.LongCodDirectorio.ToString() + ")", MsgBoxStyle.Critical) : Exit Sub

        If ruc.Text = "" Then
            MsgBox("Debe ingesar el Ruc o la cédula")
            ruc.Focus()
            Exit Sub
        End If
        If nombres.Text = "" Then
            MsgBox("Debe ingresar el nombre ", MsgBoxStyle.Information)
            nombres.Focus()
            Exit Sub
        End If
        cod = codigo.Text
        If ValidaNumeroId() = False Then
            MsgBox("El numero del documento de identificacion está errado ", MsgBoxStyle.Critical)
            ruc.Focus()
            Return
        End If

        Dim sqlaux As String = "Select codigo from Identificacion where cedulaidentidadruc='" & ruc.Text & "' and codigo <> '" & codigo.Text & "' "
        Dim Conectar As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
        Dim dataAd As SqlDataReader
        Dim comm As New SqlClient.SqlCommand(sqlaux, Conectar)
        Conectar.Open()
        dataAd = comm.ExecuteReader
        If dataAd.Read Then
            ruc.Text = ""
            MsgBox("La cédula o ruc ya existe ", MsgBoxStyle.Critical)
            ruc.Focus()
            dataAd.Close()
            Conectar.Close()
            comm.Dispose()
            Conectar.Dispose()
            Exit Sub
        End If
        Dim rsalex = New Identificacion(datosEmpresa.strConxAdcom)
        Identificacion.CadenaSelect = "select * from identificacion where Codigo = '" & codigo.Text & "'  "
        rsalex = Identificacion.Buscar(" Codigo = '" & codigo.Text & "'  ")

        If IsNothing(rsalex) = False Then
            If rsalex.Codigo > "" Then
                MsgBox("El código ya existe , debe ingresar otro código ", MsgBoxStyle.Information)
                codigo.Focus()
                Exit Sub
            End If
        Else
            rsalex = New Identificacion(datosEmpresa.strConxAdcom)
        End If

        If OpP.Checked = True Then
            Tip = "N"
        Else
            Tip = "J"
        End If
        With rsalex
            .TipoPersona = Tip
            .Codigo = codigo.Text
            .CedulaIdentidadRuc = ruc.Text
            If Not IsDBNull(nombres.Text) Then .Nombres = nombres.Text
            If Not IsDBNull(apellidos.Text) Then .Apellidos = apellidos.Text
            .NombreImpresion = NombreImpresion.Text
            .EsBanco = False
            .EsEmpleado = False
            .EsVendedor = False
            .EsAsociado = False
            .EsCliente = False
            .EsProveedor = False
            Select Case UCase(ClienteProve)
                Case "P"
                    .EsProveedor = True
                Case "E"
                    .EsEmpleado = True
                Case "V"
                    .EsVendedor = True
                Case "F"
                    .EsBanco = True
                    .EsProveedor = True
                Case Else
                    .EsCliente = True
            End Select

            .Telefono1 = telefono1.Text
            .Telefono2 = telefono2.Text
            .Telefono3 = ""
            .CorreoElectrónico = email.Text

            If Not IsDBNull(direccion.Text) Then .Domicilio = direccion.Text
            If Not IsDBNull(TipCod) Then .Ciudad = TipCod

            .TipoIdentificacion = TipoIdGeneral(TipoIdent.SelectedIndex.ToString())
            rsalex.HistoriaClinica = ruc.Text
            rsalex.Actualizar()

            CodigoCli = codigo.Text
            If .EsCliente Then
                Dim datcli = New dbCliente(datosEmpresa.strConxAdcom)
                datcli.CodigoCli = CodigoCli
                datcli.LimiteCredito = 0
                datcli.Actualizar("select * from cliente where CodigoCli = '" & codigo.Text & "'  ")
            End If
        End With

        Me.Close()
        'Me.Dispose()
        Exit Sub
HayErrores:
        '  ControlaErrores
    End Sub

    Private Sub nombres_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nombres.TextChanged
        NombreImpresion.Text = nombres.Text & " " & apellidos.Text
    End Sub

    Private Sub OpE_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpE.CheckedChanged
        If OpE.Checked Then
            TipoIdent.SelectedIndex = 1
        End If
    End Sub

    Private Sub ruc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ruc.KeyDown
        Dim KeyCode As Short = CShort(e.KeyCode)
        If KeyCode = System.Windows.Forms.Keys.F2 Then ruc.Text = codigo.Text
    End Sub
    '''''''Private Sub ruc_KeyPress(KeyAscii As Integer)
    '''''''KeyAscii = SoloNumeros(KeyAscii)
    '''''''End Sub
    '''''''Private Sub telefono1_KeyPress(KeyAscii As Integer)
    '''''''KeyAscii = SoloNumeros(KeyAscii)
    '''''''End Sub
    '''''''Private Sub telefono2_KeyPress(KeyAscii As Integer)
    '''''''KeyAscii = SoloNumeros(KeyAscii)
    '''''''End Sub
    '''''''Private Sub telefono3_KeyPress(KeyAscii As Integer)
    '''''''KeyAscii = SoloNumeros(KeyAscii)
    '''''''End Sub
    Private Function ValidaNumeroId() As Boolean
        'Dim i As Integer
        Dim j As String = ""
        Dim Persona As String = "P"
        On Error Resume Next

        Select Case TipoIdent.SelectedIndex
            Case 0
                j = "O"
            Case 1
                j = "R"
            Case 2
                j = "C"
            Case 3
                j = "P"
            Case 4
                j = "F"
        End Select
        If OpE.Checked Then Persona = "E"
        If j = "O" Or j = "P" Then ValidaNumeroId = True : Exit Function
        Dim prog As New valIdcedru.valcedruc()
        ValidaNumeroId = prog.valCr(ruc.Text, j, Persona)  ' ValidaId((ruc.Text), j, Persona)
    End Function

    Private Function ArreglaId(ByRef Ident As String) As String
        ArreglaId = Ident
        Select Case Ident
            Case "O"
                ArreglaId = CStr(0)
            Case "R"
                ArreglaId = CStr(1)
            Case "C"
                ArreglaId = CStr(2)
            Case "P"
                ArreglaId = CStr(3)
            Case "F"
                ArreglaId = CStr(4)
        End Select
    End Function

    Private Sub email_KeyDown(sender As Object, e As KeyEventArgs) Handles email.KeyDown
        If e.KeyCode = Keys.F2 Then
            Dim ssql As String = "select CorreoDefecto from adcfelec"
            Using dr As SqlDataReader = SqlDatos.leerBaseAdcom(ssql)
                If (dr.Read) Then email.Text = dr(0).ToString() Else email.Text = ""
            End Using
        End If
    End Sub
    'Private Function BuscarEmailDefecto() As String


    'End Function

    Private Sub TipoIdent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TipoIdent.SelectedIndexChanged
        If TipoIdent.SelectedIndex = 0 Then TipoIdent.SelectedIndex = 1
    End Sub

    Private Sub codigo_TextChanged(sender As Object, e As EventArgs) Handles codigo.TextChanged

    End Sub

    Private Function TipoIdGeneral(ByRef Ident As String) As String
        TipoIdGeneral = "O"
        Select Case Ident
            Case "O", "0"
                TipoIdGeneral = "O"
            Case "R", "1"
                TipoIdGeneral = "R"
            Case "C", "2"
                TipoIdGeneral = "C"
            Case "P", "3"
                TipoIdGeneral = "P"
            Case "F", "4"
                TipoIdGeneral = "F"
        End Select
    End Function

End Class