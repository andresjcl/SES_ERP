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
    public partial class frmNomina : Form
    {
        string strConxDaxsys = "";
        string usuario = "";
        int empresa = 0;
        string nomEmpresa = "";
        string sistema = "";
        DataTable dtAccesos;
        Boolean cambiado = false;
        public frmNomina(string strsys, string usr, int emp, string nomEmp, string sys)
        {
            InitializeComponent();
            strConxDaxsys = strsys;
            usuario = usr;
            empresa = emp;
            nomEmpresa = nomEmp;
            sistema = "NOM";
            diseñoMallas.DiseñarMallaNomina (mallaNomina);
            this.Text = "Registrar accesos a Nomina, de " + nomEmp + " usuario : " + usr;
            cargaMenuNómina();
            cargarRegistrosActuales(strsys);
        }
        
        private void cargaMenuNómina()
        {
            string[] trabajadores = {"Lista directorio","Mantenimiento directorio","Mantenimiento de Familiares","Registro de ausencias y cambios","Préstamos","Finiquitos"};
            string[] rolPagos = {"Rol general","Conceptos","Formulas","Parámetros","Registro de novedades","Consulta Rol Individual","Consulta Rol Total","Calcular rol","Comprobantes de pago"};
            string[] especiales = { "Períodos", "CalcularFormulas", "EditarAcumulados", "Utilidades", "Resúmenes", "ImportarProduccion", "DefineContabilidadCentroCosto", "IntegrarDepartamentos", "GenerarContabilidad", "CierreDePeríodos" };
            int ii = 5;
            for (int i = 0; i < ii; i++)
            {
                mallaNomina.Rows.Add();
                mallaNomina.Rows[i].Cells["modulo"].Value = "TRABAJADORES";
                mallaNomina.Rows[i].Cells["opcion"].Value = trabajadores[i];
                mallaNomina.Rows[i].Cells["Abierto"].Value = "";
                mallaNomina.Rows[i].Cells["Consultar"].Value = "";
                mallaNomina.Rows[i].Cells["clave"].Value = "mnuonNomTrab" + i.ToString();
            }
            ii = 8;
            for (int i = 0; i < ii; i++)
            {
                mallaNomina.Rows.Add();
                mallaNomina.Rows[i + 5].Cells["modulo"].Value = "ROLPAGOS";
                mallaNomina.Rows[i + 5].Cells["opcion"].Value = rolPagos[i];
                mallaNomina.Rows[i + 5].Cells["Abierto"].Value = "";
                mallaNomina.Rows[i + 5].Cells["Consultar"].Value = "";
                mallaNomina.Rows[i + 5].Cells["clave"].Value = "mnuonNomRol" + i.ToString();
            }
            ii = 10;
            int jj=0;
            for (int i = 0; i < ii; i++)
            {
                mallaNomina.Rows.Add();
                mallaNomina.Rows[i + 13].Cells["modulo"].Value = "ESPECIALES";
                mallaNomina.Rows[i + 13].Cells["opcion"].Value = especiales[i];
                mallaNomina.Rows[i + 13].Cells["Abierto"].Value = "";
                mallaNomina.Rows[i + 13].Cells["Consultar"].Value = "";
                mallaNomina.Rows[i + 13].Cells["clave"].Value = "mnuonNomEsp" + i.ToString();
                jj=i;
            }
            string ssql = "select abreviación as codigo, descripcion as nombre from syscod where tiporeferencia = 'departamento' and abreviación <> '#'";
            ManejoBases progBas = new ManejoBases();
            DataTable dt = progBas.leerTablas(strConxDaxsys, ssql);
            mallaNomina.Rows.Add();
            foreach (DataRow row in dt.Rows)
            {
                mallaNomina.Rows.Add();

                jj++;

                mallaNomina.Rows[jj + 14].Cells["modulo"].Value = row["Codigo"].ToString();
                mallaNomina.Rows[jj + 14].Cells["opcion"].Value = row["Nombre"].ToString();
                mallaNomina.Rows[jj + 14].Cells["Abierto"].Value = "";
                mallaNomina.Rows[jj + 14].Cells["Consultar"].Value = "";
                mallaNomina.Rows[jj + 14].Cells["clave"].Value = "mnuonNomDep" + row["Codigo"].ToString();                        
            }
        }

        private void cargarRegistrosActuales(string strConxDaxsys)
        {
            ManejoBases progBas = new ManejoBases();
            //progBas.actualizar(strConxDaxsys);
            dtAccesos = progBas.leerAccesosActuales(strConxDaxsys,usuario,empresa.ToString(),sistema);

            if (dtAccesos.Rows.Count > 0)
            {
                foreach (DataRow row in dtAccesos.Rows)
                {
                    for (Int16 i = 0; i < mallaNomina.Rows.Count; i++)
                    {
                        if (row["IdOpcion"].ToString() == mallaNomina.Rows[i].Cells["clave"].Value.ToString())
                        {
                            string aux = row["accnvo"].ToString() + "      ";
                            mallaNomina.Rows[i].Cells["Abierto"].Value = aux.Substring(0, 1);
                            mallaNomina.Rows[i].Cells["Consultar"].Value = aux.Substring(1, 1);
                        }
                    }
                }
                cambiado = false;
            }
        }

        private void btnTodo_Click(object sender, EventArgs e)
        {
            marcarMalla marc = new marcarMalla();
            marc.marcaTodo(mallaNomina);
            marc = null;
            cambiado = true;
        }

        private void tnCambia_Click(object sender, EventArgs e)
        {
            marcarMalla marc = new marcarMalla();
            marc.marcaCelda(mallaNomina);
            marc = null;
            cambiado = true;
        }

        private void btnColumna_Click(object sender, EventArgs e)
        {
            marcarMalla marc = new marcarMalla();
            marc.marcaColumna (mallaNomina);
            marc = null;
            cambiado = true;
        }
        private void btnLinea_Click(object sender, EventArgs e)
        {
            marcarMalla marc = new marcarMalla();
            marc.marcaLinea(mallaNomina);
            marc = null;
            cambiado = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarRegistros();
        }
        private string armarAccesoNuevo(DataGridViewRow row)
        {
            string aux = (row.Cells["Abierto"].Value.ToString() + " ").Substring(0, 1);
            aux += (row.Cells["Consultar"].Value.ToString() + " ").Substring(0, 1);
            return aux;        
        }

        private void guardarRegistros()
 
        {
            ManejoBases manbas = new ManejoBases();
            manbas.guardarRegistros(strConxDaxsys, usuario, empresa.ToString(), sistema, mallaNomina);
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
            if (e.KeyCode == Keys.F2) marc.marcaCelda(mallaNomina);
            else if (e.KeyCode == Keys.F3) marc.marcaTodo(mallaNomina);
            else if (e.KeyCode == Keys.F4) marc.marcaColumna(mallaNomina);
            else if (e.KeyCode == Keys.F5) marc.marcaLinea(mallaNomina);
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

    }
}
