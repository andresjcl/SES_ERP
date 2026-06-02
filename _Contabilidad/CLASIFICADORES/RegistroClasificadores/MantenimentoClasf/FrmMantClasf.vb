Imports System.Data.SqlClient

Friend Class FrmMantClasf
    Friend strcon As String = ""
    Friend strsys As String = ""
    Dim numFil As Integer = 0, numCol As Integer = 0
    Dim ClasfPadre As String = ""
    Dim existe As Boolean = False
    Dim cambios As Integer = 0

#Region "Datos Iniciales"
    Private Sub FrmMantClasf_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarCombo()
        cboTipo.SelectedIndex = 0
    End Sub
#End Region

#Region "Combos"
    Private Sub CargarCombo()
        'Dim datS As New DataSet()
        'Dim datA As New SqlDataAdapter("select nombre from adcclasfctb", conectar)
        'If conectar.State = ConnectionState.Open Then conectar.Close()
        'conectar.Open()
        'Data.Fill(datS, "Datos")
        cboTipo.DataSource = SysEmpDatt.SqlDatos.leerTablaAdcom("select nombre from adcclasfctb")
        cboTipo.ValueMember = "nombre"
        cboTipo.DisplayMember = "nombre"
        ' conectar.Close()
        cboTipo.SelectedIndex = 1
    End Sub
    Private Sub cboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged
        consultarClasif(cboTipo.SelectedValue.ToString)
        cambios = 0
    End Sub
    Private Sub consultarClasif(ByVal tipoClasf As String)
        ClasfPadre = "" : malla.Rows.Clear()
        If malla.ColumnCount = 3 Then malla.Columns.RemoveAt(2)
        TienePadre(tipoClasf)
        Dim cont As Integer = 0
        'Dim cmd As New SqlCommand("select * from syscod where TipoReferencia='" & tipoClasf & "' and Abreviación<>'#'", conectarSys)
        Dim dat As SqlDataReader = SysEmpDatt.SqlDatos.leerBaseDaxsys("select * from syscod where TipoReferencia='" & tipoClasf & "' and Abreviación<>'#'")
        'If conectarSys.State = ConnectionState.Open Then conectarSys.Close()
        'conectarSys.Open()
        'dat = cmd.ExecuteReader()
        With malla
            While dat.Read
                .Rows.Add()
                If Not IsDBNull(dat("Abreviación")) Then .Rows(cont).Cells(0).Value = dat("Abreviación")
                If Not IsDBNull(dat("Descripcion")) Then .Rows(cont).Cells(1).Value = dat("Descripcion")
                If .ColumnCount = 3 Then If Not IsDBNull(dat("Caracteristica1")) Then .Rows(cont).Cells(2).Value = dat("Caracteristica1")
                cont += 1
            End While
        End With
        'conectarSys.Close()
    End Sub
    Private Sub TienePadre(ByVal tipoCl As String)
        'Dim cmd As New SqlCommand("select Padre  from adcclasfctb where nombre='" & tipoCl & "'", conectar)
        Dim dat As SqlDataReader = Nothing
        'If conectar.State = ConnectionState.Open Then conectar.Close()
        'conectar.Open()
        dat = SysEmpDatt.SqlDatos.leerBaseAdcom("select Padre  from adcclasfctb where nombre='" & tipoCl & "'")
        If dat.Read Then
            If Not IsDBNull(dat(0)) Then malla.Columns.Add("Padre", "Padre") : ClasfPadre = CStr(dat(0))
        End If
        'conectar.Close()
    End Sub
#End Region

#Region "Malla"
    Private Sub malla_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles malla.CellEnter
        numFil = e.RowIndex
        numCol = e.ColumnIndex
    End Sub

    Private Sub malla_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles malla.CellValueChanged
        cambios += 1
    End Sub

    Private Sub malla_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles malla.RowsRemoved
        cambios += 1
    End Sub

    Private Sub malla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles malla.KeyDown
        With malla
            If .ColumnCount = 3 Then
                If e.KeyCode = Keys.F2 Then
                    Dim busk As New Buscar.frmBuscar
                    .Rows(CInt(numFil)).Cells(numCol).Value = busk.Buscar(strsys, "select Abreviación,Descripcion from syscod where TipoReferencia ='" & ClasfPadre & "' and Abreviación<>'#' ", "Abreviación", "Descripcion", "Consulta", "CLASIFICADOR PADRE - " & ClasfPadre.ToUpper)
                End If
            End If
        End With
    End Sub

    Private Sub malla_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles malla.MouseLeave
        malla.EndEdit()
    End Sub
#End Region

#Region "Guardar"
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        guardar(CStr(cboTipo.SelectedValue), strsys)
        malla.ClearSelection()
    End Sub
    Private Sub guardar(ByVal tipo As String, ByVal strsysc As String)
        Dim cl As New Clasificadores
        cl.Eliminar(tipo, "", strsysc)
        cl.TipoReferencia = tipo
        With malla
            For i = 0 To .RowCount - 2
                cl.Abreviación = CStr(.Rows(i).Cells(0).Value)
                cl.Descripcion = CStr(.Rows(i).Cells(1).Value)
                If malla.ColumnCount = 3 Then cl.Caracteristica1 = CStr(.Rows(i).Cells(2).Value)
                cl.Guardar(strsysc)
            Next
        End With
    End Sub
#End Region

#Region "Cancelar\Salir"
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Cancelar()
        consultarClasif(CStr(cboTipo.SelectedValue))
        cambios = 0
        malla.ClearSelection()
    End Sub
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Cancelar()
        Me.Dispose()
    End Sub
    Private Sub Cancelar()
        If cambios > 0 Then
            If MsgBox("Desea guardar los cambios?", MsgBoxStyle.YesNo) = vbYes Then
                guardar(CStr(cboTipo.SelectedValue), strsys)
            End If
        End If
    End Sub
#End Region

End Class
