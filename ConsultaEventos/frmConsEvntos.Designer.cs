namespace registraEvntos
{
    partial class frmConsEvntos
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsEvntos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStrip7 = new System.Windows.Forms.ToolStrip();
            this.btnBuscar = new System.Windows.Forms.ToolStripButton();
            this.btnSiguiente = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStrip12 = new System.Windows.Forms.ToolStrip();
            this.ToolStripContainer4 = new System.Windows.Forms.ToolStripContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.dtHasta = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtDesde = new System.Windows.Forms.DateTimePicker();
            this.ToolStrip4 = new System.Windows.Forms.ToolStrip();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmbOpcion = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEnviar = new System.Windows.Forms.ToolStripSplitButton();
            this.ImprimirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.malla = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labRegistros = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ToolStrip7.SuspendLayout();
            this.ToolStrip12.SuspendLayout();
            this.ToolStripContainer4.ContentPanel.SuspendLayout();
            this.ToolStripContainer4.SuspendLayout();
            this.ToolStrip4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.malla)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 74);
            // 
            // ToolStrip7
            // 
            this.ToolStrip7.AutoSize = false;
            this.ToolStrip7.BackColor = System.Drawing.Color.Transparent;
            this.ToolStrip7.Dock = System.Windows.Forms.DockStyle.Left;
            this.ToolStrip7.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip7.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ToolStrip7.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripSeparator2,
            this.btnBuscar,
            this.btnSiguiente});
            this.ToolStrip7.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ToolStrip7.Location = new System.Drawing.Point(363, 0);
            this.ToolStrip7.Name = "ToolStrip7";
            this.ToolStrip7.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStrip7.Size = new System.Drawing.Size(136, 74);
            this.ToolStrip7.Stretch = true;
            this.ToolStrip7.TabIndex = 4;
            this.ToolStrip7.Text = "ToolStrip7";
            // 
            // btnBuscar
            // 
            this.btnBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(36, 71);
            this.btnBuscar.ToolTipText = "Buscar valores de la malla";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("btnSiguiente.Image")));
            this.btnSiguiente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(36, 71);
            this.btnSiguiente.ToolTipText = "Buscar el siguiente";
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(42, 71);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // ToolStripSeparator7
            // 
            this.ToolStripSeparator7.Name = "ToolStripSeparator7";
            this.ToolStripSeparator7.Size = new System.Drawing.Size(6, 74);
            // 
            // ToolStrip12
            // 
            this.ToolStrip12.AutoSize = false;
            this.ToolStrip12.BackColor = System.Drawing.Color.Transparent;
            this.ToolStrip12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStrip12.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip12.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ToolStrip12.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripSeparator7,
            this.btnSalir});
            this.ToolStrip12.Location = new System.Drawing.Point(499, 0);
            this.ToolStrip12.Name = "ToolStrip12";
            this.ToolStrip12.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStrip12.Size = new System.Drawing.Size(704, 74);
            this.ToolStrip12.Stretch = true;
            this.ToolStrip12.TabIndex = 9;
            this.ToolStrip12.Text = "ToolStrip12";
            // 
            // ToolStripContainer4
            // 
            this.ToolStripContainer4.BottomToolStripPanelVisible = false;
            // 
            // ToolStripContainer4.ContentPanel
            // 
            this.ToolStripContainer4.ContentPanel.AccessibleDescription = "AEA";
            this.ToolStripContainer4.ContentPanel.BackColor = System.Drawing.Color.DimGray;
            this.ToolStripContainer4.ContentPanel.Controls.Add(this.label2);
            this.ToolStripContainer4.ContentPanel.Controls.Add(this.dtHasta);
            this.ToolStripContainer4.ContentPanel.Controls.Add(this.label1);
            this.ToolStripContainer4.ContentPanel.Controls.Add(this.dtDesde);
            this.ToolStripContainer4.ContentPanel.Controls.Add(this.ToolStrip12);
            this.ToolStripContainer4.ContentPanel.Controls.Add(this.ToolStrip7);
            this.ToolStripContainer4.ContentPanel.Controls.Add(this.ToolStrip4);
            this.ToolStripContainer4.ContentPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ToolStripContainer4.ContentPanel.Size = new System.Drawing.Size(1203, 74);
            this.ToolStripContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStripContainer4.LeftToolStripPanelVisible = false;
            this.ToolStripContainer4.Location = new System.Drawing.Point(0, 0);
            this.ToolStripContainer4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ToolStripContainer4.Name = "ToolStripContainer4";
            this.ToolStripContainer4.RightToolStripPanelVisible = false;
            this.ToolStripContainer4.Size = new System.Drawing.Size(1203, 74);
            this.ToolStripContainer4.TabIndex = 3;
            this.ToolStripContainer4.Text = "ToolStripContainer4";
            // 
            // ToolStripContainer4.TopToolStripPanel
            // 
            this.ToolStripContainer4.TopToolStripPanel.Padding = new System.Windows.Forms.Padding(0, 0, 25, 25);
            this.ToolStripContainer4.TopToolStripPanelVisible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(891, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Hasta :";
            // 
            // dtHasta
            // 
            this.dtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHasta.Location = new System.Drawing.Point(949, 26);
            this.dtHasta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtHasta.Name = "dtHasta";
            this.dtHasta.Size = new System.Drawing.Size(104, 22);
            this.dtHasta.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(708, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Desde :";
            // 
            // dtDesde
            // 
            this.dtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDesde.Location = new System.Drawing.Point(775, 26);
            this.dtDesde.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtDesde.Name = "dtDesde";
            this.dtDesde.Size = new System.Drawing.Size(104, 22);
            this.dtDesde.TabIndex = 10;
            // 
            // ToolStrip4
            // 
            this.ToolStrip4.AutoSize = false;
            this.ToolStrip4.BackColor = System.Drawing.Color.Transparent;
            this.ToolStrip4.Dock = System.Windows.Forms.DockStyle.Left;
            this.ToolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip4.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ToolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnActualizar,
            this.toolStripSeparator3,
            this.cmbOpcion,
            this.toolStripSeparator4,
            this.btnEnviar});
            this.ToolStrip4.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ToolStrip4.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip4.Name = "ToolStrip4";
            this.ToolStrip4.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStrip4.Size = new System.Drawing.Size(363, 74);
            this.ToolStrip4.Stretch = true;
            this.ToolStrip4.TabIndex = 0;
            this.ToolStrip4.Text = "ToolStrip4";
            // 
            // btnActualizar
            // 
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.RightToLeftAutoMirrorImage = true;
            this.btnActualizar.Size = new System.Drawing.Size(79, 71);
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnActualizar.ToolTipText = "Actualizar la carga de datos ";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 74);
            // 
            // cmbOpcion
            // 
            this.cmbOpcion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOpcion.Items.AddRange(new object[] {
            "Documentos",
            "Usuarios",
            "Novedades"});
            this.cmbOpcion.Name = "cmbOpcion";
            this.cmbOpcion.Size = new System.Drawing.Size(159, 74);
            this.cmbOpcion.Text = "Usuarios";
            this.cmbOpcion.ToolTipText = "Usuario del sistema";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 74);
            // 
            // btnEnviar
            // 
            this.btnEnviar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImprimirToolStripMenuItem,
            this.WordToolStripMenuItem,
            this.ExcelToolStripMenuItem,
            this.PDFToolStripMenuItem});
            this.btnEnviar.ForeColor = System.Drawing.Color.White;
            this.btnEnviar.Image = ((System.Drawing.Image)(resources.GetObject("btnEnviar.Image")));
            this.btnEnviar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(68, 71);
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // ImprimirToolStripMenuItem
            // 
            this.ImprimirToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ImprimirToolStripMenuItem.Image")));
            this.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem";
            this.ImprimirToolStripMenuItem.Size = new System.Drawing.Size(236, 38);
            this.ImprimirToolStripMenuItem.Text = "Imprimir";
            this.ImprimirToolStripMenuItem.Click += new System.EventHandler(this.ImprimirToolStripMenuItem_Click);
            // 
            // WordToolStripMenuItem
            // 
            this.WordToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("WordToolStripMenuItem.Image")));
            this.WordToolStripMenuItem.Name = "WordToolStripMenuItem";
            this.WordToolStripMenuItem.Size = new System.Drawing.Size(236, 38);
            this.WordToolStripMenuItem.Text = "Word";
            this.WordToolStripMenuItem.Click += new System.EventHandler(this.WordToolStripMenuItem_Click);
            // 
            // ExcelToolStripMenuItem
            // 
            this.ExcelToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ExcelToolStripMenuItem.Image")));
            this.ExcelToolStripMenuItem.Name = "ExcelToolStripMenuItem";
            this.ExcelToolStripMenuItem.Size = new System.Drawing.Size(236, 38);
            this.ExcelToolStripMenuItem.Text = "Excel";
            this.ExcelToolStripMenuItem.Click += new System.EventHandler(this.ExcelToolStripMenuItem_Click);
            // 
            // PDFToolStripMenuItem
            // 
            this.PDFToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("PDFToolStripMenuItem.Image")));
            this.PDFToolStripMenuItem.Name = "PDFToolStripMenuItem";
            this.PDFToolStripMenuItem.Size = new System.Drawing.Size(236, 38);
            this.PDFToolStripMenuItem.Text = "PDF";
            this.PDFToolStripMenuItem.Click += new System.EventHandler(this.PDFToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ToolStripContainer4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1203, 74);
            this.panel2.TabIndex = 13;
            // 
            // malla
            // 
            this.malla.AllowDrop = true;
            this.malla.AllowUserToAddRows = false;
            this.malla.AllowUserToDeleteRows = false;
            this.malla.AllowUserToOrderColumns = true;
            this.malla.AllowUserToResizeRows = false;
            this.malla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.malla.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.malla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.malla.ColumnHeadersHeight = 20;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.malla.DefaultCellStyle = dataGridViewCellStyle2;
            this.malla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.malla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.malla.EnableHeadersVisualStyles = false;
            this.malla.GridColor = System.Drawing.Color.Gray;
            this.malla.Location = new System.Drawing.Point(0, 74);
            this.malla.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.malla.Name = "malla";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.malla.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.malla.RowHeadersWidth = 20;
            this.malla.Size = new System.Drawing.Size(1203, 521);
            this.malla.StandardTab = true;
            this.malla.TabIndex = 14;
            this.malla.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.malla_DataError);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.labRegistros);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 595);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1203, 38);
            this.panel1.TabIndex = 15;
            // 
            // labRegistros
            // 
            this.labRegistros.AutoSize = true;
            this.labRegistros.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labRegistros.Location = new System.Drawing.Point(33, 9);
            this.labRegistros.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labRegistros.Name = "labRegistros";
            this.labRegistros.Size = new System.Drawing.Size(0, 19);
            this.labRegistros.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmConsEvntos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 633);
            this.ControlBox = false;
            this.Controls.Add(this.malla);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmConsEvntos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REGISTRO DE EVENTOS";
            this.ToolStrip7.ResumeLayout(false);
            this.ToolStrip7.PerformLayout();
            this.ToolStrip12.ResumeLayout(false);
            this.ToolStrip12.PerformLayout();
            this.ToolStripContainer4.ContentPanel.ResumeLayout(false);
            this.ToolStripContainer4.ContentPanel.PerformLayout();
            this.ToolStripContainer4.ResumeLayout(false);
            this.ToolStripContainer4.PerformLayout();
            this.ToolStrip4.ResumeLayout(false);
            this.ToolStrip4.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.malla)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        internal System.Windows.Forms.ToolStrip ToolStrip7;
        internal System.Windows.Forms.ToolStripButton btnSalir;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator7;
        internal System.Windows.Forms.ToolStrip ToolStrip12;
        internal System.Windows.Forms.ToolStripContainer ToolStripContainer4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView malla;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labRegistros;
        private System.Windows.Forms.ToolStripButton btnBuscar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripButton btnSiguiente;
        internal System.Windows.Forms.ToolStrip ToolStrip4;
        internal System.Windows.Forms.ToolStripButton btnActualizar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripComboBox cmbOpcion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        internal System.Windows.Forms.ToolStripSplitButton btnEnviar;
        internal System.Windows.Forms.ToolStripMenuItem ImprimirToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem WordToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ExcelToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem PDFToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtHasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtDesde;
    }
}
