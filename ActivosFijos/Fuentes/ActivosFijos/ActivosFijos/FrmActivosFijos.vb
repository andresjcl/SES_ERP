Imports System.Data
Imports System.Data.SqlClient


Public Class FrmActivosFijos
    'VARIABLES DE CONEXION
    Dim conectarBDD As New SqlConnection()

    'VARIABLES DEL PROGRAMA
    Dim sSql, opciones, codACf As String
    Dim strconexion As String
    Dim strConxDaxsys As String
    Dim posX, posY As Integer
    Dim bandera As Integer = 0
    Dim SYSEMP As New AdcDax.DaxSofSys
    'Dim EMP As New AdcDax.Empresa
    Dim botonOp As Integer = 1
    Dim conect As New SqlConnection()
    Dim ConsultaGeneral As String

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If varbleComun.VarCom.strConxAdcom = "" Then varbleComun.cargar.iniciar("", "")
        Dim coneccion As New DaxLib.DaxLibBases
        'EMP = SYSEMP.EmpresaAct
        coneccion.TipoBase = "10"
        Try
            conectarBDD.ConnectionString = coneccion.StrAdcom
            conect.ConnectionString = coneccion.StrDaxsys
            strconexion = coneccion.StrAdcom
            strConxDaxsys = coneccion.StrDaxsys
            SplitContainer1.Panel1Collapsed = True
            llenarComboCat("1")
            llenarComboCat("2")
            llenarComboCat("3")
            llenarComboCat("4")
            llenarSucursal()
            llenarDepSec("Departamento", "DEP")
            llenarDepSec("Sección", "SEC")
            llenarResponsables()
            cargarConfiguracion()
            txtDesde.Value = New Date(1900, 1, 1)
            txtHasta.Value = Now
        Catch
            MsgBox("No existe conección a la base de datos del AdcomDX_ERP")
            End
        End Try
        opciones = My.Settings.cadena
        ConsultarActivo(opciones)
    End Sub
    Private Sub desbloquear(ByVal op As Boolean)
        btnPropiedades.Enabled = op
        btnImprimir.Enabled = op
        btnDepreciar.Enabled = op
        btnDeterioro.Enabled = op
        btnMovimientos.Enabled = op
        btnReportes.Enabled = op
        btnAbrir.Enabled = op
    End Sub
    Public Sub ConsultarActivo(ByVal opciones As String)
        Dim Cons As New BindingSource()
        Dim datos As New DataSet()

        sSql = "select act.TipoActivo,act.Codigo,act.Nombre,act.Cantidad,act.FecIngreso,"
        sSql += "act.CostoIngreso, "
        sSql += "isnull( (select sum(comp.CostoIngreso) from adcacf comp where comp.CodActivoPrincipal  = act.Codigo  and  isnull(comp.esComponente,0) = 1), 0) as CambiosActivo,"
        sSql += "act.ValorResidual,'T' as Depreciacion, "
        sSql += "case when (act.VidaUtilTributa - datediff(year,act.fecIngreso,GETDATE())) > 0 then act.VidaUtilTributa - datediff(year,act.fecIngreso,GETDATE()) else 0 end as vidaUtil "
        sSql += "from AdcAcf act "
        sSql += " where act.Codigo <> ''  "
        sSql += Consulta()
        sSql += " order by case when isnull(act.escomponente,0) = 1 then act.codActivoPrincipal else act.codigo end , act.codactivoprincipal"

        'sSql = sSql & "select act.TipoActivo,act.Codigo,act.Nombre,act.Cantidad,act.FecIngreso,(act.CostoIngreso+ isnull(max(actCom.Costo),0) ) as CostoIngreso,act.ValorResidual,dep.ClaseDepreciacion as Depreciacion,"
        'sSql = sSql & " case when (act.VidaUtilTributa - datediff(year,act.fecIngreso,GETDATE())) > 0 then act.VidaUtilTributa - datediff(year,act.fecIngreso,GETDATE()) else 0 end as vidaUtil from AdcAcf act left join AdcAcfDep dep  on act.Codigo=dep.Codigo left join"
        'sSql = sSql & "( select max(CodActivoPrincipal) as CodActivoPrincipal ,sum(CostoIngreso) as costo  from AdcAcf where EsComponente=1 ) actCom on (act.Codigo =actCom.CodActivoPrincipal )"
        'sSql = sSql & " where act.Codigo <> '' and EsComponente =0 " & Consulta()
        'sSql = sSql & "group by act.Codigo, act.TipoAcivo, act.Nombre, act.Cantidad, act.FecIngreso,act.CostoIngreso, act.ValorResidual,dep.ClaseDepreciacion,act.VidaUtilTributa order by act.Codigo "
        ConsultaGeneral = sSql
        Dim dataAd As New SqlDataAdapter(sSql, conectarBDD)

        If conectarBDD.State = ConnectionState.Closed Then conectarBDD.Open()
        'Try
        dataAd.Fill(datos, "AdcAcf")
        'Catch
        '    MsgBox("No se puede accesar a la base de datos de Activos Fijos")
        '    End
        'End Try

        Cons.DataSource = datos
        Cons.DataMember = "AdcAcf"
        gridActivos.DataSource = Cons
        gridActivos.ClearSelection()
        conectarBDD.Close()
        gridActivos.Columns("FecIngreso").DefaultCellStyle.Format = "dd/MM/yyyy"
        Dim formato As New FormatoMallas.FormatoMalla
        ConfigurarMalla()
        If gridActivos.RowCount = 0 Then desbloquear(False) Else desbloquear(True)
    End Sub
    Private Sub ConfigurarMalla()
        gridActivos.Columns("TipoActivo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        gridActivos.Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        gridActivos.Columns("Nombre").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        gridActivos.Columns("FecIngreso").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        gridActivos.Columns("Depreciacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Dim MantActivo As New MantenimientoAF.MantAF
        MantActivo.NuevoActivo()
        ConsultarActivo(opciones)
    End Sub

    Private Sub btnPropiedades_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPropiedades.Click
        Dim CODACF As String
        Dim fila As Int32
        CODACF = ""
        If (gridActivos.RowCount() > 0) And (gridActivos.SelectedCells.Count > 0) Then
            fila = gridActivos.SelectedCells(0).RowIndex
            CODACF = gridActivos.Rows(fila).Cells(1).Value.ToString()
        Else
            MsgBox("Es necesario que primero seleccione un activo", MsgBoxStyle.Information)
            Exit Sub
        End If
        Dim prog2 As New MantenimientoAF.MantAF
        prog2.consultarExt("C", CODACF)
        ConsultarActivo(opciones)
    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        ConsultarActivo(opciones)
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Dispose()
    End Sub

    Private Sub btnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrir.Click
        Dim busk As New MantenimientoAF.BuscarAcf
        Dim cod As String
        cod = busk.Cargar("")
        If cod <> "" Then
            Dim mant As New MantenimientoAF.MantAF
            ' mant.actualizar = 1
            mant.consultarExt("C", cod)
        End If
    End Sub

    Private Sub btnDepreciar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDepreciar.Click
        Dim dep As New DepreActivos.Depreciacion
        dep.ShowDialog()
        'Dim acfCl As New AdcAcf
        'Dim dep As New depreciaActivoFijo.depreciaActivoFijo()
        'dep.calcularDepreciaciones("", Convert.ToDateTime("01/01/2014"), Convert.ToDateTime("31/12/2016"))
        ConsultarActivo(opciones)
    End Sub

    Private Sub btnDeterioro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeterioro.Click
        Dim det As New BuscadorActivosFijos.frmDeterioroRev
        det.AbrirListado()
    End Sub

    Private Sub btnMovimientos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMovimientos.Click
        Dim mov As New MantenimientoMov.frmMovimientos
        mov.AbrirMov()
    End Sub

    Private Sub btnAyuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAyuda.Click
        ' Process.Start(EMP.PatAppl & "\binNET\Ayuda\ActivosFijos.chm")
    End Sub

    Private Sub gridActivos_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridActivos.CellClick
        Dim fila As Int32
        If e.RowIndex >= 0 Then
            If gridActivos.Rows.Count < 1 Then Exit Sub
            fila = gridActivos.SelectedCells(0).RowIndex
            codACf = gridActivos.Rows(fila).Cells("Codigo").Value.ToString
        End If
    End Sub

    Private Sub gridActivos_CellContextMenuStripNeeded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventArgs) Handles gridActivos.CellContextMenuStripNeeded
        'VerificarComp()
        mnuMouse.Show(gridActivos, posX, posY)
        mnuMouse.Focus()
    End Sub
    Private Sub gridActivos_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles gridActivos.MouseClick
        posX = e.Location.X
        posY = e.Location.Y
    End Sub

#Region "Reportes"

    Private Sub mnuCatalogoAct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCatalogoAct.Click
        Dim ssql As String = "exec ADC_REP001"
        Dim imprimir As New ImprimirReportes.FrmImprimir
        imprimir.Impresion(ssql, "CATALOGO DE ACTIVOS", "Report1ACF.rdlc")
    End Sub
    Private Sub DetalleDeDepreciacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetalleDeDepreciacionToolStripMenuItem.Click
        Dim ssql As String = "exec ADC_REP002"
        Dim imprimir As New ImprimirReportes.FrmImprimir
        imprimir.Impresion(ssql, "REPORTE DE DETALLE DE DEPRECIACIONES", "Report1ACF.rdlc")
    End Sub

    Private Sub FinacieraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FinacieraToolStripMenuItem.Click
        Dim IngFec As New DetRep
        Dim resp(3) As String
        resp = IngFec.IngresarFec()
        Dim ssql As String = "exec ADC_REP003 'F','" & resp(0) & "','" & resp(1) & "', '" & resp(2) & "'"
        Dim imprimir As New ImprimirReportes.FrmImprimir
        imprimir.Impresion(ssql, "REPORTE DE DEPRECIACIONES FINANCIERAS", "Report2ACF.rdlc")
    End Sub

    Private Sub TributariaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TributariaToolStripMenuItem.Click
        Dim IngFec As New DetRep
        Dim resp(3) As String
        resp = IngFec.IngresarFec()
        Dim ssql As String = "exec ADC_REP003 'T','" & resp(0) & "','" & resp(1) & "', '" & resp(2) & "'"
        Dim imprimir As New ImprimirReportes.FrmImprimir
        imprimir.Impresion(ssql, "REPORTE DE DEPRECIACIONES TRIBUTARIAS", "Report2ACF.rdlc")
    End Sub

    Private Sub DifernciaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DifernciaToolStripMenuItem.Click
        Dim IngFec As New DetRep
        Dim resp(3) As String
        resp = IngFec.IngresarFec()
        Dim ssql As String = "exec ADC_REP003 'D','" & resp(0) & "','" & resp(1) & "', '" & resp(2) & "'"
        Dim imprimir As New ImprimirReportes.FrmImprimir
        imprimir.Impresion(ssql, "REPORTE DE DEPRECIACIONES (DIFERENCIA)", "Report2ACF.rdlc")
    End Sub

    Private Sub MoivimierntoDeActivosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoivimierntoDeActivosToolStripMenuItem.Click
        Dim ssql As String = "exec ADC_REP004 'T'"
        Dim imprimir As New ImprimirReportes.FrmImprimir
        imprimir.Impresion(ssql, "REPORTE DE MOVIMIENTOS DE ACTIVOS", "Report1ACF.rdlc")
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Dim imprimir As New ImprimirReportes.FrmImprimir
        imprimir.Impresion(ConsultaGeneral, "REPORTE DE ACTIVOS FIJOS", "ReporteActivosFijos.rdlc")
    End Sub
    '        sSql = ""
    '    sSql = sSql & "select act.TipoActivo,act.Codigo,act.Nombre,act.Cantidad,act.FecIngreso,(act.CostoIngreso+ isnull(max(actCom.Costo),0) ) as CostoIngreso,act.ValorResidual,dep.ClaseDepreciacion as Depreciacion,"
    '    sSql = sSql & " (act.VidaUtilCont- datediff(year,act.fecIngreso,GETDATE())) as vidaUtil from AdcAcf act left join AdcAcfDep dep  on act.Codigo=dep.Codigo left join"
    '    sSql = sSql & "( select max(CodActivoPrincipal) as CodActivoPrincipal ,sum(CostoIngreso) as costo  from AdcAcf where EsComponente =1 ) actCom on (act.Codigo =actCom.CodActivoPrincipal )"
    '    sSql = sSql & " where act.Codigo <> '' and EsComponente =0 " & opciones
    '    sSql = sSql & "group by act.Codigo, act.TipoActivo, act.Nombre, act.Cantidad, act.FecIngreso,act.CostoIngreso, act.ValorResidual,dep.ClaseDepreciacion,act.VidaUtilCont order by act.Codigo "
    'Dim imprimir As New ImprimirReportes.FrmImprimir
    '    mprimir.Impresion(sSql, "REPORTE DE ACTIVOS DE ACTIVOS", "ReporteActivosFijos.rdlc")

    'sSql = sSql & "select act.TipoActivo,act.Codigo,act.Nombre,act.Cantidad,act.FecIngreso,(act.CostoIngreso+ isnull(max(actCom.Costo),0) ) as CostoIngreso,act.ValorResidual,dep.ClaseDepreciacion,"
    'sSql = sSql & " case when (act.VidaUtilTributa - datediff(year,act.fecIngreso,GETDATE())) > 0 then act.VidaUtilTributa - datediff(year,act.fecIngreso,GETDATE()) else 0 end as vidaUtil from AdcAcf act left join AdcAcfDep dep  on act.Codigo=dep.Codigo left join"
    'sSql = sSql & "( select max(CodActivoPrincipal) as CodActivoPrincipal ,sum(CostoIngreso) as costo  from AdcAcf where EsActivoCompuesto =0 ) actCom on (act.Codigo =actCom.CodActivoPrincipal )"
    'sSql = sSql & " where act.Codigo <> '' and EsComponente =0 " & Consulta()
    'sSql = sSql & "group by act.Codigo, act.TipoActivo, act.Nombre, act.Cantidad, act.FecIngreso,act.CostoIngreso, act.ValorResidual,dep.ClaseDepreciacion,act.VidaUtilTributa order by act.Codigo "


    Private Sub btnReportes_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReportes.ButtonClick
        btnReportes.ShowDropDown()
    End Sub
#End Region

#Region "MenuMouse"

    Private Sub VerificarComp()
        Dim ssql As String = "select top 1 Codigo from AdcAcf where CodActivoPrincipal ='" & codACf & "'"
        Dim cmd As New SqlCommand(ssql, conectarBDD)
        Dim dat As SqlDataReader
        If conectarBDD.State = ConnectionState.Open Then conectarBDD.Close()
        conectarBDD.Open()
        dat = cmd.ExecuteReader()
        If dat.Read Then
            ComponentesToolStripMenuItem.Enabled = True
            TransformarEnComponeteToolStripMenuItem.Enabled = False
        Else
            ComponentesToolStripMenuItem.Enabled = False
            TransformarEnComponeteToolStripMenuItem.Enabled = True
        End If

        conectarBDD.Close()
    End Sub

    Private Sub DepreciaciesAnualesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DepreciaciesAnualesToolStripMenuItem.Click
        Dim lista As New ListadoDepreciaciones.frmListadoDepre
        If codACf <> "" Then
            If VerificarDep(codACf) = False Then MsgBox("No existen depreciaciones para mostrar!!", MsgBoxStyle.Information) : Exit Sub
            lista.cargarGrid(codACf, "2")
        Else
            MsgBox("Es necesario que seleccione un activo primero", MsgBoxStyle.Information)
        End If
    End Sub
    Private Function VerificarDep(ByVal cod As String) As Boolean
        Dim bandera As Boolean = False
        Dim ssql As String = "select * from adcacfdep where codigo='" & cod & "'"
        Dim cmd As New SqlCommand(ssql, conectarBDD)
        Dim dat As SqlDataReader = Nothing
        If conectarBDD.State = ConnectionState.Open Then conectarBDD.Close()
        conectarBDD.Open()
        dat = cmd.ExecuteReader()
        If dat.Read Then bandera = True
        Return bandera
    End Function
    Private Sub ComponentesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComponentesToolStripMenuItem.Click
        Dim com As New MostrarComponentes.FrmComponentes
        If codACf <> "" Then
            com.cargarGrid(codACf)
            ConsultarActivo(opciones)
        Else
            MsgBox("Es necesario que seleccione un activo primero", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub TransformarEnComponeteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransformarEnComponeteToolStripMenuItem.Click
        Dim busk As New Buscar.frmBuscar
        Dim ssql As String = "select codigo, nombre from adcacf where EsComponente= 0 and codigo <> '" & codACf & "'"
        Dim cod As String
        cod = busk.Buscar(strconexion, ssql, "Codigo", "Nombre", "Consulta", "Escoja El Activo Principal Del Componente " & codACf & " :")
        If cod <> "" Then
            ssql = "Update adcacf set EsComponente=1 ,CodActivoPrincipal='" & cod & "' where codigo='" & codACf & "'"
            Dim cmd As New SqlCommand(ssql, conectarBDD)
            If conectarBDD.State = ConnectionState.Closed Then conectarBDD.Open()
            cmd.ExecuteNonQuery() : conectarBDD.Close()
            ConsultarActivo(opciones)
        End If

    End Sub

#End Region

#Region "Opciones"

    Dim opconsultar As String = ""
    Dim cadena As String = ""
    Dim depCod As String = ""
    Dim secCod As String = ""

    Private Sub btnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVer.Click
        If botonOp = 0 Then
            btnVer.Checked = False
            botonOp = 1
        Else
            btnVer.Checked = True
            botonOp = 0
        End If
        SplitContainer1.Panel1Collapsed = Not btnVer.Checked
        'opciones = My.Settings.cadena
        'ConsultarActivo(opciones)
    End Sub

    Private Sub chkCategoria_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCategoria.CheckedChanged
        If chkCategoria.Checked = True Then
            cboCategoria.Enabled = True
            cboCategoria.Focus()
        Else
            cboCategoria.Enabled = False
            cboCategoria.Text = ""
        End If
    End Sub
    Private Sub chkClase_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkClase.CheckedChanged
        If chkClase.Checked = True Then
            cboClase.Enabled = True
            cboClase.Focus()
        Else
            cboClase.Enabled = False
            cboClase.Text = ""
        End If
    End Sub

    Private Sub chkGrupo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGrupo.CheckedChanged
        If chkGrupo.Checked = True Then
            cboGrupo.Enabled = True
            cboGrupo.Focus()
        Else
            cboGrupo.Enabled = False
            cboGrupo.Text = ""
        End If
    End Sub

    Private Sub chkSubgrupo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSubgrupo.CheckedChanged
        If chkSubgrupo.Checked = True Then
            CboSubgrupo.Enabled = True
            CboSubgrupo.Focus()
        Else
            CboSubgrupo.Enabled = False
            CboSubgrupo.Text = ""
        End If
    End Sub

    Private Sub chkSucursal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSucursal.CheckedChanged
        If chkSucursal.Checked = True Then
            cboSucursal.Enabled = True
            cboSucursal.Focus()
        Else
            cboSucursal.Enabled = False
            cboSucursal.Text = ""
        End If
    End Sub

    Private Sub chkDepartamento_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDepartamento.CheckedChanged
        If chkDepartamento.Checked = True Then
            cboDepartamento.Enabled = True
            cboDepartamento.Focus()
        Else
            cboDepartamento.Enabled = False
            cboDepartamento.Text = ""
        End If
    End Sub

    Private Sub chkSeccion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSeccion.CheckedChanged
        If chkSeccion.Checked = True Then
            cboSeccion.Enabled = True
            cboSeccion.Focus()
        Else
            cboSeccion.Enabled = False
            cboSeccion.Text = ""
        End If
    End Sub

    'Private Sub chkTipoDep_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If chkTipoDep.Checked = True Then
    '        optFinanciera.Enabled = True
    '        optTributaria.Enabled = True
    '        optAmbasDep.Enabled = True
    '    Else
    '        optFinanciera.Enabled = False
    '        optTributaria.Enabled = False
    '        optAmbasDep.Enabled = False
    '        optAmbasDep.Enabled = False
    '    End If
    'End Sub
    Private Sub chkResponsable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkResponsable.CheckedChanged
        If chkResponsable.Checked = True Then
            cboResponsable.Enabled = True
            cboResponsable.Focus()
        ElseIf chkResponsable.Checked = False Then
            cboResponsable.Enabled = False
            cboResponsable.Text = ""
        End If
    End Sub
    Private Sub btnNinguna_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNinguna.Click
        chkCategoria.Checked = False
        txtDesde.Value = New DateTime(1900, 1, 1)
        txtHasta.Value = DateTime.Now
        chkGrupo.Checked = False
        chkClase.Checked = False
        chkSubgrupo.Checked = False
        chkSucursal.Checked = False
        chkDepartamento.Checked = False
        chkSeccion.Checked = False
        chkResponsable.Checked = False
        optFinanciera.Enabled = False
    End Sub
    Private Sub txtDesde_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not IsDate(gridActivos.Text) Then
            MsgBox("Ingrese una Fecha Válida", MsgBoxStyle.Information)
            gridActivos.Focus()
        End If
    End Sub
    Private Sub txtHasta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not IsDate(txtHasta.Text) Then
            MsgBox("Ingrese una Fecha Válida", MsgBoxStyle.Information)
            txtHasta.Focus()
        Else
            If CDate(txtDesde.Text) > CDate(txtHasta.Text) Then
                MsgBox("La fecha de Inicio no Puede ser Mayor a la fecha Final", MsgBoxStyle.Information)
                gridActivos.Focus()
                gridActivos.SelectAll()
            End If
        End If
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim valor As Integer = 0
        valor = verificarOpciones()
        If valor <> 0 Then
            Exit Sub
        End If
        guardarConfiguracion()
        Consulta()
        opciones = My.Settings.cadena
        ConsultarActivo(opciones)
        SplitContainer1.Panel1Collapsed = True
        If botonOp = 1 Then botonOp = 0 Else botonOp = 1
    End Sub
    Public Function verificarOpciones() As Integer
        If chkCategoria.Checked = True Then
            If cboCategoria.Text = "" Then
                MsgBox("Es necesario escoger la Categoría", MsgBoxStyle.Information)
                cboCategoria.Focus()
                Return 1
                Exit Function
            End If
        End If
        If chkClase.Checked = True Then
            If cboClase.Text = "" Then
                MsgBox("Es necesario escojer la Clase", MsgBoxStyle.Information)
                cboClase.Focus()
                Return 1
                Exit Function
            End If
        End If
        If chkGrupo.Checked = True Then
            If cboGrupo.Text = "" Then
                MsgBox("Es necesario escoger el Grupo", MsgBoxStyle.Information)
                cboGrupo.Focus()
                Return 1
                Exit Function
            End If
        End If
        If chkSubgrupo.Checked = True Then
            If CboSubgrupo.Text = "" Then
                MsgBox("Es necesario escoger el Subgrupo")
                CboSubgrupo.Focus()
                Return 1
                Exit Function
            End If
        End If
        If chkSucursal.Checked = True Then
            If cboSucursal.Text = "" Then
                MsgBox("Es necesario escoger la Sucursal")
                cboSucursal.Focus()
                Return 1
                Exit Function
            End If
        End If
        If chkDepartamento.Checked = True Then
            If cboDepartamento.Text = "" Then
                MsgBox("Es necesario escoger el Departamento", MsgBoxStyle.Information)
                cboDepartamento.Focus()
                Return 1
                Exit Function
            End If
        End If
        If chkSeccion.Checked = True Then
            If cboSeccion.Text = "" Then
                MsgBox("Es necesario escoger la Sección", MsgBoxStyle.Information)
                cboSeccion.Focus()
                Return 1
                Exit Function
            End If
        End If
        Return 0
    End Function
    Public Sub guardarConfiguracion()
        My.Settings.optTangibles = Me.optTangibles.Checked
        My.Settings.optIntangibles = Me.optIntangibles.Checked
        My.Settings.optAmbosAct = Me.optAmbosAct.Checked
        My.Settings.txtDesde = Me.gridActivos.Text
        My.Settings.txtHasta = Me.txtHasta.Text
        My.Settings.chkCategoria = Me.chkCategoria.Checked
        My.Settings.cboCategoria = Me.cboCategoria.Text
        My.Settings.chkClase = Me.chkClase.Checked
        My.Settings.cboClase = Me.cboClase.Text
        My.Settings.chkGrupo = Me.chkGrupo.Checked
        My.Settings.cboGrupo = Me.cboGrupo.Text
        My.Settings.chkSubg = Me.chkSubgrupo.Checked
        My.Settings.cboSubg = Me.CboSubgrupo.Text
        My.Settings.chkSucursal = Me.chkSucursal.Checked
        My.Settings.cboSucursal = Me.cboSucursal.Text
        My.Settings.chkDep = Me.chkDepartamento.Checked
        My.Settings.cboDep = Me.cboDepartamento.Text
        My.Settings.chkSeccion = Me.chkSeccion.Checked
        My.Settings.cboSeccion = Me.cboSeccion.Text
        My.Settings.optFinanciera = Me.optFinanciera.Checked
        My.Settings.optTributaria = Me.optTributaria.Checked
        My.Settings.optAmbasDep = Me.optAmbasDep.Checked
        My.Settings.chkResponsable = Me.chkResponsable.Checked
        My.Settings.cboResponsable = Me.cboResponsable.Text
    End Sub
    Public Sub cargarConfiguracion()
        Me.optIntangibles.Checked = My.Settings.optIntangibles
        Me.optTangibles.Checked = My.Settings.optTangibles
        Me.optAmbosAct.Checked = My.Settings.optAmbosAct
        'Me.chkFechaIng.Checked = My.Settings.chkFecIng
        Me.gridActivos.Text = My.Settings.txtDesde
        'Me.txtHasta.Text = My.Settings.txtHasta
        Me.chkCategoria.Checked = My.Settings.chkCategoria
        Me.cboCategoria.Text = My.Settings.cboCategoria
        Me.chkClase.Checked = My.Settings.chkClase
        Me.cboClase.Text = My.Settings.cboClase
        Me.chkGrupo.Checked = My.Settings.chkGrupo
        Me.cboGrupo.Text = My.Settings.cboGrupo
        Me.chkSubgrupo.Checked = My.Settings.chkSubg
        Me.CboSubgrupo.Text = My.Settings.cboSubg
        Me.chkSucursal.Checked = My.Settings.chkSucursal
        Me.cboSucursal.Text = My.Settings.cboSucursal
        Me.chkDepartamento.Checked = My.Settings.chkDep
        Me.cboDepartamento.Text = My.Settings.cboDep
        Me.chkSeccion.Checked = My.Settings.chkSeccion
        Me.cboSeccion.Text = My.Settings.cboSeccion
        Me.optFinanciera.Checked = My.Settings.optFinanciera
        Me.optTributaria.Checked = My.Settings.optTributaria
        Me.optAmbasDep.Checked = My.Settings.optAmbasDep
        Me.chkResponsable.Checked = My.Settings.chkResponsable
        Me.cboResponsable.Text = My.Settings.cboResponsable
    End Sub

    'ESTE METODO LLENA LOS COMBOS DE CATEGORIA, CLASE, GRUPO Y SUBGRUPO
    Public Sub llenarComboCat(ByVal opc As String)
        Dim ssql As String
        ssql = "Select Niv_abrevia, Niv_nombre from adcnivacf where Niv_Categor=" & opc
        If conectarBDD.State = ConnectionState.Open Then conectarBDD.Close()
        conectarBDD.Open()
        Dim datos As New DataSet()
        Dim dataAd As New SqlDataAdapter(ssql, conectarBDD)
        dataAd.Fill(datos, "adcnivacf")
        If opc = "1" Then
            cboCategoria.DataSource = datos.Tables("adcnivacf")
            cboCategoria.DisplayMember = "Niv_nombre"
            cboCategoria.ValueMember = "Niv_abrevia"
        ElseIf opc = "2" Then
            cboClase.DataSource = datos.Tables("adcnivacf")
            cboClase.DisplayMember = "Niv_nombre"
            cboClase.ValueMember = "Niv_abrevia"
        ElseIf opc = "3" Then
            cboGrupo.DataSource = datos.Tables("adcnivacf")
            cboGrupo.DisplayMember = "Niv_nombre"
            cboGrupo.ValueMember = "Niv_abrevia"
        ElseIf opc = "4" Then
            CboSubgrupo.DataSource = datos.Tables("adcnivacf")
            CboSubgrupo.DisplayMember = "Niv_nombre"
            CboSubgrupo.ValueMember = "Niv_abrevia"
        End If
        conectarBDD.Close()
    End Sub

    'METODO PARA LLENAR EL COMBO SUCURSAL
    Public Sub llenarSucursal()
        'Dim conect As New SqlConnection() '"server=SISTEMAS\SQLEXPRESS;user id=sa;password=123qweASDZXC;database=DaxSys;pooling=false")
        Dim sSql As String = ""
        sSql = "Select distinct CodSucursal as Sucursal from sys_Sucursales"
        conect.Open()
        Dim datos As New DataSet
        Dim datAd As New SqlDataAdapter(sSql, conect)
        datAd.Fill(datos, "sys_Sucursales")
        cboSucursal.DataSource = datos.Tables("sys_Sucursales")
        cboSucursal.DisplayMember = "Sucursal"
        cboSucursal.ValueMember = "Sucursal"
        conect.Close()
    End Sub

    'METODO PARA LLENAR LOS COMBOS DEPARTAMENTO Y SECCION
    Public Sub llenarDepSec(ByVal ref As String, ByVal opc As String)
        Dim sSql As String = ""
        sSql = "Select Abreviación, Descripcion from Syscod where TipoReferencia='" & ref & "' and Abreviación <> '#'"
        conect.Open()
        Dim datos As New DataSet
        Dim datAd As New SqlDataAdapter(sSql, conect)
        datAd.Fill(datos, "SysCod")
        If opc = "DEP" Then
            cboDepartamento.DataSource = datos.Tables("SysCod")
            cboDepartamento.DisplayMember = "Descripcion"
            cboDepartamento.ValueMember = "Abreviación"
        ElseIf opc = "SEC" Then
            cboSeccion.DataSource = datos.Tables("SysCod")
            cboSeccion.DisplayMember = "Descripcion"
            cboSeccion.ValueMember = "Abreviación"
        End If
        conect.Close()
    End Sub
    Public Sub llenarResponsables()
        Dim sSql As String = ""
        sSql = "Select Codigo, NombreImpresion from Identificacion where EsEmpleado=1 order by Apellidos"
        Try
            If conectarBDD.State = ConnectionState.Closed Then conectarBDD.Open()
            Dim datos As New DataSet()
            Dim dataAd As New SqlDataAdapter(sSql, conectarBDD)
            dataAd.Fill(datos, "Identificacion")
            cboResponsable.DataSource = datos.Tables("Identificacion")
            cboResponsable.DisplayMember = "NombreImpresion"
            cboResponsable.ValueMember = "Codigo"
        Catch ex As Exception
            MsgBox("Error al consultar Responsables")
        End Try
    End Sub
    Public Function Consulta() As String
        Dim tipoAct = "", fecI = "", fecF As String = ""
        Dim categoria = "", clase = "", grupo = "", subgrupo As String = ""
        Dim responsable = "", tipodep As String = ""
        Dim sucursal = "", depart = "", seccion As String = ""
        Dim opVidaUtil As String = ""
        Dim opComponentes As String = ""
        If optIntangibles.Checked = True Then
            tipoAct = " and act.TipoActivo = 'Intangibles'"
        ElseIf optTangibles.Checked = True Then
            tipoAct = " and act.TipoActivo = 'Tangibles'"
        End If
        fecI = " and act.FecIngreso >= '" & CDate(txtDesde.Text) & "' and act.FecIngreso <= '" & CDate(txtHasta.Text) & "'"
        If chkCategoria.Checked = True Then
            categoria = " and act.Categoria ='" & (cboCategoria.SelectedValue.ToString()) & "'"
        Else
            categoria = ""
        End If
        If chkClase.Checked = True Then
            clase = " and act.Clase ='" & (cboClase.SelectedValue.ToString()) & "'"
        Else
            clase = ""
        End If
        If chkGrupo.Checked = True Then
            grupo = " and act.Grupo ='" & (cboGrupo.SelectedValue.ToString()) & "'"
        Else
            grupo = ""
        End If
        If chkSubgrupo.Checked = True Then
            subgrupo = " and act.Subgrupo ='" & (CboSubgrupo.SelectedValue.ToString()) & "'"
        Else
            subgrupo = ""
        End If
        If chkSucursal.Checked = True Then
            sucursal = " and act.UbicaSucursal ='" & (cboSucursal.SelectedValue.ToString()) & "'"
        Else
            sucursal = ""
        End If
        If chkDepartamento.Checked = True Then

            depart = " and act.UbicaDepartamento ='" & (cboDepartamento.SelectedValue.ToString()) & "'"
        Else
            depart = ""
        End If
        seccion = ""
        If chkSeccion.Checked = True Then
            seccion = " and act.UbicaSeccion ='" & (cboSeccion.SelectedValue.ToString()) & "'"
        End If
        responsable = ""
        Try
            If chkResponsable.Checked Then
                responsable = " and act.Responsable ='" & (cboResponsable.SelectedValue.ToString()) & "'"
            End If
        Catch ex As Exception
        End Try
        tipodep = ""
        If optFinanciera.Checked = True Then
            tipodep = " and dep.ClaseDepreciacion = 'F'"
        ElseIf optTributaria.Checked = True Then
            tipodep = " and dep.ClaseDepreciacion = 'T'"
        End If
        opComponentes = ""
        If chkComponente.Checked = True Then
            opComponentes = " and isnull(EsComponente,0) = 1 "
        ElseIf chkPrincipal.Checked = True Then
            opComponentes = " and isnull(EsComponente,0) = 0 "
        End If
        opVidaUtil = ""
        If chkVidaUtil.Checked = True Then
            Try
                opVidaUtil = " and (case when (act.VidaUtilTributa - datediff(year,act.fecIngreso,GETDATE())) > 0 then act.VidaUtilTributa - datediff(year,act.fecIngreso,GETDATE()) else 0 end )  " + cmbOperador.Text + " " + Convert.ToInt32(txtVidaUtil.Text).ToString()
            Catch
            End Try
        End If
        cadena = tipoAct & fecI & categoria & clase & grupo & subgrupo & sucursal & depart & seccion & tipodep & responsable & opVidaUtil + opComponentes
        Return cadena
    End Function
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        cargarConfiguracion()
        opciones = My.Settings.cadena
        btnAceptar_Click(sender, e)
    End Sub
#End Region

    Private Sub btnContabilizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContabilizacion.Click
        Dim conta As New ContabilizaciónNIFS.Contabilización
        conta.DefinirContab()
    End Sub

    Private Sub btnContabiliza_Click(sender As Object, e As EventArgs) Handles btnContbiliza.Click
        Dim aa As String = ""
        Dim ussr As New DaxUsr.DaxsofUsr

        Dim ctb As New genCmpbteCtbAcf.Form2(SYSEMP.EmpresaAct.SucActual, ussr.UsuarioAct.Identifica, strconexion, strConxDaxsys, 0, SYSEMP.EmpresaAct.codigo.ToString())
        ctb.ShowDialog()
    End Sub
    Private Sub txtVidaUtil_TextChanged(sender As Object, e As EventArgs) Handles txtVidaUtil.TextChanged
        Dim numero As Int32 = 0
        Try
            numero = Convert.ToInt32(txtVidaUtil.Text)
        Catch ex As Exception
            txtVidaUtil.Text = ""
        End Try
    End Sub

    Private Sub chkVidaUtil_CheckedChanged(sender As Object, e As EventArgs) Handles chkVidaUtil.CheckedChanged
        If chkVidaUtil.Checked = True Then
            cmbOperador.Enabled = True
            txtVidaUtil.Enabled = True
            txtVidaUtil.Focus()
            cmbOperador.SelectedIndex = 0
        Else
            cmbOperador.Enabled = False
            txtVidaUtil.Enabled = False
        End If

    End Sub

    Private Sub btnPlantillaOtap_Click(sender As Object, e As EventArgs) Handles btnPlantillaOtap.Click
        Dim prog As New ImprEtiquet.frmImprEt()
        prog.Show()
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub


    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class
