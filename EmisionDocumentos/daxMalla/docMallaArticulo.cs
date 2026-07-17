using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
//using adcArticulosValores;
using adcArticulo;
using DattCom;
using DaxInvent;
using comercP;
using DaxComercia;
using daxMallaDatos;

namespace DtosMall
{
	public class docMallaArticulo
	{
		//adcArticulosPrecios.cargarPrecios ponPrecio = new adcArticulosPrecios.cargarPrecios();
		
		public string sucursal = string.Empty;
		public string bodega = "";
		public double impIva = 0;
		public string codCliente = string.Empty;
		public Int32 digPrecios = 2;
		public int digCostos = 2;
		public DateTime fechaDoc;
		public string tipoDoc = "";
		public string numDoc = "";
		internal IvaRett.docImpuestos claseImpuestos = new IvaRett.docImpuestos();
		public string BuscarArticulo(string buscador)
		{
             frmBuscaArticuloDet busk = new frmBuscaArticuloDet(datosEmpresa.strConxAdcom, datosEmpresa.strConxSyscod);
			string dato = busk.IniciaBuscaArt(buscador, "", "", "", bodega); busk.Dispose();
			return dato;
		}
		public string BuscarArticuloSimple(string buscador)
		{

            frmBuscaArticuloSimple busk = new frmBuscaArticuloSimple(sucursal, codCliente, numDoc, tipoDoc);
			string dato = busk.IniciaBuscaArt(buscador, "", "", "", bodega);
			busk.Dispose();
			return dato;
		}
		
        public Boolean CargarConDesicion(DataGridView malla, ref sesSys.OpcDoc OpcDoc, string codigo, string tipoCliente, string fechaFin, string tipoDoc, double idClaveDoc, Int32 ElPrecio = 1)
        {
            if (CargarServicios(codigo, ref malla, impIva, Convert.ToInt16(digPrecios), fechaDoc, ref OpcDoc)) return true;
            return CargarArticulo(malla, ref OpcDoc, codigo, tipoCliente, fechaFin, tipoDoc, idClaveDoc,ElPrecio);
        }
		//		public Boolean CargarArticulo(DataGridView malla, ref sesSys.OpcDoc OpcDoc, string codigo, string tipoCliente, string fechaFin, string tipoDoc, double idClaveDoc, Int32 ElPrecio = 1)
		//		{
		//			DataGridViewRow row = null;
		//			try { row = malla.CurrentRow; } catch { return false; }
		//			if (row == null) return false;
		//			if (codigo.Length == 0) return false;

		//			double valPrecio = 0;
		//			AdcArt opArt = new adcArticulo.AdcArt(datosEmpresa.strConxAdcom);
		//			opArt = adcArticulo.AdcArt.Buscar(" art_codigo = '" + codigo + "' ");
		//            if (opArt == null) return false;
		//			//{
		//			//	return CargarServicios(codigo, ref malla, impIva, Convert.ToInt16(digPrecios), fechaDoc, ref OpcDoc);
		//			//}
		//			validaArticuloFactura valArt = new validaArticuloFactura();
		//			if (valArt.validarArticulo(ref opArt, ref OpcDoc, ref malla, sucursal, bodega, fechaDoc.ToShortDateString(), tipoDoc, numDoc) == false) return false;

		//			row.Cells["tra_Codigo"].Value = codigo;
		//			row.Cells["tra_nombre"].Value = opArt.Art_nombre;
		//			row.Cells["tra_medida"].Value = opArt.Art_unimed;
		//			row.Cells["tra_SnIva"].Value = opArt.Art_sniva;
		//			row.Cells["tra_Individual"].Value = opArt.Art_individ;
		//			row.Cells["tra_Multiplo"].Value = 1;
		//			row.Cells["tra_queTipo"].Value = "A";

		//			if (Convert.ToDouble("0" + row.Cells["tra_Cantidad"].Value) == 0) row.Cells["tra_Cantidad"].Value = 1;

		//			valPrecio =   cargarPrecios.CargarPrecioVta(Convert.ToInt32(Keys.F1) + ElPrecio, ref opArt, impIva, ref ElPrecio, "", "", codCliente, digPrecios);

		//			if (valPrecio == 0) valPrecio =  ultimosValor.UltimoPrecioVenta(sucursal, codCliente, codigo, false, opArt.Art_unimed, "", Convert.ToDateTime(fechaFin), datosEmpresa.strConxAdcom, datosEmpresa.strConxSyscod);

		//			try
		//			{
		//				row.Cells["variedad"].Value = opArt.Art_clase; 
		//                row.Cells["HTS"].Value = opArt.HTS;
		//                row.Cells["Nandina"].Value = opArt.Nandina;
		//                row.Cells["tra_peso"].Value = opArt.Art_peso;
		//            }
		//            catch { }

		//			row.Cells["tra_PrecUni"].Value = valPrecio;
		//			row.Cells["tra_numprecio"].Value = ElPrecio;

		//			//row.Cells["Tra_porceniva"].Value = opArt.Art_PorIVA ;
		//			DateTime fechaProd = Convert.ToDateTime(fechaFin);
		//			claseImpuestos.cargar(datosEmpresa.strConxIvaret, fechaProd);
		//			//if (opArt.Art_sniva)
		//			//{
		//			//	row.Cells["Tra_porceniva"].Value = opArt.Art_PorIVA;
		//			//}
		//			//else
		//			//{
		//			//	row.Cells["Tra_porceniva"].Value = claseImpuestos.impstoPorcentaje1;
		//			//}

		//			if (!opArt.Art_sniva)   // SIN IVA
		//			{
		//				row.Cells["Tra_porceniva"].Value = 0;
		//			}
		//			else                        // CON IVA
		//			{
		//				if (opArt.Art_PorIVA > 0)
		//					row.Cells["Tra_porceniva"].Value = opArt.Art_PorIVA;
		//				else
		//					row.Cells["Tra_porceniva"].Value = claseImpuestos.impstoPorcentaje1;
		//			}



		//			try { row.Cells["precioArticulo"].Value = valPrecio; } catch { }

		//			double desc = 0; //Convert.ToDouble ( "0" + row.Cells["tra_Porcendes"].Value);
		//			{
		//				if (fechaDoc >= opArt.Art_fecinides && fechaDoc <= opArt.Art_fecfindes)
		//				{
		//					desc = Convert.ToDouble(opArt.Art_descuen);
		//				}
		//			}
		//			if (desc == 0 && opArt.Art_categor != "" && tipoCliente != "")
		//			{
		//				adcDescto.valorDescuentoLineas adccDes = new adcDescto.valorDescuentoLineas();
		//				desc = adccDes.ValorDescuentoLineas(opArt.Art_categor, tipoCliente, datosEmpresa.strConxAdcom);
		//				row.Cells["tra_porcendes"].Value = desc;
		//			}
		//            if (desc == 0) { desc = Convert.ToDouble(opArt.Art_descuen); row.Cells["tra_porcendes"].Value = desc; }

		//			try
		//			{
		//				row.Cells["ultimoCosto"].Value = ultimosValor.UltimoCostoCompra("", "", codigo, false, "", "", Convert.ToDateTime(fechaFin), datosEmpresa.strConxAdcom, datosEmpresa.strConxSyscod);
		//			} catch { }
		//			try
		//			{
		//				if (malla.Columns["Existencia"].Visible == true)
		//				{
		//					row.Cells["Existencia"].Value = ultimosValor.SaldoFecha(datosEmpresa.strConxAdcom, codigo, fechaFin, tipoDoc, sucursal, tipoDoc, idClaveDoc, bodega);
		////					promedio ?  hacer consulta para estos tres campos de una ?
		//				}
		//			} catch { }
		//            try
		//            {
		//                    row.Cells["LimiteDescuento"].Value = opArt.art_limDescuento;
		//            }
		//            catch { }            
		//            return true;		
		//		}




		//public Boolean CargarArticuloinmediato(DataGridViewRow row, ref sesSys.OpcDoc OpcDoc, string codigo, string tipoCliente, string fechaFin, string tipoDoc, double idClaveDoc, Int32 ElPrecio = 1)
		//      {
		//          if (row == null) return false;
		//          if (codigo.Length == 0) return false;

		//          double valPrecio = 0;
		//          AdcArt opArt = new adcArticulo.AdcArt(datosEmpresa.strConxAdcom);
		//          opArt = adcArticulo.AdcArt.Buscar(" art_codigo = '" + codigo + "' ");
		//          if (opArt == null) return false;
		//          //validaArticuloFactura valArt = new validaArticuloFactura();
		//          //if (valArt.validarArticulo(ref opArt, ref OpcDoc, ref row, sucursal, bodega, fechaDoc.ToShortDateString(), tipoDoc, numDoc) == false) return false;

		//          row.Cells["tra_Codigo"].Value = codigo;
		//          row.Cells["tra_nombre"].Value = opArt.Art_nombre;
		//          row.Cells["tra_medida"].Value = opArt.Art_unimed;
		//          row.Cells["tra_SnIva"].Value = opArt.Art_sniva;
		//          row.Cells["tra_Individual"].Value = opArt.Art_individ;
		//          row.Cells["tra_Multiplo"].Value = 1;
		//          row.Cells["tra_queTipo"].Value = "A";


		//	if (Convert.ToDouble("0" + row.Cells["tra_Cantidad"].Value) == 0) row.Cells["tra_Cantidad"].Value = 1;

		//          valPrecio = cargarPrecios.CargarPrecioVta(Convert.ToInt32(Keys.F1) + ElPrecio, ref opArt, impIva, ref ElPrecio, "", "", codCliente, digPrecios);

		//          //if (valPrecio == 0) valPrecio = ultimosValor.UltimoPrecioVenta(sucursal, codCliente, codigo, false, opArt.Art_unimed, "", Convert.ToDateTime(fechaFin), datosEmpresa.strConxAdcom, datosEmpresa.strConxSyscod);

		//          row.Cells["tra_PrecUni"].Value = valPrecio;
		//          row.Cells["tra_numprecio"].Value = ElPrecio;

		//          try { row.Cells["precioArticulo"].Value = valPrecio; } catch { }

		//	row.Cells["COMP"].Value = opArt.Art_sncomp;

		//	double desc = 0; //Convert.ToDouble ( "0" + row.Cells["tra_Porcendes"].Value);
		//          {
		//              if (fechaDoc >= opArt.Art_fecinides && fechaDoc <= opArt.Art_fecfindes)
		//              {
		//                  desc = Convert.ToDouble(opArt.Art_descuen);
		//              }
		//          }
		//          if (desc == 0 && opArt.Art_categor != "" && tipoCliente != "")
		//          {
		//              adcDescto.valorDescuentoLineas adccDes = new adcDescto.valorDescuentoLineas();
		//              desc = adccDes.ValorDescuentoLineas(opArt.Art_categor, tipoCliente, datosEmpresa.strConxAdcom);
		//              row.Cells["tra_porcendes"].Value = desc;
		//          }
		//          if (desc == 0) { desc = Convert.ToDouble(opArt.Art_descuen); row.Cells["tra_porcendes"].Value = desc; }

		//          ultimosValor ult = new ultimosValor();
		//          try
		//          {
		//              row.Cells["LimiteDescuento"].Value = opArt.art_limDescuento;
		//          }
		//          catch { }
		//          return true;
		//      }


		public Boolean CargarArticulo(DataGridView malla, ref sesSys.OpcDoc OpcDoc, string codigo, string tipoCliente, string fechaFin, string tipoDoc, double idClaveDoc, Int32 ElPrecio = 1)
		{
			DataGridViewRow row = null;
			try { row = malla.CurrentRow; } catch { return false; }
			if (row == null) return false;
			if (codigo.Length == 0) return false;

			double valPrecio = 0;
			double costoPromedio = 0;
			AdcArt opArt = new adcArticulo.AdcArt(datosEmpresa.strConxAdcom);
			opArt = adcArticulo.AdcArt.Buscar(" art_codigo = '" + codigo + "' ");
			if (opArt == null) return false;

			validaArticuloFactura valArt = new validaArticuloFactura();
			if (valArt.validarArticulo(ref opArt, ref OpcDoc, ref malla, sucursal, bodega, fechaDoc.ToShortDateString(), tipoDoc, numDoc) == false) return false;

			row.Cells["tra_Codigo"].Value = codigo;
			row.Cells["tra_nombre"].Value = opArt.Art_nombre;
			row.Cells["tra_medida"].Value = opArt.Art_unimed;

			// ✅ VERIFICAR SI LAS COLUMNAS EXISTEN
			if (malla.Columns.Contains("tra_SnIva"))
				row.Cells["tra_SnIva"].Value = opArt.Art_sniva;

			if (malla.Columns.Contains("tra_Individual"))
				row.Cells["tra_Individual"].Value = opArt.Art_individ;

			if (malla.Columns.Contains("tra_Multiplo"))
				row.Cells["tra_Multiplo"].Value = 1;

			if (malla.Columns.Contains("tra_queTipo"))
				row.Cells["tra_queTipo"].Value = "A";

			if (Convert.ToDouble("0" + row.Cells["tra_Cantidad"].Value) == 0)
				row.Cells["tra_Cantidad"].Value = 1;

			// ✅ OBTENER COSTO PROMEDIO
			try
			{
				// Obtener el costo promedio del artículo
				costoPromedio = ultimosValor.UltimoCostoCompra("", "", codigo, false, "", "", Convert.ToDateTime(fechaFin), datosEmpresa.strConxAdcom, datosEmpresa.strConxSyscod);
			}
			catch
			{
				costoPromedio = Convert.ToDouble(opArt.Art_costucom); // Si no hay, usar el costo unitario de compra
			}

			// ✅ ASIGNAR COSTO PROMEDIO A LA FILA
			if (malla.Columns.Contains("Tra_costuni"))
				row.Cells["Tra_costuni"].Value = costoPromedio;

			if (malla.Columns.Contains("Tra_costtot"))
			{
				double cantidad = Convert.ToDouble(row.Cells["tra_Cantidad"].Value);
				row.Cells["Tra_costtot"].Value = costoPromedio * cantidad;
			}

			// ✅ OBTENER PRECIO DE VENTA (para el campo Costo Unitario de la malla)
			valPrecio = cargarPrecios.CargarPrecioVta(Convert.ToInt32(Keys.F1) + ElPrecio, ref opArt, impIva, ref ElPrecio, "", "", codCliente, digPrecios);

			if (valPrecio == 0)
				valPrecio = ultimosValor.UltimoPrecioVenta(sucursal, codCliente, codigo, false, opArt.Art_unimed, "", Convert.ToDateTime(fechaFin), datosEmpresa.strConxAdcom, datosEmpresa.strConxSyscod);

			// ✅ CAMPOS OPCIONALES
			try
			{
				if (malla.Columns.Contains("variedad"))
					row.Cells["variedad"].Value = opArt.Art_clase;

				if (malla.Columns.Contains("HTS"))
					row.Cells["HTS"].Value = opArt.HTS;

				if (malla.Columns.Contains("Nandina"))
					row.Cells["Nandina"].Value = opArt.Nandina;

				if (malla.Columns.Contains("tra_peso"))
					row.Cells["tra_peso"].Value = opArt.Art_peso;
			}
			catch { }

			row.Cells["tra_PrecUni"].Value = valPrecio;
			row.Cells["tra_numprecio"].Value = ElPrecio;

			DateTime fechaProd = Convert.ToDateTime(fechaFin);
			claseImpuestos.cargar(datosEmpresa.strConxIvaret, fechaProd);

			// ✅ ASIGNAR IVA SOLO SI LA COLUMNA EXISTE
			if (malla.Columns.Contains("Tra_porceniva"))
			{
				if (!opArt.Art_sniva)
				{
					row.Cells["Tra_porceniva"].Value = 0;
				}
				else
				{
					if (opArt.Art_PorIVA > 0)
						row.Cells["Tra_porceniva"].Value = opArt.Art_PorIVA;
					else
						row.Cells["Tra_porceniva"].Value = claseImpuestos.impstoPorcentaje1;
				}
			}

			try
			{
				if (malla.Columns.Contains("precioArticulo"))
					row.Cells["precioArticulo"].Value = valPrecio;
			}
			catch { }

			double desc = 0;
			{
				if (fechaDoc >= opArt.Art_fecinides && fechaDoc <= opArt.Art_fecfindes)
				{
					desc = Convert.ToDouble(opArt.Art_descuen);
				}
			}

			if (desc == 0 && opArt.Art_categor != "" && tipoCliente != "")
			{
				adcDescto.valorDescuentoLineas adccDes = new adcDescto.valorDescuentoLineas();
				desc = adccDes.ValorDescuentoLineas(opArt.Art_categor, tipoCliente, datosEmpresa.strConxAdcom);
				if (malla.Columns.Contains("tra_porcendes"))
					row.Cells["tra_porcendes"].Value = desc;
			}

			if (desc == 0)
			{
				desc = Convert.ToDouble(opArt.Art_descuen);
				if (malla.Columns.Contains("tra_porcendes"))
					row.Cells["tra_porcendes"].Value = desc;
			}

			try
			{
				if (malla.Columns.Contains("ultimoCosto"))
					row.Cells["ultimoCosto"].Value = costoPromedio;
			}
			catch { }

			try
			{
				if (malla.Columns.Contains("Existencia") && malla.Columns["Existencia"].Visible == true)
				{
					row.Cells["Existencia"].Value = ultimosValor.SaldoFecha(datosEmpresa.strConxAdcom, codigo, fechaFin, tipoDoc, sucursal, tipoDoc, idClaveDoc, bodega);
				}
			}
			catch { }

			try
			{
				if (malla.Columns.Contains("LimiteDescuento"))
					row.Cells["LimiteDescuento"].Value = opArt.art_limDescuento;
			}
			catch { }

			return true;
		}
		
		public Boolean CargarArticuloinmediato(DataGridViewRow row, ref sesSys.OpcDoc OpcDoc, string codigo, string tipoCliente, string fechaFin, string tipoDoc, double idClaveDoc, Int32 ElPrecio = 1)
		{
			if (row == null) return false;
			if (codigo.Length == 0) return false;

			double valPrecio = 0;
			AdcArt opArt = new adcArticulo.AdcArt(datosEmpresa.strConxAdcom);
			opArt = adcArticulo.AdcArt.Buscar(" art_codigo = '" + codigo + "' ");
			if (opArt == null) return false;

			// Obtener el DataGridView al que pertenece la fila
			DataGridView malla = row.DataGridView;
			if (malla == null) return false;

			row.Cells["tra_Codigo"].Value = codigo;
			row.Cells["tra_nombre"].Value = opArt.Art_nombre;
			row.Cells["tra_medida"].Value = opArt.Art_unimed;

			// ✅ VERIFICAR SI LAS COLUMNAS EXISTEN USANDO malla.Columns.Contains()
			if (malla.Columns.Contains("tra_SnIva"))
				row.Cells["tra_SnIva"].Value = opArt.Art_sniva;

			if (malla.Columns.Contains("tra_Individual"))
				row.Cells["tra_Individual"].Value = opArt.Art_individ;

			if (malla.Columns.Contains("tra_Multiplo"))
				row.Cells["tra_Multiplo"].Value = 1;

			if (malla.Columns.Contains("tra_queTipo"))
				row.Cells["tra_queTipo"].Value = "A";

			if (Convert.ToDouble("0" + row.Cells["tra_Cantidad"].Value) == 0)
				row.Cells["tra_Cantidad"].Value = 1;

			valPrecio = cargarPrecios.CargarPrecioVta(Convert.ToInt32(Keys.F1) + ElPrecio, ref opArt, impIva, ref ElPrecio, "", "", codCliente, digPrecios);

			row.Cells["tra_PrecUni"].Value = valPrecio;
			row.Cells["tra_numprecio"].Value = ElPrecio;

			try
			{
				if (malla.Columns.Contains("precioArticulo"))
					row.Cells["precioArticulo"].Value = valPrecio;
			}
			catch { }

			if (malla.Columns.Contains("COMP"))
				row.Cells["COMP"].Value = opArt.Art_sncomp;

			double desc = 0;
			{
				if (fechaDoc >= opArt.Art_fecinides && fechaDoc <= opArt.Art_fecfindes)
				{
					desc = Convert.ToDouble(opArt.Art_descuen);
				}
			}

			if (desc == 0 && opArt.Art_categor != "" && tipoCliente != "")
			{
				adcDescto.valorDescuentoLineas adccDes = new adcDescto.valorDescuentoLineas();
				desc = adccDes.ValorDescuentoLineas(opArt.Art_categor, tipoCliente, datosEmpresa.strConxAdcom);
				if (malla.Columns.Contains("tra_porcendes"))
					row.Cells["tra_porcendes"].Value = desc;
			}

			if (desc == 0)
			{
				desc = Convert.ToDouble(opArt.Art_descuen);
				if (malla.Columns.Contains("tra_porcendes"))
					row.Cells["tra_porcendes"].Value = desc;
			}

			try
			{
				if (malla.Columns.Contains("LimiteDescuento"))
					row.Cells["LimiteDescuento"].Value = opArt.art_limDescuento;
			}
			catch { }

			return true;
		}

		public Boolean CargarServicios(string dato,ref DataGridView malla,double valIva,Int16 digitosPrecios, DateTime fechaDoc,ref sesSys.OpcDoc opcDoc)
		{
            if (malla.CurrentRow == null) return false;
            if (dato == "") return false;

			daxConta.reglCtb dxCtb = new daxConta.reglCtb();
			DataGridViewRow row =malla.CurrentRow;
			double auxnum = 0;                    
			ClassDoc. Servicios OpServicio = new ClassDoc. Servicios(datosEmpresa.strConxAdcom);
			OpServicio = ClassDoc.Servicios.Buscar(" sev_codigo = '" + dato + "'");			
			if (OpServicio == null) return false;
			if (OpServicio.TipServMedico == "CON") return false;
				
			row.Cells["tra_codigo"].Value = dato;
			row.Cells["tra_nombre"].Value = OpServicio.Sev_nombre;
			row.Cells["tra_Medida"].Value = OpServicio.Sev_unimed;

			try {auxnum = Convert.ToDouble (row.Cells["tra_Cantidad"].Value);}catch{auxnum=0;}
			if ( auxnum == 0) row.Cells["tra_Cantidad"].Value = 1;

			double cantidad = 0;
			cantidad = Convert.ToDouble(row.Cells["tra_Cantidad"].Value);

			try {auxnum = Convert.ToDouble (row.Cells["tra_PrecUni"].Value);}catch{auxnum=0;}
			double precioUnitario = 0;
			if (auxnum != 0) precioUnitario = auxnum;


			if ( auxnum == 0) 
			{
					if (Convert.ToBoolean (OpServicio.Sev_IncIva) == true && OpServicio.Sev_sniva == true)
					{
						row.Cells["tra_PrecUni"].Value = Math.Round(Convert.ToDouble(OpServicio.Sev_precvta) / (valIva + 1), digitosPrecios);
						precioUnitario= Math.Round(Convert.ToDouble(OpServicio.Sev_precvta) / cantidad, digitosPrecios);
				}
					else
					{
						row.Cells["tra_PrecUni"].Value = OpServicio.Sev_precvta;
						precioUnitario =Convert.ToDouble(OpServicio.Sev_precvta);
				}
			}

			if (fechaDoc >= OpServicio.Sev_fecinides && fechaDoc <= OpServicio.Sev_fecfindes)                        
			{row.Cells["tra_PorcenDes"].Value = OpServicio.Sev_descuen;}
			//row.Cells["Tra_porceniva"].Value = OpServicio.Sev_PorIVA;

			DateTime fechaProd = Convert.ToDateTime(fechaDoc);
			claseImpuestos.cargar(datosEmpresa.strConxIvaret, fechaProd);


            if (!OpServicio.Sev_sniva)   // SIN IVA
            {
                row.Cells["Tra_porceniva"].Value = 0;
                row.Cells["TRA_SNIVA"].Value = 1;
            }
            else                        // CON IVA
            {
                if (OpServicio.Sev_PorIVA > 0)
                {
                    row.Cells["Tra_porceniva"].Value = OpServicio.Sev_PorIVA;
                    row.Cells["TRA_SNIVA"].Value = 1;
                }

                else
                {
                    row.Cells["Tra_porceniva"].Value = claseImpuestos.impstoPorcentaje1;
                    row.Cells["TRA_SNIVA"].Value = 1;
                }

            }





            double vaIvaUnit = 0;
			vaIvaUnit =Convert.ToDouble( row.Cells["Tra_porceniva"].Value);
			row.Cells["Tra_valoriva"].Value = Math.Round(Convert.ToDouble(precioUnitario* vaIvaUnit) / ( 100), digitosPrecios);

			row.Cells["tra_QueTipo"].Value = "S";
			row.Cells["tra_Individual"].Value = "";
			if (OpServicio.sev_escontable){row.Cells["tra_EsCuenta"].Value=true ;}else{row.Cells["tra_EsCuenta"].Value=false;}
								
			//row.Cells["tra_SnIva"].Value = OpServicio.Sev_sniva;
			if (opcDoc.TipoDoc == "FAP" || opcDoc.TipoDoc == "EGR" ) dxCtb.VerificarClasificadoresContablesServicios  ("T", dato,  row,  OpServicio, opcDoc,"","" );
			return true;
					
		}
		public Boolean EsComentario(string dato, DataGridViewRow row)
		{
			if (row == null) return false;
			if (dato == "") return false;

			row.Cells["tra_codigo"].Value = dato;
			row.Cells["tra_Medida"].Value = "";

			row.Cells["tra_Cantidad"].Value = 0;
			row.Cells["tra_PrecUni"].Value = 0; 
			row.Cells["tra_PorcenDes"].Value = 0;
			row.Cells["tra_QueTipo"].Value = "S";
			row.Cells["tra_Individual"].Value = "";
			row.Cells["tra_EsCuenta"].Value = false;
			row.Cells["tra_SnIva"].Value = 0;
			return true;
		}


		//public Boolean CargarArticuloRem(string codigo, DataGridViewRow row)
		//{ 
		//	if (row == null) return false; 
		//	if (codigo.Length == 0) return false;          
		//	adcArticulo.AdcArt opArt = new adcArticulo.AdcArt(datosEmpresa.strConxAdcom);
		//	opArt = adcArticulo.AdcArt.Buscar (" art_codigo = '" + codigo + "' ");

		//	if (opArt == null )
		//	{
		//		MessageBox.Show("No existe el artículo registrado");
		//		return false;
		//	}
		//	if (Convert.ToBoolean ( opArt.Art_snmed )) 
		//	{
		//		MessageBox.Show("El artículo no es para la venta");
		//		return false;
		//	}

		//	row.Cells["tra_Codigo"].Value = codigo;
		//	row.Cells["tra_nombre"].Value = opArt.Art_nombre; 
		//	row.Cells["tra_Medida"].Value = opArt.Art_unimed; 
		//	row.Cells["Tra_snIva"].Value = opArt.Art_sniva;
		//	if (Convert.ToDouble("0" + row.Cells["tra_Cantidad"].Value) == 0) row.Cells["tra_Cantidad"].Value = 1;
		//	row.Cells["tra_queTipo"].Value = "A";

		//	return true;
		//}


		//public Boolean CargarArticuloRem(string codigo, DataGridViewRow row)
		//{
		//	if (row == null) return false;
		//	if (codigo.Length == 0) return false;
		//	adcArticulo.AdcArt opArt = new adcArticulo.AdcArt(datosEmpresa.strConxAdcom);
		//	opArt = adcArticulo.AdcArt.Buscar(" art_codigo = '" + codigo + "' ");

		//	if (opArt == null)
		//	{
		//		MessageBox.Show("No existe el artículo registrado");
		//		return false;
		//	}
		//	if (Convert.ToBoolean(opArt.Art_snmed))
		//	{
		//		MessageBox.Show("El artículo no es para venta/remisión");
		//		return false;
		//	}

		//	// Usar DBNull.Value en lugar de null para limpiar
		//	foreach (DataGridViewCell cell in row.Cells)
		//	{
		//		if (cell.OwningColumn.Name != "tra_Codigo" &&
		//			cell.OwningColumn.Name != "tra_nombre" &&
		//			cell.OwningColumn.Name != "tra_Cantidad" &&
		//			cell.OwningColumn.Name != "tra_Medida" &&
		//			cell.OwningColumn.Name != "tra_queTipo")
		//		{
		//			cell.Value = DBNull.Value;  // Cambiar null por DBNull.Value
		//		}
		//	}

		//	// Asignar valores
		//	row.Cells["tra_Codigo"].Value = codigo;
		//	row.Cells["tra_nombre"].Value = opArt.Art_nombre;
		//	row.Cells["tra_Medida"].Value = opArt.Art_unimed;
		//	row.Cells["tra_queTipo"].Value = "A";

		//	// Verificar cantidad
		//	object cantidadObj = row.Cells["tra_Cantidad"].Value;
		//	double cantidad = 0;
		//	if (cantidadObj != null && cantidadObj != DBNull.Value)
		//		double.TryParse(cantidadObj.ToString(), out cantidad);

		//	if (cantidad == 0)
		//		row.Cells["tra_Cantidad"].Value = 1;

		//	return true;
		//}

		public Boolean CargarArticuloRem(string codigo, DataGridViewRow row)
		{
			if (row == null) return false;
			if (codigo.Length == 0) return false;

			adcArticulo.AdcArt opArt = new adcArticulo.AdcArt(datosEmpresa.strConxAdcom);
			opArt = adcArticulo.AdcArt.Buscar(" art_codigo = '" + codigo + "' ");

			if (opArt == null)
			{
				MessageBox.Show("No existe el artículo registrado");
				return false;
			}

			if (Convert.ToBoolean(opArt.Art_snmed))
			{
				MessageBox.Show("El artículo no es para venta/remisión");
				return false;
			}

			// Asignar valores directamente (sin limpiar toda la fila)
			row.Cells["tra_Codigo"].Value = codigo;
			row.Cells["tra_nombre"].Value = opArt.Art_nombre;
			row.Cells["tra_Medida"].Value = opArt.Art_unimed;
			row.Cells["tra_queTipo"].Value = "A";

			// Verificar cantidad
			object cantidadObj = row.Cells["tra_Cantidad"].Value;
			double cantidad = 0;
			if (cantidadObj != null && cantidadObj != DBNull.Value)
				double.TryParse(cantidadObj.ToString(), out cantidad);

			if (cantidad == 0)
				row.Cells["tra_Cantidad"].Value = 1;

			return true;
		}


		private DataTable leerTablas(string ssql,string strconx)
		{
			// devuelve un datatable con los datos leidos
			SqlDataAdapter da;
			DataTable dt = new DataTable();
			try
			{
				da = new SqlDataAdapter(ssql, strconx);
				da.Fill(dt);
			}
			catch
			{
				return null;
			}
			return dt;
		}

		public void AcumularLineasMalla(ref DataGridView Malla, string ColCodigo, string ColCantidad, string ColPrecioUnit)
		{
			Int32 i = 0;
			//Int32 j = 0;
			Int32 S = 0;
			Int32 UltimaColumna = Malla.Columns.Count - 1; 
			Double CantI;
			Double CantJ;
			if (Malla.RowCount < 2) return;
			double PrecI = 0;
			double PrecJ = 0;

			//Malla.Sort(Malla.Columns[ColCodigo], System.ComponentModel.ListSortDirection.Ascending);
			//j = 1;
			S = 0;
			do
			{

				for (int j= i+1; j < Malla.RowCount;j++)
                {
					if (Malla.Rows[i].Cells[ColCodigo].Value.ToString() != "")
					{
						try { PrecI = Convert.ToDouble(Malla.Rows[i].Cells[ColPrecioUnit].Value); } catch { PrecI = 0; };
						try { PrecJ = Convert.ToDouble(Malla.Rows[j].Cells[ColPrecioUnit].Value); } catch { PrecJ = 0; }
						if (Malla.Rows[i].Cells[ColCodigo].Value.ToString().ToUpper() == Malla.Rows[j].Cells[ColCodigo].Value.ToString().ToUpper() && PrecI == PrecJ)
						{
							CantJ = 0;
							CantI = 0;
							try { CantI = Convert.ToDouble(Malla.Rows[i].Cells[ColCantidad].Value); } catch { };
							try { CantJ = Convert.ToDouble(Malla.Rows[j].Cells[ColCantidad].Value); } catch { };
							Malla.Rows[i].Cells[ColCantidad].Value = CantI + CantJ;
							Malla.Rows.RemoveAt(j);
						}
					}
				}
				i++;
				if (i > Malla.Rows.Count - 1) S = 1;
			} while (S != 1);
		}
		public void AcumularLineasMalla(ref DataGridView Malla, Int32 Col1, Int32 Col2, Boolean ConSigno)
		{
			Int32 I = 0;
			Int32 j = 0;
			Int32 S = 0;
			Int32 SS = 0;
			Int32 QueSigno = 0;
			Double valor = 0;
			if (Malla.RowCount < 2) return;

			SS = Malla.Columns.Count - 1;
			//Malla.Columns.Count = Col1;
			Malla.Sort(Malla.Columns["tra_Codigo"], System.ComponentModel.ListSortDirection.Ascending);
			j = 1;
			S = 0;
			do
			{
				try { valor = Convert.ToDouble(Malla.Rows[I].Cells[Col2].Value) * Convert.ToDouble(Malla.Rows[I].Cells[SS].Value); }
				catch { valor = 0; }

				if (ConSigno) { Malla.Rows[I].Cells[Col2].Value = valor; }

				if (Malla.Rows[I].Cells[Col1].Value.ToString() == "")
				{ Malla.Rows.RemoveAt(I); }
				else if (Malla.Rows[I].Cells[Col1].Value.ToString() == Malla.Rows[j].Cells[Col1].Value.ToString())
				{
					if (Malla.Rows[I].Cells[Col2].Value.ToString() == "") { Malla.Rows[I].Cells[Col2].Value = 0; }
					if (Malla.Rows[j].Cells[Col2].Value.ToString() == "") { Malla.Rows[j].Cells[Col2].Value = 0; }
					if (ConSigno)
					{
						QueSigno = Convert.ToInt32(Malla.Rows[j].Cells[SS].Value);
						if (QueSigno == 0) QueSigno = 1;
						Malla.Rows[I].Cells[Col2].Value = Convert.ToDouble(Malla.Rows[I].Cells[Col2].Value) + Convert.ToDouble(Malla.Rows[j].Cells[Col2].Value) * QueSigno;
					}
					else
					{
						Malla.Rows[I].Cells[Col2].Value = Convert.ToDouble(Malla.Rows[I].Cells[Col2].Value) + Convert.ToDouble(Malla.Rows[j].Cells[Col2].Value);
						Malla.Rows.RemoveAt(j);
					}
				}
				else
				{
					I = I + 1;
					j = I + 1;
				}
				if (j > Malla.Rows.Count - 2) S = 1;
			} while (S != 1);
		}
	}

}

