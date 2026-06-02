namespace mntUsrs
{
    partial class FrmMedico
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMedico));
			this.mallaDaxMed = new System.Windows.Forms.DataGridView();
			this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnCambiaCeldas = new System.Windows.Forms.ToolStripButton();
			this.btnTodo = new System.Windows.Forms.ToolStripButton();
			this.btnColumna = new System.Windows.Forms.ToolStripButton();
			this.btnLinea = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnGuardar = new System.Windows.Forms.ToolStripButton();
			this.btnEliminar = new System.Windows.Forms.ToolStripButton();
			this.btnSalir = new System.Windows.Forms.ToolStripButton();
			((System.ComponentModel.ISupportInitialize)(this.mallaDaxMed)).BeginInit();
			this.ToolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mallaDaxMed
			// 
			this.mallaDaxMed.AllowUserToAddRows = false;
			this.mallaDaxMed.AllowUserToDeleteRows = false;
			this.mallaDaxMed.AllowUserToOrderColumns = true;
			this.mallaDaxMed.AllowUserToResizeRows = false;
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.Beige;
			this.mallaDaxMed.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
			this.mallaDaxMed.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.mallaDaxMed.BackgroundColor = System.Drawing.Color.White;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = System.Drawing.Color.SteelBlue;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.mallaDaxMed.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
			this.mallaDaxMed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.mallaDaxMed.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mallaDaxMed.EnableHeadersVisualStyles = false;
			this.mallaDaxMed.Location = new System.Drawing.Point(0, 46);
			this.mallaDaxMed.Name = "mallaDaxMed";
			this.mallaDaxMed.ReadOnly = true;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = System.Drawing.Color.SteelBlue;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.mallaDaxMed.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
			this.mallaDaxMed.Size = new System.Drawing.Size(885, 387);
			this.mallaDaxMed.TabIndex = 8;
			// 
			// ToolStrip1
			// 
			this.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue;
			this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ToolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCambiaCeldas,
            this.btnTodo,
            this.btnColumna,
            this.btnLinea,
            this.toolStripSeparator1,
            this.btnGuardar,
            this.btnEliminar,
            this.btnSalir});
			this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
			this.ToolStrip1.Name = "ToolStrip1";
			this.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.ToolStrip1.Size = new System.Drawing.Size(885, 46);
			this.ToolStrip1.TabIndex = 9;
			this.ToolStrip1.Text = "ToolStrip1";
			// 
			// btnCambiaCeldas
			// 
			this.btnCambiaCeldas.ForeColor = System.Drawing.Color.White;
			this.btnCambiaCeldas.Image = ((System.Drawing.Image)(resources.GetObject("btnCambiaCeldas.Image")));
			this.btnCambiaCeldas.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnCambiaCeldas.Name = "btnCambiaCeldas";
			this.btnCambiaCeldas.Size = new System.Drawing.Size(53, 43);
			this.btnCambiaCeldas.Text = "Cambio";
			this.btnCambiaCeldas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnCambiaCeldas.Click += new System.EventHandler(this.btnCambiaCeldas_Click);
			// 
			// btnTodo
			// 
			this.btnTodo.ForeColor = System.Drawing.Color.White;
			this.btnTodo.Image = ((System.Drawing.Image)(resources.GetObject("btnTodo.Image")));
			this.btnTodo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnTodo.Name = "btnTodo";
			this.btnTodo.Size = new System.Drawing.Size(38, 43);
			this.btnTodo.Text = "Todo";
			this.btnTodo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnTodo.Click += new System.EventHandler(this.btnTodo_Click);
			// 
			// btnColumna
			// 
			this.btnColumna.ForeColor = System.Drawing.Color.White;
			this.btnColumna.Image = ((System.Drawing.Image)(resources.GetObject("btnColumna.Image")));
			this.btnColumna.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnColumna.Name = "btnColumna";
			this.btnColumna.Size = new System.Drawing.Size(60, 43);
			this.btnColumna.Text = "Columna";
			this.btnColumna.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnColumna.Click += new System.EventHandler(this.btnColumna_Click);
			// 
			// btnLinea
			// 
			this.btnLinea.ForeColor = System.Drawing.Color.White;
			this.btnLinea.Image = ((System.Drawing.Image)(resources.GetObject("btnLinea.Image")));
			this.btnLinea.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnLinea.Name = "btnLinea";
			this.btnLinea.Size = new System.Drawing.Size(39, 43);
			this.btnLinea.Text = "Linea";
			this.btnLinea.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnLinea.Click += new System.EventHandler(this.btnLinea_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 46);
			// 
			// btnGuardar
			// 
			this.btnGuardar.ForeColor = System.Drawing.Color.White;
			this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
			this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(53, 43);
			this.btnGuardar.Text = "Guardar";
			this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
			// 
			// btnEliminar
			// 
			this.btnEliminar.ForeColor = System.Drawing.Color.White;
			this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
			this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEliminar.Name = "btnEliminar";
			this.btnEliminar.Size = new System.Drawing.Size(54, 43);
			this.btnEliminar.Text = "Eliminar";
			this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// btnSalir
			// 
			this.btnSalir.ForeColor = System.Drawing.Color.White;
			this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
			this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSalir.Name = "btnSalir";
			this.btnSalir.Size = new System.Drawing.Size(33, 43);
			this.btnSalir.Text = "Salir";
			this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
			// 
			// FrmMedico
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(885, 433);
			this.Controls.Add(this.mallaDaxMed);
			this.Controls.Add(this.ToolStrip1);
			this.Name = "FrmMedico";
			this.ShowIcon = false;
			this.Text = "REGISTRO DE ACCESOS AL SISTEMA -MEDICO- CONTROL DE ATENCIÓN EXTERNA";
			this.Load += new System.EventHandler(this.FrmMedico_Load);
			((System.ComponentModel.ISupportInitialize)(this.mallaDaxMed)).EndInit();
			this.ToolStrip1.ResumeLayout(false);
			this.ToolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView mallaDaxMed;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton btnCambiaCeldas;
        internal System.Windows.Forms.ToolStripButton btnTodo;
        internal System.Windows.Forms.ToolStripButton btnColumna;
        internal System.Windows.Forms.ToolStripButton btnLinea;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton btnGuardar;
        internal System.Windows.Forms.ToolStripButton btnEliminar;
        internal System.Windows.Forms.ToolStripButton btnSalir;
    }
}