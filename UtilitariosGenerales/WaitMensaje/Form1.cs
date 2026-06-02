using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WaitMensaje
{
    public partial class frmWMensaje : Form
    {
        internal frmWMensaje()
        {
            InitializeComponent();
        }
        internal void VerMensaje(string mensaje)
        {
            label1.Text = mensaje;
            this.Show();
            Application.DoEvents();
        }
    }
}
