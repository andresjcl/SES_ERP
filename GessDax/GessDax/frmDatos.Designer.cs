namespace GessDax
{
    partial class frmDatos
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.camposSeleccionados = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.datosDisponibles = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNombreReporte = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipoDatos = new System.Windows.Forms.ComboBox();
            this.cancelar = new System.Windows.Forms.Button();
            this.Aceptar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.camposSeleccionados);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 300);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos seleccionados";
            // 
            // camposSeleccionados
            // 
            this.camposSeleccionados.BackColor = System.Drawing.Color.LightSteelBlue;
            this.camposSeleccionados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.camposSeleccionados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.camposSeleccionados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.camposSeleccionados.FormattingEnabled = true;
            this.camposSeleccionados.ItemHeight = 16;
            this.camposSeleccionados.Location = new System.Drawing.Point(3, 18);
            this.camposSeleccionados.Name = "camposSeleccionados";
            this.camposSeleccionados.Size = new System.Drawing.Size(214, 279);
            this.camposSeleccionados.TabIndex = 3;
            this.camposSeleccionados.KeyDown += new System.Windows.Forms.KeyEventHandler(this.camposSeleccionados_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.datosDisponibles);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(220, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(719, 300);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos disponibles";
            // 
            // datosDisponibles
            // 
            this.datosDisponibles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.datosDisponibles.ColumnWidth = 160;
            this.datosDisponibles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datosDisponibles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datosDisponibles.FormattingEnabled = true;
            this.datosDisponibles.ItemHeight = 15;
            this.datosDisponibles.Location = new System.Drawing.Point(3, 18);
            this.datosDisponibles.MultiColumn = true;
            this.datosDisponibles.Name = "datosDisponibles";
            this.datosDisponibles.Size = new System.Drawing.Size(713, 279);
            this.datosDisponibles.TabIndex = 3;
            this.datosDisponibles.DoubleClick += new System.EventHandler(this.datosDisponibles_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.txtNombreReporte);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbTipoDatos);
            this.panel1.Controls.Add(this.cancelar);
            this.panel1.Controls.Add(this.Aceptar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(939, 43);
            this.panel1.TabIndex = 8;
            // 
            // txtNombreReporte
            // 
            this.txtNombreReporte.Location = new System.Drawing.Point(327, 19);
            this.txtNombreReporte.MaxLength = 148;
            this.txtNombreReporte.Name = "txtNombreReporte";
            this.txtNombreReporte.Size = new System.Drawing.Size(296, 20);
            this.txtNombreReporte.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(365, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Nombre del Reporte";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tipo de datos :";
            // 
            // cmbTipoDatos
            // 
            this.cmbTipoDatos.BackColor = System.Drawing.Color.White;
            this.cmbTipoDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoDatos.ForeColor = System.Drawing.Color.Black;
            this.cmbTipoDatos.FormattingEnabled = true;
            this.cmbTipoDatos.Location = new System.Drawing.Point(9, 15);
            this.cmbTipoDatos.Name = "cmbTipoDatos";
            this.cmbTipoDatos.Size = new System.Drawing.Size(311, 24);
            this.cmbTipoDatos.TabIndex = 9;
            this.cmbTipoDatos.SelectedIndexChanged += new System.EventHandler(this.cmbTipoDatos_SelectedIndexChanged);
            // 
            // cancelar
            // 
            this.cancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cancelar.BackColor = System.Drawing.Color.SteelBlue;
            this.cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelar.ForeColor = System.Drawing.Color.White;
            this.cancelar.Location = new System.Drawing.Point(747, 9);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(90, 30);
            this.cancelar.TabIndex = 8;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = false;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // Aceptar
            // 
            this.Aceptar.BackColor = System.Drawing.Color.SteelBlue;
            this.Aceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Aceptar.ForeColor = System.Drawing.Color.White;
            this.Aceptar.Location = new System.Drawing.Point(840, 8);
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(90, 30);
            this.Aceptar.TabIndex = 7;
            this.Aceptar.Text = "Aceptar";
            this.Aceptar.UseVisualStyleBackColor = false;
            this.Aceptar.Click += new System.EventHandler(this.Aceptar_Click);
            // 
            // frmDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 343);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "frmDatos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SELECCION DE DATOS PARA ANALISIS";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox camposSeleccionados;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox datosDisponibles;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Button Aceptar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipoDatos;
        private System.Windows.Forms.TextBox txtNombreReporte;
        private System.Windows.Forms.Label label2;

    }
}