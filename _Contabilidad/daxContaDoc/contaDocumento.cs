using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ClassDoc;
using DattCom;
using DaxComercia;
namespace daxContaDoc
{
    
    public class contabilizaDocumento
    {
        AdcDoc idDoc = new AdcDoc();
        sesSys.OpcDoc opcDcto;
        daxConta.reglCtb verCta = new daxConta.reglCtb();
        AsientosContables mallacontable = new AsientosContables();
        string QueDetalle = "";
        
        public AsientosContables  GenerarContabilidadDocumento(AdcDoc DatosDocto, DataTable mallaItemsDocumento, sesSys.OpcDoc opcDoc = null, classPagosDoc pagosDocto = null, string queDetalle = "")
        {
            idDoc = DatosDocto;
            opcDcto = opcDoc;
            switch (DatosDocto.Doc_TipoDoc.ToUpper())
            {
                case "EGR":
                case "ING":
                case "NDB":
                case "NCB":
                    contabilizarBancos(mallaItemsDocumento, pagosDocto);
                    break;
                case "EBG":
                case "IBG":
                case "TRF":
                case "AJE":
                case "AJI":
                    contabilizarInventario(mallaItemsDocumento, pagosDocto);
                    break;
                case "RTC":
                case "RTP":
                    contabilizarRetenciones(mallaItemsDocumento);
                    break;
                default:
                    contabilizarFac(mallaItemsDocumento, pagosDocto);
                    break;                
            }
            return mallacontable;
        }
        private void contabilizarInventario(DataTable mallaItemsDocumento, DaxComercia.classPagosDoc pagosDocto)
        {
            string detalle = "Doc.:  " + idDoc.Doc_sucursal + "-" + idDoc.Opc_documento + "-" + idDoc.Doc_numero + "-" + idDoc.Doc_CiRuc;
            if (mallaItemsDocumento == null) return;
            foreach (DataRow row in mallaItemsDocumento.Rows)
            {
                detalle = "Doc.:  " + idDoc.Doc_sucursal + "-" + idDoc.Opc_documento + "-" + idDoc.Doc_numero + "-" + idDoc.Doc_CiRuc + "-" + "Cod.:  " + row["tra_Codigo"].ToString();
                armarLineaContableIndividual(row, opcDcto.ctadebe, Convert.ToDecimal("0" + row["tra_CostTot"].ToString()), detalle, row["tra_Codigo"].ToString(), "", null, true);                                                          // total costo de articulos
                armarLineaContableIndividual(row, opcDcto.ctahaber, Convert.ToDecimal("0" + row["tra_CostTot"].ToString()), detalle, row["tra_Codigo"].ToString(), "", null);
            }
        }

        private void contabilizarBancos(DataTable mallaItemsDocumento, classPagosDoc pagosDocto)
        {
            string detalle = "Doc.:  " + idDoc.Doc_sucursal + "-" + idDoc.Opc_documento + "-" + idDoc.Doc_numero + "-" + idDoc.Doc_CiRuc;
            armarLineaContableTotales(opcDcto.ctadebe, idDoc.Doc_valor, detalle, null, true);  // valor total del documento            
            armarLineaContableTotales(opcDcto.ctahaber, idDoc.Doc_valor, detalle, null, false);  // valor total del documento            
            if (mallaItemsDocumento == null) return;
            foreach (DataRow row in mallaItemsDocumento.Rows)
            {
                detalle = "Doc.:  " + idDoc.Doc_sucursal + "-" + idDoc.Opc_documento + "-" + idDoc.Doc_numero + "-" + idDoc.Doc_CiRuc + "-" + "Cod.:  " + row["Codconcepto"].ToString();
                armarLineaContableIndividual(row, opcDcto.VarCtaRetBieD, Convert.ToDecimal("0"+row["Apl_valorapl"].ToString()), detalle,row["CodConcepto"].ToString(), "", null, true);             
                armarLineaContableIndividual(row, opcDcto.VarCtaRetBieH, Convert.ToDecimal("0"+row["Apl_valorapl"].ToString()), detalle,row["CodConcepto"].ToString(), "", null);
            }
        }
        private void contabilizarFac(DataTable mallaItemsDocumento,  classPagosDoc pagosDocto)
        {
            string detalle = "Doc.:  " + idDoc.Doc_sucursal + "-" + idDoc.Opc_documento + "-" + idDoc.Doc_numero + "-" + idDoc.Doc_CiRuc;
            if (opcDcto.ctadebe.ToUpper() == "&PAGOS") { contabilizaFormaPago(opcDcto.ctadebe, pagosDocto, true); }
            else
            {
                pagoDoc Pag = new pagoDoc();
                armarLineaContableTotales(opcDcto.ctadebe, idDoc.Doc_valor, detalle, Pag, true);  // valor total del documento
            }
            if (opcDcto.ctahaber.ToUpper() == "&PAGOS" || opcDcto.ctahaber.ToUpper() == "&PAGOS2") { contabilizaFormaPago(opcDcto.ctahaber, pagosDocto, false); }
            else
            {
                pagoDoc Pag = new pagoDoc();
                armarLineaContableTotales(opcDcto.ctahaber, idDoc.Doc_valor, detalle, Pag, false);  // valor total del documento
            }

            armarLineaContableTotales(opcDcto.CtaTotDescInvD, idDoc.Doc_valoriva, detalle,null, true);                                                //total iva
            armarLineaContableTotales(opcDcto.CtaTotDescInvH, idDoc.Doc_valoriva, detalle, null);

            armarLineaContableTotales(opcDcto.CtaIvaD, idDoc.Doc_TotDesArt, detalle, null, true);                                                                       // descuento en articulos
            armarLineaContableTotales(opcDcto.CtaIvaH, idDoc.Doc_TotDesArt, detalle, null);

            armarLineaContableTotales(opcDcto.CtaOSinIvaD.ToString(), idDoc.Doc_TotDesSer, detalle, null, true);                                            // descuentos servicios
            armarLineaContableTotales(opcDcto.CtaOSinIvaH, idDoc.Doc_TotDesSer, detalle, null);
            string CodigoLinea = "";
            if (mallaItemsDocumento != null) foreach (DataRow row in mallaItemsDocumento.Rows)
                {
                    CodigoLinea = row["Tra_codigo"].ToString();
                    detalle = "Doc.:  " + idDoc.Doc_sucursal + "-" + idDoc.Opc_documento + "-" + idDoc.Doc_numero + "-" + idDoc.Doc_CiRuc + "-" + "Cod.:  " + CodigoLinea;
                    if (row["tra_queTipo"].ToString() == "A")
                    {
                        armarLineaContableIndividual(row, opcDcto.CtaValVtaInvD, Convert.ToDecimal(row["tra_precTot"].ToString()), detalle, CodigoLinea, "", null, true);              // venta articulos 
                        armarLineaContableIndividual(row, opcDcto.CtaValVtaInvH, Convert.ToDecimal(row["tra_precTot"].ToString()), detalle, CodigoLinea, "", null);

                        armarLineaContableIndividual(row, opcDcto.VarCtaCostoD, Convert.ToDecimal("0"+row["tra_CostTot"].ToString()), detalle, CodigoLinea, "", null, true);                                                          // total costo de articulos
                        armarLineaContableIndividual(row, opcDcto.VarCtaCostoH, Convert.ToDecimal("0"+row["tra_CostTot"].ToString()), detalle, CodigoLinea, "", null);
                    }
                    else if (row["tra_queTipo"].ToString() == "S")
                    {
                        armarLineaContableIndividual(row, opcDcto.CtaSubTConIvaD, Convert.ToDecimal("0" + row["tra_precTot"].ToString()), detalle, CodigoLinea, "", null, true);          // venta servicios
                        armarLineaContableIndividual(row, opcDcto.CtaSubTConIvaH, Convert.ToDecimal("0" + row["tra_precTot"].ToString()), detalle, CodigoLinea, "", null);
                    }
                    else if (row["tra_queTipo"].ToString() == "F")
                    {
                        armarLineaContableIndividual(row, opcDcto.CtaValNetoD, Convert.ToDecimal("0" + row["tra_precTot"].ToString()), detalle, CodigoLinea, "", null, true);                                                                   //total venta de activos fijos
                        armarLineaContableIndividual(row, opcDcto.CtaValNetoH, Convert.ToDecimal("0" + row["tra_precTot"].ToString()), detalle, CodigoLinea, "", null);
                    }
                }
        }
        private void contabilizarRetenciones(DataTable mallaItemsRetenciones)
        {
            string detalle = "Doc.:  " + idDoc.Doc_sucursal + "-" + idDoc.Opc_documento + "-" + idDoc.Doc_numero + "-" + idDoc.Doc_CiRuc;
            armarLineaContableTotales(opcDcto.ctadebe, idDoc.Doc_valor, detalle, null, true);  // valor total del documento            
            armarLineaContableTotales(opcDcto.ctahaber, idDoc.Doc_valor, detalle, null, false);  // valor total del documento            
            if (mallaItemsRetenciones == null) return;
            foreach (DataRow row in mallaItemsRetenciones.Rows)
            {
                detalle = "Doc.:  " + idDoc.Doc_sucursal + "-" + idDoc.Opc_documento + "-" + idDoc.Doc_numero + "-" + idDoc.Doc_CiRuc + "-" + "Cod.:  " + row["CodigoRetencion"].ToString();
                armarLineaContableIndividual(row, opcDcto.VarCtaRetBieD, Convert.ToDecimal("0" + row["ValorRetencion"].ToString()), detalle,"", row["CodigoRetencion"].ToString(), null, true);
                armarLineaContableIndividual(row, opcDcto.VarCtaRetBieH, Convert.ToDecimal("0" + row["ValorRetencion"].ToString()), detalle,"", row["CodigoRetencion"].ToString(), null);
            }
        }
            private void contabilizaFormaPago( string codCuenta, classPagosDoc pagosDocmto, Boolean esDebe=false )
        {
            if (pagosDocmto == null) return;
            foreach  (pagoDoc elPago in pagosDocmto.pagosDelDocumento )
            {
                string codigoCuenta = verCta.VerificarComodines( codCuenta,idDoc.Doc_sucursal,idDoc.Doc_codper,idDoc.doc_BancoOrigen,"",idDoc.doc_BancoDestino ,"","","","", elPago.IdFormaDePago);
                string detalle = QueDetalle;
                if (QueDetalle == "")
                {
                    detalle = "Doc.:  " + idDoc.Doc_sucursal + "-" + idDoc.Opc_documento + "-" + idDoc.Doc_numero + "- " + idDoc.Doc_CiRuc + "- " +  "F.Pag: " + elPago.IdFormaDePago ;
                }
                armarLineaContableTotales(codigoCuenta, Convert.ToDecimal(elPago.Valor),detalle ,elPago  ,esDebe,false);
            }
        }
        private void armarLineaContableTotales(string cuenta, decimal valor, string detalle,  pagoDoc elPago, Boolean esDebito = false, Boolean verificar = true)
        {
            if (valor == 0 || cuenta == "") return;
            string ctaCosto = "";
            string codigoCuenta = cuenta;
            if (elPago == null) elPago = new pagoDoc();
            if (verificar) codigoCuenta = verCta.VerificarComodines(codigoCuenta , idDoc.Doc_sucursal,idDoc.PuntoVta,idDoc.Doc_codper, idDoc.doc_BancoOrigen, "", idDoc.doc_BancoDestino, "", "", "", "", elPago.IdFormaDePago);


            daxContaDoc.DetalleContab row = new DetalleContab()
            {
                codCta = codigoCuenta,
                DetalleAsiento = detalle,
                nombreCta = BuscarCta(codigoCuenta, datosEmpresa.strConxAdcom, ref ctaCosto)
            };
            if (esDebito) row.ValDebe  = Convert.ToDouble(valor);
            else row.ValHaber = Convert.ToDouble(valor);
            mallacontable.ListDetalleContab.Add(row);
        }    
        private void armarLineaContableIndividual(DataRow rowArt, string cuenta, decimal valor,string detalle,string CodArtServ,string CodSRI, pagoDoc  elPago,Boolean  esDebito = false,Boolean verifica = true)
        {
            if (valor == 0 || cuenta == "") return;
            string ctaCosto = "";
            string codigoCuenta = cuenta;
            if (elPago == null ) elPago=new DaxComercia.pagoDoc();
            if (verifica == true) codigoCuenta = verCta.VerificarComodines(cuenta, idDoc.Doc_sucursal,idDoc.PuntoVta, idDoc.Doc_codper, idDoc.doc_BancoOrigen,CodArtServ, idDoc.doc_BancoDestino,"","", "", CodSRI, elPago.IdFormaDePago);

            daxContaDoc.DetalleContab rowCtb = new DetalleContab()
            {
                codCta = codigoCuenta,
                DetalleAsiento = detalle,
                nombreCta = BuscarCta(codigoCuenta, datosEmpresa.strConxAdcom, ref ctaCosto)
            };
            detalle = QueDetalle;
            if (QueDetalle == "")
            {
                rowCtb.DetalleAsiento = "Doc.: " + idDoc.Doc_sucursal + "-" + idDoc.Opc_documento + "-" + idDoc.Doc_numero + "- " + idDoc.Doc_CiRuc + "- " + "Art/Con:  " + CodArtServ;
            }

            if (esDebito) rowCtb.ValDebe = Convert.ToDouble(valor);
            else rowCtb.ValHaber = Convert.ToDouble(valor);
            mallacontable.ListDetalleContab.Add(rowCtb);
           if (opcDcto.TipoDoc != "RTC" && opcDcto.TipoDoc != "RTP") registraClasificadoresContables(codigoCuenta, rowArt, rowCtb);
            //if (EsClasificador(codigoCuenta, "Directorio", rowArt.Cells["Directorio"].ToString())) rowCtb.Cells["Directorio"].Value = rowArt.Cells["Directorio"];
        }
        private void registraClasificadoresContables(string codigoCuenta, DataRow rowArt,DetalleContab rowCtb)
        {
            //ssql += "tra_costo, tra_centroproduccion, tra_centrodistribucion, tra_empleado,Tra_Proyecto, tra_directorio, ";
            if (EsClasificador(codigoCuenta, "Centro Costo", rowArt["tra_costo"].ToString())) rowCtb.CentCosto = rowArt["tra_costo"].ToString();
            if (EsClasificador(codigoCuenta, "Empleado", rowArt["tra_empleado"].ToString())) rowCtb.Empleado = rowArt["tra_empleado"].ToString();
            if (EsClasificador(codigoCuenta, "Proyecto", rowArt["tra_Proyecto"].ToString())) rowCtb.Proyecto = rowArt["tra_Proyecto"].ToString();
            if (EsClasificador(codigoCuenta, "Centro Producción", rowArt["tra_centroproduccion"].ToString())) rowCtb.CentProd = rowArt["tra_centroproduccion"].ToString();
            if (EsClasificador(codigoCuenta, "Centro Distribución", rowArt["tra_centrodistribucion"].ToString())) rowCtb.CentDistr = rowArt["tra_centrodistribucion"].ToString();

            //if (EsClasificador(codigoCuenta, "Centro Costo", rowArt["CentCosto"].ToString())) rowCtb.CentCosto = rowArt["CentCosto"].ToString();
            //if (EsClasificador(codigoCuenta, "Empleado", rowArt["Empleado"].ToString())) rowCtb.Empleado = rowArt["Empleado"].ToString();
            //if (EsClasificador(codigoCuenta, "Proyecto", rowArt["Proyecto"].ToString())) rowCtb.Proyecto = rowArt["Proyecto"].ToString();
            //if (EsClasificador(codigoCuenta, "Centro Producción", rowArt["CentProd"].ToString())) rowCtb.CentProd = rowArt["CentProd"].ToString();
            //if (EsClasificador(codigoCuenta, "Centro Distribución", rowArt["CentDistr"].ToString())) rowCtb.CentDistr = rowArt["CentDistr"].ToString();
        }
        private Boolean EsClasificador(string Cuenta, string clasificador, string ValClasificador = "")
        {
            if (Cuenta == "" || (clasificador == "" && ValClasificador == "")) return false;
            DataTable rs = new DataTable();
            SqlDataAdapter da;
            string ssql = "";
            if (clasificador == "" && ValClasificador != "")
            {
                ssql = "select isnull(tiporeferencia,'') as Clasificad from syscod left join AdcClasfctb";
                ssql += " on syscod.TipoReferencia = adcclasfctb.nombre";
                ssql += " where (abreviación = '" + ValClasificador + "' or descripcion = '" + ValClasificador + "') and esclasificador =1";              
                da = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom);
                da.Fill(rs);
                if (rs.Rows.Count > 0) { clasificador = rs.Rows[0]["Clasificad"].ToString(); }
            }
            if (clasificador == "") return false;
             rs = new DataTable();
            ssql = "select clasificadores from adccta where clasificadores like '%" + clasificador + "%' and CTA_CODIGO = '" + Cuenta + "' ";
            da = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom);
            da.Fill(rs);
            Boolean a = (rs.Rows.Count >0);
            //if (rs.Rows[0]["Clasificadores"].ToString() != "") a = rs.Rows[0]["Clasificadores"].ToString().Contains(clasificador);    // InStr(1, rs!Clasificadores, clasificador)
            rs.Dispose();
            da.Dispose();
            return a;
}

        public void arreglarMallaCtb(DataGridView mallactb)
        {

            string formato = "#,#0.00;-#,#0.00;\"\";";
            mallactb.Columns["Cta_codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            mallactb.Columns["Dia_ctanombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            mallactb.Columns["Dia_detalle"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            mallactb.Columns["ValDebe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            mallactb.Columns["ValHaber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            mallactb.Columns["ValDebe"].DefaultCellStyle.Format = formato ;
            mallactb.Columns["ValHaber"].DefaultCellStyle.Format = formato;

            mallactb.Columns["Dia_costo"].Visible = false;
            mallactb.Columns["Dia_Empleado"].Visible = false;
            mallactb.Columns["Dia_Proyecto"].Visible = false;
            mallactb.Columns["Dia_CentroProduccion"].Visible = false;
            mallactb.Columns["Dia_CentroDistribucion"].Visible = false;
            mallactb.Columns["Dia_Departamento"].Visible = false;
            mallactb.Columns["Dia_Zona"].Visible = false;

            mallactb.Columns["Cta_codigo"].HeaderText = "CtaContable";
            mallactb.Columns["Dia_ctanombre"].HeaderText = "Nombre de la cuenta";
            mallactb.Columns["Dia_detalle"].HeaderText = "Detalle del asiento"; ;

            mallactb.Columns["Dia_costo"].HeaderText = "CentCosto";
            mallactb.Columns["Dia_Empleado"].HeaderText = "Empleado";
            mallactb.Columns["Dia_Proyecto"].HeaderText = "Proyecto";
            mallactb.Columns["Dia_CentroProduccion"].HeaderText = "CentProducción";
            mallactb.Columns["Dia_CentroDistribucion"].HeaderText = "CentDistribución";
            mallactb.Columns["Dia_Departamento"].HeaderText = "Departamento";
            mallactb.Columns["Dia_Zona"].HeaderText = "Zona";
        }
        private decimal totalCostoArticulos(DataTable adctra, idDocumento idDoc,string strConxAdcom)
      {
            if (adctra == null) return 0;
            decimal costo = 0;
            foreach (DataRow row in adctra.Rows)
            {
                costo += Convert.ToDecimal(row["Tra_costottot"]);
            }
            return costo;
        }
        private string BuscarCta(string CtaCtb, string strConxAdcom, ref string CtaCosto)
        {
            CtaCosto = "";
            string ssql = "SELECT ISNULL(CTA_NOMBRE,'') AS CTA_NOMBRE,ISNULL(CLASIFICADORES,'') AS CLASIFICADORES FROM AdcCta WHERE Cta_Codigo='" + CtaCtb + "' and cta_agrupacion = 0 ";
            using (SqlDataAdapter da = new SqlDataAdapter(ssql, strConxAdcom))
            {
                using (DataTable rs = new DataTable())
                {
                    da.Fill(rs);
                    if (rs.Rows.Count == 0) return "No existe la cuenta";
                    CtaCosto = rs.Rows[0]["Clasificadores"].ToString();
                    return rs.Rows[0]["CTA_NOMBRE"].ToString();
                }
            }
        }
       // }
        //private void iniciaValoresParaAsientos(decimal[] Valor, DctosEmi.AdcDoc datosDocumento, DataTable  mallaart,DctosEmi.idDocumento idDoc,string strConxAdcom)
        //    {
        //        Valor[1] = Math.Round(datosDocumento.Doc_valor, 2); // valor del documento
        //        Valor[2] = Math.Round(datosDocumento.Doc_TotArtCIva + datosDocumento.Doc_TotArtSIva, 2); // venta articulos
        //        Valor[3] = 0; //Math.Round(VtaArtSIva, 2) //valor del cruce del documento
        //        Valor[4] = Math.Round(totalCostoArticulos(mallaart, idDoc, strConxAdcom)); // costo articulo
        //        Valor[5] = Math.Round(datosDocumento.Doc_TotDesArt, 2); // descuento articulo
        //        Valor[6] = Math.Round(datosDocumento.Doc_TotSerCIva + datosDocumento.Doc_TotSerSIva, 2); //venta serv con iva
        //        Valor[7] = 0; //Math.Round(VtaOtrSIva, 2) // libre
        //        Valor[8] = Math.Round(datosDocumento.Doc_TotDesSer, 2); //descuento de servicios
        //        Valor[9] = Math.Round(datosDocumento.Doc_TotAcf, 2); //activo fijo
        //        Valor[10] = Math.Round(datosDocumento.Doc_valoriva, 2); // valor del iva
        //        Valor[11] = 0; // Math.Round(ValCtaRetBie, 2) // retencion de bieneas
        //        Valor[12] = 0; //Math.Round(ValCtaRetSer, 2) // retencion de servicios
        //        Valor[13] = 0; //Math.Round(ValCtaRetFte, 2) // retencion en la fuente
        //    }
        //private void iniciaCamposDeContabilizacionIndividual(string TipoPadre, Boolean[] Individual)
        //{
        //    for (int i = 1; i < 16; i++)
        //    {
        //        Individual[i] = false;
        //    }
        //    if (TipoPadre == "EBG" || TipoPadre == "IBG" || TipoPadre == "TRF" || TipoPadre == "AJE" || TipoPadre == "AJI") Individual[1] = true;
        //    Individual[2] = true;
        //    //        Individual[3] = True
        //    Individual[4] = true;
        //    Individual[5] = true;
        //    Individual[6] = true;
        //    //        //Individual[7] = op.SNOtSinIva
        //    Individual[8] = true;
        //}
        //private void iniciaCtasContablesDefinidasEnDocumentos(string[] CtasD,string[] CtasH, sesSys.OpcDoc op, int[] CtaCuadre)
        //{
        //    CtasD[1] = op.ctadebe; // valor doc
        //    CtasH[1] = op.ctahaber;
        //    CtasD[2] = op.CtaValVtaInvD; // venta articulo con iva
        //    CtasH[2] = op.CtaValVtaInvH;
        //    CtasD[3] = op.CtaVtaOIvaD; //venta art sin iva CtaSubTConIvaD antes ahora->Valor de las aplicaciones del documento
        //    CtasH[3] = op.CtaVtaOIvaH;
        //    CtasD[4] = op.VarCtaCostoD; // costo articulo
        //    CtasH[4] = op.VarCtaCostoH;
        //    CtasD[5] = op.CtaIvaD; // descuento articulo
        //    CtasH[5] = op.CtaIvaH;
        //    CtasD[6] = op.CtaSubTConIvaD; //venta serv con iva
        //    CtasH[6] = op.CtaSubTConIvaH;
        //    CtasD[7] = op.CtaValDescD; // venta servicios sin iva  antes, ahora libre CtaOSinIvaD
        //    CtasH[7] = op.CtaValDescH;
        //    CtasD[8] = op.CtaOSinIvaD.ToString(); //descuento de servicios
        //    CtasH[8] = op.CtaOSinIvaH;
        //    CtasD[9] = op.CtaValNetoD; //activo fijo
        //    CtasH[9] = op.CtaValNetoH;
        //    CtasD[10] = op.CtaTotDescInvD; // valor del iva
        //    CtasH[10] = op.CtaTotDescInvH;
        //    CtasD[11] = op.VarCtaRetBieD; // retencion de bieneas y  conceptos de bancos
        //    CtasH[11] = op.VarCtaRetBieH;
        //    CtasD[12] = op.VarCtaRetSerD; // retencion de servicios
        //    CtasH[12] = op.VarCtaRetSerH;
        //    CtasD[13] = op.VarCtaRetFteD; // retencion en la fuente
        //    CtasH[13] = op.VarCtaRetFteH;

        //    CtaCuadre[1] = op.Opc_ctaCuadre;
        //    CtaCuadre[2] = op.Opc_ctavalvtainvCuadre; // venta articulo con iva
        //    CtaCuadre[3] = op.Opc_ctavtaoivaCuadre; //venta art sin iva CtaSubTConIvacuadreantes ahora->Valor de las aplicaciones del documento
        //    CtaCuadre[4] = op.Opc_CtaCostoCuadre; // costo articulo
        //    CtaCuadre[5] = op.Opc_ctaivaCuadre; // descuento articulo
        //    CtaCuadre[6] = op.Opc_ctasubtcivaCuadre; //venta serv con iva
        //    //   CtaCuadre[7] = op.opc_CtaVaDesccuadre; // venta servicios sin iva  antes, ahora libre CtaOSinIvaD
        //    CtaCuadre[8] = op.Opc_ctaotrosivaCuadre; //descuento de servicios
        //    CtaCuadre[9] = op.Opc_ctavalnetoCuadre; //activo fijo
        //    CtaCuadre[10] = op.Opc_ctatotdesindiCuadre; // valor del iva
        //    CtaCuadre[11] = op.Opc_CtaRetBieCuadre;
        //    CtaCuadre[12] = op.Opc_CtaRetSerCuadre;
        //    CtaCuadre[13] = op.Opc_CtaRetFteCuadre;
        //}
    }
}
//public Boolean CargarMallaContableAnt(string strConxAdcom, DataGridView mallactb, DctosEmi.idDocumento idDoc, sesSys.OpcDoc op, DctosEmi.AdcDoc datosDocumento, DataTable mallaart, DataTable datosSri, classPagosDoc ElPago, string Detalle,string Beneficiario)
//    {
//        MantCtb.BuscaCta buscarCta = new MantCtb.BuscaCta();
//        decimal[] Valor = new decimal[15];
//        Boolean[] Individual = new Boolean[20];
//        int[] CtaCuadre = new int[30];
//        string[] CtasD = new string[15];
//        string[] CtasH = new string[15];
//        int[] CualCuadra = new int[30];
//        int cont;
//        string CtaCtb = "";
//        string CuentaLista = "";
//        double ValorLis = 0;
//        //		Dim Jini, H, j, Jfin As Short
//        string BancoD = "";
//        string QueDetalle = "";
//        //		Dim NoEsta As Short
//        //		Dim Tipo As New VB6.FixedLengthString(1)
//        //		Dim Siva As Boolean
//        string TipoPadre = "";
//        //, CodPag As String
//        //		Dim ValorPag As Double
//        //		Dim PG As Short
//        //		Dim Aumento As Short
//        int CtaIni = 1;
//        int CtaFin = 13;
//        DataTable rs = new DataTable();
//        string SiCosto = "";
//        //		Dim Valorcosto As Double
//        //		Dim ValorDocto As Double
//        //		Dim k As Short

//        if (mallaart == null) return false;
//        //		If IsNothing(BancoFin) Then BancoD = "" Else BancoD = BancoFin

//        QueDetalle = Detalle;
//        //		//   If IsMissing(ColIva) Or ColIva = 0 Then ColIva = 9
//        //		op.Cargar(Doc)

//        iniciaValoresParaAsientos(Valor,datosDocumento,mallaart,idDoc,strConxAdcom);
//        TipoPadre = op.Extenciones.Substring(1, 3);
//        iniciaCamposDeContabilizacionIndividual(TipoPadre, Individual);
//        iniciaCtasContablesDefinidasEnDocumentos(CtasD, CtasH, op, CtaCuadre);

//        if (TipoPadre == "EGR" || TipoPadre == "ING" || TipoPadre == "NCB" || TipoPadre == "NDB")
//        {
//            Individual[11] = true;
//            Valor[11] = 1;
//        }

//        daxConta.reglCtb verComodines = new daxConta.reglCtb();
//        decimal TotDebito = 0;
//        decimal TotCredito = 0;
//        decimal Ajuste = 0;
//        decimal Diferencia = 0;
//        int ColPrior = 0;
//        int prioridad = 0;
//        decimal ValorPag=0;
//        string CodPag = "";
//        string siCosto = "";
//        //		With mallactb

//        //			Aumento = IIf(.FixedRows = 0, 1, 0)
//        //			.Rows = 2 - Aumento
//        //			If .Cols < 52 Then .Cols = 52
//        //			If ColVal <> 0 Then
//        //				For k = 26 To 50
//        //					.TextMatrix(0, k) = mallaart.TextMatrix(0, k)
//        //					.ColWidth(k) = 0
//        //				Next k
//        //			End If
//        //			If .Rows > 1 Then
//        //				For i = .FixedCols To .Cols - 1
//        //					.TextMatrix(1, i) = ""
//        //				Next i
//        //			End If
//        //			cont = .FixedRows
//        int H = 0;
//        for (int i = CtaIni; i <= CtaFin; i++)
//        {
//            if (Individual[i] == false)
//            {
//                CtaCtb = CtasD[i];
//                H = 0;
//                do
//                {
//                    if (Valor[i] != 0 && CtaCtb != "")
//                    {
//                        if ((CtaCtb + "      ").Substring(2, 5).ToUpper() == "PAGOS")
//                        {
//                            // contabilizar pagos
//                            	if ( ElPago != null )
//                                {
//                                    if (ElPago.pagosDelDocumento.Count > 0)
//                                        {
//                                            for ( int PG = 1;i <= ElPago.pagosDelDocumento.Count)
//                                            {
//                                                pagoDoc UnPago = ElPago.pagosDelDocumento[PG];
//                                                ValorPag =Convert.ToDecimal( UnPago.Valor);
//                                                CodPag = UnPago.IdFormaDePago;
//                                                if (CodPag != "")
//                                                {
//                                                    mallactb.Rows.Add();
//                                                    cont = mallactb.Rows.Count - 1;
//                                                    DataGridViewRow row = mallactb.Rows[cont];
//                                                    row.Cells["Lin"].Value = row.Index;
//                                                    CuentaLista = verComodines.VerificarClasificadoresContablesServicios(CodPag, idDoc.Sucursal, datosDocumento.Doc_codper,mallactb , "", BancoD, CXP, CodDes);
//                                                    row.Cells["1"].Value = CuentaLista;
//                                                    row.Cells["2"].Value = BuscarCta(CuentaLista, strConxAdcom, ref SiCosto);
//                                                    if (QueDetalle != "") row.Cells["3"].Value = "Contabilización " + idDoc.Tipo + " " + idDoc.numero + " - " + Beneficiario;

//                                                    row.Cells[4 + H].Value = System.Math.Round(ValorPag, 2);
//                                                    row.Cells["5 - H"].Value = "";
//                                                    // ReDim Preserve CualCuadra(cont + 1)
//                                                    CualCuadra[cont] = CtaCuadre[i];
//                                                }
//                                            } //										Next PG
//                                }//									End If                                                            
//                            else
//                              {
//                                    //									rs = New ADODB.Recordset
//                                    //									rs.Open("SELECT * FROM adcpag where doc_sucursal = //" & Sucursal & "// and opc_documento = //" & Doc & "// and idclavedoc = " & IdClaveDoc, ConxAdcom, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
//                                    {//									If rs.EOF = False Then
//                                        {//										Do Until rs.EOF
//                                         //											ValorPag = rs.Fields("Pag_Valor").Value
//                                         //											CodPag = LeerPago(rs.Fields("Pag_Idpago").Value)
//                                            {//											If CodPag > "" Then
//                                             //												.Rows = cont + 1
//                                             //												.TextMatrix(cont, 0) = cont + Aumento
//                                             //												CuentaLista = VerificarComodines(CodPag, Sucursal, Beneficiario, BodegaBanco, "", BancoD, CXP, "", CodDes)
//                                             //												.TextMatrix(cont, 1) = CuentaLista
//                                             //												.TextMatrix(cont, 2) = BuscarCta(CuentaLista, SiCosto)
//                                             //												//If SiCosto = "S" Then.TextMatrix(cont, 6) = CenCosto
//                                             //												.TextMatrix(cont, 3) = IIf(QueDetalle <> "", QueDetalle, "Contabilización " & Doc & " " & Num & " - " & Beneficiario)
//                                             //												.TextMatrix(cont, 4 + H) = System.Math.Round(ValorPag, 2)
//                                             //												.TextMatrix(cont, 5 - H) = ""
//                                             //												ReDim Preserve CualCuadra(cont + 1)
//                                             //												CualCuadra(cont) = CtaCuadre(i)
//                                             //												cont = cont + 1
//                                            }//											End If
//                                             //											rs.MoveNext()
//                                        }//										Loop 
//                                    }//									End If
//                                }   //								End If
//                                    //							Else
//                                {

//                                    //								.Rows = cont + 1
//                                    //								.TextMatrix(cont, 0) = cont + Aumento
//                                    //								CuentaLista = VerificarComodines(CtaCtb, Sucursal, Beneficiario, BodegaBanco, "", BancoD, CXP, "", CodDes)
//                                    //								.TextMatrix(cont, 1) = CuentaLista
//                                    //								.TextMatrix(cont, 2) = BuscarCta(CuentaLista, SiCosto)
//                                    //								//If SiCosto = "S" Then.TextMatrix(cont, 6) = CenCosto
//                                    //								.TextMatrix(cont, 3) = IIf(QueDetalle <> "", QueDetalle, "Contabilización " & Doc & " " & Num & " - " & Beneficiario)
//                                    //								.TextMatrix(cont, 4 + H) = System.Math.Round(Valor(i), 2)
//                                    //								.TextMatrix(cont, 5 - H) = ""
//                                    //								ReDim Preserve CualCuadra(cont + 1)
//                                    //								CualCuadra(cont) = CtaCuadre(i)
//                                    //								cont = cont + 1
//                                }
//                            }
//                            CtaCtb = CtasH[i];
//                            H = H + 1;
//                        } while (H < 2) ;
//                    }                                       
//        //			// si se envió o no la malla de articulos colval es mayor a 0, columna en la que esta el valor del articulo

//        //			If ColVal = 0 Then GoTo terminar

//        //			For i = mallaart.FixedCols To mallaart.Rows - 1
//        //				CtaCtb = ""
//        //				NoEsta = 0
//        //				Tipo.Value = mallaart.TextMatrix(i, ColTip)
//        //				If TipoPadre = "EBG" Or TipoPadre = "IBG" Or TipoPadre = "TRF" Or TipoPadre = "AJE" Or TipoPadre = "AJI" Then
//        //					Jini = 1 : Jfin = 1
//        //				ElseIf TipoPadre = "EGR" Or TipoPadre = "ING" Or TipoPadre = "NDB" Or TipoPadre = "NCB" Then 
//        //					Jini = 11 : Jfin = 11
//        //				ElseIf Tipo.Value = "A" Then 
//        //					NoEsta = 3 : Jini = 2 : Jfin = 5
//        //				ElseIf Tipo.Value = "S" Then 
//        //					NoEsta = 7 : Jini = 6 : Jfin = 8
//        //				End If
//        //				If Jini > 0 And Jfin > 0 Then
//        //					For j = Jini To Jfin
//        //						If Individual(j) = True And j <> NoEsta And Valor(j) <> 0 Then
//        //							CtaCtb = CtasD(j)
//        //							H = 0
//        //							ValorLis = 0
//        //							ValorLis = IIf(j = 4, CDbl(libdat.CorrijeNuloN(mallaart.TextMatrix(i, ColCos))), CDbl(libdat.CorrijeNuloN(mallaart.TextMatrix(i, ColVal))))
//        //							If ValorLis <> 0 Then
//        //								Do Until H > 1
//        //									If CtaCtb > "" Then //22 / 07 / 2011 Individual(i) = False Then
//        //										.Rows = cont + 1
//        //										.TextMatrix(cont, 0) = cont + Aumento
//        //										If mallaart.TextMatrix(i, 23) = "S" And (j <> 5 And j <> 8) Then // si el servicio es de una cuenta contable tip producto
//        //											CuentaLista = mallaart.TextMatrix(i, ColCod)
//        //										Else
//        //											CuentaLista = VerificarComodines(CtaCtb, Sucursal, Beneficiario, BodegaBanco, mallaart.TextMatrix(i, ColCod), BancoD, CXP, "", CodDes)
//        //										End If
//        //										.TextMatrix(cont, 1) = CuentaLista
//        //										.TextMatrix(cont, 2) = BuscarCta(CuentaLista, SiCosto)
//        //										If TipoPadre = "EGR" Or TipoPadre = "ING" Or TipoPadre = "NDB" Or TipoPadre = "NCB" Then
//        //											.TextMatrix(cont, 3) = IIf(QueDetalle <> "", QueDetalle, Trim(mallaart.TextMatrix(i, ColCod + 1) & "  " & Trim(mallaart.TextMatrix(i, 6)) & "  " & Trim(mallaart.TextMatrix(i, 7))))
//        //										Else
//        //											.TextMatrix(cont, 3) = IIf(QueDetalle <> "", QueDetalle, "Contabilizacion " & Doc & " " & Num & " - " & mallaart.TextMatrix(i, ColCod))
//        //										End If

//        //										//-------------------------- para cargar clasificadores contables-------------- -

//        //										For k = 26 To 50
//        //											.TextMatrix(cont, k) = mallaart.TextMatrix(i, k)
//        //											If Trim(.TextMatrix(cont, k)) > "" Then .ColWidth(k) = mallaart.ColWidth(k)
//        //										Next k
//        //										//---------------------------------------------------------------------------------- -
//        //										If j = 5 Then If DescArt <> 0 Then ValorLis = (DescArt / (VtaArtIva + VtaArtSIva)) * ValorLis Else ValorLis = 0
//        //										If j = 8 Then If DescServ <> 0 Then ValorLis = (DescServ / (VtaOtrIva + VtaOtrSIva)) * ValorLis Else ValorLis = 0
//        //										.TextMatrix(cont, 4 + H) = roundd(ValorLis, 2)
//        //										.TextMatrix(cont, 5 - H) = ""
//        //										ReDim Preserve CualCuadra(cont + 1)
//        //										CualCuadra(cont) = CtaCuadre(i)
//        //										cont = cont + 1
//        //									End If
//        //									H = H + 1
//        //									CtaCtb = CtasH(j)
//        //								Loop 
//        //							End If
//        //						End If
//        //					Next j
//        //				End If
//        //			Next 

//        //terminar: 


//        //			////////////// agrupa asientos iguales en uno solo
//        //			//UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto mallactb.Rows.Haga clic aquí para obtener más información: //ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"//
//        //			If .Rows > 2 Then
//        //				i = 2
//        //				Do Until i > 99990
//        //					H = 0
//        //					//UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto mallactb.Cols.Haga clic aquí para obtener más información: //ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"//
//        //					For j = 1 To .Cols - 1
//        //						If j <> 4 And j <> 5 And j <> 3 Then
//        //							//    MsgBox.TextMatrix(i, j) & "   " & .TextMatrix(i - 1, j)
//        //							//UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto mallactb.TextMatrix.Haga clic aquí para obtener más información: //ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"//
//        //							If (.TextMatrix(i, j) <> .TextMatrix(i - 1, j)) Then H = 1 : Exit For
//        //						End If
//        //					Next j
//        //					If H = 0 Then
//        //						//UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto mallactb.TextMatrix.Haga clic aquí para obtener más información: //ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"//
//        //						.TextMatrix(i - 1, 4) = Val(.TextMatrix(i - 1, 4)) + Val(.TextMatrix(i, 4))
//        //						//UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto mallactb.TextMatrix.Haga clic aquí para obtener más información: //ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"//
//        //						.TextMatrix(i - 1, 5) = Val(.TextMatrix(i - 1, 5)) + Val(.TextMatrix(i, 5))
//        //						//UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto mallactb.RemoveItem.Haga clic aquí para obtener más información: //ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"//
//        //						.RemoveItem(i)
//        //					Else
//        //						i = i + 1
//        //					End If
//        //					//UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto mallactb.Rows.Haga clic aquí para obtener más información: //ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"//
//        //					If i > .Rows - 1 Then Exit Do
//        //				Loop 
//        //			End If
//        //			////////////verifica si el comprobante esta cuadrado

//        //			//UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto op.Opc_LimiteCuadre.Haga clic aquí para obtener más información: //ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"//
//        //			If op.Opc_LimiteCuadre; <> 0 Then
//        //				TotDebito = 0
//        //				TotCredito = 0
//        //				//UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto mallactb.Rows.Haga clic aquí para obtener más información: //ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"//
//        //				//UPGRADE_WARNING: No se puede resolver la propiedad predeterminada del objeto mallactb.FixedRows.Haga clic aquí para obtener más información: //ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"//
//        //				For i = .FixedRows To (.Rows - 1)
//        //					TotDebito = Val(CStr(TotDebito)) + Val(.TextMatrix(i, 4))
//        //					TotCredito = Val(CStr(TotCredito)) + Val(.TextMatrix(i, 5))
//        //				Next i
//        //				Diferencia = System.Math.Abs(TotDebito - TotCredito)
//        //				If Diferencia <= op.Opc_LimiteCuadre; And Diferencia > 0 Then
//        //					ColPrior = 0
//        //					prioridad = 99

//        //					For i = .FixedRows To .Rows - 1
//        //						If CualCuadra(i) > 0 And CualCuadra(i) < prioridad Then prioridad = CualCuadra(i) : ColPrior = i
//        //					Next i

//        //					If ColPrior > 0 Then
//        //						Ajuste = TotDebito - TotCredito
//        //						If Val(.TextMatrix(ColPrior, 4)) <> 0 Then
//        //							.TextMatrix(ColPrior, 4) = Val(.TextMatrix(ColPrior, 4)) - Ajuste
//        //						Else
//        //							.TextMatrix(ColPrior, 5) = Val(.TextMatrix(ColPrior, 5)) + Ajuste
//        //						End If
//        //					End If
//        //				End If
//        //			End If


//        //			//.Rows = .Rows + 1
//        //			//VerificaDistribuirCostos mallactb, Sucursal, Doc, Num, aumento
//        //			.TextMatrix(.Rows - 1, 0) = .Rows - 1 + Aumento

//        //		End With
//        //		Exit Function
//        //ConError: 
//        //		Resume Next
//        return true;
//  }
