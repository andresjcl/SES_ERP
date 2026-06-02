using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

namespace daxSri104
{
    static internal class calcValor
    {
        static string formato="#.00";
        internal static void calculos400(frmDax104 frm,double tarifaIva)
        {
            double total2 = 0;
            double total4 = 0;
            double total6 = 0;
            double totalFac = 0;
            
            for (int i = 0; i < 9; i++)
            {
                DataGridViewRow row = frm.malla400.Rows[i];
                total2 += val(row.Cells[2].Value);
                total4 += val(row.Cells[4].Value);
                total6 += val(row.Cells[6].Value);
                if (i < 2 || i > 4)
                {
                    totalFac += val(row.Cells[4].Value);
                }
            }
            frm.malla400.Rows[9].Cells[2].Value = total2.ToString(formato);
            frm.malla400.Rows[9].Cells[4].Value = total4.ToString(formato);
            frm.malla400.Rows[9].Cells[6].Value = total6.ToString(formato);
            frm.txt482.Text =total6.ToString(formato);
            
            if (total4 != 0) frm.malla500.Rows[16].Cells[6].Value = (totalFac / total4).ToString(formato) ;
            
            if(frm.Txt480.Text == total4.ToString(formato))
                {frm.txt484.Text = frm.txt482.Text;}
            else
                {frm.txt484.Text= (val(frm.Txt480.Text) * tarifaIva/100 ).ToString(formato);}
            frm.txt485.Text = (val(frm.txt482.Text) - val(frm.txt484.Text)).ToString(formato);
			
            frm.txt499.Text = (val(frm.txt483.Text) + val(frm.txt484.Text)).ToString(formato);
        }
        internal static void calculos500( frmDax104 frm)
        {
            double total2 = 0;
            double total4 = 0;
            double total6 = 0;
            double totalfac=0;
            for (int i = 0; i < 10; i++)
            {
                DataGridViewRow row = frm.malla500.Rows[i];
                total2 += val(row.Cells[2].Value);
                total4 += val(row.Cells[4].Value);
                total6 += val(row.Cells[6].Value);
                if (i<6&&i!=2) totalfac += val(row.Cells[6].Value);

            }
            frm.malla500.Rows[10].Cells[2].Value = total2.ToString(formato);
            frm.malla500.Rows[10].Cells[4].Value = total4.ToString(formato);
            frm.malla500.Rows[10].Cells[6].Value = total6.ToString(formato);

            frm.malla500.Rows[17].Cells[6].Value = (totalfac * val(frm.malla500.Rows[16].Cells[6].Value)).ToString(formato);

            frm.txt499.Text = (val(frm.txt483.Text) + val(frm.txt484.Text)).ToString(formato);
        }
        internal static void calculos600(frmDax104 frm)
        {
            double impCausado = val(frm.txt499.Text)-val(frm.malla500.Rows[17].Cells[6].Value);
            if (impCausado > 0) { frm.malla600.Rows[0].Cells[2].Value = impCausado.ToString(formato); }
            else { frm.malla600.Rows[1].Cells[2].Value = (impCausado*-1).ToString(formato);}

            double subTotPaga = val(frm.malla600.Rows[0].Cells[2].Value) - val(frm.malla600.Rows[1].Cells[2].Value) - val(frm.malla600.Rows[2].Cells[2].Value)-val(frm.malla600.Rows[3].Cells[2].Value);
            subTotPaga += -val(frm.malla600.Rows[4].Cells[2].Value) - val(frm.malla600.Rows[5].Cells[2].Value) - val(frm.malla600.Rows[6].Cells[2].Value) - val(frm.malla600.Rows[7].Cells[2].Value) - val(frm.malla600.Rows[8].Cells[2].Value);
            subTotPaga += val(frm.malla600.Rows[9].Cells[2].Value) + val(frm.malla600.Rows[10].Cells[2].Value) + val(frm.malla600.Rows[11].Cells[2].Value);
            subTotPaga += val(frm.malla600.Rows[12].Cells[2].Value) + val(frm.malla600.Rows[13].Cells[2].Value);

            if (subTotPaga > 0) { frm.malla600.Rows[18].Cells[2].Value = subTotPaga.ToString(formato); } else { subTotPaga = 0; }
            frm.malla600.Rows[20].Cells[2].Value = (val(frm.malla600.Rows[19].Cells[2].Value) + subTotPaga).ToString(formato);

        }
        internal static void calculos700(frmDax104 frm)
        {
            double impCausado = val(frm.malla700.Rows[6].Cells[2].Value) - val(frm.malla700.Rows[7].Cells[2].Value);
            frm.malla700.Rows[8].Cells[2].Value = impCausado.ToString(formato);
            frm.malla700.Rows[9].Cells[2].Value = (impCausado + val(frm.malla600.Rows[20].Cells[2].Value)).ToString(formato);
        }
        internal static void calculos900(frmDax104 frm)
        {
            double c902 = val(frm.malla700.Rows[9].Cells[2].Value) - val(frm.txt898.Text);
            double c999 = c902 + val(frm.txt903.Text) + val(frm.txt904.Text);
            frm.TXT902.Text = c902.ToString(formato);
            frm.txt905.Text = c999.ToString(formato);
            frm.Txt999.Text = c999.ToString(formato);
        }
        static internal string valFomat(object valor)
        {
            return val(valor).ToString("#0.00");
        }
        static internal double val(object valor)
        {
            double num = 0;
            try { num = Convert.ToDouble(valor); }
            catch { };
            return num;
        }
    }
}
;