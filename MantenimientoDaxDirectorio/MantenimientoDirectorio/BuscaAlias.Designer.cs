using System;
using System.Diagnostics;

namespace directMnt
{
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	internal partial class BuscaAlias : System.Windows.Forms.Form
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
			Panel3 = new System.Windows.Forms.Panel();
			ListNombre = new System.Windows.Forms.DataGridView();
			ListNombre.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(ListNombre_CellClick);
			ListNombre.DoubleClick += new EventHandler(ListNombre_DoubleClick);
			ListNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(ListNombre_KeyDown);
			btncancelarbusca = new System.Windows.Forms.Button();
			btncancelarbusca.Click += new EventHandler(btncancelarbusca_Click);
			btnbuscar = new System.Windows.Forms.Button();
			btnbuscar.Click += new EventHandler(btnbuscar_Click);
			Panel2 = new System.Windows.Forms.Panel();
			TxtNombre = new System.Windows.Forms.TextBox();
			TxtNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(TxtNombre_KeyDown);
			Label1 = new System.Windows.Forms.Label();
			Panel1 = new System.Windows.Forms.Panel();
			Panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)ListNombre).BeginInit();
			Panel2.SuspendLayout();
			Panel1.SuspendLayout();
			SuspendLayout();
			// 
			// Panel3
			// 
			Panel3.Controls.Add(ListNombre);
			Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			Panel3.Location = new System.Drawing.Point(0, 33);
			Panel3.Name = "Panel3";
			Panel3.Size = new System.Drawing.Size(518, 248);
			Panel3.TabIndex = 5;
			// 
			// ListNombre
			// 
			ListNombre.AllowUserToAddRows = false;
			ListNombre.AllowUserToDeleteRows = false;
			ListNombre.BackgroundColor = System.Drawing.Color.White;
			DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			DataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
			DataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
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
			ListNombre.Location = new System.Drawing.Point(0, 0);
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
			ListNombre.Size = new System.Drawing.Size(518, 248);
			ListNombre.TabIndex = 0;
			// 
			// btncancelarbusca
			// 
			btncancelarbusca.BackColor = System.Drawing.Color.SteelBlue;
			btncancelarbusca.ForeColor = System.Drawing.Color.White;
			btncancelarbusca.Location = new System.Drawing.Point(444, 3);
			btncancelarbusca.Name = "btncancelarbusca";
			btncancelarbusca.Size = new System.Drawing.Size(67, 27);
			btncancelarbusca.TabIndex = 1;
			btncancelarbusca.Text = "Cancelar";
			btncancelarbusca.UseVisualStyleBackColor = false;
			// 
			// btnbuscar
			// 
			btnbuscar.BackColor = System.Drawing.Color.SteelBlue;
			btnbuscar.ForeColor = System.Drawing.Color.White;
			btnbuscar.Location = new System.Drawing.Point(360, 3);
			btnbuscar.Name = "btnbuscar";
			btnbuscar.Size = new System.Drawing.Size(67, 27);
			btnbuscar.TabIndex = 0;
			btnbuscar.Text = "Aceptar";
			btnbuscar.UseVisualStyleBackColor = false;
			// 
			// Panel2
			// 
			Panel2.BackColor = System.Drawing.Color.LightSteelBlue;
			Panel2.Controls.Add(btncancelarbusca);
			Panel2.Controls.Add(btnbuscar);
			Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			Panel2.Location = new System.Drawing.Point(0, 281);
			Panel2.Name = "Panel2";
			Panel2.Size = new System.Drawing.Size(518, 33);
			Panel2.TabIndex = 4;
			// 
			// TxtNombre
			// 
			TxtNombre.Location = new System.Drawing.Point(44, 7);
			TxtNombre.Name = "TxtNombre";
			TxtNombre.Size = new System.Drawing.Size(408, 20);
			TxtNombre.TabIndex = 1;
			// 
			// Label1
			// 
			Label1.AutoSize = true;
			Label1.Location = new System.Drawing.Point(3, 9);
			Label1.Name = "Label1";
			Label1.Size = new System.Drawing.Size(43, 13);
			Label1.TabIndex = 0;
			Label1.Text = "Buscar:";
			// 
			// Panel1
			// 
			Panel1.BackColor = System.Drawing.Color.LightSteelBlue;
			Panel1.Controls.Add(TxtNombre);
			Panel1.Controls.Add(Label1);
			Panel1.Dock = System.Windows.Forms.DockStyle.Top;
			Panel1.Location = new System.Drawing.Point(0, 0);
			Panel1.Name = "Panel1";
			Panel1.Size = new System.Drawing.Size(518, 33);
			Panel1.TabIndex = 3;
			// 
			// BuscaAlias
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(6.0f, 13.0f);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(518, 314);
			ControlBox = false;
			Controls.Add(Panel3);
			Controls.Add(Panel2);
			Controls.Add(Panel1);
			Name = "BuscaAlias";
			ShowIcon = false;
			StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "ADCOMDAX -BUSCAR ALIAS DEL DIRECTORIO";
			Panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)ListNombre).EndInit();
			Panel2.ResumeLayout(false);
			Panel1.ResumeLayout(false);
			Panel1.PerformLayout();
			Activated += new EventHandler(BuscaAlias_Activated);
			Load += new EventHandler(BuscaAlias_Load);
			ResumeLayout(false);

		}
		internal System.Windows.Forms.Panel Panel3;
		internal System.Windows.Forms.DataGridView ListNombre;
		internal System.Windows.Forms.Button btncancelarbusca;
		internal System.Windows.Forms.Button btnbuscar;
		internal System.Windows.Forms.Panel Panel2;
		internal System.Windows.Forms.TextBox TxtNombre;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Panel Panel1;
	}
}