namespace DctosEmi
{
    partial class emiFacPed
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(emiFacPed));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.Label10 = new System.Windows.Forms.Label();
			this.txtNumDoc = new System.Windows.Forms.TextBox();
			this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
			this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnAceptar = new System.Windows.Forms.ToolStripButton();
			this.btnBuscar = new System.Windows.Forms.ToolStripButton();
			this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnSalir = new System.Windows.Forms.ToolStripButton();
			this.cboSucursal = new System.Windows.Forms.ComboBox();
			this.Label7 = new System.Windows.Forms.Label();
			this.Panel1 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.dateHasta = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.dateDesde = new System.Windows.Forms.DateTimePicker();
			this.cboTipoDoc = new System.Windows.Forms.ComboBox();
			this.Label6 = new System.Windows.Forms.Label();
			this.malla = new System.Windows.Forms.DataGridView();
			this.TableLayoutPanel1.SuspendLayout();
			this.ToolStrip1.SuspendLayout();
			this.Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.malla)).BeginInit();
			this.SuspendLayout();
			// 
			// Label10
			// 
			this.Label10.AutoSize = true;
			this.Label10.Location = new System.Drawing.Point(430, 5);
			this.Label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Label10.Name = "Label10";
			this.Label10.Size = new System.Drawing.Size(109, 17);
			this.Label10.TabIndex = 61;
			this.Label10.Text = "Número de lote:";
			this.Label10.Visible = false;
			// 
			// txtNumDoc
			// 
			this.txtNumDoc.Location = new System.Drawing.Point(537, 0);
			this.txtNumDoc.Margin = new System.Windows.Forms.Padding(4);
			this.txtNumDoc.Name = "txtNumDoc";
			this.txtNumDoc.Size = new System.Drawing.Size(135, 22);
			this.txtNumDoc.TabIndex = 62;
			this.txtNumDoc.Visible = false;
			// 
			// TableLayoutPanel1
			// 
			this.TableLayoutPanel1.BackColor = System.Drawing.Color.LightSteelBlue;
			this.TableLayoutPanel1.ColumnCount = 1;
			this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.35294F));
			this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.64706F));
			this.TableLayoutPanel1.Controls.Add(this.ToolStrip1, 0, 0);
			this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 64);
			this.TableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
			this.TableLayoutPanel1.Name = "TableLayoutPanel1";
			this.TableLayoutPanel1.RowCount = 1;
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.TableLayoutPanel1.Size = new System.Drawing.Size(1051, 47);
			this.TableLayoutPanel1.TabIndex = 7;
			// 
			// ToolStrip1
			// 
			this.ToolStrip1.BackColor = System.Drawing.Color.DimGray;
			this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ToolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripSeparator2,
            this.btnAceptar,
            this.btnBuscar,
            this.ToolStripSeparator1,
            this.btnSalir});
			this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
			this.ToolStrip1.Name = "ToolStrip1";
			this.ToolStrip1.Size = new System.Drawing.Size(1051, 31);
			this.ToolStrip1.TabIndex = 1;
			this.ToolStrip1.Text = "ToolStrip1";
			// 
			// ToolStripSeparator2
			// 
			this.ToolStripSeparator2.Name = "ToolStripSeparator2";
			this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 31);
			// 
			// btnAceptar
			// 
			this.btnAceptar.ForeColor = System.Drawing.Color.White;
			this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
			this.btnAceptar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(89, 28);
			this.btnAceptar.Text = "Aceptar";
			this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnAceptar.ToolTipText = "Crear una factura con el pedido escojido";
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			// 
			// btnBuscar
			// 
			this.btnBuscar.ForeColor = System.Drawing.Color.White;
			this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
			this.btnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(103, 28);
			this.btnBuscar.Text = "Actualizar";
			this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnBuscar.ToolTipText = "Leer nuevos pedidos si existen";
			this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
			// 
			// ToolStripSeparator1
			// 
			this.ToolStripSeparator1.ForeColor = System.Drawing.Color.White;
			this.ToolStripSeparator1.Name = "ToolStripSeparator1";
			this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 31);
			// 
			// btnSalir
			// 
			this.btnSalir.ForeColor = System.Drawing.Color.White;
			this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
			this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSalir.Name = "btnSalir";
			this.btnSalir.Size = new System.Drawing.Size(66, 28);
			this.btnSalir.Text = "Salir";
			this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
			// 
			// cboSucursal
			// 
			this.cboSucursal.FormattingEnabled = true;
			this.cboSucursal.Location = new System.Drawing.Point(105, 2);
			this.cboSucursal.Margin = new System.Windows.Forms.Padding(4);
			this.cboSucursal.Name = "cboSucursal";
			this.cboSucursal.Size = new System.Drawing.Size(317, 24);
			this.cboSucursal.TabIndex = 3;
			// 
			// Label7
			// 
			this.Label7.AutoSize = true;
			this.Label7.Location = new System.Drawing.Point(29, 12);
			this.Label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Label7.Name = "Label7";
			this.Label7.Size = new System.Drawing.Size(67, 17);
			this.Label7.TabIndex = 49;
			this.Label7.Text = "Sucursal:";
			// 
			// Panel1
			// 
			this.Panel1.BackColor = System.Drawing.Color.DimGray;
			this.Panel1.Controls.Add(this.label2);
			this.Panel1.Controls.Add(this.dateHasta);
			this.Panel1.Controls.Add(this.label1);
			this.Panel1.Controls.Add(this.dateDesde);
			this.Panel1.Controls.Add(this.txtNumDoc);
			this.Panel1.Controls.Add(this.Label10);
			this.Panel1.Controls.Add(this.cboTipoDoc);
			this.Panel1.Controls.Add(this.Label6);
			this.Panel1.Controls.Add(this.cboSucursal);
			this.Panel1.Controls.Add(this.Label7);
			this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.Panel1.ForeColor = System.Drawing.Color.White;
			this.Panel1.Location = new System.Drawing.Point(0, 0);
			this.Panel1.Margin = new System.Windows.Forms.Padding(4);
			this.Panel1.Name = "Panel1";
			this.Panel1.Size = new System.Drawing.Size(1051, 64);
			this.Panel1.TabIndex = 8;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(736, 34);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(28, 17);
			this.label2.TabIndex = 66;
			this.label2.Text = "Al: ";
			// 
			// dateHasta
			// 
			this.dateHasta.CustomFormat = "dd/MM/yyyy";
			this.dateHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateHasta.Location = new System.Drawing.Point(764, 31);
			this.dateHasta.Margin = new System.Windows.Forms.Padding(4);
			this.dateHasta.Name = "dateHasta";
			this.dateHasta.Size = new System.Drawing.Size(127, 22);
			this.dateHasta.TabIndex = 65;
			this.dateHasta.ValueChanged += new System.EventHandler(this.dateHasta_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(561, 34);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(37, 17);
			this.label1.TabIndex = 64;
			this.label1.Text = "Del: ";
			// 
			// dateDesde
			// 
			this.dateDesde.CustomFormat = "dd/MM/yyyy";
			this.dateDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateDesde.Location = new System.Drawing.Point(600, 31);
			this.dateDesde.Margin = new System.Windows.Forms.Padding(4);
			this.dateDesde.Name = "dateDesde";
			this.dateDesde.Size = new System.Drawing.Size(127, 22);
			this.dateDesde.TabIndex = 63;
			this.dateDesde.ValueChanged += new System.EventHandler(this.dateDesde_ValueChanged);
			// 
			// cboTipoDoc
			// 
			this.cboTipoDoc.FormattingEnabled = true;
			this.cboTipoDoc.Location = new System.Drawing.Point(105, 30);
			this.cboTipoDoc.Margin = new System.Windows.Forms.Padding(4);
			this.cboTipoDoc.Name = "cboTipoDoc";
			this.cboTipoDoc.Size = new System.Drawing.Size(317, 24);
			this.cboTipoDoc.TabIndex = 0;
			// 
			// Label6
			// 
			this.Label6.AutoSize = true;
			this.Label6.Location = new System.Drawing.Point(9, 37);
			this.Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(89, 17);
			this.Label6.TabIndex = 47;
			this.Label6.Text = "Tipo de Doc.";
			// 
			// malla
			// 
			this.malla.AllowUserToAddRows = false;
			this.malla.AllowUserToDeleteRows = false;
			this.malla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.malla.BackgroundColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.malla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.malla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.malla.Dock = System.Windows.Forms.DockStyle.Fill;
			this.malla.EnableHeadersVisualStyles = false;
			this.malla.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.malla.Location = new System.Drawing.Point(0, 111);
			this.malla.Margin = new System.Windows.Forms.Padding(4);
			this.malla.Name = "malla";
			this.malla.ReadOnly = true;
			this.malla.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.malla.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.malla.RowHeadersWidth = 20;
			this.malla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.malla.Size = new System.Drawing.Size(1051, 561);
			this.malla.TabIndex = 9;
			this.malla.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellContentClick);
			this.malla.DoubleClick += new System.EventHandler(this.malla_DoubleClick);
			// 
			// emiFacPed
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1051, 672);
			this.Controls.Add(this.malla);
			this.Controls.Add(this.TableLayoutPanel1);
			this.Controls.Add(this.Panel1);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "emiFacPed";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FACTURACION PEDIDOS DE CLIENTES";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.TableLayoutPanel1.ResumeLayout(false);
			this.TableLayoutPanel1.PerformLayout();
			this.ToolStrip1.ResumeLayout(false);
			this.ToolStrip1.PerformLayout();
			this.Panel1.ResumeLayout(false);
			this.Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.malla)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.TextBox txtNumDoc;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        internal System.Windows.Forms.ToolStripButton btnAceptar;
        internal System.Windows.Forms.ToolStripButton btnBuscar;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton btnSalir;
        internal System.Windows.Forms.ComboBox cboSucursal;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.DataGridView malla;
        internal System.Windows.Forms.ComboBox cboTipoDoc;
        internal System.Windows.Forms.Label Label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateHasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateDesde;
    }
}

