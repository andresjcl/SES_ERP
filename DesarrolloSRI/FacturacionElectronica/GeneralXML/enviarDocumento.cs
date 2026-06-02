using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using Microsoft.VisualBasic.Devices;
using SysEmpDatt;
namespace DaxDocElectronicos

{
    public class enviarDocumentoS
    {
        enum TiposAmbiente  { PRUEBA = 1, PRODUCCION = 2}
        enum TiposAcción {RECEPCION = 1, AUTORIZACION = 2}
        enum TiposEnvío {NORMAL = 1, LOTE = 2, LOTE_MASIVO = 3}
        enum TiposEmisión {NORMAL = 1, NODISPONIBLE = 2}          // NODISPONIBLE O CONTINGENTE
        
        Int16 TipoDeAmbiente= Convert.ToInt16(TiposAmbiente.PRODUCCION) ;
        Int16 tipoDeEmision = Convert.ToInt16(TiposEmisión.NORMAL);
        string codigo_numerico = "";        
        string strConxadcom;
        string strConxDaxpro = "";
        string strConxIvaret = "";
        string strConxDaxsys = "";
             
        string pathFile = "";
        string pathBmp = "";
        //string claveContingente = "";
        //Contingencia progCont = new Contingencia();
        DaxDocElectronicos.Feutilidad util = new DaxDocElectronicos.Feutilidad();
        public string documentoAenviar(string suc_comprobante, string tipo_comprobante, string numero_comrpobante, double idclaveDoc,ref string PathCpbte,string claseDoc, string empRuc , short empDigitosPrecios, string empPatAppl,Int16 EmisionTipo, Boolean esOnLine)
        {
            string claveAcceso = "";
            //claveContingente = "";
            try
            {
                iniciarConexion();
                string ssqlDoc = util.strLeerDocumento(suc_comprobante, tipo_comprobante, idclaveDoc.ToString(), claseDoc);

                daxDatos dx = new daxDatos();
                DataTable adcdoc = daxDatos.leerDatos(ssqlDoc, strConxadcom);
                if (adcdoc.Rows.Count == 0) return "ERROR: NO EXISTE EL DOCUMENTO";

                if (iniciarVariablesExternas() == false) return "ERROR: NO SE HA CONFIGURADO LA EMISION DE COMPROBANTES ELECTRONICOS";
                tipoDeEmision = EmisionTipo;
                DataRow dr = adcdoc.Rows[0];

//                string NombreVerificador = "";

                string tipoDocumentoAdcom = dr["Doc_TipoDoc"].ToString();

                if (esOnLine)
                {
                    claveAcceso = genearClaveDocumentoElct.generar_clave_accesoNormal(Convert.ToDateTime(dr["Doc_fecha"]), util.tipoComprobanteSri(tipoDocumentoAdcom), empRuc, TipoDeAmbiente, dr["Doc_NroIdDoc"].ToString(), numero_comrpobante, codigo_numerico, tipoDeEmision, strConxadcom);
                }
                else
                {
                    claveAcceso = genearClaveDocumentoElct.generar_clave_FueraDeLinea(Convert.ToDateTime(dr["Doc_fecha"]), util.tipoComprobanteSri(tipoDocumentoAdcom), tipoDeEmision.ToString(), dr["Doc_Numero"].ToString(), TipoDeAmbiente.ToString(), dr["Doc_ciruc"].ToString(), dr["Doc_NroIdDoc"].ToString(), idclaveDoc, empRuc);
                }

                pathFile += claveAcceso + ".XML";


                if (tipoDocumentoAdcom == "FAC")
                {
                    generarDocXml xmlprog = new generarDocXml();
                    //NombreVerificador = "factura.xsd";
                    xmlprog.crear_factura_xml_sri(ref dr, ref adcdoc, pathFile, claveAcceso, TipoDeAmbiente, tipoDeEmision, empDigitosPrecios,datosEmpresa.Emp_Nombre , datosEmpresa.Emp_RUC, datosEmpresa.Emp_Dirección , datosEmpresa.nombreBaseIvaret, strConxadcom);
                }
                else if (tipoDocumentoAdcom == "REM")
                {
                    GenRem xmlprog = new GenRem();
                    //NombreVerificador = "remision.xsd";
                    xmlprog.crear_Remision_xml_sri(ref dr, ref adcdoc, pathFile, claveAcceso, TipoDeAmbiente, tipoDeEmision);
                }
                else if (tipoDocumentoAdcom == "DEV" || tipoDocumentoAdcom == "NCC")
                {
                    Genncc xmlprog = new Genncc();
                    //NombreVerificador = "notaCredito.xsd";
                    xmlprog.crear_notaCredito_xml_sri(ref dr, ref adcdoc, pathFile, claveAcceso, TipoDeAmbiente, tipoDeEmision);
                }
                else if (tipoDocumentoAdcom == "NDC")
                {
                    Genndc xmlprog = new Genndc();
                    //NombreVerificador = "notaDebito.xsd";
                    xmlprog.crear_notaDebito_xml_sri(ref dr, ref adcdoc, pathFile, claveAcceso, TipoDeAmbiente, tipoDeEmision);
                }

                else if (tipoDocumentoAdcom == "RTP")
                {
                    Genret xmlprog = new Genret();
                    //NombreVerificador = "comprobanteRetencion.xsd";
                    xmlprog.crear_Retencion_xml_sri(ref dr, ref adcdoc, pathFile, claveAcceso, TipoDeAmbiente, tipoDeEmision);
                }
                else if (tipoDocumentoAdcom == "FAP")
                {
                    GenLiqcom xmlprog = new GenLiqcom();
                    //NombreVerificador = "liquidacionCompras.xsd";
                    xmlprog.crear_LiquidacionCompra (ref dr, ref adcdoc, pathFile, claveAcceso, TipoDeAmbiente, tipoDeEmision, empDigitosPrecios, datosEmpresa.Emp_Nombre , datosEmpresa.Emp_RUC, datosEmpresa.Emp_Dirección, datosEmpresa.nombreBaseIvaret, strConxadcom);
                }
                if (claveAcceso.Length < 3) return claveAcceso;
                if (claveAcceso.Substring(0, 3).ToUpper() == "ERR") return claveAcceso;

                PathCpbte = pathFile;
                //AdcGenxml.AdcValxml verificador = new AdcGenxml.AdcValxml();               
                //if (verificador.Main(pathFile, empPatAppl + "XML\\SRI\\" + NombreVerificador) == true) { claveAcceso = "ERROR " + claveAcceso; }
                //else 
                { 
                    util.ActualizarDocumentoAdcom("Generado", suc_comprobante, tipo_comprobante, idclaveDoc, claveAcceso, "", tipoDeEmision, null, TipoDeAmbiente,strConxadcom);
                //    PrepararEnvios(pathBmp+claveAcceso+".PDF", tipoDocumentoAdcom, suc_comprobante, tipo_comprobante, numero_comrpobante, idclaveDoc);
                }

                //verificador = null;
                util = null;
    //                if (tipoDeEmision != 1 && claveAcceso.Substring(0, 3) != "ERR" && claveContingente.Length > 0)
    //                { progCont.registrarClave(claveContingente,suc_comprobante,tipo_comprobante,numero_comrpobante,strConxadcom); }
                return claveAcceso;
            }
                catch ( Exception ee)
            {   
                    return "ERROR: " + "\n" + claveAcceso + "\n" + ee.Message + " ENVIAR DOCUMENTOS" ;
            }
        }

        //private void PrepararEnvios(string PathArchivoBmp, string TipoDoc,string sucdoc,string opcDoc,string numeroDoc ,double idClaveDoc)
        //{            
        //    string  FormaImpresionDocumento = "FEL" + TipoDoc;
        //    documentosPdf.generacionPdf PROG = new documentosPdf.generacionPdf(sysEmp.EmpresaAct.NombreBaseIvaret ,strConxadcom , strConxIvaret ,strConxDaxsys , strConxDaxpro, sysEmp.EmpresaAct.codigo , sysEmp.EmpresaAct.PatServidor);
        //    PROG.GeneraDocPdf(sucdoc , opcDoc , numeroDoc , idClaveDoc, PathArchivoBmp, "", FormaImpresionDocumento);
        //}



         private string tipoDocSri(string tipoAdc,string str)
         {
             string tipo = "";
             daxDatos dx = new daxDatos();
             DataTable dt = daxDatos.leerDatos ( "select opc_tiposri from adcopc where opc_documento ='" + tipoAdc + "'",str);
             if (dt.Rows.Count > 0) tipo = dt.Rows[0]["opc_tiposri"].ToString ();
             return tipo.PadLeft(2,Convert.ToChar("0"));
         }

         private Boolean iniciarVariablesExternas()
         {             
             DaxDocElectronicos.AdcFelec fel = new DaxDocElectronicos.AdcFelec(strConxadcom);
             fel = DaxDocElectronicos.AdcFelec.Buscar("");
             if (fel != null)
             {
                 pathFile = fel.pathCpbGenerados;
                 pathBmp = fel.pathCpbAutorizados;
                 if (!fel.ambienteEnProduccion) { TipoDeAmbiente = Convert.ToInt16(TiposAmbiente.PRUEBA); }
                 fel = null;
                 return true;
             }           

             return false;
         }
         private void iniciarConexion()
         {
            strConxadcom = datosEmpresa.strConxAdcom;
             strConxDaxpro = datosEmpresa.strConxDaxpro;
             strConxIvaret = datosEmpresa.strConxIvaret;
             strConxDaxsys = datosEmpresa.strConxSyscod;
         }
    }
    public static class genearClaveDocumentoElct
    {
        static DaxDocElectronicos.Feutilidad util = new DaxDocElectronicos.Feutilidad();
        public static string generar_clave_accesoNormal( DateTime fecha_emision, string tipo_comprobante,string ruc,Int16 ambiente,string serie, string numero_comrpobante, string codigo_numerico,Int16 tipo_emision,string str)
             {
                string clave="";
                serie = util.formatoNumero(serie, 7);
                clave = string.Format("{0:ddMMyyyy}", fecha_emision) + tipo_comprobante + util.formatoNumero(ruc,13) + ambiente + util.formatoNumero(serie.Substring(0,3), 3) + util.formatoNumero(serie.Substring(4, 3),3) +util.formatoNumero( numero_comrpobante,9) + util.formatoNumero(codigo_numerico,8) + tipo_emision;
                string digito = crear_digito_mod11(clave);
                return clave + digito;
             }
        public static string generar_clave_FueraDeLinea(DateTime fecha_emision, string tipo_comprobante, string tipo_emision,string numeroDoc,string ambiente, string rucCliente, string SerieSri,double idclaveDoc,string rucEmpresa)
             {
                 // concatena los valores y aplica modulo 11 al numero para incorporarel digito validador.'                 
                 Char cc = Convert.ToChar("0");
                 string clave = "";
                 clave = string.Format("{0:ddMMyyyy}", fecha_emision);  // Fecha de Emisión Numérico ddmmaaaa 8
                 clave += util.formatoNumero (tipo_comprobante,2) ; // Tipo de Comprobante Tabla 4 2             
                 clave += util.formatoNumero(rucEmpresa,13);   // Número de RUC 1234567890001 13
                 clave += util.formatoNumero(ambiente.ToString(),1);        // Tipo de Ambiente Tabla 5 1
                 clave += util.formatoNumero(SerieSri.Substring(0, 3), 3) + util.formatoNumero(SerieSri.Substring(4, 3), 3);         // Serie 001001 6
                 clave += util.formatoNumero( numeroDoc,9);   // Número del Comprobante (secuencial) 000000001 9
                 clave += controlarIdclave(idclaveDoc); // Código Numérico Numérico 8    (crear propio)
                 clave += "1"; //tipo_emision; // Tipo de Emisión Tabla 2 1
                 string digito = crear_digito_mod11(clave);
                 return clave + digito;                 // Dígito Verificador (módulo 11 ) Numérico 1
             }

        static private string controlarIdclave(double idclave)
        {
            string clave = idclave.ToString();
            int lng = clave.Length;
            if (lng > 8) clave = clave.Substring(lng - 8);
            return util.formatoNumero(clave, 8);
        }
        static private string crear_digito_mod11(string numero)
        {
            Int32 x = 0;
            Int32 factor = 2;
            for (int c = numero.Length - 1; c > -1; c--)
            {
                x += Convert.ToInt32(numero.Substring(c, 1)) * factor;
                factor += 1;
                if (factor == 8) factor = 2;
            }
            factor = 11 - (x % 11);
            if (factor == 11) factor = 0;
            if (factor == 10) factor = 1;
            return factor.ToString();
        }
    }
}
