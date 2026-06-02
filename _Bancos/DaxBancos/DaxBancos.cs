using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DaxBan
{
    public class DaxBancos
    {
        public void CtasBancarias()
        {
            CtasBanForm prog = new CtasBanForm();
            prog.Show();
        }
        public void ConciliacionBancaria()
        {
            frmConBan prog = new DaxBan.frmConBan();
            prog.Show();
        }
        public void SaldosCajaBancos()
        {
            FrmSaldos prog = new DaxBan.FrmSaldos();
            prog.Show();
        }
    }
}
