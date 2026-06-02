using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace daxClassEmp
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    //
    public class Emp_Par
    {
        private System.Int32 _Emp_Codigo=0;
        private System.Int32 _DefCta_NumNiveles=0;
        private System.Int32 _DefCta_NumGrupos=0;
        private System.String _DefCta_NumDigNivel="";
        private System.String _Par_ConTipCierre= "";
        private System.String _Par_InvTipCierre= "";
        private System.String _Par_VenIVA= "";
        private System.Boolean _Par_VenSNEmp=false;
        private System.Boolean _Par_VenSNAcuDoc= false;
        private System.String _Par_ComIVA= "";
        private System.Boolean _Par_ComSNEmp= false;
        private System.Boolean _Par_ComSNAcuDoc= false;
        private System.Int32 _Par_AcfNumNiv=0;
        private System.String _Par_RolCodMay= "";
        private System.Int32 _Par_RolTur=0;
        private System.String _Par_SucPri= "";
        private System.String _Par_ClvDsc= "";
        private System.String _Par_ClvIVA= "";
        private System.Boolean _Par_AcumHis= false;
        private System.Int32 _Par_FecDes=0;
        private System.Int32 _Par_Numerodigitos=0;
        private System.Int32 _Par_LimAtrasoEntrada=0;
        private System.Int32 _Par_LimExtraSalida=0;
        private System.Int32 _Par_LimExtraEntrada=0;
        private System.String _Par_DocPrincipalVta= "";
        private System.Byte _Par_Cheques=0;
        private System.String _Par_PagoCompras= "";
        private System.Int32 _DefCta_NumNiveles1=0;
        private System.Int32 _DefCta_NumGrupos1=0;
        private System.String _DefCta_NumDigNivel1= "";
        private System.Decimal _DefCtaV=0;
        private System.Int32 _Par_DigitosCostos=0;
        private System.Int32 _Par_DigitosPrecios=0;
        private System.Byte _Par_CruceDocSucursal=0;
        private System.String _par_PathImagenes= "";
        private System.Int32 _par_DiasMensualesAcf=0;
        private System.String _Emp_PathImagenes= "";
        private System.Int32 _Emp_DiasMensualesAcf=0;
        private System.Int32 _Prspto_NumNiveles=0;
        private System.Int32 _Prspto_NumGrupos=0;
        private System.String _Prspto_NumDigNivel= "";
        private System.String _path_tmpServer= "";
        private System.String _CtaLocalEmail= "";
        private System.Int32 _LongCodDirectorio = 0;

        private System.Int32 _par_ValiSRI = 0;
        private System.String _par_UrlSRI = "";

        //private System.Byte _Par_CruceDocSucursal = 0;
        private System.Byte _par_ValiDir = 0;

        private string sel="";

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
        public System.Int32 Emp_Codigo
        {
            get
            {
                return _Emp_Codigo;
            }
            set
            {
                _Emp_Codigo = value;
            }
        }
        public System.Int32 DefCta_NumNiveles
        {
            get
            {
                return _DefCta_NumNiveles;
            }
            set
            {
                _DefCta_NumNiveles = value;
            }
        }
        public System.Int32 DefCta_NumGrupos
        {
            get
            {
                return _DefCta_NumGrupos;
            }
            set
            {
                _DefCta_NumGrupos = value;
            }
        }
        public System.String DefCta_NumDigNivel
        {
            get
            {
                return ajustarAncho(_DefCta_NumDigNivel, 50);
            }
            set
            {
                _DefCta_NumDigNivel = value;
            }
        }
        public System.String Par_ConTipCierre
        {
            get
            {
                return ajustarAncho(_Par_ConTipCierre, 1);
            }
            set
            {
                _Par_ConTipCierre = value;
            }
        }
        public System.String Par_InvTipCierre
        {
            get
            {
                return ajustarAncho(_Par_InvTipCierre, 1);
            }
            set
            {
                _Par_InvTipCierre = value;
            }
        }
        public System.String Par_VenIVA
        {
            get
            {
                return ajustarAncho(_Par_VenIVA, 50);
            }
            set
            {
                _Par_VenIVA = value;
            }
        }
        public System.Boolean Par_VenSNEmp
        {
            get
            {
                return _Par_VenSNEmp;
            }
            set
            {
                _Par_VenSNEmp = value;
            }
        }
        public System.Boolean Par_VenSNAcuDoc
        {
            get
            {
                return _Par_VenSNAcuDoc;
            }
            set
            {
                _Par_VenSNAcuDoc = value;
            }
        }
        public System.String Par_ComIVA
        {
            get
            {
                return ajustarAncho(_Par_ComIVA, 12);
            }
            set
            {
                _Par_ComIVA = value;
            }
        }
        public System.Boolean Par_ComSNEmp
        {
            get
            {
                return _Par_ComSNEmp;
            }
            set
            {
                _Par_ComSNEmp = value;
            }
        }
        public System.Boolean Par_ComSNAcuDoc
        {
            get
            {
                return _Par_ComSNAcuDoc;
            }
            set
            {
                _Par_ComSNAcuDoc = value;
            }
        }
        public System.Int32 Par_AcfNumNiv
        {
            get
            {
                return _Par_AcfNumNiv;
            }
            set
            {
                _Par_AcfNumNiv = value;
            }
        }
        public System.String Par_RolCodMay
        {
            get
            {
                return ajustarAncho(_Par_RolCodMay, 10);
            }
            set
            {
                _Par_RolCodMay = value;
            }
        }
        public System.Int32 Par_RolTur
        {
            get
            {
                return _Par_RolTur;
            }
            set
            {
                _Par_RolTur = value;
            }
        }
        public System.String Par_SucPri
        {
            get
            {
                return ajustarAncho(_Par_SucPri, 3);
            }
            set
            {
                _Par_SucPri = value;
            }
        }
        public System.String Par_ClvDsc
        {
            get
            {
                return ajustarAncho(_Par_ClvDsc, 8);
            }
            set
            {
                _Par_ClvDsc = value;
            }
        }
        public System.String Par_ClvIVA
        {
            get
            {
                return ajustarAncho(_Par_ClvIVA, 8);
            }
            set
            {
                _Par_ClvIVA = value;
            }
        }
        public System.Boolean Par_AcumHis
        {
            get
            {
                return _Par_AcumHis;
            }
            set
            {
                _Par_AcumHis = value;
            }
        }
        public System.Int32 Par_FecDes
        {
            get
            {
                return _Par_FecDes;
            }
            set
            {
                _Par_FecDes = value;
            }
        }
        public System.Int32 Par_Numerodigitos
        {
            get
            {
                return _Par_Numerodigitos;
            }
            set
            {
                _Par_Numerodigitos = value;
            }
        }
        public System.Int32 Par_LimAtrasoEntrada
        {
            get
            {
                return _Par_LimAtrasoEntrada;
            }
            set
            {
                _Par_LimAtrasoEntrada = value;
            }
        }
        public System.Int32 Par_LimExtraSalida
        {
            get
            {
                return _Par_LimExtraSalida;
            }
            set
            {
                _Par_LimExtraSalida = value;
            }
        }
        public System.Int32 Par_LimExtraEntrada
        {
            get
            {
                return _Par_LimExtraEntrada;
            }
            set
            {
                _Par_LimExtraEntrada = value;
            }
        }
        public System.String Par_DocPrincipalVta
        {
            get
            {
                return ajustarAncho(_Par_DocPrincipalVta, 5);
            }
            set
            {
                _Par_DocPrincipalVta = value;
            }
        }
        public System.Byte Par_Cheques
        {
            get
            {
                return _Par_Cheques;
            }
            set
            {
                _Par_Cheques = value;
            }
        }
        public System.String Par_PagoCompras
        {
            get
            {
                return ajustarAncho(_Par_PagoCompras, 3);
            }
            set
            {
                _Par_PagoCompras = value;
            }
        }
        public System.Int32 DefCta_NumNiveles1
        {
            get
            {
                return _DefCta_NumNiveles1;
            }
            set
            {
                _DefCta_NumNiveles1 = value;
            }
        }
        public System.Int32 DefCta_NumGrupos1
        {
            get
            {
                return _DefCta_NumGrupos1;
            }
            set
            {
                _DefCta_NumGrupos1 = value;
            }
        }
        public System.String DefCta_NumDigNivel1
        {
            get
            {
                return ajustarAncho(_DefCta_NumDigNivel1, 50);
            }
            set
            {
                _DefCta_NumDigNivel1 = value;
            }
        }
        public System.Decimal DefCtaV
        {
            get
            {
                return _DefCtaV;
            }
            set
            {
                _DefCtaV = value;
            }
        }
        public System.Int32 Par_DigitosCostos
        {
            get
            {
                return _Par_DigitosCostos;
            }
            set
            {
                _Par_DigitosCostos = value;
            }
        }
        public System.Int32 Par_DigitosPrecios
        {
            get
            {
                return _Par_DigitosPrecios;
            }
            set
            {
                _Par_DigitosPrecios = value;
            }
        }
        public System.Byte Par_CruceDocSucursal
        {
            get
            {
                return _Par_CruceDocSucursal;
            }
            set
            {
                _Par_CruceDocSucursal = value;
            }
        }
        public System.String par_PathImagenes
        {
            get
            {
                // Seguramente sería mejor sin ajustar el ancho...
                //return ajustarAncho(_par_PathImagenes,512);
                return _par_PathImagenes;
            }
            set
            {
                _par_PathImagenes = value;
            }
        }
        public System.Int32 par_DiasMensualesAcf
        {
            get
            {
                return _par_DiasMensualesAcf;
            }
            set
            {
                _par_DiasMensualesAcf = value;
            }
        }
        public System.String Emp_PathImagenes
        {
            get
            {
                // Seguramente sería mejor sin ajustar el ancho...
                //return ajustarAncho(_Emp_PathImagenes,512);
                return _Emp_PathImagenes;
            }
            set
            {
                _Emp_PathImagenes = value;
            }
        }
        public System.Int32 Emp_DiasMensualesAcf
        {
            get
            {
                return _Emp_DiasMensualesAcf;
            }
            set
            {
                _Emp_DiasMensualesAcf = value;
            }
        }
        public System.Int32 Prspto_NumNiveles
        {
            get
            {
                return _Prspto_NumNiveles;
            }
            set
            {
                _Prspto_NumNiveles = value;
            }
        }
        public System.Int32 Prspto_NumGrupos
        {
            get
            {
                return _Prspto_NumGrupos;
            }
            set
            {
                _Prspto_NumGrupos = value;
            }
        }
        public System.String Prspto_NumDigNivel
        {
            get
            {
                return ajustarAncho(_Prspto_NumDigNivel, 50);
            }
            set
            {
                _Prspto_NumDigNivel = value;
            }
        }
        public System.String path_tmpServer
        {
            get
            {
                return ajustarAncho(_path_tmpServer, 200);
            }
            set
            {
                _path_tmpServer = value;
            }
        }
        public System.String CtaLocalEmail
        {
            get
            {
                return ajustarAncho(_CtaLocalEmail, 200);
            }
            set
            {
                _CtaLocalEmail = value;
            }
        }
        
        public System.Int32 LongCodDirectorio
        {
            get
            {
                return _LongCodDirectorio;
            }
            set
            {
                _LongCodDirectorio = value;
            }
        }

        public System.Byte par_ValiDir
        {
            get
            {
                return _par_ValiDir;
            }
            set
            {
                _par_ValiDir = value;
            }
        }

        public System.Int32 par_ValiSRI
        {
            get
            {
                return _par_ValiSRI;
            }
            set
            {
                _par_ValiSRI = value;
            }
        }
        public System.String par_UrlSRI
        {
            get
            {
                return ajustarAncho(_par_UrlSRI, 250);
            }
            set
            {
                _par_UrlSRI = value;
            }
        }

        //
        //
        // Campos y métodos compartidos (estáticos) para gestionar la base de datos
        //
        // La cadena de conexión a la base de datos
        //private static string cadenaConexion = @"";
        private static string cadenaConexion = DattCom.datosEmpresa.strConIniSis;
        // La cadena de selección
        public static string CadenaSelect = "";
        //
        public Emp_Par()
        {
        }
        public Emp_Par(string conex)
        {
            cadenaConexion = DattCom.datosEmpresa.strConIniSis;
        }
        //
        // Métodos compartidos (estáticos) privados
        //
        // asigna una fila de la tabla a un objeto Emp_Par
        private static Emp_Par row2Emp_Par(DataRow r)
        {
            // asigna a un objeto Emp_Par los datos del dataRow indicado
            Emp_Par oEmp_Par = new Emp_Par();
            //
            oEmp_Par.Emp_Codigo = System.Int32.Parse("0" + r["Emp_Codigo"].ToString());
            oEmp_Par.DefCta_NumNiveles = System.Int32.Parse("0" + r["DefCta_NumNiveles"].ToString());
            oEmp_Par.DefCta_NumGrupos = System.Int32.Parse("0" + r["DefCta_NumGrupos"].ToString());
            oEmp_Par.DefCta_NumDigNivel = r["DefCta_NumDigNivel"].ToString();
            oEmp_Par.Par_ConTipCierre = r["Par_ConTipCierre"].ToString();
            oEmp_Par.Par_InvTipCierre = r["Par_InvTipCierre"].ToString();
            oEmp_Par.Par_VenIVA = r["Par_VenIVA"].ToString();
            try
            {
                oEmp_Par.Par_VenSNEmp = System.Boolean.Parse(r["Par_VenSNEmp"].ToString());
            }
            catch
            {
                oEmp_Par.Par_VenSNEmp = false;
            }
            try
            {
                oEmp_Par.Par_VenSNAcuDoc = System.Boolean.Parse(r["Par_VenSNAcuDoc"].ToString());
            }
            catch
            {
                oEmp_Par.Par_VenSNAcuDoc = false;
            }
            oEmp_Par.Par_ComIVA = r["Par_ComIVA"].ToString();
            try
            {
                oEmp_Par.Par_ComSNEmp = System.Boolean.Parse(r["Par_ComSNEmp"].ToString());
            }
            catch
            {
                oEmp_Par.Par_ComSNEmp = false;
            }
            try
            {
                oEmp_Par.Par_ComSNAcuDoc = System.Boolean.Parse(r["Par_ComSNAcuDoc"].ToString());
            }
            catch
            {
                oEmp_Par.Par_ComSNAcuDoc = false;
            }
            oEmp_Par.Par_AcfNumNiv = System.Int32.Parse("0" + r["Par_AcfNumNiv"].ToString());
            oEmp_Par.Par_RolCodMay = r["Par_RolCodMay"].ToString();
            oEmp_Par.Par_RolTur = System.Int32.Parse("0" + r["Par_RolTur"].ToString());
            oEmp_Par.Par_SucPri = r["Par_SucPri"].ToString();
            oEmp_Par.Par_ClvDsc = r["Par_ClvDsc"].ToString();
            oEmp_Par.Par_ClvIVA = r["Par_ClvIVA"].ToString();
            try
            {
                oEmp_Par.Par_AcumHis = System.Boolean.Parse(r["Par_AcumHis"].ToString());
            }
            catch
            {
                oEmp_Par.Par_AcumHis = false;
            }
            oEmp_Par.Par_FecDes = System.Int32.Parse("0" + r["Par_FecDes"].ToString());
            oEmp_Par.Par_Numerodigitos = System.Int32.Parse("0" + r["Par_Numerodigitos"].ToString());
            oEmp_Par.Par_LimAtrasoEntrada = System.Int32.Parse("0" + r["Par_LimAtrasoEntrada"].ToString());
            oEmp_Par.Par_LimExtraSalida = System.Int32.Parse("0" + r["Par_LimExtraSalida"].ToString());
            oEmp_Par.Par_LimExtraEntrada = System.Int32.Parse("0" + r["Par_LimExtraEntrada"].ToString());
            oEmp_Par.Par_DocPrincipalVta = r["Par_DocPrincipalVta"].ToString();
            oEmp_Par.Par_Cheques = System.Byte.Parse("0" + r["Par_Cheques"].ToString());
            oEmp_Par.Par_PagoCompras = r["Par_PagoCompras"].ToString();
            oEmp_Par.DefCta_NumNiveles1 = System.Int32.Parse("0" + r["DefCta_NumNiveles1"].ToString());
            oEmp_Par.DefCta_NumGrupos1 = System.Int32.Parse("0" + r["DefCta_NumGrupos1"].ToString());
            oEmp_Par.DefCta_NumDigNivel1 = r["DefCta_NumDigNivel1"].ToString();
            oEmp_Par.DefCtaV = System.Decimal.Parse("0" + r["DefCtaV"].ToString());
            oEmp_Par.Par_DigitosCostos = System.Int32.Parse("0" + r["Par_DigitosCostos"].ToString());
            oEmp_Par.Par_DigitosPrecios = System.Int32.Parse("0" + r["Par_DigitosPrecios"].ToString());
            oEmp_Par.Par_CruceDocSucursal = System.Byte.Parse("0" + r["Par_CruceDocSucursal"].ToString());
            oEmp_Par.par_PathImagenes = r["par_PathImagenes"].ToString();
            oEmp_Par.par_DiasMensualesAcf = System.Int32.Parse("0" + r["par_DiasMensualesAcf"].ToString());
            oEmp_Par.Emp_PathImagenes = r["Emp_PathImagenes"].ToString();
            oEmp_Par.Emp_DiasMensualesAcf = System.Int32.Parse("0" + r["Emp_DiasMensualesAcf"].ToString());
            oEmp_Par.Prspto_NumNiveles = System.Int32.Parse("0" + r["Prspto_NumNiveles"].ToString());
            oEmp_Par.Prspto_NumGrupos = System.Int32.Parse("0" + r["Prspto_NumGrupos"].ToString());
            oEmp_Par.Prspto_NumDigNivel = r["Prspto_NumDigNivel"].ToString();
            oEmp_Par.path_tmpServer = r["path_tmpServer"].ToString();
            oEmp_Par.CtaLocalEmail = r["CtaLocalEmail"].ToString();
            oEmp_Par.LongCodDirectorio = Int32.Parse ("0"+r["LongCodDirectorio"].ToString());

            oEmp_Par.par_ValiDir = System.Byte.Parse("0" + r["par_ValiDir"].ToString());
            oEmp_Par.par_ValiSRI = System.Byte.Parse("0" + r["par_ValiSRI"].ToString());
            oEmp_Par.par_UrlSRI = r["par_UrlSRI"].ToString();


            //
            return oEmp_Par;
        }
        //
        // asigna un objeto Emp_Par a la fila indicada
        private static void Emp_Par2Row(Emp_Par oEmp_Par, DataRow r)
        {
            // asigna un objeto Emp_Par al dataRow indicado
            r["Emp_Codigo"] = oEmp_Par.Emp_Codigo;
            r["DefCta_NumNiveles"] = oEmp_Par.DefCta_NumNiveles;
            r["DefCta_NumGrupos"] = oEmp_Par.DefCta_NumGrupos;
            r["DefCta_NumDigNivel"] = oEmp_Par.DefCta_NumDigNivel;
            r["Par_ConTipCierre"] = oEmp_Par.Par_ConTipCierre;
            r["Par_InvTipCierre"] = oEmp_Par.Par_InvTipCierre;
            r["Par_VenIVA"] = oEmp_Par.Par_VenIVA;
            r["Par_VenSNEmp"] = oEmp_Par.Par_VenSNEmp;
            r["Par_VenSNAcuDoc"] = oEmp_Par.Par_VenSNAcuDoc;
            r["Par_ComIVA"] = oEmp_Par.Par_ComIVA;
            r["Par_ComSNEmp"] = oEmp_Par.Par_ComSNEmp;
            r["Par_ComSNAcuDoc"] = oEmp_Par.Par_ComSNAcuDoc;
            r["Par_AcfNumNiv"] = oEmp_Par.Par_AcfNumNiv;
            r["Par_RolCodMay"] = oEmp_Par.Par_RolCodMay;
            r["Par_RolTur"] = oEmp_Par.Par_RolTur;
            r["Par_SucPri"] = oEmp_Par.Par_SucPri;
            r["Par_ClvDsc"] = oEmp_Par.Par_ClvDsc;
            r["Par_ClvIVA"] = oEmp_Par.Par_ClvIVA;
            r["Par_AcumHis"] = oEmp_Par.Par_AcumHis;
            r["Par_FecDes"] = oEmp_Par.Par_FecDes;
            r["Par_Numerodigitos"] = oEmp_Par.Par_Numerodigitos;
            r["Par_LimAtrasoEntrada"] = oEmp_Par.Par_LimAtrasoEntrada;
            r["Par_LimExtraSalida"] = oEmp_Par.Par_LimExtraSalida;
            r["Par_LimExtraEntrada"] = oEmp_Par.Par_LimExtraEntrada;
            r["Par_DocPrincipalVta"] = oEmp_Par.Par_DocPrincipalVta;
            r["Par_Cheques"] = oEmp_Par.Par_Cheques;
            r["Par_PagoCompras"] = oEmp_Par.Par_PagoCompras;
            r["DefCta_NumNiveles1"] = oEmp_Par.DefCta_NumNiveles1;
            r["DefCta_NumGrupos1"] = oEmp_Par.DefCta_NumGrupos1;
            r["DefCta_NumDigNivel1"] = oEmp_Par.DefCta_NumDigNivel1;
            r["DefCtaV"] = oEmp_Par.DefCtaV;
            r["Par_DigitosCostos"] = oEmp_Par.Par_DigitosCostos;
            r["Par_DigitosPrecios"] = oEmp_Par.Par_DigitosPrecios;
            r["Par_CruceDocSucursal"] = oEmp_Par.Par_CruceDocSucursal;
            r["par_PathImagenes"] = oEmp_Par.par_PathImagenes;
            r["par_DiasMensualesAcf"] = oEmp_Par.par_DiasMensualesAcf;
            r["Emp_PathImagenes"] = oEmp_Par.Emp_PathImagenes;
            r["Emp_DiasMensualesAcf"] = oEmp_Par.Emp_DiasMensualesAcf;
            r["Prspto_NumNiveles"] = oEmp_Par.Prspto_NumNiveles;
            r["Prspto_NumGrupos"] = oEmp_Par.Prspto_NumGrupos;
            r["Prspto_NumDigNivel"] = oEmp_Par.Prspto_NumDigNivel;
            r["path_tmpServer"] = oEmp_Par.path_tmpServer;
            r["CtaLocalEmail"] = oEmp_Par.CtaLocalEmail;
            r["LongCodDirectorio"] = oEmp_Par.LongCodDirectorio;

            r["par_ValiDir"] = oEmp_Par.par_ValiDir;
            r["par_ValiSRI"] = oEmp_Par.par_ValiSRI;
            r["par_UrlSRI"] = oEmp_Par.par_UrlSRI;
        }
        //
        // crea una nueva fila y la asigna a un objeto Emp_Par
        private static void nuevoEmp_Par(DataTable dt, Emp_Par oEmp_Par)
        {
            // Crear un nuevo Emp_Par
            DataRow dr = dt.NewRow();
            Emp_Par oE = row2Emp_Par(dr);
            //
            oE.Emp_Codigo = oEmp_Par.Emp_Codigo;
            oE.DefCta_NumNiveles = oEmp_Par.DefCta_NumNiveles;
            oE.DefCta_NumGrupos = oEmp_Par.DefCta_NumGrupos;
            oE.DefCta_NumDigNivel = oEmp_Par.DefCta_NumDigNivel;
            oE.Par_ConTipCierre = oEmp_Par.Par_ConTipCierre;
            oE.Par_InvTipCierre = oEmp_Par.Par_InvTipCierre;
            oE.Par_VenIVA = oEmp_Par.Par_VenIVA;
            oE.Par_VenSNEmp = oEmp_Par.Par_VenSNEmp;
            oE.Par_VenSNAcuDoc = oEmp_Par.Par_VenSNAcuDoc;
            oE.Par_ComIVA = oEmp_Par.Par_ComIVA;
            oE.Par_ComSNEmp = oEmp_Par.Par_ComSNEmp;
            oE.Par_ComSNAcuDoc = oEmp_Par.Par_ComSNAcuDoc;
            oE.Par_AcfNumNiv = oEmp_Par.Par_AcfNumNiv;
            oE.Par_RolCodMay = oEmp_Par.Par_RolCodMay;
            oE.Par_RolTur = oEmp_Par.Par_RolTur;
            oE.Par_SucPri = oEmp_Par.Par_SucPri;
            oE.Par_ClvDsc = oEmp_Par.Par_ClvDsc;
            oE.Par_ClvIVA = oEmp_Par.Par_ClvIVA;
            oE.Par_AcumHis = oEmp_Par.Par_AcumHis;
            oE.Par_FecDes = oEmp_Par.Par_FecDes;
            oE.Par_Numerodigitos = oEmp_Par.Par_Numerodigitos;
            oE.Par_LimAtrasoEntrada = oEmp_Par.Par_LimAtrasoEntrada;
            oE.Par_LimExtraSalida = oEmp_Par.Par_LimExtraSalida;
            oE.Par_LimExtraEntrada = oEmp_Par.Par_LimExtraEntrada;
            oE.Par_DocPrincipalVta = oEmp_Par.Par_DocPrincipalVta;
            oE.Par_Cheques = oEmp_Par.Par_Cheques;
            oE.Par_PagoCompras = oEmp_Par.Par_PagoCompras;
            oE.DefCta_NumNiveles1 = oEmp_Par.DefCta_NumNiveles1;
            oE.DefCta_NumGrupos1 = oEmp_Par.DefCta_NumGrupos1;
            oE.DefCta_NumDigNivel1 = oEmp_Par.DefCta_NumDigNivel1;
            oE.DefCtaV = oEmp_Par.DefCtaV;
            oE.Par_DigitosCostos = oEmp_Par.Par_DigitosCostos;
            oE.Par_DigitosPrecios = oEmp_Par.Par_DigitosPrecios;
            oE.Par_CruceDocSucursal = oEmp_Par.Par_CruceDocSucursal;
            oE.par_PathImagenes = oEmp_Par.par_PathImagenes;
            oE.par_DiasMensualesAcf = oEmp_Par.par_DiasMensualesAcf;
            oE.Emp_PathImagenes = oEmp_Par.Emp_PathImagenes;
            oE.Emp_DiasMensualesAcf = oEmp_Par.Emp_DiasMensualesAcf;
            oE.Prspto_NumNiveles = oEmp_Par.Prspto_NumNiveles;
            oE.Prspto_NumGrupos = oEmp_Par.Prspto_NumGrupos;
            oE.Prspto_NumDigNivel = oEmp_Par.Prspto_NumDigNivel;
            oE.path_tmpServer = oEmp_Par.path_tmpServer;
            oE.CtaLocalEmail = oEmp_Par.CtaLocalEmail;
            oE.LongCodDirectorio = oEmp_Par.LongCodDirectorio;

            oE.par_ValiDir = oEmp_Par.par_ValiDir;
            oE.par_ValiSRI = oEmp_Par.par_ValiSRI;
            oE.par_UrlSRI = oEmp_Par.par_UrlSRI;
            //
            Emp_Par2Row(oE, dr);
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
            // devuelve una tabla con los datos de la tabla Emp_Par
            SqlDataAdapter da;
            DataTable dt = new DataTable("Emp_Par");
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
        public static Emp_Par Buscar(string sWhere)
        {
            // Busca en la tabla los datos indicados en el parámetro
            // el parámetro contendrá lo que se usará después del WHERE
            Emp_Par oEmp_Par = null;
            SqlDataAdapter da;
            DataTable dt = new DataTable("Emp_Par");
            string sel = "SELECT * FROM Emp_Par WHERE " + sWhere;
            //
            da = new SqlDataAdapter(sel, cadenaConexion);
            da.Fill(dt);
            //
            if (dt.Rows.Count > 0)
            {
                oEmp_Par = row2Emp_Par(dt.Rows[0]);
            }
            return oEmp_Par;
        }
        //
        // Actualizar: Actualiza los datos en la tabla usando la instancia actual
        //             Si la instancia no hace referencia a un registro existente, se creará uno nuevo
        //             Para comprobar si el objeto en memoria coincide con uno existente,
        //             se comprueba si el Emp_Codigo existe en la tabla.
        public string Actualizar()
        {
           sel = "SELECT * FROM Emp_Par WHERE Emp_Codigo = " + this.Emp_Codigo.ToString();
            return Actualizar(sel);
        }
        public string Actualizar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("Emp_Par");
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
                Emp_Par2Row(this, dt.Rows[0]);
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
            DataTable dt = new DataTable("Emp_Par");
            CadenaSelect = sel;
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
            nuevoEmp_Par(dt, this);
            //
            try
            {
                da.Update(dt);
                dt.AcceptChanges();
                return "Se ha creado un nuevo Emp_Par";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }
        //
        public string Borrar()
        {
            string sel = "SELECT * FROM Emp_Par WHERE Emp_Codigo = " + this.Emp_Codigo.ToString();
            //
            return Borrar(sel);
        }
        public string Borrar(string sel)
        {
            SqlConnection cnn;
            SqlDataAdapter da;
            DataTable dt = new DataTable("Emp_Par");
            //
            cnn = new SqlConnection(cadenaConexion);
            da = new SqlDataAdapter(sel, cnn);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.DeleteCommand = cb.GetDeleteCommand();
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
