namespace importarData
{
    partial class ImportarDirectorio
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView mallaIdentificacion;
        private System.Windows.Forms.DataGridView mallaValidacion;
        private System.Windows.Forms.DataGridView mallaBD;
        private System.Windows.Forms.Button btnIdentificacionCargar;
        private System.Windows.Forms.Button btnValidarDirectorio;
        private System.Windows.Forms.Button btnCargarDirectorio;
        private System.Windows.Forms.Button btnExportarErrores;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnDescargarPlantilla;  // ← NUEVO BOTÓN
        private System.Windows.Forms.Button btnRefrescarBD;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageExcel;
        private System.Windows.Forms.TabPage tabPageValidacion;
        private System.Windows.Forms.TabPage tabPageBD;
        private System.Windows.Forms.Label lblTotalRegistros;
        private System.Windows.Forms.Label lblResumen;
        private System.Windows.Forms.Label lblEstadisticas;
        private System.Windows.Forms.Label lblTotalBD;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.Label lblArchivo;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Label lblParametros;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.mallaIdentificacion = new System.Windows.Forms.DataGridView();
            this.mallaValidacion = new System.Windows.Forms.DataGridView();
            this.mallaBD = new System.Windows.Forms.DataGridView();
            this.btnIdentificacionCargar = new System.Windows.Forms.Button();
            this.btnValidarDirectorio = new System.Windows.Forms.Button();
            this.btnCargarDirectorio = new System.Windows.Forms.Button();
            this.btnExportarErrores = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnDescargarPlantilla = new System.Windows.Forms.Button();
            this.btnRefrescarBD = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageExcel = new System.Windows.Forms.TabPage();
            this.tabPageValidacion = new System.Windows.Forms.TabPage();
            this.tabPageBD = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblArchivo = new System.Windows.Forms.Label();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.lblParametros = new System.Windows.Forms.Label();
            this.lblEstadisticas = new System.Windows.Forms.Label();
            this.lblResumen = new System.Windows.Forms.Label();
            this.lblTotalRegistros = new System.Windows.Forms.Label();
            this.lblTotalBD = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.mallaIdentificacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mallaValidacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mallaBD)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageExcel.SuspendLayout();
            this.tabPageValidacion.SuspendLayout();
            this.tabPageBD.SuspendLayout();
            this.panel3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mallaIdentificacion
            // 
            this.mallaIdentificacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mallaIdentificacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mallaIdentificacion.Location = new System.Drawing.Point(3, 3);
            this.mallaIdentificacion.Name = "mallaIdentificacion";
            this.mallaIdentificacion.RowHeadersWidth = 62;
            this.mallaIdentificacion.Size = new System.Drawing.Size(1186, 501);
            this.mallaIdentificacion.TabIndex = 0;
            // 
            // mallaValidacion
            // 
            this.mallaValidacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mallaValidacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mallaValidacion.Location = new System.Drawing.Point(3, 3);
            this.mallaValidacion.Name = "mallaValidacion";
            this.mallaValidacion.RowHeadersWidth = 62;
            this.mallaValidacion.Size = new System.Drawing.Size(1186, 465);
            this.mallaValidacion.TabIndex = 0;
            // 
            // mallaBD
            // 
            this.mallaBD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mallaBD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mallaBD.Location = new System.Drawing.Point(3, 3);
            this.mallaBD.Name = "mallaBD";
            this.mallaBD.RowHeadersWidth = 62;
            this.mallaBD.Size = new System.Drawing.Size(1186, 465);
            this.mallaBD.TabIndex = 0;
            // 
            // btnIdentificacionCargar
            // 
            this.btnIdentificacionCargar.ForeColor = System.Drawing.Color.Black;
            this.btnIdentificacionCargar.Location = new System.Drawing.Point(12, 21);
            this.btnIdentificacionCargar.Name = "btnIdentificacionCargar";
            this.btnIdentificacionCargar.Size = new System.Drawing.Size(130, 30);
            this.btnIdentificacionCargar.TabIndex = 0;
            this.btnIdentificacionCargar.Text = "📂 Cargar Excel";
            this.btnIdentificacionCargar.UseVisualStyleBackColor = true;
            this.btnIdentificacionCargar.Click += new System.EventHandler(this.btnIdentificacionCargar_Click);
            // 
            // btnValidarDirectorio
            // 
            this.btnValidarDirectorio.Enabled = false;
            this.btnValidarDirectorio.Location = new System.Drawing.Point(150, 21);
            this.btnValidarDirectorio.Name = "btnValidarDirectorio";
            this.btnValidarDirectorio.Size = new System.Drawing.Size(130, 30);
            this.btnValidarDirectorio.TabIndex = 1;
            this.btnValidarDirectorio.Text = "✅ Validar Datos";
            this.btnValidarDirectorio.UseVisualStyleBackColor = true;
            this.btnValidarDirectorio.Click += new System.EventHandler(this.btnValidarDirectorio_Click);
            // 
            // btnCargarDirectorio
            // 
            this.btnCargarDirectorio.Enabled = false;
            this.btnCargarDirectorio.Location = new System.Drawing.Point(288, 21);
            this.btnCargarDirectorio.Name = "btnCargarDirectorio";
            this.btnCargarDirectorio.Size = new System.Drawing.Size(130, 30);
            this.btnCargarDirectorio.TabIndex = 2;
            this.btnCargarDirectorio.Text = "💾 Guardar en BD";
            this.btnCargarDirectorio.UseVisualStyleBackColor = true;
            this.btnCargarDirectorio.Click += new System.EventHandler(this.btnCargarDirectorio_Click);
            // 
            // btnExportarErrores
            // 
            this.btnExportarErrores.Enabled = false;
            this.btnExportarErrores.Location = new System.Drawing.Point(426, 21);
            this.btnExportarErrores.Name = "btnExportarErrores";
            this.btnExportarErrores.Size = new System.Drawing.Size(120, 30);
            this.btnExportarErrores.TabIndex = 3;
            this.btnExportarErrores.Text = "📄 Exportar Errores";
            this.btnExportarErrores.UseVisualStyleBackColor = true;
            this.btnExportarErrores.Click += new System.EventHandler(this.btnExportarErrores_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(554, 21);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 30);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "🗑️ Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnDescargarPlantilla
            // 
            this.btnDescargarPlantilla.Location = new System.Drawing.Point(662, 21);
            this.btnDescargarPlantilla.Name = "btnDescargarPlantilla";
            this.btnDescargarPlantilla.Size = new System.Drawing.Size(140, 30);
            this.btnDescargarPlantilla.TabIndex = 5;
            this.btnDescargarPlantilla.Text = "📥 Descargar Plantilla";
            this.btnDescargarPlantilla.UseVisualStyleBackColor = true;
            this.btnDescargarPlantilla.Click += new System.EventHandler(this.btnDescargarPlantilla_Click);
            // 
            // btnRefrescarBD
            // 
            this.btnRefrescarBD.Location = new System.Drawing.Point(780, 22);
            this.btnRefrescarBD.Name = "btnRefrescarBD";
            this.btnRefrescarBD.Size = new System.Drawing.Size(130, 25);
            this.btnRefrescarBD.TabIndex = 5;
            this.btnRefrescarBD.Text = "🔄 Refrescar BD";
            this.btnRefrescarBD.UseVisualStyleBackColor = true;
            this.btnRefrescarBD.Click += new System.EventHandler(this.btnRefrescarBD_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.btnDescargarPlantilla);
            this.panel1.Controls.Add(this.btnExportarErrores);
            this.panel1.Controls.Add(this.btnLimpiar);
            this.panel1.Controls.Add(this.btnCargarDirectorio);
            this.panel1.Controls.Add(this.btnValidarDirectorio);
            this.panel1.Controls.Add(this.btnIdentificacionCargar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 70);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1200, 586);
            this.panel2.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageExcel);
            this.tabControl1.Controls.Add(this.tabPageValidacion);
            this.tabControl1.Controls.Add(this.tabPageBD);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1200, 536);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageExcel
            // 
            this.tabPageExcel.Controls.Add(this.mallaIdentificacion);
            this.tabPageExcel.Location = new System.Drawing.Point(4, 25);
            this.tabPageExcel.Name = "tabPageExcel";
            this.tabPageExcel.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageExcel.Size = new System.Drawing.Size(1192, 507);
            this.tabPageExcel.TabIndex = 0;
            this.tabPageExcel.Text = "📊 Datos Excel";
            this.tabPageExcel.UseVisualStyleBackColor = true;
            // 
            // tabPageValidacion
            // 
            this.tabPageValidacion.Controls.Add(this.mallaValidacion);
            this.tabPageValidacion.Location = new System.Drawing.Point(4, 25);
            this.tabPageValidacion.Name = "tabPageValidacion";
            this.tabPageValidacion.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageValidacion.Size = new System.Drawing.Size(1192, 471);
            this.tabPageValidacion.TabIndex = 1;
            this.tabPageValidacion.Text = "✅ Resultado Validación";
            this.tabPageValidacion.UseVisualStyleBackColor = true;
            // 
            // tabPageBD
            // 
            this.tabPageBD.Controls.Add(this.mallaBD);
            this.tabPageBD.Location = new System.Drawing.Point(4, 25);
            this.tabPageBD.Name = "tabPageBD";
            this.tabPageBD.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBD.Size = new System.Drawing.Size(1192, 471);
            this.tabPageBD.TabIndex = 2;
            this.tabPageBD.Text = "💾 Datos Guardados";
            this.tabPageBD.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Controls.Add(this.btnRefrescarBD);
            this.panel3.Controls.Add(this.lblUsuario);
            this.panel3.Controls.Add(this.txtUsuario);
            this.panel3.Controls.Add(this.lblArchivo);
            this.panel3.Controls.Add(this.txtArchivo);
            this.panel3.Controls.Add(this.lblParametros);
            this.panel3.Controls.Add(this.lblEstadisticas);
            this.panel3.Controls.Add(this.lblResumen);
            this.panel3.Controls.Add(this.lblTotalRegistros);
            this.panel3.Controls.Add(this.lblTotalBD);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 536);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1200, 50);
            this.panel3.TabIndex = 1;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(530, 28);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(61, 17);
            this.lblUsuario.TabIndex = 8;
            this.lblUsuario.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(600, 25);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(150, 22);
            this.txtUsuario.TabIndex = 7;
            this.txtUsuario.Text = "ADMIN";
            // 
            // lblArchivo
            // 
            this.lblArchivo.AutoSize = true;
            this.lblArchivo.Location = new System.Drawing.Point(10, 28);
            this.lblArchivo.Name = "lblArchivo";
            this.lblArchivo.Size = new System.Drawing.Size(59, 17);
            this.lblArchivo.TabIndex = 6;
            this.lblArchivo.Text = "Archivo:";
            this.lblArchivo.Visible = false;
            // 
            // txtArchivo
            // 
            this.txtArchivo.Location = new System.Drawing.Point(70, 25);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.ReadOnly = true;
            this.txtArchivo.Size = new System.Drawing.Size(350, 22);
            this.txtArchivo.TabIndex = 5;
            // 
            // lblParametros
            // 
            this.lblParametros.AutoSize = true;
            this.lblParametros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.lblParametros.ForeColor = System.Drawing.Color.Gray;
            this.lblParametros.Location = new System.Drawing.Point(10, 28);
            this.lblParametros.Name = "lblParametros";
            this.lblParametros.Size = new System.Drawing.Size(206, 17);
            this.lblParametros.TabIndex = 4;
            this.lblParametros.Text = "📋 Esperando carga de Excel...";
            // 
            // lblEstadisticas
            // 
            this.lblEstadisticas.AutoSize = true;
            this.lblEstadisticas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblEstadisticas.Location = new System.Drawing.Point(440, 5);
            this.lblEstadisticas.Name = "lblEstadisticas";
            this.lblEstadisticas.Size = new System.Drawing.Size(87, 17);
            this.lblEstadisticas.TabIndex = 3;
            this.lblEstadisticas.Text = "Estadísticas:";
            // 
            // lblResumen
            // 
            this.lblResumen.AutoSize = true;
            this.lblResumen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblResumen.Location = new System.Drawing.Point(130, 5);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(221, 17);
            this.lblResumen.TabIndex = 1;
            this.lblResumen.Text = "✅ Válidos: 0 | ❌ Inválidos: 0";
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.AutoSize = true;
            this.lblTotalRegistros.Location = new System.Drawing.Point(10, 5);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(115, 17);
            this.lblTotalRegistros.TabIndex = 0;
            this.lblTotalRegistros.Text = "Total registros: 0";
            // 
            // lblTotalBD
            // 
            this.lblTotalBD.AutoSize = true;
            this.lblTotalBD.Location = new System.Drawing.Point(310, 5);
            this.lblTotalBD.Name = "lblTotalBD";
            this.lblTotalBD.Size = new System.Drawing.Size(99, 17);
            this.lblTotalBD.TabIndex = 2;
            this.lblTotalBD.Text = "Total en BD: 0";
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 646);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1200, 10);
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 620);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1200, 26);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(172, 20);
            this.toolStripStatusLabel.Text = "Listo para cargar archivo";
            // 
            // ImportarDirectorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 656);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ImportarDirectorio";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar Directorio - Clientes y Proveedores";
            //this.Load += new System.EventHandler(this.ImportarDirectorio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mallaIdentificacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mallaValidacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mallaBD)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageExcel.ResumeLayout(false);
            this.tabPageValidacion.ResumeLayout(false);
            this.tabPageBD.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}