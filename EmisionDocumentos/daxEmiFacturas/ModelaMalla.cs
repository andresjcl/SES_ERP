using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using DattCom;

namespace DctosEmi
{
    class ModelaMalla
	{


		//public void diseñarMallaFacturas(ref System.Windows.Forms.DataGridView malla, ref sesSys.OpcDoc propedadesDocmto, daxAccs.propiedadesDaxAuto accesosLocalizados = null)
		//{

		//	malla.BackgroundColor = Color.White;
		//	malla.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
		//	malla.RowHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
		//	malla.RowHeadersDefaultCellStyle.ForeColor = Color.White;
		//	malla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
		//	malla.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
		//	malla.RowHeadersWidth = 20;

		//	foreach (DataGridViewColumn column in malla.Columns)
		//	{
		//		column.SortMode = DataGridViewColumnSortMode.NotSortable;
		//		column.Visible = false;
		//		if (column.ValueType.Name.ToUpper() == "DATETIME") column.DefaultCellStyle.Format = "dd/MMM/yyyy";
		//	}

		//	malla.Columns["tra_codigo"].HeaderText = "Codigo";
		//	malla.Columns["tra_nombre"].HeaderText = "Descripción";
		//	malla.Columns["tra_cantidad"].HeaderText = "Cantidad";
		//	malla.Columns["Tra_precuni"].HeaderText = "P.Unitario";
		//	malla.Columns["tra_porcendes"].HeaderText = "% Dscto";
		//	malla.Columns["tra_valordes"].HeaderText = "Descto";
		//	malla.Columns["Tra_prectot"].HeaderText = "PrecTotal";
		//	malla.Columns["Tra_porceniva"].HeaderText = "PorceIva";
		//	malla.Columns["Tra_valoriva"].HeaderText = "ValorIva";
		//	malla.Columns["TRA_SNIVA"].HeaderText = "IVA";
		//	malla.Columns["tra_medida"].HeaderText = "Med.";
		//	malla.Columns["TRA_NUMLINEA"].HeaderText = "Nro";

		//	malla.Columns["tra_codigo"].Visible = true;
		//	malla.Columns["tra_nombre"].Visible = true;
		//	malla.Columns["tra_cantidad"].Visible = true;
		//	malla.Columns["Tra_precuni"].Visible = true;
		//	malla.Columns["Tra_prectot"].Visible = true;
		//	malla.Columns["Tra_porceniva"].Visible = true;
		//	malla.Columns["Tra_valoriva"].Visible = true;
		//	malla.Columns["Serv"].Visible = datosAuxiliares.tieneDatoDetalle("FormaServicio", propedadesDocmto);
		//	//malla.Columns["Cmb"].Visible = datosAuxiliares.tieneDatoDetalle("Preferencia", propedadesDocmto);

		//	malla.Columns["TRA_SNIVA"].Visible = datosAuxiliares.tieneDatoDetalle("Iva", propedadesDocmto);
		//	malla.Columns["Existencia"].Visible = datosAuxiliares.tieneDatoDetalle("Existencia", propedadesDocmto);
		//	malla.Columns["tra_porcendes"].Visible = datosAuxiliares.tieneDatoDetalle("DescuentoArtículo", propedadesDocmto);


		//	if (datosAuxiliares.tieneDatoDetalle("PeriodoLiquidación", propedadesDocmto))
		//	{
		//		malla.Columns["FacDesde"].HeaderText = "Fec.Desde";
		//		malla.Columns["FacHasta"].HeaderText = "Fec.Hasta";
		//		malla.Columns["FacDesde"].Visible = true;
		//		malla.Columns["FacHasta"].Visible = true;
		//	}
		//	if (datosAuxiliares.tieneDatoDetalle("DespachoInmediato", propedadesDocmto))
		//	{
		//		malla.Columns["despacho"].Visible = true;
		//		malla.Columns["despacho"].HeaderText = "Despacho";
		//	}
		//	if (datosAuxiliares.tieneDatoDetalle("UnidadMedida", propedadesDocmto))
		//	{
		//		malla.Columns["tra_medida"].HeaderText = "Medida";
		//		malla.Columns["tra_medida"].Visible = true;
		//		malla.Columns["tra_medida"].ReadOnly = true;
		//	}
		//	if (datosAuxiliares.tieneDatoDetalle("Piezas", propedadesDocmto))
		//	{
		//		malla.Columns["tra_piezas"].HeaderText = "Piezas";
		//		malla.Columns["tra_piezas"].Visible = true;
		//	}
		//	if (datosAuxiliares.tieneDatoDetalle("Peso", propedadesDocmto))
		//	{
		//		malla.Columns["tra_peso"].HeaderText = "Peso";
		//		malla.Columns["tra_peso"].Visible = true;
		//	}
		//	if (datosAuxiliares.tieneDatoDetalle("LoteProducto", propedadesDocmto))
		//	{
		//		malla.Columns["tra_nrolote"].HeaderText = "Nro Lote";
		//		malla.Columns["tra_nrolote"].Visible = true;
		//	}

		//	if (datosAuxiliares.tieneDatoDetalle("BodegaMovimiento", propedadesDocmto))
		//	{
		//		malla.Columns["Doc_Bodega"].HeaderText = "BOD";
		//		malla.Columns["Doc_Bodega"].Visible = true;
		//	}
		//	if (datosAuxiliares.tieneDatoDetalle("FechaCaducidad", propedadesDocmto))
		//	{
		//		malla.Columns["Tra_vence"].HeaderText = "Caducidad";
		//		malla.Columns["Tra_vence"].Visible = true;
		//	}
		//	if (datosAuxiliares.tieneDatoDetalle("Centro Costo", propedadesDocmto))
		//	{
		//		malla.Columns["tra_Costo"].HeaderText = "Centro Costo";
		//		malla.Columns["tra_Costo"].Visible = true;
		//	}
		//	if (datosAuxiliares.tieneDatoDetalle("Empleado", propedadesDocmto))
		//	{
		//		malla.Columns["tra_empleado"].HeaderText = "Empleado";
		//		malla.Columns["tra_empleado"].Visible = true;
		//	}
		//	if (datosAuxiliares.tieneDatoDetalle("Centro Producción", propedadesDocmto))
		//	{
		//		malla.Columns["tra_centroProduccion"].HeaderText = "Cent.Producci";
		//		malla.Columns["tra_centroProduccion"].Visible = true;
		//	}
		//	if (datosAuxiliares.tieneDatoDetalle("Centro Distribución", propedadesDocmto))
		//	{
		//		malla.Columns["tra_centroDistribucion"].HeaderText = "Cent.Distribuc";
		//		malla.Columns["tra_centroDistribucion"].Visible = true;
		//	}
		//	if (datosAuxiliares.tieneDatoDetalle("Proyecto", propedadesDocmto))
		//	{
		//		malla.Columns["tra_Proyecto"].HeaderText = "Proyecto";
		//		malla.Columns["tra_Proyecto"].Visible = true;
		//	}

		//	malla.Columns["Tra_prectot"].ReadOnly = true;
		//	malla.Columns["TRA_NUMLINEA"].ReadOnly = true;

		//	malla.Columns["TRA_NUMLINEA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		//	malla.Columns["tra_codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		//	malla.Columns["tra_nombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

		//	//malla.Columns["Tra_precuni"].ReadOnly = false; // (accesosLocalizados.PrecioUnitario == false);
		//												   //malla.Columns["tra_porcendes"].ReadOnly = (accesosLocalizados.DescuentoUnitario == false);
		//												   // malla.Columns["tra_valordes"].ReadOnly = (accesosLocalizados.DescuentoUnitario == false);
		//	//malla.Columns["tra_nombre"].ReadOnly = false; // (accesosLocalizados.DetalleProducto == false);

		//	short digPreciosV = valoresPredefinidosEmpresa.nroDigitosEnPrecios;




		//	//malla.Columns["Tra_precuni"].DefaultCellStyle.Format = "N4";
		//	malla.Columns["Tra_precuni"].DefaultCellStyle.Format = $"N{digPreciosV}";

		//	//malla.Columns["Tra_precuni"].ReadOnly = (accesosLocalizados.PrecioUnitario == false);
		//	if (malla != null && malla.Columns.Contains("Tra_precuni"))
		//	{
		//		malla.Columns["Tra_precuni"].ReadOnly = (accesosLocalizados?.PrecioUnitario == false);
		//	}

		//	//malla.Columns["tra_porcendes"].ReadOnly = (accesosLocalizados.DescuentoUnitario == false);
		//	// Tu línea original con protección
		//	if (malla != null && accesosLocalizados != null && malla.Columns.Contains("tra_porcendes"))
		//	{
		//		malla.Columns["tra_porcendes"].ReadOnly = (accesosLocalizados.DescuentoUnitario == false);
		//	}

		//	//malla.Columns["tra_valordes"].ReadOnly = (accesosLocalizados.DescuentoUnitario == false);

		//	if (malla != null && accesosLocalizados != null && malla.Columns.Contains("tra_valordes"))
		//	{
		//		malla.Columns["tra_valordes"].ReadOnly = (accesosLocalizados.DescuentoUnitario == false);
		//	}

		//	//malla.Columns["tra_nombre"].ReadOnly = (accesosLocalizados.DetalleProducto == false);

		//	if (malla != null && accesosLocalizados != null && malla.Columns.Contains("tra_nombre"))
		//	{
		//		malla.Columns["tra_nombre"].ReadOnly = (accesosLocalizados.DetalleProducto == false);
		//	}

		//	malla.Columns["Tra_valoriva"].ReadOnly = true;

		//	if (accesosLocalizados == null) return;
		//	if (accesosLocalizados.sinRegistro == true) return;
		//}

		public void diseñarMallaFacturas(ref System.Windows.Forms.DataGridView malla,ref sesSys.OpcDoc propedadesDocmto,daxAccs.propiedadesDaxAuto accesosLocalizados = null)
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
			//malla.Columns["TRA_SNIVA"].Visible = datosAuxiliares.tieneDatoDetalle("Iva", propedadesDocmto);			
			malla.Columns["Existencia"].Visible = datosAuxiliares.tieneDatoDetalle("Existencia", propedadesDocmto);
			malla.Columns["tra_porcendes"].Visible = datosAuxiliares.tieneDatoDetalle("DescuentoArtículo", propedadesDocmto);



			if (malla.Columns.Contains("TRA_SNIVA"))
			{
				// Forzar que sea columna de texto, no checkbox
				if (malla.Columns["TRA_SNIVA"] is DataGridViewCheckBoxColumn)
				{
					// Reemplazar checkbox por textbox
					DataGridViewColumn oldCol = malla.Columns["TRA_SNIVA"];
					int colIndex = oldCol.Index;

					DataGridViewTextBoxColumn newCol = new DataGridViewTextBoxColumn();
					newCol.Name = "TRA_SNIVA";
					newCol.DataPropertyName = "TRA_SNIVA";
					newCol.HeaderText = "IVA";
					newCol.Width = oldCol.Width;
					newCol.Visible = true;
					newCol.ReadOnly = true; // ✅ CAMBIO: true para forzar uso de F2
					newCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
					newCol.DefaultCellStyle.NullValue = ""; // ✅ CAMBIO: vacío en lugar de "NO"
					newCol.DefaultCellStyle.BackColor = Color.LightYellow; // 👈 Opcional: resaltar
					newCol.DefaultCellStyle.Font = new Font(malla.Font, FontStyle.Bold);
					newCol.ToolTipText = "Presione F2 para alternar SI/NO"; // 👈 Tooltip informativo

					malla.Columns.RemoveAt(colIndex);
					malla.Columns.Insert(colIndex, newCol);
				}
				else
				{
					// Si ya es textbox, solo configurar
					malla.Columns["TRA_SNIVA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
					malla.Columns["TRA_SNIVA"].DefaultCellStyle.NullValue = ""; // ✅ CAMBIO: vacío
					malla.Columns["TRA_SNIVA"].ReadOnly = true; // ✅ CAMBIO: true
					malla.Columns["TRA_SNIVA"].DefaultCellStyle.BackColor = Color.LightYellow; // 👈 Opcional
					malla.Columns["TRA_SNIVA"].DefaultCellStyle.Font = new Font(malla.Font, FontStyle.Bold);
					malla.Columns["TRA_SNIVA"].ToolTipText = "Presione F2 para alternar SI/NO";
				}
			}



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
			malla.Columns["tra_nombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


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

		public void diseñarMallaTransferencias(ref System.Windows.Forms.DataGridView malla, ref sesSys.OpcDoc propedadesDocmto, daxAccs.propiedadesDaxAuto accesosLocalizados = null)
		{

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
				if (column.ValueType.Name.ToUpper() == "DATETIME" || column.ValueType.Name.ToUpper() == "DATE") column.DefaultCellStyle.Format = "dd/MMM/yyyy";
			}

			malla.Columns["tra_codigo"].HeaderText = "Codigo";
			malla.Columns["tra_nombre"].HeaderText = "Descripción";
			malla.Columns["tra_cantidad"].HeaderText = "Cantidad";
			//malla.Columns["Tra_precuni"].HeaderText = "P.Unitario";
			//malla.Columns["tra_porcendes"].HeaderText = "% Dscto";
			//malla.Columns["tra_valordes"].HeaderText = "Descto";
			//malla.Columns["Tra_prectot"].HeaderText = "PrecTotal";
			//malla.Columns["TRA_SNIVA"].HeaderText = "IVA";
			malla.Columns["tra_medida"].HeaderText = "Med.";
			malla.Columns["TRA_NUMLINEA"].HeaderText = "Nro";

			malla.Columns["tra_codigo"].Visible = true;
			malla.Columns["tra_nombre"].Visible = true;
			malla.Columns["tra_cantidad"].Visible = true;
			//malla.Columns["Tra_precuni"].Visible = true;
			//malla.Columns["Tra_prectot"].Visible = true;
			//malla.Columns["Serv"].Visible = datosAuxiliares.tieneDatoDetalle("FormaServicio", propedadesDocmto);
			//malla.Columns["Cmb"].Visible = datosAuxiliares.tieneDatoDetalle("Preferencia", propedadesDocmto);

			//malla.Columns["TRA_SNIVA"].Visible = datosAuxiliares.tieneDatoDetalle("Iva", propedadesDocmto);
			//malla.Columns["Existencia"].Visible = datosAuxiliares.tieneDatoDetalle("Existencia", propedadesDocmto);
		//	malla.Columns["tra_porcendes"].Visible = datosAuxiliares.tieneDatoDetalle("DescuentoArtículo", propedadesDocmto);


			//if (datosAuxiliares.tieneDatoDetalle("PeriodoLiquidación", propedadesDocmto))
			//{
			//	malla.Columns["FacDesde"].HeaderText = "Fec.Desde";
			//	malla.Columns["FacHasta"].HeaderText = "Fec.Hasta";
			//	malla.Columns["FacDesde"].Visible = true;
			//	malla.Columns["FacHasta"].Visible = true;
			//}
			//if (datosAuxiliares.tieneDatoDetalle("DespachoInmediato", propedadesDocmto))
			//{
			//	malla.Columns["despacho"].Visible = true;
			//	malla.Columns["despacho"].HeaderText = "Despacho";
			//}
			if (datosAuxiliares.tieneDatoDetalle("UnidadMedida", propedadesDocmto))
			{
				malla.Columns["tra_medida"].HeaderText = "Medida";
				malla.Columns["tra_medida"].Visible = true;
				malla.Columns["tra_medida"].ReadOnly = true;
			}
			if (datosAuxiliares.tieneDatoDetalle("Piezas", propedadesDocmto))
			{
				malla.Columns["tra_piezas"].HeaderText = "Piezas";
				malla.Columns["tra_piezas"].Visible = true;
			}
			if (datosAuxiliares.tieneDatoDetalle("Peso", propedadesDocmto))
			{
				malla.Columns["tra_peso"].HeaderText = "Peso";
				malla.Columns["tra_peso"].Visible = true;
			}
			if (datosAuxiliares.tieneDatoDetalle("LoteProducto", propedadesDocmto))
			{
				malla.Columns["tra_nrolote"].HeaderText = "Nro Lote";
				malla.Columns["tra_nrolote"].Visible = true;
			}

			if (datosAuxiliares.tieneDatoDetalle("BodegaMovimiento", propedadesDocmto))
			{
				malla.Columns["Doc_Bodega"].HeaderText = "BOD";
				malla.Columns["Doc_Bodega"].Visible = true;
			}
			if (datosAuxiliares.tieneDatoDetalle("FechaCaducidad", propedadesDocmto))
			{
				malla.Columns["Tra_vence"].HeaderText = "Caducidad";
				malla.Columns["Tra_vence"].Visible = true;
			}
			//if (datosAuxiliares.tieneDatoDetalle("Centro Costo", propedadesDocmto))
			//{
			//	malla.Columns["tra_Costo"].HeaderText = "Centro Costo";
			//	malla.Columns["tra_Costo"].Visible = true;
			//}
			//if (datosAuxiliares.tieneDatoDetalle("Empleado", propedadesDocmto))
			//{
			//	malla.Columns["tra_empleado"].HeaderText = "Empleado";
			//	malla.Columns["tra_empleado"].Visible = true;
			//}
			//if (datosAuxiliares.tieneDatoDetalle("Centro Producción", propedadesDocmto))
			//{
			//	malla.Columns["tra_centroProduccion"].HeaderText = "Cent.Producci";
			//	malla.Columns["tra_centroProduccion"].Visible = true;
			//}
			//if (datosAuxiliares.tieneDatoDetalle("Centro Distribución", propedadesDocmto))
			//{
			//	malla.Columns["tra_centroDistribucion"].HeaderText = "Cent.Distribuc";
			//	malla.Columns["tra_centroDistribucion"].Visible = true;
			//}
			//if (datosAuxiliares.tieneDatoDetalle("Proyecto", propedadesDocmto))
			//{
			//	malla.Columns["tra_Proyecto"].HeaderText = "Proyecto";
			//	malla.Columns["tra_Proyecto"].Visible = true;
			//}

			//malla.Columns["Tra_prectot"].ReadOnly = true;
			//malla.Columns["TRA_NUMLINEA"].ReadOnly = true;

			//malla.Columns["TRA_NUMLINEA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			malla.Columns["tra_codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			malla.Columns["tra_nombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

			//malla.Columns["Tra_precuni"].ReadOnly = false; // (accesosLocalizados.PrecioUnitario == false);
														   //malla.Columns["tra_porcendes"].ReadOnly = (accesosLocalizados.DescuentoUnitario == false);
														   // malla.Columns["tra_valordes"].ReadOnly = (accesosLocalizados.DescuentoUnitario == false);
			malla.Columns["tra_nombre"].ReadOnly = true; // (accesosLocalizados.DetalleProducto == false);

			if (accesosLocalizados == null) return;
			if (accesosLocalizados.sinRegistro == true) return;

			//malla.Columns["Tra_precuni"].ReadOnly = (accesosLocalizados.PrecioUnitario == false);
			//malla.Columns["tra_porcendes"].ReadOnly = (accesosLocalizados.DescuentoUnitario == false);
			//malla.Columns["tra_valordes"].ReadOnly = (accesosLocalizados.DescuentoUnitario == false);
			malla.Columns["tra_nombre"].ReadOnly = (accesosLocalizados.DetalleProducto == false);
		}
		public void diseñarMallaVerifica(ref System.Windows.Forms.DataGridView malla)
		{

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
				if (column.ValueType.Name.ToUpper() == "DATETIME" || column.ValueType.Name.ToUpper() == "DATE") column.DefaultCellStyle.Format = "dd/MMM/yyyy";
			}

			malla.Columns["tra_codigo"].HeaderText = "Codigo";
			malla.Columns["tra_nombre"].HeaderText = "Descripción";
			malla.Columns["tra_cantidad"].HeaderText = "Recibido";
			
			malla.Columns["tra_codigo"].Visible = true;
			malla.Columns["tra_nombre"].Visible = true;
			malla.Columns["tra_cantidad"].Visible = true;
			malla.Columns["Enviado"].Visible = true;
			malla.Columns["Diferencia"].Visible = true;

			malla.Columns["tra_nombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
		}

	}
}
