using System;
using System.Data;
using System.Data.SqlClient;
//
namespace adcArticulo
{
    public class AdcArt
    {
        private System.String _Art_codigo = "";
        private System.String _Art_nombre = "";
        private System.String _Art_categor = "";
        private System.String _Art_clase = "";
        private System.String _Art_grupo = "";
        private System.String _Art_subgrup = "";
        private System.String _Art_tiporota = "";
        private System.String _Art_unimed = "";
        private System.Boolean _Art_snmed = false;
        private System.Decimal _Art_factor = 0;
        private System.Decimal _Art_CoefctePrecio = 0;
        private System.Decimal _Art_largo = 0;
        private System.Decimal _Art_alto = 0;
        private System.Decimal _Art_ancho = 0;
        private System.Decimal _Art_peso = 0;
        private System.Boolean _Art_sniva = true;
        private System.DateTime _Art_fecucom = new DateTime(1900, 1, 1);
        private System.Decimal _Art_costucom = 0;
        private System.String _Art_individ = "";
        private System.Decimal _Art_minbod = 0;
        private System.Decimal _Art_maxbod = 0;
        private System.Boolean _Art_sncomp = false;
        private System.Decimal _Art_PorCom = 0;
        private System.Decimal _Art_precvta1 = 0;
        private System.Decimal _Art_precvta2 = 0;
        private System.Decimal _Art_precvta3 = 0;
        private System.Decimal _Art_precvta4 = 0;
        private System.Decimal _Art_precvta5 = 0;
        private System.Decimal _Art_descuen = 0;
        private System.DateTime _Art_fecinides = new DateTime(1900, 1, 1);
        private System.DateTime _Art_fecfindes = new DateTime(1900, 1, 1);
        private System.String _Art_usuario = "";
        private System.String _Art_codpro = "";
        private System.String _Art_logotipo = "";
        private System.Boolean _Art_IncluyeIvaP1 = false;
        private System.Boolean _Art_IncluyeIvaP2 = false;
        private System.Boolean _Art_IncluyeIvaP3 = false;
        private System.Boolean _Art_IncluyeIvaP4 = false;
        private System.Boolean _Art_IncluyeIvaP5 = false;
        private System.Decimal _Art_CostoEstandard = 0;
        private System.String _Art_idcontable = "";
        private System.String _Art_Codigobase = "";
        private System.String _Art_proveedor = "";
        private System.DateTime _Art_FechaCrea = new DateTime(1900, 1, 1);
        private System.DateTime _Art_FechaModifica = new DateTime(1900, 1, 1);
        private System.Boolean _Art_Ice = false;
        private System.Int32 _Art_CompraMinima = 0;
        private System.Int32 _Art_CompraUndsGrupo = 0;
        private System.Int32 _CompraCantidadMinima = 0;
        private System.Int32 _CompraCantidadPorGrupo = 0;
        private System.String _NombreCorto = "";
        private System.String _CodEmpaque1 = "";
        private System.Decimal _ValEmpaque1 = 0;
        private System.String _CodEmpaque2 = "";
        private System.Decimal _ValEmpaque2 = 0;
        private System.String _CodEmpaque3 = "";
        private System.Decimal _ValEmpaque3 = 0;
        private System.String _CodEmpaque4 = "";
        private System.Decimal _ValEmpaque4 = 0;
        private System.String _CodEmpaque5 = "";
        private System.Decimal _ValEmpaque5 = 0;
        private System.Decimal _art_limDescuento = 0;
        private System.Boolean _art_presentaInmediato = false;
        private System.String _FechaCaduca = "";
        private System.String _NroLote = "";
        private System.Boolean _ArticuloSuspendido = false;
        private System.Decimal _cantTallos = 0;
        private System.String _detalleLargo = "";
        private System.String _Nandina = "";
        private System.String _HTS = "";
        private System.String _IdContable1 = "";
        private System.String _IdContable2 = "";
        private System.Decimal _Art_PorIVA = 0;
        private System.Boolean _Art_ExistBod = false;

        //
        // Este método se usará para ajustar los anchos de las propiedades
        private string ajustarAncho(string cadena, int ancho)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(new String(' ', ancho));
            return (cadena + sb.ToString()).Substring(0, ancho).Trim();
        }
        public System.String Art_codigo
        {
            get
            {
                return ajustarAncho(_Art_codigo, 20);
            }
            set
            {
                _Art_codigo = value;
            }
        }
        public System.String Art_nombre
        {
            get
            {
                return ajustarAncho(_Art_nombre, 128);
            }
            set
            {
                _Art_nombre = value;
            }
        }
        public System.String detalleLargo
        {
            get
            {
                return _detalleLargo;
            }
            set
            {
                _detalleLargo = value;
            }
        }
        public System.String Nandina
        {
            get
            {
                return ajustarAncho(_Nandina, 50);
            }
            set
            {
                _Nandina = value;
            }
        }
        public System.String HTS
        {
            get
            {
                return ajustarAncho(_HTS, 50);
            }
            set
            {
                _HTS = value;
            }
        }
        public System.String IdContable1
        {
            get
            {
                return ajustarAncho(_IdContable1, 20);
            }
            set
            {
                _IdContable1 = value;
            }
        }
        public System.String IdContable2
        {
            get
            {
                return ajustarAncho(_IdContable2, 20);
            }
            set
            {
                _IdContable2 = value;
            }
        }

        public System.String Art_categor
        {
            get
            {
                return ajustarAncho(_Art_categor, 5);
            }
            set
            {
                _Art_categor = value;
            }
        }
        public System.String Art_clase
        {
            get
            {
                return ajustarAncho(_Art_clase, 5);
            }
            set
            {
                _Art_clase = value;
            }
        }
        public System.String Art_grupo
        {
            get
            {
                return ajustarAncho(_Art_grupo, 5);
            }
            set
            {
                _Art_grupo = value;
            }
        }
        public System.String Art_subgrup
        {
            get
            {
                return ajustarAncho(_Art_subgrup, 5);
            }
            set
            {
                _Art_subgrup = value;
            }
        }
        public System.String Art_tiporota
        {
            get
            {
                return ajustarAncho(_Art_tiporota, 3);
            }
            set
            {
                _Art_tiporota = value;
            }
        }
        public System.String Art_unimed
        {
            get
            {
                return ajustarAncho(_Art_unimed, 5);
            }
            set
            {
                _Art_unimed = value;
            }
        }
        public System.Boolean Art_snmed
        {
            get
            {
                return _Art_snmed;
            }
            set
            {
                _Art_snmed = value;
            }
        }
        public System.Boolean ArticuloSuspendido
        {
            get
            {
                return _ArticuloSuspendido;
            }
            set
            {
                _ArticuloSuspendido = value;
            }
        }

        public System.Decimal Art_factor
        {
            get
            {
                return _Art_factor;
            }
            set
            {
                _Art_factor = value;
            }
        }
        public System.Decimal Art_CoefctePrecio
        {
            get
            {
                return _Art_CoefctePrecio;
            }
            set
            {
                _Art_CoefctePrecio = value;
            }
        }
        public System.Decimal Art_largo
        {
            get
            {
                return _Art_largo;
            }
            set
            {
                _Art_largo = value;
            }
        }
        public System.Decimal Art_alto
        {
            get
            {
                return _Art_alto;
            }
            set
            {
                _Art_alto = value;
            }
        }
        public System.Decimal Art_ancho
        {
            get
            {
                return _Art_ancho;
            }
            set
            {
                _Art_ancho = value;
            }
        }
        public System.Decimal Art_peso
        {
            get
            {
                return _Art_peso;
            }
            set
            {
                _Art_peso = value;
            }
        }
        public System.Boolean Art_sniva
        {
            get
            {
                return _Art_sniva;
            }
            set
            {
                _Art_sniva = value;
            }
        }
        public System.DateTime Art_fecucom
        {
            get
            {
                return _Art_fecucom;
            }
            set
            {
                _Art_fecucom = value;
            }
        }
        public System.Decimal Art_costucom
        {
            get
            {
                return _Art_costucom;
            }
            set
            {
                _Art_costucom = value;
            }
        }
        public System.String Art_individ
        {
            get
            {
                return ajustarAncho(_Art_individ, 5);
            }
            set
            {
                _Art_individ = value;
            }
        }
        public System.Decimal Art_minbod
        {
            get
            {
                return _Art_minbod;
            }
            set
            {
                _Art_minbod = value;
            }
        }
        public System.Decimal Art_maxbod
        {
            get
            {
                return _Art_maxbod;
            }
            set
            {
                _Art_maxbod = value;
            }
        }
        public System.Boolean Art_sncomp
        {
            get
            {
                return _Art_sncomp;
            }
            set
            {
                _Art_sncomp = value;
            }
        }
        public System.Decimal Art_PorCom
        {
            get
            {
                return _Art_PorCom;
            }
            set
            {
                _Art_PorCom = value;
            }
        }
        public System.Decimal Art_precvta1
        {
            get
            {
                return _Art_precvta1;
            }
            set
            {
                _Art_precvta1 = value;
            }
        }
        public System.Decimal Art_precvta2
        {
            get
            {
                return _Art_precvta2;
            }
            set
            {
                _Art_precvta2 = value;
            }
        }
        public System.Decimal Art_precvta3
        {
            get
            {
                return _Art_precvta3;
            }
            set
            {
                _Art_precvta3 = value;
            }
        }
        public System.Decimal Art_precvta4
        {
            get
            {
                return _Art_precvta4;
            }
            set
            {
                _Art_precvta4 = value;
            }
        }
        public System.Decimal Art_precvta5
        {
            get
            {
                return _Art_precvta5;
            }
            set
            {
                _Art_precvta5 = value;
            }
        }
        public System.Decimal Art_descuen
        {
            get
            {
                return _Art_descuen;
            }
            set
            {
                _Art_descuen = value;
            }
        }
        public System.DateTime Art_fecinides
        {
            get
            {
                return _Art_fecinides;
            }
            set
            {
                _Art_fecinides = value;
            }
        }
        public System.DateTime Art_fecfindes
        {
            get
            {
                return _Art_fecfindes;
            }
            set
            {
                _Art_fecfindes = value;
            }
        }
        public System.String Art_usuario
        {
            get
            {
                return ajustarAncho(_Art_usuario, 15);
            }
            set
            {
                _Art_usuario = value;
            }
        }
        public System.String Art_codpro
        {
            get
            {
                return ajustarAncho(_Art_codpro, 15);
            }
            set
            {
                _Art_codpro = value;
            }
        }
        public System.String Art_logotipo
        {
            get
            {
                return ajustarAncho(_Art_logotipo, 100);
            }
            set
            {
                _Art_logotipo = value;
            }
        }
        public System.Boolean Art_IncluyeIvaP1
        {
            get
            {
                return _Art_IncluyeIvaP1;
            }
            set
            {
                _Art_IncluyeIvaP1 = value;
            }
        }
        public System.Boolean Art_IncluyeIvaP2
        {
            get
            {
                return _Art_IncluyeIvaP2;
            }
            set
            {
                _Art_IncluyeIvaP2 = value;
            }
        }
        public System.Boolean Art_IncluyeIvaP3
        {
            get
            {
                return _Art_IncluyeIvaP3;
            }
            set
            {
                _Art_IncluyeIvaP3 = value;
            }
        }
        public System.Boolean Art_IncluyeIvaP4
        {
            get
            {
                return _Art_IncluyeIvaP4;
            }
            set
            {
                _Art_IncluyeIvaP4 = value;
            }
        }
        public System.Boolean Art_IncluyeIvaP5
        {
            get
            {
                return _Art_IncluyeIvaP5;
            }
            set
            {
                _Art_IncluyeIvaP5 = value;
            }
        }
        public System.Decimal Art_CostoEstandard
        {
            get
            {
                return _Art_CostoEstandard;
            }
            set
            {
                _Art_CostoEstandard = value;
            }
        }
        public System.String Art_idcontable
        {
            get
            {
                return ajustarAncho(_Art_idcontable, 20);
            }
            set
            {
                _Art_idcontable = value;
            }
        }
        public System.String Art_Codigobase
        {
            get
            {
                return ajustarAncho(_Art_Codigobase, 20);
            }
            set
            {
                _Art_Codigobase = value;
            }
        }
        public System.String Art_proveedor
        {
            get
            {
                return ajustarAncho(_Art_proveedor, 20);
            }
            set
            {
                _Art_proveedor = value;
            }
        }
        public System.DateTime Art_FechaCrea
        {
            get
            {
                return _Art_FechaCrea;
            }
            set
            {
                _Art_FechaCrea = value;
            }
        }
        public System.DateTime Art_FechaModifica
        {
            get
            {
                return _Art_FechaModifica;
            }
            set
            {
                _Art_FechaModifica = value;
            }
        }
        public System.Boolean Art_Ice
        {
            get
            {
                return _Art_Ice;
            }
            set
            {
                _Art_Ice = value;
            }
        }
        public System.Int32 Art_CompraMinima
        {
            get
            {
                return _Art_CompraMinima;
            }
            set
            {
                _Art_CompraMinima = value;
            }
        }
        public System.Int32 Art_CompraUndsGrupo
        {
            get
            {
                return _Art_CompraUndsGrupo;
            }
            set
            {
                _Art_CompraUndsGrupo = value;
            }
        }
        public System.Int32 CompraCantidadMinima
        {
            get
            {
                return _CompraCantidadMinima;
            }
            set
            {
                _CompraCantidadMinima = value;
            }
        }
        public System.Int32 CompraCantidadPorGrupo
        {
            get
            {
                return _CompraCantidadPorGrupo;
            }
            set
            {
                _CompraCantidadPorGrupo = value;
            }
        }
        public System.String NombreCorto
        {
            get
            {
                return ajustarAncho(_NombreCorto, 20);
            }
            set
            {
                _NombreCorto = value;
            }
        }
        public System.String CodEmpaque1
        {
            get
            {
                return ajustarAncho(_CodEmpaque1, 50);
            }
            set
            {
                _CodEmpaque1 = value;
            }
        }
        public System.Decimal ValEmpaque1
        {
            get
            {
                return _ValEmpaque1;
            }
            set
            {
                _ValEmpaque1 = value;
            }
        }
        public System.String CodEmpaque2
        {
            get
            {
                return ajustarAncho(_CodEmpaque2, 50);
            }
            set
            {
                _CodEmpaque2 = value;
            }
        }
        public System.Decimal ValEmpaque2
        {
            get
            {
                return _ValEmpaque2;
            }
            set
            {
                _ValEmpaque2 = value;
            }
        }
        public System.String CodEmpaque3
        {
            get
            {
                return ajustarAncho(_CodEmpaque3, 50);
            }
            set
            {
                _CodEmpaque3 = value;
            }
        }
        public System.Decimal ValEmpaque3
        {
            get
            {
                return _ValEmpaque3;
            }
            set
            {
                _ValEmpaque3 = value;
            }
        }
        public System.String CodEmpaque4
        {
            get
            {
                return ajustarAncho(_CodEmpaque4, 50);
            }
            set
            {
                _CodEmpaque4 = value;
            }
        }
        public System.Decimal ValEmpaque4
        {
            get
            {
                return _ValEmpaque4;
            }
            set
            {
                _ValEmpaque4 = value;
            }
        }
        public System.String CodEmpaque5
        {
            get
            {
                return ajustarAncho(_CodEmpaque5, 50);
            }
            set
            {
                _CodEmpaque5 = value;
            }
        }
        public System.Decimal ValEmpaque5
        {
            get
            {
                return _ValEmpaque5;
            }
            set
            {
                _ValEmpaque5 = value;
            }
        }
        public System.Decimal art_limDescuento
        {
            get
            {
                return _art_limDescuento;
            }
            set
            {
                _art_limDescuento = value;
            }
        }
        public System.Boolean art_presentaInmediato
        {
            get
            {
                return _art_presentaInmediato;
            }
            set
            {
                _art_presentaInmediato = value;
            }
        }
        public System.String FechaCaduca
        {
            get
            {
                return ajustarAncho(_FechaCaduca, 20);
            }
            set
            {
                _FechaCaduca = value;
            }
        }
        public System.String NroLote
        {
            get
            {
                return ajustarAncho(_NroLote, 20);
            }
            set
            {
                _NroLote = value;
            }
        }
        public System.Decimal cantTallos
        {
            get
            {
                return _cantTallos;
            }
            set
            {
                _cantTallos = value;
            }
        }
        public System.Decimal Art_PorIVA
        {
            get
            {
                return _Art_PorIVA;
            }
            set
            {
                _Art_PorIVA = value;
            }
        }


        public System.Boolean Art_ExistBod
        {
            get
            {
                return _Art_ExistBod;
            }
            set
            {
                _Art_ExistBod = value;
            }
        }

        //
        //
        // Campos y métodos compartidos (estáticos) para gestionar la base de datos
        //
        // La cadena de conexión a la base de datos
        private static string cadenaConexion = @"";
        // La cadena de selección
        public static string CadenaSelect = "SELECT * FROM AdcArt";
        //
        public AdcArt()
        {
        }
        public AdcArt(string conex)
        {
            cadenaConexion = conex;
        }
        //
        // Métodos compartidos (estáticos) privados
        //
        // asigna una fila de la tabla a un objeto AdcArt
        private static AdcArt row2AdcArt(DataRow r)
        {
            // asigna a un objeto AdcArt los datos del dataRow indicado
            AdcArt oAdcArt = new AdcArt();
            //
            oAdcArt.Art_codigo = r["Art_codigo"].ToString();
            oAdcArt.Art_nombre = r["Art_nombre"].ToString();
            oAdcArt.Art_categor = r["Art_categor"].ToString();
            oAdcArt.Art_clase = r["Art_clase"].ToString();
            oAdcArt.Art_grupo = r["Art_grupo"].ToString();
            oAdcArt.Art_subgrup = r["Art_subgrup"].ToString();
            oAdcArt.Art_tiporota = r["Art_tiporota"].ToString();
            oAdcArt.Art_unimed = r["Art_unimed"].ToString();
            try
            {
                oAdcArt.Art_snmed = System.Boolean.Parse(r["Art_snmed"].ToString());
            }
            catch
            {
                oAdcArt.Art_snmed = false;
            }
            try
            {
                oAdcArt.ArticuloSuspendido = System.Boolean.Parse(r["ArticuloSuspendido"].ToString());
            }
            catch
            {
                oAdcArt.ArticuloSuspendido = false;
            }

            oAdcArt.Art_factor = System.Decimal.Parse("0" + r["Art_factor"].ToString());
            oAdcArt.Art_CoefctePrecio = System.Decimal.Parse("0" + r["Art_CoefctePrecio"].ToString());
            oAdcArt.Art_largo = System.Decimal.Parse("0" + r["Art_largo"].ToString());
            oAdcArt.Art_alto = System.Decimal.Parse("0" + r["Art_alto"].ToString());
            oAdcArt.Art_ancho = System.Decimal.Parse("0" + r["Art_ancho"].ToString());
            oAdcArt.Art_peso = System.Decimal.Parse("0" + r["Art_peso"].ToString());
            try
            {
                oAdcArt.Art_sniva = System.Boolean.Parse(r["Art_sniva"].ToString());
            }
            catch
            {
                oAdcArt.Art_sniva = false;
            }
            try
            {
                oAdcArt.Art_fecucom = DateTime.Parse(r["Art_fecucom"].ToString());
            }
            catch
            {
                oAdcArt.Art_fecucom = new DateTime(1900, 1, 1);
            }
            oAdcArt.Art_costucom = System.Decimal.Parse("0" + r["Art_costucom"].ToString());
            oAdcArt.Art_individ = r["Art_individ"].ToString();
            oAdcArt.Art_minbod = System.Decimal.Parse("0" + r["Art_minbod"].ToString());
            oAdcArt.Art_maxbod = System.Decimal.Parse("0" + r["Art_maxbod"].ToString());
            try
            {
                oAdcArt.Art_sncomp = System.Boolean.Parse(r["Art_sncomp"].ToString());
            }
            catch
            {
                oAdcArt.Art_sncomp = false;
            }
            oAdcArt.Art_PorCom = System.Decimal.Parse("0" + r["Art_PorCom"].ToString());
            oAdcArt.Art_precvta1 = System.Decimal.Parse("0" + r["Art_precvta1"].ToString());
            oAdcArt.Art_precvta2 = System.Decimal.Parse("0" + r["Art_precvta2"].ToString());
            oAdcArt.Art_precvta3 = System.Decimal.Parse("0" + r["Art_precvta3"].ToString());
            oAdcArt.Art_precvta4 = System.Decimal.Parse("0" + r["Art_precvta4"].ToString());
            oAdcArt.Art_precvta5 = System.Decimal.Parse("0" + r["Art_precvta5"].ToString());
            oAdcArt.Art_descuen = System.Decimal.Parse("0" + r["Art_descuen"].ToString());
            try
            {
                oAdcArt.Art_fecinides = DateTime.Parse(r["Art_fecinides"].ToString());
            }
            catch
            {
                oAdcArt.Art_fecinides = new DateTime(1900, 1, 1);
            }
            try
            {
                oAdcArt.Art_fecfindes = DateTime.Parse(r["Art_fecfindes"].ToString());
            }
            catch
            {
                oAdcArt.Art_fecfindes = new DateTime(1900, 1, 1);
            }
            oAdcArt.Art_usuario = r["Art_usuario"].ToString();
            oAdcArt.Art_codpro = r["Art_codpro"].ToString();
            oAdcArt.Art_logotipo = r["Art_logotipo"].ToString();
            try
            {
                oAdcArt.Art_IncluyeIvaP1 = System.Boolean.Parse(r["Art_IncluyeIvaP1"].ToString());
            }
            catch
            {
                oAdcArt.Art_IncluyeIvaP1 = false;
            }
            try
            {
                oAdcArt.Art_IncluyeIvaP2 = System.Boolean.Parse(r["Art_IncluyeIvaP2"].ToString());
            }
            catch
            {
                oAdcArt.Art_IncluyeIvaP2 = false;
            }
            try
            {
                oAdcArt.Art_IncluyeIvaP3 = System.Boolean.Parse(r["Art_IncluyeIvaP3"].ToString());
            }
            catch
            {
                oAdcArt.Art_IncluyeIvaP3 = false;
            }
            try
            {
                oAdcArt.Art_IncluyeIvaP4 = System.Boolean.Parse(r["Art_IncluyeIvaP4"].ToString());
            }
            catch
            {
                oAdcArt.Art_IncluyeIvaP4 = false;
            }
            try
            {
                oAdcArt.Art_IncluyeIvaP5 = System.Boolean.Parse(r["Art_IncluyeIvaP5"].ToString());
            }
            catch
            {
                oAdcArt.Art_IncluyeIvaP5 = false;
            }
            oAdcArt.Art_CostoEstandard = System.Decimal.Parse("0" + r["Art_CostoEstandard"].ToString());
            oAdcArt.Art_idcontable = r["Art_idcontable"].ToString();
            oAdcArt.Art_Codigobase = r["Art_Codigobase"].ToString();
            oAdcArt.Art_proveedor = r["Art_proveedor"].ToString();
            try
            {
                oAdcArt.Art_FechaCrea = DateTime.Parse(r["Art_FechaCrea"].ToString());
            }
            catch
            {
                oAdcArt.Art_FechaCrea = new DateTime(1900, 1, 1);
            }
            try
            {
                oAdcArt.Art_FechaModifica = DateTime.Parse(r["Art_FechaModifica"].ToString());
            }
            catch
            {
                oAdcArt.Art_FechaModifica = DateTime.Now;
            }
            try
            {
                oAdcArt.Art_Ice = System.Boolean.Parse(r["Art_Ice"].ToString());
            }
            catch
            {
                oAdcArt.Art_Ice = false;
            }
            oAdcArt.Art_CompraMinima = System.Int32.Parse("0" + r["Art_CompraMinima"].ToString());
            oAdcArt.Art_CompraUndsGrupo = System.Int32.Parse("0" + r["Art_CompraUndsGrupo"].ToString());
            oAdcArt.CompraCantidadMinima = System.Int32.Parse("0" + r["CompraCantidadMinima"].ToString());
            oAdcArt.CompraCantidadPorGrupo = System.Int32.Parse("0" + r["CompraCantidadPorGrupo"].ToString());
            oAdcArt.NombreCorto = r["NombreCorto"].ToString();
            oAdcArt.CodEmpaque1 = r["CodEmpaque1"].ToString();
            oAdcArt.ValEmpaque1 = System.Decimal.Parse("0" + r["ValEmpaque1"].ToString());
            oAdcArt.CodEmpaque2 = r["CodEmpaque2"].ToString();
            oAdcArt.ValEmpaque2 = System.Decimal.Parse("0" + r["ValEmpaque2"].ToString());
            oAdcArt.CodEmpaque3 = r["CodEmpaque3"].ToString();
            oAdcArt.ValEmpaque3 = System.Decimal.Parse("0" + r["ValEmpaque3"].ToString());
            oAdcArt.CodEmpaque4 = r["CodEmpaque4"].ToString();
            oAdcArt.ValEmpaque4 = System.Decimal.Parse("0" + r["ValEmpaque4"].ToString());
            oAdcArt.CodEmpaque5 = r["CodEmpaque5"].ToString();
            oAdcArt.ValEmpaque5 = System.Decimal.Parse("0" + r["ValEmpaque5"].ToString());
            oAdcArt.art_limDescuento = System.Decimal.Parse("0" + r["art_limDescuento"].ToString());
            try
            {
                oAdcArt.art_presentaInmediato = System.Boolean.Parse(r["art_presentaInmediato"].ToString());
            }
            catch
            {
                oAdcArt.art_presentaInmediato = false;
            }
            oAdcArt.FechaCaduca = r["FechaCaduca"].ToString();
            oAdcArt.NroLote = r["NroLote"].ToString();
            oAdcArt.cantTallos = System.Decimal.Parse("0" + r["cantTallos"].ToString());
            oAdcArt.Nandina = r["Nandina"].ToString();
            oAdcArt.HTS = r["HTS"].ToString();
            oAdcArt.IdContable1 = r["IdContable1"].ToString();
            oAdcArt.IdContable2 = r["IdContable2"].ToString();
            oAdcArt.Art_PorIVA = System.Decimal.Parse("0" + r["Art_PorIVA"].ToString());
            try
            {
                oAdcArt.Art_ExistBod = System.Boolean.Parse(r["Art_ExistBod"].ToString());
            }
            catch
            {
                oAdcArt.Art_ExistBod = false;
            }
            //
            return oAdcArt;
        }
        //
        // asigna un objeto AdcArt a la fila indicada
        private static void AdcArt2Row(AdcArt oAdcArt, DataRow r)
        {
            // asigna un objeto AdcArt al dataRow indicado
            r["Art_codigo"] = oAdcArt.Art_codigo;
            r["Art_nombre"] = oAdcArt.Art_nombre;
            r["Art_categor"] = oAdcArt.Art_categor;
            r["Art_clase"] = oAdcArt.Art_clase;
            r["Art_grupo"] = oAdcArt.Art_grupo;
            r["Art_subgrup"] = oAdcArt.Art_subgrup;
            r["Art_tiporota"] = oAdcArt.Art_tiporota;
            r["Art_unimed"] = oAdcArt.Art_unimed;
            r["Art_snmed"] = oAdcArt.Art_snmed;
            r["ArticuloSuspendido"] = oAdcArt.ArticuloSuspendido;
            r["Art_CoefctePrecio"] = oAdcArt.Art_CoefctePrecio;
            r["Art_factor"] = oAdcArt.Art_factor;
            r["Art_largo"] = oAdcArt.Art_largo;
            r["Art_alto"] = oAdcArt.Art_alto;
            r["Art_ancho"] = oAdcArt.Art_ancho;
            r["Art_peso"] = oAdcArt.Art_peso;
            r["Art_sniva"] = oAdcArt.Art_sniva;
            r["Art_fecucom"] = oAdcArt.Art_fecucom;
            r["Art_costucom"] = oAdcArt.Art_costucom;
            r["Art_individ"] = oAdcArt.Art_individ;
            r["Art_minbod"] = oAdcArt.Art_minbod;
            r["Art_maxbod"] = oAdcArt.Art_maxbod;
            r["Art_sncomp"] = oAdcArt.Art_sncomp;
            r["Art_PorCom"] = oAdcArt.Art_PorCom;
            r["Art_precvta1"] = oAdcArt.Art_precvta1;
            r["Art_precvta2"] = oAdcArt.Art_precvta2;
            r["Art_precvta3"] = oAdcArt.Art_precvta3;
            r["Art_precvta4"] = oAdcArt.Art_precvta4;
            r["Art_precvta5"] = oAdcArt.Art_precvta5;
            r["Art_descuen"] = oAdcArt.Art_descuen;
            r["Art_fecinides"] = oAdcArt.Art_fecinides;
            r["Art_fecfindes"] = oAdcArt.Art_fecfindes;
            r["Art_usuario"] = oAdcArt.Art_usuario;
            r["Art_codpro"] = oAdcArt.Art_codpro;
            r["Art_logotipo"] = oAdcArt.Art_logotipo;
            r["Art_IncluyeIvaP1"] = oAdcArt.Art_IncluyeIvaP1;
            r["Art_IncluyeIvaP2"] = oAdcArt.Art_IncluyeIvaP2;
            r["Art_IncluyeIvaP3"] = oAdcArt.Art_IncluyeIvaP3;
            r["Art_IncluyeIvaP4"] = oAdcArt.Art_IncluyeIvaP4;
            r["Art_IncluyeIvaP5"] = oAdcArt.Art_IncluyeIvaP5;
            r["Art_CostoEstandard"] = oAdcArt.Art_CostoEstandard;
            r["Art_idcontable"] = oAdcArt.Art_idcontable;
            r["Art_Codigobase"] = oAdcArt.Art_Codigobase;
            r["Art_proveedor"] = oAdcArt.Art_proveedor;
            r["Art_FechaCrea"] = oAdcArt.Art_FechaCrea;
            r["Art_FechaModifica"] = oAdcArt.Art_FechaModifica;
            r["Art_Ice"] = oAdcArt.Art_Ice;
            r["Art_CompraMinima"] = oAdcArt.Art_CompraMinima;
            r["Art_CompraUndsGrupo"] = oAdcArt.Art_CompraUndsGrupo;
            r["CompraCantidadMinima"] = oAdcArt.CompraCantidadMinima;
            r["CompraCantidadPorGrupo"] = oAdcArt.CompraCantidadPorGrupo;
            r["NombreCorto"] = oAdcArt.NombreCorto;
            r["CodEmpaque1"] = oAdcArt.CodEmpaque1;
            r["ValEmpaque1"] = oAdcArt.ValEmpaque1;
            r["CodEmpaque2"] = oAdcArt.CodEmpaque2;
            r["ValEmpaque2"] = oAdcArt.ValEmpaque2;
            r["CodEmpaque3"] = oAdcArt.CodEmpaque3;
            r["ValEmpaque3"] = oAdcArt.ValEmpaque3;
            r["CodEmpaque4"] = oAdcArt.CodEmpaque4;
            r["ValEmpaque4"] = oAdcArt.ValEmpaque4;
            r["CodEmpaque5"] = oAdcArt.CodEmpaque5;
            r["ValEmpaque5"] = oAdcArt.ValEmpaque5;
            r["art_limDescuento"] = oAdcArt.art_limDescuento;
            r["art_presentaInmediato"] = oAdcArt.art_presentaInmediato;
            r["FechaCaduca"] = oAdcArt.FechaCaduca;
            r["NroLote"] = oAdcArt.NroLote;
            r["cantTallos"] = oAdcArt.cantTallos;
            r["Nandina"] = oAdcArt.Nandina;
            r["HTS"] = oAdcArt.HTS;
            r["IdContable1"] = oAdcArt.IdContable1;
            r["IdContable2"] = oAdcArt.IdContable2;

            r["Art_PorIVA"] = oAdcArt.Art_PorIVA;
            r["Art_ExistBod"] = oAdcArt.Art_ExistBod;
        }
        //
        // crea una nueva fila y la asigna a un objeto AdcArt
        private static void nuevoAdcArt(DataTable dt, AdcArt oAdcArt)
        {
            // Crear un nuevo AdcArt
            DataRow dr = dt.NewRow();
            AdcArt oA = row2AdcArt(dr);
            //
            oA.Art_codigo = oAdcArt.Art_codigo;
            oA.Art_nombre = oAdcArt.Art_nombre;
            oA.Art_categor = oAdcArt.Art_categor;
            oA.Art_clase = oAdcArt.Art_clase;
            oA.Art_grupo = oAdcArt.Art_grupo;
            oA.Art_subgrup = oAdcArt.Art_subgrup;
            oA.Art_tiporota = oAdcArt.Art_tiporota;
            oA.Art_unimed = oAdcArt.Art_unimed;
            oA.Art_snmed = oAdcArt.Art_snmed;
            oA.ArticuloSuspendido = oAdcArt.ArticuloSuspendido;

            oA.Art_factor = oAdcArt.Art_factor;
            oA.Art_CoefctePrecio = oAdcArt.Art_CoefctePrecio;
            oA.Art_largo = oAdcArt.Art_largo;
            oA.Art_alto = oAdcArt.Art_alto;
            oA.Art_ancho = oAdcArt.Art_ancho;
            oA.Art_peso = oAdcArt.Art_peso;
            oA.Art_sniva = oAdcArt.Art_sniva;
            oA.Art_fecucom = oAdcArt.Art_fecucom;
            oA.Art_costucom = oAdcArt.Art_costucom;
            oA.Art_individ = oAdcArt.Art_individ;
            oA.Art_minbod = oAdcArt.Art_minbod;
            oA.Art_maxbod = oAdcArt.Art_maxbod;
            oA.Art_sncomp = oAdcArt.Art_sncomp;
            oA.Art_PorCom = oAdcArt.Art_PorCom;
            oA.Art_precvta1 = oAdcArt.Art_precvta1;
            oA.Art_precvta2 = oAdcArt.Art_precvta2;
            oA.Art_precvta3 = oAdcArt.Art_precvta3;
            oA.Art_precvta4 = oAdcArt.Art_precvta4;
            oA.Art_precvta5 = oAdcArt.Art_precvta5;
            oA.Art_descuen = oAdcArt.Art_descuen;
            oA.Art_fecinides = oAdcArt.Art_fecinides;
            oA.Art_fecfindes = oAdcArt.Art_fecfindes;
            oA.Art_usuario = oAdcArt.Art_usuario;
            oA.Art_codpro = oAdcArt.Art_codpro;
            oA.Art_logotipo = oAdcArt.Art_logotipo;
            oA.Art_IncluyeIvaP1 = oAdcArt.Art_IncluyeIvaP1;
            oA.Art_IncluyeIvaP2 = oAdcArt.Art_IncluyeIvaP2;
            oA.Art_IncluyeIvaP3 = oAdcArt.Art_IncluyeIvaP3;
            oA.Art_IncluyeIvaP4 = oAdcArt.Art_IncluyeIvaP4;
            oA.Art_IncluyeIvaP5 = oAdcArt.Art_IncluyeIvaP5;
            oA.Art_CostoEstandard = oAdcArt.Art_CostoEstandard;
            oA.Art_idcontable = oAdcArt.Art_idcontable;
            oA.Art_Codigobase = oAdcArt.Art_Codigobase;
            oA.Art_proveedor = oAdcArt.Art_proveedor;
            oA.Art_FechaCrea = oAdcArt.Art_FechaCrea;
            oA.Art_FechaModifica = oAdcArt.Art_FechaModifica;
            oA.Art_Ice = oAdcArt.Art_Ice;
            oA.Art_CompraMinima = oAdcArt.Art_CompraMinima;
            oA.Art_CompraUndsGrupo = oAdcArt.Art_CompraUndsGrupo;
            oA.CompraCantidadMinima = oAdcArt.CompraCantidadMinima;
            oA.CompraCantidadPorGrupo = oAdcArt.CompraCantidadPorGrupo;
            oA.NombreCorto = oAdcArt.NombreCorto;
            oA.CodEmpaque1 = oAdcArt.CodEmpaque1;
            oA.ValEmpaque1 = oAdcArt.ValEmpaque1;
            oA.CodEmpaque2 = oAdcArt.CodEmpaque2;
            oA.ValEmpaque2 = oAdcArt.ValEmpaque2;
            oA.CodEmpaque3 = oAdcArt.CodEmpaque3;
            oA.ValEmpaque3 = oAdcArt.ValEmpaque3;
            oA.CodEmpaque4 = oAdcArt.CodEmpaque4;
            oA.ValEmpaque4 = oAdcArt.ValEmpaque4;
            oA.CodEmpaque5 = oAdcArt.CodEmpaque5;
            oA.ValEmpaque5 = oAdcArt.ValEmpaque5;
            oA.art_limDescuento = oAdcArt.art_limDescuento;
            oA.art_presentaInmediato = oAdcArt.art_presentaInmediato;
            oA.FechaCaduca = oAdcArt.FechaCaduca;
            oA.NroLote = oAdcArt.NroLote;
            oA.cantTallos = oAdcArt.cantTallos;
            oA.Nandina = oAdcArt.Nandina;
            oA.HTS = oAdcArt.HTS;
            oA.IdContable1 = oAdcArt.IdContable1;
            oA.IdContable2 = oAdcArt.IdContable2;

            oA.Art_PorIVA = oAdcArt.Art_PorIVA;
            oA.Art_ExistBod = oAdcArt.Art_ExistBod;

            //
            AdcArt2Row(oA, dr);
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
            // devuelve una tabla con los datos de la tabla AdcArt
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcArt");
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
        public static AdcArt Buscar(string sWhere)
        {
            // Busca en la tabla los datos indicados en el parámetro
            // el parámetro contendrá lo que se usará después del WHERE
            AdcArt oAdcArt = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcArt");
            string sel = "SELECT * FROM AdcArt WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oAdcArt = row2AdcArt(dt.Rows[0]);
                oAdcArt.leerDetalleLargo();
            }
            return oAdcArt;
        }
        public string Actualizar()
        {
            string sel = "SELECT * FROM AdcArt WHERE Art_codigo = '" + this.Art_codigo + "'";
            return Actualizar(sel);
        }
        public string Actualizar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcArt");
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
                AdcArt2Row(this, dt.Rows[0]);
            }
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                grabarDetalleLargo();
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
            DataTable dt = new DataTable("AdcArt");
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
            nuevoAdcArt(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                grabarDetalleLargo();
                return "Se ha creado un nuevo AdcArt";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            string sel = "SELECT * FROM AdcArt WHERE Art_codigo = '" + this.Art_codigo + "'";
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcArt");
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
        private void grabarDetalleLargo()
        {
            if (_detalleLargo.Length < 1) return;
            string ssql = " Select * from adcdetart where det_articulo = '" + _Art_codigo + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(ssql, cadenaConexion);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                dt.Rows[0]["det_texto"] = _detalleLargo;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                dt.Rows[0]["det_articulo"] = _Art_codigo;
                dt.Rows[0]["det_texto"] = _detalleLargo;
            }
            da.Update(dt);
            dt.AcceptChanges();

        }
        private void leerDetalleLargo()
        {
            string ssql = " Select * from adcdetart where det_articulo = '" + _Art_codigo + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(ssql, cadenaConexion);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                _detalleLargo = dt.Rows[0]["det_texto"].ToString();
            }
            else
                da.Dispose();
            dt.Dispose();
        }
    }
}
