namespace daxContaDoc
{
    partial class frmVisContab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisContab));
            this.malla = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labMensaje = new System.Windows.Forms.Label();
            this.ToolStrip3 = new System.Windows.Forms.ToolStrip();
            this.btnRecontabiliza = new System.Windows.Forms.ToolStripButton();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.btnAceptar = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.malla)).BeginInit();
            this.panel1.SuspendLayout();
            this.ToolStrip3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // malla
            // 
            this.malla.AllowUserToAddRows = false;
            this.malla.AllowUserToResizeColumns = false;
            this.malla.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.malla.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.malla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.malla.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.malla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.malla.ColumnHeadersHeight = 20;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.malla.DefaultCellStyle = dataGridViewCellStyle3;
            this.malla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.malla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.malla.EnableHeadersVisualStyles = false;
            this.malla.Location = new System.Drawing.Point(0, 44);
            this.malla.Name = "malla";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.malla.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.malla.RowHeadersWidth = 20;
            this.malla.Size = new System.Drawing.Size(977, 384);
            this.malla.StandardTab = true;
            this.malla.TabIndex = 23;
            this.malla.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
            this.malla.KeyDown += new System.Windows.Forms.KeyEventHandler(this.malla_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.labMensaje);
            this.panel1.Controls.Add(this.ToolStrip3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(977, 44);
            this.panel1.TabIndex = 24;
            // 
            // labMensaje
            // 
            this.labMensaje.BackColor = System.Drawing.Color.SteelBlue;
            this.labMensaje.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMensaje.ForeColor = System.Drawing.Color.DarkOrange;
            this.labMensaje.Location = new System.Drawing.Point(642, 4);
            this.labMensaje.Name = "labMensaje";
            this.labMensaje.Size = new System.Drawing.Size(271, 34);
            this.labMensaje.TabIndex = 4;
            this.labMensaje.Text = "Sin contabilidad generada";
            this.labMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ToolStrip3
            // 
            this.ToolStrip3.AutoSize = false;
            this.ToolStrip3.BackColor = System.Drawing.Color.SteelBlue;
            this.ToolStrip3.CanOverflow = false;
            this.ToolStrip3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip3.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.ToolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRecontabiliza,
            this.btnCancelar,
            this.btnAceptar});
            this.ToolStrip3.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ToolStrip3.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip3.Name = "ToolStrip3";
            this.ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStrip3.Size = new System.Drawing.Size(977, 44);
            this.ToolStrip3.TabIndex = 2;
            this.ToolStrip3.Text = "ToolStrip3";
            // 
            // btnRecontabiliza
            // 
            this.btnRecontabiliza.ForeColor = System.Drawing.Color.White;
            this.btnRecontabiliza.Image = ((System.Drawing.Image)(resources.GetObject("btnRecontabiliza.Image")));
            this.btnRecontabiliza.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRecontabiliza.Name = "btnRecontabiliza";
            this.btnRecontabiliza.Size = new System.Drawing.Size(218, 41);
            this.btnRecontabiliza.Text = "Recontabilizar automáticamente";
            this.btnRecontabiliza.ToolTipText = "Elimina la contabilidad actual y recontabiliza ";
            this.btnRecontabiliza.Click += new System.EventHandler(this.btnRecontabiliza_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(93, 41);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.ToolTipText = "No hace ningún cambio en la contabilización y regresa al documento";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(88, 41);
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.ToolTipText = "Registra la contabilizacion actual y regresa al documento";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 428);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(977, 34);
            this.panel2.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(977, 34);
            this.label2.TabIndex = 4;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmVisContab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(977, 462);
            this.Controls.Add(this.malla);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVisContab";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "VISUALIZADOR DE CONTABILIZACION DE DOCUMENTOS";
            this.Load += new System.EventHandler(this.frmVisContab_Load);
            ((System.ComponentModel.ISupportInitialize)(this.malla)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ToolStrip3.ResumeLayout(false);
            this.ToolStrip3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView malla;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.ToolStrip ToolStrip3;
        internal System.Windows.Forms.ToolStripButton btnRecontabiliza;
        internal System.Windows.Forms.ToolStripButton btnCancelar;
        internal System.Windows.Forms.ToolStripButton btnAceptar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labMensaje;
    }
}