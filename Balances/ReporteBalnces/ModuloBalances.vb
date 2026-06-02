Imports System.Data.SqlClient
Imports DattCom

Module ModuloBalances
    Public conectar As New SqlConnection()

    ' Reemplazo de SYSEMP/EMP por la cadena de configuración de la empresa
    Public strConIniSis As String = datosEmpresa.strConIniSis

    Public Sub conectarBDD()
        ' Asignación directa de la cadena de conexión a la base de datos
        conectar.ConnectionString = datosEmpresa.strConxAdcom
    End Sub

End Module