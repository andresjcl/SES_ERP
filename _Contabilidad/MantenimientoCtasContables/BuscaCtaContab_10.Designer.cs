using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace MantCtb
{
    [DesignerGenerated()]
    internal partial class BuscaCtaContab
    {
        #region Código generado por el Diseñador de Windows Forms 
        [DebuggerNonUserCode()]
        public BuscaCtaContab() : base()
        {
            // Llamada necesaria para el Diseñador de Windows Forms.
            InitializeComponent();
            _btncancelarbusca.Name = "btncancelarbusca";
            _btAceptar.Name = "btAceptar";
            _btNuevo.Name = "btNuevo";
            _btnImprimir.Name = "btnImprimir";
            _OpCentrosCosto.Name = "OpCentrosCosto";
            _PorInicial.Name = "PorInicial";
            _OpComodines.Name = "OpComodines";
            _Optcodigo.Name = "Optcodigo";
            _OptNombre.Name = "OptNombre";
            _TxtNombre.Name = "TxtNombre";
            _TextCodigo.Name = "TextCodigo";
            _TxtGrupo.Name = "TxtGrupo";
            _ListNombre.Name = "ListNombre";
        }
        // Form invalida a Dispose para limpiar la lista de componentes.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool Disposing)
        {
            if (Disposing)
            {
                if (components is object)
                {
                    components.Dispose();
                }
            }

            base.Dispose(Disposing);
        }
        // Requerido por el Diseñador de Windows Forms
        private System.ComponentModel.IContainer components;
        public ToolTip ToolTip1;
        private CheckBox _OpCentrosCosto;

        public CheckBox OpCentrosCosto
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _OpCentrosCosto;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_OpCentrosCosto != null)
                {
                    _OpCentrosCosto.CheckStateChanged -= OpCentrosCosto_CheckStateChanged;
                }

                _OpCentrosCosto = value;
                if (_OpCentrosCosto != null)
                {
                    _OpCentrosCosto.CheckStateChanged += OpCentrosCosto_CheckStateChanged;
                }
            }
        }

        private CheckBox _PorInicial;

        public CheckBox PorInicial
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PorInicial;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PorInicial != null)
                {
                    _PorInicial.CheckedChanged -= PorInicial_CheckedChanged;
                }

                _PorInicial = value;
                if (_PorInicial != null)
                {
                    _PorInicial.CheckedChanged += PorInicial_CheckedChanged;
                }
            }
        }

        private CheckBox _OpComodines;

        public CheckBox OpComodines
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _OpComodines;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_OpComodines != null)
                {
                    _OpComodines.CheckStateChanged -= OpComodines_CheckStateChanged;
                }

                _OpComodines = value;
                if (_OpComodines != null)
                {
                    _OpComodines.CheckStateChanged += OpComodines_CheckStateChanged;
                }
            }
        }

        private Button _btncancelarbusca;

        public Button btncancelarbusca
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btncancelarbusca;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btncancelarbusca != null)
                {
                    _btncancelarbusca.Click -= btncancelarbusca_Click;
                }

                _btncancelarbusca = value;
                if (_btncancelarbusca != null)
                {
                    _btncancelarbusca.Click += btncancelarbusca_Click;
                }
            }
        }

        private Button _btAceptar;

        public Button btAceptar
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btAceptar;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btAceptar != null)
                {
                    _btAceptar.Click -= btAceptar_Click;
                }

                _btAceptar = value;
                if (_btAceptar != null)
                {
                    _btAceptar.Click += btAceptar_Click;
                }
            }
        }

        private Button _btNuevo;

        public Button btNuevo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btNuevo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btNuevo != null)
                {
                    _btNuevo.Click -= btNuevo_Click;
                }

                _btNuevo = value;
                if (_btNuevo != null)
                {
                    _btNuevo.Click += btNuevo_Click;
                }
            }
        }

        private RadioButton _Optcodigo;

        public RadioButton Optcodigo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Optcodigo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Optcodigo != null)
                {
                    _Optcodigo.CheckedChanged -= optCodigo_CheckedChanged;
                }

                _Optcodigo = value;
                if (_Optcodigo != null)
                {
                    _Optcodigo.CheckedChanged += optCodigo_CheckedChanged;
                }
            }
        }

        private RadioButton _OptNombre;

        public RadioButton OptNombre
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _OptNombre;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_OptNombre != null)
                {
                    _OptNombre.CheckedChanged -= optNombre_CheckedChanged;
                }

                _OptNombre = value;
                if (_OptNombre != null)
                {
                    _OptNombre.CheckedChanged += optNombre_CheckedChanged;
                }
            }
        }

        private TextBox _TxtNombre;

        public TextBox TxtNombre
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TxtNombre;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TxtNombre != null)
                {
                    _TxtNombre.TextChanged -= TxtNombre_TextChanged;
                    _TxtNombre.KeyDown -= txtNombre_KeyDown;
                    _TxtNombre.KeyPress -= TxtNombre_KeyPress;
                }

                _TxtNombre = value;
                if (_TxtNombre != null)
                {
                    _TxtNombre.TextChanged += TxtNombre_TextChanged;
                    _TxtNombre.KeyDown += txtNombre_KeyDown;
                    _TxtNombre.KeyPress += TxtNombre_KeyPress;
                }
            }
        }

        private TextBox _TextCodigo;

        public TextBox TextCodigo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TextCodigo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TextCodigo != null)
                {
                    _TextCodigo.KeyDown -= TextCodigo_KeyDown;
                    _TextCodigo.KeyPress -= TextCodigo_KeyPress;
                }

                _TextCodigo = value;
                if (_TextCodigo != null)
                {
                    _TextCodigo.KeyDown += TextCodigo_KeyDown;
                    _TextCodigo.KeyPress += TextCodigo_KeyPress;
                }
            }
        }

        private TextBox _TxtGrupo;

        public TextBox TxtGrupo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _TxtGrupo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_TxtGrupo != null)
                {
                    _TxtGrupo.KeyDown -= TxtGrupo_KeyDown;
                    _TxtGrupo.KeyPress -= TxtGrupo_KeyPress;
                }

                _TxtGrupo = value;
                if (_TxtGrupo != null)
                {
                    _TxtGrupo.KeyDown += TxtGrupo_KeyDown;
                    _TxtGrupo.KeyPress += TxtGrupo_KeyPress;
                }
            }
        }
        // NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
        // Se puede modificar mediante el Diseñador de Windows Forms.
        // No lo modifique con el editor de código.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            var DataGridViewCellStyle1 = new DataGridViewCellStyle();
            var DataGridViewCellStyle2 = new DataGridViewCellStyle();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscaCtaContab));
            ToolTip1 = new ToolTip(components);
            _btncancelarbusca = new Button();
            _btncancelarbusca.Click += new EventHandler(btncancelarbusca_Click);
            _btAceptar = new Button();
            _btAceptar.Click += new EventHandler(btAceptar_Click);
            _btNuevo = new Button();
            _btNuevo.Click += new EventHandler(btNuevo_Click);
            _btnImprimir = new Button();
            _btnImprimir.Click += new EventHandler(btnImprimir_Click);
            _OpCentrosCosto = new CheckBox();
            _OpCentrosCosto.CheckStateChanged += new EventHandler(OpCentrosCosto_CheckStateChanged);
            _PorInicial = new CheckBox();
            _PorInicial.CheckedChanged += new EventHandler(PorInicial_CheckedChanged);
            _OpComodines = new CheckBox();
            _OpComodines.CheckStateChanged += new EventHandler(OpComodines_CheckStateChanged);
            _Optcodigo = new RadioButton();
            _Optcodigo.CheckedChanged += new EventHandler(optCodigo_CheckedChanged);
            _OptNombre = new RadioButton();
            _OptNombre.CheckedChanged += new EventHandler(optNombre_CheckedChanged);
            _TxtNombre = new TextBox();
            _TxtNombre.TextChanged += new EventHandler(TxtNombre_TextChanged);
            _TxtNombre.KeyDown += new KeyEventHandler(txtNombre_KeyDown);
            _TxtNombre.KeyPress += new KeyPressEventHandler(TxtNombre_KeyPress);
            _TextCodigo = new TextBox();
            _TextCodigo.KeyDown += new KeyEventHandler(TextCodigo_KeyDown);
            _TextCodigo.KeyPress += new KeyPressEventHandler(TextCodigo_KeyPress);
            _TxtGrupo = new TextBox();
            _TxtGrupo.KeyDown += new KeyEventHandler(TxtGrupo_KeyDown);
            _TxtGrupo.KeyPress += new KeyPressEventHandler(TxtGrupo_KeyPress);
            _ListNombre = new DataGridView();
            _ListNombre.CellEnter += new DataGridViewCellEventHandler(ListNombre_CellEnter);
            _ListNombre.DoubleClick += new EventHandler(ListNombre_DoubleClick);
            _ListNombre.CellMouseMove += new DataGridViewCellMouseEventHandler(ListNombre_CellMouseMove);
            ((System.ComponentModel.ISupportInitialize)_ListNombre).BeginInit();
            SuspendLayout();
            // 
            // btncancelarbusca
            // 
            _btncancelarbusca.BackColor = Color.SteelBlue;
            _btncancelarbusca.Cursor = Cursors.Default;
            _btncancelarbusca.FlatStyle = FlatStyle.Flat;
            _btncancelarbusca.ForeColor = Color.White;
            _btncancelarbusca.Location = new Point(72, 408);
            _btncancelarbusca.Name = "_btncancelarbusca";
            _btncancelarbusca.RightToLeft = RightToLeft.No;
            _btncancelarbusca.Size = new Size(61, 25);
            _btncancelarbusca.TabIndex = 9;
            _btncancelarbusca.Text = "&Cancelar";
            ToolTip1.SetToolTip(_btncancelarbusca, "Elija para ingresar un nuevo nivel");
            _btncancelarbusca.UseVisualStyleBackColor = false;
            // 
            // btAceptar
            // 
            _btAceptar.BackColor = Color.SteelBlue;
            _btAceptar.Cursor = Cursors.Default;
            _btAceptar.FlatStyle = FlatStyle.Flat;
            _btAceptar.ForeColor = Color.White;
            _btAceptar.Location = new Point(8, 408);
            _btAceptar.Name = "_btAceptar";
            _btAceptar.RightToLeft = RightToLeft.No;
            _btAceptar.Size = new Size(61, 25);
            _btAceptar.TabIndex = 8;
            _btAceptar.Text = "&Aceptar";
            ToolTip1.SetToolTip(_btAceptar, "Elija para ingresar un nuevo nivel");
            _btAceptar.UseVisualStyleBackColor = false;
            // 
            // btNuevo
            // 
            _btNuevo.BackColor = Color.SteelBlue;
            _btNuevo.Cursor = Cursors.Default;
            _btNuevo.DialogResult = DialogResult.Cancel;
            _btNuevo.FlatStyle = FlatStyle.Flat;
            _btNuevo.ForeColor = Color.White;
            _btNuevo.Location = new Point(136, 408);
            _btNuevo.Name = "_btNuevo";
            _btNuevo.RightToLeft = RightToLeft.No;
            _btNuevo.Size = new Size(61, 25);
            _btNuevo.TabIndex = 7;
            _btNuevo.Text = "&Nueva";
            ToolTip1.SetToolTip(_btNuevo, "Elija para ingresar un nuevo nivel");
            _btNuevo.UseVisualStyleBackColor = false;
            // 
            // btnImprimir
            // 
            _btnImprimir.BackColor = Color.SteelBlue;
            _btnImprimir.Cursor = Cursors.Default;
            _btnImprimir.DialogResult = DialogResult.Cancel;
            _btnImprimir.FlatStyle = FlatStyle.Flat;
            _btnImprimir.ForeColor = Color.White;
            _btnImprimir.Location = new Point(203, 408);
            _btnImprimir.Name = "_btnImprimir";
            _btnImprimir.RightToLeft = RightToLeft.No;
            _btnImprimir.Size = new Size(61, 25);
            _btnImprimir.TabIndex = 14;
            _btnImprimir.Text = "&Imprimir";
            ToolTip1.SetToolTip(_btnImprimir, "Elija para ingresar un nuevo nivel");
            _btnImprimir.UseVisualStyleBackColor = false;
            // 
            // OpCentrosCosto
            // 
            _OpCentrosCosto.BackColor = Color.Transparent;
            _OpCentrosCosto.CheckAlign = ContentAlignment.MiddleRight;
            _OpCentrosCosto.Cursor = Cursors.Default;
            _OpCentrosCosto.ForeColor = Color.White;
            _OpCentrosCosto.Location = new Point(444, 10);
            _OpCentrosCosto.Name = "_OpCentrosCosto";
            _OpCentrosCosto.RightToLeft = RightToLeft.No;
            _OpCentrosCosto.Size = new Size(181, 17);
            _OpCentrosCosto.TabIndex = 12;
            _OpCentrosCosto.Text = "Cuentas con clasificadores";
            _OpCentrosCosto.UseVisualStyleBackColor = false;
            // 
            // PorInicial
            // 
            _PorInicial.BackColor = Color.Transparent;
            _PorInicial.CheckAlign = ContentAlignment.MiddleRight;
            _PorInicial.Cursor = Cursors.Default;
            _PorInicial.ForeColor = Color.White;
            _PorInicial.Location = new Point(285, 2);
            _PorInicial.Name = "_PorInicial";
            _PorInicial.RightToLeft = RightToLeft.No;
            _PorInicial.Size = new Size(113, 16);
            _PorInicial.TabIndex = 11;
            _PorInicial.Text = "Busca con nicial";
            _PorInicial.UseVisualStyleBackColor = false;
            // 
            // OpComodines
            // 
            _OpComodines.BackColor = Color.Transparent;
            _OpComodines.CheckAlign = ContentAlignment.MiddleRight;
            _OpComodines.Cursor = Cursors.Default;
            _OpComodines.ForeColor = Color.White;
            _OpComodines.Location = new Point(445, 27);
            _OpComodines.Name = "_OpComodines";
            _OpComodines.RightToLeft = RightToLeft.No;
            _OpComodines.Size = new Size(181, 17);
            _OpComodines.TabIndex = 10;
            _OpComodines.Text = "Comodines para contabilización";
            _OpComodines.UseVisualStyleBackColor = false;
            // 
            // Optcodigo
            // 
            _Optcodigo.BackColor = Color.Transparent;
            _Optcodigo.CheckAlign = ContentAlignment.MiddleRight;
            _Optcodigo.Checked = true;
            _Optcodigo.Cursor = Cursors.Default;
            _Optcodigo.ForeColor = Color.White;
            _Optcodigo.Location = new Point(12, 3);
            _Optcodigo.Name = "_Optcodigo";
            _Optcodigo.RightToLeft = RightToLeft.No;
            _Optcodigo.Size = new Size(121, 16);
            _Optcodigo.TabIndex = 4;
            _Optcodigo.TabStop = true;
            _Optcodigo.Text = "Ordenar por có&digo";
            _Optcodigo.TextImageRelation = TextImageRelation.TextBeforeImage;
            _Optcodigo.UseVisualStyleBackColor = false;
            _Optcodigo.Visible = false;
            // 
            // OptNombre
            // 
            _OptNombre.BackColor = Color.Transparent;
            _OptNombre.CheckAlign = ContentAlignment.MiddleRight;
            _OptNombre.Cursor = Cursors.Default;
            _OptNombre.ForeColor = Color.White;
            _OptNombre.Location = new Point(141, 4);
            _OptNombre.Name = "_OptNombre";
            _OptNombre.RightToLeft = RightToLeft.No;
            _OptNombre.Size = new Size(73, 16);
            _OptNombre.TabIndex = 3;
            _OptNombre.TabStop = true;
            _OptNombre.Text = "&Nombre";
            _OptNombre.TextImageRelation = TextImageRelation.TextBeforeImage;
            _OptNombre.UseVisualStyleBackColor = false;
            _OptNombre.Visible = false;
            // 
            // TxtNombre
            // 
            _TxtNombre.AcceptsReturn = true;
            _TxtNombre.BackColor = SystemColors.Window;
            _TxtNombre.Cursor = Cursors.IBeam;
            _TxtNombre.ForeColor = SystemColors.WindowText;
            _TxtNombre.Location = new Point(120, 24);
            _TxtNombre.MaxLength = 0;
            _TxtNombre.Name = "_TxtNombre";
            _TxtNombre.RightToLeft = RightToLeft.No;
            _TxtNombre.Size = new Size(278, 20);
            _TxtNombre.TabIndex = 2;
            // 
            // TextCodigo
            // 
            _TextCodigo.AcceptsReturn = true;
            _TextCodigo.BackColor = SystemColors.Window;
            _TextCodigo.Cursor = Cursors.IBeam;
            _TextCodigo.ForeColor = SystemColors.WindowText;
            _TextCodigo.Location = new Point(32, 24);
            _TextCodigo.MaxLength = 0;
            _TextCodigo.Name = "_TextCodigo";
            _TextCodigo.RightToLeft = RightToLeft.No;
            _TextCodigo.Size = new Size(89, 20);
            _TextCodigo.TabIndex = 1;
            // 
            // TxtGrupo
            // 
            _TxtGrupo.AcceptsReturn = true;
            _TxtGrupo.BackColor = SystemColors.Window;
            _TxtGrupo.Cursor = Cursors.IBeam;
            _TxtGrupo.ForeColor = SystemColors.WindowText;
            _TxtGrupo.Location = new Point(8, 24);
            _TxtGrupo.MaxLength = 0;
            _TxtGrupo.Name = "_TxtGrupo";
            _TxtGrupo.RightToLeft = RightToLeft.No;
            _TxtGrupo.Size = new Size(25, 20);
            _TxtGrupo.TabIndex = 0;
            // 
            // ListNombre
            // 
            _ListNombre.AllowUserToResizeRows = false;
            _ListNombre.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            _ListNombre.BackgroundColor = Color.White;
            DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DataGridViewCellStyle1.BackColor = Color.LightSlateGray;
            DataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            DataGridViewCellStyle1.ForeColor = SystemColors.Window;
            DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            _ListNombre.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1;
            _ListNombre.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _ListNombre.EnableHeadersVisualStyles = false;
            _ListNombre.Location = new Point(8, 50);
            _ListNombre.Name = "_ListNombre";
            DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DataGridViewCellStyle2.BackColor = Color.LightSlateGray;
            DataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            DataGridViewCellStyle2.ForeColor = SystemColors.Window;
            DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            _ListNombre.RowHeadersDefaultCellStyle = DataGridViewCellStyle2;
            _ListNombre.RowHeadersWidth = 21;
            _ListNombre.Size = new Size(618, 352);
            _ListNombre.TabIndex = 13;
            // 
            // BuscaCtaContab
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            CancelButton = _btNuevo;
            ClientSize = new Size(638, 441);
            Controls.Add(_btnImprimir);
            Controls.Add(_OpComodines);
            Controls.Add(_ListNombre);
            Controls.Add(_PorInicial);
            Controls.Add(_OpCentrosCosto);
            Controls.Add(_btncancelarbusca);
            Controls.Add(_btAceptar);
            Controls.Add(_btNuevo);
            Controls.Add(_Optcodigo);
            Controls.Add(_OptNombre);
            Controls.Add(_TxtNombre);
            Controls.Add(_TextCodigo);
            Controls.Add(_TxtGrupo);
            Cursor = Cursors.Default;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Location = new Point(3, 29);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BuscaCtaContab";
            RightToLeft = RightToLeft.No;
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Buscador de cuentas contables";
            ((System.ComponentModel.ISupportInitialize)_ListNombre).EndInit();
            FormClosed += new FormClosedEventHandler(BuscaCtaContab_FormClosed);
            Load += new EventHandler(BuscaCtaContab_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridView _ListNombre;

        internal DataGridView ListNombre
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ListNombre;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ListNombre != null)
                {
                    _ListNombre.CellEnter -= ListNombre_CellEnter;
                    _ListNombre.DoubleClick -= ListNombre_DoubleClick;
                    _ListNombre.CellMouseMove -= ListNombre_CellMouseMove;
                }

                _ListNombre = value;
                if (_ListNombre != null)
                {
                    _ListNombre.CellEnter += ListNombre_CellEnter;
                    _ListNombre.DoubleClick += ListNombre_DoubleClick;
                    _ListNombre.CellMouseMove += ListNombre_CellMouseMove;
                }
            }
        }

        private Button _btnImprimir;

        public Button btnImprimir
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnImprimir;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnImprimir != null)
                {
                    _btnImprimir.Click -= btnImprimir_Click;
                }

                _btnImprimir = value;
                if (_btnImprimir != null)
                {
                    _btnImprimir.Click += btnImprimir_Click;
                }
            }
        }
        #endregion
    }
}