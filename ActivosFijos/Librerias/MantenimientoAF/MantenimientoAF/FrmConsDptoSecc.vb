Imports System.Data
Imports System.Data.SqlClient
Public Class FrmConsDptoSecc

    Public titulo As String
    Dim sSql As String
    Dim conect As New SqlConnection() '"server=SISTEMAS\SQLEXPRESS;user id=sa;password=123qweASDZXC;database=DaxSys;pooling=false")
    Dim conect1 As New SqlConnection() '"server=SISTEMAS\SQLEXPRESS;user id=sa;password=123qweASDZXC;database=BdAdcomDxSistemas;pooling=false")
    Dim respuesta(2) As String
    Dim cod, nombre As String

    Private Sub FrmConsDptoSecc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim condax As New DaxLib.DaxLibBases
        condax.TipoBase = "10"
        conect.ConnectionString = condax.StrDaxsys
        conect1.ConnectionString = condax.StrAdcom

        If titulo = "Responsable" Then
            Me.Text = titulo
            sSql = "Select Codigo, NombreImpresion as Nombre from Identificacion where EsEmpleado=1 order by Apellidos"
            Consultar(conect1)
        ElseIf titulo = "Aseguradora" Then
            Me.Text = titulo
            sSql = "Select Codigo, NombreImpresion as Nombre from Identificacion where EsProveedor=1 order by NombreImpresion"
            Consultar(conect1)
        ElseIf titulo = "Cuenta" Then
            Me.Text = titulo
            sSql = "Select Cta_Codigo as Codigo, Cta_Nombre as Nombre from AdcCta order by Cta_Codigo"
            Consultar(conect1)
        ElseIf titulo = "Sucursales" Then
            Me.Text = titulo
            sSql = "Select distinct CodSucursal as Sucursal from sys_Sucursales"
            Consultar(conect)
        ElseIf titulo = "Centro Costo" Then
            Me.Text = titulo
            sSql = "Select CCO_id as Codigo,CCO_Nombre as Nombre from AdcCcosto"
            Consultar(conect1)
        Else
            Me.Text = titulo
            sSql = "Select Abreviación, Descripcion from Syscod where TipoReferencia='" & titulo & "'"
            Consultar(conect)
        End If

    End Sub
    Public Sub Datos()
        Dim cadena As String
        Dim cadena1 As String
        cadena = ""
        cadena1 = ""
        If Trim(txtCodigo.Text <> "") Then cadena = "and Abreviación like'" & txtCodigo.Text & "%' "
        If Trim(txtNombre.Text <> "") Then cadena = "and Descripcion like'" & txtNombre.Text & "%' "
        If optCodigo.Checked = True Then cadena1 = " order by Abreviación"
        If optNombre.Checked = True Then cadena1 = " order by Descripcion"
        sSql = "Select Abreviación, Descripcion from Syscod where TipoReferencia='" & titulo & "' " & cadena & cadena1
    End Sub
    Public Sub DatosResp()
        Dim cadena As String
        Dim cadena1 As String
        cadena = ""
        cadena1 = ""
        If Trim(txtCodigo.Text <> "") Then cadena = " and Codigo like'" & txtCodigo.Text & "%' "
        If Trim(txtNombre.Text <> "") Then cadena = " and NombreImpresion like'" & txtNombre.Text & "%' "
        If optCodigo.Checked = True Then cadena1 = " order by Codigo"
        If optNombre.Checked = True Then cadena1 = " order by NombreImpresion"
        sSql = "Select Codigo, NombreImpresion as Nombre from Identificacion where EsEmpleado=1" & cadena & cadena1
    End Sub
    Public Sub DatosAseg()
        Dim cadena As String
        Dim cadena1 As String
        cadena = ""
        cadena1 = ""
        If Trim(txtCodigo.Text <> "") Then cadena = " and Codigo like'" & txtCodigo.Text & "%' "
        If Trim(txtNombre.Text <> "") Then cadena = " and NombreImpresion like'" & txtNombre.Text & "%' "
        If optCodigo.Checked = True Then cadena1 = " order by Codigo"
        If optNombre.Checked = True Then cadena1 = " order by NombreImpresion"
        sSql = "Select Codigo, NombreImpresion as Nombre from Identificacion where EsProveedor=1" & cadena & cadena1
    End Sub
    Public Sub DatosCta()
        Dim cadena As String
        Dim cadena1 As String
        cadena = ""
        cadena1 = ""
        If Trim(txtCodigo.Text <> "") Then cadena = "where Cta_codigo like'" & txtCodigo.Text & "%' "
        If Trim(txtNombre.Text <> "") Then cadena = "where Cta_Nombre like'" & txtNombre.Text & "%' "
        If optCodigo.Checked = True Then cadena1 = " order by Cta_codigo"
        If optNombre.Checked = True Then cadena1 = " order by Cta_Nombre"
        sSql = "Select Cta_codigo as Codigo, Cta_Nombre as Nombre from AdcCta " & cadena & cadena1
    End Sub
    Public Sub DatosSucursal()
        Dim cadena As String
        Dim cadena1 As String
        cadena = ""
        cadena1 = ""
        If Trim(txtCodigo.Text <> "") Then cadena = "where CodSucursal like'" & txtCodigo.Text & "%' "
        If optCodigo.Checked = True Then cadena1 = " order by CodSucursal"
        sSql = "Select distinct CodSucursal as Sucursal from sys_Sucursales " & cadena
    End Sub
    Public Sub DatosCCosto()
        Dim cadena As String
        Dim cadena1 As String
        cadena = ""
        cadena1 = ""
        If Trim(txtCodigo.Text <> "") Then cadena = "where CCO_id like'" & txtCodigo.Text & "%' "
        If Trim(txtNombre.Text <> "") Then cadena = "where CCO_Nombre like'" & txtNombre.Text & "%' "
        If optCodigo.Checked = True Then cadena1 = " order by CCO_id"
        If optNombre.Checked = True Then cadena1 = " order by CCO_Nombre"
        sSql = "Select CCO_id as Codigo, CCO_Nombre as Nombre from AdcCcosto" & cadena & cadena1
    End Sub
    Public Sub Consultar(ByVal con As SqlConnection)
        Dim Cons As New BindingSource()
        Dim datos As New DataSet()
        Dim dataAd As New SqlDataAdapter(sSql, con)
        dataAd.Fill(datos, "Syscod")
        Cons.DataSource = datos
        Cons.DataMember = "Syscod"
        gridConsulta.DataSource = Cons
        Dim formato As New FormatoMallas.FormatoMalla
        gridConsulta = formato.ConfigurarMalla(gridConsulta, "Busqueda")
    End Sub

    Private Sub txtCodigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown
        If e.KeyCode = 13 Then
            If titulo = "Responsable" Then
                DatosResp()
                Consultar(conect1)
            ElseIf titulo = "Aseguradora" Then
                DatosAseg()
                Consultar(conect1)
            ElseIf titulo = "Cuenta" Then
                DatosCta()
                Consultar(conect1)
            ElseIf titulo = "Sucursales" Then
                DatosSucursal()
                Consultar(conect)
            ElseIf titulo = "Centro Costo" Then
                DatosCCosto()
                Consultar(conect1)
            Else
                Datos()
                Consultar(conect)
            End If
        End If
    End Sub
    Private Sub txtNombre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombre.KeyDown
        If e.KeyCode = 13 Then
            If titulo = "Responsable" Then
                DatosResp()
                Consultar(conect1)
            ElseIf titulo = "Cuenta" Then
                DatosCta()
                Consultar(conect1)
            ElseIf titulo = "Centro Costo" Then
                DatosCCosto()
                Consultar(conect1)
            Else
                Datos()
                Consultar(conect)
            End If
        End If
    End Sub

    Private Sub gridConsulta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridConsulta.KeyDown
        If e.KeyCode = 13 Then
            Dim fila As Long
            cod = ""
            nombre = ""
            If gridConsulta.RowCount() > 0 Then
                fila = gridConsulta.SelectedCells(0).RowIndex
                If titulo <> "Sucursales" Then
                    cod = gridConsulta.Rows(fila).Cells(0).Value.ToString()
                    nombre = gridConsulta.Rows(fila).Cells(1).Value.ToString()
                Else
                    cod = gridConsulta.Rows(fila).Cells(0).Value.ToString()
                End If
            Else
                cod = ""
                nombre = ""
            End If
            respuesta(0) = cod
            respuesta(1) = nombre
            Me.Dispose()
        End If
    End Sub

    Private Sub gridConsulta_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridConsulta.CellDoubleClick
        Dim fila As Long
        cod = ""
        nombre = ""
        If gridConsulta.RowCount() > 0 Then
            fila = gridConsulta.SelectedCells(0).RowIndex
            If titulo <> "Sucursales" Then
                cod = gridConsulta.Rows(fila).Cells(0).Value.ToString()
                nombre = gridConsulta.Rows(fila).Cells(1).Value.ToString()
            Else
                cod = gridConsulta.Rows(fila).Cells(0).Value.ToString()
            End If
        Else
            cod = ""
            nombre = ""
        End If
        respuesta(0) = cod
        respuesta(1) = nombre
        Me.Dispose()
    End Sub
    Public Function Cargar(ByVal tit As String) As String()
        titulo = tit
        Me.ShowDialog()
        Return respuesta
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        respuesta(0) = ""
        respuesta(1) = ""
        Me.Dispose()
    End Sub
End Class