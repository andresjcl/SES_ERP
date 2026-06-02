using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using daxMallaDatos;
using DaxComercia;
using classMenSistem;
using ClassDoc;
using System.Drawing;
using SysEmpDatt;


namespace adcDocumentos
{
	public partial class FormRegCajaChica : Form
	{
		DaxMantDirectorio.DirectorioAlex opalex = new DaxMantDirectorio.DirectorioAlex();
		DataTable datosLiquidacion = new DataTable();

		bool iniciaConNuevoDOc = false;
		Boolean esSoloConsulta = false;

		idDocumento idDocumentoActual = new idDocumento();
		double PorcentajeIVA = 0;

		string codResponsable = "";
		Boolean saltarEventoNumero = false;
		Boolean saltaEventosMalla = false;

		int operacionEnCurso = 0; // 0 sin operacion delcarada, 1 nuevo registro, 2 modificando registro
		int sinOperacion = 0;
		int nuevoRegistro = 1;
		int modificandoRegistro = 2;

		public FormRegCajaChica(bool nuevo = false, Boolean esConsulta = false,  idDocumento idDocViene = null)
		{
			InitializeComponent();
			CargarValoresIniciales();
			iniciaConNuevoDOc = nuevo;

			if (idDocViene == null) idDocViene = new idDocumento();
			if (idDocViene.idClave > 0 && esConsulta)
			{
				idDocumentoActual = idDocViene;
			}
		}
		private void CargarValoresIniciales()
		{
			LlenarCombos();
			this.Text = "ADCOMDAX - MANTENIMIENTO LIQUIDACIONES DE CAJA CHICA  : " + datosEmpresa.nomEmpresa + " SUCURSAL : " + datosEmpresa.SucursalNombre ;
			IvaRett.valorIva dciva = new IvaRett.valorIva();
			PorcentajeIVA = dciva.ValorIvaAfecha(txtfecha.Value, datosEmpresa.strConxIvaret)/100;

		}

		private void formFacPv_Load(object sender, EventArgs e)
		{
			if (idDocumentoActual.idClave != 0)
			{
				cargarDatosLiquidacion(idDocumentoActual.Sucursal, Convert.ToInt64(idDocumentoActual.numero));
			}
			else
			{
				if (iniciaConNuevoDOc) iniciarNuevoDocumento();
			}
			prepararBotones();
		}

		private void LlenarCombos()
		{
			DaxCombobx.CargCmbBox cmb = new DaxCombobx.CargCmbBox();
			cmb.DaxCombosSuc(datosEmpresa.codEmpresa.ToString(), false, datosEmpresa.strConxDaxsys, ref cmbSucursal);
		}
		private void prepararBotones()
		{
			Boolean inicio = (operacionEnCurso == sinOperacion);
			Boolean nuevo = (operacionEnCurso == nuevoRegistro);
			Boolean modificando = (operacionEnCurso == modificandoRegistro);
			Boolean docAnulado = false;
	
			btnAbre.Enabled = inicio;
			btnNuevo.Enabled = inicio;


			btnAnula.Enabled = (modificando && !docAnulado);
			btnElimina.Enabled = modificando;
			btnImprimir.Enabled  = modificando;
			btnGraba.Enabled = (!inicio && !docAnulado);
			btnRegistra.Enabled = btnGraba.Enabled;
			btnEnviar.Enabled = (modificando && !docAnulado);
			btnCierra.Enabled = !inicio;
			panel1.Enabled = (!inicio);
			malla.Enabled = (!inicio);

			txtcedula.Enabled = (!docAnulado);
			if (datosEmpresa.usr.ToUpper() == "ADMINISTRADOR" || inicio ) return;
			if (inicio) return;

			if (esSoloConsulta == true || docAnulado)
			{
				btnGraba.Enabled = false;
				btnRegistra.Enabled = false;
				btnElimina.Enabled = false;
				btnAnula.Enabled = false;
			}
			
		}

		private void BtnSalir_Click(object sender, EventArgs e)
		{
			if (classMenSistem.mensajesErrorDocumento.ConfirmaCerrar()) this.Close();
		}

		private void BuscaCliente(string buscador)
		{
			DaxMantDirectorio.BuscaClien directorio = new DaxMantDirectorio.BuscaClien();
			string cliente = "E";
			string codigo = "";
			string nombre = "";
			string conalias = "N";
			string connuevo = "N";
			codigo = directorio.IniBuscaCliOPro(ref cliente, ref nombre, ref conalias, ref connuevo);
			if ((codigo + "").Length > 0) cargarDatosCliente(codigo);
			directorio.Dispose();
		}
		private void cargarDatosCliente(string codigo = "")
		{
			// utilBasDatos datt = new utilBasDatos();
			if (codigo != "")
			{
				string solocodigo = "";
				Boolean x = false;
				opalex = new DaxMantDirectorio.DirectorioAlex();
				opalex.CargarAlex(ref codigo, ref x, ref solocodigo);
				if (opalex.codigo == null) codigo = ""; else codigo = opalex.codigo;
				if (codigo.Length > 0)
				{
					codResponsable = opalex.codigo;
					txtcedula.Text = opalex.CiRuc;
					txtnombrecliente.Text = opalex.NombreImpresion;
				}
			}
			if (codigo == "")
			{
				codResponsable = "";
				txtcedula.Text = "";
				txtnombrecliente.Text = "";
				opalex = null;
			}
		}
        private Boolean cargarDatosLiquidacion(string SUC, Int64 NUMERO)
		{
			Boolean resp = false;
			if (NUMERO != 0)
			{
					cargarTablaDatos(SUC,NUMERO);
					if (datosLiquidacion.Rows.Count > 0)
				{
					cargarDatosCliente(datosLiquidacion.Rows[0]["Responsable"].ToString());
					malla.DataSource = datosLiquidacion;
					totalizar();
					operacionEnCurso = modificandoRegistro;
					prepararBotones();
					resp = true;
					txtnumero.Text = NUMERO.ToString ();
					txtnumero.Enabled = false;
					cmbSucursal.Enabled = false;
				}
			}
			else { }
			return resp;
		}
		private void cargarTablaDatos(string sucursal, Int64 numero)
		{
			string ssql = "select DaxLiqCajChica.*,NombreImpresion as NombreProveedor from DaxLiqCajChica left join identificacion on codigo = codproveedor ";
			ssql += " where sucursal = '" + sucursal + "' and NroLiquidacion = " + numero.ToString() + " ";
			datosLiquidacion = SqlDatos.leerTablaAdcom(ssql);
			if (datosLiquidacion == null) return;
			malla.DataSource = datosLiquidacion;
			datosLiquidacion.Rows.Add(datosLiquidacion.NewRow());
			diseñarMalla();
		}


		private void btnCie5rra_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Confirma cerrar el documento actual ?", "Cerrar documento sin grabar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
			limpiarDatos();
		}
		private void limpiarDatos()
		{
			txtnumero.Enabled = true;
			cmbSucursal.Enabled = true;
			txtnumero.Text = "";
			txtnombrecliente.Text = "";
			txtcedula.Text = "";
			mensajesDocumento.Text = "";
			idDocumentoActual = new idDocumento
			{
				idClave = 0,
				fecha = txtfecha.Value
			};
			datosLiquidacion = new DataTable();
			malla.DataSource = null;
			//presentarTotales();
			txtfecha.Value = DateTime.Now ;
			operacionEnCurso = 0;
			edTotal.Text = "0";
			prepararBotones();
			//            InicializarMalla();
		}
		private void InicializarMalla()
		{
			//  this.malla.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
			//" select * from DaxLiqCajChica where sucursal = '' and NroLiquidacion = 0");
			cargarTablaDatos("",0);
			
		}
		private void diseñarMalla()
        {
		
			foreach (DataGridViewColumn dgvcol in malla.Columns)
            {
				dgvcol.Visible = false;
				dgvcol.ReadOnly = true;
            }

			malla.Columns["CodProveedor"].Visible = true;
			malla.Columns["CodProveedor"].ReadOnly = false;
			malla.Columns["FechaFactura"].Visible = true;
			malla.Columns["FechaFactura"].ReadOnly = false;
			malla.Columns["FechaFactura"].DefaultCellStyle.Format = "dd/MM/yyyy";
			malla.Columns["NroFactura"].Visible = true;
			malla.Columns["NroFactura"].ReadOnly = false;

			malla.Columns["DescripciónCompra"].Visible = true;
			malla.Columns["DescripciónCompra"].ReadOnly = false;

			malla.Columns["IDFactura"].Visible = true;
			malla.Columns["IDFactura"].ReadOnly = false;

			malla.Columns["ValorNeto"].Visible = true;
			malla.Columns["ValorNeto"].ReadOnly = false;
			malla.Columns["ValorNeto"].DefaultCellStyle.Format  = "0.00";
			malla.Columns["ValorNeto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			malla.Columns["ValorIva"].Visible = true;
			malla.Columns["ValorIva"].ReadOnly = false;
			malla.Columns["ValorIva"].DefaultCellStyle.Format = "0.00";
			malla.Columns["ValorIva"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			malla.Columns["ValorTotal"].Visible = true;
			malla.Columns["ValorTotal"].DefaultCellStyle.Format = "0.00";
			malla.Columns["ValorTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			malla.Columns["NombreProveedor"].Visible = true;
			malla.Columns["NombreProveedor"].DisplayIndex = 6;
		}
		private void malla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex < 0 || saltaEventosMalla == true)
			{
				return;
			}

			string nomCol = malla.Columns[e.ColumnIndex].Name.ToUpper();
			if (nomCol == "ValorNeto" || nomCol == "ValorIva" ) totalizar();
		}


		#region EVENTOS DE CONTROLES
		#region EVENTOS DE BOTONES


		private void btnEnviar_Click(object sender, EventArgs e)
		{
			imprimirDocumento();
		}
		private void btnBuscaCliente_Click(object sender, EventArgs e)
		{
			BuscaCliente(txtnombrecliente.Text);
		}
		private void BtnAbre_Click(object sender, EventArgs e)
		{
			idDocumentoActual.Sucursal = datosEmpresa.suc;
			DateTime queFecha = DateTime.Now;
			BuscadorDocumentos.BuscCajaChica progbus = new BuscadorDocumentos.BuscCajaChica("","");
			idDocumentoActual= progbus.BuscarDocCajaChica();
			if (idDocumentoActual.numero == 0)
			{
				idDocumentoActual.Sucursal = datosEmpresa.suc; return;
			}
			if (idDocumentoActual.numero != 0) cargarDatosLiquidacion(idDocumentoActual.Sucursal, Convert.ToInt64( idDocumentoActual.numero));
		}
		private void btnGraba_Click(object sender, EventArgs e)
		{
			if (validarDocumento() == true)
			{
				if (grabarDocumento() == true) { limpiarDatos(); }
			}
		}
		
		private void btnNuevo_Click(object sender, EventArgs e)
		{
			iniciarNuevoDocumento();
		}
		private void iniciarNuevoDocumento()
		{
			limpiarDatos();
			InicializarMalla();
			idDocumentoActual = new idDocumento
			{
				familia = "",
				fecha = txtfecha.Value,
				numero = Convert.ToDouble("0" + txtnumero.Text),
				Serie = "",
				Sucursal = datosEmpresa.suc,
				Tipo = "LQC"
			};
			edTotal.Text = "0";
			//	string bod = "";
			//	if (cmbBodega.SelectedValue != null) {bod = cmbBodega.SelectedValue.ToString(); } else { bod = datosEmpresa.Bodega; }
			txtfecha.Value = DateTime.Now;
			ClassDoc.controlNumeracion cnum = new controlNumeracion();
			txtnumero.Text = cnum.NumeroMayor(idDocumentoActual, "", "", "", datosEmpresa.strConxAdcom).ToString();
			operacionEnCurso = 1;
			prepararBotones();
		}

		private void btnRegistra_Click(object sender, EventArgs e)
		{
			if (validarDocumento() == true)
			{
				if (grabarDocumento() == true)
				{
					//EnviarAimpresora.imprimirDocumentoDirectamente(datosLiquidacion, accesosLocalizados, idDocumentoActual);
					limpiarDatos();
				}
			}
		}
		
		private void btnElimina_Click(object sender, EventArgs e)
		{
		}


		#endregion EVENTOS DE BOTONES
		#region EVENTOS DE CAJAS DE TEXTO

		private void Txtcedula_Leave(object sender, EventArgs e)
		{
			KeyEventArgs ee = new KeyEventArgs(Keys.Return);
			txtcedula_KeyDown(sender, ee);
		}

		private void txtcedula_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return && txtcedula.Text.Length > 0) ingresaCodigoClienteDirecto();
		}
		private void ingresaCodigoClienteDirecto()
		{
			string codigo = txtcedula.Text;
			string tipo = "C";
			cargarDatosCliente(codigo);
			if (txtcedula.Text == "")
			{
				if (MessageBox.Show("El cliente no existe desea registarlo ? ", "Creacion de cliente nuevo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
				{

					DaxMantDirectorio.CreaCliAlex express = new DaxMantDirectorio.CreaCliAlex();
					express.IniCrearAlex(ref tipo, ref codigo);
				}
			}
			if ((codigo + "").Length > 0) cargarDatosCliente(codigo);
		}

		private void txtnumero_Leave(object sender, EventArgs e)
		{
			if (saltarEventoNumero == true) { saltarEventoNumero = false; return; }
			if (operacionEnCurso != 2)
			{
				verificaNroDocumentoDigitado();
			}
		}
		private void txtnumero_KeyDown(object sender, KeyEventArgs e)
		{
			saltarEventoNumero = true;
			if (e.KeyCode == Keys.Return)
			{
				verificaNroDocumentoDigitado();
			}
		}
		private void verificaNroDocumentoDigitado()
		{
			LlenarIdDocumento(ref idDocumentoActual);
			//impresionVerificacion.verificarExistenciaDocumento(ref idDocumentoActual, datosEmpresa.strConxAdcom,false, "ADCDOC", txtNroID.Text);
			//if (idDocumentoActual.idClave > 0) cargarDatosLiquidacion(idDocumentoActual.Sucursal, idDocumentoActual.Tipo, idDocumentoActual.idClave);
		}


		#endregion EVENTOS DE CAJAS DE TEXTO

		#endregion EVENTOS DE CONTROLES
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
				DaxMallaLib.Documentos.MoverCelda(malla,false);
				return true;
			}
			return false;
		}

		#endregion manejo malla
		private Boolean funcionesEspeciales(ref Keys keyData, DataGridView malla)
		{

			//docMallaArticulo mallaArticulo = new docMallaArticulo();
			Boolean resp = true;
			malla.EndEdit();
            DataGridViewCell cell = malla.CurrentCell;
            string dato = cell.Value.ToString();
            string nombreCelda = cell.OwningColumn.Name.ToUpper();

            if (keyData == Keys.F8 && cell.ReadOnly == false && malla.Columns[cell.ColumnIndex].Name.ToUpper() != "CodProveedor".ToUpper())
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
                    case "CODPROVEEDOR":
						DaxMantDirectorio.BusDirectorio bus = new DaxMantDirectorio.BusDirectorio();
						string nombre = "";
						cell.Value = bus.BusDirect("", "",ref nombre , "P","S");
						malla.Rows[cell.RowIndex].Cells["NombreProveedor"].Value = nombre;
						break;
                    case "IDFACTURA":
						if (!ValidaId(cell.Value.ToString())) cell.Value = ""; 
						break;
                }
            }
            if (cell.Value.ToString() != "") { keyData = Keys.Return; } else { keyData = Keys.Cancel; }
            saltaEventosMalla = false;
            totalizar();
            return resp;
		}      
	
		private void imprimirDocumento()
		{
			//if (accesosLocalizados.NroImpresiones > 0 && accesosLocalizados.NroImpresiones <= datosLiquidacion.Doc_Adicional1)
			//{ MessageBox.Show("Ha llegado al límite de impresiones permitidas", "Imprimir documentos", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
			//ImpresionDocumentosDax.ImprimeDocumentoDoble impProg = new ImpresionDocumentosDax.ImprimeDocumentoDoble(datosEmpresa.nombreBaseIvaret, datosEmpresa.strConxAdcom, datosEmpresa.strConxIvaret, datosEmpresa.strConxSyscod, datosEmpresa.strConxDaxpro, datosEmpresa.codEmpresa, datosEmpresa.pathServer);
			//int imp = impProg.ImpDoc(idDocumentoActual, "A", "", false, false);
			//datosLiquidacion.Doc_Adicional1 = imp;
		}
		private void malla_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			MessageBox.Show("Error de dato digitado, el valor registrado es inválido");
		}

		private Boolean validarDocumento()
		{
			if (Convert.ToDouble("0" + txtnumero.Text) == 0) { mensajesErrorDocumento.MensajeNumeroDoc(); txtnumero.Focus(); return false; }
			if (ValidacionDocumentos.ValidacionGeneral.validarFecha(txtfecha.Text, datosEmpresa.usr) == false) { return false; };
			if (opalex.codigo == "" || codResponsable == "" || txtcedula.Text == "") { mensajesErrorDocumento.ElCodigoNoExiste("C"); return false; }
			return true;
		}
		private bool ValidaId(string IdDocumento)
		{
			bool Vale = false;
			if (IdDocumento.Length == 7)
			{
				if (!(Convert.ToInt32(IdDocumento.Substring(0, 3)) > 0 && IdDocumento.Substring(3, 1) == "-" && Convert.ToInt32(IdDocumento.Substring(4, 3)) > 0))
				{ Vale = false; }
				else 
				{ Vale = true; }
			}

			return Vale;
		}

		private Boolean grabarDocumento()
		{
            malla.EndEdit();
            Boolean RESP = true;
			Int32 NroLinea = NuevoNumeroDeLinea(idDocumentoActual.Sucursal,txtnumero.Text);
            string res = "";
            try
            {

				for (int i = 0;i<datosLiquidacion.Rows.Count;i++)
				{
					DataRow dRow = datosLiquidacion.Rows[i];
					if (!(dRow["CodProveedor"].ToString().Length > 0))
					{
						dRow.Delete();
					}
				}

				foreach (DataRow dRow in datosLiquidacion.Rows)
				{

					if (Convert.ToInt32("0" + dRow["NroLinea"].ToString()) == 0)
					{
						dRow["NroLinea"] = NroLinea; NroLinea++;
						dRow["Sucursal"] = idDocumentoActual.Sucursal;
						dRow["NroLiquidacion"] = txtnumero.Text;
						dRow["FechaLiq"] = txtfecha.Value;
						dRow["Responsable"] = codResponsable;
					}
				}

				string ssql = " select * from DaxLiqCajChica where sucursal = '" + idDocumentoActual.Sucursal  + "' and NroLiquidacion = " + txtnumero.Text ;
				SqlDataAdapter da = new SqlDataAdapter(ssql,datosEmpresa.strConxAdcom);
				SqlCommandBuilder cb = new SqlCommandBuilder(da);
				da.Update(datosLiquidacion);
            }
            catch (Exception ee)
            {
                res = "ERR " + ee.Message;
            }
            if ((res+"    ").Substring(0, 3) == "ERR")
            {
                MessageBox.Show("EL DOCUMENTO NO FUE GRABADO CORRECTAMENTE \n" + res);
                RESP = false;
            }
            return RESP;
		}

		private void totalizar()
		{
            if (malla.Rows.Count < 1) return;
			double totalDoc = 0;
			double valIva = 0;
			double valNeto = 0;
			foreach (DataGridViewRow dgvrow in malla.Rows)
			{
				valNeto = Convert.ToDouble("0" + dgvrow.Cells["ValorNeto"].Value);
				valIva = Convert.ToDouble("0" + dgvrow.Cells["ValorIva"].Value);
				valIva = Math.Round( valNeto * PorcentajeIVA,2);
				dgvrow.Cells["ValorIva"].Value = valIva;
				dgvrow.Cells["ValorTotal"].Value = valIva + valNeto;
				totalDoc += valIva + valNeto;
			}
			edTotal.Text = totalDoc.ToString("#,0.00");
		}
		private void LlenarIdDocumento(ref idDocumento docmtoActual)
		{
			docmtoActual.Sucursal=datosEmpresa.suc ;
			docmtoActual.Tipo ="LQC";
			docmtoActual.fecha = txtfecha.Value;
			try
			{
				docmtoActual.numero = Convert.ToDouble(txtnumero.Text);
			}
			catch { docmtoActual.numero = 0;}
		}
		private Int32  NuevoNumeroDeLinea(string sucursal, string NroLiquidacion )
        {
			Int32 linea = 1;
			SqlDataReader dr = SqlDatos.leerBaseAdcom(" select isnull(max(NroLinea),0) as NroLinea from DaxLiqCajChica where sucursal = '" + sucursal + "' and NroLiquidacion = " + NroLiquidacion);
			if (dr.Read()) linea = Convert.ToInt32(dr["NroLinea"]) + 1;
			return linea;
        }
		private void ChequearCambioValoresPoFecha()
		{
			//if (malla.Rows.Count > 1) totalizar();            
		}

		private void malla_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			if (malla.Rows.Count  == 0) datosLiquidacion.Rows.Add(datosLiquidacion.NewRow());
            totalizar();
		}
    }
}