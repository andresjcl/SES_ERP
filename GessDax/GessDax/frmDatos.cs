using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DattCom;
namespace GessDax
{
    
    public partial class frmDatos : Form
    {
        bool saltar = true;
        string[] tipoDato;
        public frmDatos()
        {
            InitializeComponent();
            llenarTipoDatos(datosEmpresa.strConxAdcom);
            if (sb_reporte.idTipoDato != 0 && sb_datosMalla.columnas.Count >0) listadoExistente();
            else sb_datosMalla.columnas.Clear();
            saltar = false;
        }
        public void llenarTipoDatos(string strConxAdcom)
        {
            string ssql = "select idtipodato, cast(idtipodato as varchar(3)) + ' - ' + descripción as Descripción from sysdatgess ";
            using (SqlDataAdapter da = new SqlDataAdapter(ssql,strConxAdcom))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbTipoDatos.ValueMember = "idtipodato";
                cmbTipoDatos.DisplayMember = "Descripción";
                cmbTipoDatos.DataSource = dt;
//                dt.Dispose();
                cmbTipoDatos.SelectedIndex = 0;
            }
        }
        private void listadoExistente()
        {
            cmbTipoDatos.SelectedValue = sb_reporte.idTipoDato;
            label2.Visible = false;
            txtNombreReporte.Enabled = false;
            cmbTipoDatos.Enabled = false;
            cargarDisponibles();
            sb_datosMalla.cargarDatosAlista(camposSeleccionados);
            txtNombreReporte.Text = sb_datosMalla.nombre;
        }
        private void cargarDisponibles()
        {
            //---- TIPO DE BSE DE DATOS     DX>ADCOM IV>IVARET PR>PRODUCCION SY>DAXSYS
            string strx="";
            if (sb_reporte.baseDatos == "DX") strx = datosEmpresa.strConxAdcom;
            else if (sb_reporte.baseDatos == "IV") strx = datosEmpresa.strConxIvaret;
                else if (sb_reporte.baseDatos == "PR") strx = datosEmpresa.strConxDaxpro;
                    else if (sb_reporte.baseDatos == "SY") strx = datosEmpresa.strConxSyscod;
            if (strx == "") return;
            if (sb_reporte.procedInicial.Length > 3) EjecutarConsulta("exec " + sb_reporte.procedInicial + "'" + "01/01/1900" + "','" + DateTime.Now.ToShortDateString() + "' ", strx);
            sb_cargDatos cd = new sb_cargDatos();
            cd.CargarDatosDisponibles(sb_reporte.consultaFinal,datosEmpresa.strConxAdcom,ref datosDisponibles, ref tipoDato);
            cd = null;
        }
        private void EjecutarConsulta(string consulta,string strconx)
        {
            try
            {
                string ssql = "set dateformat dmy;" + consulta;
                using (SqlConnection conn = new SqlConnection(strconx))
                {
                    conn.Open();
                    SqlCommand misqlDa = new SqlCommand(ssql, conn);                    
                    misqlDa.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudo conectar a la base de datos de GESS \n" + e.Message);
            }
        }
        private void cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            if (txtNombreReporte.Text =="")
            {
                if (MessageBox.Show("No se ha registrado el nombre del reporte \n Los datos escojidos se eliminarán \n Continuar ?", "DaxGess", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                { 
                    return; 
                }
                else
                {
                    camposSeleccionados.Items.Clear();
                    Close();
                    return;
                }
            }
            sb_datosMalla.nombre = txtNombreReporte.Text;
            sb_datosMalla.reorganizarDatosEscojidos(camposSeleccionados, tipoDato, datosDisponibles);
            Close();
        }

        private void cmbTipoDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (saltar) return;
          sb_reporte.cargar(Convert.ToInt32(cmbTipoDatos.SelectedValue));
          cargarDisponibles();
        }

        private void datosDisponibles_DoubleClick(object sender, EventArgs e)
        {
            if (datosDisponibles.SelectedItem == null) return;
            for (int i = 0; i < camposSeleccionados.Items.Count;i++ )
            {
                if (datosDisponibles.SelectedItem.ToString() == camposSeleccionados.Items[i].ToString()) return;
            }
            camposSeleccionados.Items.Add(datosDisponibles.SelectedItem);
            cmbTipoDatos.Enabled = false;
        }

        private void camposSeleccionados_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Delete) camposSeleccionados.Items.RemoveAt(camposSeleccionados.SelectedIndex);
            }catch{ }
        }

    }
}
