namespace TekFormDax
{
    partial class AcercaDeTekForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AcercaDeTekForm));
            this.Frame1 = new System.Windows.Forms.Panel();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.imgLogo = new System.Windows.Forms.PictureBox();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Frame1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // Frame1
            // 
            this.Frame1.BackColor = System.Drawing.Color.White;
            this.Frame1.Controls.Add(this.Label2);
            this.Frame1.Controls.Add(this.Label1);
            this.Frame1.Controls.Add(this.lblProductName);
            this.Frame1.Controls.Add(this.lblVersion);
            this.Frame1.Controls.Add(this.lblCopyright);
            this.Frame1.Controls.Add(this.imgLogo);
            this.Frame1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Frame1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Frame1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Frame1.Location = new System.Drawing.Point(0, 0);
            this.Frame1.Name = "Frame1";
            this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Frame1.Size = new System.Drawing.Size(464, 264);
            this.Frame1.TabIndex = 1;
            this.Frame1.Click += new System.EventHandler(this.Frame1_Click);
            this.Frame1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Frame1_MouseClick);
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label2.Location = new System.Drawing.Point(32, 235);
            this.Label2.Name = "Label2";
            this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label2.Size = new System.Drawing.Size(413, 20);
            this.Label2.TabIndex = 6;
            this.Label2.Text = "Prohibida la reproducción total o parcial sin el consentimiento  escrito del auto" +
    "r";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(155, 147);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(297, 49);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "Generador de formatos para impresión de formularios y documentos de sistemas DAXS" +
    "OF";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.BackColor = System.Drawing.Color.Transparent;
            this.lblProductName.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblProductName.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblProductName.Location = new System.Drawing.Point(156, 30);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblProductName.Size = new System.Drawing.Size(263, 56);
            this.lblProductName.TabIndex = 4;
            this.lblProductName.Text = "TEKFORM";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblVersion.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblVersion.Location = new System.Drawing.Point(236, 86);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblVersion.Size = new System.Drawing.Size(89, 19);
            this.lblVersion.TabIndex = 2;
            this.lblVersion.Text = "Version 21";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCopyright
            // 
            this.lblCopyright.BackColor = System.Drawing.Color.Transparent;
            this.lblCopyright.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblCopyright.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCopyright.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCopyright.Location = new System.Drawing.Point(144, 203);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCopyright.Size = new System.Drawing.Size(318, 24);
            this.lblCopyright.TabIndex = 1;
            this.lblCopyright.Text = "Derechos reservados 2021 por DAXSOF";
            this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // imgLogo
            // 
            this.imgLogo.Cursor = System.Windows.Forms.Cursors.Default;
            this.imgLogo.Image = ((System.Drawing.Image)(resources.GetObject("imgLogo.Image")));
            this.imgLogo.Location = new System.Drawing.Point(8, 16);
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Size = new System.Drawing.Size(142, 165);
            this.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLogo.TabIndex = 7;
            this.imgLogo.TabStop = false;
            // 
            // AcercaDeTekForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 264);
            this.ControlBox = false;
            this.Controls.Add(this.Frame1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "AcercaDeTekForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AcercaDeTekForm_KeyPress);
            this.Frame1.ResumeLayout(false);
            this.Frame1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel Frame1;
        public System.Windows.Forms.Label Label2;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Label lblProductName;
        public System.Windows.Forms.Label lblVersion;
        public System.Windows.Forms.Label lblCopyright;
        public System.Windows.Forms.PictureBox imgLogo;
        public System.Windows.Forms.ToolTip ToolTip1;
    }
}

