using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using registraEvntos;
namespace ClassMailSmtp
{
    public class EnvCorreoSmtp
    {
        string output = "";
        string StrconxDaxsys = "";
        Int32 codigoEmpresa = 0;
        public EnvCorreoSmtp (string strConxSys, Int32 codEmpresa = 0)
        {
            StrconxDaxsys = strConxSys;
            codigoEmpresa = codEmpresa;
        }
        public string EnviarCorreo(string ToCorreo, string ToCorreo2, string asunto, string Mensaje, string PathXml, string PathPdf, string PathTxt, SmtpClient smtpIn = null)         
        {
            try
            {
                string txtCorreo = registrar.obtenerPreferencia(StrconxDaxsys,codigoEmpresa.ToString(), "sys", "ADC", "", "mail", "correo");
                SmtpClient smtp = new SmtpClient();
                if (smtpIn != null) { smtp = smtpIn; } else { smtp = CrearConexionSmtp(); }
                smtp.Send(CrearMensaje(txtCorreo, ToCorreo, ToCorreo2,asunto,Mensaje,PathXml, PathPdf, PathTxt));
                output = "Corre electrónico fue enviado satisfactoriamente.";
            }
            catch (Exception ex)
            {
                output = "ERR: " + ex.Message;
            }

            return output;
        }
        private MailMessage CrearMensaje(string fromCorreo, string ToCorreo, string ToCorreo2, string asunto, string Mensaje, string PathXml, string PathPdf, string PathTxt)
        {
            MailMessage email = new MailMessage();
            if (fromCorreo.Length > 0) email.From = new MailAddress(fromCorreo);
            if (ToCorreo.Length > 0 ) email.To.Add(new MailAddress(ToCorreo));
            if (ToCorreo2.Length > 0) email.CC.Add(new MailAddress(ToCorreo2));
            email.Subject = asunto +" ( " + DateTime.Now.ToString("yyy/MMM/dd hh:mm:ss") + " ) ";
            email.Body = Mensaje;

            if (PathPdf.Length > 0) { email.Attachments.Add(new Attachment(PathPdf)); }
            if (PathXml.Length > 0) { email.Attachments.Add(new Attachment(PathXml)); }
            if (PathTxt.Length > 0) { email.Attachments.Add(new Attachment(PathTxt)); }
            
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;
            return email;
        }
        private SmtpClient CrearConexionSmtp()
        {
            string txtSmtp =  registrar.obtenerPreferencia(StrconxDaxsys,codigoEmpresa.ToString(), "sys", "ADC", "", "mail", "smtp");
            string txtUsuario = registrar.obtenerPreferencia(StrconxDaxsys, codigoEmpresa.ToString(), "sys", "ADC", "", "mail", "user");
            string txtClave = registrar.obtenerPreferencia(StrconxDaxsys, codigoEmpresa.ToString(), "sys", "ADC", "", "mail", "clave");
            string txtPuerto = registrar.obtenerPreferencia(StrconxDaxsys, codigoEmpresa.ToString(), "sys", "ADC", "", "mail", "puerto");
            string SSL = registrar.obtenerPreferencia(StrconxDaxsys, codigoEmpresa.ToString(), "sys", "ADC", "", "mail", "SSL");  
            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = txtSmtp;
                smtp.Port = Convert.ToInt32(txtPuerto);
                smtp.EnableSsl = false;
                if (SSL == "S") smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(txtUsuario , txtClave);
                
                return smtp;
            }catch (Exception ex)
            {
                output = "ERR: enviando correo electrónico: \n" + ex.Message;
                return null;
            }
        }

        //correo.SubjectEncoding = System.Text.Encoding.UTF8
        //correo.Subject = " ENVIO DOCUMENTOS ELCTRONICOS DE " & CONEMP.EmpresaAct.nombre
        //correo.Body = "ENVIAMOS DOCUMENTOS ELECTRONICOS FAC--"
        //correo.IsBodyHtml = False      'FORMATO WEB = TRUE
        //smtp.Credentials = New System.Net.NetworkCredential("facturasupremo@avarvel.com", "AGfsupremo") '"Correo remitente","contraseña del correo remitente")

        //'Dim text As String = "Digite un mensaje para el envio"
        //'Dim PlainView As AlternateView = AlternateView.CreateAlternateViewFromString(text, System.Text.Encoding.UTF8, MediaTypeNames.Text.Plain)
        //'Dim html As String = "<h2>Digite un mensaje para el envio</h2>" & "<img src='cid:imagen' />"
        //'Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(html, System.Text.Encoding.UTF8, MediaTypeNames.Text.Html)
        //'Dim img As New LinkedResource(CONEMP.EmpresaAct.PatAppl & NombreBmp, MediaTypeNames.Image.Jpeg)
        //'img.ContentId = "imagen"
        //'htmlView.LinkedResources.Add(img)
        //'correo.AlternateViews.Add(PlainView)
        //'correo.AlternateViews.Add(htmlView)       
    }
}
