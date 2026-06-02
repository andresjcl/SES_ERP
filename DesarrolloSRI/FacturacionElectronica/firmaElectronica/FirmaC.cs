//using System; 
//using System.Collections.Generic; 
//using System.Linq; 
//using System.Text;
//using System.Xml;
//using System.Security.Cryptography; 
//using System.Security.Cryptography.X509Certificates;
//using System.Security.Cryptography.Xml; 

//namespace AdcFirelec
//{  
//     public class Program 
//     {

//         private string strPathCertificado;
//         private string strPassword;
//         private string strPathXMLEntrada;
//         private string strPathXMLSalida;
//         public string strFileXml;
//         private string respuesta;

//         public static void Main(String[] args) 
//         { 
//             try 
//             { 
//                 // Create a new XML document. 
                  
//                 // X509Certificate2 uidCert = new X509Certificate2("C:\\Users\\m1007055\\Desktop\\public-may2012.p12", "public", X509KeyStorageFlags.DefaultKeySet);
//                 daxnumm.Class1 clvnum = new daxnumm.Class1();
//                 X509Certificate2 certificate = new X509Certificate2(strPathCertificado, clvnum.DeCodificar(strPassword), out privateKey, out provider);
 
//                 // Load an XML file into the XmlDocument object. 
                  
//                 // Sign the XML document.  
//                 FirmarXml(xmlDoc, uidCert); 
 
//                 Console.WriteLine("XML file signed."); 
 
//                 // Save the document. 
//                 xmlDoc.Save("C:\\test-signed.xml"); 
 
//             } 
//             catch (Exception e) 
//             { 
//                 Console.WriteLine(e.Message); 
//             } 
//             finally 
//             { 
//                 System.Console.ReadLine(); 
//             } 
//         } 
 
 
//         // Sign an XML file.   
//         // This document cannot be verified unless the verifying   
//         // code has the key with which it was signed.  
//         public static void FirmaDocXml(string strConxAdcom, string PathFileXml)
//         {
//             try
//             {
//                 strFileXml = PathFileXml;
//                 respuesta = strFileXml;
//                 daxnumm.Class1 clvnum = new daxnumm.Class1();

//                 registrarVariablesExternas(strConxAdcom);

//                 X509Certificate2 certificate = new X509Certificate2(strPathCertificado, clvnum.DeCodificar(strPassword), out privateKey, out provider);
//                XmlDocument xmlDoc = new XmlDocument();
//                xmlDoc.Load(strPathXMLEntrada);
//                xmlDoc.PreserveWhitespace = true; 
//                respuesta = FirmarXml(xmlDoc, certificate);
//             }
//             catch (Exception ee)
//             {
//                 respuesta = "ERROR " + ee;
//             }
//             if (respuesta == strFileXml)
//             {
//                 adcFeutil.Feutilidad util = new adcFeutil.Feutilidad();
//                 util.ActualizarDocumentoAdcom("Firmado", "", "", 0, strFileXml, "", 0, null, 0, strConxAdcom);
//                 try
//                 {
//                     //    System.IO.File.Delete(strPathXMLEntrada);
//                 }
//                 catch { }
//                 util = null;
//             }
//             try
//             {
//                 System.IO.File.Delete(strPathXMLSalida + "tmp");
//             }
//             catch { }
//             return respuesta;

//         }
//         private static void FirmarXml(XmlDocument xmlDoc, X509Certificate2 uidCert) 
//         { 
 
//             RSACryptoServiceProvider rsaKey = (RSACryptoServiceProvider)uidCert.PrivateKey; 
              
 
//             // Check arguments.  
//             if (xmlDoc == null) 
//                 throw new ArgumentException("xmlDoc"); 
//             if (rsaKey == null) 
//                 throw new ArgumentException("Key"); 
 
 
//             // Create a SignedXml object. 
//             SignedXml signedXml = new SignedXml(xmlDoc); 
 
//             // Add the key to the SignedXml document. 
//             signedXml.SigningKey = rsaKey;               
 
//             // Create a reference to be signed. 
//             Reference reference = new Reference(); 
//             reference.Uri = ""; 
 
//             // Add an enveloped transformation to the reference. 
//             XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform(); 
//             reference.AddTransform(env); 
 
//             // Add the reference to the SignedXml object. 
//             signedXml.AddReference(reference); 
 
 
//             // Add an RSAKeyValue KeyInfo (optional; helps recipient find key to validate). 
//             KeyInfo keyInfo = new KeyInfo(); 
 
//             KeyInfoX509Data clause = new KeyInfoX509Data(); 
//             clause.AddSubjectName(uidCert.Subject); 
//             clause.AddCertificate(uidCert); 
//             keyInfo.AddClause(clause); 
//             signedXml.KeyInfo = keyInfo; 
 
 
//             // Compute the signature. 
//             signedXml.ComputeSignature(); 
 
//             // Get the XML representation of the signature and save  
//             // it to an XmlElement object. 
//            XmlElement xmlDigitalSignature = signedXml.GetXml(); 
 
//             System.Console.WriteLine(signedXml.GetXml().InnerXml); 
              
//             // Append the element to the XML document. 
//             xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, true)); 
//         }
//         private static void registrarVariablesExternas(string strConxAdcom)
//         {
//             ClassFelec.AdcFelec fel = new ClassFelec.AdcFelec(strConxAdcom);
//             fel = ClassFelec.AdcFelec.Buscar("");
//             strPathCertificado = fel.pathFirmaElectronica;
//             strPassword = fel.claveFirma;
//             strPathXMLEntrada = fel.pathCpbGenerados + strFileXml + ".xml";
//             strPathXMLSalida = fel.pathCpbFirmados + strFileXml + ".xml";
//             //dxlib = null;
//             fel = null;
//         }
//         //private XmlDocument LoadXML(string path)
//         //{
//         //    DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
//         //    dbf.setNamespaceAware(true);
//         //    return dbf.newDocumentBuilder().parse(new BufferedInputStream(new FileInputStream(path)));
//         //}

//         //private X509Certificate2 LoadCertificate(string path, string password, out PrivateKey privateKey, out Provider provider)
//         //{

//         //    provider = null;
//         //    privateKey = null;

//         //    ////Cargar certificado de fichero PFX
//         //    //KeyStore ks = KeyStore.getInstance("PKCS12");
//         //    //ks.load(new BufferedInputStream(new FileInputStream(path)), password.ToCharArray());
//         //    //IPKStoreManager storeManager = new KSStore(ks, new PassStoreKS(password));
//         //    //List certificates = storeManager.getSignCertificates();

//         //    ////Si encontramos el certificado...
//         //    //if (!certificates.isEmpty())
//         //    //{
//         //    //    certificate = (X509Certificate)certificates.get(0);

//         //    //    // Obtención de la clave privada asociada al certificado
//         //    //    privateKey = storeManager.getPrivateKey(certificate);

//         //    //    // Obtención del provider encargado de las labores criptográficas
//         //    //    provider = storeManager.getProvider(certificate);
//         //    //}
//         //    return certificate;
//         //}
//     } 
// } 
