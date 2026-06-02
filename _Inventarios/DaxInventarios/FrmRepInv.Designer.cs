namespace DaxInvent
{
    partial class FrmRepInv
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripButton7,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(233, 405);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStripButton2.ForeColor = System.Drawing.Color.White;
            this.toolStripButton2.Image = global::ArtInvent.Properties.Resources.catalogo1;
            this.toolStripButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(230, 52);
            this.toolStripButton2.Text = "Catálogo de artículos";
            this.toolStripButton2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripButton2.ToolTipText = "Lista de artículos con existencias y costos";
            this.toolStripButton2.Click += new System.EventHandler(this.btnCatalogo_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStripButton3.ForeColor = System.Drawing.Color.White;
            this.toolStripButton3.Image = global::ArtInvent.Properties.Resources.Transacciones2;
            this.toolStripButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(230, 52);
            this.toolStripButton3.Text = "Lista de transacciones";
            this.toolStripButton3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripButton3.ToolTipText = "Lista de transacciones por artículo y fechas";
            this.toolStripButton3.Click += new System.EventHandler(this.ListaTransacciones_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStripButton4.ForeColor = System.Drawing.Color.White;
            this.toolStripButton4.Image = global::ArtInvent.Properties.Resources.kardex2;
            this.toolStripButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(230, 52);
            this.toolStripButton4.Text = "Kardex de artículos";
            this.toolStripButton4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripButton4.ToolTipText = "Lista de transacciones por artículo y fechas";
            this.toolStripButton4.Click += new System.EventHandler(this.btnKardex_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStripButton5.ForeColor = System.Drawing.Color.White;
            this.toolStripButton5.Image = global::ArtInvent.Properties.Resources.transacciones3;
            this.toolStripButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(230, 52);
            this.toolStripButton5.Text = "Resumen de movimientos";
            this.toolStripButton5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripButton5.ToolTipText = "Lista de transacciones por artículo y fechas";
            this.toolStripButton5.Click += new System.EventHandler(this.btnResumen_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStripButton6.ForeColor = System.Drawing.Color.White;
            this.toolStripButton6.Image = global::ArtInvent.Properties.Resources.maximosMinimos;
            this.toolStripButton6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(230, 52);
            this.toolStripButton6.Text = "Máximos y Mínimos";
            this.toolStripButton6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripButton6.ToolTipText = "Lista de transacciones por artículo y fechas";
            this.toolStripButton6.Click += new System.EventHandler(this.MaximosMinimos_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStripButton7.ForeColor = System.Drawing.Color.White;
            this.toolStripButton7.Image = global::ArtInvent.Properties.Resources.tiempoAntiguedad;
            this.toolStripButton7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(230, 52);
            this.toolStripButton7.Text = "Antigüedad de inventario";
            this.toolStripButton7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripButton7.ToolTipText = "Lista de transacciones por artículo y fechas";
            this.toolStripButton7.Click += new System.EventHandler(this.btnAntigdad_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.ForeColor = System.Drawing.Color.White;
            this.toolStripButton1.Image = global::ArtInvent.Properties.Resources.Salir;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(52, 52);
            this.toolStripButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripButton1.ToolTipText = "Lista de transacciones por artículo y fechas";
            this.toolStripButton1.Click += new System.EventHandler(this.btnSalida_Click);
            // 
            // FrmRepInv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(226, 405);
            this.ControlBox = false;
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmRepInv";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REPORTES/ CONSULTAS DE INVENTARIO";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
    }
}