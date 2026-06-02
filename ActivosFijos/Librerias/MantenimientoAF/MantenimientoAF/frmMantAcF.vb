Imports System.Data
Imports System.Data.SqlClient

Public Class MantAF
    'VARIABLES PARA LA CONEXION CON LA BASE DE DATOS
    Dim conectarBDD As New SqlConnection()

    'VARIABLES DE ACTIVOS FIJOS
    Dim cambios As Integer
    Dim op, existeCod As String
    Dim actualizar As Int16 = 0
    Public act As String
    Dim verif As Integer
    Dim opcion, ssql, acc, aseguradora As String ' , moneda As String
    Dim modCosto As Boolean = False
    Dim StrConxadcom As String = ""
    Dim dataAcf As New AdcAcf()
    Dim DatActivoCmpsto As New AdcAcf()
    Dim txtImagen As String = ""
    Dim codigoExterno As String
    Dim accionExterna As String
    Dim proceso As Int16 = 0 '1 nuevo   2 consultando  0 ninguna
    Private Sub MantAF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim conector As New DaxLib.DaxLibBases
        TabControl.TabPages(2).Dispose()
        dataAcf = New AdcAcf(varbleComun.VarCom.strConxAdcom)
        conector.TipoBase = "10"
        StrConxadcom = conector.StrAdcom
        conectarBDD.ConnectionString = StrConxadcom
        llenarComboCat(1) 'Categori
        llenarMoneda()
        If codigoExterno > "" Then AbrirActivo(codigoExterno)
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If verificarInformacion() Then Exit Sub
        MoverValoresAClaseData()
        If modCosto = True And ConsultaDep(txtCodigo.Text) = True Then
            If MsgBox("Se efectuaron cambios a lo datos de depreciación " + vbCr + "Se elimnarán las dpreciaciones existentes" + vbCr + "Desea continuar?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Return
            EliminarDep(txtCodigo.Text)
        End If
        actualizarRegistro()
        Clear()
    End Sub
    Private Function ConsultaDep(ByVal codAcf As String)
        Dim bandera As Boolean = False
        Dim ssql As String = "Select codigo from adcacfdep where codigo='" & codAcf & "'"
        Dim cmd As New SqlCommand(ssql, conectarBDD)
        Dim dat As SqlDataReader = Nothing
        If conectarBDD.State = ConnectionState.Open Then conectarBDD.Close()
        conectarBDD.Open()
        dat = cmd.ExecuteReader
        If dat.Read Then
            If Not IsDBNull(dat(0)) Then bandera = True
        End If
        conectarBDD.Close()
        Return bandera
    End Function
    Private Sub EliminarDep(ByVal codAcf As String)
        Dim ssql As String = "delete from adcacfdep where codigo='" & codAcf & "'"
        Dim cmd As New SqlCommand(ssql, conectarBDD)
        If conectarBDD.State = ConnectionState.Open Then conectarBDD.Close()
        conectarBDD.Open()
        cmd.ExecuteNonQuery()
        conectarBDD.Close()
    End Sub
    Private Sub MoverValoresAClaseData()
        'ASIGNA LOS VALORES DE LAS CAJAS DE TEXTO A CADA VARIABLE
        Dim prSys As Syscod.ManSysnetClass = New Syscod.ManSysnetClass()

        'dataAcf = New AdcAcf(StrConxadcom)

        dataAcf.Codigo = txtCodigo.Text
        dataAcf.Nombre = txtDescrip.Text
        dataAcf.TipoActivo = cboTipoActivos.Text
        dataAcf.Categoria = cboCategoria.SelectedValue.ToString()
        dataAcf.Clase = cboClase.SelectedValue.ToString()
        dataAcf.Grupo = cboGrupo.SelectedValue.ToString()
        dataAcf.Marca = txtMarca.Text
        dataAcf.Serie = txtSerie.Text
        dataAcf.NroLote = TxtLote.Text
        'dataAcf.CentroCosto = txtCCostoCod.Text
        dataAcf.CodActivoPrincipal = txtActivoCmpstoCod.Text
        dataAcf.EsComponente = chkComponente.Checked
        dataAcf.Descripcion = txtActivoCmpstoNombre.Text
        dataAcf.Responsable = txtRespCod.Text
        dataAcf.Estado = txtEstado.Text

        If IsDate(txtFechaIng.Value) Then
            dataAcf.FecIngreso = CDate(txtFechaIng.Value)
        Else
            dataAcf.FecIngreso = txtfechaSal.Text
        End If
        dataAcf.CostoIngreso = Val(txtCostoIng.Text)
        dataAcf.DocTipIngreso = txtDocIng.Text
        If txtNDocIng.Text <> "" Then
            dataAcf.DocNumIngreso = txtNDocIng.Text
        Else
            dataAcf.DocNumIngreso = 0
        End If
        'If txtfechaSal.Text = "  /  /" Then dataAcf.FecSalida = "1900/01/01" Else 
        dataAcf.FecSalida = Txtfechasal.Value
        dataAcf.DocTipSalida = txtDocSal.Text
        dataAcf.DocNumSalida = 0
        If txtNDocSal.Text <> "" Then dataAcf.DocNumSalida = txtNDocSal.Text
        dataAcf.CtaContable1 = txtIdentifCodigo1.Text
        dataAcf.CtaContable2 = txtIdentifCodigo2.Text
        dataAcf.CtaContable3 = txtIdentifCodigo3.Text
        dataAcf.CtaContable4 = txtIdentifCodigo4.Text
        dataAcf.ValorResidual = Val(txtValRes.Text)
        dataAcf.TipoDepreciacionCont = cboTipoDepFinanc.SelectedIndex
        dataAcf.TipoDepreciacionTributa = cboTipoDepTribut.SelectedIndex
        dataAcf.VidaUtilCont = Val(txtVidaUtConta.Text)
        dataAcf.VidaUtilTributa = Val(txtVidaUtTribut.Text)

        dataAcf.UnidacesProduccionCont = Val(txtUndProdConta.Text)
        dataAcf.UnidadesProduccionTribut = 0
        dataAcf.TasaDepCont = 0
        dataAcf.TasaDepTribut = Val(txtTasaDeprecTrib.Text)
        dataAcf.ValorActualCont = 0
        dataAcf.ValorActualTribut = 0
        dataAcf.UltimoAñoCalc = 0
        dataAcf.UltimoMesCalc = 0
        dataAcf.UsuarioCrea = ""
        dataAcf.UsuarioModifica = varbleComun.VarCom.usr
        dataAcf.FechaModifica = LSet(Now, 10)
        dataAcf.Imagen = txtImagen
        dataAcf.Cantidad = CLng("0" & txtCantidad.Text)
        dataAcf.Aseguradora = txtAsegCod.Text
        dataAcf.NContrato = Convert.ToDecimal("0" & txtContrato.Text)
        If IsDate(txtFechaInicioS.Text) Then
            dataAcf.FechaIngSeguro = CDate(txtFechaInicioS.Text)
        Else
            dataAcf.FechaIngSeguro = "1900/01/01"
        End If
        If IsDate(txtFechaFinS.Text) Then
            dataAcf.FechaSalSeguro = CDate(txtFechaFinS.Text)
        Else
            dataAcf.FechaSalSeguro = "1900/01/01"
        End If
        dataAcf.MontoAsegurado = Val(txtMonto.Text)
        dataAcf.Deducible = Val(txtDeducible.Text)
        dataAcf.PagoMensual = Val(txtPagoM.Text)
        If cboMoneda.Text = "" Then
            dataAcf.Moneda = ""
        Else
            dataAcf.Moneda = cboMoneda.SelectedValue.ToString()
        End If
        If txtParidad.Text = "" Then
            dataAcf.Paridad = 0
        ElseIf txtParidad.Text = "" And cboMoneda.Text = "Dólares" Then
            dataAcf.Paridad = 1
        Else
            dataAcf.Paridad = txtParidad.Text
        End If
    End Sub

    Public Sub consultarExt(ByVal accion As String, ByVal codigo As String)
        codigoExterno = codigo
        accionExterna = accion
        Me.ShowDialog()
    End Sub
    Private Sub AbrirActivo(ByVal codigo As String)
        Dim retNom As New RetNombre.AdcNomb()

        dataAcf = New AdcAcf(varbleComun.VarCom.strConxAdcom)
        dataAcf = AdcAcf.Buscar(" codigo = '" + codigo + "'")

        If IsNothing(dataAcf) Then
            If proceso = 0 Then
                If MessageBox.Show("No existe el áctivo fijo, desea crear uno nuevo ? ", "Mantenimiento Activos fijos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Return
                Nuevo()
                txtDescrip.Focus()
                Return
            Else
                MessageBox.Show("No existe el código del áctivo fijo digitado ", "Mantenimiento Activos fijos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCodigo.Text = ""
                txtCodigo.Focus()
                Return
            End If
        End If

        txtCodigo.Text = dataAcf.Codigo
        txtDescrip.Text = dataAcf.Nombre
        cboTipoActivos.Text = dataAcf.TipoActivo
        cboCategoria.SelectedValue = dataAcf.Categoria
        cboClase.SelectedValue = dataAcf.Clase
        cboGrupo.SelectedValue = dataAcf.Grupo
        cboSubg.SelectedValue = dataAcf.Subgrupo
        txtMarca.Text = dataAcf.Marca
        txtSerie.Text = dataAcf.Serie
        TxtLote.Text = dataAcf.NroLote

        txtActivoCmpstoCod.Text = dataAcf.CodActivoPrincipal

        chkComponente.Checked = dataAcf.EsComponente

        txtSucursal.Text = retNom.RetornaNombreSucursal(varbleComun.VarCom.codEmpresa, dataAcf.UbicaSucursal, varbleComun.VarCom.strConxSyscod)
        txtDepartamento.Text = retNom.RetornaNombreSyscod("Departamento", dataAcf.UbicaDepartamento, varbleComun.VarCom.strConxSyscod)
        txtSeccion.Text = retNom.RetornaNombreSyscod("Sección", dataAcf.UbicaSeccion, varbleComun.VarCom.strConxSyscod)
        'txtCCostoCod.Text = dataAcf.CentroCosto : 
        txtCCosto.Text = retNom.RetornaNombreSyscod("Centro Costo", dataAcf.CentroCosto, varbleComun.VarCom.strConxAdcom)

        txtRespCod.Text = dataAcf.Responsable : txtResp.Text = retNom.RetornaNombreDirectorio(dataAcf.Responsable, varbleComun.VarCom.strConxAdcom)
        txtEstado.Text = dataAcf.Estado
        txtFechaIng.Text = dataAcf.FecIngreso
        txtCostoIng.Text = dataAcf.CostoIngreso
        txtDocIng.Text = dataAcf.DocTipIngreso
        txtNDocIng.Text = dataAcf.DocNumIngreso
        txtDocSal.Text = dataAcf.DocTipSalida
        txtNDocSal.Text = dataAcf.DocNumSalida
        txtIdentifCodigo1.Text = dataAcf.CtaContable1
        txtIdentifCodigo2.Text = dataAcf.CtaContable2
        txtIdentifCodigo3.Text = dataAcf.CtaContable3
        txtIdentifCodigo4.Text = dataAcf.CtaContable4
        txtValRes.Text = dataAcf.ValorResidual
        cboTipoDepFinanc.SelectedIndex = dataAcf.TipoDepreciacionCont
        'cboDepFin.Text = ""
        'cboDepFin.Text = cboDepFin.SelectedItem.ToString
        cboTipoDepTribut.SelectedIndex = dataAcf.TipoDepreciacionTributa
        'cboDepTribut.Text = ""
        'cboDepTribut.Text = cboDepTribut.SelectedItem.ToString
        txtVidaUtConta.Text = dataAcf.VidaUtilCont
        txtVidaUtTribut.Text = dataAcf.VidaUtilTributa
        txtUndProdConta.Text = dataAcf.UnidacesProduccionCont
        txtTasaDeprecTrib.Text = dataAcf.TasaDepTribut

        txtImagen = dataAcf.Imagen : If (dataAcf.Imagen.Length > 0) Then imgImagen.Image = Image.FromFile(dataAcf.Imagen)
        txtCantidad.Text = dataAcf.Cantidad
        txtAsegCod.Text = dataAcf.Aseguradora
        txtContrato.Text = dataAcf.NContrato
        txtFechaInicioS.Text = dataAcf.FechaIngSeguro
        txtFechaFinS.Text = dataAcf.FechaSalSeguro
        txtMonto.Text = dataAcf.MontoAsegurado
        txtDeducible.Text = dataAcf.Deducible
        txtPagoM.Text = dataAcf.PagoMensual
        cboMoneda.SelectedValue = dataAcf.Moneda
        txtParidad.Text = dataAcf.Paridad
        Txtfechasal.Text = dataAcf.FecSalida

        ConsultCta(txtIdentifCodigo1.Text, 1)
        ConsultCta(txtIdentifCodigo2.Text, 2)
        ConsultCta(txtIdentifCodigo3.Text, 3)
        ConsultCta(txtIdentifCodigo4.Text, 4)
        consResp(txtRespCod.Text, "RESP")
        consResp(txtAsegCod.Text, "ASEG")
        CargarActivoCmpsto(txtActivoCmpstoCod.Text)
        proceso = 2
        ControlarBotones()
    End Sub
    Public Sub consCCosto(ByVal cod As String)
        ssql = "Select CCO_Nombre from AdcCcosto where CCO_id='" & cod & "'"
        Dim consulta As New SqlCommand(ssql, conectarBDD)
        Dim data As SqlDataReader
        conectarBDD.Open()
        data = consulta.ExecuteReader()
        If data.Read Then
            txtCCosto.Text = data(0)
        Else
            txtCCosto.Text = ""
        End If
        conectarBDD.Close()
    End Sub
    Public Sub consResp(ByVal cod As String, ByVal op As String)
        ssql = "Select NombreImpresion as Nombre from Identificacion where Codigo='" & cod & "'"
        Dim com As New SqlCommand(ssql, conectarBDD)
        conectarBDD.Open()
        Dim dat As SqlDataReader
        dat = com.ExecuteReader()
        If dat.Read Then
            If op = "RESP" Then
                txtResp.Text = dat(0)
            ElseIf op = "ASEG" Then
                txtAseguradora.Text = dat(0)
            End If
        Else
            If op = "RESP" Then
                txtResp.Text = ""
            ElseIf op = "ASEG" Then
                txtAseguradora.Text = ""
            End If
        End If
        conectarBDD.Close()
    End Sub
    Private Sub consDep(ByVal cod As String, ByVal ref As String)
        Dim cSql As String = ""
        Dim conect As New SqlConnection()
        Dim conector As New DaxLib.DaxLibBases
        conector.TipoBase = "10"
        conect.ConnectionString = conector.StrDaxsys
        cSql = "Select Descripcion from Syscod where TipoReferencia='" & ref & "' and Abreviación='" & cod & "'"
        Dim com As New SqlCommand(cSql, conect)
        conect.Open()
        Dim dat As SqlDataReader
        dat = com.ExecuteReader()
        If dat.Read Then
            If ref = "Departamento" Then
                txtDepartamento.Text = dat(0)
            Else
                txtSeccion.Text = dat(0)
            End If

        Else
            If ref = "Departamento" Then
                txtDepartamento.Text = ""
            Else
                txtSeccion.Text = ""
            End If
        End If
        conect.Close()
    End Sub


    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        Dim confirmacion As Integer
        confirmacion = MsgBox("Esta Seguro que Quiere Eliminar El Activo?", MsgBoxStyle.YesNoCancel)
        If confirmacion = vbYes Then
            dataAcf.Codigo = txtCodigo.Text
            dataAcf.Borrar("select * from adcacf where codigo = '" + txtCodigo.Text + "'")
            Clear()
        End If
    End Sub
    Private Sub Clear()
        txtCodigo.Text = ""
        txtDescrip.Text = ""
        cboTipoActivos.Text = ""
        txtMarca.Text = ""
        txtSerie.Text = ""
        TxtLote.Text = ""
        txtCCosto.Text = ""
        txtActivoCmpstoCod.Text = ""
        chkComponente.Checked = False
        txtActivoCmpstoNombre.Text = ""
        txtSucursal.Text = ""
        txtSeccion.Text = ""
        txtRespCod.Text = ""
        txtResp.Text = ""
        txtEstado.Text = ""
        txtTasaDeprecTrib.Text = ""
        txtDepartamento.Text = ""
        cboTipoDepFinanc.Text = ""
        cboTipoDepTribut.Text = ""
        txtUndProdConta.Text = ""
        txtFechaIng.Text = ""
        txtCostoIng.Text = ""
        txtDocIng.Text = ""
        txtNDocIng.Text = ""
        txtDocSal.Text = ""
        txtNDocSal.Text = ""
        txtIdentifCodigo1.Text = ""
        txtIdentifNombre1.Text = ""
        txtIdentifCodigo2.Text = ""
        txtIdentifNombre2.Text = ""
        txtIdentifCodigo3.Text = ""
        txtIdentifNombre3.Text = ""
        txtIdentifCodigo4.Text = ""
        txtIdentifNombre4.Text = ""
        txtValRes.Text = ""
        txtImagen = ""
        txtCantidad.Text = ""
        cboTipoDepFinanc.Text = ""
        cboTipoDepTribut.Text = ""
        imgImagen.Image = Nothing
        txtAsegCod.Text = ""
        txtAseguradora.Text = ""
        txtContrato.Text = ""
        txtMonto.Text = ""
        txtDeducible.Text = ""
        txtPagoM.Text = ""
        cboMoneda.Text = ""
        txtParidad.Text = ""
        txtActivoCmpstoCod.Visible = False
        txtActivoCmpstoNombre.Visible = False
        btnBuscaActivoCmpsto.Visible = False

        dataAcf = New AdcAcf(varbleComun.VarCom.strConxAdcom)
        proceso = 0
        modCosto = False
        cambios = 0
        ControlarBotones()
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Nuevo()
    End Sub

    Private Sub btnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrir.Click
        If HayActivos("A") = False Then MsgBox("No existen Activos", MsgBoxStyle.Information)
        Dim busk As New BuscarAcf()
        Dim cod As String
        cod = busk.Cargar("")
        If (cod <> "") Then
            llenarMoneda()
            AbrirActivo(cod)
        End If
    End Sub
    Private Function HayActivos(ByVal op As String) As Boolean
        Dim conectar As New SqlConnection() '"server=SISTEMAS\SQLEXPRESS;user id=sa;password=123qweASDZXC;database=BdAdcomDxSistemas;pooling=false")
        Dim res As Integer = 0
        Dim ssql As String = ""
        Dim condax As New DaxLib.DaxLibBases
        HayActivos = True
        condax.TipoBase = "10"
        conectar.ConnectionString = condax.StrAdcom
        ssql = "Select * from AdcAcf "
        If op = "P" Then ssql = ssql & " where EsComponente = 0"
        Dim com As New SqlCommand(ssql, conectar)
        Dim dat As SqlDataReader
        conectar.Open()
        dat = com.ExecuteReader()
        HayActivos = dat.Read()
        conectar.Close()
        dat.Close()
        com.Dispose()
        conectar.Dispose()
    End Function
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If MsgBox("Confirma cerrar las datos actuales, si realizó cambios se perderán", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Return
        Clear()
    End Sub
    Private Sub actualizarRegistro()
        dataAcf.Actualizar("Select * from adcacf where codigo = '" + txtCodigo.Text + "'")
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Dispose()
    End Sub
    Private Function verificarInformacion() As Boolean
        verificarInformacion = True
        If txtCodigo.Text = "" Then
            MsgBox("Es Necesario Ingresar el Código del Activo", MsgBoxStyle.Information)
            TabControl.SelectTab(0)
            txtCodigo.Focus()
        ElseIf txtDescrip.Text = "" Then
            MsgBox("El Nombre es Requerido para ingresar El Activo", MsgBoxStyle.Information)
            TabControl.SelectTab(0)
            txtDescrip.Focus()
        ElseIf cboTipoActivos.Text = "" Then
            MsgBox("Es Necesario Ingresar el Tipo de Activo", MsgBoxStyle.Information)
            TabControl.SelectTab(0)
            cboTipoActivos.Focus()
        ElseIf txtCantidad.Text = "" Then
            MsgBox("La Cantidad No Puede se Nula", MsgBoxStyle.Information)
            txtCantidad.Focus()
        ElseIf chkComponente.Checked = True And (txtActivoCmpstoCod.Text = "" Or txtActivoCmpstoNombre.Text = "") Then
            MsgBox("Debe registrar el Activo principal del componente", MsgBoxStyle.Information)
            txtActivoCmpstoCod.Focus()
            'ElseIf txtSucursal.Text = "" Then
            '    MsgBox("Es Necesario Ingresar la Sucursal", MsgBoxStyle.Information)
            '    TabControl.SelectTab(1)
            '    txtSucursal.Focus()
            'ElseIf txtDep.Text = "" Then
            '    MsgBox("Es Necesario Ingresar el Departamento", MsgBoxStyle.Information)
            '    TabControl.SelectTab(1)
            '    txtDep.Focus()
        ElseIf txtDocIng.Text = "" Then
            MsgBox("Es Necesario el Documento de Ingreso", MsgBoxStyle.Information)
            TabControl.SelectTab(1)
            txtDocIng.Focus()
        ElseIf txtNDocIng.Text = "" Then
            MsgBox("Es Necesario Ingresar el Número de Documento", MsgBoxStyle.Information)
            TabControl.SelectTab(1)
            txtNDocIng.Focus()
        ElseIf txtCostoIng.Text = "" Then
            MsgBox("Es Necesario Ingresar el Costo", MsgBoxStyle.Information)
            TabControl.SelectTab(1)
            txtCostoIng.Focus()
        ElseIf txtValRes.Text = "" Then
            MsgBox("Es Necesario Ingresar el Valor Residual", MsgBoxStyle.Information)
            TabControl.SelectTab(1)
            txtValRes.Focus()
        ElseIf cboTipoDepFinanc.Text = "" Then
            MsgBox("Es Necesario el Tipo de Depreciación Financiera", MsgBoxStyle.Information)
            TabControl.SelectTab(1)
            cboTipoDepFinanc.Focus()
        ElseIf cboTipoDepTribut.Text = "" Then
            MsgBox("Es Necesario el Tipo de Depreciación Tributaria", MsgBoxStyle.Information)
            TabControl.SelectTab(1)
            cboTipoDepTribut.Focus()
        Else
            verificarInformacion = False
        End If
    End Function

    'ESTE METODO COMPARA EL CODIGO INGRESADO EN PANTALLA CON LOS GUARDADOS EN LA BASE DE DATOS PARA QUE NO SE INGRESE
    'UN CODIGO QUE YA EXISTA
    Private Sub ComprobarCodigo()
        ssql = "Select Codigo from AdcAcf where Codigo ='" & txtCodigo.Text & "'"
        If conectarBDD.State = ConnectionState.Open Then
            conectarBDD.Close()
        End If
        Dim com As New SqlCommand(ssql, conectarBDD)
        conectarBDD.Open()
        Dim datos As SqlDataReader
        datos = com.ExecuteReader()
        If datos.HasRows Then
            MsgBox("El codigo " & txtCodigo.Text & " ya existe", MsgBoxStyle.Exclamation)
            actualizar = 1
            existeCod = 1
        End If
        conectarBDD.Close()
    End Sub
    Private Sub llenarMoneda()
        Dim conectar As New SqlConnection() '"server=SISTEMAS\SQLEXPRESS;user id=sa;password=123qweASDZXC;database=DaxSys;pooling=false")
        Dim condax As New DaxLib.DaxLibBases
        condax.TipoBase = "10"
        conectar.ConnectionString = condax.StrDaxsys
        Dim ssql As String = "select Abreviación, Descripcion from Syscod where TipoReferencia='Monedas' and descripcion <> '' order by Descripcion"
        conectar.Open()
        Dim dat As New BindingSource()
        Dim datS As New DataSet()
        Dim con As New SqlDataAdapter(ssql, conectar)
        con.Fill(datS, "Syscod")
        dat.DataSource = datS
        dat.DataMember = "Syscod"
        cboMoneda.DataSource = dat
        cboMoneda.DisplayMember = "Descripcion"
        cboMoneda.ValueMember = "Abreviación"
        conectar.Close()
    End Sub
    'ESTE METODO LLENA LOS COMBOS DE CATEGORIA, CLASE, GRUPO Y SUBGRUPO
    Private Sub llenarComboCat(ByVal opcion As String)



        Dim cmb As New DaxCbos.DaxCombobx

        cmb.DaxCombosCat("C", "A", StrConxadcom, cboCategoria)
        cmb.DaxCombosCat("CL", "A", StrConxadcom, cboClase)
        cmb.DaxCombosCat("G", "A", StrConxadcom, cboGrupo)
        cmb.DaxCombosCat("S", "A", StrConxadcom, cboGrupo)

        conectarBDD.Close()
    End Sub
    'Private Sub txtCodigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown
    '    If e.KeyCode = 13 And txtCodigo.Text <> "" Then
    '        ComprobarCodigo()
    '    End If
    'End Sub
    'METODO PARA CONSULTAR LOS ACTIVOS PRINCIPALES 
    Private Function CargarActivoCmpsto(ByVal cod As String, Optional CargarDatos As Boolean = False) As Boolean
        If cod.Length = 0 Then Return False
        DatActivoCmpsto = New AdcAcf(StrConxadcom)
        DatActivoCmpsto = AdcAcf.Buscar(" Codigo = '" & cod & "'")
        If IsDBNull(DatActivoCmpsto) Then
            MessageBox.Show("El codigo registrado para activo fijo principal no existe")
            txtActivoCmpstoCod.Text = ""
            txtActivoCmpstoNombre.Text = ""
            Return False
        End If
        txtActivoCmpstoCod.Text = DatActivoCmpsto.Codigo
        txtActivoCmpstoNombre.Text = DatActivoCmpsto.Nombre
        If CargarDatos Then CargaDatosActivoCmpstoAComponente()
    End Function
    Private Sub CargaDatosActivoCmpstoAComponente()
        Dim retNom As New RetNombre.AdcNomb()

        cboCategoria.SelectedValue = DatActivoCmpsto.Categoria
        cboClase.SelectedValue = DatActivoCmpsto.Clase
        cboGrupo.SelectedValue = DatActivoCmpsto.Grupo
        '        cboSubg.SelectedValue = DatActivoCmpsto.Subgrupo

        txtSucursal.Text = retNom.RetornaNombreSucursal(varbleComun.VarCom.codEmpresa, DatActivoCmpsto.UbicaSucursal, varbleComun.VarCom.strConxSyscod)
        txtDepartamento.Text = retNom.RetornaNombreSyscod("Departamento", DatActivoCmpsto.UbicaDepartamento, varbleComun.VarCom.strConxSyscod)
        txtSeccion.Text = retNom.RetornaNombreSyscod("Sección", DatActivoCmpsto.UbicaSeccion, varbleComun.VarCom.strConxSyscod)
        dataAcf.CentroCosto = DatActivoCmpsto.CentroCosto
        txtCCosto.Text = retNom.RetornaNombreSyscod("Centro Costo", DatActivoCmpsto.CentroCosto, varbleComun.VarCom.strConxAdcom)

        txtRespCod.Text = DatActivoCmpsto.Responsable
        txtResp.Text = retNom.RetornaNombreDirectorio(DatActivoCmpsto.Responsable, varbleComun.VarCom.strConxAdcom)


        cboTipoDepFinanc.SelectedIndex = DatActivoCmpsto.TipoDepreciacionCont
        cboTipoDepTribut.SelectedIndex = DatActivoCmpsto.TipoDepreciacionTributa

        txtVidaUtConta.Text = DatActivoCmpsto.VidaUtilCont
        txtUndProdConta.Text = DatActivoCmpsto.UnidacesProduccionCont
        'txtDep.Text = DatActivoCmpsto.TasaDepCont

        'calcular valores de depreciación en funcion del activo principal
        txtValRes.Text = Math.Round((DatActivoCmpsto.ValorResidual / DatActivoCmpsto.CostoIngreso) * Val(txtCostoIng.Text), 2)
        Dim mesesPasados As Long = DateDiff(DateInterval.Month, DatActivoCmpsto.FecIngreso, txtFechaIng.Value)
        Dim meseFaltaDepreciar As Long = (DatActivoCmpsto.VidaUtilTributa * 12) - mesesPasados
        Dim PorcDepreTributaria = Math.Round(((DatActivoCmpsto.VidaUtilTributa * 12) / meseFaltaDepreciar) * DatActivoCmpsto.TasaDepTribut, 2)
        txtTasaDeprecTrib.Text = PorcDepreTributaria
        txtVidaUtTribut.Text = Math.Round(100 / PorcDepreTributaria)


        txtAsegCod.Text = DatActivoCmpsto.Aseguradora
        txtContrato.Text = DatActivoCmpsto.NContrato
        txtFechaInicioS.Text = DatActivoCmpsto.FechaIngSeguro
        txtFechaFinS.Text = DatActivoCmpsto.FechaSalSeguro
        txtMonto.Text = DatActivoCmpsto.MontoAsegurado
        txtDeducible.Text = DatActivoCmpsto.Deducible
        txtPagoM.Text = DatActivoCmpsto.PagoMensual
        cboMoneda.SelectedValue = DatActivoCmpsto.Moneda
        txtParidad.Text = DatActivoCmpsto.Paridad
        Txtfechasal.Text = DatActivoCmpsto.FecSalida



        Return
    End Sub
    Private Sub ConsultCta(ByVal cta As String, ByVal num As Integer)
        ssql = "Select Cta_nombre from AdcCta where Cta_codigo= '" & cta & "'"
        If conectarBDD.State = ConnectionState.Closed Then conectarBDD.Open()
        Dim com As New SqlCommand(ssql, conectarBDD)
        Dim dat As SqlDataReader = com.ExecuteReader()
        If dat.Read Then
            If num = 1 Then
                txtIdentifNombre1.Text = dat.GetString(0)
            ElseIf num = 2 Then
                txtIdentifNombre2.Text = dat.GetString(0)
            ElseIf num = 3 Then
                txtIdentifNombre3.Text = dat.GetString(0)
            Else
                txtIdentifNombre4.Text = dat.GetString(0)
            End If
        End If
        conectarBDD.Close()
    End Sub
    Private Sub Nuevo()
        act = "Nuevo"
        txtCantidad.Text = "1"
        txtParidad.Text = "1"
        proceso = 1
        ControlarBotones()
    End Sub
    Public Sub NuevoActivo()
        Nuevo()
        Me.ShowDialog()
    End Sub

    Private Sub btnBuscaActivoCmpsto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscaActivoCmpsto.Click
        Dim res As Integer
        res = HayActivos("P")
        If res <> True Then
            MsgBox("No existen Activos", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim busk As New BuscarAcf()
        Dim cod As String
        cod = busk.Cargar("Principal")
        CargarActivoCmpsto(cod, True)
        txtMarca.Focus()
    End Sub

    Private Sub chkComponente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkComponente.CheckedChanged
        cambios = cambios + 1
        If chkComponente.Checked = True Then
            txtActivoCmpstoCod.Visible = True
            txtActivoCmpstoNombre.Visible = True
            btnBuscaActivoCmpsto.Visible = True
            ActivarOpcionesComponente(False)
        Else
            txtActivoCmpstoCod.Visible = False
            txtActivoCmpstoNombre.Visible = False
            btnBuscaActivoCmpsto.Visible = False
            txtActivoCmpstoNombre.Text = ""
            txtActivoCmpstoCod.Text = ""
            ActivarOpcionesComponente(True)
        End If
    End Sub
    Private Sub ActivarOpcionesComponente(estado As Boolean)
        cboCategoria.Enabled = estado
        cboClase.Enabled = estado
        cboGrupo.Enabled = estado
        btnBuscaActivoCmpsto.Enabled = (Not estado)
        grupoUbicacion.Enabled = estado
        grupoDepFinanciera.Enabled = estado
        grupoDepTributaria.Enabled = estado
        grupoSalida.Visible = estado
    End Sub
    Private Sub btnResponsable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResponsable.Click

        Dim busk As New MantenimientoDirectorio.BusDirectorio
        Dim codigo As String = ""
        Dim nombre As String = ""
        Dim cedula As String = ""
        Dim nombrealias As String = ""
        txtRespCod.Text = busk.BusDirect(codigo, cedula, nombre, nombrealias, "E")
        txtResp.Text = nombre
        txtDocIng.Focus()
    End Sub

    Private Sub btnIdentifCont1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIdentifCont1.Click
        Dim nombre As String = ""
        Dim codigo As String = ""
        Dim buscta As New MantCtb.BuscaCta
        txtIdentifCodigo1.Text = buscta.BuscaCtaCtb(nombre, "I")
        txtIdentifNombre1.Text = nombre
        txtIdentifCodigo2.Focus()
    End Sub

    Private Sub btnIdentifCont2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIdentifCont2.Click

        Dim nombre As String = ""
        Dim codigo As String = ""
        Dim buscta As New MantCtb.BuscaCta
        txtIdentifCodigo2.Text = buscta.BuscaCtaCtb(nombre, "I")
        txtIdentifNombre2.Text = nombre
        txtIdentifCodigo3.Focus()

    End Sub

    Private Sub btnIdentifCont3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIdentifCont3.Click

        Dim nombre As String = ""
        Dim codigo As String = ""
        Dim buscta As New MantCtb.BuscaCta
        txtIdentifCodigo3.Text = buscta.BuscaCtaCtb(nombre, "I")
        txtIdentifNombre3.Text = nombre
        txtIdentifCodigo4.Focus()

    End Sub

    Private Sub btnIdentifCont4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIdentifCont4.Click

        Dim nombre As String = ""
        Dim codigo As String = ""
        Dim buscta As New MantCtb.BuscaCta
        txtIdentifCodigo4.Text = buscta.BuscaCtaCtb(nombre, "I")
        txtIdentifNombre4.Text = nombre

    End Sub

    Private Sub btnDpto_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDpto.Click

        Dim busk As New Syscod.ManSysnetClass
        Dim codigo As String = ""
        Dim nombre As String = ""
        busk.BuscarReferencia("Departamento", codigo, nombre)
        txtDepartamento.Text = nombre
        dataAcf.UbicaDepartamento = codigo
        busk = Nothing

    End Sub

    Private Sub btnSeccion_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeccion.Click
        Dim busk As New Syscod.ManSysnetClass
        Dim codigo As String = ""
        Dim nombre As String = ""
        busk.BuscarReferencia("Sección", codigo, nombre)
        dataAcf.UbicaSeccion = codigo
        txtSeccion.Text = nombre
        busk = Nothing
    End Sub

    Private Sub txtCantidad_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCantidad.GotFocus
        txtCantidad.SelectAll()
    End Sub

    Private Sub txtCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        If InStr(1, "0123456789.," & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If

    End Sub

    Private Sub txtNDocIng_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If InStr(1, "0123456789.," & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txtNDocSal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If InStr(1, "0123456789.," & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txtCostoIng_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCostoIng.KeyPress
        If InStr(1, "0123456789.," & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txtValRes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtValRes.KeyPress
        If InStr(1, "0123456789.," & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txtVidaUtConta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVidaUtConta.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txtUndProdConta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUndProdConta.KeyPress
        If InStr(1, "0123456789.,   " & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txtValActualConta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If InStr(1, "0123456789.," & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txtVidaUtTribut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVidaUtTribut.KeyPress
        If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txtUndProdTribut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If InStr(1, "0123456789.," & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txtTDep_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If InStr(1, "0123456789.," & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txtValActualTribut_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If InStr(1, "0123456789.," & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub
    Private Sub txtDescrip_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescrip.TextChanged
        cambios = cambios + 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub cboTipoActivos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoActivos.SelectedIndexChanged
        cambios = cambios + 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub cboCategoria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCategoria.SelectedIndexChanged
        cambios = cambios + 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub cboClase_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClase.SelectedIndexChanged
        cambios = cambios + 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub cboGrupo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGrupo.SelectedIndexChanged
        cambios = cambios + 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub cboSubg_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSubg.SelectedIndexChanged
        cambios = cambios + 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub txtActPrinCod_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtActivoCmpstoCod.TextChanged
        cambios = cambios + 1
        If txtActivoCmpstoCod.Text = "" Then
            txtActivoCmpstoNombre.Text = ""
            ' chkCompuesto.Enabled = True
        Else
            ' chkCompuesto.Enabled = False
        End If
        btnGuardar.Enabled = True
    End Sub

    Private Sub txtActPrin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtActivoCmpstoNombre.TextChanged
        cambios = cambios + 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub txtMarca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMarca.TextChanged
        cambios = cambios + 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub txtSerie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSerie.TextChanged
        cambios = cambios + 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub TxtLote_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLote.TextChanged
        cambios = cambios + 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub txtEstado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEstado.TextChanged
        cambios = cambios + 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub txtCantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCantidad.TextChanged
        cambios = cambios + 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub cboDepFin_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios = cambios + 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub cboDepTribut_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios = cambios + 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub txtImagen_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios = cambios + 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub cboSucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios = cambios + 1
    End Sub

    Private Sub txtDep_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios = cambios + 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub txtSeccion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios = cambios + 1
    End Sub

    Private Sub txtRespCod_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios = cambios + 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub txtResp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios = cambios + 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub txtDocIng_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios = cambios + 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub txtDocSal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios = cambios + 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub txtNDocIng_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios = cambios + 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub txtNDocSal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios = cambios + 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub txtFechaIng_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim fec As Date
        fec = CDate("31 / 12 / 1900")
        If IsDate(txtFechaIng.Text) Then
            If CDate(txtFechaIng.Text) < fec Then
                MsgBox("Ingrese una FechaVálida", MsgBoxStyle.Exclamation)
                txtFechaIng.Text = LSet(Now, 10)
                txtFechaIng.Focus()
            End If
        End If
    End Sub

    Private Sub txtFechaIng_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFechaIng.ValueChanged
        cambios = cambios + 1
    End Sub

    Private Sub txtFechaSal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios = cambios + 1
    End Sub

    Private Sub cboCCosto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios = cambios + 1
    End Sub

    Private Sub txtCostoIng_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCostoIng.TextChanged
        cambios = cambios + 1
        modCosto = True
    End Sub

    Private Sub txtValRes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValRes.LostFocus
        Try
            If (CDbl(txtValRes.Text) >= CDbl(txtCostoIng.Text)) Then
                MsgBox("El Valor Residual no Puede ser Mayor o Igual al Costo de Ingreso")
                txtValRes.Text = ""
                txtValRes.Focus()
            End If
        Catch
        End Try
    End Sub

    Private Sub txtValRes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValRes.TextChanged
        cambios = cambios + 1
    End Sub

    Private Sub txtVidaUtConta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVidaUtConta.TextChanged
        cambios = cambios + 1
    End Sub

    Private Sub txtUndProdConta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUndProdConta.TextChanged
        cambios = cambios + 1
    End Sub

    Private Sub txtValActualConta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios = cambios + 1
    End Sub

    Private Sub txtVidaUtTribut_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVidaUtTribut.LostFocus
        Dim tdep As Double
        If txtVidaUtTribut.Text <> "" Then
            tdep = CDbl(100 / txtVidaUtTribut.Text)
            txtTasaDeprecTrib.Text = tdep
            txtIdentifCodigo1.Focus()
        End If
    End Sub

    Private Sub txtVidaUtTribut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVidaUtTribut.TextChanged
        cambios = cambios + 1
        modCosto = True
        btnGuardar.Enabled = True
    End Sub

    Private Sub txtUndProdTribut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios = cambios + 1
    End Sub

    Private Sub txtTDep_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs)
        cambios = cambios + 1
    End Sub

    Private Sub txtValActualTribut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios = cambios + 1
    End Sub
    Private Sub cboDepTribut_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoDepTribut.SelectedIndexChanged
        cambios = cambios + 1
        If cboTipoDepTribut.Text = "No Deprecia" Then
            txtVidaUtTribut.Text = ""
            grupoDepTributaria.Enabled = False
        Else
            txtVidaUtTribut.Text = "1"
            grupoDepTributaria.Enabled = True
            txtVidaUtTribut_LostFocus(sender, e)
        End If
    End Sub
    Private Sub cboDepFin_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoDepFinanc.SelectedIndexChanged
        cambios = cambios + 1
        If cboTipoDepFinanc.Text = "No Deprecia" Then
            grupoDepFinanciera.Enabled = False
            txtUndProdConta.Text = ""
            txtVidaUtConta.Text = ""
        ElseIf cboTipoDepFinanc.Text = "Lineal" Then
            txtVidaUtConta.Enabled = True
            txtVidaUtConta.Text = "1"
            txtUndProdConta.Text = ""
            txtUndProdConta.Enabled = False
            grupoDepFinanciera.Enabled = True
        Else
            txtVidaUtConta.Enabled = False
            txtUndProdConta.Text = "1"
            txtVidaUtConta.Text = ""
            txtUndProdConta.Enabled = True
            grupoDepFinanciera.Enabled = True
        End If
    End Sub
    Private Sub cboDepTribut_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipoDepTribut.LostFocus
        If cboTipoDepTribut.Text = "No Deprecia" Then
            grupoDepTributaria.Enabled = False
        Else
            grupoDepTributaria.Enabled = True
        End If
    End Sub
    Private Sub cboDepFin_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipoDepFinanc.LostFocus
        If cboTipoDepFinanc.Text = "No Deprecia" Then
            grupoDepFinanciera.Enabled = False
        Else
            grupoDepFinanciera.Enabled = True
        End If
    End Sub
    Private Sub btnSucursal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSucursal.Click
        Dim ssql As String = "select suc_codigo as cod, suc_nombre as Nombre from emp_suc where emp_codigo = " + varbleComun.VarCom.codEmpresa.ToString()

        Dim BuscaSuc As New Buscar.frmBuscar
        Dim retnom As New RetNombre.AdcNomb
        dataAcf.UbicaSucursal = BuscaSuc.Buscar(varbleComun.VarCom.strConxSyscod, ssql, "cod", "Nombre", "", "Buscar sucursales", "")
        txtSucursal.Text = retnom.RetornaNombreSucursal(varbleComun.VarCom.codEmpresa, dataAcf.UbicaSucursal, varbleComun.VarCom.strConxSyscod)
        BuscaSuc.Dispose()
        retnom = Nothing
    End Sub
    Private Sub btnCCosto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCosto.Click
        Dim busk As New Syscod.ManSysnetClass
        Dim codigo As String = ""
        Dim nombre As String = ""
        busk.BuscarReferencia("Centro Costo", codigo, nombre)
        txtCCosto.Text = nombre
        dataAcf.CentroCosto = codigo
        busk = Nothing
    End Sub

    Private Sub imgImagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgImagen.Click
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
                txtImagen = Path & "\" & Archivo
                imgImagen.Load(Path & "\" & Archivo)
            End If
        End If
    End Sub

    Private Sub txtContrato_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContrato.KeyPress
        If InStr(1, "0123456789.," & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txtMonto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        If InStr(1, "0123456789.," & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txtDeducible_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDeducible.KeyPress
        If InStr(1, "0123456789.," & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txtPagoM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPagoM.KeyPress
        If InStr(1, "0123456789.," & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub
    Private Sub imgImagen_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles imgImagen.MouseEnter
        ToolTip1.SetToolTip(imgImagen, "Doble clic para Ingresar una imagen")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim busk As New FrmConsDptoSecc()
        Dim res(2) As String
        res = busk.Cargar("Aseguradora")
        txtAsegCod.Text = res(0)
        txtAseguradora.Text = res(1)
        txtContrato.Focus()
    End Sub
    'Private Sub btnParidad_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnParidad.MouseEnter, btnParidad.Click
    '    ToolTip1.SetToolTip(btnParidad, "Ingresar Paridad")
    'End Sub
    Private Sub cboMoneda_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMoneda.LostFocus
        Dim mon As String
        Dim ssql As String
        Dim con As New SqlConnection() ' "server=SISTEMAS\SQLEXPRESS;user id=sa;password=123qweASDZXC;database=DaxSys;pooling=false")
        Dim Condax As New DaxLib.DaxLibBases
        Condax.TipoBase = "10"
        con.ConnectionString = Condax.StrDaxsys
        If cboMoneda.Text = "" Then
            MsgBox("Es necesario que escoja la moneda", MsgBoxStyle.Information)
            Exit Sub
        End If
        mon = cboMoneda.SelectedValue.ToString()
        If mon = "DOL" Then
            txtParidad.Text = "1"
            Exit Sub
        End If
        ssql = "select Caracteristica1  from Syscod where TipoReferencia='ParidadMonetaria' and Abreviación ='" & mon & "' and Descripcion ='" & LSet(txtFechaIng.Text, 10) & "'"
        Dim comando As New SqlCommand(ssql, con)
        Dim consulta As SqlDataReader
        con.Open()
        consulta = comando.ExecuteReader()
        If consulta.Read Then
            txtParidad.Text = consulta(0)
        Else
            txtParidad.Text = "0"
        End If
        con.Close()
    End Sub

    Private Sub cboMoneda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMoneda.SelectedIndexChanged
        cambios += 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub txtFechaInicioS_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFechaInicioS.LostFocus
        Dim fec As Date
        If txtFechaInicioS.Text <> "  /  /" Then
            fec = CDate("31 / 12 / 1900")
            If IsDate(txtFechaInicioS.Text) Then
                If CDate(txtFechaInicioS.Text) < fec Then
                    MsgBox("Ingrese una FechaVálida", MsgBoxStyle.Exclamation)
                    txtFechaInicioS.Focus()
                    txtFechaInicioS.SelectAll()
                End If
            Else
                MsgBox("Ingrese una fecha válida", MsgBoxStyle.Information)
                txtFechaInicioS.Focus()
                txtFechaInicioS.SelectAll()
            End If
        End If
    End Sub

    Private Sub txtFechaFinS_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFechaFinS.LostFocus
        If txtFechaFinS.Text <> "  /  /" Then
            If IsDate(txtFechaFinS.Text) Then
                If CDate(txtFechaInicioS.Text) > CDate(txtFechaFinS.Text) Then
                    MsgBox("La fecha de inicion no puede ser mayor a la de finalización ", MsgBoxStyle.Information)
                    txtFechaInicioS.Focus()
                    txtFechaInicioS.SelectAll()
                End If
            Else
                MsgBox("Ingrese una fecha válida", MsgBoxStyle.Information)
                txtFechaFinS.Focus()
                txtFechaFinS.SelectAll()
            End If
        End If
    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        Dim ssql As String = "exec ADC_REP004 'I','" & txtCodigo.Text & "'"
        Dim imprimir As New ImprimirReportes.FrmImprimir
        imprimir.Impresion(ssql, "REPORTE DE MOVIMIENTOS DE ACTIVOS", "Report1.rdlc")
    End Sub

    Private Sub txtfechaSal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If Txtfechasal.Text = "  /  /" Then Exit Sub
        If Not IsDate(Txtfechasal.Text) Then
            MsgBox("Ingrese una fecha válida!!", MsgBoxStyle.Information)
            Txtfechasal.Focus()
        End If
    End Sub
    Private Sub ControlarBotones()
        Dim consultando As Boolean = (proceso = 2)
        Dim creando As Boolean = (proceso = 1)

        BtnNuevo.Visible = (proceso = 0)
        btnAbrir.Visible = (proceso = 0)
        btnCancelar.Visible = (proceso > 0)
        btnGuardar.Visible = (proceso > 0)
        BtnEliminar.Visible = (proceso = 2)
        BtnSalir.Visible = True
        btnReporte.Visible = (proceso = 2)
        txtCodigo.ReadOnly = (proceso = 2)
    End Sub

    Private Sub Label28_Click(sender As Object, e As EventArgs) Handles Label28.Click

    End Sub

    Private Sub TabCaracteristicas_Click(sender As Object, e As EventArgs) Handles TabCaracteristicas.Click

    End Sub

    Private Sub txtCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigo.KeyDown
        If proceso = 1 Then Return
        If txtCodigo.Text <> "" And e.KeyCode = Keys.Return Then
            AbrirActivo(txtCodigo.Text)
        End If
    End Sub
End Class
