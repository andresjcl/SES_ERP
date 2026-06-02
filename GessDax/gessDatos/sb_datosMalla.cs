using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace GessDax
{
    public static class sb_datosMalla
    {
        static public List<sb_columna> columnas = new List<sb_columna>();
        static public string nombre;

        static public void delete(Int32 ind)
        {
            columnas.RemoveAt(ind);
        }

        static public sb_columna columna(string nombre)
        {            
            foreach (sb_columna column in columnas)
            {
                if (nombre.ToUpper() == column.nombreCol.ToUpper()) return column;
            }            
            return null;
        }
        static public sb_columna columna(Int32 indice)
        {
            return columnas[indice];
        }
        static public Int32 cargarDatosReporte(string nomReport)
        {
            if (nomReport == "") return 0;
            Int16 tipoGess = 0;
            string ssql = "select * from [sysdxgess] ";
            ssql += " WHERE reporte = '" + nomReport + "'  order by orden";
            SqlDataAdapter misqlDa = new SqlDataAdapter(ssql, SysEmpDatt.datosEmpresa.strConxAdcom);
            DataTable DatosLista = new DataTable();
            misqlDa.Fill(DatosLista);

            if (DatosLista.Columns.Count == 0) { MessageBox.Show("No se pudo cargar el reporte" + nombre); return 0; }
            sb_datosMalla.columnas.Clear();
            sb_datosMalla.nombre = nomReport;
            try
            {
                tipoGess = Convert.ToInt16(DatosLista.Rows[0]["TipoGess"].ToString());
            }
            catch { }
            foreach  (DataRow row in DatosLista.Rows)
            {
                sb_columna column = new sb_columna();                
                column.nombreCol = row["nomCampo"].ToString();
                column.tipoDato = row["tipo"].ToString();
                column.agrupar = Convert.ToBoolean(row["agrupado"]);
                column.sumar = Convert.ToBoolean(row["sumar"]);
                column.anchoCol = Convert.ToInt32(row["ancho"]);
                column.ordenVertical = Convert.ToInt32(row["orden"]);
                column.subtotal = Convert.ToBoolean(row["subtotal"]);
                column.clavesOrden = row["Ordenar"].ToString();
                column.secuenciaOrden = Convert.ToInt32(row["secuenciaOrden"].ToString());
                if (row["operador"].ToString() != "" & row["valorcompara"].ToString() != "")
                {
                    column.filtros[0] = row["nomCampo"].ToString();
                    column.filtros[1] = row["operador"].ToString();
                    column.filtros[2] = row["valorcompara"].ToString();
                }
                try
                {
                    column.merge = Convert.ToBoolean(row["mergge"]);
                }
                catch { column.merge = false; }
                sb_datosMalla.columnas.Add(column);
            }
            return tipoGess;
        }
        static public void reorganizarDatosEscojidos(ListBox listaDatos,string[] tipoDato,ListBox datosDisponibles)
        {
            // eliminar datos que estan en coleccion y no en lista
            bool elimina = true;
            do{
            elimina = false;
            foreach (sb_columna colum in sb_datosMalla.columnas)
            {
                if (datoEnLista(colum.nombreCol, listaDatos) == false)
                {
                    sb_datosMalla.columnas.Remove(colum);
                    elimina = true;
                    break ;
                }
            }
            }while (elimina==true);

            //aumentar datos que estan en lista y no en la coleccion 
            for (int i = 0; i < listaDatos.Items.Count; i++)
            {
                if (datoEnColeccion(listaDatos.Items[i].ToString()) == false)
                {
                    Int32 ind = indiceDisponibles(listaDatos.Items[i].ToString(),datosDisponibles);
                    sb_columna sbcolumna = new sb_columna();
                    sbcolumna.tipoDato = tipoDato[ind];
                    sbcolumna.nombreCol = listaDatos.Items[i].ToString();
                    sb_datosMalla.columnas.Add(sbcolumna);
                }
            }
        }
        static public void cargarDatosAlista(ListBox listaDatos)
        {
            listaDatos.Items.Clear();
            foreach (sb_columna column in columnas)
            {
                listaDatos.Items.Add(column.nombreCol);
            }
        }
        static private Boolean datoEnLista(string nombreCol,ListBox listaCampos)
        {
            for (int i = 0; i < listaCampos.Items.Count; i++)
            {
                if (nombreCol == listaCampos.Items[i].ToString()) return true;
            }
            return false;
        }
        static private Boolean datoEnColeccion(string nombreCol)
        {
            for (int i = 0; i < sb_datosMalla.columnas.Count; i++)
            {
                if (nombreCol == sb_datosMalla.columnas[i].nombreCol) return true;
            }
            return false;
        }
        static private Int32 indiceDisponibles(string nombre,ListBox datosDisponibles)
        {
            for (Int32 i = 0; i < datosDisponibles.Items.Count; i++)
            {
                if (datosDisponibles.Items[i].ToString() == nombre) return i;
            }
            return -1;
        }

    }
    public class sb_columna 
    {                
        public string[] filtros = new string[5] {"","","","",""};
        public string tipoDato = "";
        public int anchoCol = 100;
        public int ordenVertical = 0;
        public int secuenciaOrden = 0;
        public string clavesOrden = "";
        public Boolean agrupar = false;
        public Boolean sumar = false;
        public Boolean subtotal = false;
        public string nombreCol ="";
        public string formato = "";
        public string valorFijo = "";
        public int numeroCaracteres = 0;
        public Boolean merge = false;

    }
}
