
namespace CierreDeCaja
{
    partial class frmResumenGeneral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResumenGeneral));
            this.Grupo = new System.Windows.Forms.GroupBox();
            this.txtFechaAl = new System.Windows.Forms.DateTimePicker();
            this.txtFechaDel = new System.Windows.Forms.DateTimePicker();
            this.ReportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnOpciones = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnResumenGeneral = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGenerarIngresoBanco = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.HelpProvider1 = new System.Windows.Forms.HelpProvider();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.GrupoRecumenGenerarl = new System.Windows.Forms.GroupBox();
            this.txtfecha = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.Label();
            this.cmbConepto = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCtaBanco = new System.Windows.Forms.TextBox();
            this.cmbDocumento = new System.Windows.Forms.ComboBox();
            this.btnBuscaBanco = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNombreBanco = new System.Windows.Forms.TextBox();
            this.txtCodBanco = new System.Windows.Forms.TextBox();
            this.labNombreBanco = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Grupo.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.GrupoRecumenGenerarl.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grupo
            // 
            this.Grupo.Controls.Add(this.txtFechaAl);
            this.Grupo.Controls.Add(this.txtFechaDel);
            this.Grupo.ForeColor = System.Drawing.Color.White;
            this.Grupo.Location = new System.Drawing.Point(1, 7);
            this.Grupo.Name = "Grupo";
            this.Grupo.Size = new System.Drawing.Size(257, 62);
            this.Grupo.TabIndex = 0;
            this.Grupo.TabStop = false;
            this.Grupo.Text = "Rango de Fechas:";
            // 
            // txtFechaAl
            // 
            this.txtFechaAl.CustomFormat = "dd/MM/yyyy HH:mm";
            this.txtFechaAl.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFechaAl.Location = new System.Drawing.Point(135, 24);
            this.txtFechaAl.Name = "txtFechaAl";
            this.txtFechaAl.Size = new System.Drawing.Size(100, 20);
            this.txtFechaAl.TabIndex = 17;
            // 
            // txtFechaDel
            // 
            this.txtFechaDel.CustomFormat = "dd/MM/yyyy HH:mm";
            this.txtFechaDel.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFechaDel.Location = new System.Drawing.Point(30, 23);
            this.txtFechaDel.Name = "txtFechaDel";
            this.txtFechaDel.Size = new System.Drawing.Size(90, 20);
            this.txtFechaDel.TabIndex = 16;
            // 
            // ReportViewer1
            // 
            this.ReportViewer1.AutoSize = true;
            this.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportViewer1.DocumentMapWidth = 71;
            this.ReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.ReportViewer1.Name = "ReportViewer1";
            this.ReportViewer1.Size = new System.Drawing.Size(555, 443);
            this.ReportViewer1.TabIndex = 0;
            // 
            // btnOpciones
            // 
            this.btnOpciones.ForeColor = System.Drawing.Color.White;
            this.btnOpciones.Image = ((System.Drawing.Image)(resources.GetObject("btnOpciones.Image")));
            this.btnOpciones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpciones.Name = "btnOpciones";
            this.btnOpciones.Size = new System.Drawing.Size(89, 32);
            this.btnOpciones.Text = "Opciones";
            this.btnOpciones.Click += new System.EventHandler(this.btnOpciones_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(61, 32);
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.BackColor = System.Drawing.Color.DimGray;
            this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpciones,
            this.BtnResumenGeneral,
            this.ToolStripSeparator6,
            this.btnGenerarIngresoBanco,
            this.ToolStripSeparator3,
            this.btnSalir});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(822, 35);
            this.ToolStrip1.TabIndex = 2;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // BtnResumenGeneral
            // 
            this.BtnResumenGeneral.ForeColor = System.Drawing.Color.White;
            this.BtnResumenGeneral.Image = ((System.Drawing.Image)(resources.GetObject("BtnResumenGeneral.Image")));
            this.BtnResumenGeneral.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnResumenGeneral.Name = "BtnResumenGeneral";
            this.BtnResumenGeneral.Size = new System.Drawing.Size(140, 32);
            this.BtnResumenGeneral.Text = "Actualizar resumen";
            this.BtnResumenGeneral.ToolTipText = "Cuadre Caja General";
            this.BtnResumenGeneral.Click += new System.EventHandler(this.BtnResumenGeneral_Click);
            // 
            // ToolStripSeparator6
            // 
            this.ToolStripSeparator6.ForeColor = System.Drawing.Color.White;
            this.ToolStripSeparator6.Name = "ToolStripSeparator6";
            this.ToolStripSeparator6.Size = new System.Drawing.Size(6, 35);
            // 
            // btnGenerarIngresoBanco
            // 
            this.btnGenerarIngresoBanco.ForeColor = System.Drawing.Color.White;
            this.btnGenerarIngresoBanco.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerarIngresoBanco.Image")));
            this.btnGenerarIngresoBanco.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGenerarIngresoBanco.Name = "btnGenerarIngresoBanco";
            this.btnGenerarIngresoBanco.Size = new System.Drawing.Size(130, 32);
            this.btnGenerarIngresoBanco.Text = "GeneraIngrBanco";
            this.btnGenerarIngresoBanco.ToolTipText = "Generar Ingreso Banco";
            this.btnGenerarIngresoBanco.Click += new System.EventHandler(this.btnGenerarIngresoBanco_Click);
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.ForeColor = System.Drawing.Color.White;
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(6, 35);
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SplitContainer1.Location = new System.Drawing.Point(0, 35);
            this.SplitContainer1.Name = "SplitContainer1";
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Gray;
            this.SplitContainer1.Panel1.Controls.Add(this.GrupoRecumenGenerarl);
            this.SplitContainer1.Panel1.Controls.Add(this.Grupo);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.ReportViewer1);
            this.SplitContainer1.Size = new System.Drawing.Size(822, 443);
            this.SplitContainer1.SplitterDistance = 263;
            this.SplitContainer1.TabIndex = 3;
            // 
            // GrupoRecumenGenerarl
            // 
            this.GrupoRecumenGenerarl.Controls.Add(this.txtfecha);
            this.GrupoRecumenGenerarl.Controls.Add(this.label11);
            this.GrupoRecumenGenerarl.Controls.Add(this.txtValor);
            this.GrupoRecumenGenerarl.Controls.Add(this.cmbConepto);
            this.GrupoRecumenGenerarl.Controls.Add(this.label2);
            this.GrupoRecumenGenerarl.Controls.Add(this.txtCtaBanco);
            this.GrupoRecumenGenerarl.Controls.Add(this.cmbDocumento);
            this.GrupoRecumenGenerarl.Controls.Add(this.btnBuscaBanco);
            this.GrupoRecumenGenerarl.Controls.Add(this.label7);
            this.GrupoRecumenGenerarl.Controls.Add(this.txtNombreBanco);
            this.GrupoRecumenGenerarl.Controls.Add(this.txtCodBanco);
            this.GrupoRecumenGenerarl.Controls.Add(this.labNombreBanco);
            this.GrupoRecumenGenerarl.Controls.Add(this.Label15);
            this.GrupoRecumenGenerarl.Controls.Add(this.label1);
            this.GrupoRecumenGenerarl.ForeColor = System.Drawing.Color.White;
            this.GrupoRecumenGenerarl.Location = new System.Drawing.Point(8, 75);
            this.GrupoRecumenGenerarl.Name = "GrupoRecumenGenerarl";
            this.GrupoRecumenGenerarl.Size = new System.Drawing.Size(252, 218);
            this.GrupoRecumenGenerarl.TabIndex = 21;
            this.GrupoRecumenGenerarl.TabStop = false;
            this.GrupoRecumenGenerarl.Text = "Ingreso a bancos";
            // 
            // txtfecha
            // 
            this.txtfecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtfecha.Location = new System.Drawing.Point(7, 182);
            this.txtfecha.Name = "txtfecha";
            this.txtfecha.Size = new System.Drawing.Size(84, 20);
            this.txtfecha.TabIndex = 93;
            this.txtfecha.Value = new System.DateTime(2013, 4, 6, 0, 0, 0, 0);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(5, 168);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 14);
            this.label11.TabIndex = 92;
            this.label11.Text = "FECHA EMISION";
            // 
            // txtValor
            // 
            this.txtValor.BackColor = System.Drawing.Color.Transparent;
            this.txtValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValor.Location = new System.Drawing.Point(106, 182);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(124, 20);
            this.txtValor.TabIndex = 91;
            this.txtValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbConepto
            // 
            this.cmbConepto.BackColor = System.Drawing.Color.White;
            this.cmbConepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConepto.FormattingEnabled = true;
            this.cmbConepto.Location = new System.Drawing.Point(5, 135);
            this.cmbConepto.Name = "cmbConepto";
            this.cmbConepto.Size = new System.Drawing.Size(233, 21);
            this.cmbConepto.TabIndex = 90;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 14);
            this.label2.TabIndex = 89;
            this.label2.Text = "CONCEPTO CONTABLE  DEL DEPÓSITO";
            // 
            // txtCtaBanco
            // 
            this.txtCtaBanco.ForeColor = System.Drawing.Color.Black;
            this.txtCtaBanco.Location = new System.Drawing.Point(69, 32);
            this.txtCtaBanco.Name = "txtCtaBanco";
            this.txtCtaBanco.Size = new System.Drawing.Size(100, 20);
            this.txtCtaBanco.TabIndex = 87;
            // 
            // cmbDocumento
            // 
            this.cmbDocumento.BackColor = System.Drawing.Color.White;
            this.cmbDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDocumento.FormattingEnabled = true;
            this.cmbDocumento.Location = new System.Drawing.Point(6, 92);
            this.cmbDocumento.Name = "cmbDocumento";
            this.cmbDocumento.Size = new System.Drawing.Size(233, 21);
            this.cmbDocumento.TabIndex = 80;
            // 
            // btnBuscaBanco
            // 
            this.btnBuscaBanco.BackColor = System.Drawing.Color.Gray;
            this.btnBuscaBanco.FlatAppearance.BorderSize = 0;
            this.btnBuscaBanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscaBanco.Font = new System.Drawing.Font("Arial Narrow", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscaBanco.ForeColor = System.Drawing.Color.White;
            this.btnBuscaBanco.Image = global::CierreDeCaja.My.Resources.Resources.buscar_16;
            this.btnBuscaBanco.Location = new System.Drawing.Point(6, 32);
            this.btnBuscaBanco.Name = "btnBuscaBanco";
            this.btnBuscaBanco.Size = new System.Drawing.Size(20, 20);
            this.btnBuscaBanco.TabIndex = 86;
            this.btnBuscaBanco.UseVisualStyleBackColor = false;
            this.btnBuscaBanco.Click += new System.EventHandler(this.btnBuscaBanco_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(5, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 14);
            this.label7.TabIndex = 79;
            this.label7.Text = "DOCUMENTO";
            // 
            // txtNombreBanco
            // 
            this.txtNombreBanco.BackColor = System.Drawing.Color.White;
            this.txtNombreBanco.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombreBanco.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreBanco.ForeColor = System.Drawing.Color.Black;
            this.txtNombreBanco.Location = new System.Drawing.Point(9, 55);
            this.txtNombreBanco.Name = "txtNombreBanco";
            this.txtNombreBanco.Size = new System.Drawing.Size(230, 14);
            this.txtNombreBanco.TabIndex = 85;
            // 
            // txtCodBanco
            // 
            this.txtCodBanco.ForeColor = System.Drawing.Color.Black;
            this.txtCodBanco.Location = new System.Drawing.Point(29, 32);
            this.txtCodBanco.Name = "txtCodBanco";
            this.txtCodBanco.Size = new System.Drawing.Size(40, 20);
            this.txtCodBanco.TabIndex = 84;
            // 
            // labNombreBanco
            // 
            this.labNombreBanco.AutoSize = true;
            this.labNombreBanco.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labNombreBanco.ForeColor = System.Drawing.Color.White;
            this.labNombreBanco.Location = new System.Drawing.Point(27, 20);
            this.labNombreBanco.Name = "labNombreBanco";
            this.labNombreBanco.Size = new System.Drawing.Size(61, 14);
            this.labNombreBanco.TabIndex = 83;
            this.labNombreBanco.Text = "Banco/caja";
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(118, 90);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(31, 13);
            this.Label15.TabIndex = 11;
            this.Label15.Text = "Valor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(104, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 14);
            this.label1.TabIndex = 94;
            this.label1.Text = "Valor";
            // 
            // frmResumenGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 478);
            this.ControlBox = false;
            this.Controls.Add(this.SplitContainer1);
            this.Controls.Add(this.ToolStrip1);
            this.Name = "frmResumenGeneral";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PUNTTO - RESUMEN GENERAL DE CAJA";
            this.Grupo.ResumeLayout(false);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            this.SplitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            this.GrupoRecumenGenerarl.ResumeLayout(false);
            this.GrupoRecumenGenerarl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox Grupo;
        internal System.Windows.Forms.DateTimePicker txtFechaAl;
        internal System.Windows.Forms.DateTimePicker txtFechaDel;
        internal Microsoft.Reporting.WinForms.ReportViewer ReportViewer1;
        internal System.Windows.Forms.ToolStripButton btnOpciones;
        internal System.Windows.Forms.ToolStripButton btnSalir;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton BtnResumenGeneral;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator6;
        internal System.Windows.Forms.ToolStripButton btnGenerarIngresoBanco;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
        internal System.Windows.Forms.HelpProvider HelpProvider1;
        internal System.Windows.Forms.SplitContainer SplitContainer1;
        internal System.Windows.Forms.GroupBox GrupoRecumenGenerarl;
        internal System.Windows.Forms.Label Label15;
        public System.Windows.Forms.TextBox txtCtaBanco;
        public System.Windows.Forms.ComboBox cmbDocumento;
        public System.Windows.Forms.Button btnBuscaBanco;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtNombreBanco;
        public System.Windows.Forms.TextBox txtCodBanco;
        public System.Windows.Forms.Label labNombreBanco;
        public System.Windows.Forms.ComboBox cmbConepto;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.DateTimePicker txtfecha;
        public System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label txtValor;
    }
}