using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Buscar
{
    public partial class frmBuscar : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscar));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this._btnAceptar = new System.Windows.Forms.ToolStripButton();
            this._btnActualiza = new System.Windows.Forms.ToolStripButton();
            this._btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._btnSalir = new System.Windows.Forms.ToolStripButton();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this._txtAbrevia = new System.Windows.Forms.TextBox();
            this.chkInicial = new System.Windows.Forms.CheckBox();
            this.Panel2 = new System.Windows.Forms.Panel();
            this._gridDatos = new System.Windows.Forms.DataGridView();
            this.Panel1.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.DimGray;
            this.Panel1.Controls.Add(this.txtNombre);
            this.Panel1.Controls.Add(this.ToolStrip1);
            this.Panel1.Controls.Add(this.lblTitulo);
            this.Panel1.Controls.Add(this.Label2);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Controls.Add(this._txtAbrevia);
            this.Panel1.Controls.Add(this.chkInicial);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(680, 77);
            this.Panel1.TabIndex = 0;
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.BackColor = System.Drawing.Color.White;
            this.txtNombre.Location = new System.Drawing.Point(115, 54);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(562, 20);
            this.txtNombre.TabIndex = 15;
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.BackColor = System.Drawing.Color.DimGray;
            this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._btnAceptar,
            this._btnActualiza,
            this._btnCancelar,
            this.ToolStripSeparator1,
            this._btnSalir});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(680, 38);
            this.ToolStrip1.TabIndex = 14;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // _btnAceptar
            // 
            this._btnAceptar.ForeColor = System.Drawing.Color.White;
            this._btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("_btnAceptar.Image")));
            this._btnAceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this._btnAceptar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnAceptar.Name = "_btnAceptar";
            this._btnAceptar.Size = new System.Drawing.Size(52, 35);
            this._btnAceptar.Text = "Aceptar";
            this._btnAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // _btnActualiza
            // 
            this._btnActualiza.ForeColor = System.Drawing.Color.White;
            this._btnActualiza.Image = ((System.Drawing.Image)(resources.GetObject("_btnActualiza.Image")));
            this._btnActualiza.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this._btnActualiza.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnActualiza.Name = "_btnActualiza";
            this._btnActualiza.Size = new System.Drawing.Size(46, 35);
            this._btnActualiza.Text = "Buscar";
            this._btnActualiza.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._btnActualiza.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._btnActualiza.Click += new System.EventHandler(this.btnActualiza_Click);
            // 
            // _btnCancelar
            // 
            this._btnCancelar.ForeColor = System.Drawing.Color.White;
            this._btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("_btnCancelar.Image")));
            this._btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this._btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnCancelar.Name = "_btnCancelar";
            this._btnCancelar.Size = new System.Drawing.Size(57, 35);
            this._btnCancelar.Text = "Cancelar";
            this._btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // _btnSalir
            // 
            this._btnSalir.ForeColor = System.Drawing.Color.White;
            this._btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("_btnSalir.Image")));
            this._btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this._btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btnSalir.Name = "_btnSalir";
            this._btnSalir.Size = new System.Drawing.Size(33, 35);
            this._btnSalir.Text = "Salir";
            this._btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(13, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(0, 13);
            this.lblTitulo.TabIndex = 12;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.ForeColor = System.Drawing.Color.White;
            this.Label2.Location = new System.Drawing.Point(211, 41);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(63, 13);
            this.Label2.TabIndex = 11;
            this.Label2.Text = "Descripción";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(30, 38);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(43, 13);
            this.Label1.TabIndex = 10;
            this.Label1.Text = "Código:";
            // 
            // _txtAbrevia
            // 
            this._txtAbrevia.BackColor = System.Drawing.Color.White;
            this._txtAbrevia.Location = new System.Drawing.Point(3, 54);
            this._txtAbrevia.Name = "_txtAbrevia";
            this._txtAbrevia.Size = new System.Drawing.Size(106, 20);
            this._txtAbrevia.TabIndex = 8;
            this._txtAbrevia.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            this._txtAbrevia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAbrevia_KeyDown);
            // 
            // chkInicial
            // 
            this.chkInicial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkInicial.AutoSize = true;
            this.chkInicial.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkInicial.ForeColor = System.Drawing.Color.Gray;
            this.chkInicial.Location = new System.Drawing.Point(591, 39);
            this.chkInicial.Name = "chkInicial";
            this.chkInicial.Size = new System.Drawing.Size(86, 17);
            this.chkInicial.TabIndex = 13;
            this.chkInicial.Text = "BuscarInicial";
            this.chkInicial.UseVisualStyleBackColor = true;
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Panel2.Controls.Add(this._gridDatos);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel2.Location = new System.Drawing.Point(0, 77);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(680, 437);
            this.Panel2.TabIndex = 6;
            // 
            // _gridDatos
            // 
            this._gridDatos.AllowUserToAddRows = false;
            this._gridDatos.AllowUserToDeleteRows = false;
            this._gridDatos.AllowUserToResizeRows = false;
            this._gridDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._gridDatos.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._gridDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this._gridDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._gridDatos.DefaultCellStyle = dataGridViewCellStyle2;
            this._gridDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gridDatos.EnableHeadersVisualStyles = false;
            this._gridDatos.Location = new System.Drawing.Point(0, 0);
            this._gridDatos.Name = "_gridDatos";
            this._gridDatos.ReadOnly = true;
            this._gridDatos.RowHeadersWidth = 20;
            this._gridDatos.Size = new System.Drawing.Size(680, 437);
            this._gridDatos.TabIndex = 0;
            this._gridDatos.DoubleClick += new System.EventHandler(this.gridDatos_DoubleClick);
            // 
            // frmBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 514);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "frmBuscar";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BUSCAR";
            this.Load += new System.EventHandler(this.frmBuscar_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._gridDatos)).EndInit();
            this.ResumeLayout(false);

        }

        internal Panel Panel1;
        internal Label Label2;
        internal Label Label1;


        private TextBox _txtAbrevia;

        internal TextBox txtAbrevia
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _txtAbrevia;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_txtAbrevia != null)
                {
                    _txtAbrevia.KeyDown -= txtAbrevia_KeyDown;
                    _txtAbrevia.TextChanged -= txtNombre_TextChanged;
                }

                _txtAbrevia = value;
                if (_txtAbrevia != null)
                {
                    _txtAbrevia.KeyDown += txtAbrevia_KeyDown;
                    _txtAbrevia.TextChanged += txtNombre_TextChanged;
                }
            }
        }

        internal Panel Panel2;
        private DataGridView _gridDatos;

        internal DataGridView gridDatos
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _gridDatos;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_gridDatos != null)
                {
                    _gridDatos.DoubleClick -= gridDatos_DoubleClick;
                }

                _gridDatos = value;
                if (_gridDatos != null)
                {
                    _gridDatos.DoubleClick += gridDatos_DoubleClick;
                }
            }
        }

        internal Label lblTitulo;
        internal CheckBox chkInicial;
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

        private ToolStripButton _btnCancelar;

        internal ToolStripButton btnCancelar
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnCancelar;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnCancelar != null)
                {
                    _btnCancelar.Click -= btnCancelar_Click;
                }

                _btnCancelar = value;
                if (_btnCancelar != null)
                {
                    _btnCancelar.Click += btnCancelar_Click;
                }
            }
        }

        internal ToolStripSeparator ToolStripSeparator1;
        private ToolStripButton _btnActualiza;
        private TextBox txtNombre;

        internal ToolStripButton btnActualiza
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnActualiza;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnActualiza != null)
                {
                    _btnActualiza.Click -= btnActualiza_Click;
                }

                _btnActualiza = value;
                if (_btnActualiza != null)
                {
                    _btnActualiza.Click += btnActualiza_Click;
                }
            }
        }
    }
}