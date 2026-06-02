using Microsoft.Office.Interop.Outlook;
using System;
using System.Threading;

namespace ClassDaxMail
{
    public class EnvCorreoOutlook
    {
        public static string EnviarCorreoConOutlook(
            string toCorreos,
            string ccCorreos,
            string asunto,
            string adjuntos,
            string mensaje)
        {
            try
            {
                string resultado = "Correo enviado correctamente";

                // Abrir Outlook
                Application outlook = new Application();

                NameSpace mapi = outlook.GetNamespace("MAPI");
                mapi.Logon("", "", false, false);

                Thread.Sleep(500);

                // ✅ Crear MailItem SIN dynamic
                MailItem mail = (MailItem)outlook.CreateItem(OlItemType.olMailItem);

                mail.To = toCorreos;
                mail.CC = ccCorreos;
                mail.Subject = asunto;
                mail.HTMLBody = mensaje;

                // Adjuntos
                if (!string.IsNullOrWhiteSpace(adjuntos))
                {
                    var archivos = adjuntos.Split(';');

                    foreach (var archivo in archivos)
                    {
                        if (!string.IsNullOrWhiteSpace(archivo))
                            mail.Attachments.Add(archivo);
                    }
                }

                mail.Send();

                return resultado;
            }
            catch (System.Exception ex)
            {
                return "ERROR\n" + ex.Message;
            }
        }
    }
}
