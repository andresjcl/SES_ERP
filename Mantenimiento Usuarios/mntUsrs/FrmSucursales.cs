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
    public partial class FrmSucursales : Form
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
        public FrmSucursales(string PathServ, string strsys, string strConx, string usr, int emp, string nomEmp, string sys)
        {
            InitializeComponent();
            PathServidor = PathServ;
            strConxDaxsys = strsys;
            usuario = usr;
            empresa = emp;
            nomEmpresa = nomEmp;
            sistema = sys;
            strConxAdcom = strConx;
            this.Text = "Registrar accesos al sistema AdcomDax de " + nomEmp + " usuario : " + usr;
            cargarMenus();
        }
        private void cargarMenus()
        {
            //cargaMenusMallas cmenu = new cargaMenusMallas();
            //            cmenu.cargaMenuPrincipal(mallaMenu, PathServidor);
            cargaMenusMallas.cargaMenuSucursales(mallaSucursal, strConxDaxsys, empresa.ToString());
            cargaMenusMallas.cargaMenuBodegas(mallaBodegas, strConxDaxsys, empresa.ToString());
            //          cmenu.cargaMenuGruposDocumentos(mallaGrupoDocumentos);
            //        cmenu.cargaMenuDocumentos(mallaDocIndividual, strConxAdcom);
            cargarRegistrosActuales(strConxDaxsys);
            controlBotones();
        }

        private void cargarRegistrosActuales(string strConxDaxsys)
        {
            //cargarDatosMallas cdm = new cargarDatosMallas();
            //      cdm.cargarDatosMenuPrincipal(strConxDaxsys, mallaMenu, empresa, sistema, usuario);
            cargarDatosMallas.cargarDatosSucursal(strConxDaxsys, mallaSucursal, empresa, sistema, usuario);
            cargarDatosMallas.cargarDatosBodegas(strConxDaxsys, mallaBodegas, empresa, sistema, usuario);
            //    cdm.cargarDatosGrupoDocumentos(strConxDaxsys, mallaGrupoDocumentos, empresa, "GRD", usuario);
            //  cdm.cargarDatosDocumentos(strConxDaxsys, mallaDocIndividual, empresa, sistema, usuario);
        }

       
        private void mallaSucursal_KeyDown(object sender, KeyEventArgs e)
        {
            marcarMalla marc = new marcarMalla();
            marc.marcaKeys(mallaSucursal, e);
            cambiado = true;
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
            manbas.guardarSucursales(strConxDaxsys, usuario, empresa.ToString(), mallaSucursal,mallaBodegas);
            manbas.guardarBodegas(strConxDaxsys, empresa, usuario, mallaBodegas);
            //manbas.guardarRegistros(strConxDaxsys, usuario, empresa.ToString(), "GRD", mallaGrupoDocumentos);
            //manbas.guardarDocumentos(strConxDaxsys, usuario, empresa.ToString(), mallaDocIndividual);
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
            if (mallaSucursal.Focused) return mallaSucursal;
            return mallaBodegas;
        }

        //private void btnIndividual_Click(object sender, EventArgs e)
        //{
        //    DataGridViewCell cell = mallaDocIndividual.CurrentCell;
        //    if (cell.Value == null) return;
        //    daxAccs.frmAccsDoc docs = new daxAccs.frmAccsDoc(empresa, usuario, mallaDocIndividual.Rows[cell.RowIndex].Cells["Modulo"].Value.ToString(), mallaDocIndividual.Rows[cell.RowIndex].Cells["Opcion"].Value.ToString(), strConxDaxsys, strConxAdcom);
        //    docs.ShowDialog();
        //}


        private void controlBotones()
        {

            
        }

        private void btnAsiganPtoVta_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Seleccione la linea de la sucursal donde va asignar el punto de venta");
			if (mallaSucursal.CurrentRow.Cells["Modulo"] == null) return;
			string sucursal = mallaSucursal.CurrentRow.Cells["Modulo"].Value.ToString();

            // Validar que exista una fila seleccionada
            //if (mallaSucursal.CurrentRow == null)
            //    return;

            //// Validar que exista la columna Modulo
            //if (!mallaSucursal.Columns.Contains("Modulo"))
            //    return;

            //// Validar que la fila esté marcada con X
            //var acceso = mallaSucursal.CurrentRow.Cells["conAcceso"].Value;

            //if (acceso == null || acceso.ToString().Trim() != "X")
            //    return; // no tiene acceso

            //// Obtener sucursal
            //string sucursal = mallaSucursal.CurrentRow.Cells["Modulo"].Value?.ToString();

            //if (string.IsNullOrEmpty(sucursal))
            //    return;

            //frmUsrPtoVta progVta = new frmUsrPtoVta(strConxDaxsys, strConxAdcom, usuario , empresa, nomEmpresa, sistema, sucursal);
            frmUsrPtoVta progVta = new frmUsrPtoVta(strConxDaxsys, strConxAdcom, usuario, empresa, nomEmpresa, sistema);
            progVta.ShowDialog();
        }
    }
}
