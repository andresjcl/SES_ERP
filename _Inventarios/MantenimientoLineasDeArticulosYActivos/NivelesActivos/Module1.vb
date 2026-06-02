Imports System.Data.SqlClient
Imports DattCom

Module Module1
    Public Sub actualizaNandinaHts(nivel As Integer)

        Dim conn As New SqlConnection(datosEmpresa.strConxAdcom)
        If (conn.State = ConnectionState.Closed) Then conn.Open()
        Dim comm As New SqlCommand("DaxActArtNan " + nivel.ToString, conn)
        comm.ExecuteNonQuery()
        conn.Close()
        conn.Dispose()
        comm.Dispose()
    End Sub


End Module
