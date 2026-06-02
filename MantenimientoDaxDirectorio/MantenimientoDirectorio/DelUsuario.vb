Imports DattCom
Module DelUsuario
    Public Function AutorizarIngreso(ByVal NombreOpcion As String, Optional ByVal CodUsu As String = "", Optional ByVal codemp As Integer = 0) As String
        Dim auxiliar As String
        Dim ConxDaxSys As New SqlClient.SqlConnection(datosEmpresa.strConxSyscod)
        ConxDaxSys.Open()
        Dim RecClv As SqlClient.SqlDataReader
        On Error Resume Next

        If CodUsu = "" Then CodUsu = datosEmpresa.usr
        If codemp = 0 Then codemp = datosEmpresa.codEmpresa

        If UCase$(CodUsu) = "ADMINISTRADOR" Or UCase$(datosEmpresa.usr) = "CONTROL" Then AutorizarIngreso = "T" : Exit Function
        auxiliar = "SELECT * FROM sys_Accesos WHERE IdUsuario = '" & CodUsu & "'" & _
                            " AND IdEmpresa = " & codemp & " AND Idopcion = '" & NombreOpcion & "'"
        AutorizarIngreso = ""
        Dim Comm As New SqlClient.SqlCommand(auxiliar, ConxDaxSys)
        RecClv = Comm.ExecuteReader
        With RecClv
            If .Read = False Then .Close() : RecClv = Nothing : Exit Function
            If Not IsDBNull(.Item("Accesos")) Then AutorizarIngreso = .Item("Accesos").ToString Else AutorizarIngreso = ""
            .Close()
        End With
        RecClv = Nothing
        Comm.Dispose()
        'ConxDaxSys.Dispose()
    End Function

    'Public Sub GuardarUsuSuc(IdUsu As String, codemp As Integer, codSuc As String, Optional Aut As String)
    '        Dim cod As String
    '       ON ERROR Resume Next
    '        Dim ConxDaxSys As New SqlClient.SqlConnection(datosEmpresa.strConxSyscod)
    '        ConxDaxSys.Open()
    '        Dim RecUser As SqlClient.SqlDataReader
    '        cod = "delete FROM sys_Sucursales WHERE IdUsuario='" & IdUsu & "' AND IdEmpresa=" & codemp & " and codsucursal = '" & codSuc & "' "
    '        Dim Comm As New SqlClient.SqlCommand(cod, ConxDaxSys)
    '        Comm.ExecuteNonQuery()
    '        With RecUser
    '            !idusuario = Trim(IdUsu)
    '            !idempresa = codemp
    '            !CODSUCURSAL = Trim(codSuc)
    '            If Not IsMissing(Aut) Then !AutorizaSuc = Trim(Aut)
    '            .Update()
    '            .Close()
    '        End With
    '    End Sub

    'Public Sub GuardarUsuBod(IdUsu As String, codemp As Integer, codSuc As String, codBod As String, Optional Aut As String)
    '        Dim cod As String
    '        Dim recuser As New ADODB.Recordset
    '       ON ERROR Resume Next
    '        cod = "SELECT * FROM sys_Bodegas WHERE IdUsuario='" & IdUsu & "' AND CodBodega='" & codBod & "' AND CodSucursal='" & codSuc & "' AND IdEmpresa=" & codemp
    '        recuser.Open(cod, ConxDaxSys, adOpenKeyset, adLockOptimistic)
    '        With recuser
    '            If .RecordCount = 0 Then .AddNew()
    '            !idusuario = Trim(IdUsu)
    '            !idempresa = codemp
    '            !CODSUCURSAL = Trim(codSuc)
    '            !CODbodega = Trim(codBod)
    '            If Not IsMissing(Aut) Then !Autorizabod = Trim(Aut)
    '            .Update()
    '            .Close()
    '        End With
    '    End Sub

    'Public Sub GuardarUsuDoc(IdUsu As String, codemp As Integer, codDoc As String, Optional Cam As String)
    '        Dim cod As String
    '        Dim recuser As New ADODB.Recordset
    '        ' aqui reemplazo *****************************
    '        cod = "SELECT * FROM sys_Documentos WHERE IdUsuario='" & IdUsu & "' AND CodDocumento='" & codDoc & "' AND IdEmpresa=" & codemp
    '        recuser.Open(cod, ConxDaxSys, adOpenKeyset, adLockOptimistic)
    '        With recuser
    '            If .RecordCount = 0 Then .AddNew()
    '            !idusuario = Trim(IdUsu)
    '            !idempresa = codemp
    '            !CodDocumento = Trim(codDoc)
    '            If Not IsMissing(Cam) Then !Cambios = Trim(Cam)
    '            .Update()
    '            .Close()
    '        End With
    '    End Sub
End Module

