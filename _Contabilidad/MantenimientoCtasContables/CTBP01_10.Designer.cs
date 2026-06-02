using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace MantCtb
{
    [DesignerGenerated()]
    internal partial class CTBP01
    {
        #region Código generado por el Diseñador de Windows Forms 
        [DebuggerNonUserCode()]
        public CTBP01() : base()
        {
            // Llamada necesaria para el Diseñador de Windows Forms.
            InitializeComponent();
            _nueva.Name = "nueva";
            _insertar.Name = "insertar";
            _modificar.Name = "modificar";
            _eliminar.Name = "eliminar";
            _listado.Name = "listado";
            _Validar.Name = "Validar";
            _salir.Name = "salir";
            _trArbol.Name = "trArbol";
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
        private ToolStripButton _nueva;

        public ToolStripButton nueva
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _nueva;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_nueva != null)
                {
                    _nueva.Click -= Toolbar1_ButtonClick;
                }

                _nueva = value;
                if (_nueva != null)
                {
                    _nueva.Click += Toolbar1_ButtonClick;
                }
            }
        }

        private ToolStripButton _insertar;

        public ToolStripButton insertar
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _insertar;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_insertar != null)
                {
                    _insertar.Click -= Toolbar1_ButtonClick;
                }

                _insertar = value;
                if (_insertar != null)
                {
                    _insertar.Click += Toolbar1_ButtonClick;
                }
            }
        }

        private ToolStripButton _modificar;

        public ToolStripButton modificar
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _modificar;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_modificar != null)
                {
                    _modificar.Click -= Toolbar1_ButtonClick;
                }

                _modificar = value;
                if (_modificar != null)
                {
                    _modificar.Click += Toolbar1_ButtonClick;
                }
            }
        }

        private ToolStripButton _eliminar;

        public ToolStripButton eliminar
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _eliminar;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_eliminar != null)
                {
                    _eliminar.Click -= Toolbar1_ButtonClick;
                }

                _eliminar = value;
                if (_eliminar != null)
                {
                    _eliminar.Click += Toolbar1_ButtonClick;
                }
            }
        }

        private ToolStripButton _listado;

        public ToolStripButton listado
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _listado;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_listado != null)
                {
                    _listado.Click -= Toolbar1_ButtonClick;
                }

                _listado = value;
                if (_listado != null)
                {
                    _listado.Click += Toolbar1_ButtonClick;
                }
            }
        }

        private ToolStripButton _salir;

        public ToolStripButton salir
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _salir;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_salir != null)
                {
                    _salir.Click -= Toolbar1_ButtonClick;
                }

                _salir = value;
                if (_salir != null)
                {
                    _salir.Click += Toolbar1_ButtonClick;
                }
            }
        }

        public ToolStrip Toolbar1;
        public ImageList imlSmallIcons;
        private TreeView _trArbol;

        public TreeView trArbol
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _trArbol;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_trArbol != null)
                {
                    _trArbol.AfterSelect -= trArbol_AfterSelect;
                }

                _trArbol = value;
                if (_trArbol != null)
                {
                    _trArbol.AfterSelect += trArbol_AfterSelect;
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(CTBP01));
            var TreeNode1 = new TreeNode("Nodo0");
            ToolTip1 = new ToolTip(components);
            Toolbar1 = new ToolStrip();
            imlSmallIcons = new ImageList(components);
            _nueva = new ToolStripButton();
            _nueva.Click += new EventHandler(Toolbar1_ButtonClick);
            _insertar = new ToolStripButton();
            _insertar.Click += new EventHandler(Toolbar1_ButtonClick);
            _modificar = new ToolStripButton();
            _modificar.Click += new EventHandler(Toolbar1_ButtonClick);
            _eliminar = new ToolStripButton();
            _eliminar.Click += new EventHandler(Toolbar1_ButtonClick);
            _listado = new ToolStripButton();
            _listado.Click += new EventHandler(Toolbar1_ButtonClick);
            _Validar = new ToolStripButton();
            _Validar.Click += new EventHandler(Validar_Click);
            _salir = new ToolStripButton();
            _salir.Click += new EventHandler(Toolbar1_ButtonClick);
            _trArbol = new TreeView();
            _trArbol.AfterSelect += new TreeViewEventHandler(trArbol_AfterSelect);
            Toolbar1.SuspendLayout();
            SuspendLayout();
            // 
            // Toolbar1
            // 
            Toolbar1.BackColor = Color.SteelBlue;
            Toolbar1.GripStyle = ToolStripGripStyle.Hidden;
            Toolbar1.ImageList = imlSmallIcons;
            Toolbar1.Items.AddRange(new ToolStripItem[] { _nueva, _insertar, _modificar, _eliminar, _listado, _Validar, _salir });
            Toolbar1.Location = new Point(0, 0);
            Toolbar1.Name = "Toolbar1";
            Toolbar1.RenderMode = ToolStripRenderMode.Professional;
            Toolbar1.Size = new Size(692, 46);
            Toolbar1.TabIndex = 1;
            // 
            // imlSmallIcons
            // 
            imlSmallIcons.ImageStream = (ImageListStreamer)resources.GetObject("imlSmallIcons.ImageStream");
            imlSmallIcons.TransparentColor = Color.FromArgb(Convert.ToInt32(Conversions.ToByte(192)), Convert.ToInt32(Conversions.ToByte(192)), Convert.ToInt32(Conversions.ToByte(192)));
            imlSmallIcons.Images.SetKeyName(0, "");
            imlSmallIcons.Images.SetKeyName(1, "");
            imlSmallIcons.Images.SetKeyName(2, "");
            imlSmallIcons.Images.SetKeyName(3, "");
            imlSmallIcons.Images.SetKeyName(4, "");
            imlSmallIcons.Images.SetKeyName(5, "imgnueva");
            imlSmallIcons.Images.SetKeyName(6, "imginsertar");
            imlSmallIcons.Images.SetKeyName(7, "imgmodificar");
            imlSmallIcons.Images.SetKeyName(8, "imgeliminar");
            imlSmallIcons.Images.SetKeyName(9, "imglista");
            imlSmallIcons.Images.SetKeyName(10, "imgsalir");
            imlSmallIcons.Images.SetKeyName(11, "seleccionado.gif");
            // 
            // nueva
            // 
            _nueva.AutoSize = false;
            _nueva.ForeColor = Color.White;
            _nueva.ImageKey = "imgnueva";
            _nueva.ImageScaling = ToolStripItemImageScaling.None;
            _nueva.Name = "_nueva";
            _nueva.Size = new Size(69, 39);
            _nueva.Text = "&Nueva";
            _nueva.TextImageRelation = TextImageRelation.ImageAboveText;
            _nueva.ToolTipText = "Crear nueva cuenta al mismo nivel";
            // 
            // insertar
            // 
            _insertar.AutoSize = false;
            _insertar.ForeColor = Color.White;
            _insertar.ImageKey = "imginsertar";
            _insertar.ImageScaling = ToolStripItemImageScaling.None;
            _insertar.Name = "_insertar";
            _insertar.Size = new Size(69, 39);
            _insertar.Text = "&Insertar";
            _insertar.TextImageRelation = TextImageRelation.ImageAboveText;
            _insertar.ToolTipText = "Crear nueva cuenta en el nivel inferior";
            // 
            // modificar
            // 
            _modificar.AutoSize = false;
            _modificar.ForeColor = Color.White;
            _modificar.ImageKey = "imgmodificar";
            _modificar.ImageScaling = ToolStripItemImageScaling.None;
            _modificar.Name = "_modificar";
            _modificar.Size = new Size(69, 39);
            _modificar.Text = "&Modificar";
            _modificar.TextImageRelation = TextImageRelation.ImageAboveText;
            _modificar.ToolTipText = "Cambiar datos de la cunta existente";
            // 
            // eliminar
            // 
            _eliminar.AutoSize = false;
            _eliminar.ForeColor = Color.White;
            _eliminar.ImageKey = "imgeliminar";
            _eliminar.ImageScaling = ToolStripItemImageScaling.None;
            _eliminar.Name = "_eliminar";
            _eliminar.Size = new Size(69, 39);
            _eliminar.Text = "&Eliminar";
            _eliminar.TextImageRelation = TextImageRelation.ImageAboveText;
            _eliminar.ToolTipText = "Elimina la cuenta contable";
            // 
            // listado
            // 
            _listado.AutoSize = false;
            _listado.ForeColor = Color.White;
            _listado.ImageKey = "imglista";
            _listado.ImageScaling = ToolStripItemImageScaling.None;
            _listado.Name = "_listado";
            _listado.Size = new Size(69, 39);
            _listado.Text = "&Lista";
            _listado.TextImageRelation = TextImageRelation.ImageAboveText;
            _listado.ToolTipText = "Lista del plan de cuentas";
            // 
            // Validar
            // 
            _Validar.ForeColor = Color.White;
            _Validar.Image = (Image)resources.GetObject("Validar.Image");
            _Validar.ImageAlign = ContentAlignment.TopCenter;
            _Validar.ImageScaling = ToolStripItemImageScaling.None;
            _Validar.ImageTransparentColor = Color.Magenta;
            _Validar.Name = "_Validar";
            _Validar.Size = new Size(42, 43);
            _Validar.Text = "&Valida";
            _Validar.TextAlign = ContentAlignment.BottomCenter;
            _Validar.TextImageRelation = TextImageRelation.ImageAboveText;
            _Validar.ToolTipText = "Buscar inconsistencias en el plan de cuentas";
            // 
            // salir
            // 
            _salir.AutoSize = false;
            _salir.ForeColor = Color.White;
            _salir.ImageAlign = ContentAlignment.TopCenter;
            _salir.ImageKey = "imgsalir";
            _salir.Name = "_salir";
            _salir.Size = new Size(69, 39);
            _salir.Text = "&Salir";
            _salir.TextAlign = ContentAlignment.BottomCenter;
            _salir.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // trArbol
            // 
            _trArbol.BorderStyle = BorderStyle.FixedSingle;
            _trArbol.Dock = DockStyle.Fill;
            _trArbol.ImageKey = "seleccionado.gif";
            _trArbol.ImageList = imlSmallIcons;
            _trArbol.Indent = 40;
            _trArbol.LineColor = Color.SteelBlue;
            _trArbol.Location = new Point(0, 46);
            _trArbol.Name = "_trArbol";
            TreeNode1.Name = "Nodo0";
            TreeNode1.Text = "Nodo0";
            _trArbol.Nodes.AddRange(new TreeNode[] { TreeNode1 });
            _trArbol.RightToLeftLayout = true;
            _trArbol.SelectedImageKey = "seleccionado.gif";
            _trArbol.ShowLines = false;
            _trArbol.ShowPlusMinus = false;
            _trArbol.Size = new Size(692, 488);
            _trArbol.TabIndex = 0;
            // 
            // CTBP01
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(692, 534);
            Controls.Add(_trArbol);
            Controls.Add(Toolbar1);
            Cursor = Cursors.Default;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Location = new Point(4, -135);
            Name = "CTBP01";
            RightToLeft = RightToLeft.No;
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Maestro de Cuentas Contables";
            Toolbar1.ResumeLayout(false);
            Toolbar1.PerformLayout();
            Resize += new EventHandler(CTBP01_Resize);
            Load += new EventHandler(CTBP01_Load);
            FormClosing += new FormClosingEventHandler(CTBP01_FormClosing);
            ResumeLayout(false);
            PerformLayout();
        }

        private ToolStripButton _Validar;

        internal ToolStripButton Validar
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Validar;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Validar != null)
                {
                    _Validar.Click -= Validar_Click;
                }

                _Validar = value;
                if (_Validar != null)
                {
                    _Validar.Click += Validar_Click;
                }
            }
        }
        #endregion
    }
}