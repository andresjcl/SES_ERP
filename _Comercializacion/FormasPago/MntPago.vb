Imports DattCom
Public Class MntPago
    Public Sub FormasDePago()
        Try
            Dim prog As New FormPago
            prog.FormPago(datosEmpresa.strConxAdcom, datosEmpresa.strConxIvaret, datosEmpresa.strConIniSis)
            prog.ShowDialog()
        Catch
            MsgBox("No se puede accesar a las formas de pago" & vbCr & Err.Description, MsgBoxStyle.Critical, "Conexión errada")
        End Try
    End Sub

    'Public Sub DocsPendientes(ByVal cruceSucursales As Boolean, ByRef DocumentosPendientes As String, ByVal Sucursal As String, ByVal TipoDoc As String, ByVal IdClaveDoc As Double, ByVal CodCliente As String, ByVal NombCli As String, ByVal NroLote As String, ByVal ValorAplica As Double, ByRef ValorAbonos As Double, Optional ByVal Tipocuenta As String = "", Optional ByVal Consulta As Boolean = False)
    ' documentospendientes esta formado por ,, para separar cada documento y ; para separar cada campo para compatibilidad con vb6
    '        Dim prog As New DocPendientes.frmDocPndt()

    '.cruceSucursales = cruceSucursales,
    '    .SoloConsulta = Consulta,
    '    .QueSuc = Sucursal,
    '    .TipDoc = TipoDoc,
    '    .QueIdclavedoc = IdClaveDoc,
    '    .NombreCli = NombCli,
    '    .QueCliente = CodCliente,
    '    .QueLote = NroLote,
    '    .ValorParaAplicar = ValorAplica
    '    }
    '    'prog.DocsPending = DocumentosPendientes
    '    DocumentosPendientes += ""
    '    If DocumentosPendientes.Length > 0 And Consulta = False Then prog.DocsPending = Split(DocumentosPendientes, "{}")
    '    prog.QueTipoCta = Tipocuenta
    '    prog.ShowDialog()
    '    'DocumentosPendientes = prog.DocsPending
    '    If Not prog.DocsPending Is Nothing And Consulta = False Then
    '        ValorAbonos = prog.ValorAbonado
    '        DocumentosPendientes = ""
    '        For i As Integer = 0 To prog.DocsPending.Length - 1
    '            DocumentosPendientes += prog.DocsPending(i) & "{}"
    '        Next i
    '    End If
    '    'prog.Dispose()
    'End Sub

    'Public Sub DocsPendientes(ByVal cruceSucursales As Boolean, ByRef DocumentosPendientes() As String, ByVal Sucursal As String, ByVal TipoDoc As String, ByVal IdClaveDoc As Double, ByVal CodCliente As String, ByVal NombCli As String, ByVal NroLote As String, ByVal ValorAplica As Double, ByRef ValorAbonos As Double, Optional ByVal Tipocuenta As String = "", Optional ByVal Consulta As Boolean = False)
    '    ' documentosPendientes es una ,atriz  
    '    Dim prog As New FormDocPend With {
    '        .cruceSucursales = cruceSucursales,
    '        .SoloConsulta = Consulta,
    '        .QueSuc = Sucursal,
    '        .TipDoc = TipoDoc,
    '        .QueIdclavedoc = IdClaveDoc,
    '        .NombreCli = NombCli,
    '        .QueCliente = CodCliente,
    '        .QueLote = NroLote,
    '        .ValorParaAplicar = ValorAplica,
    '        .DocsPending = DocumentosPendientes,
    '        .QueTipoCta = Tipocuenta
    '    }
    '    prog.ShowDialog()
    '    DocumentosPendientes = prog.DocsPending
    '    prog.Dispose()
    'End Sub

    Public Sub INIPagos(ByVal IdClaveDocu As Double, ByRef ClaseDePagos As DaxComercia.classPagosDoc, ByVal CodPersona As String _
             , ByVal SucDoc As String, ByVal TipDoc As String, ByVal Fecha As String, Optional ByVal EsConsulta As Boolean = False _
             , Optional ByVal OpcDocumento As String = "", Optional ByVal NumDoc As Double = 0, Optional ByVal FormPagoPredef As String = "EFE" _
             , Optional ByVal TotalPago As Double = 0, Optional ByVal esLiquidacion As Boolean = False)

        Dim prog2 As New frmFormasPago
        With prog2
            .fac_idclavedoc = IdClaveDocu
            .Fac_Cliente = CodPersona
            .fac_EsLiquidacion = esLiquidacion
            .fac_Sucursal = SucDoc
            .fac_tipoDoc = TipDoc
            .fac_Opcdocumento = OpcDocumento
            .fac_TotalPago = TotalPago
            .fac_fecha = Fecha
            .fac_NumeroDoc = NumDoc.ToString()
            .fac_EsLiquidacion = esLiquidacion
            .fac_esConsulta = EsConsulta
            .fac_FormaPagoPredefinida = FormPagoPredef
            .fac_CodCliente = CodPersona

            .claseDePagos = ClaseDePagos
            '.fac_DocsPending = Split(ClaseDePagos, "{}") ' para comptabilidad con vb6 viene una string deberia venir una matriz
        End With
        prog2.ShowDialog()
        ClaseDePagos = prog2.claseDePagos
        'If prog2.fac_DocsPending.Length > 0 Then
        '    ClaseDePagos = ""
        '    For i As Integer = 0 To prog2.fac_DocsPending.Length - 1
        '        If prog2.fac_DocsPending(i) <> "" Then ClaseDePagos = ClaseDePagos & prog2.fac_DocsPending(i) & "{}"
        '    Next i
        'End If
    End Sub

    Public Function CrearEfectivo(valor As String) As String
        Dim lospagos As String
        Dim IdformasDePago As String = ""
        Dim PagoCredito As String = ""
        Dim GrupoPago As String = ""
        Dim concepto As String = ""
        Dim prog As New EmpNomR.AdcNomb
        concepto = prog.RetornaNombrePago("EFE", datosEmpresa.strConxAdcom)
        lospagos = ClassCtaCartera.ctasCorrientes.codigoSri(IdformasDePago, GrupoPago, PagoCredito, concepto)
        lospagos = lospagos & ";;"
        lospagos = lospagos & PagoCredito & ";"
        lospagos = lospagos & concepto & ";"
        lospagos = lospagos & ";;;;;;;;;"
        lospagos = lospagos & IdformasDePago & ";;;;;;;;"
        lospagos = lospagos & GrupoPago & ";"
        lospagos = lospagos & ";"
        lospagos = lospagos & valor
        Return lospagos & "{}"
    End Function

    Public Function CrearPagoCliente(TipoPago As String, valor As String, Optional Habitacion As String = "") As String
        Dim lospagos As String = ""
        Dim IdformasDePago As String = TipoPago
        Dim PagoCredito As String = ""
        Dim GrupoPago As String = ""
        Dim concepto As String = ""
        Dim prog As New EmpNomR.AdcNomb
        'concepto = prog.RetornaNombrePago(TipoPago, StrConxadcom)
        lospagos = ClassCtaCartera.ctasCorrientes.codigoSri(IdformasDePago, GrupoPago, PagoCredito, concepto)
        lospagos = lospagos & ";;"
        lospagos = lospagos & PagoCredito & ";;"
        lospagos = lospagos & concepto & ";"
        lospagos = lospagos & ";;;;;;;"
        lospagos = lospagos & Habitacion & ";"
        lospagos = lospagos & IdformasDePago & ";;;;" & PagoCredito & ";;;;"
        lospagos = lospagos & GrupoPago & ";"
        lospagos = lospagos & ";"
        lospagos = lospagos & valor
        Return lospagos & "{}"
    End Function
    Public Function DiasPago(idpago As String) As Integer
        Dim rs As New DataTable()
        On Error Resume Next
        Dim DA As New SqlClient.SqlDataAdapter("select isnull(DiasCuotaFijas,0) as DiasFijos ,isnull(DiasCuotaVar0,0) as diasvariar  from formasdepago where idformasdepago = '" + idpago + "' ", datosEmpresa.strConxAdcom)
        DA.Fill(rs)
        If (rs.Rows.Count > 0) Then
            Dim diasVariables As Integer = Convert.ToInt32(rs.Rows(0)("diasvariar").ToString())
            Dim diasFijos As Integer = Convert.ToInt32(rs.Rows(0)("diasfijos").ToString())
            If diasFijos > diasVariables Then DiasPago = diasFijos Else DiasPago = diasVariables
        End If
        rs.Dispose()
        DA.Dispose()
    End Function
End Class
