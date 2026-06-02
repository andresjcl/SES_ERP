using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace mntUsrs
{
    public partial class frmDirectorio : Form
    {
        string strConxDaxsys = "";
        string usuario = "";
        int empresa = 0;
        string nomEmpresa = "";
        string sistema = "";
        //DataTable dtAccesos;
        Boolean cambiado = false;
        
        public frmDirectorio(string strsys, string usr, int emp,string nomEmp, string sys)
        {
            InitializeComponent();
            strConxDaxsys = strsys;
            usuario = usr;
            empresa = emp;
            nomEmpresa = nomEmp;
            sistema = "DIR";
            diseñoMallas.DiseñarMallaDirectorio (mallaDir);
            this.Text = "Registrar accesos al directorio de " + nomEmp + " usuario : " + usr;
            cargaMenusMallas.cargaMenuDirectorio(mallaDir);
            cargarDatosMallas.cargarRegistrosActuales(strConxDaxsys, mallaDir, empresa, sistema, usuario);
        }

        //private void cargarRegistrosActuales(string strConxDaxsys)
        //{
        //    ManejoBases progBas = new ManejoBases();
        //    //progBas.actualizar(strConxDaxsys);
        //    dtAccesos = progBas.leerAccesosActuales(strConxDaxsys,usuario,empresa.ToString(),sistema );
            
        //    foreach (DataRow row in dtAccesos.Rows)
        //    { 
        //        for (Int16 i = 0;i<mallaDir.Rows.Count;i++ )
        //        {
        //            if (row["IdOpcion"].ToString() == mallaDir.Rows[i].Cells["clave"].Value.ToString())
        //            {
        //                string aux =row["accnvo"].ToString() + "      ";
        //                mallaDir.Rows[i].Cells["conAcceso"].Value = aux.Substring(0, 1);
        //            }
        //        }
        //    }
        //    cambiado = false;
        //}

        private void mallaDir_KeyDown(object sender, KeyEventArgs e)
        {
            marcarMalla marc = new marcarMalla();
            if (e.KeyCode == Keys.F2) marc.marcaCelda(mallaDir);
            else if (e.KeyCode == Keys.F3) marc.marcaTodo (mallaDir);
            else if (e.KeyCode == Keys.F4) marc.marcaColumna (mallaDir);
            else if (e.KeyCode == Keys.F5) marc.marcaLinea(mallaDir);
            marc = null;
            cambiado = true;
        }

        private void btnTodo_Click(object sender, EventArgs e)
        {
            marcarMalla marc = new marcarMalla();
            marc.marcaTodo(mallaDir);
            marc = null;
            cambiado = true;
        }

        private void tnCambia_Click(object sender, EventArgs e)
        {            
            marcarMalla marc = new marcarMalla();
            marc.marcaCelda(mallaDir);
            marc = null;
            cambiado = true;
        }

        private void btnColumna_Click(object sender, EventArgs e)
        {
            marcarMalla marc = new marcarMalla();
            marc.marcaColumna (mallaDir);
            marc = null;
            cambiado = true;
        }
        private void btnLinea_Click(object sender, EventArgs e)
        {
            marcarMalla marc = new marcarMalla();
            marc.marcaLinea(mallaDir);
            marc = null;
            cambiado = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            guardarRegistros();
            Cursor = Cursors.Default;
            Close();
        }
        private void guardarRegistros()
        {
            ManejoBases manbas = new ManejoBases();
            manbas.guardarRegistros(strConxDaxsys, usuario, empresa.ToString(), sistema, mallaDir);
            cambiado = false;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (cambiado == true) 
            { 
                System.Windows.Forms.DialogResult resp = new DialogResult ();
                resp = MessageBox.Show("Desea guadar los cambios antes de salir ? ", "Salir del proceso", MessageBoxButtons.YesNoCancel , MessageBoxIcon.Question);
                if (resp == System.Windows.Forms.DialogResult.Cancel) return;
                if (resp == System.Windows.Forms.DialogResult.Yes)
                {
                    guardarRegistros();
                }
            }   
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show ("Confirma eliminar las autorizaciones actuales ?","Autorizaciones de usuarios", MessageBoxButtons.YesNo, MessageBoxIcon.Question )== System.Windows.Forms.DialogResult.No ) return;
            ManejoBases manBas = new ManejoBases();            
            string ssql = "delete from  sys_accesos " ;
            ssql += " where idUsuario = '" + usuario + "' and idempresa = " + empresa + " and idSistema = '"+sistema+"' ";
            manBas.ejecutarComando(strConxDaxsys,ssql);
            manBas = null;
        }
    }
}
