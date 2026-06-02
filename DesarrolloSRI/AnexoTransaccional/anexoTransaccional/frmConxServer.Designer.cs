//namespace anexoTransaccional
//{
//    partial class FrmConxServer
//    {
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.Command1 = new System.Windows.Forms.Button();
//            this.Command3 = new System.Windows.Forms.Button();
//            this.Command2 = new System.Windows.Forms.Button();
//            this.TxtPasswordc = new System.Windows.Forms.TextBox();
//            this.Label4 = new System.Windows.Forms.Label();
//            this.TxtPassword = new System.Windows.Forms.TextBox();
//            this.Label3 = new System.Windows.Forms.Label();
//            this.TxtUsuario = new System.Windows.Forms.TextBox();
//            this.Label2 = new System.Windows.Forms.Label();
//            this.TxtServidor = new System.Windows.Forms.TextBox();
//            this.Label1 = new System.Windows.Forms.Label();
//            this.TxtUrl = new System.Windows.Forms.TextBox();
//            this.label5 = new System.Windows.Forms.Label();
//            this.SuspendLayout();
//            // 
//            // Command1
//            // 
//            this.Command1.BackColor = System.Drawing.Color.SteelBlue;
//            this.Command1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.Command1.ForeColor = System.Drawing.Color.White;
//            this.Command1.Location = new System.Drawing.Point(360, 151);
//            this.Command1.Name = "Command1";
//            this.Command1.Size = new System.Drawing.Size(90, 30);
//            this.Command1.TabIndex = 27;
//            this.Command1.Text = "Probar";
//            this.Command1.UseVisualStyleBackColor = false;
//            //this.Command1.Click += new System.EventHandler(this.Command1_Click);
//            // 
//            // Command3
//            // 
//            this.Command3.BackColor = System.Drawing.Color.SteelBlue;
//            this.Command3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.Command3.ForeColor = System.Drawing.Color.White;
//            this.Command3.Location = new System.Drawing.Point(264, 151);
//            this.Command3.Name = "Command3";
//            this.Command3.Size = new System.Drawing.Size(90, 30);
//            this.Command3.TabIndex = 26;
//            this.Command3.Text = "Cancelar";
//            this.Command3.UseVisualStyleBackColor = false;
//            //this.Command3.Click += new System.EventHandler(this.Command3_Click);
//            // 
//            // Command2
//            // 
//            this.Command2.BackColor = System.Drawing.Color.SteelBlue;
//            this.Command2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.Command2.ForeColor = System.Drawing.Color.White;
//            this.Command2.Location = new System.Drawing.Point(168, 151);
//            this.Command2.Name = "Command2";
//            this.Command2.Size = new System.Drawing.Size(90, 30);
//            this.Command2.TabIndex = 25;
//            this.Command2.Text = "Grabar";
//            this.Command2.UseVisualStyleBackColor = false;
//            //this.Command2.Click += new System.EventHandler(this.Command2_Click);
//            // 
//            // TxtPasswordc
//            // 
//            this.TxtPasswordc.Location = new System.Drawing.Point(283, 88);
//            this.TxtPasswordc.Name = "TxtPasswordc";
//            this.TxtPasswordc.PasswordChar = '#';
//            this.TxtPasswordc.Size = new System.Drawing.Size(163, 20);
//            this.TxtPasswordc.TabIndex = 22;
//            // 
//            // Label4
//            // 
//            this.Label4.AutoSize = true;
//            this.Label4.Location = new System.Drawing.Point(127, 91);
//            this.Label4.Name = "Label4";
//            this.Label4.Size = new System.Drawing.Size(150, 13);
//            this.Label4.TabIndex = 21;
//            this.Label4.Text = "Confirmación de la contraseña";
//            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
//            // 
//            // TxtPassword
//            // 
//            this.TxtPassword.Location = new System.Drawing.Point(283, 65);
//            this.TxtPassword.Name = "TxtPassword";
//            this.TxtPassword.PasswordChar = '#';
//            this.TxtPassword.Size = new System.Drawing.Size(163, 20);
//            this.TxtPassword.TabIndex = 20;
//            // 
//            // Label3
//            // 
//            this.Label3.AutoSize = true;
//            this.Label3.Location = new System.Drawing.Point(73, 68);
//            this.Label3.Name = "Label3";
//            this.Label3.Size = new System.Drawing.Size(204, 13);
//            this.Label3.TabIndex = 19;
//            this.Label3.Text = "Contraseña de acceso a la base de datos";
//            // 
//            // TxtUsuario
//            // 
//            this.TxtUsuario.Location = new System.Drawing.Point(283, 42);
//            this.TxtUsuario.Name = "TxtUsuario";
//            this.TxtUsuario.Size = new System.Drawing.Size(163, 20);
//            this.TxtUsuario.TabIndex = 18;
//            // 
//            // Label2
//            // 
//            this.Label2.AutoSize = true;
//            this.Label2.Location = new System.Drawing.Point(155, 49);
//            this.Label2.Name = "Label2";
//            this.Label2.Size = new System.Drawing.Size(122, 13);
//            this.Label2.TabIndex = 17;
//            this.Label2.Text = "Identificación de usuario";
//            // 
//            // TxtServidor
//            // 
//            this.TxtServidor.Location = new System.Drawing.Point(283, 20);
//            this.TxtServidor.Name = "TxtServidor";
//            this.TxtServidor.Size = new System.Drawing.Size(163, 20);
//            this.TxtServidor.TabIndex = 16;
//            // 
//            // Label1
//            // 
//            this.Label1.AutoSize = true;
//            this.Label1.Location = new System.Drawing.Point(17, 27);
//            this.Label1.Name = "Label1";
//            this.Label1.Size = new System.Drawing.Size(260, 13);
//            this.Label1.TabIndex = 15;
//            this.Label1.Text = "Nombre del servidor de Base de Datos o dirección  IP";
//            // 
//            // TxtUrl
//            // 
//            this.TxtUrl.Location = new System.Drawing.Point(283, 112);
//            this.TxtUrl.Name = "TxtUrl";
//            this.TxtUrl.PasswordChar = '#';
//            this.TxtUrl.Size = new System.Drawing.Size(163, 20);
//            this.TxtUrl.TabIndex = 29;
//            // 
//            // label5
//            // 
//            this.label5.AutoSize = true;
//            this.label5.Location = new System.Drawing.Point(161, 115);
//            this.label5.Name = "label5";
//            this.label5.Size = new System.Drawing.Size(114, 13);
//            this.label5.TabIndex = 28;
//            this.label5.Text = "Nombre base de datos";
//            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
//            // 
//            // frmConxServer
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.BackColor = System.Drawing.Color.WhiteSmoke;
//            this.ClientSize = new System.Drawing.Size(458, 186);
//            this.Controls.Add(this.TxtUrl);
//            this.Controls.Add(this.label5);
//            this.Controls.Add(this.Command1);
//            this.Controls.Add(this.Command3);
//            this.Controls.Add(this.Command2);
//            this.Controls.Add(this.TxtPasswordc);
//            this.Controls.Add(this.Label4);
//            this.Controls.Add(this.TxtPassword);
//            this.Controls.Add(this.Label3);
//            this.Controls.Add(this.TxtUsuario);
//            this.Controls.Add(this.Label2);
//            this.Controls.Add(this.TxtServidor);
//            this.Controls.Add(this.Label1);
//            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
//            this.MaximizeBox = false;
//            this.MinimizeBox = false;
//            this.Name = "frmConxServer";
//            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
//            this.Text = "Datos de conexión al servidor externo al sistema AdcomDax";
//            //this.Load += new System.EventHandler(this.frmConxServer_Load);
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        #endregion

//        internal System.Windows.Forms.Button Command1;
//        internal System.Windows.Forms.Button Command3;
//        internal System.Windows.Forms.Button Command2;
//        internal System.Windows.Forms.TextBox TxtPasswordc;
//        internal System.Windows.Forms.Label Label4;
//        internal System.Windows.Forms.TextBox TxtPassword;
//        internal System.Windows.Forms.Label Label3;
//        internal System.Windows.Forms.TextBox TxtUsuario;
//        internal System.Windows.Forms.Label Label2;
//        internal System.Windows.Forms.TextBox TxtServidor;
//        internal System.Windows.Forms.Label Label1;
//        internal System.Windows.Forms.TextBox TxtUrl;
//        internal System.Windows.Forms.Label label5;
//    }
//}