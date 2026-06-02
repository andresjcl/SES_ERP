using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace directMnt
{
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	public partial class BuscaClien : System.Windows.Forms.Form
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
			var DataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			var DataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			var DataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			var DataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			Label2 = new System.Windows.Forms.Label();
			TextBox2 = new System.Windows.Forms.TextBox();
			TextBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(TxtNombre_KeyDown);
			TextBox1 = new System.Windows.Forms.TextBox();
			TextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(TxtNombre_KeyDown);
			chkAsociacion = new System.Windows.Forms.RadioButton();
			chkAsociacion.CheckedChanged += new EventHandler(Option17_CheckedChanged);
			Panel5 = new System.Windows.Forms.Panel();
			TxtNombre = new System.Windows.Forms.TextBox();
			TxtNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(TxtNombre_KeyDown);
			TxtNombre.TextChanged += new EventHandler(TxtNombre_TextChanged);
			ConInicio = new System.Windows.Forms.CheckBox();
			NombImpresion = new System.Windows.Forms.CheckBox();
			NombImpresion.CheckStateChanged += new EventHandler(NombImpresion_CheckStateChanged);
			Label1 = new System.Windows.Forms.Label();
			Panel2 = new System.Windows.Forms.Panel();
			_Label3 = new System.Windows.Forms.Label();
			btncancelarbusca = new System.Windows.Forms.Button();
			btncancelarbusca.Click += new EventHandler(btncancelarbusca_Click);
			btnbuscar = new System.Windows.Forms.Button();
			btnbuscar.Click += new EventHandler(btnbuscar_Click);
			btNuevo = new System.Windows.Forms.Button();
			btNuevo.Click += new EventHandler(btNuevo_Click);
			chkOperador = new System.Windows.Forms.RadioButton();
			chkOperador.CheckedChanged += new EventHandler(Option16_CheckedChanged);
			Frame1 = new System.Windows.Forms.GroupBox();
			chkTransporte = new System.Windows.Forms.RadioButton();
			chkTransporte.CheckedChanged += new EventHandler(Option18_CheckedChanged);
			chkFinanciera = new System.Windows.Forms.RadioButton();
			chkFinanciera.CheckedChanged += new EventHandler(Option13_CheckedChanged);
			chkVendedor = new System.Windows.Forms.RadioButton();
			chkVendedor.CheckedChanged += new EventHandler(Option15_CheckedChanged);
			chkEmpleado = new System.Windows.Forms.RadioButton();
			chkEmpleado.CheckedChanged += new EventHandler(Option14_CheckedChanged);
			chkProveedor = new System.Windows.Forms.RadioButton();
			chkProveedor.CheckedChanged += new EventHandler(Option12_CheckedChanged);
			chkCliente = new System.Windows.Forms.RadioButton();
			chkCliente.CheckedChanged += new EventHandler(Option11_CheckedChanged);
			chkTodos = new System.Windows.Forms.RadioButton();
			chkTodos.CheckedChanged += new EventHandler(Option10_CheckedChanged);
			Panel4 = new System.Windows.Forms.Panel();
			ListNombre = new System.Windows.Forms.DataGridView();
			ListNombre.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(ListNombre_CellEnter);
			ListNombre.DoubleClick += new EventHandler(ListNombre_DoubleClick);
			ListNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(ListNombre_KeyDown);
			chkMedico = new System.Windows.Forms.RadioButton();
			chkMedico.CheckedChanged += new EventHandler(chkMedico_CheckedChanged);
			Panel5.SuspendLayout();
			Panel2.SuspendLayout();
			Frame1.SuspendLayout();
			Panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)ListNombre).BeginInit();
			SuspendLayout();
			// 
			// Label2
			// 
			Label2.AutoSize = true;
			Label2.ForeColor = System.Drawing.Color.White;
			Label2.Location = new System.Drawing.Point(384, 61);
			Label2.Name = "Label2";
			Label2.Size = new System.Drawing.Size(49, 13);
			Label2.TabIndex = 14;
			Label2.Text = "Teléfono";
			// 
			// TextBox2
			// 
			TextBox2.Location = new System.Drawing.Point(461, 58);
			TextBox2.Name = "TextBox2";
			TextBox2.Size = new System.Drawing.Size(104, 20);
			TextBox2.TabIndex = 13;
			// 
			// TextBox1
			// 
			TextBox1.Location = new System.Drawing.Point(461, 35);
			TextBox1.Name = "TextBox1";
			TextBox1.Size = new System.Drawing.Size(104, 20);
			TextBox1.TabIndex = 11;
			// 
			// chkAsociacion
			// 
			chkAsociacion.AutoSize = true;
			chkAsociacion.ForeColor = System.Drawing.Color.White;
			chkAsociacion.Location = new System.Drawing.Point(287, 31);
			chkAsociacion.Name = "chkAsociacion";
			chkAsociacion.Size = new System.Drawing.Size(77, 17);
			chkAsociacion.TabIndex = 11;
			chkAsociacion.Text = "&Asociación";
			chkAsociacion.UseVisualStyleBackColor = true;
			// 
			// Panel5
			// 
			Panel5.BackColor = System.Drawing.Color.LightSteelBlue;
			Panel5.Controls.Add(TxtNombre);
			Panel5.Controls.Add(ConInicio);
			Panel5.Controls.Add(NombImpresion);
			Panel5.Dock = System.Windows.Forms.DockStyle.Top;
			Panel5.Location = new System.Drawing.Point(0, 86);
			Panel5.Name = "Panel5";
			Panel5.Size = new System.Drawing.Size(581, 47);
			Panel5.TabIndex = 19;
			// 
			// TxtNombre
			// 
			TxtNombre.Location = new System.Drawing.Point(100, 22);
			TxtNombre.Name = "TxtNombre";
			TxtNombre.Size = new System.Drawing.Size(463, 20);
			TxtNombre.TabIndex = 10;
			// 
			// ConInicio
			// 
			ConInicio.AutoSize = true;
			ConInicio.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			ConInicio.Location = new System.Drawing.Point(4, 24);
			ConInicio.Name = "ConInicio";
			ConInicio.Size = new System.Drawing.Size(86, 17);
			ConInicio.TabIndex = 9;
			ConInicio.Text = "Buscar inicio";
			ConInicio.UseVisualStyleBackColor = true;
			// 
			// NombImpresion
			// 
			NombImpresion.AutoSize = true;
			NombImpresion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			NombImpresion.Location = new System.Drawing.Point(4, 3);
			NombImpresion.Name = "NombImpresion";
			NombImpresion.Size = new System.Drawing.Size(173, 17);
			NombImpresion.TabIndex = 8;
			NombImpresion.Text = "Visualizar Nombre de Impresión";
			NombImpresion.UseVisualStyleBackColor = true;
			// 
			// Label1
			// 
			Label1.AutoSize = true;
			Label1.ForeColor = System.Drawing.Color.White;
			Label1.Location = new System.Drawing.Point(384, 38);
			Label1.Name = "Label1";
			Label1.Size = new System.Drawing.Size(71, 13);
			Label1.TabIndex = 12;
			Label1.Text = "Ficha Médica";
			// 
			// Panel2
			// 
			Panel2.BackColor = System.Drawing.Color.LightSteelBlue;
			Panel2.Controls.Add(_Label3);
			Panel2.Controls.Add(btncancelarbusca);
			Panel2.Controls.Add(btnbuscar);
			Panel2.Controls.Add(btNuevo);
			Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			Panel2.Location = new System.Drawing.Point(0, 412);
			Panel2.Name = "Panel2";
			Panel2.Size = new System.Drawing.Size(581, 43);
			Panel2.TabIndex = 17;
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
			// chkOperador
			// 
			chkOperador.AutoSize = true;
			chkOperador.ForeColor = System.Drawing.Color.White;
			chkOperador.Location = new System.Drawing.Point(287, 12);
			chkOperador.Name = "chkOperador";
			chkOperador.Size = new System.Drawing.Size(69, 17);
			chkOperador.TabIndex = 10;
			chkOperador.Text = "&Operador";
			chkOperador.UseVisualStyleBackColor = true;
			// 
			// Frame1
			// 
			Frame1.BackColor = System.Drawing.Color.SteelBlue;
			Frame1.Controls.Add(chkMedico);
			Frame1.Controls.Add(chkTransporte);
			Frame1.Controls.Add(Label2);
			Frame1.Controls.Add(TextBox2);
			Frame1.Controls.Add(Label1);
			Frame1.Controls.Add(TextBox1);
			Frame1.Controls.Add(chkAsociacion);
			Frame1.Controls.Add(chkOperador);
			Frame1.Controls.Add(chkFinanciera);
			Frame1.Controls.Add(chkVendedor);
			Frame1.Controls.Add(chkEmpleado);
			Frame1.Controls.Add(chkProveedor);
			Frame1.Controls.Add(chkCliente);
			Frame1.Controls.Add(chkTodos);
			Frame1.Dock = System.Windows.Forms.DockStyle.Fill;
			Frame1.Location = new System.Drawing.Point(0, 0);
			Frame1.Name = "Frame1";
			Frame1.Size = new System.Drawing.Size(581, 86);
			Frame1.TabIndex = 3;
			Frame1.TabStop = false;
			// 
			// chkTransporte
			// 
			chkTransporte.AutoSize = true;
			chkTransporte.ForeColor = System.Drawing.Color.White;
			chkTransporte.Location = new System.Drawing.Point(286, 52);
			chkTransporte.Name = "chkTransporte";
			chkTransporte.Size = new System.Drawing.Size(76, 17);
			chkTransporte.TabIndex = 15;
			chkTransporte.Text = "&Transporte";
			chkTransporte.UseVisualStyleBackColor = true;
			// 
			// chkFinanciera
			// 
			chkFinanciera.AutoSize = true;
			chkFinanciera.ForeColor = System.Drawing.Color.White;
			chkFinanciera.Location = new System.Drawing.Point(143, 12);
			chkFinanciera.Name = "chkFinanciera";
			chkFinanciera.Size = new System.Drawing.Size(74, 17);
			chkFinanciera.TabIndex = 9;
			chkFinanciera.Text = "&Financiera";
			chkFinanciera.UseVisualStyleBackColor = true;
			// 
			// chkVendedor
			// 
			chkVendedor.AutoSize = true;
			chkVendedor.ForeColor = System.Drawing.Color.White;
			chkVendedor.Location = new System.Drawing.Point(143, 50);
			chkVendedor.Name = "chkVendedor";
			chkVendedor.Size = new System.Drawing.Size(71, 17);
			chkVendedor.TabIndex = 8;
			chkVendedor.Text = "&Vendedor";
			chkVendedor.UseVisualStyleBackColor = true;
			// 
			// chkEmpleado
			// 
			chkEmpleado.AutoSize = true;
			chkEmpleado.ForeColor = System.Drawing.Color.White;
			chkEmpleado.Location = new System.Drawing.Point(143, 31);
			chkEmpleado.Name = "chkEmpleado";
			chkEmpleado.Size = new System.Drawing.Size(72, 17);
			chkEmpleado.TabIndex = 7;
			chkEmpleado.Text = "E&mpleado";
			chkEmpleado.UseVisualStyleBackColor = true;
			// 
			// chkProveedor
			// 
			chkProveedor.AutoSize = true;
			chkProveedor.ForeColor = System.Drawing.Color.White;
			chkProveedor.Location = new System.Drawing.Point(16, 50);
			chkProveedor.Name = "chkProveedor";
			chkProveedor.Size = new System.Drawing.Size(74, 17);
			chkProveedor.TabIndex = 5;
			chkProveedor.Text = "P&roveedor";
			chkProveedor.UseVisualStyleBackColor = true;
			// 
			// chkCliente
			// 
			chkCliente.AutoSize = true;
			chkCliente.ForeColor = System.Drawing.Color.White;
			chkCliente.Location = new System.Drawing.Point(16, 31);
			chkCliente.Name = "chkCliente";
			chkCliente.Size = new System.Drawing.Size(57, 17);
			chkCliente.TabIndex = 4;
			chkCliente.Text = "C&liente";
			chkCliente.UseVisualStyleBackColor = true;
			// 
			// chkTodos
			// 
			chkTodos.AutoSize = true;
			chkTodos.Checked = true;
			chkTodos.ForeColor = System.Drawing.Color.White;
			chkTodos.Location = new System.Drawing.Point(16, 12);
			chkTodos.Name = "chkTodos";
			chkTodos.Size = new System.Drawing.Size(55, 17);
			chkTodos.TabIndex = 3;
			chkTodos.TabStop = true;
			chkTodos.Text = "To&dos";
			chkTodos.UseVisualStyleBackColor = true;
			// 
			// Panel4
			// 
			Panel4.BackColor = System.Drawing.Color.LightSteelBlue;
			Panel4.Controls.Add(Frame1);
			Panel4.Dock = System.Windows.Forms.DockStyle.Top;
			Panel4.Location = new System.Drawing.Point(0, 0);
			Panel4.Name = "Panel4";
			Panel4.Size = new System.Drawing.Size(581, 86);
			Panel4.TabIndex = 18;
			// 
			// ListNombre
			// 
			ListNombre.AllowUserToAddRows = false;
			ListNombre.AllowUserToDeleteRows = false;
			ListNombre.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
			ListNombre.BackgroundColor = System.Drawing.Color.White;
			DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSteelBlue;
			DataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.Window;
			DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			ListNombre.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5;
			ListNombre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
			DataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
			DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			ListNombre.DefaultCellStyle = DataGridViewCellStyle6;
			ListNombre.Dock = System.Windows.Forms.DockStyle.Fill;
			ListNombre.EnableHeadersVisualStyles = false;
			ListNombre.GridColor = System.Drawing.Color.FromArgb(224, 224, 224);
			ListNombre.Location = new System.Drawing.Point(0, 133);
			ListNombre.MultiSelect = false;
			ListNombre.Name = "ListNombre";
			ListNombre.ReadOnly = true;
			DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
			DataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
			DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			ListNombre.RowHeadersDefaultCellStyle = DataGridViewCellStyle7;
			ListNombre.RowHeadersVisible = false;
			ListNombre.RowHeadersWidth = 21;
			DataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
			ListNombre.RowsDefaultCellStyle = DataGridViewCellStyle8;
			ListNombre.Size = new System.Drawing.Size(581, 279);
			ListNombre.TabIndex = 20;
			// 
			// chkMedico
			// 
			chkMedico.AutoSize = true;
			chkMedico.ForeColor = System.Drawing.Color.White;
			chkMedico.Location = new System.Drawing.Point(387, 12);
			chkMedico.Name = "chkMedico";
			chkMedico.Size = new System.Drawing.Size(60, 17);
			chkMedico.TabIndex = 16;
			chkMedico.Text = "&Médico";
			chkMedico.UseVisualStyleBackColor = true;
			// 
			// BuscaClien
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(6.0f, 13.0f);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(581, 455);
			ControlBox = false;
			Controls.Add(ListNombre);
			Controls.Add(Panel2);
			Controls.Add(Panel5);
			Controls.Add(Panel4);
			Name = "BuscaClien";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "BUSCAR CONTACTOS DEL DIRECTORIO";
			Panel5.ResumeLayout(false);
			Panel5.PerformLayout();
			Panel2.ResumeLayout(false);
			Frame1.ResumeLayout(false);
			Frame1.PerformLayout();
			Panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)ListNombre).EndInit();
			Activated += new EventHandler(BuscaClien_Activated);
			Load += new EventHandler(BuscaClien_Load);
			ResumeLayout(false);

		}
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.TextBox TextBox2;
		internal System.Windows.Forms.TextBox TextBox1;
		internal System.Windows.Forms.RadioButton chkAsociacion;
		internal System.Windows.Forms.Panel Panel5;
		internal System.Windows.Forms.TextBox TxtNombre;
		internal System.Windows.Forms.CheckBox ConInicio;
		internal System.Windows.Forms.CheckBox NombImpresion;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Panel Panel2;
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
		internal System.Windows.Forms.RadioButton chkOperador;
		internal System.Windows.Forms.GroupBox Frame1;
		internal System.Windows.Forms.RadioButton chkFinanciera;
		internal System.Windows.Forms.RadioButton chkVendedor;
		internal System.Windows.Forms.RadioButton chkEmpleado;
		internal System.Windows.Forms.RadioButton chkProveedor;
		internal System.Windows.Forms.RadioButton chkCliente;
		internal System.Windows.Forms.RadioButton chkTodos;
		internal System.Windows.Forms.Panel Panel4;
		internal System.Windows.Forms.DataGridView ListNombre;
		internal System.Windows.Forms.RadioButton chkTransporte;
		internal System.Windows.Forms.RadioButton chkMedico;
	}
}