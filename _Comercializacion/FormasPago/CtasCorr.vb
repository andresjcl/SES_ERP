'Imports System.Data.SqlClient
'Imports ClassDoc


'Public  Class ctasCorrientes

'    Public Shared Sub GuardarAplicacionSimple(ByVal docOrg As idDocumento, docApl As idDocumento, ByVal CodPer As String,
'        ByVal ValoApli As Double, ByVal SNContado As Boolean, Optional ByVal ESPAGO As String = "", Optional ByVal numlin As Integer = 0)
'        Dim codsql As String
'        Dim Rs1doc As New DataTable
'        If numlin = 0 Then numlin = CInt(Rnd(3) * 1000)
'        'If conectarAdcomDx.State = ConnectionState.Closed Then InicioConeccion()

'        Dim conectarAdcomDx As New SqlConnection(datosEmpresa.strConxAdcom)

'        codsql = " FROM AdcApl WHERE doc_sucursal='" & docOrg.Sucursal & "' and opc_documento='" & docOrg.Tipo & "' and idclavedoc =" & docOrg.idClave &
'                " and apl_docapli = '" & docApl.Tipo & "' and idclavedocapl = " & docApl.idClave & " and apl_sucapli = '" & docApl.Sucursal & "'"
'        conectarAdcomDx.Open()
'        Dim cmd As New SqlCommand("delete" & codsql, conectarAdcomDx)
'        cmd.ExecuteNonQuery()
'        codsql = " FROM AdcApl WHERE apl_sucapli='" & docOrg.Sucursal & "' and apl_docapli='" & docOrg.Tipo & "' and idclavedocapl =" & docOrg.idClave &
'                " and opc_documento = '" & docApl.Tipo & "' and idclavedoc = " & docApl.idClave & " and doc_sucursal = '" & docApl.Sucursal & "'"
'        cmd = New SqlCommand("delete" & codsql, conectarAdcomDx)
'        cmd.ExecuteNonQuery()
'        Dim aplData As New AdcApl(datosEmpresa.strConxAdcom)
'        AdcApl.CadenaSelect = " select * FROM AdcApl WHERE doc_sucursal='" & docOrg.Sucursal & "' and opc_documento='" & docOrg.Tipo & "' and idclavedoc =" & docOrg.idClave
'        With aplData
'            .Doc_sucursal = Trim$(docOrg.Sucursal)
'            .Opc_documento = Trim$(docOrg.Tipo)
'            .Doc_numero = CDec(docOrg.numero)
'            .Apl_sucapli = Trim$(docApl.Sucursal)
'            .Apl_docapli = Trim$(docApl.Tipo)
'            .Apl_numapli = CDec(docApl.numero)
'            .Apl_docfecha = docOrg.fecha
'            .Apl_fecha = docApl.fecha
'            .Apl_valorapl = CDec(ValoApli)
'            .Apl_codbenef = CodPer
'            .Apl_DocGar = ""
'            .Apl_NumGar = 0
'            If SNContado = True Then .Apl_SNContado = True Else .Apl_SNContado = False
'            .IdClaveDoc = CDec(docOrg.idClave)
'            .IdClaveDocApl = CDec(docApl.idClave)
'            .IdClaveDocGar = 0
'            .CodConcepto = ""
'            .DescripcionConcepto = ""
'            .tra_Ventas = 0
'            .tra_Compras = 0
'            .tra_Banco = 0
'            .tra_CtasCobrar = False
'            .tra_CtasPagar = 0
'            .tra_esanticipo = False
'            .tra_costo = ""
'            .tra_centroproduccion = ""
'            .tra_centrodistribucion = ""
'            .tra_empleado = ""
'            .Tra_Proyecto = ""
'            .tra_directorio = ""
'            .Pag_DocPagoSucursal = ""
'            .espago = ESPAGO
'            .tra_escontable = False
'            .apl_valorcierre = 0
'            .Idclaveapl = 0
'            .Idclaveaplapl = 0
'            .CodConcepto = ""
'            .numLinApl = numlin

'            .Crear()
'        End With
'        aplData = Nothing
'    End Sub
'End Class
