using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace MantCtb
{
    [DesignerGenerated()]
    public partial class CtbValida : Form
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
            var DataGridViewCellStyle1 = new DataGridViewCellStyle();
            var DataGridViewCellStyle2 = new DataGridViewCellStyle();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(CtbValida));
            Malla = new DataGridView();
            ToolStrip1 = new ToolStrip();
            _BtnImprimir = new ToolStripButton();
            _BtnImprimir.Click += new EventHandler(imprimir_Click);
            _btnSalir = new ToolStripButton();
            _btnSalir.Click += new EventHandler(btnSalir_Click);
            ((System.ComponentModel.ISupportInitialize)Malla).BeginInit();
            ToolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // Malla
            // 
            Malla.BackgroundColor = Color.White;
            DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DataGridViewCellStyle1.BackColor = Color.LightSteelBlue;
            DataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            DataGridViewCellStyle1.ForeColor = Color.White;
            DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            Malla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1;
            Malla.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DataGridViewCellStyle2.BackColor = Color.White;
            DataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, Conversions.ToByte(0));
            DataGridViewCellStyle2.ForeColor = Color.Gray;
            DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            Malla.DefaultCellStyle = DataGridViewCellStyle2;
            Malla.Dock = DockStyle.Fill;
            Malla.GridColor = Color.FromArgb(Convert.ToInt32(Conversions.ToByte(224)), Convert.ToInt32(Conversions.ToByte(224)), Convert.ToInt32(Conversions.ToByte(224)));
            Malla.Location = new Point(0, 0);
            Malla.Name = "Malla";
            Malla.ReadOnly = true;
            Malla.Size = new Size(558, 352);
            Malla.TabIndex = 0;
            // 
            // ToolStrip1
            // 
            ToolStrip1.BackColor = Color.SteelBlue;
            ToolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            ToolStrip1.Items.AddRange(new ToolStripItem[] { _BtnImprimir, _btnSalir });
            ToolStrip1.Location = new Point(0, 0);
            ToolStrip1.Name = "ToolStrip1";
            ToolStrip1.Size = new Size(558, 39);
            ToolStrip1.TabIndex = 1;
            ToolStrip1.Text = "ToolStrip1";
            // 
            // BtnImprimir
            // 
            _BtnImprimir.ForeColor = Color.White;
            _BtnImprimir.Image = (Image)resources.GetObject("BtnImprimir.Image");
            _BtnImprimir.ImageScaling = ToolStripItemImageScaling.None;
            _BtnImprimir.ImageTransparentColor = Color.Magenta;
            _BtnImprimir.Name = "_BtnImprimir";
            _BtnImprimir.Size = new Size(89, 36);
            _BtnImprimir.Text = "Imprimir";
            // 
            // btnSalir
            // 
            _btnSalir.ForeColor = Color.White;
            _btnSalir.Image = (Image)resources.GetObject("btnSalir.Image");
            _btnSalir.ImageTransparentColor = Color.Magenta;
            _btnSalir.Name = "_btnSalir";
            _btnSalir.Size = new Size(49, 36);
            _btnSalir.Text = "Salir";
            // 
            // CtbValida
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(558, 352);
            Controls.Add(ToolStrip1);
            Controls.Add(Malla);
            Name = "CtbValida";
            ShowIcon = false;
            Text = "Validacion del plan de cuentas contables";
            ((System.ComponentModel.ISupportInitialize)Malla).EndInit();
            ToolStrip1.ResumeLayout(false);
            ToolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        internal DataGridView Malla;
        internal ToolStrip ToolStrip1;
        private ToolStripButton _BtnImprimir;

        internal ToolStripButton BtnImprimir
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _BtnImprimir;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_BtnImprimir != null)
                {
                    _BtnImprimir.Click -= imprimir_Click;
                }

                _BtnImprimir = value;
                if (_BtnImprimir != null)
                {
                    _BtnImprimir.Click += imprimir_Click;
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
    }
}