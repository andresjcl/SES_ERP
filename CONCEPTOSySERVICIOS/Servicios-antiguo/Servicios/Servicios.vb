Imports System.Data.SqlClient
Imports System.Data
Public Class Servicios
    Dim strConxAdcom As String
    Dim strConxSysemp As String
    Dim CONUSR As New DaxUsr.DaxsofUsr
    Dim ControlUsuario As DaxUsr.CtrlUsuario
    Dim CONEMP As New AdcDax.DaxSofSys
    Dim RsSer As New DataTable

    Public codigo As String  'copia local
    Public Nombre As String  'copia local
    Public Unimed As String  'copia local
    Public Precvta As Double  'copia local
    Public PrecioIncluyeIva As Boolean
    Public Descuen As Double  'copia local
    Public FecIniDes As Date  'copia local
    Public FecFinDes As Date  'copia local
    Public SNIva As Boolean  'copia local
    Public Usuario As String  'copia local
    Public IdContable As String
    Public IdContable2 As String
    Public IdContable3 As String
    Public IdContable4 As String
    Public SnPropina As Boolean
    Public AfectaCosto As String
    Public SriBien As Integer
    Public SriTipoIvaRet As String
    Public TipoServicio As String
    Public ServicioHotelero As Boolean
    Public conceptocompras As Boolean
    Public conceptoventas As Boolean
    Public conceptoingresobancos As Boolean
    Public conceptoegresobancos As Boolean
    Public EsCtaContable As Boolean
    Public CtasCorrientes As Boolean
    Public CruceClientes As Boolean
    Public CruceProveedores As Boolean
    Dim progg As New daaxLib.DaxLibDigDato

    Public Function Cargar(cod As String) As Boolean
        Dim codsql As String
        On Error GoTo errores
        RsSer = New DataTable
        codsql = "SELECT * FROM Adcserv WHERE sev_codigo='" & cod & "'"
        Dim da As New SqlDataAdapter(codsql, strConxAdcom)
        da.Fill(RsSer)
        With RsSer
            If .Rows.Count = 0 Then Cargar = False : .Dispose() : Exit Function
            codigo = .Rows(0)("sev_codigo").ToString
            Nombre = progg.CorrijeNulo(.Rows(0)("sev_nombre").ToString)
            Unimed = progg.CorrijeNulo(.Rows(0)("sev_unimed").ToString)
            Precvta = progg.CorrijeNuloN(.Rows(0)("Sev_precvta").ToString)
            PrecioIncluyeIva = CBool(.Rows(0)("Sev_IncIva").ToString)
            Descuen = progg.CorrijeNuloN(.Rows(0)("Sev_descuen").ToString)
            FecIniDes = progg.CorrijeNuloF(.Rows(0)("Sev_fecinides").ToString)
            FecFinDes = progg.CorrijeNuloF(.Rows(0)("Sev_fecfindes").ToString)             
            SNIva = Convert.ToBoolean(.Rows(0)("sev_sniva"))
            Usuario = progg.CorrijeNulo(.Rows(0)("Sev_usuario").ToString)
            IdContable = progg.CorrijeNulo(.Rows(0)("seV_idcta").ToString)
            IdContable2 = progg.CorrijeNulo(.Rows(0)("seV_idcta2").ToString)
            IdContable3 = progg.CorrijeNulo(.Rows(0)("seV_idcta3").ToString)
            IdContable4 = progg.CorrijeNulo(.Rows(0)("seV_idcta4").ToString)
            SnPropina = Convert.ToBoolean(.Rows(0)("Sev_SnPropina"))
            AfectaCosto = progg.CorrijeNulo(.Rows(0)("Sev_TipoCos").ToString)
            SriBien = CInt(progg.CorrijeNuloN(.Rows(0)("Sev_SriBien").ToString))
            SriTipoIvaRet = progg.CorrijeNulo(.Rows(0)("Sev_TipoSerSri").ToString)
            TipoServicio = progg.CorrijeNulo(.Rows(0)("Sev_Grupo").ToString)
            ServicioHotelero = CBool(.Rows(0)("Sev_Hotel"))
            conceptocompras = CBool(.Rows(0)("Sev_compras"))
            conceptoventas = CBool(.Rows(0)("Sev_ventas"))
            conceptoingresobancos = CBool(.Rows(0)("Sev_ingbanco"))
            conceptoegresobancos = CBool(.Rows(0)("Sev_egrbanco"))
            EsCtaContable = CBool(.Rows(0)("sev_escontable"))
            CruceClientes = CBool(.Rows(0)("sev_CruceClientes"))
            CruceProveedores = CBool(.Rows(0)("sev_CruceProveedores"))
            Cargar = True
        End With
        Exit Function
errores:
        MsgBox(Err.Description)
        Resume Next
    End Function


    Public Function ServUsado(cod As String) As Boolean
        Dim rstemp As New ADODB.Recordset
        Dim sSQL As String
        If ConxAdcom.State = 0 Then Conectar()
        sSQL = "SELECT top(1) tra_codigo FROM AdcTra WHERE Tra_Codigo='" & cod & "' and tra_quetipo = 'S' "
        rstemp.Open(sSQL, ConxAdcom, adOpenKeyset, adLockOptimistic)
        If rstemp.EOF = False Then
            ServUsado = True
        Else
            If rstemp.State = 1 Then rstemp.Close()
            sSQL = "SELECT TOP(1) * FROM ADCAPL WHERE CODCONCEPTO = '" & cod & "'"
            rstemp.Open(sSQL, ConxAdcom, adOpenKeyset, adLockOptimistic)
            If rstemp.EOF = False Then
                ServUsado = True
            Else
                ServUsado = False
            End If
        End If
        rstemp.Close()
    End Function

    Public Function Clasificadores(Tipodoc As String) As String
        Dim lacuenta As String
        Clasificadores = ClasificadorYcuenta(Tipodoc, lacuenta)
    End Function

    Public Function ClasificadorYcuenta(ByVal Tipodoc As String, ByRef CtaCont As String) As String
        Dim opopc As New PrySysp13.OpcDoc
        Dim cuentaa As String
        Dim CuentaDocDeb As String
        Dim CuentaDocHab As String
        Dim esBanco As Boolean
        Dim RS As New ADODB.Recordset

        ' CtaValVtaInvH, CtaValVtaInvD
        ' CtaVtaOIvaH CtaVtaOIvaD
        '
        ClasificadorYcuenta = ""
        cuentaa = ""
        CtaCont = ""
        esBanco = False
        If EsCtaContable Then
            cuentaa = codigo
        ElseIf Tipodoc = "" Then
            Exit Function
        Else
            opopc.Cargar(Tipodoc)
            If opopc.Nombre = "" Then Exit Function
            Select Case opopc.Tipodoc
                Case "EGR", "ING", "NCB", "NDB"
                    esBanco = True
            End Select
            CuentaDocDeb = IIf(esBanco, opopc.VarCtaRetBieD, opopc.CtaSubTConIvaD)
            If CuentaDocDeb > "" Then
                If Mid$(CuentaDocDeb, 1, 1) = "&" Then
                    CuentaDocDeb = Mid$(CuentaDocDeb, 2)
                    Select Case CuentaDocDeb
                        Case "SERV-OTROS"
                            cuentaa = IdContable
                        Case "SERV-OTRO2"
                            cuentaa = IdContable2
                        Case "SERV-OTRO3"
                            cuentaa = IdContable3
                        Case "SERV-OTRO4"
                            cuentaa = IdContable4
                    End Select
                Else
                    cuentaa = CuentaDocDeb
                End If
            End If
            CuentaDocHab = IIf(esBanco, opopc.VarCtaRetBieH, opopc.CtaSubTConIvaH)
            If CuentaDocHab > "" And cuentaa = "" Then
                If Mid$(CuentaDocHab, 1, 1) = "&" Then
                    CuentaDocHab = Mid$(CuentaDocHab, 2)
                    Select Case CuentaDocHab
                        Case "SERV-OTROS"
                            cuentaa = IdContable
                        Case "SERV-OTRO2"
                            cuentaa = IdContable2
                        Case "SERV-OTRO3"
                            cuentaa = IdContable3
                        Case "SERV-OTRO4"
                            cuentaa = IdContable4
                    End Select
                Else
                    cuentaa = CuentaDocHab
                End If
            End If
        End If
        If cuentaa > "" Then
            CtaCont = cuentaa
            If ConxAdcom.State = 0 Then Conectar()
            RS.Open("SELECT CLASIFICADORES FROM ADCCTA WHERE CTA_CODIGO = '" & cuentaa & "' ", ConxAdcom, adOpenForwardOnly, adLockReadOnly)
            If RS.State = 1 Then
                If RS.EOF = False Then
                    If Not IsNull(RS!Clasificadores) Then ClasificadorYcuenta = RS!Clasificadores
                End If
                RS.Close()
            End If
        End If
        opopc = Nothing
        RS = Nothing
    End Function

    Private Sub Conectar()
        If Emp Is Nothing Then
            CONEMP = DaxSofSys
            Emp = CONEMP.EmpresaAct
            CONUSR = New DaxsofUsr
            ControlUsuario = CONUSR.UsuarioAct
        End If
        Dim prog As New DaxLib.DaxLibBases
        If ConxAdcom.State = 1 Then ConxAdcom.Close()
        ConxAdcom.ConnectionString = prog.StrAdcom
        ConxAdcom.Open()
        prog = Nothing
    End Sub

    Private Sub Class_Terminate()
        If ConxAdcom.State = 1 Then ConxAdcom.Close()
        Emp = Nothing
        CONEMP = Nothing
        ControlUsuario = Nothing
        CONUSR = Nothing
    End Sub

End Class
