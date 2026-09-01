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

                                // ✅ DETERMINAR TIPO DE IDENTIFICACIÓN DEL EMISOR
                                if (mValor.Length == 13)
                                    tipoIdentificacion = "04";  // RUC
                                else if (mValor.Length == 10)
                                    tipoIdentificacion = "05";  // Cédula
                                else
                                    tipoIdentificacion = "06";  // Pasaporte

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

        /// <summary>
        /// Calcula los totales por tipo de producto (Artículo/Concepto) después de importar detalles
        /// </summary>
        public static void CalcularTotalesPorTipo(AdcDoc class_AdcDoc, DataGridView mallaReferencia)
        {
            try
            {
                decimal totArtCIva = 0;    // Artículos CON IVA
                decimal totArtSIva = 0;    // Artículos SIN IVA
                decimal totSerCIva = 0;    // Servicios/Conceptos CON IVA
                decimal totSerSIva = 0;    // Servicios/Conceptos SIN IVA

                foreach (DataGridViewRow row in mallaReferencia.Rows)
                {
                    if (row.IsNewRow) continue;

                    // Obtener valores de la fila
                    object cantidadObj = row.Cells["Cantidad"].Value;
                    object precioObj = row.Cells["PvUni"].Value;
                    object ivaObj = row.Cells["iva"].Value;
                    object conceptoObj = row.Cells["ConceptoProducto"].Value;

                    if (cantidadObj == null || precioObj == null) continue;

                    decimal cantidad = Convert.ToDecimal(cantidadObj);
                    decimal precioUnitario = Convert.ToDecimal(precioObj);
                    bool tieneIva = false;
                    string tipoProducto = "Producto";

                    // Determinar si tiene IVA
                    if (ivaObj != null)
                    {
                        if (ivaObj is bool)
                            tieneIva = (bool)ivaObj;
                        else if (ivaObj is string)
                            tieneIva = (ivaObj.ToString().ToUpper() == "TRUE" || ivaObj.ToString() == "1" || ivaObj.ToString().ToUpper() == "S");
                        else
                            bool.TryParse(ivaObj.ToString(), out tieneIva);
                    }

                    // Determinar tipo de producto
                    if (conceptoObj != null)
                    {
                        tipoProducto = conceptoObj.ToString();
                    }

                    // Determinar si es Artículo o Servicio/Concepto
                    bool esArticulo = (tipoProducto.ToUpper() == "PRODUCTO" || tipoProducto.ToUpper() == "A");

                    decimal subtotal = cantidad * precioUnitario;

                    if (esArticulo)
                    {
                        // ES ARTÍCULO
                        if (tieneIva)
                            totArtCIva += subtotal;
                        else
                            totArtSIva += subtotal;
                    }
                    else
                    {
                        // ES SERVICIO o CONCEPTO
                        if (tieneIva)
                            totSerCIva += subtotal;
                        else
                            totSerSIva += subtotal;
                    }
                }

                // ✅ ASIGNAR VALORES A LA CLASE AdcDoc
                class_AdcDoc.Doc_TotArtCIva = totArtCIva;
                class_AdcDoc.Doc_TotArtSIva = totArtSIva;
                class_AdcDoc.Doc_TotSerCIva = totSerCIva;
                class_AdcDoc.Doc_TotSerSIva = totSerSIva;

                // DEBUG: Mostrar en consola
                Console.WriteLine("\n=== TOTALES POR TIPO DE PRODUCTO ===");
                Console.WriteLine($"  Artículos CON IVA: {totArtCIva:F2}");
                Console.WriteLine($"  Artículos SIN IVA: {totArtSIva:F2}");
                Console.WriteLine($"  Servicios CON IVA: {totSerCIva:F2}");
                Console.WriteLine($"  Servicios SIN IVA: {totSerSIva:F2}");

                // Verificar consistencia con Doc_totciva y Doc_totsiva
                decimal totalBases = class_AdcDoc.Doc_totciva + class_AdcDoc.Doc_totsiva;
                decimal totalCalculado = totArtCIva + totArtSIva + totSerCIva + totSerSIva;

                if (Math.Abs(totalBases - totalCalculado) > 0.01m)
                {
                    Console.WriteLine($"⚠️ ADVERTENCIA: Total bases ({totalBases:F2}) vs Total por tipo ({totalCalculado:F2})");
                    Console.WriteLine($"   Diferencia: {Math.Abs(totalBases - totalCalculado):F2}");
                }
                else
                {
                    Console.WriteLine($"✅ Totales consistentes: {totalBases:F2} = {totalCalculado:F2}");
                }
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
                                // ✅ Total sin impuestos (base imponible total)
                                class_AdcDoc.Doc_totciva = Convert.ToDecimal(mValor);
                                Console.WriteLine($"totalSinImpuestos (XML): {mValor}");
                                break;
                            case "importeTotal":
                                // ✅ Importe total (con impuestos)
                                class_AdcDoc.Doc_valor = Convert.ToDecimal(mValor);
                                Console.WriteLine($"importeTotal (XML): {mValor}");
                                break;
                            case "moneda":
                                class_AdcDoc.Moneda = mValor;
                                break;
                            case "totalConImpuestos":
                                // ✅ Procesar impuestos
                                importarImpuestosDoc(child.ChildNodes.Item(i), class_AdcDoc);
                                break;
                            case "identificacionComprador":
                                class_AdcDoc.Doc_CiRuc = mValor;
                                Console.WriteLine($"Comprador: Identificacion={mValor}");
                                break;
                            case "razonSocialComprador":
                                // ✅ Nombre en MAYÚSCULAS
                                class_AdcDoc.Doc_NombreImp = mValor.ToUpper();
                                Console.WriteLine($"Comprador: Nombre={class_AdcDoc.Doc_NombreImp}");
                                break;
                            case "direccionComprador":
                                class_AdcDoc.Doc_Direccion = mValor;
                                Console.WriteLine($"Comprador: Direccion={mValor}");
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
            }
        }

        //private static void importarImpuestosDoc(XmlNode childPago, AdcDoc docDax)
        //{
        //    if (childPago == null)
        //    {
        //        Console.WriteLine("  No hay nodo totalConImpuestos");
        //        return;
        //    }

        //    decimal totalConIva = 0;
        //    decimal totalSinIva = 0;
        //    decimal totalIva = 0;
        //    decimal porcIvaPrincipal = 0;
        //    decimal baseImponibleTotal = 0;

        //    Console.WriteLine($"  Procesando {childPago.ChildNodes.Count} impuestos...");

        //    foreach (XmlNode impuesto in childPago.ChildNodes)
        //    {
        //        if (impuesto.Name == "totalImpuesto")
        //        {
        //            string codigo = "";
        //            string codigoPorcentaje = "";
        //            decimal tarifa = 0;
        //            decimal valor = 0;
        //            decimal baseImponible = 0;

        //            foreach (XmlNode campo in impuesto.ChildNodes)
        //            {
        //                switch (campo.Name)
        //                {
        //                    case "codigo":
        //                        codigo = campo.InnerText.Trim();
        //                        Console.WriteLine($"    Código: {codigo}");
        //                        break;
        //                    case "codigoPorcentaje":
        //                        codigoPorcentaje = campo.InnerText.Trim();
        //                        Console.WriteLine($"    Código Porcentaje: {codigoPorcentaje}");
        //                        break;
        //                    case "baseImponible":
        //                        decimal.TryParse(campo.InnerText.Replace(",", "."), out baseImponible);
        //                        baseImponibleTotal += baseImponible;
        //                        Console.WriteLine($"    Base Imponible: {baseImponible}");
        //                        break;
        //                    case "tarifa":
        //                        decimal.TryParse(campo.InnerText.Replace(",", "."), out tarifa);
        //                        Console.WriteLine($"    Tarifa: {tarifa}");
        //                        break;
        //                    case "valor":
        //                        decimal.TryParse(campo.InnerText.Replace(",", "."), out valor);
        //                        totalIva += valor;
        //                        Console.WriteLine($"    Valor: {valor}");
        //                        break;
        //                }
        //            }

        //            // SOLO IVA (código 2)
        //            if (codigo == "2")
        //            {
        //                // Si tarifa viene como 0, obtenerla del códigoPorcentaje
        //                if (tarifa == 0)
        //                {
        //                    tarifa = obtenerTarifaDesdeCodigo(codigoPorcentaje);
        //                    Console.WriteLine($"    Tarifa desde código {codigoPorcentaje}: {tarifa}%");
        //                }

        //                // Si tiene tarifa > 0, es CON IVA
        //                if (tarifa > 0)
        //                {
        //                    totalConIva += baseImponible;

        //                    if (porcIvaPrincipal == 0 && tarifa > 0)
        //                    {
        //                        porcIvaPrincipal = tarifa;
        //                    }
        //                    Console.WriteLine($"    Base CON IVA ({tarifa}%): +{baseImponible}");
        //                }
        //                else
        //                {
        //                    // Tarifa = 0, es SIN IVA
        //                    totalSinIva += baseImponible;
        //                    Console.WriteLine($"    Base SIN IVA: +{baseImponible}");
        //                }
        //            }
        //        }
        //    }

        //    // ✅ ASIGNAR VALORES CORRECTAMENTE
        //    docDax.Doc_totciva = totalConIva;        // Base CON IVA (25.62)
        //    docDax.Doc_totsiva = totalSinIva;        // Base SIN IVA (0)
        //    docDax.Doc_valoriva = totalIva;          // Total IVA (3.84)
        //    docDax.Doc_porceniva = porcIvaPrincipal; // Porcentaje IVA (15)
        //    docDax.BaseImp1 = totalConIva;           // ✅ BaseImp1 = base CON IVA (25.62)

        //    Console.WriteLine($"  ✅ Resultados: ConIVA={totalConIva}, SinIVA={totalSinIva}, IVA={totalIva}, %IVA={porcIvaPrincipal}, BaseImp1={totalConIva}");
        //}

        private static void importarImpuestosDoc(XmlNode childPago, AdcDoc docDax)
        {
            if (childPago == null)
            {
                Console.WriteLine("  No hay nodo totalConImpuestos");
                return;
            }

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
                                // ✅ USAR EL VALOR EXACTO DEL XML (3.84)
                                decimal.TryParse(campo.InnerText.Replace(",", "."), out valor);
                                totalIva += valor;
                                break;
                        }
                    }

                    if (codigo == "2")
                    {
                        if (tarifa == 0)
                        {
                            tarifa = obtenerTarifaDesdeCodigo(codigoPorcentaje);
                        }

                        if (porcIvaPrincipal == 0 && tarifa > 0)
                        {
                            porcIvaPrincipal = tarifa;
                        }
                    }
                }
            }

            // ✅ ASIGNAR VALORES DEL XML (NO RECALCULAR)
            docDax.Doc_valoriva = totalIva;        // 3.84
            docDax.Doc_porceniva = porcIvaPrincipal; // 15
        }
        public static string GenerarCodigoIdentificacion(string identificacion, string tipoId)
        {
            if (string.IsNullOrEmpty(identificacion))
                return "";

            string prefijo = ObtenerPrefijoSegunTipo(tipoId);
            string codigoBase = identificacion.Trim();

            // ✅ LIMPIAR CARACTERES NO NUMÉRICOS (para RUC y Cédula)
            // Pero para Pasaporte puede tener letras, así que no limpiamos todo

            // ✅ SI ES RUC (13 dígitos), tomar primeros 10 dígitos
            if (tipoId == "04" && codigoBase.Length >= 13)
            {
                // Solo tomar números para RUC
                string soloNumeros = new string(codigoBase.Where(char.IsDigit).ToArray());
                if (soloNumeros.Length >= 10)
                    codigoBase = soloNumeros.Substring(0, 10);
                else
                    codigoBase = soloNumeros.PadRight(10, '0');
            }
            // ✅ SI ES CÉDULA (10 dígitos), usar todos
            else if (tipoId == "05")
            {
                // Solo tomar números para Cédula
                string soloNumeros = new string(codigoBase.Where(char.IsDigit).ToArray());
                if (soloNumeros.Length >= 10)
                    codigoBase = soloNumeros.Substring(0, 10);
                else
                    codigoBase = soloNumeros.PadRight(10, '0');
            }
            // ✅ SI ES PASAPORTE, tomar máximo 10 caracteres
            else if (tipoId == "06")
            {
                if (codigoBase.Length > 10)
                    codigoBase = codigoBase.Substring(0, 10);
                else
                    codigoBase = codigoBase.PadRight(10, ' ').Trim();
            }
            else
            {
                // Por defecto, tomar primeros 10 caracteres
                if (codigoBase.Length > 10)
                    codigoBase = codigoBase.Substring(0, 10);
            }

            // ✅ EL CÓDIGO COMPLETO: PREFIJO + BASE (máximo 11 caracteres)
            string codigoCompleto = prefijo + codigoBase;

            // ✅ ASEGURAR QUE NO SUPERE 15 CARACTERES (varchar(15))
            if (codigoCompleto.Length > 15)
                codigoCompleto = codigoCompleto.Substring(0, 15);

            return codigoCompleto;
        }

        /// <summary>
        /// Obtiene el prefijo según el tipo de identificación
        /// </summary>
        public static string ObtenerPrefijoSegunTipo(string tipoId)
        {
            switch (tipoId)
            {
                case "04": return "R";  // RUC
                case "05": return "C";  // Cédula
                case "06": return "P";  // Pasaporte
                default: return "R";    // Por defecto RUC
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
                                            {
                                                class_AdcTra.Tra_NroLote = mValor;
                                            }
                                            else
                                            {
                                                class_AdcTra.tra_codigoalterno = mValor;
                                            }
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
                                            class_AdcTra.Tra_valordes = Convert.ToDecimal(mValor);
                                            break;

                                        case "precioTotalSinImpuesto":
                                            precioTotalSinImpuesto = Convert.ToDecimal(mValor);
                                            class_AdcTra.Tra_prectot = precioTotalSinImpuesto;
                                            Console.WriteLine($"  ✅ Base sin IVA: {precioTotalSinImpuesto}");
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
                                                class_AdcTra.Tra_valor = precioTotalSinImpuesto + valorIva;

                                                Console.WriteLine($"  ✅ Total línea: {class_AdcTra.Tra_valor}");
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

                            if (class_AdcTra.Tra_valor == 0)
                            {
                                Console.WriteLine($"  ⚠️ Tra_valor es 0, asignando default: {precioTotalSinImpuesto}");
                                class_AdcTra.Tra_valor = precioTotalSinImpuesto;
                                class_AdcTra.Tra_sniva = false;
                                class_AdcTra.Tra_porceniva = 0;
                                class_AdcTra.Tra_valoriva = 0;
                            }

                            Console.WriteLine($"  📋 Valores finales:");
                            Console.WriteLine($"    Tra_sniva: {class_AdcTra.Tra_sniva}");
                            Console.WriteLine($"    Tra_porceniva: {class_AdcTra.Tra_porceniva}");
                            Console.WriteLine($"    Tra_valoriva: {class_AdcTra.Tra_valoriva}");
                            Console.WriteLine($"    Tra_valor: {class_AdcTra.Tra_valor}");

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
                        {
                            tarifa = obtenerTarifaDesdeCodigo(codigoPorcentaje);
                        }

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
                case "0": return 0;    // 0%
                case "2": return 12;   // 12%
                case "3": return 14;   // 14%
                case "4": return 15;   // 15%
                case "5": return 13;   // 13%
                case "6": return 8;    // 8%
                case "7": return 5;    // 5%
                case "8": return 10;   // 10%
                case "9": return 0;    // 0% - Exento
                default: return 0;
            }
        }

        private static void CalcularCostosParaArticulo(ref AdcTra adcTra, AdcDoc adcDoc)
        {
            // Determinar si es artículo o servicio (podrías tener otra lógica aquí)
            // Por ahora asumimos que si tiene código, es artículo
            bool esArticulo = !string.IsNullOrEmpty(adcTra.Tra_Codigo);

            if (esArticulo)
            {
                // Si es artículo, necesitas determinar el costo
                // Opciones:
                // 1. Buscar en tabla de artículos por código
                // 2. Usar el precio unitario como costo (compras)
                // 3. Calcular costo basado en alguna fórmula

                // Por ahora, usar precio unitario como costo (para compras)
                adcTra.Tra_costuni = adcTra.Tra_precuni;
                adcTra.Tra_costtot = adcTra.Tra_costuni * adcTra.Tra_cantidad;
            }
            else
            {
                // Para servicios, generalmente no hay costo de inventario
                adcTra.Tra_costuni = 0;
                adcTra.Tra_costtot = 0;
            }
        }

        // Método importarImpuestosTra actualizado para devolver porcentaje
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

                // IVA (código 2)
                if (codigo == "2")
                {
                    // Si no viene tarifa explícita, calcularla del códigoPorcentaje
                    if (tarifa == 0 && !string.IsNullOrEmpty(codigoPorcentaje))
                    {
                        switch (codigoPorcentaje)
                        {
                            case "0": return 0;    // 0%
                            case "2": return 12;   // 12%
                            case "3": return 14;   // 14%
                            case "4": return 15;   // 15%
                            case "5": return 13;   // 13%
                            case "6": return 8;    // 8%
                            case "7": return 5;    // 5%
                            case "8": return 10;   // 10%
                            default: return 0;
                        }
                    }
                    return tarifa; // Devuelve el porcentaje: 15, 5, etc.
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

            // ✅ IVA - ASIGNAR CORRECTAMENTE
            mallaReferencia.Rows[ind].Cells["iva"].Value = adcTra.Tra_sniva;
            mallaReferencia.Rows[ind].Cells["PorcDes"].Value = adcTra.Tra_valordes;

            // ✅ CAMPOS DE IVA (porcentaje y valor)
            if (mallaReferencia.Columns.Contains("Tra_porceniva"))
            {
                mallaReferencia.Rows[ind].Cells["Tra_porceniva"].Value = adcTra.Tra_porceniva;
            }

            if (mallaReferencia.Columns.Contains("Tra_valoriva"))
            {
                mallaReferencia.Rows[ind].Cells["Tra_valoriva"].Value = adcTra.Tra_valoriva;
            }

            // ✅ CAMPO VALOR TOTAL (base + IVA)
            if (mallaReferencia.Columns.Contains("Tra_valor"))
            {
                mallaReferencia.Rows[ind].Cells["Tra_valor"].Value = adcTra.Tra_valor;
            }

            // CAMPOS DE COSTO
            if (mallaReferencia.Columns.Contains("Tra_costuni"))
            {
                mallaReferencia.Rows[ind].Cells["Tra_costuni"].Value = adcTra.Tra_costuni;
            }

            if (mallaReferencia.Columns.Contains("Tra_costtot"))
            {
                mallaReferencia.Rows[ind].Cells["Tra_costtot"].Value = adcTra.Tra_costtot;
            }

            mallaReferencia.Rows[ind].Cells["Lote"].Value = adcTra.Tra_NroLote;
            mallaReferencia.Rows[ind].Cells["Vence"].Value = adcTra.AuxVar1;
            mallaReferencia.Rows[ind].Cells["CodAlterno"].Value = adcTra.tra_codigoalterno;

            // Determinar si es Artículo o Concepto
            string strAux = articuloAdcom(adcTra.Tra_Codigo, adcDoc.Doc_CiRuc, ref esConcepto);

            if (!esConcepto)
                valConcepto = "A";

            if (!string.IsNullOrEmpty(strAux))
            {
                mallaReferencia.Rows[ind].Cells["codProductoPropio"].Value = strAux;
            }

            mallaReferencia.Rows[ind].Cells["ConceptoProducto"].Value = valConcepto;

            // ✅ DEBUG
            Console.WriteLine($"  Fila {ind}: {adcTra.Tra_Codigo}, IVA={adcTra.Tra_sniva}, %IVA={adcTra.Tra_porceniva}, ValorIVA={adcTra.Tra_valoriva}, Total={adcTra.Tra_valor}");
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
                //      'Obtenemos el Elemento nombre y valor               
                for (int i = 0; i < childDetalle.ChildNodes.Count; i++)
                {
                    try
                    {
                        child = childDetalle.ChildNodes.Item(i);
                        for (int j = 0; j < child.Attributes.Count; j += 2)
                        {
                            string mNombre = child.Attributes.Item(j).InnerText;
                            string mValor = child.Attributes.Item(j + 1).InnerText;

                            if (mNombre.ToUpper().IndexOf("LOTE_VENCE") >= 0 )
                            {
                                try
                                {
                                    int ind = mValor.IndexOf("_");
                                    classAdctra.Tra_NroLote = mValor.Substring(0,ind);
                                    classAdctra.AuxVar1 = mValor.Substring(ind + 1);
                                    //detAdicionalLote_Vence" valor="170352_31/03/2020                                    
                                }
                                catch
                                {
                                }
                            }                            
                            else if (mNombre.ToUpper().IndexOf("LOTE") >= 0) { classAdctra.Tra_NroLote = mValor; }
                            else if (mNombre.ToUpper().IndexOf("CADUCA") >= 0 || mNombre.ToUpper().IndexOf("CADUCIDAD") >= 0 || mNombre.ToUpper().IndexOf("VENCIMIENTO") >= 0 || mNombre.ToUpper().IndexOf("VENCE") >= 0)
                            {
                                try
                                {
                                    classAdctra.AuxVar1 = mValor;
                                }
                                catch
                                {
                                }
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

