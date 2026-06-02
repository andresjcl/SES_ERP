using System.Text;
 using System.Xml;
 using System.Xml.Schema;
 using System.Net;
 using System.IO;

public class WebServiceSRI {
     
     private RecepcionComprobante recepcionValue = null;
     
     private AutorizacionComprobante autorizacionValue = null;
     
     private int tipoAmbienteValue;
     
     private int tipoEmisionValue;
     
     private int tipoEmisionSoapValue = 1;
     
     private string claveAccesoValue = String.Empty;
     
     private bool isOnLineValue;
     
     private static Dictionary wsAutorizacionValue = new Dictionary(Of, Integer, String);
     
     private static Dictionary wsRecepcionValue = new Dictionary(Of, Integer, String);
     
     WebServiceSRI() {
         loadWebSericeSRI();
     }
     
     public static Dictionary[] WSAutorizacion {
     }
     
     private Dictionary[] value;
}
 EndPropertySet(Of;
Integer;
,String;
UnknownUnknownwsRecepcionValue = value;
EndSetEndPropertyEndclass Unknown {
 }

     
     public static Dictionary[] WSRecepcion {
     }
     
     private Dictionary[] value;
     
     public RecepcionComprobante RecepcionComprobante {
         get {
             return recepcionValue;
         }
     }
     
     public AutorizacionComprobante AutorizacionComprobante {
         get {
             return autorizacionValue;
         }
     }
     
     public string ClaveAcceso {
         get {
             return claveAccesoValue;
         }
     }
     
     public int TipoAmbiente {
         get {
             return tipoAmbienteValue;
         }
     }
     
     public int TipoEmision {
         get {
             return tipoEmisionValue;
         }
     }
     
     public int TipoEmisionSoap {
         get {
             return tipoEmisionSoapValue;
         }
     }
     
     public bool IsOnLine {
         get {
             return isOnLineValue;
         }
     }
     
     private string getSoapValidacion(string xml, void =, void ) {
         System.Text.StringBuilder str = new System.Text.StringBuilder();
         // Warning!!! Optional parameters not supported
         // ---------------------------------------------------------------------------------------------
        str.AppendLine("<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ec=\"http://ec.gob.s" +
             "ri.ws.recepcion\">");
         str.AppendLine("<soapenv:Header/>");
         str.AppendLine("<soapenv:Body>");
         str.AppendLine("<ec:validarComprobante>");
         str.AppendFormat("<xml>{0}</xml>{1}", xml, "\r\n");
         str.AppendLine("</ec:validarComprobante>");
         str.AppendLine("</soapenv:Body>");
         str.AppendLine("</soapenv:Envelope>");
         // ---------------------------------------------------------------------------------------------
        getSoapValidacion = str.ToString;
         // ---------------------------------------------------------------------------------------------
        str = null;
     }
     
     private string getSoapAutorizacion(string claveAccesoComprobante) {
         System.Text.StringBuilder str = new System.Text.StringBuilder();
         // ---------------------------------------------------------------------------------------------
        str.AppendLine("<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ec=\"http://ec.gob.s" +
             "ri.ws.autorizacion\">");
         str.AppendLine("<soapenv:Header/>");
         str.AppendLine("<soapenv:Body>");
         str.AppendLine("<ec:autorizacionComprobante>");
         str.AppendFormat("<claveAccesoComprobante>{0}</claveAccesoComprobante>{1}", claveAccesoComprobante, "\r\n");
         str.AppendLine("</ec:autorizacionComprobante>");
         str.AppendLine("</soapenv:Body>");
         str.AppendLine("</soapenv:Envelope>");
         // ---------------------------------------------------------------------------------------------
        getSoapAutorizacion = str.ToString;
         // ---------------------------------------------------------------------------------------------
        str = null;
     }
     
     private string getSoapAutorizacionLote(string claveAccesoLote) {
         System.Text.StringBuilder str = new System.Text.StringBuilder();
         // ---------------------------------------------------------------------------------------------
        str.AppendLine("<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ec=\"http://ec.gob.s" +
             "ri.ws.autorizacion\">");
         str.AppendLine("<soapenv:Header/>");
         str.AppendLine("<soapenv:Body>");
         str.AppendLine("<ec:autorizacionComprobanteLote>");
         str.AppendFormat("<claveAccesoLote>{0}</claveAccesoLote>{1}", claveAccesoLote, "\r\n");
         str.AppendLine("</ec:autorizacionComprobanteLote>");
         str.AppendLine("</soapenv:Body>");
         str.AppendLine("</soapenv:Envelope>");
         // ---------------------------------------------------------------------------------------------
        getSoapAutorizacionLote = str.ToString;
         // ---------------------------------------------------------------------------------------------
        str = null;
     }
     
     private string getSoapAutorizacionLoteMasivo(string claveAccesoLote) {
         System.Text.StringBuilder str = new System.Text.StringBuilder();
         // ---------------------------------------------------------------------------------------------
        str.AppendLine("<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ec=\"http://ec.gob.s" +
             "ri.ws.autorizacion\">");
         str.AppendLine("<soapenv:Header/>");
         str.AppendLine("<soapenv:Body>");
         str.AppendLine("<ec:autorizacionComprobanteLoteMasivo>");
         str.AppendFormat("<claveAccesoLote>{0}</claveAccesoLote>{1}", claveAccesoLote, "\r\n");
         str.AppendLine("</ec:autorizacionComprobanteLoteMasivo>");
         str.AppendLine("</soapenv:Body>");
         str.AppendLine("</soapenv:Envelope>");
         // ---------------------------------------------------------------------------------------------
        getSoapAutorizacionLoteMasivo = str.ToString;
         // ---------------------------------------------------------------------------------------------
        str = null;
     }
     
     public bool sendComprobante(string fileName) {
         string xmlString = getOuterXML(fileName);
         bool retVal;
         // --------------------------------------------------------------------------------------------------------
        if ((xmlString != String.Empty)) {
             // ----------------------------------------------------------------------------------------------------
            // VERIFICO QUE EXISTA CONEXION A INTERNET
             // ----------------------------------------------------------------------------------------------------
            if ((My.Computer.Network.IsAvailable == true)) {
                 resetVariables();
                 // ------------------------------------------------------------------------------------------------
                // LEO LOS DATOS IMPORTANTES DEL ARCHIVO XML
                 // ------------------------------------------------------------------------------------------------
                readElements(xmlString);
                 // ------------------------------------------------------------------------------------------------
                retVal = processSendComprobante(Metodos.ToBase64String(xmlString));
             }
         }
         // --------------------------------------------------------------------------------------------------------
        return retVal;
     }
     
     private RecepcionComprobante ProcessRecepcionComprobante(string VALUE, EnvioType ENVIO, void =, void EnvioType.NORMAL) {
         ProcessRecepcionComprobante = new RecepcionComprobante(executeWebServiceCLIENT(VALUE, AcctionType.RECEPCION, ENVIO));
         // Warning!!! Optional parameters not supported
     }
     
     private AutorizacionComprobante ProcessAutorizacionComprobante(string VALUE, EnvioType ENVIO, void =, void EnvioType.NORMAL) {
         ProcessAutorizacionComprobante = new AutorizacionComprobante(executeWebServiceCLIENT(VALUE, AcctionType.AUTORIZACION, ENVIO));
         // Warning!!! Optional parameters not supported
     }
     
     private bool processSendComprobante(string VALUE, EnvioType ENVIO, void =, void EnvioType.NORMAL) {
         bool retVal;
         // Warning!!! Optional parameters not supported
         // --------------------------------------------------------------------------------------------------
        isOnLineValue = false;
         tipoEmisionSoapValue = 0;
         // --------------------------------------------------------------------------------------------------
        recepcionValue = new RecepcionComprobante();
         // autorizacionValue = New AutorizacionComprobante
         // --------------------------------------------------------------------------------------------------
        // verifico sino ha sido autorizado anteriormente o esta pendiente de autorizar
         // --------------------------------------------------------------------------------------------------
        autorizacionValue = ProcessAutorizacionComprobante(claveAccesoValue, ENVIO);
         // --------------------------------------------------------------------------------------------------
        // verifico si hubo conexion con los webservices del sri
         // --------------------------------------------------------------------------------------------------
        if ((autorizacionValue.SoapString != String.Empty)) {
             isOnLineValue = true;
             if ((autorizacionValue.IsAutorizado == false)) {
                 // ------------------------------------------------------------------------------------------
                // verifico si esta pendiente de Autorizar
                 // ------------------------------------------------------------------------------------------
                if ((autorizacionValue.IsPendiente == false)) {
                     recepcionValue = ProcessRecepcionComprobante(VALUE, ENVIO);
                     // --------------------------------------------------------------------------------------
                    if ((recepcionValue.SoapString != String.Empty)) {
                         if ((recepcionValue.IsRecibida == true)) {
                             autorizacionValue = ProcessAutorizacionComprobante(claveAccesoValue, ENVIO);
                             // ------------------------------------------------------------------------------
                            if ((autorizacionValue.NumeroComprobantes <= 0)) {
                                 autorizacionValue = ProcessAutorizacionComprobante(claveAccesoValue, ENVIO);
                             }
                             // ------------------------------------------------------------------------------
                            if ((autorizacionValue.SoapString == String.Empty)) {
                                 tipoEmisionSoapValue = 2;
                             }
                             // ------------------------------------------------------------------------------
                            retVal = true;
                         }
                     }
                     else {
                         tipoEmisionSoapValue = 2;
                     }
                 }
             }
             else {
                 retVal = true;
             }
         }
         else {
             tipoEmisionSoapValue = 2;
         }
         // ---------------------------------------------------------------------------------------------------
        if ((tipoEmisionSoapValue == 0)) {
             tipoEmisionSoapValue = tipoEmisionValue;
         }
         // ---------------------------------------------------------------------------------------------------
        return retVal;
     }
     
     private string executeWebServiceCLIENT(string VALUE, AcctionType ACCTION, EnvioType ENVIO, void =, void EnvioType.NORMAL) {
         WebClient w = new WebClient();
         // Warning!!! Optional parameters not supported
         string data = String.Empty;
         string address = String.Empty;
         string retVal = String.Empty;
         // ---------------------------------------------------------------------------------------------
        if ((ACCTION == AcctionType.AUTORIZACION)) {
             address = WSAutorizacion(tipoAmbienteValue);
         }
         else {
             address = WSRecepcion(tipoAmbienteValue);
         }
         // ---------------------------------------------------------------------------------------------
        if ((ACCTION == AcctionType.AUTORIZACION)) {
             if ((ENVIO == EnvioType.NORMAL)) {
                 data = getSoapAutorizacion(VALUE);
             }
             else if ((ENVIO == EnvioType.LOTE)) {
                 data = getSoapAutorizacionLote(VALUE);
             }
             else if ((ENVIO == EnvioType.LOTE_MASIVO)) {
                 data = getSoapAutorizacionLoteMasivo(VALUE);
             }
         }
         else {
             data = getSoapValidacion(VALUE);
         }
         // ---------------------------------------------------------------------------------------------
        w.Encoding = System.Text.Encoding.UTF8;
         // ---------------------------------------------------------------------------------------------
        // SI DESEAS USAR PROXI EDBERIAS HACER LO SIGUIENTE
         // ---------------------------------------------------------------------------------------------
        // w.Proxy
         // ---------------------------------------------------------------------------------------------
        try {
             retVal = w.UploadString(address, data);
         }
         catch (WebException ex) {
             // MsgBox(ex.Message, MsgBoxStyle.Critical, "executeWebServiceCLIENT")
         }
         // ---------------------------------------------------------------------------------------------
        executeWebServiceCLIENT = retVal;
         // ---------------------------------------------------------------------------------------------
        w.Dispose();
         // ---------------------------------------------------------------------------------------------
        w = null;
     }
     
     private void resetVariables() {
         tipoEmisionValue = 0;
         tipoAmbienteValue = 0;
         isOnLineValue = false;
         claveAccesoValue = String.Empty;
         recepcionValue = null;
         autorizacionValue = null;
     }
     
     private void readElements(string xmlString) {
         System.Xml.XmlDocument x = new System.Xml.XmlDocument();
         // --------------------------------------------------------------------------------------------------
        x.PreserveWhitespace = true;
         x.LoadXml(xmlString);
         // --------------------------------------------------------------------------------------------------
        readElements(x.DocumentElement);
         // --------------------------------------------------------------------------------------------------
        x = null;
     }
     
     private void readElements(XmlNode node) {
         foreach (XmlNode nodeChild in node.ChildNodes) {
             if ((nodeChild.NodeType != XmlNodeType.Text)) {
                 if ((nodeChild.LocalName.Contains("claveAcceso") == true)) {
                     claveAccesoValue = nodeChild.InnerText;
                 }
                 else if ((nodeChild.LocalName.Contains("ambiente") == true)) {
                     tipoAmbienteValue = int.Parse(nodeChild.InnerText);
                 }
                 else if ((nodeChild.LocalName.Contains("tipoEmision") == true)) {
                     tipoEmisionValue = int.Parse(nodeChild.InnerText);
                 }
                 // -----------------------------------------------------------
                if ((nodeChild.ChildNodes.Count > 0)) {
                     if (((claveAccesoValue == String.Empty) 
                                 || ((tipoAmbienteValue == 0) 
                                 || (tipoEmisionValue == 0)))) {
                         readElements(nodeChild);
                     }
                 }
             }
         }
     }
     
     private void loadWebSericeSRI() {
         Dictionary wsAutValue = new Dictionary(Of, Integer, String);
         Dictionary wsRecValue = new Dictionary(Of, Integer, String);
         // --------------------------------------------------------------------------
        if (((wsAutorizacionValue.Count <= 0) 
                     || (wsRecepcionValue.Count <= 0))) {
             wsAutValue.Add(1, "https://celcer.sri.gob.ec/comprobantes-electronicos-ws/AutorizacionComprobantes?wsdl");
             wsRecValue.Add(1, "https://celcer.sri.gob.ec/comprobantes-electronicos-ws/RecepcionComprobantes?wsdl");
             // ----------------------------------------------------------------------
            wsAutValue.Add(2, "https://cel.sri.gob.ec/comprobantes-electronicos-ws/AutorizacionComprobantes?wsdl");
             wsRecValue.Add(2, "https://cel.sri.gob.ec/comprobantes-electronicos-ws/RecepcionComprobantes?wsdl");
             // ----------------------------------------------------------------------
            wsAutorizacionValue = wsAutValue;
             wsRecepcionValue = wsRecValue;
         }
         // --------------------------------------------------------------------------
        wsAutValue = null;
         wsRecValue = null;
     }
     
     public bool IsAccesibleWS(AmbienteType tipoAmbiente, void =, void AmbienteType.PRODUCCION) {
         WebClient w = new WebClient();
         // Warning!!! Optional parameters not supported
         string s = String.Empty;
         // --------------------------------------------------------------------------------
        try {
             s = w.UploadString(WSRecepcion(int.Parse(tipoAmbiente)), getSoapValidacion());
         }
         catch (WebException ex) {
             Console.WriteLine(ex.Message);
         }
         // --------------------------------------------------------------------------------
        IsAccesibleWS = (s != String.Empty);
         w.Dispose();
         // --------------------------------------------------------------------------------
        w = null;
     }
     
     private string getOuterXML(string fileNameXML) {
         XmlTextReader reader = null;
         XmlDocument xml = new XmlDocument();
         string retVal = String.Empty;
         // --------------------------------------------------------------------------------------------------------
        if ((fileNameXML != String.Empty)) {
             reader = new XmlTextReader(fileNameXML);
             // ----------------------------------------------------------------------------------------------------
            xml.PreserveWhitespace = true;
             xml.Load(reader);
             // ----------------------------------------------------------------------------------------------------
            retVal = xml.OuterXml;
             // ----------------------------------------------------------------------------------------------------
            reader.Close();
         }
         // --------------------------------------------------------------------------------------------------------
        getOuterXML = retVal;
         // --------------------------------------------------------------------------------------------------------
        xml = null;
         reader = null;
     }
