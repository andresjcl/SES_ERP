namespace DaxPagosLote
{
    partial class frmcheLote
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmcheLote));
            this.PanelParametros = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtFechaDocumento = new System.Windows.Forms.DateTimePicker();
            this.cmbBancos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbComceptosEgreso = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDocumento = new System.Windows.Forms.ComboBox();
            this.chkPausaImprime = new System.Windows.Forms.CheckBox();
            this.chkImprimeEgreso = new System.Windows.Forms.CheckBox();
            this.chkImprimeCheque = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbRubrosNomina = new System.Windows.Forms.ComboBox();
            this.cmbPeriodosRol = new System.Windows.Forms.ComboBox();
            this.LablabRubro = new System.Windows.Forms.Label();
            this.labperido = new System.Windows.Forms.Label();
            this.MallaDatos = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ToolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.ToolStrip13 = new System.Windows.Forms.ToolStrip();
            this.ToolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSalir2 = new System.Windows.Forms.ToolStripButton();
            this.ToolStrip18 = new System.Windows.Forms.ToolStrip();
            this.btnMarcarTodo = new System.Windows.Forms.ToolStripButton();
            this.BtnQuitarTodo = new System.Windows.Forms.ToolStripButton();
            this.btnMarcarSeleccion = new System.Windows.Forms.ToolStripButton();
            this.btnQutarSelecccion = new System.Windows.Forms.ToolStripButton();
            this.ToolStrip14 = new System.Windows.Forms.ToolStrip();
            this.ToolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.btnParametros = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAbrir = new System.Windows.Forms.ToolStripButton();
            this.btnCierra = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnProcesar = new System.Windows.Forms.ToolStripButton();
            this.btnEnviar = new System.Windows.Forms.ToolStripSplitButton();
            this.ImprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.PanelParametros.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MallaDatos)).BeginInit();
            this.ToolStripContainer1.ContentPanel.SuspendLayout();
            this.ToolStripContainer1.SuspendLayout();
            this.ToolStrip13.SuspendLayout();
            this.ToolStrip18.SuspendLayout();
            this.ToolStrip14.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelParametros
            // 
            this.PanelParametros.BackColor = System.Drawing.Color.DimGray;
            this.PanelParametros.Controls.Add(this.groupBox2);
            this.PanelParametros.Controls.Add(this.groupBox1);
            this.PanelParametros.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelParametros.Location = new System.Drawing.Point(0, 54);
            this.PanelParametros.Name = "PanelParametros";
            this.PanelParametros.Size = new System.Drawing.Size(284, 502);
            this.PanelParametros.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dtFechaDocumento);
            this.groupBox2.Controls.Add(this.cmbBancos);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbComceptosEgreso);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cmbDocumento);
            this.groupBox2.Controls.Add(this.chkPausaImprime);
            this.groupBox2.Controls.Add(this.chkImprimeEgreso);
            this.groupBox2.Controls.Add(this.chkImprimeCheque);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(9, 144);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(268, 261);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Paramertos para la creación del Egreso";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(31, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Fecha del documento";
            // 
            // dtFechaDocumento
            // 
            this.dtFechaDocumento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaDocumento.Location = new System.Drawing.Point(151, 29);
            this.dtFechaDocumento.Name = "dtFechaDocumento";
            this.dtFechaDocumento.Size = new System.Drawing.Size(89, 20);
            this.dtFechaDocumento.TabIndex = 31;
            // 
            // cmbBancos
            // 
            this.cmbBancos.FormattingEnabled = true;
            this.cmbBancos.Location = new System.Drawing.Point(20, 111);
            this.cmbBancos.Name = "cmbBancos";
            this.cmbBancos.Size = new System.Drawing.Size(231, 21);
            this.cmbBancos.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(20, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Tipo de documento a crear";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(20, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Banco emisor ";
            // 
            // cmbComceptosEgreso
            // 
            this.cmbComceptosEgreso.FormattingEnabled = true;
            this.cmbComceptosEgreso.Location = new System.Drawing.Point(20, 150);
            this.cmbComceptosEgreso.Name = "cmbComceptosEgreso";
            this.cmbComceptosEgreso.Size = new System.Drawing.Size(231, 21);
            this.cmbComceptosEgreso.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(20, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Concepto del egreso";
            // 
            // cmbDocumento
            // 
            this.cmbDocumento.FormattingEnabled = true;
            this.cmbDocumento.Location = new System.Drawing.Point(22, 73);
            this.cmbDocumento.Name = "cmbDocumento";
            this.cmbDocumento.Size = new System.Drawing.Size(229, 21);
            this.cmbDocumento.TabIndex = 27;
            // 
            // chkPausaImprime
            // 
            this.chkPausaImprime.AutoSize = true;
            this.chkPausaImprime.ForeColor = System.Drawing.Color.White;
            this.chkPausaImprime.Location = new System.Drawing.Point(20, 229);
            this.chkPausaImprime.Name = "chkPausaImprime";
            this.chkPausaImprime.Size = new System.Drawing.Size(127, 17);
            this.chkPausaImprime.TabIndex = 26;
            this.chkPausaImprime.Text = "Pausa para impresión";
            this.chkPausaImprime.UseVisualStyleBackColor = true;
            // 
            // chkImprimeEgreso
            // 
            this.chkImprimeEgreso.AutoSize = true;
            this.chkImprimeEgreso.ForeColor = System.Drawing.Color.White;
            this.chkImprimeEgreso.Location = new System.Drawing.Point(22, 183);
            this.chkImprimeEgreso.Name = "chkImprimeEgreso";
            this.chkImprimeEgreso.Size = new System.Drawing.Size(97, 17);
            this.chkImprimeEgreso.TabIndex = 24;
            this.chkImprimeEgreso.Text = "Imprimir Egreso";
            this.chkImprimeEgreso.UseVisualStyleBackColor = true;
            // 
            // chkImprimeCheque
            // 
            this.chkImprimeCheque.AutoSize = true;
            this.chkImprimeCheque.ForeColor = System.Drawing.Color.White;
            this.chkImprimeCheque.Location = new System.Drawing.Point(20, 206);
            this.chkImprimeCheque.Name = "chkImprimeCheque";
            this.chkImprimeCheque.Size = new System.Drawing.Size(100, 17);
            this.chkImprimeCheque.TabIndex = 25;
            this.chkImprimeCheque.Text = "Imprimir cheque";
            this.chkImprimeCheque.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbRubrosNomina);
            this.groupBox1.Controls.Add(this.cmbPeriodosRol);
            this.groupBox1.Controls.Add(this.LablabRubro);
            this.groupBox1.Controls.Add(this.labperido);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 123);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parámetros para establecer el valor";
            // 
            // cmbRubrosNomina
            // 
            this.cmbRubrosNomina.FormattingEnabled = true;
            this.cmbRubrosNomina.Location = new System.Drawing.Point(20, 35);
            this.cmbRubrosNomina.Name = "cmbRubrosNomina";
            this.cmbRubrosNomina.Size = new System.Drawing.Size(231, 21);
            this.cmbRubrosNomina.TabIndex = 24;
            // 
            // cmbPeriodosRol
            // 
            this.cmbPeriodosRol.FormattingEnabled = true;
            this.cmbPeriodosRol.Location = new System.Drawing.Point(20, 79);
            this.cmbPeriodosRol.Name = "cmbPeriodosRol";
            this.cmbPeriodosRol.Size = new System.Drawing.Size(231, 21);
            this.cmbPeriodosRol.TabIndex = 23;
            // 
            // LablabRubro
            // 
            this.LablabRubro.AutoSize = true;
            this.LablabRubro.ForeColor = System.Drawing.Color.White;
            this.LablabRubro.Location = new System.Drawing.Point(19, 22);
            this.LablabRubro.Name = "LablabRubro";
            this.LablabRubro.Size = new System.Drawing.Size(114, 13);
            this.LablabRubro.TabIndex = 26;
            this.LablabRubro.Text = "Rubro del rol de pagos";
            // 
            // labperido
            // 
            this.labperido.AutoSize = true;
            this.labperido.ForeColor = System.Drawing.Color.White;
            this.labperido.Location = new System.Drawing.Point(19, 66);
            this.labperido.Name = "labperido";
            this.labperido.Size = new System.Drawing.Size(76, 13);
            this.labperido.TabIndex = 25;
            this.labperido.Text = "Período del rol";
            // 
            // MallaDatos
            // 
            this.MallaDatos.AllowUserToAddRows = false;
            this.MallaDatos.AllowUserToDeleteRows = false;
            this.MallaDatos.AllowUserToResizeColumns = false;
            this.MallaDatos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MallaDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.MallaDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.MallaDatos.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MallaDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.MallaDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MallaDatos.DefaultCellStyle = dataGridViewCellStyle3;
            this.MallaDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MallaDatos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.MallaDatos.Location = new System.Drawing.Point(284, 54);
            this.MallaDatos.Name = "MallaDatos";
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.MallaDatos.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.MallaDatos.Size = new System.Drawing.Size(709, 502);
            this.MallaDatos.TabIndex = 10;
            // 
            // ToolStripContainer1
            // 
            this.ToolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // ToolStripContainer1.ContentPanel
            // 
            this.ToolStripContainer1.ContentPanel.BackColor = System.Drawing.Color.DimGray;
            this.ToolStripContainer1.ContentPanel.Controls.Add(this.ToolStrip13);
            this.ToolStripContainer1.ContentPanel.Controls.Add(this.ToolStrip18);
            this.ToolStripContainer1.ContentPanel.Controls.Add(this.ToolStrip14);
            this.ToolStripContainer1.ContentPanel.Size = new System.Drawing.Size(993, 54);
            this.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolStripContainer1.LeftToolStripPanelVisible = false;
            this.ToolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.ToolStripContainer1.Name = "ToolStripContainer1";
            this.ToolStripContainer1.RightToolStripPanelVisible = false;
            this.ToolStripContainer1.Size = new System.Drawing.Size(993, 54);
            this.ToolStripContainer1.TabIndex = 12;
            this.ToolStripContainer1.Text = "ToolStripContainer1";
            this.ToolStripContainer1.TopToolStripPanelVisible = false;
            // 
            // ToolStrip13
            // 
            this.ToolStrip13.BackColor = System.Drawing.Color.Transparent;
            this.ToolStrip13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStrip13.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip13.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ToolStrip13.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripSeparator6,
            this.btnSalir2});
            this.ToolStrip13.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ToolStrip13.Location = new System.Drawing.Point(495, 0);
            this.ToolStrip13.Name = "ToolStrip13";
            this.ToolStrip13.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStrip13.Size = new System.Drawing.Size(498, 54);
            this.ToolStrip13.Stretch = true;
            this.ToolStrip13.TabIndex = 20;
            this.ToolStrip13.Text = "ToolStrip13";
            // 
            // ToolStripSeparator6
            // 
            this.ToolStripSeparator6.Name = "ToolStripSeparator6";
            this.ToolStripSeparator6.Size = new System.Drawing.Size(6, 54);
            // 
            // btnSalir2
            // 
            this.btnSalir2.ForeColor = System.Drawing.Color.White;
            this.btnSalir2.Image = global::DaxPagosLote.Properties.Resources.Salir;
            this.btnSalir2.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnSalir2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir2.Name = "btnSalir2";
            this.btnSalir2.Size = new System.Drawing.Size(65, 51);
            this.btnSalir2.Text = "Salir";
            this.btnSalir2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnSalir2.Click += new System.EventHandler(this.btnSalir2_Click);
            // 
            // ToolStrip18
            // 
            this.ToolStrip18.AutoSize = false;
            this.ToolStrip18.BackColor = System.Drawing.Color.Transparent;
            this.ToolStrip18.CanOverflow = false;
            this.ToolStrip18.Dock = System.Windows.Forms.DockStyle.Left;
            this.ToolStrip18.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip18.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMarcarTodo,
            this.BtnQuitarTodo,
            this.btnMarcarSeleccion,
            this.btnQutarSelecccion});
            this.ToolStrip18.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.ToolStrip18.Location = new System.Drawing.Point(260, 0);
            this.ToolStrip18.Name = "ToolStrip18";
            this.ToolStrip18.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStrip18.Size = new System.Drawing.Size(235, 54);
            this.ToolStrip18.Stretch = true;
            this.ToolStrip18.TabIndex = 19;
            this.ToolStrip18.Text = "ToolStrip18";
            // 
            // btnMarcarTodo
            // 
            this.btnMarcarTodo.ForeColor = System.Drawing.Color.White;
            this.btnMarcarTodo.Image = global::DaxPagosLote.Properties.Resources.Visto_Ok;
            this.btnMarcarTodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMarcarTodo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMarcarTodo.Name = "btnMarcarTodo";
            this.btnMarcarTodo.Size = new System.Drawing.Size(92, 20);
            this.btnMarcarTodo.Text = "Marcar todo";
            this.btnMarcarTodo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMarcarTodo.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.btnMarcarTodo.Click += new System.EventHandler(this.btnMarcarTodo_Click);
            // 
            // BtnQuitarTodo
            // 
            this.BtnQuitarTodo.ForeColor = System.Drawing.Color.White;
            this.BtnQuitarTodo.Image = global::DaxPagosLote.Properties.Resources.Visto_Ok_Seleccion;
            this.BtnQuitarTodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnQuitarTodo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnQuitarTodo.Name = "BtnQuitarTodo";
            this.BtnQuitarTodo.Size = new System.Drawing.Size(96, 20);
            this.BtnQuitarTodo.Text = "Quitar Marca";
            this.BtnQuitarTodo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnQuitarTodo.ToolTipText = "Recalcular el valor del concepto por fórmula";
            this.BtnQuitarTodo.Click += new System.EventHandler(this.BtnQuitarTodo_Click);
            // 
            // btnMarcarSeleccion
            // 
            this.btnMarcarSeleccion.ForeColor = System.Drawing.Color.White;
            this.btnMarcarSeleccion.Image = global::DaxPagosLote.Properties.Resources.Visto_Ok;
            this.btnMarcarSeleccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMarcarSeleccion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMarcarSeleccion.Name = "btnMarcarSeleccion";
            this.btnMarcarSeleccion.Size = new System.Drawing.Size(116, 20);
            this.btnMarcarSeleccion.Text = "Marcar selección";
            this.btnMarcarSeleccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMarcarSeleccion.ToolTipText = "Recalcular el valor del concepto por fórmula";
            this.btnMarcarSeleccion.Click += new System.EventHandler(this.btnMarcarSeleccion_Click);
            // 
            // btnQutarSelecccion
            // 
            this.btnQutarSelecccion.ForeColor = System.Drawing.Color.White;
            this.btnQutarSelecccion.Image = global::DaxPagosLote.Properties.Resources.Visto_Ok_Seleccion;
            this.btnQutarSelecccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQutarSelecccion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQutarSelecccion.Name = "btnQutarSelecccion";
            this.btnQutarSelecccion.Size = new System.Drawing.Size(113, 20);
            this.btnQutarSelecccion.Text = "Quitar Selección";
            this.btnQutarSelecccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQutarSelecccion.ToolTipText = "Recalcular el valor del concepto por fórmula";
            this.btnQutarSelecccion.Click += new System.EventHandler(this.btnQutarSelecccion_Click);
            // 
            // ToolStrip14
            // 
            this.ToolStrip14.AllowItemReorder = true;
            this.ToolStrip14.AutoSize = false;
            this.ToolStrip14.BackColor = System.Drawing.Color.Transparent;
            this.ToolStrip14.CanOverflow = false;
            this.ToolStrip14.Dock = System.Windows.Forms.DockStyle.Left;
            this.ToolStrip14.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip14.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ToolStrip14.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripSeparator17,
            this.btnParametros,
            this.toolStripSeparator1,
            this.btnAbrir,
            this.btnCierra,
            this.toolStripSeparator2,
            this.btnProcesar,
            this.btnEnviar,
            this.ToolStripSeparator8});
            this.ToolStrip14.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ToolStrip14.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip14.Name = "ToolStrip14";
            this.ToolStrip14.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStrip14.Size = new System.Drawing.Size(260, 54);
            this.ToolStrip14.TabIndex = 15;
            this.ToolStrip14.Text = "Períodos de Nóminas";
            // 
            // ToolStripSeparator17
            // 
            this.ToolStripSeparator17.Name = "ToolStripSeparator17";
            this.ToolStripSeparator17.Size = new System.Drawing.Size(6, 54);
            // 
            // btnParametros
            // 
            this.btnParametros.ForeColor = System.Drawing.Color.White;
            this.btnParametros.Image = global::DaxPagosLote.Properties.Resources.BotonOpcion;
            this.btnParametros.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnParametros.Name = "btnParametros";
            this.btnParametros.Size = new System.Drawing.Size(36, 51);
            this.btnParametros.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnParametros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnParametros.ToolTipText = "Abrir/cerrar parámetros";
            this.btnParametros.Click += new System.EventHandler(this.btnOcultarParametros_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 54);
            // 
            // btnAbrir
            // 
            this.btnAbrir.ForeColor = System.Drawing.Color.White;
            this.btnAbrir.Image = global::DaxPagosLote.Properties.Resources.Abrir;
            this.btnAbrir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(37, 51);
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAbrir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAbrir.ToolTipText = "Abrir lista de valores";
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // btnCierra
            // 
            this.btnCierra.ForeColor = System.Drawing.Color.White;
            this.btnCierra.Image = global::DaxPagosLote.Properties.Resources.Cerrar2;
            this.btnCierra.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCierra.Name = "btnCierra";
            this.btnCierra.Size = new System.Drawing.Size(43, 51);
            this.btnCierra.Text = "Cerrar";
            this.btnCierra.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCierra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCierra.ToolTipText = "Cerrar lista de valores";
            this.btnCierra.Click += new System.EventHandler(this.btnCierra_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 54);
            // 
            // btnProcesar
            // 
            this.btnProcesar.ForeColor = System.Drawing.Color.White;
            this.btnProcesar.Image = ((System.Drawing.Image)(resources.GetObject("btnProcesar.Image")));
            this.btnProcesar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(56, 51);
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProcesar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnProcesar.ToolTipText = "Crear los egresos en base a la lista de valores";
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImprimirToolStripMenuItem,
            this.ExcelToolStripMenuItem,
            this.PDFToolStripMenuItem});
            this.btnEnviar.ForeColor = System.Drawing.Color.White;
            this.btnEnviar.Image = ((System.Drawing.Image)(resources.GetObject("btnEnviar.Image")));
            this.btnEnviar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(55, 51);
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnviar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEnviar.ToolTipText = "Enviar lista a impresora excel, pdf ....";
            // 
            // ImprimirToolStripMenuItem
            // 
            this.ImprimirToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ImprimirToolStripMenuItem.Image")));
            this.ImprimirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem";
            this.ImprimirToolStripMenuItem.Size = new System.Drawing.Size(136, 38);
            this.ImprimirToolStripMenuItem.Text = "Imprimir";
            this.ImprimirToolStripMenuItem.Click += new System.EventHandler(this.ImprimirToolStripMenuItem_Click);
            // 
            // ExcelToolStripMenuItem
            // 
            this.ExcelToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ExcelToolStripMenuItem.Image")));
            this.ExcelToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ExcelToolStripMenuItem.Name = "ExcelToolStripMenuItem";
            this.ExcelToolStripMenuItem.Size = new System.Drawing.Size(136, 38);
            this.ExcelToolStripMenuItem.Text = "Excel";
            this.ExcelToolStripMenuItem.Click += new System.EventHandler(this.ExcelToolStripMenuItem_Click);
            // 
            // PDFToolStripMenuItem
            // 
            this.PDFToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("PDFToolStripMenuItem.Image")));
            this.PDFToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.PDFToolStripMenuItem.Name = "PDFToolStripMenuItem";
            this.PDFToolStripMenuItem.Size = new System.Drawing.Size(136, 38);
            this.PDFToolStripMenuItem.Text = "PDF";
            this.PDFToolStripMenuItem.Click += new System.EventHandler(this.PDFToolStripMenuItem_Click);
            // 
            // ToolStripSeparator8
            // 
            this.ToolStripSeparator8.Name = "ToolStripSeparator8";
            this.ToolStripSeparator8.Size = new System.Drawing.Size(6, 54);
            // 
            // frmcheLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 556);
            this.Controls.Add(this.MallaDatos);
            this.Controls.Add(this.PanelParametros);
            this.Controls.Add(this.ToolStripContainer1);
            this.Name = "frmcheLote";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EMITIR EGRESOS Y CHEQUES PARA EMPLEADOS";
            this.PanelParametros.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MallaDatos)).EndInit();
            this.ToolStripContainer1.ContentPanel.ResumeLayout(false);
            this.ToolStripContainer1.ContentPanel.PerformLayout();
            this.ToolStripContainer1.ResumeLayout(false);
            this.ToolStripContainer1.PerformLayout();
            this.ToolStrip13.ResumeLayout(false);
            this.ToolStrip13.PerformLayout();
            this.ToolStrip18.ResumeLayout(false);
            this.ToolStrip18.PerformLayout();
            this.ToolStrip14.ResumeLayout(false);
            this.ToolStrip14.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.DataGridView MallaDatos;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox cmbComceptosEgreso;
        private System.Windows.Forms.CheckBox chkImprimeCheque;
        private System.Windows.Forms.CheckBox chkImprimeEgreso;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkPausaImprime;
        internal System.Windows.Forms.Panel PanelParametros;
        internal System.Windows.Forms.ToolStripContainer ToolStripContainer1;
        internal System.Windows.Forms.ToolStrip ToolStrip13;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator6;
        internal System.Windows.Forms.ToolStripButton btnSalir2;
        internal System.Windows.Forms.ToolStrip ToolStrip18;
        internal System.Windows.Forms.ToolStripButton btnMarcarTodo;
        internal System.Windows.Forms.ToolStripButton btnQutarSelecccion;
        internal System.Windows.Forms.ToolStrip ToolStrip14;
        internal System.Windows.Forms.ToolStripButton btnAbrir;
        internal System.Windows.Forms.ToolStripButton btnCierra;
        internal System.Windows.Forms.ToolStripSplitButton btnEnviar;
        internal System.Windows.Forms.ToolStripMenuItem ImprimirToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ExcelToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem PDFToolStripMenuItem;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator8;
        internal System.Windows.Forms.ToolStripButton BtnQuitarTodo;
        internal System.Windows.Forms.ToolStripButton btnMarcarSeleccion;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator17;
        internal System.Windows.Forms.ToolStripButton btnProcesar;
        internal System.Windows.Forms.ComboBox cmbDocumento;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cmbBancos;
        internal System.Windows.Forms.ToolStripButton btnParametros;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.ComboBox cmbRubrosNomina;
        internal System.Windows.Forms.ComboBox cmbPeriodosRol;
        internal System.Windows.Forms.Label LablabRubro;
        internal System.Windows.Forms.Label labperido;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtFechaDocumento;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

