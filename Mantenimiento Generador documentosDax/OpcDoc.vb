
Option Explicit On
Option Strict On
Imports System.Data
Imports DattCom

Imports System.Data.SqlClient

Public Class OpcDoc
    'variables locales para almacenar los valores de las propiedades

    Public Documento As String = "" 'Abreviacion del documento
    Public nombre As String = "" '
    Public TipoDoc As String = "" 'Tipo de documento - grupo al que pertenece
    Public Extenciones As String = "" 'copia local
    Public SNRepetir As Integer = 0 'copia local
    Public SNContabilizar As Integer = 0 'copia local
    Public SNCompDes As Integer = 0 'copia local
    Public SNLiquidacionGas As Integer = 0
    Public ImprimirForm As String = "" 'copia local 
    Public ImprimirDoc As String = "" 'copia local
    Public SNDefEst As Integer = 0 'copia local
    Public SNSinExist As Integer = 0 'copia local
    Public TipoCosteo As String = "" 'copia local
    Public ClasificadorCosto As String = "" 'copia local
    Public SNGuardarCosto As Integer = 0 'copia local
    Public ctadebe As String = "" 'copia local
    Public ctahaber As String = "" 'copia local
    Public CtaValVtaInvD As String = "" 'copia local
    Public CtaVtaOIvaD As String = "" 'copia local
    Public CtaValDescD As String = "" 'copia local
    Public CtaValNetoD As String = "" 'copia local
    Public CtaIvaD As String = "" 'copia local
    Public CtaOSinIvaD As String 'copia local
    Public CtaSubTConIvaD As String = "" 'copia local
    Public CtaTotDescInvD As String = "" 'copia local
    Public SNArtIndv As Integer = 0 'copia local
    Public SNDescIndv As Integer = 0 'copia local
    Public SNOtConIva As Integer = 0 'copia local
    Public SNOtSinIva As Integer = 0 'copia local
    Public ArtSevAcf As String = "" 'copia local
    Public Usuario As String = "" 'copia local
    Public PermiteCantidadCero As Integer = 0
    Public CtaVtaOIvaH As String = "" 'copia local
    Public CtaValNetoH As String = "" 'copia local
    Public CtaIvaH As String = "" 'copia local
    Public CtaOSinIvaH As String = "" 'copia local
    Public CtaSubTConIvaH As String = "" 'copia local
    Public CtaTotDescInvH As String = "" 'copia local
    Public CtaValDescH As String = "" 'copia local
    Public CtaValVtaInvH As String = "" 'copia local
    Public Recontabiliza As String = ""
    '    Public Rs As SqlClient.SqlDataReader 'copia local
    Public codsql As String = "" 'copia local
    Public ClaveDoc As String = "" 'copia local
    Public Impuestos As String = "" 'copia local
    Public Dedonde As String = ""
    Public VarCtaCostoH As String = ""
    Public VarCtaCostoD As String = ""
    Public VarCtaRetBieH As String = ""
    Public VarCtaRetBieD As String = ""
    Public VarCtaRetSerH As String = ""
    Public VarCtaRetSerD As String = ""
    Public VarCtaRetFteH As String = ""
    Public VarCtaRetFteD As String = ""
    Public VarCtaRetFte1H As String = ""
    Public VarCtaRetFte1D As String = ""
    Public VarCtaRetFte2H As String = ""
    Public VarCtaRetFte2D As String = ""
    Public FormatoCtb As String = ""
    Public FormatoElec As String = ""
    Public TipoSri As String = ""
    Public formulasPV As String = ""
    Public EsElectronico As Integer = 0
    Private _ImprimirRIDE As Boolean
    Private _ImprimirTicket As Boolean

    'Public NumDupConPropietario as Integer = 0
    'Public NumDupConBodega as Integer = 0
    'Public NumDupConIdSri as Integer = 0
    Public NroAutomatico As Integer = 0

    Public Impresora_1 As String = ""
    Public FormatoAux_1 As String = ""
    Public Impresora_2 As String = ""
    Public FormatoAux_2 As String = ""
    Public Impresora_3 As String = ""
    Public FormatoAux_3 As String = ""

    Public GeneraMateriaPrima As Integer = 0
    Public TipoSalidaMP As String = ""

    Public TipoSoporteObligatorio As String = ""
    Public TiposDocumentosConsolida As String = ""
    Public RegistraArtículos As Integer = 0
    Public RegistraServicios As Integer = 0
    Public RegistraActivos As Integer = 0
    Public DocumentoDebeAprobarse As Integer = 0
    Public Opc_TipoGas As Integer = 0
    Public Opc_Propietario As Integer = 0
    Public Opc_Bodega As Integer = 0
    Public Opc_IdSri As Integer = 0
    Public Opc_Autonumero As Integer = 0
    Public Opc_consolidar As Integer = 0
    Public DocumentoNoActivado As Integer = 0
    Public AutorizarPago As Integer = 0

    Public Opc_ctaCuadre As Integer = 0
    Public Opc_ctavalvtainvCuadre As Integer = 0
    Public Opc_ctavtaoivaCuadre As Integer = 0
    Public Opc_ctasubtcivaCuadre As Integer = 0
    Public Opc_ctavaldesCuadre As Integer = 0
    Public Opc_ctavalnetoCuadre As Integer = 0
    Public Opc_ctaivaCuadre As Integer = 0
    Public Opc_ctaotrosivaCuadre As Integer = 0
    Public Opc_ctatotdesindiCuadre As Integer = 0
    Public Opc_CtaCostoCuadre As Integer = 0
    Public Opc_CtaRetBieCuadre As Integer = 0
    Public Opc_CtaRetSerCuadre As Integer = 0
    Public Opc_CtaRetFteCuadre As Integer = 0
    Public Opc_CtaRetFte1Cuadre As Integer = 0
    Public Opc_CtaRetFte2Cuadre As Integer = 0

    Public Opc_LimiteCuadre As Double = 0.0
    Public noCtbLinea As String = ""

    Public DatosAuxiliares As String = ""
    Public DatosAuxiliaresDet As String = ""
    Public ComandoExterno As String = ""
    Public NoPVPbajoCosto As Integer = 0
    Public NumeraPorEmisor As Integer = 0

    Public ClaveEstado As Integer = 0
    Public ClaveOculto As Integer = 0
    Public ClaveContable As Integer = 0
    Public ClaveBanco As Integer = 0
    Public ClaveInventario As Integer = 0
    Public ClaveVentas As Integer = 0
    Public ClaveCompras As Integer = 0
    Public ClaveActivo As Integer = 0
    Public ClaveDocEmpresa As Integer = 0
    Public CodDuplica As String = ""
    Public DocumentoSinIva As Boolean = False
    Public LineasMaximas As Integer = 0
    Public tablaDatosDoc As String = ""
    Public tablaDatosTra As String = ""
    Public usoImportaciones As Integer = 0

    Private mvarNumIni As Double 'copia local
    Private mvarControlDuplica As String



    Public Property NumIni() As Double
        Get
            NumIni = mvarNumIni
        End Get
        Set(ByVal Value As Double)
            mvarNumIni = Value
        End Set
    End Property
    Public Property controlDuplica() As String
        Get
            Return mvarControlDuplica
        End Get
        Set(ByVal Value As String)
            mvarControlDuplica = Value
        End Set
    End Property

    Public Property ImprimirRIDE() As Boolean
        Get
            Return _ImprimirRIDE
        End Get
        Set(ByVal value As Boolean)
            _ImprimirRIDE = value
        End Set
    End Property

    Public Property ImprimirTicket() As Boolean
        Get
            Return _ImprimirTicket
        End Get
        Set(ByVal value As Boolean)
            _ImprimirTicket = value
        End Set
    End Property



    Public Function VerificarDocumento(ByRef Doc As String) As Boolean
        '        Dim conn As New SqlConnection(DattCom.datosEmpresa.strConxAdcom)
        '       conn.Open()
        '      Dim cmd As New SqlCommand("SELECT * FROM AdcOpc WHERE Opc_Documento='" & Doc & "' ", conn)
        '     Dim dat As SqlDataReader = cmd.ExecuteReader
        VerificarDocumento = SqlDatos.leerBaseAdcom("SELECT * FROM AdcOpc WHERE Opc_Documento='" & Doc & "' ").Read()
        'conn.Close()
        'conn.Dispose()
        'cmd.Dispose()
        'dat.Close()
        'dat = Nothing
    End Function
    Public Sub Cargar(Doc As String)
        Cargar(Doc, "")
    End Sub
    'AQUI ES EL PROBLEMA ANDRES
    Public Sub Cargar(ByRef Doc As String, Optional ByRef Lugar As String = "")
        Dim LibDat As New Daxlib
        If Doc = "" Then Exit Sub
        Try
            Dim dat As SqlDataReader = SqlDatos.leerBaseAdcom("SELECT * FROM AdcOpc WHERE Opc_Documento='" & Doc & "'")
            If Not dat.Read Then MsgBox("Tipo de documento '" & Doc & "' no encontrado", MsgBoxStyle.Information, "Definicion de documentos") : Exit Sub

            Documento = dat("Opc_documento").ToString
            nombre = dat("opc_nombre").ToString
            TipoDoc = dat("Opc_Tipo").ToString
            NumIni = CDbl(dat("Opc_numini"))
            Extenciones = dat("Opc_Extension").ToString
            SNCompDes = CInt(dat("Opc_SnCompDes"))
            SNRepetir = CInt(dat("Opc_SnRepetir"))
            SNContabilizar = CInt(dat("opc_contabiliza"))
            If Not IsDBNull(dat("Opc_GENERARDia")) Then Recontabiliza = dat("Opc_GENERARDia").ToString
            If Not IsDBNull(dat("Opc_ImpriDoc")) Then ImprimirDoc = dat("Opc_ImpriDoc").ToString
            If Not IsDBNull(dat("Opc_ImpriForm")) Then ImprimirForm = dat("Opc_ImpriForm").ToString
            If Not IsDBNull(dat("Opc_SnDefEstan")) Then SNDefEst = CInt(dat("Opc_SnDefEstan"))
            If Not IsDBNull(dat("Opc_SnSinExis")) Then SNSinExist = CInt(dat("Opc_SnSinExis"))
            If Not IsDBNull(dat("Opc_tipocos")) Then TipoCosteo = CStr(dat("Opc_tipocos"))
            If Not IsDBNull(dat("ClasificadorCosto")) Then ClasificadorCosto = dat("ClasificadorCosto").ToString
            SNGuardarCosto = CInt(dat("opc_snguarcos"))
            If Not IsDBNull(dat("Opc_ctadebe")) Then ctadebe = CStr(dat("opc_ctadebe"))
            If Not IsDBNull(dat("Opc_ctahaber")) Then ctahaber = CStr(dat("opc_ctahaber"))
            If Not IsDBNull(dat("Opc_ctavalvtainvd")) Then CtaValVtaInvD = CStr(dat("opc_ctavalvtainvd"))
            If Not IsDBNull(dat("Opc_ctavalvtainvh")) Then CtaValVtaInvH = CStr(dat("opc_ctavalvtainvh"))
            If Not IsDBNull(dat("Opc_ctavtaoivad")) Then CtaVtaOIvaD = CStr(dat("opc_ctavtaoivad"))
            If Not IsDBNull(dat("Opc_ctavtaoivah")) Then CtaVtaOIvaH = CStr(dat("opc_ctavtaoivah"))
            If Not IsDBNull(dat("Opc_ctasubtcivad")) Then CtaSubTConIvaD = CStr(dat("opc_ctasubtcivad"))
            If Not IsDBNull(dat("Opc_ctasubtcivah")) Then CtaSubTConIvaH = CStr(dat("opc_ctasubtcivah"))
            If Not IsDBNull(dat("Opc_ctavaldesd")) Then CtaValDescD = CStr(dat("opc_ctavaldesd"))
            If Not IsDBNull(dat("Opc_ctavaldesh")) Then CtaValDescH = dat("opc_ctavaldesh").ToString
            If Not IsDBNull(dat("Opc_ctavalnetod")) Then CtaValNetoD = dat("opc_ctavalnetod").ToString
            If Not IsDBNull(dat("Opc_ctavalnetoh")) Then CtaValNetoH = dat("opc_ctavalnetoh").ToString
            If Not IsDBNull(dat("Opc_ctaivad")) Then CtaIvaD = dat("opc_ctaivad").ToString
            If Not IsDBNull(dat("Opc_ctaivah")) Then CtaIvaH = dat("opc_ctaivah").ToString
            If Not IsDBNull(dat("Opc_ctaotrosivad")) Then CtaOSinIvaD = dat("opc_ctaotrosivad").ToString
            If Not IsDBNull(dat("Opc_ctaotrosivah")) Then CtaOSinIvaH = dat("opc_ctaotrosivah").ToString
            If Not IsDBNull(dat("Opc_ctatotdesindid")) Then CtaTotDescInvD = dat("opc_ctatotdesindid").ToString
            If Not IsDBNull(dat("Opc_ctatotdesindih")) Then CtaTotDescInvH = dat("opc_ctatotdesindih").ToString

            If Not IsDBNull(dat("Opc_ctaCostoH")) Then VarCtaCostoH = dat("opc_ctaCostoH").ToString
            If Not IsDBNull(dat("Opc_ctaCostoD")) Then VarCtaCostoD = dat("opc_ctaCostoD").ToString
            If Not IsDBNull(dat("Opc_ctaRetBieH")) Then VarCtaRetBieH = dat("opc_ctaRetBieH").ToString
            If Not IsDBNull(dat("Opc_ctaRetBieD")) Then VarCtaRetBieD = dat("opc_ctaRetBieD").ToString
            If Not IsDBNull(dat("Opc_ctaRetSerH")) Then VarCtaRetSerH = dat("opc_ctaRetSerH").ToString
            If Not IsDBNull(dat("Opc_ctaRetSerD")) Then VarCtaRetSerD = dat("opc_ctaRetSerD").ToString
            If Not IsDBNull(dat("Opc_ctaRetFteH")) Then VarCtaRetFteH = dat("opc_ctaRetFteH").ToString
            If Not IsDBNull(dat("Opc_ctaRetFteD")) Then VarCtaRetFteD = dat("opc_ctaRetFteD").ToString
            If Not IsDBNull(dat("Opc_ctaRetFte1H")) Then VarCtaRetFte1H = dat("opc_ctaRetFte1H").ToString
            If Not IsDBNull(dat("Opc_ctaRetFte1D")) Then VarCtaRetFte1D = dat("opc_ctaRetFte1D").ToString
            If Not IsDBNull(dat("Opc_ctaRetFte2H")) Then VarCtaRetFte2H = dat("opc_ctaRetFte2H").ToString
            If Not IsDBNull(dat("Opc_ctaRetFte2D")) Then VarCtaRetFte2D = dat("opc_ctaRetFte2D").ToString

            If Not IsDBNull(dat("Opc_snartind")) Then SNArtIndv = CInt(dat("opc_snartind"))
            If Not IsDBNull(dat("Opc_sndesind")) Then SNDescIndv = CInt(dat("opc_sndesind"))
            If Not IsDBNull(dat("Opc_snotrociva")) Then SNOtConIva = CInt(dat("opc_snotrociva"))
            If Not IsDBNull(dat("Opc_snotrosiva")) Then SNOtSinIva = CInt(dat("opc_snotrosiva"))
            If Not IsDBNull(dat("Opc_snartseracf")) Then ArtSevAcf = dat("opc_snartseracf").ToString
            If Not IsDBNull(dat("Opc_impuestos")) Then Impuestos = dat("opc_impuestos").ToString
            If Not IsDBNull(dat("Opc_usuario")) Then Usuario = dat("opc_usuario").ToString
            If Not IsDBNull(dat("Opc_ImpCtb")) Then FormatoCtb = dat("Opc_ImpCtb").ToString
            If Not IsDBNull(dat("FormatoElec")) Then FormatoElec = dat("FormatoElec").ToString
            If Not IsDBNull(dat("Opc_TipoGas")) Then SNLiquidacionGas = CInt(dat("Opc_TipoGas")) Else SNLiquidacionGas = CInt(False)
            If Not IsDBNull(dat("Opc_TipoSri")) Then TipoSri = Strings.Right("00" & dat("Opc_TipoSri").ToString, 2)
            If Not IsDBNull(dat("Opc_CantidadCero")) Then PermiteCantidadCero = CInt(dat("Opc_CantidadCero")) Else PermiteCantidadCero = CInt(False)

            If Not IsDBNull(dat("Auxil1")) Then noCtbLinea = CStr(dat("Auxil1"))
            If Not IsDBNull(dat("Auxil2")) Then formulasPV = dat("Auxil2").ToString
            If Not IsDBNull(dat("Auxil3")) Then usoImportaciones = CInt(Val(dat("Auxil3")))
            If Not IsDBNull(dat("EsElectronico")) Then EsElectronico = CInt(Val(dat("EsElectronico")))
            If Not IsDBNull(dat("ImprimirRIDE")) Then
                ImprimirRIDE = Convert.ToBoolean(dat("ImprimirRIDE"))
            End If

            If Not IsDBNull(dat("ImprimirTicket")) Then
                ImprimirTicket = Convert.ToBoolean(dat("ImprimirTicket"))
            End If


            Opc_Propietario = CInt(LibDat.CorrijeNuloN(dat("Opc_Propietario")))
            Opc_Bodega = CInt(LibDat.CorrijeNuloN(dat("Opc_Bodega")))
            Opc_IdSri = CInt(LibDat.CorrijeNuloN(dat("Opc_IdSri")))
            Opc_Autonumero = CInt(LibDat.CorrijeNuloN(dat("Opc_Autonumero")))

            Opc_TipoGas = CInt(LibDat.CorrijeNuloN(dat("Opc_TipoGas")))
            Opc_consolidar = CInt(LibDat.CorrijeNuloN(dat("Opc_consolidar")))
            DocumentoNoActivado = CInt(LibDat.CorrijeNuloN(dat("DocumentoNoActivado")))
            AutorizarPago = CInt(LibDat.CorrijeNuloN(dat("AutorizarPago")))

            FormatoAux_1 = CStr(LibDat.CorrijeNulo(dat("FormatoAux_1")))
            FormatoAux_2 = LibDat.CorrijeNulo(dat("FormatoAux_2")).ToString
            FormatoAux_3 = LibDat.CorrijeNulo(dat("FormatoAux_3")).ToString

            Impresora_1 = LibDat.CorrijeNulo(dat("ImpresoraAux_1")).ToString
            Impresora_2 = LibDat.CorrijeNulo(dat("ImpresoraAux_2")).ToString
            Impresora_3 = LibDat.CorrijeNulo(dat("ImpresoraAux_3")).ToString

            GeneraMateriaPrima = CInt(IIf(IsDBNull(dat("Opc_GeneraMP")), False, dat("Opc_GeneraMP")))
            TipoSalidaMP = CStr(LibDat.CorrijeNulo(dat("TipoSalidaMP")))

            If Not IsDBNull(dat("Opc_ctaCuadre")) Then Opc_ctaCuadre = CInt(dat("Opc_ctaCuadre"))
            If Not IsDBNull(dat("Opc_ctavalvtainvCuadre")) Then Opc_ctavalvtainvCuadre = CInt(dat("Opc_ctavalvtainvCuadre"))
            If Not IsDBNull(dat("Opc_ctavtaoivaCuadre")) Then Opc_ctavtaoivaCuadre = CInt(dat("Opc_ctavtaoivaCuadre"))
            If Not IsDBNull(dat("Opc_ctasubtcivaCuadre")) Then Opc_ctasubtcivaCuadre = CInt(dat("Opc_ctasubtcivaCuadre"))
            If Not IsDBNull(dat("Opc_ctavaldesCuadre")) Then Opc_ctavaldesCuadre = CInt(dat("Opc_ctavaldesCuadre"))
            If Not IsDBNull(dat("Opc_ctavalnetoCuadre")) Then Opc_ctavalnetoCuadre = CInt(dat("Opc_ctavalnetoCuadre"))
            If Not IsDBNull(dat("Opc_ctaivaCuadre")) Then Opc_ctaivaCuadre = CInt(dat("Opc_ctaivaCuadre"))
            If Not IsDBNull(dat("Opc_ctaotrosivaCuadre")) Then Opc_ctaotrosivaCuadre = CInt(dat("Opc_ctaotrosivaCuadre"))
            If Not IsDBNull(dat("Opc_ctatotdesindiCuadre")) Then Opc_ctatotdesindiCuadre = CInt(dat("Opc_ctatotdesindiCuadre"))
            If Not IsDBNull(dat("Opc_CtaCostoCuadre")) Then Opc_CtaCostoCuadre = CInt(dat("Opc_CtaCostoCuadre"))
            If Not IsDBNull(dat("Opc_CtaRetBieCuadre")) Then Opc_CtaRetBieCuadre = CInt(dat("Opc_CtaRetBieCuadre"))
            If Not IsDBNull(dat("Opc_CtaRetSerCuadre")) Then Opc_CtaRetSerCuadre = CInt(dat("Opc_CtaRetSerCuadre"))
            If Not IsDBNull(dat("Opc_CtaRetFteCuadre")) Then Opc_CtaRetFteCuadre = CInt(dat("Opc_CtaRetFteCuadre"))
            If Not IsDBNull(dat("Opc_CtaRetFte1Cuadre")) Then Opc_CtaRetFte1Cuadre = CInt(dat("Opc_CtaRetFte1Cuadre"))
            If Not IsDBNull(dat("Opc_CtaRetFte2Cuadre")) Then Opc_CtaRetFte2Cuadre = CInt(dat("Opc_CtaRetFte2Cuadre"))
            If Not IsDBNull(dat("Opc_LimiteCuadre")) Then Opc_LimiteCuadre = CDbl(dat("Opc_LimiteCuadre"))
            If Not IsDBNull(dat("DatosAuxiliares")) Then DatosAuxiliares = CStr(dat("DatosAuxiliares"))
            If Not IsDBNull(dat("DatosAuxiliaresDet")) Then DatosAuxiliaresDet = CStr(dat("DatosAuxiliaresDet"))
            If Not IsDBNull(dat("TipoSoporteObligatorio")) Then TipoSoporteObligatorio = CStr(dat("TipoSoporteObligatorio"))
            If Not IsDBNull(dat("NoPVPbajoCosto")) Then NoPVPbajoCosto = CInt(dat("NoPVPbajoCosto"))
            If Not IsDBNull(dat("NumeraPorEmisor")) Then NumeraPorEmisor = CInt(dat("NumeraPorEmisor"))

            ComandoExterno = CStr(LibDat.CorrijeNulo(dat("ComandoExterno")))

            CargarClaveDoc(TipoDoc)
            '        conn.Close()
            '       conn.Dispose()
        Catch exx As Exception
            MessageBox.Show("Excepcion en cargar propiedades Documento " + vbCr + exx.Message)
        End Try

        PropiedadesDocumento()
        Return
    End Sub
    Private Sub PropiedadesDocumento()

        ClaveEstado = ArmarExtencionDocumento(Extenciones, ClaveDoc, , 1)
        ClaveOculto = ArmarExtencionDocumento(Extenciones, ClaveDoc, , 2)
        ClaveContable = ArmarExtencionDocumento(Extenciones, ClaveDoc, , 3)
        ClaveBanco = ArmarExtencionDocumento(Extenciones, ClaveDoc, , 4)
        ClaveInventario = ArmarExtencionDocumento(Extenciones, ClaveDoc, , 5)
        ClaveVentas = ArmarExtencionDocumento(Extenciones, ClaveDoc, , 6)
        ClaveCompras = ArmarExtencionDocumento(Extenciones, ClaveDoc, , 7)
        ClaveActivo = ArmarExtencionDocumento(Extenciones, ClaveDoc, , 8)


        '.Doc_Estado = ArmarExtencionDocumento(Extencion, ClaveDoc, , 1)
        '.Doc_Oculto = ArmarExtencionDocumento(Extencion, ClaveDoc, , 2)
        '.Doc_Contabilidad = ArmarExtencionDocumento(Extencion, ClaveDoc, , 3)
        '.Doc_Banco = ArmarExtencionDocumento(Extencion, ClaveDoc, , 4)
        '.Doc_Inventario = ArmarExtencionDocumento(Extencion, ClaveDoc, , 5)
        'If CompraVenta = "C" Then
        '    SignoCom = ArmarExtencionDocumento(Extencion, ClaveDoc, , 7)
        '    SignoVen = 0
        '    Duplica = "NSS"
        'Else
        '    SignoCom = 0
        '    SignoVen = ArmarExtencionDocumento(Extencion, ClaveDoc, , 6)
        '    Duplica = ""
        'End If
        '.Doc_Ventas = SignoVen
        '.Doc_Compras = SignoCom



        ClaveDocEmpresa = 0
        Select Case TipoDoc
            Case "NCC", "NCP", "NDP", "NDC", "GAR"
                ClaveDocEmpresa = 1
        End Select

        'For I = 0 To 4
        '    ImpPorcentaje(I) = 0
        '    ImpSnIva(I) = ""
        '    ImpNombre(I) = ""
        'Next I
        ''If Val(Impuestos) > 0 Then MuestraImpuestos(ImpPorcentaje(), ImpSnIva(), ImpNombre(), OpOpc)
        'DocumentoSinIva = (ImpPorcentaje(0) = 0)
        CodDuplica = "N"
        If Opc_Bodega <> 0 Then CodDuplica = "S"
        If Opc_Propietario <> 0 Then CodDuplica = CodDuplica & ",S" Else CodDuplica = CodDuplica & ",N"
        If Opc_IdSri <> 0 Then CodDuplica = CodDuplica & ",S" Else CodDuplica = CodDuplica & ",N"

        LineasMaximas = MaximoDeLineasPorDocumento(ImprimirForm)
    End Sub

    Private Function MaximoDeLineasPorDocumento(ByVal FormaImpresionDocumento As String) As Integer
        Dim rs As New DataTable
        Dim SumLin As Int32 = 0
        Dim textval() As String
        Dim da As New SqlDataAdapter("select * from sysforms where l0='" & Trim(FormaImpresionDocumento) & "' order by S1 ", DattCom.datosEmpresa.strConxAdcom)
        da.Fill(rs)
        For Each row As DataRow In rs.Rows
            textval = Split(row("l1").ToString(), ";")
            If UBound(textval) < 13 Then ReDim Preserve textval(13)
            If Val(textval(13)) > SumLin Then SumLin = CInt(Val(textval(13)))
        Next
        If SumLin = 0 Then SumLin = 9999
        Return SumLin
    End Function

    'Private Function SignoInventarios(TipoDoc As String) As Long
    '    Dim OpAux As New Opcdoc
    '    Dim ExtencionAux As String
    '    Dim ClaveDocAux As String
    '    OpAux = New Opcdoc
    '    OpAux.Cargar(TipoDoc)
    '    ExtencionAux = OpAux.Extenciones
    '    ClaveDocAux = OpAux.ClaveDoc
    '    'TipoDocumento = OpAux.TipoDoc
    '    SignoInventarios = ArmarExtencionDocumento(ExtencionAux, ClaveDocAux, , 5)
    '    If SignoInventarios >= 2 Then SignoInventarios = -1
    '    OpAux = Nothing
    'End Function

    Public Function ArmarExtencionDocumento(Extencion As String, clave As String, Optional QueTipoEs As Boolean = False, Optional posicion As Integer = 0) As Integer


        Dim ArmarExtDoc As String, Extenciones As String, ClaveDoc As String

        'QueTipoEs =true Es unEgreso de Bodega o para Banco
        'QueTipoEs =false Es un ingreso a Bodega o para banco
        ArmarExtDoc = ""
        Extenciones = Extencion
        ClaveDoc = clave

        Select Case posicion

            Case 1
                ArmarExtDoc = "1"    ' Estado 1 = activo  2 =  anulado
            Case 2
                ArmarExtDoc = Extencion.Substring(6, 1)               ' Doc. Oculto  1 = No oculto 0= Oculto
            Case 3
                ArmarExtDoc = Extencion.Substring(3, 1)               ' Afecta a Ctb 0 = No 1= Si
            Case 4
                ArmarExtDoc = ClaveDoc.Substring(1, 1)                ' afecta  a Bancos 0=No , 1=si
            Case 5
                If Val(Extencion.Substring(4, 1)) = 0 Then
                    ArmarExtDoc = "0"
                Else
                    If (ClaveDoc.Substring(2, 1)).Trim() = "3" Then
                        If QueTipoEs = True Then
                            ArmarExtDoc = (ArmarExtDoc + "2").Trim()
                        Else
                            ArmarExtDoc = (ArmarExtDoc + "1").Trim()
                        End If
                    Else
                        ArmarExtDoc = ClaveDoc.Substring(2, 1)                ' Afecta a Inv  0 = No ,1= Si y suma en inventario , 2=resta en inventario ,3 = transferenciai
                    End If
                End If
            Case 6
                ArmarExtDoc = ClaveDoc.Substring(3, 1)      ' Ventas a 0 = No 1= Si  y suma , 2 = resta
            Case 7
                ArmarExtDoc = ClaveDoc.Substring(4, 1)                 ' Compras a 0 = No 1= Si
            Case 8
                ArmarExtDoc = Extencion.Substring(5, 1)                ' Afecta a Activo fijo  a 0 = No 1= Si
        End Select

        If ArmarExtDoc = "2" Then ArmarExtDoc = "-1"
        ArmarExtencionDocumento = Convert.ToInt32(Val(ArmarExtDoc))

    End Function
    Public Function ArmarExtencionDocTra(Extencion As String, clave As String, Optional QueTipoEs As Boolean = False, Optional posicion As Byte = 0) As Double
        Dim ArmarExtTra As String = ""
        Dim Extenciones As String, ClaveDoc As String
        'QueTipoEs =true Es unEgreso de Bodega o para Banco
        'QueTipoEs =false Es un ingreso a Bodega o para banco

        Extenciones = Extencion
        ClaveDoc = clave
        Select Case posicion
            Case 1
                ArmarExtTra = "1"                                   ' Estado 1 = activo  2= anulado
            Case 2
                ArmarExtTra = Mid$(Extencion, 7, 1)                 ' Doc. Oculto  0 = No oculto 1= Oculto
            Case 3
                If Trim$(Mid$(Extencion, 5, 1)) = "1" Then
                    If Trim$(Mid$(ClaveDoc, 3, 1)) = "3" Then
                        If QueTipoEs = True Then
                            ArmarExtTra = Trim$(ArmarExtTra & 2)
                        Else
                            ArmarExtTra = Trim$(ArmarExtTra & 1)
                        End If
                    Else
                        ArmarExtTra = Mid$(ClaveDoc, 3, 1)                ' Afecta a Inv  0 = No ,1= Si y suma en inventario , 2=resta en inventario ,3 = transferenciai
                    End If
                Else
                    ArmarExtTra = "0"
                End If
            Case 4
                ArmarExtTra = Mid$(ClaveDoc, 4, 1)                   ' Ventas a 0 = No 1= Si  y suma , 2 = resta
            Case 5
                ArmarExtTra = Mid$(ClaveDoc, 5, 1)                  ' Compras a 0 = No 1= Si y suma , 2= resta
            Case 6
                ArmarExtTra = Mid$(ClaveDoc, 6, 1)                  ' Afecta a Activo fijo  a 0 = No 1= Si

        End Select
        If ArmarExtTra = "2" Then ArmarExtTra = "-1"
        ArmarExtencionDocTra = Val(ArmarExtTra)

    End Function
    'Public Function ArmarSigno(TipoDoc As String, extension As String, Optional Pos As Integer) As String

    '        If (TipoDoc = "FAC" Or TipoDoc = "DEV") And Pos <> 0 Then
    '            Pos = 4
    '        ElseIf TipoDoc = "IBG" Or TipoDoc = "EBG" Or TipoDoc = "AJI" Or TipoDoc = "AJE" Or TipoDoc = "TRF" Then
    '            ArmarSigno = ((Right$(Left$(extension, 3), 1) - 1.5) * -2)
    '        End If
    '    End Function

    Public Sub CargarClaveDoc(ByRef DocTip As String)
        Dim cod As String = "SELECT * FROM syscod WHERE tiporeferencia = 'Documentos' and abreviación ='" & DocTip & "'"
        Dim conectarDaxsys As New SqlConnection(DattCom.datosEmpresa.strConxSyscod)
        conectarDaxsys.Open()
        Dim cmd As New SqlCommand(cod, conectarDaxsys)
        Dim dat As SqlDataReader = cmd.ExecuteReader
        If dat.Read Then
            If Not IsDBNull(dat("Caracteristica1")) Then ClaveDoc = CStr(dat("Caracteristica1"))
            tablaDatosDoc = "ADCDOC"
            tablaDatosTra = "ADCTRA"
            Dedonde = "D"
            If Not IsDBNull(dat("Caracteristica2")) Then
                If (dat("Caracteristica2").ToString() = "P") Then
                    tablaDatosDoc = "ADCDOCPRO"
                    tablaDatosTra = "ADCTRAPRO"
                    Dedonde = "P"
                End If
            End If
        End If

        conectarDaxsys.Close()
        conectarDaxsys.Dispose()
        dat.Close()
        cmd.Dispose()
    End Sub

    Public Function Eliminar(ByRef Doc As String) As Object
        codsql = "DELETE FROM AdcOpc WHERE opc_documento='" & Doc & "' "
        Dim conectar As New SqlConnection(DattCom.datosEmpresa.strConxAdcom)
        conectar.Open()
        Dim cmd As New SqlCommand(codsql, conectar)
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        codsql = "delete from Daxsys.dbo.sys_documentos where CodDocumento = '" & Doc & "' "
        cmd = New SqlCommand(codsql, conectar)
        cmd.ExecuteNonQuery()
        Eliminar = True
        conectar.Close()
        conectar.Dispose()
        cmd.Dispose()
    End Function

    Public Function Guardarr() As Integer
        Dim ssql As String = "insert into AdcOpc ( "
        ssql += "Opc_documento,"
        ssql += "opc_nombre,"
        ssql += "Opc_Tipo,"
        ssql += "Opc_numini,"
        ssql += "Opc_Extension,"
        ssql += "Opc_SnCompDes,"
        ssql += "Opc_TipoGas,"
        ssql += "Opc_CantidadCero,"
        ssql += "Opc_SnRepetir,"
        ssql += "opc_contabiliza,"
        ssql += "Opc_GENERARDia,"
        ssql += "Opc_ImpriDoc,"
        ssql += "Opc_ImpriForm,"
        ssql += "Opc_SnDefEstan,"
        ssql += "Opc_SnSinExis,"
        ssql += "Opc_tipocos,"
        ssql += "ClasificadorCosto,"
        ssql += "opc_snguarcos,"
        ssql += "opc_ctadebe,"
        ssql += "opc_ctahaber,"
        ssql += "opc_ctavalvtainvd,"
        ssql += "opc_ctavalvtainvh,"
        ssql += "opc_ctavtaoivad,"
        ssql += "opc_ctavtaoivah,"
        ssql += "opc_ctasubtcivad,"
        ssql += "opc_ctasubtcivah,"
        ssql += "opc_ctavaldesd,"
        ssql += "opc_ctavaldesh,"
        ssql += "opc_ctavalnetod,"
        ssql += "opc_ctavalnetoh,"
        ssql += "opc_ctaivad,"
        ssql += "opc_ctaivah,"
        ssql += "opc_ctaotrosivad,"
        ssql += "opc_ctaotrosivah,"
        ssql += "opc_ctatotdesindid,"
        ssql += "opc_ctatotdesindih,"
        ssql += "opc_ctaCostoH,"
        ssql += "opc_ctaCostoD,"
        ssql += "opc_ctaRetBieH,"
        ssql += "opc_ctaRetBieD,"
        ssql += "opc_ctaRetSerH,"
        ssql += "opc_ctaRetSerD,"
        ssql += "opc_ctaRetFteH,"
        ssql += "opc_ctaRetFteD,"
        ssql += "opc_ctaRetFte1H,"
        ssql += "opc_ctaRetFte1D,"
        ssql += "opc_ctaRetFte2H,"
        ssql += "opc_ctaRetFte2D,"
        ssql += "opc_snartind,"
        ssql += "opc_sndesind,"
        ssql += "opc_snotrociva,"
        ssql += "opc_snotrosiva,"
        ssql += "opc_snartseracf,"
        ssql += "opc_usuario,"
        ssql += "opc_impuestos,"
        ssql += "Opc_ImpCtb,"
        ssql += "Opc_TipoSri,"
        ssql += "ImpresoraAux_1,"
        ssql += "ImpresoraAux_2,"
        ssql += "ImpresoraAux_3,"
        ssql += "FormatoAux_1,"
        ssql += "FormatoAux_2,"
        ssql += "FormatoAux_3,"
        ssql += "opc_GeneraMP,"
        ssql += "TipoSalidaMP, "
        ssql += "Opc_Propietario,"
        ssql += "Opc_Bodega,"
        ssql += "Opc_IdSri,"
        ssql += "Opc_Autonumero,"
        ssql += "Opc_consolidar,"
        ssql += "DocumentoNoActivado,"
        ssql += "AutorizarPago,"
        ssql += "Opc_ctaCuadre,"
        ssql += "Opc_ctavalvtainvCuadre,"
        ssql += "Opc_ctavtaoivaCuadre,"
        ssql += "Opc_ctasubtcivaCuadre,"
        ssql += "Opc_ctavaldesCuadre,"
        ssql += "Opc_ctavalnetoCuadre,"
        ssql += "Opc_ctaivaCuadre,"
        ssql += "Opc_ctaotrosivaCuadre,"
        ssql += "Opc_ctatotdesindiCuadre,"
        ssql += "Opc_CtaCostoCuadre,"
        ssql += "Opc_CtaRetBieCuadre,"
        ssql += "Opc_CtaRetSerCuadre,"
        ssql += "Opc_CtaRetFteCuadre,"
        ssql += "Opc_CtaRetFte1Cuadre,"
        ssql += "Opc_CtaRetFte2Cuadre,"
        ssql += "Opc_LimiteCuadre,"
        ssql += "DatosAuxiliares,"
        ssql += "DatosAuxiliaresDet,"
        ssql += "TipoSoporteObligatorio"
        ssql += ",ComandoExterno"
        ssql += ",NoPVPbajoCosto"
        ssql += ",NumeraPorEmisor"
        ssql += ",Auxil1"
        ssql += ",Auxil2"
        ssql += ",EsElectronico"
        ssql += ",FormatoElec"
        ssql += ",Auxil3"
        ssql += ", ImprimirRIDE"
        ssql += ", ImprimirTicket"
        ssql += ")"

        ssql += "values ( "
        ssql += "'" & Trim(Documento) & "',"
        ssql += "'" & Trim(nombre) & "',"
        ssql += "'" & Trim(TipoDoc) & "',"
        ssql += "" & NumIni & ","
        ssql += "'" & Extenciones & "',"
        ssql += "" & SNCompDes & ","
        ssql += "" & SNLiquidacionGas & ","
        ssql += "" & PermiteCantidadCero & ","
        ssql += "" & SNRepetir & ","
        ssql += "'" & SNContabilizar & "',"
        ssql += "'" & Recontabiliza & "',"
        ssql += "'" & Trim(ImprimirDoc) & "',"
        ssql += "'" & Trim(ImprimirForm) & "',"
        ssql += "" & SNDefEst & ","
        ssql += "" & SNSinExist & ","
        ssql += "'" & Trim(TipoCosteo) & "',"
        ssql += "'" & ClasificadorCosto & "',"
        ssql += "" & SNGuardarCosto & ","
        ssql += "'" & Trim(ctadebe) & "',"
        ssql += "'" & Trim(ctahaber) & "',"
        ssql += "'" & Trim(CtaValVtaInvD) & "',"
        ssql += "'" & Trim(CtaValVtaInvH) & "',"
        ssql += "'" & Trim(CtaVtaOIvaD) & "',"
        ssql += "'" & Trim(CtaVtaOIvaH) & "',"
        ssql += "'" & Trim(CtaSubTConIvaD) & "',"
        ssql += "'" & Trim(CtaSubTConIvaH) & "',"
        ssql += "'" & Trim(CtaValDescD) & "',"
        ssql += "'" & Trim(CtaValDescH) & "',"
        ssql += "'" & Trim(CtaValNetoD) & "',"
        ssql += "'" & Trim(CtaValNetoH) & "',"
        ssql += "'" & Trim(CtaIvaD) & "',"
        ssql += "'" & Trim(CtaIvaH) & "',"
        ssql += "'" & Trim(CStr(CtaOSinIvaD)) & "',"
        ssql += "'" & Trim(CtaOSinIvaH) & "',"
        ssql += "'" & Trim(CtaTotDescInvD) & "',"
        ssql += "'" & Trim(CtaTotDescInvH) & "',"
        ssql += "'" & Trim(VarCtaCostoH) & "',"
        ssql += "'" & Trim(VarCtaCostoD) & "',"
        ssql += "'" & Trim(VarCtaRetBieH) & "',"
        ssql += "'" & Trim(VarCtaRetBieD) & "',"
        ssql += "'" & Trim(VarCtaRetSerH) & "',"
        ssql += "'" & Trim(VarCtaRetSerD) & "',"
        ssql += "'" & Trim(VarCtaRetFteH) & "',"
        ssql += "'" & Trim(VarCtaRetFteD) & "',"
        ssql += "'" & Trim(VarCtaRetFte1H) & "',"
        ssql += "'" & Trim(VarCtaRetFte1D) & "',"
        ssql += "'" & Trim(VarCtaRetFte2H) & "',"
        ssql += "'" & Trim(VarCtaRetFte2D) & "',"
        ssql += "" & SNArtIndv & ","
        ssql += "" & SNDescIndv & ","
        ssql += "" & SNOtConIva & ","
        ssql += "" & SNOtSinIva & ","
        ssql += "'" & Trim(ArtSevAcf) & "',"
        ssql += "'" & Trim(Usuario) & "',"
        ssql += "'" & Trim(Impuestos) & "',"
        ssql += "'" & Trim(FormatoCtb) & "',"
        ssql += "'" & Trim(TipoSri) & "',"
        ssql += "'" & Impresora_1 & "',"
        ssql += "'" & Impresora_2 & "',"
        ssql += "'" & Impresora_3 & "',"
        ssql += "'" & FormatoAux_1 & "',"
        ssql += "'" & FormatoAux_2 & "',"
        ssql += "'" & FormatoAux_3 & "',"
        ssql += "" & GeneraMateriaPrima & ","
        ssql += "'" & TipoSalidaMP & "',"
        ssql += "" & Opc_Propietario & ","
        ssql += "" & Opc_Bodega & ","
        ssql += "" & Opc_IdSri & ","
        ssql += "" & Opc_Autonumero & ","
        ssql += "" & Opc_consolidar & ","
        ssql += "" & DocumentoNoActivado & ","
        ssql += "" & AutorizarPago & ","
        ssql += "" & Opc_ctaCuadre & ","
        ssql += "" & Opc_ctavalvtainvCuadre & ","
        ssql += "" & Opc_ctavtaoivaCuadre & ","
        ssql += "" & Opc_ctasubtcivaCuadre & ","
        ssql += "" & Opc_ctavaldesCuadre & ","
        ssql += "" & Opc_ctavalnetoCuadre & ","
        ssql += "" & Opc_ctaivaCuadre & ","
        ssql += "" & Opc_ctaotrosivaCuadre & ","
        ssql += "" & Opc_ctatotdesindiCuadre & ","
        ssql += "" & Opc_CtaCostoCuadre & ","
        ssql += "" & Opc_CtaRetBieCuadre & ","
        ssql += "" & Opc_CtaRetSerCuadre & ","
        ssql += "" & Opc_CtaRetFteCuadre & ","
        ssql += "" & Opc_CtaRetFte1Cuadre & ","
        ssql += "" & Opc_CtaRetFte2Cuadre & ","
        ssql += "" & Opc_LimiteCuadre & ","
        ssql += "'" & DatosAuxiliares & "',"
        ssql += "'" & DatosAuxiliaresDet & "',"
        ssql += "'" & TipoSoporteObligatorio & "',"
        ssql += "'" & ComandoExterno & "',"
        ssql += "" & NoPVPbajoCosto & ""
        ssql += "," & NumeraPorEmisor & ""
        ssql += ",'" & noCtbLinea & "'"
        ssql += ",'" & formulasPV & "'"
        ssql += ",'" & EsElectronico.ToString & "'"
        ssql += ",'" & FormatoElec.ToString & "'"
        ssql += "," & usoImportaciones & ""
        ssql += "," & If(ImprimirRIDE, 1, 0)
        ssql += "," & If(ImprimirTicket, 1, 0)
        ssql += ")"
        EjecutaComand(ssql, DattCom.datosEmpresa.strConxAdcom)
    End Function
    Private Sub EjecutaComand(ByVal comando As String, ByVal strConx As String)
        Dim conectar As New SqlConnection(strConx)
        conectar.Open()
        Dim cmd As New SqlCommand(comando, conectar)
        Try
            cmd.ExecuteNonQuery()
        Catch ee As Exception
            MsgBox("Excepción guardando: " & ee.Message)
        End Try
    End Sub
    Public Sub Actualizar(ByVal cod As String)
        Dim ssql As String = "update AdcOpc set "
        ssql += "opc_nombre='" & Trim(nombre) & "',"
        ssql += "Opc_Tipo='" & Trim(TipoDoc) & "',"
        ssql += "Opc_numini=" & NumIni & ","
        ssql += "Opc_Extension='" & Extenciones & "',"
        ssql += "Opc_SnCompDes=" & SNCompDes & ","
        ssql += "Opc_TipoGas=" & SNLiquidacionGas & ","
        ssql += "Opc_CantidadCero=" & PermiteCantidadCero & ","
        ssql += "Opc_SnRepetir=" & SNRepetir & ","
        ssql += "opc_contabiliza='" & SNContabilizar & "',"
        ssql += "Opc_GENERARDia='" & Recontabiliza & "',"
        ssql += "Opc_ImpriDoc='" & Trim(ImprimirDoc) & "',"
        ssql += "Opc_ImpriForm='" & Trim(ImprimirForm) & "',"
        ssql += "Opc_SnDefEstan=" & SNDefEst & ","
        ssql += "Opc_SnSinExis=" & SNSinExist & ","
        ssql += "Opc_tipocos='" & Trim(TipoCosteo) & "',"
        ssql += "ClasificadorCosto='" & Trim(ClasificadorCosto) & "',"
        ssql += "opc_snguarcos=" & SNGuardarCosto & ","
        ssql += "opc_ctadebe='" & Trim(ctadebe) & "',"
        ssql += "opc_ctahaber='" & Trim(ctahaber) & "',"
        ssql += "opc_ctavalvtainvd='" & Trim(CtaValVtaInvD) & "',"
        ssql += "opc_ctavalvtainvh='" & Trim(CtaValVtaInvH) & "',"
        ssql += "opc_ctavtaoivad='" & Trim(CtaVtaOIvaD) & "',"
        ssql += "opc_ctavtaoivah='" & Trim(CtaVtaOIvaH) & "',"
        ssql += "opc_ctasubtcivad='" & Trim(CtaSubTConIvaD) & "',"
        ssql += "opc_ctasubtcivah='" & Trim(CtaSubTConIvaH) & "',"
        ssql += "opc_ctavaldesd='" & Trim(CtaValDescD) & "',"
        ssql += "opc_ctavaldesh='" & Trim(CtaValDescH) & "',"
        ssql += "opc_ctavalnetod='" & Trim(CtaValNetoD) & "',"
        ssql += "opc_ctavalnetoh='" & Trim(CtaValNetoH) & "',"
        ssql += "opc_ctaivad='" & Trim(CtaIvaD) & "',"
        ssql += "opc_ctaivah='" & Trim(CtaIvaH) & "',"
        ssql += "opc_ctaotrosivad='" & Trim(CStr(CtaOSinIvaD)) & "',"
        ssql += "opc_ctaotrosivah='" & Trim(CtaOSinIvaH) & "',"
        ssql += "opc_ctatotdesindid='" & Trim(CtaTotDescInvD) & "',"
        ssql += "opc_ctatotdesindih='" & Trim(CtaTotDescInvH) & "',"
        ssql += "opc_ctaCostoH='" & Trim(VarCtaCostoH) & "',"
        ssql += "opc_ctaCostoD='" & Trim(VarCtaCostoD) & "',"
        ssql += "opc_ctaRetBieH='" & Trim(VarCtaRetBieH) & "',"
        ssql += "opc_ctaRetBieD='" & Trim(VarCtaRetBieD) & "',"
        ssql += "opc_ctaRetSerH='" & Trim(VarCtaRetSerH) & "',"
        ssql += "opc_ctaRetSerD='" & Trim(VarCtaRetSerD) & "',"
        ssql += "opc_ctaRetFteH='" & Trim(VarCtaRetFteH) & "',"
        ssql += "opc_ctaRetFteD='" & Trim(VarCtaRetFteD) & "',"
        ssql += "opc_ctaRetFte1H='" & Trim(VarCtaRetFte1H) & "',"
        ssql += "opc_ctaRetFte1D='" & Trim(VarCtaRetFte1D) & "',"
        ssql += "opc_ctaRetFte2H='" & Trim(VarCtaRetFte2H) & "',"
        ssql += "opc_ctaRetFte2D='" & Trim(VarCtaRetFte2D) & "',"
        ssql += "opc_snartind=" & SNArtIndv & ","
        ssql += "opc_sndesind=" & SNDescIndv & ","
        ssql += "opc_snotrociva=" & SNOtConIva & ","
        ssql += "opc_snotrosiva=" & SNOtSinIva & ","
        ssql += "opc_snartseracf='" & Trim(ArtSevAcf) & "',"
        ssql += "opc_usuario='" & Trim(Usuario) & "',"
        ssql += "opc_impuestos='" & Trim(Impuestos) & "',"
        ssql += "Opc_ImpCtb='" & Trim(FormatoCtb) & "',"

        Try
            ssql += "Opc_TipoSri='" & TipoSri.ToString & "',"
        Catch
            ssql += "Opc_TipoSri='',"
        End Try

        ssql += "ImpresoraAux_1='" & Impresora_1 & "',"
        ssql += "ImpresoraAux_2='" & Impresora_2 & "',"
        ssql += "ImpresoraAux_3='" & Impresora_3 & "',"
        ssql += "FormatoAux_1='" & FormatoAux_1 & "',"
        ssql += "FormatoAux_2='" & FormatoAux_2 & "',"
        ssql += "FormatoAux_3='" & FormatoAux_3 & "',"
        ssql += "opc_GeneraMP=" & GeneraMateriaPrima & ","
        ssql += "TipoSalidaMP='" & TipoSalidaMP & "',"
        ssql += "Opc_Propietario=" & Opc_Propietario & ","
        ssql += "Opc_Bodega=" & Opc_Bodega & ","
        ssql += "Opc_IdSri=" & Opc_IdSri & ","
        ssql += "Opc_Autonumero=" & Opc_Autonumero & ","
        ssql += "Opc_consolidar=" & Opc_consolidar & ","
        ssql += "DocumentoNoActivado=" & DocumentoNoActivado & ","
        ssql += "AutorizarPago=" & AutorizarPago & ","
        ssql += "Opc_ctaCuadre=" & Opc_ctaCuadre & ","
        ssql += "Opc_ctavalvtainvCuadre=" & Opc_ctavalvtainvCuadre & ","
        ssql += " Opc_ctavtaoivaCuadre=" & Opc_ctavtaoivaCuadre & ","
        ssql += " Opc_ctasubtcivaCuadre=" & Opc_ctasubtcivaCuadre & ","
        ssql += " Opc_ctavaldesCuadre=" & Opc_ctavaldesCuadre & ","
        ssql += " Opc_ctavalnetoCuadre=" & Opc_ctavalnetoCuadre & ","
        ssql += " Opc_ctaivaCuadre=" & Opc_ctaivaCuadre & ","
        ssql += " Opc_ctaotrosivaCuadre=" & Opc_ctaotrosivaCuadre & ","
        ssql += " Opc_ctatotdesindiCuadre=" & Opc_ctatotdesindiCuadre & ","
        ssql += " Opc_CtaCostoCuadre=" & Opc_CtaCostoCuadre & ","
        ssql += " Opc_CtaRetBieCuadre=" & Opc_CtaRetBieCuadre & ","
        ssql += " Opc_CtaRetSerCuadre=" & Opc_CtaRetSerCuadre & ","
        ssql += " Opc_CtaRetFteCuadre=" & Opc_CtaRetFteCuadre & ","
        ssql += " Opc_CtaRetFte1Cuadre=" & Opc_CtaRetFte1Cuadre & ","
        ssql += " Opc_CtaRetFte2Cuadre=" & Opc_CtaRetFte2Cuadre & ","
        ssql += " Opc_LimiteCuadre=" & Opc_LimiteCuadre & ","
        ssql += " DatosAuxiliares='" & DatosAuxiliares & "', "
        ssql += " DatosAuxiliaresDet='" & DatosAuxiliaresDet & "', "
        ssql += " TipoSoporteObligatorio='" & TipoSoporteObligatorio & "' "
        ssql += ", ComandoExterno='" & ComandoExterno & "' "
        ssql += ", NoPVPbajoCosto=" & NoPVPbajoCosto & " "
        ssql += ", NumeraPorEmisor=" & NumeraPorEmisor & " "
        ssql += ", Auxil1='" & noCtbLinea & "' "
        ssql += ", Auxil2='" & formulasPV.ToString() & "' "
        ssql += ", EsElectronico=" & EsElectronico.ToString()
        ssql += ", FormatoElec='" & FormatoElec & "'"
        ssql += ", Auxil3='" & usoImportaciones.ToString() & "'"
        ssql += ", ImprimirRIDE=" & If(ImprimirRIDE, 1, 0)
        ssql += ", ImprimirTicket=" & If(ImprimirTicket, 1, 0)
        If cod <> "" Then ssql += "where Opc_documento='" & Documento & "'"
        EjecutaComand(ssql, DattCom.datosEmpresa.strConxAdcom)
    End Sub

    Public Function ArmarExtencionDocumento(ByRef Extencion As String, ByRef Clave As String, Optional ByRef QueTipoEs As Integer = CInt(False), Optional ByRef Posicion As Byte = 0) As Double
        Dim Extenciones, ArmarExtDoc, ClaveDoc As String

        'QueTipoEs =true Es unEgreso de Bodega o para Banco
        'QueTipoEs =false Es un ingreso a Bodega o para banco

        ArmarExtDoc = ""
        Extenciones = Extencion
        ClaveDoc = Clave

        Select Case Posicion

            Case 1
                ArmarExtDoc = CStr(1) ' Estado 1 = activo  2 =  anulado
            Case 2
                ArmarExtDoc = Mid(Extencion, 7, 1) ' Doc. Oculto  1 = No oculto 0= Oculto
            Case 3
                ArmarExtDoc = Mid(Extencion, 4, 1) ' Afecta a Ctb 0 = No 1= Si
            Case 4
                ArmarExtDoc = Mid(ClaveDoc, 2, 1) ' afecta  a Bancos 0=No , 1=si
            Case 5
                If CDbl(Mid(Extencion, 5, 1)) = 0 Then
                    ArmarExtDoc = CStr(0)
                Else
                    If Trim(Mid(ClaveDoc, 3, 1)) = "3" Then
                        If QueTipoEs = CInt(True) Then
                            ArmarExtDoc = Trim(ArmarExtDoc & 2)
                        Else
                            ArmarExtDoc = Trim(ArmarExtDoc & 1)
                        End If
                    Else
                        ArmarExtDoc = Mid(ClaveDoc, 3, 1) ' Afecta a Inv  0 = No ,1= Si y suma en inventario , 2=resta en inventario ,3 = transferenciai
                    End If
                End If

            Case 6
                ArmarExtDoc = Mid(ClaveDoc, 4, 1) ' Ventas a 0 = No 1= Si  y suma , 2 = resta
            Case 7
                ArmarExtDoc = Mid(ClaveDoc, 5, 1) ' Compras a 0 = No 1= Si
            Case 8
                ArmarExtDoc = Mid(Extencion, 6, 1) ' Afecta a Activo fijo  a 0 = No 1= Si
        End Select

        If ArmarExtDoc = "2" Then ArmarExtDoc = CStr(-1)
        ArmarExtencionDocumento = CDbl(Val(ArmarExtDoc))


    End Function

    Public Sub New()

    End Sub
    Public Function idTributario(SucActual As String, codigo As Int16) As String
        Dim ssql As String = "select case when isnull(pto_idtributario,'')='' then isnull(suc_idtributario,'') else pto_idtributario end as Idtributario from ("
        ssql += "select suc_idtributario,Emp_Suc.Suc_Codigo,emp_suc.Emp_Codigo  from Emp_Suc "
        ssql += " where Emp_Suc.Suc_Codigo = '" + SucActual + "' And Emp_Suc.Emp_Codigo = '" + codigo.ToString() + "'"
        ssql += " ) r1 "
        ssql += " left join ("
        ssql += " select pto_IdTributario,Pto_codigo,Suc_Codigo,Emp_Codigo  from Emp_PtoVta "
        ssql += " where Suc_Codigo = '" + SucActual + "' And  Emp_Codigo = '" + codigo.ToString() + "'"
        ssql += " and (pto_codigo = '" + Environment.MachineName + "' or pto_nombre = '" + Environment.MachineName + "') "
        ssql += " ) r2 "
        ssql += " on r1.Suc_Codigo = r2.Suc_Codigo "

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter(ssql, DattCom.datosEmpresa.strConxSyscod)
        da.Fill(dt)
        ssql = ""
        If dt.Rows.Count > 0 Then
            ssql = dt.Rows(0)("idTributario").ToString()
        End If
        Return ssql
    End Function

    Public Function ObtenerTipoImpresion() As String
        ' 1. Si está marcado RIDE
        If ImprimirRIDE Then
            Return "RIDE"
        End If

        ' 2. Si está marcado Ticket
        If ImprimirTicket Then
            Return "TICKET"
        End If

        ' 3. Si tiene impresión general (Opc_Impridoc = "G")
        If Not String.IsNullOrEmpty(ImprimirDoc) AndAlso ImprimirDoc = "G" Then
            Return "SISTEMA"
        End If

        ' 4. Si tiene impresión "No imprimir" (Opc_Impridoc = "N")
        If Not String.IsNullOrEmpty(ImprimirDoc) AndAlso ImprimirDoc = "N" Then
            Return "NINGUNO"
        End If

        ' 5. Por defecto, no imprimir
        Return "NINGUNO"
    End Function
End Class
