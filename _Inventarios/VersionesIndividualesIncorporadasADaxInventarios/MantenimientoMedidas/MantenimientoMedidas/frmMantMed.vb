Imports System.Data.SqlClient

Public Class frmMantMed
    Dim conectarSys As New SqlConnection()
    Dim SYSEMP As New AdcDax.DaxSofSys
    Dim EMP As AdcDax.Empresa
    Dim strSys As String = ""
    Dim accion As String = "Nuevo"
    Dim cambios As Integer = 0
    Dim fila As Integer = 0
    Dim columna As Integer = 0
    Public TipoFuera As String = ""
    Private Sub conectarBDD()
        'Dim coneccion As daaxLib.DaxLibBases
        'If EMP.codigo = 0 Then MsgBox("No se ha conectado al servidor del sistema Adcom", MsgBoxStyle.Critical) : Me.Close()
        'coneccion = New daaxLib.DaxLibBases(SYSEMP.EmpresaAct.codigo, SYSEMP.EmpresaAct.Sistema, SYSEMP.EmpresaAct.PatAppl, "SQL")
        conectarSys.ConnectionString = varbleComun.VarCom.strConxSyscod
        strSys = varbleComun.VarCom.strConxSyscod
        'coneccion = Nothing
    End Sub

#Region "Datos Iniciales"
    Private Sub frmMantMed_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EMP = SYSEMP.EmpresaAct
        'TipoFuera = Command()
        conectarBDD()
        limpiar(Me)
        Bloquear(True)
        If TipoFuera > "" Then
            cargarDatos(TipoFuera)
            Bloquear(False)
        End If
    End Sub

    Private Sub limpiar(ByVal Obj As Object)
        txtCodigo.Text = ""
        txtDescripcion.Text = ""
        MALLA.Rows.Clear()
    End Sub
    Private Sub Bloquear(ByVal op As Boolean)
        btnAbrir.Enabled = op
        btnNuevo.Enabled = op
        btnSalir.Enabled = op
        btnGuardar.Enabled = Not op
        btnEliminar.Enabled = Not op
        btnCancelar.Enabled = Not op
        txtCodigo.Enabled = Not op
        txtDescripcion.Enabled = Not op
        MALLA.Enabled = Not op
    End Sub
#End Region

#Region "Abrir"
    Private Sub btnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrir.Click
        abrir()
    End Sub
    Private Sub abrir()
        Dim cod As String = ""
        Dim busk As New Buscar.frmBuscar
        cod = busk.Buscar(strSys, "select Abreviación,Descripcion from syscod where TipoReferencia='Medidas' and Abreviación<>'#'", "Abreviación", "Descripcion", "Consulta", "MEDIDAS")
        If cod <> "" Then
            cargarDatos(cod)
            Bloquear(False)
        End If
    End Sub
    Private Sub cargarDatos(ByVal cod As String)
        Dim s As New SysCod
        txtCodigo.Text = cod
        s.consultar("Medidas", cod, strSys)
        txtDescripcion.Text = s.Descripcion
        Dim cont As Integer = 0
        Dim cmd As New SqlCommand("select * from conversion where Cnv_DeMedida='" & cod & "'", conectarSys)
        Dim dat As SqlDataReader = Nothing
        If conectarSys.State = ConnectionState.Open Then conectarSys.Close()
        conectarSys.Open()
        dat = cmd.ExecuteReader()
        With MALLA
            While dat.Read
                .Rows.Add()
                'If Not IsDBNull(dat("Cnv_DeMedida")) Then .Rows(cont).Cells(0).Value = dat("Cnv_DeMedida")
                If Not IsDBNull(dat("Cnv_Amedida")) Then .Rows(cont).Cells(1).Value = dat("Cnv_Amedida")
                If Not IsDBNull(dat("Cnv_Multiplo")) Then .Rows(cont).Cells(0).Value = dat("Cnv_Multiplo")
                cont += 1
                accion = "Abrir"
            End While
        End With
        conectarSys.Close()

    End Sub
#End Region

#Region "Nuevo"
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Nuevo()
    End Sub
    Private Sub Nuevo()
        accion = "Nuevo"
        limpiar(Me)
        Bloquear(False)
        cambios = 0
    End Sub
    Private Sub txtCodigo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigo.LostFocus
        cargarDatos(txtCodigo.Text)
    End Sub
#End Region

#Region "Guardar"
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Guadar(strSys)
        If TipoFuera > "" Then Me.Close() : Me.Dispose()
    End Sub
    Private Sub Guadar(ByVal strS As String)
        If txtCodigo.Text = "" Then Exit Sub
        guardarSysCod(txtCodigo.Text, strSys)
        cancela()
    End Sub
    Private Sub guardarSysCod(ByVal cod As String, ByVal strSys As String)
        Dim s As New SysCod
        s.TipoReferencia = "Medidas"
        s.Abreviación = txtCodigo.Text
        s.Descripcion = txtDescripcion.Text
        If accion = "Nuevo" Then s.Guardar(strSys) Else s.Actualizar("Medidas", cod, strSys)
        guardarConv(cod, strSys)
    End Sub

    Private Sub guardarConv(ByVal cod As String, ByVal strSys As String)
        Dim c As New Conversion
        On Error Resume Next
        c.Eliminar(cod, strSys)
        c.Cnv_DeMedida = cod
        With MALLA
            For i = 0 To .RowCount - 2
                If .Rows(i).Cells(1).Value.ToString > "" And CDbl(.Rows(i).Cells(0).Value) <> 0 Then
                    c.Cnv_Amedida = CStr(.Rows(i).Cells(1).Value)
                    c.Cnv_Multiplo = CDbl(.Rows(i).Cells(0).Value)
                    c.Guardar(strSys)
                End If
            Next
        End With
    End Sub
#End Region

#Region "Eliminar"
    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Eliminar(txtCodigo.Text)
        limpiar(Me)
        Bloquear(True)
    End Sub

    Private Sub Eliminar(ByVal cod As String)
        If MsgBox("Esta seguro de que quiere borrar el registro?", MsgBoxStyle.YesNo) = vbYes Then
            Dim c As New Conversion
            Dim s As New SysCod
            c.Eliminar(CStr(cod), strSys)
            s.Eliminar("Medidas", CStr(cod), strSys)
        End If
    End Sub
#End Region

#Region "Cambios"
    Private Sub txtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.TextChanged
        cambios += 1
    End Sub

    Private Sub txtDescripcion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcion.KeyDown
        If e.KeyCode = Keys.Enter And txtCodigo.Text > "" Then cargarDatos(txtCodigo.Text)
    End Sub

    Private Sub txtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged
        cambios += 1
    End Sub

    Private Sub MALLA_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles MALLA.CellEnter
        fila = e.RowIndex
        columna = e.ColumnIndex
    End Sub

    Private Sub MALLA_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles MALLA.CellValueChanged
        cambios += 1
        If MALLA.Rows(fila).Cells(0) Is Nothing Then MALLA.Rows(fila).Cells(0).Value = txtCodigo.Text
    End Sub
#End Region

#Region "Cancelar/Salir"
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        CancelarSalir()
        If TipoFuera > "" Then Me.Close() : Me.Dispose()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        If cambios > 0 Then
            If MsgBox("Desea guardar los cambios?", MsgBoxStyle.YesNo) = vbYes Then
                Guadar(strSys)
            End If
        End If
        Saliendo()
    End Sub
    Private Sub CancelarSalir()
        If cambios > 0 Then
            If MsgBox("Desea guardar los cambios?", MsgBoxStyle.YesNo) = vbYes Then
                Guadar(strSys)
            End If
        End If
        cancela()
    End Sub
    Private Sub Saliendo()
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub cancela()
        limpiar(Me)
        Bloquear(True)
        accion = "Nuevo"
        cambios = 0
    End Sub
#End Region

    Private Sub MALLA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MALLA.KeyDown

        If e.KeyCode = Keys.F2 And columna = 1 Then
            Dim cod As String = ""
            Dim busk As New Buscar.frmBuscar
            cod = busk.Buscar(strSys, "select Abreviación,Descripcion from syscod where TipoReferencia='Medidas' and Abreviación<>'#'", "Abreviación", "Descripcion", "Consulta", "MEDIDAS")
            MALLA.Rows(fila).Cells(columna).Value = cod
        End If
    End Sub

    Private Sub MALLA_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MALLA.MouseLeave
        MALLA.EndEdit()
    End Sub

End Class

