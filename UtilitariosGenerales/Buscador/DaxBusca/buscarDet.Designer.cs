
namespace Buscar
{
	partial class buscarDet
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(buscarDet));
			this.Panel2 = new System.Windows.Forms.Panel();
			this.gridDatos = new System.Windows.Forms.DataGridView();
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
			this.Panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridDatos)).BeginInit();
			this.Panel1.SuspendLayout();
			this.ToolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// Panel2
			// 
			this.Panel2.BackColor = System.Drawing.Color.LightSteelBlue;
			this.Panel2.Controls.Add(this.gridDatos);
			this.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Panel2.Location = new System.Drawing.Point(0, 77);
			this.Panel2.Name = "Panel2";
			this.Panel2.Size = new System.Drawing.Size(692, 373);
			this.Panel2.TabIndex = 10;
			// 
			// gridDatos
			// 
			this.gridDatos.AllowUserToAddRows = false;
			this.gridDatos.AllowUserToDeleteRows = false;
			this.gridDatos.AllowUserToResizeRows = false;
			this.gridDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.gridDatos.BackgroundColor = System.Drawing.Color.White;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = System.Drawing.Color.SteelBlue;
			dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gridDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
			this.gridDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.gridDatos.DefaultCellStyle = dataGridViewCellStyle6;
			this.gridDatos.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridDatos.EnableHeadersVisualStyles = false;
			this.gridDatos.Location = new System.Drawing.Point(0, 0);
			this.gridDatos.Name = "gridDatos";
			this.gridDatos.ReadOnly = true;
			this.gridDatos.RowHeadersWidth = 20;
			this.gridDatos.Size = new System.Drawing.Size(692, 373);
			this.gridDatos.TabIndex = 0;
			this.gridDatos.DoubleClick += new System.EventHandler(this.gridDatos_DoubleClick);
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
			this.Panel1.Name = "Panel1";
			this.Panel1.Size = new System.Drawing.Size(692, 77);
			this.Panel1.TabIndex = 9;
			// 
			// txtNombre
			// 
			this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNombre.BackColor = System.Drawing.Color.White;
			this.txtNombre.Location = new System.Drawing.Point(5, 53);
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Size = new System.Drawing.Size(574, 20);
			this.txtNombre.TabIndex = 15;
			this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.ForeColor = System.Drawing.Color.White;
			this.Label2.Location = new System.Drawing.Point(2, 40);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(257, 13);
			this.Label2.TabIndex = 11;
			this.Label2.Text = "Digite una parte del nombre del paciente para buscar";
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.ForeColor = System.Drawing.Color.White;
			this.Label1.Location = new System.Drawing.Point(637, 23);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(43, 13);
			this.Label1.TabIndex = 10;
			this.Label1.Text = "Código:";
			this.Label1.Visible = false;
			// 
			// txtAbrevia
			// 
			this.txtAbrevia.BackColor = System.Drawing.Color.White;
			this.txtAbrevia.Location = new System.Drawing.Point(690, 54);
			this.txtAbrevia.Name = "txtAbrevia";
			this.txtAbrevia.Size = new System.Drawing.Size(106, 20);
			this.txtAbrevia.TabIndex = 8;
			this.txtAbrevia.Visible = false;
			this.txtAbrevia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAbrevia_KeyDown);
			// 
			// chkInicial
			// 
			this.chkInicial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkInicial.AutoSize = true;
			this.chkInicial.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkInicial.ForeColor = System.Drawing.Color.Gray;
			this.chkInicial.Location = new System.Drawing.Point(602, 39);
			this.chkInicial.Name = "chkInicial";
			this.chkInicial.Size = new System.Drawing.Size(86, 17);
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
			this.ToolStrip1.Size = new System.Drawing.Size(692, 42);
			this.ToolStrip1.TabIndex = 14;
			this.ToolStrip1.Text = "ToolStrip1";
			// 
			// _btnAceptar
			// 
			this._btnAceptar.ForeColor = System.Drawing.Color.White;
			this._btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("_btnAceptar.Image")));
			this._btnAceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this._btnAceptar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._btnAceptar.Name = "_btnAceptar";
			this._btnAceptar.Size = new System.Drawing.Size(52, 39);
			this._btnAceptar.Text = "Aceptar";
			this._btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this._btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this._btnAceptar.Click += new System.EventHandler(this._btnAceptar_Click);
			// 
			// _btnActualiza
			// 
			this._btnActualiza.ForeColor = System.Drawing.Color.White;
			this._btnActualiza.Image = ((System.Drawing.Image)(resources.GetObject("_btnActualiza.Image")));
			this._btnActualiza.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this._btnActualiza.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._btnActualiza.Name = "_btnActualiza";
			this._btnActualiza.Size = new System.Drawing.Size(46, 39);
			this._btnActualiza.Text = "Buscar";
			this._btnActualiza.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this._btnActualiza.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this._btnActualiza.Click += new System.EventHandler(this._btnActualiza_Click);
			// 
			// _btnCancelar
			// 
			this._btnCancelar.ForeColor = System.Drawing.Color.White;
			this._btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("_btnCancelar.Image")));
			this._btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this._btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._btnCancelar.Name = "_btnCancelar";
			this._btnCancelar.Size = new System.Drawing.Size(57, 39);
			this._btnCancelar.Text = "Cancelar";
			this._btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this._btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this._btnCancelar.Click += new System.EventHandler(this._btnCancelar_Click);
			// 
			// ToolStripSeparator1
			// 
			this.ToolStripSeparator1.Name = "ToolStripSeparator1";
			this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 42);
			// 
			// _btnSalir
			// 
			this._btnSalir.ForeColor = System.Drawing.Color.White;
			this._btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("_btnSalir.Image")));
			this._btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this._btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._btnSalir.Name = "_btnSalir";
			this._btnSalir.Size = new System.Drawing.Size(33, 39);
			this._btnSalir.Text = "Salir";
			this._btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this._btnSalir.Click += new System.EventHandler(this._btnSalir_Click);
			// 
			// buscarDet
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(692, 450);
			this.Controls.Add(this.Panel2);
			this.Controls.Add(this.Panel1);
			this.Name = "buscarDet";
			this.Text = "buscarDet";
			this.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridDatos)).EndInit();
			this.Panel1.ResumeLayout(false);
			this.Panel1.PerformLayout();
			this.ToolStrip1.ResumeLayout(false);
			this.ToolStrip1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		internal System.Windows.Forms.Panel Panel2;
		private System.Windows.Forms.DataGridView gridDatos;
		internal System.Windows.Forms.Panel Panel1;
		private System.Windows.Forms.TextBox txtNombre;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label1;
		private System.Windows.Forms.TextBox txtAbrevia;
		internal System.Windows.Forms.CheckBox chkInicial;
		internal System.Windows.Forms.ToolStrip ToolStrip1;
		private System.Windows.Forms.ToolStripButton _btnAceptar;
		private System.Windows.Forms.ToolStripButton _btnActualiza;
		private System.Windows.Forms.ToolStripButton _btnCancelar;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
		private System.Windows.Forms.ToolStripButton _btnSalir;
	}
}