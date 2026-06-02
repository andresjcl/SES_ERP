using System;
using System.Data;
using System.Data.SqlClient;

namespace ClassDoc
{
    public class AdcSri
    {
        // Las variables privadas
        // TODO: Revisar los tipos de los campos
        private System.String _SRI_SUCURSAL = "";
        private System.String _SRI_DOCUMENTO = "";
        private System.Decimal _IdClaveDoc = 0;
        private System.Decimal _IdClaveDocSustento = 0;
        private System.Decimal _SRI_NUMERORET = 0;
        private System.Decimal _BaseIvaBienes = 0;
        private System.Decimal _PorRetIvaBienes = 0;
        private System.Decimal _ValorRetIvaBienes = 0;
        private System.String _CodigoRetIvaBienes = "";
        private System.Decimal _BaseIvaServicios = 0;
        private System.Decimal _PorRetIvaServicios = 0;
        private System.Decimal _ValorRetIvaServicios = 0;
        private System.String _CodigoRetIvaServicios = "";
        private System.Decimal _BaseRetFuente = 0;
        private System.Decimal _PorRetFuente = 0;
        private System.Decimal _ValorRetFuente = 0;
        private System.String _CodigoRetFuente = "";
        private System.Decimal _BaseRetFuente1 = 0;
        private System.Decimal _PorRetFuente1 = 0;
        private System.Decimal _ValorRetFuente1 = 0;
        private System.String _CodigoRetFuente1 = "";
        private System.Decimal _BasIvaExc = 0;
        private System.Decimal _BasIvaCon = 0;
        private System.Decimal _BasIvaCer = 0;
        private System.Decimal _BasIvaExc1 = 0;
        private System.Decimal _BasIvaCer1 = 0;
        private System.Decimal _BasIvaCon1 = 0;
        private System.String _Sri_tipoDoc = "";
        private System.DateTime _fechaPagoDiv = new DateTime(1900, 1, 1);
        private System.Decimal _imRentaSoc = 0;
        private System.Int32 _anioUtDiv = 0;
        private System.Decimal _NumCajBan = 0;
        private System.Decimal _PrecCajBan = 0;
        private System.DateTime _fechaPagoDiv1 = new DateTime(1900, 1, 1);
        private System.Decimal _imRentaSoc1 = 0;
        private System.Int32 _anioUtDiv1 = 0;
        private System.Decimal _NumCajBan1 = 0;
        private System.Decimal _PrecCajBan1 = 0;
        private System.Decimal _codRetAir2 = 0;
        private System.Decimal _baseImpAir2 = 0;
        private System.Decimal _porcentajeAir2 = 0;
        private System.Decimal _valRetAir2 = 0;
        private System.DateTime _fechaPagoDiv2 = new DateTime(1900, 1, 1);
        private System.Decimal _imRentaSoc2 = 0;
        private System.Int32 _anioUtDiv2 = 0;
        private System.Decimal _NumCajBan2 = 0;
        private System.Decimal _PrecCajBan2 = 0;
        private System.Decimal _codRetAir3 = 0;
        private System.Decimal _baseImpAir3 = 0;
        private System.Decimal _porcentajeAir3 = 0;
        private System.Decimal _valRetAir3 = 0;
        private System.DateTime _fechaPagoDiv3 = new DateTime(1900, 1, 1);
        private System.Decimal _imRentaSoc3 = 0;
        private System.Int32 _anioUtDiv3 = 0;
        private System.Decimal _NumCajBan3 = 0;
        private System.Decimal _PrecCajBan3 = 0;
        private System.String _codDocSustento = "";
        private System.String _codDocSustentoAdcom = "";
        private System.String _numDocSustento = "";
        private System.DateTime _fechaEmisionDocSustento = new DateTime(1900, 1, 1);
        private System.String _idsriDocSustento = "";
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
        // Las propiedades públicas
        // TODO: Revisar los tipos de las propiedades
        public System.String SRI_SUCURSAL
        {
            get
            {
                return ajustarAncho(_SRI_SUCURSAL, 3);
            }
            set
            {
                _SRI_SUCURSAL = value;
            }
        }
        public System.String SRI_DOCUMENTO
        {
            get
            {
                return ajustarAncho(_SRI_DOCUMENTO, 3);
            }
            set
            {
                _SRI_DOCUMENTO = value;
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

        public System.Decimal IdClaveDocSustento
        {
            get
            {
                return _IdClaveDocSustento;
            }
            set
            {
                _IdClaveDocSustento = value;
            }
        }
        public System.Decimal SRI_NUMERORET
        {
            get
            {
                return _SRI_NUMERORET;
            }
            set
            {
                _SRI_NUMERORET = value;
            }
        }
        public System.Decimal BaseIvaBienes
        {
            get
            {
                return _BaseIvaBienes;
            }
            set
            {
                _BaseIvaBienes = value;
            }
        }
        public System.Decimal PorRetIvaBienes
        {
            get
            {
                return _PorRetIvaBienes;
            }
            set
            {
                _PorRetIvaBienes = value;
            }
        }
        public System.Decimal ValorRetIvaBienes
        {
            get
            {
                return _ValorRetIvaBienes;
            }
            set
            {
                _ValorRetIvaBienes = value;
            }
        }
        public System.String CodigoRetIvaBienes
        {
            get
            {
                return ajustarAncho(_CodigoRetIvaBienes, 10);
            }
            set
            {
                _CodigoRetIvaBienes = value;
            }
        }
        public System.Decimal BaseIvaServicios
        {
            get
            {
                return _BaseIvaServicios;
            }
            set
            {
                _BaseIvaServicios = value;
            }
        }
        public System.Decimal PorRetIvaServicios
        {
            get
            {
                return _PorRetIvaServicios;
            }
            set
            {
                _PorRetIvaServicios = value;
            }
        }
        public System.Decimal ValorRetIvaServicios
        {
            get
            {
                return _ValorRetIvaServicios;
            }
            set
            {
                _ValorRetIvaServicios = value;
            }
        }
        public System.String CodigoRetIvaServicios
        {
            get
            {
                return ajustarAncho(_CodigoRetIvaServicios, 10);
            }
            set
            {
                _CodigoRetIvaServicios = value;
            }
        }
        public System.Decimal BaseRetFuente
        {
            get
            {
                return _BaseRetFuente;
            }
            set
            {
                _BaseRetFuente = value;
            }
        }
        public System.Decimal PorRetFuente
        {
            get
            {
                return _PorRetFuente;
            }
            set
            {
                _PorRetFuente = value;
            }
        }
        public System.Decimal ValorRetFuente
        {
            get
            {
                return _ValorRetFuente;
            }
            set
            {
                _ValorRetFuente = value;
            }
        }
        public System.String CodigoRetFuente
        {
            get
            {
                return ajustarAncho(_CodigoRetFuente, 10);
            }
            set
            {
                _CodigoRetFuente = value;
            }
        }
        public System.Decimal BaseRetFuente1
        {
            get
            {
                return _BaseRetFuente1;
            }
            set
            {
                _BaseRetFuente1 = value;
            }
        }
        public System.Decimal PorRetFuente1
        {
            get
            {
                return _PorRetFuente1;
            }
            set
            {
                _PorRetFuente1 = value;
            }
        }
        public System.Decimal ValorRetFuente1
        {
            get
            {
                return _ValorRetFuente1;
            }
            set
            {
                _ValorRetFuente1 = value;
            }
        }
        public System.String CodigoRetFuente1
        {
            get
            {
                return ajustarAncho(_CodigoRetFuente1, 10);
            }
            set
            {
                _CodigoRetFuente1 = value;
            }
        }
        public System.Decimal BasIvaExc
        {
            get
            {
                return _BasIvaExc;
            }
            set
            {
                _BasIvaExc = value;
            }
        }
        public System.Decimal BasIvaCon
        {
            get
            {
                return _BasIvaCon;
            }
            set
            {
                _BasIvaCon = value;
            }
        }
        public System.Decimal BasIvaCer
        {
            get
            {
                return _BasIvaCer;
            }
            set
            {
                _BasIvaCer = value;
            }
        }
        public System.Decimal BasIvaExc1
        {
            get
            {
                return _BasIvaExc1;
            }
            set
            {
                _BasIvaExc1 = value;
            }
        }
        public System.Decimal BasIvaCer1
        {
            get
            {
                return _BasIvaCer1;
            }
            set
            {
                _BasIvaCer1 = value;
            }
        }
        public System.Decimal BasIvaCon1
        {
            get
            {
                return _BasIvaCon1;
            }
            set
            {
                _BasIvaCon1 = value;
            }
        }
        public System.String Sri_tipoDoc
        {
            get
            {
                return ajustarAncho(_Sri_tipoDoc, 3);
            }
            set
            {
                _Sri_tipoDoc = value;
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
        public System.String codDocSustento
        {
            get
            {
                return ajustarAncho(_codDocSustento, 15);
            }
            set
            {
                _codDocSustento = value;
            }
        }
        public System.String codDocSustentoAdcom
        {
            get
            {
                return ajustarAncho(_codDocSustentoAdcom, 15);
            }
            set
            {
                _codDocSustentoAdcom = value;
            }
        }
        public System.String numDocSustento
        {
            get
            {
                return ajustarAncho(_numDocSustento, 25);
            }
            set
            {
                _numDocSustento = value;
            }
        }
        public System.DateTime fechaEmisionDocSustento
        {
            get
            {
                return _fechaEmisionDocSustento;
            }
            set
            {
                _fechaEmisionDocSustento = value;
            }
        }
        public System.String idsriDocSustento
        {
            get
            {
                return ajustarAncho(_idsriDocSustento, 15);
            }
            set
            {
                _idsriDocSustento = value;
            }
        }
        //
        //
        // Campos y métodos compartidos (estáticos) para gestionar la base de datos
        //
        // La cadena de conexión a la base de datos
        private static string cadenaConexion = @"";
        // La cadena de selección
        public static string CadenaSelect = "SELECT * FROM AdcSri9";
        //
        public AdcSri()
        {
        }
        public AdcSri(string conex)
        {
            cadenaConexion = conex;
        }
        //
        // Métodos compartidos (estáticos) privados
        //
        // asigna una fila de la tabla a un objeto AdcSri
        private static AdcSri row2AdcSri(DataRow r)
        {
            // asigna a un objeto AdcSri los datos del dataRow indicado
            AdcSri oAdcSri = new AdcSri();
            //
            oAdcSri.SRI_SUCURSAL = r["SRI_SUCURSAL"].ToString();
            oAdcSri.SRI_DOCUMENTO = r["SRI_DOCUMENTO"].ToString();
            oAdcSri.IdClaveDoc = System.Decimal.Parse("0" + r["IdClaveDoc"].ToString());
            oAdcSri.IdClaveDocSustento = System.Decimal.Parse("0" + r["IdClaveDocSustento"].ToString());
            oAdcSri.SRI_NUMERORET = System.Decimal.Parse("0" + r["SRI_NUMERORET"].ToString());
            oAdcSri.BaseIvaBienes = System.Decimal.Parse("0" + r["BaseIvaBienes"].ToString());
            oAdcSri.PorRetIvaBienes = System.Decimal.Parse("0" + r["PorRetIvaBienes"].ToString());
            oAdcSri.ValorRetIvaBienes = System.Decimal.Parse("0" + r["ValorRetIvaBienes"].ToString());
            oAdcSri.CodigoRetIvaBienes = r["CodigoRetIvaBienes"].ToString();
            oAdcSri.BaseIvaServicios = System.Decimal.Parse("0" + r["BaseIvaServicios"].ToString());
            oAdcSri.PorRetIvaServicios = System.Decimal.Parse("0" + r["PorRetIvaServicios"].ToString());
            oAdcSri.ValorRetIvaServicios = System.Decimal.Parse("0" + r["ValorRetIvaServicios"].ToString());
            oAdcSri.CodigoRetIvaServicios = r["CodigoRetIvaServicios"].ToString();
            oAdcSri.BaseRetFuente = System.Decimal.Parse("0" + r["BaseRetFuente"].ToString());
            oAdcSri.PorRetFuente = System.Decimal.Parse("0" + r["PorRetFuente"].ToString());
            oAdcSri.ValorRetFuente = System.Decimal.Parse("0" + r["ValorRetFuente"].ToString());
            oAdcSri.CodigoRetFuente = r["CodigoRetFuente"].ToString();
            oAdcSri.BaseRetFuente1 = System.Decimal.Parse("0" + r["BaseRetFuente1"].ToString());
            oAdcSri.PorRetFuente1 = System.Decimal.Parse("0" + r["PorRetFuente1"].ToString());
            oAdcSri.ValorRetFuente1 = System.Decimal.Parse("0" + r["ValorRetFuente1"].ToString());
            oAdcSri.CodigoRetFuente1 = r["CodigoRetFuente1"].ToString();
            oAdcSri.BasIvaExc = System.Decimal.Parse("0" + r["BasIvaExc"].ToString());
            oAdcSri.BasIvaCon = System.Decimal.Parse("0" + r["BasIvaCon"].ToString());
            oAdcSri.BasIvaCer = System.Decimal.Parse("0" + r["BasIvaCer"].ToString());
            oAdcSri.BasIvaExc1 = System.Decimal.Parse("0" + r["BasIvaExc1"].ToString());
            oAdcSri.BasIvaCer1 = System.Decimal.Parse("0" + r["BasIvaCer1"].ToString());
            oAdcSri.BasIvaCon1 = System.Decimal.Parse("0" + r["BasIvaCon1"].ToString());
            oAdcSri.Sri_tipoDoc = r["Sri_tipoDoc"].ToString();
            try
            {
                oAdcSri.fechaPagoDiv = DateTime.Parse(r["fechaPagoDiv"].ToString());
            }
            catch
            {
                // TODO: Usa el valor de fecha que quieras predeterminar
                //       Una fecha ficticia:
                //oAdcSri.fechaPagoDiv = new DateTime(1900, 1, 1);
                //       o la fecha de hoy:
                oAdcSri.fechaPagoDiv = DateTime.Now;
            }
            oAdcSri.imRentaSoc = System.Decimal.Parse("0" + r["imRentaSoc"].ToString());
            oAdcSri.anioUtDiv = System.Int32.Parse("0" + r["anioUtDiv"].ToString());
            oAdcSri.NumCajBan = System.Decimal.Parse("0" + r["NumCajBan"].ToString());
            oAdcSri.PrecCajBan = System.Decimal.Parse("0" + r["PrecCajBan"].ToString());
            try
            {
                oAdcSri.fechaPagoDiv1 = DateTime.Parse(r["fechaPagoDiv1"].ToString());
            }
            catch
            {
                oAdcSri.fechaPagoDiv1 = new DateTime(1900, 1, 1);
            }
            oAdcSri.imRentaSoc1 = System.Decimal.Parse("0" + r["imRentaSoc1"].ToString());
            oAdcSri.anioUtDiv1 = System.Int32.Parse("0" + r["anioUtDiv1"].ToString());
            oAdcSri.NumCajBan1 = System.Decimal.Parse("0" + r["NumCajBan1"].ToString());
            oAdcSri.PrecCajBan1 = System.Decimal.Parse("0" + r["PrecCajBan1"].ToString());
            oAdcSri.codRetAir2 = System.Decimal.Parse("0" + r["codRetAir2"].ToString());
            oAdcSri.baseImpAir2 = System.Decimal.Parse("0" + r["baseImpAir2"].ToString());
            oAdcSri.porcentajeAir2 = System.Decimal.Parse("0" + r["porcentajeAir2"].ToString());
            oAdcSri.valRetAir2 = System.Decimal.Parse("0" + r["valRetAir2"].ToString());
            try
            {
                oAdcSri.fechaPagoDiv2 = DateTime.Parse(r["fechaPagoDiv2"].ToString());
            }
            catch
            {
                oAdcSri.fechaPagoDiv2 = new DateTime(1900, 1, 1);
            }
            oAdcSri.imRentaSoc2 = System.Decimal.Parse("0" + r["imRentaSoc2"].ToString());
            oAdcSri.anioUtDiv2 = System.Int32.Parse("0" + r["anioUtDiv2"].ToString());
            oAdcSri.NumCajBan2 = System.Decimal.Parse("0" + r["NumCajBan2"].ToString());
            oAdcSri.PrecCajBan2 = System.Decimal.Parse("0" + r["PrecCajBan2"].ToString());
            oAdcSri.codRetAir3 = System.Decimal.Parse("0" + r["codRetAir3"].ToString());
            oAdcSri.baseImpAir3 = System.Decimal.Parse("0" + r["baseImpAir3"].ToString());
            oAdcSri.porcentajeAir3 = System.Decimal.Parse("0" + r["porcentajeAir3"].ToString());
            oAdcSri.valRetAir3 = System.Decimal.Parse("0" + r["valRetAir3"].ToString());
            try
            {
                oAdcSri.fechaPagoDiv3 = DateTime.Parse(r["fechaPagoDiv3"].ToString());
            }
            catch
            {
                oAdcSri.fechaPagoDiv3 = new DateTime(1900, 1, 1);
            }
            oAdcSri.imRentaSoc3 = System.Decimal.Parse("0" + r["imRentaSoc3"].ToString());
            oAdcSri.anioUtDiv3 = System.Int32.Parse("0" + r["anioUtDiv3"].ToString());
            oAdcSri.NumCajBan3 = System.Decimal.Parse("0" + r["NumCajBan3"].ToString());
            oAdcSri.PrecCajBan3 = System.Decimal.Parse("0" + r["PrecCajBan3"].ToString());
            oAdcSri.codDocSustento = r["codDocSustento"].ToString();
            oAdcSri.codDocSustentoAdcom = r["codDocSustentoAdcom"].ToString();
            oAdcSri.numDocSustento = r["numDocSustento"].ToString();
            try
            {
                oAdcSri.fechaEmisionDocSustento = DateTime.Parse(r["fechaEmisionDocSustento"].ToString());
            }
            catch
            {
                oAdcSri.fechaEmisionDocSustento = new DateTime(1900, 1, 1);
            }
            oAdcSri.idsriDocSustento = r["idsriDocSustento"].ToString();
            //
            return oAdcSri;
        }
        //
        // asigna un objeto AdcSri a la fila indicada
        private static void AdcSri2Row(AdcSri oAdcSri, DataRow r)
        {
            // asigna un objeto AdcSri al dataRow indicado
            r["SRI_SUCURSAL"] = oAdcSri.SRI_SUCURSAL;
            r["SRI_DOCUMENTO"] = oAdcSri.SRI_DOCUMENTO;
            r["IdClaveDoc"] = oAdcSri.IdClaveDoc;
            r["IdClaveDocSustento"] = oAdcSri.IdClaveDocSustento;
            r["SRI_NUMERORET"] = oAdcSri.SRI_NUMERORET;
            r["BaseIvaBienes"] = oAdcSri.BaseIvaBienes;
            r["PorRetIvaBienes"] = oAdcSri.PorRetIvaBienes;
            r["ValorRetIvaBienes"] = oAdcSri.ValorRetIvaBienes;
            r["CodigoRetIvaBienes"] = oAdcSri.CodigoRetIvaBienes;
            r["BaseIvaServicios"] = oAdcSri.BaseIvaServicios;
            r["PorRetIvaServicios"] = oAdcSri.PorRetIvaServicios;
            r["ValorRetIvaServicios"] = oAdcSri.ValorRetIvaServicios;
            r["CodigoRetIvaServicios"] = oAdcSri.CodigoRetIvaServicios;
            r["BaseRetFuente"] = oAdcSri.BaseRetFuente;
            r["PorRetFuente"] = oAdcSri.PorRetFuente;
            r["ValorRetFuente"] = oAdcSri.ValorRetFuente;
            r["CodigoRetFuente"] = oAdcSri.CodigoRetFuente;
            r["BaseRetFuente1"] = oAdcSri.BaseRetFuente1;
            r["PorRetFuente1"] = oAdcSri.PorRetFuente1;
            r["ValorRetFuente1"] = oAdcSri.ValorRetFuente1;
            r["CodigoRetFuente1"] = oAdcSri.CodigoRetFuente1;
            r["BasIvaExc"] = oAdcSri.BasIvaExc;
            r["BasIvaCon"] = oAdcSri.BasIvaCon;
            r["BasIvaCer"] = oAdcSri.BasIvaCer;
            r["BasIvaExc1"] = oAdcSri.BasIvaExc1;
            r["BasIvaCer1"] = oAdcSri.BasIvaCer1;
            r["BasIvaCon1"] = oAdcSri.BasIvaCon1;
            r["Sri_tipoDoc"] = oAdcSri.Sri_tipoDoc;
            r["fechaPagoDiv"] = oAdcSri.fechaPagoDiv;
            r["imRentaSoc"] = oAdcSri.imRentaSoc;
            r["anioUtDiv"] = oAdcSri.anioUtDiv;
            r["NumCajBan"] = oAdcSri.NumCajBan;
            r["PrecCajBan"] = oAdcSri.PrecCajBan;
            r["fechaPagoDiv1"] = oAdcSri.fechaPagoDiv1;
            r["imRentaSoc1"] = oAdcSri.imRentaSoc1;
            r["anioUtDiv1"] = oAdcSri.anioUtDiv1;
            r["NumCajBan1"] = oAdcSri.NumCajBan1;
            r["PrecCajBan1"] = oAdcSri.PrecCajBan1;
            r["codRetAir2"] = oAdcSri.codRetAir2;
            r["baseImpAir2"] = oAdcSri.baseImpAir2;
            r["porcentajeAir2"] = oAdcSri.porcentajeAir2;
            r["valRetAir2"] = oAdcSri.valRetAir2;
            r["fechaPagoDiv2"] = oAdcSri.fechaPagoDiv2;
            r["imRentaSoc2"] = oAdcSri.imRentaSoc2;
            r["anioUtDiv2"] = oAdcSri.anioUtDiv2;
            r["NumCajBan2"] = oAdcSri.NumCajBan2;
            r["PrecCajBan2"] = oAdcSri.PrecCajBan2;
            r["codRetAir3"] = oAdcSri.codRetAir3;
            r["baseImpAir3"] = oAdcSri.baseImpAir3;
            r["porcentajeAir3"] = oAdcSri.porcentajeAir3;
            r["valRetAir3"] = oAdcSri.valRetAir3;
            r["fechaPagoDiv3"] = oAdcSri.fechaPagoDiv3;
            r["imRentaSoc3"] = oAdcSri.imRentaSoc3;
            r["anioUtDiv3"] = oAdcSri.anioUtDiv3;
            r["NumCajBan3"] = oAdcSri.NumCajBan3;
            r["PrecCajBan3"] = oAdcSri.PrecCajBan3;
            r["codDocSustento"] = oAdcSri.codDocSustento;
            r["codDocSustentoAdcom"] = oAdcSri.codDocSustentoAdcom;
            r["numDocSustento"] = oAdcSri.numDocSustento;
            r["fechaEmisionDocSustento"] = oAdcSri.fechaEmisionDocSustento;
            r["idsriDocSustento"] = oAdcSri.idsriDocSustento;
        }
        //
        // crea una nueva fila y la asigna a un objeto AdcSri
        private static void nuevoAdcSri(DataTable dt, AdcSri oAdcSri)
        {
            // Crear un nuevo AdcSri
            DataRow dr = dt.NewRow();
            AdcSri oA = row2AdcSri(dr);
            //
            oA.SRI_SUCURSAL = oAdcSri.SRI_SUCURSAL;
            oA.SRI_DOCUMENTO = oAdcSri.SRI_DOCUMENTO;
            oA.IdClaveDoc = oAdcSri.IdClaveDoc;
            oA.IdClaveDocSustento = oAdcSri.IdClaveDocSustento;
            oA.SRI_NUMERORET = oAdcSri.SRI_NUMERORET;
            oA.BaseIvaBienes = oAdcSri.BaseIvaBienes;
            oA.PorRetIvaBienes = oAdcSri.PorRetIvaBienes;
            oA.ValorRetIvaBienes = oAdcSri.ValorRetIvaBienes;
            oA.CodigoRetIvaBienes = oAdcSri.CodigoRetIvaBienes;
            oA.BaseIvaServicios = oAdcSri.BaseIvaServicios;
            oA.PorRetIvaServicios = oAdcSri.PorRetIvaServicios;
            oA.ValorRetIvaServicios = oAdcSri.ValorRetIvaServicios;
            oA.CodigoRetIvaServicios = oAdcSri.CodigoRetIvaServicios;
            oA.BaseRetFuente = oAdcSri.BaseRetFuente;
            oA.PorRetFuente = oAdcSri.PorRetFuente;
            oA.ValorRetFuente = oAdcSri.ValorRetFuente;
            oA.CodigoRetFuente = oAdcSri.CodigoRetFuente;
            oA.BaseRetFuente1 = oAdcSri.BaseRetFuente1;
            oA.PorRetFuente1 = oAdcSri.PorRetFuente1;
            oA.ValorRetFuente1 = oAdcSri.ValorRetFuente1;
            oA.CodigoRetFuente1 = oAdcSri.CodigoRetFuente1;
            oA.BasIvaExc = oAdcSri.BasIvaExc;
            oA.BasIvaCon = oAdcSri.BasIvaCon;
            oA.BasIvaCer = oAdcSri.BasIvaCer;
            oA.BasIvaExc1 = oAdcSri.BasIvaExc1;
            oA.BasIvaCer1 = oAdcSri.BasIvaCer1;
            oA.BasIvaCon1 = oAdcSri.BasIvaCon1;
            oA.Sri_tipoDoc = oAdcSri.Sri_tipoDoc;
            oA.fechaPagoDiv = oAdcSri.fechaPagoDiv;
            oA.imRentaSoc = oAdcSri.imRentaSoc;
            oA.anioUtDiv = oAdcSri.anioUtDiv;
            oA.NumCajBan = oAdcSri.NumCajBan;
            oA.PrecCajBan = oAdcSri.PrecCajBan;
            oA.fechaPagoDiv1 = oAdcSri.fechaPagoDiv1;
            oA.imRentaSoc1 = oAdcSri.imRentaSoc1;
            oA.anioUtDiv1 = oAdcSri.anioUtDiv1;
            oA.NumCajBan1 = oAdcSri.NumCajBan1;
            oA.PrecCajBan1 = oAdcSri.PrecCajBan1;
            oA.codRetAir2 = oAdcSri.codRetAir2;
            oA.baseImpAir2 = oAdcSri.baseImpAir2;
            oA.porcentajeAir2 = oAdcSri.porcentajeAir2;
            oA.valRetAir2 = oAdcSri.valRetAir2;
            oA.fechaPagoDiv2 = oAdcSri.fechaPagoDiv2;
            oA.imRentaSoc2 = oAdcSri.imRentaSoc2;
            oA.anioUtDiv2 = oAdcSri.anioUtDiv2;
            oA.NumCajBan2 = oAdcSri.NumCajBan2;
            oA.PrecCajBan2 = oAdcSri.PrecCajBan2;
            oA.codRetAir3 = oAdcSri.codRetAir3;
            oA.baseImpAir3 = oAdcSri.baseImpAir3;
            oA.porcentajeAir3 = oAdcSri.porcentajeAir3;
            oA.valRetAir3 = oAdcSri.valRetAir3;
            oA.fechaPagoDiv3 = oAdcSri.fechaPagoDiv3;
            oA.imRentaSoc3 = oAdcSri.imRentaSoc3;
            oA.anioUtDiv3 = oAdcSri.anioUtDiv3;
            oA.NumCajBan3 = oAdcSri.NumCajBan3;
            oA.PrecCajBan3 = oAdcSri.PrecCajBan3;
            oA.codDocSustento = oAdcSri.codDocSustento;
            oA.codDocSustentoAdcom = oAdcSri.codDocSustentoAdcom;
            oA.numDocSustento = oAdcSri.numDocSustento;
            oA.fechaEmisionDocSustento = oAdcSri.fechaEmisionDocSustento;
            oA.idsriDocSustento = oAdcSri.idsriDocSustento;
            //
            AdcSri2Row(oA, dr);
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
            // devuelve una tabla con los datos de la tabla AdcSri
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcSri");
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
        public static AdcSri Buscar(string sWhere)
        {
            // Busca en la tabla los datos indicados en el parámetro
            // el parámetro contendrá lo que se usará después del WHERE
            AdcSri oAdcSri = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcSri");
            string sel = "SELECT * FROM AdcSri9 WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oAdcSri = row2AdcSri(dt.Rows[0]);
            }
            return oAdcSri;
        }
        //
        // Actualizar: Actualiza los datos en la tabla usando la instancia actual
        //             Si la instancia no hace referencia a un registro existente, se creará uno nuevo
        //             Para comprobar si el objeto en memoria coincide con uno existente,
        //             se comprueba si el ID existe en la tabla.
        public string Actualizar()
        {
            string sel = "SELECT * FROM AdcSri9 WHERE SRI_SUCURSAL = '" + SRI_SUCURSAL + "' and SRI_DOCUMENTO = '" + SRI_DOCUMENTO + "' AND IdClaveDoc = " + IdClaveDoc.ToString();
            sel += " AND CodigoRetIvaBienes = '" + CodigoRetIvaBienes + "' and CodigoRetIvaServicios = '" + CodigoRetIvaServicios + "' and CodigoRetFuente = '" + CodigoRetFuente + "'";
            return Actualizar(sel);
        }
        public string Actualizar(string sel)
        {
            // El parámetro, que es una cadena de selección, indicará el criterio de actualización
            //
            // En caso de error, devolverá la cadena empezando por ERROR.
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcSri");
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
                AdcSri2Row(this, dt.Rows[0]);
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
            DataTable dt = new DataTable("AdcSri");
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
            nuevoAdcSri(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo AdcSri";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            string sel = "SELECT * FROM AdcSri9 WHERE SRI_SUCURSAL = '" + SRI_SUCURSAL + "' and SRI_DOCUMENTO = '" + SRI_DOCUMENTO + "' AND IdClaveDoc = " + IdClaveDoc.ToString();
            sel += " AND CodigoRetIvaBienes = '" + CodigoRetIvaBienes + "' and CodigoRetIvaServicios = '" + CodigoRetIvaServicios + "' and CodigoRetFuente = '" + CodigoRetFuente + "'";
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            // Borrar el registro al que apunta esta clase
            // En caso de error, devolverá la cadena de error empezando por ERROR:.
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("AdcSri");
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
