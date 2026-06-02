Option Strict Off
Option Explicit On
Imports System.Data
Imports System.Data.SqlClient
Imports DattCom

Friend Class BuscDocAdcom
    Inherits System.Windows.Forms.Form
    Private Const MARGIN_SIZE As integer = 60 ' en twips
    ' variables para enlace de datos
    'Private RsDocumentos As ADODB.Recordset

    ' variables para permitir el orden de columnas
    Private m_iSortCol As integer
    Private m_iSortType As integer
    Private nombre, codigo, tipo As String
    Private ConError As Boolean
    Dim fila As Integer = 0

    Public Sub BuscaDocAdcom(ByVal ComVtaBancoInvTod As String, ByRef QUECODIGO As String, ByRef QUENOMBRE As String)
        tipo = ComVtaBancoInvTod
        Me.ShowDialog()
        QUECODIGO = codigo
        QUENOMBRE = nombre
    End Sub

    Private Sub BuscDocAdcom_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim i As Integer = 0
        Dim sSQL As String = ""
        Dim conectar As New SqlConnection(DattCom.datosEmpresa.strConxAdcom)
        Select Case tipo
            Case "V"
                sSQL = " opc_tipo in ('FAC','DEV', 'PRO', 'PEC') "
                Text = "Documentos de ventas"
            Case "T"
                sSQL = " opc_tipo > '' "
                Text = "Documentos activos del sistema"
            Case "C"
                sSQL = " isnull(OPC_consolidar,0) = 1 "
                Text = "Documentos para consolidación"
            Case "I"
                sSQL = " substring(opc_extension,5,1) <> '0' "
                Text = "Documentos de inventarios"
            Case Else
                sSQL = " opc_tipo in ( 'FAP','DEP','NCP','NDP') "
                Text = "Documentos de compras"
        End Select

        Dim cad As String = "select Opc_documento as cod,Opc_nombre as Descripción from AdcOpc where " & sSQL
        Dim datS As New DataSet()
        Dim datAd As New SqlDataAdapter(cad, DattCom.datosEmpresa.strConxAdcom)
        conectar.Open()
        datAd.Fill(datS, "Datos")
        Malla.DataSource = datS.Tables("Datos")

        ' ========== AJUSTES PARA EL DATAGRIDVIEW ==========

        ' Configurar apariencia básica
        Malla.AllowUserToAddRows = False
        Malla.AllowUserToDeleteRows = False
        Malla.AllowUserToOrderColumns = False ' Para versiones antiguas
        Malla.ReadOnly = True
        Malla.MultiSelect = False ' Para selección única

        ' Configurar selección
        Malla.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Malla.ClearSelection()

        ' Ajustar automáticamente el ancho de columnas
        Malla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        ' Configurar estilo de las filas alternadas (opcional)
        Malla.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray

        ' Configurar encabezados
        Malla.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Malla.ColumnHeadersDefaultCellStyle.Font = New Font(Malla.Font, FontStyle.Bold)

        ' Configurar altura de filas
        Malla.RowTemplate.Height = 25

        ' Ajustar manualmente columnas si es necesario
        If Malla.Columns.Count > 0 Then
            ' Si quieres ancho fijo para la primera columna
            Malla.Columns("cod").Width = 80
            Malla.Columns("cod").HeaderText = "Código"

            ' La columna "Descripción" se ajustará automáticamente
            Malla.Columns("Descripción").HeaderText = "Descripción del Documento"
        End If

        ' Configurar colores de selección
        Malla.DefaultCellStyle.SelectionBackColor = Color.SteelBlue
        Malla.DefaultCellStyle.SelectionForeColor = Color.White

        ' Deshabilitar redimensionamiento de columnas si lo prefieres
        ' Malla.AllowUserToResizeColumns = False

        ' Deshabilitar redimensionamiento de filas
        Malla.AllowUserToResizeRows = False

        ' Mostrar líneas de cuadrícula
        Malla.GridColor = SystemColors.ControlDark

        ' Ocultar la columna de encabezado de filas si no es necesaria
        Malla.RowHeadersVisible = False

        ' ========== FIN DE AJUSTES ==========

        Malla.ClearSelection()
        conectar.Close()
        Exit Sub
Errores:
        ConError = True
    End Sub

    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        With Malla
            If .SelectedCells.Count > 0 Then
                codigo = .Rows(fila).Cells(0).Value
                nombre = .Rows(fila).Cells(1).Value
            End If
        End With
        Me.Close()
    End Sub

    Private Sub BuscDocAdcom_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim KeyCode As integer = eventArgs.KeyCode
        Dim Shift As integer = eventArgs.KeyData \ &H10000
        If KeyCode = System.Windows.Forms.Keys.Escape Then Me.Close()
    End Sub

    Private Sub Malla_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Malla.CellEnter
        fila = e.RowIndex
    End Sub

    Private Sub Malla_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Malla.DoubleClick
        cmdClose_Click(cmdClose, New System.EventArgs())
    End Sub
End Class