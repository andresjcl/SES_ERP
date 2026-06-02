Imports System.Data.SqlClient
Imports SysEmpDatt

Public Class FrmNivAcf
    Dim img As String = ""
    Dim fila, col As Integer
    Dim op As Integer = 0
    Dim d As String = "I"
    Dim tabla As String = ""
    Dim CodCateg As String = ""
    Dim NomCat As String = ""
    Dim etiqueta As String = ""
    Dim esActivo As Boolean = False

#Region "Datos Iniciales"
    Public Sub FrmNivAcf(Activo As Boolean)
        esActivo = Activo
        Show()
    End Sub
    Private Sub FrmNiveles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If esActivo Then
            Me.Text = "ADMINISTRAR AGRUPACIÓN DE ACTIVOS FIJOS" : tabla = "AdcnivAcf"
            etiqueta = "Activos"
        Else
            Me.Text = "ADMINISTRAR AGRUPACIÓN DE ARTÍCULOS DE INVENTARIO" : tabla = "AdcNiv"
            etiqueta = "Artículos"
        End If
        'conectarBDD()
        '        FormatoMalla()
        cboNivel.SelectedIndex = 0
        btnGuardar.Enabled = False
    End Sub
    Private Sub cboNivel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNivel.SelectedIndexChanged
        Opciones()
    End Sub
    Private Sub Opciones()
        limpiarMalla()
        If cboNivel.SelectedItem.ToString() = "CATEGORIA" Then
            op = 1
        ElseIf cboNivel.SelectedItem.ToString() = "CLASE" Then
            op = 2
        ElseIf cboNivel.SelectedItem.ToString() = "GRUPO" Then
            op = 3
        Else
            op = 4
        End If
        llenarMalla(op, d)
    End Sub
    Private Sub Imagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Imagen.Click
        Dim miStream As IO.Stream = Nothing
        Dim Archivo As String = ""
        Dim Path As String = ""
        OpenFileDialog1.Filter = "JPG(*.jpg)|*.jpg|PNG(*.png)|*.png|GIF(*.gif)|*.gif|Todos(*.Jpg, *.Png, *.Gif, *.Tiff, *.Jpeg, *.Bmp)|*.Jpg; *.Png; *.Gif; *.Tiff; *.Jpeg; *.Bmp"
        OpenFileDialog1.FilterIndex = 4
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            miStream = OpenFileDialog1.OpenFile()
            If (miStream IsNot Nothing) Then
                Archivo = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
                Path = System.IO.Path.GetDirectoryName(OpenFileDialog1.FileName)
                img = Path & "\" & Archivo
                If Archivo <> "" Then
                    malla.Rows(fila).Cells("Niv_Grafico").Value = img
                    Imagen.Image = Image.FromFile(img)
                End If
            End If
        End If
    End Sub

    Private Sub optAcf_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        limpiarMalla()
        Opciones()
    End Sub
    Private Sub optInv_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        limpiarMalla()
        Opciones()
    End Sub

#End Region

#Region "Malla"
    Private Sub FormatoMalla()
        With malla
            .Columns("Niv_Abrevia").HeaderText = "Abreviación"
            .Columns("Niv_Nombre").HeaderText = "Descripción"
            .Columns("Niv_IdCta").HeaderText = "Id.Contable-1"
            .Columns("Niv_IdCta2").HeaderText = "Id.Contable-2"
            .Columns("Niv_IdCta3").HeaderText = "Id.Contable-3"

            .Columns("Niv_Grafico").Visible = False

            If esActivo Then
                .Columns("Nandina").Visible = False
                .Columns("HTS").Visible = False
            End If

            .Columns("Niv_IdCta").DefaultCellStyle.Format = "0"
            .Columns("Niv_IdCta2").DefaultCellStyle.Format = "0"
            .Columns("Niv_IdCta3").DefaultCellStyle.Format = "0"
        End With
    End Sub
    Private Sub limpiarMalla()
        With malla
            '        .Rows.Clear()
        End With
    End Sub
    Private Sub llenarMalla(ByVal nivel As Integer, ByVal dest As String)

        Dim ssql As String = "select Niv_abrevia,Niv_nombre,Niv_IdCta,Niv_Idcta2,Niv_Idcta3,Nandina,HTS,niv_grafico  from " & tabla & " where Niv_categor =" & nivel
        'Dim conectar As New SqlConnection(datosEmpresa.strConxAdcom)
        'conectar.Open()
        Dim cmd As New SqlDataAdapter(ssql, datosEmpresa.strConxAdcom)
        Dim dat As New DataTable()
        Dim cont As Integer = 0
        malla.Columns.Clear()
        cmd.Fill(dat)
        malla.DataSource = dat
        FormatoMalla()
        'With malla
        '    While dat.Read
        '        .Rows.Add()
        '        If Not IsDBNull(dat("Niv_abrevia")) Then .Rows(cont).Cells("Niv_Abrevia").Value = dat("Niv_abrevia")
        '        If Not IsDBNull(dat("Niv_nombre")) Then .Rows(cont).Cells("Niv_Nombre").Value = dat("Niv_nombre")
        '        If Not IsDBNull(dat("Niv_IdCta")) Then .Rows(cont).Cells("Niv_IdCta").Value = dat("Niv_IdCta")
        '        If Not IsDBNull(dat("Niv_Idcta2")) Then .Rows(cont).Cells("Niv_IdCta2").Value = dat("Niv_Idcta2")
        '        If Not IsDBNull(dat("Niv_Idcta3")) Then .Rows(cont).Cells("Niv_IdCta3").Value = dat("Niv_Idcta3")
        '        If Not IsDBNull(dat("niv_grafico")) Then .Rows(cont).Cells("Niv_Grafico").Value = dat("niv_grafico")
        '        If Not IsDBNull(dat("Nandina")) Then .Rows(cont).Cells("Nandina").Value = dat("Nandina")
        '        If Not IsDBNull(dat("HTS")) Then .Rows(cont).Cells("HTS").Value = dat("HTS")
        '        cont += 1
        '    End While
        '    .ClearSelection()
        'End With
        'conectar.Close()
    End Sub

    Private Sub malla_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles malla.CellEndEdit
        If col = 0 Then
            If VerificarExistencia(malla.Rows(fila).Cells("Niv_Abrevia").Value.ToString()) = True Then MsgBox("La abreviación ingresada ya existe", MsgBoxStyle.Information) : malla.Rows(fila).Cells("Niv_Abrevia").Value = "" : malla.Rows.RemoveAt(malla.RowCount - 2) : malla.ClearSelection()
        End If
    End Sub
    Private Function VerificarExistencia(ByVal cod As String) As Boolean
        Dim bandera As Boolean = False
        With malla
            For i = 0 To .RowCount - 2
                If i <> fila And cod <> "" Then
                    If .Rows(i).Cells("Niv_Abrevia").Value.ToString.ToUpper = cod.ToUpper Then bandera = True
                End If
            Next
        End With
        Return bandera
    End Function
    Private Sub malla_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles malla.CellEnter
        On Error Resume Next
        Dim LaImagen As String
        fila = e.RowIndex
        col = e.ColumnIndex
        LaImagen = Trim(malla.Rows(fila).Cells("Niv_Grafico").Value.ToString())
        Imagen.Image = Nothing
        If LaImagen > "" Then If Dir(LaImagen) > "" Then Imagen.Image = Image.FromFile(LaImagen)
        CodCateg = malla.Rows(fila).Cells("Niv_Abrevia").Value.ToString() : NomCat = malla.Rows(fila).Cells("Niv_Nombre").Value.ToString()
    End Sub

    Private Sub malla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles malla.KeyDown
        If e.KeyCode = Keys.Delete Then
            If malla.SelectedCells.Count = 0 Then Exit Sub
            Dim tb As String = ""
            Dim cmp As String = ""
            tb = IIf(d = "I", "AdcArt", "AdcAcf").ToString()
            Select Case op
                Case 1
                    cmp = "Art_categor"
                Case 2
                    cmp = "Art_clase"
                Case 3
                    cmp = "Art_grupo"
                Case 4
                    cmp = "Art_subgrup"
            End Select
            If PuedoEliminar(tb, cmp, CodCateg) = False Then
                If MsgBox("Existen " & etiqueta & " con " & IIf(op = 1 Or op = 2, "esta ", "este ").ToString() & cboNivel.Text.ToLower & ". Desea continuar?", MsgBoxStyle.YesNo) = vbYes Then EliminarFila(tb, cmp, op.ToString(), CodCateg, d)
            Else
                If MsgBox("Confima que desea eliminar el registro? ", MsgBoxStyle.Question, MsgBoxStyle.YesNo) = vbYes Then
                    EliminarFila(tb, cmp, op.ToString(), CodCateg, d)
                End If
            End If
            limpiarMalla()
            llenarMalla(op, d)
        ElseIf e.KeyCode = Keys.F2 And col <> 0 And col <> 1 Then
            CargaCta()
        ElseIf e.KeyCode = Keys.F3 Then
            If fila > 0 And col <> 0 Then malla.Rows(fila).Cells(col).Value = malla.Rows(fila - 1).Cells(col).Value
        End If
    End Sub
    Private Sub CargaCta()
        Dim ctacte As String = ""
        Dim cta As New MantCtb.BuscaCta
        ctacte = cta.BuscaCtaCtb("", "I")
        If ctacte <> "" Then malla.Rows(fila).Cells(col).Value = ctacte
    End Sub

#Region "Validacion de Caracteres"
    Private Sub ValidaNro_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' debe definirse un formato, en definir stilo de las columnas, SOLO para las columnas que deban aceptar números

        Dim FormatoColumna As String = malla.Columns(malla.CurrentCell.ColumnIndex).DefaultCellStyle.Format.ToString
        If FormatoColumna = "" Then Exit Sub

        Select Case e.KeyChar.ToString()
            Case "0" To "9", vbBack
                e.Handled = False
            Case "."
                If FormatoColumna.Contains(".") Or Val(Mid(FormatoColumna, 2, 1)) > 0 Then
                    e.Handled = CType(sender, TextBox).Text.Contains(".")   ' verifica si ya tiene un punto decimal
                Else
                    e.Handled = True
                End If
            Case Else
                e.Handled = True
        End Select
    End Sub
    Private Sub malla_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles malla.EditingControlShowing
        'Dim ValidarNro As TextBox = e.Control
        'malla = malla
        'RemoveHandler ValidarNro.KeyPress, AddressOf ValidaNro_KeyPress
        'AddHandler ValidarNro.KeyPress, AddressOf ValidaNro_KeyPress
    End Sub
#End Region

#End Region

#Region "Guardar"
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        malla.EndEdit()
        Guardar()
    End Sub
    'Destino--> I--- Inventario
    '           A--- Activos Fijos
    Private Sub Guardar()
        eliminar()
        Dim niv As New Niveles
        Dim regrabaNandina As Boolean = False
        niv.Niv_Categoria = op.ToString()
        niv.Tabla = tabla

        With malla
            For i = 0 To .RowCount - 2
                niv.Niv_abrevia = .Rows(i).Cells("Niv_Abrevia").Value.ToString()
                niv.Niv_nombre = .Rows(i).Cells("Niv_Nombre").Value.ToString()
                niv.Niv_IdCta = .Rows(i).Cells("Niv_IdCta").Value.ToString()
                niv.Niv_IdCta2 = .Rows(i).Cells("Niv_IdCta2").Value.ToString()
                niv.Niv_IdCta3 = .Rows(i).Cells("Niv_IdCta3").Value.ToString()
                niv.Niv_Grafico = .Rows(i).Cells("Niv_Grafico").Value.ToString()
                niv.Nandina = .Rows(i).Cells("Nandina").Value.ToString()
                niv.HTS = .Rows(i).Cells("HTS").Value.ToString()
                If niv.HTS > "" Or niv.Nandina > "" Then regrabaNandina = True
                niv.guardar()
            Next
        End With
        If regrabaNandina = True Then actualizaNandinaHts(op)
        btnGuardar.Enabled = False
    End Sub

    Private Sub eliminar()
        Dim elim As New Niveles
        elim.Tabla = tabla
        elim.eliminar(op.ToString(), "", d)
    End Sub
#End Region

#Region "Salir"
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Dispose()
    End Sub
#End Region

#Region "Agrupar"
    Private Sub btnAgrupar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgrupar.Click
        If malla.SelectedCells.Count <= 0 Then Exit Sub
        Dim agrp As New FrmAgrp()
        agrp.AgruparArt(op, d, CodCateg, NomCat)
    End Sub
#End Region

#Region "Eliminar"

    Private Function PuedoEliminar(ByVal tabla As String, ByVal campo As String, ByVal cod As String) As Boolean
        Dim ban As Boolean = True
        Dim ssql As String = "select * from " & tabla & " where " & campo & "='" & cod & "'"
        Dim conectar As New SqlConnection(datosEmpresa.strConxAdcom)
        conectar.Open()
        Dim cmd As New SqlCommand(ssql, conectar)
        Dim dat As SqlDataReader = Nothing
        conectar.Open()
        dat = cmd.ExecuteReader()
        If dat.Read Then
            If IsDBNull(dat("Niv_Abrevia")) Then ban = True Else ban = False
        Else
            ban = True
        End If
        conectar.Close()
        Return ban
    End Function
    Private Sub EliminarFila(ByVal tab As String, ByVal cmp As String, ByVal niv As String, ByVal cod As String, ByVal destino As String)
        Dim ssql As String = "Delete from " & tabla & " where Niv_categor=" & niv & " and Niv_abrevia='" & cod & "' "
        Dim conectar As New SqlConnection(datosEmpresa.strConxAdcom)
        conectar.Open()
        Dim cmd As New SqlCommand(ssql, conectar)
        conectar.Open()
        cmd.ExecuteNonQuery()
        conectar.Close()
        ElimCatArt(tab, cmp, cod)
        MsgBox("Proceso Realizado con Exito", MsgBoxStyle.Information)
    End Sub
    Private Sub ElimCatArt(ByVal tabla As String, ByVal campo As String, ByVal cod As String)
        Dim ssql As String = "update " & tabla & " set " & campo & "='' where " & campo & " = '" & cod & "' "
        Dim conectar As New SqlConnection(datosEmpresa.strConxAdcom)
        conectar.Open()
        Dim cmd As New SqlCommand(ssql, conectar)
        conectar.Open()
        cmd.ExecuteNonQuery()
        conectar.Close()
    End Sub
#End Region

#Region "Imprimir"
    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        imprimir()
    End Sub
    Private Sub imprimir()
        Dim ssql As String = ""
        If d = "I" Then ssql = "select * from adcNiv" Else ssql = "select * from adcnivAcf"
        Dim imp As New FrmImpr()
        imp.Imprimir(ssql, "Reporte de Niveles de " & etiqueta, "E")
    End Sub
#End Region

    Private Sub malla_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles malla.KeyPress
        If e.KeyChar = Chr(Keys.Delete) Then MsgBox("")
    End Sub

    Private Sub malla_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles malla.RowsAdded
        btnGuardar.Enabled = True
    End Sub

    Private Sub malla_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles malla.CellValueChanged
        btnGuardar.Enabled = True
    End Sub

    Private Sub malla_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles malla.CellLeave
        malla.EndEdit()
    End Sub
End Class
