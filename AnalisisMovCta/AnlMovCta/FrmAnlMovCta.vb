Imports System.Data
Imports System.Data.SqlClient
Imports DaxCbos 
Public Class FrmAnlMovCta
    Dim cb As New DaxCbos.DaxCombobx
    Dim carga As Boolean = False
    Dim nivel As String = ""
    Dim SoloCtaMov As Integer = 0
    Dim detCtaAux As Integer = 0
    Dim ctaIni As String = ""
    Dim ctaFin As String = ""
    Dim clas As String = ""
    Dim tipoClas As String = ""
    Dim registro As String = "M"
    Dim botonOP As Integer = 0
    Dim posRow As Long
    Dim posCol As Long
    Dim dat As New DataTable()
    ' M --> Movimientos
    ' D --> Debitos
    ' C --> Creditos

#Region "Datos Iniciales"
    Private Sub FrmAnlMovCta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Libdat As New daaxLib.DaxLibBases
        Libdat.TipoBase = "10"
        conectarBDD()
        carga = True
        cb.DaxCombosClasf(Libdat.StrAdcom, cboClas)
        cboNivel.SelectedItem = "5"
        carga = False
        Libdat = Nothing
        añoanalisis.Text = CStr(Year(Now))
    End Sub
    Private Sub cboClas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboClas.SelectedIndexChanged
        borrarmalla()
        cboClasDet.DataSource = Nothing
        If carga = True Then Exit Sub
        Dim Libdat As New daaxLib.DaxLibBases
        Libdat.TipoBase = "10"
        If CStr(cboClas.SelectedValue) <> "0" Then cb.DaxCombosReferencia(CStr(cboClas.SelectedValue), Libdat.StrDaxsys, cboClasDet)
    End Sub
    Private Sub btnCtaIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCtaIni.Click
        borrarmalla()
        BuscaCta(txtctaIni, lblctaIni)
    End Sub
    Private Sub btnCtaFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCtaFin.Click
        borrarmalla()
        BuscaCta(txtCtaFin, lblCtaFin)
    End Sub
    Private Sub btnOpciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpciones.Click
        If botonOP = 0 Then
            btnOpciones.Checked = False
            botonOP = 1
        Else
            btnOpciones.Checked = True
            botonOP = 0
        End If
        SplitContainer1.Panel1Collapsed = Not btnOpciones.Checked
    End Sub
    Private Sub BuscaCta(ByVal txt As TextBox, ByVal lbl As Label)
        Dim nombre = "", cod As String = ""
        Dim cta As New MantCtb.BuscaCta
        cod = cta.BuscaCtaCtb(nombre, "")
        txt.Text = cod
        lbl.Text = nombre
        'Dim cmd As New SqlCommand("select cta_nombre from adccta where cta_codigo='" & txt.Text & "'", conectar)
        'Dim dat As SqlDataReader = Nothing
        'cerrarConeccion()
        'conectar.Open()
        'dat = cmd.ExecuteReader
        'If dat.Read Then
        '    If Not IsDBNull(dat(0)) Then lbl.Text = CStr(dat(0))
        'End If
    End Sub
    Private Sub chkAuxiliares_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAuxiliares.CheckedChanged
        borrarmalla()
        If chkAuxiliares.Checked = True Then
            txtCtaFin.Text = "" : lblCtaFin.Text = ""
            txtCtaFin.Enabled = False : lblCtaFin.Enabled = False
            btnCtaFin.Enabled = False
        Else
            txtCtaFin.Enabled = True : lblCtaFin.Enabled = True
            btnCtaFin.Enabled = True
        End If
    End Sub
#End Region

#Region "Cambios"
    Private Sub cboNivel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNivel.SelectedIndexChanged

        borrarmalla()
    End Sub

    Private Sub chkCtaMov_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCtaMov.CheckedChanged
        borrarmalla()
    End Sub

    Private Sub txtctaIni_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtctaIni.TextChanged
        borrarmalla()
    End Sub

    Private Sub txtCtaFin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCtaFin.TextChanged
        borrarmalla()
    End Sub

    Private Sub cboClasDet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClasDet.SelectedIndexChanged
        borrarmalla()
    End Sub

    Private Sub optDebitos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optDebitos.CheckedChanged
        borrarmalla()
        registro = "D"
    End Sub

    Private Sub optCreditos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCreditos.CheckedChanged
        borrarmalla()
        registro = "C"
    End Sub

    Private Sub optMovimientos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMovimientos.CheckedChanged
        borrarmalla()
        registro = "M"
    End Sub
#End Region

#Region "Actualizar"
    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        CargarMalla()
    End Sub
    Private Sub LeerOp()
        On Error Resume Next
        nivel = cboNivel.Text
        If nivel = Nothing Then nivel = CStr(4) : cboNivel.Text = CStr(4)
        If CDbl(nivel) = 0 Then nivel = CStr(4) : cboNivel.Text = CStr(4)

        If chkCtaMov.Checked = True Then SoloCtaMov = 1 Else SoloCtaMov = 0
        If chkAuxiliares.Checked = True Then detCtaAux = 1 Else detCtaAux = 0
        ctaIni = txtctaIni.Text
        ctaFin = txtCtaFin.Text
        If ctaIni <> "" And ctaFin = "" Then ctaFin = ctaIni
        clas = cboClas.SelectedValue.ToString
        If clas <> "0" Then tipoClas = cboClasDet.SelectedValue.ToString
    End Sub
    Private Sub CargarMalla()
        On Error Resume Next
        Dim cont As Integer = 0
        dat = New DataTable
        LeerOp()
        Dim ssql As String = "exec Adc_AnlCta " & nivel & "," & SoloCtaMov & "," & detCtaAux & ",'" & ctaIni & "','" & ctaFin & "','" & clas & "','" & tipoClas & "','" & registro & "'," & añoanalisis.Text
        Dim cmd As New SqlClient.SqlDataAdapter(ssql, conectar)
        If conectar.State = ConnectionState.Closed Then conectar.Open()
        cmd.Fill(dat)
        dat.Rows.Add()
        dat.Rows.Add()
        Dim FILA As Integer = dat.Rows.Count - 1
        Totales(dat)
        With malla
            .DataSource = dat
            .Columns(14).DefaultCellStyle.BackColor = Color.AliceBlue
            .Rows(FILA).Cells(1).Value = "TOTALES"
            .Rows(FILA).DefaultCellStyle.BackColor = Color.AliceBlue
            .Columns("Código").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("Nombre_Cuenta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        End With
        'While dat.Read
        '    With malla
        '        .Rows.Add()
        '        .Rows(cont).Cells(0).Value = dat("cta_codigo")
        '        .Rows(cont).Cells(1).Value = dat("dia_ctaNombre")
        '        .Rows(cont).Cells(2).Value = dat("Enero")
        '        .Rows(cont).Cells(3).Value = dat("Febrero")
        '        .Rows(cont).Cells(4).Value = dat("Marzo")
        '        .Rows(cont).Cells(5).Value = dat("Abril")
        '        .Rows(cont).Cells(6).Value = dat("Mayo")
        '        .Rows(cont).Cells(7).Value = dat("Junio")
        '        .Rows(cont).Cells(8).Value = dat("Julio")
        '        .Rows(cont).Cells(9).Value = dat("Agosto")
        '        .Rows(cont).Cells(10).Value = dat("Septiembre")
        '        .Rows(cont).Cells(11).Value = dat("Octubre")
        '        .Rows(cont).Cells(12).Value = dat("Noviembre")
        '        .Rows(cont).Cells(13).Value = dat("Diciembre")
        '        cont += 1
        '    End With
        'End While
        conectar.Close()
    End Sub
    Private Sub Totales(ByRef DAT As DataTable)
        Dim tot As Double = 0.0
        Dim tot1 As Double = 0.0
        Dim fila As Integer = DAT.Rows.Count - 1
        With DAT
            '.Rows.Add(1)
            '    fila = .RowCount - 1
            'For l = 0 To .Rows.Count - 2
            '    tot1 = 0
            '    For k = 2 To 13
            '        tot1 += .Rows(l)(k).Value
            '    Next
            '    .Rows(l)(14).Value = tot1
            'Next
            For i = 2 To 14
                tot = 0
                For j = 0 To .Rows.Count - 2
                    tot += CDbl(.Rows(j)(i).ToString & "0")
                Next
                .Rows(fila)(i) = tot
            Next
        End With
    End Sub
#End Region

#Region "Detalle"

#End Region

#Region "Enviar"

#End Region

#Region "Salir"
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Dispose()
    End Sub
#End Region

#Region "Imprimir"
    Private Sub btnEnviar_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.ButtonClick
        btnEnviar.ShowDropDown()
    End Sub
    Private Sub ImprimirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirToolStripMenuItem.Click
        Dim imp As New DataGridViewPrinterApplication1.frmMain
        Dim tit2 As String = ""
        imp.imprimir(malla, "Análisis de Movimientos de Cuentas", tit2, SYSEMP.EmpresaAct.nombre)
    End Sub

    Private Sub WordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WordToolStripMenuItem.Click
        Dim exp As New ExportarGrid.Form1
        exp.Exportar(malla, "W", SYSEMP.EmpresaAct.nombre, "Análisis de Movimientos de Cuentas")
    End Sub

    Private Sub ExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelToolStripMenuItem.Click
        Dim exp As New ExportarGrid.Form1
        exp.Exportar(malla, "E", SYSEMP.EmpresaAct.nombre, "Análisis de Movimientos de Cuentas")
    End Sub

    Private Sub PDFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PDFToolStripMenuItem.Click
        Dim exp As New ExportarGrid.Form1
        exp.Exportar(malla, "P", SYSEMP.EmpresaAct.nombre, "Análisis de Movimientos de Cuentas")
    End Sub
#End Region

    Private Sub malla_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles malla.CellEnter
        posRow = e.RowIndex
        posCol = e.ColumnIndex
    End Sub

    Private Sub btnDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetalle.Click
        If malla.RowCount < 1 Then Exit Sub
        Dim PROG As New MovCta.MvtoCtas
        Dim Mesini As Int32 = CInt(posCol - 1)
        Dim MesFin As Int32 = 1
        If posCol < 2 Then Mesini = 1
        If posCol = 13 Then Mesini = 12
        If posCol = 14 Then Mesini = 1 : MesFin = 12

        Dim fecha1 As New Date(CInt(añoanalisis.Text), Mesini, 1)
        Dim fecha2 As Date = DateAdd(DateInterval.Month, MesFin, fecha1)
        fecha2 = DateAdd(DateInterval.Day, -1, fecha2)
        PROG.MvCtas(CStr(malla.Rows(CInt(posRow)).Cells(0).Value), fecha1, fecha2, "")
        PROG = Nothing

    End Sub
    Private Sub borrarMalla()
        malla.DataSource = Nothing
        dat = New DataTable
    End Sub
End Class
