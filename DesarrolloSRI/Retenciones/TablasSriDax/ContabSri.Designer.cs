
namespace IvaRett
{
    partial class ContabSri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContabSri));
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bntCancelar = new System.Windows.Forms.ToolStripButton();
            this.btnGrabar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.chkValidos = new System.Windows.Forms.CheckBox();
            this.malla = new System.Windows.Forms.DataGridView();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.malla)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bntCancelar,
            this.btnGrabar,
            this.btnSalir});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(800, 37);
            this.ToolStrip1.TabIndex = 3;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // bntCancelar
            // 
            this.bntCancelar.ForeColor = System.Drawing.Color.White;
            this.bntCancelar.Image = ((System.Drawing.Image)(resources.GetObject("bntCancelar.Image")));
            this.bntCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bntCancelar.Name = "bntCancelar";
            this.bntCancelar.Size = new System.Drawing.Size(87, 34);
            this.bntCancelar.Text = "Cancelar";
            this.bntCancelar.Click += new System.EventHandler(this.bntCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.ForeColor = System.Drawing.Color.White;
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(76, 34);
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(63, 34);
            this.btnSalir.Text = "Salir";
            // 
            // chkValidos
            // 
            this.chkValidos.AutoSize = true;
            this.chkValidos.BackColor = System.Drawing.Color.SteelBlue;
            this.chkValidos.Checked = true;
            this.chkValidos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkValidos.ForeColor = System.Drawing.Color.White;
            this.chkValidos.Location = new System.Drawing.Point(533, 12);
            this.chkValidos.Name = "chkValidos";
            this.chkValidos.Size = new System.Drawing.Size(133, 17);
            this.chkValidos.TabIndex = 5;
            this.chkValidos.Text = "Solo válidos a la fecha";
            this.chkValidos.UseVisualStyleBackColor = false;
            // 
            // malla
            // 
            this.malla.AllowUserToAddRows = false;
            this.malla.AllowUserToDeleteRows = false;
            this.malla.AllowUserToResizeRows = false;
            this.malla.BackgroundColor = System.Drawing.Color.White;
            this.malla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.malla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.malla.GridColor = System.Drawing.Color.Silver;
            this.malla.Location = new System.Drawing.Point(0, 0);
            this.malla.Name = "malla";
            this.malla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.malla.Size = new System.Drawing.Size(800, 450);
            this.malla.TabIndex = 4;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.SteelBlue;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(655, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(133, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Solo válidos a la fecha";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ContabSri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.chkValidos);
            this.Controls.Add(this.malla);
            this.Name = "ContabSri";
            this.Text = "ContabSri";
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.malla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton bntCancelar;
        internal System.Windows.Forms.ToolStripButton btnGrabar;
        internal System.Windows.Forms.ToolStripButton btnSalir;
        internal System.Windows.Forms.CheckBox chkValidos;
        internal System.Windows.Forms.DataGridView malla;
        internal System.Windows.Forms.CheckBox checkBox1;
    }
}