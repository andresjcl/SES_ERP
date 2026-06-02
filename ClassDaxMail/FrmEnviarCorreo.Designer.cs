
using System.Drawing;
using System.Windows.Forms;

namespace ClassDaxMail
{
	partial class FrmEnviarCorreo
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
		//private void InitializeComponent()
		//{
		//	this.txtAsunto = new System.Windows.Forms.TextBox();
		//	this.txtEnviarA = new System.Windows.Forms.TextBox();
		//	this.txtConCopiaA = new System.Windows.Forms.TextBox();
		//	this.txtDetalle = new System.Windows.Forms.TextBox();
		//	this.txtAdjuntos = new System.Windows.Forms.TextBox();
		//	this.SuspendLayout();
		//	// 
		//	// txtAsunto
		//	// 
		//	this.txtAsunto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		//	this.txtAsunto.Location = new System.Drawing.Point(32, 121);
		//	this.txtAsunto.Margin = new System.Windows.Forms.Padding(4);
		//	this.txtAsunto.Name = "txtAsunto";
		//	this.txtAsunto.Size = new System.Drawing.Size(1014, 20);
		//	this.txtAsunto.TabIndex = 31;
		//	// 
		//	// txtEnviarA
		//	// 
		//	this.txtEnviarA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		//	this.txtEnviarA.Location = new System.Drawing.Point(32, 31);
		//	this.txtEnviarA.Margin = new System.Windows.Forms.Padding(4);
		//	this.txtEnviarA.Name = "txtEnviarA";
		//	this.txtEnviarA.Size = new System.Drawing.Size(1014, 20);
		//	this.txtEnviarA.TabIndex = 29;
		//	// 
		//	// txtConCopiaA
		//	// 
		//	this.txtConCopiaA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		//	this.txtConCopiaA.Location = new System.Drawing.Point(32, 80);
		//	this.txtConCopiaA.Margin = new System.Windows.Forms.Padding(4);
		//	this.txtConCopiaA.Name = "txtConCopiaA";
		//	this.txtConCopiaA.Size = new System.Drawing.Size(1014, 20);
		//	this.txtConCopiaA.TabIndex = 27;
		//	// 
		//	// txtDetalle
		//	// 
		//	this.txtDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		//	this.txtDetalle.Location = new System.Drawing.Point(32, 257);
		//	this.txtDetalle.Margin = new System.Windows.Forms.Padding(4);
		//	this.txtDetalle.Multiline = true;
		//	this.txtDetalle.Name = "txtDetalle";
		//	this.txtDetalle.Size = new System.Drawing.Size(1014, 129);
		//	this.txtDetalle.TabIndex = 33;
		//	// 
		//	// txtAdjuntos
		//	// 
		//	this.txtAdjuntos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		//	this.txtAdjuntos.Location = new System.Drawing.Point(32, 168);
		//	this.txtAdjuntos.Margin = new System.Windows.Forms.Padding(4);
		//	this.txtAdjuntos.Multiline = true;
		//	this.txtAdjuntos.Name = "txtAdjuntos";
		//	this.txtAdjuntos.Size = new System.Drawing.Size(1014, 55);
		//	this.txtAdjuntos.TabIndex = 38;
		//	// 
		//	// FrmEnviarCorreo
		//	// 
		//	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		//	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		//	this.ClientSize = new System.Drawing.Size(1106, 450);
		//	this.Controls.Add(this.txtAdjuntos);
		//	this.Controls.Add(this.txtDetalle);
		//	this.Controls.Add(this.txtConCopiaA);
		//	this.Controls.Add(this.txtEnviarA);
		//	this.Controls.Add(this.txtAsunto);
		//	this.Name = "FrmEnviarCorreo";
		//	this.Text = "FrmEnviarCorreo";
		//	this.ResumeLayout(false);
		//	this.PerformLayout();

		//}

		private void InitializeComponent()
		{
			this.txtEnviarA = new System.Windows.Forms.TextBox();
			this.txtConCopiaA = new System.Windows.Forms.TextBox();
			this.txtAsunto = new System.Windows.Forms.TextBox();
			this.txtAdjuntos = new System.Windows.Forms.TextBox();
			this.txtDetalle = new System.Windows.Forms.TextBox();
			this.lblEnviarA = new System.Windows.Forms.Label();
			this.lblCC = new System.Windows.Forms.Label();
			this.lblAsunto = new System.Windows.Forms.Label();
			this.lblAdjuntos = new System.Windows.Forms.Label();
			this.lblDetalle = new System.Windows.Forms.Label();
			this.btnEnviarCorreo = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnAdjuntos = new System.Windows.Forms.Button();
			this.btnBuscaDirectorio = new System.Windows.Forms.Button();
			this.btnConfigurar = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// txtEnviarA
			// 
			this.txtEnviarA.Location = new System.Drawing.Point(32, 31);
			this.txtEnviarA.Name = "txtEnviarA";
			this.txtEnviarA.Size = new System.Drawing.Size(1014, 20);
			this.txtEnviarA.TabIndex = 5;
			// 
			// txtConCopiaA
			// 
			this.txtConCopiaA.Location = new System.Drawing.Point(32, 71);
			this.txtConCopiaA.Name = "txtConCopiaA";
			this.txtConCopiaA.Size = new System.Drawing.Size(1014, 20);
			this.txtConCopiaA.TabIndex = 6;
			// 
			// txtAsunto
			// 
			this.txtAsunto.Location = new System.Drawing.Point(32, 111);
			this.txtAsunto.Name = "txtAsunto";
			this.txtAsunto.Size = new System.Drawing.Size(1014, 20);
			this.txtAsunto.TabIndex = 7;
			// 
			// txtAdjuntos
			// 
			this.txtAdjuntos.Location = new System.Drawing.Point(32, 152);
			this.txtAdjuntos.Multiline = true;
			this.txtAdjuntos.Name = "txtAdjuntos";
			this.txtAdjuntos.Size = new System.Drawing.Size(1014, 55);
			this.txtAdjuntos.TabIndex = 8;
			// 
			// txtDetalle
			// 
			this.txtDetalle.Location = new System.Drawing.Point(32, 234);
			this.txtDetalle.Multiline = true;
			this.txtDetalle.Name = "txtDetalle";
			this.txtDetalle.Size = new System.Drawing.Size(1014, 152);
			this.txtDetalle.TabIndex = 9;
			// 
			// lblEnviarA
			// 
			this.lblEnviarA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEnviarA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lblEnviarA.Location = new System.Drawing.Point(34, 14);
			this.lblEnviarA.Name = "lblEnviarA";
			this.lblEnviarA.Size = new System.Drawing.Size(100, 23);
			this.lblEnviarA.TabIndex = 0;
			this.lblEnviarA.Text = "Destinatario:";
			// 
			// lblCC
			// 
			this.lblCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lblCC.Location = new System.Drawing.Point(33, 55);
			this.lblCC.Name = "lblCC";
			this.lblCC.Size = new System.Drawing.Size(100, 23);
			this.lblCC.TabIndex = 1;
			this.lblCC.Text = "cc:";
			// 
			// lblAsunto
			// 
			this.lblAsunto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAsunto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lblAsunto.Location = new System.Drawing.Point(34, 95);
			this.lblAsunto.Name = "lblAsunto";
			this.lblAsunto.Size = new System.Drawing.Size(100, 23);
			this.lblAsunto.TabIndex = 2;
			this.lblAsunto.Text = "Asunto:";
			// 
			// lblAdjuntos
			// 
			this.lblAdjuntos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAdjuntos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lblAdjuntos.Location = new System.Drawing.Point(33, 135);
			this.lblAdjuntos.Name = "lblAdjuntos";
			this.lblAdjuntos.Size = new System.Drawing.Size(100, 23);
			this.lblAdjuntos.TabIndex = 3;
			this.lblAdjuntos.Text = "Adjuntos:";
			// 
			// lblDetalle
			// 
			this.lblDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDetalle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lblDetalle.Location = new System.Drawing.Point(34, 215);
			this.lblDetalle.Name = "lblDetalle";
			this.lblDetalle.Size = new System.Drawing.Size(100, 23);
			this.lblDetalle.TabIndex = 4;
			this.lblDetalle.Text = "Detalle:";
			// 
			// btnEnviarCorreo
			// 
			this.btnEnviarCorreo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.btnEnviarCorreo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEnviarCorreo.ForeColor = System.Drawing.Color.White;
			this.btnEnviarCorreo.Location = new System.Drawing.Point(783, 397);
			this.btnEnviarCorreo.Name = "btnEnviarCorreo";
			this.btnEnviarCorreo.Size = new System.Drawing.Size(123, 39);
			this.btnEnviarCorreo.TabIndex = 10;
			this.btnEnviarCorreo.Text = "Enviar Correo";
			this.btnEnviarCorreo.UseVisualStyleBackColor = false;
			this.btnEnviarCorreo.Click += new System.EventHandler(this.btnEnviarCorreo_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancelar.ForeColor = System.Drawing.Color.White;
			this.btnCancelar.Location = new System.Drawing.Point(925, 397);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(123, 39);
			this.btnCancelar.TabIndex = 11;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = false;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// btnAdjuntos
			// 
			this.btnAdjuntos.Location = new System.Drawing.Point(6, 187);
			this.btnAdjuntos.Name = "btnAdjuntos";
			this.btnAdjuntos.Size = new System.Drawing.Size(24, 24);
			this.btnAdjuntos.TabIndex = 12;
			this.btnAdjuntos.Text = "...";
			this.btnAdjuntos.Click += new System.EventHandler(this.btnAdjuntos_Click);
			// 
			// btnBuscaDirectorio
			// 
			this.btnBuscaDirectorio.Location = new System.Drawing.Point(7, 30);
			this.btnBuscaDirectorio.Name = "btnBuscaDirectorio";
			this.btnBuscaDirectorio.Size = new System.Drawing.Size(24, 24);
			this.btnBuscaDirectorio.TabIndex = 13;
			this.btnBuscaDirectorio.Text = "...";
			this.btnBuscaDirectorio.Click += new System.EventHandler(this.btnBuscaDirectorio_Click);
			// 
			// btnConfigurar
			// 
			this.btnConfigurar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnConfigurar.Location = new System.Drawing.Point(10, 398);
			this.btnConfigurar.Name = "btnConfigurar";
			this.btnConfigurar.Size = new System.Drawing.Size(39, 39);
			this.btnConfigurar.TabIndex = 14;
			this.btnConfigurar.Click += new System.EventHandler(this.btnConfigurar_Click);
			// 
			// FrmEnviarCorreo
			// 
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1055, 463);
			this.ControlBox = false;
			this.Controls.Add(this.lblEnviarA);
			this.Controls.Add(this.lblCC);
			this.Controls.Add(this.lblAsunto);
			this.Controls.Add(this.lblAdjuntos);
			this.Controls.Add(this.lblDetalle);
			this.Controls.Add(this.txtEnviarA);
			this.Controls.Add(this.txtConCopiaA);
			this.Controls.Add(this.txtAsunto);
			this.Controls.Add(this.txtAdjuntos);
			this.Controls.Add(this.txtDetalle);
			this.Controls.Add(this.btnEnviarCorreo);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnAdjuntos);
			this.Controls.Add(this.btnBuscaDirectorio);
			this.Controls.Add(this.btnConfigurar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FrmEnviarCorreo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ENVÍO DE CORREO ELECTRÓNICO";
			this.ResumeLayout(false);
			this.PerformLayout();

		}


		#endregion

		private System.Windows.Forms.TextBox txtAsunto;
		private System.Windows.Forms.TextBox txtEnviarA;
		private System.Windows.Forms.TextBox txtConCopiaA;
		private System.Windows.Forms.TextBox txtDetalle;
		private System.Windows.Forms.TextBox txtAdjuntos;
		private Button btnEnviarCorreo;
		private Button btnCancelar;
		private Button btnAdjuntos;
		private Button btnBuscaDirectorio;
		private Label btnConfigurar;
		private OpenFileDialog openFileDialog1;
		private Label lblEnviarA;
		private Label lblCC;
		private Label lblAsunto;
		private Label lblAdjuntos;
		private Label lblDetalle;
	}
}