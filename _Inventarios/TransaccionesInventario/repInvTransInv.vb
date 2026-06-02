Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports DattCom

Public Class repInvTransInv
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
    Dim Clasedoc As String = "E"
    Dim codDirectorio As String = ""
    Dim ConPrincipal As String = "S"
    Dim ConTotal As String = "N"
    Dim Ordenar As String = ""
    Dim articuloOdocumento As String = "A"


#Region "Datos Iniciales"
    Private Sub repInventario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SplitContainer1.Panel1Collapsed = True
        Me.Text = "LISTA DE TRANSACCIONES DE INVENTARIO"
        llenarCombos()
        inicializaFechas()
    End Sub
    Private Sub inicializaFechas()
        txtFechaIni.Value = New DateTime(Now.Year, Now.Month, 1)
        txtFechaFin.Value = New DateTime(Now.Year, Now.Month, DateTime.DaysInMonth(Now.Year, Now.Month))
    End Sub
    Private Sub llenarCombos()

        Dim cmbox As DaxCombobx.CargCmbBox = New DaxCombobx.CargCmbBox()
        cmbox.DaxCombosDoc("INV", "", True, datosEmpresa.strConxAdcom, cboDocumentos)
        cboDocumentos.SelectedIndex = 0
        cmbox.DaxCombosDoc("", "", True, datosEmpresa.strConxAdcom, CboSoporte)
        CboSoporte.SelectedIndex = 0
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

        '    ssql = "select '0' as opc_documento,'Todos los Documentos' as opc_nombre"
        '    ssql += " union all "
        '    ssql += " select * from "
        '    ssql += " ("
        '    ssql += " select top 100 percent d.opc_documento,d.Doc_docnombre"
        '    ssql += " from AdcDoc d"
        '    ssql += " where(d.doc_inventario <> 0)"
        '    ssql += " group by d.opc_documento ,Doc_docnombre "
        '    ssql += " order by d.Doc_docnombre"
        '    ssql += " ) dd"
        '    llenarCategorias(ssql, cboDocumentos, "Todos los Documentos", "opc_nombre", "opc_documento", Label11, chkSubg)

        '    ssql = "select '0' as opc_documento,'Todos los Documentos' as opc_nombre "
        '    ssql += " union all"
        '    ssql += " select * from "
        '    ssql += " ("
        '    ssql += " select top 100 percent d.Doc_Docsop,o.Opc_nombre "
        '    ssql += " from AdcDoc d left join adcopc o"
        '    ssql += " on d.Doc_DocSop = o.Opc_documento "
        '    ssql += " where d.doc_inventario <> 0 and d.doc_docsop > '' and ISNULL(o.opc_nombre,'') > ''"
        '    ssql += " group by d.Doc_Docsop ,o.Opc_nombre "
        '    ssql += " order by o.opc_nombre"
        '    ssql += " ) dd"

        '    llenarCategorias(ssql, CboSoporte, "Todos los Documentos", "opc_nombre", "opc_documento", Label12, chkSubg)
        'End Sub
        'Private Sub llenarCategorias(ByVal ssql As String, ByVal cbo As ComboBox, ByVal op As String, ByVal nombre As String, ByVal cod As String, lcbo As Label, chkCbo As CheckBox)
        '    Dim datS As New Datatable
        '    'Dim datAd As New SqlDataAdapter(ssql, conectar)
        '    'cerrarConeccion(conectar)
        '    'conectar.Open()
        '    'datAd.Fill(datS, "Datos")
        '    cbo.DataSource = sys
        '    cbo.DisplayMember = nombre
        '    cbo.ValueMember = cod
        '    conectar.Close()
        '    If cbo.Items.Count = 0 Then
        '        cbo.Visible = False
        '        lcbo.Visible = False
        '        chkCbo.Visible = False
        '        chkCbo.Checked = False
        '    Else
        '        cbo.SelectedValue = "0"
        '    End If
        'End Sub
        'Private Sub llenarBodegas()
        '    Dim ssql As String = "select 0 AS Emp_Codigo ,'0' as Bod_Codigo,'Todas las Bodegas' as Bod_nombre  "
        '    ssql += " union all"
        '    ssql += " select Emp_Codigo,Bod_codigo,Bod_nombre from Emp_Bod where Emp_Codigo =" & datosEmpresa.Emp_codigo & " order by bod_nombre"
        '    'ssql += " and  Suc_Codigo='PRI'"
        '    Dim datS = SqlDatos.leerTablaIniSis(ssql)
        '    cboBodega.DataSource = datS
        '    cboBodega.DisplayMember = "Bod_nombre"
        '    cboBodega.ValueMember = "Bod_Codigo"
        '    cboBodega.SelectedValue = "0"
        '    conectarSys.Close()
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
        SplitContainer1.Panel1Collapsed = Not btnOpciones.Checked
    End Sub
    Private Sub leerOpciones()
        'CAMBIAR ON ERROR Resume Next
        bodega = CStr(IIf(cboBodega.SelectedValue.ToString = "0", "", cboBodega.SelectedValue.ToString))
        If bodega = "0" Then bodega = ""

        If chkOrden.Checked = True Then Ordenar = "A" Else Ordenar = "C"
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
        CGru = CStr(IIf(chkGrupo.Checked, "S", "N"))
        CSub = CStr(IIf(chkSubg.Checked, "S", "N"))

        articuloOdocumento = IIf(chkPorArticulo.Checked = True, "A", "D").ToString()
        FechaIni = CDate(txtFechaIni.Text)
        fechaFin = CDate(txtFechaFin.Text)
        codIni = txtcodIni.Text
        codFin = txtCodFin.Text
        TipoDoc = CStr(IIf(cboDocumentos.SelectedValue.ToString = "0", "", cboDocumentos.SelectedValue.ToString))
        TipoSop = CStr(IIf(CboSoporte.SelectedValue.ToString = "0", "", CboSoporte.SelectedValue.ToString))
        codDirectorio = txtcodDir.Text
        ConPrincipal = CStr(IIf(Ordenarporprincipal.Checked, "S", "N"))
        ConTotal = CStr(IIf(TotalDoc.Checked, "S", "N"))
    End Sub
    Private Sub optDocEmi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Clasedoc = "E" ' docuemntos Emitidos
    End Sub

    Private Sub optDocSop_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Clasedoc = "S" ' documentos de Soporte
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
        titulo = "Transacciones de Inventario bodega: " & cboBodega.Text

        ' @FechaIni as datetime			-- FECHA DESDE LAS TRANSACCIONES
        ',@FechaSaldo as datetime			-- FECHA HASTA EL MOVIMIENTO
        ',@BODEGA AS VARCHAR(25) = ''		-- CODIGO DE BODEGA O '' PARA TODAS LAS BODEGAS
        ',@CODIGO1 as VARCHAR(25) = ''		-- DESDE EL ARTICULO CODIGO1 HASTA CODIGO2 si = '' ver todos
        ',@CODIGO2 as VARCHAR(25) = ''
        ',@TipoDoc as varchar(15)=''
        ',@TipoSop as varchar(15)=''
        ',@Cliente as varchar(20)=''
        ',@Categoria as varchar(10)=''
        ',@Clase as varchar(10)=''
        ',@Grupo as varchar(10)=''
        ',@Subgrupo as varchar(10)=''
        ',@porArtDOc as varchar(1)=''
        ',@conCategoria as varchar(1)=''
        ',@conClase as varchar(1)=''
        ',@conGrupo as varchar(1)=''
        ',@conSubGrupo as varchar(1)=''

        cad = "exec  DaxInvmov '" & FechaIni & "','" & fechaFin & "','" & bodega & "','" & codIni & "','" & codFin & "','" & TipoDoc & "','" & TipoSop & "','" & codDirectorio & "'"
        cad += ",'" & categoria & "','" & clase & "','" & grupo & "','" & subg & "','" & articuloOdocumento & "','" & CCat & "','" & CCla & "','" & CGru & "','" & CSub & "','" & Ordenar & "'"

        Dim rds As New ReportDataSource()
        Dim Empresa As New ReportParameter("Empresa", datosEmpresa.Emp_Nombre)
        Dim orden As New ReportParameter("orden", "C")
        Dim nombre As New ReportParameter("Titulo", titulo)
        Dim FechaR As New ReportParameter("FechaR", fecha.ToShortDateString)
        Dim FechaE As New ReportParameter("FechaE", fechaFin.ToShortDateString)
        Dim Pcategoria As New ReportParameter("categoria", CCat.ToString)
        Dim Pclase As New ReportParameter("clase", CCla.ToString)
        Dim Pgrupo As New ReportParameter("grupo", CGru.ToString)
        Dim Psubgrupo As New ReportParameter("subgrupo", CSub.ToString)
        Dim ConAlfabetico As New ReportParameter("ConAlfabetico", Ordenar.ToString)
        Dim PRINCIPAL As New ReportParameter("PRINCIPAL", ConPrincipal)
        Dim Totaldoc As New ReportParameter("Totaldoc", ConTotal)

        If cad = "" Then Exit Sub
        Try
            Dim DT As New DataTable
            Dim da As New SqlDataAdapter(cad, datosEmpresa.strConxAdcom)
            da.Fill(DT)
            'DT = CalcularDataSet(cad)
            If DT.Rows.Count = 0 Then MsgBox("No existen valores para visualizar") : Return
            rds.Name = "DataSet1"
            rds.Value = DT
        Catch ex As Exception
            MessageBox.Show("Excepción en emision de reporte de inventarios: " + vbCr + ex.Message)
            Return
        End Try

        ReportViewer1.Visible = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(rds)
        If chkPorArticulo.Checked = True Then
            ReportViewer1.LocalReport.ReportPath = datosEmpresa.pathAppl & "BinNet\Rep\InvMovart.rdlc"
        Else
            ReportViewer1.LocalReport.ReportPath = datosEmpresa.pathAppl & "BinNet\Rep\InvMovartDoc.rdlc"
        End If

        ReportViewer1.LocalReport.SetParameters(Empresa)
        ReportViewer1.LocalReport.SetParameters(nombre)
        ReportViewer1.LocalReport.SetParameters(FechaR)
        ReportViewer1.LocalReport.SetParameters(FechaE)

        If chkPorArticulo.Checked = False Then
            ReportViewer1.LocalReport.SetParameters(Pcategoria)
            ReportViewer1.LocalReport.SetParameters(Pclase)
            ReportViewer1.LocalReport.SetParameters(Pgrupo)
            ReportViewer1.LocalReport.SetParameters(Psubgrupo)
        End If

        ReportViewer1.LocalReport.SetParameters(PRINCIPAL)
        ReportViewer1.LocalReport.SetParameters(Totaldoc)

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

    Private Sub btnDir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim dir As New directMnt.BusDirectorio
        Dim cod = "", nom As String = ""
        limpiarReporte()
        txtcodDir.Text = dir.BusDirect(txtcodDir.Text, cod, nom, "", "", "")
        'lblnombre.Text = nom
    End Sub

#End Region

    Private Sub Actualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Actualizar.Click
        reporte()
    End Sub

    Private Sub btnDir_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim prog As New directMnt.BusDirectorio()
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

    Private Sub chkCst_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        limpiarReporte()
    End Sub

    Private Sub txtcodDir_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcodDir.TextChanged
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

End Class
