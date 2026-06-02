using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebServiceSri;

namespace DaxDocElectronicos
{
    //    public class EnviarComprobanteSri
    //    {
    //        string pathError ="";
    //        public Boolean sendComprobanteSRI(string fileName, string clave, string pathAutorizado, string pathNoAutorizados,Boolean OnnLine,string ambiente, string strConxAdcom)
    //        {            
    //            WebServiceSri.WebService ws = new WebServiceSri.WebService();
    //            WebServiceSri.RespuestaSRYType respSri = WebServiceSri.RespuestaSRYType.NOAUTORIZADO;
    //            ws.IsOFFLine = !OnnLine;

    //            bool autorizado = false;
    //            List<string> errores = new List<string>();
    //            string error = "";
    //            //--------------------------------------------------------------------------------------------
    //            pathError = pathNoAutorizados.Replace("XML", "err");
    //            pathError = pathError.Replace("xml", "err");

    //            //try
    //            {
    //                respSri = ws.SendComprobante(fileName, pathAutorizado);
    //                if (respSri == WebServiceSri.RespuestaSRYType.AUTORIZADO)
    //                {
    //                    autorizado = true;
    //                    Feutilidad util = new Feutilidad();
    //                    util.ActualizarDocumentoAdcom("Autorizado", "", "", 0, clave, ws.Comprobante.NumeroAutorizacion, 0, ws.Comprobante.FechaAutorizacion,Convert.ToInt16(ambiente),strConxAdcom);
    //                }
    //                else if (ws.Comprobante.Mensajes.Count > 0)
    //                {
    //                    System.IO.File.Copy(fileName, pathNoAutorizados, true);
    //                    System.IO.File.Delete(pathAutorizado);
    //                    error = ws.Comprobante.getMensajes();
    //                }
    //            }
    ////            catch (Exception ex)
    //            {
    //  //              error = ex.Message + " " + DateTime.Now.ToLongDateString();
    //            }

    //            if (error.Length > 0) { errores.Add(error); grabarMensajes(errores);}
    //            ws = null;
    //            return autorizado;
    //        }
    //        private void grabarMensajes( List<String> mensajes)
    //            {
    //                System.IO.StreamWriter file = new System.IO.StreamWriter(pathError);

    //                foreach (string Mensaje in mensajes)
    //                {
    //                    file.WriteLine(Mensaje);
    //                }
    //                file.Flush();
    //                file.Close();
    //                file.Dispose();
    //            }
    //    }
    public class EnviarComprobanteSri
    {
        private string pathError = "";

        public bool sendComprobanteSRI(string fileName,string clave,string pathAutorizado,string pathNoAutorizados,bool OnnLine,string ambiente,string strConxAdcom)
        {
            WebService webService = new WebService();
            webService.IsOFFLine = !OnnLine;
            bool flag = false;
            List<string> mensajes = new List<string>();
            string str = "";
            this.pathError = pathNoAutorizados.Replace("XML", "err");
            this.pathError = this.pathError.Replace("xml", "err");
            try
            {
                if (webService.SendComprobante(fileName, pathAutorizado) == RespuestaSRYType.AUTORIZADO)
                {
                    flag = true;
                    new Feutilidad().ActualizarDocumentoAdcom("Autorizado", "", "", 0.0, clave, webService.Comprobante.NumeroAutorizacion, 0, webService.Comprobante.FechaAutorizacion, (int)Convert.ToInt16(ambiente), strConxAdcom);
                }
                else if (webService.Comprobante.Mensajes.Count > 0)
                {
                    File.Copy(fileName, pathNoAutorizados, true);
                    File.Delete(pathAutorizado);
                    str = webService.Comprobante.getMensajes();
                }
            }
            catch (Exception ex)
            {
                str = ex.Message + " " + DateTime.Now.ToLongDateString();
            }
            if (str.Length > 0)
            {
                mensajes.Add(str);
                this.grabarMensajes(mensajes);
            }
            return flag;
        }

        private void grabarMensajes(List<string> mensajes)
        {
            StreamWriter streamWriter = new StreamWriter(this.pathError);
            foreach (string mensaje in mensajes)
                streamWriter.WriteLine(mensaje);
            streamWriter.Flush();
            streamWriter.Close();
            streamWriter.Dispose();
        }
    }



}
