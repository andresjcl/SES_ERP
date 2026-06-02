using System;
using System.Windows.Forms;
namespace DaxInvent
{
    public partial class FrmRepInv : Form
    {
        public FrmRepInv()
        {
            InitializeComponent();
        }

        private void MaximosMinimos_Click(object sender, EventArgs e)
        {
            repInvMaxMin prog = new repInvMaxMin();
            prog.Show();
        }

        private void ListaTransacciones_Click(object sender, EventArgs e)
        {
            repInvTransInv prog = new repInvTransInv();
            prog.Show();
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Actualizar_Click_1(object sender, EventArgs e)
        {
            repInvTransInv prog = new repInvTransInv();
            prog.Show();
        }

        private void btnCatalogo_Click(object sender, EventArgs e)
        {
           DaxInvent.repCatalogo prog = new DaxInvent.repCatalogo();
            prog.Show();
        }

        private void btnKardex_Click(object sender, EventArgs e)
        {
            repInvKardex prog = new repInvKardex();
            prog.Show();
        }

        private void btnResumen_Click(object sender, EventArgs e)
        {
            repResumenMov  prog = new repResumenMov();
            prog.Show();
        }

        private void btnAntigdad_Click(object sender, EventArgs e)
        {
            repAntig prog = new repAntig();
            prog.Show();
        }
    }
}
