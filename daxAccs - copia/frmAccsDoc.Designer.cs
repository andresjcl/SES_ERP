namespace daxAccs
{
    partial class frmAccsDoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccsDoc));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpOpciones = new System.Windows.Forms.GroupBox();
            this.chkCierreCaja = new System.Windows.Forms.CheckBox();
            this.chkIngresos = new System.Windows.Forms.CheckBox();
            this.chkEntregaExpress = new System.Windows.Forms.CheckBox();
            this.chkGastos = new System.Windows.Forms.CheckBox();
            this.grpAcciones = new System.Windows.Forms.GroupBox();
            this.chkAnular = new System.Windows.Forms.CheckBox();
            this.chkCrear = new System.Windows.Forms.CheckBox();
            this.chkModificar = new System.Windows.Forms.CheckBox();
            this.chkEliminar = new System.Windows.Forms.CheckBox();
            this.chkConsultar = new System.Windows.Forms.CheckBox();
            this.cmbDocumentos = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCopiarUsuario = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEliminaUsuario = new System.Windows.Forms.ToolStripButton();
            this.btnEliminarDocumento = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.malla = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.grpOpciones.SuspendLayout();
            this.grpAcciones.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.malla)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.grpOpciones);
            this.panel1.Controls.Add(this.grpAcciones);
            this.panel1.Controls.Add(this.cmbDocumentos);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 156);
            this.panel1.TabIndex = 0;
            // 
            // grpOpciones
            // 
            this.grpOpciones.Controls.Add(this.chkCierreCaja);
            this.grpOpciones.Controls.Add(this.chkIngresos);
            this.grpOpciones.Controls.Add(this.chkEntregaExpress);
            this.grpOpciones.Controls.Add(this.chkGastos);
            this.grpOpciones.ForeColor = System.Drawing.Color.White;
            this.grpOpciones.Location = new System.Drawing.Point(15, 98);
            this.grpOpciones.Name = "grpOpciones";
            this.grpOpciones.Size = new System.Drawing.Size(461, 48);
            this.grpOpciones.TabIndex = 15;
            this.grpOpciones.TabStop = false;
            this.grpOpciones.Text = "Opciones adicionals para facturas de punto de ventas";
            // 
            // chkCierreCaja
            // 
            this.chkCierreCaja.AutoSize = true;
            this.chkCierreCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCierreCaja.ForeColor = System.Drawing.Color.Black;
            this.chkCierreCaja.Location = new System.Drawing.Point(207, 21);
            this.chkCierreCaja.Name = "chkCierreCaja";
            this.chkCierreCaja.Size = new System.Drawing.Size(93, 21);
            this.chkCierreCaja.TabIndex = 12;
            this.chkCierreCaja.Text = "CierreCaja";
            this.chkCierreCaja.UseVisualStyleBackColor = true;
            // 
            // chkIngresos
            // 
            this.chkIngresos.AutoSize = true;
            this.chkIngresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIngresos.ForeColor = System.Drawing.Color.Black;
            this.chkIngresos.Location = new System.Drawing.Point(16, 21);
            this.chkIngresos.Name = "chkIngresos";
            this.chkIngresos.Size = new System.Drawing.Size(81, 21);
            this.chkIngresos.TabIndex = 10;
            this.chkIngresos.Text = "Ingresos";
            this.chkIngresos.UseVisualStyleBackColor = true;
            // 
            // chkEntregaExpress
            // 
            this.chkEntregaExpress.AutoSize = true;
            this.chkEntregaExpress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEntregaExpress.ForeColor = System.Drawing.Color.Black;
            this.chkEntregaExpress.Location = new System.Drawing.Point(304, 21);
            this.chkEntregaExpress.Name = "chkEntregaExpress";
            this.chkEntregaExpress.Size = new System.Drawing.Size(127, 21);
            this.chkEntregaExpress.TabIndex = 13;
            this.chkEntregaExpress.Text = "EntregaExpress";
            this.chkEntregaExpress.UseVisualStyleBackColor = true;
            // 
            // chkGastos
            // 
            this.chkGastos.AutoSize = true;
            this.chkGastos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGastos.ForeColor = System.Drawing.Color.Black;
            this.chkGastos.Location = new System.Drawing.Point(122, 21);
            this.chkGastos.Name = "chkGastos";
            this.chkGastos.Size = new System.Drawing.Size(72, 21);
            this.chkGastos.TabIndex = 11;
            this.chkGastos.Text = "Gastos";
            this.chkGastos.UseVisualStyleBackColor = true;
            // 
            // grpAcciones
            // 
            this.grpAcciones.Controls.Add(this.chkAnular);
            this.grpAcciones.Controls.Add(this.chkCrear);
            this.grpAcciones.Controls.Add(this.chkModificar);
            this.grpAcciones.Controls.Add(this.chkEliminar);
            this.grpAcciones.Controls.Add(this.chkConsultar);
            this.grpAcciones.ForeColor = System.Drawing.Color.White;
            this.grpAcciones.Location = new System.Drawing.Point(15, 38);
            this.grpAcciones.Name = "grpAcciones";
            this.grpAcciones.Size = new System.Drawing.Size(411, 53);
            this.grpAcciones.TabIndex = 14;
            this.grpAcciones.TabStop = false;
            this.grpAcciones.Text = "Acciones que puede efectuar con el documento";
            // 
            // chkAnular
            // 
            this.chkAnular.AutoSize = true;
            this.chkAnular.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAnular.ForeColor = System.Drawing.Color.Black;
            this.chkAnular.Location = new System.Drawing.Point(158, 24);
            this.chkAnular.Name = "chkAnular";
            this.chkAnular.Size = new System.Drawing.Size(68, 21);
            this.chkAnular.TabIndex = 6;
            this.chkAnular.Text = "Anular";
            this.chkAnular.UseVisualStyleBackColor = true;
            // 
            // chkCrear
            // 
            this.chkCrear.AutoSize = true;
            this.chkCrear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCrear.ForeColor = System.Drawing.Color.Black;
            this.chkCrear.Location = new System.Drawing.Point(10, 24);
            this.chkCrear.Name = "chkCrear";
            this.chkCrear.Size = new System.Drawing.Size(62, 21);
            this.chkCrear.TabIndex = 4;
            this.chkCrear.Text = "Crear";
            this.chkCrear.UseVisualStyleBackColor = true;
            // 
            // chkModificar
            // 
            this.chkModificar.AutoSize = true;
            this.chkModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkModificar.ForeColor = System.Drawing.Color.Black;
            this.chkModificar.Location = new System.Drawing.Point(73, 24);
            this.chkModificar.Name = "chkModificar";
            this.chkModificar.Size = new System.Drawing.Size(84, 21);
            this.chkModificar.TabIndex = 5;
            this.chkModificar.Text = "Modificar";
            this.chkModificar.UseVisualStyleBackColor = true;
            // 
            // chkEliminar
            // 
            this.chkEliminar.AutoSize = true;
            this.chkEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEliminar.ForeColor = System.Drawing.Color.Black;
            this.chkEliminar.Location = new System.Drawing.Point(227, 25);
            this.chkEliminar.Name = "chkEliminar";
            this.chkEliminar.Size = new System.Drawing.Size(77, 21);
            this.chkEliminar.TabIndex = 7;
            this.chkEliminar.Text = "Eliminar";
            this.chkEliminar.UseVisualStyleBackColor = true;
            // 
            // chkConsultar
            // 
            this.chkConsultar.AutoSize = true;
            this.chkConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkConsultar.ForeColor = System.Drawing.Color.Black;
            this.chkConsultar.Location = new System.Drawing.Point(306, 25);
            this.chkConsultar.Name = "chkConsultar";
            this.chkConsultar.Size = new System.Drawing.Size(87, 21);
            this.chkConsultar.TabIndex = 9;
            this.chkConsultar.Text = "Consultar";
            this.chkConsultar.UseVisualStyleBackColor = true;
            // 
            // cmbDocumentos
            // 
            this.cmbDocumentos.FormattingEnabled = true;
            this.cmbDocumentos.Location = new System.Drawing.Point(351, 11);
            this.cmbDocumentos.Name = "cmbDocumentos";
            this.cmbDocumentos.Size = new System.Drawing.Size(228, 21);
            this.cmbDocumentos.TabIndex = 8;
            this.cmbDocumentos.SelectedValueChanged += new System.EventHandler(this.cmbDocumentos_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(280, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Documento:";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(67, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 19);
            this.label2.TabIndex = 1;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario: ";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCopiarUsuario,
            this.toolStripSeparator2,
            this.btnEliminaUsuario,
            this.btnEliminarDocumento,
            this.toolStripSeparator1,
            this.btnGuardar,
            this.btnSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(591, 46);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnCopiarUsuario
            // 
            this.btnCopiarUsuario.ForeColor = System.Drawing.Color.White;
            this.btnCopiarUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btnCopiarUsuario.Image")));
            this.btnCopiarUsuario.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCopiarUsuario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopiarUsuario.Name = "btnCopiarUsuario";
            this.btnCopiarUsuario.Size = new System.Drawing.Size(82, 43);
            this.btnCopiarUsuario.Text = "&CopiaUsuario";
            this.btnCopiarUsuario.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCopiarUsuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCopiarUsuario.ToolTipText = "Copia configuración existente de otro usuario";
            this.btnCopiarUsuario.Click += new System.EventHandler(this.btnCopiarUsuario_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 46);
            // 
            // btnEliminaUsuario
            // 
            this.btnEliminaUsuario.ForeColor = System.Drawing.Color.White;
            this.btnEliminaUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminaUsuario.Image")));
            this.btnEliminaUsuario.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEliminaUsuario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminaUsuario.Name = "btnEliminaUsuario";
            this.btnEliminaUsuario.Size = new System.Drawing.Size(67, 43);
            this.btnEliminaUsuario.Text = "EliminaUsr";
            this.btnEliminaUsuario.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminaUsuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEliminaUsuario.ToolTipText = "Elimina todas las autorizaciones del usuario actual";
            this.btnEliminaUsuario.Click += new System.EventHandler(this.btnEliminaUsuario_Click);
            // 
            // btnEliminarDocumento
            // 
            this.btnEliminarDocumento.ForeColor = System.Drawing.Color.White;
            this.btnEliminarDocumento.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarDocumento.Image")));
            this.btnEliminarDocumento.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEliminarDocumento.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarDocumento.Name = "btnEliminarDocumento";
            this.btnEliminarDocumento.Size = new System.Drawing.Size(54, 43);
            this.btnEliminarDocumento.Text = "Eliminar";
            this.btnEliminarDocumento.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminarDocumento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEliminarDocumento.ToolTipText = "Elimina únicamente los datos del documento actual";
            this.btnEliminarDocumento.Click += new System.EventHandler(this.btnEliminarDocumento_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 46);
            // 
            // btnGuardar
            // 
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(53, 43);
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(33, 43);
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // malla
            // 
            this.malla.AllowUserToAddRows = false;
            this.malla.AllowUserToDeleteRows = false;
            this.malla.AllowUserToResizeColumns = false;
            this.malla.AllowUserToResizeRows = false;
            this.malla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
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
            this.malla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.malla.EnableHeadersVisualStyles = false;
            this.malla.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.malla.Location = new System.Drawing.Point(0, 202);
            this.malla.Name = "malla";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.malla.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.malla.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.malla.Size = new System.Drawing.Size(591, 223);
            this.malla.TabIndex = 2;
            this.malla.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.malla_EditingControlShowing);
            this.malla.KeyDown += new System.Windows.Forms.KeyEventHandler(this.malla_KeyDown);
            // 
            // frmAccsDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(591, 425);
            this.ControlBox = false;
            this.Controls.Add(this.malla);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmAccsDoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autorizaciones para manejo de documentos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpOpciones.ResumeLayout(false);
            this.grpOpciones.PerformLayout();
            this.grpAcciones.ResumeLayout(false);
            this.grpAcciones.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.malla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.CheckBox chkEliminar;
        private System.Windows.Forms.CheckBox chkAnular;
        private System.Windows.Forms.CheckBox chkModificar;
        private System.Windows.Forms.CheckBox chkCrear;
        private System.Windows.Forms.DataGridView malla;
        private System.Windows.Forms.ToolStripButton btnCopiarUsuario;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.ComboBox cmbDocumentos;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnEliminaUsuario;
        private System.Windows.Forms.ToolStripButton btnEliminarDocumento;
        private System.Windows.Forms.CheckBox chkConsultar;
        private System.Windows.Forms.CheckBox chkCierreCaja;
        private System.Windows.Forms.CheckBox chkGastos;
        private System.Windows.Forms.CheckBox chkIngresos;
        private System.Windows.Forms.CheckBox chkEntregaExpress;
        private System.Windows.Forms.GroupBox grpOpciones;
        private System.Windows.Forms.GroupBox grpAcciones;
    }
}

