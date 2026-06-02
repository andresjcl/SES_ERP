using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DattCom;

namespace DctosEmi
{
    public class ArticulosPesados
    {
        public List<ArticuloPeso> ListaArticulosPesados = new List<ArticuloPeso>();
    }
    public class ArticuloPeso
    {
        public string codigo { get; set; }
        public string Nombre { get; set; }
        public double peso { get; set; }
        public double Cantidad { get; set; }
        public string CodigoBase { get; set; }


    }
    public class GenerarDocumentoInventarios
    {
        ArticulosPesados ListaArticulos = new ArticulosPesados();
        string tipoDocumento = "";
        string BodegaIngreso = "";
        DateTime fechaDelDocumento;
        ClassDoc.idDocumento idDocumentoActual = new ClassDoc.idDocumento();
        sesSys.OpcDoc propiedadesDoc = new sesSys.OpcDoc();

        public bool existenEgresos = false;
        public void GenerarIngresoBalanza(DateTime fechaDocumento, string TipoIngreso, string Bodega, ArticulosPesados listaArticulos)
        {
            fechaDelDocumento = fechaDocumento;
            BodegaIngreso = Bodega;
            tipoDocumento = TipoIngreso;
            ListaArticulos = listaArticulos;
            propiedadesDoc.Cargar (tipoDocumento);
            ClassDoc.controlNumeracion cnum = new ClassDoc.controlNumeracion();
            idDocumentoActual = new ClassDoc.idDocumento
            {
                familia = propiedadesDoc.TipoDoc,
                fecha = fechaDocumento,
                numero = 0,
                Serie = "",
                Sucursal = datosEmpresa.suc,
                Tipo = tipoDocumento
            };
            idDocumentoActual.numero = cnum.NumeroMayor(idDocumentoActual, "", "", "", datosEmpresa.strConxAdcom);
            GrabarDocumento();
        }
        private  void GrabarDocumento()
        {
            string codigoEmpresa = "";
            string NombreEmpresa = "";
            string ssql = "select codigo,nombreimpresion from identificacion where CedulaIdentidadRuc = '" + datosEmpresa.Emp_RUC + "'";
            DataTable dt = SqlDatos.leerTablaAdcom(ssql);
            if (dt.Rows.Count > 0)
            {
                codigoEmpresa = dt.Rows[0]["codigo"].ToString();
                NombreEmpresa = dt.Rows[0]["nombreimpresion"].ToString();
            }
            ClassDoc.AdcDoc datADCDOC = new ClassDoc.AdcDoc(datosEmpresa.strConxAdcom)
            {
                //datADCDOC.IdClaveDoc = Convert.ToDecimal(idDocumentoActual.idClave);
                Doc_sucursal = idDocumentoActual.Sucursal,
                Doc_Bodega = BodegaIngreso,
                //datADCDOC.PuntoVta = valoresPredefinidosSucursal.idPuntoVta;
                Opc_documento = idDocumentoActual.Tipo,
                Doc_docnombre = propiedadesDoc.nombre,
                Doc_numero = Convert.ToDecimal(idDocumentoActual.numero),
                Doc_fecha = Convert.ToDateTime( idDocumentoActual.fecha.ToShortDateString()),                
                Doc_codper = codigoEmpresa,
                Doc_CiRuc = datosEmpresa.Emp_RUC,
                Doc_NombreImp = NombreEmpresa,
                Doc_Direccion = "",
                Doc_Telefono1 = "",
                Doc_detalle = "Ingreso de artículos por empaque ",
                //if (cmbVendedor.SelectedValue != null) datADCDOC.Doc_venabre = "" + cmbVendedor.SelectedValue.ToString();

                Doc_DocSop = "",
                Doc_NumSop = 0,
                IdClaveDocSop = 0,

                Doc_valor = 0,
                AuxVar9 = "",
                Doc_Hora = DateTime.Now,

                Doc_NroLoteDoc = "",
                //datADCDOC.Doc_NroIdDoc = txtNroID.Text;
                //datADCDOC.Adi_TipoDocSri = propiedadesDoc.TipoSri;
                //datADCDOC.Adi_FechContab = IIf(FechaContab < TxtFecha, TxtFecha, FechaContab)
                //datADCDOC.Adi_CodigoNSR = TexCodigoExoneraRetencion.Text
                //datADCDOC.Adi_SustTrib = DatSustento.BoundText
                //datADCDOC'.Adi_SNDevIva = IIf(DerechoIva.Value = 1, "S", "N")
                Doc_TipoDoc = idDocumentoActual.familia,
                Doc_FechaEfe = idDocumentoActual.fecha,
                Doc_extension = "",
                Doc_codusu = DatosUsuario.codigo,
                //datADCDOC.Doc_valoriva = totalesDocumento.TotIva;
                //datADCDOC.Doc_totciva = totalesDocumento.TotCiva;
                //datADCDOC.Doc_totsiva = totalesDocumento.TotSiva;
                //datADCDOC.doc_TotDesSiva = totalesDocumento.totdessiva;
                //datADCDOC.doc_TotDesCIva = totalesDocumento.totdesciva;            
                //datADCDOC.Doc_valorabon = totalesDocumento.ValorCon;
                //datADCDOC.Doc_DepDes = "";
                //datADCDOC.Doc_TotDesArt = totalesDocumento.TotDesArt;
                //datADCDOC.Doc_TotDesSer = totalesDocumento.TotDesSer;
                //datADCDOC.Doc_TotArtCIva = totalesDocumento.TotArtCIva;
                //Doc_TotArtSIva = Convert.ToDecimal(totalDocumento),
                //datADCDOC.Doc_TotSerCIva = totalesDocumento.TotSerCIva;
                //datADCDOC.Doc_TotSerSIva = totalesDocumento.TotSerSIva;
                //datADCDOC.Doc_TotAcf = totalesDocumento.TotAcf;
                //datADCDOC.Doc_Contado = totalesDocumento.ValorEfec;
                Doc_Estado = 1,
                Doc_Oculto = propiedadesDoc.ClaveOculto,
                Doc_Contabilidad = propiedadesDoc.ClaveContable,
                Doc_Banco = Convert.ToInt16(propiedadesDoc.ClaveBanco),
                Doc_Inventario = Convert.ToInt16(propiedadesDoc.ClaveInventario),
                Doc_Ventas = 0,
                Doc_Compras = 0,
                Doc_Activo = Convert.ToInt16(propiedadesDoc.ClaveActivo),
                Doc_Adicional2 = 0,
                Doc_NumeroExterno = 0,
                Doc_FechaModifica = DateTime.Now,
                Cobranza = "",
                doc_BancoOrigen = "",
                doc_NumeroCheque = "",
                doc_Anticipo = false,

                //if (Estransferencia)
                //{
                //    datADCDOC.doc_BancoDestino = cmbCtasBacoDestino.SelectedValue.ToString();
                //}
                //else
                doc_BancoDestino = ""
            };
            string resp = datADCDOC.Crear();
            if (resp.Substring(0, 3) != "ERR")
            {
                GuardarDetalleDoc(datADCDOC);
            }
        }
        private void GuardarDetalleDoc(ClassDoc.AdcDoc DatosDoc)
        {
            if (ListaArticulos.ListaArticulosPesados.Count == 0) return;
            string ssql = "select * from adctra where doc_sucursal = '" + datosEmpresa.sucursal + "' and opc_documento = '" + propiedadesDoc.TipoDoc  + "' and idclavedoc = " + DatosDoc.IdClaveDoc;

            using (SqlDataAdapter da = new SqlDataAdapter(ssql, DattCom.datosEmpresa.strConxAdcom))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                int linea = 0;
                foreach (ArticuloPeso articuloPeso in ListaArticulos.ListaArticulosPesados)
                {
                    DataRow rowNew = dt.NewRow();
                    linea++;
                    rowNew["Doc_sucursal"] = DatosDoc.Doc_sucursal;
                    rowNew["Opc_documento"] = DatosDoc.Opc_documento;
                    rowNew["Doc_numero"] = DatosDoc.Doc_numero;
                    rowNew["Tra_TipoDoc"] = DatosDoc.Doc_TipoDoc;
                    rowNew["Tra_DocSop"] = DatosDoc.Doc_DocSop;
                    rowNew["Tra_NumSop"] = DatosDoc.Doc_NumSop;
                    rowNew["Tra_Inventario"] = DatosDoc.Doc_Inventario;
                    rowNew["Tra_Ventas"] = DatosDoc.Doc_Ventas;
                    rowNew["Tra_Compras"] = DatosDoc.Doc_Compras;
                    rowNew["Tra_Activo"] = DatosDoc.Doc_Activo;
                    rowNew["IdClaveDoc"] = DatosDoc.IdClaveDoc;
                    rowNew["Tra_fecha"] = DatosDoc.Doc_fecha;
                    rowNew["Tra_NroLoteDoc"] = DatosDoc.Doc_NroLoteDoc;
                    rowNew["tra_anio"] = DatosDoc.doc_anio;
                    rowNew["tra_mes"] = DatosDoc.doc_mes;
                    rowNew["tra_dia"] = DatosDoc.doc_dia;
                    rowNew["Doc_Bodega"] = BodegaIngreso;
                    rowNew["Tra_numlinea"] = linea;
                    rowNew["Tra_Codigo"] = articuloPeso.codigo;
                    rowNew["Tra_nombre"] = articuloPeso.Nombre;
                    rowNew["Tra_cantidad"] = articuloPeso.Cantidad;
                    rowNew["Tra_costuni"] = 0;
                    rowNew["Tra_costtot"] = 0;
                    //rowNew["Tra_numprecio"] = compRow["Tra_numprecio"];
                    //rowNew["Tra_descdes"] = compRow["Tra_descdes"];
                    //rowNew["Tra_porcendes"] = compRow["Tra_porcendes"];
                    //rowNew["Tra_valordes"] = compRow["Tra_valordes"];
                    rowNew["Tra_valor"] = 0;
                    //rowNew["Tra_extension"] = EgresoInv.Doc_extension ;
                    //rowNew["Tra_sniva"] = compRow["Tra_sniva"];
                    rowNew["Tra_Individual"] = "N";
                    rowNew["Tra_quetipo"] = "A";
                    //rowNew["Tra_precuni"] = compRow["Tra_precuni"];
                    //rowNew["Tra_prectot"] = compRow["Tra_prectot"];
                    //rowNew["Tra_DepDes"] = compRow["Tra_DepDes"];
                    rowNew["Tra_Estado"] = DatosDoc.Doc_Estado;
                    rowNew["Tra_Oculto"] = DatosDoc.Doc_Oculto;
                    //rowNew["Tra_Adicional1"] = compRow["Tra_Adicional1"];
                    //rowNew["Tra_Adicional2"] = compRow["Tra_Adicional2"];
                    //rowNew["Tra_piezas"] = compRow["Tra_piezas"];
                    //rowNew["Tra_medida"] = compRow["Tra_medida"];
                    rowNew["Tra_multiplo"] = 1;
                    //rowNew["Tra_vence"] = compRow["Tra_vence"];
                    //EgresoInvTra["tra_Serie"] = compRow["tra_Serie"];
                    //rowNew["Tra_NroLote"] = compRow["Tra_NroLote"];
                    //rowNew["Periodo1"] = compRow["Periodo1"];
                    //rowNew["Periodo2"] = compRow["Periodo2"];
                    //rowNew["FacDesde"] = compRow["FacDesde"];
                    //rowNew["FacHasta"] = compRow["FacHasta"];
                    //rowNew["Habitacion"] = compRow["Habitacion"];
                    //rowNew["Mesa"] = compRow["Mesa"];
                    //rowNew["TipoPeriodo"] = compRow["TipoPeriodo"];
                    //rowNew["AuxVar1"] = compRow["AuxVar1"];
                    //rowNew["AuxVar2"] = compRow["AuxVar2"];
                    //rowNew["AuxVar3"] = compRow["AuxVar3"];
                    //rowNew["AuxVar4"] = compRow["AuxVar4"];
                    //rowNew["AuxVar5"] = compRow["AuxVar5"];
                    //rowNew["AuxVar6"] = compRow["AuxVar6"];
                    //rowNew["AuxVar7"] = compRow["AuxVar7"];
                    //rowNew["AuxVar8"] = compRow["AuxVar8"];
                    //rowNew["AuxVar9"] = compRow["AuxVar9"];
                    //rowNew["AuxVar10"] = compRow["AuxVar10"];
                    //rowNew["AuxVar11"] = compRow["AuxVar11"];
                    //rowNew["AuxVar12"] = compRow["AuxVar12"];
                    //rowNew["AuxFec1"] = compRow["AuxFec1"];
                    //rowNew["AuxFec2"] = compRow["AuxFec2"];
                    //rowNew["AuxFec3"] = compRow["AuxFec3"];
                    //rowNew["AuxLog1"] = compRow["AuxLog1"];
                    //rowNew["AuxLog2"] = compRow["AuxLog2"];
                    //rowNew["AuxLog3"] = compRow["AuxLog3"];
                    //rowNew["AuxNum1"] = compRow["AuxNum1"];
                    //rowNew["AuxNum2"] = compRow["AuxNum2"];
                    //rowNew["AuxNum3"] = compRow["AuxNum3"];
                    //rowNew["AuxNum4"] = compRow["AuxNum4"];
                    //rowNew["AuxNum5"] = compRow["AuxNum5"];
                    //rowNew["AuxNum6"] = compRow["AuxNum6"];
                    //rowNew["AuxNum7"] = compRow["AuxNum7"];
                    //rowNew["AuxNum8"] = compRow["AuxNum8"];
                    //rowNew["AuxNum9"] = compRow["AuxNum9"];
                    //rowNew["AuxNum10"] = compRow["AuxNum10"];
                    //rowNew["AuxNum11"] = compRow["AuxNum11"];
                    //rowNew["AuxNum12"] = compRow["AuxNum12"];
                    //rowNew["TipoCosto"] = compRow["TipoCosto"];
                    //rowNew["Recosteo"] = compRow["Recosteo"];
                    //rowNew["tra_costo"] = compRow["tra_costo"];
                    //rowNew["tra_empleado"] = compRow["tra_empleado"];
                    //rowNew["tra_directorio"] = compRow["tra_directorio"];
                    //rowNew["tra_dia_proyecto"] = compRow["tra_dia_proyecto"];
                    //rowNew["tra_relacionado"] = compRow["tra_relacionado"];
                    //rowNew["tra_codigoalterno"] = compRow["tra_codigoalterno"];
                    //rowNew["Tra_EsCuenta"] = compRow["Tra_EsCuenta"];
                    //rowNew["tra_producto"] = compRow["prodCodigo"];
                    //rowNew["tra_centroproduccion"] = compRow["tra_centroproduccion"];
                    //rowNew["tra_centroDistribucion"] = compRow["tra_centroDistribucion"];
                    //rowNew["tra_proyecto"] = compRow["tra_proyecto"];
                    rowNew["tra_peso"] = articuloPeso.peso;
                    rowNew["CodigoBase"] = articuloPeso.CodigoBase;
                    //rowNew["Despacho"] = compRow["Despacho"];
                    //rowNew["tra_boddestino"] = compRow["tra_boddestino"];
                    //rowNew["tra_sucdestino"] = compRow["tra_sucdestino"];
                    //rowNew["Tra_Talla"] = compRow["Tra_Talla"];
                    //rowNew["Tra_Color"] = compRow["Tra_Color"];
                    //rowNew["Tra_Dibujo"] = compRow["Tra_Dibujo"];
                    //rowNew["Tra_Genero"] = compRow["Tra_Genero"];
                    //rowNew["Tra_Modelo"] = compRow["Tra_Modelo"];
                    //rowNew["Tra_Despachado"] = compRow["Tra_Despachado"];
                    //wNew["TotPeso"] = compRow["PesoTotal"];
                    //rowNew["Ramos"] = compRow["Ramos"];
                    //rowNew["Largo"] = compRow["Largo"];
                    //rowNew["TallXramo"] = compRow["TallXramo"];
                    //rowNew["RamXcaja"] = compRow["RamXcaja"];
                    //rowNew["NroCaja"] = compRow["NroCaja"];
                    //wNew["TipCaja"] = compRow["TipoCaja"];
                    //rowNew["CantCajas"] = compRow["CantCajas"];
                    //rowNew["Tallos"] = compRow["Tallos"];
                    //rowNew["SGP"] = compRow["SGP"];
                    //rowNew["Nandina"] = compRow["Nandina"];
                    //rowNew["HTS"] = compRow["HTS"];
                    //rowNew["Fulls"] = compRow["Fulls"];
                    //rowNew["ZonaProducto"] = compRow["ZonaProducto"];                    
                    if(verificarArticulo(articuloPeso)) dt.Rows.Add(rowNew);
                }
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
               // SqlCommandBuilder CB = new SqlCommandBuilder(da);
                da.Update(dt);
                dt.AcceptChanges();
                dt.Dispose();
            }
        }
        private bool verificarArticulo(ArticuloPeso articulo)
        {
            bool resp = true;
            adcArticulo.AdcArt datart = new adcArticulo.AdcArt(datosEmpresa.strConxAdcom);
            datart = adcArticulo.AdcArt.Buscar(" Art_codigo = '" + articulo.codigo + "' ");
            if (datart != null) return true;
            adcArticulo.AdcArt datartBase = new adcArticulo.AdcArt(datosEmpresa.strConxAdcom);
            datartBase = adcArticulo.AdcArt.Buscar(" Art_codigo = '" + articulo.CodigoBase + "' ");

            datart = new adcArticulo.AdcArt(datosEmpresa.strConxAdcom)
            {
                Art_codigo = articulo.codigo,
                Art_nombre = articulo.Nombre,
                Art_Codigobase = articulo.CodigoBase,
                Art_factor = datartBase.Art_factor,
                Art_FechaCrea = DateTime.Now,
                Art_grupo = "",// datartBase.Art_grupo,
                Art_subgrup = "",//datartBase.Art_subgrup,
                Art_clase = "",//datartBase.Art_clase,
                Art_categor = "",//datartBase.Art_categor,
                Art_unimed = datartBase.Art_unimed,
                NombreCorto = datartBase.NombreCorto,
                Art_peso = Convert.ToDecimal(articulo.peso)
            };
            string err = datart.Actualizar();
            if (err.Substring(0, 3) == "ERR") resp = false;
            return resp;
        }        
    }
}
