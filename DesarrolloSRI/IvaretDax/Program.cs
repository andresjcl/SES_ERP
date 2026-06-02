using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SysEmpDatt;
using DaxAdcIng;
namespace IvaretDaxx
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
            datosEmpresa.sistema = "DXA";
            if (parm.IndexOf("^") >= 0 || parm.IndexOf("|") >= 0)
            {
                SysEmpDatt.IngresoApp.iniciar(parm);
                datosEmpresa.Emp_codigo = datosEmpresa.codEmpresa;
                SysEmpDatt.ManejoDatosEmpresa.LeerDatosEmpresa(datosEmpresa.strConxSyscod, datosEmpresa.UsuarioBd, datosEmpresa.ClaveBd, datosEmpresa.Servidor);
                // if (SysEmpDatt.datosEmpresa.PuntoDeVenta == false)
                // { MessageBox.Show("No tiene licencia para este aplicativo"); return; }
                SysEmpDatt.ManejoDatosUsuario.LeerDatosUsuario(datosEmpresa.usr);
                if (SysEmpDatt.datosEmpresa.Emp_codigo > 0)
                {
                    Application.Run(new anexoTransaccional.frmAts ());
                    ;
                    SysEmpDatt.ManejoDatosEmpresa.ResetearEmpresaRegistrada();
                }
            }
            else
            {
                datosEmpresa.sistema = "DXA";
                datosEmpresa.Major = major;
                SysEmpDatt.IngresoApp.iniciar(parm);
                Syschk ingreso = new Syschk(" ANEXO TRANSACCIONAL SRI ");
                ingreso.ShowDialog();
                if (datosEmpresa.usr == "")
                {
                    return;
                }
                Application.Run(new anexoTransaccional.frmAts());
            }
        }
    }
}
