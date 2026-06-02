using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classPedPend
{
    public class mntPerio
    {
        public mntPerio ()
        {


        }
        public void iniciar()
        {
            frmPedPer frmPeriodoFijo = new frmPedPer(); 
            frmPeriodoFijo.ShowDialog();
            frmPeriodoFijo.Close();
            frmPeriodoFijo.Dispose();
        }
    }
}
