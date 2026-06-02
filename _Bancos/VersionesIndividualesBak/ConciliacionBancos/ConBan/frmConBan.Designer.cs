namespace DaxBan
{
    partial class frmConBan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConBan));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.BtnOpciones = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.abrir = new System.Windows.Forms.ToolStripButton();
            this.guardar = new System.Windows.Forms.ToolStripButton();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.Imprimir = new System.Windows.Forms.ToolStripButton();
            this.btnExportar = new System.Windows.Forms.ToolStripSplitButton();
            this.btnexcel = new System.Windows.Forms.ToolStripMenuItem();
            this.btnpdf = new System.Windows.Forms.ToolStripMenuItem();
            this.btnword = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFechaIni = new System.Windows.Forms.ToolStripButton();
            this.btnFechaFin = new System.Windows.Forms.ToolStripButton();
            this.btnFechaEmi = new System.Windows.Forms.ToolStripButton();
            this.btnBorrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnConciliacion = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.totales = new System.Windows.Forms.DataGridView();
            this.textSaldo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkNoregConcilia = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.checkNoReg = new System.Windows.Forms.RadioButton();
            this.checkRegBanco = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBanco = new System.Windows.Forms.ComboBox();
            this.comboCuentaBanco = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFechaHasta = new System.Windows.Forms.MaskedTextBox();
            this.labelHastaFecha = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFechaDesde = new System.Windows.Forms.MaskedTextBox();
            this.labelDesdeFecha = new System.Windows.Forms.Label();
            this.malla = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.totales)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.malla)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.AutoSize = false;
            this.menu.BackColor = System.Drawing.Color.SteelBlue;
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnOpciones,
            this.toolStripSeparator3,
            this.abrir,
            this.guardar,
            this.btnCancelar,
            this.Imprimir,
            this.btnExportar,
            this.toolStripSeparator1,
            this.btnFechaIni,
            this.btnFechaFin,
            this.btnFechaEmi,
            this.btnBorrar,
            this.toolStripSeparator2,
            this.btnBuscar,
            this.toolStripSeparator4,
            this.btnConciliacion,
            this.toolStripButton1});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(865, 45);
            this.menu.TabIndex = 0;
            this.menu.Text = "toolStrip1";
            // 
            // BtnOpciones
            // 
            this.BtnOpciones.Image = ((System.Drawing.Image)(resources.GetObject("BtnOpciones.Image")));
            this.BtnOpciones.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnOpciones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnOpciones.Name = "BtnOpciones";
            this.BtnOpciones.Size = new System.Drawing.Size(61, 42);
            this.BtnOpciones.Text = "Opciones";
            this.BtnOpciones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnOpciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnOpciones.ToolTipText = "Opciones para visualizacion de documentos";
            this.BtnOpciones.Click += new System.EventHandler(this.BtnOpciones_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 45);
            // 
            // abrir
            // 
            this.abrir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.abrir.Image = ((System.Drawing.Image)(resources.GetObject("abrir.Image")));
            this.abrir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.abrir.Name = "abrir";
            this.abrir.Size = new System.Drawing.Size(37, 42);
            this.abrir.Text = "Abrir";
            this.abrir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.abrir.Click += new System.EventHandler(this.abrir_Click);
            // 
            // guardar
            // 
            this.guardar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.guardar.Image = ((System.Drawing.Image)(resources.GetObject("guardar.Image")));
            this.guardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(53, 42);
            this.guardar.Text = "Guardar";
            this.guardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(57, 42);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.Click += new System.EventHandler(this.toolCancelar_Click);
            // 
            // Imprimir
            // 
            this.Imprimir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Imprimir.Image = ((System.Drawing.Image)(resources.GetObject("Imprimir.Image")));
            this.Imprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Imprimir.Name = "Imprimir";
            this.Imprimir.Size = new System.Drawing.Size(57, 42);
            this.Imprimir.Text = "Imprimir";
            this.Imprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Imprimir.ToolTipText = "Enviar a la impresora";
            this.Imprimir.Click += new System.EventHandler(this.imprimir_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnexcel,
            this.btnpdf,
            this.btnword});
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.Image")));
            this.btnExportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(66, 42);
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnexcel
            // 
            this.btnexcel.Image = ((System.Drawing.Image)(resources.GetObject("btnexcel.Image")));
            this.btnexcel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnexcel.Name = "btnexcel";
            this.btnexcel.Size = new System.Drawing.Size(158, 22);
            this.btnexcel.Text = "Exportar a Excel";
            this.btnexcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnexcel.Click += new System.EventHandler(this.btnexcel_Click);
            // 
            // btnpdf
            // 
            this.btnpdf.Image = ((System.Drawing.Image)(resources.GetObject("btnpdf.Image")));
            this.btnpdf.Name = "btnpdf";
            this.btnpdf.Size = new System.Drawing.Size(158, 22);
            this.btnpdf.Text = "Exportar a Pdf";
            this.btnpdf.Click += new System.EventHandler(this.btnpdf_Click);
            // 
            // btnword
            // 
            this.btnword.Image = ((System.Drawing.Image)(resources.GetObject("btnword.Image")));
            this.btnword.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnword.Name = "btnword";
            this.btnword.Size = new System.Drawing.Size(158, 22);
            this.btnword.Text = "Exportar a Word";
            this.btnword.Click += new System.EventHandler(this.btnword_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 45);
            // 
            // btnFechaIni
            // 
            this.btnFechaIni.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFechaIni.Image = ((System.Drawing.Image)(resources.GetObject("btnFechaIni.Image")));
            this.btnFechaIni.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFechaIni.Name = "btnFechaIni";
            this.btnFechaIni.Size = new System.Drawing.Size(66, 42);
            this.btnFechaIni.Text = "Fec. Inicial";
            this.btnFechaIni.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFechaIni.ToolTipText = "F2--Registra la fecha inicial";
            this.btnFechaIni.Click += new System.EventHandler(this.btnFechaIni_Click);
            // 
            // btnFechaFin
            // 
            this.btnFechaFin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFechaFin.Image = ((System.Drawing.Image)(resources.GetObject("btnFechaFin.Image")));
            this.btnFechaFin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFechaFin.Name = "btnFechaFin";
            this.btnFechaFin.Size = new System.Drawing.Size(60, 42);
            this.btnFechaFin.Text = "Fec. Final";
            this.btnFechaFin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFechaFin.ToolTipText = "F3--Registra la fecha final";
            this.btnFechaFin.Click += new System.EventHandler(this.btnFechaFin_Click);
            // 
            // btnFechaEmi
            // 
            this.btnFechaEmi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFechaEmi.Image = ((System.Drawing.Image)(resources.GetObject("btnFechaEmi.Image")));
            this.btnFechaEmi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFechaEmi.Name = "btnFechaEmi";
            this.btnFechaEmi.Size = new System.Drawing.Size(77, 42);
            this.btnFechaEmi.Text = "Fec. Emisión";
            this.btnFechaEmi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFechaEmi.ToolTipText = "F4--Registra la fecha del movimiento";
            this.btnFechaEmi.Click += new System.EventHandler(this.btnFechaEmi_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBorrar.Image = ((System.Drawing.Image)(resources.GetObject("btnBorrar.Image")));
            this.btnBorrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(89, 42);
            this.btnBorrar.Text = "Borrar Registro";
            this.btnBorrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 45);
            // 
            // btnConciliacion
            // 
            this.btnConciliacion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnConciliacion.Image = ((System.Drawing.Image)(resources.GetObject("btnConciliacion.Image")));
            this.btnConciliacion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConciliacion.Name = "btnConciliacion";
            this.btnConciliacion.Size = new System.Drawing.Size(57, 42);
            this.btnConciliacion.Text = "Imprimir";
            this.btnConciliacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConciliacion.ToolTipText = "Imprimir el movimiento de la cuenta";
            this.btnConciliacion.Click += new System.EventHandler(this.btnConciliacion_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.ForeColor = System.Drawing.Color.White;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 42);
            this.toolStripButton1.Text = "Salir";
            this.toolStripButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 45);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.splitContainer1.Panel2.Controls.Add(this.malla);
            this.splitContainer1.Size = new System.Drawing.Size(865, 517);
            this.splitContainer1.SplitterDistance = 303;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.totales);
            this.panel1.Controls.Add(this.textSaldo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(303, 517);
            this.panel1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 340);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Totales por documentos";
            // 
            // totales
            // 
            this.totales.AllowUserToAddRows = false;
            this.totales.AllowUserToDeleteRows = false;
            this.totales.AllowUserToResizeColumns = false;
            this.totales.AllowUserToResizeRows = false;
            this.totales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.totales.BackgroundColor = System.Drawing.Color.White;
            this.totales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.totales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.totales.DefaultCellStyle = dataGridViewCellStyle1;
            this.totales.Location = new System.Drawing.Point(12, 356);
            this.totales.Name = "totales";
            this.totales.ReadOnly = true;
            this.totales.RowHeadersVisible = false;
            this.totales.Size = new System.Drawing.Size(249, 145);
            this.totales.TabIndex = 38;
            // 
            // textSaldo
            // 
            this.textSaldo.Location = new System.Drawing.Point(12, 308);
            this.textSaldo.Name = "textSaldo";
            this.textSaldo.Size = new System.Drawing.Size(202, 20);
            this.textSaldo.TabIndex = 36;
            this.textSaldo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textSaldo_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Saldo segun estado de cuenta del banco:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkNoregConcilia);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.checkNoReg);
            this.groupBox1.Controls.Add(this.checkRegBanco);
            this.groupBox1.Location = new System.Drawing.Point(12, 157);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 124);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listar movimientos";
            // 
            // chkNoregConcilia
            // 
            this.chkNoregConcilia.AutoSize = true;
            this.chkNoregConcilia.Location = new System.Drawing.Point(21, 68);
            this.chkNoregConcilia.Name = "chkNoregConcilia";
            this.chkNoregConcilia.Size = new System.Drawing.Size(14, 13);
            this.chkNoregConcilia.TabIndex = 37;
            this.chkNoregConcilia.UseVisualStyleBackColor = true;
            this.chkNoregConcilia.Visible = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(22, 22);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(189, 17);
            this.radioButton1.TabIndex = 36;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Todos los movimientos del período";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // checkNoReg
            // 
            this.checkNoReg.AutoSize = true;
            this.checkNoReg.Location = new System.Drawing.Point(22, 45);
            this.checkNoReg.Name = "checkNoReg";
            this.checkNoReg.Size = new System.Drawing.Size(203, 17);
            this.checkNoReg.TabIndex = 35;
            this.checkNoReg.Text = "Movimientos no registrados a la fecha";
            this.checkNoReg.UseVisualStyleBackColor = true;
            this.checkNoReg.CheckedChanged += new System.EventHandler(this.checkNoReg_CheckedChanged);
            // 
            // checkRegBanco
            // 
            this.checkRegBanco.AutoSize = true;
            this.checkRegBanco.Location = new System.Drawing.Point(21, 68);
            this.checkRegBanco.Name = "checkRegBanco";
            this.checkRegBanco.Size = new System.Drawing.Size(147, 17);
            this.checkRegBanco.TabIndex = 34;
            this.checkRegBanco.Text = "Registrados en el período";
            this.checkRegBanco.UseVisualStyleBackColor = true;
            this.checkRegBanco.CheckedChanged += new System.EventHandler(this.checkRegBanco_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(211, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Opciones para visualizar registros\r\n";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBanco);
            this.groupBox2.Controls.Add(this.comboCuentaBanco);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBoxFechaHasta);
            this.groupBox2.Controls.Add(this.labelHastaFecha);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxFechaDesde);
            this.groupBox2.Controls.Add(this.labelDesdeFecha);
            this.groupBox2.Location = new System.Drawing.Point(12, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(249, 117);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            // 
            // comboBanco
            // 
            this.comboBanco.FormattingEnabled = true;
            this.comboBanco.Location = new System.Drawing.Point(59, 21);
            this.comboBanco.Name = "comboBanco";
            this.comboBanco.Size = new System.Drawing.Size(184, 21);
            this.comboBanco.TabIndex = 2;
            this.comboBanco.SelectedIndexChanged += new System.EventHandler(this.comboBanco_SelectedIndexChanged);
            this.comboBanco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBanco_KeyPress);
            // 
            // comboCuentaBanco
            // 
            this.comboCuentaBanco.FormattingEnabled = true;
            this.comboCuentaBanco.Location = new System.Drawing.Point(65, 48);
            this.comboCuentaBanco.Name = "comboCuentaBanco";
            this.comboCuentaBanco.Size = new System.Drawing.Size(178, 21);
            this.comboCuentaBanco.TabIndex = 3;
            this.comboCuentaBanco.SelectedIndexChanged += new System.EventHandler(this.comboCuentaBanco_SelectedIndexChanged);
            this.comboCuentaBanco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboCuentaBanco_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Banco:";
            // 
            // textBoxFechaHasta
            // 
            this.textBoxFechaHasta.Location = new System.Drawing.Point(166, 79);
            this.textBoxFechaHasta.Mask = "00/00/0000";
            this.textBoxFechaHasta.Name = "textBoxFechaHasta";
            this.textBoxFechaHasta.Size = new System.Drawing.Size(64, 20);
            this.textBoxFechaHasta.TabIndex = 32;
            this.textBoxFechaHasta.ValidatingType = typeof(System.DateTime);
            this.textBoxFechaHasta.TextChanged += new System.EventHandler(this.textBoxFechaHasta_TextChanged);
            // 
            // labelHastaFecha
            // 
            this.labelHastaFecha.AutoSize = true;
            this.labelHastaFecha.BackColor = System.Drawing.Color.LightSteelBlue;
            this.labelHastaFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHastaFecha.Location = new System.Drawing.Point(144, 86);
            this.labelHastaFecha.Name = "labelHastaFecha";
            this.labelHastaFecha.Size = new System.Drawing.Size(18, 13);
            this.labelHastaFecha.TabIndex = 25;
            this.labelHastaFecha.Text = "al ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Cuentas:";
            // 
            // textBoxFechaDesde
            // 
            this.textBoxFechaDesde.Location = new System.Drawing.Point(74, 79);
            this.textBoxFechaDesde.Mask = "00/00/0000";
            this.textBoxFechaDesde.Name = "textBoxFechaDesde";
            this.textBoxFechaDesde.Size = new System.Drawing.Size(64, 20);
            this.textBoxFechaDesde.TabIndex = 31;
            this.textBoxFechaDesde.ValidatingType = typeof(System.DateTime);
            this.textBoxFechaDesde.TextChanged += new System.EventHandler(this.textBoxFechaDesde_TextChanged);
            // 
            // labelDesdeFecha
            // 
            this.labelDesdeFecha.AutoSize = true;
            this.labelDesdeFecha.BackColor = System.Drawing.Color.LightSteelBlue;
            this.labelDesdeFecha.Location = new System.Drawing.Point(10, 86);
            this.labelDesdeFecha.Name = "labelDesdeFecha";
            this.labelDesdeFecha.Size = new System.Drawing.Size(68, 13);
            this.labelDesdeFecha.TabIndex = 26;
            this.labelDesdeFecha.Text = "Período del :";
            // 
            // malla
            // 
            this.malla.AllowUserToAddRows = false;
            this.malla.AllowUserToDeleteRows = false;
            this.malla.BackgroundColor = System.Drawing.Color.White;
            this.malla.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.malla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.malla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.malla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.malla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.malla.EnableHeadersVisualStyles = false;
            this.malla.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.malla.Location = new System.Drawing.Point(0, 0);
            this.malla.Name = "malla";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.malla.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.malla.Size = new System.Drawing.Size(558, 517);
            this.malla.TabIndex = 0;
            this.malla.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.malla.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValidated);
            this.malla.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.malla.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // btnBuscar
            // 
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(36, 42);
            this.btnBuscar.ToolTipText = "Buscar en el registro de movimientos";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 45);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 562);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conciliación Bancaria";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.totales)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.malla)).EndInit();
            this.ResumeLayout(false);

            }

        #endregion

        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton guardar;
        private System.Windows.Forms.ToolStripButton abrir;
        private System.Windows.Forms.ToolStripButton Imprimir;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox comboCuentaBanco;
        private System.Windows.Forms.ComboBox comboBanco;
        private System.Windows.Forms.Label labelDesdeFecha;
        private System.Windows.Forms.Label labelHastaFecha;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripButton btnFechaIni;
        private System.Windows.Forms.ToolStripButton btnFechaFin;
        private System.Windows.Forms.ToolStripButton btnFechaEmi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripButton btnConciliacion;
        internal System.Windows.Forms.MaskedTextBox textBoxFechaHasta;
        internal System.Windows.Forms.MaskedTextBox textBoxFechaDesde;
        private System.Windows.Forms.ToolStripButton btnCancelar;
        private System.Windows.Forms.ToolStripButton btnBorrar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TextBox textSaldo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView malla;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton checkNoReg;
        private System.Windows.Forms.RadioButton checkRegBanco;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton chkNoregConcilia;
        private System.Windows.Forms.ToolStripButton BtnOpciones;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView totales;
        private System.Windows.Forms.ToolStripSplitButton btnExportar;
        private System.Windows.Forms.ToolStripMenuItem btnexcel;
        private System.Windows.Forms.ToolStripMenuItem btnword;
        private System.Windows.Forms.ToolStripMenuItem btnpdf;
        private System.Windows.Forms.ToolStripButton btnBuscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}

