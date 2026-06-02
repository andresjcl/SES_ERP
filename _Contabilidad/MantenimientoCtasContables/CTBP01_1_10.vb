Option Strict Off
Option Explicit On
Imports System.Data
Imports DaxClasificadores
Imports DattCom
Friend Class CTBP01_1
    Inherits System.Windows.Forms.Form
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
    'Dim Txtcc() As Windows.Forms.TextBox
    Const Nombre As String = "Maestro de Cuentas contables"
    Dim TeniaConcepto As Boolean
    Dim TxtCtrl As New Collection
    Dim txtCodCta(9) As TextBox
    Dim ConxAdcom As New SqlClient.SqlConnection
    Public Sub CrearCuenta(ByRef codigo As String, ByRef NivelCta As Short, ByRef Grupo As Short, ByRef Accion As String, ByRef Arbol As System.Windows.Forms.TreeView)
        Dim CtaMayor As New Cuenta
        'Dim prog As New DaxLib.DaxLibMalla
        'prog.ColorF(Me)
        'prog = Nothing

        Arbolito = Arbol
        CtaIni = codigo
        NivelIni = NivelCta
        GrupoIni = Grupo
        EsNuevo = True
        Qaccion = Accion

        Dim CtaPapa As New Cuenta
        Dim Aux() As String
        Dim I As Integer
        Dim j As Integer
        Dim gg As Integer
        Select Case Qaccion
            Case "N"                
                CtaPadre = QuePadreDeCta(CtaIni, NivelIni)
                txtCta = CtaPadre
                CtaPapa.Cargar((CtaPadre))
                With CtaPapa
                    gg = Val(.Grupo)
                    If gg = 0 Then gg = 1
                    dcGruCon.SelectedIndex = gg - 1 : dcGruCon.Enabled = False
                    If .ModuloAuxiliar > "" Then DcModulo.Text = .ModuloAuxiliar : DcModulo.Enabled = False
                    Select Case .TipoPresu
                        Case "F"
                            opMenFij.Checked = True
                        Case "V"
                            opMenVar.Checked = True
                        Case Else
                            opSinPre.Checked = True
                    End Select

                    'If Not IsNull(!cta_claveseg) Then txtCla = !cta_claveseg
                    If .ClaveAux1 > "" Then txtC1.Text = .ClaveAux1 : txtC1.Enabled = False
                    If .ClaveAux2 > "" Then txtC2.Text = .ClaveAux2 : txtC2.Enabled = False
                    If .ClaveAux3 > "" Then txtC3.Text = .ClaveAux3 : txtC3.Enabled = False
                    If .ClaveAux4 > "" Then txtC4.Text = .ClaveAux4 : txtC4.Enabled = False

                    Aux = Split(.Clasificadores, ";")
                    If UBound(Aux) > 0 Then
                        For I = 0 To UBound(Aux)
                            For j = 0 To Clasificadores.Items.Count - 1
                                If Aux(I) = Clasificadores.Items(j) Then
                                    Clasificadores.SetItemChecked(j, True)
                                End If
                            Next j
                        Next I
                    End If
                End With
                CtaPapa = Nothing
            Case "I"
                txtCta = CtaIni
                NivelIni = NivelIni + 1
                CtaPadre = QuePadreDeCta(CtaIni, NivelIni)
            Case "M"
                txtCta = CtaIni
                EsNuevo = False
                CtaPadre = QuePadreDeCta(CtaIni, NivelIni)
        End Select

        'If NivelIni > 6 Or NivelIni = 0 Then Unload Me: Exit Sub
        Me.ShowDialog()
    End Sub

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
        Dim Niv As Short
        Dim CtaNumNiveles As Short
        Dim CtaNumDigNivel As String
        'Dim linkdat As New DaxData.DaxLibDatos
        'Creo la clase Cuenta

        Button1.Visible = False
        ctaActual = New Cuenta
        limpiar()
        Temp = 1
        CtaNumNiveles = Emp.CtaNumNiveles
        CtaNumDigNivel = Emp.CtaNumDigNivel
        For I = 1 To NivelIni
            With txtCodCta(I)
                If I > CtaNumNiveles Then
                    .Visible = False
                Else
                    .Visible = True
                    .MaxLength = Mid(CtaNumDigNivel, I, 1)
                    .Text = Mid(txtCta, Temp, txtCodCta(I).MaxLength)
                    .Width = 14 + (.MaxLength - 1) * 10
                    ToolTip1.SetToolTip(txtCodCta(I), .MaxLength & IIf(.MaxLength = 1, " Dígito", " Dígitos"))
                    If I > 1 Then .Left = ((txtCodCta(I - 1).Left) + 2 + (txtCodCta(I - 1).Width))
                    Temp = Temp + .MaxLength
                    .ReadOnly = True
                End If
            End With
        Next
        If EsNuevo Then
            dcGruCon.SelectedIndex = GrupoIni - 1
            txtCodCta(NivelIni).ReadOnly = False
            Button1.Left = txtCodCta(NivelIni).Left
            Button1.Width = txtCodCta(NivelIni).Width
            Button1.Visible = True
            Button1.Top = txtCodCta(NivelIni).Top + txtCodCta(NivelIni).Height + 1
            Button1.Text = NivelIni
            If Niv <> 0 Then txtCodCta(Niv + 1).Focus()
        Else
            ctaActual.Cargar((CtaIni))
            CargarDatos()
        End If
    End Sub

    Private Sub existenregistros()
        'On Error GoTo HayErrores
        '********** Controlar los botones, hacer visibles e invisibles ********
        If RsCta.Rows.Count > 0 Then
            CargarDatos()
        End If
        Exit Sub
        'HayErrores:
        '  controlaerrores
    End Sub

    Sub CargarDatos()
        Dim Aux() As String
        On Error Resume Next
        limpiar()
        Dim Temp, I, j As Short

        If ctaActual.codigo > "" Then
            With ctaActual
                Temp = 1
                txtCta = .codigo
                CodigoCta = txtCta
                txtNomCta.Text = .Nombre
                CtaAlterna.Text = .CodigoAlterno
                For I = 1 To Len(txtCta)
                    txtCodCta(Temp).Text = Mid(txtCta, I, txtCodCta(Temp).MaxLength)
                    I = I + txtCodCta(Temp).MaxLength - 1
                    Temp = Temp + 1
                Next
                chkDeAgrupacion.CheckState = IIf(.Agrupacion, 1, 0)
                dcGruCon.SelectedIndex = CDbl(.Grupo) - 1 ' ValidarCuentaContable (Mid$(.codigo, 1, 1)) - 1
                DcModulo.Text = .ModuloAuxiliar
                Chkcompras.CheckState = IIf(.ConceptoCompras, 1, 0)
                chkfacturacion.CheckState = IIf(.ConceptoVentas, 1, 0)
                chkegresobanco.CheckState = IIf(.ConceptoBcoEgreso, 1, 0)
                Chkingresobanco.CheckState = IIf(.ConceptoBcoIngreso, 1, 0)
                Select Case .TipoPresu
                    Case "F"
                        opMenFij.Checked = True
                    Case "V"
                        opMenVar.Checked = True
                    Case Else
                        opSinPre.Checked = True
                End Select
                'If Not IsNull(!cta_claveseg) Then txtCla = !cta_claveseg
                txtC1.Text = .ClaveAux1
                txtC2.Text = .ClaveAux2
                txtC3.Text = .ClaveAux3
                txtC4.Text = .ClaveAux4
                Aux = Split(.Clasificadores, ";")
                If UBound(Aux) > 0 Then
                    For I = 0 To UBound(Aux)
                        For j = 0 To Clasificadores.Items.Count - 1
                            If Aux(I) = Clasificadores.Items(j).ToString Then
                                Clasificadores.SetItemChecked(j, True)
                            End If
                        Next j
                    Next I
                End If
                Formatodetalle.Text = .Detalle
                DcModulo.Text = .ModuloAuxiliar
                Me.Text = Nombre & "-" & .usuario

                '            If Not IsNull(!Cta_CCosto) Then Check1.Value = IIf(!Cta_CCosto = "S", 1, 0)

                '            OpcCostos = !Cta_CostosDir
                '            OpCostoIndirecto = !Cta_CostosInDir
                '            OpcGasto = !Cta_Gasto
                btnNoProduccion.Checked = False
                If .tipoCosto = "MO" Then btnMO.Checked = True
                If .tipoCosto = "CD" Then btnCD.Checked = True
                If .tipoCosto = "CI" Then btnCI.Checked = True
            End With
        End If
        TeniaConcepto = False
        If Chkcompras.CheckState <> 0 Or chkfacturacion.CheckState <> 0 Or chkegresobanco.CheckState <> 0 Or Chkingresobanco.CheckState <> 0 Then
            CargarConcepto()
        End If

    End Sub

    Private Sub btnGuardar_Click()
        Dim Lon As Short
        Dim j As Short
        Dim cod As String
        Dim Classi As String
        Dim TTIPOCOS As String
        '        Dim linkdat As New DaxData.DaxLibDatos
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
                '.Gasto = OpcGasto
                '.cosDirecto = OpcCostos
                '.CosIndirecto = OpCostoIndirecto
                '.Ccosto = IIf(Check1.Value = 0, "", "S")
                .ConceptoCompras = Chkcompras.CheckState
                .ConceptoVentas = chkfacturacion.CheckState
                .ConceptoBcoEgreso = chkegresobanco.CheckState
                .ConceptoBcoIngreso = Chkingresobanco.CheckState
                'If Not IsNull(!cta_claveseg) Then txtCla = !cta_claveseg
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
                '            If MsgBox("CONFIRMA REGISTRAR LAS PROPIEDADES DE ESTA CUENTA A TODAS LAS SUBCUENTAS DE NIVEL INFERIOR ?", vbYesNo + vbQuestion) = vbYes Then

                cod = "UPDATE AdcCta SET "
                cod = cod & " Cta_tipopresu = '" & Trim(TipoPre) & "' "
                '            cod = cod & ", Cta_claveseg ='" & Trim$(txtCla) & "'"
                cod = cod & ", Cta_claveaux1 ='" & Trim(txtC1.Text) & "' "
                cod = cod & ", Cta_claveaux2 ='" & Trim(txtC2.Text) & "' "
                cod = cod & ", Cta_claveaux3 ='" & Trim(txtC3.Text) & "' "
                cod = cod & ", Cta_claveaux4 ='" & Trim(txtC4.Text) & "' "
                cod = cod & ", clasificadores ='" & Trim(Classi) & "' "
                cod = cod & ", moduloauxiliar ='" & Trim(DcModulo.Text) & "' "
                cod = cod & ", tipoCosto ='" & Trim(TTIPOCOS) & "' "
                cod = cod & " where substring(cta_codigo,1," & Lon & ") = '" & CodigoCta & "'"

                DattCom.SqlDatos.ejecutarComando(cod, datosEmpresa.strConxAdcom)

                'cod = "delete from AdcServ where AdcServ.Sev_codigo in"
                'cod = cod & "("
                'cod = cod & " Select AdcServ.Sev_codigo"
                'cod = cod & " FROM         AdcServ LEFT OUTER JOIN"
                'cod = cod & " AdcCta ON AdcServ.Sev_codigo = AdcCta.Cta_codigo"
                'cod = cod & " where ISNULL(cta_nombre,'') > ''  and ISNULL(conceptocompras,0) = 0 and ISNULL(ConceptoVentas ,0) = 0"
                'cod = cod & " and ISNULL(ConceptoBcoEgreso ,0) = 0 and ISNULL(ConceptoBcoIngreso ,0) = 0"
                'cod = cod & ")"
                'linkdat.DaxData("", cod)
            End If
            '        End If

        End If

        'linkdat = Nothing
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
        With serv
            opbienes.Checked = .Sev_SriBien

            If .Sev_sniva = True Then
                chiva.CheckState = System.Windows.Forms.CheckState.Checked
            Else
                chiva.CheckState = System.Windows.Forms.CheckState.Unchecked
            End If

            Chkcompras.CheckState = .sev_compras
            chkfacturacion.CheckState = .sev_ventas
            Chkingresobanco.CheckState = .sev_ingbanco
            chkegresobanco.CheckState = .sev_egrbanco

        End With
        TeniaConcepto = True
    End Sub
    Private Sub ArreglarArbol()
        'Dim Aux As String
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
        For I = 1 To Emp.CtaNumNiveles
            If Len(txtCodCta(I).Text) < CDbl(Mid(Emp.CtaNumDigNivel, I, 1)) And txtCodCta(I).Visible = True Then
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
        'If Nivel(CodigoCta) = Emp.CtaNumNiveles Then opCtaMov = True
        serv = Nothing
    End Function


    'Private Function GetCta(cta As String)
    '    Dim I As Integer
    '    Dim Temp As Integer
    '    Temp = Len(cta)
    '    For I = 1 To Temp
    '        If  Mid$(cta, I, 1) = " " Then
    '            cta = Mid$(cta, 1, I - 1)
    '            I = Temp
    '        End If
    '    Next
    '    GetCta = cta
    'End Function

    Private Function CodCta() As String
        Dim Temp As String = ""
        Dim I As Short
        For I = 1 To Emp.CtaNumNiveles
            Temp = Temp & txtCodCta(I).Text
        Next
        CodCta = Temp
    End Function

    Sub limpiar()
        Dim I As Short
        For I = 1 To Emp.CtaNumNiveles
            txtCodCta(I).Text = ""
        Next
        txtNomCta.Text = ""
        '    txtCla = ""
        txtC1.Text = ""
        txtC2.Text = ""
        txtC3.Text = ""
        txtC4.Text = ""
        TeniaConcepto = False

        chkegresobanco.CheckState = System.Windows.Forms.CheckState.Unchecked
        Chkcompras.CheckState = System.Windows.Forms.CheckState.Unchecked
        chkfacturacion.CheckState = System.Windows.Forms.CheckState.Unchecked
        Chkingresobanco.CheckState = System.Windows.Forms.CheckState.Unchecked
        chiva.CheckState = System.Windows.Forms.CheckState.Checked
        Option1.Checked = True
        opSinPre.Checked = True
        DcModulo.Text = ""
        Formatodetalle.Text = ""

    End Sub

    Function Agrupa() As Boolean
        '    If opCtaAgr = True Then
        '        Agrupa = True
        '    Else
        '        Agrupa = False
        '    End If
    End Function
    Sub Agrupa2(ByRef op As Boolean)
        If op = True Then
            '        Me.opCtaAgr = True
        Else
            '        opCtaMov = True
        End If
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
        NumNiv = Emp.CtaNumDigNivel
        Dim OrgNiv() As Short
        ReDim OrgNiv(Emp.CtaNumNiveles)

        For I = 1 To Emp.CtaNumNiveles
            OrgNiv(I) = CShort(Mid(Emp.CtaNumDigNivel, I, 1))
        Next
        If Emp.CtaNumNiveles > 1 Then OrgNiv(2) = OrgNiv(1) + OrgNiv(2)
        If Emp.CtaNumNiveles > 2 Then OrgNiv(3) = OrgNiv(2) + OrgNiv(3)
        If Emp.CtaNumNiveles > 3 Then OrgNiv(4) = OrgNiv(3) + OrgNiv(4)
        If Emp.CtaNumNiveles > 4 Then OrgNiv(5) = OrgNiv(4) + OrgNiv(5)
        If Emp.CtaNumNiveles > 5 Then OrgNiv(6) = OrgNiv(5) + OrgNiv(6)
        For I = 1 To Emp.CtaNumNiveles
            If Len(cta) = OrgNiv(I) Then
                Nivel = I
                I = Emp.CtaNumNiveles
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

    Private Sub CTBP01_1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        'Dim cca As New ClasificadorCtb()
        Dim colClasificadores As New ClasificadoresCtb

        'Dim Clasif As New ClasificadorCtb
        Dim I As Short
        'Dim libb As New DaxLib.DaxLibMalla
        'Dim libsql As New DaxLib.DaxLibBases
        'libsql.TipoBase = "10"
        'ConxAdcom.ConnectionString = libsql.StrAdcom
        'ConxAdcom.Open()
        'actualizarBase()

        For I = 1 To 8
            txtCodCta(I) = New TextBox
            Controls.Add(txtCodCta(I))
            txtCodCta(I).Height = 27
            txtCodCta(I).Width = 25
            txtCodCta(I).Left = 30 * I + 54 '+ TextCodCta.Left
            txtCodCta(I).Top = 55
            txtCodCta(I).Visible = False
        Next
        'cca.Cargar("")
        Clasificadores.Items.Clear()
        For Each Clasif In colClasificadores.ColClasificadoresCtb
            Clasificadores.Items.Add(Clasif.Nombre)
        Next Clasif

        Dim BCTB As Cuenta = New Cuenta
        Dim Aux() As String
        Aux = Split(BCTB.ModulosAuxiliares, ";")
        With DcModulo
            .Items.Clear()
            For I = 0 To UBound(Aux)
                .Items.Add(Aux(I))
            Next I
        End With

        colClasificadores = Nothing
        'cca = Nothing
        OrganizarNiveles()

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
    Private Sub txtCodCta_KeyDown() ' ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtCodCta.KeyDown
        Dim Index As Short '= txtCodCta.GetIndex(eventSender)
        Dim rs As SqlClient.SqlDataReader
        Dim L As Short
        Dim sSql As String
        Index = Val(Button1.Text)
        L = Len(CtaPadre)
        If L < 1 Then L = 1
        sSql = "SELECT MAX(Cta_codigo) AS CtaM From dbo.AdcCta " & "WHERE Cta_Nivel = " & NivelIni & " AND (SUBSTRING(Cta_codigo, 1," & L & ") = '" & CtaPadre & "')"
        'Dim linkdat As New SqlClient.SqlCommand(sSql, ConxAdcom)
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
        'linkdat = Nothing
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
        '//If (chkDeAgrupacion.Checked) Th
    End Sub
End Class