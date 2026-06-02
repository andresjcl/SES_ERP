using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using java.io;
using java.util;
using java.security;
using javax.xml.parsers;
using java.security.cert;

using es.mityc.javasign.pkstore;
using es.mityc.javasign.pkstore.keystore;
using es.mityc.javasign.trust;
using es.mityc.javasign.xml.xades.policy;
using es.mityc.firmaJava.libreria.xades;
using es.mityc.javasign.xml.refs;
using es.mityc.firmaJava.libreria.utilidades;

using sviudes.blogspot.com;
using org.w3c.dom;

namespace PruebaFirmaV01
{
    class Firma
    {
        private string strPathCertificado;
        private string strPassword;
        private string strPathXMLEntrada;
        private string strPathXMLSalida;
        public string strFileXml;
        
        public void FirmarArchivoXML()
        {
            registrarVariablesExternas();
            GenerarCertificado();
        }
        private void registrarVariablesExternas()
        {
            DaxLib.DaxLibBases dxlib = new DaxLib.DaxLibBases();
            dxlib.TipoBase = "10";
            ClassFelec.AdcFelec fel = new ClassFelec.AdcFelec(dxlib.StrAdcom());
            fel = ClassFelec.AdcFelec.Buscar("");
            strPathCertificado = fel.pathFirmaElectronica; // "E:\\FirmaEloctronicaDaxsof\\jorge_patricio_guerrero_velasco.p12";
            strPassword = fel.claveFirma; // "JorgeWarrior572303";
            strPathXMLEntrada = fel.pathCpbGenerados + strFileXml;  // "E:\\tmp\\sample.xml";
            strPathXMLSalida = fel.pathCpbFirmados + strFileXml; // "E:\\tmp\\sampleFirmado.xml";       

            dxlib = null;
            fel = null;
        }
        private void GenerarCertificado()
        {
            //this.btnFirmar_Click(sender, e);

            PrivateKey privateKey;
            Provider provider;
            X509Certificate certificate = LoadCertificate(strPathCertificado, strPassword, out privateKey, out provider);

            //Si encontramos el certificado...

            if (certificate != null)
            {
                //Política de firma (Con las librerías JAVA, esto se define en tiempo de ejecución)
                
                TrustFactory.instance = es.mityc.javasign.trust.TrustExtendFactory.newInstance();
                TrustFactory.truster = es.mityc.javasign.trust.MyPropsTruster.getInstance();
                PoliciesManager.POLICY_SIGN = new es.mityc.javasign.xml.xades.policy.facturae.Facturae31Manager();
                PoliciesManager.POLICY_VALIDATION = new es.mityc.javasign.xml.xades.policy.facturae.Facturae31Manager();

                //Crear datos a firmar
                
                DataToSign dataToSign = new DataToSign();
                dataToSign.setXadesFormat(EnumFormatoFirma.XAdES_BES); //XAdES-EPES
                dataToSign.setEsquema(XAdESSchemas.XAdES_132);
                dataToSign.setPolicyKey("facturae31"); //Da igual lo que pongamos aquí, la política de firma se define arriba
                dataToSign.setAddPolicy(false);
                dataToSign.setXMLEncoding("UTF-8");
                dataToSign.setEnveloped(true);
                dataToSign.addObject(new ObjectToSign(new AllXMLToSign(), "Descripcion del documento", null, "text/xml", null));
//              dataToSign.addObject(new ObjectToSign(new InternObjectToSign("comprobante"), "contenido comprobante", null, "text/xml", null));   VERIFICAR ESTA LNEA SI DA ERROR
                dataToSign.setDocument(LoadXML(strPathXMLEntrada));
                //Firmar
                Object[] res = new FirmaXML().signFile(certificate, dataToSign, privateKey, provider);

                // Guardamos la firma a un fichero en el home del usuario
                UtilidadTratarNodo.saveDocumentToOutputStream((Document)res[0], new FileOutputStream(strPathXMLSalida), true);
            }
        }

        private Document LoadXML(string path)
        {
            DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
            dbf.setNamespaceAware(true);
            return dbf.newDocumentBuilder().parse(new BufferedInputStream(new FileInputStream(path)));
        }

        private X509Certificate LoadCertificate(string path, string password, out PrivateKey privateKey, out Provider provider)
        {
            X509Certificate certificate = null;
            provider = null;
            privateKey = null;

            //Cargar certificado de fichero PFX
            KeyStore ks = KeyStore.getInstance("PKCS12");
            ks.load(new BufferedInputStream(new FileInputStream(path)), password.ToCharArray());
            IPKStoreManager storeManager = new KSStore(ks, new PassStoreKS(password));
            List certificates = storeManager.getSignCertificates();

            //Si encontramos el certificado...
            if (!certificates.isEmpty())
            {
                certificate = (X509Certificate)certificates.get(0);

                // Obtención de la clave privada asociada al certificado
                privateKey = storeManager.getPrivateKey(certificate);

                // Obtención del provider encargado de las labores criptográficas
                provider = storeManager.getProvider(certificate);
            }
            return certificate;
        }
    }
}
