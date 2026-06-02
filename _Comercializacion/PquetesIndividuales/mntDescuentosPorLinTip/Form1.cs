using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient ;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        string strAdcConxadcom="";
        string tipoCuenta = "Malla de descuentos";
        public Form1()
        {
            InitializeComponent();
            DaxLib.DaxLibBases lib = new DaxLib.DaxLibBases();
            lib.TipoBase = "10";
            strAdcConxadcom = lib.StrAdcom();           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnOpciones_Click(object sender, EventArgs e)
        {
            malla.Columns.Clear();
            string ssql = "select abreviación,Descripcion from syscod where tipoReferencia = 'TipoCliente' and abreviación <> '#'";  
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(ssql, strAdcConxadcom);
            da.Fill(dt);
            foreach (DataRow row in dt.Rows) 
            {
                malla.Columns.Add(row["abreviación"].ToString(), row["Descripcion"].ToString());
            }
            dt.Dispose();

            ssql = "select niv_abrevia,niv_nombre from adcniv where niv_categor = 1";

            dt = new DataTable();
            da = new SqlDataAdapter(ssql, strAdcConxadcom);
            da.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                DataGridViewRow vr = new DataGridViewRow ();
                vr.HeaderCell.Value = row["niv_abrevia"].ToString();
                vr.HeaderCell.ToolTipText = row["niv_nombre"].ToString();
                malla.Rows.Add(vr);
            }
            leerDatos();
        }
        private void leerDatos()
        {
            //foreach (DataGridViewRow row in malla.Rows)
            //{
            //    for (int i = 0; i < malla.Columns.Count; i++)
            //    {
                    string ssql = "select * from adcDesTipPro ";  //where tipoCliente = '" + malla.Columns[i].Name  + "' and tipoProducto = '" + row.HeaderCell.Value  + "'";   //"select * from adcDesTipPro"
                    SqlConnection con = new SqlConnection(strAdcConxadcom);
                    con.Open();
                    SqlCommand comm = new SqlCommand(ssql,con);
                    SqlDataReader dr;
                    dr = comm.ExecuteReader();
                    while (dr.Read() )
                    {
                        Int32 col = queColumna(dr["tipoCliente"].ToString());
                        Int32 lin = queFila(dr["tipoProducto"].ToString(),col); 
                        malla.Rows[lin].Cells[col].Value = dr["porcentajeDescuento"].ToString();
                    }
                    //DataTable dt = new DataTable();
                    //SqlDataAdapter da = new SqlDataAdapter(ssql, strAdcConxadcom);
                    //da.Fill(dt);
                    //if (dt.Rows.Count > 0)
                    //{
                    //    malla.Rows[row.Index].Cells[i].Value = dt.Rows[0]["porcentajeDescuento"];
                    //}
            //    }            
            //}        
        }
        private Int32 queColumna(string valor)
        {

            for (int i = 0; i < malla.Columns.Count; i++)
            {
                    if (malla.Columns[i].Name == valor) return i;
            }
            return 0;        
        }
        private Int32 queFila(string valor, Int32 col)
        {
            for (int i = 0; i < malla.Rows.Count; i++)
            {
                if (malla.Rows[i].HeaderCell.Value.ToString() == valor) return i;
            }
            return 0;        
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            GuardarDatos();
        }
        private void GuardarDatos()
        {
            string ssql = "delete from adcDesTipPro ";
            SqlConnection con = new SqlConnection (strAdcConxadcom);
            con.Open();
            SqlCommand comm = new SqlCommand(ssql, con);
            comm.ExecuteNonQuery();

            foreach (DataGridViewRow row in malla.Rows)
            {
                for (int i = 0; i < malla.Columns.Count; i++)
                {
                    if (Convert.ToDouble("0" + row.Cells[i].Value) > 0)
                    {
                        ssql = "INSERT INTO [AdcDesTippro](";
                        ssql += "[tipoCliente]";
                        ssql += ",[tipoProducto]";
                        ssql += ",[porcentajeDescuento])";
                        ssql += " VALUES (";
                        ssql += "'" + malla.Columns[i].Name + "',";
                        ssql += "'" + row.HeaderCell.Value + "',";
                        ssql += "" + Convert.ToDouble("0" + row.Cells[i].Value) + ")";
                        comm = new SqlCommand(ssql, con);
                        comm.ExecuteNonQuery();
                    }
                }
            }
            con.Close();
            con.Dispose();
            comm.Dispose();
        }

        private void ImprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewPrinterApplication1.frmMain imp = new DataGridViewPrinterApplication1.frmMain();
            string tit2 = "";
            imp.imprimir(malla, tipoCuenta, tit2, "");
        }

        private void WordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportarGrid.Form1 exp = new ExportarGrid.Form1();
            exp.Exportar(malla, "W", "", tipoCuenta);
        }

        private void ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportarGrid.Form1 exp = new ExportarGrid.Form1();
            exp.Exportar(malla, "E", "", tipoCuenta);
        }

        private void PDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportarGrid.Form1 exp = new ExportarGrid.Form1();
            exp.Exportar(malla, "P", "", tipoCuenta);
        }
    }
}
