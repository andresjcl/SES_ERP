
namespace MantCtb
{
    public class BuscaCta
    {
        public string BuscaCtaCtb(ref string Nombre, ref string TipoMovimiento)
        {
            string BuscaCtaCtbRet = default;
            var prog = new BuscaCtaContab();
            BuscaCtaCtbRet = "";
            prog.IniciaCtas(ref Nombre, ref TipoMovimiento);
            BuscaCtaCtbRet = OperacionesBuscaCta.CodigoCta;
            Nombre = OperacionesBuscaCta.NombreCta;
            prog = null;
            return BuscaCtaCtbRet;
        }

        public void ImprimePlanCtas()
        {
            var prog = new CTBP21();
            prog.ShowDialog();
            prog = null;
        }

        public void MantenCtas()
        {
            var prog = new CTBP01();
            prog.ShowDialog();
            prog = null;
        }
    }
}