using System;
using System.Data;
using System.Data.SqlClient;

namespace DattCom
{
	public static class SqlDatos
	{
		public static DataTable leerTabla(string sql, string strconx)
		{

			using (SqlDataAdapter da = new SqlDataAdapter(sql, strconx))
			{
				DataTable dt = new DataTable();
				da.Fill(dt);
				da.Dispose();
				return dt;
			}
		}

		//public static DataTable leerTablaAdcom(string sql)
		//{
		//	using (SqlDataAdapter da = new SqlDataAdapter(sql, datosEmpresa.strConxAdcom))
		//	{
		//		DataTable dt = new DataTable();
		//		da.Fill(dt);
		//		da.Dispose();
		//		return dt;
		//	}
		//}

		public static DataTable leerTablaAdcom(string sql)
		{
            {
                using (var conn = new SqlConnection(datosEmpresa.strConxAdcom))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandTimeout = 360; // 👈 5 minutos (ajusta según necesidad: 60, 120, 300...)

                    using (var da = new SqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }


		public static DataTable leerTablaIniSis(string sql)
		{

			using (SqlDataAdapter da = new SqlDataAdapter(sql, datosEmpresa.strConIniSis))
			{
				DataTable dt = new DataTable();
				da.Fill(dt);
				da.Dispose();
				return dt;
			}
		}
		public static DataTable leerTablaIvaret(string sql)
		{

			using (SqlDataAdapter da = new SqlDataAdapter(sql, datosEmpresa.strConxIvaret))
			{
				DataTable dt = new DataTable();
				da.Fill(dt);
				da.Dispose();
				return dt;
			}
		}
		public static SqlDataReader leerBase(string sql, string strconx)
		{
			SqlConnection conn = new SqlConnection(strconx);
			{
				conn.Open();
				SqlCommand comm = new SqlCommand(sql, conn);
				SqlDataReader dr = comm.ExecuteReader();
				return dr;
			}
		}
		public static SqlDataReader leerBaseAdcom(string sql)
		{
			SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom);
			{
				conn.Open();
				SqlCommand comm = new SqlCommand(sql, conn);
				SqlDataReader dr = comm.ExecuteReader();
				return dr;
			}
		}
		public static SqlDataReader leerBaseIniSis(string sql)
		{
			SqlConnection conn = new SqlConnection(datosEmpresa.strConIniSis);
			{
				conn.Open();
				SqlCommand comm = new SqlCommand(sql, conn);
				SqlDataReader dr = comm.ExecuteReader();
				return dr;
			}
		}
		public static SqlDataReader leerBaseIvaret(string sql)
		{
			SqlConnection conn = new SqlConnection(datosEmpresa.strConxIvaret);
			{
				conn.Open();
				SqlCommand comm = new SqlCommand(sql, conn);
				SqlDataReader dr = comm.ExecuteReader();
				return dr;
			}
		}
		public static void ejecutarComando(string sql, string strconx)
		{
			using (SqlConnection conn = new SqlConnection(strconx))
			{
				conn.Open();
				SqlCommand comm = new SqlCommand(sql, conn);
				comm.ExecuteNonQuery();
				conn.Close();
				conn.Dispose();
			}
		}
		public static void ejecutarComandoAdcom(string sql)
		{
			using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxAdcom))
			{
				conn.Open();
				SqlCommand comm = new SqlCommand(sql, conn);
				comm.ExecuteNonQuery();
				conn.Close();
				conn.Dispose();
			}
		}
		public static void ejecutarComandoIniSis(string sql)
		{
			using (SqlConnection conn = new SqlConnection(datosEmpresa.strConIniSis))
			{
				conn.Open();
				SqlCommand comm = new SqlCommand(sql, conn);
				comm.ExecuteNonQuery();
				conn.Close();
				conn.Dispose();
			}
		}
		public static void ejecutarComandoIvaret(string sql)
		{
			using (SqlConnection conn = new SqlConnection(datosEmpresa.strConxIvaret))
			{
				conn.Open();
				SqlCommand comm = new SqlCommand(sql, conn);
				comm.ExecuteNonQuery();
				conn.Close();
				conn.Dispose();
			}
		}
		public static string ArmStr(string Path, string Serv = "", string tipo = "", string PasswBd = "", string Usuario = "", Int32 Version = 0)
		{
			string cadena = "";
			if (tipo == "ACC")
			{
				cadena = "DRIVER={Microsoft Access Driver (*.mdb)};";
				cadena += " DBQ=" + Path + ";";
				cadena += " UID=" + Usuario + ";PWD=" + PasswBd + ";";
			}
			else if (tipo == "6")
			{

				cadena = "Provider=MSDASQL;DRIVER=SQL Server;";
				cadena = cadena + "SERVER=" + Serv + ";";
				cadena = cadena + "UID=" + Usuario.Trim() + ";";
				cadena = cadena + "PWD=" + PasswBd + ";";
				cadena = cadena + "APP=AdcomDx;";
				cadena = cadena + "WSID=" + Serv.ToUpper() + ";";
				cadena = cadena + "DATABASE=" + Path + ";";

			}
			else
			{

				cadena = "server=" + Serv + ";";
				cadena = cadena + "user id=" + Usuario.Trim() + ";";
				cadena = cadena + "password=" + PasswBd + ";";
				cadena = cadena + "database=" + Path + ";";
				cadena = cadena + "pooling=false";
			}

			return cadena;
		}
	}
}
