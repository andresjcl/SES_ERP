Imports System.Data.SqlClient
Imports DattCom

Public Class FrmAgrp
    Dim nivel As Int32 = 0
    Dim dest As String = "I"
    Dim cod As String = ""
    Dim Nomb As String = ""
    Dim etiqueta As String = ""

#Region "Datos Iniciales"
    Private Sub FrmAgrp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        etiqueta = "Servicios"
        LblNivel.Text = " " & IIf(nivel = 1, "CATEGORIA:", IIf(nivel = 2, "CLASE:", IIf(nivel = 3, "GRUPO:", "SUBGRUPO:"))).ToString() & " "
        lblCodigo.Text = " " & cod & " "
        lblNombre.Text = " " & Nomb & " "
        llenarMalla(nivel, dest, cod, False)
    End Sub
    Private Sub btnNoAgrupados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNoAgrupados.Click
        limpiar()
        If btnNoAgrupados.Text = "No Agrupados" Then
            llenarMalla(nivel, dest, cod, True)
            btnNoAgrupados.Text = "Todos "
            btnNoAgrupados.ToolTipText = "Todos los " & etiqueta
        Else
            llenarMalla(nivel, dest, cod, False)
            btnNoAgrupados.Text = "No Agrupados"
            btnNoAgrupados.ToolTipText = "Solo " & etiqueta & " no Agrupados"
        End If
    End Sub
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Dispose()
    End Sub
#End Region

#Region "Malla"
    Private Sub limpiar()
        With Malla
            .DataSource = Nothing
        End With
    End Sub
    Private Sub llenarMalla(ByVal niv As Int32, ByVal d As String, ByVal codigo As String, ByVal sinGrup As Boolean)
        Dim cont As Integer = 0
        Dim ssql As String = ""
        Dim campo As String = ""
        Dim cmd As New SqlCommand()
        Dim dat As SqlDataReader = Nothing
        Select Case niv
            Case 2
                campo = "Sev_clase"
            Case 3
                campo = "Sev_grupo"
                'Case 4
                '    campo = "Sev_subgrup"
            Case Else
                campo = "Sev_categoria"
        End Select
        ssql = "SELECT sev_codigo as Codigo, sev_nombre as Nombre"
        ssql += "," & campo & " as NivCod, AdcNivServ.Niv_nombre "
        ssql += " FROM AdcServ LEFT OUTER JOIN  AdcNivServ"
        ssql += " ON " & campo & " = AdcNivServ.Niv_abrevia"
        If sinGrup = True Then ssql += " where (" & campo & " ='' OR " & campo & " = '" + codigo + "'"
        'ssql += " order by sev_codigo "
        Dim datS As New DataTable
        Dim datA As New SqlDataAdapter(ssql, datosEmpresa.strConxAdcom)
        datA.Fill(datS)
        Malla.DataSource = datS
        With Malla
            .ClearSelection()
            .Columns(2).Visible = False
        End With
        datA.Dispose()
    End Sub
#End Region

#Region "Agrupar"
    Private Sub btnAgrupar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgrupar.Click
        Dim cmp As String = ""
        cmp = IIf(dest = "I", IIf(nivel = 1, "Sev_categorIA", IIf(nivel = 2, "Sev_clase", IIf(nivel = 3, "Sev_grupo", "Sev_subgrup"))), IIf(nivel = 1, "Categoria", IIf(nivel = 2, "Clase", IIf(nivel = 3, "Grupo", "Subgrupo")))).ToString()
        If Malla.SelectedRows.Count > 0 Then
            If MsgBox("Confirma cambiar de categoria a los " & etiqueta & " seleccionados, estos serán registrados en " & Nomb, MsgBoxStyle.YesNo) = vbYes Then
                Agrupar("AdcServ", cmp, cod, "Sev_Codigo")
                limpiar()
                llenarMalla(nivel, dest, cod, False)
            End If
        Else
            MsgBox("Es necesario que primero seleccion los " & etiqueta & " que desea agrupar", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub Agrupar(ByVal tabla As String, ByVal campoNiv As String, ByVal codig As String, ByVal campoCod As String)
        Dim ssql As String = ""
        Dim cods As String = ""
        Dim fil As Integer = 0
        Dim conectar As New SqlConnection(datosEmpresa.strConxAdcom)
        conectar.Open()
        With Malla
            For i = 0 To .SelectedRows.Count - 1
                If cods = "" Then cods = "'" & .SelectedRows(i).Cells(0).Value.ToString() & "'" Else cods += ",'" & .SelectedRows(i).Cells(0).Value.ToString() & "'"
            Next
            ssql = "update " & tabla & " set " & campoNiv & "='" & codig & "'  where " & campoCod & " in(" & cods & ")"
            Dim cmd As New SqlCommand(ssql, conectar)
            cmd.ExecuteNonQuery()
            conectar.Close()
            conectar.Dispose()
            cmd.Dispose()
        End With
    End Sub
#End Region

    Public Sub AgruparArt(ByVal nivelC As Int32, ByVal destino As String, ByVal codCate As String, ByVal nombre As String)
        nivel = nivelC
        dest = destino
        cod = codCate
        Nomb = nombre
        Me.ShowDialog()
    End Sub
End Class