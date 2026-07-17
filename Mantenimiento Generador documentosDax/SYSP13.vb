Option Strict On
Option Explicit On
Imports System.Data

Friend Class SYSP13
    Inherits System.Windows.Forms.Form
    Dim EsNuevo As Integer
    Dim TipoSis As String
    Dim op As New OpcDoc
    Dim Sw As Boolean
    Dim CampoValido As Boolean
    Dim Nrodatos As Integer
    Dim OpMnu As String
    Dim TxtCtaNombre As String
    Dim TipoSri As String
    Dim TipoBanco As String
    Dim libctactb As New CtaMtn.Cuenta
    Dim cargar As Boolean = False
    Dim PosicionLab As Integer = 0

    Private Sub btCancelar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        CancelarRegistro()
    End Sub
    Private Sub CancelarRegistro()
        If MessageBox.Show("Esta seguro que desea cerrar, se perderán los cambios efectuados", "", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            LimpiaFormulario()
        End If
    End Sub

    Private Sub btEliminar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btneliminar.Click
        If DocUsado() Then Exit Sub
        If MessageBox.Show("Esta seguro que desea eliminar el registro activo", "", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            op.Eliminar(txtAbr.Text)
            LimpiaFormulario()
        End If
    End Sub
    Private Function DocUsado() As Boolean
        Dim cod As String
        cod = "SELECT top 1 opc_documento FROM AdcDoc WHERE Opc_Documento='" & txtAbr.Text & "'"
        Dim dat As SqlDataReader = DattCom.SqlDatos.leerBase(cod, DattCom.datosEmpresa.strConxAdcom)
        DocUsado = True
        If Not dat.Read Then
            cod = "SELECT top 1 opc_documento FROM AdcDocPRO WHERE Opc_Documento='" & txtAbr.Text & "'"
            Dim dat2 As SqlDataReader = DattCom.SqlDatos.leerBase(cod, DattCom.datosEmpresa.strConxAdcom)
            If Not dat.Read Then DocUsado = False
        End If
        If DocUsado = True Then
            MsgBox("No se eliminará este tipo de documentos, existen registros grabados ")
        End If
        Return DocUsado
    End Function

    Private Sub GuardarRegistro()
        Dim SiNo As Boolean
        Dim Impuesto As String = ""
        Dim TTipoDoc As String = ""
        Try
            If IsDBNull(dbDoc.SelectedValue) Or dbDoc.Text = "" Then
                MsgBox("Debe registrar un grupo funcional del documento ", MsgBoxStyle.Critical)
                Exit Sub
            End If
            If txtAbr.Text = "" Then
                MsgBox("Ingrese la Abreviación del Documento ", MsgBoxStyle.Information)
                txtAbr.Focus()
                Exit Sub
            End If
            If txtDes.Text = "" Then
                MsgBox("Ingrese la Descripción del Documento ", MsgBoxStyle.Information)
                txtAbr.Focus()
                Exit Sub
            End If
            If EsNuevo = 1 Then
                SiNo = op.VerificarDocumento(txtAbr.Text)
                If SiNo = True Then
                    MsgBox("La Abreviación del documento ya existe", MsgBoxStyle.Information)
                    txtAbr.Focus()
                    Exit Sub
                End If
            End If

            Impuesto = ""
            Select Case dbDoc.SelectedValue.ToString.ToString
                Case "FAC", "FAP", "DEV", "DEP", "NDC", "NCC", "NDP", "NCP", "PRC", "PEC", "PEP", "PRP", "REQ"
                    'If fImpuestos.Visible = True Then
                    Impuesto = IIf(ChImp1.Checked, "1", "0").ToString + IIf(ChImp2.Checked, "1", "0").ToString + IIf(ChImp3.Checked, "1", "0").ToString + IIf(chImp4.Checked, "1", "0").ToString
                    'End If
            End Select

            'Llena la clase
            Select Case dbDoc.SelectedValue.ToString.ToString
                Case "ING", "EGR", "TRB", "NCB", "NDB", "VIC", "VEC"
                    txtTotDesIndD.Text = txtRetFte1D.Text
                    txtTotDesIndH.Text = txtRetFte1H.Text
            End Select

            'llenar el string de los campos auxiliares
            Dim cpAux As String = ""
            Dim cpAux1 As String = ""
            Dim i As Integer = 0
            Dim item As String
            Dim item1 As String
            Dim sb As New System.Text.StringBuilder
            Dim sb1 As New System.Text.StringBuilder
            With ListCabecera
                For Each item In .CheckedItems
                    If sb.ToString <> "" Then sb.Append(",")
                    sb.Append(item)
                Next
            End With

            With ListItems
                For Each item1 In .CheckedItems
                    If sb1.ToString <> "" Then sb1.Append(",")
                    sb1.Append(item1)
                Next
            End With
            TTipoDoc = ""
            TipoSri = ""
            Try
                'TTipoDoc = ComboDoc1.SelectedValue.ToString()
                If ComboDoc1 IsNot Nothing AndAlso ComboDoc1.SelectedValue IsNot Nothing Then
                    TTipoDoc = ComboDoc1.SelectedValue.ToString()
                Else
                    'TTipoDoc = "SIN_VALOR" ' O cualquier valor por defecto que necesites
                    'MessageBox.Show("Por favor, seleccione un tipo de documento.")
                End If
            Catch
                TTipoDoc = ""
            End Try


            'If CONEMP.EmpresaAct.Sri = True Then
            If (TipoComprobanteSri.SelectedValue.ToString > "") Then TipoSri = TipoComprobanteSri.SelectedValue.ToString
                'End If

                With op
                    .Documento = txtAbr.Text
                    .nombre = txtDes.Text
                    .TipoDoc = dbDoc.SelectedValue.ToString.ToString
                    '.NumIni = Val(NIni)
                    .Extenciones = ArmarExtenciones().ToString()
                    .SNRepetir = Convert.ToInt16(IIf(chRepCodFil.Checked, "1", "0"))
                    .SNContabilizar = Convert.ToInt16(IIf(chRefCon.Checked, "1", "0"))
                    .noCtbLinea = IIf(chKNoEnLinea.Checked, "X", "").ToString()
                    .Recontabiliza = IIf(Reconta.Checked, "S", "N").ToString()
                    .SNCompDes = Convert.ToInt16(IIf(chGenComDes.Checked, "1", "0"))
                    .SNLiquidacionGas = Convert.ToInt16(IIf(ChGenTipGas.Checked, "1", "0"))
                    .PermiteCantidadCero = Convert.ToInt16(IIf(RegistraCantCero.Checked, "1", "0"))

                    .ImprimirForm = txtFormato.Text
                    .ImprimirDoc = ImpDoc()
                    .SNDefEst = 0
                    .SNSinExist = Convert.ToInt16(IIf(chGenSinExi.Checked, "1", "0"))
                .TipoCosteo = TipoCosto()

                '.ClasificadorCosto = CmbClasificadorCosteo.SelectedValue.ToString()

                If CmbClasificadorCosteo.SelectedValue IsNot Nothing Then
                    .ClasificadorCosto = CmbClasificadorCosteo.SelectedValue.ToString()
                Else
                    .ClasificadorCosto = ""
                End If


                .SNGuardarCosto = Convert.ToInt16(IIf(chGuaUltCom.Checked, "1", "0"))
                .ctadebe = txtValTotDocD.Text
                    .ctahaber = txtValTotDocH.Text
                    .CtaValVtaInvD = txtValVenInvD.Text
                    .CtaValVtaInvH = txtValVenInvH.Text
                    .CtaVtaOIvaD = txtValVenOIvaD.Text
                    .CtaVtaOIvaH = txtValVenOIvaH.Text
                    .CtaValDescD = txtValDesD.Text
                    .CtaValDescH = txtValDesH.Text
                    .CtaValNetoD = txtValNetVenD.Text
                    .CtaValNetoH = txtValNetVenH.Text
                    .CtaIvaD = txtIvaD.Text
                    .CtaIvaH = txtIvaH.Text
                    .CtaOSinIvaD = txtOtrSIvaD.Text
                    .CtaOSinIvaH = txtOtrSIvaH.Text
                    .CtaSubTConIvaD = txtSubVenCIvaD.Text
                    .CtaSubTConIvaH = txtSubVenCIvaH.Text
                    .CtaTotDescInvD = txtTotDesIndD.Text
                    .CtaTotDescInvH = txtTotDesIndH.Text
                    .VarCtaCostoH = txtCtaCosH.Text
                    .VarCtaCostoD = txtCtaCosD.Text
                    .VarCtaRetBieH = txtRetBieH.Text
                    .VarCtaRetBieD = txtRetBieD.Text
                    .VarCtaRetSerH = txtRetSerH.Text
                    .VarCtaRetSerD = txtRetSerD.Text
                    .VarCtaRetFteH = txtRetFteH.Text
                    .VarCtaRetFteD = txtRetFteD.Text
                    .VarCtaRetFte1H = txtRetFte1H.Text
                    .VarCtaRetFte1D = txtRetFte1D.Text
                    .VarCtaRetFte2H = txtRetFte2H.Text
                    .VarCtaRetFte2D = txtRetFte2D.Text

                    .SNArtIndv = Convert.ToInt16(IIf(chArt.Checked, 1, 0))
                    .SNDescIndv = Convert.ToInt16(IIf(chDes.Checked, 1, 0))
                    .SNOtConIva = Convert.ToInt16(IIf(chOtrCIva.Checked, 1, 0))
                    .SNOtSinIva = Convert.ToInt16(IIf(chOtrSIva.Checked, 1, 0))
                    .ArtSevAcf = ArtSerAcf()
                    .Usuario = DattCom.datosEmpresa.usr
                    .Impuestos = Impuesto
                    .FormatoCtb = FormatoCtb.Text
                    .FormatoElec = FormatoElec.Text
                    .TipoSri = TipoSri
                    .Impresora_1 = Impresora_1.Text
                    .Impresora_2 = Impresora_2.Text
                    .Impresora_3 = Impresora_3.Text
                    .FormatoAux_1 = FormatoAux1.Text
                    .FormatoAux_2 = FormatoAux2.Text
                    .FormatoAux_3 = FormatoAux3.Text

                    .GeneraMateriaPrima = Convert.ToInt16(IIf(GeneraSalidaMP.Checked, "1", "0"))
                    .TipoSalidaMP = (IIf(.GeneraMateriaPrima = 1, TTipoDoc, "")).ToString()

                    .Opc_Propietario = Convert.ToInt16(IIf(Check3.Checked, "1", "0"))
                    .Opc_Bodega = Convert.ToInt16(IIf(Check6.Checked, "1", "0"))
                    .Opc_IdSri = Convert.ToInt16(IIf(Check5.Checked, "1", "0"))
                    .Opc_Autonumero = Convert.ToInt16(IIf(ChkNumerar.Checked, "1", "0"))
                    .Opc_consolidar = Convert.ToInt16(IIf(Chpuedeconsolidar.Checked, "1", "0"))
                    .DocumentoNoActivado = Convert.ToInt16(IIf(Check7.Checked, "1", "0"))
                    .AutorizarPago = Convert.ToInt16(IIf(Check8.Checked, "1", "0"))

                    .Opc_ctavaldesCuadre = 0
                    .Opc_ctaCuadre = Convert.ToInt16(Val(ChkCdreTotal.Text))
                    .Opc_ctavalvtainvCuadre = Convert.ToInt16(Val(ChkCdreArticulos.Text))
                    .Opc_ctavtaoivaCuadre = Convert.ToInt16(Val(ChkCdreNOUSADO.Text))
                    .Opc_ctasubtcivaCuadre = Convert.ToInt16(Val(ChkCdreConceptos.Text))
                    .Opc_ctavalnetoCuadre = Convert.ToInt16(Val(ChkCdreActivos.Text))
                    .Opc_ctaivaCuadre = Convert.ToInt16(Val(ChkCdreDescuentoArticulos.Text))
                    .Opc_ctaotrosivaCuadre = Convert.ToInt16(Val(ChkCdreDescuentosServicios.Text))
                    .Opc_ctatotdesindiCuadre = Convert.ToInt16(Val(ChkCdreImpuestos.Text))
                    .Opc_CtaCostoCuadre = Convert.ToInt16(Val(ChkCdreCostoArticulos.Text))
                    .Opc_CtaRetBieCuadre = Convert.ToInt16(Val(ChkCdreRetIvaBien.Text))
                    .Opc_CtaRetSerCuadre = Convert.ToInt16(Val(ChkCdreRetIvaServ.Text))
                    .Opc_CtaRetFteCuadre = Convert.ToInt16(Val(ChkCdreRetFte.Text))
                    .Opc_CtaRetFte1Cuadre = Convert.ToInt16(Val(ChkCdreRetFte1.Text))
                    .Opc_CtaRetFte2Cuadre = Convert.ToInt16(Val(ChkCdreRetFte2.Text))
                    .Opc_LimiteCuadre = Val(Text1.Text)
                    .DatosAuxiliares = sb.ToString
                    .DatosAuxiliaresDet = sb1.ToString
                    .TipoSoporteObligatorio = TxtTipSop.Text
                    .ComandoExterno = ComandoSQL.Text
                    If chkNoBajoCosto.Checked Then .NoPVPbajoCosto = 1 Else .NoPVPbajoCosto = 0
                    .formulasPV = txtFormulasPVP.Text
                    If chkElectronico.Checked Then .EsElectronico = 1 Else .EsElectronico = 0
                    .usoImportaciones = Convert.ToInt16(IIf(chkRegistraImportaciones.Checked, 1, 0))
                End With
            Catch
            End Try

        If EsNuevo = 1 Then op.Guardarr() Else op.Actualizar(txtAbr.Text)
        My.Settings.Abrevbia = txtAbr.Text

        My.Settings.Save()
    End Sub
    Private Sub limpiarChecList(ByVal lista As CheckedListBox)
        Dim i As Integer = 0
        With lista
            For i = 0 To .Items.Count - 1
                .SetItemChecked(i, False)
            Next
        End With
    End Sub

    Private Function ClaveDoc(ByRef DocTip As String) As String
        Dim cod As String
        cod = "select * from syscod where tiporeferencia = 'Documentos' and abreviación = '" & DocTip & "'"
        Dim dat As SqlDataReader = DattCom.SqlDatos.leerBase(cod, DattCom.datosEmpresa.strConxAdcom)
        ClaveDoc = ""
        If dat.Read Then
            If Not IsDBNull(dat("Caracteristica1")) Then ClaveDoc = dat("Caracteristica1").ToString()
        End If
    End Function

    Private Sub LimpiaFormulario()
        Limpiar()
        limpiarChecList(ListCabecera)
        limpiarChecList(ListItems)
        LlenarTipo()
        PonerGeneral()
        EsNuevo = 0
        PonerBotones()
        txtAbr.Enabled = True
    End Sub

    Private Sub Limpiar()
        Dim a As String
        For Each Control1 As System.Windows.Forms.Control In Me.Controls
            Try
                If Control1.Controls.Count > 0 Then LimpiarControl(Control1)
                a = TypeName(Control1)
                If a = "TextBox" Then Control1.Text = ""
                If a = "ComboBox" Then DirectCast(Control1, ComboBox).SelectedValue = ""
                If a = "CheckBox" Then DirectCast(Control1, CheckBox).Checked = False
            Catch
            End Try

        Next
    End Sub

    Private Sub LimpiarControl(ByVal oBJ As Control)
        Dim a As String
        For Each Control1 As System.Windows.Forms.Control In oBJ.Controls
            Try
                If Control1.Controls.Count > 0 Then LimpiarControl2(Control1)
                a = TypeName(Control1)
                If a = "TextBox" Then Control1.Text = ""
                If a = "ComboBox" Then DirectCast(Control1, ComboBox).SelectedValue = ""
                If a = "CheckBox" Then DirectCast(Control1, CheckBox).Checked = False
            Catch
            End Try

        Next
    End Sub
    Private Sub LimpiarControl2(ByVal oBJ As Control)
        Dim a As String
        For Each Control1 As System.Windows.Forms.Control In oBJ.Controls
            Try
                If Control1.Controls.Count > 0 Then LimpiarControl2(Control1)
                a = TypeName(Control1)
                If a = "TextBox" Then Control1.Text = ""
                If a = "ComboBox" Then DirectCast(Control1, ComboBox).SelectedValue = ""
                If a = "CheckBox" Then DirectCast(Control1, CheckBox).Checked = False
            Catch
            End Try

        Next
    End Sub


    Private Function ArmarExtenciones() As Object
        ' armarextenciones(tIPOdOC)
        'Permite configurar el compòrtamiento de cada documento
        'los tres primeros caracteres son del documento
        'el siguiente es de si o no en contabilidad 0=No refleja y  1=Si REfleja
        'El siguiente es de Inventario 0=No Refleja y 1=Si Refleja
        'El siguiente caracter es de Activos Fijos 0=No Refleja y 1=Si Refleja
        ' y el ultimo es del Estado del documento 0=No Oculto y 1=Si Oculto
        Return dbDoc.SelectedValue.ToString & Convert.ToInt16(chRefCon.Checked).ToString() & Convert.ToInt16(chRefInv.Checked).ToString() & Convert.ToInt16(chRefAcf.Checked).ToString() & "0" 'Trim(Str(chMostrar.Value))
    End Function
    Private Function ArmarExtenciones2(ByRef op As String) As String
        chRefCon.Checked = (Val(Mid(op, 4, 1)) <> 0)
        chRefInv.Checked = (Val(Mid(op, 5, 1)) <> 0)
        chRefAcf.Checked = (Val(Mid(op, 6, 1)) <> 0)
        'chMostrar = val(Mid$(op, 7, 1))
        Return ""
    End Function

    'Function GenDia()
    '     If opInd Then
    '        GenDia = "I"   ' "I" el documento en contabilidad se generara INDIVIDUALMENTE
    '     ElseIf opMen Then
    '        GenDia = "M"  ' "M" el documento en contabilidad se generara MENSUALMETE
    '     ElseIf opSem Then
    '        GenDia = "S"   ' "S" el documento en contabilidad se generara SEMANALMETE
    '     ElseIf opQui Then
    '        GenDia = "Q"   ' "Q" el documento en contabilidad se generara QUINCENALMENTE
    '    ElseIf opDia Then
    '        GenDia = "D"    ' "D" el documento en contabilidad se generara DIARIAMENTE
    '    End If
    'End Function
    '
    'Function GenDia2(op As String)
    '     If op = "I" Then
    '        opInd = True
    '     ElseIf op = "M" Then
    '        opMen = True
    '     ElseIf op = "S" Then
    '        opSem = True
    '     ElseIf op = "Q" Then
    '        opQui = True
    '    ElseIf op = "D" Then
    '        opDia = True
    '    End If
    'End Function
    Private Function ImpDoc() As String
        ImpDoc = ""
        If opImpForNin.Checked Then
            ImpDoc = "N" ' "N" no se imrime el documento
        ElseIf opImpForGen.Checked Then
            ImpDoc = "G" ' "G" Se imprime con formato del TEKFORM
        End If
        Return ImpDoc
    End Function
    Private Function ImpDoc2(ByRef op As String) As String
        ImpDoc2 = ""
        If op = "S" Then
            '        opImpForEst = True
        ElseIf op = "N" Then
            opImpForNin.Checked = True
        ElseIf op = "G" Then
            opImpForGen.Checked = True
        End If
        Return ImpDoc2
    End Function
    Private Function TipoCosto() As String
        TipoCosto = ""
        If opCosDig.Checked Then
            TipoCosto = "D" ' "D" tipo de costo DIGITADO
        ElseIf opCosPro.Checked Then
            TipoCosto = "P" '"P" tipo de costo PROMEDIO
        ElseIf opCosUlt.Checked Then
            TipoCosto = "U" ' "U" tipo de costo ULTIMO
        ElseIf opCosNin.Checked Then
            TipoCosto = "N" '   "N" tipo de costo NINGUNO
        ElseIf OpCosLiq.Checked Then
            TipoCosto = "L" '   "L" tipo de costo calculado liquidando importaciones con documentos
        ElseIf OpCosLiqClas.Checked Then
            TipoCosto = "Q" '   "Q" tipo de costo calculado liquidando importaciones con clasificadores
        End If
    End Function
    Private Function TipoCosto2(ByRef op As String) As Object
        TipoCosto2 = ""
        If op = "D" Then
            opCosDig.Checked = True
        ElseIf op = "P" Then
            opCosPro.Checked = True
        ElseIf op = "U" Then
            opCosUlt.Checked = True
        ElseIf op = "N" Then
            opCosNin.Checked = True
        ElseIf op = "L" Then
            OpCosLiq.Checked = True
        ElseIf op = "Q" Then
            OpCosLiqClas.Checked = True
        End If
    End Function
    Private Function ArtSerAcf() As String
        Dim Aux As String
        ' "A" cuando se refiere a faturar ARTICULOS
        If chFacArt.Checked Then
            Aux = "A"
        Else
            Aux = "*"
        End If
        ' "S" cuando se refiere a SERVICIOS
        If chFacSer.Checked Then
            Aux = Aux & "S"
        Else
            Aux = Aux & "*"
        End If
        ' "F" ACTIVOS FIJOS
        If chFacAcf.Checked Then
            Aux = Aux & "F"
        Else
            Aux = Aux & "*"
        End If
        ArtSerAcf = Aux
    End Function
    Private Function ArtSerAcf2(ByRef op As String) As String
        ArtSerAcf2 = ""
        If Mid(op, 1, 1) = "A" Then
            chFacArt.Checked = True
        Else
            chFacArt.Checked = False
        End If
        If Mid(op, 2, 1) = "S" Then
            chFacSer.Checked = True
        Else
            chFacSer.Checked = False
        End If
        If Mid(op, 3, 1) = "F" Then
            chFacAcf.Checked = True
        Else
            chFacAcf.Checked = False
        End If
    End Function


    'Private Sub btMasCtas_Click()
    'If btMasCtas.Caption = "Mas Ctas" Then
    '    frCtaRet.Visible = True
    '    btMasCtas.Caption = "Atras"
    'Else
    '    frCtaRet.Visible = False
    '    btMasCtas.Caption = "Mas Ctas"
    'End If
    '
    'End Sub

    'Private Sub btModificar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    '    EsNuevo = 0
    'End Sub

    Private Sub VerDialog()
        dgRutasOpen.Title = "Escoja un Formulario"
        dgRutasOpen.Filter = "*.fdg"
        dgRutasOpen.ShowDialog()
    End Sub

    Private Function MostrarCtas(ByVal Nombre As String, ByVal Codigo As System.Windows.Forms.TextBox) As String
        Dim ct As New CtaMtn.BuscaCta
        Dim nom As String = ""
        Dim i As Integer
        Dim cod As String
        i = InStr(Codigo.Text, ";")
        cod = ct.BuscaCtaCtb(nom, "I")
        If i > 0 Then
            Nombre = Nombre & " def:" & nom
            MostrarCtas = Mid(Codigo.Text, 1, i) & cod
        Else
            Nombre = nom
            MostrarCtas = cod
        End If
        ct = Nothing
    End Function

    'Private Sub BusquedaEnLinea_Click()
    '    BuscarCta
    'End Sub

    'Private Sub Buscar()
    '    Dim RsAux As New ADODB.Recordset
    '    Dim COD As String
    '    COD = "SELECT Cta_Codigo,Cta_Nombre FROM AdcCta WHERE Cta_Codigo='" & trim(Dato(1)) & "'"
    '    RsAux.Open COD, ConxAdcom, adOpenKeyset, adLockOptimistic
    '    If RsAux.RecordCount > 0 Then
    '        Dato(2) = RsAux!cta_nombre
    '    Else
    '        Dato(1) = ""
    '    End If
    'End Sub

    Private Sub chDefEst_Click()
        'SSTab1.TabVisible(2) = IIf(chDefEst.Value.tostring())
        '    Mallita.LineaEdicion
    End Sub

    Private Sub LlenarTipo()
        fImpuestos.Visible = False
        LabContabilidad.Visible = False
        LabInventario.Visible = False

        ChGenTipGas.Visible = False
        fImpuestos.Visible = False

        ChImp1.Checked = False
        ChImp2.Checked = False
        ChImp3.Checked = False
        chImp4.Checked = False
        chkNoBajoCosto.CheckState = CheckState.Unchecked
        chkNoBajoCosto.Visible = False
        If dbDoc.SelectedValue Is Nothing Then Exit Sub
        If dbDoc.SelectedValue.ToString = "" Then Exit Sub


        Select Case dbDoc.SelectedValue.ToString

            Case Is = "DIA"
                LlenarTipoDiario()

            Case "FAC", "DEV", "FAP", "DEP", "NDC", "NCC", "NDP", "NCP"
                LlenarTipoVentasCompras()
                ChImp1.Checked = True

            Case "IBG", "EBG", "AJI", Is = "AJE", "TRF"
                LlenarIngresoEgreso()

            Case "PRC", "PEC", "PEP", "PRP", "REQ"
                LlenarProforPedido()

            Case "NDC", "NCC", "NDP", "NCP"
                LlenarNotaCreditoDebito()

            Case "RTC", "RTP"
                LlenarRetenciones()

            Case "ING", "EGR", "TRB", "NCB", "NDB", "VIC", "VEC"
                LlenarBancos()

            Case "MAF"
                LlenarActivosFijos()
            Case "REM"
                LlenarRemisiones()
        End Select
        CargarTipoDocumentoSRI()
        CambiarEtiquetas()

        If dbDoc.SelectedValue.ToString = "FAC" Or dbDoc.SelectedValue.ToString = "DEV" Then
            opCosDig.Enabled = False
            opCosPro.Checked = True
        Else
            opCosDig.Enabled = True
        End If
        If dbDoc.SelectedValue.ToString = "FAP" Or dbDoc.SelectedValue.ToString = "DEP" Or dbDoc.SelectedValue.ToString = "NDP" Then
            OpCosLiq.Visible = True
            opCosNin.Visible = True
            chkRegistraImportaciones.Visible = True
        Else
            OpCosLiq.Visible = False
            OpCosLiq.Checked = False
            OpCosLiqClas.Checked = False
            chkRegistraImportaciones.Visible = False
            chkRegistraImportaciones.Checked = False
        End If
    End Sub

    Private Sub LlenarTipoDiario()

        chRefCon.Visible = True
        chRefCon.Checked = True
        chRefCon.Enabled = False

        ChGenTipGas.Visible = True

        frImpFor.Visible = True
        chRefInv.Visible = False
        chRefInv.Enabled = True
        chRefAcf.Visible = False
        chRefAcf.Enabled = True
        chFacArt.Enabled = True
        chFacSer.Enabled = True
        chFacAcf.Enabled = True
        frFac.Visible = False
        chGuaUltCom.Visible = False
        chGenSinExi.Visible = False
        chRepCodFil.Visible = False
        chDefEst_Click()
        chRefCon_CheckStateChanged(chRefCon, New System.EventArgs())
        chRefInv_CheckStateChanged(chRefInv, New System.EventArgs())

    End Sub

    Private Sub LlenarActivosFijos()

        chRefCon.Visible = True
        chRefCon.Checked = False
        chRefCon.Enabled = True
        frImpFor.Visible = True
        '   chDefEst.Visible = False
        chRefInv.Visible = False
        chRefInv.Enabled = True
        chRefAcf.Visible = True
        chRefAcf.Checked = True
        chFacArt.Enabled = True
        chFacSer.Enabled = True
        chFacAcf.Enabled = True
        chRefAcf.Enabled = False
        frFac.Visible = False
        chGuaUltCom.Visible = False
        chGenSinExi.Visible = False
        chRepCodFil.Visible = False
        chRefCon_CheckStateChanged(chRefCon, New System.EventArgs())
        chRefInv_CheckStateChanged(chRefInv, New System.EventArgs())

    End Sub

    Private Sub CambiarEtiquetas()
        'If dbDoc.SelectedValue.tostring = "MAF" Then
        '    LbValVtaInv.Text = "Reexpresión costo activo"
        '    lbValVtaOIva.Text = "Reexpresión de reexpresión acum."
        '    lbSubVtaCIva.Text = "Reexpresión de depresiación acum."
        '    lbValDes.Text = "Reexpresión total"
        '    lbValNetoVta.Text = "Reexpresión del costo del activo"
        '    lbIva.Text = "Depresiación de la reexpresión acum."
        '    LbOtrSIva.Text = "Depresiación total"
        '    lbTotDesInd.Visible = False
        '    txtTotDesIndD.Visible = False
        '    txtTotDesIndH.Visible = False
        '    btTotDesIndD.Visible = False
        '    btTotDesIndH.Visible = False
        'Else
        '    LbValVtaInv.Text = "Artículos :"
        '    lbValVtaOIva.Text = "Cruce documentos"
        '    lbSubVtaCIva.Text = "Servicios/Otros:"
        '    lbValDes.Text = ""
        '    lbValNetoVta.Text = "Activos Fijos:"
        '    lbIva.Text = "Descuento Artículos:"
        '    LbOtrSIva.Text = "Descuento Servicios:"
        '    lbTotDesInd.Visible = True
        '    txtTotDesIndD.Visible = True
        '    txtTotDesIndH.Visible = True
        '    btTotDesIndD.Visible = True
        '    btTotDesIndH.Visible = True
        'End If

    End Sub

    Private Sub LlenarBancos()

        chRefCon.Visible = True
        ''chRefCon.Value = False
        chRefCon.Enabled = True
        chRefInv.Visible = False
        chRefInv.Enabled = True
        chFacArt.Enabled = True
        chFacSer.Enabled = True
        chFacAcf.Enabled = True
        chRefAcf.Visible = False
        chRefAcf.Enabled = True
        frFac.Visible = False
        '   frCosto.Visible = False
        chGuaUltCom.Visible = False
        chGenSinExi.Visible = False
        chRepCodFil.Visible = False
        '    FrCta.Visible = False
        'SSTab1.TabVisible(2) = False
        chRefCon_CheckStateChanged(chRefCon, New System.EventArgs())
        chRefInv_CheckStateChanged(chRefInv, New System.EventArgs())
        '    frConInd.Visible = False
    End Sub

    Private Sub LlenarNotaCreditoDebito()

        chRefCon.Visible = True
        'chRefCon.Value = False
        chRefCon.Enabled = True
        chRefInv.Visible = False
        chRefInv.Enabled = True
        chRefAcf.Visible = False
        chFacArt.Enabled = True
        chFacSer.Enabled = True
        chFacAcf.Enabled = True
        chRefAcf.Enabled = True
        frFac.Visible = False
        '   frCosto.Visible = False
        chGuaUltCom.Visible = False
        chGenSinExi.Visible = False
        chRepCodFil.Visible = False
        '   FrCta.Visible = False
        'SSTab1.TabVisible(2) = False
        chRefCon_CheckStateChanged(chRefCon, New System.EventArgs())
        chRefInv_CheckStateChanged(chRefInv, New System.EventArgs())
        '   frConInd.Visible = False
        'If dbDoc.SelectedValue.tostring = "NCC" Or dbDoc.SelectedValue.tostring = "NDP" Then
    End Sub

    Private Sub LlenarRetenciones()

        chRefCon.Visible = True
        chRefCon.Enabled = True
        chRefInv.Visible = False
        chRefInv.Enabled = True
        chRefAcf.Visible = False
        chFacArt.Enabled = True
        chFacSer.Enabled = True
        chFacAcf.Enabled = True
        chRefAcf.Enabled = True
        frFac.Visible = False
        '   frCosto.Visible = False
        chGuaUltCom.Visible = False
        chGenSinExi.Visible = False
        chRepCodFil.Visible = False
        '        CargarTipoDocumento()
        '   FrCta.Visible = False
        'SSTab1.TabVisible(2) = False
        chRefCon_CheckStateChanged(chRefCon, New System.EventArgs())
        chRefInv_CheckStateChanged(chRefInv, New System.EventArgs())
        '   frConInd.Visible = False
        'If dbDoc.SelectedValue.tostring = "NCC" Or dbDoc.SelectedValue.tostring = "NDP" Then
    End Sub
    Private Sub LlenarProforPedido()

        chRefCon.Visible = False
        chRefCon.Checked = False
        chRefCon.Enabled = True
        fImpuestos.Visible = True
        '   chDefEst.Visible = False
        chRefInv.Visible = False
        chRefInv.Enabled = True
        chRefAcf.Visible = False
        chRefAcf.Enabled = True
        frFac.Visible = False
        chFacArt.Enabled = True
        chFacSer.Enabled = True
        chFacAcf.Enabled = True
        '   frCosto.Visible = False
        chGuaUltCom.Visible = False
        chGenSinExi.Visible = False
        chRepCodFil.Visible = True
        '    FrCta.Visible = False
        'SSTab1.TabVisible(2) = False
        chRefCon_CheckStateChanged(chRefCon, New System.EventArgs())
        chRefInv_CheckStateChanged(chRefInv, New System.EventArgs())
        '    frConInd.Visible = False
    End Sub

    Private Sub LlenarIngresoEgreso()

        chRefCon.Visible = True
        'chRefCon.Value = False
        chRefCon.Enabled = True
        frImpFor.Visible = True
        '   chDefEst.Visible = False
        chRefInv.Visible = True
        chRefInv.Checked = True
        chRefInv.Enabled = False
        chRefAcf.Visible = False
        chRefAcf.Enabled = True
        '   frFac.Visible = True
        '   frCosto.Visible = True
        chFacArt.Checked = True
        chFacArt.Enabled = False
        chFacSer.Enabled = False
        chFacAcf.Enabled = False
        chGuaUltCom.Visible = True
        chGenSinExi.Visible = True
        chRepCodFil.Visible = True
        ' FrCta.Visible = False
        '   SSTab1.TabVisible(2) = False
        chRefCon_CheckStateChanged(chRefCon, New System.EventArgs())
        chRefInv_CheckStateChanged(chRefInv, New System.EventArgs())
        '   frConInd.Visible = True
    End Sub

    Private Sub LlenarRemisiones()

        chRefCon.Visible = True
        'chRefCon.Value = False
        chRefCon.Enabled = True
        frImpFor.Visible = True
        '   chDefEst.Visible = False
        chRefInv.Visible = True
        'chRefInv.Checked = true
        chRefInv.Enabled = True
        chRefAcf.Visible = False
        chRefAcf.Enabled = True
        '   frFac.Visible = True
        '   frCosto.Visible = True
        '       CargarTipoDocumento()
        chFacArt.Checked = True
        chFacArt.Enabled = False
        chFacSer.Enabled = False
        chFacAcf.Enabled = False
        chGuaUltCom.Visible = True
        chGenSinExi.Visible = True
        chRepCodFil.Visible = True
        ' FrCta.Visible = False
        '   SSTab1.TabVisible(2) = False
        chRefCon_CheckStateChanged(chRefCon, New System.EventArgs())
        chRefInv_CheckStateChanged(chRefInv, New System.EventArgs())
        '   frConInd.Visible = True
    End Sub


    Private Sub LlenarTipoVentasCompras()

        fImpuestos.Visible = True
        chRefCon.Visible = True
        'chRefCon.Value = False
        chRefCon.Enabled = True
        frImpFor.Visible = True
        'chDefEst.Visible = False
        chRefInv.Visible = True
        chRefInv.Enabled = True
        chRefAcf.Visible = True
        chRefAcf.Enabled = True
        chFacArt.Enabled = True
        chFacSer.Enabled = True
        chFacAcf.Enabled = True
        '   FrCta.Visible = True
        '   frFac.Visible = True
        '   frCosto.Visible = True
        chGuaUltCom.Visible = True
        chGenSinExi.Visible = True
        chRepCodFil.Visible = True
        '   SSTab1.TabVisible(1) = False
        '   frConInd.Visible = True
        '      CargarTipoDocumento()
        chRefCon_CheckStateChanged(chRefCon, New System.EventArgs())
        chRefInv_CheckStateChanged(chRefInv, New System.EventArgs())
        chkNoBajoCosto.Visible = True
    End Sub

    'Private Sub conectarBDD()
    '    Dim coneccion As New DaxLib.DaxLibBases
    '    coneccion.TipoBase = "10"
    '    strConxadcom = coneccion.StrAdcom
    '    strConxIvaret = coneccion.StrIvaret
    '    conectar.ConnectionString = coneccion.StrAdcom
    '    conectarDaxsys.ConnectionString = coneccion.StrDaxsys
    'End Sub

    Private Sub SYSP13_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim I As Integer
        '        strConxadcom = DattCom.datosEmpresa.strConxAdcom
        cargar = True
        op = New OpcDoc
        LabGeneral_Click(eventSender, eventArgs)
        Sw = False
        Dim ssql As String = "select abreviación,'Documento tipo ' + Descripcion as Descripcion from syscod where tiporeferencia = 'Documentos' and abreviación <> '#' order by Descripcion "
        'Dim datS As New DataTable()
        'Dim dat As New Data.SqlClient.SqlDataAdapter(ssql, strConxadcom)
        'dat.Fill(datS)
        dbDoc.DataSource = DattCom.SqlDatos.leerTabla(ssql, DattCom.datosEmpresa.strConxAdcom)
        dbDoc.ValueMember = "abreviación"
        dbDoc.DisplayMember = "Descripcion"
        '        conectarDaxsys.Close()
        I = 0
        ssql = "SELECT Descripcion  FROM syscod where tiporeferencia = 'Impuestos'  and abreviación <> '#' "
        Using da As New SqlDataAdapter(ssql, DattCom.datosEmpresa.strConxAdcom)
            Using dat1 As New DataTable()
                da.Fill(dat1)
                For Each row As DataRow In dat1.Rows
                    I += 1
                    If I = 1 Then
                        ChImp1.Text = row("Descripcion").ToString()
                    ElseIf I = 2 Then
                        ChImp2.Text = row("Descripcion").ToString()
                    ElseIf I = 3 Then
                        ChImp3.Text = row("Descripcion").ToString()
                    ElseIf I = 4 Then
                        chImp4.Text = row("Descripcion").ToString()
                    End If
                Next
            End Using
        End Using
        Dim progg As New DaxCombobx.CargCmbBox
        progg.DaxCombosDoc("INV", "", False, DattCom.datosEmpresa.strConxAdcom, ComboDoc1)
        'ssql = "SELECT opc_documento,opc_nombre FROM AdcOpc ORDER BY Opc_tipo"
        CargarTipoDocumentoSRI()
        CargarChekList(ListCabecera, "0")
        CargarChekList(ListItems, "1")
        'Using da As New SqlDataAdapter(ssql, strConxadcom)
        '    Using dat1 As New DataTable()
        '        da.Fill(datS)
        '        ComboDoc1.DataSource = dat1
        '        ComboDoc1.ValueMember = "opc_documento"
        '        ComboDoc1.DisplayMember = "opc_nombre"
        '        conectar.Close()
        '    End Using
        'End Using

        Dim prog As New DaxCombobx.CargCmbBox()
        prog.DaxCombosClasf(DattCom.datosEmpresa.strConxAdcom, CmbClasificadorCosteo)
        cargar = False
        LimpiaFormulario()
    End Sub

    Private Sub CargarChekList(ByVal checkList As CheckedListBox, ByVal ubica As String)
        Dim ssql As String = "select Nombre from AdcClasfCtb where regporconcepto='" & ubica & "'"
        'Dim cmd As New SqlCommand(ssql, conectar)
        'Dim dat As SqlDataReader = Nothing
        'If conectar.State = ConnectionState.Open Then conectar.Close()
        'conectar.Open()
        'dat = cmd.ExecuteReader()
        Dim dat As SqlDataReader = DattCom.SqlDatos.leerBase(ssql, DattCom.datosEmpresa.strConxAdcom)
        With checkList
            While dat.Read
                If Not IsDBNull(dat(0)) Then .Items.Add(dat(0))
            End While
        End With
        'conectar.Close()
    End Sub

    Private Sub SYSP13_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        cerrando()
        Me.Dispose()
    End Sub
    Private Sub cerrando()
        'If conectar.State = ConnectionState.Closed Then conectar.Open()
        'Dim sql As String = "begin try DROP TABLE [dbo].[adcSopOblg] end try begin catch end catch ;"
        'DattCom.SqlDatos.ejecutarComandoAdcom(sql)

        'sql = "begin try DROP VIEW [dbo].[adcSopOblg] end try begin catch end catch ;"
        'DattCom.SqlDatos.ejecutarComando(sql, DattCom.datosEmpresa.strConxAdcom)

        'sql = "SELECT Opc_documento, TipoSoporteObligatorio"
        'sql += " into  adcSopOblg"
        'sql += " FROM dbo.AdcOpc"
        'sql += " WHERE Opc_tipo IN (SELECT Abreviación FROM dbo.Syscod WHERE (TipoReferencia = 'documentos') AND (SUBSTRING(Caracteristica1, 3, 1) = '2'))"
        'sql += " AND (SUBSTRING(Opc_extension, 5, 1) = '1') AND (TipoSoporteObligatorio > '')"

        'Dim dat As SqlDataReader = DattCom.SqlDatos.leerBase(sql, DattCom.datosEmpresa.strConxAdcom)
        'DattCom.SqlDatos.ejecutarComando(sql, DattCom.datosEmpresa.strConxAdcom)

    End Sub
    Private Sub FormatoAux1_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles FormatoAux1.KeyDown
        Dim KeyCode As Integer = eventArgs.KeyCode
        Dim Shift As Integer = eventArgs.KeyData \ &H10000
        If KeyCode = System.Windows.Forms.Keys.F2 Then BtRut3_Click_1(eventSender, eventArgs) 'BtRut3_Click(BtRut3, New System.EventArgs())
    End Sub

    Private Sub FormatoAux2_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles FormatoAux2.KeyDown
        Dim KeyCode As Integer = eventArgs.KeyCode
        Dim Shift As Integer = eventArgs.KeyData \ &H10000
        If KeyCode = System.Windows.Forms.Keys.F2 Then BtRut4_Click_1(eventSender, eventArgs) 'BtRut4_Click(BtRut4, New System.EventArgs())
    End Sub

    Private Sub FormatoAux3_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles FormatoAux3.KeyDown
        Dim KeyCode As Integer = eventArgs.KeyCode
        Dim Shift As Integer = eventArgs.KeyData \ &H10000
        If KeyCode = System.Windows.Forms.Keys.F2 Then BtRut5_Click(BtRut5, New System.EventArgs())
    End Sub

    Private Sub Impresora_1_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles Impresora_1.KeyDown
        Dim KeyCode As Integer = eventArgs.KeyCode
        Dim Shift As Integer = eventArgs.KeyData \ &H10000
        If KeyCode = System.Windows.Forms.Keys.F2 Then Command1_Click(eventSender, eventArgs) 'Command1_Click(Command1, New System.EventArgs())
    End Sub

    Private Sub Impresora_2_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles Impresora_2.KeyDown
        Dim KeyCode As Integer = eventArgs.KeyCode
        Dim Shift As Integer = eventArgs.KeyData \ &H10000
        If KeyCode = System.Windows.Forms.Keys.F2 Then Command2_Click(Command2, New System.EventArgs())
    End Sub

    Private Sub Impresora_3_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles Impresora_3.KeyDown
        Dim KeyCode As Integer = eventArgs.KeyCode
        Dim Shift As Integer = eventArgs.KeyData \ &H10000
        If KeyCode = System.Windows.Forms.Keys.F2 Then Command1_Click(eventSender, eventArgs)
    End Sub

    Private Sub txtAbr_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtAbr.KeyDown
        Dim KeyCode As Integer = eventArgs.KeyCode
        Dim Shift As Integer = eventArgs.KeyData \ &H10000
        If KeyCode = System.Windows.Forms.Keys.Return Then

            '         RsOpc.Find "opc_documento = '" & txtabr & "'"
            '        a = RsOpc!opc_nombre
            '        If RsOpc.EOF Then
            '               Limpia
            '               Exit Sub
            '        End If
            op.Cargar(txtAbr.Text, "")
            If op.VerificarDocumento(txtAbr.Text) = False Then Sw = False : txtAbr.Text = "" : Exit Sub
            Sw = True
            CargarDatos()
        End If
    End Sub

    'Private Sub txtNumIni_KeyPress(KeyAscii As Integer)
    'If (KeyAscii >= 48 And KeyAscii <= 59) Or (KeyAscii = 8) Or (KeyAscii = 46) Or (KeyAscii = 44")) then
    '  txtNumIni.Locked = False
    'Else
    '   txtNumIni.Locked = True
    'End If
    'End Sub

    'Private Sub CargarTipoDocumentoSRI()
    '    Dim cmd As New SqlCommand()
    '    Dim ssql As String = ""
    '    Dim dat1 As SqlDataReader = Nothing
    '    '        Dim claves As String
    '    Dim ElCodigo As String = ""
    '    Dim ElCodigo2 As String = ""
    '    'On Error Resume Next
    '    'cmd.Connection = conectarDaxsy
    '    Select Case dbDoc.SelectedValue.ToString
    '        Case "FAC", "DEV", "NDC", "NCC", "REM", "RTC"
    '            ElCodigo = "2"
    '            ElCodigo2 = "4"
    '        Case "FAP", "DEP", "NDP", "NCP", "RTP"
    '            ElCodigo = "1"
    '            ElCodigo2 = "3"
    '    End Select
    '    Dim tieneSri As Boolean = (DattCom.datosEmpresa.AnexoTransaccional Or DattCom.datosEmpresa.Ivaret)
    '    Label13.Visible = (tieneSri And Val(ElCodigo) <> 0)
    '    TipoComprobanteSri.Visible = Label13.Visible
    '    If tieneSri = True Then
    '        'ssql = "SELECT * FROM comprobantesAutorizados WHERE secuencialTransaccion like '%" + ElCodigo + "%' or secuencialTransaccion  like '%" + ElCodigo2 + "%'"
    '        'cmd.CommandText = ssql
    '        'If conectarDaxsys.State = ConnectionState.Open Then conectarDaxsys.Close()
    '        'conectarDaxsys.Open()
    '        'dat1 = cmd.ExecuteReader()
    '        'If Not dat1.Read And ElCodigo <> 0 Then
    '        '    MsgBox("No se encontró la tabla del SRI de Tipos de Transaccion")
    '        '    Exit Sub
    '        'End If
    '        'claves = dat1("TipoComprobante")
    '        'conectarDaxsys.Close()
    '        'If claves = "" And ElCodigo <> 0 Then
    '        '    MsgBox("En tabla de tipo de transacciones, codigo " & ElCodigo.ToString() & " el tipo de documentos esta mal definido")
    '        '    Exit Sub
    '        'End If
    '        'claves = SepararClaves(claves, "codigo")
    '        ssql = " select '' as codigo,'No afecta al SRI' as TipoDeComprobante  union all "
    '        ssql += "Select código, (substring(Ltrim(código) + '    ',0,3) + ' - ' + Descripción) as TipodeComprobante From comprobantesAutorizados WHERE secuencialTransaccion like '%" + ElCodigo + "%' or secuencialTransaccion  like '%" + ElCodigo2 + "%'"
    '        Dim dt As New DataTable
    '        Dim da As New SqlDataAdapter(ssql, DattCom.datosEmpresa.strConxIvaret)
    '        da.Fill(dt)
    '        TipoComprobanteSri.DataSource = dt
    '        TipoComprobanteSri.ValueMember = "codigo"
    '        TipoComprobanteSri.DisplayMember = "TipoDeComprobante"
    '    End If
    'End Sub


    Private Sub CargarTipoDocumentoSRI()
        Dim ssql As String = ""
        Dim ElCodigo As String = ""
        Dim ElCodigo2 As String = ""

        ' Determinar códigos según el tipo de documento
        Select Case dbDoc.SelectedValue.ToString
            Case "FAC", "DEV", "NDC", "NCC", "REM", "RTC"
                ElCodigo = "2"   ' Código para ventas
                ElCodigo2 = "4"
            Case "FAP", "DEP", "NDP", "NCP", "RTP"
                ElCodigo = "1"   ' Código para compras
                ElCodigo2 = "3"
        End Select

        Dim tieneSri As Boolean = (DattCom.datosEmpresa.AnexoTransaccional Or DattCom.datosEmpresa.Ivaret)
        Label13.Visible = (tieneSri And Val(ElCodigo) <> 0)
        TipoComprobanteSri.Visible = Label13.Visible

        If tieneSri = True And (ElCodigo <> "" Or ElCodigo2 <> "") Then
            ' Consulta para obtener los tipos de comprobante SRI
            ssql = " SELECT '18' as codigo, '18 - FACTURA' as TipoDeComprobante UNION ALL "
            ssql += " SELECT '01' as codigo, '01 - FACTURA' as TipoDeComprobante UNION ALL "
            ssql += " SELECT '04' as codigo, '04 - NOTA DE CREDITO' as TipoDeComprobante UNION ALL "
            ssql += " SELECT '05' as codigo, '05 - NOTA DE DEBITO' as TipoDeComprobante UNION ALL "
            ssql += " SELECT '06' as codigo, '06 - GUIA DE REMISION' as TipoDeComprobante UNION ALL "
            ssql += " SELECT '07' as codigo, '07 - COMPROBANTE DE RETENCION' as TipoDeComprobante "

            ' Si tienes tabla de comprobantes autorizados, puedes agregar:
            ' ssql += " UNION ALL "
            ' ssql += " SELECT código, (código + ' - ' + Descripción) as TipoDeComprobante "
            ' ssql += " FROM comprobantesAutorizados "
            ' ssql += " WHERE secuencialTransaccion like '%" & ElCodigo & "%' "
            ' ssql += " OR secuencialTransaccion like '%" & ElCodigo2 & "%'"

            Try
                Dim dt As New DataTable
                Dim da As New SqlDataAdapter(ssql, DattCom.datosEmpresa.strConxIvaret)
                da.Fill(dt)

                ' Agregar opción "No afecta al SRI" al inicio
                Dim dr As DataRow = dt.NewRow()
                dr("codigo") = ""
                dr("TipoDeComprobante") = "No afecta al SRI"
                dt.Rows.InsertAt(dr, 0)

                TipoComprobanteSri.DataSource = dt
                TipoComprobanteSri.ValueMember = "codigo"
                TipoComprobanteSri.DisplayMember = "TipoDeComprobante"

            Catch ex As Exception
                MessageBox.Show("Error al cargar tipos de comprobante SRI: " & ex.Message)
            End Try
        Else
            ' Si no hay SRI, cargar solo la opción por defecto
            Dim dt As New DataTable
            dt.Columns.Add("codigo")
            dt.Columns.Add("TipoDeComprobante")
            dt.Rows.Add("", "No afecta al SRI")
            TipoComprobanteSri.DataSource = dt
            TipoComprobanteSri.ValueMember = "codigo"
            TipoComprobanteSri.DisplayMember = "TipoDeComprobante"
        End If
    End Sub
    Private Function SepararClaves(ByRef Clave As String, ByRef Campo As String) As String
        Dim I, j As Integer
        Dim Tt As Single
        Dim a As String
        Dim Cadena As String
        I = Len(Clave)
        If I = 0 Or Campo = "" Then SepararClaves = "" : Exit Function
        Cadena = " " & Campo & " = "
        Tt = 0
        For j = 1 To I
            a = Mid(Clave, j, 1)
            If a = "," Then
                Cadena = Cadena & " OR " & Campo & " = "
            Else
                Cadena = Cadena & a
            End If
        Next j
        SepararClaves = Cadena
    End Function

    Private Sub _Toolbar1_Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncerrar.Click
        btCancelar_Click(sender, e)
    End Sub

    Private Sub _Toolbar1_Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnguardar.Click
        GuardarRegistro()
        LimpiaFormulario()
    End Sub

    Private Sub _Toolbar1_Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub btnnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        LimpiaFormulario()
        EsNuevo = 1
        PonerBotones()
        'bloquear(False)
    End Sub

    Sub CargarDatos()
        'On Error Resume Next
        Dim auxCamp As String = ""
        Dim Linea As String
        Dim ssql As String = "select * from adcopc where opc_documento='" & txtAbr.Text & "'"
        Dim dat As SqlDataReader = DattCom.SqlDatos.leerBase(ssql, DattCom.datosEmpresa.strConxAdcom)
        If dat.Read Then
            '  If Not IsDBNull(dat("Opc_documento")) Then txtAbr.Text = dat("Opc_documento")
            If Not IsDBNull(dat("opc_nombre")) Then txtDes.Text = dat("opc_nombre").ToString

            ' LLENAR COMBOS
            ' TIPO DE DOCUMENTO
            Try
                'If dat("Opc_Tipo").ToString <> dbDoc.SelectedValue.ToString() Then dbDoc.SelectedValue = dat("Opc_Tipo").ToString

                If dat("Opc_Tipo") IsNot Nothing Then
                    Dim valorOpcTipo As String = dat("Opc_Tipo").ToString()
                    Dim valorActual As String = If(dbDoc.SelectedValue IsNot Nothing, dbDoc.SelectedValue.ToString(), "")

                    If valorOpcTipo <> valorActual Then
                        dbDoc.SelectedValue = valorOpcTipo
                    End If
                End If



            Catch
                dbDoc.SelectedValue = dat("Opc_Tipo").ToString
            End Try

            'TIPO DOCUMENTO SRI
            'If TipoComprobanteSri.SelectedValue.ToString() <> dat("Opc_TipoSri").ToString() Then TipoComprobanteSri.SelectedValue = dat("Opc_TipoSri").ToString

            'TIPO DOCUMENTO SRI
            Try
                If TipoComprobanteSri IsNot Nothing Then
                    If Not IsDBNull(dat("Opc_TipoSri")) Then
                        Dim valorOpcTipoSri As String = dat("Opc_TipoSri").ToString()
                        Dim valorActual As String = If(TipoComprobanteSri.SelectedValue IsNot Nothing,
                                          TipoComprobanteSri.SelectedValue.ToString(), "")

                        If valorOpcTipoSri <> valorActual Then
                            TipoComprobanteSri.SelectedValue = valorOpcTipoSri
                        End If
                    End If
                End If
            Catch ex As Exception
                ' Si hay error, intentar asignar directamente
                If TipoComprobanteSri IsNot Nothing AndAlso Not IsDBNull(dat("Opc_TipoSri")) Then
                    TipoComprobanteSri.SelectedValue = dat("Opc_TipoSri").ToString()
                End If
            End Try



            ' TIPO DE DOCUMENTO GENERA EN ARTICULOS COMPUESTOS
            If Not IsDBNull(dat("opc_GeneraMP")) Then
                GeneraSalidaMP.Checked = Convert.ToBoolean(dat("opc_GeneraMP").ToString())
                If Not IsDBNull(dat("TipoSalidaMP")) Then
                    If dat("TipoSalidaMP").ToString() > "" Then ComboDoc1.SelectedValue = dat("TipoSalidaMP")
                End If
            Else
                GeneraSalidaMP.Checked = False
                ComboDoc1.Visible = False
            End If


            'LlenarTipo()

            'If Not IsNull(!Opc_numini) Then txtNumIni = !Opc_numini
            If Not IsDBNull(dat("Opc_Extension")) Then ArmarExtenciones2(dat("Opc_Extension").ToString())
            If Not IsDBNull(dat("Opc_SnCompDes")) Then chGenComDes.Checked = Convert.ToBoolean(dat("Opc_SnCompDes"))

            '      If Not IsNull(!Opc_TipoGas) Then ChGenTipGas = IIf(!Opc_TipoGas.tostring())
            If Not IsDBNull(dat("Opc_SnRepetir")) Then chRepCodFil.Checked = Convert.ToBoolean(dat("Opc_SnRepetir"))
            If Not IsDBNull(dat("opc_contabiliza")) Then chRefCon.Checked = Convert.ToBoolean(dat("opc_contabiliza"))
            If Not IsDBNull(dat("Opc_GENERARDia")) Then Reconta.Checked = (dat("Opc_GENERARDia").ToString() = "S")
            If Not IsDBNull(dat("Opc_ImpriDoc")) Then ImpDoc2(dat("Opc_ImpriDoc").ToString())
            If Not IsDBNull(dat("Opc_ImpriForm")) Then txtFormato.Text = dat("Opc_ImpriForm").ToString()
            'If Not IsNull(!Opc_SnDefEstan) Then chDefEst = IIf(!Opc_SnDefEstan.tostring())
            If Not IsDBNull(dat("Opc_SnSinExis")) Then chGenSinExi.Checked = Convert.ToBoolean(dat("Opc_SnSinExis").ToString())
            If Not IsDBNull(dat("Opc_tipocos")) Then TipoCosto2(dat("Opc_tipocos").ToString())
            If Not IsDBNull(dat("ClasificadorCosto")) Then CmbClasificadorCosteo.SelectedValue = dat("ClasificadorCosto".ToString())

            If Not IsDBNull(dat("opc_snguarcos")) Then chGuaUltCom.Checked = Convert.ToBoolean(dat("opc_snguarcos").ToString())

            If Not IsDBNull(dat("opc_ctadebe")) Then txtValTotDocD.Text = dat("opc_ctadebe").ToString() : Label14.Text = libctactb.NombreCuentaContable(txtValTotDocD.Text)
            If Not IsDBNull(dat("opc_ctaHaber")) Then txtValTotDocH.Text = dat("opc_ctaHaber").ToString() : Label31.Text = libctactb.NombreCuentaContable(txtValTotDocH.Text)
            If Not IsDBNull(dat("opc_ctavalvtainvd")) Then txtValVenInvD.Text = dat("opc_ctavalvtainvd").ToString() : Label16.Text = libctactb.NombreCuentaContable(txtValVenInvD.Text)
            If Not IsDBNull(dat("opc_ctavalvtainvh")) Then txtValVenInvH.Text = dat("opc_ctavalvtainvh").ToString() : Label43.Text = libctactb.NombreCuentaContable(txtValVenInvH.Text)
            If Not IsDBNull(dat("opc_ctavtaoivad")) Then txtValVenOIvaD.Text = dat("opc_ctavtaoivad").ToString() : Label17.Text = libctactb.NombreCuentaContable(txtValVenOIvaD.Text)
            If Not IsDBNull(dat("opc_ctavtaoivah")) Then txtValVenOIvaH.Text = dat("opc_ctavtaoivah").ToString() : Label42.Text = libctactb.NombreCuentaContable(txtValVenOIvaH.Text)
            If Not IsDBNull(dat("opc_ctasubtcivad")) Then txtSubVenCIvaD.Text = dat("opc_ctasubtcivad").ToString() : Label18.Text = libctactb.NombreCuentaContable(txtSubVenCIvaD.Text)
            If Not IsDBNull(dat("opc_ctasubtcivah")) Then txtSubVenCIvaH.Text = dat("opc_ctasubtcivah").ToString() : Label41.Text = libctactb.NombreCuentaContable(txtSubVenCIvaD.Text)
            If Not IsDBNull(dat("opc_ctavaldesd")) Then txtValDesD.Text = dat("opc_ctavaldesd").ToString() : Label20.Text = libctactb.NombreCuentaContable(txtValDesD.Text)
            If Not IsDBNull(dat("opc_ctavaldesh")) Then txtValDesH.Text = dat("opc_ctavaldesh").ToString() : Label40.Text = libctactb.NombreCuentaContable(txtValDesH.Text)
            If Not IsDBNull(dat("opc_ctavalnetod")) Then txtValNetVenD.Text = dat("opc_ctavalnetod").ToString() : Label21.Text = libctactb.NombreCuentaContable(txtValNetVenD.Text)
            If Not IsDBNull(dat("opc_ctavalnetoh")) Then txtValNetVenH.Text = dat("opc_ctavalnetoh").ToString() : Label39.Text = libctactb.NombreCuentaContable(txtValNetVenH.Text)
            If Not IsDBNull(dat("opc_ctaivad")) Then txtIvaD.Text = dat("opc_ctaivad").ToString() : Label22.Text = libctactb.NombreCuentaContable(txtIvaD.Text)
            If Not IsDBNull(dat("opc_ctaivah")) Then txtIvaH.Text = dat("opc_ctaivah").ToString() : Label38.Text = libctactb.NombreCuentaContable(txtIvaH.Text)
            If Not IsDBNull(dat("opc_ctaotrosivad")) Then txtOtrSIvaD.Text = dat("opc_ctaotrosivad").ToString() : Label23.Text = libctactb.NombreCuentaContable(txtOtrSIvaD.Text)
            If Not IsDBNull(dat("opc_ctaotrosivah")) Then txtOtrSIvaH.Text = dat("opc_ctaotrosivah").ToString() : Label37.Text = libctactb.NombreCuentaContable(txtOtrSIvaH.Text)
            If Not IsDBNull(dat("opc_ctatotdesindid")) Then txtTotDesIndD.Text = dat("opc_ctatotdesindid").ToString() : Label24.Text = libctactb.NombreCuentaContable(txtTotDesIndD.Text)
            If Not IsDBNull(dat("opc_ctatotdesindih")) Then txtTotDesIndH.Text = dat("opc_ctatotdesindih").ToString() : Label36.Text = libctactb.NombreCuentaContable(txtTotDesIndH.Text)
            If Not IsDBNull(dat("opc_ctaCostoD")) Then txtCtaCosD.Text = dat("opc_ctaCostoD").ToString() : Label25.Text = libctactb.NombreCuentaContable(txtCtaCosD.Text)
            If Not IsDBNull(dat("opc_ctaCostoH")) Then txtCtaCosH.Text = dat("opc_ctaCostoH").ToString() : Label35.Text = libctactb.NombreCuentaContable(txtCtaCosH.Text)

            If Not IsDBNull(dat("opc_ctaRetBieD")) Then txtRetBieD.Text = dat("opc_ctaRetBieD").ToString() : Label26.Text = libctactb.NombreCuentaContable(txtRetBieD.Text)
            If Not IsDBNull(dat("opc_ctaRetBieH")) Then txtRetBieH.Text = dat("opc_ctaRetBieH").ToString() : Label34.Text = libctactb.NombreCuentaContable(txtRetBieH.Text)
            If Not IsDBNull(dat("opc_ctaRetSerD")) Then txtRetSerD.Text = dat("opc_ctaRetSerD").ToString() : Label27.Text = libctactb.NombreCuentaContable(txtRetSerD.Text)
            If Not IsDBNull(dat("opc_ctaRetSerH")) Then txtRetSerH.Text = dat("opc_ctaRetSerH").ToString() : Label33.Text = libctactb.NombreCuentaContable(txtRetSerH.Text)
            If Not IsDBNull(dat("opc_ctaRetFteD")) Then txtRetFteD.Text = dat("opc_ctaRetFteD").ToString() : Label28.Text = libctactb.NombreCuentaContable(txtRetFteD.Text)
            If Not IsDBNull(dat("opc_ctaRetFteH")) Then txtRetFteH.Text = dat("opc_ctaRetFteH").ToString() : Label32.Text = libctactb.NombreCuentaContable(txtRetFteH.Text)

            If Not IsDBNull(dat("opc_ctaRetFte1D")) Then txtRetFte1D.Text = dat("opc_ctaRetFte1D").ToString() : Label5.Text = libctactb.NombreCuentaContable(txtRetFte1D.Text)
            If Not IsDBNull(dat("opc_ctaRetFte1H")) Then txtRetFte1H.Text = dat("opc_ctaRetFte1H").ToString() : Label52.Text = libctactb.NombreCuentaContable(txtRetFte1H.Text)
            If Not IsDBNull(dat("opc_ctaRetFte2D")) Then txtRetFte2D.Text = dat("opc_ctaRetFte2D").ToString() : Label4.Text = libctactb.NombreCuentaContable(txtRetFte2D.Text)
            If Not IsDBNull(dat("opc_ctaRetFte2H")) Then txtRetFte2H.Text = dat("opc_ctaRetFte2H").ToString() : Label51.Text = libctactb.NombreCuentaContable(txtRetFte2H.Text)

            Select Case dbDoc.SelectedValue.ToString
                Case "ING", "EGR", "TRB", "NCB", "NDB", "VIC", "VEC"
                    txtRetFte1D.Text = txtTotDesIndD.Text
                    txtRetFte1H.Text = txtTotDesIndH.Text
            End Select

            If Not IsDBNull(dat("opc_snartind")) Then chArt.Checked = Convert.ToBoolean(dat("opc_snartind").ToString())
            If Not IsDBNull(dat("opc_sndesind")) Then chDes.Checked = Convert.ToBoolean(dat("opc_sndesind").ToString())
            If Not IsDBNull(dat("opc_snotrociva")) Then chOtrCIva.Checked = Convert.ToBoolean(dat("opc_snotrociva").ToString())
            If Not IsDBNull(dat("opc_snotrosiva")) Then chOtrSIva.Checked = Convert.ToBoolean(dat("opc_snotrosiva").ToString())
            If Not IsDBNull(dat("opc_snartseracf")) Then ArtSerAcf2(dat("opc_snartseracf").ToString)
            If Not IsDBNull(dat("Opc_ImpCtb")) Then FormatoCtb.Text = (dat("Opc_ImpCtb").ToString)
            If Not IsDBNull(dat("FormatoElec")) Then FormatoElec.Text = (dat("FormatoElec").ToString)
            If Not IsDBNull(dat("Opc_CantidadCero")) Then RegistraCantCero.Checked = Convert.ToBoolean(dat("Opc_CantidadCero").ToString())

            If Not IsDBNull(dat("Opc_Propietario")) Then Check3.Checked = Convert.ToBoolean(dat("Opc_Propietario").ToString())
            If Not IsDBNull(dat("Opc_Bodega")) Then Check6.Checked = Convert.ToBoolean(dat("Opc_Bodega").ToString())
            If Not IsDBNull(dat("Opc_IdSri")) Then Check5.Checked = Convert.ToBoolean(dat("Opc_IdSri").ToString())
            If Not IsDBNull(dat("Opc_Autonumero")) Then ChkNumerar.Checked = Convert.ToBoolean(dat("Opc_Autonumero").ToString())
            If Not IsDBNull(dat("Opc_consolidar")) Then Chpuedeconsolidar.Checked = Convert.ToBoolean(dat("Opc_consolidar").ToString())
            If Not IsDBNull(dat("DocumentoNoActivado")) Then Check7.Checked = Convert.ToBoolean(dat("DocumentoNoActivado").ToString())
            If Not IsDBNull(dat("AutorizarPago")) Then Check8.Checked = Convert.ToBoolean(dat("AutorizarPago").ToString())

            If Not IsDBNull(dat("FormatoAux_1")) Then FormatoAux1.Text = dat("FormatoAux_1").ToString()
            If Not IsDBNull(dat("FormatoAux_2")) Then FormatoAux2.Text = dat("FormatoAux_2").ToString()
            If Not IsDBNull(dat("FormatoAux_3")) Then FormatoAux3.Text = dat("FormatoAux_3").ToString()
            If Not IsDBNull(dat("ImpresoraAux_1")) Then Impresora_1.Text = dat("ImpresoraAux_1").ToString()
            If Not IsDBNull(dat("ImpresoraAux_2")) Then Impresora_2.Text = dat("ImpresoraAux_2").ToString()
            If Not IsDBNull(dat("ImpresoraAux_3")) Then Impresora_3.Text = dat("ImpresoraAux_3").ToString()

            If Not IsDBNull(dat("Opc_ctaCuadre")) Then ChkCdreTotal.Text = dat("Opc_ctaCuadre").ToString()
            If Not IsDBNull(dat("Opc_ctavalvtainvCuadre")) Then ChkCdreArticulos.Text = dat("Opc_ctavalvtainvCuadre").ToString()
            If Not IsDBNull(dat("Opc_ctavtaoivaCuadre")) Then ChkCdreNOUSADO.Text = dat("Opc_ctavtaoivaCuadre").ToString()
            If Not IsDBNull(dat("Opc_ctasubtcivaCuadre")) Then ChkCdreConceptos.Text = dat("Opc_ctasubtcivaCuadre").ToString()
            If Not IsDBNull(dat("Opc_ctavalnetoCuadre")) Then ChkCdreActivos.Text = dat("Opc_ctavalnetoCuadre").ToString()
            If Not IsDBNull(dat("Opc_ctaivaCuadre")) Then ChkCdreDescuentoArticulos.Text = dat("Opc_ctaivaCuadre").ToString()
            If Not IsDBNull(dat("Opc_ctaotrosivaCuadre")) Then ChkCdreDescuentosServicios.Text = dat("Opc_ctaotrosivaCuadre").ToString()
            If Not IsDBNull(dat("Opc_ctatotdesindiCuadre")) Then ChkCdreImpuestos.Text = dat("Opc_ctatotdesindiCuadre").ToString()
            If Not IsDBNull(dat("Opc_CtaCostoCuadre")) Then ChkCdreCostoArticulos.Text = dat("Opc_CtaCostoCuadre").ToString()
            If Not IsDBNull(dat("Opc_CtaRetBieCuadre")) Then ChkCdreRetIvaBien.Text = dat("Opc_CtaRetBieCuadre").ToString()
            If Not IsDBNull(dat("Opc_CtaRetSerCuadre")) Then ChkCdreRetIvaServ.Text = dat("Opc_CtaRetSerCuadre").ToString()
            If Not IsDBNull(dat("Opc_CtaRetFteCuadre")) Then ChkCdreRetFte.Text = dat("Opc_CtaRetFteCuadre").ToString()
            If Not IsDBNull(dat("Opc_CtaRetFte1Cuadre")) Then ChkCdreRetFte1.Text = dat("Opc_CtaRetFte1Cuadre").ToString()
            If Not IsDBNull(dat("Opc_CtaRetFte2Cuadre")) Then ChkCdreRetFte1.Text = dat("Opc_CtaRetFte2Cuadre").ToString()
            If Not IsDBNull(dat("Opc_LimiteCuadre")) Then Text1.Text = dat("Opc_LimiteCuadre").ToString()
            If Not IsDBNull(dat("DatosAuxiliares")) Then cargarAux(ListCabecera, Split(dat("DatosAuxiliares").ToString(), ","))
            If Not IsDBNull(dat("DatosAuxiliaresDet")) Then cargarAux(ListItems, Split(dat("DatosAuxiliaresDet").ToString(), ","))
            If Not IsDBNull(dat("TipoSoporteObligatorio")) Then TxtTipSop.Text = dat("TipoSoporteObligatorio").ToString()
            If Not IsDBNull(dat("NoPVPbajoCosto")) Then chkNoBajoCosto.Checked = Convert.ToBoolean(dat("NoPVPbajoCosto"))
            Dim libdat As New Daxlib
            ComandoSQL.Text = libdat.CorrijeNulo(dat("ComandoExterno"))

            Linea = "0000"
            Select Case dbDoc.SelectedValue.ToString
                Case "FAC", "FAP", "DEV", "DEP", "NDC", "NCC", "NDP", "NCP", "PRC", "PEC", "PEP", "PRP", "REQ"
                    fImpuestos.Visible = True
                    If Not IsDBNull(dat("opc_impuestos")) Then Linea = dat("opc_impuestos").ToString()
                    ChImp1.Checked = (Linea.Substring(0, 1) <> "0")
                    ChImp2.Checked = (Linea.Substring(1, 1) <> "0")
                    ChImp3.Checked = (Linea.Substring(2, 1) <> "0")
                    chImp4.Checked = (Linea.Substring(3, 1) <> "0")
                Case Else
                    fImpuestos.Visible = False
            End Select
            If Not IsDBNull(dat("Auxil1")) Then chKNoEnLinea.Checked = (dat("Auxil1").ToString() = "X")
            If Not IsDBNull(dat("Auxil2")) Then txtFormulasPVP.Text = dat("Auxil2").ToString()
            If Not IsDBNull(dat("Auxil3")) Then chkRegistraImportaciones.Checked = (dat("Auxil3").ToString() = "1")
            chkElectronico.Checked = False
            If Not IsDBNull(dat("EsElectronico")) Then chkElectronico.Checked = (Convert.ToInt16(dat("EsElectronico")) = 1)

        End If
        Sw = False
        cargar = False
        EsNuevo = 2
        txtAbr.Enabled = False
        PonerBotones()
        dat.Close()
    End Sub

    Private Sub cargarAux(ByVal checkList As CheckedListBox, ByVal lista() As String)
        Dim i As Integer = 0
        Dim j As Integer = 0
        For i = 0 To lista.Length - 1
            For j = 0 To checkList.Items.Count - 1
                If checkList.Items(j).ToString = lista(i) Then
                    checkList.SetItemChecked(j, True)
                    Exit For
                End If
            Next
        Next
    End Sub

    Private Sub btnabrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnabrir.Click
        Dim QUECODIGO As String = ""
        Dim QUENOMBRE As String = ""
        Dim prog As New BuscDocAdcom
        prog.BuscaDocAdcom("T", QUECODIGO, QUENOMBRE)
        'limpiar(Me)
        txtAbr.Text = QUECODIGO
        txtAbr_KeyDown(txtAbr, New System.Windows.Forms.KeyEventArgs(Keys.Return)) 'btBuscar_Click(sender, e)
        'bloquear(False)
    End Sub

    'Private Sub dbDoc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dbDoc.Click
    '    If dbDoc.Text > "" Then LlenarTipo()
    'End Sub

    'Private Sub dbDoc_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dbDoc.SelectedValueChanged
    '    'If cargar = False Then LlenarTipo()
    'End Sub

    'Private Sub BtnDocSop_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim QUECODIGO As String = ""
    '    Dim QUENOMBRE As String = ""
    '    Dim prog As New BuscDocAdcom
    '    prog.BuscaDocAdcom("T", QUECODIGO, QUENOMBRE)
    '    prog = Nothing
    '    TxtTipSop.Text = QUECODIGO
    '    LbNomSoporte.Text = QUENOMBRE
    'End Sub

    'Private Sub Command8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim prog As New BuscDocAdcom
    '    Dim QUECODIGO As String = ""
    '    Dim QUENOMBRE As String = ""
    '    prog.BuscaDocAdcom("C", QUECODIGO, QUENOMBRE)
    '    prog = Nothing
    '    Label46.Text = QUECODIGO
    'End Sub

    Private Sub BtRut3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtRut3.Click
        Dim prog As New BuscaFormasDoc
        Dim cod As String = prog.IniciaBuscaClase("")
        If cod <> "" Then FormatoAux1.Text = cod
        prog = Nothing
    End Sub

    Private Sub Command1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command1.Click
        Dim printer As New PrintDialog
        printer.AllowCurrentPage = False
        printer.AllowSomePages = False
        printer.PrintToFile = False
        printer.ShowHelp = False
        printer.ShowDialog()
        Impresora_1.Text = printer.PrinterSettings.PrinterName
        printer.Dispose()
        'Impresora_1 = Printer.DeviceName
    End Sub

    Private Sub BtRut4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtRut4.Click
        Dim prog As New BuscaFormasDoc
        FormatoAux2.Text = prog.IniciaBuscaClase("")
        prog = Nothing
    End Sub

    Private Sub Command2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command2.Click
        Dim printer As New PrintDialog
        printer.AllowCurrentPage = False
        printer.AllowSomePages = False
        printer.PrintToFile = False
        printer.ShowHelp = False
        printer.ShowDialog()
        Impresora_2.Text = printer.PrinterSettings.PrinterName
        printer.Dispose()
    End Sub

    Private Sub BtRut5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtRut5.Click
        Dim prog As New BuscaFormasDoc
        FormatoAux3.Text = prog.IniciaBuscaClase("")
        'UPGRADE_NOTE: El objeto prog no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        prog = Nothing
    End Sub

    Private Sub Command3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command3.Click
        Dim printer As New PrintDialog
        printer.AllowCurrentPage = False
        printer.AllowSomePages = False
        printer.PrintToFile = False
        printer.ShowHelp = False
        printer.ShowDialog()
        Impresora_3.Text = printer.PrinterSettings.PrinterName
        printer.Dispose()
    End Sub

    Private Sub txtOtrSIvaD_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOtrSIvaD.KeyDown
        If e.KeyCode = Keys.F2 Then
            txtOtrSIvaD.Text = MostrarCtas(Label23.Text, txtOtrSIvaD)
        End If
    End Sub

    Private Sub txtRetFte1D_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetFte1D.KeyDown
        If System.Windows.Forms.Keys.F2 = e.KeyCode Then
            txtRetFte1D.Text = MostrarCtas(Label5.Text, txtRetFte1D)
        End If
    End Sub

    Private Sub txtRetFte2D_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetFte2D.KeyDown
        If System.Windows.Forms.Keys.F2 = e.KeyCode Then
            txtRetFte2D.Text = MostrarCtas(Label52.Text, txtRetFte2D)
        End If
    End Sub
    Private Sub txtRetFte1H_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetFte1H.KeyDown
        If System.Windows.Forms.Keys.F2 = e.KeyCode Then
            txtRetFte1H.Text = MostrarCtas(Label4.Text, txtRetFte1H)
        End If
    End Sub

    Private Sub txtRetFte2H_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetFte2H.KeyDown
        If System.Windows.Forms.Keys.F2 = e.KeyCode Then
            txtRetFte2H.Text = MostrarCtas(Label51.Text, txtRetFte2H)
        End If
    End Sub
    Private Sub txtCtaCosD_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCtaCosD.KeyDown
        If System.Windows.Forms.Keys.F2 = e.KeyCode Then
            txtCtaCosD.Text = MostrarCtas(Label25.Text, txtCtaCosD)
        End If
    End Sub

    Private Sub txtCtaCosH_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCtaCosH.KeyDown
        If System.Windows.Forms.Keys.F2 = e.KeyCode Then
            txtCtaCosH.Text = MostrarCtas(Label35.Text, txtCtaCosH)
        End If
    End Sub

    Private Sub txtFormato_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFormato.KeyDown
        If e.KeyCode = System.Windows.Forms.Keys.F2 Then
            VerDialog()
            txtFormato.Text = dgRutasOpen.FileName
        End If
    End Sub

    Private Sub txtIvaD_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIvaD.KeyDown
        If System.Windows.Forms.Keys.F2 = e.KeyCode Then
            txtIvaD.Text = MostrarCtas(Label22.Text, txtIvaD)
        End If
    End Sub

    Private Sub txtIvaH_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIvaH.KeyDown
        If System.Windows.Forms.Keys.F2 = e.KeyCode Then
            txtIvaH.Text = MostrarCtas(Label38.Text, txtIvaH)
        End If
    End Sub

    Private Sub txtOtrSIvaH_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOtrSIvaH.KeyDown
        If System.Windows.Forms.Keys.F2 = e.KeyCode Then
            txtOtrSIvaH.Text = MostrarCtas(Label37.Text, txtOtrSIvaH)
        End If
    End Sub

    Private Sub txtRetBieD_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetBieD.KeyDown
        If System.Windows.Forms.Keys.F2 = e.KeyCode Then
            txtRetBieD.Text = MostrarCtas(Label26.Text, txtRetBieD)
        End If
    End Sub

    Private Sub txtRetBieH_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetBieH.KeyDown
        If System.Windows.Forms.Keys.F2 = e.KeyCode Then
            txtRetBieH.Text = MostrarCtas(Label34.Text, txtRetBieH)
        End If
    End Sub

    Private Sub txtRetFteD_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetFteD.KeyDown
        If System.Windows.Forms.Keys.F2 = e.KeyCode Then
            txtRetFteD.Text = MostrarCtas(Label28.Text, txtRetFteD)
        End If
    End Sub

    Private Sub txtRetFteH_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetFteH.KeyDown
        If System.Windows.Forms.Keys.F2 = e.KeyCode Then
            txtRetFteH.Text = MostrarCtas(Label32.Text, txtRetFteH)
        End If
    End Sub

    Private Sub txtRetSerD_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetSerD.KeyDown
        If System.Windows.Forms.Keys.F2 = e.KeyCode Then
            txtRetSerD.Text = MostrarCtas(Label27.Text, txtRetSerD)
        End If
    End Sub

    Private Sub txtRetSerH_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRetSerH.KeyDown
        If System.Windows.Forms.Keys.F2 = e.KeyCode Then
            txtRetSerH.Text = MostrarCtas(Label33.Text, txtRetSerH)
        End If
    End Sub

    Private Sub txtSubVenCIvaD_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSubVenCIvaD.KeyDown
        If System.Windows.Forms.Keys.F2 = e.KeyCode Then
            txtSubVenCIvaD.Text = MostrarCtas(Label18.Text, txtSubVenCIvaD)
        End If
    End Sub

    Private Sub txtSubVenCIvaH_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSubVenCIvaH.KeyDown
        If System.Windows.Forms.Keys.F2 = e.KeyCode Then
            txtSubVenCIvaH.Text = MostrarCtas(Label41.Text, txtSubVenCIvaH)
        End If
    End Sub

    Private Sub txtTotDesIndD_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTotDesIndD.KeyDown
        If System.Windows.Forms.Keys.F2 = e.KeyCode Then
            txtTotDesIndD.Text = MostrarCtas(Label24.Text, txtTotDesIndD)
        End If
    End Sub

    Private Sub txtTotDesIndH_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTotDesIndH.KeyDown
        If System.Windows.Forms.Keys.F2 = e.KeyCode Then
            txtTotDesIndH.Text = MostrarCtas(Label36.Text, txtTotDesIndH)
        End If
    End Sub

    Private Sub txtValDesD_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtValDesD.KeyDown
        If System.Windows.Forms.Keys.F2 = e.KeyCode Then
            txtValDesD.Text = MostrarCtas(Label20.Text, txtValDesD)
        End If
    End Sub

    Private Sub txtValDesH_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtValDesH.KeyDown
        If System.Windows.Forms.Keys.F2 = e.KeyCode Then
            txtValDesH.Text = MostrarCtas(Label40.Text, txtValDesH)
        End If
    End Sub

    Private Sub txtValNetVenD_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtValNetVenD.KeyDown
        If System.Windows.Forms.Keys.F2 = e.KeyCode Then
            txtValNetVenD.Text = MostrarCtas(Label21.Text, txtValNetVenD)
        End If
    End Sub

    Private Sub txtValNetVenH_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtValNetVenH.KeyDown
        If System.Windows.Forms.Keys.F2 = e.KeyCode Then
            txtValNetVenH.Text = MostrarCtas(Label39.Text, txtValNetVenH)
        End If
    End Sub

    Private Sub txtValTotDocD_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtValTotDocD.KeyDown
        If System.Windows.Forms.Keys.F2 = e.KeyCode Then
            txtValTotDocD.Text = MostrarCtas(Label14.Text, txtValTotDocD)
        End If
    End Sub

    Private Sub txtValTotDocH_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtValTotDocH.KeyDown
        If System.Windows.Forms.Keys.F2 = e.KeyCode Then
            txtValTotDocH.Text = MostrarCtas(Label31.Text, txtValTotDocH)
        End If
    End Sub

    Private Sub txtValVenInvD_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtValVenInvD.KeyDown
        If System.Windows.Forms.Keys.F2 = e.KeyCode Then
            txtValVenInvD.Text = MostrarCtas(Label16.Text, txtValVenInvD)
        End If
    End Sub

    Private Sub txtValVenInvH_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtValVenInvH.KeyDown
        If System.Windows.Forms.Keys.F2 = e.KeyCode Then
            txtValVenInvH.Text = MostrarCtas(Label43.Text, txtValVenInvH)
        End If
    End Sub

    Private Sub txtValVenOIvaD_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtValVenOIvaD.KeyDown
        If System.Windows.Forms.Keys.F2 = e.KeyCode Then
            txtValVenOIvaD.Text = MostrarCtas(Label17.Text, txtValVenOIvaD)
        End If
    End Sub

    Private Sub txtValVenOIvaH_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtValVenOIvaH.KeyDown
        If System.Windows.Forms.Keys.F2 = e.KeyCode Then
            txtValVenOIvaH.Text = MostrarCtas(Label42.Text, txtValVenOIvaH)
        End If
    End Sub

    Private Sub btCtaCosD_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        txtCtaCosD_KeyDown(txtCtaCosD, New System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.F2))
    End Sub

    Private Sub btRut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFormatoGeneral.Click
        Dim prog As New BuscaFormasDoc
        txtFormato.Text = prog.IniciaBuscaClase("")
        prog = Nothing
    End Sub

    Private Sub BtRut2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFormatoCtb.Click
        Dim prog As New BuscaFormasDoc
        FormatoCtb.Text = prog.IniciaBuscaClase("")
        prog = Nothing
    End Sub
    Private Sub btnFormatoElec_Click(sender As Object, e As EventArgs) Handles btnFormatoElec.Click
        Dim prog As New BuscaFormasDoc
        btnFormatoElec.Text = prog.IniciaBuscaClase("")
        prog = Nothing
    End Sub

    Private Sub chRefCon_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chRefCon.CheckedChanged
        LabContabilidad.Visible = chRefCon.Checked
        If chRefCon.Checked Then ArreglaContabilidad()
    End Sub

    Private Sub ArreglaContabilidad()
        Reconta.Visible = chRefCon.Checked
        If chRefCon.Checked = False Then
            Reconta.Checked = chRefCon.Checked
        End If
        FrmOtros.Visible = False
        FrmSri.Visible = False
        Select Case dbDoc.SelectedValue.ToString
            Case "ING", "EGR", "TRB", "NCB", "NDB", "VIC", "VEC"
                Label9.Text = "Conceptos registrados"
                Label10.Visible = False
                Label11.Visible = False
                Label6.Visible = False
                Label53.Visible = False
                txtRetFteD.Visible = False
                txtRetFteH.Visible = False
                txtRetSerD.Visible = False
                txtRetSerH.Visible = False
                txtRetFte1H.Visible = False
                txtRetFte1D.Visible = False
                txtRetFte2H.Visible = False
                txtRetFte2D.Visible = False
                ChkCdreRetFte.Visible = False
                ChkCdreRetFte2.Visible = False
                ChkCdreRetFte1.Visible = False
                ChkCdreRetIvaServ.Visible = False
                Label4.Visible = False
                Label5.Visible = False
                Label32.Visible = False
                Label28.Visible = False
                Label27.Visible = False
                Label32.Visible = False
                Label33.Visible = False
                Label51.Visible = False
                Label52.Visible = False

                FrmSri.Visible = True
            Case "RTC", "RTP"
                Label9.Text = "Retención Iva Bienes"
                Label10.Visible = True
                Label11.Visible = True
                Label6.Visible = True
                Label53.Visible = True
                txtRetFteD.Visible = True
                txtRetFteH.Visible = True
                txtRetSerD.Visible = True
                txtRetSerH.Visible = True
                txtRetFte1H.Visible = True
                txtRetFte1D.Visible = True
                txtRetFte2H.Visible = True
                txtRetFte2D.Visible = True
                ChkCdreRetFte.Visible = True
                ChkCdreRetFte2.Visible = True
                ChkCdreRetFte1.Visible = True
                ChkCdreRetIvaServ.Visible = True
                Label4.Visible = True
                Label5.Visible = True
                Label32.Visible = True
                Label28.Visible = True
                Label27.Visible = True
                Label32.Visible = True
                Label33.Visible = True
                Label51.Visible = True
                Label52.Visible = True
                FrmSri.Visible = True

            Case "FAC", "FAP", "DEV", "DEP", "NDC", "NCC", "NDP", "NCP"
                FrmOtros.Visible = True
        End Select
    End Sub

    Private Sub chRefInv_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chRefInv.CheckedChanged
        LabInventario.Visible = chRefInv.Checked
        chGenSinExi.Visible = chRefInv.Checked
        chRepCodFil.Visible = chRefInv.Checked
        chGuaUltCom.Visible = chRefInv.Checked
    End Sub

    Private Sub GeneraSalidaMP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneraSalidaMP.CheckedChanged
        ComboDoc1.Visible = GeneraSalidaMP.Checked 
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'bloquear(False)
    End Sub

    Private Sub Numeracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Numeracion.Click
        Dim prog As New frmAdcDocnum
        Dim TipoDoc As String
        TipoDoc = txtAbr.Text
        prog.Command1.Visible = False
        prog.UnDocumento((TipoDoc))
        prog.Close()
        prog.Dispose()
    End Sub

    Private Sub BtnDocSop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDocSop.Click
        Dim QUECODIGO As String = ""
        Dim QUENOMBRE As String = ""
        Dim prog As New BuscDocAdcom
        prog.BuscaDocAdcom("T", QUECODIGO, QUENOMBRE)
        prog = Nothing
        TxtTipSop.Text = QUECODIGO
        LbNomSoporte.Text = QUENOMBRE
    End Sub

    Private Sub Command8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command8.Click
        Dim prog As New BuscDocAdcom
        Dim QUECODIGO As String = ""
        Dim QUENOMBRE As String = ""
        prog.BuscaDocAdcom("C", QUECODIGO, QUENOMBRE)
        prog = Nothing
        Label46.Text = QUECODIGO
    End Sub

    Private Sub TipoComprobante_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = System.Windows.Forms.Keys.Delete Then TipoComprobanteSri.Text = "" : TipoComprobanteSri.SelectedIndex = 0
    End Sub

    Private Sub RestaurarEstado()
        LabGeneral.BackColor = Color.LightSteelBlue
        LabGeneral.ForeColor = Color.Gray
        LabInventario.BackColor = Color.LightSteelBlue
        LabInventario.ForeColor = Color.Gray
        LabContabilidad.BackColor = Color.LightSteelBlue
        LabContabilidad.ForeColor = Color.Gray
        LabDatos.BackColor = Color.LightSteelBlue
        LabDatos.ForeColor = Color.Gray
    End Sub
    Private Sub LabGeneral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabGeneral.Click
        PonerGeneral()
    End Sub
    Private Sub PonerGeneral()
        RestaurarEstado()
        LabGeneral.BackColor = Color.SteelBlue
        LabGeneral.ForeColor = Color.White

        TabGeneral.Visible = True
        TabContabilidad.Visible = False
        TabDatos.Visible = False
        TabInventario.Visible = False
    End Sub
    Private Sub LabInventario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabInventario.Click
        RestaurarEstado()
        LabInventario.BackColor = Color.SteelBlue
        LabInventario.ForeColor = Color.White

        TabGeneral.Visible = False
        TabContabilidad.Visible = False
        TabDatos.Visible = False
        TabInventario.Visible = True

    End Sub

    Private Sub LabContabilidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabContabilidad.Click
        RestaurarEstado()
        LabContabilidad.BackColor = Color.SteelBlue
        LabContabilidad.ForeColor = Color.White

        TabGeneral.Visible = False
        TabContabilidad.Visible = True
        TabDatos.Visible = False
        TabInventario.Visible = False

    End Sub

    Private Sub LabDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabDatos.Click, LabDatos.Click
        RestaurarEstado()
        LabDatos.BackColor = Color.SteelBlue
        LabDatos.ForeColor = Color.White

        TabGeneral.Visible = False
        TabContabilidad.Visible = False
        TabDatos.Visible = True
        TabInventario.Visible = False

    End Sub

    Private Sub Chpuedeconsolidar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chpuedeconsolidar.CheckedChanged
        Dim Activar As Boolean
        Activar = Not Chpuedeconsolidar.Checked
        Label45.Visible = Activar
        Label46.Visible = Activar
        Command8.Visible = Activar
        Label46.Text = ""
    End Sub

    Private Sub dbDoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dbDoc.SelectedIndexChanged
        If dbDoc.Text > "" Then LlenarTipo()
    End Sub

    Private Sub PonerBotones()
        btnnuevo.Visible = (EsNuevo = 0)
        btnabrir.Visible = (EsNuevo = 0)
        btnguardar.Visible = (EsNuevo > 0)
        btncerrar.Visible = (EsNuevo > 0)
        btneliminar.Visible = (EsNuevo > 0)
    End Sub

    Private Sub txtValTotDocD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValTotDocD.TextChanged
        txtValTotDocD.Text = chequearExcepcion(txtValTotDocD.Text)
    End Sub
    Private Sub txtTotDesIndH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotDesIndH.TextChanged
        txtTotDesIndH.Text = chequearExcepcion(txtTotDesIndH.Text)
    End Sub
    Private Sub txtOtrSIvaH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOtrSIvaH.TextChanged
        txtOtrSIvaH.Text = chequearExcepcion(txtOtrSIvaH.Text)
    End Sub
    Private Sub txtIvaH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIvaH.TextChanged
        txtIvaH.Text = chequearExcepcion(txtIvaH.Text)
    End Sub
    Private Sub txtRetFte1H_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRetFte1H.TextChanged
        txtRetFte1H.Text = chequearExcepcion(txtRetFte1H.Text)
    End Sub
    Private Sub txtRetFte2H_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRetFte2H.TextChanged
        txtRetFte2H.Text = chequearExcepcion(txtRetFte2H.Text)
    End Sub
    Private Sub txtRetFteH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRetFteH.TextChanged
        txtRetFteH.Text = chequearExcepcion(txtRetFteH.Text)
    End Sub
    Private Sub txtRetSerH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRetSerH.TextChanged
        txtRetSerH.Text = chequearExcepcion(txtRetSerH.Text)
    End Sub
    Private Sub txtRetBieH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRetBieH.TextChanged
        txtRetBieH.Text = chequearExcepcion(txtRetBieH.Text)
    End Sub
    Private Sub txtValVenOIvaH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValVenOIvaH.TextChanged
        txtValVenOIvaH.Text = chequearExcepcion(txtValVenOIvaH.Text)
    End Sub
    Private Sub txtValTotDocH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValTotDocH.TextChanged
        txtValTotDocH.Text = chequearExcepcion(txtValTotDocH.Text)
    End Sub
    Private Sub txtCtaCosD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCtaCosD.TextChanged
        txtCtaCosD.Text = chequearExcepcion(txtCtaCosD.Text)
    End Sub
    Private Sub txtTotDesIndD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotDesIndD.TextChanged
        txtTotDesIndD.Text = chequearExcepcion(txtTotDesIndD.Text)
    End Sub
    Private Sub txtOtrSIvaD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOtrSIvaD.TextChanged
        txtOtrSIvaD.Text = chequearExcepcion(txtOtrSIvaD.Text)
    End Sub
    Private Sub txtIvaD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIvaD.TextChanged
        txtIvaD.Text = chequearExcepcion(txtIvaD.Text)
    End Sub
    Private Sub txtRetFte1D_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRetFte1D.TextChanged
        txtRetFte1D.Text = chequearExcepcion(txtRetFte1D.Text)
    End Sub
    Private Sub txtRetFte2D_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRetFte2D.TextChanged
        txtRetFte2D.Text = chequearExcepcion(txtRetFte2D.Text)
    End Sub
    Private Sub txtRetFteD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRetFteD.TextChanged
        txtRetFteD.Text = chequearExcepcion(txtRetFteD.Text)
    End Sub
    Private Sub txtRetSerD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRetSerD.TextChanged
        txtRetSerD.Text = chequearExcepcion(txtRetSerD.Text)
    End Sub
    Private Sub txtRetBieD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRetBieD.TextChanged
        txtRetBieD.Text = chequearExcepcion(txtRetBieD.Text)
    End Sub
    Private Sub txtValVenOIvaD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValVenOIvaD.TextChanged
        txtValVenOIvaD.Text = chequearExcepcion(txtValVenOIvaD.Text)
    End Sub
    Private Sub txtCtaCosH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCtaCosH.TextChanged
        txtValVenOIvaD.Text = chequearExcepcion(txtValVenOIvaD.Text)
    End Sub
    Private Function chequearExcepcion(ByVal Campo As String) As String
        Dim c As Integer
        c = InStr(Campo, ";")
        If c > 0 Then
            If Mid(Campo, 1, 1) <> "&" Then Campo = Mid$(Campo, 1, c - 1)
        End If
        chequearExcepcion = Campo
    End Function

    Private Sub txtValDesH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValDesH.TextChanged
        txtValDesH.Text = chequearExcepcion(txtValDesH.Text)
    End Sub

    Private Sub txtValNetVenH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValNetVenH.TextChanged
        txtValNetVenH.Text = chequearExcepcion(txtValNetVenH.Text)
    End Sub

    Private Sub txtSubVenCIvaH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubVenCIvaH.TextChanged
        txtSubVenCIvaH.Text = chequearExcepcion(txtSubVenCIvaH.Text)
    End Sub

    Private Sub txtValVenInvH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValVenInvH.TextChanged
        txtValVenInvH.Text = chequearExcepcion(txtValVenInvH.Text)
    End Sub

    Private Sub txtValDesD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValDesD.TextChanged
        txtValDesD.Text = chequearExcepcion(txtValDesD.Text)
    End Sub

    Private Sub txtValNetVenD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValNetVenD.TextChanged
        txtValNetVenD.Text = chequearExcepcion(txtValNetVenD.Text)
    End Sub

    Private Sub txtSubVenCIvaD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubVenCIvaD.TextChanged
        txtSubVenCIvaD.Text = chequearExcepcion(txtSubVenCIvaD.Text)
    End Sub

    Private Sub txtValVenInvD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValVenInvD.TextChanged
        txtValVenInvD.Text = chequearExcepcion(txtValVenInvD.Text)
    End Sub

    Private Sub OpCosLiqClas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpCosLiqClas.CheckedChanged
        If OpCosLiqClas.Checked = True Then CmbClasificadorCosteo.Enabled = True Else CmbClasificadorCosteo.Enabled = False
    End Sub

    Private Sub Reconta_CheckedChanged(sender As Object, e As EventArgs) Handles Reconta.CheckedChanged

    End Sub

    Private Sub Toolbar1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles Toolbar1.ItemClicked

    End Sub


    'Private Sub Button1_Click(sender As Object, e As EventArgs)
    '    Dim prog As New daxAccs.registrar
    '    prog.registro(CONEMP.EmpresaAct.codigo, ControlUsuario.Identifica, txtAbr.Text, "", strConxadcom, ClassConxion.strConxDaxSys)
    'End Sub
End Class
