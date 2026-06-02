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
	public partial class BuscaClien : Form
	{
		string seleccion2 = "";
		string seleccion = "";
		string seleccion3 = "";
		string codNom = "";
		string clioPro = "";
		string codigoRet = "";
		short sw = 1;
		string aliasRenamed = "";
		bool sinNuevo = false;
		int fila;
		bool esMedical;
		string conHistoria;
		string conTelefono;
		bool inicia = false;
		double sueldoAnterior = 0;
		DateTime ingresoAnterior;
		DateTime salidaAnterior;
		public BuscaClien()
		{
			InitializeComponent();
		}

		private void btncancelarbusca_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btNuevo_Click(object sender, EventArgs e)
		{

		}

		public string IniBuscaCliOPro(ref string CliOProv, ref string CodigoNombre,  string ConAlias = "",  string ConNuevo = "", bool medical = false, string histClin = "", string telf = "")
		{
			bool Inicia = true;
			string ClioPro = CliOProv;
			string CodNom = CodigoNombre;
			bool SinNuevo = (ConNuevo != "S");
			Label1.Visible = medical;
			TextBox1.Visible = medical;
			bool esmedical = medical;
			this.ShowDialog();
			string CodigoRet = ""; // Assuming CodigoRet is defined somewhere in the class
			CodigoNombre = CodNom;
			//ConAlias = Alias_Renamed; // Assuming Alias_Renamed is defined somewhere in the class
			this.Close();
			this.Dispose();
			return CodigoRet;
		}


	}
}
