namespace Syscod
{
    partial class frmBuscarTipoRef
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarTipoRef));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.TextNombre = new System.Windows.Forms.TextBox();
            this.TextCodigo = new System.Windows.Forms.TextBox();
            this.EnInicio = new System.Windows.Forms.CheckBox();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.BtnAceptar = new System.Windows.Forms.ToolStripButton();
            this.ToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.gridTipo = new System.Windows.Forms.DataGridView();
            this.Panel1.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTipo)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Panel1.Controls.Add(this.TextNombre);
            this.Panel1.Controls.Add(this.TextCodigo);
            this.Panel1.Controls.Add(this.EnInicio);
            this.Panel1.Controls.Add(this.ToolStrip1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(605, 110);
            this.Panel1.TabIndex = 2;
            // 
            // TextNombre
            // 
            this.TextNombre.Location = new System.Drawing.Point(48, 78);
            this.TextNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TextNombre.Name = "TextNombre";
            this.TextNombre.Size = new System.Drawing.Size(393, 22);
            this.TextNombre.TabIndex = 3;
            this.TextNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextNombre_KeyDown);
            // 
            // TextCodigo
            // 
            this.TextCodigo.Location = new System.Drawing.Point(1, 78);
            this.TextCodigo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TextCodigo.Name = "TextCodigo";
            this.TextCodigo.Size = new System.Drawing.Size(41, 22);
            this.TextCodigo.TabIndex = 2;
            this.TextCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextCodigo_KeyDown);
            // 
            // EnInicio
            // 
            this.EnInicio.AutoSize = true;
            this.EnInicio.BackColor = System.Drawing.Color.SteelBlue;
            this.EnInicio.Checked = true;
            this.EnInicio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EnInicio.ForeColor = System.Drawing.Color.White;
            this.EnInicio.Location = new System.Drawing.Point(328, 15);
            this.EnInicio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EnInicio.Name = "EnInicio";
            this.EnInicio.Size = new System.Drawing.Size(110, 21);
            this.EnInicio.TabIndex = 1;
            this.EnInicio.Text = "Buscar inicio";
            this.EnInicio.UseVisualStyleBackColor = false;
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButton2,
            this.BtnAceptar,
            this.ToolStripButton1});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ToolStrip1.Size = new System.Drawing.Size(605, 51);
            this.ToolStrip1.Stretch = true;
            this.ToolStrip1.TabIndex = 0;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // ToolStripButton2
            // 
            this.ToolStripButton2.ForeColor = System.Drawing.Color.White;
            this.ToolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton2.Image")));
            this.ToolStripButton2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton2.Name = "ToolStripButton2";
            this.ToolStripButton2.Size = new System.Drawing.Size(56, 48);
            this.ToolStripButton2.Text = "Nuevo";
            this.ToolStripButton2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ToolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ToolStripButton2.Click += new System.EventHandler(this.ToolStripButton2_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.ForeColor = System.Drawing.Color.White;
            this.BtnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("BtnAceptar.Image")));
            this.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnAceptar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(65, 48);
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnAceptar.ToolTipText = "Aceptar";
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // ToolStripButton1
            // 
            this.ToolStripButton1.ForeColor = System.Drawing.Color.White;
            this.ToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButton1.Image")));
            this.ToolStripButton1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripButton1.Name = "ToolStripButton1";
            this.ToolStripButton1.Size = new System.Drawing.Size(42, 48);
            this.ToolStripButton1.Text = "Salir";
            this.ToolStripButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ToolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ToolStripButton1.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.gridTipo);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel2.Location = new System.Drawing.Point(0, 110);
            this.Panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(605, 471);
            this.Panel2.TabIndex = 3;
            // 
            // gridTipo
            // 
            this.gridTipo.AllowUserToAddRows = false;
            this.gridTipo.AllowUserToResizeColumns = false;
            this.gridTipo.AllowUserToResizeRows = false;
            this.gridTipo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridTipo.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTipo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridTipo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTipo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTipo.EnableHeadersVisualStyles = false;
            this.gridTipo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridTipo.Location = new System.Drawing.Point(0, 0);
            this.gridTipo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridTipo.Name = "gridTipo";
            this.gridTipo.ReadOnly = true;
            this.gridTipo.RowHeadersVisible = false;
            this.gridTipo.RowHeadersWidth = 51;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gray;
            this.gridTipo.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridTipo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridTipo.Size = new System.Drawing.Size(605, 471);
            this.gridTipo.TabIndex = 0;
            this.gridTipo.DoubleClick += new System.EventHandler(this.gridTipo_DoubleClick);
            // 
            // frmBuscarTipoRef
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 581);
            this.ControlBox = false;
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmBuscarTipoRef";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADCOMDAX - BUSCAR CODIGOS GENERALES";
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTipo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.TextBox TextNombre;
        internal System.Windows.Forms.TextBox TextCodigo;
        internal System.Windows.Forms.CheckBox EnInicio;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton ToolStripButton2;
        internal System.Windows.Forms.ToolStripButton BtnAceptar;
        internal System.Windows.Forms.ToolStripButton ToolStripButton1;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.DataGridView gridTipo;
    }
}