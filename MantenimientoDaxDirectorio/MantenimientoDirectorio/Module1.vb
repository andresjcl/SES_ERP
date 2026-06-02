Option Strict Off
Option Explicit On
Imports DattCom
Module Module1
    Public Orden As String = ""

    Public Sub Mainn()
        Try
            'If datosEmpresa.strConxAdcom = "" Then varbleComun.cargar.iniciar("", "")
            If Len(Trim(datosEmpresa.strConxAdcom)) = 0 Then Exit Sub
        Catch ee As Exception
            MsgBox("excepción mainn: " & ee.Message)
        End Try
        Emp.CargarValores()
    End Sub

    Public Function ValidaId(ByRef NumeroId As String, ByRef TipoId As String, ByVal Persona As String) As Boolean
        Dim Largo As Short
        On Error Resume Next
        ValidaId = False
        If TipoId = "P" Then
            ValidaId = True
            Exit Function
        ElseIf TipoId = "F" Then
            If NumeroId = "9999999999999" Then ValidaId = True
            Exit Function
        End If
        Largo = Len(NumeroId)
        If Not IsNumeric(NumeroId) Then Exit Function
        If TipoId = "R" Then
            If Largo <> 13 Or Mid(NumeroId, 11) <> "001" Then Exit Function
        ElseIf TipoId = "C" Then
            If Largo <> 10 Then Exit Function
        End If
        Largo = Val(Mid(NumeroId, 3, 1))
        ValidaId = True
        If TipoId = "C" Then
            '           ValidaId = Validador.validarCedula(NumeroId)
        ElseIf Largo >= 0 And Largo <= 5 Then
            '            ValidaId = Validador.validarRUCNaturales(NumeroId)
        ElseIf Largo = 6 Then
            '            ValidaId = Validador.validarRUCPublicas(NumeroId)
        ElseIf Largo = 9 Then
            '            ValidaId = Validador.validarRUCPrivadas(NumeroId)
        End If
        'UPGRADE_NOTE: El objeto Validador no se puede destruir hasta que no se realice la recolección de los elementos no utilizados. Haga clic aquí para obtener más información: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        '        Validador = Nothing
    End Function

    Public Function ClienteMovimiento(ByRef codigo As String) As Boolean
        Dim cod As String
        Dim ConxAdcom As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
        Dim rs As SqlClient.SqlDataReader
        ClienteMovimiento = False
        Try
            ConxAdcom.Open()
            If ConxAdcom.State = 1 Then
                cod = " SELECT Doc_codper " & " From AdcDoc " & " Where Doc_codper = '" & codigo & "' "
                Dim comm As New SqlClient.SqlCommand(cod, ConxAdcom)
                rs = comm.ExecuteReader
                If rs.Read Then ClienteMovimiento = True
                rs.Close()
                comm.Dispose()
                cod = " SELECT idempleado " & " From rolliq " & " Where idempleado = '" & codigo & "' "
                comm = New SqlClient.SqlCommand(cod, ConxAdcom)
                rs = comm.ExecuteReader
                If rs.Read Then ClienteMovimiento = True
                rs.Close()
                comm.Dispose()
            End If
            ConxAdcom.Close()
        Catch ee As Exception
            MsgBox("excepción Mandir_Clmov : " & ee.Message)
        End Try
    End Function
End Module

