using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using DattCom;

namespace ConxServer
{
	public partial class ingServidor : Form
    {
        public ingServidor(string sistem, string pthAppl)
        {
            InitializeComponent();
            sistema = sistem;
            PathAppl = pthAppl;
            //Label6.Text = pthAppl;
        }

        private bool EsOk;
        private string sistema = "";
        private string PathAppl = "";
        //private string StrConxSyscod = "";

        private bool ValidaClave(string Cl1, string Cl2)
        {
            // If Cl1 </value> Cl2 Then
            // MsgBox("No coinciden las contraseñas", vbCritical)
            // ValidaClave = False
            // TxtPassword.Focus()
            // Exit Function
            // End If
            return true;
        }

        private void Command4_Click(System.Object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Confirma recuperar la última conexión exitosa al servidor del sistema ?", "Configuración Inicial", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.OK)
                leerArchivoConfiguracion(@"bin\");
        }
        private void leerArchivoConfiguracion(string bak)
        {
            DataTable dt = new DataTable();
            try
            {
                dt.ReadXml(Environment.CurrentDirectory + bak + sistema + ".xml");
                TxtServidor.Text = dt.Rows[0]["Servidor"].ToString();
                TxtUsuario.Text = dt.Rows[0]["Usuario"].ToString();
                TxtPassword.Text = dt.Rows[0]["Clave"].ToString();
                TxtUrl.Text = dt.Rows[0]["URL"].ToString();
                TxtPasswordc.Text = TxtPassword.Text;
            }
            catch
            {
            }
        }

        private void Command1_Click(System.Object sender, System.EventArgs e)
        {
            if (ValidaClave(TxtPassword.Text, TxtPasswordc.Text) == false) return;
            SqlConnection cnn = new SqlConnection(ConexionSql.ArmStr("master", TxtServidor.Text, "10", TxtPassword.Text, TxtUsuario.Text));
            if (TxtServidor.Text != "")
            {
                try { cnn.Open(); } catch { };
            }
            EsOk = false;
            if (cnn.State == 0)
            {
                MessageBox.Show("No se pudo efectuar la conexión al servidor de base de datos", "Configuración Inicial", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            MessageBox.Show("Conexión al servidor de base de datos exitosa !!", "Configuración Inicial", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cnn.Close();
            cnn = new SqlConnection(ConexionSql.ArmStr(txtBaseLicencia.Text, TxtServidor.Text, "10", TxtPassword.Text, TxtUsuario.Text));

            try { cnn.Open(); } catch { }

            if (cnn.State == 0)
            {
                MessageBox.Show("No se ha instalado la base de datos control del sistema en el servidor", "Configuración Inicial", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            if (System.IO.Directory.Exists(TxtUrl.Text) == false)
            {
                MessageBox.Show("El directorio, en el servidor, donde se encuentra instalado el sistema es inaccesible", "Configuración Inicial", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            EsOk = true;

            if (TxtUrl.Text.Substring(TxtUrl.Text.Length - 1, 1) != @"\")
                TxtUrl.Text = TxtUrl.Text + @"\";

            grabarConfiguracionSistema();
        }
        private void grabarConfiguracionSistema()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Servidor");
            dt.Columns.Add("Usuario");
            dt.Columns.Add("Clave");
            dt.Columns.Add("URL");
            dt.Columns.Add("Bds");
            dt.TableName = "config";
            DataRow row = dt.NewRow();
            row["Servidor"] = TxtServidor.Text;
            row["Usuario"] = TxtUsuario.Text;
            row["Clave"] = TxtPassword.Text;
            row["URL"] = TxtUrl.Text;
            row["Bds"] = txtBaseLicencia.Text;
            dt.Rows.Add(row);
            dt.WriteXml(PathAppl + sistema + ".xml");
            dt.WriteXml(PathAppl + @"bin\" + sistema + ".xml");
            string ruta = Path.Combine(PathAppl, "bin", sistema + ".xml");
            dt.WriteXml(ruta);

            dt.Dispose();
        }
        private void Command3_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void Command2_Click(System.Object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtServidor.Text) || string.IsNullOrEmpty(TxtUsuario.Text) || string.IsNullOrEmpty(TxtPassword.Text) || string.IsNullOrEmpty(TxtUrl.Text))
            {
                MessageBox.Show("Complete la información de conexión al servidor del sistema ", "Configuración Inicial", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Command1_Click(Command1, e);
                if (EsOk)
                    this.Close();
                MessageBox.Show("Ingrese al sistema nuevamente para activar los nuevos parámetros", "Configuración Inicial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }

        }

		private void Command1_Click_1(object sender, EventArgs e)
		{
            if (ValidaClave(TxtPassword.Text, TxtPasswordc.Text) == false) return;
            SqlConnection cnn = new SqlConnection(ConexionSql.ArmStr("master", TxtServidor.Text, "10", TxtPassword.Text, TxtUsuario.Text));
            if (TxtServidor.Text != "")
            {
                try { cnn.Open(); } catch { };
            }
            EsOk = false;
            if (cnn.State == 0)
            {
                MessageBox.Show("No se pudo efectuar la conexión al servidor de base de datos"); return;
            }
            MessageBox.Show("Conexión al servidor de base de datos exitosa !!");
            cnn.Close();
            //cnn = new SqlConnection(ConexionSql.ArmStr(datosEmpresa.strConIniSis, TxtServidor.Text, "10", TxtPassword.Text, TxtUsuario.Text));
            cnn = new SqlConnection(ConexionSql.ArmStr(txtBaseLicencia.Text, TxtServidor.Text, "10", TxtPassword.Text, TxtUsuario.Text));
            try { cnn.Open(); } catch { }

            if (cnn.State == 0)
            {
                MessageBox.Show("No se ha instalado la base de datos control del sistema en el servidor"); return;
            }
            if (System.IO.Directory.Exists(TxtUrl.Text) == false)
            {
                MessageBox.Show("El directorio, en el servidor, donde se encuentra instalado el sistema es inaccesible"); return;
            }
            EsOk = true;

            if (TxtUrl.Text.Substring(TxtUrl.Text.Length - 1, 1) != @"\")
                TxtUrl.Text = TxtUrl.Text + @"\";

            grabarConfiguracionSistema();
        }

		private void Command2_Click_1(object sender, EventArgs e)
		{
            Command1_Click(Command1, e);
            if (EsOk)
                this.Close();
            MessageBox.Show("Ingrese al sistema nuevamente para activar los nuevos parámetros");
            Environment.Exit(0);
        }

		private void Command3_Click_1(object sender, EventArgs e)
		{
            this.Close();
        }

		private void Command4_Click_1(object sender, EventArgs e)
		{
            if (MessageBox.Show("Confirma recuperar la última conexión exitosa al servidor del sistema ?", "", MessageBoxButtons.YesNo) == DialogResult.OK)
                leerArchivoConfiguracion(@"bin\");
        }

		private void label6_Click(object sender, EventArgs e)
		{

		}
	}


}
