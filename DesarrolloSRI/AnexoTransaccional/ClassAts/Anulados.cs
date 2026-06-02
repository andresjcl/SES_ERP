using System;
using System.Data;
using System.Data.SqlClient;

namespace ClassAtsDax
{
    //
    public class Anulados
    {
        private System.String _CL_ExportaciónDe= "";
        private System.String _Cl_TipoComprobante= "";
        private System.String _CL_ReferendoDistrito= "";
        private System.String _CL_ReferendoAño= "";
        private System.String _CL_ReferendoRegimen= "";
        private System.String _CL_ReferendoCorrelativo= "";
        private System.String _CL_ReferendoVerificador= "";
        private System.String _CL_NroDocTransporte= "";
        private System.DateTime _CL_FechaTransaccion=new DateTime(1900,1,1);
        private System.String _CL_NroFUE= "";
        private System.Decimal _CL_ValorFOB= 0;
        private System.Decimal _CL_ValorComprobante= 0;
        private System.String _CL_NroSerieCpbteEstablec= "";
        private System.String _CL_NroSerieCpbteEmision= "";
        private System.String _CL_NroSecuencialCpbte= "";
        private System.String _CL_NroAutorizacion= "";
        private System.DateTime _CL_FechaEmision= new DateTime(1900,1,1);
        private System.Decimal _Clave= 0;
        private System.Int32 _CL_mes= 0;
        private System.Int32 _CL_anio= 0;
        private System.String _suc= "";
        private System.String _doc= "";
        private System.String _Cl_TipoId= "";
        private System.String _Cl_CodigoCliente= "";
        private System.Int64 _CL_NroDeComprobantes= 0;
        private System.Decimal _CL_BaseNoGrabaIva= 0;
        private System.Decimal _CL_BaseImpTarCero= 0;
        private System.Decimal _CL_BaseImpGravadaIva= 0;
        private System.Decimal _CL_MontoIva= 0;
        private System.Decimal _CL_ValorRetIva= 0;
        private System.Decimal _CL_ValorRetRenta= 0;
        private System.Decimal _montoIce= 0;
        private System.String _parteRelVtas= "";
        private System.String _CL_SusTributario= "";
        private System.String _CL_TipoIdProveedor= "";
        private System.String _CL_CodigoProveedor= "";
        private System.String _CL_TipoProveedor= "";
        private System.String _CL_ParteRelacionada= "";
        private System.DateTime _CL_FechaRegContable=new DateTime(1900,1,1);
        private System.String _CL_NroSerieEstablec= "";
        private System.String _CL_NroSeriePtoEmision= "";
        private System.String _CL_NroSecuencial= "";
        private System.DateTime _CL_FechaComprobante=new DateTime(1900,1,1);
        private System.Decimal _CL_MontoICE= 0;
        private System.Decimal _CL_MontoRetIvaBienes= 0;
        private System.Decimal _CL_MontoRetIvaServicios= 0;
        private System.Decimal _CL_MontoRetIva100= 0;
        private System.Int32 _CL_pagoLocExt= 0;
        private System.String _CL_pagoPais= "";
        private System.String _CL_dobleTributacion= "";
        private System.String _CL_pagoSujetoRetencion= "";
        private System.String _CL_formaDePago= "";
        private System.String _CL_CodRetFteImpRenta0= "";
        private System.Decimal _CL_BaseImponibleIR0= 0;
        private System.Decimal _CL_CodPorcRetIR0= 0;
        private System.Decimal _CL_MontoRetIR0= 0;
        private System.String _CL_CodRetFteImpRenta1= "";
        private System.Decimal _CL_BaseImponibleIR1= 0;
        private System.Decimal _CL_CodPorcRetIR1= 0;
        private System.Decimal _CL_MontoRetIR1= 0;
        private System.String _CL_NroSerieCpbteRetEstable= "";
        private System.String _CL_NroSerieCpbteRetEmision= "";
        private System.String _CL_NroSecuencialCpbteRet= "";
        private System.String _CL_NroAutorizaCpbteRete= "";
        private System.DateTime _CL_FechaEmisionCpbteRete=new DateTime(1900,1,1);
        private System.String _CL_CodigoTipoModificado= "";
        private System.String _CL_NroSerieModificadoEstab= "";
        private System.String _CL_NroSerieModificadoEmision= "";
        private System.String _CL_NroSecuencialModificado= "";
        private System.String _CL_NroAutorizaModificado= "";
        private System.Decimal _baseImpExe= 0;
        private System.Decimal _valRetBien10= 0;
        private System.String _pagoRegFis= "";
        private System.DateTime _fechaPagoDiv=new DateTime(1900,1,1);
        private System.Decimal _imRentaSoc= 0;
        private System.Int32 _anioUtDiv= 0;
        private System.Decimal _NumCajBan= 0;
        private System.Decimal _PrecCajBan= 0;
        private System.Decimal _imRentaSoc1= 0;
        private System.Int32 _anioUtDiv1= 0;
        private System.Decimal _NumCajBan1= 0;
        private System.Decimal _PrecCajBan1= 0;
        private System.Decimal _CL_CodRetFteImpRenta2= 0;
        private System.Decimal _CL_BaseImponibleIR2= 0;
        private System.Decimal _CL_CodPorcRetIR2= 0;
        private System.DateTime _fechaPagoDiv2=new DateTime(1900,1,1);
        private System.Decimal _imRentaSoc2= 0;
        private System.Int32 _anioUtDiv2= 0;
        private System.Decimal _NumCajBan2= 0;
        private System.Decimal _PrecCajBan2= 0;
        private System.Decimal _CL_CodRetFteImpRenta3= 0;
        private System.Decimal _CL_BaseImponibleIR3= 0;
        private System.Decimal _CL_CodPorcRetIR3= 0;
        private System.DateTime _fechaPagoDiv3=new DateTime(1900,1,1);
        private System.Decimal _imRentaSoc3= 0;
        private System.Int32 _anioUtDiv3= 0;
        private System.Decimal _NumCajBan3= 0;
        private System.Decimal _PrecCajBan3= 0;
        private System.String _tipoComprobanteReemb= "";
        private System.String _tpIdProvReemb= "";
        private System.String _idProvReemb= "";
        private System.String _establecimientoReemb= "";
        private System.String _puntoEmisionReemb= "";
        private System.Decimal _secuencialReemb= 0;
        private System.DateTime _fechaEmisionReemb=new DateTime(1900,1,1);
        private System.String _autorizacionReemb= "";
        private System.Decimal _baseImponibleReemb= 0;
        private System.Decimal _baseImpGravReemb= 0;
        private System.Decimal _baseNoGraIvaReemb= 0;
        private System.Decimal _baseImpExeReemb= 0;
        private System.Decimal _montoIceRemb= 0;
        private System.Decimal _montoIvaRemb= 0;
        private System.Decimal _valRetBien20= 0;
        private System.DateTime _fechaPagoDiv1=new DateTime(1900,1,1);
        private System.Decimal _valRetServ20= 0;
        private System.Decimal _codRetAir2= 0;
        private System.Decimal _baseImpAir2= 0;
        private System.Decimal _porcentajeAir2= 0;
        private System.Decimal _valRetAir2= 0;
        private System.Decimal _codRetAir3= 0;
        private System.Decimal _baseImpAir3= 0;
        private System.Decimal _porcentajeAir3= 0;
        private System.Decimal _valRetAir3= 0;
        private System.Decimal _totbasesImpReemb= 0;
        private System.Decimal _idclavedoc= 0;
        private System.String _doc_sucursal= "";
        private System.String _opc_documento= "";
        private System.String _CL_NroSerieEstableci= "";
        private System.String _CL_NroSerieEmision= "";
        private System.String _CL_NroSecuencialDesde= "";
        private System.String _CL_NroSecuencialHasta= "";
        private System.Int32 _Anio= 0;
        private System.Int32 _Mes= 0;
        private string ajustarAncho(string cadena, int ancho)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
            return (cadena + sb.ToString()).Substring(0, ancho).Trim();
        }
        public System.String CL_ExportaciónDe
        {
            get
            {
                return ajustarAncho(_CL_ExportaciónDe, 50);
            }
            set
            {
                _CL_ExportaciónDe = value;
            }
        }
        public System.String Cl_TipoComprobante
        {
            get
            {
                return ajustarAncho(_Cl_TipoComprobante, 2);
            }
            set
            {
                _Cl_TipoComprobante = value;
            }
        }
        public System.String CL_ReferendoDistrito
        {
            get
            {
                return ajustarAncho(_CL_ReferendoDistrito, 50);
            }
            set
            {
                _CL_ReferendoDistrito = value;
            }
        }
        public System.String CL_ReferendoAño
        {
            get
            {
                return ajustarAncho(_CL_ReferendoAño, 50);
            }
            set
            {
                _CL_ReferendoAño = value;
            }
        }
        public System.String CL_ReferendoRegimen
        {
            get
            {
                return ajustarAncho(_CL_ReferendoRegimen, 50);
            }
            set
            {
                _CL_ReferendoRegimen = value;
            }
        }
        public System.String CL_ReferendoCorrelativo
        {
            get
            {
                return ajustarAncho(_CL_ReferendoCorrelativo, 50);
            }
            set
            {
                _CL_ReferendoCorrelativo = value;
            }
        }
        public System.String CL_ReferendoVerificador
        {
            get
            {
                return ajustarAncho(_CL_ReferendoVerificador, 50);
            }
            set
            {
                _CL_ReferendoVerificador = value;
            }
        }
        public System.String CL_NroDocTransporte
        {
            get
            {
                return ajustarAncho(_CL_NroDocTransporte, 50);
            }
            set
            {
                _CL_NroDocTransporte = value;
            }
        }
        public System.DateTime CL_FechaTransaccion
        {
            get
            {
                return _CL_FechaTransaccion;
            }
            set
            {
                _CL_FechaTransaccion = value;
            }
        }
        public System.String CL_NroFUE
        {
            get
            {
                return ajustarAncho(_CL_NroFUE, 50);
            }
            set
            {
                _CL_NroFUE = value;
            }
        }
        public System.Decimal CL_ValorFOB
        {
            get
            {
                return _CL_ValorFOB;
            }
            set
            {
                _CL_ValorFOB = value;
            }
        }
        public System.Decimal CL_ValorComprobante
        {
            get
            {
                return _CL_ValorComprobante;
            }
            set
            {
                _CL_ValorComprobante = value;
            }
        }
        public System.String CL_NroSerieCpbteEstablec
        {
            get
            {
                return ajustarAncho(_CL_NroSerieCpbteEstablec, 50);
            }
            set
            {
                _CL_NroSerieCpbteEstablec = value;
            }
        }
        public System.String CL_NroSerieCpbteEmision
        {
            get
            {
                return ajustarAncho(_CL_NroSerieCpbteEmision, 50);
            }
            set
            {
                _CL_NroSerieCpbteEmision = value;
            }
        }
        public System.String CL_NroSecuencialCpbte
        {
            get
            {
                return ajustarAncho(_CL_NroSecuencialCpbte, 50);
            }
            set
            {
                _CL_NroSecuencialCpbte = value;
            }
        }
        public System.String CL_NroAutorizacion
        {
            get
            {
                return ajustarAncho(_CL_NroAutorizacion, 50);
            }
            set
            {
                _CL_NroAutorizacion = value;
            }
        }
        public System.DateTime CL_FechaEmision
        {
            get
            {
                return _CL_FechaEmision;
            }
            set
            {
                _CL_FechaEmision = value;
            }
        }
        public System.Decimal Clave
        {
            get
            {
                return _Clave;
            }
            set
            {
                _Clave = value;
            }
        }
        public System.Int32 CL_mes
        {
            get
            {
                return _CL_mes;
            }
            set
            {
                _CL_mes = value;
            }
        }
        public System.Int32 CL_anio
        {
            get
            {
                return _CL_anio;
            }
            set
            {
                _CL_anio = value;
            }
        }
        public System.String suc
        {
            get
            {
                return ajustarAncho(_suc, 3);
            }
            set
            {
                _suc = value;
            }
        }
        public System.String doc
        {
            get
            {
                return ajustarAncho(_doc, 3);
            }
            set
            {
                _doc = value;
            }
        }
        public System.String Cl_TipoId
        {
            get
            {
                return ajustarAncho(_Cl_TipoId, 50);
            }
            set
            {
                _Cl_TipoId = value;
            }
        }
        public System.String Cl_CodigoCliente
        {
            get
            {
                return ajustarAncho(_Cl_CodigoCliente, 50);
            }
            set
            {
                _Cl_CodigoCliente = value;
            }
        }
        public System.Int64 CL_NroDeComprobantes
        {
            get
            {
                return _CL_NroDeComprobantes;
            }
            set
            {
                _CL_NroDeComprobantes = value;
            }
        }
        public System.Decimal CL_BaseNoGrabaIva
        {
            get
            {
                return _CL_BaseNoGrabaIva;
            }
            set
            {
                _CL_BaseNoGrabaIva = value;
            }
        }
        public System.Decimal CL_BaseImpTarCero
        {
            get
            {
                return _CL_BaseImpTarCero;
            }
            set
            {
                _CL_BaseImpTarCero = value;
            }
        }
        public System.Decimal CL_BaseImpGravadaIva
        {
            get
            {
                return _CL_BaseImpGravadaIva;
            }
            set
            {
                _CL_BaseImpGravadaIva = value;
            }
        }
        public System.Decimal CL_MontoIva
        {
            get
            {
                return _CL_MontoIva;
            }
            set
            {
                _CL_MontoIva = value;
            }
        }
        public System.Decimal CL_ValorRetIva
        {
            get
            {
                return _CL_ValorRetIva;
            }
            set
            {
                _CL_ValorRetIva = value;
            }
        }
        public System.Decimal CL_ValorRetRenta
        {
            get
            {
                return _CL_ValorRetRenta;
            }
            set
            {
                _CL_ValorRetRenta = value;
            }
        }
        public System.Decimal montoIce
        {
            get
            {
                return _montoIce;
            }
            set
            {
                _montoIce = value;
            }
        }
        public System.String parteRelVtas
        {
            get
            {
                return ajustarAncho(_parteRelVtas, 2);
            }
            set
            {
                _parteRelVtas = value;
            }
        }
        public System.String CL_SusTributario
        {
            get
            {
                return ajustarAncho(_CL_SusTributario, 50);
            }
            set
            {
                _CL_SusTributario = value;
            }
        }
        public System.String CL_TipoIdProveedor
        {
            get
            {
                return ajustarAncho(_CL_TipoIdProveedor, 50);
            }
            set
            {
                _CL_TipoIdProveedor = value;
            }
        }
        public System.String CL_CodigoProveedor
        {
            get
            {
                return ajustarAncho(_CL_CodigoProveedor, 50);
            }
            set
            {
                _CL_CodigoProveedor = value;
            }
        }
        public System.String CL_TipoProveedor
        {
            get
            {
                return ajustarAncho(_CL_TipoProveedor, 3);
            }
            set
            {
                _CL_TipoProveedor = value;
            }
        }
        public System.String CL_ParteRelacionada
        {
            get
            {
                return ajustarAncho(_CL_ParteRelacionada, 3);
            }
            set
            {
                _CL_ParteRelacionada = value;
            }
        }
        public System.DateTime CL_FechaRegContable
        {
            get
            {
                return _CL_FechaRegContable;
            }
            set
            {
                _CL_FechaRegContable = value;
            }
        }
        public System.String CL_NroSerieEstablec
        {
            get
            {
                return ajustarAncho(_CL_NroSerieEstablec, 50);
            }
            set
            {
                _CL_NroSerieEstablec = value;
            }
        }
        public System.String CL_NroSeriePtoEmision
        {
            get
            {
                return ajustarAncho(_CL_NroSeriePtoEmision, 50);
            }
            set
            {
                _CL_NroSeriePtoEmision = value;
            }
        }
        public System.String CL_NroSecuencial
        {
            get
            {
                return ajustarAncho(_CL_NroSecuencial, 20);
            }
            set
            {
                _CL_NroSecuencial = value;
            }
        }
        public System.DateTime CL_FechaComprobante
        {
            get
            {
                return _CL_FechaComprobante;
            }
            set
            {
                _CL_FechaComprobante = value;
            }
        }
        public System.Decimal CL_MontoICE
        {
            get
            {
                return _CL_MontoICE;
            }
            set
            {
                _CL_MontoICE = value;
            }
        }
        public System.Decimal CL_MontoRetIvaBienes
        {
            get
            {
                return _CL_MontoRetIvaBienes;
            }
            set
            {
                _CL_MontoRetIvaBienes = value;
            }
        }
        public System.Decimal CL_MontoRetIvaServicios
        {
            get
            {
                return _CL_MontoRetIvaServicios;
            }
            set
            {
                _CL_MontoRetIvaServicios = value;
            }
        }
        public System.Decimal CL_MontoRetIva100
        {
            get
            {
                return _CL_MontoRetIva100;
            }
            set
            {
                _CL_MontoRetIva100 = value;
            }
        }
        public System.Int32 CL_pagoLocExt
        {
            get
            {
                return _CL_pagoLocExt;
            }
            set
            {
                _CL_pagoLocExt = value;
            }
        }
        public System.String CL_pagoPais
        {
            get
            {
                return ajustarAncho(_CL_pagoPais, 20);
            }
            set
            {
                _CL_pagoPais = value;
            }
        }
        public System.String CL_dobleTributacion
        {
            get
            {
                return ajustarAncho(_CL_dobleTributacion, 10);
            }
            set
            {
                _CL_dobleTributacion = value;
            }
        }
        public System.String CL_pagoSujetoRetencion
        {
            get
            {
                return ajustarAncho(_CL_pagoSujetoRetencion, 10);
            }
            set
            {
                _CL_pagoSujetoRetencion = value;
            }
        }
        public System.String CL_formaDePago
        {
            get
            {
                return ajustarAncho(_CL_formaDePago, 50);
            }
            set
            {
                _CL_formaDePago = value;
            }
        }
        public System.String CL_CodRetFteImpRenta0
        {
            get
            {
                return ajustarAncho(_CL_CodRetFteImpRenta0, 5);
            }
            set
            {
                _CL_CodRetFteImpRenta0 = value;
            }
        }
        public System.Decimal CL_BaseImponibleIR0
        {
            get
            {
                return _CL_BaseImponibleIR0;
            }
            set
            {
                _CL_BaseImponibleIR0 = value;
            }
        }
        public System.Decimal CL_CodPorcRetIR0
        {
            get
            {
                return _CL_CodPorcRetIR0;
            }
            set
            {
                _CL_CodPorcRetIR0 = value;
            }
        }
        public System.Decimal CL_MontoRetIR0
        {
            get
            {
                return _CL_MontoRetIR0;
            }
            set
            {
                _CL_MontoRetIR0 = value;
            }
        }
        public System.String CL_CodRetFteImpRenta1
        {
            get
            {
                return ajustarAncho(_CL_CodRetFteImpRenta1, 5);
            }
            set
            {
                _CL_CodRetFteImpRenta1 = value;
            }
        }
        public System.Decimal CL_BaseImponibleIR1
        {
            get
            {
                return _CL_BaseImponibleIR1;
            }
            set
            {
                _CL_BaseImponibleIR1 = value;
            }
        }
        public System.Decimal CL_CodPorcRetIR1
        {
            get
            {
                return _CL_CodPorcRetIR1;
            }
            set
            {
                _CL_CodPorcRetIR1 = value;
            }
        }
        public System.Decimal CL_MontoRetIR1
        {
            get
            {
                return _CL_MontoRetIR1;
            }
            set
            {
                _CL_MontoRetIR1 = value;
            }
        }
        public System.String CL_NroSerieCpbteRetEstable
        {
            get
            {
                return ajustarAncho(_CL_NroSerieCpbteRetEstable, 3);
            }
            set
            {
                _CL_NroSerieCpbteRetEstable = value;
            }
        }
        public System.String CL_NroSerieCpbteRetEmision
        {
            get
            {
                return ajustarAncho(_CL_NroSerieCpbteRetEmision, 3);
            }
            set
            {
                _CL_NroSerieCpbteRetEmision = value;
            }
        }
        public System.String CL_NroSecuencialCpbteRet
        {
            get
            {
                return ajustarAncho(_CL_NroSecuencialCpbteRet, 7);
            }
            set
            {
                _CL_NroSecuencialCpbteRet = value;
            }
        }
        public System.String CL_NroAutorizaCpbteRete
        {
            get
            {
                return ajustarAncho(_CL_NroAutorizaCpbteRete, 50);
            }
            set
            {
                _CL_NroAutorizaCpbteRete = value;
            }
        }
        public System.DateTime CL_FechaEmisionCpbteRete
        {
            get
            {
                return _CL_FechaEmisionCpbteRete;
            }
            set
            {
                _CL_FechaEmisionCpbteRete = value;
            }
        }
        public System.String CL_CodigoTipoModificado
        {
            get
            {
                return ajustarAncho(_CL_CodigoTipoModificado, 2);
            }
            set
            {
                _CL_CodigoTipoModificado = value;
            }
        }
        public System.String CL_NroSerieModificadoEstab
        {
            get
            {
                return ajustarAncho(_CL_NroSerieModificadoEstab, 3);
            }
            set
            {
                _CL_NroSerieModificadoEstab = value;
            }
        }
        public System.String CL_NroSerieModificadoEmision
        {
            get
            {
                return ajustarAncho(_CL_NroSerieModificadoEmision, 3);
            }
            set
            {
                _CL_NroSerieModificadoEmision = value;
            }
        }
        public System.String CL_NroSecuencialModificado
        {
            get
            {
                return ajustarAncho(_CL_NroSecuencialModificado, 20);
            }
            set
            {
                _CL_NroSecuencialModificado = value;
            }
        }
        public System.String CL_NroAutorizaModificado
        {
            get
            {
                return ajustarAncho(_CL_NroAutorizaModificado, 50);
            }
            set
            {
                _CL_NroAutorizaModificado = value;
            }
        }
        public System.Decimal baseImpExe
        {
            get
            {
                return _baseImpExe;
            }
            set
            {
                _baseImpExe = value;
            }
        }
        public System.Decimal valRetBien10
        {
            get
            {
                return _valRetBien10;
            }
            set
            {
                _valRetBien10 = value;
            }
        }
        public System.String pagoRegFis
        {
            get
            {
                return ajustarAncho(_pagoRegFis, 2);
            }
            set
            {
                _pagoRegFis = value;
            }
        }
        public System.DateTime fechaPagoDiv
        {
            get
            {
                return _fechaPagoDiv;
            }
            set
            {
                _fechaPagoDiv = value;
            }
        }
        public System.Decimal imRentaSoc
        {
            get
            {
                return _imRentaSoc;
            }
            set
            {
                _imRentaSoc = value;
            }
        }
        public System.Int32 anioUtDiv
        {
            get
            {
                return _anioUtDiv;
            }
            set
            {
                _anioUtDiv = value;
            }
        }
        public System.Decimal NumCajBan
        {
            get
            {
                return _NumCajBan;
            }
            set
            {
                _NumCajBan = value;
            }
        }
        public System.Decimal PrecCajBan
        {
            get
            {
                return _PrecCajBan;
            }
            set
            {
                _PrecCajBan = value;
            }
        }
        public System.Decimal imRentaSoc1
        {
            get
            {
                return _imRentaSoc1;
            }
            set
            {
                _imRentaSoc1 = value;
            }
        }
        public System.Int32 anioUtDiv1
        {
            get
            {
                return _anioUtDiv1;
            }
            set
            {
                _anioUtDiv1 = value;
            }
        }
        public System.Decimal NumCajBan1
        {
            get
            {
                return _NumCajBan1;
            }
            set
            {
                _NumCajBan1 = value;
            }
        }
        public System.Decimal PrecCajBan1
        {
            get
            {
                return _PrecCajBan1;
            }
            set
            {
                _PrecCajBan1 = value;
            }
        }
        public System.Decimal CL_CodRetFteImpRenta2
        {
            get
            {
                return _CL_CodRetFteImpRenta2;
            }
            set
            {
                _CL_CodRetFteImpRenta2 = value;
            }
        }
        public System.Decimal CL_BaseImponibleIR2
        {
            get
            {
                return _CL_BaseImponibleIR2;
            }
            set
            {
                _CL_BaseImponibleIR2 = value;
            }
        }
        public System.Decimal CL_CodPorcRetIR2
        {
            get
            {
                return _CL_CodPorcRetIR2;
            }
            set
            {
                _CL_CodPorcRetIR2 = value;
            }
        }
        public System.DateTime fechaPagoDiv2
        {
            get
            {
                return _fechaPagoDiv2;
            }
            set
            {
                _fechaPagoDiv2 = value;
            }
        }
        public System.Decimal imRentaSoc2
        {
            get
            {
                return _imRentaSoc2;
            }
            set
            {
                _imRentaSoc2 = value;
            }
        }
        public System.Int32 anioUtDiv2
        {
            get
            {
                return _anioUtDiv2;
            }
            set
            {
                _anioUtDiv2 = value;
            }
        }
        public System.Decimal NumCajBan2
        {
            get
            {
                return _NumCajBan2;
            }
            set
            {
                _NumCajBan2 = value;
            }
        }
        public System.Decimal PrecCajBan2
        {
            get
            {
                return _PrecCajBan2;
            }
            set
            {
                _PrecCajBan2 = value;
            }
        }
        public System.Decimal CL_CodRetFteImpRenta3
        {
            get
            {
                return _CL_CodRetFteImpRenta3;
            }
            set
            {
                _CL_CodRetFteImpRenta3 = value;
            }
        }
        public System.Decimal CL_BaseImponibleIR3
        {
            get
            {
                return _CL_BaseImponibleIR3;
            }
            set
            {
                _CL_BaseImponibleIR3 = value;
            }
        }
        public System.Decimal CL_CodPorcRetIR3
        {
            get
            {
                return _CL_CodPorcRetIR3;
            }
            set
            {
                _CL_CodPorcRetIR3 = value;
            }
        }
        public System.DateTime fechaPagoDiv3
        {
            get
            {
                return _fechaPagoDiv3;
            }
            set
            {
                _fechaPagoDiv3 = value;
            }
        }
        public System.Decimal imRentaSoc3
        {
            get
            {
                return _imRentaSoc3;
            }
            set
            {
                _imRentaSoc3 = value;
            }
        }
        public System.Int32 anioUtDiv3
        {
            get
            {
                return _anioUtDiv3;
            }
            set
            {
                _anioUtDiv3 = value;
            }
        }
        public System.Decimal NumCajBan3
        {
            get
            {
                return _NumCajBan3;
            }
            set
            {
                _NumCajBan3 = value;
            }
        }
        public System.Decimal PrecCajBan3
        {
            get
            {
                return _PrecCajBan3;
            }
            set
            {
                _PrecCajBan3 = value;
            }
        }
        public System.String tipoComprobanteReemb
        {
            get
            {
                return ajustarAncho(_tipoComprobanteReemb, 3);
            }
            set
            {
                _tipoComprobanteReemb = value;
            }
        }
        public System.String tpIdProvReemb
        {
            get
            {
                return ajustarAncho(_tpIdProvReemb, 2);
            }
            set
            {
                _tpIdProvReemb = value;
            }
        }
        public System.String idProvReemb
        {
            get
            {
                return ajustarAncho(_idProvReemb, 15);
            }
            set
            {
                _idProvReemb = value;
            }
        }
        public System.String establecimientoReemb
        {
            get
            {
                return ajustarAncho(_establecimientoReemb, 3);
            }
            set
            {
                _establecimientoReemb = value;
            }
        }
        public System.String puntoEmisionReemb
        {
            get
            {
                return ajustarAncho(_puntoEmisionReemb, 3);
            }
            set
            {
                _puntoEmisionReemb = value;
            }
        }
        public System.Decimal secuencialReemb
        {
            get
            {
                return _secuencialReemb;
            }
            set
            {
                _secuencialReemb = value;
            }
        }
        public System.DateTime fechaEmisionReemb
        {
            get
            {
                return _fechaEmisionReemb;
            }
            set
            {
                _fechaEmisionReemb = value;
            }
        }
        public System.String autorizacionReemb
        {
            get
            {
                return ajustarAncho(_autorizacionReemb, 50);
            }
            set
            {
                _autorizacionReemb = value;
            }
        }
        public System.Decimal baseImponibleReemb
        {
            get
            {
                return _baseImponibleReemb;
            }
            set
            {
                _baseImponibleReemb = value;
            }
        }
        public System.Decimal baseImpGravReemb
        {
            get
            {
                return _baseImpGravReemb;
            }
            set
            {
                _baseImpGravReemb = value;
            }
        }
        public System.Decimal baseNoGraIvaReemb
        {
            get
            {
                return _baseNoGraIvaReemb;
            }
            set
            {
                _baseNoGraIvaReemb = value;
            }
        }
        public System.Decimal baseImpExeReemb
        {
            get
            {
                return _baseImpExeReemb;
            }
            set
            {
                _baseImpExeReemb = value;
            }
        }
        public System.Decimal montoIceRemb
        {
            get
            {
                return _montoIceRemb;
            }
            set
            {
                _montoIceRemb = value;
            }
        }
        public System.Decimal montoIvaRemb
        {
            get
            {
                return _montoIvaRemb;
            }
            set
            {
                _montoIvaRemb = value;
            }
        }
        public System.Decimal valRetBien20
        {
            get
            {
                return _valRetBien20;
            }
            set
            {
                _valRetBien20 = value;
            }
        }
        public System.DateTime fechaPagoDiv1
        {
            get
            {
                return _fechaPagoDiv1;
            }
            set
            {
                _fechaPagoDiv1 = value;
            }
        }
        public System.Decimal valRetServ20
        {
            get
            {
                return _valRetServ20;
            }
            set
            {
                _valRetServ20 = value;
            }
        }
        public System.Decimal codRetAir2
        {
            get
            {
                return _codRetAir2;
            }
            set
            {
                _codRetAir2 = value;
            }
        }
        public System.Decimal baseImpAir2
        {
            get
            {
                return _baseImpAir2;
            }
            set
            {
                _baseImpAir2 = value;
            }
        }
        public System.Decimal porcentajeAir2
        {
            get
            {
                return _porcentajeAir2;
            }
            set
            {
                _porcentajeAir2 = value;
            }
        }
        public System.Decimal valRetAir2
        {
            get
            {
                return _valRetAir2;
            }
            set
            {
                _valRetAir2 = value;
            }
        }
        public System.Decimal codRetAir3
        {
            get
            {
                return _codRetAir3;
            }
            set
            {
                _codRetAir3 = value;
            }
        }
        public System.Decimal baseImpAir3
        {
            get
            {
                return _baseImpAir3;
            }
            set
            {
                _baseImpAir3 = value;
            }
        }
        public System.Decimal porcentajeAir3
        {
            get
            {
                return _porcentajeAir3;
            }
            set
            {
                _porcentajeAir3 = value;
            }
        }
        public System.Decimal valRetAir3
        {
            get
            {
                return _valRetAir3;
            }
            set
            {
                _valRetAir3 = value;
            }
        }
        public System.Decimal totbasesImpReemb
        {
            get
            {
                return _totbasesImpReemb;
            }
            set
            {
                _totbasesImpReemb = value;
            }
        }
        public System.Decimal idclavedoc
        {
            get
            {
                return _idclavedoc;
            }
            set
            {
                _idclavedoc = value;
            }
        }
        public System.String doc_sucursal
        {
            get
            {
                return ajustarAncho(_doc_sucursal, 5);
            }
            set
            {
                _doc_sucursal = value;
            }
        }
        public System.String opc_documento
        {
            get
            {
                return ajustarAncho(_opc_documento, 5);
            }
            set
            {
                _opc_documento = value;
            }
        }
        public System.String CL_NroSerieEstableci
        {
            get
            {
                return ajustarAncho(_CL_NroSerieEstableci, 3);
            }
            set
            {
                _CL_NroSerieEstableci = value;
            }
        }
        public System.String CL_NroSerieEmision
        {
            get
            {
                return ajustarAncho(_CL_NroSerieEmision, 3);
            }
            set
            {
                _CL_NroSerieEmision = value;
            }
        }
        public System.String CL_NroSecuencialDesde
        {
            get
            {
                return ajustarAncho(_CL_NroSecuencialDesde, 50);
            }
            set
            {
                _CL_NroSecuencialDesde = value;
            }
        }
        public System.String CL_NroSecuencialHasta
        {
            get
            {
                return ajustarAncho(_CL_NroSecuencialHasta, 50);
            }
            set
            {
                _CL_NroSecuencialHasta = value;
            }
        }
        public System.Int32 Anio
        {
            get
            {
                return _Anio;
            }
            set
            {
                _Anio = value;
            }
        }
        public System.Int32 Mes
        {
            get
            {
                return _Mes;
            }
            set
            {
                _Mes = value;
            }
        }
        //
        public string this[int index]
        {
            // Devuelve el contenido del campo indicado en index
            // (el índice corresponde con la columna de la tabla)
            get
            {
                if (index == 0)
                {
                    return this.CL_ExportaciónDe.ToString();
                }
                else if (index == 1)
                {
                    return this.Cl_TipoComprobante.ToString();
                }
                else if (index == 2)
                {
                    return this.CL_ReferendoDistrito.ToString();
                }
                else if (index == 3)
                {
                    return this.CL_ReferendoAño.ToString();
                }
                else if (index == 4)
                {
                    return this.CL_ReferendoRegimen.ToString();
                }
                else if (index == 5)
                {
                    return this.CL_ReferendoCorrelativo.ToString();
                }
                else if (index == 6)
                {
                    return this.CL_ReferendoVerificador.ToString();
                }
                else if (index == 7)
                {
                    return this.CL_NroDocTransporte.ToString();
                }
                else if (index == 8)
                {
                    return this.CL_FechaTransaccion.ToString();
                }
                else if (index == 9)
                {
                    return this.CL_NroFUE.ToString();
                }
                else if (index == 10)
                {
                    return this.CL_ValorFOB.ToString();
                }
                else if (index == 11)
                {
                    return this.CL_ValorComprobante.ToString();
                }
                else if (index == 12)
                {
                    return this.CL_NroSerieCpbteEstablec.ToString();
                }
                else if (index == 13)
                {
                    return this.CL_NroSerieCpbteEmision.ToString();
                }
                else if (index == 14)
                {
                    return this.CL_NroSecuencialCpbte.ToString();
                }
                else if (index == 15)
                {
                    return this.CL_NroAutorizacion.ToString();
                }
                else if (index == 16)
                {
                    return this.CL_FechaEmision.ToString();
                }
                else if (index == 17)
                {
                    return this.Clave.ToString();
                }
                else if (index == 18)
                {
                    return this.CL_mes.ToString();
                }
                else if (index == 19)
                {
                    return this.CL_anio.ToString();
                }
                else if (index == 20)
                {
                    return this.suc.ToString();
                }
                else if (index == 21)
                {
                    return this.doc.ToString();
                }
                else if (index == 22)
                {
                    return this.Cl_TipoId.ToString();
                }
                else if (index == 23)
                {
                    return this.Cl_CodigoCliente.ToString();
                }
                else if (index == 24)
                {
                    return this.CL_NroDeComprobantes.ToString();
                }
                else if (index == 25)
                {
                    return this.CL_BaseNoGrabaIva.ToString();
                }
                else if (index == 26)
                {
                    return this.CL_BaseImpTarCero.ToString();
                }
                else if (index == 27)
                {
                    return this.CL_BaseImpGravadaIva.ToString();
                }
                else if (index == 28)
                {
                    return this.CL_MontoIva.ToString();
                }
                else if (index == 29)
                {
                    return this.CL_ValorRetIva.ToString();
                }
                else if (index == 30)
                {
                    return this.CL_ValorRetRenta.ToString();
                }
                else if (index == 31)
                {
                    return this.montoIce.ToString();
                }
                else if (index == 32)
                {
                    return this.parteRelVtas.ToString();
                }
                else if (index == 33)
                {
                    return this.CL_SusTributario.ToString();
                }
                else if (index == 34)
                {
                    return this.CL_TipoIdProveedor.ToString();
                }
                else if (index == 35)
                {
                    return this.CL_CodigoProveedor.ToString();
                }
                else if (index == 36)
                {
                    return this.CL_TipoProveedor.ToString();
                }
                else if (index == 37)
                {
                    return this.CL_ParteRelacionada.ToString();
                }
                else if (index == 38)
                {
                    return this.CL_FechaRegContable.ToString();
                }
                else if (index == 39)
                {
                    return this.CL_NroSerieEstablec.ToString();
                }
                else if (index == 40)
                {
                    return this.CL_NroSeriePtoEmision.ToString();
                }
                else if (index == 41)
                {
                    return this.CL_NroSecuencial.ToString();
                }
                else if (index == 42)
                {
                    return this.CL_FechaComprobante.ToString();
                }
                else if (index == 43)
                {
                    return this.CL_MontoICE.ToString();
                }
                else if (index == 44)
                {
                    return this.CL_MontoRetIvaBienes.ToString();
                }
                else if (index == 45)
                {
                    return this.CL_MontoRetIvaServicios.ToString();
                }
                else if (index == 46)
                {
                    return this.CL_MontoRetIva100.ToString();
                }
                else if (index == 47)
                {
                    return this.CL_pagoLocExt.ToString();
                }
                else if (index == 48)
                {
                    return this.CL_pagoPais.ToString();
                }
                else if (index == 49)
                {
                    return this.CL_dobleTributacion.ToString();
                }
                else if (index == 50)
                {
                    return this.CL_pagoSujetoRetencion.ToString();
                }
                else if (index == 51)
                {
                    return this.CL_formaDePago.ToString();
                }
                else if (index == 52)
                {
                    return this.CL_CodRetFteImpRenta0.ToString();
                }
                else if (index == 53)
                {
                    return this.CL_BaseImponibleIR0.ToString();
                }
                else if (index == 54)
                {
                    return this.CL_CodPorcRetIR0.ToString();
                }
                else if (index == 55)
                {
                    return this.CL_MontoRetIR0.ToString();
                }
                else if (index == 56)
                {
                    return this.CL_CodRetFteImpRenta1.ToString();
                }
                else if (index == 57)
                {
                    return this.CL_BaseImponibleIR1.ToString();
                }
                else if (index == 58)
                {
                    return this.CL_CodPorcRetIR1.ToString();
                }
                else if (index == 59)
                {
                    return this.CL_MontoRetIR1.ToString();
                }
                else if (index == 60)
                {
                    return this.CL_NroSerieCpbteRetEstable.ToString();
                }
                else if (index == 61)
                {
                    return this.CL_NroSerieCpbteRetEmision.ToString();
                }
                else if (index == 62)
                {
                    return this.CL_NroSecuencialCpbteRet.ToString();
                }
                else if (index == 63)
                {
                    return this.CL_NroAutorizaCpbteRete.ToString();
                }
                else if (index == 64)
                {
                    return this.CL_FechaEmisionCpbteRete.ToString();
                }
                else if (index == 65)
                {
                    return this.CL_CodigoTipoModificado.ToString();
                }
                else if (index == 66)
                {
                    return this.CL_NroSerieModificadoEstab.ToString();
                }
                else if (index == 67)
                {
                    return this.CL_NroSerieModificadoEmision.ToString();
                }
                else if (index == 68)
                {
                    return this.CL_NroSecuencialModificado.ToString();
                }
                else if (index == 69)
                {
                    return this.CL_NroAutorizaModificado.ToString();
                }
                else if (index == 70)
                {
                    return this.baseImpExe.ToString();
                }
                else if (index == 71)
                {
                    return this.valRetBien10.ToString();
                }
                else if (index == 72)
                {
                    return this.pagoRegFis.ToString();
                }
                else if (index == 73)
                {
                    return this.fechaPagoDiv.ToString();
                }
                else if (index == 74)
                {
                    return this.imRentaSoc.ToString();
                }
                else if (index == 75)
                {
                    return this.anioUtDiv.ToString();
                }
                else if (index == 76)
                {
                    return this.NumCajBan.ToString();
                }
                else if (index == 77)
                {
                    return this.PrecCajBan.ToString();
                }
                else if (index == 78)
                {
                    return this.imRentaSoc1.ToString();
                }
                else if (index == 79)
                {
                    return this.anioUtDiv1.ToString();
                }
                else if (index == 80)
                {
                    return this.NumCajBan1.ToString();
                }
                else if (index == 81)
                {
                    return this.PrecCajBan1.ToString();
                }
                else if (index == 82)
                {
                    return this.CL_CodRetFteImpRenta2.ToString();
                }
                else if (index == 83)
                {
                    return this.CL_BaseImponibleIR2.ToString();
                }
                else if (index == 84)
                {
                    return this.CL_CodPorcRetIR2.ToString();
                }
                else if (index == 85)
                {
                    return this.fechaPagoDiv2.ToString();
                }
                else if (index == 86)
                {
                    return this.imRentaSoc2.ToString();
                }
                else if (index == 87)
                {
                    return this.anioUtDiv2.ToString();
                }
                else if (index == 88)
                {
                    return this.NumCajBan2.ToString();
                }
                else if (index == 89)
                {
                    return this.PrecCajBan2.ToString();
                }
                else if (index == 90)
                {
                    return this.CL_CodRetFteImpRenta3.ToString();
                }
                else if (index == 91)
                {
                    return this.CL_BaseImponibleIR3.ToString();
                }
                else if (index == 92)
                {
                    return this.CL_CodPorcRetIR3.ToString();
                }
                else if (index == 93)
                {
                    return this.fechaPagoDiv3.ToString();
                }
                else if (index == 94)
                {
                    return this.imRentaSoc3.ToString();
                }
                else if (index == 95)
                {
                    return this.anioUtDiv3.ToString();
                }
                else if (index == 96)
                {
                    return this.NumCajBan3.ToString();
                }
                else if (index == 97)
                {
                    return this.PrecCajBan3.ToString();
                }
                else if (index == 98)
                {
                    return this.tipoComprobanteReemb.ToString();
                }
                else if (index == 99)
                {
                    return this.tpIdProvReemb.ToString();
                }
                else if (index == 100)
                {
                    return this.idProvReemb.ToString();
                }
                else if (index == 101)
                {
                    return this.establecimientoReemb.ToString();
                }
                else if (index == 102)
                {
                    return this.puntoEmisionReemb.ToString();
                }
                else if (index == 103)
                {
                    return this.secuencialReemb.ToString();
                }
                else if (index == 104)
                {
                    return this.fechaEmisionReemb.ToString();
                }
                else if (index == 105)
                {
                    return this.autorizacionReemb.ToString();
                }
                else if (index == 106)
                {
                    return this.baseImponibleReemb.ToString();
                }
                else if (index == 107)
                {
                    return this.baseImpGravReemb.ToString();
                }
                else if (index == 108)
                {
                    return this.baseNoGraIvaReemb.ToString();
                }
                else if (index == 109)
                {
                    return this.baseImpExeReemb.ToString();
                }
                else if (index == 110)
                {
                    return this.montoIceRemb.ToString();
                }
                else if (index == 111)
                {
                    return this.montoIvaRemb.ToString();
                }
                else if (index == 112)
                {
                    return this.valRetBien20.ToString();
                }
                else if (index == 113)
                {
                    return this.fechaPagoDiv1.ToString();
                }
                else if (index == 114)
                {
                    return this.valRetServ20.ToString();
                }
                else if (index == 115)
                {
                    return this.codRetAir2.ToString();
                }
                else if (index == 116)
                {
                    return this.baseImpAir2.ToString();
                }
                else if (index == 117)
                {
                    return this.porcentajeAir2.ToString();
                }
                else if (index == 118)
                {
                    return this.valRetAir2.ToString();
                }
                else if (index == 119)
                {
                    return this.codRetAir3.ToString();
                }
                else if (index == 120)
                {
                    return this.baseImpAir3.ToString();
                }
                else if (index == 121)
                {
                    return this.porcentajeAir3.ToString();
                }
                else if (index == 122)
                {
                    return this.valRetAir3.ToString();
                }
                else if (index == 123)
                {
                    return this.totbasesImpReemb.ToString();
                }
                else if (index == 124)
                {
                    return this.idclavedoc.ToString();
                }
                else if (index == 125)
                {
                    return this.doc_sucursal.ToString();
                }
                else if (index == 126)
                {
                    return this.opc_documento.ToString();
                }
                else if (index == 127)
                {
                    return this.CL_NroSerieEstableci.ToString();
                }
                else if (index == 128)
                {
                    return this.CL_NroSerieEmision.ToString();
                }
                else if (index == 129)
                {
                    return this.CL_NroSecuencialDesde.ToString();
                }
                else if (index == 130)
                {
                    return this.CL_NroSecuencialHasta.ToString();
                }
                else if (index == 131)
                {
                    return this.Anio.ToString();
                }
                else if (index == 132)
                {
                    return this.Mes.ToString();
                }
                // Para que no de error el compilador de C#
                return "";
            }
            set
            {
                if (index == 0)
                {
                    this.CL_ExportaciónDe = value;
                }
                else if (index == 1)
                {
                    this.Cl_TipoComprobante = value;
                }
                else if (index == 2)
                {
                    this.CL_ReferendoDistrito = value;
                }
                else if (index == 3)
                {
                    this.CL_ReferendoAño = value;
                }
                else if (index == 4)
                {
                    this.CL_ReferendoRegimen = value;
                }
                else if (index == 5)
                {
                    this.CL_ReferendoCorrelativo = value;
                }
                else if (index == 6)
                {
                    this.CL_ReferendoVerificador = value;
                }
                else if (index == 7)
                {
                    this.CL_NroDocTransporte = value;
                }
                else if (index == 8)
                {
                    try
                    {
                        this.CL_FechaTransaccion = System.DateTime.Parse(value);
                    }
                    catch
                    {
                        // TODO: Usa el valor de fecha que quieras predeterminar
                        //       Una fecha ficticia:
                        //this.CL_FechaTransaccion = new System.DateTime(1900, 1, 1);
                        //       o la fecha de hoy:
                        this.CL_FechaTransaccion = System.DateTime.Now;
                    }
                }
                else if (index == 9)
                {
                    this.CL_NroFUE = value;
                }
                else if (index == 10)
                {
                    try
                    {
                        this.CL_ValorFOB = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_ValorFOB = System.Decimal.Parse("0");
                    }
                }
                else if (index == 11)
                {
                    try
                    {
                        this.CL_ValorComprobante = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_ValorComprobante = System.Decimal.Parse("0");
                    }
                }
                else if (index == 12)
                {
                    this.CL_NroSerieCpbteEstablec = value;
                }
                else if (index == 13)
                {
                    this.CL_NroSerieCpbteEmision = value;
                }
                else if (index == 14)
                {
                    this.CL_NroSecuencialCpbte = value;
                }
                else if (index == 15)
                {
                    this.CL_NroAutorizacion = value;
                }
                else if (index == 16)
                {
                    try
                    {
                        this.CL_FechaEmision = System.DateTime.Parse(value);
                    }
                    catch
                    {
                        // TODO: Usa el valor de fecha que quieras predeterminar
                        //       Una fecha ficticia:
                        //this.CL_FechaEmision = new System.DateTime(1900, 1, 1);
                        //       o la fecha de hoy:
                        this.CL_FechaEmision = System.DateTime.Now;
                    }
                }
                else if (index == 17)
                {
                    try
                    {
                        this.Clave = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.Clave = System.Decimal.Parse("0");
                    }
                }
                else if (index == 18)
                {
                    try
                    {
                        this.CL_mes = System.Int32.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_mes = System.Int32.Parse("0");
                    }
                }
                else if (index == 19)
                {
                    try
                    {
                        this.CL_anio = System.Int32.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_anio = System.Int32.Parse("0");
                    }
                }
                else if (index == 20)
                {
                    this.suc = value;
                }
                else if (index == 21)
                {
                    this.doc = value;
                }
                else if (index == 22)
                {
                    this.Cl_TipoId = value;
                }
                else if (index == 23)
                {
                    this.Cl_CodigoCliente = value;
                }
                else if (index == 24)
                {
                    try
                    {
                        this.CL_NroDeComprobantes = System.Int64.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_NroDeComprobantes = System.Int64.Parse("0");
                    }
                }
                else if (index == 25)
                {
                    try
                    {
                        this.CL_BaseNoGrabaIva = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_BaseNoGrabaIva = System.Decimal.Parse("0");
                    }
                }
                else if (index == 26)
                {
                    try
                    {
                        this.CL_BaseImpTarCero = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_BaseImpTarCero = System.Decimal.Parse("0");
                    }
                }
                else if (index == 27)
                {
                    try
                    {
                        this.CL_BaseImpGravadaIva = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_BaseImpGravadaIva = System.Decimal.Parse("0");
                    }
                }
                else if (index == 28)
                {
                    try
                    {
                        this.CL_MontoIva = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_MontoIva = System.Decimal.Parse("0");
                    }
                }
                else if (index == 29)
                {
                    try
                    {
                        this.CL_ValorRetIva = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_ValorRetIva = System.Decimal.Parse("0");
                    }
                }
                else if (index == 30)
                {
                    try
                    {
                        this.CL_ValorRetRenta = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_ValorRetRenta = System.Decimal.Parse("0");
                    }
                }
                else if (index == 31)
                {
                    try
                    {
                        this.montoIce = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.montoIce = System.Decimal.Parse("0");
                    }
                }
                else if (index == 32)
                {
                    this.parteRelVtas = value;
                }
                else if (index == 33)
                {
                    this.CL_SusTributario = value;
                }
                else if (index == 34)
                {
                    this.CL_TipoIdProveedor = value;
                }
                else if (index == 35)
                {
                    this.CL_CodigoProveedor = value;
                }
                else if (index == 36)
                {
                    this.CL_TipoProveedor = value;
                }
                else if (index == 37)
                {
                    this.CL_ParteRelacionada = value;
                }
                else if (index == 38)
                {
                    try
                    {
                        this.CL_FechaRegContable = System.DateTime.Parse(value);
                    }
                    catch
                    {
                        // TODO: Usa el valor de fecha que quieras predeterminar
                        //       Una fecha ficticia:
                        //this.CL_FechaRegContable = new System.DateTime(1900, 1, 1);
                        //       o la fecha de hoy:
                        this.CL_FechaRegContable = System.DateTime.Now;
                    }
                }
                else if (index == 39)
                {
                    this.CL_NroSerieEstablec = value;
                }
                else if (index == 40)
                {
                    this.CL_NroSeriePtoEmision = value;
                }
                else if (index == 41)
                {
                    this.CL_NroSecuencial = value;
                }
                else if (index == 42)
                {
                    try
                    {
                        this.CL_FechaComprobante = System.DateTime.Parse(value);
                    }
                    catch
                    {
                        // TODO: Usa el valor de fecha que quieras predeterminar
                        //       Una fecha ficticia:
                        //this.CL_FechaComprobante = new System.DateTime(1900, 1, 1);
                        //       o la fecha de hoy:
                        this.CL_FechaComprobante = System.DateTime.Now;
                    }
                }
                else if (index == 43)
                {
                    try
                    {
                        this.CL_MontoICE = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_MontoICE = System.Decimal.Parse("0");
                    }
                }
                else if (index == 44)
                {
                    try
                    {
                        this.CL_MontoRetIvaBienes = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_MontoRetIvaBienes = System.Decimal.Parse("0");
                    }
                }
                else if (index == 45)
                {
                    try
                    {
                        this.CL_MontoRetIvaServicios = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_MontoRetIvaServicios = System.Decimal.Parse("0");
                    }
                }
                else if (index == 46)
                {
                    try
                    {
                        this.CL_MontoRetIva100 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_MontoRetIva100 = System.Decimal.Parse("0");
                    }
                }
                else if (index == 47)
                {
                    try
                    {
                        this.CL_pagoLocExt = System.Int32.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_pagoLocExt = System.Int32.Parse("0");
                    }
                }
                else if (index == 48)
                {
                    this.CL_pagoPais = value;
                }
                else if (index == 49)
                {
                    this.CL_dobleTributacion = value;
                }
                else if (index == 50)
                {
                    this.CL_pagoSujetoRetencion = value;
                }
                else if (index == 51)
                {
                    this.CL_formaDePago = value;
                }
                else if (index == 52)
                {
                    this.CL_CodRetFteImpRenta0 = value;
                }
                else if (index == 53)
                {
                    try
                    {
                        this.CL_BaseImponibleIR0 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_BaseImponibleIR0 = System.Decimal.Parse("0");
                    }
                }
                else if (index == 54)
                {
                    try
                    {
                        this.CL_CodPorcRetIR0 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_CodPorcRetIR0 = System.Decimal.Parse("0");
                    }
                }
                else if (index == 55)
                {
                    try
                    {
                        this.CL_MontoRetIR0 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_MontoRetIR0 = System.Decimal.Parse("0");
                    }
                }
                else if (index == 56)
                {
                    this.CL_CodRetFteImpRenta1 = value;
                }
                else if (index == 57)
                {
                    try
                    {
                        this.CL_BaseImponibleIR1 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_BaseImponibleIR1 = System.Decimal.Parse("0");
                    }
                }
                else if (index == 58)
                {
                    try
                    {
                        this.CL_CodPorcRetIR1 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_CodPorcRetIR1 = System.Decimal.Parse("0");
                    }
                }
                else if (index == 59)
                {
                    try
                    {
                        this.CL_MontoRetIR1 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_MontoRetIR1 = System.Decimal.Parse("0");
                    }
                }
                else if (index == 60)
                {
                    this.CL_NroSerieCpbteRetEstable = value;
                }
                else if (index == 61)
                {
                    this.CL_NroSerieCpbteRetEmision = value;
                }
                else if (index == 62)
                {
                    this.CL_NroSecuencialCpbteRet = value;
                }
                else if (index == 63)
                {
                    this.CL_NroAutorizaCpbteRete = value;
                }
                else if (index == 64)
                {
                    try
                    {
                        this.CL_FechaEmisionCpbteRete = System.DateTime.Parse(value);
                    }
                    catch
                    {
                        // TODO: Usa el valor de fecha que quieras predeterminar
                        //       Una fecha ficticia:
                        //this.CL_FechaEmisionCpbteRete = new System.DateTime(1900, 1, 1);
                        //       o la fecha de hoy:
                        this.CL_FechaEmisionCpbteRete = System.DateTime.Now;
                    }
                }
                else if (index == 65)
                {
                    this.CL_CodigoTipoModificado = value;
                }
                else if (index == 66)
                {
                    this.CL_NroSerieModificadoEstab = value;
                }
                else if (index == 67)
                {
                    this.CL_NroSerieModificadoEmision = value;
                }
                else if (index == 68)
                {
                    this.CL_NroSecuencialModificado = value;
                }
                else if (index == 69)
                {
                    this.CL_NroAutorizaModificado = value;
                }
                else if (index == 70)
                {
                    try
                    {
                        this.baseImpExe = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.baseImpExe = System.Decimal.Parse("0");
                    }
                }
                else if (index == 71)
                {
                    try
                    {
                        this.valRetBien10 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.valRetBien10 = System.Decimal.Parse("0");
                    }
                }
                else if (index == 72)
                {
                    this.pagoRegFis = value;
                }
                else if (index == 73)
                {
                    try
                    {
                        this.fechaPagoDiv = System.DateTime.Parse(value);
                    }
                    catch
                    {
                        // TODO: Usa el valor de fecha que quieras predeterminar
                        //       Una fecha ficticia:
                        //this.fechaPagoDiv = new System.DateTime(1900, 1, 1);
                        //       o la fecha de hoy:
                        this.fechaPagoDiv = System.DateTime.Now;
                    }
                }
                else if (index == 74)
                {
                    try
                    {
                        this.imRentaSoc = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.imRentaSoc = System.Decimal.Parse("0");
                    }
                }
                else if (index == 75)
                {
                    try
                    {
                        this.anioUtDiv = System.Int32.Parse("0" + value);
                    }
                    catch
                    {
                        this.anioUtDiv = System.Int32.Parse("0");
                    }
                }
                else if (index == 76)
                {
                    try
                    {
                        this.NumCajBan = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.NumCajBan = System.Decimal.Parse("0");
                    }
                }
                else if (index == 77)
                {
                    try
                    {
                        this.PrecCajBan = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.PrecCajBan = System.Decimal.Parse("0");
                    }
                }
                else if (index == 78)
                {
                    try
                    {
                        this.imRentaSoc1 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.imRentaSoc1 = System.Decimal.Parse("0");
                    }
                }
                else if (index == 79)
                {
                    try
                    {
                        this.anioUtDiv1 = System.Int32.Parse("0" + value);
                    }
                    catch
                    {
                        this.anioUtDiv1 = System.Int32.Parse("0");
                    }
                }
                else if (index == 80)
                {
                    try
                    {
                        this.NumCajBan1 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.NumCajBan1 = System.Decimal.Parse("0");
                    }
                }
                else if (index == 81)
                {
                    try
                    {
                        this.PrecCajBan1 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.PrecCajBan1 = System.Decimal.Parse("0");
                    }
                }
                else if (index == 82)
                {
                    try
                    {
                        this.CL_CodRetFteImpRenta2 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_CodRetFteImpRenta2 = System.Decimal.Parse("0");
                    }
                }
                else if (index == 83)
                {
                    try
                    {
                        this.CL_BaseImponibleIR2 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_BaseImponibleIR2 = System.Decimal.Parse("0");
                    }
                }
                else if (index == 84)
                {
                    try
                    {
                        this.CL_CodPorcRetIR2 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_CodPorcRetIR2 = System.Decimal.Parse("0");
                    }
                }
                else if (index == 85)
                {
                    try
                    {
                        this.fechaPagoDiv2 = System.DateTime.Parse(value);
                    }
                    catch
                    {
                        // TODO: Usa el valor de fecha que quieras predeterminar
                        //       Una fecha ficticia:
                        //this.fechaPagoDiv2 = new System.DateTime(1900, 1, 1);
                        //       o la fecha de hoy:
                        this.fechaPagoDiv2 = System.DateTime.Now;
                    }
                }
                else if (index == 86)
                {
                    try
                    {
                        this.imRentaSoc2 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.imRentaSoc2 = System.Decimal.Parse("0");
                    }
                }
                else if (index == 87)
                {
                    try
                    {
                        this.anioUtDiv2 = System.Int32.Parse("0" + value);
                    }
                    catch
                    {
                        this.anioUtDiv2 = System.Int32.Parse("0");
                    }
                }
                else if (index == 88)
                {
                    try
                    {
                        this.NumCajBan2 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.NumCajBan2 = System.Decimal.Parse("0");
                    }
                }
                else if (index == 89)
                {
                    try
                    {
                        this.PrecCajBan2 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.PrecCajBan2 = System.Decimal.Parse("0");
                    }
                }
                else if (index == 90)
                {
                    try
                    {
                        this.CL_CodRetFteImpRenta3 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_CodRetFteImpRenta3 = System.Decimal.Parse("0");
                    }
                }
                else if (index == 91)
                {
                    try
                    {
                        this.CL_BaseImponibleIR3 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_BaseImponibleIR3 = System.Decimal.Parse("0");
                    }
                }
                else if (index == 92)
                {
                    try
                    {
                        this.CL_CodPorcRetIR3 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_CodPorcRetIR3 = System.Decimal.Parse("0");
                    }
                }
                else if (index == 93)
                {
                    try
                    {
                        this.fechaPagoDiv3 = System.DateTime.Parse(value);
                    }
                    catch
                    {
                        // TODO: Usa el valor de fecha que quieras predeterminar
                        //       Una fecha ficticia:
                        //this.fechaPagoDiv3 = new System.DateTime(1900, 1, 1);
                        //       o la fecha de hoy:
                        this.fechaPagoDiv3 = System.DateTime.Now;
                    }
                }
                else if (index == 94)
                {
                    try
                    {
                        this.imRentaSoc3 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.imRentaSoc3 = System.Decimal.Parse("0");
                    }
                }
                else if (index == 95)
                {
                    try
                    {
                        this.anioUtDiv3 = System.Int32.Parse("0" + value);
                    }
                    catch
                    {
                        this.anioUtDiv3 = System.Int32.Parse("0");
                    }
                }
                else if (index == 96)
                {
                    try
                    {
                        this.NumCajBan3 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.NumCajBan3 = System.Decimal.Parse("0");
                    }
                }
                else if (index == 97)
                {
                    try
                    {
                        this.PrecCajBan3 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.PrecCajBan3 = System.Decimal.Parse("0");
                    }
                }
                else if (index == 98)
                {
                    this.tipoComprobanteReemb = value;
                }
                else if (index == 99)
                {
                    this.tpIdProvReemb = value;
                }
                else if (index == 100)
                {
                    this.idProvReemb = value;
                }
                else if (index == 101)
                {
                    this.establecimientoReemb = value;
                }
                else if (index == 102)
                {
                    this.puntoEmisionReemb = value;
                }
                else if (index == 103)
                {
                    try
                    {
                        this.secuencialReemb = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.secuencialReemb = System.Decimal.Parse("0");
                    }
                }
                else if (index == 104)
                {
                    try
                    {
                        this.fechaEmisionReemb = System.DateTime.Parse(value);
                    }
                    catch
                    {
                        // TODO: Usa el valor de fecha que quieras predeterminar
                        //       Una fecha ficticia:
                        //this.fechaEmisionReemb = new System.DateTime(1900, 1, 1);
                        //       o la fecha de hoy:
                        this.fechaEmisionReemb = System.DateTime.Now;
                    }
                }
                else if (index == 105)
                {
                    this.autorizacionReemb = value;
                }
                else if (index == 106)
                {
                    try
                    {
                        this.baseImponibleReemb = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.baseImponibleReemb = System.Decimal.Parse("0");
                    }
                }
                else if (index == 107)
                {
                    try
                    {
                        this.baseImpGravReemb = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.baseImpGravReemb = System.Decimal.Parse("0");
                    }
                }
                else if (index == 108)
                {
                    try
                    {
                        this.baseNoGraIvaReemb = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.baseNoGraIvaReemb = System.Decimal.Parse("0");
                    }
                }
                else if (index == 109)
                {
                    try
                    {
                        this.baseImpExeReemb = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.baseImpExeReemb = System.Decimal.Parse("0");
                    }
                }
                else if (index == 110)
                {
                    try
                    {
                        this.montoIceRemb = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.montoIceRemb = System.Decimal.Parse("0");
                    }
                }
                else if (index == 111)
                {
                    try
                    {
                        this.montoIvaRemb = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.montoIvaRemb = System.Decimal.Parse("0");
                    }
                }
                else if (index == 112)
                {
                    try
                    {
                        this.valRetBien20 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.valRetBien20 = System.Decimal.Parse("0");
                    }
                }
                else if (index == 113)
                {
                    try
                    {
                        this.fechaPagoDiv1 = System.DateTime.Parse(value);
                    }
                    catch
                    {
                        // TODO: Usa el valor de fecha que quieras predeterminar
                        //       Una fecha ficticia:
                        //this.fechaPagoDiv1 = new System.DateTime(1900, 1, 1);
                        //       o la fecha de hoy:
                        this.fechaPagoDiv1 = System.DateTime.Now;
                    }
                }
                else if (index == 114)
                {
                    try
                    {
                        this.valRetServ20 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.valRetServ20 = System.Decimal.Parse("0");
                    }
                }
                else if (index == 115)
                {
                    try
                    {
                        this.codRetAir2 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.codRetAir2 = System.Decimal.Parse("0");
                    }
                }
                else if (index == 116)
                {
                    try
                    {
                        this.baseImpAir2 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.baseImpAir2 = System.Decimal.Parse("0");
                    }
                }
                else if (index == 117)
                {
                    try
                    {
                        this.porcentajeAir2 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.porcentajeAir2 = System.Decimal.Parse("0");
                    }
                }
                else if (index == 118)
                {
                    try
                    {
                        this.valRetAir2 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.valRetAir2 = System.Decimal.Parse("0");
                    }
                }
                else if (index == 119)
                {
                    try
                    {
                        this.codRetAir3 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.codRetAir3 = System.Decimal.Parse("0");
                    }
                }
                else if (index == 120)
                {
                    try
                    {
                        this.baseImpAir3 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.baseImpAir3 = System.Decimal.Parse("0");
                    }
                }
                else if (index == 121)
                {
                    try
                    {
                        this.porcentajeAir3 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.porcentajeAir3 = System.Decimal.Parse("0");
                    }
                }
                else if (index == 122)
                {
                    try
                    {
                        this.valRetAir3 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.valRetAir3 = System.Decimal.Parse("0");
                    }
                }
                else if (index == 123)
                {
                    try
                    {
                        this.totbasesImpReemb = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.totbasesImpReemb = System.Decimal.Parse("0");
                    }
                }
                else if (index == 124)
                {
                    try
                    {
                        this.idclavedoc = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.idclavedoc = System.Decimal.Parse("0");
                    }
                }
                else if (index == 125)
                {
                    this.doc_sucursal = value;
                }
                else if (index == 126)
                {
                    this.opc_documento = value;
                }
                else if (index == 127)
                {
                    this.CL_NroSerieEstableci = value;
                }
                else if (index == 128)
                {
                    this.CL_NroSerieEmision = value;
                }
                else if (index == 129)
                {
                    this.CL_NroSecuencialDesde = value;
                }
                else if (index == 130)
                {
                    this.CL_NroSecuencialHasta = value;
                }
                else if (index == 131)
                {
                    try
                    {
                        this.Anio = System.Int32.Parse("0" + value);
                    }
                    catch
                    {
                        this.Anio = System.Int32.Parse("0");
                    }
                }
                else if (index == 132)
                {
                    try
                    {
                        this.Mes = System.Int32.Parse("0" + value);
                    }
                    catch
                    {
                        this.Mes = System.Int32.Parse("0");
                    }
                }
            }
        }
        public string this[string index]
        {
            // Devuelve el contenido del campo indicado en index
            // (el índice corresponde al nombre de la columna)
            get
            {
                if (index == "CL_ExportaciónDe")
                {
                    return this.CL_ExportaciónDe.ToString();
                }
                else if (index == "Cl_TipoComprobante")
                {
                    return this.Cl_TipoComprobante.ToString();
                }
                else if (index == "CL_ReferendoDistrito")
                {
                    return this.CL_ReferendoDistrito.ToString();
                }
                else if (index == "CL_ReferendoAño")
                {
                    return this.CL_ReferendoAño.ToString();
                }
                else if (index == "CL_ReferendoRegimen")
                {
                    return this.CL_ReferendoRegimen.ToString();
                }
                else if (index == "CL_ReferendoCorrelativo")
                {
                    return this.CL_ReferendoCorrelativo.ToString();
                }
                else if (index == "CL_ReferendoVerificador")
                {
                    return this.CL_ReferendoVerificador.ToString();
                }
                else if (index == "CL_NroDocTransporte")
                {
                    return this.CL_NroDocTransporte.ToString();
                }
                else if (index == "CL_FechaTransaccion")
                {
                    return this.CL_FechaTransaccion.ToString();
                }
                else if (index == "CL_NroFUE")
                {
                    return this.CL_NroFUE.ToString();
                }
                else if (index == "CL_ValorFOB")
                {
                    return this.CL_ValorFOB.ToString();
                }
                else if (index == "CL_ValorComprobante")
                {
                    return this.CL_ValorComprobante.ToString();
                }
                else if (index == "CL_NroSerieCpbteEstablec")
                {
                    return this.CL_NroSerieCpbteEstablec.ToString();
                }
                else if (index == "CL_NroSerieCpbteEmision")
                {
                    return this.CL_NroSerieCpbteEmision.ToString();
                }
                else if (index == "CL_NroSecuencialCpbte")
                {
                    return this.CL_NroSecuencialCpbte.ToString();
                }
                else if (index == "CL_NroAutorizacion")
                {
                    return this.CL_NroAutorizacion.ToString();
                }
                else if (index == "CL_FechaEmision")
                {
                    return this.CL_FechaEmision.ToString();
                }
                else if (index == "Clave")
                {
                    return this.Clave.ToString();
                }
                else if (index == "CL_mes")
                {
                    return this.CL_mes.ToString();
                }
                else if (index == "CL_anio")
                {
                    return this.CL_anio.ToString();
                }
                else if (index == "suc")
                {
                    return this.suc.ToString();
                }
                else if (index == "doc")
                {
                    return this.doc.ToString();
                }
                else if (index == "Cl_TipoId")
                {
                    return this.Cl_TipoId.ToString();
                }
                else if (index == "Cl_CodigoCliente")
                {
                    return this.Cl_CodigoCliente.ToString();
                }
                else if (index == "CL_NroDeComprobantes")
                {
                    return this.CL_NroDeComprobantes.ToString();
                }
                else if (index == "CL_BaseNoGrabaIva")
                {
                    return this.CL_BaseNoGrabaIva.ToString();
                }
                else if (index == "CL_BaseImpTarCero")
                {
                    return this.CL_BaseImpTarCero.ToString();
                }
                else if (index == "CL_BaseImpGravadaIva")
                {
                    return this.CL_BaseImpGravadaIva.ToString();
                }
                else if (index == "CL_MontoIva")
                {
                    return this.CL_MontoIva.ToString();
                }
                else if (index == "CL_ValorRetIva")
                {
                    return this.CL_ValorRetIva.ToString();
                }
                else if (index == "CL_ValorRetRenta")
                {
                    return this.CL_ValorRetRenta.ToString();
                }
                else if (index == "montoIce")
                {
                    return this.montoIce.ToString();
                }
                else if (index == "parteRelVtas")
                {
                    return this.parteRelVtas.ToString();
                }
                else if (index == "CL_SusTributario")
                {
                    return this.CL_SusTributario.ToString();
                }
                else if (index == "CL_TipoIdProveedor")
                {
                    return this.CL_TipoIdProveedor.ToString();
                }
                else if (index == "CL_CodigoProveedor")
                {
                    return this.CL_CodigoProveedor.ToString();
                }
                else if (index == "CL_TipoProveedor")
                {
                    return this.CL_TipoProveedor.ToString();
                }
                else if (index == "CL_ParteRelacionada")
                {
                    return this.CL_ParteRelacionada.ToString();
                }
                else if (index == "CL_FechaRegContable")
                {
                    return this.CL_FechaRegContable.ToString();
                }
                else if (index == "CL_NroSerieEstablec")
                {
                    return this.CL_NroSerieEstablec.ToString();
                }
                else if (index == "CL_NroSeriePtoEmision")
                {
                    return this.CL_NroSeriePtoEmision.ToString();
                }
                else if (index == "CL_NroSecuencial")
                {
                    return this.CL_NroSecuencial.ToString();
                }
                else if (index == "CL_FechaComprobante")
                {
                    return this.CL_FechaComprobante.ToString();
                }
                else if (index == "CL_MontoICE")
                {
                    return this.CL_MontoICE.ToString();
                }
                else if (index == "CL_MontoRetIvaBienes")
                {
                    return this.CL_MontoRetIvaBienes.ToString();
                }
                else if (index == "CL_MontoRetIvaServicios")
                {
                    return this.CL_MontoRetIvaServicios.ToString();
                }
                else if (index == "CL_MontoRetIva100")
                {
                    return this.CL_MontoRetIva100.ToString();
                }
                else if (index == "CL_pagoLocExt")
                {
                    return this.CL_pagoLocExt.ToString();
                }
                else if (index == "CL_pagoPais")
                {
                    return this.CL_pagoPais.ToString();
                }
                else if (index == "CL_dobleTributacion")
                {
                    return this.CL_dobleTributacion.ToString();
                }
                else if (index == "CL_pagoSujetoRetencion")
                {
                    return this.CL_pagoSujetoRetencion.ToString();
                }
                else if (index == "CL_formaDePago")
                {
                    return this.CL_formaDePago.ToString();
                }
                else if (index == "CL_CodRetFteImpRenta0")
                {
                    return this.CL_CodRetFteImpRenta0.ToString();
                }
                else if (index == "CL_BaseImponibleIR0")
                {
                    return this.CL_BaseImponibleIR0.ToString();
                }
                else if (index == "CL_CodPorcRetIR0")
                {
                    return this.CL_CodPorcRetIR0.ToString();
                }
                else if (index == "CL_MontoRetIR0")
                {
                    return this.CL_MontoRetIR0.ToString();
                }
                else if (index == "CL_CodRetFteImpRenta1")
                {
                    return this.CL_CodRetFteImpRenta1.ToString();
                }
                else if (index == "CL_BaseImponibleIR1")
                {
                    return this.CL_BaseImponibleIR1.ToString();
                }
                else if (index == "CL_CodPorcRetIR1")
                {
                    return this.CL_CodPorcRetIR1.ToString();
                }
                else if (index == "CL_MontoRetIR1")
                {
                    return this.CL_MontoRetIR1.ToString();
                }
                else if (index == "CL_NroSerieCpbteRetEstable")
                {
                    return this.CL_NroSerieCpbteRetEstable.ToString();
                }
                else if (index == "CL_NroSerieCpbteRetEmision")
                {
                    return this.CL_NroSerieCpbteRetEmision.ToString();
                }
                else if (index == "CL_NroSecuencialCpbteRet")
                {
                    return this.CL_NroSecuencialCpbteRet.ToString();
                }
                else if (index == "CL_NroAutorizaCpbteRete")
                {
                    return this.CL_NroAutorizaCpbteRete.ToString();
                }
                else if (index == "CL_FechaEmisionCpbteRete")
                {
                    return this.CL_FechaEmisionCpbteRete.ToString();
                }
                else if (index == "CL_CodigoTipoModificado")
                {
                    return this.CL_CodigoTipoModificado.ToString();
                }
                else if (index == "CL_NroSerieModificadoEstab")
                {
                    return this.CL_NroSerieModificadoEstab.ToString();
                }
                else if (index == "CL_NroSerieModificadoEmision")
                {
                    return this.CL_NroSerieModificadoEmision.ToString();
                }
                else if (index == "CL_NroSecuencialModificado")
                {
                    return this.CL_NroSecuencialModificado.ToString();
                }
                else if (index == "CL_NroAutorizaModificado")
                {
                    return this.CL_NroAutorizaModificado.ToString();
                }
                else if (index == "baseImpExe")
                {
                    return this.baseImpExe.ToString();
                }
                else if (index == "valRetBien10")
                {
                    return this.valRetBien10.ToString();
                }
                else if (index == "pagoRegFis")
                {
                    return this.pagoRegFis.ToString();
                }
                else if (index == "fechaPagoDiv")
                {
                    return this.fechaPagoDiv.ToString();
                }
                else if (index == "imRentaSoc")
                {
                    return this.imRentaSoc.ToString();
                }
                else if (index == "anioUtDiv")
                {
                    return this.anioUtDiv.ToString();
                }
                else if (index == "NumCajBan")
                {
                    return this.NumCajBan.ToString();
                }
                else if (index == "PrecCajBan")
                {
                    return this.PrecCajBan.ToString();
                }
                else if (index == "imRentaSoc1")
                {
                    return this.imRentaSoc1.ToString();
                }
                else if (index == "anioUtDiv1")
                {
                    return this.anioUtDiv1.ToString();
                }
                else if (index == "NumCajBan1")
                {
                    return this.NumCajBan1.ToString();
                }
                else if (index == "PrecCajBan1")
                {
                    return this.PrecCajBan1.ToString();
                }
                else if (index == "CL_CodRetFteImpRenta2")
                {
                    return this.CL_CodRetFteImpRenta2.ToString();
                }
                else if (index == "CL_BaseImponibleIR2")
                {
                    return this.CL_BaseImponibleIR2.ToString();
                }
                else if (index == "CL_CodPorcRetIR2")
                {
                    return this.CL_CodPorcRetIR2.ToString();
                }
                else if (index == "fechaPagoDiv2")
                {
                    return this.fechaPagoDiv2.ToString();
                }
                else if (index == "imRentaSoc2")
                {
                    return this.imRentaSoc2.ToString();
                }
                else if (index == "anioUtDiv2")
                {
                    return this.anioUtDiv2.ToString();
                }
                else if (index == "NumCajBan2")
                {
                    return this.NumCajBan2.ToString();
                }
                else if (index == "PrecCajBan2")
                {
                    return this.PrecCajBan2.ToString();
                }
                else if (index == "CL_CodRetFteImpRenta3")
                {
                    return this.CL_CodRetFteImpRenta3.ToString();
                }
                else if (index == "CL_BaseImponibleIR3")
                {
                    return this.CL_BaseImponibleIR3.ToString();
                }
                else if (index == "CL_CodPorcRetIR3")
                {
                    return this.CL_CodPorcRetIR3.ToString();
                }
                else if (index == "fechaPagoDiv3")
                {
                    return this.fechaPagoDiv3.ToString();
                }
                else if (index == "imRentaSoc3")
                {
                    return this.imRentaSoc3.ToString();
                }
                else if (index == "anioUtDiv3")
                {
                    return this.anioUtDiv3.ToString();
                }
                else if (index == "NumCajBan3")
                {
                    return this.NumCajBan3.ToString();
                }
                else if (index == "PrecCajBan3")
                {
                    return this.PrecCajBan3.ToString();
                }
                else if (index == "tipoComprobanteReemb")
                {
                    return this.tipoComprobanteReemb.ToString();
                }
                else if (index == "tpIdProvReemb")
                {
                    return this.tpIdProvReemb.ToString();
                }
                else if (index == "idProvReemb")
                {
                    return this.idProvReemb.ToString();
                }
                else if (index == "establecimientoReemb")
                {
                    return this.establecimientoReemb.ToString();
                }
                else if (index == "puntoEmisionReemb")
                {
                    return this.puntoEmisionReemb.ToString();
                }
                else if (index == "secuencialReemb")
                {
                    return this.secuencialReemb.ToString();
                }
                else if (index == "fechaEmisionReemb")
                {
                    return this.fechaEmisionReemb.ToString();
                }
                else if (index == "autorizacionReemb")
                {
                    return this.autorizacionReemb.ToString();
                }
                else if (index == "baseImponibleReemb")
                {
                    return this.baseImponibleReemb.ToString();
                }
                else if (index == "baseImpGravReemb")
                {
                    return this.baseImpGravReemb.ToString();
                }
                else if (index == "baseNoGraIvaReemb")
                {
                    return this.baseNoGraIvaReemb.ToString();
                }
                else if (index == "baseImpExeReemb")
                {
                    return this.baseImpExeReemb.ToString();
                }
                else if (index == "montoIceRemb")
                {
                    return this.montoIceRemb.ToString();
                }
                else if (index == "montoIvaRemb")
                {
                    return this.montoIvaRemb.ToString();
                }
                else if (index == "valRetBien20")
                {
                    return this.valRetBien20.ToString();
                }
                else if (index == "fechaPagoDiv1")
                {
                    return this.fechaPagoDiv1.ToString();
                }
                else if (index == "valRetServ20")
                {
                    return this.valRetServ20.ToString();
                }
                else if (index == "codRetAir2")
                {
                    return this.codRetAir2.ToString();
                }
                else if (index == "baseImpAir2")
                {
                    return this.baseImpAir2.ToString();
                }
                else if (index == "porcentajeAir2")
                {
                    return this.porcentajeAir2.ToString();
                }
                else if (index == "valRetAir2")
                {
                    return this.valRetAir2.ToString();
                }
                else if (index == "codRetAir3")
                {
                    return this.codRetAir3.ToString();
                }
                else if (index == "baseImpAir3")
                {
                    return this.baseImpAir3.ToString();
                }
                else if (index == "porcentajeAir3")
                {
                    return this.porcentajeAir3.ToString();
                }
                else if (index == "valRetAir3")
                {
                    return this.valRetAir3.ToString();
                }
                else if (index == "totbasesImpReemb")
                {
                    return this.totbasesImpReemb.ToString();
                }
                else if (index == "idclavedoc")
                {
                    return this.idclavedoc.ToString();
                }
                else if (index == "doc_sucursal")
                {
                    return this.doc_sucursal.ToString();
                }
                else if (index == "opc_documento")
                {
                    return this.opc_documento.ToString();
                }
                else if (index == "CL_NroSerieEstableci")
                {
                    return this.CL_NroSerieEstableci.ToString();
                }
                else if (index == "CL_NroSerieEmision")
                {
                    return this.CL_NroSerieEmision.ToString();
                }
                else if (index == "CL_NroSecuencialDesde")
                {
                    return this.CL_NroSecuencialDesde.ToString();
                }
                else if (index == "CL_NroSecuencialHasta")
                {
                    return this.CL_NroSecuencialHasta.ToString();
                }
                else if (index == "Anio")
                {
                    return this.Anio.ToString();
                }
                else if (index == "Mes")
                {
                    return this.Mes.ToString();
                }
                // Para que no de error el compilador de C#
                return "";
            }
            set
            {
                if (index == "CL_ExportaciónDe")
                {
                    this.CL_ExportaciónDe = value;
                }
                else if (index == "Cl_TipoComprobante")
                {
                    this.Cl_TipoComprobante = value;
                }
                else if (index == "CL_ReferendoDistrito")
                {
                    this.CL_ReferendoDistrito = value;
                }
                else if (index == "CL_ReferendoAño")
                {
                    this.CL_ReferendoAño = value;
                }
                else if (index == "CL_ReferendoRegimen")
                {
                    this.CL_ReferendoRegimen = value;
                }
                else if (index == "CL_ReferendoCorrelativo")
                {
                    this.CL_ReferendoCorrelativo = value;
                }
                else if (index == "CL_ReferendoVerificador")
                {
                    this.CL_ReferendoVerificador = value;
                }
                else if (index == "CL_NroDocTransporte")
                {
                    this.CL_NroDocTransporte = value;
                }
                else if (index == "CL_FechaTransaccion")
                {
                    try
                    {
                        this.CL_FechaTransaccion = System.DateTime.Parse(value);
                    }
                    catch
                    {
                        // TODO: Usa el valor de fecha que quieras predeterminar
                        //       Una fecha ficticia:
                        //this.CL_FechaTransaccion = new System.DateTime(1900, 1, 1);
                        //       o la fecha de hoy:
                        this.CL_FechaTransaccion = System.DateTime.Now;
                    }
                }
                else if (index == "CL_NroFUE")
                {
                    this.CL_NroFUE = value;
                }
                else if (index == "CL_ValorFOB")
                {
                    try
                    {
                        this.CL_ValorFOB = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_ValorFOB = System.Decimal.Parse("0");
                    }
                }
                else if (index == "CL_ValorComprobante")
                {
                    try
                    {
                        this.CL_ValorComprobante = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_ValorComprobante = System.Decimal.Parse("0");
                    }
                }
                else if (index == "CL_NroSerieCpbteEstablec")
                {
                    this.CL_NroSerieCpbteEstablec = value;
                }
                else if (index == "CL_NroSerieCpbteEmision")
                {
                    this.CL_NroSerieCpbteEmision = value;
                }
                else if (index == "CL_NroSecuencialCpbte")
                {
                    this.CL_NroSecuencialCpbte = value;
                }
                else if (index == "CL_NroAutorizacion")
                {
                    this.CL_NroAutorizacion = value;
                }
                else if (index == "CL_FechaEmision")
                {
                    try
                    {
                        this.CL_FechaEmision = System.DateTime.Parse(value);
                    }
                    catch
                    {
                        // TODO: Usa el valor de fecha que quieras predeterminar
                        //       Una fecha ficticia:
                        //this.CL_FechaEmision = new System.DateTime(1900, 1, 1);
                        //       o la fecha de hoy:
                        this.CL_FechaEmision = System.DateTime.Now;
                    }
                }
                else if (index == "Clave")
                {
                    try
                    {
                        this.Clave = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.Clave = System.Decimal.Parse("0");
                    }
                }
                else if (index == "CL_mes")
                {
                    try
                    {
                        this.CL_mes = System.Int32.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_mes = System.Int32.Parse("0");
                    }
                }
                else if (index == "CL_anio")
                {
                    try
                    {
                        this.CL_anio = System.Int32.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_anio = System.Int32.Parse("0");
                    }
                }
                else if (index == "suc")
                {
                    this.suc = value;
                }
                else if (index == "doc")
                {
                    this.doc = value;
                }
                else if (index == "Cl_TipoId")
                {
                    this.Cl_TipoId = value;
                }
                else if (index == "Cl_CodigoCliente")
                {
                    this.Cl_CodigoCliente = value;
                }
                else if (index == "CL_NroDeComprobantes")
                {
                    try
                    {
                        this.CL_NroDeComprobantes = System.Int64.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_NroDeComprobantes = System.Int64.Parse("0");
                    }
                }
                else if (index == "CL_BaseNoGrabaIva")
                {
                    try
                    {
                        this.CL_BaseNoGrabaIva = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_BaseNoGrabaIva = System.Decimal.Parse("0");
                    }
                }
                else if (index == "CL_BaseImpTarCero")
                {
                    try
                    {
                        this.CL_BaseImpTarCero = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_BaseImpTarCero = System.Decimal.Parse("0");
                    }
                }
                else if (index == "CL_BaseImpGravadaIva")
                {
                    try
                    {
                        this.CL_BaseImpGravadaIva = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_BaseImpGravadaIva = System.Decimal.Parse("0");
                    }
                }
                else if (index == "CL_MontoIva")
                {
                    try
                    {
                        this.CL_MontoIva = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_MontoIva = System.Decimal.Parse("0");
                    }
                }
                else if (index == "CL_ValorRetIva")
                {
                    try
                    {
                        this.CL_ValorRetIva = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_ValorRetIva = System.Decimal.Parse("0");
                    }
                }
                else if (index == "CL_ValorRetRenta")
                {
                    try
                    {
                        this.CL_ValorRetRenta = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_ValorRetRenta = System.Decimal.Parse("0");
                    }
                }
                else if (index == "montoIce")
                {
                    try
                    {
                        this.montoIce = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.montoIce = System.Decimal.Parse("0");
                    }
                }
                else if (index == "parteRelVtas")
                {
                    this.parteRelVtas = value;
                }
                else if (index == "CL_SusTributario")
                {
                    this.CL_SusTributario = value;
                }
                else if (index == "CL_TipoIdProveedor")
                {
                    this.CL_TipoIdProveedor = value;
                }
                else if (index == "CL_CodigoProveedor")
                {
                    this.CL_CodigoProveedor = value;
                }
                else if (index == "CL_TipoProveedor")
                {
                    this.CL_TipoProveedor = value;
                }
                else if (index == "CL_ParteRelacionada")
                {
                    this.CL_ParteRelacionada = value;
                }
                else if (index == "CL_FechaRegContable")
                {
                    try
                    {
                        this.CL_FechaRegContable = System.DateTime.Parse(value);
                    }
                    catch
                    {
                        // TODO: Usa el valor de fecha que quieras predeterminar
                        //       Una fecha ficticia:
                        //this.CL_FechaRegContable = new System.DateTime(1900, 1, 1);
                        //       o la fecha de hoy:
                        this.CL_FechaRegContable = System.DateTime.Now;
                    }
                }
                else if (index == "CL_NroSerieEstablec")
                {
                    this.CL_NroSerieEstablec = value;
                }
                else if (index == "CL_NroSeriePtoEmision")
                {
                    this.CL_NroSeriePtoEmision = value;
                }
                else if (index == "CL_NroSecuencial")
                {
                    this.CL_NroSecuencial = value;
                }
                else if (index == "CL_FechaComprobante")
                {
                    try
                    {
                        this.CL_FechaComprobante = System.DateTime.Parse(value);
                    }
                    catch
                    {
                        // TODO: Usa el valor de fecha que quieras predeterminar
                        //       Una fecha ficticia:
                        //this.CL_FechaComprobante = new System.DateTime(1900, 1, 1);
                        //       o la fecha de hoy:
                        this.CL_FechaComprobante = System.DateTime.Now;
                    }
                }
                else if (index == "CL_MontoICE")
                {
                    try
                    {
                        this.CL_MontoICE = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_MontoICE = System.Decimal.Parse("0");
                    }
                }
                else if (index == "CL_MontoRetIvaBienes")
                {
                    try
                    {
                        this.CL_MontoRetIvaBienes = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_MontoRetIvaBienes = System.Decimal.Parse("0");
                    }
                }
                else if (index == "CL_MontoRetIvaServicios")
                {
                    try
                    {
                        this.CL_MontoRetIvaServicios = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_MontoRetIvaServicios = System.Decimal.Parse("0");
                    }
                }
                else if (index == "CL_MontoRetIva100")
                {
                    try
                    {
                        this.CL_MontoRetIva100 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_MontoRetIva100 = System.Decimal.Parse("0");
                    }
                }
                else if (index == "CL_pagoLocExt")
                {
                    try
                    {
                        this.CL_pagoLocExt = System.Int32.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_pagoLocExt = System.Int32.Parse("0");
                    }
                }
                else if (index == "CL_pagoPais")
                {
                    this.CL_pagoPais = value;
                }
                else if (index == "CL_dobleTributacion")
                {
                    this.CL_dobleTributacion = value;
                }
                else if (index == "CL_pagoSujetoRetencion")
                {
                    this.CL_pagoSujetoRetencion = value;
                }
                else if (index == "CL_formaDePago")
                {
                    this.CL_formaDePago = value;
                }
                else if (index == "CL_CodRetFteImpRenta0")
                {
                    this.CL_CodRetFteImpRenta0 = value;
                }
                else if (index == "CL_BaseImponibleIR0")
                {
                    try
                    {
                        this.CL_BaseImponibleIR0 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_BaseImponibleIR0 = System.Decimal.Parse("0");
                    }
                }
                else if (index == "CL_CodPorcRetIR0")
                {
                    try
                    {
                        this.CL_CodPorcRetIR0 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_CodPorcRetIR0 = System.Decimal.Parse("0");
                    }
                }
                else if (index == "CL_MontoRetIR0")
                {
                    try
                    {
                        this.CL_MontoRetIR0 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_MontoRetIR0 = System.Decimal.Parse("0");
                    }
                }
                else if (index == "CL_CodRetFteImpRenta1")
                {
                    this.CL_CodRetFteImpRenta1 = value;
                }
                else if (index == "CL_BaseImponibleIR1")
                {
                    try
                    {
                        this.CL_BaseImponibleIR1 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_BaseImponibleIR1 = System.Decimal.Parse("0");
                    }
                }
                else if (index == "CL_CodPorcRetIR1")
                {
                    try
                    {
                        this.CL_CodPorcRetIR1 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_CodPorcRetIR1 = System.Decimal.Parse("0");
                    }
                }
                else if (index == "CL_MontoRetIR1")
                {
                    try
                    {
                        this.CL_MontoRetIR1 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_MontoRetIR1 = System.Decimal.Parse("0");
                    }
                }
                else if (index == "CL_NroSerieCpbteRetEstable")
                {
                    this.CL_NroSerieCpbteRetEstable = value;
                }
                else if (index == "CL_NroSerieCpbteRetEmision")
                {
                    this.CL_NroSerieCpbteRetEmision = value;
                }
                else if (index == "CL_NroSecuencialCpbteRet")
                {
                    this.CL_NroSecuencialCpbteRet = value;
                }
                else if (index == "CL_NroAutorizaCpbteRete")
                {
                    this.CL_NroAutorizaCpbteRete = value;
                }
                else if (index == "CL_FechaEmisionCpbteRete")
                {
                    try
                    {
                        this.CL_FechaEmisionCpbteRete = System.DateTime.Parse(value);
                    }
                    catch
                    {
                        // TODO: Usa el valor de fecha que quieras predeterminar
                        //       Una fecha ficticia:
                        //this.CL_FechaEmisionCpbteRete = new System.DateTime(1900, 1, 1);
                        //       o la fecha de hoy:
                        this.CL_FechaEmisionCpbteRete = System.DateTime.Now;
                    }
                }
                else if (index == "CL_CodigoTipoModificado")
                {
                    this.CL_CodigoTipoModificado = value;
                }
                else if (index == "CL_NroSerieModificadoEstab")
                {
                    this.CL_NroSerieModificadoEstab = value;
                }
                else if (index == "CL_NroSerieModificadoEmision")
                {
                    this.CL_NroSerieModificadoEmision = value;
                }
                else if (index == "CL_NroSecuencialModificado")
                {
                    this.CL_NroSecuencialModificado = value;
                }
                else if (index == "CL_NroAutorizaModificado")
                {
                    this.CL_NroAutorizaModificado = value;
                }
                else if (index == "baseImpExe")
                {
                    try
                    {
                        this.baseImpExe = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.baseImpExe = System.Decimal.Parse("0");
                    }
                }
                else if (index == "valRetBien10")
                {
                    try
                    {
                        this.valRetBien10 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.valRetBien10 = System.Decimal.Parse("0");
                    }
                }
                else if (index == "pagoRegFis")
                {
                    this.pagoRegFis = value;
                }
                else if (index == "fechaPagoDiv")
                {
                    try
                    {
                        this.fechaPagoDiv = System.DateTime.Parse(value);
                    }
                    catch
                    {
                        // TODO: Usa el valor de fecha que quieras predeterminar
                        //       Una fecha ficticia:
                        //this.fechaPagoDiv = new System.DateTime(1900, 1, 1);
                        //       o la fecha de hoy:
                        this.fechaPagoDiv = System.DateTime.Now;
                    }
                }
                else if (index == "imRentaSoc")
                {
                    try
                    {
                        this.imRentaSoc = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.imRentaSoc = System.Decimal.Parse("0");
                    }
                }
                else if (index == "anioUtDiv")
                {
                    try
                    {
                        this.anioUtDiv = System.Int32.Parse("0" + value);
                    }
                    catch
                    {
                        this.anioUtDiv = System.Int32.Parse("0");
                    }
                }
                else if (index == "NumCajBan")
                {
                    try
                    {
                        this.NumCajBan = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.NumCajBan = System.Decimal.Parse("0");
                    }
                }
                else if (index == "PrecCajBan")
                {
                    try
                    {
                        this.PrecCajBan = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.PrecCajBan = System.Decimal.Parse("0");
                    }
                }
                else if (index == "imRentaSoc1")
                {
                    try
                    {
                        this.imRentaSoc1 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.imRentaSoc1 = System.Decimal.Parse("0");
                    }
                }
                else if (index == "anioUtDiv1")
                {
                    try
                    {
                        this.anioUtDiv1 = System.Int32.Parse("0" + value);
                    }
                    catch
                    {
                        this.anioUtDiv1 = System.Int32.Parse("0");
                    }
                }
                else if (index == "NumCajBan1")
                {
                    try
                    {
                        this.NumCajBan1 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.NumCajBan1 = System.Decimal.Parse("0");
                    }
                }
                else if (index == "PrecCajBan1")
                {
                    try
                    {
                        this.PrecCajBan1 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.PrecCajBan1 = System.Decimal.Parse("0");
                    }
                }
                else if (index == "CL_CodRetFteImpRenta2")
                {
                    try
                    {
                        this.CL_CodRetFteImpRenta2 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_CodRetFteImpRenta2 = System.Decimal.Parse("0");
                    }
                }
                else if (index == "CL_BaseImponibleIR2")
                {
                    try
                    {
                        this.CL_BaseImponibleIR2 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_BaseImponibleIR2 = System.Decimal.Parse("0");
                    }
                }
                else if (index == "CL_CodPorcRetIR2")
                {
                    try
                    {
                        this.CL_CodPorcRetIR2 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_CodPorcRetIR2 = System.Decimal.Parse("0");
                    }
                }
                else if (index == "fechaPagoDiv2")
                {
                    try
                    {
                        this.fechaPagoDiv2 = System.DateTime.Parse(value);
                    }
                    catch
                    {
                        // TODO: Usa el valor de fecha que quieras predeterminar
                        //       Una fecha ficticia:
                        //this.fechaPagoDiv2 = new System.DateTime(1900, 1, 1);
                        //       o la fecha de hoy:
                        this.fechaPagoDiv2 = System.DateTime.Now;
                    }
                }
                else if (index == "imRentaSoc2")
                {
                    try
                    {
                        this.imRentaSoc2 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.imRentaSoc2 = System.Decimal.Parse("0");
                    }
                }
                else if (index == "anioUtDiv2")
                {
                    try
                    {
                        this.anioUtDiv2 = System.Int32.Parse("0" + value);
                    }
                    catch
                    {
                        this.anioUtDiv2 = System.Int32.Parse("0");
                    }
                }
                else if (index == "NumCajBan2")
                {
                    try
                    {
                        this.NumCajBan2 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.NumCajBan2 = System.Decimal.Parse("0");
                    }
                }
                else if (index == "PrecCajBan2")
                {
                    try
                    {
                        this.PrecCajBan2 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.PrecCajBan2 = System.Decimal.Parse("0");
                    }
                }
                else if (index == "CL_CodRetFteImpRenta3")
                {
                    try
                    {
                        this.CL_CodRetFteImpRenta3 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_CodRetFteImpRenta3 = System.Decimal.Parse("0");
                    }
                }
                else if (index == "CL_BaseImponibleIR3")
                {
                    try
                    {
                        this.CL_BaseImponibleIR3 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_BaseImponibleIR3 = System.Decimal.Parse("0");
                    }
                }
                else if (index == "CL_CodPorcRetIR3")
                {
                    try
                    {
                        this.CL_CodPorcRetIR3 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.CL_CodPorcRetIR3 = System.Decimal.Parse("0");
                    }
                }
                else if (index == "fechaPagoDiv3")
                {
                    try
                    {
                        this.fechaPagoDiv3 = System.DateTime.Parse(value);
                    }
                    catch
                    {
                        // TODO: Usa el valor de fecha que quieras predeterminar
                        //       Una fecha ficticia:
                        //this.fechaPagoDiv3 = new System.DateTime(1900, 1, 1);
                        //       o la fecha de hoy:
                        this.fechaPagoDiv3 = System.DateTime.Now;
                    }
                }
                else if (index == "imRentaSoc3")
                {
                    try
                    {
                        this.imRentaSoc3 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.imRentaSoc3 = System.Decimal.Parse("0");
                    }
                }
                else if (index == "anioUtDiv3")
                {
                    try
                    {
                        this.anioUtDiv3 = System.Int32.Parse("0" + value);
                    }
                    catch
                    {
                        this.anioUtDiv3 = System.Int32.Parse("0");
                    }
                }
                else if (index == "NumCajBan3")
                {
                    try
                    {
                        this.NumCajBan3 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.NumCajBan3 = System.Decimal.Parse("0");
                    }
                }
                else if (index == "PrecCajBan3")
                {
                    try
                    {
                        this.PrecCajBan3 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.PrecCajBan3 = System.Decimal.Parse("0");
                    }
                }
                else if (index == "tipoComprobanteReemb")
                {
                    this.tipoComprobanteReemb = value;
                }
                else if (index == "tpIdProvReemb")
                {
                    this.tpIdProvReemb = value;
                }
                else if (index == "idProvReemb")
                {
                    this.idProvReemb = value;
                }
                else if (index == "establecimientoReemb")
                {
                    this.establecimientoReemb = value;
                }
                else if (index == "puntoEmisionReemb")
                {
                    this.puntoEmisionReemb = value;
                }
                else if (index == "secuencialReemb")
                {
                    try
                    {
                        this.secuencialReemb = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.secuencialReemb = System.Decimal.Parse("0");
                    }
                }
                else if (index == "fechaEmisionReemb")
                {
                    try
                    {
                        this.fechaEmisionReemb = System.DateTime.Parse(value);
                    }
                    catch
                    {
                        // TODO: Usa el valor de fecha que quieras predeterminar
                        //       Una fecha ficticia:
                        //this.fechaEmisionReemb = new System.DateTime(1900, 1, 1);
                        //       o la fecha de hoy:
                        this.fechaEmisionReemb = System.DateTime.Now;
                    }
                }
                else if (index == "autorizacionReemb")
                {
                    this.autorizacionReemb = value;
                }
                else if (index == "baseImponibleReemb")
                {
                    try
                    {
                        this.baseImponibleReemb = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.baseImponibleReemb = System.Decimal.Parse("0");
                    }
                }
                else if (index == "baseImpGravReemb")
                {
                    try
                    {
                        this.baseImpGravReemb = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.baseImpGravReemb = System.Decimal.Parse("0");
                    }
                }
                else if (index == "baseNoGraIvaReemb")
                {
                    try
                    {
                        this.baseNoGraIvaReemb = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.baseNoGraIvaReemb = System.Decimal.Parse("0");
                    }
                }
                else if (index == "baseImpExeReemb")
                {
                    try
                    {
                        this.baseImpExeReemb = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.baseImpExeReemb = System.Decimal.Parse("0");
                    }
                }
                else if (index == "montoIceRemb")
                {
                    try
                    {
                        this.montoIceRemb = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.montoIceRemb = System.Decimal.Parse("0");
                    }
                }
                else if (index == "montoIvaRemb")
                {
                    try
                    {
                        this.montoIvaRemb = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.montoIvaRemb = System.Decimal.Parse("0");
                    }
                }
                else if (index == "valRetBien20")
                {
                    try
                    {
                        this.valRetBien20 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.valRetBien20 = System.Decimal.Parse("0");
                    }
                }
                else if (index == "fechaPagoDiv1")
                {
                    try
                    {
                        this.fechaPagoDiv1 = System.DateTime.Parse(value);
                    }
                    catch
                    {
                        // TODO: Usa el valor de fecha que quieras predeterminar
                        //       Una fecha ficticia:
                        //this.fechaPagoDiv1 = new System.DateTime(1900, 1, 1);
                        //       o la fecha de hoy:
                        this.fechaPagoDiv1 = System.DateTime.Now;
                    }
                }
                else if (index == "valRetServ20")
                {
                    try
                    {
                        this.valRetServ20 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.valRetServ20 = System.Decimal.Parse("0");
                    }
                }
                else if (index == "codRetAir2")
                {
                    try
                    {
                        this.codRetAir2 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.codRetAir2 = System.Decimal.Parse("0");
                    }
                }
                else if (index == "baseImpAir2")
                {
                    try
                    {
                        this.baseImpAir2 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.baseImpAir2 = System.Decimal.Parse("0");
                    }
                }
                else if (index == "porcentajeAir2")
                {
                    try
                    {
                        this.porcentajeAir2 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.porcentajeAir2 = System.Decimal.Parse("0");
                    }
                }
                else if (index == "valRetAir2")
                {
                    try
                    {
                        this.valRetAir2 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.valRetAir2 = System.Decimal.Parse("0");
                    }
                }
                else if (index == "codRetAir3")
                {
                    try
                    {
                        this.codRetAir3 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.codRetAir3 = System.Decimal.Parse("0");
                    }
                }
                else if (index == "baseImpAir3")
                {
                    try
                    {
                        this.baseImpAir3 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.baseImpAir3 = System.Decimal.Parse("0");
                    }
                }
                else if (index == "porcentajeAir3")
                {
                    try
                    {
                        this.porcentajeAir3 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.porcentajeAir3 = System.Decimal.Parse("0");
                    }
                }
                else if (index == "valRetAir3")
                {
                    try
                    {
                        this.valRetAir3 = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.valRetAir3 = System.Decimal.Parse("0");
                    }
                }
                else if (index == "totbasesImpReemb")
                {
                    try
                    {
                        this.totbasesImpReemb = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.totbasesImpReemb = System.Decimal.Parse("0");
                    }
                }
                else if (index == "idclavedoc")
                {
                    try
                    {
                        this.idclavedoc = System.Decimal.Parse("0" + value);
                    }
                    catch
                    {
                        this.idclavedoc = System.Decimal.Parse("0");
                    }
                }
                else if (index == "doc_sucursal")
                {
                    this.doc_sucursal = value;
                }
                else if (index == "opc_documento")
                {
                    this.opc_documento = value;
                }
                else if (index == "CL_NroSerieEstableci")
                {
                    this.CL_NroSerieEstableci = value;
                }
                else if (index == "CL_NroSerieEmision")
                {
                    this.CL_NroSerieEmision = value;
                }
                else if (index == "CL_NroSecuencialDesde")
                {
                    this.CL_NroSecuencialDesde = value;
                }
                else if (index == "CL_NroSecuencialHasta")
                {
                    this.CL_NroSecuencialHasta = value;
                }
                else if (index == "Anio")
                {
                    try
                    {
                        this.Anio = System.Int32.Parse("0" + value);
                    }
                    catch
                    {
                        this.Anio = System.Int32.Parse("0");
                    }
                }
                else if (index == "Mes")
                {
                    try
                    {
                        this.Mes = System.Int32.Parse("0" + value);
                    }
                    catch
                    {
                        this.Mes = System.Int32.Parse("0");
                    }
                }
            }
        }
        //
        // Campos y métodos compartidos (estáticos) para gestionar la base de datos
        //
        // La cadena de conexión a la base de datos
        private static string cadenaConexion = @"Data Source=patoopc; Initial Catalog=ivaret; user id=sa; password=123qweASDZXC";
        // La cadena de selección
        public static string CadenaSelect = "SELECT * FROM Anulados";
        //
        public Anulados()
        {
        }
        public Anulados(string conex)
        {
            cadenaConexion = conex;
        }
        //
        // Métodos compartidos (estáticos) privados
        //
        // asigna una fila de la tabla a un objeto Anulados
        private static Anulados row2Anulados(DataRow r)
        {
            // asigna a un objeto Anulados los datos del dataRow indicado
            Anulados oAnulados = new Anulados();
            //
            oAnulados.CL_ExportaciónDe = r["CL_ExportaciónDe"].ToString();
            oAnulados.Cl_TipoComprobante = r["Cl_TipoComprobante"].ToString();
            oAnulados.CL_ReferendoDistrito = r["CL_ReferendoDistrito"].ToString();
            oAnulados.CL_ReferendoAño = r["CL_ReferendoAño"].ToString();
            oAnulados.CL_ReferendoRegimen = r["CL_ReferendoRegimen"].ToString();
            oAnulados.CL_ReferendoCorrelativo = r["CL_ReferendoCorrelativo"].ToString();
            oAnulados.CL_ReferendoVerificador = r["CL_ReferendoVerificador"].ToString();
            oAnulados.CL_NroDocTransporte = r["CL_NroDocTransporte"].ToString();
            try
            {
                oAnulados.CL_FechaTransaccion = DateTime.Parse(r["CL_FechaTransaccion"].ToString());
            }
            catch
            {
                // TODO: Usa el valor de fecha que quieras predeterminar
                //       Una fecha ficticia:
                //oAnulados.CL_FechaTransaccion = new DateTime(1900, 1, 1);
                //       o la fecha de hoy:
                oAnulados.CL_FechaTransaccion = DateTime.Now;
            }
            oAnulados.CL_NroFUE = r["CL_NroFUE"].ToString();
            oAnulados.CL_ValorFOB = System.Decimal.Parse("0" + r["CL_ValorFOB"].ToString());
            oAnulados.CL_ValorComprobante = System.Decimal.Parse("0" + r["CL_ValorComprobante"].ToString());
            oAnulados.CL_NroSerieCpbteEstablec = r["CL_NroSerieCpbteEstablec"].ToString();
            oAnulados.CL_NroSerieCpbteEmision = r["CL_NroSerieCpbteEmision"].ToString();
            oAnulados.CL_NroSecuencialCpbte = r["CL_NroSecuencialCpbte"].ToString();
            oAnulados.CL_NroAutorizacion = r["CL_NroAutorizacion"].ToString();
            try
            {
                oAnulados.CL_FechaEmision = DateTime.Parse(r["CL_FechaEmision"].ToString());
            }
            catch
            {
                // TODO: Usa el valor de fecha que quieras predeterminar
                //       Una fecha ficticia:
                //oAnulados.CL_FechaEmision = new DateTime(1900, 1, 1);
                //       o la fecha de hoy:
                oAnulados.CL_FechaEmision = DateTime.Now;
            }
            oAnulados.Clave = System.Decimal.Parse("0" + r["Clave"].ToString());
            oAnulados.CL_mes = System.Int32.Parse("0" + r["CL_mes"].ToString());
            oAnulados.CL_anio = System.Int32.Parse("0" + r["CL_anio"].ToString());
            oAnulados.suc = r["suc"].ToString();
            oAnulados.doc = r["doc"].ToString();
            oAnulados.Cl_TipoId = r["Cl_TipoId"].ToString();
            oAnulados.Cl_CodigoCliente = r["Cl_CodigoCliente"].ToString();
            oAnulados.CL_NroDeComprobantes = System.Int64.Parse("0" + r["CL_NroDeComprobantes"].ToString());
            oAnulados.CL_BaseNoGrabaIva = System.Decimal.Parse("0" + r["CL_BaseNoGrabaIva"].ToString());
            oAnulados.CL_BaseImpTarCero = System.Decimal.Parse("0" + r["CL_BaseImpTarCero"].ToString());
            oAnulados.CL_BaseImpGravadaIva = System.Decimal.Parse("0" + r["CL_BaseImpGravadaIva"].ToString());
            oAnulados.CL_MontoIva = System.Decimal.Parse("0" + r["CL_MontoIva"].ToString());
            oAnulados.CL_ValorRetIva = System.Decimal.Parse("0" + r["CL_ValorRetIva"].ToString());
            oAnulados.CL_ValorRetRenta = System.Decimal.Parse("0" + r["CL_ValorRetRenta"].ToString());
            oAnulados.montoIce = System.Decimal.Parse("0" + r["montoIce"].ToString());
            oAnulados.parteRelVtas = r["parteRelVtas"].ToString();
            oAnulados.CL_SusTributario = r["CL_SusTributario"].ToString();
            oAnulados.CL_TipoIdProveedor = r["CL_TipoIdProveedor"].ToString();
            oAnulados.CL_CodigoProveedor = r["CL_CodigoProveedor"].ToString();
            oAnulados.CL_TipoProveedor = r["CL_TipoProveedor"].ToString();
            oAnulados.CL_ParteRelacionada = r["CL_ParteRelacionada"].ToString();
            try
            {
                oAnulados.CL_FechaRegContable = DateTime.Parse(r["CL_FechaRegContable"].ToString());
            }
            catch
            {
                // TODO: Usa el valor de fecha que quieras predeterminar
                //       Una fecha ficticia:
                //oAnulados.CL_FechaRegContable = new DateTime(1900, 1, 1);
                //       o la fecha de hoy:
                oAnulados.CL_FechaRegContable = DateTime.Now;
            }
            oAnulados.CL_NroSerieEstablec = r["CL_NroSerieEstablec"].ToString();
            oAnulados.CL_NroSeriePtoEmision = r["CL_NroSeriePtoEmision"].ToString();
            oAnulados.CL_NroSecuencial = r["CL_NroSecuencial"].ToString();
            try
            {
                oAnulados.CL_FechaComprobante = DateTime.Parse(r["CL_FechaComprobante"].ToString());
            }
            catch
            {
                // TODO: Usa el valor de fecha que quieras predeterminar
                //       Una fecha ficticia:
                //oAnulados.CL_FechaComprobante = new DateTime(1900, 1, 1);
                //       o la fecha de hoy:
                oAnulados.CL_FechaComprobante = DateTime.Now;
            }
            oAnulados.CL_MontoICE = System.Decimal.Parse("0" + r["CL_MontoICE"].ToString());
            oAnulados.CL_MontoRetIvaBienes = System.Decimal.Parse("0" + r["CL_MontoRetIvaBienes"].ToString());
            oAnulados.CL_MontoRetIvaServicios = System.Decimal.Parse("0" + r["CL_MontoRetIvaServicios"].ToString());
            oAnulados.CL_MontoRetIva100 = System.Decimal.Parse("0" + r["CL_MontoRetIva100"].ToString());
            oAnulados.CL_pagoLocExt = System.Int32.Parse("0" + r["CL_pagoLocExt"].ToString());
            oAnulados.CL_pagoPais = r["CL_pagoPais"].ToString();
            oAnulados.CL_dobleTributacion = r["CL_dobleTributacion"].ToString();
            oAnulados.CL_pagoSujetoRetencion = r["CL_pagoSujetoRetencion"].ToString();
            oAnulados.CL_formaDePago = r["CL_formaDePago"].ToString();
            oAnulados.CL_CodRetFteImpRenta0 = r["CL_CodRetFteImpRenta0"].ToString();
            oAnulados.CL_BaseImponibleIR0 = System.Decimal.Parse("0" + r["CL_BaseImponibleIR0"].ToString());
            oAnulados.CL_CodPorcRetIR0 = System.Decimal.Parse("0" + r["CL_CodPorcRetIR0"].ToString());
            oAnulados.CL_MontoRetIR0 = System.Decimal.Parse("0" + r["CL_MontoRetIR0"].ToString());
            oAnulados.CL_CodRetFteImpRenta1 = r["CL_CodRetFteImpRenta1"].ToString();
            oAnulados.CL_BaseImponibleIR1 = System.Decimal.Parse("0" + r["CL_BaseImponibleIR1"].ToString());
            oAnulados.CL_CodPorcRetIR1 = System.Decimal.Parse("0" + r["CL_CodPorcRetIR1"].ToString());
            oAnulados.CL_MontoRetIR1 = System.Decimal.Parse("0" + r["CL_MontoRetIR1"].ToString());
            oAnulados.CL_NroSerieCpbteRetEstable = r["CL_NroSerieCpbteRetEstable"].ToString();
            oAnulados.CL_NroSerieCpbteRetEmision = r["CL_NroSerieCpbteRetEmision"].ToString();
            oAnulados.CL_NroSecuencialCpbteRet = r["CL_NroSecuencialCpbteRet"].ToString();
            oAnulados.CL_NroAutorizaCpbteRete = r["CL_NroAutorizaCpbteRete"].ToString();
            try
            {
                oAnulados.CL_FechaEmisionCpbteRete = DateTime.Parse(r["CL_FechaEmisionCpbteRete"].ToString());
            }
            catch
            {
                // TODO: Usa el valor de fecha que quieras predeterminar
                //       Una fecha ficticia:
                //oAnulados.CL_FechaEmisionCpbteRete = new DateTime(1900, 1, 1);
                //       o la fecha de hoy:
                oAnulados.CL_FechaEmisionCpbteRete = DateTime.Now;
            }
            oAnulados.CL_CodigoTipoModificado = r["CL_CodigoTipoModificado"].ToString();
            oAnulados.CL_NroSerieModificadoEstab = r["CL_NroSerieModificadoEstab"].ToString();
            oAnulados.CL_NroSerieModificadoEmision = r["CL_NroSerieModificadoEmision"].ToString();
            oAnulados.CL_NroSecuencialModificado = r["CL_NroSecuencialModificado"].ToString();
            oAnulados.CL_NroAutorizaModificado = r["CL_NroAutorizaModificado"].ToString();
            oAnulados.baseImpExe = System.Decimal.Parse("0" + r["baseImpExe"].ToString());
            oAnulados.valRetBien10 = System.Decimal.Parse("0" + r["valRetBien10"].ToString());
            oAnulados.pagoRegFis = r["pagoRegFis"].ToString();
            try
            {
                oAnulados.fechaPagoDiv = DateTime.Parse(r["fechaPagoDiv"].ToString());
            }
            catch
            {
                // TODO: Usa el valor de fecha que quieras predeterminar
                //       Una fecha ficticia:
                //oAnulados.fechaPagoDiv = new DateTime(1900, 1, 1);
                //       o la fecha de hoy:
                oAnulados.fechaPagoDiv = DateTime.Now;
            }
            oAnulados.imRentaSoc = System.Decimal.Parse("0" + r["imRentaSoc"].ToString());
            oAnulados.anioUtDiv = System.Int32.Parse("0" + r["anioUtDiv"].ToString());
            oAnulados.NumCajBan = System.Decimal.Parse("0" + r["NumCajBan"].ToString());
            oAnulados.PrecCajBan = System.Decimal.Parse("0" + r["PrecCajBan"].ToString());
            oAnulados.imRentaSoc1 = System.Decimal.Parse("0" + r["imRentaSoc1"].ToString());
            oAnulados.anioUtDiv1 = System.Int32.Parse("0" + r["anioUtDiv1"].ToString());
            oAnulados.NumCajBan1 = System.Decimal.Parse("0" + r["NumCajBan1"].ToString());
            oAnulados.PrecCajBan1 = System.Decimal.Parse("0" + r["PrecCajBan1"].ToString());
            oAnulados.CL_CodRetFteImpRenta2 = System.Decimal.Parse("0" + r["CL_CodRetFteImpRenta2"].ToString());
            oAnulados.CL_BaseImponibleIR2 = System.Decimal.Parse("0" + r["CL_BaseImponibleIR2"].ToString());
            oAnulados.CL_CodPorcRetIR2 = System.Decimal.Parse("0" + r["CL_CodPorcRetIR2"].ToString());
            try
            {
                oAnulados.fechaPagoDiv2 = DateTime.Parse(r["fechaPagoDiv2"].ToString());
            }
            catch
            {
                // TODO: Usa el valor de fecha que quieras predeterminar
                //       Una fecha ficticia:
                //oAnulados.fechaPagoDiv2 = new DateTime(1900, 1, 1);
                //       o la fecha de hoy:
                oAnulados.fechaPagoDiv2 = DateTime.Now;
            }
            oAnulados.imRentaSoc2 = System.Decimal.Parse("0" + r["imRentaSoc2"].ToString());
            oAnulados.anioUtDiv2 = System.Int32.Parse("0" + r["anioUtDiv2"].ToString());
            oAnulados.NumCajBan2 = System.Decimal.Parse("0" + r["NumCajBan2"].ToString());
            oAnulados.PrecCajBan2 = System.Decimal.Parse("0" + r["PrecCajBan2"].ToString());
            oAnulados.CL_CodRetFteImpRenta3 = System.Decimal.Parse("0" + r["CL_CodRetFteImpRenta3"].ToString());
            oAnulados.CL_BaseImponibleIR3 = System.Decimal.Parse("0" + r["CL_BaseImponibleIR3"].ToString());
            oAnulados.CL_CodPorcRetIR3 = System.Decimal.Parse("0" + r["CL_CodPorcRetIR3"].ToString());
            try
            {
                oAnulados.fechaPagoDiv3 = DateTime.Parse(r["fechaPagoDiv3"].ToString());
            }
            catch
            {
                // TODO: Usa el valor de fecha que quieras predeterminar
                //       Una fecha ficticia:
                //oAnulados.fechaPagoDiv3 = new DateTime(1900, 1, 1);
                //       o la fecha de hoy:
                oAnulados.fechaPagoDiv3 = DateTime.Now;
            }
            oAnulados.imRentaSoc3 = System.Decimal.Parse("0" + r["imRentaSoc3"].ToString());
            oAnulados.anioUtDiv3 = System.Int32.Parse("0" + r["anioUtDiv3"].ToString());
            oAnulados.NumCajBan3 = System.Decimal.Parse("0" + r["NumCajBan3"].ToString());
            oAnulados.PrecCajBan3 = System.Decimal.Parse("0" + r["PrecCajBan3"].ToString());
            oAnulados.tipoComprobanteReemb = r["tipoComprobanteReemb"].ToString();
            oAnulados.tpIdProvReemb = r["tpIdProvReemb"].ToString();
            oAnulados.idProvReemb = r["idProvReemb"].ToString();
            oAnulados.establecimientoReemb = r["establecimientoReemb"].ToString();
            oAnulados.puntoEmisionReemb = r["puntoEmisionReemb"].ToString();
            oAnulados.secuencialReemb = System.Decimal.Parse("0" + r["secuencialReemb"].ToString());
            try
            {
                oAnulados.fechaEmisionReemb = DateTime.Parse(r["fechaEmisionReemb"].ToString());
            }
            catch
            {
                // TODO: Usa el valor de fecha que quieras predeterminar
                //       Una fecha ficticia:
                //oAnulados.fechaEmisionReemb = new DateTime(1900, 1, 1);
                //       o la fecha de hoy:
                oAnulados.fechaEmisionReemb = DateTime.Now;
            }
            oAnulados.autorizacionReemb = r["autorizacionReemb"].ToString();
            oAnulados.baseImponibleReemb = System.Decimal.Parse("0" + r["baseImponibleReemb"].ToString());
            oAnulados.baseImpGravReemb = System.Decimal.Parse("0" + r["baseImpGravReemb"].ToString());
            oAnulados.baseNoGraIvaReemb = System.Decimal.Parse("0" + r["baseNoGraIvaReemb"].ToString());
            oAnulados.baseImpExeReemb = System.Decimal.Parse("0" + r["baseImpExeReemb"].ToString());
            oAnulados.montoIceRemb = System.Decimal.Parse("0" + r["montoIceRemb"].ToString());
            oAnulados.montoIvaRemb = System.Decimal.Parse("0" + r["montoIvaRemb"].ToString());
            oAnulados.valRetBien20 = System.Decimal.Parse("0" + r["valRetBien20"].ToString());
            try
            {
                oAnulados.fechaPagoDiv1 = DateTime.Parse(r["fechaPagoDiv1"].ToString());
            }
            catch
            {
                // TODO: Usa el valor de fecha que quieras predeterminar
                //       Una fecha ficticia:
                //oAnulados.fechaPagoDiv1 = new DateTime(1900, 1, 1);
                //       o la fecha de hoy:
                oAnulados.fechaPagoDiv1 = DateTime.Now;
            }
            oAnulados.valRetServ20 = System.Decimal.Parse("0" + r["valRetServ20"].ToString());
            oAnulados.codRetAir2 = System.Decimal.Parse("0" + r["codRetAir2"].ToString());
            oAnulados.baseImpAir2 = System.Decimal.Parse("0" + r["baseImpAir2"].ToString());
            oAnulados.porcentajeAir2 = System.Decimal.Parse("0" + r["porcentajeAir2"].ToString());
            oAnulados.valRetAir2 = System.Decimal.Parse("0" + r["valRetAir2"].ToString());
            oAnulados.codRetAir3 = System.Decimal.Parse("0" + r["codRetAir3"].ToString());
            oAnulados.baseImpAir3 = System.Decimal.Parse("0" + r["baseImpAir3"].ToString());
            oAnulados.porcentajeAir3 = System.Decimal.Parse("0" + r["porcentajeAir3"].ToString());
            oAnulados.valRetAir3 = System.Decimal.Parse("0" + r["valRetAir3"].ToString());
            oAnulados.totbasesImpReemb = System.Decimal.Parse("0" + r["totbasesImpReemb"].ToString());
            oAnulados.idclavedoc = System.Decimal.Parse("0" + r["idclavedoc"].ToString());
            oAnulados.doc_sucursal = r["doc_sucursal"].ToString();
            oAnulados.opc_documento = r["opc_documento"].ToString();
            oAnulados.CL_NroSerieEstableci = r["CL_NroSerieEstableci"].ToString();
            oAnulados.CL_NroSerieEmision = r["CL_NroSerieEmision"].ToString();
            oAnulados.CL_NroSecuencialDesde = r["CL_NroSecuencialDesde"].ToString();
            oAnulados.CL_NroSecuencialHasta = r["CL_NroSecuencialHasta"].ToString();
            oAnulados.Anio = System.Int32.Parse("0" + r["Anio"].ToString());
            oAnulados.Mes = System.Int32.Parse("0" + r["Mes"].ToString());
            //
            return oAnulados;
        }
        //
        // asigna un objeto Anulados a la fila indicada
        private static void Anulados2Row(Anulados oAnulados, DataRow r)
        {
            // asigna un objeto Anulados al dataRow indicado
            r["CL_ExportaciónDe"] = oAnulados.CL_ExportaciónDe;
            r["Cl_TipoComprobante"] = oAnulados.Cl_TipoComprobante;
            r["CL_ReferendoDistrito"] = oAnulados.CL_ReferendoDistrito;
            r["CL_ReferendoAño"] = oAnulados.CL_ReferendoAño;
            r["CL_ReferendoRegimen"] = oAnulados.CL_ReferendoRegimen;
            r["CL_ReferendoCorrelativo"] = oAnulados.CL_ReferendoCorrelativo;
            r["CL_ReferendoVerificador"] = oAnulados.CL_ReferendoVerificador;
            r["CL_NroDocTransporte"] = oAnulados.CL_NroDocTransporte;
            r["CL_FechaTransaccion"] = oAnulados.CL_FechaTransaccion;
            r["CL_NroFUE"] = oAnulados.CL_NroFUE;
            r["CL_ValorFOB"] = oAnulados.CL_ValorFOB;
            r["CL_ValorComprobante"] = oAnulados.CL_ValorComprobante;
            r["CL_NroSerieCpbteEstablec"] = oAnulados.CL_NroSerieCpbteEstablec;
            r["CL_NroSerieCpbteEmision"] = oAnulados.CL_NroSerieCpbteEmision;
            r["CL_NroSecuencialCpbte"] = oAnulados.CL_NroSecuencialCpbte;
            r["CL_NroAutorizacion"] = oAnulados.CL_NroAutorizacion;
            r["CL_FechaEmision"] = oAnulados.CL_FechaEmision;
            // TODO: Comprueba si esta asignación debe hacerse
            //       pero mejor lo dejas comentado ya que es un campo autoincremental o único
            //r["Clave"] = oAnulados.Clave;
            r["CL_mes"] = oAnulados.CL_mes;
            r["CL_anio"] = oAnulados.CL_anio;
            r["suc"] = oAnulados.suc;
            r["doc"] = oAnulados.doc;
            r["Cl_TipoId"] = oAnulados.Cl_TipoId;
            r["Cl_CodigoCliente"] = oAnulados.Cl_CodigoCliente;
            r["CL_NroDeComprobantes"] = oAnulados.CL_NroDeComprobantes;
            r["CL_BaseNoGrabaIva"] = oAnulados.CL_BaseNoGrabaIva;
            r["CL_BaseImpTarCero"] = oAnulados.CL_BaseImpTarCero;
            r["CL_BaseImpGravadaIva"] = oAnulados.CL_BaseImpGravadaIva;
            r["CL_MontoIva"] = oAnulados.CL_MontoIva;
            r["CL_ValorRetIva"] = oAnulados.CL_ValorRetIva;
            r["CL_ValorRetRenta"] = oAnulados.CL_ValorRetRenta;
            r["montoIce"] = oAnulados.montoIce;
            r["parteRelVtas"] = oAnulados.parteRelVtas;
            r["CL_SusTributario"] = oAnulados.CL_SusTributario;
            r["CL_TipoIdProveedor"] = oAnulados.CL_TipoIdProveedor;
            r["CL_CodigoProveedor"] = oAnulados.CL_CodigoProveedor;
            r["CL_TipoProveedor"] = oAnulados.CL_TipoProveedor;
            r["CL_ParteRelacionada"] = oAnulados.CL_ParteRelacionada;
            r["CL_FechaRegContable"] = oAnulados.CL_FechaRegContable;
            r["CL_NroSerieEstablec"] = oAnulados.CL_NroSerieEstablec;
            r["CL_NroSeriePtoEmision"] = oAnulados.CL_NroSeriePtoEmision;
            r["CL_NroSecuencial"] = oAnulados.CL_NroSecuencial;
            r["CL_FechaComprobante"] = oAnulados.CL_FechaComprobante;
            r["CL_MontoICE"] = oAnulados.CL_MontoICE;
            r["CL_MontoRetIvaBienes"] = oAnulados.CL_MontoRetIvaBienes;
            r["CL_MontoRetIvaServicios"] = oAnulados.CL_MontoRetIvaServicios;
            r["CL_MontoRetIva100"] = oAnulados.CL_MontoRetIva100;
            r["CL_pagoLocExt"] = oAnulados.CL_pagoLocExt;
            r["CL_pagoPais"] = oAnulados.CL_pagoPais;
            r["CL_dobleTributacion"] = oAnulados.CL_dobleTributacion;
            r["CL_pagoSujetoRetencion"] = oAnulados.CL_pagoSujetoRetencion;
            r["CL_formaDePago"] = oAnulados.CL_formaDePago;
            r["CL_CodRetFteImpRenta0"] = oAnulados.CL_CodRetFteImpRenta0;
            r["CL_BaseImponibleIR0"] = oAnulados.CL_BaseImponibleIR0;
            r["CL_CodPorcRetIR0"] = oAnulados.CL_CodPorcRetIR0;
            r["CL_MontoRetIR0"] = oAnulados.CL_MontoRetIR0;
            r["CL_CodRetFteImpRenta1"] = oAnulados.CL_CodRetFteImpRenta1;
            r["CL_BaseImponibleIR1"] = oAnulados.CL_BaseImponibleIR1;
            r["CL_CodPorcRetIR1"] = oAnulados.CL_CodPorcRetIR1;
            r["CL_MontoRetIR1"] = oAnulados.CL_MontoRetIR1;
            r["CL_NroSerieCpbteRetEstable"] = oAnulados.CL_NroSerieCpbteRetEstable;
            r["CL_NroSerieCpbteRetEmision"] = oAnulados.CL_NroSerieCpbteRetEmision;
            r["CL_NroSecuencialCpbteRet"] = oAnulados.CL_NroSecuencialCpbteRet;
            r["CL_NroAutorizaCpbteRete"] = oAnulados.CL_NroAutorizaCpbteRete;
            r["CL_FechaEmisionCpbteRete"] = oAnulados.CL_FechaEmisionCpbteRete;
            r["CL_CodigoTipoModificado"] = oAnulados.CL_CodigoTipoModificado;
            r["CL_NroSerieModificadoEstab"] = oAnulados.CL_NroSerieModificadoEstab;
            r["CL_NroSerieModificadoEmision"] = oAnulados.CL_NroSerieModificadoEmision;
            r["CL_NroSecuencialModificado"] = oAnulados.CL_NroSecuencialModificado;
            r["CL_NroAutorizaModificado"] = oAnulados.CL_NroAutorizaModificado;
            r["baseImpExe"] = oAnulados.baseImpExe;
            r["valRetBien10"] = oAnulados.valRetBien10;
            r["pagoRegFis"] = oAnulados.pagoRegFis;
            r["fechaPagoDiv"] = oAnulados.fechaPagoDiv;
            r["imRentaSoc"] = oAnulados.imRentaSoc;
            r["anioUtDiv"] = oAnulados.anioUtDiv;
            r["NumCajBan"] = oAnulados.NumCajBan;
            r["PrecCajBan"] = oAnulados.PrecCajBan;
            r["imRentaSoc1"] = oAnulados.imRentaSoc1;
            r["anioUtDiv1"] = oAnulados.anioUtDiv1;
            r["NumCajBan1"] = oAnulados.NumCajBan1;
            r["PrecCajBan1"] = oAnulados.PrecCajBan1;
            r["CL_CodRetFteImpRenta2"] = oAnulados.CL_CodRetFteImpRenta2;
            r["CL_BaseImponibleIR2"] = oAnulados.CL_BaseImponibleIR2;
            r["CL_CodPorcRetIR2"] = oAnulados.CL_CodPorcRetIR2;
            r["fechaPagoDiv2"] = oAnulados.fechaPagoDiv2;
            r["imRentaSoc2"] = oAnulados.imRentaSoc2;
            r["anioUtDiv2"] = oAnulados.anioUtDiv2;
            r["NumCajBan2"] = oAnulados.NumCajBan2;
            r["PrecCajBan2"] = oAnulados.PrecCajBan2;
            r["CL_CodRetFteImpRenta3"] = oAnulados.CL_CodRetFteImpRenta3;
            r["CL_BaseImponibleIR3"] = oAnulados.CL_BaseImponibleIR3;
            r["CL_CodPorcRetIR3"] = oAnulados.CL_CodPorcRetIR3;
            r["fechaPagoDiv3"] = oAnulados.fechaPagoDiv3;
            r["imRentaSoc3"] = oAnulados.imRentaSoc3;
            r["anioUtDiv3"] = oAnulados.anioUtDiv3;
            r["NumCajBan3"] = oAnulados.NumCajBan3;
            r["PrecCajBan3"] = oAnulados.PrecCajBan3;
            r["tipoComprobanteReemb"] = oAnulados.tipoComprobanteReemb;
            r["tpIdProvReemb"] = oAnulados.tpIdProvReemb;
            r["idProvReemb"] = oAnulados.idProvReemb;
            r["establecimientoReemb"] = oAnulados.establecimientoReemb;
            r["puntoEmisionReemb"] = oAnulados.puntoEmisionReemb;
            r["secuencialReemb"] = oAnulados.secuencialReemb;
            r["fechaEmisionReemb"] = oAnulados.fechaEmisionReemb;
            r["autorizacionReemb"] = oAnulados.autorizacionReemb;
            r["baseImponibleReemb"] = oAnulados.baseImponibleReemb;
            r["baseImpGravReemb"] = oAnulados.baseImpGravReemb;
            r["baseNoGraIvaReemb"] = oAnulados.baseNoGraIvaReemb;
            r["baseImpExeReemb"] = oAnulados.baseImpExeReemb;
            r["montoIceRemb"] = oAnulados.montoIceRemb;
            r["montoIvaRemb"] = oAnulados.montoIvaRemb;
            r["valRetBien20"] = oAnulados.valRetBien20;
            r["fechaPagoDiv1"] = oAnulados.fechaPagoDiv1;
            r["valRetServ20"] = oAnulados.valRetServ20;
            r["codRetAir2"] = oAnulados.codRetAir2;
            r["baseImpAir2"] = oAnulados.baseImpAir2;
            r["porcentajeAir2"] = oAnulados.porcentajeAir2;
            r["valRetAir2"] = oAnulados.valRetAir2;
            r["codRetAir3"] = oAnulados.codRetAir3;
            r["baseImpAir3"] = oAnulados.baseImpAir3;
            r["porcentajeAir3"] = oAnulados.porcentajeAir3;
            r["valRetAir3"] = oAnulados.valRetAir3;
            r["totbasesImpReemb"] = oAnulados.totbasesImpReemb;
            r["idclavedoc"] = oAnulados.idclavedoc;
            r["doc_sucursal"] = oAnulados.doc_sucursal;
            r["opc_documento"] = oAnulados.opc_documento;
            r["CL_NroSerieEstableci"] = oAnulados.CL_NroSerieEstableci;
            r["CL_NroSerieEmision"] = oAnulados.CL_NroSerieEmision;
            r["CL_NroSecuencialDesde"] = oAnulados.CL_NroSecuencialDesde;
            r["CL_NroSecuencialHasta"] = oAnulados.CL_NroSecuencialHasta;
            r["Anio"] = oAnulados.Anio;
            r["Mes"] = oAnulados.Mes;
        }
        //
        // crea una nueva fila y la asigna a un objeto Anulados
        private static void nuevoAnulados(DataTable dt, Anulados oAnulados)
        {
            // Crear un nuevo Anulados
            DataRow dr = dt.NewRow();
            Anulados oA = row2Anulados(dr);
            //
            oA.CL_ExportaciónDe = oAnulados.CL_ExportaciónDe;
            oA.Cl_TipoComprobante = oAnulados.Cl_TipoComprobante;
            oA.CL_ReferendoDistrito = oAnulados.CL_ReferendoDistrito;
            oA.CL_ReferendoAño = oAnulados.CL_ReferendoAño;
            oA.CL_ReferendoRegimen = oAnulados.CL_ReferendoRegimen;
            oA.CL_ReferendoCorrelativo = oAnulados.CL_ReferendoCorrelativo;
            oA.CL_ReferendoVerificador = oAnulados.CL_ReferendoVerificador;
            oA.CL_NroDocTransporte = oAnulados.CL_NroDocTransporte;
            oA.CL_FechaTransaccion = oAnulados.CL_FechaTransaccion;
            oA.CL_NroFUE = oAnulados.CL_NroFUE;
            oA.CL_ValorFOB = oAnulados.CL_ValorFOB;
            oA.CL_ValorComprobante = oAnulados.CL_ValorComprobante;
            oA.CL_NroSerieCpbteEstablec = oAnulados.CL_NroSerieCpbteEstablec;
            oA.CL_NroSerieCpbteEmision = oAnulados.CL_NroSerieCpbteEmision;
            oA.CL_NroSecuencialCpbte = oAnulados.CL_NroSecuencialCpbte;
            oA.CL_NroAutorizacion = oAnulados.CL_NroAutorizacion;
            oA.CL_FechaEmision = oAnulados.CL_FechaEmision;
            oA.Clave = oAnulados.Clave;
            oA.CL_mes = oAnulados.CL_mes;
            oA.CL_anio = oAnulados.CL_anio;
            oA.suc = oAnulados.suc;
            oA.doc = oAnulados.doc;
            oA.Cl_TipoId = oAnulados.Cl_TipoId;
            oA.Cl_CodigoCliente = oAnulados.Cl_CodigoCliente;
            oA.CL_NroDeComprobantes = oAnulados.CL_NroDeComprobantes;
            oA.CL_BaseNoGrabaIva = oAnulados.CL_BaseNoGrabaIva;
            oA.CL_BaseImpTarCero = oAnulados.CL_BaseImpTarCero;
            oA.CL_BaseImpGravadaIva = oAnulados.CL_BaseImpGravadaIva;
            oA.CL_MontoIva = oAnulados.CL_MontoIva;
            oA.CL_ValorRetIva = oAnulados.CL_ValorRetIva;
            oA.CL_ValorRetRenta = oAnulados.CL_ValorRetRenta;
            oA.montoIce = oAnulados.montoIce;
            oA.parteRelVtas = oAnulados.parteRelVtas;
            oA.CL_SusTributario = oAnulados.CL_SusTributario;
            oA.CL_TipoIdProveedor = oAnulados.CL_TipoIdProveedor;
            oA.CL_CodigoProveedor = oAnulados.CL_CodigoProveedor;
            oA.CL_TipoProveedor = oAnulados.CL_TipoProveedor;
            oA.CL_ParteRelacionada = oAnulados.CL_ParteRelacionada;
            oA.CL_FechaRegContable = oAnulados.CL_FechaRegContable;
            oA.CL_NroSerieEstablec = oAnulados.CL_NroSerieEstablec;
            oA.CL_NroSeriePtoEmision = oAnulados.CL_NroSeriePtoEmision;
            oA.CL_NroSecuencial = oAnulados.CL_NroSecuencial;
            oA.CL_FechaComprobante = oAnulados.CL_FechaComprobante;
            oA.CL_MontoICE = oAnulados.CL_MontoICE;
            oA.CL_MontoRetIvaBienes = oAnulados.CL_MontoRetIvaBienes;
            oA.CL_MontoRetIvaServicios = oAnulados.CL_MontoRetIvaServicios;
            oA.CL_MontoRetIva100 = oAnulados.CL_MontoRetIva100;
            oA.CL_pagoLocExt = oAnulados.CL_pagoLocExt;
            oA.CL_pagoPais = oAnulados.CL_pagoPais;
            oA.CL_dobleTributacion = oAnulados.CL_dobleTributacion;
            oA.CL_pagoSujetoRetencion = oAnulados.CL_pagoSujetoRetencion;
            oA.CL_formaDePago = oAnulados.CL_formaDePago;
            oA.CL_CodRetFteImpRenta0 = oAnulados.CL_CodRetFteImpRenta0;
            oA.CL_BaseImponibleIR0 = oAnulados.CL_BaseImponibleIR0;
            oA.CL_CodPorcRetIR0 = oAnulados.CL_CodPorcRetIR0;
            oA.CL_MontoRetIR0 = oAnulados.CL_MontoRetIR0;
            oA.CL_CodRetFteImpRenta1 = oAnulados.CL_CodRetFteImpRenta1;
            oA.CL_BaseImponibleIR1 = oAnulados.CL_BaseImponibleIR1;
            oA.CL_CodPorcRetIR1 = oAnulados.CL_CodPorcRetIR1;
            oA.CL_MontoRetIR1 = oAnulados.CL_MontoRetIR1;
            oA.CL_NroSerieCpbteRetEstable = oAnulados.CL_NroSerieCpbteRetEstable;
            oA.CL_NroSerieCpbteRetEmision = oAnulados.CL_NroSerieCpbteRetEmision;
            oA.CL_NroSecuencialCpbteRet = oAnulados.CL_NroSecuencialCpbteRet;
            oA.CL_NroAutorizaCpbteRete = oAnulados.CL_NroAutorizaCpbteRete;
            oA.CL_FechaEmisionCpbteRete = oAnulados.CL_FechaEmisionCpbteRete;
            oA.CL_CodigoTipoModificado = oAnulados.CL_CodigoTipoModificado;
            oA.CL_NroSerieModificadoEstab = oAnulados.CL_NroSerieModificadoEstab;
            oA.CL_NroSerieModificadoEmision = oAnulados.CL_NroSerieModificadoEmision;
            oA.CL_NroSecuencialModificado = oAnulados.CL_NroSecuencialModificado;
            oA.CL_NroAutorizaModificado = oAnulados.CL_NroAutorizaModificado;
            oA.baseImpExe = oAnulados.baseImpExe;
            oA.valRetBien10 = oAnulados.valRetBien10;
            oA.pagoRegFis = oAnulados.pagoRegFis;
            oA.fechaPagoDiv = oAnulados.fechaPagoDiv;
            oA.imRentaSoc = oAnulados.imRentaSoc;
            oA.anioUtDiv = oAnulados.anioUtDiv;
            oA.NumCajBan = oAnulados.NumCajBan;
            oA.PrecCajBan = oAnulados.PrecCajBan;
            oA.imRentaSoc1 = oAnulados.imRentaSoc1;
            oA.anioUtDiv1 = oAnulados.anioUtDiv1;
            oA.NumCajBan1 = oAnulados.NumCajBan1;
            oA.PrecCajBan1 = oAnulados.PrecCajBan1;
            oA.CL_CodRetFteImpRenta2 = oAnulados.CL_CodRetFteImpRenta2;
            oA.CL_BaseImponibleIR2 = oAnulados.CL_BaseImponibleIR2;
            oA.CL_CodPorcRetIR2 = oAnulados.CL_CodPorcRetIR2;
            oA.fechaPagoDiv2 = oAnulados.fechaPagoDiv2;
            oA.imRentaSoc2 = oAnulados.imRentaSoc2;
            oA.anioUtDiv2 = oAnulados.anioUtDiv2;
            oA.NumCajBan2 = oAnulados.NumCajBan2;
            oA.PrecCajBan2 = oAnulados.PrecCajBan2;
            oA.CL_CodRetFteImpRenta3 = oAnulados.CL_CodRetFteImpRenta3;
            oA.CL_BaseImponibleIR3 = oAnulados.CL_BaseImponibleIR3;
            oA.CL_CodPorcRetIR3 = oAnulados.CL_CodPorcRetIR3;
            oA.fechaPagoDiv3 = oAnulados.fechaPagoDiv3;
            oA.imRentaSoc3 = oAnulados.imRentaSoc3;
            oA.anioUtDiv3 = oAnulados.anioUtDiv3;
            oA.NumCajBan3 = oAnulados.NumCajBan3;
            oA.PrecCajBan3 = oAnulados.PrecCajBan3;
            oA.tipoComprobanteReemb = oAnulados.tipoComprobanteReemb;
            oA.tpIdProvReemb = oAnulados.tpIdProvReemb;
            oA.idProvReemb = oAnulados.idProvReemb;
            oA.establecimientoReemb = oAnulados.establecimientoReemb;
            oA.puntoEmisionReemb = oAnulados.puntoEmisionReemb;
            oA.secuencialReemb = oAnulados.secuencialReemb;
            oA.fechaEmisionReemb = oAnulados.fechaEmisionReemb;
            oA.autorizacionReemb = oAnulados.autorizacionReemb;
            oA.baseImponibleReemb = oAnulados.baseImponibleReemb;
            oA.baseImpGravReemb = oAnulados.baseImpGravReemb;
            oA.baseNoGraIvaReemb = oAnulados.baseNoGraIvaReemb;
            oA.baseImpExeReemb = oAnulados.baseImpExeReemb;
            oA.montoIceRemb = oAnulados.montoIceRemb;
            oA.montoIvaRemb = oAnulados.montoIvaRemb;
            oA.valRetBien20 = oAnulados.valRetBien20;
            oA.fechaPagoDiv1 = oAnulados.fechaPagoDiv1;
            oA.valRetServ20 = oAnulados.valRetServ20;
            oA.codRetAir2 = oAnulados.codRetAir2;
            oA.baseImpAir2 = oAnulados.baseImpAir2;
            oA.porcentajeAir2 = oAnulados.porcentajeAir2;
            oA.valRetAir2 = oAnulados.valRetAir2;
            oA.codRetAir3 = oAnulados.codRetAir3;
            oA.baseImpAir3 = oAnulados.baseImpAir3;
            oA.porcentajeAir3 = oAnulados.porcentajeAir3;
            oA.valRetAir3 = oAnulados.valRetAir3;
            oA.totbasesImpReemb = oAnulados.totbasesImpReemb;
            oA.idclavedoc = oAnulados.idclavedoc;
            oA.doc_sucursal = oAnulados.doc_sucursal;
            oA.opc_documento = oAnulados.opc_documento;
            oA.CL_NroSerieEstableci = oAnulados.CL_NroSerieEstableci;
            oA.CL_NroSerieEmision = oAnulados.CL_NroSerieEmision;
            oA.CL_NroSecuencialDesde = oAnulados.CL_NroSecuencialDesde;
            oA.CL_NroSecuencialHasta = oAnulados.CL_NroSecuencialHasta;
            oA.Anio = oAnulados.Anio;
            oA.Mes = oAnulados.Mes;
            //
            Anulados2Row(oA, dr);
            //
            dt.Rows.Add(dr);
        }
        //
        // Métodos públicos
        //
        // devuelve una tabla con los datos indicados en la cadena de selección
        public static DataTable Tabla()
        {
            return Tabla(CadenaSelect);
        }
        public static DataTable Tabla(string sel)
        {
            // devuelve una tabla con los datos de la tabla Anulados
            SqlDataAdapter da;
            DataTable dt = new DataTable("Anulados");
            //
            try
            {
                da = new SqlDataAdapter(sel, cadenaConexion);
                da.Fill(dt);
            }
            catch
            {
                return null;
            }
            //
            return dt;
        }
        //
        public static Anulados Buscar(string sWhere)
        {
            // Busca en la tabla los datos indicados en el parámetro
            // el parámetro contendrá lo que se usará después del WHERE
            Anulados oAnulados = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("Anulados");
            string sel = "SELECT * FROM Anulados WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oAnulados = row2Anulados(dt.Rows[0]);
            }
            return oAnulados;
        }
        //
        // Actualizar: Actualiza los datos en la tabla usando la instancia actual
        //             Si la instancia no hace referencia a un registro existente, se creará uno nuevo
        //             Para comprobar si el objeto en memoria coincide con uno existente,
        //             se comprueba si el Clave existe en la tabla.
        //             TODO: Si en lugar de Clave usas otro campo, indicalo en la cadena SELECT
        //                   También puedes usar la sobrecarga en la que se indica la cadena SELECT a usar
        public string Actualizar()
        {
            // TODO: Poner aquí la selección a realizar para acceder a este registro
            //       yo uso el Clave que es el identificador único de cada registro
            string sel = "SELECT * FROM Anulados WHERE Clave = " + this.Clave.ToString();
            return Actualizar(sel);
        }
        public string Actualizar(string sel)
        {
            // Actualiza los datos indicados
            // El parámetro, que es una cadena de selección, indicará el criterio de actualización
            //
            // En caso de error, devolverá la cadena empezando por ERROR.
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("Anulados");
            //
            cnn = new SqlConnection(cadenaConexion);
            //da = new SqlDataAdapter(CadenaSelect, cnn);
            da = new SqlDataAdapter(sel, cnn);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //
            //-------------------------------------------
            // Esta no es la más óptima, pero funcionará
            //-------------------------------------------
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.UpdateCommand = cb.GetUpdateCommand();
            //
            //--------------------------------------------------------------------
            // Esta está más optimizada pero debes comprobar que funciona bien...
            //--------------------------------------------------------------------
            //string sCommand;
            ////
            //// El comando UPDATE
            //// TODO: Comprobar cual es el campo de índice principal (sin duplicados)
            ////       Yo compruebo que sea un campo llamado Clave, pero en tu caso puede ser otro
            ////       Ese campo, (en mi caso Clave) será el que hay que poner al final junto al WHERE.
            //sCommand = "UPDATE Anulados SET CL_ExportaciónDe = @CL_ExportaciónDe, Cl_TipoComprobante = @Cl_TipoComprobante, CL_ReferendoDistrito = @CL_ReferendoDistrito, CL_ReferendoAño = @CL_ReferendoAño, CL_ReferendoRegimen = @CL_ReferendoRegimen, CL_ReferendoCorrelativo = @CL_ReferendoCorrelativo, CL_ReferendoVerificador = @CL_ReferendoVerificador, CL_NroDocTransporte = @CL_NroDocTransporte, CL_FechaTransaccion = @CL_FechaTransaccion, CL_NroFUE = @CL_NroFUE, CL_ValorFOB = @CL_ValorFOB, CL_ValorComprobante = @CL_ValorComprobante, CL_NroSerieCpbteEstablec = @CL_NroSerieCpbteEstablec, CL_NroSerieCpbteEmision = @CL_NroSerieCpbteEmision, CL_NroSecuencialCpbte = @CL_NroSecuencialCpbte, CL_NroAutorizacion = @CL_NroAutorizacion, CL_FechaEmision = @CL_FechaEmision, CL_mes = @CL_mes, CL_anio = @CL_anio, suc = @suc, doc = @doc, Cl_TipoId = @Cl_TipoId, Cl_CodigoCliente = @Cl_CodigoCliente, CL_NroDeComprobantes = @CL_NroDeComprobantes, CL_BaseNoGrabaIva = @CL_BaseNoGrabaIva, CL_BaseImpTarCero = @CL_BaseImpTarCero, CL_BaseImpGravadaIva = @CL_BaseImpGravadaIva, CL_MontoIva = @CL_MontoIva, CL_ValorRetIva = @CL_ValorRetIva, CL_ValorRetRenta = @CL_ValorRetRenta, montoIce = @montoIce, parteRelVtas = @parteRelVtas, CL_SusTributario = @CL_SusTributario, CL_TipoIdProveedor = @CL_TipoIdProveedor, CL_CodigoProveedor = @CL_CodigoProveedor, CL_TipoProveedor = @CL_TipoProveedor, CL_ParteRelacionada = @CL_ParteRelacionada, CL_FechaRegContable = @CL_FechaRegContable, CL_NroSerieEstablec = @CL_NroSerieEstablec, CL_NroSeriePtoEmision = @CL_NroSeriePtoEmision, CL_NroSecuencial = @CL_NroSecuencial, CL_FechaComprobante = @CL_FechaComprobante, CL_MontoICE = @CL_MontoICE, CL_MontoRetIvaBienes = @CL_MontoRetIvaBienes, CL_MontoRetIvaServicios = @CL_MontoRetIvaServicios, CL_MontoRetIva100 = @CL_MontoRetIva100, CL_pagoLocExt = @CL_pagoLocExt, CL_pagoPais = @CL_pagoPais, CL_dobleTributacion = @CL_dobleTributacion, CL_pagoSujetoRetencion = @CL_pagoSujetoRetencion, CL_formaDePago = @CL_formaDePago, CL_CodRetFteImpRenta0 = @CL_CodRetFteImpRenta0, CL_BaseImponibleIR0 = @CL_BaseImponibleIR0, CL_CodPorcRetIR0 = @CL_CodPorcRetIR0, CL_MontoRetIR0 = @CL_MontoRetIR0, CL_CodRetFteImpRenta1 = @CL_CodRetFteImpRenta1, CL_BaseImponibleIR1 = @CL_BaseImponibleIR1, CL_CodPorcRetIR1 = @CL_CodPorcRetIR1, CL_MontoRetIR1 = @CL_MontoRetIR1, CL_NroSerieCpbteRetEstable = @CL_NroSerieCpbteRetEstable, CL_NroSerieCpbteRetEmision = @CL_NroSerieCpbteRetEmision, CL_NroSecuencialCpbteRet = @CL_NroSecuencialCpbteRet, CL_NroAutorizaCpbteRete = @CL_NroAutorizaCpbteRete, CL_FechaEmisionCpbteRete = @CL_FechaEmisionCpbteRete, CL_CodigoTipoModificado = @CL_CodigoTipoModificado, CL_NroSerieModificadoEstab = @CL_NroSerieModificadoEstab, CL_NroSerieModificadoEmision = @CL_NroSerieModificadoEmision, CL_NroSecuencialModificado = @CL_NroSecuencialModificado, CL_NroAutorizaModificado = @CL_NroAutorizaModificado, baseImpExe = @baseImpExe, valRetBien10 = @valRetBien10, pagoRegFis = @pagoRegFis, fechaPagoDiv = @fechaPagoDiv, imRentaSoc = @imRentaSoc, anioUtDiv = @anioUtDiv, NumCajBan = @NumCajBan, PrecCajBan = @PrecCajBan, imRentaSoc1 = @imRentaSoc1, anioUtDiv1 = @anioUtDiv1, NumCajBan1 = @NumCajBan1, PrecCajBan1 = @PrecCajBan1, CL_CodRetFteImpRenta2 = @CL_CodRetFteImpRenta2, CL_BaseImponibleIR2 = @CL_BaseImponibleIR2, CL_CodPorcRetIR2 = @CL_CodPorcRetIR2, fechaPagoDiv2 = @fechaPagoDiv2, imRentaSoc2 = @imRentaSoc2, anioUtDiv2 = @anioUtDiv2, NumCajBan2 = @NumCajBan2, PrecCajBan2 = @PrecCajBan2, CL_CodRetFteImpRenta3 = @CL_CodRetFteImpRenta3, CL_BaseImponibleIR3 = @CL_BaseImponibleIR3, CL_CodPorcRetIR3 = @CL_CodPorcRetIR3, fechaPagoDiv3 = @fechaPagoDiv3, imRentaSoc3 = @imRentaSoc3, anioUtDiv3 = @anioUtDiv3, NumCajBan3 = @NumCajBan3, PrecCajBan3 = @PrecCajBan3, tipoComprobanteReemb = @tipoComprobanteReemb, tpIdProvReemb = @tpIdProvReemb, idProvReemb = @idProvReemb, establecimientoReemb = @establecimientoReemb, puntoEmisionReemb = @puntoEmisionReemb, secuencialReemb = @secuencialReemb, fechaEmisionReemb = @fechaEmisionReemb, autorizacionReemb = @autorizacionReemb, baseImponibleReemb = @baseImponibleReemb, baseImpGravReemb = @baseImpGravReemb, baseNoGraIvaReemb = @baseNoGraIvaReemb, baseImpExeReemb = @baseImpExeReemb, montoIceRemb = @montoIceRemb, montoIvaRemb = @montoIvaRemb, valRetBien20 = @valRetBien20, fechaPagoDiv1 = @fechaPagoDiv1, valRetServ20 = @valRetServ20, codRetAir2 = @codRetAir2, baseImpAir2 = @baseImpAir2, porcentajeAir2 = @porcentajeAir2, valRetAir2 = @valRetAir2, codRetAir3 = @codRetAir3, baseImpAir3 = @baseImpAir3, porcentajeAir3 = @porcentajeAir3, valRetAir3 = @valRetAir3, totbasesImpReemb = @totbasesImpReemb, idclavedoc = @idclavedoc, doc_sucursal = @doc_sucursal, opc_documento = @opc_documento, CL_NroSerieEstableci = @CL_NroSerieEstableci, CL_NroSerieEmision = @CL_NroSerieEmision, CL_NroSecuencialDesde = @CL_NroSecuencialDesde, CL_NroSecuencialHasta = @CL_NroSecuencialHasta, Anio = @Anio, thiss = @Mes  WHERE (Clave = @Clave)";
            //da.UpdateCommand = new SqlCommand(sCommand, cnn);
            //da.UpdateCommand.Parameters.Add("@CL_ExportaciónDe", SqlDbType.NVarChar, 50, "CL_ExportaciónDe");
            //da.UpdateCommand.Parameters.Add("@Cl_TipoComprobante", SqlDbType.NVarChar, 2, "Cl_TipoComprobante");
            //da.UpdateCommand.Parameters.Add("@CL_ReferendoDistrito", SqlDbType.NVarChar, 50, "CL_ReferendoDistrito");
            //da.UpdateCommand.Parameters.Add("@CL_ReferendoAño", SqlDbType.NVarChar, 50, "CL_ReferendoAño");
            //da.UpdateCommand.Parameters.Add("@CL_ReferendoRegimen", SqlDbType.NVarChar, 50, "CL_ReferendoRegimen");
            //da.UpdateCommand.Parameters.Add("@CL_ReferendoCorrelativo", SqlDbType.NVarChar, 50, "CL_ReferendoCorrelativo");
            //da.UpdateCommand.Parameters.Add("@CL_ReferendoVerificador", SqlDbType.NVarChar, 50, "CL_ReferendoVerificador");
            //da.UpdateCommand.Parameters.Add("@CL_NroDocTransporte", SqlDbType.NVarChar, 50, "CL_NroDocTransporte");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@CL_FechaTransaccion", SqlDbType.DateTime, 0, "CL_FechaTransaccion");
            //da.UpdateCommand.Parameters.Add("@CL_NroFUE", SqlDbType.NVarChar, 50, "CL_NroFUE");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@CL_ValorFOB", SqlDbType.Decimal, 0, "CL_ValorFOB");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@CL_ValorComprobante", SqlDbType.Decimal, 0, "CL_ValorComprobante");
            //da.UpdateCommand.Parameters.Add("@CL_NroSerieCpbteEstablec", SqlDbType.NVarChar, 50, "CL_NroSerieCpbteEstablec");
            //da.UpdateCommand.Parameters.Add("@CL_NroSerieCpbteEmision", SqlDbType.NVarChar, 50, "CL_NroSerieCpbteEmision");
            //da.UpdateCommand.Parameters.Add("@CL_NroSecuencialCpbte", SqlDbType.NVarChar, 50, "CL_NroSecuencialCpbte");
            //da.UpdateCommand.Parameters.Add("@CL_NroAutorizacion", SqlDbType.NVarChar, 50, "CL_NroAutorizacion");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@CL_FechaEmision", SqlDbType.DateTime, 0, "CL_FechaEmision");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@Clave", SqlDbType.Decimal, 0, "Clave");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@CL_mes", SqlDbType.Int, 0, "CL_mes");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@CL_anio", SqlDbType.Int, 0, "CL_anio");
            //da.UpdateCommand.Parameters.Add("@suc", SqlDbType.NVarChar, 3, "suc");
            //da.UpdateCommand.Parameters.Add("@doc", SqlDbType.NVarChar, 3, "doc");
            //da.UpdateCommand.Parameters.Add("@Cl_TipoId", SqlDbType.NVarChar, 50, "Cl_TipoId");
            //da.UpdateCommand.Parameters.Add("@Cl_CodigoCliente", SqlDbType.NVarChar, 50, "Cl_CodigoCliente");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@CL_NroDeComprobantes", SqlDbType.BigInt, 0, "CL_NroDeComprobantes");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@CL_BaseNoGrabaIva", SqlDbType.Decimal, 0, "CL_BaseNoGrabaIva");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@CL_BaseImpTarCero", SqlDbType.Decimal, 0, "CL_BaseImpTarCero");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@CL_BaseImpGravadaIva", SqlDbType.Decimal, 0, "CL_BaseImpGravadaIva");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@CL_MontoIva", SqlDbType.Decimal, 0, "CL_MontoIva");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@CL_ValorRetIva", SqlDbType.Decimal, 0, "CL_ValorRetIva");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@CL_ValorRetRenta", SqlDbType.Decimal, 0, "CL_ValorRetRenta");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@montoIce", SqlDbType.Decimal, 0, "montoIce");
            //da.UpdateCommand.Parameters.Add("@parteRelVtas", SqlDbType.NVarChar, 2, "parteRelVtas");
            //da.UpdateCommand.Parameters.Add("@CL_SusTributario", SqlDbType.NVarChar, 50, "CL_SusTributario");
            //da.UpdateCommand.Parameters.Add("@CL_TipoIdProveedor", SqlDbType.NVarChar, 50, "CL_TipoIdProveedor");
            //da.UpdateCommand.Parameters.Add("@CL_CodigoProveedor", SqlDbType.NVarChar, 50, "CL_CodigoProveedor");
            //da.UpdateCommand.Parameters.Add("@CL_TipoProveedor", SqlDbType.NVarChar, 3, "CL_TipoProveedor");
            //da.UpdateCommand.Parameters.Add("@CL_ParteRelacionada", SqlDbType.NVarChar, 3, "CL_ParteRelacionada");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@CL_FechaRegContable", SqlDbType.DateTime, 0, "CL_FechaRegContable");
            //da.UpdateCommand.Parameters.Add("@CL_NroSerieEstablec", SqlDbType.NVarChar, 50, "CL_NroSerieEstablec");
            //da.UpdateCommand.Parameters.Add("@CL_NroSeriePtoEmision", SqlDbType.NVarChar, 50, "CL_NroSeriePtoEmision");
            //da.UpdateCommand.Parameters.Add("@CL_NroSecuencial", SqlDbType.NVarChar, 20, "CL_NroSecuencial");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@CL_FechaComprobante", SqlDbType.DateTime, 0, "CL_FechaComprobante");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@CL_MontoICE", SqlDbType.Decimal, 0, "CL_MontoICE");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@CL_MontoRetIvaBienes", SqlDbType.Decimal, 0, "CL_MontoRetIvaBienes");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@CL_MontoRetIvaServicios", SqlDbType.Decimal, 0, "CL_MontoRetIvaServicios");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@CL_MontoRetIva100", SqlDbType.Decimal, 0, "CL_MontoRetIva100");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@CL_pagoLocExt", SqlDbType.Int, 0, "CL_pagoLocExt");
            //da.UpdateCommand.Parameters.Add("@CL_pagoPais", SqlDbType.NVarChar, 20, "CL_pagoPais");
            //da.UpdateCommand.Parameters.Add("@CL_dobleTributacion", SqlDbType.NVarChar, 10, "CL_dobleTributacion");
            //da.UpdateCommand.Parameters.Add("@CL_pagoSujetoRetencion", SqlDbType.NVarChar, 10, "CL_pagoSujetoRetencion");
            //da.UpdateCommand.Parameters.Add("@CL_formaDePago", SqlDbType.NVarChar, 50, "CL_formaDePago");
            //da.UpdateCommand.Parameters.Add("@CL_CodRetFteImpRenta0", SqlDbType.NVarChar, 5, "CL_CodRetFteImpRenta0");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@CL_BaseImponibleIR0", SqlDbType.Decimal, 0, "CL_BaseImponibleIR0");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@CL_CodPorcRetIR0", SqlDbType.Decimal, 0, "CL_CodPorcRetIR0");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@CL_MontoRetIR0", SqlDbType.Decimal, 0, "CL_MontoRetIR0");
            //da.UpdateCommand.Parameters.Add("@CL_CodRetFteImpRenta1", SqlDbType.NVarChar, 5, "CL_CodRetFteImpRenta1");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@CL_BaseImponibleIR1", SqlDbType.Decimal, 0, "CL_BaseImponibleIR1");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@CL_CodPorcRetIR1", SqlDbType.Decimal, 0, "CL_CodPorcRetIR1");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@CL_MontoRetIR1", SqlDbType.Decimal, 0, "CL_MontoRetIR1");
            //da.UpdateCommand.Parameters.Add("@CL_NroSerieCpbteRetEstable", SqlDbType.NVarChar, 3, "CL_NroSerieCpbteRetEstable");
            //da.UpdateCommand.Parameters.Add("@CL_NroSerieCpbteRetEmision", SqlDbType.NVarChar, 3, "CL_NroSerieCpbteRetEmision");
            //da.UpdateCommand.Parameters.Add("@CL_NroSecuencialCpbteRet", SqlDbType.NVarChar, 7, "CL_NroSecuencialCpbteRet");
            //da.UpdateCommand.Parameters.Add("@CL_NroAutorizaCpbteRete", SqlDbType.NVarChar, 50, "CL_NroAutorizaCpbteRete");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@CL_FechaEmisionCpbteRete", SqlDbType.DateTime, 0, "CL_FechaEmisionCpbteRete");
            //da.UpdateCommand.Parameters.Add("@CL_CodigoTipoModificado", SqlDbType.NVarChar, 2, "CL_CodigoTipoModificado");
            //da.UpdateCommand.Parameters.Add("@CL_NroSerieModificadoEstab", SqlDbType.NVarChar, 3, "CL_NroSerieModificadoEstab");
            //da.UpdateCommand.Parameters.Add("@CL_NroSerieModificadoEmision", SqlDbType.NVarChar, 3, "CL_NroSerieModificadoEmision");
            //da.UpdateCommand.Parameters.Add("@CL_NroSecuencialModificado", SqlDbType.NVarChar, 20, "CL_NroSecuencialModificado");
            //da.UpdateCommand.Parameters.Add("@CL_NroAutorizaModificado", SqlDbType.NVarChar, 50, "CL_NroAutorizaModificado");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@baseImpExe", SqlDbType.Decimal, 0, "baseImpExe");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@valRetBien10", SqlDbType.Decimal, 0, "valRetBien10");
            //da.UpdateCommand.Parameters.Add("@pagoRegFis", SqlDbType.NVarChar, 2, "pagoRegFis");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@fechaPagoDiv", SqlDbType.DateTime, 0, "fechaPagoDiv");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@imRentaSoc", SqlDbType.Decimal, 0, "imRentaSoc");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@anioUtDiv", SqlDbType.Int, 0, "anioUtDiv");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@NumCajBan", SqlDbType.Decimal, 0, "NumCajBan");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@PrecCajBan", SqlDbType.Decimal, 0, "PrecCajBan");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@imRentaSoc1", SqlDbType.Decimal, 0, "imRentaSoc1");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@anioUtDiv1", SqlDbType.Int, 0, "anioUtDiv1");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@NumCajBan1", SqlDbType.Decimal, 0, "NumCajBan1");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@PrecCajBan1", SqlDbType.Decimal, 0, "PrecCajBan1");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@CL_CodRetFteImpRenta2", SqlDbType.Decimal, 0, "CL_CodRetFteImpRenta2");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@CL_BaseImponibleIR2", SqlDbType.Decimal, 0, "CL_BaseImponibleIR2");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@CL_CodPorcRetIR2", SqlDbType.Decimal, 0, "CL_CodPorcRetIR2");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@fechaPagoDiv2", SqlDbType.DateTime, 0, "fechaPagoDiv2");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@imRentaSoc2", SqlDbType.Decimal, 0, "imRentaSoc2");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@anioUtDiv2", SqlDbType.Int, 0, "anioUtDiv2");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@NumCajBan2", SqlDbType.Decimal, 0, "NumCajBan2");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@PrecCajBan2", SqlDbType.Decimal, 0, "PrecCajBan2");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@CL_CodRetFteImpRenta3", SqlDbType.Decimal, 0, "CL_CodRetFteImpRenta3");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@CL_BaseImponibleIR3", SqlDbType.Decimal, 0, "CL_BaseImponibleIR3");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@CL_CodPorcRetIR3", SqlDbType.Decimal, 0, "CL_CodPorcRetIR3");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@fechaPagoDiv3", SqlDbType.DateTime, 0, "fechaPagoDiv3");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@imRentaSoc3", SqlDbType.Decimal, 0, "imRentaSoc3");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@anioUtDiv3", SqlDbType.Int, 0, "anioUtDiv3");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@NumCajBan3", SqlDbType.Decimal, 0, "NumCajBan3");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@PrecCajBan3", SqlDbType.Decimal, 0, "PrecCajBan3");
            //da.UpdateCommand.Parameters.Add("@tipoComprobanteReemb", SqlDbType.NVarChar, 3, "tipoComprobanteReemb");
            //da.UpdateCommand.Parameters.Add("@tpIdProvReemb", SqlDbType.NVarChar, 2, "tpIdProvReemb");
            //da.UpdateCommand.Parameters.Add("@idProvReemb", SqlDbType.NVarChar, 15, "idProvReemb");
            //da.UpdateCommand.Parameters.Add("@establecimientoReemb", SqlDbType.NVarChar, 3, "establecimientoReemb");
            //da.UpdateCommand.Parameters.Add("@puntoEmisionReemb", SqlDbType.NVarChar, 3, "puntoEmisionReemb");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@secuencialReemb", SqlDbType.Decimal, 0, "secuencialReemb");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@fechaEmisionReemb", SqlDbType.DateTime, 0, "fechaEmisionReemb");
            //da.UpdateCommand.Parameters.Add("@autorizacionReemb", SqlDbType.NVarChar, 50, "autorizacionReemb");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@baseImponibleReemb", SqlDbType.Decimal, 0, "baseImponibleReemb");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@baseImpGravReemb", SqlDbType.Decimal, 0, "baseImpGravReemb");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@baseNoGraIvaReemb", SqlDbType.Decimal, 0, "baseNoGraIvaReemb");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@baseImpExeReemb", SqlDbType.Decimal, 0, "baseImpExeReemb");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@montoIceRemb", SqlDbType.Decimal, 0, "montoIceRemb");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@montoIvaRemb", SqlDbType.Decimal, 0, "montoIvaRemb");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@valRetBien20", SqlDbType.Decimal, 0, "valRetBien20");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@fechaPagoDiv1", SqlDbType.DateTime, 0, "fechaPagoDiv1");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@valRetServ20", SqlDbType.Decimal, 0, "valRetServ20");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@codRetAir2", SqlDbType.Decimal, 0, "codRetAir2");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@baseImpAir2", SqlDbType.Decimal, 0, "baseImpAir2");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@porcentajeAir2", SqlDbType.Decimal, 0, "porcentajeAir2");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@valRetAir2", SqlDbType.Decimal, 0, "valRetAir2");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@codRetAir3", SqlDbType.Decimal, 0, "codRetAir3");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@baseImpAir3", SqlDbType.Decimal, 0, "baseImpAir3");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@porcentajeAir3", SqlDbType.Decimal, 0, "porcentajeAir3");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@valRetAir3", SqlDbType.Decimal, 0, "valRetAir3");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@totbasesImpReemb", SqlDbType.Decimal, 0, "totbasesImpReemb");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@idclavedoc", SqlDbType.Decimal, 0, "idclavedoc");
            //da.UpdateCommand.Parameters.Add("@doc_sucursal", SqlDbType.NVarChar, 5, "doc_sucursal");
            //da.UpdateCommand.Parameters.Add("@opc_documento", SqlDbType.NVarChar, 5, "opc_documento");
            //da.UpdateCommand.Parameters.Add("@CL_NroSerieEstableci", SqlDbType.NVarChar, 3, "CL_NroSerieEstableci");
            //da.UpdateCommand.Parameters.Add("@CL_NroSerieEmision", SqlDbType.NVarChar, 3, "CL_NroSerieEmision");
            //da.UpdateCommand.Parameters.Add("@CL_NroSecuencialDesde", SqlDbType.NVarChar, 50, "CL_NroSecuencialDesde");
            //da.UpdateCommand.Parameters.Add("@CL_NroSecuencialHasta", SqlDbType.NVarChar, 50, "CL_NroSecuencialHasta");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@Anio", SqlDbType.Int, 0, "Anio");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.UpdateCommand.Parameters.Add("@Mes", SqlDbType.Int, 0, "Mes");
            //
            try
            {
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
            //
            if (dt.Rows.Count == 0)
            {
                // crear uno nuevo
                return Crear();
            }
            else
            {
                Anulados2Row(this, dt.Rows[0]);
            }
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Crear()
        {
            // Crear un nuevo registro
            // En caso de error, devolverá la cadena de error empezando por ERROR:.
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("Anulados");
            //
            cnn = new SqlConnection(cadenaConexion);
            da = new SqlDataAdapter(CadenaSelect, cnn);
            //da = new SqlDataAdapter(CadenaSelect, cadenaConexion);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //
            //-------------------------------------------
            // Esta no es la más óptima, pero funcionará
            //-------------------------------------------
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.InsertCommand = cb.GetInsertCommand();
            //
            //--------------------------------------------------------------------
            // Esta está más optimizada pero debes comprobar que funciona bien...
            //--------------------------------------------------------------------
            //string sCommand;
            ////
            //// El comando INSERT
            //// TODO: No incluir el campo de clave primaria incremental
            ////       Yo compruebo que sea un campo llamado Clave, pero en tu caso puede ser otro
            //sCommand = "INSERT INTO Anulados (CL_ExportaciónDe, Cl_TipoComprobante, CL_ReferendoDistrito, CL_ReferendoAño, CL_ReferendoRegimen, CL_ReferendoCorrelativo, CL_ReferendoVerificador, CL_NroDocTransporte, CL_FechaTransaccion, CL_NroFUE, CL_ValorFOB, CL_ValorComprobante, CL_NroSerieCpbteEstablec, CL_NroSerieCpbteEmision, CL_NroSecuencialCpbte, CL_NroAutorizacion, CL_FechaEmision, CL_mes, CL_anio, suc, doc, Cl_TipoId, Cl_CodigoCliente, CL_NroDeComprobantes, CL_BaseNoGrabaIva, CL_BaseImpTarCero, CL_BaseImpGravadaIva, CL_MontoIva, CL_ValorRetIva, CL_ValorRetRenta, montoIce, parteRelVtas, CL_SusTributario, CL_TipoIdProveedor, CL_CodigoProveedor, CL_TipoProveedor, CL_ParteRelacionada, CL_FechaRegContable, CL_NroSerieEstablec, CL_NroSeriePtoEmision, CL_NroSecuencial, CL_FechaComprobante, CL_MontoICE, CL_MontoRetIvaBienes, CL_MontoRetIvaServicios, CL_MontoRetIva100, CL_pagoLocExt, CL_pagoPais, CL_dobleTributacion, CL_pagoSujetoRetencion, CL_formaDePago, CL_CodRetFteImpRenta0, CL_BaseImponibleIR0, CL_CodPorcRetIR0, CL_MontoRetIR0, CL_CodRetFteImpRenta1, CL_BaseImponibleIR1, CL_CodPorcRetIR1, CL_MontoRetIR1, CL_NroSerieCpbteRetEstable, CL_NroSerieCpbteRetEmision, CL_NroSecuencialCpbteRet, CL_NroAutorizaCpbteRete, CL_FechaEmisionCpbteRete, CL_CodigoTipoModificado, CL_NroSerieModificadoEstab, CL_NroSerieModificadoEmision, CL_NroSecuencialModificado, CL_NroAutorizaModificado, baseImpExe, valRetBien10, pagoRegFis, fechaPagoDiv, imRentaSoc, anioUtDiv, NumCajBan, PrecCajBan, imRentaSoc1, anioUtDiv1, NumCajBan1, PrecCajBan1, CL_CodRetFteImpRenta2, CL_BaseImponibleIR2, CL_CodPorcRetIR2, fechaPagoDiv2, imRentaSoc2, anioUtDiv2, NumCajBan2, PrecCajBan2, CL_CodRetFteImpRenta3, CL_BaseImponibleIR3, CL_CodPorcRetIR3, fechaPagoDiv3, imRentaSoc3, anioUtDiv3, NumCajBan3, PrecCajBan3, tipoComprobanteReemb, tpIdProvReemb, idProvReemb, establecimientoReemb, puntoEmisionReemb, secuencialReemb, fechaEmisionReemb, autorizacionReemb, baseImponibleReemb, baseImpGravReemb, baseNoGraIvaReemb, baseImpExeReemb, montoIceRemb, montoIvaRemb, valRetBien20, fechaPagoDiv1, valRetServ20, codRetAir2, baseImpAir2, porcentajeAir2, valRetAir2, codRetAir3, baseImpAir3, porcentajeAir3, valRetAir3, totbasesImpReemb, idclavedoc, doc_sucursal, opc_documento, CL_NroSerieEstableci, CL_NroSerieEmision, CL_NroSecuencialDesde, CL_NroSecuencialHasta, Anio, thiss)  VALUES(@CL_ExportaciónDe, @Cl_TipoComprobante, @CL_ReferendoDistrito, @CL_ReferendoAño, @CL_ReferendoRegimen, @CL_ReferendoCorrelativo, @CL_ReferendoVerificador, @CL_NroDocTransporte, @CL_FechaTransaccion, @CL_NroFUE, @CL_ValorFOB, @CL_ValorComprobante, @CL_NroSerieCpbteEstablec, @CL_NroSerieCpbteEmision, @CL_NroSecuencialCpbte, @CL_NroAutorizacion, @CL_FechaEmision, @CL_mes, @CL_anio, @suc, @doc, @Cl_TipoId, @Cl_CodigoCliente, @CL_NroDeComprobantes, @CL_BaseNoGrabaIva, @CL_BaseImpTarCero, @CL_BaseImpGravadaIva, @CL_MontoIva, @CL_ValorRetIva, @CL_ValorRetRenta, @montoIce, @parteRelVtas, @CL_SusTributario, @CL_TipoIdProveedor, @CL_CodigoProveedor, @CL_TipoProveedor, @CL_ParteRelacionada, @CL_FechaRegContable, @CL_NroSerieEstablec, @CL_NroSeriePtoEmision, @CL_NroSecuencial, @CL_FechaComprobante, @CL_MontoICE, @CL_MontoRetIvaBienes, @CL_MontoRetIvaServicios, @CL_MontoRetIva100, @CL_pagoLocExt, @CL_pagoPais, @CL_dobleTributacion, @CL_pagoSujetoRetencion, @CL_formaDePago, @CL_CodRetFteImpRenta0, @CL_BaseImponibleIR0, @CL_CodPorcRetIR0, @CL_MontoRetIR0, @CL_CodRetFteImpRenta1, @CL_BaseImponibleIR1, @CL_CodPorcRetIR1, @CL_MontoRetIR1, @CL_NroSerieCpbteRetEstable, @CL_NroSerieCpbteRetEmision, @CL_NroSecuencialCpbteRet, @CL_NroAutorizaCpbteRete, @CL_FechaEmisionCpbteRete, @CL_CodigoTipoModificado, @CL_NroSerieModificadoEstab, @CL_NroSerieModificadoEmision, @CL_NroSecuencialModificado, @CL_NroAutorizaModificado, @baseImpExe, @valRetBien10, @pagoRegFis, @fechaPagoDiv, @imRentaSoc, @anioUtDiv, @NumCajBan, @PrecCajBan, @imRentaSoc1, @anioUtDiv1, @NumCajBan1, @PrecCajBan1, @CL_CodRetFteImpRenta2, @CL_BaseImponibleIR2, @CL_CodPorcRetIR2, @fechaPagoDiv2, @imRentaSoc2, @anioUtDiv2, @NumCajBan2, @PrecCajBan2, @CL_CodRetFteImpRenta3, @CL_BaseImponibleIR3, @CL_CodPorcRetIR3, @fechaPagoDiv3, @imRentaSoc3, @anioUtDiv3, @NumCajBan3, @PrecCajBan3, @tipoComprobanteReemb, @tpIdProvReemb, @idProvReemb, @establecimientoReemb, @puntoEmisionReemb, @secuencialReemb, @fechaEmisionReemb, @autorizacionReemb, @baseImponibleReemb, @baseImpGravReemb, @baseNoGraIvaReemb, @baseImpExeReemb, @montoIceRemb, @montoIvaRemb, @valRetBien20, @fechaPagoDiv1, @valRetServ20, @codRetAir2, @baseImpAir2, @porcentajeAir2, @valRetAir2, @codRetAir3, @baseImpAir3, @porcentajeAir3, @valRetAir3, @totbasesImpReemb, @idclavedoc, @doc_sucursal, @opc_documento, @CL_NroSerieEstableci, @CL_NroSerieEmision, @CL_NroSecuencialDesde, @CL_NroSecuencialHasta, @Anio, @Mes)";
            //da.InsertCommand = new SqlCommand(sCommand, cnn);
            //da.InsertCommand.Parameters.Add("@CL_ExportaciónDe", SqlDbType.NVarChar, 50, "CL_ExportaciónDe");
            //da.InsertCommand.Parameters.Add("@Cl_TipoComprobante", SqlDbType.NVarChar, 2, "Cl_TipoComprobante");
            //da.InsertCommand.Parameters.Add("@CL_ReferendoDistrito", SqlDbType.NVarChar, 50, "CL_ReferendoDistrito");
            //da.InsertCommand.Parameters.Add("@CL_ReferendoAño", SqlDbType.NVarChar, 50, "CL_ReferendoAño");
            //da.InsertCommand.Parameters.Add("@CL_ReferendoRegimen", SqlDbType.NVarChar, 50, "CL_ReferendoRegimen");
            //da.InsertCommand.Parameters.Add("@CL_ReferendoCorrelativo", SqlDbType.NVarChar, 50, "CL_ReferendoCorrelativo");
            //da.InsertCommand.Parameters.Add("@CL_ReferendoVerificador", SqlDbType.NVarChar, 50, "CL_ReferendoVerificador");
            //da.InsertCommand.Parameters.Add("@CL_NroDocTransporte", SqlDbType.NVarChar, 50, "CL_NroDocTransporte");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_FechaTransaccion", SqlDbType.DateTime, 0, "CL_FechaTransaccion");
            //da.InsertCommand.Parameters.Add("@CL_NroFUE", SqlDbType.NVarChar, 50, "CL_NroFUE");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_ValorFOB", SqlDbType.Decimal, 0, "CL_ValorFOB");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_ValorComprobante", SqlDbType.Decimal, 0, "CL_ValorComprobante");
            //da.InsertCommand.Parameters.Add("@CL_NroSerieCpbteEstablec", SqlDbType.NVarChar, 50, "CL_NroSerieCpbteEstablec");
            //da.InsertCommand.Parameters.Add("@CL_NroSerieCpbteEmision", SqlDbType.NVarChar, 50, "CL_NroSerieCpbteEmision");
            //da.InsertCommand.Parameters.Add("@CL_NroSecuencialCpbte", SqlDbType.NVarChar, 50, "CL_NroSecuencialCpbte");
            //da.InsertCommand.Parameters.Add("@CL_NroAutorizacion", SqlDbType.NVarChar, 50, "CL_NroAutorizacion");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_FechaEmision", SqlDbType.DateTime, 0, "CL_FechaEmision");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@Clave", SqlDbType.Decimal, 0, "Clave");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_mes", SqlDbType.Int, 0, "CL_mes");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_anio", SqlDbType.Int, 0, "CL_anio");
            //da.InsertCommand.Parameters.Add("@suc", SqlDbType.NVarChar, 3, "suc");
            //da.InsertCommand.Parameters.Add("@doc", SqlDbType.NVarChar, 3, "doc");
            //da.InsertCommand.Parameters.Add("@Cl_TipoId", SqlDbType.NVarChar, 50, "Cl_TipoId");
            //da.InsertCommand.Parameters.Add("@Cl_CodigoCliente", SqlDbType.NVarChar, 50, "Cl_CodigoCliente");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_NroDeComprobantes", SqlDbType.BigInt, 0, "CL_NroDeComprobantes");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_BaseNoGrabaIva", SqlDbType.Decimal, 0, "CL_BaseNoGrabaIva");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_BaseImpTarCero", SqlDbType.Decimal, 0, "CL_BaseImpTarCero");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_BaseImpGravadaIva", SqlDbType.Decimal, 0, "CL_BaseImpGravadaIva");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_MontoIva", SqlDbType.Decimal, 0, "CL_MontoIva");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_ValorRetIva", SqlDbType.Decimal, 0, "CL_ValorRetIva");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_ValorRetRenta", SqlDbType.Decimal, 0, "CL_ValorRetRenta");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@montoIce", SqlDbType.Decimal, 0, "montoIce");
            //da.InsertCommand.Parameters.Add("@parteRelVtas", SqlDbType.NVarChar, 2, "parteRelVtas");
            //da.InsertCommand.Parameters.Add("@CL_SusTributario", SqlDbType.NVarChar, 50, "CL_SusTributario");
            //da.InsertCommand.Parameters.Add("@CL_TipoIdProveedor", SqlDbType.NVarChar, 50, "CL_TipoIdProveedor");
            //da.InsertCommand.Parameters.Add("@CL_CodigoProveedor", SqlDbType.NVarChar, 50, "CL_CodigoProveedor");
            //da.InsertCommand.Parameters.Add("@CL_TipoProveedor", SqlDbType.NVarChar, 3, "CL_TipoProveedor");
            //da.InsertCommand.Parameters.Add("@CL_ParteRelacionada", SqlDbType.NVarChar, 3, "CL_ParteRelacionada");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_FechaRegContable", SqlDbType.DateTime, 0, "CL_FechaRegContable");
            //da.InsertCommand.Parameters.Add("@CL_NroSerieEstablec", SqlDbType.NVarChar, 50, "CL_NroSerieEstablec");
            //da.InsertCommand.Parameters.Add("@CL_NroSeriePtoEmision", SqlDbType.NVarChar, 50, "CL_NroSeriePtoEmision");
            //da.InsertCommand.Parameters.Add("@CL_NroSecuencial", SqlDbType.NVarChar, 20, "CL_NroSecuencial");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_FechaComprobante", SqlDbType.DateTime, 0, "CL_FechaComprobante");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_MontoICE", SqlDbType.Decimal, 0, "CL_MontoICE");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_MontoRetIvaBienes", SqlDbType.Decimal, 0, "CL_MontoRetIvaBienes");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_MontoRetIvaServicios", SqlDbType.Decimal, 0, "CL_MontoRetIvaServicios");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_MontoRetIva100", SqlDbType.Decimal, 0, "CL_MontoRetIva100");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_pagoLocExt", SqlDbType.Int, 0, "CL_pagoLocExt");
            //da.InsertCommand.Parameters.Add("@CL_pagoPais", SqlDbType.NVarChar, 20, "CL_pagoPais");
            //da.InsertCommand.Parameters.Add("@CL_dobleTributacion", SqlDbType.NVarChar, 10, "CL_dobleTributacion");
            //da.InsertCommand.Parameters.Add("@CL_pagoSujetoRetencion", SqlDbType.NVarChar, 10, "CL_pagoSujetoRetencion");
            //da.InsertCommand.Parameters.Add("@CL_formaDePago", SqlDbType.NVarChar, 50, "CL_formaDePago");
            //da.InsertCommand.Parameters.Add("@CL_CodRetFteImpRenta0", SqlDbType.NVarChar, 5, "CL_CodRetFteImpRenta0");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_BaseImponibleIR0", SqlDbType.Decimal, 0, "CL_BaseImponibleIR0");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_CodPorcRetIR0", SqlDbType.Decimal, 0, "CL_CodPorcRetIR0");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_MontoRetIR0", SqlDbType.Decimal, 0, "CL_MontoRetIR0");
            //da.InsertCommand.Parameters.Add("@CL_CodRetFteImpRenta1", SqlDbType.NVarChar, 5, "CL_CodRetFteImpRenta1");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_BaseImponibleIR1", SqlDbType.Decimal, 0, "CL_BaseImponibleIR1");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_CodPorcRetIR1", SqlDbType.Decimal, 0, "CL_CodPorcRetIR1");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_MontoRetIR1", SqlDbType.Decimal, 0, "CL_MontoRetIR1");
            //da.InsertCommand.Parameters.Add("@CL_NroSerieCpbteRetEstable", SqlDbType.NVarChar, 3, "CL_NroSerieCpbteRetEstable");
            //da.InsertCommand.Parameters.Add("@CL_NroSerieCpbteRetEmision", SqlDbType.NVarChar, 3, "CL_NroSerieCpbteRetEmision");
            //da.InsertCommand.Parameters.Add("@CL_NroSecuencialCpbteRet", SqlDbType.NVarChar, 7, "CL_NroSecuencialCpbteRet");
            //da.InsertCommand.Parameters.Add("@CL_NroAutorizaCpbteRete", SqlDbType.NVarChar, 50, "CL_NroAutorizaCpbteRete");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_FechaEmisionCpbteRete", SqlDbType.DateTime, 0, "CL_FechaEmisionCpbteRete");
            //da.InsertCommand.Parameters.Add("@CL_CodigoTipoModificado", SqlDbType.NVarChar, 2, "CL_CodigoTipoModificado");
            //da.InsertCommand.Parameters.Add("@CL_NroSerieModificadoEstab", SqlDbType.NVarChar, 3, "CL_NroSerieModificadoEstab");
            //da.InsertCommand.Parameters.Add("@CL_NroSerieModificadoEmision", SqlDbType.NVarChar, 3, "CL_NroSerieModificadoEmision");
            //da.InsertCommand.Parameters.Add("@CL_NroSecuencialModificado", SqlDbType.NVarChar, 20, "CL_NroSecuencialModificado");
            //da.InsertCommand.Parameters.Add("@CL_NroAutorizaModificado", SqlDbType.NVarChar, 50, "CL_NroAutorizaModificado");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@baseImpExe", SqlDbType.Decimal, 0, "baseImpExe");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@valRetBien10", SqlDbType.Decimal, 0, "valRetBien10");
            //da.InsertCommand.Parameters.Add("@pagoRegFis", SqlDbType.NVarChar, 2, "pagoRegFis");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@fechaPagoDiv", SqlDbType.DateTime, 0, "fechaPagoDiv");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@imRentaSoc", SqlDbType.Decimal, 0, "imRentaSoc");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@anioUtDiv", SqlDbType.Int, 0, "anioUtDiv");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@NumCajBan", SqlDbType.Decimal, 0, "NumCajBan");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@PrecCajBan", SqlDbType.Decimal, 0, "PrecCajBan");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@imRentaSoc1", SqlDbType.Decimal, 0, "imRentaSoc1");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@anioUtDiv1", SqlDbType.Int, 0, "anioUtDiv1");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@NumCajBan1", SqlDbType.Decimal, 0, "NumCajBan1");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@PrecCajBan1", SqlDbType.Decimal, 0, "PrecCajBan1");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_CodRetFteImpRenta2", SqlDbType.Decimal, 0, "CL_CodRetFteImpRenta2");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_BaseImponibleIR2", SqlDbType.Decimal, 0, "CL_BaseImponibleIR2");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_CodPorcRetIR2", SqlDbType.Decimal, 0, "CL_CodPorcRetIR2");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@fechaPagoDiv2", SqlDbType.DateTime, 0, "fechaPagoDiv2");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@imRentaSoc2", SqlDbType.Decimal, 0, "imRentaSoc2");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@anioUtDiv2", SqlDbType.Int, 0, "anioUtDiv2");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@NumCajBan2", SqlDbType.Decimal, 0, "NumCajBan2");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@PrecCajBan2", SqlDbType.Decimal, 0, "PrecCajBan2");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_CodRetFteImpRenta3", SqlDbType.Decimal, 0, "CL_CodRetFteImpRenta3");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_BaseImponibleIR3", SqlDbType.Decimal, 0, "CL_BaseImponibleIR3");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_CodPorcRetIR3", SqlDbType.Decimal, 0, "CL_CodPorcRetIR3");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@fechaPagoDiv3", SqlDbType.DateTime, 0, "fechaPagoDiv3");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@imRentaSoc3", SqlDbType.Decimal, 0, "imRentaSoc3");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@anioUtDiv3", SqlDbType.Int, 0, "anioUtDiv3");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@NumCajBan3", SqlDbType.Decimal, 0, "NumCajBan3");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@PrecCajBan3", SqlDbType.Decimal, 0, "PrecCajBan3");
            //da.InsertCommand.Parameters.Add("@tipoComprobanteReemb", SqlDbType.NVarChar, 3, "tipoComprobanteReemb");
            //da.InsertCommand.Parameters.Add("@tpIdProvReemb", SqlDbType.NVarChar, 2, "tpIdProvReemb");
            //da.InsertCommand.Parameters.Add("@idProvReemb", SqlDbType.NVarChar, 15, "idProvReemb");
            //da.InsertCommand.Parameters.Add("@establecimientoReemb", SqlDbType.NVarChar, 3, "establecimientoReemb");
            //da.InsertCommand.Parameters.Add("@puntoEmisionReemb", SqlDbType.NVarChar, 3, "puntoEmisionReemb");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@secuencialReemb", SqlDbType.Decimal, 0, "secuencialReemb");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@fechaEmisionReemb", SqlDbType.DateTime, 0, "fechaEmisionReemb");
            //da.InsertCommand.Parameters.Add("@autorizacionReemb", SqlDbType.NVarChar, 50, "autorizacionReemb");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@baseImponibleReemb", SqlDbType.Decimal, 0, "baseImponibleReemb");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@baseImpGravReemb", SqlDbType.Decimal, 0, "baseImpGravReemb");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@baseNoGraIvaReemb", SqlDbType.Decimal, 0, "baseNoGraIvaReemb");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@baseImpExeReemb", SqlDbType.Decimal, 0, "baseImpExeReemb");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@montoIceRemb", SqlDbType.Decimal, 0, "montoIceRemb");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@montoIvaRemb", SqlDbType.Decimal, 0, "montoIvaRemb");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@valRetBien20", SqlDbType.Decimal, 0, "valRetBien20");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@fechaPagoDiv1", SqlDbType.DateTime, 0, "fechaPagoDiv1");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@valRetServ20", SqlDbType.Decimal, 0, "valRetServ20");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@codRetAir2", SqlDbType.Decimal, 0, "codRetAir2");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@baseImpAir2", SqlDbType.Decimal, 0, "baseImpAir2");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@porcentajeAir2", SqlDbType.Decimal, 0, "porcentajeAir2");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@valRetAir2", SqlDbType.Decimal, 0, "valRetAir2");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@codRetAir3", SqlDbType.Decimal, 0, "codRetAir3");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@baseImpAir3", SqlDbType.Decimal, 0, "baseImpAir3");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@porcentajeAir3", SqlDbType.Decimal, 0, "porcentajeAir3");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@valRetAir3", SqlDbType.Decimal, 0, "valRetAir3");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@totbasesImpReemb", SqlDbType.Decimal, 0, "totbasesImpReemb");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@idclavedoc", SqlDbType.Decimal, 0, "idclavedoc");
            //da.InsertCommand.Parameters.Add("@doc_sucursal", SqlDbType.NVarChar, 5, "doc_sucursal");
            //da.InsertCommand.Parameters.Add("@opc_documento", SqlDbType.NVarChar, 5, "opc_documento");
            //da.InsertCommand.Parameters.Add("@CL_NroSerieEstableci", SqlDbType.NVarChar, 3, "CL_NroSerieEstableci");
            //da.InsertCommand.Parameters.Add("@CL_NroSerieEmision", SqlDbType.NVarChar, 3, "CL_NroSerieEmision");
            //da.InsertCommand.Parameters.Add("@CL_NroSecuencialDesde", SqlDbType.NVarChar, 50, "CL_NroSecuencialDesde");
            //da.InsertCommand.Parameters.Add("@CL_NroSecuencialHasta", SqlDbType.NVarChar, 50, "CL_NroSecuencialHasta");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@Anio", SqlDbType.Int, 0, "Anio");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@Mes", SqlDbType.Int, 0, "Mes");
            //
            //
            try
            {
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
            //
            nuevoAnulados(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo Anulados";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            // TODO: Poner aquí la selección a realizar para acceder a este registro
            //       yo uso el Clave que es el identificador único de cada registro
            string sel = "SELECT * FROM Anulados WHERE Clave = " + this.Clave.ToString();
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            // Borrar el registro al que apunta esta clase
            // En caso de error, devolverá la cadena de error empezando por ERROR:.
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("Anulados");
            //
            cnn = new SqlConnection(cadenaConexion);
            da = new SqlDataAdapter(sel, cnn);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //
            //-------------------------------------------
            // Esta no es la más óptima, pero funcionará
            //-------------------------------------------
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.DeleteCommand = cb.GetDeleteCommand();
            //
            //
            //--------------------------------------------------------------------
            // Esta está más optimizada pero debes comprobar que funciona bien...
            //--------------------------------------------------------------------
            //string sCommand;
            ////
            //// El comando DELETE
            //// TODO: Sólo incluir el campo de clave primaria incremental
            ////       Yo compruebo que sea un campo llamado Clave, pero en tu caso puede ser otro
            //sCommand = "DELETE FROM Anulados WHERE (Clave = @p1)";
            //da.DeleteCommand = new SqlCommand(sCommand, cnn);
            //// TODO: Comprobar el tipo de datos a usar...
            //da.DeleteCommand.Parameters.Add("@p1", SqlDbType.Decimal, 0, "Clave");
            //da.DeleteCommand.Parameters.Add("@p2", SqlDbType.Int, 0, "");
            //
            //
            da.Fill(dt);
            //
            if (dt.Rows.Count == 0)
            {
                return "ERROR: No hay datos";
            }
            else
            {
                dt.Rows[0].Delete();
            }
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Borrado satisfactoriamente";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
    }
}
