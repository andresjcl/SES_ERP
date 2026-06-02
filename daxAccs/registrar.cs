using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace daxAccs
{
    public class registrar
    {
        public void registro(Int32 cemp, string cusr, string cdoc, string ndoc, string stradc, string strsys)
        {
            try
            {
                frmAccsDoc prog = new frmAccsDoc(cemp, cusr, cdoc, ndoc, strsys, stradc);
                prog.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show("excepcion: no se puede iniciar registro de accesos \n" + ee);
            }
        }
    }
}
