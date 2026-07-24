
namespace ConxServer
{
	partial class ingServidor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Command4 = new System.Windows.Forms.Button();
            this.TxtServidor = new System.Windows.Forms.TextBox();
            this.Command1 = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.Command3 = new System.Windows.Forms.Button();
            this.Command2 = new System.Windows.Forms.Button();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.TxtUrl = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.TxtPasswordc = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Label1);
            this.groupBox1.Controls.Add(this.Command4);
            this.groupBox1.Controls.Add(this.TxtServidor);
            this.groupBox1.Controls.Add(this.Command1);
            this.groupBox1.Controls.Add(this.Label2);
            this.groupBox1.Controls.Add(this.Command3);
            this.groupBox1.Controls.Add(this.Command2);
            this.groupBox1.Controls.Add(this.TxtUsuario);
            this.groupBox1.Controls.Add(this.Label3);
            this.groupBox1.Controls.Add(this.TxtPassword);
            this.groupBox1.Controls.Add(this.TxtUrl);
            this.groupBox1.Controls.Add(this.Label4);
            this.groupBox1.Controls.Add(this.Label5);
            this.groupBox1.Controls.Add(this.TxtPasswordc);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(19, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(741, 248);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Directorio de arranque del sistema";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(28, 27);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(346, 17);
            this.Label1.TabIndex = 15;
            this.Label1.Text = "Nombre del servidor de Base de Datos o dirección  IP";
            // 
            // Command4
            // 
            this.Command4.BackColor = System.Drawing.Color.DarkGray;
            this.Command4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Command4.ForeColor = System.Drawing.Color.Black;
            this.Command4.Location = new System.Drawing.Point(528, 183);
            this.Command4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Command4.Name = "Command4";
            this.Command4.Size = new System.Drawing.Size(146, 50);
            this.Command4.TabIndex = 28;
            this.Command4.Text = "Recuperar última Conexión exitosa";
            this.Command4.UseVisualStyleBackColor = false;
            this.Command4.Click += new System.EventHandler(this.Command4_Click_1);
            // 
            // TxtServidor
            // 
            this.TxtServidor.Location = new System.Drawing.Point(382, 18);
            this.TxtServidor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtServidor.Name = "TxtServidor";
            this.TxtServidor.Size = new System.Drawing.Size(183, 22);
            this.TxtServidor.TabIndex = 16;
            // 
            // Command1
            // 
            this.Command1.BackColor = System.Drawing.Color.DarkGray;
            this.Command1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Command1.ForeColor = System.Drawing.Color.Black;
            this.Command1.Location = new System.Drawing.Point(363, 183);
            this.Command1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Command1.Name = "Command1";
            this.Command1.Size = new System.Drawing.Size(146, 50);
            this.Command1.TabIndex = 27;
            this.Command1.Text = "Probar Conexión";
            this.Command1.UseVisualStyleBackColor = false;
            this.Command1.Click += new System.EventHandler(this.Command1_Click_1);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.ForeColor = System.Drawing.Color.White;
            this.Label2.Location = new System.Drawing.Point(212, 53);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(161, 17);
            this.Label2.TabIndex = 17;
            this.Label2.Text = "Identificación de usuario";
            // 
            // Command3
            // 
            this.Command3.BackColor = System.Drawing.Color.DarkGray;
            this.Command3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Command3.ForeColor = System.Drawing.Color.Black;
            this.Command3.Location = new System.Drawing.Point(196, 183);
            this.Command3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Command3.Name = "Command3";
            this.Command3.Size = new System.Drawing.Size(146, 50);
            this.Command3.TabIndex = 26;
            this.Command3.Text = "Cancelar";
            this.Command3.UseVisualStyleBackColor = false;
            this.Command3.Click += new System.EventHandler(this.Command3_Click_1);
            // 
            // Command2
            // 
            this.Command2.BackColor = System.Drawing.Color.DarkGray;
            this.Command2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Command2.ForeColor = System.Drawing.Color.Black;
            this.Command2.Location = new System.Drawing.Point(29, 183);
            this.Command2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Command2.Name = "Command2";
            this.Command2.Size = new System.Drawing.Size(146, 50);
            this.Command2.TabIndex = 25;
            this.Command2.Text = "Continuar";
            this.Command2.UseVisualStyleBackColor = false;
            this.Command2.Click += new System.EventHandler(this.Command2_Click_1);
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.Location = new System.Drawing.Point(382, 44);
            this.TxtUsuario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(183, 22);
            this.TxtUsuario.TabIndex = 18;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.ForeColor = System.Drawing.Color.White;
            this.Label3.Location = new System.Drawing.Point(103, 74);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(271, 17);
            this.Label3.TabIndex = 19;
            this.Label3.Text = "Contraseña de acceso a la base de datos";
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(382, 70);
            this.TxtPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '#';
            this.TxtPassword.Size = new System.Drawing.Size(183, 22);
            this.TxtPassword.TabIndex = 20;
            // 
            // TxtUrl
            // 
            this.TxtUrl.Location = new System.Drawing.Point(29, 153);
            this.TxtUrl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtUrl.Name = "TxtUrl";
            this.TxtUrl.Size = new System.Drawing.Size(680, 22);
            this.TxtUrl.TabIndex = 24;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.ForeColor = System.Drawing.Color.White;
            this.Label4.Location = new System.Drawing.Point(174, 107);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(200, 17);
            this.Label4.TabIndex = 21;
            this.Label4.Text = "Confirmación de la contraseña";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label4.Visible = false;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.ForeColor = System.Drawing.Color.White;
            this.Label5.Location = new System.Drawing.Point(27, 135);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(350, 17);
            this.Label5.TabIndex = 23;
            this.Label5.Text = "Dirección URL del directorio del sistema en el servidor";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtPasswordc
            // 
            this.TxtPasswordc.Location = new System.Drawing.Point(382, 103);
            this.TxtPasswordc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtPasswordc.Name = "TxtPasswordc";
            this.TxtPasswordc.PasswordChar = '#';
            this.TxtPasswordc.Size = new System.Drawing.Size(183, 22);
            this.TxtPasswordc.TabIndex = 32;
            this.TxtPasswordc.Visible = false;
            // 
            // ingServidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(780, 268);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ingServidor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REGISTRO INFORMACION DE CONEXION A SERVIDOR DE DATOS";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button Command4;
		internal System.Windows.Forms.TextBox TxtServidor;
		internal System.Windows.Forms.Button Command1;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Button Command3;
		internal System.Windows.Forms.Button Command2;
		internal System.Windows.Forms.TextBox TxtUsuario;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.TextBox TxtPassword;
		internal System.Windows.Forms.TextBox TxtUrl;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.TextBox TxtPasswordc;
	}
}