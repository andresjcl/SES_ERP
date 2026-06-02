Option Strict Off
Option Explicit On
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports DattCom
Public Class frmCapacitacion    
    Public NombreEmpleado As String
    Public CodigoEmpleado As String
    'Public LosParientes As ColParientes
    Dim Datobak As String
    Dim ColBak As Integer
    Dim LinBak As Integer
    Dim fila, columna, colAnt As Integer
    Dim codPais, codInstr As String

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If ValidaMalla() = False Then MsgBox("Los datos ingresado están errados" & vbCr & "Los campos mínimos de datos son: País,Institución y especialización") : Return
        GuardarMallaColeccion()
        Me.Close()
    End Sub
    Private Function ValidaMalla() As Boolean
        If malla.RowCount < 1 Then Return False
        With malla
            For i = 0 To .RowCount - 2
                If .Rows(i).Cells("Pais").Value Is Nothing Or .Rows(i).Cells("Institucion").Value Is Nothing Or .Rows(i).Cells("Especializacion").Value Is Nothing Then Return False
            Next i
        End With
        Return True
    End Function
    Public Sub Capacitacion(ByVal cod As String, ByVal nombre As String)
        NombreEmpleado = nombre
        CodigoEmpleado = cod
        Me.ShowDialog()
    End Sub

    Private Sub frmCapacitacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim prog As New DaxLib.DaxLibMalla
        'prog = Nothing
        malla.Columns(0).ReadOnly = True
        LabEmpleado.Text = NombreEmpleado
        CargarColeccionMalla()
    End Sub
    Private Sub CargarColeccionMalla()
        Dim Conectar As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
        Dim i = 0, cont As Integer = 0
        On Error GoTo HayError
        Dim CodRs As String
        Dim VF As Boolean = False
        CodRs = "Select CodEmpleado,Pais,Institucion,Titulo,Especialización,NivelEstudio,Retirado,EnCurso,Graduado,FechaFinal,CursosCarrera,CursosAprobados " & _
               " from ADCcAPpER where CodEmpleado='" & CodigoEmpleado & "'"
        LabEmpleado.Text = NombreEmpleado
        Dim cmd As New SqlCommand(CodRs, Conectar)
        Dim dat As SqlDataReader
        Conectar.Open()
        dat = cmd.ExecuteReader()
        While dat.Read

            With malla
                .Rows.Add()
                .Rows(i).Cells("Pais").Value = dat("Pais")
                .Rows(i).Cells("Institucion").Value = dat("Institucion")
                .Rows(i).Cells("Titulo").Value = dat("Titulo")
                .Rows(i).Cells("Especializacion").Value = dat("Especialización")
                .Rows(i).Cells("NivelEstudio").Value = dat("NivelEstudio")
                If dat("Retirado") = 1 Then .Rows(i).Cells("Retirado").Value = True
                If dat("EnCurso") = 1 Then .Rows(i).Cells("EnCurso").Value = True
                If dat("Graduado") = 1 Then .Rows(i).Cells("Graduado").Value = True
                .Rows(i).Cells("FechaFinal").Value = FormatDateTime(dat("FechaFinal"), DateFormat.ShortDate)
                .Rows(i).Cells("CursosCarrera").Value = dat("CursosCarrera")
                .Rows(i).Cells("CursosAprobados").Value = dat("CursosAprobados")
                i = i + 1
            End With
        End While
        Conectar.Close()
        Conectar.Dispose()
        Exit Sub
HayError:
        MsgBox(Err.Description)
    End Sub

    Private Sub GuardarMallaColeccion()
        Dim Conectar As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
        Dim ssql As String = "delete from adcCapPer where CodEmpleado='" & CodigoEmpleado & "'"
        Dim cmd As New SqlCommand(ssql, Conectar)
        Conectar.Open() : cmd.ExecuteNonQuery()
        Dim Pais, NivelEstudio, Institucion, Titulo, Especializacion, CursosCarrera, CursosAprobados As String
        Dim Retirado, EnCurso, Graduado As Integer
        Dim FechaFinal As Date
        With malla
            For i = 0 To .RowCount - 2
                Pais = .Rows(i).Cells("Pais").Value
                NivelEstudio = .Rows(i).Cells("NivelEstudio").Value
                Institucion = .Rows(i).Cells("Institucion").Value
                Titulo = .Rows(i).Cells("Titulo").Value
                Especializacion = .Rows(i).Cells("Especializacion").Value
                If (.Rows(i).Cells("Retirado").Value) = True Then Retirado = 1 Else Retirado = 0
                If (.Rows(i).Cells("EnCurso").Value) = True Then EnCurso = 1 Else EnCurso = 0
                If (.Rows(i).Cells("Graduado").Value) = True Then Graduado = 1 Else Graduado = 0
                FechaFinal = FormatDateTime(.Rows(i).Cells("FechaFinal").Value, DateFormat.ShortDate)
                CursosCarrera = .Rows(i).Cells("CursosCarrera").Value
                CursosAprobados = .Rows(i).Cells("CursosAprobados").Value

                ssql = "insert into adcCapPer (CodEmpleado,Pais,NivelEstudio,Institucion,Titulo,Especialización,Retirado,EnCurso,Graduado,"
                ssql += "FechaFinal,CursosCarrera,CursosAprobados) values('" & CodigoEmpleado & "',"
                ssql += "'" & Pais & "',"
                ssql += "'" & NivelEstudio & "',"
                ssql += "'" & Institucion & "',"
                ssql += "'" & Titulo & "',"
                ssql += "'" & Especializacion & "',"
                ssql += " " & Retirado & ","
                ssql += " " & EnCurso & ","
                ssql += " " & Graduado & ","
                ssql += "'" & FechaFinal & "',"
                ssql += "'" & CursosCarrera & "',"
                ssql += "'" & CursosAprobados & "')"

                cmd = New SqlCommand(ssql, Conectar)
                cmd.ExecuteNonQuery()
            Next
            Conectar.Close()
            Conectar.Dispose()
        End With
    End Sub

    Private Sub malla_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles malla.CellEndEdit
        With malla
            If columna = 5 Then
                If .Rows(fila).Cells(5).Value = True Then .Rows(fila).Cells(6).Value = False : .Rows(fila).Cells(7).Value = False
                colAnt = 5
            ElseIf columna = 6 Then
                If .Rows(fila).Cells(6).Value Then .Rows(fila).Cells(5).Value = False : .Rows(fila).Cells(7).Value = False
                colAnt = 6
            ElseIf columna = 7 Then
                If .Rows(fila).Cells(7).Value Then .Rows(fila).Cells(6).Value = False : .Rows(fila).Cells(5).Value = False
                colAnt = 7
            End If
            If columna = 4 And colAnt = 5 Then
                If .Rows(fila).Cells(5).Value = True Then .Rows(fila).Cells(6).Value = False : .Rows(fila).Cells(7).Value = False
            ElseIf columna = 8 And colAnt = 7 Then
                If .Rows(fila).Cells(7).Value = True Then .Rows(fila).Cells(6).Value = False : .Rows(fila).Cells(5).Value = False
            End If
        End With
    End Sub

    Private Sub malla_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles malla.CellEnter
        fila = e.RowIndex
        columna = e.ColumnIndex
    End Sub

    Private Sub Buscador(ByVal indice As Integer, ByVal tiporef As String)
        Dim ElNombre As String = ""
        Dim ElCodigo As String = ""
        Dim Buscod As New Syscod.ManSysnetClass
        ElCodigo = Buscod.BuscarReferencia(tiporef, ElCodigo, ElNombre)
        If indice = 0 Then codPais = ElCodigo Else codInstr = ElCodigo
        ElCodigo = ""
        malla.Rows(fila).Cells(columna).Value = ElNombre
    End Sub

    Private Sub malla_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles malla.KeyDown
        If e.KeyCode = Keys.F2 Then
            If columna = 0 Or columna = 1 Then
                If columna = 0 Then Buscador(0, "Paises") Else Buscador(1, "Instruccion")
            End If
        End If
    End Sub

    Private Sub Malla_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles malla.EditingControlShowing
        Dim ValidarNro As TextBox = e.Control
        RemoveHandler ValidarNro.KeyPress, AddressOf ValidaNro_KeyPress
        AddHandler ValidarNro.KeyPress, AddressOf ValidaNro_KeyPress
    End Sub

    Private Sub ValidaNro_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' debe definirse un formato, en definir stilo de las columnas, SOLO para las columnas que deban aceptar números

        'Dim FormatoColumna As String = malla.Columns(malla.CurrentCell.ColumnIndex).DefaultCellStyle.Format.ToString
        'If FormatoColumna = "" Then Exit Sub       
        Dim nombre As String = malla.Columns(malla.CurrentCell.ColumnIndex).Name
        If nombre <> "CursosAprobados" And nombre <> "CursosCarrera" Then Exit Sub
        Select Case e.KeyChar
            Case "0" To "9", vbBack
                e.Handled = False
                'Case "."
                '    If FormatoColumna.Contains(".") Or Val(Mid(FormatoColumna, 2, 1)) > 0 Then
                '        e.Handled = CType(sender, TextBox).Text.Contains(".")   ' verifica si ya tiene un punto decimal
                '    Else
                '        e.Handled = True
                '    End If
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class