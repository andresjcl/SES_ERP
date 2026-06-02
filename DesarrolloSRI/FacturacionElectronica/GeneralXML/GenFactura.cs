using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DattCom;

namespace DaxDocElectronicos
{
    public class GenFactura
    {
        string retorno = "";
        Boolean esExportacion = false;
        Char cc = Convert.ToChar("0");
        Char bb = Convert.ToChar(" ");
        Feutilidad  util = new Feutilidad ();

        public string crear_factura_xml_sri(ref DataRow doc,ref DataTable dtra, string pathfile,string clv, Int16 ambiente,Int16 tipoEmision,Int16 decimales,string NombreEmpresa, string rucEmpresa, string DireccionEmpresa,string nombreBaseDatosIvaret,string strConxAdcom )
         // generar el archivo xml por facturacion para enviar al sri
        {
            try
            {                                
                string straux = "";
                int tarifaImpuesto = 0;
                double baseImpuesto = 0;
                esExportacion = ChekAdicionales.tieneExportacion(doc);

                XmlTextWriter docXml = new XmlTextWriter(pathfile, System.Text.Encoding.UTF8);
                docXml.WriteStartDocument(true);
                docXml.Formatting = Formatting.Indented;            

                docXml.WriteStartElement("factura");
                docXml.WriteAttributeString("id", "comprobante");
                docXml.WriteAttributeString("version", "2.1.0");
                docXml.WriteStartElement("infoTributaria");
                docXml.WriteElementString("ambiente", util.formatoNumero(ambiente.ToString(), 1));
                docXml.WriteElementString("tipoEmision", util.formatoNumero(tipoEmision.ToString(), 1));
                docXml.WriteElementString("razonSocial", util.formatoString(NombreEmpresa, 300));
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
                docXml.WriteElementString("codDoc", util.tipoComprobanteSri(doc["DOC_TipoDoc"].ToString()));

                straux = util.formatoNumero(doc["Doc_NroIdDoc"].ToString(), 7);
                docXml.WriteElementString("estab", straux.Substring(0, 3));
                docXml.WriteElementString("ptoEmi", straux.Substring(4, 3));

                docXml.WriteElementString("secuencial", util.formatoNumero(doc["Doc_numero"].ToString(), 9));
                docXml.WriteElementString("dirMatriz", util.formatoString(DireccionEmpresa, 300));

                ChekAdicionales.registrarfuncionalidadEmisor(docXml);

                docXml.WriteEndElement();

                docXml.WriteStartElement("infoFactura");
                docXml.WriteElementString("fechaEmision", util.formatoFecha(Convert.ToDateTime(doc["Doc_fecha"])));
                docXml.WriteElementString("dirEstablecimiento", this.util.formatoString(doc["Doc_Direccion"].ToString(), 300));
				

				if (datosEmpresa.Emp_ContrBuyEsp.Length > 2) docXml.WriteElementString("contribuyenteEspecial", datosEmpresa.Emp_ContrBuyEsp);

				docXml.WriteElementString("obligadoContabilidad", datosEmpresa.Emp_Conta ? "SI" : "NO");

				if (this.esExportacion)
				{
					docXml.WriteElementString("comercioExterior", "EXPORTADOR");
					docXml.WriteElementString("incoTermFactura", doc["TerminosVent"].ToString());
					docXml.WriteElementString("lugarIncoTerm", doc["CiudadFOB"].ToString());
					docXml.WriteElementString("paisOrigen", doc["OrigProducto"].ToString());
					docXml.WriteElementString("puertoEmbarque", doc["embarque"].ToString());
					docXml.WriteElementString("puertoDestino", doc["PuertoDest"].ToString());
					if (doc["paisDestino"].ToString().Length > 0)
						docXml.WriteElementString("paisDestino", doc["paisDestino"].ToString());
					if (doc["paisAdquisicion"].ToString().Length > 0)
						docXml.WriteElementString("paisAdquisicion", doc["paisAdquisicion"].ToString());
				}
				docXml.WriteElementString("tipoIdentificacionComprador", this.util.tipoId(doc["TipoIdentificacion"].ToString()));
				docXml.WriteElementString("razonSocialComprador", this.util.nombreCliente(ambiente, doc["Doc_NombreImp"].ToString()));
				docXml.WriteElementString("identificacionComprador", doc["Doc_CiRuc"].ToString());
				docXml.WriteElementString("direccionComprador", doc["Doc_Direccion"].ToString());
				docXml.WriteElementString("totalSinImpuestos", this.util.formatoDecimal(Convert.ToDouble(doc["subtotal"]), 14, 2));
				if (this.esExportacion)
					docXml.WriteElementString("incoTermTotalSinImpuestos", doc["TerminosVent"].ToString());
				double numero1 = Convert.ToDouble("0" + doc["totDescUnitario"].ToString());
				if (numero1 == 0.0)
					numero1 = Convert.ToDouble("0" + doc["totalDescuento"].ToString());
				docXml.WriteElementString("totalDescuento", this.util.formatoDecimal(numero1, 14, 2));

				//int int16 = (int)Convert.ToInt16(doc["Doc_porceniva"]);
				//docXml.WriteStartElement("totalConImpuestos");
				//if (Convert.ToDouble(doc["Doc_totciva"]) > 0.0)
				//{
				//	docXml.WriteStartElement("totalImpuesto");
				//	docXml.WriteElementString("codigo", "2");
				//	docXml.WriteElementString("codigoPorcentaje", datosSri.codigoIva((double)int16, straux));
				//	docXml.WriteElementString("baseImponible", this.util.formatoDecimal(doc["Doc_totciva"].ToString(), 14, 2));
				//	docXml.WriteElementString("tarifa", int16.ToString());
				//	docXml.WriteElementString("valor", this.util.formatoDecimal(doc["Doc_valoriva"].ToString(), 14, 2));
				//	docXml.WriteEndElement();
				//}
				//Convert.ToDouble(doc["Doc_totsiva"]);
				//if (Convert.ToDouble(doc["Doc_totsiva"]) > 0.0)
				//{
				//	docXml.WriteStartElement("totalImpuesto");
				//	docXml.WriteElementString("codigo", "2");
				//	docXml.WriteElementString("codigoPorcentaje", "0");
				//	docXml.WriteElementString("baseImponible", this.util.formatoDecimal(doc["Doc_totsiva"].ToString(), 14, 2));
				//	docXml.WriteElementString("tarifa", "0");
				//	docXml.WriteElementString("valor", "0");
				//	docXml.WriteEndElement();
				//}

				/////////=====================
				///

				// ============================================================
				// REEMPLAZAR todo el bloque de "totalConImpuestos" (líneas ~95-120)
				// con este nuevo código:
				// ============================================================

				docXml.WriteStartElement("totalConImpuestos");

				// Diccionario para agrupar impuestos por porcentaje
				Dictionary<int, double> basePorPorcentaje = new Dictionary<int, double>();
				Dictionary<int, double> valorPorPorcentaje = new Dictionary<int, double>();
				Dictionary<int, string> codigoSriPorPorcentaje = new Dictionary<int, string>();

				// Recorrer TODOS los detalles para sumar por porcentaje
				foreach (DataRow detalle in dtra.Rows)
				{
					bool tieneIva = Convert.ToBoolean(detalle["Tra_sniva"]);
					if (tieneIva)
					{
						// Tomar el porcentaje DEL DETALLE, no del encabezado
						int porcentaje = Convert.ToInt32(detalle["Tra_porceniva"]);
						double baseImponible = Convert.ToDouble(detalle["Tra_prectot"]);
						double valorIva = Convert.ToDouble(detalle["Tra_valoriva"]);

						if (!basePorPorcentaje.ContainsKey(porcentaje))
						{
							basePorPorcentaje[porcentaje] = 0;
							valorPorPorcentaje[porcentaje] = 0;
							// Obtener código SRI para este porcentaje
							codigoSriPorPorcentaje[porcentaje] = datosSri.codigoIva(porcentaje, "");
						}

						basePorPorcentaje[porcentaje] += baseImponible;
						valorPorPorcentaje[porcentaje] += valorIva;
					}
				}

				// Escribir un grupo de impuesto por cada porcentaje encontrado
				foreach (int porcentaje in basePorPorcentaje.Keys)
				{
					docXml.WriteStartElement("totalImpuesto");
					docXml.WriteElementString("codigo", "2");
					docXml.WriteElementString("codigoPorcentaje", codigoSriPorPorcentaje[porcentaje]);
					docXml.WriteElementString("baseImponible", this.util.formatoDecimal(basePorPorcentaje[porcentaje], 14, 2));
					docXml.WriteElementString("tarifa", porcentaje.ToString());
					docXml.WriteElementString("valor", this.util.formatoDecimal(valorPorPorcentaje[porcentaje], 14, 2));
					docXml.WriteEndElement();
				}

				// Manejar productos SIN IVA (porcentaje 0)
				double totalSinIva = 0;
				foreach (DataRow detalle in dtra.Rows)
				{
					bool tieneIva = Convert.ToBoolean(detalle["Tra_sniva"]);
					if (!tieneIva)
					{
						totalSinIva += Convert.ToDouble(detalle["Tra_prectot"]);
					}
				}

				if (totalSinIva > 0)
				{
					docXml.WriteStartElement("totalImpuesto");
					docXml.WriteElementString("codigo", "2");
					docXml.WriteElementString("codigoPorcentaje", "0");
					docXml.WriteElementString("baseImponible", this.util.formatoDecimal(totalSinIva, 14, 2));
					docXml.WriteElementString("tarifa", "0");
					docXml.WriteElementString("valor", "0");
					docXml.WriteEndElement();
				}

				docXml.WriteEndElement(); // Cierra totalConImpuestos


				////////=========================
				
				docXml.WriteElementString("propina", "0");
				double num1 = Convert.ToDouble(doc["Doc_valor"].ToString());
				if (this.esExportacion)
				{
					if (doc["flete"].ToString().Length > 0)
					{
						docXml.WriteElementString("fleteInternacional", doc["flete"].ToString());
						try
						{
							num1 += Convert.ToDouble(doc["flete"].ToString());
						}
						catch
						{
						}
					}
					if (doc["seguroInternacional"].ToString().Length > 0)
					{
						docXml.WriteElementString("seguroInternacional", doc["seguroInternacional"].ToString());
						try
						{
							num1 += Convert.ToDouble(doc["seguroInternacional"].ToString());
						}
						catch
						{
						}
					}
					if (doc["gastosAduana"].ToString().Length > 0)
					{
						docXml.WriteElementString("gastosAduaneros", doc["gastosAduana"].ToString());
						try
						{
							num1 += Convert.ToDouble(doc["gastosAduana"].ToString());
						}
						catch
						{
						}
					}
					if (doc["gastosTransporte"].ToString().Length > 0)
					{
						docXml.WriteElementString("gastosTransporteOtros", doc["gastosTransporte"].ToString());
						try
						{
							num1 += Convert.ToDouble(doc["gastosTransporte"].ToString());
						}
						catch
						{
						}
					}
				}
				docXml.WriteElementString("importeTotal", this.util.formatoDecimal(num1.ToString(), 14, 2));
				docXml.WriteElementString("moneda", "DOLAR");
				daxDatos daxDatos = new daxDatos();
				DataTable dataTable = daxDatos.leerDatos("DAX_LEEPAGO '" + nombreBaseDatosIvaret + "','" + doc["doc_sucursal"].ToString() + "','" + doc["opc_documento"].ToString() + "'," + doc["idclavedoc"].ToString(), strConxAdcom);
				if (dataTable.Rows.Count == 0)
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
					foreach (DataRow row in (InternalDataCollectionBase)dataTable.Rows)
					{
						string numero2;
						try
						{
							numero2 = row["SriFormaDePago"].ToString().Trim();
							if (numero2.Length == 0)
								numero2 = "01";
						}
						catch
						{
							numero2 = "01";
						}
						docXml.WriteStartElement("pago");
						docXml.WriteElementString("formaPago", this.util.formatoNumero(numero2, 2));
						docXml.WriteElementString("total", this.util.formatoDecimal(Convert.ToDouble(row["Pag_Valor"].ToString()), 14, 2));
						docXml.WriteElementString("plazo", row["diasPlazo"].ToString());
						docXml.WriteElementString("unidadTiempo", "dias");
						docXml.WriteEndElement();
					}
					docXml.WriteEndElement();
				}
				docXml.WriteEndElement();

				//-------------------------------------

				docXml.WriteStartElement("detalles");
				for (int index = 0; index < dtra.Rows.Count; ++index)
				{
					DataRow row = dtra.Rows[index];
					string str = row["Tra_codigo"].ToString();
					if (str != "." && str.Length > 0)
					{
						docXml.WriteStartElement("detalle");
						docXml.WriteElementString("codigoPrincipal", this.util.formatoString(str, 25));
						string auxiliar = this.util.formatoString(row["Tra_NroLote"].ToString(), 300);
						if (rucEmpresa == "1714257993001")
						{
							if (auxiliar.Length > 0)
							{
								docXml.WriteElementString("codigoAuxiliar", util.formatoString(row["Tra_NroLote"].ToString(), 300));
							}
							else
							{
								docXml.WriteElementString("codigoAuxiliar", "SN");
							}
						}
						string strConxIvaret2 = this.util.formatoString(row["codigoAuxiliar"].ToString(), 25);

						docXml.WriteElementString("descripcion", this.util.formatoString(row["Tra_nombre"].ToString(), 300));
						docXml.WriteElementString("cantidad", this.util.formatoDecimal(Convert.ToDouble(row["Tra_cantidad"]), 18, (int)decimales));
						docXml.WriteElementString("precioUnitario", this.util.formatoDecimal(Convert.ToDouble(row["Tra_precuni"]), 18, (int)decimales));
						docXml.WriteElementString("descuento", this.util.formatoDecimal(Convert.ToDouble(row["desctoUni"]), 14, 2));
						docXml.WriteElementString("precioTotalSinImpuesto", this.util.formatoDecimal(Convert.ToDouble(row["Tra_prectot"]), 14, 2));

						bool boolean = Convert.ToBoolean(row["Tra_sniva"]);
						docXml.WriteStartElement("impuestos");

						if (boolean)
						{
							// ================================================
							// CORREGIDO: Usar los valores del DETALLE, no del encabezado
							// ================================================
							int porcentajeDetalle = Convert.ToInt32(row["Tra_porceniva"]);
							double valorIvaDetalle = Convert.ToDouble(row["Tra_valoriva"]);
							double baseImponibleDetalle = Convert.ToDouble(row["Tra_prectot"]);

							docXml.WriteStartElement("impuesto");
							docXml.WriteElementString("codigo", "2");
							docXml.WriteElementString("codigoPorcentaje", datosSri.codigoIva(porcentajeDetalle, strConxIvaret2));
							docXml.WriteElementString("tarifa", porcentajeDetalle.ToString());
							docXml.WriteElementString("baseImponible", this.util.formatoDecimal(baseImponibleDetalle, 14, 2));
							docXml.WriteElementString("valor", this.util.formatoDecimal(valorIvaDetalle, 14, 2));
							docXml.WriteEndElement();
						}
						else
						{
							// Producto SIN IVA
							docXml.WriteStartElement("impuesto");
							docXml.WriteElementString("codigo", "2");
							docXml.WriteElementString("codigoPorcentaje", "0");
							docXml.WriteElementString("tarifa", "0");
							double numero3 = Convert.ToDouble(row["Tra_prectot"]);
							docXml.WriteElementString("baseImponible", this.util.formatoDecimal(numero3, 14, 2));
							docXml.WriteElementString("valor", "0");
							docXml.WriteEndElement();
						}

						docXml.WriteEndElement(); // cierra impuestos
						docXml.WriteEndElement(); // cierra detalle
					}
				}
				docXml.WriteEndElement(); // cierra detalles


				//------------




				if (rucEmpresa == "1792323002001" && classDatEmp.NroAgenteRetencion.Length > 0)
				{
					ChekAdicionales.registrarAdicionales(doc, docXml, esExportacion);
				}

				////////ChekAdicionales.registrarAdicionales(doc, docXml, esExportacion);
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


