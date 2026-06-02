
Public Class buscadorDoc

    Public Shared strConxAdcom As String
    Public Shared strConxDaxsys As String

    Public Sub New(strAdc As String, strSys As String)
        strConxAdcom = strAdc
        strConxDaxsys = strSys
    End Sub
    Public Function IniciaBusqueda(ByVal claseDocumentos As String, ByVal codCliente As String, ByVal tipDocAConsultar As String, ByVal IniFec As Date,
            ByRef EsSuc As String, ByRef EsTipDoc As String, ByRef EsNumDoc As Double, ByRef idClaveDocapl As Double, Optional SinArt As Boolean = False _
          , Optional tipDocQueInicia As String = "", Optional ByVal TipoLiquidacion As String = "", Optional ByVal NroLiquidacion As String = "", Optional Tabla As String = "") As Double
        Dim prog As New frmBuscarDoc
        'MsgBox(" " & tipDocOriginal & " - " & codCliente & " - " & tipDocAConsultar & " - " & EsTipDoc)
        With prog
            .claseDoctosPermitidos = claseDocumentos   ' clase de documentos 
            .Codigo = codCliente
            .Solodoc = tipDocAConsultar
            .sinArt = SinArt
            .LiquidacionTip = TipoLiquidacion
            .LiquidacionNum = NroLiquidacion
            ' tipo de documento que llamo a la copiadora
            .DocInicial = tipDocQueInicia
            .tabla = Tabla
            .docSucursal = EsSuc
            If IsDate(IniFec) And IniFec > CDate("0:00:00") Then .InicFec = IniFec Else .InicFec = Now.Date
            .ShowDialog()
            EsSuc = .SucRet
            EsTipDoc = .DocRet
            EsNumDoc = .NumRet
            idClaveDocapl = .idClaveDoc
            IniciaBusqueda = .NumRet
        End With
        prog.Dispose()
    End Function

    Public Function IniciaConsolidacion(ByVal claseDocumentos As String, ByVal codCliente As String, ByVal tipDocAConsultar As String, ByVal IniFec As Date,
        ByRef EsSuc As String, ByRef EsTipDoc As String, ByRef EsNumDoc As Double, ByRef idClaveDocapl As Double, Optional SinArt As Boolean = False _
      , Optional tipDocQueInicia As String = "", Optional ByVal TipoLiquidacion As String = "", Optional ByVal NroLiquidacion As String = "", Optional Tabla As String = "") As String
        Dim prog As New frmBuscarDoc
        'MsgBox(" " & tipDocOriginal & " - " & codCliente & " - " & tipDocAConsultar & " - " & EsTipDoc)
        With prog
            .claseDoctosPermitidos = ""   ' clase de documentos 
            .Codigo = codCliente
            .Solodoc = ""
            .sinArt = SinArt
            .LiquidacionTip = TipoLiquidacion
            .LiquidacionNum = NroLiquidacion
            .DocInicial = claseDocumentos
            .tabla = Tabla
            .docSucursal = EsSuc
            If IsDate(IniFec) And IniFec > CDate("0:00:00") Then .InicFec = IniFec Else .InicFec = Now.Date
            prog.estaConsolidando = True
            .ShowDialog()
            EsSuc = .SucRet
            EsTipDoc = .DocRet
            EsNumDoc = .NumRet
            idClaveDocapl = .idClaveDoc
            IniciaConsolidacion = .DocRet
            Return prog.Lista
        End With
        prog.Dispose()
    End Function
End Class
