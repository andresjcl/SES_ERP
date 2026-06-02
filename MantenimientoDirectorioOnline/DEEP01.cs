using DattCom;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
//using RucConsultarNetLib;

using System.Linq;
using System.IO;

namespace MantenimientoDirectorioOnline
{
	public partial class DEEP01 : Form
	{
		//private RucService _rucService;

		private daaxLib.DaxLibDigDato DaaxLibDat = new daaxLib.DaxLibDigDato();
		private EmpNomR.AdcNomb RetornaNombre = new EmpNomR.AdcNomb();
		internal string CodSuc;

		private string[] codigoDirectorio = new string[7];
		private bool Cambio;
		private string resp;
		private int ii;
		private string CodigoStr;
		private string entrega;
		private string CodigoBusca;
		public string tipoper;
		public string cedulabusca;
		public string Sexo;
		private bool CambioAdicionales;
		public string CodigoFoto = "";
		private int Indice;
		private string[] TipCodSyscod = new string[50];
		private bool IniNvo;
		public string QUECODIGO;
		private bool propio;
		public string CodigoDirectorio;
		string tipoDocumento = "";



		private int EsNuevo;

		private bool Act1;
		private string[] Operacion = new string[3];
		private bool saltar = true;
		private string accion = "";
		private ClassCambios LosCambios = new ClassCambios();

		private mntUsrs.autorizacion autorizaOpcion = new mntUsrs.autorizacion();
		private string claveOpcion = "mnuoDirectorioGeneral";
		private string ImgDirectorio = "\\Directorio";

		private DaxCombobx.CargCmbBox dc = new DaxCombobx.CargCmbBox();
		string resultadoConsulta = "";
		public DEEP01()
		{
			try
			{
				InitializeComponent();
				//cargar.iniciar("", "");
				//iniciar();
				//var rutaCaptcha = @"D:\Proyectos\imagenes\captcha\png";

				var rutaCaptcha = Path.Combine(datosEmpresa.Emp_PathImagenes, @"captcha\png");

				if (!Directory.Exists(rutaCaptcha))
				{
					MessageBox.Show($"La carpeta no existe: {rutaCaptcha}");
					return;
				}
				//else
				//{
				//	Console.WriteLine("Carpeta encontrada.");
				//}
				//var rutaCaptcha = datosEmpresa.Emp_PathImagenes+ @"captcha\png";  
				//_rucService = new RucService(rutaCaptcha);

			}
			catch (Exception ex)
			{

				//int num = (int)MessageBox.Show("E0inicIALIZE" + ex.Message);
				//Environment.Exit(0);
			}

		}

		private void iniciar()
		{
			try
			{
				//cargar.iniciar("", "");
				//if (datosEmpresa.codEmpresa == (short)0)
				//{
				//	int num = (int)MessageBox.Show("No se ha conectado al servidor ", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				//	Environment.Exit(0);
				//}


			}
			catch (Exception ex)
			{
				int num = (int)MessageBox.Show("E0inicio" + ex.Message);
				Environment.Exit(0);
			}
		}

		public void IniciaNuevo()
		{
			try
			{
				IniNvo = true;
				this.ShowDialog();
			}
			catch (Exception ee)
			{
				MessageBox.Show("excepción iniNvo: " + ee.Message);
			}
		}
		private void btnNuevo_Click(object sender, EventArgs e)
		{
			//habilitar();
			CrearNuevo();
		}

		private void CrearNuevo()
		{
			LimpiezaFormulario();
			QUECODIGO = "";
			//Juridica.Checked = true;
			//PonerDatosTipo();
			EsNuevo = 1;
			PonerBotonesFormulario();
			accion = "guardar";
			ChequearAutorizacion("T");
			//Codigo.Focus();
			CambioAdicionales = false;
		}

		private void LimpiezaFormulario()
		{
			//Codigo.ReadOnly = false;
			Limpiar(this);
			// limpiarGrid(Grid);
			CambioAdicionales = false;

			Natural.Checked = false;
			Juridica.Checked = false;
			Cliente.Enabled = false;
			Proveedor.Enabled = false;
			Empleado.Enabled = false;
			EsVendedor.Enabled = false;
			Banco.Enabled = false;
			TxtApellidos.Visible = false;
			label96.Visible = false;
			// Al iniciar el formulario o al inicializar controles
			fechanaci.Value = new DateTime(1900, 1, 1);

		}

		//private void Limpiar(Form oBJ)
		//{
		//	// Recursive method to handle container controls
		//	void CleanControls(Control parentControl)
		//	{
		//		foreach (Control control in parentControl.Controls)
		//		{
		//			// Recursively clean child controls if this is a container
		//			if (control.HasChildren)
		//			{
		//				CleanControls(control);
		//			}

		//			// Clear control contents based on type
		//			switch (control)
		//			{
		//				case TextBox textBox:
		//					textBox.Text = string.Empty;
		//					break;
		//				case Label label when label.BackColor == System.Drawing.Color.White:
		//					label.Text = string.Empty;
		//					break;
		//				case ComboBox comboBox:
		//					comboBox.SelectedValue = null;
		//					break;
		//				case MaskedTextBox maskedTextBox:
		//					maskedTextBox.Text = "  /  /";
		//					break;
		//			}
		//		}
		//	}

		//	// Clean all controls in the form
		//	CleanControls(oBJ);

		//	// Reset specific form controls
		//	chkObligaContabilidad.Checked = false;
		//	chkRegimenMicroempresas.Checked = false;
		//	chkRise.Checked = false;
		//	ExoneradoIva.Checked = false;
		//	txtContribuyenteEspecial.Text = string.Empty;
		//}

		private void Limpiar(Form oBJ)
		{
			void CleanControls(Control parentControl)
			{
				foreach (Control control in parentControl.Controls)
				{
					if (control.HasChildren)
					{
						CleanControls(control);
					}

					switch (control)
					{
						case TextBox textBox:
							textBox.Text = string.Empty;
							break;
						case Label label when label.BackColor == System.Drawing.Color.White:
							label.Text = string.Empty;
							break;
						case ComboBox comboBox:
							// Safer way to clear ComboBox
							if (comboBox.Items.Count > 0)
							{
								comboBox.SelectedIndex = -1;  // This is safer than SelectedValue = null
							}
							break;
						case MaskedTextBox maskedTextBox:
							maskedTextBox.Text = "  /  /";
							break;
					}
				}
			}

			CleanControls(oBJ);

			// Clear specific controls
			//chkObligaContabilidad.Checked = false;
			//chkRegimenMicroempresas.Checked = false;
			//chkRise.Checked = false;
			//ExoneradoIva.Checked = false;
			txtContribuyenteEspecial.Text = string.Empty;
		}

		private void PonerBotonesFormulario()
		{
			btnNuevo.Visible = (EsNuevo == 0);
			btnAbrir.Visible = (EsNuevo == 0);
			btnCerrar.Visible = (EsNuevo > 0);
			btnGuardar.Visible = (EsNuevo == 2 || EsNuevo == 1);
			btnEliminar.Visible = (EsNuevo == 2 || EsNuevo == 1);
			this.Text = " Mantenimiento DIRECTORIO CLIENTES - " + Operacion[EsNuevo];
		}

		private void ChequearAutorizacion(string Autorizacion)
		{
			bool Autorizado = (Autorizacion == "T");
			btnEliminar.Checked = Autorizado;
			txtLimiteCredito.Enabled = Autorizado;
			tabCliente.Enabled = Autorizado;
			txtFormaPago.Enabled = Autorizado;
			txtPorcDescuento.Enabled = Autorizado;
			txtLimiteCredito.Enabled = Autorizado;
			//ExoneradoIva.Enabled = Autorizado;
		}

		public void Mainn()
		{
			try
			{
				// If connection string is empty, exit the method
				if (string.IsNullOrWhiteSpace(datosEmpresa.strConxAdcom))
					return;
			}
			catch (Exception ee)
			{
				MessageBox.Show("excepción mainn: " + ee.Message);
				return;
			}

			
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			// Initialize form state
			if (string.IsNullOrEmpty(TxtCedulaRuc.Text))
			{
				EsNuevo = 0;
				PonerBotonesFormulario();
			}

			Mainn();
			Valores.iniciaValores(TipCodSyscod);

			// Set button visibility based on system type
			btnCargarCapacitacion.Visible = (datosEmpresa.sistema == "DAX" || datosEmpresa.sistema  == "ERP");

			// Configure grid columns
			malla.Columns[0].Visible = false;

			// Initialize operation messages
			Operacion[0] = "";
			Operacion[1] = " CREANDO NUEVO REGISTRO ";
			Operacion[2] = " MODIFICANDO REGISTRO EXISTENTE ";

			// Set default values
			Natural.Checked = true;
			DatosDirectorio.SelectedIndex = 0;

			// Configure mallaDatos DataGridView
			mallaDatos.ColumnCount = 1;
			mallaDatos.RowCount = 15;
			mallaDatos.RowHeadersWidth = 140;
			mallaDatos.Columns[0].ReadOnly = true;
			mallaDatos.Columns[0].Width = 130;

			// Configure mallaConceptos DataGridView
			mallaConceptos.ColumnCount = 1;
			mallaConceptos.RowCount = 15;
			mallaConceptos.RowHeadersWidth = 150;
			mallaConceptos.Columns[0].ReadOnly = true;
			mallaConceptos.Columns[0].Width = 30;

			saltar = false;

			// Set tab visibility based on role
			TabDatosEmpleado.Visible = Emp.rol;
			if (Emp.rol)
			{
				cargarMallaDatos();
				cargarMallaConceptos();
				cargarNombreGrupos();
			}

			// Additional initialization
			PonerDatosTipo();
			ControlarAutorizaciones();
			cargarAutorizacionOpcion();
			LlenarCombos();

			// Create new record if needed
			if (IniNvo)
			{
				CrearNuevo();
			}

			// Set image directory path
			ImgDirectorio = !string.IsNullOrEmpty(datosEmpresa.Emp_PathImagenes)
				? datosEmpresa.Emp_PathImagenes + ImgDirectorio
				: "";
		}


		private void cargarMallaDatos()
		{
			using (var conn = new SqlConnection(datosEmpresa.strConIniSis))
			{
				conn.Open();
				string ssql = "SELECT * FROM syscod WHERE tiporeferencia = 'adicionalEmpleado' AND Abreviación <> '#'";

				using (var adapter = new SqlDataAdapter(ssql, conn))
				using (var dt = new DataTable("datos"))
				{
					adapter.Fill(dt);

					mallaDatos.Rows.Clear();

					for (int i = 0; i < dt.Rows.Count; i++)
					{
						mallaDatos.Rows.Add();
						mallaDatos.Rows[i].Cells[0].Value = string.Empty;
						mallaDatos.Rows[i].HeaderCell.Value = dt.Rows[i]["Descripcion"].ToString();
					}

					// Ensure minimum row count
					if (mallaDatos.RowCount < 2)
						mallaDatos.RowCount = 2;
				}
			}
		}

		private void cargarMallaConceptos()
		{
			using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
			using (SqlDataAdapter adapter = new SqlDataAdapter(
				"SELECT CON_TIPO, Con_Descripcion FROM defcon WHERE ISNULL(con_conceptoporempleado, 'T') = 'E'", conn))
			{
				DataTable dt = new DataTable("conceptos");

				try
				{
					conn.Open();
					adapter.Fill(dt);

					mallaConceptos.Rows.Clear();

					for (int i = 0; i < dt.Rows.Count; i++)
					{
						mallaConceptos.Rows.Add();
						mallaConceptos.Rows[i].HeaderCell.Value = dt.Rows[i]["Con_descripcion"].ToString();
					}

					// Ensure minimum of 2 rows
					if (mallaConceptos.RowCount < 2)
						mallaConceptos.RowCount = 2;
				}
				catch (SqlException ex)
				{
					MessageBox.Show($"Database error loading concepts: {ex.Message}",
								  "Error",
								  MessageBoxButtons.OK,
								  MessageBoxIcon.Error);
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Error loading concepts: {ex.Message}",
								  "Error",
								  MessageBoxButtons.OK,
								  MessageBoxIcon.Error);
				}
			}
		}

		private void cargarNombreGrupos()
		{
			const string query = @"SELECT Abreviación, Descripcion 
                          FROM syscod 
                          WHERE tiporeferencia = 'nomGrupoRol' 
                          AND Abreviación <> '#'";

			using (var conn = new SqlConnection(datosEmpresa.strConIniSis))
			using (var adapter = new SqlDataAdapter(query, conn))
			{
				try
				{
					var dt = new DataTable("datos");
					conn.Open();
					adapter.Fill(dt);

					foreach (DataRow row in dt.Rows)
					{
						string abreviatura = row["Abreviación"].ToString();
						string descripcion = row["Descripcion"].ToString();

						switch (abreviatura)
						{
							case "Grupo-1":
								Label68.Text = descripcion;
								break;
							case "Grupo-2":
								Label69.Text = descripcion;
								break;
							case "Grupo-3":
								Label70.Text = descripcion;
								break;
							case "Grupo-4":
								Label71.Text = descripcion;
								break;
							case "Grupo-5":
								Label72.Text = descripcion;
								break;
							case "Grupo-6":
								Label73.Text = descripcion;
								break;
						}
					}
				}
				catch (SqlException ex)
				{
					MessageBox.Show($"Error loading group names: {ex.Message}",
								  "Database Error",
								  MessageBoxButtons.OK,
								  MessageBoxIcon.Error);
				}
			}
		}

		private void PonerDatosTipo()
		{
			// Static variable equivalent in C#
			double sum = 0;
			sum += 1;

			// Set enabled states based on Natural checkbox
			//Empleado.Enabled = Natural.Checked;
			//Banco.Enabled = Juridica.Checked;
			//Banco.Checked = Juridica.Checked;

			// Handle tab visibility based on checkboxes
			tabDatosPer.Parent = Natural.Checked ? DatosDirectorio : null;
			tabFamiliares.Parent = Natural.Checked ? DatosDirectorio : null;
			tabEmpleado.Parent = Empleado.Checked ? DatosDirectorio : null;
			tabCliente.Parent = Cliente.Checked ? DatosDirectorio : null;
			tabProveedor.Parent = Proveedor.Checked ? DatosDirectorio : null;
			//tabDatosPer.Parent = Natural.Checked ? DatosDirectorio : null;


			ControlarAutorizaciones();
		}

		private void ControlarAutorizaciones()
		{
			// Skip authorization check for admin user
			if (datosEmpresa.usr.Equals("ADMINISTRADOR", StringComparison.OrdinalIgnoreCase))
				return;

			// First verify the connection string exists
			if (string.IsNullOrEmpty(datosEmpresa.strConIniSis))
			{
				MessageBox.Show("Database connection string is not configured");
				return;
			}

			// Then create the instance
			var autorizaciones = new mntUsrs.autorizaUserDirectorio(
				datosEmpresa.usr,
				datosEmpresa.strConIniSis, // Make sure this is properly initialized
				datosEmpresa.codEmpresa.ToString());
			// Return if no identification authorization exists
			if (!autorizaciones.autUsrIdentificacion.existe)
				return;

			// Control tab visibility based on authorizations
			tabCliente.Parent = autorizaciones.autUsrCliente.visible ? DatosDirectorio : null;
			tabAlias.Parent = autorizaciones.autUsrAlias.visible ? DatosDirectorio : null;
			tabContactos.Parent = autorizaciones.autUsrContactos.visible ? DatosDirectorio : null;
			tabDatosPer.Parent = autorizaciones.autUsrDatoPersonal.visible ? DatosDirectorio : null;
			tabEmpleado.Parent = autorizaciones.autUsrEmpleado.visible ? DatosDirectorio : null;
			tabFamiliares.Parent = autorizaciones.autUsrFamiliares.visible ? DatosDirectorio : null;
			tabProveedor.Parent = autorizaciones.autUsrProveedor.visible ? DatosDirectorio : null;
		}

		private void cargarAutorizacionOpcion()
		{
			var opcUser = new mntUsrs.autorizaUserMenu(
				claveOpcion,
				datosEmpresa.usr,
				datosEmpresa.strConIniSis,
				datosEmpresa.codEmpresa.ToString(),
				datosEmpresa.sistema);

			autorizaOpcion = opcUser.autUsrMenuPrincipal;

			// Return early if no authorization needed
			if (autorizaOpcion.crearAbierto || !autorizaOpcion.existe)
				return;

			// Set control states based on authorization
			btnNuevo.Enabled = autorizaOpcion.crearAbierto;
			btnAbrir.Enabled = autorizaOpcion.visible;
			btnGuardar.Visible = autorizaOpcion.crearAbierto || autorizaOpcion.modificar;
			btnEliminar.Visible = autorizaOpcion.eliminar || autorizaOpcion.crearAbierto;
		}

		private void LlenarCombos()
		{
			saltar = true;

			// llenar combos identificacion
			dc.DaxCombosReferencia("Paises", datosEmpresa.strConxAdcom, ref cmbPaisDomicilio, "S");
			cmbPaisDomicilio.SelectedItem = "593";
			dc.DaxCombosReferencia("Provincias", datosEmpresa.strConxAdcom, ref cmbProvinciaDomicilio, "S");
			dc.DaxCombosReferencia("Ciudades", datosEmpresa.strConxAdcom, ref cmbCiudadDomicilio, "S");
			dc.DaxCombosReferencia("Region", datosEmpresa.strConxAdcom, ref cmbRegionDomicilio, "S");
			dc.DaxCombosReferencia("Cantones", datosEmpresa.strConxAdcom, ref cmbCantonDomicilio, "S");
			dc.DaxCombosReferencia("Parroquias", datosEmpresa.strConxAdcom, ref cmbParroquiaDomicilio, "S");

			//llenar combos DatosPersonales
			dc.DaxCombosReferencia("Paises", datosEmpresa.strConxAdcom, ref cmbPaisNace, "S");
			cmbPaisNace.SelectedItem = "593";
			dc.DaxCombosReferencia("Provincias", datosEmpresa.strConxAdcom, ref cmbProvinciaNace, "S");
			dc.DaxCombosReferencia("Ciudades", datosEmpresa.strConxAdcom, ref cmbCiudadNace, "S");
			dc.DaxCombosReferencia("Region", datosEmpresa.strConxAdcom, ref cmbRegionNace, "S");

			dc.DaxCombosReferencia("Nacionalidad", datosEmpresa.strConxAdcom, ref cmbNacionalidadPersonal, "S");
			dc.DaxCombosReferencia("Profesion", datosEmpresa.strConxAdcom, ref cmbProfesion, "S");
			dc.DaxCombosReferencia("Especialidad", datosEmpresa.strConxAdcom, ref cmbEspecialidad, "S");
			dc.DaxCombosReferencia("Especialidad", datosEmpresa.strConxAdcom, ref cmbEspecialidad2, "S");


			// Fill role-related combos
			dc.DaxCombosSuc(datosEmpresa.Emp_codigo.ToString(), false, datosEmpresa.strConIniSis, ref cmbSucursalRol, false);
			dc.DaxCombosReferencia("Departamento", datosEmpresa.strConxAdcom, ref cmbDepartamentoRol, "S");
			dc.DaxCombosReferencia("Seccion", datosEmpresa.strConxAdcom, ref cmbSeccionRol, "S");
			dc.DaxCombosReferencia("Centro Costo", datosEmpresa.strConxAdcom, ref cmbCentroCostoRol, "S");
			dc.DaxCombosReferencia("Módulo", datosEmpresa.strConxAdcom, ref cmbModuloRol, "S");
			dc.DaxCombosReferencia("Cargos", datosEmpresa.strConxAdcom, ref cmbCargoRol, "S");





		}

		
		//private void SaliendoCodigo()
		//{
		//	if (!string.IsNullOrEmpty( TxtCedulaRuc.Text))
		//	{
		//		CargarRegistros();
		//	}

		//}

		//private void CargarRegistros()
		//{
		//	try
		//	{
		//		propio = true;
		//		QUECODIGO =TxtCedulaRuc.Text.Trim();

		//		if (!leerIdentificacion())
		//		{
		//			EsNuevo = 1;
								

		//			if (TipoIdent.SelectedIndex == -1)
		//			{
		//				MessageBox.Show("Por favor seleccione un tipo de documento primero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		//				TipoIdent.Focus();
		//				return;
		//			}

		//			if (string.IsNullOrWhiteSpace(TxtCedulaRuc.Text))
		//			{
		//				MessageBox.Show("Por favor ingrese el número de documento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		//				TxtCedulaRuc.Focus();
		//				return;
		//			}

		//			tipoDocumento = TipoIdent.SelectedItem.ToString();
		//			string numeroDocumento = TxtCedulaRuc.Text.Trim();
					
		//	// Llamar a la función correspondiente según el tipo de documento
		//			switch (tipoDocumento)
		//			{
		//				case "Registro U Contribuyente":						
		//					ConsultarRUC(numeroDocumento);
		//					break;
		//				case "Cédula Identidad":
		//					ConsultarCedula(numeroDocumento);
		//					break;
		//				case "Pasaporte":
		//					ConsultarPasaporte();
							
		//					//MessageBox.Show("Consulta de pasaporte realizada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
		//					break;
		//				case "Consumidor Final":
		//					ConsultarFinal();
		//					break;
		//				default:
		//					MessageBox.Show("Tipo de documento no válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		//					break;
		//			}


		//		}
		//		else
		//		{
		//			if (tipoper == "N")
		//			{
		//				leerPersonal();
		//			}

		//			leerCliente();
		//			leerProveedor();
		//			LeerEmpleado.leerEmpleado(this, CodigoDirectorio, TipCodSyscod, LosCambios, codigoDirectorio);
		//			leerContactos();
		//			leerAlias();
		//			leerFamiliares();
		//			EsNuevo = 2;
		//		}

		//		if (Emp.rol)
		//		{
		//			CargarAdicionales(CodigoDirectorio);
		//			CargarConceptos(CodigoDirectorio);
		//		}

		//		//PonerDatosTipo();
		//		//CargaFoto();
		//		Cambio = false;

		//		// ChequearAutorizacion(Emp.); // Commented as in original
		//		PonerBotonesFormulario();
		//		btnCargarCapacitacion.Visible = Emp.rol;
		//	}
		//	catch (Exception ee)
		//	{
		//		MessageBox.Show($"excepción cargaDir: {ee.Message}",
		//					  "Error",
		//					  MessageBoxButtons.OK,
		//					  MessageBoxIcon.Error);
		//	}
		//	finally
		//	{
		//		CambioAdicionales = false;
		//	}
		//}

		private void ConsultarFinal()
		{
			TxtCedulaRuc.Text = "9999999999999";
			TxtNombres.Text = "CONSUMIDOR FINAL";
			Codigo.Text = "9";

		}

		private void ConsultarPasaporte()
		{
			Natural.Checked = true;
			Juridica.Checked = false;
			Cliente.Enabled = true;
			Proveedor.Enabled = true;
			Empleado.Enabled = true;
			EsVendedor.Enabled = true;
			Banco.Enabled = false;
			TxtApellidos.Visible = true;
			label96.Visible = true;
			//if (txtHistoriaclinica.Text.Length == 0)
			//{
			//	txtHistoriaclinica.Text ="P"+ Codigo.Text.Substring(1, 10);
			//	txtHistoriaclinica.Visible = true; 
			//	Label79.Visible = true;
			//}


			if (string.IsNullOrEmpty(txtHistoriaclinica.Text))
			{
				if (!string.IsNullOrEmpty(TxtCedulaRuc.Text) && TxtCedulaRuc.Text.Length >= 10)
				{
					Codigo.Text = "P" + TxtCedulaRuc.Text.Substring(0, 10);
					txtHistoriaclinica.Text = Codigo.Text.Substring(1, 10);					
				}
				else
				{
					// Opción 1: Tomar los caracteres disponibles (sin error)
					Codigo.Text = "P" + TxtCedulaRuc.Text;
					txtHistoriaclinica.Text = TxtCedulaRuc.Text;
					// Opción 2: Mostrar advertencia
					//MessageBox.Show("El código no tiene la longitud requerida");
				}

				txtHistoriaclinica.Visible = true;
				Label79.Visible = true;
			}

		}


		//// Método para validar si el documento es cédula
		//private bool EsCedula(string documento)
		//{
		//	// Aquí agregas la lógica para identificar si es cédula (puede ser una expresión regular)
		//	return documento.Length == 10; // Asumiendo que la cédula tiene 10 caracteres
		//}

		//// Método para validar si el documento es RUC
		//private bool EsRUC(string documento)
		//{
		//	// Lógica para validar RUC (puede ser diferente según la validación de tu país)
		//	return documento.Length == 13; // Asumiendo que el RUC tiene 13 caracteres
		//}

		// Método para consultar cédula (puedes llamar a un API o servicio externo)
		//private async void ConsultarCedula(string cedula)
		//{
		//	try
		//	{
				
		//		string token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IldMQURJTUlSIiwicm9sZSI6IlVzZXIiLCJlbWFpbCI6InJ2LndsYWRpODNAZ21haWwuY29tIiwiSWRlbnRpZmljYWNpb24iOiIwOTY2MTY4MjIxIiwiQ2xpZW50ZUlEIjoiMTAiLCJuYmYiOjE3MDAwNTc5MDMsImV4cCI6MTc2MzIxNjMwMywiaWF0IjoxNzAwMDU3OTAzLCJpc3MiOiJDYXRhc3Ryb3NFbkxpbmVhU2VydmVyIiwiYXVkIjoiQ2F0YXN0cm9zRW5MaW5lYUNsaWVudCJ9.onkIkMsf18IgRV91stP8W75wWjXovcGu_FPzJ7H9hDm6q25qgqxJulNvRvcbO4vWEWy6o6WWPw7mWYw8se-nbA"; ; // tu token completo aquí

		//		var consultador = new CedConsLib.Consultador(token);
		//		var datos = consultador.ConsultarAsync(QUECODIGO);

		//		if (datos == null)
		//		{
		//			MessageBox.Show("Cédula no encontrada.");
		//			return;
		//		}
				
		//		Natural.Checked = true;
		//		Juridica.Checked = false;
		//		Cliente.Enabled = true;
		//		Proveedor.Enabled = true;
		//		Empleado.Enabled = true;
		//		EsVendedor.Enabled = true;
		//		Banco.Enabled = false;

		//		TxtApellidos.Visible = true;
		//		label96.Visible = true;
		//		TxtCedulaRuc.Text = datos.Cedula;
		//		//TxtNombres.Text = datos.Nombre;


		//		// Populate form fieldsç
		//		string nombreCompleto = datos.Nombre.Trim(); // "CABEZAS LLIGUIN JOSE ANDRES"
		//		var partes = nombreCompleto.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

		//		string apellidos = "";
		//		string nombres = "";

		//		if (partes.Length >= 4)
		//		{
		//			apellidos = string.Join(" ", partes.Take(2));   // Primeras dos palabras → Apellidos
		//			nombres = string.Join(" ", partes.Skip(2));     // Resto → Nombres
		//		}
		//		else if (partes.Length == 3)
		//		{
		//			apellidos = partes[0]; // Primer apellido
		//			nombres = string.Join(" ", partes.Skip(1)); // Lo demás como nombres
		//		}
		//		else
		//		{
		//			apellidos = partes[0];
		//			nombres = partes.Length > 1 ? partes[1] : "";
		//		}

		//		TxtApellidos.Text = apellidos;
		//		TxtNombres.Text = nombres;
		//		impresion.Text = nombreCompleto;


		//		//txtCondicion.Text = datos.Condicion;
		//		//fechanaci.Value = datos.FechaNacimiento;


		//		//string fechaStr = datos.FechaNacimiento?.Trim(); // evita null

		//		//if (!string.IsNullOrEmpty(fechaStr) &&
		//		//	DateTime.TryParseExact(fechaStr, "dd/MM/yyyy",
		//		//		System.Globalization.CultureInfo.InvariantCulture,
		//		//		System.Globalization.DateTimeStyles.None,
		//		//		out DateTime fechaNac))
		//		//{
		//		//	fechanaci.Value = fechaNac;
		//		//}
		//		//else
		//		//{
		//		//	// Si el string es nulo o inválido, asigna una fecha por defecto
		//		//	fechanaci.Value = new DateTime(1900, 1, 1);
		//		//}

		//		string fechaStr = datos.FechaNacimiento?.Trim();

		//		if (!string.IsNullOrEmpty(fechaStr) &&
		//			DateTime.TryParse(fechaStr, new System.Globalization.CultureInfo("es-EC"),
		//							  System.Globalization.DateTimeStyles.None, out DateTime fechaNac))
		//		{
		//			fechanaci.Value = fechaNac;
		//		}
		//		else
		//		{
		//			// Valor por defecto si la fecha es nula o inválida
		//			fechanaci.Value = new DateTime(1900, 1, 1);
		//		}



		//		// Separar la dirección por el caracter '/'
		//		string lugarnacimientoC = datos.LugarNacimiento;

		//		//if (lugarDomicilio.Length > 2 && !string.IsNullOrWhiteSpace(lugarDomicilio[2]))
		//		string[] partesNacimiento = lugarnacimientoC.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

		//		string provinciaNacimiento = "";
		//		string ciudadNacimiento = "";
		//		string lugarNacimientoF = "";

		//		if (partesNacimiento.Length == 1)
		//		{
		//			provinciaNacimiento = partesNacimiento[0].Trim(); // Ej: "VENEZUELA"
		//		}
		//		else if (partesNacimiento.Length == 2)
		//		{
		//			provinciaNacimiento = partesNacimiento[0].Trim(); // Ej: "PICHINCHA/QUITO" → Provincia
		//			ciudadNacimiento = partesNacimiento[1].Trim();    // Ciudad
		//		}
		//		else if (partesNacimiento.Length >= 3)
		//		{
		//			provinciaNacimiento = partesNacimiento[0].Trim(); // Ej: "PICHINCHA/QUITO/COTOCOLLAO"
		//			ciudadNacimiento = partesNacimiento[1].Trim();
		//			lugarNacimientoF = partesNacimiento[2].Trim();
		//		}

		//		cmbProvinciaNace.Text = provinciaNacimiento;
		//		cmbCiudadNace.Text = ciudadNacimiento;
		//		Lugarnaci.Text = lugarNacimientoF;

		//		// Forzar actualización
		//		cmbProvinciaNace.Refresh();
		//		cmbCiudadNace.Refresh();
		//		Lugarnaci.Refresh();

		//		if (datos.Nacionalidad.ToUpper() == "ECUATORIANA")
		//		{
		//			cmbNacionalidadPersonal.Text = "Ecuatoriano";
		//		}
				

		//		cmbEstadoCivil.Text = datos.EstadoCivil;
				

		//		// Separar la dirección por el caracter '/'
		//		string lugarDomicilio = datos.Domicilio;
		//		string[] partesDomicilio = lugarDomicilio.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
		//		//string provinciaDomicilio = partesDomicilio.Length > 0 ? partesDireccion[0].Trim() : "";
		//		//string ciudadDomicilio = partesDomicilio.Length > 1 ? partesDireccion[1].Trim() : "";
		//		//string LugarDomicilio = partesDomicilio[2].Trim();
				

		//		string provinciaDomicilio = "";
		//		string ciudadDomicilio = "";
		//		string LugarDomicilio = "";

		//		if (partesDomicilio.Length == 1)
		//		{
		//			provinciaDomicilio = partesDomicilio[0].Trim(); // Ej: "VENEZUELA"
		//		}
		//		else if (partesDomicilio.Length == 2)
		//		{
		//			provinciaDomicilio = partesDomicilio[0].Trim(); // Ej: "PICHINCHA/QUITO" → Provincia
		//			ciudadDomicilio = partesDomicilio[1].Trim();    // Ciudad
		//		}
		//		else if (partesDomicilio.Length >= 3)
		//		{
		//			provinciaDomicilio = partesDomicilio[0].Trim(); // Ej: "PICHINCHA/QUITO/COTOCOLLAO"
		//			ciudadDomicilio = partesDomicilio[1].Trim();
		//			LugarDomicilio = partesDomicilio[2].Trim();
		//		}

		//		cmbProvinciaDomicilio.Text = provinciaDomicilio;
		//		cmbCiudadDomicilio.Text = ciudadDomicilio;
		//		txtnomDireccion.Text = LugarDomicilio;

				
		//		//TipoIdent.SelectedItem = "Cédula Identidad";
		//		//resultadoConsulta = "OK-CONSULTADO";
		//		Codigo.Text= "C" + datos.Cedula.Substring(0, 10);

		//		if (datos.Sexo == "M")
		//		{
		//			hombre.Checked=true;
		//		}
		//		else
		//		{
		//			mujer.Checked = true;
		//		}

		//		if (txtHistoriaclinica.Text.Length == 0 && (TipoIdent.Text == "Cédula Identidad"))

		//			txtHistoriaclinica.Text = Codigo.Text.Substring(1, 10); txtHistoriaclinica.Visible = true; Label79.Visible = true; txtHistoriaclinica.Enabled=true;
				
				
				


		//	}
		//	catch (Exception ex)
		//	{
		//		MessageBox.Show("Error: " + ex.Message);
		//	}

		//}

		// Método para consultar RUC (similar al de cédula)
	//	private async void ConsultarRUC(string ruc)
	//	{
	//		try
	//		{
	//			// Consultar el RUC
	//			var datos = _rucService.ConsultarRuc(ruc);
	//			var datos = "";

	//			if (datos.RazonSocial != "Error" && datos.RazonSocial != "RUC inválido" && !string.IsNullOrEmpty(datos.RazonSocial))
	//			{
	//				// Obtener el establecimiento matriz o el primero
	//				var establecimientoMatriz = datos.Establecimientos?.FirstOrDefault(); // Aquí se puede ajustar si sabes la propiedad para matriz

	//				string direccionCompleta = establecimientoMatriz != null ? establecimientoMatriz.direccionCompleta ?? "-" : "-";

	//				// Asignar valores en la fila



	//				TxtCedulaRuc.Text = datos.NumeroRuc;


	//				// Separar la dirección por el caracter '/'
	//				string[] partesDireccion = direccionCompleta.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);



	//				string provincia = partesDireccion.Length > 0 ? partesDireccion[0].Trim() : "";

	//				string ciudad = partesDireccion.Length > 1 ? partesDireccion[1].Trim() : "";
	//				//string canton = partesDireccion.Length > 1 ? partesDireccion[1].Trim() : "";
	//				string direccion = "";
	//				if (partesDireccion.Length > 4 && !string.IsNullOrWhiteSpace(partesDireccion[4]))
	//				{
	//					direccion = partesDireccion[3].Trim() + partesDireccion[4].Trim();
	//				}
	//				else if (partesDireccion.Length > 3)
	//				{
	//					direccion = partesDireccion[3].Trim();
	//				}


	//				txtnomDireccion.Text = direccion;

	//				cmbProvinciaDomicilio.Text = provincia;
	//				//cmbCantonDomicilio.Text = canton;
	//				cmbCiudadDomicilio.Text = ciudad;


	//				//txtnomDireccion.Text = direccionCompleta;
	//				if (datos.TipoContribuyente?.ToUpper() == "PERSONA NATURAL")
	//				{
	//					Natural.Checked = true;
	//					Juridica.Checked = false;
	//					Cliente.Enabled = true;
	//					Proveedor.Enabled = true;
	//					Empleado.Enabled = true;
	//					EsVendedor.Enabled = true;
	//					Banco.Enabled = false;
	//					TxtApellidos.Visible = true;
	//					label96.Visible = true;
	//					//tabDatosPer.Parent = Natural.Checked ? DatosDirectorio : null;

	//					string nombreCompleto = datos.RazonSocial.Trim(); // "CABEZAS LLIGUIN JOSE ANDRES"
	//					var partes = nombreCompleto.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

	//					string apellidos = "";
	//					string nombres = "";

	//					if (partes.Length >= 4)
	//					{
	//						apellidos = string.Join(" ", partes.Take(2));   // Primeras dos palabras → Apellidos
	//						nombres = string.Join(" ", partes.Skip(2));     // Resto → Nombres
	//					}
	//					else if (partes.Length == 3)
	//					{
	//						apellidos = partes[0]; // Primer apellido
	//						nombres = string.Join(" ", partes.Skip(1)); // Lo demás como nombres
	//					}
	//					else
	//					{
	//						apellidos = partes[0];
	//						nombres = partes.Length > 1 ? partes[1] : "";
	//					}

	//					TxtApellidos.Text = apellidos;
	//					TxtNombres.Text = nombres;
	//					impresion.Text = nombreCompleto;
	//				}

	//				if (datos.TipoContribuyente?.ToUpper() != "PERSONA NATURAL")
	//				{
	//					Juridica.Checked = true;
	//					Natural.Checked = false;
	//					Cliente.Enabled = true;
	//					Proveedor.Enabled = true;
	//					Empleado.Enabled = false;
	//					EsVendedor.Enabled = true;
	//					Banco.Enabled = true;
	//					TxtNombres.Text = datos.RazonSocial;
	//					TxtApellidos.Visible = false;
	//					label96.Visible = false;
	//					impresion.Text = datos.RazonSocial;
	//				}



	//				txttiporegimen.Text = datos.Regimen;
	//				txtContabilidad.Text = datos.ObligadoLlevarContabilidad;
	//				txtagenteR.Text = datos.AgenteRetencion;
	//				txtContribuyenteEspecial.Text = datos.ContribuyenteEspecial;
	//				//TipoIdent.SelectedItem = "Registro U Contribuyente";
	//				Codigo.Text = "R" + datos.NumeroRuc.Substring(0, 10);

	//				//txtContribuyenteEspecial.Text = datos.ContribuyenteEspecial.ToUpper() == "SI" ? "SI" : "";
	//				//resultadoConsulta = "OK-CONSULTADO";
	//			}

	//		}
	//		catch (Exception ex)
	//		{
	//			MessageBox.Show($"Error al validar el RUC {ruc}: {ex.Message}");
	//		}


	//		//}
	//		private bool leerIdentificacion()
	//	{
	//		Identificacion datosIdentificacion = new Identificacion(datosEmpresa.strConxAdcom);
	//		datosIdentificacion = Identificacion.Buscar($"CedulaIdentidadRuc = '{QUECODIGO}'");

	//		if (datosIdentificacion == null)
	//			return false;

			


	//		Codigo.Text = datosIdentificacion.Codigo;
	//		tipoper = datosIdentificacion.TipoPersona;

	//		// Set person type checkboxes
	//		Juridica.Checked = (tipoper == "J");
	//		Natural.Checked = (tipoper == "N");

	//		// Set entity type checkboxes
	//		Cliente.Checked = datosIdentificacion.EsCliente;
	//		Proveedor.Checked = datosIdentificacion.EsProveedor;
	//		Empleado.Checked = datosIdentificacion.EsEmpleado;
	//		Banco.Checked = datosIdentificacion.EsBanco;
	//		EsVendedor.Checked = datosIdentificacion.EsVendedor;
	//		//Asociacion.Checked = datosIdentificacion.EsAsociado;

	//		// Set directa checkbox
	//		//Directa.Checked = (datosIdentificacion.EsDirecta == "SI");

	//		// Set identification fields
	//		TipoIdent.SelectedIndex = Convert.ToInt32(Val(ArreglaId(Valores.CorrijeNulo(datosIdentificacion.TipoIdentificacion))));
	//		TxtCedulaRuc.Text = datosIdentificacion.CedulaIdentidadRuc;
	//		TxtNombres.Text = datosIdentificacion.Nombres;
	//		TxtApellidos.Text = datosIdentificacion.Apellidos;
	//		impresion.Text = datosIdentificacion.NombreImpresion;

	//		// Set address fields
	//		TxtNroDomicilio.Text = datosIdentificacion.NumeroDomicilio;
	//		cmbPaisDomicilio.SelectedValue = datosIdentificacion.País;
	//		cmbProvinciaDomicilio.SelectedValue = datosIdentificacion.Provincia;
	//		cmbParroquiaDomicilio.SelectedValue = datosIdentificacion.Casilla;
	//		cmbCantonDomicilio.SelectedValue = datosIdentificacion.Sector;
	//		cmbCiudadDomicilio.SelectedValue = datosIdentificacion.Ciudad;
	//		cmbRegionDomicilio.Text = datosIdentificacion.regionDomicilio;
	//		txtnomDireccion.Text = datosIdentificacion.Domicilio;

	//		// Set contact fields
	//		txtTelefono1.Text = datosIdentificacion.Telefono1;
	//		txtTelefono2.Text = datosIdentificacion.Telefono2;
	//		txtTelefono3.Text = datosIdentificacion.Telefono3;
	//		TxtData6.Text = datosIdentificacion.NúmeroFax;
	//		TxtData8.Text = datosIdentificacion.CorreoElectrónico;
	//		//TxtData9.Text = datosIdentificacion.Paginaweb;
			
	//		// Set additional fields
	//		//txtGrupo1.Text = datosIdentificacion.Grupo1;
	//		//txtGrupo2.Text = datosIdentificacion.Grupo2;
	//		//txtGrupo3.Text = datosIdentificacion.Grupo3;
	//		txtHistoriaclinica.Text = datosIdentificacion.HistoriaClinica;
	//		CodigoFoto = datosIdentificacion.Logotipo;

	//		// Set ownership flag
	//		propio = (datosEmpresa.usr == datosIdentificacion.CodGrabo) || string.IsNullOrEmpty(datosIdentificacion.CodGrabo);

	//		// Set tax-related fields
	//		//ExoneradoIva.Checked = datosIdentificacion.ExoneradoIva;
	//		//chkRise.Checked = datosIdentificacion.esRise;
	//		//chkObligaContabilidad.Checked = datosIdentificacion.ObligLlevarConta;
	//		//chkRegimenMicroempresas.Checked = datosIdentificacion.RegimenMicroempresas;

	//		// Set additional address fields
	//		txtSector.Text = datosIdentificacion.SectorDomicilio;
	//		TxtResolucionAR.Text = datosIdentificacion.NroAcdoAgntRetencion;
	//		txttiporegimen.Text = datosIdentificacion.TipoRegimen;

	//		txtagenteR.Text = datosIdentificacion.RegimenMicroempresas ? "SI" : "NO";
	//		txtContribuyenteEspecial.Text = datosIdentificacion.CtrbuyteEspecial ? "SI" : "NO";
	//		txtNroContribuyente.Text = datosIdentificacion.NroCtrbuyteEspecial;
	//		CodigoDirectorio = datosIdentificacion.Codigo;
	//		if (Natural.Checked)
	//		{
	//			Cliente.Enabled = true;
	//			Proveedor.Enabled = true;
	//			Empleado.Enabled = true;
	//			EsVendedor.Enabled = true;
	//			Banco.Enabled = false;
	//		}
	//		if (Juridica.Checked)
	//		{
	//			Cliente.Enabled = true;
	//			Proveedor.Enabled = true;
	//			Empleado.Enabled = false;
	//			EsVendedor.Enabled = false;
	//			Banco.Enabled = true;
	//		}

	//		return true;
	//	}

	//	// First create a Val equivalent function in C#
	//	private double Val(string inputStr)
	//	{
	//		if (string.IsNullOrWhiteSpace(inputStr))
	//			return 0;

	//		// Find the first numeric part
	//		var sb = new StringBuilder();
	//		foreach (char c in inputStr)
	//		{
	//			if (char.IsDigit(c) || c == '.' || c == ',')
	//				sb.Append(c);
	//			else if (sb.Length > 0)
	//				break; // Stop at first non-numeric after numbers
	//		}

	//		if (sb.Length == 0)
	//			return 0;

	//		// Handle culture-specific decimal separators
	//		string numStr = sb.ToString()
	//						.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
	//						.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

	//		double.TryParse(numStr, out double result);
	//		return result;
	//	}

		
	//	private string ArreglaId(string ident)
	//	{
	//		if (string.IsNullOrEmpty(ident) || Convert.IsDBNull(ident))
	//			return "1";

	//		switch (ident)
	//		{
	//			//case "O":
	//			//	return "0";
	//			case "R":
	//				return "0";
	//			case "C":
	//				return "1";
	//			case "P":
	//				return "2";
	//			case "F":
	//				return "3";
	//			default:
	//				return ident;
	//		}
	//	}

	//	private bool leerPersonal()
	//	{
	//		dbPersonal datosPersonales = new dbPersonal(datosEmpresa.strConxAdcom);
	//		datosPersonales = dbPersonal.Buscar($"codigoper = '{CodigoDirectorio}'");
			

	//		if (datosPersonales == null)
	//			return false;

	//		// Personal data
	//		fechanaci.Text = datosPersonales.FechaNacimiento.ToShortDateString();
	//		Lugarnaci.Text = datosPersonales.LugarNacimiento;
	//		Sexo = datosPersonales.Sexo;
	//		cmbEstadoCivil.Text = datosPersonales.EstadoCivil;
	//		cmbNacionalidadPersonal.SelectedValue = datosPersonales.Nacionalidad;
	//		hobbys.Text = datosPersonales.Hobbys;

	//		// Card data
	//		txtCodTar.Text = datosPersonales.codigotarjrta;
	//		txtNumTar.Text = datosPersonales.numerotarjrta;

	//		// Professional data
	//		cmbProfesion.SelectedValue = datosPersonales.Profesión;
	//		cmbEspecialidad.SelectedValue = datosPersonales.Especialidad;
	//		cmbEspecialidad2.SelectedValue = datosPersonales.Especialidad2;
	//		txtReferirseComo.Text = datosPersonales.Referirsecomo;
	//		cmbTipoSangre.Text = datosPersonales.TipoSangre;
	//		txtLugTra.Text = datosPersonales.DirecciónTrabajo;

	//		// Birth location data
	//		cmbPaisNace.Text = datosPersonales.paisNacimto;
	//		cmbProvinciaNace.Text = datosPersonales.provNacimto;
	//		cmbCiudadNace.Text = datosPersonales.ciudadNacimto;
	//		cmbRegionNace.Text = datosPersonales.regionNacimto;

	//		// Gender selection
	//		if (Sexo == "M")
	//		{
	//			mujer.Checked = true;
	//		}
	//		else
	//		{
	//			hombre.Checked = true;
				
	//		}

	//		// Disability information
	//		txtDiscapacidad.Text = datosPersonales.Discapacidad;
	//		txtPorcDiscapacidad.Text = datosPersonales.PorcentajeDiscapacidad.ToString("#0.00");

	//		return true;
	//	}

	//	private bool leerCliente()
	//	{
	//		dbCliente datosCliente = new dbCliente(datosEmpresa.strConxAdcom);
	//		datosCliente = dbCliente.Buscar($"codigocli = '{CodigoDirectorio}'");
	//		if (datosCliente == null)
	//			return false;

	//		var buscod = new Syscod.ManSysnetClass();

	//		// Check ownership
	//		if (datosCliente.VendedorInterno != datosEmpresa.usr && datosCliente.CobradorInterno != datosEmpresa.usr)
	//			propio = false;

	//		// Populate client data
	//		txtTipoCliente.Text = buscod.QueNombre(datosCliente.TipoCli, TipCodSyscod[3]);
	//		txtZonaVentas.Text = buscod.QueNombre(datosCliente.ZonaVentas, TipCodSyscod[4]);

	//		txtVendedor.Text = buscod.QueNombre(datosCliente.VendedorInterno, TipCodSyscod[3]);
	//		codigoDirectorio[0] = datosCliente.VendedorInterno;

	//		txtOperador.Text = buscod.QueNombre(datosCliente.Operador, TipCodSyscod[3]);
	//		codigoDirectorio[5] = datosCliente.Operador;

	//		txtTransportadora.Text = buscod.QueNombre(datosCliente.Transportadora, TipCodSyscod[3]);
	//		codigoDirectorio[6] = datosCliente.Transportadora;

	//		txtZonaCobranzas.Text = buscod.QueNombre(datosCliente.ZonaCobranza, TipCodSyscod[5]);

	//		txtCobrador.Text = buscod.QueNombre(datosCliente.CobradorInterno, TipCodSyscod[3]);
	//		codigoDirectorio[1] = datosCliente.CobradorInterno;

	//		txtPrecioVenta.Text = buscod.QueNombre(datosCliente.PrecioVenta, TipCodSyscod[6]);
	//		txtFormaPago.Text = RetornaNombre.RetornaNombrePago(datosCliente.FormaPago, datosEmpresa.strConxAdcom);

	//		// Numeric fields
	//		txtPorcDescuento.Text = datosCliente.PorcDescuento.ToString();
	//		txtLimiteCredito.Text = datosCliente.LimiteCredito.ToString();
	//		txtDescuentoAsociacion.Text = datosCliente.DescuentoAso.ToString();

	//		// Additional fields
	//		observacli.Text = datosCliente.Observaciones;
	//		txtContacto.Text = datosCliente.Contacto;
	//		entregarmer.Text = datosCliente.Entregarmercaderia;
	//		Cuenta0.Text = datosCliente.CtbCobrar;
	//		Cuenta4.Text = datosCliente.CtbCobrar2;
	//		entregarmer.Text = datosCliente.PuertoEmbarque;
	//		txtPaisEntrega.Text = datosCliente.PaisEmbarque;

	//		return true;
	//	}

	//	private bool leerProveedor()
	//	{
	//		try
	//		{
	//			using (SqlConnection ConxAdcom = new SqlConnection(datosEmpresa.strConxAdcom))
	//			using (SqlCommand comm = new SqlCommand("SELECT * FROM proveedor WHERE codigoproveedor = @QUECODIGO", ConxAdcom))
	//			{
	//				comm.Parameters.AddWithValue("@QUECODIGO", CodigoDirectorio);
	//				ConxAdcom.Open();

	//				using (SqlDataReader rs = comm.ExecuteReader())
	//				{
	//					if (!rs.Read())
	//						return false;

	//					// Handle FormaPago with proper type conversion
	//					if (!rs.IsDBNull(rs.GetOrdinal("FormaPago")))
	//					{
	//						object formaPagoValue = rs["FormaPago"];
	//						int formaPagoInt;

	//						// Handle all possible numeric types from database
	//						switch (formaPagoValue)
	//						{
	//							case int i:
	//								formaPagoInt = i;
	//								break;
	//							case short s:
	//								formaPagoInt = s;
	//								break;
	//							case byte b:
	//								formaPagoInt = b;
	//								break;
	//							case long l:
	//								formaPagoInt = (int)l;
	//								break;
	//							case decimal d:
	//								formaPagoInt = (int)d;
	//								break;
	//							case float f:
	//								formaPagoInt = (int)f;
	//								break;
	//							case double db:
	//								formaPagoInt = (int)db;
	//								break;
	//							default:
	//								if (!int.TryParse(formaPagoValue.ToString(), out formaPagoInt))
	//								{
	//									formaPagoInt = 0; // Default value if parsing fails
	//								}
	//								break;
	//						}

	//						Lcod8.Text = RetornaNombre.RetornaNombrePago(Convert.ToString(formaPagoInt), datosEmpresa.strConxAdcom);
	//					}
	//					else
	//					{
	//						Lcod8.Text = string.Empty;
	//					}

	//					// Other fields

	//					porcedescuentoprv.Text = rs.IsDBNull(rs.GetOrdinal("PorceDescuent")) ? string.Empty :
	//					 rs["PorceDescuent"].ToString().Trim();

	//					limcreditoprv.Text = rs.IsDBNull(rs.GetOrdinal("limcreditoprv")) ? string.Empty :
	//				 rs["limcreditoprv"].ToString().Trim();

	//					producto.Text = rs.IsDBNull(rs.GetOrdinal("Producto1")) ? string.Empty :
	//									rs["Producto1"].ToString().Trim();

	//					servicios.Text = rs.IsDBNull(rs.GetOrdinal("Servicios1")) ? string.Empty :
	//									 rs["Servicios1"].ToString().Trim();

	//					observacionesprv.Text = rs.IsDBNull(rs.GetOrdinal("Observaciones")) ? string.Empty :
	//											rs["Observaciones"].ToString().Trim();

	//					Cuenta1.Text = rs.IsDBNull(rs.GetOrdinal("ctbproveedor")) ? string.Empty :
	//								   rs["ctbproveedor"].ToString().Trim();

	//					Cuenta5.Text = rs.IsDBNull(rs.GetOrdinal("ctbproveedor2")) ? string.Empty :
	//								   rs["ctbproveedor2"].ToString().Trim();

	//					// Campos booleanos (checkboxes)
	//					incluyetransporte.Checked = !rs.IsDBNull(rs.GetOrdinal("IncluyeTranspo")) &&
	//											   SafeConvertToBoolean(rs["IncluyeTranspo"]);

	//					chkEntregaDirecccion.Checked = !rs.IsDBNull(rs.GetOrdinal("EntregaNuestraOficina")) &&
	//												  SafeConvertToBoolean(rs["EntregaNuestraOficina"]);

	//					chkRetirarTransporte.Checked = !rs.IsDBNull(rs.GetOrdinal("EnvioATransporte")) &&
	//												  SafeConvertToBoolean(rs["EnvioATransporte"]);

	//					chkRetirarProveedor.Checked = !rs.IsDBNull(rs.GetOrdinal("RetirarMercaderia")) &&
	//												 SafeConvertToBoolean(rs["RetirarMercaderia"]);

	//					// Opciones de transporte
	//					chkAereo.Checked = !rs.IsDBNull(rs.GetOrdinal("transAereo")) &&
	//									  SafeConvertToBoolean(rs["transAereo"]);

	//					chkMaritimo.Checked = !rs.IsDBNull(rs.GetOrdinal("transMaritimo")) &&
	//										 SafeConvertToBoolean(rs["transMaritimo"]);

	//					chkTerrestre.Checked = !rs.IsDBNull(rs.GetOrdinal("transTerrestre")) &&
	//										  SafeConvertToBoolean(rs["transTerrestre"]);

	//					// Método auxiliar para conversión segura a booleano
						
	//				}
	//			}
	//			return true;
	//		}
	//		catch (Exception ex)
	//		{
	//			MessageBox.Show($"Error loading provider data: {ex.Message}");
	//			return false;
	//		}
	//	}

	//	private bool SafeConvertToBoolean(object value)
	//	{
	//		if (value == null || value == DBNull.Value)
	//			return false;

	//		if (value is bool)
	//			return (bool)value;

	//		if (value is int)
	//			return (int)value != 0;

	//		if (value is string)
	//			return value.ToString().Equals("1", StringComparison.OrdinalIgnoreCase) ||
	//				   value.ToString().Equals("true", StringComparison.OrdinalIgnoreCase);

	//		try
	//		{
	//			return Convert.ToBoolean(value);
	//		}
	//		catch
	//		{
	//			return false;
	//		}
	//	}

	//	private bool leerContactos()
	//	{
	//		try
	//		{
	//			using (var ConxAdcom = new SqlConnection(datosEmpresa.strConxAdcom))
	//			using (var comm = new SqlCommand("SELECT * FROM contactos WHERE codcontacto = @QUECODIGO", ConxAdcom))
	//			{
	//				comm.Parameters.AddWithValue("@QUECODIGO", CodigoDirectorio);
	//				ConxAdcom.Open();

	//				using (var rs = comm.ExecuteReader())
	//				{
	//					int i = 0;
	//					while (rs.Read())
	//					{
	//						MallaCtco.Rows.Add();
	//						MallaCtco.Rows[i].Cells[0].Value = Valores.CorrijeNulo(rs["Principal"]);
	//						MallaCtco.Rows[i].Cells[1].Value = Valores.CorrijeNulo(rs["Nombre"]);
	//						MallaCtco.Rows[i].Cells[2].Value = Valores.CorrijeNulo(rs["Cargo"]);
	//						MallaCtco.Rows[i].Cells[3].Value = Valores.CorrijeNulo(rs["Extensión"]);
	//						MallaCtco.Rows[i].Cells[4].Value = Valores.CorrijeNulo(rs["TelfCelular"]);
	//						MallaCtco.Rows[i].Cells[5].Value = Valores.CorrijeNulo(rs["TeléfonoDirecto"]);

	//						// Handle date field with proper type checking
	//						MallaCtco.Rows[i].Cells[6].Value = rs.IsDBNull(rs.GetOrdinal("FechaNacimiento"))
	//							? string.Empty
	//							: ((DateTime)rs["FechaNacimiento"]).ToShortDateString();

	//						MallaCtco.Rows[i].Cells[7].Value = Valores.CorrijeNulo(rs["Actividades"]);
	//						MallaCtco.Rows[i].Cells[8].Value = Valores.CorrijeNulo(rs["Preferencias"]);
	//						MallaCtco.Rows[i].Cells[9].Value = Valores.CorrijeNulo(rs["Observaciones"]);
	//						i++;
	//					}
	//				}
	//			}
	//			return true;
	//		}
	//		catch (Exception ex)
	//		{
	//			MessageBox.Show($"Error loading contacts: {ex.Message}");
	//			return false;
	//		}
	//	}

	//	private bool leerAlias()
	//	{
	//		try
	//		{
	//			using (var ConxAdcom = new SqlConnection(datosEmpresa.strConxAdcom))
	//			using (var comm = new SqlCommand(
	//				"SELECT * FROM identificacionalias WHERE CodigoEmpresa = @QUECODIGO",
	//				ConxAdcom))
	//			{
	//				comm.Parameters.AddWithValue("@QUECODIGO", CodigoDirectorio);
	//				ConxAdcom.Open();

	//				using (var rs = comm.ExecuteReader())
	//				{
	//					int i = 0;
	//					while (rs.Read())
	//					{
	//						MallaAlias.Rows.Add();
	//						MallaAlias.Rows[i].Cells[0].Value = Valores.CorrijeNulo(rs["NombreAlias"]);
	//						MallaAlias.Rows[i].Cells[1].Value = Valores.CorrijeNulo(rs["DirecciónAlterna"]);
	//						MallaAlias.Rows[i].Cells[2].Value = Valores.CorrijeNulo(rs["Teléfono_1"]);
	//						MallaAlias.Rows[i].Cells[3].Value = Valores.CorrijeNulo(rs["Teléfono_2"]);
	//						MallaAlias.Rows[i].Cells[4].Value = Valores.CorrijeNulo(rs["Id_Sri"]);
	//						MallaAlias.Rows[i].Cells[5].Value = Valores.CorrijeNulo(rs["Observaciones"]);
	//						i++;
	//					}
	//				}
	//			}
	//			return true;
	//		}
	//		catch (Exception ex)
	//		{
	//			MessageBox.Show($"Error loading aliases: {ex.Message}");
	//			return false;
	//		}
	//	}

	//	private bool leerFamiliares()
	//	{
	//		try
	//		{
	//			using (var ConxAdcom = new SqlConnection(datosEmpresa.strConxAdcom))
	//			using (var comm = new SqlCommand("SELECT * FROM ROLFAM WHERE CodEmpleado = @QUECODIGO", ConxAdcom))
	//			{
	//				comm.Parameters.AddWithValue("@QUECODIGO", CodigoDirectorio);
	//				ConxAdcom.Open();

	//				using (var rs = comm.ExecuteReader())
	//				{
	//					int i = 0;
	//					while (rs.Read())
	//					{
	//						malla.Rows.Add();

	//						// Basic information
	//						malla.Rows[i].Cells["CedulaId"].Value = Valores.CorrijeNulo(rs["CEDULA"]);
	//						malla.Rows[i].Cells["Nombres"].Value = Valores.CorrijeNulo(rs["Nombres"]);
	//						malla.Rows[i].Cells["Parentesco"].Value = Valores.CorrijeNulo(rs["Parentesco"]);

	//						// First get the column index for "FechaNacim"
	//						int fechaNacimColIndex = GetColumnIndexByName(malla, "FechaNacim");

	//						// Then use the index for assignment
	//						malla.Rows[i].Cells[fechaNacimColIndex].Value = rs.IsDBNull(rs.GetOrdinal("FechaNacimiento"))
	//							? string.Empty
	//							: ((DateTime)rs["FechaNacimiento"]).ToShortDateString();



	//						// Personal details
	//						malla.Rows[i].Cells["Sexo1"].Value = Valores.CorrijeNulo(rs["Sexo"]);
	//						malla.Rows[i].Cells["EstadoCivil"].Value = Valores.CorrijeNulo(rs["EstadoCivil"]);
	//						malla.Rows[i].Cells["Direccion"].Value = Valores.CorrijeNulo(rs["Direccion"]);

	//						// Contact information
	//						malla.Rows[i].Cells["Teléfono_1"].Value = Valores.CorrijeNulo(rs["Teléfono_1"]);
	//						malla.Rows[i].Cells["Teléfono_2"].Value = Valores.CorrijeNulo(rs["Teléfono_2"]);
	//						malla.Rows[i].Cells["Ocupación"].Value = Valores.CorrijeNulo(rs["Ocupacion"]);

	//						// Boolean-like fields
	//						malla.Rows[i].Cells["Depend"].Value =
	//							Valores.CorrijeNulo(rs["EsDependiente"]).Equals("Si", StringComparison.OrdinalIgnoreCase)
	//							? "Si" : "No";

	//						malla.Rows[i].Cells["Minusv"].Value =
	//							Valores.CorrijeNulo(rs["EsMinusvalido"]).Equals("Si", StringComparison.OrdinalIgnoreCase)
	//							? "Si" : "No";

	//						i++;
	//					}
	//				}
	//			}
	//			return true;
	//		}
	//		catch (Exception ex)
	//		{
	//			MessageBox.Show($"Error loading family data: {ex.Message}");
	//			return false;
	//		}
	//	}


	//	private int GetColumnIndexByName(DataGridView grid, string columnName)
	//	{
	//		foreach (DataGridViewColumn column in grid.Columns)
	//		{
	//			if (column.Name == columnName)
	//				return column.Index;
	//		}
	//		throw new ArgumentException($"Column '{columnName}' not found in DataGridView");
	//	}

	//	private void CargarAdicionales(string QueCodigo)
	//	{
	//		AdcAdicEmp Adi = new AdcAdicEmp(datosEmpresa.strConxAdcom);
	//		if (mallaDatos.RowCount < 1)
	//			return;

	//		for (int i = 0; i < mallaDatos.RowCount; i++)
	//		{
	//			if (mallaDatos.Rows[i].HeaderCell.Value != null)
	//			{
	//				string headerValue = mallaDatos.Rows[i].HeaderCell.Value.ToString();
	//				Adi = AdcAdicEmp.Buscar($"codEmpleado = '{CodigoDirectorio}' and nomadicional = '{headerValue}'");

	//				if (Adi != null)
	//				{
	//					mallaDatos.Rows[i].Cells[0].Value = Adi.ValorAdicional;
	//				}
	//			}
	//		}
	//	}

	//	private void CargarConceptos(string QueCodigo)
	//	{
	//		AdcEmplCon adi = new AdcEmplCon();
	//		EmpNomR.AdcNomb retn = new EmpNomR.AdcNomb();
	//		try
	//		{
	//			// Check if grid has rows and first row header has value
	//			if (mallaConceptos.Rows.Count == 0 ||
	//				mallaConceptos.Rows[0].HeaderCell.Value == null ||
	//				Convert.IsDBNull(mallaConceptos.Rows[0].HeaderCell.Value))
	//			{
	//				return;
	//			}

	//			for (int i = 0; i < mallaConceptos.Rows.Count; i++)
	//			{
	//				var headerCell = mallaConceptos.Rows[i].HeaderCell;

	//				// Check if header has value
	//				if (headerCell.Value != null && !Convert.IsDBNull(headerCell.Value))
	//				{
	//					string headerValue = headerCell.Value.ToString();

	//					string tipo = ""; // Create variable to hold the optional output
	//					int conceptoId = int.Parse(new EmpNomR.AdcNomb()
	//						.RetornaCodigoConceptoRol(headerValue, datosEmpresa.strConxAdcom,  tipo));

						
	//					// Search with parameterized query to prevent SQL injection
	//					adi = AdcEmplCon.Buscar($"idEmpleado = @queCodigo AND idConcepto = @conceptoId");
							
	//						new SqlParameter("@queCodigo", QueCodigo);
	//						new SqlParameter("@conceptoId", conceptoId);

	//					// Set cell value
	//					mallaConceptos.Rows[i].Cells[0].Value = adi != null ? "SI" : "NO";
	//				}
	//			}
	//		}
	//		catch (Exception ex)
	//		{
	//			// Log error and show message
	//			MessageBox.Show($"Error loading concepts: {ex.Message}",
	//						  "Error",
	//						  MessageBoxButtons.OK,
	//						  MessageBoxIcon.Error);

	//			// Optionally rethrow if you want calling code to handle it
	//			// throw;
	//		}
	//	}

	//	private void btnSalir_Click(object sender, EventArgs e)
	//	{
	//		if (MessageBox.Show("¿Está seguro que desea salir?","Confirmación",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
	//		{
	//			this.Close();
	//		}
	//	}

	//	private void btnCerrar_Click(object sender, EventArgs e)
	//	{
	//		CerrarRegistro();
	//		accion = "";
	//		inhabilitar();
	//	}

	//	private void CerrarRegistro()
	//	{
	//		LimpiezaFormulario();
	//		EsNuevo = 0;
	//		PonerBotonesFormulario();
	//	}

	//	private void Codigo_KeyDown(object sender, KeyEventArgs e)
	//	{
			
	//	}

	//	private void BuscarProximoCodigo()
	//	{
	//		using (var ConxAdcom = new SqlConnection(datosEmpresa.strConxAdcom))
	//		{
	//			try
	//			{
	//				string sql = @"SELECT TOP 1 codigo 
 //                         FROM identificacion 
 //                         ORDER BY SUBSTRING('0000000000000000000000000' + codigo, 
 //                                 LEN(codigo) + 1, 25) DESC";

	//				using (var comm = new SqlCommand(sql, ConxAdcom))
	//				{
	//					ConxAdcom.Open();
	//					using (var rs = comm.ExecuteReader())
	//					{
	//						if (!rs.Read())
	//						{
	//							Codigo.Text = "1";
	//							return;
	//						}

	//						string a = rs["codigo"].ToString();
	//						double cod = 0;
	//						string C = "";

	//						if (double.TryParse(a, out cod))
	//						{
	//							// Numeric case - we already have the value in 'cod'
	//						}
	//						else
	//						{
	//							// Non-numeric case - extract numeric suffix
	//							for (int i = 0; i < a.Length; i++)
	//							{
	//								char b = a[i];
	//								if (b < '0' || b > '9')
	//								{
	//									C += b;
	//								}
	//								else
	//								{
	//									string remaining = a.Substring(i);
	//									if (double.TryParse(remaining, out cod))
	//									{
	//										break;
	//									}
	//								}
	//							}
	//						}

	//						Codigo.Text = C + (cod + 1).ToString();
	//					}
	//				}
	//			}
	//			catch (Exception ex)
	//			{
	//				MessageBox.Show($"Error finding next code: {ex.Message}");
	//				Codigo.Text = "1";
	//			}
	//		}
	//	}

	//	private void Codigo_Leave(object sender, EventArgs e)
	//	{
	//		SaliendoCodigo();
	//	}

	//	private void btnAbrir_Click(object sender, EventArgs e)
	//	{
	//		BuscarRegistro();
	//		accion = "actualizar";
	//		habilitar();
	//	}

	//	private void habilitar()
	//	{
	//		TipoIdent.Enabled = true;
	//		TxtCedulaRuc.Enabled = true;
	//		TxtNombres.Enabled = true;
	//		txtTelefono1.Enabled = true;
	//		txtTelefono2.Enabled = true;
	//		txtTelefono3.Enabled = true;
	//		TxtData8.Enabled = true;
	//		TxtData6.Enabled = true;
	//		txttiporegimen.Enabled = true;
	//		txtContabilidad.Enabled = true;
	//		txtagenteR.Enabled = true;
	//		TxtResolucionAR.Enabled = true;
	//		txtContribuyenteEspecial.Enabled = true;
	//		txtNroContribuyente.Enabled = true;
	//		cmbPaisDomicilio.Enabled = true;
	//		cmbProvinciaDomicilio.Enabled = true;
	//		cmbCantonDomicilio.Enabled = true;
	//		cmbParroquiaDomicilio.Enabled = true;
	//		cmbCiudadDomicilio.Enabled = true;
	//		cmbRegionDomicilio.Enabled = true;
	//		txtnomDireccion.Enabled = true;
	//		txtSector.Enabled = true;
	//		TxtNroDomicilio.Enabled = true;
	//		Cliente.Enabled = true;
	//		EsVendedor.Enabled = true;
	//		if (Natural.Checked)
	//		{
	//			Juridica.Checked = false;				
	//			Proveedor.Enabled = true;
	//			Empleado.Enabled = true;				
	//			Banco.Enabled = false;
	//			TxtApellidos.Visible = true;
	//			label96.Visible = true;
				
	//		}
	//		if (Juridica.Checked)
	//		{
	//			Juridica.Checked = true;				
	//			Proveedor.Enabled = true;
	//			Empleado.Enabled = false;				
	//			Banco.Enabled = true;
	//		}
			
	//	}

	//	private void BuscarRegistro()
	//	{
	//		BuscaClien prog = new BuscaClien();
	//		using (prog = new BuscaClien())
	//		{
	//			TxtCedulaRuc.Text = prog.IniBuscaCliOPro("T", "", "", "N");

	//			if (!string.IsNullOrEmpty(TxtCedulaRuc.Text))
	//			{
	//				SaliendoCodigo();
	//			}
	//		}
	//	}

	//	private void btnGuardar_Click(object sender, EventArgs e)
	//	{
	//		Syscod.ManSysnetClass Buscod = new Syscod.ManSysnetClass();

	//		try
	//		{
	//			malla.EndEdit();
	//			mallaConceptos.EndEdit();
	//			MallaCtco.EndEdit();
	//			mallaDatos.EndEdit();
	//			if (!validacionDatos())
	//				return;

	//			string CodigoBusca = Codigo.Text;
	//			string cedulabusca = TxtCedulaRuc.Text;

	//			Identificacion DatosIdentificacion = new Identificacion(datosEmpresa.strConxAdcom);

	//			if (CodigoBusca == DBNull.Value.ToString())
	//				CodigoBusca = "";

	//			DatosIdentificacion = Identificacion.Buscar("cedulaidentidadruc='" + cedulabusca + "' and codigo <> '" + CodigoBusca + "'");
	//			if (DatosIdentificacion != null)
	//			{
	//				TxtCedulaRuc.Text = "";
	//				MessageBox.Show("El Nro. ID (cédula o ruc) ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
	//				TxtCedulaRuc.Focus();
	//				return;
	//			}

	//			DatosIdentificacion = new Identificacion(datosEmpresa.strConxAdcom);
	//			moverDatosIdentificacion movdatId = new moverDatosIdentificacion();
	//			movdatId.movDatIdentificacion(this, DatosIdentificacion, codigoDirectorio);
	//			movdatId = null;

	//			if (DatosIdentificacion.Actualizar("Select * from Identificacion where identificacion.codigo = '" + CodigoBusca + "'").Substring(0, 5) == "ERROR")
	//			{
	//				MessageBox.Show("El registro de identificacion no puede grabarse", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
	//				return;
	//			}

	//			DatosIdentificacion = null;
	//			inhabilitar();
	//			//Microsoft.VisualBasic.Interaction.SaveSetting("Alex", "Codigos", "Ultimo", Codigo.Text);
	//			Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Software\VB and VBA Program Settings\Alex\Codigos", "Ultimo", Codigo.Text);

	//			// tabla personal
	//			if (Natural.Checked)
	//			{
	//				dbPersonal tablaper = new dbPersonal(datosEmpresa.strConxAdcom);
	//				tablaper.CodigoPer = Codigo.Text;
	//				//tablaper.FechaNacimiento = DateTime.TryParse(fechanaci.Text, out DateTime fechaNac) ? fechaNac : new DateTime(1900, 1, 1);

	//				// Si el DateTimePicker no permite valores nulos
	//				//tablaper.FechaNacimiento = fechanaci.Value;

	//				// Mostrar fecha completa con hora
	//				//MessageBox.Show(fechanaci.Value.ToString());

	//				// Mostrar solo en formato dd/MM/yyyy
	//				//MessageBox.Show(fechanaci.Value.ToString("dd/MM/yyyy"));

	//				// Mostrar en formato largo (ej. viernes, 8 de septiembre de 2025)
	//				//MessageBox.Show(fechanaci.Value.ToLongDateString());

	//				var fecha = tablaper.FechaNacimiento.ToString("dd/MM/yyyy");

	//				tablaper.FechaNacimiento = fechanaci.Value;





	//				tablaper.LugarNacimiento = Lugarnaci.Text;
	//				tablaper.Sexo = hombre.Checked ? "H" : "M";
	//				tablaper.EstadoCivil = cmbEstadoCivil.Text;
	//				if (cmbNacionalidadPersonal.SelectedValue != null)
	//				tablaper.Nacionalidad = cmbNacionalidadPersonal.SelectedValue.ToString();
	//				tablaper.Hobbys = hobbys.Text;
	//				tablaper.codigotarjrta = txtCodTar.Text;
	//				tablaper.numerotarjrta = txtNumTar.Text;
	//				tablaper.Profesión = Valores.CorrijeNulo(cmbProfesion.SelectedValue);
	//				tablaper.Especialidad = Valores.CorrijeNulo(cmbEspecialidad.SelectedValue);
	//				tablaper.Especialidad2 = Valores.CorrijeNulo(cmbEspecialidad2.SelectedValue);
	//				tablaper.Referirsecomo = txtReferirseComo.Text;
	//				tablaper.AsociadoAEmpresa = Convert.ToInt32("0" + codigoDirectorio[3]);
	//				tablaper.TipoSangre = cmbTipoSangre.Text;
	//				tablaper.DirecciónTrabajo = txtLugTra.Text;
	//				tablaper.ciudadNacimto = cmbCiudadNace.Text;
	//				tablaper.paisNacimto = cmbPaisNace.Text;
	//				tablaper.provNacimto = cmbProvinciaNace.Text;
	//				tablaper.Discapacidad = txtDiscapacidad.Text;
	//				tablaper.PorcentajeDiscapacidad = Convert.ToDecimal("0" + txtPorcDiscapacidad.Text);
	//				tablaper.regionNacimto = cmbRegionNace.Text;

	//				if (tablaper.Actualizar("select * from Personal where codigoper = '" + Codigo.Text + "'").Substring(0, 5) == "ERROR")
	//				{
	//					MessageBox.Show("El registro personal no puede grabarse", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
	//				}
	//				tablaper = null;
	//			}

	//			// tabla cliente
	//			if (Cliente.CheckState == CheckState.Checked)
	//			{
	//				dbCliente tablacli = new dbCliente(datosEmpresa.strConxAdcom);
	//				tablacli.CodigoCli = Codigo.Text;
	//				tablacli.TipoCli = Buscod.QueCodigo(txtTipoCliente.Text, TipCodSyscod[3]);
	//				tablacli.ZonaVentas = Buscod.QueCodigo(txtZonaVentas.Text, TipCodSyscod[4]);
	//				tablacli.VendedorInterno = codigoDirectorio[0];
	//				tablacli.Operador = codigoDirectorio[5];
	//				tablacli.Transportadora = codigoDirectorio[6];
	//				tablacli.ZonaCobranza = Buscod.QueCodigo(txtZonaCobranzas.Text, TipCodSyscod[5]);
	//				tablacli.CobradorInterno = codigoDirectorio[1];
	//				tablacli.PrecioVenta = Buscod.QueCodigo(txtPrecioVenta.Text, TipCodSyscod[6]);
	//				tablacli.FormaPago = RetornaNombre.RetornaCodigoPago(txtFormaPago.Text, datosEmpresa.strConxAdcom);
	//				tablacli.PorcDescuento = Convert.ToDecimal(string.IsNullOrEmpty(txtPorcDescuento.Text) ? "0" : txtPorcDescuento.Text);
	//				tablacli.LimiteCredito = Convert.ToDecimal(string.IsNullOrEmpty(txtLimiteCredito.Text) ? "0" : txtLimiteCredito.Text);
	//				tablacli.DescuentoAso = Convert.ToDecimal(string.IsNullOrEmpty(txtDescuentoAsociacion.Text) ? "0" : txtDescuentoAsociacion.Text);
	//				tablacli.Observaciones = observacli.Text;
	//				tablacli.Contacto = txtContacto.Text;
	//				tablacli.Entregarmercaderia = entregarmer.Text;
	//				tablacli.CtbCobrar = Cuenta0.Text;
	//				tablacli.CtbCobrar2 = Cuenta4.Text;
	//				tablacli.PaisEmbarque = txtPaisEntrega.Text;
	//				tablacli.PuertoEmbarque = entregarmer.Text;

	//				if (tablacli.Actualizar("select * from cliente where codigocli = '" + Codigo.Text + "'").Substring(0, 5) == "ERROR")
	//				{
	//					MessageBox.Show("El registro cliente no puede grabarse", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
	//				}
	//				tablacli = null;
	//			}

	//			// PROVEEDOR
	//			if (Proveedor.Checked)
	//			{
	//				dbProveedor tablapro = new dbProveedor(datosEmpresa.strConxAdcom);
	//				tablapro.CodigoProveedor = Codigo.Text;
	//				tablapro.FormaPago = RetornaNombre.RetornaCodigoPago(Lcod8.Text, datosEmpresa.strConxAdcom);
	//				tablapro.PorceDescuent = Convert.ToDecimal(string.IsNullOrEmpty(porcedescuentoprv.Text) ? "0" : porcedescuentoprv.Text);
	//				tablapro.IncluyeTranspo = incluyetransporte.Checked;
	//				tablapro.LimCreditoPrv = Convert.ToDecimal(string.IsNullOrEmpty(limcreditoprv.Text) ? "0" : limcreditoprv.Text);
	//				tablapro.Producto1 = producto.Text;
	//				tablapro.Servicios1 = servicios.Text;
	//				tablapro.Observaciones = observacionesprv.Text;
	//				tablapro.CtbProveedor = Cuenta1.Text;
	//				tablapro.CtbProveedor2 = Cuenta5.Text;
	//				tablapro.EntregaNuestraOficina = chkEntregaDirecccion.Checked;
	//				tablapro.RetirarMercaderia = chkRetirarProveedor.Checked;
	//				tablapro.EnvioATransporte = chkRetirarTransporte.Checked;
	//				tablapro.transAereo = chkAereo.Checked;
	//				tablapro.transMaritimo = chkMaritimo.Checked;
	//				tablapro.transTerrestre = chkTerrestre.Checked;

	//				if (tablapro.Actualizar("select * from proveedor where codigoproveedor = '" + Codigo.Text + "'").Substring(0, 5) == "ERROR")
	//				{
	//					MessageBox.Show("El registro proveedor no puedo grabarse", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
	//				}
	//				tablapro = null;
	//			}

	//			// tabla empleado
	//			if (Empleado.CheckState == CheckState.Checked)
	//			{
	//				dbEmpleado tablaemp = new dbEmpleado(datosEmpresa.strConxAdcom);
	//				MoverDatosEmpleado.moverDatos(this, tablaemp, TipCodSyscod, codigoDirectorio[2], CodSuc);

	//				string elError = tablaemp.Actualizar("select * from empleado where codigoempleado = '" + QUECODIGO + "'");
	//				if (elError.Substring(0, 5) == "ERROR")
	//				{
	//					MessageBox.Show("El registro empleado no puede grabarse \n" + elError, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
	//				}
	//				else
	//				{
	//					verificaCambios.VerificaCambios(LosCambios, tablaemp, !accion.ToUpper().Equals("ACTUALIZAR"));
	//				}
	//			}

	//			dbContactos tablacon = new dbContactos(datosEmpresa.strConxAdcom);

	//			using (SqlConnection ConxAdcom = new SqlConnection(datosEmpresa.strConxAdcom))
	//			{
	//				ConxAdcom.Open();
	//				string Ssql = "delete from contactos where codcontacto='" + codigoDirectorio + "'";
	//				SqlCommand comm = new SqlCommand(Ssql, ConxAdcom);
	//				comm.ExecuteNonQuery();

	//				if (MallaCtco.RowCount > 1)
	//				{
	//					for (int i = 0; i < MallaCtco.RowCount - 1; i++)
	//					{
	//						if (MallaCtco.Rows[i].Cells[1].Value != null)
	//						{
	//							tablacon = new dbContactos(datosEmpresa.strConxAdcom);
	//							tablacon.CodContacto = QUECODIGO;
	//							tablacon.Principal = MallaCtco.Rows[i].Cells[0].Value.ToString();
	//							tablacon.Nombre = MallaCtco.Rows[i].Cells[1].Value.ToString();
	//							tablacon.Cargo = MallaCtco.Rows[i].Cells[2].Value.ToString();
	//							tablacon.Extensión = MallaCtco.Rows[i].Cells[3].Value.ToString();
	//							tablacon.TelfCelular = MallaCtco.Rows[i].Cells[4].Value.ToString();
	//							tablacon.TeléfonoDirecto = MallaCtco.Rows[i].Cells[5].Value.ToString();
	//							tablacon.FechaNacimiento = DateTime.TryParse(MallaCtco.Rows[i].Cells[6].Value.ToString(), out DateTime fechaNacContacto) ? fechaNacContacto : new DateTime(1900, 1, 1);
	//							tablacon.Actividades = MallaCtco.Rows[i].Cells[7].Value.ToString();
	//							tablacon.Preferencias = MallaCtco.Rows[i].Cells[8].Value.ToString();
	//							tablacon.Observaciones = MallaCtco.Rows[i].Cells[9].Value.ToString();

	//							if (tablacon.Actualizar("select * from contactos where codcontacto='" + Codigo.Text + "' and nombre = '" + tablacon.Nombre + "'").Substring(0, 5) == "ERROR")
	//							{
	//								MessageBox.Show("El registro contactos no se guardó", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
	//							}
	//						}
	//					}
	//				}
	//				tablacon = null;

	//				Ssql = "delete from identificacionalias where codigoempresa='" + QUECODIGO + "'";
	//				comm = new SqlCommand(Ssql, ConxAdcom);
	//				comm.ExecuteNonQuery();

	//				dbIdentificacionAlias tablaAlias = new dbIdentificacionAlias(datosEmpresa.strConxAdcom);
	//				if (MallaAlias.RowCount > 1)
	//				{
	//					for (int i = 0; i < MallaAlias.RowCount - 1; i++)
	//					{
	//						if (MallaAlias.Rows[i].Cells[1].Value != null)
	//						{
	//							tablaAlias = new dbIdentificacionAlias(datosEmpresa.strConxAdcom);
	//							tablaAlias.CodigoEmpresa = QUECODIGO;
	//							tablaAlias.NombreAlias = MallaAlias.Rows[i].Cells[0].Value.ToString();
	//							tablaAlias.DirecciónAlterna = MallaAlias.Rows[i].Cells[1].Value.ToString();
	//							tablaAlias.Teléfono_1 = MallaAlias.Rows[i].Cells[2].Value.ToString();
	//							tablaAlias.Teléfono_2 = MallaAlias.Rows[i].Cells[3].Value.ToString();
	//							tablaAlias.Id_Sri = MallaAlias.Rows[i].Cells[4].Value.ToString();
	//							tablaAlias.Observaciones = MallaAlias.Rows[i].Cells[5].Value.ToString();

	//							if (tablaAlias.Actualizar("select * from IdentificacionAlias where codigoEmpresa = '" + Codigo.Text + "' and nombreAlias = '" + tablaAlias.NombreAlias + "'").Substring(0, 5) == "ERROR")
	//							{
	//								MessageBox.Show("El registro alias no se grabó", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
	//								return;
	//							}
	//						}
	//					}
	//				}
	//				tablaAlias = null;

	//				Ssql = "delete from rolfam where CodEmpleado='" + QUECODIGO + "'";
	//				comm = new SqlCommand(Ssql, ConxAdcom);
	//				comm.ExecuteNonQuery();

	//				dbFamilia tablaFam = new dbFamilia(datosEmpresa.strConxAdcom);
	//				foreach (DataGridViewRow rr in malla.Rows)
	//				{
	//					tablaFam = new dbFamilia(datosEmpresa.strConxAdcom);
	//					if (rr.Cells[1].Value != null && !string.IsNullOrEmpty(rr.Cells[1].Value.ToString()))
	//					{
	//						tablaFam.CodEmpleado = QUECODIGO;
	//						tablaFam.CEDULA = rr.Cells[1].Value.ToString();
	//						tablaFam.Nombres = rr.Cells[2].Value.ToString();
	//						tablaFam.Parentesco = rr.Cells[3].Value.ToString();
	//						tablaFam.FechaNacimiento = DateTime.TryParse(rr.Cells[4].Value.ToString(), out DateTime fechaNacFam) ? fechaNacFam : new DateTime(1900, 1, 1);
	//						tablaFam.Sexo = rr.Cells[5].Value.ToString();
	//						tablaFam.EstadoCivil = rr.Cells[6].Value.ToString();
	//						tablaFam.Direccion = rr.Cells[7].Value.ToString();
	//						tablaFam.Teléfono_1 = rr.Cells[8].Value.ToString();
	//						tablaFam.Teléfono_2 = rr.Cells[9].Value.ToString();
	//						tablaFam.Ocupacion = rr.Cells[10].Value.ToString();
	//						tablaFam.EsDependiente = rr.Cells[11].Value.ToString();
	//						tablaFam.EsMinusvalido = rr.Cells[12].Value.ToString();

	//						if (tablaFam.Actualizar("select * from ROLFAM where codeMPLEADO = '" + Codigo.Text + "' AND CEDULA = '" + tablaFam.CEDULA + "'").Substring(0, 5) == "ERROR")
	//						{
	//							MessageBox.Show("El registro de familiares no se grabó", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
	//							return;
	//						}
	//					}
	//				}
	//			}

	//			if (mallaDatos.RowCount > 0 && Emp.rol)
	//				GuardarAdicionales();
	//			if (mallaConceptos.RowCount > 0 && Emp.rol)
	//				GuardarConceptos();

	//			accion = "";
	//			LimpiezaFormulario();

	//			PonerBotonesFormulario();
	//			if (IniNvo)
	//				this.Close();
	//			Buscod = null;
	//			CerrarRegistro();
	//			accion = "";
	//			//Natural.Checked = false;
	//			//Juridica.Checked = false;
	//			//tabDatosPer.Parent = Natural.Checked ? DatosDirectorio : null;
	//			inhabilitar();

	//		}
	//		catch (Exception exx)
	//		{
	//			MessageBox.Show("Se produjo una excepción al grabar " + exx.Message);
	//		}


	//	}

	//	private void inhabilitar()
	//	{
	//		TipoIdent.Enabled = false;
	//		TxtCedulaRuc.Enabled = false;
	//		TxtNombres.Enabled = false;
	//		txtTelefono1.Enabled = false;
	//		txtTelefono2.Enabled = false;
	//		txtTelefono3.Enabled = false;
	//		TxtData8.Enabled = false;
	//		TxtData6.Enabled = false;
	//		txttiporegimen.Enabled = false;
	//		txtContabilidad.Enabled = false;
	//		txtagenteR.Enabled = false;
	//		TxtResolucionAR.Enabled = false;
	//		txtContribuyenteEspecial.Enabled = false;
	//		txtNroContribuyente.Enabled = false;
	//		cmbPaisDomicilio.Enabled = false;
	//		cmbProvinciaDomicilio.Enabled = false;
	//		cmbCantonDomicilio.Enabled = false;
	//		cmbParroquiaDomicilio.Enabled = false;
	//		cmbCiudadDomicilio.Enabled = false;
	//		cmbRegionDomicilio.Enabled = false;
	//		txtnomDireccion.Enabled = false;
	//		txtSector.Enabled = false;
	//		TxtNroDomicilio.Enabled = false;
	//		Cliente.Checked = false;
	//		Proveedor.Checked = false;
	//		Empleado.Checked = false;

	//		tabCliente.Parent = null;
	//		tabProveedor.Parent = null;
	//		tabEmpleado.Parent = null;
	//		Label79.Visible = false;
	//		txtHistoriaclinica.Visible = false;
	//		// Convertir el string a DateTime antes de asignar
	//		//fechanaci.Value = DateTime.Parse("01/01/1900");

			
	//	}

	//	private void GuardarConceptos()
	//	{
	//		AdcEmplCon Adi = new AdcEmplCon(datosEmpresa.strConxAdcom);
	//		EmpNomR.AdcNomb retn = new EmpNomR.AdcNomb();

	//		try
	//		{
	//			for (int i = 0; i < mallaConceptos.RowCount; i++)
	//			{
	//				if (mallaConceptos.Rows[i].HeaderCell.Value != null)
	//				{
	//					Adi.idConcepto = Convert.ToInt32(retn.RetornaCodigoConceptoRol(mallaConceptos.Rows[i].HeaderCell.Value.ToString(),datosEmpresa.strConxAdcom,tipoper));

	//					Adi.IdEmpleado = Codigo.Text;
	//					Adi.UsuarioAsigna = datosEmpresa.usr;
	//					Adi.FechaAsignacion = DateTime.Now;

	//					if (mallaConceptos.Rows[i].Cells[0].Value != null)
	//					{
	//						if (mallaConceptos.Rows[i].Cells[0].Value.ToString() == "SI")
	//						{
	//							Adi.Actualizar();
	//						}
	//						else
	//						{
	//							Adi.Borrar();
	//						}
	//					}
	//				}
	//			}
	//		}
	//		catch (Exception EX)
	//		{
	//			MessageBox.Show(EX.Message);
	//		}
	//	}

	//	private bool validacionDatos()
	//	{
	//		//string resultadoF = resultadoConsulta;
	//		bool resp = false;

	//		if (string.IsNullOrEmpty(Codigo.Text))
	//		{
	//			MessageBox.Show("Digite un Código Válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
	//			return resp;
	//		}

	//		if (DattCom.datosEmpresa.LongCodDirectorio > 0 && Codigo.Text.Length != DattCom.datosEmpresa.LongCodDirectorio)
	//		{
	//			MessageBox.Show("El código debe tener la longitud correcta (" + DattCom.datosEmpresa.LongCodDirectorio.ToString() + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
	//			return resp;
	//		}

	//		if (string.IsNullOrEmpty(TipoIdent.Text))
	//		{
	//			MessageBox.Show("Falta el tipo de identificación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
	//			return resp;
	//		}

	//		if (string.IsNullOrEmpty(TxtCedulaRuc.Text))
	//		{
	//			MessageBox.Show("Debe ingresar el RUC o CI", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
	//			TxtCedulaRuc.Focus();
	//			return resp;
	//		}
	//		//aqui valida el tipo de cedula si es juridica o natural
	//		if (!ValidaNumeroId())
	//		{
	//			MessageBox.Show("El numero del documento de identificacion está errado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
	//			TxtCedulaRuc.Focus();
	//			return resp;
	//		}

	//		if (txtHistoriaclinica.Text.Length == 0 && (TipoIdent.Text=="Cédula Identidad" || TipoIdent.Text == "Pasaporte"))

	//			txtHistoriaclinica.Text = Codigo.Text.Substring(1,10);txtHistoriaclinica.Visible = true; Label79.Visible = true;

	//		if (string.IsNullOrEmpty(TxtNombres.Text))
	//		{
	//			MessageBox.Show("Debe ingresar el nombre", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
	//			TxtNombres.Focus();
	//			return resp;
	//		}

	//		if (Natural.Checked)
	//		{
	//			tipoper = "N";
	//		}
	//		if (Juridica.Checked)
	//		{
	//			tipoper = "J";
	//		}

	//		if (string.IsNullOrEmpty(TxtNombres.Text))
	//		{
	//			TxtNombres.Focus();
	//			MessageBox.Show("Debe ingresar el nombre de impresión", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
	//			return resp;
	//		}

	//		string errado = "";
	//		// Comentarios convertidos a C#
	//		// if (cmbCantonDomicilio.SelectedValue == DBNull.Value) errado += " ; Canton de domicilio";
	//		// if (cmbCargoRol.SelectedValue == DBNull.Value) errado += " ;  Cargo del rol ";
	//		// ... resto de validaciones comentadas

	//		if (errado.Trim().Length > 0)
	//		{
	//			MessageBox.Show("Errores de digitación encontrados : \n" + errado);
	//			return resp;
	//		}

	//		return true;
	//	}

	//	private bool ValidaNumeroId()
	//	{
	//		string j = "";
	//		string Persona = "P";
	//		bool result = false;

	//		switch (TipoIdent.SelectedIndex)
	//		{
	//			//case 0:
	//			//	j = "O";
	//			//	break;
	//			case 0:
	//				j = "R";
	//				break;
	//			case 1:
	//				j = "C";
	//				break;
	//			case 2:
	//				j = "P";
	//				break;
	//			case 3:
	//				j = "F";
	//				break;
	//		}

	//		if (j == "O")
	//		{
	//			return true;
	//		}

	//		if (Juridica.Checked)
	//		{
	//			Persona = "E";
	//		}

	//		if (j == "P")
	//		{
	//			result = true;
	//		}
	//		else if (j == "F" && TxtCedulaRuc.Text == "9999999999999")
	//		{
	//			result = true;
	//		}
	//		else
	//		{
	//			if (j == "R" )
	//			{
	//				result = true;
	//			}
	//			else
	//			{
	//				if (j == "C")
	//				{
	//					result = true;
	//				}
	//			}
				
	//		}

	//		return result;
	//	}

	
	//	private void GuardarAdicionales()
	//	{
	//		AdcAdicEmp Adi = new AdcAdicEmp(datosEmpresa.strConxAdcom);
	//		EmpNomR.AdcNomb retn = new EmpNomR.AdcNomb();

	//		for (int i = 0; i < mallaDatos.RowCount; i++)
	//		{
	//			if (mallaDatos.Rows[i].HeaderCell.Value != null)
	//			{
	//				Adi.CodEmpleado = QUECODIGO;
	//				Adi.CodAdicional = retn.RetornaCodigoSyscod("adicionalEmpleado", mallaDatos.Rows[i].HeaderCell.Value.ToString(), datosEmpresa.strConxSyscod);
	//				Adi.NomAdicional = mallaDatos.Rows[i].HeaderCell.Value.ToString();
	//				Adi.ValorAdicional = mallaDatos.Rows[i].Cells[0].Value.ToString();
	//				Adi.Actualizar();
	//			}
	//		}
	//	}

	//	private void CBuscador3_Click(object sender, EventArgs e)
	//	{
	//		//CBuscador(txtTipoCliente, 3);
	//		//CBuscador(ref "", 3);
	//	}

	//	private void CBuscador(ref Label lcod, int indice)
	//	{
	//		string ElNombre = "";
	//		string ElCodigo = "";
	//		Syscod.ManSysnetClass Buscod = new Syscod.ManSysnetClass();

	//		lcod.Text = Buscod.BuscarReferencia(ref TipCodSyscod[indice],ref ElCodigo,ref ElNombre);
						
	//	}

	//	private void btnBuscaZonaVentas_Click(object sender, EventArgs e)
	//	{
	//		CBuscador(ref txtZonaVentas, 4);
	//	}

	//	private void btnBuscaZonaCobro_Click(object sender, EventArgs e)
	//	{
	//		CBuscador(ref txtZonaCobranzas, 5);
	//	}

	//	private void btnBuscaOperador_Click(object sender, EventArgs e)
	//	{
	//		string[] dat = new string[2];
	//		dat = CbuscaDir("O", 0);
	//		txtOperador.Text = dat[1];
	//		codigoDirectorio[5] = dat[0];
	//	}

	//	private string[] CbuscaDir(string tipo, int index)
	//	{
	//		string cod = "";
	//		string nom = "";
	//		string[] datos = new string[3];

	//		using (BuscaClien prog = new BuscaClien())
	//		{
	//			cod = prog.IniBuscaCliOPro(tipo, nom, "", "");
	//			prog.Close();
	//		}

	//		datos[0] = cod;
	//		datos[1] = nom;

	//		return datos;
	//	}

	//	private void btnBuscaVendedor_Click(object sender, EventArgs e)
	//	{
	//		string[] dat = new string[3];
	//		dat = CbuscaDir("V", 0);
	//		txtOperador.Text = dat[1];
	//		codigoDirectorio[0] = dat[0];
	//	}

	//	private void btnBuscaCobrador_Click(object sender, EventArgs e)
	//	{
	//		string[] dat = new string[3];
	//		dat = CbuscaDir("T", 0);
	//		txtOperador.Text = dat[1];
	//		codigoDirectorio[1] = dat[0];
	//	}

	//	private void btnPrecioVenta_Click(object sender, EventArgs e)
	//	{
	//		CBuscador(ref txtPrecioVenta, 6);
	//	}

	//	private void btnFormaPago_Click(object sender, EventArgs e)
	//	{
	//		string ElCodigo = "";
	//		// Create the search form instance
	//		Buscar.frmBuscar BusPAG = new Buscar.frmBuscar(); // DaxPagos.BuscadorPagos

	//		// SQL query string
	//		string sSql = "SELECT TOP 100 PERCENT idFormasDePago, Descripcion AS Descripción " +
	//					  "FROM formasdepago " +
	//					  "WHERE tipoformapago <> 2 " +
	//					  "ORDER BY Descripcion";

	//		// Call the search method
	//		ElCodigo = BusPAG.Buscar(datosEmpresa.strConxAdcom, sSql, "idFormasDePago", "Descripción", "", "Formas de pago clientes");

	//		// Clean up - in C# we typically don't explicitly set to null unless needed
	//		// BusPAG = null; // Not necessary in most cases

	//		// Set the textbox value
	//		txtFormaPago.Text = RetornaNombre.RetornaNombrePago(ElCodigo, datosEmpresa.strConxAdcom);
	//	}

	//	private void btnPaísEntrega_Click(object sender, EventArgs e)
	//	{
	//		CBuscador(ref txtPaisEntrega, 12);
	//	}

	//	private void btnPuertoEntrega_Click(object sender, EventArgs e)
	//	{
	//		CBuscador(ref entregarmer, 26);
	//	}

	//	private void CBuscador(ref TextBox control, int indice)
	//	{
	//		// Implementation remains the same
	//		string ElNombre = "";
	//		string ElCodigo = "";
	//		Syscod.ManSysnetClass Buscod = new Syscod.ManSysnetClass();

	//		control.Text = Buscod.BuscarReferencia(ref TipCodSyscod[indice],ref ElCodigo,ref ElNombre);
	//	}
	//	private void btnTransportadora_Click(object sender, EventArgs e)
	//	{
	//		string[] dat = new string[3];
	//		dat = CbuscaDir("R", 0);
	//		txtOperador.Text = dat[1];
	//		codigoDirectorio[6] = dat[0];
	//	}

	//	private void Command1_Click(object sender, EventArgs e)
	//	{
	//		cuenta(Cuenta0, (int)Keys.F2, 0 / 0x10000);
	//	}

	//	private void Command5_Click(object sender, EventArgs e)
	//	{
	//		cuenta(Cuenta4, (int)Keys.F2, 0 / 0x10000);
	//	}

	//	//private void cuenta(Label cuenta, int KeyCode, int Shift)
	//	//{
	//	//	if (KeyCode == (int)Keys.F2)
	//	//	{
	//	//		try
	//	//		{
	//	//			MantCtb.BuscaCta prog = new MantCtb.BuscaCta();
	//	//			string Nombre = "";
	//	//			string tipomovimiento = "I";

	//	//			if (prog != null)
	//	//			{
	//	//				cuenta.Text = prog.BuscaCtaCtb(ref Nombre, ref tipomovimiento);
	//	//			}
	//	//			else
	//	//			{
	//	//				MessageBox.Show("Error: Could not create BuscaCta instance");
	//	//			}
	//	//		}
	//	//		catch (Exception ex)
	//	//		{
	//	//			MessageBox.Show($"Error searching account: {ex.Message}");
	//	//		}
	//	//	}
	//	//}
	//	private void cuenta(Label cuenta, int KeyCode, int Shift)
	//	{
	//		if (KeyCode != (int)Keys.F2) return;
	//		if (cuenta == null) return;

	//		CtaMtn.BuscaCta prog = null;
	//		try
	//		{
	//			prog = new CtaMtn.BuscaCta();
	//			string Nombre = string.Empty;
	//			string tipomovimiento = "I";

	//			var result = prog?.BuscaCtaCtb(ref Nombre, ref tipomovimiento);
	//			cuenta.Text = result ?? string.Empty;
	//		}
	//		finally
	//		{
	//			// If BuscaCta implements IDisposable
	//			(prog as IDisposable)?.Dispose();
	//		}
	//	}

	//	private void txtTelefono3_TextChanged(object sender, EventArgs e)
	//	{

	//	}

	//	private void Natural_CheckedChanged(object sender, EventArgs e)
	//	{
	//		if (saltar)
	//			return;

							
	//				Banco.Enabled = false;
	//				Empleado.Enabled = true;
	//				Label34.Visible = true;
	//				//Apellidos.Visible = true;
	//				//Apellidos.Enabled = true;
	//				tipoper = "N";
	//				Natural.Checked = true;
	//				//Asociacion.Text = "Asociado";

	//				//if (Asociacion.CheckState == CheckState.Checked)
	//				//{
	//				//	asociadoa.Visible = true;
	//				//}
	//				//else
	//				//{
	//				//	asociadoa.Visible = false;
	//				//}			

	//			//PonerDatosTipo();
			
	//	}

	//	private void Juridica_CheckedChanged(object sender, EventArgs e)
	//	{
	//		Banco.Enabled = true;
	//		Empleado.Enabled = false;
	//		tipoper = "J";
	//		asociadoa.Visible = false;
	//		//Asociacion.Text = "Asociación";
	//		Label34.Visible = false;
	//		//Apellidos.Visible = false;
	//		//Apellidos.Enabled = false;
	//		//Apellidos.Text = "";
	//		//PonerDatosTipo();
	//	}

	//	private void btnEliminar_Click(object sender, EventArgs e)
	//	{
	//		try
	//		{
	//			using (SqlConnection ConxAdcom = new SqlConnection(datosEmpresa.strConxAdcom))
	//			{
	//				ConxAdcom.Open();
	//				if (string.IsNullOrEmpty(Codigo.Text))
	//				{
	//					MessageBox.Show("No puede eliminar, aun no ha seleccionado un registro",
	//								  "Error",
	//								  MessageBoxButtons.OK,
	//								  MessageBoxIcon.Error);
	//					inhabilitar();
	//					return;
	//				}
	//				CodigoBusca = Codigo.Text;

	//				if (ClienteMovimiento(ref CodigoBusca))
	//				{
	//					MessageBox.Show("No puede eliminar este Código, existen movimientos registrados con este código",
	//								  "Error",
	//								  MessageBoxButtons.OK,
	//								  MessageBoxIcon.Error);
	//					return;
	//				}

	//				if (MessageBox.Show("¿Está seguro que desea eliminar el registro activo?",
	//								   "Confirmar",
	//								   MessageBoxButtons.YesNo,
	//								   MessageBoxIcon.Question) == DialogResult.Yes)
	//				{
	//					// Using transaction for atomic operations
	//					using (SqlTransaction transaction = ConxAdcom.BeginTransaction())
	//					{
	//						try
	//						{
	//							string[] deleteQueries =
	//							{
	//					"DELETE FROM identificacion WHERE codigo = @Codigo",
	//					"DELETE FROM personal WHERE codigoper = @Codigo",
	//					"DELETE FROM contactos WHERE codcontacto = @Codigo",
	//					"DELETE FROM proveedor WHERE codigoproveedor = @Codigo",
	//					"DELETE FROM cliente WHERE codigocli = @Codigo",
	//					"DELETE FROM empleado WHERE codigoEmpleado = @Codigo",
	//					"DELETE FROM rolfam WHERE codEmpleado = @Codigo",
	//					"DELETE FROM adccapper WHERE codEmpleado = @Codigo"
	//				};

	//							foreach (string query in deleteQueries)
	//							{
	//								using (SqlCommand comm = new SqlCommand(query, ConxAdcom, transaction))
	//								{
	//									comm.Parameters.AddWithValue("@Codigo", CodigoBusca);
	//									comm.ExecuteNonQuery();
	//								}
	//							}

	//							transaction.Commit();
	//						}
	//						catch (Exception ex)
	//						{
	//							transaction.Rollback();
	//							MessageBox.Show("Error al eliminar el registro: " + ex.Message,
	//											"Error",
	//											MessageBoxButtons.OK,
	//											MessageBoxIcon.Error);
	//							return;
	//						}
	//					}
	//				}
	//			}
	//		}
	//		catch (Exception ee)
	//		{
	//			MessageBox.Show("Excepción en eliminaDir: " + ee.Message,
	//						   "Error",
	//						   MessageBoxButtons.OK,
	//						   MessageBoxIcon.Error);
	//		}
	//		finally
	//		{
	//			CodigoBusca = "";
	//			QUECODIGO = "";
	//			LimpiezaFormulario();
	//			DatosDirectorio.SelectedIndex = 0;
	//			EsNuevo = 0;
	//			PonerBotonesFormulario();
	//		}
	//	}



	//	public bool ClienteMovimiento(ref string codigo)
	//	{
	//		bool hasMovements = false;

	//		using (SqlConnection ConxAdcom = new SqlConnection(datosEmpresa.strConxAdcom))
	//		{
	//			try
	//			{
	//				ConxAdcom.Open();

	//				if (ConxAdcom.State == ConnectionState.Open)
	//				{
	//					// Check AdcDoc table
	//					string query1 = "SELECT Doc_codper FROM AdcDoc WHERE Doc_codper = @Codigo";
	//					using (SqlCommand comm1 = new SqlCommand(query1, ConxAdcom))
	//					{
	//						comm1.Parameters.AddWithValue("@Codigo", codigo);
	//						using (SqlDataReader rs = comm1.ExecuteReader())
	//						{
	//							if (rs.Read())
	//							{
	//								hasMovements = true;
	//							}
	//						}
	//					}

	//					// Only check second table if no movements found in first table
	//					if (!hasMovements)
	//					{
	//						string query2 = "SELECT idempleado FROM rolliq WHERE idempleado = @Codigo";
	//						using (SqlCommand comm2 = new SqlCommand(query2, ConxAdcom))
	//						{
	//							comm2.Parameters.AddWithValue("@Codigo", codigo);
	//							using (SqlDataReader rs = comm2.ExecuteReader())
	//							{
	//								if (rs.Read())
	//								{
	//									hasMovements = true;
	//								}
	//							}
	//						}
	//					}
	//				}
	//			}
	//			catch (Exception ee)
	//			{
	//				MessageBox.Show("Excepción en Mandir_Clmov: " + ee.Message,
	//								"Error",
	//								MessageBoxButtons.OK,
	//								MessageBoxIcon.Error);
	//			}
	//		}

	//		return hasMovements;
	//	}

	//	private void TipoIdent_SelectedIndexChanged(object sender, EventArgs e)
	//	{
	//		// Habilitar el campo de texto solo si se ha seleccionado un tipo de documento
	//		TxtCedulaRuc.Enabled = TipoIdent.SelectedIndex != -1;
	//	}

	//	private void TxtCedulaRuc_KeyPress(object sender, KeyPressEventArgs e)
	//	{
	//		// Validar que solo se ingresen números (excepto para Pasaporte)
	//		if (TipoIdent.SelectedItem.ToString() != "Pasaporte" && !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
	//		{
	//			e.Handled = true;
	//		}
	//	}

	//	private void TxtCedulaRuc_KeyDown(object sender, KeyEventArgs e)
	//	{
	//		//int keyCode = (int)e.KeyCode;
	//		///*int shift = (int)(e.KeyData >> 16);*/ // Equivalent to VB's \ &H10000
	//		//int shift = (int)((int)e.KeyData >> 16);
	//		tipoper = "";
	//		if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(TxtCedulaRuc.Text))
	//		{
	//			SaliendoCodigo();
	//		}
	//	}

	//	private void Cliente_CheckedChanged(object sender, EventArgs e)
	//	{
	//		tabCliente.Parent = Cliente.Checked ? DatosDirectorio : null;
	//	}

	//	private void Proveedor_CheckedChanged(object sender, EventArgs e)
	//	{
	//		tabProveedor.Parent = Proveedor.Checked ? DatosDirectorio : null;
	//	}

	//	private void Empleado_CheckedChanged(object sender, EventArgs e)
	//	{
	//		tabEmpleado.Parent = Empleado.Checked ? DatosDirectorio : null;
	//	}
	}
}
