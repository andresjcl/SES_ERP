Imports System.Data.SqlClient

Public Class Contabilizar
    Dim conectar As New SqlConnection()
    Dim cols As Integer = 0
    Dim inicial As Boolean = True
    Dim OpOpc As New PrySysp13.OpcDoc

#Region "Inicializar"
    Private Sub conectarBdd()
        Dim coneccion As New DaxLib.DaxLibBases
        coneccion.TipoBase = "10"
        conectar.ConnectionString = coneccion.StrAdcom
    End Sub
    Private Sub LimpiarMalla()
        With malla
            If .RowCount > 0 Then
                For i = .RowCount - 1 To 0 Step -1
                    .Rows.RemoveAt(i)
                Next
            End If
            If .ColumnCount > 0 Then
                For i = .ColumnCount - 1 To 0 Step -1
                    .Columns.RemoveAt(i)
                Next
            End If
        End With
    End Sub
    Private Sub cboDoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDoc.SelectedIndexChanged
        DocNum()
    End Sub
    Private Sub cargarCombo()
        Dim ssql As String = " select Opc_documento,Opc_nombre  from Adcopc where opc_tipo='DIA'"
        Dim dats As New DataSet()
        Dim datAd As New SqlDataAdapter(ssql, conectar)
        If conectar.State = ConnectionState.Open Then conectar.Close()
        conectar.Open()
        datAd.Fill(dats, "Datos")
        cboDoc.DataSource = dats.Tables("Datos")
        cboDoc.DisplayMember = "Opc_nombre"
        cboDoc.ValueMember = "Opc_documento"
        conectar.Close()
    End Sub
    Private Sub DocNum()
        Dim ssql As String = "select max(doc_numero) from adcdoc where opc_documento='" & cboDoc.SelectedValue.ToString & "'"
        Dim cmd As New SqlCommand(ssql, conectar)
        Dim dat As SqlDataReader = Nothing
        If conectar.State = ConnectionState.Open Then conectar.Close()
        conectar.Open()
        dat = cmd.ExecuteReader
        If dat.Read Then
            If Not IsDBNull(dat(0)) Then txtDocNumero.Text = dat(0) Else txtDocNumero.Text = "1"
        End If
    End Sub
    Private Sub Contabilizar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inicial = True
        conectarBdd()
        txtMes.Text = Month(Now)
        txtAño.Text = Year(Now)
        cargarCombo()
        CargarMalla()
        inicial = False
    End Sub
#End Region

#Region "Llenar malla"
    Private Function campos()
        Dim campo As String = ""
        With malla
            .Columns.Add("Codigo", "Codigo")
            .Columns.Add("Nombre", "Nombre")
            If chkReval.Checked Then
                campo += ",RevalorizacionMes"
                .Columns.Add("Revalorizacion", "RevalorizacionMes")
            End If
            If chkDet.Checked Then
                campo += ",DeterioroMes"
                .Columns.Add("DeterioroMes", "DeterioroMes")
            End If
            If chkDepFinan.Checked Then
                ' If campo = "" Then campo = "DepreciacionMes" Else campo += ",DepreciacionMes"
                .Columns.Add("DepreciacionFin", "Depreciacion Finan.")
            End If
            If chkDepTribut.Checked Then
                .Columns.Add("DepreciacionTri", "Depreciacion Trib.")
            End If
            If chkDiferencia.Checked Then
                .Columns.Add("Diferencia", "Diferencia")
            End If
        End With
        Return campo
    End Function
    Private Sub CargarMalla()
        LimpiarMalla()
        Dim con As Integer = 0
        Dim ssql As String = "select d.Codigo,a.Nombre" & campos()
        If chkDepFinan.Checked Then ssql += ",t.depFin "
        If chkDepTribut.Checked Then ssql += ",t.depT "
        If chkDiferencia.Checked Then ssql += ",abs(t.depFin -t.depT) as dif "
        ssql += " from AdcAcfDep d left join "
        ssql += "(select d1.Codigo, d1.DepreciacionMes as depT,f.DepreciacionMes as depFin "
        ssql += " from AdcAcfDep d1 left join "
        ssql += "(select Codigo, DepreciacionMes  from AdcAcfDep where ClaseDepreciacion='F' and Mes=" & txtMes.Text & " and año=" & txtAño.Text & " "
        ssql += ")F on (f.Codigo= d1.Codigo) "
        ssql += "where ClaseDepreciacion='T' and Mes=" & txtMes.Text & " and año=" & txtAño.Text & " "
        ssql += ")T on( d.Codigo=t.Codigo ) "
        ssql += "left join "
        ssql += "(select codigo, nombre from AdcAcf "
        ssql += ")A on a.Codigo=d.Codigo  "
        ssql += "where Mes=" & txtMes.Text & " and año=" & txtAño.Text & " "
        Dim cmd As New SqlCommand(ssql, conectar)
        Dim dat As SqlDataReader = Nothing
        If conectar.State = ConnectionState.Open Then conectar.Close()
        conectar.Open()
        dat = cmd.ExecuteReader()
        If dat.Read Then
            With malla
                While dat.Read
                    .Rows.Add()
                    For i = 0 To .ColumnCount - 1
                        If Not IsDBNull(dat(1)) Then .Rows(con).Cells(i).Value = dat(i)
                    Next
                    con += 1
                End While
            End With
        End If
    End Sub
    Private Sub chkReval_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReval.CheckedChanged
        If inicial = False Then CargarMalla()
    End Sub

    Private Sub chkDet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDet.CheckedChanged
        If inicial = False Then CargarMalla()
    End Sub

    Private Sub chkDepFinan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDepFinan.CheckedChanged
        If inicial = False Then CargarMalla()
    End Sub

    Private Sub chkDepTribut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDepTribut.CheckedChanged
        If inicial = False Then CargarMalla()
    End Sub

    Private Sub chkDiferencia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDiferencia.CheckedChanged
        If inicial = False Then CargarMalla()
    End Sub
#End Region



    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        OpOpc.Cargar(cboDoc.SelectedValue.ToString)
    End Sub
End Class
