using System;
using System.Data;
using System.Data.SqlClient;

namespace ClassAts
{
    //------------------------------------------------------------------------------
    using System;
    using System.Data;
    using System.Data.SqlClient;
    //
    public class Compras
    {
        private System.String _CL_SusTributario;
        private System.String _CL_TipoIdProveedor;
        private System.String _CL_CodigoProveedor;
        private System.String _CL_nombreProveedor;
        private System.String _Cl_TipoComprobante;
        private System.String _CL_TipoProveedor;
        private System.String _CL_ParteRelacionada;
        private System.DateTime _CL_FechaRegContable;
        private System.String _CL_NroSerieEstablec;
        private System.String _CL_NroSeriePtoEmision;
        private System.String _CL_NroSecuencial;
        private System.DateTime _CL_FechaComprobante;
        private System.String _CL_NroAutorizacion;
        private System.Decimal _CL_BaseNoGrabaIva;
        private System.Decimal _CL_BaseImpTarCero;
        private System.Decimal _CL_BaseImpGravadaIva;
        private System.Decimal _CL_MontoICE;
        private System.Decimal _CL_MontoIva;
        private System.Decimal _CL_MontoRetIvaBienes;
        private System.Decimal _CL_MontoRetIvaServicios;
        private System.Decimal _CL_MontoRetIva100;
        private System.Int32 _CL_pagoLocExt;
        private System.String _CL_pagoPais;
        private System.String _CL_dobleTributacion;
        private System.String _CL_pagoSujetoRetencion;
        private System.String _CL_formaDePago;
        private System.String _CL_CodRetFteImpRenta0;
        private System.Decimal _CL_BaseImponibleIR0;
        private System.Decimal _CL_CodPorcRetIR0;
        private System.Decimal _CL_MontoRetIR0;
        private System.String _CL_CodRetFteImpRenta1;
        private System.Decimal _CL_BaseImponibleIR1;
        private System.Decimal _CL_CodPorcRetIR1;
        private System.Decimal _CL_MontoRetIR1;
        private System.String _CL_NroSerieCpbteRetEstable;
        private System.String _CL_NroSerieCpbteRetEmision;
        private System.String _CL_NroSecuencialCpbteRet;
        private System.String _CL_NroAutorizaCpbteRete;
        private System.DateTime _CL_FechaEmisionCpbteRete;
        private System.Decimal _Clave;
        private System.Int32 _Cl_Mes;
        private System.Int32 _Cl_Anio;
        private System.Decimal _baseImpExe;
        private System.Decimal _valRetBien10;
        private System.String _pagoRegFis;
        private System.DateTime _fechaPagoDiv;
        private System.Decimal _imRentaSoc;
        private System.Int32 _anioUtDiv;
        private System.Decimal _NumCajBan;
        private System.Decimal _PrecCajBan;
        private System.Decimal _imRentaSoc1;
        private System.Int32 _anioUtDiv1;
        private System.Decimal _NumCajBan1;
        private System.Decimal _PrecCajBan1;
        private System.Decimal _CL_CodRetFteImpRenta2;
        private System.Decimal _CL_BaseImponibleIR2;
        private System.Decimal _CL_CodPorcRetIR2;
        private System.DateTime _fechaPagoDiv2;
        private System.Decimal _imRentaSoc2;
        private System.Int32 _anioUtDiv2;
        private System.Decimal _NumCajBan2;
        private System.Decimal _PrecCajBan2;
        private System.Decimal _CL_CodRetFteImpRenta3;
        private System.Decimal _CL_BaseImponibleIR3;
        private System.Decimal _CL_CodPorcRetIR3;
        private System.DateTime _fechaPagoDiv3;
        private System.Decimal _imRentaSoc3;
        private System.Int32 _anioUtDiv3;
        private System.Decimal _NumCajBan3;
        private System.Decimal _PrecCajBan3;
        private System.Decimal _valRetBien20;
        private System.DateTime _fechaPagoDiv1;
        private System.Decimal _valRetServ20;
        private System.Decimal _valRetServ50;
        private System.Decimal _codRetAir2;
        private System.Decimal _baseImpAir2;
        private System.Decimal _porcentajeAir2;
        private System.Decimal _valRetAir2;
        private System.Decimal _codRetAir3;
        private System.Decimal _baseImpAir3;
        private System.Decimal _porcentajeAir3;
        private System.Decimal _valRetAir3;
        private System.Decimal _totbasesImpReemb;
        private System.Decimal _idclavedoc;
        private System.String _doc_sucursal;
        private System.String _opc_documento;
        private System.Int32 _tipoEmision;
        private System.Int32 _tipoPersona;
        private System.Int32 _tipoRegi;
        //
        private string ajustarAncho(string cadena, int ancho)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
            return (cadena + sb.ToString()).Substring(0, ancho).Trim();
        }
        //
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
        public System.String CL_nombreProveedor
        {
            get
            {
                return ajustarAncho(_CL_nombreProveedor, 150);
            }
            set
            {
                _CL_nombreProveedor = value;
            }
        }
        public System.String Cl_TipoComprobante
        {
            get
            {
                return ajustarAncho(_Cl_TipoComprobante, 50);
            }
            set
            {
                _Cl_TipoComprobante = value;
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
        public System.Int32 Cl_Mes
        {
            get
            {
                return _Cl_Mes;
            }
            set
            {
                _Cl_Mes = value;
            }
        }
        public System.Int32 Cl_Anio
        {
            get
            {
                return _Cl_Anio;
            }
            set
            {
                _Cl_Anio = value;
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
        public System.Decimal valRetServ50
        {
            get
            {
                return _valRetServ50;
            }
            set
            {
                _valRetServ50 = value;
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
        public System.Int32  tipoEmision
        {
            get
            {
                return _tipoEmision;
            }
            set
            {
                _tipoEmision = value;
            }
        }
        public System.Int32 tipoPersona
        {
            get
            {
                return _tipoPersona;
            }
            set
            {
                _tipoPersona = value;
            }
        }
        //
        public System.Int32 tipoRegi
        {
            get
            {
                return _tipoRegi;
            }
            set
            {
                _tipoRegi = value;
            }
        }
        private static string cadenaConexion = @"Data Source=patoopc; Initial Catalog=ivaret; user id=sa; password=123qweASDZXC";
        // La cadena de selección
        public static string CadenaSelect = "SELECT * FROM Compras";
        //
        public Compras()
        {
        }
        public Compras(string conex)
        {
            cadenaConexion = conex;
        }
        //
        // Métodos compartidos (estáticos) privados
        //
        // asigna una fila de la tabla a un objeto Compras
        private static Compras row2Compras(DataRow r)
        {
            // asigna a un objeto Compras los datos del dataRow indicado
            Compras oCompras = new Compras();
            //
            oCompras.CL_SusTributario = r["CL_SusTributario"].ToString();
            oCompras.CL_TipoIdProveedor = r["CL_TipoIdProveedor"].ToString();
            oCompras.CL_CodigoProveedor = r["CL_CodigoProveedor"].ToString();
            oCompras.CL_nombreProveedor = r["CL_nombreProveedor"].ToString();
            oCompras.Cl_TipoComprobante = r["Cl_TipoComprobante"].ToString();
            oCompras.CL_TipoProveedor = r["CL_TipoProveedor"].ToString();
            oCompras.CL_ParteRelacionada = r["CL_ParteRelacionada"].ToString();
            try
            {
                oCompras.CL_FechaRegContable = DateTime.Parse(r["CL_FechaRegContable"].ToString());
            }
            catch
            {
                // TODO: Usa el valor de fecha que quieras predeterminar
                //       Una fecha ficticia:
                //oCompras.CL_FechaRegContable = new DateTime(1900, 1, 1);
                //       o la fecha de hoy:
                oCompras.CL_FechaRegContable = DateTime.Now;
            }
            oCompras.CL_NroSerieEstablec = r["CL_NroSerieEstablec"].ToString();
            oCompras.CL_NroSeriePtoEmision = r["CL_NroSeriePtoEmision"].ToString();
            oCompras.CL_NroSecuencial = r["CL_NroSecuencial"].ToString();
            try
            {
                oCompras.CL_FechaComprobante = DateTime.Parse(r["CL_FechaComprobante"].ToString());
            }
            catch
            {
                // TODO: Usa el valor de fecha que quieras predeterminar
                //       Una fecha ficticia:
                //oCompras.CL_FechaComprobante = new DateTime(1900, 1, 1);
                //       o la fecha de hoy:
                oCompras.CL_FechaComprobante = DateTime.Now;
            }
            oCompras.CL_NroAutorizacion = r["CL_NroAutorizacion"].ToString();
            oCompras.CL_BaseNoGrabaIva = System.Decimal.Parse("0" + r["CL_BaseNoGrabaIva"].ToString());
            oCompras.CL_BaseImpTarCero = System.Decimal.Parse("0" + r["CL_BaseImpTarCero"].ToString());
            oCompras.CL_BaseImpGravadaIva = System.Decimal.Parse("0" + r["CL_BaseImpGravadaIva"].ToString());
            oCompras.CL_MontoICE = System.Decimal.Parse("0" + r["CL_MontoICE"].ToString());
            oCompras.CL_MontoIva = System.Decimal.Parse("0" + r["CL_MontoIva"].ToString());
            oCompras.CL_MontoRetIvaBienes = System.Decimal.Parse("0" + r["CL_MontoRetIvaBienes"].ToString());
            oCompras.CL_MontoRetIvaServicios = System.Decimal.Parse("0" + r["CL_MontoRetIvaServicios"].ToString());
            oCompras.CL_MontoRetIva100 = System.Decimal.Parse("0" + r["CL_MontoRetIva100"].ToString());
            oCompras.CL_pagoLocExt = System.Int32.Parse("0" + r["CL_pagoLocExt"].ToString());
            oCompras.CL_pagoPais = r["CL_pagoPais"].ToString();
            oCompras.CL_dobleTributacion = r["CL_dobleTributacion"].ToString();
            oCompras.CL_pagoSujetoRetencion = r["CL_pagoSujetoRetencion"].ToString();
            oCompras.CL_formaDePago = r["CL_formaDePago"].ToString();
            oCompras.CL_CodRetFteImpRenta0 = r["CL_CodRetFteImpRenta0"].ToString();
            oCompras.CL_BaseImponibleIR0 = System.Decimal.Parse("0" + r["CL_BaseImponibleIR0"].ToString());
            oCompras.CL_CodPorcRetIR0 = System.Decimal.Parse("0" + r["CL_CodPorcRetIR0"].ToString());
            oCompras.CL_MontoRetIR0 = System.Decimal.Parse("0" + r["CL_MontoRetIR0"].ToString());
            oCompras.CL_CodRetFteImpRenta1 = r["CL_CodRetFteImpRenta1"].ToString();
            oCompras.CL_BaseImponibleIR1 = System.Decimal.Parse("0" + r["CL_BaseImponibleIR1"].ToString());
            oCompras.CL_CodPorcRetIR1 = System.Decimal.Parse("0" + r["CL_CodPorcRetIR1"].ToString());
            oCompras.CL_MontoRetIR1 = System.Decimal.Parse("0" + r["CL_MontoRetIR1"].ToString());
            oCompras.CL_NroSerieCpbteRetEstable = r["CL_NroSerieCpbteRetEstable"].ToString();
            oCompras.CL_NroSerieCpbteRetEmision = r["CL_NroSerieCpbteRetEmision"].ToString();
            oCompras.CL_NroSecuencialCpbteRet = r["CL_NroSecuencialCpbteRet"].ToString();
            oCompras.CL_NroAutorizaCpbteRete = r["CL_NroAutorizaCpbteRete"].ToString();
            try
            {
                oCompras.CL_FechaEmisionCpbteRete = DateTime.Parse(r["CL_FechaEmisionCpbteRete"].ToString());
            }
            catch
            {
                // TODO: Usa el valor de fecha que quieras predeterminar
                //       Una fecha ficticia:
                //oCompras.CL_FechaEmisionCpbteRete = new DateTime(1900, 1, 1);
                //       o la fecha de hoy:
                oCompras.CL_FechaEmisionCpbteRete = DateTime.Now;
            }
            oCompras.Clave = System.Decimal.Parse("0" + r["Clave"].ToString());
            oCompras.Cl_Mes = System.Int32.Parse("0" + r["Cl_Mes"].ToString());
            oCompras.Cl_Anio = System.Int32.Parse("0" + r["Cl_Anio"].ToString());
            oCompras.baseImpExe = System.Decimal.Parse("0" + r["baseImpExe"].ToString());
            oCompras.valRetBien10 = System.Decimal.Parse("0" + r["valRetBien10"].ToString());
            oCompras.pagoRegFis = r["pagoRegFis"].ToString();
            try
            {
                oCompras.fechaPagoDiv = DateTime.Parse(r["fechaPagoDiv"].ToString());
            }
            catch
            {
                // TODO: Usa el valor de fecha que quieras predeterminar
                //       Una fecha ficticia:
                //oCompras.fechaPagoDiv = new DateTime(1900, 1, 1);
                //       o la fecha de hoy:
                oCompras.fechaPagoDiv = DateTime.Now;
            }
            oCompras.imRentaSoc = System.Decimal.Parse("0" + r["imRentaSoc"].ToString());
            oCompras.anioUtDiv = System.Int32.Parse("0" + r["anioUtDiv"].ToString());
            oCompras.NumCajBan = System.Decimal.Parse("0" + r["NumCajBan"].ToString());
            oCompras.PrecCajBan = System.Decimal.Parse("0" + r["PrecCajBan"].ToString());
            oCompras.imRentaSoc1 = System.Decimal.Parse("0" + r["imRentaSoc1"].ToString());
            oCompras.anioUtDiv1 = System.Int32.Parse("0" + r["anioUtDiv1"].ToString());
            oCompras.NumCajBan1 = System.Decimal.Parse("0" + r["NumCajBan1"].ToString());
            oCompras.PrecCajBan1 = System.Decimal.Parse("0" + r["PrecCajBan1"].ToString());
            oCompras.CL_CodRetFteImpRenta2 = System.Decimal.Parse("0" + r["CL_CodRetFteImpRenta2"].ToString());
            oCompras.CL_BaseImponibleIR2 = System.Decimal.Parse("0" + r["CL_BaseImponibleIR2"].ToString());
            oCompras.CL_CodPorcRetIR2 = System.Decimal.Parse("0" + r["CL_CodPorcRetIR2"].ToString());
            try
            {
                oCompras.fechaPagoDiv2 = DateTime.Parse(r["fechaPagoDiv2"].ToString());
            }
            catch
            {
                // TODO: Usa el valor de fecha que quieras predeterminar
                //       Una fecha ficticia:
                //oCompras.fechaPagoDiv2 = new DateTime(1900, 1, 1);
                //       o la fecha de hoy:
                oCompras.fechaPagoDiv2 = DateTime.Now;
            }
            oCompras.imRentaSoc2 = System.Decimal.Parse("0" + r["imRentaSoc2"].ToString());
            oCompras.anioUtDiv2 = System.Int32.Parse("0" + r["anioUtDiv2"].ToString());
            oCompras.NumCajBan2 = System.Decimal.Parse("0" + r["NumCajBan2"].ToString());
            oCompras.PrecCajBan2 = System.Decimal.Parse("0" + r["PrecCajBan2"].ToString());
            oCompras.CL_CodRetFteImpRenta3 = System.Decimal.Parse("0" + r["CL_CodRetFteImpRenta3"].ToString());
            oCompras.CL_BaseImponibleIR3 = System.Decimal.Parse("0" + r["CL_BaseImponibleIR3"].ToString());
            oCompras.CL_CodPorcRetIR3 = System.Decimal.Parse("0" + r["CL_CodPorcRetIR3"].ToString());
            try
            {
                oCompras.fechaPagoDiv3 = DateTime.Parse(r["fechaPagoDiv3"].ToString());
            }
            catch
            {
                // TODO: Usa el valor de fecha que quieras predeterminar
                //       Una fecha ficticia:
                //oCompras.fechaPagoDiv3 = new DateTime(1900, 1, 1);
                //       o la fecha de hoy:
                oCompras.fechaPagoDiv3 = DateTime.Now;
            }
            oCompras.imRentaSoc3 = System.Decimal.Parse("0" + r["imRentaSoc3"].ToString());
            oCompras.anioUtDiv3 = System.Int32.Parse("0" + r["anioUtDiv3"].ToString());
            oCompras.NumCajBan3 = System.Decimal.Parse("0" + r["NumCajBan3"].ToString());
            oCompras.PrecCajBan3 = System.Decimal.Parse("0" + r["PrecCajBan3"].ToString());
            oCompras.valRetBien20 = System.Decimal.Parse("0" + r["valRetBien20"].ToString());
            try
            {
                oCompras.fechaPagoDiv1 = DateTime.Parse(r["fechaPagoDiv1"].ToString());
            }
            catch
            {
                // TODO: Usa el valor de fecha que quieras predeterminar
                //       Una fecha ficticia:
                //oCompras.fechaPagoDiv1 = new DateTime(1900, 1, 1);
                //       o la fecha de hoy:
                oCompras.fechaPagoDiv1 = DateTime.Now;
            }
            oCompras.valRetServ20 = System.Decimal.Parse("0" + r["valRetServ20"].ToString());
            oCompras.valRetServ20 = System.Decimal.Parse("0" + r["valRetServ50"].ToString());
            oCompras.codRetAir2 = System.Decimal.Parse("0" + r["codRetAir2"].ToString());
            oCompras.baseImpAir2 = System.Decimal.Parse("0" + r["baseImpAir2"].ToString());
            oCompras.porcentajeAir2 = System.Decimal.Parse("0" + r["porcentajeAir2"].ToString());
            oCompras.valRetAir2 = System.Decimal.Parse("0" + r["valRetAir2"].ToString());
            oCompras.codRetAir3 = System.Decimal.Parse("0" + r["codRetAir3"].ToString());
            oCompras.baseImpAir3 = System.Decimal.Parse("0" + r["baseImpAir3"].ToString());
            oCompras.porcentajeAir3 = System.Decimal.Parse("0" + r["porcentajeAir3"].ToString());
            oCompras.valRetAir3 = System.Decimal.Parse("0" + r["valRetAir3"].ToString());
            oCompras.totbasesImpReemb = System.Decimal.Parse("0" + r["totbasesImpReemb"].ToString());
            oCompras.idclavedoc = System.Decimal.Parse("0" + r["idclavedoc"].ToString());
            oCompras.doc_sucursal = r["doc_sucursal"].ToString();
            oCompras.opc_documento = r["opc_documento"].ToString();
            oCompras.tipoEmision = System.Int32.Parse("0" + r["tipoEmision"].ToString());
            oCompras.tipoPersona = System.Int32.Parse("0" + r["tipoPersona"].ToString());
            oCompras.tipoRegi = System.Int32.Parse("0" + r["tipoRegi"].ToString());
            //
            return oCompras;
        }
        //
        // asigna un objeto Compras a la fila indicada
        private static void Compras2Row(Compras oCompras, DataRow r)
        {
            // asigna un objeto Compras al dataRow indicado
            r["CL_SusTributario"] = oCompras.CL_SusTributario;
            r["CL_TipoIdProveedor"] = oCompras.CL_TipoIdProveedor;
            r["CL_CodigoProveedor"] = oCompras.CL_CodigoProveedor;
            r["CL_nombrProveedor"] = oCompras.CL_nombreProveedor;
            r["Cl_TipoComprobante"] = oCompras.Cl_TipoComprobante;
            r["CL_TipoProveedor"] = oCompras.CL_TipoProveedor;
            r["CL_ParteRelacionada"] = oCompras.CL_ParteRelacionada;
            r["CL_FechaRegContable"] = oCompras.CL_FechaRegContable;
            r["CL_NroSerieEstablec"] = oCompras.CL_NroSerieEstablec;
            r["CL_NroSeriePtoEmision"] = oCompras.CL_NroSeriePtoEmision;
            r["CL_NroSecuencial"] = oCompras.CL_NroSecuencial;
            r["CL_FechaComprobante"] = oCompras.CL_FechaComprobante;
            r["CL_NroAutorizacion"] = oCompras.CL_NroAutorizacion;
            r["CL_BaseNoGrabaIva"] = oCompras.CL_BaseNoGrabaIva;
            r["CL_BaseImpTarCero"] = oCompras.CL_BaseImpTarCero;
            r["CL_BaseImpGravadaIva"] = oCompras.CL_BaseImpGravadaIva;
            r["CL_MontoICE"] = oCompras.CL_MontoICE;
            r["CL_MontoIva"] = oCompras.CL_MontoIva;
            r["CL_MontoRetIvaBienes"] = oCompras.CL_MontoRetIvaBienes;
            r["CL_MontoRetIvaServicios"] = oCompras.CL_MontoRetIvaServicios;
            r["CL_MontoRetIva100"] = oCompras.CL_MontoRetIva100;
            r["CL_pagoLocExt"] = oCompras.CL_pagoLocExt;
            r["CL_pagoPais"] = oCompras.CL_pagoPais;
            r["CL_dobleTributacion"] = oCompras.CL_dobleTributacion;
            r["CL_pagoSujetoRetencion"] = oCompras.CL_pagoSujetoRetencion;
            r["CL_formaDePago"] = oCompras.CL_formaDePago;
            r["CL_CodRetFteImpRenta0"] = oCompras.CL_CodRetFteImpRenta0;
            r["CL_BaseImponibleIR0"] = oCompras.CL_BaseImponibleIR0;
            r["CL_CodPorcRetIR0"] = oCompras.CL_CodPorcRetIR0;
            r["CL_MontoRetIR0"] = oCompras.CL_MontoRetIR0;
            r["CL_CodRetFteImpRenta1"] = oCompras.CL_CodRetFteImpRenta1;
            r["CL_BaseImponibleIR1"] = oCompras.CL_BaseImponibleIR1;
            r["CL_CodPorcRetIR1"] = oCompras.CL_CodPorcRetIR1;
            r["CL_MontoRetIR1"] = oCompras.CL_MontoRetIR1;
            r["CL_NroSerieCpbteRetEstable"] = oCompras.CL_NroSerieCpbteRetEstable;
            r["CL_NroSerieCpbteRetEmision"] = oCompras.CL_NroSerieCpbteRetEmision;
            r["CL_NroSecuencialCpbteRet"] = oCompras.CL_NroSecuencialCpbteRet;
            r["CL_NroAutorizaCpbteRete"] = oCompras.CL_NroAutorizaCpbteRete;
            r["CL_FechaEmisionCpbteRete"] = oCompras.CL_FechaEmisionCpbteRete;
            // TODO: Comprueba si esta asignación debe hacerse
            //       pero mejor lo dejas comentado ya que es un campo autoincremental o único
            //r["Clave"] = oCompras.Clave;
            r["Cl_Mes"] = oCompras.Cl_Mes;
            r["Cl_Anio"] = oCompras.Cl_Anio;
            r["baseImpExe"] = oCompras.baseImpExe;
            r["valRetBien10"] = oCompras.valRetBien10;
            r["pagoRegFis"] = oCompras.pagoRegFis;
            r["fechaPagoDiv"] = oCompras.fechaPagoDiv;
            r["imRentaSoc"] = oCompras.imRentaSoc;
            r["anioUtDiv"] = oCompras.anioUtDiv;
            r["NumCajBan"] = oCompras.NumCajBan;
            r["PrecCajBan"] = oCompras.PrecCajBan;
            r["imRentaSoc1"] = oCompras.imRentaSoc1;
            r["anioUtDiv1"] = oCompras.anioUtDiv1;
            r["NumCajBan1"] = oCompras.NumCajBan1;
            r["PrecCajBan1"] = oCompras.PrecCajBan1;
            r["CL_CodRetFteImpRenta2"] = oCompras.CL_CodRetFteImpRenta2;
            r["CL_BaseImponibleIR2"] = oCompras.CL_BaseImponibleIR2;
            r["CL_CodPorcRetIR2"] = oCompras.CL_CodPorcRetIR2;
            r["fechaPagoDiv2"] = oCompras.fechaPagoDiv2;
            r["imRentaSoc2"] = oCompras.imRentaSoc2;
            r["anioUtDiv2"] = oCompras.anioUtDiv2;
            r["NumCajBan2"] = oCompras.NumCajBan2;
            r["PrecCajBan2"] = oCompras.PrecCajBan2;
            r["CL_CodRetFteImpRenta3"] = oCompras.CL_CodRetFteImpRenta3;
            r["CL_BaseImponibleIR3"] = oCompras.CL_BaseImponibleIR3;
            r["CL_CodPorcRetIR3"] = oCompras.CL_CodPorcRetIR3;
            r["fechaPagoDiv3"] = oCompras.fechaPagoDiv3;
            r["imRentaSoc3"] = oCompras.imRentaSoc3;
            r["anioUtDiv3"] = oCompras.anioUtDiv3;
            r["NumCajBan3"] = oCompras.NumCajBan3;
            r["PrecCajBan3"] = oCompras.PrecCajBan3;
            r["valRetBien20"] = oCompras.valRetBien20;
            r["fechaPagoDiv1"] = oCompras.fechaPagoDiv1;
            r["valRetServ20"] = oCompras.valRetServ20;
            r["valRetServ50"] = oCompras.valRetServ20;
            r["codRetAir2"] = oCompras.codRetAir2;
            r["baseImpAir2"] = oCompras.baseImpAir2;
            r["porcentajeAir2"] = oCompras.porcentajeAir2;
            r["valRetAir2"] = oCompras.valRetAir2;
            r["codRetAir3"] = oCompras.codRetAir3;
            r["baseImpAir3"] = oCompras.baseImpAir3;
            r["porcentajeAir3"] = oCompras.porcentajeAir3;
            r["valRetAir3"] = oCompras.valRetAir3;
            r["totbasesImpReemb"] = oCompras.totbasesImpReemb;
            r["idclavedoc"] = oCompras.idclavedoc;
            r["doc_sucursal"] = oCompras.doc_sucursal;
            r["opc_documento"] = oCompras.opc_documento;
            r["tipoEmision"] = oCompras.tipoEmision;
            r["tipoPersona"] = oCompras.tipoPersona;
            r["tipoRegi"] = oCompras.tipoPersona;
        }
        //
        // crea una nueva fila y la asigna a un objeto Compras
        private static void nuevoCompras(DataTable dt, Compras oCompras)
        {
            // Crear un nuevo Compras
            DataRow dr = dt.NewRow();
            Compras oC = row2Compras(dr);
            //
            oC.CL_SusTributario = oCompras.CL_SusTributario;
            oC.CL_TipoIdProveedor = oCompras.CL_TipoIdProveedor;
            oC.CL_CodigoProveedor = oCompras.CL_CodigoProveedor;
            oC.CL_nombreProveedor = oCompras.CL_nombreProveedor;
            oC.Cl_TipoComprobante = oCompras.Cl_TipoComprobante;
            oC.CL_TipoProveedor = oCompras.CL_TipoProveedor;
            oC.CL_ParteRelacionada = oCompras.CL_ParteRelacionada;
            oC.CL_FechaRegContable = oCompras.CL_FechaRegContable;
            oC.CL_NroSerieEstablec = oCompras.CL_NroSerieEstablec;
            oC.CL_NroSeriePtoEmision = oCompras.CL_NroSeriePtoEmision;
            oC.CL_NroSecuencial = oCompras.CL_NroSecuencial;
            oC.CL_FechaComprobante = oCompras.CL_FechaComprobante;
            oC.CL_NroAutorizacion = oCompras.CL_NroAutorizacion;
            oC.CL_BaseNoGrabaIva = oCompras.CL_BaseNoGrabaIva;
            oC.CL_BaseImpTarCero = oCompras.CL_BaseImpTarCero;
            oC.CL_BaseImpGravadaIva = oCompras.CL_BaseImpGravadaIva;
            oC.CL_MontoICE = oCompras.CL_MontoICE;
            oC.CL_MontoIva = oCompras.CL_MontoIva;
            oC.CL_MontoRetIvaBienes = oCompras.CL_MontoRetIvaBienes;
            oC.CL_MontoRetIvaServicios = oCompras.CL_MontoRetIvaServicios;
            oC.CL_MontoRetIva100 = oCompras.CL_MontoRetIva100;
            oC.CL_pagoLocExt = oCompras.CL_pagoLocExt;
            oC.CL_pagoPais = oCompras.CL_pagoPais;
            oC.CL_dobleTributacion = oCompras.CL_dobleTributacion;
            oC.CL_pagoSujetoRetencion = oCompras.CL_pagoSujetoRetencion;
            oC.CL_formaDePago = oCompras.CL_formaDePago;
            oC.CL_CodRetFteImpRenta0 = oCompras.CL_CodRetFteImpRenta0;
            oC.CL_BaseImponibleIR0 = oCompras.CL_BaseImponibleIR0;
            oC.CL_CodPorcRetIR0 = oCompras.CL_CodPorcRetIR0;
            oC.CL_MontoRetIR0 = oCompras.CL_MontoRetIR0;
            oC.CL_CodRetFteImpRenta1 = oCompras.CL_CodRetFteImpRenta1;
            oC.CL_BaseImponibleIR1 = oCompras.CL_BaseImponibleIR1;
            oC.CL_CodPorcRetIR1 = oCompras.CL_CodPorcRetIR1;
            oC.CL_MontoRetIR1 = oCompras.CL_MontoRetIR1;
            oC.CL_NroSerieCpbteRetEstable = oCompras.CL_NroSerieCpbteRetEstable;
            oC.CL_NroSerieCpbteRetEmision = oCompras.CL_NroSerieCpbteRetEmision;
            oC.CL_NroSecuencialCpbteRet = oCompras.CL_NroSecuencialCpbteRet;
            oC.CL_NroAutorizaCpbteRete = oCompras.CL_NroAutorizaCpbteRete;
            oC.CL_FechaEmisionCpbteRete = oCompras.CL_FechaEmisionCpbteRete;
            oC.Clave = oCompras.Clave;
            oC.Cl_Mes = oCompras.Cl_Mes;
            oC.Cl_Anio = oCompras.Cl_Anio;
            oC.baseImpExe = oCompras.baseImpExe;
            oC.valRetBien10 = oCompras.valRetBien10;
            oC.pagoRegFis = oCompras.pagoRegFis;
            oC.fechaPagoDiv = oCompras.fechaPagoDiv;
            oC.imRentaSoc = oCompras.imRentaSoc;
            oC.anioUtDiv = oCompras.anioUtDiv;
            oC.NumCajBan = oCompras.NumCajBan;
            oC.PrecCajBan = oCompras.PrecCajBan;
            oC.imRentaSoc1 = oCompras.imRentaSoc1;
            oC.anioUtDiv1 = oCompras.anioUtDiv1;
            oC.NumCajBan1 = oCompras.NumCajBan1;
            oC.PrecCajBan1 = oCompras.PrecCajBan1;
            oC.CL_CodRetFteImpRenta2 = oCompras.CL_CodRetFteImpRenta2;
            oC.CL_BaseImponibleIR2 = oCompras.CL_BaseImponibleIR2;
            oC.CL_CodPorcRetIR2 = oCompras.CL_CodPorcRetIR2;
            oC.fechaPagoDiv2 = oCompras.fechaPagoDiv2;
            oC.imRentaSoc2 = oCompras.imRentaSoc2;
            oC.anioUtDiv2 = oCompras.anioUtDiv2;
            oC.NumCajBan2 = oCompras.NumCajBan2;
            oC.PrecCajBan2 = oCompras.PrecCajBan2;
            oC.CL_CodRetFteImpRenta3 = oCompras.CL_CodRetFteImpRenta3;
            oC.CL_BaseImponibleIR3 = oCompras.CL_BaseImponibleIR3;
            oC.CL_CodPorcRetIR3 = oCompras.CL_CodPorcRetIR3;
            oC.fechaPagoDiv3 = oCompras.fechaPagoDiv3;
            oC.imRentaSoc3 = oCompras.imRentaSoc3;
            oC.anioUtDiv3 = oCompras.anioUtDiv3;
            oC.NumCajBan3 = oCompras.NumCajBan3;
            oC.PrecCajBan3 = oCompras.PrecCajBan3;
            oC.valRetBien20 = oCompras.valRetBien20;
            oC.fechaPagoDiv1 = oCompras.fechaPagoDiv1;
            oC.valRetServ20 = oCompras.valRetServ20;
            oC.valRetServ50 = oCompras.valRetServ50;
            oC.codRetAir2 = oCompras.codRetAir2;
            oC.baseImpAir2 = oCompras.baseImpAir2;
            oC.porcentajeAir2 = oCompras.porcentajeAir2;
            oC.valRetAir2 = oCompras.valRetAir2;
            oC.codRetAir3 = oCompras.codRetAir3;
            oC.baseImpAir3 = oCompras.baseImpAir3;
            oC.porcentajeAir3 = oCompras.porcentajeAir3;
            oC.valRetAir3 = oCompras.valRetAir3;
            oC.totbasesImpReemb = oCompras.totbasesImpReemb;
            oC.idclavedoc = oCompras.idclavedoc;
            oC.doc_sucursal = oCompras.doc_sucursal;
            oC.opc_documento = oCompras.opc_documento;
            oC.tipoPersona = oCompras.tipoPersona ;
            oC.tipoEmision = oCompras.tipoEmision;
            oC.tipoRegi = oCompras.tipoRegi;
            //
            Compras2Row(oC, dr);
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
            // devuelve una tabla con los datos de la tabla Compras
            SqlDataAdapter da;
            DataTable dt = new DataTable("Compras");
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
        public static Compras Buscar(string sWhere)
        {
            // Busca en la tabla los datos indicados en el parámetro
            // el parámetro contendrá lo que se usará después del WHERE
            Compras oCompras = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("Compras");
            string sel = "SELECT * FROM Compras WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oCompras = row2Compras(dt.Rows[0]);
            }
            return oCompras;
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
            string sel = "SELECT * FROM Compras WHERE Clave = " + this.Clave.ToString();
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
            DataTable dt = new DataTable("Compras");
            //
            cnn = new SqlConnection(cadenaConexion);
            //da = new SqlDataAdapter(CadenaSelect, cnn);
            da = new SqlDataAdapter(sel, cnn);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.UpdateCommand = cb.GetUpdateCommand();
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
                Compras2Row(this, dt.Rows[0]);
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
            DataTable dt = new DataTable("Compras");
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
            //sCommand = "INSERT INTO Compras (CL_SusTributario, CL_TipoIdProveedor, CL_CodigoProveedor, Cl_TipoComprobante, CL_TipoProveedor, CL_ParteRelacionada, CL_FechaRegContable, CL_NroSerieEstablec, CL_NroSeriePtoEmision, CL_NroSecuencial, CL_FechaComprobante, CL_NroAutorizacion, CL_BaseNoGrabaIva, CL_BaseImpTarCero, CL_BaseImpGravadaIva, CL_MontoICE, CL_MontoIva, CL_MontoRetIvaBienes, CL_MontoRetIvaServicios, CL_MontoRetIva100, CL_pagoLocExt, CL_pagoPais, CL_dobleTributacion, CL_pagoSujetoRetencion, CL_formaDePago, CL_CodRetFteImpRenta0, CL_BaseImponibleIR0, CL_CodPorcRetIR0, CL_MontoRetIR0, CL_CodRetFteImpRenta1, CL_BaseImponibleIR1, CL_CodPorcRetIR1, CL_MontoRetIR1, CL_NroSerieCpbteRetEstable, CL_NroSerieCpbteRetEmision, CL_NroSecuencialCpbteRet, CL_NroAutorizaCpbteRete, CL_FechaEmisionCpbteRete, Cl_Mes, Cl_Anio, baseImpExe, valRetBien10, pagoRegFis, fechaPagoDiv, imRentaSoc, anioUtDiv, NumCajBan, PrecCajBan, imRentaSoc1, anioUtDiv1, NumCajBan1, PrecCajBan1, CL_CodRetFteImpRenta2, CL_BaseImponibleIR2, CL_CodPorcRetIR2, fechaPagoDiv2, imRentaSoc2, anioUtDiv2, NumCajBan2, PrecCajBan2, CL_CodRetFteImpRenta3, CL_BaseImponibleIR3, CL_CodPorcRetIR3, fechaPagoDiv3, imRentaSoc3, anioUtDiv3, NumCajBan3, PrecCajBan3, valRetBien20, fechaPagoDiv1, valRetServ20, codRetAir2, baseImpAir2, porcentajeAir2, valRetAir2, codRetAir3, baseImpAir3, porcentajeAir3, valRetAir3, totbasesImpReemb, idclavedoc, doc_sucursal, opc_documento)  VALUES(@CL_SusTributario, @CL_TipoIdProveedor, @CL_CodigoProveedor, @Cl_TipoComprobante, @CL_TipoProveedor, @CL_ParteRelacionada, @CL_FechaRegContable, @CL_NroSerieEstablec, @CL_NroSeriePtoEmision, @CL_NroSecuencial, @CL_FechaComprobante, @CL_NroAutorizacion, @CL_BaseNoGrabaIva, @CL_BaseImpTarCero, @CL_BaseImpGravadaIva, @CL_MontoICE, @CL_MontoIva, @CL_MontoRetIvaBienes, @CL_MontoRetIvaServicios, @CL_MontoRetIva100, @CL_pagoLocExt, @CL_pagoPais, @CL_dobleTributacion, @CL_pagoSujetoRetencion, @CL_formaDePago, @CL_CodRetFteImpRenta0, @CL_BaseImponibleIR0, @CL_CodPorcRetIR0, @CL_MontoRetIR0, @CL_CodRetFteImpRenta1, @CL_BaseImponibleIR1, @CL_CodPorcRetIR1, @CL_MontoRetIR1, @CL_NroSerieCpbteRetEstable, @CL_NroSerieCpbteRetEmision, @CL_NroSecuencialCpbteRet, @CL_NroAutorizaCpbteRete, @CL_FechaEmisionCpbteRete, @Cl_Mes, @Cl_Anio, @baseImpExe, @valRetBien10, @pagoRegFis, @fechaPagoDiv, @imRentaSoc, @anioUtDiv, @NumCajBan, @PrecCajBan, @imRentaSoc1, @anioUtDiv1, @NumCajBan1, @PrecCajBan1, @CL_CodRetFteImpRenta2, @CL_BaseImponibleIR2, @CL_CodPorcRetIR2, @fechaPagoDiv2, @imRentaSoc2, @anioUtDiv2, @NumCajBan2, @PrecCajBan2, @CL_CodRetFteImpRenta3, @CL_BaseImponibleIR3, @CL_CodPorcRetIR3, @fechaPagoDiv3, @imRentaSoc3, @anioUtDiv3, @NumCajBan3, @PrecCajBan3, @valRetBien20, @fechaPagoDiv1, @valRetServ20, @codRetAir2, @baseImpAir2, @porcentajeAir2, @valRetAir2, @codRetAir3, @baseImpAir3, @porcentajeAir3, @valRetAir3, @totbasesImpReemb, @idclavedoc, @doc_sucursal, @opc_documento)";
            //da.InsertCommand = new SqlCommand(sCommand, cnn);
            //da.InsertCommand.Parameters.Add("@CL_SusTributario", SqlDbType.NVarChar, 50, "CL_SusTributario");
            //da.InsertCommand.Parameters.Add("@CL_TipoIdProveedor", SqlDbType.NVarChar, 50, "CL_TipoIdProveedor");
            //da.InsertCommand.Parameters.Add("@CL_CodigoProveedor", SqlDbType.NVarChar, 50, "CL_CodigoProveedor");
            //da.InsertCommand.Parameters.Add("@Cl_TipoComprobante", SqlDbType.NVarChar, 50, "Cl_TipoComprobante");
            //da.InsertCommand.Parameters.Add("@CL_TipoProveedor", SqlDbType.NVarChar, 3, "CL_TipoProveedor");
            //da.InsertCommand.Parameters.Add("@CL_ParteRelacionada", SqlDbType.NVarChar, 3, "CL_ParteRelacionada");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_FechaRegContable", SqlDbType.DateTime, 0, "CL_FechaRegContable");
            //da.InsertCommand.Parameters.Add("@CL_NroSerieEstablec", SqlDbType.NVarChar, 50, "CL_NroSerieEstablec");
            //da.InsertCommand.Parameters.Add("@CL_NroSeriePtoEmision", SqlDbType.NVarChar, 50, "CL_NroSeriePtoEmision");
            //da.InsertCommand.Parameters.Add("@CL_NroSecuencial", SqlDbType.NVarChar, 20, "CL_NroSecuencial");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_FechaComprobante", SqlDbType.DateTime, 0, "CL_FechaComprobante");
            //da.InsertCommand.Parameters.Add("@CL_NroAutorizacion", SqlDbType.NVarChar, 50, "CL_NroAutorizacion");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_BaseNoGrabaIva", SqlDbType.Decimal, 0, "CL_BaseNoGrabaIva");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_BaseImpTarCero", SqlDbType.Decimal, 0, "CL_BaseImpTarCero");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_BaseImpGravadaIva", SqlDbType.Decimal, 0, "CL_BaseImpGravadaIva");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_MontoICE", SqlDbType.Decimal, 0, "CL_MontoICE");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@CL_MontoIva", SqlDbType.Decimal, 0, "CL_MontoIva");
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
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@Clave", SqlDbType.Decimal, 0, "Clave");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@Cl_Mes", SqlDbType.Int, 0, "Cl_Mes");
            //// TODO: Comprobar el tipo de datos a usar...
            //da.InsertCommand.Parameters.Add("@Cl_Anio", SqlDbType.Int, 0, "Cl_Anio");
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
            nuevoCompras(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo Compras";
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
            string sel = "SELECT * FROM Compras WHERE Clave = " + this.Clave.ToString();
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            // Borrar el registro al que apunta esta clase
            // En caso de error, devolverá la cadena de error empezando por ERROR:.
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("Compras");
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
            //sCommand = "DELETE FROM Compras WHERE (Clave = @p1)";
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
