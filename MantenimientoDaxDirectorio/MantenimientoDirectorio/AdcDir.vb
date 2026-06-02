Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports DattCom
Friend Class AdcDir
    Inherits System.Windows.Forms.Form
    Dim Sistema As String
    Dim Codigo, CodigoNombre As String
    Dim Autorizacion As String
    Private Const MARGIN_SIZE As Short = 60 ' en twips

    ' variables para permitir el orden de columnas
    Private m_iSortCol As Short
    Private m_iSortType As Short

    ' variables para arrastrar columnas
    Private m_bDragOK As Boolean
    Private m_iDragCol As Short
    Private xdn, ydn As Short
    Dim busca As String
    Dim Personas As String
    Dim Relacion As String
    Dim Opckeyventas As Boolean
    Dim Opccompras As Boolean
    Dim Opckeypedidos As Boolean
    Dim Opckeymail As Boolean
    Dim posX, posY As Integer
    Dim columna, fila As Integer
    'Dim SYSEMP As New AdcDax.DaxSofSys
    Public tipo As String

    Private Sub EscogerColumnasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim prog As New EscojeCamposDir
        prog.EscojeCampos((datosEmpresa.sistema))
        cargarmalla()
    End Sub

    Private Sub AdcDir_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = e.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = e.CloseReason
        Me.Dispose()
        e.Cancel = Cancel
    End Sub

    Private Sub AdcDir_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error GoTo hayerrores
        If tipo > "" Then btnRelacion.Visible = False
        Sistema = datosEmpresa.sistema
        'If Len(Trim(varbleComun.)) = 0 Then Me.Close() : Exit Sub
        If Len(Trim(datosEmpresa.nombreBaseAdcom)) = 0 Then Me.Close() : Exit Sub
        Autorizacion = datosEmpresa.auto
        Me.Submenu.Visible = False
        If tipo > "" Then
            Select Case tipo
                Case "E"
                    Relacion = " and esempleado <> 0 "
                    Me.Text = "Directorio de Empleados"
                Case "C"
                    Relacion = " and escliente <> 0 "
                    Me.Text = "Directorio de Clientes"
                Case "P"
                    Relacion = " and esproveedor <> 0 "
                    Me.Text = "Directorio de Proveedores"
                Case "V"
                    Me.Text = "Directorio de Vendedores"
                    Relacion = " and esvendedor <> 0 "
                Case "F"
                    Me.Text = "Directorio de Instituciónes Financieras"
                    Relacion = " and esbanco <> 0"
            End Select
        End If
        'cargarmalla()
        Exit Sub
hayerrores:
        MsgBox("El sistema no tiene una configuración correcta, consulte al administrador" + Err.Description)
        Me.Close()
    End Sub
    Private Sub ChequearOpciones()
        Dim abierto As Boolean = IIf(AutorizarIngreso("mnuoDirectorioGeneral", datosEmpresa.usr) = "T", True, False)
        btnNuevo.Visible = abierto
        NuevoRegistroToolStripMenuItem1.Visible = abierto
    End Sub

    Private Sub cargarmalla()
        Dim sSQL As String
        WaitMensaje.WMensaje.verMensaje("Cargando lista de empleados")
        Dim OpcionStandard As String = "select [Codigo],[nombreImpresion] as [Nombre],[Provincia],[Ciudad],[Domicilio],[Telefono1],[NúmeroFax],[CorreoElectrónico] "
        Dim CamposDir As String
        CamposDir = GetSetting(Sistema, "Dir", "Campos", "")
        If Trim(CamposDir) > "" Then
            sSQL = "select " & CamposDir
        Else
            sSQL = OpcionStandard
        End If
        Try
            sSQL = sSQL & " from [directorioList] "
            sSQL = sSQL & " where [codigo] > '' " & Relacion & Personas & " order by [nombrecli] "
            MallaDat.DataSource = SqlDatos.leerTablaAdcom(sSQL)
            MallaDat.ClearSelection()
        Catch e As Exception
            MsgBox("Existe una excepción con los datos escojidos,el sistema regresa a los datos por defecto" & vbCr & e.Message)
            sSQL = OpcionStandard
            sSQL = sSQL & " from [directorioList] "
            sSQL = sSQL & " where [codigo] > '' " & Relacion & Personas & " order by [nombrecli] "
            MallaDat.DataSource = SqlDatos.leerTablaAdcom(sSQL)
            MallaDat.ClearSelection()
        End Try
        WaitMensaje.WMensaje.cierraMensaje()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
    Private Sub Busqueda(ByRef Tipo As Short)
        Static a As Short
        Dim i As Integer
        Dim buscomp As String
        If columna = 0 Then columna = 1
        If Tipo = 0 Then
            a = 0
            busca = ""
            busca = InputBox("BUSCAR:", "BUSQUEDA DE EXPRESIONES EN MALLAS")
        End If
        With MallaDat
            If a >= .RowCount - 1 Then a = 0
            If Len(busca) = 1 Then
                For i = a + 1 To .RowCount - 1
                    If IsDBNull(.Rows(i).Cells(columna).Value.ToString) Then buscomp = "" Else buscomp = .Rows(i).Cells(columna).Value.ToString
                    If UCase(buscomp) = UCase(busca) Then
                        .ClearSelection()
                        .Rows(i).Cells(columna).Selected = True
                        a = i
                        If Not .Rows(i).Displayed = True Then
                            .FirstDisplayedScrollingRowIndex = i
                        End If
                        Exit Sub
                    End If
                Next
                a = i
            Else
                For i = a + 1 To .RowCount - 1
                    If IsDBNull(.Rows(i).Cells(columna).Value.ToString) Then buscomp = "" Else buscomp = .Rows(i).Cells(columna).Value.ToString
                    If UCase(buscomp) Like "*" & UCase(busca) & "*" = True Then
                        .ClearSelection()
                        .Rows(i).Cells(columna).Selected = True
                        a = i
                        If Not .Rows(i).Displayed = True Then
                            .FirstDisplayedScrollingRowIndex = i
                        End If
                        Exit Sub
                    End If
                Next i
                a = i
            End If
        End With
    End Sub

    Private Sub borrarlinea(ByRef Lin As Integer)
        Dim j As Integer
        For j = 0 To MallaDat.ColumnCount - 1
        Next j
    End Sub

    Private Sub CopiarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim prog As New daaxLib.
        'prog.CopiarPegarMalla(MallaDat)
        'prog = Nothing
    End Sub

    Private Sub MallaDat_CellContextMenuStripNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventArgs) Handles MallaDat.CellContextMenuStripNeeded
        Submenu.Show(MallaDat, posX, posY)
        Submenu.Focus()
    End Sub

    Private Sub MallaDat_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MallaDat.DoubleClick
        '-------------------------------------------------------------------------------------------
        ' el código del evento DblClick de la cuadrícula permite ordenar columnas
        '-------------------------------------------------------------------------------------------

        Dim i As Short

        ' sólo ordena cuando se hace clic en una fila
        'If MallaDat.MouseRow >= MallaDat.FixedRows Then Exit Sub

        i = m_iSortCol ' guarda la columna antigua
        ' incrementa el tipo de orden
        If i <> m_iSortCol Then
            ' si hace clic en una columna nueva, inicia con orden ascendente
            m_iSortType = 1
        Else
            ' si hace clic en la misma columna, alterna entre orden ascendente y orden descendente
            m_iSortType = m_iSortType + 1
            If m_iSortType = 3 Then m_iSortType = 1
        End If

        DoColumnSort()
    End Sub

    Private Sub MallaDat_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MallaDat.DragDrop
        If m_iDragCol = -1 Then Exit Sub ' no se estaba arrastrando
        'If MallaDat.MouseRow <> 0 Then Exit Sub
        'If MallaDat.FixedCols = 1 And MallaDat.MouseCol = 0 Then Exit Sub

        'With MallaDat
        '    .Redraw = False
        '    .set_ColPosition(m_iDragCol, .MouseCol)
        '    .Redraw = True
        'End With
    End Sub

    Private Sub MallaDat_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MallaDat.KeyDown
        If e.KeyCode = System.Windows.Forms.Keys.F3 Then
            Busqueda(1)
        ElseIf e.KeyCode > System.Windows.Forms.Keys.Space And e.KeyCode <= System.Windows.Forms.Keys.Z Then
            busca = Chr(e.KeyCode)
            Busqueda(1)
        End If
    End Sub

    Private Sub MallaDat_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MallaDat.MouseClick
        posX = e.Location.X
        posY = e.Location.Y
    End Sub
    Private Sub MallaDat_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MallaDat.MouseDown
        '-------------------------------------------------------------------------------------------
        ' el código de los eventos DragDrop, MouseDown, MouseMove y MouseUp permite arrastrar columnas
        '-------------------------------------------------------------------------------------------
        If e.Button = 2 Then
            Exit Sub
        End If


        xdn = e.X
        ydn = e.Y
        m_iDragCol = -1 ' borrar indicador de arrastre
        m_bDragOK = True
    End Sub

    Private Sub MallaDat_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MallaDat.MouseUp
        '-------------------------------------------------------------------------------------------
        ' el código de los eventos DragDrop, MouseDown, MouseMove y MouseUp permite arrastrar columnas
        '-------------------------------------------------------------------------------------------

        m_bDragOK = False
    End Sub

    Sub DoColumnSort()
        ordenarmalla()
    End Sub

    Private Sub ordenarmalla()
        'Dim i As Integer
        'With MallaDat
        '    .Redraw = False
        '    For i = 1 To .Rows - 1
        '        .set_TextMatrix(i, 0, i)
        '    Next i
        '    .Redraw = True
        'End With

    End Sub

    Private Sub MostrarPedidosCliente()
        'Dim prog As New PedidosProducto
        'If Emp.Prod = False Then MsgBox "No tiene activado el módulo de produción", vbCritical: Exit Sub
        'With MallaDat
        'PedidosProducto.NombreConsulta = .TextMatrix(.Row, 2)
        'PedidosProducto.VerCliente = .TextMatrix(.Row, 1)
        'PedidosProducto.Show vbModal
        'Unload PedidosProducto
        'Set PedidosProducto = Nothing
        'End With
    End Sub
    Private Sub EstadoDeCuenta()
        'Dim prog As New CLIP00
        'With MallaDat
        'prog.CodigoCliente = .TextMatrix(.Row, 1)
        'prog.Tipo = True
        'prog.Show
        'End With
    End Sub

    Private Sub RelaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RelaciónToolStripMenuItem.Click
        Personas = " and tipopersona = 'N' "
        cargarmalla()
    End Sub

    Private Sub EmpresasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmpresasToolStripMenuItem.Click
        Personas = " and tipopersona = 'J' "
        cargarmalla()
    End Sub

    Private Sub TodosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TodosToolStripMenuItem.Click
        Personas = ""
        cargarmalla()
    End Sub

    Private Sub ClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientesToolStripMenuItem.Click
        Relacion = " and escliente <> 0 "
        cargarmalla()
    End Sub

    Private Sub TodasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TodasToolStripMenuItem.Click
        Relacion = ""
        cargarmalla()
    End Sub

    Private Sub ProveedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProveedoresToolStripMenuItem.Click

        Relacion = " and esproveedor <> 0 "
        cargarmalla()
    End Sub

    Private Sub FinancieraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FinancieraToolStripMenuItem.Click
        Relacion = " and esbanco <> 0 "
        cargarmalla()
    End Sub

    Private Sub VendedorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VendedorToolStripMenuItem.Click
        Relacion = " and esvendedor <> 0 "
        cargarmalla()
    End Sub

    Private Sub EmpleadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmpleadoToolStripMenuItem.Click
        Relacion = " and esempleado <> 0 "
        cargarmalla()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        CrearNuevo()
        cargarmalla()
    End Sub

    Private Sub btnBusca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBusca.Click
        BuscarToolStripMenuItem1_Click(sender, e)
    End Sub

    Private Sub btnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrir.Click
        PropiedadesToolStripMenuItem1_Click(sender, e)
        cargarmalla()
    End Sub

    Private Sub btnTodos_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTodos.ButtonClick
        cargarmalla()
    End Sub

    Private Sub btnRelacion_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRelacion.ButtonClick
        cargarmalla()
    End Sub
    Private Sub CrearNuevo()
        Dim prog As New BusDirectorio
        Dim autoriza As String
        autoriza = AutorizarIngreso("mnuoDirectorioGeneral", datosEmpresa.usr)
        If autoriza = "T" Then
            datosEmpresa.auto = autoriza
            prog.ManDir("&&")
            prog = Nothing
        End If
        datosEmpresa.auto = Autorizacion
    End Sub
    'Private Sub BuscarRegistro()
    'Dim prog As New BuscaClien
    'Codigo = prog.IniBuscaCliOPro("", CodigoNombre)
    '
    'End Sub

    Private Sub BuscarToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarToolStripMenuItem1.Click
        Busqueda(0)
    End Sub

    Private Sub FiltrarToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Col = 0, j = 0, i As Integer = 0
        Dim Com As String = ""
        With MallaDat
            Col = columna
            Com = InputBox("Filtrar por :", "Seleccionar filas por valores", .Rows(fila).Cells(columna).Value)
            If Com > "" Then
                j = 0
                i = 1
                Do Until j = 1
                    If Not (.Rows(i).Cells(Col).Value Like "*" & Com & "*") Then
                        If i = .RowCount - 1 Then
                            borrarlinea((i))
                            Exit Do
                        Else : .Rows.RemoveAt((i))
                        End If
                    Else : i = i + 1
                    End If
                    If i > .RowCount - 1 Then j = 1
                Loop
FINALIN:
                '                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                ordenarmalla()
            End If
        End With
    End Sub

    Private Sub EscogerColumnasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EscogerColumnasToolStripMenuItem1.Click
        Dim prog As New EscojeCamposDir
        prog.EscojeCampos(datosEmpresa.sistema)
        cargarmalla()
    End Sub

    Private Sub CopiarToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim prog As New DaxLib.DaxLibMalla
        'prog.CopiarPegarMalla(MallaDat)
        'prog = Nothing
    End Sub

    Private Sub PropiedadesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropiedadesToolStripMenuItem1.Click
        Dim prog As New DEEP01
        Dim ColAct As Long
        Dim LinAct As Long
        Dim autbak As String = AutorizarIngreso("mnuoDirectorioGeneral", datosEmpresa.usr)
        If autbak > "" Then
            With (MallaDat)
                ColAct = .CurrentCell.ColumnIndex
                LinAct = .CurrentCell.RowIndex
                datosEmpresa.auto = autbak
                prog.Directorio(.Rows(LinAct).Cells("Codigo").Value)
                prog = Nothing
                cargarmalla()
            End With
        End If
        datosEmpresa.auto = Autorizacion
    End Sub

    Private Sub NuevoRegistroToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoRegistroToolStripMenuItem1.Click
        Dim prog As New DEEP01
        Dim autbak As String = AutorizarIngreso("mnuoDirectorioGeneral", datosEmpresa.usr)
        If autbak > "" Then
            datosEmpresa.auto = autbak
            prog.Directorio("")
            prog = Nothing
        End If
        datosEmpresa.auto = Autorizacion
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirToolStripMenuItem.Click
        Dim imp As New DataGridViewPrinterApplication1.frmMain
        imp.imprimir(MallaDat)
    End Sub

    Private Sub btnEnviar_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.ButtonClick
        btnEnviar.ShowDropDown()
    End Sub

    Private Sub ExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelToolStripMenuItem.Click
        Dim exp As New mallExp.Form1
        Dim Empresa As String = datosEmpresa.nomEmpresa
        exp.Exportar(MallaDat, "E", Empresa, "Directorio")
    End Sub

    Private Sub WordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WordToolStripMenuItem.Click
        Dim exp As New mallExp.Form1
        exp.Exportar(MallaDat, "W", datosEmpresa.nomEmpresa, "Directorio")
    End Sub

    Private Sub PDFToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PDFToolStripMenuItem1.Click
        Dim exp As New mallExp.Form1
        exp.Exportar(MallaDat, "P", datosEmpresa.nomEmpresa, "Directorio")
    End Sub

    Private Sub MallaDat_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles MallaDat.CellEnter
        columna = e.ColumnIndex
        fila = e.RowIndex
    End Sub
End Class