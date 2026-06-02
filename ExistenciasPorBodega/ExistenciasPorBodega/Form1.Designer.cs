namespace ExistenciasPorBodega
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.actualizartoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.actualizartoolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.salirtoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.mostrarreportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.contenerdorsplitContainer = new System.Windows.Forms.SplitContainer();
            this.panelOpciones = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contenerdorsplitContainer)).BeginInit();
            this.contenerdorsplitContainer.Panel1.SuspendLayout();
            this.contenerdorsplitContainer.Panel2.SuspendLayout();
            this.contenerdorsplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actualizartoolStripButton,
            this.actualizartoolStripButton6,
            this.toolStripSeparator2,
            this.salirtoolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(808, 38);
            this.toolStrip1.TabIndex = 23;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // actualizartoolStripButton
            // 
            this.actualizartoolStripButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.actualizartoolStripButton.Image = global::ExistenciasPorBodega.Properties.Resources.propiedades;
            this.actualizartoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.actualizartoolStripButton.Name = "actualizartoolStripButton";
            this.actualizartoolStripButton.Size = new System.Drawing.Size(61, 35);
            this.actualizartoolStripButton.Text = "Opciones";
            this.actualizartoolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.actualizartoolStripButton.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // actualizartoolStripButton6
            // 
            this.actualizartoolStripButton6.ForeColor = System.Drawing.Color.White;
            this.actualizartoolStripButton6.Image = global::ExistenciasPorBodega.Properties.Resources.actualizar;
            this.actualizartoolStripButton6.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.actualizartoolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.actualizartoolStripButton6.Name = "actualizartoolStripButton6";
            this.actualizartoolStripButton6.Size = new System.Drawing.Size(63, 35);
            this.actualizartoolStripButton6.Text = "Actualizar";
            this.actualizartoolStripButton6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.actualizartoolStripButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.actualizartoolStripButton6.Click += new System.EventHandler(this.actualizartoolStripButton6_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // salirtoolStripButton
            // 
            this.salirtoolStripButton.ForeColor = System.Drawing.Color.White;
            this.salirtoolStripButton.Image = global::ExistenciasPorBodega.Properties.Resources.EXit;
            this.salirtoolStripButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.salirtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.salirtoolStripButton.Name = "salirtoolStripButton";
            this.salirtoolStripButton.Size = new System.Drawing.Size(33, 35);
            this.salirtoolStripButton.Text = "Salir";
            this.salirtoolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.salirtoolStripButton.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // mostrarreportViewer
            // 
            this.mostrarreportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mostrarreportViewer.Location = new System.Drawing.Point(0, 0);
            this.mostrarreportViewer.Margin = new System.Windows.Forms.Padding(0);
            this.mostrarreportViewer.Name = "mostrarreportViewer";
            this.mostrarreportViewer.Size = new System.Drawing.Size(621, 415);
            this.mostrarreportViewer.TabIndex = 24;
            // 
            // contenerdorsplitContainer
            // 
            this.contenerdorsplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.contenerdorsplitContainer.Location = new System.Drawing.Point(3, 36);
            this.contenerdorsplitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.contenerdorsplitContainer.Name = "contenerdorsplitContainer";
            // 
            // contenerdorsplitContainer.Panel1
            // 
            this.contenerdorsplitContainer.Panel1.Controls.Add(this.panelOpciones);
            // 
            // contenerdorsplitContainer.Panel2
            // 
            this.contenerdorsplitContainer.Panel2.Controls.Add(this.mostrarreportViewer);
            this.contenerdorsplitContainer.Size = new System.Drawing.Size(805, 415);
            this.contenerdorsplitContainer.SplitterDistance = 183;
            this.contenerdorsplitContainer.SplitterWidth = 1;
            this.contenerdorsplitContainer.TabIndex = 25;
            // 
            // panelOpciones
            // 
            this.panelOpciones.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelOpciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOpciones.Location = new System.Drawing.Point(0, 0);
            this.panelOpciones.Margin = new System.Windows.Forms.Padding(0);
            this.panelOpciones.Name = "panelOpciones";
            this.panelOpciones.Size = new System.Drawing.Size(183, 415);
            this.panelOpciones.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(808, 447);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.contenerdorsplitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Existencias de Articulos Por Bodegas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contenerdorsplitContainer.Panel1.ResumeLayout(false);
            this.contenerdorsplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contenerdorsplitContainer)).EndInit();
            this.contenerdorsplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton actualizartoolStripButton;
        private System.Windows.Forms.ToolStripButton actualizartoolStripButton6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton salirtoolStripButton;
        private Microsoft.Reporting.WinForms.ReportViewer mostrarreportViewer;
        private System.Windows.Forms.SplitContainer contenerdorsplitContainer;
        private System.Windows.Forms.Panel panelOpciones;
    }
}

