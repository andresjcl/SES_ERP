using System;
using System.Diagnostics;

namespace directMnt
{
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	internal partial class EscojeCamposDir : System.Windows.Forms.Form
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
			Panel1 = new System.Windows.Forms.Panel();
			Command3 = new System.Windows.Forms.Button();
			Command3.Click += new EventHandler(Command3_Click);
			Command2 = new System.Windows.Forms.Button();
			Command2.Click += new EventHandler(Command2_Click);
			Command1 = new System.Windows.Forms.Button();
			Command1.Click += new EventHandler(Command1_Click);
			Panel2 = new System.Windows.Forms.Panel();
			malla = new System.Windows.Forms.CheckedListBox();
			Panel1.SuspendLayout();
			Panel2.SuspendLayout();
			SuspendLayout();
			// 
			// Panel1
			// 
			Panel1.BackColor = System.Drawing.Color.DarkGray;
			Panel1.Controls.Add(Command3);
			Panel1.Controls.Add(Command2);
			Panel1.Controls.Add(Command1);
			Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			Panel1.Location = new System.Drawing.Point(0, 285);
			Panel1.Name = "Panel1";
			Panel1.Size = new System.Drawing.Size(608, 34);
			Panel1.TabIndex = 7;
			// 
			// Command3
			// 
			Command3.BackColor = System.Drawing.Color.DimGray;
			Command3.Cursor = System.Windows.Forms.Cursors.Default;
			Command3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			Command3.ForeColor = System.Drawing.Color.White;
			Command3.Location = new System.Drawing.Point(325, 5);
			Command3.Name = "Command3";
			Command3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Command3.Size = new System.Drawing.Size(145, 24);
			Command3.TabIndex = 10;
			Command3.Text = "Cancelar";
			Command3.UseVisualStyleBackColor = false;
			// 
			// Command2
			// 
			Command2.BackColor = System.Drawing.Color.DimGray;
			Command2.Cursor = System.Windows.Forms.Cursors.Default;
			Command2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			Command2.ForeColor = System.Drawing.Color.White;
			Command2.Location = new System.Drawing.Point(173, 5);
			Command2.Name = "Command2";
			Command2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Command2.Size = new System.Drawing.Size(145, 24);
			Command2.TabIndex = 9;
			Command2.Text = "Aceptar opciones";
			Command2.UseVisualStyleBackColor = false;
			// 
			// Command1
			// 
			Command1.BackColor = System.Drawing.Color.DimGray;
			Command1.Cursor = System.Windows.Forms.Cursors.Default;
			Command1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			Command1.ForeColor = System.Drawing.Color.White;
			Command1.Location = new System.Drawing.Point(21, 5);
			Command1.Name = "Command1";
			Command1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			Command1.Size = new System.Drawing.Size(145, 24);
			Command1.TabIndex = 8;
			Command1.Text = "Prederminados";
			Command1.UseVisualStyleBackColor = false;
			// 
			// Panel2
			// 
			Panel2.Controls.Add(malla);
			Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			Panel2.Location = new System.Drawing.Point(0, 0);
			Panel2.Name = "Panel2";
			Panel2.Size = new System.Drawing.Size(608, 285);
			Panel2.TabIndex = 8;
			// 
			// malla
			// 
			malla.BackColor = System.Drawing.SystemColors.Window;
			malla.ColumnWidth = 198;
			malla.Cursor = System.Windows.Forms.Cursors.Default;
			malla.Dock = System.Windows.Forms.DockStyle.Fill;
			malla.ForeColor = System.Drawing.SystemColors.WindowText;
			malla.Location = new System.Drawing.Point(0, 0);
			malla.MultiColumn = true;
			malla.Name = "malla";
			malla.RightToLeft = System.Windows.Forms.RightToLeft.No;
			malla.Size = new System.Drawing.Size(608, 285);
			malla.Sorted = true;
			malla.TabIndex = 5;
			// 
			// EscojeCamposDir
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(6.0f, 13.0f);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(608, 319);
			ControlBox = false;
			Controls.Add(Panel2);
			Controls.Add(Panel1);
			Name = "EscojeCamposDir";
			ShowIcon = false;
			StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "ADCOMDAX - SELECCIONAR CAMPOS PARA VISUALIZAR EL DIRECTORIO";
			Panel1.ResumeLayout(false);
			Panel2.ResumeLayout(false);
			Load += new EventHandler(EscojeCamposDir_Load);
			ResumeLayout(false);

		}
		internal System.Windows.Forms.Panel Panel1;
		public System.Windows.Forms.Button Command3;
		public System.Windows.Forms.Button Command2;
		public System.Windows.Forms.Button Command1;
		internal System.Windows.Forms.Panel Panel2;
		public System.Windows.Forms.CheckedListBox malla;
	}
}