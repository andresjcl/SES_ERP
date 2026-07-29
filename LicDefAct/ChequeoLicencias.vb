Option Strict Off
Option Explicit On

Imports System.Windows.Forms
Imports DattCom
Imports System.Data.SqlClient
Imports System.Collections.Generic

Public Class ChequeoLicencias

    Public Shared Function ChequearLicencias(major As Int32, PathServidor As String, PathAppl As String, QueSistema As String, Autorizaciones As String, FF As String) As Long
        'Dim Proglib As New daaxLib.DaxLibDigDato
        Dim n As String = ""
        Dim V As String = ""
        Dim Sh As String = ""
        Dim datex As Date
        Dim NombrePcX As String = ""
        Dim ConxDaxSys As New SqlClient.SqlConnection(datosEmpresa.strConxSyscod)
        ConxDaxSys.Open()
        Dim rsUsr As SqlClient.SqlDataReader
        Dim rsEmp As SqlClient.SqlDataReader

        Dim a As Integer
        Dim b As Integer
        Dim Licencias As Integer
        Dim EmpNombre As String
        Dim EmpNombreBase As String = ""
        Dim EmpRuc As String
        Dim EmpClave As Long
        Dim Opciones As String = ""
        Dim ClaveFinal() As String
        Dim AUX1 As String
        Dim Valido As Integer
        Dim FechaServ As Date = CDate("0:0")
        datex = CDate("17/09/3007")
        ChequearLicencias = 0
        a = Len(Dir(PathServidor & QueSistema) & ".xml")
        If a = 0 Then MsgBox("La dirección URL de directorios en el servidor está errada, registrela nuevamente") : Return 0

        NuevaCodificacion.DatosPc(PathServidor, NombrePcX, V, n, Sh)
        Valido = 1
        Dim Comm As New SqlClient.SqlCommand("Select * from emp_datos where emp_defecto <> 0 ", ConxDaxSys)
        rsEmp = Comm.ExecuteReader
        If rsEmp.Read = False Then Valido = 0
        If Valido = 0 Then MsgBox("Antes de continuar debe registrar la empresa principal en el sistema ") : Return 0
        EmpNombre = rsEmp.Item("Emp_Nombre").ToString()
        EmpNombreBase = "BdAdcomDx"
        EmpClave = CLng(rsEmp.Item("Emp_Codigo").ToString())
        EmpRuc = rsEmp.Item("Emp_RUC").ToString()
        If rsEmp.IsClosed = False Then rsEmp.Close()

        ' ============================================================
        ' 1. VERIFICAR SI EXISTE UNA LICENCIA ACTIVA (NO EXPIRADA) EN TABLA Licencias
        ' ============================================================
        Dim licenciaActiva As Boolean = VerificarLicenciaActivaYVigenteEnTabla(EmpRuc)

        If licenciaActiva Then
            ' ============================================================
            ' HAY LICENCIA ACTIVA Y VIGENTE - CARGARLA Y USARLA
            ' ============================================================
            Dim infoLicencia As LicenciaInfo = CargarLicenciaActivaDesdeTabla(EmpRuc)
            If infoLicencia IsNot Nothing Then
                ' VERIFICAR QUE NO HAYA EXPIRADO (DOBLE VALIDACIÓN)
                If infoLicencia.FechaExpiracion < DateTime.Now Then
                    ' Desactivar licencia expirada
                    DesactivarLicencia(ConxDaxSys, EmpRuc)
                    EliminarSysAccesos(ConxDaxSys, QueSistema)

                    ' Limpiar datos
                    datosEmpresa.TipoLicencia = 0
                    datosEmpresa.ModulosActivos = ""
                    datosEmpresa.GruposActivos = ""
                    datosEmpresa.OpcionesLicencia = ""

                    MsgBox("❌ SU LICENCIA HA EXPIRADO" & vbCrLf & vbCrLf &
                           "Fecha de expiración: " & infoLicencia.FechaExpiracion.ToString("dd/MM/yyyy") & vbCrLf &
                           "Debe ingresar una nueva clave de activación para continuar.",
                           MsgBoxStyle.Information, "Licencia Expirada")

                    GoTo SinClave
                End If

                datosEmpresa.TipoLicencia = infoLicencia.TipoLicencia
                datosEmpresa.OpcionesLicencia = infoLicencia.Opciones
                datosEmpresa.ModulosActivos = infoLicencia.Opciones
                datosEmpresa.GruposActivos = DecodificarOpciones(infoLicencia.Opciones)
                datosEmpresa.FechaExpiracion = infoLicencia.FechaExpiracion
                datosEmpresa.MaxUsuarios = infoLicencia.MaxUsuarios

                Return infoLicencia.TipoLicencia
            End If
        End If

        ' ============================================================
        ' 2. VERIFICAR SI EXISTE UNA LICENCIA EN SYS_ACCESOS (FALLBACK)
        ' ============================================================
        Valido = 0
        Comm.CommandText = "select *,getdate() as FechaServ  FROM SYS_ACCESOS where (idusuario = 'Adm' or idusuario = 'Ctrl' ) and idopcion <> 'mnuoa' and idempresa = 0 and idsistema = '" & QueSistema & "'"
        Comm.Connection = ConxDaxSys
        rsUsr = Comm.ExecuteReader
        ReDim ClaveFinal(0 To 6)
        With rsUsr
            Do While rsUsr.Read
                Valido = 1
                FechaServ = CDate(rsUsr.Item("FechaServ"))
                If .Item("idusuario").ToString() = "Adm" Then
                    ClaveFinal(2) = .Item("Accesos").ToString()
                    ClaveFinal(4) = .Item("IdOpcion").ToString()
                    ClaveFinal(6) = .Item("IdNomOpcion").ToString()
                ElseIf .Item("idusuario").ToString() = "Ctrl" Then
                    ClaveFinal(1) = .Item("Accesos").ToString()
                    ClaveFinal(3) = .Item("IdOpcion").ToString()
                    ClaveFinal(5) = .Item("IdNomOpcion").ToString()
                End If
            Loop
            .Close()
        End With

        ' ============================================================
        ' 3. SI HAY LICENCIA EN SYS_ACCESOS, VERIFICAR EXPIRACIÓN
        ' ============================================================
        Dim licenciaEnSysAccesos As Boolean = False
        If Valido = 1 Then
            AUX1 = ""
            For i = 1 To 6
                If AUX1 > "" Then AUX1 += "-"
                AUX1 += ClaveFinal(i)
            Next i
            ReDim ClaveFinal(0)
            If rsUsr.IsClosed = False Then rsUsr.Close()
            Licencias = CInt(NuevaCodificacion.DeCodificarLicencia(AUX1, datex, CStr(NuevaCodificacion.ValorStr(EmpNombre)), EmpRuc, n, CStr(NuevaCodificacion.ValorStr(NombrePcX)), CStr(NuevaCodificacion.ValorStr(QueSistema)), Opciones, a, b))

            If Licencias > 0 Then
                licenciaEnSysAccesos = True
                datosEmpresa.auto = Opciones

                datosEmpresa.TipoLicencia = Licencias
                datosEmpresa.OpcionesLicencia = Opciones
                datosEmpresa.ModulosActivos = Opciones
                datosEmpresa.GruposActivos = DecodificarOpciones(Opciones)

                ' OBTENER FECHA DE EXPIRACIÓN EXCLUSIVAMENTE DE LA TABLA
                Dim fechaDesdeTabla As DateTime = ObtenerFechaExpiracionDesdeTabla(EmpRuc)

                If fechaDesdeTabla <> DateTime.MinValue Then
                    ' USAR LA FECHA DE LA TABLA (LA QUE VIENE DEL GENERADOR)
                    datosEmpresa.FechaExpiracion = fechaDesdeTabla
                Else
                    ' SOLO COMO FALLBACK EXTREMO - NO DEBERÍA SUCEDER
                    datosEmpresa.FechaExpiracion = CalcularFechaExpiracionPorTipo(Licencias)
                End If

                datosEmpresa.MaxUsuarios = ObtenerMaxUsuarios(Licencias)

                ' ============================================================
                ' VERIFICAR SI LA LICENCIA ESTÁ EXPIRADA
                ' ============================================================
                If datosEmpresa.FechaExpiracion < DateTime.Now Then
                    ' Eliminar sys_Accesos
                    EliminarSysAccesos(ConxDaxSys, QueSistema)

                    ' Limpiar datos en memoria
                    datosEmpresa.TipoLicencia = 0
                    datosEmpresa.ModulosActivos = ""
                    datosEmpresa.GruposActivos = ""
                    datosEmpresa.OpcionesLicencia = ""

                    ' Desactivar licencia en tabla
                    DesactivarLicencia(ConxDaxSys, EmpRuc)

                    ' Mostrar mensaje y solicitar nueva licencia
                    MsgBox("❌ SU LICENCIA HA EXPIRADO" & vbCrLf & vbCrLf &
                           "Fecha de expiración: " & datosEmpresa.FechaExpiracion.ToString("dd/MM/yyyy") & vbCrLf &
                           "Debe ingresar una nueva clave de activación para continuar.",
                           MsgBoxStyle.Information, "Licencia Expirada")

                    ' Ir a SinClave para activar nueva licencia
                    GoTo SinClave
                End If

                Return Licencias
            End If
        End If

        ' ============================================================
        ' 4. VERIFICAR SI EXISTE LICENCIA INACTIVA (EXPIRADA) EN TABLA
        ' ============================================================
        Dim licenciaInactiva As Boolean = VerificarLicenciaInactivaEnTabla(EmpRuc)

        If licenciaInactiva Then
            ' ============================================================
            ' LICENCIA EXPIRADA - ELIMINAR SYS_ACCESOS Y SOLICITAR NUEVA
            ' ============================================================

            ' Eliminar sys_Accesos
            EliminarSysAccesos(ConxDaxSys, QueSistema)

            ' Limpiar datos en memoria
            datosEmpresa.TipoLicencia = 0
            datosEmpresa.ModulosActivos = ""
            datosEmpresa.GruposActivos = ""
            datosEmpresa.OpcionesLicencia = ""

            ' Obtener fecha de expiración
            Dim fechaExp As DateTime = ObtenerFechaExpiracionInactiva(EmpRuc)

            ' Mostrar mensaje informativo
            MsgBox("❌ SU LICENCIA HA EXPIRADO" & vbCrLf & vbCrLf &
                   "Fecha de expiración: " & fechaExp.ToString("dd/MM/yyyy") & vbCrLf &
                   "Debe ingresar una nueva clave de activación para continuar.",
                   MsgBoxStyle.Information, "Licencia Expirada")

            ' Ir a SinClave para activar nueva licencia
            GoTo SinClave
        End If

        ' ============================================================
        ' 5. SI NO HAY NINGUNA LICENCIA - IR A SinClave (ACTIVACIÓN)
        ' ============================================================
        If Valido = 0 Then GoTo SinClave Else Valido = 0

        ' ============================================================
        ' VALIDACIÓN DE FECHA PARA LICENCIAS > 99
        ' ============================================================
        If Licencias > 99 Then
            Dim aa As String
            aa = CFV(Val(n), NuevaCodificacion.ValorStr(EmpNombre), a, b, QueSistema)
            If IsDate(aa) = True Then
                If Licencias > 400 Then
                    If Math.Abs(DateDiff("d", FechaServ, aa)) > 60 Then aa = ""
                    Licencias -= 400
                ElseIf Licencias > 300 Then
                    If Math.Abs(DateDiff("d", FechaServ, aa)) > 30 Then aa = ""
                    Licencias -= 300
                ElseIf Licencias > 200 Then
                    If Math.Abs(DateDiff("d", FechaServ, aa)) > 15 Then aa = ""
                    Licencias -= 200
                Else
                    If Math.Abs(DateDiff("d", FechaServ, aa)) > 8 Then aa = ""
                    Licencias -= 100
                End If
            Else
                aa = ""
            End If
            If aa = "" Then
                Comm.CommandText = "update sys_accesos set idnomopcion = '' where (idusuario = 'Adm' or idusuario = 'Ctrl') "
                Comm.ExecuteNonQuery()
                MsgBox("Su Licencia de acceso al sistema no es válida")
                Return 0
            End If
        End If

        If Licencias > 0 Then Return Licencias

        ' ============================================================
        ' SinClave - ACTIVACIÓN DE LICENCIA
        ' ============================================================
SinClave:
        Dim progin As New IngresaRegistro
        AUX1 = NuevaCodificacion.ClaveParaEnviar(EmpNombre, EmpRuc, n, NombrePcX, V, QueSistema, EmpNombreBase, Now.Date)
        AUX1 = progin.IngresaClave(AUX1)
        If AUX1 = "" Then
            Licencias = 0
            Autorizaciones = Strings.StrDup(35, "0")
        Else
            Licencias = CInt(NuevaCodificacion.DeCodificarLicencia(AUX1, Now.Date, CStr(NuevaCodificacion.ValorStr(EmpNombre)), EmpRuc, n, CStr(NuevaCodificacion.ValorStr(NombrePcX)), CStr(NuevaCodificacion.ValorStr(QueSistema)), Opciones, a, b))
            Autorizaciones = Opciones

            ' ============================================================
            ' VALIDAR QUE LA CLAVE DE CLIENTE NO HAYA SIDO USADA
            ' ============================================================
            If Not String.IsNullOrEmpty(AUX1) Then
                Try
                    ' Verificar si la clave existe en la tabla (ACTIVA O INACTIVA)
                    Dim sqlCheck As String = "SELECT COUNT(*) FROM Licencias WHERE ClaveCliente = @ClaveCliente"
                    Using connCheck As New SqlClient.SqlConnection(datosEmpresa.strConxSyscod)
                        connCheck.Open()
                        Using cmdCheck As New SqlClient.SqlCommand(sqlCheck, connCheck)
                            cmdCheck.Parameters.AddWithValue("@ClaveCliente", AUX1)
                            Dim count As Integer = Convert.ToInt32(cmdCheck.ExecuteScalar())
                            If count > 0 Then
                                ' La clave YA fue usada antes (ACTIVA O INACTIVA)
                                MsgBox("❌ ESTA CLAVE DE CLIENTE YA FUE UTILIZADA" & vbCrLf & vbCrLf &
                           "Clave: " & AUX1 & vbCrLf &
                           "Esta clave ya fue registrada en el sistema." & vbCrLf & vbCrLf &
                           "No se puede generar una nueva licencia con la misma clave." & vbCrLf &
                           "Si necesita una nueva licencia, contacte a su proveedor.",
                           MsgBoxStyle.Exclamation, "Clave Ya Utilizada")
                                Licencias = 0
                                ChequearLicencias = 0
                                Return 0
                            End If
                        End Using
                    End Using
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine($"Error validando clave: {ex.Message}")
                End Try
            End If

            If Licencias > 0 Then

                ' ============================================================
                ' GUARDAR INFORMACIÓN DE LA LICENCIA EN datosEmpresa
                ' ============================================================
                datosEmpresa.TipoLicencia = Licencias
                datosEmpresa.OpcionesLicencia = Opciones
                datosEmpresa.ModulosActivos = Opciones
                datosEmpresa.GruposActivos = DecodificarOpciones(Opciones)

                ' OBTENER FECHA DE EXPIRACIÓN EXCLUSIVAMENTE DE LA TABLA
                Dim fechaDesdeTabla As DateTime = ObtenerFechaExpiracionDesdeTabla(EmpRuc)

                If fechaDesdeTabla <> DateTime.MinValue Then
                    ' USAR LA FECHA DE LA TABLA (LA QUE VIENE DEL GENERADOR)
                    datosEmpresa.FechaExpiracion = fechaDesdeTabla
                Else
                    ' SOLO COMO FALLBACK - NO DEBERÍA SUCEDER
                    datosEmpresa.FechaExpiracion = CalcularFechaExpiracionPorTipo(Licencias)
                End If

                datosEmpresa.MaxUsuarios = ObtenerMaxUsuarios(Licencias)

                ' ============================================================
                ' GUARDAR LICENCIA EN TABLA Licencias (CON LA FECHA OBTENIDA)
                ' ============================================================
                GuardarLicenciaEnTabla(EmpRuc, EmpNombre, Licencias, Opciones, AUX1, datosEmpresa.FechaExpiracion, datosEmpresa.MaxUsuarios)

                ' ============================================================
                ' GUARDAR EN SYS_ACCESOS (ACTIVAR)
                ' ============================================================
                AUX1 = NuevaCodificacion.CodificarLicenciaFinal(Str(Licencias), Opciones, datex, CStr(NuevaCodificacion.ValorStr(EmpNombre)), EmpRuc, n, CStr(NuevaCodificacion.ValorStr(NombrePcX)), CStr(NuevaCodificacion.ValorStr(QueSistema)), a, b)
                Comm.CommandText = "DELETE FROM SYS_ACCESOS where (idusuario = 'Adm' or idusuario = 'Ctrl' or idusuario = 'Sys'  ) and idopcion <> 'mnuoa' and idempresa = 0 and idsistema = '" & QueSistema & "'"
                Comm.ExecuteNonQuery()
                ClaveFinal = Split(AUX1, "-")
                ReDim Preserve ClaveFinal(6)
                AUX1 = " INSERT INTO SYS_ACCESOS ( "
                AUX1 += "idusuario "
                AUX1 += ",idempresa "
                AUX1 += ",idsistema "
                AUX1 += ",Accesos"
                AUX1 += ",IdOpcion"
                AUX1 += ",IdNomOpcion )"
                AUX1 += " VALUES ("
                AUX1 += "'Adm'"
                AUX1 += ",0"
                AUX1 += ",'" & QueSistema & "'"
                AUX1 += ",'" & ClaveFinal(1) & "'"
                AUX1 += ",'" & ClaveFinal(3) & "'"
                AUX1 += ",'" & ClaveFinal(5) & "'"
                AUX1 += ")"
                Comm.CommandText = AUX1
                Comm.ExecuteNonQuery()

                AUX1 = " INSERT INTO SYS_ACCESOS ( "
                AUX1 += "idusuario "
                AUX1 += ",idempresa "
                AUX1 += ",idsistema "
                AUX1 += ",Accesos"
                AUX1 += ",IdOpcion"
                AUX1 += ",IdNomOpcion )"
                AUX1 += " VALUES ("
                AUX1 += "'Ctrl'"
                AUX1 += ",0"
                AUX1 += ",'" & QueSistema & "'"
                AUX1 += ",'" & ClaveFinal(0) & "'"
                AUX1 += ",'" & ClaveFinal(2) & "'"
                AUX1 += ",'" & ClaveFinal(4) & "'"
                AUX1 += ")"
                Comm.CommandText = AUX1
                Comm.ExecuteNonQuery()
            End If
            rsUsr.Close()
            rsEmp.Close()
            Comm.Dispose()
            ConxDaxSys.Dispose()

            If Licencias > 100 Then CF(CStr(Now.Date), Val(n), NuevaCodificacion.ValorStr(EmpNombre), a, b, QueSistema)
            If Licencias > 0 Then cnn(n, NuevaCodificacion.ValorStr(PathServidor), NuevaCodificacion.ValorStr(QueSistema) * CDbl(major), 3, 1, QueSistema)
        End If
        Return Licencias
erroresingresoclave:
        MsgBox("Error registro clave: " & Err.Description & " Nro: " & Err.Number)
        Application.ExitThread()
    End Function

    ' ============================================================
    ' VERIFICAR SI EXISTE LICENCIA ACTIVA Y VIGENTE EN TABLA Licencias
    ' ============================================================
    Private Shared Function VerificarLicenciaActivaYVigenteEnTabla(ruc As String) As Boolean
        Try
            Dim sql As String = "SELECT COUNT(*) FROM Licencias WHERE RucEmpresa = @RucEmpresa AND Estado = 'ACTIVA' AND FechaExpiracion >= GETDATE()"
            Using conn As New SqlClient.SqlConnection(datosEmpresa.strConxSyscod)
                conn.Open()
                Using cmd As New SqlClient.SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@RucEmpresa", ruc)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    Return count > 0
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"Error verificando licencia activa y vigente: {ex.Message}")
            Return False
        End Try
    End Function

    ' ============================================================
    ' ELIMINAR SYS_ACCESOS
    ' ============================================================
    Private Shared Sub EliminarSysAccesos(ConxDaxSys As SqlClient.SqlConnection, QueSistema As String)
        Try
            Dim sqlDeleteSys As String = "
                DELETE FROM SYS_ACCESOS 
                WHERE IdUsuario IN ('Adm', 'Ctrl', 'System') 
                  AND IdEmpresa = 0 
                  AND IdSistema = '" & QueSistema & "'"

            Using cmdDelete As New SqlClient.SqlCommand(sqlDeleteSys, ConxDaxSys)
                Dim rows As Integer = cmdDelete.ExecuteNonQuery()
                System.Diagnostics.Debug.WriteLine($"sys_Accesos eliminados: {rows}")
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"Error eliminando sys_Accesos: {ex.Message}")
        End Try
    End Sub

    ' ============================================================
    ' DESACTIVAR LICENCIA EN TABLA
    ' ============================================================
    Private Shared Sub DesactivarLicencia(ConxDaxSys As SqlClient.SqlConnection, EmpRuc As String)
        Try
            Dim sql As String = "
                UPDATE Licencias 
                SET Estado = 'INACTIVA' 
                WHERE RucEmpresa = @RucEmpresa 
                  AND Estado = 'ACTIVA'"

            Using cmd As New SqlClient.SqlCommand(sql, ConxDaxSys)
                cmd.Parameters.AddWithValue("@RucEmpresa", EmpRuc)
                Dim rows As Integer = cmd.ExecuteNonQuery()
                System.Diagnostics.Debug.WriteLine($"Licencias desactivadas: {rows}")
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"Error desactivando licencia: {ex.Message}")
        End Try
    End Sub

    ' ============================================================
    ' VERIFICAR SI EXISTE LICENCIA INACTIVA EN TABLA Licencias
    ' ============================================================
    Private Shared Function VerificarLicenciaInactivaEnTabla(ruc As String) As Boolean
        Try
            Dim sql As String = "SELECT COUNT(*) FROM Licencias WHERE RucEmpresa = @RucEmpresa AND Estado = 'INACTIVA'"
            Using conn As New SqlClient.SqlConnection(datosEmpresa.strConxSyscod)
                conn.Open()
                Using cmd As New SqlClient.SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@RucEmpresa", ruc)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    Return count > 0
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"Error verificando licencia inactiva: {ex.Message}")
            Return False
        End Try
    End Function

    ' ============================================================
    ' OBTENER FECHA DE EXPIRACIÓN DE LICENCIA INACTIVA
    ' ============================================================
    Private Shared Function ObtenerFechaExpiracionInactiva(ruc As String) As DateTime
        Try
            Dim sql As String = "SELECT TOP 1 FechaExpiracion FROM Licencias WHERE RucEmpresa = @RucEmpresa AND Estado = 'INACTIVA' ORDER BY Id DESC"
            Using conn As New SqlClient.SqlConnection(datosEmpresa.strConxSyscod)
                conn.Open()
                Using cmd As New SqlClient.SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@RucEmpresa", ruc)
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
                        Return Convert.ToDateTime(result)
                    End If
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"Error obteniendo fecha expiración: {ex.Message}")
        End Try
        Return DateTime.Now
    End Function

    ' ============================================================
    ' CARGAR LICENCIA ACTIVA DESDE TABLA Licencias
    ' ============================================================
    Private Class LicenciaInfo
        Public Property TipoLicencia As Integer
        Public Property Opciones As String
        Public Property MaxUsuarios As Integer
        Public Property FechaExpiracion As DateTime
    End Class

    Private Shared Function CargarLicenciaActivaDesdeTabla(ruc As String) As LicenciaInfo
        Try
            Dim sql As String = "SELECT TOP 1 TipoLicencia, ModulosActivos, MaxUsuarios, FechaExpiracion FROM Licencias WHERE RucEmpresa = @RucEmpresa AND Estado = 'ACTIVA' AND FechaExpiracion >= GETDATE() ORDER BY Id DESC"
            Using conn As New SqlClient.SqlConnection(datosEmpresa.strConxSyscod)
                conn.Open()
                Using cmd As New SqlClient.SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@RucEmpresa", ruc)
                    Using reader As SqlClient.SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim info As New LicenciaInfo()
                            info.TipoLicencia = Convert.ToInt32(reader("TipoLicencia"))
                            info.Opciones = reader("ModulosActivos").ToString()
                            info.MaxUsuarios = Convert.ToInt32(reader("MaxUsuarios"))
                            info.FechaExpiracion = Convert.ToDateTime(reader("FechaExpiracion"))
                            Return info
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"Error cargando licencia activa: {ex.Message}")
            Return Nothing
        End Try
    End Function

    ' ============================================================
    ' OBTENER FECHA DE EXPIRACIÓN DESDE TABLA Licencias (NUEVA FUNCIÓN)
    ' ============================================================
    Private Shared Function ObtenerFechaExpiracionDesdeTabla(ruc As String) As DateTime
        Try
            Dim sql As String = "
                SELECT TOP 1 FechaExpiracion 
                FROM Licencias 
                WHERE RucEmpresa = @RucEmpresa 
                  AND Estado = 'ACTIVA' 
                ORDER BY Id DESC"

            Using conn As New SqlClient.SqlConnection(datosEmpresa.strConxSyscod)
                conn.Open()
                Using cmd As New SqlClient.SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@RucEmpresa", ruc)
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
                        Return Convert.ToDateTime(result)
                    End If
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"Error obteniendo fecha expiración desde tabla: {ex.Message}")
        End Try
        Return DateTime.MinValue
    End Function

    ' ============================================================
    ' CALCULAR FECHA DE EXPIRACIÓN POR TIPO (FALLBACK EXTREMO)
    ' ============================================================
    Private Shared Function CalcularFechaExpiracionPorTipo(licencias As Integer) As DateTime
        Try
            ' Intentar obtener fecha del servidor
            Using conn As New SqlClient.SqlConnection(datosEmpresa.strConxSyscod)
                conn.Open()
                Using cmd As New SqlClient.SqlCommand("SELECT GETDATE()", conn)
                    Dim fechaServidor As Object = cmd.ExecuteScalar()
                    If fechaServidor IsNot Nothing AndAlso fechaServidor IsNot DBNull.Value Then
                        Dim fechaBase As DateTime = Convert.ToDateTime(fechaServidor)
                        Return CalcularSegunTipo(licencias, fechaBase)
                    End If
                End Using
            End Using
        Catch
            ' Si todo falla, usar fecha local
            Return CalcularSegunTipo(licencias, DateTime.Now)
        End Try

        Return DateTime.Now.AddDays(30)
    End Function

    ' ============================================================
    ' CALCULAR SEGÚN TIPO DE LICENCIA
    ' ============================================================
    Private Shared Function CalcularSegunTipo(licencias As Integer, fechaBase As DateTime) As DateTime
        Select Case licencias
            Case 98 ' DEMO
                Return fechaBase.AddDays(30)
            Case 1 ' MONO
                Return fechaBase.AddYears(10)
            Case Else ' MULTI
                Return fechaBase.AddYears(10)
        End Select
    End Function

    ' ============================================================
    ' OBTENER POSICIÓN DE UN MÓDULO (PARA TienePermiso)
    ' ============================================================
    Public Shared Function ObtenerPosicionModulo(claveModulo As String) As Integer
        Dim mapaClaves As New Dictionary(Of String, Integer)()

        ' Ventas (Posición 1)
        mapaClaves.Add("PEDEmitir", 1)
        mapaClaves.Add("FACEmitirPed", 1)
        mapaClaves.Add("FACEmitir", 1)
        mapaClaves.Add("FACEmitirPto", 1)
        mapaClaves.Add("ProfEmitir", 1)

        ' Compras (Posición 3)
        mapaClaves.Add("FAPEmitir", 3)
        mapaClaves.Add("NCPEmitir", 3)

        ' Inventarios (Posición 8)
        mapaClaves.Add("MntArticulos", 8)
        mapaClaves.Add("IngInventario", 8)
        mapaClaves.Add("EgrInventario", 8)
        mapaClaves.Add("MovtArticulos", 8)
        mapaClaves.Add("ExisBod", 8)
        mapaClaves.Add("MntMedidas", 8)
        mapaClaves.Add("Recostear", 8)
        mapaClaves.Add("TransferenciaInventarios", 8)
        mapaClaves.Add("REMEmitir", 8)

        ' Directorio (Posición 6)
        mapaClaves.Add("DGRegistros", 6)
        mapaClaves.Add("DGReporteG", 6)

        ' SRI (Posición 5)
        mapaClaves.Add("SolicAutorizaSRI", 5)
        mapaClaves.Add("RTPEmitir", 5)
        mapaClaves.Add("RTCEmitir", 5)
        mapaClaves.Add("MntTablasSRI", 5)
        mapaClaves.Add("importarXML", 5)

        ' Administración (Posición 0)
        mapaClaves.Add("MntDocumentos", 0)
        mapaClaves.Add("MntServiciosBco", 0)
        mapaClaves.Add("MntServiciosCprasVta", 0)
        mapaClaves.Add("MtnUsers", 0)
        mapaClaves.Add("MtnEmpresa", 0)
        mapaClaves.Add("MntFormaPago", 0)

        ' Bancos (Posición 2)
        mapaClaves.Add("DocBancos", 2)
        mapaClaves.Add("MnConciliacionBancos", 2)
        mapaClaves.Add("MnCrearBancos", 2)

        ' Cuentas Corrientes (Posición 5)
        mapaClaves.Add("CtaCorrListaGen", 5)
        mapaClaves.Add("CtaCorrAnalisInd", 5)

        ' Contabilidad (Posición 4)
        mapaClaves.Add("mnplanCuentas", 4)
        mapaClaves.Add("MntBalances", 4)

        ' Importaciones (Posición 7)
        mapaClaves.Add("IMPEmitir", 7)

        ' Reportes (Posición 10)
        mapaClaves.Add("RepListadoDoc", 10)

        ' Ayudas (Posición 1)
        mapaClaves.Add("importarDataCli", 1)
        mapaClaves.Add("importarDataCuentas", 1)
        mapaClaves.Add("importarDataProd", 1)

        ' Auditoria (Posición 0)
        mapaClaves.Add("Auditoria", 0)

        If mapaClaves.ContainsKey(claveModulo) Then
            Return mapaClaves(claveModulo)
        End If

        Return -1
    End Function

    ' ============================================================
    ' DECODIFICAR OPCIONES (string de 35 bits → grupos activos)
    ' ============================================================
    Private Shared Function DecodificarOpciones(opciones As String) As String
        If String.IsNullOrEmpty(opciones) OrElse opciones.Length < 35 Then
            Return ""
        End If

        Dim mapa As Dictionary(Of Integer, String) = ObtenerMapaPosiciones()
        Dim gruposActivos As New List(Of String)()

        For i As Integer = 0 To 34
            If i < opciones.Length AndAlso opciones(i) = "1"c Then
                If mapa.ContainsKey(i) Then
                    gruposActivos.Add(mapa(i))
                End If
            End If
        Next
        Return String.Join(",", gruposActivos)
    End Function

    ' ============================================================
    ' MAPEO DE POSICIONES (DEBE COINCIDIR CON EL GENERADOR)
    ' ============================================================
    Private Shared Function ObtenerMapaPosiciones() As Dictionary(Of Integer, String)
        Dim mapa As New Dictionary(Of Integer, String)()
        mapa.Add(0, "Administración")
        mapa.Add(1, "Ayudas")
        mapa.Add(2, "Bancos")
        mapa.Add(3, "Compras")
        mapa.Add(4, "Contabilidad")
        mapa.Add(5, "Cuentas Corrientes")
        mapa.Add(6, "Directorio")
        mapa.Add(7, "Importaciones")
        mapa.Add(8, "Inventarios")
        mapa.Add(9, "Mantenimiento Documentos")
        mapa.Add(10, "Reportes")
        mapa.Add(11, "SRI")
        mapa.Add(12, "Ventas")
        Return mapa
    End Function

    ' ============================================================
    ' OBTENER MÁXIMO DE USUARIOS SEGÚN TIPO
    ' ============================================================
    Private Shared Function ObtenerMaxUsuarios(licencias As Integer) As Integer
        Select Case licencias
            Case 98 ' DEMO
                Return 5
            Case 1 ' MONO
                Return 1
            Case Else ' MULTI
                Return licencias
        End Select
    End Function

    ' ============================================================
    ' OBTENER CLAVE DE ACTIVACIÓN
    ' ============================================================
    Private Shared Function ObtenerClaveActivacion() As String
        Try
            Dim sql As String = "SELECT TOP 1 ClaveActivacion FROM Licencias WHERE Estado = 'ACTIVA' ORDER BY Id DESC"
            Using conn As New SqlClient.SqlConnection(datosEmpresa.strConxSyscod)
                conn.Open()
                Using cmd As New SqlClient.SqlCommand(sql, conn)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        Return result.ToString()
                    End If
                End Using
            End Using
        Catch
        End Try
        Return "CLAVE-" & Guid.NewGuid().ToString().Substring(0, 8).ToUpper()
    End Function

    ' ============================================================
    ' GUARDAR LICENCIA EN TABLA Licencias
    ' ============================================================
    Private Shared Sub GuardarLicenciaEnTabla(ruc As String, nombre As String, licencias As Integer, opciones As String, claveCliente As String, fechaExpiracion As DateTime, maxUsuarios As Integer)
        Try
            Using conn As New SqlClient.SqlConnection(datosEmpresa.strConxSyscod)
                conn.Open()

                ' 1. Crear tabla si no existe
                Dim sqlCreate As String = "
                    IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Licencias')
                    BEGIN
                        CREATE TABLE Licencias (
                            Id INT IDENTITY(1,1) PRIMARY KEY,
                            RucEmpresa VARCHAR(13) NOT NULL,
                            NombreEmpresa VARCHAR(100),
                            TipoLicencia INT NOT NULL,
                            MaxUsuarios INT NOT NULL,
                            FechaExpiracion DATETIME NOT NULL,
                            ModulosActivos VARCHAR(35) NOT NULL,
                            GruposActivos VARCHAR(500),
                            ClaveCliente VARCHAR(50) NOT NULL,
                            ClaveActivacion VARCHAR(50) NOT NULL,
                            Estado VARCHAR(20) DEFAULT 'ACTIVA',
                            FechaGeneracion DATETIME DEFAULT GETDATE()
                        )
                    END"

                Using cmd As New SqlClient.SqlCommand(sqlCreate, conn)
                    cmd.ExecuteNonQuery()
                End Using

                ' 2. Desactivar licencias anteriores
                Dim sqlDesactivar As String = "
                    UPDATE Licencias 
                    SET Estado = 'INACTIVA' 
                    WHERE RucEmpresa = @RucEmpresa 
                      AND Estado = 'ACTIVA'"

                Using cmd As New SqlClient.SqlCommand(sqlDesactivar, conn)
                    cmd.Parameters.AddWithValue("@RucEmpresa", ruc)
                    cmd.ExecuteNonQuery()
                End Using

                ' 3. Insertar nueva licencia
                Dim gruposActivos As String = DecodificarOpciones(opciones)

                Dim sqlInsert As String = "
                    INSERT INTO Licencias (
                        RucEmpresa, NombreEmpresa, TipoLicencia, MaxUsuarios,
                        ClaveCliente, ClaveActivacion, ModulosActivos, GruposActivos,
                        FechaExpiracion, Estado, FechaGeneracion
                    ) VALUES (
                        @RucEmpresa, @NombreEmpresa, @TipoLicencia, @MaxUsuarios,
                        @ClaveCliente, @ClaveActivacion, @ModulosActivos, @GruposActivos,
                        @FechaExpiracion, 'ACTIVA', GETDATE()
                    )"

                Using cmd As New SqlClient.SqlCommand(sqlInsert, conn)
                    cmd.Parameters.AddWithValue("@RucEmpresa", ruc)
                    cmd.Parameters.Add(New SqlClient.SqlParameter("@NombreEmpresa", SqlDbType.VarChar, 100) With {.Value = If(String.IsNullOrEmpty(nombre), DBNull.Value, DirectCast(nombre, Object))})
                    cmd.Parameters.AddWithValue("@TipoLicencia", licencias)
                    cmd.Parameters.AddWithValue("@MaxUsuarios", maxUsuarios)
                    cmd.Parameters.AddWithValue("@ClaveCliente", claveCliente)
                    cmd.Parameters.AddWithValue("@ClaveActivacion", ObtenerClaveActivacion())
                    cmd.Parameters.AddWithValue("@ModulosActivos", opciones)
                    cmd.Parameters.Add(New SqlClient.SqlParameter("@GruposActivos", SqlDbType.VarChar, 500) With {.Value = If(String.IsNullOrEmpty(gruposActivos), DBNull.Value, DirectCast(gruposActivos, Object))})
                    cmd.Parameters.AddWithValue("@FechaExpiracion", fechaExpiracion)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"Error guardando licencia: {ex.Message}")
        End Try
    End Sub

    ' ============================================================
    ' FUNCIONES EXISTENTES (NO TOCAR)
    ' ============================================================

    Private Shared Function CR(ByVal TEXTO As String) As String
        Dim i As Integer, b As String, bb As String
        Dim TexTot As String, Texto2 As String

        TexTot = TEXTO
        i = Len(TexTot)
        Texto2 = ""
        For i = 1 To i Step 2
            b = CStr(Val(Mid$(TexTot, i, 2)))
            If CDbl(b) < 91 And CDbl(b) > 64 Then
                bb = Chr(CInt(b))
            ElseIf CDbl(b) + 97 < 123 Then
                bb = Chr(CInt(CDbl(b) + 97))
            Else
                bb = Mid$(TexTot, i, 2)
            End If
            Texto2 += bb
        Next i
        CR = Texto2
    End Function

    Private Shared Function DCR(ByVal TEXTO As String) As String
        Dim i As Integer, m As Byte, bb As String
        Dim Texto2 As String
        Texto2 = ""
        For i = 1 To Len(TEXTO)
            bb = Mid$(TEXTO, i, 1)
            m = CByte(Asc(bb))
            If m > 64 And m < 91 Then
                bb = CStr(m)
            ElseIf m > 96 And m < 123 Then
                bb = CStr(m - 97)
                If Len(bb) < 2 Then bb = Mid$("00", 1, 2 - Len(bb)) & bb
            End If
            Texto2 += bb
        Next i
        Texto2 = Trim(Texto2)
        DCR = Texto2
    End Function

    Public Shared Function CFV(ByVal n As Double, ByVal S As Double, ByVal a As Integer, ByVal b As Integer, Sistema As String) As String
        Dim sSQL As String
        Dim V1 As Long
        Dim V2 As Long
        Dim rs As SqlClient.SqlDataReader
        Dim ConxDaxSys As New SqlClient.SqlConnection(datosEmpresa.strConxSyscod)
        ConxDaxSys.Open()
        sSQL = " where "
        sSQL += " idusuario = 'System' "
        sSQL &= " and IdEmpresa = 0 "
        sSQL &= " and SUBSTRING (IDOPCION,1,4) <> 'mnuo' "
        sSQL &= " and IdSistema = '" & Sistema & "'"

        CFV = ""
        Dim Comm As New SqlClient.SqlCommand("Select * from sys_accesos " & sSQL, ConxDaxSys)
        rs = Comm.ExecuteReader
        If rs.Read = True Then
            CFV = rs.Item("IdOpcion").ToString() & rs.Item("Accesos").ToString() & rs.Item("IdNomOpcion").ToString()
            rs.Close()
            rs = Nothing
            CFV = DCR(CFV)
            V2 = CLng(Left(CFV, 12))
            V1 = CLng(Mid(CFV, 13, 12))

            V2 = CLng(V2 - (Val(StrReverse(CStr(Int(S)))) * a))
            V2 = CLng(V2 / b)

            V1 = CLng(V1 - (n * b))
            V1 = CLng(V1 / a)
            V1 = CLng(Val(StrReverse(Mid(CStr(V1), 2))))
            If V1 = V2 Then CFV = Mid(CStr(V1), 1, 2) & "/" & Mid(CStr(V1), 3, 2) & "/" & Mid(CStr(V1), 5, 4) Else CFV = ""
        End If
        rs = Nothing
        ConxDaxSys.Dispose()
        Comm.Dispose()
    End Function

    Public Shared Sub CF(ByVal f As String, ByVal n As Double, ByVal S As Double, ByVal a As Integer, ByVal b As Integer, sistema As String)
        Dim V1 As Long
        Dim V2 As Long
        Dim T As String
        Dim V3 As String
        Dim ConxDaxSys As New SqlClient.SqlConnection(datosEmpresa.strConxSyscod)
        ConxDaxSys.Open()
        Dim sSQL As String = ""
        Dim Aux1 As String = ""
        Dim FF As String
        FF = Mid(f, 1, 2) & Mid(f, 4, 2) & Mid(f, 7, 4)
        V1 = CLng((Val("1" & StrReverse(FF)) * a) + (n * b))
        V2 = CLng((Val(FF) * b) + (Val(StrReverse(CStr(Int(S)))) * a))
        T = Right(Strings.StrDup(12, "0") & Trim(Str(V2)), 12) & Right(Strings.StrDup(12, "0") & Trim(Str(V1)), 12)
        V3 = CR(T)

        sSQL = " where "
        sSQL &= " idusuario = 'System' "
        sSQL &= " and IdEmpresa = 0 "
        sSQL &= " and SUBSTRING (IDOPCION,1,4) <> 'mnuo' "
        sSQL &= " and IdSistema = '" & sistema & "'"

        Dim comm As New SqlClient.SqlCommand("delete from sys_accesos " & sSQL, ConxDaxSys)
        comm.ExecuteNonQuery()
        Aux1 = " INSERT INTO SYS_ACCESOS ( "
        Aux1 += "idusuario "
        Aux1 += ",idempresa "
        Aux1 += ",idsistema "
        Aux1 += ",Accesos"
        Aux1 += ",IdOpcion"
        Aux1 += ",IdNomOpcion )"
        Aux1 += " VALUES ("
        Aux1 += "'System'"
        Aux1 += ",0"
        Aux1 += ",'" & sistema & "'"
        Aux1 += ",'" & Mid(V3, 6, 5) & "'"
        Aux1 += ",'" & Left(V3, 5) & "'"
        Aux1 += ",'" & Mid(V3, 11) & "'"
        Aux1 += ")"
        comm.CommandText = Aux1
        comm.ExecuteNonQuery()
        comm.Dispose()
        ConxDaxSys.Dispose()
    End Sub

    Public Shared Function CNNV(ByVal n As Double, ByVal S As Double, ByVal a As Integer, ByVal b As Integer, sistema As String) As String
        Dim sSQL As String
        Dim V1 As Long
        Dim V2 As Long
        Dim rs As SqlClient.SqlDataReader
        Dim ConxDaxSys As New SqlClient.SqlConnection(datosEmpresa.strConxSyscod)
        ConxDaxSys.Open()
        sSQL = " where "
        sSQL += " idusuario = 'Sys' "
        sSQL += " and IdEmpresa = 0 "
        sSQL += " and SUBSTRING (IDOPCION,1,4) <> 'mnuo' "
        sSQL += " and IdSistema = '" & sistema & "'"

        CNNV = ""

        Dim comm As New SqlClient.SqlCommand("Select * from sys_accesos " & sSQL, ConxDaxSys)
        rs = comm.ExecuteReader
        If rs.Read = True Then
            CNNV = CStr(rs.Item("IdNomOpcion"))
            rs.Close()
            rs = Nothing
            CNNV = DCR(CNNV)
            V2 = CLng(Left(CNNV, 12))
            V1 = CLng(Mid(CNNV, 13, 12))

            V2 = CLng(Val(V2) - (Val(StrReverse(CStr(S))) * a))
            V2 = CLng(Val(V2) / b)

            V1 = CLng(Val(V1) - (n * b))
            V1 = CLng(Val(V1) / a)
            V1 = CLng(StrReverse(Mid(CStr(V1), 2)))
            If V1 = V2 Then CNNV = CStr(V2) Else CNNV = CStr(V1)
        End If
        rs = Nothing
        comm.Dispose()
        ConxDaxSys.Dispose()
    End Function

    Public Shared Sub cnn(ByVal f As String, ByVal n As Double, ByVal S As Double, ByVal a As Integer, ByVal b As Integer, sistema As String)
        Dim V1 As Long
        Dim V2 As Long
        Dim T As String
        Dim V3 As String
        Dim sSQL As String
        Dim FF As String
        Dim Aux1 As String
        Dim ConxDaxSys As New SqlClient.SqlConnection(datosEmpresa.strConxSyscod)
        ConxDaxSys.Open()

        FF = f
        V1 = CLng((Val("1" & StrReverse(FF)) * a) + (n * b))
        V2 = CLng((Val(FF) * b) + (Val(StrReverse(CStr(S))) * a))
        T = Right(Strings.StrDup(12, "0") & Trim(Str(V2)), 12) & Right(Strings.StrDup(12, "0") & Trim(Str(V1)), 12)
        V3 = CR(T)

        sSQL = " where "
        sSQL += " idusuario = 'Sys' "
        sSQL += " and IdEmpresa = 0 "
        sSQL += " and SUBSTRING (IDOPCION,1,4) <> 'mnuo' "
        sSQL += " and IdSistema = '" & sistema & "'"

        Dim comm As New SqlClient.SqlCommand("delete from sys_accesos " & sSQL, ConxDaxSys)
        comm.ExecuteNonQuery()
        Aux1 = " INSERT INTO SYS_ACCESOS ( "
        Aux1 += "idusuario "
        Aux1 += ",idempresa "
        Aux1 += ",idsistema "
        Aux1 += ",Accesos"
        Aux1 += ",IdOpcion"
        Aux1 += ",IdNomOpcion )"
        Aux1 += " VALUES ("
        Aux1 += "'Sys'"
        Aux1 += ",0"
        Aux1 += ",'" & sistema & "'"
        Aux1 += ",''"
        Aux1 += ",''"
        Aux1 += ",'" & V3 & "'"
        Aux1 += ")"
        comm.CommandText = Aux1
        comm.ExecuteNonQuery()
        comm.Dispose()
        ConxDaxSys.Dispose()
    End Sub

End Class