using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DaxEnvDocElec
{
    public class Procesos
    {
        
        static public string generarXml()
        {
            DataTable DocsGenerar = conexionDatos.listaDocumentos();

            if (DocsGenerar == null) return "ERROR";
            if (DocsGenerar.Rows.Count == 0) return "No existen documentos para procesar";

            AdcGenxml.enviarDocumentoS AdcGenxml = new AdcGenxml.enviarDocumentoS();
            string resp = "";
            foreach (DataRow ROW in DocsGenerar.Rows)
            {
                string Errores = "";
                string queClave = "";
                ClassDoc.idDocumento iddoc = new ClassDoc.idDocumento();
                iddoc.idClave = Convert.ToDouble(ROW["IdclaveDoc"].ToString());
                iddoc.fecha = Convert.ToDateTime(ROW["Doc_fecha"]);
                iddoc.numero = Convert.ToDouble(ROW["Doc_Numero"]);
                iddoc.Sucursal = ROW["Doc_Sucursal"].ToString();
                iddoc.Tipo = ROW["Opc_documento"].ToString();
                iddoc.familia = ROW["Doc_TipoDoc"].ToString();
                string queCodigoCliente = ROW["Doc_CodPer"].ToString();
                string correoElectronico = "";
                string correoElectronico2 = "";
                Int16 tipoEmision = 1;
                if (SysEmpDat.datosEmpresa.ambienteEnProduccion == 1) tipoEmision = 2;
                queClave = GenerarXML(iddoc, SysEmpDat.datosEmpresa.Emp_RUC, SysEmpDat.datosEmpresa.Par_DigitosPrecios, Environment.CurrentDirectory + "\\", tipoEmision, false);
                if (queClave.Substring(0, 5).ToUpper() == "ERROR")
                { Errores = iddoc.Sucursal + "-" + iddoc.Tipo + "-" + iddoc.numero.ToString() + "  " + queClave + " Genera XML "; }
                else
                {
                    AdcFirelec.Firma FM = new AdcFirelec.Firma();
                    FM.strFileXml = queClave.ToUpper();
                    resp = FM.FirmarArchivoXML(conexionDatos.strConxAdcom);
                    FM = null;
                }

                if (resp.Substring(0, 5).ToUpper() != "ERROR")
                {
                    //    //leerDocumentoAdcom();
                    string PathFile = SysEmpDat.datosEmpresa.pathCpbFirmados + queClave + ".xml";
                    string pathAutorizados = SysEmpDat.datosEmpresa.pathCpbAutorizados + queClave + ".xml";
                    string pathNoAutorizados = SysEmpDat.datosEmpresa.pathpbNoAutorizados + queClave + ".xml";
                    string pathErrores = pathNoAutorizados.Replace("xml", "ERR");
                    string correoElectronicoDefecto = SysEmpDat.datosEmpresa.CorreoDefecto;
                    enviarDocumentoSri.EnviarComprobanteSri prog = new enviarDocumentoSri.EnviarComprobanteSri();


                    if (prog.sendComprobanteSRI(PathFile, queClave, pathAutorizados, pathNoAutorizados, false,tipoEmision.ToString(),conexionDatos.strConxAdcom) == true)
                    {
                        string ArchivoXML = pathAutorizados;
                        documentosPdf.generacionPdf ProgPdf = new documentosPdf.generacionPdf(SysEmpDat.datosEmpresa.strConxIvaret, conexionDatos.strConxAdcom, conexionDatos.strConxIvaret, conexionDatos.strConxDaxsys, conexionDatos.strConxAdcom, SysEmpDat.datosEmpresa.Emp_codigo, SysEmpDat.datosEmpresa.Emp_PathImagenes);
                        string nombrePdf = ArchivoXML.Replace("xml", "PDF");
                        ProgPdf.GeneraDocPdf(iddoc, nombrePdf, "", "FEL" + iddoc.familia);
                        prog = null;

                        if (SysEmpDat.datosEmpresa.consumidorFinal != "" && SysEmpDat.datosEmpresa.consumidorFinal != queCodigoCliente)
                        {
                            if (verificaCorreoElectronico(ref correoElectronico) == true)
                            {

                                string DocMensaje = "Enviamos documento electrónico  \n Favor confirmar su recepción";
                                string correos = correoElectronico + ";" + correoElectronico2;
                                string adjuntos = ArchivoXML +";" + nombrePdf;
                                string asunto = "doumento Electrónico " + iddoc.Tipo + iddoc.Serie + "-" + iddoc.numero.ToString();
                                Int32 idmail = DaxEnvMail.ClassMailMasivo.EnviaMailDocmtoElectronicoMasivo(correos, asunto,DocMensaje,adjuntos,conexionDatos.strConxDaxsys,SysEmpDat.datosEmpresa.Emp_codigo.ToString());
                                if (idmail > 0) actualizarDocumentoIdCorreo(iddoc, idmail);
                            }
                            else
                            {
                                Errores = iddoc.Sucursal + "-" + iddoc.Tipo + "-" + iddoc.numero.ToString() + "  " + queClave + " no tiene un correo electrónico valido " + correoElectronico;
                            }
                        }
                    }
                }
                if (Errores != "")
                {
                    registraEvntos.registrar.registraEventoMail(conexionDatos.strConxDaxsys, SysEmpDat.datosEmpresa.Emp_codigo.ToString(), "ADM", Environment.MachineName, "DAXDOCELEC", "ENVIO", Errores);
                }
            }
            return "";
        }

        static private void actualizarDocumentoIdCorreo(ClassDoc.idDocumento idDoc, Int32 idmail)
        {
            string ssql = "update adcdoc set IdMailAut = " + idmail.ToString();
            using ( SqlConnection conn = new SqlConnection(conexionDatos.strConxAdcom))
            {
                SqlCommand comm = new SqlCommand(ssql, conn);
                comm.ExecuteNonQuery ();
                comm.Dispose();
            }
        }
        static private string GenerarXML(ClassDoc.idDocumento IdDoc, string empRuc, short empDigitosPrecios, string empPatAppl, Int16 tipoDeEmision, Boolean esOnLine)
        { 
            adcFeutil.Feutilidad util = new adcFeutil.Feutilidad();
            string ssqlDoc = util.strLeerDocumento(IdDoc);

            DataTable adcdocDat = conexionDatos.leerDatos(ssqlDoc, conexionDatos.strConxAdcom);
            DataRow adcdocRow = adcdocDat.Rows[0];
            
            if (adcdocDat.Rows.Count == 0) return "ERROR: NO EXISTE EL DOCUMENTO";

            string claveAcceso = adcdocRow["claveAcceso"].ToString();
            string pathFile = SysEmpDat.datosEmpresa.pathCpbGenerados;
            Int16 TipoDeAmbiente = 2;
            if (SysEmpDat.datosEmpresa.ambienteEnProduccion != 1 ) { TipoDeAmbiente = 1; }
            try
            {
                string NombreVerificador = "";
                string tipoDocumentoAdcom = IdDoc.familia;

                //if (claveAcceso.Length < 25)
                { 
                    if (esOnLine)
                    {
                        claveAcceso = AdcGenxml.genearClaveDocumentoElct.generar_clave_accesoNormal(IdDoc.fecha, util.tipoComprobanteSri(IdDoc.familia), SysEmpDat.datosEmpresa.Emp_RUC , TipoDeAmbiente, adcdocRow["Doc_NroIdDoc"].ToString(), IdDoc.numero.ToString(), IdDoc.idClave.ToString(),tipoDeEmision,"");
                    }
                    else
                    {
                        claveAcceso = AdcGenxml.genearClaveDocumentoElct.generar_clave_FueraDeLinea(IdDoc.fecha , util.tipoComprobanteSri(IdDoc.familia), tipoDeEmision.ToString() , IdDoc.numero.ToString() ,TipoDeAmbiente.ToString() , adcdocRow["Doc_ciruc"].ToString(), adcdocRow["Doc_NroIdDoc"].ToString(), IdDoc.idClave, empRuc);
                    }
                }
                pathFile += claveAcceso + ".XML";


                if (tipoDocumentoAdcom == "FAC")
                {
                    AdcGenxml. generarDocXml xmlprog = new AdcGenxml. generarDocXml();
                    NombreVerificador = "factura.xsd";
                    xmlprog.crear_factura_xml_sri(ref adcdocRow,ref adcdocDat , pathFile, claveAcceso, TipoDeAmbiente, tipoDeEmision, Convert.ToInt16(SysEmpDat.datosEmpresa.Par_DigitosPrecios),SysEmpDat.datosEmpresa.Emp_Nombre ,SysEmpDat.datosEmpresa.Emp_RUC,SysEmpDat.datosEmpresa.Emp_Dirección,SysEmpDat.datosEmpresa.strConxIvaret,conexionDatos.strConxAdcom);
                }
                else if (tipoDocumentoAdcom == "REM")
                {
                    AdcGenxml.GenRem xmlprog = new AdcGenxml.GenRem();
                    NombreVerificador = "remision.xsd";
                    xmlprog.crear_Remision_xml_sri(ref adcdocRow, ref adcdocDat, pathFile, claveAcceso, TipoDeAmbiente, tipoDeEmision);
                }
                else if (tipoDocumentoAdcom == "DEV" || tipoDocumentoAdcom == "NCC")
                {
                    AdcGenxml.Genncc xmlprog = new AdcGenxml.Genncc();
                    NombreVerificador = "notaCredito.xsd";
                    xmlprog.crear_notaCredito_xml_sri(ref adcdocRow, ref adcdocDat, pathFile, claveAcceso, TipoDeAmbiente, tipoDeEmision);
                }
                else if (tipoDocumentoAdcom == "NDC")
                {
                    AdcGenxml.Genndc xmlprog = new AdcGenxml.Genndc();
                    NombreVerificador = "notaDebito.xsd";
                    xmlprog.crear_notaDebito_xml_sri(ref adcdocRow, ref adcdocDat, pathFile, claveAcceso, TipoDeAmbiente, tipoDeEmision);
                }

                else if (tipoDocumentoAdcom == "RTP")
                {
                    AdcGenxml.Genret xmlprog = new AdcGenxml.Genret();
                    NombreVerificador = "comprobanteRetencion.xsd";
                    xmlprog.crear_Retencion_xml_sri(ref adcdocRow, ref adcdocDat, pathFile, claveAcceso, TipoDeAmbiente, tipoDeEmision);
                }
                if (claveAcceso.Length < 3) return claveAcceso;
                if (claveAcceso.Substring(0, 3).ToUpper() == "ERR") return claveAcceso;

                //PathCpbte = pathFile;
                AdcGenxml.AdcValxml verificador = new AdcGenxml.AdcValxml();

                if (verificador.Main(pathFile, empPatAppl + "XML\\SRI\\" + NombreVerificador) == true) { claveAcceso = "ERROR " + claveAcceso; }
                else { util.ActualizarDocumentoAdcom("Generado", IdDoc.Sucursal, IdDoc.Tipo ,  IdDoc.idClave , claveAcceso, "", tipoDeEmision, null, TipoDeAmbiente,conexionDatos.strConxAdcom); }

                verificador = null;
                util = null;
                //if (tipoDeEmision != 1 && claveAcceso.Substring(0, 3) != "ERR" && claveContingente.Length > 0) { progCont.registrarClave(claveContingente, suc_comprobante, tipo_comprobante, numero_comrpobante, strConxadcom); }
                return claveAcceso;
            }
            catch (Exception ee)
            {
                return "ERROR: " + "\n" + claveAcceso + "\n" + ee.Message + " ENVIAR DOCUMENTOS";
            }
        }
        static private Boolean verificaCorreoElectronico(ref string correoElectronico )
        {
            if (correoElectronico.Length == 0) correoElectronico = SysEmpDat.datosEmpresa.CorreoDefecto;
            if (correoElectronico.Length == 0) return false;
             return DaxValDocElec.ValidacionesDocElectronicos.ValidarEmail (correoElectronico);             
        }

    }
}
