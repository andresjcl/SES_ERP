namespace gessClass
{
    partial class FrmColumns
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
            this.txtNombre = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAncho = new System.Windows.Forms.TextBox();
            this.chkAgrupar = new System.Windows.Forms.CheckBox();
            this.chkSubtotal = new System.Windows.Forms.CheckBox();
            this.chkSumar = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre columna:";
            // 
            // txtNombre
            // 
            this.txtNombre.AutoSize = true;
            this.txtNombre.BackColor = System.Drawing.Color.White;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(128, 21);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(114, 16);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.Text = "Nombre columna:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ancho :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(128, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Formato ";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 168);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Seleccionar valores ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(226, 168);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "a:";
            // 
            // txtAncho
            // 
            this.txtAncho.Location = new System.Drawing.Point(60, 43);
            this.txtAncho.Name = "txtAncho";
            this.txtAncho.Size = new System.Drawing.Size(33, 20);
            this.txtAncho.TabIndex = 12;
            // 
            // chkAgrupar
            // 
            this.chkAgrupar.AutoSize = true;
            this.chkAgrupar.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAgrupar.Location = new System.Drawing.Point(8, 91);
            this.chkAgrupar.Name = "chkAgrupar";
            this.chkAgrupar.Size = new System.Drawing.Size(142, 17);
            this.chkAgrupar.TabIndex = 14;
            this.chkAgrupar.Text = "Agrupar valores iguales :";
            this.chkAgrupar.UseVisualStyleBackColor = true;
            // 
            // chkSubtotal
            // 
            this.chkSubtotal.AutoSize = true;
            this.chkSubtotal.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSubtotal.Location = new System.Drawing.Point(9, 113);
            this.chkSubtotal.Name = "chkSubtotal";
            this.chkSubtotal.Size = new System.Drawing.Size(237, 17);
            this.chkSubtotal.TabIndex = 15;
            this.chkSubtotal.Text = "Calcular subtotales en base a esta columna :";
            this.chkSubtotal.UseVisualStyleBackColor = true;
            // 
            // chkSumar
            // 
            this.chkSumar.AutoSize = true;
            this.chkSumar.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSumar.Location = new System.Drawing.Point(9, 136);
            this.chkSumar.Name = "chkSumar";
            this.chkSumar.Size = new System.Drawing.Size(268, 17);
            this.chkSumar.TabIndex = 16;
            this.chkSumar.Text = "Columna para sumatorias en agrupaciones y totales";
            this.chkSumar.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Sin Formato",
            "###,###,###,##9.99",
            "############",
            "dd/MMM/yyyy",
            "dd  \'de\' MMMM de yyyy"});
            this.comboBox1.Location = new System.Drawing.Point(182, 42);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(142, 21);
            this.comboBox1.TabIndex = 17;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Igual",
            "Diferente",
            "Mayor",
            "Menor",
            "Parecido"});
            this.comboBox2.Location = new System.Drawing.Point(112, 164);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(111, 21);
            this.comboBox2.TabIndex = 18;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(245, 164);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(87, 20);
            this.textBox1.TabIndex = 19;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(11, 69);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(76, 17);
            this.radioButton1.TabIndex = 20;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "no ordenar";
            this.radioButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton2.Location = new System.Drawing.Point(99, 69);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(111, 17);
            this.radioButton2.TabIndex = 21;
            this.radioButton2.Text = "orden ascendente";
            this.radioButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton3.Location = new System.Drawing.Point(221, 69);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(117, 17);
            this.radioButton3.TabIndex = 22;
            this.radioButton3.Text = "orden descendente";
            this.radioButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // FrmColumns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(355, 224);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.chkSumar);
            this.Controls.Add(this.chkSubtotal);
            this.Controls.Add(this.chkAgrupar);
            this.Controls.Add(this.txtAncho);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label12);
            this.Name = "FrmColumns";
            this.Text = "Propiedades de la Columna";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtAncho;
        private System.Windows.Forms.CheckBox chkAgrupar;
        private System.Windows.Forms.CheckBox chkSubtotal;
        private System.Windows.Forms.CheckBox chkSumar;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
    }
}