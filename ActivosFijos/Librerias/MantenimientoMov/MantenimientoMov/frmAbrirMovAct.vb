Imports System.Data.SqlClient
Imports MantenimientoAF
Public Class frmAbrirMovAct
    Dim conectarBDD As New SqlConnection()
    Dim DatosActivo As New ClassMov
    Private Sub frmAbrirMovAct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim coneccion As New DaxLib.DaxLibBases
        coneccion.TipoBase = "10"
        conectarBDD.ConnectionString = coneccion.StrAdcom
        opcionesConsulta()
        txtCodigo.Focus()
    End Sub
    
    'METODO PARA OBTENER LAS OPCIONES DE CONSULTA
    Private Sub opcionesConsulta()
        Dim sucursal = "", depto = "", seccion = "", codigo = "", numero As String = ""
        Dim ordenar = "", op As String = ""
        If txtSucursal.Text <> "" Then
            sucursal = " and NVSucursalNueva='" & txtSucursal.Text & "'"
        Else
            sucursal = ""
        End If
        If txtDpto.Text <> "" Then
            depto = " and NvDepartamentoNvo='" & txtDpto.Text.ToString() & "'"
        Else
            depto = ""
        End If
        If txtSeccion.Text <> "" Then
            seccion = " and NvSeccionNvo='" & txtSeccion.Text.ToString() & "'"
        Else
        End If
        If optCodigo.Checked = True Then
            ordenar = " order by AdcAcfNov.Codigo"
        ElseIf optNumero.Checked = True Then
            ordenar = " order by Doc_numero"
        End If
        If txtCodigo.Text <> "" Then
            codigo = "and AdcAcf.Codigo like '" & txtCodigo.Text & "%'"
        Else : codigo = ""
        End If
        If txtDetalle.Text <> "" Then
            numero = "and Doc_numero like '" & txtDetalle.Text & "%'"
        End If
        op = codigo & numero & sucursal & depto & seccion & ordenar
        consultar(op)
    End Sub
    'METODO PARA CONSULTAR DATOS
    Private Sub consultar(ByVal opciones As String)
        Dim ssql As String = ""
        ssql = "select AdcAcfNov.Codigo,adcacf.Nombre ,doc_sucursal as Sucursal,Opc_documento as Documento,Doc_numero as Numero,FechaDocumento as Fecha"
        ssql += " from AdcAcf "
        ssql += " right join AdcAcfNov on(adcacf.Codigo = AdcAcfNov.Codigo )"
        ssql += " where isnull(EsComponente,0) = 0 and isnull(adcacf.Codigo,'') > '' " & opciones
        Dim datS As New DataTable()
        Dim datAd As New SqlDataAdapter(ssql, varbleComun.VarCom.strConxAdcom)
        datAd.Fill(datS)
        gridListado.DataSource = datS
        Dim form As New FormatoMallas.FormatoMalla
        form.ConfigurarMalla(gridListado, "Busqueda")
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Dispose()
    End Sub

    Private Sub txtCodigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown
        If e.KeyCode = 13 Then
            opcionesConsulta()
        End If
    End Sub

    Private Sub txtNumero_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDetalle.KeyDown
        If e.KeyCode = 13 Then
            opcionesConsulta()
        End If
    End Sub
    Public Function Cargar() As ClassMov
        Me.ShowDialog()
        Return DatosActivo
    End Function
    Private Sub gridListado_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridListado.CellDoubleClick
        Dim row As DataGridViewRow = gridListado.CurrentRow()
        With DatosActivo
            .CodigoActivo = row.Cells("Codigo").Value.ToString()
            .DocSucursal = row.Cells("Sucursal").Value.ToString()
            .Doc_numero = row.Cells("Numero").Value.ToString()
            .Opc_documento = row.Cells("Documento").Value.ToString()
        End With
        Me.Dispose()
    End Sub

    Private Sub btnDepto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDepto.Click
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
        txtSeccion.Text = busk.BuscarReferencia("Sección", codigo, nombre)
        txtSeccion.Text = nombre
        busk = Nothing
    End Sub

    Private Sub btnSucursal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSucursal.Click
        Dim busk As New FrmConsDptoSecc()
        Dim res(2) As String
        res = busk.Cargar("Sucursales")
        txtSucursal.Text = res(0)
        busk.Dispose()
    End Sub

End Class