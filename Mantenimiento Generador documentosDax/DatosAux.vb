Imports System.Data
Imports System.Data.SqlClient

Public Class DatosAux
    Dim conectar As New SqlConnection()
    Dim accion As String = ""
    Dim codigo As String = ""
    Dim opGuardar As Boolean = False
    Dim cambios As Integer = 0
    Dim strConect As String = ""
    Dim opc As Integer = 0

#Region "Inicializar Datos"
    Private Sub ConectarBdd()
        Dim coneccion As New DaxLib.DaxLibBases
        coneccion.TipoBase = "10"
        conectar.ConnectionString = coneccion.StrAdcom
        strConect = coneccion.StrAdcom
    End Sub
    Private Sub limpiar(ByVal Obj As Object)
        Dim Control1 As System.Windows.Forms.Control
        Dim a As String
        For Each Control1 In Obj.Controls
            If Control1.Controls.Count > 0 Then limpiar(Control1)
            a = TypeName(Control1)
            If a = "TextBox" Then Control1.Text = ""
            If a = "ComboBox" Then Control1.Text = ""
            If a = "MaskedTextBox" Then Control1.Text = "  /  /"
        Next
    End Sub
    Private Sub bloquearDesbloquear(ByVal op As Boolean)
        btnNuevo.Enabled = op
        btnAbrir.Enabled = op
        btnSalir.Enabled = op
        btnGuardar.Enabled = Not op
        BtnEliminar.Enabled = Not op
        btnCancelar.Enabled = Not op
        GroupBox1.Enabled = Not op
    End Sub
    Private Sub DatosAuxiliares_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ConectarBdd()
        bloquearDesbloquear(True)
        If accion = "Abrir" Then abrir(codigo)
    End Sub
    Private Sub CargarUltimosAsig()
        Dim ssql As String = "select max(UltimoCamVar) as Alfanumerico ,max(UltimoCamFec) as Fecha,max(UltimoCamLog) as Logico ,max(UltimoCamNum) as Numerico from cmpsAux"
        Dim cmd As New SqlCommand(ssql, conectar)
        Dim dat As SqlDataReader = Nothing
        If conectar.State = ConnectionState.Open Then conectar.Close()
        conectar.Open()
        dat = cmd.ExecuteReader()
        If dat.Read Then
            If Not IsDBNull(dat(0)) Then txtUltVar.Text = dat(0)
            If Not IsDBNull(dat(1)) Then txtUltFec.Text = dat(1)
            If Not IsDBNull(dat(2)) Then txtUltLog.Text = dat(2)
            If Not IsDBNull(dat(3)) Then txtUltNum.Text = dat(3)
        End If
        conectar.Close()
    End Sub
#End Region

#Region "Nuevo"
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        nuevo()
    End Sub
    Private Sub nuevo()
        limpiar(Me)
        bloquearDesbloquear(False)
        CargarUltimosAsig()
        cambios = 0
        accion = "Guardar"
        opGuardar = False
    End Sub
    Private Sub cboTipoDato_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoDato.SelectedIndexChanged
        cambios += 1
        HabilitarCampos(cboTipoDato.Text)
        If cboTipoDato.Text <> "" Then ConsultaCampoAsig(cboTipoDato.Text)
    End Sub
    Private Sub HabilitarCampos(ByVal tipoDato As String)
        If tipoDato = "Alfanumérico" Then
            txtLongitud.Enabled = True
            txtDecimales.Enabled = False
        ElseIf tipoDato = "Numérico Entero" Then
            txtLongitud.Enabled = False
            txtDecimales.Enabled = False
        ElseIf tipoDato = "Numérico Decimal" Then
            txtLongitud.Enabled = True
            txtDecimales.Enabled = True
        ElseIf tipoDato = "DateTime" Then
            txtLongitud.Enabled = False
            txtDecimales.Enabled = False
        ElseIf tipoDato = "Boolean" Then
            txtLongitud.Enabled = False
            txtDecimales.Enabled = False
        End If
    End Sub
    'Este método busca los campos auxiliares que se encuenten vacios para asignar el nuevo campo
    Private Sub ConsultaCampoAsig(ByVal tipoCampo As String)
        'AdcDoc/Tra : AuxVar1-12 :opc1
        'AdcDoc/Tra : AuxFec1-3  :opc2
        'AdcDoc/Tra : AuxLog1-3  :opc3
        'AdcDoc/Tra : AuxNum1-12 :opc4
        Dim num As Integer = 0
        Dim Max As Integer = 0
        Dim campoDoc As String = ""
        Dim campoDia As String = ""
        Dim tabla As String = ""
        Dim ssql As String = ""
        Dim cmd As New SqlCommand()
        Dim dat As SqlDataReader = Nothing
        If tipoCampo = "Alfanumérico" Then
            campoDoc = "AuxVar" : num = Val(txtUltVar.Text) + 1 : Max = 12 : opc = 1
        ElseIf tipoCampo = "Numérico Entero" Or tipoCampo = "Numérico Decimal" Then
            campoDoc = "AuxNum" : num = Val(txtUltNum.Text) + 1 : Max = 12 : opc = 2
        ElseIf tipoCampo = "Datetime" Then
            campoDoc = "AuxFec" : num = Val(txtUltFec.Text) + 1 : Max = 5 : opc = 3
        ElseIf tipoCampo = "Boolean" Then
            campoDoc = "AuxLog" : num = Val(txtUltLog.Text) + 1 : Max = 5 : opc = 4
        End If
        If num > Max Then MsgBox("Todos los campos auxiliares tipo " & tipoCampo & " se encuentran ocupados", MsgBoxStyle.Information) Else txtCampoAsignado.Text = campoDoc & num
    End Sub
#End Region

#Region "Abrir"
    Private Sub btnAbrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrir.Click
        Dim busk As New Buscar.frmBuscar
        Dim cod As String = ""
        cod = busk.Buscar(strConect, "select Abreviación,Descripción from CmpsAux", "Abreviación", "Descripcion", "Caonsulta", "Campos Auxiliares")
        If cod <> "" Then abrir(cod) : accion = "Abrir"
        cambios = 0
    End Sub
    Private Sub abrir(ByVal cod As String)
        limpiar(Me)
        bloquearDesbloquear(False)
        CargarDatos(cod)
    End Sub
    Private Sub CargarDatos(ByVal cod As String)
        Dim ssql As String = "select * from CmpsAux where Abreviación='" & cod & "'"
        Dim cmd As New SqlCommand(ssql, conectar)
        Dim dat As SqlDataReader = Nothing
        If conectar.State = Data.ConnectionState.Open Then conectar.Close()
        conectar.Open()
        dat = cmd.ExecuteReader()
        If dat.Read Then
            If Not IsDBNull(dat(0)) Then txtAbreviación.Text = dat(0)
            If Not IsDBNull(dat(1)) Then txtDescripcion.Text = dat(1)
            If Not IsDBNull(dat(2)) Then cboTipoDato.SelectedItem = dat(2)
            If Not IsDBNull(dat(3)) Then txtLongitud.Text = dat(3)
            If Not IsDBNull(dat(4)) Then txtDecimales.Text = dat(4)
            If Not IsDBNull(dat(5)) Then
                If dat(5).ToString = "Directorio" Then
                    optDirectorio.Checked = True
                ElseIf dat(5).ToString = "Syscod" Then
                    optSyscod.Checked = True
                ElseIf dat(5).ToString = "Manual" Then
                    optManual.Checked = True
                ElseIf dat(5).ToString = "Articulos" Then
                    optArticulos.Checked = True
                ElseIf dat(5).ToString = "Servicios" Then
                    optServicios.Checked = True
                ElseIf dat(5).ToString = "Produccion" Then
                    optProduccion.Checked = True
                End If
            End If

            If Not IsDBNull(dat(6)) Then txtCampoAsignado.Text = dat(6)
            If Not IsDBNull(dat(7)) Then
                If dat(7).ToString = "CAB" Then cboClaseCampo.SelectedItem = "Añadir campo para encabezado" Else cboTipoDato.SelectedItem = "Añadir campo para Items"
            End If
        End If
    End Sub

#End Region

#Region "Guardar"
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Guardar()
        If opGuardar = True Then
            cancelar()
        End If
    End Sub
    Private Function VerificarInformación() As Boolean
        Dim bandera As Boolean = False
        If txtAbreviación.Text = "" Then
            MsgBox("Es necesario que ingrese la Abreviación", MsgBoxStyle.Information) : bandera = True : txtAbreviación.Focus()
        ElseIf txtDescripcion.Text = "" Then
            MsgBox("Es necesario que ingrese la Descripción", MsgBoxStyle.Information) : bandera = True : txtDescripcion.Focus()
        ElseIf cboTipoDato.Text = "" Then
            MsgBox("Es necesario que escoja el tipo de dato", MsgBoxStyle.Information) : bandera = True : cboTipoDato.Focus()
        ElseIf cboClaseCampo.Text = "" Then
            MsgBox("Es necesario que ingrese la ubicación del campo ", MsgBoxStyle.Information) : bandera = True : cboClaseCampo.Focus()
        ElseIf cboTipoDato.Text = "Alfanumérico" Or cboTipoDato.Text = "Numérico Decimal" Then
            If txtLongitud.Text = "" Then MsgBox("Es necesario que ingrese la longitud del campo ", MsgBoxStyle.Information) : bandera = True : txtLongitud.Focus()
        End If
        Return bandera
    End Function
    Private Sub Guardar()
        If VerificarInformación() = True Then Exit Sub
        Dim aux As New ClsDatAux()
        aux.Abreviación = txtAbreviación.Text
        aux.Descripción = txtDescripcion.Text
        aux.TipoDato = cboTipoDato.Text
        If txtLongitud.Text <> "" Then aux.Longitud = CLng(txtLongitud.Text)
        If txtDecimales.Text <> "" Then aux.Decimales = CLng(txtDecimales.Text)
        If optDirectorio.Checked Then
            aux.Origen = "Directorio"
        ElseIf optSyscod.Checked Then
            aux.Origen = "Syscod"
        ElseIf optManual.Checked Then
            aux.Origen = "Manual"
        ElseIf optProduccion.Checked Then
            aux.Origen = "Produccion"
        ElseIf optArticulos.Checked Then
            aux.Origen = "Articulos"
        ElseIf optServicios.Checked Then
            aux.Origen = "Servicios"
        End If
        aux.CampoAsignado = txtCampoAsignado.Text
        If cboClaseCampo.Text = "Añadir campo por Documento" Then aux.UbicaCampo = "CAB" Else aux.UbicaCampo = "DET"
        If opc = 1 Then
            aux.UltimoCamVar = Val(txtUltVar.Text) + 1
        ElseIf opc = 2 Then
            aux.UltimoCamNum = Val(txtUltNum.Text) + 1
        ElseIf opc = 3 Then
            aux.UltimoCamFec = Val(txtUltFec.Text) + 1
        ElseIf opc = 4 Then
            aux.UltimoCamLog = Val(txtUltLog.Text) + 1
        End If

        If accion = "Abrir" Then aux.Actualizar(txtAbreviación.Text) Else aux.Guardar()
        opGuardar = True
    End Sub
#End Region

#Region "Eliminar"
    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If txtAbreviación.Text = "" Then Exit Sub
        Dim confirmar As Integer = MsgBox("Esta seguro que quiere eliminar el Campo " & txtAbreviación.Text & "-" & txtDescripcion.Text & "?", MsgBoxStyle.YesNo)
        If confirmar = vbYes Then
            eliminar(txtAbreviación.Text)
            limpiar(Me)
            bloquearDesbloquear(True)
        End If
    End Sub
    Private Sub eliminar(ByVal cod As String)
        Dim aux As New ClsDatAux
        aux.Eliminar(cod)
    End Sub
#End Region

#Region "Cancelar/Salir"
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Dispose()
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If cambios > 0 Then
            If MsgBox("Desea guardar los cambios", MsgBoxStyle.YesNo) = vbYes Then
                Guardar()
                If opGuardar = True Then
                    cancelar()
                End If
            Else : cancelar()
            End If
        Else : cancelar()
        End If
    End Sub
    Private Sub cancelar()
        limpiar(Me)
        bloquearDesbloquear(True)
        cambios = 0
        opGuardar = False
        accion = ""
    End Sub
#End Region

#Region "Cambios"
    Private Sub txtAbreviación_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAbreviación.TextChanged
        cambios += 1
    End Sub

    Private Sub txtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged
        cambios += 1
    End Sub

    Private Sub txtLongitud_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLongitud.TextChanged
        cambios += 1
    End Sub

    Private Sub txtDecimales_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDecimales.TextChanged
        cambios += 1
    End Sub

    Private Sub optDirectorio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios += 1
    End Sub

    Private Sub optSyscod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios += 1
    End Sub

    Private Sub optManual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios += 1
    End Sub

    Private Sub txtCampoAsignado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cambios += 1
    End Sub
#End Region

    Public Sub CamposAux(ByVal cod As String)
        If cod <> "" Then accion = "Abrir" : codigo = cod Else accion = "Nuevo"
        Me.ShowDialog()
    End Sub

    Private Sub ClasSimple_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClasSimple.CheckedChanged
        If ClasSimple.Checked Then ClasContable.Checked = False
    End Sub

    Private Sub ClasContable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClasContable.CheckedChanged
        If ClasContable.Checked Then ClasSimple.Checked = False
    End Sub
End Class