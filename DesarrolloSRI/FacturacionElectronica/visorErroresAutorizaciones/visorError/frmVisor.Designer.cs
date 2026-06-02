namespace DaxValDocElec
{
    partial class frmVisor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.Imprimir = new System.Windows.Forms.ToolStripButton();
            this.btnExportar = new System.Windows.Forms.ToolStripSplitButton();
            this.btnexcel = new System.Windows.Forms.ToolStripMenuItem();
            this.btnpdf = new System.Windows.Forms.ToolStripMenuItem();
            this.btnword = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.mallaError = new System.Windows.Forms.DataGridView();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mallaError)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.AutoSize = false;
            this.menu.BackColor = System.Drawing.Color.SteelBlue;
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Imprimir,
            this.btnExportar,
            this.toolStripSeparator1,
            this.toolStripButton1});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1193, 55);
            this.menu.TabIndex = 1;
            this.menu.Text = "toolStrip1";
            // 
            // Imprimir
            // 
            this.Imprimir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Imprimir.Image = ((System.Drawing.Image)(resources.GetObject("Imprimir.Image")));
            this.Imprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Imprimir.Name = "Imprimir";
            this.Imprimir.Size = new System.Drawing.Size(70, 52);
            this.Imprimir.Text = "Imprimir";
            this.Imprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Imprimir.ToolTipText = "Enviar a la impresora";
            this.Imprimir.Click += new System.EventHandler(this.Imprimir_Click);
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
            this.btnExportar.Size = new System.Drawing.Size(84, 52);
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnexcel
            // 
            this.btnexcel.Image = ((System.Drawing.Image)(resources.GetObject("btnexcel.Image")));
            this.btnexcel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnexcel.Name = "btnexcel";
            this.btnexcel.Size = new System.Drawing.Size(200, 26);
            this.btnexcel.Text = "Exportar a Excel";
            this.btnexcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnexcel.Click += new System.EventHandler(this.btnexcel_Click);
            // 
            // btnpdf
            // 
            this.btnpdf.Image = ((System.Drawing.Image)(resources.GetObject("btnpdf.Image")));
            this.btnpdf.Name = "btnpdf";
            this.btnpdf.Size = new System.Drawing.Size(200, 26);
            this.btnpdf.Text = "Exportar a Pdf";
            this.btnpdf.Click += new System.EventHandler(this.btnpdf_Click);
            // 
            // btnword
            // 
            this.btnword.Image = ((System.Drawing.Image)(resources.GetObject("btnword.Image")));
            this.btnword.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnword.Name = "btnword";
            this.btnword.Size = new System.Drawing.Size(200, 26);
            this.btnword.Text = "Exportar a Word";
            this.btnword.Click += new System.EventHandler(this.btnword_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.ForeColor = System.Drawing.Color.White;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(42, 52);
            this.toolStripButton1.Text = "Salir";
            this.toolStripButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // mallaError
            // 
            this.mallaError.AllowUserToAddRows = false;
            this.mallaError.AllowUserToDeleteRows = false;
            this.mallaError.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.mallaError.BackgroundColor = System.Drawing.Color.White;
            this.mallaError.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mallaError.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.mallaError.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mallaError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mallaError.EnableHeadersVisualStyles = false;
            this.mallaError.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mallaError.Location = new System.Drawing.Point(0, 55);
            this.mallaError.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mallaError.Name = "mallaError";
            this.mallaError.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mallaError.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.mallaError.RowHeadersWidth = 51;
            this.mallaError.Size = new System.Drawing.Size(1193, 333);
            this.mallaError.TabIndex = 2;
            // 
            // frmVisor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 388);
            this.Controls.Add(this.mallaError);
            this.Controls.Add(this.menu);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmVisor";
            this.ShowIcon = false;
            this.Text = "COMPROBANTES ELECTRONICOS - VISOR DE ERRRORES";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mallaError)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton Imprimir;
        private System.Windows.Forms.ToolStripSplitButton btnExportar;
        private System.Windows.Forms.ToolStripMenuItem btnexcel;
        private System.Windows.Forms.ToolStripMenuItem btnpdf;
        private System.Windows.Forms.ToolStripMenuItem btnword;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridView mallaError;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}