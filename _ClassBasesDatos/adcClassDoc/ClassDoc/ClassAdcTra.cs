namespace ClassDoc
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    //
    public class AdcTra
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
        private System.Boolean _Pallevar = false;
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
        private System.String _tra_Serie = "";
        private System.Decimal _IdClaveDoc = 0;
        private System.String _Tra_NroLote = "";
        private System.String _Tra_NroLoteDoc = "";
        private System.DateTime _Periodo1 = new DateTime(1900, 1, 1);
        private System.DateTime _Periodo2 = new DateTime(1900, 1, 1);
        private System.DateTime _FacDesde = new DateTime(1900, 1, 1);
        private System.DateTime _FacHasta = new DateTime(1900, 1, 1);
        private System.String _Habitacion = "";
        private System.String _Mesa;
        private System.String _TipoPeriodo;
        private System.String _AuxVar1;   // usado por asofarmadis
        private System.String _AuxVar2;
        private System.String _AuxVar3;  // para el numero de pedido en daxmed
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
        private System.Decimal _AuxNum1;   // guardar el precio de venta para articulos facturadoscomo cortesia
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
        private System.Decimal _tra_peso;
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
        private System.Int32 _tra_anio = 0;
        private System.Int32 _tra_mes = 0;
        private System.Int32 _tra_dia = 0;
        private System.Int64 _Ramos = 0;
        private System.String _NroCaja = "";
        private System.String _TipCaja = "";
        private System.Int64 _CantCajas = 0;
        private System.Int64 _Largo = 0;
        private System.Int64 _TallXramo = 0;
        private System.Int64 _RamXcaja = 0;
        private System.Int64 _Tallos = 0;
        private System.Decimal _TotPeso = 0;
        private System.String _ZonaProducto = "";
        private System.Decimal _Fulls = 0;
        private System.String _HTS = "";
        private System.String _SGP = "";
        private System.String _Nandina = "";
        private System.String _DetalleItm = "";
        private System.Decimal _Tra_porceniva = 0;
        private System.Decimal _Tra_valoriva = 0;

        private string ajustarAncho(string cadena, int ancho)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
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
                return ajustarAncho(_Tra_nombre, 350);
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
        public System.Boolean Pallevar
        {
            get
            {
                return _Pallevar;
            }
            set
            {
                _Pallevar = value;
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
        public System.String tra_Serie
        {
            get
            {
                return ajustarAncho(_tra_Serie, 20);
            }
            set
            {
                _tra_Serie = value;
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

        public System.Decimal Tra_porceniva
        {
            get
            {
                return _Tra_porceniva;
            }
            set
            {
                _Tra_porceniva = value;
            }
        }

        public System.Decimal Tra_valoriva
        {
            get
            {
                return _Tra_valoriva;
            }
            set
            {
                _Tra_valoriva = value;
            }
        }



        //
        private static string cadenaConexion = @"";
        // La cadena de selección
        public static string CadenaSelect = "SELECT * FROM AdcTra";
        //
        public AdcTra()
        {
        }
        public AdcTra(string conex)
        {
            cadenaConexion = conex;
        }
        // asigna una fila de la tabla a un objeto AdcTra
        private static AdcTra row2AdcTra(DataRow r)
        {
            // asigna a un objeto AdcTra los datos del dataRow indicado
            AdcTra oAdcTra = new AdcTra();
            //
            oAdcTra.Doc_sucursal = r["Doc_sucursal"].ToString();
            oAdcTra.Doc_Bodega = r["Doc_Bodega"].ToString();
            oAdcTra.Opc_documento = r["Opc_documento"].ToString();
            oAdcTra.Doc_numero = System.Decimal.Parse("0" + r["Doc_numero"].ToString());
            oAdcTra.Tra_TipoDoc = r["Tra_TipoDoc"].ToString();
            oAdcTra.Tra_DocSop = r["Tra_DocSop"].ToString();
            oAdcTra.Tra_NumSop = System.Decimal.Parse("0" + r["Tra_NumSop"].ToString());
            oAdcTra.Tra_numlinea = System.Decimal.Parse("0" + r["Tra_numlinea"].ToString());
            oAdcTra.Tra_Codigo = r["Tra_Codigo"].ToString();
            oAdcTra.Tra_docotro = r["Tra_docotro"].ToString();
            oAdcTra.Tra_numotro = System.Decimal.Parse("0" + r["Tra_numotro"].ToString());
            try
            {
                oAdcTra.Tra_fecha = DateTime.Parse(r["Tra_fecha"].ToString());
            }
            catch
            {
                oAdcTra.Tra_fecha = DateTime.Now;
            }
            oAdcTra.Tra_nombre = r["Tra_nombre"].ToString();
            oAdcTra.Tra_cantidad = System.Decimal.Parse("0" + r["Tra_cantidad"].ToString());
            oAdcTra.Tra_costuni = System.Decimal.Parse("0" + r["Tra_costuni"].ToString());
            oAdcTra.Tra_costtot = System.Decimal.Parse("0" + r["Tra_costtot"].ToString());
            oAdcTra.Tra_numprecio = r["Tra_numprecio"].ToString();
            oAdcTra.Tra_descdes = r["Tra_descdes"].ToString();
            oAdcTra.Tra_porcendes = System.Decimal.Parse("0" + r["Tra_porcendes"].ToString());
            oAdcTra.Tra_valordes = System.Decimal.Parse("0" + r["Tra_valordes"].ToString());
            oAdcTra.Tra_valor = System.Decimal.Parse("0" + r["Tra_valor"].ToString());
            oAdcTra.Tra_extension = r["Tra_extension"].ToString();
            try
            {
                oAdcTra.Tra_sniva = System.Boolean.Parse(r["Tra_sniva"].ToString());
            }
            catch
            {
                oAdcTra.Tra_sniva = false;
            }
            try
            {
                oAdcTra.Pallevar = System.Boolean.Parse(r["Pallevar"].ToString());
            }
            catch
            {
                oAdcTra.Pallevar = false;
            }
            oAdcTra.Tra_Individual = r["Tra_Individual"].ToString();
            oAdcTra.Tra_quetipo = r["Tra_quetipo"].ToString();
            oAdcTra.Tra_precuni = System.Decimal.Parse("0" + r["Tra_precuni"].ToString());
            oAdcTra.Tra_prectot = System.Decimal.Parse("0" + r["Tra_prectot"].ToString());
            oAdcTra.Tra_DepDes = r["Tra_DepDes"].ToString();
            oAdcTra.Tra_Estado = System.Int16.Parse("0" + r["Tra_Estado"].ToString());
            oAdcTra.Tra_Oculto = System.Int16.Parse("0" + r["Tra_Oculto"].ToString());
            try { oAdcTra.Tra_Inventario = System.Int16.Parse(r["Tra_Inventario"].ToString()); } catch { }
            try { oAdcTra.Tra_Ventas = System.Int16.Parse(r["Tra_Ventas"].ToString()); } catch { }
            try { oAdcTra.Tra_Compras = System.Int16.Parse(r["Tra_Compras"].ToString()); } catch { }
            try { oAdcTra.Tra_Activo = System.Int16.Parse(r["Tra_Activo"].ToString()); } catch { }
            oAdcTra.Tra_Adicional1 = System.Decimal.Parse("0" + r["Tra_Adicional1"].ToString());
            oAdcTra.Tra_Adicional2 = System.Decimal.Parse("0" + r["Tra_Adicional2"].ToString());
            oAdcTra.Tra_piezas = System.Decimal.Parse("0" + r["Tra_piezas"].ToString());
            oAdcTra.Tra_medida = r["Tra_medida"].ToString();
            oAdcTra.Tra_multiplo = System.Decimal.Parse("0" + r["Tra_multiplo"].ToString());
            try
            {
                oAdcTra.Tra_vence = DateTime.Parse(r["Tra_vence"].ToString());
            }
            catch
            {
                oAdcTra.Tra_vence = oAdcTra.Tra_fecha;
            }
            oAdcTra.tra_Serie = r["tra_Serie"].ToString();
            oAdcTra.IdClaveDoc = System.Decimal.Parse("0" + r["IdClaveDoc"].ToString());
            oAdcTra.Tra_NroLote = r["Tra_NroLote"].ToString();
            oAdcTra.Tra_NroLoteDoc = r["Tra_NroLoteDoc"].ToString();
            try
            {
                oAdcTra.Periodo1 = DateTime.Parse(r["Periodo1"].ToString());
            }
            catch
            {
                oAdcTra.Periodo1 = new DateTime(1900, 1, 1);
            }
            try
            {
                oAdcTra.Periodo2 = DateTime.Parse(r["Periodo2"].ToString());
            }
            catch
            {
                oAdcTra.Periodo2 = new DateTime(1900, 1, 1);
            }
            try
            {
                oAdcTra.FacDesde = DateTime.Parse(r["FacDesde"].ToString());
            }
            catch
            {
                oAdcTra.FacDesde = new DateTime(1900, 1, 1);
            }
            try
            {
                oAdcTra.FacHasta = DateTime.Parse(r["FacHasta"].ToString());
            }
            catch
            {
                oAdcTra.FacHasta = new DateTime(1900, 1, 1);
            }
            oAdcTra.Habitacion = r["Habitacion"].ToString();
            oAdcTra.Mesa = r["Mesa"].ToString();
            oAdcTra.TipoPeriodo = r["TipoPeriodo"].ToString();
            oAdcTra.AuxVar1 = r["AuxVar1"].ToString();
            oAdcTra.AuxVar2 = r["AuxVar2"].ToString();
            oAdcTra.AuxVar3 = r["AuxVar3"].ToString();
            oAdcTra.AuxVar4 = r["AuxVar4"].ToString();
            oAdcTra.AuxVar5 = r["AuxVar5"].ToString();
            oAdcTra.AuxVar6 = r["AuxVar6"].ToString();
            oAdcTra.AuxVar7 = r["AuxVar7"].ToString();
            oAdcTra.AuxVar8 = r["AuxVar8"].ToString();
            oAdcTra.AuxVar9 = r["AuxVar9"].ToString();
            oAdcTra.AuxVar10 = r["AuxVar10"].ToString();
            oAdcTra.AuxVar11 = r["AuxVar11"].ToString();
            oAdcTra.AuxVar12 = r["AuxVar12"].ToString();
            try
            {
                oAdcTra.AuxFec1 = DateTime.Parse(r["AuxFec1"].ToString());
            }
            catch
            {
                oAdcTra.AuxFec1 = new DateTime(1900, 1, 1);
            }
            try
            {
                oAdcTra.AuxFec2 = DateTime.Parse(r["AuxFec2"].ToString());
            }
            catch
            {
                oAdcTra.AuxFec2 = new DateTime(1900, 1, 1);
            }
            try
            {
                oAdcTra.AuxFec3 = DateTime.Parse(r["AuxFec3"].ToString());
            }
            catch
            {
                oAdcTra.AuxFec3 = new DateTime(1900, 1, 1);
            }
            oAdcTra.AuxLog1 = r["AuxLog1"].ToString();
            oAdcTra.AuxLog2 = r["AuxLog2"].ToString();
            oAdcTra.AuxLog3 = r["AuxLog3"].ToString();
            oAdcTra.AuxNum1 = System.Decimal.Parse("0" + r["AuxNum1"].ToString());
            oAdcTra.AuxNum2 = System.Decimal.Parse("0" + r["AuxNum2"].ToString());
            oAdcTra.AuxNum3 = System.Decimal.Parse("0" + r["AuxNum3"].ToString());
            oAdcTra.AuxNum4 = System.Decimal.Parse("0" + r["AuxNum4"].ToString());
            oAdcTra.AuxNum5 = System.Decimal.Parse("0" + r["AuxNum5"].ToString());
            oAdcTra.AuxNum6 = System.Decimal.Parse("0" + r["AuxNum6"].ToString());
            oAdcTra.AuxNum7 = System.Decimal.Parse("0" + r["AuxNum7"].ToString());
            oAdcTra.AuxNum8 = System.Decimal.Parse("0" + r["AuxNum8"].ToString());
            oAdcTra.AuxNum9 = System.Decimal.Parse("0" + r["AuxNum9"].ToString());
            oAdcTra.AuxNum10 = System.Decimal.Parse("0" + r["AuxNum10"].ToString());
            oAdcTra.AuxNum11 = System.Decimal.Parse("0" + r["AuxNum11"].ToString());
            oAdcTra.AuxNum12 = System.Decimal.Parse("0" + r["AuxNum12"].ToString());
            oAdcTra.TipoCosto = r["TipoCosto"].ToString();
            try
            {
                oAdcTra.Recosteo = System.Boolean.Parse(r["Recosteo"].ToString());
            }
            catch
            {
                oAdcTra.Recosteo = false;
            }
            oAdcTra.tra_costo = r["tra_costo"].ToString();
            oAdcTra.tra_empleado = r["tra_empleado"].ToString();
            oAdcTra.tra_directorio = r["tra_directorio"].ToString();
            oAdcTra.tra_dia_proyecto = r["tra_dia_proyecto"].ToString();
            oAdcTra.tra_relacionado = r["tra_relacionado"].ToString();
            oAdcTra.tra_codigoalterno = r["tra_codigoalterno"].ToString();
            try
            {
                oAdcTra.Tra_EsCuenta = System.Boolean.Parse(r["Tra_EsCuenta"].ToString());
            }
            catch
            {
                oAdcTra.Tra_EsCuenta = false;
            }
            oAdcTra.tra_producto = r["tra_producto"].ToString();
            oAdcTra.tra_centroproduccion = r["tra_centroproduccion"].ToString();
            oAdcTra.tra_centroDistribucion = r["tra_centroDistribucion"].ToString();
            oAdcTra.tra_proyecto = r["tra_proyecto"].ToString();
            oAdcTra.tra_peso = System.Decimal.Parse("0" + r["tra_peso"].ToString());
            oAdcTra.CodigoBase = r["CodigoBase"].ToString();
            oAdcTra.Despacho = System.Decimal.Parse("0" + r["Despacho"].ToString());
            oAdcTra.tra_boddestino = r["tra_boddestino"].ToString();
            oAdcTra.tra_sucdestino = r["tra_sucdestino"].ToString();
            oAdcTra.Tra_Talla = r["Tra_Talla"].ToString();
            oAdcTra.Tra_Color = r["Tra_Color"].ToString();
            oAdcTra.Tra_Dibujo = r["Tra_Dibujo"].ToString();
            oAdcTra.Tra_Genero = r["Tra_Genero"].ToString();
            oAdcTra.Tra_Modelo = r["Tra_Modelo"].ToString();
            oAdcTra.Tra_Despachado = r["Tra_Despachado"].ToString();
            oAdcTra.tra_anio = System.Int32.Parse("0" + r["tra_anio"].ToString());
            oAdcTra.tra_mes = System.Int32.Parse("0" + r["tra_mes"].ToString());
            oAdcTra.tra_dia = System.Int32.Parse("0" + r["tra_dia"].ToString());
            oAdcTra.Ramos = System.Int64.Parse("0" + r["Ramos"].ToString());
            oAdcTra.NroCaja = r["NroCaja"].ToString();
            oAdcTra.TipCaja = r["TipCaja"].ToString();
            oAdcTra.CantCajas = System.Int64.Parse("0" + r["CantCajas"].ToString());
            oAdcTra.Largo = System.Int64.Parse("0" + r["Largo"].ToString());
            oAdcTra.TallXramo = System.Int64.Parse("0" + r["TallXramo"].ToString());
            oAdcTra.RamXcaja = System.Int64.Parse("0" + r["RamXcaja"].ToString());
            oAdcTra.Tallos = System.Int64.Parse("0" + r["Tallos"].ToString());
            oAdcTra.TotPeso = System.Decimal.Parse("0" + r["TotPeso"].ToString());
            oAdcTra.Fulls = System.Decimal.Parse("0" + r["Fulls"].ToString());
            oAdcTra.ZonaProducto = r["ZonaProducto"].ToString();
            oAdcTra.SGP = r["SGP"].ToString();
            oAdcTra.Nandina = r["Nandina"].ToString();
            oAdcTra.HTS = r["HTS"].ToString();
            oAdcTra.DetalleItm = r["DetalleItm"].ToString();

            oAdcTra.Tra_porceniva = System.Decimal.Parse("0" + r["Tra_porceniva"].ToString());
            oAdcTra.Tra_valoriva = System.Decimal.Parse("0" + r["Tra_valoriva"].ToString());


            //
            return oAdcTra;
        }
        //
        // asigna un objeto AdcTra a la fila indicada
        private static void AdcTra2Row(AdcTra oAdcTra, DataRow r)
        {
            // asigna un objeto AdcTra al dataRow indicado
            r["Doc_sucursal"] = oAdcTra.Doc_sucursal;
            r["Doc_Bodega"] = oAdcTra.Doc_Bodega;
            r["Opc_documento"] = oAdcTra.Opc_documento;
            r["Doc_numero"] = oAdcTra.Doc_numero;
            r["Tra_TipoDoc"] = oAdcTra.Tra_TipoDoc;
            r["Tra_DocSop"] = oAdcTra.Tra_DocSop;
            r["Tra_NumSop"] = oAdcTra.Tra_NumSop;
            r["Tra_numlinea"] = oAdcTra.Tra_numlinea;
            r["Tra_Codigo"] = oAdcTra.Tra_Codigo;
            r["Tra_docotro"] = oAdcTra.Tra_docotro;
            r["Tra_numotro"] = oAdcTra.Tra_numotro;
            r["Tra_fecha"] = oAdcTra.Tra_fecha;
            r["Tra_nombre"] = oAdcTra.Tra_nombre;
            r["Tra_cantidad"] = oAdcTra.Tra_cantidad;
            r["Tra_costuni"] = oAdcTra.Tra_costuni;
            r["Tra_costtot"] = oAdcTra.Tra_costtot;
            r["Tra_numprecio"] = oAdcTra.Tra_numprecio;
            r["Tra_descdes"] = oAdcTra.Tra_descdes;
            r["Tra_porcendes"] = oAdcTra.Tra_porcendes;
            r["Tra_valordes"] = oAdcTra.Tra_valordes;
            r["Tra_valor"] = oAdcTra.Tra_valor;
            r["Tra_extension"] = oAdcTra.Tra_extension;
            r["Tra_sniva"] = oAdcTra.Tra_sniva;
            r["Pallevar"] = oAdcTra.Pallevar;
            r["Tra_Individual"] = oAdcTra.Tra_Individual;
            r["Tra_quetipo"] = oAdcTra.Tra_quetipo;
            r["Tra_precuni"] = oAdcTra.Tra_precuni;
            r["Tra_prectot"] = oAdcTra.Tra_prectot;
            r["Tra_DepDes"] = oAdcTra.Tra_DepDes;
            r["Tra_Estado"] = oAdcTra.Tra_Estado;
            r["Tra_Oculto"] = oAdcTra.Tra_Oculto;
            r["Tra_Inventario"] = oAdcTra.Tra_Inventario;
            r["Tra_Ventas"] = oAdcTra.Tra_Ventas;
            r["Tra_Compras"] = oAdcTra.Tra_Compras;
            r["Tra_Activo"] = oAdcTra.Tra_Activo;
            r["Tra_Adicional1"] = oAdcTra.Tra_Adicional1;
            r["Tra_Adicional2"] = oAdcTra.Tra_Adicional2;
            r["Tra_piezas"] = oAdcTra.Tra_piezas;
            r["Tra_medida"] = oAdcTra.Tra_medida;
            r["Tra_multiplo"] = oAdcTra.Tra_multiplo;
            r["Tra_vence"] = oAdcTra.Tra_vence;
            r["tra_Serie"] = oAdcTra.tra_Serie;
            r["IdClaveDoc"] = oAdcTra.IdClaveDoc;
            r["Tra_NroLote"] = oAdcTra.Tra_NroLote;
            r["Tra_NroLoteDoc"] = oAdcTra.Tra_NroLoteDoc;
            r["Periodo1"] = oAdcTra.Periodo1;
            r["Periodo2"] = oAdcTra.Periodo2;
            r["FacDesde"] = oAdcTra.FacDesde;
            r["FacHasta"] = oAdcTra.FacHasta;
            r["Habitacion"] = oAdcTra.Habitacion;
            r["Mesa"] = oAdcTra.Mesa;
            r["TipoPeriodo"] = oAdcTra.TipoPeriodo;
            r["AuxVar1"] = oAdcTra.AuxVar1;
            r["AuxVar2"] = oAdcTra.AuxVar2;
            r["AuxVar3"] = oAdcTra.AuxVar3;
            r["AuxVar4"] = oAdcTra.AuxVar4;
            r["AuxVar5"] = oAdcTra.AuxVar5;
            r["AuxVar6"] = oAdcTra.AuxVar6;
            r["AuxVar7"] = oAdcTra.AuxVar7;
            r["AuxVar8"] = oAdcTra.AuxVar8;
            r["AuxVar9"] = oAdcTra.AuxVar9;
            r["AuxVar10"] = oAdcTra.AuxVar10;
            r["AuxVar11"] = oAdcTra.AuxVar11;
            r["AuxVar12"] = oAdcTra.AuxVar12;
            r["AuxFec1"] = oAdcTra.AuxFec1;
            r["AuxFec2"] = oAdcTra.AuxFec2;
            r["AuxFec3"] = oAdcTra.AuxFec3;
            r["AuxLog1"] = oAdcTra.AuxLog1;
            r["AuxLog2"] = oAdcTra.AuxLog2;
            r["AuxLog3"] = oAdcTra.AuxLog3;
            r["AuxNum1"] = oAdcTra.AuxNum1;
            r["AuxNum2"] = oAdcTra.AuxNum2;
            r["AuxNum3"] = oAdcTra.AuxNum3;
            r["AuxNum4"] = oAdcTra.AuxNum4;
            r["AuxNum5"] = oAdcTra.AuxNum5;
            r["AuxNum6"] = oAdcTra.AuxNum6;
            r["AuxNum7"] = oAdcTra.AuxNum7;
            r["AuxNum8"] = oAdcTra.AuxNum8;
            r["AuxNum9"] = oAdcTra.AuxNum9;
            r["AuxNum10"] = oAdcTra.AuxNum10;
            r["AuxNum11"] = oAdcTra.AuxNum11;
            r["AuxNum12"] = oAdcTra.AuxNum12;
            r["TipoCosto"] = oAdcTra.TipoCosto;
            r["Recosteo"] = oAdcTra.Recosteo;
            r["tra_costo"] = oAdcTra.tra_costo;
            r["tra_empleado"] = oAdcTra.tra_empleado;
            r["tra_directorio"] = oAdcTra.tra_directorio;
            r["tra_dia_proyecto"] = oAdcTra.tra_dia_proyecto;
            r["tra_relacionado"] = oAdcTra.tra_relacionado;
            r["tra_codigoalterno"] = oAdcTra.tra_codigoalterno;
            r["Tra_EsCuenta"] = oAdcTra.Tra_EsCuenta;
            r["tra_producto"] = oAdcTra.tra_producto;
            r["tra_centroproduccion"] = oAdcTra.tra_centroproduccion;
            r["tra_centroDistribucion"] = oAdcTra.tra_centroDistribucion;
            r["tra_proyecto"] = oAdcTra.tra_proyecto;
            r["tra_peso"] = oAdcTra.tra_peso;
            r["CodigoBase"] = oAdcTra.CodigoBase;
            r["Despacho"] = oAdcTra.Despacho;
            r["tra_boddestino"] = oAdcTra.tra_boddestino;
            r["tra_sucdestino"] = oAdcTra.tra_sucdestino;
            r["Tra_Talla"] = oAdcTra.Tra_Talla;
            r["Tra_Color"] = oAdcTra.Tra_Color;
            r["Tra_Dibujo"] = oAdcTra.Tra_Dibujo;
            r["Tra_Genero"] = oAdcTra.Tra_Genero;
            r["Tra_Modelo"] = oAdcTra.Tra_Modelo;
            r["Tra_Despachado"] = oAdcTra.Tra_Despachado;
            r["tra_anio"] = oAdcTra.tra_anio;
            r["tra_mes"] = oAdcTra.tra_mes;
            r["tra_dia"] = oAdcTra.tra_dia;
            r["Ramos"] = oAdcTra.Ramos;
            r["NroCaja"] = oAdcTra.NroCaja;
            r["TipCaja"] = oAdcTra.TipCaja;
            r["CantCajas"] = oAdcTra.CantCajas;
            r["Largo"] = oAdcTra.Largo;
            r["TallXramo"] = oAdcTra.TallXramo;
            r["RamXcaja"] = oAdcTra.RamXcaja;
            r["Tallos"] = oAdcTra.Tallos;
            r["TotPeso"] = oAdcTra.TotPeso;
            r["Fulls"] = oAdcTra.Fulls;
            r["ZonaProducto"] = oAdcTra.ZonaProducto;
            r["SGP"] = oAdcTra.SGP;
            r["Nandina"] = oAdcTra.Nandina;
            r["HTS"] = oAdcTra.HTS;
            r["DetalleItm"] = oAdcTra.DetalleItm;

        }
        public void moverAdctraDatarow(AdcTra oAdcTra, ref DataRow r)
        {
            // asigna un objeto AdcTra al dataRow indicado
            r["Doc_sucursal"] = oAdcTra.Doc_sucursal;
            r["Doc_Bodega"] = oAdcTra.Doc_Bodega;
            r["Opc_documento"] = oAdcTra.Opc_documento;
            r["Doc_numero"] = oAdcTra.Doc_numero;
            r["Tra_TipoDoc"] = oAdcTra.Tra_TipoDoc;
            r["Tra_DocSop"] = oAdcTra.Tra_DocSop;
            r["Tra_NumSop"] = oAdcTra.Tra_NumSop;
            r["Tra_numlinea"] = oAdcTra.Tra_numlinea;
            r["Tra_Codigo"] = oAdcTra.Tra_Codigo;
            r["Tra_docotro"] = oAdcTra.Tra_docotro;
            r["Tra_numotro"] = oAdcTra.Tra_numotro;
            r["Tra_fecha"] = oAdcTra.Tra_fecha;
            r["Tra_nombre"] = oAdcTra.Tra_nombre;
            r["Tra_cantidad"] = oAdcTra.Tra_cantidad;
            r["Tra_costuni"] = oAdcTra.Tra_costuni;
            r["Tra_costtot"] = oAdcTra.Tra_costtot;
            r["Tra_numprecio"] = oAdcTra.Tra_numprecio;
            r["Tra_descdes"] = oAdcTra.Tra_descdes;
            r["Tra_porcendes"] = oAdcTra.Tra_porcendes;
            r["Tra_valordes"] = oAdcTra.Tra_valordes;
            r["Tra_valor"] = oAdcTra.Tra_valor;
            r["Tra_extension"] = oAdcTra.Tra_extension;
            r["Tra_sniva"] = oAdcTra.Tra_sniva;
            r["Pallevar"] = oAdcTra.Pallevar;
            r["Tra_Individual"] = oAdcTra.Tra_Individual;
            r["Tra_quetipo"] = oAdcTra.Tra_quetipo;
            r["Tra_precuni"] = oAdcTra.Tra_precuni;
            r["Tra_prectot"] = oAdcTra.Tra_prectot;
            r["Tra_DepDes"] = oAdcTra.Tra_DepDes;
            r["Tra_Estado"] = oAdcTra.Tra_Estado;
            r["Tra_Oculto"] = oAdcTra.Tra_Oculto;
            r["Tra_Inventario"] = oAdcTra.Tra_Inventario;
            r["Tra_Ventas"] = oAdcTra.Tra_Ventas;
            r["Tra_Compras"] = oAdcTra.Tra_Compras;
            r["Tra_Activo"] = oAdcTra.Tra_Activo;
            r["Tra_Adicional1"] = oAdcTra.Tra_Adicional1;
            r["Tra_Adicional2"] = oAdcTra.Tra_Adicional2;
            r["Tra_piezas"] = oAdcTra.Tra_piezas;
            r["Tra_medida"] = oAdcTra.Tra_medida;
            r["Tra_multiplo"] = oAdcTra.Tra_multiplo;
            r["Tra_vence"] = oAdcTra.Tra_vence;
            r["tra_Serie"] = oAdcTra.tra_Serie;
            r["IdClaveDoc"] = oAdcTra.IdClaveDoc;
            r["Tra_NroLote"] = oAdcTra.Tra_NroLote;
            r["Tra_NroLoteDoc"] = oAdcTra.Tra_NroLoteDoc;
            r["Periodo1"] = oAdcTra.Periodo1;
            r["Periodo2"] = oAdcTra.Periodo2;
            r["FacDesde"] = oAdcTra.FacDesde;
            r["FacHasta"] = oAdcTra.FacHasta;
            r["Habitacion"] = oAdcTra.Habitacion;
            r["Mesa"] = oAdcTra.Mesa;
            r["TipoPeriodo"] = oAdcTra.TipoPeriodo;
            r["AuxVar1"] = oAdcTra.AuxVar1;
            r["AuxVar2"] = oAdcTra.AuxVar2;
            r["AuxVar3"] = oAdcTra.AuxVar3;
            r["AuxVar4"] = oAdcTra.AuxVar4;
            r["AuxVar5"] = oAdcTra.AuxVar5;
            r["AuxVar6"] = oAdcTra.AuxVar6;
            r["AuxVar7"] = oAdcTra.AuxVar7;
            r["AuxVar8"] = oAdcTra.AuxVar8;
            r["AuxVar9"] = oAdcTra.AuxVar9;
            r["AuxVar10"] = oAdcTra.AuxVar10;
            r["AuxVar11"] = oAdcTra.AuxVar11;
            r["AuxVar12"] = oAdcTra.AuxVar12;
            r["AuxFec1"] = oAdcTra.AuxFec1;
            r["AuxFec2"] = oAdcTra.AuxFec2;
            r["AuxFec3"] = oAdcTra.AuxFec3;
            r["AuxLog1"] = oAdcTra.AuxLog1;
            r["AuxLog2"] = oAdcTra.AuxLog2;
            r["AuxLog3"] = oAdcTra.AuxLog3;
            r["AuxNum1"] = oAdcTra.AuxNum1;
            r["AuxNum2"] = oAdcTra.AuxNum2;
            r["AuxNum3"] = oAdcTra.AuxNum3;
            r["AuxNum4"] = oAdcTra.AuxNum4;
            r["AuxNum5"] = oAdcTra.AuxNum5;
            r["AuxNum6"] = oAdcTra.AuxNum6;
            r["AuxNum7"] = oAdcTra.AuxNum7;
            r["AuxNum8"] = oAdcTra.AuxNum8;
            r["AuxNum9"] = oAdcTra.AuxNum9;
            r["AuxNum10"] = oAdcTra.AuxNum10;
            r["AuxNum11"] = oAdcTra.AuxNum11;
            r["AuxNum12"] = oAdcTra.AuxNum12;
            r["TipoCosto"] = oAdcTra.TipoCosto;
            r["Recosteo"] = oAdcTra.Recosteo;
            r["tra_costo"] = oAdcTra.tra_costo;
            r["tra_empleado"] = oAdcTra.tra_empleado;
            r["tra_directorio"] = oAdcTra.tra_directorio;
            r["tra_dia_proyecto"] = oAdcTra.tra_dia_proyecto;
            r["tra_relacionado"] = oAdcTra.tra_relacionado;
            r["tra_codigoalterno"] = oAdcTra.tra_codigoalterno;
            r["Tra_EsCuenta"] = oAdcTra.Tra_EsCuenta;
            r["tra_producto"] = oAdcTra.tra_producto;
            r["tra_centroproduccion"] = oAdcTra.tra_centroproduccion;
            r["tra_centroDistribucion"] = oAdcTra.tra_centroDistribucion;
            r["tra_proyecto"] = oAdcTra.tra_proyecto;
            r["tra_peso"] = oAdcTra.tra_peso;
            r["CodigoBase"] = oAdcTra.CodigoBase;
            r["Despacho"] = oAdcTra.Despacho;
            r["tra_boddestino"] = oAdcTra.tra_boddestino;
            r["tra_sucdestino"] = oAdcTra.tra_sucdestino;
            r["Tra_Talla"] = oAdcTra.Tra_Talla;
            r["Tra_Color"] = oAdcTra.Tra_Color;
            r["Tra_Dibujo"] = oAdcTra.Tra_Dibujo;
            r["Tra_Genero"] = oAdcTra.Tra_Genero;
            r["Tra_Modelo"] = oAdcTra.Tra_Modelo;
            r["Tra_Despachado"] = oAdcTra.Tra_Despachado;
            r["tra_anio"] = oAdcTra.tra_anio;
            r["tra_mes"] = oAdcTra.tra_mes;
            r["tra_dia"] = oAdcTra.tra_dia;
            r["Ramos"] = oAdcTra.Ramos;
            r["NroCaja"] = oAdcTra.NroCaja;
            r["TipCaja"] = oAdcTra.TipCaja;
            r["CantCajas"] = oAdcTra.CantCajas;
            r["Largo"] = oAdcTra.Largo;
            r["TallXramo"] = oAdcTra.TallXramo;
            r["RamXcaja"] = oAdcTra.RamXcaja;
            r["Tallos"] = oAdcTra.Tallos;
            r["Fulls"] = oAdcTra.Fulls;
            r["ZonaProducto"] = oAdcTra.ZonaProducto;
            r["SGP"] = oAdcTra.SGP;
            r["Nandina"] = oAdcTra.Nandina;
            r["HTS"] = oAdcTra.HTS; ;
            r["DetalleItm"] = oAdcTra.DetalleItm;

            r["Tra_porceniva"] = oAdcTra.Tra_porceniva;
            r["Tra_valoriva"] = oAdcTra.Tra_valoriva;

        }

        //
        // crea una nueva fila y la asigna a un objeto AdcTra
        public static void nuevoAdcTra(DataTable dt, AdcTra oAdcTra)
        {
            // Crear un nuevo AdcTra
            DataRow dr = dt.NewRow();
            AdcTra oA = new AdcTra();
            //
            AdcTra2Row(oAdcTra, dr);
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
            // devuelve una tabla con los datos de la tabla AdcTra
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcTra");
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
        public static AdcTra Buscar(string sWhere)
        {
            // Busca en la tabla los datos indicados en el parámetro
            // el parámetro contendrá lo que se usará después del WHERE
            AdcTra oAdcTra = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcTra");
            string sel = "SELECT * FROM AdcTra WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oAdcTra = row2AdcTra(dt.Rows[0]);
            }
            return oAdcTra;
        }
        //
        public string Actualizar()
        {
            string sel = "SELECT * FROM AdcTra WHERE doc_sucursal = '" + Doc_sucursal + "' and opc_documento = '" + Opc_documento + "' and idclavedoc = " + IdClaveDoc.ToString(); ;
            return Actualizar(sel);
        }
        public string Actualizar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcTra");
            //
            cnn = new SqlConnection(cadenaConexion);
            da = new SqlDataAdapter(sel, cnn);
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
                AdcTra2Row(this, dt.Rows[0]);
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
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcTra");
            CadenaSelect = "SELECT * FROM AdcTra WHERE doc_sucursal = '" + Doc_sucursal + "' and opc_documento = '" + Opc_documento + "' and idclavedoc = " + IdClaveDoc.ToString();
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
            nuevoAdcTra(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo AdcTra";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            string sel = "SELECT * FROM AdcTra WHERE WHERE doc_sucursal = '" + Doc_sucursal + "' and opc_documento = '" + Opc_documento + "' and idclavedoc = " + IdClaveDoc.ToString();
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcTra");
            //
            cnn = new SqlConnection(cadenaConexion);
            da = new SqlDataAdapter(sel, cnn);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
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