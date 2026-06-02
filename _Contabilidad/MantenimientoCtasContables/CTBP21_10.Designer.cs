using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace MantCtb
{
    [DesignerGenerated()]
    internal partial class CTBP21
    {
        #region Código generado por el Diseñador de Windows Forms 
        [DebuggerNonUserCode()]
        public CTBP21() : base()
        {
            // Llamada necesaria para el Diseñador de Windows Forms.
            InitializeComponent();
            _Nivel6ToolStripMenuItem.Name = "Nivel6ToolStripMenuItem";
            _Nivel5ToolStripMenuItem.Name = "Nivel5ToolStripMenuItem";
            _Nivel4ToolStripMenuItem.Name = "Nivel4ToolStripMenuItem";
            _Nivel3ToolStripMenuItem.Name = "Nivel3ToolStripMenuItem";
            _Nivel2ToolStripMenuItem.Name = "Nivel2ToolStripMenuItem";
            _Nivel1ToolStripMenuItem.Name = "Nivel1ToolStripMenuItem";
            _todas.Name = "todas";
            _movimiento.Name = "movimiento";
            _comodines.Name = "comodines";
            _clasificadores.Name = "clasificadores";
            _btnactualizar.Name = "btnactualizar";
            _btnimprimir.Name = "btnimprimir";
            _ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem";
            _WordToolStripMenuItem.Name = "WordToolStripMenuItem";
            _ExcelToolStripMenuItem.Name = "ExcelToolStripMenuItem";
            _PDFToolStripMenuItem.Name = "PDFToolStripMenuItem";
            _btnsalir.Name = "btnsalir";
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
        public ImageList ImageList1;
        private ToolStripButton _btnactualizar;

        public ToolStripButton btnactualizar
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnactualizar;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnactualizar != null)
                {
                    _btnactualizar.Click -= Toolbar1_ButtonClick;
                }

                _btnactualizar = value;
                if (_btnactualizar != null)
                {
                    _btnactualizar.Click += Toolbar1_ButtonClick;
                }
            }
        }

        private ToolStripButton _btnsalir;

        public ToolStripButton btnsalir
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnsalir;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnsalir != null)
                {
                    _btnsalir.Click -= Toolbar1_ButtonClick;
                }

                _btnsalir = value;
                if (_btnsalir != null)
                {
                    _btnsalir.Click += Toolbar1_ButtonClick;
                }
            }
        }

        public ToolStrip Toolbar1;
        // NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
        // Se puede modificar mediante el Diseñador de Windows Forms.
        // No lo modifique con el editor de código.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(CTBP21));
            var DataGridViewCellStyle3 = new DataGridViewCellStyle();
            var DataGridViewCellStyle4 = new DataGridViewCellStyle();
            ToolTip1 = new ToolTip(components);
            ImageList1 = new ImageList(components);
            Toolbar1 = new ToolStrip();
            Nivel = new ToolStripSplitButton();
            _Nivel6ToolStripMenuItem = new ToolStripMenuItem();
            _Nivel6ToolStripMenuItem.Click += new EventHandler(Nivel6ToolStripMenuItem_Click);
            _Nivel5ToolStripMenuItem = new ToolStripMenuItem();
            _Nivel5ToolStripMenuItem.Click += new EventHandler(Nivel5ToolStripMenuItem_Click);
            _Nivel4ToolStripMenuItem = new ToolStripMenuItem();
            _Nivel4ToolStripMenuItem.Click += new EventHandler(Nivel4ToolStripMenuItem_Click);
            _Nivel3ToolStripMenuItem = new ToolStripMenuItem();
            _Nivel3ToolStripMenuItem.Click += new EventHandler(Nivel3ToolStripMenuItem_Click);
            _Nivel2ToolStripMenuItem = new ToolStripMenuItem();
            _Nivel2ToolStripMenuItem.Click += new EventHandler(Nivel2ToolStripMenuItem_Click);
            _Nivel1ToolStripMenuItem = new ToolStripMenuItem();
            _Nivel1ToolStripMenuItem.Click += new EventHandler(Nivel1ToolStripMenuItem_Click);
            CuentaCtas = new ToolStripSplitButton();
            _todas = new ToolStripMenuItem();
            _todas.Click += new EventHandler(TodasLasCtasToolStripMenuItem_Click);
            _movimiento = new ToolStripMenuItem();
            _movimiento.Click += new EventHandler(CtasMovimientoToolStripMenuItem_Click);
            _comodines = new ToolStripMenuItem();
            _comodines.Click += new EventHandler(ComodinesToolStripMenuItem_Click);
            _clasificadores = new ToolStripMenuItem();
            _clasificadores.Click += new EventHandler(clasificadoresToolStripMenuItem_Click);
            _btnactualizar = new ToolStripButton();
            _btnactualizar.Click += new EventHandler(Toolbar1_ButtonClick);
            _btnimprimir = new ToolStripSplitButton();
            _btnimprimir.Click += new EventHandler(Toolbar1_ButtonClick);
            _btnimprimir.ButtonClick += new EventHandler(btnimprimir_ButtonClick);
            _ImprimirToolStripMenuItem = new ToolStripMenuItem();
            _ImprimirToolStripMenuItem.Click += new EventHandler(ImprimirToolStripMenuItem_Click);
            _WordToolStripMenuItem = new ToolStripMenuItem();
            _WordToolStripMenuItem.Click += new EventHandler(WordToolStripMenuItem_Click);
            _ExcelToolStripMenuItem = new ToolStripMenuItem();
            _ExcelToolStripMenuItem.Click += new EventHandler(ExcelToolStripMenuItem_Click);
            _PDFToolStripMenuItem = new ToolStripMenuItem();
            _PDFToolStripMenuItem.Click += new EventHandler(PDFToolStripMenuItem_Click);
            _btnsalir = new ToolStripButton();
            _btnsalir.Click += new EventHandler(Toolbar1_ButtonClick);
            MALLA = new DataGridView();
            Toolbar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MALLA).BeginInit();
            SuspendLayout();
            // 
            // ImageList1
            // 
            ImageList1.ImageStream = (ImageListStreamer)resources.GetObject("ImageList1.ImageStream");
            ImageList1.TransparentColor = Color.FromArgb(Convert.ToInt32(Conversions.ToByte(192)), Convert.ToInt32(Conversions.ToByte(192)), Convert.ToInt32(Conversions.ToByte(192)));
            ImageList1.Images.SetKeyName(0, "imgactualizar");
            ImageList1.Images.SetKeyName(1, "imgimprimir");
            ImageList1.Images.SetKeyName(2, "imgsalir");
            // 
            // Toolbar1
            // 
            Toolbar1.BackColor = Color.SteelBlue;
            Toolbar1.GripStyle = ToolStripGripStyle.Hidden;
            Toolbar1.ImageList = ImageList1;
            Toolbar1.Items.AddRange(new ToolStripItem[] { Nivel, CuentaCtas, _btnactualizar, _btnimprimir, _btnsalir });
            Toolbar1.Location = new Point(0, 0);
            Toolbar1.Name = "Toolbar1";
            Toolbar1.Size = new Size(726, 42);
            Toolbar1.TabIndex = 13;
            // 
            // Nivel
            // 
            Nivel.DropDownItems.AddRange(new ToolStripItem[] { _Nivel6ToolStripMenuItem, _Nivel5ToolStripMenuItem, _Nivel4ToolStripMenuItem, _Nivel3ToolStripMenuItem, _Nivel2ToolStripMenuItem, _Nivel1ToolStripMenuItem });
            Nivel.ForeColor = Color.White;
            Nivel.Image = (Image)resources.GetObject("Nivel.Image");
            Nivel.ImageAlign = ContentAlignment.TopCenter;
            Nivel.ImageTransparentColor = Color.Magenta;
            Nivel.Name = "Nivel";
            Nivel.Overflow = ToolStripItemOverflow.Never;
            Nivel.Size = new Size(61, 39);
            Nivel.Text = "Nivel-6";
            Nivel.TextAlign = ContentAlignment.BottomLeft;
            Nivel.TextDirection = ToolStripTextDirection.Horizontal;
            Nivel.TextImageRelation = TextImageRelation.ImageAboveText;
            Nivel.ToolTipText = "Imprimir hasta el nivel deseado";
            // 
            // Nivel6ToolStripMenuItem
            // 
            _Nivel6ToolStripMenuItem.Name = "_Nivel6ToolStripMenuItem";
            _Nivel6ToolStripMenuItem.Size = new Size(112, 22);
            _Nivel6ToolStripMenuItem.Text = "Nivel-6";
            // 
            // Nivel5ToolStripMenuItem
            // 
            _Nivel5ToolStripMenuItem.Name = "_Nivel5ToolStripMenuItem";
            _Nivel5ToolStripMenuItem.Size = new Size(112, 22);
            _Nivel5ToolStripMenuItem.Text = "Nivel-5";
            // 
            // Nivel4ToolStripMenuItem
            // 
            _Nivel4ToolStripMenuItem.Name = "_Nivel4ToolStripMenuItem";
            _Nivel4ToolStripMenuItem.Size = new Size(112, 22);
            _Nivel4ToolStripMenuItem.Text = "Nivel-4";
            // 
            // Nivel3ToolStripMenuItem
            // 
            _Nivel3ToolStripMenuItem.Name = "_Nivel3ToolStripMenuItem";
            _Nivel3ToolStripMenuItem.Size = new Size(112, 22);
            _Nivel3ToolStripMenuItem.Text = "Nivel-3";
            // 
            // Nivel2ToolStripMenuItem
            // 
            _Nivel2ToolStripMenuItem.Name = "_Nivel2ToolStripMenuItem";
            _Nivel2ToolStripMenuItem.Size = new Size(112, 22);
            _Nivel2ToolStripMenuItem.Text = "Nivel-2";
            // 
            // Nivel1ToolStripMenuItem
            // 
            _Nivel1ToolStripMenuItem.Name = "_Nivel1ToolStripMenuItem";
            _Nivel1ToolStripMenuItem.Size = new Size(112, 22);
            _Nivel1ToolStripMenuItem.Text = "Nivel-1";
            // 
            // CuentaCtas
            // 
            CuentaCtas.DropDownItems.AddRange(new ToolStripItem[] { _todas, _movimiento, _comodines, _clasificadores });
            CuentaCtas.ForeColor = Color.White;
            CuentaCtas.Image = (Image)resources.GetObject("CuentaCtas.Image");
            CuentaCtas.ImageAlign = ContentAlignment.TopCenter;
            CuentaCtas.ImageTransparentColor = Color.Magenta;
            CuentaCtas.Name = "CuentaCtas";
            CuentaCtas.Size = new Size(54, 39);
            CuentaCtas.Text = "Todas";
            CuentaCtas.TextAlign = ContentAlignment.BottomCenter;
            CuentaCtas.TextImageRelation = TextImageRelation.ImageAboveText;
            CuentaCtas.ToolTipText = "Todas las Cuentas";
            // 
            // todas
            // 
            _todas.Name = "_todas";
            _todas.Size = new Size(169, 22);
            _todas.Text = "Ctas.Todas";
            // 
            // movimiento
            // 
            _movimiento.Name = "_movimiento";
            _movimiento.Size = new Size(169, 22);
            _movimiento.Text = "Ctas.Movimiento";
            // 
            // comodines
            // 
            _comodines.Name = "_comodines";
            _comodines.Size = new Size(169, 22);
            _comodines.Text = "Comodines";
            // 
            // clasificadores
            // 
            _clasificadores.Name = "_clasificadores";
            _clasificadores.Size = new Size(169, 22);
            _clasificadores.Text = "ConClasificadores";
            // 
            // btnactualizar
            // 
            _btnactualizar.AutoSize = false;
            _btnactualizar.ForeColor = Color.White;
            _btnactualizar.ImageKey = "imgactualizar";
            _btnactualizar.ImageScaling = ToolStripItemImageScaling.None;
            _btnactualizar.Name = "_btnactualizar";
            _btnactualizar.Size = new Size(70, 39);
            _btnactualizar.Text = "&Actualizar";
            _btnactualizar.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // btnimprimir
            // 
            _btnimprimir.AutoSize = false;
            _btnimprimir.DropDownItems.AddRange(new ToolStripItem[] { _ImprimirToolStripMenuItem, _WordToolStripMenuItem, _ExcelToolStripMenuItem, _PDFToolStripMenuItem });
            _btnimprimir.ForeColor = Color.White;
            _btnimprimir.ImageKey = "imgimprimir";
            _btnimprimir.ImageScaling = ToolStripItemImageScaling.None;
            _btnimprimir.Name = "_btnimprimir";
            _btnimprimir.Size = new Size(70, 39);
            _btnimprimir.Text = "&Enviar";
            _btnimprimir.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // ImprimirToolStripMenuItem
            // 
            _ImprimirToolStripMenuItem.Image = My.Resources.Resources.Printer_Green;
            _ImprimirToolStripMenuItem.Name = "_ImprimirToolStripMenuItem";
            _ImprimirToolStripMenuItem.Size = new Size(120, 22);
            _ImprimirToolStripMenuItem.Text = "Imprimir";
            // 
            // WordToolStripMenuItem
            // 
            _WordToolStripMenuItem.Image = My.Resources.Resources.page_white_word;
            _WordToolStripMenuItem.Name = "_WordToolStripMenuItem";
            _WordToolStripMenuItem.Size = new Size(120, 22);
            _WordToolStripMenuItem.Text = "Word";
            // 
            // ExcelToolStripMenuItem
            // 
            _ExcelToolStripMenuItem.Image = My.Resources.Resources.page_excel;
            _ExcelToolStripMenuItem.Name = "_ExcelToolStripMenuItem";
            _ExcelToolStripMenuItem.Size = new Size(120, 22);
            _ExcelToolStripMenuItem.Text = "Excel";
            // 
            // PDFToolStripMenuItem
            // 
            _PDFToolStripMenuItem.Image = My.Resources.Resources.page_white_acrobat;
            _PDFToolStripMenuItem.Name = "_PDFToolStripMenuItem";
            _PDFToolStripMenuItem.Size = new Size(120, 22);
            _PDFToolStripMenuItem.Text = "PDF";
            // 
            // btnsalir
            // 
            _btnsalir.AutoSize = false;
            _btnsalir.ForeColor = Color.White;
            _btnsalir.ImageKey = "imgsalir";
            _btnsalir.ImageScaling = ToolStripItemImageScaling.None;
            _btnsalir.Name = "_btnsalir";
            _btnsalir.Size = new Size(70, 39);
            _btnsalir.Text = "&Salir";
            _btnsalir.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // MALLA
            // 
            MALLA.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            MALLA.BackgroundColor = Color.White;
            DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DataGridViewCellStyle3.BackColor = Color.LightSlateGray;
            DataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            DataGridViewCellStyle3.ForeColor = SystemColors.Window;
            DataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            DataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            MALLA.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3;
            MALLA.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            MALLA.Dock = DockStyle.Fill;
            MALLA.EnableHeadersVisualStyles = false;
            MALLA.GridColor = Color.Gainsboro;
            MALLA.Location = new Point(0, 42);
            MALLA.Name = "MALLA";
            DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DataGridViewCellStyle4.BackColor = Color.LightSlateGray;
            DataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            DataGridViewCellStyle4.ForeColor = SystemColors.Window;
            DataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            DataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            DataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            MALLA.RowHeadersDefaultCellStyle = DataGridViewCellStyle4;
            MALLA.RowHeadersWidth = 21;
            MALLA.Size = new Size(726, 541);
            MALLA.TabIndex = 14;
            // 
            // CTBP21
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(726, 583);
            Controls.Add(MALLA);
            Controls.Add(Toolbar1);
            Cursor = Cursors.Default;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Location = new Point(4, 23);
            Name = "CTBP21";
            RightToLeft = RightToLeft.No;
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Plan de Cuentas contables";
            Toolbar1.ResumeLayout(false);
            Toolbar1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)MALLA).EndInit();
            Load += new EventHandler(CTBP21_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        internal ToolStripSplitButton Nivel;
        private ToolStripMenuItem _Nivel1ToolStripMenuItem;

        internal ToolStripMenuItem Nivel1ToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Nivel1ToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Nivel1ToolStripMenuItem != null)
                {
                    _Nivel1ToolStripMenuItem.Click -= Nivel1ToolStripMenuItem_Click;
                }

                _Nivel1ToolStripMenuItem = value;
                if (_Nivel1ToolStripMenuItem != null)
                {
                    _Nivel1ToolStripMenuItem.Click += Nivel1ToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _Nivel2ToolStripMenuItem;

        internal ToolStripMenuItem Nivel2ToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Nivel2ToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Nivel2ToolStripMenuItem != null)
                {
                    _Nivel2ToolStripMenuItem.Click -= Nivel2ToolStripMenuItem_Click;
                }

                _Nivel2ToolStripMenuItem = value;
                if (_Nivel2ToolStripMenuItem != null)
                {
                    _Nivel2ToolStripMenuItem.Click += Nivel2ToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _Nivel3ToolStripMenuItem;

        internal ToolStripMenuItem Nivel3ToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Nivel3ToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Nivel3ToolStripMenuItem != null)
                {
                    _Nivel3ToolStripMenuItem.Click -= Nivel3ToolStripMenuItem_Click;
                }

                _Nivel3ToolStripMenuItem = value;
                if (_Nivel3ToolStripMenuItem != null)
                {
                    _Nivel3ToolStripMenuItem.Click += Nivel3ToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _Nivel4ToolStripMenuItem;

        internal ToolStripMenuItem Nivel4ToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Nivel4ToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Nivel4ToolStripMenuItem != null)
                {
                    _Nivel4ToolStripMenuItem.Click -= Nivel4ToolStripMenuItem_Click;
                }

                _Nivel4ToolStripMenuItem = value;
                if (_Nivel4ToolStripMenuItem != null)
                {
                    _Nivel4ToolStripMenuItem.Click += Nivel4ToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _Nivel5ToolStripMenuItem;

        internal ToolStripMenuItem Nivel5ToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Nivel5ToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Nivel5ToolStripMenuItem != null)
                {
                    _Nivel5ToolStripMenuItem.Click -= Nivel5ToolStripMenuItem_Click;
                }

                _Nivel5ToolStripMenuItem = value;
                if (_Nivel5ToolStripMenuItem != null)
                {
                    _Nivel5ToolStripMenuItem.Click += Nivel5ToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _Nivel6ToolStripMenuItem;

        internal ToolStripMenuItem Nivel6ToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Nivel6ToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Nivel6ToolStripMenuItem != null)
                {
                    _Nivel6ToolStripMenuItem.Click -= Nivel6ToolStripMenuItem_Click;
                }

                _Nivel6ToolStripMenuItem = value;
                if (_Nivel6ToolStripMenuItem != null)
                {
                    _Nivel6ToolStripMenuItem.Click += Nivel6ToolStripMenuItem_Click;
                }
            }
        }

        internal ToolStripSplitButton CuentaCtas;
        private ToolStripMenuItem _movimiento;

        internal ToolStripMenuItem movimiento
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _movimiento;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_movimiento != null)
                {
                    _movimiento.Click -= CtasMovimientoToolStripMenuItem_Click;
                }

                _movimiento = value;
                if (_movimiento != null)
                {
                    _movimiento.Click += CtasMovimientoToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _todas;

        internal ToolStripMenuItem todas
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _todas;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_todas != null)
                {
                    _todas.Click -= TodasLasCtasToolStripMenuItem_Click;
                }

                _todas = value;
                if (_todas != null)
                {
                    _todas.Click += TodasLasCtasToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _comodines;

        internal ToolStripMenuItem comodines
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _comodines;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_comodines != null)
                {
                    _comodines.Click -= ComodinesToolStripMenuItem_Click;
                }

                _comodines = value;
                if (_comodines != null)
                {
                    _comodines.Click += ComodinesToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _clasificadores;

        internal ToolStripMenuItem clasificadores
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _clasificadores;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_clasificadores != null)
                {
                    _clasificadores.Click -= clasificadoresToolStripMenuItem_Click;
                }

                _clasificadores = value;
                if (_clasificadores != null)
                {
                    _clasificadores.Click += clasificadoresToolStripMenuItem_Click;
                }
            }
        }

        internal DataGridView MALLA;
        private ToolStripSplitButton _btnimprimir;

        public ToolStripSplitButton btnimprimir
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnimprimir;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnimprimir != null)
                {
                    _btnimprimir.Click -= Toolbar1_ButtonClick;
                    _btnimprimir.ButtonClick -= btnimprimir_ButtonClick;
                }

                _btnimprimir = value;
                if (_btnimprimir != null)
                {
                    _btnimprimir.Click += Toolbar1_ButtonClick;
                    _btnimprimir.ButtonClick += btnimprimir_ButtonClick;
                }
            }
        }

        private ToolStripMenuItem _ImprimirToolStripMenuItem;

        internal ToolStripMenuItem ImprimirToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ImprimirToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ImprimirToolStripMenuItem != null)
                {
                    _ImprimirToolStripMenuItem.Click -= ImprimirToolStripMenuItem_Click;
                }

                _ImprimirToolStripMenuItem = value;
                if (_ImprimirToolStripMenuItem != null)
                {
                    _ImprimirToolStripMenuItem.Click += ImprimirToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _WordToolStripMenuItem;

        internal ToolStripMenuItem WordToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _WordToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_WordToolStripMenuItem != null)
                {
                    _WordToolStripMenuItem.Click -= WordToolStripMenuItem_Click;
                }

                _WordToolStripMenuItem = value;
                if (_WordToolStripMenuItem != null)
                {
                    _WordToolStripMenuItem.Click += WordToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _ExcelToolStripMenuItem;

        internal ToolStripMenuItem ExcelToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ExcelToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ExcelToolStripMenuItem != null)
                {
                    _ExcelToolStripMenuItem.Click -= ExcelToolStripMenuItem_Click;
                }

                _ExcelToolStripMenuItem = value;
                if (_ExcelToolStripMenuItem != null)
                {
                    _ExcelToolStripMenuItem.Click += ExcelToolStripMenuItem_Click;
                }
            }
        }

        private ToolStripMenuItem _PDFToolStripMenuItem;

        internal ToolStripMenuItem PDFToolStripMenuItem
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _PDFToolStripMenuItem;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_PDFToolStripMenuItem != null)
                {
                    _PDFToolStripMenuItem.Click -= PDFToolStripMenuItem_Click;
                }

                _PDFToolStripMenuItem = value;
                if (_PDFToolStripMenuItem != null)
                {
                    _PDFToolStripMenuItem.Click += PDFToolStripMenuItem_Click;
                }
            }
        }
        #endregion
    }
}