using System.Collections.Generic;
using System; 
namespace BuscadorDocumentos
{
    public class listaDocumentos
    {
        public List<ClassDoc.idDocumento> IdDocs = new List<ClassDoc.idDocumento>();
    }

public class buscadorDoc
    {
        //static string strConxAdcom;
        //static string strConIniSis;

        //public buscadorDoc(string strAdc, string strSys)
        //{
        //    strConxAdcom = strAdc;
        //    strConIniSis = strSys;
        //}

        public double IniciaBusqueda(string claseDocumentos, string codCliente, string tipDocAConsultar, DateTime IniFec, ref string EsSuc, ref string EsTipDoc, ref double EsNumDoc, ref double idClaveDocapl, bool SinArt = false, string tipDocQueInicia = "", string TipoLiquidacion = "", string NroLiquidacion = "", string Tabla = "")
        {
            //double IniciaBusquedaRet = 0;
            //var prog = new frmBuscarDoc();
            //prog.claseDoctosPermitidos = claseDocumentos;   // clase de documentos 
            //prog.Codigo = codCliente;
            //prog.Solodoc = tipDocAConsultar;
            //prog.sinArt = SinArt;
            //prog.DocInicial = tipDocQueInicia;
            //prog.tabla = Tabla;
            //prog.docSucursal = EsSuc;
            //if ( IniFec > new DateTime(1900,1,1))
            //    prog.InicFec = IniFec;
            //else
            //    prog.InicFec = DateTime.Now;
            //prog.ShowDialog();
            //EsSuc = prog.SucRet;
            //EsTipDoc = prog.DocRet;
            //EsNumDoc = prog.NumRet;
            //idClaveDocapl = prog.idClaveDoc;
            //IniciaBusquedaRet = prog.NumRet;
            //prog.Dispose();
            //return IniciaBusquedaRet;

            double IniciaBusquedaRet = 0;

            using (var prog = new frmBuscarDoc())  // using asegura liberación correcta
            {
                prog.claseDoctosPermitidos = claseDocumentos;
                prog.Codigo = codCliente;
                prog.Solodoc = tipDocAConsultar;
                prog.sinArt = SinArt;
                prog.DocInicial = tipDocQueInicia;
                prog.tabla = Tabla;
                prog.docSucursal = EsSuc;

                if (IniFec > new DateTime(1900, 1, 1))
                    prog.InicFec = IniFec;
                else
                    prog.InicFec = DateTime.Now;

                prog.ShowDialog();

                EsSuc = prog.SucRet ?? "";
                EsTipDoc = prog.DocRet ?? "";
                EsNumDoc = prog.NumRet;
                idClaveDocapl = prog.idClaveDoc;
                IniciaBusquedaRet = prog.NumRet;
            }
            return IniciaBusquedaRet;
        }

        public string IniciaConsolidacion(string claseDocumentos, string codCliente, string tipDocAConsultar, DateTime IniFec, ref string EsSuc, ref string EsTipDoc, ref double EsNumDoc, ref double idClaveDocapl, bool SinArt = false, string tipDocQueInicia = "", string TipoLiquidacion = "", string NroLiquidacion = "", string Tabla = "")
        {
            string IniciaConsolidacionRet = "";
            var prog = new frmBuscarDoc();
            prog.claseDoctosPermitidos = "";   // clase de documentos 
            prog.Codigo = codCliente;
            prog.Solodoc = "";
            prog.sinArt = SinArt;
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