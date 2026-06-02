using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;
namespace disMallFlor
{
    static public class diseñoMallaFlor
    {
       public static void colorCaja(DataGridView malla)
        {
            string cajAnt = "";
            Color elColor = Color.White;
            
            
           foreach (DataGridViewRow row in malla.Rows)
           {
               if(cajAnt != row.Cells ["TipCaja"].Value.ToString())
               {
                   if (elColor == Color.White) elColor = Color.LightYellow; else elColor = Color.White;
                   row.DefaultCellStyle.BackColor =  elColor;
               }
           }

        }
       public static void colorPedidos(DataGridView malla)
       {
           string cajAnt = "";
           Color elColor = Color.White;


           foreach (DataGridViewRow row in malla.Rows)
           {
               if (cajAnt != row.Cells["Tipo"].Value.ToString())
               {
                   if (elColor == Color.White) elColor = Color.LightYellow; else elColor = Color.White;
                   row.DefaultCellStyle.BackColor = elColor;
               }
           }
       }

    }
}
