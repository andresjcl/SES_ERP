
Public Class frmConfiguracion

    Private strConxAdcom As String
    Dim dbFelec As New ClassFelec.AdcFelec()
    Dim clvnum As New daxnumm.Class1

    Private Sub btnGenerados_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerados.Click
        ingresaPathComprobante(TextGenerados.Text)
    End Sub

    Private Sub btnFirmados_Click(sender As System.Object, e As System.EventArgs) Handles btnFirmados.Click
        ingresaPathComprobante(TextFirmados.Text)
    End Sub

    Private Function ingresaPathComprobante(ByRef texto As String) As String
        FolderBrowserDialog1.ShowNewFolderButton = True
        FolderBrowserDialog1.ShowDialog()
        texto = FolderBrowserDialog1.SelectedPath
        Return texto
    End Function

    Private Sub btnAutorizados_Click(sender As System.Object, e As System.EventArgs) Handles btnAutorizados.Click
        ingresaPathComprobante(TextAutorizados.Text)
    End Sub

    Private Sub btnNAutorizados_Click(sender As System.Object, e As System.EventArgs) Handles btnNAutorizados.Click
        ingresaPathComprobante(TextNoAutorizados.Text)
    End Sub

    Private Sub btnPathFirmaElectronica_Click(sender As System.Object, e As System.EventArgs) Handles btnPathFirmaElectronica.Click
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.Filter = "(*.p12)|*.p12"
        OpenFileDialog1.ShowDialog()
        TextPathFirmaElectronica.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        If MsgBox("Confirma salir del administrador de configuración ? ", CType(MsgBoxStyle.Question + MessageBoxButtons.YesNo, MsgBoxStyle), "Salir de la configuración") = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub Form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim daxlib As New DaxLib.DaxLibBases()
        daxlib.TipoBase = "10"
        strConxAdcom = daxlib.StrAdcom()
        dbFelec = New ClassFelec.AdcFelec(strConxAdcom)
        cargarDatosPantalla()
    End Sub
    Private Sub cargarDatosPantalla()
        Dim cod = New sysClass.Class1()
        dbFelec = ClassFelec.AdcFelec.Buscar("")
        If Not IsNothing(dbFelec) Then
            TextGenerados.Text = dbFelec.pathCpbGenerados
            TextFirmados.Text = dbFelec.pathCpbFirmados
            TextAutorizados.Text = dbFelec.pathCpbAutorizados
            TextNoAutorizados.Text = dbFelec.pathpbNoAutorizados
            TextPathFirmaElectronica.Text = dbFelec.pathFirmaElectronica
            chkProduccion.Checked = dbFelec.ambienteEnProduccion
            chkPruebas.Checked = Not dbFelec.ambienteEnProduccion
            TextClave.Text = clvnum.DeCodificar(dbFelec.claveFirma)
        End If
    End Sub

    Private Sub GuardarDatos()
        Dim cod = New sysClass.Class1()
        If IsNothing(dbFelec) Then dbFelec = New ClassFelec.AdcFelec
        dbFelec.pathCpbGenerados = cerrarPath(TextGenerados.Text)
        dbFelec.pathCpbFirmados = cerrarPath(TextFirmados.Text)
        dbFelec.pathCpbAutorizados = cerrarPath(TextAutorizados.Text)
        dbFelec.pathpbNoAutorizados = cerrarPath(TextNoAutorizados.Text)
        dbFelec.pathFirmaElectronica = TextPathFirmaElectronica.Text
        dbFelec.ambienteEnProduccion = chkProduccion.Checked
        dbFelec.claveFirma = clvnum.Codificar(TextClave.Text)
        dbFelec.Actualizar()
        cod = Nothing
    End Sub
    Private Function cerrarPath(path As String) As String
        If path.Substring(path.Length - 1, 1) <> "\" Then path += "\"
        Return path
    End Function

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        GuardarDatos()
        Me.Close()
    End Sub

    Private Sub Label6_Click(sender As Object, e As System.EventArgs) Handles Label6.Click

    End Sub
End Class