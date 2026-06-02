
namespace DaxInvent
{
	partial class frmExistenciaBod
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExistenciaBod));
			this.plCentro = new System.Windows.Forms.Panel();
			this.malla = new System.Windows.Forms.DataGridView();
			this.plOpciones = new System.Windows.Forms.Panel();
			this.GroupBox2 = new System.Windows.Forms.GroupBox();
			this.labArticulo = new System.Windows.Forms.Label();
			this.btnBuscar = new System.Windows.Forms.Button();
			this.txtCodigo = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.chkAlfabetico = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.dtFechaFin = new System.Windows.Forms.DateTimePicker();
			this.cboBodega = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.btnLimpiar = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.cmbSubgrupo = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbGrupo = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbClase = new System.Windows.Forms.ComboBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.cmbCategoria = new System.Windows.Forms.ComboBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.ToolStripContainer4 = new System.Windows.Forms.ToolStripContainer();
			this.ToolStrip3 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.btnProcesar = new System.Windows.Forms.ToolStripButton();
			this.btnSumar = new System.Windows.Forms.ToolStripButton();
			this.btnGuardar = new System.Windows.Forms.ToolStripButton();
			this.btnMovimiento = new System.Windows.Forms.ToolStripButton();
			this.btnExcel = new System.Windows.Forms.ToolStripButton();
			this.btnImprimir = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.plCentro.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.malla)).BeginInit();
			this.plOpciones.SuspendLayout();
			this.GroupBox2.SuspendLayout();
			this.panel2.SuspendLayout();
			this.ToolStripContainer4.ContentPanel.SuspendLayout();
			this.ToolStripContainer4.SuspendLayout();
			this.ToolStrip3.SuspendLayout();
			this.SuspendLayout();
			// 
			// plCentro
			// 
			this.plCentro.Controls.Add(this.malla);
			this.plCentro.Dock = System.Windows.Forms.DockStyle.Fill;
			this.plCentro.Location = new System.Drawing.Point(323, 57);
			this.plCentro.Name = "plCentro";
			this.plCentro.Size = new System.Drawing.Size(533, 530);
			this.plCentro.TabIndex = 22;
			// 
			// malla
			// 
			this.malla.AllowUserToAddRows = false;
			this.malla.AllowUserToDeleteRows = false;
			this.malla.AllowUserToOrderColumns = true;
			this.malla.AllowUserToResizeColumns = false;
			this.malla.AllowUserToResizeRows = false;
			dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.malla.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
			this.malla.BackgroundColor = System.Drawing.Color.White;
			this.malla.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle8.BackColor = System.Drawing.Color.SteelBlue;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.malla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
			this.malla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle9.Format = "###,##0.00;(###,##0.00);#";
			dataGridViewCellStyle9.NullValue = null;
			dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.malla.DefaultCellStyle = dataGridViewCellStyle9;
			this.malla.Dock = System.Windows.Forms.DockStyle.Fill;
			this.malla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
			this.malla.EnableHeadersVisualStyles = false;
			this.malla.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.malla.Location = new System.Drawing.Point(0, 0);
			this.malla.MultiSelect = false;
			this.malla.Name = "malla";
			this.malla.ReadOnly = true;
			this.malla.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.malla.RowHeadersVisible = false;
			this.malla.RowHeadersWidth = 20;
			this.malla.Size = new System.Drawing.Size(533, 530);
			this.malla.StandardTab = true;
			this.malla.TabIndex = 6;
			this.malla.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellContentClick);
			// 
			// plOpciones
			// 
			this.plOpciones.BackColor = System.Drawing.Color.DarkGray;
			this.plOpciones.Controls.Add(this.GroupBox2);
			this.plOpciones.Dock = System.Windows.Forms.DockStyle.Left;
			this.plOpciones.Location = new System.Drawing.Point(0, 57);
			this.plOpciones.Name = "plOpciones";
			this.plOpciones.Size = new System.Drawing.Size(323, 530);
			this.plOpciones.TabIndex = 21;
			// 
			// GroupBox2
			// 
			this.GroupBox2.Controls.Add(this.labArticulo);
			this.GroupBox2.Controls.Add(this.btnBuscar);
			this.GroupBox2.Controls.Add(this.txtCodigo);
			this.GroupBox2.Controls.Add(this.label7);
			this.GroupBox2.Controls.Add(this.chkAlfabetico);
			this.GroupBox2.Controls.Add(this.label5);
			this.GroupBox2.Controls.Add(this.dtFechaFin);
			this.GroupBox2.Controls.Add(this.cboBodega);
			this.GroupBox2.Controls.Add(this.label6);
			this.GroupBox2.Controls.Add(this.btnLimpiar);
			this.GroupBox2.Controls.Add(this.label4);
			this.GroupBox2.Controls.Add(this.cmbSubgrupo);
			this.GroupBox2.Controls.Add(this.label3);
			this.GroupBox2.Controls.Add(this.cmbGrupo);
			this.GroupBox2.Controls.Add(this.label1);
			this.GroupBox2.Controls.Add(this.cmbClase);
			this.GroupBox2.Controls.Add(this.Label2);
			this.GroupBox2.Controls.Add(this.cmbCategoria);
			this.GroupBox2.Location = new System.Drawing.Point(3, 6);
			this.GroupBox2.Name = "GroupBox2";
			this.GroupBox2.Size = new System.Drawing.Size(316, 553);
			this.GroupBox2.TabIndex = 12;
			this.GroupBox2.TabStop = false;
			this.GroupBox2.Text = "Niveles y Articulos";
			// 
			// labArticulo
			// 
			this.labArticulo.BackColor = System.Drawing.Color.White;
			this.labArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labArticulo.ForeColor = System.Drawing.Color.Black;
			this.labArticulo.Location = new System.Drawing.Point(8, 240);
			this.labArticulo.Name = "labArticulo";
			this.labArticulo.Size = new System.Drawing.Size(295, 20);
			this.labArticulo.TabIndex = 41;
			// 
			// btnBuscar
			// 
			this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
			this.btnBuscar.Location = new System.Drawing.Point(9, 216);
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(20, 21);
			this.btnBuscar.TabIndex = 42;
			this.btnBuscar.Text = "..";
			this.btnBuscar.UseVisualStyleBackColor = true;
			this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
			// 
			// txtCodigo
			// 
			this.txtCodigo.Location = new System.Drawing.Point(33, 217);
			this.txtCodigo.Name = "txtCodigo";
			this.txtCodigo.Size = new System.Drawing.Size(100, 20);
			this.txtCodigo.TabIndex = 39;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.Color.Black;
			this.label7.Location = new System.Drawing.Point(11, 199);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(60, 19);
			this.label7.TabIndex = 40;
			this.label7.Text = "Articulo";
			this.label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			this.label7.Visible = false;
			// 
			// chkAlfabetico
			// 
			this.chkAlfabetico.AutoSize = true;
			this.chkAlfabetico.Checked = true;
			this.chkAlfabetico.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkAlfabetico.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkAlfabetico.Location = new System.Drawing.Point(127, 47);
			this.chkAlfabetico.Name = "chkAlfabetico";
			this.chkAlfabetico.Size = new System.Drawing.Size(130, 21);
			this.chkAlfabetico.TabIndex = 34;
			this.chkAlfabetico.Text = "Orden alfabético";
			this.chkAlfabetico.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(6, 25);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(73, 19);
			this.label5.TabIndex = 33;
			this.label5.Text = "Saldo al :";
			// 
			// dtFechaFin
			// 
			this.dtFechaFin.CalendarFont = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtFechaFin.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtFechaFin.Location = new System.Drawing.Point(10, 43);
			this.dtFechaFin.Name = "dtFechaFin";
			this.dtFechaFin.Size = new System.Drawing.Size(100, 22);
			this.dtFechaFin.TabIndex = 32;
			// 
			// cboBodega
			// 
			this.cboBodega.FormattingEnabled = true;
			this.cboBodega.Location = new System.Drawing.Point(10, 92);
			this.cboBodega.Name = "cboBodega";
			this.cboBodega.Size = new System.Drawing.Size(253, 21);
			this.cboBodega.TabIndex = 30;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(7, 72);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 19);
			this.label6.TabIndex = 31;
			this.label6.Text = "Bodega";
			// 
			// btnLimpiar
			// 
			this.btnLimpiar.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLimpiar.Location = new System.Drawing.Point(96, 263);
			this.btnLimpiar.Name = "btnLimpiar";
			this.btnLimpiar.Size = new System.Drawing.Size(131, 36);
			this.btnLimpiar.TabIndex = 29;
			this.btnLimpiar.Text = "Limpiar Filtros";
			this.btnLimpiar.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(9, 364);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(79, 19);
			this.label4.TabIndex = 28;
			this.label4.Text = "SubGrupo";
			this.label4.Visible = false;
			// 
			// cmbSubgrupo
			// 
			this.cmbSubgrupo.FormattingEnabled = true;
			this.cmbSubgrupo.Location = new System.Drawing.Point(114, 367);
			this.cmbSubgrupo.Name = "cmbSubgrupo";
			this.cmbSubgrupo.Size = new System.Drawing.Size(134, 21);
			this.cmbSubgrupo.TabIndex = 27;
			this.cmbSubgrupo.Visible = false;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(6, 180);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(61, 19);
			this.label3.TabIndex = 26;
			this.label3.Text = "Grupo  ";
			// 
			// cmbGrupo
			// 
			this.cmbGrupo.FormattingEnabled = true;
			this.cmbGrupo.Location = new System.Drawing.Point(118, 174);
			this.cmbGrupo.Name = "cmbGrupo";
			this.cmbGrupo.Size = new System.Drawing.Size(134, 21);
			this.cmbGrupo.TabIndex = 25;
			this.cmbGrupo.SelectedIndexChanged += new System.EventHandler(this.cmbGrupo_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(6, 151);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 19);
			this.label1.TabIndex = 24;
			this.label1.Text = "Clase  ";
			// 
			// cmbClase
			// 
			this.cmbClase.FormattingEnabled = true;
			this.cmbClase.Location = new System.Drawing.Point(118, 148);
			this.cmbClase.Name = "cmbClase";
			this.cmbClase.Size = new System.Drawing.Size(134, 21);
			this.cmbClase.TabIndex = 23;
			this.cmbClase.SelectedIndexChanged += new System.EventHandler(this.cmbClase_SelectedIndexChanged);
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.Location = new System.Drawing.Point(6, 128);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(83, 19);
			this.Label2.TabIndex = 22;
			this.Label2.Text = "Categoria ";
			// 
			// cmbCategoria
			// 
			this.cmbCategoria.FormattingEnabled = true;
			this.cmbCategoria.Location = new System.Drawing.Point(118, 121);
			this.cmbCategoria.Name = "cmbCategoria";
			this.cmbCategoria.Size = new System.Drawing.Size(134, 21);
			this.cmbCategoria.TabIndex = 21;
			this.cmbCategoria.SelectedIndexChanged += new System.EventHandler(this.cmbCategoria_SelectedIndexChanged);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.ToolStripContainer4);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(856, 57);
			this.panel2.TabIndex = 20;
			// 
			// ToolStripContainer4
			// 
			this.ToolStripContainer4.BottomToolStripPanelVisible = false;
			// 
			// ToolStripContainer4.ContentPanel
			// 
			this.ToolStripContainer4.ContentPanel.AccessibleDescription = "AEA";
			this.ToolStripContainer4.ContentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.ToolStripContainer4.ContentPanel.Controls.Add(this.ToolStrip3);
			this.ToolStripContainer4.ContentPanel.Size = new System.Drawing.Size(856, 57);
			this.ToolStripContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ToolStripContainer4.LeftToolStripPanelVisible = false;
			this.ToolStripContainer4.Location = new System.Drawing.Point(0, 0);
			this.ToolStripContainer4.Name = "ToolStripContainer4";
			this.ToolStripContainer4.RightToolStripPanelVisible = false;
			this.ToolStripContainer4.Size = new System.Drawing.Size(856, 57);
			this.ToolStripContainer4.TabIndex = 3;
			this.ToolStripContainer4.Text = "ToolStripContainer4";
			// 
			// ToolStripContainer4.TopToolStripPanel
			// 
			this.ToolStripContainer4.TopToolStripPanel.Padding = new System.Windows.Forms.Padding(0, 0, 25, 25);
			this.ToolStripContainer4.TopToolStripPanelVisible = false;
			// 
			// ToolStrip3
			// 
			this.ToolStrip3.AutoSize = false;
			this.ToolStrip3.BackColor = System.Drawing.Color.DimGray;
			this.ToolStrip3.CanOverflow = false;
			this.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ToolStrip3.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.ToolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.btnProcesar,
            this.btnSumar,
            this.btnGuardar,
            this.btnMovimiento,
            this.btnExcel,
            this.btnImprimir,
            this.toolStripButton1});
			this.ToolStrip3.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
			this.ToolStrip3.Location = new System.Drawing.Point(0, 0);
			this.ToolStrip3.Name = "ToolStrip3";
			this.ToolStrip3.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
			this.ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.ToolStrip3.Size = new System.Drawing.Size(856, 57);
			this.ToolStrip3.TabIndex = 1;
			this.ToolStrip3.Text = "ToolStrip3";
			this.ToolStrip3.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolStrip3_ItemClicked);
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.ForeColor = System.Drawing.Color.White;
			this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(61, 54);
			this.toolStripButton2.Text = "&Opciones";
			this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
			// 
			// btnProcesar
			// 
			this.btnProcesar.ForeColor = System.Drawing.Color.White;
			this.btnProcesar.Image = ((System.Drawing.Image)(resources.GetObject("btnProcesar.Image")));
			this.btnProcesar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnProcesar.Name = "btnProcesar";
			this.btnProcesar.Size = new System.Drawing.Size(63, 54);
			this.btnProcesar.Text = "Actualizar";
			this.btnProcesar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnProcesar.ToolTipText = "Procesar";
			this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
			// 
			// btnSumar
			// 
			this.btnSumar.ForeColor = System.Drawing.Color.White;
			this.btnSumar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSumar.Name = "btnSumar";
			this.btnSumar.Size = new System.Drawing.Size(65, 54);
			this.btnSumar.Text = "Sumatoria";
			this.btnSumar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnSumar.ToolTipText = "Total";
			this.btnSumar.Visible = false;
			// 
			// btnGuardar
			// 
			this.btnGuardar.ForeColor = System.Drawing.Color.White;
			this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
			this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(46, 54);
			this.btnGuardar.Text = "Grabar";
			this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnGuardar.ToolTipText = "Guardar los datos registrados";
			this.btnGuardar.Visible = false;
			// 
			// btnMovimiento
			// 
			this.btnMovimiento.AutoSize = false;
			this.btnMovimiento.ForeColor = System.Drawing.Color.White;
			this.btnMovimiento.Image = ((System.Drawing.Image)(resources.GetObject("btnMovimiento.Image")));
			this.btnMovimiento.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnMovimiento.Name = "btnMovimiento";
			this.btnMovimiento.Size = new System.Drawing.Size(85, 67);
			this.btnMovimiento.Text = "Movimiento";
			this.btnMovimiento.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnMovimiento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnMovimiento.ToolTipText = "Movimiento";
			this.btnMovimiento.Click += new System.EventHandler(this.btnMovimiento_Click);
			// 
			// btnExcel
			// 
			this.btnExcel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
			this.btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnExcel.Name = "btnExcel";
			this.btnExcel.Size = new System.Drawing.Size(37, 54);
			this.btnExcel.Text = "Excel";
			this.btnExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnExcel.ToolTipText = "Enviar Excel";
			this.btnExcel.Visible = false;
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			// 
			// btnImprimir
			// 
			this.btnImprimir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
			this.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnImprimir.Name = "btnImprimir";
			this.btnImprimir.Size = new System.Drawing.Size(57, 54);
			this.btnImprimir.Text = "Imprimir";
			this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnImprimir.ToolTipText = "Imprimir";
			this.btnImprimir.Visible = false;
			this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.ForeColor = System.Drawing.Color.White;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(36, 54);
			this.toolStripButton1.Text = "Salir";
			this.toolStripButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// frmExistenciaBod
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(856, 587);
			this.Controls.Add(this.plCentro);
			this.Controls.Add(this.plOpciones);
			this.Controls.Add(this.panel2);
			this.Name = "frmExistenciaBod";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Reporte de Existencias Bodegas";
			this.Load += new System.EventHandler(this.frmExistenciaBod_Load);
			this.plCentro.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.malla)).EndInit();
			this.plOpciones.ResumeLayout(false);
			this.GroupBox2.ResumeLayout(false);
			this.GroupBox2.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ToolStripContainer4.ContentPanel.ResumeLayout(false);
			this.ToolStripContainer4.ResumeLayout(false);
			this.ToolStripContainer4.PerformLayout();
			this.ToolStrip3.ResumeLayout(false);
			this.ToolStrip3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel plCentro;
		private System.Windows.Forms.DataGridView malla;
		private System.Windows.Forms.Panel plOpciones;
		internal System.Windows.Forms.GroupBox GroupBox2;
		private System.Windows.Forms.Label labArticulo;
		private System.Windows.Forms.Button btnBuscar;
		private System.Windows.Forms.TextBox txtCodigo;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.CheckBox chkAlfabetico;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker dtFechaFin;
		private System.Windows.Forms.ComboBox cboBodega;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnLimpiar;
		internal System.Windows.Forms.Label label4;
		internal System.Windows.Forms.ComboBox cmbSubgrupo;
		internal System.Windows.Forms.Label label3;
		internal System.Windows.Forms.ComboBox cmbGrupo;
		internal System.Windows.Forms.Label label1;
		internal System.Windows.Forms.ComboBox cmbClase;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.ComboBox cmbCategoria;
		private System.Windows.Forms.Panel panel2;
		internal System.Windows.Forms.ToolStripContainer ToolStripContainer4;
		internal System.Windows.Forms.ToolStrip ToolStrip3;
		internal System.Windows.Forms.ToolStripButton toolStripButton2;
		internal System.Windows.Forms.ToolStripButton btnProcesar;
		internal System.Windows.Forms.ToolStripButton btnSumar;
		internal System.Windows.Forms.ToolStripButton btnGuardar;
		internal System.Windows.Forms.ToolStripButton btnMovimiento;
		private System.Windows.Forms.ToolStripButton btnExcel;
		private System.Windows.Forms.ToolStripButton btnImprimir;
		internal System.Windows.Forms.ToolStripButton toolStripButton1;
	}
}