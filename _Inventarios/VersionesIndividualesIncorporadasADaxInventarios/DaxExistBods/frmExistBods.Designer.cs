namespace DaxInvLib
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.malla)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
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
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(926, 73);
            this.panel1.TabIndex = 0;
            // 
            // chkAlfabetico
            // 
            this.chkAlfabetico.AutoSize = true;
            this.chkAlfabetico.Checked = true;
            this.chkAlfabetico.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAlfabetico.Location = new System.Drawing.Point(289, 22);
            this.chkAlfabetico.Name = "chkAlfabetico";
            this.chkAlfabetico.Size = new System.Drawing.Size(104, 17);
            this.chkAlfabetico.TabIndex = 17;
            this.chkAlfabetico.Text = "Orden alfabético";
            this.chkAlfabetico.UseVisualStyleBackColor = true;
            this.chkAlfabetico.CheckedChanged += new System.EventHandler(this.chkAlfabetico_CheckedChanged);
            // 
            // btnSumatoria
            // 
            this.btnSumatoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSumatoria.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSumatoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSumatoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSumatoria.ForeColor = System.Drawing.Color.White;
            this.btnSumatoria.Location = new System.Drawing.Point(558, 18);
            this.btnSumatoria.Name = "btnSumatoria";
            this.btnSumatoria.Size = new System.Drawing.Size(77, 34);
            this.btnSumatoria.TabIndex = 16;
            this.btnSumatoria.Text = "Sumatoria";
            this.btnSumatoria.UseVisualStyleBackColor = false;
            this.btnSumatoria.Click += new System.EventHandler(this.btnSumatoria_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Saldo al :";
            // 
            // dtFechaFin
            // 
            this.dtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaFin.Location = new System.Drawing.Point(73, 48);
            this.dtFechaFin.Name = "dtFechaFin";
            this.dtFechaFin.Size = new System.Drawing.Size(85, 20);
            this.dtFechaFin.TabIndex = 14;
            this.dtFechaFin.ValueChanged += new System.EventHandler(this.dtFechaIni_ValueChanged);
            // 
            // cmbClasificdores
            // 
            this.cmbClasificdores.FormattingEnabled = true;
            this.cmbClasificdores.Location = new System.Drawing.Point(12, 18);
            this.cmbClasificdores.Name = "cmbClasificdores";
            this.cmbClasificdores.Size = new System.Drawing.Size(253, 21);
            this.cmbClasificdores.TabIndex = 9;
            this.cmbClasificdores.SelectedIndexChanged += new System.EventHandler(this.cmbClasificdores_SelectedIndexChanged);
            // 
            // btnActualiza
            // 
            this.btnActualiza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualiza.BackColor = System.Drawing.Color.SteelBlue;
            this.btnActualiza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualiza.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualiza.ForeColor = System.Drawing.Color.White;
            this.btnActualiza.Location = new System.Drawing.Point(737, 18);
            this.btnActualiza.Name = "btnActualiza";
            this.btnActualiza.Size = new System.Drawing.Size(77, 34);
            this.btnActualiza.TabIndex = 8;
            this.btnActualiza.Text = "Actualizar";
            this.btnActualiza.UseVisualStyleBackColor = false;
            this.btnActualiza.Click += new System.EventHandler(this.btnActualiza_Click);
            // 
            // btnImprime
            // 
            this.btnImprime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprime.BackColor = System.Drawing.Color.SteelBlue;
            this.btnImprime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprime.ForeColor = System.Drawing.Color.White;
            this.btnImprime.Location = new System.Drawing.Point(640, 18);
            this.btnImprime.Name = "btnImprime";
            this.btnImprime.Size = new System.Drawing.Size(77, 34);
            this.btnImprime.TabIndex = 7;
            this.btnImprime.Text = "Enviar";
            this.btnImprime.UseVisualStyleBackColor = false;
            this.btnImprime.Click += new System.EventHandler(this.btnImprime_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(832, 18);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(77, 34);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
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
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.malla.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.malla.BackgroundColor = System.Drawing.Color.White;
            this.malla.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.malla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.malla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.Format = "###,##0.00;(###,##0.00);#";
            dataGridViewCellStyle12.NullValue = null;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.malla.DefaultCellStyle = dataGridViewCellStyle12;
            this.malla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.malla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.malla.EnableHeadersVisualStyles = false;
            this.malla.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.malla.Location = new System.Drawing.Point(0, 73);
            this.malla.MultiSelect = false;
            this.malla.Name = "malla";
            this.malla.ReadOnly = true;
            this.malla.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.malla.RowHeadersVisible = false;
            this.malla.RowHeadersWidth = 20;
            this.malla.Size = new System.Drawing.Size(926, 372);
            this.malla.StandardTab = true;
            this.malla.TabIndex = 3;
            this.malla.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.malla_SortCompare);
            // 
            // frmExistBods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(926, 445);
            this.Controls.Add(this.malla);
            this.Controls.Add(this.panel1);
            this.Name = "frmExistBods";
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
    }
}