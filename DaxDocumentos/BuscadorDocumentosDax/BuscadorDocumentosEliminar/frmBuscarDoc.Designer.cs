using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace BuscadorDocumentos
{
    public partial class frmBuscarDoc : Form
    {

        // Form reemplaza a Dispose para limpiar la lista de componentes.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is object)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Requerido por el Diseñador de Windows Forms
        private System.ComponentModel.IContainer components;

        // NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
        // Se puede modificar usando el Diseñador de Windows Forms.  
        // No lo modifique con el editor de código.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarDoc));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._btnAceptar = new System.Windows.Forms.ToolStripButton();
            this._btnBuscar = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmbAutorizaciones = new System.Windows.Forms.ToolStripComboBox();
            this.cmbActivos = new System.Windows.Forms.ToolStripComboBox();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._btnSalir = new System.Windows.Forms.ToolStripButton();
            this._txtvalor = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this._txtDetalle = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtArticuloNombre = new System.Windows.Forms.TextBox();
            this._btnArticuloCod = new System.Windows.Forms.Button();
            this._txtArtCodigo = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.cboPtoVenta = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this._txtFechaFin = new System.Windows.Forms.DateTimePicker();
            this._txtFechaIn = new System.Windows.Forms.DateTimePicker();
            this.txtNumDoc = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.cboTipoDoc = new System.Windows.Forms.ComboBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.cboSucursal = new System.Windows.Forms.ComboBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.cboBodega = new System.Windows.Forms.ComboBox();
            this.Label8 = new System.Windows.Forms.Label();
            this._btnServicioCod = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this._txtClienteCod = new System.Windows.Forms.TextBox();
            this.txtClienteNombre = new System.Windows.Forms.TextBox();
            this._btnClienteCod = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this._malla = new System.Windows.Forms.DataGridView();
            this.TableLayoutPanel1.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._malla)).BeginInit();
            this.SuspendLayout();
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
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(848, 38);
            this.TableLayoutPanel1.TabIndex = 0;
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue;
            this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip1.ImageScalingSize = new System.Drawing.Size(24, 32);
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripSeparator2,
            this._btnAceptar,
            this._btnBuscar,
            this.ToolStripSeparator3,
            this.cmbAutorizaciones,
            this.cmbActivos,
            this.ToolStripSeparator1,
            this._btnSalir});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(848, 38);
            this.ToolStrip1.TabIndex = 1;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // _btnAceptar
            // 
            this._btnAceptar.ForeColor = System.Drawing.Color.White;
            this._btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("_btnAceptar.Image")));
            this._btnAceptar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnAceptar.Name = "_btnAceptar";
            this._btnAceptar.Size = new System.Drawing.Size(52, 35);
            this._btnAceptar.Text = "Aceptar";
            this._btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // _btnBuscar
            // 
            this._btnBuscar.ForeColor = System.Drawing.Color.White;
            this._btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("_btnBuscar.Image")));
            this._btnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnBuscar.Name = "_btnBuscar";
            this._btnBuscar.Size = new System.Drawing.Size(46, 35);
            this._btnBuscar.Text = "Buscar";
            this._btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.ForeColor = System.Drawing.Color.White;
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // cmbAutorizaciones
            // 
            this.cmbAutorizaciones.Items.AddRange(new object[] {
            "Todos los documentos",
            "Documentos sin autorización",
            "Documentos autorizados"});
            this.cmbAutorizaciones.Name = "cmbAutorizaciones";
            this.cmbAutorizaciones.Size = new System.Drawing.Size(160, 38);
            // 
            // cmbActivos
            // 
            this.cmbActivos.AutoCompleteCustomSource.AddRange(new string[] {
            "Todos los documentos",
            "Documentos activos",
            "Documentos anulados"});
            this.cmbActivos.Items.AddRange(new object[] {
            "Todos los documentos",
            "Documentos activos",
            "Documentos anulados"});
            this.cmbActivos.Name = "cmbActivos";
            this.cmbActivos.Size = new System.Drawing.Size(160, 38);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.ForeColor = System.Drawing.Color.White;
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // _btnSalir
            // 
            this._btnSalir.ForeColor = System.Drawing.Color.White;
            this._btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("_btnSalir.Image")));
            this._btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnSalir.Name = "_btnSalir";
            this._btnSalir.Size = new System.Drawing.Size(75, 35);
            this._btnSalir.Text = "   Salir   ";
            this._btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this._btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // _txtvalor
            // 
            this._txtvalor.Location = new System.Drawing.Point(439, 71);
            this._txtvalor.Name = "_txtvalor";
            this._txtvalor.Size = new System.Drawing.Size(81, 20);
            this._txtvalor.TabIndex = 10;
            this._txtvalor.TextChanged += new System.EventHandler(this.txtvalor_TextChanged);
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(399, 74);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(34, 13);
            this.Label9.TabIndex = 57;
            this.Label9.Text = "Valor:";
            // 
            // _txtDetalle
            // 
            this._txtDetalle.Location = new System.Drawing.Point(54, 71);
            this._txtDetalle.Multiline = true;
            this._txtDetalle.Name = "_txtDetalle";
            this._txtDetalle.Size = new System.Drawing.Size(341, 19);
            this._txtDetalle.TabIndex = 9;
            this._txtDetalle.TextChanged += new System.EventHandler(this.txtDetalle_TextChanged);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(8, 74);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(43, 13);
            this.Label5.TabIndex = 45;
            this.Label5.Text = "Detalle:";
            // 
            // txtArticuloNombre
            // 
            this.txtArticuloNombre.Location = new System.Drawing.Point(243, 51);
            this.txtArticuloNombre.Name = "txtArticuloNombre";
            this.txtArticuloNombre.Size = new System.Drawing.Size(277, 20);
            this.txtArticuloNombre.TabIndex = 7;
            // 
            // _btnArticuloCod
            // 
            this._btnArticuloCod.Image = ((System.Drawing.Image)(resources.GetObject("_btnArticuloCod.Image")));
            this._btnArticuloCod.Location = new System.Drawing.Point(101, 50);
            this._btnArticuloCod.Name = "_btnArticuloCod";
            this._btnArticuloCod.Size = new System.Drawing.Size(21, 20);
            this._btnArticuloCod.TabIndex = 43;
            this._btnArticuloCod.UseVisualStyleBackColor = true;
            this._btnArticuloCod.Click += new System.EventHandler(this.btnArticuloCod_Click);
            // 
            // _txtArtCodigo
            // 
            this._txtArtCodigo.Location = new System.Drawing.Point(124, 51);
            this._txtArtCodigo.Name = "_txtArtCodigo";
            this._txtArtCodigo.Size = new System.Drawing.Size(97, 20);
            this._txtArtCodigo.TabIndex = 7;
            this._txtArtCodigo.TextChanged += new System.EventHandler(this.txtArtCodigo_TextChanged);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(14, 52);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(88, 13);
            this.Label4.TabIndex = 41;
            this.Label4.Text = "Articulo/Servicio:";
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.Panel1.Controls.Add(this.cboPtoVenta);
            this.Panel1.Controls.Add(this.Label2);
            this.Panel1.Controls.Add(this._txtFechaFin);
            this.Panel1.Controls.Add(this._txtFechaIn);
            this.Panel1.Controls.Add(this.txtNumDoc);
            this.Panel1.Controls.Add(this.Label10);
            this.Panel1.Controls.Add(this.cboTipoDoc);
            this.Panel1.Controls.Add(this.Label6);
            this.Panel1.Controls.Add(this.cboSucursal);
            this.Panel1.Controls.Add(this.Label7);
            this.Panel1.Controls.Add(this.cboBodega);
            this.Panel1.Controls.Add(this.Label8);
            this.Panel1.Controls.Add(this._btnServicioCod);
            this.Panel1.Controls.Add(this._txtvalor);
            this.Panel1.Controls.Add(this.Label9);
            this.Panel1.Controls.Add(this._btnArticuloCod);
            this.Panel1.Controls.Add(this.txtArticuloNombre);
            this.Panel1.Controls.Add(this._txtDetalle);
            this.Panel1.Controls.Add(this.Label5);
            this.Panel1.Controls.Add(this._txtArtCodigo);
            this.Panel1.Controls.Add(this.Label4);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Controls.Add(this._txtClienteCod);
            this.Panel1.Controls.Add(this.txtClienteNombre);
            this.Panel1.Controls.Add(this._btnClienteCod);
            this.Panel1.Controls.Add(this.Label3);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.ForeColor = System.Drawing.Color.White;
            this.Panel1.Location = new System.Drawing.Point(0, 38);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(848, 108);
            this.Panel1.TabIndex = 5;
            // 
            // cboPtoVenta
            // 
            this.cboPtoVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPtoVenta.FormattingEnabled = true;
            this.cboPtoVenta.Location = new System.Drawing.Point(699, 85);
            this.cboPtoVenta.Name = "cboPtoVenta";
            this.cboPtoVenta.Size = new System.Drawing.Size(143, 21);
            this.cboPtoVenta.TabIndex = 77;
            // 
            // Label2
            // 
            this.Label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(642, 88);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(54, 13);
            this.Label2.TabIndex = 78;
            this.Label2.Text = "PuntoVta:";
            // 
            // _txtFechaFin
            // 
            this._txtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._txtFechaFin.Location = new System.Drawing.Point(161, 6);
            this._txtFechaFin.Name = "_txtFechaFin";
            this._txtFechaFin.Size = new System.Drawing.Size(90, 20);
            this._txtFechaFin.TabIndex = 76;
            this._txtFechaFin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFechaFin_KeyDown);
            // 
            // _txtFechaIn
            // 
            this._txtFechaIn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._txtFechaIn.Location = new System.Drawing.Point(66, 6);
            this._txtFechaIn.Name = "_txtFechaIn";
            this._txtFechaIn.Size = new System.Drawing.Size(90, 20);
            this._txtFechaIn.TabIndex = 75;
            this._txtFechaIn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFechaIn_KeyDown);
            // 
            // txtNumDoc
            // 
            this.txtNumDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumDoc.Location = new System.Drawing.Point(699, 65);
            this.txtNumDoc.Name = "txtNumDoc";
            this.txtNumDoc.Size = new System.Drawing.Size(143, 20);
            this.txtNumDoc.TabIndex = 74;
            // 
            // Label10
            // 
            this.Label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(631, 67);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(65, 13);
            this.Label10.TabIndex = 73;
            this.Label10.Text = "Nro. de lote:";
            // 
            // cboTipoDoc
            // 
            this.cboTipoDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipoDoc.FormattingEnabled = true;
            this.cboTipoDoc.Location = new System.Drawing.Point(699, 2);
            this.cboTipoDoc.Name = "cboTipoDoc";
            this.cboTipoDoc.Size = new System.Drawing.Size(143, 21);
            this.cboTipoDoc.TabIndex = 67;
            // 
            // Label6
            // 
            this.Label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(627, 6);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(69, 13);
            this.Label6.TabIndex = 70;
            this.Label6.Text = "Tipo de Doc.";
            // 
            // cboSucursal
            // 
            this.cboSucursal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSucursal.FormattingEnabled = true;
            this.cboSucursal.Location = new System.Drawing.Point(699, 23);
            this.cboSucursal.Name = "cboSucursal";
            this.cboSucursal.Size = new System.Drawing.Size(143, 21);
            this.cboSucursal.TabIndex = 68;
            // 
            // Label7
            // 
            this.Label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(642, 27);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(51, 13);
            this.Label7.TabIndex = 71;
            this.Label7.Text = "Sucursal:";
            // 
            // cboBodega
            // 
            this.cboBodega.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBodega.FormattingEnabled = true;
            this.cboBodega.Location = new System.Drawing.Point(699, 44);
            this.cboBodega.Name = "cboBodega";
            this.cboBodega.Size = new System.Drawing.Size(143, 21);
            this.cboBodega.TabIndex = 69;
            // 
            // Label8
            // 
            this.Label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(649, 47);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(47, 13);
            this.Label8.TabIndex = 72;
            this.Label8.Text = "Bodega:";
            // 
            // _btnServicioCod
            // 
            this._btnServicioCod.Image = ((System.Drawing.Image)(resources.GetObject("_btnServicioCod.Image")));
            this._btnServicioCod.Location = new System.Drawing.Point(221, 51);
            this._btnServicioCod.Name = "_btnServicioCod";
            this._btnServicioCod.Size = new System.Drawing.Size(21, 20);
            this._btnServicioCod.TabIndex = 63;
            this._btnServicioCod.UseVisualStyleBackColor = true;
            this._btnServicioCod.Click += new System.EventHandler(this.btnServicioCod_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(9, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(51, 13);
            this.Label1.TabIndex = 53;
            this.Label1.Text = "Período :";
            // 
            // _txtClienteCod
            // 
            this._txtClienteCod.Location = new System.Drawing.Point(124, 31);
            this._txtClienteCod.Name = "_txtClienteCod";
            this._txtClienteCod.Size = new System.Drawing.Size(97, 20);
            this._txtClienteCod.TabIndex = 5;
            this._txtClienteCod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtClienteCod_KeyDown);
            // 
            // txtClienteNombre
            // 
            this.txtClienteNombre.Location = new System.Drawing.Point(222, 31);
            this.txtClienteNombre.Name = "txtClienteNombre";
            this.txtClienteNombre.Size = new System.Drawing.Size(298, 20);
            this.txtClienteNombre.TabIndex = 6;
            // 
            // _btnClienteCod
            // 
            this._btnClienteCod.Image = ((System.Drawing.Image)(resources.GetObject("_btnClienteCod.Image")));
            this._btnClienteCod.Location = new System.Drawing.Point(102, 30);
            this._btnClienteCod.Name = "_btnClienteCod";
            this._btnClienteCod.Size = new System.Drawing.Size(21, 20);
            this._btnClienteCod.TabIndex = 39;
            this._btnClienteCod.UseVisualStyleBackColor = true;
            this._btnClienteCod.Click += new System.EventHandler(this.btnClienteCod_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(6, 32);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(96, 13);
            this.Label3.TabIndex = 37;
            this.Label3.Text = "Cliente/Proveedor:";
            // 
            // _malla
            // 
            this._malla.AllowUserToAddRows = false;
            this._malla.AllowUserToDeleteRows = false;
            this._malla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._malla.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._malla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this._malla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._malla.Dock = System.Windows.Forms.DockStyle.Fill;
            this._malla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this._malla.EnableHeadersVisualStyles = false;
            this._malla.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this._malla.Location = new System.Drawing.Point(0, 146);
            this._malla.Name = "_malla";
            this._malla.ReadOnly = true;
            this._malla.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._malla.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this._malla.RowHeadersWidth = 20;
            this._malla.ShowCellToolTips = false;
            this._malla.ShowEditingIcon = false;
            this._malla.Size = new System.Drawing.Size(848, 416);
            this._malla.TabIndex = 6;
            this._malla.DoubleClick += new System.EventHandler(this.malla_DoubleClick);
            // 
            // frmBuscarDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 562);
            this.Controls.Add(this._malla);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBuscarDoc";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BUSCADOR DE DOCUMENTOS";
            this.Load += new System.EventHandler(this.frmBuscarDoc_Load);
            this.TableLayoutPanel1.ResumeLayout(false);
            this.TableLayoutPanel1.PerformLayout();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._malla)).EndInit();
            this.ResumeLayout(false);

        }

        internal TableLayoutPanel TableLayoutPanel1;
        internal ToolStrip ToolStrip1;
        private ToolStripButton _btnAceptar;

        internal ToolStripButton btnAceptar
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnAceptar;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnAceptar != null)
                {
                    _btnAceptar.Click -= btnAceptar_Click;
                }

                _btnAceptar = value;
                if (_btnAceptar != null)
                {
                    _btnAceptar.Click += btnAceptar_Click;
                }
            }
        }

        private ToolStripButton _btnBuscar;

        internal ToolStripButton btnBuscar
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnBuscar;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnBuscar != null)
                {
                    _btnBuscar.Click -= btnBuscar_Click;
                }

                _btnBuscar = value;
                if (_btnBuscar != null)
                {
                    _btnBuscar.Click += btnBuscar_Click;
                }
            }
        }

        internal ToolStripSeparator ToolStripSeparator1;
        private ToolStripButton _btnSalir;

        internal ToolStripButton btnSalir
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnSalir;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnSalir != null)
                {
                    _btnSalir.Click -= btnSalir_Click;
                }

                _btnSalir = value;
                if (_btnSalir != null)
                {
                    _btnSalir.Click += btnSalir_Click;
                }
            }
        }

        private TextBox _txtDetalle;

        internal TextBox txtDetalle
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtDetalle;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtDetalle != null)
                {
                    _txtDetalle.TextChanged -= txtDetalle_TextChanged;
                }

                _txtDetalle = value;
                if (_txtDetalle != null)
                {
                    _txtDetalle.TextChanged += txtDetalle_TextChanged;
                }
            }
        }

        internal Label Label5;
        internal TextBox txtArticuloNombre;
        private Button _btnArticuloCod;

        internal Button btnArticuloCod
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnArticuloCod;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnArticuloCod != null)
                {
                    _btnArticuloCod.Click -= btnArticuloCod_Click;
                }

                _btnArticuloCod = value;
                if (_btnArticuloCod != null)
                {
                    _btnArticuloCod.Click += btnArticuloCod_Click;
                }
            }
        }

        private TextBox _txtArtCodigo;

        internal TextBox txtArtCodigo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtArtCodigo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtArtCodigo != null)
                {
                    _txtArtCodigo.TextChanged -= txtArtCodigo_TextChanged;
                }

                _txtArtCodigo = value;
                if (_txtArtCodigo != null)
                {
                    _txtArtCodigo.TextChanged += txtArtCodigo_TextChanged;
                }
            }
        }

        internal Label Label4;
        private TextBox _txtvalor;

        internal TextBox txtvalor
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtvalor;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtvalor != null)
                {
                    _txtvalor.TextChanged -= txtvalor_TextChanged;
                }

                _txtvalor = value;
                if (_txtvalor != null)
                {
                    _txtvalor.TextChanged += txtvalor_TextChanged;
                }
            }
        }

        internal Label Label9;
        internal Label Label1;
        private TextBox _txtClienteCod;

        internal TextBox txtClienteCod
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtClienteCod;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtClienteCod != null)
                {
                    _txtClienteCod.KeyDown -= txtClienteCod_KeyDown;
                }

                _txtClienteCod = value;
                if (_txtClienteCod != null)
                {
                    _txtClienteCod.KeyDown += txtClienteCod_KeyDown;
                }
            }
        }

        internal TextBox txtClienteNombre;
        private Button _btnClienteCod;

        internal Button btnClienteCod
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnClienteCod;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnClienteCod != null)
                {
                    _btnClienteCod.Click -= btnClienteCod_Click;
                }

                _btnClienteCod = value;
                if (_btnClienteCod != null)
                {
                    _btnClienteCod.Click += btnClienteCod_Click;
                }
            }
        }

        internal Label Label3;
        private Button _btnServicioCod;

        internal Button btnServicioCod
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnServicioCod;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnServicioCod != null)
                {
                    _btnServicioCod.Click -= btnServicioCod_Click;
                }

                _btnServicioCod = value;
                if (_btnServicioCod != null)
                {
                    _btnServicioCod.Click += btnServicioCod_Click;
                }
            }
        }

        internal Panel Panel1;
        private DataGridView _malla;

        internal DataGridView malla
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _malla;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_malla != null)
                {
                    _malla.DoubleClick -= malla_DoubleClick;
                }

                _malla = value;
                if (_malla != null)
                {
                    _malla.DoubleClick += malla_DoubleClick;
                }
            }
        }

        internal ToolStripSeparator ToolStripSeparator2;
        private DateTimePicker _txtFechaFin;

        internal DateTimePicker txtFechaFin
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtFechaFin;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtFechaFin != null)
                {
                    _txtFechaFin.KeyDown -= txtFechaFin_KeyDown;
                }

                _txtFechaFin = value;
                if (_txtFechaFin != null)
                {
                    _txtFechaFin.KeyDown += txtFechaFin_KeyDown;
                }
            }
        }

        private DateTimePicker _txtFechaIn;

        internal DateTimePicker txtFechaIn
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtFechaIn;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtFechaIn != null)
                {
                    _txtFechaIn.KeyDown -= txtFechaIn_KeyDown;
                }

                _txtFechaIn = value;
                if (_txtFechaIn != null)
                {
                    _txtFechaIn.KeyDown += txtFechaIn_KeyDown;
                }
            }
        }

        internal TextBox txtNumDoc;
        internal Label Label10;
        internal ComboBox cboTipoDoc;
        internal Label Label6;
        internal ComboBox cboSucursal;
        internal Label Label7;
        internal ComboBox cboBodega;
        internal Label Label8;
        internal ToolStripSeparator ToolStripSeparator3;
        internal ToolStripComboBox cmbAutorizaciones;
        internal ToolStripComboBox cmbActivos;
        internal ComboBox cboPtoVenta;
        internal Label Label2;
    }
}