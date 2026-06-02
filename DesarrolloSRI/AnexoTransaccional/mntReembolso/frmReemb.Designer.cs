namespace mntReembolso
{
    partial class frmReemb
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReemb));
            this.malla = new System.Windows.Forms.DataGridView();
            this.ToolStrip4 = new System.Windows.Forms.ToolStrip();
            this.labTitulo = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCerrar = new System.Windows.Forms.ToolStripButton();
            this.btnGraba = new System.Windows.Forms.ToolStripButton();
            this.btnContinuar = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labTotalGeneral = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labTotalIce = new System.Windows.Forms.Label();
            this.labTotIva = new System.Windows.Forms.Label();
            this.labTotIvaNoGrabado = new System.Windows.Forms.Label();
            this.labTotalIvaExcento = new System.Windows.Forms.Label();
            this.labTotIvaGrabado = new System.Windows.Forms.Label();
            this.labTotIvaCero = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.malla)).BeginInit();
            this.ToolStrip4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // malla
            // 
            this.malla.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.malla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.malla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.malla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.malla.Location = new System.Drawing.Point(0, 46);
            this.malla.Name = "malla";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.malla.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.malla.RowHeadersWidth = 25;
            this.malla.Size = new System.Drawing.Size(952, 223);
            this.malla.TabIndex = 1;
            this.malla.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellEndEdit);
            this.malla.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
            // 
            // ToolStrip4
            // 
            this.ToolStrip4.BackColor = System.Drawing.Color.SteelBlue;
            this.ToolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip4.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ToolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labTitulo,
            this.toolStripSeparator1,
            this.btnCerrar,
            this.btnGraba,
            this.btnContinuar});
            this.ToolStrip4.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ToolStrip4.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip4.Name = "ToolStrip4";
            this.ToolStrip4.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStrip4.Size = new System.Drawing.Size(952, 46);
            this.ToolStrip4.Stretch = true;
            this.ToolStrip4.TabIndex = 3;
            this.ToolStrip4.Text = "ToolStrip4";
            // 
            // labTitulo
            // 
            this.labTitulo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.labTitulo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTitulo.ForeColor = System.Drawing.Color.White;
            this.labTitulo.Name = "labTitulo";
            this.labTitulo.Size = new System.Drawing.Size(0, 43);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 46);
            // 
            // btnCerrar
            // 
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.RightToLeftAutoMirrorImage = true;
            this.btnCerrar.Size = new System.Drawing.Size(43, 43);
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCerrar.ToolTipText = "Cerrar la información actual";
            this.btnCerrar.Visible = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnGraba
            // 
            this.btnGraba.ForeColor = System.Drawing.Color.White;
            this.btnGraba.Image = ((System.Drawing.Image)(resources.GetObject("btnGraba.Image")));
            this.btnGraba.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGraba.Name = "btnGraba";
            this.btnGraba.Size = new System.Drawing.Size(46, 43);
            this.btnGraba.Text = "Grabar";
            this.btnGraba.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGraba.ToolTipText = "Guardar la información actual";
            this.btnGraba.Visible = false;
            this.btnGraba.Click += new System.EventHandler(this.btnGraba_Click);
            // 
            // btnContinuar
            // 
            this.btnContinuar.ForeColor = System.Drawing.Color.White;
            this.btnContinuar.Image = ((System.Drawing.Image)(resources.GetObject("btnContinuar.Image")));
            this.btnContinuar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(64, 43);
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnContinuar.ToolTipText = "Guardar la información actual";
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.labTotalGeneral);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labTotalIce);
            this.panel1.Controls.Add(this.labTotIva);
            this.panel1.Controls.Add(this.labTotIvaNoGrabado);
            this.panel1.Controls.Add(this.labTotalIvaExcento);
            this.panel1.Controls.Add(this.labTotIvaGrabado);
            this.panel1.Controls.Add(this.labTotIvaCero);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 269);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(952, 34);
            this.panel1.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(526, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Total ICE:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(526, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Total IVA:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(250, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Total base no graba iva:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(250, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Total base grabada iva:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Total base excento iva:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Total base iva cero:";
            // 
            // labTotalGeneral
            // 
            this.labTotalGeneral.ForeColor = System.Drawing.Color.White;
            this.labTotalGeneral.Location = new System.Drawing.Point(845, 15);
            this.labTotalGeneral.Name = "labTotalGeneral";
            this.labTotalGeneral.Size = new System.Drawing.Size(70, 13);
            this.labTotalGeneral.TabIndex = 7;
            this.labTotalGeneral.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(690, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Total documentos reembolso :";
            // 
            // labTotalIce
            // 
            this.labTotalIce.ForeColor = System.Drawing.Color.White;
            this.labTotalIce.Location = new System.Drawing.Point(584, 15);
            this.labTotalIce.Name = "labTotalIce";
            this.labTotalIce.Size = new System.Drawing.Size(70, 13);
            this.labTotalIce.TabIndex = 5;
            this.labTotalIce.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labTotIva
            // 
            this.labTotIva.ForeColor = System.Drawing.Color.White;
            this.labTotIva.Location = new System.Drawing.Point(583, 2);
            this.labTotIva.Name = "labTotIva";
            this.labTotIva.Size = new System.Drawing.Size(70, 13);
            this.labTotIva.TabIndex = 4;
            this.labTotIva.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labTotIvaNoGrabado
            // 
            this.labTotIvaNoGrabado.ForeColor = System.Drawing.Color.White;
            this.labTotIvaNoGrabado.Location = new System.Drawing.Point(374, 17);
            this.labTotIvaNoGrabado.Name = "labTotIvaNoGrabado";
            this.labTotIvaNoGrabado.Size = new System.Drawing.Size(70, 13);
            this.labTotIvaNoGrabado.TabIndex = 3;
            this.labTotIvaNoGrabado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labTotalIvaExcento
            // 
            this.labTotalIvaExcento.ForeColor = System.Drawing.Color.White;
            this.labTotalIvaExcento.Location = new System.Drawing.Point(135, 17);
            this.labTotalIvaExcento.Name = "labTotalIvaExcento";
            this.labTotalIvaExcento.Size = new System.Drawing.Size(70, 13);
            this.labTotalIvaExcento.TabIndex = 2;
            this.labTotalIvaExcento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labTotIvaGrabado
            // 
            this.labTotIvaGrabado.ForeColor = System.Drawing.Color.White;
            this.labTotIvaGrabado.Location = new System.Drawing.Point(374, 1);
            this.labTotIvaGrabado.Name = "labTotIvaGrabado";
            this.labTotIvaGrabado.Size = new System.Drawing.Size(70, 13);
            this.labTotIvaGrabado.TabIndex = 1;
            this.labTotIvaGrabado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labTotIvaCero
            // 
            this.labTotIvaCero.ForeColor = System.Drawing.Color.White;
            this.labTotIvaCero.Location = new System.Drawing.Point(135, 2);
            this.labTotIvaCero.Name = "labTotIvaCero";
            this.labTotIvaCero.Size = new System.Drawing.Size(70, 13);
            this.labTotIvaCero.TabIndex = 0;
            this.labTotIvaCero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmReemb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 303);
            this.Controls.Add(this.malla);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ToolStrip4);
            this.Name = "frmReemb";
            this.Text = "Mantenimiento documentos de reembolsos";
            this.Load += new System.EventHandler(this.frmReemb_Load);
            ((System.ComponentModel.ISupportInitialize)(this.malla)).EndInit();
            this.ToolStrip4.ResumeLayout(false);
            this.ToolStrip4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView malla;
        internal System.Windows.Forms.ToolStrip ToolStrip4;
        internal System.Windows.Forms.ToolStripButton btnCerrar;
        internal System.Windows.Forms.ToolStripButton btnGraba;
        private System.Windows.Forms.ToolStripLabel labTitulo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labTotIva;
        private System.Windows.Forms.Label labTotIvaNoGrabado;
        private System.Windows.Forms.Label labTotalIvaExcento;
        private System.Windows.Forms.Label labTotIvaGrabado;
        private System.Windows.Forms.Label labTotIvaCero;
        private System.Windows.Forms.Label labTotalIce;
        private System.Windows.Forms.Label labTotalGeneral;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ToolStripButton btnContinuar;
    }
}