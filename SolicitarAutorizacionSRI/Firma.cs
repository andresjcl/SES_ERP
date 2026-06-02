using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DattCom;

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
using DaxDocElectronicos;

namespace SolicitudAutSRI
{
    public class Firma
    {
        private string strPathCertificado;
        private string strPassword;
        private string strPathXMLEntrada;
        private string strPathXMLSalida;
        public string strFileXml;
        public string respuesta;

        public string FirmarArchivoXML(string strConxAdcom)
        {
            try
            {
                respuesta = strFileXml;
                registrarVariablesExternas(strConxAdcom);
                GenerarCertificado();
            }
            catch (Exception ee)
            {
                respuesta = "ERROR " + ee;
            }
            if (respuesta == strFileXml)
            {
                Feutilidad util = new Feutilidad();
                util.ActualizarDocumentoAdcom("Firmado", "", "", 0, strFileXml, "", 0, (string)null, 0, datosEmpresa.strConxAdcom);

                try
                {
                    System.IO.File.Delete(strPathXMLEntrada);
                }
                catch { }
                util = null;
            }
            try
            {
                System.IO.File.Delete(strPathXMLSalida + "tmp");
            }
            catch { }
            return respuesta;
        }
        private void registrarVariablesExternas(string strConxAdcom)
        {
            //DaxLib.DaxLibBases dxlib = new DaxLib.DaxLibBases();
            //dxlib.TipoBase = "10";
            ClassFelec.AdcFelec fel = new ClassFelec.AdcFelec(datosEmpresa.strConxAdcom);
            fel = ClassFelec.AdcFelec.Buscar("");
            strPathCertificado = fel.pathFirmaElectronica;
            strPassword = fel.claveFirma;
            strPathXMLEntrada = fel.pathCpbGenerados + strFileXml + ".xml";
            strPathXMLSalida = fel.pathCpbFirmados + strFileXml + ".xml";
            //dxlib = null;
            fel = null;
        }
        private void GenerarCertificado()
        {
            //this.btnFirmar_Click(sender, e);

            daxnumm.Class1 clvnum = new daxnumm.Class1();
            PrivateKey privateKey;
            Provider provider;
            com.sun.org.apache.xerces.@internal.jaxp.SAXParserFactoryImpl s = new com.sun.org.apache.xerces.@internal.jaxp.SAXParserFactoryImpl();
            X509Certificate certificate = LoadCertificate(strPathCertificado, clvnum.DeCodificar(strPassword), out privateKey, out provider);
            s = null;
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
                // dataToSign.addObject(new ObjectToSign(new AllXMLToSign(), "Descripcion del documento", null, "text/xml", null));
                dataToSign.addObject(new ObjectToSign(new InternObjectToSign("comprobante"), "contenido comprobante", null, "text/xml", null)); //  VERIFICAR ESTA LNEA SI DA ERROR
                dataToSign.setDocument(LoadXML(strPathXMLEntrada));
                //Firmar
                Object[] res = new FirmaXML().signFile(certificate, dataToSign, privateKey, provider);

                // Guardamos la firma a un fichero en el home del usuario

                using (FileOutputStream fileOut = new FileOutputStream(strPathXMLSalida))
                {
                    UtilidadTratarNodo.saveDocumentToOutputStream((Document)res[0], fileOut, true);
                }

                //try
                //{
                //    lock (this)
                //    {
                //        UtilidadTratarNodo.saveDocumentToOutputStream((Document)res[0], new FileOutputStream(strPathXMLSalida), true);
                //    }
                //}
                //finally
                //{
                //    res = null;
                //    dataToSign = null;
                //}            
            }

            else
            {


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
