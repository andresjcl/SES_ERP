namespace analisisIndCart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbMovimientos = new System.Windows.Forms.RadioButton();
            this.rbSaldos = new System.Windows.Forms.RadioButton();
            this.textNroLote = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCodigoEmpleado = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.verGarantias = new System.Windows.Forms.CheckBox();
            this.verPostfechados = new System.Windows.Forms.CheckBox();
            this.verAnticipos = new System.Windows.Forms.CheckBox();
            this.cmbTipoDocumentos = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.mallaDatos = new System.Windows.Forms.DataGridView();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnProcesar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.label5 = new System.Windows.Forms.Label();
            this.ImprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEnviar = new System.Windows.Forms.ToolStripSplitButton();
            this.WordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDetalle = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtFinal = new System.Windows.Forms.DateTimePicker();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAplicaciones = new System.Windows.Forms.ToolStripButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.labSaldo = new System.Windows.Forms.Label();
            this.labAbonos = new System.Windows.Forms.Label();
            this.labContado = new System.Windows.Forms.Label();
            this.labValor = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mallaDatos)).BeginInit();
            this.panel1.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(598, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 87;
            this.label7.Text = "Nro.LoteDoc.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSaldos);
            this.groupBox1.Controls.Add(this.rbMovimientos);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(3, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(155, 74);
            this.groupBox1.TabIndex = 89;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Analisis de:";
            // 
            // rbMovimientos
            // 
            this.rbMovimientos.AutoSize = true;
            this.rbMovimientos.Location = new System.Drawing.Point(9, 45);
            this.rbMovimientos.Name = "rbMovimientos";
            this.rbMovimientos.Size = new System.Drawing.Size(139, 17);
            this.rbMovimientos.TabIndex = 1;
            this.rbMovimientos.Text = "Movimientos del periodo\r\n";
            this.rbMovimientos.UseVisualStyleBackColor = true;
            this.rbMovimientos.CheckedChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // rbSaldos
            // 
            this.rbSaldos.AutoSize = true;
            this.rbSaldos.Checked = true;
            this.rbSaldos.Location = new System.Drawing.Point(9, 24);
            this.rbSaldos.Name = "rbSaldos";
            this.rbSaldos.Size = new System.Drawing.Size(107, 17);
            this.rbSaldos.TabIndex = 0;
            this.rbSaldos.TabStop = true;
            this.rbSaldos.Text = "Saldos a la fecha";
            this.rbSaldos.UseVisualStyleBackColor = true;
            this.rbSaldos.CheckedChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // textNroLote
            // 
            this.textNroLote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textNroLote.Location = new System.Drawing.Point(677, 7);
            this.textNroLote.Name = "textNroLote";
            this.textNroLote.Size = new System.Drawing.Size(109, 20);
            this.textNroLote.TabIndex = 86;
            this.textNroLote.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.textNroLote);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnCodigoEmpleado);
            this.panel2.Controls.Add(this.txtCodigo);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(163, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(798, 35);
            this.panel2.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 85;
            this.label3.Text = "Codigo:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(199, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(469, 17);
            this.label2.TabIndex = 82;
            // 
            // btnCodigoEmpleado
            // 
            this.btnCodigoEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCodigoEmpleado.Location = new System.Drawing.Point(179, 7);
            this.btnCodigoEmpleado.Name = "btnCodigoEmpleado";
            this.btnCodigoEmpleado.Size = new System.Drawing.Size(20, 22);
            this.btnCodigoEmpleado.TabIndex = 84;
            this.btnCodigoEmpleado.Text = "..";
            this.btnCodigoEmpleado.UseVisualStyleBackColor = true;
            this.btnCodigoEmpleado.Click += new System.EventHandler(this.btnCodigoEmpleado_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(71, 7);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(109, 20);
            this.txtCodigo.TabIndex = 83;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-194, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 80;
            this.label4.Text = "Código Empleado:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 88;
            this.label6.Text = "A la fecha:";
            // 
            // ExcelToolStripMenuItem
            // 
            this.ExcelToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ExcelToolStripMenuItem.Image")));
            this.ExcelToolStripMenuItem.Name = "ExcelToolStripMenuItem";
            this.ExcelToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.ExcelToolStripMenuItem.Text = "Excel";
            this.ExcelToolStripMenuItem.Click += new System.EventHandler(this.ExcelToolStripMenuItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.verGarantias);
            this.groupBox3.Controls.Add(this.verPostfechados);
            this.groupBox3.Controls.Add(this.verAnticipos);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(4, 174);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(154, 104);
            this.groupBox3.TabIndex = 91;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Incluir :";
            // 
            // verGarantias
            // 
            this.verGarantias.AutoSize = true;
            this.verGarantias.Location = new System.Drawing.Point(13, 44);
            this.verGarantias.Name = "verGarantias";
            this.verGarantias.Size = new System.Drawing.Size(128, 17);
            this.verGarantias.TabIndex = 5;
            this.verGarantias.Text = "Garantías de Clientes";
            this.verGarantias.UseVisualStyleBackColor = true;
            this.verGarantias.CheckedChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // verPostfechados
            // 
            this.verPostfechados.AutoSize = true;
            this.verPostfechados.Location = new System.Drawing.Point(13, 67);
            this.verPostfechados.Name = "verPostfechados";
            this.verPostfechados.Size = new System.Drawing.Size(128, 17);
            this.verPostfechados.TabIndex = 4;
            this.verPostfechados.Text = "Doc. a fecha Clientes";
            this.verPostfechados.UseVisualStyleBackColor = true;
            this.verPostfechados.CheckedChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // verAnticipos
            // 
            this.verAnticipos.AutoSize = true;
            this.verAnticipos.Location = new System.Drawing.Point(13, 22);
            this.verAnticipos.Name = "verAnticipos";
            this.verAnticipos.Size = new System.Drawing.Size(69, 17);
            this.verAnticipos.TabIndex = 3;
            this.verAnticipos.Text = "Anticipos";
            this.verAnticipos.UseVisualStyleBackColor = true;
            this.verAnticipos.CheckedChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // cmbTipoDocumentos
            // 
            this.cmbTipoDocumentos.AutoSize = false;
            this.cmbTipoDocumentos.DropDownWidth = 250;
            this.cmbTipoDocumentos.Name = "cmbTipoDocumentos";
            this.cmbTipoDocumentos.Size = new System.Drawing.Size(230, 23);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.AutoSize = false;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(50, 36);
            // 
            // mallaDatos
            // 
            this.mallaDatos.AllowUserToAddRows = false;
            this.mallaDatos.AllowUserToDeleteRows = false;
            this.mallaDatos.AllowUserToOrderColumns = true;
            this.mallaDatos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mallaDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.mallaDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.mallaDatos.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mallaDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.mallaDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mallaDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mallaDatos.EnableHeadersVisualStyles = false;
            this.mallaDatos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mallaDatos.Location = new System.Drawing.Point(163, 74);
            this.mallaDatos.Name = "mallaDatos";
            this.mallaDatos.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mallaDatos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.mallaDatos.Size = new System.Drawing.Size(798, 400);
            this.mallaDatos.TabIndex = 16;
            this.mallaDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mallaDatos_CellContentClick);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.AutoSize = false;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(50, 36);
            // 
            // btnProcesar
            // 
            this.btnProcesar.ForeColor = System.Drawing.Color.White;
            this.btnProcesar.Image = ((System.Drawing.Image)(resources.GetObject("btnProcesar.Image")));
            this.btnProcesar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(95, 36);
            this.btnProcesar.Text = "Actualizar";
            this.btnProcesar.ToolTipText = "Calcular los costos de órdenes de producción";
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 86;
            this.label5.Text = "Desde:";
            // 
            // ImprimirToolStripMenuItem
            // 
            this.ImprimirToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ImprimirToolStripMenuItem.Image")));
            this.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem";
            this.ImprimirToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.ImprimirToolStripMenuItem.Text = "Imprimir";
            this.ImprimirToolStripMenuItem.Click += new System.EventHandler(this.ImprimirToolStripMenuItem_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImprimirToolStripMenuItem,
            this.WordToolStripMenuItem,
            this.ExcelToolStripMenuItem,
            this.PDFToolStripMenuItem});
            this.btnEnviar.ForeColor = System.Drawing.Color.White;
            this.btnEnviar.Image = ((System.Drawing.Image)(resources.GetObject("btnEnviar.Image")));
            this.btnEnviar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(87, 36);
            this.btnEnviar.Text = "Enviar";
            // 
            // WordToolStripMenuItem
            // 
            this.WordToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("WordToolStripMenuItem.Image")));
            this.WordToolStripMenuItem.Name = "WordToolStripMenuItem";
            this.WordToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.WordToolStripMenuItem.Text = "Word";
            this.WordToolStripMenuItem.Click += new System.EventHandler(this.WordToolStripMenuItem_Click);
            // 
            // PDFToolStripMenuItem
            // 
            this.PDFToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("PDFToolStripMenuItem.Image")));
            this.PDFToolStripMenuItem.Name = "PDFToolStripMenuItem";
            this.PDFToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.PDFToolStripMenuItem.Text = "PDF";
            this.PDFToolStripMenuItem.Click += new System.EventHandler(this.PDFToolStripMenuItem_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // btnDetalle
            // 
            this.btnDetalle.ForeColor = System.Drawing.Color.White;
            this.btnDetalle.Image = ((System.Drawing.Image)(resources.GetObject("btnDetalle.Image")));
            this.btnDetalle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(79, 36);
            this.btnDetalle.Text = "Detalle";
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dtFinal);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dtInicio);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(163, 459);
            this.panel1.TabIndex = 14;
            // 
            // dtFinal
            // 
            this.dtFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFinal.Location = new System.Drawing.Point(66, 38);
            this.dtFinal.Name = "dtFinal";
            this.dtFinal.Size = new System.Drawing.Size(83, 20);
            this.dtFinal.TabIndex = 87;
            this.dtFinal.ValueChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // dtInicio
            // 
            this.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInicio.Location = new System.Drawing.Point(66, 15);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(83, 20);
            this.dtInicio.TabIndex = 81;
            this.dtInicio.ValueChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-194, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 80;
            this.label1.Text = "Código Empleado:";
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.cmbTipoDocumentos,
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.btnProcesar,
            this.btnDetalle,
            this.btnAplicaciones,
            this.ToolStripSeparator1,
            this.btnEnviar,
            this.btnSalir});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(961, 39);
            this.ToolStrip1.TabIndex = 15;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // btnAplicaciones
            // 
            this.btnAplicaciones.ForeColor = System.Drawing.Color.White;
            this.btnAplicaciones.Image = ((System.Drawing.Image)(resources.GetObject("btnAplicaciones.Image")));
            this.btnAplicaciones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAplicaciones.Name = "btnAplicaciones";
            this.btnAplicaciones.Size = new System.Drawing.Size(110, 36);
            this.btnAplicaciones.Text = "Aplicaciones";
            this.btnAplicaciones.Click += new System.EventHandler(this.btnAplicaciones_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.labSaldo);
            this.panel3.Controls.Add(this.labAbonos);
            this.panel3.Controls.Add(this.labContado);
            this.panel3.Controls.Add(this.labValor);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(163, 474);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(798, 24);
            this.panel3.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(267, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 85;
            this.label8.Text = "TOTALES:";
            // 
            // labSaldo
            // 
            this.labSaldo.BackColor = System.Drawing.Color.White;
            this.labSaldo.Location = new System.Drawing.Point(672, 2);
            this.labSaldo.Name = "labSaldo";
            this.labSaldo.Size = new System.Drawing.Size(77, 20);
            this.labSaldo.TabIndex = 84;
            this.labSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labAbonos
            // 
            this.labAbonos.BackColor = System.Drawing.Color.White;
            this.labAbonos.Location = new System.Drawing.Point(566, 2);
            this.labAbonos.Name = "labAbonos";
            this.labAbonos.Size = new System.Drawing.Size(77, 20);
            this.labAbonos.TabIndex = 83;
            this.labAbonos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labContado
            // 
            this.labContado.BackColor = System.Drawing.Color.White;
            this.labContado.Location = new System.Drawing.Point(463, 2);
            this.labContado.Name = "labContado";
            this.labContado.Size = new System.Drawing.Size(77, 20);
            this.labContado.TabIndex = 82;
            this.labContado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labValor
            // 
            this.labValor.BackColor = System.Drawing.Color.White;
            this.labValor.Location = new System.Drawing.Point(357, 2);
            this.labValor.Name = "labValor";
            this.labValor.Size = new System.Drawing.Size(77, 20);
            this.labValor.TabIndex = 81;
            this.labValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(-194, 163);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 13);
            this.label11.TabIndex = 80;
            this.label11.Text = "Código Empleado:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 498);
            this.Controls.Add(this.mallaDatos);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ToolStrip1);
            this.Name = "Form1";
            this.Text = "ANALISIS INDIVIDUAL DE CARTERA";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mallaDatos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbMovimientos;
        private System.Windows.Forms.RadioButton rbSaldos;
        private System.Windows.Forms.TextBox textNroLote;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Button btnCodigoEmpleado;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ToolStripMenuItem ExcelToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStripComboBox cmbTipoDocumentos;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.DataGridView mallaDatos;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        internal System.Windows.Forms.ToolStripButton btnProcesar;
        internal System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ToolStripMenuItem ImprimirToolStripMenuItem;
        internal System.Windows.Forms.ToolStripSplitButton btnEnviar;
        internal System.Windows.Forms.ToolStripMenuItem WordToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem PDFToolStripMenuItem;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnDetalle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtFinal;
        private System.Windows.Forms.DateTimePicker dtInicio;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        private System.Windows.Forms.CheckBox verAnticipos;
        private System.Windows.Forms.CheckBox verGarantias;
        private System.Windows.Forms.CheckBox verPostfechados;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labSaldo;
        private System.Windows.Forms.Label labAbonos;
        private System.Windows.Forms.Label labContado;
        private System.Windows.Forms.Label labValor;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripButton btnAplicaciones;
    }
}

