using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace DaxDocElectronicos
{
    public class ApiClient
    {
        
        public string GenerarFactura(FacturaRequest request, string rutaPdf, string nombrePDF, string urlsri_)
        {
            try
            {
                using (var client = new WebClient())
                {
                    // Configuración SSL/TLS (necesario para HTTPS)
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    string url = urlsri_;
                    //MessageBox.Show("esta rutta viene de paraametros"+url);
                    // Serializar el objeto a JSON
                    string json = new JavaScriptSerializer().Serialize(request);

                    // Enviar solicitud POST
                    byte[] responseBytes = client.UploadData(url, "POST", Encoding.UTF8.GetBytes(json));
                    //string response = Encoding.UTF8.GetString(responseBytes);

                    //return response; // Retorna la ruta del PDF generado

                    // Quitar barra final si existe
                    string rutaPdfSinBarra = rutaPdf.TrimEnd('\\');
                    //MessageBox.Show(rutaPdfSinBarra);
                    string rutaPadre = Path.GetDirectoryName(rutaPdfSinBarra);
                    string rutaF = Path.Combine(rutaPadre, "GeneradosPDF");
                    //MessageBox.Show(rutaF);
                    string archivoF = nombrePDF + ".pdf";
                    string ruta = Path.Combine(rutaF, archivoF);
                    //MessageBox.Show(ruta);
                    File.WriteAllBytes(ruta, responseBytes);  // Guarda el PDF como archivo físico

                    return "GENERADO"; // Retorna la ruta del archivo guardado

                }
            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    string error = reader.ReadToEnd();
                    throw new Exception($"Error en la API: {error}");
                }
            }
        }
    }

}
