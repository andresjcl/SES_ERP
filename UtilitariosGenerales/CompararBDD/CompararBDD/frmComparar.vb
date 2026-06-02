Imports System.Data.SqlClient
Imports System.Data

Public Class frmComparar
    Dim conectar As New SqlConnection()
    Dim SYSEMP As New AdcDax.DaxsofSys
    Dim Emp As AdcDax.Empresa
    Dim tablas() As String
    Dim campos(1000, 1000) As String
    Dim numTablas As Long = 0
    Dim numcampos As Long = 0
    Dim tablasDiferentes As Integer = 0
    Dim soloCompara As Boolean = False
    Dim ComparandoTablas As String
    Dim crearDato As Boolean = False
    Dim laLib As New DaxLib.DaxLibBases
#Region "Inicialización"

    Private Sub frmComparar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conexionbddAdcom()
        llenarCombos(cboBdd1)
        llenarCombos(cboBdd2)
    End Sub
    Public Sub conexionbddAdcom()
        Emp = SYSEMP.EmpresaAct
        Dim coneccion As New DaxLib.DaxLibBases
        coneccion.TipoBase = "10"
        conectar.ConnectionString = coneccion.StrAdcom
    End Sub
    Private Sub llenarCombos(ByVal cbo As ComboBox)
        Dim ssql As String = "SELECT Name FROM sys.databases"
        Dim datS As New DataSet()
        Dim datA As New SqlDataAdapter(ssql, conectar)
        If conectar.State = ConnectionState.Closed Then conectar.Open()
        datA.Fill(datS, "Datos")
        cbo.DataSource = datS.Tables("Datos")
        cbo.DisplayMember = "Name"
        cbo.ValueMember = "Name"
        conectar.Close()
    End Sub

#End Region

#Region "Comparar Tablas"
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ComparandoTablas = "tablas"
        dgvMalla.DataSource = Nothing
        dgvMalla.Rows.Clear()
        compararTablas()
        ' If numTablas > 0 Then CrearTablas()
    End Sub

    Private Sub compararTablas()
        ''cambiaron error Resume Next
        Try
            If conectar.State = ConnectionState.Closed Then conectar.Open()
            Dim i As Integer = 0
            Dim ssql As String = "select TABLE_NAME from " & cboBdd1.SelectedValue.ToString & ".information_schema.TABLES  where table_type = 'BASE TABLE' AND TABLE_NAME not in( "
            ssql += " select  TABLE_NAME from " & cboBdd2.SelectedValue.ToString & ".information_schema.TABLES  where table_type = 'BASE TABLE') ORDER by TABLE_NAME "
            Dim cmd As New SqlDataAdapter(ssql, conectar)
            Dim dat As New DataTable
            cmd.Fill(dat)

            If dat.Rows.Count > 0 Then
                dgvMalla.DataSource = dat
                dgvMalla.Columns(0).HeaderText = "Tabla inexistente"
                dgvMalla.RowHeadersWidth = 45
                ReDim tablas(dat.Rows.Count)
                conectar.Close()
            End If
        Catch ee As Exception
            MsgBox("excepción: " & ee.Message)
        End Try

    End Sub
    Private Sub CrearTablas()
        'cambiaron error Resume Next
        Me.UseWaitCursor = True
        Me.Cursor = Cursors.WaitCursor
        crearDato = False
        Try
            Dim tabla As String = ""
            For i = 0 To dgvMalla.Rows.Count - 1
                If dgvMalla.Rows(i).HeaderCell.Value = "X" Then
                    creaUnaTabla(dgvMalla.Rows(i).Cells(0).Value.ToString)
                End If
            Next
            Me.UseWaitCursor = False
            Me.Cursor = Cursors.Default
            MsgBox("Proceso Terminado !!", MsgBoxStyle.Information)
            limpiarMalla()
        Catch ee As Exception
            MsgBox("excepción: " & ee.Message)
        End Try

    End Sub
    Private Sub creaUnaTabla(ByVal tabla As String)
        Try
            If conectar.State = ConnectionState.Closed Then conectar.Open()
            Dim ssql As String = "select * into " & cboBdd2.SelectedValue.ToString & ".dbo." & tabla & " from " & cboBdd1.SelectedValue.ToString & ".dbo." & tabla
            Dim cmd As New SqlCommand(ssql, conectar)
            cmd.ExecuteNonQuery()
            conectar.Close()
        Catch ee As Exception
            If crearDato = False Then MsgBox("excepción: " & ee.Message)
        End Try
    End Sub
#End Region

#Region "Comparar Campos"
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        CompararCampos()
    End Sub

    Private Sub CompararCampos()
        'cambiaron error Resume Next
        Try
            Dim i As Long = 0
            Dim ssql As String = "select table_name as tabla,column_name as NombreColumna, data_Type as TipoDato,isnull(character_maximum_length,0) as longitud,isnull(NUMERIC_PRECISION,0) as nroEnteros,isnull(NUMERIC_SCALE,0) as nroDecimales "
            ssql &= " from " & cboBdd1.SelectedValue.ToString & ".information_schema.columns "
            ssql &= " where COLUMN_NAME not in"
            ssql &= "( select  COLUMN_NAME from " & cboBdd2.SelectedValue.ToString & ".information_schema.columns )"
            ssql &= " and table_name in ( select TABLE_NAME from " & cboBdd1.SelectedValue.ToString & ".information_schema.TABLES  where table_type = 'BASE TABLE' ) "
            Dim cmd As New SqlDataAdapter(ssql, conectar)
            Dim dat As New DataTable
            If conectar.State = ConnectionState.Closed Then conectar.Open()
            ComparandoTablas = "campos"
            cmd.Fill(dat)
            dgvMalla.DataSource = dat
            conectar.Close()
        Catch ee As Exception
            MsgBox("excepción: " & ee.Message)
        End Try

    End Sub

    Private Sub CrearCampos()
        Try
            'Dim ddlb As New DaxLib.DaxLibDigDato
            Dim tabla As String
            'Dim campo As String
            Dim nombreDato As String
            Dim tipo As String
            Dim tamaño As Integer
            Dim enteros As Integer
            Dim decimales As Integer
            Dim op As Integer = 3
            Dim camposAdic As String = ""
            Dim i As Integer
            If conectar.State = ConnectionState.Closed Then conectar.Open()
            Dim cmd As New SqlCommand
            crearDato = True
            For i = 0 To dgvMalla.Rows.Count - 1
                If dgvMalla.Rows(i).HeaderCell.Value = "X" Then
                    tabla = Trim(cboBdd2.SelectedValue.ToString) & ".dbo." & dgvMalla.Rows(i).Cells("tabla").Value.ToString
                    nombreDato = dgvMalla.Rows(i).Cells("NombreColumna").Value.ToString
                    tipo = dgvMalla.Rows(i).Cells("TipoDato").Value.ToString
                    tamaño = CInt(dgvMalla.Rows(i).Cells("longitud").Value.ToString)
                    enteros = CInt(dgvMalla.Rows(i).Cells("nroEnteros").Value.ToString)
                    decimales = CInt(dgvMalla.Rows(i).Cells("nroDecimales").Value.ToString)

                    creaUnaTabla(dgvMalla.Rows(i).Cells(0).Value.ToString)

                    Dim ssql As String = "IF NOT EXISTS (SELECT col.name FROM sysobjects obj, syscolumns col WHERE obj.id = col.id and obj.name='" & tabla & "' and col.name='" & nombreDato & "'"
                    ssql &= " BEGIN "
                    ssql &= " ALTER TABLE " & tabla & " Add [" & nombreDato & "] [" & tipo & "]"
                    If tamaño > 0 Then
                        ssql &= "(" & tamaño.ToString() & ")"
                    ElseIf tipo = "numeric" Then
                        ssql &= "(" & enteros.ToString() & "," & decimales.ToString() & ")"
                    End If
                    ssql &= " null"
                    ssql &= " End "

                    cmd = New SqlCommand(ssql, conectar)
                    cmd.ExecuteNonQuery()
                End If
            Next
        Catch ee As Exception
            MsgBox("excepción: " & ee.Message)
        End Try

        limpiarMalla()
    End Sub
#End Region


    Private Sub cboBdd1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBdd1.SelectedIndexChanged
        dgvMalla.DataSource = Nothing
        dgvMalla.RowCount = 0
    End Sub

    Private Sub cboBdd2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBdd2.SelectedIndexChanged
        dgvMalla.DataSource = Nothing
        dgvMalla.RowCount = 0
    End Sub


    Private Sub dgvMalla_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvMalla.DoubleClick
        If dgvMalla.Rows(dgvMalla.CurrentCell.RowIndex).HeaderCell.Value = "" Then
            dgvMalla.Rows(dgvMalla.CurrentCell.RowIndex).HeaderCell.Value = "X"
        Else
            dgvMalla.Rows(dgvMalla.CurrentCell.RowIndex).HeaderCell.Value = ""
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        MarcarMalla("X")
    End Sub
    Private Sub MarcarMalla(ByVal marca As String)
        Dim i As Integer
        For i = 0 To dgvMalla.RowCount - 1
            dgvMalla.Rows(i).HeaderCell.Value = marca
        Next
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        MarcarMalla("")
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If ComparandoTablas = "tablas" Then
            If dgvMalla.RowCount > 0 Then
                If MsgBox("Desea Crear las tablas faltantes en la base de datos a cambiar?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then CrearTablas()
            End If
        ElseIf ComparandoTablas = "campos" Then
            If dgvMalla.RowCount > 0 Then
                If MsgBox("Desea Crear los campos faltantes en la base de datos a cambiar?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then CrearCampos()
            End If
        End If
    End Sub
    Private Sub limpiarMalla()
        dgvMalla.DataSource = Nothing
        dgvMalla.RowCount = 0
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        ' tablas principales que contienen claves primarias para otras tablas

        Dim TablasPrincipales As String

        dgvMalla.ColumnCount = 4
        dgvMalla.RowCount = 0
        dgvMalla.Columns(0).HeaderText = "TablaOriginal"
        dgvMalla.Columns(1).HeaderText = "TablaComprobar"
        dgvMalla.Columns(2).HeaderText = "RegistrosCopiados"
        dgvMalla.Columns(3).HeaderText = "Error "

        TablasPrincipales = "'AdcDoc','Identificacion','AdcArt','AdcCta','AdcAcf','AdcDocPro'"

        copiarDatos("AdcDoc")
        copiarDatos("Identificacion")
        copiarDatos("AdcArt")
        copiarDatos("AdcCta")
        copiarDatos("AdcAcf")
        copiarDatos("AdcDocPro")

        If conectar.State = ConnectionState.Closed Then conectar.Open()
        Dim dat As New DataTable
        Dim tablasOriginal As String = "select * from " & cboBdd2.SelectedValue.ToString & ".information_schema.TABLES where table_type = 'BASE TABLE' and table_name not in (" & TablasPrincipales & ") order by table_name "
        Dim cmd As New SqlDataAdapter(tablasOriginal, conectar)

        cmd.Fill(dat)

        If dat.Rows.Count > 0 Then
            For i As Integer = 1 To dat.Rows.Count - 1
                copiarDatos(dat.Rows(i).Item("table_name").ToString())
            Next
        End If

        Label3.Text = ""
    End Sub

    Private Sub copiarDatos(Tabla As String)
        Label3.Text = "Procesando tabla: " & Tabla
        My.Application.DoEvents()
        dgvMalla.Rows.Add(1)
        dgvMalla.Rows(dgvMalla.RowCount - 1).Cells(1).Value = Tabla

        If existeTabla(cboBdd2.SelectedValue.ToString, Tabla) = False Then dgvMalla.Rows(dgvMalla.RowCount - 1).Cells(3).Value = "No existe la tabla en la base de datos original" : Return
        dgvMalla.Rows(dgvMalla.RowCount - 1).Cells(0).Value = Tabla
        If BorrarDatos(cboBdd1.SelectedValue.ToString, Tabla) = False Then Return

        Dim tablaOriginal As New DataTable
        Dim cmd2 As New SqlCommand()
        Dim tabla2 As SqlDataReader
        Dim colOriginal As String
        Dim i As Integer
        Dim coma As String = ","
        Dim stringCopiar As String = "INSERT INTO [" & cboBdd1.SelectedValue.ToString & "].[dbo].[" & Tabla & "] ("
        Dim strSelect As String = " Select "
        Dim columnasOriginal As String = "select column_name,data_type, character_maximum_length,numeric_precision,numeric_scale from "
        Dim ident As String = ""
        columnasOriginal += cboBdd1.SelectedValue.ToString & ".information_schema.columns where table_name = '" & Tabla & "'"

        Dim cmd As New SqlDataAdapter(columnasOriginal, conectar)

        cmd.Fill(tablaOriginal)
        If conectar.State = ConnectionState.Closed Then conectar.Open()
        coma = ""
        For i = 0 To tablaOriginal.Rows.Count - 1
            colOriginal = tablaOriginal.Rows(i).Item("column_name").ToString()
            Dim colSecundaria As String = "select column_name from "
            colSecundaria += cboBdd2.SelectedValue.ToString & ".information_schema.columns where table_name = '" & Tabla & "'"
            colSecundaria += " and column_name = '" & colOriginal & "'"
            cmd2 = New SqlCommand(colSecundaria, conectar)
            tabla2 = cmd2.ExecuteReader()
            If tabla2.Read() Then
                If tabla2.Item("column_name").ToString.Length <> 0 Then
                    stringCopiar += coma & "[" & colOriginal & "]"
                    strSelect += coma & "[" & colOriginal & "]"
                    coma = ","
                End If
            End If
            tabla2.Close()
        Next i

        stringCopiar += ") "
        strSelect += " from " & cboBdd2.SelectedValue.ToString & ".[dbo].[" & Tabla & "]"
        cmd2.Dispose()
        conectar.Close()
        My.Application.DoEvents()

        Try
            If coma = "," Then
                conectar.Open()
                Dim comm As New SqlCommand()

                If tieneIdentificacion(Tabla) Then
                    ident = "SET IDENTITY_INSERT " & cboBdd1.SelectedValue.ToString & ".dbo.[" & Tabla & "] ON; "
                    comm = New SqlCommand(ident, conectar)
                    comm.ExecuteNonQuery()
                    'comm.Dispose()
                End If

                Label3.Text = "Procesando tabla: " & Tabla & "..copiando..."
                My.Application.DoEvents()

                comm = New SqlCommand(stringCopiar & " " & strSelect, conectar)
                Dim rec As Integer = comm.ExecuteNonQuery()
                'comm.Dispose()
                dgvMalla.Rows(dgvMalla.RowCount - 1).Cells(2).Value = rec.ToString
                My.Application.DoEvents()

                If tieneIdentificacion(Tabla) Then
                    ident = "SET IDENTITY_INSERT " & cboBdd1.SelectedValue.ToString & ".dbo.[" & Tabla & "] OFF; "
                    comm = New SqlCommand(ident, conectar)
                    comm.ExecuteNonQuery()
                    'comm.Dispose()
                End If
            End If
        Catch ee As Exception
            'MsgBox("Excepción controlada en tabla " & Tabla & vbCr & ee.Message)
            dgvMalla.Rows(dgvMalla.RowCount - 1).Cells(3).Value = ee.Message
            My.Application.DoEvents()
        End Try
    End Sub

    Private Sub copiarDatosRegistroARegistro(tabla As String)

        Label3.Text = "Procesando tabla: " & tabla
        My.Application.DoEvents()
        dgvMalla.Rows.Add(1)
        dgvMalla.Rows(dgvMalla.RowCount - 1).Cells(1).Value = Tabla

        If existeTabla(cboBdd2.SelectedValue.ToString, Tabla) = False Then dgvMalla.Rows(dgvMalla.RowCount - 1).Cells(3).Value = "No existe la tabla en la base de datos original" : Return
        dgvMalla.Rows(dgvMalla.RowCount - 1).Cells(0).Value = Tabla
        If BorrarDatos(cboBdd1.SelectedValue.ToString, Tabla) = False Then Return

        Dim tablaOriginal As New DataTable
        Dim cmd2 As New SqlCommand()
        Dim tabla2 As SqlDataReader
        Dim colOriginal As String
        Dim i As Integer
        Dim coma As String = ","
        Dim stringCopiar As String = "INSERT INTO [" & cboBdd1.SelectedValue.ToString & "].[dbo].[" & Tabla & "] ("
        Dim strSelect As String = " Select "
        Dim columnasOriginal As String = "select column_name,data_type, character_maximum_length,numeric_precision,numeric_scale from "
        Dim ident As String = ""
        columnasOriginal += cboBdd1.SelectedValue.ToString & ".information_schema.columns where table_name = '" & Tabla & "'"

        Dim cmd As New SqlDataAdapter(columnasOriginal, conectar)

        cmd.Fill(tablaOriginal)
        If conectar.State = ConnectionState.Closed Then conectar.Open()
        coma = ""
        For i = 0 To tablaOriginal.Rows.Count - 1
            colOriginal = tablaOriginal.Rows(i).Item("column_name").ToString()
            Dim colSecundaria As String = "select column_name from "
            colSecundaria += cboBdd2.SelectedValue.ToString & ".information_schema.columns where table_name = '" & Tabla & "'"
            colSecundaria += " and column_name = '" & colOriginal & "'"
            cmd2 = New SqlCommand(colSecundaria, conectar)
            tabla2 = cmd2.ExecuteReader()
            If tabla2.Read() Then
                If tabla2.Item("column_name").ToString.Length <> 0 Then
                    stringCopiar += coma & "[" & colOriginal & "]"
                    strSelect += coma & "[" & colOriginal & "]"
                    coma = ","
                End If
            End If
            tabla2.Close()
        Next i

        stringCopiar += ") "
        strSelect += " from " & cboBdd2.SelectedValue.ToString & ".[dbo].[" & Tabla & "]"
        cmd2.Dispose()
        conectar.Close()
        My.Application.DoEvents()

        Try
            If coma = "," Then
                conectar.Open()
                Dim comm As New SqlCommand()

                If tieneIdentificacion(Tabla) Then
                    ident = "SET IDENTITY_INSERT " & cboBdd1.SelectedValue.ToString & ".dbo.[" & Tabla & "] ON; "
                    comm = New SqlCommand(ident, conectar)
                    comm.ExecuteNonQuery()
                    'comm.Dispose()
                End If

                Label3.Text = "Procesando tabla: " & Tabla & "..copiando..."
                My.Application.DoEvents()

                comm = New SqlCommand(stringCopiar & " " & strSelect, conectar)
                Dim rec As Integer = comm.ExecuteNonQuery()
                'comm.Dispose()
                dgvMalla.Rows(dgvMalla.RowCount - 1).Cells(2).Value = rec.ToString
                My.Application.DoEvents()

                If tieneIdentificacion(Tabla) Then
                    ident = "SET IDENTITY_INSERT " & cboBdd1.SelectedValue.ToString & ".dbo.[" & Tabla & "] OFF; "
                    comm = New SqlCommand(ident, conectar)
                    comm.ExecuteNonQuery()
                    'comm.Dispose()
                End If
            End If
        Catch ee As Exception
            'MsgBox("Excepción controlada en tabla " & Tabla & vbCr & ee.Message)
            dgvMalla.Rows(dgvMalla.RowCount - 1).Cells(3).Value = ee.Message
            My.Application.DoEvents()
        End Try
    End Sub

    Private Function tieneIdentificacion(tabla As String) As Boolean
        If conectar.State = ConnectionState.Closed Then conectar.Open()
        Dim tabla2 As SqlDataReader
        Dim comm As New SqlCommand("SELECT IDENT_CURRENT ('[" & cboBdd1.SelectedValue.ToString & "].[dbo].[" & tabla & "]') AS ultId ", conectar)
        Dim tiene As Boolean = True

        Try
            tabla2 = comm.ExecuteReader
            If tabla2.Read Then
                If IsDBNull(tabla2("ultId")) Then tiene = False
            Else
                tiene = False
            End If
        Catch ex As Exception
            tiene = False
        End Try
        tabla2.Close()
        comm.Dispose()
        Return tiene
    End Function

    Private Function BorrarDatos(Base As String, Tabla As String) As Boolean
        Try
            If conectar.State = ConnectionState.Closed Then conectar.Open()
            Dim ssql As String = "delete from " & Base & ".dbo." & Tabla
            Dim cmd As New SqlCommand(ssql, conectar)
            cmd.ExecuteNonQuery()
            conectar.Close()
        Catch ee As Exception
            dgvMalla.Rows(dgvMalla.RowCount - 1).Cells(3).Value = ee.Message
            Return False
        End Try
        Return True
    End Function
    Private Function existeTabla(base As String, tabla As String) As Boolean
        Dim strTabla As String = "select * from " & cboBdd1.SelectedValue.ToString & ".information_schema.TABLES where table_name = '" & tabla & "'"
        Dim existe As Boolean = False

        If conectar.State = ConnectionState.Closed Then conectar.Open()

        Dim cmd2 As New SqlCommand(strTabla, conectar)
        Dim tabla2 As SqlDataReader
        tabla2 = cmd2.ExecuteReader()
        If tabla2.Read Then existe = True
        tabla2.Close()
        cmd2.Dispose()
        conectar.Close()
        Return existe
    End Function
End Class
