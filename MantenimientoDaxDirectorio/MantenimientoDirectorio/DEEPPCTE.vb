Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports DattCom

Public Class DEEPPCTE
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
    Dim ImgDirectorio As String = "\Directorio\"
    Public Sub IniciaNuevo()
        Try
            IniNvo = True
            Me.ShowDialog()
        Catch ee As Exception
            MsgBox("excepción iniNvo: " & ee.Message)
        End Try
    End Sub
    Private Sub LlenarCombos()
        Dim dc As New DaxCombobx.CargCmbBox()
        dc.DaxCombosReferencia("Paises", datosEmpresa.strConxAdcom, cmbPaisDomicilio, "S")
        dc.DaxCombosReferencia("Provincias", datosEmpresa.strConxAdcom, cmbProvinciaDomicilio, "S")
        dc.DaxCombosReferencia("Ciudades", datosEmpresa.strConxAdcom, cmbCiudadDomicilio, "S")
        dc.DaxCombosReferencia("Cantones", datosEmpresa.strConxAdcom, cmbCantonDomicilio, "S")
        dc.DaxCombosReferencia("Parroquias", datosEmpresa.strConxAdcom, cmbParroquiaDomicilio, "S")
        dc.DaxCombosReferencia("Regiones", datosEmpresa.strConxAdcom, cmbRegionDomicilio, "S")

        dc.DaxCombosReferencia("Paises", datosEmpresa.strConxAdcom, cmbPaisNace, "S")
        dc.DaxCombosReferencia("Provincias", datosEmpresa.strConxAdcom, cmbProvinciaNace, "S")
        dc.DaxCombosReferencia("Ciudades", datosEmpresa.strConxAdcom, cmbCiudadNace, "S")
        dc.DaxCombosReferencia("Regiones", datosEmpresa.strConxAdcom, cmbRegionNace, "S")


        dc.DaxCombosReferencia("Nacionalidad", datosEmpresa.strConxAdcom, cmbNacionalidadPersonal, "S")

        dc.DaxCombosReferencia("Profesion", datosEmpresa.strConxAdcom, cmbProfesion, "S")
        dc.DaxCombosReferencia("Especialidad", datosEmpresa.strConxAdcom, cmbEspecialidad, "S")
        dc.DaxCombosReferencia("Especialidad", datosEmpresa.strConxAdcom, cmbEspecialidad2, "S")

    End Sub
    Private Sub Apellidos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Apellidos.TextChanged

        Dim dt As DataTable = DattCom.datosEmpresa.leeParametrosEmp("par_acumhis")
        Try
            If Convert.ToBoolean(dt.Rows(0).Item("par_AcumHis")) = False Then
                impresion.Text = Trim(TxtNombres.Text & " " & Apellidos.Text)
            Else
                impresion.Text = Trim(Apellidos.Text & " " & TxtNombres.Text)
            End If
        Catch
            impresion.Text = Trim(Apellidos.Text & " " & TxtNombres.Text)
        End Try
    End Sub

    Private Function leerIdentificacion() As Boolean
        Dim datosIdentificacion As New Identificacion(datosEmpresa.strConxAdcom)
        datosIdentificacion = Identificacion.Buscar(" codigo = '" & QUECODIGO & "' ")

        If IsNothing(datosIdentificacion) Then Return False : Exit Function

        With datosIdentificacion
            Codigo.Text = .Codigo
            tipoper = .TipoPersona

            'If tipoper = "J" Then
            '    Juridica.Checked = True
            'Else
            '    tipoper = "N"
            '    Natural.Checked = True
            'End If

            'If tipoper = "J" Then Juridica.Checked = True : Natural.Checked = False
            'If tipoper = "N" Then Juridica.Checked = False : Natural.Checked = True

            'Cliente.Checked = .EsCliente
            'Proveedor.Checked = .EsProveedor
            'Empleado.Checked = .EsEmpleado
            'Banco.Checked = .EsBanco
            'EsVendedor.Checked = .EsVendedor
            'Asociacion.Checked = .EsAsociado

            'If CBool(.EsCliente")) = True Then Cliente.CheckState = CheckState.Checked Else Cliente.CheckState = CheckState.Unchecked
            'If CBool(.EsProveedor")) = True Then Proveedor.CheckState = CheckState.Checked Else Proveedor.CheckState = CheckState.Unchecked
            'If CBool(.EsEmpleado")) = True Then Empleado.CheckState = CheckState.Checked Else Empleado.CheckState = CheckState.Unchecked
            'If CBool(.EsBanco")) = True Then Banco.CheckState = CheckState.Checked Else Banco.CheckState = CheckState.Unchecked
            'If CBool(.EsVendedor")) = True Then EsVendedor.CheckState = CheckState.Checked Else EsVendedor.CheckState = CheckState.Unchecked
            'If CBool(.EsAsociado")) = True Then Asociacion.CheckState = CheckState.Checked Else Asociacion.CheckState = CheckState.Unchecked

            'If .EsDirecta = "SI" Then
            '    Directa.CheckState = CheckState.Checked
            'Else
            '    Directa.CheckState = CheckState.Unchecked
            'End If

            TipoIdent.SelectedIndex = CInt(Val(ArreglaId(CStr(CorrijeNulo(.TipoIdentificacion))))) ': TIPID = CStr(TipoIdent.SelectedIndex)
            TxtCedulaRuc.Text = .CedulaIdentidadRuc
            TxtNombres.Text = .Nombres
            Apellidos.Text = .Apellidos
            impresion.Text = .NombreImpresion

            TxtNroDomicilio.Text = .NumeroDomicilio
            cmbPaisDomicilio.SelectedValue = .País
            cmbProvinciaDomicilio.SelectedValue = .Provincia
            cmbCiudadDomicilio.SelectedValue = .Ciudad
            txtnomDireccion.Text = .Domicilio
            txtTelefono1.Text = .Telefono1
            txtTelefono2.Text = .Telefono2
            txtTelefono3.Text = .Telefono3
            TxtData6.Text = .NúmeroFax
            cmbParroquiaDomicilio.SelectedValue = .Casilla
            '!correoelectrónico = TxtData8.Text
            TxtData8.Text = .CorreoElectrónico
            TxtData9.Text = .Paginaweb
            cmbCantonDomicilio.SelectedValue = .Sector
            txtGrupo1.Text = .Grupo1
            txtGrupo2.Text = .Grupo2
            txtGrupo3.Text = .Grupo3
            txtHistoriaclinica.Text = .HistoriaClinica
            CodigoFoto = .Logotipo
            '-----------------------------) Then PorComision.Text = .ComisionVenta")
            '-----------------------------ones Then Text1.Text = .CtaCobrarComisiones")

            If datosEmpresa.usr <> .CodGrabo And .CodGrabo > "" Then propio = False Else propio = True

            ExoneradoIva.Checked = .ExoneradoIva
            chkRise.Checked = .esRise
            txtContribuyenteEspecial.Text = .NroCtrbuyteEspecial
            chkObligaContabilidad.Checked = .ObligLlevarConta
            chkRegimenMicroempresas.Checked = .RegimenMicroempresas

            cmbRegionDomicilio.Text = .regionDomicilio
            txtSector.Text = .SectorDomicilio
            TxtResolucionAR.Text = .NroAcdoAgntRetencion
        End With
        Return True
    End Function

    Private Function leerPersonal() As Boolean
        Dim datosPersonales As New dbPersonal(datosEmpresa.strConxAdcom)
        datosPersonales = dbPersonal.Buscar(" codigoper = '" & QUECODIGO & "'")
        If IsNothing(datosPersonales) Then Return False
        'Dim Buscod As New Syscod.ManSysnetClass
        'On Error Resume Next
        'Dim ConxAdcom As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
        'Dim rs As SqlClient.SqlDataReader
        'Dim Ssql As String = "select * from Personal where codigoper = '" & QUECODIGO & "'"
        'Dim comm As New SqlClient.SqlCommand(Ssql, ConxAdcom)
        'ConxAdcom.Open()
        'rs = comm.ExecuteReader

        'If rs.Read = False Then rs.Close() : Return False : Exit Function

        'tabla personal
        With datosPersonales
            '            If .Read Then
            fechanaci.Text = .FechaNacimiento.ToShortDateString()
            Lugarnaci.Text = .LugarNacimiento
            Sexo = .Sexo
            cmbEstadoCivil.Text = .EstadoCivil
            cmbNacionalidadPersonal.SelectedValue = .Nacionalidad
            hobbys.Text = .Hobbys


            txtCodTar.Text = .codigotarjrta
            txtNumTar.Text = .numerotarjrta


            cmbProfesion.SelectedValue = .Profesión
            cmbEspecialidad.SelectedValue = .Especialidad
            cmbEspecialidad2.SelectedValue = .Especialidad2
            txtReferirseComo.Text = .Referirsecomo
            cmbTipoSangre.Text = .TipoSangre
            txtLugTra.Text = .DirecciónTrabajo
            cmbCiudadNace.Text = .ciudadNacimto
            cmbRegionNace.Text = .regionNacimto
            cmbPaisNace.Text = .paisNacimto
            cmbProvinciaNace.Text = .provNacimto

            If Sexo = "M" Then
                mujer.Checked = True
            Else
                hombre.Checked = True
                Sexo = "H"
            End If
            txtDiscapacidad.Text = .Discapacidad
            txtPorcDiscapacidad.Text = .PorcentajeDiscapacidad.ToString("#0.00")
        End With
        Return True
    End Function

    Private Function leerCliente() As Boolean
        Dim datosCliente As New dbCliente(datosEmpresa.strConxAdcom)
        datosCliente = dbCliente.Buscar(" codigocli = '" & QUECODIGO & "' ")
        If IsNothing(datosCliente) Then Return False

        Dim Buscod As New Syscod.ManSysnetClass
        'On Error Resume Next
        'Dim ConxAdcom As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
        'Dim rs As SqlClient.SqlDataReader
        'Dim Ssql As String = "select * from cliente where codigocli = '" & QUECODIGO & "' "
        'Dim comm As New SqlClient.SqlCommand(Ssql, ConxAdcom)
        'ConxAdcom.Open()
        'rs = comm.ExecuteReader
        'If rs.Read = False Then rs.Close() : Return False : Exit Function
        ''If rs.Read Then
        'If Not IsDBNull(rs.Item("VendedorInterno")) Then
        If (datosCliente.VendedorInterno <> datosEmpresa.usr And datosCliente.CobradorInterno <> datosEmpresa.usr) Then propio = False
        'tabla cliente
        With datosCliente
            '   If .Read Then
            txtTipoCliente.Text = Buscod.QueNombre(.TipoCli, TipCodSyscod(3))
            txtZonaVentas.Text = Buscod.QueNombre(.ZonaVentas, TipCodSyscod(4))
            txtVendedor.Text = QueNombre(.VendedorInterno) : codigoDirectorio(0) = .VendedorInterno
            txtOperador.Text = QueNombre(.Operador) : codigoDirectorio(5) = .Operador
            txtTransportadora.Text = QueNombre(.Transportadora) : codigoDirectorio(6) = .Transportadora
            txtZonaCobranzas.Text = Buscod.QueNombre(.ZonaCobranza, TipCodSyscod(5))
            txtCobrador.Text = QueNombre(.CobradorInterno) : codigoDirectorio(1) = .CobradorInterno
            txtPrecioVenta.Text = Buscod.QueNombre(.PrecioVenta, TipCodSyscod(6))
            txtFormaPago.Text = RetornaNombre.RetornaNombrePago(.FormaPago, datosEmpresa.strConxAdcom)
            txtPorcDescuento.Text = .PorcDescuento.ToString()
            txtLimiteCredito.Text = .LimiteCredito.ToString()
            txtDescuentoAsociacion.Text = .DescuentoAso.ToString()
            observacli.Text = .Observaciones
            txtContacto.Text = .Contacto
            entregarmer.Text = .Entregarmercaderia
            Cuenta0.Text = .CtbCobrar
            Cuenta4.Text = .CtbCobrar2
            'End If
            entregarmer.Text = .PuertoEmbarque
            txtPaisEntrega.Text = .PaisEmbarque
        End With
        'rs.Close()
        'comm.Dispose()
        'ConxAdcom.Close()
        'ConxAdcom.Dispose()
        Return True
    End Function
    'Private Function leerProveedor() As Boolean
    '    On Error Resume Next
    '    Dim ConxAdcom As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
    '    Dim rs As SqlClient.SqlDataReader
    '    On Error Resume Next
    '    Dim Ssql As String = "Select * from proveedor where codigoproveedor = '" & QUECODIGO & "'"
    '    Dim comm As New SqlClient.SqlCommand(Ssql, ConxAdcom)
    '    ConxAdcom.Open()
    '    rs = comm.ExecuteReader

    '    If rs.Read = False Then rs.Close() : Return False : Exit Function

    '    'tabla proveedor
    '    With rs
    '        'If .Read Then
    '        If Not IsDBNull(.Item("FormaPago")) Then Lcod8.Text = RetornaNombre.RetornaNombrePago(CStr(.Item("FormaPago")), datosEmpresa.strConxAdcom)
    '        If Not IsDBNull(.Item("PorceDescuent")) Then porcedescuentoprv.Text = CStr(.Item("PorceDescuent"))
    '        'If CorrijeNuloN(.Item("IncluyeTranspo")) = 1 Then incluyetransporte.CheckState = CheckState.Checked Else incluyetransporte.CheckState = CheckState.Unchecked
    '        incluyetransporte.Checked = Convert.ToBoolean(.Item("IncluyeTranspo"))

    '        If Not IsDBNull(.Item("limcreditoprv")) Then limcreditoprv.Text = CStr(.Item("limcreditoprv"))
    '        If Not IsDBNull(.Item("Producto1")) Then producto.Text = CStr(.Item("Producto1"))
    '        If Not IsDBNull(.Item("Servicios1")) Then servicios.Text = CStr(.Item("Servicios1"))
    '        If Not IsDBNull(.Item("Observaciones")) Then observacionesprv.Text = CStr(.Item("Observaciones"))
    '        If Not IsDBNull(.Item("ctbproveedor")) Then Cuenta1.Text = CStr(.Item("ctbproveedor"))
    '        If Not IsDBNull(.Item("ctbproveedor2")) Then Cuenta5.Text = CStr(.Item("ctbproveedor2"))

    '        'If CorrijeNuloN(.Item("EntregaNuestraOficina")) = 1 Then chkEntregaDirecccion.CheckState = CheckState.Checked Else chkEntregaDirecccion.CheckState = CheckState.Unchecked
    '        'If CorrijeNuloN(.Item("RetirarMercaderia")) = 1 Then chkRetirarProveedor.CheckState = CheckState.Checked Else chkRetirarProveedor.CheckState = CheckState.Unchecked
    '        'If CorrijeNuloN(.Item("EnvioATransporte")) = 1 Then chkRetirarTransporte.CheckState = CheckState.Checked Else chkRetirarTransporte.CheckState = CheckState.Unchecked

    '        chkEntregaDirecccion.Checked = CBool(.Item("EntregaNuestraOficina"))
    '        chkRetirarTransporte.Checked = CBool(.Item("EnvioATransporte"))
    '        chkRetirarProveedor.Checked = CBool(.Item("RetirarMercaderia"))

    '        'chkAereo.Checked = (CorrijeNuloN(.Item("transAereo")) = 1) 'Ten chkAereo.CheckState = CheckState.Checked Else Check4.CheckState = CheckState.Unchecked
    '        'chkMaritimo.Checked = (CorrijeNuloN(.Item("transMaritimo")) = 1) 'Then Check4.CheckState = CheckState.Checked Else Check4.CheckState = CheckState.Unchecked
    '        'chkTerrestre.Checked = (CorrijeNuloN(.Item("transTerrestre")) = 1) 'Then Check4.CheckState = CheckState.Checked Else Check4.CheckState = CheckState.Unchecked

    '        chkAereo.Checked = CBool(.Item("transAereo"))
    '        chkMaritimo.Checked = CBool(.Item("transMaritimo"))
    '        chkTerrestre.Checked = CBool(.Item("transTerrestre"))



    '        'End If
    '    End With
    '    rs.Close()
    '    comm.Dispose()
    '    ConxAdcom.Close()
    '    ConxAdcom.Dispose()
    '    Return True
    'End Function

    'tabla empleado
    'Private Function leerContactos() As Boolean
    '    On Error Resume Next
    '    'tabla contacto
    '    Dim Buscod As New Syscod.ManSysnetClass
    '    Dim i As Integer

    '    Dim ConxAdcom As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
    '    Dim rs As SqlClient.SqlDataReader
    '    Dim Ssql As String = "select * from contactos where codcontacto = '" & QUECODIGO & "'"
    '    Dim comm As New SqlClient.SqlCommand(Ssql, ConxAdcom)
    '    ConxAdcom.Open()
    '    rs = comm.ExecuteReader

    '    i = 0
    '    With rs
    '        Do While .Read
    '            MallaCtco.Rows.Add()
    '            MallaCtco.Rows(i).Cells(0).Value = CorrijeNulo(.Item("Principal"))
    '            MallaCtco.Rows(i).Cells(1).Value = CorrijeNulo(.Item("Nombre"))
    '            MallaCtco.Rows(i).Cells(2).Value = CorrijeNulo(.Item("Cargo"))
    '            MallaCtco.Rows(i).Cells(3).Value = CorrijeNulo(.Item("Extensión"))
    '            MallaCtco.Rows(i).Cells(4).Value = CorrijeNulo(.Item("TelfCelular"))
    '            MallaCtco.Rows(i).Cells(5).Value = CorrijeNulo(.Item("TeléfonoDirecto"))
    '            MallaCtco.Rows(i).Cells(6).Value = CorrijeNulo(.Item("FechaNacimiento"))
    '            MallaCtco.Rows(i).Cells(7).Value = CorrijeNulo(.Item("Actividades"))
    '            MallaCtco.Rows(i).Cells(8).Value = CorrijeNulo(.Item("Preferencias"))
    '            MallaCtco.Rows(i).Cells(9).Value = CorrijeNulo(.Item("Observaciones"))
    '            i += 1
    '        Loop
    '    End With
    '    rs.Close()
    '    comm.Dispose()
    '    ConxAdcom.Close()
    '    ConxAdcom.Dispose()
    '    Return True
    'End Function

    'Private Function leerAlias() As Boolean
    '    On Error Resume Next
    '    Dim i As Integer

    '    Dim ConxAdcom As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
    '    Dim rs As SqlClient.SqlDataReader

    '    Dim Ssql As String = "select * from identificacionalias where CodigoEmpresa = '" & QUECODIGO & "'"
    '    Dim comm As New SqlClient.SqlCommand(Ssql, ConxAdcom)
    '    ConxAdcom.Open()
    '    rs = comm.ExecuteReader

    '    With rs
    '        i = 0
    '        Do While .Read

    '            MallaAlias.Rows.Add()
    '            MallaAlias.Rows(i).Cells(0).Value = CorrijeNulo(.Item("NombreAlias"))
    '            MallaAlias.Rows(i).Cells(1).Value = CorrijeNulo(.Item("DirecciónAlterna"))
    '            MallaAlias.Rows(i).Cells(2).Value = CorrijeNulo(.Item("Teléfono_1"))
    '            MallaAlias.Rows(i).Cells(3).Value = CorrijeNulo(.Item("Teléfono_2"))
    '            MallaAlias.Rows(i).Cells(4).Value = CorrijeNulo(.Item("Id_Sri"))
    '            MallaAlias.Rows(i).Cells(5).Value = CorrijeNulo(.Item("Observaciones"))
    '            i += 1
    '        Loop
    '    End With
    '    rs.Close()
    '    comm.Dispose()
    '    ConxAdcom.Close()
    '    ConxAdcom.Dispose()
    '    Return True
    'End Function
    Private Function leerFamiliares() As Boolean
        On Error Resume Next
        Dim i As Integer = 0
        Dim ConxAdcom As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
        Dim rs As SqlClient.SqlDataReader

        Dim Ssql As String = "select * from ROLFAM where CodEmpleado = '" & QUECODIGO & "'"
        Dim comm As New SqlClient.SqlCommand(Ssql, ConxAdcom)
        ConxAdcom.Open()
        rs = comm.ExecuteReader

        'If rs.Read = False Then rs.Close() : Return False : Exit Function

        With rs
            Do While .Read
                malla.Rows.Add()
                'malla.Rows(i).Cells(0) = i + 1
                malla.Rows(i).Cells("CedulaId").Value = CorrijeNulo(.Item("CEDULA"))
                malla.Rows(i).Cells("Nombres").Value = CorrijeNulo(.Item("Nombres"))
                malla.Rows(i).Cells("Parentesco").Value = CorrijeNulo(.Item("Parentesco"))
                malla.Rows(i).Cells("FechaNacim").Value = CorrijeNulo(.Item("FechaNacimiento"))
                malla.Rows(i).Cells("Sexo1").Value = CorrijeNulo(.Item("Sexo"))
                malla.Rows(i).Cells("EstadoCivil").Value = CorrijeNulo(.Item("EstadoCivil"))
                malla.Rows(i).Cells("Direccion").Value = CorrijeNulo(.Item("Direccion"))
                malla.Rows(i).Cells("Teléfono_1").Value = CorrijeNulo(.Item("Teléfono_1"))
                malla.Rows(i).Cells("Teléfono_2").Value = CorrijeNulo(.Item("Teléfono_2"))
                malla.Rows(i).Cells("Ocupación").Value = CorrijeNulo(.Item("Ocupacion"))
                If CorrijeNulo(.Item("EsDependiente")).ToString = "Si" Then malla.Rows(i).Cells("Depend").Value = "Si" Else malla.Rows(i).Cells("Depend").Value = "No"
                If CorrijeNulo(.Item("EsMinusvalido")).ToString = "Si" Then malla.Rows(i).Cells("Minusv").Value = "Si" Else malla.Rows(i).Cells("Minusv").Value = "No"
                i += 1
            Loop
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
        'If Natural.Checked = True Then Empleado.Enabled = True : Banco.Enabled = False : Banco.Checked = False Else Empleado.Enabled = False : Banco.Enabled = True

        'If Natural.Checked = False Then
        '    tabDatosPer.Parent = Nothing
        '    tabFamiliares.Parent = Nothing
        'Else
        '    tabDatosPer.Parent = DatosDirectorio
        '    tabFamiliares.Parent = DatosDirectorio
        'End If
        'If Empleado.Checked = False Then
        '    tabEmpleado.Parent = Nothing
        'Else
        '    tabEmpleado.Parent = DatosDirectorio
        'End If

        'If Cliente.Checked = False Then tabCliente.Parent = Nothing Else tabCliente.Parent = DatosDirectorio '.TabPages.Add(tabCliente)
        'If Proveedor.Checked = False Then tabProveedor.Parent = Nothing Else tabProveedor.Parent = DatosDirectorio

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

    'Private Sub CBuscador8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim ElCodigo As String = ""
    '    Dim BusPAG As New Buscar.frmBuscar   'DaxPagos.BuscadorPagos
    '    Dim sSql As String = "select top 100 percent idFormasDePago,Descripcion as Descripción from formasdepago where tipoformapago <> 2 order by Descripcion"
    '    ElCodigo = BusPAG.Buscar(datosEmpresa.strConxAdcom, sSql, "idFormasDePago", "Descripción", "", "Formas de pago clientes")
    '    BusPAG = Nothing
    '    Lcod8.Text = RetornaNombre.RetornaNombrePago(ElCodigo, datosEmpresa.strConxAdcom)
    'End Sub

    'Private Sub CBuscador0_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    CBuscadorSuc()
    'End Sub

    'Private Sub CBuscador10_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    CBuscador(textNomCargo, 10)
    'End Sub

    'Private Sub CBuscador11_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    CBuscador(Lcod11, 11)
    'End Sub

    'Private Sub CBuscador12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBuscador12.Click
    '    CBuscador(txtNomPais, 12)
    'End Sub

    'Private Sub CBuscador13_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    CBuscador(txtNomProvincia, 13)
    'End Sub

    'Private Sub CBuscador14_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Me.UseWaitCursor = True
    '    Me.Cursor = Cursors.WaitCursor
    '    CBuscador(txtNomCiudad, 14)
    '    Me.UseWaitCursor = False
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Sub CBuscador2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    CBuscador(Lcod2, 2)
    'End Sub

    Private Sub CBuscador3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBuscador3.Click
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

    'Private Sub CBuscador9_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    CBuscador(textNomDepartamento, 9)
    'End Sub
    Private Sub CBuscador(ByRef lcod As TextBox, ByVal indice As Integer)
        Dim ElNombre As String = ""
        Dim ElCodigo As String = ""
        Dim Buscod As New Syscod.ManSysnetClass
        ElCodigo = Buscod.BuscarReferencia(TipCodSyscod(indice), ElCodigo, ElNombre)
        lcod.Text = ElNombre
        Buscod = Nothing
    End Sub
    'Private Sub CBuscadorSuc()
    '    Dim ssql As String = "select suc_codigo as cod, suc_nombre as Nombre from emp_suc where emp_codigo = " + datosEmpresa.codEmpresa.ToString()
    '    Dim BuscaSuc As New Buscar.frmBuscar
    '    CodSuc = BuscaSuc.Buscar(datosEmpresa.strConxSyscod, ssql, "cod", "Nombre", "", "Buscar sucursales", "")
    '    textNomSucursal.Text = RetornaNombre.RetornaNombreSucursal(datosEmpresa.codEmpresa, CodSuc, datosEmpresa.strConxSyscod)

    '    BuscaSuc.Dispose()
    'End Sub

    Private Sub CBuscador(ByRef lcod As Label, ByVal indice As Integer)
        Dim ElNombre As String = ""
        Dim ElCodigo As String = ""
        Dim Buscod As New Syscod.ManSysnetClass
        lcod.Text = Buscod.BuscarReferencia(TipCodSyscod(indice), ElCodigo, ElNombre)
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

    'Private Sub ComCtb1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    cuenta(Cuenta2, Keys.F2, 0 \ &H10000)
    'End Sub

    'Private Sub Comctb2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    cuenta(Cuenta3, Keys.F2, 0 \ &H10000)
    'End Sub

    Private Sub Command1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Command1.Click
        cuenta(Cuenta0, Keys.F2, 0 \ &H10000)
    End Sub

    Private Sub Command5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Command5.Click
        cuenta(Cuenta4, Keys.F2, 0 \ &H10000)
    End Sub

    'Private Sub Command6_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    cuenta(Cuenta5, Keys.F2, 0 \ &H10000)
    'End Sub

    Private Sub BuscarRegistro()
        Dim prog As New BuscaClien
        Codigo.Text = prog.IniBuscaCliOPro("T", "", "", "N")
        prog.Close()
        prog.Dispose()
        If Codigo.Text > "" Then SaliendoCodigo()
    End Sub

    'Private Sub Command2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    cuenta(Cuenta1, Keys.F2, 0 \ &H10000)
    'End Sub

    Private Sub Cuenta0_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        cuenta(Cuenta0, e.KeyCode, e.KeyData \ &H10000)
    End Sub

    'Private Sub Cuenta1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    cuenta(Cuenta1, e.KeyCode, e.KeyData \ &H10000)
    'End Sub

    'Private Sub Cuenta2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    cuenta(Cuenta2, e.KeyCode, e.KeyData \ &H10000)
    'End Sub

    'Private Sub Cuenta3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    cuenta(Cuenta3, e.KeyCode, e.KeyData \ &H10000)
    'End Sub

    'Private Sub Cuenta4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    cuenta(Cuenta3, e.KeyCode, e.KeyData \ &H10000)
    'End Sub

    'Private Sub Cuenta5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    cuenta(Cuenta5, e.KeyCode, e.KeyData \ &H10000)
    'End Sub

    Private Sub cuenta(ByRef cuenta As Label, ByVal KeyCode As Integer, ByVal Shift As Integer)
        Dim prog As New CtaMtn.BuscaCta
        Dim Nombre As String = ""
        If KeyCode = System.Windows.Forms.Keys.F2 Then
            cuenta.Text = prog.BuscaCtaCtb(Nombre, "I")
            prog = Nothing
        End If
    End Sub

    Private Sub Datox0_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCedulaRuc.KeyDown
        Dim KeyCode As Integer = e.KeyCode
        Dim Shift As Integer = e.KeyData \ &H10000
        If KeyCode = System.Windows.Forms.Keys.F2 Then TxtCedulaRuc.Text = Codigo.Text
    End Sub

    Private Sub Datox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNombres.TextChanged
        If Emp.OrdenaPorApellidos = False Then
            impresion.Text = Trim(TxtNombres.Text & " " & Apellidos.Text)
        Else
            impresion.Text = Trim(Apellidos.Text & " " & TxtNombres.Text)
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

    'Private Sub Banco_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Natural.Checked = True Then Banco.Checked = False
    'End Sub
    Public Sub Directorio(ByVal cod As String)
        Try
            If cod = "" Then
                LimpiezaFormulario()
                QUECODIGO = ""
                '    Juridica.Checked = True
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

    Private Sub DEEPPCTE_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
            MessageBox.Show("Excepción : el directorio " + ImgDirectorio + vbCr + " no es accesible  ")
        End Try
    End Sub


    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim Buscod As New Syscod.ManSysnetClass
        Try
            malla.EndEdit()
            'mallaConceptos.EndEdit()
            MallaCtco.EndEdit()
            'mallaDatos.EndEdit()
            If validacionDatos() = False Then Return

            CodigoBusca = Codigo.Text
            cedulabusca = TxtCedulaRuc.Text

            Dim DatosIdentificacion As New Identificacion(datosEmpresa.strConxAdcom)

            If IsDBNull(CodigoBusca) Then CodigoBusca = ""
            DatosIdentificacion = Identificacion.Buscar("cedulaidentidadruc='" & cedulabusca & "' and codigo <> '" & CodigoBusca & "' ")
            If Not DatosIdentificacion Is Nothing Then
                TxtCedulaRuc.Text = ""
                MsgBox("El Nro. ID (cédula o ruc) ya existe ", MsgBoxStyle.Critical)
                TxtCedulaRuc.Focus()
                Exit Sub
            End If
            DatosIdentificacion = New Identificacion(datosEmpresa.strConxAdcom)
            Dim movdatId As New moverDatosIdentificacion()
            movdatId.movDatIdentificacion(Me, DatosIdentificacion, codigoDirectorio)
            movdatId = Nothing

            With DatosIdentificacion
                If .Actualizar("Select * from Identificacion " & " where identificacion.codigo = '" & CodigoBusca & "' ").Substring(0, 5) = "ERROR" Then
                    MsgBox("El registro de identificacion no puede grabarse ", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            End With
            DatosIdentificacion = Nothing

            SaveSetting("Alex", "Codigos", "Ultimo", Codigo.Text)

            'tabla personal
            'If Natural.Checked = True Then
            Dim tablaper = New dbPersonal(datosEmpresa.strConxAdcom)
            With tablaper
                .CodigoPer = Codigo.Text
                If IsDate(fechanaci.Text) Then .FechaNacimiento = CDate(fechanaci.Text) Else .FechaNacimiento = CDate("01/01/1900")
                .LugarNacimiento = Lugarnaci.Text
                If (hombre.Checked = True) Then .Sexo = "H" Else .Sexo = "M"
                .EstadoCivil = cmbEstadoCivil.Text
                If Not IsNothing(cmbNacionalidadPersonal.SelectedValue) Then .Nacionalidad = cmbNacionalidadPersonal.SelectedValue.ToString()
                .Hobbys = hobbys.Text

                .codigotarjrta = txtCodTar.Text
                .numerotarjrta = txtNumTar.Text

                .Profesión = CorrijeNulo(cmbProfesion.SelectedValue)
                .Especialidad = CorrijeNulo(cmbEspecialidad.SelectedValue)
                .Especialidad2 = CorrijeNulo(cmbEspecialidad2.SelectedValue)
                .Referirsecomo = txtReferirseComo.Text
                .AsociadoAEmpresa = CInt("0" & codigoDirectorio(3))
                .TipoSangre = cmbTipoSangre.Text
                .DirecciónTrabajo = txtLugTra.Text

                .paisNacimto = cmbPaisNace.Text
                .provNacimto = cmbProvinciaNace.Text
                .ciudadNacimto = cmbCiudadNace.Text
                .regionNacimto = cmbRegionNace.Text

                .Discapacidad = txtDiscapacidad.Text
                .PorcentajeDiscapacidad = Convert.ToDecimal("0" + txtPorcDiscapacidad.Text)


                If .Actualizar("select * from Personal where codigoper = '" & Codigo.Text & "'").Substring(0, 5) = "ERROR" Then
                    MsgBox("El registro personal no puede grabarse", MsgBoxStyle.Exclamation)
                End If
            End With
            tablaper = Nothing
            'End If

            'tabla cliente
            'If Cliente.CheckState = 1 Then
            '    Dim tablacli = New dbCliente(datosEmpresa.strConxAdcom)
            '    With tablacli
            '        .CodigoCli = Codigo.Text
            '        .TipoCli = Buscod.QueCodigo(txtTipoCliente.Text, TipCodSyscod(3))
            '        .ZonaVentas = Buscod.QueCodigo(txtZonaVentas.Text, TipCodSyscod(4))
            '        .VendedorInterno = codigoDirectorio(0)
            '        .Operador = codigoDirectorio(5)
            '        .Transportadora = codigoDirectorio(6)
            '        .ZonaCobranza = Buscod.QueCodigo(txtZonaCobranzas.Text, TipCodSyscod(5))
            '        .CobradorInterno = codigoDirectorio(1)
            '        .PrecioVenta = Buscod.QueCodigo(txtPrecioVenta.Text, TipCodSyscod(6))
            '        .FormaPago = RetornaNombre.RetornaCodigoPago(txtFormaPago.Text, datosEmpresa.strConxAdcom)
            '        .PorcDescuento = CDec(Val(txtPorcDescuento.Text))
            '        .LimiteCredito = CDec(Val(txtLimiteCredito.Text))
            '        .DescuentoAso = CDec(Val(txtDescuentoAsociacion.Text))
            '        .Observaciones = observacli.Text
            '        .Contacto = txtContacto.Text
            '        .Entregarmercaderia = entregarmer.Text
            '        .CtbCobrar = Cuenta0.Text
            '        .CtbCobrar2 = Cuenta4.Text
            '        .PaisEmbarque = txtPaisEntrega.Text
            '        .PuertoEmbarque = entregarmer.Text

            '        If .Actualizar("select * from cliente where codigocli = '" & Codigo.Text & "' ").Substring(0, 5) = "ERROR" Then
            '            MsgBox("El registro cliente no puede grabarse", MsgBoxStyle.Exclamation)
            '        End If
            '    End With
            '    tablacli = Nothing
            'End If

            ''PROVEEDOR
            'If Proveedor.Checked Then
            '    Dim tablapro As New dbProveedor(datosEmpresa.strConxAdcom)
            '    With tablapro
            '        .CodigoProveedor = Codigo.Text
            '        .FormaPago = RetornaNombre.RetornaCodigoPago(Lcod8.Text, datosEmpresa.strConxAdcom)
            '        .PorceDescuent = CDec(Val(porcedescuentoprv.Text))
            '        If incluyetransporte.Checked Then .IncluyeTranspo = True Else .IncluyeTranspo = False
            '        .LimCreditoPrv = CDec(Val(limcreditoprv.Text))
            '        .Producto1 = producto.Text
            '        .Servicios1 = servicios.Text
            '        .Observaciones = observacionesprv.Text
            '        .CtbProveedor = Cuenta1.Text
            '        .CtbProveedor2 = Cuenta5.Text

            '        If chkEntregaDirecccion.Checked Then .EntregaNuestraOficina = True Else .EntregaNuestraOficina = False
            '        If chkRetirarProveedor.Checked Then .RetirarMercaderia = True Else .RetirarMercaderia = False
            '        If chkRetirarTransporte.Checked Then .EnvioATransporte = True Else .EnvioATransporte = False

            '        If chkAereo.Checked Then .transAereo = True Else .transAereo = False
            '        If chkMaritimo.Checked Then .transMaritimo = True Else .transMaritimo = False
            '        If chkTerrestre.Checked Then .transTerrestre = True Else .transTerrestre = False


            '        If .Actualizar("select * from proveedor where codigoproveedor = '" & Codigo.Text & "'").Substring(0, 5) = "ERROR" Then
            '            MsgBox("El registro proveedor no puedo grabarse", MsgBoxStyle.Exclamation)
            '        End If


            '    End With
            '    tablapro = Nothing
            'End If
            ''tabla empleado


            'Dim tablacon As New dbContactos(datosEmpresa.strConxAdcom)

            'Dim ConxAdcom As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
            'ConxAdcom.Open()
            'Dim Ssql As String = "delete from contactos where codcontacto='" & QUECODIGO & "' "
            'Dim comm As New SqlClient.SqlCommand(Ssql, ConxAdcom)
            'comm.ExecuteNonQuery()

            'If MallaCtco.RowCount > 1 Then
            '    For i = 0 To MallaCtco.RowCount - 2
            '        If Not (MallaCtco.Rows(i).Cells(1).Value Is Nothing) Then
            '            tablacon = New dbContactos
            '            With tablacon
            '                .CodContacto = QUECODIGO
            '                .Principal = CStr(MallaCtco.Rows(i).Cells(0).Value)
            '                .Nombre = CStr(MallaCtco.Rows(i).Cells(1).Value)
            '                .Cargo = CStr(MallaCtco.Rows(i).Cells(2).Value)
            '                .Extensión = CStr(MallaCtco.Rows(i).Cells(3).Value)
            '                .TelfCelular = CStr(MallaCtco.Rows(i).Cells(4).Value)
            '                .TeléfonoDirecto = CStr(MallaCtco.Rows(i).Cells(5).Value)
            '                If IsDate(MallaCtco.Rows(i).Cells(6).Value) Then .FechaNacimiento = CDate(MallaCtco.Rows(i).Cells(6).Value) Else .FechaNacimiento = CDate("01/01/1900")
            '                .Actividades = CStr(MallaCtco.Rows(i).Cells(7).Value)
            '                .Preferencias = CStr(MallaCtco.Rows(i).Cells(8).Value)
            '                .Observaciones = CStr(MallaCtco.Rows(i).Cells(9).Value)
            '                If .Actualizar("select * from contactos where codcontacto='" & Codigo.Text & "' and nombre = '" + .Nombre + "' ").Substring(0, 5) = "ERROR" Then
            '                    MsgBox("El registro contactos no se guardó", MsgBoxStyle.Exclamation)
            '                End If
            '            End With
            '        End If
            '    Next
            'End If

            'tablacon = Nothing


            'Ssql = "delete from identificacionalias where codigoempresa='" & QUECODIGO & "' "
            'comm = New SqlClient.SqlCommand(Ssql, ConxAdcom)
            'comm.ExecuteNonQuery()

            'Dim tablaAlias As New dbIdentificacionAlias
            'If MallaAlias.RowCount > 1 Then
            '    For i = 0 To MallaAlias.RowCount - 2
            '        If Not (MallaAlias.Rows(i).Cells(1).Value Is Nothing) Then
            '            tablaAlias = New dbIdentificacionAlias(datosEmpresa.strConxAdcom)
            '            With tablaAlias
            '                .CodigoEmpresa = QUECODIGO
            '                .NombreAlias = CStr(MallaAlias.Rows(i).Cells(0).Value)
            '                .DirecciónAlterna = CStr(MallaAlias.Rows(i).Cells(1).Value)
            '                .Teléfono_1 = CStr(MallaAlias.Rows(i).Cells(2).Value)
            '                .Teléfono_2 = CStr(MallaAlias.Rows(i).Cells(3).Value)
            '                .Id_Sri = CStr(MallaAlias.Rows(i).Cells(4).Value)
            '                .Observaciones = CStr(MallaAlias.Rows(i).Cells(5).Value)
            '                If .Actualizar("select * from IdentificacionAlias  where codigoEmpresa = '" & Codigo.Text & "' and nombreAlias = '" + .NombreAlias + "' ").Substring(0, 5) = "ERROR" Then
            '                    MsgBox("El registro alias no se grabó", MsgBoxStyle.Exclamation)
            '                    Exit Sub
            '                End If
            '            End With
            '        End If
            '    Next
            'End If
            'tablaAlias = Nothing


            'Ssql = "delete from rolfam where CodEmpleado='" & QUECODIGO & "' "
            'comm = New SqlClient.SqlCommand(Ssql, ConxAdcom)
            'comm.ExecuteNonQuery()

            'Dim tablaFam As New dbFamilia(datosEmpresa.strConxAdcom)
            'For Each rr As DataGridViewRow In malla.Rows
            '    tablaFam = New dbFamilia(datosEmpresa.strConxAdcom)
            '    If Not (rr.Cells(1).Value Is Nothing) Then
            '        If rr.Cells(1).Value.ToString() <> "" Then
            '            With tablaFam
            '                .CodEmpleado = QUECODIGO
            '                .CEDULA = CStr(rr.Cells(1).Value)
            '                .Nombres = CStr(rr.Cells(2).Value)
            '                .Parentesco = CStr(rr.Cells(3).Value)
            '                If IsDate(rr.Cells(4).Value) Then .FechaNacimiento = CDate(rr.Cells(4).Value) Else .FechaNacimiento = CDate("01/01/1900")
            '                .Sexo = CStr(rr.Cells(5).Value)
            '                .EstadoCivil = CStr(rr.Cells(6).Value)
            '                .Direccion = CStr(rr.Cells(7).Value)
            '                .Teléfono_1 = CStr(rr.Cells(8).Value)
            '                .Teléfono_2 = CStr(rr.Cells(9).Value)
            '                .Ocupacion = CStr(rr.Cells(10).Value)
            '                .EsDependiente = CStr(rr.Cells(11).Value)
            '                .EsMinusvalido = CStr(rr.Cells(12).Value)
            '                If .Actualizar("select * from ROLFAM where codeMPLEADO = '" & Codigo.Text & "' AND CEDULA = '" + tablaFam.CEDULA + "' ").Substring(0, 5) = "ERROR" Then
            '                    MsgBox("El registro de familiares no se grabó", MsgBoxStyle.Exclamation)
            '                    Exit Sub
            '                End If
            '            End With
            '        End If
            '    End If
            'Next

            ''If mallaDatos.RowCount > 0 And Emp.rol = True Then GuardarAdicionales()
            ''If mallaConceptos.RowCount > 0 And Emp.rol = True Then GuardarConceptos()

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
    Private Function validacionDatos() As Boolean
        Dim resp As Boolean = False
        If Codigo.Text = "" Then MsgBox("Digite un Código Válido", MsgBoxStyle.Critical) : Return resp
        If DattCom.datosEmpresa.LongCodDirectorio > 0 And Codigo.Text.Length <> DattCom.datosEmpresa.LongCodDirectorio Then MsgBox("El código debe tener la longitud correcta (" + DattCom.datosEmpresa.LongCodDirectorio.ToString() + ")", MsgBoxStyle.Critical) : Return resp
        If TipoIdent.Text = "" Then MsgBox("Falta el tipo de identificación", MsgBoxStyle.Critical) : Return resp
        If TxtCedulaRuc.Text = "" Then MsgBox("Debe ingresar el RUC o CI", MsgBoxStyle.Information) : TxtCedulaRuc.Focus() : Return resp

        If ValidaNumeroId() = False Then
            MsgBox("El numero del documento de identificacion está errado ", MsgBoxStyle.Critical)
            TxtCedulaRuc.Focus()
            Return resp
        End If
        If (txtHistoriaclinica.Text.Length = 0) Then txtHistoriaclinica.Text = Codigo.Text

        If TxtNombres.Text = "" Then MsgBox("Debe ingresar el nombre", MsgBoxStyle.Information) : TxtNombres.Focus() : Return resp
        'If Natural.Checked = True Then
        If Apellidos.Text = "" Then MsgBox("Debe ingresar Los apellidos", MsgBoxStyle.Information) : TxtNombres.Focus() : Return resp
        'End If
        If impresion.Text = "" Then impresion.Focus() : MsgBox("Debe ingresar el nombre de impresión", MsgBoxStyle.Information) : Return resp

        Dim errado As String = ""
        'If IsDBNull(cmbCantonDomicilio.SelectedValue) Then errado += " ; Canton de domicilio"
        'If IsDBNull(cmbCargoRol.SelectedValue) Then errado += " ;  Cargo del rol "
        'If IsDBNull(cmbCentroCostoRol.SelectedValue) Then errado += " ;  Centro de costo del rol "
        'If IsDBNull(cmbCiudadDomicilio.SelectedValue) Then errado += " ;  Ciudad del domicilio "
        'If IsDBNull(cmbCiudadNace.SelectedValue) Then errado += " ;  Ciudad de nacimiento "
        'If IsDBNull(cmbDepartamentoRol.SelectedValue) Then errado += " ;  Departamento en rol "
        'If IsDBNull(cmbEspecialidad.SelectedValue) Then errado += " ;  Especialidad "
        'If IsDBNull(cmbEspecialidad2.SelectedValue) Then errado += " ;  Especialidad 2 "
        'If IsDBNull(cmbEstadoCivil.SelectedValue) Then errado += " ;  Estado civil "
        'If IsDBNull(cmbModuloRol.SelectedValue) Then errado += " ;  Módulo del rol "
        'If IsDBNull(cmbNacionalidadPersonal.SelectedValue) Then errado += " ;  Nacionalidad "
        'If IsDBNull(cmbPaisDomicilio.SelectedValue) Then errado += " ;  País de domicilio "
        'If IsDBNull(cmbPaisNace.SelectedValue) Then errado += " ;  País de nacimiento  "
        'If IsDBNull(cmbParroquiaDomicilio.SelectedValue) Then errado += " ;  Parroquia de domicilio "
        'If IsDBNull(cmbProfesion.SelectedValue) Then errado += " ;  Profesión "
        'If IsDBNull(cmbProvinciaDomicilio.SelectedValue) Then errado += " ;  Provincia de domicilio "
        'If IsDBNull(cmbProvinciaNace.SelectedValue) Then errado += " ;  Provincia d nacimiento "
        'If IsDBNull(cmbRegionDomicilio.SelectedValue) Then errado += " ;  Región de domicilio "
        'If IsDBNull(cmbRegionNace.SelectedValue) Then errado += " ;  Región de nacimiento "
        'If IsDBNull(cmbSeccionRol.SelectedValue) Then errado += " ;  Sección del rol "
        'If IsDBNull(cmbSucursalRol.SelectedValue) Then errado += " ;  Sucursal del rol "
        'If IsDBNull(cmbTipoSangre.SelectedValue) Then errado += " ;  Tipo de sangre "

        If errado.Trim.Length > 0 Then
            MessageBox.Show("Errores de digitación encontrados : " + vbCr + errado)
            Return resp
        End If

        Return True
    End Function
    'Private Sub CargarAdicionales(ByVal QueCodigo As String)
    '    Dim Adi As New AdcAdicEmp(datosEmpresa.strConxAdcom)
    '    Dim i As Int32
    '    If mallaDatos.RowCount < 1 Then Return
    '    For i = 0 To mallaDatos.RowCount - 1
    '        If Not (mallaDatos.Rows(i).HeaderCell.Value Is Nothing) Then
    '            Adi = AdcAdicEmp.Buscar("codEmpleado ='" & QueCodigo & "' and nomadicional = '" & mallaDatos.Rows(i).HeaderCell.Value.ToString & "' ")
    '            If Not (Adi Is Nothing) Then mallaDatos.Rows(i).Cells(0).Value = Adi.ValorAdicional
    '        End If
    '    Next i
    'End Sub
    'Private Sub CargarConceptos(ByVal QueCodigo As String)
    '    Dim Adi As New AdcEmplCon(datosEmpresa.strConxAdcom)
    '    Dim retn As New EmpNomR.AdcNomb
    '    Dim i As Int32
    '    Try
    '        If IsDBNull(mallaConceptos.Rows(0).HeaderCell.Value) Then Return
    '        For i = 0 To mallaConceptos.RowCount - 1
    '            If Not IsDBNull(mallaConceptos.Rows(i).HeaderCell.Value) And Not IsNothing(mallaConceptos.Rows(i).HeaderCell.Value) Then
    '                Adi = AdcEmplCon.Buscar("idEmpleado ='" & QueCodigo & "' and idConcepto = " & retn.RetornaCodigoConceptoRol(mallaConceptos.Rows(i).HeaderCell.Value.ToString, datosEmpresa.strConxAdcom))
    '                If Not Adi Is Nothing Then
    '                    mallaConceptos.Rows(i).Cells(0).Value = "SI"
    '                Else
    '                    mallaConceptos.Rows(i).Cells(0).Value = "NO"
    '                End If
    '            End If
    '        Next i
    '    Catch
    '    End Try

    'End Sub

    'Private Sub GuardarAdicionales()
    '    Dim Adi As New AdcAdicEmp(datosEmpresa.strConxAdcom)
    '    Dim retn As New EmpNomR.AdcNomb
    '    Dim i As Int32
    '    For i = 0 To mallaDatos.RowCount - 1
    '        If Not (mallaDatos.Rows(i).HeaderCell.Value Is Nothing) Then
    '            Adi.CodEmpleado = QUECODIGO
    '            Adi.CodAdicional = retn.RetornaCodigoSyscod("adicionalEmpleado", mallaDatos.Rows(i).HeaderCell.Value.ToString, datosEmpresa.strConxSyscod)
    '            Adi.NomAdicional = mallaDatos.Rows(i).HeaderCell.Value.ToString
    '            Adi.ValorAdicional = mallaDatos.Rows(i).Cells(0).Value.ToString()
    '            Adi.Actualizar()
    '        End If
    '    Next i
    'End Sub

    'Private Sub GuardarConceptos()
    '    Dim Adi As New AdcEmplCon(datosEmpresa.strConxAdcom)
    '    Dim retn As New EmpNomR.AdcNomb
    '    Dim i As Int32
    '    Try
    '        For i = 0 To mallaConceptos.RowCount - 1
    '            If Not (mallaConceptos.Rows(i).HeaderCell.Value Is Nothing) Then
    '                Adi.idConcepto = CInt(retn.RetornaCodigoConceptoRol(mallaConceptos.Rows(i).HeaderCell.Value.ToString, datosEmpresa.strConxAdcom))
    '                Adi.IdEmpleado = Codigo.Text
    '                Adi.UsuarioAsigna = datosEmpresa.usr
    '                Adi.FechaAsignacion = Now
    '                If Not mallaConceptos.Rows(i).Cells(0).Value Is Nothing Then
    '                    If mallaConceptos.Rows(i).Cells(0).Value.ToString() = "SI" Then
    '                        Adi.Actualizar()
    '                    Else
    '                        Adi.Borrar()
    '                    End If
    '                End If
    '            End If
    '        Next i
    '    Catch EX As Exception
    '        MsgBox(EX.Message)
    '    End Try
    'End Sub

    'Private Sub hombre_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles hombre.CheckedChanged
    '    If sender.Checked Then
    '        If hombre.Checked = True Then
    '            Sexo = "H"
    '        Else
    '            hombre.Checked = False
    '            Sexo = "M"l
    '        End If
    '    End If
    'End Sub

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

    Private Sub nivelrol_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
        'Juridica.Checked = True
        'PonerDatosTipo()
        EsNuevo = 1
        PonerBotonesFormulario()
        accion = "guardar"
        ChequearAutorizacion("T")
        'btnCargarCapacitacion.Visible = False
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

    'Private Sub Proveedor_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    ' PonerDatosTipo()
    '    Try
    '        If Proveedor.Checked Then
    '            DatosDirectorio.TabPages.Item("tabProveedor").Enabled = True
    '            DatosDirectorio.TabPages.Item("tabProveedor").Visible = True
    '        Else : DatosDirectorio.TabPages.Item("tabProveedor").Enabled = False
    '            DatosDirectorio.TabPages.Item("tabProveedor").Visible = False
    '        End If
    '    Catch
    '    End Try
    'End Sub

    Private Sub DEEPPCTE_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Codigo.Text = "" Then EsNuevo = 0 : PonerBotonesFormulario()
        Mainn()
        Valores.iniciaValores(TipCodSyscod)
        '        If datosEmpresa.sistema <> "DAX" And datosEmpresa.sistema <> "ERP" Then btnCargarCapacitacion.Visible = False
        malla.Columns(0).Visible = False
        Operacion(0) = ""
        Operacion(1) = " CREANDO NUEVO REGISTRO "
        Operacion(2) = " MODIFICANDO REGISTRO EXISTENTE "

        'Juridica.Checked = True
        DatosDirectorio.SelectedIndex = 0
        'mallaDatos.ColumnCount = 1
        'mallaDatos.RowCount = 15
        'mallaDatos.RowHeadersWidth = 140
        'mallaDatos.Columns(0).ReadOnly = True
        'mallaDatos.Columns(0).Width = 130
        'mallaConceptos.ColumnCount = 1
        'mallaConceptos.RowCount = 15
        'mallaConceptos.RowHeadersWidth = 150
        'mallaConceptos.Columns(0).ReadOnly = True
        'mallaConceptos.Columns(0).Width = 30

        saltar = False
        'If Emp.rol = False Then
        '    TabDatosEmpleado.Visible = False
        'Else
        '    TabDatosEmpleado.Visible = True
        '    cargarMallaDatos()
        '    cargarMallaConceptos()
        '    cargarNombreGrupos()
        'End If
        PonerDatosTipo()
        ControlarAutorizaciones()
        cargarAutorizacionOpcion()
        LlenarCombos()
        If IniNvo Then CrearNuevo()
        If (datosEmpresa.Emp_PathImagenes.Length > 0) Then ImgDirectorio = datosEmpresa.Emp_PathImagenes + ImgDirectorio Else ImgDirectorio = ""

    End Sub

    Private Sub ControlarAutorizaciones()
        If (datosEmpresa.usr.ToUpper = "ADMINISTRADOR") Then Return
        Dim autorizaciones As New mntUsrs.autorizaUserDirectorio(datosEmpresa.usr, datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString())
        If (autorizaciones.autUsrIdentificacion.existe = False) Then Return
        If (autorizaciones.autUsrCliente.visible = False) Then tabCliente.Parent = Nothing
        'If (autorizaciones.autUsrAlias.visible = False) Then tabAlias.Parent = Nothing
        If (autorizaciones.autUsrContactos.visible = False) Then tabContactos.Parent = Nothing
        'If (autorizaciones.autUsrDatoPersonal.visible = False) Then tabDatosPer.Parent = Nothing
        'If (autorizaciones.autUsrEmpleado.visible = False) Then tabEmpleado.Parent = Nothing
        If (autorizaciones.autUsrFamiliares.visible = False) Then tabFamiliares.Parent = Nothing
        'If (autorizaciones.autUsrProveedor.visible = False) Then tabProveedor.Parent = Nothing

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
                '       leerContactos()
                leerFamiliares()
                EsNuevo = 2
            End If
            '  If Emp.rol = True Then CargarAdicionales(QUECODIGO) : CargarConceptos(QUECODIGO)
            PonerDatosTipo()
            CargaFoto()
            Cambio = False
            ''''''''''''''''''''''''''''''''''ChequearAutorizacion(Emp.)
            PonerBotonesFormulario()
            '  btnCargarCapacitacion.Visible = Emp.rol
        Catch ee As Exception
            MsgBox("excepción cargaDir: " & ee.Message)
        End Try
        CambioAdicionales = False
    End Sub

    'Private Sub Juridica_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Juridica.Checked Then
    '        Natural_CheckedChanged(Natural, New System.EventArgs())
    '    End If
    'End Sub

    Private Sub Natural_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If saltar Then Exit Sub
        'On Error Resume Next
        'If Juridica.Checked = True Then
        '    Banco.Enabled = True
        '    Empleado.Enabled = False
        '    tipoper = "J"
        '    asociadoa.Visible = False
        '    Asociacion.Text = "Asociación"
        '    Label34.Visible = False
        '    Apellidos.Visible = False
        '    Apellidos.Enabled = False
        '    Apellidos.Text = ""
        'Else
        'Banco.Enabled = False
        '    Empleado.Enabled = True
        Label34.Visible = True
        Apellidos.Visible = True
        Apellidos.Enabled = True
        tipoper = "N"
        'Natural.Checked = True
        'Asociacion.Text = "Asociado"
        'If Asociacion.CheckState = System.Windows.Forms.CheckState.Checked Then
        '    asociadoa.Visible = True
        'Else
        '    asociadoa.Visible = False
        'End If
        'End If
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
                foto.SizeMode = PictureBoxSizeMode.Zoom
            Else
                MsgBox("La Fotografía asignada a este contacto no existe " & vbCr & vbCr + ImgDirectorio + CodigoFoto, MsgBoxStyle.Information)
            End If
        End If
    End Sub

    'Private Sub Text1_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles Text1.KeyDown
    '    Dim KeyCode As Short = eventArgs.KeyCode
    '    Dim Shift As Short = eventArgs.KeyData \ &H10000
    '    Dim prog As New Busctactb.BuscaCta
    '    Dim Nombre As String = ""
    '    If KeyCode = System.Windows.Forms.Keys.F2 Then
    '        Text1.Text = prog.BuscaCtaCtb(Nombre, "S")
    '        prog = Nothing
    '        'Label4 = NombreCuentaContable(Text1)
    '    End If
    'End Sub
    Private Sub PonerBotonesFormulario()
        btnNuevo.Visible = (EsNuevo = 0)
        btnAbrir.Visible = (EsNuevo = 0)
        btnCerrar.Visible = (EsNuevo > 0)
        btnGuardar.Visible = ((EsNuevo = 2) Or (EsNuevo = 1))
        btnEliminar.Visible = ((EsNuevo = 2 Or EsNuevo = 1))
        Me.Text = "ADCOM - Mantenimiento DIRECTORIO GENERAL -  " & Operacion(EsNuevo)
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

    Private Sub TxtData2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNroDomicilio.KeyPress
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
        'LimpiarCheck()
        'limpiarGrid(Grid)
        '        limpiarGrid(MallaAlias)
        limpiarGrid(MallaCtco)
        limpiarGrid(malla)
        foto.Image = foto.InitialImage
        foto.SizeMode = PictureBoxSizeMode.CenterImage
        '       If Emp.rol = True Then limpiarGrid(mallaDatos) : cargarMallaDatos() : limpiarGrid(mallaConceptos) : cargarMallaConceptos()
        CambioAdicionales = False
    End Sub

    Private Sub Limpiar(ByVal oBJ As Form)
        Dim Control1 As System.Windows.Forms.Control
        Dim a As String
        For Each Control1 In oBJ.Controls
            If Control1.Controls.Count > 0 Then Limpiar(Control1)
            a = TypeName(Control1)
            If a = "TextBox" Then Control1.Text = ""
            If a = "Label" And Control1.BackColor = Drawing.Color.White Then Control1.Text = ""
            If a = "ComboBox" Then CType(Control1, ComboBox).SelectedValue = ""
            If a = "MaskedTextBox" Then Control1.Text = "  /  /"
            chkObligaContabilidad.Checked = False
            chkRegimenMicroempresas.Checked = False
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
            If a = "Label" And Control1.BackColor = Drawing.Color.White Then Control1.Text = ""
            If a = "ComboBox" Then CType(Control1, ComboBox).SelectedValue = ""
            If a = "MaskedTextBox" Then Control1.Text = "  /  /"
        Next
    End Sub

    'Private Sub LimpiarCheck()
    '    On Error Resume Next
    '    Cliente.Checked = False
    '    Proveedor.Checked = False
    '    EsVendedor.Checked = False
    '    Banco.Checked = False
    '    Empleado.Checked = False
    '    Directa.Checked = False
    '    Asociacion.Checked = False
    'End Sub
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
        'If Juridica.Checked Then Persona = "E"
        If j = "P" Then
            ValidaNumeroId = True
        ElseIf j = "F" And TxtCedulaRuc.Text = "9999999999999" Then
            ValidaNumeroId = True
        Else
            Dim prog As New valIdcedru.valcedruc()
            ValidaNumeroId = prog.valCr(TxtCedulaRuc.Text, j, Persona)
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

    'Private Sub CbuscaDir2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim dat(2) As String
    '    dat = CbuscaDir("F", 0)
    '    txtNomBanco.Text = dat(1)
    '    codigoDirectorio(2) = dat(0)
    'End Sub

    Private Sub CbuscaDir3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbuscaDir3.Click
        Dim dat(2) As String
        dat = CbuscaDir("F", 0)
        LDir3.Text = dat(1)
        codigoDirectorio(3) = dat(0)
    End Sub

    'Private Sub Cliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PonerDatosTipo()
    'End Sub

    'Private Sub Proveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PonerDatosTipo()
    'End Sub

    'Private Sub Banco_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PonerDatosTipo()
    'End Sub

    'Private Sub Empleado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PonerDatosTipo()
    'End Sub

    'Private Sub EsVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PonerDatosTipo()
    'End Sub

    'Private Sub Directa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PonerDatosTipo()
    'End Sub

    'Private Sub Asociacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PonerDatosTipo()
    'End Sub

    'Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
    '    CerrarRegistro()
    '    accion = ""
    'End Sub

#Region "Embarque"

    'Private Sub cargarGrid()
    '    With Grid
    '        .Columns.Add("CODIGO", "CODIGO")
    '        '.Columns(0).ReadOnly = True
    '        .Columns.Add("CONTACTO", "CONTACTO")
    '        llenarCombos("Embarque", "EMBARQUE", "TIPO EMBARQUE")
    '        llenarCombos("TipoTransporte", "EQUIPO", "EQUIPO")
    '        llenarCombos("Condiciones pago", "CONDICIONES", "CONDICIONES")
    '        llenarCombos("Terminos Venta", "TERMINOS", "TERMINOS")
    '        llenarCombos("Puertos", "PUERTOS", "PUERTOS")
    '        .Columns.Add("COSTOFLETE", "COSTO FLETE")
    '    End With
    'End Sub
    'Private Sub llenarCombos(ByVal referncia As String, ByVal NombreCol As String, ByVal TituloCol As String)
    '    Dim coneccion As New DaaxLib.DaxLibBases
    '    coneccion.TipoBase = "10"
    '    Dim cnnDaxSys As New SqlClient.SqlConnection()
    '    cnnDaxSys.ConnectionString = coneccion.StrDaxsys
    '    Dim ssql As String = "select Abreviación,Descripcion from syscod where tiporeferencia= '" & referncia & "' and Abreviación <>'#'"
    '    Dim dats As New DataSet()
    '    Dim datAd As New SqlDataAdapter(ssql, cnnDaxSys)
    '    If cnnDaxSys.State = ConnectionState.Open Then cnnDaxSys.Close()
    '    cnnDaxSys.Open()
    '    datAd.Fill(dats, "Datos")
    '    Dim column As New DataGridViewComboBoxColumn
    '    With column
    '        .Name = NombreCol
    '        .HeaderText = TituloCol
    '        .DataSource = dats.Tables("Datos")
    '        .DisplayMember = "Descripcion"
    '        .ValueMember = "Abreviación"
    '    End With
    '    Grid.Columns.Add(column)
    '    cnnDaxSys.Close()
    '    cnnDaxSys.Dispose()
    'End Sub

    'Private Sub guaradarEmbarque()
    '    EliminarEmbarque()
    '    Dim emb As New Embarque
    '    With Grid
    '        For i = 0 To .RowCount - 2
    '            emb.conectar = conectar
    '            emb.CODIGO = .Rows(i).Cells(0).Value
    '            emb.CLIENTE = Codigo.Text
    '            emb.PAÍS = Lcod12.Text
    '            emb.CONTACTO = .Rows(i).Cells(1).Value
    '            emb.EMBARQUE = .Rows(i).Cells(2).Value
    '            emb.EQUIPO = .Rows(i).Cells(3).Value
    '            emb.CONDICIONES = .Rows(i).Cells(4).Value
    '            emb.TERMINOS = .Rows(i).Cells(5).Value
    '            emb.PUERTO = .Rows(i).Cells(6).Value
    '            emb.COSTO_FLETE = .Rows(i).Cells(7).Value
    '            If Not emb.COSTO_FLETE > 0 Then emb.COSTO_FLETE = 0
    '            emb.Guardar()
    '        Next
    '    End With
    'End Sub
    'Private Sub EliminarEmbarque()
    '    Dim emb As New Embarque
    '    emb.conectar = conectar
    '    emb.Eliminar(Codigo.Text)
    'End Sub

    'Private Sub CargarEmbarque()
    '    Dim contador As Long = 0
    '    'Dim cod As String = codigoEmbarque(Codigo.Text)
    '    Dim ssql As String = "select * from embarque where cliente='" & Codigo.Text & "'"
    '    Dim cmd As New SqlCommand(ssql, conectar)
    '    Dim dat As SqlDataReader
    '    If conectar.State = ConnectionState.Open Then conectar.Close()
    '    conectar.Open()
    '    dat = cmd.ExecuteReader()
    '    With Grid
    '        While dat.Read
    '            .Rows.Add()
    '            If Not IsDBNull(dat(0)) Then .Rows(contador).Cells(0).Value = dat(0)
    '            If Not IsDBNull(dat(3)) Then .Rows(contador).Cells(1).Value = dat(3)
    '            If Not IsDBNull(dat(4)) Then .Rows(contador).Cells(2).Value = dat(4)
    '            If Not IsDBNull(dat(5)) Then .Rows(contador).Cells(3).Value = dat(5)
    '            If Not IsDBNull(dat(6)) Then .Rows(contador).Cells(4).Value = dat(6)
    '            If Not IsDBNull(dat(7)) Then .Rows(contador).Cells(5).Value = dat(7)
    '            If Not IsDBNull(dat(8)) Then .Rows(contador).Cells(6).Value = dat(8)
    '            If Not IsDBNull(dat(9)) Then .Rows(contador).Cells(7).Value = dat(9)
    '            contador += 1
    '        End While
    '    End With
    '    conectar.Close()
    'End Sub

    'Private Sub Grid_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    Dim fila As Integer = e.RowIndex
    '    With Grid
    '        If .RowCount > 2 Then
    '            If .Rows(fila).Cells(0).Value = Nothing Then .Rows(fila).Cells(0).Value = .Rows(fila - 1).Cells(0).Value + 1
    '        Else
    '            If .Rows(fila).Cells(0).Value = Nothing Then .Rows(fila).Cells(0).Value = "1"
    '        End If
    '    End With
    'End Sub

#End Region
    Private Sub Codigo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Codigo.Leave
        SaliendoCodigo()
    End Sub

    'Private Sub CbBuscador12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    CBuscador(txtProfesion, 15)
    'End Sub

    'Private Sub CbBuscador13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    CBuscador(txtEspecialidad, 16)
    'End Sub
    'Private Sub CbBuscador132_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    CBuscador(txtEspecialidad2, 16)
    'End Subselectedvalue

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
            txtHistoriaclinica.Text = TxtCedulaRuc.Text
            'ElseIf e.KeyCode = Keys.F3 And txtHistoriaclinica.Text > "" Then
            '   BuscarPorHistoriaClinica(txtHistoriaclinica.Text)
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
        '        Empleado.Visible = Autorizado
    End Sub

    'Private Sub CBuscador20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBuscador20.Click
    '    CBuscador(textNomCentroCosto, 20)
    'End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim prog As New ImpresionDocumentosDax.ImprimeConsulta("&DaxDirdir '" & Codigo.Text & "'", "0", "HojDir")
        'Dim pasar As String = datosEmpresa.sistema & "," & "" & "," & "" & "," & "" & "," & ""
        'prog.ImprimeConsulta("&DaxDirdir '" & Codigo.Text & "' ", 0, "HojDir")
        prog.ShowDialog()
    End Sub

    'Private Sub CBuscador21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBuscador21.Click
    '    CBuscador(textNomSeccion, 21)
    'End Sub

    'Private Sub CBuscador22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBuscador22.Click
    '    CBuscador(textNomModulo, 22)
    'End Sub

    'Private Sub ComCargarCapacitacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim prog As New frmCapacitacion
    '    prog.NombreEmpleado = impresion.Text
    '    prog.CodigoEmpleado = Codigo.Text
    '    prog.ShowDialog()
    'End Sub

    'Private Sub mallaDatos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    Dim codigo As String = ""
    '    Dim Descripción As String = ""
    '    Select Case e.KeyCode
    '        Case Keys.F2
    '            If mallaDatos.CurrentRow.HeaderCell.Value Is Nothing Then Exit Sub
    '            Dim nombreAdicional As String = mallaDatos.CurrentRow.HeaderCell.Value.ToString
    '            If Len(nombreAdicional) = 0 Then Exit Sub
    '            If mallaDatos.CurrentCell.ColumnIndex = 0 Then
    '                Dim progg As New Syscod.ManSysnetClass
    '                progg.BuscarReferencia(nombreAdicional, codigo, Descripción)
    '                mallaDatos.CurrentCell.Value = Descripción
    '                progg = Nothing
    '            End If
    '        Case Keys.F3
    '            Dim progg As New Syscod.ManSysnetClass
    '            progg.ManSyscodd("adicionalEmpleado")
    '            cargarMallaDatos()
    '            progg = Nothing
    '    End Select
    'End Sub

    'Private Sub cargarMallaDatos()
    '    Dim conn As New SqlClient.SqlConnection(datosEmpresa.strConxSyscod)
    '    conn.Open()
    '    Dim ssql As String = "select * from syscod where tiporeferencia = 'adicionalEmpleado' and Abreviación <> '#' "
    '    Dim dt As New DataTable("datos")
    '    Dim rr As New SqlClient.SqlDataAdapter(ssql, conn)
    '    rr.Fill(dt)
    '    With mallaDatos
    '        mallaDatos.Rows.Clear()
    '        Dim i As Int32 = 0
    '        Dim ro As DataRow
    '        For Each ro In dt.Rows
    '            mallaDatos.Rows.Add()
    '            .Rows(i).Cells(0).Value = ""
    '            .Rows(i).HeaderCell.Value = ro("Descripcion").ToString
    '            i = i + 1
    '        Next
    '    End With
    '    If mallaDatos.RowCount < 2 Then mallaDatos.RowCount = 2
    '    conn.Close()
    '    dt.Dispose()
    '    rr.Dispose()
    'End Sub

    'Private Sub cargarMallaConceptos()
    '    Dim conn As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
    '    conn.Open()
    '    Dim ssql As String = "select CON_TIPO,Con_Descripcion from defcon where isnull(con_conceptoporempleado,'T') ='E' "
    '    Dim dt As New DataTable("conceptos")
    '    Dim rr As New SqlClient.SqlDataAdapter(ssql, conn)
    '    rr.Fill(dt)
    '    With mallaConceptos
    '        .Rows.Clear()
    '        Dim i As Int32 = 0
    '        Dim ro As DataRow
    '        For Each ro In dt.Rows
    '            .Rows.Add()
    '            '.Rows(i).Cells(0).Value = 0
    '            .Rows(i).HeaderCell.Value = ro("Con_descripcion").ToString
    '            i = i + 1
    '        Next
    '    End With
    '    If mallaConceptos.RowCount < 2 Then mallaConceptos.RowCount = 2
    '    conn.Close()
    '    dt.Dispose()
    '    rr.Dispose()
    'End Sub

    'Private Sub Label68_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim progg As New Syscod.ManSysnetClass
    '    progg.ManSyscodd("nomGrupoRol")
    '    cargarNombreGrupos()
    'End Sub

    'Private Sub cargarNombreGrupos()
    '    Dim conn As New SqlClient.SqlConnection(datosEmpresa.strConxSyscod)
    '    conn.Open()
    '    Dim ssql As String = "select Abreviación, Descripcion from syscod where tiporeferencia = 'nomGrupoRol' and Abreviación <> '#' "
    '    Dim dt As New DataTable("datos")
    '    Dim rr As New SqlClient.SqlDataAdapter(ssql, conn)
    '    rr.Fill(dt)
    '    With mallaDatos
    '        Dim ro As DataRow
    '        For Each ro In dt.Rows
    '            If ro("Abreviación").ToString = "Grupo-1" Then Label68.Text = ro("Descripcion").ToString
    '            If ro("Abreviación").ToString = "Grupo-2" Then Label69.Text = ro("Descripcion").ToString
    '            If ro("Abreviación").ToString = "Grupo-3" Then Label70.Text = ro("Descripcion").ToString
    '            If ro("Abreviación").ToString = "Grupo-4" Then Label71.Text = ro("Descripcion").ToString
    '            If ro("Abreviación").ToString = "Grupo-5" Then Label72.Text = ro("Descripcion").ToString
    '            If ro("Abreviación").ToString = "Grupo-6" Then Label73.Text = ro("Descripcion").ToString
    '        Next
    '    End With
    '    conn.Close()
    '    dt.Dispose()
    '    rr.Dispose()
    'End Sub

    'Private Sub Grupo1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.F2 Then
    '        CBuscadorGrupo(Grupo1, Label68.Text)
    '    End If

    'End Sub

    'Private Sub CBuscadorGrupo(ByVal lcod As TextBox, ByVal grupo As String)
    '    Dim ElNombre As String = ""
    '    Dim ElCodigo As String = ""
    '    Dim Buscod As New Syscod.ManSysnetClass
    '    lcod.Text = Buscod.BuscarReferencia(grupo, ElCodigo, ElNombre)
    '    Buscod = Nothing
    'End Sub

    'Private Sub mallaConceptos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    Dim codigo As String = ""
    '    Dim Descripción As String = ""
    '    With mallaConceptos
    '        Select Case e.KeyCode
    '            Case Keys.F2
    '                If .CurrentRow.HeaderCell.Value Is Nothing Then Exit Sub
    '                Dim nombreConcepto As String = .CurrentRow.HeaderCell.Value.ToString
    '                If Len(nombreConcepto) = 0 Then Exit Sub
    '                If .CurrentCell.ColumnIndex = 0 Then
    '                    If .CurrentCell.Value Is Nothing Then
    '                        .CurrentCell.Value = "SI"
    '                    ElseIf .CurrentCell.Value.ToString() = "SI" Then
    '                        .CurrentCell.Value = "NO"
    '                    Else
    '                        .CurrentCell.Value = "SI"
    '                    End If
    '                End If
    '        End Select
    '    End With
    'End Sub

    Private Sub malla_UserAddedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles malla.UserAddedRow
        On Error Resume Next
        For i As Int32 = 0 To malla.RowCount - 2
            malla.Rows(i).HeaderCell.Value = (i + 1).ToString
        Next
    End Sub

    Private Sub mallaDatos_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        CambioAdicionales = True
    End Sub

    'Private Sub Grupo2_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.F2 Then
    '        CBuscadorGrupo(Grupo2, Label69.Text)
    '    End If
    'End Sub

    'Private Sub Grupo3_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.F2 Then
    '        CBuscadorGrupo(Grupo3, Label70.Text)
    '    End If
    'End Sub
    'Private Sub Grupo4_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.F2 Then
    '        CBuscadorGrupo(Grupo4, Label71.Text)
    '    End If
    'End Sub
    'Private Sub Grupo5_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.F2 Then
    '        CBuscadorGrupo(Grupo5, Label72.Text)
    '    End If
    'End Sub
    'Private Sub Grupo6_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.F2 Then
    '        CBuscadorGrupo(Grupo6, Label73.Text)
    '    End If
    'End Sub


    'Private Sub Button5_Click(sender As System.Object, e As System.EventArgs)
    '    CBuscador(txtNomParroquia, 24)
    'End Sub

    'Private Sub BtnCanton_Click(sender As System.Object, e As System.EventArgs)
    '    CBuscador(TxtNomCanton, 23)
    'End Sub

    Private Sub DEEPPCTE_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F2 And e.Alt = True And Codigo.Text.Length > 0 Then
            Try
                Dim prog As New daxNota.ClassNota
                prog.verNotaReferencia("DIR", Codigo.Text, datosEmpresa.usr, datosEmpresa.strConxAdcom)
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
    'Private Sub btnPaisNace_Click(sender As Object, e As EventArgs)
    '    CBuscador(txtPaisNace, 12)
    'End Sub

    'Private Sub btnProvNace_Click(sender As Object, e As EventArgs)
    '    CBuscador(txtProvNace, 13)
    'End Sub

    'Private Sub btnCiudadNace_Click(sender As Object, e As EventArgs)
    '    CBuscador(TxtCiudadNace, 14)
    'End Sub

    'Private Sub btnRegionNace_Click(sender As Object, e As EventArgs)
    '    CBuscador(TxtRegionNace, 25)
    'End Sub

    'Private Sub btnRegion_Click(sender As Object, e As EventArgs)
    '    CBuscador(txtRegion, 25)
    'End Sub

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

    'Private Sub Button6_Click(sender As Object, e As EventArgs)
    '    CBuscador(observacionesprv, 27)
    'End Sub

    'Private Sub Button7_Click(sender As Object, e As EventArgs)
    '    Dim progRet As New DaxNomReten.frmRetencion(Codigo.Text, impresion.Text)
    '    progRet.ShowDialog()
    '    progRet.Dispose()
    'End Sub

    'Private Sub GroupBox13_Enter(sender As Object, e As EventArgs) Handles GroupBox13.Enter

    'End Sub

    'Private Sub GroupBox11_Enter(sender As Object, e As EventArgs) Handles GroupBox11.Enter

    'End Sub

    Private Sub cmbPaisDomicilio_Leave(sender As Object, e As EventArgs) Handles cmbPaisDomicilio.Leave, cmbRegionDomicilio.Leave, cmbProvinciaDomicilio.Leave, cmbParroquiaDomicilio.Leave, cmbCiudadDomicilio.Leave, cmbCantonDomicilio.Leave, txtReferirseComo.Leave, cmbTipoSangre.Leave, cmbRegionNace.Leave, cmbProvinciaNace.Leave, cmbProfesion.Leave, cmbPaisNace.Leave, cmbNacionalidadPersonal.Leave, cmbEstadoCivil.Leave, cmbEspecialidad2.Leave, cmbEspecialidad.Leave, cmbCiudadNace.Leave
        Dim cmb As ComboBox = CType(sender, ComboBox)
        If IsNothing(cmb.SelectedValue) Then cmb.Text = ""
    End Sub

    Private Sub tabIdentificación_Click(sender As Object, e As EventArgs) Handles tabIdentificación.Click

    End Sub
End Class
