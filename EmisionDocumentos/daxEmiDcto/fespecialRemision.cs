using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using daxMallaDatos;
namespace daxEmiFacPv
{
    class fespecialRemision
    {
        private docMallaArticulo mallaArticulo = new docMallaArticulo();
        public string strConxAdcom = string.Empty ;
        public void funcionespecial(Keys datKey, DataGridView malla)
        {
            mallaArticulo.strConxAdcom = strConxAdcom;
            string resp = string.Empty ;
            DataGridViewCell cell = malla.CurrentCell;
            Int32 columnIndex = cell.ColumnIndex ;
            Int32 rowIndex = cell.RowIndex ;
            malla.EndEdit();
            string dato = "";
            dato = "" + cell.Value.ToString();
            if (dato != "" && malla.Columns[columnIndex].Name.ToUpper() == "CODIGO")
            {
                if (mallaArticulo.cargarArticuloRem(dato, malla.CurrentRow) == false) malla.CurrentCell = cell;
            }
        }


        private DataTable leerTablas(string ssql)
        { 
            SqlDataAdapter da;
            DataTable dt = new DataTable();            
            try
            {
                da = new SqlDataAdapter(ssql, strConxAdcom );
                da.Fill(dt);
            }
            catch
            {
                return null;
            }            
            return dt;
        }
    }
}
