Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Public Class repInv
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

    Private Const OPcatalogo As String = "CATALOGO DE INVENTARIO"
    Private Const OPkardex As String = "KARDEX GENERAL"
    Private Const OPmovimiento As String = "RESUMEN DE MOVIMIENTOS"
    Private Const OPtransacciones As String = "TRANSACCIONES DE INVENTARIO"
    Private Const OPantiguedad As String = "ANTIGUEDAD DE ARTICULOS"
    Private Const OPmaximos As String = "MAXIMOS Y MINIMOS"

#Region "Datos Iniciales"
    Private Sub repInventario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SplitContainer1.Panel1Collapsed = True
        conectarBDD()
        llenarCombos()
        inicializaFechas()
    End Sub
    Private Sub inicializaFechas()
        Dim mes = 0, dia = 0, año As Integer = 0
        txtFecha.Text = Now.ToShortDateString
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
        txtFechaIni.Text = CStr(CDate(dia & "/" & mes & "/" & año))
    End Sub
    Private Sub llenarCombos()
        Dim ssql As String = "select niv_categor,'Todas las categorias' as Niv_nombre,'0' as Niv_abrevia from AdcNiv where Niv_categor =1 group by Niv_categor "
        ssql += " union all select Niv_categor,Niv_nombre ,niv_abrevia  from AdcNiv where Niv_categor =1"
        llenarCategorias(ssql, cboCategoria, "Todas las categorias", "Niv_nombre", "Niv_abrevia")
        ssql = " select niv_categor,'Todas las clases' as Niv_nombre,'0' as Niv_abrevia from AdcNiv where Niv_categor =2 group by Niv_categor "
        ssql += " union all select Niv_categor,Niv_nombre ,niv_abrevia  from AdcNiv where Niv_categor =2"
        llenarCategorias(ssql, cboClase, "Todas las clases", "Niv_nombre", "Niv_abrevia")
        ssql = " select niv_categor,'Todos los grupos' as Niv_nombre,'0' as Niv_abrevia from AdcNiv where Niv_categor =3 group by Niv_categor "
        ssql += " union all select Niv_categor,Niv_nombre ,niv_abrevia  from AdcNiv where Niv_categor =3"
        llenarCategorias(ssql, cboGrupo, "Todos los grupos", "Niv_nombre", "Niv_abrevia")
        ssql = " select niv_categor,'Todos los subgrupos' as Niv_nombre,'0' as Niv_abrevia from AdcNiv where Niv_categor =4 group by Niv_categor "
        ssql += " union all select Niv_categor,Niv_nombre ,niv_abrevia  from AdcNiv where Niv_categor =4"
        llenarCategorias(ssql, cboSubg, "Todos los subgrupos", "Niv_nombre", "Niv_abrevia")
        llenarBodegas()

        ssql = "select '0' as opc_documento,'Todos los Documentos' as opc_nombre"
        ssql += " union all "
        ssql += " select * from "
        ssql += " ("
        ssql += " select top 100 percent d.opc_documento,d.Doc_docnombre"
        ssql += " from AdcDoc d"
        ssql += " where(d.doc_inventario <> 0)"
        ssql += " group by d.opc_documento ,Doc_docnombre "
        ssql += " order by d.Doc_docnombre"
        ssql += " ) dd"
        llenarCategorias(ssql, cboDocumentos, "Todos los Documentos", "opc_nombre", "opc_documento")

        ssql = "select '0' as opc_documento,'Todos los Documentos' as opc_nombre "
        ssql += " union all"
        ssql += " select * from "
        ssql += " ("
        ssql += " select top 100 percent d.Doc_Docsop,o.Opc_nombre "
        ssql += " from AdcDoc d left join adcopc o"
        ssql += " on d.Doc_DocSop = o.Opc_documento "
        ssql += " where d.doc_inventario <> 0 and d.doc_docsop > '' and ISNULL(o.opc_nombre,'') > ''"
        ssql += " group by d.Doc_Docsop ,o.Opc_nombre "
        ssql += " order by o.opc_nombre"
        ssql += " ) dd"

        llenarCategorias(ssql, CboSoporte, "Todos los Documentos", "opc_nombre", "opc_documento")
        llenarOpciones()
    End Sub
    Private Sub llenarOpciones()
        cmbReportes.Items.Add(OPcatalogo)
        cmbReportes.Items.Add(OPkardex)
        cmbReportes.Items.Add(OPtransacciones)
        cmbReportes.Items.Add(OPantiguedad)
        cmbReportes.Items.Add(OPmaximos)
    End Sub
    Private Sub llenarCategorias(ByVal ssql As String, ByVal cbo As ComboBox, ByVal op As String, ByVal nombre As String, ByVal cod As String)
        Dim datS As New DataSet
        Dim datAd As New SqlDataAdapter(ssql, conectar)
        cerrarConeccion(conectar)
        conectar.Open()
        datAd.Fill(datS, "Datos")
        cbo.DataSource = datS.Tables(0)
        cbo.DisplayMember = nombre
        cbo.ValueMember = cod
        conectar.Close()
        If cbo.Items.Count = 0 Then
            cbo.Visible = False
        Else
            cbo.SelectedIndex = 0
        End If
    End Sub
    Private Sub llenarBodegas()
        Dim ssql As String = "select 0 AS Emp_Codigo ,'0' as Bod_Codigo,'Todas las Bodegas' as Bod_nombre  "
        ssql += " union all"
        ssql += " select Emp_Codigo,Bod_codigo,Bod_nombre from Emp_Bod where Emp_Codigo =" & SYSEMP.EmpresaAct.codigo & " order by bod_nombre"
        'ssql += " and  Suc_Codigo='PRI'"
        Dim datS As New DataSet
        Dim datAd As New SqlDataAdapter(ssql, conectarSys)
        cerrarConeccion(conectarSys)
        conectarSys.Open()
        datAd.Fill(datS, "Datos")
        cboBodega.DataSource = datS.Tables(0)
        cboBodega.DisplayMember = "Bod_nombre"
        cboBodega.ValueMember = "Bod_Codigo"
        conectarSys.Close()
    End Sub
    Private Sub Bloquear(ByVal op As Integer)
        If op = 1 Then
            Agrupacion.Visible = True
            ValoracionInventario.Visible = True
        ElseIf op = 2 Then
            chkArtExis.Visible = False
            chkArtExis.Checked = False
            Agrupacion.Visible = True
            ValoracionInventario.Visible = False
        ElseIf op = 3 Then
            Agrupacion.Visible = True
            ValoracionInventario.Visible = False
        ElseIf op = 4 Then
            chkCst.Visible = False
            GroupBox4.Visible = True
            GroupBox6.Visible = True
        Else
            chkCst.Visible = True
            GroupBox4.Visible = False
            GroupBox6.Visible = False
        End If
    End Sub
#End Region

#Region "Botones de Busqueda"
    Private Sub btnCodIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCodIni.Click
        txtcodIni.Text = ConsultaArt()
    End Sub
    Private Sub btnCodFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCodFin.Click
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
    Private Sub leerOpciones(ByVal op As Integer)
        'CAMBIAR ON ERROR Resume Next
        bodega = CStr(IIf(cboBodega.SelectedValue.ToString = "0", "", cboBodega.SelectedValue.ToString))
        If bodega = "0" Then bodega = ""

        Ordenar = CStr(IIf(Orden.Checked, "A", "C"))
        codIni = txtcodIni.Text
        codFin = txtCodFin.Text

        If op <> 4 And op <> 6 Then
            If op = 5 Then
                fecha = CDate(txtFechaIni.Text)
                fechaFin = CDate(txtFechaFin.Text)
            Else
                fecha = CDate(txtFecha.Text)
            End If
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
        ElseIf op = 4 Or op = 6 Then
            'If chkArtExis.Checked = True Then articulosExiten = 1 Else articulosExiten = 0
            fecha = CDate(txtFechaIni.Text)
            fechaFin = CDate(txtFechaFin.Text)
            'If op = 4 Then
            '    codIni = txtArtIni.Text
            '    codFin = txtArtFin.Text
            'End If
            inclCost = chkCst.Checked
            TipoDoc = CStr(IIf(cboDocumentos.SelectedValue.ToString = "0", "", cboDocumentos.SelectedValue.ToString))
            TipoSop = CStr(IIf(CboSoporte.SelectedValue.ToString = "0", "", CboSoporte.SelectedValue.ToString))
            codDirectorio = txtcodDir.Text
            ConPrincipal = CStr(IIf(Ordenarporprincipal.Checked, "S", "N"))
            ConTotal = CStr(IIf(TotalDoc.Checked, "S", "N"))
            End If
    End Sub
    Private Sub optDocEmi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Clasedoc = "E" ' docuemntos Emitidos
    End Sub

    Private Sub optDocSop_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Clasedoc = "S" ' documentos de Soporte
    End Sub
    Private Sub optCostoPro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCostoPro.CheckedChanged
        costeo = "P"
        NomCosteo = "Promedio"
        limpiarReporte()
    End Sub

    Private Sub optPvp1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPvp1.CheckedChanged
        costeo = "1"
        NomCosteo = "Precio 1"
        limpiarReporte()
    End Sub

    Private Sub optPvp3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPvp3.CheckedChanged
        costeo = "3"
        NomCosteo = "Precio 3"
        limpiarReporte()
    End Sub

    Private Sub optPvp5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPvp5.CheckedChanged
        costeo = "5"
        NomCosteo = "Precio 5"
        limpiarReporte()
    End Sub

    Private Sub optUltCost_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optUltCost.CheckedChanged
        costeo = "U"
        NomCosteo = "UltimaCompra"
        limpiarReporte()
    End Sub

    Private Sub optPvp2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPvp2.CheckedChanged
        costeo = "2"
        NomCosteo = "Precio 2"
        limpiarReporte()
    End Sub

    Private Sub optPvp4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPvp4.CheckedChanged
        costeo = "4"
        NomCosteo = "Precio 4"
        limpiarReporte()
    End Sub

    Private Sub optSinCost_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optSinCost.CheckedChanged
        costeo = "0"
        NomCosteo = ""
        limpiarReporte()
    End Sub
#End Region

#Region "Reportes"
    Private Sub btnCatalogo() '_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCatalogo.Click
        Me.Text = "REPORTES DE INVENTARIO :     'CATALOGO GENERAL DE ARTICULOS'"
        'verificaActualizador(btnCatalogo)
        NumReporte = 1
        Panel1.Visible = False
        Label6.Visible = False
        Label5.Visible = False
        txtFechaIni.Visible = False
        txtFechaFin.Visible = False
        Label2.Visible = True
        txtFecha.Visible = True
        chkUbicacion.Visible = True
        ArticulosGrupos.Visible = True
        ValoracionInventario.Visible = True
        limpiarReporte()
        'reporte(1)
    End Sub

    Private Sub btnAntiguedadPrd()  '_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Text = "REPORTES DE INVENTARIO :     'REPORTE DE ANTIGÜEDAD DE ARTICULOS'"
        'verificaActualizador(btnAntiguedadPrd)
        NumReporte = 2
        Panel1.Visible = False
        Label6.Visible = False
        Label5.Visible = False
        txtFechaIni.Visible = False
        txtFechaFin.Visible = False
        Label2.Visible = True
        txtFecha.Visible = True
        chkUbicacion.Visible = False
        ValoracionInventario.Visible = False
        ArticulosGrupos.Visible = True
        limpiarReporte()


        'reporte(2)
    End Sub

    Private Sub btnMinMax()  '_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Text = "REPORTES DE INVENTARIO :     'COMPARATIVO DE MAXIMOS Y MINIMOS DE INVENTARIO'"
        'verificaActualizador(btnMinMax)
        NumReporte = 3
        Panel1.Visible = False
        Label6.Visible = False
        Label5.Visible = False
        txtFechaIni.Visible = False
        txtFechaFin.Visible = False
        Label2.Visible = True
        txtFecha.Visible = True
        chkUbicacion.Visible = False
        ArticulosGrupos.Visible = True
        ValoracionInventario.Visible = False

        limpiarReporte()
        'reporte(3)
    End Sub
    Private Sub limpiarReporte()
        ReportViewer1.Clear()
    End Sub

    Private Sub reporte(ByVal op As Integer)
        'On Error Resume Next
        ReportViewer1.Reset()
        Dim cad As String = ""
        limpiarReporte()
        Bloquear(op)
        leerOpciones(op)
        Select Case op
            Case 1 ' Catálogo de artículos
                titulo = "Catálogo de artículos bodega: " & cboBodega.Text
                If NomCosteo > "" Then titulo = titulo & "valorado por: " & NomCosteo
                cad = "exec DaxInvCst '" & fecha & "','" & bodega & "','" & codIni & "','" & codFin & "'," & articulosExiten & ",'" & costeo & "','" & categoria & "','" & clase & "','" & grupo & "','" & subg & "'"
            Case 2 'Antiguedad de artículos
                titulo = "Antigûedad de artículos bodega: " & cboBodega.Text
                cad = "DaxInvAntg '" & fecha & "','" & bodega & "','" & codIni & "','" & codFin & "'," & articulosExiten & ",'" & costeo & "','" & categoria & "','" & clase & "','" & grupo & "','" & subg & "'"
            Case 3  ' Máximos y Mínimos de productos
                titulo = "Máximos y Mínimos de productos bodega: " & cboBodega.Text
                cad = "exec DaxInvCst '" & fecha & "','" & bodega & "','" & codIni & "','" & codFin & "'," & articulosExiten & ",'" & costeo & "','" & categoria & "','" & clase & "','" & grupo & "','" & subg & "'"
            Case 4  ' Movimientos de inventario
                titulo = "Transacciones de Inventario bodega: " & cboBodega.Text
                cad = "exec  DaxInvmov '" & fecha & "','" & fechaFin & "','" & bodega & "','" & codIni & "','" & codFin & "','" & TipoDoc & "','" & TipoSop & "','" & codDirectorio & "'"
            Case 5 ' kardex simplificado
                titulo = "Movimiento de Inventario bodega: " & cboBodega.Text
                cad = "exec DaxInvKarSimp '" & fecha & "','" & fechaFin & "','" & bodega & "','" & codIni & "','" & codFin & "'," & articulosExiten & ",'" & costeo & "','" & categoria & "','" & clase & "','" & grupo & "','" & subg & "'"
            Case 6 ' kardex general
                titulo = "Kardex general de inventarios : " & cboBodega.Text
                cad = "DaxKardInven '" & fecha & "','" & fechaFin & "','" & bodega & "','" & codIni & "','" & codFin & "','" & Ordenar.ToUpper & "'"
        End Select
        Dim rds As New ReportDataSource()
        Dim Empresa As New ReportParameter("Empresa", SYSEMP.EmpresaAct.nombre)
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
        Dim conUbicación As New ReportParameter("conUbicación", IIf(chkUbicacion.Checked, "S", "N").ToString())
        If cad = "" Then Exit Sub
        'If op = 4 Or op = 6 Then rds.Name = "DataSet2" Else 

        Try
            Dim DT As New DataTable
            Dim da As New SqlDataAdapter(cad, strConxDaxsys)
            da.Fill(DT)
            'DT = CalcularDataSet(cad)
            If DT.Rows.Count = 0 Then MsgBox("No existen valores para visualizar") : Return
            rds.Name = "DataSet1"
            rds.Value = DT
        Catch ex As Exception
            MessageBox.Show("Excepción en emision de reporte de inventarios: " + vbCr + ex.Message)
        End Try

        ReportViewer1.Visible = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(rds)
        Select Case op
            Case 1 '"Catalogo de Articulos" 
                ReportViewer1.LocalReport.ReportPath = SYSEMP.EmpresaAct.PatAppl & "BinNet\Rep\Catalogo.rdlc"
            Case 2 ' antiguedad
                ReportViewer1.LocalReport.ReportPath = SYSEMP.EmpresaAct.PatAppl & "BinNet\Rep\InvAntg.rdlc"
            Case 3 ' minimos maximos
                ReportViewer1.LocalReport.ReportPath = SYSEMP.EmpresaAct.PatAppl & "BinNet\Rep\InvMMax.rdlc"
            Case 4 ' transacciones inventarios
                ReportViewer1.LocalReport.ReportPath = SYSEMP.EmpresaAct.PatAppl & "BinNet\Rep\InvMovart.rdlc"
            Case 5 ' movimiento inventarios
                ReportViewer1.LocalReport.ReportPath = SYSEMP.EmpresaAct.PatAppl & "BinNet\Rep\Movimiento.rdlc"
            Case 6 ' kardex general inventarios
                ReportViewer1.LocalReport.ReportPath = SYSEMP.EmpresaAct.PatAppl & "BinNet\Rep\karinv.rdlc"
        End Select
        '        If op <> 6 Then
        ReportViewer1.LocalReport.SetParameters(Empresa)
        ReportViewer1.LocalReport.SetParameters(nombre)
        ReportViewer1.LocalReport.SetParameters(FechaR)
        ReportViewer1.LocalReport.SetParameters(FechaE)
        ReportViewer1.LocalReport.SetParameters(ConAlfabetico)
        If op = 1 Then ReportViewer1.LocalReport.SetParameters(conUbicación)
        'End If
        If op < 4 Or op = 5 Then
            ReportViewer1.LocalReport.SetParameters(ConCategoria)
            ReportViewer1.LocalReport.SetParameters(ConClase)
            ReportViewer1.LocalReport.SetParameters(ConGrupo)
            ReportViewer1.LocalReport.SetParameters(ConSubgrupo)
        End If
        If op = 4 Or op = 6 Then
            ReportViewer1.LocalReport.SetParameters(PRINCIPAL)
            ReportViewer1.LocalReport.SetParameters(Totaldoc)
        End If
        Me.ReportViewer1.RefreshReport()
        If ReportViewer1.CanFocus = True Then ReportViewer1.Focus()
    End Sub
    Private Function CalcularDataSet(ByVal cadena As String) As DataTable    
        Dim sqlAdap As New SqlDataAdapter(cadena, strConxDaxsys)
        Dim datS As New DataTable
        sqlAdap.Fill(datS)
        Return datS
        'End Using
    End Function
#End Region

#Region "Movimientos de Inventario"
    Private Sub btnTransInv() '_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransInv.Click
        Me.Text = "REPORTES DE INVENTARIO :     'REPORTE DE TRANSACCIONES'"
        'verificaActualizador(btnTransInv)
        NumReporte = 4
        Panel1.Visible = True
        Label6.Visible = True
        Label5.Visible = True
        txtFechaIni.Visible = True
        txtFechaFin.Visible = True
        Label2.Visible = False
        txtFecha.Visible = False
        chkUbicacion.Visible = False
        ArticulosGrupos.Visible = False
        ValoracionInventario.Visible = False

        limpiarReporte()
        'reporte(4)
    End Sub

    Private Sub btnKardexSimplificado() '_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKardexSimplificado.Click
        Me.Text = "REPORTES DE INVENTARIO :     'RESUMEN DE MOVIMIENTOS DE ARTICULOS'"
        'verificaActualizador(btnKardexSimplificado)
        NumReporte = 5
        Panel1.Visible = False
        Label6.Visible = True
        Label5.Visible = True
        txtFechaIni.Visible = True
        txtFechaFin.Visible = True
        Label2.Visible = False
        txtFecha.Visible = False
        Label5.Visible = False
        Label6.Visible = False
        chkUbicacion.Visible = False
        ArticulosGrupos.Visible = True
        ValoracionInventario.Visible = False

        limpiarReporte()
        'reporte(5)
    End Sub

    Private Sub btnkardex() '_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKardex.Click
        Me.Text = "REPORTES DE INVENTARIO :     'KARDEX GENERAL DE ARTICULOS'"
        'verificaActualizador(btnKardex)
        NumReporte = 6
        Panel1.Visible = False
        Label6.Visible = True
        Label5.Visible = True
        txtFechaIni.Visible = True
        txtFechaFin.Visible = True
        Label2.Visible = False
        txtFecha.Visible = False
        Agrupacion.Visible = False
        ArticulosGrupos.Visible = True
        chkUbicacion.Visible = False
        ValoracionInventario.Visible = False
        ValoracionInventario.Visible = False

        GroupBox4.Visible = True
        GroupBox5.Visible = True
        limpiarReporte()
        '        reporte(6)
    End Sub

    Private Sub btnArtIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArtIni.Click
        limpiarReporte()
        txtArtIni.Text = ConsultaArt()
    End Sub

    Private Sub btnArtFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArtFin.Click
        limpiarReporte()
        txtArtFin.Text = ConsultaArt()
    End Sub

    Private Sub btnDir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim dir As New MantenimientoDirectorio.BusDirectorio
        Dim cod = "", nom As String = ""
        limpiarReporte()
        txtcodDir.Text = dir.BusDirect(txtcodDir.Text, "", nom, "")
        lblnombre.Text = nom
    End Sub

#End Region

    Private Sub Actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Actualizar.Click
        If cmbReportes.Text.Length < 1 Then Return

        Select Case cmbReportes.Text
            Case OPcatalogo
                btnCatalogo()
            Case OPkardex
                btnkardex()
            Case OPmovimiento
                btnKardexSimplificado()
            Case OPtransacciones
                btnTransInv()
            Case OPantiguedad
                btnAntiguedadPrd()
            Case OPmaximos
                btnMinMax()
        End Select
        reporte(NumReporte)

    End Sub

    Private Sub btnDir_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDir.Click
        Dim prog As New MantenimientoDirectorio.BusDirectorio
        Dim codigo As String = ""
        Dim nombre As String = ""
        Dim cedula As String = ""
        Dim NomAlias As String = ""
        limpiarReporte()
        txtcodDir.Text = prog.BusDirect(codigo, cedula, nombre, NomAlias)
        Label18.Text = nombre
    End Sub

    Private Sub Ordenarporprincipal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ordenarporprincipal.CheckedChanged
        limpiarReporte()
    End Sub

    Private Sub Ordenarporsoporte_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ordenarporsoporte.CheckedChanged
        limpiarReporte()
    End Sub

    Private Sub cboDocumentos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDocumentos.Click
        limpiarReporte()
    End Sub

    Private Sub CboSoporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboSoporte.Click
        limpiarReporte()
    End Sub

    Private Sub TotalDoc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TotalDoc.CheckedChanged
        limpiarReporte()
    End Sub

    Private Sub chkCst_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCst.CheckedChanged
        limpiarReporte()
    End Sub

    Private Sub txtcodDir_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcodDir.TextChanged
        limpiarReporte()
    End Sub

    Private Sub txtArtIni_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtArtIni.TextChanged
        limpiarReporte()
    End Sub

    Private Sub txtArtFin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtArtFin.TextChanged
        limpiarReporte()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub verificaActualizador(boton As ToolStripButton)
        Actualizar.Enabled = (boton.CheckState = CheckState.Checked)
    End Sub

    Private Sub cmbReportes_TextChanged(sender As Object, e As System.EventArgs) Handles cmbReportes.TextChanged
        If cmbReportes.Text.Length < 1 Then Return
        Select Case cmbReportes.Text
            Case OPcatalogo
                btnCatalogo()
            Case OPkardex
                btnkardex()
            Case OPmovimiento
                btnKardexSimplificado()
            Case OPtransacciones
                btnTransInv()
            Case OPantiguedad
                btnAntiguedadPrd()
            Case OPmaximos
                btnMinMax()
        End Select
    End Sub


    Private Sub txtcodIni_TextChanged(sender As Object, e As EventArgs) Handles txtcodIni.TextChanged

    End Sub
    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub
End Class
