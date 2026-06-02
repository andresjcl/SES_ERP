using System;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace adcDocumentos
{
    static internal class leerDatosDeLinea
    {
        static internal void tipoCaja(string dato, ref DataGridView malla)
        {
            string ssql = "select Abreviación as TipCaja,Descripcion,isnull(Caracteristica1,0) as Ramos,isnull(Caracteristica2,0) as Fulls  from syscod where TipoReferencia = 'CajasFlor'";
            ssql += " and abreviación = '" + dato + "'";
            using (SqlConnection conn = new SqlConnection(varbleComun.VarCom.strConxAdcom))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(ssql, conn);
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read())
                {
                    malla.CurrentCell.Value = dr["TipCaja"].ToString();
                    try
                    {
                        malla.CurrentRow.Cells["Fulls"].Value = Convert.ToDecimal(dr["Fulls"].ToString());
                    }
                    catch { malla.CurrentRow.Cells["Fulls"].Value = 0; }
                }
                else
                {
                    malla.CurrentCell.Value = "";
                    malla.CurrentRow.Cells["Fulls"].Value = 0;
                }
                dr.Close();
                conn.Close();
                comm.Dispose();
            }

        }

        static internal string zonaProducto(string dato, ref DataGridView malla)
        {
            RetNombre.AdcNomb nomb = new RetNombre.AdcNomb();
            string szon = nomb.RetornaNombreSyscod("zonaProducto",dato, varbleComun.VarCom.strConxSyscod);
            if (szon == "") dato = "";
            return dato;
        }
        static internal string bodega(string dato, ref DataGridView malla)
        {
            RetNombre.AdcNomb nomb = new RetNombre.AdcNomb();
            string suc = nomb.RetornaNombreSucursal(varbleComun.VarCom.codEmpresa, dato, varbleComun.VarCom.strConxSyscod);
            if (suc == "") dato = "";
            return dato;
        }
        static internal string nuevoNumeroDeCaja(DataGridView malla)
        {
            Int64 nroCaja = 1;
            Int64 nroCajaAct = 0;
            //string ssql = "select MAX(ISNULL(NROCAJA,0)) AS nroCaja from adctraPRO ";
            //using (SqlConnection conn = new SqlConnection(varbleComun.VarCom.strConxAdcom))
            //{
            //    conn.Open();
            //    using (SqlCommand comm = new SqlCommand(ssql, conn))
            //    {
            //        SqlDataReader dr = comm.ExecuteReader();
            //        if (dr.Read()) nroCaja = Convert.ToInt64("0" + dr["nroCaja"]) + 1;
            //    }

                foreach (DataGridViewRow row in malla.Rows)
                {
                    try
                    {
                        if (Convert.ToInt64(row.Cells["NROCAJA"].Value) >= nroCajaAct)
                        { nroCajaAct = Convert.ToInt64(row.Cells["NROCAJA"].Value); }
                    }
                    catch { }
                }
                if (nroCajaAct >= nroCaja) nroCaja = nroCajaAct + 1;
                return nroCaja.ToString();
            //}
        }
        internal static string repiteNumeroDeCaja(DataGridView malla)
        {
            try
            {
                if (Convert.ToInt64(malla.CurrentCell.Value) >= 0) return malla.CurrentCell.Value.ToString();
            }
            catch { }

            Int64 nroCajaAct = 1;
            foreach (DataGridViewRow row in malla.Rows)
            {
                try
                {
                    if (Convert.ToInt64(row.Cells["NROCAJA"].Value) >= 0)
                    { nroCajaAct = Convert.ToInt64(row.Cells["NROCAJA"].Value); }
                }
                catch { }
            }
            if (malla.CurrentCell.RowIndex > 0)
            {
                int indAct = malla.CurrentCell.RowIndex;
                int indAnt = malla.CurrentCell.RowIndex - 1;
                malla.Rows[indAct].Cells["CantCajas"].Value = malla.Rows[indAnt].Cells["CantCajas"].Value;
                malla.Rows[indAct].Cells["TipCaja"].Value = malla.Rows[indAnt].Cells["TipCaja"].Value;
                malla.Rows[indAct].Cells["Fulls"].Value = malla.Rows[indAnt].Cells["Fulls"].Value;
            }
            return nroCajaAct.ToString();
        }

    }
}
