
namespace DaxInvent
{
	partial class frmBuscarPreferenciaPlato
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarPreferenciaPlato));
			this.malla = new System.Windows.Forms.DataGridView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnSalida = new System.Windows.Forms.Button();
			this.txtDescripcion = new System.Windows.Forms.TextBox();
			this.btnBuscar = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.malla)).BeginInit();
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
			this.malla.Location = new System.Drawing.Point(0, 73);
			this.malla.Margin = new System.Windows.Forms.Padding(4);
			this.malla.Name = "malla";
			this.malla.ReadOnly = true;
			this.malla.RowHeadersWidth = 51;
			this.malla.Size = new System.Drawing.Size(446, 333);
			this.malla.TabIndex = 4;
			this.malla.DoubleClick += new System.EventHandler(this.malla_DoubleClick);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.panel1.Controls.Add(this.btnBuscar);
			this.panel1.Controls.Add(this.btnSalida);
			this.panel1.Controls.Add(this.txtDescripcion);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(446, 73);
			this.panel1.TabIndex = 6;
			// 
			// btnSalida
			// 
			this.btnSalida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSalida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.btnSalida.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSalida.ForeColor = System.Drawing.Color.White;
			this.btnSalida.Location = new System.Drawing.Point(347, 21);
			this.btnSalida.Margin = new System.Windows.Forms.Padding(4);
			this.btnSalida.Name = "btnSalida";
			this.btnSalida.Size = new System.Drawing.Size(95, 39);
			this.btnSalida.TabIndex = 43;
			this.btnSalida.Text = "Cancelar";
			this.btnSalida.UseVisualStyleBackColor = false;
			this.btnSalida.Click += new System.EventHandler(this.btnSalida_Click);
			// 
			// txtDescripcion
			// 
			this.txtDescripcion.Location = new System.Drawing.Point(13, 30);
			this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4);
			this.txtDescripcion.Name = "txtDescripcion";
			this.txtDescripcion.Size = new System.Drawing.Size(271, 22);
			this.txtDescripcion.TabIndex = 25;
			this.txtDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyDown);
			// 
			// btnBuscar
			// 
			this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnBuscar.ForeColor = System.Drawing.Color.White;
			this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
			this.btnBuscar.Location = new System.Drawing.Point(293, 21);
			this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(49, 39);
			this.btnBuscar.TabIndex = 44;
			this.btnBuscar.UseVisualStyleBackColor = false;
			this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
			// 
			// frmBuscarPreferenciaPlato
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(446, 406);
			this.Controls.Add(this.malla);
			this.Controls.Add(this.panel1);
			this.Name = "frmBuscarPreferenciaPlato";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Lista Preferencia Plato";
			this.Load += new System.EventHandler(this.frmBuscarPreferenciaPlato_Load);
			((System.ComponentModel.ISupportInitialize)(this.malla)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView malla;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnBuscar;
		private System.Windows.Forms.Button btnSalida;
		private System.Windows.Forms.TextBox txtDescripcion;
	}
}