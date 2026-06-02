using System;
using System.Text;
namespace Daxconxfe
{
    public class Adcconxfe
    {
        public string pedirAutorizacionSri(string suc_documento, string opc_documento, double idclavedoc, string doc_numero, string claseDoc, string empRuc, short empDigitosPrecios, string empPatAppl, Int16 tipoEmision,Boolean esOnLine,string strConxAdcom)
        {            
            string pathfile = "";            
            DaxDocElectronicos.GenerarDocumentoXML genxml = new DaxDocElectronicos.GenerarDocumentoXML();
            string queClave = genxml.documentoAenviar(suc_documento, opc_documento, doc_numero, idclavedoc, ref pathfile,claseDoc,empRuc ,empDigitosPrecios,empPatAppl,tipoEmision,esOnLine);
            string resp = queClave;
            genxml = null;

            if (queClave.Substring(0, 3).ToUpper() != "ERR" && queClave.Length > 0)
            {
                DaxDocElectronicos.Firma FM = new DaxDocElectronicos.Firma();
                FM.strFileXml = queClave;
                string firma = FM.FirmarArchivoXML(strConxAdcom);
                FM = null;
                if (firma.Substring(0, 3).ToUpper() != "ERR")
                {
                    try
                    {
                        DaxLib.DaxLibBases dxlib = new DaxLib.DaxLibBases();
                        dxlib.TipoBase = "10";
                        DaxDocElectronicos.AdcFelec fel = new DaxDocElectronicos.AdcFelec(dxlib.StrAdcom());
                        fel = DaxDocElectronicos.AdcFelec.Buscar("");
                        
                        string PathFile = fel.pathCpbFirmados + queClave + ".xml";
                        string pathAutorizados = fel.pathCpbAutorizados + queClave + ".xml";
                        string pathNoAutorizados = fel.pathpbNoAutorizados + queClave + ".xml";
                        
                        WebService.EnviarComprobanteSri prog = new WebService.EnviarComprobanteSri();
                        if (prog.sendComprobanteSRI(PathFile, queClave, pathAutorizados, pathNoAutorizados) == false)
                        { 
                            resp = "ERROR-AUTORIZANDO: " + queClave; 
                        }
                        else 
                        { 
                            resp = queClave; 
                        }
                        dxlib = null;
                        fel = null;
                    }
                    catch (Exception ex)
                    {
                        resp = "ERROR-AUTORIZACION: " + ex.Message;
                    }
                }
                else
                {
                    resp = "ERROR-FIRMADO" + firma;
                }
            }
            else
            {
                resp = "ERROR-GENERACION " + queClave;
            }
            return resp;
        }
    }
}
