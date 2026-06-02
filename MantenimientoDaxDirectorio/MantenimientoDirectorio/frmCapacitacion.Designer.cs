using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace directMnt
{
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	public partial class frmCapacitacion : System.Windows.Forms.Form
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
			NivelEstudio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Panel1 = new System.Windows.Forms.Panel();
			Panel1.Paint += new System.Windows.Forms.PaintEventHandler(Panel1_Paint);
			_LabEmpleado = new System.Windows.Forms.Label();
			_Label1 = new System.Windows.Forms.Label();
			Retirado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			Especializacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			EnCurso = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			CursosCarrera = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Graduado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			Titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			FechaFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Institucion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Panel2 = new System.Windows.Forms.Panel();
			btnGuardar = new System.Windows.Forms.Button();
			btnGuardar.Click += new EventHandler(btnGuardar_Click);
			Pais = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Panel3 = new System.Windows.Forms.Panel();
			malla = new System.Windows.Forms.DataGridView();
			malla.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(malla_CellEndEdit);
			malla.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(malla_CellEnter);
			malla.KeyDown += new System.Windows.Forms.KeyEventHandler(malla_KeyDown);
			malla.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(Malla_EditingControlShowing);
			CursosAprobados = new System.Windows.Forms.DataGridViewTextBoxColumn();
			Panel1.SuspendLayout();
			Panel2.SuspendLayout();
			Panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)malla).BeginInit();
			SuspendLayout();
			// 
			// NivelEstudio
			// 
			NivelEstudio.HeaderText = "Nivel Estudio";
			NivelEstudio.Name = "NivelEstudio";
			NivelEstudio.Width = 87;
			// 
			// Panel1
			// 
			Panel1.BackColor = System.Drawing.Color.DimGray;
			Panel1.Controls.Add(_LabEmpleado);
			Panel1.Controls.Add(_Label1);
			Panel1.Dock = System.Windows.Forms.DockStyle.Top;
			Panel1.ForeColor = System.Drawing.Color.White;
			Panel1.Location = new System.Drawing.Point(0, 0);
			Panel1.Name = "Panel1";
			Panel1.Size = new System.Drawing.Size(936, 43);
			Panel1.TabIndex = 3;
			// 
			// LabEmpleado
			// 
			_LabEmpleado.BackColor = System.Drawing.SystemColors.Window;
			_LabEmpleado.Cursor = System.Windows.Forms.Cursors.Default;
			_LabEmpleado.ForeColor = System.Drawing.SystemColors.WindowText;
			_LabEmpleado.Location = new System.Drawing.Point(68, 13);
			_LabEmpleado.Name = "_LabEmpleado";
			_LabEmpleado.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_LabEmpleado.Size = new System.Drawing.Size(569, 17);
			_LabEmpleado.TabIndex = 6;
			// 
			// Label1
			// 
			_Label1.BackColor = System.Drawing.Color.Transparent;
			_Label1.Cursor = System.Windows.Forms.Cursors.Default;
			_Label1.ForeColor = System.Drawing.Color.White;
			_Label1.Location = new System.Drawing.Point(5, 13);
			_Label1.Name = "_Label1";
			_Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			_Label1.Size = new System.Drawing.Size(65, 17);
			_Label1.TabIndex = 5;
			_Label1.Text = "Empleado:";
			// 
			// Retirado
			// 
			Retirado.HeaderText = "Retirado";
			Retirado.Name = "Retirado";
			Retirado.Width = 53;
			// 
			// Especializacion
			// 
			Especializacion.HeaderText = "Especialización";
			Especializacion.Name = "Especializacion";
			Especializacion.Width = 105;
			// 
			// EnCurso
			// 
			EnCurso.HeaderText = "En Curso";
			EnCurso.Name = "EnCurso";
			EnCurso.Width = 50;
			// 
			// CursosCarrera
			// 
			CursosCarrera.HeaderText = "Cursos de la Carrerra";
			CursosCarrera.Name = "CursosCarrera";
			CursosCarrera.Width = 86;
			// 
			// Graduado
			// 
			Graduado.HeaderText = "Graduado";
			Graduado.Name = "Graduado";
			Graduado.Width = 60;
			// 
			// Titulo
			// 
			Titulo.HeaderText = "Título";
			Titulo.Name = "Titulo";
			Titulo.Width = 60;
			// 
			// FechaFinal
			// 
			FechaFinal.HeaderText = "Fecha Final";
			FechaFinal.Name = "FechaFinal";
			FechaFinal.Width = 80;
			// 
			// Institucion
			// 
			Institucion.HeaderText = "Institución";
			Institucion.Name = "Institucion";
			Institucion.Width = 80;
			// 
			// Panel2
			// 
			Panel2.BackColor = System.Drawing.Color.DarkGray;
			Panel2.Controls.Add(btnGuardar);
			Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			Panel2.Location = new System.Drawing.Point(0, 300);
			Panel2.Name = "Panel2";
			Panel2.Size = new System.Drawing.Size(936, 44);
			Panel2.TabIndex = 4;
			// 
			// btnGuardar
			// 
			btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			btnGuardar.BackColor = System.Drawing.Color.DimGray;
			btnGuardar.FlatAppearance.BorderSize = 0;
			btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnGuardar.ForeColor = System.Drawing.Color.White;
			btnGuardar.Location = new System.Drawing.Point(839, 9);
			btnGuardar.Name = "btnGuardar";
			btnGuardar.Size = new System.Drawing.Size(89, 27);
			btnGuardar.TabIndex = 0;
			btnGuardar.Text = "Guardar";
			btnGuardar.UseVisualStyleBackColor = false;
			// 
			// Pais
			// 
			Pais.HeaderText = "País";
			Pais.Name = "Pais";
			Pais.Width = 54;
			// 
			// Panel3
			// 
			Panel3.Controls.Add(malla);
			Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			Panel3.Location = new System.Drawing.Point(0, 43);
			Panel3.Name = "Panel3";
			Panel3.Size = new System.Drawing.Size(936, 301);
			Panel3.TabIndex = 5;
			// 
			// malla
			// 
			malla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
			malla.BackgroundColor = System.Drawing.Color.White;
			DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			DataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
			DataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
			DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			malla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1;
			malla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			malla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Pais, Institucion, Titulo, Especializacion, NivelEstudio, Retirado, EnCurso, Graduado, FechaFinal, CursosCarrera, CursosAprobados });
			DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			DataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
			DataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			malla.DefaultCellStyle = DataGridViewCellStyle2;
			malla.Dock = System.Windows.Forms.DockStyle.Fill;
			malla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
			malla.EnableHeadersVisualStyles = false;
			malla.GridColor = System.Drawing.Color.FromArgb(224, 224, 224);
			malla.Location = new System.Drawing.Point(0, 0);
			malla.Name = "malla";
			DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			DataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue;
			DataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
			DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			malla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3;
			malla.RowHeadersWidth = 45;
			malla.Size = new System.Drawing.Size(936, 301);
			malla.TabIndex = 3;
			// 
			// CursosAprobados
			// 
			CursosAprobados.HeaderText = "Cursos Aprobados";
			CursosAprobados.Name = "CursosAprobados";
			CursosAprobados.Width = 108;
			// 
			// frmCapacitacion
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(6.0f, 13.0f);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(936, 344);
			Controls.Add(Panel2);
			Controls.Add(Panel3);
			Controls.Add(Panel1);
			Name = "frmCapacitacion";
			ShowIcon = false;
			StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "ADCOMDAX - MANTENIMIENTO CAPACITACION DEL PERSONAL";
			Panel1.ResumeLayout(false);
			Panel2.ResumeLayout(false);
			Panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)malla).EndInit();
			Load += new EventHandler(frmCapacitacion_Load);
			ResumeLayout(false);

		}
		internal System.Windows.Forms.DataGridViewTextBoxColumn NivelEstudio;
		internal System.Windows.Forms.Panel Panel1;
		private System.Windows.Forms.Label _LabEmpleado;

		public virtual System.Windows.Forms.Label LabEmpleado
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			get
			{
				return _LabEmpleado;
			}

			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				_LabEmpleado = value;
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
		internal System.Windows.Forms.DataGridViewCheckBoxColumn Retirado;
		internal System.Windows.Forms.DataGridViewTextBoxColumn Especializacion;
		internal System.Windows.Forms.DataGridViewCheckBoxColumn EnCurso;
		internal System.Windows.Forms.DataGridViewTextBoxColumn CursosCarrera;
		internal System.Windows.Forms.DataGridViewCheckBoxColumn Graduado;
		internal System.Windows.Forms.DataGridViewTextBoxColumn Titulo;
		internal System.Windows.Forms.DataGridViewTextBoxColumn FechaFinal;
		internal System.Windows.Forms.DataGridViewTextBoxColumn Institucion;
		internal System.Windows.Forms.Panel Panel2;
		internal System.Windows.Forms.Button btnGuardar;
		internal System.Windows.Forms.DataGridViewTextBoxColumn Pais;
		internal System.Windows.Forms.Panel Panel3;
		internal System.Windows.Forms.DataGridView malla;
		internal System.Windows.Forms.DataGridViewTextBoxColumn CursosAprobados;
	}
}