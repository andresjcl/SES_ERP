using System;
using System.Diagnostics;

namespace directMnt
{
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	internal partial class AdcDir : System.Windows.Forms.Form
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
			var resources = new System.ComponentModel.ComponentResourceManager(typeof(AdcDir));
			var DataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			var DataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			var DataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			var DataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			ToolStrip1 = new System.Windows.Forms.ToolStrip();
			btnNuevo = new System.Windows.Forms.ToolStripButton();
			btnNuevo.Click += new EventHandler(btnNuevo_Click);
			btnBusca = new System.Windows.Forms.ToolStripButton();
			btnBusca.Click += new EventHandler(btnBusca_Click);
			btnAbrir = new System.Windows.Forms.ToolStripButton();
			btnAbrir.Click += new EventHandler(btnAbrir_Click);
			btnTodos = new System.Windows.Forms.ToolStripSplitButton();
			btnTodos.ButtonClick += new EventHandler(btnTodos_ButtonClick);
			TodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			TodosToolStripMenuItem.Click += new EventHandler(TodosToolStripMenuItem_Click);
			RelaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			RelaciónToolStripMenuItem.Click += new EventHandler(RelaciónToolStripMenuItem_Click);
			EmpresasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			EmpresasToolStripMenuItem.Click += new EventHandler(EmpresasToolStripMenuItem_Click);
			btnRelacion = new System.Windows.Forms.ToolStripSplitButton();
			btnRelacion.ButtonClick += new EventHandler(btnRelacion_ButtonClick);
			TodasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			TodasToolStripMenuItem.Click += new EventHandler(TodasToolStripMenuItem_Click);
			ClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			ClientesToolStripMenuItem.Click += new EventHandler(ClientesToolStripMenuItem_Click);
			ProveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			ProveedoresToolStripMenuItem.Click += new EventHandler(ProveedoresToolStripMenuItem_Click);
			FinancieraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			FinancieraToolStripMenuItem.Click += new EventHandler(FinancieraToolStripMenuItem_Click);
			EmpleadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			EmpleadoToolStripMenuItem.Click += new EventHandler(EmpleadoToolStripMenuItem_Click);
			VendedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			VendedorToolStripMenuItem.Click += new EventHandler(VendedorToolStripMenuItem_Click);
			DirectaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			AsociaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			btnEnviar = new System.Windows.Forms.ToolStripSplitButton();
			btnEnviar.ButtonClick += new EventHandler(btnEnviar_ButtonClick);
			ImprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			ImprimirToolStripMenuItem.Click += new EventHandler(ImprimirToolStripMenuItem_Click);
			ExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			ExcelToolStripMenuItem.Click += new EventHandler(ExcelToolStripMenuItem_Click);
			WordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			WordToolStripMenuItem.Click += new EventHandler(WordToolStripMenuItem_Click);
			PDFToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			PDFToolStripMenuItem1.Click += new EventHandler(PDFToolStripMenuItem1_Click);
			btnSalir = new System.Windows.Forms.ToolStripButton();
			btnSalir.Click += new EventHandler(btnSalir_Click);
			MallaDat = new System.Windows.Forms.DataGridView();
			MallaDat.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(MallaDat_CellContextMenuStripNeeded);
			MallaDat.DoubleClick += new EventHandler(MallaDat_DoubleClick);
			MallaDat.DragDrop += new System.Windows.Forms.DragEventHandler(MallaDat_DragDrop);
			MallaDat.KeyDown += new System.Windows.Forms.KeyEventHandler(MallaDat_KeyDown);
			MallaDat.MouseClick += new System.Windows.Forms.MouseEventHandler(MallaDat_MouseClick);
			MallaDat.MouseDown += new System.Windows.Forms.MouseEventHandler(MallaDat_MouseDown);
			MallaDat.MouseUp += new System.Windows.Forms.MouseEventHandler(MallaDat_MouseUp);
			MallaDat.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(MallaDat_CellEnter);
			PropiedadesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			PropiedadesToolStripMenuItem1.Click += new EventHandler(PropiedadesToolStripMenuItem1_Click);
			ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			EscogerColumnasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			EscogerColumnasToolStripMenuItem1.Click += new EventHandler(EscogerColumnasToolStripMenuItem1_Click);
			BuscarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			BuscarToolStripMenuItem1.Click += new EventHandler(BuscarToolStripMenuItem1_Click);
			Submenu = new System.Windows.Forms.ContextMenuStrip();
			NuevoRegistroToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			NuevoRegistroToolStripMenuItem1.Click += new EventHandler(NuevoRegistroToolStripMenuItem1_Click);
			ToolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)MallaDat).BeginInit();
			Submenu.SuspendLayout();
			SuspendLayout();
			// 
			// ToolStrip1
			// 
			ToolStrip1.BackColor = System.Drawing.Color.SteelBlue;
			ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { btnNuevo, btnBusca, btnAbrir, btnTodos, btnRelacion, btnEnviar, btnSalir });
			ToolStrip1.Location = new System.Drawing.Point(0, 0);
			ToolStrip1.Name = "ToolStrip1";
			ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			ToolStrip1.Size = new System.Drawing.Size(777, 38);
			ToolStrip1.TabIndex = 3;
			ToolStrip1.Text = "ToolStrip1";
			// 
			// btnNuevo
			// 
			btnNuevo.ForeColor = System.Drawing.Color.White;
			btnNuevo.Image = (System.Drawing.Image)resources.GetObject("btnNuevo.Image");
			btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
			btnNuevo.Name = "btnNuevo";
			btnNuevo.Size = new System.Drawing.Size(46, 35);
			btnNuevo.Text = "Nuevo";
			btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// btnBusca
			// 
			btnBusca.ForeColor = System.Drawing.Color.White;
			btnBusca.Image = (System.Drawing.Image)resources.GetObject("btnBusca.Image");
			btnBusca.ImageTransparentColor = System.Drawing.Color.Magenta;
			btnBusca.Name = "btnBusca";
			btnBusca.Size = new System.Drawing.Size(42, 35);
			btnBusca.Text = "Busca";
			btnBusca.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// btnAbrir
			// 
			btnAbrir.ForeColor = System.Drawing.Color.White;
			btnAbrir.Image = (System.Drawing.Image)resources.GetObject("btnAbrir.Image");
			btnAbrir.ImageTransparentColor = System.Drawing.Color.Magenta;
			btnAbrir.Name = "btnAbrir";
			btnAbrir.Size = new System.Drawing.Size(33, 35);
			btnAbrir.Text = "Abir";
			btnAbrir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// btnTodos
			// 
			btnTodos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { TodosToolStripMenuItem, RelaciónToolStripMenuItem, EmpresasToolStripMenuItem });
			btnTodos.ForeColor = System.Drawing.Color.White;
			btnTodos.Image = (System.Drawing.Image)resources.GetObject("btnTodos.Image");
			btnTodos.ImageTransparentColor = System.Drawing.Color.Magenta;
			btnTodos.Name = "btnTodos";
			btnTodos.Size = new System.Drawing.Size(55, 35);
			btnTodos.Text = "Todos";
			btnTodos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// TodosToolStripMenuItem
			// 
			TodosToolStripMenuItem.Name = "TodosToolStripMenuItem";
			TodosToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			TodosToolStripMenuItem.Text = "Todos";
			// 
			// RelaciónToolStripMenuItem
			// 
			RelaciónToolStripMenuItem.Name = "RelaciónToolStripMenuItem";
			RelaciónToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			RelaciónToolStripMenuItem.Text = "Personas";
			// 
			// EmpresasToolStripMenuItem
			// 
			EmpresasToolStripMenuItem.Name = "EmpresasToolStripMenuItem";
			EmpresasToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			EmpresasToolStripMenuItem.Text = "Empresas";
			// 
			// btnRelacion
			// 
			btnRelacion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { TodasToolStripMenuItem, ClientesToolStripMenuItem, ProveedoresToolStripMenuItem, FinancieraToolStripMenuItem, EmpleadoToolStripMenuItem, VendedorToolStripMenuItem, DirectaToolStripMenuItem, AsociaciónToolStripMenuItem });
			btnRelacion.ForeColor = System.Drawing.Color.White;
			btnRelacion.Image = (System.Drawing.Image)resources.GetObject("btnRelacion.Image");
			btnRelacion.ImageTransparentColor = System.Drawing.Color.Magenta;
			btnRelacion.Name = "btnRelacion";
			btnRelacion.Size = new System.Drawing.Size(68, 35);
			btnRelacion.Text = "Relación";
			btnRelacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// TodasToolStripMenuItem
			// 
			TodasToolStripMenuItem.Name = "TodasToolStripMenuItem";
			TodasToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			TodasToolStripMenuItem.Text = "Todas";
			// 
			// ClientesToolStripMenuItem
			// 
			ClientesToolStripMenuItem.Name = "ClientesToolStripMenuItem";
			ClientesToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			ClientesToolStripMenuItem.Text = "Clientes";
			// 
			// ProveedoresToolStripMenuItem
			// 
			ProveedoresToolStripMenuItem.Name = "ProveedoresToolStripMenuItem";
			ProveedoresToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			ProveedoresToolStripMenuItem.Text = "Proveedores";
			// 
			// FinancieraToolStripMenuItem
			// 
			FinancieraToolStripMenuItem.Name = "FinancieraToolStripMenuItem";
			FinancieraToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			FinancieraToolStripMenuItem.Text = "Financiera";
			// 
			// EmpleadoToolStripMenuItem
			// 
			EmpleadoToolStripMenuItem.Name = "EmpleadoToolStripMenuItem";
			EmpleadoToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			EmpleadoToolStripMenuItem.Text = "Empleado";
			// 
			// VendedorToolStripMenuItem
			// 
			VendedorToolStripMenuItem.Name = "VendedorToolStripMenuItem";
			VendedorToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			VendedorToolStripMenuItem.Text = "Vendedor";
			// 
			// DirectaToolStripMenuItem
			// 
			DirectaToolStripMenuItem.Name = "DirectaToolStripMenuItem";
			DirectaToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			DirectaToolStripMenuItem.Text = "Directa";
			// 
			// AsociaciónToolStripMenuItem
			// 
			AsociaciónToolStripMenuItem.Name = "AsociaciónToolStripMenuItem";
			AsociaciónToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			AsociaciónToolStripMenuItem.Text = "Asociación";
			// 
			// btnEnviar
			// 
			btnEnviar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { ImprimirToolStripMenuItem, ExcelToolStripMenuItem, WordToolStripMenuItem, PDFToolStripMenuItem1 });
			btnEnviar.ForeColor = System.Drawing.Color.White;
			btnEnviar.Image = (System.Drawing.Image)resources.GetObject("btnEnviar.Image");
			btnEnviar.ImageTransparentColor = System.Drawing.Color.Magenta;
			btnEnviar.Name = "btnEnviar";
			btnEnviar.Size = new System.Drawing.Size(55, 35);
			btnEnviar.Text = "Enviar";
			btnEnviar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// ImprimirToolStripMenuItem
			// 
			ImprimirToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("ImprimirToolStripMenuItem.Image");
			ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem";
			ImprimirToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
			ImprimirToolStripMenuItem.Text = "Imprimir";
			// 
			// ExcelToolStripMenuItem
			// 
			ExcelToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("ExcelToolStripMenuItem.Image");
			ExcelToolStripMenuItem.Name = "ExcelToolStripMenuItem";
			ExcelToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
			ExcelToolStripMenuItem.Text = "Excel";
			// 
			// WordToolStripMenuItem
			// 
			WordToolStripMenuItem.Image = (System.Drawing.Image)resources.GetObject("WordToolStripMenuItem.Image");
			WordToolStripMenuItem.Name = "WordToolStripMenuItem";
			WordToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
			WordToolStripMenuItem.Text = "Word";
			// 
			// PDFToolStripMenuItem1
			// 
			PDFToolStripMenuItem1.Image = (System.Drawing.Image)resources.GetObject("PDFToolStripMenuItem1.Image");
			PDFToolStripMenuItem1.Name = "PDFToolStripMenuItem1";
			PDFToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
			PDFToolStripMenuItem1.Text = "PDF";
			// 
			// btnSalir
			// 
			btnSalir.ForeColor = System.Drawing.Color.White;
			btnSalir.Image = (System.Drawing.Image)resources.GetObject("btnSalir.Image");
			btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
			btnSalir.Name = "btnSalir";
			btnSalir.Size = new System.Drawing.Size(33, 35);
			btnSalir.Text = "Salir";
			btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// MallaDat
			// 
			MallaDat.AllowUserToAddRows = false;
			MallaDat.AllowUserToDeleteRows = false;
			MallaDat.AllowUserToOrderColumns = true;
			MallaDat.AllowUserToResizeRows = false;
			MallaDat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			MallaDat.BackgroundColor = System.Drawing.Color.White;
			DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
			DataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
			DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			MallaDat.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1;
			MallaDat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			DataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
			DataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
			DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
			DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
			DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			MallaDat.DefaultCellStyle = DataGridViewCellStyle2;
			MallaDat.Dock = System.Windows.Forms.DockStyle.Fill;
			MallaDat.GridColor = System.Drawing.Color.FromArgb(224, 224, 224);
			MallaDat.Location = new System.Drawing.Point(0, 38);
			MallaDat.Name = "MallaDat";
			MallaDat.ReadOnly = true;
			MallaDat.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue;
			DataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
			DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			MallaDat.RowHeadersDefaultCellStyle = DataGridViewCellStyle3;
			DataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
			DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
			DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.RoyalBlue;
			DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
			MallaDat.RowsDefaultCellStyle = DataGridViewCellStyle4;
			MallaDat.Size = new System.Drawing.Size(777, 403);
			MallaDat.TabIndex = 4;
			// 
			// PropiedadesToolStripMenuItem1
			// 
			PropiedadesToolStripMenuItem1.Name = "PropiedadesToolStripMenuItem1";
			PropiedadesToolStripMenuItem1.Size = new System.Drawing.Size(172, 22);
			PropiedadesToolStripMenuItem1.Text = "&Propiedades";
			// 
			// ToolStripSeparator2
			// 
			ToolStripSeparator2.Name = "ToolStripSeparator2";
			ToolStripSeparator2.Size = new System.Drawing.Size(169, 6);
			// 
			// EscogerColumnasToolStripMenuItem1
			// 
			EscogerColumnasToolStripMenuItem1.Name = "EscogerColumnasToolStripMenuItem1";
			EscogerColumnasToolStripMenuItem1.Size = new System.Drawing.Size(172, 22);
			EscogerColumnasToolStripMenuItem1.Text = "&Escoger Columnas";
			// 
			// BuscarToolStripMenuItem1
			// 
			BuscarToolStripMenuItem1.Name = "BuscarToolStripMenuItem1";
			BuscarToolStripMenuItem1.Size = new System.Drawing.Size(172, 22);
			BuscarToolStripMenuItem1.Text = "&Buscar";
			// 
			// Submenu
			// 
			Submenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { BuscarToolStripMenuItem1, EscogerColumnasToolStripMenuItem1, ToolStripSeparator2, PropiedadesToolStripMenuItem1, NuevoRegistroToolStripMenuItem1 });
			Submenu.Name = "ContextMenuStrip1";
			Submenu.Size = new System.Drawing.Size(173, 98);
			// 
			// NuevoRegistroToolStripMenuItem1
			// 
			NuevoRegistroToolStripMenuItem1.Name = "NuevoRegistroToolStripMenuItem1";
			NuevoRegistroToolStripMenuItem1.Size = new System.Drawing.Size(172, 22);
			NuevoRegistroToolStripMenuItem1.Text = "&Nuevo Registro";
			// 
			// AdcDir
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(6.0f, 13.0f);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(777, 441);
			Controls.Add(MallaDat);
			Controls.Add(ToolStrip1);
			Name = "AdcDir";
			ShowIcon = false;
			StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "ADCOMDAX - LISTA DEL DIRECTORIO GENERAL";
			ToolStrip1.ResumeLayout(false);
			ToolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)MallaDat).EndInit();
			Submenu.ResumeLayout(false);
			FormClosing += new System.Windows.Forms.FormClosingEventHandler(AdcDir_FormClosing);
			Load += new EventHandler(AdcDir_Load);
			ResumeLayout(false);
			PerformLayout();

		}
		internal System.Windows.Forms.ToolStrip ToolStrip1;
		internal System.Windows.Forms.ToolStripButton btnNuevo;
		internal System.Windows.Forms.ToolStripButton btnBusca;
		internal System.Windows.Forms.ToolStripButton btnAbrir;
		internal System.Windows.Forms.ToolStripSplitButton btnTodos;
		internal System.Windows.Forms.ToolStripMenuItem TodosToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem RelaciónToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem EmpresasToolStripMenuItem;
		internal System.Windows.Forms.ToolStripSplitButton btnRelacion;
		internal System.Windows.Forms.ToolStripMenuItem TodasToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem ClientesToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem ProveedoresToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem FinancieraToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem EmpleadoToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem VendedorToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem DirectaToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem AsociaciónToolStripMenuItem;
		internal System.Windows.Forms.ToolStripSplitButton btnEnviar;
		internal System.Windows.Forms.ToolStripMenuItem ImprimirToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem ExcelToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem WordToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem PDFToolStripMenuItem1;
		internal System.Windows.Forms.ToolStripButton btnSalir;
		internal System.Windows.Forms.DataGridView MallaDat;
		internal System.Windows.Forms.ToolStripMenuItem PropiedadesToolStripMenuItem1;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
		internal System.Windows.Forms.ToolStripMenuItem EscogerColumnasToolStripMenuItem1;
		internal System.Windows.Forms.ToolStripMenuItem BuscarToolStripMenuItem1;
		internal System.Windows.Forms.ContextMenuStrip Submenu;
		internal System.Windows.Forms.ToolStripMenuItem NuevoRegistroToolStripMenuItem1;
	}
}