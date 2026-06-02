Option Strict On
Option Explicit On
'
Imports System
Imports System.Data
Imports System.Data.SqlClient
'
Public Class DaxCiecaj
    ' Las variables privadas
    ' TODO: Revisar los tipos de los campos
    Private _Sucursal As System.String = ""
    Private _PuntoDeVenta As System.String = ""
    Private _IdClave As System.Decimal = 0
    Private _FechaIni As System.DateTime = New DateTime(1900, 1, 1, 0, 0, 0)
    Private _FechaFin As System.DateTime = New DateTime(1900, 1, 1, 0, 0, 0)
    Private _IdUserInicio As System.String = ""
    Private _IdUserCierre As System.String = ""
    Private _RecibidoCheques As System.Decimal = 0
    Private _RecibidoTarjetas As System.Decimal = 0
    Private _RecibidoEfectivo As System.Decimal = 0
    Private _RecibidoNroCheques As System.Decimal = 0
    Private _RecibidoNroTarjetas As System.Decimal = 0

    Public fechaIniciaCaja As DateTime
    Public fechaFinalizaCaja As DateTime
    '
    ' Este método se usará para ajustar los anchos de las propiedades
    Private Function ajustarAncho(cadena As String, ancho As Integer) As String
        Dim sb As New System.Text.StringBuilder(New String(" "c, ancho))
        ' devolver la cadena quitando los espacios en blanco
        ' esto asegura que no se devolverá un tamaño mayor ni espacios "extras"
        Return (cadena & sb.ToString()).Substring(0, ancho).Trim()
    End Function
    '
    ' Las propiedades públicas
    ' TODO: Revisar los tipos de las propiedades
    Public Property IdClave() As System.Decimal
        Get
            Return _IdClave
        End Get
        Set(value As System.Decimal)
            _IdClave = value
        End Set
    End Property
    Public Property PuntoDeVenta() As System.String
        Get
            Return ajustarAncho(_PuntoDeVenta, 100)
        End Get
        Set(value As System.String)
            _PuntoDeVenta = value
        End Set
    End Property
    Public Property Sucursal() As System.String
        Get
            Return ajustarAncho(_Sucursal, 50)
        End Get
        Set(value As System.String)
            _Sucursal = value
        End Set
    End Property
    Public Property FechaIni() As System.DateTime
        Get
            Return _FechaIni
        End Get
        Set(value As System.DateTime)
            _FechaIni = value
        End Set
    End Property
    Public Property FechaFin() As System.DateTime
        Get
            Return _FechaFin
        End Get
        Set(value As System.DateTime)
            _FechaFin = value
        End Set
    End Property
    Public Property IdUserInicio() As System.String
        Get
            Return ajustarAncho(_IdUserInicio, 50)
        End Get
        Set(value As System.String)
            _IdUserInicio = value
        End Set
    End Property
    Public Property IdUserCierre() As System.String
        Get
            Return ajustarAncho(_IdUserCierre, 50)
        End Get
        Set(value As System.String)
            _IdUserCierre = value
        End Set
    End Property
    Public Property RecibidoCheques() As System.Decimal
        Get
            Return _RecibidoCheques
        End Get
        Set(value As System.Decimal)
            _RecibidoCheques = value
        End Set
    End Property
    Public Property RecibidoTarjetas() As System.Decimal
        Get
            Return _RecibidoTarjetas
        End Get
        Set(value As System.Decimal)
            _RecibidoTarjetas = value
        End Set
    End Property
    Public Property RecibidoEfectivo() As System.Decimal
        Get
            Return _RecibidoEfectivo
        End Get
        Set(value As System.Decimal)
            _RecibidoEfectivo = value
        End Set
    End Property
    Public Property RecibidoNroCheques() As System.Decimal
        Get
            Return _RecibidoNroCheques
        End Get
        Set(value As System.Decimal)
            _RecibidoNroCheques = value
        End Set
    End Property
    Public Property RecibidoNroTarjetas() As System.Decimal
        Get
            Return _RecibidoNroTarjetas
        End Get
        Set(value As System.Decimal)
            _RecibidoNroTarjetas = value
        End Set
    End Property
    ' Campos y métodos compartidos (estáticos) para gestionar la base de datos
    '
    ' La cadena de conexión a la base de datos
    Private Shared cadenaConexion As String = ""
    ' La cadena de selección
    Public Shared CadenaSelect As String = "Seletes "
    '
    Public Sub New()
    End Sub
    Public Sub New(conex As String)
        cadenaConexion = conex
    End Sub
    '
    ' Métodos compartidos (estáticos) privados
    '
    ' asigna una fila de la tabla a un objeto DaxCiecaj
    Private Shared Function row2DaxCiecaj(r As DataRow) As DaxCiecaj
        ' asigna a un objeto DaxCiecaj los datos del dataRow indicado
        Dim oDaxCiecaj As New DaxCiecaj
        '
        oDaxCiecaj.IdClave = System.Decimal.Parse("0" & r("IdClave").ToString())
        oDaxCiecaj.PuntoDeVenta = r("PuntoDeVenta").ToString()
        oDaxCiecaj.Sucursal = r("Sucursal").ToString()
        Try
            oDaxCiecaj.FechaFin = System.DateTime.Parse(r("FechaFin").ToString())

        Catch
        End Try
        Try
            oDaxCiecaj.FechaIni = System.DateTime.Parse(r("FechaIni").ToString())

        Catch

        End Try
        oDaxCiecaj.IdUserInicio = r("IdUserInicio").ToString()
        oDaxCiecaj.IdUserCierre = r("IdUserCierre").ToString()
        oDaxCiecaj.RecibidoCheques = System.Decimal.Parse("0" & r("RecibidoCheques").ToString())
        oDaxCiecaj.RecibidoTarjetas = System.Decimal.Parse("0" & r("RecibidoTarjetas").ToString())
        oDaxCiecaj.RecibidoEfectivo = System.Decimal.Parse("0" & r("RecibidoEfectivo").ToString())
        oDaxCiecaj.RecibidoNroCheques = System.Decimal.Parse("0" & r("RecibidoNroCheques").ToString())
        oDaxCiecaj.RecibidoNroTarjetas = System.Decimal.Parse("0" & r("RecibidoNroTarjetas").ToString())
        '
        Return oDaxCiecaj
    End Function
    '
    ' asigna un objeto DaxCiecaj a la fila indicada
    Private Shared Sub DaxCiecaj2Row(oDaxCiecaj As DaxCiecaj, r As DataRow)
        r("IdClave") = oDaxCiecaj.IdClave
        r("PuntoDeVenta") = oDaxCiecaj.PuntoDeVenta
        r("Sucursal") = oDaxCiecaj.Sucursal
        r("FechaIni") = oDaxCiecaj.FechaIni
        r("FechaFin") = oDaxCiecaj.FechaFin
        r("IdUserInicio") = oDaxCiecaj.IdUserInicio
        r("IdUserCierre") = oDaxCiecaj.IdUserCierre
        r("RecibidoCheques") = oDaxCiecaj.RecibidoCheques
        r("RecibidoTarjetas") = oDaxCiecaj.RecibidoTarjetas
        r("RecibidoEfectivo") = oDaxCiecaj.RecibidoEfectivo
        r("RecibidoNroCheques") = oDaxCiecaj.RecibidoNroCheques
        r("RecibidoNroTarjetas") = oDaxCiecaj.RecibidoNroTarjetas
    End Sub
    '
    ' crea una nueva fila y la asigna a un objeto DaxCiecaj
    Private Shared Sub nuevoDaxCiecaj(dt As DataTable, oDaxCiecaj As DaxCiecaj)
        ' Crear un nuevo DaxCiecaj
        Dim dr As DataRow = dt.NewRow()
        Dim oD As DaxCiecaj = row2DaxCiecaj(dr)
        '
        oD.IdClave = oDaxCiecaj.IdClave
        oD.PuntoDeVenta = oDaxCiecaj.PuntoDeVenta
        oD.Sucursal = oDaxCiecaj.Sucursal
        oD.FechaIni = oDaxCiecaj.FechaIni
        oD.FechaFin = oDaxCiecaj.FechaFin
        oD.IdUserInicio = oDaxCiecaj.IdUserInicio
        oD.IdUserCierre = oDaxCiecaj.IdUserCierre
        oD.RecibidoCheques = oDaxCiecaj.RecibidoCheques
        oD.RecibidoTarjetas = oDaxCiecaj.RecibidoTarjetas
        oD.RecibidoEfectivo = oDaxCiecaj.RecibidoEfectivo
        oD.RecibidoNroCheques = oDaxCiecaj.RecibidoNroCheques
        oD.RecibidoNroTarjetas = oDaxCiecaj.RecibidoNroTarjetas
        '
        DaxCiecaj2Row(oD, dr)
        '
        dt.Rows.Add(dr)
    End Sub
    '
    ' Métodos públicos
    '
    ' devuelve una tabla con los datos indicados en la cadena de selección
    Public Shared Function Tabla() As DataTable
        Return Tabla(CadenaSelect)
    End Function
    Public Shared Function Tabla(sel As String) As DataTable
        ' devuelve una tabla con los datos de la tabla DaxCiecaj
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("DaxCiecaj")
        '
        Try
            da = New SqlDataAdapter(sel, cadenaConexion)
            da.Fill(dt)
        Catch
            Return Nothing
        End Try
        '
        Return dt
    End Function
    '
    Public Shared Function Buscar(sWhere As String) As DaxCiecaj
        ' Busca en la tabla los datos indicados en el parámetro
        ' el parámetro contendrá lo que se usará después del WHERE
        Dim oDaxCiecaj As DaxCiecaj = Nothing
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("DaxCiecaj")
        Dim sel As String = "SELECT * FROM DaxCiecaj WHERE " & sWhere
        '
        da = New SqlDataAdapter(sel, cadenaConexion)
        da.Fill(dt)
        '
        If dt.Rows.Count > 0 Then
            oDaxCiecaj = row2DaxCiecaj(dt.Rows(0))
        End If
        Return oDaxCiecaj
    End Function
    '
    Public Function Actualizar() As String
        Dim sel As String = "SELECT * FROM DaxCiecaj WHERE Sucursal ='" + Sucursal + "' and PuntoDeVenta = '" + PuntoDeVenta + "' and  IdClave = " & Me.IdClave.ToString()
        Return Actualizar(sel)
    End Function
    Public Function Actualizar(sel As String) As String
        ' Actualiza los datos indicados
        ' El parámetro, que es una cadena de selección, indicará el criterio de actualización
        '
        ' En caso de error, devolverá la cadena empezando por ERROR.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("DaxCiecaj")
        '
        cnn = New SqlConnection(cadenaConexion)
        da = New SqlDataAdapter(sel, cnn)
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey
        Dim cb As New SqlCommandBuilder(da)
        da.UpdateCommand = cb.GetUpdateCommand()
        Try
            da.Fill(dt)
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
        '
        If dt.Rows.Count = 0 Then
            ' crear uno nuevo
            CadenaSelect = sel
            Return Crear()
        Else
            DaxCiecaj2Row(Me, dt.Rows(0))
        End If
        '
        Try
            da.Update(dt)
            dt.AcceptChanges()
            Return "Actualizado correctamente"
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
    End Function
    '
    Public Function Crear() As String
        ' Crear un nuevo registro
        ' En caso de error, devolverá la cadena de error empezando por ERROR:.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("DaxCiecaj")
        IdClave = nuevaClave()
        cnn = New SqlConnection(cadenaConexion)
        da = New SqlDataAdapter(CadenaSelect, cnn)
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey
        Dim cb As New SqlCommandBuilder(da)
        da.InsertCommand = cb.GetInsertCommand()
        Try
            da.Fill(dt)
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
        '
        nuevoDaxCiecaj(dt, Me)
        '
        Try
            da.Update(dt)
            dt.AcceptChanges()
            Return "Se ha creado un nuevo DaxCiecaj"
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
    End Function
    Public Function nuevaClave() As Decimal
        Dim clave As Integer = 0
        Dim cnn As New SqlConnection(cadenaConexion)
        cnn.Open()
        Dim comm As New SqlCommand("select max(idclave) as idclave from DaxCieCaj where Sucursal ='" + Sucursal + "' and PuntoDeVenta = '" + PuntoDeVenta + "'", cnn)
        Dim dr As SqlDataReader = comm.ExecuteReader()
        If dr.Read And Not IsDBNull(dr("idclave")) Then clave = Convert.ToInt32(dr("idclave"))
        dr.Close()
        comm.Dispose()
        cnn.Close()
        Return clave + 1
    End Function
    Public Function Borrar() As String
        Dim sel As String = "SELECT * FROM DaxCiecaj WHERE Sucursal ='" + Sucursal + "' and PuntoDeVenta = '" + PuntoDeVenta + "' and IdClave = " & Me.IdClave.ToString()
        '
        Return Borrar(sel)
    End Function
    Public Function Borrar(sel As String) As String
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("DaxCiecaj")
        '
        cnn = New SqlConnection(cadenaConexion)
        da = New SqlDataAdapter(sel, cnn)
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey
        Dim cb As New SqlCommandBuilder(da)
        da.DeleteCommand = cb.GetDeleteCommand()
        da.Fill(dt)
        '
        If dt.Rows.Count = 0 Then
            Return "ERROR: No hay datos"
        Else
            dt.Rows(0).Delete()
        End If
        '
        Try
            da.Update(dt)
            dt.AcceptChanges()
            Return "Borrado satisfactoriamente"
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
    End Function
    '
End Class

