using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SysEmpDatt;

namespace MantCtb
{
    public class ContrlPeriodo
    {
        public void manPermisos()
        {
            var frm = new ControlPeriodo();
            Main();
            frm.iniciaPermisos();
        }

        public string valPeriodo(ref string usuario, ref DateTime fecha, ref bool esContable)
        {
            string valPeriodoRet = default;
            // Dim frm As New ControlPeriodo
            valPeriodoRet = "";
            Main();
            if (fecha <= emp.InvUltAnu)
            {
                valPeriodoRet = " Fecha del documento menor a fecha de ultimo cierre " + Strings.FormatDateTime(emp.InvUltAnu);
                return valPeriodoRet;
            }

            if (fecha < Conversions.ToDate(datosEmpresa.Par_RolCodMay))
            {
                valPeriodoRet = " Fecha del documento menor a fecha de control " + Strings.FormatDateTime(emp.RolCodMay);
                return valPeriodoRet;
            }

            valPeriodoRet = buscaVal(ref usuario, ref fecha, ref esContable);
            return valPeriodoRet;
        }

        private string buscaVal(ref string usuario, ref DateTime fecha, ref bool esContable)
        {
            string buscaValRet = default;
            // Dim TablaAux As New ADODB.Recordset
            // Dim libbas As New DaxLib.DaxLibBases
            // Dim Conxadcom As New ADODB.Connection
            // Conxadcom.ConnectionString = libbas.StrAdcom
            // Conxadcom.Open()
            string sSql = " select contabilidad,otrosmodulos,exccontabilidad,excotrosmodulos ";
            sSql = sSql + " from adcperiodo";
            sSql = sSql + " where contabilidad <> '' ";
            sSql = sSql + " and año=" + DateAndTime.Year(fecha);
            sSql = sSql + " and mes=" + DateAndTime.Month(fecha);
            var TablaAux = SqlDatos.leerBase(sSql, datosEmpresa.strConxAdcom);
            buscaValRet = "";
            if (TablaAux.Read())
            {
                if (esContable == true)
                {
                    string argtipo = TablaAux["contabilidad"].ToString();
                    string argus = TablaAux["exccontabilidad"].ToString();
                    buscaValRet = comparaExiste(argtipo, argus, usuario);
                }
                else
                {
                    buscaValRet = comparaExiste(TablaAux["otrosmodulos"].ToString(), TablaAux["excotrosmodulos"].ToString(), usuario);
                }
            }
            else
            {
                buscaValRet = "";
            }
            // If TablaAux.State = 1 Then TablaAux.Close()
            TablaAux = null;
            return buscaValRet;
            // libbas = Nothing
        }

        private string comparaExiste(string tipo, string us, string usuario)
        {
            string comparaExisteRet = default;
            string[] user;
            int I;
            comparaExisteRet = "";
            if (tipo.Trim().ToUpper() == "ABIERTO")
                return comparaExisteRet;
            user = Strings.Split(us, ";");
            var loopTo = Information.UBound(user);
            for (I = 0; I <= loopTo; I++)
            {
                if ((Strings.UCase(usuario) ?? "") == (Strings.UCase(user[I]) ?? ""))
                    return comparaExisteRet;
            }

            comparaExisteRet = "No tiene autorización para registrar documentos con esta fecha ";
            return comparaExisteRet;
        }

        private void Main()
        {
            // On Error GoTo HayErrores
            // 'CONEMP = New AdcDax.DaxSofSys
            // 'Emp = CONEMP.EmpresaAct
            // 'CONUSR = New DaxUsr.DaxsofUsr
            // 'ControlUsuario = CONUSR.UsuarioAct
            // 'Autorizacion = Emp.Autorizacion
            // Exit Sub
            // HayErrores:
            // If MsgBox(" No se ha cargado BuscaCta correctamente") Then Exit Sub
        }
    }
}