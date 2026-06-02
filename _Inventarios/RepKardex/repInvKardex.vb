Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports DattCom

Public Class repInvKardex
    Dim botonOp As Boolean = False
    Dim bodega As String = ""
    Dim TipoDoc As String = ""
    Dim TipoSop As String = ""
    Dim FechaIni As Date = CDate("0:0")
    Dim fecha As Date = CDate("0:0")
    Dim fechaFin As Date = CDate("0:0")
    Dim codIni As String = ""
    Dim codFin As String = ""
    Dim SaldoFecha As Integer = 0
    Dim medidas As String = ""
    Dim articulosExiten As Integer = 0
    Dim categoria As String = ""
    Dim clase As String = ""
    Dim grupo As String = ""
    Dim subg As String = ""
    Dim costeo As String = "P"
    Dim NomCosteo As String = ""
    Dim titulo As String = ""
    Dim CCat As String = ""
    Dim CCla As String = ""
    Dim CGru As String = ""
    Dim CSub As String = ""
    Dim inclCost As Boolean = False
    Dim Clasedoc As String = "E"
    Dim codDirectorio As String = ""
    Dim NumReporte As Integer
    Dim ConPrincipal As String = "S"
    Dim ConTotal As String = "N"
    Dim Ordenar As String = ""

#Region "Datos Iniciales"
    Private Sub repInventario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SplitContainer1.Panel1Collapsed = True
        llenarCombos()
        inicializaFechas()
    End Sub
    Private Sub inicializaFechas()
        txtFechaIni.Value = New DateTime(Now.Year, Now.Month, 1)
        txtFechaFin.Value = New DateTime(Now.Year, Now.Month, DateTime.DaysInMonth(Now.Year, Now.Month))
    End Sub
    Private Sub llenarCombos()
        Dim cmbox As DaxCombobx.CargCmbBox = New DaxCombobx.CargCmbBox()
        cmbox.DaxCombosCat("C", "I", datosEmpresa.strConxAdcom, cboCategoria, True)
        cboCategoria.SelectedIndex = 0
        cmbox.DaxCombosCat("L", "I", datosEmpresa.strConxAdcom, cboClase, True)
        cboClase.SelectedIndex = 0
        cmbox.DaxCombosCat("G", "I", datosEmpresa.strConxAdcom, cboGrupo, True)
        cboGrupo.SelectedIndex = 0
        cmbox.DaxCombosCat("S", "I", datosEmpresa.strConxAdcom, cboSubg, True)
        cboSubg.SelectedIndex = 0
        cmbox.DaxCombosBods(datosEmpresa.suc, True, datosEmpresa.strConIniSis, cboBodega)
        cboBodega.SelectedIndex = 0
        '    Dim ssql As String = "select niv_categor,'Todas las categorias' as Niv_nombre,'0' as Niv_abrevia from AdcNiv where Niv_categor =1 group by Niv_categor "
        '    ssql += " union all select Niv_categor,Niv_nombre ,niv_abrevia  from AdcNiv where Niv_categor =1"
        '    llenarCategorias(ssql, cboCategoria, "Todas las categorias", "Niv_nombre", "Niv_abrevia", Label3, chkCategoria)
        '    ssql = " select niv_categor,'Todas las clases' as Niv_nombre,'0' as Niv_abrevia from AdcNiv where Niv_categor =2 group by Niv_categor "
        '    ssql += " union all select Niv_categor,Niv_nombre ,niv_abrevia  from AdcNiv where Niv_categor =2"
        '    llenarCategorias(ssql, cboClase, "Todas las clases", "Niv_nombre", "Niv_abrevia", Label4, chkClase)
        '    ssql = " select niv_categor,'Todos los grupos' as Niv_nombre,'0' as Niv_abrevia from AdcNiv where Niv_categor =3 group by Niv_categor "
        '    ssql += " union all select Niv_categor,Niv_nombre ,niv_abrevia  from AdcNiv where Niv_categor =3"
        '    llenarCategorias(ssql, cboGrupo, "Todos los grupos", "Niv_nombre", "Niv_abrevia", Label5, chkGrupo)
        '    ssql = " select niv_categor,'Todos los subgrupos' as Niv_nombre,'0' as Niv_abrevia from AdcNiv where Niv_categor =4 group by Niv_categor "
        '    ssql += " union all select Niv_categor,Niv_nombre ,niv_abrevia  from AdcNiv where Niv_categor =4"
        '    llenarCategorias(ssql, cboSubg, "Todos los subgrupos", "Niv_nombre", "Niv_abrevia", Label6, chkSubg)
        '    llenarBodegas()

        'End Sub
        'Private Sub llenarCategorias(ByVal ssql As String, ByVal cbo As ComboBox, ByVal op As String, ByVal nombre As String, ByVal cod As String, lcbo As Label, chkCbo As CheckBox)
        '    Dim datS As New DataTable
        '    datS = SqlDatos.leerTablaAdcom(ssql)
        '    cbo.DataSource = datS
        '    cbo.DisplayMember = nombre
        '    cbo.ValueMember = cod
        '    If cbo.Items.Count = 0 Then
        '        cbo.Visible = False
        '        lcbo.Visible = False
        '        chkCbo.Visible = False
        '        chkCbo.Checked = False
        '    Else
        '        cbo.SelectedIndex = 0
        '    End If
    End Sub
    'Private Sub llenarBodegas()
    '    Dim ssql As String = "select 0 AS Emp_Codigo ,'0' as Bod_Codigo,'Todas las Bodegas' as Bod_nombre  "
    '    ssql += " union all"
    '    ssql += " select Emp_Codigo,Bod_codigo,Bod_nombre from Emp_Bod where Emp_Codigo =" & datosEmpresa.Emp_codigo & " order by bod_nombre"
    '    'ssql += " and  Suc_Codigo='PRI'"
    '    Dim datS As New DataTable
    '    datS = SqlDatos.leerTablaIniSis(ssql)
    '    cboBodega.DataSource = datS
    '    cboBodega.DisplayMember = "Bod_nombre"
    '    cboBodega.ValueMember = "Bod_Codigo"
    'End Sub
#End Region

#Region "Botones de Busqueda"
    Private Sub btnCodIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtcodIni.Text = ConsultaArt()
    End Sub
    Private Sub btnCodFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtCodFin.Text = ConsultaArt()
    End Sub
#End Region

    Private Sub btnOpciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpciones.Click
        'If botonOp = 0 Then
        '    btnOpciones.Checked = False
        '    botonOp = 1
        'Else
        '    btnOpciones.Checked = True
        '    botonOp = 0
        'End If
        SplitContainer1.Panel1Collapsed = Not btnOpciones.Checked
        'limpiarReporte()
    End Sub
    Private Sub leerOpciones()
        'CAMBIAR ON ERROR Resume Next
        bodega = CStr(IIf(cboBodega.SelectedValue.ToString = "0", "", cboBodega.SelectedValue.ToString))
        If bodega = "0" Then bodega = ""

        Ordenar = CStr(IIf(Orden.Checked, "A", "C"))
        codIni = txtcodIni.Text
        codFin = txtCodFin.Text

        medidas = txtMedidas.Text
        If chkArtExis.Checked = True Then articulosExiten = 1 Else articulosExiten = 0
        If Not (cboCategoria.SelectedValue Is Nothing) Then
            categoria = CStr(IIf(cboCategoria.Visible = False, "", IIf(cboCategoria.SelectedValue.ToString = "0", "", cboCategoria.SelectedValue.ToString)))
        End If
        If Not (cboClase.SelectedValue Is Nothing) Then
            clase = CStr(IIf(cboClase.Visible = False, "", IIf(cboClase.SelectedValue.ToString = "0", "", cboClase.SelectedValue.ToString)))
        End If
        If Not (cboGrupo.SelectedValue Is Nothing) Then
            If cboGrupo.Visible = False Then grupo = "" Else grupo = CStr(IIf(cboGrupo.SelectedValue.ToString = "0", "", cboGrupo.SelectedValue.ToString))
        End If
        'subg = IIf(cboSubg.Visible = False, "", IIf(cboSubg.SelectedValue.ToString = "0", "", cboSubg.SelectedValue.ToString))
        CCat = CStr(IIf(chkCategoria.Checked, "S", "N"))
        CCla = CStr(IIf(chkClase.Checked, "S", "N"))
        CGru = CStr(IIf(chkGrupo.Checked, "S", "N"))
        CSub = CStr(IIf(chkSubg.Checked, "S", "N"))

        fecha = CDate(txtFechaIni.Text)
        fechaFin = CDate(txtFechaFin.Text)
    End Sub


#Region "Reportes"

    Private Sub limpiarReporte()
        ReportViewer1.Clear()
    End Sub

    Private Sub reporte()
        'On Error Resume Next
        ReportViewer1.Reset()
        Dim cad As String = ""
        limpiarReporte()
        leerOpciones()

        titulo = "Kardex general de inventarios : " & cboBodega.Text
        cad = "DaxKardInven '" & fecha & "','" & fechaFin & "','" & bodega & "','" & codIni & "','" & codFin & "','" & Ordenar.ToUpper & "'"

        Dim rds As New ReportDataSource()
        Dim Empresa As New ReportParameter("Empresa", datosEmpresa.Emp_Nombre)
        Dim orden As New ReportParameter("orden", "C")
        Dim nombre As New ReportParameter("Titulo", titulo)
        Dim FechaR As New ReportParameter("FechaR", fecha.ToShortDateString)
        Dim FechaE As New ReportParameter("FechaE", fechaFin.ToShortDateString)
        Dim ConCategoria As New ReportParameter("ConCategoria", CCat.ToString)
        Dim ConClase As New ReportParameter("ConClase", CCla.ToString)
        Dim ConGrupo As New ReportParameter("ConGrupo", CGru.ToString)
        Dim ConSubgrupo As New ReportParameter("ConSubgrupo", CSub.ToString)
        Dim ConAlfabetico As New ReportParameter("ConAlfabetico", Ordenar.ToString)
        Dim PRINCIPAL As New ReportParameter("PRINCIPAL", ConPrincipal)
        Dim Totaldoc As New ReportParameter("Totaldoc", ConTotal)
        Dim conUbicación As New ReportParameter("conUbicación", "N")
        If cad = "" Then Exit Sub

        Try
            Dim DT As New DataTable
            DT = SqlDatos.leerTablaAdcom(cad)
            If DT.Rows.Count = 0 Then MsgBox("No existen valores para visualizar") : Return
            rds.Name = "DataSet1"
            rds.Value = DT
        Catch ex As Exception
            MessageBox.Show("Excepción en emision de reporte de inventarios: " + vbCr + ex.Message)
        End Try

        ReportViewer1.Visible = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewer1.LocalReport.ReportPath = datosEmpresa.pathAppl & "BinNet\Rep\karinv.rdlc"
        ReportViewer1.LocalReport.SetParameters(Empresa)
        ReportViewer1.LocalReport.SetParameters(nombre)
        ReportViewer1.LocalReport.SetParameters(FechaR)
        ReportViewer1.LocalReport.SetParameters(FechaE)
        ReportViewer1.LocalReport.SetParameters(ConAlfabetico)
        'ReportViewer1.LocalReport.SetParameters(ConCategoria)
        'ReportViewer1.LocalReport.SetParameters(ConClase)
        'ReportViewer1.LocalReport.SetParameters(ConGrupo)
        'ReportViewer1.LocalReport.SetParameters(ConSubgrupo)
        ReportViewer1.LocalReport.SetParameters(PRINCIPAL)
        ReportViewer1.LocalReport.SetParameters(Totaldoc)
        Me.ReportViewer1.RefreshReport()
        If ReportViewer1.CanFocus = True Then ReportViewer1.Focus()
    End Sub
#End Region
    Private Sub Actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Actualizar.Click
        reporte()
    End Sub


    Private Sub TotalDoc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        limpiarReporte()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub verificaActualizador(boton As ToolStripButton)
        Actualizar.Enabled = (boton.CheckState = CheckState.Checked)
    End Sub
    Private Sub txtcodIni_TextChanged(sender As Object, e As EventArgs)

    End Sub
    Private Sub Label7_Click(sender As Object, e As EventArgs)

    End Sub
End Class
