using DattCom;
using System;
using System.Windows.Forms;
namespace DctosEmi
{
	class EnviarAimpresora
	{
		internal static bool imprimirDocumento(ClassDoc.AdcDoc datADCDOC, daxAccs.propiedadesDaxAuto accesosLocalizados, ClassDoc.idDocumento idDocumentoActual)
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
		internal static bool imprimirDocumento(ClassDoc.AdcDocPro datADCDOC, daxAccs.propiedadesDaxAuto accesosLocalizados, ClassDoc.idDocumento idDocumentoActual)
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
		internal static bool imprimirDocumentoDirectamente(ClassDoc.AdcDoc datADCDOC, daxAccs.propiedadesDaxAuto accesosLocalizados, ClassDoc.idDocumento idDocumentoActual)
		{
			if (accesosLocalizados.NroImpresiones > 0 && accesosLocalizados.NroImpresiones <= datADCDOC.Doc_Adicional1)
			{ MessageBox.Show("Ha llegado al límite de impresiones permitidas", "Imprimir documentos", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
			try
			{
				ImpresionDocumentosDax.ImprimeDocumentoDoble impProg = new ImpresionDocumentosDax.ImprimeDocumentoDoble(datosEmpresa.nombreBaseIvaret, datosEmpresa.strConxAdcom, datosEmpresa.strConxIvaret, datosEmpresa.strConxSyscod, datosEmpresa.strConxDaxpro, datosEmpresa.codEmpresa, datosEmpresa.pathServer);
				int imp = impProg.ImpDocFast(idDocumentoActual, "A", "", false, true);
				datADCDOC.Doc_Adicional1 = imp;
				impProg.Dispose();
			}
			catch (Exception ee)
			{ MessageBox.Show("Excepción en impresion de documento \n" + ee.Message); return false; }
			return true;
		}
		internal static bool imprimirDocumentoDirectamente(ClassDoc.AdcDocPro datADCDOC, daxAccs.propiedadesDaxAuto accesosLocalizados, ClassDoc.idDocumento idDocumentoActual)
		{
			if (accesosLocalizados.NroImpresiones > 0 && accesosLocalizados.NroImpresiones <= datADCDOC.Doc_Adicional1)
			{ MessageBox.Show("Ha llegado al límite de impresiones permitidas", "Imprimir documentos", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
			try
			{
				ImpresionDocumentosDax.ImprimeDocumentoDoble impProg = new ImpresionDocumentosDax.ImprimeDocumentoDoble(datosEmpresa.nombreBaseIvaret, datosEmpresa.strConxAdcom, datosEmpresa.strConxIvaret, datosEmpresa.strConxSyscod, datosEmpresa.strConxDaxpro, datosEmpresa.codEmpresa, datosEmpresa.pathServer);
				int imp = impProg.ImpDocFast(idDocumentoActual, "A", "", false, true);
				datADCDOC.Doc_Adicional1 = imp;
				impProg.Dispose();
			}
			catch (Exception ee)
			{ MessageBox.Show("Excepción en impresion de documento \n" + ee.Message); return false; }
			return true;
		}
		internal static string archivoAExcell()
		{
			SaveFileDialog sfd = new SaveFileDialog()
			{
				OverwritePrompt = true,
				Title = "Nombre de archivo para exportar documento",
				InitialDirectory = @"\tmp",
				Filter = "Archivos tipo excell (*.xls)|*.xls"
			};
			sfd.ShowDialog();
			return sfd.FileName;
		}
	}
}
