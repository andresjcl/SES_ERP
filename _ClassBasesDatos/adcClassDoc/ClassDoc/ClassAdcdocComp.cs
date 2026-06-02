using System;
using System.Data;
using System.Data.SqlClient;

namespace ClassDoc
{
	public class AdcDocComp
        {
            private System.String _Doc_sucursal = "";
            private System.String _Doc_Bodega = "";
            private System.String _Opc_documento = "";
            private System.Decimal _Doc_numero = 0;
            private System.String _Doc_docnombre;
            private System.String _Doc_TipoDoc = "";
            private System.String _Doc_DocSop = "";
            private System.Decimal _Doc_NumSop = 0;
            private System.DateTime _Doc_fecha = new DateTime(1900, 1, 1, 0, 0, 0);
            private System.DateTime _Doc_Hora = new DateTime(1900, 1, 1, 0, 0, 0);
            private System.String _Doc_extension = "";
            private System.String _Doc_codper = "";
            private System.String _Doc_codusu = "";
            private System.String _Doc_venabre = "";
            private System.Decimal _Doc_porceniva = 0;
            private System.Decimal _Doc_valoriva = 0;
            private System.Decimal _Doc_totciva = 0;
            private System.Decimal _Doc_totsiva = 0;
            private System.String _Doc_nombredes1 = "";
            private System.String _Doc_nombredes2 = "";
            private System.String _Doc_nombredes3 = "";
            private System.String _Doc_nombredes4 = "";
            private System.Decimal _Doc_porcendes1 = 0;
            private System.Decimal _Doc_porcendes2 = 0;
            private System.Decimal _Doc_porcendes3 = 0;
            private System.Decimal _Doc_porcendes4 = 0;
            private System.Decimal _Doc_valordes1 = 0;
            private System.Decimal _Doc_valordes2 = 0;
            private System.Decimal _Doc_valordes3 = 0;
            private System.Decimal _Doc_valordes4 = 0;
            private System.Decimal _Doc_valor = 0;
            private System.Decimal _Doc_valorabon = 0;
            private System.String _Doc_detalle = "";
            private System.String _Doc_NombreImp = "";
            private System.String _Doc_CiRuc = "";
            private System.String _Doc_Direccion = "";
            private System.String _Doc_Telefono1 = "";
            private System.String _Doc_Telefono2 = "";
            private System.String _Doc_DepDes = "";
            private System.Decimal _Doc_TotDesArt = 0;
            private System.Decimal _Doc_TotDesSer = 0;
            private System.Decimal _Doc_TotArtCIva = 0;
            private System.Decimal _Doc_TotArtSIva = 0;
            private System.Decimal _Doc_TotSerCIva = 0;
            private System.Decimal _Doc_TotSerSIva = 0;
            private System.Decimal _Doc_TotAcf = 0;
            private System.Decimal _Doc_Contado = 0;
            private System.DateTime _Doc_FechaEfe = new DateTime(1900, 1, 1, 0, 0, 0);
            private System.Int32 _Doc_Estado = 0;
            private System.Int32 _Doc_Oculto = 0;
            private System.Decimal _Doc_Contabilidad = 0;
            private System.Decimal _Doc_Banco = 0;
            private System.Int16 _Doc_Inventario = 0;
            private System.Int16 _Doc_Ventas = 0;
            private System.Int16 _Doc_Compras = 0;
            private System.Int16 _Doc_Activo = 0;
            private System.Decimal _Doc_Adicional1 = 0;
            private System.Decimal _Doc_Adicional2 = 0;
            private System.Decimal _Doc_NumeroExterno = 0;
            private System.String _Doc_NroIdDoc = "";
            private System.Decimal _Doc_SaldoActualCli = 0;
            private System.Decimal _Doc_SaldoFinalCli = 0;
            private System.DateTime _Doc_FechaModifica = new DateTime(1900, 1, 1, 0, 0, 0);
            private System.String _Doc_CentroCosto = "";
            private System.Decimal _IdClaveDoc = 0;
            private System.Decimal _IdClaveDocSop = 0;
            private System.String _doc_SucursalDestino = "";
            private System.String _doc_SucDestino = "";
            private System.String _doc_BodDestino = "";
            private System.String _Doc_NroLoteDoc = "";
            private System.String _doc_BancoOrigen = "";
            private System.String _doc_BancoDestino = "";
            private System.String _doc_NumeroCheque = "";
            private System.Boolean _doc_Aceptado = false;
            private System.Boolean _Doc_Liquidado = false;
            private System.String _Doc_CobraCheque = "";
            private System.Decimal _doc_TotDesCIva = 0;
            private System.Decimal _doc_TotDesSiva = 0;
            private System.DateTime _Periodo1 = new DateTime(1900, 1, 1, 0, 0, 0);
            private System.DateTime _Periodo2 = new DateTime(1900, 1, 1, 0, 0, 0);
            private System.DateTime _FacDesde = new DateTime(1900, 1, 1, 0, 0, 0);
            private System.DateTime _FacHasta = new DateTime(1900, 1, 1, 0, 0, 0);
            private System.String _Habitacion = "";
            private System.String _Mesa = "";
            private System.String _TipoPeriodo = "";
            private System.String _Adi_NroAutSri = "";
            private System.String _Adi_SustTrib = "";
            private System.String _Adi_TipoDocSri = "";
            private System.String _Adi_SNDevIva = "";
            private System.DateTime _Adi_FechContab = new DateTime(1900, 1, 1, 0, 0, 0);
            private System.String _Adi_CodigoNSR = "";
            private System.String _Dia_Status = "";
            private System.String _Moneda = "";
            private System.Decimal _Paridad = 0;
            private System.Decimal _ParidadBiMoneda = 0;
            private System.String _PaisDestino = "";
            private System.String _ProvinciaDestino = "";
            private System.String _CiudadDestino = "";
            private System.String _DireccionDestino = "";
            private System.String _Destinatario = "";
            private System.String _RucDestinatario = "";
            private System.String _ContactoDestino = "";
            private System.DateTime _FecIniTransporte = new DateTime(1900, 1, 1, 0, 0, 0);
            private System.DateTime _FecFinTransporte = new DateTime(1900, 1, 1, 0, 0, 0);
            private System.String _Transportista = "";
            private System.String _RucTransportista = "";
            private System.String _TipoTransporte = "";
            private System.String _EsContable = "";
            private System.String _AuxVar1 = "";
            private System.String _AuxVar2 = "";
            private System.String _AuxVar3 = "";
            private System.String _AuxVar4 = "";
            private System.String _AuxVar5 = "";
            private System.String _AuxVar6 = "";
            private System.String _AuxVar7 = "";
            private System.String _AuxVar8 = "";
            private System.String _AuxVar9 = "";
            private System.String _AuxVar10 = "";
            private System.String _AuxVar11 = "";
            private System.String _AuxVar12 = "";
            private System.DateTime _AuxFec1 = new DateTime(1900, 1, 1, 0, 0, 0);
            private System.DateTime _AuxFec2 = new DateTime(1900, 1, 1, 0, 0, 0);
            private System.DateTime _AuxFec3 = new DateTime(1900, 1, 1, 0, 0, 0);
            private System.String _AuxLog1 = "";
            private System.String _AuxLog2 = "";
            private System.String _AuxLog3 = "";
            private System.Decimal _AuxNum1 = 0;
            private System.Decimal _AuxNum2 = 0;
            private System.Decimal _AuxNum3 = 0;
            private System.Decimal _AuxNum4 = 0;
            private System.Decimal _AuxNum5 = 0;
            private System.Decimal _AuxNum6 = 0;
            private System.Decimal _AuxNum7 = 0;
            private System.Decimal _AuxNum8 = 0;
            private System.Decimal _AuxNum9 = 0;
            private System.Decimal _AuxNum10 = 0;
            private System.Decimal _AuxNum11 = 0;
            private System.Decimal _AuxNum12 = 0;
            private System.Boolean _doc_Anticipo = false;
            private System.Boolean _Consolidar = false;
            private System.String _TipDocConsolida = "";
            private System.Decimal _NroDocConsolida;
            private System.Boolean _Contabilizar = false;
            private System.String _ProductoProduccion = "";
            private System.String _Mesero = "";
            private System.Decimal _BaseImp1 = 0;
            private System.Decimal _BaseImp2 = 0;
            private System.Decimal _BaseImp3 = 0;
            private System.Decimal _PorcImp1 = 0;
            private System.Decimal _PorcImp2 = 0;
            private System.Decimal _PorcImp3 = 0;
            private System.Decimal _ValorImp1 = 0;
            private System.Decimal _ValorImp2 = 0;
            private System.Decimal _ValorImp3 = 0;
            private System.Decimal _Ocupantes = 0;
            private System.String _UbicaMesa = "";
            private System.String _PuntoVta = "";
            private System.Int32 _doc_anio = 0;
            private System.Int32 _doc_mes = 0;
            private System.Int32 _doc_dia = 0;
            private System.Boolean _Autorizado = false;
            private System.String _MotivoAnulacion = "";
            private System.Boolean _sev_DeLiq = false;
            private System.String _Cobranza = "";
            private System.Decimal _tra_inmediato = 0;
            private System.Decimal _IdClaveDocDespacho = 0;
            private System.String _Doc_mensaje = "";
            private System.DateTime _Doc_FecGraba = new DateTime(1900, 1, 1, 0, 0, 0);
            private System.DateTime _AuxFec4 = new DateTime(1900, 1, 1, 0, 0, 0);
            private System.DateTime _AuxFec5 = new DateTime(1900, 1, 1, 0, 0, 0);
            private System.String _AuxLog4 = "";
            private System.String _AuxLog5 = "";
            private System.Decimal _NroCtrbuyteEspecial = 0;
            private System.String _claveSri = "";
            private System.String _estadoSri = "";
            private System.String _guiaRemision = "";
            private System.String _NroAutorizacionSri = "";
            private System.String _fechaAutorizacion = "";
            private System.Int32 _tipoEmision = 0;
            private System.String _rutaTransporte = "";
            private System.String _codEstabDestino = "";
            private System.String _docAduaneroUnico = "";
            private System.String _dirPartida = "";
            private System.String _codClienteFinal = "";
            private System.String _nomClienteFinal = "";
            private System.String _AutorizadoFecha = "";
            private System.String _AutorizadoPor = "";
            public bool autonumeracion = false;
            public bool DocDeProveedor = false;
            //
            // Este método se usará para ajustar los anchos de las propiedades
            private string ajustarAncho(string cadena, int ancho)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
                // devolver la cadena quitando los espacios en blanco
                // esto asegura que no se devolverá un tamaño mayor ni espacios "extras"
                return (cadena + sb.ToString()).Substring(0, ancho).Trim();
            }
            //
            public System.String Doc_sucursal
            {
                get
                {
                    return ajustarAncho(_Doc_sucursal, 3);
                }
                set
                {
                    _Doc_sucursal = value;
                }
            }
            public System.String Doc_Bodega
            {
                get
                {
                    return ajustarAncho(_Doc_Bodega, 3);
                }
                set
                {
                    _Doc_Bodega = value;
                }
            }
            public System.String Opc_documento
            {
                get
                {
                    return ajustarAncho(_Opc_documento, 3);
                }
                set
                {
                    _Opc_documento = value;
                }
            }
            public System.Decimal Doc_numero
            {
                get
                {
                    return _Doc_numero;
                }
                set
                {
                    _Doc_numero = value;
                }
            }
            public System.String Doc_docnombre
            {
                get
                {
                    return ajustarAncho(_Doc_docnombre, 40);
                }
                set
                {
                    _Doc_docnombre = value;
                }
            }
            public System.String Doc_TipoDoc
            {
                get
                {
                    return ajustarAncho(_Doc_TipoDoc, 3);
                }
                set
                {
                    _Doc_TipoDoc = value;
                }
            }
            public System.String Doc_DocSop
            {
                get
                {
                    return ajustarAncho(_Doc_DocSop, 3);
                }
                set
                {
                    _Doc_DocSop = value;
                }
            }
            public System.Decimal Doc_NumSop
            {
                get
                {
                    return _Doc_NumSop;
                }
                set
                {
                    _Doc_NumSop = value;
                }
            }
            public System.DateTime Doc_fecha
            {
                get
                {
                    return _Doc_fecha;
                }
                set
                {
                    _Doc_fecha = value;
                }
            }
            public System.DateTime Doc_Hora
            {
                get
                {
                    return _Doc_Hora;
                }
                set
                {
                    _Doc_Hora = value;
                }
            }
            public System.String Doc_extension
            {
                get
                {
                    return ajustarAncho(_Doc_extension, 15);
                }
                set
                {
                    _Doc_extension = value;
                }
            }
            public System.String Doc_codper
            {
                get
                {
                    return ajustarAncho(_Doc_codper, 15);
                }
                set
                {
                    _Doc_codper = value;
                }
            }
            public System.String Doc_codusu
            {
                get
                {
                    return ajustarAncho(_Doc_codusu, 15);
                }
                set
                {
                    _Doc_codusu = value;
                }
            }
            public System.String Doc_venabre
            {
                get
                {
                    return ajustarAncho(_Doc_venabre, 15);
                }
                set
                {
                    _Doc_venabre = value;
                }
            }
            public System.Decimal Doc_porceniva
            {
                get
                {
                    return _Doc_porceniva;
                }
                set
                {
                    _Doc_porceniva = value;
                }
            }
            public System.Decimal Doc_valoriva
            {
                get
                {
                    return _Doc_valoriva;
                }
                set
                {
                    _Doc_valoriva = value;
                }
            }
            public System.Decimal Doc_totciva
            {
                get
                {
                    return _Doc_totciva;
                }
                set
                {
                    _Doc_totciva = value;
                }
            }
            public System.Decimal Doc_totsiva
            {
                get
                {
                    return _Doc_totsiva;
                }
                set
                {
                    _Doc_totsiva = value;
                }
            }
            public System.String Doc_nombredes1
            {
                get
                {
                    return ajustarAncho(_Doc_nombredes1, 40);
                }
                set
                {
                    _Doc_nombredes1 = value;
                }
            }
            public System.String Doc_nombredes2
            {
                get
                {
                    return ajustarAncho(_Doc_nombredes2, 40);
                }
                set
                {
                    _Doc_nombredes2 = value;
                }
            }
            public System.String Doc_nombredes3
            {
                get
                {
                    return ajustarAncho(_Doc_nombredes3, 40);
                }
                set
                {
                    _Doc_nombredes3 = value;
                }
            }
            public System.String Doc_nombredes4
            {
                get
                {
                    return ajustarAncho(_Doc_nombredes4, 40);
                }
                set
                {
                    _Doc_nombredes4 = value;
                }
            }
            public System.Decimal Doc_porcendes1
            {
                get
                {
                    return _Doc_porcendes1;
                }
                set
                {
                    _Doc_porcendes1 = value;
                }
            }
            public System.Decimal Doc_porcendes2
            {
                get
                {
                    return _Doc_porcendes2;
                }
                set
                {
                    _Doc_porcendes2 = value;
                }
            }
            public System.Decimal Doc_porcendes3
            {
                get
                {
                    return _Doc_porcendes3;
                }
                set
                {
                    _Doc_porcendes3 = value;
                }
            }
            public System.Decimal Doc_porcendes4
            {
                get
                {
                    return _Doc_porcendes4;
                }
                set
                {
                    _Doc_porcendes4 = value;
                }
            }
            public System.Decimal Doc_valordes1
            {
                get
                {
                    return _Doc_valordes1;
                }
                set
                {
                    _Doc_valordes1 = value;
                }
            }
            public System.Decimal Doc_valordes2
            {
                get
                {
                    return _Doc_valordes2;
                }
                set
                {
                    _Doc_valordes2 = value;
                }
            }
            public System.Decimal Doc_valordes3
            {
                get
                {
                    return _Doc_valordes3;
                }
                set
                {
                    _Doc_valordes3 = value;
                }
            }
            public System.Decimal Doc_valordes4
            {
                get
                {
                    return _Doc_valordes4;
                }
                set
                {
                    _Doc_valordes4 = value;
                }
            }
            public System.Decimal Doc_valor
            {
                get
                {
                    return _Doc_valor;
                }
                set
                {
                    _Doc_valor = value;
                }
            }
            public System.Decimal Doc_valorabon
            {
                get
                {
                    return _Doc_valorabon;
                }
                set
                {
                    _Doc_valorabon = value;
                }
            }
            public System.String Doc_detalle
            {
                get
                {
                    // Seguramente sería mejor sin ajustar el ancho...
                    //return ajustarAncho(_Doc_detalle,512);
                    return _Doc_detalle;
                }
                set
                {
                    _Doc_detalle = value;
                }
            }
            public System.String Doc_NombreImp
            {
                get
                {
                    return ajustarAncho(_Doc_NombreImp, 80);
                }
                set
                {
                    _Doc_NombreImp = value;
                }
            }
            public System.String Doc_CiRuc
            {
                get
                {
                    return ajustarAncho(_Doc_CiRuc, 20);
                }
                set
                {
                    _Doc_CiRuc = value;
                }
            }
            public System.String Doc_Direccion
            {
                get
                {
                    return ajustarAncho(_Doc_Direccion, 300);
                }
                set
                {
                    _Doc_Direccion = value;
                }
            }
            public System.String Doc_Telefono1
            {
                get
                {
                    return ajustarAncho(_Doc_Telefono1, 20);
                }
                set
                {
                    _Doc_Telefono1 = value;
                }
            }
            public System.String Doc_Telefono2
            {
                get
                {
                    return ajustarAncho(_Doc_Telefono2, 20);
                }
                set
                {
                    _Doc_Telefono2 = value;
                }
            }
            public System.String Doc_DepDes
            {
                get
                {
                    return ajustarAncho(_Doc_DepDes, 50);
                }
                set
                {
                    _Doc_DepDes = value;
                }
            }
            public System.Decimal Doc_TotDesArt
            {
                get
                {
                    return _Doc_TotDesArt;
                }
                set
                {
                    _Doc_TotDesArt = value;
                }
            }
            public System.Decimal Doc_TotDesSer
            {
                get
                {
                    return _Doc_TotDesSer;
                }
                set
                {
                    _Doc_TotDesSer = value;
                }
            }
            public System.Decimal Doc_TotArtCIva
            {
                get
                {
                    return _Doc_TotArtCIva;
                }
                set
                {
                    _Doc_TotArtCIva = value;
                }
            }
            public System.Decimal Doc_TotArtSIva
            {
                get
                {
                    return _Doc_TotArtSIva;
                }
                set
                {
                    _Doc_TotArtSIva = value;
                }
            }
            public System.Decimal Doc_TotSerCIva
            {
                get
                {
                    return _Doc_TotSerCIva;
                }
                set
                {
                    _Doc_TotSerCIva = value;
                }
            }
            public System.Decimal Doc_TotSerSIva
            {
                get
                {
                    return _Doc_TotSerSIva;
                }
                set
                {
                    _Doc_TotSerSIva = value;
                }
            }
            public System.Decimal Doc_TotAcf
            {
                get
                {
                    return _Doc_TotAcf;
                }
                set
                {
                    _Doc_TotAcf = value;
                }
            }
            public System.Decimal Doc_Contado
            {
                get
                {
                    return _Doc_Contado;
                }
                set
                {
                    _Doc_Contado = value;
                }
            }
            public System.DateTime Doc_FechaEfe
            {
                get
                {
                    return _Doc_FechaEfe;
                }
                set
                {
                    _Doc_FechaEfe = value;
                }
            }
            public System.Int32 Doc_Estado
            {
                get
                {
                    return _Doc_Estado;
                }
                set
                {
                    _Doc_Estado = value;
                }
            }
            public System.Int32 Doc_Oculto
            {
                get
                {
                    return _Doc_Oculto;
                }
                set
                {
                    _Doc_Oculto = value;
                }
            }
            public System.Decimal Doc_Contabilidad
            {
                get
                {
                    return _Doc_Contabilidad;
                }
                set
                {
                    _Doc_Contabilidad = value;
                }
            }
            public System.Decimal Doc_Banco
            {
                get
                {
                    return _Doc_Banco;
                }
                set
                {
                    _Doc_Banco = value;
                }
            }
            public System.Int16 Doc_Inventario
            {
                get
                {
                    return _Doc_Inventario;
                }
                set
                {
                    _Doc_Inventario = value;
                }
            }
            public System.Int16 Doc_Ventas
            {
                get
                {
                    return _Doc_Ventas;
                }
                set
                {
                    _Doc_Ventas = value;
                }
            }
            public System.Int16 Doc_Compras
            {
                get
                {
                    return _Doc_Compras;
                }
                set
                {
                    _Doc_Compras = value;
                }
            }
            public System.Int16 Doc_Activo
            {
                get
                {
                    return _Doc_Activo;
                }
                set
                {
                    _Doc_Activo = value;
                }
            }
            public System.Decimal Doc_Adicional1
            {
                get
                {
                    return _Doc_Adicional1;
                }
                set
                {
                    _Doc_Adicional1 = value;
                }
            }
            public System.Decimal Doc_Adicional2
            {
                get
                {
                    return _Doc_Adicional2;
                }
                set
                {
                    _Doc_Adicional2 = value;
                }
            }
            public System.Decimal Doc_NumeroExterno
            {
                get
                {
                    return _Doc_NumeroExterno;
                }
                set
                {
                    _Doc_NumeroExterno = value;
                }
            }
            public System.String Doc_NroIdDoc
            {
                get
                {
                    return ajustarAncho(_Doc_NroIdDoc, 50);
                }
                set
                {
                    _Doc_NroIdDoc = value;
                }
            }
            public System.Decimal Doc_SaldoActualCli
            {
                get
                {
                    return _Doc_SaldoActualCli;
                }
                set
                {
                    _Doc_SaldoActualCli = value;
                }
            }
            public System.Decimal Doc_SaldoFinalCli
            {
                get
                {
                    return _Doc_SaldoFinalCli;
                }
                set
                {
                    _Doc_SaldoFinalCli = value;
                }
            }
            public System.DateTime Doc_FechaModifica
            {
                get
                {
                    return _Doc_FechaModifica;
                }
                set
                {
                    _Doc_FechaModifica = value;
                }
            }
            public System.String Doc_CentroCosto
            {
                get
                {
                    return ajustarAncho(_Doc_CentroCosto, 20);
                }
                set
                {
                    _Doc_CentroCosto = value;
                }
            }
            public System.Decimal IdClaveDoc
            {
                get
                {
                    return _IdClaveDoc;
                }
                set
                {
                    _IdClaveDoc = value;
                }
            }
            public System.Decimal IdClaveDocSop
            {
                get
                {
                    return _IdClaveDocSop;
                }
                set
                {
                    _IdClaveDocSop = value;
                }
            }
            public System.String doc_SucursalDestino
            {
                get
                {
                    return ajustarAncho(_doc_SucursalDestino, 20);
                }
                set
                {
                    _doc_SucursalDestino = value;
                }
            }
            public System.String doc_SucDestino
            {
                get
                {
                    return ajustarAncho(_doc_SucDestino, 20);
                }
                set
                {
                    _doc_SucDestino = value;
                }
            }
            public System.String doc_BodDestino
            {
                get
                {
                    return ajustarAncho(_doc_BodDestino, 20);
                }
                set
                {
                    _doc_BodDestino = value;
                }
            }
            public System.String Doc_NroLoteDoc
            {
                get
                {
                    return ajustarAncho(_Doc_NroLoteDoc, 20);
                }
                set
                {
                    _Doc_NroLoteDoc = value;
                }
            }
            public System.String doc_BancoOrigen
            {
                get
                {
                    return ajustarAncho(_doc_BancoOrigen, 20);
                }
                set
                {
                    _doc_BancoOrigen = value;
                }
            }
            public System.String doc_BancoDestino
            {
                get
                {
                    return ajustarAncho(_doc_BancoDestino, 20);
                }
                set
                {
                    _doc_BancoDestino = value;
                }
            }
            public System.String doc_NumeroCheque
            {
                get
                {
                    return ajustarAncho(_doc_NumeroCheque, 20);
                }
                set
                {
                    _doc_NumeroCheque = value;
                }
            }
            public System.Boolean doc_Aceptado
            {
                get
                {
                    return _doc_Aceptado;
                }
                set
                {
                    _doc_Aceptado = value;
                }
            }
            public System.Boolean Doc_Liquidado
            {
                get
                {
                    return _Doc_Liquidado;
                }
                set
                {
                    _Doc_Liquidado = value;
                }
            }
            public System.String Doc_CobraCheque
            {
                get
                {
                    return ajustarAncho(_Doc_CobraCheque, 10);
                }
                set
                {
                    _Doc_CobraCheque = value;
                }
            }
            public System.Decimal doc_TotDesCIva
            {
                get
                {
                    return _doc_TotDesCIva;
                }
                set
                {
                    _doc_TotDesCIva = value;
                }
            }
            public System.Decimal doc_TotDesSiva
            {
                get
                {
                    return _doc_TotDesSiva;
                }
                set
                {
                    _doc_TotDesSiva = value;
                }
            }
            public System.DateTime Periodo1
            {
                get
                {
                    return _Periodo1;
                }
                set
                {
                    _Periodo1 = value;
                }
            }
            public System.DateTime Periodo2
            {
                get
                {
                    return _Periodo2;
                }
                set
                {
                    _Periodo2 = value;
                }
            }
            public System.DateTime FacDesde
            {
                get
                {
                    return _FacDesde;
                }
                set
                {
                    _FacDesde = value;
                }
            }
            public System.DateTime FacHasta
            {
                get
                {
                    return _FacHasta;
                }
                set
                {
                    _FacHasta = value;
                }
            }
            public System.String Habitacion
            {
                get
                {
                    return ajustarAncho(_Habitacion, 15);
                }
                set
                {
                    _Habitacion = value;
                }
            }
            public System.String Mesa
            {
                get
                {
                    return ajustarAncho(_Mesa, 15);
                }
                set
                {
                    _Mesa = value;
                }
            }
            public System.String TipoPeriodo
            {
                get
                {
                    return ajustarAncho(_TipoPeriodo, 20);
                }
                set
                {
                    _TipoPeriodo = value;
                }
            }
            public System.String Adi_NroAutSri
            {
                get
                {
                    return ajustarAncho(_Adi_NroAutSri, 80);
                }
                set
                {
                    _Adi_NroAutSri = value;
                }
            }
            public System.String Adi_SustTrib
            {
                get
                {
                    return ajustarAncho(_Adi_SustTrib, 20);
                }
                set
                {
                    _Adi_SustTrib = value;
                }
            }
            public System.String Adi_TipoDocSri
            {
                get
                {
                    return ajustarAncho(_Adi_TipoDocSri, 20);
                }
                set
                {
                    _Adi_TipoDocSri = value;
                }
            }
            public System.String Adi_SNDevIva
            {
                get
                {
                    return ajustarAncho(_Adi_SNDevIva, 1);
                }
                set
                {
                    _Adi_SNDevIva = value;
                }
            }
            public System.DateTime Adi_FechContab
            {
                get
                {
                    return _Adi_FechContab;
                }
                set
                {
                    _Adi_FechContab = value;
                }
            }
            public System.String Adi_CodigoNSR
            {
                get
                {
                    return ajustarAncho(_Adi_CodigoNSR, 20);
                }
                set
                {
                    _Adi_CodigoNSR = value;
                }
            }
            public System.String Dia_Status
            {
                get
                {
                    return ajustarAncho(_Dia_Status, 1);
                }
                set
                {
                    _Dia_Status = value;
                }
            }
            public System.String Moneda
            {
                get
                {
                    return ajustarAncho(_Moneda, 20);
                }
                set
                {
                    _Moneda = value;
                }
            }
            public System.Decimal Paridad
            {
                get
                {
                    return _Paridad;
                }
                set
                {
                    _Paridad = value;
                }
            }
            public System.Decimal ParidadBiMoneda
            {
                get
                {
                    return _ParidadBiMoneda;
                }
                set
                {
                    _ParidadBiMoneda = value;
                }
            }
            public System.String PaisDestino
            {
                get
                {
                    return ajustarAncho(_PaisDestino, 80);
                }
                set
                {
                    _PaisDestino = value;
                }
            }
            public System.String ProvinciaDestino
            {
                get
                {
                    return ajustarAncho(_ProvinciaDestino, 80);
                }
                set
                {
                    _ProvinciaDestino = value;
                }
            }
            public System.String CiudadDestino
            {
                get
                {
                    return ajustarAncho(_CiudadDestino, 80);
                }
                set
                {
                    _CiudadDestino = value;
                }
            }
            public System.String DireccionDestino
            {
                get
                {
                    return ajustarAncho(_DireccionDestino, 80);
                }
                set
                {
                    _DireccionDestino = value;
                }
            }
            public System.String Destinatario
            {
                get
                {
                    return ajustarAncho(_Destinatario, 80);
                }
                set
                {
                    _Destinatario = value;
                }
            }
            public System.String RucDestinatario
            {
                get
                {
                    return ajustarAncho(_RucDestinatario, 80);
                }
                set
                {
                    _RucDestinatario = value;
                }
            }
            public System.String ContactoDestino
            {
                get
                {
                    return ajustarAncho(_ContactoDestino, 80);
                }
                set
                {
                    _ContactoDestino = value;
                }
            }
            public System.DateTime FecIniTransporte
            {
                get
                {
                    return _FecIniTransporte;
                }
                set
                {
                    _FecIniTransporte = value;
                }
            }
            public System.DateTime FecFinTransporte
            {
                get
                {
                    return _FecFinTransporte;
                }
                set
                {
                    _FecFinTransporte = value;
                }
            }
            public System.String Transportista
            {
                get
                {
                    return ajustarAncho(_Transportista, 80);
                }
                set
                {
                    _Transportista = value;
                }
            }
            public System.String RucTransportista
            {
                get
                {
                    return ajustarAncho(_RucTransportista, 15);
                }
                set
                {
                    _RucTransportista = value;
                }
            }
            public System.String TipoTransporte
            {
                get
                {
                    return ajustarAncho(_TipoTransporte, 20);
                }
                set
                {
                    _TipoTransporte = value;
                }
            }
            public System.String EsContable
            {
                get
                {
                    return ajustarAncho(_EsContable, 1);
                }
                set
                {
                    _EsContable = value;
                }
            }
            public System.String AuxVar1
            {
                get
                {
                    return ajustarAncho(_AuxVar1, 128);
                }
                set
                {
                    _AuxVar1 = value;
                }
            }
            public System.String AuxVar2
            {
                get
                {
                    return ajustarAncho(_AuxVar2, 128);
                }
                set
                {
                    _AuxVar2 = value;
                }
            }
            public System.String AuxVar3
            {
                get
                {
                    return ajustarAncho(_AuxVar3, 128);
                }
                set
                {
                    _AuxVar3 = value;
                }
            }
            public System.String AuxVar4
            {
                get
                {
                    return ajustarAncho(_AuxVar4, 128);
                }
                set
                {
                    _AuxVar4 = value;
                }
            }
            public System.String AuxVar5
            {
                get
                {
                    return ajustarAncho(_AuxVar5, 128);
                }
                set
                {
                    _AuxVar5 = value;
                }
            }
            public System.String AuxVar6
            {
                get
                {
                    return ajustarAncho(_AuxVar6, 128);
                }
                set
                {
                    _AuxVar6 = value;
                }
            }
            public System.String AuxVar7
            {
                get
                {
                    return ajustarAncho(_AuxVar7, 128);
                }
                set
                {
                    _AuxVar7 = value;
                }
            }
            public System.String AuxVar8
            {
                get
                {
                    return ajustarAncho(_AuxVar8, 128);
                }
                set
                {
                    _AuxVar8 = value;
                }
            }
            public System.String AuxVar9
            {
                get
                {
                    return ajustarAncho(_AuxVar9, 128);
                }
                set
                {
                    _AuxVar9 = value;
                }
            }
            public System.String AuxVar10
            {
                get
                {
                    return ajustarAncho(_AuxVar10, 128);
                }
                set
                {
                    _AuxVar10 = value;
                }
            }
            public System.String AuxVar11
            {
                get
                {
                    return ajustarAncho(_AuxVar11, 128);
                }
                set
                {
                    _AuxVar11 = value;
                }
            }
            public System.String AuxVar12
            {
                get
                {
                    return ajustarAncho(_AuxVar12, 128);
                }
                set
                {
                    _AuxVar12 = value;
                }
            }
            public System.DateTime AuxFec1
            {
                get
                {
                    return _AuxFec1;
                }
                set
                {
                    _AuxFec1 = value;
                }
            }
            public System.DateTime AuxFec2
            {
                get
                {
                    return _AuxFec2;
                }
                set
                {
                    _AuxFec2 = value;
                }
            }
            public System.DateTime AuxFec3
            {
                get
                {
                    return _AuxFec3;
                }
                set
                {
                    _AuxFec3 = value;
                }
            }
            public System.String AuxLog1
            {
                get
                {
                    return ajustarAncho(_AuxLog1, 1);
                }
                set
                {
                    _AuxLog1 = value;
                }
            }
            public System.String AuxLog2
            {
                get
                {
                    return ajustarAncho(_AuxLog2, 1);
                }
                set
                {
                    _AuxLog2 = value;
                }
            }
            public System.String AuxLog3
            {
                get
                {
                    return ajustarAncho(_AuxLog3, 1);
                }
                set
                {
                    _AuxLog3 = value;
                }
            }
            public System.Decimal AuxNum1
            {
                get
                {
                    return _AuxNum1;
                }
                set
                {
                    _AuxNum1 = value;
                }
            }
            public System.Decimal AuxNum2
            {
                get
                {
                    return _AuxNum2;
                }
                set
                {
                    _AuxNum2 = value;
                }
            }
            public System.Decimal AuxNum3
            {
                get
                {
                    return _AuxNum3;
                }
                set
                {
                    _AuxNum3 = value;
                }
            }
            public System.Decimal AuxNum4
            {
                get
                {
                    return _AuxNum4;
                }
                set
                {
                    _AuxNum4 = value;
                }
            }
            public System.Decimal AuxNum5
            {
                get
                {
                    return _AuxNum5;
                }
                set
                {
                    _AuxNum5 = value;
                }
            }
            public System.Decimal AuxNum6
            {
                get
                {
                    return _AuxNum6;
                }
                set
                {
                    _AuxNum6 = value;
                }
            }
            public System.Decimal AuxNum7
            {
                get
                {
                    return _AuxNum7;
                }
                set
                {
                    _AuxNum7 = value;
                }
            }
            public System.Decimal AuxNum8
            {
                get
                {
                    return _AuxNum8;
                }
                set
                {
                    _AuxNum8 = value;
                }
            }
            public System.Decimal AuxNum9
            {
                get
                {
                    return _AuxNum9;
                }
                set
                {
                    _AuxNum9 = value;
                }
            }
            public System.Decimal AuxNum10
            {
                get
                {
                    return _AuxNum10;
                }
                set
                {
                    _AuxNum10 = value;
                }
            }
            public System.Decimal AuxNum11
            {
                get
                {
                    return _AuxNum11;
                }
                set
                {
                    _AuxNum11 = value;
                }
            }
            public System.Decimal AuxNum12
            {
                get
                {
                    return _AuxNum12;
                }
                set
                {
                    _AuxNum12 = value;
                }
            }
            public System.Boolean doc_Anticipo
            {
                get
                {
                    return _doc_Anticipo;
                }
                set
                {
                    _doc_Anticipo = value;
                }
            }
            public System.Boolean Consolidar
            {
                get
                {
                    return _Consolidar;
                }
                set
                {
                    _Consolidar = value;
                }
            }
            public System.String TipDocConsolida
            {
                get
                {
                    return ajustarAncho(_TipDocConsolida, 10);
                }
                set
                {
                    _TipDocConsolida = value;
                }
            }
            public System.Decimal NroDocConsolida
            {
                get
                {
                    return _NroDocConsolida;
                }
                set
                {
                    _NroDocConsolida = value;
                }
            }
            public System.Boolean Contabilizar
            {
                get
                {
                    return _Contabilizar;
                }
                set
                {
                    _Contabilizar = value;
                }
            }
            public System.String ProductoProduccion
            {
                get
                {
                    return ajustarAncho(_ProductoProduccion, 50);
                }
                set
                {
                    _ProductoProduccion = value;
                }
            }
            public System.String Mesero
            {
                get
                {
                    return ajustarAncho(_Mesero, 125);
                }
                set
                {
                    _Mesero = value;
                }
            }
            public System.Decimal BaseImp1
            {
                get
                {
                    return _BaseImp1;
                }
                set
                {
                    _BaseImp1 = value;
                }
            }
            public System.Decimal BaseImp2
            {
                get
                {
                    return _BaseImp2;
                }
                set
                {
                    _BaseImp2 = value;
                }
            }
            public System.Decimal BaseImp3
            {
                get
                {
                    return _BaseImp3;
                }
                set
                {
                    _BaseImp3 = value;
                }
            }
            public System.Decimal PorcImp1
            {
                get
                {
                    return _PorcImp1;
                }
                set
                {
                    _PorcImp1 = value;
                }
            }
            public System.Decimal PorcImp2
            {
                get
                {
                    return _PorcImp2;
                }
                set
                {
                    _PorcImp2 = value;
                }
            }
            public System.Decimal PorcImp3
            {
                get
                {
                    return _PorcImp3;
                }
                set
                {
                    _PorcImp3 = value;
                }
            }
            public System.Decimal ValorImp1
            {
                get
                {
                    return _ValorImp1;
                }
                set
                {
                    _ValorImp1 = value;
                }
            }
            public System.Decimal ValorImp2
            {
                get
                {
                    return _ValorImp2;
                }
                set
                {
                    _ValorImp2 = value;
                }
            }
            public System.Decimal ValorImp3
            {
                get
                {
                    return _ValorImp3;
                }
                set
                {
                    _ValorImp3 = value;
                }
            }
            public System.Decimal Ocupantes
            {
                get
                {
                    return _Ocupantes;
                }
                set
                {
                    _Ocupantes = value;
                }
            }
            public System.String UbicaMesa
            {
                get
                {
                    return ajustarAncho(_UbicaMesa, 50);
                }
                set
                {
                    _UbicaMesa = value;
                }
            }
            public System.String PuntoVta
            {
                get
                {
                    return ajustarAncho(_PuntoVta, 128);
                }
                set
                {
                    _PuntoVta = value;
                }
            }
            public System.Int32 doc_anio
            {
                get
                {
                    return _doc_anio;
                }
                set
                {
                    _doc_anio = value;
                }
            }
            public System.Int32 doc_mes
            {
                get
                {
                    return _doc_mes;
                }
                set
                {
                    _doc_mes = value;
                }
            }
            public System.Int32 doc_dia
            {
                get
                {
                    return _doc_dia;
                }
                set
                {
                    _doc_dia = value;
                }
            }
            public System.Boolean Autorizado
            {
                get
                {
                    return _Autorizado;
                }
                set
                {
                    _Autorizado = value;
                }
            }
            public System.String MotivoAnulacion
            {
                get
                {
                    return ajustarAncho(_MotivoAnulacion, 128);
                }
                set
                {
                    _MotivoAnulacion = value;
                }
            }
            public System.Boolean sev_DeLiq
            {
                get
                {
                    return _sev_DeLiq;
                }
                set
                {
                    _sev_DeLiq = value;
                }
            }
            public System.String Cobranza
            {
                get
                {
                    return ajustarAncho(_Cobranza, 50);
                }
                set
                {
                    _Cobranza = value;
                }
            }
            public System.Decimal tra_inmediato
            {
                get
                {
                    return _tra_inmediato;
                }
                set
                {
                    _tra_inmediato = value;
                }
            }
            public System.Decimal IdClaveDocDespacho
            {
                get
                {
                    return _IdClaveDocDespacho;
                }
                set
                {
                    _IdClaveDocDespacho = value;
                }
            }
            public System.String Doc_mensaje
            {
                get
                {
                    // Seguramente sería mejor sin ajustar el ancho...
                    //return ajustarAncho(_Doc_mensaje,512);
                    return _Doc_mensaje;
                }
                set
                {
                    _Doc_mensaje = value;
                }
            }
            public System.DateTime Doc_FecGraba
            {
                get
                {
                    return _Doc_FecGraba;
                }
                set
                {
                    _Doc_FecGraba = value;
                }
            }
            public System.DateTime AuxFec4
            {
                get
                {
                    return _AuxFec4;
                }
                set
                {
                    _AuxFec4 = value;
                }
            }
            public System.DateTime AuxFec5
            {
                get
                {
                    return _AuxFec5;
                }
                set
                {
                    _AuxFec5 = value;
                }
            }
            public System.String AuxLog4
            {
                get
                {
                    return ajustarAncho(_AuxLog4, 1);
                }
                set
                {
                    _AuxLog4 = value;
                }
            }
            public System.String AuxLog5
            {
                get
                {
                    return ajustarAncho(_AuxLog5, 1);
                }
                set
                {
                    _AuxLog5 = value;
                }
            }
            public System.Decimal NroCtrbuyteEspecial
            {
                get
                {
                    return _NroCtrbuyteEspecial;
                }
                set
                {
                    _NroCtrbuyteEspecial = value;
                }
            }
            public System.String claveSri
            {
                get
                {
                    return ajustarAncho(_claveSri, 80);
                }
                set
                {
                    _claveSri = value;
                }
            }
            public System.String estadoSri
            {
                get
                {
                    return ajustarAncho(_estadoSri, 20);
                }
                set
                {
                    _estadoSri = value;
                }
            }
            public System.String guiaRemision
            {
                get
                {
                    return ajustarAncho(_guiaRemision, 20);
                }
                set
                {
                    _guiaRemision = value;
                }
            }
            public System.String NroAutorizacionSri
            {
                get
                {
                    return ajustarAncho(_NroAutorizacionSri, 80);
                }
                set
                {
                    _NroAutorizacionSri = value;
                }
            }
            public System.String fechaAutorizacion
            {
                get
                {
                    return ajustarAncho(_fechaAutorizacion, 40);
                }
                set
                {
                    _fechaAutorizacion = value;
                }
            }
            public System.Int32 tipoEmision
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
            public System.String rutaTransporte
            {
                get
                {
                    return ajustarAncho(_rutaTransporte, 80);
                }
                set
                {
                    _rutaTransporte = value;
                }
            }
            public System.String codEstabDestino
            {
                get
                {
                    return ajustarAncho(_codEstabDestino, 15);
                }
                set
                {
                    _codEstabDestino = value;
                }
            }
            public System.String docAduaneroUnico
            {
                get
                {
                    return ajustarAncho(_docAduaneroUnico, 30);
                }
                set
                {
                    _docAduaneroUnico = value;
                }
            }
            public System.String dirPartida
            {
                get
                {
                    return ajustarAncho(_dirPartida, 80);
                }
                set
                {
                    _dirPartida = value;
                }
            }
            public System.String codClienteFinal
            {
                get
                {
                    return _codClienteFinal;
                }
                set
                {
                    _codClienteFinal = value;
                }
            }
            public System.String nomClienteFinal
            {
                get
                {
                    return _nomClienteFinal;
                }
                set
                {
                    _nomClienteFinal = value;
                }
            }
            public System.String AutorizadoFecha
            {
                get
                {
                    return ajustarAncho(_AutorizadoFecha, 100);
                }
                set
                {
                    _AutorizadoFecha = value;
                }
            }
            public System.String AutorizadoPor
            {
                get
                {
                    return ajustarAncho(_AutorizadoPor, 100);
                }
                set
                {
                    _AutorizadoPor = value;
                }
            }
            //
            //
            // Campos y métodos compartidos (estáticos) para gestionar la base de datos
            //
            // La cadena de conexión a la base de datos
            private static string cadenaConexion = @"";
            // La cadena de selección
            public static string CadenaSelect = "";
            //
            public AdcDocComp()
            {
            }
            public AdcDocComp(string conex)
            {
                cadenaConexion = conex;
            }
            //
            // Métodos compartidos (estáticos) privados
            //
            // asigna una fila de la tabla a un objeto AdcDoc
            public static AdcDocComp row2AdcDoc(DataRow r)
            {
                // asigna a un objeto AdcDoc los datos del dataRow indicado
                AdcDocComp oAdcDoc = new AdcDocComp();
                //
                oAdcDoc.Doc_sucursal = r["Doc_sucursal"].ToString();
                oAdcDoc.Doc_Bodega = r["Doc_Bodega"].ToString();
                oAdcDoc.Opc_documento = r["Opc_documento"].ToString();
                oAdcDoc.Doc_numero = System.Decimal.Parse("0" + r["Doc_numero"].ToString());
                oAdcDoc.Doc_docnombre = r["Doc_docnombre"].ToString();
                oAdcDoc.Doc_TipoDoc = r["Doc_TipoDoc"].ToString();
                oAdcDoc.Doc_DocSop = r["Doc_DocSop"].ToString();
                oAdcDoc.Doc_NumSop = System.Decimal.Parse("0" + r["Doc_NumSop"].ToString());
                try
                {
                    oAdcDoc.Doc_fecha = DateTime.Parse(r["Doc_fecha"].ToString());
                }
                catch
                {
                    oAdcDoc.Doc_fecha = DateTime.Now;
                }
                try
                {
                    oAdcDoc.Doc_Hora = DateTime.Parse(r["Doc_Hora"].ToString());
                }
                catch
                {
                    oAdcDoc.Doc_Hora = DateTime.Now;
                }
                oAdcDoc.Doc_extension = r["Doc_extension"].ToString();
                oAdcDoc.Doc_codper = r["Doc_codper"].ToString();
                oAdcDoc.Doc_codusu = r["Doc_codusu"].ToString();
                oAdcDoc.Doc_venabre = r["Doc_venabre"].ToString();
                oAdcDoc.Doc_porceniva = System.Decimal.Parse("0" + r["Doc_porceniva"].ToString());
                oAdcDoc.Doc_valoriva = System.Decimal.Parse("0" + r["Doc_valoriva"].ToString());
                oAdcDoc.Doc_totciva = System.Decimal.Parse("0" + r["Doc_totciva"].ToString());
                oAdcDoc.Doc_totsiva = System.Decimal.Parse("0" + r["Doc_totsiva"].ToString());
                oAdcDoc.Doc_nombredes1 = r["Doc_nombredes1"].ToString();
                oAdcDoc.Doc_nombredes2 = r["Doc_nombredes2"].ToString();
                oAdcDoc.Doc_nombredes3 = r["Doc_nombredes3"].ToString();
                oAdcDoc.Doc_nombredes4 = r["Doc_nombredes4"].ToString();
                oAdcDoc.Doc_porcendes1 = System.Decimal.Parse("0" + r["Doc_porcendes1"].ToString());
                oAdcDoc.Doc_porcendes2 = System.Decimal.Parse("0" + r["Doc_porcendes2"].ToString());
                oAdcDoc.Doc_porcendes3 = System.Decimal.Parse("0" + r["Doc_porcendes3"].ToString());
                oAdcDoc.Doc_porcendes4 = System.Decimal.Parse("0" + r["Doc_porcendes4"].ToString());
                oAdcDoc.Doc_valordes1 = System.Decimal.Parse("0" + r["Doc_valordes1"].ToString());
                oAdcDoc.Doc_valordes2 = System.Decimal.Parse("0" + r["Doc_valordes2"].ToString());
                oAdcDoc.Doc_valordes3 = System.Decimal.Parse("0" + r["Doc_valordes3"].ToString());
                oAdcDoc.Doc_valordes4 = System.Decimal.Parse("0" + r["Doc_valordes4"].ToString());
                oAdcDoc.Doc_valor = System.Decimal.Parse("0" + r["Doc_valor"].ToString());
                oAdcDoc.Doc_valorabon = System.Decimal.Parse("0" + r["Doc_valorabon"].ToString());
                oAdcDoc.Doc_detalle = r["Doc_detalle"].ToString();
                oAdcDoc.Doc_NombreImp = r["Doc_NombreImp"].ToString();
                oAdcDoc.Doc_CiRuc = r["Doc_CiRuc"].ToString();
                oAdcDoc.Doc_Direccion = r["Doc_Direccion"].ToString();
                oAdcDoc.Doc_Telefono1 = r["Doc_Telefono1"].ToString();
                oAdcDoc.Doc_Telefono2 = r["Doc_Telefono2"].ToString();
                oAdcDoc.Doc_DepDes = r["Doc_DepDes"].ToString();
                oAdcDoc.Doc_TotDesArt = System.Decimal.Parse("0" + r["Doc_TotDesArt"].ToString());
                oAdcDoc.Doc_TotDesSer = System.Decimal.Parse("0" + r["Doc_TotDesSer"].ToString());
                oAdcDoc.Doc_TotArtCIva = System.Decimal.Parse("0" + r["Doc_TotArtCIva"].ToString());
                oAdcDoc.Doc_TotArtSIva = System.Decimal.Parse("0" + r["Doc_TotArtSIva"].ToString());
                oAdcDoc.Doc_TotSerCIva = System.Decimal.Parse("0" + r["Doc_TotSerCIva"].ToString());
                oAdcDoc.Doc_TotSerSIva = System.Decimal.Parse("0" + r["Doc_TotSerSIva"].ToString());
                oAdcDoc.Doc_TotAcf = System.Decimal.Parse("0" + r["Doc_TotAcf"].ToString());
                oAdcDoc.Doc_Contado = System.Decimal.Parse("0" + r["Doc_Contado"].ToString());
                try
                {
                    oAdcDoc.Doc_FechaEfe = DateTime.Parse(r["Doc_FechaEfe"].ToString());
                }
                catch
                {
                    oAdcDoc.Doc_FechaEfe = oAdcDoc.Doc_fecha;
                }
                oAdcDoc.Doc_Estado = System.Int32.Parse("0" + r["Doc_Estado"].ToString());
                oAdcDoc.Doc_Oculto = System.Int32.Parse("0" + r["Doc_Oculto"].ToString());
                try { oAdcDoc.Doc_Contabilidad = System.Decimal.Parse(r["Doc_Contabilidad"].ToString()); } catch { }
                try { oAdcDoc.Doc_Banco = System.Decimal.Parse(r["Doc_Banco"].ToString()); } catch { }
                try { oAdcDoc.Doc_Inventario = System.Int16.Parse(r["Doc_Inventario"].ToString()); } catch { }
                try { oAdcDoc.Doc_Ventas = System.Int16.Parse(r["Doc_Ventas"].ToString()); } catch { }
                try { oAdcDoc.Doc_Compras = System.Int16.Parse(r["Doc_Compras"].ToString()); } catch { }
                try { oAdcDoc.Doc_Activo = System.Int16.Parse(r["Doc_Activo"].ToString()); } catch { }
                oAdcDoc.Doc_Adicional1 = System.Decimal.Parse("0" + r["Doc_Adicional1"].ToString());
                oAdcDoc.Doc_Adicional2 = System.Decimal.Parse("0" + r["Doc_Adicional2"].ToString());
                oAdcDoc.Doc_NumeroExterno = System.Decimal.Parse("0" + r["Doc_NumeroExterno"].ToString());
                oAdcDoc.Doc_NroIdDoc = r["Doc_NroIdDoc"].ToString();
                oAdcDoc.Doc_SaldoActualCli = System.Decimal.Parse("0" + r["Doc_SaldoActualCli"].ToString());
                oAdcDoc.Doc_SaldoFinalCli = System.Decimal.Parse("0" + r["Doc_SaldoFinalCli"].ToString());
                try
                {
                    oAdcDoc.Doc_FechaModifica = DateTime.Parse(r["Doc_FechaModifica"].ToString());
                }
                catch
                {
                    oAdcDoc.Doc_FechaModifica = DateTime.Now;
                }
                oAdcDoc.Doc_CentroCosto = r["Doc_CentroCosto"].ToString();
                oAdcDoc.IdClaveDoc = System.Decimal.Parse("0" + r["IdClaveDoc"].ToString());
                oAdcDoc.IdClaveDocSop = System.Decimal.Parse("0" + r["IdClaveDocSop"].ToString());
                oAdcDoc.doc_SucursalDestino = r["doc_SucursalDestino"].ToString();
                oAdcDoc.doc_SucDestino = r["doc_SucDestino"].ToString();
                oAdcDoc.doc_BodDestino = r["doc_BodDestino"].ToString();
                oAdcDoc.Doc_NroLoteDoc = r["Doc_NroLoteDoc"].ToString();
                oAdcDoc.doc_BancoOrigen = r["doc_BancoOrigen"].ToString();
                oAdcDoc.doc_BancoDestino = r["doc_BancoDestino"].ToString();
                oAdcDoc.doc_NumeroCheque = r["doc_NumeroCheque"].ToString();
                try
                {
                    oAdcDoc.doc_Aceptado = System.Boolean.Parse(r["doc_Aceptado"].ToString());
                }
                catch
                {
                    oAdcDoc.doc_Aceptado = false;
                }
                try
                {
                    oAdcDoc.Doc_Liquidado = System.Boolean.Parse(r["Doc_Liquidado"].ToString());
                }
                catch
                {
                    oAdcDoc.Doc_Liquidado = false;
                }
                oAdcDoc.Doc_CobraCheque = r["Doc_CobraCheque"].ToString();
                oAdcDoc.doc_TotDesCIva = System.Decimal.Parse("0" + r["doc_TotDesCIva"].ToString());
                oAdcDoc.doc_TotDesSiva = System.Decimal.Parse("0" + r["doc_TotDesSiva"].ToString());
                try
                {
                    oAdcDoc.Periodo1 = DateTime.Parse(r["Periodo1"].ToString());
                }
                catch
                {
                    oAdcDoc.Periodo1 = new DateTime(1900, 1, 1, 0, 0, 0);
                }
                try
                {
                    oAdcDoc.Periodo2 = DateTime.Parse(r["Periodo2"].ToString());
                }
                catch
                {
                    oAdcDoc.Periodo2 = new DateTime(1900, 1, 1, 0, 0, 0);
                }
                try
                {
                    oAdcDoc.FacDesde = DateTime.Parse(r["FacDesde"].ToString());
                }
                catch
                {
                    oAdcDoc.FacDesde = new DateTime(1900, 1, 1, 0, 0, 0);
                }
                try
                {
                    oAdcDoc.FacHasta = DateTime.Parse(r["FacHasta"].ToString());
                }
                catch
                {
                    oAdcDoc.FacHasta = new DateTime(1900, 1, 1, 0, 0, 0);
                }
                oAdcDoc.Habitacion = r["Habitacion"].ToString();
                oAdcDoc.Mesa = r["Mesa"].ToString();
                oAdcDoc.TipoPeriodo = r["TipoPeriodo"].ToString();
                oAdcDoc.Adi_NroAutSri = r["Adi_NroAutSri"].ToString();
                oAdcDoc.Adi_SustTrib = r["Adi_SustTrib"].ToString();
                oAdcDoc.Adi_TipoDocSri = r["Adi_TipoDocSri"].ToString();
                oAdcDoc.Adi_SNDevIva = r["Adi_SNDevIva"].ToString();
                try
                {
                    oAdcDoc.Adi_FechContab = DateTime.Parse(r["Adi_FechContab"].ToString());
                }
                catch
                {
                    oAdcDoc.Adi_FechContab = oAdcDoc.Doc_fecha;
                }
                oAdcDoc.Adi_CodigoNSR = r["Adi_CodigoNSR"].ToString();
                oAdcDoc.Dia_Status = r["Dia_Status"].ToString();
                oAdcDoc.Moneda = r["Moneda"].ToString();
                oAdcDoc.Paridad = System.Decimal.Parse("0" + r["Paridad"].ToString());
                oAdcDoc.ParidadBiMoneda = System.Decimal.Parse("0" + r["ParidadBiMoneda"].ToString());
                oAdcDoc.PaisDestino = r["PaisDestino"].ToString();
                oAdcDoc.ProvinciaDestino = r["ProvinciaDestino"].ToString();
                oAdcDoc.CiudadDestino = r["CiudadDestino"].ToString();
                oAdcDoc.DireccionDestino = r["DireccionDestino"].ToString();
                oAdcDoc.Destinatario = r["Destinatario"].ToString();
                oAdcDoc.RucDestinatario = r["RucDestinatario"].ToString();
                oAdcDoc.ContactoDestino = r["ContactoDestino"].ToString();
                try
                {
                    oAdcDoc.FecIniTransporte = DateTime.Parse(r["FecIniTransporte"].ToString());
                }
                catch
                {
                    oAdcDoc.FecIniTransporte = new DateTime(1900, 1, 1);
                }
                try
                {
                    oAdcDoc.FecFinTransporte = DateTime.Parse(r["FecFinTransporte"].ToString());
                }
                catch
                {
                    oAdcDoc.FecFinTransporte = new DateTime(1900, 1, 1, 0, 0, 0);
                }
                oAdcDoc.Transportista = r["Transportista"].ToString();
                oAdcDoc.RucTransportista = r["RucTransportista"].ToString();
                oAdcDoc.TipoTransporte = r["TipoTransporte"].ToString();
                oAdcDoc.EsContable = r["EsContable"].ToString();
                oAdcDoc.AuxVar1 = r["AuxVar1"].ToString();
                oAdcDoc.AuxVar2 = r["AuxVar2"].ToString();
                oAdcDoc.AuxVar3 = r["AuxVar3"].ToString();
                oAdcDoc.AuxVar4 = r["AuxVar4"].ToString();
                oAdcDoc.AuxVar5 = r["AuxVar5"].ToString();
                oAdcDoc.AuxVar6 = r["AuxVar6"].ToString();
                oAdcDoc.AuxVar7 = r["AuxVar7"].ToString();
                oAdcDoc.AuxVar8 = r["AuxVar8"].ToString();
                oAdcDoc.AuxVar9 = r["AuxVar9"].ToString();
                oAdcDoc.AuxVar10 = r["AuxVar10"].ToString();
                oAdcDoc.AuxVar11 = r["AuxVar11"].ToString();
                oAdcDoc.AuxVar12 = r["AuxVar12"].ToString();
                try
                {
                    oAdcDoc.AuxFec1 = DateTime.Parse(r["AuxFec1"].ToString());
                }
                catch
                {
                    oAdcDoc.AuxFec1 = new DateTime(1900, 1, 1, 0, 0, 0);
                }
                try
                {
                    oAdcDoc.AuxFec2 = DateTime.Parse(r["AuxFec2"].ToString());
                }
                catch
                {
                    oAdcDoc.AuxFec2 = new DateTime(1900, 1, 1, 0, 0, 0);
                }
                try
                {
                    oAdcDoc.AuxFec3 = DateTime.Parse(r["AuxFec3"].ToString());
                }
                catch
                {
                    oAdcDoc.AuxFec3 = new DateTime(1900, 1, 1, 0, 0, 0);
                }
                oAdcDoc.AuxLog1 = r["AuxLog1"].ToString();
                oAdcDoc.AuxLog2 = r["AuxLog2"].ToString();
                oAdcDoc.AuxLog3 = r["AuxLog3"].ToString();
                oAdcDoc.AuxNum1 = System.Decimal.Parse("0" + r["AuxNum1"].ToString());
                oAdcDoc.AuxNum2 = System.Decimal.Parse("0" + r["AuxNum2"].ToString());
                oAdcDoc.AuxNum3 = System.Decimal.Parse("0" + r["AuxNum3"].ToString());
                oAdcDoc.AuxNum4 = System.Decimal.Parse("0" + r["AuxNum4"].ToString());
                oAdcDoc.AuxNum5 = System.Decimal.Parse("0" + r["AuxNum5"].ToString());
                oAdcDoc.AuxNum6 = System.Decimal.Parse("0" + r["AuxNum6"].ToString());
                oAdcDoc.AuxNum7 = System.Decimal.Parse("0" + r["AuxNum7"].ToString());
                oAdcDoc.AuxNum8 = System.Decimal.Parse("0" + r["AuxNum8"].ToString());
                oAdcDoc.AuxNum9 = System.Decimal.Parse("0" + r["AuxNum9"].ToString());
                oAdcDoc.AuxNum10 = System.Decimal.Parse("0" + r["AuxNum10"].ToString());
                oAdcDoc.AuxNum11 = System.Decimal.Parse("0" + r["AuxNum11"].ToString());
                oAdcDoc.AuxNum12 = System.Decimal.Parse("0" + r["AuxNum12"].ToString());
                try
                {
                    oAdcDoc.doc_Anticipo = System.Boolean.Parse(r["doc_Anticipo"].ToString());
                }
                catch
                {
                    oAdcDoc.doc_Anticipo = false;
                }
                try
                {
                    oAdcDoc.Consolidar = System.Boolean.Parse(r["Consolidar"].ToString());
                }
                catch
                {
                    oAdcDoc.Consolidar = false;
                }
                oAdcDoc.TipDocConsolida = r["TipDocConsolida"].ToString();
                oAdcDoc.NroDocConsolida = System.Decimal.Parse("0" + r["NroDocConsolida"].ToString());
                try
                {
                    oAdcDoc.Contabilizar = System.Boolean.Parse(r["Contabilizar"].ToString());
                }
                catch
                {
                    oAdcDoc.Contabilizar = false;
                }
                oAdcDoc.ProductoProduccion = r["ProductoProduccion"].ToString();
                oAdcDoc.Mesero = r["Mesero"].ToString();
                oAdcDoc.BaseImp1 = System.Decimal.Parse("0" + r["BaseImp1"].ToString());
                oAdcDoc.BaseImp2 = System.Decimal.Parse("0" + r["BaseImp2"].ToString());
                oAdcDoc.BaseImp3 = System.Decimal.Parse("0" + r["BaseImp3"].ToString());
                oAdcDoc.PorcImp1 = System.Decimal.Parse("0" + r["PorcImp1"].ToString());
                oAdcDoc.PorcImp2 = System.Decimal.Parse("0" + r["PorcImp2"].ToString());
                oAdcDoc.PorcImp3 = System.Decimal.Parse("0" + r["PorcImp3"].ToString());
                oAdcDoc.ValorImp1 = System.Decimal.Parse("0" + r["ValorImp1"].ToString());
                oAdcDoc.ValorImp2 = System.Decimal.Parse("0" + r["ValorImp2"].ToString());
                oAdcDoc.ValorImp3 = System.Decimal.Parse("0" + r["ValorImp3"].ToString());
                oAdcDoc.Ocupantes = System.Decimal.Parse("0" + r["Ocupantes"].ToString());
                oAdcDoc.UbicaMesa = r["UbicaMesa"].ToString();
                oAdcDoc.PuntoVta = r["PuntoVta"].ToString();
                oAdcDoc.doc_anio = System.Int32.Parse("0" + r["doc_anio"].ToString());
                oAdcDoc.doc_mes = System.Int32.Parse("0" + r["doc_mes"].ToString());
                oAdcDoc.doc_dia = System.Int32.Parse("0" + r["doc_dia"].ToString());
                try
                {
                    oAdcDoc.Autorizado = System.Boolean.Parse(r["Autorizado"].ToString());
                }
                catch
                {
                    oAdcDoc.Autorizado = false;
                }
                oAdcDoc.MotivoAnulacion = r["MotivoAnulacion"].ToString();
                try
                {
                    oAdcDoc.sev_DeLiq = System.Boolean.Parse(r["sev_DeLiq"].ToString());
                }
                catch
                {
                    oAdcDoc.sev_DeLiq = false;
                }
                oAdcDoc.Cobranza = r["Cobranza"].ToString();
                oAdcDoc.tra_inmediato = System.Decimal.Parse("0" + r["tra_inmediato"].ToString());
                oAdcDoc.IdClaveDocDespacho = System.Decimal.Parse("0" + r["IdClaveDocDespacho"].ToString());
                oAdcDoc.Doc_mensaje = r["Doc_mensaje"].ToString();
                try
                {
                    oAdcDoc.Doc_FecGraba = DateTime.Parse(r["Doc_FecGraba"].ToString());
                }
                catch
                {
                    oAdcDoc.Doc_FecGraba = new DateTime(1900, 1, 1, 0, 0, 0);
                }
                try
                {
                    oAdcDoc.AuxFec4 = DateTime.Parse(r["AuxFec4"].ToString());
                }
                catch
                {
                    oAdcDoc.AuxFec4 = new DateTime(1900, 1, 1, 0, 0, 0);
                }
                try
                {
                    oAdcDoc.AuxFec5 = DateTime.Parse(r["AuxFec5"].ToString());
                }
                catch
                {
                    oAdcDoc.AuxFec5 = new DateTime(1900, 1, 1, 0, 0, 0);
                }
                oAdcDoc.AuxLog4 = r["AuxLog4"].ToString();
                oAdcDoc.AuxLog5 = r["AuxLog5"].ToString();
                oAdcDoc.NroCtrbuyteEspecial = System.Decimal.Parse("0" + r["NroCtrbuyteEspecial"].ToString());
                oAdcDoc.claveSri = r["claveSri"].ToString();
                oAdcDoc.estadoSri = r["estadoSri"].ToString();
                oAdcDoc.guiaRemision = r["guiaRemision"].ToString();
                oAdcDoc.NroAutorizacionSri = r["NroAutorizacionSri"].ToString();
                oAdcDoc.fechaAutorizacion = r["fechaAutorizacion"].ToString();
                oAdcDoc.tipoEmision = System.Int32.Parse("0" + r["tipoEmision"].ToString());
                oAdcDoc.rutaTransporte = r["rutaTransporte"].ToString();
                oAdcDoc.codEstabDestino = r["codEstabDestino"].ToString();
                oAdcDoc.docAduaneroUnico = r["docAduaneroUnico"].ToString();
                oAdcDoc.dirPartida = r["dirPartida"].ToString();
                oAdcDoc.codClienteFinal = r["codClienteFinal"].ToString();
                oAdcDoc.nomClienteFinal = r["nomClienteFinal"].ToString();
                oAdcDoc.AutorizadoFecha = r["AutorizadoFecha"].ToString();
                oAdcDoc.AutorizadoPor = r["AutorizadoPor"].ToString();
                //
                return oAdcDoc;
            }
            //
            // asigna un objeto AdcDoc a la fila indicada
            private static void AdcDoc2Row(AdcDocComp oAdcDoc, DataRow r)
            {
                // asigna un objeto AdcDoc al dataRow indicado
                r["Doc_sucursal"] = oAdcDoc.Doc_sucursal;
                r["Doc_Bodega"] = oAdcDoc.Doc_Bodega;
                r["Opc_documento"] = oAdcDoc.Opc_documento;
                r["Doc_numero"] = oAdcDoc.Doc_numero;
                r["Doc_docnombre"] = oAdcDoc.Doc_docnombre;
                r["Doc_TipoDoc"] = oAdcDoc.Doc_TipoDoc;
                r["Doc_DocSop"] = oAdcDoc.Doc_DocSop;
                r["Doc_NumSop"] = oAdcDoc.Doc_NumSop;
                r["Doc_fecha"] = oAdcDoc.Doc_fecha;
                r["Doc_Hora"] = oAdcDoc.Doc_Hora;
                r["Doc_extension"] = oAdcDoc.Doc_extension;
                r["Doc_codper"] = oAdcDoc.Doc_codper;
                r["Doc_codusu"] = oAdcDoc.Doc_codusu;
                r["Doc_venabre"] = oAdcDoc.Doc_venabre;
                r["Doc_porceniva"] = oAdcDoc.Doc_porceniva;
                r["Doc_valoriva"] = oAdcDoc.Doc_valoriva;
                r["Doc_totciva"] = oAdcDoc.Doc_totciva;
                r["Doc_totsiva"] = oAdcDoc.Doc_totsiva;
                r["Doc_nombredes1"] = oAdcDoc.Doc_nombredes1;
                r["Doc_nombredes2"] = oAdcDoc.Doc_nombredes2;
                r["Doc_nombredes3"] = oAdcDoc.Doc_nombredes3;
                r["Doc_nombredes4"] = oAdcDoc.Doc_nombredes4;
                r["Doc_porcendes1"] = oAdcDoc.Doc_porcendes1;
                r["Doc_porcendes2"] = oAdcDoc.Doc_porcendes2;
                r["Doc_porcendes3"] = oAdcDoc.Doc_porcendes3;
                r["Doc_porcendes4"] = oAdcDoc.Doc_porcendes4;
                r["Doc_valordes1"] = oAdcDoc.Doc_valordes1;
                r["Doc_valordes2"] = oAdcDoc.Doc_valordes2;
                r["Doc_valordes3"] = oAdcDoc.Doc_valordes3;
                r["Doc_valordes4"] = oAdcDoc.Doc_valordes4;
                r["Doc_valor"] = oAdcDoc.Doc_valor;
                r["Doc_valorabon"] = oAdcDoc.Doc_valorabon;
                r["Doc_detalle"] = oAdcDoc.Doc_detalle;
                r["Doc_NombreImp"] = oAdcDoc.Doc_NombreImp;
                r["Doc_CiRuc"] = oAdcDoc.Doc_CiRuc;
                r["Doc_Direccion"] = oAdcDoc.Doc_Direccion;
                r["Doc_Telefono1"] = oAdcDoc.Doc_Telefono1;
                r["Doc_Telefono2"] = oAdcDoc.Doc_Telefono2;
                r["Doc_DepDes"] = oAdcDoc.Doc_DepDes;
                r["Doc_TotDesArt"] = oAdcDoc.Doc_TotDesArt;
                r["Doc_TotDesSer"] = oAdcDoc.Doc_TotDesSer;
                r["Doc_TotArtCIva"] = oAdcDoc.Doc_TotArtCIva;
                r["Doc_TotArtSIva"] = oAdcDoc.Doc_TotArtSIva;
                r["Doc_TotSerCIva"] = oAdcDoc.Doc_TotSerCIva;
                r["Doc_TotSerSIva"] = oAdcDoc.Doc_TotSerSIva;
                r["Doc_TotAcf"] = oAdcDoc.Doc_TotAcf;
                r["Doc_Contado"] = oAdcDoc.Doc_Contado;
                r["Doc_FechaEfe"] = oAdcDoc.Doc_FechaEfe;
                r["Doc_Estado"] = oAdcDoc.Doc_Estado;
                r["Doc_Oculto"] = oAdcDoc.Doc_Oculto;
                r["Doc_Contabilidad"] = oAdcDoc.Doc_Contabilidad;
                r["Doc_Banco"] = oAdcDoc.Doc_Banco;
                r["Doc_Inventario"] = oAdcDoc.Doc_Inventario;
                r["Doc_Ventas"] = oAdcDoc.Doc_Ventas;
                r["Doc_Compras"] = oAdcDoc.Doc_Compras;
                r["Doc_Activo"] = oAdcDoc.Doc_Activo;
                r["Doc_Adicional1"] = oAdcDoc.Doc_Adicional1;
                r["Doc_Adicional2"] = oAdcDoc.Doc_Adicional2;
                r["Doc_NumeroExterno"] = oAdcDoc.Doc_NumeroExterno;
                r["Doc_NroIdDoc"] = oAdcDoc.Doc_NroIdDoc;
                r["Doc_SaldoActualCli"] = oAdcDoc.Doc_SaldoActualCli;
                r["Doc_SaldoFinalCli"] = oAdcDoc.Doc_SaldoFinalCli;
                r["Doc_FechaModifica"] = oAdcDoc.Doc_FechaModifica;
                r["Doc_CentroCosto"] = oAdcDoc.Doc_CentroCosto;
                r["IdClaveDoc"] = oAdcDoc.IdClaveDoc;
                r["IdClaveDocSop"] = oAdcDoc.IdClaveDocSop;
                r["doc_SucursalDestino"] = oAdcDoc.doc_SucursalDestino;
                r["doc_SucDestino"] = oAdcDoc.doc_SucDestino;
                r["doc_BodDestino"] = oAdcDoc.doc_BodDestino;
                r["Doc_NroLoteDoc"] = oAdcDoc.Doc_NroLoteDoc;
                r["doc_BancoOrigen"] = oAdcDoc.doc_BancoOrigen;
                r["doc_BancoDestino"] = oAdcDoc.doc_BancoDestino;
                r["doc_NumeroCheque"] = oAdcDoc.doc_NumeroCheque;
                r["doc_Aceptado"] = oAdcDoc.doc_Aceptado;
                r["Doc_Liquidado"] = oAdcDoc.Doc_Liquidado;
                r["Doc_CobraCheque"] = oAdcDoc.Doc_CobraCheque;
                r["doc_TotDesCIva"] = oAdcDoc.doc_TotDesCIva;
                r["doc_TotDesSiva"] = oAdcDoc.doc_TotDesSiva;
                r["Periodo1"] = oAdcDoc.Periodo1;
                r["Periodo2"] = oAdcDoc.Periodo2;
                r["FacDesde"] = oAdcDoc.FacDesde;
                r["FacHasta"] = oAdcDoc.FacHasta;
                r["Habitacion"] = oAdcDoc.Habitacion;
                r["Mesa"] = oAdcDoc.Mesa;
                r["TipoPeriodo"] = oAdcDoc.TipoPeriodo;
                r["Adi_NroAutSri"] = oAdcDoc.Adi_NroAutSri;
                r["Adi_SustTrib"] = oAdcDoc.Adi_SustTrib;
                r["Adi_TipoDocSri"] = oAdcDoc.Adi_TipoDocSri;
                r["Adi_SNDevIva"] = oAdcDoc.Adi_SNDevIva;
                r["Adi_FechContab"] = oAdcDoc.Adi_FechContab;
                r["Adi_CodigoNSR"] = oAdcDoc.Adi_CodigoNSR;
                r["Dia_Status"] = oAdcDoc.Dia_Status;
                r["Moneda"] = oAdcDoc.Moneda;
                r["Paridad"] = oAdcDoc.Paridad;
                r["ParidadBiMoneda"] = oAdcDoc.ParidadBiMoneda;
                r["PaisDestino"] = oAdcDoc.PaisDestino;
                r["ProvinciaDestino"] = oAdcDoc.ProvinciaDestino;
                r["CiudadDestino"] = oAdcDoc.CiudadDestino;
                r["DireccionDestino"] = oAdcDoc.DireccionDestino;
                r["Destinatario"] = oAdcDoc.Destinatario;
                r["RucDestinatario"] = oAdcDoc.RucDestinatario;
                r["ContactoDestino"] = oAdcDoc.ContactoDestino;
                r["FecIniTransporte"] = oAdcDoc.FecIniTransporte;
                r["FecFinTransporte"] = oAdcDoc.FecFinTransporte;
                r["Transportista"] = oAdcDoc.Transportista;
                r["RucTransportista"] = oAdcDoc.RucTransportista;
                r["TipoTransporte"] = oAdcDoc.TipoTransporte;
                r["EsContable"] = oAdcDoc.EsContable;
                r["AuxVar1"] = oAdcDoc.AuxVar1;
                r["AuxVar2"] = oAdcDoc.AuxVar2;
                r["AuxVar3"] = oAdcDoc.AuxVar3;
                r["AuxVar4"] = oAdcDoc.AuxVar4;
                r["AuxVar5"] = oAdcDoc.AuxVar5;
                r["AuxVar6"] = oAdcDoc.AuxVar6;
                r["AuxVar7"] = oAdcDoc.AuxVar7;
                r["AuxVar8"] = oAdcDoc.AuxVar8;
                r["AuxVar9"] = oAdcDoc.AuxVar9;
                r["AuxVar10"] = oAdcDoc.AuxVar10;
                r["AuxVar11"] = oAdcDoc.AuxVar11;
                r["AuxVar12"] = oAdcDoc.AuxVar12;
                r["AuxFec1"] = oAdcDoc.AuxFec1;
                r["AuxFec2"] = oAdcDoc.AuxFec2;
                r["AuxFec3"] = oAdcDoc.AuxFec3;
                r["AuxLog1"] = oAdcDoc.AuxLog1;
                r["AuxLog2"] = oAdcDoc.AuxLog2;
                r["AuxLog3"] = oAdcDoc.AuxLog3;
                r["AuxNum1"] = oAdcDoc.AuxNum1;
                r["AuxNum2"] = oAdcDoc.AuxNum2;
                r["AuxNum3"] = oAdcDoc.AuxNum3;
                r["AuxNum4"] = oAdcDoc.AuxNum4;
                r["AuxNum5"] = oAdcDoc.AuxNum5;
                r["AuxNum6"] = oAdcDoc.AuxNum6;
                r["AuxNum7"] = oAdcDoc.AuxNum7;
                r["AuxNum8"] = oAdcDoc.AuxNum8;
                r["AuxNum9"] = oAdcDoc.AuxNum9;
                r["AuxNum10"] = oAdcDoc.AuxNum10;
                r["AuxNum11"] = oAdcDoc.AuxNum11;
                r["AuxNum12"] = oAdcDoc.AuxNum12;
                r["doc_Anticipo"] = oAdcDoc.doc_Anticipo;
                r["Consolidar"] = oAdcDoc.Consolidar;
                r["TipDocConsolida"] = oAdcDoc.TipDocConsolida;
                r["NroDocConsolida"] = oAdcDoc.NroDocConsolida;
                r["Contabilizar"] = oAdcDoc.Contabilizar;
                r["ProductoProduccion"] = oAdcDoc.ProductoProduccion;
                r["Mesero"] = oAdcDoc.Mesero;
                r["BaseImp1"] = oAdcDoc.BaseImp1;
                r["BaseImp2"] = oAdcDoc.BaseImp2;
                r["BaseImp3"] = oAdcDoc.BaseImp3;
                r["PorcImp1"] = oAdcDoc.PorcImp1;
                r["PorcImp2"] = oAdcDoc.PorcImp2;
                r["PorcImp3"] = oAdcDoc.PorcImp3;
                r["ValorImp1"] = oAdcDoc.ValorImp1;
                r["ValorImp2"] = oAdcDoc.ValorImp2;
                r["ValorImp3"] = oAdcDoc.ValorImp3;
                r["Ocupantes"] = oAdcDoc.Ocupantes;
                r["UbicaMesa"] = oAdcDoc.UbicaMesa;
                r["PuntoVta"] = oAdcDoc.PuntoVta;
                r["doc_anio"] = oAdcDoc.doc_anio;
                r["doc_mes"] = oAdcDoc.doc_mes;
                r["doc_dia"] = oAdcDoc.doc_dia;
                r["Autorizado"] = oAdcDoc.Autorizado;
                r["MotivoAnulacion"] = oAdcDoc.MotivoAnulacion;
                r["sev_DeLiq"] = oAdcDoc.sev_DeLiq;
                r["Cobranza"] = oAdcDoc.Cobranza;
                r["tra_inmediato"] = oAdcDoc.tra_inmediato;
                r["IdClaveDocDespacho"] = oAdcDoc.IdClaveDocDespacho;
                r["Doc_mensaje"] = oAdcDoc.Doc_mensaje;
                r["Doc_FecGraba"] = oAdcDoc.Doc_FecGraba;
                r["AuxFec4"] = oAdcDoc.AuxFec4;
                r["AuxFec5"] = oAdcDoc.AuxFec5;
                r["AuxLog4"] = oAdcDoc.AuxLog4;
                r["AuxLog5"] = oAdcDoc.AuxLog5;
                r["NroCtrbuyteEspecial"] = oAdcDoc.NroCtrbuyteEspecial;
                r["claveSri"] = oAdcDoc.claveSri;
                r["estadoSri"] = oAdcDoc.estadoSri;
                r["guiaRemision"] = oAdcDoc.guiaRemision;
                r["NroAutorizacionSri"] = oAdcDoc.NroAutorizacionSri;
                r["fechaAutorizacion"] = oAdcDoc.fechaAutorizacion;
                r["tipoEmision"] = oAdcDoc.tipoEmision;
                r["rutaTransporte"] = oAdcDoc.rutaTransporte;
                r["codEstabDestino"] = oAdcDoc.codEstabDestino;
                r["docAduaneroUnico"] = oAdcDoc.docAduaneroUnico;
                r["dirPartida"] = oAdcDoc.dirPartida;
                r["codClienteFinal"] = oAdcDoc.codClienteFinal;
                r["nomClienteFinal"] = oAdcDoc.nomClienteFinal;
                r["AutorizadoFecha"] = oAdcDoc.AutorizadoFecha;
                r["AutorizadoPor"] = oAdcDoc.AutorizadoPor;
            }
            //
            // crea una nueva fila y la asigna a un objeto AdcDoc
            private static void nuevoAdcDoc(DataTable dt, AdcDocComp oAdcDoc)
            {
                // Crear un nuevo AdcDoc
                DataRow dr = dt.NewRow();
                AdcDocComp oA = row2AdcDoc(dr);
                //
                oA.Doc_sucursal = oAdcDoc.Doc_sucursal;
                oA.Doc_Bodega = oAdcDoc.Doc_Bodega;
                oA.Opc_documento = oAdcDoc.Opc_documento;
                oA.Doc_numero = oAdcDoc.Doc_numero;
                oA.Doc_docnombre = oAdcDoc.Doc_docnombre;
                oA.Doc_TipoDoc = oAdcDoc.Doc_TipoDoc;
                oA.Doc_DocSop = oAdcDoc.Doc_DocSop;
                oA.Doc_NumSop = oAdcDoc.Doc_NumSop;
                oA.Doc_fecha = oAdcDoc.Doc_fecha;
                oA.Doc_Hora = oAdcDoc.Doc_Hora;
                oA.Doc_extension = oAdcDoc.Doc_extension;
                oA.Doc_codper = oAdcDoc.Doc_codper;
                oA.Doc_codusu = oAdcDoc.Doc_codusu;
                oA.Doc_venabre = oAdcDoc.Doc_venabre;
                oA.Doc_porceniva = oAdcDoc.Doc_porceniva;
                oA.Doc_valoriva = oAdcDoc.Doc_valoriva;
                oA.Doc_totciva = oAdcDoc.Doc_totciva;
                oA.Doc_totsiva = oAdcDoc.Doc_totsiva;
                oA.Doc_nombredes1 = oAdcDoc.Doc_nombredes1;
                oA.Doc_nombredes2 = oAdcDoc.Doc_nombredes2;
                oA.Doc_nombredes3 = oAdcDoc.Doc_nombredes3;
                oA.Doc_nombredes4 = oAdcDoc.Doc_nombredes4;
                oA.Doc_porcendes1 = oAdcDoc.Doc_porcendes1;
                oA.Doc_porcendes2 = oAdcDoc.Doc_porcendes2;
                oA.Doc_porcendes3 = oAdcDoc.Doc_porcendes3;
                oA.Doc_porcendes4 = oAdcDoc.Doc_porcendes4;
                oA.Doc_valordes1 = oAdcDoc.Doc_valordes1;
                oA.Doc_valordes2 = oAdcDoc.Doc_valordes2;
                oA.Doc_valordes3 = oAdcDoc.Doc_valordes3;
                oA.Doc_valordes4 = oAdcDoc.Doc_valordes4;
                oA.Doc_valor = oAdcDoc.Doc_valor;
                oA.Doc_valorabon = oAdcDoc.Doc_valorabon;
                oA.Doc_detalle = oAdcDoc.Doc_detalle;
                oA.Doc_NombreImp = oAdcDoc.Doc_NombreImp;
                oA.Doc_CiRuc = oAdcDoc.Doc_CiRuc;
                oA.Doc_Direccion = oAdcDoc.Doc_Direccion;
                oA.Doc_Telefono1 = oAdcDoc.Doc_Telefono1;
                oA.Doc_Telefono2 = oAdcDoc.Doc_Telefono2;
                oA.Doc_DepDes = oAdcDoc.Doc_DepDes;
                oA.Doc_TotDesArt = oAdcDoc.Doc_TotDesArt;
                oA.Doc_TotDesSer = oAdcDoc.Doc_TotDesSer;
                oA.Doc_TotArtCIva = oAdcDoc.Doc_TotArtCIva;
                oA.Doc_TotArtSIva = oAdcDoc.Doc_TotArtSIva;
                oA.Doc_TotSerCIva = oAdcDoc.Doc_TotSerCIva;
                oA.Doc_TotSerSIva = oAdcDoc.Doc_TotSerSIva;
                oA.Doc_TotAcf = oAdcDoc.Doc_TotAcf;
                oA.Doc_Contado = oAdcDoc.Doc_Contado;
                oA.Doc_FechaEfe = oAdcDoc.Doc_FechaEfe;
                oA.Doc_Estado = oAdcDoc.Doc_Estado;
                oA.Doc_Oculto = oAdcDoc.Doc_Oculto;
                oA.Doc_Contabilidad = oAdcDoc.Doc_Contabilidad;
                oA.Doc_Banco = oAdcDoc.Doc_Banco;
                oA.Doc_Inventario = oAdcDoc.Doc_Inventario;
                oA.Doc_Ventas = oAdcDoc.Doc_Ventas;
                oA.Doc_Compras = oAdcDoc.Doc_Compras;
                oA.Doc_Activo = oAdcDoc.Doc_Activo;
                oA.Doc_Adicional1 = oAdcDoc.Doc_Adicional1;
                oA.Doc_Adicional2 = oAdcDoc.Doc_Adicional2;
                oA.Doc_NumeroExterno = oAdcDoc.Doc_NumeroExterno;
                oA.Doc_NroIdDoc = oAdcDoc.Doc_NroIdDoc;
                oA.Doc_SaldoActualCli = oAdcDoc.Doc_SaldoActualCli;
                oA.Doc_SaldoFinalCli = oAdcDoc.Doc_SaldoFinalCli;
                oA.Doc_FechaModifica = oAdcDoc.Doc_FechaModifica;
                oA.Doc_CentroCosto = oAdcDoc.Doc_CentroCosto;
                oA.IdClaveDoc = oAdcDoc.IdClaveDoc;
                oA.IdClaveDocSop = oAdcDoc.IdClaveDocSop;
                oA.doc_SucursalDestino = oAdcDoc.doc_SucursalDestino;
                oA.doc_SucDestino = oAdcDoc.doc_SucDestino;
                oA.doc_BodDestino = oAdcDoc.doc_BodDestino;
                oA.Doc_NroLoteDoc = oAdcDoc.Doc_NroLoteDoc;
                oA.doc_BancoOrigen = oAdcDoc.doc_BancoOrigen;
                oA.doc_BancoDestino = oAdcDoc.doc_BancoDestino;
                oA.doc_NumeroCheque = oAdcDoc.doc_NumeroCheque;
                oA.doc_Aceptado = oAdcDoc.doc_Aceptado;
                oA.Doc_Liquidado = oAdcDoc.Doc_Liquidado;
                oA.Doc_CobraCheque = oAdcDoc.Doc_CobraCheque;
                oA.doc_TotDesCIva = oAdcDoc.doc_TotDesCIva;
                oA.doc_TotDesSiva = oAdcDoc.doc_TotDesSiva;
                oA.Periodo1 = oAdcDoc.Periodo1;
                oA.Periodo2 = oAdcDoc.Periodo2;
                oA.FacDesde = oAdcDoc.FacDesde;
                oA.FacHasta = oAdcDoc.FacHasta;
                oA.Habitacion = oAdcDoc.Habitacion;
                oA.Mesa = oAdcDoc.Mesa;
                oA.TipoPeriodo = oAdcDoc.TipoPeriodo;
                oA.Adi_NroAutSri = oAdcDoc.Adi_NroAutSri;
                oA.Adi_SustTrib = oAdcDoc.Adi_SustTrib;
                oA.Adi_TipoDocSri = oAdcDoc.Adi_TipoDocSri;
                oA.Adi_SNDevIva = oAdcDoc.Adi_SNDevIva;
                oA.Adi_FechContab = oAdcDoc.Adi_FechContab;
                oA.Adi_CodigoNSR = oAdcDoc.Adi_CodigoNSR;
                oA.Dia_Status = oAdcDoc.Dia_Status;
                oA.Moneda = oAdcDoc.Moneda;
                oA.Paridad = oAdcDoc.Paridad;
                oA.ParidadBiMoneda = oAdcDoc.ParidadBiMoneda;
                oA.PaisDestino = oAdcDoc.PaisDestino;
                oA.ProvinciaDestino = oAdcDoc.ProvinciaDestino;
                oA.CiudadDestino = oAdcDoc.CiudadDestino;
                oA.DireccionDestino = oAdcDoc.DireccionDestino;
                oA.Destinatario = oAdcDoc.Destinatario;
                oA.RucDestinatario = oAdcDoc.RucDestinatario;
                oA.ContactoDestino = oAdcDoc.ContactoDestino;
                oA.FecIniTransporte = oAdcDoc.FecIniTransporte;
                oA.FecFinTransporte = oAdcDoc.FecFinTransporte;
                oA.Transportista = oAdcDoc.Transportista;
                oA.RucTransportista = oAdcDoc.RucTransportista;
                oA.TipoTransporte = oAdcDoc.TipoTransporte;
                oA.EsContable = oAdcDoc.EsContable;
                oA.AuxVar1 = oAdcDoc.AuxVar1;
                oA.AuxVar2 = oAdcDoc.AuxVar2;
                oA.AuxVar3 = oAdcDoc.AuxVar3;
                oA.AuxVar4 = oAdcDoc.AuxVar4;
                oA.AuxVar5 = oAdcDoc.AuxVar5;
                oA.AuxVar6 = oAdcDoc.AuxVar6;
                oA.AuxVar7 = oAdcDoc.AuxVar7;
                oA.AuxVar8 = oAdcDoc.AuxVar8;
                oA.AuxVar9 = oAdcDoc.AuxVar9;
                oA.AuxVar10 = oAdcDoc.AuxVar10;
                oA.AuxVar11 = oAdcDoc.AuxVar11;
                oA.AuxVar12 = oAdcDoc.AuxVar12;
                oA.AuxFec1 = oAdcDoc.AuxFec1;
                oA.AuxFec2 = oAdcDoc.AuxFec2;
                oA.AuxFec3 = oAdcDoc.AuxFec3;
                oA.AuxLog1 = oAdcDoc.AuxLog1;
                oA.AuxLog2 = oAdcDoc.AuxLog2;
                oA.AuxLog3 = oAdcDoc.AuxLog3;
                oA.AuxNum1 = oAdcDoc.AuxNum1;
                oA.AuxNum2 = oAdcDoc.AuxNum2;
                oA.AuxNum3 = oAdcDoc.AuxNum3;
                oA.AuxNum4 = oAdcDoc.AuxNum4;
                oA.AuxNum5 = oAdcDoc.AuxNum5;
                oA.AuxNum6 = oAdcDoc.AuxNum6;
                oA.AuxNum7 = oAdcDoc.AuxNum7;
                oA.AuxNum8 = oAdcDoc.AuxNum8;
                oA.AuxNum9 = oAdcDoc.AuxNum9;
                oA.AuxNum10 = oAdcDoc.AuxNum10;
                oA.AuxNum11 = oAdcDoc.AuxNum11;
                oA.AuxNum12 = oAdcDoc.AuxNum12;
                oA.doc_Anticipo = oAdcDoc.doc_Anticipo;
                oA.Consolidar = oAdcDoc.Consolidar;
                oA.TipDocConsolida = oAdcDoc.TipDocConsolida;
                oA.NroDocConsolida = oAdcDoc.NroDocConsolida;
                oA.Contabilizar = oAdcDoc.Contabilizar;
                oA.ProductoProduccion = oAdcDoc.ProductoProduccion;
                oA.Mesero = oAdcDoc.Mesero;
                oA.BaseImp1 = oAdcDoc.BaseImp1;
                oA.BaseImp2 = oAdcDoc.BaseImp2;
                oA.BaseImp3 = oAdcDoc.BaseImp3;
                oA.PorcImp1 = oAdcDoc.PorcImp1;
                oA.PorcImp2 = oAdcDoc.PorcImp2;
                oA.PorcImp3 = oAdcDoc.PorcImp3;
                oA.ValorImp1 = oAdcDoc.ValorImp1;
                oA.ValorImp2 = oAdcDoc.ValorImp2;
                oA.ValorImp3 = oAdcDoc.ValorImp3;
                oA.Ocupantes = oAdcDoc.Ocupantes;
                oA.UbicaMesa = oAdcDoc.UbicaMesa;
                oA.PuntoVta = oAdcDoc.PuntoVta;
                oA.doc_anio = oAdcDoc.doc_anio;
                oA.doc_mes = oAdcDoc.doc_mes;
                oA.doc_dia = oAdcDoc.doc_dia;
                oA.Autorizado = oAdcDoc.Autorizado;
                oA.MotivoAnulacion = oAdcDoc.MotivoAnulacion;
                oA.sev_DeLiq = oAdcDoc.sev_DeLiq;
                oA.Cobranza = oAdcDoc.Cobranza;
                oA.tra_inmediato = oAdcDoc.tra_inmediato;
                oA.IdClaveDocDespacho = oAdcDoc.IdClaveDocDespacho;
                oA.Doc_mensaje = oAdcDoc.Doc_mensaje;
                oA.Doc_FecGraba = oAdcDoc.Doc_FecGraba;
                oA.AuxFec4 = oAdcDoc.AuxFec4;
                oA.AuxFec5 = oAdcDoc.AuxFec5;
                oA.AuxLog4 = oAdcDoc.AuxLog4;
                oA.AuxLog5 = oAdcDoc.AuxLog5;
                oA.NroCtrbuyteEspecial = oAdcDoc.NroCtrbuyteEspecial;
                oA.claveSri = oAdcDoc.claveSri;
                oA.estadoSri = oAdcDoc.estadoSri;
                oA.guiaRemision = oAdcDoc.guiaRemision;
                oA.NroAutorizacionSri = oAdcDoc.NroAutorizacionSri;
                oA.fechaAutorizacion = oAdcDoc.fechaAutorizacion;
                oA.tipoEmision = oAdcDoc.tipoEmision;
                oA.rutaTransporte = oAdcDoc.rutaTransporte;
                oA.codEstabDestino = oAdcDoc.codEstabDestino;
                oA.docAduaneroUnico = oAdcDoc.docAduaneroUnico;
                oA.dirPartida = oAdcDoc.dirPartida;
                oA.codClienteFinal = oAdcDoc.codClienteFinal;
                oA.nomClienteFinal = oAdcDoc.nomClienteFinal;
                oA.AutorizadoFecha = oAdcDoc.AutorizadoFecha;
                oA.AutorizadoPor = oAdcDoc.AutorizadoPor;
                //
                AdcDoc2Row(oA, dr);
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
                // devuelve una tabla con los datos de la tabla AdcDoc
                SqlDataAdapter da;
                DataTable dt = new DataTable("AdcDoc");
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
            public static AdcDocComp Buscar(string sWhere)
            {
                // Busca en la tabla los datos indicados en el parámetro
                // el parámetro contendrá lo que se usará después del WHERE
                AdcDocComp oAdcDoc = null;
                SqlDataAdapter da;
                DataTable dt = new DataTable("AdcDoc");
                string sel = "SELECT * FROM AdcDoc WHERE " + sWhere;
                //
                da = new SqlDataAdapter(sel, cadenaConexion);
                da.Fill(dt);
                //
                if (dt.Rows.Count > 0)
                {
                    oAdcDoc = row2AdcDoc(dt.Rows[0]);
                }
                return oAdcDoc;
            }
            //
            public string Actualizar()
            {
                string sel = "SELECT * FROM AdcDoc WHERE doc_sucursal = '" + Doc_sucursal + "' and opc_documento = '" + Opc_documento + "' and idclavedoc = " + IdClaveDoc.ToString();
                return Actualizar(sel);
            }
            public string Actualizar(string sel)
            {
                // Actualiza los datos indicados
                // El parámetro, que es una cadena de selección, indicará el criterio de actualización
                //
                // En caso de error, devolverá la cadena empezando por ERROR.
                //SqlConnection cnn;
                if (IdClaveDoc == 0) return Crear();

                SqlDataAdapter da;
                DataTable dt = new DataTable("AdcDoc");
                da = new SqlDataAdapter(sel, cadenaConexion);
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
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
                    AdcDoc2Row(this, dt.Rows[0]);
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
            public string claveDuplica = "NSS";
            //
            public string Crear()
            {
                // Crear un nuevo registro
                // En caso de error, devolverá la cadena de error empezando por ERROR:.

                string codProveedor = "";
                if (DocDeProveedor) codProveedor = Doc_codper;
                controlNumeracion NumeracDoc = new controlNumeracion();
                idDocumento id = new idDocumento
                {
                    idClave = Convert.ToDouble(IdClaveDoc),
                    fecha = Doc_fecha,
                    Serie = Doc_NroIdDoc,
                    numero = Convert.ToDouble(Doc_numero),
                    Sucursal = Doc_sucursal,
                    Tipo = Opc_documento
                };
                if (!NumeracDoc.FijarNroDeDocumento("ADCDOC", autonumeracion, codProveedor, id, cadenaConexion)) return "NUMERO DUPLICADO";

                DataTable dt = new DataTable();
                IdClaveDoc = Convert.ToDecimal(id.idClave);
                Doc_numero = Convert.ToDecimal(id.numero);

                CadenaSelect = "SELECT * FROM AdcDoc WHERE doc_sucursal = '" + Doc_sucursal + "' and opc_documento = '" + Opc_documento + "' and idclavedoc = " + IdClaveDoc.ToString();
                SqlDataAdapter da = new SqlDataAdapter(CadenaSelect, cadenaConexion);
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.InsertCommand = cb.GetInsertCommand();
                try
                {
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    return "ERROR: " + ex.Message;
                }
                //
                nuevoAdcDoc(dt, this);
                //
                string resp = "";
                try
                {
                    da.Update(dt);
                    dt.AcceptChanges();
                    //String EMISION = "";
                    //if(Doc_TipoDoc == "EGR" || Doc_TipoDoc == "ING" || Doc_TipoDoc == "NDB" || Doc_TipoDoc == "NCB" || Doc_TipoDoc == "VIC" || Doc_TipoDoc == "VEC")
                    //{ EMISION = doc_BancoOrigen; }

                    NumeracDoc.guardarNumeroDocumento(id, cadenaConexion, "", codProveedor);
                    resp = "Se ha creado un nuevo AdcDoc";
                }
                catch (Exception ex)
                {
                    resp = "ERROR: " + ex.Message;
                }
                dt.Dispose();
                da.Dispose();
                NumeracDoc = null;
                return resp;
            }
            //
            public string Borrar()
            {
                string sel = "SELECT * FROM AdcDoc WHERE doc_sucursal = '" + Doc_sucursal + "' and opc_documento = '" + Opc_documento + "' and idclavedoc = " + IdClaveDoc.ToString();
                //
                return Borrar(sel);
            }
            public string Borrar(string sel)
            {
                // Borrar el registro al que apunta esta clase
                // En caso de error, devolverá la cadena de error empezando por ERROR:.
                SqlConnection cnn;
                SqlDataAdapter da;
                DataTable dt = new DataTable("AdcDoc");
                //
                cnn = new SqlConnection(cadenaConexion);
                da = new SqlDataAdapter(sel, cnn);
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                //
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.DeleteCommand = cb.GetDeleteCommand();
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
