using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using DaxComercia;
namespace DctosEmi
{
	public class FuncionesEspeciales
	{
		public void PrecioUnitario(Keys keyData, DataGridView malla, adcArticulo.AdcArt propiedadesArt, IvaRett.docImpuestos claseImpuestos, int nroDigitosEnPrecios)
		{
			DataGridViewCell cell = malla.CurrentCell;
			string dato = malla.CurrentCell.Value.ToString();
			DataGridViewRow row = malla.Rows[cell.RowIndex];
			int quePrecio = 0;
			cell.Value = cargarPrecios.CargarPrecioVta(Convert.ToInt32(keyData), ref propiedadesArt, claseImpuestos.impstoPorcentaje1, ref quePrecio, "", row.Cells["tra_Medida"].Value.ToString(), "", nroDigitosEnPrecios);

		}
			//else if (nombreCelda == "TRA_CODIGO")
			//{
			//	try
			//	{
			//		mallaArticulo.bodega = ""; //cmbBodega.SelectedValue.ToString();
			//	}
			//	catch { }
			//	saltaEventosMalla = true;
			//	mallaArticulo.digCostos = nroDigitosEnCostos;
			//	mallaArticulo.digPrecios = nroDigitosEnPrecios;
			//	mallaArticulo.fechaDoc = Convert.ToDateTime(txtfecha.Text);
			//	mallaArticulo.impIva = claseImpuestos.impstoPorcentaje1;
			//	mallaArticulo.codCliente = codCliente;
			//	mallaArticulo.sucursal = datosEmpresa.suc;
			//	mallaArticulo.tipoDoc = cmbDocumento.SelectedValue.ToString();
			//	mallaArticulo.numDoc = txtnumero.Text;

			//	if (keyData == Keys.F2)
			//	{
			//		dato = mallaArticulo.BuscarArticuloSimple(malla.CurrentCell.Value.ToString());
			//		if (mallaArticulo.CargarArticulo(malla, ref propiedadesDoc, dato, opalex.TipoCliente, txtfecha.Text, propiedadesDoc.Documento, idDocumentoActual.idClave) == false) cell.Value = ""; keyData = Keys.Cancel;
			//	}
			//	else if (keyData == Keys.F11)
			//	{
			//		dato = mallaArticulo.BuscarArticulo(malla.CurrentCell.Value.ToString());
			//		if (mallaArticulo.CargarArticulo(malla, ref propiedadesDoc, dato, opalex.TipoCliente, txtfecha.Text, propiedadesDoc.Documento, idDocumentoActual.idClave) == false) cell.Value = ""; keyData = Keys.Cancel;
			//	}
			//	else if (keyData == Keys.Return && dato.Length > 0)
			//	{
			//		if (mallaArticulo.CargarArticulo(malla, ref propiedadesDoc, dato, opalex.TipoCliente, txtfecha.Text, propiedadesDoc.Documento, idDocumentoActual.idClave) == false) cell.Value = ""; keyData = Keys.Cancel;
			//	}
			//	else if (keyData == Keys.F3)
			//	{
			//		DaxConceptos.classConceptos buscserv = new DaxConceptos.classConceptos();
			//		dato = buscserv.iniciaBuscador(datosEmpresa.strConxAdcom, "", "CC", false, true);
			//		if (dato != "") mallaArticulo.CargarServicios(dato, ref malla, claseImpuestos.impstoPorcentaje1, nroDigitosEnPrecios, Convert.ToDateTime(txtfecha.Text), ref propiedadesDoc);
			//	}

			//	//        VerificarClasificadoresContablesArticulo dato
			//}
			//else if (nombreCelda == "DOC_BODEGA")
			//{

			//}    //        VerificarClasificadoresContablesArticulo dato

			//if (cell.Value.ToString() != "") keyData = Keys.Return; else keyData = Keys.Cancel;
			//saltaEventosMalla = false;
			//totalizar();
			//mallaArticulo = null;
			//return resp;
	}
}
