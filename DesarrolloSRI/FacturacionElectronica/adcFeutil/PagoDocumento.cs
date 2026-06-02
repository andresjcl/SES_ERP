using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DaxDocElectronicos
{
    public class PagoDocumento
    {
        public string Doc_sucursal { get; set; }
        public string Opc_documento { get; set; }
        public int Doc_numero { get; set; }
        public int Pag_Numero { get; set; }
        public DateTime Doc_Fecha { get; set; }
        public int Pag_TipoPago { get; set; }
        public decimal Pag_Valor { get; set; }
        public string Pag_DocInstitucion { get; set; }
        public string Pag_DocPagoTipo { get; set; }
        public string Pag_DocPagoNumero { get; set; }
        public string Pag_NumCtaBanco { get; set; }
        public string Pag_PlanTarjeta { get; set; }
        public string Pag_Autoriza { get; set; }
        public decimal Pag_ComisionTarjeta { get; set; }
        public int Pag_Cuotas { get; set; }
        public string Pag_Descripcion { get; set; }
        public int Pag_Formapago { get; set; }
        public decimal Pag_Interestarjeta { get; set; }
        public string Pag_Idpago { get; set; }
        public DateTime Pag_Vence { get; set; }
        public int? Pag_diferidos { get; set; }
        public DateTime? Pag_FechaUltDiferimiento { get; set; }
        public string pag_Beneficiario { get; set; }
        public string pag_status { get; set; }
        public string pag_DocVoucher { get; set; }
        public int IdClaveDoc { get; set; }
        public decimal? Pag_Retencion { get; set; }
        public decimal? Pag_RetIva { get; set; }
        public string Pag_TipoRet { get; set; }
        public string Pag_Recap { get; set; }
        public DateTime? Pag_FechRecap { get; set; }
        public string Pag_NumDocPago { get; set; }
        public DateTime? Pag_FechaPago { get; set; }
        public decimal Pag_ValorPago { get; set; }
        public decimal Pag_ValorCobrar { get; set; }
        public int IdclaveDocPag { get; set; }
        public string pag_docpagosucursal { get; set; }
        public string SriFormaDePago { get; set; }
        public string SRI_TipoPago { get; set; }
        public int diasPlazo { get; set; }
        public string contadoOcredito { get; set; }
        public int idPagoAdc { get; set; }
        public int NumeroDeCuotas { get; set; }
        public int plazofv { get; set; }
        public string SRI_pagoLocExt { get; set; }
        public string nombreFpagoSri { get; set; }
        public decimal pagEfectivo { get; set; }
        public decimal pagElectronico { get; set; }
        public decimal pagCreditoDebito { get; set; }
        public decimal pagOtros { get; set; }
    }
}
