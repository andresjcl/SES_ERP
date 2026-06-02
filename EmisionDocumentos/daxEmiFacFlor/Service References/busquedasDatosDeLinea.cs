using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace adcDocumentos
{
    internal static class busquedasDatosDeLinea
    {
        internal static string buscarTipoCaja()
        {
            string ssql = "select Abreviación as TipCaja,Descripcion,Caracteristica1 as Ramos,Caracteristica2 as Fulls  from syscod where TipoReferencia = 'CajasFlor'";
            Buscar.frmBuscar buscaTipo = new Buscar.frmBuscar();
            string tipo = buscaTipo.Buscar(varbleComun.VarCom.strConxAdcom, ssql, "TipCaja", "Descripcion", "", "Buscar tipo de cajas");
            return tipo;            
        }
        internal static string buscarZonaProducto()
        {
            string ssql = "select Abreviación as Tip,Descripcion from syscod where TipoReferencia = 'zonaProducto'";
            Buscar.frmBuscar buscaTipo = new Buscar.frmBuscar();
            string tipo = buscaTipo.Buscar(varbleComun.VarCom.strConxAdcom, ssql, "Tip", "Descripcion", "", "Buscar Zona Producto");
            return tipo;
        }

        internal static string buscarBodega()
        {
            string ssql = "select bod_codigo, bod_nombre from Emp_Bod where emp_codigo = " + varbleComun.VarCom.codEmpresa;
            Buscar.frmBuscar buscaTipo = new Buscar.frmBuscar();
            string tipo = buscaTipo.Buscar(varbleComun.VarCom.strConxSyscod, ssql, "bod_codigo", "bod_nombre", "", "Buscar Bodegas");
            return tipo;
        }

    }
}
