Option Strict Off
Option Explicit On
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports DattCom

Public Class CTBP01
    Inherits System.Windows.Forms.Form

    Dim NivAct, GrupAct As Integer
    Dim CtaAct As String

    ' ✅ CONFIGURACIÓN DE DÍGITOS POR NIVEL
    Private digitosPorNivel As List(Of Integer) = New List(Of Integer) From {1, 2, 2, 2, 2}

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

    'Private Sub ModificarCuenta_Click()
    '    Dim prog As New CTBP01_1
    '    prog.CrearCuenta(CtaAct, NivAct, GrupAct, "M", trArbol)
    '    prog = Nothing
    '    PonerDatosRapidos()
    '    trArbol.Refresh()
    'End Sub

    Private Sub ModificarCuenta_Click()
        Try
            ' ✅ VERIFICAR QUE HAYA UN NODO SELECCIONADO
            If trArbol.SelectedNode Is Nothing Then
                MsgBox("Primero debe seleccionar una cuenta para modificar", MsgBoxStyle.Exclamation, "Modificar Cuenta")
                Exit Sub
            End If

            ' ✅ OBTENER EL NOMBRE DEL NODO SELECCIONADO
            Dim nodeName As String = trArbol.SelectedNode.Name
            Dim nodeText As String = trArbol.SelectedNode.Text

            ' ✅ DEBUG: Mostrar en ventana de salida
            System.Diagnostics.Debug.WriteLine("=== MODIFICAR CUENTA ===")
            System.Diagnostics.Debug.WriteLine($"Node.Name: {nodeName}")
            System.Diagnostics.Debug.WriteLine($"Node.Text: {nodeText}")

            ' ✅ VERIFICAR QUE SEA UNA CUENTA (NO UN GRUPO)
            If Not nodeName.StartsWith("C") Then
                MsgBox("Debe seleccionar una cuenta, no un grupo", MsgBoxStyle.Exclamation, "Modificar Cuenta")
                Exit Sub
            End If

            ' ✅ OBTENER EL CÓDIGO DE LA CUENTA (eliminar la "C" del inicio)
            Dim codigoCuenta As String = Mid(nodeName, 2)

            If String.IsNullOrEmpty(codigoCuenta) Then
                MsgBox("No se pudo obtener el código de la cuenta", MsgBoxStyle.Exclamation, "Modificar Cuenta")
                Exit Sub
            End If

            System.Diagnostics.Debug.WriteLine($"Código de cuenta: {codigoCuenta}")

            ' ✅ CARGAR LA CUENTA PARA OBTENER NIVEL Y GRUPO
            Dim Ctaaux As New Cuenta
            Ctaaux.Cargar(codigoCuenta)

            If Ctaaux.codigo = "" Then
                MsgBox($"No se encontró la cuenta: {codigoCuenta}", MsgBoxStyle.Exclamation, "Modificar Cuenta")
                Ctaaux = Nothing
                Exit Sub
            End If

            ' ✅ GUARDAR DATOS EN LAS VARIABLES GLOBALES
            CtaAct = codigoCuenta
            NivAct = Ctaaux.Nivel
            GrupAct = CShort(Ctaaux.Grupo)

            System.Diagnostics.Debug.WriteLine($"Nivel: {NivAct}, Grupo: {GrupAct}")

            Ctaaux = Nothing

            ' ✅ ABRIR EL FORMULARIO DE MODIFICACIÓN
            Dim prog As New CTBP01_1
            prog.CrearCuenta(CtaAct, NivAct, GrupAct, "M", trArbol)
            prog = Nothing

            ' ✅ REFRESCAR EL ÁRBOL
            PonerDatosRapidos()
            trArbol.Refresh()

            System.Diagnostics.Debug.WriteLine("=== ModificarCuenta_Click COMPLETADO ===")

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine($"ERROR en ModificarCuenta_Click: {ex.ToString()}")
            MsgBox($"Error al modificar cuenta: {ex.Message}", MsgBoxStyle.Critical, "Error")
        End Try
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
        CargarDigitosPorNivel()
        CargaCtas()
        EstaEnDefinicion()
    End Sub

    ' ✅ OBTENER DÍGITOS POR NIVEL DESDE EMPRESA
    Private Sub CargarDigitosPorNivel()
        Try
            Dim digitos As String = ""
            Using conn As New SqlConnection(datosEmpresa.strConIniSis)
                Dim cmd As New SqlCommand("SELECT DefCta_NumDigNivel FROM emp_par WHERE Emp_Codigo = @codigo", conn)
                cmd.Parameters.AddWithValue("@codigo", datosEmpresa.Emp_codigo)
                conn.Open()
                Dim resultado As Object = cmd.ExecuteScalar()
                If resultado IsNot Nothing Then
                    digitos = resultado.ToString()
                End If
            End Using

            If Not String.IsNullOrEmpty(digitos) Then
                digitosPorNivel.Clear()
                For Each c As Char In digitos
                    Dim num As Integer = 0
                    If Integer.TryParse(c.ToString(), num) Then
                        digitosPorNivel.Add(num)
                    End If
                Next
            End If
        Catch ex As Exception
            ' Usar valores por defecto si falla
            digitosPorNivel = New List(Of Integer) From {1, 2, 2, 2, 2}
        End Try
    End Sub

    ' ✅ CARGAR CUENTAS CORRECTAMENTE
    Private Sub CargaCtas()
        Dim RsCta As SqlDataReader
        Dim Aux As String
        Dim Indice As Short

        trArbol.Nodes.Clear()
        CargaTipoCta()
        Indice = 0

        ' ✅ INCLUIR TODOS LOS CAMPOS NECESARIOS
        Aux = "SELECT Cta_codigo, Cta_nombre, Cta_grupo, Cta_Nivel, Cta_agrupacion, CuentaPadre, Cniv1, Cniv2, Cniv3, Cniv4 FROM AdcCta ORDER BY Cta_codigo"

        RsCta = DattCom.SqlDatos.leerBase(Aux, datosEmpresa.strConxAdcom)
        Indice = 0
        Dim CtaNivel As Integer = 1
        Dim ctaCodigo As String

        With RsCta
            Do Until RsCta.Read = False
                Indice = Indice + 1
                If Not IsDBNull(.Item("Cta_Nivel")) Then
                    CtaNivel = .Item("Cta_Nivel")
                End If
                If CtaNivel = 0 Then CtaNivel = 1

                ctaCodigo = .Item("CTA_CODIGO").ToString()

                ' ✅ DETERMINAR EL PADRE
                Dim cuentaPadre As String = ""

                ' PRIMERO: Intentar usar CuentaPadre
                If Not IsDBNull(.Item("CuentaPadre")) Then
                    cuentaPadre = .Item("CuentaPadre").ToString()
                End If

                ' SEGUNDO: Si no tiene CuentaPadre, calcular usando Cniv
                If String.IsNullOrEmpty(cuentaPadre) AndAlso CtaNivel > 1 Then
                    cuentaPadre = ObtenerPadreDesdeCniv(ctaCodigo, CtaNivel)
                End If

                ' TERCERO: Si aún no tiene padre, usar el método tradicional
                If String.IsNullOrEmpty(cuentaPadre) Then
                    cuentaPadre = QuePadreDeCta(ctaCodigo, CtaNivel)
                End If

                ' ✅ AGREGAR AL ÁRBOL
                If String.IsNullOrEmpty(cuentaPadre) Then
                    ' Cuenta de nivel 1 - agregar directamente al grupo
                    Dim grupo As String = ""
                    If Not IsDBNull(.Item("cta_grupo")) Then
                        grupo = .Item("cta_grupo").ToString()
                    End If

                    If String.IsNullOrEmpty(grupo) Then
                        grupo = ObtenerGrupoDesdeCodigo(ctaCodigo)
                    End If

                    Dim nodosPadre As TreeNode() = trArbol.Nodes.Find("M" & Trim(grupo), True)
                    If nodosPadre IsNot Nothing AndAlso nodosPadre.Length > 0 Then
                        Dim esAgrupacion As Boolean = False
                        If Not IsDBNull(.Item("cta_agrupacion")) Then
                            esAgrupacion = CBool(.Item("cta_agrupacion"))
                        End If

                        Dim imgIndex As Integer = IIf(esAgrupacion, 2, 4)
                        nodosPadre(0).Nodes.Add("C" & Trim(ctaCodigo), ctaCodigo & "  " & .Item("CTA_NOMBRE"), imgIndex, imgIndex + 1)
                    End If
                Else
                    ' Buscar el nodo padre en el árbol
                    Dim nodosPadre As TreeNode() = trArbol.Nodes.Find("C" & cuentaPadre, True)
                    If nodosPadre IsNot Nothing AndAlso nodosPadre.Length > 0 Then
                        Dim esAgrupacion As Boolean = False
                        If Not IsDBNull(.Item("cta_agrupacion")) Then
                            esAgrupacion = CBool(.Item("cta_agrupacion"))
                        End If

                        Dim imgIndex As Integer = IIf(esAgrupacion, 2, 4)
                        nodosPadre(0).Nodes.Add("C" & Trim(ctaCodigo), ctaCodigo & "  " & .Item("CTA_NOMBRE"), imgIndex, imgIndex + 1)
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

    ' ✅ OBTENER PADRE DESDE Cniv
    Private Function ObtenerPadreDesdeCniv(ByVal codigo As String, ByVal nivel As Integer) As String
        If nivel <= 1 Then Return ""

        ' Obtener el código del nivel anterior usando Cniv
        Select Case nivel
            Case 2
                Return codigo.Substring(0, digitosPorNivel(0))
            Case 3
                Return codigo.Substring(0, digitosPorNivel(0) + digitosPorNivel(1))
            Case 4
                Return codigo.Substring(0, digitosPorNivel(0) + digitosPorNivel(1) + digitosPorNivel(2))
            Case 5
                Return codigo.Substring(0, digitosPorNivel(0) + digitosPorNivel(1) + digitosPorNivel(2) + digitosPorNivel(3))
            Case Else
                Return ""
        End Select
    End Function

    ' ✅ OBTENER GRUPO DESDE CÓDIGO
    Private Function ObtenerGrupoDesdeCodigo(ByVal codigo As String) As String
        If String.IsNullOrEmpty(codigo) Then Return "0"

        Dim primerDigito As String = codigo.Substring(0, 1)

        Select Case primerDigito
            Case "1"
                Return "1"  ' Activo
            Case "2"
                Return "2"  ' Pasivo
            Case "3"
                Return "3"  ' Patrimonio
            Case "4"
                Return "4"  ' Resultados (Ingresos)
            Case "5"
                Return "5"  ' Resultados (Egresos)
            Case "6"
                Return "6"  ' Orden
            Case Else
                Return "0"
        End Select
    End Function

    ' ✅ MÉTODO QuePadreDeCta MEJORADO
    Private Function QuePadreDeCta(ByVal ctaCodigo As String, ByVal nivel As Integer) As String
        If nivel <= 1 Then Return ""

        ' Calcular la longitud del padre
        Dim longitudPadre As Integer = 0
        For i As Integer = 0 To nivel - 2
            If i < digitosPorNivel.Count Then
                longitudPadre += digitosPorNivel(i)
            Else
                longitudPadre += 2 ' Valor por defecto
            End If
        Next

        If longitudPadre <= 0 OrElse longitudPadre >= ctaCodigo.Length Then Return ""

        ' Retornar los primeros N caracteres del código
        Return ctaCodigo.Substring(0, longitudPadre)
    End Function

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

    'Private Sub PonerDatosRapidos()
    '    Dim Qcodigo As String
    '    Dim Ctaaux As New Cuenta
    '    On Error Resume Next
    '    Qcodigo = Mid(trArbol.SelectedNode.Name, 2)
    '    Ctaaux.Cargar((Qcodigo))
    '    If Ctaaux.codigo = "" Then Exit Sub
    '    With Ctaaux
    '        NivAct = .Nivel
    '        CtaAct = .codigo
    '        GrupAct = CShort(.Grupo)
    '        Toolbar1.Items.Item("insertar").Enabled = IIf(.Agrupacion = True, True, False)
    '        Toolbar1.Items.Item("nueva").Enabled = True
    '        Toolbar1.Items.Item("modificar").Enabled = True
    '        Toolbar1.Items.Item("eliminar").Enabled = True
    '    End With
    '    Ctaaux = Nothing
    'End Sub

    Private Sub PonerDatosRapidos()
        Dim Qcodigo As String
        Dim Ctaaux As New Cuenta

        On Error Resume Next

        If trArbol.SelectedNode Is Nothing Then
            EstaEnDefinicion()
            Exit Sub
        End If

        Qcodigo = Mid(trArbol.SelectedNode.Name, 2)

        If String.IsNullOrEmpty(Qcodigo) Then
            EstaEnDefinicion()
            Exit Sub
        End If

        Ctaaux.Cargar(Qcodigo)

        If Ctaaux.codigo = "" Then
            EstaEnDefinicion()
            Exit Sub
        End If

        With Ctaaux
            NivAct = .Nivel          ' ← SE GUARDA EL NIVEL
            CtaAct = .codigo         ' ← SE GUARDA EL CÓDIGO
            GrupAct = CShort(.Grupo) ' ← SE GUARDA EL GRUPO

            ' ✅ DEBUG
            System.Diagnostics.Debug.WriteLine($"Cuenta cargada: { .codigo}, Nivel: { .Nivel}, Grupo: { .Grupo}")

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
        If trArbol.Nodes.Item(trArbol.SelectedNode.Name).GetNodeCount(False) > 0 Then
            SiElimina = False
            MsgBox("No se puede eliminar cuenta con auxiliares", MsgBoxStyle.Critical, "eliminar cuenta contable " & Cuenta)
            Exit Function
        End If
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

    'Private Sub trArbol_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trArbol.AfterSelect
    '    Dim Node As System.Windows.Forms.TreeNode = e.Node
    '    Select Case Mid(trArbol.SelectedNode.Name, 1, 1)
    '        Case "C", "B"
    '            PonerDatosRapidos()
    '        Case "M"
    '            EstaEnDefinicion()
    '    End Select
    'End Sub

    Private Sub trArbol_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles trArbol.AfterSelect
        Dim Node As System.Windows.Forms.TreeNode = e.Node

        ' ✅ VERIFICAR QUE EL NODO EXISTA
        If Node Is Nothing Then
            EstaEnDefinicion()
            Exit Sub
        End If

        Dim nodeName As String = Node.Name
        If String.IsNullOrEmpty(nodeName) Then
            EstaEnDefinicion()
            Exit Sub
        End If

        Select Case Mid(nodeName, 1, 1)
            Case "C", "B"
                PonerDatosRapidos()
            Case "M"
                EstaEnDefinicion()
            Case Else
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