namespace mntUsrs
{
    partial class frmMntUser
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
			this.components = new System.ComponentModel.Container();
			this.btnSalir = new System.Windows.Forms.Button();
			this.btnCopiar = new System.Windows.Forms.Button();
			this.btnGuardar = new System.Windows.Forms.Button();
			this.btnNomina = new System.Windows.Forms.Button();
			this.dtValidoHasta = new System.Windows.Forms.DateTimePicker();
			this.Label8 = new System.Windows.Forms.Label();
			this.txtDiasCambia = new System.Windows.Forms.TextBox();
			this.Label7 = new System.Windows.Forms.Label();
			this.Label6 = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.Label5 = new System.Windows.Forms.Label();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.btnAdcomDax = new System.Windows.Forms.Button();
			this.btnDirectorio = new System.Windows.Forms.Button();
			this.btnElimina = new System.Windows.Forms.Button();
			this.btnNuevo = new System.Windows.Forms.Button();
			this.btnMedica = new System.Windows.Forms.Button();
			this.btnLocales = new System.Windows.Forms.Button();
			this.btnDocumentos = new System.Windows.Forms.Button();
			this.txtPasswordVerifica = new System.Windows.Forms.TextBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.txtIdentificacion = new System.Windows.Forms.TextBox();
			this.txtCodigoDirectorio = new System.Windows.Forms.TextBox();
			this.NombreDirectorio = new System.Windows.Forms.Label();
			this.CBuscador13 = new System.Windows.Forms.Button();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.btnBuscaUsuarios = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnSalir
			// 
			this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.btnSalir.FlatAppearance.BorderSize = 0;
			this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSalir.ForeColor = System.Drawing.Color.White;
			this.btnSalir.Location = new System.Drawing.Point(483, 270);
			this.btnSalir.Name = "btnSalir";
			this.btnSalir.Size = new System.Drawing.Size(81, 43);
			this.btnSalir.TabIndex = 47;
			this.btnSalir.Text = "Salir";
			this.btnSalir.UseVisualStyleBackColor = false;
			this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
			// 
			// btnCopiar
			// 
			this.btnCopiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.btnCopiar.FlatAppearance.BorderSize = 0;
			this.btnCopiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCopiar.ForeColor = System.Drawing.Color.White;
			this.btnCopiar.Location = new System.Drawing.Point(395, 270);
			this.btnCopiar.Name = "btnCopiar";
			this.btnCopiar.Size = new System.Drawing.Size(81, 43);
			this.btnCopiar.TabIndex = 46;
			this.btnCopiar.Text = "Copiar";
			this.ToolTip1.SetToolTip(this.btnCopiar, "Copiar las autorizaciones de otro usuario");
			this.btnCopiar.UseVisualStyleBackColor = false;
			this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
			// 
			// btnGuardar
			// 
			this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.btnGuardar.FlatAppearance.BorderSize = 0;
			this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnGuardar.ForeColor = System.Drawing.Color.White;
			this.btnGuardar.Location = new System.Drawing.Point(220, 270);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(81, 43);
			this.btnGuardar.TabIndex = 45;
			this.btnGuardar.Text = "Guardar";
			this.ToolTip1.SetToolTip(this.btnGuardar, "Guardar los datos actuales");
			this.btnGuardar.UseVisualStyleBackColor = false;
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
			// 
			// btnNomina
			// 
			this.btnNomina.BackColor = System.Drawing.Color.SteelBlue;
			this.btnNomina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnNomina.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnNomina.ForeColor = System.Drawing.Color.White;
			this.btnNomina.Location = new System.Drawing.Point(440, 160);
			this.btnNomina.Name = "btnNomina";
			this.btnNomina.Size = new System.Drawing.Size(100, 40);
			this.btnNomina.TabIndex = 44;
			this.btnNomina.Text = "RRHH NOM";
			this.ToolTip1.SetToolTip(this.btnNomina, "Permite definir accesos personalizados a las opciones del sistema");
			this.btnNomina.UseVisualStyleBackColor = false;
			this.btnNomina.Visible = false;
			this.btnNomina.Click += new System.EventHandler(this.btnNomina_Click);
			// 
			// dtValidoHasta
			// 
			this.dtValidoHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtValidoHasta.Location = new System.Drawing.Point(175, 196);
			this.dtValidoHasta.Name = "dtValidoHasta";
			this.dtValidoHasta.Size = new System.Drawing.Size(100, 20);
			this.dtValidoHasta.TabIndex = 42;
			// 
			// Label8
			// 
			this.Label8.AutoSize = true;
			this.Label8.Location = new System.Drawing.Point(218, 224);
			this.Label8.Name = "Label8";
			this.Label8.Size = new System.Drawing.Size(28, 13);
			this.Label8.TabIndex = 41;
			this.Label8.Text = "días";
			// 
			// txtDiasCambia
			// 
			this.txtDiasCambia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtDiasCambia.Location = new System.Drawing.Point(175, 221);
			this.txtDiasCambia.Name = "txtDiasCambia";
			this.txtDiasCambia.Size = new System.Drawing.Size(42, 20);
			this.txtDiasCambia.TabIndex = 40;
			// 
			// Label7
			// 
			this.Label7.AutoSize = true;
			this.Label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label7.Location = new System.Drawing.Point(62, 224);
			this.Label7.Name = "Label7";
			this.Label7.Size = new System.Drawing.Size(116, 15);
			this.Label7.TabIndex = 39;
			this.Label7.Text = "Cambiar clave cada";
			// 
			// Label6
			// 
			this.Label6.AutoSize = true;
			this.Label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label6.Location = new System.Drawing.Point(61, 197);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(119, 15);
			this.Label6.TabIndex = 38;
			this.Label6.Text = "Acceso válido hasta:";
			// 
			// txtPassword
			// 
			this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPassword.Location = new System.Drawing.Point(175, 146);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(100, 20);
			this.txtPassword.TabIndex = 37;
			// 
			// Label5
			// 
			this.Label5.AutoSize = true;
			this.Label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label5.Location = new System.Drawing.Point(90, 148);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(86, 15);
			this.Label5.TabIndex = 36;
			this.Label5.Text = "Clave Secreta:";
			// 
			// btnAdcomDax
			// 
			this.btnAdcomDax.BackColor = System.Drawing.Color.SteelBlue;
			this.btnAdcomDax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAdcomDax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAdcomDax.ForeColor = System.Drawing.Color.White;
			this.btnAdcomDax.Location = new System.Drawing.Point(440, 114);
			this.btnAdcomDax.Name = "btnAdcomDax";
			this.btnAdcomDax.Size = new System.Drawing.Size(100, 40);
			this.btnAdcomDax.TabIndex = 48;
			this.btnAdcomDax.Text = "SESERP";
			this.ToolTip1.SetToolTip(this.btnAdcomDax, "Permite definir accesos personalizados a las opciones del sistema");
			this.btnAdcomDax.UseVisualStyleBackColor = false;
			this.btnAdcomDax.Click += new System.EventHandler(this.btnSistema_Click);
			// 
			// btnDirectorio
			// 
			this.btnDirectorio.BackColor = System.Drawing.Color.DimGray;
			this.btnDirectorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDirectorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDirectorio.ForeColor = System.Drawing.Color.White;
			this.btnDirectorio.Location = new System.Drawing.Point(547, 161);
			this.btnDirectorio.Name = "btnDirectorio";
			this.btnDirectorio.Size = new System.Drawing.Size(100, 40);
			this.btnDirectorio.TabIndex = 49;
			this.btnDirectorio.Text = "DIrectorio general";
			this.ToolTip1.SetToolTip(this.btnDirectorio, "Permite definir accesos personalizados a las opciones del sistema");
			this.btnDirectorio.UseVisualStyleBackColor = false;
			this.btnDirectorio.Click += new System.EventHandler(this.btnDirectorio_Click);
			// 
			// btnElimina
			// 
			this.btnElimina.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.btnElimina.FlatAppearance.BorderSize = 0;
			this.btnElimina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnElimina.ForeColor = System.Drawing.Color.White;
			this.btnElimina.Location = new System.Drawing.Point(308, 270);
			this.btnElimina.Name = "btnElimina";
			this.btnElimina.Size = new System.Drawing.Size(81, 43);
			this.btnElimina.TabIndex = 51;
			this.btnElimina.Text = "Eliminar";
			this.ToolTip1.SetToolTip(this.btnElimina, "Guardar los datos actuales");
			this.btnElimina.UseVisualStyleBackColor = false;
			this.btnElimina.Click += new System.EventHandler(this.btnElimina_Click);
			// 
			// btnNuevo
			// 
			this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.btnNuevo.FlatAppearance.BorderSize = 0;
			this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnNuevo.ForeColor = System.Drawing.Color.White;
			this.btnNuevo.Location = new System.Drawing.Point(134, 270);
			this.btnNuevo.Name = "btnNuevo";
			this.btnNuevo.Size = new System.Drawing.Size(81, 43);
			this.btnNuevo.TabIndex = 52;
			this.btnNuevo.Text = "Nuevo";
			this.ToolTip1.SetToolTip(this.btnNuevo, "Guardar los datos actuales");
			this.btnNuevo.UseVisualStyleBackColor = false;
			this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
			// 
			// btnMedica
			// 
			this.btnMedica.BackColor = System.Drawing.Color.SteelBlue;
			this.btnMedica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnMedica.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnMedica.ForeColor = System.Drawing.Color.White;
			this.btnMedica.Location = new System.Drawing.Point(440, 206);
			this.btnMedica.Name = "btnMedica";
			this.btnMedica.Size = new System.Drawing.Size(100, 40);
			this.btnMedica.TabIndex = 54;
			this.btnMedica.Text = "MEDICO";
			this.ToolTip1.SetToolTip(this.btnMedica, "Permite definir accesos personalizados a las opciones del sistema");
			this.btnMedica.UseVisualStyleBackColor = false;
			this.btnMedica.Visible = false;
			this.btnMedica.Click += new System.EventHandler(this.btnMedica_Click);
			// 
			// btnLocales
			// 
			this.btnLocales.BackColor = System.Drawing.Color.DimGray;
			this.btnLocales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLocales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLocales.ForeColor = System.Drawing.Color.White;
			this.btnLocales.Location = new System.Drawing.Point(547, 115);
			this.btnLocales.Name = "btnLocales";
			this.btnLocales.Size = new System.Drawing.Size(100, 40);
			this.btnLocales.TabIndex = 55;
			this.btnLocales.Text = "Locales de la empresa";
			this.ToolTip1.SetToolTip(this.btnLocales, "Permite definir accesos personalizados a las opciones del sistema");
			this.btnLocales.UseVisualStyleBackColor = false;
			this.btnLocales.Click += new System.EventHandler(this.btnLocales_Click);
			// 
			// btnDocumentos
			// 
			this.btnDocumentos.BackColor = System.Drawing.Color.DimGray;
			this.btnDocumentos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDocumentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDocumentos.ForeColor = System.Drawing.Color.White;
			this.btnDocumentos.Location = new System.Drawing.Point(547, 206);
			this.btnDocumentos.Name = "btnDocumentos";
			this.btnDocumentos.Size = new System.Drawing.Size(100, 40);
			this.btnDocumentos.TabIndex = 56;
			this.btnDocumentos.Text = "Documentos";
			this.ToolTip1.SetToolTip(this.btnDocumentos, "Permite definir accesos personalizados a las opciones del sistema");
			this.btnDocumentos.UseVisualStyleBackColor = false;
			this.btnDocumentos.Click += new System.EventHandler(this.btnDocumentos_Click);
			// 
			// txtPasswordVerifica
			// 
			this.txtPasswordVerifica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPasswordVerifica.Location = new System.Drawing.Point(175, 171);
			this.txtPasswordVerifica.Name = "txtPasswordVerifica";
			this.txtPasswordVerifica.PasswordChar = '*';
			this.txtPasswordVerifica.Size = new System.Drawing.Size(100, 20);
			this.txtPasswordVerifica.TabIndex = 35;
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label4.Location = new System.Drawing.Point(38, 173);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(144, 15);
			this.Label4.TabIndex = 34;
			this.Label4.Text = "Confirmar Clave Secreta:";
			// 
			// txtIdentificacion
			// 
			this.txtIdentificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtIdentificacion.Location = new System.Drawing.Point(195, 122);
			this.txtIdentificacion.Name = "txtIdentificacion";
			this.txtIdentificacion.Size = new System.Drawing.Size(100, 20);
			this.txtIdentificacion.TabIndex = 33;
			this.txtIdentificacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdentificacion_KeyDown);
			// 
			// txtCodigoDirectorio
			// 
			this.txtCodigoDirectorio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtCodigoDirectorio.Location = new System.Drawing.Point(100, 73);
			this.txtCodigoDirectorio.Name = "txtCodigoDirectorio";
			this.txtCodigoDirectorio.Size = new System.Drawing.Size(100, 20);
			this.txtCodigoDirectorio.TabIndex = 32;
			this.txtCodigoDirectorio.Leave += new System.EventHandler(this.txtCodigoDirectorio_Leave);
			// 
			// NombreDirectorio
			// 
			this.NombreDirectorio.Location = new System.Drawing.Point(206, 73);
			this.NombreDirectorio.Name = "NombreDirectorio";
			this.NombreDirectorio.Size = new System.Drawing.Size(409, 18);
			this.NombreDirectorio.TabIndex = 31;
			this.NombreDirectorio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.NombreDirectorio.Click += new System.EventHandler(this.NombreDirectorio_Click);
			// 
			// CBuscador13
			// 
			this.CBuscador13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.CBuscador13.Cursor = System.Windows.Forms.Cursors.Default;
			this.CBuscador13.FlatAppearance.BorderSize = 0;
			this.CBuscador13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CBuscador13.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CBuscador13.ForeColor = System.Drawing.Color.White;
			this.CBuscador13.Location = new System.Drawing.Point(80, 72);
			this.CBuscador13.Name = "CBuscador13";
			this.CBuscador13.Size = new System.Drawing.Size(18, 20);
			this.CBuscador13.TabIndex = 30;
			this.CBuscador13.Text = "...";
			this.CBuscador13.UseVisualStyleBackColor = false;
			this.CBuscador13.Click += new System.EventHandler(this.CBuscador13_Click);
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(14, 76);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(61, 13);
			this.Label2.TabIndex = 29;
			this.Label2.Text = "IdDirectorio";
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.Location = new System.Drawing.Point(56, 124);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(125, 15);
			this.Label1.TabIndex = 28;
			this.Label1.Text = "Identificación acceso:";
			// 
			// btnBuscaUsuarios
			// 
			this.btnBuscaUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.btnBuscaUsuarios.Cursor = System.Windows.Forms.Cursors.Default;
			this.btnBuscaUsuarios.FlatAppearance.BorderSize = 0;
			this.btnBuscaUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuscaUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnBuscaUsuarios.ForeColor = System.Drawing.Color.White;
			this.btnBuscaUsuarios.Location = new System.Drawing.Point(175, 121);
			this.btnBuscaUsuarios.Name = "btnBuscaUsuarios";
			this.btnBuscaUsuarios.Size = new System.Drawing.Size(18, 20);
			this.btnBuscaUsuarios.TabIndex = 50;
			this.btnBuscaUsuarios.Text = "...";
			this.btnBuscaUsuarios.UseVisualStyleBackColor = false;
			this.btnBuscaUsuarios.Click += new System.EventHandler(this.btnBuscaUsuarios_Click);
			// 
			// label3
			// 
			this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.label3.Location = new System.Drawing.Point(76, 41);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(508, 18);
			this.label3.TabIndex = 57;
			this.label3.Text = "MANTENIMIENTO DE USUARIOS ";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// frmMntUser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(652, 323);
			this.ControlBox = false;
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnDocumentos);
			this.Controls.Add(this.btnLocales);
			this.Controls.Add(this.btnMedica);
			this.Controls.Add(this.btnNuevo);
			this.Controls.Add(this.btnElimina);
			this.Controls.Add(this.btnBuscaUsuarios);
			this.Controls.Add(this.btnDirectorio);
			this.Controls.Add(this.btnAdcomDax);
			this.Controls.Add(this.btnSalir);
			this.Controls.Add(this.btnCopiar);
			this.Controls.Add(this.btnGuardar);
			this.Controls.Add(this.btnNomina);
			this.Controls.Add(this.dtValidoHasta);
			this.Controls.Add(this.Label8);
			this.Controls.Add(this.txtDiasCambia);
			this.Controls.Add(this.Label7);
			this.Controls.Add(this.Label6);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.txtPasswordVerifica);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.txtIdentificacion);
			this.Controls.Add(this.txtCodigoDirectorio);
			this.Controls.Add(this.NombreDirectorio);
			this.Controls.Add(this.CBuscador13);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.Label2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmMntUser";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Load += new System.EventHandler(this.frmMntUser_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnSalir;
        internal System.Windows.Forms.Button btnCopiar;
        internal System.Windows.Forms.ToolTip ToolTip1;
        internal System.Windows.Forms.Button btnGuardar;
        internal System.Windows.Forms.Button btnNomina;
        internal System.Windows.Forms.DateTimePicker dtValidoHasta;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.TextBox txtDiasCambia;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txtPasswordVerifica;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtIdentificacion;
        internal System.Windows.Forms.TextBox txtCodigoDirectorio;
        internal System.Windows.Forms.Label NombreDirectorio;
        internal System.Windows.Forms.Button CBuscador13;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btnAdcomDax;
        internal System.Windows.Forms.Button btnDirectorio;
        internal System.Windows.Forms.Button btnBuscaUsuarios;
        internal System.Windows.Forms.Button btnElimina;
        internal System.Windows.Forms.Button btnNuevo;
        internal System.Windows.Forms.Button btnMedica;
        internal System.Windows.Forms.Button btnLocales;
        internal System.Windows.Forms.Button btnDocumentos;
        internal System.Windows.Forms.Label label3;
    }
}