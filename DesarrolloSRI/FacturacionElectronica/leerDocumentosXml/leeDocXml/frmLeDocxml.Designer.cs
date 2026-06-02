namespace leeDocXml
{
    partial class frmLeDocxml
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLeDocxml));
			this.buscaArchivos = new System.Windows.Forms.OpenFileDialog();
			this.mallaReferencia = new System.Windows.Forms.DataGridView();
			this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnImportar = new System.Windows.Forms.ToolStripButton();
			this.btnCancela = new System.Windows.Forms.ToolStripButton();
			this.btnProcesar = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnDirectorio = new System.Windows.Forms.ToolStripButton();
			this.btnDirectorioExpress = new System.Windows.Forms.ToolStripButton();
			this.btnMantProducto = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.btnDocumento = new System.Windows.Forms.ToolStripButton();
			this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnSalir = new System.Windows.Forms.ToolStripButton();
			this.labProveedor = new System.Windows.Forms.Label();
			this.labDocumento = new System.Windows.Forms.Label();
			this.labValores = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbDocumentosAdcom = new System.Windows.Forms.ComboBox();
			this.labAutorizacion = new System.Windows.Forms.Label();
			this.labFecha = new System.Windows.Forms.Label();
			this.labDirectorios = new System.Windows.Forms.Label();
			this.txtCodDirectorioAdcom = new System.Windows.Forms.TextBox();
			this.txtRuc = new System.Windows.Forms.TextBox();
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.txtDocTipOrigen = new System.Windows.Forms.TextBox();
			this.txtIdRucOrigen = new System.Windows.Forms.TextBox();
			this.txtDocNumeroOrigen = new System.Windows.Forms.TextBox();
			this.txtAutorizacionSriOrigen = new System.Windows.Forms.TextBox();
			this.txtFechaAutorizacionOrigen = new System.Windows.Forms.TextBox();
			this.txtValorDocOrigen = new System.Windows.Forms.TextBox();
			this.txtFechaDocOrigen = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.cmbBodegaAdcom = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.chkSumarItems = new System.Windows.Forms.RadioButton();
			this.chkAgruparItems = new System.Windows.Forms.RadioButton();
			this.label3 = new System.Windows.Forms.Label();
			this.chkTodosCodigoIgual = new System.Windows.Forms.CheckBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.mallaReferencia)).BeginInit();
			this.ToolStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mallaReferencia
			// 
			this.mallaReferencia.AllowUserToAddRows = false;
			this.mallaReferencia.AllowUserToDeleteRows = false;
			this.mallaReferencia.AllowUserToOrderColumns = true;
			this.mallaReferencia.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.mallaReferencia.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.mallaReferencia.BackgroundColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.mallaReferencia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.mallaReferencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.mallaReferencia.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mallaReferencia.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
			this.mallaReferencia.EnableHeadersVisualStyles = false;
			this.mallaReferencia.Location = new System.Drawing.Point(0, 187);
			this.mallaReferencia.Name = "mallaReferencia";
			this.mallaReferencia.RowHeadersWidth = 20;
			this.mallaReferencia.Size = new System.Drawing.Size(982, 196);
			this.mallaReferencia.TabIndex = 1;
			this.mallaReferencia.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.mallaReferencia_CellEndEdit);
			this.mallaReferencia.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.mallaReferencia_CellValueChanged);
			this.mallaReferencia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mallaReferencia_KeyDown);
			// 
			// ToolStrip1
			// 
			this.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ToolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnImportar,
            this.btnCancela,
            this.btnProcesar,
            this.toolStripSeparator2,
            this.btnDirectorio,
            this.btnDirectorioExpress,
            this.btnMantProducto,
            this.toolStripSeparator3,
            this.btnDocumento,
            this.ToolStripSeparator1,
            this.btnSalir});
			this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
			this.ToolStrip1.Name = "ToolStrip1";
			this.ToolStrip1.Size = new System.Drawing.Size(982, 39);
			this.ToolStrip1.TabIndex = 3;
			this.ToolStrip1.Text = "ToolStrip1";
			// 
			// btnImportar
			// 
			this.btnImportar.ForeColor = System.Drawing.Color.White;
			this.btnImportar.Image = ((System.Drawing.Image)(resources.GetObject("btnImportar.Image")));
			this.btnImportar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnImportar.Name = "btnImportar";
			this.btnImportar.Size = new System.Drawing.Size(89, 36);
			this.btnImportar.Text = "Importar";
			this.btnImportar.Click += new System.EventHandler(this.button1_Click);
			// 
			// btnCancela
			// 
			this.btnCancela.ForeColor = System.Drawing.Color.White;
			this.btnCancela.Image = ((System.Drawing.Image)(resources.GetObject("btnCancela.Image")));
			this.btnCancela.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnCancela.Name = "btnCancela";
			this.btnCancela.Size = new System.Drawing.Size(89, 36);
			this.btnCancela.Text = "Cancelar";
			this.btnCancela.Click += new System.EventHandler(this.btnCancela_Click);
			// 
			// btnProcesar
			// 
			this.btnProcesar.ForeColor = System.Drawing.Color.White;
			this.btnProcesar.Image = ((System.Drawing.Image)(resources.GetObject("btnProcesar.Image")));
			this.btnProcesar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnProcesar.Name = "btnProcesar";
			this.btnProcesar.Size = new System.Drawing.Size(78, 36);
			this.btnProcesar.Text = "Grabar";
			this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
			// 
			// btnDirectorio
			// 
			this.btnDirectorio.ForeColor = System.Drawing.Color.White;
			this.btnDirectorio.Image = ((System.Drawing.Image)(resources.GetObject("btnDirectorio.Image")));
			this.btnDirectorio.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnDirectorio.Name = "btnDirectorio";
			this.btnDirectorio.Size = new System.Drawing.Size(95, 36);
			this.btnDirectorio.Text = "Directorio";
			this.btnDirectorio.ToolTipText = "Creación abierta en directorio";
			this.btnDirectorio.Click += new System.EventHandler(this.btnDirectorio_Click);
			// 
			// btnDirectorioExpress
			// 
			this.btnDirectorioExpress.ForeColor = System.Drawing.Color.White;
			this.btnDirectorioExpress.Image = ((System.Drawing.Image)(resources.GetObject("btnDirectorioExpress.Image")));
			this.btnDirectorioExpress.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnDirectorioExpress.Name = "btnDirectorioExpress";
			this.btnDirectorioExpress.Size = new System.Drawing.Size(96, 36);
			this.btnDirectorioExpress.Text = "DirExpress";
			this.btnDirectorioExpress.ToolTipText = "Creación rápida de registro en directorio ";
			this.btnDirectorioExpress.Click += new System.EventHandler(this.btnDirectorioExpress_Click);
			// 
			// btnMantProducto
			// 
			this.btnMantProducto.ForeColor = System.Drawing.Color.White;
			this.btnMantProducto.Image = ((System.Drawing.Image)(resources.GetObject("btnMantProducto.Image")));
			this.btnMantProducto.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnMantProducto.Name = "btnMantProducto";
			this.btnMantProducto.Size = new System.Drawing.Size(97, 36);
			this.btnMantProducto.Text = "Productos";
			this.btnMantProducto.ToolTipText = "Mantenimiento de productos de inventario";
			this.btnMantProducto.Click += new System.EventHandler(this.btnMantProducto_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
			// 
			// btnDocumento
			// 
			this.btnDocumento.ForeColor = System.Drawing.Color.White;
			this.btnDocumento.Image = ((System.Drawing.Image)(resources.GetObject("btnDocumento.Image")));
			this.btnDocumento.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnDocumento.Name = "btnDocumento";
			this.btnDocumento.Size = new System.Drawing.Size(106, 36);
			this.btnDocumento.Text = "Documento";
			this.btnDocumento.ToolTipText = "Verificar Documento grabado";
			this.btnDocumento.Click += new System.EventHandler(this.btnDocumento_Click);
			// 
			// ToolStripSeparator1
			// 
			this.ToolStripSeparator1.Name = "ToolStripSeparator1";
			this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 39);
			// 
			// btnSalir
			// 
			this.btnSalir.ForeColor = System.Drawing.Color.White;
			this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
			this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSalir.Name = "btnSalir";
			this.btnSalir.Size = new System.Drawing.Size(65, 36);
			this.btnSalir.Text = "Salir";
			this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
			// 
			// labProveedor
			// 
			this.labProveedor.AutoSize = true;
			this.labProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labProveedor.ForeColor = System.Drawing.Color.White;
			this.labProveedor.Location = new System.Drawing.Point(23, 8);
			this.labProveedor.Name = "labProveedor";
			this.labProveedor.Size = new System.Drawing.Size(49, 15);
			this.labProveedor.TabIndex = 1;
			this.labProveedor.Text = "Ci/Ruc :";
			// 
			// labDocumento
			// 
			this.labDocumento.AutoSize = true;
			this.labDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labDocumento.ForeColor = System.Drawing.Color.White;
			this.labDocumento.Location = new System.Drawing.Point(23, 37);
			this.labDocumento.Name = "labDocumento";
			this.labDocumento.Size = new System.Drawing.Size(74, 15);
			this.labDocumento.TabIndex = 2;
			this.labDocumento.Text = "Documento:";
			// 
			// labValores
			// 
			this.labValores.AutoSize = true;
			this.labValores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labValores.ForeColor = System.Drawing.Color.White;
			this.labValores.Location = new System.Drawing.Point(259, 69);
			this.labValores.Name = "labValores";
			this.labValores.Size = new System.Drawing.Size(41, 15);
			this.labValores.TabIndex = 3;
			this.labValores.Text = "Valor :";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(477, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(141, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Tipo de documento ADCOM";
			// 
			// cmbDocumentosAdcom
			// 
			this.cmbDocumentosAdcom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbDocumentosAdcom.FormattingEnabled = true;
			this.cmbDocumentosAdcom.Location = new System.Drawing.Point(624, 35);
			this.cmbDocumentosAdcom.Name = "cmbDocumentosAdcom";
			this.cmbDocumentosAdcom.Size = new System.Drawing.Size(280, 21);
			this.cmbDocumentosAdcom.TabIndex = 5;
			this.cmbDocumentosAdcom.SelectedIndexChanged += new System.EventHandler(this.cmbDocumentos_SelectedIndexChanged);
			// 
			// labAutorizacion
			// 
			this.labAutorizacion.AutoSize = true;
			this.labAutorizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labAutorizacion.ForeColor = System.Drawing.Color.White;
			this.labAutorizacion.Location = new System.Drawing.Point(23, 52);
			this.labAutorizacion.Name = "labAutorizacion";
			this.labAutorizacion.Size = new System.Drawing.Size(77, 15);
			this.labAutorizacion.TabIndex = 7;
			this.labAutorizacion.Text = "Autorización:";
			// 
			// labFecha
			// 
			this.labFecha.AutoSize = true;
			this.labFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labFecha.ForeColor = System.Drawing.Color.White;
			this.labFecha.Location = new System.Drawing.Point(23, 67);
			this.labFecha.Name = "labFecha";
			this.labFecha.Size = new System.Drawing.Size(117, 15);
			this.labFecha.TabIndex = 8;
			this.labFecha.Text = "Fecha autorización :";
			// 
			// labDirectorios
			// 
			this.labDirectorios.AutoSize = true;
			this.labDirectorios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labDirectorios.ForeColor = System.Drawing.Color.White;
			this.labDirectorios.Location = new System.Drawing.Point(476, 8);
			this.labDirectorios.Name = "labDirectorios";
			this.labDirectorios.Size = new System.Drawing.Size(153, 15);
			this.labDirectorios.TabIndex = 9;
			this.labDirectorios.Text = "Código directorio ADCOM :";
			// 
			// txtCodDirectorioAdcom
			// 
			this.txtCodDirectorioAdcom.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtCodDirectorioAdcom.Location = new System.Drawing.Point(634, 11);
			this.txtCodDirectorioAdcom.Name = "txtCodDirectorioAdcom";
			this.txtCodDirectorioAdcom.Size = new System.Drawing.Size(127, 13);
			this.txtCodDirectorioAdcom.TabIndex = 10;
			// 
			// txtRuc
			// 
			this.txtRuc.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtRuc.Location = new System.Drawing.Point(103, 11);
			this.txtRuc.Name = "txtRuc";
			this.txtRuc.ReadOnly = true;
			this.txtRuc.Size = new System.Drawing.Size(81, 13);
			this.txtRuc.TabIndex = 11;
			// 
			// txtNombre
			// 
			this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtNombre.Location = new System.Drawing.Point(190, 11);
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.ReadOnly = true;
			this.txtNombre.Size = new System.Drawing.Size(279, 13);
			this.txtNombre.TabIndex = 12;
			// 
			// txtDocTipOrigen
			// 
			this.txtDocTipOrigen.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtDocTipOrigen.Location = new System.Drawing.Point(103, 41);
			this.txtDocTipOrigen.Name = "txtDocTipOrigen";
			this.txtDocTipOrigen.ReadOnly = true;
			this.txtDocTipOrigen.Size = new System.Drawing.Size(32, 13);
			this.txtDocTipOrigen.TabIndex = 13;
			// 
			// txtIdRucOrigen
			// 
			this.txtIdRucOrigen.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtIdRucOrigen.Location = new System.Drawing.Point(141, 41);
			this.txtIdRucOrigen.Name = "txtIdRucOrigen";
			this.txtIdRucOrigen.ReadOnly = true;
			this.txtIdRucOrigen.Size = new System.Drawing.Size(53, 13);
			this.txtIdRucOrigen.TabIndex = 14;
			// 
			// txtDocNumeroOrigen
			// 
			this.txtDocNumeroOrigen.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtDocNumeroOrigen.Location = new System.Drawing.Point(200, 41);
			this.txtDocNumeroOrigen.Name = "txtDocNumeroOrigen";
			this.txtDocNumeroOrigen.ReadOnly = true;
			this.txtDocNumeroOrigen.Size = new System.Drawing.Size(102, 13);
			this.txtDocNumeroOrigen.TabIndex = 15;
			// 
			// txtAutorizacionSriOrigen
			// 
			this.txtAutorizacionSriOrigen.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtAutorizacionSriOrigen.Location = new System.Drawing.Point(103, 56);
			this.txtAutorizacionSriOrigen.Name = "txtAutorizacionSriOrigen";
			this.txtAutorizacionSriOrigen.ReadOnly = true;
			this.txtAutorizacionSriOrigen.Size = new System.Drawing.Size(366, 13);
			this.txtAutorizacionSriOrigen.TabIndex = 16;
			// 
			// txtFechaAutorizacionOrigen
			// 
			this.txtFechaAutorizacionOrigen.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtFechaAutorizacionOrigen.Location = new System.Drawing.Point(146, 71);
			this.txtFechaAutorizacionOrigen.Name = "txtFechaAutorizacionOrigen";
			this.txtFechaAutorizacionOrigen.ReadOnly = true;
			this.txtFechaAutorizacionOrigen.Size = new System.Drawing.Size(100, 13);
			this.txtFechaAutorizacionOrigen.TabIndex = 17;
			// 
			// txtValorDocOrigen
			// 
			this.txtValorDocOrigen.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtValorDocOrigen.Location = new System.Drawing.Point(306, 71);
			this.txtValorDocOrigen.Name = "txtValorDocOrigen";
			this.txtValorDocOrigen.ReadOnly = true;
			this.txtValorDocOrigen.Size = new System.Drawing.Size(87, 13);
			this.txtValorDocOrigen.TabIndex = 18;
			this.txtValorDocOrigen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtFechaDocOrigen
			// 
			this.txtFechaDocOrigen.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtFechaDocOrigen.Location = new System.Drawing.Point(308, 41);
			this.txtFechaDocOrigen.Name = "txtFechaDocOrigen";
			this.txtFechaDocOrigen.ReadOnly = true;
			this.txtFechaDocOrigen.Size = new System.Drawing.Size(81, 13);
			this.txtFechaDocOrigen.TabIndex = 19;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(23, 23);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(113, 15);
			this.label2.TabIndex = 20;
			this.label2.Text = "Correo electrónico: ";
			// 
			// txtEmail
			// 
			this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtEmail.Location = new System.Drawing.Point(136, 26);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.ReadOnly = true;
			this.txtEmail.Size = new System.Drawing.Size(333, 13);
			this.txtEmail.TabIndex = 21;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panel1.Controls.Add(this.cmbBodegaAdcom);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.txtEmail);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.txtFechaDocOrigen);
			this.panel1.Controls.Add(this.txtValorDocOrigen);
			this.panel1.Controls.Add(this.txtFechaAutorizacionOrigen);
			this.panel1.Controls.Add(this.txtAutorizacionSriOrigen);
			this.panel1.Controls.Add(this.txtDocNumeroOrigen);
			this.panel1.Controls.Add(this.txtIdRucOrigen);
			this.panel1.Controls.Add(this.txtDocTipOrigen);
			this.panel1.Controls.Add(this.txtNombre);
			this.panel1.Controls.Add(this.txtRuc);
			this.panel1.Controls.Add(this.txtCodDirectorioAdcom);
			this.panel1.Controls.Add(this.labDirectorios);
			this.panel1.Controls.Add(this.labFecha);
			this.panel1.Controls.Add(this.labAutorizacion);
			this.panel1.Controls.Add(this.cmbDocumentosAdcom);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.labValores);
			this.panel1.Controls.Add(this.labDocumento);
			this.panel1.Controls.Add(this.labProveedor);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 39);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(982, 90);
			this.panel1.TabIndex = 2;
			// 
			// cmbBodegaAdcom
			// 
			this.cmbBodegaAdcom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbBodegaAdcom.FormattingEnabled = true;
			this.cmbBodegaAdcom.Location = new System.Drawing.Point(624, 62);
			this.cmbBodegaAdcom.Name = "cmbBodegaAdcom";
			this.cmbBodegaAdcom.Size = new System.Drawing.Size(280, 21);
			this.cmbBodegaAdcom.TabIndex = 23;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.White;
			this.label4.Location = new System.Drawing.Point(477, 69);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(143, 13);
			this.label4.TabIndex = 22;
			this.label4.Text = "Bodega local para artículos :";
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.SteelBlue;
			this.panel2.Controls.Add(this.groupBox1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 129);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(982, 58);
			this.panel2.TabIndex = 4;
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.SystemColors.ControlDark;
			this.groupBox1.Controls.Add(this.chkSumarItems);
			this.groupBox1.Controls.Add(this.chkAgruparItems);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.chkTodosCodigoIgual);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.ForeColor = System.Drawing.Color.White;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(982, 58);
			this.groupBox1.TabIndex = 24;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Registro de items en documento ADCOM";
			// 
			// chkSumarItems
			// 
			this.chkSumarItems.AutoSize = true;
			this.chkSumarItems.Location = new System.Drawing.Point(293, 35);
			this.chkSumarItems.Name = "chkSumarItems";
			this.chkSumarItems.Size = new System.Drawing.Size(118, 17);
			this.chkSumarItems.TabIndex = 27;
			this.chkSumarItems.TabStop = true;
			this.chkSumarItems.Text = "Sumar items iguales";
			this.toolTip1.SetToolTip(this.chkSumarItems, "Suma únicamente el valor de los items iguales");
			this.chkSumarItems.UseVisualStyleBackColor = true;
			this.chkSumarItems.CheckedChanged += new System.EventHandler(this.chkSumarItems_CheckedChanged);
			// 
			// chkAgruparItems
			// 
			this.chkAgruparItems.AutoSize = true;
			this.chkAgruparItems.Location = new System.Drawing.Point(292, 13);
			this.chkAgruparItems.Name = "chkAgruparItems";
			this.chkAgruparItems.Size = new System.Drawing.Size(128, 17);
			this.chkAgruparItems.TabIndex = 26;
			this.chkAgruparItems.TabStop = true;
			this.chkAgruparItems.Text = "Agrupar items iguales ";
			this.toolTip1.SetToolTip(this.chkAgruparItems, "Suma únicamente el valor de los items iguales");
			this.chkAgruparItems.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.LightGray;
			this.label3.Location = new System.Drawing.Point(723, 18);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(223, 26);
			this.label3.TabIndex = 25;
			this.label3.Text = "Si no se registra código Adcom para el item se asignará el código del proveedor";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// chkTodosCodigoIgual
			// 
			this.chkTodosCodigoIgual.AutoSize = true;
			this.chkTodosCodigoIgual.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkTodosCodigoIgual.ForeColor = System.Drawing.Color.White;
			this.chkTodosCodigoIgual.Location = new System.Drawing.Point(6, 24);
			this.chkTodosCodigoIgual.Name = "chkTodosCodigoIgual";
			this.chkTodosCodigoIgual.Size = new System.Drawing.Size(251, 17);
			this.chkTodosCodigoIgual.TabIndex = 23;
			this.chkTodosCodigoIgual.Text = "Utilizar código Adcom del primer item para todos";
			this.chkTodosCodigoIgual.UseVisualStyleBackColor = true;
			this.chkTodosCodigoIgual.CheckedChanged += new System.EventHandler(this.chkTodosCodigoIgual_CheckedChanged);
			// 
			// frmLeDocxml
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(982, 383);
			this.Controls.Add(this.mallaReferencia);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.ToolStrip1);
			this.Name = "frmLeDocxml";
			this.Text = "Importación documentos Xml";
			this.Load += new System.EventHandler(this.frmLeDocxml_Load);
			((System.ComponentModel.ISupportInitialize)(this.mallaReferencia)).EndInit();
			this.ToolStrip1.ResumeLayout(false);
			this.ToolStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog buscaArchivos;
        private System.Windows.Forms.DataGridView mallaReferencia;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton btnImportar;
        internal System.Windows.Forms.ToolStripButton btnCancela;
        internal System.Windows.Forms.ToolStripButton btnProcesar;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton btnSalir;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        internal System.Windows.Forms.ToolStripButton btnDirectorioExpress;
        internal System.Windows.Forms.ToolStripButton btnDirectorio;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        internal System.Windows.Forms.ToolStripButton btnDocumento;
        private System.Windows.Forms.Label labProveedor;
        private System.Windows.Forms.Label labDocumento;
        private System.Windows.Forms.Label labValores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDocumentosAdcom;
        private System.Windows.Forms.Label labAutorizacion;
        private System.Windows.Forms.Label labFecha;
        private System.Windows.Forms.Label labDirectorios;
        private System.Windows.Forms.TextBox txtCodDirectorioAdcom;
        private System.Windows.Forms.TextBox txtRuc;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDocTipOrigen;
        private System.Windows.Forms.TextBox txtIdRucOrigen;
        private System.Windows.Forms.TextBox txtDocNumeroOrigen;
        private System.Windows.Forms.TextBox txtAutorizacionSriOrigen;
        private System.Windows.Forms.TextBox txtFechaAutorizacionOrigen;
        private System.Windows.Forms.TextBox txtValorDocOrigen;
        private System.Windows.Forms.TextBox txtFechaDocOrigen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkTodosCodigoIgual;
        internal System.Windows.Forms.ToolStripButton btnMantProducto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbBodegaAdcom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton chkSumarItems;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.RadioButton chkAgruparItems;
    }
}

