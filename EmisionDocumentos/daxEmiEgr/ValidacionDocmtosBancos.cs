using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using classMenSistem;
using ValidacionDocumentos;

namespace DctosEmi
{
    public class ValidacionDocmtosBancos
    {
        public bool validaEgresoBanco(ClassDoc.AdcDoc DatosDocmto, System.Windows.Forms.DataGridView malla,string usuario)
        {                      
            {
                if (DatosDocmto.Doc_numero == 0) { mensajesErrorDocumento.MensajeNumeroDoc(); return false; }
                if (ValidacionGeneral.validarFecha(DatosDocmto.Doc_fecha.ToShortDateString(), usuario) == false) return false;
                if (ValidacionGeneral.validarIngresoDetalle(malla, "CodConcepto") == false) return false;
                if (DatosDocmto.Doc_codper == "" ) { mensajesErrorDocumento.ElCodigoNoExiste("C"); return false; }
                if (DatosDocmto.Doc_NombreImp.Length == 0) { mensajesErrorDocumento.InfDeContactoNoCorrecta(); return false; }
                //            if (DatosDocmto.Doc_Banco.ToString().Length == 0) { mensajesErrorDocumento.bInfDeContactoNoCorrecta(); return false; })
                return true;
            }
        }
    }
}
