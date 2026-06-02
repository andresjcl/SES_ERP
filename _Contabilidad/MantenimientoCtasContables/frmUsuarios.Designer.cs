using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace MantCtb
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    internal partial class frmUsuarios
    {
        #region Código generado por el Diseñador de Windows Forms 
        [DebuggerNonUserCode()]
        public frmUsuarios() : base()
        {
            // Llamada necesaria para el Diseñador de Windows Forms.
            InitializeComponent();
            _cmdAceptar.Name = "cmdAceptar";
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
        private Button _cmdAceptar;

        public Button cmdAceptar
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _cmdAceptar;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_cmdAceptar != null)
                {
                    _cmdAceptar.Click -= cmdAceptar_Click;
                }

                _cmdAceptar = value;
                if (_cmdAceptar != null)
                {
                    _cmdAceptar.Click += cmdAceptar_Click;
                }
            }
        }

        public CheckedListBox List1;
        // NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
        // Se puede modificar mediante el Diseñador de Windows Forms.
        // No lo modifique con el editor de código.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ToolTip1 = new ToolTip(components);
            _cmdAceptar = new Button();
            _cmdAceptar.Click += new EventHandler(cmdAceptar_Click);
            List1 = new CheckedListBox();
            SuspendLayout();
            // 
            // cmdAceptar
            // 
            _cmdAceptar.BackColor = Color.SteelBlue;
            _cmdAceptar.Cursor = Cursors.Default;
            _cmdAceptar.ForeColor = Color.White;
            _cmdAceptar.Location = new Point(184, 183);
            _cmdAceptar.Name = "_cmdAceptar";
            _cmdAceptar.RightToLeft = RightToLeft.No;
            _cmdAceptar.Size = new Size(81, 25);
            _cmdAceptar.TabIndex = 1;
            _cmdAceptar.Text = "Cerrar";
            _cmdAceptar.UseVisualStyleBackColor = false;
            // 
            // List1
            // 
            List1.BackColor = SystemColors.Window;
            List1.Cursor = Cursors.Default;
            List1.ForeColor = SystemColors.WindowText;
            List1.Location = new Point(8, 8);
            List1.Name = "List1";
            List1.RightToLeft = RightToLeft.No;
            List1.Size = new Size(257, 169);
            List1.TabIndex = 0;
            // 
            // frmUsuarios
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(277, 216);
            Controls.Add(_cmdAceptar);
            Controls.Add(List1);
            Cursor = Cursors.Default;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Location = new Point(3, 29);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmUsuarios";
            RightToLeft = RightToLeft.No;
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Excepciones";
            ResumeLayout(false);
        }
        #endregion
    }
}