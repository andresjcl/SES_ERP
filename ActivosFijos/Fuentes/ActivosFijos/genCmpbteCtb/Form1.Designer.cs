namespace genCmpbteCtbAcf
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mallaDatos = new System.Windows.Forms.DataGridView();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.btnAbrir = new System.Windows.Forms.ToolStripButton();
            this.btnCerrar = new System.Windows.Forms.ToolStripButton();
            this.txtPeriodo = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.btnEnviar = new System.Windows.Forms.ToolStripSplitButton();
            this.btnexcel = new System.Windows.Forms.ToolStripMenuItem();
            this.btnpdf = new System.Windows.Forms.ToolStripMenuItem();
            this.btnword = new System.Windows.Forms.ToolStripMenuItem();
            this.btnImprimir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCrearDiario = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmbDetallado = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSumatoria = new System.Windows.Forms.ToolStripButton();
            this.btnBuscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mallaDatos)).BeginInit();
            this.menu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mallaDatos
            // 
            this.mallaDatos.AllowUserToAddRows = false;
            this.mallaDatos.AllowUserToOrderColumns = true;
            this.mallaDatos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.mallaDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.mallaDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.mallaDatos.BackgroundColor = System.Drawing.Color.White;
            this.mallaDatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mallaDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.mallaDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mallaDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mallaDatos.EnableHeadersVisualStyles = false;
            this.mallaDatos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mallaDatos.Location = new System.Drawing.Point(0, 45);
            this.mallaDatos.Name = "mallaDatos";
            this.mallaDatos.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mallaDatos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.mallaDatos.Size = new System.Drawing.Size(794, 321);
            this.mallaDatos.TabIndex = 8;
            this.mallaDatos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mallaDatos_KeyDown);
            // 
            // menu
            // 
            this.menu.AutoSize = false;
            this.menu.BackColor = System.Drawing.Color.SteelBlue;
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAbrir,
            this.btnCerrar,
            this.txtPeriodo,
            this.toolStripSeparator2,
            this.btnActualizar,
            this.btnEnviar,
            this.toolStripSeparator1,
            this.btnCrearDiario,
            this.toolStripSeparator3,
            this.cmbDetallado,
            this.toolStripSeparator5,
            this.btnSumatoria,
            this.btnBuscar,
            this.toolStripSeparator4,
            this.toolStripButton1});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(794, 45);
            this.menu.TabIndex = 7;
            this.menu.Text = "    ";
            // 
            // btnAbrir
            // 
            this.btnAbrir.ForeColor = System.Drawing.Color.White;
            this.btnAbrir.Image = ((System.Drawing.Image)(resources.GetObject("btnAbrir.Image")));
            this.btnAbrir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(37, 42);
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAbrir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAbrir.ToolTipText = "Abrir periodo de liquidación de rol";
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(43, 42);
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCerrar.ToolTipText = "Abrir periodo de liquidación de rol";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.txtPeriodo.ForeColor = System.Drawing.Color.White;
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Size = new System.Drawing.Size(0, 42);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 45);
            // 
            // btnActualizar
            // 
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(63, 42);
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnexcel,
            this.btnpdf,
            this.btnword,
            this.btnImprimir});
            this.btnEnviar.ForeColor = System.Drawing.Color.White;
            this.btnEnviar.Image = ((System.Drawing.Image)(resources.GetObject("btnEnviar.Image")));
            this.btnEnviar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(55, 42);
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnexcel
            // 
            this.btnexcel.Image = ((System.Drawing.Image)(resources.GetObject("btnexcel.Image")));
            this.btnexcel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnexcel.Name = "btnexcel";
            this.btnexcel.Size = new System.Drawing.Size(158, 22);
            this.btnexcel.Text = "Exportar a Excel";
            this.btnexcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnexcel.Click += new System.EventHandler(this.btnexcel_Click);
            // 
            // btnpdf
            // 
            this.btnpdf.Image = ((System.Drawing.Image)(resources.GetObject("btnpdf.Image")));
            this.btnpdf.Name = "btnpdf";
            this.btnpdf.Size = new System.Drawing.Size(158, 22);
            this.btnpdf.Text = "Exportar a Pdf";
            this.btnpdf.Click += new System.EventHandler(this.btnpdf_Click);
            // 
            // btnword
            // 
            this.btnword.Image = ((System.Drawing.Image)(resources.GetObject("btnword.Image")));
            this.btnword.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnword.Name = "btnword";
            this.btnword.Size = new System.Drawing.Size(158, 22);
            this.btnword.Text = "Exportar a Word";
            this.btnword.Click += new System.EventHandler(this.btnword_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(158, 22);
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 45);
            // 
            // btnCrearDiario
            // 
            this.btnCrearDiario.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCrearDiario.Image = ((System.Drawing.Image)(resources.GetObject("btnCrearDiario.Image")));
            this.btnCrearDiario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCrearDiario.Name = "btnCrearDiario";
            this.btnCrearDiario.Size = new System.Drawing.Size(117, 42);
            this.btnCrearDiario.Text = "Diario Contable";
            this.btnCrearDiario.ToolTipText = "Crear diario en módulo contable del AdcomDax";
            this.btnCrearDiario.Click += new System.EventHandler(this.btnCrearDiario_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 45);
            // 
            // cmbDetallado
            // 
            this.cmbDetallado.Items.AddRange(new object[] {
            "Resumen para diario",
            "Detalle por empleado"});
            this.cmbDetallado.Name = "cmbDetallado";
            this.cmbDetallado.Size = new System.Drawing.Size(151, 45);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 45);
            // 
            // btnSumatoria
            // 
            this.btnSumatoria.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSumatoria.ForeColor = System.Drawing.Color.White;
            this.btnSumatoria.Image = ((System.Drawing.Image)(resources.GetObject("btnSumatoria.Image")));
            this.btnSumatoria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSumatoria.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSumatoria.Name = "btnSumatoria";
            this.btnSumatoria.Size = new System.Drawing.Size(28, 42);
            this.btnSumatoria.Text = "Suma";
            this.btnSumatoria.ToolTipText = "Obtiene el total de la suma de las celdas seleccionadas o de la columna total";
            this.btnSumatoria.Click += new System.EventHandler(this.btnSumatoria_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(28, 42);
            this.btnBuscar.ToolTipText = "Buscar y/o reeemplazar valores de la malla";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 45);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.ForeColor = System.Drawing.Color.White;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(57, 42);
            this.toolStripButton1.Text = "Salir";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 366);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 32);
            this.panel1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(398, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Total Débitos : 0.00    Créditos:  0.0  Conceptos sin Cuenta Contable : 0.0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 398);
            this.Controls.Add(this.mallaDatos);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.mallaDatos)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView mallaDatos;
        private System.Windows.Forms.ToolStrip menu;
        internal System.Windows.Forms.ToolStripButton btnAbrir;
        internal System.Windows.Forms.ToolStripButton btnCerrar;
        private System.Windows.Forms.ToolStripLabel txtPeriodo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private System.Windows.Forms.ToolStripSplitButton btnEnviar;
        private System.Windows.Forms.ToolStripMenuItem btnexcel;
        private System.Windows.Forms.ToolStripMenuItem btnpdf;
        private System.Windows.Forms.ToolStripMenuItem btnword;
        private System.Windows.Forms.ToolStripMenuItem btnImprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnCrearDiario;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripComboBox cmbDetallado;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnSumatoria;
        private System.Windows.Forms.ToolStripButton btnBuscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;

    }
}