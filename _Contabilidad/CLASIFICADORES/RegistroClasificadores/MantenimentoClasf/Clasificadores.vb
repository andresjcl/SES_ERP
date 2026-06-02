Imports System.Data.SqlClient

Public Class Clasificadores
    Public TipoReferencia As String = ""
    Public Abreviación As String = ""
    Public Descripcion As String = ""
    Public Caracteristica1 As String = ""
    Public Caracteristica2 As String = ""
    Public Caracteristica3 As String = ""
    Public Caracteristica4 As String = ""
    Public Caracteristica5 As String = ""
    Public Clave As String = ""
    Public Tipo1 As String = ""
    Public Tipo2 As String = ""
    Public Tipo3 As String = ""
    Public Tipo4 As Integer = 0
    Public Tipo5 As Integer = 0
    Public longitud1 As Integer = 0
    Public longitud2 As Integer = 0
    Public longitud3 As Integer = 0
    Public longitud4 As Integer = 0
    Public longitud5 As Integer = 0
    Public decimales1 As Integer = 0
    Public decimales2 As Integer = 0
    Public decimales3 As Integer = 0
    Public decimales4 As Integer = 0
    Public decimales5 As Integer = 0
    Dim ssql As String = ""
    Dim conectaSys As New SqlConnection()

    Public Sub Guardar(ByVal StrSys As String)
        ssql = "insert into Syscod("
        ssql += "TipoReferencia ,"
        ssql += "Abreviación ,"
        ssql += "Descripcion ,"
        ssql += "Caracteristica1 ,"
        ssql += "Caracteristica2 ,"
        ssql += "Caracteristica3 ,"
        ssql += "Caracteristica4 ,"
        ssql += "Caracteristica5 ,"
        ssql += "Tipo1 ,"
        ssql += "Tipo2 ,"
        ssql += "Tipo3 ,"
        ssql += "Tipo4 ,"
        ssql += "Tipo5 ,"
        ssql += "longitud1 ,"
        ssql += "longitud2 ,"
        ssql += "longitud3 ,"
        ssql += "longitud4 ,"
        ssql += "longitud5 ,"
        ssql += "decimales1 ,"
        ssql += "decimales2 ,"
        ssql += "decimales3 ,"
        ssql += "decimales4 ,"
        ssql += "decimales5 )"
        ssql += " values("
        ssql += "'" & TipoReferencia & "',"
        ssql += "'" & Abreviación & "',"
        ssql += "'" & Descripcion & "',"
        ssql += "'" & Caracteristica1 & "',"
        ssql += "'" & Caracteristica2 & "',"
        ssql += "'" & Caracteristica3 & "',"
        ssql += "'" & Caracteristica4 & "',"
        ssql += "'" & Caracteristica5 & "',"
        ssql += "'" & Tipo1 & "',"
        ssql += "'" & Tipo2 & "',"
        ssql += "'" & Tipo3 & "',"
        ssql += "'" & Tipo4 & "',"
        ssql += "'" & Tipo5 & "',"
        ssql += " " & longitud1 & ","
        ssql += " " & longitud2 & ","
        ssql += " " & longitud3 & ","
        ssql += " " & longitud4 & ","
        ssql += " " & longitud5 & ","
        ssql += " " & decimales1 & ","
        ssql += " " & decimales2 & ","
        ssql += " " & decimales3 & ","
        ssql += " " & decimales4 & ","
        ssql += " " & decimales5 & ")"
        EjecutarComandos(ssql, StrSys)
    End Sub
    Public Sub Actualizar(ByVal TiporRef As String, ByVal cod As String)
        ssql = "Update Syscod set "
        ssql += "Descripcion ='" & Descripcion & "',"
        ssql += "Caracteristica1 ='" & Caracteristica1 & "',"
        ssql += "Caracteristica2 ='" & Caracteristica2 & "',"
        ssql += "Caracteristica3 ='" & Caracteristica3 & "',"
        ssql += "Caracteristica4 ='" & Caracteristica4 & "',"
        ssql += "Caracteristica5 ='" & Caracteristica5 & "',"
        ssql += "Tipo1 ='" & Tipo1 & "',"
        ssql += "Tipo2 ='" & Tipo2 & "',"
        ssql += "Tipo3 ='" & Tipo3 & "',"
        ssql += "Tipo4 ='" & Tipo4 & "',"
        ssql += "Tipo5 ='" & Tipo5 & "',"
        ssql += "longitud1 =" & longitud1 & ","
        ssql += "longitud2 =" & longitud2 & ","
        ssql += "longitud3 =" & longitud3 & ","
        ssql += "longitud4 =" & longitud4 & ","
        ssql += "longitud5 =" & longitud5 & ","
        ssql += "decimales1 =" & decimales1 & ","
        ssql += "decimales2 =" & decimales2 & ","
        ssql += "decimales3 =" & decimales3 & ","
        ssql += "decimales4 =" & decimales4 & ","
        ssql += "decimales5 =" & decimales5 & ")"
        ssql += " where TipoReferencia ='" & TiporRef & "' and Abreviación ='" & cod & "'"
    End Sub
    Public Sub Eliminar(ByVal TiporRef As String, ByVal cod As String, ByVal strsys As String)
        ssql = "delete from syscod "
        ssql += " where TipoReferencia ='" & TiporRef & "'"
        If cod <> "" Then ssql += "' and Abreviación ='" & cod & "'"
        EjecutarComandos(ssql, strsys)
    End Sub
    Public Sub consultar(ByVal tipoRef As String, ByVal cod As String, ByVal strSys As String)
        conectaSys.ConnectionString = strSys
        Dim cmd As New SqlCommand("select * from syscod where TipoReferencia='" & tipoRef & "' and Abreviación='" & cod & "'", conectaSys)
        Dim dat As SqlDataReader = Nothing
        If conectaSys.State = ConnectionState.Open Then conectaSys.Close()
        conectaSys.Open()
        dat = cmd.ExecuteReader()
        If dat.Read Then
            If Not IsDBNull(dat("TipoReferencia")) Then TipoReferencia = CStr(dat("TipoReferencia"))
            If Not IsDBNull(dat("Abreviación")) Then Abreviación = CStr(dat("Abreviación"))
            If Not IsDBNull(dat("Descripcion")) Then Descripcion = CStr(dat("Descripcion"))
            If Not IsDBNull(dat("Caracteristica1")) Then Caracteristica1 = CStr(dat("Caracteristica1"))
            If Not IsDBNull(dat("Caracteristica2")) Then Caracteristica2 = CStr(dat("Caracteristica2"))
            If Not IsDBNull(dat("Caracteristica3")) Then Caracteristica3 = CStr(dat("Caracteristica3"))
            If Not IsDBNull(dat("Caracteristica4")) Then Caracteristica4 = CStr(dat("Caracteristica4"))
            If Not IsDBNull(dat("Caracteristica5")) Then Caracteristica5 = CStr(dat("Caracteristica5"))
            If Not IsDBNull(dat("Tipo1")) Then Tipo1 = CStr(dat("Tipo1"))
            If Not IsDBNull(dat("Tipo2")) Then Tipo2 = CStr(dat("Tipo2"))
            If Not IsDBNull(dat("Tipo3")) Then Tipo3 = CStr(dat("Tipo3"))
            If Not IsDBNull(dat("Tipo4")) Then Tipo4 = CInt(dat("Tipo4"))
            If Not IsDBNull(dat("Tipo5")) Then Tipo5 = CInt(dat("Tipo5"))
            If Not IsDBNull(dat("longitud1")) Then longitud1 = CInt(dat("longitud1"))
            If Not IsDBNull(dat("longitud2")) Then longitud2 = CInt(dat("longitud2"))
            If Not IsDBNull(dat("longitud3")) Then longitud3 = CInt(dat("longitud3"))
            If Not IsDBNull(dat("longitud4")) Then longitud4 = CInt(dat("longitud4"))
            If Not IsDBNull(dat("longitud5")) Then longitud5 = CInt(dat("longitud5"))
            If Not IsDBNull(dat("decimales1")) Then decimales1 = CInt(dat("decimales1"))
            If Not IsDBNull(dat("decimales2")) Then decimales2 = CInt(dat("decimales2"))
            If Not IsDBNull(dat("decimales3")) Then decimales3 = CInt(dat("decimales3"))
            If Not IsDBNull(dat("decimales4")) Then decimales4 = CInt(dat("decimales4"))
            If Not IsDBNull(dat("decimales5")) Then decimales5 = CInt(dat("decimales5"))
        End If
        conectaSys.Close()
    End Sub
    Private Sub EjecutarComandos(ByVal sql As String, ByVal strSys As String)
        conectaSys.ConnectionString = strSys
        Dim cmd As New SqlCommand(sql, conectaSys)
        conectaSys.Open()
        cmd.ExecuteNonQuery()
        conectaSys.Close()
    End Sub
End Class
