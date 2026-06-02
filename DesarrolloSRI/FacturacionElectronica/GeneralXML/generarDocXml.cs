using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DaxDocElectronicos
{
    public class generarDocXml
    {
        string retorno = "";
        Boolean esExportacion = false;
        Char cc = Convert.ToChar("0");
        Char bb = Convert.ToChar(" ");
        DaxDocElectronicos.Feutilidad  util = new DaxDocElectronicos.Feutilidad ();
        //datosSri datsri = new datosSri();

        public string crear_factura_xml_sri(ref DataRow doc,ref DataTable dtra, string pathfile,string clv, Int16 ambiente,Int16 tipoEmision,Int16 decimales,string NombreEmpresa, string rucEmpresa, string DireccionEmpresa,string nombreBaseDatosIvaret,string strConxAdcom )
         // generar el archivo xml por facturacion para enviar al sri
        {
            try
            {                                
                string straux = "";
                int tarifaImpuesto = 0;
                double baseImpuesto = 0;
                esExportacion = ChekAdicionales.tieneExportacion(doc);

                //AdcDax.DaxSofSys daxemp = new AdcDax.DaxSofSys();

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
                docXml.WriteElementString("razonSocial", util.formatoString(NombreEmpresa, 300));
                docXml.WriteElementString("nombreComercial", util.formatoString(NombreEmpresa, 300));
                docXml.WriteElementString("ruc", rucEmpresa);
                docXml.WriteElementString("claveAcceso", clv);
                docXml.WriteElementString("codDoc", util.tipoComprobanteSri(doc["DOC_TipoDoc"].ToString()));

                straux = util.formatoNumero(doc["Doc_NroIdDoc"].ToString(), 7);
                docXml.WriteElementString("estab", straux.Substring(0, 3));
                docXml.WriteElementString("ptoEmi", straux.Substring(4, 3));

                docXml.WriteElementString("secuencial", util.formatoNumero(doc["Doc_numero"].ToString(), 9));
                docXml.WriteElementString("dirMatriz", util.formatoString(DireccionEmpresa, 300));

                
                try
                {
                    if (Convert.ToBoolean(doc["RegimenMicroempresas"]))
                    {
                        //docXml.WriteStartElement("campoAdicional");
                        //docXml.WriteAttributeString("nombre", "Contribuyente Régimen Microempresas");
                        //docXml.WriteString("SI");
                        //docXml.WriteEndElement();
                        docXml.WriteElementString("regimenMicroempresas", "CONTRIBUYENTE RÉGIMEN MICROEMPRESAS");
                    }
                }
                catch { } 

                try
                {
                    if (doc["NroAcdoAgntRetencion"].ToString().Length > 0)
                    {
                        //docXml.WriteStartElement("campoAdicional");
                        //docXml.WriteAttributeString("nombre", "Agente De Retención");
                        //docXml.WriteString(doc["NroAcdoAgntRetencion"].ToString().Trim());
                        //docXml.WriteEndElement();

                        docXml.WriteElementString("agenteRetencion",util.formatoString(doc["NroAcdoAgntRetencion"].ToString(),8));
                    }
                }
                catch { }




                docXml.WriteEndElement();

                docXml.WriteStartElement("infoFactura");
                docXml.WriteElementString("fechaEmision", util.formatoFecha(Convert.ToDateTime(doc["Doc_fecha"])));
                //docXml.WriteElementString("dirEstablecimiento", util.formatoString(doc["Doc_Direccion"].ToString(), 300));

                //if (classDatEmp.nroContribuyenteEspecial.Length > 2)
                //{ docXml.WriteElementString("contribuyenteEspecial", classDatEmp.nroContribuyenteEspecial); }

                //docXml.WriteElementString("obligadoContabilidad", classDatEmp.obligadoContabilidad);
                
                if (doc["empObligConta"].ToString().Length>2)
                { docXml.WriteElementString("contribuyenteEspecial", doc["NroCtrbuyteEspecial"].ToString()); }

                docXml.WriteElementString("obligadoContabilidad", doc["empObligConta"].ToString());
                
                if (esExportacion)
                {
                    docXml.WriteElementString("comercioExterior", "EXPORTADOR");
                    docXml.WriteElementString("incoTermFactura", doc["TerminosVent"].ToString());
                    docXml.WriteElementString("lugarIncoTerm", doc["CiudadFOB"].ToString());
                    docXml.WriteElementString("paisOrigen", doc["OrigProducto"].ToString());
                    docXml.WriteElementString("puertoEmbarque", doc["embarque"].ToString());
                    docXml.WriteElementString("puertoDestino", doc["PuertoDest"].ToString());
                    if (doc["paisDestino"].ToString().Length > 0) { docXml.WriteElementString("paisDestino", doc["paisDestino"].ToString()); }
                    if (doc["paisAdquisicion"].ToString().Length > 0) { docXml.WriteElementString("paisAdquisicion", doc["paisAdquisicion"].ToString()); }                    
                }
                
                
                docXml.WriteElementString("tipoIdentificacionComprador", util.tipoId(doc["TipoIdentificacion"].ToString()));

                straux = doc["guiaRemision"].ToString();
                if (straux.Length > 0) { docXml.WriteElementString("guiaRemision", straux); }

                docXml.WriteElementString("razonSocialComprador", util.nombreCliente(ambiente, doc["Doc_NombreImp"].ToString()));
                docXml.WriteElementString("identificacionComprador", doc["Doc_CiRuc"].ToString());
                                docXml.WriteElementString("direccionComprador", doc["Doc_Direccion"].ToString());

                docXml.WriteElementString("totalSinImpuestos", util.formatoDecimal(Convert.ToDouble(doc["subtotal"]), 14, 2));

                if (esExportacion) docXml.WriteElementString("incoTermTotalSinImpuestos", doc["TerminosVent"].ToString());

                double totDescUni = Convert.ToDouble("0" + doc["totDescUnitario"].ToString());
                if (totDescUni == 0) totDescUni = Convert.ToDouble("0" + doc["totalDescuento"].ToString());
                docXml.WriteElementString("totalDescuento", util.formatoDecimal(totDescUni, 14, 2));

                tarifaImpuesto = Convert.ToInt16(doc["Doc_porceniva"]);

                
                docXml.WriteStartElement("totalConImpuestos");

                // revisar codigo 2 en ambos ????
                if (Convert.ToDouble(doc["Doc_totciva"]) > 0)
                {
                    docXml.WriteStartElement("totalImpuesto");
                    docXml.WriteElementString("codigo", "2");
                    docXml.WriteElementString("codigoPorcentaje", datosSri.codigoIva(tarifaImpuesto, straux));
                    docXml.WriteElementString("baseImponible", util.formatoDecimal( doc["Doc_totciva"].ToString(),14,2));
                    docXml.WriteElementString("tarifa", tarifaImpuesto.ToString());
                    docXml.WriteElementString("valor", util.formatoDecimal(doc["Doc_valoriva"].ToString(),14,2));
                    docXml.WriteEndElement();
                }

                double val = Convert.ToDouble(doc["Doc_totsiva"]);

                if (Convert.ToDouble(doc["Doc_totsiva"]) > 0)
                {
                    docXml.WriteStartElement("totalImpuesto");
                    docXml.WriteElementString("codigo", "2");
                    docXml.WriteElementString("codigoPorcentaje", "0");
                    docXml.WriteElementString("baseImponible", util.formatoDecimal(doc["Doc_totsiva"].ToString(),14,2));
                    docXml.WriteElementString("tarifa", "0");
                    docXml.WriteElementString("valor", "0");
                    docXml.WriteEndElement();
                }

                // aumentar ice

                //docXml.WriteStartElement("totalImpuesto");
                //    docXml.WriteElementString("codigo","0");
                //    docXml.WriteElementString("codigoPorcentaje","0");
                //    docXml.WriteElementString("baseImponible","0");
                //    docXml.WriteElementString("tarifa","0");
                //    docXml.WriteElementString("valor","0");
                //docXml.WriteEndElement();

                docXml.WriteEndElement(); //total con impuestos

                docXml.WriteElementString("propina", "0");

                if (esExportacion && doc["flete"].ToString().Length > 0) docXml.WriteElementString("fleteInternacional", doc["flete"].ToString());
                if (esExportacion && doc["seguroInternacional"].ToString().Length > 0) docXml.WriteElementString("seguroInternacional", doc["seguroInternacional"].ToString());
                if (esExportacion && doc["gastosAduana"].ToString().Length > 0) docXml.WriteElementString("gastosAduaneros", doc["gastosAduana"].ToString());
                if (esExportacion && doc["gastosTransporte"].ToString().Length > 0) docXml.WriteElementString("gastosTransporteOtros", doc["gastosTransporte"].ToString());

                docXml.WriteElementString("importeTotal",util.formatoDecimal( doc["Doc_valor"].ToString(),14,2));
                docXml.WriteElementString("moneda", "DOLAR");

                daxDatos dat = new daxDatos();
                string ssql = "DAX_LEEPAGO '" + nombreBaseDatosIvaret  + "','" + doc["doc_sucursal"].ToString() + "','" + doc["opc_documento"].ToString() + "'," + doc["idclavedoc"].ToString();

                DataTable dtPagos = daxDatos.leerDatos(ssql,strConxAdcom);
                if (dtPagos.Rows.Count == 0)
                {
                    docXml.WriteStartElement ( "pagos");
                        docXml.WriteStartElement ( "pago");
                            docXml.WriteElementString("formaPago", "01");
                            docXml.WriteElementString("total", util.formatoDecimal(Convert.ToDouble(doc["Doc_valor"].ToString()),14,2));
                            docXml.WriteElementString("plazo", "0");
                            docXml.WriteElementString("unidadTiempo", "dias");
                        docXml.WriteEndElement();                
                    docXml.WriteEndElement();
                }
                else
                {
                    docXml.WriteStartElement ( "pagos");
                    string elPago = "";
                    foreach (DataRow rowPag in dtPagos.Rows)
                    {
                        try { elPago = rowPag["SriFormaDePago"].ToString().Trim(); if (elPago.Length == 0) elPago = "01"; }
                        catch { elPago = "01";}
                        docXml.WriteStartElement ( "pago");
                            docXml.WriteElementString("formaPago", util.formatoNumero(elPago, 2));
                            docXml.WriteElementString("total", util.formatoDecimal(Convert.ToDouble(rowPag["Pag_Valor"].ToString()),14,2));
                            docXml.WriteElementString("plazo", rowPag["diasPlazo"].ToString());
                            docXml.WriteElementString("unidadTiempo", "dias");
                        docXml.WriteEndElement();                
                    }
                    docXml.WriteEndElement();
                }

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

                        Boolean imp = Convert.ToBoolean(tra["Tra_sniva"]);
                        docXml.WriteStartElement("impuestos");
                        if (imp)
                        {
                            docXml.WriteStartElement("impuesto");
                            docXml.WriteElementString("codigo", "2");
                            docXml.WriteElementString("codigoPorcentaje", datosSri.codigoIva(tarifaImpuesto, straux));
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
                //daxemp = null;
                docXml.WriteEndElement(); // detalles

                ChekAdicionales.registrarAdicionales(doc, docXml, esExportacion);
                //int adicionales = ChekAdicionales.tieneAdicionales(doc);
                //if (adicionales  > 0 || esExportacion ) 
                //{
                //    docXml.WriteStartElement("infoAdicional");                                                            

                //    try
                //        {
                //            if (doc["NroCtrbuyteEspecial"].ToString().Length > 0)
                //            {
                //                docXml.WriteStartElement("campoAdicional");
                //                docXml.WriteAttributeString("nombre", "Agente De Retención");
                //                docXml.WriteString(doc["NroCtrbuyteEspecial"].ToString());
                //                docXml.WriteEndElement();
                //            }
                //        }
                //    catch { }
                    
                //    try
                //        {
                //            if (doc["ExportadorHabitualDeBienes"].ToString().Length > 0)
                //            {
                //                docXml.WriteStartElement("campoAdicional");
                //                docXml.WriteAttributeString("nombre", "ExportadorHabitualDeBienes");
                //                docXml.WriteString("Exportador Habitual de Bienes");
                //                docXml.WriteEndElement();
                //            }
                //        }
                //        catch { }

                //        try
                //        {
                //            if (doc["Doc_Detalle"].ToString().Length > 0)
                //            {
                //                docXml.WriteStartElement("campoAdicional");
                //                docXml.WriteAttributeString("nombre", "Detalle");
                //                docXml.WriteString(doc["Doc_Detalle"].ToString());
                //                docXml.WriteEndElement();
                //            }
                //        }
                //        catch { }
                    
                //        try
                //        {
                //            if (doc["Doc_NumSop"].ToString().Length > 0)
                //            {
                //                docXml.WriteStartElement("campoAdicional");
                //                docXml.WriteAttributeString("nombre", "pedido");
                //                docXml.WriteString(doc["Doc_NumSop"].ToString());
                //                docXml.WriteEndElement();
                //            }
                //        }
                //        catch { }

                //        try
                //        {
                //            if (doc["Doc_NroLoteDoc"].ToString().Length > 0)
                //            {
                //                docXml.WriteStartElement("campoAdicional");
                //                docXml.WriteAttributeString("nombre", "ORDEN COMPRA");
                //                docXml.WriteString(doc["Doc_NroLoteDoc"].ToString());
                //                docXml.WriteEndElement();
                //            }
                //        }
                //        catch { }


                //    if (doc["PreEntrada"].ToString().Length > 0)
                //    {
                //        docXml.WriteStartElement("campoAdicional");
                //        docXml.WriteAttributeString("nombre", "PreEntrada");
                //        docXml.WriteString(doc["PreEntrada"].ToString());
                //        docXml.WriteEndElement();
                //    }
                //    if (esExportacion)
                //    {
                //        if (doc["ConsignarA"].ToString().Length > 0)
                //        {
                //            docXml.WriteStartElement("campoAdicional");
                //            docXml.WriteAttributeString("nombre", "ConsignarA");
                //            docXml.WriteString(doc["ConsignarA"].ToString());
                //            docXml.WriteEndElement();
                //        }
                //        if (doc["Transporte"].ToString().Length > 0)
                //        {
                //            docXml.WriteStartElement("campoAdicional");
                //            docXml.WriteAttributeString("nombre", "Transportista");
                //            docXml.WriteString(doc["Transporte"].ToString());
                //            docXml.WriteEndElement();
                //        }
                //        if (doc["EndosarA"].ToString().Length > 0)
                //        {
                //            docXml.WriteStartElement("campoAdicional");
                //            docXml.WriteAttributeString("nombre", "EndosarA");
                //            docXml.WriteString(doc["EndosarA"].ToString());
                //            docXml.WriteEndElement();
                //        }
                //        if (doc["CondicionesVenta"].ToString().Length > 0)
                //        {
                //            docXml.WriteStartElement("campoAdicional");
                //            docXml.WriteAttributeString("nombre", "CondicionesVta");
                //            docXml.WriteString(doc["CondicionesVenta"].ToString());
                //            docXml.WriteEndElement();
                //        }
                //        //if ( doc["ValorFOB"].ToString().Length > 0)
                //        //{
                //        //    docXml.WriteStartElement("campoAdicional");
                //        //    docXml.WriteAttributeString("nombre", "ValorFOB");
                //        //    docXml.WriteString(doc["ValorFOB"].ToString());
                //        //    docXml.WriteEndElement();
                //        //}
                //        //if (doc["Transporte"].ToString().Length > 0)
                //        //{
                //        //    docXml.WriteStartElement("campoAdicional");
                //        //    docXml.WriteAttributeString("nombre", "Transporte");
                //        //    docXml.WriteString(doc["Transporte"].ToString());
                //        //    docXml.WriteEndElement();
                //        //}
                //    }
                //    docXml.WriteEndElement();
                //}
                //<campoAdicional nombre="PreEntrada">0187253438</campoAdicional>
                //<campoAdicional nombre="PreEntrada">123</campoAdicional>

                docXml.WriteEndElement();  // factura
                docXml.Flush();
                docXml.Close();
            }
            catch (Exception ex) 
            { 
              Console.Write ( ex.Message) ; 
              retorno = "ERROR " + ex.Message + "FACTURA XML"; 
            }
            
            return retorno ;                   
        }
        //private int tieneAdicionales (DataRow dt)
        //{
        //    int resp = 0;
        //    try
        //    {
        //        if (dt["PreEntrada"].ToString().Length > 0 || dt["ConsignarA"].ToString().Length > 0 || dt["Transporte"].ToString().Length > 0 || dt["endosarA"].ToString().Length > 0 || dt["CondicionesVenta"].ToString().Length > 0) return 1;
        //    }
        //    catch { }
        //    try
        //    {
        //        if (dt["ExportadorHabitualDeBienes"].ToString().Length > 0) return 9;
        //    }
        //    catch { }
        //    try
        //    {
        //        if (dt["Doc_NumSop"].ToString().Length > 0) return 8;
        //    }
        //    catch { }
        //    try
        //    {
        //        if (dt["Doc_Detalle"].ToString().Length > 0) return 1;
        //    }
        //    catch { }

        //    try
        //    {
        //        if (dt["NroCtrbuyteEspecial"].ToString().Length > 0) return 1;
        //    }
        //    catch { }
            
        //    return resp;
        //}
        //private Boolean tieneExportacion(DataRow dt)
        //{
        //    Boolean  resp = false ;
        //    try
        //    {
        //        if (dt["TerminosVent"].ToString().Length > 0 || dt["OrigProducto"].ToString().Length > 0 || dt["paisDestino"].ToString().Length > 0) return true;
        //    }
        //    catch { resp = false; }
        //    return resp;                    
        //}
    }
}
