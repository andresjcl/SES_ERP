Imports System.Data.SqlClient
Imports DattCom


Public Class FormAplicaciones
    'Dim cta As New cuenta
    'Public strConxAdcom As String = ""
    Public EmpSucActual As String = ""
    Dim SalirSN As Boolean
    Dim FechaHasta As String
    Dim DeDondeEs As String
    Dim Docum As String
    Dim Num As Double
    Dim SwSalida As Boolean
    Dim TotalDoc As Double
    Dim PosicionDoc As Integer
    Dim StrComVen As String
    Dim Sucursal As String
    Dim IdClaveDoc As Double
    Dim Act1 As Boolean

    Public Sub IniMovimientoDoc(IdClaveDocC As Double, Documento As String, numero As Long, Optional Adicional As Double = 0, Optional fecha As String = "", Optional Dedonde As String = "", Optional Posicion As Integer = 0, Optional DocSuc As String = "")
        DeDondeEs = Dedonde
        FechaHasta = fecha
        SwSalida = True
        PosicionDoc = Posicion
        Docum = Documento
        Num = numero
        Sucursal = DocSuc
        IdClaveDoc = IdClaveDocC
        If Sucursal = "" Then Sucursal = EmpSucActual
        TotalDoc = Adicional
        Act1 = False
        'Form_Activate
        Me.ShowDialog()
    End Sub


    Private Sub llenarMalla()
        Dim cod As String = ""
        Dim StrFecha As String = ""
        Dim Seleccion As String
        Dim cont As Long : cont = 0
        SalirSN = True
        Select Case PosicionDoc
            Case 3
                StrComVen = "Doc_Contabilidad"
            Case 4
                StrComVen = "Doc_Banco"
            Case 5
                StrComVen = "Doc_Inventario"
            Case 6
                StrComVen = "Doc_Ventas"
            Case 7
                StrComVen = "Doc_Compras"
            Case 8
                StrComVen = "Doc_Activo"
        End Select
        SwSalida = False
        If FechaHasta <> "" Then StrFecha = " AND abb.apl_Fecha <= '" & FechaHasta & "'"
        Seleccion = "APL_SUCAPLI = '" & Sucursal & "' AND  (APL_DOCAPLI = '" & Docum & "') AND idclavedocAPL = " & IdClaveDoc

        cod = " SELECT   dd.idclavedoc,DD.DOC_SUCURSAL, ABB.opc_documento, ABB.doc_numero, ABB.Apl_fecha, ABB.Apl_valorapl as ValorApl , DD.Doc_Bodega, " & _
              " DD.Doc_NombreImp, DD.Doc_codper, DD.doc_fecha " & _
              "  " & _
              " FROM  AdcDoc DD right JOIN Adcdocabonos2 ABB ON DD.idclavedoc = ABB.idclavedoc AND " & _
              " DD.Opc_documento = ABB.opc_documento AND ABB.Doc_sucursal = DD.Doc_sucursal " & _
              " WHERE  " & Seleccion & "  " & StrFecha & "   " & _
              " Order BY abb.Apl_Fecha, abb.Opc_Documento , dd.Doc_numero"

        Dim dt As New DataTable()
        Dim da As New SqlDataAdapter(cod, datosEmpresa.strConxAdcom)
        da.Fill(dt)
        malla.DataSource = dt
        totalizar()
    End Sub

    Private Sub totalizar()
        Dim Temp As Double = 0
        Dim row As New DataGridViewRow
        TotalDoc = 0
        For Each row In malla.Rows
            TotalDoc += Convert.ToDouble("0" + row.Cells("Valor").Value.ToString())
        Next
        Label1.Text = "Total aplicaciones: " + String.Format("0.00", TotalDoc)
    End Sub

    Private Sub button1_Click(sender As System.Object, e As System.EventArgs) Handles button1.Click
        Me.Close()
    End Sub

    Public Sub New()
        InitializeComponent()
        If SwSalida = True Then llenarMalla()
    End Sub
End Class