using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms; 
using DattCom;

namespace ImpresionDocumentosDax
{
    class ImpresionControlada
    {
        internal static bool ImprimirSinMensaje(ClassDoc.AdcDoc datADCDOC, daxAccs.propiedadesDaxAuto accesosLocalizados, ClassDoc.idDocumento idDocumentoActual,bool ImpresionDirecta = false)
        {
            if (accesosLocalizados.NroImpresiones > 0 && accesosLocalizados.NroImpresiones <= datADCDOC.Doc_Adicional1)
            { MessageBox.Show("Ha llegado al límite de impresiones permitidas", "Imprimir documentos", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
            try
            {
                ImpresionDocumentosDax.ImprimeDocumentoDoble impProg = new ImpresionDocumentosDax.ImprimeDocumentoDoble(datosEmpresa.nombreBaseIvaret, datosEmpresa.strConxAdcom, datosEmpresa.strConxIvaret, datosEmpresa.strConIniSis, datosEmpresa.strConxDaxpro, datosEmpresa.codEmpresa, datosEmpresa.pathServer);
                int imp = impProg.ImpDocFast(idDocumentoActual, "A", "", false, ImpresionDirecta);
                datADCDOC.Doc_Adicional1 = imp;
                impProg.Dispose();
            }
            catch (Exception ee)
            { MessageBox.Show("Excepción en impresion de documento \n" + ee.Message); return false; }
            return true;
        }
    }
}
