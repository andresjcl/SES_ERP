using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using ClassDoc;
using DattCom;
namespace leeDocXml
{
    class impRtc
    {
        public static void importaInfTributariaRetencion(XmlNode child, AdcDoc class_AdcDoc, ref string tipoIdentificacion)
        { 
            string estab = "";
            string ptoemi = "";
            if (child != null)
            {
                try {
                                class_AdcDoc.tipoEmision = Convert.ToInt32(valorElemento(child, "tipoEmision"));
                                class_AdcDoc.Doc_NombreImp = valorElemento(child, "razonSocial");
                                class_AdcDoc.Doc_CiRuc = valorElemento(child, "ruc");
                                class_AdcDoc.claveSri = valorElemento(child, "claveAcceso");
                                class_AdcDoc.Adi_TipoDocSri = valorElemento(child, "codDoc");
                                estab = valorElemento(child, "estab");
                                ptoemi = valorElemento(child, "ptoEmi");
                                class_AdcDoc.Doc_numero = Convert.ToDecimal(valorElemento(child, "secuencial"));
                                class_AdcDoc.Doc_Direccion = valorElemento(child, "dirMatriz");
                                tipoIdentificacion = valorElemento(child, "tipoIdentificacionComprador");
                    }
                    catch {}
                    }
                class_AdcDoc.Doc_NroIdDoc = estab + "-" + ptoemi;            
        }
        public static void importaInfRetencion(XmlDocument xmlDocFactura, AdcDoc class_AdcDoc, DataGridView mallaReferencia)
        {
            XmlNode child = xmlDocFactura.SelectSingleNode("/comprobanteRetencion/infoCompRetencion");
            if (child != null)
            {                            
                class_AdcDoc.Doc_fecha = Convert.ToDateTime(valorElemento(child,"fechaEmision"));
            }
        }
        public static void importaDetallesRetencion(XmlDocument xmlDocFactura, AdcSri class_AdcSri, AdcDoc class_AdcDoc, DataGridView mallaReferencia)
        {
            XmlNode childDet = xmlDocFactura.SelectSingleNode("/comprobanteRetencion/impuestos");
            if (childDet != null)
            {
                int nroFuente = 0;
                int nroIva = 0;
                
                string nroSustento = "";

                if (childDet.ChildNodes.Count == 0) return;
                for (int i = 0; i < childDet.ChildNodes.Count; i++)
                {
                    try
                    {
                        XmlNode child = childDet.ChildNodes[i];
                    if (child.Name == "impuesto")
                    {
                        try
                        {
                            int tiporetencion =Convert.ToInt16(valorElemento(child, "codigo"));
                            if (tiporetencion == 1) // retencion impuesto a la renta                {
                            {
                                nroFuente++;
                                if (nroFuente == 1)  // retencion en la fuente 1
                                {
                                    class_AdcSri.CodigoRetFuente = valorElemento(child, "codigoRetencion");
                                    class_AdcSri.BaseRetFuente = Convert.ToDecimal(valorElemento(child, "baseImponible"));
                                    class_AdcSri.BasIvaCon = class_AdcSri.BaseRetFuente;
                                    class_AdcSri.PorRetFuente = Convert.ToDecimal( valorElemento(child, "porcentajeRetener"));
                                    class_AdcSri.ValorRetFuente = Convert.ToDecimal(valorElemento(child, "valorRetenido"));
                                    class_AdcSri.Sri_tipoDoc = valorElemento(child, "codDocSustento");
                                    nroSustento = valorElemento(child, "numDocSustento");
                                    try { class_AdcSri.fechaEmisionDocSustento = Convert.ToDateTime(valorElemento(child, "fechaEmisionDocSustento")); }
                                    catch { class_AdcSri.fechaEmisionDocSustento = new DateTime(1900, 1, 1); }
                                }
                                else  // retencion en la fuente 2
                                {
                                    class_AdcSri.CodigoRetFuente1 = valorElemento(child, "codigoRetencion");
                                    class_AdcSri.BaseRetFuente1 = Convert.ToDecimal(valorElemento(child, "baseImponible"));
                                    class_AdcSri.BasIvaCon1 = class_AdcSri.BaseRetFuente1;
                                    class_AdcSri.PorRetFuente1 = Convert.ToDecimal( valorElemento(child, "porcentajeRetener"));
                                    class_AdcSri.ValorRetFuente1 = Convert.ToDecimal(valorElemento(child, "valorRetenido"));
                                    class_AdcSri.Sri_tipoDoc = valorElemento(child, "codDocSustento");
                                    nroSustento = valorElemento(child, "numDocSustento");
                                    try { class_AdcSri.fechaEmisionDocSustento = Convert.ToDateTime(valorElemento(child, "fechaEmisionDocSustento")); }
                                    catch { class_AdcSri.fechaEmisionDocSustento = new DateTime(1900, 1, 1); }
                                }
                            }

                            else // retencion iva
                            {
                                nroIva++;
                                if (nroIva == 1)  // retencion IVA 1 asignamos a bienes provisionalmente
                                {
                                    class_AdcSri.CodigoRetIvaBienes = valorElemento(child, "codigoRetencion");
                                    class_AdcSri.BaseIvaBienes = Convert.ToDecimal(valorElemento(child, "baseImponible"));
                                    class_AdcSri.PorRetIvaBienes =Convert.ToDecimal(valorElemento(child, "porcentajeRetener"));
                                    class_AdcSri.ValorRetIvaBienes = Convert.ToDecimal(valorElemento(child, "valorRetenido"));
                                    class_AdcSri.Sri_tipoDoc = valorElemento(child, "codDocSustento");
                                    nroSustento = valorElemento(child, "numDocSustento");
                                    try { class_AdcSri.fechaEmisionDocSustento = Convert.ToDateTime(valorElemento(child, "fechaEmisionDocSustento")); }
                                    catch { class_AdcSri.fechaEmisionDocSustento = new DateTime(1900, 1, 1); }
                                }
                                else  // retencion IVA 2    asignamos a servicios provisionalmente
                                {
                                    class_AdcSri.CodigoRetIvaServicios = valorElemento(child, "codigoRetencion");
                                    class_AdcSri.BaseIvaServicios = Convert.ToDecimal(valorElemento(child, "baseImponible"));
                                    class_AdcSri.PorRetIvaServicios = Convert.ToDecimal(valorElemento(child, "porcentajeRetener"));
                                    class_AdcSri.ValorRetIvaServicios = Convert.ToDecimal(valorElemento(child, "valorRetenido"));
                                    class_AdcSri.Sri_tipoDoc = valorElemento(child, "codDocSustento");
                                    nroSustento = valorElemento(child, "numDocSustento");
                                    try { class_AdcSri.fechaEmisionDocSustento = Convert.ToDateTime(valorElemento(child, "fechaEmisionDocSustento")); }
                                    catch { class_AdcSri.fechaEmisionDocSustento = new DateTime(1900, 1, 1); }
                                }
                            }                    
                        }catch { }
                            //obtenerDatosDocumentoAdcom(class_AdcSri.numDocSustento, class_AdcDoc, class_AdcSri);
                            //guardaDetalle(class_AdcSri, class_AdcDoc, mallaReferencia);
                        }
                    }
                    catch { break; }
                }
                class_AdcDoc.Doc_valor = class_AdcSri.ValorRetFuente + class_AdcSri.ValorRetFuente1 + class_AdcSri.ValorRetIvaBienes + class_AdcSri.ValorRetIvaServicios;
                obtenerDatosDocumentoAdcom(nroSustento, class_AdcDoc, class_AdcSri);
                guardaDetalle(class_AdcSri, class_AdcDoc, mallaReferencia);
            }
        }
        static private string valorElemento(XmlNode child, string nomElemento)
        {
            for (int j = 0; j < child.ChildNodes.Count; j++)
            {
                //                                XmlNodeList elemList = doc.GetElementsByTagName("title");
                try
                {
                    if (nomElemento == child.ChildNodes.Item(j).Name) return child.ChildNodes.Item(j).InnerText;
                }finally{}
            }
            return "";
        }
        private static void guardaDetalle(AdcSri adcSri, AdcDoc adcDoc, DataGridView mallaReferencia)
        {
            Int32 ind = 0;
            if (adcSri.BaseRetFuente  > 0)
            {
                mallaReferencia.Rows.Add();
                ind = mallaReferencia.Rows.Count - 1;
                mallaReferencia.Rows[ind].Cells["tipoRetencion"].Value = "Fuente";
                mallaReferencia.Rows[ind].Cells["codigoRetencion"].Value = adcSri.CodigoRetFuente;
                mallaReferencia.Rows[ind].Cells["baseImponible"].Value = adcSri.BaseRetFuente;
                mallaReferencia.Rows[ind].Cells["PorcentajeRetener"].Value = adcSri.PorRetFuente;
                mallaReferencia.Rows[ind].Cells["valorRetenido"].Value = adcSri.ValorRetFuente;
                mallaReferencia.Rows[ind].Cells["codDocSustento"].Value = adcSri.Sri_tipoDoc;
                mallaReferencia.Rows[ind].Cells["tipoDocumentAdcom"].Value = adcSri.codDocSustentoAdcom;
                mallaReferencia.Rows[ind].Cells["numDocSustento"].Value = adcSri.idsriDocSustento.Substring(0, 3) + "-" + adcSri.idsriDocSustento.Substring(3, 3) + "-" + adcSri.numDocSustento;
                mallaReferencia.Rows[ind].Cells["fechaEmisionDocSustento"].Value = adcSri.fechaEmisionDocSustento.ToShortDateString();                
            }
            if (adcSri.BaseRetFuente1 > 0)
            {
                mallaReferencia.Rows.Add();
                ind = mallaReferencia.Rows.Count - 1;
                mallaReferencia.Rows[ind].Cells["tipoRetencion"].Value = "Fuente1";
                mallaReferencia.Rows[ind].Cells["codigoRetencion"].Value = adcSri.CodigoRetFuente1;
                mallaReferencia.Rows[ind].Cells["baseImponible"].Value = adcSri.BaseRetFuente1;
                mallaReferencia.Rows[ind].Cells["PorcentajeRetener"].Value = adcSri.PorRetFuente1;
                mallaReferencia.Rows[ind].Cells["valorRetenido"].Value = adcSri.ValorRetFuente1;
                mallaReferencia.Rows[ind].Cells["codDocSustento"].Value = adcSri.Sri_tipoDoc;
                mallaReferencia.Rows[ind].Cells["tipoDocumentAdcom"].Value = adcSri.codDocSustentoAdcom;
                mallaReferencia.Rows[ind].Cells["numDocSustento"].Value = adcSri.idsriDocSustento.Substring(0, 3) + "-" + adcSri.idsriDocSustento.Substring(3, 3) + "-" + adcSri.numDocSustento;
                mallaReferencia.Rows[ind].Cells["fechaEmisionDocSustento"].Value = adcSri.fechaEmisionDocSustento;
            }
            if (adcSri.BaseIvaBienes > 0)
            {
                mallaReferencia.Rows.Add();
                ind = mallaReferencia.Rows.Count - 1;
                mallaReferencia.Rows[ind].Cells["tipoRetencion"].Value = "IvaBienes";
                mallaReferencia.Rows[ind].Cells["codigoRetencion"].Value = adcSri.CodigoRetIvaBienes;
                mallaReferencia.Rows[ind].Cells["baseImponible"].Value = adcSri.BaseIvaBienes;
                mallaReferencia.Rows[ind].Cells["PorcentajeRetener"].Value = adcSri.PorRetIvaBienes;
                mallaReferencia.Rows[ind].Cells["valorRetenido"].Value = adcSri.ValorRetIvaBienes;
                mallaReferencia.Rows[ind].Cells["codDocSustento"].Value = adcSri.Sri_tipoDoc;
                mallaReferencia.Rows[ind].Cells["tipoDocumentAdcom"].Value = adcSri.codDocSustentoAdcom;
                mallaReferencia.Rows[ind].Cells["numDocSustento"].Value = adcSri.idsriDocSustento.Substring(0, 3) + "-" + adcSri.idsriDocSustento.Substring(3, 3) + "-" + adcSri.numDocSustento;
                mallaReferencia.Rows[ind].Cells["fechaEmisionDocSustento"].Value = adcSri.fechaEmisionDocSustento;
            }
            if (adcSri.BaseIvaServicios > 0)
            {
                mallaReferencia.Rows.Add();
                ind = mallaReferencia.Rows.Count - 1;
                mallaReferencia.Rows[ind].Cells["tipoRetencion"].Value = "IvaServicios";
                mallaReferencia.Rows[ind].Cells["codigoRetencion"].Value = adcSri.CodigoRetIvaServicios;
                mallaReferencia.Rows[ind].Cells["baseImponible"].Value = adcSri.BaseIvaServicios;
                mallaReferencia.Rows[ind].Cells["PorcentajeRetener"].Value = adcSri.PorRetIvaServicios;
                mallaReferencia.Rows[ind].Cells["valorRetenido"].Value = adcSri.ValorRetIvaServicios;
                mallaReferencia.Rows[ind].Cells["codDocSustento"].Value = adcSri.Sri_tipoDoc;
                mallaReferencia.Rows[ind].Cells["tipoDocumentAdcom"].Value = adcSri.codDocSustentoAdcom;
                mallaReferencia.Rows[ind].Cells["numDocSustento"].Value = adcSri.idsriDocSustento.Substring(0,3) + "-" + adcSri.idsriDocSustento.Substring(3,3) + "-" + adcSri.numDocSustento;
                mallaReferencia.Rows[ind].Cells["fechaEmisionDocSustento"].Value = adcSri.fechaEmisionDocSustento;
            }

        }

        private static void importarImpuestosDoc(XmlNode childPago, AdcDoc docDax)
        {
            if (childPago.ChildNodes.Count == 0) return;
            string[] codigo = new string[childPago.ChildNodes.Count];
            string[] codPorcentaje = new string[childPago.ChildNodes.Count];
            string[] baseImponible = new string[childPago.ChildNodes.Count];
            string[] tarifa = new string[childPago.ChildNodes.Count];
            string[] valor = new string[childPago.ChildNodes.Count];
            int validos = 0;
            XmlNode child;
            if (childPago != null)
            {
                for (int i = 0; i < childPago.ChildNodes.Count; i++)
                {
                    try
                    {
                        child = childPago.ChildNodes.Item(i);
                        for (int j = 0; j < child.ChildNodes.Count; j++)
                        {
                            validos++;
                            try
                            {
                                codigo[i] = valorElemento(child, "codigo");
                                codPorcentaje[i] = valorElemento(child, "codigoPorcentaje");
                                baseImponible[i] = valorElemento(child, "baseImponible");
                                tarifa[i] = valorElemento(child, "tarifa");
                                valor[i] = valorElemento(child, "valor");
                            }
                            catch { break; }
                        }
                    }
                    catch { break; }
                }
                if (validos > 0)
                {
                    for (int i = 0; i < validos; i++)
                    {
                        decimal porcIva = 0;
                        decimal valorIva = 0;
                        try
                        {
                            valorIva = Convert.ToDecimal(valor[0]);
                            porcIva = Convert.ToDecimal(tarifa[0]);
                        }
                        catch { }
                        docDax.Doc_valoriva = valorIva;
                        docDax.Doc_porceniva = porcIva;
                    }
                }
            }

        }
        private static void obtenerDatosDocumentoAdcom(string numSri, AdcDoc classDoc,AdcSri classSri)
        {
            if (numSri =="" || numSri == "0" || numSri == "00")
            {
                classSri.codDocSustentoAdcom = "";
                classSri.IdClaveDocSustento = 0;
                classSri.numDocSustento = "0";
                classSri.idsriDocSustento = "000000";
                return;
            }
            string docnum = numSri.Substring(6);
            string idsri = numSri.Substring(0, 6);
            string ssql = "select * from adcdoc where doc_numero =" + docnum + " and doc_nroIdDoc = '" + idsri.Substring(0, 3) + "-" + idsri.Substring(3, 3) + "'";
            ssql += " and doc_ciruc = '" + classDoc.Doc_CiRuc + "' ";
            classSri.numDocSustento = docnum;
            classSri.idsriDocSustento = idsri;

            classDoc.IdClaveDocSop = classSri.IdClaveDocSustento;
            classDoc.Doc_NumeroExterno = Convert.ToDecimal("0"+docnum);

            using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(ssql, conn))
                {
                    using (SqlDataReader DR = comm.ExecuteReader())
                    {
                        if (DR.Read())
                        {
                            classSri.codDocSustentoAdcom = DR["OPC_Documento"].ToString();
                            classSri.IdClaveDocSustento = Convert.ToDecimal(DR["idclavedoc"]);
                        }
                        else
                        {
                            classSri.codDocSustentoAdcom = "DOC NO EXISTE"; classSri.IdClaveDoc = 0;
                        }
                        DR.Close();
                    }
                }
                conn.Close();
            }
        }

    }
}
