using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace directMnt
{
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	public partial class BuscaClientFin : System.Windows.Forms.Form
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
			var DataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			var DataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			var DataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			var DataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			var resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscaClientFin));
			chkTodos = new System.Windows.Forms.RadioButton();
			chkTodos.CheckedChanged += new EventHandler(Option10_CheckedChanged);
			Frame1 = new System.Windows.Forms.GroupBox();
			Button1 = new System.Windows.Forms.Button();
			Button1.Click += new EventHandler(Button1_Click);
			NomClienePrincipal = new System.Windows.Forms.Label();
			Label1 = new System.Windows.Forms.Label();
			_Label3 = new System.Windows.Forms.Label();
			btncancelarbusca = new System.Windows.Forms.Button();
			btncancelarbusca.Click += new EventHandler(btncancelarbusca_Click);
			btnbuscar = new System.Windows.Forms.Button();
			btnbuscar.Click += new EventHandler(btnbuscar_Click);
			btNuevo = new System.Windows.Forms.Button();
			Panel2 = new System.Windows.Forms.Panel();
			TxtNombre = new System.Windows.Forms.TextBox();
			TxtNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(TxtNombre_KeyDown);
			TxtNombre.TextChanged += new EventHandler(TxtNombre_TextChanged);
			ConInicio = new System.Windows.Forms.CheckBox();
			Panel5 = new System.Windows.Forms.Panel();
			Panel4 = new System.Windows.Forms.Panel();
			ListNombre = new System.Windows.Forms.DataGridView();
			ListNombre.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(ListNombre_CellEnter);
			ListNombre.DoubleClick += new EventHandler(ListNombre_DoubleClick);
			ListNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(ListNombre_KeyDown);
			Frame1.SuspendLayout();
			Panel2.SuspendLayout();
			Panel5.SuspendLayout();
			Panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)ListNombre).BeginInit();
			SuspendLayout();
			// 
			// chkTodos
			// 
			chkTodos.AutoSize = true;
			chkTodos.ForeColor = System.Drawing.Color.White;
			chkTodos.Location = new System.Drawing.Point(12, 53);
			chkTodos.Name = "chkTodos";
			chkTodos.Size = new System.Drawing.Size(143, 17);
			chkTodos.TabIndex = 3;
			chkTodos.Text = "To&dos los clientes finales";
			chkTodos.UseVisualStyleBackColor = true;
			// 
			// Frame1
			// 
			Frame1.BackColor = System.Drawing.Color.SteelBlue;
			Frame1.Controls.Add(Button1);
			Frame1.Controls.Add(NomClienePrincipal);
			Frame1.Controls.Add(Label1);
			Frame1.Controls.Add(chkTodos);
			Frame1.Dock = System.Windows.Forms.DockStyle.Fill;
			Frame1.Location = new System.Drawing.Point(0, 0);
			Frame1.Name = "Frame1";
			Frame1.Size = new System.Drawing.Size(574, 86);
			Frame1.TabIndex = 3;
			Frame1.TabStop = false;
			// 
			// Button1
			// 
			Button1.ForeColor = System.Drawing.Color.White;
			Button1.Location = new System.Drawing.Point(509, 49);
			Button1.Name = "Button1";
			Button1.Size = new System.Drawing.Size(53, 24);
			Button1.TabIndex = 6;
			Button1.Text = "Buscar";
			Button1.UseVisualStyleBackColor = false;
			// 
			// NomClienePrincipal
			// 
			NomClienePrincipal.ForeColor = System.Drawing.Color.White;
			NomClienePrincipal.Location = new System.Drawing.Point(157, 25);
			NomClienePrincipal.Name = "NomClienePrincipal";
			NomClienePrincipal.Size = new System.Drawing.Size(374, 13);
			NomClienePrincipal.TabIndex = 5;
			NomClienePrincipal.Text = "..";
			NomClienePrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Label1
			// 
			Label1.AutoSize = true;
			Label1.ForeColor = System.Drawing.Color.White;
			Label1.Location = new System.Drawing.Point(12, 25);
			Label1.Name = "Label1";
			Label1.Size = new System.Drawing.Size(137, 13);
			Label1.TabIndex = 4;
			Label1.Text = "Cliente Principal/Operador :";
			// 
			// Label3
			// 
			_Label3.BackColor = System.Drawing.Color.Transparent;
			_Label3.Cursor = System.Windows.Forms.Cursors.Default;
			_Label3.ForeColor = System.Drawing.Color.FromArgb(128, 128, 128);
			_Label3.Location = new System.Drawing.Point(9, 7);
			_Label3.Name = "_Label3";
			_Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label3.Size = new System.Drawing.Size(153, 33);
			_Label3.TabIndex = 25;
			_Label3.Text = "Señale el cliente y presione F3 para escojer un alias";
			_Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// btncancelarbusca
			// 
			btncancelarbusca.BackColor = System.Drawing.Color.SteelBlue;
			btncancelarbusca.ForeColor = System.Drawing.Color.White;
			btncancelarbusca.Location = new System.Drawing.Point(360, 8);
			btncancelarbusca.Name = "btncancelarbusca";
			btncancelarbusca.Size = new System.Drawing.Size(75, 23);
			btncancelarbusca.TabIndex = 2;
			btncancelarbusca.Text = "Cancelar";
			btncancelarbusca.UseVisualStyleBackColor = false;
			// 
			// btnbuscar
			// 
			btnbuscar.BackColor = System.Drawing.Color.SteelBlue;
			btnbuscar.ForeColor = System.Drawing.Color.White;
			btnbuscar.Location = new System.Drawing.Point(284, 8);
			btnbuscar.Name = "btnbuscar";
			btnbuscar.Size = new System.Drawing.Size(74, 23);
			btnbuscar.TabIndex = 1;
			btnbuscar.Text = "Aceptar";
			btnbuscar.UseVisualStyleBackColor = false;
			// 
			// btNuevo
			// 
			btNuevo.BackColor = System.Drawing.Color.SteelBlue;
			btNuevo.ForeColor = System.Drawing.Color.White;
			btNuevo.Location = new System.Drawing.Point(191, 8);
			btNuevo.Name = "btNuevo";
			btNuevo.Size = new System.Drawing.Size(92, 23);
			btNuevo.TabIndex = 0;
			btNuevo.Text = "&Nuevo Express";
			btNuevo.UseVisualStyleBackColor = false;
			// 
			// Panel2
			// 
			Panel2.BackColor = System.Drawing.Color.LightSteelBlue;
			Panel2.Controls.Add(_Label3);
			Panel2.Controls.Add(btncancelarbusca);
			Panel2.Controls.Add(btnbuscar);
			Panel2.Controls.Add(btNuevo);
			Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			Panel2.Location = new System.Drawing.Point(0, 376);
			Panel2.Name = "Panel2";
			Panel2.Size = new System.Drawing.Size(574, 43);
			Panel2.TabIndex = 21;
			// 
			// TxtNombre
			// 
			TxtNombre.Location = new System.Drawing.Point(100, 5);
			TxtNombre.Name = "TxtNombre";
			TxtNombre.Size = new System.Drawing.Size(463, 20);
			TxtNombre.TabIndex = 10;
			// 
			// ConInicio
			// 
			ConInicio.AutoSize = true;
			ConInicio.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			ConInicio.Location = new System.Drawing.Point(4, 7);
			ConInicio.Name = "ConInicio";
			ConInicio.Size = new System.Drawing.Size(86, 17);
			ConInicio.TabIndex = 9;
			ConInicio.Text = "Buscar inicio";
			ConInicio.UseVisualStyleBackColor = true;
			// 
			// Panel5
			// 
			Panel5.BackColor = System.Drawing.Color.LightSteelBlue;
			Panel5.Controls.Add(TxtNombre);
			Panel5.Controls.Add(ConInicio);
			Panel5.Dock = System.Windows.Forms.DockStyle.Top;
			Panel5.Location = new System.Drawing.Point(0, 86);
			Panel5.Name = "Panel5";
			Panel5.Size = new System.Drawing.Size(574, 31);
			Panel5.TabIndex = 23;
			// 
			// Panel4
			// 
			Panel4.BackColor = System.Drawing.Color.LightSteelBlue;
			Panel4.Controls.Add(Frame1);
			Panel4.Dock = System.Windows.Forms.DockStyle.Top;
			Panel4.Location = new System.Drawing.Point(0, 0);
			Panel4.Name = "Panel4";
			Panel4.Size = new System.Drawing.Size(574, 86);
			Panel4.TabIndex = 22;
			// 
			// ListNombre
			// 
			ListNombre.AllowUserToAddRows = false;
			ListNombre.AllowUserToDeleteRows = false;
			ListNombre.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
			ListNombre.BackgroundColor = System.Drawing.Color.White;
			DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
			DataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
			DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			ListNombre.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1;
			ListNombre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			DataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			ListNombre.DefaultCellStyle = DataGridViewCellStyle2;
			ListNombre.Dock = System.Windows.Forms.DockStyle.Fill;
			ListNombre.EnableHeadersVisualStyles = false;
			ListNombre.GridColor = System.Drawing.Color.FromArgb(224, 224, 224);
			ListNombre.Location = new System.Drawing.Point(0, 117);
			ListNombre.MultiSelect = false;
			ListNombre.Name = "ListNombre";
			ListNombre.ReadOnly = true;
			DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			DataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			ListNombre.RowHeadersDefaultCellStyle = DataGridViewCellStyle3;
			ListNombre.RowHeadersVisible = false;
			ListNombre.RowHeadersWidth = 21;
			DataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
			ListNombre.RowsDefaultCellStyle = DataGridViewCellStyle4;
			ListNombre.Size = new System.Drawing.Size(574, 259);
			ListNombre.TabIndex = 24;
			// 
			// BuscaClientFin
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(6.0f, 13.0f);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(574, 419);
			ControlBox = false;
			Controls.Add(ListNombre);
			Controls.Add(Panel2);
			Controls.Add(Panel5);
			Controls.Add(Panel4);
			Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			Name = "BuscaClientFin";
			ShowIcon = false;
			Text = "ADCOMDAX - Busca cliente final";
			Frame1.ResumeLayout(false);
			Frame1.PerformLayout();
			Panel2.ResumeLayout(false);
			Panel5.ResumeLayout(false);
			Panel5.PerformLayout();
			Panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)ListNombre).EndInit();
			Activated += new EventHandler(BuscaClien_Activated);
			Load += new EventHandler(BuscaClienFin_Load);
			ResumeLayout(false);

		}
		internal System.Windows.Forms.RadioButton chkTodos;
		internal System.Windows.Forms.GroupBox Frame1;
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
		internal System.Windows.Forms.Button btncancelarbusca;
		internal System.Windows.Forms.Button btnbuscar;
		internal System.Windows.Forms.Button btNuevo;
		internal System.Windows.Forms.Panel Panel2;
		internal System.Windows.Forms.TextBox TxtNombre;
		internal System.Windows.Forms.CheckBox ConInicio;
		internal System.Windows.Forms.Panel Panel5;
		internal System.Windows.Forms.Panel Panel4;
		internal System.Windows.Forms.Label NomClienePrincipal;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.DataGridView ListNombre;
	}
}