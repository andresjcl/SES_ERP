using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace MantCtb
{
    [DesignerGenerated()]
    internal partial class ControlPeriodo
    {
        #region Código generado por el Diseñador de Windows Forms 
        [DebuggerNonUserCode()]
        public ControlPeriodo() : base()
        {
            // Llamada necesaria para el Diseñador de Windows Forms.
            InitializeComponent();
            _keycrear.Name = "keycrear";
            _keygrabar.Name = "keygrabar";
            _keycancelar.Name = "keycancelar";
            _keyeliminar.Name = "keyeliminar";
            _keyimprimir.Name = "keyimprimir";
            __Toolbar1_Button6.Name = "_Toolbar1_Button6";
            _keyactivar.Name = "keyactivar";
            _keycerrar.Name = "keycerrar";
            _btnExcepto.Name = "btnExcepto";
            __Toolbar1_Button10.Name = "_Toolbar1_Button10";
            _btnsalir.Name = "btnsalir";
            _Malla.Name = "Malla";
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
        private ToolStripButton _keycrear;

        public ToolStripButton keycrear
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _keycrear;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_keycrear != null)
                {
                    _keycrear.Click -= Toolbar1_ButtonClick;
                }

                _keycrear = value;
                if (_keycrear != null)
                {
                    _keycrear.Click += Toolbar1_ButtonClick;
                }
            }
        }

        private ToolStripButton _keygrabar;

        public ToolStripButton keygrabar
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _keygrabar;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_keygrabar != null)
                {
                    _keygrabar.Click -= Toolbar1_ButtonClick;
                }

                _keygrabar = value;
                if (_keygrabar != null)
                {
                    _keygrabar.Click += Toolbar1_ButtonClick;
                }
            }
        }

        private ToolStripButton _keycancelar;

        public ToolStripButton keycancelar
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _keycancelar;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_keycancelar != null)
                {
                    _keycancelar.Click -= Toolbar1_ButtonClick;
                }

                _keycancelar = value;
                if (_keycancelar != null)
                {
                    _keycancelar.Click += Toolbar1_ButtonClick;
                }
            }
        }

        private ToolStripButton _keyeliminar;

        public ToolStripButton keyeliminar
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _keyeliminar;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_keyeliminar != null)
                {
                    _keyeliminar.Click -= Toolbar1_ButtonClick;
                }

                _keyeliminar = value;
                if (_keyeliminar != null)
                {
                    _keyeliminar.Click += Toolbar1_ButtonClick;
                }
            }
        }

        private ToolStripButton _keyimprimir;

        public ToolStripButton keyimprimir
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _keyimprimir;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_keyimprimir != null)
                {
                    _keyimprimir.Click -= Toolbar1_ButtonClick;
                }

                _keyimprimir = value;
                if (_keyimprimir != null)
                {
                    _keyimprimir.Click += Toolbar1_ButtonClick;
                }
            }
        }

        private ToolStripSeparator __Toolbar1_Button6;

        public ToolStripSeparator _Toolbar1_Button6
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return __Toolbar1_Button6;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (__Toolbar1_Button6 != null)
                {
                    __Toolbar1_Button6.Click -= Toolbar1_ButtonClick;
                }

                __Toolbar1_Button6 = value;
                if (__Toolbar1_Button6 != null)
                {
                    __Toolbar1_Button6.Click += Toolbar1_ButtonClick;
                }
            }
        }

        private ToolStripButton _keyactivar;

        public ToolStripButton keyactivar
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _keyactivar;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_keyactivar != null)
                {
                    _keyactivar.Click -= Toolbar1_ButtonClick;
                }

                _keyactivar = value;
                if (_keyactivar != null)
                {
                    _keyactivar.Click += Toolbar1_ButtonClick;
                }
            }
        }

        private ToolStripButton _keycerrar;

        public ToolStripButton keycerrar
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _keycerrar;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_keycerrar != null)
                {
                    _keycerrar.Click -= Toolbar1_ButtonClick;
                }

                _keycerrar = value;
                if (_keycerrar != null)
                {
                    _keycerrar.Click += Toolbar1_ButtonClick;
                }
            }
        }

        private ToolStripButton _btnExcepto;

        public ToolStripButton btnExcepto
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _btnExcepto;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_btnExcepto != null)
                {
                    _btnExcepto.Click -= Toolbar1_ButtonClick;
                }

                _btnExcepto = value;
                if (_btnExcepto != null)
                {
                    _btnExcepto.Click += Toolbar1_ButtonClick;
                }
            }
        }

        private ToolStripSeparator __Toolbar1_Button10;

        public ToolStripSeparator _Toolbar1_Button10
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return __Toolbar1_Button10;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (__Toolbar1_Button10 != null)
                {
                    __Toolbar1_Button10.Click -= Toolbar1_ButtonClick;
                }

                __Toolbar1_Button10 = value;
                if (__Toolbar1_Button10 != null)
                {
                    __Toolbar1_Button10.Click += Toolbar1_ButtonClick;
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPeriodo));
            var DataGridViewCellStyle4 = new DataGridViewCellStyle();
            var DataGridViewCellStyle5 = new DataGridViewCellStyle();
            var DataGridViewCellStyle6 = new DataGridViewCellStyle();
            ToolTip1 = new ToolTip(components);
            ImageList1 = new ImageList(components);
            Toolbar1 = new ToolStrip();
            _keycrear = new ToolStripButton();
            _keycrear.Click += new EventHandler(Toolbar1_ButtonClick);
            _keygrabar = new ToolStripButton();
            _keygrabar.Click += new EventHandler(Toolbar1_ButtonClick);
            _keycancelar = new ToolStripButton();
            _keycancelar.Click += new EventHandler(Toolbar1_ButtonClick);
            _keyeliminar = new ToolStripButton();
            _keyeliminar.Click += new EventHandler(Toolbar1_ButtonClick);
            _keyimprimir = new ToolStripButton();
            _keyimprimir.Click += new EventHandler(Toolbar1_ButtonClick);
            __Toolbar1_Button6 = new ToolStripSeparator();
            __Toolbar1_Button6.Click += new EventHandler(Toolbar1_ButtonClick);
            _keyactivar = new ToolStripButton();
            _keyactivar.Click += new EventHandler(Toolbar1_ButtonClick);
            _keycerrar = new ToolStripButton();
            _keycerrar.Click += new EventHandler(Toolbar1_ButtonClick);
            _btnExcepto = new ToolStripButton();
            _btnExcepto.Click += new EventHandler(Toolbar1_ButtonClick);
            __Toolbar1_Button10 = new ToolStripSeparator();
            __Toolbar1_Button10.Click += new EventHandler(Toolbar1_ButtonClick);
            _btnsalir = new ToolStripButton();
            _btnsalir.Click += new EventHandler(Toolbar1_ButtonClick);
            _Malla = new DataGridView();
            _Malla.CellEnter += new DataGridViewCellEventHandler(Malla_EnterCell);
            Toolbar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_Malla).BeginInit();
            SuspendLayout();
            // 
            // ImageList1
            // 
            ImageList1.ImageStream = (ImageListStreamer)resources.GetObject("ImageList1.ImageStream");
            ImageList1.TransparentColor = Color.FromArgb(Convert.ToInt32(Conversions.ToByte(192)), Convert.ToInt32(Conversions.ToByte(192)), Convert.ToInt32(Conversions.ToByte(192)));
            ImageList1.Images.SetKeyName(0, "imgCancelar");
            ImageList1.Images.SetKeyName(1, "imgEliminar");
            ImageList1.Images.SetKeyName(2, "imgSalir");
            ImageList1.Images.SetKeyName(3, "imgGuardar");
            ImageList1.Images.SetKeyName(4, "imgCerrar");
            ImageList1.Images.SetKeyName(5, "imgNuevo");
            ImageList1.Images.SetKeyName(6, "imgAbrir");
            ImageList1.Images.SetKeyName(7, "imgExcepto");
            ImageList1.Images.SetKeyName(8, "imgExc");
            ImageList1.Images.SetKeyName(9, "imgE");
            ImageList1.Images.SetKeyName(10, "imgimprimir");
            // 
            // Toolbar1
            // 
            Toolbar1.BackColor = Color.SteelBlue;
            Toolbar1.GripStyle = ToolStripGripStyle.Hidden;
            Toolbar1.ImageList = ImageList1;
            Toolbar1.Items.AddRange(new ToolStripItem[] { _keycrear, _keygrabar, _keycancelar, _keyeliminar, _keyimprimir, __Toolbar1_Button6, _keyactivar, _keycerrar, _btnExcepto, __Toolbar1_Button10, _btnsalir });
            Toolbar1.Location = new Point(0, 0);
            Toolbar1.Name = "Toolbar1";
            Toolbar1.Size = new Size(760, 42);
            Toolbar1.TabIndex = 1;
            // 
            // keycrear
            // 
            _keycrear.AutoSize = false;
            _keycrear.ForeColor = Color.White;
            _keycrear.ImageKey = "imgNuevo";
            _keycrear.ImageScaling = ToolStripItemImageScaling.None;
            _keycrear.Name = "_keycrear";
            _keycrear.Size = new Size(55, 39);
            _keycrear.Text = "Crear";
            _keycrear.TextImageRelation = TextImageRelation.ImageAboveText;
            _keycrear.ToolTipText = "Crear periodos de un año";
            // 
            // keygrabar
            // 
            _keygrabar.AutoSize = false;
            _keygrabar.ForeColor = Color.White;
            _keygrabar.ImageKey = "imgGuardar";
            _keygrabar.ImageScaling = ToolStripItemImageScaling.None;
            _keygrabar.Name = "_keygrabar";
            _keygrabar.Size = new Size(55, 39);
            _keygrabar.Text = "Guardar";
            _keygrabar.TextImageRelation = TextImageRelation.ImageAboveText;
            _keygrabar.ToolTipText = "Guardar datos";
            // 
            // keycancelar
            // 
            _keycancelar.AutoSize = false;
            _keycancelar.ForeColor = Color.White;
            _keycancelar.ImageKey = "imgCancelar";
            _keycancelar.ImageScaling = ToolStripItemImageScaling.None;
            _keycancelar.Name = "_keycancelar";
            _keycancelar.Size = new Size(55, 39);
            _keycancelar.Text = "Cancelar";
            _keycancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // keyeliminar
            // 
            _keyeliminar.AutoSize = false;
            _keyeliminar.ForeColor = Color.White;
            _keyeliminar.ImageKey = "imgEliminar";
            _keyeliminar.ImageScaling = ToolStripItemImageScaling.None;
            _keyeliminar.Name = "_keyeliminar";
            _keyeliminar.Size = new Size(55, 39);
            _keyeliminar.Text = "Eliminar";
            _keyeliminar.TextImageRelation = TextImageRelation.ImageAboveText;
            _keyeliminar.ToolTipText = "Eliminar períodos de un año";
            // 
            // keyimprimir
            // 
            _keyimprimir.AutoSize = false;
            _keyimprimir.ForeColor = Color.White;
            _keyimprimir.ImageKey = "imgimprimir";
            _keyimprimir.ImageScaling = ToolStripItemImageScaling.None;
            _keyimprimir.Name = "_keyimprimir";
            _keyimprimir.Size = new Size(55, 39);
            _keyimprimir.Text = "Imprimir";
            _keyimprimir.TextImageRelation = TextImageRelation.ImageAboveText;
            _keyimprimir.ToolTipText = "Imprimir malla de periodos";
            // 
            // _Toolbar1_Button6
            // 
            __Toolbar1_Button6.AutoSize = false;
            __Toolbar1_Button6.ForeColor = Color.White;
            __Toolbar1_Button6.Name = "__Toolbar1_Button6";
            __Toolbar1_Button6.Size = new Size(55, 39);
            // 
            // keyactivar
            // 
            _keyactivar.AutoSize = false;
            _keyactivar.ForeColor = Color.White;
            _keyactivar.ImageKey = "imgAbrir";
            _keyactivar.ImageScaling = ToolStripItemImageScaling.None;
            _keyactivar.Name = "_keyactivar";
            _keyactivar.Size = new Size(55, 39);
            _keyactivar.Text = "Abierto";
            _keyactivar.TextImageRelation = TextImageRelation.ImageAboveText;
            _keyactivar.ToolTipText = "Activar periodos marcados";
            // 
            // keycerrar
            // 
            _keycerrar.AutoSize = false;
            _keycerrar.ForeColor = Color.White;
            _keycerrar.ImageKey = "imgCerrar";
            _keycerrar.ImageScaling = ToolStripItemImageScaling.None;
            _keycerrar.Name = "_keycerrar";
            _keycerrar.Size = new Size(55, 39);
            _keycerrar.Text = "Cerrado";
            _keycerrar.TextImageRelation = TextImageRelation.ImageAboveText;
            _keycerrar.ToolTipText = "Cerrar periodos marcados";
            // 
            // btnExcepto
            // 
            _btnExcepto.AutoSize = false;
            _btnExcepto.ForeColor = Color.White;
            _btnExcepto.ImageKey = "imgE";
            _btnExcepto.ImageScaling = ToolStripItemImageScaling.None;
            _btnExcepto.Name = "_btnExcepto";
            _btnExcepto.Size = new Size(55, 39);
            _btnExcepto.Text = "Excepto";
            _btnExcepto.TextImageRelation = TextImageRelation.ImageAboveText;
            _btnExcepto.ToolTipText = "Registrar usuarios con excepción";
            // 
            // _Toolbar1_Button10
            // 
            __Toolbar1_Button10.AutoSize = false;
            __Toolbar1_Button10.ForeColor = Color.White;
            __Toolbar1_Button10.Name = "__Toolbar1_Button10";
            __Toolbar1_Button10.Size = new Size(55, 39);
            // 
            // btnsalir
            // 
            _btnsalir.AutoSize = false;
            _btnsalir.ForeColor = Color.White;
            _btnsalir.ImageKey = "imgSalir";
            _btnsalir.ImageScaling = ToolStripItemImageScaling.None;
            _btnsalir.Name = "_btnsalir";
            _btnsalir.Size = new Size(55, 39);
            _btnsalir.Text = "Salir";
            _btnsalir.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // Malla
            // 
            _Malla.AllowUserToAddRows = false;
            _Malla.AllowUserToDeleteRows = false;
            _Malla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            _Malla.BackgroundColor = Color.White;
            DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DataGridViewCellStyle4.BackColor = Color.LightSteelBlue;
            DataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            DataGridViewCellStyle4.ForeColor = Color.White;
            DataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            DataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            DataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            _Malla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4;
            _Malla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DataGridViewCellStyle5.BackColor = Color.White;
            DataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            DataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            DataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            DataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            DataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            _Malla.DefaultCellStyle = DataGridViewCellStyle5;
            _Malla.Dock = DockStyle.Fill;
            _Malla.GridColor = Color.Gainsboro;
            _Malla.Location = new Point(0, 42);
            _Malla.Name = "_Malla";
            _Malla.ReadOnly = true;
            DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DataGridViewCellStyle6.BackColor = Color.LightSteelBlue;
            DataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            DataGridViewCellStyle6.ForeColor = Color.White;
            DataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            DataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            DataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            _Malla.RowHeadersDefaultCellStyle = DataGridViewCellStyle6;
            _Malla.Size = new Size(760, 375);
            _Malla.TabIndex = 2;
            // 
            // ControlPeriodo
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(760, 417);
            Controls.Add(_Malla);
            Controls.Add(Toolbar1);
            Cursor = Cursors.Default;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Location = new Point(3, 22);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ControlPeriodo";
            RightToLeft = RightToLeft.No;
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Control de períodos contables";
            Toolbar1.ResumeLayout(false);
            Toolbar1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_Malla).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridView _Malla;

        internal DataGridView Malla
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Malla;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Malla != null)
                {
                    _Malla.CellEnter -= Malla_EnterCell;
                }

                _Malla = value;
                if (_Malla != null)
                {
                    _Malla.CellEnter += Malla_EnterCell;
                }
            }
        }
        #endregion
    }
}