Option Strict On
Option Explicit On

Imports System.Data.SqlClient
Imports DattCom
Public Class Directorio
    ''Esta Clase sirve para cargar directorios en produccion o sistemas que  permito que no usen el adcomdx
    Public codigo As String 'copia local
    Public NombreImpresion As String 'copia local
    Public CiRuc As String 'copia local
    Public telefono1 As String 'copia local
    Public telefono2 As String 'copia local
    Public direccion As String 'copia local
    Public CodVendedor As String 'copia local
    Public ZonaVentas As String 'copia local
    Public TipoCliente As String
    Public Ciudad As String
    Public TipoId As String
    Public NombreCli As String
    Public TipoPersona As String
    'variables locales para almacenar los valores de las propiedades

    Public Function CargarAlex(ByRef CodigoAlex As String, ByRef ClioPro As Boolean, Optional ByRef SoloCodigo As String = "") As Boolean

        Dim apellidos As String = ""
        Dim nombres As String = ""
        Dim seleccion As String = ""

        Dim ConxAdcom As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
        Dim rs As SqlClient.SqlDataReader
        Dim Ssql As String = "SELECT * FROM DirectorioList " & " WHERE codigo='" & CodigoAlex & "' or cedulaidentidadruc ='" & CodigoAlex & "'  " & seleccion & ""
        Dim comm As New SqlClient.SqlCommand(Ssql, ConxAdcom)
        ConxAdcom.Open()
        rs = comm.ExecuteReader

        If rs.Read = False Then rs.Close() : CargarAlex = False : Exit Function

        With rs
            codigo = .Item("codigo").ToString()
            If Not IsDBNull(.Item("nombres")) Then nombres = .Item("nombres").ToString()
            If Not IsDBNull(.Item("apellidos")) Then apellidos = .Item("apellidos").ToString()
            If Not IsDBNull(.Item("NombreImpresion")) Then NombreImpresion = .Item("NombreImpresion").ToString()
            If Not IsDBNull(.Item("CedulaIdentidadRuc")) Then CiRuc = .Item("CedulaIdentidadRuc").ToString()
            If Not IsDBNull(.Item("telefono1")) Then telefono1 = .Item("telefono1").ToString()
            If Not IsDBNull(.Item("Domicilio")) Then direccion = .Item("Domicilio").ToString()
            If Not IsDBNull(.Item("Ciudad")) Then Ciudad = .Item("Ciudad").ToString()
            If Not IsDBNull(.Item("TipoIdentificacion")) Then TipoId = .Item("TipoIdentificacion").ToString()
            If Not IsDBNull(.Item("TipoPersona")) Then TipoPersona = IIf(.Item("TipoPersona").ToString() = "N", "1", "2").ToString()
            If Not IsDBNull(.Item("VendedorInterno")) Then CodVendedor = .Item("VendedorInterno").ToString()
            If Not IsDBNull(.Item("ZonaVentas")) Then ZonaVentas = .Item("ZonaVentas").ToString()
            If Not IsDBNull(.Item("TipoCli")) Then TipoCliente = .Item("TipoCli").ToString()
            NombreCli = CorrijeNulo(.Item("NombreCli"))
        End With
        rs.Close()
        CargarAlex = True
        ConxAdcom.Close()
        ConxAdcom.Dispose()
        rs.Close()
        comm.Dispose()
    End Function
    Public Shared Sub actualizarDirectorio(txtcedula As String, txtCorreoElectronico As String, txtnombrecliente As String, txtApellido As String, txttelefono2 As String, txttelefono As String, txtdireccion As String, txtSector As String)
        Dim insertar = "update identificacion set HistoriaClinica = '" + txtcedula + "'"
        insertar += ", correoElectrónico = '" + txtCorreoElectronico + "'"
        insertar += ", NombreImpresion = '" + txtnombrecliente + "'"
        insertar += ", Telefono1 = '" + txttelefono + "'"
        insertar += ", Telefono2 = '" + txttelefono2 + "'"
        insertar += ", Domicilio = '" + txtdireccion + "'"
        insertar += ", sector = '" + txtSector + "'"
        insertar += " where Codigo = '" + txtcedula + "' or CedulaIdentidadRuc = '" + txtcedula + "' "

        Using conn As New SqlConnection(datosEmpresa.strConxAdcom)
            conn.Open()
            Using comm As New SqlCommand(insertar, conn)
                comm.ExecuteNonQuery()
            End Using
        End Using

    End Sub

End Class

