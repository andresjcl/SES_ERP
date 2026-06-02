using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using DattCom;

namespace DctosEmi
{
    class FacturacionMasiva
    {
        public void GenerarFacturas(string tipoDoc, string idNumDoc, DateTime fechaFact)
        {
            DataTable dtAdcTra = new DataTable();
            docTotals totalesDocumento = new docTotals();
            sesSys.OpcDoc propiedadesFactura = new sesSys.OpcDoc();
            propiedadesFactura.Cargar(tipoDoc);

            sesSys.OpcDoc propiedadesOrigen = new sesSys.OpcDoc();

            ClassDoc.AdcDoc datADCDOC = new ClassDoc.AdcDoc(datosEmpresa.strConxAdcom);
            DaxComercia.classPagosDoc pagosDoc = new DaxComercia.classPagosDoc();
            adcDescto.descDocumento claseDescuentos = new adcDescto.descDocumento();
            IvaRett.docImpuestos claseImpuestos = new IvaRett.docImpuestos();
            claseImpuestos.cargar(datosEmpresa.strConxIvaret, DateTime.Now);

            string ssql = "select max (Doc_sucursal +';'+ OPC_DOCUMENTO+';'+cast(IdClaveDoc as varchar(20))+';'+cast(isnull(UnirArticulos,0) as varchar(1))) as idDoc";
            ssql += ", NroFactura from DaxGenMasFac where NroFactura > 0";
            ssql += " group by NroFactura order by nroFactura";

            DataTable DatGenerar = SqlDatos.leerTablaAdcom(ssql);
            decimal NroFacturaAnterior = 0;
            decimal NroFacturaAsignado = 0;

            foreach (DataRow dtrow in DatGenerar.Rows)
            {
                NroFacturaAsignado = Convert.ToDecimal(dtrow["NroFactura"]);
                //if  (NroFacturaAnterior > 0)
                {
                    string[] IDdoc = dtrow["idDoc"].ToString().Split(Convert.ToChar(";"));
                    ClassDoc.idDocumento idDocOrig = new ClassDoc.idDocumento
                    {
                        idClave = Convert.ToDouble(IDdoc[2]),
                        numero = Convert.ToDouble(IDdoc[3]),
                        Sucursal = IDdoc[0],
                        Tipo = IDdoc[1]
                    };
                    propiedadesOrigen.Cargar(idDocOrig.Tipo);

                    pagosDoc.DocSucursal = idDocOrig.Sucursal;
                    pagosDoc.Doctipo = idDocOrig.Tipo;
                    pagosDoc.idClaveDoc = idDocOrig.idClave;
                    pagosDoc.cargarPagosDocumento("ADCPAG");

                    //ssql = " doc_sucursal ='" + dtrow["doc_sucursal"].ToString() + "' and Opc_documento ='" + dtrow["opc_documento"].ToString() + "' and idclavedoc =" + dtrow["idclavedoc"].ToString();

                    datADCDOC = new ClassDoc.AdcDoc(datosEmpresa.strConxAdcom);
                    //                    datADCDOC = ClassDoc.AdcDoc.Buscar(ssql);
                    DataTable DatAux = new DataTable();
                    CopiarDocumento copia = new CopiarDocumento();
                    copia.CopiarElDocumento(idDocOrig, propiedadesOrigen.tablaDatosDoc, ref datADCDOC, ref DatAux, false);

                    datADCDOC.Doc_sucursal = datosEmpresa.suc;
                    datADCDOC.Doc_Bodega = "";
                    datADCDOC.Opc_documento = tipoDoc;
                    datADCDOC.Doc_fecha = fechaFact;
                    datADCDOC.Doc_numero = NroFacturaAsignado;

                    //datADCDOC.Doc_codper = dtrow["Doc_codper"].ToString();
                    //datADCDOC.Doc_CiRuc = dtrow["Doc_ciruc"].ToString();
                    //datADCDOC.Doc_NombreImp = dtrow["Doc_nombreimp"].ToString();
                    //datADCDOC.Doc_Direccion = dtrow["Doc_direccion"].ToString();
                    //datADCDOC.Doc_Telefono1 = dtrow["Doc_telefono1"].ToString();
                    //datADCDOC.Doc_detalle = dtrow["Doc_detalle"].ToString();
                    //datADCDOC.Doc_venabre = dtrow["Doc_venabre"].ToString();

                    datADCDOC.Doc_DocSop = "";
                    datADCDOC.Doc_NumSop = 0;

                    //datADCDOC.AuxVar9 = txtCorreElectronico.Text;

                    //datADCDOC.Doc_nombredes1 = "";// claseDescuentos.nombreDes[0];
                    //datADCDOC.Doc_nombredes2 = "";//claseDescuentos.nombreDes[1];
                    //datADCDOC.Doc_nombredes3 = "";//claseDescuentos.nombreDes[2];

                    //datADCDOC.Doc_porcendes1 = 0;//Convert.ToDecimal(claseDescuentos.porcentajeDes[0]);
                    //datADCDOC.Doc_porcendes2 = 0;//Convert.ToDecimal(claseDescuentos.porcentajeDes[1]);
                    //datADCDOC.Doc_porcendes3 = 0;//Convert.ToDecimal(claseDescuentos.porcentajeDes[2]);

                    //datADCDOC.Doc_valordes1 = 0;//Convert.ToDecimal(claseDescuentos.valorDes[0]); ;
                    //datADCDOC.Doc_valordes2 = 0;//Convert.ToDecimal(claseDescuentos.valorDes[1]);
                    //datADCDOC.Doc_valordes3 = 0;//Convert.ToDecimal(claseDescuentos.valorDes[2]);

                    datADCDOC.Doc_porceniva = Convert.ToDecimal(claseImpuestos.impstoPorcentaje1);

                    //datADCDOC.Doc_NroLoteDoc = TexLote.Text

                    datADCDOC.Doc_NroIdDoc = idNumDoc;
                    datADCDOC.Adi_TipoDocSri = propiedadesFactura.TipoSri;

                    //datADCDOC.Adi_FechContab = IIf(FechaContab < TxtFecha, TxtFecha, FechaContab)
                    //datADCDOC.Adi_CodigoNSR = TexCodigoExoneraRetencion.Text
                    //datADCDOC.Adi_SustTrib = DatSustento.BoundText
                    //datADCDOC'.Adi_SNDevIva = IIf(DerechoIva.Value = 1, "S", "N")

                    datADCDOC.IdClaveDoc = 0; //Convert.ToDecimal(idDocumentoActual.idClave);
                    datADCDOC.IdClaveDocSop = 0;
                    datADCDOC.Doc_docnombre = propiedadesFactura.nombre;
                    datADCDOC.Doc_TipoDoc = propiedadesFactura.TipoDoc;
                    datADCDOC.Doc_FechaEfe = datADCDOC.Doc_fecha;     //FechaVence.Value
                    datADCDOC.Doc_Hora = DateTime.Now;
                    datADCDOC.Doc_extension = "";
                    datADCDOC.Doc_codusu = datosEmpresa.usr;

                    datADCDOC.Doc_Estado = 1;
                    datADCDOC.Doc_Oculto = propiedadesFactura.ClaveOculto;
                    datADCDOC.Doc_Contabilidad = propiedadesFactura.ClaveContable;
                    datADCDOC.Doc_Banco = Convert.ToInt16(propiedadesFactura.ClaveBanco);
                    datADCDOC.Doc_Inventario = Convert.ToInt16(propiedadesFactura.ClaveInventario);
                    datADCDOC.Doc_Ventas = Convert.ToInt16(propiedadesFactura.ClaveVentas);
                    datADCDOC.Doc_Compras = Convert.ToInt16(propiedadesFactura.ClaveCompras);
                    datADCDOC.Doc_Activo = Convert.ToInt16(propiedadesFactura.ClaveActivo);
                    datADCDOC.Doc_Adicional2 = 0;
                    datADCDOC.Doc_NumeroExterno = 0;
                    datADCDOC.IdClaveDocSop = 0;
                    datADCDOC.Doc_FechaModifica = docUtils.DaxNow();
                    datADCDOC.Adi_NroAutSri = "";                   //TextNroAutSri
                    datADCDOC.ProductoProduccion = "";             //ProductoProduccion.Text                                                                   //            datADCDOC.FacDesde = FDesde.Valu                                                                  //            datADCDOC.FacHasta = FHasta.Value;
                    datADCDOC.TipoPeriodo = "";
                    datADCDOC.Doc_DepDes = "";

                    datADCDOC.Crear();

                    if (datADCDOC.IdClaveDoc > 0)
                    {
                        pagosDoc.DocSucursal = datADCDOC.Doc_sucursal;
                        pagosDoc.Doctipo = datADCDOC.Opc_documento;
                        pagosDoc.idClaveDoc = Convert.ToDouble(datADCDOC.IdClaveDoc);
                        pagosDoc.DocNumero = Convert.ToDouble(datADCDOC.Doc_numero);
                        pagosDoc.DocFecha = datADCDOC.Doc_fecha;

                        GenerarDetalle(datADCDOC, dtAdcTra, totalesDocumento, NroFacturaAsignado, idDocOrig.numero);
                        Decimal ivaM = 0;
                        totalesDocumento.totalizar(dtAdcTra, ivaM, claseDescuentos, pagosDoc, propiedadesFactura, datosEmpresa.Par_DigitosPrecios, datosEmpresa.Par_DigitosCostos);

                        datADCDOC.Doc_valor = Convert.ToDecimal(totalesDocumento.TotVta);
                        pagosDoc.DocValor = Convert.ToDouble(datADCDOC.Doc_valor);
                        datADCDOC.Doc_valoriva = totalesDocumento.TotIva;
                        datADCDOC.Doc_totciva = totalesDocumento.TotCiva;
                        datADCDOC.Doc_totsiva = totalesDocumento.TotSiva;
                        datADCDOC.Doc_valorabon = totalesDocumento.ValorCon;
                        datADCDOC.Doc_TotDesArt = totalesDocumento.TotDesArt;
                        datADCDOC.Doc_TotDesSer = totalesDocumento.TotDesSer;
                        datADCDOC.Doc_TotArtCIva = totalesDocumento.TotArtCIva;
                        datADCDOC.Doc_TotArtSIva = totalesDocumento.TotArtSIva;
                        datADCDOC.Doc_TotSerCIva = totalesDocumento.TotSerCIva;
                        datADCDOC.Doc_TotSerSIva = totalesDocumento.TotSerSIva;
                        datADCDOC.Doc_TotAcf = totalesDocumento.TotAcf;
                        datADCDOC.Doc_Contado = totalesDocumento.ValorEfec;
                        datADCDOC.doc_TotDesSiva = totalesDocumento.totdessiva;
                        datADCDOC.doc_TotDesCIva = totalesDocumento.totdesciva;

                        datADCDOC.Actualizar();
                        //                        GenerarDetalle(datADCDOC, dtAdcTra, totalesDocumento, NroFacturaAsignado, 0);
                    }
                    NroFacturaAnterior = datADCDOC.Doc_numero;
                }
            }
        }

        public Int32 GenerarDetalle(ClassDoc.AdcDoc Factura, DataTable dtAdcTraOrigen, docTotals totalesDocumento, decimal nroFacturaAsigando, double unirArticulos)
        {
            Int32 NroRegistrosCreados = 0;
            string agrupar = "N";
            if (unirArticulos != 0) agrupar = "S";
            dtAdcTraOrigen = SqlDatos.leerTablaAdcom("FacMasTranOrig " + nroFacturaAsigando.ToString() + ",'" + agrupar + "'");

            string ssql = " doc_sucursal = '" + Factura.Doc_sucursal + "' and opc_documento = '" + Factura.Opc_documento + "' and idclavedoc = " + Factura.IdClaveDoc.ToString();

            DataTable dtFactura = new DataTable();
            SqlDataAdapter daDoc = new SqlDataAdapter("select * from adctra where " + ssql, DattCom.datosEmpresa.strConxAdcom);
            DataRow rowFac;
            daDoc.Fill(dtFactura);

            SqlCommandBuilder cb = new SqlCommandBuilder(daDoc);
            string ManifiestoAnt = "";
            foreach (DataRow rowPro in dtAdcTraOrigen.Rows)
            {
                NroRegistrosCreados++;
                if (ManifiestoAnt == "" || ManifiestoAnt != rowPro["Manifiesto"].ToString())
                {
                    ManifiestoAnt = rowPro["Manifiesto"].ToString();
                    crearLineaManifiesto(ManifiestoAnt, dtFactura, NroRegistrosCreados,Factura);
                    NroRegistrosCreados++;
                }
                rowFac = dtFactura.NewRow();
                rowFac["Doc_sucursal"] = Factura.Doc_sucursal;
                rowFac["Opc_documento"] = Factura.Opc_documento;
                rowFac["Doc_numero"] = Factura.Doc_numero;
                rowFac["IdClaveDoc"] = Factura.IdClaveDoc;
                rowFac["Tra_TipoDoc"] = Factura.Doc_TipoDoc;
                rowFac["Tra_DocSop"] = Factura.Doc_DocSop;
                rowFac["Tra_NumSop"] = Factura.Doc_NumSop;
                rowFac["Tra_Inventario"] = Factura.Doc_Inventario;
                rowFac["Tra_Ventas"] = Factura.Doc_Ventas;
                rowFac["Tra_Compras"] = Factura.Doc_Compras;
                rowFac["Tra_Activo"] = Factura.Doc_Activo;
                rowFac["Tra_fecha"] = Factura.Doc_fecha;
                rowFac["Tra_NroLoteDoc"] = Factura.Doc_NroLoteDoc;
                rowFac["tra_anio"] = Factura.doc_anio;
                rowFac["tra_mes"] = Factura.doc_mes;
                rowFac["tra_dia"] = Factura.doc_dia;

                rowFac["Doc_Bodega"] = "";

                rowFac["Tra_numlinea"] = NroRegistrosCreados;
                rowFac["Tra_Codigo"] = rowPro["Tra_Codigo"];
                rowFac["Tra_docotro"] = rowPro["Tra_docotro"];
                rowFac["Tra_numotro"] = rowPro["Tra_numotro"];
                rowFac["Tra_nombre"] = rowPro["Tra_nombre"];
                rowFac["Tra_cantidad"] = rowPro["CantidadProducto"];
                rowFac["Tra_costuni"] = rowPro["Tra_costuni"];
                rowFac["Tra_costtot"] = rowPro["Tra_costtot"];
                rowFac["Tra_numprecio"] = rowPro["Tra_numprecio"];
                rowFac["Tra_descdes"] = rowPro["Tra_descdes"];
                rowFac["Tra_porcendes"] = rowPro["Tra_porcendes"];
                rowFac["Tra_valordes"] = rowPro["Tra_valordes"];

                rowFac["Tra_valor"] = rowPro["Tra_valor"];

                rowFac["Tra_extension"] = rowPro["Tra_extension"];
                rowFac["Tra_sniva"] = rowPro["Tra_sniva"];
                rowFac["Tra_Individual"] = rowPro["Tra_Individual"];
                rowFac["Tra_quetipo"] = rowPro["Tra_quetipo"];

                rowFac["Tra_precuni"] = rowPro["Tra_precuni"];
                rowFac["Tra_prectot"] = rowPro["Tra_prectot"];

                rowFac["Tra_DepDes"] = rowPro["Tra_DepDes"];
                rowFac["Tra_Estado"] = rowPro["Tra_Estado"];
                rowFac["Tra_Oculto"] = rowPro["Tra_Oculto"];
                rowFac["Tra_Adicional1"] = rowPro["Tra_Adicional1"];
                rowFac["Tra_Adicional2"] = rowPro["Tra_Adicional2"];
                rowFac["Tra_piezas"] = rowPro["Tra_piezas"];
                rowFac["Tra_medida"] = rowPro["Tra_medida"];
                rowFac["Tra_multiplo"] = rowPro["Tra_multiplo"];
                rowFac["Tra_vence"] = rowPro["Tra_vence"];
                //FacturaTra["tra_Serie"] = rowPro["tra_Serie"];
                rowFac["Tra_NroLote"] = rowPro["Tra_NroLote"];
                rowFac["Periodo1"] = rowPro["Periodo1"];
                rowFac["Periodo2"] = rowPro["Periodo2"];
                rowFac["FacDesde"] = rowPro["FacDesde"];
                rowFac["FacHasta"] = rowPro["FacHasta"];
                rowFac["Habitacion"] = rowPro["Habitacion"];
                rowFac["Mesa"] = rowPro["Mesa"];
                rowFac["TipoPeriodo"] = rowPro["TipoPeriodo"];
                rowFac["AuxVar1"] = rowPro["AuxVar1"];
                rowFac["AuxVar2"] = rowPro["AuxVar2"];
                rowFac["AuxVar3"] = rowPro["AuxVar3"];
                rowFac["AuxVar4"] = rowPro["AuxVar4"];
                rowFac["AuxVar5"] = rowPro["AuxVar5"];
                rowFac["AuxVar6"] = rowPro["AuxVar6"];
                rowFac["AuxVar7"] = rowPro["AuxVar7"];
                rowFac["AuxVar8"] = rowPro["AuxVar8"];
                rowFac["AuxVar9"] = rowPro["AuxVar9"];
                rowFac["AuxVar10"] = rowPro["AuxVar10"];
                rowFac["AuxVar11"] = rowPro["AuxVar11"];
                rowFac["AuxVar12"] = rowPro["AuxVar12"];
                rowFac["AuxFec1"] = rowPro["AuxFec1"];
                rowFac["AuxFec2"] = rowPro["AuxFec2"];
                rowFac["AuxFec3"] = rowPro["AuxFec3"];
                rowFac["AuxLog1"] = rowPro["AuxLog1"];
                rowFac["AuxLog2"] = rowPro["AuxLog2"];
                rowFac["AuxLog3"] = rowPro["AuxLog3"];
                rowFac["AuxNum1"] = rowPro["AuxNum1"];
                rowFac["AuxNum2"] = rowPro["AuxNum2"];
                rowFac["AuxNum3"] = rowPro["AuxNum3"];
                rowFac["AuxNum4"] = rowPro["AuxNum4"];
                rowFac["AuxNum5"] = rowPro["AuxNum5"];
                rowFac["AuxNum6"] = rowPro["AuxNum6"];
                rowFac["AuxNum7"] = rowPro["AuxNum7"];
                rowFac["AuxNum8"] = rowPro["AuxNum8"];
                rowFac["AuxNum9"] = rowPro["AuxNum9"];
                rowFac["AuxNum10"] = rowPro["AuxNum10"];
                rowFac["AuxNum11"] = rowPro["AuxNum11"];
                rowFac["AuxNum12"] = rowPro["AuxNum12"];
                rowFac["TipoCosto"] = rowPro["TipoCosto"];
                rowFac["Recosteo"] = rowPro["Recosteo"];
                rowFac["tra_costo"] = rowPro["tra_costo"];
                rowFac["tra_empleado"] = rowPro["tra_empleado"];
                rowFac["tra_directorio"] = rowPro["tra_directorio"];
                rowFac["tra_dia_proyecto"] = rowPro["tra_dia_proyecto"];
                rowFac["tra_relacionado"] = rowPro["tra_relacionado"];
                rowFac["tra_codigoalterno"] = rowPro["tra_codigoalterno"];
                rowFac["Tra_EsCuenta"] = rowPro["Tra_EsCuenta"];
                rowFac["tra_producto"] = rowPro["tra_producto"];
                rowFac["tra_centroproduccion"] = rowPro["tra_centroproduccion"];
                rowFac["tra_centroDistribucion"] = rowPro["tra_centroDistribucion"];
                rowFac["tra_proyecto"] = rowPro["tra_proyecto"];
                rowFac["tra_peso"] = rowPro["tra_peso"];
                rowFac["CodigoBase"] = rowPro["CodigoBase"];
                rowFac["Despacho"] = rowPro["Despacho"];
                rowFac["tra_boddestino"] = rowPro["tra_boddestino"];
                rowFac["tra_sucdestino"] = rowPro["tra_sucdestino"];
                rowFac["Tra_Talla"] = rowPro["Tra_Talla"];
                rowFac["Tra_Color"] = rowPro["Tra_Color"];
                rowFac["Tra_Dibujo"] = rowPro["Tra_Dibujo"];
                rowFac["Tra_Genero"] = rowPro["Tra_Genero"];
                rowFac["Tra_Modelo"] = rowPro["Tra_Modelo"];
                rowFac["Tra_Despachado"] = rowPro["Tra_Despachado"];
                rowFac["TotPeso"] = rowPro["TotPeso"];
                rowFac["Ramos"] = rowPro["Ramos"];
                rowFac["Largo"] = rowPro["Largo"];
                rowFac["TallXramo"] = rowPro["TallXramo"];
                rowFac["RamXcaja"] = rowPro["RamXcaja"];
                rowFac["NroCaja"] = rowPro["NroCaja"];
                rowFac["TipCaja"] = rowPro["TipCaja"];
                rowFac["CantCajas"] = rowPro["CantCajas"];
                rowFac["Tallos"] = rowPro["Tallos"];
                rowFac["SGP"] = rowPro["SGP"];
                rowFac["Nandina"] = rowPro["Nandina"];
                rowFac["HTS"] = rowPro["HTS"];
                rowFac["Fulls"] = rowPro["Fulls"];
                rowFac["ZonaProducto"] = rowPro["ZonaProducto"];
                dtFactura.Rows.Add(rowFac);
            }
            daDoc.Update(dtFactura);
            dtFactura.AcceptChanges();
            return NroRegistrosCreados;
        }
        private void crearLineaManifiesto(string manifiestoAnt, DataTable dtFactura, int NroRegistrosCreados, ClassDoc.AdcDoc Factura)
        {
            DataRow  rowFac = dtFactura.NewRow();
            rowFac["Doc_sucursal"] = Factura.Doc_sucursal;
            rowFac["Opc_documento"] = Factura.Opc_documento;
            rowFac["Doc_numero"] = Factura.Doc_numero;
            rowFac["IdClaveDoc"] = Factura.IdClaveDoc;
            rowFac["Tra_TipoDoc"] = Factura.Doc_TipoDoc;
            rowFac["Tra_DocSop"] = Factura.Doc_DocSop;
            rowFac["Tra_NumSop"] = Factura.Doc_NumSop;
            rowFac["Tra_Inventario"] = Factura.Doc_Inventario;
            rowFac["Tra_Ventas"] = Factura.Doc_Ventas;
            rowFac["Tra_Compras"] = Factura.Doc_Compras;
            rowFac["Tra_Activo"] = Factura.Doc_Activo;
            rowFac["Tra_fecha"] = Factura.Doc_fecha;
            rowFac["Tra_NroLoteDoc"] = Factura.Doc_NroLoteDoc;
            rowFac["tra_anio"] = Factura.doc_anio;
            rowFac["tra_mes"] = Factura.doc_mes;
            rowFac["tra_dia"] = Factura.doc_dia;

            rowFac["Doc_Bodega"] = "";

            rowFac["Tra_numlinea"] = NroRegistrosCreados;
            rowFac["Tra_Codigo"] = ".";
            rowFac["Tra_nombre"] = "Manifiesto : " + manifiestoAnt;
            rowFac["Tra_cantidad"] = 0;
            rowFac["Tra_costuni"] = 0;
            rowFac["Tra_costtot"] = 0;
            rowFac["Tra_numprecio"] = 0;
            rowFac["Tra_descdes"] = 0;
            rowFac["Tra_porcendes"] = 0;
            rowFac["Tra_valordes"] = 0;

            rowFac["Tra_valor"] = 0;

            rowFac["Tra_extension"] = 0;
            //rowFac["Tra_sniva"] = rowPro["Tra_sniva"];
            //rowFac["Tra_Individual"] = rowPro["Tra_Individual"];
            rowFac["Tra_quetipo"] = "S";

            rowFac["Tra_precuni"] = 0;
            rowFac["Tra_prectot"] = 0;

            //rowFac["Tra_DepDes"] = rowPro["Tra_DepDes"];
            //rowFac["Tra_Estado"] = rowPro["Tra_Estado"];
            //rowFac["Tra_Oculto"] = rowPro["Tra_Oculto"];
            //rowFac["Tra_Adicional1"] = rowPro["Tra_Adicional1"];
            //rowFac["Tra_Adicional2"] = rowPro["Tra_Adicional2"];
            //rowFac["Tra_piezas"] = rowPro["Tra_piezas"];
            //rowFac["Tra_medida"] = rowPro["Tra_medida"];
            //rowFac["Tra_multiplo"] = rowPro["Tra_multiplo"];
            //rowFac["Tra_vence"] = rowPro["Tra_vence"];
            ////FacturaTra["tra_Serie"] = rowPro["tra_Serie"];
            //rowFac["Tra_NroLote"] = rowPro["Tra_NroLote"];
            //rowFac["Periodo1"] = rowPro["Periodo1"];
            //rowFac["Periodo2"] = rowPro["Periodo2"];
            //rowFac["FacDesde"] = rowPro["FacDesde"];
            //rowFac["FacHasta"] = rowPro["FacHasta"];
            //rowFac["Habitacion"] = rowPro["Habitacion"];
            //rowFac["Mesa"] = rowPro["Mesa"];
            //rowFac["TipoPeriodo"] = rowPro["TipoPeriodo"];
            //rowFac["AuxVar1"] = rowPro["AuxVar1"];
            //rowFac["AuxVar2"] = rowPro["AuxVar2"];
            //rowFac["AuxVar3"] = rowPro["AuxVar3"];
            //rowFac["AuxVar4"] = rowPro["AuxVar4"];
            //rowFac["AuxVar5"] = rowPro["AuxVar5"];
            //rowFac["AuxVar6"] = rowPro["AuxVar6"];
            //rowFac["AuxVar7"] = rowPro["AuxVar7"];
            //rowFac["AuxVar8"] = rowPro["AuxVar8"];
            //rowFac["AuxVar9"] = rowPro["AuxVar9"];
            //rowFac["AuxVar10"] = rowPro["AuxVar10"];
            //rowFac["AuxVar11"] = rowPro["AuxVar11"];
            //rowFac["AuxVar12"] = rowPro["AuxVar12"];
            //rowFac["AuxFec1"] = rowPro["AuxFec1"];
            //rowFac["AuxFec2"] = rowPro["AuxFec2"];
            //rowFac["AuxFec3"] = rowPro["AuxFec3"];
            //rowFac["AuxLog1"] = rowPro["AuxLog1"];
            //rowFac["AuxLog2"] = rowPro["AuxLog2"];
            //rowFac["AuxLog3"] = rowPro["AuxLog3"];
            //rowFac["AuxNum1"] = rowPro["AuxNum1"];
            //rowFac["AuxNum2"] = rowPro["AuxNum2"];
            //rowFac["AuxNum3"] = rowPro["AuxNum3"];
            //rowFac["AuxNum4"] = rowPro["AuxNum4"];
            //rowFac["AuxNum5"] = rowPro["AuxNum5"];
            //rowFac["AuxNum6"] = rowPro["AuxNum6"];
            //rowFac["AuxNum7"] = rowPro["AuxNum7"];
            //rowFac["AuxNum8"] = rowPro["AuxNum8"];
            //rowFac["AuxNum9"] = rowPro["AuxNum9"];
            //rowFac["AuxNum10"] = rowPro["AuxNum10"];
            //rowFac["AuxNum11"] = rowPro["AuxNum11"];
            //rowFac["AuxNum12"] = rowPro["AuxNum12"];
            //rowFac["TipoCosto"] = rowPro["TipoCosto"];
            //rowFac["Recosteo"] = rowPro["Recosteo"];
            //rowFac["tra_costo"] = rowPro["tra_costo"];
            //rowFac["tra_empleado"] = rowPro["tra_empleado"];
            //rowFac["tra_directorio"] = rowPro["tra_directorio"];
            //rowFac["tra_dia_proyecto"] = rowPro["tra_dia_proyecto"];
            //rowFac["tra_relacionado"] = rowPro["tra_relacionado"];
            //rowFac["tra_codigoalterno"] = rowPro["tra_codigoalterno"];
            //rowFac["Tra_EsCuenta"] = rowPro["Tra_EsCuenta"];
            //rowFac["tra_producto"] = rowPro["tra_producto"];
            //rowFac["tra_centroproduccion"] = rowPro["tra_centroproduccion"];
            //rowFac["tra_centroDistribucion"] = rowPro["tra_centroDistribucion"];
            //rowFac["tra_proyecto"] = rowPro["tra_proyecto"];
            //rowFac["tra_peso"] = rowPro["tra_peso"];
            //rowFac["CodigoBase"] = rowPro["CodigoBase"];
            //rowFac["Despacho"] = rowPro["Despacho"];
            //rowFac["tra_boddestino"] = rowPro["tra_boddestino"];
            //rowFac["tra_sucdestino"] = rowPro["tra_sucdestino"];
            //rowFac["Tra_Talla"] = rowPro["Tra_Talla"];
            //rowFac["Tra_Color"] = rowPro["Tra_Color"];
            //rowFac["Tra_Dibujo"] = rowPro["Tra_Dibujo"];
            //rowFac["Tra_Genero"] = rowPro["Tra_Genero"];
            //rowFac["Tra_Modelo"] = rowPro["Tra_Modelo"];
            //rowFac["Tra_Despachado"] = rowPro["Tra_Despachado"];
            //rowFac["TotPeso"] = rowPro["TotPeso"];
            //rowFac["Ramos"] = rowPro["Ramos"];
            //rowFac["Largo"] = rowPro["Largo"];
            //rowFac["TallXramo"] = rowPro["TallXramo"];
            //rowFac["RamXcaja"] = rowPro["RamXcaja"];
            //rowFac["NroCaja"] = rowPro["NroCaja"];
            //rowFac["TipCaja"] = rowPro["TipCaja"];
            //rowFac["CantCajas"] = rowPro["CantCajas"];
            //rowFac["Tallos"] = rowPro["Tallos"];
            //rowFac["SGP"] = rowPro["SGP"];
            //rowFac["Nandina"] = rowPro["Nandina"];
            //rowFac["HTS"] = rowPro["HTS"];
            //rowFac["Fulls"] = rowPro["Fulls"];
            //rowFac["ZonaProducto"] = rowPro["ZonaProducto"];
            dtFactura.Rows.Add(rowFac);
        }
    }
}
