Option Explicit On
Option Strict On
Imports System.Data.SqlClient


Public Class frmSuc
    Dim EmpresaCod As Integer = 0
    Dim empresaNom As String = ""
    Dim cambios As Integer = 0
    Dim CodSucursal As String
    Dim accion As String = ""
    Dim fila As Integer = 0, columna As Integer = 0

#Region "DatosIniciales"

    Private Sub frmSuc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CodSucursal = CStr(ObtnrCodSuc(EmpresaCod))
        CargarDatos(EmpresaCod, CodSucursal)
        Bloquear(True)
        FormatoMallas()
    End Sub
    Private Sub FormatoMallas()
        With mallaBod
            .Columns(0).Width = 50
            .Columns(1).Width = 240
            .Columns(2).Width = 65
        End With
        With mallaPtoVta
            .Columns(0).Width = 40
            .Columns(1).Width = 200
            .Columns(2).Width = 65
            .Columns(3).Width = 65
            .Columns(4).Width = 65
        End With
    End Sub
    Private Sub btnSuc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSuc.Click
        CodSucursal = CStr(Busca("select suc_codigo, suc_nombre from Emp_Suc where Emp_Codigo = " & EmpresaCod, "suc_codigo", "suc_nombre", "SUCURSALES"))
        If CodSucursal <> "" Then
            txtSuc.Text = CodSucursal
            CargarDatos(EmpresaCod, CodSucursal)
        End If
    End Sub
    Private Sub btnIdCont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIdCont.Click
        txtIdCont.Text = CargaCta()
    End Sub
    Private Function CargaCta() As String
        Dim ctacte As String = ""
        Dim cta As New CtaMtn.BuscaCta()
        ctacte = cta.BuscaCtaCtb("", "S")
        Return ctacte
    End Function
    Private Sub Bloquear(ByVal op As Boolean)
        Dim Control1 As System.Windows.Forms.Control
        Dim a As String
        btnNuevo.Enabled = op
        btnModificar.Enabled = op
        btnEliminar.Enabled = op
        btnSalir.Enabled = op
        btnSuc.Enabled = op

        btnIdCont.Enabled = Not op
        btnGuardar.Enabled = Not op
        btnCancelar.Enabled = Not op
        mallaBod.Enabled = Not op
        mallaPtoVta.Enabled = Not op
        For Each Control1 In GroupBox1.Controls
            a = TypeName(Control1)
            If a = "TextBox" Then Control1.Enabled = Not op
            If a = "MaskedTextBox" Then Control1.Enabled = Not op
        Next
    End Sub

    Private Sub mallaBod_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles mallaBod.CellEnter
        Try
            fila = e.RowIndex
            columna = e.ColumnIndex
        Catch ex As Exception
            MsgBox("exception enter : " & ex.Message)
        End Try
    End Sub
    Private Sub mallaBod_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mallaBod.KeyDown
        Try
            If e.KeyCode = Keys.F2 And columna = 2 Then
                mallaBod.Rows(fila).Cells(2).Value = CargaCta()
            End If
        Catch ex As Exception
            MsgBox("exception keyd : " & ex.Message)
        End Try
    End Sub
    Private Sub mallaPtoVta_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles mallaPtoVta.CellEnter
        fila = e.RowIndex
        columna = e.ColumnIndex
    End Sub

    Private Sub mallaPtoVta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mallaPtoVta.KeyDown
        If e.KeyCode = Keys.F2 And columna = 2 Then
            mallaPtoVta.Rows(fila).Cells(2).Value = CargaCta()
        ElseIf e.KeyCode = Keys.F2 And columna = 4 Then
            Dim sysd As New Syscod.frmBuscarTipoRef()
            Dim tipo As String = "TipoPuntoAtencion"
            Dim Cod As String = ""
            Dim Desc As String = ""
            sysd.BuscarTipoRef(tipo, Cod, Desc)
            mallaPtoVta.Rows(fila).Cells(4).Value = Cod
        End If
    End Sub
#End Region

#Region "CaragrDatos"
    Private Sub CargarDatos(ByVal emp As Integer, ByVal suc As String)
        Limpiar()
        CargarSuc(emp, suc)
        CargarBod(emp, suc)
        CargarPto(emp, suc)
    End Sub
    Private Sub CargarSuc(ByVal emp As Integer, ByVal suc As String)
        Dim s As New Emp_Suc
        s.Consultar(CInt(emp), suc)
        txtEmpresa.Text = empresaNom
        txtSuc.Text = CodSucursal
        txtNom.Text = s.Suc_Nombre
        txtDir.Text = s.Suc_Direccion
        txtRuc.Text = s.Suc_RUC
        txtSegSoc.Text = s.Suc_SegSocial
        txtIdTrib.Text = s.Suc_IdTributario
        txtIdCont.Text = s.Suc_IdCta
        txtPrecioVta.Text = s.precioVta.ToString
    End Sub
    Private Function ObtnrCodSuc(ByVal emp As Int32) As String
        Dim codS As String = ""
        'Dim cmd As New SqlCommand("select min(suc_codigo) from Emp_Suc where Emp_Codigo =" & emp, ConSys)
        Dim dat As SqlDataReader = DattCom.SqlDatos.leerBaseIniSis("select min(suc_codigo) from Emp_Suc where Emp_Codigo =" & emp)
        'ConSys.Open()
        'dat = cmd.ExecuteReader()
        If dat.Read Then
            If Not IsDBNull(dat(0)) Then codS = CStr(dat(0))
        End If
        'ConSys.Close()
        Return codS
    End Function
    Private Sub CargarBod(ByVal emp As Integer, ByVal suc As String)
        Dim con As Integer = 0
        Dim ssql As String = "select Bod_codigo, Bod_nombre, Bod_IdCta from Emp_Bod  where Emp_Codigo =" & emp & " and Suc_Codigo ='" & suc & "'"
        'Dim cmd As New SqlCommand(ssql, ConSys)
        Dim dat As SqlDataReader = DattCom.SqlDatos.leerBaseIniSis(ssql)
        'ConSys.Open()
        'dat = cmd.ExecuteReader()
        With mallaBod
            While dat.Read
                .Rows.Add()
                If Not IsDBNull(dat("Bod_codigo")) Then .Rows(con).Cells(0).Value = dat("Bod_codigo")
                If Not IsDBNull(dat("Bod_nombre")) Then .Rows(con).Cells(1).Value = dat("Bod_nombre")
                If Not IsDBNull(dat("Bod_IdCta")) Then .Rows(con).Cells(2).Value = dat("Bod_IdCta")
                con += 1
            End While
        End With
        'ConSys.Close()
    End Sub
    Private Sub CargarPto(ByVal emp As Integer, ByVal suc As String)
        Dim con As Integer = 0
        Dim ssql As String = "select * from Emp_PtoVta   where Emp_Codigo =" & emp & " and Suc_Codigo ='" & suc & "'"
        'Dim cmd As New SqlCommand(ssql, ConSys)
        Dim dat As SqlDataReader = DattCom.SqlDatos.leerBaseIniSis(ssql)
        'ConSys.Open()
        'dat = cmd.ExecuteReader()
        With mallaPtoVta
            While dat.Read
                .Rows.Add()
                If Not IsDBNull(dat("Pto_codigo")) Then .Rows(con).Cells(0).Value = dat("Pto_codigo")
                If Not IsDBNull(dat("Pto_nombre")) Then .Rows(con).Cells(1).Value = dat("Pto_nombre")
                If Not IsDBNull(dat("Pto_IDTributario")) Then .Rows(con).Cells("IdTrib").Value = dat("Pto_IDTributario")
                If Not IsDBNull(dat("Pto_IdCta")) Then .Rows(con).Cells("IdCtb").Value = dat("Pto_IdCta")
                If Not IsDBNull(dat("TipoPunto")) Then .Rows(con).Cells("TipoPunto").Value = dat("TipoPunto")
                con += 1
            End While
        End With
        'ConSys.Close()
    End Sub
#End Region

#Region "Cambios"
    Private Sub txtEmpresa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmpresa.TextChanged
        cambios += 1
    End Sub

    Private Sub txtSuc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSuc.TextChanged
        cambios += 1
    End Sub

    Private Sub txtNom_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNom.TextChanged
        cambios += 1
    End Sub

    Private Sub txtDir_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDir.TextChanged
        cambios += 1
    End Sub

    Private Sub txtRuc_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtRuc.MaskInputRejected
        cambios += 1
    End Sub

    Private Sub txtSegSoc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSegSoc.TextChanged
        cambios += 1
    End Sub

    Private Sub txtIdTrib_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIdTrib.TextChanged
        cambios += 1
    End Sub

    Private Sub txtIdCont_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIdCont.TextChanged, txtPrecioVta.TextChanged
        cambios += 1
    End Sub
#End Region

#Region "Nuevo"
    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Bloquear(False)
        Limpiar()
        accion = "G"
        txtEmpresa.Text = empresaNom
        cambios = 0
    End Sub
    Private Sub Limpiar()
        Dim Control1 As System.Windows.Forms.Control
        Dim a As String
        For Each Control1 In GroupBox1.Controls
            a = TypeName(Control1)
            If a = "TextBox" Then Control1.Text = ""
            If a = "MaskedTextBox" Then Control1.Text = "  /  /"
        Next
        mallaBod.Rows.Clear()
        mallaPtoVta.Rows.Clear()
    End Sub
#End Region

#Region "Guardar/modificar"
    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        accion = "M"
        Bloquear(False)
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim msg As String = VerificarDat()
        If msg <> "" Then MsgBox(msg, MsgBoxStyle.Information) : Exit Sub
        guardarSuc(EmpresaCod)
        guardarBod(EmpresaCod, txtSuc.Text)
        guardarPto(EmpresaCod, txtSuc.Text)
        CodSucursal = txtSuc.Text
        cancelar(EmpresaCod, CodSucursal)
    End Sub
    Private Function VerificarDat() As String
        Dim msg As String = ""
        If txtSuc.Text = "" Then msg = "Ingrese el Codigo de la Sucursal" : Return msg : Exit Function
        For i = 0 To mallaBod.RowCount - 2
            If IsNothing(mallaBod.Rows(i).Cells(0).Value) Then
                msg = "Virifique que todas las Bodegas tengan Codigo" : Return msg : Exit Function
            End If
        Next
        For i = 0 To mallaPtoVta.RowCount - 2
            If IsNothing(mallaPtoVta.Rows(i).Cells(0).Value) Then
                msg = "Verifique que todos los Puntos de Venta tengan Codigo" : Return msg : Exit Function
            End If
        Next
        Return msg
    End Function

    Private Sub guardarSuc(ByVal emp As Int32)
        Dim codBod As String = ""
        If mallaBod.RowCount > 1 Then codBod = CStr(mallaBod.Rows(0).Cells(0).Value)
        Dim s As New Emp_Suc
        s.Emp_Codigo = emp
        s.Suc_Codigo = txtSuc.Text
        s.Suc_Nombre = txtNom.Text
        s.Suc_Direccion = txtDir.Text
        s.Suc_RUC = txtRuc.Text
        s.Suc_SegSocial = txtSegSoc.Text
        s.Suc_IdCta = txtIdCont.Text
        s.Bod_Codigo = codBod
        s.Suc_IdTributario = txtIdTrib.Text
        s.precioVta = Val(txtPrecioVta.Text)
        If accion = "G" Then
            s.Guardar()
        ElseIf accion = "M" Then
            s.Actualizar(emp, txtSuc.Text)
        End If
    End Sub
    Private Sub guardarBod(ByVal emp As Int32, ByVal suc As String)
        Dim b As New Emp_Bod
        b.Emp_Codigo = emp
        b.Suc_Codigo = suc
        b.Eliminar(CStr(emp), suc, "")
        With mallaBod
            For i = 0 To mallaBod.RowCount - 2
                b.Bod_codigo = CStr(.Rows(i).Cells(0).Value)
                b.Bod_nombre = CStr(.Rows(i).Cells(1).Value)
                b.Bod_IdCta = CStr(.Rows(i).Cells(2).Value)
                b.Guardar()
            Next
        End With
    End Sub
    Private Sub guardarPto(ByVal emp As Integer, ByVal suc As String)
        Dim p As New Emp_ptoVta
        p.Emp_Codigo = CStr(emp)
        p.Suc_Codigo = CStr(suc)
        p.Eliminar(CStr(emp), CStr(suc), "")
        With mallaPtoVta
            For i = 0 To mallaPtoVta.RowCount - 2
                p.Pto_codigo = CStr(.Rows(i).Cells(0).Value)
                p.Pto_nombre = CStr(.Rows(i).Cells(1).Value)
                p.Pto_IdCta = CStr(.Rows(i).Cells("IdCtb").Value)
                p.Pto_IDTributario = CStr(.Rows(i).Cells("IdTrib").Value)
                p.TipoPunto = CStr(.Rows(i).Cells("TipoPunto").Value)
                p.Guardar()
            Next
        End With
    End Sub
#End Region

#Region "Eliminar"
    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If MsgBox("Esta seguro que desea eliminar la sucursal?", MsgBoxStyle.YesNo) = vbYes Then
            eliminar(CStr(EmpresaCod), CodSucursal)
            CodSucursal = ObtnrCodSuc(EmpresaCod)
            CargarDatos(EmpresaCod, CodSucursal)
        End If
    End Sub
    Private Sub eliminar(ByVal emp As String, ByVal suc As String)
        Dim s As New Emp_Suc
        s.Eliminar(CInt(emp), suc)
    End Sub
#End Region

#Region "Salir/Cancelar"
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If cambios > 1 Then
            If MsgBox("Desea guardar los cambios?", MsgBoxStyle.YesNo) = vbYes Then
                guardarSuc(EmpresaCod)
                cancelar(EmpresaCod, CodSucursal)
            Else
                cancelar(EmpresaCod, CStr(ObtnrCodSuc(EmpresaCod)))
            End If
        Else
            cancelar(EmpresaCod, CStr(ObtnrCodSuc(EmpresaCod)))
        End If
    End Sub
    Private Sub frmSuc_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If cambios > 1 Then
            If MsgBox("Desea guardar los cambios?", MsgBoxStyle.YesNo) = vbYes Then
                guardarSuc(EmpresaCod)
                cancelar(EmpresaCod, CodSucursal)
            Else
                cancelar(EmpresaCod, CStr(ObtnrCodSuc(EmpresaCod)))
            End If
        Else
            cancelar(EmpresaCod, CStr(ObtnrCodSuc(EmpresaCod)))
        End If
    End Sub
    Private Sub cancelar(ByVal emp As Integer, ByVal suc As String)
        Limpiar()
        Bloquear(True)
        CargarDatos(emp, suc)
        cambios = 0
        accion = ""
    End Sub
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub mallaPtoVta_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles mallaPtoVta.CellContentClick

    End Sub
#End Region

    Public Sub Sucursales(ByVal empCod As Integer, ByVal empNom As String)
        EmpresaCod = empCod
        empresaNom = empNom
        Me.ShowDialog()
    End Sub

    'Private Sub mallaBod_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles mallaBod.Scroll
    '    Dim a As Integer
    '    a = 1
    'End Sub

    'Private Sub mallaBod_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles mallaBod.CellContentClick

    'End Sub


End Class