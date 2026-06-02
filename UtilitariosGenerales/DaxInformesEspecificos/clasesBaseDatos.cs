using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DaxInfDefinidos
{
    class clasesBaseDatos
    {

        static internal bool CargarMallaConceptos(DataGridView MallaDatos, bool activos, bool cesantes, string Suc, string Cargo,string anio, ref string filtro)
        {
            string Ssql = "SELECT ID.Codigo, ID.NombreImpresion, SRI.Vivienda, SRI.Alimentación, SRI.Vestimenta, SRI.Educación, SRI.Salud, SRI.IngresoPatronoAnterior, SRI.AportesIessPatronoAnterior, SRI.IngresosAdicionales, 000000000.00 AS st";
            Ssql += " FROM Identificacion AS ID LEFT OUTER JOIN";
            Ssql += " (select * from DaxNomIrValPer where año = " + anio + ") AS SRI ON SRI.Empleado = ID.Codigo LEFT OUTER JOIN";
            Ssql += " EMPLEADO AS EMP ON ID.Codigo = EMP.CodigoEmpleado ";
            filtro = " WHERE ISNULL(Id.EsEmpleado, 0) = 1 ";

            if (activos)
            {
                filtro += " AND (ISNULL(EMP.EstadoRol,'A') = 'A' or EMP.estadoRol = '' )  ";
            }
            if (cesantes)
            {
                filtro += " AND (ISNULL(EMP.EstadoRol,'A') = 'C' )  ";
            }
            if (Suc != "0" && Suc != "")
            {
                filtro += " AND (ISNULL(EMP.Sucursalrol,'') = '" + Suc + "') ";
            }

            if (Cargo != "0" && Cargo != "")
            {
                filtro += " AND (ISNULL(EMP.Cargorol,'') = '" + Cargo + "') ";
            }
            Ssql += filtro;
            Ssql += " ORDER BY ID.NombreImpresion";
            try
            {
                SqlDataAdapter MiAdaptador = new SqlDataAdapter(Ssql, varbleComun.VarCom.strConxAdcom);
                DataTable DT = new DataTable();
                MiAdaptador.Fill(DT);

                MallaDatos.DataSource = DT;
                arreglarMalla.ArreglaMalla(MallaDatos);
                DT.Dispose();
            }catch { return false; }
            return true;
        }

        static internal bool guardandoRegistros(DataGridView MallaDatos, string filtro,string anio)
        {
            string Ssql = "SELECT ID.Codigo";
            Ssql += " FROM Identificacion AS ID LEFT OUTER JOIN";
            Ssql += " DaxNomIrValPer AS SRI ON SRI.Empleado = ID.Codigo LEFT OUTER JOIN";
            Ssql += " EMPLEADO AS EMP ON ID.Codigo = EMP.CodigoEmpleado ";
            Ssql += filtro;
            bool procesado = true;
            string ssql = "select * from DaxNomIrValPer where empleado in (" + Ssql + ") and año = " + anio;
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter(ssql, varbleComun.VarCom.strConxAdcom))
                {
                    SqlCommandBuilder cb = new SqlCommandBuilder(da);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    bool nuevo = false;
                    foreach (DataGridViewRow drow in MallaDatos.Rows)
                    {
                        if (Convert.ToDecimal("0" + drow.Cells["st"].Value) > 0)
                        {
                            nuevo = false;
                            DataRow nrow = encontrarRow(drow.Cells["codigo"].Value.ToString(), dt);
                            if (nrow == null) { nrow = dt.NewRow(); nuevo = true; }

                            //SELECT ,  Vivienda, Alimentación, Vestimenta, Educación, Salud, IngresoPatronoAnterior, AportesIessPatronoAnterior, IngresosEmpresa, AportesEmpresa, IngresosAdicionales
                            //FROM DaxNomIrValPer

                            nrow["año"] = anio;
                            nrow["Empleado"] = drow.Cells["Codigo"].Value.ToString();
                            nrow["Vivienda"] = Convert.ToDecimal("0" + drow.Cells["Vivienda"].Value);
                            nrow["Alimentación"] = Convert.ToDecimal("0" + drow.Cells["Alimentación"].Value);
                            nrow["Vestimenta"] = Convert.ToDecimal("0" + drow.Cells["Vestimenta"].Value);
                            nrow["Educación"] = Convert.ToDecimal("0" + drow.Cells["Educación"].Value);
                            nrow["Salud"] = Convert.ToDecimal("0" + drow.Cells["Salud"].Value);
                            nrow["IngresoPatronoAnterior"] = Convert.ToDecimal("0" + drow.Cells["IngresoPatronoAnterior"].Value);
                            nrow["AportesIessPatronoAnterior"] = Convert.ToDecimal("0" + drow.Cells["AportesIessPatronoAnterior"].Value);
                            nrow["IngresosAdicionales"] = Convert.ToDecimal("0" + drow.Cells["IngresosAdicionales"].Value);

                            if (nuevo) dt.Rows.Add(nrow);
                        }
                    }
                    da.Update(dt);
                    dt.AcceptChanges();
                }
            }catch { procesado = false; }
            return procesado;
        }
        static private DataRow encontrarRow(string codigo, DataTable dt)
        {
            foreach (DataRow drow in dt.Rows)
            {
                if (drow["Empleado"].ToString() == codigo) return drow;
            }
            return null;
        }
    }
}
