
namespace BuscadorDocumentos
{
    partial class BuscCajaChica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscCajaChica));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.btnBuscar = new System.Windows.Forms.ToolStripButton();
            this.btnAceptar = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClienteCod = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.malla = new System.Windows.Forms.DataGridView();
            this.txtClienteCod = new System.Windows.Forms.TextBox();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.txtFechaFin = new System.Windows.Forms.DateTimePicker();
            this.txtFechaIn = new System.Windows.Forms.DateTimePicker();
            this.cboSucursal = new System.Windows.Forms.ComboBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtClienteNombre = new System.Windows.Forms.TextBox();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.malla)).BeginInit();
            this.Panel1.SuspendLayout();
            this.TableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 44);
            this.btnSalir.Text = "   Salir   ";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(56, 44);
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(65, 44);
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 47);
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.BackColor = System.Drawing.Color.DimGray;
            this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip1.ImageScalingSize = new System.Drawing.Size(24, 32);
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripSeparator2,
            this.btnAceptar,
            this.btnBuscar,
            this.ToolStripSeparator3,
            this.btnSalir});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(1067, 47);
            this.ToolStrip1.TabIndex = 1;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.ForeColor = System.Drawing.Color.White;
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(6, 47);
            // 
            // btnClienteCod
            // 
            this.btnClienteCod.FlatAppearance.BorderSize = 0;
            this.btnClienteCod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClienteCod.Image = ((System.Drawing.Image)(resources.GetObject("btnClienteCod.Image")));
            this.btnClienteCod.Location = new System.Drawing.Point(113, 37);
            this.btnClienteCod.Margin = new System.Windows.Forms.Padding(4);
            this.btnClienteCod.Name = "btnClienteCod";
            this.btnClienteCod.Size = new System.Drawing.Size(28, 25);
            this.btnClienteCod.TabIndex = 39;
            this.btnClienteCod.UseVisualStyleBackColor = true;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(8, 39);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(99, 17);
            this.Label3.TabIndex = 37;
            this.Label3.Text = "Responsable :";
            // 
            // malla
            // 
            this.malla.AllowUserToAddRows = false;
            this.malla.AllowUserToDeleteRows = false;
            this.malla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.malla.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.malla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.malla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.malla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.malla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.malla.EnableHeadersVisualStyles = false;
            this.malla.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.malla.Location = new System.Drawing.Point(0, 122);
            this.malla.Margin = new System.Windows.Forms.Padding(4);
            this.malla.Name = "malla";
            this.malla.ReadOnly = true;
            this.malla.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.malla.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.malla.RowHeadersWidth = 20;
            this.malla.ShowCellToolTips = false;
            this.malla.ShowEditingIcon = false;
            this.malla.Size = new System.Drawing.Size(1067, 432);
            this.malla.TabIndex = 12;
            this.malla.DoubleClick += new System.EventHandler(this.malla_DoubleClick);
            // 
            // txtClienteCod
            // 
            this.txtClienteCod.Location = new System.Drawing.Point(142, 38);
            this.txtClienteCod.Margin = new System.Windows.Forms.Padding(4);
            this.txtClienteCod.Name = "txtClienteCod";
            this.txtClienteCod.Size = new System.Drawing.Size(128, 22);
            this.txtClienteCod.TabIndex = 5;
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.Gray;
            this.Panel1.Controls.Add(this.txtFechaFin);
            this.Panel1.Controls.Add(this.txtFechaIn);
            this.Panel1.Controls.Add(this.cboSucursal);
            this.Panel1.Controls.Add(this.Label7);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Controls.Add(this.txtClienteCod);
            this.Panel1.Controls.Add(this.txtClienteNombre);
            this.Panel1.Controls.Add(this.btnClienteCod);
            this.Panel1.Controls.Add(this.Label3);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.ForeColor = System.Drawing.Color.White;
            this.Panel1.Location = new System.Drawing.Point(0, 47);
            this.Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1067, 75);
            this.Panel1.TabIndex = 11;
            // 
            // txtFechaFin
            // 
            this.txtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFechaFin.Location = new System.Drawing.Point(216, 8);
            this.txtFechaFin.Margin = new System.Windows.Forms.Padding(4);
            this.txtFechaFin.Name = "txtFechaFin";
            this.txtFechaFin.Size = new System.Drawing.Size(119, 22);
            this.txtFechaFin.TabIndex = 76;
            this.txtFechaFin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFechaFin_KeyDown);
            // 
            // txtFechaIn
            // 
            this.txtFechaIn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFechaIn.Location = new System.Drawing.Point(89, 8);
            this.txtFechaIn.Margin = new System.Windows.Forms.Padding(4);
            this.txtFechaIn.Name = "txtFechaIn";
            this.txtFechaIn.Size = new System.Drawing.Size(119, 22);
            this.txtFechaIn.TabIndex = 75;
            this.txtFechaIn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFechaFin_KeyDown);
            // 
            // cboSucursal
            // 
            this.cboSucursal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSucursal.FormattingEnabled = true;
            this.cboSucursal.Location = new System.Drawing.Point(808, 36);
            this.cboSucursal.Margin = new System.Windows.Forms.Padding(4);
            this.cboSucursal.Name = "cboSucursal";
            this.cboSucursal.Size = new System.Drawing.Size(249, 24);
            this.cboSucursal.TabIndex = 68;
            this.cboSucursal.SelectedValueChanged += new System.EventHandler(this.cboSucursal_SelectedValueChanged);
            // 
            // Label7
            // 
            this.Label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(728, 41);
            this.Label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(67, 17);
            this.Label7.TabIndex = 71;
            this.Label7.Text = "Sucursal:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(13, 12);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(65, 17);
            this.Label1.TabIndex = 53;
            this.Label1.Text = "Período :";
            // 
            // txtClienteNombre
            // 
            this.txtClienteNombre.Location = new System.Drawing.Point(273, 38);
            this.txtClienteNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtClienteNombre.Name = "txtClienteNombre";
            this.txtClienteNombre.Size = new System.Drawing.Size(396, 22);
            this.txtClienteNombre.TabIndex = 6;
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.TableLayoutPanel1.ColumnCount = 1;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.35294F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.64706F));
            this.TableLayoutPanel1.Controls.Add(this.ToolStrip1, 0, 0);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(1067, 47);
            this.TableLayoutPanel1.TabIndex = 10;
            // 
            // BuscCajaChica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.ControlBox = false;
            this.Controls.Add(this.malla);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BuscCajaChica";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscador de documentos caja chica";
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.malla)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.TableLayoutPanel1.ResumeLayout(false);
            this.TableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ToolStripButton btnSalir;
        internal System.Windows.Forms.ToolStripButton btnBuscar;
        internal System.Windows.Forms.ToolStripButton btnAceptar;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
        internal System.Windows.Forms.Button btnClienteCod;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.DataGridView malla;
        internal System.Windows.Forms.TextBox txtClienteCod;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.DateTimePicker txtFechaFin;
        internal System.Windows.Forms.DateTimePicker txtFechaIn;
        internal System.Windows.Forms.ComboBox cboSucursal;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtClienteNombre;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
    }
}

