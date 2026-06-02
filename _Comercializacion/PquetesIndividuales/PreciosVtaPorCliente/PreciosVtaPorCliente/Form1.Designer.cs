namespace DaxComercia
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnAbrir = new System.Windows.Forms.ToolStripButton();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.btnCopiar = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTipocliente = new System.Windows.Forms.TextBox();
            this.txtPais = new System.Windows.Forms.TextBox();
            this.btnTipoCliente = new System.Windows.Forms.Button();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtTipoClienteCod = new System.Windows.Forms.TextBox();
            this.btnPAis = new System.Windows.Forms.Button();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtPaisCod = new System.Windows.Forms.TextBox();
            this.txtSQLPrecio = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.btnClientes = new System.Windows.Forms.Button();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtClienteNombre = new System.Windows.Forms.TextBox();
            this.txtClienteCod = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.cboGrupo = new System.Windows.Forms.ComboBox();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.cboClase = new System.Windows.Forms.ComboBox();
            this.malla = new System.Windows.Forms.DataGridView();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.btnAgrupar = new System.Windows.Forms.Button();
            this.chkIva = new System.Windows.Forms.CheckBox();
            this.txtDescripLst = new System.Windows.Forms.TextBox();
            this.txtNumeroLst = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.ToolStrip1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.malla)).BeginInit();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.btnAbrir,
            this.btnCancelar,
            this.ToolStripSeparator2,
            this.btnGuardar,
            this.btnEliminar,
            this.btnCopiar,
            this.ToolStripSeparator3,
            this.btnSalir});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(944, 38);
            this.ToolStrip1.TabIndex = 5;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(46, 35);
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNuevo.ToolTipText = "Nueva Lista de Precios";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnAbrir
            // 
            this.btnAbrir.Image = ((System.Drawing.Image)(resources.GetObject("btnAbrir.Image")));
            this.btnAbrir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(37, 35);
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAbrir.ToolTipText = "Abrir Lista de Precios";
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(57, 35);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(53, 35);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGuardar.ToolTipText = "Guardar Lista de Precios";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(54, 35);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEliminar.ToolTipText = "Eliminar Lista de Precios";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCopiar
            // 
            this.btnCopiar.Enabled = false;
            this.btnCopiar.Image = ((System.Drawing.Image)(resources.GetObject("btnCopiar.Image")));
            this.btnCopiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(46, 35);
            this.btnCopiar.Text = "Copiar";
            this.btnCopiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCopiar.ToolTipText = "Copiar Lista de Precios";
            this.btnCopiar.Visible = false;
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(33, 35);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(15, 50);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(36, 13);
            this.Label8.TabIndex = 7;
            this.Label8.Text = "Clase:";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(14, 25);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(57, 13);
            this.Label7.TabIndex = 6;
            this.Label7.Text = "Categoría:";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txtTipocliente);
            this.GroupBox1.Controls.Add(this.txtPais);
            this.GroupBox1.Controls.Add(this.btnTipoCliente);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.txtTipoClienteCod);
            this.GroupBox1.Controls.Add(this.btnPAis);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.txtPaisCod);
            this.GroupBox1.Controls.Add(this.txtSQLPrecio);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.btnClientes);
            this.GroupBox1.Controls.Add(this.cboMoneda);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.txtClienteNombre);
            this.GroupBox1.Controls.Add(this.txtClienteCod);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Location = new System.Drawing.Point(0, 3);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(574, 99);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "REGISTRAR ESTA LISTA DE PRECIOS PARA  UTILIZARLA CON:";
            // 
            // txtTipocliente
            // 
            this.txtTipocliente.Location = new System.Drawing.Point(228, 47);
            this.txtTipocliente.Name = "txtTipocliente";
            this.txtTipocliente.Size = new System.Drawing.Size(207, 20);
            this.txtTipocliente.TabIndex = 8;
            // 
            // txtPais
            // 
            this.txtPais.Location = new System.Drawing.Point(229, 68);
            this.txtPais.Name = "txtPais";
            this.txtPais.Size = new System.Drawing.Size(206, 20);
            this.txtPais.TabIndex = 11;
            // 
            // btnTipoCliente
            // 
            this.btnTipoCliente.Location = new System.Drawing.Point(206, 47);
            this.btnTipoCliente.Name = "btnTipoCliente";
            this.btnTipoCliente.Size = new System.Drawing.Size(23, 22);
            this.btnTipoCliente.TabIndex = 9;
            this.btnTipoCliente.Text = "...";
            this.btnTipoCliente.UseVisualStyleBackColor = true;
            this.btnTipoCliente.Click += new System.EventHandler(this.btnTipoCliente_Click);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(9, 50);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(66, 13);
            this.Label6.TabIndex = 18;
            this.Label6.Text = "Tipo Cliente:";
            // 
            // txtTipoClienteCod
            // 
            this.txtTipoClienteCod.Location = new System.Drawing.Point(75, 47);
            this.txtTipoClienteCod.MaxLength = 10;
            this.txtTipoClienteCod.Name = "txtTipoClienteCod";
            this.txtTipoClienteCod.Size = new System.Drawing.Size(132, 20);
            this.txtTipoClienteCod.TabIndex = 7;
            this.txtTipoClienteCod.TextChanged += new System.EventHandler(this.txtClienteCod_TextChanged);
            // 
            // btnPAis
            // 
            this.btnPAis.Location = new System.Drawing.Point(206, 68);
            this.btnPAis.Name = "btnPAis";
            this.btnPAis.Size = new System.Drawing.Size(23, 22);
            this.btnPAis.TabIndex = 12;
            this.btnPAis.Text = "...";
            this.btnPAis.UseVisualStyleBackColor = true;
            this.btnPAis.Click += new System.EventHandler(this.btnPAis_Click);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(43, 71);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(32, 13);
            this.Label5.TabIndex = 15;
            this.Label5.Text = "País:";
            // 
            // txtPaisCod
            // 
            this.txtPaisCod.Location = new System.Drawing.Point(75, 68);
            this.txtPaisCod.MaxLength = 10;
            this.txtPaisCod.Name = "txtPaisCod";
            this.txtPaisCod.Size = new System.Drawing.Size(132, 20);
            this.txtPaisCod.TabIndex = 10;
            this.txtPaisCod.TextChanged += new System.EventHandler(this.txtClienteCod_TextChanged);
            // 
            // txtSQLPrecio
            // 
            this.txtSQLPrecio.Location = new System.Drawing.Point(637, 35);
            this.txtSQLPrecio.Name = "txtSQLPrecio";
            this.txtSQLPrecio.Size = new System.Drawing.Size(306, 20);
            this.txtSQLPrecio.TabIndex = 13;
            this.txtSQLPrecio.Visible = false;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(589, 41);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(47, 13);
            this.Label4.TabIndex = 12;
            this.Label4.Text = "Fórmula:";
            this.Label4.Visible = false;
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(205, 26);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(23, 22);
            this.btnClientes.TabIndex = 6;
            this.btnClientes.Text = "...";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // cboMoneda
            // 
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(657, 56);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(138, 21);
            this.cboMoneda.TabIndex = 9;
            this.cboMoneda.Visible = false;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(605, 63);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(49, 13);
            this.Label3.TabIndex = 8;
            this.Label3.Text = "Moneda:";
            this.Label3.Visible = false;
            // 
            // txtClienteNombre
            // 
            this.txtClienteNombre.Location = new System.Drawing.Point(227, 26);
            this.txtClienteNombre.Name = "txtClienteNombre";
            this.txtClienteNombre.Size = new System.Drawing.Size(328, 20);
            this.txtClienteNombre.TabIndex = 5;
            // 
            // txtClienteCod
            // 
            this.txtClienteCod.Location = new System.Drawing.Point(75, 26);
            this.txtClienteCod.MaxLength = 30;
            this.txtClienteCod.Name = "txtClienteCod";
            this.txtClienteCod.Size = new System.Drawing.Size(132, 20);
            this.txtClienteCod.TabIndex = 4;
            this.txtClienteCod.TextChanged += new System.EventHandler(this.txtClienteCod_TextChanged);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(33, 29);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(42, 13);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Cliente:";
            // 
            // cboCategoria
            // 
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(73, 21);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(276, 21);
            this.cboCategoria.TabIndex = 3;
            this.cboCategoria.SelectedIndexChanged += new System.EventHandler(this.cboCategoria_SelectedIndexChanged);
            this.cboCategoria.TextChanged += new System.EventHandler(this.txtClienteCod_TextChanged);
            // 
            // cboGrupo
            // 
            this.cboGrupo.FormattingEnabled = true;
            this.cboGrupo.Location = new System.Drawing.Point(73, 72);
            this.cboGrupo.Name = "cboGrupo";
            this.cboGrupo.Size = new System.Drawing.Size(276, 21);
            this.cboGrupo.TabIndex = 5;
            this.cboGrupo.SelectedIndexChanged += new System.EventHandler(this.cboCategoria_SelectedIndexChanged);
            this.cboGrupo.TextChanged += new System.EventHandler(this.txtClienteCod_TextChanged);
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.GroupBox2);
            this.Panel3.Controls.Add(this.GroupBox1);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel3.Location = new System.Drawing.Point(0, 69);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(944, 108);
            this.Panel3.TabIndex = 7;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.Label9);
            this.GroupBox2.Controls.Add(this.Label8);
            this.GroupBox2.Controls.Add(this.Label7);
            this.GroupBox2.Controls.Add(this.cboCategoria);
            this.GroupBox2.Controls.Add(this.cboGrupo);
            this.GroupBox2.Controls.Add(this.cboClase);
            this.GroupBox2.Location = new System.Drawing.Point(585, 3);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(358, 98);
            this.GroupBox2.TabIndex = 2;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "SELECCIONAR ARTICULOS A REGISTRAR PRECIO";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(16, 77);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(39, 13);
            this.Label9.TabIndex = 8;
            this.Label9.Text = "Grupo:";
            // 
            // cboClase
            // 
            this.cboClase.FormattingEnabled = true;
            this.cboClase.Location = new System.Drawing.Point(73, 46);
            this.cboClase.Name = "cboClase";
            this.cboClase.Size = new System.Drawing.Size(276, 21);
            this.cboClase.TabIndex = 4;
            this.cboClase.SelectedIndexChanged += new System.EventHandler(this.cboCategoria_SelectedIndexChanged);
            this.cboClase.TextChanged += new System.EventHandler(this.txtClienteCod_TextChanged);
            // 
            // malla
            // 
            this.malla.AllowUserToAddRows = false;
            this.malla.AllowUserToDeleteRows = false;
            this.malla.AllowUserToOrderColumns = true;
            this.malla.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.malla.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.malla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.malla.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.malla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.malla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.malla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.malla.EnableHeadersVisualStyles = false;
            this.malla.Location = new System.Drawing.Point(0, 177);
            this.malla.Name = "malla";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.malla.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.malla.RowHeadersWidth = 21;
            this.malla.Size = new System.Drawing.Size(944, 330);
            this.malla.TabIndex = 8;
            this.malla.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.malla_CellValueChanged);
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.btnAgrupar);
            this.Panel2.Controls.Add(this.chkIva);
            this.Panel2.Controls.Add(this.txtDescripLst);
            this.Panel2.Controls.Add(this.txtNumeroLst);
            this.Panel2.Controls.Add(this.Label1);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel2.Location = new System.Drawing.Point(0, 38);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(944, 31);
            this.Panel2.TabIndex = 6;
            // 
            // btnAgrupar
            // 
            this.btnAgrupar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAgrupar.ForeColor = System.Drawing.Color.White;
            this.btnAgrupar.Location = new System.Drawing.Point(662, 5);
            this.btnAgrupar.Name = "btnAgrupar";
            this.btnAgrupar.Size = new System.Drawing.Size(216, 24);
            this.btnAgrupar.TabIndex = 19;
            this.btnAgrupar.Text = "Agrupar en esta lista varios clientes";
            this.btnAgrupar.UseVisualStyleBackColor = false;
            this.btnAgrupar.Visible = false;
            // 
            // chkIva
            // 
            this.chkIva.AutoSize = true;
            this.chkIva.Location = new System.Drawing.Point(532, 9);
            this.chkIva.Name = "chkIva";
            this.chkIva.Size = new System.Drawing.Size(111, 17);
            this.chkIva.TabIndex = 3;
            this.chkIva.Text = "Precio Incluye Iva";
            this.chkIva.UseVisualStyleBackColor = true;
            // 
            // txtDescripLst
            // 
            this.txtDescripLst.Location = new System.Drawing.Point(163, 7);
            this.txtDescripLst.MaxLength = 100;
            this.txtDescripLst.Name = "txtDescripLst";
            this.txtDescripLst.Size = new System.Drawing.Size(363, 20);
            this.txtDescripLst.TabIndex = 2;
            // 
            // txtNumeroLst
            // 
            this.txtNumeroLst.Location = new System.Drawing.Point(60, 6);
            this.txtNumeroLst.MaxLength = 20;
            this.txtNumeroLst.Name = "txtNumeroLst";
            this.txtNumeroLst.ReadOnly = true;
            this.txtNumeroLst.Size = new System.Drawing.Size(100, 20);
            this.txtNumeroLst.TabIndex = 1;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(11, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(49, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Lista No:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(944, 507);
            this.Controls.Add(this.malla);
            this.Controls.Add(this.Panel3);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.ToolStrip1);
            this.Name = "Form1";
            this.Text = "MANTENIMIENTO LISTA DE PRECIOS POR CLIENTE";
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.Panel3.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.malla)).EndInit();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton btnNuevo;
        internal System.Windows.Forms.ToolStripButton btnAbrir;
        internal System.Windows.Forms.ToolStripButton btnCancelar;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        internal System.Windows.Forms.ToolStripButton btnGuardar;
        internal System.Windows.Forms.ToolStripButton btnEliminar;
        internal System.Windows.Forms.ToolStripButton btnCopiar;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
        internal System.Windows.Forms.ToolStripButton btnSalir;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox txtTipocliente;
        internal System.Windows.Forms.TextBox txtPais;
        internal System.Windows.Forms.Button btnTipoCliente;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox txtTipoClienteCod;
        internal System.Windows.Forms.Button btnPAis;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txtPaisCod;
        internal System.Windows.Forms.TextBox txtSQLPrecio;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Button btnClientes;
        internal System.Windows.Forms.ComboBox cboMoneda;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtClienteNombre;
        internal System.Windows.Forms.TextBox txtClienteCod;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox cboCategoria;
        internal System.Windows.Forms.ComboBox cboGrupo;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.ComboBox cboClase;
        internal System.Windows.Forms.DataGridView malla;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Button btnAgrupar;
        internal System.Windows.Forms.CheckBox chkIva;
        internal System.Windows.Forms.TextBox txtDescripLst;
        internal System.Windows.Forms.TextBox txtNumeroLst;
        internal System.Windows.Forms.Label Label1;
    }
}

