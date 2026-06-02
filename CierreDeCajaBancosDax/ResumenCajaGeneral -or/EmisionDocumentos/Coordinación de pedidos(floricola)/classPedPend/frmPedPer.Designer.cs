namespace classPedPend
{
    partial class frmPedPer
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
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtFin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.chkSemanal = new System.Windows.Forms.RadioButton();
            this.cmbDiasemanal = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkQuincenal = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbDiaQuincena2 = new System.Windows.Forms.ComboBox();
            this.cmbDiaQuincena1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkMensual = new System.Windows.Forms.RadioButton();
            this.cmbDiaMes = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtInicio
            // 
            this.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInicio.Location = new System.Drawing.Point(154, 24);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(84, 20);
            this.dtInicio.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha inicia despacho :";
            // 
            // dtFin
            // 
            this.dtFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFin.Location = new System.Drawing.Point(397, 24);
            this.dtFin.Name = "dtFin";
            this.dtFin.Size = new System.Drawing.Size(84, 20);
            this.dtFin.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fecha último Despacho:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(495, 160);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(87, 28);
            this.btnAceptar.TabIndex = 13;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(593, 160);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 28);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // chkSemanal
            // 
            this.chkSemanal.AutoSize = true;
            this.chkSemanal.Location = new System.Drawing.Point(45, 58);
            this.chkSemanal.Name = "chkSemanal";
            this.chkSemanal.Size = new System.Drawing.Size(103, 17);
            this.chkSemanal.TabIndex = 19;
            this.chkSemanal.TabStop = true;
            this.chkSemanal.Text = "Emisión semanal";
            this.chkSemanal.UseVisualStyleBackColor = true;
            // 
            // cmbDiasemanal
            // 
            this.cmbDiasemanal.FormattingEnabled = true;
            this.cmbDiasemanal.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miércoles",
            "Jueves",
            "Viernes",
            "Sábado",
            "Domingo"});
            this.cmbDiasemanal.Location = new System.Drawing.Point(279, 57);
            this.cmbDiasemanal.Name = "cmbDiasemanal";
            this.cmbDiasemanal.Size = new System.Drawing.Size(126, 21);
            this.cmbDiasemanal.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(180, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Día de la semana :";
            // 
            // chkQuincenal
            // 
            this.chkQuincenal.AutoSize = true;
            this.chkQuincenal.Location = new System.Drawing.Point(48, 94);
            this.chkQuincenal.Name = "chkQuincenal";
            this.chkQuincenal.Size = new System.Drawing.Size(110, 17);
            this.chkQuincenal.TabIndex = 24;
            this.chkQuincenal.TabStop = true;
            this.chkQuincenal.Text = "Emisión quincenal";
            this.chkQuincenal.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(409, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Dia Segunda Quincena";
            // 
            // cmbDiaQuincena2
            // 
            this.cmbDiaQuincena2.FormattingEnabled = true;
            this.cmbDiaQuincena2.Items.AddRange(new object[] {
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "Fin de mes"});
            this.cmbDiaQuincena2.Location = new System.Drawing.Point(536, 95);
            this.cmbDiaQuincena2.Name = "cmbDiaQuincena2";
            this.cmbDiaQuincena2.Size = new System.Drawing.Size(84, 21);
            this.cmbDiaQuincena2.TabIndex = 22;
            // 
            // cmbDiaQuincena1
            // 
            this.cmbDiaQuincena1.FormattingEnabled = true;
            this.cmbDiaQuincena1.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.cmbDiaQuincena1.Location = new System.Drawing.Point(302, 94);
            this.cmbDiaQuincena1.Name = "cmbDiaQuincena1";
            this.cmbDiaQuincena1.Size = new System.Drawing.Size(84, 21);
            this.cmbDiaQuincena1.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(183, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Dia primera Quincena";
            // 
            // chkMensual
            // 
            this.chkMensual.AutoSize = true;
            this.chkMensual.Location = new System.Drawing.Point(48, 131);
            this.chkMensual.Name = "chkMensual";
            this.chkMensual.Size = new System.Drawing.Size(103, 17);
            this.chkMensual.TabIndex = 27;
            this.chkMensual.TabStop = true;
            this.chkMensual.Text = "Emisión mensual";
            this.chkMensual.UseVisualStyleBackColor = true;
            // 
            // cmbDiaMes
            // 
            this.cmbDiaMes.FormattingEnabled = true;
            this.cmbDiaMes.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "Fin de mes"});
            this.cmbDiaMes.Location = new System.Drawing.Point(266, 131);
            this.cmbDiaMes.Name = "cmbDiaMes";
            this.cmbDiaMes.Size = new System.Drawing.Size(84, 21);
            this.cmbDiaMes.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(186, 134);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Día del mes :";
            // 
            // frmPedPer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(692, 198);
            this.Controls.Add(this.chkMensual);
            this.Controls.Add(this.cmbDiaMes);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chkQuincenal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbDiaQuincena2);
            this.Controls.Add(this.cmbDiaQuincena1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkSemanal);
            this.Controls.Add(this.cmbDiasemanal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtFin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtInicio);
            this.Name = "frmPedPer";
            this.Text = "DefiniciónPedidosPeriódicos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtInicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtFin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.RadioButton chkSemanal;
        private System.Windows.Forms.ComboBox cmbDiasemanal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton chkQuincenal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbDiaQuincena2;
        private System.Windows.Forms.ComboBox cmbDiaQuincena1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton chkMensual;
        private System.Windows.Forms.ComboBox cmbDiaMes;
        private System.Windows.Forms.Label label8;
    }
}