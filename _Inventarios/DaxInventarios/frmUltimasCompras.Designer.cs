namespace ArtInvent
{
    partial class frmUltimasCompras
    {
        private System.ComponentModel.IContainer components = null;

        // Controles del formulario
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblCodigoValor;
        private System.Windows.Forms.Label lblDescripcionValor;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dgvCompras;
        private System.Windows.Forms.Label lblTotalRegistros;
        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Panel panelInferior;
        private System.Windows.Forms.Label lblDecimales;

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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblCodigoValor = new System.Windows.Forms.Label();
            this.lblDescripcionValor = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dgvCompras = new System.Windows.Forms.DataGridView();
            this.lblTotalRegistros = new System.Windows.Forms.Label();
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.lblPorcentajeIVA = new System.Windows.Forms.Label();
            this.lblInfoDecimales = new System.Windows.Forms.Label();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.panelInferior = new System.Windows.Forms.Panel();
            this.lblDecimales = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).BeginInit();
            this.panelSuperior.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.panelInferior.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(102)))));
            this.lblTitulo.Location = new System.Drawing.Point(10, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(274, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Últimas compras por artículo";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblCodigo.Location = new System.Drawing.Point(12, 38);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(67, 18);
            this.lblCodigo.TabIndex = 1;
            this.lblCodigo.Text = "Código:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblDescripcion.Location = new System.Drawing.Point(12, 60);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(103, 18);
            this.lblDescripcion.TabIndex = 3;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // lblCodigoValor
            // 
            this.lblCodigoValor.AutoSize = true;
            this.lblCodigoValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblCodigoValor.ForeColor = System.Drawing.Color.Blue;
            this.lblCodigoValor.Location = new System.Drawing.Point(87, 38);
            this.lblCodigoValor.Name = "lblCodigoValor";
            this.lblCodigoValor.Size = new System.Drawing.Size(17, 18);
            this.lblCodigoValor.TabIndex = 2;
            this.lblCodigoValor.Text = "0";
            // 
            // lblDescripcionValor
            // 
            this.lblDescripcionValor.AutoSize = true;
            this.lblDescripcionValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblDescripcionValor.Location = new System.Drawing.Point(130, 60);
            this.lblDescripcionValor.Name = "lblDescripcionValor";
            this.lblDescripcionValor.Size = new System.Drawing.Size(0, 18);
            this.lblDescripcionValor.TabIndex = 4;
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(12, 8);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(100, 32);
            this.btnActualizar.TabIndex = 0;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(738, 8);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 32);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dgvCompras
            // 
            this.dgvCompras.AllowUserToAddRows = false;
            this.dgvCompras.AllowUserToDeleteRows = false;
            this.dgvCompras.BackgroundColor = System.Drawing.Color.White;
            this.dgvCompras.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCompras.Location = new System.Drawing.Point(143, 10);
            this.dgvCompras.Name = "dgvCompras";
            this.dgvCompras.ReadOnly = true;
            this.dgvCompras.RowHeadersVisible = false;
            this.dgvCompras.RowHeadersWidth = 51;
            this.dgvCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCompras.Size = new System.Drawing.Size(1181, 315);
            this.dgvCompras.TabIndex = 0;
            this.dgvCompras.DoubleClick += new System.EventHandler(this.dgvCompras_DoubleClick);
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.AutoSize = true;
            this.lblTotalRegistros.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTotalRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalRegistros.Location = new System.Drawing.Point(10, 10);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblTotalRegistros.Size = new System.Drawing.Size(133, 22);
            this.lblTotalRegistros.TabIndex = 1;
            this.lblTotalRegistros.Text = "Total registros: 0";
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelSuperior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSuperior.Controls.Add(this.lblPorcentajeIVA);
            this.panelSuperior.Controls.Add(this.lblInfoDecimales);
            this.panelSuperior.Controls.Add(this.lblTitulo);
            this.panelSuperior.Controls.Add(this.lblCodigo);
            this.panelSuperior.Controls.Add(this.lblCodigoValor);
            this.panelSuperior.Controls.Add(this.lblDescripcion);
            this.panelSuperior.Controls.Add(this.lblDescripcionValor);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(1334, 85);
            this.panelSuperior.TabIndex = 0;
            // 
            // lblPorcentajeIVA
            // 
            this.lblPorcentajeIVA.AutoSize = true;
            this.lblPorcentajeIVA.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblPorcentajeIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPorcentajeIVA.ForeColor = System.Drawing.Color.Blue;
            this.lblPorcentajeIVA.Location = new System.Drawing.Point(1150, 0);
            this.lblPorcentajeIVA.Name = "lblPorcentajeIVA";
            this.lblPorcentajeIVA.Padding = new System.Windows.Forms.Padding(0, 5, 10, 0);
            this.lblPorcentajeIVA.Size = new System.Drawing.Size(83, 22);
            this.lblPorcentajeIVA.TabIndex = 6;
            this.lblPorcentajeIVA.Text = "IVA: 15%";
            this.lblPorcentajeIVA.Visible = false;
            // 
            // lblInfoDecimales
            // 
            this.lblInfoDecimales.AutoSize = true;
            this.lblInfoDecimales.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblInfoDecimales.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblInfoDecimales.ForeColor = System.Drawing.Color.Gray;
            this.lblInfoDecimales.Location = new System.Drawing.Point(1233, 0);
            this.lblInfoDecimales.Name = "lblInfoDecimales";
            this.lblInfoDecimales.Padding = new System.Windows.Forms.Padding(0, 5, 10, 0);
            this.lblInfoDecimales.Size = new System.Drawing.Size(99, 22);
            this.lblInfoDecimales.TabIndex = 5;
            this.lblInfoDecimales.Text = "Decimales: 6";
            // 
            // panelBotones
            // 
            this.panelBotones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelBotones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBotones.Controls.Add(this.btnActualizar);
            this.panelBotones.Controls.Add(this.btnCerrar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Location = new System.Drawing.Point(0, 420);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(1334, 50);
            this.panelBotones.TabIndex = 1;
            // 
            // panelInferior
            // 
            this.panelInferior.Controls.Add(this.dgvCompras);
            this.panelInferior.Controls.Add(this.lblTotalRegistros);
            this.panelInferior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInferior.Location = new System.Drawing.Point(0, 85);
            this.panelInferior.Name = "panelInferior";
            this.panelInferior.Padding = new System.Windows.Forms.Padding(10);
            this.panelInferior.Size = new System.Drawing.Size(1334, 335);
            this.panelInferior.TabIndex = 2;
            // 
            // lblDecimales
            // 
            this.lblDecimales.AutoSize = true;
            this.lblDecimales.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDecimales.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblDecimales.ForeColor = System.Drawing.Color.Gray;
            this.lblDecimales.Location = new System.Drawing.Point(680, 303);
            this.lblDecimales.Name = "lblDecimales";
            this.lblDecimales.Padding = new System.Windows.Forms.Padding(0, 5, 10, 0);
            this.lblDecimales.Size = new System.Drawing.Size(80, 18);
            this.lblDecimales.TabIndex = 3;
            this.lblDecimales.Text = "Decimales: 2";
            // 
            // frmUltimasCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 470);
            this.Controls.Add(this.panelInferior);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelSuperior);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUltimasCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Últimas compras por artículo";
            this.Load += new System.EventHandler(this.frmUltimasCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).EndInit();
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            this.panelInferior.ResumeLayout(false);
            this.panelInferior.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblPorcentajeIVA;
        private System.Windows.Forms.Label lblInfoDecimales;
    }
}