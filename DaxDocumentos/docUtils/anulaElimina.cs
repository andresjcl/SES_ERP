using System;
using System.Data.SqlClient ;
using classMenSistem;
using AuditSis;
using inputDialogo;
using ClassDoc;
namespace DctosEmi
{
    public class anulaElimina
    {
        public Boolean anularDocumento(string strDax, string strSys, idDocumento idDocto, string idUsuario, Boolean EsDeLiquidacion, string nomEmpresa, string codEmpresa, string valor, string tablaDatos,string comandoExterno)
        {
            //DtosMall.validacionDocumento validar = new DtosMall.validacionDocumento();
            if (ValidacionDocumentos.ValidacionGeneral.validarFecha(idDocto.fecha.ToShortDateString(), idUsuario) == false) return false;

            if (EsDeLiquidacion) { mensajesErrorDocumento.documentoDeLquidacion(""); return false; }
            ClassDoc.idDocumento dctoAplica = new idDocumento();
            if (chequeos.ChequeaDocAplicado(idDocto, ref dctoAplica, strDax) == true)
            {
                mensajesErrorDocumento.documentoNoAnulaAplicado("SUC: " + dctoAplica.Sucursal + " DOC: " + dctoAplica.Tipo + " " + dctoAplica.numero.ToString() + " ");
                return false;
            }

            if (chequeos.ChequeaSoporteObligado(idDocto, ref dctoAplica, strDax) == true)
            {
                mensajesErrorDocumento.documentoNoAnulaConSoporte("SUC: " + dctoAplica.Sucursal + " DOC: " + dctoAplica.Tipo + " " + dctoAplica.numero.ToString() + " ");
                return false;
            }

            string[] datosCita = chequeos.ChequeaDocumentoCitasMédicas(idDocto);
            string estadoCita = datosCita[0].ToUpper();
            double IdclaveCita = 0;
            //string errAdicional = "";
            //string estadoCitaMedica = chequeos.ChequeaDocumentoCitasMédicas(idDocto).ToUpper();
            if (estadoCita != "NO")
            {
                if (estadoCita == "")
                {
                    if (mensajesErrorDocumento.Respuesta("El documento tiene una cita médica asociada, \n Si anula el documento, se eliminará la cita médica asociada \n, Confirma la anulación ? ") == false) return false;
                    IdclaveCita = Convert.ToDouble(datosCita[1]);
                }
                else
                {
                    mensajesErrorDocumento.neutro("No se puede Anular el documento, tiene una cita médica utilizada");
                    return false;
                }
            }

            if (mensajesErrorDocumento.ConfirmaAnular() == false) return false;
            string motivoAnulacion = inputDialogo.inputDialogo.ingresar("Anulación de documentos", "Digite el motivo de la anulación", "");
            if (motivoAnulacion.Length == 0) return false;
            if (ProcesarAnulacion(idDocto, tablaDatos, strDax,motivoAnulacion,comandoExterno,IdclaveCita) == false) return false;
            AuditSis.registrar.registraEventoDoc(strSys, codEmpresa , idUsuario, "SES_ERP", Environment.MachineName, AuditSis.registrar.EvntAnula, idDocto.Sucursal, idDocto.Tipo, idDocto.numero.ToString(), valor, DateTime.Now.ToShortDateString());
            return true;            
        }
        public Boolean eliminarDocumento(string strDax, string strSys, ClassDoc.idDocumento idDocto, string idUsuario, Boolean EsDeLiquidacion, string nomEmpresa, string codEmpresa, string valor,string tablaDatos,string comandoExterno)
        {
            chequeos chekeos = new chequeos();
            //DtosMall.validacionDocumento validar = new DtosMall.validacionDocumento();
            if (ValidacionDocumentos.ValidacionGeneral.validarFecha(idDocto.fecha.ToShortDateString(), idUsuario) == false) return false;

            if (EsDeLiquidacion) mensajesErrorDocumento.documentoDeLquidacion("");
            ClassDoc.idDocumento dctoAplica = new ClassDoc.idDocumento();
            if (chequeos.ChequeaDocAplicado(idDocto, ref dctoAplica, strDax) == true)
            {
                mensajesErrorDocumento.documentoNoEliminaAplicado("SUC: " + dctoAplica.Sucursal + " DOC: " + dctoAplica.Tipo + " " + dctoAplica.numero.ToString() + " ");
                return false;
            }

            if (chequeos.ChequeaSoporteObligado(idDocto, ref dctoAplica, strDax) == true)
            {
                mensajesErrorDocumento.documentoNoEliminaConSoporte("SUC: " + dctoAplica.Sucursal + " DOC: " + dctoAplica.Tipo + " " + dctoAplica.numero.ToString() + " ");
                return false;

            }

            string[] datosCita = chequeos.ChequeaDocumentoCitasMédicas(idDocto);
            string estadoCita = datosCita[0].ToUpper();
            double IdclaveCita = 0;
            //string errAdicional = "";
            //string estadoCitaMedica = chequeos.ChequeaDocumentoCitasMédicas(idDocto).ToUpper();
            if (estadoCita != "NO") 
            {
                if (estadoCita == "")
                {
                   if ( mensajesErrorDocumento.Respuesta ( "El documento tiene una cita médica asociada, \n Si elimina el documento, se eliminará la cita médica asociada \n, Confirma la eliminación ? ") == false ) return false;
                    IdclaveCita = Convert.ToDouble(datosCita[1]);
                }
                else 
                {
                    mensajesErrorDocumento.neutro("No se puede eliminar el documento, tiene una cita médica utilizada");
                    return false;
                }
            }

            if (mensajesErrorDocumento.ConfirmaEliminar() == false) return false;
            
            registrar.registraEventoDoc(strSys ,codEmpresa, idUsuario, "SES_ERP", Environment.MachineName, AuditSis.registrar.EvntElimina, idDocto.Sucursal, idDocto.Tipo, idDocto.numero.ToString(), valor, DateTime.Now.ToShortDateString());
            if (procesarEliminacion(idDocto,tablaDatos, strDax,IdclaveCita) == false) return false;
            return true;
        }
        public Boolean ProcesarAnulacion(ClassDoc.idDocumento docAnula, string tabla, string strConxAdcom,string motivoAnula,string comandoExterno,double idclaveCita)
        {

            string codsql = "adc_anuDocTablas '" + tabla + "','" + docAnula.Sucursal + "','" + docAnula.Tipo + "'," + docAnula.idClave.ToString() +",'"+motivoAnula+"','"+comandoExterno+"'";
            string cod = "delete from medcitas where idclave = " + idclaveCita.ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(strConxAdcom))
                {
                    conn.Open();
                    using (SqlCommand comm = new SqlCommand(codsql, conn))
                    {
                        comm.ExecuteNonQuery();
                        comm.Dispose();
                        if (idclaveCita > 0)
                        {
                            SqlCommand comm2 = new SqlCommand(cod, conn);
                            comm2.ExecuteNonQuery();
                            comm2.Dispose();
                        }
                    }
                }
            }
            catch (Exception ee) { mensajesErrorDocumento.neutro("excepcion anulando " + tabla + "\n" + ee.Message); return false; }
            return true;
        }
        public Boolean procesarEliminacion(ClassDoc.idDocumento docElimina, string tabla, string strConxAdcom,double idclaveCita = 0)
        {

            string codsql = "adc_eliDocTablas '" + tabla + "','" + docElimina.Sucursal + "','" + docElimina.Tipo + "'," + docElimina.idClave.ToString();
            string cod = "delete from medcitas where idclave = " + idclaveCita.ToString();
            try
            {
                using (SqlConnection conn = new SqlConnection(strConxAdcom))
                {
                    conn.Open();
                    using (SqlCommand comm = new SqlCommand(codsql, conn))
                    {
                        comm.ExecuteNonQuery();
                        comm.Dispose();
                        if (idclaveCita > 0)
                        {
                            SqlCommand comm2 = new SqlCommand(cod, conn);
                            comm2.ExecuteNonQuery();
                            comm2.Dispose();
                        }
                    }

                }
            }
            catch (Exception ee) { mensajesErrorDocumento.neutro("excepcion eliminando " + tabla + "\n" + ee.Message); return false; }
            return true;
        }
    }
}




