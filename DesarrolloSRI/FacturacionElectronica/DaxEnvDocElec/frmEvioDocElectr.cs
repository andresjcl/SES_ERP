using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DaxEnvDocElec
{
    public partial class frmEvioDocElectr : Form
    {
        string codigoEmpresa = "";
        public frmEvioDocElectr(string codEmpresa)
        {
            InitializeComponent();
            codigoEmpresa = codEmpresa;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma detener el envío de documetos electronicos a clientes   ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.ExitThread();
                this.Dispose();
            }
        }

        private void frmEvioDocElectr_Shown(object sender, EventArgs e)
        {
            
        }
        

    }
}
