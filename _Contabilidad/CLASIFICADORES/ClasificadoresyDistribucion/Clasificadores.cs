using System;
using System.Collections.Generic;
using DattCom;
using System.Data.SqlClient;
using ClassDoc;

namespace DaxClasificadores
{    
    public class ClasificadorCtb
    {
        public string Nombre = "";
        public Boolean regPorConcepto = false; //si debe rgistrarse en cad linea por concepto en los documentos si no se registra como dato adicional en el documento
        public string campotra = ""; // nombre del campo en adctra
        public string campodia = ""; // nombre del campo an adcdia
        public string origenvalores = ""; // si los valores se escojen desde el directorio o desde generales
        public Boolean Status = false; // 1 activo 0 inactivp
        public Int32 IDCLAVE = 0; // clave unica también se utyiliza para el número de campo en la malla de ingreso
        public string TipoDirectorio = ""; // si es E empleado C cliente P proveedor F financiero
        public string GrupoDirectorio = ""; // para buscar en el directorio solo a un grupo definido


        public void Cargar(string nombre)
        {

            string comm = "select * from AdcClasfctb where status <> 0 AND EsClasificador = 1 ";
            comm += " and Nombre = '" + nombre + "'";
            SqlDataReader RsAux = SqlDatos.leerBaseAdcom(comm);
            {
                if (RsAux.Read() == true)
                {
                    MoverDataReadToClasf(RsAux);
                }
            }
        }
        public void Cargar(Int32 idclave)
        {
            string comm = "select * from AdcClasfctb where status <> 0 AND EsClasificador = 1 ";
            comm += " and IDCLAVE = " + idclave.ToString();
            SqlDataReader RsAux = SqlDatos.leerBaseAdcom(comm);
            if (RsAux.Read() == true) MoverDataReadToClasf(RsAux);
        }
        private void MoverDataReadToClasf(SqlDataReader DatR)
        {
            IDCLAVE = Convert.ToInt32(DatR["IDCLAVE"]);
            Nombre = DatR["Nombre"].ToString();
            regPorConcepto = Convert.ToBoolean(DatR["regPorConcepto"]);
            campotra = DatR["campotra"].ToString();
            campodia = DatR["campodia"].ToString();
            origenvalores = DatR["origenvalores"].ToString();
            Status = Convert.ToBoolean(DatR["Status"]);
            TipoDirectorio = DatR["TipoDirectorio"].ToString();
            GrupoDirectorio = DatR["GrupoDirectorio"].ToString();
        }
    }

    public class ClasificadoresCtb
    {
        public List<ClasificadorCtb> ColClasificadoresCtb = new List<ClasificadorCtb>();
        public void Cargar()
        {
            ClasificadoresCtb LaColeccion = new ClasificadoresCtb();
            string comm = "select * from AdcClasfctb where status <> 0 AND EsClasificador = 1 ";
            SqlDataReader RsAux = SqlDatos.leerBaseAdcom(comm);
            {
                while (RsAux.Read() == true)
                {
                    ClasificadorCtb Elclasificador = new ClasificadorCtb();
                    MoverDataReadToClasf(Elclasificador, RsAux);
                    ColClasificadoresCtb.Add(Elclasificador);
                }
            }
        }
        private void MoverDataReadToClasf(ClasificadorCtb clasificador, SqlDataReader DatR)
        {
            clasificador.IDCLAVE = Convert.ToInt32(DatR["IDCLAVE"]);
            clasificador.Nombre = DatR["Nombre"].ToString();
            clasificador.regPorConcepto = Convert.ToBoolean(DatR["regPorConcepto"]);
            clasificador.campotra = DatR["campotra"].ToString();
            clasificador.campodia = DatR["campodia"].ToString();
            clasificador.origenvalores = DatR["origenvalores"].ToString();
            clasificador.Status = Convert.ToBoolean(DatR["Status"]);
            clasificador.TipoDirectorio = DatR["TipoDirectorio"].ToString();
            clasificador.GrupoDirectorio = DatR["GrupoDirectorio"].ToString();

            //Elclasificador.IdClas = "C" + RsAux["Nombre"].ToString();
            //Elclasificador.CtaCtb = "";
            //Elclasificador.Cantidad = 0;
            //Elclasificador.Costo = 0;
            //Elclasificador.ElIva = "";

        }
    }

    public class ClasificadorMalla
    {
        // datos para asignacion de valores en Mallas de documentos
        public string IdClas = "";
        public string Nombre = "";
        public string CtaCtb = "";
        public double Cantidad = 0;
        public double Costo = 0;

        //    public bool ClasificadorValidoEnConcepto(string TipoDoc, string concepto, string Queclasificador, Boolean esContable)
        //    {
        //        Servicios servicios1 = new Servicios(datosEmpresa.strConxAdcom);
        //        Servicios servicios2 = Servicios.Buscar(" sev_codigo = '" + concepto + "'");
        //        if (servicios2 == null || servicios2.Sev_codigo.Length == 0)
        //            return false;
        //        sesSys.OpcDoc opcDoc = new sesSys.OpcDoc();
        //        opcDoc.Documento = TipoDoc; // o la propiedad correcta
        //        string[] strArray = servicios2.Clasificadores(TipoDoc).Split(Convert.ToChar(";"));
        //        for (int index = 0; index <= strArray.Length - 1; ++index)
        //        {
        //            if (strArray[index] == Queclasificador)
        //                return true;
        //        }
        //        return false;
        //    }

        //}

        public bool ClasificadorValidoEnConcepto(
    string TipoDoc,
    string concepto,
    string Queclasificador,
    bool esContable)
        {
            Servicios servicios1 = new Servicios(datosEmpresa.strConxAdcom);
            Servicios servicios2 = Servicios.Buscar(" sev_codigo = '" + concepto + "'");

            if (servicios2 == null || servicios2.Sev_codigo.Length == 0)
                return false;

            // Crear el objeto OpcDoc correctamente
            sesSys.OpcDoc opcDoc = new sesSys.OpcDoc();
            opcDoc.Documento = TipoDoc; // usa la propiedad correcta

            // 🔥 AQUÍ estaba el error
            string[] strArray = servicios2.Clasificadores(opcDoc)
                                          .Split(';');

            foreach (string clasificador in strArray)
            {
                if (clasificador == Queclasificador)
                    return true;
            }

            return false;
        }

        public class ClasificadoresMallas
    {
        public List <ClasificadorMalla> ColClasificadoresMalla = new List<ClasificadorMalla>();
    }
    }

}


