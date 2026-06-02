Imports System.Data.SqlClient
Public Class ClsDatAux
    Dim ssql As String = ""
    Public nombre As String = ""
    Public Descripción As String = ""
    Public regPorConcepto As Boolean = False
    Public campotra As String = ""
    Public campodia As String = ""
    Public origenvalores As String = ""
    Public status As Boolean = False
    Public IDCLAVE As Integer = 0
    Public TipoDirectorio As String = ""
    Public GrupoDirectorio As String = ""
    Public TipoDato As String = ""
    Public Longitud As Integer = 0
    Public Decimales As Integer = 0
    Public EsClasificador As Boolean = False
    Public EsClasificadorSimple As Boolean = False
    Public Padre As String = ""
    Public CreadoUsuario As Boolean = False
    Dim conectar As New SqlConnection()

    Public Sub Guardar(ByVal conStr As String)
        ssql = "insert into AdcClasfctb("
        ssql += "nombre ,"
        ssql += "Descripción ,"
        ssql += "regPorConcepto ,"
        ssql += "campotra ,"
        ssql += "campodia ,"
        ssql += "origenvalores ,"
        ssql += "status ,"
        ssql += "IDCLAVE ,"
        ssql += "TipoDirectorio ,"
        ssql += "GrupoDirectorio ,"
        ssql += "TipoDato ,"
        ssql += "Longitud ,"
        ssql += "Decimales ,"
        ssql += "EsClasificador ,"
        ssql += "EsClasificadorSimple ,"
        ssql += "Padre ,"
        ssql += "CreadoUsuario )"
        ssql += " values ("
        ssql += "'" & nombre & "',"
        ssql += "'" & Descripción & "',"
        ssql += "'" & regPorConcepto & "',"
        ssql += "'" & campotra & "',"
        ssql += "'" & campodia & "',"
        ssql += "'" & origenvalores & "',"
        ssql += "'" & status & "',"
        ssql += " " & IDCLAVE & ","
        ssql += "'" & TipoDirectorio & "',"
        ssql += "'" & GrupoDirectorio & "',"
        ssql += "'" & TipoDato & "',"
        ssql += " " & Longitud & " ,"
        ssql += " " & Decimales & " ,"
        ssql += "'" & EsClasificador & "' ,"
        ssql += "'" & EsClasificadorSimple & "' ,"
        ssql += "'" & Padre & "',"
        ssql += "'" & CreadoUsuario & "')"
        EjecutarComnados(ssql, conStr)
    End Sub
    Public Sub Actualizar(ByVal nom As String, ByVal str As String)
        ssql = "update AdcClasfctb set "
        ssql += "nombre ='" & nombre & "',"
        ssql += "Descripción ='" & Descripción & "',"
        ssql += "regPorConcepto ='" & regPorConcepto & "',"
        ssql += "campotra ='" & campotra & "',"
        ssql += "campodia ='" & campodia & "',"
        ssql += "origenvalores ='" & origenvalores & "',"
        ssql += "status ='" & status & "',"
        ssql += "IDCLAVE =" & IDCLAVE & ","
        ssql += "TipoDirectorio ='" & TipoDirectorio & "',"
        ssql += "GrupoDirectorio ='" & GrupoDirectorio & "',"
        ssql += "TipoDato ='" & TipoDato & "',"
        ssql += "Longitud =" & Longitud & ","
        ssql += "Decimales =" & Decimales & ","
        ssql += "EsClasificador ='" & EsClasificador & "',"
        ssql += "EsClasificadorsimple ='" & EsClasificadorSimple & "',"
        ssql += "Padre ='" & Padre & "',"
        ssql += "CreadoUsuario ='" & CreadoUsuario & "'"
        If nom <> "" Then ssql += " where nombre='" & nom & "'"
        EjecutarComnados(ssql, str)
    End Sub
    Private Sub EjecutarComnados(ByVal comando As String, ByVal strC As String)
        conectar.ConnectionString = strC
        Dim cmd As New SqlCommand(comando, conectar)
        If conectar.State = ConnectionState.Open Then conectar.Close()
        conectar.Open()
        cmd.ExecuteNonQuery()
    End Sub
    Public Sub CargarCamp(ByVal nombre As String, ByVal str As String)
        conectar.ConnectionString = str
        Dim campos As String = ""
        Dim ssql As String = "select * from AdcClasfctb where nombre='" & nombre & "'"
        Dim cmd As New SqlCommand(ssql, conectar)
        Dim dat As SqlDataReader = Nothing
        If conectar.State = ConnectionState.Open Then conectar.Close()
        conectar.Open()
        dat = cmd.ExecuteReader()
        If dat.Read Then
            If Not IsDBNull(dat("nombre")) Then nombre = CStr(dat("nombre"))
            If Not IsDBNull(dat("Descripción")) Then Descripción = CStr(dat("Descripción"))
            If Not IsDBNull(dat("regPorConcepto")) Then regPorConcepto = CBool(dat("regPorConcepto"))
            If Not IsDBNull(dat("campotra")) Then campotra = CStr(dat("campotra"))
            If Not IsDBNull(dat("campodia")) Then campodia = CStr(dat("campodia"))
            If Not IsDBNull(dat("origenvalores")) Then origenvalores = CStr(dat("origenvalores"))
            If Not IsDBNull(dat("status")) Then status = CBool(dat("status"))
            If Not IsDBNull(dat("IDCLAVE")) Then IDCLAVE = CInt(dat("IDCLAVE"))
            If Not IsDBNull(dat("TipoDirectorio")) Then TipoDirectorio = CStr(dat("TipoDirectorio"))
            If Not IsDBNull(dat("GrupoDirectorio")) Then GrupoDirectorio = CStr(dat("GrupoDirectorio"))
            If Not IsDBNull(dat("TipoDato")) Then TipoDato = CStr(dat("TipoDato"))
            If Not IsDBNull(dat("Longitud")) Then Longitud = CInt(dat("Longitud"))
            If Not IsDBNull(dat("Decimales")) Then Decimales = CInt(dat("Decimales"))
            If Not IsDBNull(dat("EsClasificador")) Then EsClasificador = CBool(dat("EsClasificador"))
            If Not IsDBNull(dat("EsClasificadorSimple")) Then EsClasificadorSimple = CBool(dat("EsClasificadorSimple"))
            If Not IsDBNull(dat("Padre")) Then Padre = CStr(dat("Padre"))
            If Not IsDBNull(dat("CreadoUsuario")) Then CreadoUsuario = CBool(dat("CreadoUsuario"))
        End If
        conectar.Close()
    End Sub
End Class
