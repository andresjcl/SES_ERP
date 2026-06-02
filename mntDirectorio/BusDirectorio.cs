using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mntDirectorio
{
	public class BusDirectorio
	{
        public string BusDirect(ref string codigo, ref string CEDULA, ref string Nombre, ref string NombreAlias, string Tipo = "", string ConNuevo = "")
        {
            string ElCodigo = "";
            try
            {
                //BuscaClien PROG = new BuscaClien();
                //ElCodigo = PROG.IniBuscaCliOPro(Tipo, Nombre, NombreAlias, ConNuevo);
                //PROG.Dispose();
            }
            catch (Exception ee)
            {
                MessageBox.Show("excepción busDirect: " + ee.Message);
            }
            return ElCodigo;
        }

        public string BusDirect(string codigo, string cedula, ref string nombre, string nombreAlias, string tipo = "", string conNuevo = "", string neutro = "")
        {
            string elCodigo = "";
            try
            {
                //BuscaClien prog = new BuscaClien();
                //elCodigo = prog.IniBuscaCliOPro(tipo, nombre, nombreAlias, conNuevo);
                //prog.Dispose();
            }
            catch (Exception ee)
            {
                MessageBox.Show("excepción busDirect: " + ee.Message);
            }
            return elCodigo;
        }

        public string BusDirect(string codigo, string cedula, string nombre, string nomAlias)
        {
            string ElCodigo = "";
            
            try
            {
                //BuscaClien PROG = new BuscaClien();
                //ElCodigo = PROG.IniBuscaCliOPro("", nombre, nomAlias, "");
                //PROG.Dispose();
            }
            catch (Exception ee)
            {
                MessageBox.Show("excepción busDirect: " + ee.Message);
            }
            return ElCodigo;
        }



        public void ManDir(ref string ConCodigo)
        {           
            MNT01 PROG = new MNT01();
            // PROG.Autorizacion = datosEmpresa.auto;
            if (ConCodigo == "&&")
            {
                PROG.QUECODIGO = "";
                PROG.IniciaNuevo();
            }
            else
            {
                PROG.QUECODIGO = ConCodigo;
                PROG.Show();
            }
        }
    }
}
