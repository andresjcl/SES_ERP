namespace DaxConceptos
{
    partial class BuscServ
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkSinTipo = new System.Windows.Forms.RadioButton();
            this.chkEgrBancos = new System.Windows.Forms.RadioButton();
            this.chkIngBancos = new System.Windows.Forms.RadioButton();
            this.chkVentas = new System.Windows.Forms.RadioButton();
            this.chkCompras = new System.Windows.Forms.RadioButton();
            this.chkTodos = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.mallaDatos = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbClase = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbGrupos = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mallaDatos)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 62);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(841, 62);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DimGray;
            this.groupBox1.Controls.Add(this.chkSinTipo);
            this.groupBox1.Controls.Add(this.chkEgrBancos);
            this.groupBox1.Controls.Add(this.chkIngBancos);
            this.groupBox1.Controls.Add(this.chkVentas);
            this.groupBox1.Controls.Add(this.chkCompras);
            this.groupBox1.Controls.Add(this.chkTodos);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(841, 62);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selección";
            // 
            // chkSinTipo
            // 
            this.chkSinTipo.AutoSize = true;
            this.chkSinTipo.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkSinTipo.Location = new System.Drawing.Point(475, 19);
            this.chkSinTipo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkSinTipo.Name = "chkSinTipo";
            this.chkSinTipo.Size = new System.Drawing.Size(77, 39);
            this.chkSinTipo.TabIndex = 11;
            this.chkSinTipo.Text = "SinTipo";
            this.chkSinTipo.UseVisualStyleBackColor = true;
            // 
            // chkEgrBancos
            // 
            this.chkEgrBancos.AutoSize = true;
            this.chkEgrBancos.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkEgrBancos.Location = new System.Drawing.Point(354, 19);
            this.chkEgrBancos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkEgrBancos.Name = "chkEgrBancos";
            this.chkEgrBancos.Size = new System.Drawing.Size(121, 39);
            this.chkEgrBancos.TabIndex = 10;
            this.chkEgrBancos.Text = "EgresoBancos";
            this.chkEgrBancos.UseVisualStyleBackColor = true;
            // 
            // chkIngBancos
            // 
            this.chkIngBancos.AutoSize = true;
            this.chkIngBancos.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkIngBancos.Location = new System.Drawing.Point(231, 19);
            this.chkIngBancos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkIngBancos.Name = "chkIngBancos";
            this.chkIngBancos.Size = new System.Drawing.Size(123, 39);
            this.chkIngBancos.TabIndex = 9;
            this.chkIngBancos.Text = "IngresoBancos";
            this.chkIngBancos.UseVisualStyleBackColor = true;
            // 
            // chkVentas
            // 
            this.chkVentas.AutoSize = true;
            this.chkVentas.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkVentas.Location = new System.Drawing.Point(158, 19);
            this.chkVentas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkVentas.Name = "chkVentas";
            this.chkVentas.Size = new System.Drawing.Size(73, 39);
            this.chkVentas.TabIndex = 8;
            this.chkVentas.Text = "Ventas";
            this.chkVentas.UseVisualStyleBackColor = true;
            // 
            // chkCompras
            // 
            this.chkCompras.AutoSize = true;
            this.chkCompras.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkCompras.Location = new System.Drawing.Point(73, 19);
            this.chkCompras.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkCompras.Name = "chkCompras";
            this.chkCompras.Size = new System.Drawing.Size(85, 39);
            this.chkCompras.TabIndex = 7;
            this.chkCompras.Text = "Compras";
            this.chkCompras.UseVisualStyleBackColor = true;
            // 
            // chkTodos
            // 
            this.chkTodos.AutoSize = true;
            this.chkTodos.Checked = true;
            this.chkTodos.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkTodos.Location = new System.Drawing.Point(4, 19);
            this.chkTodos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.Size = new System.Drawing.Size(69, 39);
            this.chkTodos.TabIndex = 6;
            this.chkTodos.TabStop = true;
            this.chkTodos.Text = "Todos";
            this.chkTodos.UseVisualStyleBackColor = true;
            this.chkTodos.CheckedChanged += new System.EventHandler(this.chkTodos_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtNombre);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 124);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(841, 39);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Buscar :";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(76, 6);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(501, 22);
            this.txtNombre.TabIndex = 2;
            this.txtNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNombre_KeyDown);
            // 
            // mallaDatos
            // 
            this.mallaDatos.AllowUserToAddRows = false;
            this.mallaDatos.AllowUserToDeleteRows = false;
            this.mallaDatos.AllowUserToResizeRows = false;
            this.mallaDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.mallaDatos.BackgroundColor = System.Drawing.Color.White;
            this.mallaDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mallaDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mallaDatos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mallaDatos.Location = new System.Drawing.Point(0, 163);
            this.mallaDatos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mallaDatos.Name = "mallaDatos";
            this.mallaDatos.ReadOnly = true;
            this.mallaDatos.RowHeadersWidth = 51;
            this.mallaDatos.Size = new System.Drawing.Size(841, 312);
            this.mallaDatos.TabIndex = 3;
            this.mallaDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mallaDatos_CellContentClick);
            this.mallaDatos.DoubleClick += new System.EventHandler(this.mallaDatos_DoubleClick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.Controls.Add(this.btnNuevo);
            this.panel3.Controls.Add(this.btnCancelar);
            this.panel3.Controls.Add(this.btnCrear);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 475);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(841, 43);
            this.panel3.TabIndex = 2;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.DimGray;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(683, 6);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(153, 31);
            this.btnNuevo.TabIndex = 2;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.DimGray;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(511, 6);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(153, 31);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnCrear
            // 
            this.btnCrear.BackColor = System.Drawing.Color.DimGray;
            this.btnCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrear.ForeColor = System.Drawing.Color.White;
            this.btnCrear.Location = new System.Drawing.Point(339, 6);
            this.btnCrear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(153, 31);
            this.btnCrear.TabIndex = 0;
            this.btnCrear.Text = "Aceptar";
            this.btnCrear.UseVisualStyleBackColor = false;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.DimGray;
            this.groupBox2.Controls.Add(this.cmbClase);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.cmbGrupos);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(841, 62);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // cmbClase
            // 
            this.cmbClase.FormattingEnabled = true;
            this.cmbClase.Location = new System.Drawing.Point(17, 27);
            this.cmbClase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbClase.Name = "cmbClase";
            this.cmbClase.Size = new System.Drawing.Size(255, 24);
            this.cmbClase.TabIndex = 31;
            this.cmbClase.SelectedIndexChanged += new System.EventHandler(this.cmbClase_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(13, 9);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 20);
            this.label12.TabIndex = 32;
            this.label12.Text = "Clase";
            // 
            // cmbGrupos
            // 
            this.cmbGrupos.FormattingEnabled = true;
            this.cmbGrupos.Location = new System.Drawing.Point(289, 27);
            this.cmbGrupos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbGrupos.Name = "cmbGrupos";
            this.cmbGrupos.Size = new System.Drawing.Size(255, 24);
            this.cmbGrupos.TabIndex = 29;
            this.cmbGrupos.SelectedIndexChanged += new System.EventHandler(this.cmbClase_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(288, 9);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 20);
            this.label13.TabIndex = 30;
            this.label13.Text = "Grupo :";
            // 
            // BuscServ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(841, 518);
            this.Controls.Add(this.mallaDatos);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "BuscServ";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BUSQUEDA DE CONCEPTOS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BuscServ_FormClosing);
            this.Load += new System.EventHandler(this.BuscServ_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mallaDatos)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView mallaDatos;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.RadioButton chkSinTipo;
        private System.Windows.Forms.RadioButton chkEgrBancos;
        private System.Windows.Forms.RadioButton chkIngBancos;
        private System.Windows.Forms.RadioButton chkVentas;
        private System.Windows.Forms.RadioButton chkCompras;
        private System.Windows.Forms.RadioButton chkTodos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbClase;
        internal System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbGrupos;
        internal System.Windows.Forms.Label label13;
    }
}