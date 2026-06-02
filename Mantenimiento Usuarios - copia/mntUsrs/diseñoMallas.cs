using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mntUsrs
{
    class diseñoMallas
    {
        static public void DiseñarMallaAdcom(DataGridView mallaMenu)
        {
            mallaMenu.Columns.Add("modulo", "Módulo");
            mallaMenu.Columns.Add("opcion", "OpciónAdcom");
            mallaMenu.Columns.Add("Abierto", "Abierto");
            mallaMenu.Columns.Add("Consultar", "Consultar");
            mallaMenu.Columns.Add("Imprimir", "Imprimir");
            mallaMenu.Columns.Add("clave", "clave");
            mallaMenu.Columns["clave"].Visible = false;
        }
        //public void DiseñarMallaSucursal(DataGridView mallaSuc)
        //{
        //    mallaSuc.Columns.Add("modulo", "SUC");
        //    mallaSuc.Columns.Add("opcion", "Nombre");
        //    mallaSuc.Columns.Add("conAcceso", "Con acceso");
        //    mallaSuc.Columns.Add("clave", "clave");
        //    mallaSuc.Columns["clave"].Visible = false;
        //}
        static public void DiseñarMallaGrupoDocumentos(DataGridView mallaDoc)
        {
            mallaDoc.Columns.Add("modulo", "Módulo");
            mallaDoc.Columns.Add("opcion", "OpciónGrupoDocumentos");
            mallaDoc.Columns.Add("conAcceso", "Con acceso");
            mallaDoc.Columns.Add("clave", "clave");
            mallaDoc.Columns["clave"].Visible = false;
        }
        static public void DiseñarMallaDirectorio(DataGridView mallaDir)
        {
            mallaDir.Columns.Add("modulo", "Módulo");
            mallaDir.Columns.Add("opcion", "OpciónDirectorio");
            mallaDir.Columns.Add("Abierto", "Abierto");
            mallaDir.Columns.Add("consultar", "Consultar");
            mallaDir.Columns.Add("Imprimir", "Imprimir");
            mallaDir.Columns.Add("clave", "clave");
            mallaDir.Columns["clave"].Visible = false;
        }
        static public void DiseñarMallaNomina(DataGridView mallaNomina)
        {
            mallaNomina.Columns.Add("modulo", "Módulo");
            mallaNomina.Columns.Add("opcion", "Opción Nómina");
            mallaNomina.Columns.Add("abierto", "Abierto");
            mallaNomina.Columns.Add("consultar", "Consultar");
            mallaNomina.Columns.Add("clave", "clave");
            mallaNomina.Columns["clave"].Visible = false;
        }
        static public void DiseñarMallaDaxmed(DataGridView mallaDaxMed)
        {
            mallaDaxMed.Columns["modulo"].HeaderText = "Módulo";
            mallaDaxMed.Columns["clave"].Visible = false;
        }
        static public void DiseñarMallaPtoVta(DataGridView mallaPtoVta)
        {
            mallaPtoVta.Columns["Nombre"].HeaderText = "NombreDelUsuario";
            mallaPtoVta.Columns["suc_codigo"].HeaderText = "SUC";
            mallaPtoVta.Columns["IdUsuario"].HeaderText = "Id.Usuario";
            mallaPtoVta.Columns["CodptoVta"].HeaderText = "PuntoVenta";
            mallaPtoVta.Columns["AutorizaPtoVta"].HeaderText = "Modifica";

            mallaPtoVta.Columns["suc_codigo"].Visible = false;

            //mallaPtoVta.Columns["Nombre"].ReadOnly = true;
            //mallaPtoVta.Columns["suc_codigo"].ReadOnly = true;
            //mallaPtoVta.Columns["IdUsuario"].ReadOnly = true;
        }
    }
}
