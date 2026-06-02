using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace DaxComercia
{
    public class pagoDoc
    {
        public string TipoPag ="";
        public string Descripcion = "";  
        public double Valor=0 ;
        public string autoriza = "";
        public string DocInstitucion = "";
        public string NumCtaBanco = "";
        public string DocPagoTipo = "";
        public string DocPagoNumero = "";
        public string PlanTarjeta = "";  
        public double ComisionTarjeta =0;  
        public Single NroCuotas=0; 
        public Int32 PagoACredito =0;
        public Int32 GeneraIngreso =0;
        public Int32 CancelaFactura =0; 
        public double InteresTarjeta =0;
        public string IdFormaDePago = "";
        public string FechaVence = "";
        public string Beneficiario = ""; 
        public double RetencionTarjeta =0; 
        public double RetIva=0 ;
        public string TipoRetencioIva = ""; 
        public double IdclavedocPago =0;
        public string Habitacion = "";
        public string DocPagoSucursal = ""; 

        public List<cuotaPag> cuotasPago = new List<cuotaPag>();
    }
}
