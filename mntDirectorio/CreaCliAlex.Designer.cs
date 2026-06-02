
namespace mntDirectorio
{
	partial class CreaCliAlex
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
			this.btncontinuar = new System.Windows.Forms.Button();
			this.btncancelar = new System.Windows.Forms.Button();
			this.fprincipal1 = new System.Windows.Forms.GroupBox();
			this.TipoIdent = new System.Windows.Forms.ComboBox();
			this.fTipo = new System.Windows.Forms.GroupBox();
			this.OpE = new System.Windows.Forms.RadioButton();
			this.OpP = new System.Windows.Forms.RadioButton();
			this.fprincipal = new System.Windows.Forms.Panel();
			this.CBuscador = new System.Windows.Forms.Button();
			this.email = new System.Windows.Forms.TextBox();
			this.telefono2 = new System.Windows.Forms.TextBox();
			this.direccion = new System.Windows.Forms.TextBox();
			this.ruc = new System.Windows.Forms.TextBox();
			this.apellidos = new System.Windows.Forms.TextBox();
			this.nombres = new System.Windows.Forms.TextBox();
			this.telefono1 = new System.Windows.Forms.TextBox();
			this.NombreImpresion = new System.Windows.Forms.Label();
			this.Label7 = new System.Windows.Forms.Label();
			this.Label10 = new System.Windows.Forms.Label();
			this.Lcod = new System.Windows.Forms.Label();
			this.Label9 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label6 = new System.Windows.Forms.Label();
			this.rr = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label75 = new System.Windows.Forms.Label();
			this.fprincipal1.SuspendLayout();
			this.fTipo.SuspendLayout();
			this.fprincipal.SuspendLayout();
			this.SuspendLayout();
			// 
			// btncontinuar
			// 
			this.btncontinuar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.btncontinuar.Cursor = System.Windows.Forms.Cursors.Default;
			this.btncontinuar.ForeColor = System.Drawing.Color.White;
			this.btncontinuar.Location = new System.Drawing.Point(0, 347);
			this.btncontinuar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btncontinuar.Name = "btncontinuar";
			this.btncontinuar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.btncontinuar.Size = new System.Drawing.Size(91, 52);
			this.btncontinuar.TabIndex = 35;
			this.btncontinuar.Text = "&Continuar";
			this.btncontinuar.UseVisualStyleBackColor = false;
			this.btncontinuar.Click += new System.EventHandler(this.btncontinuar_Click);
			// 
			// btncancelar
			// 
			this.btncancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.btncancelar.Cursor = System.Windows.Forms.Cursors.Default;
			this.btncancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btncancelar.ForeColor = System.Drawing.Color.White;
			this.btncancelar.Location = new System.Drawing.Point(95, 347);
			this.btncancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btncancelar.Name = "btncancelar";
			this.btncancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.btncancelar.Size = new System.Drawing.Size(91, 52);
			this.btncancelar.TabIndex = 36;
			this.btncancelar.Text = "Canc&elar";
			this.btncancelar.UseVisualStyleBackColor = false;
			this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
			// 
			// fprincipal1
			// 
			this.fprincipal1.BackColor = System.Drawing.Color.Transparent;
			this.fprincipal1.Controls.Add(this.TipoIdent);
			this.fprincipal1.Controls.Add(this.fprincipal);
			this.fprincipal1.Controls.Add(this.Label75);
			this.fprincipal1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.fprincipal1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.fprincipal1.Location = new System.Drawing.Point(0, 4);
			this.fprincipal1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.fprincipal1.Name = "fprincipal1";
			this.fprincipal1.Padding = new System.Windows.Forms.Padding(0);
			this.fprincipal1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fprincipal1.Size = new System.Drawing.Size(981, 336);
			this.fprincipal1.TabIndex = 34;
			this.fprincipal1.TabStop = false;
			// 
			// TipoIdent
			// 
			this.TipoIdent.BackColor = System.Drawing.SystemColors.Window;
			this.TipoIdent.Cursor = System.Windows.Forms.Cursors.Default;
			this.TipoIdent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.TipoIdent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.TipoIdent.ForeColor = System.Drawing.SystemColors.WindowText;
			this.TipoIdent.Items.AddRange(new object[] {
            "No aplica",
            "Registro U Contribuyente",
            "Cédula Identidad",
            "Pasaporte",
            "Consumidor Final"});
			this.TipoIdent.Location = new System.Drawing.Point(241, 27);
			this.TipoIdent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.TipoIdent.Name = "TipoIdent";
			this.TipoIdent.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.TipoIdent.Size = new System.Drawing.Size(216, 21);
			this.TipoIdent.TabIndex = 3;
			// 
			// fTipo
			// 
			this.fTipo.BackColor = System.Drawing.Color.Transparent;
			this.fTipo.Controls.Add(this.OpE);
			this.fTipo.Controls.Add(this.OpP);
			this.fTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.fTipo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.fTipo.Location = new System.Drawing.Point(474, 350);
			this.fTipo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.fTipo.Name = "fTipo";
			this.fTipo.Padding = new System.Windows.Forms.Padding(0);
			this.fTipo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fTipo.Size = new System.Drawing.Size(278, 62);
			this.fTipo.TabIndex = 1;
			this.fTipo.TabStop = false;
			this.fTipo.Text = "Tipo";
			this.fTipo.Visible = false;
			// 
			// OpE
			// 
			this.OpE.BackColor = System.Drawing.Color.Transparent;
			this.OpE.Cursor = System.Windows.Forms.Cursors.Default;
			this.OpE.ForeColor = System.Drawing.Color.White;
			this.OpE.Location = new System.Drawing.Point(144, 25);
			this.OpE.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.OpE.Name = "OpE";
			this.OpE.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.OpE.Size = new System.Drawing.Size(122, 26);
			this.OpE.TabIndex = 29;
			this.OpE.TabStop = true;
			this.OpE.Text = "Empresa";
			this.OpE.UseVisualStyleBackColor = false;
			// 
			// OpP
			// 
			this.OpP.BackColor = System.Drawing.Color.Transparent;
			this.OpP.Checked = true;
			this.OpP.Cursor = System.Windows.Forms.Cursors.Default;
			this.OpP.ForeColor = System.Drawing.Color.White;
			this.OpP.Location = new System.Drawing.Point(12, 25);
			this.OpP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.OpP.Name = "OpP";
			this.OpP.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.OpP.Size = new System.Drawing.Size(109, 26);
			this.OpP.TabIndex = 28;
			this.OpP.TabStop = true;
			this.OpP.Text = "Persona";
			this.OpP.UseVisualStyleBackColor = false;
			// 
			// fprincipal
			// 
			this.fprincipal.BackColor = System.Drawing.Color.Transparent;
			this.fprincipal.Controls.Add(this.CBuscador);
			this.fprincipal.Controls.Add(this.email);
			this.fprincipal.Controls.Add(this.telefono2);
			this.fprincipal.Controls.Add(this.direccion);
			this.fprincipal.Controls.Add(this.ruc);
			this.fprincipal.Controls.Add(this.apellidos);
			this.fprincipal.Controls.Add(this.nombres);
			this.fprincipal.Controls.Add(this.telefono1);
			this.fprincipal.Controls.Add(this.NombreImpresion);
			this.fprincipal.Controls.Add(this.Label7);
			this.fprincipal.Controls.Add(this.Label10);
			this.fprincipal.Controls.Add(this.Lcod);
			this.fprincipal.Controls.Add(this.Label9);
			this.fprincipal.Controls.Add(this.Label5);
			this.fprincipal.Controls.Add(this.Label2);
			this.fprincipal.Controls.Add(this.Label1);
			this.fprincipal.Controls.Add(this.Label6);
			this.fprincipal.Controls.Add(this.rr);
			this.fprincipal.Controls.Add(this.Label4);
			this.fprincipal.Cursor = System.Windows.Forms.Cursors.Default;
			this.fprincipal.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.fprincipal.ForeColor = System.Drawing.SystemColors.ControlText;
			this.fprincipal.Location = new System.Drawing.Point(12, 67);
			this.fprincipal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.fprincipal.Name = "fprincipal";
			this.fprincipal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fprincipal.Size = new System.Drawing.Size(948, 259);
			this.fprincipal.TabIndex = 25;
			// 
			// CBuscador
			// 
			this.CBuscador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.CBuscador.Cursor = System.Windows.Forms.Cursors.Default;
			this.CBuscador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CBuscador.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CBuscador.ForeColor = System.Drawing.Color.White;
			this.CBuscador.Location = new System.Drawing.Point(764, 95);
			this.CBuscador.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.CBuscador.Name = "CBuscador";
			this.CBuscador.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.CBuscador.Size = new System.Drawing.Size(30, 34);
			this.CBuscador.TabIndex = 15;
			this.CBuscador.Text = "...";
			this.CBuscador.UseVisualStyleBackColor = false;
			// 
			// email
			// 
			this.email.AcceptsReturn = true;
			this.email.BackColor = System.Drawing.SystemColors.Window;
			this.email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.email.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.email.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.email.ForeColor = System.Drawing.SystemColors.WindowText;
			this.email.Location = new System.Drawing.Point(93, 218);
			this.email.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.email.MaxLength = 120;
			this.email.Name = "email";
			this.email.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.email.Size = new System.Drawing.Size(840, 20);
			this.email.TabIndex = 24;
			// 
			// telefono2
			// 
			this.telefono2.AcceptsReturn = true;
			this.telefono2.BackColor = System.Drawing.SystemColors.Window;
			this.telefono2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.telefono2.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.telefono2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.telefono2.ForeColor = System.Drawing.SystemColors.WindowText;
			this.telefono2.Location = new System.Drawing.Point(284, 139);
			this.telefono2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.telefono2.MaxLength = 13;
			this.telefono2.Name = "telefono2";
			this.telefono2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.telefono2.Size = new System.Drawing.Size(131, 20);
			this.telefono2.TabIndex = 22;
			// 
			// direccion
			// 
			this.direccion.AcceptsReturn = true;
			this.direccion.BackColor = System.Drawing.SystemColors.Window;
			this.direccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.direccion.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.direccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.direccion.ForeColor = System.Drawing.SystemColors.WindowText;
			this.direccion.Location = new System.Drawing.Point(93, 179);
			this.direccion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.direccion.MaxLength = 300;
			this.direccion.Name = "direccion";
			this.direccion.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.direccion.Size = new System.Drawing.Size(837, 20);
			this.direccion.TabIndex = 18;
			// 
			// ruc
			// 
			this.ruc.AcceptsReturn = true;
			this.ruc.BackColor = System.Drawing.SystemColors.Window;
			this.ruc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ruc.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.ruc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.ruc.ForeColor = System.Drawing.SystemColors.WindowText;
			this.ruc.Location = new System.Drawing.Point(91, 12);
			this.ruc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.ruc.MaxLength = 13;
			this.ruc.Name = "ruc";
			this.ruc.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ruc.Size = new System.Drawing.Size(180, 20);
			this.ruc.TabIndex = 7;
			// 
			// apellidos
			// 
			this.apellidos.AcceptsReturn = true;
			this.apellidos.BackColor = System.Drawing.SystemColors.Window;
			this.apellidos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.apellidos.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.apellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.apellidos.ForeColor = System.Drawing.SystemColors.WindowText;
			this.apellidos.Location = new System.Drawing.Point(558, 52);
			this.apellidos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.apellidos.MaxLength = 35;
			this.apellidos.Name = "apellidos";
			this.apellidos.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.apellidos.Size = new System.Drawing.Size(372, 20);
			this.apellidos.TabIndex = 11;
			// 
			// nombres
			// 
			this.nombres.AcceptsReturn = true;
			this.nombres.BackColor = System.Drawing.SystemColors.Window;
			this.nombres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.nombres.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.nombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.nombres.ForeColor = System.Drawing.SystemColors.WindowText;
			this.nombres.Location = new System.Drawing.Point(93, 52);
			this.nombres.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.nombres.MaxLength = 80;
			this.nombres.Name = "nombres";
			this.nombres.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.nombres.Size = new System.Drawing.Size(372, 20);
			this.nombres.TabIndex = 9;
			// 
			// telefono1
			// 
			this.telefono1.AcceptsReturn = true;
			this.telefono1.BackColor = System.Drawing.SystemColors.Window;
			this.telefono1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.telefono1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.telefono1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.telefono1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.telefono1.Location = new System.Drawing.Point(91, 139);
			this.telefono1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.telefono1.MaxLength = 13;
			this.telefono1.Name = "telefono1";
			this.telefono1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.telefono1.Size = new System.Drawing.Size(131, 20);
			this.telefono1.TabIndex = 20;
			// 
			// NombreImpresion
			// 
			this.NombreImpresion.BackColor = System.Drawing.SystemColors.Window;
			this.NombreImpresion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.NombreImpresion.Cursor = System.Windows.Forms.Cursors.Default;
			this.NombreImpresion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.NombreImpresion.ForeColor = System.Drawing.SystemColors.WindowText;
			this.NombreImpresion.Location = new System.Drawing.Point(93, 100);
			this.NombreImpresion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.NombreImpresion.Name = "NombreImpresion";
			this.NombreImpresion.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.NombreImpresion.Size = new System.Drawing.Size(373, 26);
			this.NombreImpresion.TabIndex = 13;
			// 
			// Label7
			// 
			this.Label7.AutoSize = true;
			this.Label7.BackColor = System.Drawing.Color.Transparent;
			this.Label7.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.Label7.ForeColor = System.Drawing.Color.White;
			this.Label7.Location = new System.Drawing.Point(3, 102);
			this.Label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Label7.Name = "Label7";
			this.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label7.Size = new System.Drawing.Size(55, 13);
			this.Label7.TabIndex = 12;
			this.Label7.Text = "&Impresión:";
			// 
			// Label10
			// 
			this.Label10.AutoSize = true;
			this.Label10.BackColor = System.Drawing.Color.Transparent;
			this.Label10.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.Label10.ForeColor = System.Drawing.Color.White;
			this.Label10.Location = new System.Drawing.Point(489, 101);
			this.Label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Label10.Name = "Label10";
			this.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label10.Size = new System.Drawing.Size(40, 13);
			this.Label10.TabIndex = 14;
			this.Label10.Text = "&Ciudad";
			// 
			// Lcod
			// 
			this.Lcod.BackColor = System.Drawing.Color.White;
			this.Lcod.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Lcod.Cursor = System.Windows.Forms.Cursors.Default;
			this.Lcod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.Lcod.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Lcod.Location = new System.Drawing.Point(558, 100);
			this.Lcod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Lcod.Name = "Lcod";
			this.Lcod.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Lcod.Size = new System.Drawing.Size(202, 26);
			this.Lcod.TabIndex = 16;
			// 
			// Label9
			// 
			this.Label9.AutoSize = true;
			this.Label9.BackColor = System.Drawing.Color.Transparent;
			this.Label9.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.Label9.ForeColor = System.Drawing.Color.White;
			this.Label9.Location = new System.Drawing.Point(37, 222);
			this.Label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Label9.Name = "Label9";
			this.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label9.Size = new System.Drawing.Size(32, 13);
			this.Label9.TabIndex = 23;
			this.Label9.Text = "&Email";
			// 
			// Label5
			// 
			this.Label5.AutoSize = true;
			this.Label5.BackColor = System.Drawing.Color.Transparent;
			this.Label5.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.Label5.ForeColor = System.Drawing.Color.White;
			this.Label5.Location = new System.Drawing.Point(235, 145);
			this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Label5.Name = "Label5";
			this.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label5.Size = new System.Drawing.Size(31, 13);
			this.Label5.TabIndex = 21;
			this.Label5.Text = "Te&lf2";
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.BackColor = System.Drawing.Color.Transparent;
			this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.Label2.ForeColor = System.Drawing.Color.White;
			this.Label2.Location = new System.Drawing.Point(8, 185);
			this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Label2.Name = "Label2";
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.Size = new System.Drawing.Size(52, 13);
			this.Label2.TabIndex = 17;
			this.Label2.Text = "&Dirección";
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.BackColor = System.Drawing.Color.Transparent;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.Label1.ForeColor = System.Drawing.Color.White;
			this.Label1.Location = new System.Drawing.Point(8, 19);
			this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Label1.Name = "Label1";
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.Size = new System.Drawing.Size(45, 13);
			this.Label1.TabIndex = 6;
			this.Label1.Text = "C.I/&Ruc";
			// 
			// Label6
			// 
			this.Label6.AutoSize = true;
			this.Label6.BackColor = System.Drawing.Color.Transparent;
			this.Label6.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.Label6.ForeColor = System.Drawing.Color.White;
			this.Label6.Location = new System.Drawing.Point(3, 59);
			this.Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Label6.Name = "Label6";
			this.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label6.Size = new System.Drawing.Size(55, 13);
			this.Label6.TabIndex = 8;
			this.Label6.Text = "&Nombres :";
			// 
			// rr
			// 
			this.rr.AutoSize = true;
			this.rr.BackColor = System.Drawing.Color.Transparent;
			this.rr.Cursor = System.Windows.Forms.Cursors.Default;
			this.rr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.rr.ForeColor = System.Drawing.Color.White;
			this.rr.Location = new System.Drawing.Point(51, 145);
			this.rr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.rr.Name = "rr";
			this.rr.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.rr.Size = new System.Drawing.Size(25, 13);
			this.rr.TabIndex = 19;
			this.rr.Text = "&Telf";
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.BackColor = System.Drawing.Color.Transparent;
			this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.Label4.ForeColor = System.Drawing.Color.White;
			this.Label4.Location = new System.Drawing.Point(472, 59);
			this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Label4.Name = "Label4";
			this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label4.Size = new System.Drawing.Size(55, 13);
			this.Label4.TabIndex = 10;
			this.Label4.Text = "&Apellidos :";
			// 
			// Label75
			// 
			this.Label75.BackColor = System.Drawing.Color.Transparent;
			this.Label75.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label75.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
			this.Label75.ForeColor = System.Drawing.Color.White;
			this.Label75.Location = new System.Drawing.Point(9, 22);
			this.Label75.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Label75.Name = "Label75";
			this.Label75.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label75.Size = new System.Drawing.Size(243, 28);
			this.Label75.TabIndex = 2;
			this.Label75.Text = "Tipo Documento Identificación";
			this.Label75.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// CreaCliAlex
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Gray;
			this.ClientSize = new System.Drawing.Size(980, 414);
			this.Controls.Add(this.btncontinuar);
			this.Controls.Add(this.fTipo);
			this.Controls.Add(this.btncancelar);
			this.Controls.Add(this.fprincipal1);
			this.Name = "CreaCliAlex";
			this.Text = "CreaCliAlex";
			this.fprincipal1.ResumeLayout(false);
			this.fTipo.ResumeLayout(false);
			this.fprincipal.ResumeLayout(false);
			this.fprincipal.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.Button btncontinuar;
		public System.Windows.Forms.Button btncancelar;
		public System.Windows.Forms.GroupBox fprincipal1;
		public System.Windows.Forms.ComboBox TipoIdent;
		public System.Windows.Forms.GroupBox fTipo;
		public System.Windows.Forms.RadioButton OpE;
		public System.Windows.Forms.RadioButton OpP;
		public System.Windows.Forms.Panel fprincipal;
		public System.Windows.Forms.Button CBuscador;
		public System.Windows.Forms.TextBox email;
		public System.Windows.Forms.TextBox telefono2;
		public System.Windows.Forms.TextBox direccion;
		public System.Windows.Forms.TextBox ruc;
		public System.Windows.Forms.TextBox apellidos;
		public System.Windows.Forms.TextBox nombres;
		public System.Windows.Forms.TextBox telefono1;
		public System.Windows.Forms.Label NombreImpresion;
		public System.Windows.Forms.Label Label7;
		public System.Windows.Forms.Label Label10;
		public System.Windows.Forms.Label Lcod;
		public System.Windows.Forms.Label Label9;
		public System.Windows.Forms.Label Label5;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label Label6;
		public System.Windows.Forms.Label rr;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.Label Label75;
	}
}