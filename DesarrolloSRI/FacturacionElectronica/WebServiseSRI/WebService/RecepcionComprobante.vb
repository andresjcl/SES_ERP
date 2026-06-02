Imports System.Xml

Friend Class RecepcionComprobante

#Region "VARIABLES"

    Private soapStringValue As String = String.Empty
    Private estadoValue As String = String.Empty
    Private comprobantesValue As New List(Of Comprobante)
    Private estadoSRIValue As RespuestaSRYType = RespuestaSRYType.DEVUELTA

#End Region

#Region "PROPERTIES"

    Public ReadOnly Property SoapString() As String
        Get
            Return soapStringValue
        End Get
    End Property

    Public ReadOnly Property Comprobantes() As List(Of Comprobante)
        Get
            Return comprobantesValue
        End Get
    End Property

    Public ReadOnly Property Comprobante() As Comprobante
        Get
            If comprobantesValue.Count > 0 Then
                Return comprobantesValue(0)
            Else
                Return Nothing
            End If
        End Get
    End Property

    Friend ReadOnly Property EstadoSRI() As RespuestaSRYType
        Get
            Return estadoSRIValue
        End Get
    End Property

    Public ReadOnly Property Estado() As String
        Get
            Return estadoValue
        End Get
    End Property

#End Region

#Region "CONSTRUCTOR"

    Friend Sub New(ByVal soapString As String)
        MyBase.New()
        '-----------------------------------------------------------------------------
        soapStringValue = soapString.Trim
        '-----------------------------------------------------------------------------
        If soapStringValue <> String.Empty Then
            readXML()
        End If
    End Sub

#End Region

#Region "METODOS"

    Private Sub readXML()
        Dim document As New System.Xml.XmlDocument
        '----------------------------------------------------------------
        Try
            document.LoadXml(soapStringValue)
            '------------------------------------------------------------
            readXML(document)
        Catch ex As Exception
            Throw New Exception(String.Concat("Read XML Recepcion:", vbCrLf, ex.Message))
        End Try
        '----------------------------------------------------------------
        document = Nothing
    End Sub

    Private Sub readXML(ByVal document As XmlDocument)
        For Each nodeChild As XmlNode In document.GetElementsByTagName("RespuestaRecepcionComprobante")
            estadoValue = nodeChild.Item("estado").InnerText
            '------------------------------------------------------------
            If estadoValue = "RECIBIDA" Then
                estadoSRIValue = RespuestaSRYType.RECIBIDA
            End If
            '------------------------------------------------------------
            readComprobantes(nodeChild.Item("comprobantes"))
        Next
    End Sub

    Private Sub readComprobantes(ByVal nodeParent As XmlNode)
        For Each nodeChild As XmlNode In nodeParent.ChildNodes
            Dim x As XmlElement = Nothing
            Dim comprobante As New Comprobante
            '-------------------------------------------------------------
            comprobante.Estado = estadoValue
            comprobante.EstadoSRI = estadoSRIValue
            '-------------------------------------------------------------
            comprobante.SoapString = nodeChild.OuterXml
            '-------------------------------------------------------------
            x = nodeChild.Item("claveAcceso")
            '-------------------------------------------------------------
            If x IsNot Nothing AndAlso x.InnerText <> "N/A" Then
                comprobante.ClaveAcceso = x.InnerText
                '---------------------------------------------------------
                If CInt(comprobante.ClaveAcceso.Substring(23, 1)) = 1 Then
                    comprobante.Ambiente = "PRUEBAS"
                Else
                    comprobante.Ambiente = "PRODUCCION"
                End If
            End If
            '-------------------------------------------------------------
            x = nodeChild.Item("mensajes")
            '-------------------------------------------------------------
            If x IsNot Nothing Then
                readMensajes(x, comprobante)
            End If
            '-------------------------------------------------------------
            comprobantesValue.Add(comprobante)
            '-------------------------------------------------------------
            comprobante = Nothing
        Next
    End Sub

    Private Sub readMensajes(ByVal nodeParent As XmlNode, ByVal comprobante As Comprobante)
        For Each nodeChild As XmlNode In nodeParent.ChildNodes
            Dim m As New Mensaje
            Dim x As XmlElement = Nothing
            '--------------------------------------------------------------------
            x = nodeChild.Item("identificador")
            If x IsNot Nothing Then
                m.Identificador = x.InnerText
            End If
            '--------------------------------------------------------------------
            x = nodeChild.Item("informacionAdicional")
            If x IsNot Nothing Then
                m.InformacionAdicional = x.InnerText
            End If
            '--------------------------------------------------------------------
            x = nodeChild.Item("mensaje")
            If x IsNot Nothing Then
                m.Mensaje = x.InnerText
            End If
            '--------------------------------------------------------------------
            x = nodeChild.Item("tipo")
            If x IsNot Nothing Then
                m.Tipo = x.InnerText
            End If
            '--------------------------------------------------------------------
            If m.Identificador <> CStr(60) Then
                comprobante.Mensajes.Add(m)
            End If
            '--------------------------------------------------------------------
            x = Nothing
            m = Nothing
        Next
    End Sub

#End Region

End Class