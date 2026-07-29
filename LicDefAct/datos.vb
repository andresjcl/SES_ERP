Imports System.Data.SqlClient
Imports DattCom

Namespace DattCom

    Public Class datosEmpresa

        ' ============================================================
        ' PROPIEDADES EXISTENTES (las que ya tenías)
        ' ============================================================
        Public Shared strConIniSis As String = ""
        Public Shared strConxSyscod As String = ""
        Public Shared strConxAdcom As String = ""
        Public Shared usr As String = ""
        Public Shared Emp_codigo As Integer = 0
        Public Shared Emp_Nombre As String = ""
        Public Shared Emp_RUC As String = ""
        Public Shared auto As String = ""
        Public Shared pathServer As String = ""
        Public Shared pathAppl As String = ""
        Public Shared sistema As String = ""
        Public Shared Major As Integer = 0
        Public Shared SucursalNombre As String = ""
        Public Shared suc As String = ""
        Public Shared sucNom As String = ""
        Public Shared nomEmpresa As String = ""

        ' ============================================================
        ' NUEVAS PROPIEDADES PARA LICENCIA
        ' ============================================================
        Public Shared TipoLicencia As Integer = 0
        Public Shared OpcionesLicencia As String = ""
        Public Shared ModulosActivos As String = ""
        Public Shared GruposActivos As String = ""
        Public Shared MaxUsuarios As Integer = 1
        Public Shared FechaExpiracion As DateTime = DateTime.MaxValue

        ' ============================================================
        ' FUNCIÓN PARA VERIFICAR PERMISO DE MÓDULO
        ' ============================================================
        Public Shared Function TienePermiso(claveModulo As String) As Boolean
            ' Si es administrador, siempre tiene permiso
            If usr.ToUpper() = "ADMINISTRADOR" OrElse usr.ToUpper() = "ADMIN" Then
                Return True
            End If

            ' Si es MONO (1), siempre tiene permiso
            If TipoLicencia = 1 Then
                Return True
            End If

            ' Si es DEMO (98), verificar grupos permitidos
            If TipoLicencia = 98 Then
                Dim gruposDemo As String() = {"Ventas", "Inventarios", "Directorio"}
                Dim grupoModulo As String = ObtenerGrupoModulo(claveModulo)
                For Each g As String In gruposDemo
                    If g = grupoModulo Then Return True
                Next
                Return False
            End If

            ' Si es MULTI (99+), verificar en GruposActivos
            If TipoLicencia >= 99 Then
                If String.IsNullOrEmpty(GruposActivos) Then Return False
                Dim grupoModulo As String = ObtenerGrupoModulo(claveModulo)
                Return GruposActivos.Contains(grupoModulo)
            End If

            Return False
        End Function

        ' ============================================================
        ' OBTENER GRUPO DE UN MÓDULO DESDE MenuSES
        ' ============================================================
        Private Shared Function ObtenerGrupoModulo(claveModulo As String) As String
            Try
                Dim sql As String = $"SELECT Menuprincipal FROM MenuSES WHERE Clave = '{claveModulo}'"
                Dim dt As DataTable = SqlDatos.leerTabla(sql, strConxSyscod)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    Return dt.Rows(0)("Menuprincipal").ToString()
                End If
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine($"Error obteniendo grupo: {ex.Message}")
            End Try
            Return ""
        End Function

    End Class

End Namespace