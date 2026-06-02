namespace CtasCorrientes
{
    partial class FrmListaCtasCorrientes
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListaCtasCorrientes));
			this.menu = new System.Windows.Forms.ToolStrip();
			this.opciones = new System.Windows.Forms.ToolStripButton();
			this.imprimir = new System.Windows.Forms.ToolStripButton();
			this.salir = new System.Windows.Forms.ToolStripButton();
			this.contenedor = new System.Windows.Forms.SplitContainer();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tFecha = new System.Windows.Forms.DateTimePicker();
			this.tCuentasCobrar = new System.Windows.Forms.CheckBox();
			this.tCuentasPagar = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cheSoloTotal = new System.Windows.Forms.CheckBox();
			this.chkValorVencido = new System.Windows.Forms.CheckBox();
			this.cheDetDoc = new System.Windows.Forms.CheckBox();
			this.chUnaCuentaPorHoja = new System.Windows.Forms.CheckBox();
			this.chkFechaVencimiento = new System.Windows.Forms.CheckBox();
			this.chkValorInicial = new System.Windows.Forms.CheckBox();
			this.chkDiasVencidos = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.adDocumentosFechaVencidosTodos = new System.Windows.Forms.CheckBox();
			this.adVencimiento = new System.Windows.Forms.CheckBox();
			this.adEmpleado = new System.Windows.Forms.CheckBox();
			this.adGarantias = new System.Windows.Forms.CheckBox();
			this.adAnticipos = new System.Windows.Forms.CheckBox();
			this.adDocumentosFechaVencidos = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.grupNiv = new System.Windows.Forms.GroupBox();
			this.agGrupo3 = new System.Windows.Forms.RadioButton();
			this.agCiudad = new System.Windows.Forms.RadioButton();
			this.agTipoCliente = new System.Windows.Forms.RadioButton();
			this.agZonaVentas = new System.Windows.Forms.RadioButton();
			this.agGrupo1 = new System.Windows.Forms.RadioButton();
			this.agGrupo2 = new System.Windows.Forms.RadioButton();
			this.agProvincia = new System.Windows.Forms.RadioButton();
			this.agRegion = new System.Windows.Forms.RadioButton();
			this.agVendedor = new System.Windows.Forms.RadioButton();
			this.agSucursal = new System.Windows.Forms.RadioButton();
			this.label12 = new System.Windows.Forms.Label();
			this.btnGrupo3 = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.tGrupo3 = new System.Windows.Forms.TextBox();
			this.btnGrupo2 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.tGrupo2 = new System.Windows.Forms.TextBox();
			this.btnGrupo1 = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.tGrupo1 = new System.Windows.Forms.TextBox();
			this.btnZonaVentas = new System.Windows.Forms.Button();
			this.btnTipoCliente = new System.Windows.Forms.Button();
			this.tProvincia = new System.Windows.Forms.TextBox();
			this.tRegion = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnCiudad = new System.Windows.Forms.Button();
			this.btnProvincia = new System.Windows.Forms.Button();
			this.btnRegion = new System.Windows.Forms.Button();
			this.tZonaVen = new System.Windows.Forms.TextBox();
			this.tCliente = new System.Windows.Forms.TextBox();
			this.tCiudad = new System.Windows.Forms.TextBox();
			this.cSucursal = new System.Windows.Forms.ComboBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.cVendedor = new System.Windows.Forms.ComboBox();
			this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
			this.menu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.contenedor)).BeginInit();
			this.contenedor.Panel1.SuspendLayout();
			this.contenedor.Panel2.SuspendLayout();
			this.contenedor.SuspendLayout();
			this.panel1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.grupNiv.SuspendLayout();
			this.SuspendLayout();
			// 
			// menu
			// 
			this.menu.AutoSize = false;
			this.menu.BackColor = System.Drawing.Color.DimGray;
			this.menu.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opciones,
            this.imprimir,
            this.salir});
			this.menu.Location = new System.Drawing.Point(0, 0);
			this.menu.Name = "menu";
			this.menu.Size = new System.Drawing.Size(1128, 55);
			this.menu.TabIndex = 3;
			this.menu.Text = "toolStrip1";
			// 
			// opciones
			// 
			this.opciones.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.opciones.Image = ((System.Drawing.Image)(resources.GetObject("opciones.Image")));
			this.opciones.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.opciones.Name = "opciones";
			this.opciones.Size = new System.Drawing.Size(75, 52);
			this.opciones.Text = "Opciones";
			this.opciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.opciones.Click += new System.EventHandler(this.opciones_Click);
			// 
			// imprimir
			// 
			this.imprimir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.imprimir.Image = ((System.Drawing.Image)(resources.GetObject("imprimir.Image")));
			this.imprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.imprimir.Name = "imprimir";
			this.imprimir.Size = new System.Drawing.Size(79, 52);
			this.imprimir.Text = "Actualizar";
			this.imprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.imprimir.Click += new System.EventHandler(this.imprimir_Click);
			// 
			// salir
			// 
			this.salir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.salir.Image = ((System.Drawing.Image)(resources.GetObject("salir.Image")));
			this.salir.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.salir.Name = "salir";
			this.salir.Size = new System.Drawing.Size(42, 52);
			this.salir.Text = "Salir";
			this.salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.salir.Click += new System.EventHandler(this.salir_Click);
			// 
			// contenedor
			// 
			this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.contenedor.Location = new System.Drawing.Point(0, 55);
			this.contenedor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.contenedor.Name = "contenedor";
			// 
			// contenedor.Panel1
			// 
			this.contenedor.Panel1.Controls.Add(this.panel1);
			this.contenedor.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			// 
			// contenedor.Panel2
			// 
			this.contenedor.Panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.contenedor.Panel2.Controls.Add(this.reportViewer1);
			this.contenedor.Size = new System.Drawing.Size(1128, 791);
			this.contenedor.SplitterDistance = 414;
			this.contenedor.SplitterWidth = 5;
			this.contenedor.TabIndex = 4;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.DarkGray;
			this.panel1.Controls.Add(this.tFecha);
			this.panel1.Controls.Add(this.tCuentasCobrar);
			this.panel1.Controls.Add(this.tCuentasPagar);
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.grupNiv);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(414, 791);
			this.panel1.TabIndex = 1;
			// 
			// tFecha
			// 
			this.tFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.tFecha.Location = new System.Drawing.Point(283, 11);
			this.tFecha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tFecha.Name = "tFecha";
			this.tFecha.Size = new System.Drawing.Size(119, 22);
			this.tFecha.TabIndex = 60;
			// 
			// tCuentasCobrar
			// 
			this.tCuentasCobrar.AutoSize = true;
			this.tCuentasCobrar.Checked = true;
			this.tCuentasCobrar.CheckState = System.Windows.Forms.CheckState.Checked;
			this.tCuentasCobrar.Location = new System.Drawing.Point(16, 26);
			this.tCuentasCobrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tCuentasCobrar.Name = "tCuentasCobrar";
			this.tCuentasCobrar.Size = new System.Drawing.Size(154, 21);
			this.tCuentasCobrar.TabIndex = 59;
			this.tCuentasCobrar.Text = "Cuentas por Cobrar";
			this.tCuentasCobrar.UseVisualStyleBackColor = true;
			// 
			// tCuentasPagar
			// 
			this.tCuentasPagar.AutoSize = true;
			this.tCuentasPagar.Location = new System.Drawing.Point(16, 6);
			this.tCuentasPagar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tCuentasPagar.Name = "tCuentasPagar";
			this.tCuentasPagar.Size = new System.Drawing.Size(148, 21);
			this.tCuentasPagar.TabIndex = 58;
			this.tCuentasPagar.Text = "Cuentas por pagar";
			this.tCuentasPagar.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.cheSoloTotal);
			this.groupBox2.Controls.Add(this.chkValorVencido);
			this.groupBox2.Controls.Add(this.cheDetDoc);
			this.groupBox2.Controls.Add(this.chUnaCuentaPorHoja);
			this.groupBox2.Controls.Add(this.chkFechaVencimiento);
			this.groupBox2.Controls.Add(this.chkValorInicial);
			this.groupBox2.Controls.Add(this.chkDiasVencidos);
			this.groupBox2.ForeColor = System.Drawing.Color.White;
			this.groupBox2.Location = new System.Drawing.Point(4, 540);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.groupBox2.Size = new System.Drawing.Size(403, 186);
			this.groupBox2.TabIndex = 55;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Campos a imprimir";
			// 
			// cheSoloTotal
			// 
			this.cheSoloTotal.AutoSize = true;
			this.cheSoloTotal.ForeColor = System.Drawing.Color.Black;
			this.cheSoloTotal.Location = new System.Drawing.Point(16, 128);
			this.cheSoloTotal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.cheSoloTotal.Name = "cheSoloTotal";
			this.cheSoloTotal.Size = new System.Drawing.Size(155, 21);
			this.cheSoloTotal.TabIndex = 10;
			this.cheSoloTotal.Text = "Imprimir solo totales";
			this.cheSoloTotal.UseVisualStyleBackColor = true;
			// 
			// chkValorVencido
			// 
			this.chkValorVencido.AutoSize = true;
			this.chkValorVencido.ForeColor = System.Drawing.Color.Black;
			this.chkValorVencido.Location = new System.Drawing.Point(15, 86);
			this.chkValorVencido.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.chkValorVencido.Name = "chkValorVencido";
			this.chkValorVencido.Size = new System.Drawing.Size(116, 21);
			this.chkValorVencido.TabIndex = 9;
			this.chkValorVencido.Text = "Valor vencido";
			this.chkValorVencido.UseVisualStyleBackColor = true;
			// 
			// cheDetDoc
			// 
			this.cheDetDoc.AutoSize = true;
			this.cheDetDoc.Checked = true;
			this.cheDetDoc.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cheDetDoc.ForeColor = System.Drawing.Color.Black;
			this.cheDetDoc.Location = new System.Drawing.Point(15, 107);
			this.cheDetDoc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.cheDetDoc.Name = "cheDetDoc";
			this.cheDetDoc.Size = new System.Drawing.Size(175, 21);
			this.cheDetDoc.TabIndex = 8;
			this.cheDetDoc.Text = "Detalle de documentos";
			this.cheDetDoc.UseVisualStyleBackColor = true;
			// 
			// chUnaCuentaPorHoja
			// 
			this.chUnaCuentaPorHoja.AutoSize = true;
			this.chUnaCuentaPorHoja.ForeColor = System.Drawing.Color.Black;
			this.chUnaCuentaPorHoja.Location = new System.Drawing.Point(16, 150);
			this.chUnaCuentaPorHoja.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.chUnaCuentaPorHoja.Name = "chUnaCuentaPorHoja";
			this.chUnaCuentaPorHoja.Size = new System.Drawing.Size(315, 21);
			this.chUnaCuentaPorHoja.TabIndex = 5;
			this.chUnaCuentaPorHoja.Text = "Imprimir un estado de cuenta en cada página";
			this.chUnaCuentaPorHoja.UseVisualStyleBackColor = true;
			// 
			// chkFechaVencimiento
			// 
			this.chkFechaVencimiento.AutoSize = true;
			this.chkFechaVencimiento.ForeColor = System.Drawing.Color.Black;
			this.chkFechaVencimiento.Location = new System.Drawing.Point(15, 65);
			this.chkFechaVencimiento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.chkFechaVencimiento.Name = "chkFechaVencimiento";
			this.chkFechaVencimiento.Size = new System.Drawing.Size(168, 21);
			this.chkFechaVencimiento.TabIndex = 4;
			this.chkFechaVencimiento.Text = "Fecha de vencimiento";
			this.chkFechaVencimiento.UseVisualStyleBackColor = true;
			// 
			// chkValorInicial
			// 
			this.chkValorInicial.AutoSize = true;
			this.chkValorInicial.ForeColor = System.Drawing.Color.Black;
			this.chkValorInicial.Location = new System.Drawing.Point(15, 44);
			this.chkValorInicial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.chkValorInicial.Name = "chkValorInicial";
			this.chkValorInicial.Size = new System.Drawing.Size(199, 21);
			this.chkValorInicial.TabIndex = 3;
			this.chkValorInicial.Text = "Valor inicial del documento";
			this.chkValorInicial.UseVisualStyleBackColor = true;
			// 
			// chkDiasVencidos
			// 
			this.chkDiasVencidos.AutoSize = true;
			this.chkDiasVencidos.ForeColor = System.Drawing.Color.Black;
			this.chkDiasVencidos.Location = new System.Drawing.Point(15, 23);
			this.chkDiasVencidos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.chkDiasVencidos.Name = "chkDiasVencidos";
			this.chkDiasVencidos.Size = new System.Drawing.Size(118, 21);
			this.chkDiasVencidos.TabIndex = 2;
			this.chkDiasVencidos.Text = "Dias vencidos";
			this.chkDiasVencidos.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.adDocumentosFechaVencidosTodos);
			this.groupBox1.Controls.Add(this.adVencimiento);
			this.groupBox1.Controls.Add(this.adEmpleado);
			this.groupBox1.Controls.Add(this.adGarantias);
			this.groupBox1.Controls.Add(this.adAnticipos);
			this.groupBox1.Controls.Add(this.adDocumentosFechaVencidos);
			this.groupBox1.ForeColor = System.Drawing.Color.White;
			this.groupBox1.Location = new System.Drawing.Point(5, 49);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.groupBox1.Size = new System.Drawing.Size(403, 145);
			this.groupBox1.TabIndex = 53;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Datos Adicionales para incluir en el reporte";
			// 
			// adDocumentosFechaVencidosTodos
			// 
			this.adDocumentosFechaVencidosTodos.AutoSize = true;
			this.adDocumentosFechaVencidosTodos.ForeColor = System.Drawing.Color.Black;
			this.adDocumentosFechaVencidosTodos.Location = new System.Drawing.Point(15, 82);
			this.adDocumentosFechaVencidosTodos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.adDocumentosFechaVencidosTodos.Name = "adDocumentosFechaVencidosTodos";
			this.adDocumentosFechaVencidosTodos.Size = new System.Drawing.Size(203, 21);
			this.adDocumentosFechaVencidosTodos.TabIndex = 71;
			this.adDocumentosFechaVencidosTodos.Text = "Documentos a Fecha todos";
			this.adDocumentosFechaVencidosTodos.UseVisualStyleBackColor = true;
			// 
			// adVencimiento
			// 
			this.adVencimiento.AutoSize = true;
			this.adVencimiento.ForeColor = System.Drawing.Color.Black;
			this.adVencimiento.Location = new System.Drawing.Point(15, 122);
			this.adVencimiento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.adVencimiento.Name = "adVencimiento";
			this.adVencimiento.Size = new System.Drawing.Size(146, 21);
			this.adVencimiento.TabIndex = 70;
			this.adVencimiento.Text = "Solo Vencimientos";
			this.adVencimiento.UseVisualStyleBackColor = true;
			// 
			// adEmpleado
			// 
			this.adEmpleado.AutoSize = true;
			this.adEmpleado.ForeColor = System.Drawing.Color.Black;
			this.adEmpleado.Location = new System.Drawing.Point(15, 101);
			this.adEmpleado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.adEmpleado.Name = "adEmpleado";
			this.adEmpleado.Size = new System.Drawing.Size(168, 21);
			this.adEmpleado.TabIndex = 70;
			this.adEmpleado.Text = "Cuentas de empleado";
			this.adEmpleado.UseVisualStyleBackColor = true;
			// 
			// adGarantias
			// 
			this.adGarantias.AutoSize = true;
			this.adGarantias.ForeColor = System.Drawing.Color.Black;
			this.adGarantias.Location = new System.Drawing.Point(15, 43);
			this.adGarantias.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.adGarantias.Name = "adGarantias";
			this.adGarantias.Size = new System.Drawing.Size(92, 21);
			this.adGarantias.TabIndex = 1;
			this.adGarantias.Text = "Garantias";
			this.adGarantias.UseVisualStyleBackColor = true;
			// 
			// adAnticipos
			// 
			this.adAnticipos.AutoSize = true;
			this.adAnticipos.ForeColor = System.Drawing.Color.Black;
			this.adAnticipos.Location = new System.Drawing.Point(15, 23);
			this.adAnticipos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.adAnticipos.Name = "adAnticipos";
			this.adAnticipos.Size = new System.Drawing.Size(87, 21);
			this.adAnticipos.TabIndex = 0;
			this.adAnticipos.Text = "Anticipos";
			this.adAnticipos.UseVisualStyleBackColor = true;
			// 
			// adDocumentosFechaVencidos
			// 
			this.adDocumentosFechaVencidos.AutoSize = true;
			this.adDocumentosFechaVencidos.ForeColor = System.Drawing.Color.Black;
			this.adDocumentosFechaVencidos.Location = new System.Drawing.Point(15, 63);
			this.adDocumentosFechaVencidos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.adDocumentosFechaVencidos.Name = "adDocumentosFechaVencidos";
			this.adDocumentosFechaVencidos.Size = new System.Drawing.Size(224, 21);
			this.adDocumentosFechaVencidos.TabIndex = 0;
			this.adDocumentosFechaVencidos.Text = "Documentos a Fecha vencidos";
			this.adDocumentosFechaVencidos.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(179, 17);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(103, 17);
			this.label2.TabIndex = 52;
			this.label2.Text = "Hasta la fecha:";
			// 
			// grupNiv
			// 
			this.grupNiv.Controls.Add(this.agGrupo3);
			this.grupNiv.Controls.Add(this.agCiudad);
			this.grupNiv.Controls.Add(this.agTipoCliente);
			this.grupNiv.Controls.Add(this.agZonaVentas);
			this.grupNiv.Controls.Add(this.agGrupo1);
			this.grupNiv.Controls.Add(this.agGrupo2);
			this.grupNiv.Controls.Add(this.agProvincia);
			this.grupNiv.Controls.Add(this.agRegion);
			this.grupNiv.Controls.Add(this.agVendedor);
			this.grupNiv.Controls.Add(this.agSucursal);
			this.grupNiv.Controls.Add(this.label12);
			this.grupNiv.Controls.Add(this.btnGrupo3);
			this.grupNiv.Controls.Add(this.label7);
			this.grupNiv.Controls.Add(this.tGrupo3);
			this.grupNiv.Controls.Add(this.btnGrupo2);
			this.grupNiv.Controls.Add(this.label6);
			this.grupNiv.Controls.Add(this.tGrupo2);
			this.grupNiv.Controls.Add(this.btnGrupo1);
			this.grupNiv.Controls.Add(this.label5);
			this.grupNiv.Controls.Add(this.tGrupo1);
			this.grupNiv.Controls.Add(this.btnZonaVentas);
			this.grupNiv.Controls.Add(this.btnTipoCliente);
			this.grupNiv.Controls.Add(this.tProvincia);
			this.grupNiv.Controls.Add(this.tRegion);
			this.grupNiv.Controls.Add(this.label4);
			this.grupNiv.Controls.Add(this.label3);
			this.grupNiv.Controls.Add(this.label1);
			this.grupNiv.Controls.Add(this.btnCiudad);
			this.grupNiv.Controls.Add(this.btnProvincia);
			this.grupNiv.Controls.Add(this.btnRegion);
			this.grupNiv.Controls.Add(this.tZonaVen);
			this.grupNiv.Controls.Add(this.tCliente);
			this.grupNiv.Controls.Add(this.tCiudad);
			this.grupNiv.Controls.Add(this.cSucursal);
			this.grupNiv.Controls.Add(this.label11);
			this.grupNiv.Controls.Add(this.label10);
			this.grupNiv.Controls.Add(this.label9);
			this.grupNiv.Controls.Add(this.label8);
			this.grupNiv.Controls.Add(this.cVendedor);
			this.grupNiv.ForeColor = System.Drawing.Color.White;
			this.grupNiv.Location = new System.Drawing.Point(5, 202);
			this.grupNiv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.grupNiv.Name = "grupNiv";
			this.grupNiv.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.grupNiv.Size = new System.Drawing.Size(405, 331);
			this.grupNiv.TabIndex = 1;
			this.grupNiv.TabStop = false;
			this.grupNiv.Text = "Opciones para seleccionar y ordenar cuentas";
			// 
			// agGrupo3
			// 
			this.agGrupo3.AutoSize = true;
			this.agGrupo3.Location = new System.Drawing.Point(360, 300);
			this.agGrupo3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.agGrupo3.Name = "agGrupo3";
			this.agGrupo3.Size = new System.Drawing.Size(17, 16);
			this.agGrupo3.TabIndex = 79;
			this.agGrupo3.TabStop = true;
			this.agGrupo3.UseVisualStyleBackColor = true;
			// 
			// agCiudad
			// 
			this.agCiudad.AutoSize = true;
			this.agCiudad.Location = new System.Drawing.Point(360, 165);
			this.agCiudad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.agCiudad.Name = "agCiudad";
			this.agCiudad.Size = new System.Drawing.Size(17, 16);
			this.agCiudad.TabIndex = 78;
			this.agCiudad.TabStop = true;
			this.agCiudad.UseVisualStyleBackColor = true;
			// 
			// agTipoCliente
			// 
			this.agTipoCliente.AutoSize = true;
			this.agTipoCliente.Location = new System.Drawing.Point(360, 191);
			this.agTipoCliente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.agTipoCliente.Name = "agTipoCliente";
			this.agTipoCliente.Size = new System.Drawing.Size(17, 16);
			this.agTipoCliente.TabIndex = 77;
			this.agTipoCliente.TabStop = true;
			this.agTipoCliente.UseVisualStyleBackColor = true;
			// 
			// agZonaVentas
			// 
			this.agZonaVentas.AutoSize = true;
			this.agZonaVentas.Location = new System.Drawing.Point(360, 220);
			this.agZonaVentas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.agZonaVentas.Name = "agZonaVentas";
			this.agZonaVentas.Size = new System.Drawing.Size(17, 16);
			this.agZonaVentas.TabIndex = 76;
			this.agZonaVentas.TabStop = true;
			this.agZonaVentas.UseVisualStyleBackColor = true;
			// 
			// agGrupo1
			// 
			this.agGrupo1.AutoSize = true;
			this.agGrupo1.Location = new System.Drawing.Point(360, 245);
			this.agGrupo1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.agGrupo1.Name = "agGrupo1";
			this.agGrupo1.Size = new System.Drawing.Size(17, 16);
			this.agGrupo1.TabIndex = 75;
			this.agGrupo1.TabStop = true;
			this.agGrupo1.UseVisualStyleBackColor = true;
			// 
			// agGrupo2
			// 
			this.agGrupo2.AutoSize = true;
			this.agGrupo2.Location = new System.Drawing.Point(360, 272);
			this.agGrupo2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.agGrupo2.Name = "agGrupo2";
			this.agGrupo2.Size = new System.Drawing.Size(17, 16);
			this.agGrupo2.TabIndex = 74;
			this.agGrupo2.TabStop = true;
			this.agGrupo2.UseVisualStyleBackColor = true;
			// 
			// agProvincia
			// 
			this.agProvincia.AutoSize = true;
			this.agProvincia.Location = new System.Drawing.Point(360, 138);
			this.agProvincia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.agProvincia.Name = "agProvincia";
			this.agProvincia.Size = new System.Drawing.Size(17, 16);
			this.agProvincia.TabIndex = 73;
			this.agProvincia.TabStop = true;
			this.agProvincia.UseVisualStyleBackColor = true;
			// 
			// agRegion
			// 
			this.agRegion.AutoSize = true;
			this.agRegion.Location = new System.Drawing.Point(360, 107);
			this.agRegion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.agRegion.Name = "agRegion";
			this.agRegion.Size = new System.Drawing.Size(17, 16);
			this.agRegion.TabIndex = 72;
			this.agRegion.TabStop = true;
			this.agRegion.UseVisualStyleBackColor = true;
			// 
			// agVendedor
			// 
			this.agVendedor.AutoSize = true;
			this.agVendedor.Location = new System.Drawing.Point(360, 74);
			this.agVendedor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.agVendedor.Name = "agVendedor";
			this.agVendedor.Size = new System.Drawing.Size(17, 16);
			this.agVendedor.TabIndex = 71;
			this.agVendedor.TabStop = true;
			this.agVendedor.UseVisualStyleBackColor = true;
			// 
			// agSucursal
			// 
			this.agSucursal.AutoSize = true;
			this.agSucursal.Location = new System.Drawing.Point(360, 46);
			this.agSucursal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.agSucursal.Name = "agSucursal";
			this.agSucursal.Size = new System.Drawing.Size(17, 16);
			this.agSucursal.TabIndex = 70;
			this.agSucursal.TabStop = true;
			this.agSucursal.UseVisualStyleBackColor = true;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.ForeColor = System.Drawing.Color.White;
			this.label12.Location = new System.Drawing.Point(336, 20);
			this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(57, 17);
			this.label12.TabIndex = 69;
			this.label12.Text = "AGRUPA";
			// 
			// btnGrupo3
			// 
			this.btnGrupo3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnGrupo3.Location = new System.Drawing.Point(308, 294);
			this.btnGrupo3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnGrupo3.Name = "btnGrupo3";
			this.btnGrupo3.Size = new System.Drawing.Size(29, 27);
			this.btnGrupo3.TabIndex = 68;
			this.btnGrupo3.Text = "...";
			this.btnGrupo3.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.ForeColor = System.Drawing.Color.Black;
			this.label7.Location = new System.Drawing.Point(13, 299);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(61, 17);
			this.label7.TabIndex = 67;
			this.label7.Text = "Grupo-3";
			// 
			// tGrupo3
			// 
			this.tGrupo3.Location = new System.Drawing.Point(107, 293);
			this.tGrupo3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tGrupo3.Name = "tGrupo3";
			this.tGrupo3.Size = new System.Drawing.Size(200, 22);
			this.tGrupo3.TabIndex = 66;
			// 
			// btnGrupo2
			// 
			this.btnGrupo2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnGrupo2.Location = new System.Drawing.Point(308, 267);
			this.btnGrupo2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnGrupo2.Name = "btnGrupo2";
			this.btnGrupo2.Size = new System.Drawing.Size(29, 27);
			this.btnGrupo2.TabIndex = 65;
			this.btnGrupo2.Text = "...";
			this.btnGrupo2.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.ForeColor = System.Drawing.Color.Black;
			this.label6.Location = new System.Drawing.Point(13, 272);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(61, 17);
			this.label6.TabIndex = 64;
			this.label6.Text = "Grupo-2";
			// 
			// tGrupo2
			// 
			this.tGrupo2.Location = new System.Drawing.Point(107, 266);
			this.tGrupo2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tGrupo2.Name = "tGrupo2";
			this.tGrupo2.Size = new System.Drawing.Size(200, 22);
			this.tGrupo2.TabIndex = 63;
			// 
			// btnGrupo1
			// 
			this.btnGrupo1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnGrupo1.Location = new System.Drawing.Point(307, 240);
			this.btnGrupo1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnGrupo1.Name = "btnGrupo1";
			this.btnGrupo1.Size = new System.Drawing.Size(29, 27);
			this.btnGrupo1.TabIndex = 62;
			this.btnGrupo1.Text = "...";
			this.btnGrupo1.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.ForeColor = System.Drawing.Color.Black;
			this.label5.Location = new System.Drawing.Point(12, 245);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(61, 17);
			this.label5.TabIndex = 61;
			this.label5.Text = "Grupo-1";
			// 
			// tGrupo1
			// 
			this.tGrupo1.Location = new System.Drawing.Point(105, 239);
			this.tGrupo1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tGrupo1.Name = "tGrupo1";
			this.tGrupo1.Size = new System.Drawing.Size(200, 22);
			this.tGrupo1.TabIndex = 60;
			// 
			// btnZonaVentas
			// 
			this.btnZonaVentas.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnZonaVentas.Location = new System.Drawing.Point(307, 214);
			this.btnZonaVentas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnZonaVentas.Name = "btnZonaVentas";
			this.btnZonaVentas.Size = new System.Drawing.Size(29, 27);
			this.btnZonaVentas.TabIndex = 59;
			this.btnZonaVentas.Text = "...";
			this.btnZonaVentas.UseVisualStyleBackColor = true;
			// 
			// btnTipoCliente
			// 
			this.btnTipoCliente.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnTipoCliente.Location = new System.Drawing.Point(305, 186);
			this.btnTipoCliente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnTipoCliente.Name = "btnTipoCliente";
			this.btnTipoCliente.Size = new System.Drawing.Size(29, 27);
			this.btnTipoCliente.TabIndex = 58;
			this.btnTipoCliente.Text = "...";
			this.btnTipoCliente.UseVisualStyleBackColor = true;
			// 
			// tProvincia
			// 
			this.tProvincia.Location = new System.Drawing.Point(104, 130);
			this.tProvincia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tProvincia.Name = "tProvincia";
			this.tProvincia.Size = new System.Drawing.Size(200, 22);
			this.tProvincia.TabIndex = 57;
			// 
			// tRegion
			// 
			this.tRegion.Location = new System.Drawing.Point(104, 103);
			this.tRegion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tRegion.Name = "tRegion";
			this.tRegion.Size = new System.Drawing.Size(201, 22);
			this.tRegion.TabIndex = 56;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(11, 135);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(70, 17);
			this.label4.TabIndex = 55;
			this.label4.Text = "Provincia:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(11, 107);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 17);
			this.label3.TabIndex = 54;
			this.label3.Text = "Región:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(12, 217);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(91, 17);
			this.label1.TabIndex = 53;
			this.label1.Text = "Zona ventas:";
			// 
			// btnCiudad
			// 
			this.btnCiudad.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCiudad.Location = new System.Drawing.Point(305, 159);
			this.btnCiudad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnCiudad.Name = "btnCiudad";
			this.btnCiudad.Size = new System.Drawing.Size(29, 27);
			this.btnCiudad.TabIndex = 52;
			this.btnCiudad.Text = "...";
			this.btnCiudad.UseVisualStyleBackColor = true;
			// 
			// btnProvincia
			// 
			this.btnProvincia.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnProvincia.Location = new System.Drawing.Point(305, 132);
			this.btnProvincia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnProvincia.Name = "btnProvincia";
			this.btnProvincia.Size = new System.Drawing.Size(29, 27);
			this.btnProvincia.TabIndex = 51;
			this.btnProvincia.Text = "...";
			this.btnProvincia.UseVisualStyleBackColor = true;
			// 
			// btnRegion
			// 
			this.btnRegion.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnRegion.Location = new System.Drawing.Point(305, 103);
			this.btnRegion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnRegion.Name = "btnRegion";
			this.btnRegion.Size = new System.Drawing.Size(29, 27);
			this.btnRegion.TabIndex = 50;
			this.btnRegion.Text = "...";
			this.btnRegion.UseVisualStyleBackColor = true;
			// 
			// tZonaVen
			// 
			this.tZonaVen.Location = new System.Drawing.Point(105, 212);
			this.tZonaVen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tZonaVen.Name = "tZonaVen";
			this.tZonaVen.Size = new System.Drawing.Size(200, 22);
			this.tZonaVen.TabIndex = 49;
			// 
			// tCliente
			// 
			this.tCliente.Location = new System.Drawing.Point(104, 185);
			this.tCliente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tCliente.Name = "tCliente";
			this.tCliente.Size = new System.Drawing.Size(200, 22);
			this.tCliente.TabIndex = 48;
			// 
			// tCiudad
			// 
			this.tCiudad.Location = new System.Drawing.Point(104, 158);
			this.tCiudad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.tCiudad.Name = "tCiudad";
			this.tCiudad.Size = new System.Drawing.Size(200, 22);
			this.tCiudad.TabIndex = 47;
			// 
			// cSucursal
			// 
			this.cSucursal.FormattingEnabled = true;
			this.cSucursal.ItemHeight = 16;
			this.cSucursal.Location = new System.Drawing.Point(85, 41);
			this.cSucursal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.cSucursal.Name = "cSucursal";
			this.cSucursal.Size = new System.Drawing.Size(248, 24);
			this.cSucursal.TabIndex = 46;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.ForeColor = System.Drawing.Color.Black;
			this.label11.Location = new System.Drawing.Point(11, 191);
			this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(85, 17);
			this.label11.TabIndex = 7;
			this.label11.Text = "Tipo cliente:";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.ForeColor = System.Drawing.Color.Black;
			this.label10.Location = new System.Drawing.Point(11, 80);
			this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(74, 17);
			this.label10.TabIndex = 6;
			this.label10.Text = "Vendedor:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.ForeColor = System.Drawing.Color.Black;
			this.label9.Location = new System.Drawing.Point(11, 164);
			this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(56, 17);
			this.label9.TabIndex = 5;
			this.label9.Text = "Ciudad:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.ForeColor = System.Drawing.Color.Black;
			this.label8.Location = new System.Drawing.Point(11, 50);
			this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(67, 17);
			this.label8.TabIndex = 4;
			this.label8.Text = "Sucursal:";
			// 
			// cVendedor
			// 
			this.cVendedor.FormattingEnabled = true;
			this.cVendedor.Location = new System.Drawing.Point(85, 70);
			this.cVendedor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.cVendedor.Name = "cVendedor";
			this.cVendedor.Size = new System.Drawing.Size(248, 24);
			this.cVendedor.TabIndex = 1;
			// 
			// reportViewer1
			// 
			this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.reportViewer1.Location = new System.Drawing.Point(0, 0);
			this.reportViewer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.reportViewer1.Name = "reportViewer1";
			this.reportViewer1.Size = new System.Drawing.Size(709, 791);
			this.reportViewer1.TabIndex = 0;
			// 
			// FrmListaCtasCorrientes
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1128, 846);
			this.Controls.Add(this.contenedor);
			this.Controls.Add(this.menu);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "FrmListaCtasCorrientes";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Lista general de saldos de cuentas";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.menu.ResumeLayout(false);
			this.menu.PerformLayout();
			this.contenedor.Panel1.ResumeLayout(false);
			this.contenedor.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.contenedor)).EndInit();
			this.contenedor.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.grupNiv.ResumeLayout(false);
			this.grupNiv.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton opciones;
        private System.Windows.Forms.ToolStripButton imprimir;
        private System.Windows.Forms.ToolStripButton salir;
        private System.Windows.Forms.SplitContainer contenedor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grupNiv;
        private System.Windows.Forms.ComboBox cSucursal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cVendedor;
        private System.Windows.Forms.TextBox tZonaVen;
        private System.Windows.Forms.TextBox tCliente;
        private System.Windows.Forms.TextBox tCiudad;
        private System.Windows.Forms.Button btnCiudad;
        private System.Windows.Forms.Button btnProvincia;
        private System.Windows.Forms.Button btnRegion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox adGarantias;
        private System.Windows.Forms.CheckBox adAnticipos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chUnaCuentaPorHoja;
        private System.Windows.Forms.CheckBox chkFechaVencimiento;
        private System.Windows.Forms.CheckBox chkValorInicial;
        private System.Windows.Forms.CheckBox chkDiasVencidos;
        private System.Windows.Forms.CheckBox adDocumentosFechaVencidos;
        private System.Windows.Forms.TextBox tProvincia;
        private System.Windows.Forms.TextBox tRegion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnZonaVentas;
        private System.Windows.Forms.Button btnTipoCliente;
        private System.Windows.Forms.CheckBox cheDetDoc;
        private System.Windows.Forms.Button btnGrupo3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tGrupo3;
        private System.Windows.Forms.Button btnGrupo2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tGrupo2;
        private System.Windows.Forms.Button btnGrupo1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tGrupo1;
        private System.Windows.Forms.CheckBox adVencimiento;
        private System.Windows.Forms.CheckBox chkValorVencido;
        private System.Windows.Forms.CheckBox adEmpleado;
        private System.Windows.Forms.RadioButton agGrupo3;
        private System.Windows.Forms.RadioButton agCiudad;
        private System.Windows.Forms.RadioButton agTipoCliente;
        private System.Windows.Forms.RadioButton agZonaVentas;
        private System.Windows.Forms.RadioButton agGrupo1;
        private System.Windows.Forms.RadioButton agGrupo2;
        private System.Windows.Forms.RadioButton agProvincia;
        private System.Windows.Forms.RadioButton agRegion;
        private System.Windows.Forms.RadioButton agVendedor;
        private System.Windows.Forms.RadioButton agSucursal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox cheSoloTotal;
        private System.Windows.Forms.CheckBox adDocumentosFechaVencidosTodos;
        private System.Windows.Forms.CheckBox tCuentasCobrar;
        private System.Windows.Forms.CheckBox tCuentasPagar;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.DateTimePicker tFecha;
    }
}

