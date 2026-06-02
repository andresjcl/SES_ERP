using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DaxInvent
{
    public class DaxInventarios
    {
        public static void MantenimientoArticulos(string CodArticulo = "", bool SoloConsulta = false)
        {
            MantArticulo prog = new MantArticulo(CodArticulo, SoloConsulta);
            prog.Show();
        }
        public static void MovimientosPorArtículo()
        {
            frmMovArt prog = new frmMovArt();
            prog.Show();
        }
        public static void DatosComercialesDelArticulo(string CodArticulo, string CoxAdcom, string Suc, string CodCliente, string Fecha, string tipoDoc, string NumDoc, string Bodega)
        {
            frmDatosComerciales prog = new frmDatosComerciales(CodArticulo, CoxAdcom, Suc, CodCliente,Fecha, tipoDoc,NumDoc, Bodega);
            prog.ShowDialog();            
        }
        public static void ExistenciaPorBodega()
        {
            frmExistBods prog = new frmExistBods ();
            prog.ShowDialog();
        }
        public static void AgrupacionNiveles()
        {
            DaxInvent.FrmNivAcf prog = new DaxInvent.FrmNivAcf();
            prog.FrmNivAcf(false);
        }
    }
}
