Imports System.Data.SqlClient

Public Class frmAcumulados
    Dim banderaFecha As Boolean = False
    Dim mesAct, añoAct As Integer
    Dim conectar As New SqlConnection()
    Dim depFin, depTrib As Boolean
    Dim existAcum, existDep As Boolean
    Dim cambios As Integer = 0
    Dim SYSEMP As New DaxUsr.DaxsofUsr
    Dim banderaGrid As Boolean = False
    Dim opmsg As Boolean = False
    Private Sub frmAcumulados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim coneccion As New DaxLib.DaxLibBases
        coneccion.TipoBase = "10"
        conectar.ConnectionString = coneccion.StrAdcom
        gridDatos.Columns(0).DataPropertyName = "codigo"
        gridDatos.Columns(1).DataPropertyName = "nombre"
        ExisteAcum()
        CargarGrid()
        With gridDatos
            .ClearSelection()
            .Columns(0).Frozen = True
            .Columns(1).Frozen = True
            .Columns(2).DefaultCellStyle.BackColor = Color.AliceBlue
            .Columns(3).DefaultCellStyle.BackColor = Color.AliceBlue
            .Columns(4).DefaultCellStyle.BackColor = Color.AliceBlue
            .Columns(5).DefaultCellStyle.BackColor = Color.Lavender
            .Columns(6).DefaultCellStyle.BackColor = Color.Lavender
            .Columns(7).DefaultCellStyle.BackColor = Color.Lavender
        End With
        txtMes.Focus()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If cambios > 0 Then
            If MsgBox("Desea guardar los cambios?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                btnGuardar_Click(sender, e)
            Else
                limpiarGrid(gridDatos)
                CargarGrid()
            End If
        Else
            limpiarGrid(gridDatos)
            CargarGrid()

        End If
        total()
        cambios = 0
    End Sub

    Private Sub btnSalir_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Dim confirmar As Integer
        If cambios > 0 Then
            confirmar = MsgBox("Desea guardar los cambios?", MsgBoxStyle.YesNo)
            If confirmar = vbYes Then btnGuardar_Click(sender, e) : Me.Dispose() Else Me.Dispose()
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub Limpiar()
        With gridDatos
            For i = 0 To .RowCount - 1
                For j = 2 To .ColumnCount - 1
                    .Rows(i).Cells(j).Value = Nothing
                Next
            Next
        End With
    End Sub
    Public Sub limpiarGrid(ByVal grid As DataGridView)
        With grid
            For i = .RowCount - 1 To 0 Step -1
                If i <= .Rows.Count Then .Rows.RemoveAt(i)
            Next
        End With
    End Sub


#Region "Verificacion Ingreso Fechas"

    Private Sub CambioFecha(ByVal sender As Object, ByVal e As System.EventArgs)
        If banderaFecha = True Then
            If MsgBox("Si cambia la fecha se eliminarán los acumulados ingresados." & vbCrLf & "Desea Continuar?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Eliminar()
        End If
    End Sub

    Private Sub txtMes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMes.KeyDown
        If e.KeyCode = Keys.Enter Then
            CambioFecha(sender, e)
            txtAño.Focus()
        End If

    End Sub

    Private Sub txtMes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMes.LostFocus
        If txtMes.Text <> "" Then
            If txtMes.Text < 0 Or txtMes.Text > 12 Then MsgBox("El mes ingresado no es correcto", MsgBoxStyle.Information) : txtMes.Text = "" : txtMes.Focus()
            'If txtMes.Text = "" Then MsgBox("Es necesario que ingrese el mes", MsgBoxStyle.Information)
            If existAcum = True Then banderaFecha = True
        End If
    End Sub

    Private Sub txtAño_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAño.KeyDown
        If e.KeyCode = Keys.Enter Then
            If banderaFecha = True Then
                CambioFecha(sender, e)
            Else
                limpiarGrid(gridDatos)
                CargarGrid()
            End If
            If txtAño.Text < 1900 Or txtAño.Text > Year(Now) Then opmsg = True : MsgBox("Ingrese un año válido", MsgBoxStyle.Information)
            If existAcum = True Then banderaFecha = True
            opmsg = False
        End If
    End Sub
    Private Sub txtAño_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAño.LostFocus
        If opmsg = True Then Exit Sub
        If txtAño.Text < 1900 Or txtAño.Text > Year(Now) Then MsgBox("Ingrese un año válido", MsgBoxStyle.Information)
        If existAcum = True Then banderaFecha = True
    End Sub

#End Region

#Region "Consulta De Depreciaciones"

    Private Sub ExisteAcum()
        Dim ssql As String = "select año, mes from AdcAcfDep where Acumulados=1"
        Dim cmd As New SqlCommand(ssql, conectar)
        Dim dat As SqlDataReader
        Try
            If conectar.State = ConnectionState.Closed Then conectar.Open()
        Catch
            MsgBox("No se puede conectar al servidor virtual del AdcomDX")
            End
        End Try
        Try
            dat = cmd.ExecuteReader()
        Catch
            MsgBox("Es posible que no tenga acceso al módulo de Activos Fijos falta AcfDep")
            End
        End Try
        If dat.Read Then
            txtAño.Text = dat(0)
            txtMes.Text = dat(1)

        Else
            txtAño.Text = Year(Now)
            txtMes.Text = Month(Now)
        End If
        If txtMes.Text.Length = 1 Then txtMes.Text = "0" & txtMes.Text
        mesAct = txtMes.Text
        añoAct = txtAño.Text
        conectar.Close()
    End Sub
    'METODO PARA CONSULTAR TODOS LOS ACTIVOS
    Private Sub CargarGrid()
        Dim finan(3), tribut(3), cod As String
        Dim contador = 0
        Dim ssql As String = "select codigo, nombre from adcacf where YEAR(FecIngreso)*100+ MONTH(fecIngreso) <=" & CInt(txtAño.Text) * 100 + CInt(txtMes.Text)
        ' & txtMes.Text & " and YEAR(FecIngreso) <=" & txtAño.Text
        Dim cmd As New SqlCommand(ssql, conectar)
        Dim datos As SqlDataReader
        If conectar.State = ConnectionState.Closed Then conectar.Open()
        datos = cmd.ExecuteReader()
        While datos.Read
            gridDatos.Rows.Add()
            gridDatos.Rows(contador).Cells(0).Value = datos(0)
            gridDatos.Rows(contador).Cells(1).Value = datos(1)
            contador += 1
        End While
        conectar.Close()
        With gridDatos
            For i = 0 To .RowCount - 1
                cod = .Rows(i).Cells(0).Value
                ConsultaTipoDep(cod)
                If depFin = False Then .Rows(i).Cells(2).ReadOnly = True : .Rows(i).Cells(2).Style.BackColor = Color.FloralWhite : .Rows(i).Cells(3).ReadOnly = True : .Rows(i).Cells(3).Style.BackColor = Color.FloralWhite : .Rows(i).Cells(4).ReadOnly = True : .Rows(i).Cells(4).Style.BackColor = Color.FloralWhite
                If depTrib = False Then .Rows(i).Cells(5).ReadOnly = True : .Rows(i).Cells(5).Style.BackColor = Color.FloralWhite : .Rows(i).Cells(6).ReadOnly = True : .Rows(i).Cells(6).Style.BackColor = Color.FloralWhite : .Rows(i).Cells(7).ReadOnly = True : .Rows(i).Cells(7).Style.BackColor = Color.FloralWhite
                'verifica si ya se ingresaron los acumulados
                existAcum = VerificarDepreciaciones("select * from adcacfdep where Acumulados=1")
                'verifica si existen depreciaciones efectuadas
                existDep = VerificarDepreciaciones("select * from adcacfdep where  Acumulados=0")
                If existAcum And depFin = True Then
                    finan = CargarAcum(.Rows(i).Cells(0).Value, "F")
                    .Rows(i).Cells(2).Value = finan(0)
                    .Rows(i).Cells(3).Value = finan(1)
                    .Rows(i).Cells(4).Value = finan(2)
                End If
                If existAcum And depTrib = True Then
                    tribut = CargarAcum(.Rows(i).Cells(0).Value, "T")
                    .Rows(i).Cells(5).Value = tribut(0)
                    .Rows(i).Cells(6).Value = tribut(1)
                    .Rows(i).Cells(7).Value = tribut(2)
                End If
            Next
        End With
        Totales()
        banderaGrid = True
    End Sub
    Private Sub Totales()
        With gridDatos
            If .RowCount > 0 Then
                .Rows.Add()
                .Rows(.RowCount - 1).DefaultCellStyle.BackColor = Color.LightSteelBlue
                .Rows(.RowCount - 1).Cells(0).Value = "TOTAL"
            End If
        End With
    End Sub
    'METODO PARA CONSULTAR EL TIPO DE DEPRECIACIONES TIENE EL ACTIVO
    Private Sub ConsultaTipoDep(ByVal cod As String)
        Dim ssql As String = "select TipoDepreciacionCont,TipoDepreciacionTributa  from adcacf where Codigo ='" & cod & "'"
        Dim cmd As New SqlCommand(ssql, conectar)
        Dim dat As SqlDataReader
        If conectar.State = ConnectionState.Closed Then conectar.Open()
        dat = cmd.ExecuteReader()
        If dat.Read Then
            If Not IsDBNull(dat(0)) Then
                If dat(0) <> 0 Then depFin = True Else depFin = False
            End If
            If Not IsDBNull(dat(1)) Then
                If dat(1) <> 0 Then depTrib = True Else depTrib = False
            End If
        End If
        conectar.Close()
    End Sub

    'METODO PARA VERIFICAR SI EL ACTIVO YA TIENE DEPRECIACIONES O ACUMULADOS INICIALES
    Private Function VerificarDepreciaciones(ByVal Ssql As String)
        Dim cmd As New SqlCommand(Ssql, conectar)
        Dim dat As SqlDataReader
        If conectar.State = ConnectionState.Closed Then conectar.Open()
        dat = cmd.ExecuteReader
        If dat.Read Then conectar.Close() : Return True Else  : conectar.Close() : Return False
    End Function
    'METODO PARA CARGAR LOS ACUMULADOS EXISTENTES
    Private Function CargarAcum(ByVal cod As String, ByVal tipo As String)
        Dim res(3) As String
        Dim Ssql = "select cast(DepreciacionMes as numeric(18,2)) as Dep ,cast(RevalorizacionMes as numeric(18,2)) as Rev,cast(DeterioroMes as numeric(18,2)) as Det  from AdcAcfDep p where codigo = '" & cod.Trim & "' and ClaseDepreciacion='" & tipo & "' and Acumulados=1"
        Dim cmd As New SqlCommand(Ssql, conectar)
        Dim dat As SqlDataReader
        If conectar.State = ConnectionState.Closed Then conectar.Open()
        dat = cmd.ExecuteReader
        If dat.Read Then
            If Not IsDBNull(dat(0)) Then res(0) = dat(0) Else res(0) = "0"
            If Not IsDBNull(dat(1)) Then res(1) = dat(1) Else res(1) = "0"
            If Not IsDBNull(dat(2)) Then res(2) = dat(2) Else res(2) = "0"
        End If
        conectar.Close()
        Return res
    End Function

#End Region

#Region "Guardar Acumulados"

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim confirmar As Integer
        With gridDatos
            For i = 0 To .RowCount - 1
                For j = 2 To .ColumnCount - 1
                    If IsNothing(.Rows(i).Cells(j).Value) And (.Rows(i).Cells(j).ReadOnly = False) Then .Rows(i).Cells(j).Value = 0
                Next
                'Verifica que los datos de los acumulados son correctos
                If (IsNothing(.Rows(i).Cells(2).Value) Or .Rows(i).Cells(2).Value <= 0) And (.Rows(i).Cells(2).ReadOnly = False) Then MsgBox("El valor de la depreciación no puede ser 0") : Exit Sub
                If (IsNothing(.Rows(i).Cells(5).Value) Or .Rows(i).Cells(5).Value <= 0) And (.Rows(i).Cells(5).ReadOnly = False) Then MsgBox("El valor de la depreciación no puede ser 0") : Exit Sub
            Next
            If existAcum = True Then
                For i = 0 To .RowCount - 1
                    'Elimina todas las depreciaciones existentes
                    EliminarDep(.Rows(i).Cells(0).Value, 1)
                Next
            End If
            If existDep = True Then
                ' si existen depreciaciones pregunta si desea guardar los cambios y eliminar las depreciaciones existentes
                confirmar = MsgBox("Existen depreciaciones efectuadas si guarda los cambios" & vbCrLf & "se eliminaran las depreciaciones existentes. Desea Continuar?", MsgBoxStyle.YesNo)
                If confirmar = vbNo Then Exit Sub
                For i = 0 To .RowCount - 1
                    'Elimina todas las depreciaciones existentes
                    EliminarDep(.Rows(i).Cells(0).Value, 0)
                Next
            End If
        End With
        Guardar()
        MsgBox("Proceso realizado con éxito!!", MsgBoxStyle.Information)
        cambios = 0
    End Sub

    Private Sub Guardar()
        Dim cod As String
        Dim depF, depT, revF, revT, detF, detT As Double

        Me.UseWaitCursor = True
        Me.Cursor = Cursors.WaitCursor
        With gridDatos
            For i = 0 To .RowCount - 2
                'Guarda los acumulados
                cod = .Rows(i).Cells(0).Value
                depF = .Rows(i).Cells(2).Value
                revF = .Rows(i).Cells(3).Value
                detF = .Rows(i).Cells(4).Value
                depT = .Rows(i).Cells(5).Value
                revT = .Rows(i).Cells(6).Value
                detT = .Rows(i).Cells(7).Value
                If .Rows(i).Cells(2).ReadOnly = False Then guardarAcumulados(cod, txtAño.Text, txtMes.Text, "F", revF, detF, depF)
                If .Rows(i).Cells(5).ReadOnly = False Then guardarAcumulados(cod, txtAño.Text, txtMes.Text, "T", revT, detT, depT)
                Me.UseWaitCursor = False
                Me.Cursor = Cursors.Default
            Next
        End With
        cambios = 0
    End Sub
    Private Sub EliminarDep(ByVal cod As String, ByVal acum As Integer)
        Dim ssql As String = "delete from adcacfdep where codigo='" & cod.Trim & "' and Acumulados=" & acum
        Dim cmd As New SqlCommand(ssql, conectar)
        If conectar.State = ConnectionState.Closed Then conectar.Open()
        cmd.ExecuteNonQuery()
        conectar.Close()
    End Sub
    Private Sub guardarAcumulados(ByVal cod As String, ByVal año As Integer, ByVal mes As Integer, ByVal clase As String, ByVal rev As Double, ByVal det As Double, ByVal dep As Double)
        Dim ssql = "Insert into adcacfdep (codigo, año, mes,claseDepreciacion,deterioroMes,RevalorizacionMes,DepreciacionMes,Acumulados,usuarioProceso,FechaProceso)"
        ssql += "values ("
        ssql += "'" & cod & "',"
        ssql += "" & año & ","
        ssql += " " & mes & ","
        ssql += "'" & clase & "',"
        ssql += " " & det & ","
        ssql += " " & rev & ","
        ssql += " " & dep & ","
        ssql += "1,"
        ssql += "'" & SYSEMP.UsuarioAct.nombre & "',"
        ssql += "'" & Now & "')"
        Dim cmd As New SqlCommand(ssql, conectar)
        If conectar.State = ConnectionState.Closed Then conectar.Open()
        cmd.ExecuteReader()
        conectar.Close()
    End Sub

#End Region

#Region "Eliminar Acumulados"

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim confirmar As Integer
        confirmar = MsgBox("Esta seguro que desea eliminar los acumulados?", MsgBoxStyle.YesNo)
        If confirmar = vbNo Then banderaFecha = True : Exit Sub
        Eliminar()
    End Sub

    Private Sub Eliminar()
        With gridDatos
            For i = 0 To .RowCount - 1
                EliminarDep(.Rows(i).Cells(0).Value, 0)
                EliminarDep(.Rows(i).Cells(0).Value, 1)
                banderaFecha = False
                existAcum = False
            Next
        End With
        Limpiar()
        limpiarGrid(gridDatos)
        CargarGrid()
        cambios = 0
    End Sub

#End Region

    Private Sub txtMes_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtMes.MaskInputRejected

        If existAcum = True Then banderaFecha = True
        cambios += 1
    End Sub



    Private Sub txtAño_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtAño.MaskInputRejected
        If existAcum = True Then banderaFecha = True
        cambios += 1
    End Sub


    Private Sub gridDatos_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridDatos.CellEndEdit
        If banderaGrid = True Then cambios += 1
    End Sub

    Private Sub gridDatos_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridDatos.CellEnter
        total()
    End Sub
    Private Sub total()
        Dim total As Double = 0
        If banderaGrid = True Or cambios > 0 Then
            With gridDatos
                For j = 2 To .ColumnCount - 1
                    For i = 0 To .RowCount - 2
                        If Not IsNothing(.Rows(i).Cells(j).Value) Then total += .Rows(i).Cells(j).Value
                    Next
                    .Rows(.RowCount - 1).Cells(j).Value = total
                    total = 0
                Next
            End With
        End If
    End Sub
End Class
