using System;
using System.IO;
using System.Data;
using System.Data.SqlClient ;
using System.Windows.Forms ;

namespace mntUsrs
{
    class cargaMenusMallas
    {

        static internal void cargaMenuAdcom(DataGridView mallaMenu, string PathServidor)
        {
            string VarTitulo = "";
            string VarNombre = "";
            string Varsis = "";
            string ElTitulo = "";
            Int32 linea = 0;
            string QueLista = "";
            string strLine = "";
            string[] LasOpciones;
            string modulo = "";
            int longTit = 0;
            string aux = "";
            
            diseñoMallas.DiseñarMallaAdcom(mallaMenu);

            DirectoryInfo folderr = new DirectoryInfo(PathServidor + "\\MnAc\\");
            foreach (FileInfo filee in folderr.GetFiles("*.LX"))
            {
                QueLista = filee.FullName;
                if (QueLista.Substring(QueLista.Length - 8, 5).ToUpper() == "SES26")
                {
                    StreamReader objStreamReader = new StreamReader(QueLista, System.Text.Encoding.Default);
                    strLine = objStreamReader.ReadLine();
                    do
                    {
                        if (strLine != "" && strLine.Substring(0, 1) != "-")
                        {
                            LasOpciones = strLine.Split(Convert.ToChar(","));
                            VarNombre = LasOpciones[0].Trim();
                            VarTitulo = LasOpciones[1].Trim();
                            Varsis = LasOpciones[2].Trim();
                            ElTitulo = QuitarMarca(VarTitulo);
                            longTit = ElTitulo.Length;
                            aux = "";
                            if (longTit > 6) aux = ElTitulo.Substring(0, 7).ToUpper();
                            if (aux != "CAMBIAR")
                            {
                                if (VarNombre.Substring(0, 4).ToUpper() == "MNUM" || Varsis == "T")
                                {
                                    modulo = ElTitulo.ToUpper();
                                }
                                else if (VarNombre.Substring(0, 4).ToUpper() == "MNUO")
                                {
                                    mallaMenu.Rows.Add();
                                    mallaMenu.Rows[linea].Cells["modulo"].Value = modulo;
                                    mallaMenu.Rows[linea].Cells["opcion"].Value = ElTitulo;
                                    mallaMenu.Rows[linea].Cells["abierto"].Value = "";
                                    mallaMenu.Rows[linea].Cells["consultar"].Value = "";
                                    //mallaMenu.Rows[linea].Cells["consultar"].Value = "";
                                    //mallaMenu.Rows[linea].Cells["eliminar"].Value = "";
                                    mallaMenu.Rows[linea].Cells["imprimir"].Value = "";
                                    //mallaMenu.Rows[linea].Cells["accesos"].Value = "";
                                    mallaMenu.Rows[linea].Cells["clave"].Value = VarNombre;
                                    linea++;
                                }
                            }
                        }
                        strLine = objStreamReader.ReadLine();
                    } while (!(strLine == null));
                    objStreamReader.Dispose();
                }  // end if
            } //next foreach
            folderr = null;
        }

        static internal void cargaMenuSES(DataGridView mallaMenu)
        {

            string ssql = "select Menuprincipal, Descripcion as opcion, '' as Abierto, Clave from MenuSES order by menuPrincipal,descripcion";
            mallaMenu.DataSource = DattCom.SqlDatos.leerTablaIniSis(ssql);

            // Títulos de columnas
            mallaMenu.Columns["Menuprincipal"].HeaderText = "Módulo";
            mallaMenu.Columns["opcion"].HeaderText = "Opción";
            

            // Ocultar columnas
            mallaMenu.Columns["Clave"].Visible = false;            


        }
        static internal void cargaMenuMedico(DataGridView mallaDaxMed)
        {

            string ssql = "select menuPrincipal as modulo,Descripcion as opcion, '' as Abierto, '' as Consultar,'' as Imprimir,clave from MenDM order by menuPrincipal,descripcion";
            mallaDaxMed.DataSource = DattCom.SqlDatos.leerTablaIniSis(ssql);
        }
        static internal void cargaMenuDirectorio(DataGridView mallaDir)
        {
            string[] dir = { "Identificacion", "Datos Personales", "Familiares", "Empleado", "Cliente", "Proveedor", "Contactos", "Alias" };
            int ii = 8;
            for (int i = 0; i < ii; i++)
            {
                mallaDir.Rows.Add();
                mallaDir.Rows[i].Cells["modulo"].Value = "DIRECTORIO";
                mallaDir.Rows[i].Cells["opcion"].Value = dir[i];
                mallaDir.Rows[i].Cells["Abierto"].Value = "";
                mallaDir.Rows[i].Cells["Consultar"].Value = "";
                mallaDir.Rows[i].Cells["Imprimir"].Value = "";
                mallaDir.Rows[i].Cells["clave"].Value = "mnuon" + dir[i];
            }
        }


        static internal void cargaMenuSucursales(DataGridView mallaSucursal, string strConxDaxsys, string empresa)
        {
            ManejoBases progBas = new ManejoBases();
            string ssql = "select Suc_Codigo as modulo,Suc_Nombre as opcion,'' as conAcceso from emp_suc where emp_codigo = " + empresa + " order by suc_nombre";
            ManejoBases mb = new ManejoBases();
            DataTable dt = mb.leerTablas(strConxDaxsys, ssql);
            mallaSucursal.DataSource = dt;
            mallaSucursal.Columns["modulo"].HeaderText = "Sucursal";
            mallaSucursal.Columns["opcion"].HeaderText = "Nombre";
            progBas = null;
            dt.Dispose();
            dt = null;
        }

        static internal void cargaMenuBodegas(DataGridView mallaBodega, string strConxDaxsys, string empresa)
        {
            ManejoBases progBas = new ManejoBases();
            string ssql = "select suc_codigo, bod_codigo as modulo, Bod_nombre as opcion,'' as conAcceso from Emp_Bod where Emp_Codigo = " + empresa + " order by bod_nombre";
            ManejoBases mb = new ManejoBases();
            DataTable dt = mb.leerTablas(strConxDaxsys, ssql);
            mallaBodega.DataSource = dt;
            mallaBodega.Columns["modulo"].HeaderText = "Bodega";
            mallaBodega.Columns["opcion"].HeaderText = "Nombre";
            progBas = null;
            dt.Dispose();
            dt = null;
        }
        static internal void cargaMenuGruposDocumentos(DataGridView mallaGrupoDocumentos)
        {
            diseñoMallas.DiseñarMallaGrupoDocumentos(mallaGrupoDocumentos);
            string[] grupos = { "Proformas/Pedidos de Cliente", "Proformas/Pedidos de Proveedor", "Ingresos a Bodega", "Ingresos a caja/bancos", "Facturas de Clientes", "Facturas de Proveedores", "Salidas de bodega", "Egresos de caja Bancos", "Notas Debito/Crédito clientes", "Notas de Débito/Crédito Proveedores","Transferencias de Bodega","Remisiones a clientes","Retenciones a proveedor"," Diarios Contabilidad","Factura punto de Ventas","Retenciones Cliente","Administración documentos electrónicos" };
            string[] claves = { "proPedCli", "proPedProv", "ingBode", "ingBcos", "facCliente", "facProve", "salBode", "egrBcos", "debCredCli", "debCredProv", "transBod", "remCli", "retenProvee", "diarioCtb", "pdv", "retCli", "admDocElec" };
            int ii = grupos.Length;
            for (int i = 0; i < grupos.Length ; i++)
            {
                mallaGrupoDocumentos.Rows.Add();
                mallaGrupoDocumentos.Rows[i].Cells["modulo"].Value = "Grupo Documentos";
                mallaGrupoDocumentos.Rows[i].Cells["opcion"].Value = grupos[i];
                mallaGrupoDocumentos.Rows[i].Cells["clave"].Value = "mnuonGdoc" + claves[i];
                mallaGrupoDocumentos.Rows[i].Cells["conAcceso"].Value = "";
            }
        }

        static internal void cargaMenuDocumentos(DataGridView mallaDocumentos, string strConxAdcom)
        {
            string ssql = "select Opc_documento as modulo,Opc_nombre as opcion,'' as conAcceso from adcopc";
            ManejoBases mb = new ManejoBases();
            DataTable dt = mb.leerTablas(strConxAdcom,ssql);
            mallaDocumentos.DataSource = dt;
            mallaDocumentos.Columns["modulo"].HeaderText = "Documento";
            mallaDocumentos.Columns["opcion"].HeaderText = "Nombre";
            dt.Dispose();
            dt = null;
            mb = null;
        }
        static private string QuitarMarca(string Auxil)
        {
            Int32 M = Auxil.IndexOf("&");
            if (M > 0) Auxil = Auxil.Substring(0, M) + Auxil.Substring(M + 1);
            return Auxil;
        }
    }
}