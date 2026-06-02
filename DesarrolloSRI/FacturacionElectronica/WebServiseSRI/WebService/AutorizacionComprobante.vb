Imports System.Xml

Friend Class AutorizacionComprobante

#Region "VARIABLES"

    Private estadoSRIValue As RespuestaSRYType = RespuestaSRYType.NOAUTORIZADO
    Private claveAccesoConsultadaValue As String = String.Empty
    Private autorizacionesValue As New List(Of Comprobante)
    Private autorizacionValue As Comprobante = Nothing
    Private soapStringValue As String = String.Empty

#End Region

#Region "PROPERTIES"

    Public ReadOnly Property EstadoSRI() As RespuestaSRYType
        Get
            Return estadoSRIValue
        End Get
    End Property

    Public ReadOnly Property SoapString() As String
        Get
            Return soapStringValue
        End Get
    End Property

    Public ReadOnly Property Autorizacion() As Comprobante
        Get
            If autorizacionValue IsNot Nothing Then
                Return autorizacionValue
            ElseIf autorizacionesValue.Count > 0 Then
                Return autorizacionesValue(0)
            Else
                Return New Comprobante(ClaveAccesoConsultada, String.Empty)
            End If
        End Get
    End Property

    Public ReadOnly Property Autorizaciones() As List(Of Comprobante)
        Get
            Return autorizacionesValue
        End Get
    End Property

    Public ReadOnly Property ClaveAccesoConsultada() As String
        Get
            Return claveAccesoConsultadaValue
        End Get
    End Property

#End Region

#Region "CONSTRUCTOR"

    Friend Sub New(ByVal soapString As String)
        soapStringValue = soapString.Trim
        '----------------------------------------------------------------
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
            document.PreserveWhitespace = True
            '------------------------------------------------------------
            document.LoadXml(soapStringValue)
            '------------------------------------------------------------
            readXML(document)
        Catch ex As Exception
            Throw New Exception(String.Concat("Read XML Autorizacion:", vbCrLf, ex.Message))
        End Try
        '----------------------------------------------------------------
        document = Nothing
    End Sub

    Private Sub readXML(ByVal document As XmlDocument)
        '----------------------------------------------------------------
        'INICIALIZO LAS VARIABLES
        '----------------------------------------------------------------
        autorizacionValue = Nothing
        estadoSRIValue = RespuestaSRYType.NOAUTORIZADO
        '----------------------------------------------------------------
        For Each nodeChild As XmlNode In document.GetElementsByTagName("RespuestaAutorizacionComprobante")
            claveAccesoConsultadaValue = nodeChild.Item("claveAccesoConsultada").InnerText
        Next
        '----------------------------------------------------------------
        'LEEMOS LAS AUTORIZACIONES
        '----------------------------------------------------------------
        For Each nodeChild As XmlNode In document.GetElementsByTagName("autorizaciones")
            readAutorizaciones(nodeChild)
        Next
    End Sub

    Private Sub readAutorizaciones(ByVal nodeParent As XmlNode)
        For Each nodeChild As XmlNode In nodeParent.ChildNodes
            Dim autorizacion As New Comprobante
            Dim nodeMensajes As XmlElement = Nothing
            '--------------------------------------------------------------------
            autorizacion.SoapString = nodeChild.OuterXml
            autorizacion.ClaveAcceso = claveAccesoConsultadaValue
            autorizacion.Estado = nodeChild.Item("estado").InnerText
            '--------------------------------------------------------------------
            If autorizacion.Estado = "EN PROCESO" Then
                autorizacion.EstadoSRI = RespuestaSRYType.PENDIENTE
                estadoSRIValue = RespuestaSRYType.PENDIENTE
            Else
                autorizacion.Ambiente = nodeChild.Item("ambiente").InnerText
                autorizacion.Comprobante = nodeChild.Item("comprobante").InnerText
                autorizacion.FechaAutorizacion = Date.Parse(nodeChild.Item("fechaAutorizacion").InnerText.Trim).ToString
            End If
            '--------------------------------------------------------------------
            'VERIFICO SI ESTA AUTORIZADO
            '--------------------------------------------------------------------
            If autorizacion.Estado = "AUTORIZADO" Then
                autorizacion.NumeroAutorizacion = nodeChild.Item("numeroAutorizacion").InnerText
                autorizacion.EstadoSRI = RespuestaSRYType.AUTORIZADO
                '----------------------------------------------------------------
                estadoSRIValue = RespuestaSRYType.AUTORIZADO
                '----------------------------------------------------------------
                autorizacionValue = autorizacion
            End If
            '--------------------------------------------------------------------
            nodeMensajes = nodeChild.Item("mensajes")
            '--------------------------------------------------------------------
            If nodeMensajes IsNot Nothing Then
                readMensajes(nodeMensajes, autorizacion)
            End If
            '--------------------------------------------------------------------
            autorizacionesValue.Add(autorizacion)
            '--------------------------------------------------------------------
            nodeMensajes = Nothing
            autorizacion = Nothing
        Next
    End Sub

    Private Sub readMensajes(ByVal nodeParent As XmlNode, ByVal autorizacion As Comprobante)
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
            If estadoSRIValue <> RespuestaSRYType.AUTORIZADO Then
                If m.Identificador = CStr(70) Then
                    autorizacion.EstadoSRI = RespuestaSRYType.PENDIENTE
                    estadoSRIValue = RespuestaSRYType.PENDIENTE
                ElseIf m.Identificador = CStr(45) Then
                    estadoSRIValue = RespuestaSRYType.DEVUELTA
                End If
            End If
            '--------------------------------------------------------------------
            If m.Identificador <> CStr(60) Then
                autorizacion.Mensajes.Add(m)
            End If
            '--------------------------------------------------------------------
            x = Nothing
            m = Nothing
        Next
    End Sub

#End Region

End Class