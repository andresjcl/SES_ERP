using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using SysEmpDatt;

namespace MantCtb
{
    internal partial class frmUsuarios : Form
    {
        private string ListUsuarios;

        public string iniciaUsuario(ref string user)
        {
            string iniciaUsuarioRet = default;
            ListUsuarios = "";
            cargaUsuarios();
            comparaSelect(ref user);
            ShowDialog();
            iniciaUsuarioRet = ListUsuarios;
            return iniciaUsuarioRet;
        }

        private void cargaUsuarios()
        {
            string sSql = " select idusuario from sys_usuario where fechacaduca>'" + DateAndTime.Today + "'";
            int i;
            SqlDataReader TablaAux;
            List1.Items.Clear();
            i = 0;
            TablaAux = SqlDatos.leerBase(sSql, datosEmpresa.strConxSyscod);
            while (TablaAux.Read() != false)
            {
                List1.Items.Insert(i, TablaAux["idusuario"]);
                i = i + 1;
            }

            TablaAux.Close();
        }

        private void comparaSelect(ref string us)
        {
            string[] usuario;
            int i;
            int j;
            usuario = Strings.Split(us, ";");
            var loopTo = usuario.Length - 1;
            for (i = 0; i <= loopTo; i++)
            {
                var loopTo1 = List1.Items.Count - 1;
                for (j = 0; j <= loopTo1; j++)
                {
                    if ((usuario[i] ?? "") == (List1.Items[j].ToString() ?? ""))
                        List1.SetItemChecked(j, true);
                }
            }
        }

        private void cmdAceptar_Click(object eventSender, EventArgs eventArgs)
        {
            int i;
            var loopTo = List1.Items.Count - 1;
            for (i = 0; i <= loopTo; i++)
            {
                if (List1.GetItemChecked(i) == true)
                    ListUsuarios = ListUsuarios + List1.Items[i].ToString() + ";";
            }

            Close();
        }
    }
}