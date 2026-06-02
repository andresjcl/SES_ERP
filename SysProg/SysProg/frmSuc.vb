Imports System.Data.SqlClient
Imports SysEmpDatt


Public Class frmSuc
    Dim codSuc As String = ""
    Dim carga As Boolean = False
    Dim ElNombre As String
#Region "Datos Iniciales"
    Private Sub frmSuc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        carga = True
        llenarLista(StrCon, DatosUsuario.Identifica, datosEmpresa.codEmpresa)
        carga = False
    End Sub

    Private Sub llenarLista(ByVal conect As SqlConnection, ByVal usu As String, ByVal idEmp As Integer)
        Dim str As New SqlConnection()
        Dim ssql As String = ""
        str = conect
        If UCase(usu) = "ADMINISTRADOR" Or UCase(usu) = "CONTROL" Then
            ssql = "select S.SUC_CODIGO, s.Suc_Nombre  from Emp_Suc s where S.EMP_CODIGO='" & idEmp & "' "
        Else
            ssql = "select codsucursal AS SUC_CODIGO, s.Suc_Nombre "
            ssql += " from sys_Sucursales left join Emp_Suc s On(CodSucursal=Suc_Codigo) where IdUsuario ='" & usu & "' and IdEmpresa=" & idEmp
            ssql += " and isnull(CodSucursal,'') <> '' group by CodSucursal,s.Suc_Nombre "
        End If
        Dim datS As New DataTable
        Dim datA As New SqlDataAdapter(ssql, str)
        str.Open()
        datA.Fill(datS)
        lst.DataSource = datS
        lst.DisplayMember = "Suc_Nombre"
        lst.ValueMember = "SUC_CODIGO"
        str.Close()
        lst.ClearSelected()
    End Sub
#End Region

#Region "Conectar"
    Private Sub btnConectar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConectar.Click
        SysEmpDatt.ManejoDatosEmpresa.cargarSucursalYbodegaCambio(codSuc)
        Me.Dispose()
    End Sub
    Private Sub lst_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lst.SelectedIndexChanged
        If carga = True Then Exit Sub
        codSuc = lst.SelectedValue.ToString
        ElNombre = lst.Text
    End Sub
#End Region

#Region "Salir"
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        codSuc = ""
        Me.Dispose()
    End Sub
#End Region

    Public Function CmbSuc(ByVal Str As String, ByRef Nombre As String) As String
        StrCon.ConnectionString = Str
        'StrCon.Open()
        Me.ShowDialog()
        Nombre = ElNombre
        Return codSuc
    End Function


End Class