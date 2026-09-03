using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using ClassDoc;
using DattCom;
using System.Linq;

namespace leeDocXml
{
    public static class impFac
    {
        public static void importaInfTributariaFactura(XmlNode child, AdcDoc class_AdcDoc, ref string tipoIdentificacion)
        {
            string estab = "";
            string ptoemi = "";
            string secuencial = "";

            if (child != null)
            {
                for (int i = 0; i < child.ChildNodes.Count; i++)
                {
                    try
                    {
                        string mNombre = child.ChildNodes.Item(i).Name;
                        string mValor = child.ChildNodes.Item(i).InnerText;
                        switch (mNombre)
                        {
                            case "tipoEmision":
                                class_AdcDoc.tipoEmision = Convert.ToInt32(mValor);
                                break;
                            case "razonSocial":
                                class_AdcDoc.Doc_NombreImp = mValor;
                                break;
                            case "ruc":
                                class_AdcDoc.Doc_CiRuc = mValor;
                                if (mValor.Length == 13)
                                    tipoIdentificacion = "04";
                                else if (mValor.Length == 10)
                                    tipoIdentificacion = "05";
                                else
                                    tipoIdentificacion = "06";
                                Console.WriteLine($"Emisor: ID={mValor}, Tipo={tipoIdentificacion}");
                                break;
                            case "claveAcceso":
                                class_AdcDoc.claveSri = mValor;
                                class_AdcDoc.NroAutorizacionSri = mValor;
                                class_AdcDoc.Adi_NroAutSri = mValor;
                                break;
                            case "codDoc":
                                class_AdcDoc.Adi_TipoDocSri = mValor;
                                break;
                            case "estab":
                                estab = mValor;
                                break;
                            case "ptoEmi":
                                ptoemi = mValor;
                                break;
                            case "secuencial":
                                secuencial = mValor;
                                class_AdcDoc.Doc_numero = Convert.ToDecimal(mValor);
                                break;
                            case "dirMatriz":
                                class_AdcDoc.Doc_Direccion = mValor;
                                break;
                        }
                    }
                    catch { break; }
                }
                class_AdcDoc.Doc_NroIdDoc = estab + "-" + ptoemi;
            }
        }

        public static void CalcularTotalesPorTipo(AdcDoc class_AdcDoc, DataGridView mallaReferencia)
        {
            try
            {
                decimal totArtCIva = 0;
                decimal totArtSIva = 0;
                decimal totSerCIva = 0;
                decimal totSerSIva = 0;

                foreach (DataGridViewRow row in mallaReferencia.Rows)
                {
                    if (row.IsNewRow) continue;
                    if (row.Cells["Cantidad"].Value == null || row.Cells["PvUni"].Value == null) continue;

                    decimal cantidad = Convert.ToDecimal(row.Cells["Cantidad"].Value);
                    decimal precioUnitario = Convert.ToDecimal(row.Cells["PvUni"].Value);

                    decimal subtotal = Math.Round(cantidad * precioUnitario, 2);

                    bool tieneIva = false;
                    if (row.Cells["iva"].Value != null)
                    {
                        if (row.Cells["iva"].Value is bool)
                            tieneIva = (bool)row.Cells["iva"].Value;
                        else
                            bool.TryParse(row.Cells["iva"].Value.ToString(), out tieneIva);
                    }

                    string tipoProducto = row.Cells["ConceptoProducto"]?.Value?.ToString() ?? "Producto";
                    bool esArticulo = (tipoProducto.ToUpper() == "PRODUCTO" || tipoProducto.ToUpper() == "A");

                    if (esArticulo)
                    {
                        if (tieneIva) totArtCIva += subtotal;
                        else totArtSIva += subtotal;
                    }
                    else
                    {
                        if (tieneIva) totSerCIva += subtotal;
                        else totSerSIva += subtotal;
                    }
                }

                class_AdcDoc.Doc_TotArtCIva = Math.Round(totArtCIva, 2);
                class_AdcDoc.Doc_TotArtSIva = Math.Round(totArtSIva, 2);
                class_AdcDoc.Doc_TotSerCIva = Math.Round(totSerCIva, 2);
                class_AdcDoc.Doc_TotSerSIva = Math.Round(totSerSIva, 2);

                Console.WriteLine("\n=== TOTALES POR TIPO DE PRODUCTO ===");
                Console.WriteLine($"  Artículos CON IVA: {class_AdcDoc.Doc_TotArtCIva:F2}");
                Console.WriteLine($"  Artículos SIN IVA: {class_AdcDoc.Doc_TotArtSIva:F2}");
                Console.WriteLine($"  Servicios CON IVA: {class_AdcDoc.Doc_TotSerCIva:F2}");
                Console.WriteLine($"  Servicios SIN IVA: {class_AdcDoc.Doc_TotSerSIva:F2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error en CalcularTotalesPorTipo: {ex.Message}");
            }
        }

        public static void importaInfFactura(XmlDocument xmlDocFactura, AdcDoc class_AdcDoc, DataGridView mallaReferencia)
        {
            XmlNode child = xmlDocFactura.SelectSingleNode("/factura/infoFactura");
            if (child != null)
            {
                for (int i = 0; i < child.ChildNodes.Count; i++)
                {
                    try
                    {
                        string mNombre = child.ChildNodes.Item(i).Name;
                        string mValor = child.ChildNodes.Item(i).InnerText;

                        switch (mNombre)
                        {
                            case "fechaEmision":
                                class_AdcDoc.Doc_fecha = Convert.ToDateTime(mValor);
                                break;
                            case "totalSinImpuestos":
                                class_AdcDoc.Doc_totciva = Math.Round(Convert.ToDecimal(mValor), 2);
                                Console.WriteLine($"totalSinImpuestos (XML): {mValor} -> redondeado: {class_AdcDoc.Doc_totciva}");
                                break;
                            case "importeTotal":
                                class_AdcDoc.Doc_valor = Math.Round(Convert.ToDecimal(mValor), 2);
                                Console.WriteLine($"importeTotal (XML): {mValor} -> redondeado: {class_AdcDoc.Doc_valor}");
                                break;
                            case "moneda":
                                class_AdcDoc.Moneda = mValor;
                                break;
                            case "totalConImpuestos":
                                importarImpuestosDoc(child.ChildNodes.Item(i), class_AdcDoc);
                                break;
                            case "identificacionComprador":
                                class_AdcDoc.Doc_CiRuc = mValor;
                                break;
                            case "razonSocialComprador":
                                class_AdcDoc.Doc_NombreImp = mValor.ToUpper();
                                break;
                            case "direccionComprador":
                                class_AdcDoc.Doc_Direccion = mValor;
                                break;
                            case "obligadoContabilidad":
                                class_AdcDoc.Doc_Contabilidad = (mValor.ToUpper() == "SI") ? 1 : 0;
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error en importaInfFactura: {ex.Message}");
                    }
                }

                class_AdcDoc.Doc_totciva = Math.Round(class_AdcDoc.Doc_totciva, 2);
                class_AdcDoc.Doc_valor = Math.Round(class_AdcDoc.Doc_valor, 2);
                class_AdcDoc.BaseImp1 = class_AdcDoc.Doc_totciva;
            }
        }

        private static void importarImpuestosDoc(XmlNode childPago, AdcDoc docDax)
        {
            if (childPago == null) return;

            decimal totalIva = 0;
            decimal porcIvaPrincipal = 0;

            foreach (XmlNode impuesto in childPago.ChildNodes)
            {
                if (impuesto.Name == "totalImpuesto")
                {
                    string codigo = "";
                    string codigoPorcentaje = "";
                    decimal tarifa = 0;
                    decimal valor = 0;
                    decimal baseImponible = 0;

                    foreach (XmlNode campo in impuesto.ChildNodes)
                    {
                        switch (campo.Name)
                        {
                            case "codigo":
                                codigo = campo.InnerText.Trim();
                                break;
                            case "codigoPorcentaje":
                                codigoPorcentaje = campo.InnerText.Trim();
                                break;
                            case "baseImponible":
                                decimal.TryParse(campo.InnerText.Replace(",", "."), out baseImponible);
                                break;
                            case "tarifa":
                                decimal.TryParse(campo.InnerText.Replace(",", "."), out tarifa);
                                break;
                            case "valor":
                                decimal.TryParse(campo.InnerText.Replace(",", "."), out valor);
                                totalIva += valor;
                                break;
                        }
                    }

                    if (codigo == "2")
                    {
                        if (tarifa == 0)
                            tarifa = obtenerTarifaDesdeCodigo(codigoPorcentaje);

                        if (porcIvaPrincipal == 0 && tarifa > 0)
                            porcIvaPrincipal = tarifa;
                    }
                }
            }

            docDax.Doc_valoriva = Math.Round(totalIva, 2);
            docDax.Doc_porceniva = porcIvaPrincipal;
        }

        public static string GenerarCodigoIdentificacion(string identificacion, string tipoId)
        {
            if (string.IsNullOrEmpty(identificacion))
                return "";

            string prefijo = ObtenerPrefijoSegunTipo(tipoId);
            string codigoBase = identificacion.Trim();

            if (tipoId == "04" && codigoBase.Length >= 13)
            {
                string soloNumeros = new string(codigoBase.Where(char.IsDigit).ToArray());
                if (soloNumeros.Length >= 10)
                    codigoBase = soloNumeros.Substring(0, 10);
                else
                    codigoBase = soloNumeros.PadRight(10, '0');
            }
            else if (tipoId == "05")
            {
                string soloNumeros = new string(codigoBase.Where(char.IsDigit).ToArray());
                if (soloNumeros.Length >= 10)
                    codigoBase = soloNumeros.Substring(0, 10);
                else
                    codigoBase = soloNumeros.PadRight(10, '0');
            }
            else if (tipoId == "06")
            {
                if (codigoBase.Length > 10)
                    codigoBase = codigoBase.Substring(0, 10);
                else
                    codigoBase = codigoBase.PadRight(10, ' ').Trim();
            }
            else
            {
                if (codigoBase.Length > 10)
                    codigoBase = codigoBase.Substring(0, 10);
            }

            string codigoCompleto = prefijo + codigoBase;
            if (codigoCompleto.Length > 15)
                codigoCompleto = codigoCompleto.Substring(0, 15);

            return codigoCompleto;
        }

        public static string ObtenerPrefijoSegunTipo(string tipoId)
        {
            switch (tipoId)
            {
                case "04": return "R";
                case "05": return "C";
                case "06": return "P";
                default: return "R";
            }
        }

        public static void importaDetallesFactura(XmlDocument xmlDocFactura, AdcTra class_AdcTra, AdcDoc class_AdcDoc, DataGridView mallaReferencia)
        {
            Console.WriteLine("\n=== INICIANDO IMPORTACIÓN DE DETALLES ===");

            XmlNode childDet = xmlDocFactura.SelectSingleNode("/factura/detalles");
            if (childDet != null)
            {
                Console.WriteLine($"📋 Nodos detalles encontrados: {childDet.ChildNodes.Count}");

                if (childDet.ChildNodes.Count == 0) return;

                for (int i = 0; i < childDet.ChildNodes.Count; i++)
                {
                    try
                    {
                        XmlNode child = childDet.ChildNodes[i];
                        Console.WriteLine($"\n--- Detalle {i + 1} ---");
                        Console.WriteLine($"Nodo: {child.Name}");

                        if (child.Name == "detalle")
                        {
                            class_AdcTra = new AdcTra();
                            decimal precioTotalSinImpuesto = 0;
                            decimal porcIva = 0;
                            decimal valorIva = 0;
                            bool tieneIva = false;
                            decimal subtotalSinDescuento = 0;
                            decimal valorDescuento = 0;

                            for (int j = 0; j < child.ChildNodes.Count; j++)
                            {
                                try
                                {
                                    string mNombre = child.ChildNodes.Item(j).Name;
                                    string mValor = child.ChildNodes.Item(j).InnerText;

                                    Console.WriteLine($"  Campo: {mNombre} = {mValor}");

                                    switch (mNombre)
                                    {
                                        case "codigoPrincipal":
                                            class_AdcTra.Tra_Codigo = mValor;
                                            break;

                                        case "codigoAuxiliar":
                                            int ind = mValor.ToUpper().IndexOf("LOTE");
                                            if (ind >= 0)
                                                class_AdcTra.Tra_NroLote = mValor;
                                            else
                                                class_AdcTra.tra_codigoalterno = mValor;
                                            break;

                                        case "descripcion":
                                            class_AdcTra.Tra_nombre = mValor;
                                            break;

                                        case "cantidad":
                                            class_AdcTra.Tra_cantidad = Convert.ToDecimal(mValor);
                                            class_AdcTra.Tra_numprecio = "1";
                                            break;

                                        case "precioUnitario":
                                            class_AdcTra.Tra_precuni = Convert.ToDecimal(mValor);
                                            break;

                                        case "descuento":
                                            valorDescuento = Convert.ToDecimal(mValor);
                                            class_AdcTra.Tra_valordes = Math.Round(valorDescuento, 2);
                                            break;

                                        case "precioTotalSinImpuesto":
                                            precioTotalSinImpuesto = Convert.ToDecimal(mValor);
                                            // ✅ Tra_prectot = SUBTOTAL CON DESCUENTO (redondeado a 2 decimales)
                                            class_AdcTra.Tra_prectot = Math.Round(precioTotalSinImpuesto, 2);
                                            Console.WriteLine($"  ✅ Base sin IVA (con descuento): {class_AdcTra.Tra_prectot}");
                                            break;

                                        case "impuestos":
                                            Console.WriteLine("  🔍 Procesando impuestos...");
                                            XmlNode childImp = child.ChildNodes[j];
                                            if (childImp.ChildNodes.Count > 0)
                                            {
                                                decimal baseImponible = 0;
                                                ObtenerDatosIVA(childImp, ref porcIva, ref valorIva, ref baseImponible);

                                                tieneIva = (porcIva > 0);

                                                Console.WriteLine($"  📊 Resultado IVA: tieneIva={tieneIva}, porcIva={porcIva}, valorIva={valorIva}");

                                                class_AdcTra.Tra_sniva = tieneIva;
                                                class_AdcTra.Tra_porceniva = porcIva;
                                                class_AdcTra.Tra_valoriva = valorIva;

                                                // ✅ Tra_valor = subtotal + IVA (redondeado a 2 decimales)
                                                class_AdcTra.Tra_valor = Math.Round(precioTotalSinImpuesto + valorIva, 2);

                                                Console.WriteLine($"  ✅ Total línea (redondeado): {class_AdcTra.Tra_valor}");
                                            }
                                            else
                                            {
                                                Console.WriteLine("  ⚠️ No hay nodos impuestos");
                                            }
                                            break;

                                        case "detallesAdicionales":
                                            XmlNode childAdiTra = child.ChildNodes[j];
                                            if (childAdiTra.ChildNodes.Count > 0)
                                                importardetallesAdicionalesTra(childAdiTra, class_AdcTra);
                                            break;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"  ❌ Error en campo {j}: {ex.Message}");
                                    break;
                                }
                            }

                            // ✅ CALCULAR PORCENTAJE DE DESCUENTO
                            // subtotalSinDescuento = cantidad * precioUnitario
                            subtotalSinDescuento = class_AdcTra.Tra_cantidad * class_AdcTra.Tra_precuni;
                            decimal descuentoPorcentaje = 0;
                            if (subtotalSinDescuento > 0 && valorDescuento > 0)
                            {
                                descuentoPorcentaje = Math.Round((valorDescuento / subtotalSinDescuento) * 100, 2);
                            }
                            // ✅ Tra_porcendes = PORCENTAJE DE DESCUENTO (10.00)
                            class_AdcTra.Tra_porcendes = descuentoPorcentaje;

                            Console.WriteLine($"  📊 Descuento: %={descuentoPorcentaje}%, Valor={valorDescuento}");

                            if (class_AdcTra.Tra_valor == 0)
                            {
                                Console.WriteLine($"  ⚠️ Tra_valor es 0, asignando default: {precioTotalSinImpuesto}");
                                class_AdcTra.Tra_valor = Math.Round(precioTotalSinImpuesto, 2);
                                class_AdcTra.Tra_sniva = false;
                                class_AdcTra.Tra_porceniva = 0;
                                class_AdcTra.Tra_valoriva = 0;
                            }

                            Console.WriteLine($"  📋 Valores finales:");
                            Console.WriteLine($"    Tra_sniva: {class_AdcTra.Tra_sniva}");
                            Console.WriteLine($"    Tra_porceniva: {class_AdcTra.Tra_porceniva}");
                            Console.WriteLine($"    Tra_valoriva: {class_AdcTra.Tra_valoriva}");
                            Console.WriteLine($"    Tra_valor: {class_AdcTra.Tra_valor}");
                            Console.WriteLine($"    Tra_porcendes: {class_AdcTra.Tra_porcendes}");
                            Console.WriteLine($"    Tra_valordes: {class_AdcTra.Tra_valordes}");

                            CalcularCostosParaArticulo(ref class_AdcTra, class_AdcDoc);
                            guardaDetalle(class_AdcTra, class_AdcDoc, mallaReferencia);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"❌ Error en detalle {i}: {ex.Message}");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("❌ No se encontró el nodo /factura/detalles");
            }

            Console.WriteLine("=== FIN IMPORTACIÓN DE DETALLES ===\n");
        }

        private static void ObtenerDatosIVA(XmlNode nodeImpuestos, ref decimal porcentaje, ref decimal valor, ref decimal baseImponible)
        {
            porcentaje = 0;
            valor = 0;
            baseImponible = 0;

            if (nodeImpuestos == null)
            {
                Console.WriteLine("  ❌ nodeImpuestos es NULL");
                return;
            }

            Console.WriteLine($"  🔍 Procesando nodo impuestos con {nodeImpuestos.ChildNodes.Count} hijos");

            foreach (XmlNode impuesto in nodeImpuestos.ChildNodes)
            {
                Console.WriteLine($"    📌 Nodo: {impuesto.Name}");

                if (impuesto.Name == "impuesto")
                {
                    string codigo = "";
                    string codigoPorcentaje = "";
                    decimal tarifa = 0;
                    decimal val = 0;
                    decimal baseImp = 0;

                    foreach (XmlNode campo in impuesto.ChildNodes)
                    {
                        Console.WriteLine($"      🔹 Campo: {campo.Name} = {campo.InnerText}");

                        switch (campo.Name)
                        {
                            case "codigo":
                                codigo = campo.InnerText.Trim();
                                break;
                            case "codigoPorcentaje":
                                codigoPorcentaje = campo.InnerText.Trim();
                                break;
                            case "tarifa":
                                decimal.TryParse(campo.InnerText.Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out tarifa);
                                break;
                            case "baseImponible":
                                decimal.TryParse(campo.InnerText.Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out baseImp);
                                break;
                            case "valor":
                                decimal.TryParse(campo.InnerText.Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out val);
                                break;
                        }
                    }

                    Console.WriteLine($"    📊 Código={codigo}, Tarifa={tarifa}, Valor={val}, Base={baseImp}");

                    if (codigo == "2")
                    {
                        if (tarifa == 0 && !string.IsNullOrEmpty(codigoPorcentaje))
                            tarifa = obtenerTarifaDesdeCodigo(codigoPorcentaje);

                        porcentaje = tarifa;
                        valor = val;
                        baseImponible = baseImp;

                        Console.WriteLine($"    ✅ IVA ENCONTRADO: tarifa={tarifa}%, valor={val}, base={baseImp}");
                        return;
                    }
                }
            }

            Console.WriteLine($"  ⚠️ No se encontró IVA (código 2) en este detalle");
        }

        private static decimal obtenerTarifaDesdeCodigo(string cod)
        {
            switch (cod)
            {
                case "0": return 0;
                case "2": return 12;
                case "3": return 14;
                case "4": return 15;
                case "5": return 13;
                case "6": return 8;
                case "7": return 5;
                case "8": return 10;
                case "9": return 0;
                default: return 0;
            }
        }

        private static void CalcularCostosParaArticulo(ref AdcTra adcTra, AdcDoc adcDoc)
        {
            bool esArticulo = !string.IsNullOrEmpty(adcTra.Tra_Codigo);

            if (adcTra.Tra_quetipo == "A")
                esArticulo = true;
            else if (adcTra.Tra_quetipo == "S")
                esArticulo = false;

            if (esArticulo)
            {
                adcTra.Tra_costuni = adcTra.Tra_precuni;
                adcTra.Tra_costtot = adcTra.Tra_costuni * adcTra.Tra_cantidad;
            }
            else
            {
                adcTra.Tra_costuni = 0;
                adcTra.Tra_costtot = 0;
            }
        }

        public static decimal importarImpuestosTra(XmlNode childDetalle)
        {
            if (childDetalle == null) return 0;

            foreach (XmlNode impuesto in childDetalle.ChildNodes)
            {
                string codigo = "";
                string codigoPorcentaje = "";
                decimal tarifa = 0;

                foreach (XmlNode campo in impuesto.ChildNodes)
                {
                    switch (campo.Name)
                    {
                        case "codigo":
                            codigo = campo.InnerText;
                            break;
                        case "codigoPorcentaje":
                            codigoPorcentaje = campo.InnerText;
                            break;
                        case "tarifa":
                            decimal.TryParse(campo.InnerText, out tarifa);
                            break;
                    }
                }

                if (codigo == "2")
                {
                    if (tarifa == 0 && !string.IsNullOrEmpty(codigoPorcentaje))
                    {
                        switch (codigoPorcentaje)
                        {
                            case "0": return 0;
                            case "2": return 12;
                            case "3": return 14;
                            case "4": return 15;
                            case "5": return 13;
                            case "6": return 8;
                            case "7": return 5;
                            case "8": return 10;
                            default: return 0;
                        }
                    }
                    return tarifa;
                }
            }

            return 0;
        }

        private static void guardaDetalle(AdcTra adcTra, AdcDoc adcDoc, DataGridView mallaReferencia)
        {
            Boolean esConcepto = true;
            string valConcepto = "S";
            Int32 ind = 0;

            if (string.IsNullOrEmpty(adcTra.Tra_Codigo) && string.IsNullOrEmpty(adcTra.Tra_nombre))
                return;

            if (string.IsNullOrEmpty(adcTra.Tra_Codigo))
                adcTra.Tra_Codigo = adcTra.Tra_nombre;
            if (string.IsNullOrEmpty(adcTra.Tra_nombre))
                adcTra.Tra_nombre = adcTra.Tra_Codigo;

            mallaReferencia.Rows.Add();
            ind = mallaReferencia.Rows.Count - 1;

            // ✅ CAMPOS PRINCIPALES
            mallaReferencia.Rows[ind].Cells["ProductoProveedor"].Value = adcTra.Tra_Codigo;
            mallaReferencia.Rows[ind].Cells["DetalleProveedor"].Value = adcTra.Tra_nombre;
            mallaReferencia.Rows[ind].Cells["usarDetalle"].Value = "Proveedor";
            mallaReferencia.Rows[ind].Cells["DetalleAutilizar"].Value = adcTra.Tra_nombre;

            mallaReferencia.Rows[ind].Cells["Cantidad"].Value = adcTra.Tra_cantidad;
            mallaReferencia.Rows[ind].Cells["PvUni"].Value = adcTra.Tra_precuni;

            // ✅ IVA
            mallaReferencia.Rows[ind].Cells["iva"].Value = adcTra.Tra_sniva;

            // ✅ DESCUENTO - CORRECCIÓN
            // Tra_porcendes = PORCENTAJE de descuento (10.00%)
            // Tra_valordes = VALOR del descuento (0.12)
            mallaReferencia.Rows[ind].Cells["PorcDes"].Value = adcTra.Tra_porcendes;  // ✅ AHORA ES EL PORCENTAJE

            // ✅ CAMPOS DE IVA
            if (mallaReferencia.Columns.Contains("Tra_porceniva"))
                mallaReferencia.Rows[ind].Cells["Tra_porceniva"].Value = adcTra.Tra_porceniva;

            if (mallaReferencia.Columns.Contains("Tra_valoriva"))
                mallaReferencia.Rows[ind].Cells["Tra_valoriva"].Value = adcTra.Tra_valoriva;

            // ✅ Tra_prectot = SUBTOTAL CON DESCUENTO
            if (mallaReferencia.Columns.Contains("Tra_prectot"))
                mallaReferencia.Rows[ind].Cells["Tra_prectot"].Value = adcTra.Tra_prectot;

            // ✅ Tra_valor = TOTAL (subtotal + IVA)
            if (mallaReferencia.Columns.Contains("Tra_valor"))
                mallaReferencia.Rows[ind].Cells["Tra_valor"].Value = adcTra.Tra_valor;

            // ✅ COSTOS
            if (mallaReferencia.Columns.Contains("Tra_costuni"))
                mallaReferencia.Rows[ind].Cells["Tra_costuni"].Value = adcTra.Tra_costuni;

            if (mallaReferencia.Columns.Contains("Tra_costtot"))
                mallaReferencia.Rows[ind].Cells["Tra_costtot"].Value = adcTra.Tra_costtot;

            mallaReferencia.Rows[ind].Cells["Lote"].Value = adcTra.Tra_NroLote;
            mallaReferencia.Rows[ind].Cells["Vence"].Value = adcTra.AuxVar1;
            mallaReferencia.Rows[ind].Cells["CodAlterno"].Value = adcTra.tra_codigoalterno;

            // Determinar si es Artículo o Concepto
            string strAux = articuloAdcom(adcTra.Tra_Codigo, adcDoc.Doc_CiRuc, ref esConcepto);

            if (!esConcepto)
                valConcepto = "A";

            if (!string.IsNullOrEmpty(strAux))
                mallaReferencia.Rows[ind].Cells["codProductoPropio"].Value = strAux;

            mallaReferencia.Rows[ind].Cells["ConceptoProducto"].Value = valConcepto;

            Console.WriteLine($"  Fila {ind}: {adcTra.Tra_Codigo}, IVA={adcTra.Tra_sniva}, %IVA={adcTra.Tra_porceniva}, ValorIVA={adcTra.Tra_valoriva}, Total={adcTra.Tra_valor}, Desc%={adcTra.Tra_porcendes}, DescVal={adcTra.Tra_valordes}");
        }

        private static string articuloAdcom(string prodProveedor, string codProveedor, ref Boolean esConcepto)
        {
            string ssql = "select * from daxRefProov where idProveedor ='" + codProveedor + "' and idProductoProveedor = '" + prodProveedor + "'";
            using (SqlDataAdapter da = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0) return "";
                esConcepto = (dt.Rows[0]["productoConcepto"].ToString() == "S");
                return dt.Rows[0]["codigoAdcomDax"].ToString();
            }
        }

        public static Boolean importardetallesAdicionalesTra(XmlNode childDetalle, AdcTra classAdctra)
        {
            if (childDetalle == null) return false;
            if (childDetalle.ChildNodes.Count == 0) return false;
            XmlNode child;
            if (childDetalle != null)
            {
                for (int i = 0; i < childDetalle.ChildNodes.Count; i++)
                {
                    try
                    {
                        child = childDetalle.ChildNodes.Item(i);
                        for (int j = 0; j < child.Attributes.Count; j += 2)
                        {
                            string mNombre = child.Attributes.Item(j).InnerText;
                            string mValor = child.Attributes.Item(j + 1).InnerText;

                            if (mNombre.ToUpper().IndexOf("LOTE_VENCE") >= 0)
                            {
                                try
                                {
                                    int ind = mValor.IndexOf("_");
                                    classAdctra.Tra_NroLote = mValor.Substring(0, ind);
                                    classAdctra.AuxVar1 = mValor.Substring(ind + 1);
                                }
                                catch { }
                            }
                            else if (mNombre.ToUpper().IndexOf("LOTE") >= 0)
                            {
                                classAdctra.Tra_NroLote = mValor;
                            }
                            else if (mNombre.ToUpper().IndexOf("CADUCA") >= 0 || mNombre.ToUpper().IndexOf("CADUCIDAD") >= 0 || mNombre.ToUpper().IndexOf("VENCIMIENTO") >= 0 || mNombre.ToUpper().IndexOf("VENCE") >= 0)
                            {
                                try { classAdctra.AuxVar1 = mValor; }
                                catch { }
                            }
                        }
                    }
                    catch { }
                }
            }
            return false;
        }

        public static void ImportarEmailAdicional(XmlDocument xmlDocFactura, AdcDoc class_AdcDoc)
        {
            try
            {
                XmlNodeList campos = xmlDocFactura.SelectNodes("/factura/infoAdicional/campoAdicional");
                if (campos != null)
                {
                    foreach (XmlNode campo in campos)
                    {
                        string nombre = campo.Attributes["nombre"]?.Value ?? "";
                        if (nombre.Equals("Correo", StringComparison.OrdinalIgnoreCase))
                        {
                            class_AdcDoc.AuxVar9 = campo.InnerText.Trim();
                            Console.WriteLine($"  Email importado: {class_AdcDoc.AuxVar9}");
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error importando email: {ex.Message}");
            }
        }
    }
}