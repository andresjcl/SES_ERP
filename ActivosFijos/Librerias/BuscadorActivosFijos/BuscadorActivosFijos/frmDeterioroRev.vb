Imports System.Data
Imports Depre_Activos
Imports System.Data.SqlClient
Imports MantenimientoAF
Imports ListadoDepreciaciones
Public Class frmDeterioroRev
    Dim conectar As New SqlConnection()
    Dim codAct As String = ""
    Dim cambios As Integer = 0
    Dim aux = 0, guardar1 = 0, posX = 0, posY As Integer = 0
    Dim nombreMes As String
    Dim SYSEMP As New AdcDax.DaxsofSys
    Private Sub FrmBuscarAct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim coneccion As New DaxLib.DaxLibBases
        coneccion.TipoBase = "10"
        conectar.ConnectionString = coneccion.StrAdcom
        txtFecha.Text = Now
        txtFecha.Focus()
    End Sub
    Public Sub consulta()
        gridDatos.Refresh()
        Me.Refresh()
        Dim ssql As String
        Dim fec As Integer
        Dim fecha As String
        fecha = txtFecha.Text
        Dim mes, año As Integer
        mes = CInt(fecha.Substring(3, 2))
        año = CInt(fecha.Substring(6, 4))
        fec = año * 100 + mes
        ssql = "select adcAcf.Codigo,AdcAcf.Nombre,AdcAcf.CostoIngreso,AdcAcf.ValorResidual,(AdcAcf.CostoIngreso- abs(r2.ValorActual)) as ValorActual, AdcAcfNov.NVdeterioro as Deterioro, AdcAcfNov.NVrevalorizacion as Revalorizacion from  AdcAcf  left join"
        ssql += "(select dep.codigo, (SUM(dep.DepreciacionMes)+SUM(dep.RevalorizacionMes)-SUM(dep.DeterioroMes))"
        ssql += " as ValorActual from adcAcfDep dep where año*100+Mes <=" & año * 100 + mes
        ssql += " group by dep.codigo) r2"
        ssql += " on (adcacf.Codigo = r2.Codigo) left join AdcAcfNov on(AdcAcf.Codigo = AdcAcfNov.Codigo and MONTH(AdcAcfNov.FechaNovedad)=" & mes & " and YEAR(AdcAcfNov.FechaNovedad)=" & año & " and AdcAcfNov.Opc_documento ='CAL')"
        Dim cons As New BindingSource()
        Dim datos As New DataSet()
        Dim dataAd As New SqlDataAdapter(ssql, conectar)
        dataAd.Fill(datos, "AdcAcf")
        cons.DataSource = datos
        cons.DataMember = "AdcAcf"
        gridDatos.DataSource = cons
        gridDatos.ClearSelection()
        Dim formato As New FormatoMallas.FormatoMalla
        gridDatos = formato.ConfigurarMalla(gridDatos, "IngresoDatos")
        gridDatos.Columns("Deterioro").DefaultCellStyle.Format = "N2"
        gridDatos.Columns("Revalorizacion").DefaultCellStyle.Format = "N2"
        gridDatos.Columns("Deterioro").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        gridDatos.Columns("Revalorizacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        consEstado(mes, año)
        consMesesDep(mes, año)
    End Sub
    Public Sub consMesesDep(ByVal mes As Long, ByVal año As Long)
        Dim cons As String = "select MIN(año*100+mes), MAX(año*100+mes) from AdcAcfDep "
        Dim cmd As New SqlCommand(cons, conectar)
        Dim dat As SqlDataReader
        Dim fechaDepMin, fechaDepMax, fechaIng As Long
        fechaIng = año * 100 + mes
        conectar.Open()
        dat = cmd.ExecuteReader()
        If dat.Read Then
            If Not IsDBNull(dat(0)) Then fechaDepMin = dat(0)
            If Not IsDBNull(dat(1)) Then fechaDepMax = dat(1)
        End If
        conectar.Close()
        If fechaDepMax > 0 Then
            If fechaDepMax < fechaIng Then
                Dim m, a As Long
                m = (fechaDepMax.ToString.Substring(4, 2))
                a = (fechaDepMax.ToString.Substring(0, 4))
                Nombre(m)
                MsgBox("No existen depreciaciones a partir de " & nombreMes & " del " & a, MsgBoxStyle.Information)
            End If
        Else
            MsgBox("No existe ninguna Depreciaciòn", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Dim confirmar As Integer
        If cambios > 0 Then
            confirmar = MessageBox.Show("Desea guardar los cambios antes de salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If confirmar = vbYes Then
                guardar()
                Me.Dispose()
            Else
                Me.Dispose()
            End If
        Else
            Me.Dispose()
        End If
    End Sub
    Private Sub btnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click
        consulta()
        gridDatos.Columns("Codigo").Frozen = True
        gridDatos.Columns("Nombre").Frozen = True
        gridDatos.Columns.Add("NuevoValor", "NuevoValor")
        gridDatos.Columns("Codigo").ReadOnly = True
        gridDatos.Columns("Nombre").ReadOnly = True
        gridDatos.Columns("CostoIngreso").ReadOnly = True
        gridDatos.Columns("ValorResidual").ReadOnly = True
        gridDatos.Columns("ValorActual").ReadOnly = True
        gridDatos.Columns("Deterioro").ReadOnly = False
        gridDatos.Columns("Revalorizacion").ReadOnly = False
        gridDatos.Columns("NuevoValor").ReadOnly = True
        gridDatos.Columns("NuevoValor").DefaultCellStyle.Format = "N2"
        gridDatos.Columns("NuevoValor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        If gridDatos.RowCount > 0 Then
            btnPorcDet.Visible = True
            btnPorcReval.Visible = True
            btnImportar.Visible = False
            btnPropiedades.Visible = True
        Else
            btnPorcDet.Visible = False
            btnPorcReval.Visible = False
        End If
        aux = 1

    End Sub

    Private Sub txtFecha_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFecha.GotFocus
        If txtFecha.Text <> "  /  /" Then
            txtFecha.SelectAll()
        End If
    End Sub

    Private Sub btnPropiedades_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPropiedades.Click
        Dim fila As Integer
        fila = gridDatos.SelectedCells(0).RowIndex.ToString()
        codAct = gridDatos.Rows(fila).Cells("Codigo").Value.ToString()
        Dim mant As New MantenimientoAF.MantAF
        mant.act = 1
        mant.consultarExt("C", codAct)
    End Sub

    Private Sub btnPorc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPorcDet.Click
        Dim porcTodReg As Double = 0
        Dim reg As Integer = 0
        Dim tipo As String = ""
        Dim porc As New FrmPorcentaje()
        Dim respuesta(3) As String
        respuesta = porc.Abrir()
        If CInt(respuesta(0)) = 1 Then
            Exit Sub
        End If
        If respuesta(1) = 0 Then
            tipo = "PORC"
        ElseIf respuesta(1) = 1 Then
            tipo = "VALOR"
        End If
        porcTodReg = respuesta(2)
        If gridDatos.SelectedCells.Count() > 0 Then
            reg = CInt(gridDatos.SelectedCells.Count().ToString())
            porcentaje(porcTodReg, reg, "DET", tipo)
        Else
            PorcentajeTodo(porcTodReg, "DET", tipo)
        End If
        porc.Dispose()
    End Sub
    Public Sub porcentaje(ByVal porcen As Double, ByVal nreg As Integer, ByVal tipo As String, ByVal tipo_ing As String)
        Dim val_act As Double = 0.0
        Dim det, reval As Double
        Dim fila As Integer
        For contador = 0 To nreg - 1 Step 1
            If gridDatos.SelectedCells.Count > 0 Then
                fila = gridDatos.SelectedCells(contador).RowIndex.ToString()
                If tipo_ing = "PORC" Then
                    val_act = CDbl(gridDatos.Rows(fila).Cells("ValorActual").Value)
                    If tipo = "DET" Then
                        det = CDbl(val_act * porcen / 100)
                        gridDatos.Rows(fila).Cells("Deterioro").Value = CDbl(det)
                    ElseIf tipo = "REV" Then
                        reval = CDbl(val_act * porcen / 100)
                        gridDatos.Rows(fila).Cells("Revalorizacion").Value = CDbl(reval)
                    End If
                ElseIf tipo_ing = "VALOR" Then
                    If tipo = "DET" Then
                        gridDatos.Rows(fila).Cells("Deterioro").Value = porcen
                    ElseIf tipo = "REV" Then
                        gridDatos.Rows(fila).Cells("Revalorizacion").Value = porcen
                    End If
                End If
            End If

        Next
    End Sub
    Public Sub PorcentajeTodo(ByVal porcentaje As Double, ByVal tipo As String, ByVal tipo_ing As String)
        Dim val_act As Double = 0.0
        Dim det, rev As Double
        Dim nreg As Integer
        nreg = gridDatos.RowCount()
        For con = 0 To nreg - 1 Step 1
            If tipo_ing = "PORC" Then
                If Not IsDBNull(gridDatos.Rows(con).Cells("ValorActual").Value) Then
                    val_act = gridDatos.Rows(con).Cells("ValorActual").Value
                    If tipo = "DET" Then
                        det = CDbl(val_act * porcentaje / 100)
                        gridDatos.Rows(con).Cells("Deterioro").Value = det
                    ElseIf tipo = "REV" Then
                        rev = CDbl(val_act * porcentaje / 100)
                        gridDatos.Rows(con).Cells("Revalorizacion").Value = rev
                    End If
                End If
            ElseIf tipo_ing = "VALOR" Then
                If tipo = "DET" Then
                    If Not IsDBNull(gridDatos.Rows(con).Cells("ValorActual").Value) Then
                        gridDatos.Rows(con).Cells("Deterioro").Value = porcentaje
                    End If
                ElseIf tipo = "REV" Then
                    If Not IsDBNull(gridDatos.Rows(con).Cells("ValorActual").Value) Then
                        gridDatos.Rows(con).Cells("Revalorizacion").Value = porcentaje
                    End If
                    End If
                End If
        Next
    End Sub
    Public Sub calcular()
        Dim det, val_act, rev, nuevo As Double
        Dim reg As Integer
        reg = gridDatos.RowCount()
        For cont = 0 To reg - 1 Step 1
            If Not IsDBNull(gridDatos.Rows(cont).Cells("ValorActual").Value) Then
                val_act = gridDatos.Rows(cont).Cells("ValorActual").Value
                If IsDBNull(gridDatos.Rows(cont).Cells("Deterioro").Value) Then
                    det = 0
                Else
                    det = gridDatos.Rows(cont).Cells("Deterioro").Value
                End If
                If IsDBNull(gridDatos.Rows(cont).Cells("Revalorizacion").Value) Then
                    rev = 0
                Else
                    rev = gridDatos.Rows(cont).Cells("Revalorizacion").Value
                End If
                nuevo = val_act - det + rev
                gridDatos.Rows(cont).Cells("NuevoValor").Value = nuevo
            End If
        Next
    End Sub
    Private Sub btnPorcReval_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPorcReval.Click
        Dim porcTodReg As Double = 0
        Dim reg As Integer = 0
        Dim porc As New FrmPorcentaje()
        Dim tipo As String = ""
        Dim respuesta(3) As String
        respuesta = porc.Abrir()
        If respuesta(0) = 1 Then
            Exit Sub
        End If
        If respuesta(1) = 0 Then
            tipo = "PORC"
        ElseIf respuesta(1) Then
            tipo = "VALOR"
        End If

        porcTodReg = respuesta(2)

        If gridDatos.SelectedCells.Count() > 0 Then
            reg = CInt(gridDatos.SelectedCells.Count().ToString())
            porcentaje(porcTodReg, reg, "REV", tipo)
        Else
            PorcentajeTodo(porcTodReg, "REV", tipo)
        End If
        porc.Dispose()
    End Sub
    Public Sub eliminarNov()
        Dim mes, año As Long
        Dim ssql As String = ""
        mes = CLng(txtFecha.Text.Substring(3, 2))
        año = CLng(txtFecha.Text.Substring(6, 4))
        ssql = "delete from AdcAcfNov where Opc_documento='CAL' and MONTH(FechaNovedad)= " & mes & " and YEAR(FechaNovedad)=" & año
        Dim comando As New SqlCommand(ssql, conectar)
        Try
            conectar.Open()
            comando.ExecuteNonQuery()
            conectar.Close()
        Catch ex As Exception
            MsgBox("Error al eliminar", MsgBoxStyle.Information)
        End Try
    End Sub
    Public Sub Nombre(ByVal mes As Long)
        If mes = 1 Then
            nombreMes = "Enero"
        ElseIf mes = 2 Then
            nombreMes = "Febrero"
        ElseIf mes = 3 Then
            nombreMes = "Marzo"
        ElseIf mes = 4 Then
            nombreMes = "Abril"
        ElseIf mes = 5 Then
            nombreMes = "Mayo"
        ElseIf mes = 6 Then
            nombreMes = "Junio"
        ElseIf mes = 7 Then
            nombreMes = "Julio"
        ElseIf mes = 8 Then
            nombreMes = "Agosto"
        ElseIf mes = 9 Then
            nombreMes = "Septiembre"
        ElseIf mes = 10 Then
            nombreMes = "Octubre"
        ElseIf mes = 11 Then
            nombreMes = "Noviembre"
        Else
            nombreMes = "Diciembre"
        End If
    End Sub
    Public Sub consultaDepre(ByVal mes As Long, ByVal año As Long)
        'Dim conec As New SqlConnection("server=SISTEMAS\SQLEXPRESS;user id=sa;password=123qweASDZXC;database=BdAdcomDxSistemas;pooling=false")
        Dim ssql As String = ""
        Dim dep = 0, dep1 As Integer = 0
        Dim conf As Integer = 0
        Dim mensaje As String = ""
        ssql = "select Codigo  from AdcAcfDep where año*100+Mes ='" & (año * 100 + mes) & "' and estado =1"
        Dim comando As New SqlCommand(ssql, conectar)
        Dim datos As SqlDataReader
        If conectar.State = ConnectionState.Open Then conectar.Close()
        conectar.Open()
        datos = comando.ExecuteReader()
        If datos.Read Then
            dep = 1
        End If
        conectar.Close()
        ssql = "select Codigo  from AdcAcfDep where año*100+Mes >'" & (año * 100 + mes) & "' and estado =1"
        Dim comando1 As New SqlCommand(ssql, conectar)
        conectar.Open()
        datos = comando.ExecuteReader()
        If datos.Read Then
            dep1 = 1
        End If
        conectar.Close()
        If dep = 1 And dep1 = 0 Then
            Nombre(mes)
            mensaje = "Al guardar los datos la depreciación de " & nombreMes & "del " & año & vbCrLf & " será eliminada ¿Desea Continuar?"
            conf = MessageBox.Show(mensaje, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
            If conf = vbYes Then
                eliminarDepre(mes, año)
                guardar1 = 1
            Else
                guardar1 = 0
            End If
        ElseIf dep1 = 1 Then
            Nombre(mes)
            mensaje = "Existen depreciaciones de meses mayores a " & nombreMes & " del " & año & vbCrLf & " al guardar será eliminadas ¿Desea Continuar?"
            conf = MessageBox.Show(mensaje, "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
            If conf = vbYes Then
                eliminarDepre(mes, año)
                guardar1 = 1
            Else
                guardar1 = 0
            End If
        ElseIf dep = 0 And dep1 = 0 Then
            guardar1 = 2
        End If
    End Sub
    Public Sub eliminarDepre(ByVal mes As Long, ByVal año As Long)
        Dim ssql As String = ""
        ssql = "update AdcAcfDep set estado= 0 where año*100+Mes ='" & (año * 100 + mes) & "'"
        Dim comando As New SqlCommand(ssql, conectar)
        Try
            conectar.Open()
            comando.ExecuteNonQuery()
            conectar.Close()
        Catch ex As Exception
            MsgBox("Error al eliminar la Depreciación")
        End Try
    End Sub
    Public Sub guardar()
        Dim codigo = "", sucursal As String = ""
        Dim num = 0, nreg As Integer = 0
        Dim ssql, ssql1 As String
        nreg = gridDatos.RowCount()
        Dim dataR As SqlDataReader
        For contador = 0 To nreg - 1 Step 1
            If Not (IsDBNull(gridDatos.Rows(contador).Cells(5).Value) And IsDBNull(gridDatos.Rows(contador).Cells(6).Value)) Then
                'Dim conec As New SqlConnection("server=SISTEMAS\SQLEXPRESS;user id=sa;password=123qweASDZXC;database=BdAdcomDxSistemas;pooling=false")
                codigo = gridDatos.Rows(contador).Cells("Codigo").Value.ToString
                ssql = "Select UbicaSucursal from AdcAcf where Codigo='" & codigo & "'"
                Dim com As New SqlCommand(ssql, conectar)
                If conectar.State = ConnectionState.Open Then conectar.Close()
                conectar.Open()
                dataR = com.ExecuteReader()
                If dataR.Read Then
                    sucursal = dataR(0)
                End If
                conectar.Close()
                ssql1 = "select MAX(Doc_numero) from AdcAcfNov where Doc_sucursal='" & sucursal & "' and Opc_documento='CAL'"
                Dim com1 As New SqlCommand(ssql1, conectar)
                conectar.Open()
                dataR = com1.ExecuteReader()
                If dataR.Read Then
                    If IsDBNull(dataR(0)) Then
                        num = 0
                    Else
                        num = dataR(0)
                    End If
                End If
                conectar.Close()
                Dim det, reval As Double

                '//////////////////////////////////////////////////////////////////////////////
                If IsDBNull(gridDatos.Rows(contador).Cells("Deterioro").Value) Then
                    det = 0
                Else
                    det = gridDatos.Rows(contador).Cells("Deterioro").Value
                End If
                If IsDBNull(gridDatos.Rows(contador).Cells("Revalorizacion").Value) Then
                    reval = 0
                Else
                    reval = gridDatos.Rows(contador).Cells("Revalorizacion").Value
                End If
                ssql = "exec ACTFDET_INS '" & sucursal & "',"
                ssql = ssql & "'CAL',"
                ssql = ssql & num + 1 & ","
                ssql = ssql & "'" & gridDatos.Rows(contador).Cells("Codigo").Value.ToString & "',"
                ssql = ssql & "'" & LSet(Now, 10) & "',"
                ssql = ssql & "'" & CDate(txtFecha.Text) & "',"
                ssql = ssql & det & ","
                ssql = ssql & reval
                Try
                    Dim comando As New SqlCommand(ssql, conectar)
                    conectar.Open()
                    comando.ExecuteNonQuery()
                    conectar.Close()
                Catch ex As Exception
                    MsgBox("Error al insertar el registro")
                End Try
            End If
        Next
    End Sub
    Private Sub btnCalculo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        calcular()
        btnGuardar.Visible = False
        cambios = 0
    End Sub

    Private Sub gridDatos_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridDatos.CellClick
        Dim fila As Integer
        If e.RowIndex > 0 Then
            fila = gridDatos.SelectedCells(0).RowIndex.ToString
            codAct = gridDatos.Rows(fila).Cells("Codigo").Value.ToString
        End If
    End Sub

    Private Sub gridDatos_CellContextMenuStripNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventArgs) Handles gridDatos.CellContextMenuStripNeeded
        mnuMouse.Show(gridDatos, posX, posY)
        mnuMouse.Focus()
    End Sub

    Private Sub gridDatos_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridDatos.CellValueChanged
        cambios += 1
        btnGuardar.Visible = True
        calcular()
    End Sub
    Public Sub consEstado(ByVal mes, ByVal año)
        Dim ssql As String = "select * from AdcAcfDep where año*100+Mes ='" & año * 100 + mes & "' and estado=1"
        Dim com As New SqlCommand(ssql, conectar)
        Dim dat As SqlDataReader
        conectar.Open()
        dat = com.ExecuteReader()
        If Not dat.Read Then
            gridDatos.Columns("ValorActual").DefaultCellStyle.BackColor = Color.Red
            btnDepreciar.Visible = True
        End If
        conectar.Close()
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim mensaje As String = ""
        Dim confirmar As Integer
        Dim fecha As String
        fecha = txtFecha.Text
        Dim mes, año As Integer
        mes = CInt(fecha.Substring(3, 2))
        año = CInt(fecha.Substring(6, 4))
        confirmar = MessageBox.Show("Esta seguro que desea guardar los cambios?", "Guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If confirmar = vbYes Then
            consultaDepre(mes, año)
            If guardar1 = 0 Then
                Exit Sub
            Else
                eliminarNov()
                guardar()
                If guardar1 = 1 Then
                    Nombre(mes)
                    mensaje = "Es necesario que vuelva a recalcular las depreciaciones a partir de " & vbCrLf & nombreMes & " " & año & ". Desea realizarlo en este momento?"
                    confirmar = MessageBox.Show(mensaje, "Depreciaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                    If confirmar = vbYes Then
                        Dim dep As New Depre_Activos.Depreciacion
                        dep.ShowDialog()
                        dep.Dispose()
                        consEstado(mes, año)
                        conectar.Close()
                        btnDepreciar.Visible = True
                    Else
                        gridDatos.Columns(4).DefaultCellStyle.BackColor = Color.Red
                        btnDepreciar.Visible = True
                    End If
                ElseIf guardar1 = 2 Then
                    MsgBox("Proceso realizado con éxito", MsgBoxStyle.Information)
                End If
            End If
        End If
        cambios = 0
        btnGuardar.Visible = False
        consulta()
    End Sub

    Private Sub gridDatos_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gridDatos.MouseMove
        posX = e.Location.X
        posY = e.Location.Y
    End Sub

    Private Sub DepreciacionesAnualesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DepreciacionesAnualesToolStripMenuItem.Click
        Dim lista As New ListadoDepreciaciones.frmListadoDepre
        If codAct <> "" Then
            lista.cargarGrid(codAct, "2")
        Else
            MsgBox("Es necesario que seleccione un activo primero", MsgBoxStyle.Information)
        End If
    End Sub
    Public Sub AbrirListado()
        Me.ShowDialog()
    End Sub

    Private Sub EnviarAWordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarAWordToolStripMenuItem.Click
        Dim exp As New ExportarGrid.Form1
        exp.Exportar(gridDatos, "E", SYSEMP.EmpresaAct.nombre, "Activos Fijos")
    End Sub

    Private Sub EnviarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarAExcelToolStripMenuItem.Click
        Dim imp As New DataGridViewPrinterApplication1.frmMain
        imp.imprimir(gridDatos)
    End Sub

    Private Sub EnviarAPdfToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarAPdfToolStripMenuItem.Click
        Dim exp As New ExportarGrid.Form1
        exp.Exportar(gridDatos, "W", SYSEMP.EmpresaAct.nombre, "Activos Fijos")
    End Sub

    Private Sub EnviarAExelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarAExelToolStripMenuItem.Click
        Dim exp As New ExportarGrid.Form1
        exp.Exportar(gridDatos, "P", SYSEMP.EmpresaAct.nombre, "Activos Fijos")
    End Sub

    Private Sub btnImprime_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprime.ButtonClick
        btnImprime.ShowDropDown()
    End Sub

    Private Sub btnDepreciar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDepreciar.Click
        Dim dep As New Depre_Activos.Depreciacion
        dep.ShowDialog()
    End Sub
End Class
