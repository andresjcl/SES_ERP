using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mntDirectorio
{
	public partial class CreaCliAlex : Form
	{
		public CreaCliAlex()
		{
			InitializeComponent();
		}

		private void btncontinuar_Click(object sender, EventArgs e)
		{
			Grabar();
		}

		private void Grabar()
		{
			if (string.IsNullOrEmpty(TipoIdent.Text))
			{

			}
		}

		private void btncancelar_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
