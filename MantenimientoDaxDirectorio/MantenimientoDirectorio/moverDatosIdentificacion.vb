Imports System.Windows.Forms
Imports DattCom
Public Class moverDatosIdentificacion
    Public Sub movDatIdentificacion(frmId As DEEP01, recide As Identificacion, Lcodir() As String)
        Dim buscod As New EmpNomR.AdcNomb()
        With recide
            .RegistroMunicp = ""
            .TipoPersona = frmId.tipoper
            If (.TipoPersona <> "J") Then .TipoPersona = "N"
            .TipoIdentificacion = TipoIdGenerall(CStr(frmId.TipoIdent.SelectedIndex))
            .Telefono1 = frmId.txtTelefono1.Text
            .Telefono2 = frmId.txtTelefono2.Text
            .Telefono3 = frmId.txtTelefono3.Text
            .NroCtrbuyteEspecial = frmId.txtContribuyenteEspecial.Text
            .ObligLlevarConta = frmId.chkObligaContabilidad.Checked
            .RegimenMicroempresas = frmId.chkRegimenMicroempresas.Checked

            .NroAcdoAgntRetencion = frmId.TxtResolucionAR.Text

            .Codigo = frmId.Codigo.Text
            .Apellidos = frmId.Apellidos.Text
            .CedulaIdentidadRuc = frmId.TxtCedulaRuc.Text
            .CodGrabo = datosEmpresa.usr
            .CodAsociacion = Lcodir(3)
            .ComisionVenta = 0
            .CtaCobrarComisiones = ""
            .CorreoElectrónico = frmId.TxtData8.Text
            .Domicilio = frmId.txtnomDireccion.Text
            .EsCliente = frmId.Cliente.Checked
            .EsProveedor = frmId.Proveedor.Checked
            .EsEmpleado = frmId.Empleado.Checked
            .EsBanco = frmId.Banco.Checked
            .EsVendedor = frmId.EsVendedor.Checked
            .EsAsociado = frmId.Asociacion.Checked
            If frmId.Directa.Checked Then .EsDirecta = "SI" Else .EsDirecta = "NO"
            .esRise = frmId.chkRise.Checked
            .ExoneradoIva = frmId.ExoneradoIva.Checked
            .FichaDental = ""
            .Grupo1 = frmId.txtGrupo1.Text
            .Grupo2 = frmId.txtGrupo2.Text
            .Grupo3 = frmId.txtGrupo3.Text
            .HistoriaClinica = frmId.txtHistoriaclinica.Text
            .Logotipo = frmId.CodigoFoto
            .NombreImpresion = frmId.impresion.Text
            .Nombres = frmId.TxtNombres.Text
            .NúmeroFax = frmId.TxtData6.Text
            .NumeroDomicilio = frmId.TxtNroDomicilio.Text
            .Paginaweb = frmId.TxtData9.Text

            If IsNothing(frmId.cmbPaisDomicilio.SelectedValue) = False Then .País = frmId.cmbPaisDomicilio.SelectedValue.ToString() 'buscod.RetornaCodigoSyscod("Paises", frmId.txtNomPais.Text, datosEmpresa.strConxSyscod)
            If IsNothing(frmId.cmbProvinciaDomicilio.SelectedValue) = False Then .Provincia = frmId.cmbProvinciaDomicilio.SelectedValue.ToString()  ' //; buscod.RetornaCodigoSyscod("Provincias", frmId.cmbProvinciaDomicilio.Text, datosEmpresa.strConxSyscod)
            If IsNothing(frmId.cmbCantonDomicilio.SelectedValue) = False Then .Sector = frmId.cmbCantonDomicilio.SelectedValue.ToString() ' buscod.RetornaCodigoSyscod("Cantones", frmId.cmbCantonDomicilio.Text, datosEmpresa.strConxSyscod)
            If IsNothing(frmId.cmbParroquiaDomicilio.SelectedValue) = False Then .Casilla = frmId.cmbParroquiaDomicilio.SelectedValue.ToString() '; buscod.RetornaCodigoSyscod("Parroquias", frmId.cmbParroquiaDomicilio.Text, datosEmpresa.strConxSyscod)
            If IsNothing(frmId.cmbCiudadDomicilio.SelectedValue) = False Then .Ciudad = frmId.cmbCiudadDomicilio.SelectedValue.ToString()  ' buscod.RetornaCodigoSyscod("Ciudades", frmId.cmbCiudadDomicilio.Text, datosEmpresa.strConxSyscod)

            .regionDomicilio = frmId.cmbRegionDomicilio.Text
            .SectorDomicilio = frmId.txtSector.Text

        End With
    End Sub
    Public Sub movDatIdentificacion(frmId As DEEPPCTE, recide As Identificacion, Lcodir() As String)
        Dim buscod As New EmpNomR.AdcNomb()
        With recide
            .Codigo = frmId.Codigo.Text
            .Apellidos = frmId.Apellidos.Text
            .CedulaIdentidadRuc = frmId.TxtCedulaRuc.Text
            .CodGrabo = datosEmpresa.usr
            .CodAsociacion = Lcodir(3)
            .ComisionVenta = 0
            .CtaCobrarComisiones = ""
            .CorreoElectrónico = frmId.TxtData8.Text
            .Domicilio = frmId.txtnomDireccion.Text
            .EsCliente = False
            .EsProveedor = False
            .EsEmpleado = False
            .EsBanco = False
            .EsVendedor = False
            .EsAsociado = False
            'If frmId.Directa.Checked Then .EsDirecta = "SI" Else .EsDirecta = "NO"
            .esRise = frmId.chkRise.Checked
            .ExoneradoIva = frmId.ExoneradoIva.Checked
            .FichaDental = ""
            .Grupo1 = frmId.txtGrupo1.Text
            .Grupo2 = frmId.txtGrupo2.Text
            .Grupo3 = frmId.txtGrupo3.Text
            .HistoriaClinica = frmId.txtHistoriaclinica.Text
            .Logotipo = frmId.CodigoFoto
            .NombreImpresion = frmId.impresion.Text
            .Nombres = frmId.TxtNombres.Text
            .NúmeroFax = frmId.TxtData6.Text
            .NumeroDomicilio = frmId.TxtNroDomicilio.Text
            .Paginaweb = frmId.TxtData9.Text

            .País = frmId.cmbPaisDomicilio.SelectedValue.ToString() 'buscod.RetornaCodigoSyscod("Paises", frmId.txtNomPais.Text, datosEmpresa.strConxSyscod)
            .Provincia = frmId.cmbProvinciaDomicilio.SelectedValue.ToString() 'buscod.RetornaCodigoSyscod("Provincias", frmId.cmbProvinciaDomicilio.Text, datosEmpresa.strConxSyscod)
            .Sector = frmId.cmbCantonDomicilio.SelectedValue.ToString() ' buscod.RetornaCodigoSyscod("Cantones", frmId.cmbCantonDomicilio.Text, datosEmpresa.strConxSyscod)
            .Casilla = frmId.cmbParroquiaDomicilio.SelectedValue.ToString() '; buscod.RetornaCodigoSyscod("Parroquias", frmId.cmbParroquiaDomicilio.Text, datosEmpresa.strConxSyscod)
            .Ciudad = frmId.cmbCiudadDomicilio.SelectedValue.ToString() '  buscod.RetornaCodigoSyscod("Ciudades", frmId.cmbCiudadDomicilio.Text, datosEmpresa.strConxSyscod)
            .regionDomicilio = frmId.cmbRegionDomicilio.Text


            .RegistroMunicp = ""
            .TipoPersona = frmId.tipoper
            .TipoIdentificacion = TipoIdGenerall(CStr(frmId.TipoIdent.SelectedIndex))
            .Telefono1 = frmId.txtTelefono1.Text
            .Telefono2 = frmId.txtTelefono2.Text
            .Telefono3 = frmId.txtTelefono3.Text
            .NroCtrbuyteEspecial = frmId.txtContribuyenteEspecial.Text
            .ObligLlevarConta = frmId.chkObligaContabilidad.Checked
            .RegimenMicroempresas = frmId.chkRegimenMicroempresas.Checked

            .SectorDomicilio = frmId.txtSector.Text
            .NroAcdoAgntRetencion = frmId.TxtResolucionAR.Text
        End With
    End Sub
    Public Sub movDatIdentificacionCli(frmId As DEEPCLI, recide As Identificacion, Lcodir() As String)
        Dim buscod As New EmpNomR.AdcNomb()
        With recide
            .Codigo = frmId.Codigo.Text
            .Apellidos = frmId.Apellidos.Text
            .Casilla = buscod.RetornaCodigoSyscod("Parroquias", frmId.txtNomParroquia.Text, datosEmpresa.strConxSyscod)
            .CedulaIdentidadRuc = frmId.Datox0.Text
            .Ciudad = buscod.RetornaCodigoSyscod("Ciudades", frmId.txtNomCiudad.Text, datosEmpresa.strConxSyscod)
            .CodGrabo = datosEmpresa.usr
            .CodAsociacion = Lcodir(3)
            '.ComisionVenta = 0
            '.CtaCobrarComisiones = ""
            .CorreoElectrónico = frmId.TxtData8.Text
            .Domicilio = frmId.txtnomDireccion.Text
            .EsCliente = True
            '.EsProveedor = False
            '.EsEmpleado = False
            '.EsBanco = frmId.Banco.Checked
            '.EsVendedor = frmId.EsVendedor.Checked
            '.EsAsociado = frmId.Asociacion.Checked
            'If frmId.Directa.Checked Then .EsDirecta = "SI" Else .EsDirecta = "NO"
            .esRise = frmId.chkRise.Checked
            .ExoneradoIva = frmId.ExoneradoIva.Checked
            '.FichaDental = ""
            .Grupo1 = frmId.txtGrupo1.Text
            .Grupo2 = frmId.txtGrupo2.Text
            .Grupo3 = frmId.txtGrupo3.Text
            .HistoriaClinica = frmId.txtHistoriaclinica.Text
            .Logotipo = frmId.CodigoFoto
            .NombreImpresion = frmId.impresion.Text
            .Nombres = frmId.Datox1.Text
            .NúmeroFax = frmId.TxtData6.Text
            .NumeroDomicilio = frmId.TxtData2.Text
            .Paginaweb = frmId.TxtData9.Text
            .País = buscod.RetornaCodigoSyscod("Paises", frmId.txtNomPais.Text, datosEmpresa.strConxSyscod)
            .Provincia = buscod.RetornaCodigoSyscod("Provincias", frmId.txtNomProvincia.Text, datosEmpresa.strConxSyscod)
            '.RegistroMunicp = ""
            .Sector = buscod.RetornaCodigoSyscod("Cantones", frmId.TxtNomCanton.Text, datosEmpresa.strConxSyscod)
            .TipoPersona = frmId.tipoper
            .TipoIdentificacion = TipoIdGenerall(CStr(frmId.TipoIdent.SelectedIndex))
            .Telefono1 = frmId.txtTelefono1.Text
            .Telefono2 = frmId.txtTelefono2.Text
            .Telefono3 = frmId.txtTelefono3.Text
            .NroCtrbuyteEspecial = frmId.txtContribuyenteEspecial.Text
            .ObligLlevarConta = frmId.chkObligaContabilidad.Checked
            .regionDomicilio = frmId.txtRegion.Text
            .SectorDomicilio = frmId.txtSector.Text
        End With
    End Sub

    Public Sub movControlADatIdentificacion(frmId As DEEP01, recide As Identificacion, Lcodir() As String)
        Dim buscod As New EmpNomR.AdcNomb()
        With recide
            frmId.Codigo.Text = .Codigo
            frmId.Apellidos.Text = .Apellidos
            frmId.cmbParroquiaDomicilio.Text = buscod.RetornaNombreSyscod("Parroquias", .Casilla, datosEmpresa.strConxSyscod)
            frmId.TxtCedulaRuc.Text = .CedulaIdentidadRuc
            frmId.cmbCiudadDomicilio.Text = buscod.RetornaNombreSyscod("Ciudades", .Ciudad, datosEmpresa.strConxSyscod)
            '.CodGrabo = datosEmpresa.usr
            Lcodir(3) = .CodAsociacion
            '.ComisionVenta = 0
            '.CtaCobrarComisiones = ""
            frmId.TxtData8.Text = .CorreoElectrónico
            frmId.txtnomDireccion.Text = .Domicilio
            frmId.Cliente.Checked = .EsCliente
            frmId.Proveedor.Checked = .EsProveedor
            frmId.Empleado.Checked = .EsEmpleado
            frmId.Banco.Checked = .EsBanco
            frmId.EsVendedor.Checked = .EsVendedor
            frmId.Asociacion.Checked = .EsAsociado
            If .EsDirecta = "SI" Then frmId.Directa.Checked = True Else frmId.Directa.Checked = False
            frmId.chkRise.Checked = .esRise
            frmId.ExoneradoIva.Checked = .ExoneradoIva
            ' .FichaDental = ""
            frmId.txtGrupo1.Text = .Grupo1
            frmId.txtGrupo2.Text = .Grupo2
            frmId.txtGrupo3.Text = .Grupo3
            frmId.txtHistoriaclinica.Text = .HistoriaClinica
            frmId.CodigoFoto = .Logotipo
            frmId.impresion.Text = .NombreImpresion
            frmId.TxtNombres.Text = .Nombres
            frmId.TxtData6.Text = .NúmeroFax
            frmId.TxtNroDomicilio.Text = .NumeroDomicilio
            frmId.TxtData9.Text = .Paginaweb
            frmId.cmbPaisDomicilio.Text = buscod.RetornaNombreSyscod("Paises", .País, datosEmpresa.strConxSyscod)
            frmId.cmbProvinciaDomicilio.Text = buscod.RetornaNombreSyscod("Provincias", .Provincia, datosEmpresa.strConxSyscod)
            '.RegistroMunicp = ""
            frmId.cmbCantonDomicilio.Text = buscod.RetornaNombreSyscod("Cantones", .Sector, datosEmpresa.strConxSyscod)
            frmId.tipoper = .TipoPersona
            frmId.TipoIdent.SelectedIndex = CInt(TipoIdGenerall(.TipoIdentificacion))
            frmId.txtTelefono1.Text = .Telefono1
            frmId.txtTelefono2.Text = .Telefono2
            frmId.txtTelefono3.Text = .Telefono3
            frmId.txtContribuyenteEspecial.Text = .NroCtrbuyteEspecial
            frmId.chkObligaContabilidad.Checked = .ObligLlevarConta
            frmId.cmbRegionDomicilio.Text = .regionDomicilio
            frmId.txtSector.Text = .SectorDomicilio
            frmId.TxtResolucionAR.Text = .NroAcdoAgntRetencion

        End With
    End Sub
    Private Function TipoIdGenerall(ByVal Ident As String) As String

        Select Case Ident
            Case "O", "0"
                Return "O"
            Case "R", "1"
                Return "R"
            Case "C", "2"
                Return "C"
            Case "P", "3"
                Return "P"
            Case "F", "4"
                Return "F"
        End Select
        Return "O"
    End Function

End Class
