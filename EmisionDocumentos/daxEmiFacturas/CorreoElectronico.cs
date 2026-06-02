using DattCom;

namespace DctosEmi
{
    class CorreoElectronico
    {
        static internal void EnviarCorreoElectronico(ClassDoc.idDocumento idDocumentoActual,int EsElectronico)
        {
			string separa = " - ";
			string formatoElectronico = "";
			if (EsElectronico > 0) formatoElectronico = "FEL" + idDocumentoActual.Tipo;
			string archivoPdf = datosEmpresa.path_tmpServer + idDocumentoActual.Tipo;
			if (idDocumentoActual.Serie.Length > 0) archivoPdf += separa + idDocumentoActual.Serie;
			archivoPdf += separa + idDocumentoActual.numero.ToString();
			documentosPdf.generacionPdf genpdf = new documentosPdf.generacionPdf(datosEmpresa.nombreBaseIvaret, datosEmpresa.strConxAdcom, datosEmpresa.strConxIvaret, datosEmpresa.strConIniSis, datosEmpresa.strConxDaxpro, datosEmpresa.Emp_codigo, datosEmpresa.pathServer);
			genpdf.GeneraDocPdf(idDocumentoActual, archivoPdf, formatoElectronico);
			ClassDaxMail.FrmEnviarCorreo frmEnviar = new ClassDaxMail.FrmEnviarCorreo(datosEmpresa.Emp_Nombre + ",envío de documentos", "", "", "", datosEmpresa.strConIniSis, archivoPdf);
			frmEnviar.ShowDialog();
		}

	}
}
