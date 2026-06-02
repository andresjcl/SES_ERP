
namespace BuscadorDocumentos
{
    partial class frmBuscarDoc
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarDoc));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.cboPtoVenta = new System.Windows.Forms.ComboBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.txtFechaFin = new System.Windows.Forms.DateTimePicker();
			this.txtFechaIn = new System.Windows.Forms.DateTimePicker();
			this.txtNumDoc = new System.Windows.Forms.TextBox();
			this.Label10 = new System.Windows.Forms.Label();
			this.cboTipoDoc = new System.Windows.Forms.ComboBox();
			this.Label6 = new System.Windows.Forms.Label();
			this.cboSucursal = new System.Windows.Forms.ComboBox();
			this.Label7 = new System.Windows.Forms.Label();
			this.cboBodega = new System.Windows.Forms.ComboBox();
			this.Label8 = new System.Windows.Forms.Label();
			this.btnServicioCod = new System.Windows.Forms.Button();
			this.Label1 = new System.Windows.Forms.Label();
			this.txtClienteCod = new System.Windows.Forms.TextBox();
			this.txtClienteNombre = new System.Windows.Forms.TextBox();
			this.btnClienteCod = new System.Windows.Forms.Button();
			this.malla = new System.Windows.Forms.DataGridView();
			this.Panel1 = new System.Windows.Forms.Panel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.chkNoAutirizados = new System.Windows.Forms.CheckBox();
			this.btnAceptar = new System.Windows.Forms.PictureBox();
			this.chkAutorizados = new System.Windows.Forms.CheckBox();
			this.btnSalir = new System.Windows.Forms.PictureBox();
			this.chkAnulados = new System.Windows.Forms.CheckBox();
			this.btnBuscar = new System.Windows.Forms.PictureBox();
			this.chkActivos = new System.Windows.Forms.CheckBox();
			this.label9 = new System.Windows.Forms.Label();
			this.btnArticuloCod = new System.Windows.Forms.Button();
			this.txtDetalle = new System.Windows.Forms.TextBox();
			this.txtArtCodigo = new System.Windows.Forms.TextBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.txtArticuloNombre = new System.Windows.Forms.TextBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.malla)).BeginInit();
			this.Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.btnAceptar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).BeginInit();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// cboPtoVenta
			// 
			this.cboPtoVenta.BackColor = System.Drawing.Color.White;
			this.cboPtoVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPtoVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cboPtoVenta.ForeColor = System.Drawing.Color.Black;
			this.cboPtoVenta.FormattingEnabled = true;
			this.cboPtoVenta.Location = new System.Drawing.Point(195, 13);
			this.cboPtoVenta.Name = "cboPtoVenta";
			this.cboPtoVenta.Size = new System.Drawing.Size(143, 21);
			this.cboPtoVenta.TabIndex = 77;
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(197, 1);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(54, 13);
			this.Label2.TabIndex = 78;
			this.Label2.Text = "PuntoVta:";
			// 
			// txtFechaFin
			// 
			this.txtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.txtFechaFin.Location = new System.Drawing.Point(287, 54);
			this.txtFechaFin.Name = "txtFechaFin";
			this.txtFechaFin.Size = new System.Drawing.Size(79, 20);
			this.txtFechaFin.TabIndex = 76;
			this.txtFechaFin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFechaFin_KeyDown);
			// 
			// txtFechaIn
			// 
			this.txtFechaIn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.txtFechaIn.Location = new System.Drawing.Point(210, 54);
			this.txtFechaIn.Name = "txtFechaIn";
			this.txtFechaIn.Size = new System.Drawing.Size(77, 20);
			this.txtFechaIn.TabIndex = 75;
			this.txtFechaIn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFechaIn_KeyDown);
			// 
			// txtNumDoc
			// 
			this.txtNumDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtNumDoc.Location = new System.Drawing.Point(488, 14);
			this.txtNumDoc.Name = "txtNumDoc";
			this.txtNumDoc.Size = new System.Drawing.Size(103, 20);
			this.txtNumDoc.TabIndex = 74;
			// 
			// Label10
			// 
			this.Label10.AutoSize = true;
			this.Label10.Location = new System.Drawing.Point(491, 2);
			this.Label10.Name = "Label10";
			this.Label10.Size = new System.Drawing.Size(65, 13);
			this.Label10.TabIndex = 73;
			this.Label10.Text = "Nro. de lote:";
			// 
			// cboTipoDoc
			// 
			this.cboTipoDoc.BackColor = System.Drawing.Color.White;
			this.cboTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboTipoDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cboTipoDoc.ForeColor = System.Drawing.Color.Black;
			this.cboTipoDoc.FormattingEnabled = true;
			this.cboTipoDoc.Location = new System.Drawing.Point(7, 53);
			this.cboTipoDoc.Name = "cboTipoDoc";
			this.cboTipoDoc.Size = new System.Drawing.Size(193, 21);
			this.cboTipoDoc.TabIndex = 67;
			this.cboTipoDoc.SelectedIndexChanged += new System.EventHandler(this.cboTipoDoc_SelectedIndexChanged);
			// 
			// Label6
			// 
			this.Label6.AutoSize = true;
			this.Label6.Location = new System.Drawing.Point(4, 41);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(69, 13);
			this.Label6.TabIndex = 70;
			this.Label6.Text = "Tipo de Doc.";
			// 
			// cboSucursal
			// 
			this.cboSucursal.BackColor = System.Drawing.Color.White;
			this.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboSucursal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cboSucursal.ForeColor = System.Drawing.Color.Black;
			this.cboSucursal.FormattingEnabled = true;
			this.cboSucursal.Location = new System.Drawing.Point(12, 13);
			this.cboSucursal.Name = "cboSucursal";
			this.cboSucursal.Size = new System.Drawing.Size(182, 21);
			this.cboSucursal.TabIndex = 68;
			this.cboSucursal.SelectedIndexChanged += new System.EventHandler(this.cboSucursal_SelectedIndexChanged);
			// 
			// Label7
			// 
			this.Label7.AutoSize = true;
			this.Label7.Location = new System.Drawing.Point(11, 1);
			this.Label7.Name = "Label7";
			this.Label7.Size = new System.Drawing.Size(51, 13);
			this.Label7.TabIndex = 71;
			this.Label7.Text = "Sucursal:";
			// 
			// cboBodega
			// 
			this.cboBodega.BackColor = System.Drawing.Color.White;
			this.cboBodega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboBodega.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cboBodega.ForeColor = System.Drawing.Color.Black;
			this.cboBodega.FormattingEnabled = true;
			this.cboBodega.Location = new System.Drawing.Point(340, 13);
			this.cboBodega.Name = "cboBodega";
			this.cboBodega.Size = new System.Drawing.Size(143, 21);
			this.cboBodega.TabIndex = 69;
			this.cboBodega.SelectedIndexChanged += new System.EventHandler(this.cboBodega_SelectedIndexChanged);
			// 
			// Label8
			// 
			this.Label8.AutoSize = true;
			this.Label8.Location = new System.Drawing.Point(345, 0);
			this.Label8.Name = "Label8";
			this.Label8.Size = new System.Drawing.Size(47, 13);
			this.Label8.TabIndex = 72;
			this.Label8.Text = "Bodega:";
			// 
			// btnServicioCod
			// 
			this.btnServicioCod.Image = ((System.Drawing.Image)(resources.GetObject("btnServicioCod.Image")));
			this.btnServicioCod.Location = new System.Drawing.Point(126, 79);
			this.btnServicioCod.Name = "btnServicioCod";
			this.btnServicioCod.Size = new System.Drawing.Size(21, 20);
			this.btnServicioCod.TabIndex = 63;
			this.btnServicioCod.UseVisualStyleBackColor = true;
			this.btnServicioCod.Click += new System.EventHandler(this.btnServicioCod_Click);
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(213, 42);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(51, 13);
			this.Label1.TabIndex = 53;
			this.Label1.Text = "Período :";
			// 
			// txtClienteCod
			// 
			this.txtClienteCod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtClienteCod.Location = new System.Drawing.Point(31, 47);
			this.txtClienteCod.Name = "txtClienteCod";
			this.txtClienteCod.Size = new System.Drawing.Size(97, 20);
			this.txtClienteCod.TabIndex = 5;
			this.txtClienteCod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtClienteCod_KeyDown);
			// 
			// txtClienteNombre
			// 
			this.txtClienteNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtClienteNombre.Location = new System.Drawing.Point(128, 47);
			this.txtClienteNombre.Name = "txtClienteNombre";
			this.txtClienteNombre.Size = new System.Drawing.Size(298, 20);
			this.txtClienteNombre.TabIndex = 6;
			// 
			// btnClienteCod
			// 
			this.btnClienteCod.Image = ((System.Drawing.Image)(resources.GetObject("btnClienteCod.Image")));
			this.btnClienteCod.Location = new System.Drawing.Point(10, 47);
			this.btnClienteCod.Name = "btnClienteCod";
			this.btnClienteCod.Size = new System.Drawing.Size(21, 20);
			this.btnClienteCod.TabIndex = 39;
			this.btnClienteCod.UseVisualStyleBackColor = true;
			this.btnClienteCod.Click += new System.EventHandler(this.btnClienteCod_Click);
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
			this.malla.Location = new System.Drawing.Point(0, 182);
			this.malla.MultiSelect = false;
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
			this.malla.Size = new System.Drawing.Size(689, 344);
			this.malla.TabIndex = 9;
			this.malla.DoubleClick += new System.EventHandler(this.malla_DoubleClick);
			// 
			// Panel1
			// 
			this.Panel1.BackColor = System.Drawing.Color.Gray;
			this.Panel1.Controls.Add(this.pictureBox1);
			this.Panel1.Controls.Add(this.chkNoAutirizados);
			this.Panel1.Controls.Add(this.btnAceptar);
			this.Panel1.Controls.Add(this.chkAutorizados);
			this.Panel1.Controls.Add(this.btnSalir);
			this.Panel1.Controls.Add(this.chkAnulados);
			this.Panel1.Controls.Add(this.btnBuscar);
			this.Panel1.Controls.Add(this.chkActivos);
			this.Panel1.Controls.Add(this.txtFechaFin);
			this.Panel1.Controls.Add(this.txtFechaIn);
			this.Panel1.Controls.Add(this.cboTipoDoc);
			this.Panel1.Controls.Add(this.Label6);
			this.Panel1.Controls.Add(this.Label1);
			this.Panel1.Controls.Add(this.label9);
			this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.Panel1.ForeColor = System.Drawing.Color.White;
			this.Panel1.Location = new System.Drawing.Point(0, 0);
			this.Panel1.Name = "Panel1";
			this.Panel1.Size = new System.Drawing.Size(689, 78);
			this.Panel1.TabIndex = 8;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(567, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(24, 24);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 87;
			this.pictureBox1.TabStop = false;
			this.toolTip1.SetToolTip(this.pictureBox1, "Filtros adicionales");
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// chkNoAutirizados
			// 
			this.chkNoAutirizados.AutoSize = true;
			this.chkNoAutirizados.Checked = true;
			this.chkNoAutirizados.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkNoAutirizados.Location = new System.Drawing.Point(585, 57);
			this.chkNoAutirizados.Name = "chkNoAutirizados";
			this.chkNoAutirizados.Size = new System.Drawing.Size(97, 17);
			this.chkNoAutirizados.TabIndex = 83;
			this.chkNoAutirizados.Text = "No autorizados";
			this.chkNoAutirizados.UseVisualStyleBackColor = true;
			this.chkNoAutirizados.CheckedChanged += new System.EventHandler(this.chkActivos_CheckedChanged);
			// 
			// btnAceptar
			// 
			this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
			this.btnAceptar.Location = new System.Drawing.Point(624, 3);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(24, 24);
			this.btnAceptar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.btnAceptar.TabIndex = 86;
			this.btnAceptar.TabStop = false;
			this.toolTip1.SetToolTip(this.btnAceptar, "Aceptar linea escojida");
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			// 
			// chkAutorizados
			// 
			this.chkAutorizados.AutoSize = true;
			this.chkAutorizados.Checked = true;
			this.chkAutorizados.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkAutorizados.Location = new System.Drawing.Point(505, 57);
			this.chkAutorizados.Name = "chkAutorizados";
			this.chkAutorizados.Size = new System.Drawing.Size(81, 17);
			this.chkAutorizados.TabIndex = 82;
			this.chkAutorizados.Text = "Autorizados";
			this.chkAutorizados.UseVisualStyleBackColor = true;
			this.chkAutorizados.CheckedChanged += new System.EventHandler(this.chkActivos_CheckedChanged);
			// 
			// btnSalir
			// 
			this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
			this.btnSalir.Location = new System.Drawing.Point(654, 3);
			this.btnSalir.Name = "btnSalir";
			this.btnSalir.Size = new System.Drawing.Size(24, 24);
			this.btnSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.btnSalir.TabIndex = 85;
			this.btnSalir.TabStop = false;
			this.toolTip1.SetToolTip(this.btnSalir, "Salir de la aplicación");
			this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
			// 
			// chkAnulados
			// 
			this.chkAnulados.AutoSize = true;
			this.chkAnulados.Location = new System.Drawing.Point(436, 57);
			this.chkAnulados.Name = "chkAnulados";
			this.chkAnulados.Size = new System.Drawing.Size(70, 17);
			this.chkAnulados.TabIndex = 81;
			this.chkAnulados.Text = "Anulados";
			this.chkAnulados.UseVisualStyleBackColor = true;
			this.chkAnulados.CheckedChanged += new System.EventHandler(this.chkActivos_CheckedChanged);
			// 
			// btnBuscar
			// 
			this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
			this.btnBuscar.Location = new System.Drawing.Point(594, 3);
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(24, 24);
			this.btnBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.btnBuscar.TabIndex = 84;
			this.btnBuscar.TabStop = false;
			this.toolTip1.SetToolTip(this.btnBuscar, "Actualizar resultados");
			this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
			// 
			// chkActivos
			// 
			this.chkActivos.AutoSize = true;
			this.chkActivos.Checked = true;
			this.chkActivos.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkActivos.Location = new System.Drawing.Point(375, 57);
			this.chkActivos.Name = "chkActivos";
			this.chkActivos.Size = new System.Drawing.Size(61, 17);
			this.chkActivos.TabIndex = 80;
			this.chkActivos.Text = "Activos";
			this.chkActivos.UseVisualStyleBackColor = true;
			this.chkActivos.CheckedChanged += new System.EventHandler(this.chkActivos_CheckedChanged);
			// 
			// label9
			// 
			this.label9.BackColor = System.Drawing.Color.White;
			this.label9.Dock = System.Windows.Forms.DockStyle.Top;
			this.label9.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.ForeColor = System.Drawing.Color.SteelBlue;
			this.label9.Location = new System.Drawing.Point(0, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(689, 37);
			this.label9.TabIndex = 87;
			this.label9.Text = "Buscador de documentos";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnArticuloCod
			// 
			this.btnArticuloCod.Image = ((System.Drawing.Image)(resources.GetObject("btnArticuloCod.Image")));
			this.btnArticuloCod.Location = new System.Drawing.Point(10, 79);
			this.btnArticuloCod.Name = "btnArticuloCod";
			this.btnArticuloCod.Size = new System.Drawing.Size(21, 20);
			this.btnArticuloCod.TabIndex = 43;
			this.btnArticuloCod.UseVisualStyleBackColor = true;
			this.btnArticuloCod.CausesValidationChanged += new System.EventHandler(this.btnArticuloCod_Click);
			// 
			// txtDetalle
			// 
			this.txtDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtDetalle.Location = new System.Drawing.Point(389, 80);
			this.txtDetalle.Multiline = true;
			this.txtDetalle.Name = "txtDetalle";
			this.txtDetalle.Size = new System.Drawing.Size(299, 19);
			this.txtDetalle.TabIndex = 9;
			// 
			// txtArtCodigo
			// 
			this.txtArtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtArtCodigo.Location = new System.Drawing.Point(30, 79);
			this.txtArtCodigo.Name = "txtArtCodigo";
			this.txtArtCodigo.Size = new System.Drawing.Size(97, 20);
			this.txtArtCodigo.TabIndex = 7;
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(10, 34);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(96, 13);
			this.Label3.TabIndex = 37;
			this.Label3.Text = "Cliente/Proveedor:";
			// 
			// txtArticuloNombre
			// 
			this.txtArticuloNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtArticuloNombre.Location = new System.Drawing.Point(146, 79);
			this.txtArticuloNombre.Name = "txtArticuloNombre";
			this.txtArticuloNombre.Size = new System.Drawing.Size(237, 20);
			this.txtArticuloNombre.TabIndex = 7;
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Location = new System.Drawing.Point(10, 67);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(88, 13);
			this.Label4.TabIndex = 41;
			this.Label4.Text = "Articulo/Servicio:";
			// 
			// Label5
			// 
			this.Label5.AutoSize = true;
			this.Label5.Location = new System.Drawing.Point(388, 68);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(43, 13);
			this.Label5.TabIndex = 45;
			this.Label5.Text = "Detalle:";
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.Gray;
			this.panel3.Controls.Add(this.txtClienteNombre);
			this.panel3.Controls.Add(this.cboPtoVenta);
			this.panel3.Controls.Add(this.Label2);
			this.panel3.Controls.Add(this.txtNumDoc);
			this.panel3.Controls.Add(this.txtArticuloNombre);
			this.panel3.Controls.Add(this.cboSucursal);
			this.panel3.Controls.Add(this.Label3);
			this.panel3.Controls.Add(this.cboBodega);
			this.panel3.Controls.Add(this.btnClienteCod);
			this.panel3.Controls.Add(this.btnServicioCod);
			this.panel3.Controls.Add(this.txtClienteCod);
			this.panel3.Controls.Add(this.btnArticuloCod);
			this.panel3.Controls.Add(this.txtArtCodigo);
			this.panel3.Controls.Add(this.txtDetalle);
			this.panel3.Controls.Add(this.Label5);
			this.panel3.Controls.Add(this.Label4);
			this.panel3.Controls.Add(this.Label7);
			this.panel3.Controls.Add(this.Label8);
			this.panel3.Controls.Add(this.Label10);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.ForeColor = System.Drawing.Color.White;
			this.panel3.Location = new System.Drawing.Point(0, 78);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(689, 104);
			this.panel3.TabIndex = 11;
			this.panel3.Visible = false;
			// 
			// frmBuscarDoc
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(689, 526);
			this.ControlBox = false;
			this.Controls.Add(this.malla);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.Panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmBuscarDoc";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Load += new System.EventHandler(this.frmBuscarDoc_Load);
			((System.ComponentModel.ISupportInitialize)(this.malla)).EndInit();
			this.Panel1.ResumeLayout(false);
			this.Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.btnAceptar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ComboBox cboPtoVenta;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.DateTimePicker txtFechaFin;
        private System.Windows.Forms.DateTimePicker txtFechaIn;
        internal System.Windows.Forms.TextBox txtNumDoc;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.ComboBox cboTipoDoc;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.ComboBox cboSucursal;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.ComboBox cboBodega;
        internal System.Windows.Forms.Label Label8;
        private System.Windows.Forms.Button btnServicioCod;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox txtClienteCod;
        internal System.Windows.Forms.TextBox txtClienteNombre;
        private System.Windows.Forms.Button btnClienteCod;
        private System.Windows.Forms.DataGridView malla;
        internal System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.Button btnArticuloCod;
        internal System.Windows.Forms.TextBox txtArticuloNombre;
        private System.Windows.Forms.TextBox txtDetalle;
        internal System.Windows.Forms.Label Label5;
        private System.Windows.Forms.TextBox txtArtCodigo;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        private System.Windows.Forms.CheckBox chkNoAutirizados;
        private System.Windows.Forms.CheckBox chkAutorizados;
        private System.Windows.Forms.CheckBox chkAnulados;
        private System.Windows.Forms.CheckBox chkActivos;
        private System.Windows.Forms.PictureBox btnAceptar;
        private System.Windows.Forms.PictureBox btnSalir;
        private System.Windows.Forms.PictureBox btnBuscar;
        internal System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}