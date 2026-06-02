using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DaxGesvta
{
    class sb_datosMalla
    {
        public List<sb_columna> columnas = new List<sb_columna>();
        
        public void add (sb_columna column)
        {
            columnas.Add(column);
        }
        public sb_columna columna(string nombre)
        {
            foreach (sb_columna column in columnas)
            {
                if (nombre.ToUpper() == column.nombreCol.ToUpper()) return column;
            }            
            return null;
        }
        public sb_columna columna(Int32 indice)
        {
            return columnas[indice];
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
    }
}
