using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DattCom;

namespace MantenimientoDirectorioOnline
{
	public class Module1
	{
        public static string Orden = "";

        public static void Mainn()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(datosEmpresa.strConxAdcom))
                    return;
            }
            catch (Exception ee)
            {
                MessageBox.Show("excepción mainn: " + ee.Message);
            }
            Emp.CargarValores();
        }

        public static bool ValidaId(ref string numeroId, ref string tipoId, string persona)
        {
            try
            {
                if (tipoId == "P")
                    return true;

                if (tipoId == "F")
                    return numeroId == "9999999999999";

                int largo = numeroId.Length;
                if (!long.TryParse(numeroId, out _))
                    return false;

                if (tipoId == "R")
                {
                    if (largo != 13 || !numeroId.EndsWith("001"))
                        return false;
                }
                else if (tipoId == "C")
                {
                    if (largo != 10)
                        return false;
                }

                int tercerDigito = int.Parse(numeroId.Substring(2, 1));

                if (tipoId == "C")
                {
                    // return Validador.validarCedula(numeroId);
                }
                else if (tercerDigito >= 0 && tercerDigito <= 5)
                {
                    // return Validador.validarRUCNaturales(numeroId);
                }
                else if (tercerDigito == 6)
                {
                    // return Validador.validarRUCPublicas(numeroId);
                }
                else if (tercerDigito == 9)
                {
                    // return Validador.validarRUCPrivadas(numeroId);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ClienteMovimiento(ref string codigo)
        {
            using (var conxAdcom = new SqlConnection(datosEmpresa.strConxAdcom))
            {
                try
                {
                    conxAdcom.Open();

                    string query = "SELECT Doc_codper FROM AdcDoc WHERE Doc_codper = @codigo";
                    using (var comm = new SqlCommand(query, conxAdcom))
                    {
                        comm.Parameters.AddWithValue("@codigo", codigo);
                        using (var rs = comm.ExecuteReader())
                        {
                            if (rs.HasRows)
                                return true;
                        }
                    }

                    query = "SELECT idempleado FROM rolliq WHERE idempleado = @codigo";
                    using (var comm = new SqlCommand(query, conxAdcom))
                    {
                        comm.Parameters.AddWithValue("@codigo", codigo);
                        using (var rs = comm.ExecuteReader())
                        {
                            return rs.HasRows;
                        }
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show("excepción Mandir_Clmov: " + ee.Message);
                    return false;
                }
            }
        }
    }
}
