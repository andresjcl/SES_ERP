using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace GessDax
{
    static class sb_util
    {

        static public string armarSelectConsulta(string txtFechaDel, string txtFechaAl, string GessConsulta,ListBox camposSeleccionados,ref string SSqlorder)
        {
            string SSqlSelect = "Select ";
            string SSqlgroup = " group by ";            
            string coma = "";
            string comagrupa = "";
            string comaorder = "";
            string SSqlwhere = "";
            string comawhere = "";
            ///// chequearTotVta();
            //Boolean ConSubtotal = (dgSubtotales.Items.Count > 0);


            //armar agrupacion
            //if (ConSubtotal == false)
            //{

            foreach (sb_columna column in sb_datosMalla.columnas)
            {
                    if (column.agrupar == true && column.tipoDato != "DEC")
                    {
                        SSqlgroup += comagrupa + "[" + column.nombreCol  + "]";
                        comagrupa = ",";
                    }
            }
             
            // armar el select sin subtotales

            //foreach (sb_columna column in sb_datosMalla.columnas)
                for (Int32 i = 0; i < camposSeleccionados.Items.Count;i++)
                {
                    sb_columna column = sb_datosMalla.columna(camposSeleccionados.Items[i].ToString());
                    if (comagrupa == "" || column.agrupar == true)
                    {
                        SSqlSelect += coma + "[" + column.nombreCol + "]";
                        coma = ",";
                    }
                    else
                    {
                        if (column.tipoDato == "DEC" && column.sumar == true)
                        {
                            SSqlSelect += coma + "sum([" + column.nombreCol + "]) as [" + column.nombreCol + "]";
                            coma = ",";
                        }
                        else
                        {
                            SSqlSelect += coma + "'' as [" + column.nombreCol + "]"; //"max([" + campos[i].Text + "]) as [" + campos[i].Text + "]";
                            coma = ",";
                        }
                    }
                }

            SSqlwhere = " where (fecha >= '" + txtFechaDel + "' and fecha <= '" + txtFechaAl + "') ";

            agregarFiltros(ref SSqlwhere, ref comawhere);
            agregarOrdenamiento(ref SSqlorder, ref comaorder);

            if (comagrupa == "") SSqlgroup = "";
            SSqlSelect += " from " + GessConsulta;
            SSqlSelect += SSqlwhere + SSqlgroup;
            return SSqlSelect;
        }
        static private void agregarFiltros(ref string SSqlw, ref string comaw)
        {
            comaw = " and ";
            foreach (sb_columna column in sb_datosMalla.columnas)
            {
                if (column.filtros[0].Trim() != "" & column.filtros[1].Trim() != "" & column.filtros[2].Trim() != "")
                {
                    if (column.filtros[1] == "PARECIDO A")
                    {
                        if (column.tipoDato != "DEC")
                        {
                            SSqlw += comaw + "([" + column.filtros[0] + "] like '%" + column.filtros[2] + "%') ";
                        }
                        else
                        {
                            SSqlw += comaw + "([" + column.filtros[0] + "] like %" + column.filtros[2] + "%) ";
                        }
                    }
                    else
                    {
                        if (column.tipoDato != "DEC")
                        {
                            SSqlw += comaw + "([" + column.filtros[0] + "] " + column.filtros[1] + " '" + column.filtros[2] + "') ";
                        }
                        else
                        {
                            SSqlw += comaw + "([" + column.filtros[0] + "] " + column.filtros[1] + " " + column.filtros[2] + ") ";
                        }
                    }
                    comaw = " and ";
                }
            }
        }

        static private void agregarOrdenamiento(ref string SSqlo, ref string comao)
        {
            Int32 NroCampos = sb_datosMalla.columnas.Count;
            string[] tablaSort = new string[NroCampos];
            Int32 posicionOrden = 0;
            for (int i = 0; i < NroCampos; i++)
            {
                tablaSort[i] = "";
            }

            SSqlo = "";
            comao = " order by ";
            foreach (sb_columna column in sb_datosMalla.columnas)
            {
                int i = 0;
                if (column.clavesOrden != "" && column.clavesOrden != null)
                {
                    string nombre = "[" + column.nombreCol + "] ";
                    if (nombre == "[MES] ")
                    {
                        nombre = " case UPPER(MES) ";
                        nombre += " when 'ENERO' THEN 1 ";
                        nombre += " WHEN 'FEBRERO' THEN 2";
                        nombre += " WHEN 'MARZO' THEN 3";
                        nombre += " WHEN 'ABRIL' THEN 4";
                        nombre += " WHEN 'MAYO' THEN 5";
                        nombre += " WHEN 'JUNIO' THEN 6";
                        nombre += " WHEN 'JULIO' THEN 7";
                        nombre += " WHEN 'AGOSTO' THEN 8";
                        nombre += " WHEN 'SEPTIEMBRE' THEN 9";
                        nombre += " WHEN 'OCTUBRE' THEN 10";
                        nombre += " WHEN 'NOVIEMBRE' THEN 11";
                        nombre += " WHEN 'DICIEMBRE' THEN 12";
                        nombre += " END ";
                    }

                    if (nombre == "[NomDia] ")
                    {
                        nombre = " case UPPER(NomDia) ";
                        nombre += " when 'LUNES' THEN 1 ";
                        nombre += " WHEN 'MARTES' THEN 2";
                        nombre += " WHEN 'MIERCOLES' THEN 3";
                        nombre += " WHEN 'MIÉRCOLES' THEN 3";
                        nombre += " WHEN 'JUEVES' THEN 4";
                        nombre += " WHEN 'VIERNES' THEN 5";
                        nombre += " WHEN 'SABADO' THEN 6";
                        nombre += " WHEN 'SÁBADO' THEN 6";
                        nombre += " WHEN 'DOMINGO' THEN 7";
                        nombre += " END ";
                    }
                    i++;
                    if (column.secuenciaOrden > 0) { posicionOrden = column.secuenciaOrden; } else { posicionOrden = i; }
                    tablaSort[posicionOrden] = nombre + column.clavesOrden;
                }
            }
            for (int i = 0; i < NroCampos; i++)
            {
                if (tablaSort[i] != "")
                {
                    SSqlo += comao + tablaSort[i] + " ";
                    comao = ", ";
                }
            }
        }
    }
}
