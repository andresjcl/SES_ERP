using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static DaxDocElectronicos.Auxiliares;

namespace DaxDocElectronicos
{
    public class FacturaRequest
    {
        public List<IvaInfo> IvaInfoList { get; set; } = new List<IvaInfo>();
        public string RucEmisor { get; set; }
        public string RazonSocialEmisor { get; set; }
        public string DireccionMatriz { get; set; }
        public string DireccionSucursal { get; set; }
        public string EmailEmisor { get; set; }
        public string TelefonoEmisor { get; set; }
        public bool ObligadoContabilidad { get; set; }
        public string AgenteRetencion { get; set; }
        public string NroCtrbuyteEspecial { get; set; }
        public string Regimen { get; set; }
        public string NumeroFactura { get; set; }
        public string NumeroAutorizacion { get; set; }
        public string FechaAutorizacion { get; set; }
        public string Ambiente { get; set; }
        public string TipoEmision { get; set; }
        public string ClaveAcceso { get; set; }
        public string NombreCliente { get; set; }
        public string IdentificacionCliente { get; set; }
        public string FechaEmision { get; set; }
        public string DireccionCliente { get; set; }
        public string TelefonoCliente { get; set; }
        public string EmailCliente { get; set; }
        public string FormaPago { get; set; }
        public decimal TotalFormaPago { get; set; }
        public int PlazoFormaPago { get; set; }
        public decimal _Doc_porceniva { get; set; }
        public string UnidadFormaPago { get; set; }
        public string InformacionAdicional { get; set; }
        public Double Subtotal0 { get; set; }
        public Double Subtotal15 { get; set; }
        public Double Subtotal5 { get; set; }
        public Double SubtotalNoIva { get; set; }
        public Double Descuento { get; set; }
        public Double Ice { get; set; }
        public Double Iva15 { get; set; }
        public Double Iva5 { get; set; }

        public Double ValorTotal { get; set; }

        public string LogoBase64 { get; set; }


        public List<DetalleFactura> Detalles { get; set; }
    }

    public class DetalleFactura
    {
        public string CodigoPrincipal { get; set; }
        public decimal Cantidad { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Descuento { get; set; }
        public decimal PrecioTotal { get; set; }
        public decimal Tra_porcendes { get; set; }
        public decimal Tra_porceniva { get; set; }

    }

}
