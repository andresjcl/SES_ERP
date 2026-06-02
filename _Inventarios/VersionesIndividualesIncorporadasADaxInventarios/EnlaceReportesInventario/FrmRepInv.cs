using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace daxenlCorr
{
    public partial class FrmRepInv : Form
    {
        public FrmRepInv()
        {
            InitializeComponent();
            if (varbleComun.VarCom.sistema != "ERP" && varbleComun.VarCom.sistema != "DAX")
            {
                btnAntigdad.Visible = false;
                btnCatalogo.Visible  = false;
                btnKardex.Visible  = false;
                btnMaxMin.Visible  = false;
                btnResumen.Visible  = false;
            }
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RepInvMaxMin.repInvMaxMin prog = new RepInvMaxMin.repInvMaxMin();
            prog.MdiParent = this;
            prog.Show();
            prog.WindowState = FormWindowState.Normal;
            //prog.Dock = DockStyle.Fill;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RepTraInv.repInvTransInv prog = new RepTraInv.repInvTransInv();
            prog.MdiParent = this;
            prog.Show();
            //prog.Dock = DockStyle.Fill;
            prog.WindowState = FormWindowState.Normal;
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Actualizar_Click_1(object sender, EventArgs e)
        {
            RepTraInv.repInvTransInv prog = new RepTraInv.repInvTransInv();
            prog.MdiParent = this;
            prog.Show();
            //prog.Dock = DockStyle.Fill;
            prog.WindowState = FormWindowState.Normal;

        }

        private void btnCatalogo_Click(object sender, EventArgs e)
        {
            RepInvCatlgo.repCatalogo prog = new RepInvCatlgo.repCatalogo();
            prog.MdiParent = this;
            prog.Show();
            //prog.Dock = DockStyle.Fill;
            prog.WindowState = FormWindowState.Normal;

        }

        private void btnKardex_Click(object sender, EventArgs e)
        {
            RepInvtKardx.repInvKardex prog = new RepInvtKardx.repInvKardex();
            prog.MdiParent = this;
            prog.Show();
            //prog.Dock = DockStyle.Fill;
            prog.WindowState = FormWindowState.Normal;

        }

        private void btnResumen_Click(object sender, EventArgs e)
        {
            RepResMov.repResumenMov  prog = new RepResMov.repResumenMov();
            prog.MdiParent = this;
            prog.Show();
            //prog.Dock = DockStyle.Fill;
            prog.WindowState = FormWindowState.Normal;

        }

        private void btnAntigdad_Click(object sender, EventArgs e)
        {
            RepInvAntg.repAntig prog = new RepInvAntg.repAntig();
            prog.MdiParent = this;
            prog.Show();
            //prog.Dock = DockStyle.Fill;
            prog.WindowState = FormWindowState.Normal;

        }
    }
}
