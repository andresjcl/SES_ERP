using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SysEmpDatt;
namespace DaxInvent
{
    class MallaSaldosBodegas
    {
        static internal void CargarMalla(DataGridView malla, string  Bodega,DateTime FechaFin,Boolean ordenAlfabetico)
        {
            string articuloini = "";
            string articulofin = "";
            string TxtSuc = "";
            string SUMAR = "";
            string QueSaldo = " where tra_fecha <= '" + FechaFin.ToShortDateString() + "' ";
            string sSQL = "Select bod_codigo from emp_bod where emp_codigo = " + datosEmpresa.codEmpresa;
            if (Bodega != "" && Bodega != "0")
            {
                sSQL += " and bod_codigo = '" + Bodega + "' ";
            }                   
            sSQL += " group by bod_codigo ";

            using (SqlDataAdapter da = new SqlDataAdapter(sSQL, datosEmpresa.strConxSyscod))
            {
                DataTable rs = new DataTable();
                da.Fill(rs);
                if (rs.Rows.Count == 0)
                {
                    MessageBox.Show("No existen datos para imprimir en este período");
                    rs.Dispose(); return;
                }

                string Coma =  "";
                string Mas = "";
                foreach (DataRow row in rs.Rows)
                {
                     TxtSuc += Coma + " SUM(CASE bodega WHEN '" + row["Bod_Codigo"] + "' THEN CANTIDAD ELSE 0 END) AS [" + row["Bod_Codigo"] + "] ";
                     SUMAR = SUMAR + Mas + " r1.[" + row["Bod_Codigo"] + "] ";
                     Mas = " + ";
                     Coma = " ,";
                }

                rs.Dispose();
            }

            sSQL = "DaxInvSaldBod '" + FechaFin.ToShortDateString() + "','" + Bodega + "','" + articuloini + "','" + articulofin + "',2";

            using (SqlConnection conn = new SqlConnection (datosEmpresa.strConxAdcom))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(sSQL, conn);
                comm.ExecuteNonQuery();
                comm.Dispose();
            }
     
            sSQL = "SELECT AdcArt.Art_categor as CAT, AdcArt.Art_nombre AS Descripción, R1.*, " + SUMAR + " AS TOTAL ";
            sSQL += " FROM AdcArt right OUTER JOIN" ;
            sSQL += " (SELECT Articulo, " + TxtSuc;
            sSQL += " FROM tmpSaldoBode AS R ";
            sSQL += " GROUP BY ARTICULO) R1 ON AdcArt.Art_codigo = R1.ARTICULO ";
            if (ordenAlfabetico) 
            {
                sSQL += " order by adcart.art_nombre";
            }
            else
            {
                sSQL += " order by r1.articulo ";
            }
            
            using (SqlDataAdapter da = new SqlDataAdapter(sSQL, datosEmpresa.strConxAdcom))
            {
                DataTable rs = new DataTable();
                da.Fill(rs);
                malla.DataSource = rs;
            }

        }
        static internal void DiseñaMalla(DataGridView malla)
        {
                foreach (DataGridViewColumn colmn in malla.Columns)
                {
                    if (colmn.Name == "CAT")
                    {
                        colmn.Width = 40;
                        colmn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    }
                    else if (colmn.Name == "Articulo")
                    {
                        colmn.Width = 110;
                        colmn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    }
                    else if (colmn.Name == "Descripción")
                    {
                        colmn.Width = 290;
                        colmn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    }
                    else
                    {
                        colmn.Width = 80;
                    }
                }
        }

        static internal void SumatoriaMalla(DataGridView malla)
        {
            malla.Rows.Add();
            DataGridViewRow rowTot = malla.Rows[malla.Rows.Count - 1];
            foreach (DataGridViewColumn column in malla.Columns)
            {
                if (column.ValueType == Type.GetType("System.Decimal"))
                {
                    Decimal totalColumna = 0;
                    Int32 ind = 0;
                    foreach (DataGridViewRow row in malla.Rows)
                    {
                        totalColumna += Convert.ToDecimal(row.Cells[ind].Value);
                    }
                    rowTot.Cells[column.Index].Value = totalColumna;
                }
            }
            malla.Rows[malla.Rows.Count - 1].HeaderCell.ToolTipText = "Total";
        }
        static internal void SumatoriaMallaDat(DataGridView malla)
        {
            DataTable data = (DataTable)malla.DataSource;
            DataRow rowTot = data.NewRow();
            foreach (DataColumn column in data.Columns)
            {
                if (column.DataType == Type.GetType("System.Decimal"))
                {
                    Decimal totalColumna = 0;
                    Int32 ind = column.Ordinal;
                    foreach (DataRow row in data.Rows)
                    {
                        totalColumna += Convert.ToDecimal(row[ind]);
                    }
                    rowTot[ind] = totalColumna;
                }
            }
            data.Rows.Add(rowTot);
            malla.Rows[malla.Rows.Count - 1].HeaderCell.ToolTipText = "Total";
        }

    }
}
