Option Strict On
Option Explicit On

Imports System.Data
Imports System.Data.SqlClient
Imports DattCom


Public Class Cuenta
    '*******************
    Public codigo As String 'copia local
    Public Nombre As String 'copia local
    Public Grupo As String 'copia local
    Public Agrupacion As Boolean 'copia local
    Public Nivel As Short
    Public TipoPresu As String 'copia local
    Public ClaveSeg As String 'copia local
    Public ClaveAux1 As String 'copia local balance resultados
    Public ClaveAux2 As String 'copia local agrupacion
    Public ClaveAux3 As String 'copia local flujo de caja
    Public ClaveAux4 As String 'copia local dsri f 101

    Public Ccosto As Boolean
    Public EsGasto As Boolean

    Public ConceptoCompras As Short
    Public ConceptoVentas As Short
    Public ConceptoBcoEgreso As Short
    Public ConceptoBcoIngreso As Short
    Public CodigoAlterno As String

    Public escosDirecto As Boolean
    Public esCosIndirecto As Boolean
    Public ModuloAuxiliar As String
    Public colclassif As DaxClasificadores.ClasificadoresCtb
    Public Clasificadores As String
    Public CuentaPadre As String
    Public usuario As String
    Public Detalle As String
    Public FechaCierre As Date
    Public Estado As String
    Public Gasto As Boolean
    Public CosDirecto As Boolean
    Public CosIndirecto As Boolean
    Public tipoCosto As String

    Public Shared DatEmp As DataTable
    Public Function Eliminar(ByRef cod As String) As Boolean
        Dim Largo As Short
        Eliminar = False
        Largo = CShort(Len(cod))

        Dim ssql As String = "select top( 1) * from adcdia where Cta_codigo  ='" & cod & "' "
        Dim rs As SqlDataReader = SqlDatos.leerBase(ssql, datosEmpresa.strConxAdcom)
        If rs.Read() = False Then
            rs.Close()
            ssql = "select top( 1) * from adccta where substring(Cta_codigo,1," & Largo & ") ='" & cod & "' and cta_codigo <> '" & cod & "'"
            rs = SqlDatos.leerBase(ssql, datosEmpresa.strConxAdcom)
            If rs.Read = False Then
                SqlDatos.ejecutarComando("DELETE FROM AdcCta WHERE Cta_codigo='" & cod & "' ", datosEmpresa.strConxAdcom)
                Eliminar = True
            Else
                MsgBox("ERROR, No puede eliminarse la cuenta," & vbCr & " Existen cuentas auxiliares")
            End If
        Else
            MsgBox("ERROR, No puede eliminarse la cuenta," & vbCr & " Existen movimientos contables")
        End If
    End Function

    Public Sub EliminarCtaBco(ByRef cod As String)
        Dim CODSQL As String = "DELETE FROM AdcCtaBco WHERE Bco_codigo='" & cod & "' "
        DattCom.SqlDatos.ejecutarComando(CODSQL, datosEmpresa.strConxAdcom)
    End Sub

    Public Sub Cargar(ByRef cod As String)
        'Dim libdat As New DaxLib.DaxLibDigDato
        'Dim LIBBD As New DaxLib.DaxLibBases
        'Dim linkdat As New DaxData.DaxLibDatos
        codigo = ""
        Nombre = ""
        Grupo = ""
        Agrupacion = False
        TipoPresu = ""
        ClaveSeg = ""
        ClaveAux1 = ""
        ClaveAux2 = ""
        ClaveAux3 = ""
        ClaveAux4 = ""
        ConceptoCompras = 0
        ConceptoVentas = 0
        ConceptoBcoEgreso = 0
        ConceptoBcoIngreso = 0
        CodigoAlterno = ""
        Clasificadores = ""
        usuario = ""
        CuentaPadre = ""
        escosDirecto = False
        esCosIndirecto = False
        Ccosto = False
        EsGasto = False
        tipoCosto = ""
        Detalle = ""
        FechaCierre = System.DateTime.FromOADate(VariantType.Null)
        Estado = ""
        Nivel = 0
        'Dim conxadcom As New ADODB.Connection
        'LIBBD.TipoBase = "SQL"
        'conxadcom.ConnectionString = LIBBD.StrAdcom
        'conxadcom.Open()
        Dim rs As SqlDataReader = DattCom.SqlDatos.leerBase("SELECT * FROM AdcCta WHERE Cta_Codigo='" & cod & "'", datosEmpresa.strConxAdcom)
        With rs

            If .Read() Then
                codigo = CStr(rs.Item("CTA_CODIGO"))
                Nombre = CStr(.Item("CTA_NOMBRE"))
                If Not IsDBNull(.Item("cta_grupo")) Then Grupo = CStr(.Item("cta_grupo"))
                If Not IsDBNull(.Item("cta_agrupacion")) Then Agrupacion = CBool(.Item("cta_agrupacion"))
                If Not IsDBNull(.Item("cta_tipopresu")) Then TipoPresu = CStr(.Item("cta_tipopresu"))
                If Not IsDBNull(.Item("cta_claveseg")) Then ClaveSeg = CStr(.Item("cta_claveseg"))
                If Not IsDBNull(.Item("cta_claveaux1")) Then ClaveAux1 = CStr(.Item("cta_claveaux1"))
                If Not IsDBNull(.Item("cta_claveaux2")) Then ClaveAux2 = CStr(.Item("cta_claveaux2"))
                If Not IsDBNull(.Item("cta_claveaux3")) Then ClaveAux3 = CStr(.Item("cta_claveaux3"))
                If Not IsDBNull(.Item("cta_claveaux4")) Then ClaveAux4 = CStr(.Item("cta_claveaux4"))
                If Not IsDBNull(.Item("ConceptoCompras")) Then ConceptoCompras = CShort(.Item("ConceptoCompras"))
                If Not IsDBNull(.Item("ConceptoVentas")) Then ConceptoVentas = CShort(.Item("ConceptoVentas"))
                If Not IsDBNull(.Item("ConceptoBcoEgreso")) Then ConceptoBcoEgreso = CShort(.Item("ConceptoBcoEgreso"))
                If Not IsDBNull(.Item("ConceptoBcoIngreso")) Then ConceptoBcoIngreso = CShort(.Item("ConceptoBcoIngreso"))
                If Not IsDBNull(.Item("CodigoAlterno")) Then CodigoAlterno = CStr(.Item("CodigoAlterno"))
                If Not IsDBNull(.Item("Clasificadores")) Then Clasificadores = CStr(.Item("Clasificadores"))
                If Not IsDBNull(.Item("cta_usuario")) Then usuario = CStr(.Item("cta_usuario"))
                If Not IsDBNull(.Item("CuentaPadre")) Then CuentaPadre = CStr(.Item("CuentaPadre"))
                If Not IsDBNull(.Item("Detalle")) Then Detalle = CStr(.Item("Detalle"))
                If Not IsDBNull(.Item("FechaCierre")) Then FechaCierre = CDate(.Item("FechaCierre"))
                If Not IsDBNull(.Item("Estado")) Then Estado = CStr(.Item("Estado"))
                If Not IsDBNull(.Item("Cta_Nivel")) Then Nivel = CShort(.Item("Cta_Nivel"))
                If Not IsDBNull(.Item("ModuloAuxiliar")) Then ModuloAuxiliar = CStr(.Item("ModuloAuxiliar"))
                If Not IsDBNull(.Item("tipoCosto")) Then tipoCosto = CStr(.Item("tipoCosto"))

                'Ccosto = (libdat.CorrijeNulo(.Fields("Cta_CCosto")) = "S")
                'EsGasto = libdat.CorrijeNuloN(.Fields("Cta_Gasto").Value = 1)
                'escosDirecto = libdat.CorrijeNuloN(.Fields("Cta_CostosDir").Value = 1)
                'esCosIndirecto = libdat.CorrijeNuloN(.Fields("Cta_CostosInDir").Value = 1)

            End If

            .Close()
        End With


    End Sub

    Public Function Guardar() As Boolean
        Dim rs As New DataTable
        Dim ssql As String = ""
        Dim da As New SqlDataAdapter("SELECT * FROM AdcCta WHERE Cta_codigo ='" & codigo & "'", datosEmpresa.strConxAdcom)
        da.Fill(rs)
        If rs.Rows.Count = 0 Then rs.Rows.Add(rs.NewRow)
        Dim row As DataRow = rs.Rows(0)
        With row
            .Item("CTA_CODIGO") = Trim(codigo)
            .Item("CTA_NOMBRE") = Trim(Nombre)
            .Item("cta_grupo") = Grupo
            .Item("cta_agrupacion") = Agrupacion
            .Item("cta_tipopresu") = Trim(TipoPresu)
            .Item("cta_claveseg") = Trim(ClaveSeg)
            .Item("cta_claveaux1") = Trim(ClaveAux1)
            .Item("cta_claveaux2") = Trim(ClaveAux2)
            .Item("cta_claveaux3") = Trim(ClaveAux3)
            .Item("cta_claveaux4") = Trim(ClaveAux4)
            .Item("Cta_Nivel") = Nivel
            .Item("cta_usuario") = usuario
            '!Cta_CCosto = (Ccosto)
            .Item("Cta_Gasto") = (EsGasto)
            .Item("Cta_CostosDir") = (escosDirecto)
            .Item("Cta_CostosInDir") = (esCosIndirecto)

            .Item("ConceptoCompras") = ConceptoCompras
            .Item("ConceptoVentas") = ConceptoVentas
            .Item("ConceptoBcoEgreso") = ConceptoBcoEgreso
            .Item("ConceptoBcoIngreso") = ConceptoBcoIngreso
            .Item("CodigoAlterno") = CodigoAlterno
            .Item("Clasificadores") = Clasificadores
            .Item("CuentaPadre") = CuentaPadre
            .Item("Detalle") = Detalle
            .Item("Estado") = Estado
            .Item("FechaCierre") = "31/12/1900" 'FechaCierre
            .Item("ModuloAuxiliar") = ModuloAuxiliar
            .Item("tipoCosto") = tipoCosto
        End With
        Dim db As New SqlCommandBuilder(da)
        da.Update(rs)
        db.Dispose()
        da.Dispose()
        rs.Dispose()

    End Function

    Public Function BuscarCta(ByRef cta As String) As Boolean
        Dim rs As SqlDataReader
        rs = DattCom.SqlDatos.leerBase("SELECT * FROM AdcCta WHERE Cta_Codigo='" & cta & "'", datosEmpresa.strConxAdcom)
        BuscarCta = rs.Read()
        rs.Close()
    End Function

    Public Function GuardarCtaBco(ByRef CodCta As String, ByRef CodBco As String, ByRef CodAlex As String, ByRef nom As String, ByRef numCta As String, ByRef TipoCta As String, ByRef Saldo As Double, ByRef fecha As String) As Boolean
        Dim rs As New DataTable
        Dim ssql As String = ""
        Dim da As New SqlDataAdapter("SELECT * FROM AdcCtaBco WHERE Bco_Codigo='" & CodBco & "'", datosEmpresa.strConxAdcom)
        da.Fill(rs)
        If rs.Rows.Count = 0 Then rs.Rows.Add(rs.NewRow)
        Dim row As DataRow = rs.Rows(0)
        With row
            .Item("Bco_Codigo") = Trim(CodBco)
            .Item("CTA_CODIGO") = Trim(CodCta)
            .Item("Bco_CodAlex") = Trim(CodAlex)
            .Item("Bco_Nombre") = Trim(nom)
            .Item("Bco_NumCta") = Trim(numCta)
            .Item("Bco_TipoCta") = Trim(TipoCta)
            .Item("Bco_Saldo") = Saldo
            If IsDate(fecha) Then .Item("Bco_Fecha") = fecha
        End With
        Dim db As New SqlCommandBuilder(da)
        da.Update(rs)
        db.Dispose()
        da.Dispose()
        rs.Dispose()
    End Function

    Public Function Saldo(ByRef cta As String, ByRef SNSaldo As Boolean, ByRef QueTipoEs As String, Optional ByRef Hasta As String = "", Optional ByRef Desde As String = "", Optional ByRef anioAnt As Short = 0) As Double
        'EL CAMPO SNSALDO ES CUANDO SEA SALDO O MOVIMIENTO, MOVIMIENTO DEVUELVE EL SALDO DE UN PERIODO
        'DETERMINADO
        'QueTipoEs, ESTA VARIABLE ES PARA SABER QUE TIPO DE DOCUMENTOS SE USARAN PARA EL SALDO
        'O OCULTOS
        'N NO OCULTOS
        'T TODOS
        '        Dim daxlib As New DaxLib.DaxLibBases
        Dim cod As String
        Dim Anio As Integer
        Dim Mes As Short
        Dim fechaci As Date
        Dim sal1 As Double
        '       Dim RsAux As ADODB.Recordset
        Dim ProCta As New Cuenta
        Dim DeResultados As Short
        Dim anioAct As Short
        '      Dim linkdat As New DaxData.DaxLibDatos
        Dim fechaIni As New Date

        '     daxlib.TipoBase = ""
        '    Dim strConxadcom As String = daxlib.StrAdcom
        '   Dim conxadcom As New ADODB.Connection
        '  conxadcom.ConnectionString = strConxadcom
        ' conxadcom.Open()
        'RsAux = New ADODB.Recordset
        '        If IsNothing(Emp) Then Main()
        '       If Emp.codigo = 0 Then Main()
        'leer  'fechaci =  Emp.ConUltAnu
        'verifico el saldo del año anterior


        ProCta = New Cuenta
        ProCta.Cargar(cta)
        DeResultados = CShort(Val(ProCta.Grupo))
        'If IsNothing(Desde) Then Desde = ""
        If Hasta = "" Then Hasta = FormatDateTime(Today, CType("dd/mm/yyyy", DateFormat))
        anioAct = CShort(Year(CDate(Hasta)))
        If anioAct > Year(fechaci) Then Anio = Year(fechaci) Else Anio = anioAct
        Mes = CShort(Month(fechaci))
        sal1 = 0
        Try
            fechaIni = Convert.ToDateTime(Desde)
        Catch ex As Exception
            fechaIni = DateAdd(DateInterval.Day, 1, fechaci)
        End Try
        If SNSaldo = True Then
            If DeResultados <> 4 Then
                Dim RsAux As SqlDataReader = DattCom.SqlDatos.leerBase("SELECT isnull(mov_saldebe,0) as debito, isnull(mov_salhaber,0) as credito FROM AdcCtaMov WHERE Cta_Codigo='" & cta & "' AND Mov_Fecha=" & Anio, datosEmpresa.strConxAdcom)
                If RsAux.Read Then
                    sal1 = Convert.ToDouble(RsAux.Item("debito")) - Convert.ToDouble(RsAux.Item("credito"))
                End If
                RsAux.Close()
            Else
                If Year(fechaIni) > Year(fechaci) Then
                    fechaIni = New Date(Year(CDate(Hasta)), 1, 1)
                End If
            End If
        End If

        If Not IsNothing(Hasta) And CDate(Hasta) > fechaci Then
            cod = "SELECT SUM(Dia_Valor * Dia_Signo) AS Val FROM AdcDia "
            '" on i.Opc_Documento=d.Opc_Documento AND i.Doc_Sucursal=d.Doc_Sucursal AND i.idclavedoc=d.idclavedoc "
            If Desde = "" Then
                cod += " WHERE Dia_Fecha<=" & Hasta
            Else
                cod += " WHERE Dia_Fecha<=" & Hasta & " AND Dia_Fecha>=" & fechaIni.ToShortTimeString
            End If
            cod += " AND Left(Cta_Codigo," & Len(cta) & ")='" & cta & "'"
            Dim RsAux As SqlDataReader = DattCom.SqlDatos.leerBase("SELECT isnull(mov_saldebe,0) as debito, isnull(mov_salhaber,0) as credito FROM AdcCtaMov WHERE Cta_Codigo='" & cta & "' AND Mov_Fecha=" & Anio, datosEmpresa.strConxAdcom)
            Dim valor As Double = Val(RsAux.Item("Val"))
            If RsAux.Read() Then
                If SNSaldo = True Then
                    sal1 = sal1 + valor
                Else
                    sal1 = valor
                End If
            End If
            RsAux.Close()
            RsAux.Dispose()
            'Catch ex As Exception
            '    MsgBox("Exception en saldo de cuentas ctb: " & vbCr & ex.Message)
            'End Try
        End If
        Saldo = sal1

    End Function

    Public Function Utilidad(ByRef Hasta As Date, ByRef SNSaldo As Boolean, ByRef QueTipoEs As String, Optional ByRef Desde As String = "", Optional ByRef anioAnt As Short = 0) As Double
        Dim cod As String = "SELECT SUM(Dia_Valor * Dia_Signo) AS Val FROM AdcDia Left  join AdcCta on adccta.Cta_Codigo=adcdia.Cta_Codigo where Cta_Grupo='4' " & " "
        If IsNothing(Desde) Then
            cod += " AND Dia_Fecha<=" & Hasta.ToShortDateString()
        Else
            cod += " AND Dia_Fecha<=" & Hasta.ToShortDateString & " AND Dia_Fecha>=" & Desde
        End If

        QueTipoEs = ""
        Dim RsAux As SqlDataReader = DattCom.SqlDatos.leerBase(cod, datosEmpresa.strConxAdcom)
        If RsAux.Read Then
            Try
                Utilidad = System.Math.Round(CDbl(RsAux.Item("Val")), Emp.NumeroDigitos)
            Catch
                Utilidad = 0
            End Try
        End If
        RsAux.Close()
        RsAux.Dispose()
    End Function

    Public Function NombreCuentaContable(ByRef codigo As String) As String
        Dim cod As String = "SELECT Cta_Codigo,Cta_Nombre FROM AdcCta WHERE Cta_Codigo='" & Trim(codigo) & "'"
        Dim RsAux As SqlDataReader = DattCom.SqlDatos.leerBase(cod, datosEmpresa.strConxAdcom)
        If RsAux.Read() Then
            NombreCuentaContable = RsAux.Item("CTA_NOMBRE").ToString()
        Else
            NombreCuentaContable = ""
        End If
        RsAux.Close()
        RsAux.Dispose()
    End Function

    Public Function ValidarCuentaContable() As Boolean
    End Function

    Public Function AbrirClasificadores(ByRef ClasificadoresCol() As String) As Short

    End Function

    Public Sub NombClasi(ByRef NomClas() As String)
    End Sub

    Public Function ModulosAuxiliares() As String
        Dim Aux As String = ""
        If Emp.Acf Then Aux = "Activos Fijos;"
        Aux = Aux & "Anticipos Clientes"
        Aux = Aux & ";" & "Anticipos Proveedores"
        Aux = Aux & ";" & "CajaBancos"
        Aux = Aux & ";" & "Compras"
        Aux = Aux & ";" & "Cuentas Cobrar Clientes"
        Aux = Aux & ";" & "Cuentas Pagar Proveedores"
        If Emp.Inv Then Aux = Aux & ";" & "Inventarios"
        If Emp.rol Then Aux = Aux & ";" & "Nómina"
        Aux = Aux & ";" & "Ventas"
        ModulosAuxiliares = Aux
    End Function

    Private Sub Main()
        'On Error GoTo HayErrores
        'Dim Opcion As Short
        'Dim opc() As String
        'Dim tipo As Short
        'Dim daxlib As New DaxLibBases
        'CONEMP = New AdcDax.DaxSofSys
        'Emp = CONEMP.EmpresaAct
        'CONUSR = New DaxUsr.DaxsofUsr
        'ControlUsuario = CONUSR.UsuarioAct
        'Set ConxAdcom = New ADODB.Connection
        'ConxAdcom.ConnectionString = daxlib.StrAdcom '(Emp.NombreBaseAdcom, Emp.servidor, "", Emp.ClaveBD, Emp.UsuarioBd)
        'If ConxAdcom.State = 0 Then ConxAdcom.Open
        'Set ConxSysemp = New ADODB.Connection
        'ConxSysemp.ConnectionString = daxlib.StrDaxsys '("Daxsys", Emp.servidor, "", Emp.ClaveBD, Emp.UsuarioBd)
        'If ConxSysemp.State = 0 Then ConxSysemp.Open
        Autorizacion = Emp.Autorizacion
        'Set daxlib = Nothing
        '        Exit Sub
        'HayErrores:
        '        MsgBox(" No se ha cargado BuscaCta correctamente" + Err.Description)
    End Sub
End Class