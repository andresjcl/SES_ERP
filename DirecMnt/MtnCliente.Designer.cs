
namespace DirecMnt
{
	partial class MtnCliente
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MtnCliente));
			this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnNuevo = new System.Windows.Forms.ToolStripButton();
			this.btnAbrir = new System.Windows.Forms.ToolStripButton();
			this.btnCerrar = new System.Windows.Forms.ToolStripButton();
			this.btnGuardar = new System.Windows.Forms.ToolStripButton();
			this.btnEliminar = new System.Windows.Forms.ToolStripButton();
			this.btnSalir = new System.Windows.Forms.ToolStripButton();
			this.ToolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// ToolStrip1
			// 
			this.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(181)))));
			this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ToolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.btnAbrir,
            this.btnCerrar,
            this.btnGuardar,
            this.btnEliminar,
            this.btnSalir});
			this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
			this.ToolStrip1.Name = "ToolStrip1";
			this.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.ToolStrip1.Size = new System.Drawing.Size(800, 42);
			this.ToolStrip1.TabIndex = 3;
			this.ToolStrip1.Text = "ToolStrip1";
			// 
			// btnNuevo
			// 
			this.btnNuevo.ForeColor = System.Drawing.Color.White;
			this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
			this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNuevo.Name = "btnNuevo";
			this.btnNuevo.Size = new System.Drawing.Size(46, 39);
			this.btnNuevo.Text = "Nuevo";
			this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// btnAbrir
			// 
			this.btnAbrir.ForeColor = System.Drawing.Color.White;
			this.btnAbrir.Image = ((System.Drawing.Image)(resources.GetObject("btnAbrir.Image")));
			this.btnAbrir.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAbrir.Name = "btnAbrir";
			this.btnAbrir.Size = new System.Drawing.Size(37, 39);
			this.btnAbrir.Text = "Abrir";
			this.btnAbrir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// btnCerrar
			// 
			this.btnCerrar.ForeColor = System.Drawing.Color.White;
			this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
			this.btnCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnCerrar.Name = "btnCerrar";
			this.btnCerrar.Size = new System.Drawing.Size(43, 39);
			this.btnCerrar.Text = "Cerrar";
			this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// btnGuardar
			// 
			this.btnGuardar.ForeColor = System.Drawing.Color.White;
			this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
			this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(53, 39);
			this.btnGuardar.Text = "Guardar";
			this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// btnEliminar
			// 
			this.btnEliminar.ForeColor = System.Drawing.Color.White;
			this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
			this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEliminar.Name = "btnEliminar";
			this.btnEliminar.Size = new System.Drawing.Size(54, 39);
			this.btnEliminar.Text = "Eliminar";
			this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// btnSalir
			// 
			this.btnSalir.ForeColor = System.Drawing.Color.White;
			this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
			this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSalir.Name = "btnSalir";
			this.btnSalir.Size = new System.Drawing.Size(33, 39);
			this.btnSalir.Text = "Salir";
			this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// MtnCliente
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.ToolStrip1);
			this.Name = "MtnCliente";
			this.Text = "MtnCliente";
			this.ToolStrip1.ResumeLayout(false);
			this.ToolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.ToolStrip ToolStrip1;
		internal System.Windows.Forms.ToolStripButton btnNuevo;
		internal System.Windows.Forms.ToolStripButton btnAbrir;
		internal System.Windows.Forms.ToolStripButton btnCerrar;
		internal System.Windows.Forms.ToolStripButton btnGuardar;
		internal System.Windows.Forms.ToolStripButton btnEliminar;
		internal System.Windows.Forms.ToolStripButton btnSalir;
	}
}