using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DattCom;

namespace leeDocXml
{
    internal static class crearDirectorio
    {
        internal static void grabarRegistro(string Ruc,string nombre,string codigo,string direccion,string email, int tipoDoc, string tipoId)
        {
            Identificacion adc = new Identificacion(datosEmpresa.strConxAdcom);
            
            DaxDocElectronicos.Feutilidad  util = new DaxDocElectronicos.Feutilidad ();
            adc.TipoIdentificacion = util.tipoIdRol(tipoId);
            adc.CedulaIdentidadRuc = Ruc;
            adc.NombreImpresion = nombre;
            adc.Codigo = codigo;
            adc.Domicilio = direccion;
            adc.Nombres = nombre;
            adc.CorreoElectrónico = email;
            adc.TipoPersona = "J";
            adc.EsProveedor = true;
            if (tipoDoc==1) adc.EsCliente = true;
            adc.Crear();
        }
    }
}

