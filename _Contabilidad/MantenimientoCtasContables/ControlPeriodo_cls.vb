Option Strict On
Option Explicit On
Imports DattCom

Imports System.Data.SqlClient

Public Class ContrlPeriodo
    Public Sub manPermisos()
        Dim frm As New ControlPeriodo
        Main()
        frm.iniciaPermisos()
    End Sub

    Public Function valPeriodo(ByRef usuario As String, ByRef fecha As Date, ByRef esContable As Boolean) As String
        'Dim frm As New ControlPeriodo
        valPeriodo = ""
        Main()

        'If fecha <= datosEmpresa.UltimoCierreAnual Then valPeriodo = " Fecha del documento menor a fecha de ultimo cierre " & FormatDateTime(datosEmpresa.UltimoCierreAnual) : Exit Function
        'If fecha < CDate(DattCom.datosEmpresa.FechaLimiteDocumentos) Then valPeriodo = " Fecha del documento menor a fecha de control " & FormatDateTime(datosEmpresa.FechaLimiteDocumentos) : Exit Function
        'valPeriodo = buscaVal(usuario, fecha, esContable)
        If fecha <= emp.InvUltAnu Then valPeriodo = " Fecha del documento menor a fecha de ultimo cierre " & FormatDateTime(emp.InvUltAnu) : Exit Function
        If fecha < CDate(DattCom.datosEmpresa.Par_RolCodMay) Then valPeriodo = " Fecha del documento menor a fecha de control " & FormatDateTime(emp.RolCodMay) : Exit Function
        valPeriodo = buscaVal(usuario, fecha, esContable)

    End Function

    Private Function buscaVal(ByRef usuario As String, ByRef fecha As Date, ByRef esContable As Boolean) As String
        'Dim TablaAux As New ADODB.Recordset
        'Dim libbas As New DaxLib.DaxLibBases
        'Dim Conxadcom As New ADODB.Connection
        'Conxadcom.ConnectionString = libbas.StrAdcom
        'Conxadcom.Open()
        Dim sSql As String = " select contabilidad,otrosmodulos,exccontabilidad,excotrosmodulos "
        sSql = sSql & " from adcperiodo"
        sSql = sSql & " where contabilidad <> '' "
        sSql = sSql & " and año=" & Year(fecha)
        sSql = sSql & " and mes=" & Month(fecha)
        Dim TablaAux As SqlDataReader = DattCom.SqlDatos.leerBase(sSql, datosEmpresa.strConxAdcom)
        buscaVal = ""
        If TablaAux.Read() Then
            If esContable = True Then
                buscaVal = comparaExiste(TablaAux("contabilidad").ToString(), TablaAux("exccontabilidad").ToString(), usuario)
            Else
                buscaVal = comparaExiste(TablaAux("otrosmodulos").ToString, TablaAux("excotrosmodulos").ToString, usuario)
            End If
        Else
            buscaVal = ""
        End If
        'If TablaAux.State = 1 Then TablaAux.Close()
        TablaAux = Nothing
        'libbas = Nothing
    End Function

    Private Function comparaExiste(ByRef tipo As String, ByRef us As String, ByRef usuario As String) As String
        Dim user() As String
        Dim I As Int32
        comparaExiste = ""
        If tipo.Trim.ToUpper = "ABIERTO" Then Exit Function
        user = Split(us, ";")
        For I = 0 To UBound(user)
            If UCase(usuario) = UCase(user(I)) Then Exit Function
        Next I
        comparaExiste = "No tiene autorización para registrar documentos con esta fecha "
    End Function

    Private Sub Main()
        '        On Error GoTo HayErrores
        '        'CONEMP = New AdcDax.DaxSofSys
        '        'Emp = CONEMP.EmpresaAct
        '        'CONUSR = New DaxUsr.DaxsofUsr
        '        'ControlUsuario = CONUSR.UsuarioAct
        '        'Autorizacion = Emp.Autorizacion
        '        Exit Sub
        'HayErrores:
        '        If MsgBox(" No se ha cargado BuscaCta correctamente") Then Exit Sub
    End Sub
End Class