using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace directMnt
{
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	public partial class CreaCliAlex : System.Windows.Forms.Form
	{

		// Form reemplaza a Dispose para limpiar la lista de componentes.
		[DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components is not null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		// Requerido por el Diseñador de Windows Forms
		private System.ComponentModel.IContainer components;

		// NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
		// Se puede modificar usando el Diseñador de Windows Forms.  
		// No lo modifique con el editor de código.
		[DebuggerStepThrough()]
		private void InitializeComponent()
		{
			_CBuscador = new System.Windows.Forms.Button();
			_CBuscador.Click += new EventHandler(CBuscador_Click);
			_email = new System.Windows.Forms.TextBox();
			_email.KeyDown += new System.Windows.Forms.KeyEventHandler(email_KeyDown);
			_btncontinuar = new System.Windows.Forms.Button();
			_btncontinuar.Click += new EventHandler(btncontinuar_Click);
			_telefono2 = new System.Windows.Forms.TextBox();
			_direccion = new System.Windows.Forms.TextBox();
			_ruc = new System.Windows.Forms.TextBox();
			_ruc.KeyDown += new System.Windows.Forms.KeyEventHandler(ruc_KeyDown);
			_apellidos = new System.Windows.Forms.TextBox();
			_apellidos.TextChanged += new EventHandler(apellidos_TextChanged);
			_nombres = new System.Windows.Forms.TextBox();
			_nombres.TextChanged += new EventHandler(nombres_TextChanged);
			_fprincipal = new System.Windows.Forms.Panel();
			_telefono1 = new System.Windows.Forms.TextBox();
			_codigo = new System.Windows.Forms.TextBox();
			_codigo.KeyDown += new System.Windows.Forms.KeyEventHandler(codigo_KeyDown);
			_codigo.TextChanged += new EventHandler(codigo_TextChanged);
			_NombreImpresion = new System.Windows.Forms.Label();
			_Label7 = new System.Windows.Forms.Label();
			_Label10 = new System.Windows.Forms.Label();
			_Lcod = new System.Windows.Forms.Label();
			_Label9 = new System.Windows.Forms.Label();
			_Label5 = new System.Windows.Forms.Label();
			_Label2 = new System.Windows.Forms.Label();
			_Label1 = new System.Windows.Forms.Label();
			_Label6 = new System.Windows.Forms.Label();
			_rr = new System.Windows.Forms.Label();
			_Label4 = new System.Windows.Forms.Label();
			_Label3 = new System.Windows.Forms.Label();
			_btncancelar = new System.Windows.Forms.Button();
			_btncancelar.Click += new EventHandler(btncancelar_Click);
			_fprincipal1 = new System.Windows.Forms.GroupBox();
			_TipoIdent = new System.Windows.Forms.ComboBox();
			_TipoIdent.SelectedIndexChanged += new EventHandler(TipoIdent_SelectedIndexChanged);
			_fTipo = new System.Windows.Forms.GroupBox();
			_OpE = new System.Windows.Forms.RadioButton();
			_OpE.CheckedChanged += new EventHandler(OpE_CheckedChanged);
			_OpP = new System.Windows.Forms.RadioButton();
			_Label75 = new System.Windows.Forms.Label();
			_fprincipal.SuspendLayout();
			_fprincipal1.SuspendLayout();
			_fTipo.SuspendLayout();
			SuspendLayout();
			// 
			// CBuscador
			// 
			_CBuscador.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			_CBuscador.Cursor = System.Windows.Forms.Cursors.Default;
			_CBuscador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			_CBuscador.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.0f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			_CBuscador.ForeColor = System.Drawing.Color.White;
			_CBuscador.Location = new System.Drawing.Point(679, 76);
			_CBuscador.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			_CBuscador.Name = "_CBuscador";
			_CBuscador.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_CBuscador.Size = new System.Drawing.Size(27, 27);
			_CBuscador.TabIndex = 15;
			_CBuscador.Text = "...";
			_CBuscador.UseVisualStyleBackColor = false;
			// 
			// email
			// 
			_email.AcceptsReturn = true;
			_email.BackColor = System.Drawing.SystemColors.Window;
			_email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_email.Cursor = System.Windows.Forms.Cursors.IBeam;
			_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_email.ForeColor = System.Drawing.SystemColors.WindowText;
			_email.Location = new System.Drawing.Point(83, 174);
			_email.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			_email.MaxLength = 120;
			_email.Name = "_email";
			_email.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_email.Size = new System.Drawing.Size(747, 23);
			_email.TabIndex = 24;
			// 
			// btncontinuar
			// 
			_btncontinuar.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			_btncontinuar.Cursor = System.Windows.Forms.Cursors.Default;
			_btncontinuar.ForeColor = System.Drawing.Color.White;
			_btncontinuar.Location = new System.Drawing.Point(12, 305);
			_btncontinuar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			_btncontinuar.Name = "_btncontinuar";
			_btncontinuar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_btncontinuar.Size = new System.Drawing.Size(81, 42);
			_btncontinuar.TabIndex = 32;
			_btncontinuar.Text = "&Continuar";
			_btncontinuar.UseVisualStyleBackColor = false;
			// 
			// telefono2
			// 
			_telefono2.AcceptsReturn = true;
			_telefono2.BackColor = System.Drawing.SystemColors.Window;
			_telefono2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_telefono2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_telefono2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_telefono2.ForeColor = System.Drawing.SystemColors.WindowText;
			_telefono2.Location = new System.Drawing.Point(252, 111);
			_telefono2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			_telefono2.MaxLength = 13;
			_telefono2.Name = "_telefono2";
			_telefono2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_telefono2.Size = new System.Drawing.Size(117, 23);
			_telefono2.TabIndex = 22;
			// 
			// direccion
			// 
			_direccion.AcceptsReturn = true;
			_direccion.BackColor = System.Drawing.SystemColors.Window;
			_direccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_direccion.Cursor = System.Windows.Forms.Cursors.IBeam;
			_direccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_direccion.ForeColor = System.Drawing.SystemColors.WindowText;
			_direccion.Location = new System.Drawing.Point(83, 143);
			_direccion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			_direccion.MaxLength = 300;
			_direccion.Name = "_direccion";
			_direccion.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_direccion.Size = new System.Drawing.Size(744, 23);
			_direccion.TabIndex = 18;
			// 
			// ruc
			// 
			_ruc.AcceptsReturn = true;
			_ruc.BackColor = System.Drawing.SystemColors.Window;
			_ruc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_ruc.Cursor = System.Windows.Forms.Cursors.IBeam;
			_ruc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_ruc.ForeColor = System.Drawing.SystemColors.WindowText;
			_ruc.Location = new System.Drawing.Point(341, 10);
			_ruc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			_ruc.MaxLength = 13;
			_ruc.Name = "_ruc";
			_ruc.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_ruc.Size = new System.Drawing.Size(160, 23);
			_ruc.TabIndex = 7;
			// 
			// apellidos
			// 
			_apellidos.AcceptsReturn = true;
			_apellidos.BackColor = System.Drawing.SystemColors.Window;
			_apellidos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_apellidos.Cursor = System.Windows.Forms.Cursors.IBeam;
			_apellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_apellidos.ForeColor = System.Drawing.SystemColors.WindowText;
			_apellidos.Location = new System.Drawing.Point(496, 42);
			_apellidos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			_apellidos.MaxLength = 35;
			_apellidos.Name = "_apellidos";
			_apellidos.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_apellidos.Size = new System.Drawing.Size(331, 23);
			_apellidos.TabIndex = 11;
			// 
			// nombres
			// 
			_nombres.AcceptsReturn = true;
			_nombres.BackColor = System.Drawing.SystemColors.Window;
			_nombres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_nombres.Cursor = System.Windows.Forms.Cursors.IBeam;
			_nombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_nombres.ForeColor = System.Drawing.SystemColors.WindowText;
			_nombres.Location = new System.Drawing.Point(83, 42);
			_nombres.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			_nombres.MaxLength = 80;
			_nombres.Name = "_nombres";
			_nombres.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_nombres.Size = new System.Drawing.Size(331, 23);
			_nombres.TabIndex = 9;
			// 
			// fprincipal
			// 
			_fprincipal.BackColor = System.Drawing.Color.Transparent;
			_fprincipal.Controls.Add(_CBuscador);
			_fprincipal.Controls.Add(_email);
			_fprincipal.Controls.Add(_telefono2);
			_fprincipal.Controls.Add(_direccion);
			_fprincipal.Controls.Add(_ruc);
			_fprincipal.Controls.Add(_apellidos);
			_fprincipal.Controls.Add(_nombres);
			_fprincipal.Controls.Add(_telefono1);
			_fprincipal.Controls.Add(_codigo);
			_fprincipal.Controls.Add(_NombreImpresion);
			_fprincipal.Controls.Add(_Label7);
			_fprincipal.Controls.Add(_Label10);
			_fprincipal.Controls.Add(_Lcod);
			_fprincipal.Controls.Add(_Label9);
			_fprincipal.Controls.Add(_Label5);
			_fprincipal.Controls.Add(_Label2);
			_fprincipal.Controls.Add(_Label1);
			_fprincipal.Controls.Add(_Label6);
			_fprincipal.Controls.Add(_rr);
			_fprincipal.Controls.Add(_Label4);
			_fprincipal.Controls.Add(_Label3);
			_fprincipal.Cursor = System.Windows.Forms.Cursors.Default;
			_fprincipal.Font = new System.Drawing.Font("Times New Roman", 18.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			_fprincipal.ForeColor = System.Drawing.SystemColors.ControlText;
			_fprincipal.Location = new System.Drawing.Point(11, 79);
			_fprincipal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			_fprincipal.Name = "_fprincipal";
			_fprincipal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_fprincipal.Size = new System.Drawing.Size(843, 207);
			_fprincipal.TabIndex = 25;
			// 
			// telefono1
			// 
			_telefono1.AcceptsReturn = true;
			_telefono1.BackColor = System.Drawing.SystemColors.Window;
			_telefono1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_telefono1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_telefono1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_telefono1.ForeColor = System.Drawing.SystemColors.WindowText;
			_telefono1.Location = new System.Drawing.Point(81, 111);
			_telefono1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			_telefono1.MaxLength = 13;
			_telefono1.Name = "_telefono1";
			_telefono1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_telefono1.Size = new System.Drawing.Size(117, 23);
			_telefono1.TabIndex = 20;
			// 
			// codigo
			// 
			_codigo.AcceptsReturn = true;
			_codigo.BackColor = System.Drawing.SystemColors.Window;
			_codigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_codigo.Cursor = System.Windows.Forms.Cursors.IBeam;
			_codigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_codigo.ForeColor = System.Drawing.SystemColors.WindowText;
			_codigo.Location = new System.Drawing.Point(83, 10);
			_codigo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			_codigo.MaxLength = 15;
			_codigo.Name = "_codigo";
			_codigo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_codigo.Size = new System.Drawing.Size(160, 23);
			_codigo.TabIndex = 5;
			// 
			// NombreImpresion
			// 
			_NombreImpresion.BackColor = System.Drawing.SystemColors.Window;
			_NombreImpresion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			_NombreImpresion.Cursor = System.Windows.Forms.Cursors.Default;
			_NombreImpresion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_NombreImpresion.ForeColor = System.Drawing.SystemColors.WindowText;
			_NombreImpresion.Location = new System.Drawing.Point(83, 80);
			_NombreImpresion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			_NombreImpresion.Name = "_NombreImpresion";
			_NombreImpresion.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_NombreImpresion.Size = new System.Drawing.Size(332, 21);
			_NombreImpresion.TabIndex = 13;
			// 
			// Label7
			// 
			_Label7.AutoSize = true;
			_Label7.BackColor = System.Drawing.Color.Transparent;
			_Label7.Cursor = System.Windows.Forms.Cursors.Default;
			_Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_Label7.ForeColor = System.Drawing.Color.White;
			_Label7.Location = new System.Drawing.Point(3, 82);
			_Label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			_Label7.Name = "_Label7";
			_Label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label7.Size = new System.Drawing.Size(73, 17);
			_Label7.TabIndex = 12;
			_Label7.Text = "&Impresión:";
			// 
			// Label10
			// 
			_Label10.AutoSize = true;
			_Label10.BackColor = System.Drawing.Color.Transparent;
			_Label10.Cursor = System.Windows.Forms.Cursors.Default;
			_Label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_Label10.ForeColor = System.Drawing.Color.White;
			_Label10.Location = new System.Drawing.Point(435, 81);
			_Label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			_Label10.Name = "_Label10";
			_Label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label10.Size = new System.Drawing.Size(52, 17);
			_Label10.TabIndex = 14;
			_Label10.Text = "&Ciudad";
			// 
			// Lcod
			// 
			_Lcod.BackColor = System.Drawing.Color.White;
			_Lcod.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			_Lcod.Cursor = System.Windows.Forms.Cursors.Default;
			_Lcod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_Lcod.ForeColor = System.Drawing.SystemColors.ControlText;
			_Lcod.Location = new System.Drawing.Point(496, 80);
			_Lcod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			_Lcod.Name = "_Lcod";
			_Lcod.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Lcod.Size = new System.Drawing.Size(180, 21);
			_Lcod.TabIndex = 16;
			// 
			// Label9
			// 
			_Label9.AutoSize = true;
			_Label9.BackColor = System.Drawing.Color.Transparent;
			_Label9.Cursor = System.Windows.Forms.Cursors.Default;
			_Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_Label9.ForeColor = System.Drawing.Color.White;
			_Label9.Location = new System.Drawing.Point(33, 178);
			_Label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			_Label9.Name = "_Label9";
			_Label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label9.Size = new System.Drawing.Size(42, 17);
			_Label9.TabIndex = 23;
			_Label9.Text = "&Email";
			// 
			// Label5
			// 
			_Label5.AutoSize = true;
			_Label5.BackColor = System.Drawing.Color.Transparent;
			_Label5.Cursor = System.Windows.Forms.Cursors.Default;
			_Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_Label5.ForeColor = System.Drawing.Color.White;
			_Label5.Location = new System.Drawing.Point(209, 116);
			_Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			_Label5.Name = "_Label5";
			_Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label5.Size = new System.Drawing.Size(40, 17);
			_Label5.TabIndex = 21;
			_Label5.Text = "Te&lf2";
			// 
			// Label2
			// 
			_Label2.AutoSize = true;
			_Label2.BackColor = System.Drawing.Color.Transparent;
			_Label2.Cursor = System.Windows.Forms.Cursors.Default;
			_Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_Label2.ForeColor = System.Drawing.Color.White;
			_Label2.Location = new System.Drawing.Point(7, 148);
			_Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			_Label2.Name = "_Label2";
			_Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label2.Size = new System.Drawing.Size(67, 17);
			_Label2.TabIndex = 17;
			_Label2.Text = "&Dirección";
			// 
			// Label1
			// 
			_Label1.AutoSize = true;
			_Label1.BackColor = System.Drawing.Color.Transparent;
			_Label1.Cursor = System.Windows.Forms.Cursors.Default;
			_Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_Label1.ForeColor = System.Drawing.Color.White;
			_Label1.Location = new System.Drawing.Point(277, 15);
			_Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			_Label1.Name = "_Label1";
			_Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1.Size = new System.Drawing.Size(53, 17);
			_Label1.TabIndex = 6;
			_Label1.Text = "C.I/&Ruc";
			// 
			// Label6
			// 
			_Label6.AutoSize = true;
			_Label6.BackColor = System.Drawing.Color.Transparent;
			_Label6.Cursor = System.Windows.Forms.Cursors.Default;
			_Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_Label6.ForeColor = System.Drawing.Color.White;
			_Label6.Location = new System.Drawing.Point(3, 47);
			_Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			_Label6.Name = "_Label6";
			_Label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6.Size = new System.Drawing.Size(73, 17);
			_Label6.TabIndex = 8;
			_Label6.Text = "&Nombres :";
			// 
			// rr
			// 
			_rr.AutoSize = true;
			_rr.BackColor = System.Drawing.Color.Transparent;
			_rr.Cursor = System.Windows.Forms.Cursors.Default;
			_rr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_rr.ForeColor = System.Drawing.Color.White;
			_rr.Location = new System.Drawing.Point(45, 116);
			_rr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			_rr.Name = "_rr";
			_rr.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_rr.Size = new System.Drawing.Size(32, 17);
			_rr.TabIndex = 19;
			_rr.Text = "&Telf";
			// 
			// Label4
			// 
			_Label4.AutoSize = true;
			_Label4.BackColor = System.Drawing.Color.Transparent;
			_Label4.Cursor = System.Windows.Forms.Cursors.Default;
			_Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_Label4.ForeColor = System.Drawing.Color.White;
			_Label4.Location = new System.Drawing.Point(420, 47);
			_Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			_Label4.Name = "_Label4";
			_Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label4.Size = new System.Drawing.Size(73, 17);
			_Label4.TabIndex = 10;
			_Label4.Text = "&Apellidos :";
			// 
			// Label3
			// 
			_Label3.AutoSize = true;
			_Label3.BackColor = System.Drawing.Color.Transparent;
			_Label3.Cursor = System.Windows.Forms.Cursors.Default;
			_Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_Label3.ForeColor = System.Drawing.Color.White;
			_Label3.Location = new System.Drawing.Point(19, 15);
			_Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			_Label3.Name = "_Label3";
			_Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label3.Size = new System.Drawing.Size(56, 17);
			_Label3.TabIndex = 4;
			_Label3.Text = "C&ódigo:";
			// 
			// btncancelar
			// 
			_btncancelar.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
			_btncancelar.Cursor = System.Windows.Forms.Cursors.Default;
			_btncancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			_btncancelar.ForeColor = System.Drawing.Color.White;
			_btncancelar.Location = new System.Drawing.Point(97, 305);
			_btncancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			_btncancelar.Name = "_btncancelar";
			_btncancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_btncancelar.Size = new System.Drawing.Size(81, 42);
			_btncancelar.TabIndex = 33;
			_btncancelar.Text = "Canc&elar";
			_btncancelar.UseVisualStyleBackColor = false;
			// 
			// fprincipal1
			// 
			_fprincipal1.BackColor = System.Drawing.Color.Transparent;
			_fprincipal1.Controls.Add(_TipoIdent);
			_fprincipal1.Controls.Add(_fTipo);
			_fprincipal1.Controls.Add(_fprincipal);
			_fprincipal1.Controls.Add(_Label75);
			_fprincipal1.Font = new System.Drawing.Font("Times New Roman", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			_fprincipal1.ForeColor = System.Drawing.SystemColors.ControlText;
			_fprincipal1.Location = new System.Drawing.Point(12, -1);
			_fprincipal1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			_fprincipal1.Name = "_fprincipal1";
			_fprincipal1.Padding = new System.Windows.Forms.Padding(0);
			_fprincipal1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_fprincipal1.Size = new System.Drawing.Size(872, 299);
			_fprincipal1.TabIndex = 31;
			_fprincipal1.TabStop = false;
			// 
			// TipoIdent
			// 
			_TipoIdent.BackColor = System.Drawing.SystemColors.Window;
			_TipoIdent.Cursor = System.Windows.Forms.Cursors.Default;
			_TipoIdent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			_TipoIdent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_TipoIdent.ForeColor = System.Drawing.SystemColors.WindowText;
			_TipoIdent.Items.AddRange(new object[] { "No aplica", "Registro U Contribuyente", "Cédula Identidad", "Pasaporte", "Consumidor Final" });
			_TipoIdent.Location = new System.Drawing.Point(401, 42);
			_TipoIdent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			_TipoIdent.Name = "_TipoIdent";
			_TipoIdent.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_TipoIdent.Size = new System.Drawing.Size(192, 25);
			_TipoIdent.TabIndex = 3;
			// 
			// fTipo
			// 
			_fTipo.BackColor = System.Drawing.Color.Transparent;
			_fTipo.Controls.Add(_OpE);
			_fTipo.Controls.Add(_OpP);
			_fTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_fTipo.ForeColor = System.Drawing.SystemColors.ControlText;
			_fTipo.Location = new System.Drawing.Point(21, 20);
			_fTipo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			_fTipo.Name = "_fTipo";
			_fTipo.Padding = new System.Windows.Forms.Padding(0);
			_fTipo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_fTipo.Size = new System.Drawing.Size(247, 50);
			_fTipo.TabIndex = 1;
			_fTipo.TabStop = false;
			_fTipo.Text = "Tipo";
			// 
			// OpE
			// 
			_OpE.BackColor = System.Drawing.Color.Transparent;
			_OpE.Cursor = System.Windows.Forms.Cursors.Default;
			_OpE.ForeColor = System.Drawing.Color.White;
			_OpE.Location = new System.Drawing.Point(128, 20);
			_OpE.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			_OpE.Name = "_OpE";
			_OpE.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_OpE.Size = new System.Drawing.Size(108, 21);
			_OpE.TabIndex = 29;
			_OpE.TabStop = true;
			_OpE.Text = "Empresa";
			_OpE.UseVisualStyleBackColor = false;
			// 
			// OpP
			// 
			_OpP.BackColor = System.Drawing.Color.Transparent;
			_OpP.Checked = true;
			_OpP.Cursor = System.Windows.Forms.Cursors.Default;
			_OpP.ForeColor = System.Drawing.Color.White;
			_OpP.Location = new System.Drawing.Point(11, 20);
			_OpP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			_OpP.Name = "_OpP";
			_OpP.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_OpP.Size = new System.Drawing.Size(97, 21);
			_OpP.TabIndex = 28;
			_OpP.TabStop = true;
			_OpP.Text = "Persona";
			_OpP.UseVisualStyleBackColor = false;
			// 
			// Label75
			// 
			_Label75.BackColor = System.Drawing.Color.Transparent;
			_Label75.Cursor = System.Windows.Forms.Cursors.Default;
			_Label75.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_Label75.ForeColor = System.Drawing.Color.White;
			_Label75.Location = new System.Drawing.Point(389, 18);
			_Label75.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			_Label75.Name = "_Label75";
			_Label75.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label75.Size = new System.Drawing.Size(216, 22);
			_Label75.TabIndex = 2;
			_Label75.Text = "Tipo Documento Identificación";
			_Label75.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// CreaCliAlex
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(8.0f, 16.0f);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.DimGray;
			ClientSize = new System.Drawing.Size(871, 354);
			ControlBox = false;
			Controls.Add(_btncontinuar);
			Controls.Add(_btncancelar);
			Controls.Add(_fprincipal1);
			ForeColor = System.Drawing.Color.Black;
			Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			Name = "CreaCliAlex";
			ShowIcon = false;
			StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "ADCOMDAX - CREACION EXPRESS DE REGISTRO DE DIRECTORIO";
			_fprincipal.ResumeLayout(false);
			_fprincipal.PerformLayout();
			_fprincipal1.ResumeLayout(false);
			_fTipo.ResumeLayout(false);
			FormClosed += new System.Windows.Forms.FormClosedEventHandler(CreaCliAlex_FormClosed);
			Load += new EventHandler(CreaCliAlex_Load);
			ResumeLayout(false);

		}
		private System.Windows.Forms.Button _CBuscador;

		public virtual System.Windows.Forms.Button CBuscador
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _CBuscador;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (_CBuscador != null)
				{
					_CBuscador.Click -= CBuscador_Click;
				}

				_CBuscador = value;
				if (_CBuscador != null)
				{
					_CBuscador.Click += CBuscador_Click;
				}
			}
		}
		private System.Windows.Forms.TextBox _email;

		public virtual System.Windows.Forms.TextBox email
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _email;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (_email != null)
				{
					_email.KeyDown -= email_KeyDown;
				}

				_email = value;
				if (_email != null)
				{
					_email.KeyDown += email_KeyDown;
				}
			}
		}
		private System.Windows.Forms.Button _btncontinuar;

		public virtual System.Windows.Forms.Button btncontinuar
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _btncontinuar;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (_btncontinuar != null)
				{
					_btncontinuar.Click -= btncontinuar_Click;
				}

				_btncontinuar = value;
				if (_btncontinuar != null)
				{
					_btncontinuar.Click += btncontinuar_Click;
				}
			}
		}
		private System.Windows.Forms.TextBox _telefono2;

		public virtual System.Windows.Forms.TextBox telefono2
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _telefono2;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				_telefono2 = value;
			}
		}
		private System.Windows.Forms.TextBox _direccion;

		public virtual System.Windows.Forms.TextBox direccion
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _direccion;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				_direccion = value;
			}
		}
		private System.Windows.Forms.TextBox _ruc;

		public virtual System.Windows.Forms.TextBox ruc
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _ruc;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (_ruc != null)
				{
					_ruc.KeyDown -= ruc_KeyDown;
				}

				_ruc = value;
				if (_ruc != null)
				{
					_ruc.KeyDown += ruc_KeyDown;
				}
			}
		}
		private System.Windows.Forms.TextBox _apellidos;

		public virtual System.Windows.Forms.TextBox apellidos
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _apellidos;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (_apellidos != null)
				{
					_apellidos.TextChanged -= apellidos_TextChanged;
				}

				_apellidos = value;
				if (_apellidos != null)
				{
					_apellidos.TextChanged += apellidos_TextChanged;
				}
			}
		}
		private System.Windows.Forms.TextBox _nombres;

		public virtual System.Windows.Forms.TextBox nombres
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _nombres;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (_nombres != null)
				{
					_nombres.TextChanged -= nombres_TextChanged;
				}

				_nombres = value;
				if (_nombres != null)
				{
					_nombres.TextChanged += nombres_TextChanged;
				}
			}
		}
		private System.Windows.Forms.Panel _fprincipal;

		public virtual System.Windows.Forms.Panel fprincipal
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _fprincipal;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				_fprincipal = value;
			}
		}
		private System.Windows.Forms.TextBox _telefono1;

		public virtual System.Windows.Forms.TextBox telefono1
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _telefono1;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				_telefono1 = value;
			}
		}
		private System.Windows.Forms.TextBox _codigo;

		public virtual System.Windows.Forms.TextBox codigo
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _codigo;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (_codigo != null)
				{
					_codigo.KeyDown -= codigo_KeyDown;
					_codigo.TextChanged -= codigo_TextChanged;
				}

				_codigo = value;
				if (_codigo != null)
				{
					_codigo.KeyDown += codigo_KeyDown;
					_codigo.TextChanged += codigo_TextChanged;
				}
			}
		}
		private System.Windows.Forms.Label _NombreImpresion;

		public virtual System.Windows.Forms.Label NombreImpresion
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _NombreImpresion;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				_NombreImpresion = value;
			}
		}
		private System.Windows.Forms.Label _Label7;

		public virtual System.Windows.Forms.Label Label7
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _Label7;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				_Label7 = value;
			}
		}
		private System.Windows.Forms.Label _Label10;

		public virtual System.Windows.Forms.Label Label10
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _Label10;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				_Label10 = value;
			}
		}
		private System.Windows.Forms.Label _Lcod;

		public virtual System.Windows.Forms.Label Lcod
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _Lcod;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				_Lcod = value;
			}
		}
		private System.Windows.Forms.Label _Label9;

		public virtual System.Windows.Forms.Label Label9
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _Label9;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				_Label9 = value;
			}
		}
		private System.Windows.Forms.Label _Label5;

		public virtual System.Windows.Forms.Label Label5
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _Label5;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				_Label5 = value;
			}
		}
		private System.Windows.Forms.Label _Label2;

		public virtual System.Windows.Forms.Label Label2
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _Label2;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				_Label2 = value;
			}
		}
		private System.Windows.Forms.Label _Label1;

		public virtual System.Windows.Forms.Label Label1
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _Label1;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				_Label1 = value;
			}
		}
		private System.Windows.Forms.Label _Label6;

		public virtual System.Windows.Forms.Label Label6
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _Label6;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				_Label6 = value;
			}
		}
		private System.Windows.Forms.Label _rr;

		public virtual System.Windows.Forms.Label rr
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _rr;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				_rr = value;
			}
		}
		private System.Windows.Forms.Label _Label4;

		public virtual System.Windows.Forms.Label Label4
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _Label4;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				_Label4 = value;
			}
		}
		private System.Windows.Forms.Label _Label3;

		public virtual System.Windows.Forms.Label Label3
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _Label3;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				_Label3 = value;
			}
		}
		private System.Windows.Forms.Button _btncancelar;

		public virtual System.Windows.Forms.Button btncancelar
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _btncancelar;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (_btncancelar != null)
				{
					_btncancelar.Click -= btncancelar_Click;
				}

				_btncancelar = value;
				if (_btncancelar != null)
				{
					_btncancelar.Click += btncancelar_Click;
				}
			}
		}
		private System.Windows.Forms.GroupBox _fprincipal1;

		public virtual System.Windows.Forms.GroupBox fprincipal1
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _fprincipal1;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				_fprincipal1 = value;
			}
		}
		private System.Windows.Forms.ComboBox _TipoIdent;

		public virtual System.Windows.Forms.ComboBox TipoIdent
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _TipoIdent;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (_TipoIdent != null)
				{
					_TipoIdent.SelectedIndexChanged -= TipoIdent_SelectedIndexChanged;
				}

				_TipoIdent = value;
				if (_TipoIdent != null)
				{
					_TipoIdent.SelectedIndexChanged += TipoIdent_SelectedIndexChanged;
				}
			}
		}
		private System.Windows.Forms.GroupBox _fTipo;

		public virtual System.Windows.Forms.GroupBox fTipo
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _fTipo;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				_fTipo = value;
			}
		}
		private System.Windows.Forms.RadioButton _OpE;

		public virtual System.Windows.Forms.RadioButton OpE
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _OpE;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (_OpE != null)
				{
					_OpE.CheckedChanged -= OpE_CheckedChanged;
				}

				_OpE = value;
				if (_OpE != null)
				{
					_OpE.CheckedChanged += OpE_CheckedChanged;
				}
			}
		}
		private System.Windows.Forms.RadioButton _OpP;

		public virtual System.Windows.Forms.RadioButton OpP
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _OpP;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				_OpP = value;
			}
		}
		private System.Windows.Forms.Label _Label75;

		public virtual System.Windows.Forms.Label Label75
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _Label75;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				_Label75 = value;
			}
		}
	}
}