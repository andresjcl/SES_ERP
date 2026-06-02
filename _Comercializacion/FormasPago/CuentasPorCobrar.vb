'Option Strict On
'Imports System.Data.SqlClient

'Module CuentasPorCobrar
'    Public conectarAdcomDx As New SqlConnection()
'    Public Function codigoSri(ByVal idFormasDePago As String, ByRef GrupoDelPago As String, ByRef pagoCreditoContado As String, ByRef NomPlan As String) As String
'        Dim ssql As String = "select isnull(SRI_formaDePago,'0') as SRI_formaDePago,formaDepago,tipoformapago,Descripcion from FormasDePago where idFormasDePago = '" & idFormasDePago & "'"
'        Dim cnn As New SqlConnection(datosEmpresa.strConxAdcom)
'        Dim dato As New DataTable
'        Dim misqlDa As SqlDataAdapter = New SqlDataAdapter()
'        Try
'            cnn.Open()
'            misqlDa = New SqlDataAdapter(ssql, cnn)
'            misqlDa.Fill(dato)
'        Catch e As Exception
'            MsgBox("No se puede ejecutar la consulta " & ssql & vbCr & e.Message)
'        End Try
'        If dato.Rows.Count = 0 Then
'            ssql = ""
'            pagoCreditoContado = ""
'            NomPlan = ""
'            GrupoDelPago = ""
'        Else
'            ssql = dato.Rows(0).Item("sri_formaDePago").ToString
'            GrupoDelPago = dato.Rows(0).Item("TipoformaPago").ToString
'            pagoCreditoContado = dato.Rows(0).Item("formaDePago").ToString
'            NomPlan = dato.Rows(0).Item("Descripcion").ToString
'        End If
'        cnn.Close()
'        dato.Dispose()
'        misqlDa.Dispose()
'        Return ssql
'    End Function

'    Public Function consultarDato(ByVal consulta As String) As DataSet
'        Dim dato As New DataSet
'        Dim valor As New BindingSource
'        Dim misqlDa As SqlDataAdapter = New SqlDataAdapter()
'        Try
'            misqlDa = New SqlDataAdapter(consulta, datosEmpresa.strConxAdcom)
'            misqlDa.Fill(dato, "lista")
'        Catch
'            MsgBox("No se puede ejecutar la consulta " & consulta)
'        End Try
'        misqlDa.Dispose()
'        Return dato
'    End Function

'    Public Sub mantenimiento(ByVal mantenimiento As String)
'        Dim conectarAdcomdx As New SqlConnection(datosEmpresa.strConxAdcom)
'        conectarAdcomdx.Open()
'        Dim cmd As New SqlCommand(mantenimiento, conectarAdcomDx)
'        Try
'            cmd.ExecuteNonQuery()
'        Catch
'            MsgBox("No se puede ejecutar el mantenimiento " & mantenimiento)
'        End Try

'    End Sub

'    Public Sub CargarMallaSaldos2(ByVal EsCliente As Boolean, ByRef malla As DataGridView, ByVal txtCodPer As String, ByVal txtFec As String _
'            , Optional ByVal DocSuc As String = "", Optional ByVal DocTip As String = "", Optional ByVal DocNum As String = "", _
'            Optional ByVal IdClaveDoc As Double = 0, Optional ByVal NroLoteEx As String = "", Optional ByVal Solocliente As Boolean = False, Optional ByVal coloproveedor As Boolean = False, Optional ByVal conanticipos As Boolean = False, Optional ByVal TipoDoc As String = "")
'        Dim i As Integer, cod As String
'        Dim StrSigno As String
'        Dim SinDocumento As String
'        Dim ConLote As String

'        Dim SYSEMP As AdcDax.DaxSofSys = New AdcDax.DaxSofSys '= AdcDaxx.DaxSofSys.Instance
'        If Not (Solocliente Or coloproveedor Or conanticipos) Then Exit Sub
'        If txtFec = "" Then txtFec = Now.Date.ToString
'        If NroLoteEx > "" Then ConLote = NroLoteEx

'        StrSigno = ""
'        If Solocliente And coloproveedor Then

'        ElseIf Solocliente Then
'            StrSigno = "C"
'        ElseIf coloproveedor Then
'            StrSigno = "P"
'        End If

'        Dim txtfec1 As String

'        txtfec1 = CStr(DateAdd("D", 1, SYSEMP.EmpresaAct.InvUltAnu))
'        cod = "exec ADC_PENDI '" & txtCodPer & "','" & txtfec1 & "','" & txtFec & "'," & IIf(conanticipos, 1, 0).ToString & ",0,0,'" & StrSigno & "','" & NroLoteEx & "',0,'" & DocSuc & "','" & DocTip & "'," & IdClaveDoc
'        malla.DataSource = consultarDato(cod).Tables(0)
'        If malla.RowCount = 0 Then Exit Sub
'        With malla
'            For Each coll As DataGridViewColumn In .Columns
'                coll.ReadOnly = True
'                coll.Visible = False
'            Next

'            .Columns("Abono").ReadOnly = False

'            .Columns("Nombre").Visible = True
'            .Columns("SUC").Visible = True
'            .Columns("TIP").Visible = True
'            .Columns("Numero").Visible = True
'            .Columns("Fecha").Visible = True
'            .Columns("Valor").Visible = True
'            .Columns("SaldoAct").Visible = True
'            .Columns("Abono").Visible = True

'            .Columns("Nombre").Width = 250
'            .Columns("SUC").Width = 40
'            .Columns("TIP").Width = 40
'            .Columns("Numero").Width = 80
'            .Columns("Fecha").Width = 80
'            .Columns("Valor").Width = 95
'            .Columns("SaldoAct").Width = 95
'            .Columns("Abono").Width = 95
'            '.Columns("temp2").Visible = False
'            '.Columns("Doc_codper").Visible = False
'            '.Columns("IdClaveDoc").Visible = False

'            .Columns("Valor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
'            .Columns("SaldoAct").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
'            .Columns("Abono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
'            .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
'            .Columns("Nombre").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
'            .Columns("Numero").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

'            .Columns("Valor").DefaultCellStyle.Format = "#0.00;;\"
'            .Columns("SaldoAct").DefaultCellStyle.Format = "#0.00;;\"
'            .Columns("Abono").DefaultCellStyle.Format = "#0.00;;\"

'            If DocSuc > "" And DocTip > "" And IdClaveDoc > 0 Then
'                Dim RA As New DataTable
'                SinDocumento = " doc_sucursal = '" & DocSuc & "' and opc_documento = '" & DocTip & "' and idclavedoc = " & IdClaveDoc
'                RA = consultarDato("select apl_sucapli,apl_docapli,idClaveDocApl,Apl_valorapl from adcdocabonos2 where " & SinDocumento).Tables(0)
'                If RA.Rows.Count = 0 Then RA.Dispose() : Exit Sub
'                For j = 0 To RA.Rows.Count - 1
'                    For i = 0 To .Rows.Count - 1
'                        If Trim(.Rows(i).Cells("SUC").Value.ToString) = Trim(RA.Rows(j).Item("apl_sucapli").ToString) And Trim(.Rows(i).Cells("TIP").Value.ToString) = Trim(RA.Rows(j).Item("apl_docapli").ToString) And Val(.Rows(i).Cells("idClaveDoc").Value.ToString) = Val(RA.Rows(j).Item("idclavedocapl").ToString) Then
'                            .Rows(i).Cells("Abono").Value = Val(RA.Rows(j).Item("apl_valorapl").ToString)
'                        End If
'                    Next i
'                Next j
'                RA.Dispose()
'            End If
'        End With
'        SYSEMP = Nothing
'    End Sub
'End Module
