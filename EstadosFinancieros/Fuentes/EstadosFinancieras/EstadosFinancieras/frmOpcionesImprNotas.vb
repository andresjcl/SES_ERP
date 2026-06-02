Imports System.Data.SqlClient

Public Class frmOpcionesImprNotas
    Dim opciones As String = ""
    Dim conectar As New SqlConnection()
    Private checkPrint As Integer
    Private Sub frmOpcionesImprNotas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim coneccion As New DaxLib.DaxLibBases
        coneccion.TipoBase = "10"
        conectar.ConnectionString = coneccion.StrAdcom
        opciones = ""
    End Sub
    Private Sub CargarNota()
        Dim ssql As String = "select Nota_Codigo from AdcNote where Nota_codigo <> 0" & opciones
        Dim num(100), contador As Integer
        Dim cmd As New SqlCommand(ssql, conectar)
        Dim dat As SqlDataReader
        Dim pos As Integer
        Dim posIni As Integer = 0
        conectar.Open()
        dat = cmd.ExecuteReader()
        contador = 1
        Do While dat.Read
            num(contador) = dat(0)
            contador += 1
        Loop
        conectar.Close()
        For i = 1 To contador - 1 Step 1
            ssql = "Select Nota_Codigo,Nota_Cta, Nota_Descripcion from AdcNote where Nota_Codigo= " & num(i)
            cmd = New SqlCommand(ssql, conectar)
            Dim str As String = ""
            conectar.Open()
            dat = cmd.ExecuteReader()

            If dat.Read Then
                str = vbCrLf & "No. " & dat(0) & " - CTA No. " & dat(1) & vbCrLf
                RichTextBoxPrintCtrl1.SelectionStart = Len(RichTextBoxPrintCtrl1.Text)
                RichTextBoxPrintCtrl1.SelectedText = str & vbCrLf
                RichTextBoxPrintCtrl1.SelectionStart = Len(RichTextBoxPrintCtrl1.Text)
                RichTextBoxPrintCtrl1.SelectedRtf = dat(2)
                pos = RichTextBoxPrintCtrl1.Find("No. ", posIni, RichTextBoxFinds.MatchCase)
                If pos > 0 Then
                    RichTextBoxPrintCtrl1.Select(pos, Trim(Len(str) - 3))
                    With RichTextBoxPrintCtrl1
                        .SelectionFont = New Font("Tahoma", 13, FontStyle.Bold)
                    End With
                End If
                posIni = pos + (Trim(Len(str) - 3))
            End If
            conectar.Close()
        Next

    End Sub

    Private Sub optTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTodos.CheckedChanged
        opciones += ""

    End Sub

    Private Sub optSituacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optSituacion.CheckedChanged
        opciones += "and Nota_Origen='BAL_SIT'"
    End Sub

    Private Sub optResultados_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optResultados.CheckedChanged
        opciones += " and Nota_Origen='BAL_RES'"
    End Sub

    Private Sub optPatrimonial_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optPatrimonial.CheckedChanged
        opciones += " and Nota_Origen='BAL_PAT'"
    End Sub

    Private Sub optFlujoE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optFlujoE.CheckedChanged
        opciones += " and Nota_Origen='FLUJ'"
    End Sub
    Private Sub txtNumD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumD.TextChanged
        opciones += " and Nota_codigo >=" & txtNumD.Text
    End Sub

    Private Sub txtNumH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumH.TextChanged
        opciones += " and Nota_codigo <=" & txtNumH.Text
    End Sub

    Private Sub txtFecD_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtFecD.MaskInputRejected
        If IsDate(txtFecD.Text) Then
            opciones += " and substring(nota.Nota_Mes,1,2)>=" & Month(txtFecD.Text)
        End If
    End Sub

    Private Sub txtFecH_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtFecH.MaskInputRejected
        If IsDate(txtFecD.Text) Then
            opciones += " and substring(nota.Nota_Mes,4,2)<=" & Month(txtFecH.Text)
        End If
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        CargarNota()
        PrintPreviewDialog1.ShowDialog()
        RichTextBoxPrintCtrl1.Text = ""
        txtFecD.Text = "__/__/"
        txtFecH.Text = "__/__/"
        txtNumD.Text = ""
        txtNumH.Text = ""
        opciones = ""
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Dispose()
    End Sub

    Private Sub PrintDocument1_BeginPrint1(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint
        checkPrint = 0
    End Sub

    Private Sub PrintDocument1_PrintPage_1(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        checkPrint = RichTextBoxPrintCtrl1.Print(checkPrint, RichTextBoxPrintCtrl1.TextLength, e)
        ' Buscar más páginas 
        If checkPrint < RichTextBoxPrintCtrl1.TextLength Then
            e.HasMorePages = True
        Else : e.HasMorePages = False
        End If
    End Sub
End Class