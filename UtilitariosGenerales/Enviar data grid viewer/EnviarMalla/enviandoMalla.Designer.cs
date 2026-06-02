namespace SalidasDeMalla
{
    partial class enviandoMalla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(enviandoMalla));
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnImprime = new System.Windows.Forms.Button();
            this.btnWord = new System.Windows.Forms.Button();
            this.btnPdf = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkEncabezado = new System.Windows.Forms.CheckBox();
            this.chkTab = new System.Windows.Forms.RadioButton();
            this.chkComa = new System.Windows.Forms.RadioButton();
            this.chkPuntoComa = new System.Windows.Forms.RadioButton();
            this.btnCsv = new System.Windows.Forms.Button();
            this.MyPrintDocument = new System.Drawing.Printing.PrintDocument();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.SlateGray;
            this.btnExcel.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gray;
            this.btnExcel.ForeColor = System.Drawing.Color.White;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.Location = new System.Drawing.Point(2, 46);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(190, 40);
            this.btnExcel.TabIndex = 0;
            this.btnExcel.Text = "Exportar a Excell";
            this.btnExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnImprime
            // 
            this.btnImprime.BackColor = System.Drawing.Color.SlateGray;
            this.btnImprime.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gray;
            this.btnImprime.ForeColor = System.Drawing.Color.White;
            this.btnImprime.Image = ((System.Drawing.Image)(resources.GetObject("btnImprime.Image")));
            this.btnImprime.Location = new System.Drawing.Point(2, 3);
            this.btnImprime.Name = "btnImprime";
            this.btnImprime.Size = new System.Drawing.Size(190, 40);
            this.btnImprime.TabIndex = 1;
            this.btnImprime.Text = "Imprimir";
            this.btnImprime.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprime.UseVisualStyleBackColor = false;
            this.btnImprime.Click += new System.EventHandler(this.btnImprime_Click);
            // 
            // btnWord
            // 
            this.btnWord.BackColor = System.Drawing.Color.SlateGray;
            this.btnWord.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gray;
            this.btnWord.ForeColor = System.Drawing.Color.White;
            this.btnWord.Image = ((System.Drawing.Image)(resources.GetObject("btnWord.Image")));
            this.btnWord.Location = new System.Drawing.Point(2, 90);
            this.btnWord.Name = "btnWord";
            this.btnWord.Size = new System.Drawing.Size(190, 40);
            this.btnWord.TabIndex = 3;
            this.btnWord.Text = "Exportar a Word";
            this.btnWord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnWord.UseVisualStyleBackColor = false;
            this.btnWord.Visible = false;
            this.btnWord.Click += new System.EventHandler(this.btnWord_Click);
            // 
            // btnPdf
            // 
            this.btnPdf.BackColor = System.Drawing.Color.SlateGray;
            this.btnPdf.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gray;
            this.btnPdf.ForeColor = System.Drawing.Color.White;
            this.btnPdf.Image = ((System.Drawing.Image)(resources.GetObject("btnPdf.Image")));
            this.btnPdf.Location = new System.Drawing.Point(2, 134);
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Size = new System.Drawing.Size(190, 40);
            this.btnPdf.TabIndex = 4;
            this.btnPdf.Text = "Exportar a PDF";
            this.btnPdf.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPdf.UseVisualStyleBackColor = false;
            this.btnPdf.Visible = false;
            this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.SlateGray;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gray;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(0, 237);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(190, 40);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "SALIR";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSlateGray;
            this.groupBox1.Controls.Add(this.chkEncabezado);
            this.groupBox1.Controls.Add(this.chkTab);
            this.groupBox1.Controls.Add(this.chkComa);
            this.groupBox1.Controls.Add(this.chkPuntoComa);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(3, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 105);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Separadores CSV";
            // 
            // chkEncabezado
            // 
            this.chkEncabezado.AutoSize = true;
            this.chkEncabezado.Location = new System.Drawing.Point(7, 85);
            this.chkEncabezado.Name = "chkEncabezado";
            this.chkEncabezado.Size = new System.Drawing.Size(116, 17);
            this.chkEncabezado.TabIndex = 10;
            this.chkEncabezado.Text = "Incluir encabezado";
            this.chkEncabezado.UseVisualStyleBackColor = true;
            // 
            // chkTab
            // 
            this.chkTab.AutoSize = true;
            this.chkTab.Location = new System.Drawing.Point(6, 53);
            this.chkTab.Name = "chkTab";
            this.chkTab.Size = new System.Drawing.Size(105, 17);
            this.chkTab.TabIndex = 9;
            this.chkTab.Text = "tabulador [ TAB ]";
            this.chkTab.UseVisualStyleBackColor = true;
            // 
            // chkComa
            // 
            this.chkComa.AutoSize = true;
            this.chkComa.Checked = true;
            this.chkComa.Location = new System.Drawing.Point(6, 17);
            this.chkComa.Name = "chkComa";
            this.chkComa.Size = new System.Drawing.Size(69, 17);
            this.chkComa.TabIndex = 7;
            this.chkComa.TabStop = true;
            this.chkComa.Text = "coma [ , ]";
            this.chkComa.UseVisualStyleBackColor = true;
            // 
            // chkPuntoComa
            // 
            this.chkPuntoComa.AutoSize = true;
            this.chkPuntoComa.Location = new System.Drawing.Point(6, 35);
            this.chkPuntoComa.Name = "chkPuntoComa";
            this.chkPuntoComa.Size = new System.Drawing.Size(107, 17);
            this.chkPuntoComa.TabIndex = 8;
            this.chkPuntoComa.Text = "punto y coma [ ; ]";
            this.chkPuntoComa.UseVisualStyleBackColor = true;
            // 
            // btnCsv
            // 
            this.btnCsv.BackColor = System.Drawing.Color.SlateGray;
            this.btnCsv.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gray;
            this.btnCsv.ForeColor = System.Drawing.Color.White;
            this.btnCsv.Location = new System.Drawing.Point(2, 90);
            this.btnCsv.Name = "btnCsv";
            this.btnCsv.Size = new System.Drawing.Size(189, 33);
            this.btnCsv.TabIndex = 8;
            this.btnCsv.Text = "Exportar a CSV";
            this.btnCsv.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCsv.UseVisualStyleBackColor = false;
            this.btnCsv.Click += new System.EventHandler(this.btnCsv_Click_1);
            // 
            // enviandoMalla
            // 
            this.AcceptButton = this.btnImprime;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(194, 280);
            this.ControlBox = false;
            this.Controls.Add(this.btnCsv);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnPdf);
            this.Controls.Add(this.btnWord);
            this.Controls.Add(this.btnImprime);
            this.Controls.Add(this.btnExcel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "enviandoMalla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnImprime;
        private System.Windows.Forms.Button btnWord;
        private System.Windows.Forms.Button btnPdf;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton chkTab;
        private System.Windows.Forms.RadioButton chkComa;
        private System.Windows.Forms.RadioButton chkPuntoComa;
        private System.Windows.Forms.Button btnCsv;
        private System.Windows.Forms.CheckBox chkEncabezado;
        private System.Drawing.Printing.PrintDocument MyPrintDocument;
        private System.Windows.Forms.SaveFileDialog sfd;
    }
}