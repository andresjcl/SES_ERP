using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DattCom;
namespace DaxDocElectronicos
{
    public class Genndc
    {

        Char cc = Convert.ToChar("0");
        Char bb = Convert.ToChar(" ");
        DaxDocElectronicos.Feutilidad util = new DaxDocElectronicos.Feutilidad();
        //datosSri datsri = new datosSri ();
        public string crear_notaDebito_xml_sri(ref DataRow doc, ref DataTable dtra, string pathfile, string clv, Int16 ambiente, Int16 tipoEmision)
        // generar el archivo xml por facturacion para enviar al sri
        {
            string straux = "";

            XmlTextWriter docXml = new XmlTextWriter(pathfile, System.Text.Encoding.UTF8);
            docXml.WriteStartDocument(true);
            docXml.Formatting = Formatting.Indented;            

            docXml.WriteStartElement("notaDebito");
            docXml.WriteAttributeString("version", "1.0.0");
            docXml.WriteAttributeString("id", "comprobante");

            docXml.WriteStartElement("infoTributaria");
            docXml.WriteElementString("ambiente", util.formatoNumero(ambiente.ToString(), 1));
            docXml.WriteElementString("tipoEmision", util.formatoNumero(tipoEmision.ToString(), 1));
            docXml.WriteElementString("razonSocial", util.formatoString(datosEmpresa.Emp_Nombre , 300));
            docXml.WriteElementString("nombreComercial", util.formatoString(datosEmpresa.Emp_Nombre, 300));
            docXml.WriteElementString("ruc", datosEmpresa.Emp_RUC);
            docXml.WriteElementString("claveAcceso", clv);
            docXml.WriteElementString("codDoc", util.tipoComprobanteSri(doc["DOC_TipoDoc"].ToString()));


            straux = util.formatoNumero(doc["Doc_NroIdDoc"].ToString(), 7);
            docXml.WriteElementString("estab", straux.Substring(0, 3));
            docXml.WriteElementString("ptoEmi", straux.Substring(4, 3));

            docXml.WriteElementString("secuencial", util.formatoNumero(doc["Doc_numero"].ToString(), 9));
            docXml.WriteElementString("dirMatriz", util.formatoString(datosEmpresa.Emp_Dirección, 300));

            try
            {
                if (Convert.ToBoolean(doc["RegimenMicroempresas"]))
                {
                    docXml.WriteElementString("regimenMicroempresas", "CONTRIBUYENTE RÉGIMEN MICROEMPRESAS");
                }
            }
            catch { }


            try
            {
                if (doc["NroAcdoAgntRetencion"].ToString().Length > 0)
                {
                    docXml.WriteElementString("agenteRetencion", util.formatoString(doc["NroAcdoAgntRetencion"].ToString(), 8));
                }
            }
            catch { }


            docXml.WriteEndElement(); //infoTributARIA

            docXml.WriteStartElement("infoNotaDebito");
            docXml.WriteElementString("fechaEmision", util.formatoFecha(Convert.ToDateTime(doc["Doc_fecha"])));
            //docXml.WriteElementString("dirEstablecimiento", util.formatoString(doc["Doc_Direccion"].ToString(), 300));

            docXml.WriteElementString("tipoIdentificacionComprador", util.tipoId(doc["TipoIdentificacion"].ToString()));
            docXml.WriteElementString("razonSocialComprador", util.nombreCliente(ambiente, doc["Doc_NombreImp"].ToString()));
            docXml.WriteElementString("identificacionComprador", doc["Doc_CiRuc"].ToString());


            //if (doc["NroCtrbuyteEspecial"].ToString().Length > 2)
            //{ docXml.WriteElementString("contribuyenteEspecial", doc["NroCtrbuyteEspecial"].ToString()); }

            //if (doc["ObligLlevarConta"].ToString().Length > 0)
            //{ docXml.WriteElementString("obligadoContabilidad", util.ObligadoLlevarContabilidad(Convert.ToBoolean(doc["ObligLlevarConta"].ToString()))); }

            if (datosEmpresa.Emp_ContrBuyEsp.Length > 2) docXml.WriteElementString("contribuyenteEspecial", datosEmpresa.Emp_ContrBuyEsp);

            docXml.WriteElementString("obligadoContabilidad", datosEmpresa.Emp_Conta ? "SI" : "NO");


            if (doc["esRise"].ToString().ToUpper() == "S")
            {
                docXml.WriteElementString("rise", "Contribuyente Regimen Simplificado RISE");
            }

            //    if (Convert.ToDouble(doc["idclavedocapl"]) != 0)
            //{
            docXml.WriteElementString("codDocModificado", util.tipoComprobanteSri(doc["DOC_tipoSoporte"].ToString()));
            docXml.WriteElementString("numDocModificado", util.formatoString(doc["Doc_idSriSoporte"].ToString(), 7) + "-" + util.formatoNumero(doc["Doc_numSoporte"].ToString(), 9));
            try
            {
                docXml.WriteElementString("fechaEmisionDocSustento", util.formatoFecha(Convert.ToDateTime(doc["Doc_fechaSoporte"])));
            }
            catch
            {
                docXml.WriteElementString("fechaEmisionDocSustento", "01/01/1900");
            }
            //}
            docXml.WriteElementString("totalSinImpuestos", util.formatoDecimal(Convert.ToDouble(doc["subtotal"]), 14, 2));
            //docXml.WriteElementString("valorModificacion", util.formatoDecimal(Convert.ToDouble("0" + doc["doc_valor"].ToString()), 14, 2));

            //docXml.WriteElementString("moneda", "DOLAR");


            docXml.WriteStartElement("impuestos");
            double tarifaImpuesto = Convert.ToDouble(doc["Doc_porceniva"]);
            if (Convert.ToDouble(doc["Doc_valoriva"]) != 0)
            {
                docXml.WriteStartElement("impuesto");
                docXml.WriteElementString("codigo", "2");
                docXml.WriteElementString("codigoPorcentaje", datosSri.codigoIva(tarifaImpuesto, straux));
                docXml.WriteElementString("tarifa", util.formatoDecimal(tarifaImpuesto,5,2));
                docXml.WriteElementString("baseImponible", doc["Doc_totciva"].ToString());
                docXml.WriteElementString("valor", doc["Doc_valoriva"].ToString());
                docXml.WriteEndElement();
            }

            if (Convert.ToDouble(doc["Doc_totsiva"]) != 0)
            {
            docXml.WriteStartElement("impuesto");
            docXml.WriteElementString("codigo", "2");
            docXml.WriteElementString("codigoPorcentaje", "0");
            docXml.WriteElementString("tarifa", "0");
            docXml.WriteElementString("baseImponible", doc["Doc_totsiva"].ToString());
            docXml.WriteElementString("valor", "0");
            docXml.WriteEndElement();
            }

            //docXml.WriteStartElement("totalImpuesto");
            //    docXml.WriteElementString("codigo","0");
            //    docXml.WriteElementString("codigoPorcentaje","0");
            //    docXml.WriteElementString("baseImponible","0");
            //    docXml.WriteElementString("tarifa","0");
            //    docXml.WriteElementString("valor","0");
            //docXml.WriteEndElement();

            docXml.WriteEndElement(); //impuestos
            docXml.WriteElementString("valorTotal", doc["Doc_valor"].ToString());

            docXml.WriteEndElement(); //info nota de debito
            docXml.WriteStartElement("motivos"); 
                docXml.WriteStartElement  ("motivo");
                    docXml.WriteElementString("razon", doc["Doc_detalle"].ToString());
                    docXml.WriteElementString("valor", util.formatoDecimal(Convert.ToDouble(doc["subtotal"].ToString()), 14, 2));
                docXml.WriteEndElement(); // motivo
            docXml.WriteEndElement(); //motivos

            ChekAdicionales.registrarAdicionales(doc, docXml, false);

            docXml.WriteEndElement();  // notaDeCredito
            docXml.Flush();
            docXml.Close();
            return "OK";
        }

    }
}
