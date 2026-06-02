namespace DaxInfDefinidos
{
    partial class frmInfDef
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInfDef));
            this.MallaDatos = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkactivos = new System.Windows.Forms.CheckBox();
            this.chkCesantes = new System.Windows.Forms.CheckBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
            this.cmbCargo = new System.Windows.Forms.ComboBox();
            this.cmbSucursal = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.cmbPeriodos = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnOpciones = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAbrir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEnviar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBuscar = new System.Windows.Forms.ToolStripButton();
            this.btnProximo = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.MallaDatos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MallaDatos
            // 
            this.MallaDatos.AllowUserToAddRows = false;
            this.MallaDatos.AllowUserToDeleteRows = false;
            this.MallaDatos.AllowUserToOrderColumns = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MallaDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.MallaDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.MallaDatos.BackgroundColor = System.Drawing.Color.White;
            this.MallaDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.NullValue = null;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MallaDatos.DefaultCellStyle = dataGridViewCellStyle4;
            this.MallaDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MallaDatos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.MallaDatos.Location = new System.Drawing.Point(263, 0);
            this.MallaDatos.Name = "MallaDatos";
            this.MallaDatos.ReadOnly = true;
            this.MallaDatos.Size = new System.Drawing.Size(669, 474);
            this.MallaDatos.TabIndex = 13;
            this.MallaDatos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.MallaDatos_CellEndEdit);
            this.MallaDatos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.MallaDatos_DataError);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkactivos);
            this.groupBox1.Controls.Add(this.chkCesantes);
            this.groupBox1.Controls.Add(this.Label5);
            this.groupBox1.Controls.Add(this.cmbDepartamento);
            this.groupBox1.Controls.Add(this.cmbCargo);
            this.groupBox1.Controls.Add(this.cmbSucursal);
            this.groupBox1.Controls.Add(this.Label3);
            this.groupBox1.Controls.Add(this.Label4);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(8, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 134);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro para visualizar empleados";
            // 
            // chkactivos
            // 
            this.chkactivos.AutoSize = true;
            this.chkactivos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkactivos.Checked = true;
            this.chkactivos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkactivos.ForeColor = System.Drawing.Color.White;
            this.chkactivos.Location = new System.Drawing.Point(26, 22);
            this.chkactivos.Name = "chkactivos";
            this.chkactivos.Size = new System.Drawing.Size(61, 17);
            this.chkactivos.TabIndex = 4;
            this.chkactivos.Text = "Activos";
            this.chkactivos.UseVisualStyleBackColor = true;
            // 
            // chkCesantes
            // 
            this.chkCesantes.AutoSize = true;
            this.chkCesantes.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCesantes.ForeColor = System.Drawing.Color.White;
            this.chkCesantes.Location = new System.Drawing.Point(105, 21);
            this.chkCesantes.Name = "chkCesantes";
            this.chkCesantes.Size = new System.Drawing.Size(70, 17);
            this.chkCesantes.TabIndex = 2;
            this.chkCesantes.Text = "Cesantes";
            this.chkCesantes.UseVisualStyleBackColor = true;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.ForeColor = System.Drawing.Color.White;
            this.Label5.Location = new System.Drawing.Point(45, 100);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(35, 13);
            this.Label5.TabIndex = 16;
            this.Label5.Text = "Cargo";
            // 
            // cmbDepartamento
            // 
            this.cmbDepartamento.FormattingEnabled = true;
            this.cmbDepartamento.Location = new System.Drawing.Point(84, 73);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(158, 21);
            this.cmbDepartamento.TabIndex = 12;
            // 
            // cmbCargo
            // 
            this.cmbCargo.FormattingEnabled = true;
            this.cmbCargo.Location = new System.Drawing.Point(84, 97);
            this.cmbCargo.Name = "cmbCargo";
            this.cmbCargo.Size = new System.Drawing.Size(158, 21);
            this.cmbCargo.TabIndex = 15;
            // 
            // cmbSucursal
            // 
            this.cmbSucursal.FormattingEnabled = true;
            this.cmbSucursal.Location = new System.Drawing.Point(84, 49);
            this.cmbSucursal.Name = "cmbSucursal";
            this.cmbSucursal.Size = new System.Drawing.Size(158, 21);
            this.cmbSucursal.TabIndex = 11;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.ForeColor = System.Drawing.Color.White;
            this.Label3.Location = new System.Drawing.Point(6, 76);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(74, 13);
            this.Label3.TabIndex = 14;
            this.Label3.Text = "Departamento";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.ForeColor = System.Drawing.Color.White;
            this.Label4.Location = new System.Drawing.Point(32, 52);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(48, 13);
            this.Label4.TabIndex = 13;
            this.Label4.Text = "Sucursal";
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Controls.Add(this.cmbPeriodos);
            this.Panel1.Controls.Add(this.groupBox1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.Panel1.ForeColor = System.Drawing.Color.White;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(263, 474);
            this.Panel1.TabIndex = 12;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(18, 15);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(56, 13);
            this.Label1.TabIndex = 22;
            this.Label1.Text = "PERIODO";
            // 
            // cmbPeriodos
            // 
            this.cmbPeriodos.FormattingEnabled = true;
            this.cmbPeriodos.Location = new System.Drawing.Point(80, 12);
            this.cmbPeriodos.Name = "cmbPeriodos";
            this.cmbPeriodos.Size = new System.Drawing.Size(169, 21);
            this.cmbPeriodos.TabIndex = 21;
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.ToolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpciones,
            this.toolStripSeparator3,
            this.btnAbrir,
            this.toolStripSeparator5,
            this.btnEnviar,
            this.toolStripSeparator4,
            this.btnBuscar,
            this.btnProximo,
            this.ToolStripSeparator2,
            this.btnSalir});
            this.ToolStrip1.Location = new System.Drawing.Point(263, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(669, 46);
            this.ToolStrip1.TabIndex = 16;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // btnOpciones
            // 
            this.btnOpciones.CheckOnClick = true;
            this.btnOpciones.ForeColor = System.Drawing.Color.White;
            this.btnOpciones.Image = ((System.Drawing.Image)(resources.GetObject("btnOpciones.Image")));
            this.btnOpciones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpciones.Name = "btnOpciones";
            this.btnOpciones.Size = new System.Drawing.Size(59, 43);
            this.btnOpciones.Text = "opciónes";
            this.btnOpciones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOpciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOpciones.ToolTipText = "Ocultar o ver opciones ";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 46);
            // 
            // btnAbrir
            // 
            this.btnAbrir.ForeColor = System.Drawing.Color.White;
            this.btnAbrir.Image = ((System.Drawing.Image)(resources.GetObject("btnAbrir.Image")));
            this.btnAbrir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(61, 43);
            this.btnAbrir.Text = "Abrir";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 46);
            // 
            // btnEnviar
            // 
            this.btnEnviar.ForeColor = System.Drawing.Color.White;
            this.btnEnviar.Image = ((System.Drawing.Image)(resources.GetObject("btnEnviar.Image")));
            this.btnEnviar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(98, 43);
            this.btnEnviar.Text = "Imprime Exporta";
            this.btnEnviar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click_1);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 46);
            // 
            // btnBuscar
            // 
            this.btnBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(28, 43);
            this.btnBuscar.Text = "toolStripButton1";
            this.btnBuscar.ToolTipText = "Buscar un valor";
            // 
            // btnProximo
            // 
            this.btnProximo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnProximo.Image = ((System.Drawing.Image)(resources.GetObject("btnProximo.Image")));
            this.btnProximo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProximo.Name = "btnProximo";
            this.btnProximo.Size = new System.Drawing.Size(28, 43);
            this.btnProximo.Text = "toolStripButton2";
            this.btnProximo.ToolTipText = "Buscar el mismo valor siguiente";
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 46);
            // 
            // btnSalir
            // 
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(57, 43);
            this.btnSalir.Text = "Salir";
            // 
            // frmInfDef
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 474);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.MallaDatos);
            this.Controls.Add(this.Panel1);
            this.Name = "frmInfDef";
            this.Text = "ADCOMDAX - INFORMES ESPECIALES DE NOMINA";
            this.Load += new System.EventHandler(this.frmInfDef_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MallaDatos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView MallaDatos;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.CheckBox chkactivos;
        internal System.Windows.Forms.CheckBox chkCesantes;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.ComboBox cmbDepartamento;
        internal System.Windows.Forms.ComboBox cmbCargo;
        internal System.Windows.Forms.ComboBox cmbSucursal;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox cmbPeriodos;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton btnOpciones;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        internal System.Windows.Forms.ToolStripButton btnAbrir;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        internal System.Windows.Forms.ToolStripButton btnEnviar;
        internal System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnBuscar;
        private System.Windows.Forms.ToolStripButton btnProximo;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        internal System.Windows.Forms.ToolStripButton btnSalir;
    }
}

