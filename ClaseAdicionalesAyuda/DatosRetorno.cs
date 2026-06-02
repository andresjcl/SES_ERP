using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace ConsultaCedulaApi
{
    public class ConsultaCedulaService
    {
        private const string ApiKey = "aupx1RSuyw8STqR4i3nxG5Xks5OGwbZN5xelUG0NVPE";
        private const string BaseUrl = "https://smartxmlplus.com/api/dinardap/";

        public ConsultaCedulaService()
        {
            // Configurar protocolos de seguridad para .NET 4.0
            // Tls12 no está disponible en .NET 4.0, usamos el valor numérico
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // 3072 = Tls12
        }

        // Método sincrono tradicional para .NET 4.0
        public ResultadoConsulta ConsultarCedula(string cedula)
        {
            var resultado = new ResultadoConsulta();

            try
            {
                if (!EsCedulaValida(cedula))
                {
                    resultado.Error = "La cédula debe tener exactamente 10 dígitos numéricos";
                    resultado.Exitoso = false;
                    return resultado;
                }

                string url = BaseUrl + cedula;

                // Usar HttpWebRequest (más confiable que WebClient para HTTPS)
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                // Configurar request
                request.Method = "GET";
                request.Headers["Authorization"] = "Bearer " + ApiKey;
                request.Accept = "application/json";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64)";
                request.Timeout = 30000; // 30 segundos

                // Configurar SSL/TLS
                request.ServicePoint.Expect100Continue = false;
                request.Proxy = null;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (Stream stream = response.GetResponseStream())
                        using (StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8))
                        {
                            string json = reader.ReadToEnd();
                            var respuestaApi = JsonConvert.DeserializeObject<RespuestaApi>(json);

                            if (respuestaApi != null && respuestaApi.ok && respuestaApi.data != null)
                            {
                                resultado.Exitoso = true;
                                resultado.Datos = MapearDatos(respuestaApi.data);
                            }
                            else
                            {
                                resultado.Exitoso = false;
                                resultado.Error = "No se encontró información para la cédula ingresada";
                            }
                        }
                    }
                    else
                    {
                        resultado.Exitoso = false;
                        resultado.Error = $"Error en la consulta: {response.StatusCode}";
                    }
                }
            }
            catch (WebException webEx)
            {
                resultado.Exitoso = false;

                if (webEx.Response != null)
                {
                    HttpWebResponse errorResponse = (HttpWebResponse)webEx.Response;

                    if (errorResponse.StatusCode == HttpStatusCode.NotFound)
                    {
                        resultado.Error = "Cédula no encontrada en el registro civil";
                    }
                    else if (errorResponse.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        resultado.Error = "Error de autenticación. Verifique el token de API";
                    }
                    else if (errorResponse.StatusCode == HttpStatusCode.Forbidden)
                    {
                        resultado.Error = "Acceso denegado al servicio";
                    }
                    else
                    {
                        resultado.Error = $"Error HTTP: {errorResponse.StatusCode} - {errorResponse.StatusDescription}";
                    }
                }
                else
                {
                    resultado.Error = $"Error de conexión: {webEx.Message}";

                    // Si es un error de SSL/TLS
                    if (webEx.Message.Contains("SSL/TLS"))
                    {
                        resultado.Error += ". Verifique que el servidor soporte TLS 1.2";
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.Exitoso = false;
                resultado.Error = $"Error: {ex.Message}";
            }

            return resultado;
        }

        // Versión alternativa usando WebClient (más simple)
        public ResultadoConsulta ConsultarCedulaSimple(string cedula)
        {
            var resultado = new ResultadoConsulta();

            try
            {
                if (!EsCedulaValida(cedula))
                {
                    resultado.Error = "La cédula debe tener exactamente 10 dígitos numéricos";
                    resultado.Exitoso = false;
                    return resultado;
                }

                string url = BaseUrl + cedula;

                using (WebClient client = new WebClient())
                {
                    // Configurar headers
                    client.Headers[HttpRequestHeader.Authorization] = "Bearer " + ApiKey;
                    client.Headers[HttpRequestHeader.Accept] = "application/json";
                    client.Encoding = System.Text.Encoding.UTF8;
                    client.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64)";

                    // Descargar datos
                    string json = client.DownloadString(url);

                    var respuestaApi = JsonConvert.DeserializeObject<RespuestaApi>(json);

                    if (respuestaApi != null && respuestaApi.ok && respuestaApi.data != null)
                    {
                        resultado.Exitoso = true;
                        resultado.Datos = MapearDatos(respuestaApi.data);
                    }
                    else
                    {
                        resultado.Exitoso = false;
                        resultado.Error = "No se encontró información para la cédula ingresada";
                    }
                }
            }
            catch (WebException webEx)
            {
                resultado.Exitoso = false;
                resultado.Error = ManejarExcepcionWeb(webEx);
            }
            catch (Exception ex)
            {
                resultado.Exitoso = false;
                resultado.Error = $"Error: {ex.Message}";
            }

            return resultado;
        }

        private string ManejarExcepcionWeb(WebException webEx)
        {
            if (webEx.Response != null)
            {
                using (HttpWebResponse errorResponse = (HttpWebResponse)webEx.Response)
                {
                    if (errorResponse.StatusCode == HttpStatusCode.NotFound)
                        return "Cédula no encontrada en el registro civil";
                    else if (errorResponse.StatusCode == HttpStatusCode.Unauthorized)
                        return "Error de autenticación. Verifique el token de API";
                    else if (errorResponse.StatusCode == HttpStatusCode.Forbidden)
                        return "Acceso denegado al servicio";
                    else
                        return $"Error HTTP: {errorResponse.StatusCode}";
                }
            }
            else
            {
                string mensaje = $"Error de conexión: {webEx.Message}";

                // Verificar si es un error de SSL/TLS
                if (webEx.Status == WebExceptionStatus.TrustFailure ||
                    webEx.Message.Contains("SSL") ||
                    webEx.Message.Contains("TLS"))
                {
                    mensaje += "\n\nPosible solución: Instale las actualizaciones de .NET Framework 4.0 o";
                    mensaje += "\nconfigure el registro de Windows para habilitar TLS 1.2.";
                }

                return mensaje;
            }
        }

        private DatosCiudadano MapearDatos(Data data)
        {
            return new DatosCiudadano
            {
                Cedula = data.identificacion ?? "",
                NombresCompletos = $"{data.nombres} {data.apellidos}".Trim(),
                CondicionCiudadano = data.condicionCiudadano ?? "",
                Sexo = "", // API no devuelve este campo
                FechaNacimiento = data.fechaNacimiento ?? "",
                LugarNacimiento = data.direccion ?? "",
                Nacionalidad = "", // API no devuelve este campo
                EstadoCivil = data.estadoCivil ?? "",
                Conyuge = $"{data.nombreConyuge} {data.apellidoConyuge}".Trim(),
                Domicilio = data.direccion ?? "",
                Provincia = data.canton?.nombre ?? "",
                Canton = data.provincia?.nombre ?? "",
                Edad = data.edad,
                Profesion = data.profesion ?? ""
            };
        }

        private bool EsCedulaValida(string cedula)
        {
            if (string.IsNullOrWhiteSpace(cedula))
                return false;

            if (cedula.Length != 10)
                return false;

            // Verificar que todos sean dígitos
            foreach (char c in cedula)
            {
                if (!char.IsDigit(c))
                    return false;
            }

            return true;
        }
    }

    
}