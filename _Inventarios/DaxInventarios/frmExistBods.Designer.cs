namespace DaxInvent
{
    partial class frmExistBods
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExistBods));
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkAlfabetico = new System.Windows.Forms.CheckBox();
            this.btnSumatoria = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dtFechaFin = new System.Windows.Forms.DateTimePicker();
            this.cmbClasificdores = new System.Windows.Forms.ComboBox();
            this.btnActualiza = new System.Windows.Forms.Button();
            this.btnImprime = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.malla = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.labArticulo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.malla)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Controls.Add(this.labArticulo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.chkAlfabetico);
            this.panel1.Controls.Add(this.btnSumatoria);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtFechaFin);
            this.panel1.Controls.Add(this.cmbClasificdores);
            this.panel1.Controls.Add(this.btnActualiza);
            this.panel1.Controls.Add(this.btnImprime);
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1235, 142);
            this.panel1.TabIndex = 0;
            // 
            // chkAlfabetico
            // 
            this.chkAlfabetico.AutoSize = true;
            this.chkAlfabetico.Checked = true;
            this.chkAlfabetico.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAlfabetico.Location = new System.Drawing.Point(385, 27);
            this.chkAlfabetico.Margin = new System.Windows.Forms.Padding(4);
            this.chkAlfabetico.Name = "chkAlfabetico";
            this.chkAlfabetico.Size = new System.Drawing.Size(135, 21);
            this.chkAlfabetico.TabIndex = 17;
            this.chkAlfabetico.Text = "Orden alfabético";
            this.chkAlfabetico.UseVisualStyleBackColor = true;
            this.chkAlfabetico.CheckedChanged += new System.EventHandler(this.chkAlfabetico_CheckedChanged);
            // 
            // btnSumatoria
            // 
            this.btnSumatoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSumatoria.BackColor = System.Drawing.Color.Transparent;
            this.btnSumatoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSumatoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSumatoria.ForeColor = System.Drawing.Color.White;
            this.btnSumatoria.Location = new System.Drawing.Point(776, 22);
            this.btnSumatoria.Margin = new System.Windows.Forms.Padding(4);
            this.btnSumatoria.Name = "btnSumatoria";
            this.btnSumatoria.Size = new System.Drawing.Size(103, 42);
            this.btnSumatoria.TabIndex = 16;
            this.btnSumatoria.Text = "Sumatoria";
            this.btnSumatoria.UseVisualStyleBackColor = false;
            this.btnSumatoria.Click += new System.EventHandler(this.btnSumatoria_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Saldo al :";
            // 
            // dtFechaFin
            // 
            this.dtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaFin.Location = new System.Drawing.Point(97, 59);
            this.dtFechaFin.Margin = new System.Windows.Forms.Padding(4);
            this.dtFechaFin.Name = "dtFechaFin";
            this.dtFechaFin.Size = new System.Drawing.Size(112, 22);
            this.dtFechaFin.TabIndex = 14;
            this.dtFechaFin.ValueChanged += new System.EventHandler(this.dtFechaIni_ValueChanged);
            // 
            // cmbClasificdores
            // 
            this.cmbClasificdores.FormattingEnabled = true;
            this.cmbClasificdores.Location = new System.Drawing.Point(16, 22);
            this.cmbClasificdores.Margin = new System.Windows.Forms.Padding(4);
            this.cmbClasificdores.Name = "cmbClasificdores";
            this.cmbClasificdores.Size = new System.Drawing.Size(336, 24);
            this.cmbClasificdores.TabIndex = 9;
            this.cmbClasificdores.SelectedIndexChanged += new System.EventHandler(this.cmbClasificdores_SelectedIndexChanged);
            // 
            // btnActualiza
            // 
            this.btnActualiza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualiza.BackColor = System.Drawing.Color.Transparent;
            this.btnActualiza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualiza.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualiza.ForeColor = System.Drawing.Color.White;
            this.btnActualiza.Location = new System.Drawing.Point(998, 22);
            this.btnActualiza.Margin = new System.Windows.Forms.Padding(4);
            this.btnActualiza.Name = "btnActualiza";
            this.btnActualiza.Size = new System.Drawing.Size(103, 42);
            this.btnActualiza.TabIndex = 8;
            this.btnActualiza.Text = "Actualizar";
            this.btnActualiza.UseVisualStyleBackColor = false;
            this.btnActualiza.Click += new System.EventHandler(this.btnActualiza_Click);
            // 
            // btnImprime
            // 
            this.btnImprime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprime.BackColor = System.Drawing.Color.Transparent;
            this.btnImprime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprime.ForeColor = System.Drawing.Color.White;
            this.btnImprime.Location = new System.Drawing.Point(887, 22);
            this.btnImprime.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprime.Name = "btnImprime";
            this.btnImprime.Size = new System.Drawing.Size(103, 42);
            this.btnImprime.TabIndex = 7;
            this.btnImprime.Text = "Enviar";
            this.btnImprime.UseVisualStyleBackColor = false;
            this.btnImprime.Click += new System.EventHandler(this.btnImprime_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.Transparent;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(1109, 22);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(103, 42);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Bodega";
            // 
            // malla
            // 
            this.malla.AllowUserToAddRows = false;
            this.malla.AllowUserToDeleteRows = false;
            this.malla.AllowUserToOrderColumns = true;
            this.malla.AllowUserToResizeColumns = false;
            this.malla.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.malla.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.malla.BackgroundColor = System.Drawing.Color.White;
            this.malla.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.malla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.malla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.Format = "###,##0.00;(###,##0.00);#";
            dataGridViewCellStyle9.NullValue = null;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.malla.DefaultCellStyle = dataGridViewCellStyle9;
            this.malla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.malla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.malla.EnableHeadersVisualStyles = false;
            this.malla.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.malla.Location = new System.Drawing.Point(0, 142);
            this.malla.Margin = new System.Windows.Forms.Padding(4);
            this.malla.MultiSelect = false;
            this.malla.Name = "malla";
            this.malla.ReadOnly = true;
            this.malla.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.malla.RowHeadersVisible = false;
            this.malla.RowHeadersWidth = 20;
            this.malla.Size = new System.Drawing.Size(1235, 406);
            this.malla.StandardTab = true;
            this.malla.TabIndex = 3;
            this.malla.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.malla_SortCompare);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(222, 100);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 26);
            this.button1.TabIndex = 21;
            this.button1.Text = "..";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(97, 99);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(132, 22);
            this.txtCodigo.TabIndex = 18;
            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
            // 
            // labArticulo
            // 
            this.labArticulo.BackColor = System.Drawing.Color.White;
            this.labArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labArticulo.ForeColor = System.Drawing.Color.Black;
            this.labArticulo.Location = new System.Drawing.Point(252, 101);
            this.labArticulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labArticulo.Name = "labArticulo";
            this.labArticulo.Size = new System.Drawing.Size(481, 22);
            this.labArticulo.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(20, 104);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "ARTICULO:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // frmExistBods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1235, 548);
            this.ControlBox = false;
            this.Controls.Add(this.malla);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmExistBods";
            this.ShowIcon = false;
            this.Text = "EXISTENCIAS DE ARTICULOS POR BODEGA";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.malla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView malla;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnActualiza;
        private System.Windows.Forms.Button btnImprime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtFechaFin;
        private System.Windows.Forms.ComboBox cmbClasificdores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSumatoria;
        private System.Windows.Forms.CheckBox chkAlfabetico;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label labArticulo;
        private System.Windows.Forms.Label label2;
    }
}