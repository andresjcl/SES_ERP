
namespace IngSis
{
	partial class Acceso
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Acceso));
			this.picDaxsof = new System.Windows.Forms.PictureBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.btnSalir = new System.Windows.Forms.Button();
			this.BtnContinuar = new System.Windows.Forms.Button();
			this.DcEmp = new System.Windows.Forms.ComboBox();
			this.chkGuardarClaves = new System.Windows.Forms.CheckBox();
			this.ClaveSecreta = new System.Windows.Forms.TextBox();
			this.IdIngreso = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.picDaxsof)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// picDaxsof
			// 
			this.picDaxsof.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.picDaxsof.Image = ((System.Drawing.Image)(resources.GetObject("picDaxsof.Image")));
			this.picDaxsof.Location = new System.Drawing.Point(61, 80);
			this.picDaxsof.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.picDaxsof.Name = "picDaxsof";
			this.picDaxsof.Size = new System.Drawing.Size(254, 189);
			this.picDaxsof.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picDaxsof.TabIndex = 31;
			this.picDaxsof.TabStop = false;
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.BackColor = System.Drawing.Color.Transparent;
			this.Label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(181)))));
			this.Label3.Location = new System.Drawing.Point(16, 151);
			this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(102, 23);
			this.Label3.TabIndex = 30;
			this.Label3.Text = "EMPRESA ";
			// 
			// btnSalir
			// 
			this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(181)))));
			this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnSalir.FlatAppearance.BorderSize = 0;
			this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnSalir.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSalir.ForeColor = System.Drawing.Color.White;
			this.btnSalir.Location = new System.Drawing.Point(425, 254);
			this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnSalir.Name = "btnSalir";
			this.btnSalir.Size = new System.Drawing.Size(222, 52);
			this.btnSalir.TabIndex = 29;
			this.btnSalir.Text = "Salir";
			this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnSalir.UseVisualStyleBackColor = false;
			this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
			// 
			// BtnContinuar
			// 
			this.BtnContinuar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(181)))));
			this.BtnContinuar.FlatAppearance.BorderSize = 0;
			this.BtnContinuar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.BtnContinuar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BtnContinuar.ForeColor = System.Drawing.Color.White;
			this.BtnContinuar.Location = new System.Drawing.Point(81, 257);
			this.BtnContinuar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.BtnContinuar.Name = "BtnContinuar";
			this.BtnContinuar.Size = new System.Drawing.Size(193, 52);
			this.BtnContinuar.TabIndex = 28;
			this.BtnContinuar.Text = "Login";
			this.BtnContinuar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.BtnContinuar.UseVisualStyleBackColor = false;
			this.BtnContinuar.Click += new System.EventHandler(this.BtnContinuar_Click);
			// 
			// DcEmp
			// 
			this.DcEmp.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DcEmp.ForeColor = System.Drawing.Color.SteelBlue;
			this.DcEmp.FormattingEnabled = true;
			this.DcEmp.Location = new System.Drawing.Point(14, 178);
			this.DcEmp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.DcEmp.Name = "DcEmp";
			this.DcEmp.Size = new System.Drawing.Size(676, 31);
			this.DcEmp.TabIndex = 27;
			this.DcEmp.Click += new System.EventHandler(this.DcEmp_Click);
			// 
			// chkGuardarClaves
			// 
			this.chkGuardarClaves.AutoSize = true;
			this.chkGuardarClaves.BackColor = System.Drawing.Color.Transparent;
			this.chkGuardarClaves.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkGuardarClaves.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(181)))));
			this.chkGuardarClaves.Location = new System.Drawing.Point(16, 222);
			this.chkGuardarClaves.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.chkGuardarClaves.Name = "chkGuardarClaves";
			this.chkGuardarClaves.Size = new System.Drawing.Size(142, 23);
			this.chkGuardarClaves.TabIndex = 26;
			this.chkGuardarClaves.Text = "Recuerdame";
			this.chkGuardarClaves.UseVisualStyleBackColor = false;
			this.chkGuardarClaves.CheckedChanged += new System.EventHandler(this.chkGuardarClaves_CheckedChanged);
			// 
			// ClaveSecreta
			// 
			this.ClaveSecreta.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ClaveSecreta.Location = new System.Drawing.Point(74, 105);
			this.ClaveSecreta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.ClaveSecreta.Multiline = true;
			this.ClaveSecreta.Name = "ClaveSecreta";
			this.ClaveSecreta.PasswordChar = 'X';
			this.ClaveSecreta.Size = new System.Drawing.Size(544, 38);
			this.ClaveSecreta.TabIndex = 23;
			// 
			// IdIngreso
			// 
			this.IdIngreso.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IdIngreso.Location = new System.Drawing.Point(74, 37);
			this.IdIngreso.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.IdIngreso.Multiline = true;
			this.IdIngreso.Name = "IdIngreso";
			this.IdIngreso.Size = new System.Drawing.Size(544, 36);
			this.IdIngreso.TabIndex = 22;
			this.IdIngreso.TextChanged += new System.EventHandler(this.IdIngreso_TextChanged);
			this.IdIngreso.Leave += new System.EventHandler(this.IdIngreso_Leave);
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.BackColor = System.Drawing.Color.Transparent;
			this.Label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(181)))));
			this.Label1.Location = new System.Drawing.Point(69, 12);
			this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(81, 23);
			this.Label1.TabIndex = 24;
			this.Label1.Text = "Usuario";
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.BackColor = System.Drawing.Color.Transparent;
			this.Label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(181)))));
			this.Label2.Location = new System.Drawing.Point(76, 80);
			this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(68, 23);
			this.Label2.TabIndex = 25;
			this.Label2.Text = "Clave";
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.White;
			this.groupBox1.Controls.Add(this.Label1);
			this.groupBox1.Controls.Add(this.Label2);
			this.groupBox1.Controls.Add(this.Label3);
			this.groupBox1.Controls.Add(this.IdIngreso);
			this.groupBox1.Controls.Add(this.btnSalir);
			this.groupBox1.Controls.Add(this.ClaveSecreta);
			this.groupBox1.Controls.Add(this.BtnContinuar);
			this.groupBox1.Controls.Add(this.chkGuardarClaves);
			this.groupBox1.Controls.Add(this.DcEmp);
			this.groupBox1.Location = new System.Drawing.Point(376, 3);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.groupBox1.Size = new System.Drawing.Size(696, 320);
			this.groupBox1.TabIndex = 32;
			this.groupBox1.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.picDaxsof);
			this.panel1.Location = new System.Drawing.Point(0, 3);
			this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(384, 320);
			this.panel1.TabIndex = 33;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(181)))));
			this.label5.Location = new System.Drawing.Point(62, 4);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(253, 47);
			this.label5.TabIndex = 32;
			this.label5.Text = "Bienvenido ";
			this.label5.Click += new System.EventHandler(this.label5_Click);
			// 
			// Acceso
			// 
			this.AcceptButton = this.BtnContinuar;
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnSalir;
			this.ClientSize = new System.Drawing.Size(1072, 319);
			this.ControlBox = false;
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.groupBox1);
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximizeBox = false;
			this.Name = "Acceso";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "REGISTRAR INGRESO AL SISTEMA";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Acceso_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.picDaxsof)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox picDaxsof;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Button btnSalir;
		internal System.Windows.Forms.Button BtnContinuar;
		internal System.Windows.Forms.ComboBox DcEmp;
		internal System.Windows.Forms.CheckBox chkGuardarClaves;
		internal System.Windows.Forms.TextBox ClaveSecreta;
		internal System.Windows.Forms.TextBox IdIngreso;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label Label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel panel1;
		internal System.Windows.Forms.Label label5;
	}
}