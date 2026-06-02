using System;
using System.Windows.Forms ;
using System.Data ;
using System.Data.SqlClient ;
using System.Text;

namespace mntUsrs
{
    class cargarDatosMallas

    {
        static internal void cargarDatosMenuPrincipal(string strConxDaxsys, DataGridView mallaMenu,int empresa,string sistema,string usuario)
        {
//            diseñoMallas.DiseñarMallaAdcom(mallaMenu);
            ManejoBases progBas = new ManejoBases();
            //progBas.actualizar(strConxDaxsys);
            DataTable dtAccesos = progBas.leerAccesosActuales(strConxDaxsys, usuario, empresa.ToString(), sistema);

            foreach (DataRow row in dtAccesos.Rows)
            {
                for (Int16 i = 0; i < mallaMenu.Rows.Count; i++)
                {
                    if (row["IdOpcion"].ToString() == mallaMenu.Rows[i].Cells["clave"].Value.ToString())
                    {
                        string aux = row["accesos"].ToString();
                        if (aux == "T")
                        {
                            mallaMenu.Rows[i].Cells["abierto"].Value = "X";
                            mallaMenu.Rows[i].Cells["Consultar"].Value = "X";
                            mallaMenu.Rows[i].Cells["Imprimir"].Value = "X";
                        }
                        else
                        if (aux == "R")
                        {
                            mallaMenu.Rows[i].Cells["Consultar"].Value = "X";
                        }
                        else
                        {
                            aux += "      ";
                            mallaMenu.Rows[i].Cells["Abierto"].Value = aux.Substring(0, 1);
                            mallaMenu.Rows[i].Cells["Consultar"].Value = aux.Substring(1, 1);
                            mallaMenu.Rows[i].Cells["Imprimir"].Value = aux.Substring(2, 1);
                        }
                    }
                }
            }
        }
        static internal void cargarRegistrosActuales(string strConxDaxsys, DataGridView mallaDaxMed, int empresa, string sistema, string usuario)
        {
            ManejoBases progBas = new ManejoBases();
            DataTable dtAccesos = progBas.leerAccesosActuales(strConxDaxsys, usuario, empresa.ToString(), sistema);

            if (dtAccesos.Rows.Count > 0)
            {
                foreach (DataRow row in dtAccesos.Rows)
                {
                    for (Int16 i = 0; i < mallaDaxMed.Rows.Count; i++)
                    {
                        if (row["IdOpcion"].ToString() == mallaDaxMed.Rows[i].Cells["clave"].Value.ToString())
                        {
                            string aux = row["accnvo"].ToString() + "      ";
                            mallaDaxMed.Rows[i].Cells["Abierto"].Value = aux.Substring(0, 1);
                            mallaDaxMed.Rows[i].Cells["Consultar"].Value = aux.Substring(1, 1);
                            mallaDaxMed.Rows[i].Cells["Imprimir"].Value = aux.Substring(2, 1);
                        }
                    }
                }
            }
        }
        static internal void cargarRegistrosActualesSES(string strConxDaxsys, DataGridView mallaDaxMed, int empresa, string sistema, string usuario)
        {
            ManejoBases progBas = new ManejoBases();
            DataTable dtAccesos = progBas.leerAccesosActuales(strConxDaxsys, usuario, empresa.ToString(), sistema);

            if (dtAccesos.Rows.Count > 0)
            {
                foreach (DataRow row in dtAccesos.Rows)
                {
                    for (Int16 i = 0; i < mallaDaxMed.Rows.Count; i++)
                    {
                        if (row["IdOpcion"].ToString() == mallaDaxMed.Rows[i].Cells["clave"].Value.ToString())
                        {
                            string aux = row["accnvo"].ToString() + "      ";
                            mallaDaxMed.Rows[i].Cells["Abierto"].Value = aux.Substring(0, 1);
                            //mallaDaxMed.Rows[i].Cells["Consultar"].Value = aux.Substring(1, 1);
                            //mallaDaxMed.Rows[i].Cells["Imprimir"].Value = aux.Substring(2, 1);
                        }
                    }
                }
            }
        }

        static internal void cargarDatosSucursal(string strConxDaxsys, DataGridView mallaMenu, int empresa, string sistema, string usuario)
        {
            ManejoBases progBas = new ManejoBases();
            //progBas.actualizar(strConxDaxsys);
            DataTable dtAccesos = progBas.leerSucursalesActuales(strConxDaxsys, usuario, empresa.ToString(), sistema);

            foreach (DataRow row in dtAccesos.Rows)
            {
                for (Int16 i = 0; i < mallaMenu.Rows.Count; i++)
                {
                    if (row["CodSucursal"].ToString() == mallaMenu.Rows[i].Cells["Modulo"].Value.ToString())
                    {
                        string aux = row["AutorizaSuc"].ToString();
                        if (aux == "S") { aux = "X";} else { aux = "";}
                        mallaMenu.Rows[i].Cells["conAcceso"].Value = aux;
                    }
                }
            }
        }
        static internal void cargarDatosBodegas(string strConxDaxsys, DataGridView mallaMenu, int empresa, string sistema, string usuario)
        {
            ManejoBases progBas = new ManejoBases();
            //progBas.actualizar(strConxDaxsys);
            DataTable dtAccesos = progBas.leerBodegasActuales(strConxDaxsys, usuario, empresa.ToString(), sistema);

            foreach (DataRow row in dtAccesos.Rows)
            {
                for (Int16 i = 0; i < mallaMenu.Rows.Count; i++)
                {
                    if (row["CodBodega"].ToString() == mallaMenu.Rows[i].Cells["Modulo"].Value.ToString()  && row["CodSucursal"].ToString() == mallaMenu.Rows[i].Cells["Suc_codigo"].Value.ToString())
                    {
                        string aux = row["AutorizaBod"].ToString();
                        if (aux == "S") { aux = "X"; } else { aux = ""; }
                        mallaMenu.Rows[i].Cells["conAcceso"].Value = aux;
                    }
                }
            }
        }
        static internal void cargarDatosGrupoDocumentos(string strConxDaxsys, DataGridView mallaGrupDoc, int empresa, string sistema, string usuario)
        {
            ManejoBases progBas = new ManejoBases();
            //progBas.actualizar(strConxDaxsys);
            DataTable dtAccesos = progBas.leerAccesosActuales(strConxDaxsys, usuario, empresa.ToString(), sistema);

            foreach (DataRow row in dtAccesos.Rows)
            {
                for (Int16 i = 0; i < mallaGrupDoc.Rows.Count; i++)
                {
                    if (row["IdOpcion"].ToString() == mallaGrupDoc.Rows[i].Cells["clave"].Value.ToString())
                    {
                        string aux = row["accnvo"].ToString() + "      ";
                        mallaGrupDoc.Rows[i].Cells["conAcceso"].Value = aux.Substring(0, 1);
                        //mallaGrupDoc.Rows[i].Cells["modificar"].Value = aux.Substring(1, 1);
                        //mallaGrupDoc.Rows[i].Cells["consultar"].Value = aux.Substring(2, 1);
                        //mallaGrupDoc.Rows[i].Cells["eliminar"].Value = aux.Substring(3, 1);
                        //mallaGrupDoc.Rows[i].Cells["imprimir"].Value = aux.Substring(4, 1);
                    }
                }
            }
        }
        static internal void cargarDatosDocumentos(string strConxDaxsys, DataGridView mallaDoc, int empresa, string sistema, string usuario)
        {
            ManejoBases progBas = new ManejoBases();
            //progBas.actualizar(strConxDaxsys);
            DataTable dtAccesos = progBas.leerDocumentosActuales(strConxDaxsys, usuario, empresa.ToString(), sistema);

            foreach (DataRow row in dtAccesos.Rows)
            {
                for (Int16 i = 0; i < mallaDoc.Rows.Count; i++)
                {
                    if (row["CodDocumento"].ToString() == mallaDoc.Rows[i].Cells["Modulo"].Value.ToString())
                    {
                        string aux = row["cambios"].ToString();
                        if (aux == "T" || aux == "R") { aux = "X"; } else { aux = ""; }
                        mallaDoc.Rows[i].Cells["conAcceso"].Value = aux;
                    }
                }
            }
        }
    }
}
