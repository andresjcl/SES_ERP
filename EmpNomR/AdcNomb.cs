using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpNomR
{
	public class AdcNomb
	{
        public string RetornaNombreSucursal(int CodigoEmp, string Codigo, string strConxDaxsys)
        {
            string RetornaNombreSucursalRet = default;
            var ConxDaxsys = new SqlConnection(strConxDaxsys);
            SqlDataReader RsSuc;
            var Comm = new SqlCommand(" SELECT suc_nombre FROM emp_suc where emp_codigo= " + CodigoEmp + " and Suc_codigo='" + Codigo + "'  ", ConxDaxsys);
            try
            {

                ConxDaxsys.Open();
                RsSuc = Comm.ExecuteReader();
                if (RsSuc.Read())
                {
                    return RsSuc.GetString(RsSuc.GetOrdinal("Suc_Nombre"));
                }
                else
                {
                    RetornaNombreSucursalRet = "";
                }
            }
            catch
            {
            }

            RsSuc = default;
            ConxDaxsys.Dispose();
            Comm.Dispose();
            return RetornaNombreSucursalRet;

        }

        public string RetornaNombreBodega(int CodigoEmp, string CodigoSuc, string Codigo, string strConxDaxsys)
        {
            using (SqlConnection ConxDaxsys = new SqlConnection(strConxDaxsys))
            {
                ConxDaxsys.Open();
                using (SqlCommand Comm = new SqlCommand(" SELECT bod_nombre FROM emp_bod where emp_codigo= " + CodigoEmp + " and bod_codigo='" + Codigo + "'  ", ConxDaxsys))
                {
                    using (SqlDataReader RsSuc = Comm.ExecuteReader())
                    {
                        if (RsSuc.Read())
                        {
                            return RsSuc.GetString(RsSuc.GetOrdinal("bod_Nombre"));
                        }
                        else
                        {
                            return "";
                        }
                    }
                }
            }
        }

        public string RetornaNombreBanco(string codigo, string strConxAdcom)
        {
            using (SqlConnection ConxAdcom = new SqlConnection(strConxAdcom))
            {
                SqlCommand Comm = new SqlCommand(" SELECT Bco_Nombre FROM adcCtabco where bco_codigo= '" + codigo + "'", ConxAdcom);
                ConxAdcom.Open();
                SqlDataReader RsSuc = Comm.ExecuteReader();
                if (RsSuc.Read())
                {
                    string result = RsSuc.GetString(RsSuc.GetOrdinal("Bco_Nombre"));
                    RsSuc.Close();
                    return result;
                }
                else
                {
                    return "";
                }
            }
        }

        public string RetornaNombrePago(string codigo, string strConxAdcom)
        {
            using (SqlConnection ConxAdcom = new SqlConnection(strConxAdcom))
            {
                SqlCommand Comm = new SqlCommand(" SELECT Descripcion FROM formasdepago where IdFormasDePago = '" + codigo + "'", ConxAdcom);
                ConxAdcom.Open();
                SqlDataReader RsSuc = Comm.ExecuteReader();
                if (RsSuc.Read())
                {
                    string result = RsSuc.GetString(RsSuc.GetOrdinal("Descripcion"));
                    RsSuc.Close();
                    return result;
                }
                else
                {
                    return "";
                }
            }
        }

        public string RetornaCodigoPago(string codigo, string strConxAdcom)
        {
            using (SqlConnection ConxAdcom = new SqlConnection(strConxAdcom))
            {
                using (SqlCommand Comm = new SqlCommand(" SELECT IdFormasDePago FROM formasdepago where descripcion = '" + codigo + "'", ConxAdcom))
                {
                    ConxAdcom.Open();
                    using (SqlDataReader RsSuc = Comm.ExecuteReader())
                    {
                        if (RsSuc.Read())
                        {
                            return RsSuc.GetString(RsSuc.GetOrdinal("IdFormasDePago"));
                        }
                        else
                        {
                            return "";
                        }
                    }
                }
            }
        }

        public string RetornaNombreNivel(string Codigo, string strConxAdcom)
        {
            using (SqlConnection ConxAdcom = new SqlConnection(strConxAdcom))
            {
                using (SqlCommand Comm = new SqlCommand("SELECT niv_nombre FROM AdcNiv Where Niv_abrevia= '" + Codigo + "' ", ConxAdcom))
                {
                    ConxAdcom.Open();
                    using (SqlDataReader RsSuc = Comm.ExecuteReader())
                    {
                        if (RsSuc.Read())
                        {
                            return RsSuc.GetString(RsSuc.GetOrdinal("Niv_nombre"));
                        }
                        else
                        {
                            return "";
                        }
                    }
                }
            }
        }

        public string RetornaMedida(string Codigo, string strConxDaxsys)
        {
            using (SqlConnection ConxAdcom = new SqlConnection(strConxDaxsys))
            {
                using (SqlCommand Comm = new SqlCommand("Select Descripcion from Syscod where tiporeferencia ='Medidas' and abreviación = @Codigo", ConxAdcom))
                {
                    Comm.Parameters.AddWithValue("@Codigo", Codigo);
                    ConxAdcom.Open();
                    using (SqlDataReader RsSuc = Comm.ExecuteReader())
                    {
                        if (RsSuc.Read())
                        {
                            return RsSuc.GetString(0);
                        }
                        else
                        {
                            return "";
                        }
                    }
                }
            }
        }

        public string RetornaNombreCtaCont(string codigo, string strConxAdcom)
        {
            using (SqlConnection ConxAdcom = new SqlConnection(strConxAdcom))
            {
                using (SqlCommand Comm = new SqlCommand("SELECT Cta_Codigo,Cta_Nombre FROM AdcCta WHERE Cta_Codigo=@codigo", ConxAdcom))
                {
                    Comm.Parameters.AddWithValue("@codigo", codigo.Trim());
                    ConxAdcom.Open();
                    using (SqlDataReader RsSuc = Comm.ExecuteReader())
                    {
                        if (RsSuc.Read())
                        {
                            return RsSuc.GetString(RsSuc.GetOrdinal("Cta_Nombre"));
                        }
                        else
                        {
                            return "";
                        }
                    }
                }
            }
        }

        public string RetornaNombreDirectorio(string codigo, string strConxAdcom)
        {
            using (SqlConnection ConxAdcom = new SqlConnection(strConxAdcom))
            {
                using (SqlCommand Comm = new SqlCommand("SELECT NombreImpresion FROM Identificacion WHERE codigo=@codigo", ConxAdcom))
                {
                    Comm.Parameters.AddWithValue("@codigo", codigo.Trim());
                    ConxAdcom.Open();
                    using (SqlDataReader RsSuc = Comm.ExecuteReader())
                    {
                        if (RsSuc.Read())
                        {
                            return RsSuc.GetString(RsSuc.GetOrdinal("NombreImpresion"));
                        }
                        else
                        {
                            return "";
                        }
                    }
                }
            }
        }

        public string RetornaCodigoSyscod(string Tipo, string Nombre, string strConxDaxsys)
        {
            using (SqlConnection ConxDaxsys = new SqlConnection(strConxDaxsys))
            {
                using (SqlCommand Comm = new SqlCommand("SELECT Abreviación FROM Syscod WHERE TipoReferencia = @Tipo and Descripcion = @Nombre", ConxDaxsys))
                {
                    Comm.Parameters.AddWithValue("@Tipo", Tipo.Trim());
                    Comm.Parameters.AddWithValue("@Nombre", Nombre.Trim());
                    ConxDaxsys.Open();
                    using (SqlDataReader RsSuc = Comm.ExecuteReader())
                    {
                        if (RsSuc.Read())
                        {
                            return RsSuc.GetString(0);
                        }
                        else
                        {
                            return "";
                        }
                    }
                }
            }
        }

        public string RetornaNombreSyscod(string Tipo, string Codigo, string strConxDaxsys)
        {
            using (SqlConnection ConxDaxsys = new SqlConnection(strConxDaxsys))
            {
                using (SqlCommand Comm = new SqlCommand("SELECT Descripcion FROM Syscod WHERE TipoReferencia = @Tipo and Abreviación = @Codigo", ConxDaxsys))
                {
                    Comm.Parameters.AddWithValue("@Tipo", Tipo.Trim());
                    Comm.Parameters.AddWithValue("@Codigo", Codigo.Trim());
                    ConxDaxsys.Open();
                    using (SqlDataReader RsSuc = Comm.ExecuteReader())
                    {
                        if (RsSuc.Read())
                        {
                            return RsSuc.GetString(0);
                        }
                        else
                        {
                            return "";
                        }
                    }
                }
            }
        }

        public string RetornaNombreConceptoRol(string Codigo, string strConxAdcom,  string tipo = "")
        {
            using (SqlConnection ConxDaxsys = new SqlConnection(strConxAdcom))
            {
                using (SqlCommand Comm = new SqlCommand("SELECT Con_tipo,Con_Descripcion FROM Defcon WHERE con_numero = @Codigo", ConxDaxsys))
                {
                    Comm.Parameters.AddWithValue("@Codigo", Codigo);
                    ConxDaxsys.Open();
                    using (SqlDataReader Rs = Comm.ExecuteReader())
                    {
                        if (Rs.Read())
                        {
                            string result = Rs.GetString(Rs.GetOrdinal("con_Descripcion"));
                            tipo = Rs.GetString(Rs.GetOrdinal("con_tipo"));
                            return result;
                        }
                        else
                        {
                            return "";
                        }
                    }
                }
            }
        }

        //public string RetornaCodigoConceptoRol(string Nombre, string strConxAdcom,  string tipo = "")
        //{
        //    using (SqlConnection ConxDaxsys = new SqlConnection(strConxAdcom))
        //    {
        //        using (SqlCommand Comm = new SqlCommand("SELECT Con_tipo,con_numero FROM Defcon WHERE Con_Descripcion = @Nombre", ConxDaxsys))
        //        {
        //            Comm.Parameters.AddWithValue("@Nombre", Nombre);
        //            ConxDaxsys.Open();
        //            using (SqlDataReader Rs = Comm.ExecuteReader())
        //            {
        //                if (Rs.Read())
        //                {
        //                    string result =Convert.ToString(Rs.GetString(Rs.GetOrdinal("con_numero")));
        //                    tipo = Rs.GetString(Rs.GetOrdinal("con_tipo"));
        //                    return result;
        //                }
        //                else
        //                {
        //                    return "";
        //                }
        //            }
        //        }
        //    }
        //}

        public string RetornaCodigoConceptoRol(string Nombre, string strConxAdcom, string tipo = "")
        {
            using (SqlConnection ConxDaxsys = new SqlConnection(strConxAdcom))
            {
                using (SqlCommand Comm = new SqlCommand("SELECT Con_tipo, con_numero FROM Defcon WHERE Con_Descripcion = @Nombre", ConxDaxsys))
                {
                    Comm.Parameters.AddWithValue("@Nombre", Nombre);
                    ConxDaxsys.Open();

                    using (SqlDataReader Rs = Comm.ExecuteReader())
                    {
                        if (Rs.Read())
                        {
                            string result = Convert.ToString(Rs["con_numero"]);
                            tipo = Convert.ToString(Rs["con_tipo"]);
                            return result;
                        }
                        else
                        {
                            return "";
                        }
                    }
                }
            }
        }

        public string RetornaNombreTurno(string codigo, string strConxAdcom)
        {
            using (SqlConnection ConxAdcom = new SqlConnection(strConxAdcom))
            using (SqlCommand Comm = new SqlCommand("select NumeroTurno, Descripción from tim_horarios where NumeroTurno = @codigo", ConxAdcom))
            {
                Comm.Parameters.AddWithValue("@codigo", codigo.Trim());
                ConxAdcom.Open();
                using (SqlDataReader RsSuc = Comm.ExecuteReader())
                {
                    if (RsSuc.Read())
                    {
                        return RsSuc.GetString(RsSuc.GetOrdinal("Descripción"));
                    }
                    else
                    {
                        return "";
                    }
                }
            }
        }

        public string RetornaNombrePeriodo(double codigo, string strConxAdcom)
        {
            using (SqlConnection ConxAdcom = new SqlConnection(strConxAdcom))
            using (SqlCommand Comm = new SqlCommand("SELECT PER_NOMBRE as Descripción FROM ROLPER where NumeroTurno = @codigo", ConxAdcom))
            {
                Comm.Parameters.AddWithValue("@codigo", codigo.ToString().Trim());
                ConxAdcom.Open();
                using (SqlDataReader RsSuc = Comm.ExecuteReader())
                {
                    if (RsSuc.Read())
                    {
                        return RsSuc.GetString(RsSuc.GetOrdinal("Descripción"));
                    }
                    else
                    {
                        return "";
                    }
                }
            }
        }

        public string RetornaNombreCategoria(string Articulo, string strConxAdcom)
        {
            using (SqlConnection ConxAdcom = new SqlConnection(strConxAdcom))
            {
                SqlDataReader RsSuc;
                SqlCommand Comm = new SqlCommand("SELECT AdcNiv.Niv_nombre FROM AdcArt LEFT JOIN AdcNiv ON AdcArt.Art_categor = AdcNiv.Niv_abrevia WHERE niv_categor = 1 AND AdcArt.Art_codigo = @Articulo", ConxAdcom);
                Comm.Parameters.AddWithValue("@Articulo", Articulo.Trim());

                ConxAdcom.Open();
                RsSuc = Comm.ExecuteReader();

                if (RsSuc.Read())
                {
                    string result = RsSuc["Niv_nombre"].ToString();
                    RsSuc.Close();
                    return result;
                }
                else
                {
                    RsSuc.Close();
                    return string.Empty;
                }
            }
        }

        public string RetornaNombreClase(string Articulo, string strConxAdcom)
        {
            using (SqlConnection ConxAdcom = new SqlConnection(strConxAdcom))
            {
                SqlDataReader RsSuc;
                SqlCommand Comm = new SqlCommand("SELECT AdcNiv.Niv_nombre FROM AdcArt LEFT JOIN AdcNiv ON AdcArt.Art_clase = AdcNiv.Niv_abrevia WHERE niv_categor = 2 AND AdcArt.Art_codigo = @Articulo", ConxAdcom);
                Comm.Parameters.AddWithValue("@Articulo", Articulo.Trim());

                ConxAdcom.Open();
                RsSuc = Comm.ExecuteReader();
                string result = "";

                if (RsSuc.Read())
                {
                    result = RsSuc["Niv_nombre"].ToString();
                }

                RsSuc.Close();
                return result;
            }
        }

   
        public string RetornaNombreGrupo(string Articulo, string strConxAdcom)
        {
            using (SqlConnection ConxAdcom = new SqlConnection(strConxAdcom))
            {
                SqlDataReader RsSuc;
                SqlCommand Comm = new SqlCommand("SELECT AdcNiv.Niv_nombre FROM AdcArt left JOIN AdcNiv ON AdcArt.Art_grupo = AdcNiv.Niv_abrevia WHERE niv_categor = 3 and AdcArt.Art_codigo = @Articulo", ConxAdcom);
                Comm.Parameters.AddWithValue("@Articulo", Articulo.Trim());
                ConxAdcom.Open();
                RsSuc = Comm.ExecuteReader();
                if (RsSuc.Read())
                {
                    string result = RsSuc["Niv_nombre"].ToString();
                    RsSuc.Close();
                    return result;
                }
                else
                {
                    RsSuc.Close();
                    return string.Empty;
                }
            }
        }

        public string RetornaNombreSubGrupo(string Articulo, string strConxAdcom)
        {
            using (SqlConnection ConxAdcom = new SqlConnection(strConxAdcom))
            {
                SqlDataReader RsSuc;
                SqlCommand Comm = new SqlCommand("SELECT AdcNiv.Niv_nombre FROM AdcArt left JOIN AdcNiv ON AdcArt.Art_subgrup = AdcNiv.Niv_abrevia WHERE niv_categor = 4 and AdcArt.Art_codigo = @Articulo", ConxAdcom);
                Comm.Parameters.AddWithValue("@Articulo", Articulo.Trim());
                ConxAdcom.Open();
                RsSuc = Comm.ExecuteReader();
                if (RsSuc.Read())
                {
                    string result = RsSuc["Niv_nombre"].ToString();
                    RsSuc.Close();
                    return result;
                }
                else
                {
                    RsSuc.Close();
                    return string.Empty;
                }
            }
        }

        public string RetornaNombreArticulo(string Codigo, string strConxAdcom)
        {
            using (SqlConnection ConxAdcom = new SqlConnection(strConxAdcom))
            {
                SqlDataReader RsSuc;
                SqlCommand Comm = new SqlCommand("SELECT art_nombre FROM AdcArt WHERE Art_codigo = @Codigo", ConxAdcom);
                Comm.Parameters.AddWithValue("@Codigo", Codigo.Trim());
                ConxAdcom.Open();
                RsSuc = Comm.ExecuteReader();
                if (RsSuc.Read())
                {
                    string result = RsSuc["art_nombre"].ToString();
                    RsSuc.Close();
                    return result;
                }
                else
                {
                    RsSuc.Close();
                    return string.Empty;
                }
            }
        }

        public string RetornaNombreServicio(string Codigo, string strConxAdcom)
        {
            using (SqlConnection ConxAdcom = new SqlConnection(strConxAdcom))
            {
                SqlDataReader RsSuc;
                SqlCommand Comm = new SqlCommand("SELECT sev_nombre FROM AdcServ WHERE sev_codigo = @Codigo", ConxAdcom);
                Comm.Parameters.AddWithValue("@Codigo", Codigo.Trim());
                ConxAdcom.Open();
                RsSuc = Comm.ExecuteReader();
                if (RsSuc.Read())
                {
                    string result = RsSuc["sev_nombre"].ToString();
                    RsSuc.Close();
                    return result;
                }
                else
                {
                    RsSuc.Close();
                    return string.Empty;
                }
            }
        }


    }
}
