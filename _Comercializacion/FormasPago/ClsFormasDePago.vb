Option Strict On
Option Explicit On
'
Imports System
Imports System.Data
Imports System.Data.SqlClient
'
Public Class FormasDePago
    ' Las variables privadas
    ' TODO: Revisar los tipos de los campos
    Private _IdFormasDePago As System.String
    Private _Descripcion As System.String
    Private _formadepago As System.Int16
    Private _NumeroDeCuotas As System.Int16
    Private _Institucion As System.Boolean
    Private _tipoformapago As System.Int16
    Private _plazofv As System.Byte
    Private _DiasCuotaFijas As System.Int16
    Private _DiasCuotaVar0 As System.Int16
    Private _DiasCuotaVar1 As System.Int16
    Private _DiasCuotaVar2 As System.Int16
    Private _DiasCuotaVar3 As System.Int16
    Private _DiasCuotaVar4 As System.Int16
    Private _DiasCuotaVar5 As System.Int16
    Private _DiasCuotaVar6 As System.Int16
    Private _DiasCuotaVar7 As System.Int16
    Private _DiasCuotaVar8 As System.Int16
    Private _DiasCuotaVar9 As System.Int16
    Private _DiasCuotaVar10 As System.Int16
    Private _DiasCuotaVar11 As System.Int16
    Private _GeneraIngreso As System.Int16
    Private _CancelaFactura As System.Int16
    Private _Id_Contable As System.String
    Private _ContadoSri As System.Boolean
    Private _Id_Contable2 As System.String
    Private _SRI_formaDePago As System.String
    Private _SRI_pagoLocExt As System.String
    Private _SRI_pagoPais As System.String
    Private _SRI_dobleTributacion As System.String
    Private _SRI_pagoSujetoRetencion As System.String
    '
    Private Function ajustarAncho(cadena As String, ancho As Integer) As String
        Dim sb As New System.Text.StringBuilder(New String(" "c, ancho))
        Return (cadena & sb.ToString()).Substring(0, ancho).Trim()
    End Function
    '
    Public Property IdFormasDePago() As System.String
        Get
            Return ajustarAncho(_IdFormasDePago, 3)
        End Get
        Set(Value As System.String)
            _IdFormasDePago = Value
        End Set
    End Property

    Public Property Descripcion() As System.String
        Get
            Return ajustarAncho(_Descripcion, 50)
        End Get
        Set(value As System.String)
            _Descripcion = value
        End Set
    End Property
    Public Property formadepago() As System.Int16
        Get
            Return _formadepago
        End Get
        Set(Value As System.Int16)
            _formadepago = Value
        End Set
    End Property
    Public Property NumeroDeCuotas() As System.Int16
        Get
            Return _NumeroDeCuotas
        End Get
        Set(Value As System.Int16)
            _NumeroDeCuotas = Value
        End Set
    End Property
    Public Property Institucion() As System.Boolean
        Get
            Return _Institucion
        End Get
        Set(Value As System.Boolean)
            _Institucion = Value
        End Set
    End Property
    Public Property tipoformapago() As System.Int16
        Get
            Return _tipoformapago
        End Get
        Set(Value As System.Int16)
            _tipoformapago = Value
        End Set
    End Property
    Public Property plazofv() As System.Byte
        Get
            Return _plazofv
        End Get
        Set(Value As System.Byte)
            _plazofv = Value
        End Set
    End Property
    Public Property DiasCuotaFijas() As System.Int16
        Get
            Return _DiasCuotaFijas
        End Get
        Set(Value As System.Int16)
            _DiasCuotaFijas = Value
        End Set
    End Property
    Public Property DiasCuotaVar0() As System.Int16
        Get
            Return _DiasCuotaVar0
        End Get
        Set(Value As System.Int16)
            _DiasCuotaVar0 = Value
        End Set
    End Property
    Public Property DiasCuotaVar1() As System.Int16
        Get
            Return _DiasCuotaVar1
        End Get
        Set(Value As System.Int16)
            _DiasCuotaVar1 = Value
        End Set
    End Property
    Public Property DiasCuotaVar2() As System.Int16
        Get
            Return _DiasCuotaVar2
        End Get
        Set(Value As System.Int16)
            _DiasCuotaVar2 = Value
        End Set
    End Property
    Public Property DiasCuotaVar3() As System.Int16
        Get
            Return _DiasCuotaVar3
        End Get
        Set(Value As System.Int16)
            _DiasCuotaVar3 = Value
        End Set
    End Property
    Public Property DiasCuotaVar4() As System.Int16
        Get
            Return _DiasCuotaVar4
        End Get
        Set(Value As System.Int16)
            _DiasCuotaVar4 = Value
        End Set
    End Property
    Public Property DiasCuotaVar5() As System.Int16
        Get
            Return _DiasCuotaVar5
        End Get
        Set(Value As System.Int16)
            _DiasCuotaVar5 = Value
        End Set
    End Property
    Public Property DiasCuotaVar6() As System.Int16
        Get
            Return _DiasCuotaVar6
        End Get
        Set(Value As System.Int16)
            _DiasCuotaVar6 = Value
        End Set
    End Property
    Public Property DiasCuotaVar7() As System.Int16
        Get
            Return _DiasCuotaVar7
        End Get
        Set(Value As System.Int16)
            _DiasCuotaVar7 = Value
        End Set
    End Property
    Public Property DiasCuotaVar8() As System.Int16
        Get
            Return _DiasCuotaVar8
        End Get
        Set(Value As System.Int16)
            _DiasCuotaVar8 = Value
        End Set
    End Property
    Public Property DiasCuotaVar9() As System.Int16
        Get
            Return _DiasCuotaVar9
        End Get
        Set(Value As System.Int16)
            _DiasCuotaVar9 = Value
        End Set
    End Property
    Public Property DiasCuotaVar10() As System.Int16
        Get
            Return _DiasCuotaVar10
        End Get
        Set(Value As System.Int16)
            _DiasCuotaVar10 = Value
        End Set
    End Property
    Public Property DiasCuotaVar11() As System.Int16
        Get
            Return _DiasCuotaVar11
        End Get
        Set(Value As System.Int16)
            _DiasCuotaVar11 = Value
        End Set
    End Property
    Public Property GeneraIngreso() As System.Int16
        Get
            Return _GeneraIngreso
        End Get
        Set(Value As System.Int16)
            _GeneraIngreso = Value
        End Set
    End Property
    Public Property CancelaFactura() As System.Int16
        Get
            Return _CancelaFactura
        End Get
        Set(Value As System.Int16)
            _CancelaFactura = Value
        End Set
    End Property
    Public Property Id_Contable() As System.String
        Get
            Return ajustarAncho(_Id_Contable, 15)
        End Get
        Set(Value As System.String)
            _Id_Contable = Value
        End Set
    End Property
    Public Property ContadoSri() As System.Boolean
        Get
            Return _ContadoSri
        End Get
        Set(Value As System.Boolean)
            _ContadoSri = Value
        End Set
    End Property
    Public Property Id_Contable2() As System.String
        Get
            Return ajustarAncho(_Id_Contable2, 15)
        End Get
        Set(Value As System.String)
            _Id_Contable2 = Value
        End Set
    End Property
    Public Property SRI_formaDePago() As System.String
        Get
            Return ajustarAncho(_SRI_formaDePago, 3)
        End Get
        Set(Value As System.String)
            _SRI_formaDePago = Value
        End Set
    End Property
    Public Property SRI_pagoLocExt() As System.String
        Get
            Return ajustarAncho(_SRI_pagoLocExt, 3)
        End Get
        Set(Value As System.String)
            _SRI_pagoLocExt = Value
        End Set
    End Property
    Public Property SRI_pagoPais() As System.String
        Get
            Return ajustarAncho(_SRI_pagoPais, 20)
        End Get
        Set(Value As System.String)
            _SRI_pagoPais = Value
        End Set
    End Property
    Public Property SRI_dobleTributacion() As System.String
        Get
            Return ajustarAncho(_SRI_dobleTributacion, 10)
        End Get
        Set(Value As System.String)
            _SRI_dobleTributacion = Value
        End Set
    End Property
    Public Property SRI_pagoSujetoRetencion() As System.String
        Get
            Return ajustarAncho(_SRI_pagoSujetoRetencion, 10)
        End Get
        Set(Value As System.String)
            _SRI_pagoSujetoRetencion = Value
        End Set
    End Property
    Private Shared cadenaConexion As String = ""
    Public Shared CadenaSelect As String = "SELECT * FROM FormasDePago"
    '
    Public Sub New()
    End Sub
    Public Sub New(conex As String)
        cadenaConexion = conex
    End Sub
    Private Shared Function row2FormasDePago(r As DataRow) As FormasDePago
        '
        Dim oFormasDePago As New FormasDePago With {
            .IdFormasDePago = r("IdFormasDePago").ToString(),
            .Descripcion = r("Descripcion").ToString(),
            .formadepago = System.Int16.Parse("0" & r("formadepago").ToString()),
            .NumeroDeCuotas = System.Int16.Parse("0" & r("NumeroDeCuotas").ToString())
        }
        Try
            oFormasDePago.Institucion = System.Boolean.Parse(r("Institucion").ToString())
        Catch
            oFormasDePago.Institucion = False
        End Try
        oFormasDePago.tipoformapago = System.Int16.Parse("0" & r("tipoformapago").ToString())
        oFormasDePago.plazofv = System.Byte.Parse("0" & r("plazofv").ToString())
        oFormasDePago.DiasCuotaFijas = System.Int16.Parse("0" & r("DiasCuotaFijas").ToString())
        oFormasDePago.DiasCuotaVar0 = System.Int16.Parse("0" & r("DiasCuotaVar0").ToString())
        oFormasDePago.DiasCuotaVar1 = System.Int16.Parse("0" & r("DiasCuotaVar1").ToString())
        oFormasDePago.DiasCuotaVar2 = System.Int16.Parse("0" & r("DiasCuotaVar2").ToString())
        oFormasDePago.DiasCuotaVar3 = System.Int16.Parse("0" & r("DiasCuotaVar3").ToString())
        oFormasDePago.DiasCuotaVar4 = System.Int16.Parse("0" & r("DiasCuotaVar4").ToString())
        oFormasDePago.DiasCuotaVar5 = System.Int16.Parse("0" & r("DiasCuotaVar5").ToString())
        oFormasDePago.DiasCuotaVar6 = System.Int16.Parse("0" & r("DiasCuotaVar6").ToString())
        oFormasDePago.DiasCuotaVar7 = System.Int16.Parse("0" & r("DiasCuotaVar7").ToString())
        oFormasDePago.DiasCuotaVar8 = System.Int16.Parse("0" & r("DiasCuotaVar8").ToString())
        oFormasDePago.DiasCuotaVar9 = System.Int16.Parse("0" & r("DiasCuotaVar9").ToString())
        oFormasDePago.DiasCuotaVar10 = System.Int16.Parse("0" & r("DiasCuotaVar10").ToString())
        oFormasDePago.DiasCuotaVar11 = System.Int16.Parse("0" & r("DiasCuotaVar11").ToString())
        oFormasDePago.GeneraIngreso = System.Int16.Parse("0" & r("GeneraIngreso").ToString())
        oFormasDePago.CancelaFactura = System.Int16.Parse("0" & r("CancelaFactura").ToString())
        oFormasDePago.Id_Contable = r("Id_Contable").ToString()
        Try
            oFormasDePago.ContadoSri = System.Boolean.Parse(r("ContadoSri").ToString())
        Catch
            oFormasDePago.ContadoSri = False
        End Try
        oFormasDePago.Id_Contable2 = r("Id_Contable2").ToString()
        oFormasDePago.SRI_formaDePago = r("SRI_formaDePago").ToString()
        oFormasDePago.SRI_pagoLocExt = r("SRI_pagoLocExt").ToString()
        oFormasDePago.SRI_pagoPais = r("SRI_pagoPais").ToString()
        oFormasDePago.SRI_dobleTributacion = r("SRI_dobleTributacion").ToString()
        oFormasDePago.SRI_pagoSujetoRetencion = r("SRI_pagoSujetoRetencion").ToString()
        '
        Return oFormasDePago
    End Function
    '
    ' asigna un objeto FormasDePago a la fila indicada
    Private Shared Sub FormasDePago2Row(oFormasDePago As FormasDePago, r As DataRow)
        ' asigna un objeto FormasDePago al dataRow indicado
        r("IdFormasDePago") = oFormasDePago.IdFormasDePago
        r("Descripcion") = oFormasDePago.Descripcion
        r("formadepago") = oFormasDePago.formadepago
        r("NumeroDeCuotas") = oFormasDePago.NumeroDeCuotas
        r("Institucion") = oFormasDePago.Institucion
        r("tipoformapago") = oFormasDePago.tipoformapago
        r("plazofv") = oFormasDePago.plazofv
        r("DiasCuotaFijas") = oFormasDePago.DiasCuotaFijas
        r("DiasCuotaVar0") = oFormasDePago.DiasCuotaVar0
        r("DiasCuotaVar1") = oFormasDePago.DiasCuotaVar1
        r("DiasCuotaVar2") = oFormasDePago.DiasCuotaVar2
        r("DiasCuotaVar3") = oFormasDePago.DiasCuotaVar3
        r("DiasCuotaVar4") = oFormasDePago.DiasCuotaVar4
        r("DiasCuotaVar5") = oFormasDePago.DiasCuotaVar5
        r("DiasCuotaVar6") = oFormasDePago.DiasCuotaVar6
        r("DiasCuotaVar7") = oFormasDePago.DiasCuotaVar7
        r("DiasCuotaVar8") = oFormasDePago.DiasCuotaVar8
        r("DiasCuotaVar9") = oFormasDePago.DiasCuotaVar9
        r("DiasCuotaVar10") = oFormasDePago.DiasCuotaVar10
        r("DiasCuotaVar11") = oFormasDePago.DiasCuotaVar11
        r("GeneraIngreso") = oFormasDePago.GeneraIngreso
        r("CancelaFactura") = oFormasDePago.CancelaFactura
        r("Id_Contable") = oFormasDePago.Id_Contable
        r("ContadoSri") = oFormasDePago.ContadoSri
        r("Id_Contable2") = oFormasDePago.Id_Contable2
        r("SRI_formaDePago") = oFormasDePago.SRI_formaDePago
        r("SRI_pagoLocExt") = oFormasDePago.SRI_pagoLocExt
        r("SRI_pagoPais") = oFormasDePago.SRI_pagoPais
        r("SRI_dobleTributacion") = oFormasDePago.SRI_dobleTributacion
        r("SRI_pagoSujetoRetencion") = oFormasDePago.SRI_pagoSujetoRetencion
    End Sub
    '
    ' crea una nueva fila y la asigna a un objeto FormasDePago
    Private Shared Sub nuevoFormasDePago(dt As DataTable, oFormasDePago As FormasDePago)
        Dim dr As DataRow = dt.NewRow()
        Dim oFp As FormasDePago = row2FormasDePago(dr)
        '
        oFp.IdFormasDePago = oFormasDePago.IdFormasDePago
        oFp.Descripcion = oFormasDePago.Descripcion
        oFp.formadepago = oFormasDePago.formadepago
        oFp.NumeroDeCuotas = oFormasDePago.NumeroDeCuotas
        oFp.Institucion = oFormasDePago.Institucion
        oFp.tipoformapago = oFormasDePago.tipoformapago
        oFp.plazofv = oFormasDePago.plazofv
        oFp.DiasCuotaFijas = oFormasDePago.DiasCuotaFijas
        oFp.DiasCuotaVar0 = oFormasDePago.DiasCuotaVar0
        oFp.DiasCuotaVar1 = oFormasDePago.DiasCuotaVar1
        oFp.DiasCuotaVar2 = oFormasDePago.DiasCuotaVar2
        oFp.DiasCuotaVar3 = oFormasDePago.DiasCuotaVar3
        oFp.DiasCuotaVar4 = oFormasDePago.DiasCuotaVar4
        oFp.DiasCuotaVar5 = oFormasDePago.DiasCuotaVar5
        oFp.DiasCuotaVar6 = oFormasDePago.DiasCuotaVar6
        oFp.DiasCuotaVar7 = oFormasDePago.DiasCuotaVar7
        oFp.DiasCuotaVar8 = oFormasDePago.DiasCuotaVar8
        oFp.DiasCuotaVar9 = oFormasDePago.DiasCuotaVar9
        oFp.DiasCuotaVar10 = oFormasDePago.DiasCuotaVar10
        oFp.DiasCuotaVar11 = oFormasDePago.DiasCuotaVar11
        oFp.GeneraIngreso = oFormasDePago.GeneraIngreso
        oFp.CancelaFactura = oFormasDePago.CancelaFactura
        oFp.Id_Contable = oFormasDePago.Id_Contable
        oFp.ContadoSri = oFormasDePago.ContadoSri
        oFp.Id_Contable2 = oFormasDePago.Id_Contable2
        oFp.SRI_formaDePago = oFormasDePago.SRI_formaDePago
        oFp.SRI_pagoLocExt = oFormasDePago.SRI_pagoLocExt
        oFp.SRI_pagoPais = oFormasDePago.SRI_pagoPais
        oFp.SRI_dobleTributacion = oFormasDePago.SRI_dobleTributacion
        oFp.SRI_pagoSujetoRetencion = oFormasDePago.SRI_pagoSujetoRetencion
        '
        FormasDePago2Row(oFp, dr)
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
        ' devuelve una tabla con los datos de la tabla FormasDePago
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("FormasDePago")
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
    Public Shared Function Buscar(sWhere As String) As FormasDePago
        Dim oFormasDePago As FormasDePago = Nothing
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("FormasDePago")
        Dim sel As String = "SELECT * FROM FormasDePago WHERE " & sWhere
        '
        da = New SqlDataAdapter(sel, cadenaConexion)
        da.Fill(dt)
        '
        If dt.Rows.Count > 0 Then
            oFormasDePago = row2FormasDePago(dt.Rows(0))
        End If
        Return oFormasDePago
    End Function
    '
    Public Function Actualizar() As String
        Dim sel As String = "SELECT * FROM FormasDePago WHERE IdFormasDePago = '" & Me.IdFormasDePago & "'"
        Return Actualizar(sel)
    End Function

    Public Function Actualizar(sel As String) As String
        ' En caso de error, devolverá la cadena empezando por ERROR.
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("FormasDePago")
        '
        cnn = New SqlConnection(cadenaConexion)
        da = New SqlDataAdapter(sel, cnn) With {
            .MissingSchemaAction = MissingSchemaAction.AddWithKey
        }
        '
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
            Return Crear()
        Else
            FormasDePago2Row(Me, dt.Rows(0))
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
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("FormasDePago")
        '
        cnn = New SqlConnection(cadenaConexion)
        da = New SqlDataAdapter(CadenaSelect, cnn) With {
            .MissingSchemaAction = MissingSchemaAction.AddWithKey
        }
        Dim cb As New SqlCommandBuilder(da)
        da.InsertCommand = cb.GetInsertCommand()
        Try
            da.Fill(dt)
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
        '
        nuevoFormasDePago(dt, Me)
        '
        Try
            da.Update(dt)
            dt.AcceptChanges()
            Return "Se ha creado un nuevo FormasDePago"
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
    End Function
    '
    Public Function Borrar() As String
        Dim sel As String = "SELECT * FROM FormasDePago WHERE IdFormasDePago = '" & Me.IdFormasDePago & "'"
        '
        Return Borrar(sel)
    End Function
    Public Function Borrar(sel As String) As String
        Dim cnn As SqlConnection
        Dim da As SqlDataAdapter
        Dim dt As New DataTable("FormasDePago")
        '
        cnn = New SqlConnection(cadenaConexion)
        da = New SqlDataAdapter(sel, cnn) With {
            .MissingSchemaAction = MissingSchemaAction.AddWithKey
        }
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

