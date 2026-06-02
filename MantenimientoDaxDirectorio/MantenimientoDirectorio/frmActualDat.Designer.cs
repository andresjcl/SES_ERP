using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace directMnt
{
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	public partial class frmActualDat : System.Windows.Forms.Form
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
			_Label75 = new System.Windows.Forms.Label();
			_OpE = new System.Windows.Forms.RadioButton();
			_OpE.CheckedChanged += new EventHandler(OpE_CheckedChanged);
			_TipoIdent = new System.Windows.Forms.ComboBox();
			_fTipo = new System.Windows.Forms.GroupBox();
			_OpP = new System.Windows.Forms.RadioButton();
			_btncancelar = new System.Windows.Forms.Button();
			_btncancelar.Click += new EventHandler(btncancelar_Click);
			_fprincipal1 = new System.Windows.Forms.GroupBox();
			_fprincipal = new System.Windows.Forms.Panel();
			_email = new System.Windows.Forms.TextBox();
			_email.KeyDown += new System.Windows.Forms.KeyEventHandler(email_KeyDown);
			_telefono2 = new System.Windows.Forms.TextBox();
			_direccion = new System.Windows.Forms.TextBox();
			_apellidos = new System.Windows.Forms.TextBox();
			_apellidos.TextChanged += new EventHandler(apellidos_TextChanged);
			_nombres = new System.Windows.Forms.TextBox();
			_nombres.TextChanged += new EventHandler(apellidos_TextChanged);
			_telefono1 = new System.Windows.Forms.TextBox();
			_Label9 = new System.Windows.Forms.Label();
			_Label5 = new System.Windows.Forms.Label();
			_Label2 = new System.Windows.Forms.Label();
			_Label6 = new System.Windows.Forms.Label();
			_rr = new System.Windows.Forms.Label();
			_Label4 = new System.Windows.Forms.Label();
			_ruc = new System.Windows.Forms.TextBox();
			_ruc.KeyDown += new System.Windows.Forms.KeyEventHandler(ruc_KeyDown);
			_Label1 = new System.Windows.Forms.Label();
			_btncontinuar = new System.Windows.Forms.Button();
			_btncontinuar.Click += new EventHandler(btncontinuar_Click);
			_Label8 = new System.Windows.Forms.Label();
			_fTipo.SuspendLayout();
			_fprincipal1.SuspendLayout();
			_fprincipal.SuspendLayout();
			SuspendLayout();
			// 
			// Label75
			// 
			_Label75.BackColor = System.Drawing.Color.Transparent;
			_Label75.Cursor = System.Windows.Forms.Cursors.Default;
			_Label75.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_Label75.ForeColor = System.Drawing.Color.White;
			_Label75.Location = new System.Drawing.Point(214, 16);
			_Label75.Name = "_Label75";
			_Label75.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label75.Size = new System.Drawing.Size(162, 18);
			_Label75.TabIndex = 2;
			_Label75.Text = "Tipo Documento Identificación";
			_Label75.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// OpE
			// 
			_OpE.BackColor = System.Drawing.Color.DimGray;
			_OpE.Cursor = System.Windows.Forms.Cursors.Default;
			_OpE.ForeColor = System.Drawing.Color.White;
			_OpE.Location = new System.Drawing.Point(96, 16);
			_OpE.Name = "_OpE";
			_OpE.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_OpE.Size = new System.Drawing.Size(81, 17);
			_OpE.TabIndex = 29;
			_OpE.TabStop = true;
			_OpE.Text = "Empresa";
			_OpE.UseVisualStyleBackColor = false;
			// 
			// TipoIdent
			// 
			_TipoIdent.BackColor = System.Drawing.SystemColors.Window;
			_TipoIdent.Cursor = System.Windows.Forms.Cursors.Default;
			_TipoIdent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_TipoIdent.ForeColor = System.Drawing.Color.White;
			_TipoIdent.Items.AddRange(new object[] { "No aplica", "Registro U Contribuyente", "Cédula Identidad", "Pasaporte", "Consumidor Final" });
			_TipoIdent.Location = new System.Drawing.Point(223, 35);
			_TipoIdent.Name = "_TipoIdent";
			_TipoIdent.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_TipoIdent.Size = new System.Drawing.Size(145, 21);
			_TipoIdent.TabIndex = 3;
			// 
			// fTipo
			// 
			_fTipo.BackColor = System.Drawing.Color.DimGray;
			_fTipo.Controls.Add(_OpE);
			_fTipo.Controls.Add(_OpP);
			_fTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_fTipo.ForeColor = System.Drawing.Color.White;
			_fTipo.Location = new System.Drawing.Point(16, 16);
			_fTipo.Name = "_fTipo";
			_fTipo.Padding = new System.Windows.Forms.Padding(0);
			_fTipo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_fTipo.Size = new System.Drawing.Size(185, 41);
			_fTipo.TabIndex = 1;
			_fTipo.TabStop = false;
			_fTipo.Text = "Tipo";
			// 
			// OpP
			// 
			_OpP.BackColor = System.Drawing.Color.DimGray;
			_OpP.Checked = true;
			_OpP.Cursor = System.Windows.Forms.Cursors.Default;
			_OpP.ForeColor = System.Drawing.Color.White;
			_OpP.Location = new System.Drawing.Point(8, 16);
			_OpP.Name = "_OpP";
			_OpP.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_OpP.Size = new System.Drawing.Size(73, 17);
			_OpP.TabIndex = 28;
			_OpP.TabStop = true;
			_OpP.Text = "Persona";
			_OpP.UseVisualStyleBackColor = false;
			// 
			// btncancelar
			// 
			_btncancelar.BackColor = System.Drawing.Color.DimGray;
			_btncancelar.Cursor = System.Windows.Forms.Cursors.Default;
			_btncancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			_btncancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			_btncancelar.ForeColor = System.Drawing.Color.White;
			_btncancelar.Location = new System.Drawing.Point(479, 253);
			_btncancelar.Name = "_btncancelar";
			_btncancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_btncancelar.Size = new System.Drawing.Size(80, 43);
			_btncancelar.TabIndex = 36;
			_btncancelar.Text = "Canc&elar";
			_btncancelar.UseVisualStyleBackColor = false;
			// 
			// fprincipal1
			// 
			_fprincipal1.BackColor = System.Drawing.Color.DimGray;
			_fprincipal1.Controls.Add(_TipoIdent);
			_fprincipal1.Controls.Add(_fTipo);
			_fprincipal1.Controls.Add(_fprincipal);
			_fprincipal1.Controls.Add(_Label75);
			_fprincipal1.Controls.Add(_ruc);
			_fprincipal1.Controls.Add(_Label1);
			_fprincipal1.Font = new System.Drawing.Font("Times New Roman", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			_fprincipal1.ForeColor = System.Drawing.Color.White;
			_fprincipal1.Location = new System.Drawing.Point(3, 22);
			_fprincipal1.Name = "_fprincipal1";
			_fprincipal1.Padding = new System.Windows.Forms.Padding(0);
			_fprincipal1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_fprincipal1.Size = new System.Drawing.Size(654, 223);
			_fprincipal1.TabIndex = 34;
			_fprincipal1.TabStop = false;
			// 
			// fprincipal
			// 
			_fprincipal.BackColor = System.Drawing.Color.DimGray;
			_fprincipal.Controls.Add(_email);
			_fprincipal.Controls.Add(_telefono2);
			_fprincipal.Controls.Add(_direccion);
			_fprincipal.Controls.Add(_apellidos);
			_fprincipal.Controls.Add(_nombres);
			_fprincipal.Controls.Add(_telefono1);
			_fprincipal.Controls.Add(_Label9);
			_fprincipal.Controls.Add(_Label5);
			_fprincipal.Controls.Add(_Label2);
			_fprincipal.Controls.Add(_Label6);
			_fprincipal.Controls.Add(_rr);
			_fprincipal.Controls.Add(_Label4);
			_fprincipal.Cursor = System.Windows.Forms.Cursors.Default;
			_fprincipal.Font = new System.Drawing.Font("Times New Roman", 18.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			_fprincipal.ForeColor = System.Drawing.Color.White;
			_fprincipal.Location = new System.Drawing.Point(8, 64);
			_fprincipal.Name = "_fprincipal";
			_fprincipal.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_fprincipal.Size = new System.Drawing.Size(632, 148);
			_fprincipal.TabIndex = 25;
			// 
			// email
			// 
			_email.AcceptsReturn = true;
			_email.BackColor = System.Drawing.SystemColors.Window;
			_email.Cursor = System.Windows.Forms.Cursors.IBeam;
			_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_email.ForeColor = System.Drawing.Color.White;
			_email.Location = new System.Drawing.Point(61, 117);
			_email.MaxLength = 120;
			_email.Name = "_email";
			_email.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_email.Size = new System.Drawing.Size(561, 20);
			_email.TabIndex = 24;
			// 
			// telefono2
			// 
			_telefono2.AcceptsReturn = true;
			_telefono2.BackColor = System.Drawing.SystemColors.Window;
			_telefono2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_telefono2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_telefono2.ForeColor = System.Drawing.Color.White;
			_telefono2.Location = new System.Drawing.Point(61, 73);
			_telefono2.MaxLength = 13;
			_telefono2.Name = "_telefono2";
			_telefono2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_telefono2.Size = new System.Drawing.Size(89, 20);
			_telefono2.TabIndex = 22;
			// 
			// direccion
			// 
			_direccion.AcceptsReturn = true;
			_direccion.BackColor = System.Drawing.SystemColors.Window;
			_direccion.Cursor = System.Windows.Forms.Cursors.IBeam;
			_direccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_direccion.ForeColor = System.Drawing.Color.White;
			_direccion.Location = new System.Drawing.Point(62, 95);
			_direccion.MaxLength = 300;
			_direccion.Name = "_direccion";
			_direccion.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_direccion.Size = new System.Drawing.Size(559, 20);
			_direccion.TabIndex = 18;
			// 
			// apellidos
			// 
			_apellidos.AcceptsReturn = true;
			_apellidos.BackColor = System.Drawing.SystemColors.Window;
			_apellidos.Cursor = System.Windows.Forms.Cursors.IBeam;
			_apellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_apellidos.ForeColor = System.Drawing.Color.White;
			_apellidos.Location = new System.Drawing.Point(61, 30);
			_apellidos.MaxLength = 35;
			_apellidos.Name = "_apellidos";
			_apellidos.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_apellidos.Size = new System.Drawing.Size(249, 20);
			_apellidos.TabIndex = 11;
			// 
			// nombres
			// 
			_nombres.AcceptsReturn = true;
			_nombres.BackColor = System.Drawing.SystemColors.Window;
			_nombres.Cursor = System.Windows.Forms.Cursors.IBeam;
			_nombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_nombres.ForeColor = System.Drawing.Color.White;
			_nombres.Location = new System.Drawing.Point(62, 8);
			_nombres.MaxLength = 80;
			_nombres.Name = "_nombres";
			_nombres.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_nombres.Size = new System.Drawing.Size(249, 20);
			_nombres.TabIndex = 9;
			// 
			// telefono1
			// 
			_telefono1.AcceptsReturn = true;
			_telefono1.BackColor = System.Drawing.SystemColors.Window;
			_telefono1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_telefono1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_telefono1.ForeColor = System.Drawing.Color.White;
			_telefono1.Location = new System.Drawing.Point(61, 52);
			_telefono1.MaxLength = 13;
			_telefono1.Name = "_telefono1";
			_telefono1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_telefono1.Size = new System.Drawing.Size(89, 20);
			_telefono1.TabIndex = 20;
			// 
			// Label9
			// 
			_Label9.AutoSize = true;
			_Label9.BackColor = System.Drawing.Color.Transparent;
			_Label9.Cursor = System.Windows.Forms.Cursors.Default;
			_Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_Label9.ForeColor = System.Drawing.Color.White;
			_Label9.Location = new System.Drawing.Point(24, 121);
			_Label9.Name = "_Label9";
			_Label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label9.Size = new System.Drawing.Size(32, 13);
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
			_Label5.Location = new System.Drawing.Point(29, 77);
			_Label5.Name = "_Label5";
			_Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label5.Size = new System.Drawing.Size(31, 13);
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
			_Label2.Location = new System.Drawing.Point(5, 99);
			_Label2.Name = "_Label2";
			_Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label2.Size = new System.Drawing.Size(52, 13);
			_Label2.TabIndex = 17;
			_Label2.Text = "&Dirección";
			// 
			// Label6
			// 
			_Label6.AutoSize = true;
			_Label6.BackColor = System.Drawing.Color.Transparent;
			_Label6.Cursor = System.Windows.Forms.Cursors.Default;
			_Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_Label6.ForeColor = System.Drawing.Color.White;
			_Label6.Location = new System.Drawing.Point(2, 12);
			_Label6.Name = "_Label6";
			_Label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label6.Size = new System.Drawing.Size(55, 13);
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
			_rr.Location = new System.Drawing.Point(34, 56);
			_rr.Name = "_rr";
			_rr.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_rr.Size = new System.Drawing.Size(25, 13);
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
			_Label4.Location = new System.Drawing.Point(4, 34);
			_Label4.Name = "_Label4";
			_Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label4.Size = new System.Drawing.Size(55, 13);
			_Label4.TabIndex = 10;
			_Label4.Text = "&Apellidos :";
			// 
			// ruc
			// 
			_ruc.AcceptsReturn = true;
			_ruc.BackColor = System.Drawing.SystemColors.Window;
			_ruc.Cursor = System.Windows.Forms.Cursors.IBeam;
			_ruc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_ruc.ForeColor = System.Drawing.Color.White;
			_ruc.Location = new System.Drawing.Point(380, 35);
			_ruc.MaxLength = 13;
			_ruc.Name = "_ruc";
			_ruc.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_ruc.Size = new System.Drawing.Size(140, 20);
			_ruc.TabIndex = 7;
			// 
			// Label1
			// 
			_Label1.AutoSize = true;
			_Label1.BackColor = System.Drawing.Color.Transparent;
			_Label1.Cursor = System.Windows.Forms.Cursors.Default;
			_Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_Label1.ForeColor = System.Drawing.Color.White;
			_Label1.Location = new System.Drawing.Point(403, 20);
			_Label1.Name = "_Label1";
			_Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1.Size = new System.Drawing.Size(89, 13);
			_Label1.TabIndex = 6;
			_Label1.Text = "Nro.identificacion";
			// 
			// btncontinuar
			// 
			_btncontinuar.BackColor = System.Drawing.Color.DimGray;
			_btncontinuar.Cursor = System.Windows.Forms.Cursors.Default;
			_btncontinuar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			_btncontinuar.ForeColor = System.Drawing.Color.White;
			_btncontinuar.Location = new System.Drawing.Point(571, 252);
			_btncontinuar.Name = "_btncontinuar";
			_btncontinuar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_btncontinuar.Size = new System.Drawing.Size(80, 43);
			_btncontinuar.TabIndex = 35;
			_btncontinuar.Text = "&Continuar";
			_btncontinuar.UseVisualStyleBackColor = false;
			// 
			// Label8
			// 
			_Label8.AutoSize = true;
			_Label8.BackColor = System.Drawing.Color.Transparent;
			_Label8.Cursor = System.Windows.Forms.Cursors.Default;
			_Label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_Label8.ForeColor = System.Drawing.Color.White;
			_Label8.Location = new System.Drawing.Point(189, 9);
			_Label8.Name = "_Label8";
			_Label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label8.Size = new System.Drawing.Size(290, 13);
			_Label8.TabIndex = 37;
			_Label8.Text = "ACTUALIZAR DATOS DE IDENTIFICACION DIRECTORIO";
			_Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// frmActualDat
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(6.0f, 13.0f);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.DarkGray;
			ClientSize = new System.Drawing.Size(657, 306);
			ControlBox = false;
			Controls.Add(_Label8);
			Controls.Add(_btncancelar);
			Controls.Add(_fprincipal1);
			Controls.Add(_btncontinuar);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			Name = "frmActualDat";
			Text = "Actualizacion de datos del directorio";
			_fTipo.ResumeLayout(false);
			_fprincipal1.ResumeLayout(false);
			_fprincipal1.PerformLayout();
			_fprincipal.ResumeLayout(false);
			_fprincipal.PerformLayout();
			FormClosed += new System.Windows.Forms.FormClosedEventHandler(CreaCliAlex_FormClosed);
			Load += new EventHandler(CreaCliAlex_Load);
			ResumeLayout(false);
			PerformLayout();

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
				_TipoIdent = value;
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
					_nombres.TextChanged -= apellidos_TextChanged;
				}

				_nombres = value;
				if (_nombres != null)
				{
					_nombres.TextChanged += apellidos_TextChanged;
				}
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
		private System.Windows.Forms.Label _Label8;

		public virtual System.Windows.Forms.Label Label8
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _Label8;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				_Label8 = value;
			}
		}
	}
}