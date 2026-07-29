' ============================================================
' ModulosMapping.vb - Mapeo dinámico desde MenuSES
' ============================================================

Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient

Namespace Defctrlclving

    Public Class ModulosMapping

        ' Diccionarios en memoria
        Private Shared _clavePosicion As New Dictionary(Of String, Integer)()
        Private Shared _claveGrupo As New Dictionary(Of String, String)()
        Private Shared _posicionGrupo As New Dictionary(Of Integer, String)()
        Private Shared _modulosPorGrupo As New Dictionary(Of String, List(Of String))()
        Private Shared _ultimaActualizacion As DateTime = DateTime.MinValue
        Private Shared ReadOnly _lock As New Object()

        Public Shared Sub CargarMapping(cadenaConexion As String)
            SyncLock _lock
                Try
                    ' Solo cargar si ha pasado más de 5 minutos
                    If (DateTime.Now - _ultimaActualizacion).TotalMinutes < 5 AndAlso _clavePosicion.Count > 0 Then
                        Return
                    End If

                    Using conn As New SqlConnection(cadenaConexion)
                        conn.Open()
                        Dim sql As String = "
                            SELECT 
                                Clave,
                                Descripcion,
                                Menuprincipal AS Grupo,
                                orden
                            FROM MenuSES
                            WHERE Clave IS NOT NULL 
                              AND Clave != ''
                              AND Menuprincipal IS NOT NULL
                              AND Menuprincipal != ''
                            ORDER BY Menuprincipal, orden"

                        Using cmd As New SqlCommand(sql, conn)
                            Using reader As SqlDataReader = cmd.ExecuteReader()
                                ' Limpiar diccionarios
                                _clavePosicion.Clear()
                                _claveGrupo.Clear()
                                _posicionGrupo.Clear()
                                _modulosPorGrupo.Clear()

                                Dim grupoPosicion As New Dictionary(Of String, Integer)()
                                Dim posicionGlobal As Integer = 0

                                While reader.Read()
                                    Dim clave As String = reader("Clave").ToString()
                                    Dim grupo As String = reader("Grupo").ToString()

                                    If Not grupoPosicion.ContainsKey(grupo) Then
                                        grupoPosicion(grupo) = posicionGlobal
                                        posicionGlobal += 1
                                        _posicionGrupo(grupoPosicion(grupo)) = grupo
                                        _modulosPorGrupo(grupo) = New List(Of String)()
                                    End If

                                    Dim posicion As Integer = grupoPosicion(grupo)
                                    _clavePosicion(clave) = posicion
                                    _claveGrupo(clave) = grupo
                                    _modulosPorGrupo(grupo).Add(clave)
                                End While
                            End Using
                        End Using
                    End Using

                    _ultimaActualizacion = DateTime.Now
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine($"Error cargando mapping: {ex.Message}")
                End Try
            End SyncLock
        End Sub

        Public Shared Function ObtenerPosicion(claveModulo As String, cadenaConexion As String) As Integer
            If _clavePosicion.Count = 0 Then
                CargarMapping(cadenaConexion)
            End If

            If _clavePosicion.ContainsKey(claveModulo) Then
                Return _clavePosicion(claveModulo)
            End If

            Return -1
        End Function

        Public Shared Function ObtenerGrupo(claveModulo As String, cadenaConexion As String) As String
            If _claveGrupo.Count = 0 Then
                CargarMapping(cadenaConexion)
            End If

            If _claveGrupo.ContainsKey(claveModulo) Then
                Return _claveGrupo(claveModulo)
            End If

            Return ""
        End Function

        Public Shared Function ObtenerGrupos(cadenaConexion As String) As List(Of String)
            If _modulosPorGrupo.Count = 0 Then
                CargarMapping(cadenaConexion)
            End If

            Return New List(Of String)(_modulosPorGrupo.Keys)
        End Function

        Public Shared Function ObtenerModulosPorGrupo(grupo As String, cadenaConexion As String) As List(Of String)
            If _modulosPorGrupo.Count = 0 Then
                CargarMapping(cadenaConexion)
            End If

            If _modulosPorGrupo.ContainsKey(grupo) Then
                Return _modulosPorGrupo(grupo)
            End If

            Return New List(Of String)()
        End Function

        Public Shared Function ConstruirOpciones(gruposSeleccionados As List(Of String), cadenaConexion As String) As String
            If _posicionGrupo.Count = 0 Then
                CargarMapping(cadenaConexion)
            End If

            Dim opciones As Char() = New Char(34) {}
            For i As Integer = 0 To 34
                opciones(i) = "0"c
            Next

            For Each grupo As String In gruposSeleccionados
                For Each pos As KeyValuePair(Of Integer, String) In _posicionGrupo
                    If pos.Value = grupo AndAlso pos.Key < 35 Then
                        opciones(pos.Key) = "1"c
                        Exit For
                    End If
                Next
            Next

            Return New String(opciones)
        End Function

        Public Shared Function DecodificarOpciones(opciones As String, cadenaConexion As String) As List(Of String)
            If _posicionGrupo.Count = 0 Then
                CargarMapping(cadenaConexion)
            End If

            Dim gruposActivos As New List(Of String)()

            For i As Integer = 0 To opciones.Length - 1
                If i >= 35 Then Exit For
                If opciones(i) = "1"c AndAlso _posicionGrupo.ContainsKey(i) Then
                    gruposActivos.Add(_posicionGrupo(i))
                End If
            Next

            Return gruposActivos
        End Function

        Public Shared Sub ForzarActualizacion(cadenaConexion As String)
            _ultimaActualizacion = DateTime.MinValue
            CargarMapping(cadenaConexion)
        End Sub

    End Class

End Namespace