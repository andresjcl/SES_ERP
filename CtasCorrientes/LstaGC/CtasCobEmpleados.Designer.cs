namespace adcCtasCorrientes
{
    partial class CtasCobEmpleados
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
            this.menu = new System.Windows.Forms.ToolStrip();
            this.contenedor = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.agSucursal = new System.Windows.Forms.RadioButton();
            this.adVencimiento = new System.Windows.Forms.CheckBox();
            this.cSucursal = new System.Windows.Forms.ComboBox();
            this.tFecha = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cheSoloTotal = new System.Windows.Forms.CheckBox();
            this.chkValorVencido = new System.Windows.Forms.CheckBox();
            this.cheDetDoc = new System.Windows.Forms.CheckBox();
            this.chUnaCuentaPorHoja = new System.Windows.Forms.CheckBox();
            this.chkFechaVencimiento = new System.Windows.Forms.CheckBox();
            this.chkValorInicial = new System.Windows.Forms.CheckBox();
            this.chkDiasVencidos = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.opciones = new System.Windows.Forms.ToolStripButton();
            this.imprimir = new System.Windows.Forms.ToolStripButton();
            this.salir = new System.Windows.Forms.ToolStripButton();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contenedor)).BeginInit();
            this.contenedor.Panel1.SuspendLayout();
            this.contenedor.Panel2.SuspendLayout();
            this.contenedor.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.AutoSize = false;
            this.menu.BackColor = System.Drawing.Color.DimGray;
            this.menu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opciones,
            this.imprimir,
            this.salir});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(973, 45);
            this.menu.TabIndex = 3;
            this.menu.Text = "toolStrip1";
            // 
            // contenedor
            // 
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedor.Location = new System.Drawing.Point(0, 45);
            this.contenedor.Name = "contenedor";
            // 
            // contenedor.Panel1
            // 
            this.contenedor.Panel1.Controls.Add(this.panel1);
            this.contenedor.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // contenedor.Panel2
            // 
            this.contenedor.Panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.contenedor.Panel2.Controls.Add(this.reportViewer1);
            this.contenedor.Size = new System.Drawing.Size(973, 642);
            this.contenedor.SplitterDistance = 319;
            this.contenedor.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.agSucursal);
            this.panel1.Controls.Add(this.adVencimiento);
            this.panel1.Controls.Add(this.cSucursal);
            this.panel1.Controls.Add(this.tFecha);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(319, 642);
            this.panel1.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(260, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 15);
            this.label12.TabIndex = 69;
            this.label12.Text = "AGRUPA";
            this.label12.Visible = false;
            // 
            // agSucursal
            // 
            this.agSucursal.AutoSize = true;
            this.agSucursal.Location = new System.Drawing.Point(275, 91);
            this.agSucursal.Name = "agSucursal";
            this.agSucursal.Size = new System.Drawing.Size(14, 13);
            this.agSucursal.TabIndex = 70;
            this.agSucursal.TabStop = true;
            this.agSucursal.UseVisualStyleBackColor = true;
            this.agSucursal.Visible = false;
            // 
            // adVencimiento
            // 
            this.adVencimiento.AutoSize = true;
            this.adVencimiento.ForeColor = System.Drawing.Color.White;
            this.adVencimiento.Location = new System.Drawing.Point(16, 55);
            this.adVencimiento.Name = "adVencimiento";
            this.adVencimiento.Size = new System.Drawing.Size(113, 17);
            this.adVencimiento.TabIndex = 70;
            this.adVencimiento.Text = "Solo Vencimientos";
            this.adVencimiento.UseVisualStyleBackColor = true;
            // 
            // cSucursal
            // 
            this.cSucursal.FormattingEnabled = true;
            this.cSucursal.ItemHeight = 13;
            this.cSucursal.Location = new System.Drawing.Point(69, 87);
            this.cSucursal.Name = "cSucursal";
            this.cSucursal.Size = new System.Drawing.Size(187, 21);
            this.cSucursal.TabIndex = 46;
            // 
            // tFecha
            // 
            this.tFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tFecha.Location = new System.Drawing.Point(120, 9);
            this.tFecha.Name = "tFecha";
            this.tFecha.Size = new System.Drawing.Size(90, 20);
            this.tFecha.TabIndex = 60;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(13, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Sucursal:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cheSoloTotal);
            this.groupBox2.Controls.Add(this.chkValorVencido);
            this.groupBox2.Controls.Add(this.cheDetDoc);
            this.groupBox2.Controls.Add(this.chUnaCuentaPorHoja);
            this.groupBox2.Controls.Add(this.chkFechaVencimiento);
            this.groupBox2.Controls.Add(this.chkValorInicial);
            this.groupBox2.Controls.Add(this.chkDiasVencidos);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(12, 137);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(302, 151);
            this.groupBox2.TabIndex = 55;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Campos a imprimir";
            // 
            // cheSoloTotal
            // 
            this.cheSoloTotal.AutoSize = true;
            this.cheSoloTotal.ForeColor = System.Drawing.Color.White;
            this.cheSoloTotal.Location = new System.Drawing.Point(12, 104);
            this.cheSoloTotal.Name = "cheSoloTotal";
            this.cheSoloTotal.Size = new System.Drawing.Size(117, 17);
            this.cheSoloTotal.TabIndex = 10;
            this.cheSoloTotal.Text = "Imprimir solo totales";
            this.cheSoloTotal.UseVisualStyleBackColor = true;
            // 
            // chkValorVencido
            // 
            this.chkValorVencido.AutoSize = true;
            this.chkValorVencido.ForeColor = System.Drawing.Color.White;
            this.chkValorVencido.Location = new System.Drawing.Point(11, 70);
            this.chkValorVencido.Name = "chkValorVencido";
            this.chkValorVencido.Size = new System.Drawing.Size(91, 17);
            this.chkValorVencido.TabIndex = 9;
            this.chkValorVencido.Text = "Valor vencido";
            this.chkValorVencido.UseVisualStyleBackColor = true;
            // 
            // cheDetDoc
            // 
            this.cheDetDoc.AutoSize = true;
            this.cheDetDoc.Checked = true;
            this.cheDetDoc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cheDetDoc.ForeColor = System.Drawing.Color.White;
            this.cheDetDoc.Location = new System.Drawing.Point(11, 87);
            this.cheDetDoc.Name = "cheDetDoc";
            this.cheDetDoc.Size = new System.Drawing.Size(135, 17);
            this.cheDetDoc.TabIndex = 8;
            this.cheDetDoc.Text = "Detalle de documentos";
            this.cheDetDoc.UseVisualStyleBackColor = true;
            // 
            // chUnaCuentaPorHoja
            // 
            this.chUnaCuentaPorHoja.AutoSize = true;
            this.chUnaCuentaPorHoja.ForeColor = System.Drawing.Color.White;
            this.chUnaCuentaPorHoja.Location = new System.Drawing.Point(12, 122);
            this.chUnaCuentaPorHoja.Name = "chUnaCuentaPorHoja";
            this.chUnaCuentaPorHoja.Size = new System.Drawing.Size(239, 17);
            this.chUnaCuentaPorHoja.TabIndex = 5;
            this.chUnaCuentaPorHoja.Text = "Imprimir un estado de cuenta en cada página";
            this.chUnaCuentaPorHoja.UseVisualStyleBackColor = true;
            // 
            // chkFechaVencimiento
            // 
            this.chkFechaVencimiento.AutoSize = true;
            this.chkFechaVencimiento.ForeColor = System.Drawing.Color.White;
            this.chkFechaVencimiento.Location = new System.Drawing.Point(11, 53);
            this.chkFechaVencimiento.Name = "chkFechaVencimiento";
            this.chkFechaVencimiento.Size = new System.Drawing.Size(131, 17);
            this.chkFechaVencimiento.TabIndex = 4;
            this.chkFechaVencimiento.Text = "Fecha de vencimiento";
            this.chkFechaVencimiento.UseVisualStyleBackColor = true;
            // 
            // chkValorInicial
            // 
            this.chkValorInicial.AutoSize = true;
            this.chkValorInicial.ForeColor = System.Drawing.Color.White;
            this.chkValorInicial.Location = new System.Drawing.Point(11, 36);
            this.chkValorInicial.Name = "chkValorInicial";
            this.chkValorInicial.Size = new System.Drawing.Size(152, 17);
            this.chkValorInicial.TabIndex = 3;
            this.chkValorInicial.Text = "Valor inicial del documento";
            this.chkValorInicial.UseVisualStyleBackColor = true;
            // 
            // chkDiasVencidos
            // 
            this.chkDiasVencidos.AutoSize = true;
            this.chkDiasVencidos.ForeColor = System.Drawing.Color.White;
            this.chkDiasVencidos.Location = new System.Drawing.Point(11, 19);
            this.chkDiasVencidos.Name = "chkDiasVencidos";
            this.chkDiasVencidos.Size = new System.Drawing.Size(93, 17);
            this.chkDiasVencidos.TabIndex = 2;
            this.chkDiasVencidos.Text = "Dias vencidos";
            this.chkDiasVencidos.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Hasta la fecha:";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(650, 642);
            this.reportViewer1.TabIndex = 0;
            // 
            // opciones
            // 
            this.opciones.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.opciones.Image = global::adcCtasCorrientes.Properties.Resources.BotonOpcion;
            this.opciones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.opciones.Name = "opciones";
            this.opciones.Size = new System.Drawing.Size(61, 42);
            this.opciones.Text = "Opciones";
            this.opciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.opciones.Click += new System.EventHandler(this.opciones_Click);
            // 
            // imprimir
            // 
            this.imprimir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.imprimir.Image = global::adcCtasCorrientes.Properties.Resources.Procesar;
            this.imprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.imprimir.Name = "imprimir";
            this.imprimir.Size = new System.Drawing.Size(63, 42);
            this.imprimir.Text = "Actualizar";
            this.imprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.imprimir.Click += new System.EventHandler(this.imprimir_Click);
            // 
            // salir
            // 
            this.salir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.salir.Image = global::adcCtasCorrientes.Properties.Resources.Salir;
            this.salir.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.salir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.salir.Name = "salir";
            this.salir.Size = new System.Drawing.Size(57, 42);
            this.salir.Text = "Salir";
            this.salir.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.salir.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.salir.Click += new System.EventHandler(this.salir_Click);
            // 
            // CtasCobEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 687);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.menu);
            this.Name = "CtasCobEmpleados";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuentas por cobrar empleados";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.contenedor.Panel1.ResumeLayout(false);
            this.contenedor.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contenedor)).EndInit();
            this.contenedor.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton opciones;
        private System.Windows.Forms.ToolStripButton imprimir;
        private System.Windows.Forms.ToolStripButton salir;
        private System.Windows.Forms.SplitContainer contenedor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cSucursal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chUnaCuentaPorHoja;
        private System.Windows.Forms.CheckBox chkFechaVencimiento;
        private System.Windows.Forms.CheckBox chkValorInicial;
        private System.Windows.Forms.CheckBox chkDiasVencidos;
        private System.Windows.Forms.CheckBox cheDetDoc;
        private System.Windows.Forms.CheckBox adVencimiento;
        private System.Windows.Forms.CheckBox chkValorVencido;
        private System.Windows.Forms.RadioButton agSucursal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox cheSoloTotal;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.DateTimePicker tFecha;
    }
}

