using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace importarData
{
    public class CuentaValidada
    {
        public string CodigoOriginal { get; set; }
        public string CodigoNormalizado { get; set; }
        public string Nombre { get; set; }
        public int Nivel { get; set; }
        public string Grupo { get; set; }
        public bool Agrupacion { get; set; }
        public string CuentaPadre { get; set; }
        public string Cniv1 { get; set; }
        public string Cniv2 { get; set; }
        public string Cniv3 { get; set; }
        public string Cniv4 { get; set; }
        public string NomNiv1 { get; set; }
        public string NomNiv2 { get; set; }
        public bool EsValido { get; set; }
        public string Error { get; set; }

        // Nuevas propiedades
        public bool EsAgrupadora { get; set; }
        public bool PermiteMovimiento { get; set; }
        public string Tipo { get; set; }
        public int Cta_Gasto { get; set; }
        public int Cta_CostosDir { get; set; }
        public int Cta_CostosInDir { get; set; }
    }
}
