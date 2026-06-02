Imports System.Data
Imports System.Data.SqlClient
Public Class BuscarAcf
    Dim conectarBDD As New SqlConnection()
    Dim tabla As New DataSet
    Dim sSql, codACf, bandera As String

    Private Sub FrmBuscarActivo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim coneccion As New DaxLib.DaxLibBases
        coneccion.TipoBase = "10"
        conectarBDD.ConnectionString = coneccion.StrAdcom
        cargarDatos()
    End Sub

    Private Sub cargarDatos()
        Dim order As String
        Dim sucursal As String
        Dim depar As String
        Dim secc As String
        Dim contenga As String
        Dim solocompuesto As String
        contenga = ""
        sSql = ""
        order = ""
        sucursal = ""
        depar = ""
        secc = ""
        solocompuesto = ""
        If optCodigo.Checked = True Then
            order = " order by codigo"
        Else
            order = " order by nombre"
        End If
        If txtSucursal.Text = "" Then
            sucursal = ""
        Else
            sucursal = " and ubicasucursal='" & txtSucursal.Text & "'"
        End If
        If Trim(txtDpto.Text) = "" Then
            depar = ""
        Else
            depar = " and ubicadepartamento='" & txtDpto.Text & "'"
        End If
        If Trim(txtSeccion.Text) = "" Then
            secc = ""
        Else
            secc = " and ubicaseccion='" & txtSeccion.Text & "'"
        End If
        If Trim(txtCodigo.Text) <> "" Then
            If conInicial.Checked Then
                contenga = " and codigo like '" & txtCodigo.Text & "%' "
            Else
                contenga = " and codigo like '%" & txtCodigo.Text & "%' "
            End If

        End If

        If bandera = "Principal" Then solocompuesto = " and EsComponente = 0 "
        If Trim(txtNombre.Text) <> "" Then contenga = " and nombre like '" & txtNombre.Text & "%' "
        sSql = " select codigo, nombre from adcacf where codigo <>'' " & solocompuesto & depar & secc & contenga & order
        Try
            conectarBDD.Open()
            Dim Cons As New BindingSource()
            Dim datos As New DataSet()
            Dim dataAd As New SqlDataAdapter(sSql, conectarBDD)
            dataAd.Fill(datos, "AdcAcf")
            Cons.DataSource = datos
            Cons.DataMember = "AdcAcf"
            dgListaAct.DataSource = Cons
            conectarBDD.Close()
            Dim formato As New FormatoMallas.FormatoMalla
            dgListaAct = formato.ConfigurarMalla(dgListaAct, "Busqueda")
        Catch ex As Exception
            MsgBox("Error al consultar")
        End Try

    End Sub

    Private Sub txtCodigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown
        If e.KeyCode = 13 Then
            cargarDatos()
        End If

    End Sub

    Private Sub txtNombre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombre.KeyDown
        If e.KeyCode = 13 Then
            cargarDatos()
        End If
    End Sub

    Private Sub dgListaAct_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgListaAct.KeyDown
        If e.KeyCode = 13 Then
            Dim fila As Long
            If dgListaAct.RowCount() > 0 Then
                fila = dgListaAct.SelectedCells(0).RowIndex.ToString()
                codACf = dgListaAct.Rows(fila).Cells(0).Value.ToString()
            Else
                codACf = ""
            End If
            Me.Dispose()
        End If
    End Sub
    Private Sub dgListaAct_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgListaAct.CellDoubleClick
        Dim fila As Long
        If dgListaAct.RowCount() > 0 Then
            fila = dgListaAct.SelectedCells(0).RowIndex.ToString()
            codACf = dgListaAct.Rows(fila).Cells(0).Value.ToString()
        Else
            codACf = ""
        End If
        Me.Dispose()
    End Sub
    Public Function Cargar(ByVal ban As String) As String
        bandera = ban
        Dim conector As New DaxLib.DaxLibBases
        conector.TipoBase = "10"
        conectarBDD.ConnectionString = conector.StrAdcom
        Me.ShowDialog()
        Return codACf
    End Function
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        codACf = ""
        Me.Dispose()
    End Sub

    Private Sub txtNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged
        If conInicial.Checked Then cargarDatos()
    End Sub

    Private Sub btnDpto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDpto.Click
        Dim busk As New Syscod.ManSysnetClass
        Dim codigo As String = ""
        Dim nombre As String = ""
        txtDpto.Text = busk.BuscarReferencia("Departamento", codigo, nombre)
        txtDpto.Text = nombre
        busk = Nothing
    End Sub

    Private Sub btnSeccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeccion.Click
        Dim busk As New Syscod.ManSysnetClass
        Dim codigo As String = ""
        Dim nombre As String = ""
        txtSeccion.Text = busk.BuscarReferencia("Seeción", codigo, nombre)
        txtSeccion.Text = nombre
        busk = Nothing
    End Sub
    Private Sub btnSucursal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSucursal.Click
        Dim busk As New FrmConsDptoSecc()
        Dim res(2) As String
        busk.GroupBox1.Enabled = False
        busk.txtNombre.Enabled = False
        res = busk.Cargar("Sucursales")
        txtSucursal.Text = res(0)
        busk.Dispose()
        txtDpto.Focus()
    End Sub

End Class