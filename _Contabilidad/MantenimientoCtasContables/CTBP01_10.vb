Option Strict Off
Option Explicit On
Imports System.Data
Imports System.Data.SqlClient
Imports DattCom
Public Class CTBP01
    Inherits System.Windows.Forms.Form

    Dim NivAct, GrupAct As Integer
    Dim CtaAct As String
    Private Sub Command2_Click()
        Dim prog As New CTBP21
        prog.ShowDialog()
        prog.Close()
        prog.Dispose()
    End Sub

    Private Sub CuentaNueva_Click()
        Dim prog As New CTBP01_1
        prog.CrearCuenta(CtaAct, NivAct, GrupAct, "N", trArbol)
        prog.Dispose()
    End Sub

    Private Sub CTBP01_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        Dim Separacion As Short
        On Error Resume Next
        Separacion = 100
        With Me
            'Frame1.Left = Me.Width - Frame1.Width - Separacion * 2
            trArbol.Left = (Separacion)
            trArbol.Width = .Width - Separacion * 4
            trArbol.Height = .Height - Toolbar1.Height - Separacion * 8
        End With

    End Sub

    Private Sub InsertarCuenta_Click()
        Dim prog As New CTBP01_1
        prog.CrearCuenta(CtaAct, NivAct, GrupAct, "I", trArbol)
        prog = Nothing
        trArbol.Refresh()
    End Sub

    Private Sub ModificarCuenta_Click()
        Dim prog As New CTBP01_1
        prog.CrearCuenta(CtaAct, NivAct, GrupAct, "M", trArbol)
        prog = Nothing
        PonerDatosRapidos()
        trArbol.Refresh()
    End Sub

    Private Sub EliminarCuenta_Click()
        Dim Ctaaux As New Cuenta
        CtaAct = Mid(trArbol.SelectedNode.Name, 2)
        If Ctaaux.Eliminar(CtaAct) = True Then
            trArbol.Nodes.Remove(trArbol.SelectedNode)
        End If
        Ctaaux = Nothing
    End Sub

    Public Sub CTBP01_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        cargarParametrosEmpresa()
        CargaCtas()
        EstaEnDefinicion()
    End Sub


    Private Sub CargaCtas()
        Dim RsCta As SqlDataReader
        Dim Aux As String
        Dim Indice As Short
        Dim ConxAdcom As New SqlConnection(datosEmpresa.strConxAdcom)
        trArbol.Nodes.Clear()
        CargaTipoCta()
        Indice = 0

        Aux = "select * from adccta order by cta_codigo"

        RsCta = DattCom.SqlDatos.leerBase(Aux, datosEmpresa.strConxAdcom)
        Indice = 0
        Dim CtaNivel As Integer = 1
        Dim ctaCodigo As String
        With RsCta
            Do Until RsCta.Read = False
                Indice = Indice + 1
                If Not IsDBNull(.Item("Cta_Nivel")) Then CtaNivel = .Item("Cta_Nivel")
                If CtaNivel = 0 Then CtaNivel = 1
                ctaCodigo = .Item("CTA_CODIGO").ToString()
                Aux = QuePadreDeCta(ctaCodigo, CtaNivel)

                If Aux = "" Then
                    trArbol.Nodes.Find("M" & Trim(.Item("cta_grupo")), True)(0).Nodes.Add("C" & Trim(ctaCodigo), ctaCodigo & "  " & .Item("CTA_NOMBRE"), 2, 3)
                Else
                    If .Item("cta_agrupacion") = True Then
                        trArbol.Nodes.Find("C" & Aux, True)(0).Nodes.Add("C" & Trim(ctaCodigo), ctaCodigo & "  " & .Item("CTA_NOMBRE"), 2, 3)
                    Else
                        trArbol.Nodes.Find("C" & Aux, True)(0).Nodes.Add("C" & Trim(ctaCodigo), ctaCodigo & "  " & .Item("CTA_NOMBRE"), 4, 5)
                    End If
                End If
            Loop
Final:
            .Close()
        End With
        RsCta = Nothing
        Exit Sub
CTAMALA:
        trArbol.Nodes.Add("B" & Trim(RsCta.Item("CTA_CODIGO").Value), RsCta.Item("CTA_CODIGO").Value & "  " & RsCta.Item("CTA_NOMBRE").Value, 4)
        Resume Next
    End Sub

    Private Sub CargaTipoCta()
        trArbol.ShowRootLines = True
        With trArbol.Nodes
            .Clear()
            .Add("M1", "Ctas. de Activo", 1)
            .Add("M2", "Ctas. de Pasivo", 1)
            .Add("M3", "Ctas. de Patrimonio", 1)
            .Add("M4", "Ctas. de Resultados", 1)
            .Add("M5", "Ctas. de Orden", 1)
        End With
    End Sub
    Private Sub Toolbar1_ButtonClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles nueva.Click, insertar.Click, modificar.Click, eliminar.Click, listado.Click, salir.Click
        Dim Button As System.Windows.Forms.ToolStripItem = CType(eventSender, System.Windows.Forms.ToolStripItem)
        Select Case Button.Name
            Case "nueva"
                CuentaNueva_Click()
            Case "insertar"
                InsertarCuenta_Click()
            Case "modificar"
                ModificarCuenta_Click()
            Case "eliminar"
                EliminarCuenta_Click()
            Case "listado"
                Command2_Click()
            Case "salir"

                Me.Close()
        End Select
    End Sub
    Private Sub Salida()
        DattCom.SqlDatos.ejecutarComando("Adc_CtaForma " & DattCom.datosEmpresa.Emp_codigo, datosEmpresa.strConxAdcom)
    End Sub

    Private Sub PonerDatosRapidos()
        Dim Qcodigo As String
        Dim Ctaaux As New Cuenta
        On Error Resume Next
        Qcodigo = Mid(trArbol.SelectedNode.Name, 2)
        Ctaaux.Cargar((Qcodigo))
        If Ctaaux.codigo = "" Then Exit Sub
        With Ctaaux
            NivAct = .Nivel
            CtaAct = .codigo
            GrupAct = CShort(.Grupo)
            Toolbar1.Items.Item("insertar").Enabled = IIf(.Agrupacion = True, True, False)
            Toolbar1.Items.Item("nueva").Enabled = True
            Toolbar1.Items.Item("modificar").Enabled = True
            Toolbar1.Items.Item("eliminar").Enabled = True
        End With
        Ctaaux = Nothing
    End Sub

    Private Sub EstaEnDefinicion()
        Dim Qcodigo As String
        On Error Resume Next

        If trArbol.SelectedNode Is Nothing Then
            Qcodigo = "1"
        Else
            Qcodigo = Mid(trArbol.SelectedNode.Name, 2)
        End If
        If Qcodigo = "" Then Qcodigo = "1"
        Toolbar1.Items.Item("insertar").Enabled = True
        Toolbar1.Items.Item("nueva").Enabled = False
        Toolbar1.Items.Item("modificar").Enabled = False
        Toolbar1.Items.Item("eliminar").Enabled = False
        NivAct = 0
        CtaAct = ""
        GrupAct = CShort(Qcodigo)
    End Sub

    Private Function PuntosCta(ByRef Cuenta As String, ByRef Nivel As Short) As String
        Dim i, Lim As Short
        Dim Aux As String

        Aux = Mid(Cuenta, 1, Val(Mid(emp.CtaNumDigNivel, 1, 1)))
        For i = 1 To Nivel - 1
            If i > 2 Then Aux = Aux & "."
            Lim = Lim + Val(Mid(emp.CtaNumDigNivel, i, 1))
            Aux = Aux & Mid(Cuenta, Lim + 1, Val(Mid(emp.CtaNumDigNivel, i + 1, 1)))
        Next i
        PuntosCta = Aux
    End Function

    Private Function SiElimina(ByRef Cuenta As String) As Boolean
        If trArbol.Nodes.Item(trArbol.SelectedNode.Name).GetNodeCount(False) > 0 Then SiElimina = False : MsgBox("No se puede eliminar cuenta con auxiliares", MsgBoxStyle.Critical, "eliminar cuenta contable " & Cuenta) : Exit Function
        SiElimina = CtaUsada(Cuenta)
    End Function
    Private Function CtaUsada(ByRef cta As String) As Boolean
        Dim rstemp As SqlDataReader
        Dim cod As String
        cod = " select top 1 cta_codigo from AdcDia WHERE Cta_Codigo = '" & cta & "'"
        rstemp = DattCom.SqlDatos.leerBase(cod, datosEmpresa.strConxAdcom)
        If rstemp.Read Then
            MsgBox("Imposible borrar esta Cuenta, esta registrada en otros documentos", MsgBoxStyle.Critical, "Eliminar cuenta contable " & cta)
            CtaUsada = False
        Else
            CtaUsada = True
        End If
        rstemp.Close()
        rstemp = Nothing
    End Function

    Private Sub trArbol_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trArbol.AfterSelect
        Dim Node As System.Windows.Forms.TreeNode = e.Node
        Select Case Mid(trArbol.SelectedNode.Name, 1, 1)
            Case "C", "B"
                PonerDatosRapidos()
            Case "M"
                EstaEnDefinicion()
        End Select
    End Sub

    Private Sub Validar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Validar.Click
        Dim prog As New CtbValida
        Dim Sstr As String

        Sstr = ""

        Sstr = Sstr & " select cta1.Cta_codigo,'ERROR: La cuenta de Mayor no existe' as mensaje from adccta cta1"
        Sstr = Sstr & " left join adccta cta2"
        Sstr = Sstr & " on substring(cta1.cta_codigo,1,len(cta2.cta_codigo)) = cta2 .cta_codigo"
        Sstr = Sstr & " and cta1.Cta_Nivel = cta2.cta_nivel +1"
        Sstr = Sstr & " Where cta1.Cta_Nivel > 1 And IsNull(cta2.Cta_Nivel, 9) = 9"

        Sstr = Sstr & " union All"

        Sstr = Sstr & " select cta1.Cta_codigo,'ERROR: La cuenta de Agrupación ' + cta2.cta_codigo + ' - ' + cta2.Cta_nombre  + ' está definida como de movimiento'  as mensaje from adccta cta1"
        Sstr = Sstr & " left join adccta cta2"
        Sstr = Sstr & " on substring(cta1.cta_codigo,1,len(cta2.cta_codigo)) = cta2 .cta_codigo"
        Sstr = Sstr & " and cta1.Cta_Nivel = cta2.cta_nivel +1"
        Sstr = Sstr & " where cta1.Cta_Nivel > 1 and isnull(cta2.cta_agrupacion,0)=0 and isnull(cta2.Cta_codigo,'') > ''"

        Dim con As New SqlConnection
        Dim datS As New DataTable
        Dim datA As New SqlDataAdapter(Sstr, con)
        datA.Fill(datS)
        prog.Malla.DataSource = datS
        con.Close()
        prog.ShowDialog()
        prog.Dispose()
    End Sub

    Private Sub CTBP01_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Salida()
    End Sub
End Class