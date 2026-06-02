
namespace Buscar
{
    partial class frmBuscar
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscar));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.Panel1 = new System.Windows.Forms.Panel();
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.txtAbrevia = new System.Windows.Forms.TextBox();
			this.chkInicial = new System.Windows.Forms.CheckBox();
			this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
			this._btnAceptar = new System.Windows.Forms.ToolStripButton();
			this._btnActualiza = new System.Windows.Forms.ToolStripButton();
			this._btnCancelar = new System.Windows.Forms.ToolStripButton();
			this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this._btnSalir = new System.Windows.Forms.ToolStripButton();
			this.Panel2 = new System.Windows.Forms.Panel();
			this.gridDatos = new System.Windows.Forms.DataGridView();
			this.Panel1.SuspendLayout();
			this.ToolStrip1.SuspendLayout();
			this.Panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridDatos)).BeginInit();
			this.SuspendLayout();
			// 
			// Panel1
			// 
			this.Panel1.BackColor = System.Drawing.Color.DimGray;
			this.Panel1.Controls.Add(this.txtNombre);
			this.Panel1.Controls.Add(this.Label2);
			this.Panel1.Controls.Add(this.Label1);
			this.Panel1.Controls.Add(this.txtAbrevia);
			this.Panel1.Controls.Add(this.chkInicial);
			this.Panel1.Controls.Add(this.ToolStrip1);
			this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.Panel1.Location = new System.Drawing.Point(0, 0);
			this.Panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Panel1.Name = "Panel1";
			this.Panel1.Size = new System.Drawing.Size(1056, 119);
			this.Panel1.TabIndex = 7;
			// 
			// txtNombre
			// 
			this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNombre.BackColor = System.Drawing.Color.White;
			this.txtNombre.Location = new System.Drawing.Point(172, 82);
			this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Size = new System.Drawing.Size(877, 26);
			this.txtNombre.TabIndex = 15;
			this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
			this.txtNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNombre_KeyDown);
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.ForeColor = System.Drawing.Color.White;
			this.Label2.Location = new System.Drawing.Point(316, 62);
			this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(332, 20);
			this.Label2.TabIndex = 11;
			this.Label2.Text = "Digite una parte de la descripción para buscar";
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.ForeColor = System.Drawing.Color.White;
			this.Label1.Location = new System.Drawing.Point(45, 59);
			this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(63, 20);
			this.Label1.TabIndex = 10;
			this.Label1.Text = "Código:";
			// 
			// txtAbrevia
			// 
			this.txtAbrevia.BackColor = System.Drawing.Color.White;
			this.txtAbrevia.Location = new System.Drawing.Point(4, 82);
			this.txtAbrevia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtAbrevia.Name = "txtAbrevia";
			this.txtAbrevia.Size = new System.Drawing.Size(157, 26);
			this.txtAbrevia.TabIndex = 8;
			this.txtAbrevia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAbrevia_KeyDown);
			// 
			// chkInicial
			// 
			this.chkInicial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkInicial.AutoSize = true;
			this.chkInicial.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkInicial.ForeColor = System.Drawing.Color.Gray;
			this.chkInicial.Location = new System.Drawing.Point(926, 60);
			this.chkInicial.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.chkInicial.Name = "chkInicial";
			this.chkInicial.Size = new System.Drawing.Size(125, 24);
			this.chkInicial.TabIndex = 13;
			this.chkInicial.Text = "BuscarInicial";
			this.chkInicial.UseVisualStyleBackColor = true;
			// 
			// ToolStrip1
			// 
			this.ToolStrip1.BackColor = System.Drawing.Color.DimGray;
			this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ToolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnAceptar,
            this._btnActualiza,
            this._btnCancelar,
            this.ToolStripSeparator1,
            this._btnSalir});
			this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
			this.ToolStrip1.Name = "ToolStrip1";
			this.ToolStrip1.Size = new System.Drawing.Size(1056, 54);
			this.ToolStrip1.TabIndex = 14;
			this.ToolStrip1.Text = "ToolStrip1";
			this.ToolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolStrip1_ItemClicked);
			// 
			// _btnAceptar
			// 
			this._btnAceptar.ForeColor = System.Drawing.Color.White;
			this._btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("_btnAceptar.Image")));
			this._btnAceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this._btnAceptar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._btnAceptar.Name = "_btnAceptar";
			this._btnAceptar.Size = new System.Drawing.Size(77, 49);
			this._btnAceptar.Text = "Aceptar";
			this._btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this._btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this._btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			// 
			// _btnActualiza
			// 
			this._btnActualiza.ForeColor = System.Drawing.Color.White;
			this._btnActualiza.Image = ((System.Drawing.Image)(resources.GetObject("_btnActualiza.Image")));
			this._btnActualiza.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this._btnActualiza.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._btnActualiza.Name = "_btnActualiza";
			this._btnActualiza.Size = new System.Drawing.Size(67, 49);
			this._btnActualiza.Text = "Buscar";
			this._btnActualiza.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this._btnActualiza.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this._btnActualiza.Click += new System.EventHandler(this.btnActualiza_Click);
			// 
			// _btnCancelar
			// 
			this._btnCancelar.ForeColor = System.Drawing.Color.White;
			this._btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("_btnCancelar.Image")));
			this._btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this._btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._btnCancelar.Name = "_btnCancelar";
			this._btnCancelar.Size = new System.Drawing.Size(82, 49);
			this._btnCancelar.Text = "Cancelar";
			this._btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this._btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this._btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// ToolStripSeparator1
			// 
			this.ToolStripSeparator1.Name = "ToolStripSeparator1";
			this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 54);
			// 
			// _btnSalir
			// 
			this._btnSalir.ForeColor = System.Drawing.Color.White;
			this._btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("_btnSalir.Image")));
			this._btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this._btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._btnSalir.Name = "_btnSalir";
			this._btnSalir.Size = new System.Drawing.Size(49, 49);
			this._btnSalir.Text = "Salir";
			this._btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this._btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
			// 
			// Panel2
			// 
			this.Panel2.BackColor = System.Drawing.Color.LightSteelBlue;
			this.Panel2.Controls.Add(this.gridDatos);
			this.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Panel2.Location = new System.Drawing.Point(0, 119);
			this.Panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Panel2.Name = "Panel2";
			this.Panel2.Size = new System.Drawing.Size(1056, 573);
			this.Panel2.TabIndex = 8;
			// 
			// gridDatos
			// 
			this.gridDatos.AllowUserToAddRows = false;
			this.gridDatos.AllowUserToDeleteRows = false;
			this.gridDatos.AllowUserToResizeRows = false;
			this.gridDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.gridDatos.BackgroundColor = System.Drawing.Color.White;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue;
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.gridDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.gridDatos.DefaultCellStyle = dataGridViewCellStyle4;
			this.gridDatos.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridDatos.EnableHeadersVisualStyles = false;
			this.gridDatos.Location = new System.Drawing.Point(0, 0);
			this.gridDatos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gridDatos.Name = "gridDatos";
			this.gridDatos.ReadOnly = true;
			this.gridDatos.RowHeadersWidth = 20;
			this.gridDatos.Size = new System.Drawing.Size(1056, 573);
			this.gridDatos.TabIndex = 0;
			this.gridDatos.DoubleClick += new System.EventHandler(this.gridDatos_DoubleClick);
			// 
			// frmBuscar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1056, 692);
			this.ControlBox = false;
			this.Controls.Add(this.Panel2);
			this.Controls.Add(this.Panel1);
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "frmBuscar";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Buscador ";
			this.Load += new System.EventHandler(this.frmBuscar_Load_1);
			this.Panel1.ResumeLayout(false);
			this.Panel1.PerformLayout();
			this.ToolStrip1.ResumeLayout(false);
			this.ToolStrip1.PerformLayout();
			this.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridDatos)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.TextBox txtNombre;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        private System.Windows.Forms.ToolStripButton _btnAceptar;
        private System.Windows.Forms.ToolStripButton _btnActualiza;
        private System.Windows.Forms.ToolStripButton _btnCancelar;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        private System.Windows.Forms.ToolStripButton _btnSalir;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox txtAbrevia;
        internal System.Windows.Forms.CheckBox chkInicial;
        internal System.Windows.Forms.Panel Panel2;
        private System.Windows.Forms.DataGridView gridDatos;
    }
}

