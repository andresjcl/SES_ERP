Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Public Class repInventario
    Dim botonOp As Boolean = False
    Dim bodega As String = ""
    Dim TipoDoc As String = ""
    Dim fecha As Date = "0:0"
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
    Dim titulo As String = ""

#Region "Datos Iniciales"
    Private Sub repInventario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conectarBDD()
        llenarCombos()
        txtFecha.Text = Now
    End Sub
    Private Sub llenarCombos()
        Dim ssql As String = "select niv_categor,'Todas las categorias' as Niv_nombre,'0' as Niv_abrevia from AdcNiv where Niv_categor =1 group by Niv_categor "
        ssql += " union all select Niv_categor,Niv_nombre ,niv_abrevia  from AdcNiv where Niv_categor =1"
        llenarCategorias(ssql, cboCategoria, "Todas las categorias")
        ssql = " select niv_categor,'Todas las clases' as Niv_nombre,'0' as Niv_abrevia from AdcNiv where Niv_categor =2 group by Niv_categor "
        ssql += " union all select Niv_categor,Niv_nombre ,niv_abrevia  from AdcNiv where Niv_categor =2"
        llenarCategorias(ssql, cboClase, "Todas las clases")
        ssql = " select niv_categor,'Todos los grupos' as Niv_nombre,'0' as Niv_abrevia from AdcNiv where Niv_categor =3 group by Niv_categor "
        ssql += " union all select Niv_categor,Niv_nombre ,niv_abrevia  from AdcNiv where Niv_categor =3"
        llenarCategorias(ssql, cboGrupo, "Todos los grupos")
        ssql = " select niv_categor,'Todos los subgrupos' as Niv_nombre,'0' as Niv_abrevia from AdcNiv where Niv_categor =4 group by Niv_categor "
        ssql += " union all select Niv_categor,Niv_nombre ,niv_abrevia  from AdcNiv where Niv_categor =4"
        llenarCategorias(ssql, cboSubg, "Todos los subgrupos")
        llenarBodegas()
    End Sub
    Private Sub llenarCategorias(ByVal ssql As String, ByVal cbo As ComboBox, ByVal op As String)
        Dim datS As New DataSet
        Dim datAd As New SqlDataAdapter(ssql, conectar)
        cerrarConeccion(conectar)
        conectar.Open()
        datAd.Fill(datS, "Datos")
        cbo.DataSource = datS.Tables(0)
        cbo.DisplayMember = "Niv_nombre"
        cbo.ValueMember = "Niv_abrevia"
        conectar.Close()
        If cbo.Items.Count = 0 Then
            cbo.DataSource = Nothing
            cbo.Items.Add(op)
        End If
        cbo.SelectedIndex = 0
    End Sub
    Private Sub llenarBodegas()
        Dim ssql As String = "select Emp_Codigo ,'0' as Bod_Codigo,'Todas las Bodegas' as Bod_nombre from Emp_Bod where Emp_Codigo =(select Emp_Codigo from Emp_Datos where emp_nombre='" & SYSEMP.EmpresaAct.nombre & "') group by Emp_Codigo "
        ssql += " union all"
        ssql += " select Emp_Codigo,Bod_codigo,Bod_nombre from Emp_Bod where Emp_Codigo =(select Emp_Codigo from Emp_Datos where emp_nombre='EMPRESA DE EJEMPLO')"
        ssql += " and  Suc_Codigo='PRI'"
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
            GroupBox1.Visible = True
            GroupBox2.Visible = True
        Else
            GroupBox1.Visible = False
            GroupBox2.Visible = False
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
        If botonOp = 0 Then
            btnOpciones.Checked = False
            botonOp = 1
        Else
            btnOpciones.Checked = True
            botonOp = 0
        End If
        SplitContainer1.Panel1Collapsed = Not btnOpciones.Checked
    End Sub
    Private Sub leerOpciones()
        bodega = cboBodega.SelectedValue.ToString
        fecha = txtFecha.Text
        codIni = txtcodIni.Text
        codFin = txtCodFin.Text
        medidas = txtMedidas.Text
        If chkArtExis.Checked = True Then articulosExiten = 1 Else articulosExiten = 0
        categoria = cboCategoria.SelectedValue.ToString
        clase = cboClase.SelectedValue.ToString
        grupo = cboGrupo.SelectedValue.ToString
        subg = cboSubg.SelectedValue.ToString
    End Sub
    Private Sub optCostoPro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCostoPro.CheckedChanged
        costeo = "P"
    End Sub

    Private Sub optPvp1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPvp1.CheckedChanged
        costeo = "1"
    End Sub

    Private Sub optPvp3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPvp3.CheckedChanged
        costeo = "3"
    End Sub

    Private Sub optPvp5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPvp5.CheckedChanged
        costeo = "5"
    End Sub

    Private Sub optUltCost_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optUltCost.CheckedChanged
        costeo = "U"
    End Sub

    Private Sub optPvp2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPvp2.CheckedChanged
        costeo = "2"
    End Sub

    Private Sub optPvp4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPvp4.CheckedChanged
        costeo = "4"
    End Sub

    Private Sub optSinCost_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optSinCost.CheckedChanged
        costeo = "0"
    End Sub
#End Region

#Region "Reportes"
    Private Sub btnCatalogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCatalogo.Click
        Bloquear(1)
        reporte(1)
    End Sub
    Private Sub reporte(ByVal op As Integer)
        On Error Resume Next
        Dim cad As String = ""
        leerOpciones()
        Select Case op
            Case 1 ' 
                titulo = "CATALOGO DE ARTÍCULOS "
                cad = "exec DaxCB024_11 '" & fecha & "','" & bodega & "','" & codIni & "','" & codFin & "'," & articulosExiten & ",'" & costeo & "','" & categoria & "','" & clase & "'','" & grupo & "','" & subg & "'"
            Case 2

            Case 3  ' balance de resultados

            Case 4  ' balance ampliado

        End Select
        Dim rds As New ReportDataSource()
        Dim Empresa As New ReportParameter("Empresa", SYSEMP.EmpresaAct.nombre)
        Dim nombre As New ReportParameter("Titulo", titulo)
        Dim FechaR As New ReportParameter("Fecha", txtFecha.Text)
        Dim FechaE As New ReportParameter("FechaEmi", Now.Date)
        rds.Name = "DataSet1"
        rds.Value = CalcularDataSet(cad).Tables(0)
        ReportViewer1.Visible = True
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(rds)
        Select Case op
            Case 1 '"Catalogo de Articulos" Then
                ReportViewer1.LocalReport.ReportPath = EMP.PatAppl & "BinNet\Rep\Catalogo.rdlc"
            Case 2 ' "Balance General" Then
                'ReportViewer1.LocalReport.ReportPath = EMP.PatAppl & "BinNet\Rep\BalanceGeneral.rdlc"
            Case 3 ' "Balance resultados" Then
                ' ReportViewer1.LocalReport.ReportPath = EMP.PatAppl & "BinNet\Rep\BalanceGeneral.rdlc"
        End Select
        ReportViewer1.LocalReport.SetParameters(Empresa)
        ReportViewer1.LocalReport.SetParameters(nombre)
        ReportViewer1.LocalReport.SetParameters(FechaR)
        ReportViewer1.LocalReport.SetParameters(FechaE)
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Function CalcularDataSet(ByVal cadena As String) As DataSet
        Dim ssql As String = cadena
        Dim sqlAdap As New SqlDataAdapter(ssql, conectar)
        conectar.Open()
        Dim datS As New DataSet()
        sqlAdap.Fill(datS, "Activos")
        conectar.Close()
        Return datS
    End Function
#End Region


    Private Sub btnAntiguedadPrd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAntiguedadPrd.Click
        Bloquear(2)
        reporte(2)
    End Sub

    Private Sub btnMinMax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMinMax.Click
        Bloquear(3)
        reporte(3)
    End Sub
End Class
