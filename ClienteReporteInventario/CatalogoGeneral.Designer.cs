using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace ClienteReporteInventario
{
    partial class CatalogoGeneral
    {
        private System.ComponentModel.IContainer components = null;

        // ==========================================
        // CONTROLES PRINCIPALES
        // ==========================================
        private System.Windows.Forms.SplitContainer SplitContainer1;
        private System.Windows.Forms.Panel panelOpciones;
        private System.Windows.Forms.Panel panelDatos;
        private System.Windows.Forms.Panel panelCombos;

        // ==========================================
        // CONTROLES DE EMPRESA, SERVIDOR, SUCURSAL Y BODEGA
        // ==========================================
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Label lblServidor;
        private System.Windows.Forms.Label lblSucursal;
        private System.Windows.Forms.Label lblBodega;
        private System.Windows.Forms.ComboBox cmbEmpresa;
        private System.Windows.Forms.ComboBox cmbServidor;
        private System.Windows.Forms.ComboBox cmbSucursal;
        private System.Windows.Forms.ComboBox cboBodega;

        // ==========================================
        // GRUPO CONEXIÓN
        // ==========================================
        private System.Windows.Forms.GroupBox gbEmpresa;
        private System.Windows.Forms.Label lblConexion;
        private System.Windows.Forms.Label lblApi;

        // ==========================================
        // GRUPO FILTROS
        // ==========================================
        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Button btnFecha;
        private System.Windows.Forms.Label lblCodIni;
        private System.Windows.Forms.TextBox txtCodIni;
        private System.Windows.Forms.Button btnCodIni;
        private System.Windows.Forms.Label lblCodFin;
        private System.Windows.Forms.TextBox txtCodFin;
        private System.Windows.Forms.Button btnCodFin;
        private System.Windows.Forms.Label lblMedidas;
        private System.Windows.Forms.TextBox txtMedidas;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.CheckBox chkCategoria;
        private System.Windows.Forms.Label lblClase;
        private System.Windows.Forms.ComboBox cboClase;
        private System.Windows.Forms.CheckBox chkClase;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.ComboBox cboGrupo;
        private System.Windows.Forms.CheckBox chkGrupo;
        private System.Windows.Forms.Label lblSubgrupo;
        private System.Windows.Forms.ComboBox cboSubg;
        private System.Windows.Forms.CheckBox chkSubg;

        // ==========================================
        // CHECKBOXES ADICIONALES
        // ==========================================
        private System.Windows.Forms.CheckBox chkArtExis;
        private System.Windows.Forms.CheckBox chkUbicacion;
        private System.Windows.Forms.CheckBox Orden;

        // ==========================================
        // COSTEO (RadioButtons)
        // ==========================================
        private System.Windows.Forms.GroupBox gbCosteo;
        private System.Windows.Forms.RadioButton optCostoPro;
        private System.Windows.Forms.RadioButton optPvp1;
        private System.Windows.Forms.RadioButton optPvp2;
        private System.Windows.Forms.RadioButton optPvp3;
        private System.Windows.Forms.RadioButton optPvp4;
        private System.Windows.Forms.RadioButton optPvp5;
        private System.Windows.Forms.RadioButton optUltCost;
        private System.Windows.Forms.RadioButton optSinCost;

        // ==========================================
        // BOTONES
        // ==========================================
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnOpciones;

        // ==========================================
        // REPORTE Y PROGRESS
        // ==========================================
        private Microsoft.Reporting.WinForms.ReportViewer ReportViewer1;
        private System.Windows.Forms.ProgressBar progressBar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelOpciones = new System.Windows.Forms.Panel();
            this.gbCosteo = new System.Windows.Forms.GroupBox();
            this.optCostoPro = new System.Windows.Forms.RadioButton();
            this.optPvp1 = new System.Windows.Forms.RadioButton();
            this.optPvp2 = new System.Windows.Forms.RadioButton();
            this.optPvp3 = new System.Windows.Forms.RadioButton();
            this.optPvp4 = new System.Windows.Forms.RadioButton();
            this.optPvp5 = new System.Windows.Forms.RadioButton();
            this.optUltCost = new System.Windows.Forms.RadioButton();
            this.optSinCost = new System.Windows.Forms.RadioButton();
            this.panelCombos = new System.Windows.Forms.Panel();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.cmbEmpresa = new System.Windows.Forms.ComboBox();
            this.lblServidor = new System.Windows.Forms.Label();
            this.cmbServidor = new System.Windows.Forms.ComboBox();
            this.lblSucursal = new System.Windows.Forms.Label();
            this.cmbSucursal = new System.Windows.Forms.ComboBox();
            this.lblBodega = new System.Windows.Forms.Label();
            this.cboBodega = new System.Windows.Forms.ComboBox();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.btnFecha = new System.Windows.Forms.Button();
            this.lblCodIni = new System.Windows.Forms.Label();
            this.txtCodIni = new System.Windows.Forms.TextBox();
            this.btnCodIni = new System.Windows.Forms.Button();
            this.lblCodFin = new System.Windows.Forms.Label();
            this.txtCodFin = new System.Windows.Forms.TextBox();
            this.btnCodFin = new System.Windows.Forms.Button();
            this.lblMedidas = new System.Windows.Forms.Label();
            this.txtMedidas = new System.Windows.Forms.TextBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.chkCategoria = new System.Windows.Forms.CheckBox();
            this.lblClase = new System.Windows.Forms.Label();
            this.cboClase = new System.Windows.Forms.ComboBox();
            this.chkClase = new System.Windows.Forms.CheckBox();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.cboGrupo = new System.Windows.Forms.ComboBox();
            this.chkGrupo = new System.Windows.Forms.CheckBox();
            this.lblSubgrupo = new System.Windows.Forms.Label();
            this.cboSubg = new System.Windows.Forms.ComboBox();
            this.chkSubg = new System.Windows.Forms.CheckBox();
            this.chkArtExis = new System.Windows.Forms.CheckBox();
            this.chkUbicacion = new System.Windows.Forms.CheckBox();
            this.Orden = new System.Windows.Forms.CheckBox();
            this.gbEmpresa = new System.Windows.Forms.GroupBox();
            this.lblConexion = new System.Windows.Forms.Label();
            this.lblApi = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnOpciones = new System.Windows.Forms.Button();
            this.panelDatos = new System.Windows.Forms.Panel();
            this.ReportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.panelOpciones.SuspendLayout();
            this.gbCosteo.SuspendLayout();
            this.panelCombos.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            this.gbEmpresa.SuspendLayout();
            this.panelDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer1.Name = "SplitContainer1";
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.panelOpciones);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.panelDatos);
            this.SplitContainer1.Size = new System.Drawing.Size(1467, 846);
            this.SplitContainer1.SplitterDistance = 506;
            this.SplitContainer1.SplitterWidth = 5;
            this.SplitContainer1.TabIndex = 0;
            // 
            // panelOpciones
            // 
            this.panelOpciones.AutoScroll = true;
            this.panelOpciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.panelOpciones.Controls.Add(this.gbCosteo);
            this.panelOpciones.Controls.Add(this.panelCombos);
            this.panelOpciones.Controls.Add(this.gbFiltros);
            this.panelOpciones.Controls.Add(this.gbEmpresa);
            this.panelOpciones.Controls.Add(this.btnActualizar);
            this.panelOpciones.Controls.Add(this.btnExportarExcel);
            this.panelOpciones.Controls.Add(this.btnLimpiar);
            this.panelOpciones.Controls.Add(this.btnSalir);
            this.panelOpciones.Controls.Add(this.btnOpciones);
            this.panelOpciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOpciones.Location = new System.Drawing.Point(0, 0);
            this.panelOpciones.Name = "panelOpciones";
            this.panelOpciones.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.panelOpciones.Size = new System.Drawing.Size(506, 846);
            this.panelOpciones.TabIndex = 0;
            // 
            // gbCosteo
            // 
            this.gbCosteo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbCosteo.Controls.Add(this.optCostoPro);
            this.gbCosteo.Controls.Add(this.optPvp1);
            this.gbCosteo.Controls.Add(this.optPvp2);
            this.gbCosteo.Controls.Add(this.optPvp3);
            this.gbCosteo.Controls.Add(this.optPvp4);
            this.gbCosteo.Controls.Add(this.optPvp5);
            this.gbCosteo.Controls.Add(this.optUltCost);
            this.gbCosteo.Controls.Add(this.optSinCost);
            this.gbCosteo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCosteo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gbCosteo.Location = new System.Drawing.Point(13, 597);
            this.gbCosteo.Name = "gbCosteo";
            this.gbCosteo.Size = new System.Drawing.Size(667, 107);
            this.gbCosteo.TabIndex = 3;
            this.gbCosteo.TabStop = false;
            this.gbCosteo.Text = "Costeo";
            // 
            // optCostoPro
            // 
            this.optCostoPro.AutoSize = true;
            this.optCostoPro.Checked = true;
            this.optCostoPro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.optCostoPro.Location = new System.Drawing.Point(13, 27);
            this.optCostoPro.Name = "optCostoPro";
            this.optCostoPro.Size = new System.Drawing.Size(89, 21);
            this.optCostoPro.TabIndex = 0;
            this.optCostoPro.TabStop = true;
            this.optCostoPro.Text = "Promedio";
            this.optCostoPro.CheckedChanged += new System.EventHandler(this.optCostoPro_CheckedChanged);
            // 
            // optPvp1
            // 
            this.optPvp1.AutoSize = true;
            this.optPvp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.optPvp1.Location = new System.Drawing.Point(120, 27);
            this.optPvp1.Name = "optPvp1";
            this.optPvp1.Size = new System.Drawing.Size(81, 21);
            this.optPvp1.TabIndex = 1;
            this.optPvp1.Text = "Precio 1";
            this.optPvp1.CheckedChanged += new System.EventHandler(this.optPvp1_CheckedChanged);
            // 
            // optPvp2
            // 
            this.optPvp2.AutoSize = true;
            this.optPvp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.optPvp2.Location = new System.Drawing.Point(227, 27);
            this.optPvp2.Name = "optPvp2";
            this.optPvp2.Size = new System.Drawing.Size(81, 21);
            this.optPvp2.TabIndex = 2;
            this.optPvp2.Text = "Precio 2";
            this.optPvp2.CheckedChanged += new System.EventHandler(this.optPvp2_CheckedChanged);
            // 
            // optPvp3
            // 
            this.optPvp3.AutoSize = true;
            this.optPvp3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.optPvp3.Location = new System.Drawing.Point(333, 27);
            this.optPvp3.Name = "optPvp3";
            this.optPvp3.Size = new System.Drawing.Size(81, 21);
            this.optPvp3.TabIndex = 3;
            this.optPvp3.Text = "Precio 3";
            this.optPvp3.CheckedChanged += new System.EventHandler(this.optPvp3_CheckedChanged);
            // 
            // optPvp4
            // 
            this.optPvp4.AutoSize = true;
            this.optPvp4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.optPvp4.Location = new System.Drawing.Point(13, 62);
            this.optPvp4.Name = "optPvp4";
            this.optPvp4.Size = new System.Drawing.Size(81, 21);
            this.optPvp4.TabIndex = 4;
            this.optPvp4.Text = "Precio 4";
            this.optPvp4.CheckedChanged += new System.EventHandler(this.optPvp4_CheckedChanged);
            // 
            // optPvp5
            // 
            this.optPvp5.AutoSize = true;
            this.optPvp5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.optPvp5.Location = new System.Drawing.Point(120, 62);
            this.optPvp5.Name = "optPvp5";
            this.optPvp5.Size = new System.Drawing.Size(81, 21);
            this.optPvp5.TabIndex = 5;
            this.optPvp5.Text = "Precio 5";
            this.optPvp5.CheckedChanged += new System.EventHandler(this.optPvp5_CheckedChanged);
            // 
            // optUltCost
            // 
            this.optUltCost.AutoSize = true;
            this.optUltCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.optUltCost.Location = new System.Drawing.Point(227, 62);
            this.optUltCost.Name = "optUltCost";
            this.optUltCost.Size = new System.Drawing.Size(108, 21);
            this.optUltCost.TabIndex = 6;
            this.optUltCost.Text = "Último Costo";
            this.optUltCost.CheckedChanged += new System.EventHandler(this.optUltCost_CheckedChanged);
            // 
            // optSinCost
            // 
            this.optSinCost.AutoSize = true;
            this.optSinCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.optSinCost.Location = new System.Drawing.Point(333, 62);
            this.optSinCost.Name = "optSinCost";
            this.optSinCost.Size = new System.Drawing.Size(97, 21);
            this.optSinCost.TabIndex = 7;
            this.optSinCost.Text = "Sin Costeo";
            this.optSinCost.CheckedChanged += new System.EventHandler(this.optSinCost_CheckedChanged);
            // 
            // panelCombos
            // 
            this.panelCombos.BackColor = System.Drawing.Color.White;
            this.panelCombos.Controls.Add(this.lblEmpresa);
            this.panelCombos.Controls.Add(this.cmbEmpresa);
            this.panelCombos.Controls.Add(this.lblServidor);
            this.panelCombos.Controls.Add(this.cmbServidor);
            this.panelCombos.Controls.Add(this.lblSucursal);
            this.panelCombos.Controls.Add(this.cmbSucursal);
            this.panelCombos.Controls.Add(this.lblBodega);
            this.panelCombos.Controls.Add(this.cboBodega);
            this.panelCombos.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCombos.Location = new System.Drawing.Point(13, 442);
            this.panelCombos.Name = "panelCombos";
            this.panelCombos.Padding = new System.Windows.Forms.Padding(13, 6, 13, 6);
            this.panelCombos.Size = new System.Drawing.Size(667, 155);
            this.panelCombos.TabIndex = 1;
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblEmpresa.Location = new System.Drawing.Point(7, 6);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(80, 25);
            this.lblEmpresa.TabIndex = 0;
            this.lblEmpresa.Text = "Empresa:";
            // 
            // cmbEmpresa
            // 
            this.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbEmpresa.Location = new System.Drawing.Point(90, 3);
            this.cmbEmpresa.Name = "cmbEmpresa";
            this.cmbEmpresa.Size = new System.Drawing.Size(381, 26);
            this.cmbEmpresa.TabIndex = 1;
            this.cmbEmpresa.SelectedIndexChanged += new System.EventHandler(this.cmbEmpresa_SelectedIndexChanged);
            // 
            // lblServidor
            // 
            this.lblServidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblServidor.Location = new System.Drawing.Point(7, 42);
            this.lblServidor.Name = "lblServidor";
            this.lblServidor.Size = new System.Drawing.Size(80, 25);
            this.lblServidor.TabIndex = 2;
            this.lblServidor.Text = "Servidor:";
            // 
            // cmbServidor
            // 
            this.cmbServidor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbServidor.Location = new System.Drawing.Point(90, 39);
            this.cmbServidor.Name = "cmbServidor";
            this.cmbServidor.Size = new System.Drawing.Size(381, 26);
            this.cmbServidor.TabIndex = 3;
            this.cmbServidor.SelectedIndexChanged += new System.EventHandler(this.cmbServidor_SelectedIndexChanged);
            // 
            // lblSucursal
            // 
            this.lblSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblSucursal.Location = new System.Drawing.Point(7, 78);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(80, 25);
            this.lblSucursal.TabIndex = 4;
            this.lblSucursal.Text = "Sucursal:";
            // 
            // cmbSucursal
            // 
            this.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cmbSucursal.Location = new System.Drawing.Point(90, 75);
            this.cmbSucursal.Name = "cmbSucursal";
            this.cmbSucursal.Size = new System.Drawing.Size(381, 26);
            this.cmbSucursal.TabIndex = 5;
            this.cmbSucursal.SelectedIndexChanged += new System.EventHandler(this.cmbSucursal_SelectedIndexChanged);
            // 
            // lblBodega
            // 
            this.lblBodega.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblBodega.Location = new System.Drawing.Point(7, 114);
            this.lblBodega.Name = "lblBodega";
            this.lblBodega.Size = new System.Drawing.Size(80, 25);
            this.lblBodega.TabIndex = 6;
            this.lblBodega.Text = "Bodega:";
            // 
            // cboBodega
            // 
            this.cboBodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBodega.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cboBodega.Location = new System.Drawing.Point(90, 111);
            this.cboBodega.Name = "cboBodega";
            this.cboBodega.Size = new System.Drawing.Size(381, 26);
            this.cboBodega.TabIndex = 7;
            // 
            // gbFiltros
            // 
            this.gbFiltros.BackColor = System.Drawing.Color.White;
            this.gbFiltros.Controls.Add(this.lblFecha);
            this.gbFiltros.Controls.Add(this.txtFecha);
            this.gbFiltros.Controls.Add(this.btnFecha);
            this.gbFiltros.Controls.Add(this.lblCodIni);
            this.gbFiltros.Controls.Add(this.txtCodIni);
            this.gbFiltros.Controls.Add(this.btnCodIni);
            this.gbFiltros.Controls.Add(this.lblCodFin);
            this.gbFiltros.Controls.Add(this.txtCodFin);
            this.gbFiltros.Controls.Add(this.btnCodFin);
            this.gbFiltros.Controls.Add(this.lblMedidas);
            this.gbFiltros.Controls.Add(this.txtMedidas);
            this.gbFiltros.Controls.Add(this.lblCategoria);
            this.gbFiltros.Controls.Add(this.cboCategoria);
            this.gbFiltros.Controls.Add(this.chkCategoria);
            this.gbFiltros.Controls.Add(this.lblClase);
            this.gbFiltros.Controls.Add(this.cboClase);
            this.gbFiltros.Controls.Add(this.chkClase);
            this.gbFiltros.Controls.Add(this.lblGrupo);
            this.gbFiltros.Controls.Add(this.cboGrupo);
            this.gbFiltros.Controls.Add(this.chkGrupo);
            this.gbFiltros.Controls.Add(this.lblSubgrupo);
            this.gbFiltros.Controls.Add(this.cboSubg);
            this.gbFiltros.Controls.Add(this.chkSubg);
            this.gbFiltros.Controls.Add(this.chkArtExis);
            this.gbFiltros.Controls.Add(this.chkUbicacion);
            this.gbFiltros.Controls.Add(this.Orden);
            this.gbFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gbFiltros.Location = new System.Drawing.Point(13, 72);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(667, 370);
            this.gbFiltros.TabIndex = 2;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros";
            // 
            // lblFecha
            // 
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblFecha.Location = new System.Drawing.Point(13, 25);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(91, 17);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha Saldo:";
            // 
            // txtFecha
            // 
            this.txtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtFecha.Location = new System.Drawing.Point(120, 21);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(239, 23);
            this.txtFecha.TabIndex = 1;
            this.txtFecha.Text = "29/06/2026";
            // 
            // btnFecha
            // 
            this.btnFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnFecha.Location = new System.Drawing.Point(367, 20);
            this.btnFecha.Name = "btnFecha";
            this.btnFecha.Size = new System.Drawing.Size(87, 27);
            this.btnFecha.TabIndex = 2;
            this.btnFecha.Text = "Calendario";
            this.btnFecha.Click += new System.EventHandler(this.btnFecha_Click);
            // 
            // lblCodIni
            // 
            this.lblCodIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblCodIni.Location = new System.Drawing.Point(13, 64);
            this.lblCodIni.Name = "lblCodIni";
            this.lblCodIni.Size = new System.Drawing.Size(81, 17);
            this.lblCodIni.TabIndex = 3;
            this.lblCodIni.Text = "Código 1er:";
            // 
            // txtCodIni
            // 
            this.txtCodIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtCodIni.Location = new System.Drawing.Point(120, 60);
            this.txtCodIni.Name = "txtCodIni";
            this.txtCodIni.Size = new System.Drawing.Size(239, 23);
            this.txtCodIni.TabIndex = 4;
            // 
            // btnCodIni
            // 
            this.btnCodIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnCodIni.Location = new System.Drawing.Point(367, 59);
            this.btnCodIni.Name = "btnCodIni";
            this.btnCodIni.Size = new System.Drawing.Size(47, 27);
            this.btnCodIni.TabIndex = 5;
            this.btnCodIni.Text = "...";
            this.btnCodIni.Click += new System.EventHandler(this.btnCodIni_Click);
            // 
            // lblCodFin
            // 
            this.lblCodFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblCodFin.Location = new System.Drawing.Point(13, 103);
            this.lblCodFin.Name = "lblCodFin";
            this.lblCodFin.Size = new System.Drawing.Size(84, 17);
            this.lblCodFin.TabIndex = 6;
            this.lblCodFin.Text = "Código 2do:";
            // 
            // txtCodFin
            // 
            this.txtCodFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtCodFin.Location = new System.Drawing.Point(120, 100);
            this.txtCodFin.Name = "txtCodFin";
            this.txtCodFin.Size = new System.Drawing.Size(239, 23);
            this.txtCodFin.TabIndex = 7;
            // 
            // btnCodFin
            // 
            this.btnCodFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnCodFin.Location = new System.Drawing.Point(367, 98);
            this.btnCodFin.Name = "btnCodFin";
            this.btnCodFin.Size = new System.Drawing.Size(47, 27);
            this.btnCodFin.TabIndex = 8;
            this.btnCodFin.Text = "...";
            this.btnCodFin.Click += new System.EventHandler(this.btnCodFin_Click);
            // 
            // lblMedidas
            // 
            this.lblMedidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblMedidas.Location = new System.Drawing.Point(13, 133);
            this.lblMedidas.Name = "lblMedidas";
            this.lblMedidas.Size = new System.Drawing.Size(65, 17);
            this.lblMedidas.TabIndex = 9;
            this.lblMedidas.Text = "Medidas:";
            // 
            // txtMedidas
            // 
            this.txtMedidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.txtMedidas.Location = new System.Drawing.Point(120, 129);
            this.txtMedidas.Name = "txtMedidas";
            this.txtMedidas.Size = new System.Drawing.Size(292, 23);
            this.txtMedidas.TabIndex = 10;
            // 
            // lblCategoria
            // 
            this.lblCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblCategoria.Location = new System.Drawing.Point(13, 161);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(73, 17);
            this.lblCategoria.TabIndex = 11;
            this.lblCategoria.Text = "Categoría:";
            // 
            // cboCategoria
            // 
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cboCategoria.Location = new System.Drawing.Point(120, 157);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(265, 24);
            this.cboCategoria.TabIndex = 12;
            // 
            // chkCategoria
            // 
            this.chkCategoria.AutoSize = true;
            this.chkCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.chkCategoria.Location = new System.Drawing.Point(393, 159);
            this.chkCategoria.Name = "chkCategoria";
            this.chkCategoria.Size = new System.Drawing.Size(78, 21);
            this.chkCategoria.TabIndex = 13;
            this.chkCategoria.Text = "Mostrar";
            // 
            // lblClase
            // 
            this.lblClase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblClase.Location = new System.Drawing.Point(13, 192);
            this.lblClase.Name = "lblClase";
            this.lblClase.Size = new System.Drawing.Size(47, 17);
            this.lblClase.TabIndex = 14;
            this.lblClase.Text = "Clase:";
            // 
            // cboClase
            // 
            this.cboClase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cboClase.Location = new System.Drawing.Point(120, 188);
            this.cboClase.Name = "cboClase";
            this.cboClase.Size = new System.Drawing.Size(265, 24);
            this.cboClase.TabIndex = 15;
            // 
            // chkClase
            // 
            this.chkClase.AutoSize = true;
            this.chkClase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.chkClase.Location = new System.Drawing.Point(393, 189);
            this.chkClase.Name = "chkClase";
            this.chkClase.Size = new System.Drawing.Size(78, 21);
            this.chkClase.TabIndex = 16;
            this.chkClase.Text = "Mostrar";
            // 
            // lblGrupo
            // 
            this.lblGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblGrupo.Location = new System.Drawing.Point(13, 224);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(52, 17);
            this.lblGrupo.TabIndex = 17;
            this.lblGrupo.Text = "Grupo:";
            // 
            // cboGrupo
            // 
            this.cboGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cboGrupo.Location = new System.Drawing.Point(120, 220);
            this.cboGrupo.Name = "cboGrupo";
            this.cboGrupo.Size = new System.Drawing.Size(265, 24);
            this.cboGrupo.TabIndex = 18;
            // 
            // chkGrupo
            // 
            this.chkGrupo.AutoSize = true;
            this.chkGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.chkGrupo.Location = new System.Drawing.Point(393, 221);
            this.chkGrupo.Name = "chkGrupo";
            this.chkGrupo.Size = new System.Drawing.Size(78, 21);
            this.chkGrupo.TabIndex = 19;
            this.chkGrupo.Text = "Mostrar";
            // 
            // lblSubgrupo
            // 
            this.lblSubgrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblSubgrupo.Location = new System.Drawing.Point(13, 253);
            this.lblSubgrupo.Name = "lblSubgrupo";
            this.lblSubgrupo.Size = new System.Drawing.Size(74, 17);
            this.lblSubgrupo.TabIndex = 20;
            this.lblSubgrupo.Text = "Subgrupo:";
            // 
            // cboSubg
            // 
            this.cboSubg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cboSubg.Location = new System.Drawing.Point(120, 250);
            this.cboSubg.Name = "cboSubg";
            this.cboSubg.Size = new System.Drawing.Size(265, 24);
            this.cboSubg.TabIndex = 21;
            // 
            // chkSubg
            // 
            this.chkSubg.AutoSize = true;
            this.chkSubg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.chkSubg.Location = new System.Drawing.Point(393, 251);
            this.chkSubg.Name = "chkSubg";
            this.chkSubg.Size = new System.Drawing.Size(78, 21);
            this.chkSubg.TabIndex = 22;
            this.chkSubg.Text = "Mostrar";
            // 
            // chkArtExis
            // 
            this.chkArtExis.AutoSize = true;
            this.chkArtExis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.chkArtExis.Location = new System.Drawing.Point(120, 289);
            this.chkArtExis.Name = "chkArtExis";
            this.chkArtExis.Size = new System.Drawing.Size(177, 21);
            this.chkArtExis.TabIndex = 23;
            this.chkArtExis.Text = "Artículos con existencia";
            // 
            // chkUbicacion
            // 
            this.chkUbicacion.AutoSize = true;
            this.chkUbicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.chkUbicacion.Location = new System.Drawing.Point(120, 316);
            this.chkUbicacion.Name = "chkUbicacion";
            this.chkUbicacion.Size = new System.Drawing.Size(142, 21);
            this.chkUbicacion.TabIndex = 24;
            this.chkUbicacion.Text = "Mostrar ubicación";
            // 
            // Orden
            // 
            this.Orden.AutoSize = true;
            this.Orden.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.Orden.Location = new System.Drawing.Point(120, 344);
            this.Orden.Name = "Orden";
            this.Orden.Size = new System.Drawing.Size(136, 21);
            this.Orden.TabIndex = 25;
            this.Orden.Text = "Orden Alfabético";
            // 
            // gbEmpresa
            // 
            this.gbEmpresa.BackColor = System.Drawing.Color.White;
            this.gbEmpresa.Controls.Add(this.lblConexion);
            this.gbEmpresa.Controls.Add(this.lblApi);
            this.gbEmpresa.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.gbEmpresa.Location = new System.Drawing.Point(13, 12);
            this.gbEmpresa.Name = "gbEmpresa";
            this.gbEmpresa.Size = new System.Drawing.Size(667, 60);
            this.gbEmpresa.TabIndex = 4;
            this.gbEmpresa.TabStop = false;
            this.gbEmpresa.Text = "Conexión";
            // 
            // lblConexion
            // 
            this.lblConexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblConexion.Location = new System.Drawing.Point(13, 27);
            this.lblConexion.Name = "lblConexion";
            this.lblConexion.Size = new System.Drawing.Size(96, 17);
            this.lblConexion.TabIndex = 0;
            this.lblConexion.Text = "Conectando...";
            // 
            // lblApi
            // 
            this.lblApi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblApi.Location = new System.Drawing.Point(333, 27);
            this.lblApi.Name = "lblApi";
            this.lblApi.Size = new System.Drawing.Size(116, 17);
            this.lblApi.TabIndex = 1;
            this.lblApi.Text = "Verificando API...";
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(13, 761);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(133, 43);
            this.btnActualizar.TabIndex = 5;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(80)))));
            this.btnExportarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportarExcel.Location = new System.Drawing.Point(160, 761);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(133, 43);
            this.btnExportarExcel.TabIndex = 6;
            this.btnExportarExcel.Text = "Exportar Excel";
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(307, 761);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(120, 43);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(440, 761);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(120, 43);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnOpciones
            // 
            this.btnOpciones.Location = new System.Drawing.Point(573, 761);
            this.btnOpciones.Name = "btnOpciones";
            this.btnOpciones.Size = new System.Drawing.Size(120, 43);
            this.btnOpciones.TabIndex = 9;
            this.btnOpciones.Text = "Opciones";
            this.btnOpciones.Visible = false;
            this.btnOpciones.Click += new System.EventHandler(this.btnOpciones_Click);
            // 
            // panelDatos
            // 
            this.panelDatos.BackColor = System.Drawing.Color.White;
            this.panelDatos.Controls.Add(this.ReportViewer1);
            this.panelDatos.Controls.Add(this.progressBar);
            this.panelDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDatos.Location = new System.Drawing.Point(0, 0);
            this.panelDatos.Name = "panelDatos";
            this.panelDatos.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.panelDatos.Size = new System.Drawing.Size(956, 846);
            this.panelDatos.TabIndex = 0;
            // 
            // ReportViewer1
            // 
            this.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportViewer1.Location = new System.Drawing.Point(7, 6);
            this.ReportViewer1.Name = "ReportViewer1";
            this.ReportViewer1.Size = new System.Drawing.Size(942, 822);
            this.ReportViewer1.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(7, 828);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(942, 12);
            this.progressBar.TabIndex = 1;
            this.progressBar.Visible = false;
            // 
            // CatalogoGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 846);
            this.Controls.Add(this.SplitContainer1);
            this.Name = "CatalogoGeneral";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Inventario";
            this.Load += new System.EventHandler(this.CatalogoGeneral_Load);
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            this.panelOpciones.ResumeLayout(false);
            this.gbCosteo.ResumeLayout(false);
            this.gbCosteo.PerformLayout();
            this.panelCombos.ResumeLayout(false);
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.gbEmpresa.ResumeLayout(false);
            this.panelDatos.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}