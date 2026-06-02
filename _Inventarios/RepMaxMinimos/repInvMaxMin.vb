Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports DattCom

Public Class repInvMaxMin
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
    Dim ConPrincipal As String = "S"
    Dim ConTotal As String = "N"
    Dim Ordenar As String = ""

#Region "Datos Iniciales"
    Private Sub repInventario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SplitContainer1.Panel1Collapsed = True
        llenarCombos()
        inicializaFechas()
        Me.ReportViewer1.RefreshReport()
    End Sub
    Private Sub inicializaFechas()
        Dim mes = 0, dia = 0, año As Integer = 0
        txtFechaFin.Text = Now.ToShortDateString
        año = Year(Now)
        mes = Month(Now)
        dia = CInt(LSet(txtFechaFin.Text, 2))
        If mes > 1 Then mes -= 1 Else mes = 12 : año -= 1
        If dia >= 30 And mes = 2 Then
            If año Mod 4 = 0 Then
                If año Mod 100 = 0 And Not (año Mod 400 = 0) Then dia = 28 Else dia = 29
            Else : dia = 28
            End If
        ElseIf dia = 31 And mes <> 2 Then
            If mes = 2 Or mes = 4 Or mes = 6 Or mes = 9 Or mes = 11 Then dia = 30
        End If
    End Sub
    Private Sub llenarCombos()
        Dim ssql As String = "select niv_categor,'Todas las categorias' as Niv_nombre,'0' as Niv_abrevia from AdcNiv where Niv_categor =1 group by Niv_categor "
        ssql += " union all select Niv_categor,Niv_nombre ,niv_abrevia  from AdcNiv where Niv_categor =1"
        llenarCategorias(ssql, cboCategoria, "Todas las categorias", "Niv_nombre", "Niv_abrevia", Label3, chkCategoria)
        ssql = " select niv_categor,'Todas las clases' as Niv_nombre,'0' as Niv_abrevia from AdcNiv where Niv_categor =2 group by Niv_categor "
        ssql += " union all select Niv_categor,Niv_nombre ,niv_abrevia  from AdcNiv where Niv_categor =2"
        llenarCategorias(ssql, cboClase, "Todas las clases", "Niv_nombre", "Niv_abrevia", Label4, chkClase)
        ssql = " select niv_categor,'Todos los grupos' as Niv_nombre,'0' as Niv_abrevia from AdcNiv where Niv_categor =3 group by Niv_categor "
        ssql += " union all select Niv_categor,Niv_nombre ,niv_abrevia  from AdcNiv where Niv_categor =3"
        llenarCategorias(ssql, cboGrupo, "Todos los grupos", "Niv_nombre", "Niv_abrevia", Label5, chkGrupo)
        ssql = " select niv_categor,'Todos los subgrupos' as Niv_nombre,'0' as Niv_abrevia from AdcNiv where Niv_categor =4 group by Niv_categor "
        ssql += " union all select Niv_categor,Niv_nombre ,niv_abrevia  from AdcNiv where Niv_categor =4"
        llenarCategorias(ssql, cboSubg, "Todos los subgrupos", "Niv_nombre", "Niv_abrevia", Label6, chkSubg)
        llenarBodegas()
    End Sub
    Private Sub llenarCategorias(ByVal ssql As String, ByVal cbo As ComboBox, ByVal op As String, ByVal nombre As String, ByVal cod As String, lcbo As Label, chkCbo As CheckBox)
        Dim datS As New DataTable
        datS = SqlDatos.leerTablaAdcom(ssql)
        cbo.DataSource = datS
        cbo.DisplayMember = nombre
        cbo.ValueMember = cod
        If cbo.Items.Count = 0 Then
            cbo.Visible = False
            lcbo.Visible = False
            chkCbo.Visible = False
            chkCbo.Checked = False
        Else
            cbo.SelectedIndex = 0
        End If
    End Sub
    Private Sub llenarBodegas()
        Dim ssql As String = "select 0 AS Emp_Codigo ,'0' as Bod_Codigo,'Todas las Bodegas' as Bod_nombre  "
        ssql += " union all"
        ssql += " select Emp_Codigo,Bod_codigo,Bod_nombre from Emp_Bod where Emp_Codigo =" & datosEmpresa.Emp_codigo & " order by bod_nombre"
        'ssql += " and  Suc_Codigo='PRI'"
        Dim datS As New DataTable
        datS = SqlDatos.leerTablaIniSis(ssql)
        cboBodega.DataSource = datS
        cboBodega.DisplayMember = "Bod_nombre"
        cboBodega.ValueMember = "Bod_Codigo"
        cboBodega.SelectedValue = "0"
    End Sub
#End Region

#Region "Botones de Busqueda"
    Private Sub btnCodIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtcodIni.Text = ConsultaArt()
    End Sub
    Private Sub btnCodFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtCodFin.Text = ConsultaArt()
    End Sub
#End Region

#Region "Opciones"
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

        fecha = CDate(txtFechaFin.Text)
        fechaFin = CDate(txtFechaFin.Text)
        If chkArtExis.Checked = True Then articulosExiten = 1 Else articulosExiten = 0
        codIni = txtcodIni.Text
        codFin = txtCodFin.Text

        If Not (cboCategoria.SelectedValue Is Nothing) Then
            categoria = CStr(IIf(cboCategoria.Visible = False, "", IIf(cboCategoria.SelectedValue.ToString = "0", "", cboCategoria.SelectedValue.ToString)))
        End If
        If Not (cboClase.SelectedValue Is Nothing) Then

            clase = CStr(IIf(cboClase.Visible = False, "", IIf(cboClase.SelectedValue.ToString = "0", "", cboClase.SelectedValue.ToString)))
        End If
        If Not (cboGrupo.SelectedValue Is Nothing) Then
            If cboGrupo.Visible = False Then grupo = "" Else grupo = CStr(IIf(cboGrupo.SelectedValue.ToString = "0", "", cboGrupo.SelectedValue.ToString))
        End If
        If Not (cboGrupo.SelectedValue Is Nothing) Then
            If cboSubg.Visible = False Then subg = "" Else subg = CStr(IIf(cboSubg.SelectedValue.ToString = "0", "", cboSubg.SelectedValue.ToString))
        End If

        CCat = CStr(IIf(chkCategoria.Checked, "S", "N"))
        CCla = CStr(IIf(chkClase.Checked, "S", "N"))
        CGru = CStr(IIf(chkClase.Checked, "S", "N"))
        CSub = CStr(IIf(chkSubg.Checked, "S", "N"))
        inclCost = False
        TipoDoc = "0"
        TipoSop = "0"
        codDirectorio = ""
        ConPrincipal = "N"
        ConTotal = "N"
    End Sub
    Private Sub optDocEmi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Clasedoc = "E" ' docuemntos Emitidos
    End Sub

    Private Sub optDocSop_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Clasedoc = "S" ' documentos de Soporte
    End Sub
    Private Sub optCostoPro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        costeo = "P"
        NomCosteo = "Promedio"
        limpiarReporte()
    End Sub

    Private Sub optPvp1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        costeo = "1"
        NomCosteo = "Precio 1"
        limpiarReporte()
    End Sub

    Private Sub optPvp3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        costeo = "3"
        NomCosteo = "Precio 3"
        limpiarReporte()
    End Sub

    Private Sub optPvp5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        costeo = "5"
        NomCosteo = "Precio 5"
        limpiarReporte()
    End Sub

    Private Sub optUltCost_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        costeo = "U"
        NomCosteo = "UltimaCompra"
        limpiarReporte()
    End Sub

    Private Sub optPvp2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        costeo = "2"
        NomCosteo = "Precio 2"
        limpiarReporte()
    End Sub

    Private Sub optPvp4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        costeo = "4"
        NomCosteo = "Precio 4"
        limpiarReporte()
    End Sub

    Private Sub optSinCost_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        costeo = "0"
        NomCosteo = ""
        limpiarReporte()
    End Sub
#End Region

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
        titulo = "Máximos y Mínimos de productos bodega: " & cboBodega.Text
        cad = "exec DaxInvMaxMin '" & fecha & "','" & bodega & "','" & codIni & "','" & codFin & "'," & articulosExiten & ",'" & costeo & "','" & categoria & "','" & clase & "','" & grupo & "','" & subg & "'"
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
        'If op = 4 Or op = 6 Then rds.Name = "DataSet2" Else 

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
        ReportViewer1.LocalReport.ReportPath = datosEmpresa.pathAppl & "BinNet\Rep\InvMMax.rdlc"
        '        If op <> 6 Then
        ReportViewer1.LocalReport.SetParameters(Empresa)
        ReportViewer1.LocalReport.SetParameters(nombre)
        ReportViewer1.LocalReport.SetParameters(FechaR)
        ReportViewer1.LocalReport.SetParameters(FechaE)
        ReportViewer1.LocalReport.SetParameters(ConAlfabetico)
        ReportViewer1.LocalReport.SetParameters(ConCategoria)
        ReportViewer1.LocalReport.SetParameters(ConClase)
        ReportViewer1.LocalReport.SetParameters(ConGrupo)
        ReportViewer1.LocalReport.SetParameters(ConSubgrupo)
        Me.ReportViewer1.RefreshReport()
        If ReportViewer1.CanFocus = True Then ReportViewer1.Focus()
    End Sub
#End Region

    Private Sub Actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Actualizar.Click
        reporte()
    End Sub
    Private Sub Ordenarporprincipal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        limpiarReporte()
    End Sub

    Private Sub chkCst_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        limpiarReporte()
    End Sub

    Private Sub txtcodDir_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        limpiarReporte()
    End Sub

    Private Sub txtArtIni_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        limpiarReporte()
    End Sub

    Private Sub txtArtFin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        limpiarReporte()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub verificaActualizador(boton As ToolStripButton)
        Actualizar.Enabled = (boton.CheckState = CheckState.Checked)
    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load

    End Sub
End Class
