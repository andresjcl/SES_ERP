Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Friend Class frmTablasSri
    Public SYSEMP As New AdcDax.DaxSofSys
    'Public EMP As AdcDax.Empresa
    'Public path As String
    Dim cambios As Integer = 0
    Dim ColNum As Integer = 0, FilNum As Integer = 0
    Dim Esquema As String
    Dim dt As New DataTable
    Dim nom As String
    Dim strConxIvaret As String = ""

#Region "Datos Iniciales"
    Private Sub frmTablasSri_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'EMP = SYSEMP.EmpresaAct
        '   path = EMP.PatServidor & "XML\SRI\"
        Dim dlib As New DaxLib.DaxLibBases
        dlib.TipoBase = "10"
        strConxIvaret = dlib.StrIvaret
        dlib = Nothing
        cargarCombo()
        Botones()
    End Sub
    Private Sub cargarCombo()
        Dim prog As New nombreTablas()
        Dim tablas As String() = prog.listaTablas
        For i As Int16 = 0 To CShort(tablas.Length - 1)
            cboTipo.Items.Add(tablas(i))
        Next

    End Sub
    Private Sub cboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged

        Dim nomTabla As New nombreTablas

        nom = cboTipo.SelectedItem.ToString
        Malla.DataSource = Nothing
        dt = New DataTable
        Dim ssql As String = "select * from " + nom
        Malla.Columns.Clear()
        Try
            Dim da As New SqlDataAdapter(ssql, strConxIvaret)
            da.Fill(dt)
            Malla.DataSource = dt
        Catch
            MessageBox.Show("No existe la tabla " + nom + " en las base de datos ","Registrar datos tablas delSRI",MessageBoxButtons.OK,MessageBoxIcon.Error)
        End Try
        If nom = nomTabla.ConceptosRetencion Or nom = nomTabla.RetencionIvaBienes Or nom = nomTabla.RetencionIvaServicios Then
            btncontabilidad.Enabled = True
        Else
            btncontabilidad.Enabled = False
        End If
        Malla.ShowCellToolTips = False
        cambios = 0
        Botones()

    End Sub

    Private Sub Malla_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Malla.CellValueChanged
        cambios += 1
        Botones()
    End Sub
#End Region

#Region "Guardar"
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Malla.EndEdit()
        guardar()
        cambios = 0
        Botones()
        Malla.ClearSelection()
    End Sub

    Private Sub guardar()
        Try
            Dim ssql As String = "select * from " + nom
            Dim da As New SqlDataAdapter(ssql, strConxIvaret)
            Dim cb As New SqlCommandBuilder(da)
            da.Update(dt)
        Catch ex As Exception
            MessageBox.Show("excepcion guardando tablas-SRI \n" + ex.Message)
        End Try
    End Sub
    'Private Shared Function DataGridViewToDataTable(ByVal dtg As DataGridView, Optional ByVal DataTableName As String = "Tabla1") As DataTable
    '    Dim cont As Integer = 0
    '    Try
    '        Dim TablaDatos As New DataTable(DataTableName)
    '        Dim Fila As DataRow
    '        Dim TablaDatosTotalColumnas As Integer = dtg.ColumnCount - 1

    '        'Agrega columna de datos
    '        For Each c As DataGridViewColumn In dtg.Columns
    '            Dim IColumna As DataColumn = New DataColumn()
    '            IColumna.ColumnName = c.Name
    '            TablaDatos.Columns.Add(IColumna)
    '        Next

    '        'Ahora Iterar a través de Datagrid y crear la fila de datos

    '        For Each DataFila As DataGridViewRow In dtg.Rows
    '            'Iterar a través de datagrid

    '            Fila = TablaDatos.NewRow 'Crear una línea nueva

    '            'Iterar a través de la columna 1 hasta el número total de columnas de datagrid
    '            For cn As Integer = 0 To TablaDatosTotalColumnas
    '                Fila.Item(cn) = DataFila.Cells(cn).Value
    '            Next

    '            'Ahora agregue la fila a la colección DataRow
    '            If cont <= dtg.RowCount - 2 Then TablaDatos.Rows.Add(Fila)
    '            cont += 1
    '        Next

    '        'Ahora vuelve la tabla de datos
    '        Return TablaDatos
    '    Catch ex As Exception
    '        Return Nothing
    '    End Try
    'End Function
#End Region

#Region "Ctas"
    Private Sub Malla_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Malla.CellEnter
        ColNum = e.ColumnIndex
        FilNum = e.RowIndex
        'Try
        '    If Malla.Columns(ColNum).HeaderText = "IdCta1" Or Malla.Columns(ColNum).HeaderText = "IdCta2" Then Malla.ShowCellToolTips = True Else Malla.ShowCellToolTips = False
        'Catch
        '    Malla.ShowCellToolTips = False
        'End Try
    End Sub
    Private Sub Malla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Malla.KeyDown
        With Malla
            If .Columns(Convert.ToInt32(ColNum)).HeaderText = "IdCta1" Or .Columns(Convert.ToInt32(ColNum)).HeaderText = "IdCta2" Then
                If e.KeyCode = Keys.F2 Then
                    Dim ct As New MantCtb.BuscaCta
                    .Rows(Convert.ToInt32(FilNum)).Cells(Convert.ToInt32(ColNum)).Value = ct.BuscaCtaCtb("", "S")
                End If
            End If
        End With
    End Sub
    Private Sub Malla_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Malla.MouseLeave
        Malla.EndEdit()
    End Sub
#End Region

#Region "Imprimir"
    Private Sub btnEnviar_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.ButtonClick
        btnEnviar.ShowDropDown()
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirToolStripMenuItem.Click
        Try
            Dim imp As New DataGridViewPrinterApplication1.frmMain
            imp.imprimir(Malla, cboTipo.SelectedItem.ToString.ToUpper, "", SYSEMP.EmpresaAct.nombre)
        Catch
            msgbox("Debe abrir una referencia para usar esta opción")
        End Try
    End Sub

    Private Sub WordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WordToolStripMenuItem.Click

        Try
            Dim exp As New Exp
            exp.Exportar(Malla, "W", SYSEMP.EmpresaAct.nombre, cboTipo.SelectedItem.ToString.ToUpper)
        Catch
            msgbox("Debe abrir una referencia para usar esta opción")
        End Try
    End Sub

    Private Sub ExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelToolStripMenuItem.Click
        Try
            Dim exp As New ExportarGrid.Form1
            exp.Exportar(Malla, "E", SYSEMP.EmpresaAct.nombre, cboTipo.SelectedItem.ToString.ToUpper)
        Catch
            msgbox("Debe abrir una referencia para usar esta opción")
        End Try

    End Sub

    Private Sub PDFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PDFToolStripMenuItem.Click
        Try
            Dim exp As New ExportarGrid.Form1
            exp.Exportar(Malla, "P", SYSEMP.EmpresaAct.nombre, cboTipo.SelectedItem.ToString.ToUpper)
        Catch
            msgbox("Debe abrir una referencia para usar esta opción")
        End Try

    End Sub
#End Region

#Region "Salir"
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Salir()
    End Sub
    Private Sub frmTablasSri_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Salir()
    End Sub
    Private Sub Salir()
        If cambios > 0 Then
            If MsgBox("Desea guardar los cambios?", MsgBoxStyle.YesNo) = vbYes Then
                guardar()
                Me.Dispose()
            End If
        Else
            Me.Dispose()
            Botones()
        End If
    End Sub
#End Region

#Region "Contabilizar"
    Private Sub CargarCodigos()
        '        On Error Resume Next
        Dim codigoant As String = ""
        Dim porcentajeant As Long = 0
        Dim Codigo As String
        Dim Porcentaje As Long
        Dim Concepto As String
        Dim Pasar() As String
        Dim PyC As String = ""
        Dim Coma As String = ","
        Dim i As Integer
        Dim j As Boolean = False
        Dim l As Integer = 0
        Dim fechaini As Date
        Dim fechafin As Date
        ReDim Pasar(1)
        For Each RR As DataGridViewRow In Malla.Rows
            If IsNothing(RR.Cells("Descripción").Value) = False Then
                Codigo = CStr(RR.Cells("código").Value)
                Porcentaje = 0
                If cboTipo.Text.Substring(0, 12).ToUpper = "RETENCIONIVA" Then
                    Concepto = cboTipo.Text + RR.Cells("Descripción").Value.ToString()
                    Porcentaje = CLng("0" + RR.Cells("Descripción").Value.ToString())
                Else
                    Porcentaje = CLng("0" + RR.Cells("porcentaje").Value.ToString())
                    Concepto = CStr(RR.Cells("Descripción").Value)
                End If

                Try
                    fechafin = CDate(RR.Cells("fechaFin").Value)
                Catch ex As Exception
                    fechafin = CDate("31/12/9999")
                End Try

                Try
                    fechaini = CDate(RR.Cells("fechaInicio").Value)
                Catch ex As Exception
                    fechaini = CDate("01/01/1900")
                End Try

                If Porcentaje > 0 And Now.Date >= fechaini And Now.Date <= fechafin Then
                    For i = 0 To Pasar.Length
                        If codigoant = Codigo And porcentajeant = Porcentaje Then j = True : Exit For
                    Next
                    If j = False Then
                        l = l + 1
                        ReDim Preserve Pasar(l)
                        Pasar(l - 1) = Codigo & "," & Replace(Concepto, ",", " ") & "," & Porcentaje
                        codigoant = Codigo
                        porcentajeant = Porcentaje
                    End If
                    j = False
                End If
            End If
        Next
        Dim prog As New frmContabilidad(Malla, cboTipo.Text)
        'prog.tabla = cboTipo.Text
        'prog.Campos = Pasar
        prog.ShowDialog()
    End Sub
#End Region


    Private Sub btncontabilidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncontabilidad.Click
        CargarCodigos()
    End Sub
    Private Sub Botones()
        btnGuardar.Enabled = CBool(IIf(cambios > 0, True, False))
    End Sub
End Class
