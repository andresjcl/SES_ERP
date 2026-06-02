using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace AdcGenxml

{
    public class enviarDocumentoS
    {
        enum TipoAmbiente  { PRUEBA = 1, PRODUCCION = 2}
        enum TipoAcción {RECEPCION = 1, AUTORIZACION = 2}
        enum TipoEnvío {NORMAL = 1, LOTE = 2, LOTE_MASIVO = 3}
        enum TipoEmisión {NORMAL = 1, NODISPONIBLE = 2}          
        
        Int16 TipoDeAmbiente= Convert.ToInt16(TipoAmbiente.PRODUCCION) ;
        Int16 tipoDeEmision = Convert.ToInt16(TipoEmisión.NORMAL);
        string codigo_numerico = "";        
        string strConxadcom;
        string pathFile = "";

        adcFeutil.Feutilidad util = new adcFeutil.Feutilidad();

        public string documentoAenviar(string suc_comprobante, string tipo_comprobante, string numero_comrpobante, double idclaveDoc,ref string PathCpbte)
        {
            registrarCOnexion();
            string ssqlDoc = "";
            string ssqlTra = "";
            util.strLeerDocumento(ref ssqlDoc, ref ssqlTra, suc_comprobante, tipo_comprobante, idclaveDoc.ToString());            
            daxDatos dx = new daxDatos();
            DataTable adcdoc = dx.leerDatos(ssqlDoc,strConxadcom);
            DataTable adctra = dx.leerDatos(ssqlTra, strConxadcom);
                    
            if (adcdoc.Rows.Count == 0 || adctra.Rows.Count == 0) return "ERROR";
            
            registrarVariablesExternas();            
            DataRow dr = adcdoc.Rows[0];

            AdcDax.DaxSofSys AdcDaxx = new AdcDax.DaxSofSys();
            AdcDax.Empresa emp = AdcDaxx.EmpresaAct;

            string claveAcceso = generar_clave_accesoNormal(Convert.ToDateTime(dr["Doc_fecha"]), util.tipoComprobanteSri( dr["Doc_TipoDoc"].ToString()), emp.ruc, TipoDeAmbiente, dr["Doc_NroIdDoc"].ToString(), numero_comrpobante, codigo_numerico, tipoDeEmision, strConxadcom);
            pathFile += claveAcceso + ".XML";
            
            generarDocXml xmlprog = new generarDocXml();

            xmlprog.crear_factura_xml_sri(ref dr, ref adctra, pathFile, claveAcceso, TipoDeAmbiente, tipoDeEmision);
            PathCpbte = pathFile;
            AdcGenxml.AdcValxml  verificador = new AdcGenxml.AdcValxml ();

            if (verificador.Main(pathFile, emp.PatAppl + "factura.xsd") == true) { claveAcceso = "ERROR" + claveAcceso; }
            else { util.ActualizarDocumentoAdcom("Generado", suc_comprobante, tipo_comprobante, idclaveDoc, claveAcceso, "", tipoDeEmision, null); }
            verificador = null;
            return claveAcceso;
        }

         private string generar_clave_accesoNormal( DateTime fecha_emision, string tipo_comprobante,string ruc,Int16 ambiente,string serie, string numero_comrpobante, string codigo_numerico,Int16 tipo_emision,string str)
             {
                string clave="";
                serie = util.formatoNumero(serie, 7);
                clave = string.Format("{0:ddMMyyyy}", fecha_emision) + tipo_comprobante + util.formatoNumero(ruc,13) + ambiente + util.formatoNumero(serie.Substring(0,3), 3) + util.formatoNumero(serie.Substring(4, 3),3) +util.formatoNumero( numero_comrpobante,9) + util.formatoNumero(codigo_numerico,8) + tipo_emision;
                string digito = crear_digito_mod11(clave);
                return clave + digito;
             }

         private string generar_clave_accesoContingente(DateTime fecha_emision, string tipo_comprobante, string claveContigente, string tipo_emision,string str)
             {
                 // concatena los valores y aplica modulo 11 al numero para incorporarel digito validador.'
                 Char cc = Convert.ToChar("0");
                 string clave = "";
                 clave = fecha_emision.ToShortDateString() + tipoDocSri( tipo_comprobante,str) + claveContigente + tipo_emision;
                 string digito = crear_digito_mod11(clave);
                 return clave + digito;
             }        
         private string crear_digito_mod11(string numero)
            {
            Int32  x = 0;
            Int32 factor = 2;
            for (int c=numero.Length - 1;c>-1; c--)
                {                   
                    x += Convert.ToInt32( numero.Substring(c,1)) * factor;
                    factor += 1;
                    if (factor == 8) factor = 2;                   
                }
            factor = 11 - (x % 11);
            if (factor == 11) factor=0;
            if (factor == 10) factor=1;
            return factor.ToString();
            }
         private string tipoDocSri(string tipoAdc,string str)
         {
             string tipo = "";
             daxDatos dx = new daxDatos();
             DataTable dt = dx.leerDatos ( "select opc_tiposri from adcopc where opc_documento ='" + tipoAdc + "'",str);
             if (dt.Rows.Count > 0) tipo = dt.Rows[0]["opc_tiposri"].ToString ();
             return tipo.PadLeft(2,Convert.ToChar("0"));
         }
         private void registrarVariablesExternas()
         {             
             ClassFelec.AdcFelec fel = new ClassFelec.AdcFelec(strConxadcom);
             fel = ClassFelec.AdcFelec.Buscar("");
             pathFile = fel.pathCpbGenerados ;  // "E:\\tmp\\sample.xml";
             if (!fel.ambienteEnProduccion) { TipoDeAmbiente = Convert.ToInt16(TipoAmbiente.PRUEBA); }
             fel = null;
         }
         private void registrarCOnexion()
         {
             DaxLib.DaxLibBases dxlib = new DaxLib.DaxLibBases();
             dxlib.TipoBase = "10";
             strConxadcom = dxlib.StrAdcom();
             dxlib = null;
         }
    }
}
