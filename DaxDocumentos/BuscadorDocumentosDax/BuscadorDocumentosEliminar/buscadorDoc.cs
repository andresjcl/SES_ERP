using System;

namespace BuscadorDocumentos
{
    public class buscadorDoc
    {
        public static string strConxAdcom;
        public static string strConxDaxsys;

        public buscadorDoc(string strAdc, string strSys)
        {
            strConxAdcom = strAdc;
            strConxDaxsys = strSys;
        }

        public double IniciaBusqueda(string claseDocumentos, string codCliente, string tipDocAConsultar, DateTime IniFec, ref string EsSuc, ref string EsTipDoc, ref double EsNumDoc, ref double idClaveDocapl, bool SinArt = false, string tipDocQueInicia = "", string TipoLiquidacion = "", string NroLiquidacion = "", string Tabla = "")
        {
            double IniciaBusquedaRet = default;
            var prog = new frmBuscarDoc();
            // MsgBox(" " & tipDocOriginal & " - " & codCliente & " - " & tipDocAConsultar & " - " & EsTipDoc)
            prog.claseDoctosPermitidos = claseDocumentos;   // clase de documentos 
            prog.Codigo = codCliente;
            prog.Solodoc = tipDocAConsultar;
            prog.sinArt = SinArt;
            prog.LiquidacionTip = TipoLiquidacion;
            prog.LiquidacionNum = NroLiquidacion;
            // tipo de documento que llamo a la copiadora
            prog.DocInicial = tipDocQueInicia;
            prog.tabla = Tabla;
            prog.docSucursal = EsSuc;
            if ( IniFec > new DateTime(1900,1,1))
                prog.InicFec = IniFec;
            else
                prog.InicFec = DateTime.Now;
            prog.ShowDialog();
            EsSuc = prog.SucRet;
            EsTipDoc = prog.DocRet;
            EsNumDoc = prog.NumRet;
            idClaveDocapl = prog.idClaveDoc;
            IniciaBusquedaRet = prog.NumRet;
            prog.Dispose();
            return IniciaBusquedaRet;
        }

        public string IniciaConsolidacion(string claseDocumentos, string codCliente, string tipDocAConsultar, DateTime IniFec, ref string EsSuc, ref string EsTipDoc, ref double EsNumDoc, ref double idClaveDocapl, bool SinArt = false, string tipDocQueInicia = "", string TipoLiquidacion = "", string NroLiquidacion = "", string Tabla = "")
        {
            string IniciaConsolidacionRet = default;
            var prog = new frmBuscarDoc();
            // MsgBox(" " & tipDocOriginal & " - " & codCliente & " - " & tipDocAConsultar & " - " & EsTipDoc)
            prog.claseDoctosPermitidos = "";   // clase de documentos 
            prog.Codigo = codCliente;
            prog.Solodoc = "";
            prog.sinArt = SinArt;
            prog.LiquidacionTip = TipoLiquidacion;
            prog.LiquidacionNum = NroLiquidacion;
            prog.DocInicial = claseDocumentos;
            prog.tabla = Tabla;
            prog.docSucursal = EsSuc;
            if (IniFec > new DateTime(1900, 1, 1))
                prog.InicFec = IniFec;
            else
                prog.InicFec = DateTime.Now;
            prog.estaConsolidando = true;
            prog.ShowDialog();
            EsSuc = prog.SucRet;
            EsTipDoc = prog.DocRet;
            EsNumDoc = prog.NumRet;
            idClaveDocapl = prog.idClaveDoc;
            IniciaConsolidacionRet = prog.DocRet;
            return prog.Lista;
        }
    }
}