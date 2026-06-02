using DattCom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mntUsrs
{
    public partial class FrmMedico : Form
    {
        string strConxDaxsys = "";
        string usuario = "";
        string sistema = "";
        int empresa = 0;
        string nomEmpresa = "";
//        DataTable dtAccesos;
        Boolean cambiado = false;

        public FrmMedico(string strsys, string usr, int emp, string nomEmp, string sis)
        {
            InitializeComponent();
            strConxDaxsys = strsys;
            usuario = usr;
            empresa = emp;
            nomEmpresa = nomEmp;
            sistema = sis;
            this.Text = "Registrar accesos a Sistema Medico, de " + nomEmp + " usuario : " + usr;
            cargaMenusMallas.cargaMenuMedico(mallaDaxMed);
            cargarDatosMallas. cargarRegistrosActuales(strConxDaxsys,mallaDaxMed,empresa, sistema, usuario);
            diseñoMallas.DiseñarMallaDaxmed(mallaDaxMed);
        }


        private void btnTodo_Click(object sender, EventArgs e)
        {
            marcarMalla marc = new marcarMalla();
            marc.marcaTodo(mallaDaxMed);
            marc = null;
            cambiado = true;
        }

        private void btnCambiaCeldas_Click(object sender, EventArgs e)
        {
            marcarMalla marc = new marcarMalla();
            marc.marcaCelda(mallaDaxMed);
            marc = null;
            cambiado = true;
        }

        private void btnColumna_Click(object sender, EventArgs e)
        {
            marcarMalla marc = new marcarMalla();
            marc.marcaColumna(mallaDaxMed);
            marc = null;
            cambiado = true;
        }
        private void btnLinea_Click(object sender, EventArgs e)
        {
            marcarMalla marc = new marcarMalla();
            marc.marcaLinea(mallaDaxMed);
            marc = null;
            cambiado = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarRegistros();
        }

        private void guardarRegistros()

        {
            ManejoBases manbas = new ManejoBases();
            manbas.guardarRegistros(strConxDaxsys, usuario, empresa.ToString(), sistema, mallaDaxMed);
            cambiado = false;
            Close();
        }



        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (cambiado == true)
            {
                System.Windows.Forms.DialogResult resp = new DialogResult();
                resp = MessageBox.Show("Desea guadar los cambios antes de salir ? ", "Salir del proceso", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (resp == System.Windows.Forms.DialogResult.Cancel) return;
                if (resp == System.Windows.Forms.DialogResult.Yes)
                {
                    guardarRegistros();
                }
            }
            this.Close();
        }

        private void mallaNomina_KeyDown(object sender, KeyEventArgs e)
        {
            marcarMalla marc = new marcarMalla();
            if (e.KeyCode == Keys.F2) marc.marcaCelda(mallaDaxMed);
            else if (e.KeyCode == Keys.F3) marc.marcaTodo(mallaDaxMed);
            else if (e.KeyCode == Keys.F4) marc.marcaColumna(mallaDaxMed);
            else if (e.KeyCode == Keys.F5) marc.marcaLinea(mallaDaxMed);
            marc = null;
            cambiado = true;
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma eliminar las autorizaciones actuales ?", "Autorizaciones de usuarios", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
            ManejoBases manBas = new ManejoBases();
            string ssql = "delete from  sys_accesos ";
            ssql += " where idUsuario = '" + usuario + "' and idempresa = " + empresa + " and idSistema = '" + sistema + "' ";
            manBas.ejecutarComando(strConxDaxsys, ssql);
            manBas = null;
        }

		private void FrmMedico_Load(object sender, EventArgs e)
		{

		}
	}
}
