namespace DaxBan
{
    partial class FrmSaldos
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
            this.dtFechaSaldo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkSaldoCero = new System.Windows.Forms.CheckBox();
            this.chkFechaEfectivizacion = new System.Windows.Forms.CheckBox();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labSaldoTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.malla = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.malla)).BeginInit();
            this.SuspendLayout();
            // 
            // dtFechaSaldo
            // 
            this.dtFechaSaldo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaSaldo.Location = new System.Drawing.Point(91, 22);
            this.dtFechaSaldo.Margin = new System.Windows.Forms.Padding(4);
            this.dtFechaSaldo.Name = "dtFechaSaldo";
            this.dtFechaSaldo.Size = new System.Drawing.Size(108, 22);
            this.dtFechaSaldo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Saldos al ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.chkSaldoCero);
            this.panel1.Controls.Add(this.chkFechaEfectivizacion);
            this.panel1.Controls.Add(this.dtFechaSaldo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(969, 95);
            this.panel1.TabIndex = 2;
            // 
            // chkSaldoCero
            // 
            this.chkSaldoCero.AutoSize = true;
            this.chkSaldoCero.Location = new System.Drawing.Point(275, 57);
            this.chkSaldoCero.Margin = new System.Windows.Forms.Padding(4);
            this.chkSaldoCero.Name = "chkSaldoCero";
            this.chkSaldoCero.Size = new System.Drawing.Size(218, 21);
            this.chkSaldoCero.TabIndex = 3;
            this.chkSaldoCero.Text = "Incluir cuentas con saldo cero";
            this.chkSaldoCero.UseVisualStyleBackColor = true;
            // 
            // chkFechaEfectivizacion
            // 
            this.chkFechaEfectivizacion.AutoSize = true;
            this.chkFechaEfectivizacion.Location = new System.Drawing.Point(25, 57);
            this.chkFechaEfectivizacion.Margin = new System.Windows.Forms.Padding(4);
            this.chkFechaEfectivizacion.Name = "chkFechaEfectivizacion";
            this.chkFechaEfectivizacion.Size = new System.Drawing.Size(203, 21);
            this.chkFechaEfectivizacion.TabIndex = 2;
            this.chkFechaEfectivizacion.Text = "Con fecha de efectivicación";
            this.chkFechaEfectivizacion.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Controls.Add(this.labSaldoTotal);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnActualizar);
            this.panel2.Controls.Add(this.btnImprimir);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(0, 427);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(969, 69);
            this.panel2.TabIndex = 3;
            // 
            // labSaldoTotal
            // 
            this.labSaldoTotal.BackColor = System.Drawing.Color.White;
            this.labSaldoTotal.ForeColor = System.Drawing.Color.Black;
            this.labSaldoTotal.Location = new System.Drawing.Point(528, 23);
            this.labSaldoTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labSaldoTotal.Name = "labSaldoTotal";
            this.labSaldoTotal.Size = new System.Drawing.Size(152, 25);
            this.labSaldoTotal.TabIndex = 11;
            this.labSaldoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(431, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Saldo Total ;";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(248, 10);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(107, 49);
            this.button1.TabIndex = 9;
            this.button1.Text = "Salir";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(13, 10);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(4);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnActualizar.Size = new System.Drawing.Size(107, 49);
            this.btnActualizar.TabIndex = 8;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.SteelBlue;
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(131, 10);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnImprimir.Size = new System.Drawing.Size(107, 49);
            this.btnImprimir.TabIndex = 7;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // malla
            // 
            this.malla.AllowUserToAddRows = false;
            this.malla.AllowUserToDeleteRows = false;
            this.malla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.malla.BackgroundColor = System.Drawing.Color.White;
            this.malla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.malla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.malla.GridColor = System.Drawing.Color.Gainsboro;
            this.malla.Location = new System.Drawing.Point(0, 95);
            this.malla.Margin = new System.Windows.Forms.Padding(4);
            this.malla.Name = "malla";
            this.malla.ReadOnly = true;
            this.malla.RowHeadersWidth = 51;
            this.malla.Size = new System.Drawing.Size(969, 332);
            this.malla.TabIndex = 4;
            // 
            // FrmSaldos
            // 
            this.AcceptButton = this.btnActualizar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(969, 496);
            this.ControlBox = false;
            this.Controls.Add(this.malla);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmSaldos";
            this.ShowIcon = false;
            this.Text = "CONSULTA DE SALDOS DE BANCOS Y CAJAS";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.malla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtFechaSaldo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkSaldoCero;
        private System.Windows.Forms.CheckBox chkFechaEfectivizacion;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button btnActualizar;
        public System.Windows.Forms.Button btnImprimir;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labSaldoTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView malla;
    }
}