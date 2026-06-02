using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using daxMallaDatos;
using DaxComercia;
using classMenSistem;
using ctrlReferencia;
using ClassDoc;
using System.Drawing;
using DattCom;


namespace DctosEmi
{
	public partial class FormVerificarIng : Form
	{
		internal sesSys.OpcDoc propiedadesDoc;
		directMnt.DirectorioAlex opalex = new directMnt.DirectorioAlex();
		internal AdcDoc datADCDOC;
		internal daxAccs.propiedadesDaxAuto accesosLocalizados = new daxAccs.propiedadesDaxAuto();

		DataTable dtDetalleDocumento = new DataTable();

		internal DctosEmi.docTotals totalesDocumento = new DctosEmi.docTotals();
		internal Boolean esSoloConsulta = false;
		internal Boolean esDeLiquidacion = false;

		internal idDocumento idDocumentoActual = new idDocumento();
		internal idDocumento idDocumentoSoporte = new idDocumento();
		idDocumento idDocumentoParaGenerar = new idDocumento();

		internal string codCliente = "";
		Boolean saltaEventosMalla = false;

		internal int operacionEnCurso = 0; // 0 sin operacion delcarada, 1 nuevo registro, 2 modificando registro
		internal int sinOperacion = 0;
		internal int nuevoRegistro = 1;
		internal int modificandoRegistro = 2;
		DataGridView MallaIngreso;
		public FormVerificarIng(idDocumento idDocViene, sesSys.OpcDoc propDocumento, DataGridView mallaDocmto)
		{
			InitializeComponent();
			idDocumentoActual = idDocViene;
			propiedadesDoc = propDocumento;
			MallaIngreso = mallaDocmto;
			CargarValoresIniciales();

			InicializarMalla();
		}
		private void CargarValoresIniciales()
		{
			labDocumento.Text = propiedadesDoc.nombre + " -  SUC Origen :" + idDocumentoActual.Sucursal + " - DOC: " + idDocumentoActual.Tipo + "-" + idDocumentoActual.numero;
			valoresPredefinidosEmpresa.cargaValores();
			valoresPredefinidosSucursal.cargarValores();
		}

		private void BtnSalir_Click(object sender, EventArgs e)
		{
			if (classMenSistem.mensajesErrorDocumento.ConfirmaCerrar()) this.Close();
		}

		private void btnCierra_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Confirma cerrar el documento actual ?", "Cerrar documento sin grabar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
			if (esSoloConsulta) Close();
		}
		private void InicializarMalla()
		{
			//  this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
			armarConsTra dcut = new armarConsTra();
			ModelaMalla dcut2 = new ModelaMalla();

			dtDetalleDocumento = utilBasDatos.utilBasDatos.leerTablas(dcut.armarSqlLecturaTransferencia(propiedadesDoc, "ADCTRA", datosEmpresa.suc, idDocumentoActual.Tipo, 0), datosEmpresa.strConxAdcom);
			if (dtDetalleDocumento == null) return;
			malla.DataSource = dtDetalleDocumento;
			dtDetalleDocumento.Rows.Add(dtDetalleDocumento.NewRow());
			dcut2.diseñarMallaVerifica(ref malla);
			dcut2 = null;
			malla.Focus();
			malla.CurrentCell = malla.Rows[0].Cells[1];
			malla.BeginEdit(true);
		}

		//private void malla_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		//{
		//    //if (e.ColumnIndex < 0 || saltaEventosMalla == true)
		//    //{
		//    //    return;
		//    //}

		//    //string nomCol = malla.Columns[e.ColumnIndex].Name.ToUpper();
		//    //if (nomCol == "TRA_PRECUNI" || nomCol == "TRA_CANTIDAD" || nomCol == "TRA_PORCENDES" || nomCol == "TRA_SNIVA" || nomCol == "TRA_MULTIPLO") totalizar();
		//}
		private void malla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex < 0 || saltaEventosMalla == true)
			{
				return;
			}

			string nomCol = malla.Columns[e.ColumnIndex].Name.ToUpper();
			if (malla.Rows.Count > propiedadesDoc.LineasMaximas && nomCol == "TRA_CODIGO")
			{
				MessageBox.Show("El documento tiene un número máximo de " + propiedadesDoc.LineasMaximas.ToString() + " lineas para su impresión ", "INFORMACION DE DOCUMENTOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			if (DctosEmi.ValidarDatos.ValidarDatosVentas(nomCol, malla.Rows[e.RowIndex], accesosLocalizados) == false) return;
			//if (nomCol == "TRA_PRECUNI" || nomCol == "TRA_CANTIDAD" || nomCol == "TRA_PORCENDES" || nomCol == "TRA_SNIVA" || nomCol == "TRA_MULTIPLO") totalizar();
		}


		private void btnEnviar_Click(object sender, EventArgs e)
		{
			imprimirDocumento();
		}
		private void iniciarNuevoDocumento()
		{
			InicializarMalla();
		}


		#region manejo malla
		private void malla_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			saltaEventosMalla = true;
			foreach (DataGridViewRow rr in malla.Rows)
			{
				rr.HeaderCell.Value = (rr.Index + 1).ToString();
			}
			saltaEventosMalla = false;
		}
		protected override Boolean ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (malla.Focused == false && malla.IsCurrentCellInEditMode == false) return false;
			if (malla.IsCurrentCellInEditMode && (keyData == Keys.Up || keyData == Keys.Down || keyData == Keys.Right || keyData == Keys.Left))
			{ keyData = Keys.Return; }

			if (keyData == Keys.Return || (keyData >= Keys.F1 && keyData < Keys.F13))
			{
				//DataGridViewCell cell = malla.CurrentCell;
				if (!(malla.IsCurrentCellInEditMode == false && keyData == Keys.Return)) funcionesEspeciales(ref keyData, malla);
				if (keyData != Keys.Return) return true;
				DaxMallaLib.Documentos.MoverCelda(malla, true);
				return true;
			}
			return false;
		}

		#endregion manejo malla
		private Boolean funcionesEspeciales(ref Keys keyData, DataGridView malla)
		{

			docMallaArticulo mallaArticulo = new docMallaArticulo();
			Boolean resp = true;
			malla.EndEdit();
			DataGridViewCell cell = malla.CurrentCell;
			string dato = cell.Value.ToString();
			string nombreCelda = cell.OwningColumn.Name.ToUpper();

			if (keyData == Keys.F8 && cell.ReadOnly == false && malla.Columns[cell.ColumnIndex].Name.ToUpper() != "TRA_CODIGO")
			{
				if (cell.RowIndex > 0) cell.Value = malla.Rows[cell.RowIndex - 1].Cells[cell.ColumnIndex].Value;
			}
			else if (keyData == Keys.F3 && cell.ValueType.Name.ToUpper() == "DATETIME")
			{
				cell.Value = docUtils.DaxNow().ToShortDateString();
			}
			else
			{
				switch (nombreCelda)
				{
					//case "TRA_PRECUNI":
					//    if (keyData >= Keys.F2 && keyData <= Keys.F6)
					//    {
					//        DataGridViewRow row = malla.CurrentRow;
					//        daxMallaDatos.docMallaArticulo preVta = new docMallaArticulo();
					//        Int32 quePrecio = 0;
					//        cell.Value = cargarPrecios.CargarPrecioVta(Convert.ToInt16(keyData), malla.CurrentRow.Cells["tra_Codigo"].Value.ToString(), claseImpuestos.impstoPorcentaje1, ref quePrecio, "", row.Cells["tra_Medida"].Value.ToString(), "", valoresPredefinidosEmpresa.nroDigitosEnPrecios);
					//        //	totalizar();
					//    }
					//    break;
					case "TRA_CODIGO":
						if (dato != ".")
						{
							try
							{
								mallaArticulo.bodega = ""; //cmbBodega.SelectedValue.ToString();
							}
							catch { }
							saltaEventosMalla = true;
							mallaArticulo.digCostos = valoresPredefinidosEmpresa.nroDigitosEnCostos;
							mallaArticulo.digPrecios = valoresPredefinidosEmpresa.nroDigitosEnPrecios;
							mallaArticulo.fechaDoc = idDocumentoActual.fecha;
							mallaArticulo.impIva = 0;// claseImpuestos.impstoPorcentaje1;
							mallaArticulo.codCliente = codCliente;
							mallaArticulo.sucursal = datosEmpresa.suc;
							mallaArticulo.tipoDoc = idDocumentoActual.Tipo;
							mallaArticulo.numDoc = idDocumentoActual.numero.ToString();

							if (keyData == Keys.F2)
							{
								dato = mallaArticulo.BuscarArticuloSimple(malla.CurrentCell.Value.ToString());
								if (mallaArticulo.CargarArticulo(malla, ref propiedadesDoc, dato, opalex.TipoCliente, idDocumentoActual.fecha.ToShortDateString(), propiedadesDoc.Documento, idDocumentoActual.idClave) == false) { cell.Value = ""; keyData = Keys.Cancel; }
							}
							//else if (keyData == Keys.F3)
							//{
							//    DaxConceptos.classConceptos buscserv = new DaxConceptos.classConceptos();
							//    dato = buscserv.iniciaBuscador(datosEmpresa.strConxAdcom, "", "V", false, false);
							//    if (dato != "") mallaArticulo.CargarServicios(dato, ref malla, claseImpuestos.impstoPorcentaje1, valoresPredefinidosEmpresa.nroDigitosEnPrecios, Convert.ToDateTime(txtfecha.Text), ref propiedadesDoc);
							//}
							else if (keyData == Keys.Return && dato.Length > 0)
							{
								if (mallaArticulo.CargarConDesicion(malla, ref propiedadesDoc, dato, opalex.TipoCliente, idDocumentoActual.fecha.ToShortDateString(), propiedadesDoc.Documento, idDocumentoActual.idClave) == false) { cell.Value = ""; keyData = Keys.Cancel; }
							}
							else if (keyData == Keys.F11)
							{
								dato = mallaArticulo.BuscarArticulo(malla.CurrentCell.Value.ToString());
								if (mallaArticulo.CargarArticulo(malla, ref propiedadesDoc, dato, opalex.TipoCliente, idDocumentoActual.fecha.ToShortDateString(), propiedadesDoc.Documento, idDocumentoActual.idClave) == false) { cell.Value = ""; keyData = Keys.Cancel; }
							}

							//        VerificarClasificadoresContablesArticulo dato
						}
						break;
					case "DOC_BODEGA":
					case "TRA_EMPLEADO":
					case "TRA_VENCE":
					case "FACDESDE":
					case "FACHASTA":
						if (keyData == Keys.F2)
						{
							BusquedasDetalleDocumentos.BuscarValor(cell, nombreCelda);
						}
						break;
					case "TRA_COSTO":
					case "TRA_CENTROPRODUCCION":
					case "TRA_CENTRODISTRIBUCION":
					case "TRA_PROYECTO":
						if (keyData == Keys.F2)
						{
							BusquedasDetalleDocumentos.BuscarValor(cell, nombreCelda);
						}
						break;
				}
			}
			if (cell.Value.ToString() != "") { keyData = Keys.Return; } else { keyData = Keys.Cancel; }
			saltaEventosMalla = false;
			//totalizar();
			mallaArticulo = null;
			return resp;
		}

		private string registrarFormaDePagoPredefinida()
		{
			if (opalex.FormaPago != null && opalex.FormaPago.Length > 0) return opalex.FormaPago;
			if (valoresPredefinidosEmpresa.formaPagoPredefinidaVtas.Length > 0) return valoresPredefinidosEmpresa.formaPagoPredefinidaVtas;
			return "EFE";
		}

		//private void crearPagoPredefinido(string IdPago)
		//{
		//	if (IdPago == "") IdPago = "EFE";
		//	clasePagos.DocValor = Convert.ToDouble(edTotal.Text);
		//	clasePagos.DocFecha = txtfecha.Value;
		//	clasePagos.DocNumero = Convert.ToDouble(txtnumero.Text);
		//	clasePagos.DocSucursal = datosEmpresa.suc;
		//	clasePagos.Doctipo = cmbDocumento.SelectedValue.ToString();
		//	clasePagos.pagosDelDocumento.Add( DaxComercia.utility.CrearPagoDocumento (IdPago, clasePagos.DocValor));
		//}

		private void imprimirDocumento()
		{
			if (accesosLocalizados.NroImpresiones > 0 && accesosLocalizados.NroImpresiones <= datADCDOC.Doc_Adicional1)
			{ MessageBox.Show("Ha llegado al límite de impresiones permitidas", "Imprimir documentos", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
			ImpresionDocumentosDax.ImprimeDocumentoDoble impProg = new ImpresionDocumentosDax.ImprimeDocumentoDoble(datosEmpresa.nombreBaseIvaret, datosEmpresa.strConxAdcom, datosEmpresa.strConxIvaret, datosEmpresa.strConxSyscod, datosEmpresa.strConxDaxpro, datosEmpresa.codEmpresa, datosEmpresa.pathServer);
			int imp = impProg.ImpDoc(idDocumentoActual, "A", "", false, false);
			datADCDOC.Doc_Adicional1 = imp;
		}
		private void malla_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			MessageBox.Show("Error de dato digitado, el valor registrado es inválido");
		}


		private void malla_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			if (malla.Rows.Count == 0) dtDetalleDocumento.Rows.Add(dtDetalleDocumento.NewRow());
		}

		private void btnVerificar_Click(object sender, EventArgs e)
		{
			if (MallaIngreso.Rows.Count == 0) MessageBox.Show("No existen productos en la transferencia para verificar");
			AgruparMalla docut = new AgruparMalla();
			if (malla.Rows.Count < 2) return;
			docut.AcumularLineasMalla(malla, "tra_cantidad", "tra_codigo", "");
			CargarDiferencias();
		}

		private void btnImprimir_Click(object sender, EventArgs e)
		{
			DataGridViewPrinterApplication1.frmMain  impm = new DataGridViewPrinterApplication1.frmMain ();
			//DataGridView mallatmp=new DataGridView();
			//foreach (DataGridViewRow dgvr in malla.Rows )
   //         {
			//	if (dgvr.Cells["Tra_codigo"].Value != null)
			//	{
			//		if (dgvr.Cells["Tra_codigo"].Value.ToString().Length > 0)
			//		{
			//			mallatmp.Rows.Add(dgvr); 
			//		}
			//	}
   //         }
			impm.imprimir (malla, "DIFRENCIAS ENTRE ENVIO Y RECEPCIÓN  SUC :" + idDocumentoActual.Sucursal + " - DOC: " + idDocumentoActual.Tipo + "-" + idDocumentoActual.numero,"", datosEmpresa.codEmpresa.ToString());
		}

		private void btnSalir_Click_1(object sender, EventArgs e)
		{
			Close();
		}
		private void CargarDiferencias()
		{
			foreach (DataGridViewRow dgvrow in malla.Rows)
			{
				{
					dgvrow.Cells["Enviado"].Value = 0;
					dgvrow.Cells["Diferencia"].Value = 0;
				}
			}

			foreach (DataGridViewRow RowDoc in MallaIngreso.Rows)
			{
				string codigoProdDoc = "";
				double CantEnviada = 0;
				bool CodigoEnConteo = false;
				try
				{
					codigoProdDoc = RowDoc.Cells["tra_codigo"].Value.ToString();
					CantEnviada = Convert.ToDouble(RowDoc.Cells["Tra_cantidad"].Value);
				}
				catch { }
				if (codigoProdDoc.Length > 0)
				{
					
					foreach (DataGridViewRow dgvrow in malla.Rows)
					{
						//try { recibido = Convert.ToDouble(dgvrow.Cells["Tra_cantidad"].Value); } catch { recibido = 0; }
						//if (recibido>0)
						{
							if (dgvrow.Cells["Tra_codigo"].Value.ToString().ToUpper() == RowDoc.Cells["Tra_codigo"].Value.ToString().ToUpper())
							{
								dgvrow.Cells["Enviado"].Value = CantEnviada + Convert.ToDouble("0"+dgvrow.Cells["Enviado"].Value);
								CodigoEnConteo = true;
							}
						}
					}
				}
				if (!CodigoEnConteo)
                {
					((DataTable)malla.DataSource).Rows.Add();
					DataGridViewRow mallarow = malla.Rows[malla.RowCount - 1];
					mallarow.Cells["tra_codigo"].Value = RowDoc.Cells["tra_codigo"].Value;
					mallarow.Cells["Enviado"].Value = RowDoc.Cells["tra_cantidad"].Value;
				}
			}
			foreach (DataGridViewRow dgvrow in malla.Rows)
			{
				{
					dgvrow.Cells["Diferencia"].Value = Convert.ToDouble("0" + dgvrow.Cells["tra_cantidad"].Value) - Convert.ToDouble("0" + dgvrow.Cells["Enviado"].Value);
				}
			}
		}

        private void malla_KeyDown(object sender, KeyEventArgs e)
        {
			if (e.KeyCode == Keys.Delete)
            {
				DataTable dt = (DataTable)malla.DataSource;
				dt.Rows.Remove(dt.Rows[malla.CurrentRow.Index]);
            }
        }
    }
}