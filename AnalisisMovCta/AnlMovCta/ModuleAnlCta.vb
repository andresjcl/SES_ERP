Imports System.Data
Imports System.Data.SqlClient
Imports DattCom

<System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes")>
<System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1824:MarkAssembliesWithNeutralResourcesLanguage")>
<System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA2210:AssembliesShouldHaveValidStrongNames")>
<System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1014:MarkAssembliesWithClsCompliant")>
Module ModuleAnlCta
    Public conectar As New SqlConnection()
    Public conectarSys As New SqlConnection()

    ' El campo strcon se mantiene solo para compatibilidad
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>
    Private strcon As String = ""

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters")>
    Public Sub conectarBDD()
        Try
            If datosEmpresa.Emp_codigo = 0 Then
                MessageBox.Show("No se ha conectado al servidor AdcomDx", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            strcon = datosEmpresa.strConxAdcom
            conectarSys.ConnectionString = datosEmpresa.strConIniSis
        Catch ex As SqlException
            MessageBox.Show("Error de SQL al conectar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error al conectar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")>
    Public Sub cerrarConeccion()
        Try
            If conectar IsNot Nothing AndAlso conectar.State = ConnectionState.Open Then
                conectar.Close()
                conectar.Dispose()
            End If
            If conectarSys IsNot Nothing AndAlso conectarSys.State = ConnectionState.Open Then
                conectarSys.Close()
                conectarSys.Dispose()
            End If
        Catch ex As Exception
            ' Ignorar errores al cerrar conexiones
        End Try
    End Sub

    ''' <summary>
    ''' Ejecuta un comando SQL sin parámetros (NO RECOMENDADO para datos de usuario)
    ''' </summary>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters")>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:ReviewSqlQueriesForSecurityVulnerabilities")>
    Public Sub EjecutarComandos(ByVal comando As String)
        If String.IsNullOrEmpty(comando) Then Exit Sub

        Using cmd As New SqlCommand(comando, conectar)
            Try
                If conectar.State = ConnectionState.Closed Then
                    conectar.Open()
                End If
                cmd.ExecuteNonQuery()
            Catch ex As SqlException
                MessageBox.Show("Error de SQL: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As InvalidOperationException
                MessageBox.Show("Error de operación: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Error al ejecutar comando: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If conectar.State = ConnectionState.Open Then
                    conectar.Close()
                End If
            End Try
        End Using
    End Sub

    ''' <summary>
    ''' Ejecuta un comando SQL con parámetros (RECOMENDADO)
    ''' </summary>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters")>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:ReviewSqlQueriesForSecurityVulnerabilities")>
    Public Sub EjecutarComandoParametrizado(ByVal comando As String, ParamArray parametros() As SqlParameter)
        If String.IsNullOrEmpty(comando) Then Exit Sub

        Using cmd As New SqlCommand(comando, conectar)
            Try
                ' Agregar parámetros si existen
                If parametros IsNot Nothing AndAlso parametros.Length > 0 Then
                    cmd.Parameters.AddRange(parametros)
                End If

                If conectar.State = ConnectionState.Closed Then
                    conectar.Open()
                End If
                cmd.ExecuteNonQuery()
            Catch ex As SqlException
                MessageBox.Show("Error de SQL: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As InvalidOperationException
                MessageBox.Show("Error de operación: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Error al ejecutar comando: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If conectar.State = ConnectionState.Open Then
                    conectar.Close()
                End If
            End Try
        End Using
    End Sub

    ''' <summary>
    ''' Ejecuta una consulta SQL y devuelve un DataTable
    ''' </summary>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters")>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1306:SetLocaleForDataTypes")>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope")>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:ReviewSqlQueriesForSecurityVulnerabilities")>
    Public Function EjecutarConsulta(ByVal comando As String) As DataTable
        Dim dt As DataTable = Nothing

        If String.IsNullOrEmpty(comando) Then Return New DataTable()

        dt = New DataTable()

        Using cmd As New SqlCommand(comando, conectar)
            Using da As New SqlDataAdapter(cmd)
                Try
                    If conectar.State = ConnectionState.Closed Then
                        conectar.Open()
                    End If
                    da.Fill(dt)
                Catch ex As SqlException
                    MessageBox.Show("Error de SQL en consulta: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dt = Nothing
                Catch ex As InvalidOperationException
                    MessageBox.Show("Error de operación: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dt = Nothing
                Catch ex As Exception
                    MessageBox.Show("Error al ejecutar consulta: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dt = Nothing
                Finally
                    If conectar.State = ConnectionState.Open Then
                        conectar.Close()
                    End If
                End Try
            End Using
        End Using

        Return If(dt Is Nothing, New DataTable(), dt)
    End Function

    ''' <summary>
    ''' Ejecuta un procedimiento almacenado y devuelve un DataTable
    ''' </summary>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters")>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1306:SetLocaleForDataTypes")>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope")>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:ReviewSqlQueriesForSecurityVulnerabilities")>
    Public Function EjecutarSP(ByVal nombreSP As String, ParamArray parametros() As SqlParameter) As DataTable
        Dim dt As DataTable = Nothing

        If String.IsNullOrEmpty(nombreSP) Then Return New DataTable()

        dt = New DataTable()

        Using cmd As New SqlCommand(nombreSP, conectar)
            cmd.CommandType = CommandType.StoredProcedure

            If parametros IsNot Nothing AndAlso parametros.Length > 0 Then
                cmd.Parameters.AddRange(parametros)
            End If

            Using da As New SqlDataAdapter(cmd)
                Try
                    If conectar.State = ConnectionState.Closed Then
                        conectar.Open()
                    End If
                    da.Fill(dt)
                Catch ex As SqlException
                    MessageBox.Show("Error de SQL en SP: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dt = Nothing
                Catch ex As InvalidOperationException
                    MessageBox.Show("Error de operación: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dt = Nothing
                Catch ex As Exception
                    MessageBox.Show("Error al ejecutar procedimiento: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    dt = Nothing
                Finally
                    If conectar.State = ConnectionState.Open Then
                        conectar.Close()
                    End If
                End Try
            End Using
        End Using

        Return If(dt Is Nothing, New DataTable(), dt)
    End Function

    ''' <summary>
    ''' Ejecuta un procedimiento almacenado que devuelve un solo valor (Scalar)
    ''' </summary>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters")>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:ReviewSqlQueriesForSecurityVulnerabilities")>
    Public Function EjecutarScalarSP(ByVal nombreSP As String, ParamArray parametros() As SqlParameter) As Object
        Dim resultado As Object = Nothing

        If String.IsNullOrEmpty(nombreSP) Then Return resultado

        Using cmd As New SqlCommand(nombreSP, conectar)
            cmd.CommandType = CommandType.StoredProcedure

            If parametros IsNot Nothing AndAlso parametros.Length > 0 Then
                cmd.Parameters.AddRange(parametros)
            End If

            Try
                If conectar.State = ConnectionState.Closed Then
                    conectar.Open()
                End If
                resultado = cmd.ExecuteScalar()
            Catch ex As SqlException
                MessageBox.Show("Error de SQL en SP Scalar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Error al ejecutar procedimiento: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If conectar.State = ConnectionState.Open Then
                    conectar.Close()
                End If
            End Try
        End Using

        Return resultado
    End Function
End Module