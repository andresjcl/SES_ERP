using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Xml;
using DaxDocElectronicos;
using DattCom;

namespace DaxDocElectronicos
{
    public class GenLiqcom
    {
        private string retorno = "";
        private char cc = Convert.ToChar("0");
        private char bb = Convert.ToChar(" ");
        private Feutilidad util = new Feutilidad();

        public string crear_LiquidacionCompra(
          ref DataRow doc,
          ref DataTable dtra,
          string pathfile,
          string clv,
          short ambiente,
          short tipoEmision,
          short decimales,
          string NombreEmpresa,
          string rucEmpresa,
          string DireccionEmpresa,
          string nombreBaseDatosIvaret,
          string strConxAdcom)
        {
            DataTable dataTable1 = daxDatos.leerReembolsos(doc["DOC_Sucursal"].ToString(), doc["opc_documento"].ToString(), Convert.ToDouble(doc["IdClaveDoc"].ToString()), strConxAdcom);
            try
            {
                string strConxIvaret = "";
                XmlTextWriter docXml = new XmlTextWriter(pathfile, Encoding.UTF8);
                docXml.WriteStartDocument(true);
                docXml.Formatting = Formatting.Indented;
                //docXml.WriteComment("Generado por: Sistema AdcomDx de DaxsofSistem 0999906974 Quito Ecuador");
                docXml.WriteStartElement("liquidacionCompra");
                docXml.WriteAttributeString("id", "comprobante");
                docXml.WriteAttributeString("version", "1.1.0");
                docXml.WriteStartElement("infoTributaria");
                docXml.WriteElementString(nameof(ambiente), this.util.formatoNumero(ambiente.ToString(), 1));
                docXml.WriteElementString(nameof(tipoEmision), this.util.formatoNumero(tipoEmision.ToString(), 1));
                docXml.WriteElementString("razonSocial", this.util.formatoString(NombreEmpresa, 300));
                if (rucEmpresa == "1792323002001")
                {
                    docXml.WriteElementString("nombreComercial", this.util.formatoString("DASTRIFARM", 300));
                }
                else
                {
                    docXml.WriteElementString("nombreComercial", this.util.formatoString(NombreEmpresa, 300));
                }
                docXml.WriteElementString("ruc", rucEmpresa);
                docXml.WriteElementString("claveAcceso", clv);
                docXml.WriteElementString("codDoc", this.util.tipoComprobanteSri(doc["DOC_TipoDoc"].ToString()));
                try
                {
                    strConxIvaret = this.util.formatoNumero(doc["Doc_NroIdDoc"].ToString(), 7);
                    docXml.WriteElementString("estab", strConxIvaret.Substring(0, 3));
                    docXml.WriteElementString("ptoEmi", strConxIvaret.Substring(4, 3));
                }
                catch
                {
                }
                docXml.WriteElementString("secuencial", this.util.formatoNumero(doc["Doc_numero"].ToString(), 9));
                docXml.WriteElementString("dirMatriz", this.util.formatoString(DireccionEmpresa, 300));

                ChekAdicionales.registrarfuncionalidadEmisor(docXml);
                docXml.WriteEndElement();
                docXml.WriteStartElement("infoLiquidacionCompra");
                docXml.WriteElementString("fechaEmision", this.util.formatoFecha(Convert.ToDateTime(doc["Doc_fecha"])));
                docXml.WriteElementString("dirEstablecimiento", this.util.formatoString(doc["Doc_Direccion"].ToString(), 300));
                if (datosEmpresa.Emp_ContrBuyEsp.Length > 2) docXml.WriteElementString("contribuyenteEspecial", datosEmpresa.Emp_ContrBuyEsp);

                docXml.WriteElementString("obligadoContabilidad", datosEmpresa.Emp_Conta ? "SI" : "NO");

                docXml.WriteElementString("tipoIdentificacionProveedor", this.util.tipoId(doc["TipoIdentificacion"].ToString()));
                docXml.WriteElementString("razonSocialProveedor", this.util.nombreCliente(ambiente, doc["Doc_NombreImp"].ToString()));
                docXml.WriteElementString("identificacionProveedor", doc["Doc_CiRuc"].ToString());
                docXml.WriteElementString("direccionProveedor", doc["Doc_Direccion"].ToString());
                docXml.WriteElementString("totalSinImpuestos", this.util.formatoDecimal(Convert.ToDouble(doc["subtotal"]), 14, 2));
                double numero1 = Convert.ToDouble("0" + doc["totDescUnitario"].ToString());
                if (numero1 == 0.0)
                    numero1 = Convert.ToDouble("0" + doc["totalDescuento"].ToString());
                docXml.WriteElementString("totalDescuento", this.util.formatoDecimal(numero1, 14, 2));
                bool flag = false;
                try
                {
                    flag = doc["codDocReembolso"].ToString() == "41";
                }
                catch
                {
                }
                dataTable1.NewRow();
                if (flag)
                {
                    DataRow row = dataTable1.Rows[0];
                    docXml.WriteElementString("codDocReembolso", this.util.formatoNumero(row["codDocReembolso"].ToString(), 2));
                    double numero2 = Convert.ToDouble("0" + row["totalComprobantesReembolso"].ToString());
                    docXml.WriteElementString("totalComprobantesReembolso", this.util.formatoDecimal(numero2, 14, 2));
                    double numero3 = Convert.ToDouble("0" + row["totalBaseImponibleReembolso"].ToString());
                    docXml.WriteElementString("totalBaseImponibleReembolso", this.util.formatoDecimal(numero3, 14, 2));
                    double numero4 = Convert.ToDouble("0" + row["totalImpuestoReembolso"].ToString());
                    docXml.WriteElementString("totalImpuestoReembolso", this.util.formatoDecimal(numero4, 14, 2));
                }
                int int16_1 = (int)Convert.ToInt16(doc["Doc_porceniva"]);
                docXml.WriteStartElement("totalConImpuestos");
                docXml.WriteStartElement("totalImpuesto");
                docXml.WriteElementString("codigo", "2");
                docXml.WriteElementString("codigoPorcentaje", datosSri.codigoIva((double)int16_1, strConxIvaret));
                docXml.WriteElementString("baseImponible", this.util.formatoDecimal(doc["Doc_totciva"].ToString(), 14, 2));
                docXml.WriteElementString("tarifa", int16_1.ToString());
                docXml.WriteElementString("valor", this.util.formatoDecimal(doc["Doc_valoriva"].ToString(), 14, 2));
                docXml.WriteEndElement();
                Convert.ToDouble(doc["Doc_totsiva"]);
                docXml.WriteStartElement("totalImpuesto");
                docXml.WriteElementString("codigo", "2");
                docXml.WriteElementString("codigoPorcentaje", "0");
                docXml.WriteElementString("baseImponible", this.util.formatoDecimal(doc["Doc_totsiva"].ToString(), 14, 2));
                docXml.WriteElementString("tarifa", "0");
                docXml.WriteElementString("valor", "0");
                docXml.WriteEndElement();
                docXml.WriteEndElement();
                docXml.WriteElementString("importeTotal", this.util.formatoDecimal(doc["Doc_valor"].ToString(), 14, 2));
                docXml.WriteElementString("moneda", "DOLAR");
                DataTable dataTable2 = daxDatos.leerDatos("DAX_LEEPAGO '" + nombreBaseDatosIvaret + "','" + doc["doc_sucursal"].ToString() + "','" + doc["opc_documento"].ToString() + "'," + doc["idclavedoc"].ToString(), strConxAdcom);
                if (dataTable2.Rows.Count == 0)
                {
                    docXml.WriteStartElement("pagos");
                    docXml.WriteStartElement("pago");
                    docXml.WriteElementString("formaPago", "01");
                    docXml.WriteElementString("total", this.util.formatoDecimal(Convert.ToDouble(doc["Doc_valor"].ToString()), 14, 2));
                    docXml.WriteElementString("plazo", "0");
                    docXml.WriteElementString("unidadTiempo", "dias");
                    docXml.WriteEndElement();
                    docXml.WriteEndElement();
                }
                else
                {
                    docXml.WriteStartElement("pagos");
                    foreach (DataRow row in (InternalDataCollectionBase)dataTable2.Rows)
                    {
                        string numero5;
                        try
                        {
                            numero5 = row["SriFormaDePago"].ToString().Trim();
                            if (numero5.Length == 0)
                                numero5 = "01";
                        }
                        catch
                        {
                            numero5 = "01";
                        }
                        docXml.WriteStartElement("pago");
                        docXml.WriteElementString("formaPago", this.util.formatoNumero(numero5, 2));
                        docXml.WriteElementString("total", this.util.formatoDecimal(Convert.ToDouble(row["Pag_Valor"].ToString()), 14, 2));
                        docXml.WriteElementString("plazo", row["diasPlazo"].ToString());
                        docXml.WriteElementString("unidadTiempo", "dias");
                        docXml.WriteEndElement();
                    }
                    docXml.WriteEndElement();
                }
                docXml.WriteEndElement();
                docXml.WriteStartElement("detalles");
                for (int index = 0; index < dtra.Rows.Count; ++index)
                {
                    DataRow row = dtra.Rows[index];
                    string str = row["Tra_codigo"].ToString();
                    if (str != "." && str.Length > 0)
                    {
                        docXml.WriteStartElement("detalle");
                        docXml.WriteElementString("codigoPrincipal", this.util.formatoString(str, 25));
                        strConxIvaret = this.util.formatoString(row["codigoAuxiliar"].ToString(), 25);
                        if (strConxIvaret.Length > 0)
                            docXml.WriteElementString("codigoAuxiliar", strConxIvaret);
                        docXml.WriteElementString("descripcion", this.util.formatoString(row["Tra_nombre"].ToString(), 300));
                        docXml.WriteElementString("cantidad", this.util.formatoDecimal(Convert.ToDouble(row["Tra_cantidad"]), 18, (int)decimales));
                        docXml.WriteElementString("precioUnitario", this.util.formatoDecimal(Convert.ToDouble(row["Tra_precuni"]), 18, (int)decimales));
                        docXml.WriteElementString("descuento", this.util.formatoDecimal(Convert.ToDouble(row["desctoUni"]), 14, 2));
                        docXml.WriteElementString("precioTotalSinImpuesto", this.util.formatoDecimal(Convert.ToDouble(row["Tra_prectot"]), 14, 2));
                        bool boolean = Convert.ToBoolean(row["Tra_sniva"]);
                        docXml.WriteStartElement("impuestos");
                        if (boolean)
                        {
                            docXml.WriteStartElement("impuesto");
                            docXml.WriteElementString("codigo", "2");
                            docXml.WriteElementString("codigoPorcentaje", datosSri.codigoIva((double)int16_1, strConxIvaret));
                            double num = Convert.ToDouble(row["Tra_prectot"]);
                            docXml.WriteElementString("tarifa", int16_1.ToString());
                            docXml.WriteElementString("baseImponible", this.util.formatoDecimal(num, 14, 2));
                            docXml.WriteElementString("valor", this.util.formatoDecimal(this.util.calcularValorIva((double)int16_1, num), 14, 2));
                            docXml.WriteEndElement();
                        }
                        else
                        {
                            docXml.WriteStartElement("impuesto");
                            docXml.WriteElementString("codigo", "2");
                            docXml.WriteElementString("codigoPorcentaje", "0");
                            docXml.WriteElementString("tarifa", "0");
                            double numero6 = Convert.ToDouble(row["Tra_prectot"]);
                            docXml.WriteElementString("baseImponible", this.util.formatoDecimal(numero6, 14, 2));
                            docXml.WriteElementString("valor", "0");
                            docXml.WriteEndElement();
                        }
                        docXml.WriteEndElement();
                        docXml.WriteEndElement();
                    }
                }
                docXml.WriteEndElement();
                if (flag)
                {
                    docXml.WriteStartElement("reembolsos");
                    foreach (DataRow row in (InternalDataCollectionBase)dataTable1.Rows)
                    {
                        docXml.WriteStartElement("reembolsoDetalle");
                        docXml.WriteElementString("tipoIdentificacionProveedorReembolso", this.util.tipoId(row["tipoIdentificacionProveedorReembolso"].ToString()));
                        docXml.WriteElementString("identificacionProveedorReembolso", row["identificacionProveedorReembolso"].ToString());
                        docXml.WriteElementString("codPaisPagoProveedorReembolso", row["codPaisPagoProveedorReembolso"].ToString());
                        docXml.WriteElementString("tipoProveedorReembolso", row["tipoProveedorReembolso"].ToString());
                        docXml.WriteElementString("codDocReembolso", this.util.formatoNumero(row["codDocReembolso"].ToString(), 2));
                        docXml.WriteElementString("estabDocReembolso", row["estabDocReembolso"].ToString());
                        docXml.WriteElementString("ptoEmiDocReembolso", row["ptoEmiDocReembolso"].ToString());
                        docXml.WriteElementString("secuencialDocReembolso", this.util.formatoNumero(row["secuencialDocReembolso"].ToString(), 9));
                        docXml.WriteElementString("fechaEmisionDocReembolso", this.util.formatoFecha(Convert.ToDateTime(row["fechaEmisionDocReembolso"])));
                        docXml.WriteElementString("numeroautorizacionDocReemb", row["numeroautorizacionDocReemb"].ToString());
                        docXml.WriteStartElement("detalleImpuestos");
                        int int16_2 = (int)Convert.ToInt16(row["porciva"]);
                        docXml.WriteStartElement("detalleImpuesto");
                        docXml.WriteElementString("codigo", "2");
                        docXml.WriteElementString("codigoPorcentaje", datosSri.codigoIva((double)int16_2, strConxIvaret));
                        double num = Convert.ToDouble(row["baseImponibleReembolso"]);
                        docXml.WriteElementString("tarifa", int16_2.ToString());
                        docXml.WriteElementString("baseImponibleReembolso", this.util.formatoDecimal(num, 14, 2));
                        docXml.WriteElementString("impuestoReembolso", this.util.formatoDecimal(this.util.calcularValorIva((double)int16_2, num), 14, 2));
                        docXml.WriteEndElement();
                        docXml.WriteStartElement("detalleImpuesto");
                        docXml.WriteElementString("codigo", "2");
                        docXml.WriteElementString("codigoPorcentaje", "0");
                        docXml.WriteElementString("tarifa", "0");
                        double numero7 = Convert.ToDouble(row["baseImponibleReembolsoCero"]);
                        docXml.WriteElementString("baseImponibleReembolso", this.util.formatoDecimal(numero7, 14, 2));
                        docXml.WriteElementString("impuestoReembolso", "0");
                        docXml.WriteEndElement();
                        docXml.WriteEndElement();
                        docXml.WriteEndElement();
                    }
                    docXml.WriteEndElement();
                }
                if (rucEmpresa == "1792323002001" && classDatEmp.NroAgenteRetencion.Length > 0)
                {
                    ChekAdicionales.registrarAdicionales(doc, docXml, false);
                }
                ////ChekAdicionales.registrarAdicionales(doc, docXml, false);
                docXml.WriteEndElement();
                docXml.Flush();
                docXml.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                this.retorno = "ERROR " + ex.Message + "FACTURA XML";
            }
            return this.retorno;
        }
    }
}
