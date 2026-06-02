namespace DaxClasificadores
{
    partial class FrmDistrbuirCosto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDistrbuirCosto));
            this.Malla = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.labunidades = new System.Windows.Forms.Label();
            this.txtUnidades = new System.Windows.Forms.TextBox();
            this.labCosto = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.ToolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDivideCosto = new System.Windows.Forms.ToolStripButton();
            this.btnRegistraCosto = new System.Windows.Forms.ToolStripButton();
            this.btnBorrarCostos = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDivideUnidad = new System.Windows.Forms.ToolStripButton();
            this.chkRegistraCantidad = new System.Windows.Forms.ToolStripButton();
            this.btnBorrarUnidades = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnaceptar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labTotalUnidades = new System.Windows.Forms.Label();
            this.txtTotUnidades = new System.Windows.Forms.TextBox();
            this.labTotalCosto = new System.Windows.Forms.Label();
            this.txtTotalCosto = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Malla)).BeginInit();
            this.panel2.SuspendLayout();
            this.ToolStrip4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Malla
            // 
            this.Malla.AllowUserToAddRows = false;
            this.Malla.AllowUserToResizeColumns = false;
            this.Malla.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Malla.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Malla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Malla.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Malla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Malla.ColumnHeadersHeight = 20;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Malla.DefaultCellStyle = dataGridViewCellStyle3;
            this.Malla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Malla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.Malla.EnableHeadersVisualStyles = false;
            this.Malla.Location = new System.Drawing.Point(0, 129);
            this.Malla.Name = "Malla";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Malla.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.Malla.RowHeadersWidth = 20;
            this.Malla.Size = new System.Drawing.Size(616, 417);
            this.Malla.StandardTab = true;
            this.Malla.TabIndex = 33;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.labunidades);
            this.panel2.Controls.Add(this.txtUnidades);
            this.panel2.Controls.Add(this.labCosto);
            this.panel2.Controls.Add(this.txtCosto);
            this.panel2.Controls.Add(this.ToolStrip4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(616, 129);
            this.panel2.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(616, 30);
            this.label3.TabIndex = 6;
            this.label3.Text = "DISTRIBUCION DE RUBROS PARA ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labunidades
            // 
            this.labunidades.AutoSize = true;
            this.labunidades.ForeColor = System.Drawing.Color.White;
            this.labunidades.Location = new System.Drawing.Point(267, 99);
            this.labunidades.Name = "labunidades";
            this.labunidades.Size = new System.Drawing.Size(166, 13);
            this.labunidades.TabIndex = 5;
            this.labunidades.Text = "Cantidad de unidades a distribuir :";
            // 
            // txtUnidades
            // 
            this.txtUnidades.Location = new System.Drawing.Point(439, 96);
            this.txtUnidades.Name = "txtUnidades";
            this.txtUnidades.Size = new System.Drawing.Size(72, 20);
            this.txtUnidades.TabIndex = 4;
            // 
            // labCosto
            // 
            this.labCosto.AutoSize = true;
            this.labCosto.ForeColor = System.Drawing.Color.White;
            this.labCosto.Location = new System.Drawing.Point(18, 96);
            this.labCosto.Name = "labCosto";
            this.labCosto.Size = new System.Drawing.Size(121, 13);
            this.labCosto.TabIndex = 3;
            this.labCosto.Text = "Valor costos a distribuir :";
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(145, 93);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(72, 20);
            this.txtCosto.TabIndex = 2;
            // 
            // ToolStrip4
            // 
            this.ToolStrip4.AutoSize = false;
            this.ToolStrip4.BackColor = System.Drawing.Color.Transparent;
            this.ToolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip4.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ToolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.btnDivideCosto,
            this.btnRegistraCosto,
            this.btnBorrarCostos,
            this.toolStripSeparator4,
            this.btnDivideUnidad,
            this.chkRegistraCantidad,
            this.btnBorrarUnidades,
            this.toolStripSeparator1,
            this.btnaceptar,
            this.btnSalir});
            this.ToolStrip4.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ToolStrip4.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip4.Name = "ToolStrip4";
            this.ToolStrip4.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStrip4.Size = new System.Drawing.Size(616, 60);
            this.ToolStrip4.Stretch = true;
            this.ToolStrip4.TabIndex = 1;
            this.ToolStrip4.Text = "ToolStrip4";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 60);
            // 
            // btnDivideCosto
            // 
            this.btnDivideCosto.ForeColor = System.Drawing.Color.White;
            this.btnDivideCosto.Image = ((System.Drawing.Image)(resources.GetObject("btnDivideCosto.Image")));
            this.btnDivideCosto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDivideCosto.Name = "btnDivideCosto";
            this.btnDivideCosto.Size = new System.Drawing.Size(75, 57);
            this.btnDivideCosto.Text = "DivideCosto";
            this.btnDivideCosto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDivideCosto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDivideCosto.ToolTipText = "Divide el valor del costo entre cada item seleccionado";
            this.btnDivideCosto.Click += new System.EventHandler(this.btnDivideCosto_Click);
            // 
            // btnRegistraCosto
            // 
            this.btnRegistraCosto.ForeColor = System.Drawing.Color.White;
            this.btnRegistraCosto.Image = ((System.Drawing.Image)(resources.GetObject("btnRegistraCosto.Image")));
            this.btnRegistraCosto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRegistraCosto.Name = "btnRegistraCosto";
            this.btnRegistraCosto.Size = new System.Drawing.Size(84, 57);
            this.btnRegistraCosto.Text = "RegistraCosto";
            this.btnRegistraCosto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRegistraCosto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRegistraCosto.ToolTipText = "Registra el valor del costo en cada item seleccionado";
            this.btnRegistraCosto.Click += new System.EventHandler(this.btnRegistraCosto_Click);
            // 
            // btnBorrarCostos
            // 
            this.btnBorrarCostos.ForeColor = System.Drawing.Color.White;
            this.btnBorrarCostos.Image = ((System.Drawing.Image)(resources.GetObject("btnBorrarCostos.Image")));
            this.btnBorrarCostos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBorrarCostos.Name = "btnBorrarCostos";
            this.btnBorrarCostos.Size = new System.Drawing.Size(79, 57);
            this.btnBorrarCostos.Text = "BorrarCostos";
            this.btnBorrarCostos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBorrarCostos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBorrarCostos.ToolTipText = "Marca todos los items";
            this.btnBorrarCostos.Click += new System.EventHandler(this.btnBorrarCostos_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 60);
            // 
            // btnDivideUnidad
            // 
            this.btnDivideUnidad.ForeColor = System.Drawing.Color.White;
            this.btnDivideUnidad.Image = ((System.Drawing.Image)(resources.GetObject("btnDivideUnidad.Image")));
            this.btnDivideUnidad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDivideUnidad.Name = "btnDivideUnidad";
            this.btnDivideUnidad.RightToLeftAutoMirrorImage = true;
            this.btnDivideUnidad.Size = new System.Drawing.Size(76, 57);
            this.btnDivideUnidad.Text = "DividUnidad";
            this.btnDivideUnidad.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDivideUnidad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDivideUnidad.ToolTipText = "Divide el valor de unidades entre cada item seleccionado";
            this.btnDivideUnidad.Click += new System.EventHandler(this.btnDivideUnidad_Click);
            // 
            // chkRegistraCantidad
            // 
            this.chkRegistraCantidad.ForeColor = System.Drawing.Color.White;
            this.chkRegistraCantidad.Image = ((System.Drawing.Image)(resources.GetObject("chkRegistraCantidad.Image")));
            this.chkRegistraCantidad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.chkRegistraCantidad.Name = "chkRegistraCantidad";
            this.chkRegistraCantidad.Size = new System.Drawing.Size(77, 57);
            this.chkRegistraCantidad.Text = "RegisUnidad";
            this.chkRegistraCantidad.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkRegistraCantidad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.chkRegistraCantidad.ToolTipText = "Registra el valor de unidades en cada item seleccionado";
            this.chkRegistraCantidad.Click += new System.EventHandler(this.chkRegistraCantidad_Click);
            // 
            // btnBorrarUnidades
            // 
            this.btnBorrarUnidades.ForeColor = System.Drawing.Color.White;
            this.btnBorrarUnidades.Image = ((System.Drawing.Image)(resources.GetObject("btnBorrarUnidades.Image")));
            this.btnBorrarUnidades.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBorrarUnidades.Name = "btnBorrarUnidades";
            this.btnBorrarUnidades.Size = new System.Drawing.Size(92, 57);
            this.btnBorrarUnidades.Text = "BorrarUnidades";
            this.btnBorrarUnidades.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBorrarUnidades.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBorrarUnidades.ToolTipText = "Desmarca todos los items";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 60);
            // 
            // btnaceptar
            // 
            this.btnaceptar.ForeColor = System.Drawing.Color.White;
            this.btnaceptar.Image = global::sesClasif.Properties.Resources.Select;
            this.btnaceptar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnaceptar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnaceptar.Name = "btnaceptar";
            this.btnaceptar.Size = new System.Drawing.Size(52, 57);
            this.btnaceptar.Text = "Aceptar";
            this.btnaceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnaceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnaceptar.ToolTipText = "Guarda los valores seleccionados y regresa al documento";
            this.btnaceptar.Click += new System.EventHandler(this.btnaceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(36, 57);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.labTotalUnidades);
            this.panel1.Controls.Add(this.txtTotUnidades);
            this.panel1.Controls.Add(this.labTotalCosto);
            this.panel1.Controls.Add(this.txtTotalCosto);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 501);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(616, 45);
            this.panel1.TabIndex = 34;
            // 
            // labTotalUnidades
            // 
            this.labTotalUnidades.AutoSize = true;
            this.labTotalUnidades.ForeColor = System.Drawing.Color.White;
            this.labTotalUnidades.Location = new System.Drawing.Point(449, 19);
            this.labTotalUnidades.Name = "labTotalUnidades";
            this.labTotalUnidades.Size = new System.Drawing.Size(83, 13);
            this.labTotalUnidades.TabIndex = 5;
            this.labTotalUnidades.Text = "Total unidades :";
            // 
            // txtTotUnidades
            // 
            this.txtTotUnidades.Location = new System.Drawing.Point(535, 15);
            this.txtTotUnidades.Name = "txtTotUnidades";
            this.txtTotUnidades.Size = new System.Drawing.Size(72, 20);
            this.txtTotUnidades.TabIndex = 4;
            // 
            // labTotalCosto
            // 
            this.labTotalCosto.AutoSize = true;
            this.labTotalCosto.ForeColor = System.Drawing.Color.White;
            this.labTotalCosto.Location = new System.Drawing.Point(288, 19);
            this.labTotalCosto.Name = "labTotalCosto";
            this.labTotalCosto.Size = new System.Drawing.Size(74, 13);
            this.labTotalCosto.TabIndex = 3;
            this.labTotalCosto.Text = " Total costos :";
            // 
            // txtTotalCosto
            // 
            this.txtTotalCosto.Location = new System.Drawing.Point(365, 15);
            this.txtTotalCosto.Name = "txtTotalCosto";
            this.txtTotalCosto.Size = new System.Drawing.Size(72, 20);
            this.txtTotalCosto.TabIndex = 2;
            // 
            // FrmDistrbuirCosto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 546);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Malla);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmDistrbuirCosto";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.Malla)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ToolStrip4.ResumeLayout(false);
            this.ToolStrip4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView Malla;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.ToolStrip ToolStrip4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        internal System.Windows.Forms.ToolStripButton btnDivideCosto;
        internal System.Windows.Forms.ToolStripButton btnDivideUnidad;
        private System.Windows.Forms.ToolStripButton btnRegistraCosto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton chkRegistraCantidad;
        internal System.Windows.Forms.ToolStripButton btnBorrarUnidades;
        internal System.Windows.Forms.ToolStripButton btnaceptar;
        internal System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.Label labunidades;
        private System.Windows.Forms.TextBox txtUnidades;
        private System.Windows.Forms.Label labCosto;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labTotalUnidades;
        private System.Windows.Forms.TextBox txtTotUnidades;
        private System.Windows.Forms.Label labTotalCosto;
        private System.Windows.Forms.TextBox txtTotalCosto;
        internal System.Windows.Forms.ToolStripButton btnBorrarCostos;
    }
}