Option Strict Off
Option Explicit On
Friend Class Datos
	Inherits System.Windows.Forms.Form
    Dim Opcion, linea As Byte
    Dim tabla3, tabla1, tabla2, tabla4 As ADODB.Recordset
	Public EsDeConsulta As String
	
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		Dim i As Short
		Dim INI, fIN As Short
		Dim POS As Short
		On Error Resume Next
		If ListDatos.Row > ListDatos.RowSel Then
			INI = ListDatos.RowSel
			fIN = ListDatos.Row
		Else
			INI = ListDatos.Row
			fIN = ListDatos.RowSel
		End If
		If EsDeConsulta > "S" Then
			POS = 1
		Else
			POS = 0
		End If
		Pasar = ""
		For i = INI To fIN
			If Pasar > "" Then Pasar = Pasar & ","
			Pasar = Pasar & ListDatos.get_TextMatrix(i, POS)
		Next 
		
		Tipo = CStr(Opcion)
		linea = ListDatos.Row
		Me.Close()
	End Sub
	
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		Pasar = ""
		Me.Close()
	End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        ORDEN = IIf(ORDEN = 0, 1, 0)
        ListDatos.Col = ORDEN
        ListDatos.Sort = 5
        Command3.Text = IIf(ORDEN = 0, "Ordenar Por Nombre", "Ordenar Por Código")

    End Sub

    Private Sub Datos_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Dim i As Short
		
		On Error Resume Next
		
		Option1(14).Enabled = False
		If EsDeConsulta > "" Then
			'For i = 0 To 13: Option1(i).Enabled = False: Next
			Option1(14).Enabled = True
			Opcion = 14
			linea = 0
		End If
		'Else
		
		Opcion = Val(GetSetting(My.Application.Info.Title, "ADC", "Datos", "0"))
		If GenDatox.Sistema = "P" Then
			Option1(9).Enabled = False
			Option1(4).Enabled = False
			Option1(10).Enabled = False
			If Opcion = 9 Or Opcion = 10 Or Opcion = 4 Then Opcion = 0
		End If
		linea = Val(GetSetting(My.Application.Info.Title, "ADC", "Linea", "0"))
		'End If
		Option1(Opcion).Checked = True
		ListDatos.set_ColWidth(0,  , 650)
		ListDatos.set_ColWidth(1,  , 3050)
		ListDatos.Col = 1
	End Sub

    Private Sub Datos_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        SaveSetting(My.Application.Info.Title, "ADC", "Datos", CStr(Opcion))
        SaveSetting(My.Application.Info.Title, "ADC", "Linea", CStr(linea))
    End Sub

    Private Sub ListDatos_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Command1_Click(Command1, New System.EventArgs())
    End Sub

    Private Sub Option1_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Option1.CheckedChanged
        If eventSender.Checked Then
            Dim index As Short = Option1.GetIndex(eventSender)
            Dim rs As New ADODB.Recordset

            GenDatox = New DaxLib.GenDatos
            GenDatox.Abrir("A", PathServidor)
            GenDatox.Cargar(ListDatos, index,  , IIf(index = 14, NombreConsulta, ""), BaseConsulta)
            Opcion = index
        End If
    End Sub
End Class