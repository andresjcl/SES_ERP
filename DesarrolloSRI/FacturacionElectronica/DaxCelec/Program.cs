using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DattCom;
using IngSis;

namespace DaxCelec
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            int major = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileMajorPart;

            string parm = "";
            if (args.Length > 0) parm = args[0];
            if (args.Length > 1)
            {
                string parm2 = args[1];
                if (parm2.IndexOf("^") >= 0 || parm2.IndexOf("|") >= 0 || parm2.IndexOf("#1") >= 0) parm = parm2;
            }
            if (parm.IndexOf("^") >= 0 || parm.IndexOf("|") >= 0)
            {
                IngresoApp.iniciar(parm);
                datosEmpresa.Emp_codigo = datosEmpresa.codEmpresa;
                ManejoDatosEmpresa.LeerDatosEmpresa(datosEmpresa.strConxSyscod, datosEmpresa.UsuarioBd, datosEmpresa.ClaveBd, datosEmpresa.Servidor);
                // if (SysEmpDatt.datosEmpresa.PuntoDeVenta == false)
                // { MessageBox.Show("No tiene licencia para este aplicativo"); return; }
                ManejoDatosUsuario.LeerDatosUsuario(datosEmpresa.usr);
                if (datosEmpresa.Emp_codigo > 0)
                {
                    Application.Run(new FrmDaxCelec());
                    ManejoDatosEmpresa.ResetearEmpresaRegistrada();
                }
            }
            else
            {
                datosEmpresa.sistema = "DXA";
                datosEmpresa.Major = major;
                IngresoApp.iniciar(parm);
                Acceso ingreso = new Acceso(" EMISION DE FACTURAS MASIVAS ");
                ingreso.ShowDialog();
                if (datosEmpresa.usr == "")
                {
                    return;
                }
                Application.Run(new FrmDaxCelec());
            }

        }
    }
}
