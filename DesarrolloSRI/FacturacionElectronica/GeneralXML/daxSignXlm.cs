//
// This example signs an XML file using an
// envelope signature. It then verifies the 
// signed XML.
//
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;


namespace daxFesri
{

    public class daxSignXlm
    {

        public void Main(String[] args)
        {
            try
            {
                
                
                // Create a new CspParameters object to specify
                // a key container.
                CspParameters cspParamsKey = new CspParameters();
                //cspParamsKey = "";
                    //KeyContainerName = "E:\\FirmaEloctronicaDaxsof\\jorge_patricio_guerrero_velasco";
                
                //System.Security.SecureString str = new System.Security.SecureString();

                //str.AppendChar(Convert.ToChar("J"));
                //str.AppendChar(Convert.ToChar("o"));
                //str.AppendChar(Convert.ToChar("r"));
                //str.AppendChar(Convert.ToChar("g"));
                //str.AppendChar(Convert.ToChar("e"));
                //str.AppendChar(Convert.ToChar("W"));
                //str.AppendChar(Convert.ToChar("a"));
                //str.AppendChar(Convert.ToChar("r"));
                //str.AppendChar(Convert.ToChar("r"));
                //str.AppendChar(Convert.ToChar("i"));
                //str.AppendChar(Convert.ToChar("o"));
                //str.AppendChar(Convert.ToChar("r"));
                //str.AppendChar(Convert.ToChar("5"));
                //str.AppendChar(Convert.ToChar("7"));
                //str.AppendChar(Convert.ToChar("2"));
                //str.AppendChar(Convert.ToChar("3"));
                //str.AppendChar(Convert.ToChar("0"));
                //str.AppendChar(Convert.ToChar("3"));

                //cspParamsKey.KeyPassword = str;
                
                // Create a new RSA signing key and save it in the container. 
                X509Certificate2 objCert = new X509Certificate2("E:\\FirmaEloctronicaDaxsof\\jorge_patricio_guerrero_velasco.p12", "JorgeWarrior572303"); //Acá tenemos que poner el certificado 
                
                      //Inicializo el RSA
                RSACryptoServiceProvider rsaKey = (RSACryptoServiceProvider)objCert.PrivateKey;                
                
                // Create a new XML document.
                XmlDocument xmlDoc = new XmlDocument();

                // Load an XML file into the XmlDocument object.
                xmlDoc.PreserveWhitespace = true;
                xmlDoc.Load("E:\\tmp\\Example.xml");
                
                // Sign the XML document. 
                SignXml(xmlDoc, rsaKey);

                Console.WriteLine("XML file signed.");

                // Save the document.
                xmlDoc.Save("E:\\tmp\\signedExample.xml");



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

        //private string certificado()
        //{         
        //    X509Certificate2 objCert = new X509Certificate2 ("E:\\FirmaEloctronicaDaxsof\\jorge_patricio_guerrero_velasco.p12","JorgeWarrior572303"); //Acá tenemos que poner el certificado 
        //    StringBuilder objSB = new StringBuilder("Detalle del certificado: \n\n"); 
        //    objSB.AppendLine("Persona = " + objCert.Subject); 
        //    objSB.AppendLine("Emisor = " + objCert.Issuer); 
        //    objSB.AppendLine("Válido desde = " + objCert.NotBefore.ToString()); 
        //    objSB.AppendLine("Válido hasta = " + objCert.NotAfter.ToString()); 
        //    objSB.AppendLine("Tamaño de la clave = " + objCert.PublicKey.Key.KeySize.ToString()); 
        //    objSB.AppendLine("Número de serie = " + objCert.SerialNumber); 
        //    objSB.AppendLine("Hash = " + objCert.Thumbprint);
        //    objSB.AppendLine("Clave = " + objCert.GetPublicKeyString ());
        //    string clave = objCert.GetPublicKeyString();
        //    //Extensiones 
        //    objSB.AppendLine("\nExtensiones:\n"); 
            
        //    foreach (X509Extension objExt in objCert.Extensions) 
        //    { 
        //        objSB.AppendLine(objExt.Oid.FriendlyName + " (" + objExt.Oid.Value + ')'); 
        //        if (objExt.Oid.FriendlyName == "Key Usage") 
        //        { 
        //            X509KeyUsageExtension ext = (X509KeyUsageExtension)objExt; 
        //            objSB.AppendLine("    " + ext.KeyUsages); 
        //        } 
        //        if (objExt.Oid.FriendlyName == "Basic Constraints") 
        //        { 
        //            X509BasicConstraintsExtension ext = (X509BasicConstraintsExtension)objExt; 
        //            objSB.AppendLine("    " + ext.CertificateAuthority); 
        //            objSB.AppendLine("    " + ext.HasPathLengthConstraint); 
        //            objSB.AppendLine("    " + ext.PathLengthConstraint); 
        //        } 
        //        if (objExt.Oid.FriendlyName == "Subject Key Identifier") 
        //        { 
        //            X509SubjectKeyIdentifierExtension ext = (X509SubjectKeyIdentifierExtension)objExt; 
        //            objSB.AppendLine("    " + ext.SubjectKeyIdentifier); 
        //        } 
        //        if (objExt.Oid.FriendlyName == "Enhanced Key Usage") //2.5.29.37 
        //        { 
        //            X509EnhancedKeyUsageExtension ext = (X509EnhancedKeyUsageExtension)objExt; 
        //            OidCollection objOids = ext.EnhancedKeyUsages; 
        //            foreach (Oid oid in objOids) 
        //            objSB.AppendLine("    " + oid.FriendlyName + " (" + oid.Value + ')'); 
        //        }
        //        return clave;
        //} 

        //}

        // Sign an XML file. 
        // This document cannot be verified unless the verifying 
        // code has the key with which it was signed.
        public static void SignXml(XmlDocument xmlDoc, RSA Key)
        {
            // Check arguments.
            if (xmlDoc == null)
                throw new ArgumentException("xmlDoc");
            if (Key == null)
                throw new ArgumentException("Key");

            // Create a SignedXml object.
            SignedXml signedXml = new SignedXml(xmlDoc);
            signedXml.SigningKey = Key;

            
               
            
            // Create a reference to be signed.
            Reference reference = new Reference();
            reference.DigestMethod = null ;
            reference.Uri = "";

            // Add an enveloped transformation to the reference.
            XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(env);

            // Add the reference to the SignedXml object.
            signedXml.AddReference(reference);


            
            
            // Compute the signature.
            signedXml.ComputeSignature();

            // Get the XML representation of the signature and save
            // it to an XmlElement object.
            XmlElement xmlDigitalSignature = signedXml.GetXml();

            // Append the element to the XML document.
            xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, true));
        }
    }
}