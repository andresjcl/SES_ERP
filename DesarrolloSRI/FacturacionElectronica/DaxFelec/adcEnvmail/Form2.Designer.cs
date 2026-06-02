namespace adcEnvmail
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.btnConfigurar = new System.Windows.Forms.Label();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.txtDetalle = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtAsunto = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtOrigen = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnConfigurar
            // 
            this.btnConfigurar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfigurar.Image = ((System.Drawing.Image)(resources.GetObject("btnConfigurar.Image")));
            this.btnConfigurar.Location = new System.Drawing.Point(541, 14);
            this.btnConfigurar.Name = "btnConfigurar";
            this.btnConfigurar.Size = new System.Drawing.Size(29, 32);
            this.btnConfigurar.TabIndex = 31;
            this.btnConfigurar.Click += new System.EventHandler(this.btnConfigurar_Click);
            // 
            // Button2
            // 
            this.Button2.BackColor = System.Drawing.Color.SteelBlue;
            this.Button2.ForeColor = System.Drawing.Color.White;
            this.Button2.Location = new System.Drawing.Point(490, 213);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(84, 32);
            this.Button2.TabIndex = 30;
            this.Button2.Text = "Cancelar";
            this.Button2.UseVisualStyleBackColor = false;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Button1
            // 
            this.Button1.BackColor = System.Drawing.Color.SteelBlue;
            this.Button1.ForeColor = System.Drawing.Color.White;
            this.Button1.Location = new System.Drawing.Point(384, 213);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(84, 32);
            this.Button1.TabIndex = 29;
            this.Button1.Text = "Aceptar";
            this.Button1.UseVisualStyleBackColor = false;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // txtDetalle
            // 
            this.txtDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetalle.Location = new System.Drawing.Point(21, 128);
            this.txtDetalle.Multiline = true;
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.Size = new System.Drawing.Size(549, 79);
            this.txtDetalle.TabIndex = 28;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(21, 112);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(43, 13);
            this.Label4.TabIndex = 27;
            this.Label4.Text = "Detalle:";
            // 
            // txtAsunto
            // 
            this.txtAsunto.Location = new System.Drawing.Point(60, 78);
            this.txtAsunto.Name = "txtAsunto";
            this.txtAsunto.Size = new System.Drawing.Size(503, 20);
            this.txtAsunto.TabIndex = 26;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(18, 82);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(43, 13);
            this.Label3.TabIndex = 25;
            this.Label3.Text = "Asunto:";
            // 
            // txtDestino
            // 
            this.txtDestino.Location = new System.Drawing.Point(48, 45);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(416, 20);
            this.txtDestino.TabIndex = 24;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(18, 52);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(16, 13);
            this.Label2.TabIndex = 23;
            this.Label2.Text = "a:";
            // 
            // txtOrigen
            // 
            this.txtOrigen.Location = new System.Drawing.Point(48, 19);
            this.txtOrigen.Name = "txtOrigen";
            this.txtOrigen.Size = new System.Drawing.Size(439, 20);
            this.txtOrigen.TabIndex = 22;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(18, 23);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(24, 13);
            this.Label1.TabIndex = 21;
            this.Label1.Text = "De:";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(582, 252);
            this.ControlBox = false;
            this.Controls.Add(this.btnConfigurar);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.txtDetalle);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.txtAsunto);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtDestino);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtOrigen);
            this.Controls.Add(this.Label1);
            this.Name = "Form2";
            this.Text = "Registrar datos para envío de correo electrónico";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label btnConfigurar;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.TextBox txtDetalle;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtAsunto;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtDestino;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtOrigen;
        internal System.Windows.Forms.Label Label1;
    }
}