using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DattCom;
namespace adcDocumentos
{
    class EnviarAimpresora
    {
        internal static bool imprimirDocumento(ClassDoc.AdcDoc datADCDOC, daxAccs.propiedadesDaxAuto accesosLocalizados,ClassDoc.idDocumento idDocumentoActual)
        {
            if (accesosLocalizados.NroImpresiones > 0 && accesosLocalizados.NroImpresiones <= datADCDOC.Doc_Adicional1)
            { MessageBox.Show("Ha llegado al límite de impresiones permitidas", "Imprimir documentos", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
 //           try
            {
                ImpresionDocumentosDax.ImprimeDocumentoDoble impProg = new ImpresionDocumentosDax.ImprimeDocumentoDoble(datosEmpresa.nombreBaseIvaret, datosEmpresa.strConxAdcom, datosEmpresa.strConxIvaret, datosEmpresa.strConxSyscod, datosEmpresa.strConxDaxpro, datosEmpresa.codEmpresa, datosEmpresa.pathServer);
                int imp = impProg.ImpDoc(idDocumentoActual, "A", "", false, false);
                datADCDOC.Doc_Adicional1 = imp;
                impProg.Dispose();
            }
   //         catch (Exception ee)
   //         { MessageBox.Show ("Excepción en impresion de documento \n" + ee.Message); return false; }
            return true;
        }
        internal static bool imprimirDocumentoDirectamente(ClassDoc.AdcDoc datADCDOC, daxAccs.propiedadesDaxAuto accesosLocalizados, ClassDoc.idDocumento idDocumentoActual, string ImprimeOtroFormato = "")
        {
            if (accesosLocalizados.NroImpresiones > 0 && accesosLocalizados.NroImpresiones <= datADCDOC.Doc_Adicional1)
            { MessageBox.Show("Ha llegado al límite de impresiones permitidas", "Imprimir documentos", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
            try
            {
                ImpresionDocumentosDax.ImprimeDocumentoDoble impProg = new ImpresionDocumentosDax.ImprimeDocumentoDoble(datosEmpresa.nombreBaseIvaret, datosEmpresa.strConxAdcom, datosEmpresa.strConxIvaret, datosEmpresa.strConxSyscod, datosEmpresa.strConxDaxpro, datosEmpresa.codEmpresa, datosEmpresa.pathServer);
                int imp = impProg.ImpDocFast(idDocumentoActual, "A", ImprimeOtroFormato, false, true);
                datADCDOC.Doc_Adicional1 = imp;
                impProg.Dispose();
            }
            catch (Exception ee)
            { MessageBox.Show("Excepción en impresion de documento \n" + ee.Message); return false; }
            return true;
        }
    }
}
