
namespace BuscadorDocumentos
{
    partial class frmSeleccDoc
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSeleccDoc));
            this.malla = new System.Windows.Forms.DataGridView();
            this.txtvalor = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.btnArticuloCod = new System.Windows.Forms.Button();
            this.txtArticuloNombre = new System.Windows.Forms.TextBox();
            this.txtDetalle = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtArtCodigo = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAceptar = new System.Windows.Forms.ToolStripButton();
            this.btnBuscar = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmbAutorizaciones = new System.Windows.Forms.ToolStripComboBox();
            this.cmbActivos = new System.Windows.Forms.ToolStripComboBox();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.cboPtoVenta = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtFechaFin = new System.Windows.Forms.DateTimePicker();
            this.txtFechaIn = new System.Windows.Forms.DateTimePicker();
            this.txtNumDoc = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.cboTipoDoc = new System.Windows.Forms.ComboBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.cboSucursal = new System.Windows.Forms.ComboBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.cboBodega = new System.Windows.Forms.ComboBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.btnServicioCod = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtClienteCod = new System.Windows.Forms.TextBox();
            this.txtClienteNombre = new System.Windows.Forms.TextBox();
            this.btnClienteCod = new System.Windows.Forms.Button();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.malla)).BeginInit();
            this.ToolStrip1.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.TableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // malla
            // 
            this.malla.AllowUserToAddRows = false;
            this.malla.AllowUserToDeleteRows = false;
            this.malla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.malla.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.malla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.malla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.malla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.malla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.malla.EnableHeadersVisualStyles = false;
            this.malla.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.malla.Location = new System.Drawing.Point(0, 146);
            this.malla.Name = "malla";
            this.malla.ReadOnly = true;
            this.malla.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.malla.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.malla.RowHeadersWidth = 20;
            this.malla.ShowCellToolTips = false;
            this.malla.ShowEditingIcon = false;
            this.malla.Size = new System.Drawing.Size(800, 304);
            this.malla.TabIndex = 12;
            // 
            // txtvalor
            // 
            this.txtvalor.Location = new System.Drawing.Point(439, 71);
            this.txtvalor.Name = "txtvalor";
            this.txtvalor.Size = new System.Drawing.Size(81, 20);
            this.txtvalor.TabIndex = 10;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(399, 74);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(34, 13);
            this.Label9.TabIndex = 57;
            this.Label9.Text = "Valor:";
            // 
            // btnArticuloCod
            // 
            this.btnArticuloCod.Image = ((System.Drawing.Image)(resources.GetObject("btnArticuloCod.Image")));
            this.btnArticuloCod.Location = new System.Drawing.Point(101, 50);
            this.btnArticuloCod.Name = "btnArticuloCod";
            this.btnArticuloCod.Size = new System.Drawing.Size(21, 20);
            this.btnArticuloCod.TabIndex = 43;
            this.btnArticuloCod.UseVisualStyleBackColor = true;
            this.btnArticuloCod.Click += new System.EventHandler(this.btnArticuloCod_Click);
            // 
            // txtArticuloNombre
            // 
            this.txtArticuloNombre.Location = new System.Drawing.Point(243, 51);
            this.txtArticuloNombre.Name = "txtArticuloNombre";
            this.txtArticuloNombre.Size = new System.Drawing.Size(277, 20);
            this.txtArticuloNombre.TabIndex = 7;
            // 
            // txtDetalle
            // 
            this.txtDetalle.Location = new System.Drawing.Point(54, 71);
            this.txtDetalle.Multiline = true;
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.Size = new System.Drawing.Size(341, 19);
            this.txtDetalle.TabIndex = 9;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(8, 74);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(43, 13);
            this.Label5.TabIndex = 45;
            this.Label5.Text = "Detalle:";
            // 
            // txtArtCodigo
            // 
            this.txtArtCodigo.Location = new System.Drawing.Point(124, 51);
            this.txtArtCodigo.Name = "txtArtCodigo";
            this.txtArtCodigo.Size = new System.Drawing.Size(97, 20);
            this.txtArtCodigo.TabIndex = 7;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(14, 52);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(88, 13);
            this.Label4.TabIndex = 41;
            this.Label4.Text = "Articulo/Servicio:";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(6, 32);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(96, 13);
            this.Label3.TabIndex = 37;
            this.Label3.Text = "Cliente/Proveedor:";
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // btnAceptar
            // 
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(52, 35);
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(46, 35);
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.ForeColor = System.Drawing.Color.White;
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // cmbAutorizaciones
            // 
            this.cmbAutorizaciones.Items.AddRange(new object[] {
            "Todos los documentos",
            "Documentos sin autorización",
            "Documentos autorizados"});
            this.cmbAutorizaciones.Name = "cmbAutorizaciones";
            this.cmbAutorizaciones.Size = new System.Drawing.Size(160, 38);
            // 
            // cmbActivos
            // 
            this.cmbActivos.AutoCompleteCustomSource.AddRange(new string[] {
            "Todos los documentos",
            "Documentos activos",
            "Documentos anulados"});
            this.cmbActivos.Items.AddRange(new object[] {
            "Todos los documentos",
            "Documentos activos",
            "Documentos anulados"});
            this.cmbActivos.Name = "cmbActivos";
            this.cmbActivos.Size = new System.Drawing.Size(160, 38);
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.BackColor = System.Drawing.Color.Gray;
            this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip1.ImageScalingSize = new System.Drawing.Size(24, 32);
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripSeparator2,
            this.btnAceptar,
            this.btnBuscar,
            this.ToolStripSeparator3,
            this.cmbAutorizaciones,
            this.cmbActivos,
            this.ToolStripSeparator1,
            this.btnSalir});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(800, 38);
            this.ToolStrip1.TabIndex = 1;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.ForeColor = System.Drawing.Color.White;
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // btnSalir
            // 
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 35);
            this.btnSalir.Text = "   Salir   ";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.Gray;
            this.Panel1.Controls.Add(this.cboPtoVenta);
            this.Panel1.Controls.Add(this.Label2);
            this.Panel1.Controls.Add(this.txtFechaFin);
            this.Panel1.Controls.Add(this.txtFechaIn);
            this.Panel1.Controls.Add(this.txtNumDoc);
            this.Panel1.Controls.Add(this.Label10);
            this.Panel1.Controls.Add(this.cboTipoDoc);
            this.Panel1.Controls.Add(this.Label6);
            this.Panel1.Controls.Add(this.cboSucursal);
            this.Panel1.Controls.Add(this.Label7);
            this.Panel1.Controls.Add(this.cboBodega);
            this.Panel1.Controls.Add(this.Label8);
            this.Panel1.Controls.Add(this.btnServicioCod);
            this.Panel1.Controls.Add(this.txtvalor);
            this.Panel1.Controls.Add(this.Label9);
            this.Panel1.Controls.Add(this.btnArticuloCod);
            this.Panel1.Controls.Add(this.txtArticuloNombre);
            this.Panel1.Controls.Add(this.txtDetalle);
            this.Panel1.Controls.Add(this.Label5);
            this.Panel1.Controls.Add(this.txtArtCodigo);
            this.Panel1.Controls.Add(this.Label4);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Controls.Add(this.txtClienteCod);
            this.Panel1.Controls.Add(this.txtClienteNombre);
            this.Panel1.Controls.Add(this.btnClienteCod);
            this.Panel1.Controls.Add(this.Label3);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.ForeColor = System.Drawing.Color.White;
            this.Panel1.Location = new System.Drawing.Point(0, 38);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(800, 108);
            this.Panel1.TabIndex = 11;
            // 
            // cboPtoVenta
            // 
            this.cboPtoVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPtoVenta.FormattingEnabled = true;
            this.cboPtoVenta.Location = new System.Drawing.Point(651, 85);
            this.cboPtoVenta.Name = "cboPtoVenta";
            this.cboPtoVenta.Size = new System.Drawing.Size(143, 21);
            this.cboPtoVenta.TabIndex = 77;
            // 
            // Label2
            // 
            this.Label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(594, 88);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(54, 13);
            this.Label2.TabIndex = 78;
            this.Label2.Text = "PuntoVta:";
            // 
            // txtFechaFin
            // 
            this.txtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFechaFin.Location = new System.Drawing.Point(161, 6);
            this.txtFechaFin.Name = "txtFechaFin";
            this.txtFechaFin.Size = new System.Drawing.Size(90, 20);
            this.txtFechaFin.TabIndex = 76;
            this.txtFechaFin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFechaFin_KeyDown);
            // 
            // txtFechaIn
            // 
            this.txtFechaIn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFechaIn.Location = new System.Drawing.Point(66, 6);
            this.txtFechaIn.Name = "txtFechaIn";
            this.txtFechaIn.Size = new System.Drawing.Size(90, 20);
            this.txtFechaIn.TabIndex = 75;
            this.txtFechaIn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFechaIn_KeyDown);
            // 
            // txtNumDoc
            // 
            this.txtNumDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumDoc.Location = new System.Drawing.Point(651, 65);
            this.txtNumDoc.Name = "txtNumDoc";
            this.txtNumDoc.Size = new System.Drawing.Size(143, 20);
            this.txtNumDoc.TabIndex = 74;
            // 
            // Label10
            // 
            this.Label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(583, 67);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(65, 13);
            this.Label10.TabIndex = 73;
            this.Label10.Text = "Nro. de lote:";
            // 
            // cboTipoDoc
            // 
            this.cboTipoDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipoDoc.FormattingEnabled = true;
            this.cboTipoDoc.Location = new System.Drawing.Point(651, 2);
            this.cboTipoDoc.Name = "cboTipoDoc";
            this.cboTipoDoc.Size = new System.Drawing.Size(143, 21);
            this.cboTipoDoc.TabIndex = 67;
            this.cboTipoDoc.SelectedIndexChanged += new System.EventHandler(this.cboTipoDoc_SelectedIndexChanged);
            // 
            // Label6
            // 
            this.Label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(579, 6);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(69, 13);
            this.Label6.TabIndex = 70;
            this.Label6.Text = "Tipo de Doc.";
            // 
            // cboSucursal
            // 
            this.cboSucursal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSucursal.FormattingEnabled = true;
            this.cboSucursal.Location = new System.Drawing.Point(651, 23);
            this.cboSucursal.Name = "cboSucursal";
            this.cboSucursal.Size = new System.Drawing.Size(143, 21);
            this.cboSucursal.TabIndex = 68;
            this.cboSucursal.SelectedIndexChanged += new System.EventHandler(this.cboSucursal_SelectedIndexChanged);
            // 
            // Label7
            // 
            this.Label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(594, 27);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(51, 13);
            this.Label7.TabIndex = 71;
            this.Label7.Text = "Sucursal:";
            // 
            // cboBodega
            // 
            this.cboBodega.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBodega.FormattingEnabled = true;
            this.cboBodega.Location = new System.Drawing.Point(651, 44);
            this.cboBodega.Name = "cboBodega";
            this.cboBodega.Size = new System.Drawing.Size(143, 21);
            this.cboBodega.TabIndex = 69;
            this.cboBodega.SelectedIndexChanged += new System.EventHandler(this.cboBodega_SelectedIndexChanged);
            // 
            // Label8
            // 
            this.Label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(601, 47);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(47, 13);
            this.Label8.TabIndex = 72;
            this.Label8.Text = "Bodega:";
            // 
            // btnServicioCod
            // 
            this.btnServicioCod.Image = ((System.Drawing.Image)(resources.GetObject("btnServicioCod.Image")));
            this.btnServicioCod.Location = new System.Drawing.Point(221, 51);
            this.btnServicioCod.Name = "btnServicioCod";
            this.btnServicioCod.Size = new System.Drawing.Size(21, 20);
            this.btnServicioCod.TabIndex = 63;
            this.btnServicioCod.UseVisualStyleBackColor = true;
            this.btnServicioCod.Click += new System.EventHandler(this.btnServicioCod_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(9, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(51, 13);
            this.Label1.TabIndex = 53;
            this.Label1.Text = "Período :";
            // 
            // txtClienteCod
            // 
            this.txtClienteCod.Location = new System.Drawing.Point(124, 31);
            this.txtClienteCod.Name = "txtClienteCod";
            this.txtClienteCod.Size = new System.Drawing.Size(97, 20);
            this.txtClienteCod.TabIndex = 5;
            // 
            // txtClienteNombre
            // 
            this.txtClienteNombre.Location = new System.Drawing.Point(222, 31);
            this.txtClienteNombre.Name = "txtClienteNombre";
            this.txtClienteNombre.Size = new System.Drawing.Size(298, 20);
            this.txtClienteNombre.TabIndex = 6;
            // 
            // btnClienteCod
            // 
            this.btnClienteCod.Image = ((System.Drawing.Image)(resources.GetObject("btnClienteCod.Image")));
            this.btnClienteCod.Location = new System.Drawing.Point(102, 30);
            this.btnClienteCod.Name = "btnClienteCod";
            this.btnClienteCod.Size = new System.Drawing.Size(21, 20);
            this.btnClienteCod.TabIndex = 39;
            this.btnClienteCod.UseVisualStyleBackColor = true;
            this.btnClienteCod.Click += new System.EventHandler(this.btnClienteCod_Click);
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.TableLayoutPanel1.ColumnCount = 1;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.35294F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.64706F));
            this.TableLayoutPanel1.Controls.Add(this.ToolStrip1, 0, 0);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(800, 38);
            this.TableLayoutPanel1.TabIndex = 10;
            // 
            // frmSeleccDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.malla);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Name = "frmSeleccDoc";
            this.ShowIcon = false;
            this.Text = "SELECCIONAR VARIOS DOCUMENTOS";
            ((System.ComponentModel.ISupportInitialize)(this.malla)).EndInit();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.TableLayoutPanel1.ResumeLayout(false);
            this.TableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView malla;
        private System.Windows.Forms.TextBox txtvalor;
        internal System.Windows.Forms.Label Label9;
        private System.Windows.Forms.Button btnArticuloCod;
        internal System.Windows.Forms.TextBox txtArticuloNombre;
        private System.Windows.Forms.TextBox txtDetalle;
        internal System.Windows.Forms.Label Label5;
        private System.Windows.Forms.TextBox txtArtCodigo;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnAceptar;
        private System.Windows.Forms.ToolStripButton btnBuscar;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
        internal System.Windows.Forms.ToolStripComboBox cmbAutorizaciones;
        internal System.Windows.Forms.ToolStripComboBox cmbActivos;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSalir;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.ComboBox cboPtoVenta;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.DateTimePicker txtFechaFin;
        private System.Windows.Forms.DateTimePicker txtFechaIn;
        internal System.Windows.Forms.TextBox txtNumDoc;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.ComboBox cboTipoDoc;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.ComboBox cboSucursal;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.ComboBox cboBodega;
        internal System.Windows.Forms.Label Label8;
        private System.Windows.Forms.Button btnServicioCod;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox txtClienteCod;
        internal System.Windows.Forms.TextBox txtClienteNombre;
        private System.Windows.Forms.Button btnClienteCod;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
    }
}