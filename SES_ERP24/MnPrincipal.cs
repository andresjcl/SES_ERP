using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DattCom;
using ListadoDocumentos;

namespace SES_ERP24
{
	public partial class MnPrincipal : Form
	{
		public MnPrincipal()
		{
			InitializeComponent();
		}

		private void menMedico_Click(object sender, EventArgs e)
		{

		}

		private void panelSuperior_Paint(object sender, PaintEventArgs e)
		{

		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{

		}

		private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}

		private void MnPrincipal_Load(object sender, EventArgs e)
		{

		}

		private void MenReporteD_Click(object sender, EventArgs e)
		{

		}

		private void btnFAP_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("FACEmitirFap")) return;
			DctosEmi.FormFactProveedor prog = new DctosEmi.FormFactProveedor("FAP", "", true, false, false, false, null);
			//MessageBox.Show(datosEmpresa.strConxIvaret.ToString());
			prog.Show();
		}

		private void btnEmitirFacturasDirectas_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("FACEmitirFac")) return;
			DctosEmi.FormFactCliente prog = new DctosEmi.FormFactCliente("FAC", "", true, false, false, false, null);
			prog.Show();
		}

		private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
		{

		}

		private void btnDevProv_Click(object sender, EventArgs e)
		{
			DctosEmi.FormDevProveedor prog = new DctosEmi.FormDevProveedor("DEV", "", true, false, false, false, null);
		}

		private void btnEmitirDevCliente_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("FACEmitirFac")) return;
			DctosEmi.FormDevolucion prog = new DctosEmi.FormDevolucion("DEV", "", true, false, false, false, null);
			prog.Show();
		}

		private void menCompras_Click(object sender, EventArgs e)
		{

		}

		private void MneCliente_Click(object sender, EventArgs e)
		{

		}

		private void MnuProveedor_Click(object sender, EventArgs e)
		{
			//if (!AutorizarLlamadas.VerificaAutorización("DGRegistros")) return;
			//mntDirectorio prog = new mntDirectorio();
			////directMnt.BusDirectorio prog = new directMnt.BusDirectorio();
			////string codigo = "";
			////prog.ManDir(ref codigo);
			//prog.ShowDialog();
			//prog = null;
		}

		private void btnConsulaMedicaPorPaciente_Click(object sender, EventArgs e)
		{
			if (!AutorizarLlamadas.VerificaAutorización("FACEmitirFac")) return;
			GessDax.GessDax prog = new GessDax.GessDax("01");
			prog.Show();
		}

		private void btnReportesDocumentos_Click(object sender, EventArgs e)
		{
			//if (!AutorizarLlamadas.VerificaAutorización("FACEmitirFac")) return;
			//ListadoDocumentos prog = new ListadoDocumentos();
			ListadoDocumentos.frmRepDoc prog = new frmRepDoc();			
			prog.Show();
		}
	}
}
