namespace ImprEtiquet
{
    partial class frmImprEt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImprEt));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnGenerar = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.malla = new System.Windows.Forms.DataGridView();
            this.CamposDisponibles = new System.Windows.Forms.ListBox();
            this.CamposParaEtiqueta = new System.Windows.Forms.ListBox();
            this.btnRegresaTodos = new System.Windows.Forms.Button();
            this.btnPasaTodos = new System.Windows.Forms.Button();
            this.btnRegresaUno = new System.Windows.Forms.Button();
            this.btnPasaUno = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.malla)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGenerar,
            this.ToolStripSeparator1,
            this.btnSalir});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(776, 38);
            this.ToolStrip1.TabIndex = 1;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // btnGenerar
            // 
            this.btnGenerar.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerar.Image")));
            this.btnGenerar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(52, 35);
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(33, 35);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // malla
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.malla.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.malla.BackgroundColor = System.Drawing.Color.White;
            this.malla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.malla.Dock = System.Windows.Forms.DockStyle.Top;
            this.malla.Location = new System.Drawing.Point(0, 38);
            this.malla.Name = "malla";
            this.malla.Size = new System.Drawing.Size(776, 378);
            this.malla.TabIndex = 2;
            // 
            // CamposDisponibles
            // 
            this.CamposDisponibles.Dock = System.Windows.Forms.DockStyle.Left;
            this.CamposDisponibles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CamposDisponibles.FormattingEnabled = true;
            this.CamposDisponibles.ItemHeight = 16;
            this.CamposDisponibles.Items.AddRange(new object[] {
            "Codigo",
            "Nombre",
            "TipoActivo",
            "Categoria",
            "Clase",
            "Grupo",
            "Subgrupo",
            "Marca",
            "Serie",
            "NroLote",
            "CentroCosto",
            "UbicaSucursal",
            "UbicaDepartamento",
            "UbicaSeccion",
            "Responsable",
            "Estado"});
            this.CamposDisponibles.Location = new System.Drawing.Point(0, 416);
            this.CamposDisponibles.MultiColumn = true;
            this.CamposDisponibles.Name = "CamposDisponibles";
            this.CamposDisponibles.Size = new System.Drawing.Size(328, 169);
            this.CamposDisponibles.TabIndex = 3;
            this.CamposDisponibles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CamposDisponibles_MouseDown);
            // 
            // CamposParaEtiqueta
            // 
            this.CamposParaEtiqueta.AllowDrop = true;
            this.CamposParaEtiqueta.Dock = System.Windows.Forms.DockStyle.Right;
            this.CamposParaEtiqueta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CamposParaEtiqueta.FormattingEnabled = true;
            this.CamposParaEtiqueta.ItemHeight = 16;
            this.CamposParaEtiqueta.Location = new System.Drawing.Point(448, 416);
            this.CamposParaEtiqueta.MultiColumn = true;
            this.CamposParaEtiqueta.Name = "CamposParaEtiqueta";
            this.CamposParaEtiqueta.Size = new System.Drawing.Size(328, 169);
            this.CamposParaEtiqueta.TabIndex = 4;
            this.CamposParaEtiqueta.DragDrop += new System.Windows.Forms.DragEventHandler(this.CamposParaEtiqueta_DragDrop);
            this.CamposParaEtiqueta.DragOver += new System.Windows.Forms.DragEventHandler(this.CamposParaEtiqueta_DragOver);
            this.CamposParaEtiqueta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CamposParaEtiqueta_KeyDown);
            // 
            // btnRegresaTodos
            // 
            this.btnRegresaTodos.BackColor = System.Drawing.Color.SteelBlue;
            this.btnRegresaTodos.ForeColor = System.Drawing.Color.White;
            this.btnRegresaTodos.Image = global::ImprEtiquet.Properties.Resources.arrow_right___392_;
            this.btnRegresaTodos.Location = new System.Drawing.Point(343, 540);
            this.btnRegresaTodos.Name = "btnRegresaTodos";
            this.btnRegresaTodos.Size = new System.Drawing.Size(90, 35);
            this.btnRegresaTodos.TabIndex = 12;
            this.btnRegresaTodos.UseVisualStyleBackColor = false;
            this.btnRegresaTodos.Click += new System.EventHandler(this.btnRegresaTodos_Click);
            // 
            // btnPasaTodos
            // 
            this.btnPasaTodos.BackColor = System.Drawing.Color.SteelBlue;
            this.btnPasaTodos.ForeColor = System.Drawing.Color.White;
            this.btnPasaTodos.Image = global::ImprEtiquet.Properties.Resources.arrow_left___391_;
            this.btnPasaTodos.Location = new System.Drawing.Point(343, 504);
            this.btnPasaTodos.Name = "btnPasaTodos";
            this.btnPasaTodos.Size = new System.Drawing.Size(90, 35);
            this.btnPasaTodos.TabIndex = 11;
            this.btnPasaTodos.UseVisualStyleBackColor = false;
            this.btnPasaTodos.Click += new System.EventHandler(this.btnPasaTodos_Click);
            // 
            // btnRegresaUno
            // 
            this.btnRegresaUno.BackColor = System.Drawing.Color.SteelBlue;
            this.btnRegresaUno.ForeColor = System.Drawing.Color.White;
            this.btnRegresaUno.Image = global::ImprEtiquet.Properties.Resources.arrow_left___347_;
            this.btnRegresaUno.Location = new System.Drawing.Point(343, 468);
            this.btnRegresaUno.Name = "btnRegresaUno";
            this.btnRegresaUno.Size = new System.Drawing.Size(90, 35);
            this.btnRegresaUno.TabIndex = 10;
            this.btnRegresaUno.UseVisualStyleBackColor = false;
            this.btnRegresaUno.Click += new System.EventHandler(this.btnRegresaUno_Click);
            // 
            // btnPasaUno
            // 
            this.btnPasaUno.BackColor = System.Drawing.Color.SteelBlue;
            this.btnPasaUno.ForeColor = System.Drawing.Color.White;
            this.btnPasaUno.Image = ((System.Drawing.Image)(resources.GetObject("btnPasaUno.Image")));
            this.btnPasaUno.Location = new System.Drawing.Point(343, 432);
            this.btnPasaUno.Name = "btnPasaUno";
            this.btnPasaUno.Size = new System.Drawing.Size(90, 35);
            this.btnPasaUno.TabIndex = 9;
            this.btnPasaUno.UseVisualStyleBackColor = false;
            this.btnPasaUno.Click += new System.EventHandler(this.btnPasaUno_Click);
            // 
            // frmImprEt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(776, 585);
            this.Controls.Add(this.btnRegresaTodos);
            this.Controls.Add(this.btnPasaTodos);
            this.Controls.Add(this.btnRegresaUno);
            this.Controls.Add(this.btnPasaUno);
            this.Controls.Add(this.CamposParaEtiqueta);
            this.Controls.Add(this.CamposDisponibles);
            this.Controls.Add(this.malla);
            this.Controls.Add(this.ToolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmImprEt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GENERAR PLANILA PARA IMPRESION DE CODIGO DE BARRAS";
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.malla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton btnGenerar;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.DataGridView malla;
        private System.Windows.Forms.ListBox CamposDisponibles;
        private System.Windows.Forms.ListBox CamposParaEtiqueta;
        private System.Windows.Forms.Button btnRegresaTodos;
        private System.Windows.Forms.Button btnPasaTodos;
        private System.Windows.Forms.Button btnRegresaUno;
        private System.Windows.Forms.Button btnPasaUno;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}