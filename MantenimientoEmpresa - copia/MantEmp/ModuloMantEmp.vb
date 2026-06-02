Imports System.Data.SqlClient

Module ModuloMantEmp

    Friend Function retornaNombRef(ByVal cod As String, ByVal tipoRef As String) As String

        Dim nom As String = ""
        Dim ssql As String = "select descripcion from syscod where tipoReferencia='" & tipoRef & "' and Abreviación='" & cod & "'"
        Dim dat As SqlDataReader = DattCom.SqlDatos.leerBaseIniSis(ssql)
        If dat.Read Then
            If Not IsDBNull(dat(0)) Then nom = CStr(dat(0))
        End If
        Return nom
    End Function

    Friend Function retornaNomb(ByVal cod As String) As String
        If cod = "" Then Return ""
        Dim nom As String = ""
        Try
            Dim dat As SqlDataReader = DattCom.SqlDatos.leerBaseAdcom("select nombreImpresion from identificacion where codigo='" & cod & "'")
            If dat.Read Then
                If Not IsDBNull(dat(0)) Then nom = CStr(dat(0))
            End If
        Catch EE As Exception
            MsgBox("No se puede accesar a la base de datos registrada" & "el sistema continuará para que corrija el registro")
            Return ""
        End Try
        Return nom
    End Function
    Friend Function Busca(ByVal cad As String, ByVal cmpCod As String, ByVal cmpNom As String, ByVal tit As String) As String
        Dim cod As String = ""
        Dim busk As New Buscar.frmBuscar
        cod = busk.Buscar(DattCom.datosEmpresa.strConIniSis, cad, cmpCod, cmpNom, "Consulta", tit)
        Return cod
    End Function
End Module
