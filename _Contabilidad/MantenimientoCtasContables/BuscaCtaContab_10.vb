Option Strict Off
Option Explicit On
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DattCom

Friend Class BuscaCtaContab
    Inherits System.Windows.Forms.Form
    Dim MovAgr, CodigoArt As String
    Dim CodigoRet As String
    Dim Sw As Boolean
    Dim Ini, Fin As Date
    Dim Act1 As Boolean
    Dim ConNombre As Boolean
    Dim fila As Integer = 0
    Private Sub btnbuscar_Click()
        Retorna()
    End Sub

    Public Function IniciaCtas(Optional ByRef PriCta As String = "", Optional ByRef mov As String = "") As String
        If Not IsNothing(PriCta) Then
            CodigoArt = PriCta
        Else
            CodigoArt = ""
        End If
        MovAgr = Strings.Left(UCase(mov), 1)
        Me.ShowDialog()
        IniciaCtas = CodigoRet
    End Function

    Private Sub btAceptar_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btAceptar.Click
        ListNombre_DoubleClick(ListNombre, New System.EventArgs())
    End Sub

    Private Sub btncancelarbusca_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btncancelarbusca.Click
        CodigoRet = ""
        Sw = False
        Me.Close()
    End Sub

    Private Sub BuscaCtaContab_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        SaveSetting("ADCOM", "BUSCAR", "Cta", IIf(OptNombre.Checked, 1, 0))
    End Sub

    Private Sub btNuevo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btNuevo.Click
        Dim prog As New CTBP01
        prog.ShowDialog()
        prog.Close()
        prog = Nothing
    End Sub

    ''Private Sub BuscaCtaContab_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
    ''    On Error Resume Next
    ''    'TxtNombre.SetFocus
    ''    '' by Victor
    ''    'ListNombre.Col = 1
    ''    'ListNombre.Row = 1
    ''    'If ListNombre.Rows > 2 Then ListNombre.SetFocus
    ''    If Act1 = False Then
    ''        If TxtNombre.Text > "" Then
    ''            If ListNombre.Rows > 2 Then
    ''                With ListNombre
    ''                    .Row = 1
    ''                    .Col = 1
    ''                    .Focus()
    ''                End With
    ''            Else
    ''                TxtNombre.Focus()
    ''                '        PonerSel TxtNombre
    ''            End If
    ''        Else
    ''            TxtNombre.Focus()
    ''        End If
    ''        Act1 = True
    ''    End If
    ''End Sub

    Private Sub BuscaCtaContab_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Sw = False
        'Me.Caption = "Busqueda de Artículos"
        If CDbl(GetSetting("ADCOM", "BUSCAR", "ARTICULO", CStr(0))) = 1 Then
            OptNombre.Checked = True
        Else
            Optcodigo.Checked = True
        End If
        OpCentrosCosto.Visible = True 'Emp.Ccosto
        TextCodigo.Text = CodigoArt
        Sw = True
        ArreglaMalla()
    End Sub
    Private Sub OpCentrosCosto_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OpCentrosCosto.CheckStateChanged
        ArreglaMalla()
    End Sub

    Private Sub OpComodines_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OpComodines.CheckStateChanged
        ArreglaMalla()
        TxtNombre.Focus()
    End Sub

    'Private Sub listnombre_KeyDown(KeyCode As Integer, Shift As Integer)
    ' If KeyCode = vbKeyReturn Then listnombre_DblClick
    '    If ListNombre.Rows = 0 Then Exit Sub
    '    If KeyCode = vbKeyF5 Then
    '        DetalleArt.ConsultaDetalle ListNombre.TextMatrix(ListNombre.Row, 1), ListNombre.TextMatrix(ListNombre.Row, 2)
    '        ListNombre.SetFocus
    '        Set DetalleArt = Nothing
    '    ElseIf KeyCode = vbKeyF6 Then
    '        Compatibles.ConsultarCompatibles ListNombre.TextMatrix(ListNombre.Row, 1), ListNombre.TextMatrix(ListNombre.Row, 2)
    '        ListNombre.SetFocus
    '        Set Compatibles = Nothing
    '    ElseIf KeyCode = vbKeyF7 Then
    '        ExistenciasArt.INIExistencia ListNombre.TextMatrix(ListNombre.Row, 1), "", "", Date, ""
    '        Set ExistenciasArt = Nothing
    '    End If
    '
    'End Sub

    Private Sub optCodigo_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Optcodigo.CheckedChanged
        If eventSender.Checked Then
            ArreglaMalla()
            TxtNombre.Focus()
        End If
    End Sub

    Private Sub optNombre_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OptNombre.CheckedChanged
        If eventSender.Checked Then
            On Error Resume Next
            'TxtNombre.Text = ""
            'Label2.Caption = ""
            ArreglaMalla()
            TxtNombre.Focus()
        End If
    End Sub

    Private Sub ArreglaMalla()
        Dim NomCod, CODSQL As String
        Dim busca As String
        Dim Seleccion As String
        Dim con As New SqlConnection()
        If Sw = False Then Exit Sub
        On Error Resume Next
        Seleccion = " Cta_grupo as Grupo,Cta_codigo AS CODIGO, Cta_Nombre AS Nombre "
        If OpCentrosCosto.Checked = True Then Seleccion += ",Clasificadores "
        NomCod = ""
        If OptNombre.Checked = True Then
            NomCod = "cta_NOMBRE"
        Else
            NomCod = "cta_codigo"
        End If

        CODSQL = "SELECT " & Seleccion & " From adccta where cta_codigo > '' "
        If OpCentrosCosto.Checked = True Then CODSQL += " and ISNULL(clasificadores,'') <> '' "
        If TxtGrupo.Text > "" Then
            If PorInicial.CheckState Then
                CODSQL = CODSQL & " AND cta_grupo LIKE '" & TxtGrupo.Text & "%' "
            Else
                CODSQL = CODSQL & " AND cta_grupo LIKE '%" & TxtGrupo.Text & "%' "
            End If
        End If
        If TextCodigo.Text > "" Then
            If PorInicial.CheckState Then
                CODSQL = CODSQL & " AND cta_codigo LIKE '" & TextCodigo.Text & "%' "
            Else
                CODSQL = CODSQL & " AND cta_codigo LIKE '%" & TextCodigo.Text & "%' "
            End If
        End If
        If TxtNombre.Text > "" Then
            If PorInicial.CheckState Then
                CODSQL = CODSQL & " AND cta_NOMBRE LIKE '" & TxtNombre.Text & "%' "
            Else
                CODSQL = CODSQL & " AND cta_NOMBRE LIKE '%" & TxtNombre.Text & "%' "
            End If
        End If
        If OpCentrosCosto.CheckState Then
            CODSQL = CODSQL & " AND cta_ccosto ='S' "
        End If

        OpComodines.Visible = False

        If MovAgr = "S" Then
            Me.Text = "BUSCAR CUENTAS CONTABLES DE MOVIMIENTO"
            CODSQL = CODSQL & " AND cta_agrupacion = 0 "
        ElseIf MovAgr = "M" Then
            Me.Text = "BUSCAR CUENTAS CONTABLES MAYORES"
            CODSQL = CODSQL & " AND cta_agrupacion <> 0 "
        ElseIf MovAgr = "I" Then
            Me.Text = "Buscar cuentas para contabilización automática"
            CODSQL = CODSQL & " AND cta_agrupacion = 0 "
            OpComodines.Visible = True
        End If
        busca = ""
        CODSQL = CODSQL & busca & " ORDER BY " & NomCod & " ; "

        If OpComodines.CheckState = 0 Then
            ListNombre.DataSource = SqlDatos.leerTablaAdcom(CODSQL)
        Else
            CODSQL = "Select IDCLAVECOM AS Nro,Com_Clave as Comodin,Com_Descripcion as Descripción from sys_Comodin "
            ListNombre.DataSource = SqlDatos.leerTablaIniSis(CODSQL)
        End If
        Ini = TimeOfDay
        con.Close()
        With ListNombre
            If .RowCount > 1 Then .Rows(1).Frozen = True
            If OpComodines.CheckState = 0 Then
                If .ColumnCount > 0 Then .Columns(0).HeaderText = "Grupo"
                If .ColumnCount > 0 Then .Columns(1).HeaderText = "Codigo"
                If .ColumnCount > 0 Then .Columns(2).HeaderText = "Nombre"
            End If

        End With
        Fin = TimeOfDay

    End Sub

    Private Sub Retorna()
        On Error Resume Next
        CodigoCta = ListNombre.Rows(fila).Cells(1).Value
        NombreCta = ListNombre.Rows(fila).Cells(2).Value
        Sw = False
        Me.Close()
    End Sub

    Private Sub TextCodigo_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TextCodigo.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = System.Windows.Forms.Keys.Return Then ArreglaMalla()
    End Sub

    Private Sub TextCodigo_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TextCodigo.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = Asc(vbCr) Then KeyAscii = 0
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub TxtGrupo_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TxtGrupo.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = System.Windows.Forms.Keys.Return Then ArreglaMalla()
    End Sub

    Private Sub TxtGrupo_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TxtGrupo.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = Asc(vbCr) Then KeyAscii = 0
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub TxtNombre_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles TxtNombre.TextChanged
        If PorInicial.CheckState Then ArreglaMalla()
    End Sub

    Private Sub txtNombre_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles TxtNombre.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = System.Windows.Forms.Keys.Return Then ArreglaMalla()
    End Sub

    Private Sub TxtNombre_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles TxtNombre.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = Asc(vbCr) Then KeyAscii = 0
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub ListNombre_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ListNombre.CellEnter
        fila = e.RowIndex
    End Sub

    Private Sub ListNombre_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListNombre.DoubleClick
        If ListNombre.RowCount = 0 Then Exit Sub
        With ListNombre
            If .Rows(fila).Cells(1).Value > "" Then Retorna()
        End With
    End Sub
    Private Sub ListNombre_CellMouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles ListNombre.CellMouseMove
        Dim codigo As String
        Dim j As Short
        Dim L As Short
        On Error Resume Next
        If OpComodines.CheckState = 0 Then
            With ListNombre
                j = .Rows(e.RowIndex).Cells(3).Value
                L = Len(.Rows(e.RowIndex).Cells(1).Value)
                If j > 1 Then
                    j = Val(Mid(Emp.CtaNumDigNivel, j, 1))
                    codigo = Mid(.Rows(e.RowIndex).Cells(1).Value, 1, L - j)
                End If
            End With
            codigo = ""
            Dim ssql As String = "SELECT CTA_CODIGO,CTA_NOMBRE,clasificadores FROM ADCCTA WHERE CTA_CODIGO = '" & codigo & "'"
            Dim dat As SqlDataReader = SqlDatos.leerBaseAdcom(ssql)
            If Not dat.Read Then dat.Close() : Exit Sub
            ToolTip1.SetToolTip(ListNombre, dat("CTA_CODIGO").Value & "-" & dat("CTA_NOMBRE").Value)
            dat.Close()
        Else
            ToolTip1.SetToolTip(ListNombre, "El comodín se reemplaza por la cuenta contable registrada en:")
        End If
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Dim imp As New DataGridViewPrinterApplication1.frmMain
        imp.imprimir(ListNombre, "Plan de cuentas contables ", , DattCom.datosEmpresa.Emp_Nombre)
    End Sub

    Private Sub PorInicial_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PorInicial.CheckedChanged

    End Sub
End Class