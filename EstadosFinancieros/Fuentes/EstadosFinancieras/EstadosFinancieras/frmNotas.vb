Imports System.Data.SqlClient
Public Class frmNotas
    Dim conectar As New SqlConnection()
    Dim notaNum As Integer = 0
    Dim codigo = 0, cambios = 0, guardar As Integer = 0
    Dim cta, descripcion, fecha, fecha1, nombreMes, numeroMes, mes, mes1 As String
    Private checkPrint As Integer
    '****************************************CARGAR LA FORMA *********************************************************
    Private Sub frmNotas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim coneccion As New DaxLib.DaxLibBases
        On Error Resume Next

        coneccion.TipoBase = "10"
        conectar.ConnectionString = coneccion.StrAdcom
        If notaNum = 0 Then
            NumeroNota()
            If cta = 0 Then ConsultaCta()
            Me.Text = "Nueva Nota No. " & codigo & " - Cuenta: " & cta
            Nombre(fecha.Substring(3, 2))
            mes = numeroMes
            txtDelMes.Text = nombreMes
            Nombre(fecha1.Substring(3, 2))
            mes1 = numeroMes
            txtAlMes.Text = nombreMes
            txtAño.Text = "del " & Year(fecha)
        Else
            codigo = notaNum
            consultarFecha()
            Me.Text = "Nota No. " & notaNum & " - Cuenta: " & cta
            CargarNota()
            cambios = 0
            btnEliminar.Enabled = True
        End If
        If mes = mes1 Then
            txtAlMes.Visible = False
            lblA.Visible = False
        End If
    End Sub
    Private Sub ConsultaCta()
        Dim ssql As String = "Select "

    End Sub
    Private Sub consultarFecha()
        Dim ssql As String = "Select Nota_Mes,nota_cta from AdcNote where Nota_Codigo=" & notaNum & "and Nota_Origen='BAL_SIT'"
        Dim cmd As New SqlCommand(ssql, conectar)
        Dim dat As SqlDataReader
        conectar.Open()
        dat = cmd.ExecuteReader()
        If dat.Read Then
            Nombre(dat(0).ToString.Substring(0, 2))
            mes = numeroMes
            txtDelMes.Text = nombreMes
            Nombre(dat(0).ToString.Substring(3, 2))
            mes1 = numeroMes
            txtAlMes.Text = nombreMes
            txtAño.Text = "del " & Year(fecha)
            If Not IsDBNull(dat(1)) Then cta = dat(1)
        Else
            MsgBox("La nota " & notaNum & " no está creada", MsgBoxStyle.Information)
            Me.Dispose()
        End If
        conectar.Close()
    End Sub
    Private Sub CargarNota()
        Dim ssql As String = "Select Nota_Descripcion from AdcNote where Nota_Codigo=" & notaNum
        Dim cmd As New SqlCommand(ssql, conectar)
        Dim dat As SqlDataReader
        Dim Nota As String = ""
        conectar.Open()
        dat = cmd.ExecuteReader()
        If dat.Read Then
            Nota = dat(0)
            Nota = Replace(Nota, "ª", "'")
            txtNota.Rtf = Nota
        End If
        conectar.Close()
        conectar.Dispose()
    End Sub
    Private Sub NumeroNota()
        If notaNum = 0 Then
            Dim ssql As String = "select max(Nota_Codigo) from adcNote"
            Dim cmd As New SqlCommand(ssql, conectar)
            Dim dat As SqlDataReader
            conectar.Open()
            dat = cmd.ExecuteReader()
            If dat.Read Then
                If IsDBNull(dat(0)) Then
                    codigo = 1
                Else
                    codigo = dat(0) + 1
                End If
            Else
                codigo = 1
            End If
            conectar.Close()
        End If
    End Sub
    '*****************************************BOTÓN SALIR************************************************************
    Private Sub bntSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntSalir.Click
        Dim confirmar As Integer
        If cambios > 0 Then
            confirmar = MsgBox("Desea guardar los cambios?", MsgBoxStyle.YesNoCancel)
            If confirmar = vbYes Then
                If notaNum = 0 Then
                    guardarActualizar("I", 0)
                Else
                    guardarActualizar("U", notaNum)
                End If
                cambios = 0
                btnGuardar.Enabled = False
                Me.Dispose()
            ElseIf confirmar = vbNo Then
                Me.Dispose()
            End If
        Else
            Me.Dispose()
        End If
    End Sub

    Private Sub txtNota_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNota.TextChanged
        cambios += 1
        btnGuardar.Enabled = True
    End Sub

    '************************************************BOTÓN GUARDAR *******************************************************
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
            If notaNum = 0 Then
            guardarActualizar("I", 0)
            Else
            guardarActualizar("U", notaNum)
        End If
        If guardar = 0 Then Exit Sub
            cambios = 0
        btnGuardar.Enabled = False
        Me.Dispose()
    End Sub
    Private Sub guardarActualizar(ByVal opc As String, ByVal cod As Integer)
        Dim ssql As String = ""
        Dim Nota As String
        Dim mesIng As String = ""

        If CInt(mes) <= fecha.Substring(3, 2) Or CInt(mes1) >= fecha1.Substring(3, 2) Then
            mesIng = Trim(mes) & "-" & Trim(mes1)
            guardar = 1
        Else
            MsgBox("El periodo ingresado no es válido")
            guardar = 0
            txtDelMes.Focus()
            txtDelMes.SelectAll()
            Exit Sub
        End If
        Nota = txtNota.Rtf
        Nota = Replace(Nota, "'", "ª")
        If opc = "I" Then
            ssql = "insert into AdcNote (Nota_Codigo,Nota_Cta,Nota_Descripcion,Nota_Mes,Nota_Año,Nota_Origen)"
            ssql += " values(" & codigo & ",'" & cta & "','" & Nota & "','" & mesIng & "','" & Year(fecha) & "','BAL_SIT')"
        ElseIf opc = "U" Then
            ssql = "update AdcNote set Nota_Descripcion='" & Nota & "' where Nota_Codigo =" & cod
        End If
        Dim cmd As New SqlCommand(ssql, conectar)
        If conectar.State <> ConnectionState.Closed Then
            conectar.Close()
        End If
        conectar.Open()
        cmd.ExecuteNonQuery()
        conectar.Close()
        txtNota.Text = ""
    End Sub
    '**************************************BOTÓN ELIMINAR****************************************************************
    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim confirmar As Integer
        confirmar = MsgBox("Esta seguro que desea eliminar la nota?", MsgBoxStyle.YesNo)
        If confirmar = vbYes Then
            Eliminar(notaNum)
        End If
    End Sub
    Private Sub Eliminar(ByVal cod As Integer)
        Dim ssql As String
        ssql = "delete from AdcNote where Nota_Codigo =" & cod
        Dim cmd As New SqlCommand(ssql, conectar)
        If conectar.State <> ConnectionState.Closed Then
            conectar.Close()
        End If
        conectar.Open()
        cmd.ExecuteNonQuery()
        conectar.Close()
        txtNota.Text = ""
        txtNumNota.Text = ""
        Me.Dispose()
    End Sub
    '*********************************************************************************************************************
    '*********************************************************************************************************************
    Public Sub MostrarNotasBalance(ByVal cod As Integer, ByVal cta1 As String, ByVal fec As String, ByVal fec1 As String)
        notaNum = cod
        Me.cta = cta1
        fecha = fec
        fecha1 = fec1
        Me.ShowDialog()
    End Sub
    Private Sub btnIzq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIzq.Click
        With txtNota
            .SelectionAlignment = LeftRightAlignment.Left
        End With
    End Sub
    Private Sub btnDerecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDerecha.Click
        With txtNota
            .SelectionAlignment = LeftRightAlignment.Right
        End With
    End Sub

    Private Sub btnCentrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCentrar.Click
        With txtNota
            .SelectionAlignment = HorizontalAlignment.Center
        End With
    End Sub
    '**************************************************imprimir ******************************************************

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Dim str As String = ""
        str = txtNota.Rtf
        With txtNota
            .Text = "No. " & codigo & " - Cuenta: " & cta & vbCrLf
            .SelectAll()
            .SelectionFont = New Font("Tahoma", 13, FontStyle.Bold)
            .SelectionStart = Len(txtNota.Text)
            .SelectedRtf = str
        End With
        PrintPreviewDialog1.ShowDialog()
        txtNota.Rtf = str
        cambios = 0
    End Sub
    Private Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint
        checkPrint = 0
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage ' Imprimir el contenido del RichTextBox. Almacenar el último carácter impreso. 
        checkPrint = txtNota.Print(checkPrint, txtNota.TextLength, e)

        ' Buscar más páginas 
        If checkPrint < txtNota.TextLength Then
            e.HasMorePages = True
        Else : e.HasMorePages = False
        End If
    End Sub
    Public Sub Nombre(ByVal mes As Long)
        If mes = 1 Then
            nombreMes = "Enero"
            numeroMes = "01"
        ElseIf mes = 2 Then
            nombreMes = "Febrero"
            numeroMes = "02"
        ElseIf mes = 3 Then
            nombreMes = "Marzo"
            numeroMes = "03"
        ElseIf mes = 4 Then
            nombreMes = "Abril"
            numeroMes = "04"
        ElseIf mes = 5 Then
            nombreMes = "Mayo"
            numeroMes = "05"
        ElseIf mes = 6 Then
            nombreMes = "Junio"
            numeroMes = "06"
        ElseIf mes = 7 Then
            nombreMes = "Julio"
            numeroMes = "07"
        ElseIf mes = 8 Then
            nombreMes = "Agosto"
            numeroMes = "08"
        ElseIf mes = 9 Then
            nombreMes = "Septiembre"
            numeroMes = "09"
        ElseIf mes = 10 Then
            nombreMes = "Octubre"
            numeroMes = "10"
        ElseIf mes = 11 Then
            nombreMes = "Noviembre"
            numeroMes = "11"
        Else
            nombreMes = "Diciembre"
            numeroMes = "12"
        End If
    End Sub

End Class