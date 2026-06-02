using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace importarData
{
    public class RegistroValidado
    {
        public string RUC { get; set; }
        public string Codigo { get; set; }
        public string RazonSocial { get; set; }
        public string Telefonos { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public bool EsCliente { get; set; }
        public bool EsProveedor { get; set; }
        public string TipoIdentificacion { get; set; }
        public string TipoPersona { get; set; }
        public bool EsValido { get; set; }
        public string Error { get; set; }
    }
}
