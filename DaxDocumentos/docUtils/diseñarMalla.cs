using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using DattCom;

namespace DctosEmi
{
	public class diseñarMalla
	{	
		public void diseñarMallaFacPv(ref System.Windows.Forms.DataGridView malla, ref sesSys.OpcDoc propedadesDocmto, daxAccs.propiedadesDaxAuto accesosLocalizados = null)
		{
			if (malla == null) return;

			// ✅ ASEGURAR QUE LOS VALORES ESTÉN CARGADOS
			if (valoresPredefinidosEmpresa.nroDigitosEnPrecios == 0)
			{
				valoresPredefinidosEmpresa.cargaValores();
			}

			short digPreciosV = valoresPredefinidosEmpresa.nroDigitosEnPrecios;
			short digCostosV = valoresPredefinidosEmpresa.nroDigitosEnCostos;

			// =============================
			// ESTILOS GENERALES
			// =============================
			malla.BackgroundColor = Color.White;
			malla.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
			malla.RowHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
			malla.RowHeadersDefaultCellStyle.ForeColor = Color.White;
			malla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
			malla.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			malla.RowHeadersWidth = 20;

			foreach (DataGridViewColumn column in malla.Columns)
			{
				column.SortMode = DataGridViewColumnSortMode.NotSortable;
				column.Visible = false;

				if (column.ValueType?.Name.ToUpper() == "DATETIME")
					column.DefaultCellStyle.Format = "dd/MMM/yyyy";
			}

			// =============================
			// HEADERS
			// =============================
			malla.Columns["tra_codigo"].HeaderText = "Codigo";
			malla.Columns["tra_nombre"].HeaderText = "Descripción";
			malla.Columns["tra_cantidad"].HeaderText = "Cantidad";
			malla.Columns["Tra_precuni"].HeaderText = "P.Unitario";
			malla.Columns["tra_porcendes"].HeaderText = "% Dscto";
			malla.Columns["tra_valordes"].HeaderText = "Descto";
			malla.Columns["Tra_prectot"].HeaderText = "PrecTotal";
			malla.Columns["Tra_porceniva"].HeaderText = "PorceIva";
			malla.Columns["Tra_valoriva"].HeaderText = "ValorIva";
			malla.Columns["TRA_SNIVA"].HeaderText = "IVA";
			malla.Columns["tra_medida"].HeaderText = "Med.";
			malla.Columns["TRA_NUMLINEA"].HeaderText = "Nro";

			// =============================
			// VISIBILIDAD
			// =============================
			malla.Columns["tra_codigo"].Visible = true;
			malla.Columns["tra_nombre"].Visible = true;
			malla.Columns["tra_cantidad"].Visible = true;
			malla.Columns["Tra_precuni"].Visible = true;
			malla.Columns["Tra_prectot"].Visible = true;
			malla.Columns["Tra_porceniva"].Visible = true;
			malla.Columns["Tra_valoriva"].Visible = true;

			malla.Columns["Serv"].Visible = datosAuxiliares.tieneDatoDetalle("FormaServicio", propedadesDocmto);
			malla.Columns["TRA_SNIVA"].Visible = datosAuxiliares.tieneDatoDetalle("Iva", propedadesDocmto);
			malla.Columns["Existencia"].Visible = datosAuxiliares.tieneDatoDetalle("Existencia", propedadesDocmto);
			malla.Columns["tra_porcendes"].Visible = datosAuxiliares.tieneDatoDetalle("DescuentoArtículo", propedadesDocmto);

			// =============================
			// SOLO LECTURA FIJOS
			// =============================
			malla.Columns["Tra_prectot"].ReadOnly = true;
			malla.Columns["TRA_NUMLINEA"].ReadOnly = true;
			malla.Columns["Tra_valoriva"].ReadOnly = true;

			// =============================
			// FORMATOS
			// =============================
			//short digPreciosV = valoresPredefinidosEmpresa.nroDigitosEnPrecios;
			malla.Columns["Tra_precuni"].DefaultCellStyle.Format = $"N{digPreciosV}";

			malla.Columns["TRA_NUMLINEA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			malla.Columns["tra_codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			//malla.Columns["tra_nombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


			// =========================================================
			// 🔥 NUEVA LÓGICA DE SEGURIDAD
			// =========================================================

			bool esAdmin = datosEmpresa.usr?.ToUpper() == "ADMINISTRADOR";

			// ✅ ADMIN → NO aplicar restricciones
			if (esAdmin)
				return;

			// Si no hay permisos configurados, salir
			if (accesosLocalizados == null) return;
			if (accesosLocalizados.sinRegistro) return;


			// =========================================================
			// USUARIOS NORMALES → aplicar permisos
			// =========================================================

			if (malla.Columns.Contains("Tra_precuni"))
				malla.Columns["Tra_precuni"].ReadOnly = !accesosLocalizados.PrecioUnitario;

			if (malla.Columns.Contains("tra_porcendes"))
				malla.Columns["tra_porcendes"].ReadOnly = !accesosLocalizados.DescuentoUnitario;

			if (malla.Columns.Contains("tra_valordes"))
				malla.Columns["tra_valordes"].ReadOnly = !accesosLocalizados.DescuentoUnitario;

			if (malla.Columns.Contains("tra_nombre"))
				malla.Columns["tra_nombre"].ReadOnly = !accesosLocalizados.DetalleProducto;
		}


		public void diseñarMallaFacPvT(ref System.Windows.Forms.DataGridView malla, ref sesSys.OpcDoc propedadesDocmto, daxAccs.propiedadesDaxAuto accesosLocalizados = null)
		{
			malla.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
			malla.RowHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
			malla.RowHeadersDefaultCellStyle.ForeColor = Color.White;
			malla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
			malla.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			malla.RowHeadersWidth = 25;           
			

			foreach (DataGridViewColumn column in malla.Columns)
			{
				column.SortMode = DataGridViewColumnSortMode.NotSortable;
				column.Visible = false;
				if (column.ValueType.Name.ToUpper() == "DATETIME") column.DefaultCellStyle.Format = "dd/MMM/yyyy";
			}

			malla.Columns["tra_codigo"].HeaderText = "Codigo";
			malla.Columns["tra_nombre"].HeaderText = "Descripción";
			malla.Columns["tra_cantidad"].HeaderText = "Cant";
			malla.Columns["Tra_precuni"].HeaderText = "Pv.Uni";
			malla.Columns["tra_porcendes"].HeaderText = "Dsct";
			malla.Columns["tra_valordes"].HeaderText = "Descto";
			malla.Columns["Tra_prectot"].HeaderText = "PvTotal";
			//malla.Columns["CantC"].HeaderText = "CantPl";
			//malla.Columns["TRA_SNIVA"].HeaderText = "IVA";
			//malla.Columns["tra_medida"].HeaderText = "Med.";
			//malla.Columns["TRA_NUMLINEA"].HeaderText = "Nro";

			//malla.Columns["tra_codigo"].Visible = true;
			malla.Columns["tra_nombre"].Visible = true;
			malla.Columns["tra_cantidad"].Visible = true;
			malla.Columns["Tra_precuni"].Visible = true;
			malla.Columns["Tra_prectot"].Visible = true;
			malla.Columns["Serv"].Visible = datosAuxiliares.tieneDatoDetalle("FormaServicio", propedadesDocmto);
			malla.Columns["CtP"].Visible = false;
			malla.Columns["Cmb"].Visible = datosAuxiliares.tieneDatoDetalle("Preferencia", propedadesDocmto);
			
			malla.Columns["COMP"].HeaderText = "COMP";
			malla.Columns["COMP"].Visible = false;
			malla.Columns["Tra_Despachado"].HeaderText = "Plato";
			malla.Columns["Tra_Despachado"].Visible = false;
			malla.Columns["CORT"].Visible = true;

			

			
			

			//malla.Columns["TRA_SNIVA"].Visible = datosAuxiliares.tieneDatoDetalle("Iva", propedadesDocmto);
			//malla.Columns["Existencia"].Visible = datosAuxiliares.tieneDatoDetalle("Existencia", propedadesDocmto);
			malla.Columns["tra_porcendes"].Visible = datosAuxiliares.tieneDatoDetalle("DescuentoArtículo", propedadesDocmto);
			malla.Columns["Tra_prectot"].ReadOnly = true;
			malla.Columns["Serv"].ReadOnly = true;
			malla.Columns["Cmb"].ReadOnly = true;
			malla.Columns["CORT"].ReadOnly = true;
			//malla.Columns["TRA_NUMLINEA"].ReadOnly = true;
			float size = 7;              
			malla.Columns["tra_nombre"].DefaultCellStyle.Font = new Font("Arial",size);
			malla.Columns["Serv"].DefaultCellStyle.Font = new Font("Arial", size); ;
            malla.Columns["Cmb"].DefaultCellStyle.Font = new Font("Arial", size); ;
			malla.Columns["CtP"].DefaultCellStyle.Format = "N2"; ;
			malla.Columns["COMP"].DefaultCellStyle.Font = new Font("Arial", size); ;
			
			

			malla.Columns["tra_cantidad"].DefaultCellStyle.Format="N0";
			malla.Columns["tra_porcendes"].DefaultCellStyle.Format = "N1";
			malla.Columns["tra_nombre"].Width  = 200;
			malla.Columns["tra_cantidad"].Width = 35;
			malla.Columns["Tra_precuni"].Width = 60;
			malla.Columns["tra_porcendes"].Width = 35;
			malla.Columns["Tra_prectot"].Width = 80;
			malla.Columns["Serv"].Width = 40;
			malla.Columns["Cmb"].Width = 40;
			malla.Columns["CtP"].Width = 30;
			malla.Columns["CORT"].Width = 40;
			malla.Columns["COMP"].Width = 40;

			malla.Columns["TRA_NUMLINEA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			malla.Columns["tra_codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			malla.Columns["tra_nombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			malla.Columns["Serv"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			malla.Columns["Cmb"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			malla.Columns["CtP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			malla.Columns["COMP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

			malla.Columns["Tra_precuni"].ReadOnly = true; // (accesosLocalizados.PrecioUnitario == false);
           // malla.Columns["tra_porcendes"].ReadOnly = (accesosLocalizados.DescuentoUnitario == false);
           // malla.Columns["tra_valordes"].ReadOnly = (accesosLocalizados.DescuentoUnitario == false);
            malla.Columns["tra_nombre"].ReadOnly = true; // (accesosLocalizados.DetalleProducto == false);

            if (accesosLocalizados == null) return;
			if (accesosLocalizados.sinRegistro == true) return;

            malla.Columns["Tra_precuni"].ReadOnly = true; // (accesosLocalizados.PrecioUnitario == false);
            malla.Columns["tra_nombre"].ReadOnly = true; // (accesosLocalizados.DetalleProducto == false);
            try
            {
                malla.Columns["tra_valordes"].ReadOnly = (accesosLocalizados.DescuentoUnitario == false);
                malla.Columns["tra_porcendes"].ReadOnly = (accesosLocalizados.DescuentoUnitario == false);
            }
            catch { };
			malla.Columns["Tra_valoriva"].ReadOnly = true;
		}

		public void diseñarMallaMovPrep(ref System.Windows.Forms.DataGridView malla, ref sesSys.OpcDoc propedadesDocmto)
		{
			malla.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
			malla.RowHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
			malla.RowHeadersDefaultCellStyle.ForeColor = Color.White;
			malla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
			malla.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			malla.RowHeadersWidth = 20;

			malla.Columns["Dia_linea"].Visible = false;
			malla.Columns["Dia_Signo"].Visible = false;
			malla.Columns["Dia_Valor"].Visible = false;

			if (datosAuxiliares.tieneDatoDetalle("Centro Costo", propedadesDocmto)) malla.Columns["tra_Costo"].HeaderText = "Centro Costo";
			if (datosAuxiliares.tieneDatoDetalle("Empleado", propedadesDocmto)) malla.Columns["tra_empleado"].HeaderText = "Empleado";
			if (datosAuxiliares.tieneDatoDetalle("Centro Producción", propedadesDocmto)) malla.Columns["tra_centroProduccion"].HeaderText = "Cent.Producci";
			if (datosAuxiliares.tieneDatoDetalle("Centro Distribución", propedadesDocmto)) malla.Columns["tra_centroDistribucion"].HeaderText = "Cent.Distribuc";
			if (datosAuxiliares.tieneDatoDetalle("Proyecto", propedadesDocmto)) malla.Columns["tra_Proyecto"].HeaderText = "Proyecto";
            if (datosAuxiliares.tieneDatoDetalle("Proyecto", propedadesDocmto)) malla.Columns["tra_Proyecto"].HeaderText = "Proyecto";

            malla.Columns["Cta_codigo"].HeaderText = "Cuenta";
			malla.Columns["Dia_ctanombre"].HeaderText = "Descripción Presupuesto";
			malla.Columns["Dia_detalle"].HeaderText = "Detalle del cambio";
			malla.Columns["valordebito"].HeaderText = "Débitos";
			malla.Columns["valorcredito"].HeaderText = "Créditos";

			malla.Columns["Cta_codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			malla.Columns["Dia_ctanombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			malla.Columns["Dia_detalle"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			foreach (DataGridViewColumn column in malla.Columns)
			{
				column.SortMode = DataGridViewColumnSortMode.NotSortable;
			}

		}

		public void diseñarMallaFacCli(ref System.Windows.Forms.DataGridView malla, ref sesSys.OpcDoc propDocto)
		{
			malla.RowHeadersWidth = 20;

			malla.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
			malla.RowHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
			malla.RowHeadersDefaultCellStyle.ForeColor = Color.White;
			malla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
			malla.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			malla.RowHeadersWidth = 50;

			malla.Columns["Codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			malla.Columns["Descripción"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			malla.Columns["Medida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			malla.Columns["Nro"].Visible = false;
			malla.Columns["Medida"].Visible = false;
			malla.Columns["PorDscto"].Visible = false;
			malla.Columns["ValDesCto"].Visible = false;
			malla.Columns["Tipo"].Visible = false;
			malla.Columns["Individual"].Visible = false;
			malla.Columns["SnIva"].Visible = false;
			malla.Columns["CostoUnit"].Visible = false;
			malla.Columns["CostoTot"].Visible = false;
			malla.Columns["NroSerie"].Visible = false;
			malla.Columns["Piezas"].Visible = false;
			malla.Columns["Peso"].Visible = false;
			malla.Columns["Multi"].Visible = false;
			malla.Columns["NroLote"].Visible = false;
			malla.Columns["Bodega"].Visible = false;
			malla.Columns["Despacho"].Visible = false;
			malla.Columns["tra_numprecio"].Visible = false;
			malla.Columns["Saldo"].Visible = false;
			malla.Columns["tra_numprecio"].Visible = false;
			malla.Columns["costoPromedio"].Visible = false;
			malla.Columns["ultimoCosto"].Visible = false;
			malla.Columns["tra_EsCuenta"].Visible = false;
			malla.Columns["caduca"].Visible = false;
			malla.Columns["sucDest"].Visible = false;
			malla.Columns["BodDest"].Visible = false;
			malla.Columns["Empleado"].Visible = false;
			malla.Columns["CentCosto"].Visible = false;
			malla.Columns["centProd"].Visible = false;
			malla.Columns["centDistr"].Visible = false;
			malla.Columns["Proyecto"].Visible = false;
			malla.Columns["tra_talla"].Visible = false;
			malla.Columns["tra_Color"].Visible = false;
			malla.Columns["tra_Genero"].Visible = false;
			malla.Columns["tra_Dibujo"].Visible = false;
			malla.Columns["tra_Modelo"].Visible = false;
			malla.Columns["FecDesde"].Visible = false;
			malla.Columns["FecHasta"].Visible = false;
			malla.Columns["PreVtaTot"].ReadOnly = true;
			foreach (DataGridViewColumn column in malla.Columns)
			{
				column.SortMode = DataGridViewColumnSortMode.NotSortable;
			}

		}

		public void diseñarMallaPedCliFlor(ref System.Windows.Forms.DataGridView malla, ref sesSys.OpcDoc propDocto)
		{
			
			malla.RowHeadersWidth = 20;

			malla.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
			malla.RowHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
			malla.RowHeadersDefaultCellStyle.ForeColor = Color.White;
			malla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
			malla.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			malla.RowHeadersWidth = 50;

			malla.Columns["tra_Codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			malla.Columns["Tra_nombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			malla.Columns["Tra_medida"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


			malla.Columns["NroCaja"].HeaderText = "Caja";
			malla.Columns["CantCajas"].HeaderText = "Cant";
			malla.Columns["TipCaja"].HeaderText = "Tipo";
			malla.Columns["Fulls"].HeaderText = "Full";
			malla.Columns["Tra_Codigo"].HeaderText = "Codigo";
			malla.Columns["Tra_nombre"].HeaderText = "Variedad";
			malla.Columns["RamXcaja"].HeaderText = "RmCaja";
			malla.Columns["Tra_cantidad"].HeaderText = "Ramos";
			malla.Columns["Tra_precuni"].HeaderText = "PvUnid";
			malla.Columns["Tra_prectot"].HeaderText = "PvTotal";

			malla.Columns["TallXramo"].HeaderText = "TallRm";
			malla.Columns["Tallos"].HeaderText = "Tallos";
			malla.Columns["Largo"].HeaderText = "Alto";
			malla.Columns["tra_peso"].HeaderText = "GramRm";
			malla.Columns["doc_bodega"].HeaderText = "BOD";
			malla.Columns["ZonaProducto"].HeaderText = "ZON";
			malla.Columns["DetalleItm"].HeaderText = "Observaciones";
			malla.Columns["Tra_sniva"].HeaderText = "IVA";

			//colIniOculta = 15;

			// malla.Columns["Ramos"].Visible = false;
			malla.Columns["Tra_numlinea"].Visible = false;
			malla.Columns["Doc_sucursal"].Visible = false;
			//malla.Columns["Doc_Bodega"].Visible = false;
			malla.Columns["Opc_documento"].Visible = false;
			malla.Columns["Doc_numero"].Visible = false;
			malla.Columns["Tra_TipoDoc"].Visible = false;
			malla.Columns["Tra_DocSop"].Visible = false;
			malla.Columns["Tra_NumSop"].Visible = false;
			malla.Columns["Tra_docotro"].Visible = false;
			malla.Columns["Tra_numotro"].Visible = false;
			malla.Columns["Tra_fecha"].Visible = false;
			malla.Columns["Tra_costuni"].Visible = false;
			malla.Columns["Tra_costtot"].Visible = false;
			malla.Columns["Tra_numprecio"].Visible = false;
			malla.Columns["Tra_descdes"].Visible = false;
			malla.Columns["Tra_porcendes"].Visible = false;
			malla.Columns["Tra_valordes"].Visible = false;
			malla.Columns["Tra_valor"].Visible = false;
			malla.Columns["Tra_extension"].Visible = false;
			//malla.Columns["Tra_sniva"].Visible = false;
			malla.Columns["Tra_Individual"].Visible = false;
			malla.Columns["Tra_quetipo"].Visible = false;
			malla.Columns["Tra_DepDes"].Visible = false;
			malla.Columns["Tra_Estado"].Visible = false;
			malla.Columns["Tra_Oculto"].Visible = false;
			malla.Columns["Tra_Inventario"].Visible = false;
			malla.Columns["Tra_Ventas"].Visible = false;
			malla.Columns["Tra_Compras"].Visible = false;
			malla.Columns["Tra_Activo"].Visible = false;
			malla.Columns["Tra_piezas"].Visible = false;
			malla.Columns["Tra_medida"].Visible = false;
			malla.Columns["Tra_multiplo"].Visible = false;
			malla.Columns["Tra_vence"].Visible = false;
			//malla.Columns["tra_serie"].Visible = false;
			malla.Columns["IdClaveDoc"].Visible = false;
			malla.Columns["Tra_NroLote"].Visible = false;
			malla.Columns["Tra_NroLoteDoc"].Visible = false;
			//malla.Columns["Periodo1"].Visible = false;
			//malla.Columns["Periodo2"].Visible = false;
			//malla.Columns["FacDesde"].Visible = false;
			//malla.Columns["FacHasta"].Visible = false;
			//malla.Columns["Habitacion"].Visible = false;
			//malla.Columns["Mesa"].Visible = false;
			malla.Columns["TipoPeriodo"].Visible = false;
			malla.Columns["AuxVar1"].Visible = false;
			malla.Columns["ord_numero"].Visible = false;
			malla.Columns["NumeroHoras"].Visible = false;
			malla.Columns["CostoHora"].Visible = false;
			malla.Columns["CostoMatPrima"].Visible = false;
			malla.Columns["PorcUtilidad"].Visible = false;
			malla.Columns["CostosIndirectos"].Visible = false;
			malla.Columns["CostosTerceros"].Visible = false;
			//malla.Columns["ZonaProducto"].Visible = false;
			malla.Columns["TipoCosto"].Visible = false;
			malla.Columns["Recosteo"].Visible = false;
			malla.Columns["tra_costo"].Visible = false;
			malla.Columns["tra_empleado"].Visible = false;
			malla.Columns["tra_directorio"].Visible = false;
			malla.Columns["tra_dia_proyecto"].Visible = false;
			malla.Columns["tra_relacionado"].Visible = false;
			malla.Columns["tra_codigoalterno"].Visible = false;
			malla.Columns["Tra_EsCuenta"].Visible = false;
			malla.Columns["tra_producto"].Visible = false;
			malla.Columns["tra_centroproduccion"].Visible = false;
			malla.Columns["tra_centroDistribucion"].Visible = false;
			malla.Columns["tra_proyecto"].Visible = false;
			malla.Columns["Despacho"].Visible = false;
			malla.Columns["tra_boddestino"].Visible = false;
			malla.Columns["tra_sucdestino"].Visible = false;
			malla.Columns["HTS"].Visible = false;
			malla.Columns["Nandina"].Visible = false;
			//malla.Columns["Tra_Talla"].Visible = false;
			//malla.Columns["Tra_Color"].Visible = false;
			//malla.Columns["Tra_Dibujo"].Visible = false;
			//malla.Columns["Tra_Genero"].Visible = false;
			//malla.Columns["Tra_Modelo"].Visible = false;
			//malla.Columns["Tra_Despachado"].Visible = false;

			malla.Columns["Fulls"].Visible = false;

			malla.Columns["Variedad"].Visible = false;

			malla.Columns["tra_prectot"].ReadOnly = true;
	 //       malla.Columns["TallXramo"].ReadOnly = true;
			malla.Columns["Tallos"].ReadOnly = true;
			malla.Columns["Largo"].ReadOnly = true;
			malla.Columns["tra_peso"].ReadOnly = true;
			malla.Columns["totPeso"].ReadOnly = true;
			malla.Columns["Tra_cantidad"].ReadOnly = true;
			foreach (DataGridViewColumn column in malla.Columns)
			{
				column.SortMode = DataGridViewColumnSortMode.NotSortable;
			}
		}


    }

    public class autorizaMalla
	{

		private void modelaMallaAutorizaciones(ref DataGridView malla,string strConxAdcom,string strConxDaxsys,string idUsuario)
		{         

		}
	}
}
