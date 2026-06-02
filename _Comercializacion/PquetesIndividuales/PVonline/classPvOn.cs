using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ClassDoc;
namespace adcArticulosPrecios
{
    public class classPvOn
    {
        DataTable productosDocmto = new DataTable();


        public void calcPv(idDocumento idDoc, string formulasDoc, string strConxAdcom, string user)
        {
            if (formulasDoc.Length == 0) return;

            classVar.classVarIni();
           
            leerDocumento(idDoc, strConxAdcom);

            if (productosDocmto.Rows.Count == 0) return;

            string[] formula = (formulasDoc).Split(Convert.ToChar(","));
            for (int i = 0; i < formula.Length; i++)
            {
        //        MessageBox.Show(formula[i]);
                if (formula[i]!="") procesarFormula(formula[i],strConxAdcom,user,idDoc);
            }
        }
        private  void procesarFormula(string formula,string strConxAdcom,string user,idDocumento idDoc)
        {
            if (formula.Length == 0) return;
            DaxFormPv datFormul = new DaxFormPv(strConxAdcom);
            datFormul = DaxFormPv.Buscar(" IdFormulaPvta = " + formula);        
            if (datFormul == null) return;
            if (datFormul.PrecioActualiza == "") return;
            if (datFormul.snConfirma == true)
            {
                if (MessageBox.Show("El precio de venta ''" + datFormul.PrecioActualiza + "''  de los productos en este documento se cambiarán automáticamente (FORM-" + formula + ")", "Cambio de precios automáticos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            }
            if (datFormul.consultaSQL != "")
            {
                calcPvSql(idDoc, strConxAdcom, user,formula);
                return;
            }
            foreach (DataRow row in productosDocmto.Rows)
            {
                procesarCambios(row["tra_codigo"].ToString(), row["tra_precuni"].ToString(), datFormul, strConxAdcom, user);
            }
        }
        public void calcPvSql(idDocumento idDoc, string strConxAdcom, string user,string formula)
        {
            //string Ssql = " DaxVtaPrecioOnLine @suc, @tipdoc, @idclave,@formula ";
            string Ssql = "DaxVtaPrecioOnLine";

            using (SqlConnection conn = new SqlConnection(strConxAdcom))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(Ssql, conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue ("@suc", idDoc.Sucursal);
                comm.Parameters.AddWithValue("@tipdoc", idDoc.Tipo);
                comm.Parameters.AddWithValue("@idclave", idDoc.idClave.ToString());
                comm.Parameters.AddWithValue("@formula", formula);
                comm.ExecuteNonQuery();
            }
        }
        private void leerDocumento(idDocumento idDoc, string strConxAdcom)
        {
            string Ssql = "select tra_codigo,tra_precuni from adctra where doc_sucursal = '" + idDoc.Sucursal + "' and opc_documento = '" + idDoc.Tipo + "' and idclavedoc = " + idDoc.idClave.ToString();
            SqlDataAdapter da = new SqlDataAdapter(Ssql, strConxAdcom);
            productosDocmto = new DataTable();
            da.Fill(productosDocmto);
        }
        private void procesarCambios(string Producto,string Valor, DaxFormPv formula, string strConxAdcom,string user)
        {
            string bakSsql = "";
            string Ssql = "";
            string Where = " and ";
            string sqlWhere = "";
            string cambiarPrecio = "";
            string precioActual = "";
            int numPrecio = 0;
            Ssql =  " (adcart.Art_codigo ='" + Producto + "' )";
            try
            {
                classVar.columnaPrecio(formula.PrecioActualiza,formula.FormulaValInicial,ref cambiarPrecio,ref precioActual, ref numPrecio);
                if (formula.ArticuloIni != "" && formula.ArticuloFin != "")
                {
                    if (formula.ArticuloIni.CompareTo(formula.ArticuloFin) > 0)
                    {
                        MessageBox.Show("Los códigos de artículos que establecen los límites están errados", "Filtros de artículos en fórmula", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    Ssql += Where + " (adcart.Art_codigo >='" + formula.ArticuloIni + "' and adcart.Art_codigo <='" + formula.ArticuloFin + "')";
                    Where = " and ";
                }
                if (formula.Categoria != "0") { Ssql += Where + " Art_categor ='" + formula.Categoria + "'"; }
                if (formula.Clase != "0") { Ssql += Where + " Art_clase ='" + formula.Clase + "'"; }
                if (formula.Grupo != "0") { Ssql += Where + " Art_grupo ='" + formula.Grupo + "'"; }
                if (formula.Subgrupo != "0") { Ssql += Where + " Art_subgrup ='" + formula.Subgrupo + "'"; }


                sqlWhere = Ssql;

                bakSsql = "select '" + DateTime.Now.ToShortDateString() + "' as fechaCambio";
                bakSsql += "," + numPrecio.ToString() + " as nroListaPrecios";
                bakSsql += ",'' as temporada";
                bakSsql += ",'" + user + "' as usuario";
                bakSsql += ",'" + Environment.MachineName + "' as equipo";
                bakSsql += ",adcart.art_codigo as producto";
                bakSsql += "," + cambiarPrecio;
                bakSsql += "," + classVar.ultimoCambioProducto(strConxAdcom).ToString();
                bakSsql += ",'" + cambiarPrecio + "' from adcart ";
                if (sqlWhere.Length > 0) bakSsql +=  " where (" + sqlWhere + ")";

                string multiplica = "1";
                string sumar = "0";
                
                //MessageBox.Show(" val " + formula.FormulaValMultiplica.ToString());

                if (formula.FormulaValMultiplica == 9999) 
                    { multiplica  = " Art_CoefctePrecio "; }
                else 
                {
                    if (formula.FormulaValMultiplica != 0 ) multiplica = formula.FormulaValMultiplica.ToString();
                }
                if (formula.FormulaValSuma.ToString() != "") sumar = formula.FormulaValSuma.ToString();
                Ssql = "update adcart set " + cambiarPrecio + " = ( " + Valor + " * " + multiplica + ") + " + sumar;
                if (sqlWhere.Length > 0) Ssql +=  " where (" + sqlWhere + ")" ;
                variarPrecio(Ssql, bakSsql, cambiarPrecio,strConxAdcom);
            }
            catch  (Exception ee)
            {
                MessageBox.Show("Los cambios no se han podido realizar revise las opciones seleccionadas \n" + ee.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("El cambio de precio se realizó correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void variarPrecio(string comando, string guardar, string campo,string strConxAdcom)
        {
            try
            {  
                using (SqlConnection conexion = new SqlConnection(strConxAdcom))
                {
                    SqlConnection conn = new SqlConnection(strConxAdcom);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into adcprvtabk " + guardar, conn);                   
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand(comando, conn);
                    cmd.ExecuteNonQuery();                    
                    cmd.Dispose();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("No se ha podido ejecutar el comando  \n  "+comando +" \n" + ee.Message, "Cambiar valores-precios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
