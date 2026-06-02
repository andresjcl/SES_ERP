//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;
//using System.Net.Mail;
//using System.Net.Mime;
//using Microsoft.Office.Interop;
//namespace adcEnvmail
//{
//    public class docmail
//    {
//        string pathFileBmp = string.Empty;
//        string pathFileXml = string.Empty;
//        string pathFileTxt = string.Empty;
//        string strAsunto = string.Empty;
//        string claveElectronica = string.Empty;
//        string emailCorreo = string.Empty;
//        Boolean estado = true;

//        string strUser = string.Empty;
//        string strClave = string.Empty;
//        string strCorreoDesde = string.Empty;
//        string strPuerto = string.Empty;
//        string strSmtp = string.Empty;
//        string strDetalle = string.Empty;

//        private AdcHisOpc.AdcHistOpc AdcSettings = new AdcHisOpc.AdcHistOpc();
//        string StrConxSysemp10 = string.Empty;
//        Microsoft.Office.Interop.Outlook.Application m_OutLook; 

//        public string enviarMailDoc(string pathBMP, string pathXML, string pathTXT, string email, string strDsys)
//        {
//            pathFileBmp = pathBMP;
//            pathFileXml = pathXML;
//            pathFileTxt = pathTXT;
//            StrConxSysemp10 = strDsys;
//            emailCorreo = email;

//            if (claveElectronica.Length > 0)
//            {
//                strAsunto = " Envío documentos electrónicos ";
//            }
//            else
//            {
//                strAsunto = " Correo automático AdcomDx ";
//            }


//            if (verificar_outlook() == false) { return enviarMailSmtp(); }
//            else { return enviarMailOutlook(); }
//        }
//        private Boolean verificar_outlook()
//        {
//            try
//            {
//                Microsoft.Office.Interop.Outlook.Application m_OutLook = new Microsoft.Office.Interop.Outlook.Application();
//            }
//            catch 
//            {
//                estado = false;
//            }
//            return estado;
//        }
//        private string enviarMailOutlook()
//        {
//            string resp = string.Empty;
//            try
//            {
//                Microsoft.Office.Interop.Outlook.MailItem objMail = new Microsoft.Office.Interop.Outlook.MailItem();
//                Microsoft.Office.Interop.Outlook.Application m_OutLook = new Microsoft.Office.Interop.Outlook.Application();
//                objMail = (Microsoft.Office.Interop.Outlook.MailItem)m_OutLook.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

//                objMail.To = emailCorreo;
//                objMail.Subject = strAsunto;
//                objMail.HTMLBody = ".... " + "<img src='" + pathFileBmp + "' />";
//                objMail.Attachments.Add(pathFileBmp);

//                if (pathFileXml.Length > 5) { objMail.Attachments.Add(pathFileXml); }

//                objMail.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML;
//                //objMail.Display();
//                ((Microsoft.Office.Interop.Outlook._MailItem)objMail).Send();

//                if (m_OutLook != null)
//                {
//                    m_OutLook.Quit();
//                    m_OutLook = null;
//                }

//            }
//            catch (Exception ex)
//            {
//                resp = "ERROR: " + ex.Message;
//            }
//            return resp;
//        }



//        private string enviarMailSmtp()
//        {
//            string resp = string.Empty;
//            if (cargarParametrosCuenta() == false) return "ERROR : Parámetros de cuenta no válidos";
//            if (strSmtp.Length < 1) return "";
//            editarParametrosCorreo();
//            if (emailCorreo.Length < 1) return "";

//            MailMessage mail = new MailMessage();
//            mail.From = new MailAddress(strCorreoDesde);
//            mail.To.Add(emailCorreo);
//            mail.Subject = strAsunto;

//            string text = string.Empty;
//            AlternateView PlainView = AlternateView.CreateAlternateViewFromString(text, System.Text.Encoding.UTF8, MediaTypeNames.Text.Plain);
//            string html = "<h2>" + strDetalle + "</h2>" + "<img src='cid:imagen' />";
//            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(html, System.Text.Encoding.UTF8, MediaTypeNames.Text.Html);
//            LinkedResource img = new LinkedResource(pathFileBmp, MediaTypeNames.Image.Jpeg);
//            Attachment att = new Attachment(pathFileBmp);

//            mail.Attachments.Add(att);
//            if (pathFileXml.Length > 5)
//            {
//                Attachment att2 = new Attachment(pathFileXml);
//                mail.Attachments.Add(att2);
//            }

//            img.ContentId = "imagen";
//            htmlView.LinkedResources.Add(img);
//            mail.AlternateViews.Add(PlainView);
//            mail.AlternateViews.Add(htmlView);
//            SmtpClient smtp = new SmtpClient(strSmtp);

//            if (strUser.Length > 0)
//            {
//                smtp.Credentials = new System.Net.NetworkCredential(strUser, strClave);
//            }
//            smtp.Port = 2525;
//            try
//            {
//                if (Convert.ToInt32(strPuerto) > 0) smtp.Port = Convert.ToInt32(strPuerto);
//            }
//            catch { }
//            try
//            {
//                smtp.Send(mail);
//                smtp.Dispose();
//                att.Dispose();
//            }
//            catch (Exception ee)
//            {
//                resp = "Excepción al enviar correo \n" + ee.Message;
//            }

//            return resp;
//        }

//        private void editarParametrosCorreo()
//        {
//            Form2 prog = new Form2();
//            prog.strA = emailCorreo;
//            prog.strAsunto = strAsunto;
//            prog.strDe = strCorreoDesde;
//            prog.strDetalle = claveElectronica;

//            prog.ShowDialog();

//            emailCorreo = prog.strA;
//            strAsunto = prog.strAsunto;
//            strCorreoDesde = prog.strDe;
//            strDetalle = prog.strDetalle;
//        }

//        private Boolean cargarParametrosCuenta()
//        {
//            Form2 prog = new Form2();
//            strSmtp = AdcSettings.CargarOpcionHis(StrConxSysemp10, "", "ADC", "", "mail", "smtp");
//            if (strSmtp.Length == 0)
//            {
//                //if (MessageBox.Show("Debe registrar los datos para el servidor de salida de correo electronico \n" + "Desea registrar la información ahora ? ", "Evaluación de cuenta de correo ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return false;
//                ingresarDatosServidorCorreo();
//            }
//            else
//            {
//                strUser = AdcSettings.CargarOpcionHis(StrConxSysemp10, "", "ADC", "", "mail", "user");
//                strClave = AdcSettings.CargarOpcionHis(StrConxSysemp10, "", "ADC", "", "mail", "clave");
//                strCorreoDesde = AdcSettings.CargarOpcionHis(StrConxSysemp10, "", "ADC", "", "mail", "correo");
//                strPuerto = AdcSettings.CargarOpcionHis(StrConxSysemp10, "", "ADC", "", "mail", "puerto");
//            }
//            return true;
//        }


//        private void ingresarDatosServidorCorreo()
//        {
//            Form1 prog = new Form1();
//            prog.strClave = strClave;
//            prog.strCorreo = strCorreoDesde;
//            prog.strSmtp = strSmtp;
//            prog.strUsuario = strUser;
//            prog.strPuerto = strPuerto;

//            prog.ShowDialog();

//            strClave = prog.strClave;
//            strCorreoDesde = prog.strCorreo;
//            strSmtp = prog.strSmtp;
//            strUser = prog.strUsuario;
//            strPuerto = prog.strPuerto;
//        }
//    }
//}
