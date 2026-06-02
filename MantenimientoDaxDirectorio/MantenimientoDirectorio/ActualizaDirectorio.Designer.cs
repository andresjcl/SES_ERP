using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace directMnt
{
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	public partial class ActualizaDirectorio : System.Windows.Forms.Form
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
			_chkEmpresa = new System.Windows.Forms.RadioButton();
			_TipoIdent = new System.Windows.Forms.ComboBox();
			_fTipo = new System.Windows.Forms.GroupBox();
			_chkPersona = new System.Windows.Forms.RadioButton();
			_btncancelar = new System.Windows.Forms.Button();
			_btncancelar.Click += new EventHandler(btncancelar_Click);
			_fprincipal1 = new System.Windows.Forms.GroupBox();
			_fprincipal = new System.Windows.Forms.Panel();
			_txtSector = new System.Windows.Forms.TextBox();
			_lbsector = new System.Windows.Forms.Label();
			_TxtEmail = new System.Windows.Forms.TextBox();
			_TxtEmail.TextChanged += new EventHandler(TxtEmail_TextChanged);
			_TxtTelefono2 = new System.Windows.Forms.TextBox();
			_TxtTelefono2.TextChanged += new EventHandler(TxtTelefono2_TextChanged);
			_TxtDireccion = new System.Windows.Forms.TextBox();
			_TxtDireccion.TextChanged += new EventHandler(TxtDireccion_TextChanged);
			_TxtApellidos = new System.Windows.Forms.TextBox();
			_TxtApellidos.TextChanged += new EventHandler(apellidos_TextChanged);
			_TxtNombres = new System.Windows.Forms.TextBox();
			_TxtNombres.TextChanged += new EventHandler(apellidos_TextChanged);
			_TxtTelefono1 = new System.Windows.Forms.TextBox();
			_TxtTelefono1.TextChanged += new EventHandler(TxtTelefono1_TextChanged);
			_TxtNombreImpresion = new System.Windows.Forms.Label();
			_Label7 = new System.Windows.Forms.Label();
			_Label9 = new System.Windows.Forms.Label();
			_Label5 = new System.Windows.Forms.Label();
			_Label2 = new System.Windows.Forms.Label();
			_Label6 = new System.Windows.Forms.Label();
			_rr = new System.Windows.Forms.Label();
			_Label4 = new System.Windows.Forms.Label();
			_TxtRucCi = new System.Windows.Forms.TextBox();
			_Label1 = new System.Windows.Forms.Label();
			_btncontinuar = new System.Windows.Forms.Button();
			_btncontinuar.Click += new EventHandler(btncontinuar_Click);
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
			_Label75.Location = new System.Drawing.Point(218, 16);
			_Label75.Name = "_Label75";
			_Label75.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label75.Size = new System.Drawing.Size(107, 18);
			_Label75.TabIndex = 2;
			_Label75.Text = "Tipo identificacion";
			_Label75.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// chkEmpresa
			// 
			_chkEmpresa.BackColor = System.Drawing.Color.DarkGray;
			_chkEmpresa.Cursor = System.Windows.Forms.Cursors.Default;
			_chkEmpresa.ForeColor = System.Drawing.Color.White;
			_chkEmpresa.Location = new System.Drawing.Point(96, 16);
			_chkEmpresa.Name = "_chkEmpresa";
			_chkEmpresa.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkEmpresa.Size = new System.Drawing.Size(81, 17);
			_chkEmpresa.TabIndex = 29;
			_chkEmpresa.TabStop = true;
			_chkEmpresa.Text = "Juridica";
			_chkEmpresa.UseVisualStyleBackColor = false;
			// 
			// TipoIdent
			// 
			_TipoIdent.BackColor = System.Drawing.SystemColors.Window;
			_TipoIdent.Cursor = System.Windows.Forms.Cursors.Default;
			_TipoIdent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_TipoIdent.ForeColor = System.Drawing.SystemColors.WindowText;
			_TipoIdent.Items.AddRange(new object[] { "Registro U Contribuyente", "Cédula Identidad", "Pasaporte" });
			_TipoIdent.Location = new System.Drawing.Point(212, 34);
			_TipoIdent.Name = "_TipoIdent";
			_TipoIdent.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_TipoIdent.Size = new System.Drawing.Size(117, 21);
			_TipoIdent.TabIndex = 3;
			// 
			// fTipo
			// 
			_fTipo.BackColor = System.Drawing.Color.DarkGray;
			_fTipo.Controls.Add(_chkEmpresa);
			_fTipo.Controls.Add(_chkPersona);
			_fTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_fTipo.ForeColor = System.Drawing.Color.White;
			_fTipo.Location = new System.Drawing.Point(16, 16);
			_fTipo.Name = "_fTipo";
			_fTipo.Padding = new System.Windows.Forms.Padding(0);
			_fTipo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_fTipo.Size = new System.Drawing.Size(185, 41);
			_fTipo.TabIndex = 1;
			_fTipo.TabStop = false;
			_fTipo.Text = "Tipo de persona";
			// 
			// chkPersona
			// 
			_chkPersona.BackColor = System.Drawing.Color.DarkGray;
			_chkPersona.Checked = true;
			_chkPersona.Cursor = System.Windows.Forms.Cursors.Default;
			_chkPersona.ForeColor = System.Drawing.Color.White;
			_chkPersona.Location = new System.Drawing.Point(8, 16);
			_chkPersona.Name = "_chkPersona";
			_chkPersona.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_chkPersona.Size = new System.Drawing.Size(73, 17);
			_chkPersona.TabIndex = 28;
			_chkPersona.TabStop = true;
			_chkPersona.Text = "Natural";
			_chkPersona.UseVisualStyleBackColor = false;
			// 
			// btncancelar
			// 
			_btncancelar.BackColor = System.Drawing.Color.Gray;
			_btncancelar.Cursor = System.Windows.Forms.Cursors.Default;
			_btncancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			_btncancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			_btncancelar.Font = new System.Drawing.Font("Arial", 9.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			_btncancelar.ForeColor = System.Drawing.Color.White;
			_btncancelar.Location = new System.Drawing.Point(575, 208);
			_btncancelar.Name = "_btncancelar";
			_btncancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_btncancelar.Size = new System.Drawing.Size(77, 51);
			_btncancelar.TabIndex = 36;
			_btncancelar.Text = "Canc&elar";
			_btncancelar.UseVisualStyleBackColor = false;
			// 
			// fprincipal1
			// 
			_fprincipal1.BackColor = System.Drawing.Color.DarkGray;
			_fprincipal1.Controls.Add(_TipoIdent);
			_fprincipal1.Controls.Add(_fTipo);
			_fprincipal1.Controls.Add(_fprincipal);
			_fprincipal1.Controls.Add(_TxtRucCi);
			_fprincipal1.Controls.Add(_Label1);
			_fprincipal1.Controls.Add(_Label75);
			_fprincipal1.Font = new System.Drawing.Font("Times New Roman", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			_fprincipal1.ForeColor = System.Drawing.Color.White;
			_fprincipal1.Location = new System.Drawing.Point(2, 2);
			_fprincipal1.Name = "_fprincipal1";
			_fprincipal1.Padding = new System.Windows.Forms.Padding(0);
			_fprincipal1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_fprincipal1.Size = new System.Drawing.Size(654, 204);
			_fprincipal1.TabIndex = 34;
			_fprincipal1.TabStop = false;
			// 
			// fprincipal
			// 
			_fprincipal.BackColor = System.Drawing.Color.DarkGray;
			_fprincipal.Controls.Add(_txtSector);
			_fprincipal.Controls.Add(_lbsector);
			_fprincipal.Controls.Add(_TxtEmail);
			_fprincipal.Controls.Add(_TxtTelefono2);
			_fprincipal.Controls.Add(_TxtDireccion);
			_fprincipal.Controls.Add(_TxtApellidos);
			_fprincipal.Controls.Add(_TxtNombres);
			_fprincipal.Controls.Add(_TxtTelefono1);
			_fprincipal.Controls.Add(_TxtNombreImpresion);
			_fprincipal.Controls.Add(_Label7);
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
			_fprincipal.Size = new System.Drawing.Size(632, 126);
			_fprincipal.TabIndex = 25;
			// 
			// txtSector
			// 
			_txtSector.AcceptsReturn = true;
			_txtSector.BackColor = System.Drawing.SystemColors.Window;
			_txtSector.Cursor = System.Windows.Forms.Cursors.IBeam;
			_txtSector.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_txtSector.ForeColor = System.Drawing.SystemColors.WindowText;
			_txtSector.Location = new System.Drawing.Point(99, 103);
			_txtSector.MaxLength = 180;
			_txtSector.Name = "_txtSector";
			_txtSector.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_txtSector.Size = new System.Drawing.Size(524, 20);
			_txtSector.TabIndex = 26;
			// 
			// lbsector
			// 
			_lbsector.AutoSize = true;
			_lbsector.BackColor = System.Drawing.Color.Transparent;
			_lbsector.Cursor = System.Windows.Forms.Cursors.Default;
			_lbsector.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_lbsector.ForeColor = System.Drawing.Color.White;
			_lbsector.Location = new System.Drawing.Point(5, 107);
			_lbsector.Name = "_lbsector";
			_lbsector.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_lbsector.Size = new System.Drawing.Size(95, 13);
			_lbsector.TabIndex = 25;
			_lbsector.Text = "&Sector/Referencia";
			// 
			// TxtEmail
			// 
			_TxtEmail.AcceptsReturn = true;
			_TxtEmail.BackColor = System.Drawing.SystemColors.Window;
			_TxtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
			_TxtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_TxtEmail.ForeColor = System.Drawing.SystemColors.WindowText;
			_TxtEmail.Location = new System.Drawing.Point(62, 78);
			_TxtEmail.MaxLength = 180;
			_TxtEmail.Name = "_TxtEmail";
			_TxtEmail.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_TxtEmail.Size = new System.Drawing.Size(561, 20);
			_TxtEmail.TabIndex = 24;
			// 
			// TxtTelefono2
			// 
			_TxtTelefono2.AcceptsReturn = true;
			_TxtTelefono2.BackColor = System.Drawing.SystemColors.Window;
			_TxtTelefono2.Cursor = System.Windows.Forms.Cursors.IBeam;
			_TxtTelefono2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_TxtTelefono2.ForeColor = System.Drawing.SystemColors.WindowText;
			_TxtTelefono2.Location = new System.Drawing.Point(530, 51);
			_TxtTelefono2.MaxLength = 13;
			_TxtTelefono2.Name = "_TxtTelefono2";
			_TxtTelefono2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_TxtTelefono2.Size = new System.Drawing.Size(89, 20);
			_TxtTelefono2.TabIndex = 22;
			// 
			// TxtDireccion
			// 
			_TxtDireccion.AcceptsReturn = true;
			_TxtDireccion.BackColor = System.Drawing.SystemColors.Window;
			_TxtDireccion.Cursor = System.Windows.Forms.Cursors.IBeam;
			_TxtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_TxtDireccion.ForeColor = System.Drawing.SystemColors.WindowText;
			_TxtDireccion.Location = new System.Drawing.Point(62, 54);
			_TxtDireccion.MaxLength = 150;
			_TxtDireccion.Name = "_TxtDireccion";
			_TxtDireccion.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_TxtDireccion.Size = new System.Drawing.Size(307, 20);
			_TxtDireccion.TabIndex = 18;
			// 
			// TxtApellidos
			// 
			_TxtApellidos.AcceptsReturn = true;
			_TxtApellidos.BackColor = System.Drawing.SystemColors.Window;
			_TxtApellidos.Cursor = System.Windows.Forms.Cursors.IBeam;
			_TxtApellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_TxtApellidos.ForeColor = System.Drawing.Color.Black;
			_TxtApellidos.Location = new System.Drawing.Point(372, 6);
			_TxtApellidos.MaxLength = 50;
			_TxtApellidos.Name = "_TxtApellidos";
			_TxtApellidos.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_TxtApellidos.Size = new System.Drawing.Size(249, 20);
			_TxtApellidos.TabIndex = 11;
			// 
			// TxtNombres
			// 
			_TxtNombres.AcceptsReturn = true;
			_TxtNombres.BackColor = System.Drawing.SystemColors.Window;
			_TxtNombres.Cursor = System.Windows.Forms.Cursors.IBeam;
			_TxtNombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_TxtNombres.ForeColor = System.Drawing.SystemColors.WindowText;
			_TxtNombres.Location = new System.Drawing.Point(62, 6);
			_TxtNombres.MaxLength = 80;
			_TxtNombres.Name = "_TxtNombres";
			_TxtNombres.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_TxtNombres.Size = new System.Drawing.Size(249, 20);
			_TxtNombres.TabIndex = 9;
			// 
			// TxtTelefono1
			// 
			_TxtTelefono1.AcceptsReturn = true;
			_TxtTelefono1.BackColor = System.Drawing.SystemColors.Window;
			_TxtTelefono1.Cursor = System.Windows.Forms.Cursors.IBeam;
			_TxtTelefono1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_TxtTelefono1.ForeColor = System.Drawing.SystemColors.WindowText;
			_TxtTelefono1.Location = new System.Drawing.Point(402, 51);
			_TxtTelefono1.MaxLength = 13;
			_TxtTelefono1.Name = "_TxtTelefono1";
			_TxtTelefono1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_TxtTelefono1.Size = new System.Drawing.Size(89, 20);
			_TxtTelefono1.TabIndex = 20;
			// 
			// TxtNombreImpresion
			// 
			_TxtNombreImpresion.BackColor = System.Drawing.SystemColors.Window;
			_TxtNombreImpresion.Cursor = System.Windows.Forms.Cursors.Default;
			_TxtNombreImpresion.Enabled = false;
			_TxtNombreImpresion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_TxtNombreImpresion.ForeColor = System.Drawing.SystemColors.WindowText;
			_TxtNombreImpresion.Location = new System.Drawing.Point(62, 31);
			_TxtNombreImpresion.Name = "_TxtNombreImpresion";
			_TxtNombreImpresion.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_TxtNombreImpresion.Size = new System.Drawing.Size(410, 17);
			_TxtNombreImpresion.TabIndex = 13;
			// 
			// Label7
			// 
			_Label7.AutoSize = true;
			_Label7.BackColor = System.Drawing.Color.Transparent;
			_Label7.Cursor = System.Windows.Forms.Cursors.Default;
			_Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_Label7.ForeColor = System.Drawing.Color.White;
			_Label7.Location = new System.Drawing.Point(2, 33);
			_Label7.Name = "_Label7";
			_Label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label7.Size = new System.Drawing.Size(55, 13);
			_Label7.TabIndex = 12;
			_Label7.Text = "&Impresión:";
			// 
			// Label9
			// 
			_Label9.AutoSize = true;
			_Label9.BackColor = System.Drawing.Color.Transparent;
			_Label9.Cursor = System.Windows.Forms.Cursors.Default;
			_Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_Label9.ForeColor = System.Drawing.Color.White;
			_Label9.Location = new System.Drawing.Point(5, 82);
			_Label9.Name = "_Label9";
			_Label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label9.Size = new System.Drawing.Size(59, 13);
			_Label9.TabIndex = 23;
			_Label9.Text = "&Correo Elc.";
			// 
			// Label5
			// 
			_Label5.AutoSize = true;
			_Label5.BackColor = System.Drawing.Color.Transparent;
			_Label5.Cursor = System.Windows.Forms.Cursors.Default;
			_Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_Label5.ForeColor = System.Drawing.Color.White;
			_Label5.Location = new System.Drawing.Point(498, 55);
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
			_Label2.Location = new System.Drawing.Point(5, 58);
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
			_Label6.Location = new System.Drawing.Point(2, 10);
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
			_rr.Location = new System.Drawing.Point(375, 55);
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
			_Label4.Location = new System.Drawing.Point(315, 10);
			_Label4.Name = "_Label4";
			_Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label4.Size = new System.Drawing.Size(55, 13);
			_Label4.TabIndex = 10;
			_Label4.Text = "&Apellidos :";
			// 
			// TxtRucCi
			// 
			_TxtRucCi.AcceptsReturn = true;
			_TxtRucCi.BackColor = System.Drawing.SystemColors.Window;
			_TxtRucCi.Cursor = System.Windows.Forms.Cursors.IBeam;
			_TxtRucCi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_TxtRucCi.ForeColor = System.Drawing.SystemColors.WindowText;
			_TxtRucCi.Location = new System.Drawing.Point(349, 34);
			_TxtRucCi.MaxLength = 13;
			_TxtRucCi.Name = "_TxtRucCi";
			_TxtRucCi.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_TxtRucCi.Size = new System.Drawing.Size(131, 20);
			_TxtRucCi.TabIndex = 7;
			// 
			// Label1
			// 
			_Label1.AutoSize = true;
			_Label1.BackColor = System.Drawing.Color.Transparent;
			_Label1.Cursor = System.Windows.Forms.Cursors.Default;
			_Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
			_Label1.ForeColor = System.Drawing.Color.White;
			_Label1.Location = new System.Drawing.Point(349, 20);
			_Label1.Name = "_Label1";
			_Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1.Size = new System.Drawing.Size(130, 13);
			_Label1.TabIndex = 6;
			_Label1.Text = "Nro. Documento identifica" + '\r' + '\n';
			// 
			// btncontinuar
			// 
			_btncontinuar.BackColor = System.Drawing.Color.Gray;
			_btncontinuar.Cursor = System.Windows.Forms.Cursors.Default;
			_btncontinuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			_btncontinuar.Font = new System.Drawing.Font("Arial", 9.0f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			_btncontinuar.ForeColor = System.Drawing.Color.White;
			_btncontinuar.Location = new System.Drawing.Point(494, 208);
			_btncontinuar.Name = "_btncontinuar";
			_btncontinuar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_btncontinuar.Size = new System.Drawing.Size(77, 51);
			_btncontinuar.TabIndex = 35;
			_btncontinuar.Text = "&Continuar";
			_btncontinuar.UseVisualStyleBackColor = false;
			// 
			// ActualizaDirectorio
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(6.0f, 13.0f);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.DarkGray;
			ClientSize = new System.Drawing.Size(657, 263);
			Controls.Add(_btncancelar);
			Controls.Add(_fprincipal1);
			Controls.Add(_btncontinuar);
			FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			Name = "ActualizaDirectorio";
			Text = "ACTUALIZAR DATOS DE IDENTIFICACION ";
			_fTipo.ResumeLayout(false);
			_fprincipal1.ResumeLayout(false);
			_fprincipal1.PerformLayout();
			_fprincipal.ResumeLayout(false);
			_fprincipal.PerformLayout();
			FormClosed += new System.Windows.Forms.FormClosedEventHandler(ActualizaDir_FormClosed);
			ResumeLayout(false);

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
		private System.Windows.Forms.RadioButton _chkEmpresa;

		public virtual System.Windows.Forms.RadioButton chkEmpresa
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _chkEmpresa;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				_chkEmpresa = value;
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
		private System.Windows.Forms.RadioButton _chkPersona;

		public virtual System.Windows.Forms.RadioButton chkPersona
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _chkPersona;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				_chkPersona = value;
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
		private System.Windows.Forms.TextBox _TxtEmail;

		public virtual System.Windows.Forms.TextBox TxtEmail
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _TxtEmail;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (_TxtEmail != null)
				{
					_TxtEmail.TextChanged -= TxtEmail_TextChanged;
				}

				_TxtEmail = value;
				if (_TxtEmail != null)
				{
					_TxtEmail.TextChanged += TxtEmail_TextChanged;
				}
			}
		}
		private System.Windows.Forms.TextBox _TxtTelefono2;

		public virtual System.Windows.Forms.TextBox TxtTelefono2
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _TxtTelefono2;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (_TxtTelefono2 != null)
				{
					_TxtTelefono2.TextChanged -= TxtTelefono2_TextChanged;
				}

				_TxtTelefono2 = value;
				if (_TxtTelefono2 != null)
				{
					_TxtTelefono2.TextChanged += TxtTelefono2_TextChanged;
				}
			}
		}
		private System.Windows.Forms.TextBox _TxtDireccion;

		public virtual System.Windows.Forms.TextBox TxtDireccion
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _TxtDireccion;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (_TxtDireccion != null)
				{
					_TxtDireccion.TextChanged -= TxtDireccion_TextChanged;
				}

				_TxtDireccion = value;
				if (_TxtDireccion != null)
				{
					_TxtDireccion.TextChanged += TxtDireccion_TextChanged;
				}
			}
		}
		private System.Windows.Forms.TextBox _TxtRucCi;

		public virtual System.Windows.Forms.TextBox TxtRucCi
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _TxtRucCi;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				_TxtRucCi = value;
			}
		}
		private System.Windows.Forms.TextBox _TxtApellidos;

		public virtual System.Windows.Forms.TextBox TxtApellidos
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _TxtApellidos;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (_TxtApellidos != null)
				{
					_TxtApellidos.TextChanged -= apellidos_TextChanged;
				}

				_TxtApellidos = value;
				if (_TxtApellidos != null)
				{
					_TxtApellidos.TextChanged += apellidos_TextChanged;
				}
			}
		}
		private System.Windows.Forms.TextBox _TxtNombres;

		public virtual System.Windows.Forms.TextBox TxtNombres
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _TxtNombres;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (_TxtNombres != null)
				{
					_TxtNombres.TextChanged -= apellidos_TextChanged;
				}

				_TxtNombres = value;
				if (_TxtNombres != null)
				{
					_TxtNombres.TextChanged += apellidos_TextChanged;
				}
			}
		}
		private System.Windows.Forms.TextBox _TxtTelefono1;

		public virtual System.Windows.Forms.TextBox TxtTelefono1
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _TxtTelefono1;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (_TxtTelefono1 != null)
				{
					_TxtTelefono1.TextChanged -= TxtTelefono1_TextChanged;
				}

				_TxtTelefono1 = value;
				if (_TxtTelefono1 != null)
				{
					_TxtTelefono1.TextChanged += TxtTelefono1_TextChanged;
				}
			}
		}
		private System.Windows.Forms.Label _TxtNombreImpresion;

		public virtual System.Windows.Forms.Label TxtNombreImpresion
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _TxtNombreImpresion;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				_TxtNombreImpresion = value;
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
		private System.Windows.Forms.TextBox _txtSector;

		public virtual System.Windows.Forms.TextBox txtSector
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _txtSector;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				_txtSector = value;
			}
		}
		private System.Windows.Forms.Label _lbsector;

		public virtual System.Windows.Forms.Label lbsector
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _lbsector;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				_lbsector = value;
			}
		}
	}
}