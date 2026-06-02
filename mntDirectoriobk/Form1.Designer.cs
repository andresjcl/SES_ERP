using Microsoft.VisualBasic.CompilerServices;

namespace mntDirectorio
{
	public partial class Form1
	{
		/// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
		private ComponentModel.IContainer components = default;

		/// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <paramname="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && components is not null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
		private void InitializeComponent()
		{
			var dataGridViewCellStyle31 = new Windows.Forms.DataGridViewCellStyle();
			var dataGridViewCellStyle32 = new Windows.Forms.DataGridViewCellStyle();
			var dataGridViewCellStyle33 = new Windows.Forms.DataGridViewCellStyle();
			var dataGridViewCellStyle34 = new Windows.Forms.DataGridViewCellStyle();
			var dataGridViewCellStyle35 = new Windows.Forms.DataGridViewCellStyle();
			var dataGridViewCellStyle36 = new Windows.Forms.DataGridViewCellStyle();
			var dataGridViewCellStyle37 = new Windows.Forms.DataGridViewCellStyle();
			var dataGridViewCellStyle38 = new Windows.Forms.DataGridViewCellStyle();
			var dataGridViewCellStyle39 = new Windows.Forms.DataGridViewCellStyle();
			var dataGridViewCellStyle40 = new Windows.Forms.DataGridViewCellStyle();
			var resources = new ComponentModel.ComponentResourceManager(typeof(Form1));
			SplitContainer1 = new Windows.Forms.SplitContainer();
			GroupBox3 = new Windows.Forms.GroupBox();
			Asociacion = new Windows.Forms.CheckBox();
			GroupBox2 = new Windows.Forms.GroupBox();
			Directa = new Windows.Forms.CheckBox();
			EsVendedor = new Windows.Forms.CheckBox();
			Empleado = new Windows.Forms.CheckBox();
			Banco = new Windows.Forms.CheckBox();
			Proveedor = new Windows.Forms.CheckBox();
			Cliente = new Windows.Forms.CheckBox();
			GroupBox1 = new Windows.Forms.GroupBox();
			Juridica = new Windows.Forms.RadioButton();
			Natural = new Windows.Forms.RadioButton();
			DatosDirectorio = new Windows.Forms.TabControl();
			tabIdentificación = new Windows.Forms.TabPage();
			GroupBox13 = new Windows.Forms.GroupBox();
			cmbRegionDomicilio = new Windows.Forms.ComboBox();
			cmbCantonDomicilio = new Windows.Forms.ComboBox();
			cmbCiudadDomicilio = new Windows.Forms.ComboBox();
			cmbParroquiaDomicilio = new Windows.Forms.ComboBox();
			cmbProvinciaDomicilio = new Windows.Forms.ComboBox();
			cmbPaisDomicilio = new Windows.Forms.ComboBox();
			txtSector = new Windows.Forms.TextBox();
			Label18 = new Windows.Forms.Label();
			TxtNroDomicilio = new Windows.Forms.TextBox();
			Label12 = new Windows.Forms.Label();
			txtnomDireccion = new Windows.Forms.TextBox();
			Label11 = new Windows.Forms.Label();
			Label88 = new Windows.Forms.Label();
			Label16 = new Windows.Forms.Label();
			Label10 = new Windows.Forms.Label();
			Label9 = new Windows.Forms.Label();
			Label8 = new Windows.Forms.Label();
			Label7 = new Windows.Forms.Label();
			GroupBox5 = new Windows.Forms.GroupBox();
			chkRegimenMicroempresas = new Windows.Forms.CheckBox();
			TxtResolucionAR = new Windows.Forms.TextBox();
			Label82 = new Windows.Forms.Label();
			txtContribuyenteEspecial = new Windows.Forms.TextBox();
			Label83 = new Windows.Forms.Label();
			chkRise = new Windows.Forms.CheckBox();
			chkObligaContabilidad = new Windows.Forms.CheckBox();
			ExoneradoIva = new Windows.Forms.CheckBox();
			Label20 = new Windows.Forms.Label();
			TxtData9 = new Windows.Forms.TextBox();
			Label19 = new Windows.Forms.Label();
			TxtData8 = new Windows.Forms.TextBox();
			TxtData6 = new Windows.Forms.TextBox();
			txtTelefono3 = new Windows.Forms.TextBox();
			Label15 = new Windows.Forms.Label();
			txtTelefono2 = new Windows.Forms.TextBox();
			Label14 = new Windows.Forms.Label();
			txtTelefono1 = new Windows.Forms.TextBox();
			Label13 = new Windows.Forms.Label();
			impresion = new Windows.Forms.TextBox();
			Label5 = new Windows.Forms.Label();
			label17 = new Windows.Forms.Label();
			tabDatosPer = new Windows.Forms.TabPage();
			cmbEspecialidad2 = new Windows.Forms.ComboBox();
			cmbEspecialidad = new Windows.Forms.ComboBox();
			cmbProfesion = new Windows.Forms.ComboBox();
			cmbNacionalidadPersonal = new Windows.Forms.ComboBox();
			cmbTipoSangre = new Windows.Forms.ComboBox();
			Label93 = new Windows.Forms.Label();
			Label89 = new Windows.Forms.Label();
			txtPorcDiscapacidad = new Windows.Forms.TextBox();
			Label91 = new Windows.Forms.Label();
			txtDiscapacidad = new Windows.Forms.TextBox();
			GroupBox12 = new Windows.Forms.GroupBox();
			cmbRegionNace = new Windows.Forms.ComboBox();
			cmbCiudadNace = new Windows.Forms.ComboBox();
			cmbProvinciaNace = new Windows.Forms.ComboBox();
			cmbPaisNace = new Windows.Forms.ComboBox();
			fechanaci = new Windows.Forms.DateTimePicker();
			Label28 = new Windows.Forms.Label();
			Label84 = new Windows.Forms.Label();
			Label85 = new Windows.Forms.Label();
			Label86 = new Windows.Forms.Label();
			Lugarnaci = new Windows.Forms.TextBox();
			Label23 = new Windows.Forms.Label();
			Label22 = new Windows.Forms.Label();
			Label80 = new Windows.Forms.Label();
			Label77 = new Windows.Forms.Label();
			asociadoa = new Windows.Forms.GroupBox();
			CbuscaDir3 = new Windows.Forms.Button();
			LDir3 = new Windows.Forms.TextBox();
			Label31 = new Windows.Forms.Label();
			txtLugTra = new Windows.Forms.TextBox();
			Label30 = new Windows.Forms.Label();
			txtNumTar = new Windows.Forms.TextBox();
			Label29 = new Windows.Forms.Label();
			Label24 = new Windows.Forms.Label();
			txtCodTar = new Windows.Forms.TextBox();
			hobbys = new Windows.Forms.TextBox();
			Label27 = new Windows.Forms.Label();
			txtReferirseComo = new Windows.Forms.ComboBox();
			Label26 = new Windows.Forms.Label();
			Label25 = new Windows.Forms.Label();
			cmbEstadoCivil = new Windows.Forms.ComboBox();
			Label21 = new Windows.Forms.Label();
			GroupBox4 = new Windows.Forms.GroupBox();
			mujer = new Windows.Forms.RadioButton();
			hombre = new Windows.Forms.RadioButton();
			tabCliente = new Windows.Forms.TabPage();
			btnBuscaZonaVentas = new Windows.Forms.Button();
			CBuscador3 = new Windows.Forms.Button();
			txtOperador = new Windows.Forms.Label();
			btnBuscaOperador = new Windows.Forms.Button();
			Label90 = new Windows.Forms.Label();
			Cuenta4 = new Windows.Forms.Label();
			Cuenta0 = new Windows.Forms.Label();
			GroupBox15 = new Windows.Forms.GroupBox();
			btnTransportadora = new Windows.Forms.Button();
			Label41 = new Windows.Forms.Label();
			txtTransportadora = new Windows.Forms.TextBox();
			txtPaisEntrega = new Windows.Forms.Label();
			btnPuertoEntrega = new Windows.Forms.Button();
			Label94 = new Windows.Forms.Label();
			btnPaísEntrega = new Windows.Forms.Button();
			Label95 = new Windows.Forms.Label();
			entregarmer = new Windows.Forms.TextBox();
			txtCobrador = new Windows.Forms.Label();
			txtVendedor = new Windows.Forms.Label();
			txtZonaCobranzas = new Windows.Forms.Label();
			txtZonaVentas = new Windows.Forms.Label();
			txtTipoCliente = new Windows.Forms.Label();
			GroupBox11 = new Windows.Forms.GroupBox();
			txtPrecioVenta = new Windows.Forms.Label();
			txtFormaPago = new Windows.Forms.Label();
			txtLimiteCredito = new Windows.Forms.TextBox();
			Label46 = new Windows.Forms.Label();
			txtDescuentoAsociacion = new Windows.Forms.TextBox();
			Label43 = new Windows.Forms.Label();
			txtPorcDescuento = new Windows.Forms.TextBox();
			Label40 = new Windows.Forms.Label();
			btnFormaPago = new Windows.Forms.Button();
			Label39 = new Windows.Forms.Label();
			btnPrecioVenta = new Windows.Forms.Button();
			Label38 = new Windows.Forms.Label();
			Command5 = new Windows.Forms.Button();
			Label75 = new Windows.Forms.Label();
			Command1 = new Windows.Forms.Button();
			Label45 = new Windows.Forms.Label();
			observacli = new Windows.Forms.TextBox();
			Label44 = new Windows.Forms.Label();
			txtContacto = new Windows.Forms.TextBox();
			Label42 = new Windows.Forms.Label();
			btnBuscaCobrador = new Windows.Forms.Button();
			Label37 = new Windows.Forms.Label();
			btnBuscaZonaCobro = new Windows.Forms.Button();
			Label36 = new Windows.Forms.Label();
			btnBuscaVendedor = new Windows.Forms.Button();
			Label35 = new Windows.Forms.Label();
			Label34 = new Windows.Forms.Label();
			Label33 = new Windows.Forms.Label();
			tabProveedor = new Windows.Forms.TabPage();
			CBuscador8 = new Windows.Forms.Button();
			GroupBox14 = new Windows.Forms.GroupBox();
			chkTerrestre = new Windows.Forms.CheckBox();
			Button6 = new Windows.Forms.Button();
			chkMaritimo = new Windows.Forms.CheckBox();
			chkAereo = new Windows.Forms.CheckBox();
			observacionesprv = new Windows.Forms.TextBox();
			Label52 = new Windows.Forms.Label();
			Lcod8 = new Windows.Forms.Label();
			Cuenta5 = new Windows.Forms.Label();
			Cuenta1 = new Windows.Forms.Label();
			Command6 = new Windows.Forms.Button();
			Label76 = new Windows.Forms.Label();
			Label51 = new Windows.Forms.Label();
			Command2 = new Windows.Forms.Button();
			Label53 = new Windows.Forms.Label();
			GroupBox6 = new Windows.Forms.GroupBox();
			chkRetirarTransporte = new Windows.Forms.CheckBox();
			chkRetirarProveedor = new Windows.Forms.CheckBox();
			chkEntregaDirecccion = new Windows.Forms.CheckBox();
			servicios = new Windows.Forms.TextBox();
			producto = new Windows.Forms.TextBox();
			Label50 = new Windows.Forms.Label();
			incluyetransporte = new Windows.Forms.CheckBox();
			limcreditoprv = new Windows.Forms.TextBox();
			Label49 = new Windows.Forms.Label();
			porcedescuentoprv = new Windows.Forms.TextBox();
			Label48 = new Windows.Forms.Label();
			Label47 = new Windows.Forms.Label();
			tabEmpleado = new Windows.Forms.TabPage();
			cmbSucursalRol = new Windows.Forms.ComboBox();
			cmbDepartamentoRol = new Windows.Forms.ComboBox();
			cmbCargoRol = new Windows.Forms.ComboBox();
			TabDatosEmpleado = new Windows.Forms.TabControl();
			TabPage1 = new Windows.Forms.TabPage();
			mallaDatos = new Windows.Forms.DataGridView();
			Campos1 = new Windows.Forms.DataGridViewTextBoxColumn();
			valorcampo = new Windows.Forms.DataGridViewTextBoxColumn();
			TabPage2 = new Windows.Forms.TabPage();
			mallaConceptos = new Windows.Forms.DataGridView();
			DataGridViewTextBoxColumn1 = new Windows.Forms.DataGridViewTextBoxColumn();
			conceptoSeleccionado = new Windows.Forms.DataGridViewCheckBoxColumn();
			btnCargarCapacitacion = new Windows.Forms.Button();
			fJubilacion = new Windows.Forms.DateTimePicker();
			fsalida = new Windows.Forms.DateTimePicker();
			fingreso = new Windows.Forms.DateTimePicker();
			Label81 = new Windows.Forms.Label();
			Button7 = new Windows.Forms.Button();
			Cuenta3 = new Windows.Forms.Label();
			CodBimetrico = new Windows.Forms.TextBox();
			Cuenta2 = new Windows.Forms.Label();
			GroupBox9 = new Windows.Forms.GroupBox();
			Grupo6 = new Windows.Forms.TextBox();
			Label73 = new Windows.Forms.Label();
			Grupo5 = new Windows.Forms.TextBox();
			Label72 = new Windows.Forms.Label();
			Grupo4 = new Windows.Forms.TextBox();
			Label71 = new Windows.Forms.Label();
			Grupo3 = new Windows.Forms.TextBox();
			Label70 = new Windows.Forms.Label();
			Grupo2 = new Windows.Forms.TextBox();
			Label69 = new Windows.Forms.Label();
			Grupo1 = new Windows.Forms.TextBox();
			Label68 = new Windows.Forms.Label();
			Comctb2 = new Windows.Forms.Button();
			Label63 = new Windows.Forms.Label();
			ComCtb1 = new Windows.Forms.Button();
			Label62 = new Windows.Forms.Label();
			Label61 = new Windows.Forms.Label();
			Label60 = new Windows.Forms.Label();
			GroupBox7 = new Windows.Forms.GroupBox();
			Jubilado = new Windows.Forms.RadioButton();
			Eliminadorol = new Windows.Forms.RadioButton();
			Cesanterol = new Windows.Forms.RadioButton();
			activorol = new Windows.Forms.RadioButton();
			GroupBox8 = new Windows.Forms.GroupBox();
			Lcod11 = new Windows.Forms.TextBox();
			txtHorasJornadaSemanal = new Windows.Forms.TextBox();
			valorsueldo = new Windows.Forms.TextBox();
			Label65 = new Windows.Forms.Label();
			CBuscador11 = new Windows.Forms.Button();
			Label64 = new Windows.Forms.Label();
			RolHoras = new Windows.Forms.RadioButton();
			rolproduccion = new Windows.Forms.RadioButton();
			roldiario = new Windows.Forms.RadioButton();
			rolmensual = new Windows.Forms.RadioButton();
			GroupBox10 = new Windows.Forms.GroupBox();
			CbuscaDir2 = new Windows.Forms.Button();
			txtNomBanco = new Windows.Forms.TextBox();
			Label67 = new Windows.Forms.Label();
			Nroctabancorol = new Windows.Forms.TextBox();
			Label66 = new Windows.Forms.Label();
			ctaahorrosrol = new Windows.Forms.RadioButton();
			ctacorrienterol = new Windows.Forms.RadioButton();
			AcreditaBanco = new Windows.Forms.CheckBox();
			Label92 = new Windows.Forms.Label();
			nivelrol = new Windows.Forms.TextBox();
			Label74 = new Windows.Forms.Label();
			Label87 = new Windows.Forms.Label();
			cmbCentroCostoRol = new Windows.Forms.ComboBox();
			cmbModuloRol = new Windows.Forms.ComboBox();
			cmbSeccionRol = new Windows.Forms.ComboBox();
			Label58 = new Windows.Forms.Label();
			Label55 = new Windows.Forms.Label();
			Label59 = new Windows.Forms.Label();
			Label56 = new Windows.Forms.Label();
			Label57 = new Windows.Forms.Label();
			Label54 = new Windows.Forms.Label();
			tabFamiliares = new Windows.Forms.TabPage();
			malla = new Windows.Forms.DataGridView();
			Nro = new Windows.Forms.DataGridViewTextBoxColumn();
			CedulaId = new Windows.Forms.DataGridViewTextBoxColumn();
			Nombres = new Windows.Forms.DataGridViewTextBoxColumn();
			Parentesco = new Windows.Forms.DataGridViewComboBoxColumn();
			FechaNacim = new Windows.Forms.DataGridViewTextBoxColumn();
			Sexo1 = new Windows.Forms.DataGridViewComboBoxColumn();
			EstadoCivil = new Windows.Forms.DataGridViewComboBoxColumn();
			Direccion = new Windows.Forms.DataGridViewTextBoxColumn();
			Teléfono_1 = new Windows.Forms.DataGridViewTextBoxColumn();
			Teléfono_2 = new Windows.Forms.DataGridViewTextBoxColumn();
			Ocupación = new Windows.Forms.DataGridViewTextBoxColumn();
			Depend = new Windows.Forms.DataGridViewComboBoxColumn();
			Minusv = new Windows.Forms.DataGridViewComboBoxColumn();
			tabContactos = new Windows.Forms.TabPage();
			MallaCtco = new Windows.Forms.DataGridView();
			TipoContacto = new Windows.Forms.DataGridViewTextBoxColumn();
			Nombrecontacto = new Windows.Forms.DataGridViewTextBoxColumn();
			Cargo = new Windows.Forms.DataGridViewTextBoxColumn();
			NroExtensión = new Windows.Forms.DataGridViewTextBoxColumn();
			NroTlfCelular = new Windows.Forms.DataGridViewTextBoxColumn();
			NroTlfDirecto = new Windows.Forms.DataGridViewTextBoxColumn();
			FecNacimto = new Windows.Forms.DataGridViewTextBoxColumn();
			Actividades = new Windows.Forms.DataGridViewTextBoxColumn();
			Preferencias = new Windows.Forms.DataGridViewTextBoxColumn();
			Observaciones = new Windows.Forms.DataGridViewTextBoxColumn();
			tabAlias = new Windows.Forms.TabPage();
			MallaAlias = new Windows.Forms.DataGridView();
			NombreAliasSucursal = new Windows.Forms.DataGridViewTextBoxColumn();
			DirecciónAlterna = new Windows.Forms.DataGridViewTextBoxColumn();
			Teléfono1 = new Windows.Forms.DataGridViewTextBoxColumn();
			Teléfono2 = new Windows.Forms.DataGridViewTextBoxColumn();
			IdSri = new Windows.Forms.DataGridViewTextBoxColumn();
			Observaciones1 = new Windows.Forms.DataGridViewTextBoxColumn();
			Panel1 = new Windows.Forms.Panel();
			Apellidos = new Windows.Forms.TextBox();
			txtHistoriaclinica = new Windows.Forms.TextBox();
			Label1 = new Windows.Forms.Label();
			Label79 = new Windows.Forms.Label();
			Codigo = new Windows.Forms.TextBox();
			Label2 = new Windows.Forms.Label();
			TipoIdent = new Windows.Forms.ComboBox();
			Label3 = new Windows.Forms.Label();
			TxtCedulaRuc = new Windows.Forms.TextBox();
			Label4 = new Windows.Forms.Label();
			TxtNombres = new Windows.Forms.TextBox();
			Label32 = new Windows.Forms.Label();
			ToolStrip1 = new Windows.Forms.ToolStrip();
			btnNuevo = new Windows.Forms.ToolStripButton();
			btnAbrir = new Windows.Forms.ToolStripButton();
			btnCerrar = new Windows.Forms.ToolStripButton();
			btnGuardar = new Windows.Forms.ToolStripButton();
			btnEliminar = new Windows.Forms.ToolStripButton();
			btnSalir = new Windows.Forms.ToolStripButton();
			Label78 = new Windows.Forms.Label();
			Button1 = new Windows.Forms.Button();
			Button2 = new Windows.Forms.Button();
			Button3 = new Windows.Forms.Button();
			txtGrupo1 = new Windows.Forms.Label();
			txtGrupo3 = new Windows.Forms.Label();
			txtGrupo2 = new Windows.Forms.Label();
			foto = new Windows.Forms.PictureBox();
			((ComponentModel.ISupportInitialize)SplitContainer1).BeginInit();
			SplitContainer1.Panel1.SuspendLayout();
			SplitContainer1.Panel2.SuspendLayout();
			SplitContainer1.SuspendLayout();
			GroupBox3.SuspendLayout();
			GroupBox2.SuspendLayout();
			GroupBox1.SuspendLayout();
			DatosDirectorio.SuspendLayout();
			tabIdentificación.SuspendLayout();
			GroupBox13.SuspendLayout();
			GroupBox5.SuspendLayout();
			tabDatosPer.SuspendLayout();
			GroupBox12.SuspendLayout();
			asociadoa.SuspendLayout();
			GroupBox4.SuspendLayout();
			tabCliente.SuspendLayout();
			GroupBox15.SuspendLayout();
			GroupBox11.SuspendLayout();
			tabProveedor.SuspendLayout();
			GroupBox14.SuspendLayout();
			GroupBox6.SuspendLayout();
			tabEmpleado.SuspendLayout();
			TabDatosEmpleado.SuspendLayout();
			TabPage1.SuspendLayout();
			((ComponentModel.ISupportInitialize)mallaDatos).BeginInit();
			TabPage2.SuspendLayout();
			((ComponentModel.ISupportInitialize)mallaConceptos).BeginInit();
			GroupBox9.SuspendLayout();
			GroupBox7.SuspendLayout();
			GroupBox8.SuspendLayout();
			GroupBox10.SuspendLayout();
			tabFamiliares.SuspendLayout();
			((ComponentModel.ISupportInitialize)malla).BeginInit();
			tabContactos.SuspendLayout();
			((ComponentModel.ISupportInitialize)MallaCtco).BeginInit();
			tabAlias.SuspendLayout();
			((ComponentModel.ISupportInitialize)MallaAlias).BeginInit();
			Panel1.SuspendLayout();
			ToolStrip1.SuspendLayout();
			((ComponentModel.ISupportInitialize)foto).BeginInit();
			SuspendLayout();
			// 
			// SplitContainer1
			// 
			SplitContainer1.Dock = Windows.Forms.DockStyle.Fill;
			SplitContainer1.Location = new Drawing.Point(0, 54);
			SplitContainer1.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			SplitContainer1.Name = "SplitContainer1";
			// 
			// SplitContainer1.Panel1
			// 
			SplitContainer1.Panel1.BackColor = Drawing.Color.DimGray;
			SplitContainer1.Panel1.Controls.Add(GroupBox3);
			SplitContainer1.Panel1.Controls.Add(GroupBox2);
			// 
			// SplitContainer1.Panel2
			// 
			SplitContainer1.Panel2.Controls.Add(DatosDirectorio);
			SplitContainer1.Panel2.Controls.Add(Panel1);
			SplitContainer1.Size = new Drawing.Size(1228, 780);
			SplitContainer1.SplitterDistance = 156;
			SplitContainer1.SplitterWidth = 6;
			SplitContainer1.TabIndex = 5;
			// 
			// GroupBox3
			// 
			GroupBox3.BackColor = Drawing.Color.Transparent;
			GroupBox3.Controls.Add(Asociacion);
			GroupBox3.FlatStyle = Windows.Forms.FlatStyle.Flat;
			GroupBox3.ForeColor = Drawing.Color.White;
			GroupBox3.Location = new Drawing.Point(4, 420);
			GroupBox3.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			GroupBox3.Name = "GroupBox3";
			GroupBox3.Padding = new Windows.Forms.Padding(4, 5, 4, 5);
			GroupBox3.Size = new Drawing.Size(180, 82);
			GroupBox3.TabIndex = 2;
			GroupBox3.TabStop = false;
			GroupBox3.Text = "Es:";
			GroupBox3.Visible = false;
			// 
			// Asociacion
			// 
			Asociacion.AutoSize = true;
			Asociacion.ForeColor = Drawing.Color.White;
			Asociacion.Location = new Drawing.Point(22, 31);
			Asociacion.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			Asociacion.Name = "Asociacion";
			Asociacion.Size = new Drawing.Size(112, 24);
			Asociacion.TabIndex = 0;
			Asociacion.Text = "Asociación";
			Asociacion.UseVisualStyleBackColor = true;
			// 
			// GroupBox2
			// 
			GroupBox2.BackColor = Drawing.Color.Transparent;
			GroupBox2.Controls.Add(Directa);
			GroupBox2.Controls.Add(EsVendedor);
			GroupBox2.Controls.Add(Empleado);
			GroupBox2.Controls.Add(Banco);
			GroupBox2.Controls.Add(Proveedor);
			GroupBox2.Controls.Add(Cliente);
			GroupBox2.FlatStyle = Windows.Forms.FlatStyle.Flat;
			GroupBox2.ForeColor = Drawing.Color.White;
			GroupBox2.Location = new Drawing.Point(3, 6);
			GroupBox2.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			GroupBox2.Name = "GroupBox2";
			GroupBox2.Padding = new Windows.Forms.Padding(4, 5, 4, 5);
			GroupBox2.Size = new Drawing.Size(183, 289);
			GroupBox2.TabIndex = 1;
			GroupBox2.TabStop = false;
			GroupBox2.Text = "Relación:";
			// 
			// Directa
			// 
			Directa.AutoSize = true;
			Directa.Font = new Drawing.Font("Microsoft Sans Serif", 9.75f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Directa.ForeColor = Drawing.Color.White;
			Directa.Location = new Drawing.Point(22, 209);
			Directa.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			Directa.Name = "Directa";
			Directa.Size = new Drawing.Size(148, 29);
			Directa.TabIndex = 5;
			Directa.Text = "PartRelacion";
			Directa.UseVisualStyleBackColor = true;
			// 
			// EsVendedor
			// 
			EsVendedor.AutoSize = true;
			EsVendedor.Font = new Drawing.Font("Microsoft Sans Serif", 9.75f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			EsVendedor.ForeColor = Drawing.Color.White;
			EsVendedor.Location = new Drawing.Point(22, 175);
			EsVendedor.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			EsVendedor.Name = "EsVendedor";
			EsVendedor.Size = new Drawing.Size(124, 29);
			EsVendedor.TabIndex = 4;
			EsVendedor.Text = "Vendedor";
			EsVendedor.UseVisualStyleBackColor = true;
			// 
			// Empleado
			// 
			Empleado.AutoSize = true;
			Empleado.Font = new Drawing.Font("Microsoft Sans Serif", 9.75f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Empleado.ForeColor = Drawing.Color.White;
			Empleado.Location = new Drawing.Point(22, 140);
			Empleado.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			Empleado.Name = "Empleado";
			Empleado.Size = new Drawing.Size(126, 29);
			Empleado.TabIndex = 3;
			Empleado.Text = "Empleado";
			Empleado.UseVisualStyleBackColor = true;
			// 
			// Banco
			// 
			Banco.AutoSize = true;
			Banco.Font = new Drawing.Font("Microsoft Sans Serif", 9.75f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Banco.ForeColor = Drawing.Color.White;
			Banco.Location = new Drawing.Point(22, 105);
			Banco.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			Banco.Name = "Banco";
			Banco.Size = new Drawing.Size(129, 29);
			Banco.TabIndex = 2;
			Banco.Text = "&Financiera";
			Banco.UseVisualStyleBackColor = true;
			// 
			// Proveedor
			// 
			Proveedor.AutoSize = true;
			Proveedor.Font = new Drawing.Font("Microsoft Sans Serif", 9.75f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Proveedor.ForeColor = Drawing.Color.White;
			Proveedor.Location = new Drawing.Point(22, 69);
			Proveedor.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			Proveedor.Name = "Proveedor";
			Proveedor.Size = new Drawing.Size(128, 29);
			Proveedor.TabIndex = 1;
			Proveedor.Text = "Pro&veedor";
			Proveedor.UseVisualStyleBackColor = true;
			// 
			// Cliente
			// 
			Cliente.AutoSize = true;
			Cliente.Font = new Drawing.Font("Microsoft Sans Serif", 9.75f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Cliente.ForeColor = Drawing.Color.White;
			Cliente.Location = new Drawing.Point(22, 34);
			Cliente.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			Cliente.Name = "Cliente";
			Cliente.Size = new Drawing.Size(99, 29);
			Cliente.TabIndex = 0;
			Cliente.Text = "&Cliente";
			Cliente.UseVisualStyleBackColor = true;
			// 
			// GroupBox1
			// 
			GroupBox1.BackColor = Drawing.Color.Transparent;
			GroupBox1.Controls.Add(Juridica);
			GroupBox1.Controls.Add(Natural);
			GroupBox1.FlatStyle = Windows.Forms.FlatStyle.Flat;
			GroupBox1.ForeColor = Drawing.Color.White;
			GroupBox1.Location = new Drawing.Point(882, 301);
			GroupBox1.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			GroupBox1.Name = "GroupBox1";
			GroupBox1.Padding = new Windows.Forms.Padding(4, 5, 4, 5);
			GroupBox1.Size = new Drawing.Size(180, 106);
			GroupBox1.TabIndex = 0;
			GroupBox1.TabStop = false;
			GroupBox1.Text = "Registro de:";
			GroupBox1.Visible = false;
			// 
			// Juridica
			// 
			Juridica.AutoSize = true;
			Juridica.Font = new Drawing.Font("Microsoft Sans Serif", 9.75f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Juridica.ForeColor = Drawing.Color.White;
			Juridica.Location = new Drawing.Point(22, 68);
			Juridica.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			Juridica.Name = "Juridica";
			Juridica.Size = new Drawing.Size(115, 29);
			Juridica.TabIndex = 1;
			Juridica.Text = "Empresa";
			Juridica.UseVisualStyleBackColor = true;
			// 
			// Natural
			// 
			Natural.AutoSize = true;
			Natural.Checked = true;
			Natural.Font = new Drawing.Font("Microsoft Sans Serif", 9.75f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Natural.ForeColor = Drawing.Color.White;
			Natural.Location = new Drawing.Point(22, 38);
			Natural.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			Natural.Name = "Natural";
			Natural.Size = new Drawing.Size(110, 29);
			Natural.TabIndex = 0;
			Natural.TabStop = true;
			Natural.Text = "Persona";
			Natural.UseVisualStyleBackColor = true;
			// 
			// DatosDirectorio
			// 
			DatosDirectorio.Appearance = Windows.Forms.TabAppearance.FlatButtons;
			DatosDirectorio.Controls.Add(tabIdentificación);
			DatosDirectorio.Controls.Add(tabDatosPer);
			DatosDirectorio.Controls.Add(tabCliente);
			DatosDirectorio.Controls.Add(tabProveedor);
			DatosDirectorio.Controls.Add(tabEmpleado);
			DatosDirectorio.Controls.Add(tabFamiliares);
			DatosDirectorio.Controls.Add(tabContactos);
			DatosDirectorio.Controls.Add(tabAlias);
			DatosDirectorio.Dock = Windows.Forms.DockStyle.Fill;
			DatosDirectorio.Font = new Drawing.Font("Microsoft Sans Serif", 9.75f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			DatosDirectorio.Location = new Drawing.Point(0, 75);
			DatosDirectorio.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			DatosDirectorio.Name = "DatosDirectorio";
			DatosDirectorio.SelectedIndex = 0;
			DatosDirectorio.Size = new Drawing.Size(1066, 705);
			DatosDirectorio.TabIndex = 0;
			// 
			// tabIdentificación
			// 
			tabIdentificación.BackColor = Drawing.Color.Gray;
			tabIdentificación.Controls.Add(Apellidos);
			tabIdentificación.Controls.Add(txtGrupo2);
			tabIdentificación.Controls.Add(GroupBox13);
			tabIdentificación.Controls.Add(txtGrupo3);
			tabIdentificación.Controls.Add(GroupBox1);
			tabIdentificación.Controls.Add(txtGrupo1);
			tabIdentificación.Controls.Add(GroupBox5);
			tabIdentificación.Controls.Add(Button3);
			tabIdentificación.Controls.Add(Button2);
			tabIdentificación.Controls.Add(Button1);
			tabIdentificación.Controls.Add(Label32);
			tabIdentificación.Controls.Add(TxtNombres);
			tabIdentificación.Controls.Add(Label4);
			tabIdentificación.Controls.Add(Label78);
			tabIdentificación.Controls.Add(Label20);
			tabIdentificación.Controls.Add(foto);
			tabIdentificación.Controls.Add(TxtData9);
			tabIdentificación.Controls.Add(Label19);
			tabIdentificación.Controls.Add(TxtData8);
			tabIdentificación.Controls.Add(TxtData6);
			tabIdentificación.Controls.Add(txtTelefono3);
			tabIdentificación.Controls.Add(Label15);
			tabIdentificación.Controls.Add(txtTelefono2);
			tabIdentificación.Controls.Add(Label14);
			tabIdentificación.Controls.Add(txtTelefono1);
			tabIdentificación.Controls.Add(Label13);
			tabIdentificación.Controls.Add(label17);
			tabIdentificación.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			tabIdentificación.ForeColor = Drawing.Color.White;
			tabIdentificación.Location = new Drawing.Point(4, 37);
			tabIdentificación.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			tabIdentificación.Name = "tabIdentificación";
			tabIdentificación.Size = new Drawing.Size(1058, 664);
			tabIdentificación.TabIndex = 7;
			tabIdentificación.Text = "Identificación";
			// 
			// GroupBox13
			// 
			GroupBox13.Controls.Add(cmbRegionDomicilio);
			GroupBox13.Controls.Add(cmbCantonDomicilio);
			GroupBox13.Controls.Add(cmbCiudadDomicilio);
			GroupBox13.Controls.Add(cmbParroquiaDomicilio);
			GroupBox13.Controls.Add(cmbProvinciaDomicilio);
			GroupBox13.Controls.Add(cmbPaisDomicilio);
			GroupBox13.Controls.Add(txtSector);
			GroupBox13.Controls.Add(Label18);
			GroupBox13.Controls.Add(TxtNroDomicilio);
			GroupBox13.Controls.Add(Label12);
			GroupBox13.Controls.Add(txtnomDireccion);
			GroupBox13.Controls.Add(Label11);
			GroupBox13.Controls.Add(Label88);
			GroupBox13.Controls.Add(Label16);
			GroupBox13.Controls.Add(Label10);
			GroupBox13.Controls.Add(Label9);
			GroupBox13.Controls.Add(Label8);
			GroupBox13.Controls.Add(Label7);
			GroupBox13.ForeColor = Drawing.Color.Black;
			GroupBox13.Location = new Drawing.Point(16, 164);
			GroupBox13.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			GroupBox13.Name = "GroupBox13";
			GroupBox13.Padding = new Windows.Forms.Padding(4, 5, 4, 5);
			GroupBox13.Size = new Drawing.Size(820, 234);
			GroupBox13.TabIndex = 101;
			GroupBox13.TabStop = false;
			GroupBox13.Text = "Ubicación domiciliaria ";
			// 
			// cmbRegionDomicilio
			// 
			cmbRegionDomicilio.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Append;
			cmbRegionDomicilio.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems;
			cmbRegionDomicilio.FlatStyle = Windows.Forms.FlatStyle.Flat;
			cmbRegionDomicilio.ForeColor = Drawing.Color.Black;
			cmbRegionDomicilio.FormattingEnabled = true;
			cmbRegionDomicilio.Location = new Drawing.Point(507, 111);
			cmbRegionDomicilio.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			cmbRegionDomicilio.Name = "cmbRegionDomicilio";
			cmbRegionDomicilio.Size = new Drawing.Size(301, 28);
			cmbRegionDomicilio.TabIndex = 115;
			// 
			// cmbCantonDomicilio
			// 
			cmbCantonDomicilio.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Append;
			cmbCantonDomicilio.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems;
			cmbCantonDomicilio.FlatStyle = Windows.Forms.FlatStyle.Flat;
			cmbCantonDomicilio.ForeColor = Drawing.Color.Black;
			cmbCantonDomicilio.FormattingEnabled = true;
			cmbCantonDomicilio.Items.AddRange(new object[] { "Soltero", "Unión Libre", "Casado", "Divorciado", "Viudo" });
			cmbCantonDomicilio.Location = new Drawing.Point(96, 66);
			cmbCantonDomicilio.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			cmbCantonDomicilio.Name = "cmbCantonDomicilio";
			cmbCantonDomicilio.Size = new Drawing.Size(301, 28);
			cmbCantonDomicilio.TabIndex = 114;
			// 
			// cmbCiudadDomicilio
			// 
			cmbCiudadDomicilio.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Append;
			cmbCiudadDomicilio.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems;
			cmbCiudadDomicilio.FlatStyle = Windows.Forms.FlatStyle.Flat;
			cmbCiudadDomicilio.ForeColor = Drawing.Color.Black;
			cmbCiudadDomicilio.FormattingEnabled = true;
			cmbCiudadDomicilio.Items.AddRange(new object[] { "Soltero", "Unión Libre", "Casado", "Divorciado", "Viudo" });
			cmbCiudadDomicilio.Location = new Drawing.Point(94, 105);
			cmbCiudadDomicilio.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			cmbCiudadDomicilio.Name = "cmbCiudadDomicilio";
			cmbCiudadDomicilio.Size = new Drawing.Size(301, 28);
			cmbCiudadDomicilio.TabIndex = 113;
			// 
			// cmbParroquiaDomicilio
			// 
			cmbParroquiaDomicilio.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Append;
			cmbParroquiaDomicilio.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems;
			cmbParroquiaDomicilio.FlatStyle = Windows.Forms.FlatStyle.Flat;
			cmbParroquiaDomicilio.ForeColor = Drawing.Color.Black;
			cmbParroquiaDomicilio.FormattingEnabled = true;
			cmbParroquiaDomicilio.Location = new Drawing.Point(507, 70);
			cmbParroquiaDomicilio.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			cmbParroquiaDomicilio.Name = "cmbParroquiaDomicilio";
			cmbParroquiaDomicilio.Size = new Drawing.Size(301, 28);
			cmbParroquiaDomicilio.TabIndex = 112;
			// 
			// cmbProvinciaDomicilio
			// 
			cmbProvinciaDomicilio.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Append;
			cmbProvinciaDomicilio.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems;
			cmbProvinciaDomicilio.FlatStyle = Windows.Forms.FlatStyle.Flat;
			cmbProvinciaDomicilio.ForeColor = Drawing.Color.Black;
			cmbProvinciaDomicilio.FormattingEnabled = true;
			cmbProvinciaDomicilio.Items.AddRange(new object[] { "Soltero", "Unión Libre", "Casado", "Divorciado", "Viudo" });
			cmbProvinciaDomicilio.Location = new Drawing.Point(507, 26);
			cmbProvinciaDomicilio.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			cmbProvinciaDomicilio.Name = "cmbProvinciaDomicilio";
			cmbProvinciaDomicilio.Size = new Drawing.Size(301, 28);
			cmbProvinciaDomicilio.TabIndex = 111;
			// 
			// cmbPaisDomicilio
			// 
			cmbPaisDomicilio.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Append;
			cmbPaisDomicilio.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems;
			cmbPaisDomicilio.FlatStyle = Windows.Forms.FlatStyle.Flat;
			cmbPaisDomicilio.ForeColor = Drawing.Color.Black;
			cmbPaisDomicilio.FormattingEnabled = true;
			cmbPaisDomicilio.Items.AddRange(new object[] { "Soltero", "Unión Libre", "Casado", "Divorciado", "Viudo" });
			cmbPaisDomicilio.Location = new Drawing.Point(94, 26);
			cmbPaisDomicilio.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			cmbPaisDomicilio.Name = "cmbPaisDomicilio";
			cmbPaisDomicilio.Size = new Drawing.Size(301, 28);
			cmbPaisDomicilio.TabIndex = 110;
			// 
			// txtSector
			// 
			txtSector.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			txtSector.ForeColor = Drawing.Color.Black;
			txtSector.Location = new Drawing.Point(91, 191);
			txtSector.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			txtSector.Name = "txtSector";
			txtSector.Size = new Drawing.Size(360, 26);
			txtSector.TabIndex = 99;
			// 
			// Label18
			// 
			Label18.AutoSize = true;
			Label18.BackColor = Drawing.Color.Transparent;
			Label18.ForeColor = Drawing.Color.White;
			Label18.Location = new Drawing.Point(32, 195);
			Label18.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label18.Name = "Label18";
			Label18.Size = new Drawing.Size(58, 20);
			Label18.TabIndex = 100;
			Label18.Text = "Sector";
			// 
			// TxtNroDomicilio
			// 
			TxtNroDomicilio.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			TxtNroDomicilio.ForeColor = Drawing.Color.Black;
			TxtNroDomicilio.Location = new Drawing.Point(516, 152);
			TxtNroDomicilio.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			TxtNroDomicilio.Name = "TxtNroDomicilio";
			TxtNroDomicilio.Size = new Drawing.Size(134, 26);
			TxtNroDomicilio.TabIndex = 13;
			// 
			// Label12
			// 
			Label12.AutoSize = true;
			Label12.BackColor = Drawing.Color.Transparent;
			Label12.ForeColor = Drawing.Color.White;
			Label12.Location = new Drawing.Point(474, 159);
			Label12.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label12.Name = "Label12";
			Label12.Size = new Drawing.Size(34, 20);
			Label12.TabIndex = 66;
			Label12.Text = "No.";
			// 
			// txtnomDireccion
			// 
			txtnomDireccion.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			txtnomDireccion.ForeColor = Drawing.Color.Black;
			txtnomDireccion.Location = new Drawing.Point(93, 152);
			txtnomDireccion.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			txtnomDireccion.Name = "txtnomDireccion";
			txtnomDireccion.Size = new Drawing.Size(359, 26);
			txtnomDireccion.TabIndex = 12;
			// 
			// Label11
			// 
			Label11.AutoSize = true;
			Label11.BackColor = Drawing.Color.Transparent;
			Label11.ForeColor = Drawing.Color.White;
			Label11.Location = new Drawing.Point(12, 158);
			Label11.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label11.Name = "Label11";
			Label11.Size = new Drawing.Size(81, 20);
			Label11.TabIndex = 64;
			Label11.Text = "Dirección";
			// 
			// Label88
			// 
			Label88.AutoSize = true;
			Label88.BackColor = Drawing.Color.Transparent;
			Label88.ForeColor = Drawing.Color.White;
			Label88.Location = new Drawing.Point(442, 118);
			Label88.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label88.Name = "Label88";
			Label88.Size = new Drawing.Size(61, 20);
			Label88.TabIndex = 102;
			Label88.Text = "Región";
			// 
			// Label16
			// 
			Label16.AutoSize = true;
			Label16.BackColor = Drawing.Color.Transparent;
			Label16.ForeColor = Drawing.Color.White;
			Label16.Location = new Drawing.Point(424, 76);
			Label16.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label16.Name = "Label16";
			Label16.Size = new Drawing.Size(81, 20);
			Label16.TabIndex = 74;
			Label16.Text = "Parroquia";
			// 
			// Label10
			// 
			Label10.AutoSize = true;
			Label10.BackColor = Drawing.Color.Transparent;
			Label10.ForeColor = Drawing.Color.White;
			Label10.Location = new Drawing.Point(30, 72);
			Label10.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label10.Name = "Label10";
			Label10.Size = new Drawing.Size(62, 20);
			Label10.TabIndex = 62;
			Label10.Text = "Canton";
			// 
			// Label9
			// 
			Label9.AutoSize = true;
			Label9.BackColor = Drawing.Color.Transparent;
			Label9.ForeColor = Drawing.Color.White;
			Label9.Location = new Drawing.Point(27, 115);
			Label9.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label9.Name = "Label9";
			Label9.Size = new Drawing.Size(61, 20);
			Label9.TabIndex = 59;
			Label9.Text = "Ciudad";
			// 
			// Label8
			// 
			Label8.AutoSize = true;
			Label8.BackColor = Drawing.Color.Transparent;
			Label8.ForeColor = Drawing.Color.White;
			Label8.Location = new Drawing.Point(428, 32);
			Label8.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label8.Name = "Label8";
			Label8.Size = new Drawing.Size(78, 20);
			Label8.TabIndex = 56;
			Label8.Text = "Provincia";
			// 
			// Label7
			// 
			Label7.AutoSize = true;
			Label7.BackColor = Drawing.Color.Transparent;
			Label7.ForeColor = Drawing.Color.White;
			Label7.Location = new Drawing.Point(45, 32);
			Label7.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label7.Name = "Label7";
			Label7.Size = new Drawing.Size(42, 20);
			Label7.TabIndex = 53;
			Label7.Text = "País";
			// 
			// GroupBox5
			// 
			GroupBox5.Controls.Add(chkRegimenMicroempresas);
			GroupBox5.Controls.Add(TxtResolucionAR);
			GroupBox5.Controls.Add(Label82);
			GroupBox5.Controls.Add(txtContribuyenteEspecial);
			GroupBox5.Controls.Add(Label83);
			GroupBox5.Controls.Add(chkRise);
			GroupBox5.Controls.Add(chkObligaContabilidad);
			GroupBox5.Controls.Add(ExoneradoIva);
			GroupBox5.ForeColor = Drawing.Color.Black;
			GroupBox5.Location = new Drawing.Point(16, 408);
			GroupBox5.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			GroupBox5.Name = "GroupBox5";
			GroupBox5.Padding = new Windows.Forms.Padding(4, 5, 4, 5);
			GroupBox5.Size = new Drawing.Size(820, 171);
			GroupBox5.TabIndex = 98;
			GroupBox5.TabStop = false;
			GroupBox5.Text = "Características fiscales";
			GroupBox5.Visible = false;
			// 
			// chkRegimenMicroempresas
			// 
			chkRegimenMicroempresas.AutoSize = true;
			chkRegimenMicroempresas.BackColor = Drawing.Color.Transparent;
			chkRegimenMicroempresas.ForeColor = Drawing.Color.White;
			chkRegimenMicroempresas.Location = new Drawing.Point(426, 69);
			chkRegimenMicroempresas.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			chkRegimenMicroempresas.Name = "chkRegimenMicroempresas";
			chkRegimenMicroempresas.Size = new Drawing.Size(315, 24);
			chkRegimenMicroempresas.TabIndex = 33;
			chkRegimenMicroempresas.Text = "Pertenece al régimen microempresas";
			chkRegimenMicroempresas.UseVisualStyleBackColor = false;
			// 
			// TxtResolucionAR
			// 
			TxtResolucionAR.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			TxtResolucionAR.ForeColor = Drawing.Color.Black;
			TxtResolucionAR.Location = new Drawing.Point(375, 125);
			TxtResolucionAR.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			TxtResolucionAR.Name = "TxtResolucionAR";
			TxtResolucionAR.Size = new Drawing.Size(265, 26);
			TxtResolucionAR.TabIndex = 32;
			// 
			// Label82
			// 
			Label82.AutoSize = true;
			Label82.BackColor = Drawing.Color.Transparent;
			Label82.ForeColor = Drawing.Color.White;
			Label82.Location = new Drawing.Point(370, 106);
			Label82.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label82.Name = "Label82";
			Label82.Size = new Drawing.Size(275, 20);
			Label82.TabIndex = 31;
			Label82.Text = "Nro. Resolución Agente Retención :";
			// 
			// txtContribuyenteEspecial
			// 
			txtContribuyenteEspecial.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			txtContribuyenteEspecial.ForeColor = Drawing.Color.Black;
			txtContribuyenteEspecial.Location = new Drawing.Point(22, 125);
			txtContribuyenteEspecial.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			txtContribuyenteEspecial.Name = "txtContribuyenteEspecial";
			txtContribuyenteEspecial.Size = new Drawing.Size(242, 26);
			txtContribuyenteEspecial.TabIndex = 30;
			// 
			// Label83
			// 
			Label83.AutoSize = true;
			Label83.BackColor = Drawing.Color.Transparent;
			Label83.ForeColor = Drawing.Color.White;
			Label83.Location = new Drawing.Point(22, 105);
			Label83.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label83.Name = "Label83";
			Label83.Size = new Drawing.Size(208, 20);
			Label83.TabIndex = 29;
			Label83.Text = "NroContribuyenteEspecial:";
			// 
			// chkRise
			// 
			chkRise.AutoSize = true;
			chkRise.BackColor = Drawing.Color.Transparent;
			chkRise.ForeColor = Drawing.Color.White;
			chkRise.Location = new Drawing.Point(27, 69);
			chkRise.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			chkRise.Name = "chkRise";
			chkRise.Size = new Drawing.Size(368, 24);
			chkRise.TabIndex = 5;
			chkRise.Text = "Pertenece al régimen impositivo simplificado";
			chkRise.UseVisualStyleBackColor = false;
			// 
			// chkObligaContabilidad
			// 
			chkObligaContabilidad.AutoSize = true;
			chkObligaContabilidad.BackColor = Drawing.Color.Transparent;
			chkObligaContabilidad.ForeColor = Drawing.Color.White;
			chkObligaContabilidad.Location = new Drawing.Point(426, 34);
			chkObligaContabilidad.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			chkObligaContabilidad.Name = "chkObligaContabilidad";
			chkObligaContabilidad.Size = new Drawing.Size(254, 24);
			chkObligaContabilidad.TabIndex = 4;
			chkObligaContabilidad.Text = "Obligado a llevar contabilidad";
			chkObligaContabilidad.UseVisualStyleBackColor = false;
			// 
			// ExoneradoIva
			// 
			ExoneradoIva.AutoSize = true;
			ExoneradoIva.BackColor = Drawing.Color.Transparent;
			ExoneradoIva.ForeColor = Drawing.Color.White;
			ExoneradoIva.Location = new Drawing.Point(28, 34);
			ExoneradoIva.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			ExoneradoIva.Name = "ExoneradoIva";
			ExoneradoIva.Size = new Drawing.Size(240, 24);
			ExoneradoIva.TabIndex = 3;
			ExoneradoIva.Text = "Exonerado del pago del IVA";
			ExoneradoIva.UseVisualStyleBackColor = false;
			// 
			// Label20
			// 
			Label20.AutoSize = true;
			Label20.BackColor = Drawing.Color.Transparent;
			Label20.ForeColor = Drawing.Color.White;
			Label20.Location = new Drawing.Point(12, 60);
			Label20.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label20.Name = "Label20";
			Label20.Size = new Drawing.Size(147, 20);
			Label20.TabIndex = 83;
			Label20.Text = "Correo electrónico";
			// 
			// TxtData9
			// 
			TxtData9.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			TxtData9.Location = new Drawing.Point(112, 121);
			TxtData9.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			TxtData9.Name = "TxtData9";
			TxtData9.Size = new Drawing.Size(581, 26);
			TxtData9.TabIndex = 20;
			// 
			// Label19
			// 
			Label19.AutoSize = true;
			Label19.BackColor = Drawing.Color.Transparent;
			Label19.ForeColor = Drawing.Color.White;
			Label19.Location = new Drawing.Point(12, 126);
			Label19.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label19.Name = "Label19";
			Label19.Size = new Drawing.Size(99, 20);
			Label19.TabIndex = 80;
			Label19.Text = "Página Web";
			// 
			// TxtData8
			// 
			TxtData8.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			TxtData8.Location = new Drawing.Point(174, 51);
			TxtData8.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			TxtData8.Name = "TxtData8";
			TxtData8.Size = new Drawing.Size(653, 26);
			TxtData8.TabIndex = 19;
			// 
			// TxtData6
			// 
			TxtData6.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			TxtData6.Location = new Drawing.Point(174, 86);
			TxtData6.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			TxtData6.Name = "TxtData6";
			TxtData6.Size = new Drawing.Size(652, 26);
			TxtData6.TabIndex = 18;
			// 
			// txtTelefono3
			// 
			txtTelefono3.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			txtTelefono3.Location = new Drawing.Point(486, 17);
			txtTelefono3.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			txtTelefono3.Name = "txtTelefono3";
			txtTelefono3.Size = new Drawing.Size(171, 26);
			txtTelefono3.TabIndex = 16;
			// 
			// Label15
			// 
			Label15.AutoSize = true;
			Label15.BackColor = Drawing.Color.Transparent;
			Label15.ForeColor = Drawing.Color.White;
			Label15.Location = new Drawing.Point(418, 23);
			Label15.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label15.Name = "Label15";
			Label15.Size = new Drawing.Size(61, 20);
			Label15.TabIndex = 72;
			Label15.Text = "Telef-3";
			// 
			// txtTelefono2
			// 
			txtTelefono2.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			txtTelefono2.Location = new Drawing.Point(276, 14);
			txtTelefono2.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			txtTelefono2.Name = "txtTelefono2";
			txtTelefono2.Size = new Drawing.Size(131, 26);
			txtTelefono2.TabIndex = 15;
			// 
			// Label14
			// 
			Label14.AutoSize = true;
			Label14.BackColor = Drawing.Color.Transparent;
			Label14.ForeColor = Drawing.Color.White;
			Label14.Location = new Drawing.Point(208, 21);
			Label14.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label14.Name = "Label14";
			Label14.Size = new Drawing.Size(61, 20);
			Label14.TabIndex = 70;
			Label14.Text = "Telef-2";
			// 
			// txtTelefono1
			// 
			txtTelefono1.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			txtTelefono1.Location = new Drawing.Point(80, 14);
			txtTelefono1.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			txtTelefono1.Name = "txtTelefono1";
			txtTelefono1.Size = new Drawing.Size(120, 26);
			txtTelefono1.TabIndex = 14;
			// 
			// Label13
			// 
			Label13.AutoSize = true;
			Label13.BackColor = Drawing.Color.Transparent;
			Label13.ForeColor = Drawing.Color.White;
			Label13.Location = new Drawing.Point(12, 21);
			Label13.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label13.Name = "Label13";
			Label13.Size = new Drawing.Size(61, 20);
			Label13.TabIndex = 68;
			Label13.Text = "Telef-1";
			// 
			// impresion
			// 
			impresion.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			impresion.Location = new Drawing.Point(84, 42);
			impresion.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			impresion.Name = "impresion";
			impresion.Size = new Drawing.Size(720, 26);
			impresion.TabIndex = 51;
			// 
			// Label5
			// 
			Label5.AutoSize = true;
			Label5.Location = new Drawing.Point(11, 45);
			Label5.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label5.Name = "Label5";
			Label5.Size = new Drawing.Size(77, 20);
			Label5.TabIndex = 50;
			Label5.Text = "Nombres ";
			// 
			// label17
			// 
			label17.AutoSize = true;
			label17.BackColor = Drawing.Color.Transparent;
			label17.ForeColor = Drawing.Color.White;
			label17.Location = new Drawing.Point(9, 92);
			label17.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			label17.Name = "label17";
			label17.Size = new Drawing.Size(165, 20);
			label17.TabIndex = 76;
			label17.Text = "Correo electrónico_2";
			// 
			// tabDatosPer
			// 
			tabDatosPer.BackColor = Drawing.Color.Gray;
			tabDatosPer.Controls.Add(cmbEspecialidad2);
			tabDatosPer.Controls.Add(cmbEspecialidad);
			tabDatosPer.Controls.Add(cmbProfesion);
			tabDatosPer.Controls.Add(cmbNacionalidadPersonal);
			tabDatosPer.Controls.Add(cmbTipoSangre);
			tabDatosPer.Controls.Add(Label93);
			tabDatosPer.Controls.Add(Label89);
			tabDatosPer.Controls.Add(txtPorcDiscapacidad);
			tabDatosPer.Controls.Add(Label91);
			tabDatosPer.Controls.Add(txtDiscapacidad);
			tabDatosPer.Controls.Add(GroupBox12);
			tabDatosPer.Controls.Add(Label80);
			tabDatosPer.Controls.Add(Label77);
			tabDatosPer.Controls.Add(asociadoa);
			tabDatosPer.Controls.Add(Label31);
			tabDatosPer.Controls.Add(txtLugTra);
			tabDatosPer.Controls.Add(Label30);
			tabDatosPer.Controls.Add(txtNumTar);
			tabDatosPer.Controls.Add(Label29);
			tabDatosPer.Controls.Add(Label24);
			tabDatosPer.Controls.Add(txtCodTar);
			tabDatosPer.Controls.Add(hobbys);
			tabDatosPer.Controls.Add(Label27);
			tabDatosPer.Controls.Add(txtReferirseComo);
			tabDatosPer.Controls.Add(Label26);
			tabDatosPer.Controls.Add(Label25);
			tabDatosPer.Controls.Add(cmbEstadoCivil);
			tabDatosPer.Controls.Add(Label21);
			tabDatosPer.Controls.Add(GroupBox4);
			tabDatosPer.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			tabDatosPer.Location = new Drawing.Point(4, 37);
			tabDatosPer.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			tabDatosPer.Name = "tabDatosPer";
			tabDatosPer.Padding = new Windows.Forms.Padding(4, 5, 4, 5);
			tabDatosPer.Size = new Drawing.Size(1268, 717);
			tabDatosPer.TabIndex = 0;
			tabDatosPer.Text = "Datos Personales";
			// 
			// cmbEspecialidad2
			// 
			cmbEspecialidad2.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Append;
			cmbEspecialidad2.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems;
			cmbEspecialidad2.FlatStyle = Windows.Forms.FlatStyle.Flat;
			cmbEspecialidad2.ForeColor = Drawing.Color.Black;
			cmbEspecialidad2.FormattingEnabled = true;
			cmbEspecialidad2.Items.AddRange(new object[] { "Soltero", "Unión Libre", "Casado", "Divorciado", "Viudo" });
			cmbEspecialidad2.Location = new Drawing.Point(734, 286);
			cmbEspecialidad2.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			cmbEspecialidad2.Name = "cmbEspecialidad2";
			cmbEspecialidad2.Size = new Drawing.Size(453, 28);
			cmbEspecialidad2.TabIndex = 116;
			// 
			// cmbEspecialidad
			// 
			cmbEspecialidad.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Append;
			cmbEspecialidad.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems;
			cmbEspecialidad.FlatStyle = Windows.Forms.FlatStyle.Flat;
			cmbEspecialidad.ForeColor = Drawing.Color.Black;
			cmbEspecialidad.FormattingEnabled = true;
			cmbEspecialidad.Items.AddRange(new object[] { "Soltero", "Unión Libre", "Casado", "Divorciado", "Viudo" });
			cmbEspecialidad.Location = new Drawing.Point(141, 286);
			cmbEspecialidad.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			cmbEspecialidad.Name = "cmbEspecialidad";
			cmbEspecialidad.Size = new Drawing.Size(436, 28);
			cmbEspecialidad.TabIndex = 115;
			// 
			// cmbProfesion
			// 
			cmbProfesion.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Append;
			cmbProfesion.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems;
			cmbProfesion.FlatStyle = Windows.Forms.FlatStyle.Flat;
			cmbProfesion.ForeColor = Drawing.Color.Black;
			cmbProfesion.FormattingEnabled = true;
			cmbProfesion.Items.AddRange(new object[] { "Soltero", "Unión Libre", "Casado", "Divorciado", "Viudo" });
			cmbProfesion.Location = new Drawing.Point(102, 248);
			cmbProfesion.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			cmbProfesion.Name = "cmbProfesion";
			cmbProfesion.Size = new Drawing.Size(476, 28);
			cmbProfesion.TabIndex = 114;
			// 
			// cmbNacionalidadPersonal
			// 
			cmbNacionalidadPersonal.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Append;
			cmbNacionalidadPersonal.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems;
			cmbNacionalidadPersonal.FlatStyle = Windows.Forms.FlatStyle.Flat;
			cmbNacionalidadPersonal.ForeColor = Drawing.Color.Black;
			cmbNacionalidadPersonal.FormattingEnabled = true;
			cmbNacionalidadPersonal.Items.AddRange(new object[] { "Soltero", "Unión Libre", "Casado", "Divorciado", "Viudo" });
			cmbNacionalidadPersonal.Location = new Drawing.Point(987, 54);
			cmbNacionalidadPersonal.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			cmbNacionalidadPersonal.Name = "cmbNacionalidadPersonal";
			cmbNacionalidadPersonal.Size = new Drawing.Size(199, 28);
			cmbNacionalidadPersonal.TabIndex = 81;
			// 
			// cmbTipoSangre
			// 
			cmbTipoSangre.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Append;
			cmbTipoSangre.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems;
			cmbTipoSangre.FlatStyle = Windows.Forms.FlatStyle.Flat;
			cmbTipoSangre.ForeColor = Drawing.Color.Black;
			cmbTipoSangre.FormattingEnabled = true;
			cmbTipoSangre.Items.AddRange(new object[] { "A RH+", "A RH-", "B RH+", "B RH-", "AB RH+", "AB RH-", "O RH+", "O RH-" });
			cmbTipoSangre.Location = new Drawing.Point(436, 55);
			cmbTipoSangre.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			cmbTipoSangre.Name = "cmbTipoSangre";
			cmbTipoSangre.Size = new Drawing.Size(100, 28);
			cmbTipoSangre.TabIndex = 80;
			// 
			// Label93
			// 
			Label93.AutoSize = true;
			Label93.ForeColor = Drawing.Color.White;
			Label93.Location = new Drawing.Point(611, 291);
			Label93.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label93.Name = "Label93";
			Label93.Size = new Drawing.Size(118, 20);
			Label93.TabIndex = 77;
			Label93.Text = "Especialidad 2";
			// 
			// Label89
			// 
			Label89.AutoSize = true;
			Label89.ForeColor = Drawing.Color.White;
			Label89.Location = new Drawing.Point(27, 459);
			Label89.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label89.Name = "Label89";
			Label89.Size = new Drawing.Size(111, 20);
			Label89.TabIndex = 76;
			Label89.Text = "Discapacidad";
			// 
			// txtPorcDiscapacidad
			// 
			txtPorcDiscapacidad.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			txtPorcDiscapacidad.Location = new Drawing.Point(579, 455);
			txtPorcDiscapacidad.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			txtPorcDiscapacidad.Name = "txtPorcDiscapacidad";
			txtPorcDiscapacidad.Size = new Drawing.Size(76, 26);
			txtPorcDiscapacidad.TabIndex = 74;
			// 
			// Label91
			// 
			Label91.AutoSize = true;
			Label91.ForeColor = Drawing.Color.White;
			Label91.Location = new Drawing.Point(379, 459);
			Label91.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label91.Name = "Label91";
			Label91.Size = new Drawing.Size(196, 20);
			Label91.TabIndex = 75;
			Label91.Text = "Porcentaje Discapacidad";
			// 
			// txtDiscapacidad
			// 
			txtDiscapacidad.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			txtDiscapacidad.Location = new Drawing.Point(150, 454);
			txtDiscapacidad.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			txtDiscapacidad.Name = "txtDiscapacidad";
			txtDiscapacidad.Size = new Drawing.Size(199, 26);
			txtDiscapacidad.TabIndex = 73;
			// 
			// GroupBox12
			// 
			GroupBox12.Controls.Add(cmbRegionNace);
			GroupBox12.Controls.Add(cmbCiudadNace);
			GroupBox12.Controls.Add(cmbProvinciaNace);
			GroupBox12.Controls.Add(cmbPaisNace);
			GroupBox12.Controls.Add(fechanaci);
			GroupBox12.Controls.Add(Label28);
			GroupBox12.Controls.Add(Label84);
			GroupBox12.Controls.Add(Label85);
			GroupBox12.Controls.Add(Label86);
			GroupBox12.Controls.Add(Lugarnaci);
			GroupBox12.Controls.Add(Label23);
			GroupBox12.Controls.Add(Label22);
			GroupBox12.ForeColor = Drawing.Color.Black;
			GroupBox12.Location = new Drawing.Point(19, 99);
			GroupBox12.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			GroupBox12.Name = "GroupBox12";
			GroupBox12.Padding = new Windows.Forms.Padding(4, 5, 4, 5);
			GroupBox12.Size = new Drawing.Size(1215, 128);
			GroupBox12.TabIndex = 69;
			GroupBox12.TabStop = false;
			GroupBox12.Text = "Nacimiento :";
			// 
			// cmbRegionNace
			// 
			cmbRegionNace.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Append;
			cmbRegionNace.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems;
			cmbRegionNace.FlatStyle = Windows.Forms.FlatStyle.Flat;
			cmbRegionNace.ForeColor = Drawing.Color.Black;
			cmbRegionNace.FormattingEnabled = true;
			cmbRegionNace.Items.AddRange(new object[] { "Soltero", "Unión Libre", "Casado", "Divorciado", "Viudo" });
			cmbRegionNace.Location = new Drawing.Point(423, 71);
			cmbRegionNace.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			cmbRegionNace.Name = "cmbRegionNace";
			cmbRegionNace.Size = new Drawing.Size(255, 28);
			cmbRegionNace.TabIndex = 114;
			// 
			// cmbCiudadNace
			// 
			cmbCiudadNace.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Append;
			cmbCiudadNace.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems;
			cmbCiudadNace.FlatStyle = Windows.Forms.FlatStyle.Flat;
			cmbCiudadNace.ForeColor = Drawing.Color.Black;
			cmbCiudadNace.FormattingEnabled = true;
			cmbCiudadNace.Items.AddRange(new object[] { "Soltero", "Unión Libre", "Casado", "Divorciado", "Viudo" });
			cmbCiudadNace.Location = new Drawing.Point(72, 72);
			cmbCiudadNace.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			cmbCiudadNace.Name = "cmbCiudadNace";
			cmbCiudadNace.Size = new Drawing.Size(274, 28);
			cmbCiudadNace.TabIndex = 113;
			// 
			// cmbProvinciaNace
			// 
			cmbProvinciaNace.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Append;
			cmbProvinciaNace.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems;
			cmbProvinciaNace.FlatStyle = Windows.Forms.FlatStyle.Flat;
			cmbProvinciaNace.ForeColor = Drawing.Color.Black;
			cmbProvinciaNace.FormattingEnabled = true;
			cmbProvinciaNace.Items.AddRange(new object[] { "Soltero", "Unión Libre", "Casado", "Divorciado", "Viudo" });
			cmbProvinciaNace.Location = new Drawing.Point(647, 22);
			cmbProvinciaNace.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			cmbProvinciaNace.Name = "cmbProvinciaNace";
			cmbProvinciaNace.Size = new Drawing.Size(291, 28);
			cmbProvinciaNace.TabIndex = 112;
			// 
			// cmbPaisNace
			// 
			cmbPaisNace.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Append;
			cmbPaisNace.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems;
			cmbPaisNace.FlatStyle = Windows.Forms.FlatStyle.Flat;
			cmbPaisNace.ForeColor = Drawing.Color.Black;
			cmbPaisNace.FormattingEnabled = true;
			cmbPaisNace.Items.AddRange(new object[] { "Soltero", "Unión Libre", "Casado", "Divorciado", "Viudo" });
			cmbPaisNace.Location = new Drawing.Point(253, 28);
			cmbPaisNace.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			cmbPaisNace.Name = "cmbPaisNace";
			cmbPaisNace.Size = new Drawing.Size(291, 28);
			cmbPaisNace.TabIndex = 111;
			// 
			// fechanaci
			// 
			fechanaci.CustomFormat = "ddMMyyyy";
			fechanaci.Format = Windows.Forms.DateTimePickerFormat.Short;
			fechanaci.Location = new Drawing.Point(72, 29);
			fechanaci.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			fechanaci.Name = "fechanaci";
			fechanaci.Size = new Drawing.Size(118, 26);
			fechanaci.TabIndex = 76;
			fechanaci.Value = new DateTime(1900, 1, 1, 0, 0, 0, 0);
			// 
			// Label28
			// 
			Label28.AutoSize = true;
			Label28.ForeColor = Drawing.Color.White;
			Label28.Location = new Drawing.Point(357, 82);
			Label28.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label28.Name = "Label28";
			Label28.Size = new Drawing.Size(61, 20);
			Label28.TabIndex = 71;
			Label28.Text = "Región";
			// 
			// Label84
			// 
			Label84.AutoSize = true;
			Label84.ForeColor = Drawing.Color.White;
			Label84.Location = new Drawing.Point(10, 81);
			Label84.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label84.Name = "Label84";
			Label84.Size = new Drawing.Size(61, 20);
			Label84.TabIndex = 68;
			Label84.Text = "Ciudad";
			// 
			// Label85
			// 
			Label85.AutoSize = true;
			Label85.ForeColor = Drawing.Color.White;
			Label85.Location = new Drawing.Point(561, 34);
			Label85.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label85.Name = "Label85";
			Label85.Size = new Drawing.Size(78, 20);
			Label85.TabIndex = 67;
			Label85.Text = "Provincia";
			// 
			// Label86
			// 
			Label86.AutoSize = true;
			Label86.ForeColor = Drawing.Color.White;
			Label86.Location = new Drawing.Point(207, 35);
			Label86.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label86.Name = "Label86";
			Label86.Size = new Drawing.Size(42, 20);
			Label86.TabIndex = 66;
			Label86.Text = "País";
			// 
			// Lugarnaci
			// 
			Lugarnaci.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Append;
			Lugarnaci.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			Lugarnaci.ForeColor = Drawing.Color.Black;
			Lugarnaci.Location = new Drawing.Point(750, 69);
			Lugarnaci.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			Lugarnaci.Name = "Lugarnaci";
			Lugarnaci.Size = new Drawing.Size(336, 26);
			Lugarnaci.TabIndex = 4;
			// 
			// Label23
			// 
			Label23.AutoSize = true;
			Label23.ForeColor = Drawing.Color.White;
			Label23.Location = new Drawing.Point(688, 75);
			Label23.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label23.Name = "Label23";
			Label23.Size = new Drawing.Size(57, 20);
			Label23.TabIndex = 5;
			Label23.Text = "Lugar:";
			// 
			// Label22
			// 
			Label22.AutoSize = true;
			Label22.ForeColor = Drawing.Color.White;
			Label22.Location = new Drawing.Point(14, 35);
			Label22.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label22.Name = "Label22";
			Label22.Size = new Drawing.Size(55, 20);
			Label22.TabIndex = 3;
			Label22.Text = "Fecha";
			// 
			// Label80
			// 
			Label80.AutoSize = true;
			Label80.ForeColor = Drawing.Color.White;
			Label80.Location = new Drawing.Point(310, 60);
			Label80.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label80.Name = "Label80";
			Label80.Size = new Drawing.Size(122, 20);
			Label80.TabIndex = 27;
			Label80.Text = "Tipo de Sangre";
			// 
			// Label77
			// 
			Label77.AutoSize = true;
			Label77.ForeColor = Drawing.Color.White;
			Label77.Location = new Drawing.Point(18, 291);
			Label77.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label77.Name = "Label77";
			Label77.Size = new Drawing.Size(118, 20);
			Label77.TabIndex = 23;
			Label77.Text = "Especialidad 1";
			// 
			// asociadoa
			// 
			asociadoa.Controls.Add(CbuscaDir3);
			asociadoa.Controls.Add(LDir3);
			asociadoa.ForeColor = Drawing.Color.Black;
			asociadoa.Location = new Drawing.Point(21, 495);
			asociadoa.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			asociadoa.Name = "asociadoa";
			asociadoa.Padding = new Windows.Forms.Padding(4, 5, 4, 5);
			asociadoa.Size = new Drawing.Size(518, 71);
			asociadoa.TabIndex = 2;
			asociadoa.TabStop = false;
			asociadoa.Text = "Asociado a la Empresa";
			asociadoa.Visible = false;
			// 
			// CbuscaDir3
			// 
			CbuscaDir3.BackColor = Drawing.Color.DimGray;
			CbuscaDir3.FlatAppearance.BorderColor = Drawing.Color.White;
			CbuscaDir3.FlatAppearance.BorderSize = 0;
			CbuscaDir3.FlatStyle = Windows.Forms.FlatStyle.Flat;
			CbuscaDir3.Font = new Drawing.Font("Microsoft Sans Serif", 6f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			CbuscaDir3.ForeColor = Drawing.Color.White;
			CbuscaDir3.Location = new Drawing.Point(19, 28);
			CbuscaDir3.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			CbuscaDir3.Name = "CbuscaDir3";
			CbuscaDir3.Size = new Drawing.Size(30, 31);
			CbuscaDir3.TabIndex = 10;
			CbuscaDir3.Text = "...";
			CbuscaDir3.UseVisualStyleBackColor = false;
			// 
			// LDir3
			// 
			LDir3.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			LDir3.Location = new Drawing.Point(50, 28);
			LDir3.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			LDir3.Name = "LDir3";
			LDir3.Size = new Drawing.Size(458, 26);
			LDir3.TabIndex = 0;
			// 
			// Label31
			// 
			Label31.AutoSize = true;
			Label31.ForeColor = Drawing.Color.White;
			Label31.Location = new Drawing.Point(15, 385);
			Label31.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label31.Name = "Label31";
			Label31.Size = new Drawing.Size(143, 20);
			Label31.TabIndex = 22;
			Label31.Text = "Tarjeta de Credito";
			// 
			// txtLugTra
			// 
			txtLugTra.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			txtLugTra.Location = new Drawing.Point(186, 419);
			txtLugTra.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			txtLugTra.Name = "txtLugTra";
			txtLugTra.Size = new Drawing.Size(616, 26);
			txtLugTra.TabIndex = 10;
			// 
			// Label30
			// 
			Label30.AutoSize = true;
			Label30.ForeColor = Drawing.Color.White;
			Label30.Location = new Drawing.Point(21, 419);
			Label30.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label30.Name = "Label30";
			Label30.Size = new Drawing.Size(165, 20);
			Label30.TabIndex = 20;
			Label30.Text = "Dirección de Trabajo";
			// 
			// txtNumTar
			// 
			txtNumTar.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			txtNumTar.Location = new Drawing.Point(514, 381);
			txtNumTar.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			txtNumTar.Name = "txtNumTar";
			txtNumTar.Size = new Drawing.Size(242, 26);
			txtNumTar.TabIndex = 9;
			// 
			// Label29
			// 
			Label29.AutoSize = true;
			Label29.ForeColor = Drawing.Color.White;
			Label29.Location = new Drawing.Point(386, 385);
			Label29.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label29.Name = "Label29";
			Label29.Size = new Drawing.Size(125, 20);
			Label29.TabIndex = 18;
			Label29.Text = "Número Tarjeta";
			// 
			// Label24
			// 
			Label24.AutoSize = true;
			Label24.ForeColor = Drawing.Color.White;
			Label24.Location = new Drawing.Point(874, 60);
			Label24.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label24.Name = "Label24";
			Label24.Size = new Drawing.Size(105, 20);
			Label24.TabIndex = 7;
			Label24.Text = "Nacionalidad";
			// 
			// txtCodTar
			// 
			txtCodTar.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			txtCodTar.Location = new Drawing.Point(161, 381);
			txtCodTar.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			txtCodTar.Name = "txtCodTar";
			txtCodTar.Size = new Drawing.Size(199, 26);
			txtCodTar.TabIndex = 8;
			// 
			// hobbys
			// 
			hobbys.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			hobbys.Location = new Drawing.Point(91, 332);
			hobbys.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			hobbys.Name = "hobbys";
			hobbys.Size = new Drawing.Size(486, 26);
			hobbys.TabIndex = 7;
			// 
			// Label27
			// 
			Label27.AutoSize = true;
			Label27.ForeColor = Drawing.Color.White;
			Label27.Location = new Drawing.Point(18, 335);
			Label27.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label27.Name = "Label27";
			Label27.Size = new Drawing.Size(66, 20);
			Label27.TabIndex = 14;
			Label27.Text = "Hobbys";
			// 
			// txtReferirseComo
			// 
			txtReferirseComo.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Append;
			txtReferirseComo.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems;
			txtReferirseComo.FlatStyle = Windows.Forms.FlatStyle.Flat;
			txtReferirseComo.FormattingEnabled = true;
			txtReferirseComo.Items.AddRange(new object[] { "Sr.", "Sra.", "Srta.", "Ing.", "Dr.", "Dra.", "Arq." });
			txtReferirseComo.Location = new Drawing.Point(744, 248);
			txtReferirseComo.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			txtReferirseComo.Name = "txtReferirseComo";
			txtReferirseComo.Size = new Drawing.Size(158, 28);
			txtReferirseComo.TabIndex = 13;
			// 
			// Label26
			// 
			Label26.AutoSize = true;
			Label26.ForeColor = Drawing.Color.White;
			Label26.Location = new Drawing.Point(618, 252);
			Label26.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label26.Name = "Label26";
			Label26.Size = new Drawing.Size(124, 20);
			Label26.TabIndex = 12;
			Label26.Text = "Referirse como";
			// 
			// Label25
			// 
			Label25.AutoSize = true;
			Label25.ForeColor = Drawing.Color.White;
			Label25.Location = new Drawing.Point(17, 254);
			Label25.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label25.Name = "Label25";
			Label25.Size = new Drawing.Size(80, 20);
			Label25.TabIndex = 10;
			Label25.Text = "Profesión";
			// 
			// cmbEstadoCivil
			// 
			cmbEstadoCivil.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Append;
			cmbEstadoCivil.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems;
			cmbEstadoCivil.FlatStyle = Windows.Forms.FlatStyle.Flat;
			cmbEstadoCivil.ForeColor = Drawing.Color.Black;
			cmbEstadoCivil.FormattingEnabled = true;
			cmbEstadoCivil.Items.AddRange(new object[] { "Soltero", "Unión Libre", "Casado", "Divorciado", "Viudo" });
			cmbEstadoCivil.Location = new Drawing.Point(647, 54);
			cmbEstadoCivil.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			cmbEstadoCivil.Name = "cmbEstadoCivil";
			cmbEstadoCivil.Size = new Drawing.Size(199, 28);
			cmbEstadoCivil.TabIndex = 1;
			// 
			// Label21
			// 
			Label21.AutoSize = true;
			Label21.ForeColor = Drawing.Color.White;
			Label21.Location = new Drawing.Point(548, 60);
			Label21.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label21.Name = "Label21";
			Label21.Size = new Drawing.Size(98, 20);
			Label21.TabIndex = 1;
			Label21.Text = "Estado Civil";
			// 
			// GroupBox4
			// 
			GroupBox4.Controls.Add(mujer);
			GroupBox4.Controls.Add(hombre);
			GroupBox4.FlatStyle = Windows.Forms.FlatStyle.Flat;
			GroupBox4.ForeColor = Drawing.Color.Black;
			GroupBox4.Location = new Drawing.Point(22, 29);
			GroupBox4.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			GroupBox4.Name = "GroupBox4";
			GroupBox4.Padding = new Windows.Forms.Padding(4, 5, 4, 5);
			GroupBox4.Size = new Drawing.Size(280, 60);
			GroupBox4.TabIndex = 0;
			GroupBox4.TabStop = false;
			GroupBox4.Text = "Sexo";
			// 
			// mujer
			// 
			mujer.AutoSize = true;
			mujer.ForeColor = Drawing.Color.White;
			mujer.Location = new Drawing.Point(143, 22);
			mujer.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			mujer.Name = "mujer";
			mujer.Size = new Drawing.Size(107, 24);
			mujer.TabIndex = 1;
			mujer.Text = "Femenino";
			mujer.UseVisualStyleBackColor = true;
			// 
			// hombre
			// 
			hombre.AutoSize = true;
			hombre.Checked = true;
			hombre.ForeColor = Drawing.Color.White;
			hombre.Location = new Drawing.Point(24, 22);
			hombre.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			hombre.Name = "hombre";
			hombre.Size = new Drawing.Size(110, 24);
			hombre.TabIndex = 0;
			hombre.TabStop = true;
			hombre.Text = "Masculino";
			hombre.UseVisualStyleBackColor = true;
			// 
			// tabCliente
			// 
			tabCliente.BackColor = Drawing.Color.Gray;
			tabCliente.Controls.Add(btnBuscaZonaVentas);
			tabCliente.Controls.Add(CBuscador3);
			tabCliente.Controls.Add(txtOperador);
			tabCliente.Controls.Add(btnBuscaOperador);
			tabCliente.Controls.Add(Label90);
			tabCliente.Controls.Add(Cuenta4);
			tabCliente.Controls.Add(Cuenta0);
			tabCliente.Controls.Add(GroupBox15);
			tabCliente.Controls.Add(txtCobrador);
			tabCliente.Controls.Add(txtVendedor);
			tabCliente.Controls.Add(txtZonaCobranzas);
			tabCliente.Controls.Add(txtZonaVentas);
			tabCliente.Controls.Add(txtTipoCliente);
			tabCliente.Controls.Add(GroupBox11);
			tabCliente.Controls.Add(Command5);
			tabCliente.Controls.Add(Label75);
			tabCliente.Controls.Add(Command1);
			tabCliente.Controls.Add(Label45);
			tabCliente.Controls.Add(observacli);
			tabCliente.Controls.Add(Label44);
			tabCliente.Controls.Add(txtContacto);
			tabCliente.Controls.Add(Label42);
			tabCliente.Controls.Add(btnBuscaCobrador);
			tabCliente.Controls.Add(Label37);
			tabCliente.Controls.Add(btnBuscaZonaCobro);
			tabCliente.Controls.Add(Label36);
			tabCliente.Controls.Add(btnBuscaVendedor);
			tabCliente.Controls.Add(Label35);
			tabCliente.Controls.Add(Label34);
			tabCliente.Controls.Add(Label33);
			tabCliente.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			tabCliente.Location = new Drawing.Point(4, 37);
			tabCliente.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			tabCliente.Name = "tabCliente";
			tabCliente.Padding = new Windows.Forms.Padding(4, 5, 4, 5);
			tabCliente.Size = new Drawing.Size(1268, 717);
			tabCliente.TabIndex = 1;
			tabCliente.Text = "Cliente  ";
			// 
			// btnBuscaZonaVentas
			// 
			btnBuscaZonaVentas.BackColor = Drawing.Color.DimGray;
			btnBuscaZonaVentas.FlatAppearance.BorderColor = Drawing.Color.White;
			btnBuscaZonaVentas.FlatAppearance.BorderSize = 0;
			btnBuscaZonaVentas.FlatStyle = Windows.Forms.FlatStyle.Flat;
			btnBuscaZonaVentas.Font = new Drawing.Font("Microsoft Sans Serif", 6f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			btnBuscaZonaVentas.ForeColor = Drawing.Color.White;
			btnBuscaZonaVentas.Location = new Drawing.Point(158, 46);
			btnBuscaZonaVentas.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			btnBuscaZonaVentas.Name = "btnBuscaZonaVentas";
			btnBuscaZonaVentas.Size = new Drawing.Size(27, 28);
			btnBuscaZonaVentas.TabIndex = 124;
			btnBuscaZonaVentas.Text = "...";
			btnBuscaZonaVentas.UseVisualStyleBackColor = false;
			// 
			// CBuscador3
			// 
			CBuscador3.BackColor = Drawing.Color.DimGray;
			CBuscador3.FlatAppearance.BorderColor = Drawing.Color.White;
			CBuscador3.FlatAppearance.BorderSize = 0;
			CBuscador3.FlatStyle = Windows.Forms.FlatStyle.Flat;
			CBuscador3.Font = new Drawing.Font("Microsoft Sans Serif", 6f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			CBuscador3.ForeColor = Drawing.Color.White;
			CBuscador3.Location = new Drawing.Point(158, 14);
			CBuscador3.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			CBuscador3.Name = "CBuscador3";
			CBuscador3.Size = new Drawing.Size(27, 28);
			CBuscador3.TabIndex = 123;
			CBuscador3.Text = "...";
			CBuscador3.UseVisualStyleBackColor = false;
			// 
			// txtOperador
			// 
			txtOperador.BackColor = Drawing.Color.White;
			txtOperador.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			txtOperador.Location = new Drawing.Point(534, 18);
			txtOperador.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			txtOperador.Name = "txtOperador";
			txtOperador.Size = new Drawing.Size(450, 27);
			txtOperador.TabIndex = 122;
			// 
			// btnBuscaOperador
			// 
			btnBuscaOperador.BackColor = Drawing.Color.DimGray;
			btnBuscaOperador.FlatAppearance.BorderColor = Drawing.Color.White;
			btnBuscaOperador.FlatAppearance.BorderSize = 0;
			btnBuscaOperador.FlatStyle = Windows.Forms.FlatStyle.Flat;
			btnBuscaOperador.Font = new Drawing.Font("Microsoft Sans Serif", 6f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			btnBuscaOperador.ForeColor = Drawing.Color.White;
			btnBuscaOperador.Location = new Drawing.Point(505, 18);
			btnBuscaOperador.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			btnBuscaOperador.Name = "btnBuscaOperador";
			btnBuscaOperador.Size = new Drawing.Size(27, 28);
			btnBuscaOperador.TabIndex = 121;
			btnBuscaOperador.Text = "...";
			btnBuscaOperador.UseVisualStyleBackColor = false;
			// 
			// Label90
			// 
			Label90.AutoSize = true;
			Label90.ForeColor = Drawing.Color.White;
			Label90.Location = new Drawing.Point(428, 21);
			Label90.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label90.Name = "Label90";
			Label90.Size = new Drawing.Size(79, 20);
			Label90.TabIndex = 120;
			Label90.Text = "Operador";
			// 
			// Cuenta4
			// 
			Cuenta4.BackColor = Drawing.Color.White;
			Cuenta4.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			Cuenta4.Location = new Drawing.Point(756, 439);
			Cuenta4.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Cuenta4.Name = "Cuenta4";
			Cuenta4.Size = new Drawing.Size(188, 27);
			Cuenta4.TabIndex = 119;
			// 
			// Cuenta0
			// 
			Cuenta0.BackColor = Drawing.Color.White;
			Cuenta0.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			Cuenta0.Location = new Drawing.Point(220, 440);
			Cuenta0.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Cuenta0.Name = "Cuenta0";
			Cuenta0.Size = new Drawing.Size(179, 27);
			Cuenta0.TabIndex = 118;
			// 
			// GroupBox15
			// 
			GroupBox15.Controls.Add(btnTransportadora);
			GroupBox15.Controls.Add(Label41);
			GroupBox15.Controls.Add(txtTransportadora);
			GroupBox15.Controls.Add(txtPaisEntrega);
			GroupBox15.Controls.Add(btnPuertoEntrega);
			GroupBox15.Controls.Add(Label94);
			GroupBox15.Controls.Add(btnPaísEntrega);
			GroupBox15.Controls.Add(Label95);
			GroupBox15.Controls.Add(entregarmer);
			GroupBox15.ForeColor = Drawing.Color.Black;
			GroupBox15.Location = new Drawing.Point(14, 271);
			GroupBox15.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			GroupBox15.Name = "GroupBox15";
			GroupBox15.Padding = new Windows.Forms.Padding(4, 5, 4, 5);
			GroupBox15.Size = new Drawing.Size(1225, 129);
			GroupBox15.TabIndex = 117;
			GroupBox15.TabStop = false;
			GroupBox15.Text = "Entrega de productos";
			// 
			// btnTransportadora
			// 
			btnTransportadora.BackColor = Drawing.Color.DimGray;
			btnTransportadora.FlatAppearance.BorderColor = Drawing.Color.White;
			btnTransportadora.FlatAppearance.BorderSize = 0;
			btnTransportadora.FlatStyle = Windows.Forms.FlatStyle.Flat;
			btnTransportadora.Font = new Drawing.Font("Microsoft Sans Serif", 6f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			btnTransportadora.ForeColor = Drawing.Color.White;
			btnTransportadora.Location = new Drawing.Point(195, 71);
			btnTransportadora.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			btnTransportadora.Name = "btnTransportadora";
			btnTransportadora.Size = new Drawing.Size(27, 28);
			btnTransportadora.TabIndex = 117;
			btnTransportadora.Text = "...";
			btnTransportadora.UseVisualStyleBackColor = false;
			// 
			// Label41
			// 
			Label41.AutoSize = true;
			Label41.ForeColor = Drawing.Color.White;
			Label41.Location = new Drawing.Point(9, 74);
			Label41.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label41.Name = "Label41";
			Label41.Size = new Drawing.Size(193, 20);
			Label41.TabIndex = 115;
			Label41.Text = "Agencia transportadora :";
			// 
			// txtTransportadora
			// 
			txtTransportadora.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			txtTransportadora.ForeColor = Drawing.Color.Black;
			txtTransportadora.Location = new Drawing.Point(224, 69);
			txtTransportadora.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			txtTransportadora.Name = "txtTransportadora";
			txtTransportadora.Size = new Drawing.Size(487, 26);
			txtTransportadora.TabIndex = 116;
			// 
			// txtPaisEntrega
			// 
			txtPaisEntrega.BackColor = Drawing.Color.White;
			txtPaisEntrega.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			txtPaisEntrega.ForeColor = Drawing.Color.Black;
			txtPaisEntrega.Location = new Drawing.Point(78, 29);
			txtPaisEntrega.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			txtPaisEntrega.Name = "txtPaisEntrega";
			txtPaisEntrega.Size = new Drawing.Size(287, 27);
			txtPaisEntrega.TabIndex = 114;
			// 
			// btnPuertoEntrega
			// 
			btnPuertoEntrega.BackColor = Drawing.Color.DimGray;
			btnPuertoEntrega.FlatAppearance.BorderColor = Drawing.Color.White;
			btnPuertoEntrega.FlatAppearance.BorderSize = 0;
			btnPuertoEntrega.FlatStyle = Windows.Forms.FlatStyle.Flat;
			btnPuertoEntrega.Font = new Drawing.Font("Microsoft Sans Serif", 6f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			btnPuertoEntrega.ForeColor = Drawing.Color.White;
			btnPuertoEntrega.Location = new Drawing.Point(449, 29);
			btnPuertoEntrega.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			btnPuertoEntrega.Name = "btnPuertoEntrega";
			btnPuertoEntrega.Size = new Drawing.Size(27, 28);
			btnPuertoEntrega.TabIndex = 20;
			btnPuertoEntrega.Text = "...";
			btnPuertoEntrega.UseVisualStyleBackColor = false;
			// 
			// Label94
			// 
			Label94.AutoSize = true;
			Label94.ForeColor = Drawing.Color.White;
			Label94.Location = new Drawing.Point(386, 38);
			Label94.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label94.Name = "Label94";
			Label94.Size = new Drawing.Size(68, 20);
			Label94.TabIndex = 18;
			Label94.Text = "Puerto :";
			// 
			// btnPaísEntrega
			// 
			btnPaísEntrega.BackColor = Drawing.Color.DimGray;
			btnPaísEntrega.FlatAppearance.BorderColor = Drawing.Color.White;
			btnPaísEntrega.FlatAppearance.BorderSize = 0;
			btnPaísEntrega.FlatStyle = Windows.Forms.FlatStyle.Flat;
			btnPaísEntrega.Font = new Drawing.Font("Microsoft Sans Serif", 6f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			btnPaísEntrega.ForeColor = Drawing.Color.White;
			btnPaísEntrega.Location = new Drawing.Point(50, 29);
			btnPaísEntrega.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			btnPaísEntrega.Name = "btnPaísEntrega";
			btnPaísEntrega.Size = new Drawing.Size(27, 28);
			btnPaísEntrega.TabIndex = 17;
			btnPaísEntrega.Text = "...";
			btnPaísEntrega.UseVisualStyleBackColor = false;
			// 
			// Label95
			// 
			Label95.AutoSize = true;
			Label95.ForeColor = Drawing.Color.White;
			Label95.Location = new Drawing.Point(8, 38);
			Label95.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label95.Name = "Label95";
			Label95.Size = new Drawing.Size(42, 20);
			Label95.TabIndex = 15;
			Label95.Text = "Pais";
			// 
			// entregarmer
			// 
			entregarmer.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			entregarmer.ForeColor = Drawing.Color.Black;
			entregarmer.Location = new Drawing.Point(477, 26);
			entregarmer.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			entregarmer.Name = "entregarmer";
			entregarmer.Size = new Drawing.Size(487, 26);
			entregarmer.TabIndex = 24;
			// 
			// txtCobrador
			// 
			txtCobrador.BackColor = Drawing.Color.White;
			txtCobrador.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			txtCobrador.Location = new Drawing.Point(534, 81);
			txtCobrador.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			txtCobrador.Name = "txtCobrador";
			txtCobrador.Size = new Drawing.Size(450, 27);
			txtCobrador.TabIndex = 116;
			// 
			// txtVendedor
			// 
			txtVendedor.BackColor = Drawing.Color.White;
			txtVendedor.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			txtVendedor.Location = new Drawing.Point(534, 49);
			txtVendedor.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			txtVendedor.Name = "txtVendedor";
			txtVendedor.Size = new Drawing.Size(450, 27);
			txtVendedor.TabIndex = 115;
			// 
			// txtZonaCobranzas
			// 
			txtZonaCobranzas.BackColor = Drawing.Color.White;
			txtZonaCobranzas.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			txtZonaCobranzas.Location = new Drawing.Point(186, 79);
			txtZonaCobranzas.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			txtZonaCobranzas.Name = "txtZonaCobranzas";
			txtZonaCobranzas.Size = new Drawing.Size(212, 27);
			txtZonaCobranzas.TabIndex = 114;
			// 
			// txtZonaVentas
			// 
			txtZonaVentas.BackColor = Drawing.Color.White;
			txtZonaVentas.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			txtZonaVentas.Location = new Drawing.Point(186, 46);
			txtZonaVentas.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			txtZonaVentas.Name = "txtZonaVentas";
			txtZonaVentas.Size = new Drawing.Size(212, 27);
			txtZonaVentas.TabIndex = 113;
			// 
			// txtTipoCliente
			// 
			txtTipoCliente.BackColor = Drawing.Color.White;
			txtTipoCliente.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			txtTipoCliente.Location = new Drawing.Point(186, 14);
			txtTipoCliente.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			txtTipoCliente.Name = "txtTipoCliente";
			txtTipoCliente.Size = new Drawing.Size(212, 27);
			txtTipoCliente.TabIndex = 112;
			// 
			// GroupBox11
			// 
			GroupBox11.Controls.Add(txtPrecioVenta);
			GroupBox11.Controls.Add(txtFormaPago);
			GroupBox11.Controls.Add(txtLimiteCredito);
			GroupBox11.Controls.Add(Label46);
			GroupBox11.Controls.Add(txtDescuentoAsociacion);
			GroupBox11.Controls.Add(Label43);
			GroupBox11.Controls.Add(txtPorcDescuento);
			GroupBox11.Controls.Add(Label40);
			GroupBox11.Controls.Add(btnFormaPago);
			GroupBox11.Controls.Add(Label39);
			GroupBox11.Controls.Add(btnPrecioVenta);
			GroupBox11.Controls.Add(Label38);
			GroupBox11.ForeColor = Drawing.Color.Black;
			GroupBox11.Location = new Drawing.Point(12, 151);
			GroupBox11.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			GroupBox11.Name = "GroupBox11";
			GroupBox11.Padding = new Windows.Forms.Padding(4, 5, 4, 5);
			GroupBox11.Size = new Drawing.Size(1225, 111);
			GroupBox11.TabIndex = 42;
			GroupBox11.TabStop = false;
			GroupBox11.Text = "Características comerciales";
			// 
			// txtPrecioVenta
			// 
			txtPrecioVenta.BackColor = Drawing.Color.White;
			txtPrecioVenta.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			txtPrecioVenta.ForeColor = Drawing.Color.Black;
			txtPrecioVenta.Location = new Drawing.Point(172, 35);
			txtPrecioVenta.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			txtPrecioVenta.Name = "txtPrecioVenta";
			txtPrecioVenta.Size = new Drawing.Size(188, 27);
			txtPrecioVenta.TabIndex = 114;
			// 
			// txtFormaPago
			// 
			txtFormaPago.BackColor = Drawing.Color.White;
			txtFormaPago.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			txtFormaPago.ForeColor = Drawing.Color.Black;
			txtFormaPago.Location = new Drawing.Point(532, 35);
			txtFormaPago.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			txtFormaPago.Name = "txtFormaPago";
			txtFormaPago.Size = new Drawing.Size(188, 27);
			txtFormaPago.TabIndex = 113;
			// 
			// txtLimiteCredito
			// 
			txtLimiteCredito.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			txtLimiteCredito.ForeColor = Drawing.Color.Black;
			txtLimiteCredito.Location = new Drawing.Point(161, 71);
			txtLimiteCredito.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			txtLimiteCredito.Name = "txtLimiteCredito";
			txtLimiteCredito.Size = new Drawing.Size(197, 26);
			txtLimiteCredito.TabIndex = 28;
			// 
			// Label46
			// 
			Label46.AutoSize = true;
			Label46.ForeColor = Drawing.Color.White;
			Label46.Location = new Drawing.Point(24, 75);
			Label46.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label46.Name = "Label46";
			Label46.Size = new Drawing.Size(137, 20);
			Label46.TabIndex = 27;
			Label46.Text = "Límite de Credito";
			// 
			// txtDescuentoAsociacion
			// 
			txtDescuentoAsociacion.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			txtDescuentoAsociacion.ForeColor = Drawing.Color.Black;
			txtDescuentoAsociacion.Location = new Drawing.Point(908, 69);
			txtDescuentoAsociacion.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			txtDescuentoAsociacion.MaxLength = 6;
			txtDescuentoAsociacion.Name = "txtDescuentoAsociacion";
			txtDescuentoAsociacion.Size = new Drawing.Size(147, 26);
			txtDescuentoAsociacion.TabIndex = 30;
			// 
			// Label43
			// 
			Label43.AutoSize = true;
			Label43.ForeColor = Drawing.Color.White;
			Label43.Location = new Drawing.Point(684, 74);
			Label43.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label43.Name = "Label43";
			Label43.Size = new Drawing.Size(222, 20);
			Label43.TabIndex = 29;
			Label43.Text = "Decuento  como  asociación";
			// 
			// txtPorcDescuento
			// 
			txtPorcDescuento.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			txtPorcDescuento.ForeColor = Drawing.Color.Black;
			txtPorcDescuento.Location = new Drawing.Point(906, 32);
			txtPorcDescuento.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			txtPorcDescuento.MaxLength = 5;
			txtPorcDescuento.Name = "txtPorcDescuento";
			txtPorcDescuento.Size = new Drawing.Size(71, 26);
			txtPorcDescuento.TabIndex = 22;
			// 
			// Label40
			// 
			Label40.AutoSize = true;
			Label40.ForeColor = Drawing.Color.White;
			Label40.Location = new Drawing.Point(735, 38);
			Label40.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label40.Name = "Label40";
			Label40.Size = new Drawing.Size(175, 20);
			Label40.TabIndex = 21;
			Label40.Text = "Porcentaje Descuento";
			// 
			// btnFormaPago
			// 
			btnFormaPago.BackColor = Drawing.Color.DimGray;
			btnFormaPago.FlatAppearance.BorderColor = Drawing.Color.White;
			btnFormaPago.FlatAppearance.BorderSize = 0;
			btnFormaPago.FlatStyle = Windows.Forms.FlatStyle.Flat;
			btnFormaPago.Font = new Drawing.Font("Microsoft Sans Serif", 6f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			btnFormaPago.ForeColor = Drawing.Color.White;
			btnFormaPago.Location = new Drawing.Point(504, 35);
			btnFormaPago.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			btnFormaPago.Name = "btnFormaPago";
			btnFormaPago.Size = new Drawing.Size(27, 28);
			btnFormaPago.TabIndex = 20;
			btnFormaPago.Text = "...";
			btnFormaPago.UseVisualStyleBackColor = false;
			// 
			// Label39
			// 
			Label39.AutoSize = true;
			Label39.ForeColor = Drawing.Color.White;
			Label39.Location = new Drawing.Point(386, 38);
			Label39.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label39.Name = "Label39";
			Label39.Size = new Drawing.Size(123, 20);
			Label39.TabIndex = 18;
			Label39.Text = "Forma de Pago";
			// 
			// btnPrecioVenta
			// 
			btnPrecioVenta.BackColor = Drawing.Color.DimGray;
			btnPrecioVenta.FlatAppearance.BorderColor = Drawing.Color.White;
			btnPrecioVenta.FlatAppearance.BorderSize = 0;
			btnPrecioVenta.FlatStyle = Windows.Forms.FlatStyle.Flat;
			btnPrecioVenta.Font = new Drawing.Font("Microsoft Sans Serif", 6f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			btnPrecioVenta.ForeColor = Drawing.Color.White;
			btnPrecioVenta.Location = new Drawing.Point(144, 35);
			btnPrecioVenta.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			btnPrecioVenta.Name = "btnPrecioVenta";
			btnPrecioVenta.Size = new Drawing.Size(27, 28);
			btnPrecioVenta.TabIndex = 17;
			btnPrecioVenta.Text = "...";
			btnPrecioVenta.UseVisualStyleBackColor = false;
			// 
			// Label38
			// 
			Label38.AutoSize = true;
			Label38.ForeColor = Drawing.Color.White;
			Label38.Location = new Drawing.Point(21, 38);
			Label38.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label38.Name = "Label38";
			Label38.Size = new Drawing.Size(128, 20);
			Label38.TabIndex = 15;
			Label38.Text = "Precio de Venta";
			// 
			// Command5
			// 
			Command5.BackColor = Drawing.Color.DimGray;
			Command5.FlatAppearance.BorderColor = Drawing.Color.White;
			Command5.FlatAppearance.BorderSize = 0;
			Command5.FlatStyle = Windows.Forms.FlatStyle.Flat;
			Command5.Font = new Drawing.Font("Microsoft Sans Serif", 6f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Command5.ForeColor = Drawing.Color.White;
			Command5.Location = new Drawing.Point(728, 439);
			Command5.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			Command5.Name = "Command5";
			Command5.Size = new Drawing.Size(27, 28);
			Command5.TabIndex = 38;
			Command5.Text = "...";
			Command5.UseVisualStyleBackColor = false;
			// 
			// Label75
			// 
			Label75.AutoSize = true;
			Label75.ForeColor = Drawing.Color.White;
			Label75.Location = new Drawing.Point(539, 441);
			Label75.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label75.Name = "Label75";
			Label75.Size = new Drawing.Size(188, 20);
			Label75.TabIndex = 36;
			Label75.Text = "Identificativo Contable-2";
			// 
			// Command1
			// 
			Command1.BackColor = Drawing.Color.DimGray;
			Command1.FlatAppearance.BorderColor = Drawing.Color.White;
			Command1.FlatAppearance.BorderSize = 0;
			Command1.FlatStyle = Windows.Forms.FlatStyle.Flat;
			Command1.Font = new Drawing.Font("Microsoft Sans Serif", 6f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Command1.ForeColor = Drawing.Color.White;
			Command1.Location = new Drawing.Point(190, 440);
			Command1.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			Command1.Name = "Command1";
			Command1.Size = new Drawing.Size(27, 28);
			Command1.TabIndex = 35;
			Command1.Text = "...";
			Command1.UseVisualStyleBackColor = false;
			// 
			// Label45
			// 
			Label45.AutoSize = true;
			Label45.ForeColor = Drawing.Color.White;
			Label45.Location = new Drawing.Point(4, 442);
			Label45.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label45.Name = "Label45";
			Label45.Size = new Drawing.Size(188, 20);
			Label45.TabIndex = 31;
			Label45.Text = "Identificativo Contable-1";
			// 
			// observacli
			// 
			observacli.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			observacli.Location = new Drawing.Point(136, 486);
			observacli.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			observacli.Name = "observacli";
			observacli.Size = new Drawing.Size(525, 26);
			observacli.TabIndex = 40;
			// 
			// Label44
			// 
			Label44.AutoSize = true;
			Label44.ForeColor = Drawing.Color.White;
			Label44.Location = new Drawing.Point(10, 492);
			Label44.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label44.Name = "Label44";
			Label44.Size = new Drawing.Size(121, 20);
			Label44.TabIndex = 39;
			Label44.Text = "Observaciones";
			// 
			// txtContacto
			// 
			txtContacto.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			txtContacto.Location = new Drawing.Point(129, 114);
			txtContacto.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			txtContacto.Name = "txtContacto";
			txtContacto.Size = new Drawing.Size(635, 26);
			txtContacto.TabIndex = 26;
			// 
			// Label42
			// 
			Label42.AutoSize = true;
			Label42.ForeColor = Drawing.Color.White;
			Label42.Location = new Drawing.Point(24, 120);
			Label42.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label42.Name = "Label42";
			Label42.Size = new Drawing.Size(76, 20);
			Label42.TabIndex = 25;
			Label42.Text = "Contacto";
			// 
			// btnBuscaCobrador
			// 
			btnBuscaCobrador.BackColor = Drawing.Color.DimGray;
			btnBuscaCobrador.FlatAppearance.BorderColor = Drawing.Color.White;
			btnBuscaCobrador.FlatAppearance.BorderSize = 0;
			btnBuscaCobrador.FlatStyle = Windows.Forms.FlatStyle.Flat;
			btnBuscaCobrador.Font = new Drawing.Font("Microsoft Sans Serif", 6f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			btnBuscaCobrador.ForeColor = Drawing.Color.White;
			btnBuscaCobrador.Location = new Drawing.Point(505, 81);
			btnBuscaCobrador.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			btnBuscaCobrador.Name = "btnBuscaCobrador";
			btnBuscaCobrador.Size = new Drawing.Size(27, 28);
			btnBuscaCobrador.TabIndex = 14;
			btnBuscaCobrador.Text = "...";
			btnBuscaCobrador.UseVisualStyleBackColor = false;
			// 
			// Label37
			// 
			Label37.AutoSize = true;
			Label37.ForeColor = Drawing.Color.White;
			Label37.Location = new Drawing.Point(417, 85);
			Label37.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label37.Name = "Label37";
			Label37.Size = new Drawing.Size(78, 20);
			Label37.TabIndex = 12;
			Label37.Text = "Cobrador";
			// 
			// btnBuscaZonaCobro
			// 
			btnBuscaZonaCobro.BackColor = Drawing.Color.DimGray;
			btnBuscaZonaCobro.FlatAppearance.BorderColor = Drawing.Color.White;
			btnBuscaZonaCobro.FlatAppearance.BorderSize = 0;
			btnBuscaZonaCobro.FlatStyle = Windows.Forms.FlatStyle.Flat;
			btnBuscaZonaCobro.Font = new Drawing.Font("Microsoft Sans Serif", 6f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			btnBuscaZonaCobro.ForeColor = Drawing.Color.White;
			btnBuscaZonaCobro.Location = new Drawing.Point(158, 79);
			btnBuscaZonaCobro.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			btnBuscaZonaCobro.Name = "btnBuscaZonaCobro";
			btnBuscaZonaCobro.Size = new Drawing.Size(27, 28);
			btnBuscaZonaCobro.TabIndex = 11;
			btnBuscaZonaCobro.Text = "...";
			btnBuscaZonaCobro.UseVisualStyleBackColor = false;
			// 
			// Label36
			// 
			Label36.AutoSize = true;
			Label36.ForeColor = Drawing.Color.White;
			Label36.Location = new Drawing.Point(3, 85);
			Label36.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label36.Name = "Label36";
			Label36.Size = new Drawing.Size(154, 20);
			Label36.TabIndex = 9;
			Label36.Text = "Zona de Cobranzas";
			// 
			// btnBuscaVendedor
			// 
			btnBuscaVendedor.BackColor = Drawing.Color.DimGray;
			btnBuscaVendedor.FlatAppearance.BorderColor = Drawing.Color.White;
			btnBuscaVendedor.FlatAppearance.BorderSize = 0;
			btnBuscaVendedor.FlatStyle = Windows.Forms.FlatStyle.Flat;
			btnBuscaVendedor.Font = new Drawing.Font("Microsoft Sans Serif", 6f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			btnBuscaVendedor.ForeColor = Drawing.Color.White;
			btnBuscaVendedor.Location = new Drawing.Point(505, 49);
			btnBuscaVendedor.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			btnBuscaVendedor.Name = "btnBuscaVendedor";
			btnBuscaVendedor.Size = new Drawing.Size(27, 28);
			btnBuscaVendedor.TabIndex = 8;
			btnBuscaVendedor.Text = "...";
			btnBuscaVendedor.UseVisualStyleBackColor = false;
			// 
			// Label35
			// 
			Label35.AutoSize = true;
			Label35.ForeColor = Drawing.Color.White;
			Label35.Location = new Drawing.Point(424, 54);
			Label35.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label35.Name = "Label35";
			Label35.Size = new Drawing.Size(80, 20);
			Label35.TabIndex = 6;
			Label35.Text = "Vendedor";
			// 
			// Label34
			// 
			Label34.AutoSize = true;
			Label34.ForeColor = Drawing.Color.White;
			Label34.Location = new Drawing.Point(30, 51);
			Label34.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label34.Name = "Label34";
			Label34.Size = new Drawing.Size(122, 20);
			Label34.TabIndex = 3;
			Label34.Text = "Zona de ventas";
			// 
			// Label33
			// 
			Label33.AutoSize = true;
			Label33.ForeColor = Drawing.Color.White;
			Label33.Location = new Drawing.Point(36, 20);
			Label33.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label33.Name = "Label33";
			Label33.Size = new Drawing.Size(121, 20);
			Label33.TabIndex = 0;
			Label33.Text = "Tipo de Cliente";
			// 
			// tabProveedor
			// 
			tabProveedor.BackColor = Drawing.Color.Gray;
			tabProveedor.Controls.Add(CBuscador8);
			tabProveedor.Controls.Add(GroupBox14);
			tabProveedor.Controls.Add(Lcod8);
			tabProveedor.Controls.Add(Cuenta5);
			tabProveedor.Controls.Add(Cuenta1);
			tabProveedor.Controls.Add(Command6);
			tabProveedor.Controls.Add(Label76);
			tabProveedor.Controls.Add(Label51);
			tabProveedor.Controls.Add(Command2);
			tabProveedor.Controls.Add(Label53);
			tabProveedor.Controls.Add(GroupBox6);
			tabProveedor.Controls.Add(servicios);
			tabProveedor.Controls.Add(producto);
			tabProveedor.Controls.Add(Label50);
			tabProveedor.Controls.Add(incluyetransporte);
			tabProveedor.Controls.Add(limcreditoprv);
			tabProveedor.Controls.Add(Label49);
			tabProveedor.Controls.Add(porcedescuentoprv);
			tabProveedor.Controls.Add(Label48);
			tabProveedor.Controls.Add(Label47);
			tabProveedor.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			tabProveedor.Location = new Drawing.Point(4, 37);
			tabProveedor.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			tabProveedor.Name = "tabProveedor";
			tabProveedor.Size = new Drawing.Size(1268, 717);
			tabProveedor.TabIndex = 2;
			tabProveedor.Text = "Proveedor";
			// 
			// CBuscador8
			// 
			CBuscador8.BackColor = Drawing.Color.DimGray;
			CBuscador8.FlatAppearance.BorderColor = Drawing.Color.White;
			CBuscador8.FlatAppearance.BorderSize = 0;
			CBuscador8.FlatStyle = Windows.Forms.FlatStyle.Flat;
			CBuscador8.Font = new Drawing.Font("Microsoft Sans Serif", 6f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			CBuscador8.ForeColor = Drawing.Color.White;
			CBuscador8.Location = new Drawing.Point(130, 20);
			CBuscador8.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			CBuscador8.Name = "CBuscador8";
			CBuscador8.Size = new Drawing.Size(28, 29);
			CBuscador8.TabIndex = 118;
			CBuscador8.Text = "...";
			CBuscador8.UseVisualStyleBackColor = false;
			// 
			// GroupBox14
			// 
			GroupBox14.Controls.Add(chkTerrestre);
			GroupBox14.Controls.Add(Button6);
			GroupBox14.Controls.Add(chkMaritimo);
			GroupBox14.Controls.Add(chkAereo);
			GroupBox14.Controls.Add(observacionesprv);
			GroupBox14.Controls.Add(Label52);
			GroupBox14.ForeColor = Drawing.Color.Black;
			GroupBox14.Location = new Drawing.Point(9, 321);
			GroupBox14.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			GroupBox14.Name = "GroupBox14";
			GroupBox14.Padding = new Windows.Forms.Padding(4, 5, 4, 5);
			GroupBox14.Size = new Drawing.Size(894, 139);
			GroupBox14.TabIndex = 116;
			GroupBox14.TabStop = false;
			GroupBox14.Text = "Tipo de transporte que ofrece";
			// 
			// chkTerrestre
			// 
			chkTerrestre.AutoSize = true;
			chkTerrestre.ForeColor = Drawing.Color.White;
			chkTerrestre.Location = new Drawing.Point(611, 35);
			chkTerrestre.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			chkTerrestre.Name = "chkTerrestre";
			chkTerrestre.Size = new Drawing.Size(104, 24);
			chkTerrestre.TabIndex = 2;
			chkTerrestre.Text = "Terrestre";
			chkTerrestre.UseVisualStyleBackColor = true;
			// 
			// Button6
			// 
			Button6.BackColor = Drawing.Color.DimGray;
			Button6.FlatAppearance.BorderColor = Drawing.Color.White;
			Button6.FlatAppearance.BorderSize = 0;
			Button6.FlatStyle = Windows.Forms.FlatStyle.Flat;
			Button6.Font = new Drawing.Font("Microsoft Sans Serif", 6f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Button6.ForeColor = Drawing.Color.White;
			Button6.Location = new Drawing.Point(168, 82);
			Button6.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			Button6.Name = "Button6";
			Button6.Size = new Drawing.Size(28, 29);
			Button6.TabIndex = 117;
			Button6.Text = "...";
			Button6.UseVisualStyleBackColor = false;
			// 
			// chkMaritimo
			// 
			chkMaritimo.AutoSize = true;
			chkMaritimo.ForeColor = Drawing.Color.White;
			chkMaritimo.Location = new Drawing.Point(328, 35);
			chkMaritimo.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			chkMaritimo.Name = "chkMaritimo";
			chkMaritimo.Size = new Drawing.Size(100, 24);
			chkMaritimo.TabIndex = 1;
			chkMaritimo.Text = "Marítimo";
			chkMaritimo.UseVisualStyleBackColor = true;
			// 
			// chkAereo
			// 
			chkAereo.AutoSize = true;
			chkAereo.ForeColor = Drawing.Color.White;
			chkAereo.Location = new Drawing.Point(46, 35);
			chkAereo.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			chkAereo.Name = "chkAereo";
			chkAereo.Size = new Drawing.Size(79, 24);
			chkAereo.TabIndex = 0;
			chkAereo.Text = "Aéreo";
			chkAereo.UseVisualStyleBackColor = true;
			// 
			// observacionesprv
			// 
			observacionesprv.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			observacionesprv.Location = new Drawing.Point(198, 82);
			observacionesprv.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			observacionesprv.Name = "observacionesprv";
			observacionesprv.Size = new Drawing.Size(521, 26);
			observacionesprv.TabIndex = 18;
			// 
			// Label52
			// 
			Label52.AutoSize = true;
			Label52.ForeColor = Drawing.Color.White;
			Label52.Location = new Drawing.Point(42, 88);
			Label52.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label52.Name = "Label52";
			Label52.Size = new Drawing.Size(124, 20);
			Label52.TabIndex = 17;
			Label52.Text = "Transportador :";
			// 
			// Lcod8
			// 
			Lcod8.BackColor = Drawing.Color.White;
			Lcod8.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			Lcod8.Location = new Drawing.Point(161, 21);
			Lcod8.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Lcod8.Name = "Lcod8";
			Lcod8.Size = new Drawing.Size(188, 27);
			Lcod8.TabIndex = 115;
			// 
			// Cuenta5
			// 
			Cuenta5.BackColor = Drawing.Color.White;
			Cuenta5.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			Cuenta5.Location = new Drawing.Point(719, 485);
			Cuenta5.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Cuenta5.Name = "Cuenta5";
			Cuenta5.Size = new Drawing.Size(188, 27);
			Cuenta5.TabIndex = 114;
			// 
			// Cuenta1
			// 
			Cuenta1.BackColor = Drawing.Color.White;
			Cuenta1.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			Cuenta1.Location = new Drawing.Point(217, 482);
			Cuenta1.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Cuenta1.Name = "Cuenta1";
			Cuenta1.Size = new Drawing.Size(188, 27);
			Cuenta1.TabIndex = 113;
			// 
			// Command6
			// 
			Command6.BackColor = Drawing.Color.DimGray;
			Command6.FlatAppearance.BorderColor = Drawing.Color.White;
			Command6.FlatAppearance.BorderSize = 0;
			Command6.FlatStyle = Windows.Forms.FlatStyle.Flat;
			Command6.Font = new Drawing.Font("Microsoft Sans Serif", 6f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Command6.ForeColor = Drawing.Color.White;
			Command6.Location = new Drawing.Point(688, 482);
			Command6.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			Command6.Name = "Command6";
			Command6.Size = new Drawing.Size(28, 29);
			Command6.TabIndex = 26;
			Command6.Text = "...";
			Command6.UseVisualStyleBackColor = false;
			// 
			// Label76
			// 
			Label76.AutoSize = true;
			Label76.ForeColor = Drawing.Color.White;
			Label76.Location = new Drawing.Point(504, 486);
			Label76.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label76.Name = "Label76";
			Label76.Size = new Drawing.Size(188, 20);
			Label76.TabIndex = 24;
			Label76.Text = "Identificativo Contable-2";
			// 
			// Label51
			// 
			Label51.AutoSize = true;
			Label51.ForeColor = Drawing.Color.White;
			Label51.Location = new Drawing.Point(4, 172);
			Label51.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label51.Name = "Label51";
			Label51.Size = new Drawing.Size(167, 20);
			Label51.TabIndex = 23;
			Label51.Text = "Servicios que Provee";
			// 
			// Command2
			// 
			Command2.BackColor = Drawing.Color.DimGray;
			Command2.FlatAppearance.BorderColor = Drawing.Color.White;
			Command2.FlatAppearance.BorderSize = 0;
			Command2.FlatStyle = Windows.Forms.FlatStyle.Flat;
			Command2.Font = new Drawing.Font("Microsoft Sans Serif", 6f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Command2.ForeColor = Drawing.Color.White;
			Command2.Location = new Drawing.Point(188, 481);
			Command2.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			Command2.Name = "Command2";
			Command2.Size = new Drawing.Size(28, 29);
			Command2.TabIndex = 22;
			Command2.Text = "...";
			Command2.UseVisualStyleBackColor = false;
			// 
			// Label53
			// 
			Label53.AutoSize = true;
			Label53.ForeColor = Drawing.Color.White;
			Label53.Location = new Drawing.Point(4, 486);
			Label53.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label53.Name = "Label53";
			Label53.Size = new Drawing.Size(188, 20);
			Label53.TabIndex = 20;
			Label53.Text = "Identificativo Contable-1";
			// 
			// GroupBox6
			// 
			GroupBox6.Controls.Add(chkRetirarTransporte);
			GroupBox6.Controls.Add(chkRetirarProveedor);
			GroupBox6.Controls.Add(chkEntregaDirecccion);
			GroupBox6.ForeColor = Drawing.Color.Black;
			GroupBox6.Location = new Drawing.Point(9, 215);
			GroupBox6.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			GroupBox6.Name = "GroupBox6";
			GroupBox6.Padding = new Windows.Forms.Padding(4, 5, 4, 5);
			GroupBox6.Size = new Drawing.Size(894, 85);
			GroupBox6.TabIndex = 16;
			GroupBox6.TabStop = false;
			GroupBox6.Text = "Lugar de Entrega de Productos o Servicios";
			// 
			// chkRetirarTransporte
			// 
			chkRetirarTransporte.AutoSize = true;
			chkRetirarTransporte.ForeColor = Drawing.Color.White;
			chkRetirarTransporte.Location = new Drawing.Point(611, 35);
			chkRetirarTransporte.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			chkRetirarTransporte.Name = "chkRetirarTransporte";
			chkRetirarTransporte.Size = new Drawing.Size(261, 24);
			chkRetirarTransporte.TabIndex = 2;
			chkRetirarTransporte.Text = "Retirar del transporte de envío";
			chkRetirarTransporte.UseVisualStyleBackColor = true;
			// 
			// chkRetirarProveedor
			// 
			chkRetirarProveedor.AutoSize = true;
			chkRetirarProveedor.ForeColor = Drawing.Color.White;
			chkRetirarProveedor.Location = new Drawing.Point(328, 35);
			chkRetirarProveedor.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			chkRetirarProveedor.Name = "chkRetirarProveedor";
			chkRetirarProveedor.Size = new Drawing.Size(194, 24);
			chkRetirarProveedor.TabIndex = 1;
			chkRetirarProveedor.Text = "Retirar del Proveedor";
			chkRetirarProveedor.UseVisualStyleBackColor = true;
			// 
			// chkEntregaDirecccion
			// 
			chkEntregaDirecccion.AutoSize = true;
			chkEntregaDirecccion.ForeColor = Drawing.Color.White;
			chkEntregaDirecccion.Location = new Drawing.Point(46, 35);
			chkEntregaDirecccion.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			chkEntregaDirecccion.Name = "chkEntregaDirecccion";
			chkEntregaDirecccion.Size = new Drawing.Size(189, 24);
			chkEntregaDirecccion.TabIndex = 0;
			chkEntregaDirecccion.Text = "En nuestra dirección";
			chkEntregaDirecccion.UseVisualStyleBackColor = true;
			// 
			// servicios
			// 
			servicios.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			servicios.Location = new Drawing.Point(194, 168);
			servicios.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			servicios.Name = "servicios";
			servicios.Size = new Drawing.Size(707, 26);
			servicios.TabIndex = 15;
			// 
			// producto
			// 
			producto.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			producto.Location = new Drawing.Point(194, 119);
			producto.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			producto.Name = "producto";
			producto.Size = new Drawing.Size(707, 26);
			producto.TabIndex = 12;
			// 
			// Label50
			// 
			Label50.AutoSize = true;
			Label50.ForeColor = Drawing.Color.White;
			Label50.Location = new Drawing.Point(4, 120);
			Label50.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label50.Name = "Label50";
			Label50.Size = new Drawing.Size(174, 20);
			Label50.TabIndex = 11;
			Label50.Text = "Productos que Provee";
			// 
			// incluyetransporte
			// 
			incluyetransporte.AutoSize = true;
			incluyetransporte.CheckAlign = Drawing.ContentAlignment.MiddleRight;
			incluyetransporte.ForeColor = Drawing.Color.White;
			incluyetransporte.Location = new Drawing.Point(690, 25);
			incluyetransporte.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			incluyetransporte.Name = "incluyetransporte";
			incluyetransporte.Size = new Drawing.Size(221, 24);
			incluyetransporte.TabIndex = 10;
			incluyetransporte.Text = "Precio incluye transporte";
			incluyetransporte.TextAlign = Drawing.ContentAlignment.MiddleCenter;
			incluyetransporte.UseVisualStyleBackColor = true;
			// 
			// limcreditoprv
			// 
			limcreditoprv.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			limcreditoprv.Location = new Drawing.Point(170, 74);
			limcreditoprv.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			limcreditoprv.MaxLength = 8;
			limcreditoprv.Name = "limcreditoprv";
			limcreditoprv.Size = new Drawing.Size(181, 26);
			limcreditoprv.TabIndex = 9;
			// 
			// Label49
			// 
			Label49.AutoSize = true;
			Label49.ForeColor = Drawing.Color.White;
			Label49.Location = new Drawing.Point(4, 75);
			Label49.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label49.Name = "Label49";
			Label49.Size = new Drawing.Size(134, 20);
			Label49.TabIndex = 8;
			Label49.Text = "Límite de credito";
			// 
			// porcedescuentoprv
			// 
			porcedescuentoprv.Location = new Drawing.Point(586, 19);
			porcedescuentoprv.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			porcedescuentoprv.Name = "porcedescuentoprv";
			porcedescuentoprv.Size = new Drawing.Size(52, 26);
			porcedescuentoprv.TabIndex = 7;
			// 
			// Label48
			// 
			Label48.AutoSize = true;
			Label48.ForeColor = Drawing.Color.White;
			Label48.Location = new Drawing.Point(390, 25);
			Label48.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label48.Name = "Label48";
			Label48.Size = new Drawing.Size(194, 20);
			Label48.TabIndex = 6;
			Label48.Text = "Porcentaje de descuento";
			// 
			// Label47
			// 
			Label47.AutoSize = true;
			Label47.ForeColor = Drawing.Color.White;
			Label47.Location = new Drawing.Point(4, 25);
			Label47.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label47.Name = "Label47";
			Label47.Size = new Drawing.Size(123, 20);
			Label47.TabIndex = 3;
			Label47.Text = "Forma de Pago";
			// 
			// tabEmpleado
			// 
			tabEmpleado.BackColor = Drawing.Color.Gray;
			tabEmpleado.Controls.Add(cmbSucursalRol);
			tabEmpleado.Controls.Add(cmbDepartamentoRol);
			tabEmpleado.Controls.Add(cmbCargoRol);
			tabEmpleado.Controls.Add(TabDatosEmpleado);
			tabEmpleado.Controls.Add(btnCargarCapacitacion);
			tabEmpleado.Controls.Add(fJubilacion);
			tabEmpleado.Controls.Add(fsalida);
			tabEmpleado.Controls.Add(fingreso);
			tabEmpleado.Controls.Add(Label81);
			tabEmpleado.Controls.Add(Button7);
			tabEmpleado.Controls.Add(Cuenta3);
			tabEmpleado.Controls.Add(CodBimetrico);
			tabEmpleado.Controls.Add(Cuenta2);
			tabEmpleado.Controls.Add(GroupBox9);
			tabEmpleado.Controls.Add(Comctb2);
			tabEmpleado.Controls.Add(Label63);
			tabEmpleado.Controls.Add(ComCtb1);
			tabEmpleado.Controls.Add(Label62);
			tabEmpleado.Controls.Add(Label61);
			tabEmpleado.Controls.Add(Label60);
			tabEmpleado.Controls.Add(GroupBox7);
			tabEmpleado.Controls.Add(GroupBox8);
			tabEmpleado.Controls.Add(nivelrol);
			tabEmpleado.Controls.Add(Label74);
			tabEmpleado.Controls.Add(Label87);
			tabEmpleado.Controls.Add(cmbCentroCostoRol);
			tabEmpleado.Controls.Add(cmbModuloRol);
			tabEmpleado.Controls.Add(cmbSeccionRol);
			tabEmpleado.Controls.Add(Label58);
			tabEmpleado.Controls.Add(Label55);
			tabEmpleado.Controls.Add(Label59);
			tabEmpleado.Controls.Add(Label56);
			tabEmpleado.Controls.Add(Label57);
			tabEmpleado.Controls.Add(Label54);
			tabEmpleado.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			tabEmpleado.Location = new Drawing.Point(4, 37);
			tabEmpleado.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			tabEmpleado.Name = "tabEmpleado";
			tabEmpleado.Size = new Drawing.Size(1268, 717);
			tabEmpleado.TabIndex = 3;
			tabEmpleado.Text = "Empleado";
			// 
			// cmbSucursalRol
			// 
			cmbSucursalRol.AutoCompleteMode = Windows.Forms.AutoCompleteMode.SuggestAppend;
			cmbSucursalRol.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems;
			cmbSucursalRol.FlatStyle = Windows.Forms.FlatStyle.Flat;
			cmbSucursalRol.FormattingEnabled = true;
			cmbSucursalRol.Location = new Drawing.Point(15, 82);
			cmbSucursalRol.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			cmbSucursalRol.Name = "cmbSucursalRol";
			cmbSucursalRol.Size = new Drawing.Size(229, 28);
			cmbSucursalRol.TabIndex = 125;
			// 
			// cmbDepartamentoRol
			// 
			cmbDepartamentoRol.AutoCompleteMode = Windows.Forms.AutoCompleteMode.SuggestAppend;
			cmbDepartamentoRol.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems;
			cmbDepartamentoRol.FlatStyle = Windows.Forms.FlatStyle.Flat;
			cmbDepartamentoRol.FormattingEnabled = true;
			cmbDepartamentoRol.Location = new Drawing.Point(276, 82);
			cmbDepartamentoRol.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			cmbDepartamentoRol.Name = "cmbDepartamentoRol";
			cmbDepartamentoRol.Size = new Drawing.Size(229, 28);
			cmbDepartamentoRol.TabIndex = 124;
			// 
			// cmbCargoRol
			// 
			cmbCargoRol.AutoCompleteMode = Windows.Forms.AutoCompleteMode.SuggestAppend;
			cmbCargoRol.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems;
			cmbCargoRol.FlatStyle = Windows.Forms.FlatStyle.Flat;
			cmbCargoRol.FormattingEnabled = true;
			cmbCargoRol.Location = new Drawing.Point(534, 82);
			cmbCargoRol.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			cmbCargoRol.Name = "cmbCargoRol";
			cmbCargoRol.Size = new Drawing.Size(229, 28);
			cmbCargoRol.TabIndex = 123;
			// 
			// TabDatosEmpleado
			// 
			TabDatosEmpleado.Controls.Add(TabPage1);
			TabDatosEmpleado.Controls.Add(TabPage2);
			TabDatosEmpleado.Location = new Drawing.Point(774, 71);
			TabDatosEmpleado.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			TabDatosEmpleado.Name = "TabDatosEmpleado";
			TabDatosEmpleado.SelectedIndex = 0;
			TabDatosEmpleado.Size = new Drawing.Size(514, 451);
			TabDatosEmpleado.TabIndex = 116;
			// 
			// TabPage1
			// 
			TabPage1.Controls.Add(mallaDatos);
			TabPage1.Location = new Drawing.Point(4, 29);
			TabPage1.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			TabPage1.Name = "TabPage1";
			TabPage1.Padding = new Windows.Forms.Padding(4, 5, 4, 5);
			TabPage1.Size = new Drawing.Size(506, 418);
			TabPage1.TabIndex = 0;
			TabPage1.Text = "Datos adicionales del trabajador";
			TabPage1.UseVisualStyleBackColor = true;
			// 
			// mallaDatos
			// 
			mallaDatos.AllowUserToAddRows = false;
			mallaDatos.AllowUserToResizeRows = false;
			mallaDatos.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
			mallaDatos.BackgroundColor = Drawing.Color.White;
			mallaDatos.BorderStyle = Windows.Forms.BorderStyle.None;
			mallaDatos.CausesValidation = false;
			mallaDatos.ClipboardCopyMode = Windows.Forms.DataGridViewClipboardCopyMode.Disable;
			mallaDatos.ColumnHeadersHeightSizeMode = Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			mallaDatos.ColumnHeadersVisible = false;
			mallaDatos.Columns.AddRange(new Windows.Forms.DataGridViewColumn[] { Campos1, valorcampo });
			dataGridViewCellStyle31.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle31.BackColor = Drawing.Color.White;
			dataGridViewCellStyle31.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle31.ForeColor = Drawing.Color.Black;
			dataGridViewCellStyle31.SelectionBackColor = Drawing.SystemColors.Highlight;
			dataGridViewCellStyle31.SelectionForeColor = Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle31.WrapMode = Windows.Forms.DataGridViewTriState.False;
			mallaDatos.DefaultCellStyle = dataGridViewCellStyle31;
			mallaDatos.Dock = Windows.Forms.DockStyle.Fill;
			mallaDatos.EditMode = Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
			mallaDatos.EnableHeadersVisualStyles = false;
			mallaDatos.GridColor = Drawing.Color.FromArgb(224, 224, 224);
			mallaDatos.Location = new Drawing.Point(4, 5);
			mallaDatos.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			mallaDatos.MultiSelect = false;
			mallaDatos.Name = "mallaDatos";
			dataGridViewCellStyle32.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle32.BackColor = Drawing.Color.FromArgb(225, 231, 247);
			dataGridViewCellStyle32.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle32.ForeColor = Drawing.Color.Black;
			dataGridViewCellStyle32.SelectionBackColor = Drawing.SystemColors.Highlight;
			dataGridViewCellStyle32.SelectionForeColor = Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle32.WrapMode = Windows.Forms.DataGridViewTriState.True;
			mallaDatos.RowHeadersDefaultCellStyle = dataGridViewCellStyle32;
			mallaDatos.RowHeadersWidth = 51;
			mallaDatos.ScrollBars = Windows.Forms.ScrollBars.Vertical;
			mallaDatos.SelectionMode = Windows.Forms.DataGridViewSelectionMode.CellSelect;
			mallaDatos.ShowCellToolTips = false;
			mallaDatos.ShowEditingIcon = false;
			mallaDatos.ShowRowErrors = false;
			mallaDatos.Size = new Drawing.Size(498, 408);
			mallaDatos.TabIndex = 46;
			// 
			// Campos1
			// 
			Campos1.HeaderText = "Campo1";
			Campos1.MinimumWidth = 6;
			Campos1.Name = "Campos1";
			Campos1.Width = 6;
			// 
			// valorcampo
			// 
			valorcampo.HeaderText = "Valor";
			valorcampo.MinimumWidth = 6;
			valorcampo.Name = "valorcampo";
			valorcampo.Width = 6;
			// 
			// TabPage2
			// 
			TabPage2.Controls.Add(mallaConceptos);
			TabPage2.Location = new Drawing.Point(4, 29);
			TabPage2.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			TabPage2.Name = "TabPage2";
			TabPage2.Padding = new Windows.Forms.Padding(4, 5, 4, 5);
			TabPage2.Size = new Drawing.Size(506, 418);
			TabPage2.TabIndex = 1;
			TabPage2.Text = "Asignar Conceptos de Nómina";
			TabPage2.UseVisualStyleBackColor = true;
			// 
			// mallaConceptos
			// 
			mallaConceptos.AllowUserToAddRows = false;
			mallaConceptos.AllowUserToResizeRows = false;
			mallaConceptos.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
			mallaConceptos.BackgroundColor = Drawing.Color.White;
			mallaConceptos.BorderStyle = Windows.Forms.BorderStyle.None;
			mallaConceptos.CausesValidation = false;
			mallaConceptos.ClipboardCopyMode = Windows.Forms.DataGridViewClipboardCopyMode.Disable;
			mallaConceptos.ColumnHeadersHeightSizeMode = Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			mallaConceptos.ColumnHeadersVisible = false;
			mallaConceptos.Columns.AddRange(new Windows.Forms.DataGridViewColumn[] { DataGridViewTextBoxColumn1, conceptoSeleccionado });
			dataGridViewCellStyle33.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle33.BackColor = Drawing.Color.White;
			dataGridViewCellStyle33.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle33.ForeColor = Drawing.Color.Black;
			dataGridViewCellStyle33.SelectionBackColor = Drawing.SystemColors.Highlight;
			dataGridViewCellStyle33.SelectionForeColor = Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle33.WrapMode = Windows.Forms.DataGridViewTriState.False;
			mallaConceptos.DefaultCellStyle = dataGridViewCellStyle33;
			mallaConceptos.Dock = Windows.Forms.DockStyle.Fill;
			mallaConceptos.EditMode = Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
			mallaConceptos.EnableHeadersVisualStyles = false;
			mallaConceptos.GridColor = Drawing.Color.FromArgb(224, 224, 224);
			mallaConceptos.Location = new Drawing.Point(4, 5);
			mallaConceptos.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			mallaConceptos.MultiSelect = false;
			mallaConceptos.Name = "mallaConceptos";
			dataGridViewCellStyle34.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle34.BackColor = Drawing.Color.FromArgb(225, 231, 247);
			dataGridViewCellStyle34.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle34.ForeColor = Drawing.Color.Black;
			dataGridViewCellStyle34.SelectionBackColor = Drawing.SystemColors.Highlight;
			dataGridViewCellStyle34.SelectionForeColor = Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle34.WrapMode = Windows.Forms.DataGridViewTriState.True;
			mallaConceptos.RowHeadersDefaultCellStyle = dataGridViewCellStyle34;
			mallaConceptos.RowHeadersWidth = 51;
			mallaConceptos.ScrollBars = Windows.Forms.ScrollBars.Vertical;
			mallaConceptos.SelectionMode = Windows.Forms.DataGridViewSelectionMode.CellSelect;
			mallaConceptos.ShowCellToolTips = false;
			mallaConceptos.ShowEditingIcon = false;
			mallaConceptos.ShowRowErrors = false;
			mallaConceptos.Size = new Drawing.Size(498, 408);
			mallaConceptos.TabIndex = 48;
			// 
			// DataGridViewTextBoxColumn1
			// 
			DataGridViewTextBoxColumn1.HeaderText = "Campo1";
			DataGridViewTextBoxColumn1.MinimumWidth = 6;
			DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1";
			DataGridViewTextBoxColumn1.Width = 6;
			// 
			// conceptoSeleccionado
			// 
			conceptoSeleccionado.HeaderText = "Seleccionar";
			conceptoSeleccionado.MinimumWidth = 6;
			conceptoSeleccionado.Name = "conceptoSeleccionado";
			conceptoSeleccionado.Width = 6;
			// 
			// btnCargarCapacitacion
			// 
			btnCargarCapacitacion.BackColor = Drawing.Color.SteelBlue;
			btnCargarCapacitacion.FlatStyle = Windows.Forms.FlatStyle.Flat;
			btnCargarCapacitacion.ForeColor = Drawing.Color.White;
			btnCargarCapacitacion.Location = new Drawing.Point(1122, 545);
			btnCargarCapacitacion.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			btnCargarCapacitacion.Name = "btnCargarCapacitacion";
			btnCargarCapacitacion.Size = new Drawing.Size(166, 54);
			btnCargarCapacitacion.TabIndex = 34;
			btnCargarCapacitacion.Text = "Capacitación";
			btnCargarCapacitacion.UseVisualStyleBackColor = false;
			// 
			// fJubilacion
			// 
			fJubilacion.Format = Windows.Forms.DateTimePickerFormat.Short;
			fJubilacion.Location = new Drawing.Point(1097, 32);
			fJubilacion.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			fJubilacion.Name = "fJubilacion";
			fJubilacion.Size = new Drawing.Size(127, 26);
			fJubilacion.TabIndex = 122;
			fJubilacion.Value = new DateTime(1900, 1, 1, 0, 0, 0, 0);
			// 
			// fsalida
			// 
			fsalida.Format = Windows.Forms.DateTimePickerFormat.Short;
			fsalida.Location = new Drawing.Point(937, 32);
			fsalida.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			fsalida.Name = "fsalida";
			fsalida.Size = new Drawing.Size(127, 26);
			fsalida.TabIndex = 121;
			fsalida.Value = new DateTime(1900, 1, 1, 0, 0, 0, 0);
			// 
			// fingreso
			// 
			fingreso.Format = Windows.Forms.DateTimePickerFormat.Short;
			fingreso.Location = new Drawing.Point(774, 31);
			fingreso.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			fingreso.Name = "fingreso";
			fingreso.Size = new Drawing.Size(127, 26);
			fingreso.TabIndex = 120;
			fingreso.Value = new DateTime(1900, 1, 1, 0, 0, 0, 0);
			// 
			// Label81
			// 
			Label81.AutoSize = true;
			Label81.ForeColor = Drawing.Color.White;
			Label81.Location = new Drawing.Point(1092, 15);
			Label81.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label81.Name = "Label81";
			Label81.Size = new Drawing.Size(121, 20);
			Label81.TabIndex = 118;
			Label81.Text = "Fec. Jubilacion";
			// 
			// Button7
			// 
			Button7.BackColor = Drawing.Color.SteelBlue;
			Button7.FlatStyle = Windows.Forms.FlatStyle.Flat;
			Button7.ForeColor = Drawing.Color.White;
			Button7.Location = new Drawing.Point(951, 545);
			Button7.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			Button7.Name = "Button7";
			Button7.Size = new Drawing.Size(166, 54);
			Button7.TabIndex = 117;
			Button7.Text = "Retenciones";
			Button7.UseVisualStyleBackColor = false;
			Button7.Visible = false;
			// 
			// Cuenta3
			// 
			Cuenta3.BackColor = Drawing.Color.White;
			Cuenta3.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			Cuenta3.Location = new Drawing.Point(622, 542);
			Cuenta3.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Cuenta3.Name = "Cuenta3";
			Cuenta3.Size = new Drawing.Size(188, 27);
			Cuenta3.TabIndex = 115;
			// 
			// CodBimetrico
			// 
			CodBimetrico.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			CodBimetrico.ForeColor = Drawing.Color.Black;
			CodBimetrico.Location = new Drawing.Point(602, 35);
			CodBimetrico.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			CodBimetrico.Name = "CodBimetrico";
			CodBimetrico.Size = new Drawing.Size(149, 26);
			CodBimetrico.TabIndex = 51;
			// 
			// Cuenta2
			// 
			Cuenta2.BackColor = Drawing.Color.White;
			Cuenta2.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			Cuenta2.Location = new Drawing.Point(220, 545);
			Cuenta2.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Cuenta2.Name = "Cuenta2";
			Cuenta2.Size = new Drawing.Size(188, 27);
			Cuenta2.TabIndex = 115;
			// 
			// GroupBox9
			// 
			GroupBox9.Controls.Add(Grupo6);
			GroupBox9.Controls.Add(Label73);
			GroupBox9.Controls.Add(Grupo5);
			GroupBox9.Controls.Add(Label72);
			GroupBox9.Controls.Add(Grupo4);
			GroupBox9.Controls.Add(Label71);
			GroupBox9.Controls.Add(Grupo3);
			GroupBox9.Controls.Add(Label70);
			GroupBox9.Controls.Add(Grupo2);
			GroupBox9.Controls.Add(Label69);
			GroupBox9.Controls.Add(Grupo1);
			GroupBox9.Controls.Add(Label68);
			GroupBox9.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point, 0);
			GroupBox9.ForeColor = Drawing.Color.Black;
			GroupBox9.Location = new Drawing.Point(14, 426);
			GroupBox9.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			GroupBox9.Name = "GroupBox9";
			GroupBox9.Padding = new Windows.Forms.Padding(4, 5, 4, 5);
			GroupBox9.Size = new Drawing.Size(742, 100);
			GroupBox9.TabIndex = 36;
			GroupBox9.TabStop = false;
			GroupBox9.Text = "Claves para Agrupación";
			// 
			// Grupo6
			// 
			Grupo6.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			Grupo6.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Grupo6.ForeColor = Drawing.Color.Black;
			Grupo6.Location = new Drawing.Point(681, 61);
			Grupo6.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			Grupo6.Name = "Grupo6";
			Grupo6.Size = new Drawing.Size(37, 26);
			Grupo6.TabIndex = 19;
			// 
			// Label73
			// 
			Label73.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Label73.ForeColor = Drawing.Color.White;
			Label73.Location = new Drawing.Point(489, 69);
			Label73.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label73.Name = "Label73";
			Label73.Size = new Drawing.Size(180, 20);
			Label73.TabIndex = 18;
			Label73.Text = "Grupo-6";
			// 
			// Grupo5
			// 
			Grupo5.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			Grupo5.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Grupo5.ForeColor = Drawing.Color.Black;
			Grupo5.Location = new Drawing.Point(433, 61);
			Grupo5.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			Grupo5.Name = "Grupo5";
			Grupo5.Size = new Drawing.Size(37, 26);
			Grupo5.TabIndex = 17;
			// 
			// Label72
			// 
			Label72.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Label72.ForeColor = Drawing.Color.White;
			Label72.Location = new Drawing.Point(248, 68);
			Label72.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label72.Name = "Label72";
			Label72.Size = new Drawing.Size(180, 20);
			Label72.TabIndex = 16;
			Label72.Text = "Grupo-5";
			// 
			// Grupo4
			// 
			Grupo4.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			Grupo4.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Grupo4.ForeColor = Drawing.Color.Black;
			Grupo4.Location = new Drawing.Point(194, 61);
			Grupo4.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			Grupo4.Name = "Grupo4";
			Grupo4.Size = new Drawing.Size(37, 26);
			Grupo4.TabIndex = 15;
			// 
			// Label71
			// 
			Label71.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Label71.ForeColor = Drawing.Color.White;
			Label71.Location = new Drawing.Point(3, 68);
			Label71.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label71.Name = "Label71";
			Label71.Size = new Drawing.Size(180, 20);
			Label71.TabIndex = 14;
			Label71.Text = "Grupo-4";
			// 
			// Grupo3
			// 
			Grupo3.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			Grupo3.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Grupo3.ForeColor = Drawing.Color.Black;
			Grupo3.Location = new Drawing.Point(681, 26);
			Grupo3.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			Grupo3.Name = "Grupo3";
			Grupo3.Size = new Drawing.Size(37, 26);
			Grupo3.TabIndex = 13;
			// 
			// Label70
			// 
			Label70.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Label70.ForeColor = Drawing.Color.White;
			Label70.Location = new Drawing.Point(487, 34);
			Label70.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label70.Name = "Label70";
			Label70.Size = new Drawing.Size(180, 20);
			Label70.TabIndex = 12;
			Label70.Text = "Grupo-3";
			// 
			// Grupo2
			// 
			Grupo2.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			Grupo2.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Grupo2.ForeColor = Drawing.Color.Black;
			Grupo2.Location = new Drawing.Point(433, 28);
			Grupo2.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			Grupo2.Name = "Grupo2";
			Grupo2.Size = new Drawing.Size(37, 26);
			Grupo2.TabIndex = 11;
			// 
			// Label69
			// 
			Label69.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Label69.ForeColor = Drawing.Color.White;
			Label69.Location = new Drawing.Point(248, 34);
			Label69.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label69.Name = "Label69";
			Label69.Size = new Drawing.Size(180, 20);
			Label69.TabIndex = 10;
			Label69.Text = "Grupo-2";
			// 
			// Grupo1
			// 
			Grupo1.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			Grupo1.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Grupo1.ForeColor = Drawing.Color.Black;
			Grupo1.Location = new Drawing.Point(195, 28);
			Grupo1.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			Grupo1.Name = "Grupo1";
			Grupo1.Size = new Drawing.Size(37, 26);
			Grupo1.TabIndex = 9;
			// 
			// Label68
			// 
			Label68.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Label68.ForeColor = Drawing.Color.White;
			Label68.Location = new Drawing.Point(4, 34);
			Label68.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label68.Name = "Label68";
			Label68.Size = new Drawing.Size(180, 20);
			Label68.TabIndex = 8;
			Label68.Text = "Grupo-1";
			// 
			// Comctb2
			// 
			Comctb2.BackColor = Drawing.Color.Transparent;
			Comctb2.FlatAppearance.BorderSize = 0;
			Comctb2.FlatStyle = Windows.Forms.FlatStyle.Flat;
			Comctb2.Font = new Drawing.Font("Microsoft Sans Serif", 6f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Comctb2.ForeColor = Drawing.Color.White;
			Comctb2.Image = (Drawing.Image)resources.GetObject("Comctb2.Image");
			Comctb2.Location = new Drawing.Point(593, 541);
			Comctb2.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			Comctb2.Name = "Comctb2";
			Comctb2.Size = new Drawing.Size(27, 28);
			Comctb2.TabIndex = 32;
			Comctb2.UseVisualStyleBackColor = false;
			// 
			// Label63
			// 
			Label63.AutoSize = true;
			Label63.ForeColor = Drawing.Color.White;
			Label63.Location = new Drawing.Point(415, 548);
			Label63.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label63.Name = "Label63";
			Label63.Size = new Drawing.Size(182, 20);
			Label63.TabIndex = 30;
			Label63.Text = "Identificativo Contable2";
			// 
			// ComCtb1
			// 
			ComCtb1.BackColor = Drawing.Color.Transparent;
			ComCtb1.FlatAppearance.BorderSize = 0;
			ComCtb1.FlatStyle = Windows.Forms.FlatStyle.Flat;
			ComCtb1.Font = new Drawing.Font("Microsoft Sans Serif", 6f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			ComCtb1.ForeColor = Drawing.Color.White;
			ComCtb1.Image = (Drawing.Image)resources.GetObject("ComCtb1.Image");
			ComCtb1.Location = new Drawing.Point(189, 541);
			ComCtb1.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			ComCtb1.Name = "ComCtb1";
			ComCtb1.Size = new Drawing.Size(27, 28);
			ComCtb1.TabIndex = 29;
			ComCtb1.UseVisualStyleBackColor = false;
			// 
			// Label62
			// 
			Label62.AutoSize = true;
			Label62.ForeColor = Drawing.Color.White;
			Label62.Location = new Drawing.Point(12, 548);
			Label62.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label62.Name = "Label62";
			Label62.Size = new Drawing.Size(182, 20);
			Label62.TabIndex = 27;
			Label62.Text = "Identificativo Contable1";
			// 
			// Label61
			// 
			Label61.AutoSize = true;
			Label61.ForeColor = Drawing.Color.White;
			Label61.Location = new Drawing.Point(933, 15);
			Label61.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label61.Name = "Label61";
			Label61.Size = new Drawing.Size(106, 20);
			Label61.TabIndex = 24;
			Label61.Text = "Fecha Salida";
			// 
			// Label60
			// 
			Label60.AutoSize = true;
			Label60.ForeColor = Drawing.Color.White;
			Label60.Location = new Drawing.Point(771, 14);
			Label60.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label60.Name = "Label60";
			Label60.Size = new Drawing.Size(115, 20);
			Label60.TabIndex = 22;
			Label60.Text = "Fecha Ingreso";
			// 
			// GroupBox7
			// 
			GroupBox7.Controls.Add(Jubilado);
			GroupBox7.Controls.Add(Eliminadorol);
			GroupBox7.Controls.Add(Cesanterol);
			GroupBox7.Controls.Add(activorol);
			GroupBox7.Location = new Drawing.Point(12, 8);
			GroupBox7.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			GroupBox7.Name = "GroupBox7";
			GroupBox7.Padding = new Windows.Forms.Padding(4, 5, 4, 5);
			GroupBox7.Size = new Drawing.Size(582, 55);
			GroupBox7.TabIndex = 15;
			GroupBox7.TabStop = false;
			GroupBox7.Text = "Estado";
			// 
			// Jubilado
			// 
			Jubilado.AutoSize = true;
			Jubilado.ForeColor = Drawing.Color.White;
			Jubilado.Location = new Drawing.Point(266, 21);
			Jubilado.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			Jubilado.Name = "Jubilado";
			Jubilado.Size = new Drawing.Size(96, 24);
			Jubilado.TabIndex = 3;
			Jubilado.Text = "Jubilado";
			Jubilado.UseVisualStyleBackColor = true;
			// 
			// Eliminadorol
			// 
			Eliminadorol.AutoSize = true;
			Eliminadorol.ForeColor = Drawing.Color.White;
			Eliminadorol.Location = new Drawing.Point(417, 21);
			Eliminadorol.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			Eliminadorol.Name = "Eliminadorol";
			Eliminadorol.Size = new Drawing.Size(107, 24);
			Eliminadorol.TabIndex = 2;
			Eliminadorol.Text = "Eliminado";
			Eliminadorol.UseVisualStyleBackColor = true;
			// 
			// Cesanterol
			// 
			Cesanterol.AutoSize = true;
			Cesanterol.ForeColor = Drawing.Color.White;
			Cesanterol.Location = new Drawing.Point(138, 21);
			Cesanterol.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			Cesanterol.Name = "Cesanterol";
			Cesanterol.Size = new Drawing.Size(96, 24);
			Cesanterol.TabIndex = 1;
			Cesanterol.Text = "Cesante";
			Cesanterol.UseVisualStyleBackColor = true;
			// 
			// activorol
			// 
			activorol.AutoSize = true;
			activorol.Checked = true;
			activorol.ForeColor = Drawing.Color.White;
			activorol.Location = new Drawing.Point(19, 21);
			activorol.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			activorol.Name = "activorol";
			activorol.Size = new Drawing.Size(80, 24);
			activorol.TabIndex = 0;
			activorol.TabStop = true;
			activorol.Text = "Activo";
			activorol.UseVisualStyleBackColor = true;
			// 
			// GroupBox8
			// 
			GroupBox8.Controls.Add(Lcod11);
			GroupBox8.Controls.Add(txtHorasJornadaSemanal);
			GroupBox8.Controls.Add(valorsueldo);
			GroupBox8.Controls.Add(Label65);
			GroupBox8.Controls.Add(CBuscador11);
			GroupBox8.Controls.Add(Label64);
			GroupBox8.Controls.Add(RolHoras);
			GroupBox8.Controls.Add(rolproduccion);
			GroupBox8.Controls.Add(roldiario);
			GroupBox8.Controls.Add(rolmensual);
			GroupBox8.Controls.Add(GroupBox10);
			GroupBox8.Controls.Add(Label92);
			GroupBox8.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Bold, Drawing.GraphicsUnit.Point, 0);
			GroupBox8.ForeColor = Drawing.Color.Black;
			GroupBox8.Location = new Drawing.Point(17, 199);
			GroupBox8.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			GroupBox8.Name = "GroupBox8";
			GroupBox8.Padding = new Windows.Forms.Padding(4, 5, 4, 5);
			GroupBox8.Size = new Drawing.Size(739, 215);
			GroupBox8.TabIndex = 35;
			GroupBox8.TabStop = false;
			GroupBox8.Text = "Forma de Pago";
			// 
			// Lcod11
			// 
			Lcod11.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Lcod11.ForeColor = Drawing.Color.Black;
			Lcod11.Location = new Drawing.Point(252, 12);
			Lcod11.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			Lcod11.Name = "Lcod11";
			Lcod11.Size = new Drawing.Size(46, 26);
			Lcod11.TabIndex = 17;
			Lcod11.Visible = false;
			// 
			// txtHorasJornadaSemanal
			// 
			txtHorasJornadaSemanal.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			txtHorasJornadaSemanal.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			txtHorasJornadaSemanal.ForeColor = Drawing.Color.Black;
			txtHorasJornadaSemanal.Location = new Drawing.Point(459, 58);
			txtHorasJornadaSemanal.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			txtHorasJornadaSemanal.Name = "txtHorasJornadaSemanal";
			txtHorasJornadaSemanal.Size = new Drawing.Size(158, 26);
			txtHorasJornadaSemanal.TabIndex = 15;
			txtHorasJornadaSemanal.Visible = false;
			// 
			// valorsueldo
			// 
			valorsueldo.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			valorsueldo.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			valorsueldo.ForeColor = Drawing.Color.Black;
			valorsueldo.Location = new Drawing.Point(199, 59);
			valorsueldo.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			valorsueldo.Name = "valorsueldo";
			valorsueldo.Size = new Drawing.Size(190, 26);
			valorsueldo.TabIndex = 13;
			// 
			// Label65
			// 
			Label65.AutoSize = true;
			Label65.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Label65.ForeColor = Drawing.Color.White;
			Label65.Location = new Drawing.Point(195, 40);
			Label65.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label65.Name = "Label65";
			Label65.Size = new Drawing.Size(105, 20);
			Label65.TabIndex = 12;
			Label65.Text = "Valor Salario";
			// 
			// CBuscador11
			// 
			CBuscador11.BackColor = Drawing.Color.Transparent;
			CBuscador11.FlatAppearance.BorderColor = Drawing.Color.LightSteelBlue;
			CBuscador11.FlatAppearance.BorderSize = 0;
			CBuscador11.FlatStyle = Windows.Forms.FlatStyle.Flat;
			CBuscador11.Font = new Drawing.Font("Microsoft Sans Serif", 6f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			CBuscador11.ForeColor = Drawing.Color.White;
			CBuscador11.Image = (Drawing.Image)resources.GetObject("CBuscador11.Image");
			CBuscador11.Location = new Drawing.Point(215, 21);
			CBuscador11.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			CBuscador11.Name = "CBuscador11";
			CBuscador11.Size = new Drawing.Size(27, 28);
			CBuscador11.TabIndex = 11;
			CBuscador11.UseVisualStyleBackColor = false;
			CBuscador11.Visible = false;
			// 
			// Label64
			// 
			Label64.AutoSize = true;
			Label64.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Label64.ForeColor = Drawing.Color.Black;
			Label64.Location = new Drawing.Point(215, 22);
			Label64.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label64.Name = "Label64";
			Label64.Size = new Drawing.Size(84, 20);
			Label64.TabIndex = 9;
			Label64.Text = "Tipo Pago";
			Label64.Visible = false;
			// 
			// RolHoras
			// 
			RolHoras.AutoSize = true;
			RolHoras.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			RolHoras.ForeColor = Drawing.Color.Black;
			RolHoras.Location = new Drawing.Point(309, 21);
			RolHoras.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			RolHoras.Name = "RolHoras";
			RolHoras.Size = new Drawing.Size(102, 24);
			RolHoras.TabIndex = 3;
			RolHoras.Text = "Por Hora";
			RolHoras.UseVisualStyleBackColor = true;
			RolHoras.Visible = false;
			// 
			// rolproduccion
			// 
			rolproduccion.AutoSize = true;
			rolproduccion.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			rolproduccion.ForeColor = Drawing.Color.Black;
			rolproduccion.Location = new Drawing.Point(309, 28);
			rolproduccion.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			rolproduccion.Name = "rolproduccion";
			rolproduccion.Size = new Drawing.Size(149, 24);
			rolproduccion.TabIndex = 2;
			rolproduccion.Text = "Por Producción";
			rolproduccion.UseVisualStyleBackColor = true;
			rolproduccion.Visible = false;
			// 
			// roldiario
			// 
			roldiario.AutoSize = true;
			roldiario.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			roldiario.ForeColor = Drawing.Color.Black;
			roldiario.Location = new Drawing.Point(309, 25);
			roldiario.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			roldiario.Name = "roldiario";
			roldiario.Size = new Drawing.Size(130, 24);
			roldiario.TabIndex = 1;
			roldiario.Text = "Jornal Diario";
			roldiario.UseVisualStyleBackColor = true;
			roldiario.Visible = false;
			// 
			// rolmensual
			// 
			rolmensual.AutoSize = true;
			rolmensual.Checked = true;
			rolmensual.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			rolmensual.ForeColor = Drawing.Color.White;
			rolmensual.Location = new Drawing.Point(19, 61);
			rolmensual.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			rolmensual.Name = "rolmensual";
			rolmensual.Size = new Drawing.Size(153, 24);
			rolmensual.TabIndex = 0;
			rolmensual.TabStop = true;
			rolmensual.Text = "Sueldo Mensual";
			rolmensual.UseVisualStyleBackColor = true;
			// 
			// GroupBox10
			// 
			GroupBox10.Controls.Add(CbuscaDir2);
			GroupBox10.Controls.Add(txtNomBanco);
			GroupBox10.Controls.Add(Label67);
			GroupBox10.Controls.Add(Nroctabancorol);
			GroupBox10.Controls.Add(Label66);
			GroupBox10.Controls.Add(ctaahorrosrol);
			GroupBox10.Controls.Add(ctacorrienterol);
			GroupBox10.Controls.Add(AcreditaBanco);
			GroupBox10.Location = new Drawing.Point(17, 95);
			GroupBox10.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			GroupBox10.Name = "GroupBox10";
			GroupBox10.Padding = new Windows.Forms.Padding(4, 5, 4, 5);
			GroupBox10.Size = new Drawing.Size(711, 108);
			GroupBox10.TabIndex = 14;
			GroupBox10.TabStop = false;
			// 
			// CbuscaDir2
			// 
			CbuscaDir2.BackColor = Drawing.Color.Transparent;
			CbuscaDir2.FlatAppearance.BorderColor = Drawing.Color.LightSteelBlue;
			CbuscaDir2.FlatAppearance.BorderSize = 0;
			CbuscaDir2.FlatStyle = Windows.Forms.FlatStyle.Flat;
			CbuscaDir2.Font = new Drawing.Font("Microsoft Sans Serif", 6f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			CbuscaDir2.ForeColor = Drawing.Color.White;
			CbuscaDir2.Image = (Drawing.Image)resources.GetObject("CbuscaDir2.Image");
			CbuscaDir2.Location = new Drawing.Point(334, 60);
			CbuscaDir2.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			CbuscaDir2.Name = "CbuscaDir2";
			CbuscaDir2.Size = new Drawing.Size(27, 28);
			CbuscaDir2.TabIndex = 27;
			CbuscaDir2.UseVisualStyleBackColor = false;
			// 
			// txtNomBanco
			// 
			txtNomBanco.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			txtNomBanco.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			txtNomBanco.ForeColor = Drawing.Color.Black;
			txtNomBanco.Location = new Drawing.Point(366, 61);
			txtNomBanco.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			txtNomBanco.Name = "txtNomBanco";
			txtNomBanco.Size = new Drawing.Size(316, 26);
			txtNomBanco.TabIndex = 26;
			// 
			// Label67
			// 
			Label67.AutoSize = true;
			Label67.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Label67.ForeColor = Drawing.Color.White;
			Label67.Location = new Drawing.Point(276, 66);
			Label67.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label67.Name = "Label67";
			Label67.Size = new Drawing.Size(57, 20);
			Label67.TabIndex = 25;
			Label67.Text = "Banco";
			// 
			// Nroctabancorol
			// 
			Nroctabancorol.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			Nroctabancorol.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Nroctabancorol.ForeColor = Drawing.Color.Black;
			Nroctabancorol.Location = new Drawing.Point(108, 62);
			Nroctabancorol.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			Nroctabancorol.Name = "Nroctabancorol";
			Nroctabancorol.Size = new Drawing.Size(154, 26);
			Nroctabancorol.TabIndex = 24;
			// 
			// Label66
			// 
			Label66.AutoSize = true;
			Label66.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Label66.ForeColor = Drawing.Color.White;
			Label66.Location = new Drawing.Point(10, 66);
			Label66.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label66.Name = "Label66";
			Label66.Size = new Drawing.Size(93, 20);
			Label66.TabIndex = 23;
			Label66.Text = "Nro.Cuenta";
			// 
			// ctaahorrosrol
			// 
			ctaahorrosrol.AutoSize = true;
			ctaahorrosrol.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			ctaahorrosrol.ForeColor = Drawing.Color.White;
			ctaahorrosrol.Location = new Drawing.Point(426, 20);
			ctaahorrosrol.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			ctaahorrosrol.Name = "ctaahorrosrol";
			ctaahorrosrol.Size = new Drawing.Size(93, 24);
			ctaahorrosrol.TabIndex = 22;
			ctaahorrosrol.Text = "Ahorros";
			ctaahorrosrol.UseVisualStyleBackColor = true;
			// 
			// ctacorrienterol
			// 
			ctacorrienterol.AutoSize = true;
			ctacorrienterol.Checked = true;
			ctacorrienterol.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			ctacorrienterol.ForeColor = Drawing.Color.White;
			ctacorrienterol.Location = new Drawing.Point(316, 21);
			ctacorrienterol.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			ctacorrienterol.Name = "ctacorrienterol";
			ctacorrienterol.Size = new Drawing.Size(103, 24);
			ctacorrienterol.TabIndex = 21;
			ctacorrienterol.TabStop = true;
			ctacorrienterol.Text = "Corriente";
			ctacorrienterol.UseVisualStyleBackColor = true;
			// 
			// AcreditaBanco
			// 
			AcreditaBanco.AutoSize = true;
			AcreditaBanco.CheckAlign = Drawing.ContentAlignment.MiddleRight;
			AcreditaBanco.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			AcreditaBanco.ForeColor = Drawing.Color.White;
			AcreditaBanco.Location = new Drawing.Point(9, 21);
			AcreditaBanco.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			AcreditaBanco.Name = "AcreditaBanco";
			AcreditaBanco.Size = new Drawing.Size(278, 24);
			AcreditaBanco.TabIndex = 20;
			AcreditaBanco.Text = "Valor a pagar acreditar a Cuenta";
			AcreditaBanco.UseVisualStyleBackColor = true;
			// 
			// Label92
			// 
			Label92.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Label92.ForeColor = Drawing.Color.White;
			Label92.Location = new Drawing.Point(456, 15);
			Label92.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label92.Name = "Label92";
			Label92.Size = new Drawing.Size(163, 48);
			Label92.TabIndex = 16;
			Label92.Text = "Horas semanales jornada parcial permanente";
			Label92.TextAlign = Drawing.ContentAlignment.MiddleCenter;
			Label92.Visible = false;
			// 
			// nivelrol
			// 
			nivelrol.Location = new Drawing.Point(1126, 21);
			nivelrol.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			nivelrol.Name = "nivelrol";
			nivelrol.Size = new Drawing.Size(37, 26);
			nivelrol.TabIndex = 38;
			nivelrol.Visible = false;
			// 
			// Label74
			// 
			Label74.AutoSize = true;
			Label74.Location = new Drawing.Point(994, 29);
			Label74.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label74.Name = "Label74";
			Label74.Size = new Drawing.Size(126, 20);
			Label74.TabIndex = 37;
			Label74.Text = "Nivel Seguridad";
			Label74.Visible = false;
			// 
			// Label87
			// 
			Label87.AutoSize = true;
			Label87.ForeColor = Drawing.Color.White;
			Label87.Location = new Drawing.Point(598, 15);
			Label87.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label87.Name = "Label87";
			Label87.Size = new Drawing.Size(147, 20);
			Label87.TabIndex = 50;
			Label87.Text = "CódigoBiométrico:";
			// 
			// cmbCentroCostoRol
			// 
			cmbCentroCostoRol.AutoCompleteMode = Windows.Forms.AutoCompleteMode.SuggestAppend;
			cmbCentroCostoRol.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems;
			cmbCentroCostoRol.FlatStyle = Windows.Forms.FlatStyle.Flat;
			cmbCentroCostoRol.FormattingEnabled = true;
			cmbCentroCostoRol.Location = new Drawing.Point(14, 141);
			cmbCentroCostoRol.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			cmbCentroCostoRol.Name = "cmbCentroCostoRol";
			cmbCentroCostoRol.Size = new Drawing.Size(230, 28);
			cmbCentroCostoRol.TabIndex = 126;
			// 
			// cmbModuloRol
			// 
			cmbModuloRol.AutoCompleteMode = Windows.Forms.AutoCompleteMode.SuggestAppend;
			cmbModuloRol.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems;
			cmbModuloRol.FlatStyle = Windows.Forms.FlatStyle.Flat;
			cmbModuloRol.FormattingEnabled = true;
			cmbModuloRol.Location = new Drawing.Point(279, 142);
			cmbModuloRol.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			cmbModuloRol.Name = "cmbModuloRol";
			cmbModuloRol.Size = new Drawing.Size(226, 28);
			cmbModuloRol.TabIndex = 127;
			// 
			// cmbSeccionRol
			// 
			cmbSeccionRol.AutoCompleteMode = Windows.Forms.AutoCompleteMode.SuggestAppend;
			cmbSeccionRol.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems;
			cmbSeccionRol.FlatStyle = Windows.Forms.FlatStyle.Flat;
			cmbSeccionRol.FormattingEnabled = true;
			cmbSeccionRol.Location = new Drawing.Point(537, 141);
			cmbSeccionRol.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			cmbSeccionRol.Name = "cmbSeccionRol";
			cmbSeccionRol.Size = new Drawing.Size(223, 28);
			cmbSeccionRol.TabIndex = 128;
			// 
			// Label58
			// 
			Label58.AutoSize = true;
			Label58.ForeColor = Drawing.Color.White;
			Label58.Location = new Drawing.Point(531, 122);
			Label58.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label58.Name = "Label58";
			Label58.Size = new Drawing.Size(69, 20);
			Label58.TabIndex = 18;
			Label58.Text = "Sección";
			// 
			// Label55
			// 
			Label55.AutoSize = true;
			Label55.ForeColor = Drawing.Color.White;
			Label55.Location = new Drawing.Point(271, 64);
			Label55.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label55.Name = "Label55";
			Label55.Size = new Drawing.Size(115, 20);
			Label55.TabIndex = 9;
			Label55.Text = "Departamento";
			// 
			// Label59
			// 
			Label59.AutoSize = true;
			Label59.ForeColor = Drawing.Color.White;
			Label59.Location = new Drawing.Point(276, 125);
			Label59.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label59.Name = "Label59";
			Label59.Size = new Drawing.Size(63, 20);
			Label59.TabIndex = 20;
			Label59.Text = "Módulo";
			// 
			// Label56
			// 
			Label56.AutoSize = true;
			Label56.ForeColor = Drawing.Color.White;
			Label56.Location = new Drawing.Point(531, 62);
			Label56.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label56.Name = "Label56";
			Label56.Size = new Drawing.Size(54, 20);
			Label56.TabIndex = 12;
			Label56.Text = "Cargo";
			// 
			// Label57
			// 
			Label57.AutoSize = true;
			Label57.ForeColor = Drawing.Color.White;
			Label57.Location = new Drawing.Point(12, 122);
			Label57.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label57.Name = "Label57";
			Label57.Size = new Drawing.Size(108, 20);
			Label57.TabIndex = 16;
			Label57.Text = "Centro Costo";
			// 
			// Label54
			// 
			Label54.AutoSize = true;
			Label54.ForeColor = Drawing.Color.White;
			Label54.Location = new Drawing.Point(10, 64);
			Label54.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label54.Name = "Label54";
			Label54.Size = new Drawing.Size(75, 20);
			Label54.TabIndex = 6;
			Label54.Text = "Sucursal";
			// 
			// tabFamiliares
			// 
			tabFamiliares.BackColor = Drawing.Color.AliceBlue;
			tabFamiliares.Controls.Add(malla);
			tabFamiliares.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			tabFamiliares.Location = new Drawing.Point(4, 37);
			tabFamiliares.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			tabFamiliares.Name = "tabFamiliares";
			tabFamiliares.Size = new Drawing.Size(1268, 717);
			tabFamiliares.TabIndex = 8;
			tabFamiliares.Text = "Familiares";
			// 
			// malla
			// 
			malla.AllowUserToResizeRows = false;
			malla.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
			malla.BackgroundColor = Drawing.Color.White;
			malla.BorderStyle = Windows.Forms.BorderStyle.None;
			dataGridViewCellStyle35.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle35.BackColor = Drawing.Color.SteelBlue;
			dataGridViewCellStyle35.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle35.ForeColor = Drawing.Color.White;
			dataGridViewCellStyle35.SelectionBackColor = Drawing.SystemColors.Highlight;
			dataGridViewCellStyle35.SelectionForeColor = Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle35.WrapMode = Windows.Forms.DataGridViewTriState.True;
			malla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle35;
			malla.ColumnHeadersHeightSizeMode = Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			malla.Columns.AddRange(new Windows.Forms.DataGridViewColumn[] { Nro, CedulaId, Nombres, Parentesco, FechaNacim, Sexo1, EstadoCivil, Direccion, Teléfono_1, Teléfono_2, Ocupación, Depend, Minusv });
			malla.Dock = Windows.Forms.DockStyle.Fill;
			malla.EditMode = Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
			malla.EnableHeadersVisualStyles = false;
			malla.GridColor = Drawing.Color.FromArgb(224, 224, 224);
			malla.Location = new Drawing.Point(0, 0);
			malla.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			malla.Name = "malla";
			dataGridViewCellStyle36.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle36.BackColor = Drawing.Color.SteelBlue;
			dataGridViewCellStyle36.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle36.ForeColor = Drawing.Color.White;
			dataGridViewCellStyle36.SelectionBackColor = Drawing.SystemColors.Highlight;
			dataGridViewCellStyle36.SelectionForeColor = Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle36.WrapMode = Windows.Forms.DataGridViewTriState.True;
			malla.RowHeadersDefaultCellStyle = dataGridViewCellStyle36;
			malla.RowHeadersWidth = 50;
			malla.RowHeadersWidthSizeMode = Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			malla.Size = new Drawing.Size(1268, 717);
			malla.TabIndex = 0;
			// 
			// Nro
			// 
			Nro.HeaderText = "Nro.";
			Nro.MinimumWidth = 6;
			Nro.Name = "Nro";
			Nro.Width = 76;
			// 
			// CedulaId
			// 
			CedulaId.HeaderText = "Celuda Id.";
			CedulaId.MinimumWidth = 6;
			CedulaId.Name = "CedulaId";
			CedulaId.Width = 119;
			// 
			// Nombres
			// 
			Nombres.HeaderText = "Nombres";
			Nombres.MinimumWidth = 6;
			Nombres.Name = "Nombres";
			Nombres.Width = 113;
			// 
			// Parentesco
			// 
			Parentesco.DisplayStyle = Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
			Parentesco.HeaderText = "Parentesco";
			Parentesco.Items.AddRange(new object[] { "Conyuge", "Hijo", "Hija", "Papá", "Mamá", "Hermano", "Hermana", "Suegro", "Suegra", "Tío", "Tía", "Primo", "Prima", "Cuñado", "Cuñada" });
			Parentesco.MinimumWidth = 6;
			Parentesco.Name = "Parentesco";
			// 
			// FechaNacim
			// 
			FechaNacim.HeaderText = "FechaNacim.";
			FechaNacim.MinimumWidth = 6;
			FechaNacim.Name = "FechaNacim";
			FechaNacim.Width = 143;
			// 
			// Sexo1
			// 
			Sexo1.DisplayStyle = Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
			Sexo1.HeaderText = "Sexo";
			Sexo1.Items.AddRange(new object[] { "Masculino", "Femenino" });
			Sexo1.MinimumWidth = 6;
			Sexo1.Name = "Sexo1";
			Sexo1.Width = 54;
			// 
			// EstadoCivil
			// 
			EstadoCivil.DisplayStyle = Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
			EstadoCivil.HeaderText = "EstadoCivil";
			EstadoCivil.Items.AddRange(new object[] { "Soltero/a", "Casado/a", "Divorciado/a", "Viudo/a", "Unión Libre" });
			EstadoCivil.MinimumWidth = 6;
			EstadoCivil.Name = "EstadoCivil";
			EstadoCivil.Width = 99;
			// 
			// Direccion
			// 
			Direccion.HeaderText = "Direccion";
			Direccion.MinimumWidth = 6;
			Direccion.Name = "Direccion";
			Direccion.Width = 117;
			// 
			// Teléfono_1
			// 
			Teléfono_1.HeaderText = "Teléfono_1";
			Teléfono_1.MinimumWidth = 6;
			Teléfono_1.Name = "Teléfono_1";
			Teléfono_1.Width = 127;
			// 
			// Teléfono_2
			// 
			Teléfono_2.HeaderText = "Teléfono_2";
			Teléfono_2.MinimumWidth = 6;
			Teléfono_2.Name = "Teléfono_2";
			Teléfono_2.Width = 127;
			// 
			// Ocupación
			// 
			Ocupación.HeaderText = "Ocupación";
			Ocupación.MinimumWidth = 6;
			Ocupación.Name = "Ocupación";
			Ocupación.Width = 125;
			// 
			// Depend
			// 
			Depend.DisplayStyle = Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
			Depend.HeaderText = "Depend.";
			Depend.Items.AddRange(new object[] { "Si", "No" });
			Depend.MinimumWidth = 6;
			Depend.Name = "Depend";
			Depend.Width = 77;
			// 
			// Minusv
			// 
			Minusv.DisplayStyle = Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
			Minusv.HeaderText = "Discapac.";
			Minusv.Items.AddRange(new object[] { "Si", "No" });
			Minusv.MinimumWidth = 6;
			Minusv.Name = "Minusv";
			Minusv.Width = 90;
			// 
			// tabContactos
			// 
			tabContactos.Controls.Add(MallaCtco);
			tabContactos.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			tabContactos.Location = new Drawing.Point(4, 37);
			tabContactos.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			tabContactos.Name = "tabContactos";
			tabContactos.Size = new Drawing.Size(1268, 717);
			tabContactos.TabIndex = 4;
			tabContactos.Text = "Contactos";
			tabContactos.UseVisualStyleBackColor = true;
			// 
			// MallaCtco
			// 
			MallaCtco.AllowDrop = true;
			MallaCtco.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
			MallaCtco.BackgroundColor = Drawing.Color.White;
			dataGridViewCellStyle37.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle37.BackColor = Drawing.Color.SteelBlue;
			dataGridViewCellStyle37.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle37.ForeColor = Drawing.Color.White;
			dataGridViewCellStyle37.SelectionBackColor = Drawing.SystemColors.Highlight;
			dataGridViewCellStyle37.SelectionForeColor = Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle37.WrapMode = Windows.Forms.DataGridViewTriState.True;
			MallaCtco.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle37;
			MallaCtco.ColumnHeadersHeightSizeMode = Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			MallaCtco.Columns.AddRange(new Windows.Forms.DataGridViewColumn[] { TipoContacto, Nombrecontacto, Cargo, NroExtensión, NroTlfCelular, NroTlfDirecto, FecNacimto, Actividades, Preferencias, Observaciones });
			MallaCtco.Dock = Windows.Forms.DockStyle.Fill;
			MallaCtco.EditMode = Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
			MallaCtco.EnableHeadersVisualStyles = false;
			MallaCtco.GridColor = Drawing.Color.FromArgb(224, 224, 224);
			MallaCtco.Location = new Drawing.Point(0, 0);
			MallaCtco.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			MallaCtco.Name = "MallaCtco";
			dataGridViewCellStyle38.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle38.BackColor = Drawing.Color.SteelBlue;
			dataGridViewCellStyle38.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle38.ForeColor = Drawing.Color.White;
			dataGridViewCellStyle38.SelectionBackColor = Drawing.SystemColors.Highlight;
			dataGridViewCellStyle38.SelectionForeColor = Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle38.WrapMode = Windows.Forms.DataGridViewTriState.True;
			MallaCtco.RowHeadersDefaultCellStyle = dataGridViewCellStyle38;
			MallaCtco.RowHeadersWidth = 51;
			MallaCtco.Size = new Drawing.Size(1268, 717);
			MallaCtco.TabIndex = 0;
			// 
			// TipoContacto
			// 
			TipoContacto.HeaderText = "Tip";
			TipoContacto.MinimumWidth = 6;
			TipoContacto.Name = "TipoContacto";
			TipoContacto.Width = 68;
			// 
			// Nombrecontacto
			// 
			Nombrecontacto.HeaderText = "Nombre del contacto";
			Nombrecontacto.MinimumWidth = 6;
			Nombrecontacto.Name = "Nombrecontacto";
			Nombrecontacto.Width = 183;
			// 
			// Cargo
			// 
			Cargo.HeaderText = "Cargo";
			Cargo.MinimumWidth = 6;
			Cargo.Name = "Cargo";
			Cargo.Width = 90;
			// 
			// NroExtensión
			// 
			NroExtensión.HeaderText = "NroExtensión";
			NroExtensión.MinimumWidth = 6;
			NroExtensión.Name = "NroExtensión";
			NroExtensión.Width = 145;
			// 
			// NroTlfCelular
			// 
			NroTlfCelular.HeaderText = "NroTlfCelular";
			NroTlfCelular.MinimumWidth = 6;
			NroTlfCelular.Name = "NroTlfCelular";
			NroTlfCelular.Width = 144;
			// 
			// NroTlfDirecto
			// 
			NroTlfDirecto.HeaderText = "NroTlfDirecto";
			NroTlfDirecto.MinimumWidth = 6;
			NroTlfDirecto.Name = "NroTlfDirecto";
			NroTlfDirecto.Width = 146;
			// 
			// FecNacimto
			// 
			FecNacimto.HeaderText = "FecNacimto";
			FecNacimto.MaxInputLength = 10;
			FecNacimto.MinimumWidth = 6;
			FecNacimto.Name = "FecNacimto";
			FecNacimto.Width = 135;
			// 
			// Actividades
			// 
			Actividades.HeaderText = "Actividades";
			Actividades.MinimumWidth = 6;
			Actividades.Name = "Actividades";
			Actividades.Width = 131;
			// 
			// Preferencias
			// 
			Preferencias.HeaderText = "Preferencias";
			Preferencias.MinimumWidth = 6;
			Preferencias.Name = "Preferencias";
			Preferencias.Width = 140;
			// 
			// Observaciones
			// 
			Observaciones.HeaderText = "Observaciones";
			Observaciones.MinimumWidth = 6;
			Observaciones.Name = "Observaciones";
			Observaciones.Width = 157;
			// 
			// tabAlias
			// 
			tabAlias.Controls.Add(MallaAlias);
			tabAlias.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			tabAlias.Location = new Drawing.Point(4, 37);
			tabAlias.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			tabAlias.Name = "tabAlias";
			tabAlias.Size = new Drawing.Size(1268, 717);
			tabAlias.TabIndex = 5;
			tabAlias.Text = "Alias";
			tabAlias.UseVisualStyleBackColor = true;
			// 
			// MallaAlias
			// 
			MallaAlias.AutoSizeColumnsMode = Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
			MallaAlias.BackgroundColor = Drawing.Color.White;
			MallaAlias.CellBorderStyle = Windows.Forms.DataGridViewCellBorderStyle.Raised;
			dataGridViewCellStyle39.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle39.BackColor = Drawing.Color.SteelBlue;
			dataGridViewCellStyle39.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle39.ForeColor = Drawing.Color.White;
			dataGridViewCellStyle39.SelectionBackColor = Drawing.SystemColors.Highlight;
			dataGridViewCellStyle39.SelectionForeColor = Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle39.WrapMode = Windows.Forms.DataGridViewTriState.True;
			MallaAlias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle39;
			MallaAlias.ColumnHeadersHeightSizeMode = Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			MallaAlias.Columns.AddRange(new Windows.Forms.DataGridViewColumn[] { NombreAliasSucursal, DirecciónAlterna, Teléfono1, Teléfono2, IdSri, Observaciones1 });
			MallaAlias.Dock = Windows.Forms.DockStyle.Fill;
			MallaAlias.EditMode = Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
			MallaAlias.EnableHeadersVisualStyles = false;
			MallaAlias.GridColor = Drawing.Color.FromArgb(224, 224, 224);
			MallaAlias.Location = new Drawing.Point(0, 0);
			MallaAlias.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			MallaAlias.Name = "MallaAlias";
			dataGridViewCellStyle40.Alignment = Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle40.BackColor = Drawing.Color.SteelBlue;
			dataGridViewCellStyle40.Font = new Drawing.Font("Microsoft Sans Serif", 8.25f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle40.ForeColor = Drawing.Color.White;
			dataGridViewCellStyle40.SelectionBackColor = Drawing.SystemColors.Highlight;
			dataGridViewCellStyle40.SelectionForeColor = Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle40.WrapMode = Windows.Forms.DataGridViewTriState.True;
			MallaAlias.RowHeadersDefaultCellStyle = dataGridViewCellStyle40;
			MallaAlias.RowHeadersWidth = 51;
			MallaAlias.Size = new Drawing.Size(1268, 717);
			MallaAlias.TabIndex = 0;
			// 
			// NombreAliasSucursal
			// 
			NombreAliasSucursal.HeaderText = "Nombre  del Alias o Sucursal";
			NombreAliasSucursal.MinimumWidth = 6;
			NombreAliasSucursal.Name = "NombreAliasSucursal";
			NombreAliasSucursal.Width = 180;
			// 
			// DirecciónAlterna
			// 
			DirecciónAlterna.HeaderText = "Dirección Alterna";
			DirecciónAlterna.MinimumWidth = 6;
			DirecciónAlterna.Name = "DirecciónAlterna";
			DirecciónAlterna.Width = 161;
			// 
			// Teléfono1
			// 
			Teléfono1.HeaderText = "Teléfono-1";
			Teléfono1.MinimumWidth = 6;
			Teléfono1.Name = "Teléfono1";
			Teléfono1.Width = 124;
			// 
			// Teléfono2
			// 
			Teléfono2.HeaderText = "Teléfono-2";
			Teléfono2.MinimumWidth = 6;
			Teléfono2.Name = "Teléfono2";
			Teléfono2.Width = 124;
			// 
			// IdSri
			// 
			IdSri.HeaderText = "Id-Sri";
			IdSri.MinimumWidth = 6;
			IdSri.Name = "IdSri";
			IdSri.Width = 85;
			// 
			// Observaciones1
			// 
			Observaciones1.HeaderText = "Observaciones";
			Observaciones1.MinimumWidth = 6;
			Observaciones1.Name = "Observaciones1";
			Observaciones1.Width = 157;
			// 
			// Panel1
			// 
			Panel1.BackColor = Drawing.Color.DimGray;
			Panel1.Controls.Add(txtHistoriaclinica);
			Panel1.Controls.Add(Label1);
			Panel1.Controls.Add(Label79);
			Panel1.Controls.Add(Codigo);
			Panel1.Controls.Add(Label2);
			Panel1.Controls.Add(TipoIdent);
			Panel1.Controls.Add(Label3);
			Panel1.Controls.Add(TxtCedulaRuc);
			Panel1.Controls.Add(Label5);
			Panel1.Controls.Add(impresion);
			Panel1.Dock = Windows.Forms.DockStyle.Top;
			Panel1.ForeColor = Drawing.Color.White;
			Panel1.Location = new Drawing.Point(0, 0);
			Panel1.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			Panel1.Name = "Panel1";
			Panel1.Size = new Drawing.Size(1066, 75);
			Panel1.TabIndex = 1;
			// 
			// Apellidos
			// 
			Apellidos.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			Apellidos.Location = new Drawing.Point(872, 152);
			Apellidos.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			Apellidos.Name = "Apellidos";
			Apellidos.Size = new Drawing.Size(491, 26);
			Apellidos.TabIndex = 4;
			Apellidos.Visible = false;
			// 
			// txtHistoriaclinica
			// 
			txtHistoriaclinica.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			txtHistoriaclinica.Location = new Drawing.Point(891, 2);
			txtHistoriaclinica.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			txtHistoriaclinica.Name = "txtHistoriaclinica";
			txtHistoriaclinica.Size = new Drawing.Size(157, 26);
			txtHistoriaclinica.TabIndex = 93;
			// 
			// Label1
			// 
			Label1.AutoSize = true;
			Label1.Location = new Drawing.Point(6, 9);
			Label1.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label1.Name = "Label1";
			Label1.Size = new Drawing.Size(59, 20);
			Label1.TabIndex = 42;
			Label1.Text = "Código";
			// 
			// Label79
			// 
			Label79.AutoSize = true;
			Label79.Location = new Drawing.Point(796, 9);
			Label79.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label79.Name = "Label79";
			Label79.Size = new Drawing.Size(87, 20);
			Label79.TabIndex = 94;
			Label79.Text = "Hist.Clínica";
			// 
			// Codigo
			// 
			Codigo.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			Codigo.Location = new Drawing.Point(69, 5);
			Codigo.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			Codigo.MaxLength = 15;
			Codigo.Name = "Codigo";
			Codigo.Size = new Drawing.Size(130, 26);
			Codigo.TabIndex = 0;
			// 
			// Label2
			// 
			Label2.AutoSize = true;
			Label2.Location = new Drawing.Point(207, 9);
			Label2.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label2.Name = "Label2";
			Label2.Size = new Drawing.Size(194, 20);
			Label2.TabIndex = 44;
			Label2.Text = "Documento Identificación:";
			// 
			// TipoIdent
			// 
			TipoIdent.FlatStyle = Windows.Forms.FlatStyle.Flat;
			TipoIdent.FormattingEnabled = true;
			TipoIdent.Items.AddRange(new object[] { "No aplica", "Registro U Contribuyente", "Cédula Identidad", "Pasaporte", "Consumidor Final" });
			TipoIdent.Location = new Drawing.Point(408, 2);
			TipoIdent.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			TipoIdent.Name = "TipoIdent";
			TipoIdent.Size = new Drawing.Size(176, 28);
			TipoIdent.TabIndex = 1;
			// 
			// Label3
			// 
			Label3.AutoSize = true;
			Label3.Location = new Drawing.Point(594, 9);
			Label3.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label3.Name = "Label3";
			Label3.Size = new Drawing.Size(38, 20);
			Label3.TabIndex = 46;
			Label3.Text = "Nro:";
			// 
			// TxtCedulaRuc
			// 
			TxtCedulaRuc.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			TxtCedulaRuc.Location = new Drawing.Point(638, 6);
			TxtCedulaRuc.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			TxtCedulaRuc.Name = "TxtCedulaRuc";
			TxtCedulaRuc.Size = new Drawing.Size(149, 26);
			TxtCedulaRuc.TabIndex = 2;
			// 
			// Label4
			// 
			Label4.AutoSize = true;
			Label4.Location = new Drawing.Point(883, 51);
			Label4.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label4.Name = "Label4";
			Label4.Size = new Drawing.Size(77, 20);
			Label4.TabIndex = 48;
			Label4.Text = "Nombres";
			Label4.Visible = false;
			// 
			// TxtNombres
			// 
			TxtNombres.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			TxtNombres.Location = new Drawing.Point(872, 86);
			TxtNombres.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			TxtNombres.Name = "TxtNombres";
			TxtNombres.Size = new Drawing.Size(391, 26);
			TxtNombres.TabIndex = 3;
			TxtNombres.Visible = false;
			// 
			// Label32
			// 
			Label32.AutoSize = true;
			Label32.Location = new Drawing.Point(878, 120);
			Label32.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label32.Name = "Label32";
			Label32.Size = new Drawing.Size(77, 20);
			Label32.TabIndex = 84;
			Label32.Text = "Apellidos";
			Label32.Visible = false;
			// 
			// ToolStrip1
			// 
			ToolStrip1.BackColor = Drawing.Color.DimGray;
			ToolStrip1.GripStyle = Windows.Forms.ToolStripGripStyle.Hidden;
			ToolStrip1.ImageScalingSize = new Drawing.Size(20, 20);
			ToolStrip1.Items.AddRange(new Windows.Forms.ToolStripItem[] { btnNuevo, btnAbrir, btnCerrar, btnGuardar, btnEliminar, btnSalir });
			ToolStrip1.Location = new Drawing.Point(0, 0);
			ToolStrip1.Name = "ToolStrip1";
			ToolStrip1.RenderMode = Windows.Forms.ToolStripRenderMode.Professional;
			ToolStrip1.Size = new Drawing.Size(1228, 54);
			ToolStrip1.TabIndex = 4;
			ToolStrip1.Text = "ToolStrip1";
			// 
			// btnNuevo
			// 
			btnNuevo.ForeColor = Drawing.Color.White;
			btnNuevo.Image = (Drawing.Image)resources.GetObject("btnNuevo.Image");
			btnNuevo.ImageTransparentColor = Drawing.Color.Magenta;
			btnNuevo.Name = "btnNuevo";
			btnNuevo.Size = new Drawing.Size(68, 49);
			btnNuevo.Text = "Nuevo";
			btnNuevo.TextImageRelation = Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// btnAbrir
			// 
			btnAbrir.ForeColor = Drawing.Color.White;
			btnAbrir.Image = (Drawing.Image)resources.GetObject("btnAbrir.Image");
			btnAbrir.ImageTransparentColor = Drawing.Color.Magenta;
			btnAbrir.Name = "btnAbrir";
			btnAbrir.Size = new Drawing.Size(55, 49);
			btnAbrir.Text = "Abrir";
			btnAbrir.TextImageRelation = Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// btnCerrar
			// 
			btnCerrar.ForeColor = Drawing.Color.White;
			btnCerrar.Image = (Drawing.Image)resources.GetObject("btnCerrar.Image");
			btnCerrar.ImageTransparentColor = Drawing.Color.Magenta;
			btnCerrar.Name = "btnCerrar";
			btnCerrar.Size = new Drawing.Size(63, 49);
			btnCerrar.Text = "Cerrar";
			btnCerrar.TextImageRelation = Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// btnGuardar
			// 
			btnGuardar.ForeColor = Drawing.Color.White;
			btnGuardar.Image = (Drawing.Image)resources.GetObject("btnGuardar.Image");
			btnGuardar.ImageTransparentColor = Drawing.Color.Magenta;
			btnGuardar.Name = "btnGuardar";
			btnGuardar.Size = new Drawing.Size(79, 49);
			btnGuardar.Text = "Guardar";
			btnGuardar.TextImageRelation = Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// btnEliminar
			// 
			btnEliminar.ForeColor = Drawing.Color.White;
			btnEliminar.Image = (Drawing.Image)resources.GetObject("btnEliminar.Image");
			btnEliminar.ImageTransparentColor = Drawing.Color.Magenta;
			btnEliminar.Name = "btnEliminar";
			btnEliminar.Size = new Drawing.Size(78, 49);
			btnEliminar.Text = "Eliminar";
			btnEliminar.TextImageRelation = Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// btnSalir
			// 
			btnSalir.ForeColor = Drawing.Color.White;
			btnSalir.Image = (Drawing.Image)resources.GetObject("btnSalir.Image");
			btnSalir.ImageTransparentColor = Drawing.Color.Magenta;
			btnSalir.Name = "btnSalir";
			btnSalir.Size = new Drawing.Size(49, 49);
			btnSalir.Text = "Salir";
			btnSalir.TextImageRelation = Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// Label78
			// 
			Label78.AutoSize = true;
			Label78.BackColor = Drawing.Color.Transparent;
			Label78.ForeColor = Drawing.Color.White;
			Label78.Location = new Drawing.Point(1000, 408);
			Label78.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			Label78.Name = "Label78";
			Label78.Size = new Drawing.Size(98, 20);
			Label78.TabIndex = 86;
			Label78.Text = "Agrupacion:";
			// 
			// Button1
			// 
			Button1.BackColor = Drawing.Color.Transparent;
			Button1.Cursor = Windows.Forms.Cursors.Default;
			Button1.FlatAppearance.BorderSize = 0;
			Button1.FlatStyle = Windows.Forms.FlatStyle.Flat;
			Button1.Font = new Drawing.Font("Microsoft Sans Serif", 6f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Button1.ForeColor = Drawing.Color.White;
			Button1.Image = (Drawing.Image)resources.GetObject("Button1.Image");
			Button1.Location = new Drawing.Point(882, 440);
			Button1.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			Button1.Name = "Button1";
			Button1.Size = new Drawing.Size(26, 26);
			Button1.TabIndex = 88;
			Button1.UseVisualStyleBackColor = false;
			// 
			// Button2
			// 
			Button2.BackColor = Drawing.Color.Transparent;
			Button2.Cursor = Windows.Forms.Cursors.Default;
			Button2.FlatAppearance.BorderSize = 0;
			Button2.FlatStyle = Windows.Forms.FlatStyle.Flat;
			Button2.Font = new Drawing.Font("Microsoft Sans Serif", 6f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Button2.ForeColor = Drawing.Color.White;
			Button2.Image = (Drawing.Image)resources.GetObject("Button2.Image");
			Button2.Location = new Drawing.Point(882, 474);
			Button2.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			Button2.Name = "Button2";
			Button2.Size = new Drawing.Size(26, 26);
			Button2.TabIndex = 90;
			Button2.UseVisualStyleBackColor = false;
			// 
			// Button3
			// 
			Button3.BackColor = Drawing.Color.Transparent;
			Button3.Cursor = Windows.Forms.Cursors.Default;
			Button3.FlatAppearance.BorderSize = 0;
			Button3.FlatStyle = Windows.Forms.FlatStyle.Flat;
			Button3.Font = new Drawing.Font("Microsoft Sans Serif", 6f, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point, 0);
			Button3.ForeColor = Drawing.Color.White;
			Button3.Image = (Drawing.Image)resources.GetObject("Button3.Image");
			Button3.Location = new Drawing.Point(882, 506);
			Button3.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			Button3.Name = "Button3";
			Button3.Size = new Drawing.Size(26, 26);
			Button3.TabIndex = 92;
			Button3.UseVisualStyleBackColor = false;
			// 
			// txtGrupo1
			// 
			txtGrupo1.BackColor = Drawing.Color.White;
			txtGrupo1.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			txtGrupo1.ForeColor = Drawing.Color.Black;
			txtGrupo1.Location = new Drawing.Point(910, 439);
			txtGrupo1.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			txtGrupo1.Name = "txtGrupo1";
			txtGrupo1.Size = new Drawing.Size(323, 27);
			txtGrupo1.TabIndex = 110;
			txtGrupo1.Visible = false;
			// 
			// txtGrupo3
			// 
			txtGrupo3.BackColor = Drawing.Color.White;
			txtGrupo3.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			txtGrupo3.ForeColor = Drawing.Color.Black;
			txtGrupo3.Location = new Drawing.Point(910, 502);
			txtGrupo3.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			txtGrupo3.Name = "txtGrupo3";
			txtGrupo3.Size = new Drawing.Size(323, 27);
			txtGrupo3.TabIndex = 111;
			txtGrupo3.Visible = false;
			// 
			// txtGrupo2
			// 
			txtGrupo2.BackColor = Drawing.Color.White;
			txtGrupo2.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			txtGrupo2.ForeColor = Drawing.Color.Black;
			txtGrupo2.Location = new Drawing.Point(910, 471);
			txtGrupo2.Margin = new Windows.Forms.Padding(4, 0, 4, 0);
			txtGrupo2.Name = "txtGrupo2";
			txtGrupo2.Size = new Drawing.Size(323, 27);
			txtGrupo2.TabIndex = 112;
			txtGrupo2.Visible = false;
			// 
			// foto
			// 
			foto.BackColor = Drawing.Color.White;
			foto.BorderStyle = Windows.Forms.BorderStyle.FixedSingle;
			foto.Location = new Drawing.Point(872, 12);
			foto.Margin = new Windows.Forms.Padding(4, 5, 4, 5);
			foto.Name = "foto";
			foto.Size = new Drawing.Size(363, 311);
			foto.SizeMode = Windows.Forms.PictureBoxSizeMode.Zoom;
			foto.TabIndex = 82;
			foto.TabStop = false;
			foto.Visible = false;
			// 
			// Form1
			// 
			AutoScaleDimensions = new Drawing.SizeF(9f, 20f);
			AutoScaleMode = (System.Windows.Forms.AutoScaleMode)Conversions.ToInteger(Windows.Forms.AutoScaleMode.Font);
			ClientSize = new Drawing.Size(1228, 834);
			Controls.Add(SplitContainer1);
			Controls.Add(ToolStrip1);
			Name = "Form1";
			Text = "Form1";
			SplitContainer1.Panel1.ResumeLayout(false);
			SplitContainer1.Panel2.ResumeLayout(false);
			((ComponentModel.ISupportInitialize)SplitContainer1).EndInit();
			SplitContainer1.ResumeLayout(false);
			GroupBox3.ResumeLayout(false);
			GroupBox3.PerformLayout();
			GroupBox2.ResumeLayout(false);
			GroupBox2.PerformLayout();
			GroupBox1.ResumeLayout(false);
			GroupBox1.PerformLayout();
			DatosDirectorio.ResumeLayout(false);
			tabIdentificación.ResumeLayout(false);
			tabIdentificación.PerformLayout();
			GroupBox13.ResumeLayout(false);
			GroupBox13.PerformLayout();
			GroupBox5.ResumeLayout(false);
			GroupBox5.PerformLayout();
			tabDatosPer.ResumeLayout(false);
			tabDatosPer.PerformLayout();
			GroupBox12.ResumeLayout(false);
			GroupBox12.PerformLayout();
			asociadoa.ResumeLayout(false);
			asociadoa.PerformLayout();
			GroupBox4.ResumeLayout(false);
			GroupBox4.PerformLayout();
			tabCliente.ResumeLayout(false);
			tabCliente.PerformLayout();
			GroupBox15.ResumeLayout(false);
			GroupBox15.PerformLayout();
			GroupBox11.ResumeLayout(false);
			GroupBox11.PerformLayout();
			tabProveedor.ResumeLayout(false);
			tabProveedor.PerformLayout();
			GroupBox14.ResumeLayout(false);
			GroupBox14.PerformLayout();
			GroupBox6.ResumeLayout(false);
			GroupBox6.PerformLayout();
			tabEmpleado.ResumeLayout(false);
			tabEmpleado.PerformLayout();
			TabDatosEmpleado.ResumeLayout(false);
			TabPage1.ResumeLayout(false);
			((ComponentModel.ISupportInitialize)mallaDatos).EndInit();
			TabPage2.ResumeLayout(false);
			((ComponentModel.ISupportInitialize)mallaConceptos).EndInit();
			GroupBox9.ResumeLayout(false);
			GroupBox9.PerformLayout();
			GroupBox7.ResumeLayout(false);
			GroupBox7.PerformLayout();
			GroupBox8.ResumeLayout(false);
			GroupBox8.PerformLayout();
			GroupBox10.ResumeLayout(false);
			GroupBox10.PerformLayout();
			tabFamiliares.ResumeLayout(false);
			((ComponentModel.ISupportInitialize)malla).EndInit();
			tabContactos.ResumeLayout(false);
			((ComponentModel.ISupportInitialize)MallaCtco).EndInit();
			tabAlias.ResumeLayout(false);
			((ComponentModel.ISupportInitialize)MallaAlias).EndInit();
			Panel1.ResumeLayout(false);
			Panel1.PerformLayout();
			ToolStrip1.ResumeLayout(false);
			ToolStrip1.PerformLayout();
			((ComponentModel.ISupportInitialize)foto).EndInit();
			ResumeLayout(false);
			PerformLayout();

		}

		#endregion

		internal Windows.Forms.SplitContainer SplitContainer1;
		internal Windows.Forms.GroupBox GroupBox3;
		internal Windows.Forms.CheckBox Asociacion;
		internal Windows.Forms.GroupBox GroupBox2;
		internal Windows.Forms.CheckBox Directa;
		internal Windows.Forms.CheckBox EsVendedor;
		internal Windows.Forms.CheckBox Empleado;
		internal Windows.Forms.CheckBox Banco;
		internal Windows.Forms.CheckBox Proveedor;
		internal Windows.Forms.CheckBox Cliente;
		internal Windows.Forms.GroupBox GroupBox1;
		internal Windows.Forms.RadioButton Juridica;
		internal Windows.Forms.RadioButton Natural;
		internal Windows.Forms.TabControl DatosDirectorio;
		internal Windows.Forms.TabPage tabIdentificación;
		internal Windows.Forms.GroupBox GroupBox13;
		internal Windows.Forms.ComboBox cmbRegionDomicilio;
		internal Windows.Forms.ComboBox cmbCantonDomicilio;
		internal Windows.Forms.ComboBox cmbCiudadDomicilio;
		internal Windows.Forms.ComboBox cmbParroquiaDomicilio;
		internal Windows.Forms.ComboBox cmbProvinciaDomicilio;
		internal Windows.Forms.ComboBox cmbPaisDomicilio;
		internal Windows.Forms.TextBox txtSector;
		internal Windows.Forms.Label Label18;
		internal Windows.Forms.TextBox TxtNroDomicilio;
		internal Windows.Forms.Label Label12;
		internal Windows.Forms.TextBox txtnomDireccion;
		internal Windows.Forms.Label Label11;
		internal Windows.Forms.Label Label88;
		internal Windows.Forms.Label Label16;
		internal Windows.Forms.Label Label10;
		internal Windows.Forms.Label Label9;
		internal Windows.Forms.Label Label8;
		internal Windows.Forms.Label Label7;
		internal Windows.Forms.GroupBox GroupBox5;
		internal Windows.Forms.CheckBox chkRegimenMicroempresas;
		internal Windows.Forms.TextBox TxtResolucionAR;
		internal Windows.Forms.Label Label82;
		internal Windows.Forms.TextBox txtContribuyenteEspecial;
		internal Windows.Forms.Label Label83;
		internal Windows.Forms.CheckBox chkRise;
		internal Windows.Forms.CheckBox chkObligaContabilidad;
		internal Windows.Forms.CheckBox ExoneradoIva;
		internal Windows.Forms.Label Label20;
		internal Windows.Forms.TextBox TxtData9;
		internal Windows.Forms.Label Label19;
		internal Windows.Forms.TextBox TxtData8;
		internal Windows.Forms.TextBox TxtData6;
		internal Windows.Forms.TextBox txtTelefono3;
		internal Windows.Forms.Label Label15;
		internal Windows.Forms.TextBox txtTelefono2;
		internal Windows.Forms.Label Label14;
		internal Windows.Forms.TextBox txtTelefono1;
		internal Windows.Forms.Label Label13;
		internal Windows.Forms.TextBox impresion;
		internal Windows.Forms.Label Label5;
		internal Windows.Forms.Label label17;
		internal Windows.Forms.TabPage tabDatosPer;
		internal Windows.Forms.ComboBox cmbEspecialidad2;
		internal Windows.Forms.ComboBox cmbEspecialidad;
		internal Windows.Forms.ComboBox cmbProfesion;
		internal Windows.Forms.ComboBox cmbNacionalidadPersonal;
		internal Windows.Forms.ComboBox cmbTipoSangre;
		internal Windows.Forms.Label Label93;
		internal Windows.Forms.Label Label89;
		internal Windows.Forms.TextBox txtPorcDiscapacidad;
		internal Windows.Forms.Label Label91;
		internal Windows.Forms.TextBox txtDiscapacidad;
		internal Windows.Forms.GroupBox GroupBox12;
		internal Windows.Forms.ComboBox cmbRegionNace;
		internal Windows.Forms.ComboBox cmbCiudadNace;
		internal Windows.Forms.ComboBox cmbProvinciaNace;
		internal Windows.Forms.ComboBox cmbPaisNace;
		internal Windows.Forms.DateTimePicker fechanaci;
		internal Windows.Forms.Label Label28;
		internal Windows.Forms.Label Label84;
		internal Windows.Forms.Label Label85;
		internal Windows.Forms.Label Label86;
		internal Windows.Forms.TextBox Lugarnaci;
		internal Windows.Forms.Label Label23;
		internal Windows.Forms.Label Label22;
		internal Windows.Forms.Label Label80;
		internal Windows.Forms.Label Label77;
		internal Windows.Forms.GroupBox asociadoa;
		internal Windows.Forms.Button CbuscaDir3;
		internal Windows.Forms.TextBox LDir3;
		internal Windows.Forms.Label Label31;
		internal Windows.Forms.TextBox txtLugTra;
		internal Windows.Forms.Label Label30;
		internal Windows.Forms.TextBox txtNumTar;
		internal Windows.Forms.Label Label29;
		internal Windows.Forms.Label Label24;
		internal Windows.Forms.TextBox txtCodTar;
		internal Windows.Forms.TextBox hobbys;
		internal Windows.Forms.Label Label27;
		internal Windows.Forms.ComboBox txtReferirseComo;
		internal Windows.Forms.Label Label26;
		internal Windows.Forms.Label Label25;
		internal Windows.Forms.ComboBox cmbEstadoCivil;
		internal Windows.Forms.Label Label21;
		internal Windows.Forms.GroupBox GroupBox4;
		internal Windows.Forms.RadioButton mujer;
		internal Windows.Forms.RadioButton hombre;
		internal Windows.Forms.TabPage tabCliente;
		internal Windows.Forms.Button btnBuscaZonaVentas;
		internal Windows.Forms.Button CBuscador3;
		internal Windows.Forms.Label txtOperador;
		internal Windows.Forms.Button btnBuscaOperador;
		internal Windows.Forms.Label Label90;
		internal Windows.Forms.Label Cuenta4;
		internal Windows.Forms.Label Cuenta0;
		internal Windows.Forms.GroupBox GroupBox15;
		internal Windows.Forms.Button btnTransportadora;
		internal Windows.Forms.Label Label41;
		internal Windows.Forms.TextBox txtTransportadora;
		internal Windows.Forms.Label txtPaisEntrega;
		internal Windows.Forms.Button btnPuertoEntrega;
		internal Windows.Forms.Label Label94;
		internal Windows.Forms.Button btnPaísEntrega;
		internal Windows.Forms.Label Label95;
		internal Windows.Forms.TextBox entregarmer;
		internal Windows.Forms.Label txtCobrador;
		internal Windows.Forms.Label txtVendedor;
		internal Windows.Forms.Label txtZonaCobranzas;
		internal Windows.Forms.Label txtZonaVentas;
		internal Windows.Forms.Label txtTipoCliente;
		internal Windows.Forms.GroupBox GroupBox11;
		internal Windows.Forms.Label txtPrecioVenta;
		internal Windows.Forms.Label txtFormaPago;
		internal Windows.Forms.TextBox txtLimiteCredito;
		internal Windows.Forms.Label Label46;
		internal Windows.Forms.TextBox txtDescuentoAsociacion;
		internal Windows.Forms.Label Label43;
		internal Windows.Forms.TextBox txtPorcDescuento;
		internal Windows.Forms.Label Label40;
		internal Windows.Forms.Button btnFormaPago;
		internal Windows.Forms.Label Label39;
		internal Windows.Forms.Button btnPrecioVenta;
		internal Windows.Forms.Label Label38;
		internal Windows.Forms.Button Command5;
		internal Windows.Forms.Label Label75;
		internal Windows.Forms.Button Command1;
		internal Windows.Forms.Label Label45;
		internal Windows.Forms.TextBox observacli;
		internal Windows.Forms.Label Label44;
		internal Windows.Forms.TextBox txtContacto;
		internal Windows.Forms.Label Label42;
		internal Windows.Forms.Button btnBuscaCobrador;
		internal Windows.Forms.Label Label37;
		internal Windows.Forms.Button btnBuscaZonaCobro;
		internal Windows.Forms.Label Label36;
		internal Windows.Forms.Button btnBuscaVendedor;
		internal Windows.Forms.Label Label35;
		internal Windows.Forms.Label Label34;
		internal Windows.Forms.Label Label33;
		internal Windows.Forms.TabPage tabProveedor;
		internal Windows.Forms.Button CBuscador8;
		internal Windows.Forms.GroupBox GroupBox14;
		internal Windows.Forms.CheckBox chkTerrestre;
		internal Windows.Forms.Button Button6;
		internal Windows.Forms.CheckBox chkMaritimo;
		internal Windows.Forms.CheckBox chkAereo;
		internal Windows.Forms.TextBox observacionesprv;
		internal Windows.Forms.Label Label52;
		internal Windows.Forms.Label Lcod8;
		internal Windows.Forms.Label Cuenta5;
		internal Windows.Forms.Label Cuenta1;
		internal Windows.Forms.Button Command6;
		internal Windows.Forms.Label Label76;
		internal Windows.Forms.Label Label51;
		internal Windows.Forms.Button Command2;
		internal Windows.Forms.Label Label53;
		internal Windows.Forms.GroupBox GroupBox6;
		internal Windows.Forms.CheckBox chkRetirarTransporte;
		internal Windows.Forms.CheckBox chkRetirarProveedor;
		internal Windows.Forms.CheckBox chkEntregaDirecccion;
		internal Windows.Forms.TextBox servicios;
		internal Windows.Forms.TextBox producto;
		internal Windows.Forms.Label Label50;
		internal Windows.Forms.CheckBox incluyetransporte;
		internal Windows.Forms.TextBox limcreditoprv;
		internal Windows.Forms.Label Label49;
		internal Windows.Forms.TextBox porcedescuentoprv;
		internal Windows.Forms.Label Label48;
		internal Windows.Forms.Label Label47;
		internal Windows.Forms.TabPage tabEmpleado;
		internal Windows.Forms.ComboBox cmbSucursalRol;
		internal Windows.Forms.ComboBox cmbDepartamentoRol;
		internal Windows.Forms.ComboBox cmbCargoRol;
		internal Windows.Forms.TabControl TabDatosEmpleado;
		internal Windows.Forms.TabPage TabPage1;
		internal Windows.Forms.DataGridView mallaDatos;
		internal Windows.Forms.DataGridViewTextBoxColumn Campos1;
		internal Windows.Forms.DataGridViewTextBoxColumn valorcampo;
		internal Windows.Forms.TabPage TabPage2;
		internal Windows.Forms.DataGridView mallaConceptos;
		internal Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn1;
		internal Windows.Forms.DataGridViewCheckBoxColumn conceptoSeleccionado;
		internal Windows.Forms.Button btnCargarCapacitacion;
		internal Windows.Forms.DateTimePicker fJubilacion;
		internal Windows.Forms.DateTimePicker fsalida;
		internal Windows.Forms.DateTimePicker fingreso;
		internal Windows.Forms.Label Label81;
		internal Windows.Forms.Button Button7;
		internal Windows.Forms.Label Cuenta3;
		internal Windows.Forms.TextBox CodBimetrico;
		internal Windows.Forms.Label Cuenta2;
		internal Windows.Forms.GroupBox GroupBox9;
		internal Windows.Forms.TextBox Grupo6;
		internal Windows.Forms.Label Label73;
		internal Windows.Forms.TextBox Grupo5;
		internal Windows.Forms.Label Label72;
		internal Windows.Forms.TextBox Grupo4;
		internal Windows.Forms.Label Label71;
		internal Windows.Forms.TextBox Grupo3;
		internal Windows.Forms.Label Label70;
		internal Windows.Forms.TextBox Grupo2;
		internal Windows.Forms.Label Label69;
		internal Windows.Forms.TextBox Grupo1;
		internal Windows.Forms.Label Label68;
		internal Windows.Forms.Button Comctb2;
		internal Windows.Forms.Label Label63;
		internal Windows.Forms.Button ComCtb1;
		internal Windows.Forms.Label Label62;
		internal Windows.Forms.Label Label61;
		internal Windows.Forms.Label Label60;
		internal Windows.Forms.GroupBox GroupBox7;
		internal Windows.Forms.RadioButton Jubilado;
		internal Windows.Forms.RadioButton Eliminadorol;
		internal Windows.Forms.RadioButton Cesanterol;
		internal Windows.Forms.RadioButton activorol;
		internal Windows.Forms.GroupBox GroupBox8;
		internal Windows.Forms.TextBox Lcod11;
		internal Windows.Forms.TextBox txtHorasJornadaSemanal;
		internal Windows.Forms.TextBox valorsueldo;
		internal Windows.Forms.Label Label65;
		internal Windows.Forms.Button CBuscador11;
		internal Windows.Forms.Label Label64;
		internal Windows.Forms.RadioButton RolHoras;
		internal Windows.Forms.RadioButton rolproduccion;
		internal Windows.Forms.RadioButton roldiario;
		internal Windows.Forms.RadioButton rolmensual;
		internal Windows.Forms.GroupBox GroupBox10;
		internal Windows.Forms.Button CbuscaDir2;
		internal Windows.Forms.TextBox txtNomBanco;
		internal Windows.Forms.Label Label67;
		internal Windows.Forms.TextBox Nroctabancorol;
		internal Windows.Forms.Label Label66;
		internal Windows.Forms.RadioButton ctaahorrosrol;
		internal Windows.Forms.RadioButton ctacorrienterol;
		internal Windows.Forms.CheckBox AcreditaBanco;
		internal Windows.Forms.Label Label92;
		internal Windows.Forms.TextBox nivelrol;
		internal Windows.Forms.Label Label74;
		internal Windows.Forms.Label Label87;
		internal Windows.Forms.ComboBox cmbCentroCostoRol;
		internal Windows.Forms.ComboBox cmbModuloRol;
		internal Windows.Forms.ComboBox cmbSeccionRol;
		internal Windows.Forms.Label Label58;
		internal Windows.Forms.Label Label55;
		internal Windows.Forms.Label Label59;
		internal Windows.Forms.Label Label56;
		internal Windows.Forms.Label Label57;
		internal Windows.Forms.Label Label54;
		internal Windows.Forms.TabPage tabFamiliares;
		internal Windows.Forms.DataGridView malla;
		internal Windows.Forms.DataGridViewTextBoxColumn Nro;
		internal Windows.Forms.DataGridViewTextBoxColumn CedulaId;
		internal Windows.Forms.DataGridViewTextBoxColumn Nombres;
		internal Windows.Forms.DataGridViewComboBoxColumn Parentesco;
		internal Windows.Forms.DataGridViewTextBoxColumn FechaNacim;
		internal Windows.Forms.DataGridViewComboBoxColumn Sexo1;
		internal Windows.Forms.DataGridViewComboBoxColumn EstadoCivil;
		internal Windows.Forms.DataGridViewTextBoxColumn Direccion;
		internal Windows.Forms.DataGridViewTextBoxColumn Teléfono_1;
		internal Windows.Forms.DataGridViewTextBoxColumn Teléfono_2;
		internal Windows.Forms.DataGridViewTextBoxColumn Ocupación;
		internal Windows.Forms.DataGridViewComboBoxColumn Depend;
		internal Windows.Forms.DataGridViewComboBoxColumn Minusv;
		internal Windows.Forms.TabPage tabContactos;
		internal Windows.Forms.DataGridView MallaCtco;
		internal Windows.Forms.DataGridViewTextBoxColumn TipoContacto;
		internal Windows.Forms.DataGridViewTextBoxColumn Nombrecontacto;
		internal Windows.Forms.DataGridViewTextBoxColumn Cargo;
		internal Windows.Forms.DataGridViewTextBoxColumn NroExtensión;
		internal Windows.Forms.DataGridViewTextBoxColumn NroTlfCelular;
		internal Windows.Forms.DataGridViewTextBoxColumn NroTlfDirecto;
		internal Windows.Forms.DataGridViewTextBoxColumn FecNacimto;
		internal Windows.Forms.DataGridViewTextBoxColumn Actividades;
		internal Windows.Forms.DataGridViewTextBoxColumn Preferencias;
		internal Windows.Forms.DataGridViewTextBoxColumn Observaciones;
		internal Windows.Forms.TabPage tabAlias;
		internal Windows.Forms.DataGridView MallaAlias;
		internal Windows.Forms.DataGridViewTextBoxColumn NombreAliasSucursal;
		internal Windows.Forms.DataGridViewTextBoxColumn DirecciónAlterna;
		internal Windows.Forms.DataGridViewTextBoxColumn Teléfono1;
		internal Windows.Forms.DataGridViewTextBoxColumn Teléfono2;
		internal Windows.Forms.DataGridViewTextBoxColumn IdSri;
		internal Windows.Forms.DataGridViewTextBoxColumn Observaciones1;
		internal Windows.Forms.Panel Panel1;
		internal Windows.Forms.TextBox Apellidos;
		internal Windows.Forms.TextBox txtHistoriaclinica;
		internal Windows.Forms.Label Label1;
		internal Windows.Forms.Label Label79;
		internal Windows.Forms.TextBox Codigo;
		internal Windows.Forms.Label Label2;
		internal Windows.Forms.ComboBox TipoIdent;
		internal Windows.Forms.Label Label3;
		internal Windows.Forms.TextBox TxtCedulaRuc;
		internal Windows.Forms.Label Label4;
		internal Windows.Forms.TextBox TxtNombres;
		internal Windows.Forms.Label Label32;
		internal Windows.Forms.ToolStrip ToolStrip1;
		internal Windows.Forms.ToolStripButton btnNuevo;
		internal Windows.Forms.ToolStripButton btnAbrir;
		internal Windows.Forms.ToolStripButton btnCerrar;
		internal Windows.Forms.ToolStripButton btnGuardar;
		internal Windows.Forms.ToolStripButton btnEliminar;
		internal Windows.Forms.ToolStripButton btnSalir;
		internal Windows.Forms.Label txtGrupo2;
		internal Windows.Forms.Label txtGrupo3;
		internal Windows.Forms.Label txtGrupo1;
		internal Windows.Forms.Button Button3;
		internal Windows.Forms.Button Button2;
		internal Windows.Forms.Button Button1;
		internal Windows.Forms.Label Label78;
		internal Windows.Forms.PictureBox foto;
	}
}