Imports System.Data.SqlClient
Public Class FrmComponentes
    Dim SYSEMP As New AdcDax.DaxsofSys
    Dim codigoAct, codACf As String
    Dim conectar As New SqlConnection()
    Dim posX, posY As Integer

    Private Sub FrmComponentes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim coneccion As New DaxLib.DaxLibBases
        coneccion.TipoBase = "10"
        conectar.ConnectionString = coneccion.StrAdcom
        CargarComponentes(codigoAct)
    End Sub
    Public Sub cargarGrid(ByVal codigo As String)
        codigoAct = codigo
        'CargarComponentes(codigo)
        Me.ShowDialog()
    End Sub
    Private Sub CargarComponentes(ByVal cod As String)
        Dim ssql As String = "select act.TipoActivo,act.Codigo,act.Nombre,act.Cantidad,act.FecIngreso,act.CostoIngreso,act.ValorResidual,dep.ClaseDepreciacion,(act.VidaUtilCont- datediff(year,act.fecIngreso,GETDATE())) as vidaUtil from AdcAcf act left join AdcAcfDep dep  on act.Codigo=dep.Codigo"
        ssql += " where act.Codigo  = '" & cod & "' union "
        ssql += " select act.TipoActivo,act.Codigo,act.Nombre,act.Cantidad,act.FecIngreso,act.CostoIngreso,act.ValorResidual,dep.ClaseDepreciacion,(act.VidaUtilCont- datediff(year,act.fecIngreso,GETDATE())) as vidaUtil from AdcAcf act left join AdcAcfDep dep  on act.Codigo=dep.Codigo"
        ssql += " where act.CodActivoPrincipal  = '" & cod & "' group by act.Codigo, act.TipoActivo, act.Nombre, act.Cantidad, act.FecIngreso,act.CostoIngreso, act.ValorResidual,dep.ClaseDepreciacion,act.VidaUtilCont order by act.Codigo "
        Dim conectar As New SqlConnection()
        Dim coneccion As New DaxLib.DaxLibBases
        coneccion.TipoBase = "10"
        conectar.ConnectionString = coneccion.StrAdcom
        Dim datS As New DataSet()
        Dim d As New SqlDataAdapter(ssql, conectar)
        d.Fill(datS, "Datos")
        With gridListado
            .DataSource = datS.Tables("Datos")
            Dim formato As New FormatoMallas.FormatoMalla
            formato.ConfigurarMalla(gridListado, "Consulta")
            ' este metodo cambia de color al activo principal
            If .RowCount > 0 Then ActPrincipal() : .ClearSelection()
        End With
        
    End Sub
    Private Sub ActPrincipal()
        With gridListado
            For i = 0 To .RowCount - 1
                If .Rows(i).Cells(1).Value.ToString.Trim = codigoAct.Trim Then .Rows(i).DefaultCellStyle.BackColor = Color.Beige
            Next
        End With
    End Sub
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Dispose()
    End Sub
    Private Sub btnPropiedades_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPropiedades.Click
        Dim CODACF As String
        Dim fila As Long
        CODACF = ""
        If (gridListado.RowCount() > 0) And (gridListado.SelectedCells.Count > 0) Then
            fila = gridListado.SelectedCells(0).RowIndex.ToString()
            CODACF = gridListado.Rows(fila).Cells(1).Value.ToString()
        Else
            MsgBox("Es necesario que primero seleccione un activo", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim prog2 As New MantenimientoAF.MantAF
        '        prog2.actualizar = 1
        prog2.consultarExt("C", CODACF)
    End Sub

#Region "Reportes"

    Private Sub ImprimirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirToolStripMenuItem.Click
        Dim imp As New DataGridViewPrinterApplication1.frmMain
        imp.imprimir(gridListado, "Activos Fijos", , SYSEMP.EmpresaAct.nombre)
    End Sub

    Private Sub EnviarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarAExcelToolStripMenuItem.Click
        Dim exp As New ExportarGrid.Form1
        exp.Exportar(gridListado, "E", SYSEMP.EmpresaAct.nombre, "Activos Fijos")
    End Sub

    Private Sub EnviarAWordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarAWordToolStripMenuItem.Click
        Dim exp As New ExportarGrid.Form1
        exp.Exportar(gridListado, "W", SYSEMP.EmpresaAct.nombre, "Activos Fijos")
    End Sub

    Private Sub EnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnToolStripMenuItem.Click
        Dim exp As New ExportarGrid.Form1
        exp.Exportar(gridListado, "P", SYSEMP.EmpresaAct.nombre, "Activos Fijos")
    End Sub

#End Region

#Region "Menu Mouse"

    Private Sub VerificarComp()
        Dim ssql As String = "select Codigo from AdcAcf where EsActivoCompuesto=0 and codigo ='" & codACf & "'"
        Dim cmd As New SqlCommand(ssql, conectar)
        Dim dat As SqlDataReader
        conectar.Open()
        dat = cmd.ExecuteReader()
        If dat.Read Then SepararComponenteToolStripMenuItem.Enabled = True Else SepararComponenteToolStripMenuItem.Enabled = False
        conectar.Close()
    End Sub
    Private Sub gridListado_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridListado.CellClick
        Dim fila As Long
        If e.RowIndex >= 0 Then
            If gridListado.Rows.Count < 1 Then Exit Sub
            fila = gridListado.SelectedCells(0).RowIndex.ToString
            codACf = gridListado.Rows(fila).Cells("Codigo").Value.ToString
        End If
    End Sub

    Private Sub gridListado_CellContextMenuStripNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventArgs) Handles gridListado.CellContextMenuStripNeeded
        VerificarComp()
        MnuMouse.Show(gridListado, posX, posY)
        MnuMouse.Focus()
    End Sub

    Private Sub gridListado_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gridListado.MouseClick
        posX = e.Location.X
        posY = e.Location.Y
    End Sub

    Private Sub DepreciacionesAnualesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DepreciacionesAnualesToolStripMenuItem.Click
        Dim lista As New ListadoDepreciaciones.frmListadoDepre
        If codACf <> "" Then
            lista.cargarGrid(codACf, "1")
        Else
            MsgBox("Es necesario que seleccione un activo primero", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub SepararComponenteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SepararComponenteToolStripMenuItem.Click
        Dim cod As String = gridListado.Rows(0).Cells(1).Value
        Dim nom As String = gridListado.Rows(0).Cells(2).Value
        If MessageBox.Show("Esta seguro que quiere separar el componente " & codACf & vbCrLf & " del activo principal ?", "ACTIVO PRINCIPAL : " & cod.ToUpper & "- " & nom.ToUpper, MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = vbYes Then
            Dim ssql As String = "update adcacf set EsComponente=0, CodActivoPrincipal='' where codigo= '" & codACf & "'"
            Dim cmd As New SqlCommand(ssql, conectar)
            If conectar.State = ConnectionState.Closed Then conectar.Open()
            cmd.ExecuteNonQuery() : conectar.Close()
            CargarComponentes(cod)
        End If
    End Sub

#End Region

    Private Sub btnEnviar_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.ButtonClick
        btnEnviar.ShowDropDown()
    End Sub

End Class
