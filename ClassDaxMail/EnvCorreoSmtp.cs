using AuditSis;
using DattCom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Text;

namespace ClassDaxMail
{
    public class EnvCorreoSmtp
    {
        private string output = "";
        private string StrconxDaxsys = "";
        private int codigoEmpresa = 0;
        private SmtpClient smtp;

        public EnvCorreoSmtp(string strConxSys, int codEmpresa = 0)
        {
            this.StrconxDaxsys = strConxSys;
            this.codigoEmpresa = codEmpresa;
            if (this.codigoEmpresa != 0)
                return;
            this.codigoEmpresa = (int)datosEmpresa.codEmpresa;
        }

        public string EnviarCorreoSmpt(
          string ToCorreos,
          string CCcorreos,
          string asunto,
          string Mensaje,
          string Adjuntos)
        {
            this.output = "Correo electrónico fue enviado satisfactoriamente.";
            try
            {
                string fromCorreo = registrar.obtenerPreferencia(this.StrconxDaxsys, this.codigoEmpresa.ToString(), "sys", "ADC", "", "mail", "correo");
                this.smtp = new SmtpClient();
                string host = registrar.obtenerPreferencia(this.StrconxDaxsys, this.codigoEmpresa.ToString(), "sys", "ADC", "", "mail", "smtp");
                if (host.Length == 0)
                {
                    this.output = " No se ha registrado una cuenta de correo ";
                    return (string)null;
                }
                string userName = registrar.obtenerPreferencia(this.StrconxDaxsys, this.codigoEmpresa.ToString(), "sys", "ADC", "", "mail", "user");
                string password = registrar.obtenerPreferencia(this.StrconxDaxsys, this.codigoEmpresa.ToString(), "sys", "ADC", "", "mail", "clave");
                string str1 = registrar.obtenerPreferencia(this.StrconxDaxsys, this.codigoEmpresa.ToString(), "sys", "ADC", "", "mail", "puerto");
                string str2 = registrar.obtenerPreferencia(this.StrconxDaxsys, this.codigoEmpresa.ToString(), "sys", "ADC", "", "mail", "SSL");
                registrar.obtenerPreferencia(this.StrconxDaxsys, this.codigoEmpresa.ToString(), "sys", "ADC", "", "mail", "cuenta");
                try
                {
                    this.smtp = new SmtpClient(host, Convert.ToInt32(str1));
                    this.smtp.Credentials = (ICredentialsByHost)new NetworkCredential(userName, password);
                    ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)((s, certificate, chain, sslPolicyErrors) => true);
                    this.smtp.EnableSsl = str2 == "S";
                    this.smtp.Timeout = 50000;
                    this.smtp.Send(this.CrearMensaje(fromCorreo, ToCorreos, CCcorreos, asunto, Mensaje, Adjuntos));
                }
                catch (Exception ex)
                {
                    this.output = "ERR: Enviando correo electrónico : \n" + ex.Message;
                }
            }
            catch (Exception ex)
            {
                this.output = "ERR: " + ex.Message;
            }
            return this.output;
        }

        private MailMessage CrearMensaje(
          string fromCorreo,
          string ToCorreos,
          string CCcorreos,
          string asunto,
          string Mensaje,
          string Adjuntos)
        {
            MailMessage mailMessage = new MailMessage();
            if (fromCorreo.Length > 0)
                mailMessage.From = new MailAddress(fromCorreo);
            mailMessage.Subject = asunto;
            mailMessage.Body = Mensaje;
            string[] strArray1 = new string[1];
            if (!string.IsNullOrEmpty(ToCorreos))
            {
                string str = ToCorreos + ";;;;;";
                char[] chArray = new char[1] { Convert.ToChar(";") };
                foreach (string address in str.Split(chArray))
                {
                    if (!string.IsNullOrEmpty(address))
                        mailMessage.To.Add(new MailAddress(address));
                }
            }
            strArray1 = new string[1];
            if (!string.IsNullOrEmpty(ToCorreos))
            {
                string str = ToCorreos + ";;;;;";
                char[] chArray = new char[1] { Convert.ToChar(";") };
                foreach (string address in str.Split(chArray))
                {
                    if (!string.IsNullOrEmpty(address))
                        mailMessage.CC.Add(new MailAddress(address));
                }
            }
            string[] strArray2 = new string[1];
            if (!string.IsNullOrEmpty(Adjuntos))
            {
                string str = Adjuntos + ";;;;;";
                char[] chArray = new char[1] { Convert.ToChar(";") };
                foreach (string fileName in str.Split(chArray))
                {
                    if (!string.IsNullOrEmpty(fileName))
                        mailMessage.Attachments.Add(new Attachment(fileName));
                }
            }
            mailMessage.IsBodyHtml = true;
            mailMessage.Priority = MailPriority.Normal;
            return mailMessage;
        }
    }

}
