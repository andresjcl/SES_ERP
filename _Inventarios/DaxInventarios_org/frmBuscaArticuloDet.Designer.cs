namespace DaxInvent
{
    partial class frmBuscaArticuloDet
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.malla = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkConIva = new System.Windows.Forms.CheckBox();
            this.chkSoloExistencia = new System.Windows.Forms.CheckBox();
            this.chkSoloVenta = new System.Windows.Forms.CheckBox();
            this.chkOrdenCodigo = new System.Windows.Forms.RadioButton();
            this.chkOrdenAlfabetico = new System.Windows.Forms.RadioButton();
            this.cmbSubgrupo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbGrupo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbClase = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalida = new System.Windows.Forms.Button();
            this.btnPropieddades = new System.Windows.Forms.Button();
            this.btnPendientes = new System.Windows.Forms.Button();
            this.btnMovimiento = new System.Windows.Forms.Button();
            this.btnDetalle = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnCompras = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.malla)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // malla
            // 
            this.malla.AllowUserToAddRows = false;
            this.malla.AllowUserToDeleteRows = false;
            this.malla.AllowUserToOrderColumns = true;
            this.malla.AllowUserToResizeColumns = false;
            this.malla.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.malla.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.malla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.malla.BackgroundColor = System.Drawing.Color.White;
            this.malla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.malla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.malla.GridColor = System.Drawing.Color.Silver;
            this.malla.Location = new System.Drawing.Point(0, 162);
            this.malla.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.malla.Name = "malla";
            this.malla.ReadOnly = true;
            this.malla.RowHeadersWidth = 51;
            this.malla.Size = new System.Drawing.Size(1252, 371);
            this.malla.TabIndex = 1;
            this.malla.DoubleClick += new System.EventHandler(this.malla_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Controls.Add(this.chkConIva);
            this.groupBox1.Controls.Add(this.chkSoloExistencia);
            this.groupBox1.Controls.Add(this.chkSoloVenta);
            this.groupBox1.Controls.Add(this.chkOrdenCodigo);
            this.groupBox1.Controls.Add(this.chkOrdenAlfabetico);
            this.groupBox1.Controls.Add(this.cmbSubgrupo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbGrupo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbClase);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbCategoria);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1252, 89);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // chkConIva
            // 
            this.chkConIva.AutoSize = true;
            this.chkConIva.Checked = true;
            this.chkConIva.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConIva.ForeColor = System.Drawing.Color.White;
            this.chkConIva.Location = new System.Drawing.Point(789, 60);
            this.chkConIva.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkConIva.Name = "chkConIva";
            this.chkConIva.Size = new System.Drawing.Size(126, 21);
            this.chkConIva.TabIndex = 28;
            this.chkConIva.Text = "Precios con &Iva";
            this.chkConIva.UseVisualStyleBackColor = true;
            this.chkConIva.CheckedChanged += new System.EventHandler(this.chkOrdenCodigo_CheckedChanged);
            // 
            // chkSoloExistencia
            // 
            this.chkSoloExistencia.AutoSize = true;
            this.chkSoloExistencia.ForeColor = System.Drawing.Color.White;
            this.chkSoloExistencia.Location = new System.Drawing.Point(551, 60);
            this.chkSoloExistencia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkSoloExistencia.Name = "chkSoloExistencia";
            this.chkSoloExistencia.Size = new System.Drawing.Size(208, 21);
            this.chkSoloExistencia.TabIndex = 27;
            this.chkSoloExistencia.Text = "Solo artículos con e&xistencia";
            this.chkSoloExistencia.UseVisualStyleBackColor = true;
            this.chkSoloExistencia.CheckedChanged += new System.EventHandler(this.chkOrdenCodigo_CheckedChanged);
            // 
            // chkSoloVenta
            // 
            this.chkSoloVenta.AutoSize = true;
            this.chkSoloVenta.Checked = true;
            this.chkSoloVenta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSoloVenta.ForeColor = System.Drawing.Color.White;
            this.chkSoloVenta.Location = new System.Drawing.Point(337, 60);
            this.chkSoloVenta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkSoloVenta.Name = "chkSoloVenta";
            this.chkSoloVenta.Size = new System.Drawing.Size(187, 21);
            this.chkSoloVenta.TabIndex = 26;
            this.chkSoloVenta.Text = "&Solo artículos para venta";
            this.chkSoloVenta.UseVisualStyleBackColor = true;
            this.chkSoloVenta.CheckedChanged += new System.EventHandler(this.chkOrdenCodigo_CheckedChanged);
            // 
            // chkOrdenCodigo
            // 
            this.chkOrdenCodigo.AutoSize = true;
            this.chkOrdenCodigo.ForeColor = System.Drawing.Color.White;
            this.chkOrdenCodigo.Location = new System.Drawing.Point(175, 60);
            this.chkOrdenCodigo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkOrdenCodigo.Name = "chkOrdenCodigo";
            this.chkOrdenCodigo.Size = new System.Drawing.Size(117, 21);
            this.chkOrdenCodigo.TabIndex = 25;
            this.chkOrdenCodigo.Text = "Orden Códi&go";
            this.chkOrdenCodigo.UseVisualStyleBackColor = true;
            this.chkOrdenCodigo.CheckedChanged += new System.EventHandler(this.chkOrdenCodigo_CheckedChanged);
            // 
            // chkOrdenAlfabetico
            // 
            this.chkOrdenAlfabetico.AutoSize = true;
            this.chkOrdenAlfabetico.Checked = true;
            this.chkOrdenAlfabetico.ForeColor = System.Drawing.Color.White;
            this.chkOrdenAlfabetico.Location = new System.Drawing.Point(17, 60);
            this.chkOrdenAlfabetico.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkOrdenAlfabetico.Name = "chkOrdenAlfabetico";
            this.chkOrdenAlfabetico.Size = new System.Drawing.Size(135, 21);
            this.chkOrdenAlfabetico.TabIndex = 24;
            this.chkOrdenAlfabetico.TabStop = true;
            this.chkOrdenAlfabetico.Text = "Orden Alfa&bético";
            this.chkOrdenAlfabetico.UseVisualStyleBackColor = true;
            this.chkOrdenAlfabetico.CheckedChanged += new System.EventHandler(this.chkOrdenCodigo_CheckedChanged);
            // 
            // cmbSubgrupo
            // 
            this.cmbSubgrupo.ForeColor = System.Drawing.Color.Black;
            this.cmbSubgrupo.FormattingEnabled = true;
            this.cmbSubgrupo.Location = new System.Drawing.Point(939, 30);
            this.cmbSubgrupo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbSubgrupo.Name = "cmbSubgrupo";
            this.cmbSubgrupo.Size = new System.Drawing.Size(305, 24);
            this.cmbSubgrupo.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(1000, 14);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 17);
            this.label6.TabIndex = 20;
            this.label6.Text = "Subgrupo";
            // 
            // cmbGrupo
            // 
            this.cmbGrupo.ForeColor = System.Drawing.Color.Black;
            this.cmbGrupo.FormattingEnabled = true;
            this.cmbGrupo.Location = new System.Drawing.Point(629, 30);
            this.cmbGrupo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbGrupo.Name = "cmbGrupo";
            this.cmbGrupo.Size = new System.Drawing.Size(305, 24);
            this.cmbGrupo.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(729, 14);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "Grupo";
            // 
            // cmbClase
            // 
            this.cmbClase.ForeColor = System.Drawing.Color.Black;
            this.cmbClase.FormattingEnabled = true;
            this.cmbClase.Location = new System.Drawing.Point(320, 30);
            this.cmbClase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbClase.Name = "cmbClase";
            this.cmbClase.Size = new System.Drawing.Size(305, 24);
            this.cmbClase.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(435, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Clase";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.ForeColor = System.Drawing.Color.Black;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(11, 30);
            this.cmbCategoria.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(305, 24);
            this.cmbCategoria.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(127, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Categoría";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.btnSalida);
            this.panel1.Controls.Add(this.btnPropieddades);
            this.panel1.Controls.Add(this.btnPendientes);
            this.panel1.Controls.Add(this.btnMovimiento);
            this.panel1.Controls.Add(this.btnDetalle);
            this.panel1.Controls.Add(this.btnVentas);
            this.panel1.Controls.Add(this.btnCompras);
            this.panel1.Controls.Add(this.txtDescripcion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 89);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1252, 73);
            this.panel1.TabIndex = 3;
            // 
            // btnSalida
            // 
            this.btnSalida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalida.ForeColor = System.Drawing.Color.White;
            this.btnSalida.Location = new System.Drawing.Point(1129, 23);
            this.btnSalida.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSalida.Name = "btnSalida";
            this.btnSalida.Size = new System.Drawing.Size(113, 42);
            this.btnSalida.TabIndex = 43;
            this.btnSalida.Text = "Continua&r";
            this.btnSalida.UseVisualStyleBackColor = false;
            this.btnSalida.Click += new System.EventHandler(this.btnSalida_Click);
            // 
            // btnPropieddades
            // 
            this.btnPropieddades.BackColor = System.Drawing.Color.White;
            this.btnPropieddades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPropieddades.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPropieddades.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnPropieddades.Location = new System.Drawing.Point(156, 7);
            this.btnPropieddades.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPropieddades.Name = "btnPropieddades";
            this.btnPropieddades.Size = new System.Drawing.Size(140, 31);
            this.btnPropieddades.TabIndex = 42;
            this.btnPropieddades.Text = "&Propiedades";
            this.toolTip1.SetToolTip(this.btnPropieddades, "Acceso a los datoscompletos de artículo");
            this.btnPropieddades.UseVisualStyleBackColor = true;
            this.btnPropieddades.Click += new System.EventHandler(this.btnPropieddades_Click);
            // 
            // btnPendientes
            // 
            this.btnPendientes.BackColor = System.Drawing.Color.White;
            this.btnPendientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPendientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPendientes.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnPendientes.Location = new System.Drawing.Point(721, 7);
            this.btnPendientes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPendientes.Name = "btnPendientes";
            this.btnPendientes.Size = new System.Drawing.Size(140, 31);
            this.btnPendientes.TabIndex = 41;
            this.btnPendientes.Text = "E&nt.Pendientes";
            this.toolTip1.SetToolTip(this.btnPendientes, "Visualiza las entregas pendientes por pedidos de clientes");
            this.btnPendientes.UseVisualStyleBackColor = false;
            this.btnPendientes.Click += new System.EventHandler(this.btnPendientes_Click);
            // 
            // btnMovimiento
            // 
            this.btnMovimiento.BackColor = System.Drawing.Color.White;
            this.btnMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMovimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMovimiento.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnMovimiento.Location = new System.Drawing.Point(580, 7);
            this.btnMovimiento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMovimiento.Name = "btnMovimiento";
            this.btnMovimiento.Size = new System.Drawing.Size(140, 31);
            this.btnMovimiento.TabIndex = 40;
            this.btnMovimiento.Text = "M&ovimiento";
            this.btnMovimiento.UseVisualStyleBackColor = false;
            this.btnMovimiento.Click += new System.EventHandler(this.btnMovimiento_Click);
            // 
            // btnDetalle
            // 
            this.btnDetalle.BackColor = System.Drawing.Color.White;
            this.btnDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalle.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnDetalle.Location = new System.Drawing.Point(15, 7);
            this.btnDetalle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(140, 31);
            this.btnDetalle.TabIndex = 39;
            this.btnDetalle.Text = "&Detalle";
            this.toolTip1.SetToolTip(this.btnDetalle, "Visualizar el detalle ampliado");
            this.btnDetalle.UseVisualStyleBackColor = false;
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.BackColor = System.Drawing.Color.White;
            this.btnVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentas.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnVentas.Location = new System.Drawing.Point(439, 7);
            this.btnVentas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(140, 31);
            this.btnVentas.TabIndex = 38;
            this.btnVentas.Text = "&Ventas";
            this.btnVentas.UseVisualStyleBackColor = false;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // btnCompras
            // 
            this.btnCompras.BackColor = System.Drawing.Color.White;
            this.btnCompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompras.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnCompras.Location = new System.Drawing.Point(297, 7);
            this.btnCompras.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.Size = new System.Drawing.Size(140, 31);
            this.btnCompras.TabIndex = 37;
            this.btnCompras.Text = "Co&mpras";
            this.btnCompras.UseVisualStyleBackColor = false;
            this.btnCompras.Click += new System.EventHandler(this.btnCompras_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Location = new System.Drawing.Point(16, 44);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(620, 22);
            this.txtDescripcion.TabIndex = 25;
            this.txtDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyDown);
            // 
            // frmBuscaArticuloDet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1252, 533);
            this.ControlBox = false;
            this.Controls.Add(this.malla);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmBuscaArticuloDet";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADCOMDAX - Búsqueda ampliada de artículos";
            this.Load += new System.EventHandler(this.frmBuscaArticuloDet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.malla)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView malla;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbSubgrupo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbGrupo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbClase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkConIva;
        private System.Windows.Forms.CheckBox chkSoloExistencia;
        private System.Windows.Forms.CheckBox chkSoloVenta;
        private System.Windows.Forms.RadioButton chkOrdenCodigo;
        private System.Windows.Forms.RadioButton chkOrdenAlfabetico;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnSalida;
        private System.Windows.Forms.Button btnPropieddades;
        private System.Windows.Forms.Button btnPendientes;
        private System.Windows.Forms.Button btnMovimiento;
        private System.Windows.Forms.Button btnDetalle;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnCompras;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}