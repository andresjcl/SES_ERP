namespace DaxInvent
{
    partial class FrmRecosteo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRecosteo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnErrores = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.labDesde = new System.Windows.Forms.Label();
            this.labFechaDoc = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labCierre = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.dtFechaLimiteProceso = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnErrores);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.labDesde);
            this.panel1.Controls.Add(this.labFechaDoc);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.labCierre);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.dtFechaLimiteProceso);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(16, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(818, 184);
            this.panel1.TabIndex = 0;
            // 
            // btnErrores
            // 
            this.btnErrores.BackColor = System.Drawing.Color.SteelBlue;
            this.btnErrores.FlatAppearance.BorderSize = 0;
            this.btnErrores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnErrores.ForeColor = System.Drawing.Color.White;
            this.btnErrores.Location = new System.Drawing.Point(680, 128);
            this.btnErrores.Margin = new System.Windows.Forms.Padding(4);
            this.btnErrores.Name = "btnErrores";
            this.btnErrores.Size = new System.Drawing.Size(129, 41);
            this.btnErrores.TabIndex = 4;
            this.btnErrores.Text = "Analizar errores";
            this.btnErrores.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(528, 65);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Hasta :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labDesde
            // 
            this.labDesde.BackColor = System.Drawing.Color.White;
            this.labDesde.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDesde.ForeColor = System.Drawing.Color.Black;
            this.labDesde.Location = new System.Drawing.Point(397, 65);
            this.labDesde.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labDesde.Name = "labDesde";
            this.labDesde.Size = new System.Drawing.Size(115, 20);
            this.labDesde.TabIndex = 7;
            this.labDesde.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labFechaDoc
            // 
            this.labFechaDoc.BackColor = System.Drawing.Color.White;
            this.labFechaDoc.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labFechaDoc.ForeColor = System.Drawing.Color.Black;
            this.labFechaDoc.Location = new System.Drawing.Point(677, 21);
            this.labFechaDoc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labFechaDoc.Name = "labFechaDoc";
            this.labFechaDoc.Size = new System.Drawing.Size(115, 20);
            this.labFechaDoc.TabIndex = 6;
            this.labFechaDoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(333, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(330, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Registro de documentos permitido desde el :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labCierre
            // 
            this.labCierre.BackColor = System.Drawing.Color.White;
            this.labCierre.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCierre.ForeColor = System.Drawing.Color.Black;
            this.labCierre.Location = new System.Drawing.Point(191, 21);
            this.labCierre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labCierre.Name = "labCierre";
            this.labCierre.Size = new System.Drawing.Size(115, 20);
            this.labCierre.TabIndex = 4;
            this.labCierre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(45, 112);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(260, 22);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Verificar saldos negativos en bodega :";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // dtFechaLimiteProceso
            // 
            this.dtFechaLimiteProceso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaLimiteProceso.Location = new System.Drawing.Point(596, 63);
            this.dtFechaLimiteProceso.Margin = new System.Windows.Forms.Padding(4);
            this.dtFechaLimiteProceso.Name = "dtFechaLimiteProceso";
            this.dtFechaLimiteProceso.Size = new System.Drawing.Size(132, 22);
            this.dtFechaLimiteProceso.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(25, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Se reactualizará costos en documentos desde el :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(17, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Último cierre anual  :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnProcesar.FlatAppearance.BorderSize = 0;
            this.btnProcesar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcesar.ForeColor = System.Drawing.Color.White;
            this.btnProcesar.Location = new System.Drawing.Point(563, 260);
            this.btnProcesar.Margin = new System.Windows.Forms.Padding(4);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(129, 41);
            this.btnProcesar.TabIndex = 1;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.UseVisualStyleBackColor = false;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(701, 260);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(129, 41);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(9, 208);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(520, 93);
            this.label3.TabIndex = 3;
            this.label3.Text = resources.GetString("label3.Text");
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmRecosteo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(872, 350);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmRecosteo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADCOMDAX - REACTUALIZACION DE COSTO DE ARTICULOS";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DateTimePicker dtFechaLimiteProceso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labCierre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labDesde;
        private System.Windows.Forms.Label labFechaDoc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnErrores;
    }
}