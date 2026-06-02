Imports System.Data.SqlClient

Public Class DetRep

    Dim conectar As New SqlConnection()
    Dim resp(3) As String
#Region "Inicialización de datos"
    Private Sub conectarBdd()
        Dim coneccion As New DaxLib.DaxLibBases
        coneccion.TipoBase = "10"
        conectar.ConnectionString = coneccion.StrAdcom
    End Sub
    Private Sub Inicializar()
        txtDesde.Text = "01/01/" & Year(Now).ToString()
        txtHasta.Text = Now.ToShortDateString
        chkAct.Checked = True
        txtCod.Enabled = False
        txtNombre.Enabled = False
        btnAct.Enabled = False
    End Sub
    Private Sub DetRep_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conectarBdd()
        Inicializar()
    End Sub
#End Region

#Region "Escoger Activo"
    Private Sub chkAct_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAct.CheckedChanged
        txtCod.Enabled = Not chkAct.Checked
        txtNombre.Enabled = Not chkAct.Checked
        btnAct.Enabled = Not chkAct.Checked
    End Sub
    Private Sub btnAct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAct.Click
        Dim busk As New MantenimientoAF.BuscarAcf
        Dim cod As String
        cod = busk.Cargar("")
        If cod <> "" Then
            txtCod.Text = cod : txtNombre.Text = nombreAct(cod)
        End If
    End Sub
    Private Function nombreAct(ByVal cod As String) As String
        Dim nom As String = ""
        Dim ssql As String = "select nombre from AdcAcf where codigo='" & cod & "'"
        Dim cmd As New SqlCommand(ssql, conectar)
        Dim dat As SqlDataReader = Nothing
        If conectar.State = ConnectionState.Open Then conectar.Close()
        conectar.Open()
        dat = cmd.ExecuteReader
        If dat.Read Then
            If Not IsDBNull(dat(0)) Then nom = CStr(dat(0))
        End If
        Return nom
    End Function
#End Region

#Region "Aceptar"
    Private Function verificar() As Boolean
        Dim ban As Boolean = True
        If txtDesde.Text > txtHasta.Text Then
            MsgBox("La fecha de inicio debe ser menor a la fecha de finalización", MsgBoxStyle.Information)
            ban = False
            txtDesde.Focus()
        End If
        Return ban
    End Function
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If verificar() = False Then Exit Sub
        resp(0) = txtCod.Text
        resp(1) = txtDesde.Text
        resp(2) = txtHasta.Text
        Me.Dispose()
    End Sub
#End Region

#Region "Cancelar"
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Dispose()
    End Sub
#End Region

    Public Function IngresarFec() As String()
        Me.ShowDialog()
        Return resp
    End Function

End Class