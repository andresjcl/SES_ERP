Imports System.Data.SqlClient
Imports SysEmpDatt
Public Class frmBuscarDoc

    Dim conexion As New SqlConnection()
    Dim botonOpc As Integer = 0
    Dim opciones As String
    Dim cargainicial As Boolean = True
    Dim camp As String
    Dim cargar As Boolean = False
    Dim numero As String = ""

    'Dim adcdax As New AdcDax.DaxSofSys
    'Dim emp As AdcDax.Empresa

    Public docSucursal As String = ""
    Public LisTipoDocu As String = ""
    Public opc_d As String = ""
    Public tabla As String = ""

    Public idClaveDoc As Double = 0
    Public Solodoc As String = ""
    Public LiquidacionTip As String = ""
    Public LiquidacionNum As String = ""
    Public DocInicial As String = ""
    Public Codigo As String = ""
    Public claseDoctosPermitidos As String = "" ' ES LA CLASE DE DOCUMENTOS QUE QUEREMOS BUSCAR (viene un solo string string  de  cdigos de doctos de tres en tres seguidos "FACEGRFAPPRO...etc")
    Public InicFec As Date = CDate("00:00")

    Public DocRet As String
    Public NumRet As Double
    Public TipoDoc As String
    Public SucRet As String
    Public Lista As String
    Public sinArt As Boolean
    Public laEmpresa As Integer

    Public estaConsolidando As Boolean = False
    Dim saltar As Boolean = True
#Region "Consulta"

    Private Sub frmBuscarDoc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If sinArt Then
            Label4.Visible = False
            btnArticuloCod.Visible = False
            btnServicioCod.Visible = False
            txtArtCodigo.Visible = False
            txtArticuloNombre.Visible = False
        End If

        'emp = adcdax.EmpresaAct
        Dim fec As String
        Dim mes As Integer = Month(Now)
        Dim año As Integer = 0
        If mes = 1 Then año = CInt(Year(Now) - 1) Else año = CInt(Year(Now))
        If mes = 1 Then fec = "01/12/" & año Else fec = "01/" & (mes - 1) & "/" & año
        txtFechaIn.Text = CStr(CDate(fec))
        txtFechaFin.Text = CStr(Now)
        conectarBDD()
        Dim llcbo As New DaxCombobx.CargCmbBox
        llcbo.DaxCombosSuc(datosEmpresa.codEmpresa.ToString(), True, datosEmpresa.strConxSyscod, cboSucursal)
        cboSucursal.SelectedValue = docSucursal
        llcbo.DaxCombosBods(docSucursal, True, buscadorDoc.strConxDaxsys, cboBodega)
        llcbo.DaxCombosDoc(claseDoctosPermitidos, DocInicial, False, buscadorDoc.strConxAdcom, cboTipoDoc)
        llcbo.DaxCombosPtoVta(buscadorDoc.strConxAdcom, cboPtoVenta, True)
        Try
            cboPtoVenta.SelectedValue = Environment.MachineName
        Catch
            cboPtoVenta.SelectedValue = "0"
        End Try
        If cboPtoVenta.SelectedValue Is Nothing Then cboPtoVenta.SelectedValue = "0"
        Try
            cboSucursal.SelectedValue = datosEmpresa.suc
        Catch ex As Exception
        End Try
        Dim aux As String = DocInicial.Replace("'", "")
        If (aux.Length > 2) Then cboTipoDoc.SelectedValue = aux.Substring(0, 3)
        cmbActivos.SelectedIndex = 1
        cmbAutorizaciones.SelectedIndex = 1

        'llenarBodegaSucurasal("select Abreviación,Descripcion from  syscod where tiporeferencia ='sucursales' and Abreviación <>'#'", cboSucursal)
        'llenarBodegaSucurasal("select Abreviación,Descripcion from  syscod where tiporeferencia = 'bodegas' and Abreviación <>'#'", cboBodega)

        If Codigo > "" Then
            txtClienteCod.Text = Codigo
            Dim prog As New RetNombre.AdcNomb
            txtClienteNombre.Text = prog.RetornaNombreDirectorio(Codigo, buscadorDoc.strConxAdcom)
        End If

        CargarMalla()
        cargainicial = False
        txtFechaIn.Focus()
        cargar = True
        saltar = False
        ' If cboTipoDoc.Items.Count > 0 Then cboTipoDoc.SelectedIndex = 1
    End Sub

    'Metodo para conectar el programa con la base de datos
    Private Sub conectarBDD()
        'Dim coneccion As New DaxLib.DaxLibBases
        'coneccion.TipoBase = "10"
        Try
            conexion.ConnectionString = buscadorDoc.strConxAdcom
        Catch
            MsgBox("No existe conección a la base de datos del AdcomDX_ERP")
        End Try
    End Sub
    'Metodo para cargar la malla de busqueda
    Private Sub CargarMalla()
        Dim Bus_PtoVta As String = ""
        Dim Bus_tipDoc As String = ""
        Dim Bus_suc As String = ""
        Dim Bus_bod As String = ""
        Dim Bus_client As String = ""
        Dim Bus_art As String = ""
        Dim Bus_det As String = ""
        Dim Bus_valor As String = ""
        Dim Bus_tablaDoc As String = "ADCDOC"
        Dim Bus_tablaTra As String = "ADCTRA"
        malla.DataSource = Nothing
        If tabla.ToUpper() = "ADCDOCPRO" Then
            Bus_tablaDoc = "AdcDocpro"
            Bus_tablaTra = "AdcTraPro"
        End If

        If (cboTipoDoc.SelectedValue Is Nothing) Then Exit Sub
        Dim campo As String = camp
        'Dim cls As New ClassDoc.utilDoc(buscadorDoc.strConxAdcom)
        '        lassDoc.utilDoc()

        If estaConsolidando And DocInicial.Length > 3 Then
            Bus_tipDoc = " and opc_documento in (" + DocInicial + ")"
        Else
            Bus_tipDoc = " and opc_documento ='" & cboTipoDoc.SelectedValue.ToString() & "' "
        End If


        'ClassDoc.utilDoc.cadenaConexion = buscadorDoc.strConxAdcom
        'ClassDoc.utilDoc.tablasDeDatos(cboTipoDoc.SelectedValue.ToString(), Bus_tablaDoc, Bus_tablaTra)
        'cls = Nothing
        Try
            If cboSucursal.SelectedValue.ToString() <> "0" And cboSucursal.SelectedValue.ToString() <> "" Then
                Bus_suc = " and doc_sucursal = '" & cboSucursal.SelectedValue.ToString() & "' "
            End If
        Catch
        End Try

        Try
            If cboPtoVenta.SelectedValue.ToString() <> "0" And cboPtoVenta.SelectedValue.ToString() <> "" Then
                Bus_PtoVta = " and puntovta ='" & cboPtoVenta.SelectedValue.ToString() & "' "
            End If
        Catch
        End Try


        If cboBodega.SelectedValue.ToString() <> "0" And cboBodega.SelectedValue.ToString() <> "" Then
            Bus_bod = " and doc_bodega ='" & cboBodega.SelectedValue.ToString() & "' "
        End If

        If txtClienteCod.Text <> "" Then
            Bus_client = " and (doc_codper ='" & txtClienteCod.Text & "' or Doc_CiRuc ='" & txtClienteCod.Text & "') "
        End If

        If txtDetalle.Text <> "" Then
            Bus_det = " and doc_detalle like '%" & txtDetalle.Text & "%'"
        End If

        If txtArtCodigo.Text <> "" Then
            Bus_art = " and idClaveDoc in(select DISTINCT idclaveDoc from " & Bus_tablaTra & " where tra_codigo ='" & txtArtCodigo.Text & "') "
        End If

        If txtvalor.Text <> "" Then
            Bus_valor = " and doc_valor like '%" & txtvalor.Text & "%'"
        End If

        If txtNumDoc.Text <> "" Then
            numero = " and Doc_NroLoteDoc ='" & txtNumDoc.Text & "'"
        End If

        Dim ssql As String = "select doc_sucursal as SUC, opc_documento as TIP"
        ssql += ",doc_fecha as FECHA,doc_numero as NUM,Doc_NombreImp as NOMBRE, doc_valor as VALOR"
        ssql += ",Doc_detalle as DETALLE,doc_codper, idClaveDoc,isnull(estadosri,'') as EstadoSri  from " & Bus_tablaDoc & ""
        ssql += " where doc_fecha>= '" & txtFechaIn.Text & "' and doc_fecha<= '" & txtFechaFin.Text & " 23:59:59' "
        ssql += Bus_tipDoc & Bus_suc & Bus_bod & Bus_PtoVta & Bus_client & Bus_art & Bus_det & Bus_valor & numero

        If cmbAutorizaciones.SelectedIndex = 2 Then
            ssql += " and (isnull(EstadoSri,'') = 'Autorizado')"
        ElseIf cmbAutorizaciones.SelectedIndex = 1 Then
            ssql += " and (isnull(EstadoSri,'') <> 'Autorizado')"
        End If

        If cmbActivos.SelectedIndex = 2 Then
            ssql += " and (isnull(doc_estado,0) = 0)"
        ElseIf cmbAutorizaciones.SelectedIndex = 1 Then
            ssql += " and (isnull(doc_estado,0) = 1)"
        End If

        Dim dats As New DataSet()
        Dim datAd As New SqlDataAdapter(ssql, conexion)
        If conexion.State = ConnectionState.Closed Then conexion.Open()
        datAd.Fill(dats, "Datos")
        With malla
            .DataSource = dats.Tables("Datos")
            .ClearSelection()
            .Columns("doc_codper").Visible = False
            .Columns("idclavedoc").Visible = False
            .Columns("fecha").DefaultCellStyle.Format = "dd/MMM/yyyy"
            .Columns("Valor").DefaultCellStyle.Format = "###,###,###,##0.00"
            .Columns("Detalle").Visible = False
        End With
        conexion.Close()
    End Sub
    'Metodo para llenar el combo tipo documento
    'Private Sub llenarTipoDoc(ByVal LisTipoDocu As String, ByVal LisOpcDoc As String)
    '    Dim ssql As String = ""
    '    ' Dim opc(), tipo() As String
    '    If tabla = "" Then Exit Sub

    '    If LisTipoDocu = "" Then
    '        ssql = "select opc_documento,Doc_docnombre from ADCOPC where opc_documento in (" & LisOpcDoc & ") "
    '        camp = "opc_documento"
    '    Else
    '        ssql = "select doc_TipoDoc,Doc_docnombre from ADCOPC  where Doc_TipoDoc in (" & LisTipoDocu & ") group by doc_TipoDoc,doc_docnombre"
    '        camp = "doc_TipoDoc"
    '    End If

    '    Dim dats As New DataSet()
    '    Dim datA As New SqlDataAdapter(ssql, conexion)
    '    If conexion.State = ConnectionState.Closed Then conexion.Open()
    '    datA.Fill(dats, "Datos")
    '    cboTipoDoc.DataSource = dats.Tables("Datos")
    '    cboTipoDoc.DisplayMember = "Doc_docnombre"
    '    If LisTipoDocu = "" Then cboTipoDoc.ValueMember = "opc_documento" Else cboTipoDoc.ValueMember = "Doc_TipoDoc"
    '    conexion.Close()
    'End Sub
    'Metodo para llenar los combos Bodega y Sucursal
    'Private Sub llenarBodegaSucurasal(ByVal ssql As String, ByVal cbo As ComboBox)
    '    Dim con As New SqlConnection()
    '    Dim coneccion As New DaxLib.DaxLibBases
    '    coneccion.TipoBase = "10"
    '    con.ConnectionString = coneccion.StrDaxsys
    '    Dim datS As New DataSet()
    '    Dim datA As New SqlDataAdapter(ssql, con)
    '    If con.State = ConnectionState.Closed Then con.Open()
    '    datA.Fill(datS, "Datos")
    '    cbo.DataSource = datS.Tables("Datos")
    '    cbo.ValueMember = "Abreviación"
    '    cbo.DisplayMember = "Descripcion"
    '    con.Close()
    'End Sub

    Private Sub txtFechaIn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaIn.KeyDown
        If e.KeyCode = Keys.Return Then
            CargarMalla()
            Return
        End If
        'If e.KeyCode <> Keys.F2 Then Return
        'Dim progfec As New DaxFechas.DaxFechas
        'Dim lafecha As String = ""
        'txtFechaIn.Text = progfec.DaxFecha(lafecha)
    End Sub

    Private Sub txtFechaFin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFechaFin.KeyDown
        If e.KeyCode = Keys.Return Then
            CargarMalla()
            Return
        End If
        'If e.KeyCode <> Keys.F2 Then Return
        'Dim progfec As New DaxFechas.DaxFechas
        'Dim lafecha As String = ""
        'txtFechaFin.Text = progfec.DaxFecha(lafecha)
    End Sub

#End Region

#Region "Panel Opciones"

    'Metodo para mostrar u ocultar el panel de opciones
    'Metodo para inicializar las cajas de texto del panel de opciones
    Private Sub limpiar()
        txtArtCodigo.Text = ""
        txtArticuloNombre.Text = ""
        txtClienteCod.Text = ""
        txtClienteNombre.Text = ""
        txtDetalle.Text = ""
        txtvalor.Text = ""
    End Sub
    'Metodo para limpiar la malla
    Private Sub limpiarGrid()
        With malla
            For i = .RowCount - 2 To 0 Step -1
                If i <= .Rows.Count Then .Rows.RemoveAt(i)
            Next
        End With
    End Sub
    Private Sub opcionPanel()

    End Sub
    Private Sub cboTipoDoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If cargar = True Then CargarMalla()
    End Sub

    Private Sub cboSucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CargarMalla()
    End Sub

    Private Sub cboBodega_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CargarMalla()
    End Sub

    Private Sub txtDetalle_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDetalle.TextChanged
        CargarMalla()
    End Sub

    Private Sub txtArtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtArtCodigo.TextChanged
        CargarMalla()
    End Sub

    Private Sub txtvalor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtvalor.TextChanged
        CargarMalla()
    End Sub
#End Region


    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        limpiar()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        CargarMalla()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Lista = ""
        DocRet = ""
        SucRet = ""
        NumRet = 0
        idClaveDoc = 0
        If estaConsolidando Then
            If malla.SelectedRows.Count > 0 Then
                Dim aux As String = ""
                For Each row As DataGridViewRow In malla.SelectedRows
                    If idClaveDoc = 0 Then
                        DocRet = row.Cells("TIP").Value.ToString()
                        SucRet = row.Cells("SUC").Value.ToString()
                        NumRet = 0
                        idClaveDoc = CDbl(row.Cells("idClaveDoc").Value.ToString())
                    End If
                    Lista += aux + "'" + row.Cells("SUC").Value.ToString() + row.Cells("TIP").Value.ToString() + row.Cells("idClaveDoc").Value.ToString() + "'"
                    aux = ","
                Next
            End If
        Else
            malla_DoubleClick(sender, e)
        End If
        Me.Close()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub malla_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles malla.DoubleClick
        SucRet = ""
        DocRet = ""
        Lista = ""
        NumRet = 0
        idClaveDoc = 0
        Try
            If IsNothing(malla.CurrentRow) Then Return
            Dim row As DataGridViewRow = malla.CurrentRow()
            SucRet = (row.Cells("SUC").Value.ToString())
            DocRet = row.Cells("TIP").Value.ToString()
            idClaveDoc = CDbl(row.Cells("idClaveDoc").Value.ToString())
            NumRet = CDbl(row.Cells("NUM").Value.ToString())
            row.Dispose()
        Catch
        End Try
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub txtNumDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If InStr(1, "0123456789" & Chr(8) & Chr(13), e.KeyChar) = 0 Then e.KeyChar = CChar("")
    End Sub

    Private Sub txtNumDoc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CargarMalla()
    End Sub

    Private Sub btnClienteCod_Click(sender As System.Object, e As System.EventArgs) Handles btnClienteCod.Click
        Dim prog As New DaxMantDirectorio.BusDirectorio
        Dim nombre As String = ""
        txtClienteCod.Text = prog.BusDirect("", "", nombre, "", "", "")
        txtClienteNombre.Text = nombre
    End Sub

    Private Sub btnArticuloCod_Click(sender As System.Object, e As System.EventArgs) Handles btnArticuloCod.Click
        Dim progbus As New Buscar.frmBuscar
        Dim nombrar As New RetNombre.AdcNomb
        Dim nombre As String = ""
        txtArtCodigo.Text = progbus.Buscar(buscadorDoc.strConxAdcom, "select art_codigo,art_nombre from adcart", "art_codigo", "art_nombre", "", "Busca Artículos")
        txtArticuloNombre.Text = nombrar.RetornaNombreArticulo(txtArtCodigo.Text, buscadorDoc.strConxAdcom)
    End Sub

    Private Sub btnServicioCod_Click(sender As System.Object, e As System.EventArgs) Handles btnServicioCod.Click
        Dim progbus As New Buscar.frmBuscar
        Dim nombrar As New RetNombre.AdcNomb
        Dim nombre As String = ""
        txtArtCodigo.Text = progbus.Buscar(buscadorDoc.strConxAdcom, "select sev_codigo,sev_nombre from adcserv", "sev_codigo", "sev_nombre", "", "Busca Servicios")
        txtArticuloNombre.Text = nombrar.RetornaNombreServicio(txtArtCodigo.Text, buscadorDoc.strConxAdcom)
    End Sub

 Private Sub txtClienteCod_KeyDown(sender As Object, e As KeyEventArgs) Handles txtClienteCod.KeyDown
        If e.KeyCode = Keys.Return  And txtClienteCod.TextLength > 0 Then CargarMalla()
    End Sub


    'Private Sub malla_KeyDown(sender As Object, e As KeyEventArgs) Handles malla.KeyDown
    '    Dim row As New DataGridViewRow
    '    If (e.KeyCode = Keys.F2 Or e.KeyCode = Keys.Space) Then
    '        row = malla.CurrentRow
    '        If IsNothing(row.HeaderCell.Value) Then row.HeaderCell.Value = "X" : Return
    '        If row.HeaderCell.Value.ToString() = "" Then row.HeaderCell.Value = "X" Else row.HeaderCell.Value = ""

    '    End If
    'End Sub
End Class
