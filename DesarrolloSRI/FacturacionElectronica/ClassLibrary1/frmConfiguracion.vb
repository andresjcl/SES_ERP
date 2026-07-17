
Imports System.Windows.Forms

Public Class frmConfiguracion

    Dim dbFelec As New AdcFelec
    Dim clvnum As New Class1
    Dim StrConxDaxsys As String = ""
    Dim StrConxAdcom As String = ""
    Public Sub New(strConxsys As String, strConxAdc As String)
        InitializeComponent()
        StrConxDaxsys = strConxsys
        StrConxAdcom = strConxAdc
    End Sub
    Private Sub btnGenerados_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerados.Click, Button4.Click
        ingresaPathComprobante(TextGenerados.Text)
    End Sub

    Private Sub btnFirmados_Click(sender As System.Object, e As System.EventArgs) Handles btnFirmados.Click, Button3.Click
        ingresaPathComprobante(TextFirmados.Text)
    End Sub

    Private Function ingresaPathComprobante(ByRef texto As String) As String
        FolderBrowserDialog1.ShowNewFolderButton = True
        FolderBrowserDialog1.ShowDialog()
        texto = FolderBrowserDialog1.SelectedPath
        Return texto
    End Function

    Private Sub btnAutorizados_Click(sender As System.Object, e As System.EventArgs) Handles btnAutorizados.Click, Button2.Click
        ingresaPathComprobante(TextAutorizados.Text)
    End Sub

    Private Sub btnNAutorizados_Click(sender As System.Object, e As System.EventArgs) Handles btnNAutorizados.Click, Button1.Click
        ingresaPathComprobante(TextNoAutorizados.Text)
    End Sub

    Private Sub btnPathFirmaElectronica_Click(sender As System.Object, e As System.EventArgs) Handles btnPathFirmaElectronica.Click
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.Filter = "(*.p12)|*.p12"
        OpenFileDialog1.ShowDialog()
        TextPathFirmaElectronica.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        If MsgBox("Confirma salir del administrador de configuración ? ", CType(MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgBoxStyle), "Salir de la configuración") = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub Form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dbFelec = New AdcFelec(StrConxAdcom)
        cargarDatosPantalla()
    End Sub
    Private Sub cargarDatosPantalla()
        Dim cod = New Class1()
        dbFelec = AdcFelec.Buscar("")
        If Not IsNothing(dbFelec) Then
            TextGenerados.Text = dbFelec.pathCpbGenerados
            TextFirmados.Text = dbFelec.pathCpbFirmados
            TextAutorizados.Text = dbFelec.pathCpbAutorizados
            TextNoAutorizados.Text = dbFelec.pathpbNoAutorizados
            TextPathFirmaElectronica.Text = dbFelec.pathFirmaElectronica
            chkProduccion.Checked = dbFelec.ambienteEnProduccion
            chkPruebas.Checked = Not dbFelec.ambienteEnProduccion
            TextClave.Text = clvnum.DeCodificar(dbFelec.claveFirma)
            txtConsumidorFinal.Text = dbFelec.consumidorFinal
            txtCorreoPorDefecto.Text = dbFelec.correoDefecto
            'If dbFelec.utilizarCtaCorreo = "OT" Then chkMailOutlook.Checked = True
            'If dbFelec.utilizarCtaCorreo = "SV" Then chkMailServidor.Checked = True
            'If dbFelec.utilizarCtaCorreo = "QL" Then chkMailSmtp.Checked = True
        End If
    End Sub

    'Private Sub GuardarDatos()
    '    Dim cod = New Class1()
    '    If IsNothing(dbFelec) Then dbFelec = New AdcFelec
    '    dbFelec.pathCpbGenerados = cerrarPath(TextGenerados.Text)
    '    dbFelec.pathCpbFirmados = cerrarPath(TextFirmados.Text)
    '    dbFelec.pathCpbAutorizados = cerrarPath(TextAutorizados.Text)
    '    dbFelec.pathpbNoAutorizados = cerrarPath(TextNoAutorizados.Text)
    '    dbFelec.pathFirmaElectronica = TextPathFirmaElectronica.Text
    '    dbFelec.ambienteEnProduccion = chkProduccion.Checked
    '    dbFelec.claveFirma = clvnum.Codificar(TextClave.Text)
    '    dbFelec.consumidorFinal = txtConsumidorFinal.Text
    '    dbFelec.correoDefecto = txtCorreoPorDefecto.Text
    '    'If chkMailOutlook.Checked Then dbFelec.utilizarCtaCorreo = "OT"
    '    'If chkMailServidor.Checked Then dbFelec.utilizarCtaCorreo = "SV"
    '    'If chkMailSmtp.Checked Then dbFelec.utilizarCtaCorreo = "QL"
    '    dbFelec.Actualizar()
    '    cod = Nothing
    'End Sub


    Private Sub GuardarDatos()
        Try
            ' Validar que los campos obligatorios no estén vacíos
            If String.IsNullOrEmpty(TextGenerados.Text) Then
                MessageBox.Show("La ruta de Comprobantes Generados es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextGenerados.Focus()
                Exit Sub
            End If

            If String.IsNullOrEmpty(TextFirmados.Text) Then
                MessageBox.Show("La ruta de Comprobantes Firmados es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextFirmados.Focus()
                Exit Sub
            End If

            If String.IsNullOrEmpty(TextAutorizados.Text) Then
                MessageBox.Show("La ruta de Comprobantes Autorizados es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextAutorizados.Focus()
                Exit Sub
            End If

            If String.IsNullOrEmpty(TextNoAutorizados.Text) Then
                MessageBox.Show("La ruta de Comprobantes No Autorizados es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextNoAutorizados.Focus()
                Exit Sub
            End If

            If String.IsNullOrEmpty(TextPathFirmaElectronica.Text) Then
                MessageBox.Show("La ruta de la Firma Electrónica es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextPathFirmaElectronica.Focus()
                Exit Sub
            End If

            If String.IsNullOrEmpty(TextClave.Text) Then
                MessageBox.Show("La clave de la Firma Electrónica es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextClave.Focus()
                Exit Sub
            End If

            ' Inicializar dbFelec si es Nothing
            If IsNothing(dbFelec) Then
                dbFelec = New AdcFelec()
            End If

            ' Asignar valores con la función cerrarPath mejorada
            dbFelec.pathCpbGenerados = cerrarPath(TextGenerados.Text.Trim())
            dbFelec.pathCpbFirmados = cerrarPath(TextFirmados.Text.Trim())
            dbFelec.pathCpbAutorizados = cerrarPath(TextAutorizados.Text.Trim())
            dbFelec.pathpbNoAutorizados = cerrarPath(TextNoAutorizados.Text.Trim())
            dbFelec.pathFirmaElectronica = TextPathFirmaElectronica.Text.Trim()
            dbFelec.ambienteEnProduccion = chkProduccion.Checked
            dbFelec.claveFirma = clvnum.Codificar(TextClave.Text.Trim())

            ' Asignar valores opcionales
            If Not String.IsNullOrEmpty(txtConsumidorFinal.Text) Then
                dbFelec.consumidorFinal = txtConsumidorFinal.Text.Trim()
            End If

            If Not String.IsNullOrEmpty(txtCorreoPorDefecto.Text) Then
                dbFelec.correoDefecto = txtCorreoPorDefecto.Text.Trim()
            End If

            ' Configuración de correo (descomentar según necesidad)
            'If chkMailOutlook.Checked Then 
            '    dbFelec.utilizarCtaCorreo = "OT"
            'ElseIf chkMailServidor.Checked Then 
            '    dbFelec.utilizarCtaCorreo = "SV"
            'ElseIf chkMailSmtp.Checked Then 
            '    dbFelec.utilizarCtaCorreo = "QL"
            'End If

            ' Guardar en la base de datos
            dbFelec.Actualizar()

            ' Mensaje de éxito
            MessageBox.Show("Datos guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error al guardar los datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    'Private Function cerrarPath(path As String) As String
    '    If path.Substring(path.Length - 1, 1) <> "\" Then path += "\"
    '    Return path
    'End Function

    Private Function cerrarPath(path As String) As String
        If String.IsNullOrEmpty(path) Then Return ""
        ' Path.Combine agrega automáticamente la barra cuando es necesario
        Return System.IO.Path.Combine(path, "")
        ' O mejor aún, usa Path.Combine directamente donde construyas las rutas completas
    End Function

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        GuardarDatos()
        Me.Close()
    End Sub

    Private Sub btnConfiguracion_Click(sender As Object, e As EventArgs) Handles btnConfiguracion.Click
        Dim prog As New ClassDaxMail.frmRegistraDatosEmail(DattCom.datosEmpresa.strConxAdcom, DattCom.datosEmpresa.codEmpresa.ToString())
        prog.ShowDialog()
        prog.Dispose()
    End Sub
End Class