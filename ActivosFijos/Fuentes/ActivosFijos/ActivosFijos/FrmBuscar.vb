Imports System.Data
Imports System.Data.SqlClient
Imports ActivosFijos
Imports MantenimientoAF
Public Class FrmBuscar

    'VARIABLES DE CONEXION
    Dim conectarBDD As New SqlConnection("server=SISTEMAS\SQLEXPRESS;user id=sa;password=123qweASDZXC;database=BdAdcomDxSistemas;pooling=false")
    Dim tabla As New DataSet

    Dim sSql ,codACf As String

    Public Sub cargarDatos()
        Dim order, sucursal, depar As String
        Dim secc, cuenta, contenga As String
        contenga = ""
        sSql = ""
        order = ""
        sucursal = ""
        depar = ""
        secc = ""
        If optCodigo.Checked = True Then
            order = " order by codigo"
        Else
            order = " order by nombre"
        End If
        If Trim(txtIdentCont.Text) = "" Then
            cuenta = ""
        Else
            cuenta = " and CtaContable1='" & txtIdentCont.Text & "'"
        End If
        If cboSucursal.SelectedItem = "" Then
            sucursal = ""
        Else
            sucursal = " and ubicasucursal='" & cboSucursal.SelectedItem & "'"
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
        If Trim(txtCodigo.Text) <> "" Then contenga = " and codigo like '" & txtCodigo.Text & "%' "
        If Trim(txtNombre.Text) <> "" Then contenga = " and nombre like '" & txtNombre.Text & "%' "
        sSql = " select * from adcacf where codigo<>'' " & cuenta & depar & secc & contenga & order
    End Sub
    Public Sub ConsultarActivo()
        Dim Cons As New BindingSource()
        Dim datos As New DataSet()
        Dim dataAd As New SqlDataAdapter(sSql, conectarBDD)
        dataAd.Fill(datos, "AdcAcf")
        Cons.DataSource = datos
        Cons.DataMember = "AdcAcf"
        gridBuscarActivos.DataSource = Cons
        Me.ShowDialog()
    End Sub
    Private Sub FrmBuscar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarDatos()
        ConsultarActivo()
    End Sub

    Private Sub txtCodigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown
        If e.KeyCode = 13 Then
            cargarDatos()
            ConsultarActivo()
        End If
    End Sub

    Private Sub txtNombre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombre.KeyDown
        If e.KeyCode = 13 Then
            cargarDatos()
            ConsultarActivo()
        End If
    End Sub
    Private Sub gridBuscarActivos_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridBuscarActivos.CellDoubleClick
        Dim fila As Long
        If gridBuscarActivos.RowCount() > 0 Then
            fila = gridBuscarActivos.SelectedCells(0).RowIndex.ToString()
            codACf = gridBuscarActivos.Rows(fila).Cells(0).Value.ToString()
        Else
            codACf = ""
        End If
        Me.Dispose()
    End Sub

    Public Function ConsExt() As String
        Me.ShowDialog()
        Return codACf
    End Function
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Dispose()
    End Sub
End Class