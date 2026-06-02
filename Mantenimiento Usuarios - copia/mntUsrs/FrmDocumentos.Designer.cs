namespace mntUsrs
{
    partial class FrmDocumentos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDocumentos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDocIndividual = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLinea = new System.Windows.Forms.ToolStripButton();
            this.btnColumna = new System.Windows.Forms.ToolStripButton();
            this.btnTodo = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.tnCambia = new System.Windows.Forms.ToolStripButton();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mallaDocIndividual = new System.Windows.Forms.DataGridView();
            this.mallaGrupoDocumentos = new System.Windows.Forms.DataGridView();
            this.ToolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mallaDocIndividual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mallaGrupoDocumentos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(33, 52);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(53, 52);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnDocIndividual
            // 
            this.btnDocIndividual.ForeColor = System.Drawing.Color.White;
            this.btnDocIndividual.Image = ((System.Drawing.Image)(resources.GetObject("btnDocIndividual.Image")));
            this.btnDocIndividual.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDocIndividual.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDocIndividual.Name = "btnDocIndividual";
            this.btnDocIndividual.Size = new System.Drawing.Size(140, 52);
            this.btnDocIndividual.Text = "PorDocumento";
            this.btnDocIndividual.ToolTipText = "Autorizaciones a documentos individualmente";
            this.btnDocIndividual.Click += new System.EventHandler(this.btnIndividual_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btnLinea
            // 
            this.btnLinea.ForeColor = System.Drawing.Color.White;
            this.btnLinea.Image = ((System.Drawing.Image)(resources.GetObject("btnLinea.Image")));
            this.btnLinea.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLinea.Name = "btnLinea";
            this.btnLinea.Size = new System.Drawing.Size(39, 52);
            this.btnLinea.Text = "Linea";
            this.btnLinea.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLinea.Click += new System.EventHandler(this.btnColumna_Click);
            // 
            // btnColumna
            // 
            this.btnColumna.ForeColor = System.Drawing.Color.White;
            this.btnColumna.Image = ((System.Drawing.Image)(resources.GetObject("btnColumna.Image")));
            this.btnColumna.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnColumna.Name = "btnColumna";
            this.btnColumna.Size = new System.Drawing.Size(60, 52);
            this.btnColumna.Text = "Columna";
            this.btnColumna.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnColumna.Click += new System.EventHandler(this.btnColumna_Click);
            // 
            // btnTodo
            // 
            this.btnTodo.ForeColor = System.Drawing.Color.White;
            this.btnTodo.Image = ((System.Drawing.Image)(resources.GetObject("btnTodo.Image")));
            this.btnTodo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTodo.Name = "btnTodo";
            this.btnTodo.Size = new System.Drawing.Size(38, 52);
            this.btnTodo.Text = "Todo";
            this.btnTodo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTodo.Click += new System.EventHandler(this.btnTodo_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(54, 52);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tnCambia
            // 
            this.tnCambia.ForeColor = System.Drawing.Color.White;
            this.tnCambia.Image = ((System.Drawing.Image)(resources.GetObject("tnCambia.Image")));
            this.tnCambia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tnCambia.Name = "tnCambia";
            this.tnCambia.Size = new System.Drawing.Size(53, 52);
            this.tnCambia.Text = "Cambio";
            this.tnCambia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tnCambia.Click += new System.EventHandler(this.tnCambia_Click);
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
            this.toolStripSeparator2,
            this.btnDocIndividual,
            this.toolStripSeparator1,
            this.btnGuardar,
            this.btnEliminar,
            this.btnSalir});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ToolStrip1.Size = new System.Drawing.Size(800, 55);
            this.ToolStrip1.TabIndex = 11;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.mallaDocIndividual, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mallaGrupoDocumentos, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 55);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 395);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // mallaDocIndividual
            // 
            this.mallaDocIndividual.AllowUserToAddRows = false;
            this.mallaDocIndividual.AllowUserToDeleteRows = false;
            this.mallaDocIndividual.AllowUserToOrderColumns = true;
            this.mallaDocIndividual.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.mallaDocIndividual.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.mallaDocIndividual.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.mallaDocIndividual.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mallaDocIndividual.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.mallaDocIndividual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mallaDocIndividual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mallaDocIndividual.EnableHeadersVisualStyles = false;
            this.mallaDocIndividual.Location = new System.Drawing.Point(403, 3);
            this.mallaDocIndividual.Name = "mallaDocIndividual";
            this.mallaDocIndividual.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mallaDocIndividual.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.mallaDocIndividual.Size = new System.Drawing.Size(394, 389);
            this.mallaDocIndividual.TabIndex = 3;
            this.mallaDocIndividual.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mallaDocIndividual_KeyDown);
            // 
            // mallaGrupoDocumentos
            // 
            this.mallaGrupoDocumentos.AllowUserToAddRows = false;
            this.mallaGrupoDocumentos.AllowUserToDeleteRows = false;
            this.mallaGrupoDocumentos.AllowUserToOrderColumns = true;
            this.mallaGrupoDocumentos.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Beige;
            this.mallaGrupoDocumentos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.mallaGrupoDocumentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.mallaGrupoDocumentos.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mallaGrupoDocumentos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.mallaGrupoDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mallaGrupoDocumentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mallaGrupoDocumentos.EnableHeadersVisualStyles = false;
            this.mallaGrupoDocumentos.Location = new System.Drawing.Point(3, 3);
            this.mallaGrupoDocumentos.Name = "mallaGrupoDocumentos";
            this.mallaGrupoDocumentos.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mallaGrupoDocumentos.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.mallaGrupoDocumentos.Size = new System.Drawing.Size(394, 389);
            this.mallaGrupoDocumentos.TabIndex = 2;
            this.mallaGrupoDocumentos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mallaGrupoDocumentos_KeyDown);
            // 
            // FrmDocumentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ToolStrip1);
            this.Name = "FrmDocumentos";
            this.ShowIcon = false;
            this.Text = "REGISTRO DE ACCESO A DOCUMENTOS DEL SISTEMA";
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mallaDocIndividual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mallaGrupoDocumentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStripButton btnSalir;
        internal System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton btnDocIndividual;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        internal System.Windows.Forms.ToolStripButton btnLinea;
        internal System.Windows.Forms.ToolStripButton btnColumna;
        internal System.Windows.Forms.ToolStripButton btnTodo;
        internal System.Windows.Forms.ToolStripButton btnEliminar;
        internal System.Windows.Forms.ToolStripButton tnCambia;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView mallaDocIndividual;
        private System.Windows.Forms.DataGridView mallaGrupoDocumentos;
    }
}