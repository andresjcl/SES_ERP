using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using DattCom;

namespace IngSis
{
    public class DelUsuario
    {
        public static string VerificarClave(string ClaveSecreta, string ClaveIngreso)
        {
            string Empresas = "";
            try
            {
                SqlConnection ConxDaxsys = new SqlConnection(DattCom.datosEmpresa.strConIniSis);
                SqlDataReader Rs;
                SqlCommand Comm = new SqlCommand();
                string Separador = "";
                ConxDaxsys.Open();
                // Dim resp As String
                {
                    DattCom.DatosUsuario.ClaveSecreta = ClaveSecreta;
                    DattCom.DatosUsuario.codigo = ClaveIngreso;
                }


                switch (DattCom.DatosUsuario.Estado)
                {
                    case 0:
                        {
                            if (ClaveIngreso.ToUpper() == "ADMINISTRADOR" || ClaveIngreso.ToUpper() == "CONTROL")
                            {
                                Comm.CommandText = "Select emp_codigo as IdEmpresa from Emp_datos";
                            }
                            else
                            {
                                Comm.CommandText = "Select IdEmpresa from sys_accesos where idusuario = '" + ClaveIngreso + "' AND idSistema ='" + datosEmpresa.sistema + "' group by idempresa";
                            }
                            Comm.Connection = ConxDaxsys;
                            Rs = Comm.ExecuteReader();
                            if (Rs.HasRows == false)
                            {
                                MessageBox.Show("El usuario no tiene acceso a ninguna empresa");
                            }
                            else
                                while (Rs.Read())
                                {
                                    Empresas += Separador + Rs["IdEmpresa"].ToString();
                                    Separador = ",";
                                }
                            if (Rs.IsClosed == false)
                                Rs.Close();
                            break;
                        }

                    case 1:
                    case 2:
                        {
                            MessageBox.Show("Acceso inválido el usuario no existe o la clave secreta no es valida");
                            break;
                        }

                    case 3:
                        {
                            MessageBox.Show("La validez de su identificación a vencido consulte al administrador");
                            break;
                        }

                    case 9:
                        {
                            MessageBox.Show("No tiene clave secreta de acceso, debe registrarla ahora");
                            break;
                        }

                    case 4:
                        {
                            MessageBox.Show("La validez de su clave secreta a vencido, debe cambiar su clave secreta ahora");
                            break;
                        }
                }
                ConxDaxsys.Dispose();
                Comm.Dispose();
                Rs = null;
            }
            catch (Exception ee)
            {
                MessageBox.Show("Existe un error en la verificación de acceso \n" + ee.Message);
                Application.Exit(); // Environment.Exit(0);
            }
            return Empresas;
        }
    }
}
