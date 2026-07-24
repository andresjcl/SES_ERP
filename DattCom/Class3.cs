using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DattCom
{
	internal class Class3
    {
        internal static string cargarValoresIniciales()
        {
            string resp = "";
            try
            {
                var dt = new DataSet();
                dt.ReadXml(datosEmpresa.pathAppl + @"\" + datosEmpresa.sistema + ".xml");
                DataRow row = dt.Tables[0].Rows[0];
                datosEmpresa.UsuarioBd = row["Usuario"].ToString();
                datosEmpresa._ClaveBd = row["Clave"].ToString();
                datosEmpresa.pathServer = row["URL"].ToString();
                datosEmpresa.Servidor = row["Servidor"].ToString();
                //datosEmpresa.strConIniSis = row["Bds"].ToString();
                //datosEmpresa.nombreBaseSis = row["Bds"].ToString();
                dt.Dispose();
            }
            catch (Exception EE)
            {
                resp = "ERROR: No se ha inicializado la aplicación correctamente \n" + EE.Message;
            }

            if (string.IsNullOrEmpty(datosEmpresa.Servidor))
            {
                resp = "ERROR: La aplicación no esta configurada correctamente \nRevise la instalación del sistema, comuniquese con el administrador del sistema";
            }
            else
            {
                //datosEmpresa.strConIniSis = IngresoApp.ArmStr("BdIniSis", datosEmpresa.Servidor, "10", datosEmpresa.ClaveBd, datosEmpresa.UsuarioBd);
                //datosEmpresa.strConIniSis6 = IngresoApp.ArmStr("BdIniSis", datosEmpresa.Servidor, "SQL", datosEmpresa.ClaveBd, datosEmpresa.UsuarioBd);
                //datosEmpresa.strConIniSis = IngresoApp.ArmStr(datosEmpresa.nombreBaseSis, datosEmpresa.Servidor, "10", datosEmpresa.ClaveBd, datosEmpresa.UsuarioBd);
                //datosEmpresa.strConIniSis6 = IngresoApp.ArmStr(datosEmpresa.nombreBaseSis, datosEmpresa.Servidor, "SQL", datosEmpresa.ClaveBd, datosEmpresa.UsuarioBd);
                datosEmpresa.strConIniSis = IngresoApp.ArmStr("SysBd", datosEmpresa.Servidor, "10", datosEmpresa.ClaveBd, datosEmpresa.UsuarioBd);
                datosEmpresa.strConIniSis6 = IngresoApp.ArmStr("SysBd", datosEmpresa.Servidor, "SQL", datosEmpresa.ClaveBd, datosEmpresa.UsuarioBd);
                SqlConnection ConIniSis = new SqlConnection(datosEmpresa.strConIniSis);
                //datosEmpresa.marca = Emp_Servidor + "," + Emp_Usuario + "," + Emp_Clave;
                try
                {
                    ConIniSis.Open();
                    ConIniSis.Close();
                    //MessageBox.Show("Ingreso a la bd licencia");
                }
                catch (Exception ee)
                {
                    resp = "ERROR: La aplicación no esta configurada correctamente \nRevise la instalación del sistema, comuniquese con el administrador del sistema \n" + ee.Message;
                }

                if (ConIniSis == null)
                {
                    resp = ("ERROR: La base de datos del sistema no está instalada o no se puede acceder \nRevise la instalación del sistema,comuniquese con el administrador del sistema \nConexión nula");
                }
            }

            if (resp.Length > 2 && resp.Substring(0, 3) == "ERR")
            {
                if (System.Windows.Forms.MessageBox.Show(resp + " \nDesea ingresar los datos de conexión ahora ?", "Configuración Inicial del sistema", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.No) { Environment.Exit(0); }
                else
                {
                    ConxServer.ingServidor prog = new ConxServer.ingServidor(datosEmpresa.sistema, datosEmpresa.pathAppl);
                    prog.ShowDialog();
                    prog.Dispose();
                    Environment.Exit(0);
                }
            }
            return resp;
        }
    }
}
