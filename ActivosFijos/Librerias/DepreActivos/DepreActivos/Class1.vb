Imports System.Data.SqlClient

Public Class Class1
    Dim conectarBDD As New SqlConnection()
    Dim conectar As New SqlConnection()
    Dim sSql As String
    Dim mes, año, NroDiasLiquidacion, mesIng, mesSal, añoIng, añoSal, dIng, dSal As Long
    Public codigo, nombre, ClaseDepreciacion, usuarioProceso As String
    Dim VALORENLIBROS, COSTOdelACTIVO, AcumDepreciacion, ProduccionMes As Double
    Dim AcumRevalorizacion, AcumDeterioro, DepreciacionMes, RevalorizacionMes As Double
    Dim IMPORTEDEPRECIABLE, ValorResidualNov, ValorResidualAct, ValorResidual, VidaUtilAlMes, vidaUtilNov, vidaUtilAct As Double
    Dim CapacidadProduccionMes, DeterioroMes, TASA, UndProduccion As Double
    Public fechaDepI, fechaDepF, fechaActI, fechaActS, fechaDesde, FechaHasta, FechaProduccion, fechaProceso As Date
    Dim tipoDepFin, TipoDepTribut, bandera As Integer
    Dim fec, fec2 As String
    Dim opVidaUtilNov As Boolean = False

    Public Sub ConectarBase()
        Dim coneccion As New DaxLib.DaxLibBases
        coneccion.TipoBase = "10"
        conectarBDD.ConnectionString = coneccion.StrAdcom
        conectar.ConnectionString = coneccion.StrAdcom
    End Sub
    Public Sub Depreciación()
        Dim barra As New Depreciacion()
        Dim f, f1 As Long
        Dim contador = 0, aux As Integer = 0
        DepreciacionMes = 0
        ConectarBase()
        If codigo <> "" Then
            ConsultarActivo()
            MesesDep()
            If tipoDepFin <> 0 And TipoDepTribut <> 0 Then
                contador = 0
                aux = 2
            ElseIf tipoDepFin <> 0 And TipoDepTribut = 0 Or tipoDepFin = 0 And TipoDepTribut <> 0 Then
                contador = 1
                aux = 1
            End If
            Do While contador < 2
                If contador = 0 And aux = 2 Then
                    ClaseDepreciacion = "F"
                ElseIf contador = 1 And aux = 1 Then
                    If tipoDepFin <> 0 Then
                        ClaseDepreciacion = "F"
                    ElseIf TipoDepTribut <> 0 Then
                        ClaseDepreciacion = "T"
                    End If
                End If
                Fecha()
                f = añoIng * 100 + mesIng
                f1 = añoSal * 100 + mesSal
                mes = mesIng
                año = añoIng
                Do While f < f1 + 1
                    calcularNoDias(dIng, mes, año, mesSal, añoSal)
                    consultaNov(mes, año)
                    AcumDepreciacion = Acumulados("Depreciacion", mes, año)
                    AcumRevalorizacion = Acumulados("Revalorizacion", mes, año)
                    AcumDeterioro = Acumulados("Deterioro", mes, año)
                    CalculoDatos(codigo, CInt(f))
                    If ClaseDepreciacion = "T" Then
                        If DepreciacionMes <= 0 Or f >= (añoIng + vidaUtilAct) * 100 + mesIng Then
                            bandera = 1
                        Else : bandera = 0
                        End If
                    End If
                    If bandera <> 1 Then
                        InsertarDepreciacion()
                    End If
                    If mes = 12 Then
                        año = año + 1
                        mes = 0
                    End If
                    mes = mes + 1
                    f = año * 100 + mes
                    If mes = mesSal And año = añoSal Then
                        dIng = dSal
                    End If
                Loop
                ClaseDepreciacion = "T"
                contador += 1
            Loop
        Else '********************************
            sSql = "Select codigo from AdcAcf "
            Dim consulta As New SqlCommand(sSql, conectar)
            conectar.Open()
            Dim activos As SqlDataReader
            activos = consulta.ExecuteReader()
            Do While activos.Read
                codigo = activos(0).ToString()
                ConsultarActivo()
                MesesDep()
                If tipoDepFin <> 0 And TipoDepTribut <> 0 Then
                    contador = 0
                    aux = 2
                ElseIf tipoDepFin <> 0 And TipoDepTribut = 0 Or tipoDepFin = 0 And TipoDepTribut <> 0 Then
                    contador = 1
                    aux = 1
                End If
                Do While contador < 2
                    If contador = 0 And aux = 2 Then
                        ClaseDepreciacion = "F"
                    ElseIf contador = 1 And aux = 1 Then
                        If tipoDepFin <> 0 Then
                            ClaseDepreciacion = "F"
                        ElseIf TipoDepTribut <> 0 Then
                            ClaseDepreciacion = "T"
                        End If
                    End If
                    Fecha()
                    f = añoIng * 100 + mesIng
                    f1 = añoSal * 100 + mesSal
                    mes = mesIng
                    año = añoIng
                    Do While f < f1 + 1
                        calcularNoDias(dIng, mes, año, mesSal, añoSal)
                        consultaNov(mes, año)
                        AcumDepreciacion = Acumulados("Depreciacion", mes, año)
                        AcumRevalorizacion = Acumulados("Revalorizacion", mes, año)
                        AcumDeterioro = Acumulados("Deterioro", mes, año)
                        CalculoDatos(codigo, CInt(f))
                        If ClaseDepreciacion = "T" Then
                            If DepreciacionMes <= 0 Or f >= (añoIng + vidaUtilAct) * 100 + mesIng Then
                                bandera = 1
                            Else : bandera = 0
                            End If
                        End If
                        If bandera <> 1 Then
                            InsertarDepreciacion()
                        End If
                        If mes = 12 Then
                            año = año + 1
                            mes = 0
                        End If
                        mes = mes + 1
                        f = año * 100 + mes
                        If mes = mesSal And año = añoSal Then
                            dIng = dSal
                        End If
                    Loop
                    ClaseDepreciacion = "T"
                    contador += 1
                Loop
            Loop
            conectar.Close()
        End If
    End Sub
    'MÉTODO PARA OBTENER LA FECHA
    Private Sub Fecha()
        fec = fechaDepI.ToString()
        fec2 = fechaDepF.ToString()
        dIng = CLng(fec.Substring(0, 2))
        mesIng = CLng(fec.Substring(3, 2))
        añoIng = CLng(fec.Substring(6, 4))
        dSal = CLng(fec2.Substring(0, 2))
        mesSal = CLng(fec2.Substring(3, 2))
        añoSal = CLng(fec2.Substring(6, 4))
    End Sub

    'METODO PARA CONSULTAR LOS CAMPOS DE LA TABLA DE NOVEDADES
    Public Sub consultaNov(ByVal mes As Long, ByVal año As Long)
        sSql = "select NVdeterioro,NVrevalorizacion,NVvidautil,NVvalorresidual from adcAcfNov where Codigo ='" & codigo & "' and (YEAR(FechaNovedad)*100+MONTH(FechaNovedad))=" & año * 100 + mes
        Dim com As New SqlCommand(sSql, conectarBDD)
        Dim dat As SqlDataReader
        If conectarBDD.State <> ConnectionState.Closed Then
            conectarBDD.Close()
        End If
        conectarBDD.Open()
        dat = com.ExecuteReader()
        If dat.Read Then
            If Not IsDBNull(dat("NVdeterioro")) Then
                DeterioroMes = CDbl(dat("NVdeterioro"))
            Else
                DeterioroMes = 0
            End If
            If Not IsDBNull(dat("NVrevalorizacion")) Then
                RevalorizacionMes = CDbl(dat("NVrevalorizacion"))
            Else
                RevalorizacionMes = 0
            End If
            If Not IsDBNull(dat("NVvidautil")) Then
                vidaUtilNov = CDbl(dat("NVvidautil"))
                If vidaUtilNov > 0 Then vidaUtilAct = CDbl(dat("NVvidautil"))
            Else
                vidaUtilNov = 0
            End If
            If Not IsDBNull(dat("NVvalorresidual")) Then
                ValorResidualNov = CDbl(dat("NVvalorresidual"))
                opVidaUtilNov = True
            Else
                ValorResidualNov = 0
            End If
        Else
            DeterioroMes = 0
            RevalorizacionMes = 0
            vidaUtilNov = 0
            ValorResidualNov = 0
        End If
        conectarBDD.Close()
        UnidadesProducidas()
    End Sub
    Private Sub UnidadesProducidas()
        Dim ssql As String = "select sum(NVvalorproduccionmes) as NVvalorproduccionmes from adcAcfNov where Codigo ='" & codigo & "' and (YEAR(FechaProduccion)*100+MONTH(FechaProduccion))=" & año * 100 + mes
        Dim cmd As New SqlCommand(ssql, conectarBDD)
        Dim dat As SqlDataReader = Nothing
        If conectarBDD.State = ConnectionState.Open Then conectarBDD.Close()
        conectarBDD.Open()
        dat = cmd.ExecuteReader()
        If dat.Read Then
            If Not IsDBNull(dat("NVvalorproduccionmes")) Then
                ProduccionMes = CDbl(dat("NVvalorproduccionmes"))
            Else
                ProduccionMes = 0
            End If
        Else
            ProduccionMes = 0
        End If
        conectarBDD.Close()
    End Sub
    'METODO PARA INSERTAR EL REGISTRO DE DEPRECIACION
    Public Sub InsertarDepreciacion()
        sSql = ""
        sSql = "exec ACTFDEP_INS '" & codigo & "',"
        sSql = sSql & " " & año & ","
        sSql = sSql & " " & mes & ","
        sSql = sSql & " '" & ClaseDepreciacion & "',"
        sSql = sSql & " " & AcumDepreciacion & ","
        sSql = sSql & " " & AcumRevalorizacion & ","
        sSql = sSql & " " & AcumDeterioro & ","
        sSql = sSql & " " & VidaUtilAlMes & ","
        sSql = sSql & " " & CapacidadProduccionMes & ","
        sSql = sSql & " " & NroDiasLiquidacion & ","
        sSql = sSql & " " & ProduccionMes & ","
        sSql = sSql & " " & ValorResidual & ","
        sSql = sSql & " " & DeterioroMes & ","
        sSql = sSql & " " & RevalorizacionMes & ","
        sSql = sSql & " " & DepreciacionMes & ","
        sSql = sSql & "'" & fechaProceso & "',"
        sSql = sSql & "'" & usuarioProceso & "',"
        sSql = sSql & " " & 1 & ","
        sSql = sSql & " " & 0
        'Try
        conectarBDD.Open()
        Dim cons As New SqlCommand(sSql, conectarBDD)
        cons.ExecuteNonQuery()
        conectarBDD.Close()
        'Catch ex As Exception
        '    MsgBox("Error al Insertar la Depreciación")
        'End Try
    End Sub
    Public Function nMesesDep(ByVal cod As String, ByVal clase As String) As Integer
        Dim valor As Integer = 0
        Dim ss As String = "select sum(NroDiasLiquidacion) from AdcAcfDep where Codigo='" & cod & "' and ClaseDepreciacion ='" & clase & "'"
        Dim cmd As New SqlCommand(ss, conectarBDD)
        Dim dat As SqlDataReader
        conectarBDD.Open()
        dat = cmd.ExecuteReader()
        If dat.Read Then
            If Not IsDBNull(dat(0)) Then valor = Convert.ToInt16(dat(0))
        End If
        conectarBDD.Close()
        Return valor
    End Function

    'METODO PARA EL CALCULO DE LA DÈPRECIACION DEL MES
    Public Sub CalculoDatos(ByVal codAcf As String, ByVal fec As Integer)
        Dim n As Integer
        Dim valLib As Double
        If ClaseDepreciacion = "T" Then ' SI LA DEPRECIACIÓN ES TRIBUTARIA
            If TipoDepTribut = 1 Then
                DepreciacionMes = ((COSTOdelACTIVO * (TASA / 100)) / 360) * NroDiasLiquidacion
            Else
                DepreciacionMes = 0
            End If
        ElseIf ClaseDepreciacion = "F" Then 'SI LA DEPRECIACIÓN ES FINANCIERA
            If ValorResidualAct <> 0 And ValorResidualNov = 0 Then
                ValorResidual = ValorResidualAct
            ElseIf ValorResidual <> 0 Then
                ValorResidual = ValorResidualNov
            Else
                ValorResidual = 0
            End If
            n = nMesesDep(codigo, ClaseDepreciacion)
            valLib = consultarValorLibros()
            IMPORTEDEPRECIABLE = valLib - ValorResidual
            If IMPORTEDEPRECIABLE = 0 Then
                bandera = 1
                Exit Sub
            Else
                bandera = 0
            End If
            If tipoDepFin = 1 Then 'SI LA DEPRECIACIÓN ES TIPO LINEAL
                'If vidaUtilNov = 0 Then
                '    VidaUtilAlMes = (vidaUtilAct * 360) - n '(NroDiasLiquidacion)
                '    If VidaUtilAlMes <= 0 Then
                '        bandera = 1
                '        Exit Sub
                '    End If
                'Else
                VidaUtilAlMes = CalcularVidaUtilMes(codAcf, fec)
                'End If
                DepreciacionMes = (IMPORTEDEPRECIABLE / VidaUtilAlMes) * NroDiasLiquidacion
            ElseIf tipoDepFin = 2 Then ' SI LA DEPRECIACIÓN ES TIPO PRODICCIÓN
                If UndProduccion = 0 Then
                    CapacidadProduccionMes = UndProduccion - ProduccionMes
                Else
                    CapacidadProduccionMes = UndProduccion
                End If
                DepreciacionMes = (IMPORTEDEPRECIABLE / CapacidadProduccionMes) * ProduccionMes
            End If
        End If
        VALORENLIBROS = COSTOdelACTIVO - AcumDepreciacion + AcumRevalorizacion - AcumDeterioro - DepreciacionMes + RevalorizacionMes
    End Sub
    'METODO PARA CALCULAR LA VIDA UTIL DEL MES TOMANDO EN CUANTA EL VALOR DEL LAS NOVEDADES O DE LAS DEPRECIACIONES ANETRIORES
    Private Function CalcularVidaUtilMes(ByVal cod As String, ByVal fec As Integer) As Double 
        Dim vidautil As Double = 0.0
        Dim ssql As String = "select NVvidautil from adcAcfNov where Codigo ='" & cod & "' and (YEAR(FechaNovedad)*100+MONTH(FechaNovedad))=" & fec
        'consulta la vidautil en la tabla de novedades
        vidautil = EjecutarConsul(ssql) * 360
        If vidautil = 0 Then
            'si no encontro valor en la tabla de novedades busca la vida util al mes de la útlima depreciavión
            ssql = "select cast(VidaUtilAlMes as numeric(18,0)) as VidaU from adcacfdep where codigo='" & cod & "' and claseDepreciacion='F' order by  año*100+mes desc" ' = fec
            vidautil = EjecutarConsul(ssql)
            If vidautil = 0 Then
                ' si no encuentra la vida util en las depreciaciones busca en el catalogo de activos
                ssql = "select VidaUtilCont from adcacf where Codigo='" & cod & "'"
                vidautil = EjecutarConsul(ssql) * 360
            Else
                vidautil = vidautil - NroDiasLiquidacion
            End If
        End If
        Return vidautil
    End Function
    Private Function EjecutarConsul(ByVal ssql As String) As Double
        Dim val As Double = 0.0
        Dim cmd As New SqlCommand(ssql, conectarBDD)
        Dim dat As SqlDataReader = Nothing
        cmd = New SqlCommand(ssql, conectarBDD)
        conectarBDD.Open()
        dat = cmd.ExecuteReader()
        If dat.Read Then
            If Not IsDBNull(dat(0)) Then val = CDbl(dat(0))
        End If
        conectarBDD.Close()
        dat = Nothing
        Return val
    End Function
    'METODO PARA CONSULTAR LA DEPRECIACION DEL MES ANTERIOR
    Public Function consultarValorLibros() As Double
        Dim valor = 0, dep = 0, det = 0, rev As Double = 0
        Dim fec As Long
        If mes = 1 Then
            fec = (año - 1) * 100 + 12
        Else
            fec = año * 100 + (mes - 1)
        End If
        sSql = "select SUM(DepreciacionMes), SUM(RevalorizacionMes), SUM(DeterioroMes) from AdcAcfDep where año*100+Mes <=" & fec & "and Codigo='" & codigo & "'"
        Dim cons As New SqlCommand(sSql, conectarBDD)
        Dim datos As SqlDataReader
        conectarBDD.Open()
        datos = cons.ExecuteReader()
        If datos.Read Then
            If IsDBNull(datos(0)) Then
                valor = 0
            Else
                If IsDBNull(datos(0)) Then
                    dep = 0
                Else
                    dep = Convert.ToInt16(datos(0))
                End If
                If IsDBNull(datos(1)) Then
                    rev = 0
                Else
                    rev = CDbl(datos(1))
                End If
                If IsDBNull(datos(2)) Then
                    det = 0
                Else
                    det = CInt(datos(2))
                End If
            End If
        End If
        conectarBDD.Close()
        valor = CInt(COSTOdelACTIVO - (dep + rev - det))
        Return valor
    End Function

    'FUNCION PARA CALCULAR LOS VALORES ACUMULADOS DE DEPRECIACION,REVALORIZACION,DETERIORO
    Public Function Acumulados(ByVal clase As String, ByVal mes As Long, ByVal año As Long) As Double
        Dim valor As Double
        Dim fec As Long
        If mes = 1 Then
            fec = (año - 1) * 100 + 12
        Else
            fec = año * 100 + (mes - 1)
        End If
        valor = 0
        If clase = "Depreciacion" Then
            sSql = "select SUM(DepreciacionMes)from AdcAcfDep where año*100+Mes <= " & fec & " and Codigo='" & codigo & "'"
        ElseIf ClaseDepreciacion = "Revalorizacion" Then
            sSql = "select SUM((RevalorizacionMes))from AdcAcfDep where año*100+Mes <= " & fec & " and Codigo='" & codigo & "'"
        Else
            sSql = "select SUM((DeterioroMes))from AdcAcfDep where año*100+Mes <= " & fec & " and Codigo='" & codigo & "'"
        End If
        Dim cons As New SqlCommand(sSql, conectarBDD)
        Dim dat As SqlDataReader
        Try
            conectarBDD.Open()
            dat = cons.ExecuteReader()
            If dat.Read Then
                If IsDBNull(dat(0)) Then
                    valor = 0
                Else
                    valor = CDbl(dat(0))
                End If
            End If
            conectarBDD.Close()
        Catch ex As Exception
            MsgBox("Error al Calcular el Valor Acumulado")
        End Try
        Return valor
    End Function
    'FUNCIÓN PARA CALCULAR EL NUMERO DE DIAS DE LIQUIDACIÓN
    Public Sub MesesDep()
        If fechaDesde < fechaActI Then
            fechaDepI = fechaActI
        Else
            fechaDepI = fechaDesde
        End If
        If fechaActS <= CDate("31/12/1900") Then
            fechaDepF = FechaHasta
        ElseIf FechaHasta < fechaActS Then
            fechaDepF = FechaHasta
        Else
            fechaDepF = fechaActS
        End If


    End Sub
    Public Sub calcularNoDias(ByVal dias As Long, ByVal mes As Long, ByVal año As Long, ByVal mesS As Long, ByVal añoS As Long)
        If mes <> mesS Or (mes = mesS And año <> añoS) Then
            If dias <> 1 Then
                NroDiasLiquidacion = 30 - dias
            Else
                NroDiasLiquidacion = 30
            End If
            dIng = 1
        ElseIf mes = mesS And año = añoS Then
            If dias < 31 Then
                NroDiasLiquidacion = dias
            Else
                NroDiasLiquidacion = 30
            End If
        End If
    End Sub
    'METODO PARA CONSULTAR TODOS LOS ACTIVOS
    Public Function ConsultarTodos() As SqlDataReader
        sSql = "Select codigo, TipoDepreciacionCont ,TipoDepreciacionTributa  from AdcAcf "
        Dim consulta As New SqlCommand(sSql, conectarBDD)
        conectarBDD.Open()
        Dim datos As SqlDataReader
        datos = consulta.ExecuteReader()
        conectarBDD.Close()
        Return datos
    End Function
    'METODO PARA CONSULTAR EL ACTIVO
    Public Sub ConsultarActivo()
        sSql = "select Nombre,ValorResidual,UnidacesProduccionCont,TasaDepTribut,FecIngreso,FecSalida,TipoDepreciacionCont,TipoDepreciacionTributa,CostoIngreso,VidaUtilCont,VidaUtilTributa from AdcAcf  where Codigo='" & codigo & "'"
        Dim consulta As New SqlCommand(sSql, conectarBDD)
        Dim datos As SqlDataReader
        Try
            If conectarBDD.State = ConnectionState.Open Then conectarBDD.Close()
            conectarBDD.Open()
            datos = consulta.ExecuteReader()
            If datos.Read Then
                If Not IsDBNull(datos(0)) Then nombre = datos(0).ToString()
                If Not IsDBNull(datos(1)) Then ValorResidualAct = CDbl(datos(1)) Else ValorResidualAct = 0
                If Not IsDBNull(datos(2)) Then UndProduccion = CDbl(datos(2)) Else UndProduccion = 0
                If Not IsDBNull(datos(3)) Then TASA = CDbl(datos(3))
                If Not IsDBNull(datos(4)) Then fechaActI = CDate(datos(4))
                If Not IsDBNull(datos(5)) Then fechaActS = CDate(datos(5))
                If Not IsDBNull(datos(6)) Then tipoDepFin = CInt(datos(6))
                If Not IsDBNull(datos(7)) Then TipoDepTribut = CInt(datos(7))
                If Not IsDBNull(datos(8)) Then COSTOdelACTIVO = CDbl(datos(8))
                If Not IsDBNull(datos(9)) Then vidaUtilAct = CDbl(datos(9)) Else vidaUtilAct = 0
                If vidaUtilAct = 0 Then
                    If Not IsDBNull(datos(10)) Then vidaUtilAct = CDbl(datos(10))
                End If

            End If
            conectarBDD.Close()
        Catch ex As Exception
            MsgBox("Error al consultar el Activo")
        End Try
    End Sub
End Class
