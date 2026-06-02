Imports System.Data.SqlClient
Imports DattCom
Public Class frmEmp
    Dim empcod As String = CStr(datosEmpresa.Emp_codigo)
    Dim codPais As String = ""
    Dim codProv As String = ""
    Dim codCan As String = ""
    Dim codCiu As String = ""
    Dim accion As String = "G" 'G--> Guardar / M-->Modificar
    Dim cambios As Integer = 0

#Region "DatosIniciales"
    Private Sub frmEmp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim opcion As String
        'conectarBDD()
        Combos()
        CargarIdentific(empcod)
        CargarBddActual()
        bloquear(True)
        btnEmp.Select()
        btnIdentificacion_Click(sender, e)
        opcion = Command()
    End Sub
    Private Sub bloquear(ByVal op As Boolean)
        btnNuevo.Enabled = op
        btnSalir.Enabled = op
        btnEmp.Enabled = op
        btnEliminar.Enabled = op
        btnNuevo.Enabled = op
        btnModificar.Enabled = op
        btnSuc.Enabled = op
        btnParam.Enabled = op

        btnGuardar.Enabled = Not op
        btnCancelar.Enabled = Not op
        txtEmp.ReadOnly = op
        chkEmpDef.Enabled = Not op
        pnlIdentificacion.Enabled = Not op
    End Sub
    Private Sub btnEmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmp.Click
        empcod = Busca("Select emp_codigo as Codigo_Empresa, emp_nombre as Nombre_Empresa from emp_datos where emp_codigo >0", "emp_codigo", "emp_nombre", "LISTA DE EMPRESA")
        If empcod <> "" Then CargarIdentific(empcod) : cargarBdd(empcod)
    End Sub
    Private Sub imgEmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgEmp.Click
        If accion = "G" Then MsgBox("No puede Escoger una imagen antes de crear la empresa", MsgBoxStyle.Information) : Exit Sub
        Dim miStream As IO.Stream = Nothing
        Dim Archivo As String = ""
        Dim Path As String = ""
        OpenFileDialog1.Filter = "JPG(*.jpg)|*.jpg|PNG(*.png)|*.png|GIF(*.gif)|*.gif|Todos(*.Jpg, *.Png, *.Gif, *.Tiff, *.Jpeg, *.Bmp)|*.Jpg; *.Png; *.Gif; *.Tiff; *.Jpeg; *.Bmp"
        OpenFileDialog1.FilterIndex = 4
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            miStream = OpenFileDialog1.OpenFile()
            If (miStream IsNot Nothing) Then
                Archivo = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
                Path = System.IO.Path.GetDirectoryName(OpenFileDialog1.FileName)
                lblpathIma.Text = Path & "\" & Archivo
                imgEmp.Load(Path & "\" & Archivo)
            End If
        End If
    End Sub
    Private Sub Combos()
        cargarCombos(cboAdcom)
        cargarCombos(cboRolP)
        cargarCombos(cboIvar)
        cargarCombos(cboDaxp)
    End Sub
    Private Sub cargarCombos(ByVal cbo As ComboBox)
        Dim ssql As String = "SELECT Name FROM sys.databases order by Name"
        'Dim datS As New DataSet()
        'Dim datA As New SqlDataAdapter(ssql, ConSys)
        'ConSys.Open()
        'datA.Fill(datS, "Datos")
        cbo.DataSource = SqlDatos.leerTablaIniSis(ssql)
        cbo.DisplayMember = "Name"
        cbo.ValueMember = "Name"
        'ConSys.Close()
    End Sub
#End Region

#Region "Identificacion"
    Private Sub btnIdentificacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIdentificacion.Click
        btnIdentificacion.Checked = True
        pnlIdentificacion.Visible = True
        btnBaseD.Checked = False
        pnlBdd.Visible = False
    End Sub
    Private Sub CargarIdentific(ByVal codEmp As String)
        Dim empD As New Emp_datos
        empD.Consultar(codEmp)
        txtEmp.Text = empD.Emp_Nombre
        chkEmpDef.Checked = empD.Emp_Defecto
        txtRuc.Text = empD.Emp_RUC
        txtSegSoc.Text = empD.Emp_SegSocial
        txtPais.Text = empD.Emp_Pais
        txtProv.Text = empD.Emp_Provincia
        txtCanton.Text = empD.Emp_Cantón
        txtCiudad.Text = empD.Emp_Ciudad
        txtDomicilio.Text = empD.Emp_Dirección
        'txtFax.Text = empD.Emp_Fax
        'txtCasilla.Text = empD.Emp_Casilla
        txtTelf1.Text = empD.Emp_Telefono_1
        txtTelf2.Text = empD.Emp_Telefono_2
        txtCorreo.Text = empD.Emp_Email
        txtPresCod.Text = empD.Emp_Presidente
        lblPresNom.Text = retornaNomb(txtPresCod.Text)
        txtRepLCod.Text = empD.Emp_RepLegal
        lblRepLNom.Text = retornaNomb(txtRepLCod.Text)
        txtGerent.Text = empD.Emp_Gerente
        lblGerentNom.Text = retornaNomb(txtGerent.Text)
        txtContCod.Text = empD.Emp_Contador
        lblContNom.Text = retornaNomb(txtContCod.Text)
        chkEmpConta.Checked = empD.Emp_Conta
        txtAgeRet.Text = empD.Emp_AgeRet
        txtContrBuyEsp.Text = empD.Emp_ContrBuyEsp
        cboRegimen.Text = empD.Emp_Regimen

    End Sub

    Private Sub btnPais_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPais.Click
        txtPais.Text = buskRef("Paises")
    End Sub
    Private Sub btnProv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProv.Click
        txtProv.Text = buskRef("Provincias")
    End Sub

    Private Sub btnCanton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCanton.Click
        txtCanton.Text = buskRef("Cantones")
    End Sub

    Private Sub btnCiudad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCiudad.Click
        txtCiudad.Text = buskRef("Ciudades")
    End Sub
    Private Function buskRef(ByVal ref As String) As String
        Dim codigo As String = ""
        Dim nom As String = ""
        Dim bus As New Syscod.ManSysnetClass
        codigo = bus.BuscarReferencia(ref, codigo, nom)
        Return nom
    End Function
    Private Sub btnPres_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPres.Click
        lblPresNom.Text = buskDir(txtPresCod)
    End Sub

    Private Sub btnRepL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRepL.Click
        lblRepLNom.Text = buskDir(txtRepLCod)
    End Sub

    Private Sub btnGerent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGerent.Click
        lblGerentNom.Text = buskDir(txtGerent)
    End Sub

    Private Sub btnCont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCont.Click
        lblContNom.Text = buskDir(txtContCod)
    End Sub
    Private Function buskDir(ByVal txt As TextBox) As String
        Dim busk As New directMnt.BusDirectorio
        Dim codigo As String = ""
        Dim nombre As String = ""
        Dim cedula As String = ""
        Dim nombrealias As String = ""
        txt.Text = busk.BusDirect(codigo, cedula, nombre, nombrealias, "T", "", "")
        Return nombre
    End Function
    Private Sub txtRuc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtSegSoc.Text = txtRuc.Text
    End Sub
#End Region

#Region "BaseDatos"
    Private Sub btnBaseD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBaseD.Click
        btnIdentificacion.Checked = False
        btnBaseD.Checked = True
        pnlBdd.Visible = True
    End Sub
    Private Sub CargarBddActual()
        txtservidor.Text = datosEmpresa.Servidor
        txtUrs.Text = datosEmpresa.usr
        txtPass.Text = datosEmpresa.ClaveBd
        cboAdcom.SelectedValue = datosEmpresa.nombreBaseAdcom
        cboRolP.SelectedValue = datosEmpresa.nombreBaseAdcom
        cboIvar.SelectedValue = datosEmpresa.nombreBaseIvaret
        cboDaxp.SelectedValue = datosEmpresa.nombreBaseDaxpro
    End Sub
    Private Sub cargarBdd(ByVal cod As String)
        Dim d As New emp_Arch
        cboAdcom.SelectedValue = d.Consultar(cod, "ADC")
        cboDaxp.SelectedValue = d.Consultar(cod, "PRO")
        cboIvar.SelectedValue = d.Consultar(cod, "SRI")
        cboRolP.SelectedValue = d.Consultar(cod, "ROL")
    End Sub
    Private Sub btnProbarCon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProbarCon.Click
        'ConSys.Open()
        MsgBox("Conexión esxitosa con el servidor " & txtservidor.Text, MsgBoxStyle.Information)
        'ConSys.Close()
    End Sub
#End Region

#Region "Cambios"
    Private Sub txtEmp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmp.TextChanged
        cambios += 1
    End Sub

    Private Sub txtRuc_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtRuc.MaskInputRejected
        cambios += 1
    End Sub

    Private Sub txtSegSoc_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtSegSoc.MaskInputRejected
        cambios += 1
    End Sub

    Private Sub txtPais_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPais.TextChanged
        cambios += 1
    End Sub

    Private Sub txtProv_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProv.TextChanged
        cambios += 1
    End Sub

    Private Sub txtCanton_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCanton.TextChanged
        cambios += 1
    End Sub

    Private Sub txtCiudad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCiudad.TextChanged
        cambios += 1
    End Sub

    Private Sub txtDomicilio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDomicilio.TextChanged
        cambios += 1
    End Sub

    Private Sub txtFax_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios += 1
    End Sub

    Private Sub txtCasilla_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios += 1
    End Sub

    Private Sub txtTelf1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTelf1.TextChanged
        cambios += 1
    End Sub

    Private Sub txtTelf2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTelf2.TextChanged
        cambios += 1
    End Sub

    Private Sub txtCorreo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCorreo.TextChanged
        cambios += 1
    End Sub

    Private Sub txtPresCod_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPresCod.TextChanged
        cambios += 1
    End Sub

    Private Sub txtRepLCod_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRepLCod.TextChanged
        cambios += 1
    End Sub

    Private Sub txtGerent_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGerent.TextChanged
        cambios += 1
    End Sub

    Private Sub txtContCod_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtContCod.TextChanged
        cambios += 1
    End Sub
    Private Sub txtservidor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtservidor.TextChanged
        cambios += 1
    End Sub

    Private Sub txtPass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPass.TextChanged
        cambios += 1
    End Sub

    Private Sub txtUrs_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUrs.TextChanged
        cambios += 1
    End Sub

    Private Sub txtConfirma_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtConfirma.TextChanged
        cambios += 1
    End Sub

    Private Sub cboAdcom_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAdcom.SelectedValueChanged
        cambios += 1
    End Sub

    Private Sub cboDaxp_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDaxp.SelectedValueChanged
        cambios += 1
    End Sub

    Private Sub cboIvar_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIvar.SelectedValueChanged
        cambios += 1
    End Sub

    Private Sub cboRolP_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRolP.SelectedValueChanged
        cambios += 1
    End Sub
#End Region

#Region "Guardar/Modificar"

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        bloquear(False)
        accion = "M"
        cambios = 0
    End Sub
    Private Function verificacion() As String
        Dim msg As String = ""
        If txtEmp.Text = "" Then Return "No se ha registrado el nombre de la empresa" : Exit Function
        If txtRuc.Text = "" Then Return "No se ha registrado el ruc de la empresa" : Exit Function
        If cboAdcom.Text = "" Then Return "No se ha registrado el nombre de la base de datos en el directorio" : Exit Function
        'If txtPass.Text <> txtConfirma.Text Then Return "La confirmación de la contraseña no es correcta" : Exit Function
        Return msg
    End Function
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim m As String = verificacion()
        If m <> "" Then MsgBox(m) : Exit Sub
        GuardarIdentificacion(accion)
        GuardarBdd(CInt(empcod))
        If accion = "G" Then
            If MsgBox("RECUERDE REGISTRAR LAS SUCURSALES Y PARÁMETROS DEL SISTEMA ANTES DE CONTINUAR CON LA UTILIZACIÓN DE LA NUEVA EMPRESA" & vbCr & "DESEA HACERLO EN ESTE MOMENTO?", MsgBoxStyle.YesNo) = vbYes Then
                Dim suc As New frmSuc
                suc.Sucursales(CInt(empcod), txtEmp.Text)
                Dim p As New frmPar
                p.Parametros(empcod, Replace(DattCom.datosEmpresa.strConxAdcom, datosEmpresa.nombreBaseAdcom, CStr(cboAdcom.SelectedValue)))
            End If
        End If
        MsgBox("Los cambios efectuados no serán efectivos hasta que reinicie el sistema", MsgBoxStyle.Information)
        cancelar()
    End Sub

#Region "Guardar Indet."

    Private Sub GuardarIdentificacion(ByVal acc As String)
        Dim em As New Emp_datos
        em.Emp_Nombre = txtEmp.Text
        em.Emp_Defecto = chkEmpDef.Checked
        em.Emp_RUC = txtRuc.Text
        em.Emp_SegSocial = txtSegSoc.Text
        em.Emp_Pais = txtPais.Text
        em.Emp_Provincia = txtProv.Text
        em.Emp_Cantón = txtCanton.Text
        em.Emp_Ciudad = txtCiudad.Text
        em.Emp_Dirección = txtDomicilio.Text
        'em.Emp_Fax = txtFax.Text
        'em.Emp_Casilla = txtCasilla.Text
        em.Emp_Telefono_1 = txtTelf1.Text
        em.Emp_Telefono_2 = txtTelf2.Text
        em.Emp_Email = txtCorreo.Text
        em.Emp_PathImagenes = lblpathIma.Text
        em.Emp_Presidente = txtPresCod.Text
        em.Emp_RepLegal = txtRepLCod.Text
        em.Emp_Gerente = txtGerent.Text
        em.Emp_Contador = txtContCod.Text
        em.Emp_Conta = chkEmpConta.Checked
        em.Emp_AgeRet = txtAgeRet.Text
        em.Emp_ContrBuyEsp = txtContrBuyEsp.Text
        em.Emp_Regimen = cboRegimen.Text

        If accion = "G" Then
            empcod = CStr(CodEmp())
            em.Emp_codigo = CInt(empcod)
            em.Guardar()
        Else
            em.Actualizar(empcod)
        End If
    End Sub
    Private Function CodEmp() As Integer
        Dim codigoEmp As Integer = 0
        Dim ssql As String = "select max(emp_codigo) as cod from emp_datos"
        'Dim cmd As New SqlCommand(ssql, ConSys)
        Dim dat As SqlDataReader = DattCom.SqlDatos.leerBaseIniSis(ssql)
        'dat = cmd.ExecuteReader()
        If dat.Read Then
            If Not IsDBNull(dat(0)) Then codigoEmp = CInt(dat(0).ToString) + 1 Else codigoEmp = 1
        Else : codigoEmp = 1
        End If
        'ConSys.Close()
        Return codigoEmp
    End Function
#End Region

#Region "Guardar BaseD"
    Private Sub GuardarBdd(ByVal cod As Integer)
        GuardarBddDet(CStr(cod), "ADC", CStr(cboAdcom.SelectedValue))
        GuardarBddDet(CStr(cod), "ALE", CStr(cboAdcom.SelectedValue))
        'GuardarBddDet(CStr(cod), "PRO", CStr(cboDaxp.SelectedValue))
        'GuardarBddDet(CStr(cod), "ROL", CStr(cboRolP.SelectedValue))
        GuardarBddDet(CStr(cod), "PRO", CStr(cboAdcom.SelectedValue))
        GuardarBddDet(CStr(cod), "ROL", CStr(cboAdcom.SelectedValue))
        GuardarBddDet(CStr(cod), "SRI", CStr(cboIvar.SelectedValue))
    End Sub
    Private Sub GuardarBddDet(ByVal codE As String, ByVal tipo As String, ByVal nom As String)
        Dim em As New emp_Arch
        em.Emp_Codigo = CInt(codE)
        em.Arch_Tipo = tipo
        em.Arch_Nom = nom
        If accion = "G" Then
            em.Guardar()
        Else
            em.Actualizar(empcod)
        End If
    End Sub
#End Region

#End Region

#Region "Nuevo"
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        accion = "G"
        btnParam.Enabled = False
        btnSuc.Enabled = False
        limpiar()
        bloquear(False)
        cboAdcom.Text = ""
        cboDaxp.Text = ""
        cboIvar.Text = ""
        cboRolP.Text = ""
        txtservidor.Text = datosEmpresa.Servidor
        txtUrs.Text = datosEmpresa.UsuarioBd
        txtPass.Text = datosEmpresa.ClaveBd

        cambios = 0
    End Sub
    Private Sub limpiar()
        Dim Control1 As System.Windows.Forms.Control
        Dim Control2 As System.Windows.Forms.Control
        Dim a As String
        txtRuc.Text = ""
        txtEmp.Text = ""
        For Each Control1 In GroupBox1.Controls
            a = TypeName(Control1)
            If a = "TextBox" Then Control1.Text = ""
            If a = "MaskedTextBox" Then Control1.Text = "  /  /"
        Next
        For Each Control2 In GroupBox2.Controls
            a = TypeName(Control2)
            If a = "TextBox" Then Control2.Text = ""
            If a = "MaskedTextBox" Then Control2.Text = "  /  /"
        Next
        For Each Control2 In GroupBox3.Controls
            a = TypeName(Control2)
            If a = "TextBox" Then Control2.Text = ""
            If a = "MaskedTextBox" Then Control2.Text = "  /  /"
        Next
        For Each Control2 In GroupBox4.Controls
            a = TypeName(Control2)
            If a = "TextBox" Then Control2.Text = ""
            If a = "MaskedTextBox" Then Control2.Text = "  /  /"
        Next
        lblContNom.Text = ""
        lblGerentNom.Text = ""
        lblpathIma.Text = ""
        lblPresNom.Text = ""
        lblRepLNom.Text = ""
        chkEmpConta.Checked = False
        txtAgeRet.Text = ""
        txtContrBuyEsp.Text = ""
        cboRegimen.SelectedIndex = -1


    End Sub

#End Region

#Region "Eliminar"
    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If MsgBox("Confirma eliminar todo el registro? ", MsgBoxStyle.YesNo) = vbYes Then
            eliminar(empcod)
            Dim codigoEmp As Int16 = CShort(empcod)
            codigoEmp = CShort(codigoEmp - 1)
            empcod = CStr(codigoEmp)
            CargarIdentific(empcod)
        End If
    End Sub
    Private Sub eliminar(ByVal empCod As String)
        Dim em As New Emp_datos
        em.Eliminar(empCod)
    End Sub
#End Region

#Region "Salir/Cancelar"
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If cambios > 0 Then
            If MsgBox("Desea guardar los cambios ?", MsgBoxStyle.YesNo) = vbYes Then
                GuardarIdentificacion(accion)
                cancelar()
            Else : cancelar()
            End If
        Else
            cancelar()
        End If
    End Sub
    Private Sub cancelar()
        bloquear(True)
        CargarIdentific(CStr(datosEmpresa.Emp_codigo))
        txtConfirma.Text = ""
        cambios = 0
        accion = "G"
    End Sub
#End Region

#Region "Sucursales"
    Private Sub btnSuc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSuc.Click
        Dim suc As New frmSuc
        suc.Sucursales(CInt(empcod), txtEmp.Text)
    End Sub
#End Region

#Region "Parametros"
    Private Sub btnParam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnParam.Click
        Dim p As New frmPar
        p.Parametros(empcod, Replace(datosEmpresa.strConxAdcom, datosEmpresa.nombreBaseAdcom, CStr(cboAdcom.SelectedValue)))
    End Sub
#End Region

End Class
