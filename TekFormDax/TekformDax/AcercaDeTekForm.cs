using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TekFormDax
{
    public partial class AcercaDeTekForm : Form
    {
        public AcercaDeTekForm()
        {
            InitializeComponent();
        }

        private void AcercaDeTekForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            Close();
        }

        private void Frame1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Frame1_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }
    }
}
