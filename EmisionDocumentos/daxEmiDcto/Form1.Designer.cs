namespace daxEmiFacPv
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCrear = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.mallaDatos = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mallaDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnCrear);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 333);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(670, 41);
            this.panel1.TabIndex = 0;
            // 
            // btnCrear
            // 
            this.btnCrear.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCrear.ForeColor = System.Drawing.Color.White;
            this.btnCrear.Location = new System.Drawing.Point(3, 2);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(251, 36);
            this.btnCrear.TabIndex = 0;
            this.btnCrear.Text = "&Crear nuevo con el mismo número";
            this.btnCrear.UseVisualStyleBackColor = false;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(260, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(251, 36);
            this.button1.TabIndex = 1;
            this.button1.Text = "&Visualizar documento seleccionado";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mallaDatos
            // 
            this.mallaDatos.AllowUserToAddRows = false;
            this.mallaDatos.AllowUserToDeleteRows = false;
            this.mallaDatos.AllowUserToResizeRows = false;
            this.mallaDatos.BackgroundColor = System.Drawing.Color.White;
            this.mallaDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mallaDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mallaDatos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mallaDatos.Location = new System.Drawing.Point(0, 0);
            this.mallaDatos.Name = "mallaDatos";
            this.mallaDatos.ReadOnly = true;
            this.mallaDatos.Size = new System.Drawing.Size(670, 333);
            this.mallaDatos.TabIndex = 1;
            this.mallaDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mallaDatos_CellContentClick);
            this.mallaDatos.DoubleClick += new System.EventHandler(this.mallaDatos_DoubleClick);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.SteelBlue;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(517, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 36);
            this.button2.TabIndex = 2;
            this.button2.Text = "&Salir";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(670, 374);
            this.ControlBox = false;
            this.Controls.Add(this.mallaDatos);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "                                   DOCUMENTOS CON NUMERACION COINCIDENTE";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mallaDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView mallaDatos;
        private System.Windows.Forms.Button button2;
    }
}