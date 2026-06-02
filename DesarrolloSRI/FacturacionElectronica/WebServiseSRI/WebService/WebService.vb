Imports System.Xml.Schema
Imports System.Text
Imports System.Xml
Imports System.Net
Imports System.IO

Public Class WebService

#Region "VARIABLES DE WEB SERVICE"

    Private Shared wsAutorizacionValue As New Dictionary(Of Integer, String)
    Private Shared wsRecepcionValue As New Dictionary(Of Integer, String)

#End Region

#Region "VARIABLES"

    Private comprobanteValue As Comprobante = Nothing

    Private tipoEmisionValue As Integer
    Private tipoAmbienteValue As Integer

    Private rucValue As String = String.Empty
    Private claveAccesoValue As String = String.Empty
    Private xmlStringBase64Value As String = String.Empty

    Private timeOutRecepcionValue As Integer = 7000
    Private timeOutAutorizacionValue As Integer = 15000
    Private timeWaitSendAutorizacionValue As Integer = 250

    Private proxyHostValue As String = String.Empty
    Private proxyPortValue As Integer

    Private isOffLineValue As Boolean = True

    Private xmlStringSRIValue As String = String.Empty
    Private messageSoapValue As String = String.Empty

#End Region

#Region "CONSTRUCTOR"

    Sub New()
        loadWebSericeSRI()
    End Sub

#End Region

#Region "PROPERTIES"

    '''<summary>
    '''Obtiene el contenido de la respuesta emitida en formato XML por parte del SRI
    '''</summary>
    Public ReadOnly Property XMLStringSRI() As String
        Get
            Return xmlStringSRIValue
        End Get
    End Property

    '''<summary>
    '''Obtiene o establece un valor que indica si se debe usar el esquema OFFLINE
    '''</summary>
    Public Property IsOFFLine() As Boolean
        Get
            Return isOffLineValue
        End Get
        Set(ByVal value As Boolean)
            isOffLineValue = value
        End Set
    End Property

    '''<summary>
    '''Host del Proxy
    '''</summary>
    Public Property ProxyHost() As String
        Get
            Return proxyHostValue
        End Get
        Set(ByVal value As String)
            proxyHostValue = value
        End Set
    End Property

    '''<summary>
    '''Puerto del proxy
    '''</summary>
    Public Property ProxyPort() As Integer
        Get
            Return proxyPortValue
        End Get
        Set(ByVal value As Integer)
            proxyPortValue = value
        End Set
    End Property

    '''<summary>
    '''Permitira obtener los datos importantes del cotnenido XMl como los datos de Autorizacion
    '''</summary>
    Public ReadOnly Property Comprobante() As Comprobante
        Get
            If comprobanteValue Is Nothing Then
                Return New Comprobante(claveAccesoValue, messageSoapValue)
            Else
                Return comprobanteValue
            End If
        End Get
    End Property

    '''<summary>
    '''Clave de Acceso del comprobante XML
    '''</summary>
    Public ReadOnly Property ClaveAcceso() As String
        Get
            Return claveAccesoValue
        End Get
    End Property

    '''<summary>
    '''Tipo de Ambiente del comprobante XML
    '''</summary>
    Public ReadOnly Property TipoAmbiente() As Integer
        Get
            Return tipoAmbienteValue
        End Get
    End Property

    '''<summary>
    '''Tipo de Emision del comprobante XML
    '''</summary>
    Public ReadOnly Property TipoEmision() As Integer
        Get
            Return tipoEmisionValue
        End Get
    End Property

    '''<summary>
    '''Tiempo expresado en milisegundos que debe esperar para obtener respuesta del WebServices de Recepcion
    '''</summary>
    Public Property TimeOutRecepcion() As Integer
        Get
            Return timeOutRecepcionValue
        End Get
        Set(ByVal value As Integer)
            If value >= 5000 AndAlso value <= 100000 Then
                timeOutRecepcionValue = value
            End If
        End Set
    End Property

    '''<summary>
    '''Tiempo expresado en milisegundos que debe esperar para obtener respuesta del WebServices de Autorizacion
    '''</summary>
    Public Property TimeOutAutorizacion() As Integer
        Get
            Return timeOutAutorizacionValue
        End Get
        Set(ByVal value As Integer)
            If value >= 5000 AndAlso value <= 100000 Then
                timeOutAutorizacionValue = value
            End If
        End Set
    End Property

    '''<summary>
    '''Tiempo expresado en milisegundos que debe esperar para enviar a pedir la autorizacion luego de haber sido validado por los WebServices del SRI
    '''</summary>
    Public Property TimeWaitSendAutorizacion() As Integer
        Get
            Return timeWaitSendAutorizacionValue
        End Get
        Set(ByVal value As Integer)
            If value > 0 AndAlso value <= 300000 Then
                timeWaitSendAutorizacionValue = value
            End If
        End Set
    End Property

#End Region

#Region "GET SOAP"

    Private Function getSoapValidacion(ByVal xml As String) As String
        Dim str As New System.Text.StringBuilder
        '---------------------------------------------------------------------------------------------
        str.AppendLine("<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ec=""http://ec.gob.sri.ws.recepcion"">")
        str.AppendLine("<soapenv:Header/>")
        str.AppendLine("<soapenv:Body>")
        str.AppendLine("<ec:validarComprobante>")
        str.AppendLine("<xml>{0}</xml>")
        str.AppendLine("</ec:validarComprobante>")
        str.AppendLine("</soapenv:Body>")
        str.AppendLine("</soapenv:Envelope>")
        '---------------------------------------------------------------------------------------------
        Return String.Format(str.ToString, xml)
    End Function

    Private Function getSoapAutorizacion(ByVal claveAccesoComprobante As String) As String
        Dim str As New System.Text.StringBuilder
        '---------------------------------------------------------------------------------------------
        str.AppendLine("<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ec=""http://ec.gob.sri.ws.autorizacion"">")
        str.AppendLine("<soapenv:Header/>")
        str.AppendLine("<soapenv:Body>")
        str.AppendLine("<ec:autorizacionComprobante>")
        str.AppendLine("<claveAccesoComprobante>{0}</claveAccesoComprobante>")
        str.AppendLine("</ec:autorizacionComprobante>")
        str.AppendLine("</soapenv:Body>")
        str.AppendLine("</soapenv:Envelope>")
        '---------------------------------------------------------------------------------------------
        Return String.Format(str.ToString, claveAccesoComprobante)
    End Function

#End Region

#Region "SEND COMPROBANTE"

    '''<summary>
    '''Permite enviar a autorizar el documento XML a los WebServices del SRI
    '''</summary>
    '''<param name="fileNameXML">Ruta del archivo XML firmado</param>
    '''<param name="fileNameRespSRI">Ruta donde se almacenara la respuesta del SRI</param>
    Public Function SendComprobante(ByVal fileNameXML As String, ByVal fileNameRespSRI As String) As RespuestaSRYType
        Dim retVal As RespuestaSRYType = RespuestaSRYType.NOAUTORIZADO
        '--------------------------------------------------------------------------------------------------------
        If readFileNameXML(fileNameXML) Then
            If My.Computer.Network.IsAvailable Then
                retVal = processSendComprobante(fileNameRespSRI)
            Else
                retVal = RespuestaSRYType.SINCONEXION
            End If
        Else
            retVal = RespuestaSRYType.NOLEEXML
        End If
        '--------------------------------------------------------------------------------------------------------
        If retVal = RespuestaSRYType.SINCONEXION Then
            If messageSoapValue = String.Empty Then
                messageSoapValue = "!!!No hay conexion a Internet.¡¡¡"
            End If
        End If
        If retVal = RespuestaSRYType.NOLEEXML Then
            If messageSoapValue = String.Empty Then
                messageSoapValue = "!!!No se puede leer el archivo XML¡¡¡ " + fileNameXML
            End If
        End If
        '--------------------------------------------------------------------------------------------------------
        Return retVal
    End Function

    Public Function IsAccesibleWS(Optional ByVal ambiente As Integer = 2) As Boolean
        Dim s As String = String.Empty
        Dim w As New WebClient
        '--------------------------------------------------------------------------------
        Try
            s = w.UploadString(wsRecepcionValue(CInt(TipoAmbiente)), getSoapValidacion(String.Empty))
        Catch ex As WebException
        End Try
        '--------------------------------------------------------------------------------
        w.Dispose()
        '--------------------------------------------------------------------------------
        Return s <> String.Empty
    End Function

#End Region

#Region "PROCESS SEND COMPROBANTE"

    Private Function ProcessRecepcionComprobante(ByVal value As String) As RecepcionComprobante
        Return New RecepcionComprobante(executeWebServiceHTTP(value, AcctionType.RECEPCION))
    End Function

    Private Function ProcessAutorizacionComprobante(ByVal value As String) As AutorizacionComprobante
        Return New AutorizacionComprobante(executeWebServiceHTTP(value, AcctionType.AUTORIZACION))
    End Function

    Private Function processSendComprobante(ByVal fileNameRespSRI As String) As RespuestaSRYType
        Dim autorizacionComprobanteValue As AutorizacionComprobante = Nothing
        Dim recepcionComprobanteValue As RecepcionComprobante = Nothing
        Dim retVal As RespuestaSRYType = RespuestaSRYType.NOAUTORIZADO
        '--------------------------------------------------------------------------------------------------
        'verifico sino ha sido autorizado anteriormente o esta pendiente de autorizar
        '--------------------------------------------------------------------------------------------------
        autorizacionComprobanteValue = ProcessAutorizacionComprobante(claveAccesoValue)
        '--------------------------------------------------------------------------------------------------
        'BUG POR PROBLEMA QUE EL SRI A VECES DEVUELVE EL COMPROBANTE CON ESTADO [EN PROCESO]
        '--------------------------------------------------------------------------------------------------
        If autorizacionComprobanteValue.EstadoSRI = RespuestaSRYType.PENDIENTE Then
            If isOffLineValue Then
                isOffLineValue = False
                '------------------------------------------------------------------------------------------
                autorizacionComprobanteValue = ProcessAutorizacionComprobante(claveAccesoValue)
                '------------------------------------------------------------------------------------------
                isOffLineValue = True
            End If
        End If
        '--------------------------------------------------------------------------------------------------
        'verifico si hubo conexion con los webservices del sri
        '--------------------------------------------------------------------------------------------------
        If autorizacionComprobanteValue.SoapString = String.Empty Then
            retVal = RespuestaSRYType.SINCONEXION
        Else
            If autorizacionComprobanteValue.EstadoSRI = RespuestaSRYType.NOAUTORIZADO Then
                '------------------------------------------------------------------------------------------
                'envio a validar el comprobante
                '------------------------------------------------------------------------------------------
                recepcionComprobanteValue = ProcessRecepcionComprobante(xmlStringBase64Value)
                '------------------------------------------------------------------------------------------
                'verifico si hubo conexion con los webservices del sri
                '------------------------------------------------------------------------------------------
                If recepcionComprobanteValue.SoapString = String.Empty Then
                    retVal = RespuestaSRYType.SINCONEXION
                Else
                    If recepcionComprobanteValue.EstadoSRI = RespuestaSRYType.RECIBIDA Then
                        '----------------------------------------------------------------------------------
                        If timeWaitSendAutorizacionValue <> 0 Then
                            System.Threading.Thread.Sleep(timeWaitSendAutorizacionValue)
                        End If
                        '----------------------------------------------------------------------------------
                        'ejecuto 3 veces si es que no me trae nada en la primera ocasion
                        '----------------------------------------------------------------------------------
                        For x As Integer = 1 To 3
                            autorizacionComprobanteValue = ProcessAutorizacionComprobante(claveAccesoValue)
                            '------------------------------------------------------------------------------
                            If autorizacionComprobanteValue.Autorizaciones.Count > 0 OrElse autorizacionComprobanteValue.SoapString = String.Empty Then
                                Exit For
                            End If
                        Next
                        '----------------------------------------------------------------------------------
                        If autorizacionComprobanteValue.Autorizaciones.Count <= 0 Then
                            retVal = RespuestaSRYType.PENDIENTE
                        Else
                            retVal = autorizacionComprobanteValue.EstadoSRI
                        End If
                        '----------------------------------------------------------------------------------
                        comprobanteValue = autorizacionComprobanteValue.Autorizacion
                    Else
                        comprobanteValue = recepcionComprobanteValue.Comprobante
                    End If
                End If
            Else
                If autorizacionComprobanteValue.EstadoSRI <> RespuestaSRYType.DEVUELTA Then
                    retVal = autorizacionComprobanteValue.EstadoSRI
                End If
                '-------------------------------------------------------------------------------------------
                comprobanteValue = autorizacionComprobanteValue.Autorizacion
            End If
        End If
        '---------------------------------------------------------------------------------------------------
        If comprobanteValue Is Nothing Then
            comprobanteValue = New Comprobante(claveAccesoValue, messageSoapValue)
        ElseIf retVal = RespuestaSRYType.AUTORIZADO Then
            writeXML(comprobanteValue, fileNameRespSRI)
        End If
        '---------------------------------------------------------------------------------------------------
        Return retVal
    End Function

#End Region

#Region "RESPUESTA DE WEB SERVICE"

    Private Function executeWebServiceHTTP(ByVal VALUE As String, ByVal ACCTION As AcctionType) As String
        Dim myRequest As HttpWebRequest = Nothing
        Dim response As HttpWebResponse = Nothing
        Dim retVal As String = String.Empty
        Dim sendValue() As Byte = Nothing
        Dim uri As String = String.Empty
        Dim stm As IO.Stream = Nothing
        Dim d As DateTime = Date.Now
        Dim timeOutValue As Integer
        '---------------------------------------------------------------------------------------------
        messageSoapValue = String.Empty
        '---------------------------------------------------------------------------------------------
        Try
            '-----------------------------------------------------------------------------------------
            uri = getUrlWebService(ACCTION)
            '-----------------------------------------------------------------------------------------
            If ACCTION = AcctionType.AUTORIZACION Then
                sendValue = Encoding.UTF8.GetBytes(getSoapAutorizacion(VALUE))
                timeOutValue = timeOutAutorizacionValue
            Else
                sendValue = Encoding.UTF8.GetBytes(getSoapValidacion(VALUE))
                timeOutValue = timeOutRecepcionValue
            End If
            '-----------------------------------------------------------------------------------------
            'CREO EL HTTPWEBREQUEST
            '-----------------------------------------------------------------------------------------
            myRequest = WebRequest.Create(uri)
            '-----------------------------------------------------------------------------------------
            myRequest.Timeout = timeOutValue
            '-----------------------------------------------------------------------------------------
            myRequest.ContentType = "text/xml; charset=""UTF-8"""
            myRequest.Accept = "text/xml"
            myRequest.Method = "POST"
            myRequest.ContentLength = sendValue.Length
            '-----------------------------------------------------------------------------------------
            myRequest.Headers.Add("SOAPAction", String.Empty)
            '-----------------------------------------------------------------------------------------
            'agrego el proxi si lo tuviese
            '-----------------------------------------------------------------------------------------
            If proxyHostValue <> String.Empty Then
                Dim proxy As WebProxy = Nothing
                '-------------------------------------------------------------------------------------
                If proxyPortValue <> 0 Then
                    proxy = New WebProxy(proxyHostValue, proxyPortValue)
                Else
                    proxy = New WebProxy(proxyHostValue)
                End If
                '-------------------------------------------------------------------------------------
                myRequest.Proxy = proxy
                '-------------------------------------------------------------------------------------
                proxy = Nothing
            End If
            '-----------------------------------------------------------------------------------------
            Try
                stm = myRequest.GetRequestStream()
            Catch ex As Exception
                Throw New Exception(String.Concat("Error RequestStream: ", ex.Message))
            End Try
            '-----------------------------------------------------------------------------------------
            If stm IsNot Nothing Then
                If stm.CanWrite = True Then
                    stm.Write(sendValue, 0, sendValue.Length)
                    '---------------------------------------------------------------------------------
                    stm.Flush()
                    stm.Close()
                    '---------------------------------------------------------------------------------
                    stm.Dispose()
                Else
                    Throw New Exception("Error RequestStream: No se ha podido escribir datos.")
                End If
            Else
                Throw New Exception("Error RequestStream: No se ha podido obtener datos.")
            End If
            '-----------------------------------------------------------------------------------------
            Try
                response = myRequest.GetResponse()
            Catch ex As Exception
                Throw New Exception(String.Concat("Error Response: ", ex.Message))
            End Try
            '-----------------------------------------------------------------------------------------
            If response IsNot Nothing Then
                If response.StatusCode = HttpStatusCode.OK Then
                    Dim reader As New IO.StreamReader(response.GetResponseStream())
                    '---------------------------------------------------------------------------------
                    retVal = reader.ReadToEnd()
                    '---------------------------------------------------------------------------------
                    reader.Close()
                    reader.Dispose()
                    '---------------------------------------------------------------------------------
                    reader = Nothing
                Else
                    messageSoapValue = String.Concat("Error Response: HttpStatusCode ", response.StatusDescription)
                End If
                '-------------------------------------------------------------------------------------
                response.Close()
            Else
                messageSoapValue = "Error Response: No se ha podido obtener datos."
            End If
        Catch ex As Exception
            messageSoapValue = ex.Message
        End Try
        '---------------------------------------------------------------------------------------------
        If messageSoapValue <> String.Empty Then
            messageSoapValue = String.Format("WebServices <{0}> [ms:{1}] {2}", ACCTION.ToString, CType(Date.Now - d, TimeSpan).TotalMilliseconds.ToString("0.00"), messageSoapValue)
        End If
        '---------------------------------------------------------------------------------------------
        Return retVal
    End Function

#End Region

#Region "METODOS"

    Private Sub writeXML(ByVal autorizacion As Comprobante, ByVal outpahFile As String)
        If readXML(autorizacion) AndAlso outpahFile <> String.Empty Then
            Dim info As New System.IO.FileInfo(outpahFile)
            '--------------------------------------------------------------------------------------
            If info.Directory.Exists Then
                System.IO.File.WriteAllText(outpahFile, xmlStringSRIValue, New Text.UTF8Encoding(True))
            Else
                Throw New Exception(String.Format("La ruta [{0}] que ha ingresado no existe, no se podra crear la respuesta del SRI", info.DirectoryName))
            End If
            '--------------------------------------------------------------------------------------
            info = Nothing
        End If
    End Sub

    Private Function readXML(ByVal autorizacion As Comprobante) As Boolean
        Dim reader As IO.StreamReader = Nothing
        Dim settings As New XmlWriterSettings()
        Dim writer As XmlWriter = Nothing
        Dim stream As New IO.MemoryStream
        '-----------------------------------------------------------------------------------------
        xmlStringSRIValue = String.Empty
        '-----------------------------------------------------------------------------------------
        settings.Indent = True
        settings.Encoding = New UTF8Encoding(True)
        '-----------------------------------------------------------------------------------------
        writer = XmlWriter.Create(stream, settings)
        '-----------------------------------------------------------------------------------------
        writer.WriteProcessingInstruction("xml", "version=""1.0"" encoding=""utf-8""")
        '-----------------------------------------------------------------------------------------
        writer.WriteStartElement("autorizacion")
        '-----------------------------------------------------------------------------------------
        writer.WriteElementString("estado", autorizacion.Estado)
        '-----------------------------------------------------------------------------------------
        If autorizacion.NumeroAutorizacion <> String.Empty Then
            writer.WriteElementString("numeroAutorizacion", autorizacion.NumeroAutorizacion)
        End If
        '-----------------------------------------------------------------------------------------
        If autorizacion.FechaAutorizacion <> String.Empty Then
            writer.WriteStartElement("fechaAutorizacion")
            writer.WriteAttributeString("class", "fechaAutorizacion")
            writer.WriteString(autorizacion.FechaAutorizacion)
            writer.WriteEndElement()
        End If
        writer.WriteElementString("ambiente", autorizacion.Ambiente)

        '-----------------------------------------------------------------------------------------
        If autorizacion.Comprobante <> String.Empty Then
            writer.WriteStartElement("comprobante")
            writer.WriteCData(autorizacion.Comprobante)
            writer.WriteEndElement()
        Else
            writer.WriteElementString("claveAcceso", claveAccesoValue)
        End If
        '-----------------------------------------------------------------------------------------
        If autorizacion.Mensajes.Count > 0 AndAlso autorizacion.EstadoSRI <> RespuestaSRYType.AUTORIZADO Then
            writer.WriteStartElement("mensajes")
            '-------------------------------------------------------------------------------------
            For Each row As Mensaje In autorizacion.Mensajes
                writer.WriteStartElement("mensaje")
                '---------------------------------------------------------------------------------
                writer.WriteElementString("tipo", row.Tipo)
                writer.WriteElementString("identificador", row.Identificador)
                writer.WriteElementString("mensaje", row.Mensaje)
                '---------------------------------------------------------------------------------
                If row.InformacionAdicional <> String.Empty Then
                    writer.WriteElementString("informacionAdicional", row.InformacionAdicional)
                End If
                '---------------------------------------------------------------------------------
                writer.WriteEndElement()
            Next
            '-------------------------------------------------------------------------------------
            writer.WriteEndElement()
        End If
        '-----------------------------------------------------------------------------------------
        writer.WriteEndElement()
        '-----------------------------------------------------------------------------------------
        writer.Flush()
        writer.Close()
        '-----------------------------------------------------------------------------------------
        stream.Seek(0, IO.SeekOrigin.Begin)
        '-----------------------------------------------------------------------------------------
        reader = New IO.StreamReader(stream)
        '-----------------------------------------------------------------------------------------
        xmlStringSRIValue = reader.ReadToEnd()
        '-----------------------------------------------------------------------------------------
        reader.Close()
        reader.Dispose()
        '-----------------------------------------------------------------------------------------
        Return (xmlStringSRIValue <> String.Empty)
    End Function

    Private Sub loadWebSericeSRI()
        '--------------------------------------------------------------------------------------------------------
        'ONLINE
        '--------------------------------------------------------------------------------------------------------
        Try
            wsAutorizacionValue.Add(1, "https://celcer.sri.gob.ec/comprobantes-electronicos-ws/AutorizacionComprobantes?wsdl")
            wsAutorizacionValue.Add(2, "https://cel.sri.gob.ec/comprobantes-electronicos-ws/AutorizacionComprobantes?wsdl")
            '--------------------------------------------------------------------------------------------------------
            wsRecepcionValue.Add(1, "https://celcer.sri.gob.ec/comprobantes-electronicos-ws/RecepcionComprobantes?wsdl")
            wsRecepcionValue.Add(2, "https://cel.sri.gob.ec/comprobantes-electronicos-ws/RecepcionComprobantes?wsdl")
            '--------------------------------------------------------------------------------------------------------
            'OFFLINE
            '--------------------------------------------------------------------------------------------------------
            wsAutorizacionValue.Add(11, "https://celcer.sri.gob.ec/comprobantes-electronicos-ws/AutorizacionComprobantesOffline?wsdl")
            wsAutorizacionValue.Add(22, "https://cel.sri.gob.ec/comprobantes-electronicos-ws/AutorizacionComprobantesOffline?wsdl")
            '--------------------------------------------------------------------------------------------------------
            wsRecepcionValue.Add(11, "https://celcer.sri.gob.ec/comprobantes-electronicos-ws/RecepcionComprobantesOffline?wsdl")
            wsRecepcionValue.Add(22, "https://cel.sri.gob.ec/comprobantes-electronicos-ws/RecepcionComprobantesOffline?wsdl")
        Catch
        End Try
    End Sub

    Private Function getUrlWebService(ByVal ACCTION As AcctionType) As String
        Dim ambiente As Integer = tipoAmbienteValue
        Dim retVal As String = String.Empty
        '--------------------------------------------------------------------------------------------------------
        If isOffLineValue Then
            ambiente = (tipoAmbienteValue * 10) + tipoAmbienteValue
        End If
        '--------------------------------------------------------------------------------------------------------
        If ACCTION = AcctionType.AUTORIZACION Then
            If wsAutorizacionValue.ContainsKey(ambiente) Then
                retVal = wsAutorizacionValue(ambiente)
            End If
        Else
            If wsRecepcionValue.ContainsKey(ambiente) Then
                retVal = wsRecepcionValue(ambiente)
            End If
        End If
        '--------------------------------------------------------------------------------------------------------
        If retVal = String.Empty Then
            Throw New Exception(String.Format("El URL solicitado para el WebServices de [ {0} ] se encuentra vacio", ACCTION.ToString))
        End If
        '--------------------------------------------------------------------------------------------------------
        Return retVal
    End Function

    Private Function readFileNameXML(ByVal fileNameXML As String) As Boolean
        Dim document As New XmlDocument
        '--------------------------------------------------------------------------------------------------------
        xmlStringBase64Value = String.Empty
        messageSoapValue = String.Empty
        comprobanteValue = Nothing
        '--------------------------------------------------------------------------------------------------------
        If System.IO.File.Exists(fileNameXML) Then
            document.PreserveWhitespace = True
            '----------------------------------------------------------------------------------------------------
            document.LoadXml(System.IO.File.ReadAllText(fileNameXML))
            '----------------------------------------------------------------------------------------------------
            Try
                For Each node As XmlNode In document.SelectNodes(String.Format("{0}/infoTributaria", document.DocumentElement.Name))
                    rucValue = node.Item("ruc").InnerText
                    claveAccesoValue = node.Item("claveAcceso").InnerText
                    tipoAmbienteValue = CInt(node.Item("ambiente").InnerText)
                    tipoEmisionValue = CInt(node.Item("tipoEmision").InnerText)
                Next
            Catch
            End Try
            '----------------------------------------------------------------------------------------------------
            xmlStringBase64Value = ToBase64String(document.InnerXml)
        Else
            Throw New Exception(String.Concat("No se puede encontrar la ruta especificada, del archivo XML, ", fileNameXML))
        End If
        '--------------------------------------------------------------------------------------------------------
        Return (xmlStringBase64Value <> String.Empty)
    End Function

    Private Function ToBase64String(ByVal value As String) As String
        Return Convert.ToBase64String(Encoding.UTF8.GetBytes(value))
    End Function

#End Region

End Class