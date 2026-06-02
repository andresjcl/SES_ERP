using System;
using System.Data;
using System.Data.SqlClient;

namespace ClassDoc
{
    public class AdcTraPro
    {
        private System.String _Doc_sucursal = "";
        private System.String _Doc_Bodega = "";
        private System.String _Opc_documento = "";
        private System.Decimal _Doc_numero = 0;
        private System.String _Tra_TipoDoc = "";
        private System.String _Tra_DocSop = "";
        private System.Decimal _Tra_NumSop = 0;
        private System.Decimal _Tra_numlinea = 0;
        private System.String _Tra_Codigo = "";
        private System.String _Tra_docotro = "";
        private System.Decimal _Tra_numotro = 0;
        private System.DateTime _Tra_fecha = new DateTime(1900, 1, 1);
        private System.String _Tra_nombre = "";
        private System.Decimal _Tra_cantidad = 0;
        private System.Decimal _Tra_costuni = 0;
        private System.Decimal _Tra_costtot = 0;
        private System.String _Tra_numprecio = "";
        private System.String _Tra_descdes = "";
        private System.Decimal _Tra_porcendes = 0;
        private System.Decimal _Tra_valordes = 0;
        private System.Decimal _Tra_valor = 0;
        private System.String _Tra_extension = "";
        private System.Boolean _Tra_sniva = false;
        private System.String _Tra_Individual = "";
        private System.String _Tra_quetipo = "";
        private System.Decimal _Tra_precuni = 0;
        private System.Decimal _Tra_prectot = 0;
        private System.String _Tra_DepDes = "";
        private System.Int16 _Tra_Estado = 0;
        private System.Int16 _Tra_Oculto = 0;
        private System.Int16 _Tra_Inventario = 0;
        private System.Int16 _Tra_Ventas = 0;
        private System.Int16 _Tra_Compras = 0;
        private System.Int16 _Tra_Activo = 0;
        private System.Decimal _Tra_Adicional1 = 0;
        private System.Decimal _Tra_Adicional2 = 0;
        private System.Decimal _Tra_piezas = 0;
        private System.String _Tra_medida = "";
        private System.Decimal _Tra_multiplo = 0;
        private System.DateTime _Tra_vence = new DateTime(1900, 1, 1);
        private System.String _tra_serie = "";
        private System.Decimal _IdClaveDoc = 0;
        private System.String _Tra_NroLote = "";
        private System.String _Tra_NroLoteDoc = "";
        private System.DateTime _Periodo1 = new DateTime(1900, 1, 1);
        private System.DateTime _Periodo2 = new DateTime(1900, 1, 1);
        private System.DateTime _FacDesde = new DateTime(1900, 1, 1);
        private System.DateTime _FacHasta = new DateTime(1900, 1, 1);
        private System.String _Habitacion = "";
        private System.String _Mesa = "";
        private System.String _TipoPeriodo = "";
        private System.Decimal _ord_numero = 0;
        private System.Decimal _NumeroHoras = 0;
        private System.Decimal _CostoHora = 0;
        private System.Decimal _CostoMatPrima = 0;
        private System.Decimal _PorcUtilidad = 0;
        private System.Decimal _CostosIndirectos = 0;
        private System.Decimal _CostosTerceros = 0;
        private System.String _ZonaProducto = "";
        private System.String _AuxVar1;
        private System.String _AuxVar2;
        private System.String _AuxVar3;
        private System.String _AuxVar4;
        private System.String _AuxVar5;
        private System.String _AuxVar6;
        private System.String _AuxVar7;
        private System.String _AuxVar8;
        private System.String _AuxVar9;
        private System.String _AuxVar10;
        private System.String _AuxVar11;
        private System.String _AuxVar12;
        private System.DateTime _AuxFec1 = new DateTime(1900, 1, 1);
        private System.DateTime _AuxFec2 = new DateTime(1900, 1, 1);
        private System.DateTime _AuxFec3 = new DateTime(1900, 1, 1);
        private System.String _AuxLog1 = "";
        private System.String _AuxLog2 = "";
        private System.String _AuxLog3 = "";
        private System.Decimal _AuxNum1;
        private System.Decimal _AuxNum2;
        private System.Decimal _AuxNum3;
        private System.Decimal _AuxNum4;
        private System.Decimal _AuxNum5;
        private System.Decimal _AuxNum6;
        private System.Decimal _AuxNum7;
        private System.Decimal _AuxNum8;
        private System.Decimal _AuxNum9;
        private System.Decimal _AuxNum10;
        private System.Decimal _AuxNum11;
        private System.Decimal _AuxNum12;
        private System.String _TipoCosto = "";
        private System.Boolean _Recosteo = false;
        private System.String _tra_costo = "";
        private System.String _tra_empleado = "";
        private System.String _tra_directorio = "";
        private System.String _tra_dia_proyecto = "";
        private System.String _tra_relacionado = "";
        private System.String _tra_codigoalterno = "";
        private System.Boolean _Tra_EsCuenta = false;
        private System.String _tra_producto = "";
        private System.String _tra_centroproduccion = "";
        private System.String _tra_centroDistribucion = "";
        private System.String _tra_proyecto = "";
        private System.Decimal _tra_peso = 0;
        private System.String _CodigoBase = "";
        private System.Decimal _Despacho = 0;
        private System.String _tra_boddestino = "";
        private System.String _tra_sucdestino = "";
        private System.String _Tra_Talla = "";
        private System.String _Tra_Color = "";
        private System.String _Tra_Dibujo = "";
        private System.String _Tra_Genero = "";
        private System.String _Tra_Modelo = "";
        private System.String _Tra_Despachado = "";
        private System.Int64 _Ramos = 0;
        private System.String _NroCaja = "";
        private System.String _TipCaja = "";
        private System.Int64 _CantCajas = 0;
        private System.Int64 _Largo = 0;
        private System.Int64 _TallXramo = 0;
        private System.Int64 _RamXcaja = 0;
        private System.Int64 _Tallos = 0;
        private System.Decimal _TotPeso = 0;
        private System.Decimal _Fulls = 0;
        private System.Int32 _tra_anio = 0;
        private System.Int32 _tra_mes = 0;
        private System.Int32 _tra_dia = 0;
        private System.String _HTS = "";
        private System.String _SGP = "";
        private System.String _Nandina = "";
        private System.String _DetalleItm = "";
        //
        // Este método se usará para ajustar los anchos de las propiedades
        private string ajustarAncho(string cadena, int ancho)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
            // devolver la cadena quitando los espacios en blanco
            // esto asegura que no se devolverá un tamaño mayor ni espacios "extras"
            return (cadena + sb.ToString()).Substring(0, ancho).Trim();
        }
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
        public System.String Tra_TipoDoc
        {
            get
            {
                return ajustarAncho(_Tra_TipoDoc, 3);
            }
            set
            {
                _Tra_TipoDoc = value;
            }
        }
        public System.String Tra_DocSop
        {
            get
            {
                return ajustarAncho(_Tra_DocSop, 3);
            }
            set
            {
                _Tra_DocSop = value;
            }
        }
        public System.Decimal Tra_NumSop
        {
            get
            {
                return _Tra_NumSop;
            }
            set
            {
                _Tra_NumSop = value;
            }
        }
        public System.Decimal Tra_numlinea
        {
            get
            {
                return _Tra_numlinea;
            }
            set
            {
                _Tra_numlinea = value;
            }
        }
        public System.String Tra_Codigo
        {
            get
            {
                return ajustarAncho(_Tra_Codigo, 20);
            }
            set
            {
                _Tra_Codigo = value;
            }
        }
        public System.String Tra_docotro
        {
            get
            {
                return ajustarAncho(_Tra_docotro, 3);
            }
            set
            {
                _Tra_docotro = value;
            }
        }
        public System.Decimal Tra_numotro
        {
            get
            {
                return _Tra_numotro;
            }
            set
            {
                _Tra_numotro = value;
            }
        }
        public System.DateTime Tra_fecha
        {
            get
            {
                return _Tra_fecha;
            }
            set
            {
                _Tra_fecha = value;
            }
        }
        public System.String Tra_nombre
        {
            get
            {
                return ajustarAncho(_Tra_nombre, 40);
            }
            set
            {
                _Tra_nombre = value;
            }
        }
        public System.Decimal Tra_cantidad
        {
            get
            {
                return _Tra_cantidad;
            }
            set
            {
                _Tra_cantidad = value;
            }
        }
        public System.Decimal Tra_costuni
        {
            get
            {
                return _Tra_costuni;
            }
            set
            {
                _Tra_costuni = value;
            }
        }
        public System.Decimal Tra_costtot
        {
            get
            {
                return _Tra_costtot;
            }
            set
            {
                _Tra_costtot = value;
            }
        }
        public System.String Tra_numprecio
        {
            get
            {
                return ajustarAncho(_Tra_numprecio, 1);
            }
            set
            {
                _Tra_numprecio = value;
            }
        }
        public System.String Tra_descdes
        {
            get
            {
                return ajustarAncho(_Tra_descdes, 40);
            }
            set
            {
                _Tra_descdes = value;
            }
        }
        public System.Decimal Tra_porcendes
        {
            get
            {
                return _Tra_porcendes;
            }
            set
            {
                _Tra_porcendes = value;
            }
        }
        public System.Decimal Tra_valordes
        {
            get
            {
                return _Tra_valordes;
            }
            set
            {
                _Tra_valordes = value;
            }
        }
        public System.Decimal Tra_valor
        {
            get
            {
                return _Tra_valor;
            }
            set
            {
                _Tra_valor = value;
            }
        }
        public System.String Tra_extension
        {
            get
            {
                return ajustarAncho(_Tra_extension, 15);
            }
            set
            {
                _Tra_extension = value;
            }
        }
        public System.Boolean Tra_sniva
        {
            get
            {
                return _Tra_sniva;
            }
            set
            {
                _Tra_sniva = value;
            }
        }
        public System.String Tra_Individual
        {
            get
            {
                return ajustarAncho(_Tra_Individual, 3);
            }
            set
            {
                _Tra_Individual = value;
            }
        }
        public System.String Tra_quetipo
        {
            get
            {
                return ajustarAncho(_Tra_quetipo, 1);
            }
            set
            {
                _Tra_quetipo = value;
            }
        }
        public System.Decimal Tra_precuni
        {
            get
            {
                return _Tra_precuni;
            }
            set
            {
                _Tra_precuni = value;
            }
        }
        public System.Decimal Tra_prectot
        {
            get
            {
                return _Tra_prectot;
            }
            set
            {
                _Tra_prectot = value;
            }
        }
        public System.String Tra_DepDes
        {
            get
            {
                return ajustarAncho(_Tra_DepDes, 50);
            }
            set
            {
                _Tra_DepDes = value;
            }
        }
        public System.Int16 Tra_Estado
        {
            get
            {
                return _Tra_Estado;
            }
            set
            {
                _Tra_Estado = value;
            }
        }
        public System.Int16 Tra_Oculto
        {
            get
            {
                return _Tra_Oculto;
            }
            set
            {
                _Tra_Oculto = value;
            }
        }
        public System.Int16 Tra_Inventario
        {
            get
            {
                return _Tra_Inventario;
            }
            set
            {
                _Tra_Inventario = value;
            }
        }
        public System.Int16 Tra_Ventas
        {
            get
            {
                return _Tra_Ventas;
            }
            set
            {
                _Tra_Ventas = value;
            }
        }
        public System.Int16 Tra_Compras
        {
            get
            {
                return _Tra_Compras;
            }
            set
            {
                _Tra_Compras = value;
            }
        }
        public System.Int16 Tra_Activo
        {
            get
            {
                return _Tra_Activo;
            }
            set
            {
                _Tra_Activo = value;
            }
        }
        public System.Decimal Tra_Adicional1
        {
            get
            {
                return _Tra_Adicional1;
            }
            set
            {
                _Tra_Adicional1 = value;
            }
        }
        public System.Decimal Tra_Adicional2
        {
            get
            {
                return _Tra_Adicional2;
            }
            set
            {
                _Tra_Adicional2 = value;
            }
        }
        public System.Decimal Tra_piezas
        {
            get
            {
                return _Tra_piezas;
            }
            set
            {
                _Tra_piezas = value;
            }
        }
        public System.String Tra_medida
        {
            get
            {
                return ajustarAncho(_Tra_medida, 5);
            }
            set
            {
                _Tra_medida = value;
            }
        }
        public System.Decimal Tra_multiplo
        {
            get
            {
                return _Tra_multiplo;
            }
            set
            {
                _Tra_multiplo = value;
            }
        }
        public System.DateTime Tra_vence
        {
            get
            {
                return _Tra_vence;
            }
            set
            {
                _Tra_vence = value;
            }
        }
        public System.String tra_serie
        {
            get
            {
                return ajustarAncho(_tra_serie, 20);
            }
            set
            {
                _tra_serie = value;
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
        public System.String Tra_NroLote
        {
            get
            {
                return ajustarAncho(_Tra_NroLote, 20);
            }
            set
            {
                _Tra_NroLote = value;
            }
        }
        public System.String Tra_NroLoteDoc
        {
            get
            {
                return ajustarAncho(_Tra_NroLoteDoc, 20);
            }
            set
            {
                _Tra_NroLoteDoc = value;
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
        public System.Decimal ord_numero
        {
            get
            {
                return _ord_numero;
            }
            set
            {
                _ord_numero = value;
            }
        }
        public System.Decimal NumeroHoras
        {
            get
            {
                return _NumeroHoras;
            }
            set
            {
                _NumeroHoras = value;
            }
        }
        public System.Decimal CostoHora
        {
            get
            {
                return _CostoHora;
            }
            set
            {
                _CostoHora = value;
            }
        }
        public System.Decimal CostoMatPrima
        {
            get
            {
                return _CostoMatPrima;
            }
            set
            {
                _CostoMatPrima = value;
            }
        }
        public System.Decimal PorcUtilidad
        {
            get
            {
                return _PorcUtilidad;
            }
            set
            {
                _PorcUtilidad = value;
            }
        }
        public System.Decimal CostosIndirectos
        {
            get
            {
                return _CostosIndirectos;
            }
            set
            {
                _CostosIndirectos = value;
            }
        }
        public System.Decimal CostosTerceros
        {
            get
            {
                return _CostosTerceros;
            }
            set
            {
                _CostosTerceros = value;
            }
        }
        public System.String ZonaProducto
        {
            get
            {
                return ajustarAncho(_ZonaProducto, 50);
            }
            set
            {
                _ZonaProducto = value;
            }
        }
        public System.String TipoCosto
        {
            get
            {
                return ajustarAncho(_TipoCosto, 1);
            }
            set
            {
                _TipoCosto = value;
            }
        }
        public System.Boolean Recosteo
        {
            get
            {
                return _Recosteo;
            }
            set
            {
                _Recosteo = value;
            }
        }
        public System.String tra_costo
        {
            get
            {
                return ajustarAncho(_tra_costo, 50);
            }
            set
            {
                _tra_costo = value;
            }
        }
        public System.String tra_empleado
        {
            get
            {
                return ajustarAncho(_tra_empleado, 50);
            }
            set
            {
                _tra_empleado = value;
            }
        }
        public System.String tra_directorio
        {
            get
            {
                return ajustarAncho(_tra_directorio, 50);
            }
            set
            {
                _tra_directorio = value;
            }
        }
        public System.String tra_dia_proyecto
        {
            get
            {
                return ajustarAncho(_tra_dia_proyecto, 50);
            }
            set
            {
                _tra_dia_proyecto = value;
            }
        }
        public System.String tra_relacionado
        {
            get
            {
                return ajustarAncho(_tra_relacionado, 50);
            }
            set
            {
                _tra_relacionado = value;
            }
        }
        public System.String tra_codigoalterno
        {
            get
            {
                return ajustarAncho(_tra_codigoalterno, 50);
            }
            set
            {
                _tra_codigoalterno = value;
            }
        }
        public System.Boolean Tra_EsCuenta
        {
            get
            {
                return _Tra_EsCuenta;
            }
            set
            {
                _Tra_EsCuenta = value;
            }
        }
        public System.String tra_producto
        {
            get
            {
                return ajustarAncho(_tra_producto, 50);
            }
            set
            {
                _tra_producto = value;
            }
        }
        public System.String tra_centroproduccion
        {
            get
            {
                return ajustarAncho(_tra_centroproduccion, 50);
            }
            set
            {
                _tra_centroproduccion = value;
            }
        }
        public System.String tra_centroDistribucion
        {
            get
            {
                return ajustarAncho(_tra_centroDistribucion, 50);
            }
            set
            {
                _tra_centroDistribucion = value;
            }
        }
        public System.String tra_proyecto
        {
            get
            {
                return ajustarAncho(_tra_proyecto, 50);
            }
            set
            {
                _tra_proyecto = value;
            }
        }
        public System.Decimal tra_peso
        {
            get
            {
                return _tra_peso;
            }
            set
            {
                _tra_peso = value;
            }
        }
        public System.String CodigoBase
        {
            get
            {
                return ajustarAncho(_CodigoBase, 20);
            }
            set
            {
                _CodigoBase = value;
            }
        }
        public System.Decimal Despacho
        {
            get
            {
                return _Despacho;
            }
            set
            {
                _Despacho = value;
            }
        }
        public System.String tra_boddestino
        {
            get
            {
                return ajustarAncho(_tra_boddestino, 20);
            }
            set
            {
                _tra_boddestino = value;
            }
        }
        public System.String tra_sucdestino
        {
            get
            {
                return ajustarAncho(_tra_sucdestino, 20);
            }
            set
            {
                _tra_sucdestino = value;
            }
        }

        public System.Int32 tra_anio
        {
            get
            {
                return _tra_anio;
            }
            set
            {
                _tra_anio = value;
            }
        }
        public System.Int32 tra_mes
        {
            get
            {
                return _tra_mes;
            }
            set
            {
                _tra_mes = value;
            }
        }
        public System.Int32 tra_dia
        {
            get
            {
                return _tra_dia;
            }
            set
            {
                _tra_dia = value;
            }
        }


        public System.String Tra_Talla
        {
            get
            {
                return ajustarAncho(_Tra_Talla, 20);
            }
            set
            {
                _Tra_Talla = value;
            }
        }
        public System.String Tra_Color
        {
            get
            {
                return ajustarAncho(_Tra_Color, 20);
            }
            set
            {
                _Tra_Color = value;
            }
        }
        public System.String Tra_Dibujo
        {
            get
            {
                return ajustarAncho(_Tra_Dibujo, 20);
            }
            set
            {
                _Tra_Dibujo = value;
            }
        }
        public System.String Tra_Genero
        {
            get
            {
                return ajustarAncho(_Tra_Genero, 20);
            }
            set
            {
                _Tra_Genero = value;
            }
        }
        public System.String Tra_Modelo
        {
            get
            {
                return ajustarAncho(_Tra_Modelo, 20);
            }
            set
            {
                _Tra_Modelo = value;
            }
        }
        public System.String Tra_Despachado
        {
            get
            {
                return ajustarAncho(_Tra_Despachado, 20);
            }
            set
            {
                _Tra_Despachado = value;
            }
        }
        public System.Int64 Ramos
        {
            get
            {
                return _Ramos;
            }
            set
            {
                _Ramos = value;
            }
        }
        public System.String NroCaja
        {
            get
            {
                return ajustarAncho(_NroCaja, 20);
            }
            set
            {
                _NroCaja = value;
            }
        }
        public System.String TipCaja
        {
            get
            {
                return ajustarAncho(_TipCaja, 20);
            }
            set
            {
                _TipCaja = value;
            }
        }
        public System.Int64 CantCajas
        {
            get
            {
                return _CantCajas;
            }
            set
            {
                _CantCajas = value;
            }
        }
        public System.Int64 Largo
        {
            get
            {
                return _Largo;
            }
            set
            {
                _Largo = value;
            }
        }
        public System.Int64 TallXramo
        {
            get
            {
                return _TallXramo;
            }
            set
            {
                _TallXramo = value;
            }
        }
        public System.Int64 RamXcaja
        {
            get
            {
                return _RamXcaja;
            }
            set
            {
                _RamXcaja = value;
            }
        }
        public System.Int64 Tallos
        {
            get
            {
                return _Tallos;
            }
            set
            {
                _Tallos = value;
            }
        }
        public System.Decimal TotPeso
        {
            get
            {
                return _TotPeso;
            }
            set
            {
                _TotPeso = value;
            }
        }
        public System.Decimal Fulls
        {
            get
            {
                return _Fulls;
            }
            set
            {
                _Fulls = value;
            }
        }
        public System.String SGP
        {
            get
            {
                return ajustarAncho(_SGP, 20);
            }
            set
            {
                _SGP = value;
            }
        }
        public System.String Nandina
        {
            get
            {
                return ajustarAncho(_Nandina, 20);
            }
            set
            {
                _Nandina = value;
            }
        }
        public System.String DetalleItm
        {
            get
            {
                return ajustarAncho(_DetalleItm, 20);
            }
            set
            {
                _DetalleItm = value;
            }
        }
        public System.String HTS
        {
            get
            {
                return ajustarAncho(_HTS, 20);
            }
            set
            {
                _HTS = value;
            }
        }

        //
        // Campos y métodos compartidos (estáticos) para gestionar la base de datos
        //
        // La cadena de conexión a la base de datos
        private static string cadenaConexion = @"Data Source=.; Initial Catalog=BdAdcomDax; user id=sa; password=1234qwerASDFZXCV";
        // La cadena de selección
        public static string CadenaSelect = "SELECT * FROM AdcTraPro";
        //
        public AdcTraPro()
        {
        }
        public AdcTraPro(string conex)
        {
            cadenaConexion = conex;
        }
        //
        // Métodos compartidos (estáticos) privados
        //
        // asigna una fila de la tabla a un objeto AdcTraPro
        private static AdcTraPro row2AdcTraPro(DataRow r)
        {
            // asigna a un objeto AdcTraPro los datos del dataRow indicado
            AdcTraPro oAdcTraPro = new AdcTraPro();
            //
            oAdcTraPro.Doc_sucursal = r["Doc_sucursal"].ToString();
            oAdcTraPro.Doc_Bodega = r["Doc_Bodega"].ToString();
            oAdcTraPro.Opc_documento = r["Opc_documento"].ToString();
            oAdcTraPro.Doc_numero = System.Decimal.Parse("0" + r["Doc_numero"].ToString());
            oAdcTraPro.Tra_TipoDoc = r["Tra_TipoDoc"].ToString();
            oAdcTraPro.Tra_DocSop = r["Tra_DocSop"].ToString();
            oAdcTraPro.Tra_NumSop = System.Decimal.Parse("0" + r["Tra_NumSop"].ToString());
            oAdcTraPro.Tra_numlinea = System.Decimal.Parse("0" + r["Tra_numlinea"].ToString());
            oAdcTraPro.Tra_Codigo = r["Tra_Codigo"].ToString();
            oAdcTraPro.Tra_docotro = r["Tra_docotro"].ToString();
            oAdcTraPro.Tra_numotro = System.Decimal.Parse("0" + r["Tra_numotro"].ToString());
            try
            {
                oAdcTraPro.Tra_fecha = DateTime.Parse(r["Tra_fecha"].ToString());
            }
            catch
            {
                oAdcTraPro.Tra_fecha = DateTime.Now;
            }
            oAdcTraPro.Tra_nombre = r["Tra_nombre"].ToString();
            oAdcTraPro.Tra_cantidad = System.Decimal.Parse("0" + r["Tra_cantidad"].ToString());
            oAdcTraPro.Tra_costuni = System.Decimal.Parse("0" + r["Tra_costuni"].ToString());
            oAdcTraPro.Tra_costtot = System.Decimal.Parse("0" + r["Tra_costtot"].ToString());
            oAdcTraPro.Tra_numprecio = r["Tra_numprecio"].ToString();
            oAdcTraPro.Tra_descdes = r["Tra_descdes"].ToString();
            oAdcTraPro.Tra_porcendes = System.Decimal.Parse("0" + r["Tra_porcendes"].ToString());
            oAdcTraPro.Tra_valordes = System.Decimal.Parse("0" + r["Tra_valordes"].ToString());
            oAdcTraPro.Tra_valor = System.Decimal.Parse("0" + r["Tra_valor"].ToString());
            oAdcTraPro.Tra_extension = r["Tra_extension"].ToString();
            try
            {
                oAdcTraPro.Tra_sniva = System.Boolean.Parse(r["Tra_sniva"].ToString());
            }
            catch
            {
                oAdcTraPro.Tra_sniva = false;
            }
            oAdcTraPro.Tra_Individual = r["Tra_Individual"].ToString();
            oAdcTraPro.Tra_quetipo = r["Tra_quetipo"].ToString();
            oAdcTraPro.Tra_precuni = System.Decimal.Parse("0" + r["Tra_precuni"].ToString());
            oAdcTraPro.Tra_prectot = System.Decimal.Parse("0" + r["Tra_prectot"].ToString());
            oAdcTraPro.Tra_DepDes = r["Tra_DepDes"].ToString();
            oAdcTraPro.Tra_Estado = System.Int16.Parse("0" + r["Tra_Estado"].ToString());
            oAdcTraPro.Tra_Oculto = System.Int16.Parse("0" + r["Tra_Oculto"].ToString());
            try { oAdcTraPro.Tra_Inventario = short.Parse(r["Tra_Inventario"].ToString()); } catch { }
            try { oAdcTraPro.Tra_Ventas = System.Int16.Parse(r["Tra_Ventas"].ToString()); } catch { }
            try { oAdcTraPro.Tra_Compras = System.Int16.Parse(r["Tra_Compras"].ToString()); } catch { }
            try { oAdcTraPro.Tra_Activo = System.Int16.Parse(r["Tra_Activo"].ToString()); } catch { }
            oAdcTraPro.Tra_Adicional1 = System.Decimal.Parse("0" + r["Tra_Adicional1"].ToString());
            oAdcTraPro.Tra_Adicional2 = System.Decimal.Parse("0" + r["Tra_Adicional2"].ToString());
            oAdcTraPro.Tra_piezas = System.Decimal.Parse("0" + r["Tra_piezas"].ToString());
            oAdcTraPro.Tra_medida = r["Tra_medida"].ToString();
            oAdcTraPro.Tra_multiplo = System.Decimal.Parse("0" + r["Tra_multiplo"].ToString());
            try
            {
                oAdcTraPro.Tra_vence = DateTime.Parse(r["Tra_vence"].ToString());
            }
            catch
            {
                oAdcTraPro.Tra_vence = oAdcTraPro.Tra_fecha;
            }
            oAdcTraPro.tra_serie = r["tra_serie"].ToString();
            oAdcTraPro.IdClaveDoc = System.Decimal.Parse("0" + r["IdClaveDoc"].ToString());
            oAdcTraPro.Tra_NroLote = r["Tra_NroLote"].ToString();
            oAdcTraPro.Tra_NroLoteDoc = r["Tra_NroLoteDoc"].ToString();
            try
            {
                oAdcTraPro.Periodo1 = DateTime.Parse(r["Periodo1"].ToString());
            }
            catch
            {
                oAdcTraPro.Periodo1 = new DateTime(1900, 1, 1);
            }
            try
            {
                oAdcTraPro.Periodo2 = DateTime.Parse(r["Periodo2"].ToString());
            }
            catch
            {
                oAdcTraPro.Periodo2 = new DateTime(1900, 1, 1);
            }
            try
            {
                oAdcTraPro.FacDesde = DateTime.Parse(r["FacDesde"].ToString());
            }
            catch
            {
                oAdcTraPro.FacDesde = new DateTime(1900, 1, 1);
            }
            try
            {
                oAdcTraPro.FacHasta = DateTime.Parse(r["FacHasta"].ToString());
            }
            catch
            {
                oAdcTraPro.FacHasta = new DateTime(1900, 1, 1);
            }
            oAdcTraPro.Habitacion = r["Habitacion"].ToString();
            oAdcTraPro.Mesa = r["Mesa"].ToString();
            oAdcTraPro.TipoPeriodo = r["TipoPeriodo"].ToString();
            oAdcTraPro.AuxVar1 = r["AuxVar1"].ToString();
            oAdcTraPro.AuxVar2 = r["AuxVar2"].ToString();
            oAdcTraPro.AuxVar3 = r["AuxVar3"].ToString();
            oAdcTraPro.AuxVar4 = r["AuxVar4"].ToString();
            oAdcTraPro.AuxVar5 = r["AuxVar5"].ToString();
            oAdcTraPro.AuxVar6 = r["AuxVar6"].ToString();
            oAdcTraPro.AuxVar7 = r["AuxVar7"].ToString();
            oAdcTraPro.AuxVar8 = r["AuxVar8"].ToString();
            oAdcTraPro.AuxVar9 = r["AuxVar9"].ToString();
            oAdcTraPro.AuxVar10 = r["AuxVar10"].ToString();
            oAdcTraPro.AuxVar11 = r["AuxVar11"].ToString();
            oAdcTraPro.AuxVar12 = r["AuxVar12"].ToString();
            try
            {
                oAdcTraPro.AuxFec1 = DateTime.Parse(r["AuxFec1"].ToString());
            }
            catch
            {
                oAdcTraPro.AuxFec1 = new DateTime(1900, 1, 1);
            }
            try
            {
                oAdcTraPro.AuxFec2 = DateTime.Parse(r["AuxFec2"].ToString());
            }
            catch
            {
                oAdcTraPro.AuxFec2 = new DateTime(1900, 1, 1);
            }
            try
            {
                oAdcTraPro.AuxFec3 = DateTime.Parse(r["AuxFec3"].ToString());
            }
            catch
            {
                oAdcTraPro.AuxFec3 = new DateTime(1900, 1, 1);
            }
            oAdcTraPro.AuxLog1 = r["AuxLog1"].ToString();
            oAdcTraPro.AuxLog2 = r["AuxLog2"].ToString();
            oAdcTraPro.AuxLog3 = r["AuxLog3"].ToString();
            oAdcTraPro.AuxNum1 = System.Decimal.Parse("0" + r["AuxNum1"].ToString());
            oAdcTraPro.AuxNum2 = System.Decimal.Parse("0" + r["AuxNum2"].ToString());
            oAdcTraPro.AuxNum3 = System.Decimal.Parse("0" + r["AuxNum3"].ToString());
            oAdcTraPro.AuxNum4 = System.Decimal.Parse("0" + r["AuxNum4"].ToString());
            oAdcTraPro.AuxNum5 = System.Decimal.Parse("0" + r["AuxNum5"].ToString());
            oAdcTraPro.AuxNum6 = System.Decimal.Parse("0" + r["AuxNum6"].ToString());
            oAdcTraPro.AuxNum7 = System.Decimal.Parse("0" + r["AuxNum7"].ToString());
            oAdcTraPro.AuxNum8 = System.Decimal.Parse("0" + r["AuxNum8"].ToString());
            oAdcTraPro.AuxNum9 = System.Decimal.Parse("0" + r["AuxNum9"].ToString());
            oAdcTraPro.AuxNum10 = System.Decimal.Parse("0" + r["AuxNum10"].ToString());
            oAdcTraPro.AuxNum11 = System.Decimal.Parse("0" + r["AuxNum11"].ToString());
            oAdcTraPro.AuxNum12 = System.Decimal.Parse("0" + r["AuxNum12"].ToString());
            oAdcTraPro.ord_numero = System.Decimal.Parse("0" + r["ord_numero"].ToString());
            oAdcTraPro.NumeroHoras = System.Decimal.Parse("0" + r["NumeroHoras"].ToString());
            oAdcTraPro.CostoHora = System.Decimal.Parse("0" + r["CostoHora"].ToString());
            oAdcTraPro.CostoMatPrima = System.Decimal.Parse("0" + r["CostoMatPrima"].ToString());
            oAdcTraPro.PorcUtilidad = System.Decimal.Parse("0" + r["PorcUtilidad"].ToString());
            oAdcTraPro.CostosIndirectos = System.Decimal.Parse("0" + r["CostosIndirectos"].ToString());
            oAdcTraPro.CostosTerceros = System.Decimal.Parse("0" + r["CostosTerceros"].ToString());
            oAdcTraPro.ZonaProducto = r["ZonaProducto"].ToString();
            oAdcTraPro.TipoCosto = r["TipoCosto"].ToString();
            try
            {
                oAdcTraPro.Recosteo = System.Boolean.Parse(r["Recosteo"].ToString());
            }
            catch
            {
                oAdcTraPro.Recosteo = false;
            }
            oAdcTraPro.tra_costo = r["tra_costo"].ToString();
            oAdcTraPro.tra_empleado = r["tra_empleado"].ToString();
            oAdcTraPro.tra_directorio = r["tra_directorio"].ToString();
            oAdcTraPro.tra_dia_proyecto = r["tra_dia_proyecto"].ToString();
            oAdcTraPro.tra_relacionado = r["tra_relacionado"].ToString();
            oAdcTraPro.tra_codigoalterno = r["tra_codigoalterno"].ToString();
            try
            {
                oAdcTraPro.Tra_EsCuenta = System.Boolean.Parse(r["Tra_EsCuenta"].ToString());
            }
            catch
            {
                oAdcTraPro.Tra_EsCuenta = false;
            }
            oAdcTraPro.tra_producto = r["tra_producto"].ToString();
            oAdcTraPro.tra_centroproduccion = r["tra_centroproduccion"].ToString();
            oAdcTraPro.tra_centroDistribucion = r["tra_centroDistribucion"].ToString();
            oAdcTraPro.tra_proyecto = r["tra_proyecto"].ToString();
            oAdcTraPro.tra_peso = System.Decimal.Parse("0" + r["tra_peso"].ToString());
            oAdcTraPro.CodigoBase = r["CodigoBase"].ToString();
            oAdcTraPro.Despacho = System.Decimal.Parse("0" + r["Despacho"].ToString());
            oAdcTraPro.tra_boddestino = r["tra_boddestino"].ToString();
            oAdcTraPro.tra_sucdestino = r["tra_sucdestino"].ToString();
            oAdcTraPro.Tra_Talla = r["Tra_Talla"].ToString();
            oAdcTraPro.Tra_Color = r["Tra_Color"].ToString();
            oAdcTraPro.Tra_Dibujo = r["Tra_Dibujo"].ToString();
            oAdcTraPro.Tra_Genero = r["Tra_Genero"].ToString();
            oAdcTraPro.Tra_Modelo = r["Tra_Modelo"].ToString();
            oAdcTraPro.Tra_Despachado = r["Tra_Despachado"].ToString();
            oAdcTraPro.tra_anio = System.Int32.Parse("0" + r["tra_anio"].ToString());
            oAdcTraPro.tra_mes = System.Int32.Parse("0" + r["tra_mes"].ToString());
            oAdcTraPro.tra_dia = System.Int32.Parse("0" + r["tra_dia"].ToString());
            oAdcTraPro.Ramos = System.Int64.Parse("0" + r["Ramos"].ToString());
            oAdcTraPro.NroCaja = r["NroCaja"].ToString();
            oAdcTraPro.TipCaja = r["TipCaja"].ToString();
            oAdcTraPro.CantCajas = System.Int64.Parse("0" + r["CantCajas"].ToString());
            oAdcTraPro.Largo = System.Int64.Parse("0" + r["Largo"].ToString());
            oAdcTraPro.TallXramo = System.Int64.Parse("0" + r["TallXramo"].ToString());
            oAdcTraPro.RamXcaja = System.Int64.Parse("0" + r["RamXcaja"].ToString());
            oAdcTraPro.Tallos = System.Int64.Parse("0" + r["Tallos"].ToString());
            oAdcTraPro.TotPeso = System.Decimal.Parse("0" + r["TotPeso"].ToString());
            oAdcTraPro.Fulls = System.Decimal.Parse("0" + r["Fulls"].ToString());
            oAdcTraPro.SGP = r["SGP"].ToString();
            oAdcTraPro.Nandina = r["Nandina"].ToString();
            oAdcTraPro.HTS = r["HTS"].ToString();
            oAdcTraPro.DetalleItm = r["DetalleItm"].ToString();
            //
            return oAdcTraPro;
        }
        //
        // asigna un objeto AdcTraPro a la fila indicada
        public void MoverAdcTraPro2Row(AdcTraPro oAdcTraPro, ref DataRow r)
        {
            // asigna un objeto AdcTraPro al dataRow indicado
            r["Doc_sucursal"] = oAdcTraPro.Doc_sucursal;
            r["Doc_Bodega"] = oAdcTraPro.Doc_Bodega;
            r["Opc_documento"] = oAdcTraPro.Opc_documento;
            r["Doc_numero"] = oAdcTraPro.Doc_numero;
            r["Tra_TipoDoc"] = oAdcTraPro.Tra_TipoDoc;
            r["Tra_DocSop"] = oAdcTraPro.Tra_DocSop;
            r["Tra_NumSop"] = oAdcTraPro.Tra_NumSop;
            r["Tra_numlinea"] = oAdcTraPro.Tra_numlinea;
            r["Tra_Codigo"] = oAdcTraPro.Tra_Codigo;
            r["Tra_docotro"] = oAdcTraPro.Tra_docotro;
            r["Tra_numotro"] = oAdcTraPro.Tra_numotro;
            r["Tra_fecha"] = oAdcTraPro.Tra_fecha;
            r["Tra_nombre"] = oAdcTraPro.Tra_nombre;
            r["Tra_cantidad"] = oAdcTraPro.Tra_cantidad;
            r["Tra_costuni"] = oAdcTraPro.Tra_costuni;
            r["Tra_costtot"] = oAdcTraPro.Tra_costtot;
            r["Tra_numprecio"] = oAdcTraPro.Tra_numprecio;
            r["Tra_descdes"] = oAdcTraPro.Tra_descdes;
            r["Tra_porcendes"] = oAdcTraPro.Tra_porcendes;
            r["Tra_valordes"] = oAdcTraPro.Tra_valordes;
            r["Tra_valor"] = oAdcTraPro.Tra_valor;
            r["Tra_extension"] = oAdcTraPro.Tra_extension;
            r["Tra_sniva"] = oAdcTraPro.Tra_sniva;
            r["Tra_Individual"] = oAdcTraPro.Tra_Individual;
            r["Tra_quetipo"] = oAdcTraPro.Tra_quetipo;
            r["Tra_precuni"] = oAdcTraPro.Tra_precuni;
            r["Tra_prectot"] = oAdcTraPro.Tra_prectot;
            r["Tra_DepDes"] = oAdcTraPro.Tra_DepDes;
            r["Tra_Estado"] = oAdcTraPro.Tra_Estado;
            r["Tra_Oculto"] = oAdcTraPro.Tra_Oculto;
            r["Tra_Inventario"] = oAdcTraPro.Tra_Inventario;
            r["Tra_Ventas"] = oAdcTraPro.Tra_Ventas;
            r["Tra_Compras"] = oAdcTraPro.Tra_Compras;
            r["Tra_Activo"] = oAdcTraPro.Tra_Activo;
            r["Tra_Adicional1"] = oAdcTraPro.Tra_Adicional1;
            r["Tra_Adicional2"] = oAdcTraPro.Tra_Adicional2;
            r["Tra_piezas"] = oAdcTraPro.Tra_piezas;
            r["Tra_medida"] = oAdcTraPro.Tra_medida;
            r["Tra_multiplo"] = oAdcTraPro.Tra_multiplo;
            r["Tra_vence"] = oAdcTraPro.Tra_vence;
            r["tra_serie"] = oAdcTraPro.tra_serie;
            r["IdClaveDoc"] = oAdcTraPro.IdClaveDoc;
            r["Tra_NroLote"] = oAdcTraPro.Tra_NroLote;
            r["Tra_NroLoteDoc"] = oAdcTraPro.Tra_NroLoteDoc;
            r["Periodo1"] = oAdcTraPro.Periodo1;
            r["Periodo2"] = oAdcTraPro.Periodo2;
            r["FacDesde"] = oAdcTraPro.FacDesde;
            r["FacHasta"] = oAdcTraPro.FacHasta;
            r["Habitacion"] = oAdcTraPro.Habitacion;
            r["Mesa"] = oAdcTraPro.Mesa;
            r["TipoPeriodo"] = oAdcTraPro.TipoPeriodo;
            r["AuxVar1"] = oAdcTraPro.AuxVar1;
            r["AuxVar2"] = oAdcTraPro.AuxVar2;
            r["AuxVar3"] = oAdcTraPro.AuxVar3;
            r["AuxVar4"] = oAdcTraPro.AuxVar4;
            r["AuxVar5"] = oAdcTraPro.AuxVar5;
            r["AuxVar6"] = oAdcTraPro.AuxVar6;
            r["AuxVar7"] = oAdcTraPro.AuxVar7;
            r["AuxVar8"] = oAdcTraPro.AuxVar8;
            r["AuxVar9"] = oAdcTraPro.AuxVar9;
            r["AuxVar10"] = oAdcTraPro.AuxVar10;
            r["AuxVar11"] = oAdcTraPro.AuxVar11;
            r["AuxVar12"] = oAdcTraPro.AuxVar12;
            r["AuxFec1"] = oAdcTraPro.AuxFec1;
            r["AuxFec2"] = oAdcTraPro.AuxFec2;
            r["AuxFec3"] = oAdcTraPro.AuxFec3;
            r["AuxLog1"] = oAdcTraPro.AuxLog1;
            r["AuxLog2"] = oAdcTraPro.AuxLog2;
            r["AuxLog3"] = oAdcTraPro.AuxLog3;
            r["AuxNum1"] = oAdcTraPro.AuxNum1;
            r["AuxNum2"] = oAdcTraPro.AuxNum2;
            r["AuxNum3"] = oAdcTraPro.AuxNum3;
            r["AuxNum4"] = oAdcTraPro.AuxNum4;
            r["AuxNum5"] = oAdcTraPro.AuxNum5;
            r["AuxNum6"] = oAdcTraPro.AuxNum6;
            r["AuxNum7"] = oAdcTraPro.AuxNum7;
            r["AuxNum8"] = oAdcTraPro.AuxNum8;
            r["AuxNum9"] = oAdcTraPro.AuxNum9;
            r["AuxNum10"] = oAdcTraPro.AuxNum10;
            r["AuxNum11"] = oAdcTraPro.AuxNum11;
            r["AuxNum12"] = oAdcTraPro.AuxNum12;
            r["TipoCosto"] = oAdcTraPro.TipoCosto;
            r["Recosteo"] = oAdcTraPro.Recosteo;
            r["tra_costo"] = oAdcTraPro.tra_costo;
            r["tra_empleado"] = oAdcTraPro.tra_empleado;
            r["tra_directorio"] = oAdcTraPro.tra_directorio;
            r["tra_dia_proyecto"] = oAdcTraPro.tra_dia_proyecto;
            r["tra_relacionado"] = oAdcTraPro.tra_relacionado;
            r["tra_codigoalterno"] = oAdcTraPro.tra_codigoalterno;
            r["Tra_EsCuenta"] = oAdcTraPro.Tra_EsCuenta;
            r["tra_producto"] = oAdcTraPro.tra_producto;
            r["tra_centroproduccion"] = oAdcTraPro.tra_centroproduccion;
            r["tra_centroDistribucion"] = oAdcTraPro.tra_centroDistribucion;
            r["tra_proyecto"] = oAdcTraPro.tra_proyecto;
            r["tra_peso"] = oAdcTraPro.tra_peso;
            r["CodigoBase"] = oAdcTraPro.CodigoBase;
            r["Despacho"] = oAdcTraPro.Despacho;
            r["tra_boddestino"] = oAdcTraPro.tra_boddestino;
            r["tra_sucdestino"] = oAdcTraPro.tra_sucdestino;
            r["Tra_Talla"] = oAdcTraPro.Tra_Talla;
            r["Tra_Color"] = oAdcTraPro.Tra_Color;
            r["Tra_Dibujo"] = oAdcTraPro.Tra_Dibujo;
            r["Tra_Genero"] = oAdcTraPro.Tra_Genero;
            r["Tra_Modelo"] = oAdcTraPro.Tra_Modelo;
            r["Tra_Despachado"] = oAdcTraPro.Tra_Despachado;
            r["tra_anio"] = oAdcTraPro.tra_anio;
            r["tra_mes"] = oAdcTraPro.tra_mes;
            r["tra_dia"] = oAdcTraPro.tra_dia;
            r["Ramos"] = oAdcTraPro.Ramos;
            r["NroCaja"] = oAdcTraPro.NroCaja;
            r["TipCaja"] = oAdcTraPro.TipCaja;
            r["CantCajas"] = oAdcTraPro.CantCajas;
            r["Largo"] = oAdcTraPro.Largo;
            r["TallXramo"] = oAdcTraPro.TallXramo;
            r["RamXcaja"] = oAdcTraPro.RamXcaja;
            r["Tallos"] = oAdcTraPro.Tallos;
            r["TotPeso"] = oAdcTraPro.TotPeso;
            r["Fulls"] = oAdcTraPro.Fulls;
            r["ZonaProducto"] = oAdcTraPro.ZonaProducto;
            r["ord_numero"] = oAdcTraPro.ord_numero;
            r["NumeroHoras"] = oAdcTraPro.NumeroHoras;
            r["CostoHora"] = oAdcTraPro.CostoHora;
            r["CostoMatPrima"] = oAdcTraPro.CostoMatPrima;
            r["PorcUtilidad"] = oAdcTraPro.PorcUtilidad;
            r["CostosIndirectos"] = oAdcTraPro.CostosIndirectos;
            r["CostosTerceros"] = oAdcTraPro.CostosTerceros;
            r["ZonaProducto"] = oAdcTraPro.ZonaProducto;
            r["TipoCosto"] = oAdcTraPro.TipoCosto;
            r["Recosteo"] = oAdcTraPro.Recosteo;
            r["tra_costo"] = oAdcTraPro.tra_costo;
            r["tra_empleado"] = oAdcTraPro.tra_empleado;
            r["tra_directorio"] = oAdcTraPro.tra_directorio;
            r["tra_dia_proyecto"] = oAdcTraPro.tra_dia_proyecto;
            r["tra_relacionado"] = oAdcTraPro.tra_relacionado;
            r["tra_codigoalterno"] = oAdcTraPro.tra_codigoalterno;
            r["Tra_EsCuenta"] = oAdcTraPro.Tra_EsCuenta;
            r["tra_producto"] = oAdcTraPro.tra_producto;
            r["tra_centroproduccion"] = oAdcTraPro.tra_centroproduccion;
            r["tra_centroDistribucion"] = oAdcTraPro.tra_centroDistribucion;
            r["tra_proyecto"] = oAdcTraPro.tra_proyecto;
            r["tra_peso"] = oAdcTraPro.tra_peso;
            r["Despacho"] = oAdcTraPro.Despacho;
            r["tra_boddestino"] = oAdcTraPro.tra_boddestino;
            r["tra_sucdestino"] = oAdcTraPro.tra_sucdestino;
            r["Tra_Talla"] = oAdcTraPro.Tra_Talla;
            r["Tra_Color"] = oAdcTraPro.Tra_Color;
            r["Tra_Dibujo"] = oAdcTraPro.Tra_Dibujo;
            r["Tra_Genero"] = oAdcTraPro.Tra_Genero;
            r["Tra_Modelo"] = oAdcTraPro.Tra_Modelo;
            r["Tra_Despachado"] = oAdcTraPro.Tra_Despachado;
            r["Ramos"] = oAdcTraPro.Ramos;
            r["tra_anio"] = oAdcTraPro.tra_anio;
            r["tra_mes"] = oAdcTraPro.tra_mes;
            r["tra_dia"] = oAdcTraPro.tra_dia;
            r["NroCaja"] = oAdcTraPro.NroCaja;
            r["TipCaja"] = oAdcTraPro.TipCaja;
            r["CantCajas"] = oAdcTraPro.CantCajas;
            r["Largo"] = oAdcTraPro.Largo;
            r["TallXramo"] = oAdcTraPro.TallXramo;
            r["RamXcaja"] = oAdcTraPro.RamXcaja;
            r["Tallos"] = oAdcTraPro.Tallos;
            r["TotPeso"] = oAdcTraPro.TotPeso;
            r["Fulls"] = oAdcTraPro.Fulls;
            r["SGP"] = oAdcTraPro.SGP;
            r["Nandina"] = oAdcTraPro.Nandina;
            r["HTS"] = oAdcTraPro.HTS;
            r["DetalleItm"] = oAdcTraPro.DetalleItm;
        }
        //
        // crea una nueva fila y la asigna a un objeto AdcTraPro
        public static void nuevoAdcTraPro(DataTable dt, AdcTraPro oAdcTraPro)
        {
            // Crear un nuevo AdcTraPro
            DataRow dr = dt.NewRow();
            AdcTraPro oA = row2AdcTraPro(dr);
            //
            oA.Doc_sucursal = oAdcTraPro.Doc_sucursal;
            oA.Doc_Bodega = oAdcTraPro.Doc_Bodega;
            oA.Opc_documento = oAdcTraPro.Opc_documento;
            oA.Doc_numero = oAdcTraPro.Doc_numero;
            oA.Tra_TipoDoc = oAdcTraPro.Tra_TipoDoc;
            oA.Tra_DocSop = oAdcTraPro.Tra_DocSop;
            oA.Tra_NumSop = oAdcTraPro.Tra_NumSop;
            oA.Tra_numlinea = oAdcTraPro.Tra_numlinea;
            oA.Tra_Codigo = oAdcTraPro.Tra_Codigo;
            oA.Tra_docotro = oAdcTraPro.Tra_docotro;
            oA.Tra_numotro = oAdcTraPro.Tra_numotro;
            oA.Tra_fecha = oAdcTraPro.Tra_fecha;
            oA.Tra_nombre = oAdcTraPro.Tra_nombre;
            oA.Tra_cantidad = oAdcTraPro.Tra_cantidad;
            oA.Tra_costuni = oAdcTraPro.Tra_costuni;
            oA.Tra_costtot = oAdcTraPro.Tra_costtot;
            oA.Tra_numprecio = oAdcTraPro.Tra_numprecio;
            oA.Tra_descdes = oAdcTraPro.Tra_descdes;
            oA.Tra_porcendes = oAdcTraPro.Tra_porcendes;
            oA.Tra_valordes = oAdcTraPro.Tra_valordes;
            oA.Tra_valor = oAdcTraPro.Tra_valor;
            oA.Tra_extension = oAdcTraPro.Tra_extension;
            oA.Tra_sniva = oAdcTraPro.Tra_sniva;
            oA.Tra_Individual = oAdcTraPro.Tra_Individual;
            oA.Tra_quetipo = oAdcTraPro.Tra_quetipo;
            oA.Tra_precuni = oAdcTraPro.Tra_precuni;
            oA.Tra_prectot = oAdcTraPro.Tra_prectot;
            oA.Tra_DepDes = oAdcTraPro.Tra_DepDes;
            oA.Tra_Estado = oAdcTraPro.Tra_Estado;
            oA.Tra_Oculto = oAdcTraPro.Tra_Oculto;
            oA.Tra_Inventario = oAdcTraPro.Tra_Inventario;
            oA.Tra_Ventas = oAdcTraPro.Tra_Ventas;
            oA.Tra_Compras = oAdcTraPro.Tra_Compras;
            oA.Tra_Activo = oAdcTraPro.Tra_Activo;
            oA.Tra_Adicional1 = oAdcTraPro.Tra_Adicional1;
            oA.Tra_Adicional2 = oAdcTraPro.Tra_Adicional2;
            oA.Tra_piezas = oAdcTraPro.Tra_piezas;
            oA.Tra_medida = oAdcTraPro.Tra_medida;
            oA.Tra_multiplo = oAdcTraPro.Tra_multiplo;
            oA.Tra_vence = oAdcTraPro.Tra_vence;
            oA.tra_serie = oAdcTraPro.tra_serie;
            oA.IdClaveDoc = oAdcTraPro.IdClaveDoc;
            oA.Tra_NroLote = oAdcTraPro.Tra_NroLote;
            oA.Tra_NroLoteDoc = oAdcTraPro.Tra_NroLoteDoc;
            oA.Periodo1 = oAdcTraPro.Periodo1;
            oA.Periodo2 = oAdcTraPro.Periodo2;
            oA.FacDesde = oAdcTraPro.FacDesde;
            oA.FacHasta = oAdcTraPro.FacHasta;
            oA.Habitacion = oAdcTraPro.Habitacion;
            oA.Mesa = oAdcTraPro.Mesa;
            oA.TipoPeriodo = oAdcTraPro.TipoPeriodo;
            oA.AuxVar1 = oAdcTraPro.AuxVar1;
            oA.AuxVar1 = oAdcTraPro.AuxVar1;
            oA.AuxVar2 = oAdcTraPro.AuxVar2;
            oA.AuxVar3 = oAdcTraPro.AuxVar3;
            oA.AuxVar4 = oAdcTraPro.AuxVar4;
            oA.AuxVar5 = oAdcTraPro.AuxVar5;
            oA.AuxVar6 = oAdcTraPro.AuxVar6;
            oA.AuxVar7 = oAdcTraPro.AuxVar7;
            oA.AuxVar8 = oAdcTraPro.AuxVar8;
            oA.AuxVar9 = oAdcTraPro.AuxVar9;
            oA.AuxVar10 = oAdcTraPro.AuxVar10;
            oA.AuxVar11 = oAdcTraPro.AuxVar11;
            oA.AuxVar12 = oAdcTraPro.AuxVar12;
            oA.AuxFec1 = oAdcTraPro.AuxFec1;
            oA.AuxFec2 = oAdcTraPro.AuxFec2;
            oA.AuxFec3 = oAdcTraPro.AuxFec3;
            oA.AuxLog1 = oAdcTraPro.AuxLog1;
            oA.AuxLog2 = oAdcTraPro.AuxLog2;
            oA.AuxLog3 = oAdcTraPro.AuxLog3;
            oA.AuxNum1 = oAdcTraPro.AuxNum1;
            oA.AuxNum2 = oAdcTraPro.AuxNum2;
            oA.AuxNum3 = oAdcTraPro.AuxNum3;
            oA.AuxNum4 = oAdcTraPro.AuxNum4;
            oA.AuxNum5 = oAdcTraPro.AuxNum5;
            oA.AuxNum6 = oAdcTraPro.AuxNum6;
            oA.AuxNum7 = oAdcTraPro.AuxNum7;
            oA.AuxNum8 = oAdcTraPro.AuxNum8;
            oA.AuxNum9 = oAdcTraPro.AuxNum9;
            oA.AuxNum10 = oAdcTraPro.AuxNum10;
            oA.AuxNum11 = oAdcTraPro.AuxNum11;
            oA.AuxNum12 = oAdcTraPro.AuxNum12;
            oA.ord_numero = oAdcTraPro.ord_numero;
            oA.NumeroHoras = oAdcTraPro.NumeroHoras;
            oA.CostoHora = oAdcTraPro.CostoHora;
            oA.CostoMatPrima = oAdcTraPro.CostoMatPrima;
            oA.PorcUtilidad = oAdcTraPro.PorcUtilidad;
            oA.CostosIndirectos = oAdcTraPro.CostosIndirectos;
            oA.CostosTerceros = oAdcTraPro.CostosTerceros;
            oA.ZonaProducto = oAdcTraPro.ZonaProducto;
            oA.TipoCosto = oAdcTraPro.TipoCosto;
            oA.Recosteo = oAdcTraPro.Recosteo;
            oA.tra_costo = oAdcTraPro.tra_costo;
            oA.tra_empleado = oAdcTraPro.tra_empleado;
            oA.tra_directorio = oAdcTraPro.tra_directorio;
            oA.tra_dia_proyecto = oAdcTraPro.tra_dia_proyecto;
            oA.tra_relacionado = oAdcTraPro.tra_relacionado;
            oA.tra_codigoalterno = oAdcTraPro.tra_codigoalterno;
            oA.Tra_EsCuenta = oAdcTraPro.Tra_EsCuenta;
            oA.tra_producto = oAdcTraPro.tra_producto;
            oA.tra_centroproduccion = oAdcTraPro.tra_centroproduccion;
            oA.tra_centroDistribucion = oAdcTraPro.tra_centroDistribucion;
            oA.tra_proyecto = oAdcTraPro.tra_proyecto;
            oA.tra_peso = oAdcTraPro.tra_peso;
            oA.Despacho = oAdcTraPro.Despacho;
            oA.tra_boddestino = oAdcTraPro.tra_boddestino;
            oA.tra_sucdestino = oAdcTraPro.tra_sucdestino;
            oA.Tra_Talla = oAdcTraPro.Tra_Talla;
            oA.Tra_Color = oAdcTraPro.Tra_Color;
            oA.Tra_Dibujo = oAdcTraPro.Tra_Dibujo;
            oA.Tra_Genero = oAdcTraPro.Tra_Genero;
            oA.Tra_Modelo = oAdcTraPro.Tra_Modelo;
            oA.Tra_Despachado = oAdcTraPro.Tra_Despachado;
            oA.Ramos = oAdcTraPro.Ramos;
            oA.NroCaja = oAdcTraPro.NroCaja;
            oA.TipCaja = oAdcTraPro.TipCaja;
            oA.CantCajas = oAdcTraPro.CantCajas;
            oA.Largo = oAdcTraPro.Largo;
            oA.TallXramo = oAdcTraPro.TallXramo;
            oA.RamXcaja = oAdcTraPro.RamXcaja;
            oA.Tallos = oAdcTraPro.Tallos;
            oA.TotPeso = oAdcTraPro.TotPeso;
            oA.Fulls = oAdcTraPro.Fulls;
            oA.SGP = oAdcTraPro.SGP;
            oA.Nandina = oAdcTraPro.Nandina;
            oA.HTS = oAdcTraPro.HTS;
            oA.DetalleItm = oAdcTraPro.DetalleItm;
            //
            AdcTraPro2Row(oA, dr);
            //
            dt.Rows.Add(dr);
        }
        //
        // Métodos públicos
        //
        // devuelve una tabla con los datos indicados en la cadena de selección
        private static void AdcTraPro2Row(AdcTraPro oAdcTraPro, DataRow r)
        {
            // asigna un objeto AdcTraPro al dataRow indicado
            r["Doc_sucursal"] = oAdcTraPro.Doc_sucursal;
            r["Doc_Bodega"] = oAdcTraPro.Doc_Bodega;
            r["Opc_documento"] = oAdcTraPro.Opc_documento;
            r["Doc_numero"] = oAdcTraPro.Doc_numero;
            r["Tra_TipoDoc"] = oAdcTraPro.Tra_TipoDoc;
            r["Tra_DocSop"] = oAdcTraPro.Tra_DocSop;
            r["Tra_NumSop"] = oAdcTraPro.Tra_NumSop;
            r["Tra_numlinea"] = oAdcTraPro.Tra_numlinea;
            r["Tra_Codigo"] = oAdcTraPro.Tra_Codigo;
            r["Tra_docotro"] = oAdcTraPro.Tra_docotro;
            r["Tra_numotro"] = oAdcTraPro.Tra_numotro;
            r["Tra_fecha"] = oAdcTraPro.Tra_fecha;
            r["Tra_nombre"] = oAdcTraPro.Tra_nombre;
            r["Tra_cantidad"] = oAdcTraPro.Tra_cantidad;
            r["Tra_costuni"] = oAdcTraPro.Tra_costuni;
            r["Tra_costtot"] = oAdcTraPro.Tra_costtot;
            r["Tra_numprecio"] = oAdcTraPro.Tra_numprecio;
            r["Tra_descdes"] = oAdcTraPro.Tra_descdes;
            r["Tra_porcendes"] = oAdcTraPro.Tra_porcendes;
            r["Tra_valordes"] = oAdcTraPro.Tra_valordes;
            r["Tra_valor"] = oAdcTraPro.Tra_valor;
            r["Tra_extension"] = oAdcTraPro.Tra_extension;
            r["Tra_sniva"] = oAdcTraPro.Tra_sniva;
            r["Tra_Individual"] = oAdcTraPro.Tra_Individual;
            r["Tra_quetipo"] = oAdcTraPro.Tra_quetipo;
            r["Tra_precuni"] = oAdcTraPro.Tra_precuni;
            r["Tra_prectot"] = oAdcTraPro.Tra_prectot;
            r["Tra_DepDes"] = oAdcTraPro.Tra_DepDes;
            r["Tra_Estado"] = oAdcTraPro.Tra_Estado;
            r["Tra_Oculto"] = oAdcTraPro.Tra_Oculto;
            r["Tra_Inventario"] = oAdcTraPro.Tra_Inventario;
            r["Tra_Ventas"] = oAdcTraPro.Tra_Ventas;
            r["Tra_Compras"] = oAdcTraPro.Tra_Compras;
            r["Tra_Activo"] = oAdcTraPro.Tra_Activo;
            r["Tra_Adicional1"] = oAdcTraPro.Tra_Adicional1;
            r["Tra_Adicional2"] = oAdcTraPro.Tra_Adicional2;
            r["Tra_piezas"] = oAdcTraPro.Tra_piezas;
            r["Tra_medida"] = oAdcTraPro.Tra_medida;
            r["Tra_multiplo"] = oAdcTraPro.Tra_multiplo;
            r["Tra_vence"] = oAdcTraPro.Tra_vence;
            r["tra_serie"] = oAdcTraPro.tra_serie;
            r["IdClaveDoc"] = oAdcTraPro.IdClaveDoc;
            r["Tra_NroLote"] = oAdcTraPro.Tra_NroLote;
            r["Tra_NroLoteDoc"] = oAdcTraPro.Tra_NroLoteDoc;
            r["Periodo1"] = oAdcTraPro.Periodo1;
            r["Periodo2"] = oAdcTraPro.Periodo2;
            r["FacDesde"] = oAdcTraPro.FacDesde;
            r["FacHasta"] = oAdcTraPro.FacHasta;
            r["Habitacion"] = oAdcTraPro.Habitacion;
            r["Mesa"] = oAdcTraPro.Mesa;
            r["TipoPeriodo"] = oAdcTraPro.TipoPeriodo;
            r["AuxVar1"] = oAdcTraPro.AuxVar1;
            r["AuxVar2"] = oAdcTraPro.AuxVar2;
            r["AuxVar3"] = oAdcTraPro.AuxVar3;
            r["AuxVar4"] = oAdcTraPro.AuxVar4;
            r["AuxVar5"] = oAdcTraPro.AuxVar5;
            r["AuxVar6"] = oAdcTraPro.AuxVar6;
            r["AuxVar7"] = oAdcTraPro.AuxVar7;
            r["AuxVar8"] = oAdcTraPro.AuxVar8;
            r["AuxVar9"] = oAdcTraPro.AuxVar9;
            r["AuxVar10"] = oAdcTraPro.AuxVar10;
            r["AuxVar11"] = oAdcTraPro.AuxVar11;
            r["AuxVar12"] = oAdcTraPro.AuxVar12;
            r["AuxFec1"] = oAdcTraPro.AuxFec1;
            r["AuxFec2"] = oAdcTraPro.AuxFec2;
            r["AuxFec3"] = oAdcTraPro.AuxFec3;
            r["AuxLog1"] = oAdcTraPro.AuxLog1;
            r["AuxLog2"] = oAdcTraPro.AuxLog2;
            r["AuxLog3"] = oAdcTraPro.AuxLog3;
            r["AuxNum1"] = oAdcTraPro.AuxNum1;
            r["AuxNum2"] = oAdcTraPro.AuxNum2;
            r["AuxNum3"] = oAdcTraPro.AuxNum3;
            r["AuxNum4"] = oAdcTraPro.AuxNum4;
            r["AuxNum5"] = oAdcTraPro.AuxNum5;
            r["AuxNum6"] = oAdcTraPro.AuxNum6;
            r["AuxNum7"] = oAdcTraPro.AuxNum7;
            r["AuxNum8"] = oAdcTraPro.AuxNum8;
            r["AuxNum9"] = oAdcTraPro.AuxNum9;
            r["AuxNum10"] = oAdcTraPro.AuxNum10;
            r["AuxNum11"] = oAdcTraPro.AuxNum11;
            r["AuxNum12"] = oAdcTraPro.AuxNum12;
            r["ord_numero"] = oAdcTraPro.ord_numero;
            r["NumeroHoras"] = oAdcTraPro.NumeroHoras;
            r["CostoHora"] = oAdcTraPro.CostoHora;
            r["CostoMatPrima"] = oAdcTraPro.CostoMatPrima;
            r["PorcUtilidad"] = oAdcTraPro.PorcUtilidad;
            r["CostosIndirectos"] = oAdcTraPro.CostosIndirectos;
            r["CostosTerceros"] = oAdcTraPro.CostosTerceros;
            r["ZonaProducto"] = oAdcTraPro.ZonaProducto;
            r["TipoCosto"] = oAdcTraPro.TipoCosto;
            r["Recosteo"] = oAdcTraPro.Recosteo;
            r["tra_costo"] = oAdcTraPro.tra_costo;
            r["tra_empleado"] = oAdcTraPro.tra_empleado;
            r["tra_directorio"] = oAdcTraPro.tra_directorio;
            r["tra_dia_proyecto"] = oAdcTraPro.tra_dia_proyecto;
            r["tra_relacionado"] = oAdcTraPro.tra_relacionado;
            r["tra_codigoalterno"] = oAdcTraPro.tra_codigoalterno;
            r["Tra_EsCuenta"] = oAdcTraPro.Tra_EsCuenta;
            r["tra_producto"] = oAdcTraPro.tra_producto;
            r["tra_centroproduccion"] = oAdcTraPro.tra_centroproduccion;
            r["tra_centroDistribucion"] = oAdcTraPro.tra_centroDistribucion;
            r["tra_proyecto"] = oAdcTraPro.tra_proyecto;
            r["tra_peso"] = oAdcTraPro.tra_peso;
            r["Despacho"] = oAdcTraPro.Despacho;
            r["tra_boddestino"] = oAdcTraPro.tra_boddestino;
            r["tra_sucdestino"] = oAdcTraPro.tra_sucdestino;
            r["Tra_Talla"] = oAdcTraPro.Tra_Talla;
            r["Tra_Color"] = oAdcTraPro.Tra_Color;
            r["Tra_Dibujo"] = oAdcTraPro.Tra_Dibujo;
            r["Tra_Genero"] = oAdcTraPro.Tra_Genero;
            r["Tra_Modelo"] = oAdcTraPro.Tra_Modelo;
            r["Tra_Despachado"] = oAdcTraPro.Tra_Despachado;
            r["Ramos"] = oAdcTraPro.Ramos;
            r["tra_anio"] = oAdcTraPro.tra_anio;
            r["tra_mes"] = oAdcTraPro.tra_mes;
            r["tra_dia"] = oAdcTraPro.tra_dia;
            r["NroCaja"] = oAdcTraPro.NroCaja;
            r["TipCaja"] = oAdcTraPro.TipCaja;
            r["CantCajas"] = oAdcTraPro.CantCajas;
            r["Largo"] = oAdcTraPro.Largo;
            r["TallXramo"] = oAdcTraPro.TallXramo;
            r["RamXcaja"] = oAdcTraPro.RamXcaja;
            r["Tallos"] = oAdcTraPro.Tallos;
            r["TotPeso"] = oAdcTraPro.TotPeso;
            r["Fulls"] = oAdcTraPro.Fulls;
            r["SGP"] = oAdcTraPro.SGP;
            r["Nandina"] = oAdcTraPro.Nandina;
            r["HTS"] = oAdcTraPro.HTS;
            r["DetalleItm"] = oAdcTraPro.DetalleItm;
        }
        public static DataTable Tabla()
        {
            return Tabla(CadenaSelect);
        }
        public static DataTable Tabla(string sel)
        {
            // devuelve una tabla con los datos de la tabla AdcTraPro
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcTraPro");
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
        public static AdcTraPro Buscar(string sWhere)
        {
            // Busca en la tabla los datos indicados en el parámetro
            // el parámetro contendrá lo que se usará después del WHERE
            AdcTraPro oAdcTraPro = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcTraPro");
            string sel = "SELECT * FROM AdcTraPro WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oAdcTraPro = row2AdcTraPro(dt.Rows[0]);
            }
            return oAdcTraPro;
        }
        //
        public string Actualizar()
        {
            // TODO: Poner aquí la selección a realizar para acceder a este registro
            //       yo uso el ID que es el identificador único de cada registro
            string sel = "SELECT * FROM AdcTraPro WHERE doc_sucursal = '" + Doc_sucursal + "' and opc_documento = '" + Opc_documento + "' and idclavedoc = " + IdClaveDoc.ToString();
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
            DataTable dt = new DataTable("AdcTraPro");
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
                AdcTraPro2Row(this, dt.Rows[0]);
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
            DataTable dt = new DataTable("AdcTraPro");
            //
            cnn = new SqlConnection(cadenaConexion);
            da = new SqlDataAdapter(CadenaSelect, cnn);
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
            nuevoAdcTraPro(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo AdcTraPro";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            string sel = "SELECT * FROM AdcTraPro WHERE  doc_sucursal = '" + Doc_sucursal + "' and opc_documento = '" + Opc_documento + "' and idclavedoc = " + IdClaveDoc.ToString();
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcTraPro");
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
    }
}
