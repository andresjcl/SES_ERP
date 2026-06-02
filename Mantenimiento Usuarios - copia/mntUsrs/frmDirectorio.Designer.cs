namespace mntUsrs
{
    partial class frmDirectorio
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDirectorio));
            this.mallaDir = new System.Windows.Forms.DataGridView();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tnCambia = new System.Windows.Forms.ToolStripButton();
            this.btnTodo = new System.Windows.Forms.ToolStripButton();
            this.btnColumna = new System.Windows.Forms.ToolStripButton();
            this.btnLinea = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.mallaDir)).BeginInit();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mallaDir
            // 
            this.mallaDir.AllowUserToAddRows = false;
            this.mallaDir.AllowUserToDeleteRows = false;
            this.mallaDir.AllowUserToOrderColumns = true;
            this.mallaDir.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.mallaDir.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.mallaDir.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.mallaDir.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mallaDir.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.mallaDir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mallaDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mallaDir.EnableHeadersVisualStyles = false;
            this.mallaDir.Location = new System.Drawing.Point(0, 46);
            this.mallaDir.Name = "mallaDir";
            this.mallaDir.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mallaDir.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.mallaDir.Size = new System.Drawing.Size(809, 388);
            this.mallaDir.TabIndex = 5;
            this.mallaDir.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mallaDir_KeyDown);
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tnCambia,
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
            this.ToolStrip1.Size = new System.Drawing.Size(809, 46);
            this.ToolStrip1.TabIndex = 6;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // tnCambia
            // 
            this.tnCambia.ForeColor = System.Drawing.Color.White;
            this.tnCambia.Image = ((System.Drawing.Image)(resources.GetObject("tnCambia.Image")));
            this.tnCambia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tnCambia.Name = "tnCambia";
            this.tnCambia.Size = new System.Drawing.Size(53, 43);
            this.tnCambia.Text = "Cambio";
            this.tnCambia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tnCambia.Click += new System.EventHandler(this.tnCambia_Click);
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
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
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
            // frmDirectorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 434);
            this.Controls.Add(this.mallaDir);
            this.Controls.Add(this.ToolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDirectorio";
            this.ShowIcon = false;
            this.Text = "REGISTRO DE AUTORIZACIONES DE ACCESO AL DIRECTORIO";
            ((System.ComponentModel.ISupportInitialize)(this.mallaDir)).EndInit();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView mallaDir;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton tnCambia;
        internal System.Windows.Forms.ToolStripButton btnTodo;
        internal System.Windows.Forms.ToolStripButton btnLinea;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton btnGuardar;
        internal System.Windows.Forms.ToolStripButton btnSalir;
        internal System.Windows.Forms.ToolStripButton btnColumna;
        internal System.Windows.Forms.ToolStripButton btnEliminar;
    }
}