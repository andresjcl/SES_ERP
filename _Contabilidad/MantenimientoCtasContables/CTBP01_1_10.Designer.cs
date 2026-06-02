using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace MantCtb
{
    [DesignerGenerated()]
    internal partial class CTBP01_1
    {
        #region Código generado por el Diseñador de Windows Forms 
        [DebuggerNonUserCode()]
        public CTBP01_1() : base()
        {
            // Llamada necesaria para el Diseñador de Windows Forms.
            InitializeComponent();
            _Button1.Name = "Button1";
            _chkDeAgrupacion.Name = "chkDeAgrupacion";
            _DcModulo.Name = "DcModulo";
            _chkegresobanco.Name = "chkegresobanco";
            _Chkingresobanco.Name = "Chkingresobanco";
            _chkfacturacion.Name = "chkfacturacion";
            _Chkcompras.Name = "Chkcompras";
            _dcGruCon.Name = "dcGruCon";
            _guardar.Name = "guardar";
            _salir.Name = "salir";
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
        private CheckBox _chkDeAgrupacion;

        public CheckBox chkDeAgrupacion
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkDeAgrupacion;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkDeAgrupacion != null)
                {
                    _chkDeAgrupacion.CheckStateChanged -= chkDeAgrupacion_CheckStateChanged;
                    _chkDeAgrupacion.CheckedChanged -= chkDeAgrupacion_CheckedChanged;
                }

                _chkDeAgrupacion = value;
                if (_chkDeAgrupacion != null)
                {
                    _chkDeAgrupacion.CheckStateChanged += chkDeAgrupacion_CheckStateChanged;
                    _chkDeAgrupacion.CheckedChanged += chkDeAgrupacion_CheckedChanged;
                }
            }
        }

        public TextBox Formatodetalle;
        private ComboBox _DcModulo;

        public ComboBox DcModulo
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _DcModulo;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_DcModulo != null)
                {
                    _DcModulo.SelectedIndexChanged -= DcModulo_SelectedIndexChanged;
                }

                _DcModulo = value;
                if (_DcModulo != null)
                {
                    _DcModulo.SelectedIndexChanged += DcModulo_SelectedIndexChanged;
                }
            }
        }

        public RadioButton Option1;
        public RadioButton opbienes;
        public CheckBox chiva;
        private CheckBox _chkegresobanco;

        public CheckBox chkegresobanco
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkegresobanco;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkegresobanco != null)
                {
                    _chkegresobanco.CheckStateChanged -= chkegresobanco_CheckStateChanged;
                }

                _chkegresobanco = value;
                if (_chkegresobanco != null)
                {
                    _chkegresobanco.CheckStateChanged += chkegresobanco_CheckStateChanged;
                }
            }
        }

        private CheckBox _Chkingresobanco;

        public CheckBox Chkingresobanco
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Chkingresobanco;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Chkingresobanco != null)
                {
                    _Chkingresobanco.CheckStateChanged -= Chkingresobanco_CheckStateChanged;
                }

                _Chkingresobanco = value;
                if (_Chkingresobanco != null)
                {
                    _Chkingresobanco.CheckStateChanged += Chkingresobanco_CheckStateChanged;
                }
            }
        }

        private CheckBox _chkfacturacion;

        public CheckBox chkfacturacion
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _chkfacturacion;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_chkfacturacion != null)
                {
                    _chkfacturacion.CheckStateChanged -= chkfacturacion_CheckStateChanged;
                }

                _chkfacturacion = value;
                if (_chkfacturacion != null)
                {
                    _chkfacturacion.CheckStateChanged += chkfacturacion_CheckStateChanged;
                }
            }
        }

        private CheckBox _Chkcompras;

        public CheckBox Chkcompras
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Chkcompras;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Chkcompras != null)
                {
                    _Chkcompras.CheckStateChanged -= Chkcompras_CheckStateChanged;
                }

                _Chkcompras = value;
                if (_Chkcompras != null)
                {
                    _Chkcompras.CheckStateChanged += Chkcompras_CheckStateChanged;
                }
            }
        }

        public GroupBox Frconceptos;
        public TextBox CtaAlterna;
        public TextBox txtNomCta;
        public Label Label14;
        public Label Label13;
        public Label Label15;
        public Label Label16;
        public GroupBox Frame3;
        public RadioButton opMenVar;
        public RadioButton opSinPre;
        public RadioButton opMenFij;
        public GroupBox Frame6;
        private ComboBox _dcGruCon;

        public ComboBox dcGruCon
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _dcGruCon;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_dcGruCon != null)
                {
                    _dcGruCon.SelectedIndexChanged -= dcGruCon_SelectedIndexChanged;
                }

                _dcGruCon = value;
                if (_dcGruCon != null)
                {
                    _dcGruCon.SelectedIndexChanged += dcGruCon_SelectedIndexChanged;
                }
            }
        }

        public ImageList ImageList1;
        private ToolStripButton _guardar;

        public ToolStripButton guardar
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _guardar;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_guardar != null)
                {
                    _guardar.Click -= Toolbar1_ButtonClick;
                }

                _guardar = value;
                if (_guardar != null)
                {
                    _guardar.Click += Toolbar1_ButtonClick;
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
        public Label Label4;
        public Label Label3;
        public Label Label2;
        public Label Label1;
        public Label Label5;
        public Label Label6;
        // Public WithEvents txtCodCta As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
        // NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
        // Se puede modificar mediante el Diseñador de Windows Forms.
        // No lo modifique con el editor de código.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(CTBP01_1));
            ToolTip1 = new ToolTip(components);
            _Button1 = new Button();
            _Button1.Click += new EventHandler(Button1_Click);
            _chkDeAgrupacion = new CheckBox();
            _chkDeAgrupacion.CheckStateChanged += new EventHandler(chkDeAgrupacion_CheckStateChanged);
            _chkDeAgrupacion.CheckedChanged += new EventHandler(chkDeAgrupacion_CheckedChanged);
            Formatodetalle = new TextBox();
            _DcModulo = new ComboBox();
            _DcModulo.SelectedIndexChanged += new EventHandler(DcModulo_SelectedIndexChanged);
            Frconceptos = new GroupBox();
            _chkegresobanco = new CheckBox();
            _chkegresobanco.CheckStateChanged += new EventHandler(chkegresobanco_CheckStateChanged);
            Option1 = new RadioButton();
            opbienes = new RadioButton();
            chiva = new CheckBox();
            _Chkingresobanco = new CheckBox();
            _Chkingresobanco.CheckStateChanged += new EventHandler(Chkingresobanco_CheckStateChanged);
            _chkfacturacion = new CheckBox();
            _chkfacturacion.CheckStateChanged += new EventHandler(chkfacturacion_CheckStateChanged);
            _Chkcompras = new CheckBox();
            _Chkcompras.CheckStateChanged += new EventHandler(Chkcompras_CheckStateChanged);
            CtaAlterna = new TextBox();
            txtNomCta = new TextBox();
            Frame3 = new GroupBox();
            txtC2 = new ComboBox();
            txtC4 = new ComboBox();
            txtC1 = new ComboBox();
            txtC3 = new ComboBox();
            Label14 = new Label();
            Label13 = new Label();
            Label15 = new Label();
            Label16 = new Label();
            Frame6 = new GroupBox();
            opMenVar = new RadioButton();
            opMenFij = new RadioButton();
            opSinPre = new RadioButton();
            _dcGruCon = new ComboBox();
            _dcGruCon.SelectedIndexChanged += new EventHandler(dcGruCon_SelectedIndexChanged);
            ImageList1 = new ImageList(components);
            Toolbar1 = new ToolStrip();
            _guardar = new ToolStripButton();
            _guardar.Click += new EventHandler(Toolbar1_ButtonClick);
            _salir = new ToolStripButton();
            _salir.Click += new EventHandler(Toolbar1_ButtonClick);
            Label4 = new Label();
            Label3 = new Label();
            Label2 = new Label();
            Label1 = new Label();
            Label5 = new Label();
            Label6 = new Label();
            GroupBox1 = new GroupBox();
            Clasificadores = new CheckedListBox();
            GroupBox2 = new GroupBox();
            btnNoProduccion = new RadioButton();
            btnCI = new RadioButton();
            btnCD = new RadioButton();
            btnMO = new RadioButton();
            Frconceptos.SuspendLayout();
            Frame3.SuspendLayout();
            Frame6.SuspendLayout();
            Toolbar1.SuspendLayout();
            GroupBox1.SuspendLayout();
            GroupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // Button1
            // 
            _Button1.BackColor = Color.SteelBlue;
            _Button1.ForeColor = Color.SteelBlue;
            _Button1.Location = new Point(139, 63);
            _Button1.Name = "_Button1";
            _Button1.Size = new Size(27, 14);
            _Button1.TabIndex = 41;
            ToolTip1.SetToolTip(_Button1, "Numeración automática");
            _Button1.UseVisualStyleBackColor = false;
            // 
            // chkDeAgrupacion
            // 
            _chkDeAgrupacion.BackColor = Color.Transparent;
            _chkDeAgrupacion.Cursor = Cursors.Default;
            _chkDeAgrupacion.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _chkDeAgrupacion.ForeColor = Color.FromArgb(Convert.ToInt32(Conversions.ToByte(192)), Convert.ToInt32(Conversions.ToByte(0)), Convert.ToInt32(Conversions.ToByte(0)));
            _chkDeAgrupacion.Location = new Point(648, 52);
            _chkDeAgrupacion.Margin = new Padding(4, 3, 4, 3);
            _chkDeAgrupacion.Name = "_chkDeAgrupacion";
            _chkDeAgrupacion.RightToLeft = RightToLeft.No;
            _chkDeAgrupacion.Size = new Size(120, 49);
            _chkDeAgrupacion.TabIndex = 38;
            _chkDeAgrupacion.Text = "Es cuenta de agrupación";
            _chkDeAgrupacion.UseVisualStyleBackColor = false;
            // 
            // Formatodetalle
            // 
            Formatodetalle.AcceptsReturn = true;
            Formatodetalle.BackColor = SystemColors.Window;
            Formatodetalle.Cursor = Cursors.IBeam;
            Formatodetalle.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Formatodetalle.ForeColor = SystemColors.WindowText;
            Formatodetalle.Location = new Point(12, 437);
            Formatodetalle.Margin = new Padding(4, 3, 4, 3);
            Formatodetalle.MaxLength = 0;
            Formatodetalle.Name = "Formatodetalle";
            Formatodetalle.RightToLeft = RightToLeft.No;
            Formatodetalle.Size = new Size(762, 20);
            Formatodetalle.TabIndex = 30;
            Formatodetalle.Text = "Valor  [nrodoc] ";
            Formatodetalle.Visible = false;
            // 
            // DcModulo
            // 
            _DcModulo.BackColor = SystemColors.Window;
            _DcModulo.Cursor = Cursors.Default;
            _DcModulo.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _DcModulo.ForeColor = SystemColors.WindowText;
            _DcModulo.Location = new Point(488, 119);
            _DcModulo.Margin = new Padding(4, 3, 4, 3);
            _DcModulo.Name = "_DcModulo";
            _DcModulo.RightToLeft = RightToLeft.No;
            _DcModulo.Size = new Size(286, 21);
            _DcModulo.TabIndex = 28;
            // 
            // Frconceptos
            // 
            Frconceptos.BackColor = Color.LightSteelBlue;
            Frconceptos.Controls.Add(_chkegresobanco);
            Frconceptos.Controls.Add(Option1);
            Frconceptos.Controls.Add(opbienes);
            Frconceptos.Controls.Add(chiva);
            Frconceptos.Controls.Add(_Chkingresobanco);
            Frconceptos.Controls.Add(_chkfacturacion);
            Frconceptos.Controls.Add(_Chkcompras);
            Frconceptos.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Frconceptos.ForeColor = Color.White;
            Frconceptos.Location = new Point(12, 143);
            Frconceptos.Margin = new Padding(4, 3, 4, 3);
            Frconceptos.Name = "Frconceptos";
            Frconceptos.Padding = new Padding(0);
            Frconceptos.RightToLeft = RightToLeft.No;
            Frconceptos.Size = new Size(344, 73);
            Frconceptos.TabIndex = 27;
            Frconceptos.TabStop = false;
            Frconceptos.Text = "Propiedades como concepto:";
            // 
            // chkegresobanco
            // 
            _chkegresobanco.BackColor = Color.Transparent;
            _chkegresobanco.Cursor = Cursors.Default;
            _chkegresobanco.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _chkegresobanco.ForeColor = Color.Black;
            _chkegresobanco.Location = new Point(108, 48);
            _chkegresobanco.Margin = new Padding(4, 3, 4, 3);
            _chkegresobanco.Name = "_chkegresobanco";
            _chkegresobanco.RightToLeft = RightToLeft.No;
            _chkegresobanco.Size = new Size(89, 17);
            _chkegresobanco.TabIndex = 42;
            _chkegresobanco.Text = "Egreso Banco";
            _chkegresobanco.UseVisualStyleBackColor = false;
            // 
            // Option1
            // 
            Option1.BackColor = Color.Transparent;
            Option1.Checked = true;
            Option1.Cursor = Cursors.Default;
            Option1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Option1.ForeColor = Color.Black;
            Option1.Location = new Point(203, 32);
            Option1.Margin = new Padding(4, 3, 4, 3);
            Option1.Name = "Option1";
            Option1.RightToLeft = RightToLeft.No;
            Option1.Size = new Size(134, 17);
            Option1.TabIndex = 45;
            Option1.TabStop = true;
            Option1.Text = "Tipo Servicios SRI";
            Option1.UseVisualStyleBackColor = false;
            // 
            // opbienes
            // 
            opbienes.BackColor = Color.Transparent;
            opbienes.Cursor = Cursors.Default;
            opbienes.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            opbienes.ForeColor = Color.Black;
            opbienes.Location = new Point(203, 48);
            opbienes.Margin = new Padding(4, 3, 4, 3);
            opbienes.Name = "opbienes";
            opbienes.RightToLeft = RightToLeft.No;
            opbienes.Size = new Size(126, 17);
            opbienes.TabIndex = 44;
            opbienes.TabStop = true;
            opbienes.Text = "Tipo Bienes SRI";
            opbienes.UseVisualStyleBackColor = false;
            // 
            // chiva
            // 
            chiva.BackColor = Color.Transparent;
            chiva.Checked = true;
            chiva.CheckState = CheckState.Checked;
            chiva.Cursor = Cursors.Default;
            chiva.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            chiva.ForeColor = Color.Black;
            chiva.Location = new Point(203, 16);
            chiva.Margin = new Padding(4, 3, 4, 3);
            chiva.Name = "chiva";
            chiva.RightToLeft = RightToLeft.No;
            chiva.Size = new Size(134, 17);
            chiva.TabIndex = 43;
            chiva.Text = "Gravado con IVA";
            chiva.UseVisualStyleBackColor = false;
            // 
            // Chkingresobanco
            // 
            _Chkingresobanco.BackColor = Color.Transparent;
            _Chkingresobanco.Cursor = Cursors.Default;
            _Chkingresobanco.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Chkingresobanco.ForeColor = Color.Black;
            _Chkingresobanco.Location = new Point(108, 24);
            _Chkingresobanco.Margin = new Padding(4, 3, 4, 3);
            _Chkingresobanco.Name = "_Chkingresobanco";
            _Chkingresobanco.RightToLeft = RightToLeft.No;
            _Chkingresobanco.Size = new Size(89, 17);
            _Chkingresobanco.TabIndex = 41;
            _Chkingresobanco.Text = "Ingreso Banco";
            _Chkingresobanco.UseVisualStyleBackColor = false;
            // 
            // chkfacturacion
            // 
            _chkfacturacion.BackColor = Color.Transparent;
            _chkfacturacion.Cursor = Cursors.Default;
            _chkfacturacion.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _chkfacturacion.ForeColor = Color.Black;
            _chkfacturacion.Location = new Point(20, 48);
            _chkfacturacion.Margin = new Padding(4, 3, 4, 3);
            _chkfacturacion.Name = "_chkfacturacion";
            _chkfacturacion.RightToLeft = RightToLeft.No;
            _chkfacturacion.Size = new Size(89, 17);
            _chkfacturacion.TabIndex = 40;
            _chkfacturacion.Text = "Facturación";
            _chkfacturacion.UseVisualStyleBackColor = false;
            // 
            // Chkcompras
            // 
            _Chkcompras.BackColor = Color.Transparent;
            _Chkcompras.Cursor = Cursors.Default;
            _Chkcompras.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _Chkcompras.ForeColor = Color.Black;
            _Chkcompras.Location = new Point(20, 24);
            _Chkcompras.Margin = new Padding(4, 3, 4, 3);
            _Chkcompras.Name = "_Chkcompras";
            _Chkcompras.RightToLeft = RightToLeft.No;
            _Chkcompras.Size = new Size(113, 17);
            _Chkcompras.TabIndex = 39;
            _Chkcompras.Text = "Compras";
            _Chkcompras.UseVisualStyleBackColor = false;
            // 
            // CtaAlterna
            // 
            CtaAlterna.AcceptsReturn = true;
            CtaAlterna.BackColor = SystemColors.Window;
            CtaAlterna.Cursor = Cursors.IBeam;
            CtaAlterna.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            CtaAlterna.ForeColor = SystemColors.WindowText;
            CtaAlterna.Location = new Point(368, 53);
            CtaAlterna.Margin = new Padding(4, 3, 4, 3);
            CtaAlterna.MaxLength = 45;
            CtaAlterna.Name = "CtaAlterna";
            CtaAlterna.RightToLeft = RightToLeft.No;
            CtaAlterna.Size = new Size(161, 20);
            CtaAlterna.TabIndex = 25;
            // 
            // txtNomCta
            // 
            txtNomCta.AcceptsReturn = true;
            txtNomCta.BackColor = SystemColors.Window;
            txtNomCta.Cursor = Cursors.IBeam;
            txtNomCta.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            txtNomCta.ForeColor = SystemColors.WindowText;
            txtNomCta.Location = new Point(72, 90);
            txtNomCta.Margin = new Padding(4, 3, 4, 3);
            txtNomCta.MaxLength = 45;
            txtNomCta.Name = "txtNomCta";
            txtNomCta.RightToLeft = RightToLeft.No;
            txtNomCta.Size = new Size(441, 20);
            txtNomCta.TabIndex = 19;
            // 
            // Frame3
            // 
            Frame3.BackColor = Color.LightSteelBlue;
            Frame3.Controls.Add(txtC2);
            Frame3.Controls.Add(txtC4);
            Frame3.Controls.Add(txtC1);
            Frame3.Controls.Add(txtC3);
            Frame3.Controls.Add(Label14);
            Frame3.Controls.Add(Label13);
            Frame3.Controls.Add(Label15);
            Frame3.Controls.Add(Label16);
            Frame3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Frame3.ForeColor = Color.White;
            Frame3.Location = new Point(12, 224);
            Frame3.Margin = new Padding(4, 3, 4, 3);
            Frame3.Name = "Frame3";
            Frame3.Padding = new Padding(0);
            Frame3.RightToLeft = RightToLeft.No;
            Frame3.Size = new Size(344, 197);
            Frame3.TabIndex = 12;
            Frame3.TabStop = false;
            Frame3.Text = "Claves Agrupación NIIFS - SRI";
            // 
            // txtC2
            // 
            txtC2.FormattingEnabled = true;
            txtC2.Location = new Point(11, 168);
            txtC2.Margin = new Padding(4, 3, 4, 3);
            txtC2.Name = "txtC2";
            txtC2.Size = new Size(326, 21);
            txtC2.TabIndex = 39;
            // 
            // txtC4
            // 
            txtC4.FormattingEnabled = true;
            txtC4.Items.AddRange(new object[] { "01-Recalcular a valor presente" });
            txtC4.Location = new Point(11, 118);
            txtC4.Margin = new Padding(4, 3, 4, 3);
            txtC4.Name = "txtC4";
            txtC4.Size = new Size(326, 21);
            txtC4.TabIndex = 38;
            // 
            // txtC1
            // 
            txtC1.AutoCompleteCustomSource.AddRange(new string[] { "01-Ingreso por ventas", "02-Costo de productos vendidos", "03-Gastos comerciales y_o producció", "04-Movimientos Financieros", "05-Impuesto a las Ganancias" });
            txtC1.FormattingEnabled = true;
            txtC1.Items.AddRange(new object[] { "INGRESOS POR VENTAS NETAS", "COSTO DE PRODUCTOS VENDIDOS", "GANANCIA BRUTA", "GASTOS DE COMERCIALIZACIÓN Y ADMINISTRACIÓN", "RESULTADO OPERATIVO", "MOVIMIENTOS FINANCIEROS", "IMPUESTO A LAS GANANCIAS" });
            txtC1.Location = new Point(11, 28);
            txtC1.Margin = new Padding(4, 3, 4, 3);
            txtC1.Name = "txtC1";
            txtC1.Size = new Size(326, 21);
            txtC1.TabIndex = 37;
            // 
            // txtC3
            // 
            txtC3.FormattingEnabled = true;
            txtC3.Items.AddRange(new object[] { "01-Actv.Operación (Rec.Cliente)", "02-Actv.Operación (Pag.Proveedor)", "03-Actv.Operación (Otros)", "04-Actv.Inversión", "05-Actv.Financiamiento" });
            txtC3.Location = new Point(11, 72);
            txtC3.Margin = new Padding(4, 3, 4, 3);
            txtC3.Name = "txtC3";
            txtC3.Size = new Size(326, 21);
            txtC3.TabIndex = 36;
            // 
            // Label14
            // 
            Label14.AutoSize = true;
            Label14.BackColor = Color.Transparent;
            Label14.Cursor = Cursors.Default;
            Label14.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label14.ForeColor = Color.Black;
            Label14.Location = new Point(8, 105);
            Label14.Margin = new Padding(4, 0, 4, 0);
            Label14.Name = "Label14";
            Label14.RightToLeft = RightToLeft.No;
            Label14.Size = new Size(226, 13);
            Label14.TabIndex = 33;
            Label14.Text = "Variacion para presentacion de  balances Niifs";
            // 
            // Label13
            // 
            Label13.AutoSize = true;
            Label13.BackColor = Color.Transparent;
            Label13.Cursor = Cursors.Default;
            Label13.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label13.ForeColor = Color.Black;
            Label13.Location = new Point(8, 15);
            Label13.Margin = new Padding(4, 0, 4, 0);
            Label13.Name = "Label13";
            Label13.RightToLeft = RightToLeft.No;
            Label13.Size = new Size(168, 13);
            Label13.TabIndex = 18;
            Label13.Text = "Grupo para Balance de resultados";
            // 
            // Label15
            // 
            Label15.AutoSize = true;
            Label15.BackColor = Color.Transparent;
            Label15.Cursor = Cursors.Default;
            Label15.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label15.ForeColor = Color.Black;
            Label15.Location = new Point(8, 59);
            Label15.Margin = new Padding(4, 0, 4, 0);
            Label15.Name = "Label15";
            Label15.RightToLeft = RightToLeft.No;
            Label15.Size = new Size(135, 13);
            Label15.TabIndex = 17;
            Label15.Text = "Grupo para el Flujo de Caja";
            // 
            // Label16
            // 
            Label16.AutoSize = true;
            Label16.BackColor = Color.Transparent;
            Label16.Cursor = Cursors.Default;
            Label16.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label16.ForeColor = Color.Black;
            Label16.Location = new Point(8, 155);
            Label16.Margin = new Padding(4, 0, 4, 0);
            Label16.Name = "Label16";
            Label16.RightToLeft = RightToLeft.No;
            Label16.Size = new Size(166, 13);
            Label16.TabIndex = 16;
            Label16.Text = "Identificativo formulario SRI F-101";
            // 
            // Frame6
            // 
            Frame6.BackColor = Color.LightSteelBlue;
            Frame6.Controls.Add(opMenVar);
            Frame6.Controls.Add(opMenFij);
            Frame6.Controls.Add(opSinPre);
            Frame6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Frame6.ForeColor = Color.White;
            Frame6.Location = new Point(364, 143);
            Frame6.Margin = new Padding(4, 3, 4, 3);
            Frame6.Name = "Frame6";
            Frame6.Padding = new Padding(0);
            Frame6.RightToLeft = RightToLeft.No;
            Frame6.Size = new Size(411, 49);
            Frame6.TabIndex = 8;
            Frame6.TabStop = false;
            Frame6.Text = "Tipo de presupuesto";
            Frame6.Visible = false;
            // 
            // opMenVar
            // 
            opMenVar.BackColor = Color.Transparent;
            opMenVar.Cursor = Cursors.Default;
            opMenVar.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            opMenVar.ForeColor = Color.Black;
            opMenVar.Location = new Point(301, 21);
            opMenVar.Margin = new Padding(4, 3, 4, 3);
            opMenVar.Name = "opMenVar";
            opMenVar.RightToLeft = RightToLeft.No;
            opMenVar.Size = new Size(88, 17);
            opMenVar.TabIndex = 11;
            opMenVar.TabStop = true;
            opMenVar.Text = "Mensual Variable";
            opMenVar.UseVisualStyleBackColor = false;
            // 
            // opMenFij
            // 
            opMenFij.BackColor = Color.Transparent;
            opMenFij.Cursor = Cursors.Default;
            opMenFij.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            opMenFij.ForeColor = Color.Black;
            opMenFij.Location = new Point(198, 21);
            opMenFij.Margin = new Padding(4, 3, 4, 3);
            opMenFij.Name = "opMenFij";
            opMenFij.RightToLeft = RightToLeft.No;
            opMenFij.Size = new Size(97, 17);
            opMenFij.TabIndex = 9;
            opMenFij.TabStop = true;
            opMenFij.Text = "Mensual Fijo";
            opMenFij.UseVisualStyleBackColor = false;
            // 
            // opSinPre
            // 
            opSinPre.BackColor = Color.Transparent;
            opSinPre.Checked = true;
            opSinPre.Cursor = Cursors.Default;
            opSinPre.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            opSinPre.ForeColor = Color.Black;
            opSinPre.Location = new Point(62, 21);
            opSinPre.Margin = new Padding(4, 3, 4, 3);
            opSinPre.Name = "opSinPre";
            opSinPre.RightToLeft = RightToLeft.No;
            opSinPre.Size = new Size(130, 17);
            opSinPre.TabIndex = 10;
            opSinPre.TabStop = true;
            opSinPre.Text = "Sin Presupuesto";
            opSinPre.UseVisualStyleBackColor = false;
            // 
            // dcGruCon
            // 
            _dcGruCon.BackColor = SystemColors.Window;
            _dcGruCon.Cursor = Cursors.Default;
            _dcGruCon.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            _dcGruCon.ForeColor = SystemColors.WindowText;
            _dcGruCon.Items.AddRange(new object[] { "Activos", "Pasivos", "Patrimonio", "Resultados", "Ctas. de Orden" });
            _dcGruCon.Location = new Point(102, 117);
            _dcGruCon.Margin = new Padding(4, 3, 4, 3);
            _dcGruCon.Name = "_dcGruCon";
            _dcGruCon.RightToLeft = RightToLeft.No;
            _dcGruCon.Size = new Size(192, 21);
            _dcGruCon.TabIndex = 1;
            // 
            // ImageList1
            // 
            ImageList1.ImageStream = (ImageListStreamer)resources.GetObject("ImageList1.ImageStream");
            ImageList1.TransparentColor = Color.FromArgb(Convert.ToInt32(Conversions.ToByte(192)), Convert.ToInt32(Conversions.ToByte(192)), Convert.ToInt32(Conversions.ToByte(192)));
            ImageList1.Images.SetKeyName(0, "imggrabar");
            ImageList1.Images.SetKeyName(1, "imgsalir");
            // 
            // Toolbar1
            // 
            Toolbar1.BackColor = Color.SteelBlue;
            Toolbar1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Toolbar1.GripStyle = ToolStripGripStyle.Hidden;
            Toolbar1.ImageList = ImageList1;
            Toolbar1.Items.AddRange(new ToolStripItem[] { _guardar, _salir });
            Toolbar1.Location = new Point(0, 0);
            Toolbar1.Name = "Toolbar1";
            Toolbar1.Size = new Size(781, 42);
            Toolbar1.TabIndex = 0;
            // 
            // guardar
            // 
            _guardar.AutoSize = false;
            _guardar.ImageKey = "imggrabar";
            _guardar.ImageScaling = ToolStripItemImageScaling.None;
            _guardar.Name = "_guardar";
            _guardar.Size = new Size(50, 39);
            _guardar.Text = "Guardar";
            _guardar.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // salir
            // 
            _salir.AutoSize = false;
            _salir.Image = (Image)resources.GetObject("salir.Image");
            _salir.ImageScaling = ToolStripItemImageScaling.None;
            _salir.Name = "_salir";
            _salir.Size = new Size(50, 39);
            _salir.Text = "Salir";
            _salir.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // Label4
            // 
            Label4.BackColor = Color.Transparent;
            Label4.Cursor = Cursors.Default;
            Label4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label4.ForeColor = SystemColors.ControlText;
            Label4.Location = new Point(12, 424);
            Label4.Margin = new Padding(4, 0, 4, 0);
            Label4.Name = "Label4";
            Label4.RightToLeft = RightToLeft.No;
            Label4.Size = new Size(240, 13);
            Label4.TabIndex = 31;
            Label4.Text = "Plantilla para detalle en contabilización automática:";
            Label4.Visible = false;
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.BackColor = Color.Transparent;
            Label3.Cursor = Cursors.Default;
            Label3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label3.ForeColor = Color.Black;
            Label3.Location = new Point(380, 122);
            Label3.Margin = new Padding(4, 0, 4, 0);
            Label3.Name = "Label3";
            Label3.RightToLeft = RightToLeft.No;
            Label3.Size = new Size(103, 13);
            Label3.TabIndex = 29;
            Label3.Text = "Modulo relaciónado:";
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.BackColor = Color.Transparent;
            Label2.Cursor = Cursors.Default;
            Label2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label2.ForeColor = Color.Black;
            Label2.Location = new Point(304, 60);
            Label2.Margin = new Padding(4, 0, 4, 0);
            Label2.Name = "Label2";
            Label2.RightToLeft = RightToLeft.No;
            Label2.Size = new Size(62, 13);
            Label2.TabIndex = 26;
            Label2.Text = "Cod.Alterno";
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.BackColor = Color.Transparent;
            Label1.Cursor = Cursors.Default;
            Label1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label1.ForeColor = Color.Black;
            Label1.Location = new Point(12, 60);
            Label1.Margin = new Padding(4, 0, 4, 0);
            Label1.Name = "Label1";
            Label1.RightToLeft = RightToLeft.No;
            Label1.Size = new Size(65, 13);
            Label1.TabIndex = 22;
            Label1.Text = "Código  Cta.";
            // 
            // Label5
            // 
            Label5.AutoSize = true;
            Label5.BackColor = Color.Transparent;
            Label5.Cursor = Cursors.Default;
            Label5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label5.ForeColor = Color.Black;
            Label5.Location = new Point(12, 94);
            Label5.Margin = new Padding(4, 0, 4, 0);
            Label5.Name = "Label5";
            Label5.RightToLeft = RightToLeft.No;
            Label5.Size = new Size(47, 13);
            Label5.TabIndex = 21;
            Label5.Text = "Nombre:";
            // 
            // Label6
            // 
            Label6.AutoSize = true;
            Label6.BackColor = Color.Transparent;
            Label6.Cursor = Cursors.Default;
            Label6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            Label6.ForeColor = Color.Black;
            Label6.Location = new Point(12, 122);
            Label6.Margin = new Padding(4, 0, 4, 0);
            Label6.Name = "Label6";
            Label6.RightToLeft = RightToLeft.No;
            Label6.Size = new Size(84, 13);
            Label6.TabIndex = 20;
            Label6.Text = "Grupo Contable:";
            // 
            // GroupBox1
            // 
            GroupBox1.Controls.Add(Clasificadores);
            GroupBox1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            GroupBox1.ForeColor = Color.White;
            GroupBox1.Location = new Point(364, 265);
            GroupBox1.Margin = new Padding(4, 3, 4, 3);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Padding = new Padding(4, 3, 4, 3);
            GroupBox1.Size = new Size(410, 156);
            GroupBox1.TabIndex = 39;
            GroupBox1.TabStop = false;
            GroupBox1.Text = "Clasificadores contables";
            // 
            // Clasificadores
            // 
            Clasificadores.BackColor = Color.LightSteelBlue;
            Clasificadores.BorderStyle = BorderStyle.None;
            Clasificadores.ColumnWidth = 353;
            Clasificadores.Cursor = Cursors.Default;
            Clasificadores.Dock = DockStyle.Fill;
            Clasificadores.ForeColor = Color.FromArgb(Convert.ToInt32(Conversions.ToByte(64)), Convert.ToInt32(Conversions.ToByte(64)), Convert.ToInt32(Conversions.ToByte(64)));
            Clasificadores.IntegralHeight = false;
            Clasificadores.Location = new Point(4, 16);
            Clasificadores.Margin = new Padding(4, 3, 4, 3);
            Clasificadores.MultiColumn = true;
            Clasificadores.Name = "Clasificadores";
            Clasificadores.RightToLeft = RightToLeft.No;
            Clasificadores.Size = new Size(402, 137);
            Clasificadores.TabIndex = 37;
            // 
            // GroupBox2
            // 
            GroupBox2.BackColor = Color.LightSteelBlue;
            GroupBox2.Controls.Add(btnNoProduccion);
            GroupBox2.Controls.Add(btnCI);
            GroupBox2.Controls.Add(btnCD);
            GroupBox2.Controls.Add(btnMO);
            GroupBox2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            GroupBox2.ForeColor = Color.White;
            GroupBox2.Location = new Point(364, 198);
            GroupBox2.Margin = new Padding(4, 3, 4, 3);
            GroupBox2.Name = "GroupBox2";
            GroupBox2.Padding = new Padding(0);
            GroupBox2.RightToLeft = RightToLeft.No;
            GroupBox2.Size = new Size(411, 61);
            GroupBox2.TabIndex = 42;
            GroupBox2.TabStop = false;
            GroupBox2.Text = "En producción el valor es de:";
            // 
            // btnNoProduccion
            // 
            btnNoProduccion.AutoSize = true;
            btnNoProduccion.BackColor = Color.Transparent;
            btnNoProduccion.Checked = true;
            btnNoProduccion.Cursor = Cursors.Default;
            btnNoProduccion.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            btnNoProduccion.ForeColor = Color.Black;
            btnNoProduccion.Location = new Point(12, 25);
            btnNoProduccion.Margin = new Padding(4, 3, 4, 3);
            btnNoProduccion.Name = "btnNoProduccion";
            btnNoProduccion.RightToLeft = RightToLeft.No;
            btnNoProduccion.Size = new Size(65, 17);
            btnNoProduccion.TabIndex = 43;
            btnNoProduccion.TabStop = true;
            btnNoProduccion.Text = "Ninguno";
            btnNoProduccion.UseVisualStyleBackColor = false;
            // 
            // btnCI
            // 
            btnCI.AutoSize = true;
            btnCI.BackColor = Color.Transparent;
            btnCI.Cursor = Cursors.Default;
            btnCI.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            btnCI.ForeColor = Color.Black;
            btnCI.Location = new Point(289, 26);
            btnCI.Margin = new Padding(4, 3, 4, 3);
            btnCI.Name = "btnCI";
            btnCI.RightToLeft = RightToLeft.No;
            btnCI.Size = new Size(105, 17);
            btnCI.TabIndex = 11;
            btnCI.Text = "Costos indirectos";
            btnCI.UseVisualStyleBackColor = false;
            // 
            // btnCD
            // 
            btnCD.AutoSize = true;
            btnCD.BackColor = Color.Transparent;
            btnCD.Cursor = Cursors.Default;
            btnCD.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            btnCD.ForeColor = Color.Black;
            btnCD.Location = new Point(188, 25);
            btnCD.Margin = new Padding(4, 3, 4, 3);
            btnCD.Name = "btnCD";
            btnCD.RightToLeft = RightToLeft.No;
            btnCD.Size = new Size(97, 17);
            btnCD.TabIndex = 9;
            btnCD.Text = "Costos directos";
            btnCD.UseVisualStyleBackColor = false;
            // 
            // btnMO
            // 
            btnMO.AutoSize = true;
            btnMO.BackColor = Color.Transparent;
            btnMO.Cursor = Cursors.Default;
            btnMO.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            btnMO.ForeColor = Color.Black;
            btnMO.Location = new Point(86, 25);
            btnMO.Margin = new Padding(4, 3, 4, 3);
            btnMO.Name = "btnMO";
            btnMO.RightToLeft = RightToLeft.No;
            btnMO.Size = new Size(93, 17);
            btnMO.TabIndex = 10;
            btnMO.Text = "Mano de Obra";
            btnMO.UseVisualStyleBackColor = false;
            // 
            // CTBP01_1
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(781, 469);
            Controls.Add(GroupBox2);
            Controls.Add(_Button1);
            Controls.Add(GroupBox1);
            Controls.Add(_chkDeAgrupacion);
            Controls.Add(Formatodetalle);
            Controls.Add(_DcModulo);
            Controls.Add(Frconceptos);
            Controls.Add(CtaAlterna);
            Controls.Add(txtNomCta);
            Controls.Add(Frame3);
            Controls.Add(Frame6);
            Controls.Add(_dcGruCon);
            Controls.Add(Toolbar1);
            Controls.Add(Label4);
            Controls.Add(Label3);
            Controls.Add(Label2);
            Controls.Add(Label1);
            Controls.Add(Label5);
            Controls.Add(Label6);
            Cursor = Cursors.Default;
            Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Location = new Point(3, 22);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CTBP01_1";
            RightToLeft = RightToLeft.No;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Ingreso de Nueva Cuenta";
            Frconceptos.ResumeLayout(false);
            Frame3.ResumeLayout(false);
            Frame3.PerformLayout();
            Frame6.ResumeLayout(false);
            Toolbar1.ResumeLayout(false);
            Toolbar1.PerformLayout();
            GroupBox1.ResumeLayout(false);
            GroupBox2.ResumeLayout(false);
            GroupBox2.PerformLayout();
            FormClosing += new FormClosingEventHandler(CTBP01_1_FormClosing);
            Load += new EventHandler(CTBP01_1_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        internal GroupBox GroupBox1;
        public CheckedListBox Clasificadores;
        internal ComboBox txtC3;
        internal ComboBox txtC1;
        internal ComboBox txtC2;
        internal ComboBox txtC4;
        private Button _Button1;

        internal Button Button1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button1 != null)
                {
                    _Button1.Click -= Button1_Click;
                }

                _Button1 = value;
                if (_Button1 != null)
                {
                    _Button1.Click += Button1_Click;
                }
            }
        }

        public GroupBox GroupBox2;
        public RadioButton btnCI;
        public RadioButton btnCD;
        public RadioButton btnMO;
        public RadioButton btnNoProduccion;
        #endregion
    }
}