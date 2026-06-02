
namespace DaxInvent
{
    partial class repCatalogo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(repCatalogo));
            this.chkArtExis = new System.Windows.Forms.CheckBox();
            this.optSinCost = new System.Windows.Forms.RadioButton();
            this.optPvp4 = new System.Windows.Forms.RadioButton();
            this.optPvp2 = new System.Windows.Forms.RadioButton();
            this.optUltCost = new System.Windows.Forms.RadioButton();
            this.ValoracionInventario = new System.Windows.Forms.GroupBox();
            this.optPvp5 = new System.Windows.Forms.RadioButton();
            this.optPvp3 = new System.Windows.Forms.RadioButton();
            this.optPvp1 = new System.Windows.Forms.RadioButton();
            this.optCostoPro = new System.Windows.Forms.RadioButton();
            this.cboGrupo = new System.Windows.Forms.ComboBox();
            this.btnCodFin = new System.Windows.Forms.Button();
            this.txtCodFin = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cboBodega = new System.Windows.Forms.ComboBox();
            this.ReportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnCodIni = new System.Windows.Forms.Button();
            this.txtcodIni = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.chkSubg = new System.Windows.Forms.CheckBox();
            this.chkGrupo = new System.Windows.Forms.CheckBox();
            this.btnMed = new System.Windows.Forms.Button();
            this.chkClase = new System.Windows.Forms.CheckBox();
            this.cboSubg = new System.Windows.Forms.ComboBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtMedidas = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.chkCategoria = new System.Windows.Forms.CheckBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtFecha = new System.Windows.Forms.DateTimePicker();
            this.chkPiezas = new System.Windows.Forms.CheckBox();
            this.ArticulosGrupos = new System.Windows.Forms.GroupBox();
            this.cboClase = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.chkUbicacion = new System.Windows.Forms.CheckBox();
            this.Orden = new System.Windows.Forms.CheckBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnOpciones = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Actualizar = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ValoracionInventario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.ArticulosGrupos.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkArtExis
            // 
            this.chkArtExis.AutoSize = true;
            this.chkArtExis.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkArtExis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkArtExis.Location = new System.Drawing.Point(46, 48);
            this.chkArtExis.Name = "chkArtExis";
            this.chkArtExis.Size = new System.Drawing.Size(168, 17);
            this.chkArtExis.TabIndex = 45;
            this.chkArtExis.Text = "Incluir artículos sin Existencia:";
            this.chkArtExis.UseVisualStyleBackColor = true;
            // 
            // optSinCost
            // 
            this.optSinCost.AutoSize = true;
            this.optSinCost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.optSinCost.Location = new System.Drawing.Point(117, 89);
            this.optSinCost.Name = "optSinCost";
            this.optSinCost.Size = new System.Drawing.Size(97, 17);
            this.optSinCost.TabIndex = 7;
            this.optSinCost.Text = "Sin Costo         ";
            this.optSinCost.UseVisualStyleBackColor = true;
            this.optSinCost.CheckedChanged += new System.EventHandler(this.optSinCost_CheckedChanged);
            // 
            // optPvp4
            // 
            this.optPvp4.AutoSize = true;
            this.optPvp4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.optPvp4.Location = new System.Drawing.Point(116, 65);
            this.optPvp4.Name = "optPvp4";
            this.optPvp4.Size = new System.Drawing.Size(98, 17);
            this.optPvp4.TabIndex = 6;
            this.optPvp4.Text = "Precio Venta 4 ";
            this.optPvp4.UseVisualStyleBackColor = true;
            this.optPvp4.CheckedChanged += new System.EventHandler(this.optPvp4_CheckedChanged);
            // 
            // optPvp2
            // 
            this.optPvp2.AutoSize = true;
            this.optPvp2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.optPvp2.Location = new System.Drawing.Point(116, 42);
            this.optPvp2.Name = "optPvp2";
            this.optPvp2.Size = new System.Drawing.Size(98, 17);
            this.optPvp2.TabIndex = 5;
            this.optPvp2.Text = "Precio Venta 2 ";
            this.optPvp2.UseVisualStyleBackColor = true;
            this.optPvp2.Click += new System.EventHandler(this.optPvp2_CheckedChanged);
            // 
            // optUltCost
            // 
            this.optUltCost.AutoSize = true;
            this.optUltCost.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.optUltCost.Location = new System.Drawing.Point(115, 19);
            this.optUltCost.Name = "optUltCost";
            this.optUltCost.Size = new System.Drawing.Size(99, 17);
            this.optUltCost.TabIndex = 4;
            this.optUltCost.Text = "Ultimo Costo     ";
            this.optUltCost.UseVisualStyleBackColor = true;
            this.optUltCost.Click += new System.EventHandler(this.optUltCost_CheckedChanged);
            // 
            // ValoracionInventario
            // 
            this.ValoracionInventario.Controls.Add(this.optSinCost);
            this.ValoracionInventario.Controls.Add(this.optPvp4);
            this.ValoracionInventario.Controls.Add(this.optPvp2);
            this.ValoracionInventario.Controls.Add(this.optUltCost);
            this.ValoracionInventario.Controls.Add(this.optPvp5);
            this.ValoracionInventario.Controls.Add(this.optPvp3);
            this.ValoracionInventario.Controls.Add(this.optPvp1);
            this.ValoracionInventario.Controls.Add(this.optCostoPro);
            this.ValoracionInventario.Location = new System.Drawing.Point(40, 305);
            this.ValoracionInventario.Name = "ValoracionInventario";
            this.ValoracionInventario.Size = new System.Drawing.Size(221, 112);
            this.ValoracionInventario.TabIndex = 44;
            this.ValoracionInventario.TabStop = false;
            this.ValoracionInventario.Text = "Valoración del inventario:";
            // 
            // optPvp5
            // 
            this.optPvp5.AutoSize = true;
            this.optPvp5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.optPvp5.Location = new System.Drawing.Point(5, 88);
            this.optPvp5.Name = "optPvp5";
            this.optPvp5.Size = new System.Drawing.Size(98, 17);
            this.optPvp5.TabIndex = 3;
            this.optPvp5.Text = "Precio Venta 5 ";
            this.optPvp5.UseVisualStyleBackColor = true;
            this.optPvp5.Click += new System.EventHandler(this.optPvp5_CheckedChanged);
            // 
            // optPvp3
            // 
            this.optPvp3.AutoSize = true;
            this.optPvp3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.optPvp3.Location = new System.Drawing.Point(5, 65);
            this.optPvp3.Name = "optPvp3";
            this.optPvp3.Size = new System.Drawing.Size(98, 17);
            this.optPvp3.TabIndex = 2;
            this.optPvp3.Text = "Precio Venta 3 ";
            this.optPvp3.UseVisualStyleBackColor = true;
            this.optPvp3.CheckedChanged += new System.EventHandler(this.optPvp3_CheckedChanged);
            // 
            // optPvp1
            // 
            this.optPvp1.AutoSize = true;
            this.optPvp1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.optPvp1.Location = new System.Drawing.Point(5, 42);
            this.optPvp1.Name = "optPvp1";
            this.optPvp1.Size = new System.Drawing.Size(98, 17);
            this.optPvp1.TabIndex = 1;
            this.optPvp1.Text = "Precio Venta 1 ";
            this.optPvp1.UseVisualStyleBackColor = true;
            this.optPvp1.CheckedChanged += new System.EventHandler(this.optPvp1_CheckedChanged);
            // 
            // optCostoPro
            // 
            this.optCostoPro.AutoSize = true;
            this.optCostoPro.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.optCostoPro.Checked = true;
            this.optCostoPro.Location = new System.Drawing.Point(4, 19);
            this.optCostoPro.Name = "optCostoPro";
            this.optCostoPro.Size = new System.Drawing.Size(99, 17);
            this.optCostoPro.TabIndex = 0;
            this.optCostoPro.TabStop = true;
            this.optCostoPro.Text = "Costo Promedio";
            this.optCostoPro.UseVisualStyleBackColor = true;
            this.optCostoPro.Click += new System.EventHandler(this.optCostoPro_CheckedChanged);
            // 
            // cboGrupo
            // 
            this.cboGrupo.FormattingEnabled = true;
            this.cboGrupo.Location = new System.Drawing.Point(62, 62);
            this.cboGrupo.Name = "cboGrupo";
            this.cboGrupo.Size = new System.Drawing.Size(157, 21);
            this.cboGrupo.TabIndex = 24;
            // 
            // btnCodFin
            // 
            this.btnCodFin.Location = new System.Drawing.Point(217, 130);
            this.btnCodFin.Name = "btnCodFin";
            this.btnCodFin.Size = new System.Drawing.Size(21, 21);
            this.btnCodFin.TabIndex = 36;
            this.btnCodFin.Text = "...";
            this.btnCodFin.UseVisualStyleBackColor = true;
            this.btnCodFin.Click += new System.EventHandler(this.btnCodFin_Click);
            // 
            // txtCodFin
            // 
            this.txtCodFin.Location = new System.Drawing.Point(63, 130);
            this.txtCodFin.Name = "txtCodFin";
            this.txtCodFin.Size = new System.Drawing.Size(155, 20);
            this.txtCodFin.TabIndex = 35;
            this.txtCodFin.TextChanged += new System.EventHandler(this.txtArtFin_TextChanged);
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(4, 133);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(32, 13);
            this.Label8.TabIndex = 34;
            this.Label8.Text = "Final:";
            // 
            // cboBodega
            // 
            this.cboBodega.FormattingEnabled = true;
            this.cboBodega.Location = new System.Drawing.Point(457, 11);
            this.cboBodega.Name = "cboBodega";
            this.cboBodega.Size = new System.Drawing.Size(163, 21);
            this.cboBodega.TabIndex = 5;
            // 
            // ReportViewer1
            // 
            this.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.ReportViewer1.Name = "ReportViewer1";
            this.ReportViewer1.Size = new System.Drawing.Size(565, 519);
            this.ReportViewer1.TabIndex = 1;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(14, 9);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(61, 13);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "A la Fecha:";
            // 
            // btnCodIni
            // 
            this.btnCodIni.Location = new System.Drawing.Point(216, 107);
            this.btnCodIni.Name = "btnCodIni";
            this.btnCodIni.Size = new System.Drawing.Size(21, 21);
            this.btnCodIni.TabIndex = 33;
            this.btnCodIni.Text = "...";
            this.btnCodIni.UseVisualStyleBackColor = true;
            this.btnCodIni.Click += new System.EventHandler(this.btnCodIni_Click);
            // 
            // txtcodIni
            // 
            this.txtcodIni.Location = new System.Drawing.Point(63, 107);
            this.txtcodIni.Name = "txtcodIni";
            this.txtcodIni.Size = new System.Drawing.Size(155, 20);
            this.txtcodIni.TabIndex = 32;
            this.txtcodIni.TextChanged += new System.EventHandler(this.txtArtIni_TextChanged);
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(4, 110);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(37, 13);
            this.Label7.TabIndex = 31;
            this.Label7.Text = "Inicial:";
            // 
            // chkSubg
            // 
            this.chkSubg.AutoSize = true;
            this.chkSubg.Location = new System.Drawing.Point(225, 87);
            this.chkSubg.Name = "chkSubg";
            this.chkSubg.Size = new System.Drawing.Size(60, 17);
            this.chkSubg.TabIndex = 30;
            this.chkSubg.Text = "Agrupa";
            this.chkSubg.UseVisualStyleBackColor = true;
            // 
            // chkGrupo
            // 
            this.chkGrupo.AutoSize = true;
            this.chkGrupo.Location = new System.Drawing.Point(225, 65);
            this.chkGrupo.Name = "chkGrupo";
            this.chkGrupo.Size = new System.Drawing.Size(60, 17);
            this.chkGrupo.TabIndex = 29;
            this.chkGrupo.Text = "Agrupa";
            this.chkGrupo.UseVisualStyleBackColor = true;
            // 
            // btnMed
            // 
            this.btnMed.Location = new System.Drawing.Point(226, 457);
            this.btnMed.Name = "btnMed";
            this.btnMed.Size = new System.Drawing.Size(21, 21);
            this.btnMed.TabIndex = 48;
            this.btnMed.Text = "...";
            this.btnMed.UseVisualStyleBackColor = true;
            this.btnMed.Visible = false;
            // 
            // chkClase
            // 
            this.chkClase.AutoSize = true;
            this.chkClase.Location = new System.Drawing.Point(225, 42);
            this.chkClase.Name = "chkClase";
            this.chkClase.Size = new System.Drawing.Size(60, 17);
            this.chkClase.TabIndex = 28;
            this.chkClase.Text = "Agrupa";
            this.chkClase.UseVisualStyleBackColor = true;
            // 
            // cboSubg
            // 
            this.cboSubg.FormattingEnabled = true;
            this.cboSubg.Location = new System.Drawing.Point(62, 84);
            this.cboSubg.Name = "cboSubg";
            this.cboSubg.Size = new System.Drawing.Size(157, 21);
            this.cboSubg.TabIndex = 26;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(5, 87);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(56, 13);
            this.Label6.TabIndex = 25;
            this.Label6.Text = "Subgrupo:";
            // 
            // txtMedidas
            // 
            this.txtMedidas.Location = new System.Drawing.Point(101, 457);
            this.txtMedidas.Name = "txtMedidas";
            this.txtMedidas.Size = new System.Drawing.Size(125, 20);
            this.txtMedidas.TabIndex = 47;
            this.txtMedidas.Visible = false;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(52, 460);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(50, 13);
            this.Label9.TabIndex = 46;
            this.Label9.Text = "Medidas:";
            this.Label9.Visible = false;
            // 
            // chkCategoria
            // 
            this.chkCategoria.AutoSize = true;
            this.chkCategoria.Location = new System.Drawing.Point(225, 20);
            this.chkCategoria.Name = "chkCategoria";
            this.chkCategoria.Size = new System.Drawing.Size(60, 17);
            this.chkCategoria.TabIndex = 27;
            this.chkCategoria.Text = "Agrupa";
            this.chkCategoria.UseVisualStyleBackColor = true;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(5, 65);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(39, 13);
            this.Label5.TabIndex = 23;
            this.Label5.Text = "Grupo:";
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SplitContainer1.IsSplitterFixed = true;
            this.SplitContainer1.Location = new System.Drawing.Point(0, 38);
            this.SplitContainer1.Name = "SplitContainer1";
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.SplitContainer1.Panel1.Controls.Add(this.txtFecha);
            this.SplitContainer1.Panel1.Controls.Add(this.chkPiezas);
            this.SplitContainer1.Panel1.Controls.Add(this.ArticulosGrupos);
            this.SplitContainer1.Panel1.Controls.Add(this.chkUbicacion);
            this.SplitContainer1.Panel1.Controls.Add(this.Orden);
            this.SplitContainer1.Panel1.Controls.Add(this.chkArtExis);
            this.SplitContainer1.Panel1.Controls.Add(this.ValoracionInventario);
            this.SplitContainer1.Panel1.Controls.Add(this.txtMedidas);
            this.SplitContainer1.Panel1.Controls.Add(this.Label9);
            this.SplitContainer1.Panel1.Controls.Add(this.btnMed);
            this.SplitContainer1.Panel1.Controls.Add(this.Label2);
            this.SplitContainer1.Panel1MinSize = 20;
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.ReportViewer1);
            this.SplitContainer1.Size = new System.Drawing.Size(869, 519);
            this.SplitContainer1.SplitterDistance = 300;
            this.SplitContainer1.TabIndex = 7;
            // 
            // txtFecha
            // 
            this.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFecha.Location = new System.Drawing.Point(78, 7);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(101, 20);
            this.txtFecha.TabIndex = 53;
            // 
            // chkPiezas
            // 
            this.chkPiezas.AutoSize = true;
            this.chkPiezas.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkPiezas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkPiezas.Location = new System.Drawing.Point(44, 98);
            this.chkPiezas.Name = "chkPiezas";
            this.chkPiezas.Size = new System.Drawing.Size(145, 17);
            this.chkPiezas.TabIndex = 52;
            this.chkPiezas.Text = "Incluir columna de piezas";
            this.chkPiezas.UseVisualStyleBackColor = true;
            // 
            // ArticulosGrupos
            // 
            this.ArticulosGrupos.Controls.Add(this.cboGrupo);
            this.ArticulosGrupos.Controls.Add(this.btnCodFin);
            this.ArticulosGrupos.Controls.Add(this.txtCodFin);
            this.ArticulosGrupos.Controls.Add(this.Label8);
            this.ArticulosGrupos.Controls.Add(this.btnCodIni);
            this.ArticulosGrupos.Controls.Add(this.txtcodIni);
            this.ArticulosGrupos.Controls.Add(this.Label7);
            this.ArticulosGrupos.Controls.Add(this.chkSubg);
            this.ArticulosGrupos.Controls.Add(this.chkGrupo);
            this.ArticulosGrupos.Controls.Add(this.chkClase);
            this.ArticulosGrupos.Controls.Add(this.chkCategoria);
            this.ArticulosGrupos.Controls.Add(this.cboSubg);
            this.ArticulosGrupos.Controls.Add(this.Label6);
            this.ArticulosGrupos.Controls.Add(this.Label5);
            this.ArticulosGrupos.Controls.Add(this.cboClase);
            this.ArticulosGrupos.Controls.Add(this.Label4);
            this.ArticulosGrupos.Controls.Add(this.cboCategoria);
            this.ArticulosGrupos.Controls.Add(this.Label3);
            this.ArticulosGrupos.Location = new System.Drawing.Point(3, 133);
            this.ArticulosGrupos.Name = "ArticulosGrupos";
            this.ArticulosGrupos.Size = new System.Drawing.Size(287, 166);
            this.ArticulosGrupos.TabIndex = 51;
            this.ArticulosGrupos.TabStop = false;
            this.ArticulosGrupos.Text = "Opciones de selección de artículos";
            // 
            // cboClase
            // 
            this.cboClase.FormattingEnabled = true;
            this.cboClase.Location = new System.Drawing.Point(62, 40);
            this.cboClase.Name = "cboClase";
            this.cboClase.Size = new System.Drawing.Size(157, 21);
            this.cboClase.TabIndex = 22;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(6, 43);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(36, 13);
            this.Label4.TabIndex = 21;
            this.Label4.Text = "Clase:";
            // 
            // cboCategoria
            // 
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(62, 18);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(157, 21);
            this.cboCategoria.TabIndex = 20;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(5, 21);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(55, 13);
            this.Label3.TabIndex = 19;
            this.Label3.Text = "Categoria:";
            // 
            // chkUbicacion
            // 
            this.chkUbicacion.AutoSize = true;
            this.chkUbicacion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkUbicacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkUbicacion.Location = new System.Drawing.Point(45, 81);
            this.chkUbicacion.Name = "chkUbicacion";
            this.chkUbicacion.Size = new System.Drawing.Size(144, 17);
            this.chkUbicacion.TabIndex = 50;
            this.chkUbicacion.Text = "Incluir ubicación general:";
            this.chkUbicacion.UseVisualStyleBackColor = true;
            // 
            // Orden
            // 
            this.Orden.AutoSize = true;
            this.Orden.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Orden.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Orden.Location = new System.Drawing.Point(47, 64);
            this.Orden.Name = "Orden";
            this.Orden.Size = new System.Drawing.Size(142, 17);
            this.Orden.TabIndex = 49;
            this.Orden.Text = "Ordenar alfabeticamente";
            this.Orden.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(407, 14);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(47, 13);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "Bodega:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label10.Location = new System.Drawing.Point(404, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Bodega:";
            // 
            // btnOpciones
            // 
            this.btnOpciones.CheckOnClick = true;
            this.btnOpciones.Image = ((System.Drawing.Image)(resources.GetObject("btnOpciones.Image")));
            this.btnOpciones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpciones.Name = "btnOpciones";
            this.btnOpciones.Size = new System.Drawing.Size(61, 35);
            this.btnOpciones.Text = "Opciones";
            this.btnOpciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOpciones.Click += new System.EventHandler(this.btnOpciones_Click);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // Actualizar
            // 
            this.Actualizar.Checked = true;
            this.Actualizar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Actualizar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Actualizar.Image = ((System.Drawing.Image)(resources.GetObject("Actualizar.Image")));
            this.Actualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Actualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Actualizar.Name = "Actualizar";
            this.Actualizar.Size = new System.Drawing.Size(52, 35);
            this.Actualizar.Text = "Generar";
            this.Actualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Actualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.Actualizar.Click += new System.EventHandler(this.Actualizar_Click);
            // 
            // ToolStripSeparator4
            // 
            this.ToolStripSeparator4.Name = "ToolStripSeparator4";
            this.ToolStripSeparator4.Size = new System.Drawing.Size(6, 38);
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
            // ToolStrip1
            // 
            this.ToolStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpciones,
            this.ToolStripSeparator2,
            this.Actualizar,
            this.ToolStripSeparator4,
            this.btnSalir});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(869, 38);
            this.ToolStrip1.TabIndex = 6;
            this.ToolStrip1.Text = "ToolStrip1";
            this.ToolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolStrip1_ItemClicked);
            // 
            // repCatalogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 557);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.SplitContainer1);
            this.Controls.Add(this.cboBodega);
            this.Controls.Add(this.ToolStrip1);
            this.Controls.Add(this.Label1);
            this.Name = "repCatalogo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REPORTE CATALAGO DE ARTÍCULOS DE INVENTARIO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.repCatalogo_Load);
            this.ValoracionInventario.ResumeLayout(false);
            this.ValoracionInventario.PerformLayout();
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel1.PerformLayout();
            this.SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            this.ArticulosGrupos.ResumeLayout(false);
            this.ArticulosGrupos.PerformLayout();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.CheckBox chkArtExis;
        internal System.Windows.Forms.RadioButton optSinCost;
        internal System.Windows.Forms.RadioButton optPvp4;
        internal System.Windows.Forms.RadioButton optPvp2;
        internal System.Windows.Forms.RadioButton optUltCost;
        internal System.Windows.Forms.GroupBox ValoracionInventario;
        internal System.Windows.Forms.RadioButton optPvp5;
        internal System.Windows.Forms.RadioButton optPvp3;
        internal System.Windows.Forms.RadioButton optPvp1;
        internal System.Windows.Forms.RadioButton optCostoPro;
        internal System.Windows.Forms.ComboBox cboGrupo;
        internal System.Windows.Forms.Button btnCodFin;
        internal System.Windows.Forms.TextBox txtCodFin;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.ToolTip ToolTip1;
        internal System.Windows.Forms.ComboBox cboBodega;
        private Microsoft.Reporting.WinForms.ReportViewer ReportViewer1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button btnCodIni;
        internal System.Windows.Forms.TextBox txtcodIni;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.CheckBox chkSubg;
        internal System.Windows.Forms.CheckBox chkGrupo;
        internal System.Windows.Forms.Button btnMed;
        internal System.Windows.Forms.CheckBox chkClase;
        internal System.Windows.Forms.ComboBox cboSubg;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox txtMedidas;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.CheckBox chkCategoria;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.SplitContainer SplitContainer1;
        private System.Windows.Forms.DateTimePicker txtFecha;
        internal System.Windows.Forms.CheckBox chkPiezas;
        internal System.Windows.Forms.GroupBox ArticulosGrupos;
        internal System.Windows.Forms.ComboBox cboClase;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ComboBox cboCategoria;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.CheckBox chkUbicacion;
        internal System.Windows.Forms.CheckBox Orden;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripButton btnOpciones;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        private System.Windows.Forms.ToolStripButton Actualizar;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnSalir;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
    }
}