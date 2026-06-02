using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;

namespace AdcGenxml
{
    class GenFacExp
    {

        string retorno = "";
        Char cc = Convert.ToChar("0");
        Char bb = Convert.ToChar(" ");
        adcFeutil.Feutilidad util = new adcFeutil.Feutilidad();

        public string crear_facturaExpotacion_xml_sri(ref DataRow doc, ref DataTable dtra, string pathfile, string clv, Int16 ambiente, Int16 tipoEmision, Int16 decimales)
        // generar el archivo xml por facturacion para enviar al sri
        {
            try
            {
                string straux = "";
                int tarifaImpuesto = 0;
                double baseImpuesto = 0;
                AdcDax.DaxSofSys daxemp = new AdcDax.DaxSofSys();

                XmlTextWriter docXml = new XmlTextWriter(pathfile, System.Text.Encoding.UTF8);
                docXml.WriteStartDocument(true);
                docXml.Formatting = Formatting.Indented;
                docXml.WriteComment("Generado por: Sistema AdcomDx de DaxsofSistem 0999906974 Quito Ecuador");

                docXml.WriteStartElement("factura");
                docXml.WriteAttributeString("id", "comprobante");
                docXml.WriteAttributeString("version", "1.1.0");
                docXml.WriteStartElement("infoTributaria");
                docXml.WriteElementString("ambiente", util.formatoNumero(ambiente.ToString(), 1));
                docXml.WriteElementString("tipoEmision", util.formatoNumero(tipoEmision.ToString(), 1));
                docXml.WriteElementString("razonSocial", util.formatoString(daxemp.EmpresaAct.nombre, 300));
                docXml.WriteElementString("nombreComercial", util.formatoString(daxemp.EmpresaAct.nombre, 300));
                docXml.WriteElementString("ruc", daxemp.EmpresaAct.ruc);
                docXml.WriteElementString("claveAcceso", clv);
                docXml.WriteElementString("codDoc", util.tipoComprobanteSri(doc["DOC_TipoDoc"].ToString()));

                straux = util.formatoNumero(doc["Doc_NroIdDoc"].ToString(), 7);
                docXml.WriteElementString("estab", straux.Substring(0, 3));
                docXml.WriteElementString("ptoEmi", straux.Substring(4, 3));

                docXml.WriteElementString("secuencial", util.formatoNumero(doc["Doc_numero"].ToString(), 9));
                docXml.WriteElementString("dirMatriz", util.formatoString(daxemp.EmpresaAct.direccion, 300));
                docXml.WriteEndElement();

                docXml.WriteStartElement("infoFactura");
                docXml.WriteElementString("fechaEmision", util.formatoFecha(Convert.ToDateTime(doc["Doc_fecha"])));
                //docXml.WriteElementString("dirEstablecimiento", util.formatoString(doc["Doc_Direccion"].ToString(), 300));

                if (doc["NroCtrbuyteEspecial"].ToString().Length > 2)
                { docXml.WriteElementString("contribuyenteEspecial", doc["NroCtrbuyteEspecial"].ToString()); }

                docXml.WriteElementString("obligadoContabilidad", util.ObligadoLlevarContabilidad(Convert.ToBoolean(doc["ObligLlevarConta"])));
                
                
                
                
                
                
                
                docXml.WriteElementString("tipoIdentificacionComprador", util.tipoId(doc["TipoIdentificacion"].ToString()));

                straux = doc["guiaRemision"].ToString();
                if (straux.Length > 0) { docXml.WriteElementString("guiaRemision", straux); }

                docXml.WriteElementString("razonSocialComprador", util.nombreCliente(ambiente, doc["Doc_NombreImp"].ToString()));
                docXml.WriteElementString("identificacionComprador", doc["Doc_CiRuc"].ToString());

                docXml.WriteElementString("totalSinImpuestos", util.formatoDecimal(Convert.ToDouble(doc["subtotal"]), 14, 2));

                double totDescUni = Convert.ToDouble("0" + doc["totDescUnitario"].ToString());
                if (totDescUni == 0) totDescUni = Convert.ToDouble("0" + doc["totalDescuento"].ToString());
                docXml.WriteElementString("totalDescuento", util.formatoDecimal(totDescUni, 14, 2));

                tarifaImpuesto = Convert.ToInt16(doc["Doc_porceniva"]);

                docXml.WriteStartElement("totalConImpuestos");

                if (Convert.ToDouble(doc["Doc_valoriva"]) != 0)
                {
                    docXml.WriteStartElement("totalImpuesto");
                    docXml.WriteElementString("codigo", "2");
                    docXml.WriteElementString("codigoPorcentaje", "2");
                    docXml.WriteElementString("baseImponible", doc["Doc_totciva"].ToString());
                    docXml.WriteElementString("tarifa", tarifaImpuesto.ToString());
                    docXml.WriteElementString("valor", doc["Doc_valoriva"].ToString());
                    docXml.WriteEndElement();
                }

                if (Convert.ToDouble(doc["Doc_totsiva"]) != 0)
                {
                    docXml.WriteStartElement("totalImpuesto");
                    docXml.WriteElementString("codigo", "2");
                    docXml.WriteElementString("codigoPorcentaje", "0");
                    docXml.WriteElementString("baseImponible", doc["Doc_totsiva"].ToString());
                    docXml.WriteElementString("tarifa", "0");
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

                docXml.WriteEndElement(); //total con impuestos

                docXml.WriteElementString("propina", "0");
                docXml.WriteElementString("importeTotal", doc["Doc_valor"].ToString());
                docXml.WriteElementString("moneda", "DOLAR");
                docXml.WriteEndElement(); //info factura


                docXml.WriteStartElement("detalles");
                for (int i = 0; i < dtra.Rows.Count; i++)
                {
                    DataRow tra = dtra.Rows[i];
                    string codigo = tra["Tra_codigo"].ToString();
                    if (codigo != "." && codigo.Length > 0)
                    {
                        docXml.WriteStartElement("detalle");
                        docXml.WriteElementString("codigoPrincipal", util.formatoString(codigo, 25));
                        straux = util.formatoString(tra["codigoAuxiliar"].ToString(), 25);
                        if (straux.Length > 0) { docXml.WriteElementString("codigoAuxiliar", straux); }
                        docXml.WriteElementString("descripcion", util.formatoString(tra["Tra_nombre"].ToString(), 300));
                        docXml.WriteElementString("cantidad", util.formatoDecimal(Convert.ToDouble(tra["Tra_cantidad"]), 18, decimales));
                        docXml.WriteElementString("precioUnitario", util.formatoDecimal(Convert.ToDouble(tra["Tra_precuni"]), 18, decimales));
                        docXml.WriteElementString("descuento", util.formatoDecimal(Convert.ToDouble(tra["desctoUni"]), 14, 2));
                        docXml.WriteElementString("precioTotalSinImpuesto", util.formatoDecimal(Convert.ToDouble(tra["Tra_prectot"]), 14, 2));

                        //docXml.WriteStartElement("detallesAdicionales");
                        //    docXml.WriteStartElement("detAdicional");
                        //        docXml.WriteAttributeString("valor", "v");
                        //        docXml.WriteAttributeString("nombre", "AX");
                        //    docXml.WriteEndElement();
                        //docXml.WriteEndElement();
                        Boolean imp = Convert.ToBoolean(tra["Tra_sniva"]);
                        docXml.WriteStartElement("impuestos");
                        if (imp)
                        {
                            docXml.WriteStartElement("impuesto");
                            docXml.WriteElementString("codigo", "2");
                            docXml.WriteElementString("codigoPorcentaje", "2");
                            baseImpuesto = Convert.ToDouble(tra["Tra_prectot"]);
                            docXml.WriteElementString("tarifa", tarifaImpuesto.ToString());
                            docXml.WriteElementString("baseImponible", util.formatoDecimal(baseImpuesto, 14, 2));
                            docXml.WriteElementString("valor", util.formatoDecimal(util.calcularValorIva(tarifaImpuesto, baseImpuesto), 14, 2));
                            docXml.WriteEndElement();
                        }
                        else
                        {
                            docXml.WriteStartElement("impuesto");
                            docXml.WriteElementString("codigo", "2");
                            docXml.WriteElementString("codigoPorcentaje", "0");
                            docXml.WriteElementString("tarifa", "0");
                            baseImpuesto = Convert.ToDouble(tra["Tra_prectot"]);
                            docXml.WriteElementString("baseImponible", util.formatoDecimal(baseImpuesto, 14, 2));
                            docXml.WriteElementString("valor", "0");
                            docXml.WriteEndElement();
                        }

                        docXml.WriteEndElement(); //impuestos

                        docXml.WriteEndElement(); // detalle
                    }
                }
                docXml.WriteEndElement(); // detalles
                int adicionales = tieneAdicionales(doc);
                if (adicionales > 0) // aumentar "OR" con los  valores adicionales que se desea
                {
                    docXml.WriteStartElement("infoAdicional");

                    if (doc["PreEntrada"].ToString().Length > 0)
                    {
                        docXml.WriteStartElement("campoAdicional");
                        docXml.WriteAttributeString("nombre", "PreEntrada");
                        docXml.WriteString(doc["PreEntrada"].ToString());
                        docXml.WriteEndElement();
                    }
                    else if (adicionales == 2)
                    {
                        //                ,ConsignarA,transportarNom as Transporte,endosarNom as EndosarA,CondicionesVenta,puertoDest as Destino
                        //                    ,Embarque,ViaEmbarque,totalPesoBruto,TotalPesoNeto,ValorFob

                        if (doc["ConsignarA"].ToString().Length > 0)
                        {
                            docXml.WriteStartElement("campoAdicional");
                            docXml.WriteAttributeString("nombre", "ConsignarA");
                            docXml.WriteString(doc["ConsignarA"].ToString());
                            docXml.WriteEndElement();
                        }
                        if (doc["Transporte"].ToString().Length > 0)
                        {
                            docXml.WriteStartElement("campoAdicional");
                            docXml.WriteAttributeString("nombre", "Transporte");
                            docXml.WriteString(doc["Transporte"].ToString());
                            docXml.WriteEndElement();
                        }
                        if (doc["EndosarA"].ToString().Length > 0)
                        {
                            docXml.WriteStartElement("campoAdicional");
                            docXml.WriteAttributeString("nombre", "EndosarA");
                            docXml.WriteString(doc["EndosarA"].ToString());
                            docXml.WriteEndElement();
                        }
                        if (doc["CondicionesVta"].ToString().Length > 0)
                        {
                            docXml.WriteStartElement("campoAdicional");
                            docXml.WriteAttributeString("nombre", "CondicionesVta");
                            docXml.WriteString(doc["CondicionesVta"].ToString());
                            docXml.WriteEndElement();
                        }
                        if (doc["Destino"].ToString().Length > 0)
                        {
                            docXml.WriteStartElement("campoAdicional");
                            docXml.WriteAttributeString("nombre", "Destino");
                            docXml.WriteString(doc["Destino"].ToString());
                            docXml.WriteEndElement();
                        }
                        if (doc["Embarque"].ToString().Length > 0)
                        {
                            docXml.WriteStartElement("campoAdicional");
                            docXml.WriteAttributeString("nombre", "Embarque");
                            docXml.WriteString(doc["Embarque"].ToString());
                            docXml.WriteEndElement();
                        }
                        if (doc["ViaEmbarque"].ToString().Length > 0)
                        {
                            docXml.WriteStartElement("campoAdicional");
                            docXml.WriteAttributeString("nombre", "ViaEmbarque");
                            docXml.WriteString(doc["ViaEmbarque"].ToString());
                            docXml.WriteEndElement();
                        }
                        if (doc["ValorFOB"].ToString().Length > 0)
                        {
                            docXml.WriteStartElement("campoAdicional");
                            docXml.WriteAttributeString("nombre", "ValorFOB");
                            docXml.WriteString(doc["ValorFOB"].ToString());
                            docXml.WriteEndElement();
                        }
                        if (doc["Flete"].ToString().Length > 0)
                        {
                            docXml.WriteStartElement("campoAdicional");
                            docXml.WriteAttributeString("nombre", "Flete");
                            docXml.WriteString(doc["Flete"].ToString());
                            docXml.WriteEndElement();
                        }
                        //if (doc["Transporte"].ToString().Length > 0)
                        //{
                        //    docXml.WriteStartElement("campoAdicional");
                        //    docXml.WriteAttributeString("nombre", "Transporte");
                        //    docXml.WriteString(doc["Transporte"].ToString());
                        //    docXml.WriteEndElement();
                        //}
                    }

                    docXml.WriteEndElement();
                }
                //<campoAdicional nombre="PreEntrada">0187253438</campoAdicional>
                //<campoAdicional nombre="PreEntrada">123</campoAdicional>

                docXml.WriteEndElement();  // factura
                docXml.Flush();
                docXml.Close();
            }
            catch (Exception ee)
            { retorno = "ERROR " + ee.Message; }
            return retorno;
        }
        private int tieneAdicionales(DataRow dt)
        {
            int resp = 0;
            try
            {
                if (dt["PreEntrada"].ToString().Length > 0) return 1;
            }
            catch { resp = 0; }

            try
            {
                if (dt["ConsignarA"].ToString().Length > 0 || dt["transporte"].ToString().Length > 0 || dt["ValorFob"].ToString().Length > 0) return 2;
            }
            catch { resp = 0; }
            return resp;
            //                ,consignarNom as ConsignarA,transportarNom as Transporte,endosarNom as EndosarA,CondicionesVenta,puertoDest as Destino
            //                    ,Embarque,ViaEmbarque,totalPesoBruto,TotalPesoNeto,ValorFob
        }



    }
}
