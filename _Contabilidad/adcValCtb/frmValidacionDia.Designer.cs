namespace adcValCtb
{
    partial class frmValidacionDia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmValidacionDia));
            this.mallaDatos = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.btnEnviar = new System.Windows.Forms.ToolStripSplitButton();
            this.btnexcel = new System.Windows.Forms.ToolStripMenuItem();
            this.btnpdf = new System.Windows.Forms.ToolStripMenuItem();
            this.btnword = new System.Windows.Forms.ToolStripMenuItem();
            this.btnImprimir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSumatoria = new System.Windows.Forms.ToolStripButton();
            this.btnBuscar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cmbDocumentos = new System.Windows.Forms.ComboBox();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSucursal = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.mallaDatos)).BeginInit();
            this.menu.SuspendLayout();
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
            this.mallaDatos.Location = new System.Drawing.Point(0, 53);
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
            this.mallaDatos.Size = new System.Drawing.Size(901, 343);
            this.mallaDatos.TabIndex = 4;
            this.mallaDatos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.mallaDatos_DataError);
            this.mallaDatos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mallaDatos_KeyDown);
            // 
            // btnActualizar
            // 
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(46, 50);
            this.btnActualizar.Text = "Validar";
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
            this.btnEnviar.Size = new System.Drawing.Size(55, 50);
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
            // toolStripButton1
            // 
            this.toolStripButton1.ForeColor = System.Drawing.Color.White;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(57, 50);
            this.toolStripButton1.Text = "Salir";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // menu
            // 
            this.menu.AutoSize = false;
            this.menu.BackColor = System.Drawing.Color.SteelBlue;
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.btnEnviar,
            this.btnActualizar,
            this.toolStripSeparator5,
            this.btnSumatoria,
            this.btnBuscar,
            this.toolStripSeparator4,
            this.toolStripButton1});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(901, 53);
            this.menu.TabIndex = 3;
            this.menu.Text = "    ";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 53);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 53);
            // 
            // btnSumatoria
            // 
            this.btnSumatoria.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSumatoria.ForeColor = System.Drawing.Color.White;
            this.btnSumatoria.Image = ((System.Drawing.Image)(resources.GetObject("btnSumatoria.Image")));
            this.btnSumatoria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSumatoria.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSumatoria.Name = "btnSumatoria";
            this.btnSumatoria.Size = new System.Drawing.Size(28, 50);
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
            this.btnBuscar.Size = new System.Drawing.Size(28, 50);
            this.btnBuscar.ToolTipText = "Buscar y/o reeemplazar valores de la malla";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 53);
            // 
            // cmbDocumentos
            // 
            this.cmbDocumentos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDocumentos.FormattingEnabled = true;
            this.cmbDocumentos.Location = new System.Drawing.Point(502, 26);
            this.cmbDocumentos.Name = "cmbDocumentos";
            this.cmbDocumentos.Size = new System.Drawing.Size(238, 21);
            this.cmbDocumentos.TabIndex = 7;
            // 
            // dtDesde
            // 
            this.dtDesde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(799, 3);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(98, 20);
            this.dtDesde.TabIndex = 8;
            this.dtDesde.Value = new System.DateTime(2016, 5, 16, 0, 0, 0, 0);
            // 
            // dtHasta
            // 
            this.dtHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(799, 26);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(98, 20);
            this.dtHasta.TabIndex = 9;
            this.dtHasta.Value = new System.DateTime(2016, 5, 16, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(751, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Período:";
            // 
            // cmbSucursal
            // 
            this.cmbSucursal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSucursal.FormattingEnabled = true;
            this.cmbSucursal.Location = new System.Drawing.Point(502, 3);
            this.cmbSucursal.Name = "cmbSucursal";
            this.cmbSucursal.Size = new System.Drawing.Size(238, 21);
            this.cmbSucursal.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 396);
            this.ControlBox = false;
            this.Controls.Add(this.cmbSucursal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtHasta);
            this.Controls.Add(this.dtDesde);
            this.Controls.Add(this.cmbDocumentos);
            this.Controls.Add(this.mallaDatos);
            this.Controls.Add(this.menu);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADCOMDAX - VALIDACION DE DIARIOS CONTABLES";
            ((System.ComponentModel.ISupportInitialize)(this.mallaDatos)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView mallaDatos;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private System.Windows.Forms.ToolStripSplitButton btnEnviar;
        private System.Windows.Forms.ToolStripMenuItem btnexcel;
        private System.Windows.Forms.ToolStripMenuItem btnpdf;
        private System.Windows.Forms.ToolStripMenuItem btnword;
        private System.Windows.Forms.ToolStripMenuItem btnImprimir;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnSumatoria;
        private System.Windows.Forms.ToolStripButton btnBuscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ComboBox cmbDocumentos;
        private System.Windows.Forms.DateTimePicker dtDesde;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ComboBox cmbSucursal;

    }
}