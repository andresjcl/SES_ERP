Imports System.Data.SqlClient
Imports System.Data

Public Class ClsDatAux
    Dim ssql As String = ""
    Public Abreviación As String = ""
    Public Descripción As String = ""
    Public TipoDato As String = ""
    Public Longitud As Long = 0
    Public Decimales As Long = 0
    Public Origen As String = ""
    Public CampoAsignado As String = ""
    Public UbicaCampo As String = ""
    Public UltimoCamVar As Integer = 0
    Public UltimoCamFec As Integer = 0
    Public UltimoCamLog As Integer = 0
    Public UltimoCamNum As Integer = 0

    Dim conectar As New SqlConnection()
    Public Sub Guardar()
        ssql = "Insert into CmpsAux( "
        ssql += "Abreviación,"
        ssql += "Descripción,"
        ssql += "TipoDato,"
        ssql += "Longitud,"
        ssql += "Decimales,"
        ssql += "Origen,"
        ssql += "CampoAsignado,"
        ssql += "UbicaCampo,"
        ssql += "UltimoCamVar,"
        ssql += "UltimoCamFec,"
        ssql += "UltimoCamLog,"
        ssql += "UltimoCamNum)"
        ssql += "Values ( "
        ssql += "'" & Abreviación & "',"
        ssql += "'" & Descripción & "',"
        ssql += "'" & TipoDato & "',"
        ssql += " " & Longitud & ","
        ssql += " " & Decimales & ","
        ssql += "'" & Origen & "',"
        ssql += "'" & CampoAsignado & "',"
        ssql += "'" & UbicaCampo & "',"
        If UltimoCamVar > 0 Then ssql += "'" & UltimoCamVar & "'," Else ssql += "null,"
        If UltimoCamFec > 0 Then ssql += "'" & UltimoCamFec & "'," Else ssql += "null,"
        If UltimoCamLog > 0 Then ssql += "'" & UltimoCamLog & "'," Else ssql += "null,"
        If UltimoCamNum > 0 Then ssql += "'" & UltimoCamNum & "')" Else ssql += "null)"
        EjecutarComnados(ssql)
    End Sub
    Public Sub Actualizar(ByVal cod As String)
        ssql = "Update CmpsAux set "
        ssql += "Descripción='" & Descripción & "',"
        ssql += "TipoDato='" & TipoDato & "',"
        ssql += "Longitud=" & Longitud & ","
        ssql += "Decimales=" & Decimales & ","
        ssql += "Origen='" & Origen & "',"
        ssql += "CampoAsignado='" & CampoAsignado & "',"
        ssql += "UbicaCampo='" & UbicaCampo & "',"
        If UltimoCamVar > 0 Then ssql += "UltimoCamVar=" & UltimoCamVar & ","
        If UltimoCamVar > 0 Then ssql += "UltimoCamFec='" & UltimoCamFec & "',"
        If UltimoCamVar > 0 Then ssql += "UltimoCamLog='" & UltimoCamLog & "',"
        If UltimoCamVar > 0 Then ssql += "UltimoCamNum='" & UltimoCamNum & "' "
        If cod <> "" Then ssql += "where Abreviación='" & cod & "'"
    End Sub
    Public Sub Eliminar(ByVal cod As String)
        ssql = "Delete from CmpsAux "
        ssql += "where Abreviación='" & cod & "'"
        EjecutarComnados(ssql)
    End Sub

    'Private Sub ConectarBdd()
    '    Dim coneccion As New DaxLib.DaxLibBases
    '    coneccion.TipoBase = "10"
    '    conectar.ConnectionString = coneccion.StrAdcom
    'End Sub
    Private Sub EjecutarComnados(ByVal comando As String)
        Dim conectar As New SqlConnection(DattCom.datosEmpresa.strConxAdcom)
        Dim cmd As New SqlCommand(comando, conectar)
        conectar.Open()
        cmd.ExecuteNonQuery()
        conectar.Dispose()
    End Sub
    Public Function ListarCamp(ByVal Ubicacion As String) As String
        Dim conectar As New SqlConnection(DattCom.datosEmpresa.strConxAdcom)
        Dim campos As String = ""
        Dim ssql As String = "select Abreviación from CmpsAux where UbicaCampo='" & Ubicacion & "'"
        Dim cmd As New SqlCommand(ssql, conectar)
        conectar.Open()
        Dim dat As SqlDataReader = cmd.ExecuteReader()
        While dat.Read
            If Not IsDBNull(dat(0)) Then
                If campos = "" Then campos = CStr(dat(0)) Else campos += "," & dat(0).ToString
            End If
        End While
        conectar.Close()
        Return campos
    End Function
    Public Sub CargarProp(ByVal nombre As String)
        Dim conectar As New SqlConnection(DattCom.datosEmpresa.strConxAdcom)
        conectar.Open()
        Dim campos As String = ""
        Dim ssql As String = "select * from AdcClasfCtb where nombre='" & nombre & "'"
        Dim cmd As New SqlCommand(ssql, conectar)
        Dim dat As SqlDataReader = cmd.ExecuteReader()
        If dat.Read Then
            If Not IsDBNull(dat(0)) Then Abreviación = CStr(dat(0))
            If Not IsDBNull(dat(1)) Then Descripción = CStr(dat(1))
            If Not IsDBNull(dat(2)) Then TipoDato = CStr(dat(2))
            If Not IsDBNull(dat(3)) Then Longitud = CLng(dat(3))
            If Not IsDBNull(dat(4)) Then Decimales = CLng(dat(4))
            If Not IsDBNull(dat(5)) Then Origen = CStr(dat(5))
            If Not IsDBNull(dat(6)) Then CampoAsignado = CStr(dat(6))
            If Not IsDBNull(dat(7)) Then UbicaCampo = CStr(dat(7))
            If Not IsDBNull(dat(8)) Then UltimoCamVar = CInt(dat(8))
            If Not IsDBNull(dat(9)) Then UltimoCamFec = CInt(dat(9))
            If Not IsDBNull(dat(10)) Then UltimoCamLog = CInt(dat(10))
            If Not IsDBNull(dat(11)) Then UltimoCamNum = CInt(dat(11))
        End If
        conectar.Close()
        conectar.Dispose()
    End Sub
End Class
