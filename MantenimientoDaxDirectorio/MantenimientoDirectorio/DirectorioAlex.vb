Option Strict Off
Option Explicit On
Imports DattCom
Public Class DirectorioAlex
    'variables locales para almacenar los valores de las propiedades
    Public codigo As String 'copia local
    Public nombres As String 'copia local
    Public apellidos As String 'copia local
    Public NombreImpresion As String 'copia local
    Public CiRuc As String 'copia local
    Public telefono1 As String 'copia local
    Public telefono2 As String 'copia local
    Public direccion As String 'copia local
    Public CodVendedor As String 'copia local
    Public CodCobrador As String 'copia local
    Public ZonaVentas As String 'copia local
    Public ZonaCobranzas As String 'copia local
    Public TipoCliente As String
    Public EsProveedor As Boolean
    Public EsCliente As Boolean
    Public EsEmpleado As Boolean
    Public EsBanco As Boolean
    Public EsVendedor As Boolean
    Public Ciudad As String
    Public PrecioVenta As Short
    Public dESCUENTO As Double
    Public dESCUENTO_prov As Double
    Public FormaPago As String
    Public FormaPago_prov As String
    Public limitecredito As Double
    Public limitecredito_prov As Double
    Public PorcComision As Integer
    Public CtaCobComision As String
    Public TipoId As String
    Public NombreCli As String
    Public TipoPersona As String
    Public ExoneradoIva As Boolean
    Public correoElectronico As String
    Public sector As String

    Public Function CargarAlex(ByRef CodigoAlex As String, ByRef ClioPro As Boolean, Optional ByRef SoloCodigo As String = "") As Boolean
        CargarAlex = False
        Mainn()
        Dim Seleccion As String = ""
        Try
            Dim RsCli = New Identificacion(datosEmpresa.strConxAdcom)
            RsCli = Identificacion.Buscar(" codigo='" & CodigoAlex & "' or cedulaidentidadruc ='" & CodigoAlex & "'  " & Seleccion & "")
            If RsCli Is Nothing Then Exit Function
            Seleccion = ""

            With RsCli
                codigo = .Codigo
                nombres = .Nombres
                apellidos = .Apellidos
                NombreImpresion = .NombreImpresion
                CiRuc = .CedulaIdentidadRuc
                telefono1 = .Telefono1
                telefono2 = .Telefono2
                direccion = .Domicilio
                EsCliente = .EsCliente
                EsProveedor = .EsProveedor
                EsEmpleado = .EsEmpleado
                EsBanco = .EsBanco
                Ciudad = .Ciudad
                EsVendedor = .EsVendedor
                PorcComision = .ComisionVenta
                CtaCobComision = .CtaCobrarComisiones
                TipoId = .TipoIdentificacion
                TipoPersona = .TipoPersona
                ExoneradoIva = .ExoneradoIva
                NombreCli = nombres & " " & apellidos
                correoElectronico = .CorreoElectrónico
                sector = .Sector
            End With
            CargarAlex = True
        Catch exx As Exception
            MsgBox("excepcion en lectura de datos Alex identificacion" + vbCr + exx.Message)
        End Try

        Try
            Dim ConxAdcom As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
            ConxAdcom.Open()
            Dim Ssql As String = "SELECT * FROM Cliente WHERE codigocli='" & CodigoAlex & "'"
            Dim comm As New SqlClient.SqlCommand(Ssql, ConxAdcom)
            Dim rs As SqlClient.SqlDataReader = comm.ExecuteReader
            If rs.Read Then
                With rs
                    If Not IsDBNull(.Item("VendedorInterno").ToString) Then CodVendedor = .Item("VendedorInterno").ToString
                    If Not IsDBNull(.Item("TipoCli").ToString) Then TipoCliente = .Item("TipoCli").ToString
                    If Not IsDBNull(.Item("ZonaVentas").ToString) Then ZonaVentas = .Item("ZonaVentas").ToString
                    If Not IsDBNull(.Item("ZonaCobranza").ToString) Then ZonaCobranzas = .Item("ZonaCobranza").ToString
                    If Not IsDBNull(.Item("CobradorInterno").ToString) Then CodCobrador = .Item("CobradorInterno").ToString
                    If Not IsDBNull(.Item("PrecioVenta")) Then PrecioVenta = CorrijeNuloN(.Item("PrecioVenta"))
                    If Not IsDBNull(.Item("PorcDescuento")) Then dESCUENTO = .Item("PorcDescuento")
                    If Not IsDBNull(.Item("FormaPago").ToString) Then FormaPago = .Item("FormaPago").ToString
                    If Not IsDBNull(.Item("limitecredito")) Then limitecredito = CDbl("0" + .Item("limitecredito").ToString)
                End With
            End If
            rs.Close()
        Catch exx As Exception
            MsgBox("excepcion en lectura de datos Alex cliente" + vbCr + exx.Message)
        End Try

        Try
            Dim ConxAdcom As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
            ConxAdcom.Open()
            Dim Ssql As String = "SELECT isnull(FormaPago,'') as FormaPago,isnull(PorceDescuent,0) as PorceDescuent,isnull(LimCreditoPrv,0) as LimCreditoPrv FROM proveedor WHERE codigoproveedor='" & CodigoAlex & "'"
            Dim comm As SqlClient.SqlCommand = New SqlClient.SqlCommand(Ssql, ConxAdcom)
            Dim rs As SqlClient.SqlDataReader = comm.ExecuteReader
            If rs.Read Then
                With rs
                    If Not IsDBNull(.Item("PorceDescuent")) Then dESCUENTO_prov = .Item("PorceDescuent")
                    If Not IsDBNull(.Item("FormaPago")) Then FormaPago_prov = .Item("FormaPago").ToString
                    If Not IsDBNull(.Item("LimCreditoPrv")) Then limitecredito_prov = Val(.Item("LimCreditoPrv").ToString)
                End With
            End If
            rs.Close()
        Catch exx As Exception
            MsgBox("excepcion en lectura de datos Alex proveedor" + vbCr + exx.Message)
        End Try

    End Function
End Class

