namespace DocPendientes
{
    partial class frmDocPndt
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocPndt));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnActualiza = new System.Windows.Forms.Button();
            this.chkAutorizados = new System.Windows.Forms.CheckBox();
            this.chkAnticipo = new System.Windows.Forms.CheckBox();
            this.chkProveedor = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkCliente = new System.Windows.Forms.CheckBox();
            this.txtValorPorAplicar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNroLote = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAplicarValor = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnBorraAplicar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalPendiente = new System.Windows.Forms.TextBox();
            this.txtValorAplicado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.Malla = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Malla)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.btnActualiza);
            this.panel1.Controls.Add(this.chkAutorizados);
            this.panel1.Controls.Add(this.chkAnticipo);
            this.panel1.Controls.Add(this.chkProveedor);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.chkCliente);
            this.panel1.Controls.Add(this.txtValorPorAplicar);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtNroLote);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnAplicarValor);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 71);
            this.panel1.TabIndex = 0;
            // 
            // btnActualiza
            // 
            this.btnActualiza.BackgroundImage = global::pendiDcmto.Properties.Resources.Rehacer;
            this.btnActualiza.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnActualiza.FlatAppearance.BorderSize = 0;
            this.btnActualiza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualiza.ForeColor = System.Drawing.Color.White;
            this.btnActualiza.Location = new System.Drawing.Point(420, 41);
            this.btnActualiza.Name = "btnActualiza";
            this.btnActualiza.Size = new System.Drawing.Size(24, 24);
            this.btnActualiza.TabIndex = 97;
            this.btnActualiza.UseVisualStyleBackColor = true;
            this.btnActualiza.Click += new System.EventHandler(this.btnActualiza_Click);
            // 
            // chkAutorizados
            // 
            this.chkAutorizados.AutoSize = true;
            this.chkAutorizados.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutorizados.ForeColor = System.Drawing.Color.White;
            this.chkAutorizados.Location = new System.Drawing.Point(289, 46);
            this.chkAutorizados.Name = "chkAutorizados";
            this.chkAutorizados.Size = new System.Drawing.Size(108, 18);
            this.chkAutorizados.TabIndex = 95;
            this.chkAutorizados.Text = "Solo Autorizados";
            this.chkAutorizados.UseVisualStyleBackColor = true;
            this.chkAutorizados.CheckedChanged += new System.EventHandler(this.chkCliente_CheckedChanged);
            // 
            // chkAnticipo
            // 
            this.chkAnticipo.AutoSize = true;
            this.chkAnticipo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAnticipo.ForeColor = System.Drawing.Color.White;
            this.chkAnticipo.Location = new System.Drawing.Point(216, 46);
            this.chkAnticipo.Name = "chkAnticipo";
            this.chkAnticipo.Size = new System.Drawing.Size(71, 18);
            this.chkAnticipo.TabIndex = 94;
            this.chkAnticipo.Text = "Anticipos";
            this.chkAnticipo.UseVisualStyleBackColor = true;
            this.chkAnticipo.CheckedChanged += new System.EventHandler(this.chkCliente_CheckedChanged);
            // 
            // chkProveedor
            // 
            this.chkProveedor.AutoSize = true;
            this.chkProveedor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkProveedor.ForeColor = System.Drawing.Color.White;
            this.chkProveedor.Location = new System.Drawing.Point(104, 46);
            this.chkProveedor.Name = "chkProveedor";
            this.chkProveedor.Size = new System.Drawing.Size(110, 18);
            this.chkProveedor.TabIndex = 93;
            this.chkProveedor.Text = "Doc.Proveedores";
            this.chkProveedor.UseVisualStyleBackColor = true;
            this.chkProveedor.CheckedChanged += new System.EventHandler(this.chkCliente_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(491, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Valor a aplicar :";
            // 
            // chkCliente
            // 
            this.chkCliente.AutoSize = true;
            this.chkCliente.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCliente.ForeColor = System.Drawing.Color.White;
            this.chkCliente.Location = new System.Drawing.Point(14, 46);
            this.chkCliente.Name = "chkCliente";
            this.chkCliente.Size = new System.Drawing.Size(86, 18);
            this.chkCliente.TabIndex = 92;
            this.chkCliente.Text = "Doc.Clientes";
            this.chkCliente.UseVisualStyleBackColor = true;
            this.chkCliente.CheckedChanged += new System.EventHandler(this.chkCliente_CheckedChanged);
            // 
            // txtValorPorAplicar
            // 
            this.txtValorPorAplicar.Location = new System.Drawing.Point(577, 43);
            this.txtValorPorAplicar.Name = "txtValorPorAplicar";
            this.txtValorPorAplicar.Size = new System.Drawing.Size(66, 20);
            this.txtValorPorAplicar.TabIndex = 3;
            this.txtValorPorAplicar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtValort_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(675, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 91;
            this.label5.Text = "Nro.Lote :";
            // 
            // txtNroLote
            // 
            this.txtNroLote.Location = new System.Drawing.Point(728, 46);
            this.txtNroLote.Name = "txtNroLote";
            this.txtNroLote.Size = new System.Drawing.Size(53, 20);
            this.txtNroLote.TabIndex = 90;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(791, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "DOCUMENTOS CON SALDOS PENDIENTES";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnAplicarValor
            // 
            this.btnAplicarValor.FlatAppearance.BorderSize = 0;
            this.btnAplicarValor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicarValor.ForeColor = System.Drawing.Color.White;
            this.btnAplicarValor.Image = ((System.Drawing.Image)(resources.GetObject("btnAplicarValor.Image")));
            this.btnAplicarValor.Location = new System.Drawing.Point(644, 44);
            this.btnAplicarValor.Name = "btnAplicarValor";
            this.btnAplicarValor.Size = new System.Drawing.Size(20, 18);
            this.btnAplicarValor.TabIndex = 96;
            this.toolTip1.SetToolTip(this.btnAplicarValor, "Presione este boton para aplicar automáticamente este valor");
            this.btnAplicarValor.UseVisualStyleBackColor = true;
            this.btnAplicarValor.Click += new System.EventHandler(this.btnAplicarValor_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.Controls.Add(this.btnBorraAplicar);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtTotalPendiente);
            this.panel2.Controls.Add(this.txtValorAplicado);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Controls.Add(this.btnAceptar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 317);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(791, 42);
            this.panel2.TabIndex = 1;
            // 
            // btnBorraAplicar
            // 
            this.btnBorraAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorraAplicar.ForeColor = System.Drawing.Color.White;
            this.btnBorraAplicar.Location = new System.Drawing.Point(9, 7);
            this.btnBorraAplicar.Name = "btnBorraAplicar";
            this.btnBorraAplicar.Size = new System.Drawing.Size(87, 28);
            this.btnBorraAplicar.TabIndex = 8;
            this.btnBorraAplicar.Text = "BorraAplicar";
            this.btnBorraAplicar.UseVisualStyleBackColor = true;
            this.btnBorraAplicar.Click += new System.EventHandler(this.btnBorraAplicar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(391, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Saldos pendientes :";
            // 
            // txtTotalPendiente
            // 
            this.txtTotalPendiente.Location = new System.Drawing.Point(496, 11);
            this.txtTotalPendiente.Name = "txtTotalPendiente";
            this.txtTotalPendiente.Size = new System.Drawing.Size(100, 20);
            this.txtTotalPendiente.TabIndex = 6;
            // 
            // txtValorAplicado
            // 
            this.txtValorAplicado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValorAplicado.Location = new System.Drawing.Point(679, 11);
            this.txtValorAplicado.Name = "txtValorAplicado";
            this.txtValorAplicado.Size = new System.Drawing.Size(100, 20);
            this.txtValorAplicado.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(598, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total aplicado :";
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(194, 6);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 28);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(101, 6);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(87, 28);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // Malla
            // 
            this.Malla.AllowUserToAddRows = false;
            this.Malla.AllowUserToResizeColumns = false;
            this.Malla.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Malla.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Malla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Malla.BackgroundColor = System.Drawing.Color.White;
            this.Malla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Malla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Malla.GridColor = System.Drawing.Color.Gainsboro;
            this.Malla.Location = new System.Drawing.Point(0, 71);
            this.Malla.MultiSelect = false;
            this.Malla.Name = "Malla";
            this.Malla.Size = new System.Drawing.Size(791, 246);
            this.Malla.TabIndex = 2;
            this.Malla.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Malla_CellContentClick);
            this.Malla.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Malla_CellEndEdit);
            this.Malla.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.Malla_CellLeave);
            this.Malla.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.Malla_DataError);
            this.Malla.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Malla_KeyDown);
            // 
            // frmDocPndt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(791, 359);
            this.ControlBox = false;
            this.Controls.Add(this.Malla);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDocPndt";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Malla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridView Malla;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtValorPorAplicar;
        private System.Windows.Forms.TextBox txtValorAplicado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNroLote;
        private System.Windows.Forms.CheckBox chkAutorizados;
        private System.Windows.Forms.CheckBox chkAnticipo;
        private System.Windows.Forms.CheckBox chkProveedor;
        private System.Windows.Forms.CheckBox chkCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalPendiente;
        private System.Windows.Forms.Button btnAplicarValor;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnBorraAplicar;
        private System.Windows.Forms.Button btnActualiza;
    }
}

