Option Strict Off
Option Explicit On
Imports System.Data
Imports DaxClasificadores
Imports DattCom


Friend Class CTBP01_1
    Inherits System.Windows.Forms.Form

    Public EsNuevo As Boolean = True
    Dim CodigoCta As String
    Dim ctaActual As New Cuenta
    Dim Sw As Boolean
    Dim ctr As Short
    Dim RsCta As DataTable
    Dim CtaIni, Qaccion As String
    Dim NivelIni, GrupoIni As Short
    Dim txtCta As String
    Dim Arbolito As System.Windows.Forms.TreeView
    Dim CtaPadre As String
    Const Nombre As String = "Maestro de Cuentas contables"
    Dim TeniaConcepto As Boolean
    Dim TxtCtrl As New Collection
    Dim txtCodCta(9) As TextBox
    Dim ConxAdcom As New SqlClient.SqlConnection

    ' ✅ DECLARAR EL LABEL COMO VARIABLE DE CLASE
    Private lblCodigoCta As Label

    Public Sub CrearCuenta(ByRef codigo As String, ByRef NivelCta As Short, ByRef Grupo As Short, ByRef Accion As String, ByRef Arbol As System.Windows.Forms.TreeView)
        ' ✅ ASIGNAR VARIABLES
        Arbolito = Arbol
        CtaIni = codigo
        NivelIni = NivelCta
        GrupoIni = Grupo

        ' ✅ ESTABLECER SI ES NUEVO O MODIFICACIÓN
        Select Case Accion
            Case "N", "I"
                EsNuevo = True
                txtCta = codigo
            Case "M"
                EsNuevo = False
                txtCta = codigo
                CtaPadre = QuePadreDeCta(codigo, NivelCta)

                ' ✅ CARGAR LA CUENTA AQUÍ (IMPORTANTE)
                ctaActual = New Cuenta()
                ctaActual.Cargar(codigo)

                ' ✅ DEBUG: Verificar que se cargó
                System.Diagnostics.Debug.WriteLine($"Cuenta cargada: {ctaActual.codigo} - {ctaActual.Nombre}")
                System.Diagnostics.Debug.WriteLine($"Nivel: {ctaActual.Nivel}, Grupo: {ctaActual.Grupo}")
        End Select

        Qaccion = Accion

        ' ✅ MOSTRAR EL FORMULARIO
        Me.ShowDialog()
    End Sub



    ' ✅ MÉTODO QuePadreDeCta
    Private Function QuePadreDeCta(ByVal ctaCodigo As String, ByVal nivel As Integer) As String
        If nivel <= 1 Then Return ""

        Dim digitosPorNivel As String = ""
        Try
            digitosPorNivel = emp.CtaNumDigNivel
        Catch
            digitosPorNivel = "12222"
        End Try

        Dim longitudPadre As Integer = 0
        For i As Integer = 0 To nivel - 2
            If i < digitosPorNivel.Length Then
                longitudPadre += Val(Mid(digitosPorNivel, i + 1, 1))
            Else
                longitudPadre += 2
            End If
        Next

        If longitudPadre <= 0 OrElse longitudPadre >= ctaCodigo.Length Then Return ""

        Return ctaCodigo.Substring(0, longitudPadre)
    End Function

    Private Sub btnsalir_Click()
        If MsgBox("Esta seguro que desea cancelar, se perdera toda la información", 36) = MsgBoxResult.Yes Then Me.Close()
    End Sub

    Private Sub Chkcompras_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Chkcompras.CheckStateChanged
        FuncionCuenta()
    End Sub

    Private Sub chkDeAgrupacion_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkDeAgrupacion.CheckStateChanged
        FuncionCuenta()
    End Sub

    Private Sub chkegresobanco_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkegresobanco.CheckStateChanged
        FuncionCuenta()
    End Sub

    Private Sub chkfacturacion_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkfacturacion.CheckStateChanged
        FuncionCuenta()
    End Sub

    Private Sub Chkingresobanco_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Chkingresobanco.CheckStateChanged
        FuncionCuenta()
    End Sub

    Private Sub dcGruCon_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles dcGruCon.SelectedIndexChanged
        FuncionCuenta()
    End Sub

    Private Sub DcModulo_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles DcModulo.SelectedIndexChanged
        FuncionCuenta()
    End Sub

    Private Sub FuncionCuenta()
        If chkDeAgrupacion.CheckState = 0 Then
            Frconceptos.Enabled = True
            If Chkingresobanco.CheckState <> 0 Then
                chkegresobanco.CheckState = System.Windows.Forms.CheckState.Unchecked
                Chkcompras.CheckState = System.Windows.Forms.CheckState.Unchecked
                chkfacturacion.CheckState = System.Windows.Forms.CheckState.Unchecked
            ElseIf chkegresobanco.CheckState <> 0 Then
                Chkingresobanco.CheckState = System.Windows.Forms.CheckState.Unchecked
                Chkcompras.CheckState = System.Windows.Forms.CheckState.Unchecked
                chkfacturacion.CheckState = System.Windows.Forms.CheckState.Unchecked
            ElseIf Chkcompras.CheckState <> 0 Then
                Chkingresobanco.CheckState = System.Windows.Forms.CheckState.Unchecked
                chkfacturacion.CheckState = System.Windows.Forms.CheckState.Unchecked
                chkegresobanco.CheckState = System.Windows.Forms.CheckState.Unchecked
            ElseIf chkfacturacion.CheckState <> 0 Then
                Chkingresobanco.CheckState = System.Windows.Forms.CheckState.Unchecked
                chkegresobanco.CheckState = System.Windows.Forms.CheckState.Unchecked
                Chkcompras.CheckState = System.Windows.Forms.CheckState.Unchecked
            End If
        Else
            Frconceptos.Enabled = False
            Chkingresobanco.CheckState = System.Windows.Forms.CheckState.Unchecked
            chkegresobanco.CheckState = System.Windows.Forms.CheckState.Unchecked
            Chkcompras.CheckState = System.Windows.Forms.CheckState.Unchecked
            chkfacturacion.CheckState = System.Windows.Forms.CheckState.Unchecked
        End If
    End Sub



    Private Sub OrganizarNiveles()
        Dim Temp As Short = 0
        Dim I As Short = 0
        Dim CtaNumNiveles As Short
        Dim CtaNumDigNivel As String

        Button1.Visible = False
        limpiar()
        Temp = 1

        ' ✅ OBTENER EL NÚMERO DE NIVELES DESDE LA BASE DE DATOS (SIEMPRE)
        Try
            CtaNumNiveles = emp.CtaNumNiveles
        Catch ex As Exception
            CtaNumNiveles = 0
        End Try

        Try
            CtaNumDigNivel = emp.CtaNumDigNivel
        Catch ex As Exception
            CtaNumDigNivel = ""
        End Try

        ' ✅ SI NO HAY CONFIGURACIÓN EN LA BD, USAR VALORES POR DEFECTO
        If CtaNumNiveles <= 0 Then
            CtaNumNiveles = 5
            CtaNumDigNivel = "12222"
        End If

        ' ✅ SI CtaNumDigNivel ESTÁ VACÍO, USAR VALOR POR DEFECTO
        If String.IsNullOrEmpty(CtaNumDigNivel) Then
            CtaNumDigNivel = "12222"
        End If

        ' ✅ ASEGURAR QUE CtaNumDigNivel TENGA SUFICIENTES DÍGITOS
        While CtaNumDigNivel.Length < CtaNumNiveles
            CtaNumDigNivel = CtaNumDigNivel & "2"
        End While

        ' ✅ OBTENER EL CÓDIGO FUENTE
        Dim codigoFuente As String = ""
        If ctaActual IsNot Nothing AndAlso ctaActual.codigo <> "" Then
            codigoFuente = ctaActual.codigo
        ElseIf Not String.IsNullOrEmpty(CtaIni) Then
            codigoFuente = CtaIni
        ElseIf Not String.IsNullOrEmpty(txtCta) Then
            codigoFuente = txtCta
        End If

        System.Diagnostics.Debug.WriteLine($"OrganizarNiveles - CtaNumNiveles: {CtaNumNiveles}, CtaNumDigNivel: {CtaNumDigNivel}, codigoFuente: {codigoFuente}")

        Dim posX As Integer = 65

        For I = 1 To 8
            With txtCodCta(I)
                .Visible = True
                .MaxLength = 1
                If I <= CtaNumNiveles AndAlso I <= CtaNumDigNivel.Length Then
                    .MaxLength = Val(Mid(CtaNumDigNivel, I, 1))
                    If .MaxLength <= 0 Then .MaxLength = 2
                Else
                    .MaxLength = 2
                End If

                .Width = 12 + (.MaxLength - 1) * 6 + 6
                If .Width < 18 Then .Width = 18
                If .Width > 28 Then .Width = 28
                .Height = 20

                .Left = posX
                posX = posX + .Width + 2

                .Top = 60
                .Font = New Font("Segoe UI", 9, FontStyle.Bold)
                .TextAlign = HorizontalAlignment.Center

                ' ✅ ASIGNAR VALORES
                If EsNuevo Then
                    If I <= NivelIni AndAlso Not String.IsNullOrEmpty(txtCta) Then
                        .Text = Mid(txtCta, Temp, .MaxLength)
                        .ReadOnly = True
                        .BackColor = Color.FromArgb(240, 248, 255)
                        .ForeColor = Color.FromArgb(0, 0, 64)
                    Else
                        .Text = ""
                        .ReadOnly = False
                        .BackColor = Color.FromArgb(220, 255, 220)
                        .ForeColor = Color.FromArgb(0, 64, 0)
                    End If
                Else
                    If I <= NivelIni AndAlso Not String.IsNullOrEmpty(codigoFuente) Then
                        If codigoFuente.Length >= Temp + .MaxLength - 1 Then
                            .Text = Mid(codigoFuente, Temp, .MaxLength)
                            .ReadOnly = True
                            .BackColor = Color.FromArgb(240, 248, 255)
                            .ForeColor = Color.FromArgb(0, 0, 64)
                        Else
                            .Text = ""
                            .ReadOnly = True
                            .BackColor = Color.FromArgb(245, 245, 245)
                            .ForeColor = Color.FromArgb(128, 128, 128)
                        End If
                    Else
                        .Text = ""
                        .ReadOnly = True
                        .BackColor = Color.FromArgb(245, 245, 245)
                        .ForeColor = Color.FromArgb(128, 128, 128)
                    End If
                End If

                .BringToFront()
            End With
            Temp = Temp + txtCodCta(I).MaxLength
        Next

        ' ✅ OCULTAR LOS QUE EXCEDEN EL NÚMERO DE NIVELES
        For I = CtaNumNiveles + 1 To 8
            txtCodCta(I).Visible = False
        Next

        ' ✅ CONFIGURAR EL BOTÓN GENERADOR
        If EsNuevo Then
            dcGruCon.SelectedIndex = GrupoIni - 1
            txtCodCta(NivelIni).ReadOnly = False
            txtCodCta(NivelIni).BackColor = Color.FromArgb(220, 255, 220)
            Button1.Left = txtCodCta(NivelIni).Left
            Button1.Width = txtCodCta(NivelIni).Width
            Button1.Visible = True
            Button1.Top = txtCodCta(NivelIni).Top + txtCodCta(NivelIni).Height + 1
            Button1.Text = NivelIni.ToString()
            Button1.BackColor = Color.FromArgb(255, 255, 200)
            txtCodCta(NivelIni).Focus()
        Else
            If ctaActual IsNot Nothing AndAlso ctaActual.codigo <> "" Then
                CargarDatos()
                txtNomCta.Focus()
                txtNomCta.SelectAll()
            End If
        End If

        Me.Refresh()
    End Sub


    Private Sub existenregistros()
        If RsCta.Rows.Count > 0 Then
            CargarDatos()
        End If
    End Sub

    Sub CargarDatos()
        Dim Aux() As String
        On Error Resume Next
        limpiar()
        Dim Temp, I, j As Short

        If ctaActual IsNot Nothing AndAlso ctaActual.codigo > "" Then
            With ctaActual
                Temp = 1
                txtCta = .codigo
                CodigoCta = txtCta

                ' ✅ 1. CÓDIGO DE CUENTA (solo si los TextBox están vacíos)
                For I = 1 To emp.CtaNumNiveles
                    If I <= .Nivel Then
                        ' ✅ Si el TextBox ya tiene texto, no sobrescribir
                        If String.IsNullOrEmpty(txtCodCta(I).Text) Then
                            txtCodCta(I).Text = Mid(txtCta, Temp, txtCodCta(I).MaxLength)
                        End If
                        Temp = Temp + txtCodCta(I).MaxLength
                    Else
                        txtCodCta(I).Text = ""
                    End If
                Next

                ' ✅ 2. DATOS BÁSICOS
                txtNomCta.Text = .Nombre
                CtaAlterna.Text = .CodigoAlterno

                ' ✅ 3. GRUPO CONTABLE
                dcGruCon.SelectedIndex = CDbl(.Grupo) - 1

                ' ✅ 4. MODULO RELACIONADO
                DcModulo.Text = .ModuloAuxiliar

                ' ✅ 5. ES CUENTA DE AGRUPACIÓN
                chkDeAgrupacion.CheckState = IIf(.Agrupacion, 1, 0)

                ' ✅ 6. PROPIEDADES COMO CONCEPTO
                Chkcompras.CheckState = IIf(.ConceptoCompras, 1, 0)
                chkfacturacion.CheckState = IIf(.ConceptoVentas, 1, 0)
                chkegresobanco.CheckState = IIf(.ConceptoBcoEgreso, 1, 0)
                Chkingresobanco.CheckState = IIf(.ConceptoBcoIngreso, 1, 0)

                ' ✅ 7. GRAVADO CON IVA / TIPO SERVICIOS SRI / TIPO BIENES SRI
                CargarConcepto()

                ' ✅ 8. TIPO DE PRESUPUESTO
                Select Case .TipoPresu
                    Case "F"
                        opMenFij.Checked = True
                    Case "V"
                        opMenVar.Checked = True
                    Case Else
                        opSinPre.Checked = True
                End Select

                ' ✅ 9. CLAVES AGRUPACIÓN NIIFS - SRI
                txtC1.Text = .ClaveAux1
                txtC2.Text = .ClaveAux2
                txtC3.Text = .ClaveAux3
                txtC4.Text = .ClaveAux4

                ' ✅ 10. CLASIFICADORES CONTABLES
                ' ✅ PRIMERO: LIMPIAR TODOS LOS CHECKS
                For j = 0 To Clasificadores.Items.Count - 1
                    Clasificadores.SetItemChecked(j, False)
                Next

                ' ✅ SEGUNDO: MARCAR LOS QUE CORRESPONDEN
                Aux = Split(.Clasificadores, ";")
                If UBound(Aux) > 0 Then
                    For I = 0 To UBound(Aux)
                        If Not String.IsNullOrEmpty(Aux(I)) Then
                            For j = 0 To Clasificadores.Items.Count - 1
                                If Aux(I).Trim() = Clasificadores.Items(j).ToString().Trim() Then
                                    Clasificadores.SetItemChecked(j, True)
                                    Exit For
                                End If
                            Next j
                        End If
                    Next I
                End If

                ' ✅ AJUSTAR ALTURA DESPUÉS DE MARCAR
                AjustarAlturaCheckedListBox()

                ' ✅ 11. EN PRODUCCIÓN EL VALOR ES DE
                btnNoProduccion.Checked = False
                Select Case .tipoCosto
                    Case "MO"
                        btnMO.Checked = True
                    Case "CD"
                        btnCD.Checked = True
                    Case "CI"
                        btnCI.Checked = True
                    Case Else
                        btnNoProduccion.Checked = True
                End Select

                ' ✅ 12. DETALLE
                Formatodetalle.Text = .Detalle

                ' ✅ 13. USUARIO
                Me.Text = Nombre & "-" & .usuario
            End With
        End If

        ' ✅ 14. HABILITAR/DESHABILITAR SEGÚN AGRUPACIÓN
        FuncionCuenta()
    End Sub

    Private Sub btnGuardar_Click()
        Dim Lon As Short
        Dim j As Short
        Dim cod As String
        Dim Classi As String
        Dim TTIPOCOS As String

        CodigoCta = CodCta()
        Lon = Len(CodigoCta)
        If ValidarCta() Then
            With ctaActual
                .codigo = CodigoCta
                .Nombre = txtNomCta.Text
                .Grupo = CStr(dcGruCon.SelectedIndex + 1)
                .CodigoAlterno = CtaAlterna.Text
                .Agrupacion = (chkDeAgrupacion.CheckState > 0)

                If opMenFij.Checked Then
                    .TipoPresu = "F"
                ElseIf opMenVar.Checked Then
                    .TipoPresu = "V"
                Else
                    .TipoPresu = ""
                End If
                .ClaveAux1 = txtC1.Text
                .ClaveAux2 = txtC2.Text
                .ClaveAux3 = txtC3.Text
                .ClaveAux4 = txtC4.Text

                cod = ""
                For j = 0 To Clasificadores.Items.Count - 1
                    If Clasificadores.GetItemChecked(j) = True Then
                        cod = cod & Clasificadores.Items(j) & ";"
                    End If
                Next j
                .Clasificadores = cod
                Classi = cod
                .Nivel = Nivel(CodigoCta)
                .usuario = DattCom.DatosUsuario.Identifica
                .ConceptoCompras = Chkcompras.CheckState
                .ConceptoVentas = chkfacturacion.CheckState
                .ConceptoBcoEgreso = chkegresobanco.CheckState
                .ConceptoBcoIngreso = Chkingresobanco.CheckState
                .Detalle = Formatodetalle.Text
                .ModuloAuxiliar = DcModulo.Text
                .CuentaPadre = CtaPadre
                .tipoCosto = ""
                If btnMO.Checked Then .tipoCosto = "MO"
                If btnCD.Checked Then .tipoCosto = "CD"
                If btnCI.Checked Then .tipoCosto = "CI"
                TTIPOCOS = .tipoCosto
            End With
            ctaActual.Guardar()

            If Chkcompras.CheckState <> 0 Or chkfacturacion.CheckState <> 0 Or chkegresobanco.CheckState <> 0 Or Chkingresobanco.CheckState <> 0 Then
                GrabarConcepto()
            End If

            If (chkDeAgrupacion.CheckState > 0) Then
                cod = "UPDATE AdcCta SET "
                cod = cod & " Cta_tipopresu = '" & Trim(TipoPre) & "' "
                cod = cod & ", Cta_claveaux1 ='" & Trim(txtC1.Text) & "' "
                cod = cod & ", Cta_claveaux2 ='" & Trim(txtC2.Text) & "' "
                cod = cod & ", Cta_claveaux3 ='" & Trim(txtC3.Text) & "' "
                cod = cod & ", Cta_claveaux4 ='" & Trim(txtC4.Text) & "' "
                cod = cod & ", clasificadores ='" & Trim(Classi) & "' "
                cod = cod & ", moduloauxiliar ='" & Trim(DcModulo.Text) & "' "
                cod = cod & ", tipoCosto ='" & Trim(TTIPOCOS) & "' "
                cod = cod & " where substring(cta_codigo,1," & Lon & ") = '" & CodigoCta & "'"

                DattCom.SqlDatos.ejecutarComando(cod, datosEmpresa.strConxAdcom)
            End If
        End If

        If (chkDeAgrupacion.CheckState = 0) Then
            If Qaccion = "N" Or Qaccion = "I" Then InsertarEnArbol()
            If Qaccion = "M" Then ArreglarArbol()
        End If
        Me.Close()
    End Sub

    Private Sub GrabarConcepto()
        Dim serv As New ClassDoc.Servicios(datosEmpresa.strConxAdcom)
        serv = ClassDoc.Servicios.Buscar(" sev_codigo = '" + CodigoCta + "'")
        With serv
            .Sev_codigo = CodigoCta
            .Sev_nombre = txtNomCta.Text
            .Sev_unimed = "UND"
            .Sev_precvta = 0
            .Sev_descuen = 0
            .Sev_fecfindes = CDate("00:00")
            .Sev_fecinides = CDate("00:00")
            .Sev_idcta = CodigoCta
            .Sev_idcta2 = ""
            .Sev_idcta3 = ""
            .Sev_idcta4 = ""
            .Sev_SriBien = opbienes.Checked
            .Sev_sniva = chiva.CheckState
            .Sev_TipoCos = ""
            .Sev_TipoSerSri = ""
            .sev_compras = Chkcompras.CheckState
            .sev_ventas = chkfacturacion.CheckState
            .sev_ingbanco = Chkingresobanco.CheckState
            .sev_egrbanco = chkegresobanco.CheckState
            .Sev_Hotel = False
            .sev_escontable = True
            .Actualizar()
        End With
        serv = Nothing
    End Sub

    Private Sub CargarConcepto()
        Dim serv As New ClassDoc.Servicios(datosEmpresa.strConxAdcom)
        serv = ClassDoc.Servicios.Buscar(" Sev_codigo = '" + CodigoCta + "'")

        If serv IsNot Nothing AndAlso serv.Sev_codigo > "" Then
            With serv
                opbienes.Checked = .Sev_SriBien
                If .Sev_sniva = True Then
                    chiva.CheckState = System.Windows.Forms.CheckState.Checked
                Else
                    chiva.CheckState = System.Windows.Forms.CheckState.Unchecked
                End If
                Chkcompras.CheckState = IIf(.sev_compras, 1, 0)
                chkfacturacion.CheckState = IIf(.sev_ventas, 1, 0)
                Chkingresobanco.CheckState = IIf(.sev_ingbanco, 1, 0)
                chkegresobanco.CheckState = IIf(.sev_egrbanco, 1, 0)
            End With
            TeniaConcepto = True
        Else
            TeniaConcepto = False
        End If
        serv = Nothing
    End Sub

    Private Sub ArreglarArbol()
        On Error Resume Next
        Arbolito.Nodes.Remove(Arbolito.SelectedNode)
        InsertarEnArbol()
        Arbolito.Update()
        Arbolito.Sort()
    End Sub

    Private Sub InsertarEnArbol()
        Dim Aux As String
        On Error Resume Next
        With Arbolito.Nodes
            Aux = QuePadreDeCta(CodigoCta, Nivel(CodigoCta))
            If Aux = "" Then
                .Find("M" & Trim(CStr(GrupoIni)), True)(0).Nodes.Add("C" & Trim(CodigoCta), CodigoCta & "  " & txtNomCta.Text, 2, 3)
            Else
                If (chkDeAgrupacion.CheckState > 0) Then
                    .Find("C" & Aux, True)(0).Nodes.Add("C" & Trim(CodigoCta), CodigoCta & "  " & txtNomCta.Text, 2, 3)
                Else
                    .Find("C" & Aux, True)(0).Nodes.Add("C" & Trim(CodigoCta), CodigoCta & "  " & txtNomCta.Text, 4, 5)
                End If
            End If
        End With
    End Sub

    Private Function ValidarCta() As Boolean
        Dim I As Short
        ValidarCta = True
        For I = 1 To emp.CtaNumNiveles
            If Len(txtCodCta(I).Text) < CDbl(Mid(emp.CtaNumDigNivel, I, 1)) And txtCodCta(I).Visible = True Then
                ValidarCta = False
                MsgBox("Los dígitos de la cuenta están mal registrados", MsgBoxStyle.Critical, Nombre)
                Exit Function
            End If
        Next I
        If EsNuevo And LeerCuenta(CodigoCta) = True Then
            MsgBox("La cuenta ha registrar ya existe", MsgBoxStyle.Critical, Nombre)
            ValidarCta = False
        End If
        If txtNomCta.Text = "" Then MsgBox("Debe dar un nombre a la cuenta", MsgBoxStyle.Critical, Nombre) : ValidarCta = False
        Dim serv As New ClassDoc.Servicios
        If Not (Chkcompras.CheckState <> 0 Or chkfacturacion.CheckState <> 0 Or chkegresobanco.CheckState <> 0 Or Chkingresobanco.CheckState <> 0) And TeniaConcepto Then
            If serv.ServUsado(CodigoCta) = True Then MsgBox("No se puede eliminar el Concepto creado por la cuenta" & vbCr & "Existen documentos que utilizan este concepto", MsgBoxStyle.Critical) : ValidarCta = False
        End If
        serv = Nothing
    End Function

    Private Function CodCta() As String
        Dim Temp As String = ""
        Dim I As Short
        For I = 1 To emp.CtaNumNiveles
            Temp = Temp & txtCodCta(I).Text
        Next
        CodCta = Temp
    End Function

    'Sub limpiar()
    '    Dim I As Short
    '    For I = 1 To emp.CtaNumNiveles
    '        txtCodCta(I).Text = ""
    '    Next
    '    txtNomCta.Text = ""
    '    CtaAlterna.Text = ""
    '    txtC1.Text = ""
    '    txtC2.Text = ""
    '    txtC3.Text = ""
    '    txtC4.Text = ""
    '    TeniaConcepto = False

    '    chkegresobanco.CheckState = System.Windows.Forms.CheckState.Unchecked
    '    Chkcompras.CheckState = System.Windows.Forms.CheckState.Unchecked
    '    chkfacturacion.CheckState = System.Windows.Forms.CheckState.Unchecked
    '    Chkingresobanco.CheckState = System.Windows.Forms.CheckState.Unchecked

    '    chiva.CheckState = System.Windows.Forms.CheckState.Checked
    '    Option1.Checked = True
    '    opbienes.Checked = False

    '    opSinPre.Checked = True
    '    DcModulo.Text = ""
    '    Formatodetalle.Text = ""

    '    For I = 0 To Clasificadores.Items.Count - 1
    '        Clasificadores.SetItemChecked(I, False)
    '    Next

    '    btnNoProduccion.Checked = True
    '    btnMO.Checked = False
    '    btnCD.Checked = False
    '    btnCI.Checked = False
    '    chkDeAgrupacion.CheckState = System.Windows.Forms.CheckState.Unchecked
    'End Sub

    Sub limpiar()
        Dim I As Short

        ' ✅ LIMPIAR TEXTBOX DE CÓDIGO
        For I = 1 To emp.CtaNumNiveles
            txtCodCta(I).Text = ""
        Next

        ' ✅ LIMPIAR CAMPOS DE TEXTO
        txtNomCta.Text = ""
        CtaAlterna.Text = ""
        txtC1.Text = ""
        txtC2.Text = ""
        txtC3.Text = ""
        txtC4.Text = ""
        TeniaConcepto = False

        ' ✅ LIMPIAR PROPIEDADES COMO CONCEPTO
        chkegresobanco.CheckState = System.Windows.Forms.CheckState.Unchecked
        Chkcompras.CheckState = System.Windows.Forms.CheckState.Unchecked
        chkfacturacion.CheckState = System.Windows.Forms.CheckState.Unchecked
        Chkingresobanco.CheckState = System.Windows.Forms.CheckState.Unchecked

        ' ✅ LIMPIAR TIPO DE SERVICIO SRI
        chiva.CheckState = System.Windows.Forms.CheckState.Checked
        Option1.Checked = True
        opbienes.Checked = False

        ' ✅ LIMPIAR TIPO PRESUPUESTO
        opSinPre.Checked = True

        ' ✅ LIMPIAR MÓDULO Y DETALLE
        DcModulo.Text = ""
        Formatodetalle.Text = ""

        ' ✅ LIMPIAR CLASIFICADORES
        For I = 0 To Me.Clasificadores.Items.Count - 1
            Me.Clasificadores.SetItemChecked(I, False)
        Next

        ' ✅ LIMPIAR TIPO COSTO
        btnNoProduccion.Checked = True
        btnMO.Checked = False
        btnCD.Checked = False
        btnCI.Checked = False

        ' ✅ LIMPIAR AGRUPACIÓN
        chkDeAgrupacion.CheckState = System.Windows.Forms.CheckState.Unchecked
    End Sub

    Function Agrupa() As Boolean
    End Function

    Sub Agrupa2(ByRef op As Boolean)
    End Sub

    Function TipoPre() As String
        If opSinPre.Checked = True Then
            TipoPre = "1"
        ElseIf opMenVar.Checked = True Then
            TipoPre = "2"
        Else
            TipoPre = "3"
        End If
    End Function

    Sub TipoPre2(ByRef op As String)
        If op = "1" Then
            opSinPre.Checked = True
        ElseIf op = "2" Then
            opMenVar.Checked = True
        Else
            opMenFij.Checked = True
        End If
    End Sub

    Private Function Nivel(ByRef cta As String) As Short
        Dim I As Short
        Dim NumNiv As String
        NumNiv = emp.CtaNumDigNivel
        Dim OrgNiv() As Short
        ReDim OrgNiv(emp.CtaNumNiveles)

        For I = 1 To emp.CtaNumNiveles
            OrgNiv(I) = CShort(Mid(emp.CtaNumDigNivel, I, 1))
        Next
        If emp.CtaNumNiveles > 1 Then OrgNiv(2) = OrgNiv(1) + OrgNiv(2)
        If emp.CtaNumNiveles > 2 Then OrgNiv(3) = OrgNiv(2) + OrgNiv(3)
        If emp.CtaNumNiveles > 3 Then OrgNiv(4) = OrgNiv(3) + OrgNiv(4)
        If emp.CtaNumNiveles > 4 Then OrgNiv(5) = OrgNiv(4) + OrgNiv(5)
        If emp.CtaNumNiveles > 5 Then OrgNiv(6) = OrgNiv(5) + OrgNiv(6)
        For I = 1 To emp.CtaNumNiveles
            If Len(cta) = OrgNiv(I) Then
                Nivel = I
                I = emp.CtaNumNiveles
            End If
        Next
    End Function

    Private Function LeerCuenta(ByRef QueCuenta As String) As Boolean
        Dim RsCta As SqlClient.SqlDataReader = DattCom.SqlDatos.leerBase("SELECT cta_codigo FROM AdcCta WHERE Cta_Codigo='" & QueCuenta & "'", datosEmpresa.strConxAdcom)
        LeerCuenta = RsCta.Read()
        RsCta.Close()
        RsCta = Nothing
    End Function

    Private Sub CTBP01_1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ConxAdcom.Close()
        ConxAdcom.Dispose()
    End Sub

    Private Sub MostrarPosicionesControles()
        Dim msg As String = "=== POSICIONES DE txtCodCta ===" & vbCrLf

        For I As Integer = 1 To 8
            If txtCodCta(I) IsNot Nothing Then
                msg &= $"txtCodCta({I}): Left={txtCodCta(I).Left}, Top={txtCodCta(I).Top}, " &
                   $"Visible={txtCodCta(I).Visible}, Text='{txtCodCta(I).Text}', " &
                   $"MaxLength={txtCodCta(I).MaxLength}" & vbCrLf
            Else
                msg &= $"txtCodCta({I}): NOTHING" & vbCrLf
            End If
        Next

        msg &= vbCrLf & "=== DATOS DE EMPRESA ===" & vbCrLf
        msg &= $"CtaNumNiveles: {emp.CtaNumNiveles}" & vbCrLf
        msg &= $"CtaNumDigNivel: {emp.CtaNumDigNivel}" & vbCrLf
        msg &= $"EsNuevo: {EsNuevo}" & vbCrLf
        msg &= $"NivelIni: {NivelIni}" & vbCrLf
        msg &= $"CtaIni: {CtaIni}" & vbCrLf
        msg &= $"txtCta: {txtCta}" & vbCrLf

        If ctaActual IsNot Nothing Then
            msg &= $"ctaActual.codigo: {ctaActual.codigo}" & vbCrLf
            msg &= $"ctaActual.Nivel: {ctaActual.Nivel}" & vbCrLf
        Else
            msg &= "ctaActual: NOTHING" & vbCrLf
        End If

        'MsgBox(msg, MsgBoxStyle.Information, "DEPURACIÓN - POSICIONES")
    End Sub

    ' ✅ MÉTODO PARA AJUSTAR LA ALTURA DEL CheckedListBox (SIN IntegralHeight = False)
    Private Sub AjustarAlturaCheckedListBox()
        Try
            ' Usar el nombre del control sin Me. si es un control del formulario
            If Clasificadores Is Nothing Then Exit Sub

            ' Esperar a que los items estén cargados
            Application.DoEvents()

            Dim itemHeight As Integer = Clasificadores.ItemHeight
            Dim itemCount As Integer = Clasificadores.Items.Count

            ' Si no hay items, ocultar o poner altura mínima
            If itemCount = 0 Then
                Clasificadores.Height = 20
                Clasificadores.Visible = False
                Exit Sub
            End If

            Clasificadores.Visible = True

            ' Contar cuántos items están marcados (visibles)
            Dim visibleCount As Integer = 0
            For i As Integer = 0 To itemCount - 1
                If Not String.IsNullOrEmpty(Clasificadores.Items(i).ToString()) Then
                    visibleCount += 1
                End If
            Next

            ' Usar el count visible o el total
            Dim countToUse As Integer = Math.Max(visibleCount, itemCount)

            ' Calcular altura (itemHeight + padding)
            Dim padding As Integer = 4
            Dim totalHeight As Integer = (itemHeight * countToUse) + padding

            ' Limitar altura máxima (150 es suficiente para 5-6 items)
            If totalHeight > 150 Then
                totalHeight = 150
            End If

            ' ✅ NO FORZAR IntegralHeight = False (dejarlo como está)
            ' Si el control tiene IntegralHeight = True, los items se mostrarán completos
            ' Si tiene IntegralHeight = False, se mostrará con scroll si es necesario

            ' Aplicar altura
            Clasificadores.Height = totalHeight

            System.Diagnostics.Debug.WriteLine($"CheckedListBox ajustado: Items={itemCount}, Altura={totalHeight}")

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"Error ajustando altura: {ex.Message}")
        End Try
    End Sub


    Private Sub CTBP01_1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim colClasificadores As New ClasificadoresCtb
        Dim I As Short

        ' ✅ CREAR Y POSICIONAR LOS TEXTBOX (MÁS A LA DERECHA)
        Dim posX As Integer = 65 ' ← Posición inicial más a la derecha (antes era 10)

        For I = 1 To 8
            txtCodCta(I) = New TextBox
            Controls.Add(txtCodCta(I))
            txtCodCta(I).Height = 15
            txtCodCta(I).Width = 15

            txtCodCta(I).Left = posX
            posX = posX + txtCodCta(I).Width + 3

            txtCodCta(I).Top = 60
            txtCodCta(I).Visible = True
            txtCodCta(I).ReadOnly = True
            'txtCodCta(I).BackColor = Color.White
            'txtCodCta(I).ForeColor = Color.Black
            txtCodCta(I).BackColor = Color.FromArgb(240, 248, 255)  ' ✅ Azul muy claro (AliceBlue)
            txtCodCta(I).ForeColor = Color.FromArgb(0, 0, 64)
            txtCodCta(I).BorderStyle = BorderStyle.FixedSingle
            txtCodCta(I).Font = New Font("Segoe UI", 9, FontStyle.Bold)
            txtCodCta(I).TextAlign = HorizontalAlignment.Center
            txtCodCta(I).Text = ""

            txtCodCta(I).BringToFront()
            txtCodCta(I).Refresh()
        Next

        Try
            Dim clsCtb As New ClasificaCtb()
            Dim clasificadores As ColClasificador = clsCtb.Cargar()

            ' ✅ USAR Me.Clasificadores PARA EL CONTROL DEL FORMULARIO
            Me.Clasificadores.Items.Clear()
            For Each cl As Clasificador In clasificadores
                Me.Clasificadores.Items.Add(cl.Nombre)
            Next cl

            AjustarAlturaCheckedListBox()

            clsCtb = Nothing
            clasificadores = Nothing
        Catch ex As Exception
            MessageBox.Show($"Error cargando clasificadores: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        ' ✅ CARGAR MÓDULOS AUXILIARES
        Dim BCTB As Cuenta = New Cuenta
        Dim Aux() As String = Split(BCTB.ModulosAuxiliares, ";")
        With DcModulo
            .Items.Clear()
            For I = 0 To UBound(Aux)
                .Items.Add(Aux(I))
            Next I
        End With

        OrganizarNiveles()

        'MostrarPosicionesControles()
    End Sub

    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles guardar.Click, salir.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
        Select Case Button.Name
            Case "guardar"
                btnGuardar_Click()
            Case "salir"
                Me.Close()
        End Select
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtCodCta_KeyDown()
    End Sub

    Private Sub txtCodCta_KeyDown()
        Dim Index As Short
        Dim rs As SqlClient.SqlDataReader
        Dim L As Short
        Dim sSql As String
        Index = Val(Button1.Text)
        L = Len(CtaPadre)
        If L < 1 Then L = 1
        sSql = "SELECT MAX(Cta_codigo) AS CtaM From dbo.AdcCta " & "WHERE Cta_Nivel = " & NivelIni & " AND (SUBSTRING(Cta_codigo, 1," & L & ") = '" & CtaPadre & "')"
        rs = SqlDatos.leerBaseAdcom(sSql)

        If rs.Read Then
            Try
                If Not IsDBNull(rs.Item("ctam")) Then
                    txtCodCta(Index).Text = CStr(Val(Mid(rs.Item("ctam"), L + 1)) + 1)
                    txtCodCta(Index).Text = Strings.Right("00000000" & txtCodCta(Index).Text, txtCodCta(Index).MaxLength)
                Else
                    txtCodCta(Index).Text = "0"
                End If
            Catch
            End Try
        Else
            txtCodCta(Index).Text = "1"
        End If
        rs.Close()
        rs = Nothing
    End Sub

    Private Sub Clasificadores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Clasificadores.SelectedIndexChanged
    End Sub

    Private Sub actualizarBase()
        Dim sSQL As String = "IF NOT EXISTS (SELECT col.name FROM sysobjects obj, syscolumns col WHERE obj.id = col.id and obj.name = 'adccta' and col.name='tipoCosto')"
        sSQL += " BEGIN ALTER TABLE AdcCta Add [tipoCosto] [varchar](3) null End"
        Dim linkdat As New SqlClient.SqlCommand(sSQL, ConxAdcom)
        linkdat.ExecuteNonQuery()
    End Sub

    Private Sub chkDeAgrupacion_CheckedChanged(sender As Object, e As EventArgs) Handles chkDeAgrupacion.CheckedChanged
    End Sub
End Class