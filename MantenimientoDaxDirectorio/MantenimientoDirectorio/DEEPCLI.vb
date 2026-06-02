Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports DattCom
Public Class DEEPCLI
    'Dim DaaxLibNom As New daaxLib.DaxLibNom
    Dim DaaxLibDat As New daaxLib.DaxLibDigDato
    Dim RetornaNombre As New EmpNomR.AdcNomb
    Friend CodSuc As String

    Dim codigoDirectorio(7) As String
    Dim Cambio As Boolean
    Dim resp As String
    Dim ii As Integer
    Dim CodigoStr As String
    Dim entrega As String
    Dim CodigoBusca As String
    Public tipoper As String
    Public cedulabusca As String
    Public Sexo As String
    Dim CambioAdicionales As Boolean
    Public CodigoFoto As String = ""
    Dim Indice As Integer
    Dim TipCodSyscod(50) As String
    Dim IniNvo As Boolean
    Public QUECODIGO As String
    Dim propio As Boolean

    Dim EsNuevo As Integer

    Dim Act1 As Boolean
    Dim Operacion(3) As String
    Dim saltar As Boolean = True
    Dim accion As String = ""
    Dim LosCambios As New ClassCambios

    Dim autorizaOpcion As New mntUsrs.autorizacion
    Dim claveOpcion As String = "mnuoDirectorioGeneral"
    Dim ImgDirectorio As String = "\Directorio"
    Public Sub IniciaNuevo()
        Try
            IniNvo = True
            Me.ShowDialog()
        Catch ee As Exception
            MsgBox("excepción iniNvo: " & ee.Message)
        End Try
    End Sub

    Private Sub Apellidos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Apellidos.TextChanged

        Dim dt As DataTable = DattCom.datosEmpresa.leeParametrosEmp("par_acumhis")
        Try
            If Convert.ToBoolean(dt.Rows(0).Item("par_AcumHis")) = False Then
                impresion.Text = Trim(Datox1.Text & " " & Apellidos.Text)
            Else
                impresion.Text = Trim(Apellidos.Text & " " & Datox1.Text)
            End If
        Catch
            impresion.Text = Trim(Apellidos.Text & " " & Datox1.Text)
        End Try
    End Sub

    Private Function leerIdentificacion() As Boolean
        Dim Buscod As New Syscod.ManSysnetClass
        On Error Resume Next
        Dim ConxAdcom As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
        Dim rs As SqlClient.SqlDataReader
        Dim Ssql As String = "Select * from Identificacion " & " where identificacion.codigo = '" & QUECODIGO & "' "
        Dim comm As New SqlClient.SqlCommand(Ssql, ConxAdcom)
        ConxAdcom.Open()
        rs = comm.ExecuteReader

        If rs.Read = False Then rs.Close() : Return False : Exit Function

        With rs
            Codigo.Text = .Item("codigo").ToString
            If Not IsDBNull(.Item("TipoPersona")) Then tipoper = .Item("TipoPersona").ToString

            If tipoper = "J" Then
                Juridica.Checked = True
            Else
                tipoper = "N"
                Natural.Checked = True
            End If

            If tipoper = "J" Then Juridica.Checked = True : Natural.Checked = False
            If tipoper = "N" Then Juridica.Checked = False : Natural.Checked = True

            TipoIdent.SelectedIndex = CInt(Val(ArreglaId(CStr(CorrijeNulo(.Item("TipoIdentificacion")))))) ': TIPID = CStr(TipoIdent.SelectedIndex)
            If Not IsDBNull(.Item("CedulaIdentidadRuc")) Then Datox0.Text = .Item("CedulaIdentidadRuc").ToString
            If Not IsDBNull(.Item("nombres")) Then Datox1.Text = .Item("nombres").ToString
            If Not IsDBNull(.Item("apellidos")) Then Apellidos.Text = .Item("apellidos").ToString
            If Not IsDBNull(.Item("NombreImpresion")) Then impresion.Text = .Item("NombreImpresion").ToString

            If Not IsDBNull(.Item("NumeroDomicilio")) Then TxtData2.Text = .Item("NumeroDomicilio").ToString
            If Not IsDBNull(.Item("País")) Then txtNomPais.Text = Buscod.QueNombre(.Item("País").ToString, TipCodSyscod(12))
            If Not IsDBNull(.Item("Provincia")) Then txtNomProvincia.Text = Buscod.QueNombre(.Item("Provincia").ToString, TipCodSyscod(13))
            If Not IsDBNull(.Item("Ciudad")) Then txtNomCiudad.Text = Buscod.QueNombre(.Item("Ciudad").ToString, TipCodSyscod(14))
            If Not IsDBNull(.Item("Domicilio")) Then txtnomDireccion.Text = .Item("Domicilio").ToString
            If Not IsDBNull(.Item("telefono1")) Then txtTelefono1.Text = .Item("telefono1").ToString
            If Not IsDBNull(.Item("telefono2")) Then txtTelefono2.Text = .Item("telefono2").ToString
            If Not IsDBNull(.Item("telefono3")) Then txtTelefono3.Text = .Item("telefono3").ToString
            If Not IsDBNull(.Item("NúmeroFax")) Then TxtData6.Text = .Item("NúmeroFax").ToString
            If Not IsDBNull(.Item("Casilla")) Then txtNomParroquia.Text = Buscod.QueNombre(.Item("Casilla").ToString, TipCodSyscod(24))
            '!correoelectrónico = TxtData8.Text
            If Not IsDBNull(.Item("CorreoElectrónico")) Then TxtData8.Text = .Item("CorreoElectrónico").ToString
            If Not IsDBNull(.Item("Paginaweb")) Then TxtData9.Text = .Item("Paginaweb").ToString
            If Not IsDBNull(.Item("Sector")) Then TxtNomCanton.Text = Buscod.QueNombre(.Item("Sector").ToString, TipCodSyscod(23))
            If Not IsDBNull(.Item("Grupo1")) Then txtGrupo1.Text = .Item("Grupo1").ToString
            If Not IsDBNull(.Item("Grupo2")) Then txtGrupo2.Text = .Item("Grupo2").ToString
            If Not IsDBNull(.Item("Grupo3")) Then txtGrupo3.Text = .Item("Grupo3").ToString
            If Not IsDBNull(.Item("HistoriaClinica")) Then txtHistoriaclinica.Text = .Item("HistoriaClinica").ToString
            If Not IsDBNull(.Item("Logotipo")) Then CodigoFoto = .Item("Logotipo").ToString
            '-----------------------------If Not IsDbNull(.ITEM("ComisionVenta")) Then PorComision.Text = .ITEM("ComisionVenta")
            '-----------------------------If Not IsDbNull(.ITEM("CtaCobrarComisiones")) Then Text1.Text = .ITEM("CtaCobrarComisiones")
            If Not IsDBNull(.Item("CodGrabo")) Then
                If datosEmpresa.usr <> .Item("CodGrabo").ToString And .Item("CodGrabo").ToString > "" Then propio = False
            End If
            If Not IsDBNull(.Item("ExoneradoIva")) Then ExoneradoIva.Checked = CBool(.Item("ExoneradoIva"))
            If Not IsDBNull(.Item("esRise")) Then chkRise.Checked = CBool(.Item("esRise"))
            If Not IsDBNull(.Item("NroCtrbuyteEspecial")) Then txtContribuyenteEspecial.Text = .Item("NroCtrbuyteEspecial").ToString()
            If Not IsDBNull(.Item("ObligLlevarConta")) Then chkObligaContabilidad.Checked = CBool(.Item("ObligLlevarConta"))
            If Not IsDBNull(.Item("regionDomicilio")) Then txtRegion.Text = .Item("regionDomicilio").ToString
            If Not IsDBNull(.Item("SectorDomicilio")) Then txtSector.Text = .Item("SectorDomicilio").ToString

        End With

        rs.Close()
        comm.Dispose()
        ConxAdcom.Close()
        ConxAdcom.Dispose()
        Return True
    End Function

    Private Function leerPersonal() As Boolean
        Dim Buscod As New Syscod.ManSysnetClass
        On Error Resume Next
        Dim ConxAdcom As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
        Dim rs As SqlClient.SqlDataReader
        Dim Ssql As String = "select * from Personal where codigoper = '" & QUECODIGO & "'"
        Dim comm As New SqlClient.SqlCommand(Ssql, ConxAdcom)
        ConxAdcom.Open()
        rs = comm.ExecuteReader

        If rs.Read = False Then rs.Close() : Return False : Exit Function

        'tabla personal
        With rs
            '            If .Read Then
            If Not IsDBNull(.Item("FechaNacimiento")) Then fechanaci.Text = "" + .Item("FechaNacimiento").ToString
            If Not IsDBNull(.Item("LugarNacimiento")) Then Lugarnaci.Text = "" + .Item("LugarNacimiento").ToString
            If Not IsDBNull(.Item("Sexo")) Then Sexo = "" + .Item("Sexo").ToString
            If Not IsDBNull(.Item("EstadoCivil")) Then CBOestadocivil.Text = "" + .Item("EstadoCivil").ToString
            If Not IsDBNull(.Item("Nacionalidad")) Then Lcod2.Text = Buscod.QueNombre(.Item("Nacionalidad").ToString, TipCodSyscod(2))
            If Not IsDBNull(.Item("hobbys")) Then hobbys.Text = "" + .Item("hobbys").ToString


            If Not IsDBNull(.Item("codigotarjrta")) Then txtCodTar.Text = "" + .Item("codigotarjrta").ToString
            If Not IsDBNull(.Item("numerotarjrta")) Then txtNumTar.Text = "" + .Item("numerotarjrta").ToString


            If Not IsDBNull(.Item("Profesión")) Then txtProfesion.Text = Buscod.QueNombre(.Item("Profesión").ToString, "Profesion")
            If Not IsDBNull(.Item("Especialidad")) Then txtEspecialidad.Text = Buscod.QueNombre(.Item("Especialidad").ToString, "Especialidad")
            If Not IsDBNull(.Item("Especialidad2")) Then txtEspecialidad2.Text = Buscod.QueNombre(.Item("Especialidad2").ToString, "Especialidad")
            If Not IsDBNull(.Item("Referirsecomo")) Then Combo1.Text = .Item("Referirsecomo").ToString
            If Not IsDBNull(.Item("TipoSangre")) Then txtTipoSangre.Text = .Item("TipoSangre").ToString
            If Not IsDBNull(.Item("DirecciónTrabajo")) Then txtLugTra.Text = .Item("DirecciónTrabajo").ToString
            If Not IsDBNull(.Item("ciudadNacimto")) Then txtCiudadNace.Text = .Item("ciudadNacimto").ToString
            If Not IsDBNull(.Item("paisNacimto")) Then txtPaisNace.Text = .Item("paisNacimto").ToString
            If Not IsDBNull(.Item("provNacimto")) Then txtProvNace.Text = .Item("provNacimto").ToString


            If Sexo = "M" Then
                mujer.Checked = True
            Else
                hombre.Checked = True
                Sexo = "H"
            End If

        End With
        rs.Close()
        comm.Dispose()
        ConxAdcom.Close()
        ConxAdcom.Dispose()
        Return True
    End Function

    Private Function leerCliente() As Boolean
        Dim Buscod As New Syscod.ManSysnetClass
        On Error Resume Next
        Dim ConxAdcom As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
        Dim rs As SqlClient.SqlDataReader
        Dim Ssql As String = "select * from cliente where codigocli = '" & QUECODIGO & "' "
        Dim comm As New SqlClient.SqlCommand(Ssql, ConxAdcom)
        ConxAdcom.Open()
        rs = comm.ExecuteReader
        If rs.Read = False Then rs.Close() : Return False : Exit Function
        'If rs.Read Then
        If Not IsDBNull(rs.Item("VendedorInterno")) Then
            If rs.Item("VendedorInterno").ToString <> datosEmpresa.usr And rs.Item("CobradorInterno").ToString <> datosEmpresa.usr Then propio = False
            'End If
        Else
        End If

        'tabla cliente
        With rs
            '   If .Read Then
            If Not IsDBNull(.Item("TipoCli")) Then txtTipoCliente.Text = Buscod.QueNombre(.Item("TipoCli").ToString, TipCodSyscod(3))
            If Not IsDBNull(.Item("ZonaVentas")) Then txtZonaVentas.Text = Buscod.QueNombre(.Item("ZonaVentas").ToString, TipCodSyscod(4))
            If Not IsDBNull(.Item("VendedorInterno")) Then txtVendedor.Text = QueNombre(.Item("VendedorInterno").ToString) : codigoDirectorio(0) = .Item("VendedorInterno").ToString
            If Not IsDBNull(.Item("Operador")) Then txtOperador.Text = QueNombre(.Item("Operador").ToString) : codigoDirectorio(5) = .Item("Operador").ToString
            If Not IsDBNull(.Item("Transportadora")) Then txtTransportadora.Text = QueNombre(.Item("Transportadora").ToString) : codigoDirectorio(6) = .Item("Transportadora").ToString
            If Not IsDBNull(.Item("ZonaCobranza")) Then txtZonaCobranzas.Text = Buscod.QueNombre(.Item("ZonaCobranza").ToString, TipCodSyscod(5))
            If Not IsDBNull(.Item("CobradorInterno")) Then txtCobrador.Text = QueNombre(.Item("CobradorInterno").ToString) : codigoDirectorio(1) = .Item("CobradorInterno").ToString
            If Not IsDBNull(.Item("PrecioVenta")) Then txtPrecioVenta.Text = Buscod.QueNombre(.Item("PrecioVenta").ToString, TipCodSyscod(6))
            If Not IsDBNull(.Item("FormaPago")) Then txtFormaPago.Text = RetornaNombre.RetornaNombrePago(.Item("FormaPago").ToString, DattCom.datosEmpresa.strConxAdcom)
            If Not IsDBNull(.Item("PorcDescuento")) Then txtPorcDescuento.Text = .Item("PorcDescuento").ToString
            If Not IsDBNull(.Item("limitecredito")) Then txtLimiteCredito.Text = .Item("limitecredito").ToString
            If Not IsDBNull(.Item("descuentoaso")) Then txtDescuentoAsociacion.Text = .Item("descuentoaso").ToString
            If Not IsDBNull(.Item("Observaciones")) Then observacli.Text = .Item("Observaciones").ToString
            If Not IsDBNull(.Item("contacto")) Then txtContacto.Text = .Item("contacto").ToString
            If Not IsDBNull(.Item("Entregarmercaderia").ToString) Then entregarmer.Text = .Item("Entregarmercaderia").ToString
            If Not IsDBNull(.Item("ctbcobrar")) Then Cuenta0.Text = .Item("ctbcobrar").ToString
            If Not IsDBNull(.Item("ctbcobrar2")) Then Cuenta4.Text = .Item("ctbcobrar2").ToString
            'End If
            If Not IsDBNull(.Item("PuertoEmbarque").ToString) Then entregarmer.Text = .Item("PuertoEmbarque").ToString
            If Not IsDBNull(.Item("PaisEmbarque").ToString) Then txtPaisEntrega.Text = .Item("PaisEmbarque").ToString

        End With
        rs.Close()
        comm.Dispose()
        ConxAdcom.Close()
        ConxAdcom.Dispose()
        Return True
    End Function
    Private Function QueNombre(ByVal COD As String) As String
        Dim ConxAdcomNet As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
        ConxAdcomNet.Open()
        Dim RS As SqlClient.SqlDataReader
        Dim Comm As New SqlClient.SqlCommand("select nombreimpresion from identificacion where Codigo = '" & COD & "'", ConxAdcomNet)
        Dim Nombre As String
        On Error Resume Next
        RS = Comm.ExecuteReader
        Nombre = ""
        If RS.Read Then Nombre = RS.Item("NOMBREIMPRESION").ToString
        RS.Close()
        RS = Nothing
        Comm.Dispose()
        QueNombre = Nombre
        ConxAdcomNet.Dispose()
    End Function

    Private Sub PonerDatosTipo()
        Static sum As Double
        sum += 1
        If Natural.Checked = False Then
            tabDatosPer.Parent = Nothing
        Else
            tabDatosPer.Parent = DatosDirectorio
        End If
        tabCliente.Parent = DatosDirectorio '.TabPages.Add(tabCliente)

        ControlarAutorizaciones()

    End Sub
    Private Sub MoverAArchivo()
        Cambio = False
        EsNuevo = 0
    End Sub

    Private Sub Asociacion_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        ' PonerDatosTipo()
    End Sub

    Private Sub centroCosto_KeyPress(ByRef KeyAscii As Integer)
        KeyAscii = DaaxLibDat.SoloNumeros(CShort(KeyAscii))
    End Sub

    Private Sub ciruc_KeyPress(ByRef KeyAscii As Integer)
        KeyAscii = DaaxLibDat.SoloNumeros(CShort(KeyAscii))
    End Sub

    Private Sub CBuscador7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFormaPago.Click
        Dim ElCodigo As String = ""
        Dim BusPAG As New Buscar.frmBuscar   'DaxPagos.BuscadorPagos
        Dim sSql As String = "select top 100 percent idFormasDePago,Descripcion as Descripción from formasdepago where tipoformapago <> 2 order by Descripcion"
        ElCodigo = BusPAG.Buscar(datosEmpresa.strConxAdcom, sSql, "idFormasDePago", "Descripción", "", "Formas de pago clientes")
        BusPAG = Nothing
        txtFormaPago.Text = RetornaNombre.RetornaNombrePago(ElCodigo, datosEmpresa.strConxAdcom)
    End Sub

    Private Sub CBuscador12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBuscador12.Click
        CBuscador(txtNomPais, 12)
    End Sub

    Private Sub CBuscador13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBuscador13.Click
        CBuscador(txtNomProvincia, 13)
    End Sub

    Private Sub CBuscador14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBuscador14.Click
        Me.UseWaitCursor = True
        Me.Cursor = Cursors.WaitCursor
        CBuscador(txtNomCiudad, 14)
        Me.UseWaitCursor = False
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CBuscador2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBuscador2.Click
        CBuscador(Lcod2, 2)
    End Sub

    Private Sub CBuscador3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscaTipoCliente.Click
        CBuscador(txtTipoCliente, 3)
    End Sub

    Private Sub CBuscador4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscaZonaVentas.Click
        CBuscador(txtZonaVentas, 4)
    End Sub

    Private Sub CBuscador5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscaZonaCobro.Click
        CBuscador(txtZonaCobranzas, 5)
    End Sub

    Private Sub CBuscador6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrecioVenta.Click
        CBuscador(txtPrecioVenta, 6)
    End Sub

    Private Sub CBuscador(ByRef lcod As TextBox, ByVal indice As Integer)
        Dim ElNombre As String = ""
        Dim ElCodigo As String = ""
        Dim Buscod As New Syscod.ManSysnetClass
        ElCodigo = Buscod.BuscarReferencia(TipCodSyscod(indice), ElCodigo, ElNombre)
        lcod.Text = ElNombre
        Buscod = Nothing
    End Sub

    Private Sub CBuscador(ByRef lcod As Label, ByVal indice As Integer)
        Dim ElNombre As String = ""
        Dim ElCodigo As String = ""
        Dim Buscod As New Syscod.ManSysnetClass
        ElCodigo = Buscod.BuscarReferencia(TipCodSyscod(indice), ElCodigo, ElNombre)
        lcod.Text = ElNombre
        Buscod = Nothing
    End Sub

    Private Sub Codigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Codigo.KeyDown
        Dim KeyCode As Integer = e.KeyCode
        Dim Shift As Integer = e.KeyData \ &H10000
        If KeyCode = System.Windows.Forms.Keys.F2 Then
            BuscarProximoCodigo()
        ElseIf KeyCode = System.Windows.Forms.Keys.Return And Codigo.Text > "" Then
            SaliendoCodigo()
        End If
    End Sub
    Private Sub BuscarPorHistoriaClinica(historia As String)

        Dim prog As New Buscar.frmBuscar()
        Dim ingCodigo As String = prog.Buscar(datosEmpresa.strConxAdcom, "select codigo, nombreimpresion,HistoriaClinica from identificacion where ltrim(rtrim(historiaclinica)) = '" & Trim(historia) & "' ", "Codigo", "nombreImpresion", "", "Busqueda por Historia Clínica")
        If ingCodigo > "" Then Codigo.Text = ingCodigo : SaliendoCodigo()
    End Sub

    Private Sub SaliendoCodigo()
        If Codigo.Text > "" And Codigo.ReadOnly = False Then CargarRegistros()
    End Sub

    Private Sub Command1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Command1.Click
        cuenta(Cuenta0, Keys.F2, 0 \ &H10000)
    End Sub

    Private Sub Command5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Command5.Click
        cuenta(Cuenta4, Keys.F2, 0 \ &H10000)
    End Sub

    Private Sub BuscarRegistro()
        Dim prog As New BuscaClien
        Codigo.Text = prog.IniBuscaCliOPro("T", "", "", "N")
        prog.Close()
        prog.Dispose()
        If Codigo.Text > "" Then SaliendoCodigo()
    End Sub

    Private Sub Cuenta0_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        cuenta(Cuenta0, e.KeyCode, e.KeyData \ &H10000)
    End Sub

    Private Sub cuenta(ByRef cuenta As Label, ByVal KeyCode As Integer, ByVal Shift As Integer)
        Dim prog As New CtaMtn.BuscaCta
        Dim Nombre As String = ""
        If KeyCode = System.Windows.Forms.Keys.F2 Then
            cuenta.Text = prog.BuscaCtaCtb(Nombre, "I")
            prog = Nothing
        End If
    End Sub

    Private Sub Datox0_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Datox0.KeyDown
        Dim KeyCode As Integer = e.KeyCode
        Dim Shift As Integer = e.KeyData \ &H10000
        If KeyCode = System.Windows.Forms.Keys.F2 Then Datox0.Text = Codigo.Text
    End Sub

    Private Sub Datox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Datox1.TextChanged
        If Emp.OrdenaPorApellidos = False Then
            impresion.Text = Trim(Datox1.Text & " " & Apellidos.Text)
        Else
            impresion.Text = Trim(Apellidos.Text & " " & Datox1.Text)
        End If
    End Sub

    Private Sub descuentoaso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescuentoAsociacion.KeyPress
        Dim KeyAscii As Integer = Asc(e.KeyChar)
        KeyAscii = DaaxLibDat.SoloNumeros(CShort(KeyAscii))
        e.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Try
            Dim ConxAdcom As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
            ConxAdcom.Open()
            Dim Ssql As String = ""

            CodigoBusca = Codigo.Text
            If ClienteMovimiento(CodigoBusca) = True Then MsgBox("No puede eliminar este Codigo, existen movimientos registrados con este código", MsgBoxStyle.Critical) : Exit Sub
            If MsgBox("Esta seguro que desea eliminar el registro activo", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Ssql = ("delete from identificacion  where codigo='" & CodigoBusca & "' ")
                Ssql &= ("delete from personal  where codigoper='" & CodigoBusca & "' ")
                Ssql &= ("delete from contactos where codcontacto='" & CodigoBusca & "' ")
                Ssql &= ("delete from proveedor  where codigoproveedor='" & CodigoBusca & "' ")
                Ssql &= ("delete from cliente  where codigocli='" & CodigoBusca & "' ")
                Ssql &= ("delete from empleado  where codigoEmpleado='" & CodigoBusca & "' ")
                Ssql &= ("delete from rolfam  where codEmpleado='" & CodigoBusca & "' ")
                Ssql &= ("delete from adccapper  where codEmpleado='" & CodigoBusca & "' ")
                Dim comm = New SqlClient.SqlCommand(Ssql, ConxAdcom)
                comm.ExecuteNonQuery()

                '            EliminarEmbarque()
                comm.Dispose()
            End If
            ConxAdcom.Close()
            ConxAdcom.Dispose()
        Catch ee As Exception
            MsgBox("excepción eliminaDir: " & ee.Message)
        End Try
        CodigoBusca = ""
        QUECODIGO = ""
        LimpiezaFormulario()
        DatosDirectorio.SelectedIndex = 0
        EsNuevo = 0
        PonerBotonesFormulario()
    End Sub

    Public Sub Directorio(ByVal cod As String)
        Try
            If cod = "" Then
                LimpiezaFormulario()
                QUECODIGO = ""
                Juridica.Checked = True
                EsNuevo = 1
                PonerBotonesFormulario()
                Codigo.Focus()
            Else
                QUECODIGO = cod
                Codigo.Text = cod
                CargarRegistros()
            End If
            Me.ShowDialog()
        Catch ee As Exception
            MsgBox("excepción Directorio: " & ee.Message)
        End Try
    End Sub

    Private Sub DEEP01_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = e.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = e.CloseReason
        QUECODIGO = CStr(0)
        RetornaNombre = Nothing
        DaaxLibDat = Nothing
        If Emp.rol Then generarTablaAdicionales()
        Me.Dispose()
    End Sub

    Private Sub foto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles foto.Click

        Try
            If (ImgDirectorio) = "" Then MsgBox("No se ha definido un directorio para registrar las imágenes" & vbCr & "Definalo en parametros del sistema", vbCritical) : Exit Sub
            dialogoOpen.Title = "Escojer fotografía para directorio"
            dialogoOpen.Filter = "Imágenes (*.bmp;*.ico;*.jpg)|*.bmp;*.ico;*.jpg"
            dialogoOpen.InitialDirectory = ImgDirectorio
            dialogoOpen.ShowDialog()
            CodigoFoto = dialogoOpen.SafeFileName
            FileIO.FileSystem.CopyFile(dialogoOpen.FileName, ImgDirectorio + CodigoFoto, True)
            CargaFoto()
            Cambio = True
        Catch ee As Exception

        End Try
    End Sub


    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim Buscod As New Syscod.ManSysnetClass
        Try
            If Codigo.Text = "" Then MsgBox("Digite un Código Válido", MsgBoxStyle.Critical) : Exit Sub
            If DattCom.datosEmpresa.LongCodDirectorio > 0 And Codigo.Text.Length <> DattCom.datosEmpresa.LongCodDirectorio Then MsgBox("El código debe tener la longitud correcta (" + DattCom.datosEmpresa.LongCodDirectorio.ToString() + ")", MsgBoxStyle.Critical) : Exit Sub

            If TipoIdent.Text = "" Then MsgBox("Falta el tipo de identificación", MsgBoxStyle.Critical) : Exit Sub
            If Datox0.Text = "" Then MsgBox("Debe ingresar el RUC o CI", MsgBoxStyle.Information) : Datox0.Focus() : Exit Sub

            If ValidaNumeroId() = False Then
                MsgBox("El numero del documento de identificacion está errado ", MsgBoxStyle.Critical)
                Datox0.Focus()
                Exit Sub
            End If

            If Datox1.Text = "" Then MsgBox("Debe ingresar el nombre", MsgBoxStyle.Information) : Datox1.Focus() : Exit Sub
            If Natural.Checked = True Then
                If Apellidos.Text = "" Then Apellidos.Focus() : MsgBox("Debe ingresar el apellido", MsgBoxStyle.Information) : Exit Sub
            End If
            If impresion.Text = "" Then impresion.Focus() : MsgBox("Debe ingresar el nombre de impresión", MsgBoxStyle.Information) : Exit Sub

            CodigoBusca = Codigo.Text
            cedulabusca = Datox0.Text

            Dim recide As New Identificacion(datosEmpresa.strConxAdcom)

            'If IsDBNull(CodigoBusca) Then CodigoBusca = ""
            'recide = Identificacion.Buscar("cedulaidentidadruc='" & cedulabusca & "' and codigo <> '" & CodigoBusca & "' ")
            'If Not recide Is Nothing Then
            If LeerEmpleado.ExisteCedula(CodigoBusca, cedulabusca) Then
                Datox0.Text = ""
                MsgBox("El Nro. ID (cédula o ruc) ya existe ", MsgBoxStyle.Critical)
                Datox0.Focus()
                Exit Sub
            End If
            recide = Identificacion.Buscar(" codigo = '" + CodigoBusca + "'")
            If recide Is Nothing Then recide = New Identificacion(datosEmpresa.strConxAdcom)
            Dim movdatId As New moverDatosIdentificacion()
            movdatId.movDatIdentificacionCli(Me, recide, codigoDirectorio)
            movdatId = Nothing

            With recide
                If .Actualizar("Select * from Identificacion " & " where identificacion.codigo = '" & QUECODIGO & "' ").Substring(0, 5) = "ERROR" Then
                    MsgBox("El registro de identificacion no puede grabarse ", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            End With
            recide = Nothing

            SaveSetting("Alex", "Codigos", "Ultimo", Codigo.Text)

            'tabla personal
            If Natural.Checked = True Then
                Dim tablaper = New dbPersonal(datosEmpresa.strConxAdcom)
                With tablaper
                    .CodigoPer = Codigo.Text
                    If IsDate(fechanaci.Text) Then .FechaNacimiento = CDate(fechanaci.Text) Else .FechaNacimiento = CDate("01/01/1900")
                    .LugarNacimiento = Lugarnaci.Text
                    If (hombre.Checked = True) Then .Sexo = "H" Else .Sexo = "M"
                    .EstadoCivil = CBOestadocivil.Text
                    .Nacionalidad = Buscod.QueCodigo(Lcod2.Text, TipCodSyscod(2))
                    .Hobbys = hobbys.Text

                    .codigotarjrta = txtCodTar.Text
                    .numerotarjrta = txtNumTar.Text

                    .Profesión = Buscod.QueCodigo(txtProfesion.Text, "Profesion")
                    .Especialidad = Buscod.QueCodigo(txtEspecialidad.Text, "Especialidad")
                    .Especialidad2 = Buscod.QueCodigo(txtEspecialidad2.Text, "Especialidad")
                    .Referirsecomo = Combo1.Text
                    .AsociadoAEmpresa = CInt("0" & codigoDirectorio(3))
                    .TipoSangre = txtTipoSangre.Text
                    .DirecciónTrabajo = txtLugTra.Text

                    .ciudadNacimto = txtCiudadNace.Text
                    .paisNacimto = txtPaisNace.Text
                    .provNacimto = txtProvNace.Text
                    .Discapacidad = txtDiscapacidad.Text
                    .PorcentajeDiscapacidad = Convert.ToDecimal("0" + txtPorcDiscapacidad.Text)


                    If .Actualizar("select * from Personal where codigoper = '" & Codigo.Text & "'").Substring(0, 5) = "ERROR" Then
                        MsgBox("El registro personal no puede grabarse", MsgBoxStyle.Exclamation)
                    End If
                End With
                tablaper = Nothing
            End If

            ''tabla cliente
            Dim tablacli = New dbCliente(datosEmpresa.strConxAdcom)
            With tablacli
                .CodigoCli = Codigo.Text
                .TipoCli = Buscod.QueCodigo(txtTipoCliente.Text, TipCodSyscod(3))
                .ZonaVentas = Buscod.QueCodigo(txtZonaVentas.Text, TipCodSyscod(4))
                .VendedorInterno = codigoDirectorio(0)
                .Operador = codigoDirectorio(5)
                .Transportadora = codigoDirectorio(6)
                .ZonaCobranza = Buscod.QueCodigo(txtZonaCobranzas.Text, TipCodSyscod(5))
                .CobradorInterno = codigoDirectorio(1)
                .PrecioVenta = Buscod.QueCodigo(txtPrecioVenta.Text, TipCodSyscod(6))
                .FormaPago = RetornaNombre.RetornaCodigoPago(txtFormaPago.Text, DattCom.datosEmpresa.strConxAdcom)
                .PorcDescuento = CDec(Val(txtPorcDescuento.Text))
                .LimiteCredito = CDec(Val(txtLimiteCredito.Text))
                .DescuentoAso = CDec(Val(txtDescuentoAsociacion.Text))
                .Observaciones = observacli.Text
                .Contacto = txtContacto.Text
                .Entregarmercaderia = entregarmer.Text
                .CtbCobrar = Cuenta0.Text
                .CtbCobrar2 = Cuenta4.Text
                .PaisEmbarque = txtPaisEntrega.Text
                .PuertoEmbarque = entregarmer.Text

                If .Actualizar("select * from cliente where codigocli = '" & Codigo.Text & "' ").Substring(0, 5) = "ERROR" Then
                    MsgBox("El registro cliente no puede grabarse", MsgBoxStyle.Exclamation)
                End If
            End With
            tablacli = Nothing
            'tabla empleado

            Dim tablacon As New dbContactos(datosEmpresa.strConxAdcom)

            Dim ConxAdcom As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
            ConxAdcom.Open()
            Dim Ssql As String = "delete from contactos where codcontacto='" & QUECODIGO & "' "
            Dim comm As New SqlClient.SqlCommand(Ssql, ConxAdcom)
            comm.ExecuteNonQuery()


            tablacon = Nothing

            accion = ""
            LimpiezaFormulario()

            PonerBotonesFormulario()
            If IniNvo = True Then Me.Close()
            Buscod = Nothing
            CerrarRegistro()
            accion = ""
        Catch exx As Exception
            MessageBox.Show("Se produjo una excepción al grabar " + exx.Message)
        End Try

    End Sub

    Private Sub libretamilitar_KeyPress(ByRef KeyAscii As Int32)
        KeyAscii = DaaxLibDat.SoloNumeros(KeyAscii)
    End Sub

    Private Sub limitecredito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLimiteCredito.KeyPress
        Dim KeyAscii As Int32 = Asc(e.KeyChar)
        KeyAscii = DaaxLibDat.SoloNumeros(KeyAscii)
        e.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub


    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        CrearNuevo()
    End Sub
    Private Sub CrearNuevo()
        LimpiezaFormulario()
        QUECODIGO = ""
        Juridica.Checked = True
        'PonerDatosTipo()
        EsNuevo = 1
        PonerBotonesFormulario()
        accion = "guardar"
        ChequearAutorizacion("T")
        Codigo.Focus()
        CambioAdicionales = False
    End Sub

    Private Sub Nroctabancorol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Int32 = Asc(e.KeyChar)
        KeyAscii = DaaxLibDat.SoloNumeros(KeyAscii)
        e.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub Porcdescuentocli_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPorcDescuento.KeyPress
        Dim KeyAscii As Int32 = Asc(e.KeyChar)
        KeyAscii = DaaxLibDat.SoloNumeros(KeyAscii)
        e.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub porcedescuentoprv_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Int32 = Asc(e.KeyChar)
        KeyAscii = DaaxLibDat.SoloNumeros(KeyAscii)
        e.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub DEEP01_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Codigo.Text = "" Then EsNuevo = 0 : PonerBotonesFormulario()
        Mainn()
        Valores.iniciaValores(TipCodSyscod)
        Operacion(0) = ""
        Operacion(1) = " CREANDO NUEVO REGISTRO "
        Operacion(2) = " MODIFICANDO REGISTRO EXISTENTE "

        Juridica.Checked = True
        DatosDirectorio.SelectedIndex = 0
        saltar = False
        PonerDatosTipo()
        ControlarAutorizaciones()
        cargarAutorizacionOpcion()
        If IniNvo Then CrearNuevo()
        If (Emp.PathImagenes.Length > 0) Then ImgDirectorio = Emp.PathImagenes + ImgDirectorio Else ImgDirectorio = ""

    End Sub

    Private Sub ControlarAutorizaciones()
        If (datosEmpresa.usr.ToUpper = " ADMINISTRADOR") Then Return
        Dim autorizaciones As New mntUsrs.autorizaUserDirectorio(datosEmpresa.usr, datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString())
        If (autorizaciones.autUsrIdentificacion.existe = False) Then Return
        If (autorizaciones.autUsrCliente.visible = False) Then tabCliente.Parent = Nothing
        If (autorizaciones.autUsrDatoPersonal.visible = False) Then tabDatosPer.Parent = Nothing

        If (autorizaciones.autUsrCliente.visible = False) Then tabCliente.Parent = Nothing




    End Sub
    Private Sub cargarAutorizacionOpcion()
        Dim opcUser As New mntUsrs.autorizaUserMenu(claveOpcion, datosEmpresa.usr, datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.sistema)
        autorizaOpcion = opcUser.autUsrMenuPrincipal
        opcUser = Nothing
        If autorizaOpcion.crearAbierto Or autorizaOpcion.existe = False Then Return
        btnNuevo.Enabled = autorizaOpcion.crearAbierto
        btnAbrir.Enabled = (autorizaOpcion.visible)
        btnGuardar.Visible = (autorizaOpcion.crearAbierto Or autorizaOpcion.modificar)
        btnEliminar.Visible = (autorizaOpcion.eliminar Or autorizaOpcion.crearAbierto)

    End Sub
    Private Sub CargarRegistros()
        Try

            propio = True
            QUECODIGO = Codigo.Text
            If leerIdentificacion() = False Then
                EsNuevo = 1
            Else
                Codigo.ReadOnly = True
                If tipoper = "N" Then leerPersonal()
                leerCliente()
                EsNuevo = 2
            End If
            PonerDatosTipo()
            CargaFoto()
            Cambio = False
            ''''''''''''''''''''''''''''''''''ChequearAutorizacion(Emp.)
            PonerBotonesFormulario()
        Catch ee As Exception
            MsgBox("excepción cargaDir: " & ee.Message)
        End Try
        CambioAdicionales = False
    End Sub

    Private Sub Juridica_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Juridica.CheckedChanged
        If Juridica.Checked Then
            Natural_CheckedChanged(Natural, New System.EventArgs())
        End If
    End Sub

    Private Sub Natural_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Natural.CheckedChanged
        If saltar Then Exit Sub
        On Error Resume Next
        If Juridica.Checked = True Then
            tipoper = "J"
            asociadoa.Visible = False
            Label34.Visible = False
            Apellidos.Visible = False
            Apellidos.Enabled = False
            Apellidos.Text = ""
        Else
            Label34.Visible = True
            Apellidos.Visible = True
            Apellidos.Enabled = True
            tipoper = "N"
            Natural.Checked = True
        End If
        PonerDatosTipo()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        If MsgBox("Esta seguro que desea salir ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub generarTablaAdicionales()
        Dim conn As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
        Dim noExiste As Boolean = False
        conn.Open()
        Dim ssql As String = "set dateformat dmy; exec daxAdicEmp "
        Dim rr As New SqlCommand(ssql, conn)
        Try
            rr.ExecuteNonQuery()
        Catch ee As Exception
            MsgBox("excepción AdicEmp : " & ee.Message)
        End Try
        Try
            Dim rs As SqlClient.SqlDataReader
            ssql = "Select top 1 * from DaxAdiTrabj "
            Dim comm As New SqlClient.SqlCommand(ssql, conn)
            rs = comm.ExecuteReader

            If rs.Read = False Then noExiste = False
        Catch
            noExiste = True
        End Try
        If noExiste Then
            ssql = "CREATE TABLE [dbo].[DaxAdiTrabj]([codEmpleado] [varchar](20) NOT NULL ) ON [PRIMARY]"
            rr = New SqlCommand(ssql, conn)
            rr.ExecuteNonQuery()
        End If
        conn.Close()
        conn.Dispose()
        rr.Dispose()
    End Sub

    Private Sub CargaFoto()
        If CodigoFoto > "" Then
            Dim resp As String = Dir(ImgDirectorio + CodigoFoto)
            If Len(resp) > 0 Then
                foto.Image = System.Drawing.Image.FromFile(ImgDirectorio + CodigoFoto)
            Else
                MsgBox("La Fotografía asignada a este contacto no existe " & vbCr & vbCr + ImgDirectorio + CodigoFoto, MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub PonerBotonesFormulario()
        btnNuevo.Visible = (EsNuevo = 0)
        btnAbrir.Visible = (EsNuevo = 0)
        btnCerrar.Visible = (EsNuevo > 0)
        btnGuardar.Visible = ((EsNuevo = 2) Or (EsNuevo = 1))
        btnEliminar.Visible = ((EsNuevo = 2 Or EsNuevo = 1))
        Me.Text = "ADCOM - Mantenimiento DIRECTORIO CLIENTES -  " & Operacion(EsNuevo)
    End Sub

    Private Sub CerrarRegistro()
        LimpiezaFormulario()
        EsNuevo = 0
        PonerBotonesFormulario()
    End Sub

    'Private Sub TxtData0_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNomCanton.KeyPress
    '    Dim KeyAscii As int32 = Asc(e.KeyChar)
    '    e.KeyChar = Chr(KeyAscii)
    '    If KeyAscii = 0 Then
    '        e.Handled = True
    '    End If
    'End Sub

    Private Sub TxtData1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnomDireccion.KeyPress
        Dim KeyAscii As Int32 = Asc(e.KeyChar)
        e.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtData2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtData2.KeyPress
        Dim KeyAscii As Int32 = Asc(e.KeyChar)
        e.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    'Private Sub TxtData7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNomParroquia.KeyPress
    '    Dim KeyAscii As int32 = Asc(e.KeyChar)
    '    e.KeyChar = Chr(KeyAscii)
    '    If KeyAscii = 0 Then
    '        e.Handled = True
    '    End If
    'End Sub

    Private Sub TxtData8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtData8.KeyPress
        Dim KeyAscii As Int32 = Asc(e.KeyChar)
        e.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtData9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtData9.KeyPress
        Dim KeyAscii As Int32 = Asc(e.KeyChar)
        e.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtData31_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Int32 = Asc(e.KeyChar)
        e.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtData32_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Int32 = Asc(e.KeyChar)
        e.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtData3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelefono1.KeyPress
        Dim KeyAscii As Int32 = Asc(e.KeyChar)
        KeyAscii = DaaxLibDat.SoloNumeros(KeyAscii)
    End Sub

    Private Sub TxtData4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelefono2.KeyPress
        Dim KeyAscii As Int32 = Asc(e.KeyChar)
        KeyAscii = DaaxLibDat.SoloNumeros(KeyAscii)
    End Sub

    Private Sub TxtData5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelefono3.KeyPress
        Dim KeyAscii As Int32 = Asc(e.KeyChar)
        KeyAscii = DaaxLibDat.SoloNumeros(KeyAscii)
    End Sub

    Private Sub TxtData6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtData6.KeyPress
        Dim KeyAscii As Int32 = Asc(e.KeyChar)
        KeyAscii = DaaxLibDat.SoloNumeros(KeyAscii)
    End Sub

    Private Sub valorsueldo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Int32 = Asc(e.KeyChar)
        KeyAscii = DaaxLibDat.SoloNumeros(KeyAscii)
        e.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub BuscarProximoCodigo()
        Dim ConxAdcom As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
        Dim rs As SqlClient.SqlDataReader
        Dim cod As Double
        Dim C, a, b As String
        Dim i As Int32
        a = ""
        C = ""
        b = ""
        Dim Ssql As String = "select top 1 codigo from identificacion order by substring ('0000000000000000000000000' + codigo,len(Codigo)+1 ,25) desc"
        Dim comm As New SqlClient.SqlCommand(Ssql, ConxAdcom)
        ConxAdcom.Open()
        rs = comm.ExecuteReader
        If rs.Read = False Then
            Codigo.Text = "1"
        Else
            a = CStr(rs.Item("codigo"))
            If IsNumeric(a) Then
                cod = CDbl(a)
            Else
                For i = 1 To CShort(Len(a))
                    b = Mid(a, i, 1)
                    If b < "0" Or b > "9" Then C = C & b Else cod = CSng(Val(Mid(a, i))) : i = 9999
                Next i
            End If
        End If
        Codigo.Text = C & Trim(Str(cod + 1))
        ConxAdcom.Close()
        ConxAdcom = Nothing
    End Sub

    Private Function ProximoNumeroHistoriaClinica() As String
        Dim ConxAdcomNet As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
        Dim CodigoNvo As String = ""
        ConxAdcomNet.Open()
        Dim RS As SqlClient.SqlDataReader
        Dim Comm As New SqlClient.SqlCommand("select max(HistoriaClinica) as HistClinica from identificacion", ConxAdcomNet)
        RS = Comm.ExecuteReader
        If RS.Read Then CodigoNvo = RS.Item("HistClinica").ToString
        RS.Close()
        RS = Nothing
        Comm.Dispose()
        ConxAdcomNet.Dispose()
        If CodigoNvo = "" Then CodigoNvo = "1" : Return CodigoNvo : Exit Function
        If IsNumeric(CodigoNvo) Then CodigoNvo = CStr(Val(CodigoNvo) + 1) : Return CodigoNvo : Exit Function

        Dim cod As Single
        Dim C As String = ""
        Dim b As String
        Dim i As Short
        For i = CShort(Len(CodigoNvo)) To 0 Step -1
            b = CodigoNvo(i)
            If IsNumeric(b) Then C = b & C Else cod = CSng(Mid(CodigoNvo, 1, i)) : Exit For
        Next i
        CodigoNvo = CStr(cod)
        If C > "" Then CodigoNvo = CodigoNvo & Val(C) + 1
        Return CodigoNvo
    End Function


    Private Sub LimpiezaFormulario()
        Codigo.ReadOnly = False
        Limpiar(Me)
        'limpiarGrid(Grid)
        CambioAdicionales = False
    End Sub

    Private Sub Limpiar(ByVal oBJ As Form)
        Dim Control1 As System.Windows.Forms.Control
        Dim a As String
        For Each Control1 In oBJ.Controls
            If Control1.Controls.Count > 0 Then Limpiar(Control1)
            a = TypeName(Control1)
            If a = "TextBox" Then Control1.Text = ""
            'If a = "ComboBox" Then Control1.SelectedIndex = 0)
            If a = "MaskedTextBox" Then Control1.Text = "  /  /"
            chkObligaContabilidad.Checked = False
            chkRise.Checked = False
            ExoneradoIva.Checked = False
            txtContribuyenteEspecial.Text = ""

        Next
    End Sub

    Private Sub Limpiar(ByVal oBJ As Control)
        Dim Control1 As System.Windows.Forms.Control
        Dim a As String
        For Each Control1 In oBJ.Controls
            If Control1.Controls.Count > 0 Then Limpiar(Control1)
            a = TypeName(Control1)
            If a = "TextBox" Then Control1.Text = ""
            'If a = "ComboBox" Then Control1.SelectedIndex = 0)
            If a = "MaskedTextBox" Then Control1.Text = "  /  /"
        Next
    End Sub

    Private Sub limpiarGrid(ByVal grid As DataGridView)
        With grid
            For i = .RowCount - 2 To 0 Step -1
                If i <= .Rows.Count Then .Rows.RemoveAt(i)
            Next
        End With
    End Sub

    Private Function ValidaNumeroId() As Boolean
        Dim j As String = ""
        Dim Persona As String = "P"
        ValidaNumeroId = False
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
        If j = "O" Then ValidaNumeroId = True : Exit Function
        If Juridica.Checked Then Persona = "E"
        If j = "P" Then
            ValidaNumeroId = True
        ElseIf j = "F" And Datox0.Text = "9999999999999" Then
            ValidaNumeroId = True
        Else
            Dim prog As New valIdcedru.valcedruc()
            ValidaNumeroId = prog.valCr(Datox0.Text, j, Persona)
        End If
    End Function

    Private Function ArreglaId(ByRef Ident As String) As String
        If IsDBNull(Ident) Then Return "1" : Exit Function
        ArreglaId = Ident
        Select Case Ident
            Case "O"
                ArreglaId = "0"
            Case "R"
                ArreglaId = "1"
            Case "C"
                ArreglaId = "2"
            Case "P"
                ArreglaId = "3"
            Case "F"
                ArreglaId = "4"
        End Select
    End Function
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

    Private Sub btnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrir.Click
        BuscarRegistro()
        accion = "actualizar"
        '        CargarEmbarque()
    End Sub
    Private Function CbuscaDir(ByVal tipo As String, ByVal index As Integer) As String()
        Dim prog As New BuscaClien
        Dim cod As String = ""
        Dim nom As String = ""
        Dim datos(2) As String
        cod = prog.IniBuscaCliOPro(tipo, nom, "", "")
        prog.Close()
        prog.Dispose()
        datos(0) = cod : datos(1) = nom
        Return datos
    End Function
    Private Sub buscaVendedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscaVendedor.Click
        Dim dat(2) As String
        dat = CbuscaDir("V", 0)
        txtVendedor.Text = dat(1)
        codigoDirectorio(0) = dat(0)
    End Sub

    Private Sub CbuscaDir1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscaCobrador.Click
        Dim dat(2) As String
        dat = CbuscaDir("T", 0)
        txtCobrador.Text = dat(1)
        codigoDirectorio(1) = dat(0)
    End Sub

    Private Sub CbuscaDir2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim dat(2) As String
        dat = CbuscaDir("F", 0)
        codigoDirectorio(2) = dat(0)
    End Sub

    Private Sub CbuscaDir3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbuscaDir3.Click
        Dim dat(2) As String
        dat = CbuscaDir("F", 0)
        LDir3.Text = dat(1)
        codigoDirectorio(3) = dat(0)
    End Sub

    Private Sub Cliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PonerDatosTipo()
    End Sub

    Private Sub Proveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PonerDatosTipo()
    End Sub

    Private Sub Banco_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PonerDatosTipo()
    End Sub

    Private Sub Empleado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PonerDatosTipo()
    End Sub

    Private Sub EsVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PonerDatosTipo()
    End Sub

    Private Sub Directa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PonerDatosTipo()
    End Sub

    Private Sub Asociacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PonerDatosTipo()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        CerrarRegistro()
        accion = ""
    End Sub

#Region "Embarque"


#End Region
    Private Sub Codigo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Codigo.Leave
        SaliendoCodigo()
    End Sub

    Private Sub CbBuscador12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbBuscador12.Click
        CBuscador(txtProfesion, 15)
    End Sub

    Private Sub CbBuscador13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbBuscador13.Click
        CBuscador(txtEspecialidad, 16)
    End Sub
    Private Sub CbBuscador132_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbBuscador132.Click
        CBuscador(txtEspecialidad2, 16)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CBuscador(txtGrupo1, 17)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        CBuscador(txtGrupo2, 18)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        CBuscador(txtGrupo3, 19)
    End Sub

    Private Sub txtHistoriaclinica_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHistoriaclinica.KeyDown
        If e.KeyCode = Keys.F2 Then
            txtHistoriaclinica.Text = ProximoNumeroHistoriaClinica()
        ElseIf e.KeyCode = Keys.F3 And txtHistoriaclinica.Text > "" Then
            BuscarPorHistoriaClinica(txtHistoriaclinica.Text)
        End If
    End Sub
    Private Sub ChequearAutorizacion(ByVal Autorizacion As String)
        Dim Autorizado As Boolean = (Autorizacion = "T")
        btnEliminar.Checked = Autorizado
        txtLimiteCredito.Enabled = Autorizado
        tabCliente.Enabled = Autorizado
        txtFormaPago.Enabled = Autorizado
        txtPorcDescuento.Enabled = Autorizado
        txtLimiteCredito.Enabled = Autorizado
        ExoneradoIva.Enabled = Autorizado
    End Sub

    Private Sub ComCargarCapacitacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim prog As New frmCapacitacion
        prog.NombreEmpleado = impresion.Text
        prog.CodigoEmpleado = Codigo.Text
        prog.ShowDialog()
    End Sub



    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        CBuscador(txtNomParroquia, 24)
    End Sub

    Private Sub BtnCanton_Click(sender As System.Object, e As System.EventArgs) Handles BtnCanton.Click
        CBuscador(TxtNomCanton, 23)
    End Sub

    Private Sub DEEP01_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F2 And e.Alt = True And Codigo.Text.Length > 0 Then
            Try
                Dim prog As New daxNota.ClassNota
                prog.verNotaReferencia("EMP", Codigo.Text, datosEmpresa.usr, datosEmpresa.strConxAdcom)
                Return
            Catch
            End Try
        End If
        If e.KeyCode = Keys.F3 And e.Alt = True And Codigo.Text.Length > 0 And impresion.Text.Length > 0 Then
            Try
                Dim prog As New daxNota.ClassNota()
                Dim nnota As New daxNota.DaxNot(datosEmpresa.strConxAdcom)
                nnota.fechaNota = Now
                nnota.idCodigo = Codigo.Text
                nnota.idNombre = impresion.Text
                nnota.idTipo = "DIR"
                nnota.UsuarioCreaNota = datosEmpresa.usr
                prog.nuevaNota(nnota)
                Return
            Catch
            End Try
        End If
    End Sub
    Private Sub btnPaisNace_Click(sender As Object, e As EventArgs) Handles btnPaisNace.Click
        CBuscador(txtPaisNace, 12)
    End Sub

    Private Sub btnProvNace_Click(sender As Object, e As EventArgs) Handles btnProvNace.Click
        CBuscador(txtProvNace, 13)
    End Sub

    Private Sub btnCiudadNace_Click(sender As Object, e As EventArgs) Handles btnCiudadNace.Click
        CBuscador(txtCiudadNace, 14)
    End Sub

    Private Sub btnRegionNace_Click(sender As Object, e As EventArgs) Handles btnRegionNace.Click
        CBuscador(txtRegionNace, 25)
    End Sub

    Private Sub btnRegion_Click(sender As Object, e As EventArgs) Handles btnRegion.Click
        CBuscador(txtRegion, 25)
    End Sub

    Private Sub btnPaísEntrega_Click(sender As Object, e As EventArgs) Handles btnPaísEntrega.Click
        CBuscador(txtPaisEntrega, 12)
    End Sub

    Private Sub btnPuertoEntrega_Click(sender As Object, e As EventArgs) Handles btnPuertoEntrega.Click
        CBuscador(entregarmer, 26)
    End Sub


    Private Sub btnBuscaOperador_Click(sender As Object, e As EventArgs) Handles btnBuscaOperador.Click
        Dim dat(2) As String
        dat = CbuscaDir("O", 0)
        txtOperador.Text = dat(1)
        codigoDirectorio(5) = dat(0)
    End Sub

    Private Sub btnTransportadora_Click(sender As Object, e As EventArgs) Handles btnTransportadora.Click
        Dim dat(2) As String
        dat = CbuscaDir("R", 0)
        txtTransportadora.Text = dat(1)
        codigoDirectorio(6) = dat(0)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        'Dim progRet As New DaxNomReten.frmRetencion(Codigo.Text, impresion.Text)
        'progRet.ShowDialog()
        'progRet.Dispose()
    End Sub

    Private Sub TipoIdent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TipoIdent.SelectedIndexChanged
        If TipoIdent.SelectedIndex = 0 Then TipoIdent.SelectedIndex = 1
    End Sub

End Class
