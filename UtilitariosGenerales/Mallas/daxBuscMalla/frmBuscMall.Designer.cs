namespace DaxMallaLib
{
    partial class frmBuscMall
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.txtReemplazar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbAmbitoBusqueda = new System.Windows.Forms.ComboBox();
            this.btnInicia = new System.Windows.Forms.Button();
            this.btnCancela = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.RadioButton();
            this.btnReemplazar = new System.Windows.Forms.RadioButton();
            this.chkValor = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(26, 62);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(257, 20);
            this.txtBuscar.TabIndex = 1;
            // 
            // txtReemplazar
            // 
            this.txtReemplazar.Location = new System.Drawing.Point(26, 98);
            this.txtReemplazar.Name = "txtReemplazar";
            this.txtReemplazar.Size = new System.Drawing.Size(257, 20);
            this.txtReemplazar.TabIndex = 5;
            this.txtReemplazar.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Reemplazar por:";
            this.label2.Visible = false;
            // 
            // cmbAmbitoBusqueda
            // 
            this.cmbAmbitoBusqueda.FormattingEnabled = true;
            this.cmbAmbitoBusqueda.Items.AddRange(new object[] {
            "Buscar en la columna actual",
            "Buscar en la fila actual",
            "Buscar en las celdas seleccionadas",
            "Buscar en toda la malla"});
            this.cmbAmbitoBusqueda.Location = new System.Drawing.Point(26, 135);
            this.cmbAmbitoBusqueda.Name = "cmbAmbitoBusqueda";
            this.cmbAmbitoBusqueda.Size = new System.Drawing.Size(257, 21);
            this.cmbAmbitoBusqueda.TabIndex = 6;
            // 
            // btnInicia
            // 
            this.btnInicia.BackColor = System.Drawing.Color.SteelBlue;
            this.btnInicia.ForeColor = System.Drawing.Color.White;
            this.btnInicia.Location = new System.Drawing.Point(206, 169);
            this.btnInicia.Name = "btnInicia";
            this.btnInicia.Size = new System.Drawing.Size(76, 27);
            this.btnInicia.TabIndex = 8;
            this.btnInicia.Text = "iniciar";
            this.btnInicia.UseVisualStyleBackColor = false;
            this.btnInicia.Click += new System.EventHandler(this.btnInicia_Click);
            // 
            // btnCancela
            // 
            this.btnCancela.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCancela.ForeColor = System.Drawing.Color.White;
            this.btnCancela.Location = new System.Drawing.Point(124, 169);
            this.btnCancela.Name = "btnCancela";
            this.btnCancela.Size = new System.Drawing.Size(76, 27);
            this.btnCancela.TabIndex = 9;
            this.btnCancela.Text = "cancela";
            this.btnCancela.UseVisualStyleBackColor = false;
            this.btnCancela.Click += new System.EventHandler(this.btnCancela_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.AutoSize = true;
            this.btnBuscar.Checked = true;
            this.btnBuscar.Location = new System.Drawing.Point(26, 15);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(58, 17);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.TabStop = true;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.CheckedChanged += new System.EventHandler(this.btnBuscar_CheckedChanged);
            // 
            // btnReemplazar
            // 
            this.btnReemplazar.AutoSize = true;
            this.btnReemplazar.Location = new System.Drawing.Point(90, 15);
            this.btnReemplazar.Name = "btnReemplazar";
            this.btnReemplazar.Size = new System.Drawing.Size(81, 17);
            this.btnReemplazar.TabIndex = 3;
            this.btnReemplazar.Text = "Reemplazar";
            this.btnReemplazar.UseVisualStyleBackColor = true;
            this.btnReemplazar.CheckedChanged += new System.EventHandler(this.btnBuscar_CheckedChanged);
            // 
            // chkValor
            // 
            this.chkValor.AutoSize = true;
            this.chkValor.Location = new System.Drawing.Point(212, 15);
            this.chkValor.Name = "chkValor";
            this.chkValor.Size = new System.Drawing.Size(71, 17);
            this.chkValor.TabIndex = 10;
            this.chkValor.Text = "Por valor ";
            this.chkValor.UseVisualStyleBackColor = true;
            this.chkValor.CheckedChanged += new System.EventHandler(this.chkValor_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Buscar en :";
            this.label3.Visible = false;
            // 
            // frmBuscMall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(301, 202);
            this.ControlBox = false;
            this.Controls.Add(this.chkValor);
            this.Controls.Add(this.btnCancela);
            this.Controls.Add(this.btnInicia);
            this.Controls.Add(this.cmbAmbitoBusqueda);
            this.Controls.Add(this.txtReemplazar);
            this.Controls.Add(this.btnReemplazar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "frmBuscMall";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.TextBox txtReemplazar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbAmbitoBusqueda;
        private System.Windows.Forms.Button btnInicia;
        private System.Windows.Forms.Button btnCancela;
        private System.Windows.Forms.RadioButton btnBuscar;
        private System.Windows.Forms.RadioButton btnReemplazar;
        private System.Windows.Forms.CheckBox chkValor;
        private System.Windows.Forms.Label label3;
    }
}