using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace adcDocumentos
{
    static public class recordarOpciones
    {
        static public void registraEvento(ClassDoc.idDocumento iddoc,string evento, double valor)
        {
            registraEvntos.registrar.registraEventoDoc(varbleComun.VarCom.strConxSyscod, varbleComun.VarCom.codEmpresa.ToString(), varbleComun.VarCom.usr, "ADX", Environment.MachineName, evento, iddoc.Sucursal, iddoc.Tipo, iddoc.numero.ToString(), valor.ToString());
        }
    }
}
