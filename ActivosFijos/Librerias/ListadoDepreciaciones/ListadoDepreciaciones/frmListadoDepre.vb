Imports System.Data.SqlClient
Public Class frmListadoDepre
    Dim SYSEMP As New AdcDax.DaxsofSys
    Dim cad As String
    Dim opcion As String
    Private Sub Consulta(ByVal cod As String, ByVal clase As String, ByVal op As String)
        Dim conectar As New SqlConnection()
        Dim coneccion As New DaxLib.DaxLibBases
        coneccion.TipoBase = "10"
        conectar.ConnectionString = coneccion.StrAdcom
        Dim ssql As String
        ssql = "exec ACTFDEP_LISTADO '" & cod & "', '" & clase & "','" & op & "'"
        Dim bind As New BindingSource()
        Dim datS As New DataSet()
        Dim consulta As New SqlDataAdapter(ssql, conectar)
        consulta.Fill(datS, "AdcAcfDep")
        bind.DataMember = "AdcAcfDep"
        bind.DataSource = datS
        gridListado.DataSource = bind
        gridListado.Columns("Codigo").Frozen = True
        gridListado.Columns("Clase").Frozen = True
        gridListado.Columns("Año").Frozen = True
        gridListado.Columns("Codigo").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
        gridListado.Columns("Clase").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        gridListado.Columns("Año").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Dim formato As New FormatoMallas.FormatoMalla
        gridListado = formato.ConfigurarMalla(gridListado, "Consulta")
        gridListado.Columns("Total").DefaultCellStyle.BackColor = Color.Beige
        gridListado.Columns("Año").DefaultCellStyle.Format = "g"

    End Sub
    Public Sub cargarGrid(ByVal codigo As String, ByVal op As String)
        opcion = op
        Consulta(codigo, "TD", op)
        Me.ShowDialog()
    End Sub
    Private Sub cargarCombo()
        cboTipo.Items.Add("Todas")
        cboTipo.Items.Add("Financiera")
        cboTipo.Items.Add("Tributaria")
        cboTipo.SelectedIndex = 0
    End Sub
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Dispose()
    End Sub

    Private Sub frmListadoDepre_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarCombo()
        cboTipo.ToolTipText = "Clase de Depreciación"
        cboTipo.AutoSize = True
    End Sub

    Private Sub cboTipo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipo.TextChanged
        Dim cod As String
        cod = gridListado.Rows(0).Cells("Codigo").Value.ToString
        If cboTipo.Text = "Todas" Then
            Consulta(cod, "TD", opcion)
        ElseIf cboTipo.Text = "Financiera" Then
            Consulta(cod, "F", opcion)
        ElseIf cboTipo.Text = "Tributaria" Then
            Consulta(cod, "T", opcion)
        End If
    End Sub


    Private Sub ImprimirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirToolStripMenuItem.Click
        Dim imp As New DataGridViewPrinterApplication1.frmMain
        imp.imprimir(gridListado, "Listado de Depreciaciones", , SYSEMP.EmpresaAct.nombre)
    End Sub

    Private Sub EnviarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarAExcelToolStripMenuItem.Click
        Dim exp As New ExportarGrid.Form1
        exp.Exportar(gridListado, "E", SYSEMP.EmpresaAct.nombre, "Listado de Depreciaciones")
    End Sub

    Private Sub EnviarAWordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarAWordToolStripMenuItem.Click
        Dim exp As New ExportarGrid.Form1
        exp.Exportar(gridListado, "W", SYSEMP.EmpresaAct.nombre, "Listado de Depreciaciones")
    End Sub

    Private Sub EnviarAPdfToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarAPdfToolStripMenuItem.Click
        Dim exp As New ExportarGrid.Form1
        exp.Exportar(gridListado, "P", SYSEMP.EmpresaAct.nombre, "Listado de Depreciaciones")
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        btnImprimir.ShowDropDown()
    End Sub
End Class
