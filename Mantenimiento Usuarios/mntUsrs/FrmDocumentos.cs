using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mntUsrs
{
    public partial class FrmDocumentos : Form
    {
        string PathServidor = "";
        string strConxDaxsys = "";
        string strConxAdcom = "";
        string usuario = "";
        int empresa = 0;
        string nomEmpresa = "";
        string sistema = "";

        Boolean cambiado = false;
        ManejoBases progBas = new ManejoBases();

        public FrmDocumentos(string PathServ, string strsys, string strConx, string usr, int emp, string nomEmp, string sys)
        {

            InitializeComponent();
            PathServidor = PathServ;
            strConxDaxsys = strsys;
            usuario = usr;
            empresa = emp;
            nomEmpresa = nomEmp;
            sistema = sys;
            strConxAdcom = strConx;
            this.Text = "Registrar accesos al sistema  " + nomEmp + " usuario : " + usr;
            cargarMenus();
        }
        private void cargarMenus()
        {
            //cargaMenusMallas cmenu = new cargaMenusMallas();
            //cmenu.cargaMenuPrincipal(mallaMenu, PathServidor);
            //cmenu.cargaMenuSucursales(mallaSucursal, strConxDaxsys, empresa.ToString());
            cargaMenusMallas.cargaMenuGruposDocumentos(mallaGrupoDocumentos);
            cargaMenusMallas.cargaMenuDocumentos(mallaDocIndividual, strConxAdcom);
            cargarRegistrosActuales(strConxDaxsys);
            controlBotones();
        }

        private void cargarRegistrosActuales(string strConxDaxsys)
        {
            //cargarDatosMallas cdm = new cargarDatosMallas();
            //cdm.cargarDatosMenuPrincipal(strConxDaxsys, mallaMenu, empresa, sistema, usuario);
            //cdm.cargarDatosSucursal(strConxDaxsys, mallaSucursal, empresa, sistema, usuario);
            cargarDatosMallas.cargarDatosGrupoDocumentos(strConxDaxsys, mallaGrupoDocumentos, empresa, "GRD", usuario);
            cargarDatosMallas.cargarDatosDocumentos(strConxDaxsys, mallaDocIndividual, empresa, sistema, usuario);
        }

        //private void mallaMenu_KeyDown(object sender, KeyEventArgs e)
        //{
        //    marcarMalla marc = new marcarMalla();
        //    marc.marcaKeys(mallaMenu, e);
        //    cambiado = true;
        //    marc = null;
        //    cambiado = true;
        //}
        //private void mallaSucursal_KeyDown(object sender, KeyEventArgs e)
        //{
        //    marcarMalla marc = new marcarMalla();
        //    marc.marcaKeys(mallaSucursal, e);
        //    cambiado = true;
        //    marc = null;
        //    cambiado = true;
        //}
        private void mallaGrupoDocumentos_KeyDown(object sender, KeyEventArgs e)
        {
            marcarMalla marc = new marcarMalla();
            marc.marcaKeys(mallaGrupoDocumentos, e);
            cambiado = true;
            marc = null;
            cambiado = true;
        }
        private void mallaDocIndividual_KeyDown(object sender, KeyEventArgs e)
        {
            marcarMalla marc = new marcarMalla();
            marc.marcaKeys(mallaDocIndividual, e);
            marc = null;
            cambiado = true;
        }

        private void btnTodo_Click(object sender, EventArgs e)
        {
            marcarMalla marc = new marcarMalla();
            marc.marcaTodo(mallaActual());
            marc = null;
            cambiado = true;
        }

        private void tnCambia_Click(object sender, EventArgs e)
        {
            marcarMalla marc = new marcarMalla();
            marc.marcaCelda(mallaActual());
            marc = null;
            cambiado = true;
        }

        private void btnColumna_Click(object sender, EventArgs e)
        {
            marcarMalla marc = new marcarMalla();
            marc.marcaColumna(mallaActual());
            marc = null;
            cambiado = true;
        }
        private void btnLinea_Click(object sender, EventArgs e)
        {
            marcarMalla marc = new marcarMalla();
            marc.marcaLinea(mallaActual());
            marc = null;
            cambiado = true;
        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarRegistros();
        }
        private string armarAccesoNuevo(DataGridViewRow row)
        {
            string aux = (row.Cells["conAcceso"].Value.ToString() + " ").Substring(0, 1);
            return aux;
        }

        private void guardarRegistros()
        {
            ManejoBases manbas = new ManejoBases();
            //manbas.guardarRegistros(strConxDaxsys, usuario, empresa.ToString(), sistema, mallaMenu);
            //manbas.guardarSucursales(strConxDaxsys, usuario, empresa.ToString(), mallaSucursal);
            manbas.guardarRegistros(strConxDaxsys, usuario, empresa.ToString(), "CNX", mallaGrupoDocumentos);
            manbas.guardarDocumentos(strConxDaxsys, usuario, empresa.ToString(), mallaDocIndividual);
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

        private DataGridView mallaActual()
        {
            if (mallaGrupoDocumentos.Focused) return mallaGrupoDocumentos;
            return mallaDocIndividual;
        }

        private void btnIndividual_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = mallaDocIndividual.CurrentCell;
            if (cell.Value == null) return;
            daxAccs.frmAccsDoc docs = new daxAccs.frmAccsDoc(empresa, usuario, mallaDocIndividual.Rows[cell.RowIndex].Cells["Modulo"].Value.ToString(), mallaDocIndividual.Rows[cell.RowIndex].Cells["Opcion"].Value.ToString(), strConxDaxsys, strConxAdcom);
            docs.ShowDialog();
        }


        private void controlBotones()
        {

        }
    }
}
