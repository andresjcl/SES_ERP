namespace ImpresionDocumentosDax
{
    partial class ImprimeConsulta
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImprimeConsulta));
            this.BtnPrevisual = new System.Windows.Forms.Button();
            this.BtnImpresora = new System.Windows.Forms.Button();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.QueImpresora = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this._Label1_0 = new System.Windows.Forms.Label();
            this.BtnPagina = new System.Windows.Forms.Button();
            this.PageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.PrintDocument1 = new System.Drawing.Printing.PrintDocument();
            this.PrintPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.SuspendLayout();
            // 
            // BtnPrevisual
            // 
            this.BtnPrevisual.BackColor = System.Drawing.Color.DimGray;
            this.BtnPrevisual.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnPrevisual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPrevisual.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPrevisual.ForeColor = System.Drawing.Color.White;
            this.BtnPrevisual.Image = ((System.Drawing.Image)(resources.GetObject("BtnPrevisual.Image")));
            this.BtnPrevisual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnPrevisual.Location = new System.Drawing.Point(470, 67);
            this.BtnPrevisual.Name = "BtnPrevisual";
            this.BtnPrevisual.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnPrevisual.Size = new System.Drawing.Size(150, 50);
            this.BtnPrevisual.TabIndex = 30;
            this.BtnPrevisual.Text = "&Previsual";
            this.ToolTip1.SetToolTip(this.BtnPrevisual, "Visualizar la impresión del documento en pantalla");
            this.BtnPrevisual.UseVisualStyleBackColor = false;
            this.BtnPrevisual.Click += new System.EventHandler(this.BtnPrevisual_Click);
            // 
            // BtnImpresora
            // 
            this.BtnImpresora.BackColor = System.Drawing.Color.DimGray;
            this.BtnImpresora.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnImpresora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnImpresora.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnImpresora.ForeColor = System.Drawing.Color.White;
            this.BtnImpresora.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnImpresora.Location = new System.Drawing.Point(251, 148);
            this.BtnImpresora.Name = "BtnImpresora";
            this.BtnImpresora.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnImpresora.Size = new System.Drawing.Size(150, 30);
            this.BtnImpresora.TabIndex = 26;
            this.BtnImpresora.Text = "    Ca&mbia Impresora";
            this.ToolTip1.SetToolTip(this.BtnImpresora, "Cambiar de impresora actual");
            this.BtnImpresora.UseVisualStyleBackColor = false;
            this.BtnImpresora.Click += new System.EventHandler(this.BtnImpresora_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.BackColor = System.Drawing.Color.DimGray;
            this.BtnAceptar.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAceptar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.ForeColor = System.Drawing.Color.White;
            this.BtnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("BtnAceptar.Image")));
            this.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAceptar.Location = new System.Drawing.Point(470, 12);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnAceptar.Size = new System.Drawing.Size(150, 50);
            this.BtnAceptar.TabIndex = 23;
            this.BtnAceptar.Text = "&Imprimir";
            this.ToolTip1.SetToolTip(this.BtnAceptar, "Imprimir el documento en la impresora seleccionada");
            this.BtnAceptar.UseVisualStyleBackColor = false;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.DimGray;
            this.BtnCancelar.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.ForeColor = System.Drawing.Color.White;
            this.BtnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BtnCancelar.Image")));
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(470, 124);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnCancelar.Size = new System.Drawing.Size(150, 50);
            this.BtnCancelar.TabIndex = 24;
            this.BtnCancelar.Text = "&Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.CancelButton_Renamed_Click);
            // 
            // QueImpresora
            // 
            this.QueImpresora.BackColor = System.Drawing.Color.White;
            this.QueImpresora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QueImpresora.Cursor = System.Windows.Forms.Cursors.Default;
            this.QueImpresora.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.QueImpresora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QueImpresora.ForeColor = System.Drawing.Color.DimGray;
            this.QueImpresora.Location = new System.Drawing.Point(9, 100);
            this.QueImpresora.Name = "QueImpresora";
            this.QueImpresora.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.QueImpresora.Size = new System.Drawing.Size(451, 45);
            this.QueImpresora.TabIndex = 28;
            this.QueImpresora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.White;
            this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.Label1.Location = new System.Drawing.Point(9, 42);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(451, 39);
            this.Label1.TabIndex = 27;
            this.Label1.Text = "IMPRIMIENDO CONSULTA";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _Label1_0
            // 
            this._Label1_0.AutoSize = true;
            this._Label1_0.BackColor = System.Drawing.Color.White;
            this._Label1_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._Label1_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Label1_0.ForeColor = System.Drawing.Color.Black;
            this._Label1_0.Location = new System.Drawing.Point(41, 16);
            this._Label1_0.Name = "_Label1_0";
            this._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._Label1_0.Size = new System.Drawing.Size(380, 16);
            this._Label1_0.TabIndex = 25;
            this._Label1_0.Text = "PRESIONE ACEPTAR CUANDO ESTE LISTA LA IMPRESION";
            this._Label1_0.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BtnPagina
            // 
            this.BtnPagina.BackColor = System.Drawing.Color.DimGray;
            this.BtnPagina.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnPagina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPagina.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPagina.ForeColor = System.Drawing.Color.White;
            this.BtnPagina.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnPagina.Location = new System.Drawing.Point(67, 148);
            this.BtnPagina.Name = "BtnPagina";
            this.BtnPagina.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnPagina.Size = new System.Drawing.Size(150, 30);
            this.BtnPagina.TabIndex = 29;
            this.BtnPagina.Text = "   C&onfiguración";
            this.BtnPagina.UseVisualStyleBackColor = false;
            this.BtnPagina.Click += new System.EventHandler(this.BtnPropiedadesImpresora_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // PrintDocument1
            // 
            this.PrintDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // PrintPreviewDialog1
            // 
            this.PrintPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.PrintPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.PrintPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.PrintPreviewDialog1.Enabled = true;
            this.PrintPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("PrintPreviewDialog1.Icon")));
            this.PrintPreviewDialog1.Name = "PrintPreviewDialog1";
            this.PrintPreviewDialog1.Visible = false;
            // 
            // ImprimeConsulta
            // 
            this.AcceptButton = this.BtnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.BtnCancelar;
            this.ClientSize = new System.Drawing.Size(626, 181);
            this.ControlBox = false;
            this.Controls.Add(this.BtnPrevisual);
            this.Controls.Add(this.BtnImpresora);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.QueImpresora);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this._Label1_0);
            this.Controls.Add(this.BtnPagina);
            this.Name = "ImprimeConsulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ToolTip ToolTip1;
        public System.Windows.Forms.Button BtnPrevisual;
        public System.Windows.Forms.Button BtnImpresora;
        public System.Windows.Forms.Button BtnAceptar;
        public System.Windows.Forms.Button BtnCancelar;
        public System.Windows.Forms.Label QueImpresora;
        public System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Label _Label1_0;
        public System.Windows.Forms.Button BtnPagina;
        private System.Windows.Forms.PageSetupDialog PageSetupDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument PrintDocument1;
        private System.Windows.Forms.PrintPreviewDialog PrintPreviewDialog1;
    }
}

