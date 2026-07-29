Option Strict On
Option Explicit On

Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports DattCom

Public Class ClasificaCtb

    ' ✅ CARGAR TODOS LOS CLASIFICADORES ACTIVOS
    Public Function Cargar() As ColClasificador
        Dim RsAux As SqlDataReader = Nothing
        Dim CargarAux As New ColClasificador()

        Try
            Using ConxAdcom As New SqlConnection(datosEmpresa.strConxAdcom)
                ConxAdcom.Open()

                ' ✅ SOLO CLASIFICADORES ACTIVOS (Status = 1) y EsClasificador = 1
                Dim comm As New SqlCommand(
                    "SELECT IDCLAVE, Status, origenvalores, campodia, campotra, " &
                    "regPorConcepto, Nombre, Descripción, TipoDirectorio, GrupoDirectorio " &
                    "FROM AdcClasfctb WHERE Status = 1 AND EsClasificador = 1 ORDER BY Nombre",
                    ConxAdcom)

                RsAux = comm.ExecuteReader()

                With RsAux
                    Do While .Read()
                        Dim Elclasificador As New Clasificador()
                        Elclasificador.IDCLAVE = Convert.ToInt32(.Item("IDCLAVE"))
                        Elclasificador.Status = Convert.ToBoolean(.Item("Status"))
                        Elclasificador.OrigenValores = .Item("origenvalores").ToString()
                        Elclasificador.CampoDia = .Item("campodia").ToString()
                        Elclasificador.CampoTra = .Item("campotra").ToString()
                        Elclasificador.RegPorConcepto = Convert.ToBoolean(.Item("regPorConcepto"))
                        Elclasificador.Nombre = .Item("Nombre").ToString()
                        Elclasificador.Descripcion = .Item("Descripción").ToString()
                        Elclasificador.TipoDirectorio = .Item("TipoDirectorio").ToString()
                        Elclasificador.GrupoDirectorio = .Item("GrupoDirectorio").ToString()
                        Elclasificador.Clave = "C" & .Item("Nombre").ToString()

                        CargarAux.Add(Elclasificador)
                    Loop
                End With
            End Using

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"Error cargando clasificadores: {ex.Message}")
            Throw New Exception($"Error al cargar clasificadores: {ex.Message}", ex)
        Finally
            If RsAux IsNot Nothing AndAlso Not RsAux.IsClosed Then
                RsAux.Close()
            End If
            RsAux = Nothing
        End Try

        Return CargarAux
    End Function

    ' ✅ CARGAR CLASIFICADORES POR IDCLAVE
    Public Function CargarPorIDCLAVE(ByVal idClave As Integer) As Clasificador
        Dim RsAux As SqlDataReader = Nothing
        Dim resultado As Clasificador = Nothing

        Try
            Using ConxAdcom As New SqlConnection(datosEmpresa.strConxAdcom)
                ConxAdcom.Open()

                Dim comm As New SqlCommand(
                    "SELECT IDCLAVE, Status, origenvalores, campodia, campotra, " &
                    "regPorConcepto, Nombre, Descripción, TipoDirectorio, GrupoDirectorio " &
                    "FROM AdcClasfctb WHERE IDCLAVE = @IDCLAVE AND Status = 1 AND EsClasificador = 1",
                    ConxAdcom)
                comm.Parameters.AddWithValue("@IDCLAVE", idClave)

                RsAux = comm.ExecuteReader()

                If RsAux.Read() Then
                    resultado = New Clasificador()
                    resultado.IDCLAVE = Convert.ToInt32(RsAux("IDCLAVE"))
                    resultado.Status = Convert.ToBoolean(RsAux("Status"))
                    resultado.OrigenValores = RsAux("origenvalores").ToString()
                    resultado.CampoDia = RsAux("campodia").ToString()
                    resultado.CampoTra = RsAux("campotra").ToString()
                    resultado.RegPorConcepto = Convert.ToBoolean(RsAux("regPorConcepto"))
                    resultado.Nombre = RsAux("Nombre").ToString()
                    resultado.Descripcion = RsAux("Descripción").ToString()
                    resultado.TipoDirectorio = RsAux("TipoDirectorio").ToString()
                    resultado.GrupoDirectorio = RsAux("GrupoDirectorio").ToString()
                    resultado.Clave = "C" & RsAux("Nombre").ToString()
                End If
            End Using

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"Error cargando clasificador por ID: {ex.Message}")
            Throw
        Finally
            If RsAux IsNot Nothing AndAlso Not RsAux.IsClosed Then
                RsAux.Close()
            End If
            RsAux = Nothing
        End Try

        Return resultado
    End Function

    ' ✅ VERIFICAR SI UN NOMBRE ES CLASIFICADOR
    Public Function EsClasificador(ByVal nombre As String) As Boolean
        Dim resultado As Boolean = False

        Try
            Using ConxAdcom As New SqlConnection(datosEmpresa.strConxAdcom)
                ConxAdcom.Open()

                Dim comm As New SqlCommand(
                    "SELECT COUNT(*) FROM AdcClasfctb " &
                    "WHERE Nombre = @Nombre AND Status = 1 AND EsClasificador = 1",
                    ConxAdcom)
                comm.Parameters.AddWithValue("@Nombre", nombre)

                Dim count As Integer = Convert.ToInt32(comm.ExecuteScalar())
                resultado = (count > 0)
            End Using

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"Error verificando clasificador: {ex.Message}")
        End Try

        Return resultado
    End Function

    ' ✅ OBTENER LISTA DE NOMBRES DE CLASIFICADORES
    Public Function GetNombresClasificadores() As List(Of String)
        Dim nombres As New List(Of String)()

        Try
            Using ConxAdcom As New SqlConnection(datosEmpresa.strConxAdcom)
                ConxAdcom.Open()

                Dim comm As New SqlCommand(
                    "SELECT Nombre FROM AdcClasfctb " &
                    "WHERE Status = 1 AND EsClasificador = 1 ORDER BY Nombre",
                    ConxAdcom)

                Using RsAux As SqlDataReader = comm.ExecuteReader()
                    While RsAux.Read()
                        nombres.Add(RsAux("Nombre").ToString())
                    End While
                End Using
            End Using

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"Error obteniendo nombres: {ex.Message}")
        End Try

        Return nombres
    End Function
End Class