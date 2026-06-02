Imports System.Data.SqlClient
Friend Class frmMovCta
    Dim carga As Boolean = False
    Dim cmpAdCont As Integer = 0
    Dim Cabecera As String = "Movimiento Cuenta : "
    Dim SSsql As String = ""

#Region "Datos Iniciales"
    Private Sub frmMovCta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EMP = SYSEMP.EmpresaAct()
        carga = True
        conectarBDD()
        cargarDatosIni()
        carga = False
        txtFechaIni.Text = CStr(New Date(Year(Now), Month(Now), 1))  ' "01/" & Month(Now) & "/" & Year(Now)
        txtFechaFin.Text = Now.ToShortDateString()
        If CodigoEntrada > "" Then
            txtcta.Text = CodigoEntrada
            txtFechaIni.Text = fechaIni.ToShortDateString()
            txtFechaFin.Text = fechaFin.ToShortDateString()
            procesar()
        End If
    End Sub

    Private Sub cargarDatosIni()
        Dim ssql As String = ""

        ssql = "select '0' as Opc_documento,' Todos los Documentos' as Opc_nombre union all "
        ssql += " select d.Opc_documento , op.Opc_nombre  from adcdia d left join AdcOpc op on(op.Opc_documento =d.Opc_documento) "
        ssql += " group by d.Opc_documento,op.Opc_nombre"
        llenarCombos(ssql, cboTipoDoc, "Opc_documento", "Opc_nombre")
        ssql = "select 'Sin Clasificadores' as nombre, '0' as campodia union all select nombre,campodia from AdcClasfctb where esclasificador = 1 "
        llenarCombos(ssql, cboClas, "campodia", "nombre")
        If TieneClasificadores() = False Then
            Label6.Visible = False
            cboClas.Visible = False
            cboDetClas.Visible = False
        End If
    End Sub

    Private Sub cboClas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClas.SelectedIndexChanged
        If carga = True Or cboClas.SelectedValue.ToString = "0" Then cboDetClas.DataSource = Nothing : Exit Sub
        malla.DataSource = Nothing
        If conectar.State = ConnectionState.Closed Then conectar.Open()
        Dim ssql As String = "select campodia from adcclasfctb where status <> 0 AND EsClasificador = 1 and nombre = '" + cboClas.Text + "'"
        Dim datS As New DataTable
        Dim datA As New SqlDataAdapter(ssql, conectar)
        datA.Fill(datS)

        If datS.Rows.Count > 0 Then
            Dim clsDia As String = datS.Rows(0)("campodia").ToString()
            ssql = "select '0' as Código, ' Todos' as Descripción union all "
            If clsDia.ToUpper = "DIA_EMPLEADO" Then
                ssql += " select Dia_empleado as Codigo, Dia_empleado +' - '+max(nombreImpresion) as Descripción from  adcdia"
                ssql += " left join identificacion on Codigo = DIA_empleado "
                ssql += " where isnull(Dia_empleado,'') <> ''  group by dia_empleado order by Descripción  "
            Else
                ssql += " select " + clsDia + " as codigo, " + clsDia + " as Descripción from  adcdia  where isnull(" + clsDia + ",'') <> ''  group by  " + clsDia + "  order by Descripción  "
            End If
            datS = New DataTable
            datA = New SqlDataAdapter(ssql, conectar)
            datA.Fill(datS)
            cboDetClas.DisplayMember = "Descripción"
            cboDetClas.ValueMember = "Código"
            cboDetClas.DataSource = datS
        End If
    End Sub

    Private Sub llenarCombos(ByVal cmd As String, ByVal cbo As ComboBox, ByVal cmpCod As String, ByVal cmpNom As String)
        Dim datS As New DataSet()
        Dim datA As New SqlDataAdapter(cmd, conectar)
        cerrarConeccion()
        conectar.Open()
        datA.Fill(datS, "Datos")
        cbo.DataSource = datS.Tables(0)
        cbo.DisplayMember = cmpNom
        cbo.ValueMember = cmpCod
        conectar.Close()
        datS.Dispose()
        datA.Dispose()
    End Sub
    Private Function TieneClasificadores() As Boolean
        Dim ssql As String = "select top 1 cta_codigo,clasificadores from adccta where Clasificadores > '' "
        Dim datS As SqlDataReader
        Dim data As New SqlCommand(ssql, conectar)
        cerrarConeccion()
        conectar.Open()
        datS = data.ExecuteReader
        If datS.Read Then TieneClasificadores = True Else TieneClasificadores = False
        datS.Close()
        data.Dispose()
    End Function
    Private Sub btnCta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCta.Click
        CargaCta()
    End Sub
    Private Sub txtcta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcta.TextChanged
        malla.DataSource = Nothing
        If txtcta.Text <> "" Then lblctanom.Text = CStr(nombre("select cta_nombre from adccta where cta_codigo='" & txtcta.Text & "'"))
    End Sub
    Private Sub CargaCta()
        Dim ctacte As String = ""
        Dim cta As New MantCtb.BuscaCta
        ctacte = cta.BuscaCtaCtb("", "")
        If ctacte <> "" Then txtcta.Text = ctacte : lblctanom.Text = CStr(nombre("select cta_nombre from adccta where cta_codigo='" & txtcta.Text & "'"))
    End Sub
    Private Function nombre(ByVal ssql As String) As String
        Dim nom As String = ""
        Dim cmd As New SqlCommand(ssql, conectar)
        Dim dat As SqlDataReader = Nothing
        Try
            cerrarConeccion()
            conectar.Open()
            dat = cmd.ExecuteReader()
            If dat.Read Then
                If Not IsDBNull(dat(0)) Then nom = CStr(dat(0))
            End If
            conectar.Close()
        Catch
        End Try
        Return nom
    End Function
    Private Sub cboDetClas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDetClas.SelectedIndexChanged
        malla.DataSource = Nothing
    End Sub
    Private Sub txtFechaIni_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFechaIni.TextChanged
        malla.DataSource = Nothing
    End Sub
    Private Sub txtFechaFin_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFechaFin.TextChanged
        malla.DataSource = Nothing
    End Sub

#End Region

#Region "Procesar"
    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        If txtcta.Text = "" Then MsgBox("Es necesario Escojer una Cuenta Primero", MsgBoxStyle.Information) : Exit Sub
        procesar()
    End Sub

    Private Sub procesar()
        Dim cta As String = "", cmp As String = "", nomCmp As String = "", val As String = "", TipoDoc As String = ""
        Me.Cursor = Cursors.WaitCursor
        ''''malla.DataSource = Nothing
        cta = txtcta.Text
        If cboClas.Text > "" Then
            cmp = cboClas.SelectedValue.ToString
            If cmp = "0" Then nomCmp = "" Else nomCmp = cboClas.Text
            If cboDetClas.Items.Count > 0 And cboDetClas.Text <> " Todos" Then val = cboDetClas.Text
        End If
        If cboTipoDoc.SelectedValue.ToString <> "0" Then TipoDoc = cboTipoDoc.SelectedValue.ToString
        llenarMalla(cta, cmp, val, nomCmp, TipoDoc)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub llenarMalla(ByVal cta As String, ByVal campoClas As String, ByVal valcmpCla As String, ByVal nomCmpCls As String, ByVal TipoDoc As String)
        Dim CampoUne As String = ""
        Dim campodia As String = ""
        malla.DataSource = Nothing
        Try
            If nomCmpCls > "" Then
                CampoUne = EscojeClasf(nomCmpCls, campodia)
                If campodia = "" Then MsgBox("El clasificador " & nomCmpCls & " no tiene conexión contable ") : Exit Sub
            End If

            SSsql = "exec Adc_CtaMovs '" & cta & "','" & txtFechaIni.Text & "','" & txtFechaFin.Text & "','" & nomCmpCls & "','" & valcmpCla & "','" & CampoUne & "','" & campodia & "','" & TipoDoc & "'"
            Dim datS As New DataSet()
            Dim datA As New SqlDataAdapter(SSsql, conectar)
            cerrarConeccion()
            conectar.Open()
            datA.Fill(datS, "Datos")
            With (malla)
                .DataSource = datS.Tables(0)
                .ClearSelection()
            End With
            conectar.Close()
            FormatoMalla(nomCmpCls)
            calculoSaldos()
        Catch ex As Exception
            MessageBox.Show("Excepcion contolada: " & ex.Message)
        End Try
    End Sub
    Private Sub FormatoMalla(ByVal ConClase As String)
        With malla
            .Columns(0).Width = 75
            .Columns(1).Width = 33
            .Columns(2).Width = 80
            .Columns(3).Width = 350
            .Columns(4).Width = 90
            .Columns(5).Width = 90
            .Columns(6).Width = 90
            .Columns(7).Width = 90
            .Columns(0).DefaultCellStyle.Format = "dd/MMM/yyyy"
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Columns(4).DefaultCellStyle.Format = "#,###,##0.00;(#,###,##0.00);\"
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Columns(5).DefaultCellStyle.Format = "#,###,##0.00;(#,###,##0.00);\"
            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .Columns(6).DefaultCellStyle.Format = "#,###,##0.00;(#,###,##0.00);\"
            If ConClase = "" Then .Columns(7).Visible = False
        End With
    End Sub

    Private Sub calculoSaldos()
        Dim salIni As Double = 0
        Dim saltot As Double = 0
        'salIni = Val(lblSaldoIni.Text)
        Dim deb As Double = 0
        Dim cred As Double = 0
        Dim salFin As Double = 0
        Dim mov As Double = 0
        Dim sumDeb As Double = 0
        Dim sumCre As Double = 0
        Dim campoDebito As Double = 0
        Dim campoCredito As Double = 0
        Dim FechaSal As Date
        Dim Col1 As Integer = 4
        Dim col2 As Integer = 5
        Dim ctacon As New MantCtb.Cuenta
        FechaSal = DateAdd("d", -1, txtFechaIni.Text)
        salIni = ctacon.Saldo(txtcta.Text, True, "", FechaSal.ToShortDateString())
        saltot = salIni

        For Each row As DataGridViewRow In Me.malla.Rows
            campoDebito = CDbl(row.Cells(Col1).Value)
            campoCredito = CDbl(row.Cells(col2).Value)
            sumDeb += campoDebito
            sumCre += campoCredito
            saltot += (campoDebito - campoCredito)
            row.Cells(6).Value = saltot
        Next

        salFin = salIni + sumDeb - sumCre
        lblSaldoIni.Text = Format(salIni, "#,###,##0.00")
        lblDebitos.Text = Format(sumDeb, "#,###,##0.00")
        lblCreditos.Text = Format(sumCre, "#,###,##0.00")
        lblSaldoFin.Text = Format(salFin, "#,###,##0.00")
        lbl_Movimiento.Text = Format((sumDeb - sumCre), "#,###,##0.00")
    End Sub
#End Region

#Region "Imprimir"
    Private Sub btnEnviar_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.ButtonClick

        If SSsql = "" Then Return

        PasarDataGridASQL(malla)
        Dim tit2 As String = "De: " & txtFechaIni.Text & " A: " & txtFechaFin.Text & vbCrLf '& " SaldoIni::" & lblSaldoIni.Text & " Débts:" & lblDebitos.Text & "  Cred.:" & lblCreditos.Text & " Final:" & lblSaldoFin.Text & " Mov:" & lbl_Movimiento.Text
        Dim titulo As String = Cabecera & txtcta.Text & " " & lblctanom.Text & vbCrLf & tit2

        Dim prog As New FormImpr
        prog.Reporte(SSsql, Convert.ToDateTime(txtFechaIni.Text), Convert.ToDateTime(txtFechaFin.Text), CDbl(lblSaldoIni.Text), titulo)
        ''        btnEnviar.ShowDropDown()
    End Sub

    Private Sub PasarDataGridASQL(ByVal grilla As DataGridView)
        Dim cmd As New SqlCommand()
        If conectar.State = ConnectionState.Closed Then conectar.Open()
        cmd.Connection = conectar
        Dim ssql As String = "IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AdcCctmp]') AND type in (N'U'))"
        ssql += "DROP TABLE [dbo].[AdcCctmp]"
        cmd.CommandText = ssql
        cmd.ExecuteNonQuery()
        ssql = "CREATE TABLE [dbo].[AdcCctmp]("
        ssql += "[Fecha] [date],"
        ssql += "[DOC] [char](10) ,"
        ssql += "[Numero] [varchar](18) ,"
        ssql += "[Detalle] [varchar](256) ,"
        ssql += "[Debitos] [numeric](22, 2) ,"
        ssql += "[Creditos] [numeric](22, 2) ,"
        ssql += "[Saldo] [numeric](22, 2) ,"
        ssql += "[Clasificador] [varchar](256)"
        ssql += ") ON [PRIMARY]"
        cmd.CommandText = ssql
        cmd.ExecuteNonQuery()
        Try
            'Recorremos el Datagridview
            For Each fila As System.Windows.Forms.DataGridViewRow In grilla.Rows
                cmd = New SqlCommand("insert into AdcCctmp values(@parametro1,@parametro2,@parametro3,@parametro4,@parametro5,@parametro6,@parametro7,@parametro8)", conectar)
                cmd.Parameters.Add("@parametro1", SqlDbType.Date).Value = fila.Cells(0).Value
                cmd.Parameters.Add("@parametro2", SqlDbType.VarChar).Value = fila.Cells(1).Value
                cmd.Parameters.Add("@parametro3", SqlDbType.VarChar).Value = fila.Cells(2).Value
                cmd.Parameters.Add("@parametro4", SqlDbType.VarChar).Value = fila.Cells(3).Value
                cmd.Parameters.Add("@parametro5", SqlDbType.Decimal).Value = Convert.ToDecimal(fila.Cells(4).Value)
                cmd.Parameters.Add("@parametro6", SqlDbType.Decimal).Value = Convert.ToDecimal(fila.Cells(5).Value)
                cmd.Parameters.Add("@parametro7", SqlDbType.Decimal).Value = Convert.ToDecimal(fila.Cells(6).Value)
                cmd.Parameters.Add("@parametro8", SqlDbType.VarChar).Value = fila.Cells(7).Value
                cmd.ExecuteNonQuery()
            Next
        Catch ex As Exception
            'Anunciamos el error
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirToolStripMenuItem.Click
        Dim imp As New DataGridViewPrinterApplication1.frmMain
        Dim tit2 As String = "De: " & txtFechaIni.Text & " A: " & txtFechaFin.Text & vbCrLf & " SaldoIni::" & lblSaldoIni.Text & " Débts:" & lblDebitos.Text & "  Cred.:" & lblCreditos.Text & " Final:" & lblSaldoFin.Text & " Mov:" & lbl_Movimiento.Text
        imp.imprimir(malla, Cabecera & txtcta.Text & " " & lblctanom.Text, tit2, SYSEMP.EmpresaAct.nombre)
    End Sub

    Private Sub WordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WordToolStripMenuItem.Click
        Dim exp As New ExportarGrid.Form1
        exp.Exportar(malla, "W", SYSEMP.EmpresaAct.nombre, Cabecera & txtcta.Text & " " & lblctanom.Text)
    End Sub

    Private Sub ExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelToolStripMenuItem.Click
        Dim exp As New ExportarGrid.Form1
        exp.Exportar(malla, "E", SYSEMP.EmpresaAct.nombre, Cabecera & txtcta.Text & " " & lblctanom.Text)
    End Sub

    Private Sub PDFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PDFToolStripMenuItem.Click
        Dim exp As New ExportarGrid.Form1
        exp.Exportar(malla, "P", SYSEMP.EmpresaAct.nombre, Cabecera & txtcta.Text & " " & lblctanom.Text)
    End Sub
#End Region

#Region "Salir"
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Dispose()
    End Sub
#End Region

    Private Sub malla_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles malla.Sorted
        calculoSaldos()
    End Sub

    Private Function SaldoContable(ByVal cta As String, ByVal Debe As Double, ByVal Haber As Double, ByVal Hasta As Date, ByVal Desde As Date, Optional ByVal anioAnt As Integer = 0) As Double
        Dim cod As String
        Dim Anio As Long
        Dim sal1 As Double
        Dim RsAux As SqlDataReader
        Dim Fec As String
        If cta = "" Then SaldoContable = 0 : Exit Function
        'verifico el saldo del año anterior
        If Hasta < CDate("31/12/1902") Then Hasta = Now.Date
        If Desde < CDate("31/12/1902") Then Desde = DateAdd("d", 1, EMP.ConUltAnu)
        If anioAnt = 0 Then
            If Desde.ToString() = "" Then Fec = CStr(Hasta) Else Fec = CStr(Desde)
            Anio = Year(CDate(Fec)) - 1
            cod = "SELECT Mov_saldebe,Mov_SalHaber FROM AdcCtaMov WHERE Cta_Codigo='" & cta & "' AND Mov_Fecha=" & Anio
        Else
            cod = "SELECT Mov_saldebe,Mov_SalHaber FROM AdcCtaMov WHERE Cta_Codigo='" & cta & "' AND Mov_Fecha=" & anioAnt
        End If
        Dim CONXADCOM As New SqlCommand(cod, conectar)
        RsAux = CONXADCOM.ExecuteReader()
        sal1 = 0
        Do While RsAux.Read
            sal1 = Convert.ToDouble(RsAux.Item("Mov_Saldebe")) - Convert.ToDouble(RsAux.Item("Mov_Salhaber"))
        Loop
        RsAux.Close()
        If IsDate(Hasta) Then
            'verifico que saldo hasta la fecha de inicio

            cod = "SELECT SUM(i.Dia_Valor * i.Dia_Signo) AS Val, SUM(i.Dia_Valor * ((i.dia_signo + 1)/2)) AS TotDebitos,SUM(i.Dia_Valor * ((i.dia_signo - 1)/-2)) AS TotCreditos FROM AdcDia i ,AdcDoc d " & _
            "WHERE i.Opc_Documento=d.Opc_Documento AND i.Doc_Sucursal=d.Doc_Sucursal AND i.Doc_Numero=d.Doc_Numero "
            If Desde.ToShortDateString() = "" Then
                cod = cod & " AND i.Dia_Fecha<='" & Hasta & "'"
            Else
                cod = cod & " AND i.Dia_Fecha<='" & Hasta & "' AND i.Dia_Fecha>='" & Desde & "' "
            End If

            cod = cod & " AND LEFT$(i.Cta_Codigo," & Len(cta) & ")='" & cta & "'"
            CONXADCOM.Dispose()
            CONXADCOM = New SqlCommand(cod, conectar)
            RsAux = CONXADCOM.ExecuteReader()
            Do While RsAux.Read
                sal1 = sal1 + Convert.ToDouble(RsAux.Item("val"))
                Debe = Convert.ToDouble(RsAux.Item("TotDebitoS"))
                Haber = Convert.ToDouble(RsAux.Item("TotCreditoS"))
            Loop
        End If
        RsAux.Close()
        SaldoContable = sal1
    End Function

    Private Sub cboTipoDoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoDoc.SelectedIndexChanged
        malla.DataSource = Nothing
    End Sub

    Private Sub lblctanom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblctanom.Click
        malla.DataSource = Nothing
    End Sub

End Class
