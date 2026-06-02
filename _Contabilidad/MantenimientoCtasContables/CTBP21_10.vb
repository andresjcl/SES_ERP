Option Strict Off
Option Explicit On
Imports System.Data
Imports System.Data.SqlClient
Imports DattCom
Imports mallExp

Friend Class CTBP21
	Inherits System.Windows.Forms.Form
    Dim CtaAnt As String
	Dim Tam(5, 8) As String
	Dim TotDoc(6) As Double
	Dim TotSuc(6) As Double
	Dim TotGen(6) As Double
	Dim suma As Double
	Dim alto, Pagina As Short
	Dim AUXIL2, Auxil, titulo As String
    '	Dim RsCta As New ADODB.Recordset
    Dim CbNiv As Short = 1
    Dim ChTCtas As Short = 1
    Dim conectar As New SqlConnection()
    Dim conectarDaxys As New SqlConnection()

    'Private Sub conectarBDD()
    '    Dim coneccion As New DaxLib.DaxLibBases
    '    coneccion.TipoBase = "10"
    '    conectar.ConnectionString = coneccion.StrAdcom
    '    conectarDaxys.ConnectionString = coneccion.StrDaxsys
    'End Sub
    Private Sub btImprimir_Click()
        'Donde = frmenviar.EnviarImpresion
        'If Donde > "" Then ChequearSalida: Me.Refresh:
        Impresion()
    End Sub

    Private Sub btSalir_Click()
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub CTBP21_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        CbNiv = 6
        ChTCtas = 2
        CargarDatos()
    End Sub
    Public Sub Impresion()
        Dim imp As New DataGridViewPrinterApplication1.frmMain
        imp.imprimir(MALLA, "Plan de cuentas contables ", , DattCom.datosEmpresa.Emp_Nombre)
    End Sub
    Private Sub CargarDatos()
        Dim i As Short
        Dim Seleccion As String
        Dim PosNiv(10) As Short
        Dim NumNiv As Short
        Dim Tniv(10) As Short
        Dim Espacios As String
        'On Error GoTo HayErrores
        Espacios = Space(30)
        NumNiv = Emp.CtaNumNiveles
        For i = 1 To NumNiv
            Tniv(i) = Val(Mid(Emp.CtaNumDigNivel, i, 1))
        Next

        PosNiv(1) = 1
        PosNiv(2) = PosNiv(1) + Tniv(1)
        PosNiv(3) = PosNiv(2) + Tniv(2)
        PosNiv(4) = PosNiv(3) + Tniv(3)
        PosNiv(5) = PosNiv(4) + Tniv(4)
        PosNiv(6) = PosNiv(5) + Tniv(5)

        Pagina = 0
        Seleccion = ""
        'If txtCtaIni.Text > "" And txtCtaFin.Text > txtCtaIni.Text Then
        '    Seleccion = "AND Cta_codigo >= '" & txtCtaIni.Text & "' and Cta_codigo <= '" & txtCtaFin.Text & "' "
        'End If
        If ChTCtas = 1 Then Seleccion += " AND CTA_AGRUPACION = 0 "
        If ChTCtas = 4 Then Seleccion += " AND ISNULL(clasificadores,'') <> '' "
        Dim cod As String = "SELECT"
        cod = cod & " Case cta_nivel"
        cod = cod & " when 1 then cta_codigo"
        cod = cod & " when 2 then cta_codigo"
        cod = cod & " when 3 then cta_codigo"
        cod = cod & " when 4 then substring(cta_codigo,1," & PosNiv(4) - 1 & ") + '.' + substring (cta_codigo," & PosNiv(4) & "," & Tniv(4) & " )"
        cod = cod & " when 5 then substring(cta_codigo,1," & PosNiv(4) - 1 & ") + '.' + substring (cta_codigo," & PosNiv(4) & "," & Tniv(4) & " ) + '.' + substring (cta_codigo," & PosNiv(5)  & "," & Tniv(5) & ") "
        cod = cod & " when 6 then substring(cta_codigo,1," & PosNiv(4) - 1 & ") + '.' + substring (cta_codigo," & PosNiv(4) & "," & Tniv(4) & " ) + '.' + substring (cta_codigo," & PosNiv(5) & "," & Tniv(5) & ") + '.' + substring (cta_codigo," & PosNiv(6) & "," & Tniv(6) & ") "
        cod = cod & " End"
        cod = cod & " as Cuenta"
        cod = cod & ", Cta_nombre "
        'cod = cod & " ,case cta_nivel"
        'cod = cod & " when 1 then  Cta_nombre"
        'cod = cod & " when 2 then '   ' + Cta_nombre"
        'cod = cod & " when 3 then '         ' + Cta_nombre"
        'cod = cod & " when 4 then '            ' + Cta_nombre"
        'cod = cod & " when 5 then '               ' + Cta_nombre"
        'cod = cod & " when 6 then '                  ' + Cta_nombre"
        'cod = cod & " End"
        cod = cod & " as NombreCuenta"
        cod = cod & " ,case  cta_grupo"
        cod = cod & " when 1 then 'Activos'"
        cod = cod & " when 2 then 'Pasivos'"
        cod = cod & " when 3 then 'Patrimonio'"
        cod = cod & " when 4 then 'Resultados'"
        cod = cod & " when 5 then 'Orden'"
        cod = cod & " End"
        cod = cod & " as CtaDe"
        cod = cod & ",ModuloAuxiliar"
        cod = cod & " ,case Cta_Agrupacion"
        cod = cod & " when 1 then 'Agrupación'"
        cod = cod & " Else  'Movimiento'"
        cod = cod & " End"
        cod = cod & " as TipoCta"
        cod = cod & ", Clasificadores"
        cod = cod & " From ADCCTA "
        cod = cod & " WHERE Cta_Nivel<=" & Nivel.Text.Substring(Nivel.Text.Length - 1, 1) & " " & Seleccion & " ORDER BY Cta_Codigo , Cta_nombre "
        If ChTCtas = 3 Then cod = "Select IDCLAVECOM AS Nro,Com_Clave as Comodin,Com_Descripcion as Descripción from sys_Comodin "
        Dim datS As New DataSet()
        Dim datA As New SqlDataAdapter(cod, datosEmpresa.strConxAdcom)
        datA.Fill(datS, "Datos")
        MALLA.DataSource = datS.Tables("Datos")
        Exit Sub
HayErrores:


    End Sub

    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnactualizar.Click, btnimprimir.Click, btnsalir.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
        Select Case Button.Name
            Case "btnactualizar"
                CargarDatos()
            Case "btnimprimir"
                ' btImprimir_Click()
            Case "btnsalir"
                Me.Close()
        End Select
    End Sub

    'Private Sub txtCtaFin_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs)
    '    Dim KeyCode As Short = eventArgs.KeyCode
    '    Dim Shift As Short = eventArgs.KeyData \ &H10000
    '    Dim BCContab As New BuscaCtaContab
    '    If System.Windows.Forms.Keys.F2 = KeyCode Then
    '        txtCtaFin.Text = BCContab.IniciaCtas(txtCtaFin.Text)
    '            '        Buscar(2)
    '    ElseIf System.Windows.Forms.Keys.Return = KeyCode Then
    '        Buscar(2)
    '    End If
    '    BCContab = Nothing
    'End Sub


    'Private Sub Buscar(ByRef op As Short)
    '    '        Dim RsAux As New ADODB.Recordset
    '    Dim cod As String = ""
    '    '       Dim linkdat As New DaxData.DaxLibDatos
    '    '        cod = "SELECT Cta_Codigo,Cta_Nombre FROM AdcCta WHERE Cta_Codigo='" & IIf(op = 1, txtCtaIni.Text, txtCtaFin.Text) & "'"
    '    Dim RsAux = linkdat.DaxData("", cod) '.Open cod, ConxAdcom, adOpenKeyset, adLockOptimistic
    '    If RsAux.EOF = False Then
    '        If op = 1 Then
    '            'lbNomCta1 = RsAux!CTA_NOMBRE
    '        Else
    '            'lbNomCta2 = RsAux!CTA_NOMBRE
    '        End If
    '    Else
    '        'If op = 1 Then
    '        '    'lbNomCta1 = ""
    '        '    txtCtaIni.Text = ""
    '        'Else
    '        '    'lbNomCta2 = ""
    '        '    txtCtaFin.Text = ""
    '        'End If
    '    End If
    '    RsAux = Nothing
    '    linkdat = Nothing
    'End Sub

    'Private Sub txtCtaFin_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    '    Buscar(2)
    'End Sub

    'Private Sub txtCtaIni_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs)
    '    Dim KeyCode As Short = eventArgs.KeyCode
    '    Dim Shift As Short = eventArgs.KeyData \ &H10000
    '    Dim BCContab As New BuscaCtaContab

    '    If System.Windows.Forms.Keys.F2 = KeyCode Then
    '        '            txtCtaIni.Text = BCContab.IniciaCtas(txtCtaIni.Text)
    '        Buscar(1)
    '    ElseIf System.Windows.Forms.Keys.Return = KeyCode Then
    '        Buscar(1)
    '    End If
    '    BCContab = Nothing
    'End Sub

    Private Sub Nivel1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nivel1ToolStripMenuItem.Click
        Nivel.Text = sender.text
        CbNiv = 1
    End Sub

    Private Sub Nivel2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nivel2ToolStripMenuItem.Click
        Nivel.Text = sender.text
        CbNiv = 2
    End Sub

    Private Sub Nivel3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nivel3ToolStripMenuItem.Click
        Nivel.Text = sender.text
        CbNiv = 3

    End Sub

    Private Sub Nivel4ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nivel4ToolStripMenuItem.Click
        Nivel.Text = sender.text
        CbNiv = 4

    End Sub

    Private Sub Nivel5ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nivel5ToolStripMenuItem.Click
        Nivel.Text = sender.text
        CbNiv = 5

    End Sub

    Private Sub Nivel6ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nivel6ToolStripMenuItem.Click
        Nivel.Text = sender.text
        CbNiv = 6
    End Sub

    Private Sub CtasMovimientoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles movimiento.Click
        CuentaCtas.Text = sender.text
        ChTCtas = 1
    End Sub

    Private Sub TodasLasCtasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles todas.Click
        CuentaCtas.Text = sender.text
        ChTCtas = 2
    End Sub

    Private Sub ComodinesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comodines.Click
        CuentaCtas.Text = sender.text
        ChTCtas = 3
    End Sub

    Private Sub clasificadoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clasificadores.Click
        CuentaCtas.Text = sender.text
        ChTCtas = 4
    End Sub

    Private Sub btnimprimir_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnimprimir.ButtonClick
        btnimprimir.ShowDropDown()
    End Sub

    Private Sub ImprimirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirToolStripMenuItem.Click
        btImprimir_Click()
    End Sub

    Private Sub WordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WordToolStripMenuItem.Click
        Dim exp As New mallExp.Form1
        exp.Exportar(MALLA, "W", DattCom.datosEmpresa.Emp_Nombre, "PLAN DE CUENTAS CONTABLES")
    End Sub

    Private Sub ExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelToolStripMenuItem.Click
        Dim exp As New mallExp.Form1
        exp.Exportar(MALLA, "E", DattCom.datosEmpresa.Emp_Nombre, "PLAN DE CUENTAS CONTABLES")
    End Sub

    Private Sub PDFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PDFToolStripMenuItem.Click
        Dim exp As New mallExp.Form1
        exp.Exportar(MALLA, "P", DattCom.datosEmpresa.Emp_Nombre, "PLAN DE CUENTAS CONTABLES")
        CargarDatos()
    End Sub
End Class