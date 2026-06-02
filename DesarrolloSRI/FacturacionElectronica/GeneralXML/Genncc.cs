using DattCom;
using DaxDocElectronicos;
using System;
using System.Data;
using System.Text;
using System.Xml;

namespace DaxDocElectronicos
{
    public class Genncc
    {
        private char cc = Convert.ToChar("0");
        private char bb = Convert.ToChar(" ");
        private Feutilidad util = new Feutilidad();

        public string crear_notaCredito_xml_sri(
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
            docXml.WriteStartElement("notaCredito");
            docXml.WriteAttributeString("version", "1.1.0");
            docXml.WriteAttributeString("id", "comprobante");
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
            string strConxIvaret1 = this.util.formatoNumero(doc["Doc_NroIdDoc"].ToString(), 7);
            docXml.WriteElementString("estab", strConxIvaret1.Substring(0, 3));
            docXml.WriteElementString("ptoEmi", strConxIvaret1.Substring(4, 3));
            docXml.WriteElementString("secuencial", this.util.formatoNumero(doc["Doc_numero"].ToString(), 9));
            docXml.WriteElementString("dirMatriz", this.util.formatoString(datosEmpresa.Emp_Dirección , 300));
            ChekAdicionales.registrarfuncionalidadEmisor(docXml);
            docXml.WriteEndElement();
            docXml.WriteStartElement("infoNotaCredito");
            docXml.WriteElementString("fechaEmision", this.util.formatoFecha(Convert.ToDateTime(doc["Doc_fecha"])));
            docXml.WriteElementString("tipoIdentificacionComprador", this.util.tipoId(doc["TipoIdentificacion"].ToString()));
            docXml.WriteElementString("razonSocialComprador", this.util.nombreCliente(ambiente, doc["Doc_NombreImp"].ToString()));
            docXml.WriteElementString("identificacionComprador", doc["Doc_CiRuc"].ToString());
            if (datosEmpresa.Emp_ContrBuyEsp.Length > 2) docXml.WriteElementString("contribuyenteEspecial", datosEmpresa.Emp_ContrBuyEsp);

            docXml.WriteElementString("obligadoContabilidad", datosEmpresa.Emp_Conta ? "SI" : "NO");
            if (doc["esRise"].ToString().ToUpper() == "S")
                docXml.WriteElementString("rise", "Contribuyente Regimen Simplificado RISE");
            docXml.WriteElementString("codDocModificado", this.util.tipoComprobanteSri(doc["DOC_tipoSoporte"].ToString()));
            docXml.WriteElementString("numDocModificado", this.util.formatoString(doc["Doc_idSriSoporte"].ToString(), 7) + "-" + this.util.formatoNumero(doc["Doc_numSoporte"].ToString(), 9));
            try
            {
                docXml.WriteElementString("fechaEmisionDocSustento", this.util.formatoFecha(Convert.ToDateTime(doc["Doc_fechaSoporte"])));
            }
            catch
            {
                docXml.WriteElementString("fechaEmisionDocSustento", "01/01/1900");
            }
            docXml.WriteElementString("totalSinImpuestos", this.util.formatoDecimal(Convert.ToDouble(doc["subtotal"]), 14, 2));
            docXml.WriteElementString("valorModificacion", this.util.formatoDecimal(Convert.ToDouble("0" + doc["doc_valor"].ToString()), 14, 2));
            docXml.WriteElementString("moneda", "DOLAR");
            docXml.WriteStartElement("totalConImpuestos");
            double num1 = Convert.ToDouble(doc["Doc_porceniva"]);


            if (Convert.ToDouble(doc["Doc_valoriva"]) != 0.0)
            {
                docXml.WriteStartElement("totalImpuesto");
                docXml.WriteElementString("codigo", "2");
                docXml.WriteElementString("codigoPorcentaje", datosSri.codigoIva(num1, strConxIvaret1));
                docXml.WriteElementString("baseImponible", doc["Doc_totciva"].ToString());
                docXml.WriteElementString("valor", doc["Doc_valoriva"].ToString());
                docXml.WriteEndElement();
            }
            if (Convert.ToDouble(doc["Doc_totsiva"]) != 0.0)
            {
                docXml.WriteStartElement("totalImpuesto");
                docXml.WriteElementString("codigo", "2");
                docXml.WriteElementString("codigoPorcentaje", "0");
                docXml.WriteElementString("baseImponible", doc["Doc_totsiva"].ToString());
                docXml.WriteElementString("valor", "0");
                docXml.WriteEndElement();
            }
            docXml.WriteEndElement();
            docXml.WriteElementString("motivo", doc["Doc_detalle"].ToString());
            docXml.WriteEndElement();
            docXml.WriteStartElement("detalles");
            for (int index = 0; index < dtra.Rows.Count; ++index)
            {
                DataRow row = dtra.Rows[index];
                string str = row["Tra_codigo"].ToString();
                if (str != "." && str.Length > 0)
                {
                    docXml.WriteStartElement("detalle");
                    docXml.WriteElementString("codigoInterno", this.util.formatoString(str, 25));
                    string strConxIvaret2 = this.util.formatoString(row["codigoAdicional"].ToString(), 25);
                    if (strConxIvaret2.Length > 0)
                        docXml.WriteElementString("codigoAuxiliar", strConxIvaret2);
                    docXml.WriteElementString("descripcion", this.util.formatoString(row["Tra_nombre"].ToString(), 300));
                    docXml.WriteElementString("cantidad", this.util.formatoDecimal(Convert.ToDouble(row["Tra_cantidad"]), 18, 6));
                    docXml.WriteElementString("precioUnitario", this.util.formatoDecimal(Convert.ToDouble(row["Tra_precuni"]), 18, 6));
                    docXml.WriteElementString("descuento", this.util.formatoDecimal(Convert.ToDouble(row["desctoUni"]), 14, 2));
                    docXml.WriteElementString("precioTotalSinImpuesto", this.util.formatoDecimal(Convert.ToDouble(row["Tra_prectot"]), 14, 2));
                    bool boolean = Convert.ToBoolean(row["Tra_sniva"]);
                    docXml.WriteStartElement("impuestos");
                    if (boolean)
                    {
                        docXml.WriteStartElement("impuesto");
                        docXml.WriteElementString("codigo", "2");
                        docXml.WriteElementString("codigoPorcentaje", datosSri.codigoIva(num1, strConxIvaret2));
                        double num2 = Convert.ToDouble(row["Tra_prectot"]);
                        num1 = Convert.ToDouble(row["Doc_porceniva"]);
                        docXml.WriteElementString("tarifa", this.util.formatoDecimal(num1, 5, 2));
                        docXml.WriteElementString("baseImponible", this.util.formatoDecimal(num2, 14, 2));
                        docXml.WriteElementString("valor", this.util.formatoDecimal(this.util.calcularValorIva(num1, num2), 14, 2));
                        docXml.WriteEndElement();
                    }
                    else
                    {
                        docXml.WriteStartElement("impuesto");
                        docXml.WriteElementString("codigo", "2");
                        docXml.WriteElementString("codigoPorcentaje", "0");
                        docXml.WriteElementString("tarifa", "0");
                        double numero = Convert.ToDouble(row["Tra_prectot"]);
                        docXml.WriteElementString("baseImponible", this.util.formatoDecimal(numero, 14, 2));
                        docXml.WriteElementString("valor", "0");
                        docXml.WriteEndElement();
                    }
                    docXml.WriteEndElement();
                    docXml.WriteEndElement();
                }
            }
            docXml.WriteEndElement();
            if (datosEmpresa.Emp_RUC == "1792323002001" && classDatEmp.NroAgenteRetencion.Length > 0)
            {
                ChekAdicionales.registrarAdicionales(doc, docXml, false);
            }
            docXml.WriteEndElement();
            docXml.Flush();
            docXml.Close();
            return "OK";
        }
    }
}
