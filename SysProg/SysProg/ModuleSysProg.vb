Imports System.Data.SqlClient
Module ModuleSysProg
    Public StrCon As New SqlConnection()
    'Public usr As New DaxUsr.DaxsofUsr

    Public Sub EjecutarComnados(ByVal comando As String)
        Dim con As New SqlConnection()
        con = StrCon
        Dim cmd As New SqlCommand(comando, con)
        con.Open()
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        con.Close()
        con.Dispose()

    End Sub
End Module
