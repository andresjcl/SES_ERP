using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DaxFechas
{
    public partial class FormFecha : Form
    {
        public string laFecha;
        public FormFecha()
        {
            InitializeComponent();
            
        }


        private void FormFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape)) this.Close();
        }

        private void calendario_DateSelected(object sender, DateRangeEventArgs e)
        {
            laFecha = calendario.SelectionStart.ToShortDateString();
            Clipboard.SetText(laFecha);
            this.Close();
        }

        private void FormFecha_Load(object sender, EventArgs e)
        {

        }
    }
}
