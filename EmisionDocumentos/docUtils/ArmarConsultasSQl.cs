using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace adcDocumentos
{
    public class armarConsTra
    {

		public string armarSqlLecturaTraFacPv(PrySysp13.OpcDoc propedadesDocmto, string TablaTra, string suc, string tip, double idClave)
        {
            string ssqlTra = "select ";
            ssqlTra += "TRA_NUMLINEA";
            ssqlTra += ",tra_codigo";
            ssqlTra += ",tra_nombre";
            ssqlTra += ",tra_cantidad";
            ssqlTra += ",tra_medida";
            ssqlTra += ",Tra_precuni";
            ssqlTra += ",tra_porcendes";
            ssqlTra += ",tra_valordes";
            ssqlTra += ",Tra_prectot";
            ssqlTra += ",TRA_SNIVA";


            if (datosAuxiliares.tieneDatoDetalle("Piezas", propedadesDocmto)) ssqlTra += ",tra_piezas";
            if (datosAuxiliares.tieneDatoDetalle("Peso", propedadesDocmto)) ssqlTra += ",tra_peso";
            if (datosAuxiliares.tieneDatoDetalle("BodegaMovimiento", propedadesDocmto)) ssqlTra += ",Doc_Bodega";
            if (datosAuxiliares.tieneDatoDetalle("LoteProducto", propedadesDocmto)) ssqlTra += ",tra_nrolote";
            if (datosAuxiliares.tieneDatoDetalle("FechaCaducidad", propedadesDocmto)) ssqlTra += ",Tra_vence";
            if (datosAuxiliares.tieneDatoDetalle("PeriodoLiquidación", propedadesDocmto)) ssqlTra += ",FacDesde,FacHasta";
            if (datosAuxiliares.tieneDatoDetalle("DespachoInmediato", propedadesDocmto)) ssqlTra += ",despacho";
            if (datosAuxiliares.tieneDatoDetalle("Centro Costo", propedadesDocmto)) ssqlTra += ",tra_costo";
			if (datosAuxiliares.tieneDatoDetalle("Empleado", propedadesDocmto)) ssqlTra += ",tra_empleado";
			if (datosAuxiliares.tieneDatoDetalle("Centro Producción", propedadesDocmto)) ssqlTra += ",tra_centroProduccion";
			if (datosAuxiliares.tieneDatoDetalle("Centro Distribución", propedadesDocmto)) ssqlTra += ",tra_centroDistribucion";
			if (datosAuxiliares.tieneDatoDetalle("Proyecto", propedadesDocmto)) ssqlTra += ",tra_Proyecto";

			//if (tieneDatoDetalle("Talla", propedadesDocmto)) ssqlTra += ", Tra_Talla";
			//if (tieneDatoDetalle("Color", propedadesDocmto)) ssqlTra += ", Tra_Color";
			//ssqlTra += ", Tra_Dibujo";
			//ssqlTra += ", Tra_Genero";
			//ssqlTra += ", Tra_Modelo";
			//ssqlTra += ",Tra_serie as NroSerie";



			ssqlTra += ",tra_quetipo";
            ssqlTra += ",tra_esCuenta";
            ssqlTra += ",Tra_individual";
            ssqlTra += ",tra_costuni";
            ssqlTra += ",Tra_CostTot";
            ssqlTra += ",tra_multiplo";
            ssqlTra += ",tra_numprecio";
            ssqlTra += ",0.0000 as Existencia ";
            ssqlTra += ",0.0000 as limiteDescuento";
			ssqlTra += ",0.0000 as descuentoArticulo";
			ssqlTra += ",0.0000 as precioArticulo";
            ssqlTra += ",'' as medidaArticulo";
            ssqlTra += ",'S' as Serv";
            ssqlTra += ",'' as Cmb";
            ssqlTra += ",TRA_SNIVA";
            ssqlTra += ",AuxVar3";


            ssqlTra += " from " + TablaTra + " where doc_sucursal = '" + suc + "' and opc_documento ='" + tip + "' and idclavedoc = " + idClave.ToString();
            ssqlTra += " order by opc_documento,idclavedoc,tra_numlinea";

            return ssqlTra;
        }
		public string armarSqlLecturaMovPrep(PrySysp13.OpcDoc propedadesDocmto, string TablaDia, string suc, string tip, double idClave)
		{
			string ssqlTra = "select ";

            

            ssqlTra += "Dia_linea";
			ssqlTra += ",Cta_codigo";
			ssqlTra += ",Dia_ctanombre";
            ssqlTra += ",Dia_detalle";
            ssqlTra += ",dia_signo";
            ssqlTra += ",dia_valor";
            ssqlTra += ",case when (dia_signo = 1) then dia_valor else 0 end as valordebito";
			ssqlTra += ",case when (dia_signo <> 1) then dia_valor else 0 end as valorcredito";

			if (datosAuxiliares.tieneDatoDetalle("Centro Costo", propedadesDocmto)) ssqlTra += ",Dia_Costo";
			if (datosAuxiliares.tieneDatoDetalle("Empleado", propedadesDocmto)) ssqlTra += ",dia_empleado";
			if (datosAuxiliares.tieneDatoDetalle("Centro Producción", propedadesDocmto)) ssqlTra += ",dia_centroProduccion";
			if (datosAuxiliares.tieneDatoDetalle("Centro Distribución", propedadesDocmto)) ssqlTra += ",dia_centroDistribucion";
			if (datosAuxiliares.tieneDatoDetalle("Proyecto", propedadesDocmto)) ssqlTra += ",dia_Proyecto";

			ssqlTra += " from " + TablaDia + " where doc_sucursal = '" + suc + "' and opc_documento ='" + tip + "' and idclavedoc = " + idClave.ToString();
			ssqlTra += " order by Dia_Linea";

			return ssqlTra;
		}

		public string armarSqlLecturaTraPv(string TablaTra, string suc, string tip, double idClave)
        {

            string ssqlTra = "select ";
            ssqlTra += "TRA_NUMLINEA as Nro";
            ssqlTra += ",tra_codigo as codigo";
            ssqlTra += ",tra_nombre as Descripción";
            ssqlTra += ",tra_cantidad as Cantidad";
            ssqlTra += ",tra_medida as Medida";
            ssqlTra += ",Tra_precuni as PreVtaUni";
            ssqlTra += ",tra_porcendes as PorDscto";
            ssqlTra += ",tra_valordes as ValDesCto";
            ssqlTra += ",Tra_prectot as PreVtaTot";
            //' 08 si es Articulo, Srvicio o Activo Fijo
            ssqlTra += ",tra_quetipo as Tipo";
            //' 09 en esta columna se guradra  si es Talla, Serie o Ninguno
            ssqlTra += ",Tra_individual as Individual";
            ssqlTra += ",TRA_SNIVA as SnIva";
            ssqlTra += ",tra_costuni as CostoUnit";
            ssqlTra += ",Tra_CostTot as CostoTot";
            ssqlTra += ",tra_piezas as Piezas";
            ssqlTra += ",tra_peso as Peso";
            //' 18 múltiplo  para facturación multimedida
            ssqlTra += ",tra_multiplo as Multi";
            ssqlTra += ",tra_nrolote as NroLote";
            //' 20 Bodega para facturacion con multiple bodega
            ssqlTra += ",Doc_Bodega as Bodega";
            ssqlTra += ",Despacho as Despacho";
            //' 24 fecha de caducidad
            ssqlTra += ",Tra_serie as NroSerie";
            ssqlTra += ",tra_numprecio ";

            ssqlTra += ",0.00 as saldo ";
            ssqlTra += ",0.00 as costoPromedio ";
            ssqlTra += ",0.00 as ultimoCosto ";
            ssqlTra += ",tra_EsCuenta ";

            ssqlTra += " from " + TablaTra + " where doc_sucursal = '" + suc + "' and opc_documento ='" + tip + "' and idclavedoc = " + idClave.ToString();
            ssqlTra += " order by opc_documento,idclavedoc,tra_numlinea";

            return ssqlTra;
        }
        //public string armarSqlLecturaTraFac(string TablaTra, string suc, string tip, double idClave)
        //{
        //    string ssqlTra = "select ";
        //    ssqlTra += "TRA_NUMLINEA as Nro";
        //    ssqlTra += ",tra_codigo as codigo";
        //    ssqlTra += ",tra_nombre as Descripción";
        //    ssqlTra += ",FacDesde as FecDesde";
        //    ssqlTra += ",FacHasta as FecHasta";
        //    ssqlTra += ",tra_cantidad as Cantidad";
        //    ssqlTra += ",tra_medida as Medida";
        //    ssqlTra += ",Tra_precuni as PreVtaUni";
        //    ssqlTra += ",tra_porcendes as PorDscto";
        //    ssqlTra += ",tra_valordes as ValDesCto";
        //    ssqlTra += ",Tra_prectot as PreVtaTot";
        //    //' 08 si es Articulo, Srvicio o Activo Fijo
        //    ssqlTra += ",tra_quetipo as Tipo";
        //    //' 09 en esta columna se guradra  si es Talla, Serie o Ninguno
        //    ssqlTra += ",Tra_individual as Individual";
        //    ssqlTra += ",TRA_SNIVA as SnIva";
        //    ssqlTra += ",tra_costuni as CostoUnit";
        //    ssqlTra += ",Tra_CostTot as CostoTot";
        //    ssqlTra += ",tra_piezas as Piezas";
        //    ssqlTra += ",tra_peso as Peso";
        //    //' 18 múltiplo  para facturación multimedida
        //    ssqlTra += ",tra_multiplo as Multi";
        //    ssqlTra += ",tra_nrolote as NroLote";
        //    //' 20 Bodega para facturacion con multiple bodega
        //    ssqlTra += ",Doc_Bodega as Bodega";
        //    ssqlTra += ",Despacho as Despacho";
        //    //' 24 fecha de caducidad
        //    ssqlTra += ",Tra_vence as Caduca";
        //    ssqlTra += ",Tra_serie as NroSerie";
        //    ssqlTra += ",tra_SucDestino as SucDest";
        //    ssqlTra += ",tra_BodDestino as BodDest";
        //    ssqlTra += ",tra_costo as CentCosto";
        //    ssqlTra += ",tra_empleado as Empleado";
        //    ssqlTra += ",tra_centroProduccion as CentProd";
        //    ssqlTra += ",tra_centroDistribucion as CentDistr";
        //    ssqlTra += ",tra_Proyecto as Proyecto";
        //    ssqlTra += ",tra_numprecio ";
        //    ssqlTra += ", Tra_Talla";
        //    ssqlTra += ", Tra_Color";
        //    ssqlTra += ", Tra_Dibujo";
        //    ssqlTra += ", Tra_Genero";
        //    ssqlTra += ", Tra_Modelo";
        //    ssqlTra += ",0.00 as saldo ";
        //    ssqlTra += ",0.00 as costoPromedio ";
        //    ssqlTra += ",0.00 as ultimoCosto ";
        //    ssqlTra += ",tra_EsCuenta ";

        //    ssqlTra += " from " + TablaTra + " where doc_sucursal = '" + suc + "' and opc_documento ='" + tip + "' and idclavedoc = " + idClave.ToString();
        //    ssqlTra += " order by opc_documento,idclavedoc,tra_numlinea";

        //    return ssqlTra;
        //}
        public string armarSqlLecturaTraPedCliFlor(string TablaTra, string suc, string tip, double idClave, ref int colIniOculta)
        {

            string ssqlTra = "select ";


            ssqlTra += " Tra_numlinea";
            ssqlTra += ", NroCaja";
            ssqlTra += ", CantCajas";
            ssqlTra += ", TipCaja";
            ssqlTra += ", Fulls";
            ssqlTra += ", Tra_Codigo";
            ssqlTra += ", Tra_nombre";
            ssqlTra += ", RamXcaja";
            ssqlTra += ", Tra_cantidad";
            ssqlTra += ", Tra_precuni";
            ssqlTra += ", Tra_prectot";

            ssqlTra += ", tra_peso";
            ssqlTra += ", totPeso";
            ssqlTra += ", TallXramo";
            ssqlTra += ", Largo";
            ssqlTra += ", Tallos";
            ssqlTra += ", ZonaProducto";
            ssqlTra += ", Doc_Bodega";
            ssqlTra += ", DetalleItm";


            colIniOculta = 15;
            ssqlTra += ", Ramos";
            ssqlTra += " Doc_sucursal";
            ssqlTra += ", Opc_documento";
            ssqlTra += ", Doc_numero";
            ssqlTra += ", Tra_TipoDoc";
            ssqlTra += ", Tra_DocSop";
            ssqlTra += ", Tra_NumSop";
            ssqlTra += ", Tra_docotro";
            ssqlTra += ", Tra_numotro";
            ssqlTra += ", Tra_fecha";
            ssqlTra += ", Tra_costuni";
            ssqlTra += ", Tra_costtot";
            ssqlTra += ", Tra_numprecio";
            ssqlTra += ", Tra_descdes";
            ssqlTra += ", Tra_porcendes";
            ssqlTra += ", Tra_valordes";
            ssqlTra += ", Tra_valor";
            ssqlTra += ", Tra_extension";
            ssqlTra += ", Tra_sniva";
            ssqlTra += ", Tra_Individual";
            ssqlTra += ", Tra_quetipo";
            ssqlTra += ", Tra_DepDes";
            ssqlTra += ", Tra_Estado";
            ssqlTra += ", Tra_Oculto";
            ssqlTra += ",Tra_Inventario";
            ssqlTra += ", Tra_Ventas";
            ssqlTra += ", Tra_Compras";
            ssqlTra += ", Tra_Activo";
            ssqlTra += ", Tra_piezas";
            ssqlTra += ", Tra_medida";
            ssqlTra += ", Tra_multiplo";
            ssqlTra += ", Tra_vence";
            ssqlTra += ", IdClaveDoc";
            ssqlTra += ", Tra_NroLote";
            ssqlTra += ", Tra_NroLoteDoc";
            //ssqlTra += ", tra_serie";
            //ssqlTra += ", Periodo1";
            //ssqlTra += ", Periodo2";
            //ssqlTra += ", FacDesde";
            //ssqlTra += ", FacHasta";
            //ssqlTra += ", Habitacion";
            //ssqlTra += ", Mesa";
            ssqlTra += ", TipoPeriodo";
            ssqlTra += ", AuxVar1";
            ssqlTra += ", ord_numero";
            ssqlTra += ", NumeroHoras";
            ssqlTra += ", CostoHora";
            ssqlTra += ", CostoMatPrima";
            ssqlTra += ", PorcUtilidad";
            ssqlTra += ", CostosIndirectos";
            ssqlTra += ", CostosTerceros";
            ssqlTra += ", TipoCosto";
            ssqlTra += ", Recosteo";
            ssqlTra += ", tra_costo";
            ssqlTra += ", tra_empleado";
            ssqlTra += ", tra_directorio";
            ssqlTra += ", tra_dia_proyecto";
            ssqlTra += ", tra_relacionado";
            ssqlTra += ", tra_codigoalterno";
            ssqlTra += ", Tra_EsCuenta";
            ssqlTra += ", tra_producto";
            ssqlTra += ", tra_centroproduccion";
            ssqlTra += ", tra_centroDistribucion";
            ssqlTra += ", tra_proyecto";
            ssqlTra += ", Despacho";
            ssqlTra += ", tra_boddestino";
            ssqlTra += ", tra_sucdestino";
            ssqlTra += ",HTS";
            ssqlTra += ", Nandina";
            //ssqlTra += ",Tra_Talla";
            //ssqlTra += ", Tra_Color";
            //ssqlTra += ", Tra_Dibujo";
            //ssqlTra += ", Tra_Genero";
            //ssqlTra += ", Tra_Modelo";
            //ssqlTra += ", Tra_Despachado";
            ssqlTra += ",'' as variedad";

            ssqlTra += " from "+TablaTra+" where doc_sucursal = '" + suc + "' and opc_documento ='" + tip + "' and idclavedoc = " + idClave.ToString();
            ssqlTra += " order by opc_documento,idclavedoc,tra_numlinea";

            return ssqlTra;
        }
        public string armarSqlLecturaTraFacConsolida(string TablaTra, string doctosConsolidar)
        {
            string ssqlTra = "select ";
            ssqlTra += "0 as Nro";
            ssqlTra += ",tra_codigo as codigo";
            ssqlTra += ",max(tra_nombre) as Descripción";
            ssqlTra += ",max(FacDesde) as FecDesde";
            ssqlTra += ",max(FacHasta) as FecHasta";
            ssqlTra += ",sum(tra_cantidad * -1 * (case when tra_inventario<>0 then tra_inventario else tra_ventas end)) as Cantidad";
            ssqlTra += ",tra_medida as Medida";
            ssqlTra += ",max(Tra_precuni) as PreVtaUni";
            ssqlTra += ",max(tra_porcendes) as PorDscto";
            ssqlTra += ",sum(tra_valordes) as ValDesCto";
            ssqlTra += ",sum(Tra_prectot) as PreVtaTot";
            //' 08 si es Articulo, Srvicio o Activo Fijo
            ssqlTra += ",tra_quetipo as Tipo";
            //' 09 en esta columna se guradra  si es Talla, Serie o Ninguno
            ssqlTra += ",max(Tra_individual) as Individual";
            ssqlTra += ",TRA_SNIVA as SnIva";
            ssqlTra += ",max(tra_costuni) as CostoUnit";
            ssqlTra += ",sum(Tra_CostTot) as CostoTot";
            ssqlTra += ",sum(tra_piezas) as Piezas";
            ssqlTra += ",sum(tra_peso) as Peso";
            //' 18 múltiplo  para facturación multimedida
            ssqlTra += ",tra_multiplo as Multi";
            ssqlTra += ",max(tra_nrolote) as NroLote";
            //' 20 Bodega para facturacion con multiple bodega
            ssqlTra += ",max(Doc_Bodega) as Bodega";
            ssqlTra += ",sum(Despacho) as Despacho";
            //' 24 fecha de caducidad
            ssqlTra += ",max(Tra_vence) as Caduca";
            ssqlTra += ",Tra_serie as NroSerie";
            ssqlTra += ",max(tra_SucDestino) as SucDest";
            ssqlTra += ",max(tra_BodDestino) as BodDest";
            ssqlTra += ",tra_costo as CentCosto";
            ssqlTra += ",tra_empleado as Empleado";
            ssqlTra += ",tra_centroProduccion as CentProd";
            ssqlTra += ",tra_centroDistribucion as CentDistr";
            ssqlTra += ",tra_Proyecto as Proyecto";
            ssqlTra += ", Tra_Talla";
            ssqlTra += ", Tra_Color";
            ssqlTra += ", Tra_Dibujo";
            ssqlTra += ", Tra_Genero";
            ssqlTra += ", Tra_Modelo";
            ssqlTra += ",0.00 as saldo ";
            ssqlTra += ",0.00 as costoPromedio ";
            ssqlTra += ",0.00 as ultimoCosto ";
            ssqlTra += ",tra_EsCuenta ";
            ssqlTra += ",max(tra_numprecio) as tra_numprecio";

            ssqlTra += " from " + TablaTra + " where doc_sucursal+opc_documento+cast(idclavedoc as varchar(20)) in (" + doctosConsolidar + ")";
 
            ssqlTra += "GROUP BY Tra_medida";
            ssqlTra += ",Tra_Codigo";
            ssqlTra += ",Tra_sniva";
            ssqlTra += ",Tra_quetipo";
            ssqlTra += ", tra_escuenta";
            ssqlTra += ",Tra_multiplo";
            ssqlTra += ", tra_Serie";
            ssqlTra += ", tra_costo";
            ssqlTra += ", tra_centroproduccion";
            ssqlTra += ", tra_empleado";
            ssqlTra += ", tra_directorio";
            ssqlTra += ", tra_dia_proyecto";
            ssqlTra += ", tra_relacionado";
            ssqlTra += ", tra_centroDistribucion";
            ssqlTra += ", tra_proyecto";
            ssqlTra += ", Tra_Talla";
            ssqlTra += ", Tra_Color";
            ssqlTra += ", Tra_Dibujo";
            ssqlTra += ", Tra_Genero";
            ssqlTra += ", Tra_Modelo";
            return ssqlTra;
        }
    }
}
