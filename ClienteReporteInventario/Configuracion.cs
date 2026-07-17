using System.Configuration;

namespace ClienteReporteInventario
{
    public static class Configuracion
    {
        public static string ApiUrl
        {
            get
            {
                // Leer desde App.config
                string url = ConfigurationManager.AppSettings["ApiUrl"];

                // Si no está configurado, usar valor por defecto
                if (string.IsNullOrEmpty(url))
                {
                    url = "http://SRV-BH:5000";
                }

                return url;
            }
        }
    }
}