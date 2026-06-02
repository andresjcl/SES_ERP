using DattCom;
using DaxDocElectronicos;
using System;
using System.Data;
using System.Text;
using System.Xml;

namespace DaxDocElectronicos
{
    public class GenRem
    {
        private char cc = Convert.ToChar("0");
        private char bb = Convert.ToChar(" ");
        private Feutilidad util = new Feutilidad();

        public string crear_Remision_xml_sri(
          ref DataRow doc,
          ref DataTable dtra,
          string pathfile,
          string clv,
          short ambiente,
          short tipoEmision)
        {
            string str1 = "OK";
            
            try
            {
                XmlTextWriter docXml = new XmlTextWriter(pathfile, Encoding.UTF8);
                docXml.WriteStartDocument(true);
                docXml.Formatting = Formatting.Indented;
                docXml.WriteStartElement("guiaRemision");
                docXml.WriteAttributeString("id", "comprobante");
                docXml.WriteAttributeString("version", "1.1.0");
                docXml.WriteStartElement("infoTributaria");
                docXml.WriteElementString(nameof(ambiente), this.util.formatoNumero(ambiente.ToString(), 1));
                docXml.WriteElementString(nameof(tipoEmision), this.util.formatoNumero(tipoEmision.ToString(), 1));
                docXml.WriteElementString("razonSocial", this.util.formatoString(datosEmpresa.Emp_Nombre, 300));
                if (datosEmpresa.Emp_RUC  == "1792323002001")
                {
                    docXml.WriteElementString("nombreComercial", this.util.formatoString("DASTRIFARM", 300));
                }
                else
                {
                    docXml.WriteElementString("nombreComercial", this.util.formatoString(datosEmpresa.Emp_Nombre, 300));
                }
                docXml.WriteElementString("ruc", datosEmpresa.Emp_RUC);
                docXml.WriteElementString("claveAcceso", clv);
                docXml.WriteElementString("codDoc", this.util.tipoComprobanteSri(doc["DOC_TipoDoc"].ToString()));
                string str2 = this.util.formatoNumero(doc["Doc_NroIdDoc"].ToString(), 7);
                docXml.WriteElementString("estab", str2.Substring(0, 3));
                docXml.WriteElementString("ptoEmi", str2.Substring(4, 3));
                docXml.WriteElementString("secuencial", this.util.formatoNumero(doc["Doc_numero"].ToString(), 9));
                docXml.WriteElementString("dirMatriz", this.util.formatoString(datosEmpresa.Emp_Dirección, 300));
                ChekAdicionales.registrarfuncionalidadEmisor(docXml);
                docXml.WriteEndElement();
                docXml.WriteStartElement("infoGuiaRemision");
                docXml.WriteElementString("dirPartida", this.util.formatoString(doc["dirPartida"].ToString(), 300));
                docXml.WriteElementString("razonSocialTransportista", this.util.formatoString(doc["nombreTransportista"].ToString(), 300));
                docXml.WriteElementString("tipoIdentificacionTransportista", this.util.tipoId(doc["tipoIdTransportista"].ToString()));
                docXml.WriteElementString("rucTransportista", doc["IdRucTransportista"].ToString());
                if (doc["esRise"].ToString() == "SI")
                    docXml.WriteElementString("rise", "Contribuyente Regimen Simplificado RISE");
                
                if (datosEmpresa.Emp_ContrBuyEsp.Length > 2) docXml.WriteElementString("contribuyenteEspecial", datosEmpresa.Emp_ContrBuyEsp);

                docXml.WriteElementString("obligadoContabilidad", datosEmpresa.Emp_Conta ? "SI" : "NO");
                docXml.WriteElementString("fechaIniTransporte", this.util.formatoFecha(Convert.ToDateTime(doc["FecIniTransporte"])));
                docXml.WriteElementString("fechaFinTransporte", this.util.formatoFecha(Convert.ToDateTime(doc["FecFinTransporte"])));
                docXml.WriteElementString("placa", doc["auxvar10"].ToString());
                docXml.WriteEndElement();
                docXml.WriteStartElement("destinatarios");
                docXml.WriteStartElement("destinatario");
                docXml.WriteElementString("identificacionDestinatario", this.util.formatoNumero(doc["doc_ciruc"].ToString(), 13));
                docXml.WriteElementString("razonSocialDestinatario", this.util.formatoString(doc["doc_nombreimp"].ToString(), 300));
                docXml.WriteElementString("dirDestinatario", this.util.formatoString(doc["doc_direccion"].ToString(), 300));
                docXml.WriteElementString("motivoTraslado", this.util.formatoString(doc["TipoTransporte"].ToString(), 300));
                docXml.WriteElementString("docAduaneroUnico", this.util.formatoString(doc["docAduaneroUnico"].ToString(), 20));
                string numero = doc["codEstabDestino"].ToString();
                docXml.WriteElementString("codEstabDestino", this.util.formatoNumero(numero, 3));
                docXml.WriteElementString("ruta", this.util.formatoString(doc["rutaTransporte"].ToString(), 300));
                string tipoDocAdc = doc["doc_docsop"].ToString();
                double num = Convert.ToDouble(doc["doc_numsop"].ToString());
                if (tipoDocAdc.Length != 0 && num != 0.0)
                {
                    docXml.WriteElementString("codDocSustento", this.util.tipoComprobanteSri(tipoDocAdc));
                    string str3 = this.util.formatoNumero(doc["auxvar11"].ToString(), 7) + "-" + this.util.formatoNumero(num.ToString(), 9);
                    docXml.WriteElementString("numDocSustento", str3);
                    docXml.WriteElementString("fechaEmisionDocSustento", this.util.formatoFecha(Convert.ToDateTime(doc["auxfec1"])));
                }
                docXml.WriteStartElement("detalles");
                for (int index = 0; index < dtra.Rows.Count; ++index)
                {
                    DataRow row = dtra.Rows[index];
                    docXml.WriteStartElement("detalle");
                    docXml.WriteElementString("codigoInterno", this.util.formatoString(row["Tra_codigo"].ToString(), 25));
                    string str4 = this.util.formatoString(row["codigoAdicional"].ToString(), 25);
                    if (str4.Length > 0)
                        docXml.WriteElementString("codigoAdicional", str4);
                    docXml.WriteElementString("descripcion", this.util.formatoString(row["Tra_nombre"].ToString(), 300));
                    docXml.WriteElementString("cantidad", this.util.formatoDecimal(Convert.ToDouble(row["Tra_cantidad"]), 18, 6));
                    docXml.WriteStartElement("detallesAdicionales");
                    docXml.WriteStartElement("detAdicional");
                    docXml.WriteAttributeString("valor", "v");
                    docXml.WriteAttributeString("nombre", "AX");
                    docXml.WriteEndElement();
                    docXml.WriteEndElement();
                    docXml.WriteEndElement();
                }
                docXml.WriteEndElement();
                docXml.WriteEndElement();
                docXml.WriteEndElement();
                if (datosEmpresa.Emp_RUC == "1792323002001" && classDatEmp.NroAgenteRetencion.Length > 0)
                {
                    ChekAdicionales.registrarAdicionales(doc, docXml, false);
                }
                //ChekAdicionales.registrarAdicionales(doc, docXml, false);
                docXml.WriteEndElement();
                docXml.Flush();
                docXml.Close();
            }
            catch (Exception ex)
            {
                str1 = "ERROR-AUTORIZACION: " + ex.Message;
            }
            return str1;
        }
    }
}
