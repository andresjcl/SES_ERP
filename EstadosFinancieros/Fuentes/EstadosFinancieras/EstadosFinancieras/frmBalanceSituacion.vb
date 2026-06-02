Option Explicit On
Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class frmBalanceSituacion
    Dim conectar As New SqlConnection()
    Dim SYSEMP As New AdcDax.DaxsofSys
    Dim EMP As AdcDax.Empresa
    Dim fecha, fecha1, fechaAnt, fechaAnt1 As Date
    Dim ban As Integer = 0
    Dim meses As String = ""
    Dim nivel, exp As Integer
    Dim posX, posy, bandera, numeroNota As Integer
    Dim fila = 0, columna = 0, grabarNota = 0, BalanceImprimir As Integer = 1
    Dim ref = True, cod = True, nom = True, añ = True, añ1 = True, dif = True, por As Boolean = True
    Dim nombreMes, expresadoEn As String
    Dim report As Integer = 1
    Dim BotonOp As Integer = 0
    Dim PonerResultado As Boolean = False
    '*******************************************CARGAR LA FORMA*************************************************************
    Private Sub BalanceSituacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim coneccion As New DaxLib.DaxLibBases
        Dim i As Integer
        SYSEMP = New AdcDax.DaxSofSys
        EMP = SYSEMP.EmpresaAct
        coneccion.TipoBase = "10"
        conectar.ConnectionString = coneccion.StrAdcom
        txtDelAño.Text = Now.Year
        llenarCombos("Nivel", "select 'Nivel '+ cast(Cta_Nivel as varchar(5)) as Nivel_nom, Cta_Nivel from AdcCta where Cta_Nivel >=3 and Cta_Nivel <= 5 group by Cta_Nivel")
        llenarCombos("Moneda", "select Abreviación, Descripcion from Syscod where TipoReferencia='Monedas' and descripcion <> '' and Abreviación <> '#' order by Descripcion")
        txtAlMes.Items.Clear()
        txtDelMes.Items.Clear()
        For i = 1 To 12
            txtAlMes.Items.Add(MonthName(i))
            txtDelMes.Items.Add(MonthName(i))
        Next
        txtDelMes.SelectedIndex = 0
        txtAlMes.SelectedIndex = Now.Month - 1
        cboExpresar.Text = "Ninguno"
        cboTipo.Text = "Saldo"
        cboNivel.SelectedItem = 2
        BalanceImprimir = 1
    End Sub
    'METODO PARA LLENAR LOS COMBOS MONEDA Y NIVELES
    Private Sub llenarCombos(ByVal nombre As String, ByVal ssql As String)
        If nombre = "Moneda" Then
            Dim conectar As New SqlConnection()
            Dim condax As New DaxLib.DaxLibBases
            condax.TipoBase = "10"
            conectar.ConnectionString = condax.StrDaxsys
        End If
        Dim bnd As New BindingSource
        Dim datS As New DataSet
        Dim adt As New SqlDataAdapter(ssql, conectar)
        conectar.Open()
        adt.Fill(datS, "Datos")
        bnd.DataSource = datS
        bnd.DataMember = "Datos"
        Select Case nombre
            Case "Moneda"
                cboMoneda.DataSource = bnd
                cboMoneda.ValueMember = "Abreviación"
                cboMoneda.DisplayMember = "Descripcion"
            Case "Nivel"
                cboNivel.DataSource = bnd
                cboNivel.DisplayMember = "Nivel_nom"
                cboNivel.ValueMember = "Cta_Nivel"
        End Select
        conectar.Close()
    End Sub


    Private Sub btnImprNota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprNota.Click
        Dim notas As New frmOpcionesImprNotas()
        notas.ShowDialog()
    End Sub

    Private Sub btnBalance_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnBalance.ShowDropDown()
    End Sub

    Private Sub VariaciónPatrimonialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim prog As New VariaciondePatrimonio.VariacionPatrimonio
        Dim ch As String = ""
        If chkExcluirNifs.Checked Then ch = "Si" Else ch = "No"
        prog.inicio("EMP.nombre", "Variacion patrimonial al " & Year(fecha), Year(fechaAnt), Year(fecha1), cboNivel.SelectedValue.ToString, ch)
    End Sub

    Private Sub chkExcluirNifs_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ReportViewer1.Clear()
    End Sub

    Private Sub cboNivel_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ban = 1 Then
            nivel = cboNivel.SelectedValue.ToString
            ReportViewer1.Clear()
        End If
    End Sub


    Private Sub btnVerNotas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nota As New frmNotas
        If txtCodNota.Text = "" Then MsgBox("Ingrese el numero de la nota!!", MsgBoxStyle.Information) : txtCodNota.Focus() : Exit Sub
        nota.MostrarNotasBalance(txtCodNota.Text, 0, Now, Now)
    End Sub

    Private Sub txtCodNota_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If InStr(1, "0123456789,." & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txtDelAño_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDelAño.TextChanged
        ArreglarPeriodo()
    End Sub
    Private Sub btnOpciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpciones.Click
        If BotonOp = 0 Then
            btnOpciones.Checked = False
            BotonOp = 1
        Else
            btnOpciones.Checked = True
            BotonOp = 0
        End If
        SplitContainer1.Panel1Collapsed = Not btnOpciones.Checked
    End Sub

    Private Sub btnActualizar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        Actualizar()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub BalanceDeSituaciónToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BalanceDeSituaciónToolStripMenuItem.Click
        BalanceImprimir = 1
        opcionBal(BalanceDeSituaciónToolStripMenuItem)
    End Sub

    Private Sub BalanceDeResultadosToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BalanceDeResultadosToolStripMenuItem.Click
        BalanceImprimir = 2
        opcionBal(BalanceDeResultadosToolStripMenuItem)
    End Sub

    Private Sub VariaciónPatrimonialToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VariaciónPatrimonialToolStripMenuItem.Click
        BalanceImprimir = 3
        opcionBal(VariaciónPatrimonialToolStripMenuItem)
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged
        ArreglarOpciones()
    End Sub
    Private Sub ArreglarPeriodo()
        chkAño.Text = "Valores del año: " & txtDelAño.Text
        chkAñoAnt.Text = "Valores del año: " & Val(txtDelAño.Text) - 1
        ReportViewer1.Clear()
    End Sub
    Private Sub ArreglarOpciones()
        If cboTipo.SelectedIndex = 0 Then
            txtDelMes.SelectedIndex = 0
            txtDelMes.Enabled = False
        Else
            txtDelMes.Enabled = True
        End If
        ReportViewer1.Clear()
    End Sub

    Private Sub opcionBal(ByVal nombre As ToolStripMenuItem)
        btnBalance.Text = nombre.Text
        BalanceDeSituaciónToolStripMenuItem.Checked = False
        BalanceDeResultadosToolStripMenuItem.Checked = False
        VariaciónPatrimonialToolStripMenuItem.Checked = False
        nombre.Checked = True
        Actualizar()
    End Sub
    Private Sub Actualizar()
        ' evaluar las opciones seleccionadas y preparar la impresion
        ban = 1
        Me.UseWaitCursor = True
        Me.Cursor = Cursors.WaitCursor
        If Val(txtDelAño.Text) > 1900 And txtAlMes.SelectedIndex < 12 And txtDelMes.SelectedIndex <= txtAlMes.SelectedIndex Then
            Try
                ' Armar el período del año del balance
                fecha = New DateTime(txtDelAño.Text, txtDelMes.SelectedIndex + 1, 1)
                fecha1 = DateAdd(DateInterval.Month, 1, New DateTime(Val(txtDelAño.Text), txtAlMes.SelectedIndex + 1, 1))
                fecha1 = DateAdd(DateInterval.Day, -1, fecha1)

                'armar el período del año anterior
                fechaAnt = DateAdd(DateInterval.Year, -1, fecha)        ' periodo año anterior desde
                fechaAnt1 = DateAdd(DateInterval.Year, -1, fecha1)      ' periodo año anterior hasta

            Catch
                MsgBox("El rango de fechas Ingresados no es válida", MsgBoxStyle.Information)
                txtDelAño.Focus()
                txtDelAño.SelectAll()
                Exit Sub
            End Try
        Else
            MsgBox("Es necesario que ingrese el rango de fechas", MsgBoxStyle.Information)
            txtDelAño.Focus()
            txtDelAño.SelectAll()
            Exit Sub
        End If
        nivel = cboNivel.SelectedValue.ToString
        If cboExpresar.Text = "Ninguno" Then
            exp = 1
            expresadoEn = "(Expresado en " & cboMoneda.Text & ")"
        ElseIf cboExpresar.Text = "Cientos" Then
            exp = 100
            expresadoEn = "(Expresado en Cientos de " & cboMoneda.Text & ")"
        ElseIf cboExpresar.Text = "Miles" Then
            exp = 1000
            expresadoEn = "(Expresado en Miles de " & cboMoneda.Text & ")"
        Else
            exp = 1000000
            expresadoEn = "(Expresado en Millones de " & cboMoneda.Text & ")"
        End If
        meses = ""
        'For i = 1 To 12
        '    If i >= txtDelMes.Text And i <= txtAlMes.Text Then
        '        meses = meses & "1"
        '    Else
        '        meses = meses & "0"
        '    End If
        'Next
        Datosreporte()
        Me.UseWaitCursor = False
        Me.Cursor = Cursors.Default
    End Sub
#Region "Reporte"
    Private Sub Datosreporte()
        Dim ssql = "", tit As String = ""
        Dim mes1 As String
        Dim colum(10) As Boolean
        nombreMes = UCase(MonthName(Month(fecha)))
        mes1 = UCase(MonthName(Month(fecha1)))
        PonerResultado = False
        If BalanceImprimir = 1 Then
            If cboTipo.Text = "Saldo" Then
                ssql = "exec daxctbsal " & nivel & ",'" & fecha1 & "'," & IIf(chkExcluirNifs.Checked, 1, 0) & ",1"
                tit = "BALANCE DE SITUACIÓN CONSOLIDADO AL " & Format(fecha1, "dd/MMM/yyyy")
            Else
                ssql = "exec daxctbmov " & nivel & ",'" & fecha1 & "','" & fecha & "'," & IIf(chkExcluirNifs.Checked, 1, 0) & ",1,'" & fechaAnt1 & "','" & fechaAnt & "'"
                tit = "BALANCE DE SITUACIÓN (MOVIMIENTOS) DEL MES DE " & UCase(nombreMes) & " A " & UCase(mes1) & " DEL " & txtDelAño.Text
            End If
        ElseIf BalanceImprimir = 2 Then
            If cboTipo.Text = "Saldo" Then
                ssql = "exec daxctbsal " & nivel & ",'" & fecha1 & "'," & IIf(chkExcluirNifs.Checked, 1, 0) & ",2"
                tit = "BALANCE DE RESULTADOS INTEGRAL AL " & Format(fecha, "dd/MMM/yyyy")
                PonerResultado = True
            Else
                ssql = "exec daxctbmov " & nivel & ",'" & fecha1 & "','" & fecha & "'," & IIf(chkExcluirNifs.Checked, 1, 0) & ",2,'" & fechaAnt1 & "','" & fechaAnt & "'"
                tit = "BALANCE DE RESULTADOS (MOVIMIENTOS) DEL MES DE " & UCase(mes1) & " A " & UCase(nombreMes) & " DEL " & txtDelAño.Text
            End If
        End If
        colum(1) = chkCodigo.Checked
        colum(2) = chkNombre.Checked
        colum(3) = chkAño.Checked
        colum(4) = chkAñoAnt.Checked
        colum(5) = chkDiferencia.Checked
        colum(6) = chkDiferencia.Checked
        If ssql > "" Then reporte(ssql, tit, fecha, colum, exp, "")
    End Sub
    Private Sub reporte(ByVal cadena As String, ByVal titul As String, ByVal fecha As String, ByVal col() As Boolean, ByVal exp As Integer, ByVal expresaren As String)
        Dim rds As New ReportDataSource()
        If report = 1 Then
            Dim titulo1 As New ReportParameter("Titulo", titul                                               )
            Dim empresa1 As New ReportParameter("Empresa", EMP.nombre)
            Dim fecha1 As New ReportParameter("Fecha", fecha)
            Dim años As New ReportParameter("Año", Year(fecha) - 1)
            Dim años1 As New ReportParameter("Año1", Year(fecha))
            Dim ColReferencia As New ReportParameter("ColReferencia", col(0))
            Dim ColCodigo As New ReportParameter("ColCodigo", col(1))
            Dim ColNota As New ReportParameter("ColNota", col(2))
            Dim ColAño As New ReportParameter("ColAño", col(3))
            Dim ColAño1 As New ReportParameter("ColAño1", col(4))
            Dim ColDiferencia As New ReportParameter("ColDiferencia", col(5))
            Dim ColPorcentaje As New ReportParameter("ColPorcentaje", col(6))
            Dim expresar As New ReportParameter("expresar", exp)
            Dim ExpresadoEn As New ReportParameter("ExpresadoEn", expresaren)
            Dim ImprimirResultado As New ReportParameter("ImprimirResultado", PonerResultado)
            rds.Name = "DataSet1"
            rds.Value = CalcularDataSet(cadena).Tables(0)
            ReportViewer1.Visible = True
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(rds)
            ReportViewer1.LocalReport.ReportPath = EMP.PatAppl & "binNET\REP\ReporteBalanceSit.rdlc"
            ReportViewer1.LocalReport.SetParameters(titulo1)
            ReportViewer1.LocalReport.SetParameters(empresa1)
            ReportViewer1.LocalReport.SetParameters(fecha1)
            ReportViewer1.LocalReport.SetParameters(años)
            ReportViewer1.LocalReport.SetParameters(años1)
            ReportViewer1.LocalReport.SetParameters(ColReferencia)
            ReportViewer1.LocalReport.SetParameters(ColCodigo)
            ReportViewer1.LocalReport.SetParameters(ColNota)
            ReportViewer1.LocalReport.SetParameters(ColAño)
            ReportViewer1.LocalReport.SetParameters(ColAño1)
            ReportViewer1.LocalReport.SetParameters(ColDiferencia)
            ReportViewer1.LocalReport.SetParameters(ColPorcentaje)
            ReportViewer1.LocalReport.SetParameters(expresar)
            ReportViewer1.LocalReport.SetParameters(ExpresadoEn)
            ReportViewer1.LocalReport.SetParameters(ImprimirResultado)
        ElseIf report = 2 Then
            rds.Name = "DataSet1"
            rds.Value = CalcularDataSet(cadena).Tables(0)
            ReportViewer1.Visible = True
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(rds)
            ReportViewer1.LocalReport.ReportPath = EMP.PatAppl & "binNet\REP\ReporteNotas.rdlc"
        End If
        Me.ReportViewer1.RefreshReport()
    End Sub
    Public Function CalcularDataSet(ByVal cadena As String) As DataSet
        Dim ssql As String = cadena
        Dim sqlAdap As New SqlDataAdapter(ssql, conectar)
        conectar.Open()
        Dim datS As New DataSet()
        If cadena = "" Then Return datS : Exit Function
        sqlAdap.Fill(datS, "Inventario")
        conectar.Close()
        Return datS
    End Function
#End Region

    Private Sub chkCodigo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCodigo.CheckedChanged
        ReportViewer1.Clear()
    End Sub

    Private Sub chkNombre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNombre.CheckedChanged
        ReportViewer1.Clear()
    End Sub

    Private Sub chkAño_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAño.CheckedChanged
        ReportViewer1.Clear()
    End Sub

    Private Sub chkAñoAnt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAñoAnt.CheckedChanged
        ReportViewer1.Clear()
    End Sub

    Private Sub chkDiferencia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDiferencia.CheckedChanged
        ReportViewer1.Clear()
    End Sub

    Private Sub chkExcluirNifs_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExcluirNifs.CheckedChanged
        ReportViewer1.Clear()
    End Sub

    Private Sub btnBalance_ButtonClick_1(sender As System.Object, e As System.EventArgs) Handles btnBalance.ButtonClick

    End Sub
End Class
