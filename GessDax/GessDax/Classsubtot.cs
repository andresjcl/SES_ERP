using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;
using System.Data;

namespace DaxGesvta
{
    public class Classsubtot
    {
        public string armarSelectSubtotales(ref CheckedListBox  campos2, Boolean [] sumar,ref ListBox subtotal, string [] tipoDato, string basedat,string filtro)
        {
            string coma = ",";
            string comac = "";
            string cabecera = "";
            string SSqlSelect = "SELECT '0' AS TOT";
            string selectsub1 = "";
            string selectsub2 = "";
            string selectsub3 = "";
            Int32 countCampos = campos2.Items.Count;
            string[] campoSub = new string[4];
            int j = 0;
            campoSub[1] = "";
            campoSub[2] = "";
            campoSub[3] = "";

            for (int i = 0; i < subtotal.Items.Count; i++)
            {
                { j++; campoSub[j] = subtotal.Items[i].ToString(); }
            }
            if (j == 0) return "";
            // armar el select
            if (campoSub[1].Length > 0) selectsub1 = "select '1' AS TOT";
            if (campoSub[2].Length > 0) selectsub2 = "select '2' AS TOT";
            if (campoSub[3].Length > 0) selectsub3 = "select '3' AS TOT";

            foreach (int i in campos2.CheckedIndices)
            {
                string itemChecked = campos2.Items[i].ToString() ;
                
                
                // armo select normal CAMBIANDO NOMBRE CON +"z" DE CAMPOS DE SUBTOTAL
                if (itemChecked == campoSub[1] | itemChecked == campoSub[2] | itemChecked == campoSub[3])
                { SSqlSelect += coma + "isnull([" + itemChecked + "],'') AS " + "[" + itemChecked + "Z]"; }
                else
                { SSqlSelect += coma + "isnull([" + itemChecked + "],'') as " + "[" + itemChecked + "]"; }

                
                // armo select cabezera poniendo totales y marcas y quitando la z
                if (itemChecked == campoSub[1] | itemChecked == campoSub[2] | itemChecked == campoSub[3] )
                {
                    if (itemChecked == campoSub[1] )
                    {
                        cabecera += comac + "CASE TOT ";
                        cabecera += "WHEN '1' THEN 'Total: ' + substring([" + campoSub[1] + "Z],1,len([" + campoSub[1] + "Z]) - 1 ) ";
                        cabecera += "when '2' then '' ";
                        cabecera += "when '3' then '' ";
                        cabecera += "ELSE [" + campoSub[1] + "Z] END AS [" + campoSub[1] + "] ";
                    }
                    if (itemChecked == campoSub[2] )
                    {
                        cabecera += comac + "CASE TOT ";
                        cabecera += "when '1' then '' ";
                        cabecera += "WHEN '2' THEN 'Total: ' + substring([" + campoSub[2] + "Z],1,len([" + campoSub[2] + "Z]) - 1 ) ";
                        cabecera += "when '3' then '' ";
                        cabecera += "ELSE [" + campoSub[2] + "Z] END AS [" + campoSub[2] + "] ";
                    }
                    if (itemChecked == campoSub[3] )
                    {
                        cabecera += comac + "CASE TOT ";
                        cabecera += "when '1' then '' ";
                        cabecera += "when '2' then '' ";
                        cabecera += "WHEN '3' THEN 'Total: ' + substring([" + campoSub[3] + "Z],1,len([" + campoSub[3] + "Z]) - 1 ) ";
                        cabecera += "ELSE [" + campoSub[3] + "Z] END AS [" + campoSub[3] + "] ";
                    }
                }
                else
                { cabecera += comac + "[" + itemChecked + "] "; }

                comac = ",";
                
                // armo select SUBTOTAL1
                if (campoSub[1].Length > 0)
                {
                    if (itemChecked == campoSub[1])
                    { selectsub1 += coma + "[" + itemChecked + "] + 'Z' AS " + "[" + itemChecked + "] "; }
                    else
                    {
                        if (tipoDato[i] == "DEC" & sumar[i] == true)
                        {
                            selectsub1 += coma + "sum([" + itemChecked + "]) as [" + itemChecked + "]";
                        }
                        else
                        {
                            selectsub1 += coma + "'' as [" + itemChecked + "]";
                        }
                    }
                }

                // armo select SUBTOTAL2
                if (campoSub[2].Length > 0)
                {
                    if (itemChecked == campoSub[1])
                    { selectsub2 += coma + "[" + itemChecked + "] "; }
                    else
                    {
                        if (itemChecked == campoSub[2])
                        { selectsub2 += coma + "[" + itemChecked + "] + 'Z' AS " + "[" + itemChecked + "] "; }
                        else
                        {
                            if (tipoDato[i] == "DEC" & sumar[i] == true)
                            {
                                selectsub2 += coma + "sum([" + itemChecked + "]) as [" + itemChecked + "]";
                            }
                            else
                            {
                                selectsub2 += coma + "'' as [" + itemChecked + "]";
                            }
                        }
                    }
                }

                // armo select SUBTOTAL3
                if (campoSub[3].Length > 0)
                {
                    selectsub3 = "select '3' AS TOT";
                    if (itemChecked == campoSub[1] | itemChecked == campoSub[2])
                    { selectsub3 += coma + "[" + itemChecked + "] "; }
                    else
                    {
                        if (itemChecked == campoSub[3])
                        { selectsub3 += coma + "[" + itemChecked + "] + 'Z' AS " + "[" + itemChecked + "] "; }
                        else
                        {
                            if (tipoDato[i] == "DEC" & sumar[i] == true)
                            {
                                selectsub3 += coma + "sum([" + itemChecked + "]) as [" + itemChecked + "]";
                            }
                            else
                            {
                                selectsub3 += coma + "'' as [" + itemChecked + "]";
                            }
                        }
                    }
                }                
            }
            cabecera = "select tot," + cabecera + " from (";
            SSqlSelect = cabecera + SSqlSelect + " from " + basedat + filtro;
            if (selectsub1 != "") SSqlSelect += " union all " + selectsub1 + " from " + basedat + filtro + " group by [" + campoSub[1] + "] + 'Z' ";
            if (selectsub2 != "") SSqlSelect += " union all " + selectsub2 + " from " + basedat + filtro + " group by [" + campoSub[1] + "],[" + campoSub[2] + "] + 'Z' ";
            if (selectsub3 != "") SSqlSelect += " union all " + selectsub3 + " from " + basedat + filtro + " group by [" + campoSub[1] + "],[" + campoSub[2] + "],[" + campoSub[2] + "] + 'Z' ";
            SSqlSelect += ") r1 ";

            SSqlSelect += "order by [" + campoSub[1] + "Z]";
            if (campoSub[2].Length > 0) SSqlSelect += ", [" + campoSub[2] + "Z]";
            if (campoSub[3].Length > 0) SSqlSelect += ", [" + campoSub[3] + "Z]";

                return SSqlSelect;
        }
        public void formatoSubtotales(ref DataGridView lista)
        {
            try
            {
                foreach (DataGridViewRow linea in lista.Rows)
                {
                    if (linea.Cells["TOT"].Value.ToString() == "1")
                    {
                        linea.DefaultCellStyle.BackColor = Color.Brown;
                        linea.DefaultCellStyle.ForeColor = Color.White;
                        //                    lista.Rows.Insert(linea.Index, 1);
                    }
                    if (linea.Cells["TOT"].Value.ToString() == "2")
                    {
                        linea.DefaultCellStyle.BackColor = Color.CadetBlue;
                    }

                    if (linea.Cells["TOT"].Value.ToString() == "3")
                    {
                        linea.DefaultCellStyle.BackColor = Color.Chocolate;
                    }

                }
                lista.Columns.RemoveAt(lista.Columns["TOT"].Index);

            }
            catch(Exception  e)
            {
                MessageBox.Show("Excepcion: " + e.Message );
            } 
        }
        public void CalcularSubtotales(ref DataTable lista, ref CheckedListBox campos2, Boolean[] sumar, ref ListBox subtotal, string[] tipoDato)
        {
            foreach (DataRow Linea in lista.Rows)
            {

            
            
            
            
            }
        }

    }
}
