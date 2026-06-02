namespace genCmpbteCtbAcf
{
    partial class Form2
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnProcesar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.txtDetalle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFechaDocumento = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.txtNumeroDiario = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbDocumento = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbAño = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDeMes = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbAMes = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnProcesar.ForeColor = System.Drawing.Color.White;
            this.btnProcesar.Location = new System.Drawing.Point(354, 183);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(106, 26);
            this.btnProcesar.TabIndex = 78;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.UseVisualStyleBackColor = false;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(240, 183);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(106, 26);
            this.btnSalir.TabIndex = 77;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // txtDetalle
            // 
            this.txtDetalle.Location = new System.Drawing.Point(7, 155);
            this.txtDetalle.MaxLength = 150;
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.Size = new System.Drawing.Size(451, 20);
            this.txtDetalle.TabIndex = 76;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 75;
            this.label1.Text = "Detalle:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFechaDocumento);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.txtNumeroDiario);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.cmbDocumento);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(7, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(451, 95);
            this.groupBox1.TabIndex = 74;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Diario contable a crear";
            // 
            // txtFechaDocumento
            // 
            this.txtFechaDocumento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFechaDocumento.Location = new System.Drawing.Point(274, 53);
            this.txtFechaDocumento.Name = "txtFechaDocumento";
            this.txtFechaDocumento.Size = new System.Drawing.Size(88, 20);
            this.txtFechaDocumento.TabIndex = 44;
            this.txtFechaDocumento.Value = new System.DateTime(2013, 4, 6, 0, 0, 0, 0);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(191, 58);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(79, 13);
            this.label17.TabIndex = 43;
            this.label17.Text = "Fecha Emisión:";
            // 
            // txtNumeroDiario
            // 
            this.txtNumeroDiario.Location = new System.Drawing.Point(93, 53);
            this.txtNumeroDiario.MaxLength = 9;
            this.txtNumeroDiario.Name = "txtNumeroDiario";
            this.txtNumeroDiario.Size = new System.Drawing.Size(83, 20);
            this.txtNumeroDiario.TabIndex = 42;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(10, 57);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 13);
            this.label14.TabIndex = 41;
            this.label14.Text = "Numero inicial :";
            // 
            // cmbDocumento
            // 
            this.cmbDocumento.BackColor = System.Drawing.Color.White;
            this.cmbDocumento.FormattingEnabled = true;
            this.cmbDocumento.Location = new System.Drawing.Point(76, 24);
            this.cmbDocumento.Name = "cmbDocumento";
            this.cmbDocumento.Size = new System.Drawing.Size(268, 21);
            this.cmbDocumento.TabIndex = 40;
            this.cmbDocumento.SelectedValueChanged += new System.EventHandler(this.cmbDocumento_SelectedValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "Documento:";
            // 
            // cmbAño
            // 
            this.cmbAño.BackColor = System.Drawing.Color.White;
            this.cmbAño.FormattingEnabled = true;
            this.cmbAño.Location = new System.Drawing.Point(52, 6);
            this.cmbAño.Name = "cmbAño";
            this.cmbAño.Size = new System.Drawing.Size(61, 21);
            this.cmbAño.TabIndex = 80;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 79;
            this.label2.Text = "Año:";
            // 
            // cmbDeMes
            // 
            this.cmbDeMes.BackColor = System.Drawing.Color.White;
            this.cmbDeMes.FormattingEnabled = true;
            this.cmbDeMes.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Semptiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.cmbDeMes.Location = new System.Drawing.Point(161, 6);
            this.cmbDeMes.Name = "cmbDeMes";
            this.cmbDeMes.Size = new System.Drawing.Size(130, 21);
            this.cmbDeMes.TabIndex = 82;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(131, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 81;
            this.label3.Text = "De :";
            // 
            // cmbAMes
            // 
            this.cmbAMes.BackColor = System.Drawing.Color.White;
            this.cmbAMes.FormattingEnabled = true;
            this.cmbAMes.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Semptiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.cmbAMes.Location = new System.Drawing.Point(322, 6);
            this.cmbAMes.Name = "cmbAMes";
            this.cmbAMes.Size = new System.Drawing.Size(130, 21);
            this.cmbAMes.TabIndex = 84;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(297, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 83;
            this.label4.Text = "A:";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 215);
            this.Controls.Add(this.cmbAMes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbDeMes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbAño);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.txtDetalle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form2";
            this.Text = "GENERACION DE DIARIO CONTABLE  ACTIVOS FIJOS";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtDetalle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker txtFechaDocumento;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtNumeroDiario;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbDocumento;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbAño;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDeMes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbAMes;
        private System.Windows.Forms.Label label4;
    }
}

