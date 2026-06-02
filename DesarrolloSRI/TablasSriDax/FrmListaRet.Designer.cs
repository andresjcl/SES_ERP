namespace IvaRett
{
    partial class FrmlistaReten
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmlistaReten));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.mallaListado = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.mallaTotales = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radventas = new System.Windows.Forms.RadioButton();
            this.radcompras = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.btnTipoRetencion = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDocumento = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnProcesar = new System.Windows.Forms.ToolStripButton();
            this.btnEnviar = new System.Windows.Forms.ToolStripSplitButton();
            this.ImprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.txtFechaIni = new System.Windows.Forms.DateTimePicker();
            this.txtFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mallaListado)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mallaTotales)).BeginInit();
            this.panel1.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 73);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(974, 298);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.mallaListado);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(966, 272);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lista de retenciones";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // mallaListado
            // 
            this.mallaListado.AllowUserToAddRows = false;
            this.mallaListado.AllowUserToDeleteRows = false;
            this.mallaListado.AllowUserToOrderColumns = true;
            this.mallaListado.AllowUserToResizeRows = false;
            this.mallaListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.mallaListado.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mallaListado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.mallaListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mallaListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mallaListado.EnableHeadersVisualStyles = false;
            this.mallaListado.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mallaListado.Location = new System.Drawing.Point(3, 3);
            this.mallaListado.Name = "mallaListado";
            this.mallaListado.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mallaListado.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.mallaListado.Size = new System.Drawing.Size(960, 266);
            this.mallaListado.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.mallaTotales);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(966, 272);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Totales";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // mallaTotales
            // 
            this.mallaTotales.AllowUserToAddRows = false;
            this.mallaTotales.AllowUserToDeleteRows = false;
            this.mallaTotales.AllowUserToOrderColumns = true;
            this.mallaTotales.AllowUserToResizeRows = false;
            this.mallaTotales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.mallaTotales.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mallaTotales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.mallaTotales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mallaTotales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mallaTotales.EnableHeadersVisualStyles = false;
            this.mallaTotales.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mallaTotales.Location = new System.Drawing.Point(3, 3);
            this.mallaTotales.Name = "mallaTotales";
            this.mallaTotales.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mallaTotales.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.mallaTotales.Size = new System.Drawing.Size(960, 266);
            this.mallaTotales.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtFechaFin);
            this.panel1.Controls.Add(this.txtFechaIni);
            this.panel1.Controls.Add(this.radventas);
            this.panel1.Controls.Add(this.radcompras);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(974, 34);
            this.panel1.TabIndex = 4;
            // 
            // radventas
            // 
            this.radventas.AutoSize = true;
            this.radventas.ForeColor = System.Drawing.Color.White;
            this.radventas.Location = new System.Drawing.Point(84, 9);
            this.radventas.Name = "radventas";
            this.radventas.Size = new System.Drawing.Size(58, 17);
            this.radventas.TabIndex = 6;
            this.radventas.Text = "Ventas";
            this.radventas.UseVisualStyleBackColor = true;
            this.radventas.CheckedChanged += new System.EventHandler(this.radventas_CheckedChanged);
            // 
            // radcompras
            // 
            this.radcompras.AutoSize = true;
            this.radcompras.Checked = true;
            this.radcompras.ForeColor = System.Drawing.Color.White;
            this.radcompras.Location = new System.Drawing.Point(12, 9);
            this.radcompras.Name = "radcompras";
            this.radcompras.Size = new System.Drawing.Size(66, 17);
            this.radcompras.TabIndex = 5;
            this.radcompras.TabStop = true;
            this.radcompras.Text = "Compras";
            this.radcompras.UseVisualStyleBackColor = true;
            this.radcompras.CheckedChanged += new System.EventHandler(this.radventas_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(227, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Período";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.toolStripSeparator2,
            this.btnProcesar,
            this.btnEnviar,
            this.ToolStripSeparator1,
            this.btnSalir});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(974, 39);
            this.ToolStrip1.TabIndex = 5;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTipoRetencion,
            this.btnDocumento});
            this.toolStripSplitButton1.ForeColor = System.Drawing.Color.White;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(117, 36);
            this.toolStripSplitButton1.Text = "TipoListado";
            // 
            // btnTipoRetencion
            // 
            this.btnTipoRetencion.CheckOnClick = true;
            this.btnTipoRetencion.Image = ((System.Drawing.Image)(resources.GetObject("btnTipoRetencion.Image")));
            this.btnTipoRetencion.Name = "btnTipoRetencion";
            this.btnTipoRetencion.Size = new System.Drawing.Size(185, 22);
            this.btnTipoRetencion.Text = "Por tipo de retención";
            this.btnTipoRetencion.Click += new System.EventHandler(this.btnTipoRetencion_Click);
            // 
            // btnDocumento
            // 
            this.btnDocumento.Checked = true;
            this.btnDocumento.CheckOnClick = true;
            this.btnDocumento.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnDocumento.Image = ((System.Drawing.Image)(resources.GetObject("btnDocumento.Image")));
            this.btnDocumento.Name = "btnDocumento";
            this.btnDocumento.Size = new System.Drawing.Size(185, 22);
            this.btnDocumento.Text = "Por documento";
            this.btnDocumento.Click += new System.EventHandler(this.btnDocumento_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // btnProcesar
            // 
            this.btnProcesar.ForeColor = System.Drawing.Color.White;
            this.btnProcesar.Image = ((System.Drawing.Image)(resources.GetObject("btnProcesar.Image")));
            this.btnProcesar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(88, 36);
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
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
            // ImprimirToolStripMenuItem
            // 
            this.ImprimirToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ImprimirToolStripMenuItem.Image")));
            this.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem";
            this.ImprimirToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.ImprimirToolStripMenuItem.Text = "Imprimir";
            this.ImprimirToolStripMenuItem.Click += new System.EventHandler(this.ImprimirToolStripMenuItem_Click);
            // 
            // WordToolStripMenuItem
            // 
            this.WordToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("WordToolStripMenuItem.Image")));
            this.WordToolStripMenuItem.Name = "WordToolStripMenuItem";
            this.WordToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.WordToolStripMenuItem.Text = "Word";
            this.WordToolStripMenuItem.Click += new System.EventHandler(this.WordToolStripMenuItem_Click);
            // 
            // ExcelToolStripMenuItem
            // 
            this.ExcelToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ExcelToolStripMenuItem.Image")));
            this.ExcelToolStripMenuItem.Name = "ExcelToolStripMenuItem";
            this.ExcelToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.ExcelToolStripMenuItem.Text = "Excel";
            this.ExcelToolStripMenuItem.Click += new System.EventHandler(this.ExcelToolStripMenuItem_Click);
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
            // txtFechaIni
            // 
            this.txtFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFechaIni.Location = new System.Drawing.Point(278, 6);
            this.txtFechaIni.Name = "txtFechaIni";
            this.txtFechaIni.Size = new System.Drawing.Size(78, 20);
            this.txtFechaIni.TabIndex = 7;
            // 
            // txtFechaFin
            // 
            this.txtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFechaFin.Location = new System.Drawing.Point(390, 6);
            this.txtFechaFin.Name = "txtFechaFin";
            this.txtFechaFin.Size = new System.Drawing.Size(78, 20);
            this.txtFechaFin.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(368, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "al";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // FrmlistaReten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 371);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ToolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmlistaReten";
            this.Text = "LISTA DE RETENCIONES POR DOCUMENTOS";
            this.Load += new System.EventHandler(this.FrmFacSinRet_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mallaListado)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mallaTotales)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView mallaListado;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton btnProcesar;
        internal System.Windows.Forms.ToolStripSplitButton btnEnviar;
        internal System.Windows.Forms.ToolStripMenuItem ImprimirToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem WordToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ExcelToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem PDFToolStripMenuItem;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.RadioButton radventas;
        private System.Windows.Forms.RadioButton radcompras;
        private System.Windows.Forms.DataGridView mallaTotales;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem btnTipoRetencion;
        private System.Windows.Forms.ToolStripMenuItem btnDocumento;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DateTimePicker txtFechaIni;
        private System.Windows.Forms.DateTimePicker txtFechaFin;
        private System.Windows.Forms.Label label1;
    }
}

