using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DattCom;

namespace DctosEmi
{
    static public class recordarOpciones
    {
        static public void registraEvento(ClassDoc.idDocumento iddoc,string evento, double valor)
        {
            AuditSis.registrar.registraEventoDoc(datosEmpresa.strConxSyscod, datosEmpresa.codEmpresa.ToString(), datosEmpresa.usr, "ADX", Environment.MachineName, evento, iddoc.Sucursal, iddoc.Tipo, iddoc.numero.ToString(), valor.ToString());
        }
    }
}
