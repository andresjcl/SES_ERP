namespace ArtInvent
{
    partial class FrmErrores
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvErrores;
        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Panel panelInferior;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblSeleccionados;
        private System.Windows.Forms.Button btnJustificarTodos;
        private System.Windows.Forms.Button btnEliminarSeleccionados;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.Button btnCopiar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Button btnCerrar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvErrores = new System.Windows.Forms.DataGridView();
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblSeleccionados = new System.Windows.Forms.Label();
            this.panelInferior = new System.Windows.Forms.Panel();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.btnJustificarTodos = new System.Windows.Forms.Button();
            this.btnEliminarSeleccionados = new System.Windows.Forms.Button();
            this.btnCopiar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrores)).BeginInit();
            this.panelSuperior.SuspendLayout();
            this.panelInferior.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvErrores
            // 
            this.dgvErrores.AllowUserToAddRows = false;
            this.dgvErrores.AllowUserToDeleteRows = false;
            this.dgvErrores.BackgroundColor = System.Drawing.Color.White;
            this.dgvErrores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvErrores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvErrores.Location = new System.Drawing.Point(0, 40);
            this.dgvErrores.Name = "dgvErrores";
            this.dgvErrores.ReadOnly = true;
            this.dgvErrores.RowHeadersVisible = false;
            this.dgvErrores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvErrores.Size = new System.Drawing.Size(1100, 440);
            this.dgvErrores.TabIndex = 0;
            this.dgvErrores.SelectionChanged += new System.EventHandler(this.dgvErrores_SelectionChanged);
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelSuperior.Controls.Add(this.lblTotal);
            this.panelSuperior.Controls.Add(this.lblSeleccionados);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(1100, 40);
            this.panelSuperior.TabIndex = 1;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(12, 10);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(117, 17);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Total de errores: 0";
            // 
            // lblSeleccionados
            // 
            this.lblSeleccionados.AutoSize = true;
            this.lblSeleccionados.Font = new System.Drawing.Font("Calibri", 10F);
            this.lblSeleccionados.ForeColor = System.Drawing.Color.Yellow;
            this.lblSeleccionados.Location = new System.Drawing.Point(200, 10);
            this.lblSeleccionados.Name = "lblSeleccionados";
            this.lblSeleccionados.Size = new System.Drawing.Size(95, 17);
            this.lblSeleccionados.TabIndex = 1;
            this.lblSeleccionados.Text = "Seleccionados: 0";
            // 
            // panelInferior
            // 
            this.panelInferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelInferior.Controls.Add(this.btnRefrescar);
            this.panelInferior.Controls.Add(this.btnJustificarTodos);
            this.panelInferior.Controls.Add(this.btnEliminarSeleccionados);
            this.panelInferior.Controls.Add(this.btnCopiar);
            this.panelInferior.Controls.Add(this.btnImprimir);
            this.panelInferior.Controls.Add(this.btnExportarExcel);
            this.panelInferior.Controls.Add(this.btnCerrar);
            this.panelInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelInferior.Location = new System.Drawing.Point(0, 480);
            this.panelInferior.Name = "panelInferior";
            this.panelInferior.Size = new System.Drawing.Size(1100, 60);
            this.panelInferior.TabIndex = 2;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnRefrescar.FlatAppearance.BorderSize = 0;
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.ForeColor = System.Drawing.Color.White;
            this.btnRefrescar.Location = new System.Drawing.Point(12, 10);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(100, 40);
            this.btnRefrescar.TabIndex = 0;
            this.btnRefrescar.Text = "🔄 Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = false;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // btnJustificarTodos
            // 
            this.btnJustificarTodos.BackColor = System.Drawing.Color.DarkGreen;
            this.btnJustificarTodos.FlatAppearance.BorderSize = 0;
            this.btnJustificarTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJustificarTodos.ForeColor = System.Drawing.Color.White;
            this.btnJustificarTodos.Location = new System.Drawing.Point(118, 10);
            this.btnJustificarTodos.Name = "btnJustificarTodos";
            this.btnJustificarTodos.Size = new System.Drawing.Size(130, 40);
            this.btnJustificarTodos.TabIndex = 1;
            this.btnJustificarTodos.Text = "✓ Justificar todos";
            this.btnJustificarTodos.UseVisualStyleBackColor = false;
            this.btnJustificarTodos.Click += new System.EventHandler(this.btnJustificarTodos_Click);
            // 
            // btnEliminarSeleccionados
            // 
            this.btnEliminarSeleccionados.BackColor = System.Drawing.Color.Crimson;
            this.btnEliminarSeleccionados.Enabled = false;
            this.btnEliminarSeleccionados.FlatAppearance.BorderSize = 0;
            this.btnEliminarSeleccionados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarSeleccionados.ForeColor = System.Drawing.Color.White;
            this.btnEliminarSeleccionados.Location = new System.Drawing.Point(254, 10);
            this.btnEliminarSeleccionados.Name = "btnEliminarSeleccionados";
            this.btnEliminarSeleccionados.Size = new System.Drawing.Size(150, 40);
            this.btnEliminarSeleccionados.TabIndex = 2;
            this.btnEliminarSeleccionados.Text = "🗑 Eliminar seleccionados";
            this.btnEliminarSeleccionados.UseVisualStyleBackColor = false;
            this.btnEliminarSeleccionados.Click += new System.EventHandler(this.btnEliminarSeleccionados_Click);
            // 
            // btnCopiar
            // 
            this.btnCopiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnCopiar.FlatAppearance.BorderSize = 0;
            this.btnCopiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopiar.ForeColor = System.Drawing.Color.White;
            this.btnCopiar.Location = new System.Drawing.Point(410, 10);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(100, 40);
            this.btnCopiar.TabIndex = 3;
            this.btnCopiar.Text = "📋 Copiar";
            this.btnCopiar.UseVisualStyleBackColor = false;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(516, 10);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(100, 40);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "🖨 Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(130)))), ((int)(((byte)(70)))));
            this.btnExportarExcel.FlatAppearance.BorderSize = 0;
            this.btnExportarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportarExcel.Location = new System.Drawing.Point(622, 10);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(150, 40);
            this.btnExportarExcel.TabIndex = 5;
            this.btnExportarExcel.Text = "📊 Exportar a CSV/Excel";
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(990, 10);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 40);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.Text = "✖ Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FrmErrores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1100, 540);
            this.Controls.Add(this.dgvErrores);
            this.Controls.Add(this.panelSuperior);
            this.Controls.Add(this.panelInferior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "FrmErrores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ANÁLISIS DE ERRORES - RECOSTEO";
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrores)).EndInit();
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            this.panelInferior.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}