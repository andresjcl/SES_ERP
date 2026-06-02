namespace DaxInvent
{
    partial class frmBuscaArticuloSimple
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscaArticuloSimple));
			this.malla = new System.Windows.Forms.DataGridView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.chkSoloVenta = new System.Windows.Forms.CheckBox();
			this.chkOrdenCodigo = new System.Windows.Forms.RadioButton();
			this.chkOrdenAlfabetico = new System.Windows.Forms.RadioButton();
			this.cmbGrupo = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cmbClase = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cmbCategoria = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnBuscar = new System.Windows.Forms.Button();
			this.btnSalida = new System.Windows.Forms.Button();
			this.btnComercial = new System.Windows.Forms.Button();
			this.btnDetalle = new System.Windows.Forms.Button();
			this.btnCompatibles = new System.Windows.Forms.Button();
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
			this.malla.Location = new System.Drawing.Point(0, 202);
			this.malla.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.malla.Name = "malla";
			this.malla.ReadOnly = true;
			this.malla.RowHeadersWidth = 51;
			this.malla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.malla.Size = new System.Drawing.Size(831, 478);
			this.malla.TabIndex = 1;
			this.malla.DoubleClick += new System.EventHandler(this.malla_DoubleClick);
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.groupBox1.Controls.Add(this.chkSoloVenta);
			this.groupBox1.Controls.Add(this.chkOrdenCodigo);
			this.groupBox1.Controls.Add(this.chkOrdenAlfabetico);
			this.groupBox1.Controls.Add(this.cmbGrupo);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.cmbClase);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.cmbCategoria);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox1.Size = new System.Drawing.Size(831, 111);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			// 
			// chkSoloVenta
			// 
			this.chkSoloVenta.AutoSize = true;
			this.chkSoloVenta.Checked = true;
			this.chkSoloVenta.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkSoloVenta.ForeColor = System.Drawing.Color.White;
			this.chkSoloVenta.Location = new System.Drawing.Point(379, 75);
			this.chkSoloVenta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.chkSoloVenta.Name = "chkSoloVenta";
			this.chkSoloVenta.Size = new System.Drawing.Size(209, 24);
			this.chkSoloVenta.TabIndex = 26;
			this.chkSoloVenta.Text = "&Solo artículos para venta";
			this.chkSoloVenta.UseVisualStyleBackColor = true;
			this.chkSoloVenta.CheckedChanged += new System.EventHandler(this.chkOrdenCodigo_CheckedChanged);
			// 
			// chkOrdenCodigo
			// 
			this.chkOrdenCodigo.AutoSize = true;
			this.chkOrdenCodigo.ForeColor = System.Drawing.Color.White;
			this.chkOrdenCodigo.Location = new System.Drawing.Point(197, 75);
			this.chkOrdenCodigo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.chkOrdenCodigo.Name = "chkOrdenCodigo";
			this.chkOrdenCodigo.Size = new System.Drawing.Size(132, 24);
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
			this.chkOrdenAlfabetico.Location = new System.Drawing.Point(19, 75);
			this.chkOrdenAlfabetico.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.chkOrdenAlfabetico.Name = "chkOrdenAlfabetico";
			this.chkOrdenAlfabetico.Size = new System.Drawing.Size(153, 24);
			this.chkOrdenAlfabetico.TabIndex = 24;
			this.chkOrdenAlfabetico.TabStop = true;
			this.chkOrdenAlfabetico.Text = "Orden Alfa&bético";
			this.chkOrdenAlfabetico.UseVisualStyleBackColor = true;
			this.chkOrdenAlfabetico.CheckedChanged += new System.EventHandler(this.chkOrdenCodigo_CheckedChanged);
			// 
			// cmbGrupo
			// 
			this.cmbGrupo.ForeColor = System.Drawing.Color.Black;
			this.cmbGrupo.FormattingEnabled = true;
			this.cmbGrupo.Location = new System.Drawing.Point(561, 38);
			this.cmbGrupo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmbGrupo.Name = "cmbGrupo";
			this.cmbGrupo.Size = new System.Drawing.Size(268, 28);
			this.cmbGrupo.TabIndex = 19;
			this.cmbGrupo.SelectedIndexChanged += new System.EventHandler(this.btnBuscar_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.White;
			this.label5.Location = new System.Drawing.Point(674, 18);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(55, 20);
			this.label5.TabIndex = 18;
			this.label5.Text = "Grupo";
			// 
			// cmbClase
			// 
			this.cmbClase.ForeColor = System.Drawing.Color.Black;
			this.cmbClase.FormattingEnabled = true;
			this.cmbClase.Location = new System.Drawing.Point(287, 38);
			this.cmbClase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmbClase.Name = "cmbClase";
			this.cmbClase.Size = new System.Drawing.Size(268, 28);
			this.cmbClase.TabIndex = 17;
			this.cmbClase.SelectedIndexChanged += new System.EventHandler(this.btnBuscar_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.White;
			this.label4.Location = new System.Drawing.Point(405, 18);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(52, 20);
			this.label4.TabIndex = 16;
			this.label4.Text = "Clase";
			// 
			// cmbCategoria
			// 
			this.cmbCategoria.ForeColor = System.Drawing.Color.Black;
			this.cmbCategoria.FormattingEnabled = true;
			this.cmbCategoria.Location = new System.Drawing.Point(12, 38);
			this.cmbCategoria.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmbCategoria.Name = "cmbCategoria";
			this.cmbCategoria.Size = new System.Drawing.Size(268, 28);
			this.cmbCategoria.TabIndex = 15;
			this.cmbCategoria.SelectedIndexChanged += new System.EventHandler(this.btnBuscar_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(134, 18);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(81, 20);
			this.label3.TabIndex = 14;
			this.label3.Text = "Categoría";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.panel1.Controls.Add(this.btnBuscar);
			this.panel1.Controls.Add(this.btnSalida);
			this.panel1.Controls.Add(this.btnComercial);
			this.panel1.Controls.Add(this.btnDetalle);
			this.panel1.Controls.Add(this.btnCompatibles);
			this.panel1.Controls.Add(this.txtDescripcion);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 111);
			this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(831, 91);
			this.panel1.TabIndex = 3;
			// 
			// btnBuscar
			// 
			this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnBuscar.ForeColor = System.Drawing.Color.White;
			this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
			this.btnBuscar.Location = new System.Drawing.Point(-9, 55);
			this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(30, 31);
			this.btnBuscar.TabIndex = 44;
			this.btnBuscar.UseVisualStyleBackColor = false;
			this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
			// 
			// btnSalida
			// 
			this.btnSalida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSalida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.btnSalida.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSalida.ForeColor = System.Drawing.Color.White;
			this.btnSalida.Location = new System.Drawing.Point(696, 32);
			this.btnSalida.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnSalida.Name = "btnSalida";
			this.btnSalida.Size = new System.Drawing.Size(127, 52);
			this.btnSalida.TabIndex = 43;
			this.btnSalida.Text = "Cancelar";
			this.btnSalida.UseVisualStyleBackColor = false;
			this.btnSalida.Click += new System.EventHandler(this.btnSalida_Click);
			// 
			// btnComercial
			// 
			this.btnComercial.BackColor = System.Drawing.Color.White;
			this.btnComercial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnComercial.ForeColor = System.Drawing.Color.SteelBlue;
			this.btnComercial.Location = new System.Drawing.Point(327, 9);
			this.btnComercial.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnComercial.Name = "btnComercial";
			this.btnComercial.Size = new System.Drawing.Size(158, 39);
			this.btnComercial.TabIndex = 42;
			this.btnComercial.Text = "C&omercial";
			this.toolTip1.SetToolTip(this.btnComercial, "Consultar precios,saldos y existencia");
			this.btnComercial.UseVisualStyleBackColor = false;
			this.btnComercial.Click += new System.EventHandler(this.btnComercial_Click);
			// 
			// btnDetalle
			// 
			this.btnDetalle.BackColor = System.Drawing.Color.White;
			this.btnDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDetalle.ForeColor = System.Drawing.Color.SteelBlue;
			this.btnDetalle.Location = new System.Drawing.Point(168, 9);
			this.btnDetalle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnDetalle.Name = "btnDetalle";
			this.btnDetalle.Size = new System.Drawing.Size(158, 39);
			this.btnDetalle.TabIndex = 39;
			this.btnDetalle.Text = "&Detalle";
			this.toolTip1.SetToolTip(this.btnDetalle, "Visualizar el detalle ampliado");
			this.btnDetalle.UseVisualStyleBackColor = false;
			this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
			// 
			// btnCompatibles
			// 
			this.btnCompatibles.BackColor = System.Drawing.Color.White;
			this.btnCompatibles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCompatibles.ForeColor = System.Drawing.Color.SteelBlue;
			this.btnCompatibles.Location = new System.Drawing.Point(9, 9);
			this.btnCompatibles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnCompatibles.Name = "btnCompatibles";
			this.btnCompatibles.Size = new System.Drawing.Size(158, 39);
			this.btnCompatibles.TabIndex = 36;
			this.btnCompatibles.Text = "&Compatibles";
			this.toolTip1.SetToolTip(this.btnCompatibles, "Lista de artículos compatibles ");
			this.btnCompatibles.UseVisualStyleBackColor = false;
			// 
			// txtDescripcion
			// 
			this.txtDescripcion.Location = new System.Drawing.Point(39, 55);
			this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtDescripcion.Name = "txtDescripcion";
			this.txtDescripcion.Size = new System.Drawing.Size(638, 26);
			this.txtDescripcion.TabIndex = 25;
			this.toolTip1.SetToolTip(this.txtDescripcion, "Digite un texto para muestra de busqueda \\n Utilize \"%\" como separador para busca" +
        "r con varios textos");
			this.txtDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyDown);
			// 
			// frmBuscaArticuloSimple
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LightSteelBlue;
			this.CancelButton = this.btnSalida;
			this.ClientSize = new System.Drawing.Size(831, 680);
			this.ControlBox = false;
			this.Controls.Add(this.malla);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.HelpButton = true;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "frmBuscaArticuloSimple";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "BUSQUEDA DE ARTICULOS ";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBuscaArticuloSimple_FormClosing);
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
        private System.Windows.Forms.ComboBox cmbClase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkSoloVenta;
        private System.Windows.Forms.RadioButton chkOrdenCodigo;
        private System.Windows.Forms.RadioButton chkOrdenAlfabetico;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnSalida;
        private System.Windows.Forms.Button btnComercial;
        private System.Windows.Forms.Button btnDetalle;
        private System.Windows.Forms.Button btnCompatibles;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox cmbGrupo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBuscar;
    }
}