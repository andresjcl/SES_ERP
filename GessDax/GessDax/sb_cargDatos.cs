using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms ;
using System.Drawing;


namespace GessDax
{
    class sb_cargDatos
    {        
        public void CargarDatosDisponibles( string GessConsulta,string strconeccion,ref ListBox camposSeleccion,ref string[] tipoDato)
        {                        
            DataTable Data = consultarDato("select top 1 * from " + GessConsulta, strconeccion);
            Int32 NroCampos = Data.Columns.Count;
            camposSeleccion.Items.Clear();
            if ( NroCampos > 0)
            {
                tipoDato = new string[NroCampos];
                
                for (int i = 0; i < NroCampos; ++i)
                {
                    camposSeleccion.Items.Add(Data.Columns[i].ColumnName);
                    tipoDato[i] = Data.Columns[i].DataType.Name.Substring(0, 3).ToUpper();
                }
            }
        }

        public void leerDatosaGrid(string Comando, string strconx, String Ordenar, ref DataGridView lista, ref DataTable Data)
        {
            lista.Columns.Clear();
            lista.DataSource = null;
            if (Ordenar.Length > 0) Comando = "select * from (" + Comando + ") r1 " + Ordenar;
            try
            {
               Data = consultarDato(Comando,strconx);
               lista.DataSource = Data;
            }
            catch (Exception ex)
            { MessageBox.Show("No se puede accesar a los datos \n" + ex.Message); return; }
            // label3.Text = "Cantidad de Registros: " + lista.RowCount.ToString();
            //lista.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            foreach (DataGridViewColumn dColumn in lista.Columns)
            {
                {
                    try
                    {
                        dColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
                        if (sb_datosMalla.columna(dColumn.Name).anchoCol != 0) { dColumn.Width = sb_datosMalla.columna(dColumn.Name).anchoCol; };

                        //{ dColumn.DisplayIndex = sb_datosMalla.columna(dColumn.Name).ordenVertical; };

                        if (sb_datosMalla.columna(dColumn.Name).tipoDato == "DEC")
                        {
                            dColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dColumn.DefaultCellStyle.Format = "###,###,##0.00";
                        }
                        if (sb_datosMalla.columna(dColumn.Name).tipoDato == "DAT")
                        {
                            dColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            dColumn.DefaultCellStyle.Format = "dd/MMM/yyyy";
                        }
                    }
                    catch { }
                }
            }
        }

        public DataTable consultarDato(String consulta, string strconeccion)
        {
            DataTable Data = new DataTable();            
            try
            {
                using (SqlDataAdapter misqlDa = new SqlDataAdapter("set dateformat dmy;" + consulta, strconeccion))
                {
                    misqlDa.Fill(Data);
                }
            }
            catch 
            {
            }
            return Data;
        }
    }
}
