namespace SES_ERP24
{
    partial class frmGestionLicencia
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
            this.gbInfoLicencia = new System.Windows.Forms.GroupBox();
            this.lblIdLicencia = new System.Windows.Forms.Label();
            this.lblFechaGeneracion = new System.Windows.Forms.Label();
            this.lblDiasRestantes = new System.Windows.Forms.Label();
            this.lblFechaExpiracion = new System.Windows.Forms.Label();
            this.lblUsuarios = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblTipoLicencia = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInfoLicencia = new System.Windows.Forms.Label();
            this.gbClaves = new System.Windows.Forms.GroupBox();
            this.btnCopiarClaves = new System.Windows.Forms.Button();
            this.txtClaveActivacion = new System.Windows.Forms.TextBox();
            this.txtClaveCliente = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gbModulos = new System.Windows.Forms.GroupBox();
            this.chkModulos = new System.Windows.Forms.CheckedListBox();
            this.txtGruposActivos = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtModulosActivos = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnResetear = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.gbInfoLicencia.SuspendLayout();
            this.gbClaves.SuspendLayout();
            this.gbModulos.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbInfoLicencia
            // 
            this.gbInfoLicencia.Controls.Add(this.lblIdLicencia);
            this.gbInfoLicencia.Controls.Add(this.lblFechaGeneracion);
            this.gbInfoLicencia.Controls.Add(this.lblDiasRestantes);
            this.gbInfoLicencia.Controls.Add(this.lblFechaExpiracion);
            this.gbInfoLicencia.Controls.Add(this.lblUsuarios);
            this.gbInfoLicencia.Controls.Add(this.lblEstado);
            this.gbInfoLicencia.Controls.Add(this.lblTipoLicencia);
            this.gbInfoLicencia.Controls.Add(this.label7);
            this.gbInfoLicencia.Controls.Add(this.label6);
            this.gbInfoLicencia.Controls.Add(this.label5);
            this.gbInfoLicencia.Controls.Add(this.label4);
            this.gbInfoLicencia.Controls.Add(this.label3);
            this.gbInfoLicencia.Controls.Add(this.label2);
            this.gbInfoLicencia.Controls.Add(this.label1);
            this.gbInfoLicencia.Controls.Add(this.lblInfoLicencia);
            this.gbInfoLicencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gbInfoLicencia.Location = new System.Drawing.Point(16, 15);
            this.gbInfoLicencia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbInfoLicencia.Name = "gbInfoLicencia";
            this.gbInfoLicencia.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbInfoLicencia.Size = new System.Drawing.Size(488, 295);
            this.gbInfoLicencia.TabIndex = 0;
            this.gbInfoLicencia.TabStop = false;
            this.gbInfoLicencia.Text = "INFORMACIÓN DE LICENCIA";
            // 
            // lblIdLicencia
            // 
            this.lblIdLicencia.Location = new System.Drawing.Point(160, 206);
            this.lblIdLicencia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdLicencia.Name = "lblIdLicencia";
            this.lblIdLicencia.Size = new System.Drawing.Size(333, 25);
            this.lblIdLicencia.TabIndex = 0;
            // 
            // lblFechaGeneracion
            // 
            this.lblFechaGeneracion.Location = new System.Drawing.Point(160, 236);
            this.lblFechaGeneracion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaGeneracion.Name = "lblFechaGeneracion";
            this.lblFechaGeneracion.Size = new System.Drawing.Size(333, 25);
            this.lblFechaGeneracion.TabIndex = 1;
            // 
            // lblDiasRestantes
            // 
            this.lblDiasRestantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblDiasRestantes.Location = new System.Drawing.Point(81, 171);
            this.lblDiasRestantes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiasRestantes.Name = "lblDiasRestantes";
            this.lblDiasRestantes.Size = new System.Drawing.Size(107, 25);
            this.lblDiasRestantes.TabIndex = 2;
            // 
            // lblFechaExpiracion
            // 
            this.lblFechaExpiracion.Location = new System.Drawing.Point(160, 134);
            this.lblFechaExpiracion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaExpiracion.Name = "lblFechaExpiracion";
            this.lblFechaExpiracion.Size = new System.Drawing.Size(160, 25);
            this.lblFechaExpiracion.TabIndex = 3;
            // 
            // lblUsuarios
            // 
            this.lblUsuarios.Location = new System.Drawing.Point(160, 68);
            this.lblUsuarios.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuarios.Name = "lblUsuarios";
            this.lblUsuarios.Size = new System.Drawing.Size(333, 25);
            this.lblUsuarios.TabIndex = 4;
            // 
            // lblEstado
            // 
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblEstado.Location = new System.Drawing.Point(160, 101);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(333, 25);
            this.lblEstado.TabIndex = 5;
            // 
            // lblTipoLicencia
            // 
            this.lblTipoLicencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTipoLicencia.Location = new System.Drawing.Point(160, 34);
            this.lblTipoLicencia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipoLicencia.Name = "lblTipoLicencia";
            this.lblTipoLicencia.Size = new System.Drawing.Size(333, 25);
            this.lblTipoLicencia.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(13, 236);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 25);
            this.label7.TabIndex = 7;
            this.label7.Text = "Generada:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(13, 206);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 25);
            this.label6.TabIndex = 8;
            this.label6.Text = "ID:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(13, 171);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Días:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(13, 134);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Expiración:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(13, 101);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Estado:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Usuarios:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "Tipo:";
            // 
            // lblInfoLicencia
            // 
            this.lblInfoLicencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblInfoLicencia.Location = new System.Drawing.Point(13, 240);
            this.lblInfoLicencia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfoLicencia.Name = "lblInfoLicencia";
            this.lblInfoLicencia.Size = new System.Drawing.Size(480, 37);
            this.lblInfoLicencia.TabIndex = 14;
            // 
            // gbClaves
            // 
            this.gbClaves.Controls.Add(this.chkModulos);
            this.gbClaves.Controls.Add(this.btnCopiarClaves);
            this.gbClaves.Controls.Add(this.txtClaveActivacion);
            this.gbClaves.Controls.Add(this.txtModulosActivos);
            this.gbClaves.Controls.Add(this.label13);
            this.gbClaves.Controls.Add(this.txtClaveCliente);
            this.gbClaves.Controls.Add(this.label9);
            this.gbClaves.Controls.Add(this.label8);
            this.gbClaves.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gbClaves.Location = new System.Drawing.Point(12, 98);
            this.gbClaves.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbClaves.Name = "gbClaves";
            this.gbClaves.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbClaves.Size = new System.Drawing.Size(599, 189);
            this.gbClaves.TabIndex = 1;
            this.gbClaves.TabStop = false;
            this.gbClaves.Text = "CLAVES";
            // 
            // btnCopiarClaves
            // 
            this.btnCopiarClaves.Location = new System.Drawing.Point(160, 113);
            this.btnCopiarClaves.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCopiarClaves.Name = "btnCopiarClaves";
            this.btnCopiarClaves.Size = new System.Drawing.Size(333, 34);
            this.btnCopiarClaves.TabIndex = 0;
            this.btnCopiarClaves.Text = "📋 COPIAR CLAVES";
            this.btnCopiarClaves.UseVisualStyleBackColor = true;
            this.btnCopiarClaves.Visible = false;
            this.btnCopiarClaves.Click += new System.EventHandler(this.btnCopiarClaves_Click);
            // 
            // txtClaveActivacion
            // 
            this.txtClaveActivacion.Location = new System.Drawing.Point(143, 74);
            this.txtClaveActivacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtClaveActivacion.Name = "txtClaveActivacion";
            this.txtClaveActivacion.ReadOnly = true;
            this.txtClaveActivacion.Size = new System.Drawing.Size(448, 24);
            this.txtClaveActivacion.TabIndex = 1;
            // 
            // txtClaveCliente
            // 
            this.txtClaveCliente.Location = new System.Drawing.Point(137, 34);
            this.txtClaveCliente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtClaveCliente.Name = "txtClaveCliente";
            this.txtClaveCliente.ReadOnly = true;
            this.txtClaveCliente.Size = new System.Drawing.Size(454, 24);
            this.txtClaveCliente.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(13, 74);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 25);
            this.label9.TabIndex = 3;
            this.label9.Text = "Clave Activación:";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(13, 34);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 25);
            this.label8.TabIndex = 4;
            this.label8.Text = "Clave Cliente:";
            // 
            // gbModulos
            // 
            this.gbModulos.Controls.Add(this.txtGruposActivos);
            this.gbModulos.Controls.Add(this.label14);
            this.gbModulos.Controls.Add(this.gbClaves);
            this.gbModulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.gbModulos.Location = new System.Drawing.Point(512, 15);
            this.gbModulos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbModulos.Name = "gbModulos";
            this.gbModulos.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbModulos.Size = new System.Drawing.Size(619, 295);
            this.gbModulos.TabIndex = 2;
            this.gbModulos.TabStop = false;
            this.gbModulos.Text = "MÓDULOS ACTIVOS";
            // 
            // chkModulos
            // 
            this.chkModulos.Enabled = false;
            this.chkModulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.chkModulos.Location = new System.Drawing.Point(16, 120);
            this.chkModulos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkModulos.Name = "chkModulos";
            this.chkModulos.Size = new System.Drawing.Size(105, 22);
            this.chkModulos.TabIndex = 0;
            this.chkModulos.Visible = false;
            // 
            // txtGruposActivos
            // 
            this.txtGruposActivos.Location = new System.Drawing.Point(75, 32);
            this.txtGruposActivos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGruposActivos.Multiline = true;
            this.txtGruposActivos.Name = "txtGruposActivos";
            this.txtGruposActivos.ReadOnly = true;
            this.txtGruposActivos.Size = new System.Drawing.Size(506, 61);
            this.txtGruposActivos.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(9, 32);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(133, 25);
            this.label14.TabIndex = 2;
            this.label14.Text = "Grupos:";
            // 
            // txtModulosActivos
            // 
            this.txtModulosActivos.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.txtModulosActivos.Location = new System.Drawing.Point(160, 155);
            this.txtModulosActivos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtModulosActivos.Name = "txtModulosActivos";
            this.txtModulosActivos.ReadOnly = true;
            this.txtModulosActivos.Size = new System.Drawing.Size(425, 23);
            this.txtModulosActivos.TabIndex = 3;
            this.txtModulosActivos.Visible = false;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(13, 155);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(133, 25);
            this.label13.TabIndex = 4;
            this.label13.Text = "Modulos (35):";
            this.label13.Visible = false;
            // 
            // btnResetear
            // 
            this.btnResetear.BackColor = System.Drawing.Color.Orange;
            this.btnResetear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnResetear.Location = new System.Drawing.Point(223, 318);
            this.btnResetear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnResetear.Name = "btnResetear";
            this.btnResetear.Size = new System.Drawing.Size(293, 43);
            this.btnResetear.TabIndex = 3;
            this.btnResetear.Text = "⚠️ RESETEAR LICENCIA";
            this.btnResetear.UseVisualStyleBackColor = false;
            this.btnResetear.Click += new System.EventHandler(this.btnResetear_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnCerrar.Location = new System.Drawing.Point(529, 318);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(293, 43);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "❌ CERRAR";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // frmGestionLicencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 375);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnResetear);
            this.Controls.Add(this.gbModulos);
            this.Controls.Add(this.gbInfoLicencia);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGestionLicencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GESTIÓN DE LICENCIA - CONSULTA";
            this.gbInfoLicencia.ResumeLayout(false);
            this.gbClaves.ResumeLayout(false);
            this.gbClaves.PerformLayout();
            this.gbModulos.ResumeLayout(false);
            this.gbModulos.PerformLayout();
            this.ResumeLayout(false);

        }

        #region Variables del Diseñador
        private System.Windows.Forms.GroupBox gbInfoLicencia;
        private System.Windows.Forms.Label lblTipoLicencia;
        private System.Windows.Forms.Label lblUsuarios;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblFechaExpiracion;
        private System.Windows.Forms.Label lblDiasRestantes;
        private System.Windows.Forms.Label lblIdLicencia;
        private System.Windows.Forms.Label lblFechaGeneracion;
        private System.Windows.Forms.Label lblInfoLicencia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gbClaves;
        private System.Windows.Forms.Button btnCopiarClaves;
        private System.Windows.Forms.TextBox txtClaveActivacion;
        private System.Windows.Forms.TextBox txtClaveCliente;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gbModulos;
        private System.Windows.Forms.CheckedListBox chkModulos;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtModulosActivos;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtGruposActivos;
        private System.Windows.Forms.Button btnResetear;
        private System.Windows.Forms.Button btnCerrar;
        #endregion
    }
}