Option Strict Off
Option Explicit On
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports DattCom
Friend Class EscojeCamposDir
    Dim CamposAntes As String = ""
    Dim LimSup As Integer = 0
    Dim LimInf As Integer = 0
    Dim MatCamposAntes() As String
    Dim CamposCol As String = ""
    Dim Sistema As String = ""

    Public Function EscojeCampos(ByRef Sistem As String) As String
        '    If CamposCol = Nothing Then Return ""
        Sistema = Sistem
        Me.ShowDialog()
        SaveSetting(Sistema, "Dir", "Campos", CamposCol)
        EscojeCampos = CamposCol
    End Function

    Private Sub EscojeCamposDir_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim prog As New DaxLib.DaxLibMalla
        'prog.ColorF(Me)
        ' prog = Nothing

        CamposAntes = GetSetting(Sistema, "Dir", "Campos", "")
        If CamposAntes > "" Then
            MatCamposAntes = Split(CamposAntes, ",")
            LimSup = UBound(MatCamposAntes)
            LimInf = LBound(MatCamposAntes)
        End If
        llenarMalla()
    End Sub
    Private Sub llenarMalla()
        Dim sSQL As String = "select top 1 * from directorioList "
        Dim conn As New SqlClient.SqlConnection(datosEmpresa.strConxAdcom)
        Dim I As Integer
        conn.Open()
        Dim misqlDa As New SqlDataAdapter(sSql, conn)
        Dim dato As New DataTable("datos")
        misqlDa.Fill(dato)
        With malla
            For I = 0 To dato.Columns.Count - 1
                .Items.Add(dato.Columns(i).ColumnName())
            Next
        End With

        'Dim rs As New DataTable
        'Dim DR As New SqlClient.SqlDataReader
        'Dim CONN As 
        'Dim prog As New DaxData.DaxLibDatos
        ''Dim ConxAdcom As New ADODB.Connection
        ''Dim PROG As New DaxLibBases
        'Dim i As Integer
        'Dim j As Integer

        ''ConxAdcom.ConnectionString = Prog.StrAdcom    'prog.ArmStr(Emp.NombreBaseAlex, Emp.servidor, "", Emp.ClaveBD, Emp.UsuarioBd)
        ''ConxAdcom.Open

        ''rs = prog.DaxData("MSSQL", "sp_columns directorioadc") ' ConxAdcom.Execute("sp_columns directorioadc")
        'With malla
        '    Do Until rs.EOF
        '        If Not IsDBNull(rs.Fields("column_name").Value) Then .Items.Add(rs.Fields("column_name").Value)
        '        rs.MoveNext()
        '    Loop
        'End With
        If LimSup > 0 Then
            For i = 0 To malla.Items.Count - 1
                For j = 1 To LimSup
                    If malla.Items(i) = MatCamposAntes(j) Then malla.SetItemChecked(i, True)
                Next j
            Next i
        End If
        malla.SetItemChecked(0, True)
    End Sub


    Private Sub Command2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Command2.Click
        Dim i As Integer
        CamposCol = "Codigo"
        With malla
            For i = 1 To .Items.Count - 1
                If malla.GetItemChecked(i) = True Then
                    If CamposCol > "" Then CamposCol = CamposCol & ","
                    CamposCol = CamposCol & .Items.Item(i).ToString
                End If
            Next i
        End With
        Me.Close()
    End Sub

    Private Sub Command1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Command1.Click
        CamposCol = ""
        SaveSetting(Sistema, "Dir", "Campos", CamposCol)
        Me.Close()
    End Sub

    Private Sub Command3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command3.Click
        Me.Close()
    End Sub
End Class