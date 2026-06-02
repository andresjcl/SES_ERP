using DattCom;
using System;
using System.Data;
using System.Text;
using System.Xml;

namespace DaxDocElectronicos
{
    public class Genret
    {
        private char cc = Convert.ToChar("0");
        private char bb = Convert.ToChar(" ");
        private Feutilidad util = new Feutilidad();

        public string crear_Retencion_xml_sri(
          ref DataRow doc,
          ref DataTable dtra,
          string pathfile,
          string clv,
          short ambiente,
          short tipoEmision)
        {
            XmlTextWriter docXml = new XmlTextWriter(pathfile, Encoding.UTF8);
            docXml.WriteStartDocument(true);
            docXml.Formatting = Formatting.Indented;            
            docXml.WriteStartElement("comprobanteRetencion");
            docXml.WriteAttributeString("id", "comprobante");
            docXml.WriteAttributeString("version", "1.0.0");
            docXml.WriteStartElement("infoTributaria");
            docXml.WriteElementString(nameof(ambiente), this.util.formatoNumero(ambiente.ToString(), 1));
            docXml.WriteElementString(nameof(tipoEmision), this.util.formatoNumero(tipoEmision.ToString(), 1));
            docXml.WriteElementString("razonSocial", this.util.formatoString(datosEmpresa.Emp_Nombre, 300));
            if (datosEmpresa.Emp_RUC == "1792323002001")
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
            string str1 = this.util.formatoNumero(doc["Doc_NroIdDoc"].ToString(), 7);
            docXml.WriteElementString("estab", str1.Substring(0, 3));
            docXml.WriteElementString("ptoEmi", str1.Substring(4, 3));
            docXml.WriteElementString("secuencial", this.util.formatoNumero(doc["Doc_numero"].ToString(), 9));
            docXml.WriteElementString("dirMatriz", this.util.formatoString(datosEmpresa.Emp_Dirección , 300));
            ChekAdicionales.registrarfuncionalidadEmisor(docXml);
            docXml.WriteEndElement();
            docXml.WriteStartElement("infoCompRetencion");
            docXml.WriteElementString("fechaEmision", this.util.formatoFecha(Convert.ToDateTime(doc["Doc_fecha"].ToString())));
            if (datosEmpresa.Emp_ContrBuyEsp.Length > 2) docXml.WriteElementString("contribuyenteEspecial", datosEmpresa.Emp_ContrBuyEsp);

            docXml.WriteElementString("obligadoContabilidad", datosEmpresa.Emp_Conta ? "SI" : "NO");
            docXml.WriteElementString("tipoIdentificacionSujetoRetenido", this.util.tipoId(doc["TipoIdentificacion"].ToString()));
            docXml.WriteElementString("razonSocialSujetoRetenido", this.util.nombreCliente(ambiente, doc["Doc_NombreImp"].ToString()));
            docXml.WriteElementString("identificacionSujetoRetenido", doc["Doc_CiRuc"].ToString());
            docXml.WriteElementString("periodoFiscal", this.util.formatoFecha(Convert.ToDateTime(doc["doc_fecha"])).Substring(3));
            docXml.WriteEndElement();
            docXml.WriteStartElement("impuestos");
            double num1 = 0.0;
            string str2 = "";
            try
            {
                num1 = Convert.ToDouble(doc["BaseIvaBienes"].ToString());
                str2 = doc["CodigoRetIvaBienes"].ToString();
                if (str2.Length > 2)
                    str2 = this.util.codigoRetencionIva(Convert.ToDouble(doc["PorRetIvaBienes"].ToString()));
            }
            catch
            {
            }
            if (num1 != 0.0 && str2.Length > 0)
            {
                docXml.WriteStartElement("impuesto");
                docXml.WriteElementString("codigo", "2");
                docXml.WriteElementString("codigoRetencion", str2);
                docXml.WriteElementString("baseImponible", num1.ToString());
                docXml.WriteElementString("porcentajeRetener", doc["PorRetIvaBienes"].ToString());
                docXml.WriteElementString("valorRetenido", this.util.formatoDecimal(doc["ValorRetIvaBienes"].ToString(), 10, 2));
                docXml.WriteElementString("codDocSustento", this.util.formatoNumero(doc["Adi_TipoDocSri"].ToString(), 2));
                docXml.WriteElementString("numDocSustento", doc["iddocSop"].ToString().Replace("-", "") + this.util.formatoNumero(doc["DOC_numsop"].ToString(), 9));
                try
                {
                    docXml.WriteElementString("fechaEmisionDocSustento", this.util.formatoFecha(Convert.ToDateTime(doc["fechaSustento"])));
                }
                catch
                {
                }
                docXml.WriteEndElement();
            }
            double num2 = 0.0;
            string str3 = "";
            try
            {
                num2 = Convert.ToDouble(doc["BaseIvaServicios"].ToString());
                str3 = doc["CodigoRetIvaServicios"].ToString();
                if (str3.Length > 2)
                    str3 = this.util.codigoRetencionIva(Convert.ToDouble(doc["PorRetIvaServicios"].ToString()));
            }
            catch
            {
            }
            if (num2 != 0.0 && str3.Length > 0)
            {
                docXml.WriteStartElement("impuesto");
                docXml.WriteElementString("codigo", "2");
                docXml.WriteElementString("codigoRetencion", str3);
                docXml.WriteElementString("baseImponible", num2.ToString());
                docXml.WriteElementString("porcentajeRetener", doc["PorRetIvaServicios"].ToString());
                docXml.WriteElementString("valorRetenido", this.util.formatoDecimal(doc["ValorRetIvaServicios"].ToString(), 12, 2));
                docXml.WriteElementString("codDocSustento", this.util.formatoNumero(doc["Adi_TipoDocSri"].ToString(), 2));
                docXml.WriteElementString("numDocSustento", doc["iddocSop"].ToString().Replace("-", "") + this.util.formatoNumero(doc["DOC_numsop"].ToString(), 9));
                try
                {
                    docXml.WriteElementString("fechaEmisionDocSustento", this.util.formatoFecha(Convert.ToDateTime(doc["fechaSustento"])));
                }
                catch
                {
                }
                docXml.WriteEndElement();
            }
            double num3 = Convert.ToDouble(doc["BaseRetFuente"].ToString());
            if (num3 != 0.0)
            {
                docXml.WriteStartElement("impuesto");
                docXml.WriteElementString("codigo", "1");
                docXml.WriteElementString("codigoRetencion", doc["CodigoRetFuente"].ToString());
                docXml.WriteElementString("baseImponible", num3.ToString());
                docXml.WriteElementString("porcentajeRetener", doc["PorRetFuente"].ToString());
                docXml.WriteElementString("valorRetenido", this.util.formatoDecimal(doc["ValorRetFuente"].ToString(), 12, 2));
                docXml.WriteElementString("codDocSustento", this.util.formatoNumero(doc["Adi_TipoDocSri"].ToString(), 2));
                docXml.WriteElementString("numDocSustento", doc["iddocSop"].ToString().Replace("-", "") + this.util.formatoNumero(doc["DOC_numsop"].ToString(), 9));
                try
                {
                    docXml.WriteElementString("fechaEmisionDocSustento", this.util.formatoFecha(Convert.ToDateTime(doc["fechaSustento"])));
                }
                catch
                {
                }
                docXml.WriteEndElement();
            }
            double num4 = Convert.ToDouble(doc["BaseRetFuente1"].ToString());
            if (num4 != 0.0)
            {
                docXml.WriteStartElement("impuesto");
                docXml.WriteElementString("codigo", "1");
                docXml.WriteElementString("codigoRetencion", doc["CodigoRetFuente1"].ToString());
                docXml.WriteElementString("baseImponible", num4.ToString());
                docXml.WriteElementString("porcentajeRetener", doc["PorRetFuente1"].ToString());
                docXml.WriteElementString("valorRetenido", this.util.formatoDecimal(doc["ValorRetFuente1"].ToString(), 12, 2));
                docXml.WriteElementString("codDocSustento", this.util.formatoNumero(doc["Adi_TipoDocSri"].ToString(), 2));
                docXml.WriteElementString("numDocSustento", doc["iddocSop"].ToString().Replace("-", "") + this.util.formatoNumero(doc["DOC_numsop"].ToString(), 9));
                try
                {
                    docXml.WriteElementString("fechaEmisionDocSustento", this.util.formatoFecha(Convert.ToDateTime(doc["fechaSustento"])));
                }
                catch
                {
                }
                docXml.WriteEndElement();
            }
            docXml.WriteEndElement();
            if (datosEmpresa.Emp_RUC == "1792323002001" && classDatEmp.NroAgenteRetencion.Length > 0)
            {
                ChekAdicionales.registrarAdicionales(doc, docXml, false);
            }
            ////ChekAdicionales.registrarAdicionales(doc, docXml, false);
            docXml.WriteEndElement();
            docXml.Flush();
            docXml.Close();
            return "OK";
        }
    }
}






