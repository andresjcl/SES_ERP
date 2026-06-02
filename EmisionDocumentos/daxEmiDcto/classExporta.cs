using System;
using System.Data;
using System.Data.SqlClient;
//
namespace daxEmiFacPv
{
    public class classExporta
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private string _conexiondata ="";
        private System.String _Doc_Sucursal="";
        private System.String _Opc_documento="";
        private System.String _Ciudad="";
        private System.String _Estado="";
        private System.String _ClienteConsig="";
        private System.String _CiudadConsig="";
        private System.String _EstadoConsig="";
        private System.String _PedidoNo="";
        private System.String _PuertoDest="";
        private System.String _ViaEmbarque="";
        private System.String _EquipoNro="";
        private System.DateTime _fechaEmb=DateTime.Now;
        private System.DateTime _FechaEmbIngles = DateTime.Now;
        private System.String _DespachoParcial="";
        private System.String _CondicionesPag="";
        private System.String _OrigenProforma="";
        private System.String _Marcas="";
        private System.String _Idioma="";
        private System.DateTime _FechaReq = DateTime.Now;
        private System.String _TerminosVent="";
        private System.String _SeguroTipo="";
        private System.String _OrigProducto="";
        private System.String _PartidaArancelaria="";
        private System.String _UnidadEntrada="";
        private System.String _UnidadSalida="";
        private System.String _ObsDetalle="";
        private string _Fue ="";
        private System.String _Flete = "";
        private System.String _CiudadFOB="";
        private System.String _Seguro="";
        private System.String _Embarque_Aprox="";
        private System.String _pedido="";
        private System.String _EndosarCod="";
        private System.String _condicionesVenta="";
        private System.String _embarque="";
        private System.String _Transporte="";
        private System.String _valorFob="";
        private System.String _EndosarNom="";
        private System.String _transportarNom="";
        private System.String _consignarNom="";
        private System.String _paisAdquisicion="";
        private System.String _seguroInternacional="";
        private System.String _gastosAduana="";
        private System.String _gastosTransporte="";
        private System.Decimal _TotalPesoNeto = 0;
        private System.Decimal _TotalPesoBruto = 0;
        private System.Decimal _NumeroPagos = 0;
        private System.Decimal _Doc_numero = 0;
        private System.Decimal _IdClaveDoc = 0;
        private System.Decimal _CantidadEquip = 0;
        private System.Decimal _PlazoPagos = 0;
        private System.Decimal _Anticipo = 0;
        private System.Int32 _exportacionDe = 0;
        private System.String _tipoComprobante="";
        private System.String _disAduanero="";
        private System.String _regimen="";
        private System.String _correlativo="";
        private System.String _verificador="";
        private System.String _fechaEmbarque="";
        private System.String _valorFobComprobante="";
        private System.String _docTransp="";
        private System.String _anio="";

        private string ajustarAncho(string cadena, int ancho)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
            return (cadena + sb.ToString()).Substring(0, ancho).Trim();
        }
        public System.String conexiondata
        {
            get
            {
                return ajustarAncho(_conexiondata, 250);
            }
            set
            {
                _conexiondata = value;
                cadenaConexion = value;
            }
        }

        public System.String Doc_Sucursal
        {
            get
            {
                return ajustarAncho(_Doc_Sucursal, 3);
            }
            set
            {
                _Doc_Sucursal = value;
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
        public System.String Ciudad
        {
            get
            {
                return ajustarAncho(_Ciudad, 50);
            }
            set
            {
                _Ciudad = value;
            }
        }
        public System.String Estado
        {
            get
            {
                return ajustarAncho(_Estado, 50);
            }
            set
            {
                _Estado = value;
            }
        }
        public System.String ClienteConsig
        {
            get
            {
                return ajustarAncho(_ClienteConsig, 80);
            }
            set
            {
                _ClienteConsig = value;
            }
        }
        public System.String CiudadConsig
        {
            get
            {
                return ajustarAncho(_CiudadConsig, 80);
            }
            set
            {
                _CiudadConsig = value;
            }
        }
        public System.String EstadoConsig
        {
            get
            {
                return ajustarAncho(_EstadoConsig, 50);
            }
            set
            {
                _EstadoConsig = value;
            }
        }
        public System.String PedidoNo
        {
            get
            {
                return ajustarAncho(_PedidoNo, 60);
            }
            set
            {
                _PedidoNo = value;
            }
        }
        public System.String PuertoDest
        {
            get
            {
                return ajustarAncho(_PuertoDest, 80);
            }
            set
            {
                _PuertoDest = value;
            }
        }
        public System.String ViaEmbarque
        {
            get
            {
                return ajustarAncho(_ViaEmbarque, 80);
            }
            set
            {
                _ViaEmbarque = value;
            }
        }
        public System.String EquipoNro
        {
            get
            {
                return ajustarAncho(_EquipoNro, 20);
            }
            set
            {
                _EquipoNro = value;
            }
        }
        public System.Decimal CantidadEquip
        {
            get
            {
                return _CantidadEquip;
            }
            set
            {
                _CantidadEquip = value;
            }
        }
        public System.DateTime fechaEmb
        {
            get
            {
                return _fechaEmb;
            }
            set
            {
                _fechaEmb = value;
            }
        }
        public System.DateTime FechaEmbIngles
        {
            get
            {
                return _FechaEmbIngles;
            }
            set
            {
                _FechaEmbIngles = value;
            }
        }
        public System.String DespachoParcial
        {
            get
            {
                return ajustarAncho(_DespachoParcial, 20);
            }
            set
            {
                _DespachoParcial = value;
            }
        }
        public System.String CondicionesPag
        {
            get
            {
                return ajustarAncho(_CondicionesPag, 80);
            }
            set
            {
                _CondicionesPag = value;
            }
        }
        public System.Decimal NumeroPagos
        {
            get
            {
                return _NumeroPagos;
            }
            set
            {
                _NumeroPagos = value;
            }
        }
        public System.Decimal PlazoPagos
        {
            get
            {
                return _PlazoPagos;
            }
            set
            {
                _PlazoPagos = value;
            }
        }
        public System.Decimal Anticipo
        {
            get
            {
                return _Anticipo;
            }
            set
            {
                _Anticipo = value;
            }
        }
        public System.String OrigenProforma
        {
            get
            {
                return ajustarAncho(_OrigenProforma, 50);
            }
            set
            {
                _OrigenProforma = value;
            }
        }
        public System.String Marcas
        {
            get
            {
                return ajustarAncho(_Marcas, 150);
            }
            set
            {
                _Marcas = value;
            }
        }
        public System.String Idioma
        {
            get
            {
                return ajustarAncho(_Idioma, 20);
            }
            set
            {
                _Idioma = value;
            }
        }
        public System.DateTime FechaReq
        {
            get
            {
                return _FechaReq;
            }
            set
            {
                _FechaReq = value;
            }
        }
        public System.String TerminosVent
        {
            get
            {
                return ajustarAncho(_TerminosVent, 80);
            }
            set
            {
                _TerminosVent = value;
            }
        }
        public System.String SeguroTipo
        {
            get
            {
                return ajustarAncho(_SeguroTipo, 80);
            }
            set
            {
                _SeguroTipo = value;
            }
        }
        public System.String OrigProducto
        {
            get
            {
                return ajustarAncho(_OrigProducto, 80);
            }
            set
            {
                _OrigProducto = value;
            }
        }
        public System.String PartidaArancelaria
        {
            get
            {
                return ajustarAncho(_PartidaArancelaria, 50);
            }
            set
            {
                _PartidaArancelaria = value;
            }
        }
        public System.String UnidadEntrada
        {
            get
            {
                return ajustarAncho(_UnidadEntrada, 10);
            }
            set
            {
                _UnidadEntrada = value;
            }
        }
        public System.String UnidadSalida
        {
            get
            {
                return ajustarAncho(_UnidadSalida, 10);
            }
            set
            {
                _UnidadSalida = value;
            }
        }
        public System.String ObsDetalle
        {
            get
            {
                return ajustarAncho(_ObsDetalle, 150);
            }
            set
            {
                _ObsDetalle = value;
            }
        }
        public System.String Fue
        {
            get
            {
                return ajustarAncho(_Fue, 50);
            }
            set
            {
                _Fue = value;
            }
        }
        public System.Decimal TotalPesoNeto
        {
            get
            {
                return _TotalPesoNeto;
            }
            set
            {
                _TotalPesoNeto = value;
            }
        }
        public System.Decimal TotalPesoBruto
        {
            get
            {
                return _TotalPesoBruto;
            }
            set
            {
                _TotalPesoBruto = value;
            }
        }
        public System.String Flete
        {
            get
            {
                return ajustarAncho(_Flete, 50);
            }
            set
            {
                _Flete = value;
            }
        }
        public System.String CiudadFOB
        {
            get
            {
                return ajustarAncho(_CiudadFOB, 20);
            }
            set
            {
                _CiudadFOB = value;
            }
        }
        public System.String Seguro
        {
            get
            {
                return ajustarAncho(_Seguro, 60);
            }
            set
            {
                _Seguro = value;
            }
        }
        public System.String Embarque_Aprox
        {
            get
            {
                return ajustarAncho(_Embarque_Aprox, 150);
            }
            set
            {
                _Embarque_Aprox = value;
            }
        }
        public System.String pedido
        {
            get
            {
                return ajustarAncho(_pedido, 60);
            }
            set
            {
                _pedido = value;
            }
        }
        public System.String EndosarCod
        {
            get
            {
                return ajustarAncho(_EndosarCod, 50);
            }
            set
            {
                _EndosarCod = value;
            }
        }
        public System.String condicionesVenta
        {
            get
            {
                return ajustarAncho(_condicionesVenta, 50);
            }
            set
            {
                _condicionesVenta = value;
            }
        }
        public System.String embarque
        {
            get
            {
                return ajustarAncho(_embarque, 50);
            }
            set
            {
                _embarque = value;
            }
        }
        public System.String Transporte
        {
            get
            {
                return ajustarAncho(_Transporte, 50);
            }
            set
            {
                _Transporte = value;
            }
        }
        public System.String valorFob
        {
            get
            {
                return ajustarAncho(_valorFob, 50);
            }
            set
            {
                _valorFob = value;
            }
        }
        public System.String EndosarNom
        {
            get
            {
                return ajustarAncho(_EndosarNom, 100);
            }
            set
            {
                _EndosarNom = value;
            }
        }
        public System.String transportarNom
        {
            get
            {
                return ajustarAncho(_transportarNom, 100);
            }
            set
            {
                _transportarNom = value;
            }
        }
        public System.String consignarNom
        {
            get
            {
                return ajustarAncho(_consignarNom, 100);
            }
            set
            {
                _consignarNom = value;
            }
        }
        public System.String paisAdquisicion
        {
            get
            {
                return ajustarAncho(_paisAdquisicion, 50);
            }
            set
            {
                _paisAdquisicion = value;
            }
        }
        public System.String seguroInternacional
        {
            get
            {
                return ajustarAncho(_seguroInternacional, 25);
            }
            set
            {
                _seguroInternacional = value;
            }
        }
        public System.String gastosAduana
        {
            get
            {
                return ajustarAncho(_gastosAduana, 25);
            }
            set
            {
                _gastosAduana = value;
            }
        }
        public System.String gastosTransporte
        {
            get
            {
                return ajustarAncho(_gastosTransporte, 25);
            }
            set
            {
                _gastosTransporte = value;
            }
        }
        public System.Int32 exportacionDe
        {
            get
            {
                return _exportacionDe;
            }
            set
            {
                _exportacionDe = value;
            }
        }
        public System.String tipoComprobante
        {
            get
            {
                return ajustarAncho(_tipoComprobante, 20);
            }
            set
            {
                _tipoComprobante = value;
            }
        }
        public System.String disAduanero
        {
            get
            {
                return ajustarAncho(_disAduanero, 20);
            }
            set
            {
                _disAduanero = value;
            }
        }
        public System.String regimen
        {
            get
            {
                return ajustarAncho(_regimen, 20);
            }
            set
            {
                _regimen = value;
            }
        }
        public System.String correlativo
        {
            get
            {
                return ajustarAncho(_correlativo, 20);
            }
            set
            {
                _correlativo = value;
            }
        }
        public System.String verificador
        {
            get
            {
                return ajustarAncho(_verificador, 20);
            }
            set
            {
                _verificador = value;
            }
        }
        public System.String fechaEmbarque
        {
            get
            {
                return ajustarAncho(_fechaEmbarque, 20);
            }
            set
            {
                _fechaEmbarque = value;
            }
        }
        public System.String valorFobComprobante
        {
            get
            {
                return ajustarAncho(_valorFobComprobante, 20);
            }
            set
            {
                _valorFobComprobante = value;
            }
        }
        public System.String docTransp
        {
            get
            {
                return ajustarAncho(_docTransp, 20);
            }
            set
            {
                _docTransp = value;
            }
        }
        public System.String anio
        {
            get
            {
                return ajustarAncho(_anio,4);
            }
            set
            {
                _anio = value;
            }
        }
        //
        private static string cadenaConexion = @"Data Source=patoopc; Initial Catalog=bdadcomdx_procaesa; user id=sa; password=123qweASDZXC";
        // La cadena de selección
        public static string CadenaSelect = "SELECT * FROM Exportacion";
        //
        public classExporta()
        {
        }
        public classExporta(string conex)
        {
            cadenaConexion = conex;
        }
        // asigna una fila de la tabla a un objeto Exportacion
        private static classExporta row2Exportacion(DataRow r)
        {
            // asigna a un objeto Exportacion los datos del dataRow indicado
            classExporta oExportacion = new classExporta();
            //
            oExportacion.Doc_Sucursal = r["Doc_Sucursal"].ToString();
            oExportacion.Opc_documento = r["Opc_documento"].ToString();
            oExportacion.Doc_numero = System.Decimal.Parse("0" + r["Doc_numero"].ToString());
            oExportacion.IdClaveDoc = System.Decimal.Parse("0" + r["IdClaveDoc"].ToString());
            oExportacion.Ciudad = r["Ciudad"].ToString();
            oExportacion.Estado = r["Estado"].ToString();
            oExportacion.ClienteConsig = r["ClienteConsig"].ToString();
            oExportacion.CiudadConsig = r["CiudadConsig"].ToString();
            oExportacion.EstadoConsig = r["EstadoConsig"].ToString();
            oExportacion.PedidoNo = r["PedidoNo"].ToString();
            oExportacion.PuertoDest = r["PuertoDest"].ToString();
            oExportacion.ViaEmbarque = r["ViaEmbarque"].ToString();
            oExportacion.EquipoNro = r["EquipoNro"].ToString();
            oExportacion.CantidadEquip = System.Decimal.Parse("0" + r["CantidadEquip"].ToString());
            try
            {
                oExportacion.fechaEmb = DateTime.Parse(r["fechaEmb"].ToString());
            }
            catch
            {
                oExportacion.fechaEmb = DateTime.Now;
            }
            try
            {
                oExportacion.FechaEmbIngles = DateTime.Parse(r["FechaEmbIngles"].ToString());
            }
            catch
            {
                oExportacion.FechaEmbIngles = DateTime.Now;
            }
            oExportacion.DespachoParcial = r["DespachoParcial"].ToString();
            oExportacion.CondicionesPag = r["CondicionesPag"].ToString();
            oExportacion.NumeroPagos = System.Decimal.Parse("0" + r["NumeroPagos"].ToString());
            oExportacion.PlazoPagos = System.Decimal.Parse("0" + r["PlazoPagos"].ToString());
            oExportacion.Anticipo = System.Decimal.Parse("0" + r["Anticipo"].ToString());
            oExportacion.OrigenProforma = r["OrigenProforma"].ToString();
            oExportacion.Marcas = r["Marcas"].ToString();
            oExportacion.Idioma = r["Idioma"].ToString();
            try
            {
                oExportacion.FechaReq = DateTime.Parse(r["FechaReq"].ToString());
            }
            catch
            {
                oExportacion.FechaReq = DateTime.Now;
            }
            oExportacion.TerminosVent = r["TerminosVent"].ToString();
            oExportacion.SeguroTipo = r["SeguroTipo"].ToString();
            oExportacion.OrigProducto = r["OrigProducto"].ToString();
            oExportacion.PartidaArancelaria = r["PartidaArancelaria"].ToString();
            oExportacion.UnidadEntrada = r["UnidadEntrada"].ToString();
            oExportacion.UnidadSalida = r["UnidadSalida"].ToString();
            oExportacion.ObsDetalle = r["ObsDetalle"].ToString();
            oExportacion.Fue = r["Fue"].ToString();
            oExportacion.TotalPesoNeto = System.Decimal.Parse("0" + r["TotalPesoNeto"].ToString());
            oExportacion.TotalPesoBruto = System.Decimal.Parse("0" + r["TotalPesoBruto"].ToString());
            oExportacion.Flete = r["Flete"].ToString();
            oExportacion.CiudadFOB = r["CiudadFOB"].ToString();
            oExportacion.Seguro = r["Seguro"].ToString();
            oExportacion.Embarque_Aprox = r["Embarque_Aprox"].ToString();
            oExportacion.pedido = r["pedido"].ToString();
            oExportacion.EndosarCod = r["EndosarCod"].ToString();
            oExportacion.condicionesVenta = r["condicionesVenta"].ToString();
            oExportacion.embarque = r["embarque"].ToString();
            oExportacion.Transporte = r["Transporte"].ToString();
            oExportacion.valorFob = r["valorFob"].ToString();
            oExportacion.EndosarNom = r["EndosarNom"].ToString();
            oExportacion.transportarNom = r["transportarNom"].ToString();
            oExportacion.consignarNom = r["consignarNom"].ToString();
            oExportacion.paisAdquisicion = r["paisAdquisicion"].ToString();
            oExportacion.seguroInternacional = r["seguroInternacional"].ToString();
            oExportacion.gastosAduana = r["gastosAduana"].ToString();
            oExportacion.gastosTransporte = r["gastosTransporte"].ToString();
            oExportacion.exportacionDe = System.Int32.Parse("0" + r["exportacionDe"].ToString());
            oExportacion.tipoComprobante = r["tipoComprobante"].ToString();
            oExportacion.disAduanero = r["disAduanero"].ToString();
            oExportacion.regimen = r["regimen"].ToString();
            oExportacion.correlativo = r["correlativo"].ToString();
            oExportacion.verificador = r["verificador"].ToString();
            oExportacion.fechaEmbarque = r["fechaEmbarque"].ToString();
            oExportacion.valorFobComprobante = r["valorFobComprobante"].ToString();
            oExportacion.docTransp = r["docTransp"].ToString();
            oExportacion.anio = r["anio"].ToString();
            //
            return oExportacion;
        }
        //
        // asigna un objeto Exportacion a la fila indicada
        private static void Exportacion2Row(classExporta oExportacion, DataRow r)
        {
            // asigna un objeto Exportacion al dataRow indicado
            r["Doc_Sucursal"] = oExportacion.Doc_Sucursal;
            r["Opc_documento"] = oExportacion.Opc_documento;
            r["Doc_numero"] = oExportacion.Doc_numero;
            r["IdClaveDoc"] = oExportacion.IdClaveDoc;
            r["Ciudad"] = oExportacion.Ciudad;
            r["Estado"] = oExportacion.Estado;
            r["ClienteConsig"] = oExportacion.ClienteConsig;
            r["CiudadConsig"] = oExportacion.CiudadConsig;
            r["EstadoConsig"] = oExportacion.EstadoConsig;
            r["PedidoNo"] = oExportacion.PedidoNo;
            r["PuertoDest"] = oExportacion.PuertoDest;
            r["ViaEmbarque"] = oExportacion.ViaEmbarque;
            r["EquipoNro"] = oExportacion.EquipoNro;
            r["CantidadEquip"] = oExportacion.CantidadEquip;
            r["fechaEmb"] = oExportacion.fechaEmb;
            r["FechaEmbIngles"] = oExportacion.FechaEmbIngles;
            r["DespachoParcial"] = oExportacion.DespachoParcial;
            r["CondicionesPag"] = oExportacion.CondicionesPag;
            r["NumeroPagos"] = oExportacion.NumeroPagos;
            r["PlazoPagos"] = oExportacion.PlazoPagos;
            r["Anticipo"] = oExportacion.Anticipo;
            r["OrigenProforma"] = oExportacion.OrigenProforma;
            r["Marcas"] = oExportacion.Marcas;
            r["Idioma"] = oExportacion.Idioma;
            r["FechaReq"] = oExportacion.FechaReq;
            r["TerminosVent"] = oExportacion.TerminosVent;
            r["SeguroTipo"] = oExportacion.SeguroTipo;
            r["OrigProducto"] = oExportacion.OrigProducto;
            r["PartidaArancelaria"] = oExportacion.PartidaArancelaria;
            r["UnidadEntrada"] = oExportacion.UnidadEntrada;
            r["UnidadSalida"] = oExportacion.UnidadSalida;
            r["ObsDetalle"] = oExportacion.ObsDetalle;
            r["Fue"] = oExportacion.Fue;
            r["TotalPesoNeto"] = oExportacion.TotalPesoNeto;
            r["TotalPesoBruto"] = oExportacion.TotalPesoBruto;
            r["Flete"] = oExportacion.Flete;
            r["CiudadFOB"] = oExportacion.CiudadFOB;
            r["Seguro"] = oExportacion.Seguro;
            r["Embarque_Aprox"] = oExportacion.Embarque_Aprox;
            r["pedido"] = oExportacion.pedido;
            r["EndosarCod"] = oExportacion.EndosarCod;
            r["condicionesVenta"] = oExportacion.condicionesVenta;
            r["embarque"] = oExportacion.embarque;
            r["Transporte"] = oExportacion.Transporte;
            r["valorFob"] = oExportacion.valorFob;
            r["EndosarNom"] = oExportacion.EndosarNom;
            r["transportarNom"] = oExportacion.transportarNom;
            r["consignarNom"] = oExportacion.consignarNom;
            r["paisAdquisicion"] = oExportacion.paisAdquisicion;
            r["seguroInternacional"] = oExportacion.seguroInternacional;
            r["gastosAduana"] = oExportacion.gastosAduana;
            r["gastosTransporte"] = oExportacion.gastosTransporte;
            r["exportacionDe"] = oExportacion.exportacionDe;
            r["tipoComprobante"] = oExportacion.tipoComprobante;
            r["disAduanero"] = oExportacion.disAduanero;
            r["regimen"] = oExportacion.regimen;
            r["correlativo"] = oExportacion.correlativo;
            r["verificador"] = oExportacion.verificador;
            r["fechaEmbarque"] = oExportacion.fechaEmbarque;
            r["valorFobComprobante"] = oExportacion.valorFobComprobante;
            r["docTransp"] = oExportacion.docTransp;
            r["anio"] = oExportacion.anio;
        }
        //
        // crea una nueva fila y la asigna a un objeto Exportacion
        private static void nuevoExportacion(DataTable dt, classExporta oExportacion)
        {
            // Crear un nuevo Exportacion
            DataRow dr = dt.NewRow();
            classExporta oE = row2Exportacion(dr);
            //
            oE.Doc_Sucursal = oExportacion.Doc_Sucursal;
            oE.Opc_documento = oExportacion.Opc_documento;
            oE.Doc_numero = oExportacion.Doc_numero;
            oE.IdClaveDoc = oExportacion.IdClaveDoc;
            oE.Ciudad = oExportacion.Ciudad;
            oE.Estado = oExportacion.Estado;
            oE.ClienteConsig = oExportacion.ClienteConsig;
            oE.CiudadConsig = oExportacion.CiudadConsig;
            oE.EstadoConsig = oExportacion.EstadoConsig;
            oE.PedidoNo = oExportacion.PedidoNo;
            oE.PuertoDest = oExportacion.PuertoDest;
            oE.ViaEmbarque = oExportacion.ViaEmbarque;
            oE.EquipoNro = oExportacion.EquipoNro;
            oE.CantidadEquip = oExportacion.CantidadEquip;
            oE.fechaEmb = oExportacion.fechaEmb;
            oE.FechaEmbIngles = oExportacion.FechaEmbIngles;
            oE.DespachoParcial = oExportacion.DespachoParcial;
            oE.CondicionesPag = oExportacion.CondicionesPag;
            oE.NumeroPagos = oExportacion.NumeroPagos;
            oE.PlazoPagos = oExportacion.PlazoPagos;
            oE.Anticipo = oExportacion.Anticipo;
            oE.OrigenProforma = oExportacion.OrigenProforma;
            oE.Marcas = oExportacion.Marcas;
            oE.Idioma = oExportacion.Idioma;
            oE.FechaReq = oExportacion.FechaReq;
            oE.TerminosVent = oExportacion.TerminosVent;
            oE.SeguroTipo = oExportacion.SeguroTipo;
            oE.OrigProducto = oExportacion.OrigProducto;
            oE.PartidaArancelaria = oExportacion.PartidaArancelaria;
            oE.UnidadEntrada = oExportacion.UnidadEntrada;
            oE.UnidadSalida = oExportacion.UnidadSalida;
            oE.ObsDetalle = oExportacion.ObsDetalle;
            oE.Fue = oExportacion.Fue;
            oE.TotalPesoNeto = oExportacion.TotalPesoNeto;
            oE.TotalPesoBruto = oExportacion.TotalPesoBruto;
            oE.Flete = oExportacion.Flete;
            oE.CiudadFOB = oExportacion.CiudadFOB;
            oE.Seguro = oExportacion.Seguro;
            oE.Embarque_Aprox = oExportacion.Embarque_Aprox;
            oE.pedido = oExportacion.pedido;
            oE.EndosarCod = oExportacion.EndosarCod;
            oE.condicionesVenta = oExportacion.condicionesVenta;
            oE.embarque = oExportacion.embarque;
            oE.Transporte = oExportacion.Transporte;
            oE.valorFob = oExportacion.valorFob;
            oE.EndosarNom = oExportacion.EndosarNom;
            oE.transportarNom = oExportacion.transportarNom;
            oE.consignarNom = oExportacion.consignarNom;
            oE.paisAdquisicion = oExportacion.paisAdquisicion;
            oE.seguroInternacional = oExportacion.seguroInternacional;
            oE.gastosAduana = oExportacion.gastosAduana;
            oE.gastosTransporte = oExportacion.gastosTransporte;
            oE.exportacionDe = oExportacion.exportacionDe;
            oE.tipoComprobante = oExportacion.tipoComprobante;
            oE.disAduanero = oExportacion.disAduanero;
            oE.regimen = oExportacion.regimen;
            oE.correlativo = oExportacion.correlativo;
            oE.verificador = oExportacion.verificador;
            oE.fechaEmbarque = oExportacion.fechaEmbarque;
            oE.valorFobComprobante = oExportacion.valorFobComprobante;
            oE.docTransp = oExportacion.docTransp;
            oE.anio = oExportacion.anio;
            //
            Exportacion2Row(oE, dr);
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
            // devuelve una tabla con los datos de la tabla Exportacion
            SqlDataAdapter da;
            DataTable dt = new DataTable("Exportacion");
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
        public static classExporta Buscar(string sWhere)
        {
            // Busca en la tabla los datos indicados en el parámetro
            // el parámetro contendrá lo que se usará después del WHERE
            classExporta oExportacion = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("Exportacion");
            string sel = "SELECT * FROM Exportacion WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oExportacion = row2Exportacion(dt.Rows[0]);
            }
            return oExportacion;
        }
        //
        // Actualizar: Actualiza los datos en la tabla usando la instancia actual
        //             Si la instancia no hace referencia a un registro existente, se creará uno nuevo
        //             Para comprobar si el objeto en memoria coincide con uno existente,
        //             se comprueba si el ID existe en la tabla.
        public string Actualizar()
        {
            // TODO: Poner aquí la selección a realizar para acceder a este registro
            //       yo uso el ID que es el identificador único de cada registro
            string sel = "SELECT * FROM Exportacion WHERE doc_sucursal = '" + Doc_Sucursal + "' and opc_documento = '" + Opc_documento + "' and idclavedoc = " + IdClaveDoc.ToString();
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
            DataTable dt = new DataTable("Exportacion");
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
                Exportacion2Row(this, dt.Rows[0]);
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
            DataTable dt = new DataTable("Exportacion");
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
            nuevoExportacion(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo Exportacion";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            string sel = "SELECT * FROM Exportacion WHERE doc_sucursal = '" + Doc_Sucursal + "' and opc_documento = '" + Opc_documento + "' and idclavedoc = " + IdClaveDoc.ToString();
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            // Borrar el registro al que apunta esta clase
            // En caso de error, devolverá la cadena de error empezando por ERROR:.
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("Exportacion");
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
        //
    }
}
