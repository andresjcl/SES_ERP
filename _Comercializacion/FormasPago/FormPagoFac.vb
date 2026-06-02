Imports System.Data.Sql
Imports System.Data.SqlClient
Imports DattCom


Friend Class frmFormasPago
    Public fac_Sucursal As String = ""
    Public fac_tipoDoc As String = "FAP"
    Public fac_Opcdocumento As String
    Public fac_NumeroDoc As String = ""
    Public fac_idclavedoc As Double = 0
    Public fac_FechaSaldo As Date
    Public claseDePagos As DaxComercia.classPagosDoc

    Public fac_esConsulta As Boolean
    Public fac_CodCliente As String
    Public fac_esCliente As Boolean = False

    Public Fac_Cliente As String
    Public fac_EsLiquidacion As Boolean
    Public fac_fecha As String
    Public fac_FormaPagoPredefinida As String
    Public fac_TotalPago As Double = 0
    Public fac_esLiquidación As Boolean
    Public fac_NroLote As String
    Public fac_cruceSucursales As Boolean

    Dim saltar As Boolean = False
    Dim ValorTotal As Double

    Private Sub frmFormasPago_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'InicioConeccion()
        Dim prog As New DaxCombobx.CargCmbBox

        'If fac_tipoDoc = "FAP" Then
        SriFormaPagoCheques.Width = 35
        sriFormaPagoSriDocumentos.Width = 35
        SriFormaPagoSriPlan.Width = 35
        SriFormaPagoTarjeta.Width = 35
        'Else
        'SriFormaPagoCheques.Visible = False
        'sriFormaPagoSriDocumentos.Visible = False
        'SriFormaPagoSriPlan.Visible = False
        'SriFormaPagoTarjeta.Visible = False
        'End If

        DescripciónCheques.Width = 220
        descripcionPlan.Width = 220
        Descripciontarjeta.Width = 220
        DescripcionDocumentos.Width = 220

        With mallaDocumento
            .Columns("SUC").Width = 40
            .Columns("DOC").Width = 40
            .Columns("Numero").Width = 90
            .Columns("ValorCruce").Width = 100
            .Columns("Nombre").Width = 200
            .Columns("SUC").ReadOnly = True
            .Columns("DOC").ReadOnly = True
            .Columns("Numero").ReadOnly = True
            .Columns("ValorCruce").ReadOnly = True
            .Columns("Nombre").ReadOnly = True
        End With

        llenarCombosFormasPago(descripcionPlan, "0,4,6")
        llenarCombosFormasPago(DescripciónCheques, "3,5")
        llenarCombosFormasPago(DescripcionDocumentos, "2")
        llenarCombosFormasPago(Descripciontarjeta, "1")

        If claseDePagos.pagosDelDocumento.Count > 0 Then
            CargarPagosExistentes(claseDePagos)
        ElseIf fac_FormaPagoPredefinida > "" Then
            cargarFormaPagoPredefinida(fac_FormaPagoPredefinida)
        End If
        saltar = True
    End Sub

    Private Sub CargarPagosExistentes(losPagos As DaxComercia.classPagosDoc)
        Dim rp As Int32 = 0
        Dim rc As Int32 = 0
        Dim rt As Int32 = 0
        Dim rd As Int32 = 0
        Dim Fpago As New EmpNomR.AdcNomb()
        Dim pago As New DaxComercia.pagoDoc

        For Each pago In losPagos.pagosDelDocumento
            If pago.Valor <> 0 Then
                Select Case Val(pago.TipoPag)
                    Case 0, 4, 6 ' plan
                        With mallaPlanes
                            .Rows.Add()
                            .Rows(rp).Selected = True
                            .Rows(rp).Cells("SriFormaPagoSriPlan").Value = pago.autoriza
                            Try
                                .Rows(rp).Cells("descripcionPlan").Value = pago.IdFormaDePago  'Fpago.RetornaNombrePago(pago(13), StrConxadcom)
                            Catch
                                MsgBox("No existe la forma de pago " & pago.IdFormaDePago) 'Fpago.RetornaNombrePago(pago(13), StrConxadcom)
                                .Rows(rp).Cells("descripcionPlan").Value = descripcionPlan.Items(1)
                            End Try
                            .Rows(rp).Cells("valorPlan").Value = pago.Valor
                            rp += 1
                        End With
                    Case 3, 5  ' cheque
                        With mallaCheques
                            .Rows.Add()
                            .Rows(rc).Cells("SriFormaPagoCheques").Value = pago.autoriza
                            Try
                                .Rows(rc).Cells("descripciónCheques").Value = pago.IdFormaDePago  'Fpago.RetornaNombrePago(pago(13), StrConxadcom)
                            Catch
                                MsgBox("No existe la forma de pago " & pago.IdFormaDePago) 'Fpago.RetornaNombrePago(pago(13), StrConxadcom)
                            End Try
                            .Rows(rc).Cells("valorCheque").Value = pago.Valor
                            .Rows(rc).Cells("FechaVence").Value = pago.FechaVence
                            .Rows(rc).Cells("NroCheque").Value = pago.DocPagoNumero
                            .Rows(rc).Cells("Cuenta").Value = pago.NumCtaBanco
                            .Rows(rc).Cells("Banco").Value = pago.DocInstitucion
                            rc += 1
                        End With
                    Case 1  'tarjetas
                        With mallaTarjetas
                            .Rows.Add()
                            .Rows(rt).Cells("SriFormaPagoTarjeta").Value = pago.autoriza
                            Try
                                .Rows(rt).Cells("Descripciontarjeta").Value = pago.IdFormaDePago  'Fpago.RetornaNombrePago(pago(13), StrConxadcom)
                            Catch
                                MsgBox("No existe la forma de pago " & pago.IdFormaDePago)  'Fpago.RetornaNombrePago(pago(13), StrConxadcom)
                                .Rows(rt).Cells("Descripciontarjeta").Value = descripcionPlan.Items(1)
                            End Try
                            .Rows(rt).Cells("valorTarjeta").Value = pago.Valor
                            Try
                                .Rows(rt).Cells("planPago").Value = pago.PlanTarjeta
                            Catch
                                MsgBox("No existe la forma de pago " & pago.IdFormaDePago) 'Fpago.RetornaNombrePago(pago(13), StrConxadcom)
                                .Rows(rt).Cells("planPago").Value = PlanPago.Items(1)
                            End Try
                            .Rows(rt).Cells("NroTarjeta").Value = pago.DocPagoNumero
                            .Rows(rt).Cells("FinancieraTarjeta").Value = pago.DocInstitucion
                            .Rows(rt).Cells("fechaVenceTarjeta").Value = pago.FechaVence

                            rt += 1
                        End With
                    Case 2  'documentos
                        With mallaDocumento
                            .Rows.Add()
                            .Rows(rd).Cells("sriFormaPagoSriDocumentos").Value = pago.autoriza
                            Try
                                .Rows(rd).Cells("descripcionDocumentos").Value = pago.IdFormaDePago  'Fpago.RetornaNombrePago(pago(13), StrConxadcom)
                            Catch
                                MsgBox("No existe la forma de pago " & pago.IdFormaDePago) 'Fpago.RetornaNombrePago(pago(13), StrConxadcom)
                            End Try
                            .Rows(rd).Cells("valorcruce").Value = pago.Valor
                            .Rows(rd).Cells("SUC").Value = pago.DocPagoSucursal
                            .Rows(rd).Cells("DOC").Value = pago.DocPagoTipo
                            .Rows(rd).Cells("Numero").Value = pago.DocPagoNumero
                            .Rows(rd).Cells("nombre").Value = pago.DocInstitucion
                            .Rows(rd).Cells("idclavedoc").Value = pago.IdclavedocPago
                            .Rows(rd).Cells("codigoCliente").Value = pago.Beneficiario
                            rd += 1
                        End With
                End Select
            End If
            sumarTotalAplica()
        Next
    End Sub

    Private Sub cargarFormaPagoPredefinida(formaPago As String)
        Dim prog As New FormasDePago(datosEmpresa.strConxAdcom)
        Try
            prog = FormasDePago.Buscar(" idformasdepago = '" & formaPago & "'")
        Catch
            prog = Nothing
        End Try

        If prog Is Nothing Then
            MsgBox("LA FORMA DE PAGO PREDEFINIDA " & formaPago & " NO ESTÁ DEFINIDA ", MsgBoxStyle.Information) : Exit Sub
        End If

        DescripciónCheques.Width = 220
        descripcionPlan.Width = 220
        Descripciontarjeta.Width = 220
        DescripcionDocumentos.Width = 220

        If prog.Descripcion = "" Then Return
        Try
            Select Case prog.tipoformapago
                Case 0, 4, 6 ' plan
                    With mallaPlanes
                        .Rows.Add()
                        .Rows(0).Cells("descripcionPlan").Value = prog.IdFormasDePago  'Descripcion
                        .Rows(0).Cells("valorPlan").Value = fac_TotalPago
                        '                    .Rows(0).Cells("creditocontadoplan").Value = formaPago
                        '                    .Rows(0).Cells("grupopagoplan").Value = prog.tipoformapago

                        TabControl1.SelectedIndex = 0
                    End With
                Case 3, 5  ' cheque
                    With mallaCheques
                        .Rows.Add()
                        .Rows(0).Cells("DescripciónCheques").Value = prog.IdFormasDePago ' Descripcion
                        .Rows(0).Cells("valorCheque").Value = fac_TotalPago
                        '                    .Rows(0).Cells("creditocontadocheque").Value = formaPago
                        '                    .Rows(0).Cells("grupopagocheque").Value = prog.tipoformapago
                        TabControl1.SelectedIndex = 1
                    End With
                Case 1  'tarjetas
                    With mallaTarjetas
                        .Rows.Add()
                        .Rows(0).Cells("Descripciontarjeta").Value = prog.IdFormasDePago ' Descripcion
                        .Rows(0).Cells("valorTarjeta").Value = fac_TotalPago
                        '.Rows(0).Cells("creditocontadotarjeta").Value = formaPago
                        '.Rows(0).Cells("grupopagotarjeta").Value = prog.tipoformapago
                        TabControl1.SelectedIndex = 2

                    End With
            End Select
        Catch ee As Exception
            MsgBox("Exception forma de pago predefinida " & formaPago & vbCr & ee.Message)
        End Try
        sumarTotalAplica()
    End Sub


    Private Function datosSRI() As String
        Dim prog As New Buscar.frmBuscar
        Dim codigo As String = ""
        Dim ssql As String = "select abreviación,descripcion as Descripción from syscod where tiporeferencia = 'tipopagosri'"
        codigo = prog.Buscar(datosEmpresa.strConxAdcom, ssql, "abreviación", "Descripcion", "", "Formas de pago SRI")
        Return codigo
    End Function

    Private Sub llenarCombosFormasPago(ByRef cmb As DataGridViewComboBoxColumn, ByVal tipo As String)
        Dim ssql As String = "select idFormasDePago,Descripcion as Descripción  from formasdepago where tipoformapago in (" & tipo & ") order by descripcion"
        Dim cnn As New SqlConnection(datosEmpresa.strConxAdcom)
        Dim dato As New DataTable
        Dim misqlDa As SqlDataAdapter
        Try
            cnn.Open()
            misqlDa = New SqlDataAdapter(ssql, cnn)
            misqlDa.Fill(dato)
            cmb.DataSource = dato.DefaultView
            cmb.DisplayMember = "Descripción"
            cmb.ValueMember = "idFormasDePago"
        Catch e As Exception
            MsgBox("No se puede ejecutar la consulta " & vbCr & e.Message)
        End Try
    End Sub

    Private Sub mallaDocumentos_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles mallaDocumento.KeyDown
        If (mallaDocumento.CurrentCell Is Nothing) Then Return
        Dim COLL As Integer = mallaDocumento.CurrentCell.ColumnIndex
        Dim LINN As Integer = mallaDocumento.CurrentCell.RowIndex
        Dim ListDoctosAplicados As New DocPendientes.ListDocAplican()

        If mallaDocumento.Rows(LINN).Cells("DescripcionDocumentos").Value Is Nothing Then Return
        Dim Tipo As String = mallaDocumento.Rows(LINN).Cells("DescripcionDocumentos").Value.ToString()
        Try
            If e.KeyCode = Keys.F2 Then
                Select Case mallaDocumento.Columns(COLL).HeaderText
                    Case "SRI"
                        mallaDocumento.CurrentCell.Value = datosSRI()
                    Case "ValorCruce", "SUC", "DOC", "Numero", "Nombre"
                        '                        ReDim DocsPendientes(1)
                        mallaAdocumentos(ListDoctosAplicados, Tipo)
                        Dim idDoc = New ClassDoc.idDocumento
                        idDoc.Sucursal = fac_Sucursal
                        idDoc.Tipo = fac_Opcdocumento
                        idDoc.familia = fac_tipoDoc
                        Try
                            idDoc.fecha = Convert.ToDateTime(fac_fecha)
                        Catch
                            idDoc.fecha = New DateTime(1900, 1, 1)
                        End Try
                        idDoc.idClave = fac_idclavedoc
                        idDoc.numero = Val(fac_NumeroDoc)

                        Dim sald As New DocPendientes.frmDocPndt(ListDoctosAplicados, fac_CodCliente, "", idDoc, fac_NroLote, fac_TotalPago, "", False, DattCom.datosEmpresa.UltimoCierreAnual, Convert.ToDateTime(fac_fecha))
                        ListDoctosAplicados = sald.iniciarDocsPendientes()
                        '                        sald.DocsPendientes.frmDocPndt(fac_cruceSucursales, ListDoctosAplicados, fac_Sucursal, fac_tipoDoc, fac_idclavedoc, Fac_Cliente, "", "", 0, fac_TotalPago, "", False)
                        documentosAmalla(ListDoctosAplicados, Tipo)
                        sald = Nothing
                        malladocumentos_Validating()
                End Select
            End If
        Catch ee As Exception
            MsgBox(ee.Message)
        End Try
    End Sub

    Private Sub mallaAdocumentos(ByRef documentos As DocPendientes.ListDocAplican, ByVal Codconcepto As String)
        For Each mrow As DataGridViewRow In mallaDocumento.Rows
            Try
                If Not (mrow.Cells("ValorCruce").Value Is Nothing) Then
                    Dim valorDeCruce As Double = Val(mrow.Cells("ValorCruce").Value.ToString)
                    If mrow.Cells("DescripcionDocumentos").Value.ToString = Codconcepto And valorDeCruce <> 0 Then
                        Dim DocumentoAplica As New DocPendientes.DocAplica()
                        DocumentoAplica.CodigoCliente = mrow.Cells("codigoCliente").Value.ToString()
                        DocumentoAplica.formaDePagoDocumento = ""
                        DocumentoAplica.IdClaveDoc = Val(mrow.Cells("IdClaveDoc").Value.ToString())
                        DocumentoAplica.Nombre = mrow.Cells("Nombre").Value.ToString
                        DocumentoAplica.Numero = mrow.Cells("Numero").Value.ToString()
                        DocumentoAplica.sriFormaPagoSriDocumentos = mrow.Cells("sriFormaPagoSriDocumentos").Value.ToString()
                        DocumentoAplica.Sucursal = mrow.Cells("SUC").Value.ToString()
                        DocumentoAplica.TipoDoc = mrow.Cells("DOC").Value.ToString()
                        DocumentoAplica.tipodocumentoSri = mrow.Cells("tipodocumento").Value.ToString()
                        DocumentoAplica.ValorCruce = valorDeCruce
                    End If
                End If
            Catch
            End Try
        Next
    End Sub

    Private Sub documentosAmalla(ByRef documentos As DocPendientes.ListDocAplican, ByVal CodConcepto As String)
        With mallaDocumento
            ' eliminar filas de concepto igual al iniciado al pedir documentos pendientes
            For Each mrow As DataGridViewRow In mallaDocumento.Rows
                If Not mrow.Cells("DescripcionDocumentos").Value Is Nothing Then
                    If mrow.Cells("DescripcionDocumentos").Value.ToString = CodConcepto Or mrow.Cells("DescripcionDocumentos").Value.ToString = "" Then
                        mallaDocumento.Rows.Remove(mrow)
                    End If
                End If
            Next
            If documentos Is Nothing Then Return
            If documentos.ListaDocAplican.Count = 0 Then Return

            Dim rw As Int32 = 0
            Dim r As Int32 = 0
            For Each DocAplica As DocPendientes.DocAplica In documentos.ListaDocAplican
                If DocAplica.ValorCruce <> 0 Then
                    .Rows.Add()
                    r = .RowCount - 2
                    .Rows(r).Cells("DescripcionDocumentos").Value = CodConcepto
                    .Rows(r).Cells("ValorCruce").Value = DocAplica.ValorCruce
                    .Rows(r).Cells("SUC").Value = DocAplica.Sucursal
                    .Rows(r).Cells("DOC").Value = DocAplica.TipoDoc
                    .Rows(r).Cells("Numero").Value = DocAplica.Numero
                    .Rows(r).Cells("IdClaveDoc").Value = DocAplica.IdClaveDoc
                    .Rows(r).Cells("codigoCliente").Value = DocAplica.CodigoCliente
                    .Rows(r).Cells("Nombre").Value = DocAplica.Nombre

                    If DocAplica.sriFormaPagoSriDocumentos = "" Then
                        Dim CODSRI = ClassCtaCartera.ctasCorrientes.codigoSri(CodConcepto, "", "", "")
                        .Rows(r).Cells("sriFormaPagoSriDocumentos").Value = CODSRI
                    Else
                        .Rows(r).Cells("sriFormaPagoSriDocumentos").Value = DocAplica.sriFormaPagoSriDocumentos
                    End If
                End If
            Next
        End With
    End Sub


    'Private Sub mallaPlanes_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles mallaPlanes.CellEnter
    '    Try
    '        With mallaPlanes
    '            mallaCuotas.Rows.Clear()
    '            If .Rows(e.RowIndex).Cells("descripcionPlan").Value.ToString <> "" Then
    '                Dim tipo As String = .Rows(e.RowIndex).Cells("descripcionPlan").Value.ToString 'codigoPago(.Rows(e.RowIndex).Cells("descripcionPlan").Value.ToString)
    '                Dim valor As Double = CDbl(.Rows(e.RowIndex).Cells("valorPlan").Value)
    '                If fac_fecha Is Nothing Then fac_fecha = Now.ToShortDateString
    '                CalcularSoloCuotas(tipo, valor, CDate(fac_fecha), mallaCuotas, 0)
    '            End If
    '        End With
    '    Catch
    '    End Try
    'End Sub

    Private Sub mallaPlanes_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles mallaPlanes.CellEnter
        Try
            With mallaPlanes

                mallaCuotas.Rows.Clear()

                If e.RowIndex < 0 Then Exit Sub

                Dim valorCelda = .Rows(e.RowIndex).Cells("descripcionPlan").Value

                If valorCelda IsNot Nothing AndAlso valorCelda.ToString.Trim <> "" Then

                    Dim tipo As String = valorCelda.ToString
                    Dim valor As Double = 0

                    If .Rows(e.RowIndex).Cells("valorPlan").Value IsNot Nothing Then
                        Double.TryParse(.Rows(e.RowIndex).Cells("valorPlan").Value.ToString, valor)
                    End If

                    If fac_fecha Is Nothing Then
                        fac_fecha = Now.ToShortDateString
                    End If

                    CalcularSoloCuotas(tipo, valor, CDate(fac_fecha), mallaCuotas, 0)

                End If

            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub




    Private Sub CalcularSoloCuotas(ByVal TipoPago As String, ByVal ValorPago As Double, ByVal DocFecha As Date, ByRef MallaCuotas As DataGridView, Optional ValorCuota As Double = 0)
        Dim Xfecha As Date, Xdias As Integer, XvalorCuota As Double
        Dim total As Double, NumCuotas As Integer
        Dim i As Int32
        Dim ssql As String = "SELECT * from FormasDePago wheRE IdFormasdePago = '" & TipoPago & "'"
        Dim cnn As New SqlConnection(datosEmpresa.strConxAdcom)
        Dim RecPago As New DataTable
        Dim misqlDa As SqlDataAdapter
        Try
            cnn.Open()
            misqlDa = New SqlDataAdapter(ssql, cnn)
            misqlDa.Fill(RecPago)
        Catch e As Exception
            MsgBox(e.Message)
            Return
        End Try

        MallaCuotas.Columns(0).DefaultCellStyle.Format = "##########0.00"
        With RecPago
            Dim NumeroDeCuotas As Int32
            If RecPago.Rows.Count = 0 Then Return
            For R As Int32 = 0 To RecPago.Rows.Count - 1
                NumeroDeCuotas = CInt(.Rows(R).Item("numerodecuotas").ToString)
                If (ValorCuota = 0) And CInt(.Rows(R).Item("numerodecuotas").ToString) = 99 Then ValorCuota = CInt(Val(InputBox("Digite el valor de la cuota", .Rows(R).Item("Descripcion").ToString, "0")))
                If CInt(.Rows(R).Item("formadepago").ToString) = 1 Or NumeroDeCuotas = 0 Then RecPago.Dispose() : Exit Sub
                Xfecha = DocFecha
                If NumeroDeCuotas = 99 And ValorCuota > 0 Then
                    total = ValorCuota * NumCuotas
                    If ValorPago > total Then NumCuotas = NumCuotas + 1
                    XvalorCuota = ValorCuota
                Else
                    XvalorCuota = Math.Round(ValorPago / NumeroDeCuotas, 2)
                    NumCuotas = NumeroDeCuotas
                End If
                total = 0
                For i = 1 To NumCuotas
                    If CInt(.Rows(R).Item("plazofv").ToString) = 2 Then
                        Select Case i
                            Case 1
                                Xdias = CInt(.Rows(R).Item("DiasCuotaVar0").ToString)
                            Case 2
                                Xdias = CInt(.Rows(R).Item("DiasCuotaVar1").ToString)
                            Case 3
                                Xdias = CInt(.Rows(R).Item("DiasCuotaVar2").ToString)
                            Case 4
                                Xdias = CInt(.Rows(R).Item("DiasCuotaVar3").ToString)
                            Case 5
                                Xdias = CInt(.Rows(R).Item("DiasCuotaVar4").ToString)
                            Case 6
                                Xdias = CInt(.Rows(R).Item("DiasCuotaVar5").ToString)
                            Case 7
                                Xdias = CInt(.Rows(R).Item("DiasCuotaVar6").ToString)
                            Case 8
                                Xdias = CInt(.Rows(R).Item("DiasCuotaVar7").ToString)
                            Case 9
                                Xdias = CInt(.Rows(R).Item("DiasCuotaVar8").ToString)
                            Case 10
                                Xdias = CInt(.Rows(R).Item("DiasCuotaVar9").ToString)
                            Case 11
                                Xdias = CInt(.Rows(R).Item("DiasCuotaVar10").ToString)
                            Case 12
                                Xdias = CInt(.Rows(R).Item("DiasCuotaVar11").ToString)
                        End Select
                    Else : Xdias = CInt(.Rows(R).Item("DiasCuotaFijas").ToString)
                    End If
                    If TipoPago = "MES" Then Xfecha = DateAdd("m", 1, Xfecha) Else Xfecha = DateAdd("d", Xdias, Xfecha)
                    total = total + XvalorCuota
                    MallaCuotas.RowCount = i
                    MallaCuotas.Rows(i - 1).Cells(0).Value = XvalorCuota
                    MallaCuotas.Rows(i - 1).Cells(1).Value = Xfecha.ToShortDateString
                Next i
                If NumCuotas > 1 Then
                    XvalorCuota = ValorPago - total
                    MallaCuotas.Rows(NumCuotas - 1).Cells(0).Value = CDbl(MallaCuotas.Rows(NumCuotas - 1).Cells(0).Value) + XvalorCuota
                End If
            Next R
        End With
        RecPago.Dispose()
    End Sub
    'Private Function codigoPago(ByVal nombre As String) As String
    '    Dim ssql As String = "select idFormasDePago from formasdepago where Descripcion = '" & nombre & "'"
    '    Dim cnn As New SqlConnection(StrConxadcom)
    '    Dim dato As New DataTable
    '    Dim misqlDa As SqlDataAdapter
    '    Try
    '        cnn.Open()
    '        misqlDa = New SqlDataAdapter(ssql, cnn)
    '        misqlDa.Fill(dato)
    '    Catch
    '        MsgBox("No se puede ejecutar la consulta " & ssql)
    '        Return ""
    '    End Try

    '    If dato.Rows.Count = 0 Then ssql = "" Else ssql = dato.Rows(0).Item(0).ToString
    '    cnn.Close()
    '    dato.Dispose()
    '    Return ssql
    'End Function

    Private Sub mallaCuotas_CellLeave(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles mallaCuotas.CellLeave
        If saltar = False Then Return
        If e.ColumnIndex <> 1 Then Return
        Try
            With mallaPlanes
                If .Rows(e.RowIndex).Cells("descripcionPlan").Value.ToString <> "" Then
                    Dim tipo As String = .Rows(e.RowIndex).Cells("descripcionPlan").Value.ToString 'codigoPago(.Rows(e.RowIndex).Cells("descripcionPlan").Value.ToString)
                    Dim valor As Double = CDbl(.Rows(e.RowIndex).Cells("valorPlan").Value)
                    If fac_fecha Is Nothing Then fac_fecha = Now.ToShortDateString
                    CalcularSoloCuotas(tipo, valor, CDate(fac_fecha), mallaCuotas, 0)
                End If
            End With
        Catch
        End Try
    End Sub

    Private Sub mallaPlanes_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles mallaPlanes.KeyDown
        Dim COLL As Integer
        Dim LINN As Integer
        If (mallaPlanes.CurrentCell Is Nothing) Then Return
        Try
            COLL = mallaPlanes.CurrentCell.ColumnIndex
            LINN = mallaPlanes.CurrentCell.RowIndex
        Catch
            Return
        End Try
        If mallaPlanes.Rows(LINN).Cells("DescripcionPlan").Value Is Nothing Then Return
        If e.KeyCode = Keys.F2 Then
            Select Case mallaPlanes.Columns(COLL).HeaderText
                Case "ValorPlan"
                    mallaPlanes.CurrentCell.Value = Math.Round(fac_TotalPago - ValorTotal, 2)
                Case "SRI"
                    mallaPlanes.CurrentCell.Value = datosSRI()
            End Select
        ElseIf e.KeyCode = Keys.F8 Then
            Select Case mallaPlanes.Columns(COLL).HeaderText
                Case "ValorPlan"
                    Dim calc As New daxcalc.Calcula
                    mallaPlanes.CurrentCell.Value = calc.valor
            End Select

        End If
        sumarTotalAplica()
    End Sub

    Private Sub mallacheques_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles mallaCheques.KeyDown
        If (mallaCheques.CurrentCell Is Nothing) Then Return
        Dim COLL As Integer
        Dim LINN As Integer
        Try
            COLL = mallaCheques.CurrentCell.ColumnIndex
            LINN = mallaCheques.CurrentCell.RowIndex
        Catch
            Return
        End Try
        If mallaCheques.Rows(LINN).Cells("DescripciónCheques").Value Is Nothing Then Return
        If e.KeyCode = Keys.F2 Then
            Select Case mallaCheques.Columns(COLL).HeaderText
                Case "ValorCheque"
                    mallaCheques.CurrentCell.Value = fac_TotalPago - ValorTotal
                Case "Banco"
                    Dim prog As New Buscar.frmBuscar
                    Dim prog2 As New EmpNomR.AdcNomb
                    Dim Ssql As String = "select top 100 percent codigo, Nombres from identificacion where esbanco = 1 order by nombres"
                    Dim cod As String = prog.Buscar(datosEmpresa.strConxAdcom, Ssql, "codigo", "Nombres", "", "Buscar Banco")
                    mallaCheques.CurrentCell.Value = prog2.RetornaNombreDirectorio(cod, datosEmpresa.strConxAdcom)
                Case "FechaVence"
                    Dim FEC As New DaxFechas.DaxFechas()
                    Dim FF As String = Now.Date.ToShortDateString
                    If Not mallaCheques.CurrentCell.Value Is Nothing Then FF = mallaCheques.CurrentCell.Value.ToString()
                    mallaCheques.CurrentCell.Value = FEC.DaxFecha(FF)
                Case "SRI"
                    mallaCheques.CurrentCell.Value = datosSRI()
            End Select
        End If
        sumarTotalAplica()
    End Sub

    Private Sub mallaPlanes_Validating(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles mallaPlanes.CellValidated
        With mallaPlanes
            If .Rows(e.RowIndex).Cells("SriFormaPagoSriPlan").Value Is Nothing Then Return
            If e.ColumnIndex = 0 Then
                Dim conceptoSRI As String = ClassCtaCartera.ctasCorrientes.codigoSri(.Rows(e.RowIndex).Cells("descripcionPlan").Value.ToString, "", "", "")
                If .Rows(e.RowIndex).Cells("SriFormaPagoSriPlan").Value.ToString() = "" Then .Rows(e.RowIndex).Cells("SriFormaPagoSriPlan").Value = conceptoSRI
            End If
        End With
        sumarTotalAplica()
    End Sub

    Private Sub mallaCheques_Validating(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles mallaCheques.CellValidated
        With mallaCheques
            If .Rows(e.RowIndex).Cells("SriFormaPagoCheques").Value Is Nothing Then Return
            If e.ColumnIndex = 0 Then
                Dim conceptoSRI As String = ClassCtaCartera.ctasCorrientes.codigoSri(.Rows(e.RowIndex).Cells("descripciónCheques").Value.ToString(), "", "", "")
                If .Rows(e.RowIndex).Cells("SriFormaPagoCheques").Value.ToString() = "" Then .Rows(e.RowIndex).Cells("SriFormaPagoCheques").Value = conceptoSRI
            End If
        End With
        sumarTotalAplica()
    End Sub

    Private Sub mallatarjetas_Validating(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles mallaTarjetas.CellValidated
        With mallaTarjetas
            If .Rows(e.RowIndex).Cells("SriFormaPagoTarjeta").Value Is Nothing Then Return
            If e.ColumnIndex = 0 Then
                Dim conceptoSRI As String = ClassCtaCartera.ctasCorrientes.codigoSri(.Rows(e.RowIndex).Cells("Descripciontarjeta").Value.ToString(), "", "", "")
                If .Rows(e.RowIndex).Cells("SriFormaPagoTarjeta").Value.ToString = "" Then .Rows(e.RowIndex).Cells("SriFormaPagoTarjeta").Value = conceptoSRI
            End If
        End With
        sumarTotalAplica()
    End Sub

    Private Sub malladocumentos_Validating()
        sumarTotalAplica()
    End Sub

    Private Sub sumarTotalAplica()
        Dim totalP As Double = 0
        Dim totalC As Double = 0
        Dim totalT As Double = 0
        Dim totalD As Double = 0

        Dim total As Double = 0

        Dim i As Integer
        For i = 0 To mallaPlanes.RowCount - 2
            totalP += Val(mallaPlanes.Rows(i).Cells("valorPlan").Value)
        Next i
        totalplan.Text = Format(totalP, "########0.00")

        For i = 0 To mallaTarjetas.RowCount - 2
            totalT += Val(mallaTarjetas.Rows(i).Cells("valortarjeta").Value)
        Next i
        totalTarjetas.Text = Format(totalT, "########0.00")

        For i = 0 To mallaCheques.RowCount - 2
            totalC += Val(mallaCheques.Rows(i).Cells("valorCheque").Value)
        Next i
        totalCheques.Text = Format(totalC, "########0.00")

        For i = 0 To mallaDocumento.RowCount - 2
            totalD += Val(mallaDocumento.Rows(i).Cells("valorCruce").Value)
        Next i
        totalDocumentos.Text = Format(totalD, "########0.00")

        total = totalP + totalC + totalT + totalD
        totalAplicacion.Text = Format(total, "###,###,##0.00")
        ValorTotal = total
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        If MsgBox("Confirma cancelar el registro de pagos ? ", CType(MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgBoxStyle), "Registro forma de pago de facturas") = MsgBoxResult.No Then Return
        Me.Close()
    End Sub

    Private Sub mallaTarjetas_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles mallaTarjetas.KeyDown
        Dim COLL As Integer
        Dim LINN As Integer
        If (mallaTarjetas.CurrentCell Is Nothing) Then Return
        Try
            COLL = mallaTarjetas.CurrentCell.ColumnIndex
            LINN = mallaTarjetas.CurrentCell.RowIndex
        Catch
            Return
        End Try
        If mallaTarjetas.Rows(LINN).Cells("Descripciontarjeta").Value Is Nothing Then Return
        If e.KeyCode = Keys.F2 Then
            Select Case mallaTarjetas.Columns(COLL).HeaderText
                Case "ValorTarjeta"
                    mallaTarjetas.CurrentCell.Value = fac_TotalPago - ValorTotal
                Case "Financiera"
                    Dim prog As New Buscar.frmBuscar
                    Dim prog2 As New EmpNomR.AdcNomb
                    Dim Ssql As String = "select top 100 percent codigo, Nombres from identificacion where esbanco = 1 order by nombres"
                    Dim cod As String = prog.Buscar(datosEmpresa.strConxAdcom, Ssql, "codigo", "Nombres", "", "Buscar Financieras de tarjetas")
                    mallaTarjetas.CurrentCell.Value = prog2.RetornaNombreDirectorio(cod, datosEmpresa.strConxAdcom)
                Case "FechaVence"
                    Dim FEC As New DaxFechas.DaxFechas()
                    Dim FF As String = Now.Date.ToShortDateString
                    If Not mallaTarjetas.CurrentCell.Value Is Nothing Then FF = mallaTarjetas.CurrentCell.Value.ToString()
                    mallaTarjetas.CurrentCell.Value = FEC.DaxFecha(FF)
                Case "SRI"
                    mallaTarjetas.CurrentCell.Value = datosSRI()
            End Select
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click

        mallaCuotas.EndEdit()
        mallaCheques.EndEdit()
        mallaTarjetas.EndEdit()
        mallaDocumento.EndEdit()
        mallaCuotas.EndEdit()
        sumarTotalAplica()
        '        If ValorRegistrado <> fac_TotalPago Then MsgBox("El total de pagos no es igual al valor de la factura ", MsgBoxStyle.Critical) : Return
        If ValidarPagos() = False Then Return
        GuardarPagos()
        Me.Close()
    End Sub

    Private Sub GuardarPagos()
        Dim i As Integer
        Dim aux As String = ""
        On Error Resume Next
        'ReDim fac_DocsPending(mallaCheques.RowCount + mallaDocumento.RowCount + mallaPlanes.RowCount + mallaTarjetas.RowCount - 4)
        Dim concepto As String = ""
        Dim GrupoPago As String = ""
        Dim PagoCredito As String = ""
        Dim idFormasDePago As String = ""
        Dim CodSri As String = ""
        Dim ValorRegistrado As Double = 0
        Dim elPago As New DaxComercia.pagoDoc()
        claseDePagos.pagosDelDocumento.Clear()
        ''= New pagosDocumento.classPagosDoc()

        'With claseDePagos
        '    .DocSucursal = fac_Sucursal
        '    Date.TryParse(fac_fecha, .DocFecha)
        '    .DocNumero = Convert.ToDouble("0" + fac_NumeroDoc)
        '    .Doctipo = fac_Opcdocumento
        '    .DocValor = fac_TotalPago
        '    .idClaveDoc = fac_idclavedoc
        '    End With
        With (mallaPlanes)
            If .RowCount > 1 Then
                For i = 0 To .RowCount - 2
                    ValorRegistrado = 0
                    idFormasDePago = ""
                    ValorRegistrado = Val(.Rows(i).Cells("valorplan").Value.ToString)
                    idFormasDePago = .Rows(i).Cells("descripcionPlan").Value.ToString

                    If ValorRegistrado <> 0 And idFormasDePago > "" Then
                        elPago = New DaxComercia.pagoDoc()
                        CodSri = ClassCtaCartera.ctasCorrientes.codigoSri(idFormasDePago, GrupoPago, PagoCredito, concepto)
                        If .Rows(i).Cells("SriFormaPagoSriPlan").Value Is Nothing Then aux = CodSri Else aux = .Rows(i).Cells("SriFormaPagoSriPlan").Value.ToString()
                        elPago.autoriza = aux
                        elPago.CancelaFactura = CInt(PagoCredito)
                        elPago.Descripcion = concepto
                        elPago.IdFormaDePago = idFormasDePago
                        elPago.PagoACredito = CInt(PagoCredito)
                        elPago.TipoPag = GrupoPago
                        elPago.Valor = ValorRegistrado
                        claseDePagos.pagosDelDocumento.Add(elPago)
                    End If
                Next i
            End If
        End With

        With mallaCheques
            If .RowCount > 1 Then
                For i = 0 To .RowCount - 2
                    ValorRegistrado = 0
                    idFormasDePago = ""
                    ValorRegistrado = Val(.Rows(i).Cells("valorCheque").Value.ToString)
                    idFormasDePago = .Rows(i).Cells("descripciónCheques").Value.ToString
                    If ValorRegistrado <> 0 And idFormasDePago > "" Then
                        elPago = New DaxComercia.pagoDoc()
                        CodSri = ClassCtaCartera.ctasCorrientes.codigoSri(idFormasDePago, GrupoPago, PagoCredito, concepto)
                        If .Rows(i).Cells("SriFormaPagoCheques").Value Is Nothing Then aux = CodSri Else aux = .Rows(i).Cells("SriFormaPagoCheques").Value.ToString()
                        elPago.autoriza = aux
                        elPago.CancelaFactura = CInt(PagoCredito)
                        elPago.Descripcion = concepto
                        If .Rows(i).Cells("Banco").Value Is Nothing Then aux = "" Else aux = .Rows(i).Cells("Banco").Value.ToString()
                        elPago.DocInstitucion = aux
                        If .Rows(i).Cells("NroCheque").Value Is Nothing Then aux = "" Else aux = .Rows(i).Cells("NroCheque").Value.ToString()
                        elPago.DocPagoNumero = aux
                        If .Rows(i).Cells("FechaVence").Value Is Nothing Then aux = "" Else aux = .Rows(i).Cells("FechaVence").Value.ToString()
                        elPago.FechaVence = aux
                        elPago.IdFormaDePago = idFormasDePago
                        If .Rows(i).Cells("Cuenta").Value Is Nothing Then aux = "" Else aux = .Rows(i).Cells("Cuenta").Value.ToString()
                        elPago.NumCtaBanco = aux
                        elPago.PagoACredito = CInt(PagoCredito)
                        elPago.TipoPag = GrupoPago
                        elPago.Valor = ValorRegistrado
                        claseDePagos.pagosDelDocumento.Add(elPago)
                    End If
                Next i
            End If
        End With

        With mallaTarjetas
            If .RowCount > 1 Then
                For i = 0 To .RowCount - 2
                    ValorRegistrado = 0
                    idFormasDePago = ""
                    ValorRegistrado = Val(.Rows(i).Cells("valorTarjeta").Value.ToString)
                    idFormasDePago = .Rows(i).Cells("Descripciontarjeta").Value.ToString
                    If ValorRegistrado <> 0 And idFormasDePago > "" Then
                        CodSri = ClassCtaCartera.ctasCorrientes.codigoSri(idFormasDePago, GrupoPago, PagoCredito, concepto)
                        elPago = New DaxComercia.pagoDoc()
                        If .Rows(i).Cells("SriFormaPagoTarjeta").Value Is Nothing Then aux = CodSri Else aux = .Rows(i).Cells("SriFormaPagoTarjeta").Value.ToString()
                        elPago.autoriza = aux
                        elPago.CancelaFactura = CInt(PagoCredito)
                        elPago.Descripcion = concepto
                        If .Rows(i).Cells("FinancieraTarjeta").Value Is Nothing Then aux = "" Else aux = .Rows(i).Cells("FinancieraTarjeta").Value.ToString()
                        elPago.DocInstitucion = aux
                        If .Rows(i).Cells("NroTarjeta").Value Is Nothing Then aux = "" Else aux = .Rows(i).Cells("NroTarjeta").Value.ToString()
                        elPago.DocPagoNumero = aux
                        If .Rows(i).Cells("fechaVenceTarjeta").Value Is Nothing Then aux = "" Else aux = .Rows(i).Cells("fechaVenceTarjeta").Value.ToString()
                        elPago.FechaVence = aux
                        elPago.IdFormaDePago = idFormasDePago
                        elPago.PagoACredito = CInt(PagoCredito)
                        If .Rows(i).Cells("planPago").Value Is Nothing Then aux = "" Else aux = .Rows(i).Cells("planPago").Value.ToString()
                        elPago.PlanTarjeta = aux
                        elPago.TipoPag = GrupoPago
                        elPago.Valor = ValorRegistrado
                        claseDePagos.pagosDelDocumento.Add(elPago)
                    End If
                Next i
            End If
        End With

        With mallaDocumento
            If .RowCount > 1 Then
                For i = 0 To .RowCount - 2
                    ValorRegistrado = 0
                    idFormasDePago = ""
                    ValorRegistrado = Val(.Rows(i).Cells("valorcruce").Value.ToString)
                    idFormasDePago = .Rows(i).Cells("descripcionDocumentos").Value.ToString
                    If ValorRegistrado <> 0 And idFormasDePago > "" Then
                        CodSri = ClassCtaCartera.ctasCorrientes.codigoSri(idFormasDePago, GrupoPago, PagoCredito, concepto)
                        elPago = New DaxComercia.pagoDoc()
                        If .Rows(i).Cells("sriFormaPagoSriDocumentos").Value Is Nothing Then aux = CodSri Else aux = .Rows(i).Cells("sriFormaPagoSriDocumentos").Value.ToString()
                        elPago.autoriza = aux
                        If .Rows(i).Cells("CodigoCliente").Value Is Nothing Then aux = "" Else aux = .Rows(i).Cells("CodigoCliente").Value.ToString()
                        elPago.Beneficiario = aux
                        elPago.CancelaFactura = CInt(PagoCredito)
                        elPago.Descripcion = concepto
                        elPago.DocInstitucion = .Rows(i).Cells("Nombre").Value.ToString()
                        elPago.DocPagoNumero = .Rows(i).Cells("Numero").Value.ToString()
                        elPago.DocPagoSucursal = .Rows(i).Cells("SUC").Value.ToString()
                        elPago.DocPagoTipo = .Rows(i).Cells("DOC").Value.ToString()
                        If .Rows(i).Cells("Idclavedoc").Value Is Nothing Then aux = "" Else aux = .Rows(i).Cells("Idclavedoc").Value.ToString()
                        elPago.IdclavedocPago = CDbl(aux)
                        elPago.IdFormaDePago = idFormasDePago
                        elPago.PagoACredito = CInt(PagoCredito)
                        elPago.TipoPag = GrupoPago
                        elPago.Valor = CDbl(.Rows(i).Cells("valorcruce").Value.ToString())
                        claseDePagos.pagosDelDocumento.Add(elPago)
                    End If
                Next i
            End If
        End With
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        mallaCheques.Rows.Clear()
        mallaCuotas.Rows.Clear()
        mallaCuotas.Rows.Clear()
        mallaDocumento.Rows.Clear()
        mallaPlanes.Rows.Clear()
        mallaTarjetas.Rows.Clear()
    End Sub
    Private Function Nonull(valor As Object) As String
        Dim aux As String
        Try
            aux = valor.ToString
        Catch ex As Exception
            aux = ""
        End Try
        Return aux
    End Function
    'Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
    '    ' Control activo
    '    '
    '    Dim ctrl As Control = Me.ActiveControl

    '    If Not TypeOf (ctrl) Is DataGridTextBox Then
    '        ' Si el control no es del tipo DataGridTextBox,
    '        ' abandonamos el procedimiento.
    '        '
    '        Return MyBase.ProcessCmdKey(msg, keyData)
    '    End If

    '    ' Tecla presionada
    '    '
    '    Dim key As Keys = keyData

    '    Select Case key
    '        Case Keys.D0 To Keys.D9
    '            ' Teclas numéricas

    '        Case Else
    '            ' Otras teclas
    '            msg = Nothing
    '    End Select

    '    Return MyBase.ProcessCmdKey(msg, keyData)

    'End Function

    Private Sub mallaCheques_CurrentCellChanged(sender As System.Object, e As System.EventArgs) Handles mallaCheques.CurrentCellChanged
        sumarTotalAplica()
    End Sub

    Private Sub mallaPlanes_CurrentCellChanged(sender As System.Object, e As System.EventArgs) Handles mallaPlanes.CurrentCellChanged
        sumarTotalAplica()
    End Sub

    Private Sub mallaTarjetas_CurrentCellChanged(sender As System.Object, e As System.EventArgs) Handles mallaTarjetas.CurrentCellChanged
        sumarTotalAplica()
    End Sub

    Private Sub mallaPlanes_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles mallaPlanes.DataError
        MessageBox.Show("Error de datos, el valor del dato registrado es inválido")
        mallaPlanes.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = ""
    End Sub

    Private Sub mallaCheques_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles mallaCheques.DataError
        MessageBox.Show("Error de datos, el valor del dato registrado es inválido ")
        mallaCheques.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = ""
    End Sub

    Private Sub mallaTarjetas_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles mallaTarjetas.DataError
        MessageBox.Show("Error de datos, el valor del dato registrado es inválido ")
        mallaTarjetas.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = ""
    End Sub

    Private Sub mallaDocumento_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles mallaDocumento.DataError
        MessageBox.Show("Error de datos, el valor del dato registrado es inválido ")
        mallaTarjetas.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = ""
    End Sub
    Private Function ValidarPagos() As Boolean
        Dim idFormasDePago As String = ""
        Dim resp As Boolean = True
        With (mallaPlanes)
            If .RowCount > 1 Then
                For i = 0 To .RowCount - 2
                    idFormasDePago = .Rows(i).Cells("descripcionPlan").Value.ToString
                    If idFormasDePago > "" Then
                        For j = 0 To .RowCount - 2
                            If idFormasDePago = .Rows(j).Cells("descripcionPlan").Value.ToString And i <> j Then
                                MessageBox.Show("No se puede ingresar formas de pago duplicadas en planes de pago", "Validar pagos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                resp = False
                            End If
                        Next j
                    End If
                Next i
            End If
        End With

        With mallaCheques
            Dim banco As String = ""
            Dim cuenta As String = ""
            Dim cheque As String = ""
            If .RowCount > 1 Then
                For i = 0 To .RowCount - 2
                    If .Rows(i).Cells("Banco").Value Is Nothing Then banco = "" Else banco = .Rows(i).Cells("Banco").Value.ToString()
                    If .Rows(i).Cells("NroCheque").Value Is Nothing Then cheque = "" Else cheque = .Rows(i).Cells("NroCheque").Value.ToString()
                    If .Rows(i).Cells("Cuenta").Value Is Nothing Then cuenta = "" Else cuenta = .Rows(i).Cells("Cuenta").Value.ToString()
                    If banco > "" And cheque > "" And cuenta > "" Then
                        For j = 0 To .RowCount - 2
                            If (banco = .Rows(j).Cells("Banco").Value.ToString() Or
                                cheque = .Rows(i).Cells("NroCheque").Value.ToString() Or
                            cuenta = .Rows(i).Cells("Cuenta").Value.ToString()) And i <> j Then
                                MessageBox.Show("No se puede ingresar cheques duplicados en pagos", "Validar pagos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                resp = False
                            End If
                        Next j
                    End If
                Next i
            End If
        End With

        With mallaTarjetas

            Dim emisor As String = ""
            Dim marca As String = ""
            Dim numero As String = ""
            If .RowCount > 1 Then
                For i = 0 To .RowCount - 2
                    If .Rows(i).Cells("FinancieraTarjeta").Value Is Nothing Then emisor = "" Else emisor = .Rows(i).Cells("FinancieraTarjeta").Value.ToString()
                    If .Rows(i).Cells("NroTarjeta").Value Is Nothing Then numero = "" Else numero = .Rows(i).Cells("NroTarjeta").Value.ToString()
                    If .Rows(i).Cells("Descripciontarjeta").Value Is Nothing Then marca = "" Else marca = .Rows(i).Cells("Descripciontarjeta").Value.ToString()
                    If emisor > "" And numero > "" And marca > "" Then
                        For j = 0 To .RowCount - 2
                            If (emisor = .Rows(j).Cells("FinancieraTarjeta").Value.ToString() Or
                                numero = .Rows(i).Cells("NroTarjeta").Value.ToString() Or
                                marca = .Rows(i).Cells("Descripciontarjeta").Value.ToString()) And i <> j Then
                                MessageBox.Show("No se puede ingresar cheques duplicados en pagos", "Validar pagos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                resp = False
                            End If
                        Next j
                    End If
                Next i
            End If

        End With
        Return resp
    End Function



End Class
