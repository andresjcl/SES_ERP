using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Text;
using System.Threading.Tasks;
using DaxDocElectronicos;
namespace atsgenxml
{
    public class atsGenCom
    {
        //string retorno = "";
        //Boolean esExportacion = false;
        Char cc = Convert.ToChar("0");
        Char bb = Convert.ToChar(" ");
           Feutilidad util = new Feutilidad();

        public string crear_ats_xml(string pathfile,string pathSys, DateTime fechaInicial,DateTime fechaFinal, string conxadc,string empRuc,string empNombre, string conxIva,string regMicroempresa)
        // generar el archivo xml por ats para enviar al sri
        {
            if (pathfile.Length == 0) return "Error : no se ha registrado el nombre del archivo";
            double numAux = 0;
            Int32 nroEstablecimientos = 0;
            double totalVentas = 0;
            string tipoDocSri = "";
            string tipoIdProveedor = "";
            
            DataTable dataResVentas = leerTabla ("select isnull(sum(totVenta),0) as total from resventas where FechaIni  >= '" + fechaInicial.ToShortDateString() + "' and fechafin <= '" + fechaFinal +"'", conxIva);

            if (dataResVentas.Rows.Count > 0)
            {
                if (dataResVentas.Rows[0]["total"] != null ) totalVentas = Convert.ToDouble(dataResVentas.Rows[0]["total"].ToString());
            }

            dataResVentas = leerTabla ("select * from resventas where FechaIni  >= '" + fechaInicial.ToShortDateString () + "' and fechaFin <= '" + fechaFinal.ToShortDateString() +"'" , conxIva);
            if (dataResVentas.Rows.Count > 0) nroEstablecimientos = dataResVentas.Rows.Count;
            //dataResVentas.Dispose();
            

            DataTable dataVentas = leerTabla("leeOrdenVentas '" + fechaInicial.ToShortDateString() + "', '" + fechaFinal.ToShortDateString() +"'", conxIva);
            DataTable dataCompras = leerTabla("leeOrdenCompras '" + fechaInicial.ToShortDateString() + "', '" + fechaFinal.ToShortDateString() + "'", conxIva);
            
            XmlTextWriter docXml = new XmlTextWriter(pathfile, System.Text.Encoding.UTF8);
            docXml.WriteStartDocument(true);
            docXml.Formatting = Formatting.Indented;
            //docXml.WriteComment("Generado por: AdcomDax de DaxsofSistem 0999906974 Quito Ecuador");

            docXml.WriteStartElement("iva");
            docXml.WriteElementString("TipoIDInformante", "R");
            docXml.WriteElementString("IdInformante", empRuc);
            docXml.WriteElementString("razonSocial", util.formatoString(empNombre, 300));
            docXml.WriteElementString("Anio", fechaFinal.Year.ToString());
            docXml.WriteElementString("Mes", util.formatoNumero(fechaFinal.Month.ToString(),2));

            if (regMicroempresa == "1" || regMicroempresa == "S") regMicroempresa = "SI";
            if (regMicroempresa == "SI") docXml.WriteElementString("regimenMicroempresa", regMicroempresa.Trim());

            if ( nroEstablecimientos > 0)
            {
                docXml.WriteElementString("numEstabRuc", util.formatoNumero(nroEstablecimientos.ToString(), 3));
                docXml.WriteElementString("totalVentas", util.formatoDecimal(totalVentas, 15, 2, true));
            }

            docXml.WriteElementString("codigoOperativo", "IVA");

            if (dataCompras.Rows.Count > 0)
            {
                docXml.WriteStartElement("compras");

                foreach (DataRow row in dataCompras.Rows)
                {
                    docXml.WriteStartElement("detalleCompras");
                        docXml.WriteElementString("codSustento", util.formatoNumero(row["codSustento"].ToString(), 2));
                        
                        tipoIdProveedor = util.tipoId(row["tpIdProv"].ToString(), 0);
                        
                        docXml.WriteElementString("tpIdProv", tipoIdProveedor);
                        
                        docXml.WriteElementString("idProv", row["idProv"].ToString());
                        tipoDocSri = util.formatoNumero(row["tipoComprobante"].ToString(),2);
                        docXml.WriteElementString("tipoComprobante", tipoDocSri);

                    // auxiliar para verificar si es pago al extranjero

                        try { numAux = Convert.ToDouble(row["pagoLocExt"].ToString()); }
                        catch { numAux = 1; }
                        string esExtranjero = util.formatoNumero(numAux.ToString(), 2);

                        if (tipoIdProveedor == "03" || tipoIdProveedor == "3")
                        { 
                            docXml.WriteElementString("tipoProv", util.formatoNumero(row["tipoProv"].ToString(), 2));
                        if (fechaInicial.Year * 100 + fechaInicial.Month >= 201605)
                        {
                            RetNombre.AdcNomb prog = new RetNombre.AdcNomb();
                            string Nombre = prog.RetornaNombreDirectorio(row["idProv"].ToString(), SysEmpDatt.datosEmpresa.strConxAdcom);
                            docXml.WriteElementString("denoProv", Nombre.ToString());
                        }
                        }

                        if (tipoIdProveedor == "01" || tipoIdProveedor == "02" || tipoIdProveedor == "03") docXml.WriteElementString("parteRel", util.formatoNumero(row["parteRel"].ToString(), 2));
                        
                        docXml.WriteElementString("fechaRegistro", util.formatoFecha(Convert.ToDateTime(row["fechaRegistro"].ToString())));
                        docXml.WriteElementString("establecimiento", util.formatoNumero(row["establecimiento"].ToString(), 3));
                        docXml.WriteElementString("puntoEmision", util.formatoNumero(row["puntoEmision"].ToString(), 3));
                        docXml.WriteElementString("secuencial", util.formatoNumero(row["secuencial"].ToString(), 9));
                        docXml.WriteElementString("fechaEmision", util.formatoFecha(Convert.ToDateTime(row["fechaEmision"].ToString())));
                        docXml.WriteElementString("autorizacion", util.formatoString (row["autorizacion"].ToString(), 49));
                        docXml.WriteElementString("baseNoGraIva", util.formatoDecimal(Convert.ToDouble(row["baseNoGraIva"].ToString()), 15, 2));
                        docXml.WriteElementString("baseImponible", util.formatoDecimal(Convert.ToDouble(row["baseImponible"].ToString()), 15, 2));
                        docXml.WriteElementString("baseImpGrav", util.formatoDecimal(Convert.ToDouble(row["baseImpGrav"].ToString()), 15, 2));
                        docXml.WriteElementString("baseImpExe", util.formatoDecimal(Convert.ToDouble(row["baseImpExe"].ToString()), 15, 2));
                        docXml.WriteElementString("montoIce", util.formatoDecimal(Convert.ToDouble( row["montoIce"].ToString()), 15, 2));
                        docXml.WriteElementString("montoIva", util.formatoDecimal(Convert.ToDouble( row["montoIva"].ToString()), 15, 2));
                        docXml.WriteElementString("valRetBien10", util.formatoDecimal(Double.Parse(row["valRetBien10"].ToString()), 15, 2));
                        docXml.WriteElementString("valRetServ20", util.formatoDecimal(Convert.ToDouble(row["valRetServ20"].ToString()), 15, 2));                       
                        docXml.WriteElementString("valorRetBienes", util.formatoDecimal(Convert.ToDouble(row["valorRetBienes"].ToString()), 15, 2));
                        docXml.WriteElementString("valRetServ50", util.formatoDecimal(Convert.ToDouble(row["valRetServ50"].ToString()), 15, 2)); docXml.WriteElementString("valorRetServicios", util.formatoDecimal(Convert.ToDouble(row["valorRetServicios"].ToString()), 15, 2));
                        docXml.WriteElementString("valRetServ100", util.formatoDecimal(Convert.ToDouble(row["valRetServ100"].ToString()), 15, 2));

                        double valReembolso=0;
                        try
                        {
                            string strRem = "SELECT sum(isnull(baseImponibleReemb,0) + isnull(baseImpGravReemb,0) + isnull(baseNoGraIvaReemb,0) + isnull(baseImpExeReemb,0)) as totbasesImpReemb ";
                            strRem += " FROM AdcDocReemb";
                            strRem += " where fechaemisionreemb <= '" + row["fechaEmision"].ToString() + "' ";
                            strRem += " and DOC_SUCURSAL = '" + row["SUC"].ToString() + "' and OPC_DOCUMENTO = '" + row["DOC"].ToString() + "' and idclavedoc = " + row["idclavedoc"].ToString();
                            DataTable ree = leerTabla(strRem, conxadc);
                            valReembolso = Convert.ToDouble("0" + ree.Rows[0]["totbasesImpReemb"].ToString());
                            ree.Dispose();
                        }
                        catch {}                            
                        docXml.WriteElementString("totbasesImpReemb", util.formatoDecimal(valReembolso, 15, 2));

                    
                        docXml.WriteStartElement("pagoExterior");

                        if (numAux == 2)
                            {
                                docXml.WriteElementString("pagoLocExt",esExtranjero );
                                string regimenFiscal = util.formatoNumero(row["tipoRegi"].ToString(), 2);
                                docXml.WriteElementString("tipoRegi", regimenFiscal);  // t19
                                docXml.WriteElementString("paisEfecPagoGen", util.formatoString(row["paisEfecPago"].ToString(), 50));
                                docXml.WriteElementString("paisEfecPago", util.formatoString(row["paisEfecPago"].ToString(), 50));
                                docXml.WriteElementString("aplicConvDobTrib", util.formatoString(row["aplicConvDobTrib"].ToString(), 2));
                                docXml.WriteElementString("pagExtSujRetNorLeg", util.formatoString(row["pagExtSujRetNorLeg"].ToString(), 2));
                                if (fechaInicial.Year  * 100 + fechaInicial.Month  < 201605)
                                { docXml.WriteElementString("pagoRegFis", util.formatoString(row["pagoRegFis"].ToString(), 2)); }
                            }
                            else
                            {
                                docXml.WriteElementString("pagoLocExt", util.formatoNumero(numAux.ToString(), 2));
                                docXml.WriteElementString("paisEfecPago", "NA");
                                docXml.WriteElementString("aplicConvDobTrib", "NA");
                                docXml.WriteElementString("pagExtSujRetNorLeg", "NA");
                                if (fechaInicial.Year * 100 + fechaInicial.Month < 201605 || esExtranjero == "02")
                                { docXml.WriteElementString("pagoRegFis", "NA"); }
                            }
                        docXml.WriteEndElement();
                        

                        double totalBas = Convert.ToDouble(row["baseNoGraIva"]) + Convert.ToDouble(row["baseImponible"]) + Convert.ToDouble(row["baseImpGrav"])+Convert.ToDouble(row["baseImpExe"]) + Convert.ToDouble(row["montoIce"])+Convert.ToDouble(row["montoIva"]);

                        if (totalBas >= 1000)
                        {
                            docXml.WriteStartElement("formasDePago");
                            docXml.WriteElementString("formaPago", util.formatoNumero(row["formaPago"].ToString(), 02));
                            docXml.WriteEndElement();
                        }
                        docXml.WriteStartElement("air");
                        if (row["codRetAir"].ToString().Length > 0 && row["codRetAir"].ToString() != "0")
                     // if ((row["codRetAir"].ToString().Length > 0 && Convert.ToDouble(row["valRetAir"].ToString()) > 0) || (row["codRetAir"].ToString() + "   ").Substring(0, 3).Trim() == "332")
                            {
                            docXml.WriteStartElement("detalleAir");
                                docXml.WriteElementString("codRetAir", util.formatoString(row["codRetAir"].ToString(), 5));
                                docXml.WriteElementString("baseImpAir", util.formatoDecimal(Convert.ToDouble(row["baseImpAir"].ToString()), 15, 2));
                                docXml.WriteElementString("porcentajeAir", util.formatoNumero(row["porcentajeAir"].ToString(), 5));
                                docXml.WriteElementString("valRetAir", util.formatoDecimal(Convert.ToDouble(row["valRetAir"].ToString()), 15, 2));

                                if (Convert.ToDouble("0" + row["imRentaSoc"].ToString()) > 0)
                                {
                                    docXml.WriteElementString("fechaPagoDiv", util.formatoFecha(Convert.ToDateTime(row["fechaPagoDiv"].ToString())));
                                    docXml.WriteElementString("imRentaSoc", util.formatoDecimal(Convert.ToDouble(row["imRentaSoc"].ToString()), 15, 2));
                                    docXml.WriteElementString("anioUtDiv", util.formatoNumero(row["anioUtDiv"].ToString(), 4));
                                }
                                if (Convert.ToDouble("0" + row["NumCajBan"].ToString()) > 0)
                                {
                                    docXml.WriteElementString("NumCajBan", util.formatoDecimal(Convert.ToDouble(row["NumCajBan"].ToString()),7,2));
                                    docXml.WriteElementString("PrecCajBan", util.formatoDecimal(Convert.ToDouble(row["PrecCajBan"].ToString()), 2, 2));
                                }
                            docXml.WriteEndElement();
                        }

                        if (row["codRetAir1"].ToString().Length > 0 && row["codRetAir1"].ToString() != "0") //&& Convert.ToDouble(row["valRetAir1"].ToString()) > 0 || row["codRetAir1"].ToString() == "332")
                        {
                            docXml.WriteStartElement("detalleAir");
                                docXml.WriteElementString("codRetAir", util.formatoString (row["codRetAir1"].ToString(),5));
                                docXml.WriteElementString("baseImpAir", util.formatoDecimal(Convert.ToDouble(row["baseImpAir1"].ToString()), 15, 2));
                                docXml.WriteElementString("porcentajeAir", util.formatoNumero(row["porcentajeAir1"].ToString(), 5));
                                docXml.WriteElementString("valRetAir", util.formatoDecimal(Convert.ToDouble(row["valRetAir1"].ToString()), 15, 2));
                                if (Convert.ToDouble("0" + row["imRentaSoc1"].ToString()) > 0)
                                {
                                    docXml.WriteElementString("fechaPagoDiv", util.formatoFecha(Convert.ToDateTime(row["fechaPagoDiv1"].ToString())));
                                    docXml.WriteElementString("imRentaSoc", util.formatoDecimal(Convert.ToDouble(row["imRentaSoc1"].ToString()), 15, 2));
                                    docXml.WriteElementString("anioUtDiv", util.formatoNumero(row["anioUtDiv1"].ToString(), 4));
                                }
                                if (Convert.ToDouble("0" + row["NumCajBan1"].ToString()) > 0)
                                {
                                    docXml.WriteElementString("NumCajBan", util.formatoDecimal(Convert.ToDouble(row["NumCajBan1"].ToString()), 7,2));
                                    docXml.WriteElementString("PrecCajBan", util.formatoDecimal(Convert.ToDouble(row["PrecCajBan1"].ToString()), 2, 2));
                                }
                            docXml.WriteEndElement(); 
                        }

                        if (row["codRetAir2"].ToString().Length > 0 && row["codRetAir2"].ToString() != "0") // && Convert.ToDouble(row["valRetAir2"].ToString()) > 0 || row["codRetAir2"].ToString() == "332")
                        {
                            docXml.WriteStartElement("detalleAir");
                                docXml.WriteElementString("codRetAir", util.formatoString(row["codRetAir2"].ToString(), 5));
                                docXml.WriteElementString("baseImpAir", util.formatoDecimal(Convert.ToDouble(row["baseImpAir2"].ToString()), 15, 2));
                                docXml.WriteElementString("porcentajeAir", util.formatoNumero(row["porcentajeAir2"].ToString(), 5));
                                docXml.WriteElementString("valRetAir", util.formatoDecimal(Convert.ToDouble(row["valRetAir2"].ToString()), 15, 2));
                                if (Convert.ToDouble(row["imRentaSoc2"].ToString()) > 0)
                                {
                                    docXml.WriteElementString("fechaPagoDiv", util.formatoFecha(Convert.ToDateTime(row["fechaPagoDiv2"].ToString())));
                                    docXml.WriteElementString("imRentaSoc", util.formatoDecimal(Convert.ToDouble(row["imRentaSoc2"].ToString()), 15, 2));
                                    docXml.WriteElementString("anioUtDiv", util.formatoNumero(row["anioUtDiv2"].ToString(), 4));
                                }
                                if (Convert.ToDouble(row["NumCajBan2"].ToString()) > 0)
                                {
                                    docXml.WriteElementString("NumCajBan", util.formatoDecimal(Convert.ToDouble(row["NumCajBan2"].ToString()),7, 2));
                                    docXml.WriteElementString("PrecCajBan", util.formatoDecimal(Convert.ToDouble(row["PrecCajBan2"].ToString()), 2, 2));
                                }
                            docXml.WriteEndElement();
                        }
                        if (row["codRetAir3"].ToString().Length > 0 && row["codRetAir3"].ToString() != "0") //&& Convert.ToDouble(row["valRetAir3"].ToString()) > 0 || row["codRetAir3"].ToString() == "332")
                        {
                            docXml.WriteStartElement("detalleAir");
                                docXml.WriteElementString("codRetAir", util.formatoString(row["codRetAir3"].ToString(), 5));
                                docXml.WriteElementString("baseImpAir", util.formatoDecimal(Convert.ToDouble(row["baseImpAir3"].ToString()), 15, 2));
                                docXml.WriteElementString("porcentajeAir", util.formatoNumero(row["porcentajeAir3"].ToString(), 5));
                                docXml.WriteElementString("valRetAir", util.formatoDecimal(Convert.ToDouble(row["valRetAir3"].ToString()), 15, 2));
                                if (Convert.ToDouble(row["imRentaSoc3"].ToString()) > 0)
                                {
                                    docXml.WriteElementString("fechaPagoDiv", util.formatoFecha(Convert.ToDateTime(row["fechaPagoDiv3"].ToString())));
                                    docXml.WriteElementString("imRentaSoc", util.formatoDecimal(Convert.ToDouble(row["imRentaSoc3"].ToString()), 15, 2));
                                    docXml.WriteElementString("anioUtDiv", util.formatoNumero(row["anioUtDiv3"].ToString(), 4));
                                }
                                if (Convert.ToDouble(row["NumCajBan3"].ToString()) > 0)
                                {
                                    docXml.WriteElementString("NumCajBan", util.formatoDecimal(Convert.ToDouble(row["NumCajBan3"].ToString()), 7,2));
                                    docXml.WriteElementString("PrecCajBan", util.formatoDecimal(Convert.ToDouble(row["PrecCajBan3"].ToString()), 2, 2));
                                }
                            docXml.WriteEndElement(); 
                        }
                        docXml.WriteEndElement(); //air
                        if (( row["codRetAir"].ToString() != "" || row["codRetAir1"].ToString() != "" || row["codRetAir2"].ToString() != "" || row["codRetAir3"].ToString() != "") && row["secRetencion1"].ToString() != "")
                        {
                            docXml.WriteElementString("estabRetencion1", util.formatoNumero(row["estabRetencion1"].ToString(), 3));
                            docXml.WriteElementString("ptoEmiRetencion1", util.formatoNumero(row["ptoEmiRetencion1"].ToString(), 3));
                            docXml.WriteElementString("secRetencion1", util.formatoString(row["secRetencion1"].ToString(), 9));
                            docXml.WriteElementString("autRetencion1", util.formatoString(row["autRetencion1"].ToString(), 49));
                            docXml.WriteElementString("fechaEmiRet1", util.formatoFecha(Convert.ToDateTime(row["fechaEmiRet1"].ToString())));
                        }
                    //docXml.WriteEndElement(); //detalle de compras
                        DataTable dtreemb = new DataTable(); //leerTabla(" select sum( from adcdocreemb where doc_sucursal = '" + row["suc"].ToString() + "' and opc_documento = '" + row["doc"].ToString() + "' and idclavedoc = " + row["IdClaveDoc"].ToString(), conxadc);
                    dtreemb = leerTabla(" select * from adcdocreemb where doc_sucursal = '" + row["suc"].ToString() + "' and opc_documento = '" + row["doc"].ToString() + "' and idclavedoc = " + row["IdClaveDoc"].ToString(), conxadc);
                    if (dtreemb.Rows.Count > 0)
                    {
                        docXml.WriteStartElement("reembolsos");
                        foreach (DataRow rowrreemb in dtreemb.Rows)
                        {
                            docXml.WriteStartElement("reembolso");
                                docXml.WriteElementString("tipoComprobanteReemb", util.formatoNumero(rowrreemb["tipoComprobanteReemb"].ToString(), 2));
                                docXml.WriteElementString("tpIdProvReemb", util.formatoNumero(util.tipoId(rowrreemb["tpIdProvReemb"].ToString(),0), 2));
                                docXml.WriteElementString("idProvReemb", rowrreemb["idProvReemb"].ToString());
                                docXml.WriteElementString("establecimientoReemb", util.formatoNumero(rowrreemb["establecimientoReemb"].ToString(), 3));
                                docXml.WriteElementString("puntoEmisionReemb", util.formatoNumero(rowrreemb["puntoEmisionReemb"].ToString(), 3));
                                docXml.WriteElementString("secuencialReemb", util.formatoString(rowrreemb["secuencialReemb"].ToString(), 9));
                                docXml.WriteElementString("fechaEmisionReemb", util.formatoFecha(Convert.ToDateTime(rowrreemb["fechaEmisionReemb"].ToString())));
                                docXml.WriteElementString("autorizacionReemb", util.formatoString(rowrreemb["autorizacionReemb"].ToString(), 49));
                                docXml.WriteElementString("baseImponibleReemb", util.formatoDecimal(Convert.ToDouble("0" + rowrreemb["baseImponibleReemb"].ToString()), 15, 2));
                                docXml.WriteElementString("baseImpGravReemb", util.formatoDecimal(Convert.ToDouble("0" + rowrreemb["baseImpGravReemb"].ToString()), 15, 2));
                                docXml.WriteElementString("baseNoGraIvaReemb", util.formatoDecimal(Convert.ToDouble("0" + rowrreemb["baseNoGraIvaReemb"].ToString()), 15, 2));
                                docXml.WriteElementString("baseImpExeReemb", util.formatoDecimal(Convert.ToDouble("0" + rowrreemb["baseImpExeReemb"].ToString()), 15, 2));
                                docXml.WriteElementString("montoIceRemb", util.formatoDecimal(Convert.ToDouble("0" + rowrreemb["montoIceRemb"].ToString()), 15, 2));
                                docXml.WriteElementString("montoIvaRemb", util.formatoDecimal(Convert.ToDouble("0" + rowrreemb["montoIvaRemb"].ToString()), 15, 2));
                            docXml.WriteEndElement();
                        }
                        docXml.WriteEndElement();
                    }
                    dtreemb.Dispose();
                    if (tipoDocSri == "04" || tipoDocSri == "05" || tipoDocSri == "4" || tipoDocSri == "5")
                    {
                        DataTable dtmodif = leerTabla("ConAplica '" + row["suc"].ToString() + "','" + row["doc"].ToString() + "'," + row["IdClaveDoc"].ToString(), conxadc);
                        if (dtmodif.Rows.Count > 0)
                        {
                            foreach (DataRow rowmodif in dtmodif.Rows)
                            {
                                docXml.WriteElementString("docModificado", util.formatoNumero(rowmodif["docModificado"].ToString(), 2));
                                docXml.WriteElementString("estabModificado", util.formatoNumero(rowmodif["estabModificado"].ToString(), 3));
                                docXml.WriteElementString("ptoEmiModificado", util.formatoNumero(rowmodif["ptoEmiModificado"].ToString(), 3));
                                docXml.WriteElementString("secModificado", util.formatoString(rowmodif["secModificado"].ToString(), 9));
                                docXml.WriteElementString("autModificado", util.formatoString(rowmodif["autModificado"].ToString(), 49));
                            }
                        }
                    }
                docXml.WriteEndElement();  // detalle compras
                }  //foreach compras
                docXml.WriteEndElement();  // compras
                dataCompras.Dispose();
            }

            if (dataVentas.Rows.Count > 0)
            {
                docXml.WriteStartElement("ventas");
                foreach (DataRow row in dataVentas.Rows)
                {
                    tipoDocSri = util.formatoNumero(row["tipoComprobante"].ToString(), 2);
                    docXml.WriteStartElement("detalleVentas");
                    tipoIdProveedor = util.tipoId(row["tpIdCliente"].ToString(), 1);
                    docXml.WriteElementString("tpIdCliente", tipoIdProveedor);
                    docXml.WriteElementString("idCliente", row["idCliente"].ToString());
                    if (tipoIdProveedor == "04" || tipoIdProveedor == "05" || tipoIdProveedor == "06") docXml.WriteElementString("parteRelVtas", util.formatoString(row["parteRelVtas"].ToString(), 2));

                    if (tipoIdProveedor == "06" || tipoIdProveedor == "6")
                    {
                        string tipoCliente = "01";
                        if (row["tipoPersona"].ToString() == "J" || (row["tipoPersona"].ToString() != "01" && row["tipoPersona"].ToString() != "1")) tipoCliente = "02";
                        docXml.WriteElementString("tipoCliente", tipoCliente);
                        docXml.WriteElementString("denoCli", row["nombre"].ToString());
                    }
                    //if (tipoIdProveedor == "03" || tipoIdProveedor == "03")
                    //{
                    //}
                    docXml.WriteElementString("tipoComprobante", util.formatoNumero(tipoDocSri, 2));
                    string tipoEmision = "F";
                    try
                    {
                        if (Convert.ToDouble(row["tipoEmision"]) == 1) tipoEmision = "E";
                    }
                    catch { }

                    docXml.WriteElementString("tipoEmision", tipoEmision);
                    docXml.WriteElementString("numeroComprobantes", util.formatoString(row["numeroComprobantes"].ToString(), 12));
                    docXml.WriteElementString("baseNoGraIva", util.formatoNumero(row["baseNoGraIva"].ToString(), 2));
                    docXml.WriteElementString("baseImponible", util.formatoDecimal(Convert.ToDouble(row["baseImponible"].ToString()), 12, 2));
                    docXml.WriteElementString("baseImpGrav", util.formatoDecimal(Convert.ToDouble(row["baseImpGrav"].ToString()), 12, 2));
                    docXml.WriteElementString("montoIva", util.formatoDecimal(Convert.ToDouble(row["montoIva"].ToString()), 12, 2));
                    // leer compensaciones e imprimir por cada tipo y valor
                    //docXml.WriteStartElement("compensaciones");
                    //    docXml.WriteStartElement("compensacion");
                    //        docXml.WriteElementString("tipoCompe", "");
                    //        docXml.WriteElementString("monto", "0.00");
                    //    docXml.WriteEndElement();
                    //docXml.WriteEndElement();
                    docXml.WriteElementString("montoIce", util.formatoDecimal(Convert.ToDouble(row["montoIce"].ToString()), 12, 2));
                    docXml.WriteElementString("valorRetIva", util.formatoDecimal(Convert.ToDouble(row["valorRetIva"].ToString()), 12, 2));
                    docXml.WriteElementString("valorRetRenta", util.formatoDecimal(Convert.ToDouble(row["valorRetRenta"].ToString()), 12, 2));

                    // leer formas de pago e imprimir 1 line por cada tipo
                    DataTable dataPagVta = leerTabla("DAX_PAGATSVTA " + "'ivaretDax'" + ",'" + row["idCliente"].ToString() + "','" + row["tipoComprobante"].ToString() + "','" + fechaInicial.ToShortDateString () + "'," + fechaFinal.ToShortDateString()+"'", conxadc);

                    if ((tipoDocSri == "18" || tipoDocSri == "05") &&  (fechaInicial.Year * 100 + fechaInicial.Month) > 201605)
                    {
                        docXml.WriteStartElement("formasDePago");
                        if (dataPagVta.Rows.Count > 0)
                        {
                            foreach (DataRow pagrow in dataPagVta.Rows)
                            {
                                docXml.WriteElementString("formaPago", util.formatoNumero(pagrow["formaPago"].ToString(), 2));
                            }
                        }
                        else
                        {
                            docXml.WriteElementString("formaPago", "01");
                        }
                        docXml.WriteEndElement();
                    }

                    docXml.WriteEndElement();  // detalleVentas
                }
                docXml.WriteEndElement();  // ventas
                dataVentas.Dispose();

                double totVenta = 0;
                double ivacom = 0;
                //if (dataResVentas.Rows.Count > 0)
                //{
                    docXml.WriteStartElement("ventasEstablecimiento");

                    foreach (DataRow row in dataResVentas.Rows)
                    {
                        try {totVenta =Convert.ToDouble(row["totVenta"].ToString()); }catch{totVenta=0; }                        
                        try {ivacom =Convert.ToDouble(row["ivaCompensado"].ToString()); }catch{ivacom=0; }                        
                        docXml.WriteStartElement("ventaEst");
                        docXml.WriteElementString("codEstab", util.formatoString(row["idEstab"].ToString(), 3));
                        docXml.WriteElementString("ventasEstab", util.formatoDecimal(totVenta, 12, 2, true));
                        docXml.WriteElementString("ivaComp", util.formatoDecimal(ivacom, 12, 2, true));
                        docXml.WriteEndElement();  // ventas est
                   }
                    docXml.WriteEndElement();  // ventas establecimiento
                //}
                dataResVentas.Dispose();
                dataVentas.Dispose();
            }

            DataTable dataExport = leerTabla("leeOrdenExportacion '" + fechaInicial.ToShortDateString()  + "','" +fechaFinal.ToShortDateString()+"'",conxIva);
            if (dataExport.Rows.Count > 0)
            {
                docXml.WriteStartElement("exportaciones");
                foreach (DataRow rowExp in dataExport.Rows)
                {
                    docXml.WriteStartElement("detalleExportaciones");

                    string tipocliente =util.tipoId(rowExp["tpIdClienteEx"].ToString(), 2);
                    
                    docXml.WriteElementString("tpIdClienteEx", tipocliente);
                    docXml.WriteElementString("idClienteEx", util.formatoString(rowExp["idClienteEx"].ToString(), 13));
                    docXml.WriteElementString("parteRelExp", util.formatoString (rowExp["parteRel"].ToString(), 2));

                    if (tipocliente == "21")
                    {
                        docXml.WriteElementString("tipoCli", util.formatoNumero(rowExp["tipoCli"].ToString(), 2));   // t14
                        docXml.WriteElementString("denoExpCli", rowExp["denoExpCli"].ToString());                    //
                    }
                    string regimenFiscal =util.formatoNumero(rowExp["tipoRegi"].ToString(), 2);
                    docXml.WriteElementString("tipoRegi",regimenFiscal );  // t19


                    if (regimenFiscal == "01") {docXml.WriteElementString("paisEfecPagoGen", util.formatoNumero(rowExp["paisEfecPagoGen"].ToString(), 3)); } // t16
                    if (regimenFiscal == "02") {docXml.WriteElementString("paisEfecPagoParFi", util.formatoNumero(rowExp["paisEfecPagoParFi"].ToString(), 3));}  //                     
                    if (regimenFiscal == "03") 
                    { 
                        docXml.WriteElementString("denopagoRegFis", rowExp["denopagoRegFis"].ToString()); 

                    } //
                   
                    docXml.WriteElementString("paisEfecExp", util.formatoNumero(rowExp["paisEfecExp"].ToString(),3));
                    
                    if (fechaInicial.Year *100 + fechaInicial.Month  < 201605) { docXml.WriteElementString("pagoRegFis", rowExp["pagoRegFis"].ToString()); } //

                    Int32 tipo = Convert.ToInt32(rowExp["exportacionDe"].ToString());
                    docXml.WriteElementString("exportacionDe", util.formatoNumero(tipo.ToString(), 2));
                    docXml.WriteElementString("tipoComprobante", util.formatoNumero(rowExp["tipoComprobante"].ToString(), 2));

                    if (tipo == 1)
                    {
                        //docXml.WriteElementString("ventasEstab", util.formatoDecimal(Convert.ToDouble("0" + row["totVenta"].ToString()), 12, 2));
                        docXml.WriteElementString("distAduanero", util.formatoNumero(rowExp["distAduanero"].ToString(), 3));
                        docXml.WriteElementString("anio", util.formatoString(rowExp["anio"].ToString(), 4));
                        docXml.WriteElementString("regimen", util.formatoString(rowExp["regimen"].ToString(), 2));
                        docXml.WriteElementString("correlativo", util.formatoNumero(rowExp["correlativo"].ToString(), 8));
                        docXml.WriteElementString("docTransp", util.formatoString(rowExp["docTransp"].ToString(), 13));
                    }

                    docXml.WriteElementString("fechaEmbarque", util.formatoFecha(Convert.ToDateTime(rowExp["fechaEmbarque"].ToString())));
                    docXml.WriteElementString("valorFOB", util.formatoDecimal(Convert.ToDouble(rowExp["valorFOB"].ToString()), 15, 2));
                    docXml.WriteElementString("valorFOBComprobante", util.formatoDecimal(Convert.ToDouble(rowExp["valorFOBComprobante"].ToString()), 15, 2));
                    docXml.WriteElementString("establecimiento", util.formatoNumero(rowExp["establecimiento"].ToString(), 3));
                    docXml.WriteElementString("puntoEmision", util.formatoNumero(rowExp["puntoEmision"].ToString(), 3));
                    docXml.WriteElementString("secuencial", util.formatoString(rowExp["secuencial"].ToString(), 9));
                    docXml.WriteElementString("autorizacion", util.formatoString(rowExp["autorizacion"].ToString(), 49));
                    docXml.WriteElementString("fechaEmision", util.formatoFecha(Convert.ToDateTime(rowExp["fechaEmision"].ToString())));

                    docXml.WriteEndElement();  // detalleExportaciones
                }
                docXml.WriteEndElement();  // exportaciones
            }
            dataExport.Dispose();            

            DataTable dataAnula = leerTabla("leeOrdenAnulados '" + fechaInicial.ToShortDateString() + "','" + fechaFinal.ToShortDateString() + "'", conxIva);
            if (dataAnula.Rows.Count > 0) 
            {
                docXml.WriteStartElement("anulados");
                foreach (DataRow row in dataAnula.Rows)
                {
                    docXml.WriteStartElement("detalleAnulados");
                        docXml.WriteElementString("tipoComprobante", util.formatoNumero(row["tipoComprobante"].ToString(), 2));
                        docXml.WriteElementString("establecimiento", util.formatoNumero(row["establecimiento"].ToString(), 3));
                        docXml.WriteElementString("puntoEmision", util.formatoNumero(row["emision"].ToString(), 3));
                        docXml.WriteElementString("secuencialInicio", util.formatoString(row["secuencialInicio"].ToString(), 9));
                        docXml.WriteElementString("secuencialFin", util.formatoString(row["secuencialFin"].ToString(), 9));
                    docXml.WriteElementString("autorizacion", util.formatoString(row["autorizacion"].ToString(), 49));

                    docXml.WriteEndElement();  // detalleAnuados
                }
                docXml.WriteEndElement();  // Anulados
            }
            dataAnula.Dispose();


            docXml.WriteEndDocument();
            docXml.Flush();
            docXml.Close();
            atsValXml verificador = new atsValXml ();
            dataExport.Dispose();
            return (verificador.Main(pathfile, pathSys + "XML\\SRI\\at.xsd"));
        }
        private DataTable leerTabla(string ssql, string conx)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(ssql, conx))
            {
                try
                {
                    da.Fill(dt);
                    da.Dispose();
                }
                catch { }
            }
            return dt;
        }
    }
}
