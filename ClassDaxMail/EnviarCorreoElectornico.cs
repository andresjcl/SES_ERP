using AuditSis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassDaxMail
{
    public static class EnviarCorreoElectornico
    {
        public static string EnviandoCorreo(
          string strConxSys,
          int codEmpresa,
          string ToCorreos,
          string CCcorreos,
          string asunto,
          string Mensaje,
          string Adjuntos)
        {
            return registrar.obtenerPreferencia(strConxSys, codEmpresa.ToString(), "sys", "CNX", "", "mail", "TipoCta") == "smtp" ? new EnvCorreoSmtp(strConxSys, codEmpresa).EnviarCorreoSmpt(ToCorreos, CCcorreos, asunto, Mensaje, Adjuntos) : EnvCorreoOutlook.EnviarCorreoConOutlook(ToCorreos, CCcorreos, asunto, Adjuntos, Mensaje);
        }
    }
}
