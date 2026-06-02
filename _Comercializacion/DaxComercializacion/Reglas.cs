using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DattCom;

namespace DaxComercia
{
    public class Reglas
    {
        public void llenarComboDatosFormula(ComboBox comboDatos)
        {
            string ssql = "select  * from daxdatform where art_codigo = '('";
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter(ssql, datosEmpresa.strConxAdcom))
                {
                    comboDatos.Items.Clear();
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    foreach (DataColumn dc in dt.Columns)
                    {
                            comboDatos.Items.Add(dc.ColumnName);
                    }
                    dt.Dispose();
                }
            }
            catch (Exception EX)
            {
            }
        }
    }
}
