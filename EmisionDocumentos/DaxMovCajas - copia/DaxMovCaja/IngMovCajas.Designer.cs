namespace DaxMovCaja
{
    partial class IngMovCaja
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
            this.txtResponsable = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.btnGuarda = new System.Windows.Forms.Button();
            this.btnCancela = new System.Windows.Forms.Button();
            this.btnBusca = new System.Windows.Forms.Button();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // txtResponsable
            // 
            this.txtResponsable.Location = new System.Drawing.Point(96, 45);
            this.txtResponsable.Name = "txtResponsable";
            this.txtResponsable.Size = new System.Drawing.Size(343, 20);
            this.txtResponsable.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Recibido de:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Concepto :";
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(96, 70);
            this.txtConcepto.MaxLength = 100;
            this.txtConcepto.Multiline = true;
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(343, 34);
            this.txtConcepto.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Valor :";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(96, 108);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(83, 20);
            this.txtValor.TabIndex = 4;
            // 
            // btnGuarda
            // 
            this.btnGuarda.BackColor = System.Drawing.Color.SteelBlue;
            this.btnGuarda.ForeColor = System.Drawing.Color.White;
            this.btnGuarda.Location = new System.Drawing.Point(465, 97);
            this.btnGuarda.Name = "btnGuarda";
            this.btnGuarda.Size = new System.Drawing.Size(76, 48);
            this.btnGuarda.TabIndex = 6;
            this.btnGuarda.Text = "Guarda";
            this.btnGuarda.UseVisualStyleBackColor = false;
            this.btnGuarda.Click += new System.EventHandler(this.btnGuarda_Click);
            // 
            // btnCancela
            // 
            this.btnCancela.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancela.ForeColor = System.Drawing.Color.White;
            this.btnCancela.Location = new System.Drawing.Point(465, 49);
            this.btnCancela.Name = "btnCancela";
            this.btnCancela.Size = new System.Drawing.Size(76, 48);
            this.btnCancela.TabIndex = 7;
            this.btnCancela.Text = "Cancela";
            this.btnCancela.UseVisualStyleBackColor = false;
            // 
            // btnBusca
            // 
            this.btnBusca.BackColor = System.Drawing.Color.SteelBlue;
            this.btnBusca.ForeColor = System.Drawing.Color.White;
            this.btnBusca.Location = new System.Drawing.Point(465, 0);
            this.btnBusca.Name = "btnBusca";
            this.btnBusca.Size = new System.Drawing.Size(76, 48);
            this.btnBusca.TabIndex = 8;
            this.btnBusca.Text = "Editar";
            this.btnBusca.UseVisualStyleBackColor = false;
            this.btnBusca.Click += new System.EventHandler(this.btnBusca_Click);
            // 
            // dtFecha
            // 
            this.dtFecha.CustomFormat = "dddd,dd MMMM yyyy  hh:mm";
            this.dtFecha.Enabled = false;
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFecha.Location = new System.Drawing.Point(96, 8);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(210, 20);
            this.dtFecha.TabIndex = 9;
            // 
            // IngMovCaja
            // 
            this.AcceptButton = this.btnGuarda;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancela;
            this.ClientSize = new System.Drawing.Size(544, 146);
            this.ControlBox = false;
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.btnBusca);
            this.Controls.Add(this.btnCancela);
            this.Controls.Add(this.btnGuarda);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtConcepto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtResponsable);
            this.Name = "IngMovCaja";
            this.Text = "Registro de Otros ingresos a caja";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResponsable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Button btnGuarda;
        private System.Windows.Forms.Button btnCancela;
        private System.Windows.Forms.Button btnBusca;
        private System.Windows.Forms.DateTimePicker dtFecha;
    }
}