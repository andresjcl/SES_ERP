using System;
using System.Windows.Forms;
using DattCom;
using IngSis;

namespace SES_ERP24
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
            string parm2 = "";
            if (args.Length > 0) parm = args[0];
            if (args.Length > 1) parm2 = args[1];
            if (parm2.IndexOf("^") >= 0 || parm.IndexOf("|") >= 0) parm = parm2;

            if (parm.IndexOf("^") >= 0 || parm.IndexOf("|") >= 0)
            {
                datosEmpresa.sistema = "CNX";
                DattCom.IngresoApp.iniciar(parm);
                datosEmpresa.Emp_codigo = datosEmpresa.codEmpresa;
                DattCom.ManejoDatosEmpresa.LeerDatosEmpresa(datosEmpresa.strConxSyscod, datosEmpresa.UsuarioBd, datosEmpresa.ClaveBd, datosEmpresa.Servidor);
                if (DattCom.datosEmpresa.ControlMedico == false)
                { MessageBox.Show("No tiene licencia para este aplicativo"); return; }
                DattCom.ManejoDatosUsuario.LeerDatosUsuario(datosEmpresa.usr);
                if (DattCom.datosEmpresa.Emp_codigo > 0)
                {
                    Application.Run(new MnPrincipal());
                    DattCom.ManejoDatosEmpresa.ResetearEmpresaRegistrada();
                }
            }
            else
            {
                datosEmpresa.sistema = "CNX";
                datosEmpresa.Major = major;                
                DattCom.IngresoApp.iniciar(parm);                
                Acceso ingreso = new Acceso(" SISTEMA CONTABLE ");
                
                ingreso.ShowDialog();
                if (datosEmpresa.usr == "")
                {
                    return;
                }
                Application.Run(new FrmMenuInicial());
                DattCom.ManejoDatosEmpresa.ResetearEmpresaRegistrada();
            }
        }


        
    }

}
