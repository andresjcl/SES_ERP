using System;
using System.Data ;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mntUsrs
{

    public class autorizaUserDirectorio
    { 
            public mntUsrs.autorizacion autUsrIdentificacion = new mntUsrs.autorizacion();
            public mntUsrs.autorizacion autUsrDatoPersonal = new mntUsrs.autorizacion();
            public mntUsrs.autorizacion autUsrCliente = new mntUsrs.autorizacion();
            public mntUsrs.autorizacion autUsrProveedor = new mntUsrs.autorizacion();
            public mntUsrs.autorizacion autUsrEmpleado = new mntUsrs.autorizacion();
            public mntUsrs.autorizacion autUsrFamiliares = new mntUsrs.autorizacion();
            public mntUsrs.autorizacion autUsrContactos = new mntUsrs.autorizacion();
            public mntUsrs.autorizacion autUsrAlias = new mntUsrs.autorizacion();

            public autorizaUserDirectorio(string Identifica, string strConxDaxSys, string EmpCodigo)
            {
                autorizacionesUser mntusuario = new autorizacionesUser();
                definicionesDirectorio definicion = new definicionesDirectorio();

                autUsrIdentificacion = mntusuario.autoDirectorio(Identifica, "mnuon" + definicion.identificacion, strConxDaxSys, EmpCodigo);
                autUsrDatoPersonal = mntusuario.autoDirectorio(Identifica, "mnuon" + definicion.datosPersonales, strConxDaxSys, EmpCodigo);
                autUsrCliente = mntusuario.autoDirectorio(Identifica, "mnuon" + definicion.cliente, strConxDaxSys, EmpCodigo);
                autUsrProveedor = mntusuario.autoDirectorio(Identifica, "mnuon" + definicion.proveedor, strConxDaxSys, EmpCodigo);
                autUsrEmpleado = mntusuario.autoDirectorio(Identifica, "mnuon" + definicion.empleado, strConxDaxSys, EmpCodigo);
                autUsrFamiliares = mntusuario.autoDirectorio(Identifica, "mnuon" + definicion.fmiliares, strConxDaxSys, EmpCodigo);
                autUsrContactos = mntusuario.autoDirectorio(Identifica, "mnuon" + definicion.contactos, strConxDaxSys, EmpCodigo);
                autUsrAlias = mntusuario.autoDirectorio(Identifica, "mnuon" + definicion.alias, strConxDaxSys, EmpCodigo);

                mntusuario = null;
                definicion = null;
            }
    
    }

    public class autorizaUserMenu
    {
        public mntUsrs.autorizacion autUsrMenuPrincipal = new mntUsrs.autorizacion();
          
        public autorizaUserMenu(string clave, string Identifica, string strConxDaxSys, string EmpCodigo, string sistema)
        {
            autorizacion autUser = new autorizacion ();
            string ssql = "select * from  sys_accesos  where idUsuario = '" + Identifica + "' and idempresa = " + EmpCodigo  + " and idSistema = '" + sistema + "' and idOpcion = '" + clave + "' ";
            ManejoBases manBas = new ManejoBases();            
            DataTable dtAccesos = manBas.leerTablas(strConxDaxSys,ssql);
            if (dtAccesos.Rows.Count > 0)
            {
                string aux = dtAccesos.Rows[0]["accnvo"].ToString() + "      ";
                if (aux.Substring(0, 1) == "X") autUser.crearAbierto = true;
                if (aux.Substring(2, 1) == "X") autUser.consultar = true;
                if (aux.Substring(1, 1) == "X") autUser.modificar = true;
                if (aux.Substring(3, 1) == "X") autUser.eliminar = true;
                if (aux.Substring(4, 1) == "X") autUser.imprimir = true;
                autUser.existe = true;

                autUser.visible = (autUser.crearAbierto == true || autUser.consultar == true || autUser.modificar == true || autUser.imprimir == true || autUser.eliminar == true);
            }
        }
    }
    
    public class autorizacion
    {
        public Boolean existe = false;
        public Boolean crearAbierto = false;
        public Boolean consultar = false;  
        public Boolean modificar = false;
        public Boolean imprimir = false;
        public Boolean eliminar = false;
        public Boolean anular = false;
        public Boolean visible = false;
    }

    public class autorizacionesUser
    {        
        public  autorizacion autoDirectorio(string usuario, string modulo, string conxSys, string empresa)
        {
           autorizacion autUser = new autorizacion ();
           string ssql = "select * from  sys_accesos  where idUsuario = '" + usuario + "' and idempresa = " + empresa + " and idSistema = 'DIR' and idOpcion = '" + modulo + "' ";
           ManejoBases manBas = new ManejoBases();            
           DataTable dtAccesos = manBas.leerTablas(conxSys,ssql);
           if (dtAccesos.Rows.Count > 0 )
           { 
                string aux = dtAccesos.Rows[0]["accnvo"].ToString() + "      ";
                if (aux.Substring(0, 1) == "X") autUser.crearAbierto = true;
                if (aux.Substring(1, 1) == "X") autUser.consultar = true;
//                if (aux.Substring(2, 1) == "X") autUser.modificar = true;
                if (aux.Substring(2, 1) == "X") autUser.imprimir = true;
//                if (aux.Substring(4, 1) == "X") autUser.eliminar = true;
                autUser.existe = true;
                autUser.visible = (autUser.crearAbierto == true || autUser.consultar == true || autUser.modificar == true || autUser.imprimir == true || autUser.eliminar == true);
           }
           return autUser;
        }
    }
}
