namespace daxFaxPed
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.mallaPedidos = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dateHasta = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateDesde = new System.Windows.Forms.DateTimePicker();
            this.cboSucursal = new System.Windows.Forms.ComboBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.mallaDetalle = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtNomTransportadora = new System.Windows.Forms.TextBox();
            this.txtcedulaTransportista = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtConsignarNom = new System.Windows.Forms.TextBox();
            this.txtConsigarCod = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ToolStripContainer4 = new System.Windows.Forms.ToolStripContainer();
            this.ToolStrip12 = new System.Windows.Forms.ToolStrip();
            this.ToolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.ToolStrip10 = new System.Windows.Forms.ToolStrip();
            this.btnBarras = new System.Windows.Forms.ToolStripButton();
            this.btnAgrupa = new System.Windows.Forms.ToolStripButton();
            this.ToolStrip7 = new System.Windows.Forms.ToolStrip();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDespacho = new System.Windows.Forms.ToolStripButton();
            this.btnRevisar = new System.Windows.Forms.ToolStripButton();
            this.btnFacturaDirecta = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.ToolStrip3 = new System.Windows.Forms.ToolStrip();
            this.btnAbre = new System.Windows.Forms.ToolStripButton();
            this.btnElimina = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mallaPedidos)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mallaDetalle)).BeginInit();
            this.panel2.SuspendLayout();
            this.TableLayoutPanel1.SuspendLayout();
            this.ToolStripContainer4.ContentPanel.SuspendLayout();
            this.ToolStripContainer4.SuspendLayout();
            this.ToolStrip12.SuspendLayout();
            this.ToolStrip10.SuspendLayout();
            this.ToolStrip7.SuspendLayout();
            this.ToolStrip4.SuspendLayout();
            this.ToolStrip3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 67);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.mallaPedidos);
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.mallaDetalle);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(994, 479);
            this.splitContainer1.SplitterDistance = 331;
            this.splitContainer1.TabIndex = 9;
            // 
            // mallaPedidos
            // 
            this.mallaPedidos.AllowUserToAddRows = false;
            this.mallaPedidos.AllowUserToDeleteRows = false;
            this.mallaPedidos.AllowUserToResizeRows = false;
            this.mallaPedidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.mallaPedidos.BackgroundColor = System.Drawing.Color.White;
            this.mallaPedidos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mallaPedidos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.mallaPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mallaPedidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mallaPedidos.EnableHeadersVisualStyles = false;
            this.mallaPedidos.GridColor = System.Drawing.Color.WhiteSmoke;
            this.mallaPedidos.Location = new System.Drawing.Point(0, 61);
            this.mallaPedidos.Name = "mallaPedidos";
            this.mallaPedidos.ReadOnly = true;
            this.mallaPedidos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mallaPedidos.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.mallaPedidos.RowHeadersWidth = 20;
            this.mallaPedidos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.mallaPedidos.ShowEditingIcon = false;
            this.mallaPedidos.Size = new System.Drawing.Size(331, 418);
            this.mallaPedidos.TabIndex = 10;
            this.mallaPedidos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.mallaPedidos_CellEnter);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.dateHasta);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.dateDesde);
            this.panel3.Controls.Add(this.cboSucursal);
            this.panel3.Controls.Add(this.Label7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(331, 61);
            this.panel3.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(171, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 72;
            this.label2.Text = "Al: ";
            // 
            // dateHasta
            // 
            this.dateHasta.CustomFormat = "dd/MM/yyyy";
            this.dateHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateHasta.Location = new System.Drawing.Point(192, 28);
            this.dateHasta.Name = "dateHasta";
            this.dateHasta.Size = new System.Drawing.Size(96, 20);
            this.dateHasta.TabIndex = 71;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(41, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 70;
            this.label1.Text = "Del: ";
            // 
            // dateDesde
            // 
            this.dateDesde.CustomFormat = "dd/MM/yyyy";
            this.dateDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDesde.Location = new System.Drawing.Point(69, 28);
            this.dateDesde.Name = "dateDesde";
            this.dateDesde.Size = new System.Drawing.Size(96, 20);
            this.dateDesde.TabIndex = 69;
            this.dateDesde.ValueChanged += new System.EventHandler(this.dateDesde_ValueChanged_1);
            // 
            // cboSucursal
            // 
            this.cboSucursal.FormattingEnabled = true;
            this.cboSucursal.Location = new System.Drawing.Point(69, 5);
            this.cboSucursal.Name = "cboSucursal";
            this.cboSucursal.Size = new System.Drawing.Size(239, 21);
            this.cboSucursal.TabIndex = 67;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.ForeColor = System.Drawing.Color.White;
            this.Label7.Location = new System.Drawing.Point(17, 13);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(51, 13);
            this.Label7.TabIndex = 68;
            this.Label7.Text = "Sucursal:";
            // 
            // mallaDetalle
            // 
            this.mallaDetalle.AllowUserToAddRows = false;
            this.mallaDetalle.AllowUserToDeleteRows = false;
            this.mallaDetalle.AllowUserToResizeRows = false;
            this.mallaDetalle.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mallaDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.mallaDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mallaDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mallaDetalle.EnableHeadersVisualStyles = false;
            this.mallaDetalle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mallaDetalle.Location = new System.Drawing.Point(0, 61);
            this.mallaDetalle.Name = "mallaDetalle";
            this.mallaDetalle.ReadOnly = true;
            this.mallaDetalle.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mallaDetalle.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.mallaDetalle.RowHeadersWidth = 20;
            this.mallaDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mallaDetalle.Size = new System.Drawing.Size(659, 418);
            this.mallaDetalle.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.txtNomTransportadora);
            this.panel2.Controls.Add(this.txtcedulaTransportista);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.txtConsignarNom);
            this.panel2.Controls.Add(this.txtConsigarCod);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(659, 61);
            this.panel2.TabIndex = 11;
            // 
            // txtNomTransportadora
            // 
            this.txtNomTransportadora.BackColor = System.Drawing.Color.White;
            this.txtNomTransportadora.Location = new System.Drawing.Point(199, 30);
            this.txtNomTransportadora.Name = "txtNomTransportadora";
            this.txtNomTransportadora.Size = new System.Drawing.Size(319, 20);
            this.txtNomTransportadora.TabIndex = 50;
            // 
            // txtcedulaTransportista
            // 
            this.txtcedulaTransportista.BackColor = System.Drawing.Color.White;
            this.txtcedulaTransportista.Location = new System.Drawing.Point(93, 30);
            this.txtcedulaTransportista.Name = "txtcedulaTransportista";
            this.txtcedulaTransportista.Size = new System.Drawing.Size(104, 20);
            this.txtcedulaTransportista.TabIndex = 49;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(8, 34);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 13);
            this.label13.TabIndex = 48;
            this.label13.Text = "Transportadora:";
            // 
            // txtConsignarNom
            // 
            this.txtConsignarNom.BackColor = System.Drawing.Color.White;
            this.txtConsignarNom.Location = new System.Drawing.Point(199, 6);
            this.txtConsignarNom.Name = "txtConsignarNom";
            this.txtConsignarNom.Size = new System.Drawing.Size(293, 20);
            this.txtConsignarNom.TabIndex = 37;
            // 
            // txtConsigarCod
            // 
            this.txtConsigarCod.BackColor = System.Drawing.Color.White;
            this.txtConsigarCod.Location = new System.Drawing.Point(91, 6);
            this.txtConsigarCod.Name = "txtConsigarCod";
            this.txtConsigarCod.Size = new System.Drawing.Size(106, 20);
            this.txtConsigarCod.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(13, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Consignar a:";
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.TableLayoutPanel1.ColumnCount = 1;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.35294F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.64706F));
            this.TableLayoutPanel1.Controls.Add(this.ToolStripContainer4, 0, 0);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(994, 67);
            this.TableLayoutPanel1.TabIndex = 7;
            // 
            // ToolStripContainer4
            // 
            this.ToolStripContainer4.BottomToolStripPanelVisible = false;
            // 
            // ToolStripContainer4.ContentPanel
            // 
            this.ToolStripContainer4.ContentPanel.BackColor = System.Drawing.Color.SteelBlue;
            this.ToolStripContainer4.ContentPanel.Controls.Add(this.ToolStrip12);
            this.ToolStripContainer4.ContentPanel.Controls.Add(this.ToolStrip10);
            this.ToolStripContainer4.ContentPanel.Controls.Add(this.ToolStrip7);
            this.ToolStripContainer4.ContentPanel.Controls.Add(this.ToolStrip4);
            this.ToolStripContainer4.ContentPanel.Controls.Add(this.ToolStrip3);
            this.ToolStripContainer4.ContentPanel.Controls.Add(this.toolStrip1);
            this.ToolStripContainer4.ContentPanel.Size = new System.Drawing.Size(988, 61);
            this.ToolStripContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStripContainer4.LeftToolStripPanelVisible = false;
            this.ToolStripContainer4.Location = new System.Drawing.Point(3, 3);
            this.ToolStripContainer4.Name = "ToolStripContainer4";
            this.ToolStripContainer4.RightToolStripPanelVisible = false;
            this.ToolStripContainer4.Size = new System.Drawing.Size(988, 61);
            this.ToolStripContainer4.TabIndex = 4;
            this.ToolStripContainer4.Text = "ToolStripContainer4";
            // 
            // ToolStripContainer4.TopToolStripPanel
            // 
            this.ToolStripContainer4.TopToolStripPanel.Padding = new System.Windows.Forms.Padding(0, 0, 25, 25);
            this.ToolStripContainer4.TopToolStripPanelVisible = false;
            // 
            // ToolStrip12
            // 
            this.ToolStrip12.AutoSize = false;
            this.ToolStrip12.BackColor = System.Drawing.Color.Transparent;
            this.ToolStrip12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStrip12.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip12.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.ToolStrip12.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripSeparator7,
            this.btnSalir});
            this.ToolStrip12.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ToolStrip12.Location = new System.Drawing.Point(581, 0);
            this.ToolStrip12.Name = "ToolStrip12";
            this.ToolStrip12.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStrip12.Size = new System.Drawing.Size(407, 61);
            this.ToolStrip12.Stretch = true;
            this.ToolStrip12.TabIndex = 4;
            this.ToolStrip12.Text = "ToolStrip12";
            // 
            // ToolStripSeparator7
            // 
            this.ToolStripSeparator7.Name = "ToolStripSeparator7";
            this.ToolStripSeparator7.Size = new System.Drawing.Size(6, 61);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(68, 58);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // ToolStrip10
            // 
            this.ToolStrip10.AutoSize = false;
            this.ToolStrip10.BackColor = System.Drawing.Color.Transparent;
            this.ToolStrip10.CanOverflow = false;
            this.ToolStrip10.Dock = System.Windows.Forms.DockStyle.Left;
            this.ToolStrip10.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip10.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ToolStrip10.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBarras,
            this.btnAgrupa});
            this.ToolStrip10.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.ToolStrip10.Location = new System.Drawing.Point(507, 0);
            this.ToolStrip10.Name = "ToolStrip10";
            this.ToolStrip10.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStrip10.Size = new System.Drawing.Size(74, 61);
            this.ToolStrip10.Stretch = true;
            this.ToolStrip10.TabIndex = 3;
            this.ToolStrip10.Text = "ToolStrip10";
            // 
            // btnBarras
            // 
            this.btnBarras.CheckOnClick = true;
            this.btnBarras.ForeColor = System.Drawing.Color.White;
            this.btnBarras.Image = ((System.Drawing.Image)(resources.GetObject("btnBarras.Image")));
            this.btnBarras.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBarras.Name = "btnBarras";
            this.btnBarras.Size = new System.Drawing.Size(63, 24);
            this.btnBarras.Text = "Barras";
            this.btnBarras.ToolTipText = "Habilitar ingreso de codigos con lector de barras";
            // 
            // btnAgrupa
            // 
            this.btnAgrupa.Enabled = false;
            this.btnAgrupa.ForeColor = System.Drawing.Color.White;
            this.btnAgrupa.Image = ((System.Drawing.Image)(resources.GetObject("btnAgrupa.Image")));
            this.btnAgrupa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgrupa.Name = "btnAgrupa";
            this.btnAgrupa.Size = new System.Drawing.Size(70, 24);
            this.btnAgrupa.Text = "Agrupa";
            this.btnAgrupa.ToolTipText = "Agrupar varios artículos iguales delismo precio en uno solo";
            // 
            // ToolStrip7
            // 
            this.ToolStrip7.AutoSize = false;
            this.ToolStrip7.BackColor = System.Drawing.Color.Transparent;
            this.ToolStrip7.Dock = System.Windows.Forms.DockStyle.Left;
            this.ToolStrip7.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip7.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ToolStrip7.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripSeparator2});
            this.ToolStrip7.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ToolStrip7.Location = new System.Drawing.Point(497, 0);
            this.ToolStrip7.Name = "ToolStrip7";
            this.ToolStrip7.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStrip7.Size = new System.Drawing.Size(10, 61);
            this.ToolStrip7.Stretch = true;
            this.ToolStrip7.TabIndex = 4;
            this.ToolStrip7.Text = "ToolStrip7";
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 61);
            // 
            // ToolStrip4
            // 
            this.ToolStrip4.BackColor = System.Drawing.Color.Transparent;
            this.ToolStrip4.Dock = System.Windows.Forms.DockStyle.Left;
            this.ToolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip4.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ToolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator4,
            this.btnDespacho,
            this.btnRevisar,
            this.btnFacturaDirecta,
            this.toolStripSeparator3,
            this.btnImprimir,
            this.toolStripButton1});
            this.ToolStrip4.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ToolStrip4.Location = new System.Drawing.Point(159, 0);
            this.ToolStrip4.Name = "ToolStrip4";
            this.ToolStrip4.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStrip4.Size = new System.Drawing.Size(338, 61);
            this.ToolStrip4.Stretch = true;
            this.ToolStrip4.TabIndex = 2;
            this.ToolStrip4.Text = "ToolStrip4";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 61);
            // 
            // btnDespacho
            // 
            this.btnDespacho.ForeColor = System.Drawing.Color.White;
            this.btnDespacho.Image = ((System.Drawing.Image)(resources.GetObject("btnDespacho.Image")));
            this.btnDespacho.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDespacho.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDespacho.Name = "btnDespacho";
            this.btnDespacho.Size = new System.Drawing.Size(44, 58);
            this.btnDespacho.Text = "Activa";
            this.btnDespacho.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDespacho.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDespacho.ToolTipText = "Convierte un pedido períodico en corriente";
            // 
            // btnRevisar
            // 
            this.btnRevisar.ForeColor = System.Drawing.Color.White;
            this.btnRevisar.Image = ((System.Drawing.Image)(resources.GetObject("btnRevisar.Image")));
            this.btnRevisar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRevisar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRevisar.Name = "btnRevisar";
            this.btnRevisar.Size = new System.Drawing.Size(62, 58);
            this.btnRevisar.Text = "RevisaFac";
            this.btnRevisar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRevisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRevisar.ToolTipText = "Genera la factura y permite revisión";
            // 
            // btnFacturaDirecta
            // 
            this.btnFacturaDirecta.ForeColor = System.Drawing.Color.White;
            this.btnFacturaDirecta.Image = ((System.Drawing.Image)(resources.GetObject("btnFacturaDirecta.Image")));
            this.btnFacturaDirecta.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFacturaDirecta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFacturaDirecta.Name = "btnFacturaDirecta";
            this.btnFacturaDirecta.Size = new System.Drawing.Size(65, 58);
            this.btnFacturaDirecta.Text = "FacturaDir";
            this.btnFacturaDirecta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFacturaDirecta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFacturaDirecta.ToolTipText = "Generar las factura seleccionadas directamente";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 61);
            // 
            // btnImprimir
            // 
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(69, 58);
            this.btnImprimir.Text = "ImpPedido";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnImprimir.ToolTipText = "Imprimir pedido seleccionado";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.ForeColor = System.Drawing.Color.White;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(83, 58);
            this.toolStripButton1.Text = "FacComercial";
            this.toolStripButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.ToolTipText = "Imprimir pedido seleccionado";
            // 
            // ToolStrip3
            // 
            this.ToolStrip3.AutoSize = false;
            this.ToolStrip3.BackColor = System.Drawing.Color.Transparent;
            this.ToolStrip3.CanOverflow = false;
            this.ToolStrip3.Dock = System.Windows.Forms.DockStyle.Left;
            this.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ToolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAbre,
            this.btnElimina});
            this.ToolStrip3.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.ToolStrip3.Location = new System.Drawing.Point(66, 0);
            this.ToolStrip3.Name = "ToolStrip3";
            this.ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStrip3.Size = new System.Drawing.Size(93, 61);
            this.ToolStrip3.TabIndex = 1;
            this.ToolStrip3.Text = "ToolStrip3";
            // 
            // btnAbre
            // 
            this.btnAbre.ForeColor = System.Drawing.Color.White;
            this.btnAbre.Image = ((System.Drawing.Image)(resources.GetObject("btnAbre.Image")));
            this.btnAbre.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbre.Name = "btnAbre";
            this.btnAbre.Size = new System.Drawing.Size(62, 24);
            this.btnAbre.Text = "Abre  ";
            this.btnAbre.ToolTipText = "Abrir un documento existente";
            // 
            // btnElimina
            // 
            this.btnElimina.ForeColor = System.Drawing.Color.White;
            this.btnElimina.Image = ((System.Drawing.Image)(resources.GetObject("btnElimina.Image")));
            this.btnElimina.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnElimina.Name = "btnElimina";
            this.btnElimina.Size = new System.Drawing.Size(70, 24);
            this.btnElimina.Text = "Elimina";
            this.btnElimina.ToolTipText = "Eliminar completamente un documento";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.toolStripSeparator1});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(66, 61);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNuevo
            // 
            this.btnNuevo.CheckOnClick = true;
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(46, 58);
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNuevo.ToolTipText = "Crear un nuevo Pedido";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 61);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.Panel1.Controls.Add(this.TableLayoutPanel1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.ForeColor = System.Drawing.Color.White;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(994, 67);
            this.Panel1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 546);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.Panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "COORDINACION DESPACHO DE PEDIDOS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mallaPedidos)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mallaDetalle)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.TableLayoutPanel1.ResumeLayout(false);
            this.ToolStripContainer4.ContentPanel.ResumeLayout(false);
            this.ToolStripContainer4.ContentPanel.PerformLayout();
            this.ToolStripContainer4.ResumeLayout(false);
            this.ToolStripContainer4.PerformLayout();
            this.ToolStrip12.ResumeLayout(false);
            this.ToolStrip12.PerformLayout();
            this.ToolStrip10.ResumeLayout(false);
            this.ToolStrip10.PerformLayout();
            this.ToolStrip7.ResumeLayout(false);
            this.ToolStrip7.PerformLayout();
            this.ToolStrip4.ResumeLayout(false);
            this.ToolStrip4.PerformLayout();
            this.ToolStrip3.ResumeLayout(false);
            this.ToolStrip3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        internal System.Windows.Forms.DataGridView mallaPedidos;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.DataGridView mallaDetalle;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateHasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateDesde;
        internal System.Windows.Forms.ComboBox cboSucursal;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.TextBox txtConsignarNom;
        private System.Windows.Forms.TextBox txtConsigarCod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNomTransportadora;
        private System.Windows.Forms.TextBox txtcedulaTransportista;
        private System.Windows.Forms.Label label13;
        internal System.Windows.Forms.ToolStripContainer ToolStripContainer4;
        internal System.Windows.Forms.ToolStrip ToolStrip12;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator7;
        internal System.Windows.Forms.ToolStripButton btnSalir;
        internal System.Windows.Forms.ToolStrip ToolStrip10;
        internal System.Windows.Forms.ToolStripButton btnBarras;
        internal System.Windows.Forms.ToolStripButton btnAgrupa;
        internal System.Windows.Forms.ToolStrip ToolStrip7;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        internal System.Windows.Forms.ToolStrip ToolStrip4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        internal System.Windows.Forms.ToolStripButton btnRevisar;
        private System.Windows.Forms.ToolStripButton btnImprimir;
        internal System.Windows.Forms.ToolStrip ToolStrip3;
        internal System.Windows.Forms.ToolStripButton btnAbre;
        internal System.Windows.Forms.ToolStripButton btnElimina;
        internal System.Windows.Forms.ToolStrip toolStrip1;
        internal System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton btnDespacho;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.ToolStripButton btnFacturaDirecta;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

