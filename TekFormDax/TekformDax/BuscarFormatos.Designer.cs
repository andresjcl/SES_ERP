namespace TekFormDax
{
    partial class BuscarFormatos
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
            this.components = new System.ComponentModel.Container();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btncancelarbusca = new System.Windows.Forms.Button();
            this.btnbuscar = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.malla = new System.Windows.Forms.DataGridView();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.malla)).BeginInit();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btncancelarbusca
            // 
            this.btncancelarbusca.BackColor = System.Drawing.Color.SteelBlue;
            this.btncancelarbusca.Cursor = System.Windows.Forms.Cursors.Default;
            this.btncancelarbusca.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btncancelarbusca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncancelarbusca.ForeColor = System.Drawing.Color.White;
            this.btncancelarbusca.Location = new System.Drawing.Point(197, 15);
            this.btncancelarbusca.Name = "btncancelarbusca";
            this.btncancelarbusca.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btncancelarbusca.Size = new System.Drawing.Size(69, 25);
            this.btncancelarbusca.TabIndex = 6;
            this.btncancelarbusca.Text = "&Cancelar";
            this.ToolTip1.SetToolTip(this.btncancelarbusca, "Elija para ingresar un nuevo nivel");
            this.btncancelarbusca.UseVisualStyleBackColor = false;
            this.btncancelarbusca.Click += new System.EventHandler(this.btncancelarbusca_Click);
            // 
            // btnbuscar
            // 
            this.btnbuscar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnbuscar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnbuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscar.ForeColor = System.Drawing.Color.White;
            this.btnbuscar.Location = new System.Drawing.Point(106, 15);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnbuscar.Size = new System.Drawing.Size(69, 25);
            this.btnbuscar.TabIndex = 5;
            this.btnbuscar.Text = "&Aceptar";
            this.ToolTip1.SetToolTip(this.btnbuscar, "Realiza la busqueda");
            this.btnbuscar.UseVisualStyleBackColor = false;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.Panel1.Controls.Add(this.txtnombre);
            this.Panel1.Controls.Add(this.Label10);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(305, 43);
            this.Panel1.TabIndex = 10;
            // 
            // txtnombre
            // 
            this.txtnombre.AcceptsReturn = true;
            this.txtnombre.BackColor = System.Drawing.SystemColors.Window;
            this.txtnombre.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtnombre.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtnombre.Location = new System.Drawing.Point(58, 17);
            this.txtnombre.MaxLength = 30;
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtnombre.Size = new System.Drawing.Size(244, 20);
            this.txtnombre.TabIndex = 6;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.BackColor = System.Drawing.Color.Transparent;
            this.Label10.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label10.ForeColor = System.Drawing.Color.White;
            this.Label10.Location = new System.Drawing.Point(13, 19);
            this.Label10.Name = "Label10";
            this.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label10.Size = new System.Drawing.Size(40, 13);
            this.Label10.TabIndex = 7;
            this.Label10.Text = "Buscar";
            // 
            // malla
            // 
            this.malla.BackgroundColor = System.Drawing.Color.White;
            this.malla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.malla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.malla.Location = new System.Drawing.Point(0, 0);
            this.malla.Name = "malla";
            this.malla.Size = new System.Drawing.Size(305, 279);
            this.malla.TabIndex = 9;
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.Panel2.Controls.Add(this.btncancelarbusca);
            this.Panel2.Controls.Add(this.btnbuscar);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel2.Location = new System.Drawing.Point(0, 279);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(305, 55);
            this.Panel2.TabIndex = 11;
            // 
            // BuscarFormatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btncancelarbusca;
            this.ClientSize = new System.Drawing.Size(305, 334);
            this.ControlBox = false;
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.malla);
            this.Controls.Add(this.Panel2);
            this.Name = "BuscarFormatos";
            this.Text = "BUSCAR FORMATOS DE IMPRESIÓN";
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.malla)).EndInit();
            this.Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ToolTip ToolTip1;
        public System.Windows.Forms.Button btncancelarbusca;
        public System.Windows.Forms.Button btnbuscar;
        internal System.Windows.Forms.Panel Panel1;
        public System.Windows.Forms.TextBox txtnombre;
        public System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.DataGridView malla;
        internal System.Windows.Forms.Panel Panel2;
    }
}