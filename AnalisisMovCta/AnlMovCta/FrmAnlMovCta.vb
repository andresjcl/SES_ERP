Imports System.Data
Imports System.Data.SqlClient
Imports DattCom
Imports DaxCombobx

Public Class FrmAnlMovCta
    Private cb As New CargCmbBox()
    Private carga As Boolean = False
    Private nivel As String = ""
    Private SoloCtaMov As Integer = 0
    Private detCtaAux As Integer = 0
    Private ctaIni As String = ""
    Private ctaFin As String = ""
    Private clas As String = ""
    Private tipoClas As String = ""
    Private registro As String = "M"
    Private botonOP As Integer = 0
    Private posRow As Long
    Private posCol As Long
    Private dat As New DataTable()
    ' M --> Movimientos
    ' D --> Debitos
    ' C --> Creditos

#Region "Datos Iniciales"
    Private Sub FrmAnlMovCta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            conectarBDD()
            carga = True
            cb.DaxCombosClasf(datosEmpresa.strConxAdcom, cboClas)
            cboNivel.SelectedItem = "5"
            carga = False
            añoanalisis.Text = CStr(Year(Now))
        Catch ex As Exception
            MessageBox.Show("Error al cargar el formulario: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboClas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboClas.SelectedIndexChanged
        Try
            borrarMalla()
            cboClasDet.DataSource = Nothing
            If carga = True Then Exit Sub
            If cboClas.SelectedValue IsNot Nothing AndAlso CStr(cboClas.SelectedValue) <> "0" Then
                cb.DaxCombosReferencia(CStr(cboClas.SelectedValue), datosEmpresa.strConIniSis, cboClasDet)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al cargar clasificadores: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCtaIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCtaIni.Click
        borrarMalla()
        BuscaCta(txtctaIni, lblctaIni)
    End Sub

    Private Sub btnCtaFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCtaFin.Click
        borrarMalla()
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

    Private Shared Sub BuscaCta(ByVal txt As TextBox, ByVal lbl As Label)
        Dim nombre = "", cod As String = ""
        Dim cta As New CtaMtn.BuscaCta()
        cod = cta.BuscaCtaCtb(nombre, "")
        txt.Text = cod
        lbl.Text = nombre
    End Sub

    Private Sub chkAuxiliares_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAuxiliares.CheckedChanged
        borrarMalla()
        If chkAuxiliares.Checked = True Then
            txtCtaFin.Text = ""
            lblCtaFin.Text = ""
            txtCtaFin.Enabled = False
            lblCtaFin.Enabled = False
            btnCtaFin.Enabled = False
        Else
            txtCtaFin.Enabled = True
            lblCtaFin.Enabled = True
            btnCtaFin.Enabled = True
        End If
    End Sub
#End Region

#Region "Cambios"
    Private Sub cboNivel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNivel.SelectedIndexChanged
        borrarMalla()
    End Sub

    Private Sub chkCtaMov_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCtaMov.CheckedChanged
        borrarMalla()
    End Sub

    Private Sub txtctaIni_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtctaIni.TextChanged
        borrarMalla()
    End Sub

    Private Sub txtCtaFin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCtaFin.TextChanged
        borrarMalla()
    End Sub

    Private Sub cboClasDet_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClasDet.SelectedIndexChanged
        borrarMalla()
    End Sub

    Private Sub optDebitos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optDebitos.CheckedChanged
        borrarMalla()
        registro = "D"
    End Sub

    Private Sub optCreditos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optCreditos.CheckedChanged
        borrarMalla()
        registro = "C"
    End Sub

    Private Sub optMovimientos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMovimientos.CheckedChanged
        borrarMalla()
        registro = "M"
    End Sub
#End Region

#Region "Actualizar"
    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        CargarMalla()
    End Sub

    Private Sub LeerOp()
        Try
            nivel = cboNivel.Text
            If String.IsNullOrEmpty(nivel) Then
                nivel = "4"
                cboNivel.Text = "4"
            End If
            If CDbl(nivel) = 0 Then
                nivel = "4"
                cboNivel.Text = "4"
            End If

            SoloCtaMov = If(chkCtaMov.Checked, 1, 0)
            detCtaAux = If(chkAuxiliares.Checked, 1, 0)
            ctaIni = txtctaIni.Text
            ctaFin = txtCtaFin.Text
            If ctaIni <> "" And ctaFin = "" Then ctaFin = ctaIni

            If cboClas.SelectedValue IsNot Nothing Then
                clas = cboClas.SelectedValue.ToString()
                If clas <> "0" And cboClasDet.SelectedValue IsNot Nothing Then
                    tipoClas = cboClasDet.SelectedValue.ToString()
                Else
                    tipoClas = ""
                End If
            Else
                clas = ""
                tipoClas = ""
            End If
        Catch ex As Exception
            MessageBox.Show("Error al leer opciones: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargarMalla()
        Try
            dat = New DataTable()
            LeerOp()

            ' Usar parámetros para evitar inyección SQL
            Using conn As New SqlConnection(datosEmpresa.strConxAdcom)
                Using cmd As New SqlCommand("Adc_AnlCta", conn)
                    cmd.CommandType = CommandType.StoredProcedure

                    ' Agregar parámetros
                    cmd.Parameters.AddWithValue("@nivel", nivel)
                    cmd.Parameters.AddWithValue("@SoloCtaMov", SoloCtaMov)
                    cmd.Parameters.AddWithValue("@detCtaAux", detCtaAux)
                    cmd.Parameters.AddWithValue("@ctaIni", If(String.IsNullOrEmpty(ctaIni), "", ctaIni))
                    cmd.Parameters.AddWithValue("@ctaFin", If(String.IsNullOrEmpty(ctaFin), "", ctaFin))
                    cmd.Parameters.AddWithValue("@clas", If(String.IsNullOrEmpty(clas), "", clas))
                    cmd.Parameters.AddWithValue("@tipoClas", If(String.IsNullOrEmpty(tipoClas), "", tipoClas))
                    cmd.Parameters.AddWithValue("@registro", registro)
                    cmd.Parameters.AddWithValue("@anio", añoanalisis.Text)

                    Using da As New SqlDataAdapter(cmd)
                        If conn.State = ConnectionState.Closed Then conn.Open()
                        da.Fill(dat)
                    End Using
                End Using
            End Using

            ' Agregar filas de totales
            dat.Rows.Add()
            dat.Rows.Add()
            Dim FILA As Integer = dat.Rows.Count - 1
            Totales(dat)

            ' Asignar datos al DataGridView
            With malla
                .DataSource = dat
                .Columns(14).DefaultCellStyle.BackColor = Color.AliceBlue
                .Rows(FILA).Cells(1).Value = "TOTALES"
                .Rows(FILA).DefaultCellStyle.BackColor = Color.AliceBlue
                .Columns("Código").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Columns("Nombre_Cuenta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

        Catch ex As Exception
            MessageBox.Show("Error al cargar datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Totales(ByRef DAT As DataTable)
        Try
            Dim tot As Double = 0.0
            Dim fila As Integer = DAT.Rows.Count - 1

            With DAT
                For i As Integer = 2 To 14
                    tot = 0
                    For j As Integer = 0 To .Rows.Count - 2
                        If Not IsDBNull(.Rows(j)(i)) AndAlso .Rows(j)(i) IsNot Nothing Then
                            tot += CDbl(.Rows(j)(i).ToString())
                        End If
                    Next
                    .Rows(fila)(i) = tot
                Next
            End With
        Catch ex As Exception
            MessageBox.Show("Error al calcular totales: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "Detalle"
    Private Sub btnDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetalle.Click
        Try
            If malla.RowCount < 1 Then Exit Sub

            Dim PROG As New MovCtases.MvtoCtas()
            Dim Mesini As Int32 = CInt(posCol - 1)
            Dim MesFin As Int32 = 1

            If posCol < 2 Then Mesini = 1
            If posCol = 13 Then Mesini = 12
            If posCol = 14 Then
                Mesini = 1
                MesFin = 12
            End If

            Dim fecha1 As New Date(CInt(añoanalisis.Text), Mesini, 1)
            Dim fecha2 As Date = DateAdd(DateInterval.Month, MesFin, fecha1)
            fecha2 = DateAdd(DateInterval.Day, -1, fecha2)

            PROG.MvCtas(CStr(malla.Rows(CInt(posRow)).Cells(0).Value), fecha1, fecha2, "")
            PROG = Nothing
        Catch ex As Exception
            MessageBox.Show("Error al mostrar detalle: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "Enviar"
    Private Sub btnEnviar_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviar.ButtonClick
        btnEnviar.ShowDropDown()
    End Sub
#End Region

#Region "Salir"
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Try
            cerrarConeccion()
            Me.Dispose()
        Catch ex As Exception
            ' Ignorar errores al cerrar
        End Try
    End Sub
#End Region

#Region "Imprimir"
    Private Sub ImprimirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirToolStripMenuItem.Click
        Try
            Using imp As New DataGridViewPrinterApplication1.frmMain()
                Dim tit2 As String = ""
                imp.imprimir(malla, "Análisis de Movimientos de Cuentas", tit2, datosEmpresa.Emp_Nombre)
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al imprimir: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub WordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WordToolStripMenuItem.Click
        Try
            Using exp As New mallExp.Form1()
                exp.Exportar(malla, "W", datosEmpresa.Emp_Nombre, "Análisis de Movimientos de Cuentas")
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al exportar a Word: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelToolStripMenuItem.Click
        Try
            Using exp As New mallExp.Form1()
                exp.Exportar(malla, "E", datosEmpresa.Emp_Nombre, "Análisis de Movimientos de Cuentas")
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al exportar a Excel: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PDFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PDFToolStripMenuItem.Click
        Try
            Using exp As New mallExp.Form1()
                exp.Exportar(malla, "P", datosEmpresa.Emp_Nombre, "Análisis de Movimientos de Cuentas")
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al exportar a PDF: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "Eventos del DataGridView"
    Private Sub malla_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles malla.CellEnter
        If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
            posRow = e.RowIndex
            posCol = e.ColumnIndex
        End If
    End Sub
#End Region

#Region "Funciones Auxiliares"
    Private Sub borrarMalla()
        Try
            malla.DataSource = Nothing
            dat = New DataTable()
        Catch ex As Exception
            ' Ignorar errores al limpiar
        End Try
    End Sub
#End Region

End Class