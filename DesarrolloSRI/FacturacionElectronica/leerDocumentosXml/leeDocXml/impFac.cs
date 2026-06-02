using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using ClassDoc;
using DattCom;
namespace leeDocXml
{
    public static class impFac
    {

        public static void importaInfTributariaFactura(XmlNode child, AdcDoc class_AdcDoc, ref string tipoIdentificacion)
        {
            string estab = "";
            string ptoemi = "";
            //XmlNode child = xmlDocFactura.SelectSingleNode("/factura/infoTributaria");
            if (child != null)
            {
                //      'Obtenemos el Elemento nombre y valor               
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
                                break;
                            case "claveAcceso":
                                class_AdcDoc.claveSri = mValor;
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
                                class_AdcDoc.Doc_numero = Convert.ToDecimal(mValor);
                                break;
                            case "dirMatriz":
                                class_AdcDoc.Doc_Direccion = mValor;
                                break;
                            case "tipoIdentificacionComprador":
                                tipoIdentificacion = mValor;
                                break;
                        }
                    }
                    catch { break; }
                }
                class_AdcDoc.Doc_NroIdDoc = estab + "-" + ptoemi;
            }
        }

        //public static void importaInfFactura(XmlDocument xmlDocFactura, AdcDoc class_AdcDoc, DataGridView mallaReferencia)
        //{
        //    XmlNode child = xmlDocFactura.SelectSingleNode("/factura/infoFactura");
        //    if (child != null)
        //    {
        //        for (int i = 0; i < child.ChildNodes.Count; i++)
        //        {
        //            try
        //            {
        //                string mNombre = child.ChildNodes.Item(i).Name;
        //                string mValor = child.ChildNodes.Item(i).InnerText;
        //                switch (mNombre)
        //                {
        //                    case "fechaEmision":
        //                        class_AdcDoc.Doc_fecha = Convert.ToDateTime(mValor);
        //                        break;
        //                    case "totalDescuento":
        //                        class_AdcDoc.doc_TotDesCIva = Convert.ToDecimal(mValor);
        //                        break;
        //                    case "importeTotal":
        //                        // 1. Asignar importe total
        //                        class_AdcDoc.Doc_valor = Convert.ToDecimal(mValor); // 24.85

        //                        // 2. Buscar totalConImpuestos para calcular Doc_totciva y Doc_totsiva
        //                        XmlNode totalConImpuestosNode = child.SelectSingleNode("totalConImpuestos");
        //                        if (totalConImpuestosNode != null)
        //                        {
        //                            foreach (XmlNode impuesto in totalConImpuestosNode.ChildNodes)
        //                            {
        //                                if (impuesto.Name == "totalImpuesto")
        //                                {
        //                                    string codigo = impuesto.SelectSingleNode("codigo")?.InnerText ?? "";
        //                                    string codigoPorcentaje = impuesto.SelectSingleNode("codigoPorcentaje")?.InnerText ?? "";
        //                                    string tarifaStr = impuesto.SelectSingleNode("tarifa")?.InnerText ?? "0";
        //                                    string baseStr = impuesto.SelectSingleNode("baseImponible")?.InnerText ?? "0";

        //                                    decimal tarifa = 0;
        //                                    decimal baseImponible = 0;
        //                                    decimal.TryParse(tarifaStr, out tarifa);
        //                                    decimal.TryParse(baseStr, out baseImponible);

        //                                    // EVALUAR PRIMERO EL CÓDIGO PORCENTAJE
        //                                    if (tarifa == 0)
        //                                        tarifa = obtenerTarifaDesdeCodigo(codigoPorcentaje);

        //                                    if (codigo == "2") // Es IVA
        //                                    {
        //                                        if (tarifa > 0)
        //                                        {
        //                                            // Base CON IVA
        //                                            class_AdcDoc.Doc_totciva += baseImponible; // 19.00
        //                                            class_AdcDoc.Doc_porceniva = tarifa; // 15
        //                                            class_AdcDoc.BaseImp1 += baseImponible;
        //                                        }
        //                                        else
        //                                        {
        //                                            // Base SIN IVA
        //                                            class_AdcDoc.Doc_totsiva += baseImponible; // 4.00
        //                                        }
        //                                    }
        //                                }
        //                            }

        //                            // Calcular IVA
        //                            if (class_AdcDoc.Doc_porceniva > 0)
        //                            {
        //                                class_AdcDoc.Doc_valoriva = class_AdcDoc.Doc_totciva * (class_AdcDoc.Doc_porceniva / 100); // 1.85
        //                            }
        //                        }
        //                        break;
        //                    case "moneda":
        //                        class_AdcDoc.Moneda = mValor;
        //                        break;
        //                    case "totalConImpuestos":
        //                        importarImpuestosDoc(child.ChildNodes.Item(i), class_AdcDoc);
        //                        break;
        //                }
        //            }
        //            catch { break; }
        //        }
        //    }
        //}

        public static void importaInfFactura(XmlDocument xmlDocFactura, AdcDoc class_AdcDoc, DataGridView mallaReferencia)
        {
            XmlNode child = xmlDocFactura.SelectSingleNode("/factura/infoFactura");
            if (child != null)
            {
                // Variables para almacenar valores del XML
                decimal importeTotalXml = 0;
                decimal totalSinImpuestosXml = 0;
                decimal totalDescuentoXml = 0;

                for (int i = 0; i < child.ChildNodes.Count; i++)
                {
                    try
                    {
                        string mNombre = child.ChildNodes.Item(i).Name;
                        string mValor = child.ChildNodes.Item(i).InnerText;

                        Console.WriteLine($"Procesando campo: {mNombre} = {mValor}");

                        switch (mNombre)
                        {
                            case "fechaEmision":
                                class_AdcDoc.Doc_fecha = Convert.ToDateTime(mValor);
                                Console.WriteLine($"  Asignado Doc_fecha: {class_AdcDoc.Doc_fecha}");
                                break;

                            case "totalDescuento":
                                totalDescuentoXml = Convert.ToDecimal(mValor);
                                class_AdcDoc.doc_TotDesCIva = totalDescuentoXml;
                                Console.WriteLine($"  Asignado doc_TotDesCIva: {totalDescuentoXml}");
                                break;

                            case "totalSinImpuestos":
                                totalSinImpuestosXml = Convert.ToDecimal(mValor);
                                // Guardar temporalmente - se ajustará después
                                class_AdcDoc.Doc_totciva = totalSinImpuestosXml;
                                Console.WriteLine($"  Temporal Doc_totciva: {totalSinImpuestosXml}");
                                break;

                            case "importeTotal":
                                importeTotalXml = Convert.ToDecimal(mValor);
                                class_AdcDoc.Doc_valor = importeTotalXml;
                                Console.WriteLine($"  Asignado Doc_valor (XML): {importeTotalXml}");
                                break;

                            case "moneda":
                                class_AdcDoc.Moneda = mValor;
                                Console.WriteLine($"  Asignado Moneda: {mValor}");
                                break;

                            case "totalConImpuestos":
                                Console.WriteLine("  Procesando totalConImpuestos...");
                                importarImpuestosDoc(child.ChildNodes.Item(i), class_AdcDoc);
                                break;

                            case "razonSocialComprador":
                                class_AdcDoc.Doc_NombreImp = mValor;
                                Console.WriteLine($"  Asignado Doc_NombreImp: {mValor}");
                                break;

                            case "identificacionComprador":
                                class_AdcDoc.Doc_CiRuc = mValor;
                                Console.WriteLine($"  Asignado Doc_CiRuc: {mValor}");
                                break;

                            case "direccionComprador":
                                class_AdcDoc.Doc_Direccion = mValor;
                                Console.WriteLine($"  Asignado Doc_Direccion: {mValor}");
                                break;

                            case "obligadoContabilidad":
                                class_AdcDoc.Doc_Contabilidad = (mValor.ToUpper() == "SI") ? 1 : 0;
                                Console.WriteLine($"  Asignado Doc_Contabilidad: {class_AdcDoc.Doc_Contabilidad}");
                                break;

                            case "propina":
                                class_AdcDoc.AuxNum1 = Convert.ToDecimal(mValor);
                                Console.WriteLine($"  Asignado AuxNum1 (propina): {mValor}");
                                break;

                            case "dirEstablecimiento":
                                class_AdcDoc.AuxVar1 = mValor;
                                Console.WriteLine($"  Asignado AuxVar1: {mValor}");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error procesando {child.ChildNodes.Item(i).Name}: {ex.Message}");
                        continue; // Continuar con siguiente campo
                    }
                }

                // ============================================
                // VALIDACIÓN Y AJUSTE DE CONSISTENCIA
                // ============================================
                Console.WriteLine("\n=== VALIDACIÓN DE CONSISTENCIA ===");
                Console.WriteLine($"Total sin impuestos (XML): {totalSinImpuestosXml}");
                Console.WriteLine($"Importe total (XML): {importeTotalXml}");
                Console.WriteLine($"Doc_totciva (base con IVA): {class_AdcDoc.Doc_totciva}");
                Console.WriteLine($"Doc_totsiva (base sin IVA): {class_AdcDoc.Doc_totsiva}");
                Console.WriteLine($"Doc_valoriva (IVA total): {class_AdcDoc.Doc_valoriva}");
                Console.WriteLine($"Doc_porceniva (% IVA): {class_AdcDoc.Doc_porceniva}");

                // Calcular total según bases + IVA
                decimal totalCalculado = class_AdcDoc.Doc_totciva + class_AdcDoc.Doc_totsiva + class_AdcDoc.Doc_valoriva;
                Console.WriteLine($"Total calculado (bases + IVA): {totalCalculado}");

                // Verificar si hay inconsistencia entre el XML y los cálculos
                if (Math.Abs(importeTotalXml - totalCalculado) > 0.01m)
                {
                    Console.WriteLine($"¡INCONSISTENCIA DETECTADA!");
                    Console.WriteLine($"  XML dice: {importeTotalXml}");
                    Console.WriteLine($"  Cálculo dice: {totalCalculado}");
                    Console.WriteLine($"  Diferencia: {Math.Abs(importeTotalXml - totalCalculado)}");

                    // Guardar ambos valores para referencia
                    class_AdcDoc.AuxNum2 = totalCalculado; // Valor real calculado
                    Console.WriteLine($"  Guardando valor real en AuxNum2: {totalCalculado}");

                    // Si el IVA es 0 pero debería tener, recalcular
                    if (class_AdcDoc.Doc_valoriva == 0 && class_AdcDoc.Doc_porceniva > 0 && class_AdcDoc.Doc_totciva > 0)
                    {
                        decimal ivaCalculado = class_AdcDoc.Doc_totciva * (class_AdcDoc.Doc_porceniva / 100);
                        Console.WriteLine($"  Recalculando IVA: {class_AdcDoc.Doc_totciva} * {class_AdcDoc.Doc_porceniva}% = {ivaCalculado}");
                        class_AdcDoc.Doc_valoriva = ivaCalculado;
                        totalCalculado = class_AdcDoc.Doc_totciva + class_AdcDoc.Doc_totsiva + class_AdcDoc.Doc_valoriva;
                        Console.WriteLine($"  Nuevo total calculado: {totalCalculado}");
                    }
                }
                else
                {
                    Console.WriteLine("✅ Totales consistentes");
                }

                // Asegurar que Doc_totciva + Doc_totsiva = totalSinImpuestosXml
                decimal totalBases = class_AdcDoc.Doc_totciva + class_AdcDoc.Doc_totsiva;
                if (Math.Abs(totalSinImpuestosXml - totalBases) > 0.01m)
                {
                    Console.WriteLine($"Ajustando bases para coincidir con totalSinImpuestos ({totalSinImpuestosXml})");

                    // Si solo hay base con IVA, asignar todo a Doc_totciva
                    if (class_AdcDoc.Doc_porceniva > 0 && class_AdcDoc.Doc_totsiva == 0)
                    {
                        class_AdcDoc.Doc_totciva = totalSinImpuestosXml;
                        Console.WriteLine($"  Ajustado Doc_totciva a: {totalSinImpuestosXml}");
                    }
                    // Si hay ambas bases, mantener proporción
                    else if (class_AdcDoc.Doc_totciva > 0 && class_AdcDoc.Doc_totsiva > 0)
                    {
                        decimal factor = totalSinImpuestosXml / totalBases;
                        class_AdcDoc.Doc_totciva = class_AdcDoc.Doc_totciva * factor;
                        class_AdcDoc.Doc_totsiva = class_AdcDoc.Doc_totsiva * factor;
                        Console.WriteLine($"  Ajustadas bases proporcionalmente: Doc_totciva={class_AdcDoc.Doc_totciva}, Doc_totsiva={class_AdcDoc.Doc_totsiva}");
                    }
                }

                Console.WriteLine("\n=== VALORES FINALES ===");
                Console.WriteLine($"Doc_valor: {class_AdcDoc.Doc_valor}");
                Console.WriteLine($"Doc_totciva: {class_AdcDoc.Doc_totciva}");
                Console.WriteLine($"Doc_totsiva: {class_AdcDoc.Doc_totsiva}");
                Console.WriteLine($"Doc_valoriva: {class_AdcDoc.Doc_valoriva}");
                Console.WriteLine($"Doc_porceniva: {class_AdcDoc.Doc_porceniva}");
            }
            else
            {
                Console.WriteLine("ERROR: No se encontró nodo infoFactura en el XML");
            }
        }

        private static void importarImpuestosDoc(XmlNode childPago, AdcDoc docDax)
        {
            if (childPago == null)
            {
                Console.WriteLine("  No hay nodo totalConImpuestos");
                return;
            }

            decimal totalConIva = 0;
            decimal totalSinIva = 0;
            decimal totalIva = 0;
            decimal porcIvaPrincipal = 0;

            Console.WriteLine($"  Procesando {childPago.ChildNodes.Count} impuestos...");

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
                                Console.WriteLine($"    Código: {codigo}");
                                break;

                            case "codigoPorcentaje":
                                codigoPorcentaje = campo.InnerText.Trim();
                                Console.WriteLine($"    Código Porcentaje: {codigoPorcentaje}");
                                break;

                            case "baseImponible":
                                decimal.TryParse(campo.InnerText.Replace(",", "."), out baseImponible);
                                Console.WriteLine($"    Base Imponible: {baseImponible}");
                                break;

                            case "tarifa":
                                decimal.TryParse(campo.InnerText.Replace(",", "."), out tarifa);
                                Console.WriteLine($"    Tarifa: {tarifa}");
                                break;

                            case "valor":
                                decimal.TryParse(campo.InnerText.Replace(",", "."), out valor);
                                Console.WriteLine($"    Valor: {valor}");
                                break;
                        }
                    }

                    // SOLO IVA (código 2)
                    if (codigo == "2")
                    {
                        // Si tarifa viene como 0, obtenerla del códigoPorcentaje
                        if (tarifa == 0)
                        {
                            tarifa = obtenerTarifaDesdeCodigo(codigoPorcentaje);
                            Console.WriteLine($"    Tarifa desde código {codigoPorcentaje}: {tarifa}%");
                        }

                        // Si tiene tarifa > 0, es base CON IVA
                        if (tarifa > 0)
                        {
                            totalConIva += baseImponible;
                            totalIva += valor;

                            // Guardar el porcentaje principal (el primero que encuentre > 0)
                            if (porcIvaPrincipal == 0 && tarifa > 0)
                            {
                                porcIvaPrincipal = tarifa;
                            }

                            Console.WriteLine($"    Base CON IVA ({tarifa}%): +{baseImponible}, IVA: +{valor}");
                        }
                        else
                        {
                            // Tarifa = 0, es base SIN IVA
                            totalSinIva += baseImponible;
                            Console.WriteLine($"    Base SIN IVA: +{baseImponible}");
                        }
                    }
                }
            }

            // Asignar valores a la clase
            docDax.Doc_totciva = totalConIva;      // Base gravable CON IVA
            docDax.Doc_totsiva = totalSinIva;      // Base NO gravable SIN IVA
            docDax.Doc_valoriva = totalIva;        // Total IVA
            docDax.Doc_porceniva = porcIvaPrincipal; // Porcentaje principal

            Console.WriteLine($"  Resultados: ConIVA={totalConIva}, SinIVA={totalSinIva}, IVA={totalIva}, %IVA={porcIvaPrincipal}");
        }

        private static decimal obtenerTarifaDesdeCodigo(string cod)
        {
            switch (cod)
            {
                case "0": return 0;    // 0%
                case "2": return 12;   // 12%
                case "3": return 14;   // 14%
                case "4": return 15;   // 15% ← Este es tu caso
                case "5": return 13;   // 13%
                case "6": return 8;    // 8%
                case "7": return 5;    // 5%
                case "8": return 10;   // 10%
                case "9": return 0;    // 0% - Exento
                default: return 0;
            }
        }

        public static void importaDetallesFactura(XmlDocument xmlDocFactura, AdcTra class_AdcTra, AdcDoc class_AdcDoc, DataGridView mallaReferencia)
        {
            XmlNode childDet = xmlDocFactura.SelectSingleNode("/factura/detalles");
            if (childDet != null)
            {
                if (childDet.ChildNodes.Count == 0) return;

                for (int i = 0; i < childDet.ChildNodes.Count; i++)
                {
                    try
                    {
                        XmlNode child = childDet.ChildNodes[i];
                        if (child.Name == "detalle")
                        {
                            class_AdcTra = new AdcTra();
                            decimal precioTotalSinImpuesto = 0;
                            decimal porcIva = 0;
                            bool tieneIva = false;

                            for (int j = 0; j < child.ChildNodes.Count; j++)
                            {
                                try
                                {
                                    string mNombre = child.ChildNodes.Item(j).Name;
                                    string mValor = child.ChildNodes.Item(j).InnerText;

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
                                            class_AdcTra.Tra_numprecio = "1"; // ← AQUÍ
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
                                            break;

                                        case "impuestos":
                                            XmlNode childImp = child.ChildNodes[j];
                                            if (childImp.ChildNodes.Count > 0)
                                            {
                                                // Obtener porcentaje de IVA
                                                porcIva = importarImpuestosTra(childImp);
                                                tieneIva = (porcIva > 0);
                                                class_AdcTra.Tra_sniva = tieneIva;
                                                class_AdcTra.Tra_porceniva = porcIva;

                                                // Calcular el valor del IVA para esta línea
                                                if (tieneIva && precioTotalSinImpuesto > 0)
                                                {
                                                    decimal valorIva = precioTotalSinImpuesto * (porcIva / 100);
                                                    class_AdcTra.Tra_valoriva = valorIva;
                                                    class_AdcTra.Tra_valor = precioTotalSinImpuesto + valorIva; // ← AQUÍ
                                                }
                                                else
                                                {
                                                    class_AdcTra.Tra_valoriva = 0;
                                                    class_AdcTra.Tra_valor = precioTotalSinImpuesto; // ← AQUÍ
                                                }
                                            }
                                            break;

                                        case "detallesAdicionales":
                                            XmlNode childAdiTra = child.ChildNodes[j];
                                            if (childAdiTra.ChildNodes.Count > 0)
                                                importardetallesAdicionalesTra(childAdiTra, class_AdcTra);
                                            break;
                                    }
                                }
                                catch { break; }
                            }

                            // Si no se procesaron impuestos, calcular valores por defecto
                            if (class_AdcTra.Tra_valor == 0)
                            {
                                class_AdcTra.Tra_valor = precioTotalSinImpuesto; // ← AQUÍ
                            }

                            // Calcular costos (para artículos)
                            CalcularCostosParaArticulo(ref class_AdcTra, class_AdcDoc);

                            guardaDetalle(class_AdcTra, class_AdcDoc, mallaReferencia);
                        }
                    }
                    catch { break; }
                }
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

        //private static void guardaDetalle(AdcTra adcTra, AdcDoc adcDoc, DataGridView mallaReferencia)
        //{
        //    Boolean esConcepto = true;
        //    string valConcepto = "S";
        //    Int32 ind = 0;
        //    if (adcTra.Tra_Codigo == "" && adcTra.Tra_nombre == "") return;

        //    if (adcTra.Tra_Codigo == "") adcTra.Tra_Codigo = adcTra.Tra_nombre;
        //    if (adcTra.Tra_nombre == "") adcTra.Tra_nombre = adcTra.Tra_Codigo;

        //    mallaReferencia.Rows.Add();

        //    ind = mallaReferencia.Rows.Count - 1;
        //    mallaReferencia.Rows[ind].Cells["ProductoProveedor"].Value = adcTra.Tra_Codigo;
        //    mallaReferencia.Rows[ind].Cells["DetalleProveedor"].Value = adcTra.Tra_nombre;
        //    mallaReferencia.Rows[ind].Cells["usarDetalle"].Value = "Proveedor";
        //    mallaReferencia.Rows[ind].Cells["DetalleAutilizar"].Value = adcTra.Tra_nombre;

        //    mallaReferencia.Rows[ind].Cells["Cantidad"].Value = adcTra.Tra_cantidad;
        //    mallaReferencia.Rows[ind].Cells["PvUni"].Value = adcTra.Tra_precuni;
        //    mallaReferencia.Rows[ind].Cells["iva"].Value = adcTra.Tra_sniva;
        //    mallaReferencia.Rows[ind].Cells["PorcDes"].Value = adcTra.Tra_valordes;

        //    mallaReferencia.Rows[ind].Cells["Lote"].Value = adcTra.Tra_NroLote;
        //    mallaReferencia.Rows[ind].Cells["Vence"].Value = adcTra.AuxVar1;
        //    mallaReferencia.Rows[ind].Cells["CodAlterno"].Value = adcTra.tra_codigoalterno;

        //    string strAux = articuloAdcom(adcTra.Tra_Codigo, adcDoc.Doc_CiRuc, ref esConcepto);

        //    if (esConcepto == false) valConcepto = "A";
        //    if (strAux != "")
        //    {
        //        mallaReferencia.Rows[ind].Cells["codProductoPropio"].Value = strAux;
        //    }
        //    else
        //    {

        //    }
        //    mallaReferencia.Rows[ind].Cells["ConceptoProducto"].Value = valConcepto;
        //    //DataRow row = Dt_adctra.NewRow();
        //    //adcTra.moverAdctraDatarow(adcTra,ref row);
        //    //Dt_adctra.Rows.Add(row);
        //}

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

            // CAMPOS PRINCIPALES
            mallaReferencia.Rows[ind].Cells["ProductoProveedor"].Value = adcTra.Tra_Codigo;
            mallaReferencia.Rows[ind].Cells["DetalleProveedor"].Value = adcTra.Tra_nombre;
            mallaReferencia.Rows[ind].Cells["usarDetalle"].Value = "Proveedor";
            mallaReferencia.Rows[ind].Cells["DetalleAutilizar"].Value = adcTra.Tra_nombre;

            mallaReferencia.Rows[ind].Cells["Cantidad"].Value = adcTra.Tra_cantidad;
            mallaReferencia.Rows[ind].Cells["PvUni"].Value = adcTra.Tra_precuni;
            mallaReferencia.Rows[ind].Cells["iva"].Value = adcTra.Tra_sniva;
            mallaReferencia.Rows[ind].Cells["PorcDes"].Value = adcTra.Tra_valordes;

            // CAMPOS DE IVA
            if (mallaReferencia.Columns.Contains("Tra_porceniva"))
            {
                mallaReferencia.Rows[ind].Cells["Tra_porceniva"].Value = adcTra.Tra_porceniva;
            }

            if (mallaReferencia.Columns.Contains("Tra_valoriva"))
            {
                mallaReferencia.Rows[ind].Cells["Tra_valoriva"].Value = adcTra.Tra_valoriva;
            }

            // CAMPOS DE VALOR TOTAL
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

            string strAux = articuloAdcom(adcTra.Tra_Codigo, adcDoc.Doc_CiRuc, ref esConcepto);

            if (!esConcepto)
                valConcepto = "A";

            if (!string.IsNullOrEmpty(strAux))
            {
                mallaReferencia.Rows[ind].Cells["codProductoPropio"].Value = strAux;
            }

            mallaReferencia.Rows[ind].Cells["ConceptoProducto"].Value = valConcepto;
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

        //private static void importarImpuestosDoc(XmlNode childPago, AdcDoc docDax)
        //{
        //    if (childPago.ChildNodes.Count == 0) return;
        //    string[] codigo = new string[childPago.ChildNodes.Count];
        //    string[] codPorcentaje = new string[childPago.ChildNodes.Count];
        //    string[] baseImponible = new string[childPago.ChildNodes.Count];
        //    string[] tarifa = new string[childPago.ChildNodes.Count];
        //    string[] valor = new string[childPago.ChildNodes.Count];
        //    int validos = 0;
        //    XmlNode child;
        //    if (childPago != null)
        //    {
        //        //      'Obtenemos el Elemento nombre y valor               
        //        for (int i = 0; i < childPago.ChildNodes.Count; i++)
        //        {
        //            try
        //            {
        //                child = childPago.ChildNodes.Item(i);
        //                for (int j = 0; j < child.ChildNodes.Count; j++)
        //                {
        //                    validos++;
        //                    try
        //                    {
        //                        string mNombre = child.ChildNodes.Item(j).Name;
        //                        string mValor = child.ChildNodes.Item(j).InnerText;
        //                        switch (mNombre)
        //                        {
        //                            case "codigo":
        //                                codigo[i] = mValor;
        //                                break;
        //                            case "codigoPorcentaje":
        //                                codPorcentaje[i] = mValor;
        //                                break;
        //                            case "baseImponible":
        //                                baseImponible[i] = mValor;
        //                                break;
        //                            case "tarifa":
        //                                tarifa[i] = mValor;
        //                                break;
        //                            case "valor":
        //                                valor[i] = mValor;
        //                                break;
        //                        }
        //                    }
        //                    catch { break; }
        //                }
        //            }
        //            catch { break; }
        //        }
        //        if (validos > 0)
        //        {
        //            for (int i = 0; i < validos; i++)
        //            {
        //                decimal porcIva = 0;
        //                decimal valorIva = 0;
        //                try
        //                {
        //                    valorIva = Convert.ToDecimal(valor[0]);
        //                    porcIva = Convert.ToDecimal(tarifa[0]);
        //                }
        //                catch { }
        //                docDax.Doc_valoriva = valorIva;
        //                docDax.Doc_porceniva = porcIva;
        //            }
        //        }
        //    }

        //}

        //private static void importarImpuestosDoc(XmlNode childPago, AdcDoc docDax)
        //{
        //    if (childPago == null) return;

        //    foreach (XmlNode impuesto in childPago.ChildNodes)
        //    {
        //        string codigo = "";
        //        string codigoPorcentaje = "";
        //        decimal tarifa = 0;
        //        decimal valor = 0;

        //        foreach (XmlNode campo in impuesto.ChildNodes)
        //        {
        //            switch (campo.Name)
        //            {
        //                case "codigo":
        //                    codigo = campo.InnerText.Trim();
        //                    break;

        //                case "codigoPorcentaje":
        //                    codigoPorcentaje = campo.InnerText.Trim();
        //                    break;

        //                case "tarifa":
        //                    decimal.TryParse(campo.InnerText.Replace(",", "."), out tarifa);
        //                    break;

        //                case "valor":
        //                    decimal.TryParse(campo.InnerText.Replace(",", "."), out valor);
        //                    break;
        //            }
        //        }

        //        // ✅ SOLO IVA
        //        if (codigo == "2")
        //        {
        //            // si no vino tarifa → calcular por codigoPorcentaje
        //            if (tarifa == 0)
        //                tarifa = obtenerTarifaDesdeCodigo(codigoPorcentaje);

        //            docDax.Doc_porceniva = tarifa;
        //            docDax.Doc_valoriva = valor;
        //        }
        //    }
        //}

        //private static decimal obtenerTarifaDesdeCodigo(string cod)
        //{
        //    switch (cod)
        //    {
        //        case "0": return 0;    // 0% - No tiene IVA
        //        case "2": return 12;   // 12% - IVA 12%
        //        case "3": return 14;   // 14% - IVA 14%
        //        case "4": return 15;   // 15% - IVA 15% ← TU CASO
        //        case "5": return 13;   // 13% - IVA 13%
        //        case "6": return 8;    // 8% - IVA 8%
        //        case "7": return 5;    // 5% - IVA 5%
        //        case "8": return 10;   // 10% - IVA 10%
        //        case "9": return 0;    // 0% - Exento
        //        default: return 0;
        //    }
        //}


  //      public static Boolean importarImpuestosTra(XmlNode childDetalle)
		//{
		//	if (childDetalle == null) return false;
		//	if (childDetalle.ChildNodes.Count == 0) return false;
		//	string impCodigo = "0";
		//	double impValor = 0;
		//	XmlNode child;
		//	if (childDetalle != null)
		//	{
		//		//      'Obtenemos el Elemento nombre y valor               
		//		for (int i = 0; i < childDetalle.ChildNodes.Count; i++)
		//		{
		//			try
		//			{
		//				child = childDetalle.ChildNodes.Item(i);
		//				for (int j = 0; j < child.ChildNodes.Count; j++)
		//				{
		//					try
		//					{
		//						string mNombre = child.ChildNodes.Item(j).Name;
		//						string mValor = child.ChildNodes.Item(j).InnerText;
		//						switch (mNombre)
		//						{
		//							case "codigo":
		//								impCodigo = mValor;
		//								break;
		//							case "tarifa":
		//								impValor = Convert.ToDouble(mValor);
		//								break;
		//						}
		//					}
		//					catch { break; }
		//				}
		//			}
		//			catch { break; }
		//		}
		//		if (impCodigo == "2" && impValor > 0) return true;
		//	}
		//	return false;
		//}

		//public static decimal importarImpuestosTra(XmlNode childDetalle)
  //      {
  //          if (childDetalle == null) return 0;

  //          foreach (XmlNode impuesto in childDetalle.ChildNodes)
  //          {
  //              string codigo = "";
  //              decimal tarifa = 0;

  //              foreach (XmlNode campo in impuesto.ChildNodes)
  //              {
  //                  switch (campo.Name)
  //                  {
  //                      case "codigo":
  //                          codigo = campo.InnerText;
  //                          break;

  //                      case "tarifa":
  //                          decimal.TryParse(campo.InnerText, out tarifa);
  //                          break;
  //                  }
  //              }

  //              // IVA
  //              if (codigo == "2")
  //                  return tarifa; // ← devuelve 15
  //          }

  //          return 0;
  //      }



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

    }
}
