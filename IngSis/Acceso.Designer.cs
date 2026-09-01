namespace IngSis
{
    partial class Acceso
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.Label3 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.BtnContinuar = new System.Windows.Forms.Button();
            this.DcEmp = new System.Windows.Forms.ComboBox();
            this.chkGuardarClaves = new System.Windows.Forms.CheckBox();
            this.ClaveSecreta = new System.Windows.Forms.TextBox();
            this.IdIngreso = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnMostrarPass = new System.Windows.Forms.Button();
            this.panelPassword = new System.Windows.Forms.Panel();
            this.panelPassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Label3.Location = new System.Drawing.Point(35, 330);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(103, 20);
            this.Label3.TabIndex = 6;
            this.Label3.Text = "🏢 EMPRESA";
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Transparent;
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSalir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(181)))));
            this.btnSalir.Location = new System.Drawing.Point(35, 299);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(243, 25);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "❌ Salir del sistema";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // BtnContinuar
            // 
            this.BtnContinuar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(181)))));
            this.BtnContinuar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnContinuar.FlatAppearance.BorderSize = 0;
            this.BtnContinuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnContinuar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.BtnContinuar.ForeColor = System.Drawing.Color.White;
            this.BtnContinuar.Location = new System.Drawing.Point(35, 246);
            this.BtnContinuar.Name = "BtnContinuar";
            this.BtnContinuar.Size = new System.Drawing.Size(400, 45);
            this.BtnContinuar.TabIndex = 4;
            this.BtnContinuar.Text = "INICIAR SESIÓN";
            this.BtnContinuar.UseVisualStyleBackColor = false;
            this.BtnContinuar.Click += new System.EventHandler(this.BtnContinuar_Click);
            // 
            // DcEmp
            // 
            this.DcEmp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.DcEmp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DcEmp.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.DcEmp.Location = new System.Drawing.Point(35, 355);
            this.DcEmp.Name = "DcEmp";
            this.DcEmp.Size = new System.Drawing.Size(400, 31);
            this.DcEmp.TabIndex = 6;
            this.DcEmp.Click += new System.EventHandler(this.DcEmp_Click);
            // 
            // chkGuardarClaves
            // 
            this.chkGuardarClaves.AutoSize = true;
            this.chkGuardarClaves.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkGuardarClaves.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.chkGuardarClaves.Location = new System.Drawing.Point(35, 211);
            this.chkGuardarClaves.Name = "chkGuardarClaves";
            this.chkGuardarClaves.Size = new System.Drawing.Size(120, 24);
            this.chkGuardarClaves.TabIndex = 3;
            this.chkGuardarClaves.Text = "  Recordarme";
            this.chkGuardarClaves.CheckedChanged += new System.EventHandler(this.chkGuardarClaves_CheckedChanged);
            // 
            // ClaveSecreta
            // 
            this.ClaveSecreta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClaveSecreta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ClaveSecreta.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ClaveSecreta.Location = new System.Drawing.Point(0, -55);
            this.ClaveSecreta.Name = "ClaveSecreta";
            this.ClaveSecreta.PasswordChar = '●';
            this.ClaveSecreta.Size = new System.Drawing.Size(360, 25);
            this.ClaveSecreta.TabIndex = 2;
            // 
            // IdIngreso
            // 
            this.IdIngreso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.IdIngreso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IdIngreso.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.IdIngreso.Location = new System.Drawing.Point(35, 85);
            this.IdIngreso.Name = "IdIngreso";
            this.IdIngreso.Size = new System.Drawing.Size(400, 32);
            this.IdIngreso.TabIndex = 1;
            this.IdIngreso.TextChanged += new System.EventHandler(this.IdIngreso_TextChanged);
            this.IdIngreso.Enter += new System.EventHandler(this.IdIngreso_Enter);
            this.IdIngreso.Leave += new System.EventHandler(this.IdIngreso_Leave);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Label1.Location = new System.Drawing.Point(35, 60);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(102, 20);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "👤 USUARIO";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Label2.Location = new System.Drawing.Point(35, 135);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(136, 20);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "🔑 CONTRASEÑA";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(181)))));
            this.label5.Location = new System.Drawing.Point(102, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(297, 41);
            this.label5.TabIndex = 0;
            this.label5.Text = "🔐 INICIAR SESIÓN";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // btnMostrarPass
            // 
            this.btnMostrarPass.BackColor = System.Drawing.Color.Transparent;
            this.btnMostrarPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMostrarPass.FlatAppearance.BorderSize = 0;
            this.btnMostrarPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarPass.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMostrarPass.ForeColor = System.Drawing.Color.Gray;
            this.btnMostrarPass.Location = new System.Drawing.Point(365, 0);
            this.btnMostrarPass.Name = "btnMostrarPass";
            this.btnMostrarPass.Size = new System.Drawing.Size(35, 30);
            this.btnMostrarPass.TabIndex = 3;
            this.btnMostrarPass.Text = "👁️";
            this.btnMostrarPass.UseVisualStyleBackColor = false;
            this.btnMostrarPass.Click += new System.EventHandler(this.btnMostrarPass_Click);
            // 
            // panelPassword
            // 
            this.panelPassword.Controls.Add(this.ClaveSecreta);
            this.panelPassword.Controls.Add(this.btnMostrarPass);
            this.panelPassword.Location = new System.Drawing.Point(35, 165);
            this.panelPassword.Name = "panelPassword";
            this.panelPassword.Size = new System.Drawing.Size(400, 32);
            this.panelPassword.TabIndex = 3;
            // 
            // Acceso
            // 
            this.AcceptButton = this.BtnContinuar;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(520, 408);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.IdIngreso);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.panelPassword);
            this.Controls.Add(this.chkGuardarClaves);
            this.Controls.Add(this.BtnContinuar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.DcEmp);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Acceso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INGRESO AL SISTEMA";
            this.panelPassword.ResumeLayout(false);
            this.panelPassword.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // ============================================================
        // DECLARACIÓN DE CONTROLES (SIN DUPLICADOS)
        // ============================================================
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button BtnContinuar;
        private System.Windows.Forms.ComboBox DcEmp;
        private System.Windows.Forms.CheckBox chkGuardarClaves;
        private System.Windows.Forms.TextBox ClaveSecreta;
        private System.Windows.Forms.TextBox IdIngreso;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Label label5;

        // Nuevos controles (SOLO DECLARADOS UNA VEZ)
        private System.Windows.Forms.Button btnMostrarPass;
        private System.Windows.Forms.Panel panelPassword;
    }
}