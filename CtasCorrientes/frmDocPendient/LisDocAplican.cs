using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocPendientes
{
    public class DocAplica
    {
        public double ValorCruce = 0;
        public string Sucursal = "";
        public string TipoDoc = "";
        public string Numero = "";
        public double IdClaveDoc = 0;
        public string CodigoCliente = "";
        public string Nombre = "";
        public string tipodocumentoSri = "";
        public string sriFormaPagoSriDocumentos;
        public string formaDePagoDocumento;
        public string fechaDocumento;
    }
    public class ListDocAplican
    {
       public List<DocAplica> ListaDocAplican = new List<DocAplica>();
    }

}

