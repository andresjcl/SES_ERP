Imports System.Data.SqlClient
Imports MantenimientoAF
Imports AdcAcfNov
Imports varbleComun
Public Class frmMovimientos

    Dim conectarBDD As New SqlConnection()
    Dim actualizar = 0, cambios As Integer = 0
    Dim docSucursal, OpcDocumento, Codigo, TipoNovedad, NuevaSucursal, respAbrir As String
    Dim NuevoDepto, NuevaSeccion, NuevoResponsable, Observaciones, OpcSucursal As String
    Dim NVvalorresidual, NVvidautil, NVdeterioro, NVrevalorizacion, NVvalorproduccionmes As Double
    Dim DocNumero, numSecuen As Long
    Dim fechaDoc, fechaNov, fecProduc As Date
    Dim cod_suc, cod_doc As String
    Dim strconexion As String
    Dim codigosComp() As String
    Dim accion As String = ""
    Dim op_Val As Boolean
    Dim DatosDocumento As New AdcAcfNov
    'esta variable indica si los valores financieros cambiaron
    'Dim conectarDaxSys As New SqlConnection()
    'Dim strConxAdcom As String
    '******************************************* NUEVO REGISTRO **************************************************************************
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        cambios = 0
        txtCodigo.Enabled = True
        btnCodAct.Enabled = True
        cboDocumento.Enabled = True
        txtNumDoc.Enabled = True
        cboResponsable.Enabled = True
        txtFechaDoc.Enabled = True
        txtSucursalAct.Enabled = True
        txtDptoAct.Enabled = True
        txtSeccionAct.Enabled = True
        cboSucursalNva.Enabled = True
        cboDptoNvo.Enabled = True
        cboSeccionNva.Enabled = True
        txtObservaciones.Enabled = True
        txtNDeter.Enabled = True
        txtNReval.Enabled = True
        txtNValorRes.Enabled = True
        txtFechaProduccion.Enabled = True
        'txtNValProd.Enabled = True
        txtUnidadesProducidas.Enabled = True
        txtNViadUtil.Enabled = True
        btnGuardar.Visible = True
        btnGuardar.Enabled = False
        btnAbrir.Visible = False
        btnNuevo.Visible = False
        btnCerrar.Visible = True
        btnSalir.Visible = False
        cboSeccionNva.Text = ""
        txtFechaDoc.Focus()
        cboDocumento.Text = ""
        cboDptoNvo.Text = ""
        cboResponsable.Text = ""
        cboSeccionNva.Text = ""
        DatosDocumento = New AdcAcfNov(varbleComun.VarCom.strConxAdcom)
    End Sub
    'CARGAR EL COMBO DOCUMENTOS
    Private Sub CargarDoc()
        Dim cmbCmbo As New DaxCbos.DaxCombobx()
        cmbCmbo.DaxCombosDoc("INV", "", False, varbleComun.VarCom.strConxAdcom, cboDocumento)
    End Sub
    'CARGAR EL COMBO RESPONSABLES
    Public Sub llenarResponsables()
        Dim cmbCmbo As New DaxCbos.DaxCombobx()
        cmbCmbo.DaxCombosSuc(varbleComun.VarCom.codEmpresa, False, varbleComun.VarCom.strConxSyscod, cboSucursalNva)

        Dim sSql As String = "Select Codigo, NombreImpresion from Identificacion where EsEmpleado=1 order by Apellidos"
        Try
            Using dataAd As New SqlDataAdapter(sSql, varbleComun.VarCom.strConxAdcom)
                Dim datos As New DataTable
                dataAd.Fill(datos)
                cboResponsable.DataSource = datos
                cboResponsable.DisplayMember = "NombreImpresion"
                cboResponsable.ValueMember = "Codigo"
            End Using
        Catch ex As Exception
            MsgBox("Error al consultar Responsables")
        End Try
    End Sub
    'CARGAR EL COMBO SUCURSAL DOCUMENTO
    Public Sub llenarSucursalDocumento()
        Dim cmbCmbo As New DaxCbos.DaxCombobx()
        cmbCmbo.DaxCombosSuc(varbleComun.VarCom.codEmpresa, False, varbleComun.VarCom.strConxSyscod, cmbSucursalDoc)
    End Sub
    'CARGAR EL COMBO SUCURSAL NUEVA
    Public Sub llenarSucursal()
        Dim cmbCmbo As New DaxCbos.DaxCombobx()
        cmbCmbo.DaxCombosSuc(varbleComun.VarCom.codEmpresa, False, varbleComun.VarCom.strConxSyscod, cboSucursalNva)
    End Sub
    'CARGAR LOS COMBOS DEPARTAMENTO, SECCION
    Public Sub llenarDptoSec(ByVal titulo As String)
        Dim cmbCmbo As New DaxCbos.DaxCombobx()
        cmbCmbo.DaxCombosReferencia("Departamento", varbleComun.VarCom.strConxSyscod, cboDptoNvo)
        cmbCmbo.DaxCombosReferencia("Sección", varbleComun.VarCom.strConxSyscod, cboSeccionNva)
    End Sub
    ' BUSCAR ACTIVOS
    Private Sub btnCodAct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCodAct.Click
        Dim cod As String = ""
        Dim busk As New Buscar.frmBuscar
        Dim ssql As String = "select codigo, nombre from adcacf where EsComponente = 0 order by codigo"
        cod = busk.Buscar(varbleComun.VarCom.strConxAdcom, ssql, "Codigo", "Nombre", "Consulta", "Registro movimiento de activos ")
        If cod <> "" Then
            txtCodigo.Text = cod
        Else
            txtCodigo.Text = ""
        End If
        InformacionAnteriorDelActivo(cod)
        NumeroDocumento(cod)
        cboSeccionNva.Text = ""
        cboDocumento.Text = ""
        cboDptoNvo.Text = ""
        cboResponsable.Text = ""
        cboSeccionNva.Text = ""
        txtFechaDoc.Focus()
    End Sub
    'METODO PARA CONSULTAR EL NUMERO DE DOCUMENTO
    Private Sub NumeroDocumento(ByVal cod As String)
        Dim ssql As String = "select MAX(Doc_numero) from AdcAcfNov "
        Dim conn As New SqlConnection(varbleComun.VarCom.strConxAdcom)
        Dim cmd As New SqlCommand(ssql, conn)
        Dim dat As SqlDataReader

        conn.Open()
        dat = cmd.ExecuteReader()
        If dat.Read Then
            If Not IsDBNull(dat(0)) Then
                numSecuen = dat(0)
            Else
                numSecuen = 0
            End If
        End If
        conectarBDD.Close()
        txtNumDoc.Text = numSecuen + 1
    End Sub
    'METODO PARA BUSCAR LA INFORMACIÓN DEL ACTIVO SELECCIONADO
    Private Sub InformacionAnteriorDelActivo(ByVal codAct As String)
        Dim ssql As String = "exec ADC_REP004 'I','" & txtCodigo.Text & "','" + txtFechaDoc.Value.ToShortDateString() + "'"
        Using DA As SqlDataAdapter = New SqlDataAdapter(ssql, VarCom.strConxAdcom)
            Dim DT As DataTable = New DataTable()
            DA.Fill(DT)
            If (DT.Rows.Count = 0) Then Return
            Dim row As DataRow = DT.Rows(DT.Rows.Count - 1)
            txtSucursalAct.Text = row("Sucursal").ToString()
            txtDptoAct.Text = row("Departamento").ToString()
            txtResAct.Text = row("Responsable").ToString()
            txtSeccionAct.Text = row("Seccion").ToString()
            labNombreActivo.Text = row("Nombre").ToString()
        End Using
    End Sub
    'METODO PARA OBTENER DESCRPCIONES DE LA UBICACIÓN DEL ACTIVO
    Private Sub DescripUbica(ByVal cod As String, ByVal titulo As String)
        If titulo = "Responsables" Then
            Dim sSql As String = ""
            sSql = "Select NombreImpresion from Identificacion where Codigo='" & cod & "'"
            Dim cmdo As New SqlCommand(sSql, conectarBDD)
            Dim dat As SqlDataReader
            If conectarBDD.State <> ConnectionState.Closed Then
                conectarBDD.Close()
            End If
            conectarBDD.Open()
            dat = cmdo.ExecuteReader()
            If dat.Read Then
                txtResAct.Text = dat(0)
            End If
            conectarBDD.Close()
        Else

            Dim sSql As String = "Select Descripcion from Syscod where TipoReferencia='" & titulo & "' and Abreviación='" & cod & "'"
            Dim cmd As New SqlCommand(sSql, conectarBDD)
            Dim dat As SqlDataReader
            If conectarBDD.State <> ConnectionState.Closed Then
                conectarBDD.Close()
            End If
            If conectarBDD.State <> ConnectionState.Closed Then
                conectarBDD.Close()
            End If
            conectarBDD.Open()
            dat = cmd.ExecuteReader()
            If dat.Read Then
                If titulo = "Departamento" Then
                    txtDptoAct.Text = dat(0)
                ElseIf titulo = "Sección" Then
                    txtSeccionAct.Text = dat(0)
                End If
            End If
            conectarBDD.Close()
        End If
    End Sub
    ' VERIFICA QUE SE INGRESE SOLO NUMEROS EN LA CAJA DE TEXTO
    Private Sub txtNumDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress
        If InStr("0123456789.,-" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

#Region "Guardar"
    '*********************************************** GUARDAR REGISRO *******************************************************************
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim band As Boolean
        If Verificar() <> True Then
            Exit Sub
        End If
        If VerificarDep(txtCodigo.Text) = True And op_Val = True Then
            If MsgBox("Si cambia Los valores financieros las depreciaciones existentes serán eliminadas. Desea Continuar?", MsgBoxStyle.YesNo) = vbNo Then
                Exit Sub
            Else : EliminarDep(txtCodigo.Text)
            End If
        End If
        band = Componentes()
        If band = True Then
            If MsgBox("Este activo posee componentes que se moverán junto con " & txtCodigo.Text & vbCrLf & "Desea Continuar?", MsgBoxStyle.YesNo) = vbNo Then Exit Sub
        End If
        ObtenerInformacion(txtCodigo.Text)
        GuardarActualizar("")
        If band = True Then guardarComp("I")
        clear()
        cambios = 0
    End Sub
    Private Function VerificarDep(ByVal cod As String)
        Dim bandera As Boolean = False
        Dim fec As Long = Year(txtFechaDoc.Text) * 100 + Month(txtFechaDoc.Text)
        Dim ssql As String = "Select * from adcacfdep where codigo='" & cod & "' and año*100+mes >=" & fec
        Dim conectarBDD As New SqlConnection(varbleComun.VarCom.strConxAdcom)
        Dim cmd As New SqlCommand(ssql, conectarBDD)
        Dim dat As SqlDataReader = Nothing
        conectarBDD.Open()
        dat = cmd.ExecuteReader()
        If dat.Read Then bandera = True
        conectarBDD.Close()
        Return bandera
    End Function
    Private Sub EliminarDep(ByVal cod As String)
        Dim fec As Long = Year(txtFechaDoc.Text) * 100 + Month(txtFechaDoc.Text)
        Dim ssql As String = "delete from adcacfdep where codigo ='" & cod & "' and año*100+mes >=" & fec
        Dim cmd As New SqlCommand(ssql, conectarBDD)
        If conectarBDD.State = ConnectionState.Open Then conectarBDD.Close()
        conectarBDD.Open()
        cmd.ExecuteNonQuery()
        conectarBDD.Close()
    End Sub
    Private Sub guardarComp(ByVal accion As String)
        Dim conta As Integer = 0
        Do While conta <= codigosComp.Length - 1
            If codigosComp(conta) <> "" Then Codigo = codigosComp(conta) : GuardarActualizar(accion)
            conta += 1
        Loop
    End Sub
    'METODO PARA DETERMINAR SI EL ACTIVO ES COMPUESTO Y CUALES OSN SUS COMPONENTES
    Private Function Componentes()
        Dim band As Boolean = False
        Dim contador As Integer = 0

        Dim ssql As String = "select codigo from adcacf where CodActivoPrincipal='" & txtCodigo.Text.Trim & "'"
        Dim conectarBDD As New SqlConnection(varbleComun.VarCom.strConxAdcom)
        Dim cmd As New SqlCommand(ssql, conectarBDD)
        Dim dat As SqlDataReader
        conectarBDD.Open()
        dat = cmd.ExecuteReader()
        While dat.Read
            band = True
            ReDim Preserve codigosComp(contador)
            codigosComp(contador) = dat(0)
            contador += 1
        End While
        conectarBDD.Close()
        Return band
    End Function
    'METODO PARA VERIFICAR LA INFORMACIÓN
    Private Function Verificar() As Boolean
        Dim ssql As String = ""
        ssql = "select *  from AdcAcfNov where Codigo='" & txtCodigo.Text & "' and NVSucursalNueva='" & cboSucursalNva.SelectedValue & "'"
        ssql += " and opc_documento = '" + OpcDocumento + "' and Doc_numero='" & txtNumDoc.Text & "' and TipoNovedad='MOV_ACT'"
        Dim conectarBDD As New SqlConnection(varbleComun.VarCom.strConxAdcom)
        Dim cmd As New SqlCommand(ssql, conectarBDD)
        Dim dat As SqlDataReader
        conectarBDD.Open()
        dat = cmd.ExecuteReader()
        If dat.Read Then
            txtNumDoc.Text = numSecuen + 1
        End If
        conectarBDD.Close()
        If txtCodigo.Text = "" Then
            MsgBox("Es necesario que ingrese el codigo del activo", MsgBoxStyle.Information)
            txtCodigo.Focus()
            Verificar = False
        ElseIf txtNumDoc.Text = "" Then
            MsgBox("Es necesario que ingrese el número del documento", MsgBoxStyle.Information)
            txtNumDoc.Focus()
            Verificar = False
            'ElseIf cboDocumento.Text = "" Then
            '    MsgBox("Es necesario que escoja el docuemnto", MsgBoxStyle.Information)
            '    cboDocumento.Focus()
            '    Verificar = False
        Else
            Verificar = True
        End If
    End Function
    ' METODO PARA OBTENER LA INFORMACIÓN
    Private Sub ObtenerInformacion(ByVal cod As String)
        OpcSucursal = varbleComun.VarCom.suc
        If cboDocumento.Text <> "" Then OpcDocumento = cboDocumento.SelectedValue.ToString() Else OpcDocumento = ""
        DocNumero = CLng(txtNumDoc.Text)
        Codigo = cod
        fechaDoc = CDate(txtFechaDoc.Text)
        fechaNov = LSet(Now, 10)
        TipoNovedad = "MOV_ACT"
        If cboSucursalNva.Text <> "" Then
            NuevaSucursal = cboSucursalNva.SelectedValue.ToString()
        Else
            NuevaSucursal = ""
        End If
        If cboDptoNvo.Text <> "" Then
            NuevoDepto = cboDptoNvo.SelectedValue.ToString()
        Else
            NuevoDepto = ""
        End If
        If cboSeccionNva.Text <> "" Then
            NuevaSeccion = cboSeccionNva.SelectedValue.ToString()
        Else
            NuevaSeccion = ""
        End If
        If cboResponsable.Text <> "" Then
            NuevoResponsable = cboResponsable.SelectedValue.ToString()
        Else
            NuevoResponsable = ""
        End If
        Observaciones = txtObservaciones.Text
        If txtNValorRes.Text <> "" Then NVvalorresidual = txtNValorRes.Text Else NVvalorresidual = 0
        If txtNViadUtil.Text <> "" Then NVvidautil = txtNViadUtil.Text Else NVvidautil = 0
        If txtNDeter.Text <> "" Then NVdeterioro = txtNDeter.Text Else NVdeterioro = 0
        If txtNReval.Text <> "" Then NVrevalorizacion = txtNReval.Text Else NVrevalorizacion = 0
        If txtUnidadesProducidas.Text <> "" Then NVvalorproduccionmes = txtUnidadesProducidas.Text Else NVdeterioro = 0
        'If txtNValProd.Text <> "" Then NVvalorproduccionmes = txtNValProd.Text Else NVdeterioro = 0
    End Sub
    'METODO PARA GUARDAR EL REGISTRO    
    Private Sub GuardarActualizar(ByVal opcion As String)
        Dim DATNOV As New AdcAcfNov(VarCom.strConxAdcom)
        With DATNOV
            .Codigo = txtCodigo.Text
            .Doc_numero = txtNumDoc.Text
            .Doc_sucursal = OpcSucursal
            .FechaDocumento = fechaDoc
            .FechaNovedad = fechaNov
            .FechaProduccion = txtFechaProduccion.Value
            .NvDepartamentoNvo = NuevoDepto
            .NVdeterioro = NVdeterioro
            .NvResponsable = cboResponsable.SelectedValue
            .NVrevalorizacion = Val(txtNReval.Text)
            .NvSeccionNvo = cboSeccionNva.SelectedValue
            .NVSucursalNueva = cboSucursalNva.SelectedValue
            .NVvalorproduccionmes = Val(txtNValProd.Text)
            .NVvalorresidual = Val(txtNValorRes.Text)
            .NVvidautil = Val(txtNViadUtil.Text)
            .Observaciones = txtObservaciones.Text
            .Opc_documento = OpcDocumento
            .TipoNovedad = TipoNovedad
        End With
        Dim resp As String = DATNOV.Actualizar()
        If resp.Substring(3) = "ERR" Then
            MessageBox.Show("el registro no se actualizo correctamente " + vbCr + resp)
        End If
    End Sub
#End Region

    '****************************METODO PARA INICIALIZAR LOS CAMPOS**************************************************
    Private Sub clear()
        txtCodigo.Text = ""
        txtNumDoc.Text = ""
        cboDocumento.Text = ""
        cboResponsable.Text = ""
        txtObservaciones.Text = ""
        txtSucursalAct.Text = ""
        txtDptoAct.Text = ""
        txtSeccionAct.Text = ""
        cboSucursalNva.Text = ""
        cboDptoNvo.Text = ""
        cboSeccionNva.Text = ""
        txtObservaciones.Text = ""
        txtNDeter.Text = ""
        txtNReval.Text = ""
        txtNValorRes.Text = ""
        'txtNValProd.Text = ""
        txtUnidadesProducidas.Text = ""
        txtFechaProduccion.Text = New Date(1900, 1, 1)
        txtNViadUtil.Text = ""
        txtCodigo.Enabled = False
        btnCodAct.Enabled = False
        cboDocumento.Enabled = False
        txtNumDoc.Enabled = False
        cboResponsable.Enabled = False
        txtFechaDoc.Enabled = False
        cboSucursalNva.Enabled = False
        cboDptoNvo.Enabled = False
        cboSeccionNva.Enabled = False
        txtObservaciones.Enabled = False
        txtNDeter.Enabled = False
        txtNReval.Enabled = False
        txtNValorRes.Enabled = False
        'txtNValProd.Enabled = False
        txtUnidadesProducidas.Enabled = False
        txtFechaProduccion.Enabled = False
        txtNViadUtil.Enabled = False
        btnGuardar.Visible = False
        btnEliminar.Visible = False
        btnAbrir.Visible = True
        btnNuevo.Visible = True
        btnCerrar.Visible = False
        btnSalir.Visible = True
    End Sub


    '************************************************BOTÓN CERRAR*********************************************************************
    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Dim confirmar As Integer = 0
        If cambios > 0 Then
            confirmar = MessageBox.Show("Desea guardar los cambios?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If confirmar = vbYes Then
                Verificar()
                ObtenerInformacion(txtCodigo.Text)
                If actualizar = 1 Then
                    GuardarActualizar("U")
                Else
                    GuardarActualizar("I")
                End If
                clear()
                cambios = 0
                op_Val = False
                actualizar = 0
                accion = ""
            ElseIf confirmar = vbNo Then
                clear()
                cambios = 0
                op_Val = False
                actualizar = 0
                accion = ""
            End If
        Else
            clear()
            cambios = 0
            op_Val = False
            actualizar = 0
            accion = ""
        End If
    End Sub
    '************************************************BOTÓN ELIMINAR************************************************************************
    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim confirmar As Integer
        confirmar = MessageBox.Show("Esta seguro que quiere eliminar el registro?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirmar = vbYes Then
            eliminarMov()
            EliminarDep(txtCodigo.Text)
            clear()
        End If
    End Sub
    Private Sub eliminarMov()
        Dim ssql As String = ""
        Dim DATNOV As New AdcAcfNov(VarCom.strConxAdcom)
        With DATNOV
            .Codigo = txtCodigo.Text
            .Doc_numero = txtNumDoc.Text
            .Doc_sucursal = varbleComun.VarCom.suc
            .Opc_documento = cboDocumento.SelectedValue
            .TipoNovedad = TipoNovedad
        End With
        Dim resp As String = DATNOV.Borrar()
        If resp.Substring(3) = "ERR" Then
            MessageBox.Show("el registro no se eliminó correctamente " + vbCr + resp)
        End If
    End Sub

    '*************************************************BOTÓN ABRIR*********************************************************************
    Private Sub btnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrir.Click

        Dim buskMov As New frmAbrirMovAct()
        Dim res As ClassMov = New ClassMov()
        res = buskMov.Cargar()
        If res.CodigoActivo = "" Then Return
        accion = "abrir"
        txtCodigo.Text = res.CodigoActivo
        cboDocumento.SelectedValue = res.Opc_documento
        txtNumDoc.Text = res.Doc_numero.ToString()
        Try
            txtFechaDoc.Value = res.FechaDoc
        Catch
            txtFechaDoc.Value = New Date(1900, 1, 1)
        End Try

        cmbSucursalDoc.SelectedValue = res.DocSucursal

        InformacionAnteriorDelActivo(txtCodigo.Text)
        VisualizarDocumentoConsultado()
        'ConsUbica(txtCodigo.Text)
        txtCodigo.Enabled = True
        txtCodigo.ReadOnly = True
        btnCodAct.Enabled = False
        cboDocumento.Enabled = True
        txtNumDoc.Enabled = True
        cboResponsable.Enabled = True
        txtFechaDoc.Enabled = True
        txtSucursalAct.Enabled = True
        txtDptoAct.Enabled = True
        txtSeccionAct.Enabled = True
        cboSucursalNva.Enabled = True
        cboDptoNvo.Enabled = True
        cboSeccionNva.Enabled = True
        txtObservaciones.Enabled = True
        txtNDeter.Enabled = True
        txtNReval.Enabled = True
        txtNValorRes.Enabled = True
        txtUnidadesProducidas.Enabled = True
        txtFechaProduccion.Enabled = True
        'txtNValProd.Enabled = True
        txtNViadUtil.Enabled = True
        btnGuardar.Visible = True
        btnGuardar.Enabled = False
        btnAbrir.Visible = False
        btnNuevo.Visible = False
        btnCerrar.Visible = True
        btnSalir.Visible = False
        btnEliminar.Visible = True
        cambios = 0
    End Sub
    'METODO PARA CONSULTAR EL MOVIMIENTO DE UN ACTIVO
    Private Sub VisualizarDocumentoConsultado()

        Dim ssql As String = " Codigo='" + Trim(txtCodigo.Text) & "' "
        ssql += " AND Doc_sucursal ='" + cmbSucursalDoc.SelectedValue + "' and Opc_documento = '" + cboDocumento.SelectedValue + "' and Doc_numero= " + Val(txtNumDoc.Text).ToString() + " and Codigo = '" + Codigo + "' "
        DatosDocumento = New AdcAcfNov(varbleComun.VarCom.strConxAdcom)
        DatosDocumento = AdcAcfNov.Buscar(ssql)

        If IsNothing(DatosDocumento) Then
            DatosDocumento = New AdcAcfNov(VarCom.strConxAdcom)
            Return
        End If

        With DatosDocumento
            txtNValorRes.Text = FormatNumber(.NVrevalorizacion)
            txtNViadUtil.Text = FormatNumber(.NVvidautil)
            txtNDeter.Text = FormatNumber(.NVdeterioro)
            txtNReval.Text = FormatNumber(.NVrevalorizacion)
            txtUnidadesProducidas.Text = FormatNumber(.NVvalorproduccionmes)
            txtFechaProduccion.Value = .FechaProduccion
            actualizar = 1
            DescripUbica(.NvResponsable, "Responsables")
            DescripUbica(.NvDepartamentoNvo, "Departamento")
            DescripUbica(.NvSeccionNvo, "Sección")
            cboResponsable.Text = txtResAct.Text
        End With
        conectarBDD.Open()
    End Sub
    Private Sub ConsUbica(ByVal cod As String)
        If txtResAct.Text = "" Then
            ConsAcf("select responsable from adcacf where codigo='" & cod & "'", txtResAct, "Responsables")
        End If
        If txtSucursalAct.Text = "" Then
            ConsAcf("select ubicaSucursal from adcacf where codigo='" & cod & "'", txtSucursalAct, "")
        End If
        If txtDptoAct.Text = "" Then
            ConsAcf("select UbicaDepartamento from adcacf where codigo='" & cod & "'", txtDptoAct, "Departamento")
        End If
        If txtSeccionAct.Text = "" Then
            ConsAcf("select UbicaSeccion from adcacf where codigo='" & cod & "'", txtSeccionAct, "Sección")
        End If
        cboResponsable.Text = txtResAct.Text
    End Sub
    Private Sub ConsAcf(ByVal cons As String, ByVal obj As Label, ByVal cat As String)
        Dim ssql As String = cons
        Dim cmd As New SqlCommand(ssql, conectarBDD)
        Dim dat As SqlDataReader = Nothing
        If conectarBDD.State = ConnectionState.Open Then conectarBDD.Close()
        conectarBDD.Open()
        dat = cmd.ExecuteReader()
        If dat.Read Then
            If Not IsDBNull(dat(0)) Then obj.Text = dat(0) : DescripUbica(dat(0), cat)
        End If
        conectarBDD.Close()
    End Sub
    'REGISTRA SI EXISTE ALGUN CAMBIO EN LOS CAMPOS DE LAPANTALLA Y ACTIVA EL BOTON GUARDAR
    Private Sub cboDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios += 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub txtNumDoc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumDoc.TextChanged
        cambios += 1
        'btnGuardar.Enabled = True
        'If txtNumDoc.Text <> "" And accion <> "abrir" Then VisualizarDocumentoConsultado()
    End Sub

    Private Sub cboResponsable_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios += 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub txtFechaDoc_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFechaDoc.ValueChanged
        cambios += 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub cboSucursalNva_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios += 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub cboDptoNvo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios += 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub cboSeccionNva_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios += 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub txtObservaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios += 1
        btnGuardar.Enabled = True
    End Sub
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Dispose()
    End Sub

    Private Sub frmMovimientos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim coneccion As New DaxLib.DaxLibBases
        '        coneccion.TipoBase = "10"
        '       strConxAdcom = coneccion.StrAdcom
        'conectarBDD.ConnectionString = VarCom.strConxAdcom
        'conectarDaxSys.ConnectionString = VarCom.strConxSyscod
        'strconexion = coneccion.StrAdcom
        cambios = 0
        CargarDoc()
        llenarResponsables()
        llenarDptoSec("Departamento")
        llenarDptoSec("Sección")
        llenarSucursal()
        llenarSucursalDocumento()
        cboSucursalNva.Text = ""
        cboDptoNvo.Text = ""
        cboSeccionNva.Text = ""
        cboResponsable.Text = ""
        cboDocumento.Text = ""
        txtCodigo.Focus()
    End Sub
    Public Sub AbrirMov()
        Me.ShowDialog()
    End Sub

    Private Sub cboDocumento_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios += 1
        btnGuardar.Enabled = True
    End Sub
    Private Sub txtNValorRes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNValorRes.TextChanged
        cambios += 1
        btnGuardar.Enabled = True
        op_Val = True
    End Sub

    Private Sub txtNViadUtil_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNViadUtil.TextChanged
        cambios += 1
        btnGuardar.Enabled = True
        op_Val = True
    End Sub

    Private Sub txtNDeter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNDeter.TextChanged
        cambios += 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub txtNReval_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNReval.TextChanged
        cambios += 1
        btnGuardar.Enabled = True
        op_Val = True
    End Sub

    Private Sub txtNValProd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNValProd.TextChanged
        cambios += 1
        btnGuardar.Enabled = True
        op_Val = True
    End Sub

    Private Sub cboResponsable_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboResponsable.SelectedIndexChanged
        cambios += 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub cboDocumento_SelectedIndexChanged_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDocumento.SelectedIndexChanged
        cambios += 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub cboSucursalNva_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSucursalNva.SelectedIndexChanged
        cambios += 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub cboDptoNvo_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDptoNvo.SelectedIndexChanged
        cambios += 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub txtObservaciones_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios += 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub txtObservaciones_TextChanged_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtObservaciones.TextChanged
        cambios += 1
        btnGuardar.Enabled = True
    End Sub

    Private Sub txtFechaProduccion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If txtFechaProduccion.Text <> "  /  /" Then
            If Not IsDate(txtFechaProduccion.Text) Then MsgBox("Ingrese una fecha válida!!", MsgBoxStyle.Information) : txtFechaProduccion.Focus()
        End If
    End Sub

    Private Sub txtUnidadesProducidas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUnidadesProducidas.KeyPress
        If InStr(1, "0123456789.," & Chr(8) & Chr(13), e.KeyChar) = 0 Then e.KeyChar = ""
    End Sub

    Private Sub txtCodigo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigo.GotFocus
        cboSeccionNva.Text = ""
        cboDocumento.Text = ""
        cboDptoNvo.Text = ""
        cboResponsable.Text = ""
        cboSeccionNva.Text = ""
    End Sub

    Private Sub Label22_Click(sender As Object, e As EventArgs) Handles Label22.Click

    End Sub
End Class
