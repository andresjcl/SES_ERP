Option Strict Off
Option Explicit On
Imports System.Data
Imports System.Data.SqlClient
Friend Class frmAdcDocnum
	Inherits System.Windows.Forms.Form
    Dim mbChangedByCode As Boolean
	Dim mvBookMark As Object
	Dim mbEditFlag As Boolean
	Dim mbAddNewFlag As Boolean
	Dim mbDataChanged As Boolean
	Dim TipoDoc As String
    Dim ssql As String = ""
    Public Sub UnDocumento(ByRef Tipo As String)
        TipoDoc = Tipo
        Me.ShowDialog()
    End Sub
    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        Dim cod As String
        'on error resume next
        Try
            Dim conectar As New SqlConnection(DattCom.datosEmpresa.strConxAdcom)
            conectar.Open()

            If MsgBox("Confirma Reorganizar la numeración de documentos, " & vbCr & "según los documentos que existen actualmente ", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                cod = "delete from AdcDocNum "
                Dim cmd1 As New SqlCommand(cod, conectar)
                cmd1.ExecuteNonQuery()
                CargarDatosNum()
                cod = "INSERT INTO [AdcDocNum]([Id_Lugar], [id_Documento], [UltimoNumero], [UltimaFecha]) "
                cod = cod & "SELECT Lugar, Opc_documento, max(CASE WHEN Numero = '' THEN 0 ELSE ISNULL(Numero,0)END) AS Numero,max( Fecha) as fecha From"
                cod = cod & " ("
                cod = cod & " SELECT doc_sucursal AS Lugar, Opc_documento,max(cast(Doc_numero as varchar(20))) AS Numero, MAX(Doc_fecha) AS Fecha From dbo.AdcDoc"
                cod = cod & " GROUP BY  doc_sucursal , Opc_documento"
                cod = cod & " union All"
                cod = cod & " SELECT doc_sucursal AS Lugar, Opc_documento,max(cast(Doc_numero as varchar(20))) AS Numero, MAX(Doc_fecha) AS Fecha From dbo.AdcDocPro"
                cod = cod & " GROUP BY  doc_sucursal , Opc_documento"
                cod = cod & " union All"
                cod = cod & " SELECT doc_BancoOrigen AS Lugar, Opc_documento,max(CAST(Doc_numerocheque as varchar(20))) AS Numero, MAX(Doc_fecha) AS Fecha From dbo.AdcDoc"
                cod = cod & " where  isnull(doc_BancoOrigen,'') > '' "
                cod = cod & " GROUP BY  doc_BancoOrigen , Opc_documento"
                cod = cod & " ) t1"
                cod = cod & " group by lugar,opc_documento"
                cod = cod & " order by lugar,opc_documento"
                Dim cmd As New SqlCommand(cod, conectar)
                cmd.ExecuteNonQuery()
                conectar.Close()
                CargarDatosNum()
                conectar.Dispose()
            End If
        Catch ex As Exception
            MessageBox.Show("Excepción en la renumeración de documentos " + vbCr + ex.Message)
        End Try

    End Sub

    Private Sub frmAdcDocnum_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        If TipoDoc > "" Then grdDataGrid.AllowUserToAddRows = False
        CargarDatosNum()
    End Sub
    'Private Sub conectarBdd()
    '    Dim coneccion As New DaxLib.DaxLibBases
    '    coneccion.TipoBase = "10"
    '    DattCom.datosEmpresa.strConxAdcom = coneccion.StrAdcom
    '    conectar.ConnectionString = DattCom.datosEmpresa.strConxAdcom
    'End Sub
    Private Sub CargarDatosNum()
        Dim ConDoc As String = ""
        'On Error Resume Next
        If TipoDoc > "" Then ConDoc = " where id_documento = '" & TipoDoc & "' "
        'Dim ssql As String = "select Id_Lugar as Sucursal,Id_Documento as Documento,UltimoNumero,UltimaFecha from AdcDocnum " & ConDoc

        ssql = "SELECT Id_Lugar as Sucursal, id_Documento as Documento, UltimoNumero, UltimaFecha"
        ssql = ssql & ", id_bodega, id_Banco, id_Directorio, id_Sri, idclave "
        ssql = ssql & " FROM AdcDocNum " & ConDoc

        Dim dats As New DataTable
        Dim datAd As New SqlDataAdapter(ssql, DattCom.datosEmpresa.strConxAdcom)
        datAd.Fill(dats)
        grdDataGrid.DataSource = dats
        Dim i As Integer = dats.Rows.Count
        grdDataGrid.Columns("id_bodega").Visible = False
        grdDataGrid.Columns("id_Banco").Visible = False
        grdDataGrid.Columns("id_Directorio").Visible = False
        grdDataGrid.Columns("id_Sri").Visible = False
        grdDataGrid.Columns("idclave").Visible = False

        grdDataGrid.ClearSelection()
        'dats.Dispose()
    End Sub

    Private Sub frmAdcDocnum_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub


    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        Dim confirmar As Integer = MsgBox("Desea guardar los cambios?", MsgBoxStyle.YesNoCancel)
        If confirmar = vbYes Then
            'eliminar()
            GrabarNum()
            Me.Close()
        ElseIf confirmar = vbNo Then
            Me.Close()
        End If
    End Sub
    Private Sub eliminar()
        Dim ssql As String = "delete from AdcDocNum "
        Dim conectar As New SqlConnection(DattCom.datosEmpresa.strConxAdcom)
        conectar.Open()
        Dim cmd As New SqlCommand(ssql, conectar)
        conectar.Open()
        cmd.ExecuteNonQuery()
        conectar.Close()
        conectar.Dispose()
    End Sub

    Private Sub GrabarNum()
        Dim dataT As New DataTable
        Dim datAd As New SqlDataAdapter(ssql, DattCom.datosEmpresa.strConxAdcom)
        datAd.Fill(dataT)
        With grdDataGrid
            For i As Integer = 0 To .RowCount - 1
                For Each dRow As DataRow In dataT.Rows
                    'If (.Rows(i).Cells(0).Value Is Nothing Or .Rows(i).Cells(2).Value Is Nothing) = True Then
                    Try
                        If .Rows(i).Cells("idclave").Value.ToString() = dRow.Item("idclave").ToString() Then
                            For j As Integer = 0 To .Columns.Count - 1
                                dRow.Item(j) = .Rows(i).Cells(j).Value
                            Next j
                            Exit For
                        End If
                    Catch
                    End Try
                Next
            Next
        End With
        Dim db As New SqlCommandBuilder(datAd)
        datAd.Update(dataT)
        dataT.Dispose()
        datAd.Dispose()
        db.Dispose()
    End Sub
	
    Private Sub grdDataGrid_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDataGrid.MouseLeave
        grdDataGrid.EndEdit()
    End Sub
End Class