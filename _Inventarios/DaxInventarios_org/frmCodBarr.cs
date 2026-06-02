using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using SysEmpDatt;

namespace DaxInvent
{
    internal partial class frmCodBarr : Form
    {
        string codigoBase = "";
        DataTable datos = new DataTable();
        internal frmCodBarr(string codigo, string Nombre,string strconx, ref DataTable datosCodBarr)
        {
            InitializeComponent();
            codigoBase = codigo;
            lblCodigoBase.Text = "Código Artículo: " + codigo + " - " + Nombre;
            //datosEmpresa.VarCom.strConxAdcom = strconx;
            datos = datosCodBarr;
            cargaInicial(ref datos, codigo);
            malla.DataSource = datos;
            diseñarMalla();            
            datos.Rows.Add(datos.NewRow());
        }
        public DataTable iniciarRegistro()
        {
            ShowDialog();
            return datos;
        }
        static public string Ssql = "";
        static public void cargaInicial(ref DataTable datosBarr,string codigoBase)
        {
            if (datosBarr.Columns.Count > 0) return;
            Ssql = "SELECT * from AdcTik ";
            Ssql += " where tik_artcodi = '" + codigoBase + "'";                        
            using (SqlDataAdapter da = new SqlDataAdapter(Ssql,datosEmpresa.strConxAdcom))
            {
                datosBarr = new DataTable();
                da.Fill(datosBarr);
            }        
        }
        private void diseñarMalla()
        {
            malla.Columns["TIK_COLOR"].Visible = false;
            malla.Columns["TIK_TALLA"].Visible = false;
            malla.Columns["TIK_ARTCODI"].Visible = false;

            malla.Columns["TIK_SERIE"].Visible = false;
            malla.Columns["TIK_ALTERNO"].Visible = false;

            malla.Columns["TIK_NUMERO"].HeaderText = "CodBarrasEAN13";            
        }
        protected override Boolean ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (malla.Focused == false && malla.IsCurrentCellInEditMode == false) return false;
            if (malla.IsCurrentCellInEditMode && keyData == Keys.Return) { malla.EndEdit(); return true;}
            if (!(keyData == Keys.Return || (keyData > Keys.F1 && keyData < Keys.F13))) return false;

            DataGridViewCell cell = malla.CurrentCell;
            if (cell.RowIndex > malla.Rows.Count - 3) { datos.Rows.Add(datos.NewRow()); }

            funcionesEspeciales(ref keyData, ref cell); 

            if (keyData != Keys.Return) return true;
            moverCeldaMalla(cell);
            return true;
        }
        private void moverCeldaMalla(DataGridViewCell cell)
        {

            Int32 columnIndex = cell.ColumnIndex;
            Int32 rowIndex = cell.RowIndex;
            Int32 col = columnIndex;
            Int32 row = rowIndex;

            Boolean esVisible = false;
            do
            {
                if (col == malla.Columns.Count - 1)
                {
                    if (row == malla.Rows.Count - 1)
                    {
                        col = 0;
                        row = 0;
                    }
                    else
                    {
                        col = 0;
                        row++;
                    }
                }
                else
                {
                    col++;
                }
                cell = malla.Rows[row].Cells[col];
                esVisible = (cell.Visible && !cell.ReadOnly);
            } while (esVisible == false);
            malla.CurrentCell = cell;
        }
        private Boolean funcionesEspeciales(ref Keys keyData, ref DataGridViewCell cell)
        {
            string datoNvo = "";

            string nombreCelda = malla.Columns[cell.ColumnIndex].Name;

            switch (keyData)
            {
                case Keys.F2:
                    {
                    }
                break;
            }

            if (datoNvo != "")
            { 
                cell.Value = datoNvo;
                keyData = Keys.Return;
            }
            return true;
        }
        public DataTable leerTablas(string ssql, string strConeccion)
        {

            // devuelve una tabla con los datos leidos

            SqlDataAdapter da;
            DataTable dt = new DataTable();
            try
            {
                da = new SqlDataAdapter(ssql, strConeccion);
                da.Fill(dt);
            }
            catch
            {
                return null;
            }
            return dt;
        }

        private double nroTiket(string codArticulo)
        {
            if (codArticulo  == "") {return 0;}
            
            double Ultimo = PonerNumeroTicket(codArticulo);
            double auxiliar = 0;
            
            foreach (DataGridViewRow row in malla.Rows )
            {
                try
                {
                    auxiliar = Convert.ToDouble("0" + row.Cells["CodBarrasEAN13"].ToString());
                }
                catch 
                { 
                    auxiliar = 0;
                }
                if ( auxiliar > Ultimo)
                {
                    Ultimo = auxiliar + 1;
                }
            }
            return Ultimo;
        }
        private double PonerNumeroTicket(string codArticulo)
        {
            double numeroTiket=0;
            DataTable Rs = new DataTable ();
            string Aux = "Select max(ISNULL(TIK_NUMERO,0)) AS TiketMayor from adctik";
            Rs = leerTablas(Aux,datosEmpresa.strConxAdcom);   
            if (Rs.Rows.Count == 0) {numeroTiket = 1;}
            else 
            {
                Aux = Rs.Rows[0]["tiketmayor"].ToString();
                if(Aux.Length > 12 ){Aux = Aux.Substring(0,12);}
                numeroTiket = Convert.ToDouble("0" + Aux) + 1;
            }
            Rs.Dispose();
            return numeroTiket ;
        }
        private void btnContinuar_Click(object sender, EventArgs e)
        {
            malla.EndEdit();
            foreach (DataGridViewRow dtgr in malla.Rows)
            {
                Int64 nuevoCodigo=0;
                try{nuevoCodigo =Convert.ToInt64 (dtgr.Cells["TIK_NUMERO"].Value); }catch{nuevoCodigo=0;}
                if (nuevoCodigo > 0)
                {
                    bool existe = false;
                    foreach (DataRow Drow in datos.Rows)
                    {
                        if (Convert.ToInt64("0"+Drow["TIK_NUMERO"]) == nuevoCodigo) existe = true;
                    }
                    if (existe == false)
                    {
                        DataRow row = datos.NewRow();
                        row["TIK_COLOR"] = "";
                        row["TIK_TALLA"] = "";
                        row["TIK_ARTCODI"] = codigoBase;

                        row["TIK_SERIE"] = "";
                        row["TIK_ALTERNO"] = "";

                        row["TIK_NUMERO"] = nuevoCodigo;
                        datos.Rows.Add(row);
                    }
                }
            }
            Close();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            datos.Rows.Clear();
            malla.CurrentCell = malla.Rows[0].Cells[0];                        
        }

        private void malla_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            malla.Rows[e.RowIndex].Cells["TIK_ARTCODI"].Value = codigoBase;
        }

        private void malla_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("El código digitado esta errado");
        }
    }
}
