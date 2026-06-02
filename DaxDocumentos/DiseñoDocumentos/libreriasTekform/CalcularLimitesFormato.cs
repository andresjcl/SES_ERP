using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace libreriasTekform
{
    public class LimitesForma
    {
        public static Int32 linPorHoja = 0;
        public static Int32 LinIniciaRenglones = 0;
        public static Int32 cuantasPáginas = 0;
        public static Int32 EspacioDeRenglones = 0;
        public static Int32 LinFinalizaRenglones = 0;
        public static Int32 LongitudPagina = 0;
        public static Int32 LinIniciaPiePagina = 0;
        public static void CalcularLimites(Int32 FilasAdctra,Int32 FilasDiariosCtb,Int32 FilasConsulta, Int32 FilasRetenciones,DataTable DataFormaDoc, Boolean esAcordeon)
        {
            linPorHoja = 1;
            LinIniciaRenglones = 0;
            cuantasPáginas = 0;
            Int32 RegistrosAimprimir = 0;
            Int32 AltoLinea = 0;
            Int32 PosicionLineaMáxima = 0;
            Int32 AltoLineaMaxima = 0;
            camposForma DatoAimprimir = new camposForma();
            //string TipoDato = "0";
            string version = "";
            try
            {
                version = DataFormaDoc.Rows[0]["version"].ToString();
            }
            catch { }
            if (DataFormaDoc.Rows.Count > 0)
            {
                foreach (DataRow row in DataFormaDoc.Rows)
                {
                    leerDefinicionFormato.LeerLinea(row["l1"].ToString(), ref DatoAimprimir, 0,version);

                    if (DatoAimprimir.Ftop + DatoAimprimir.FHeight > PosicionLineaMáxima)
                    {
                        PosicionLineaMáxima = DatoAimprimir.Ftop  + DatoAimprimir.FHeight;
                        AltoLineaMaxima = DatoAimprimir.FHeight;
                    }                

                    if (row["S1"].ToString() == "D")
                    {                            
                        if (DatoAimprimir.Numlineas > 1)
                        {

                            if (DatoAimprimir.Tipo == "14" && FilasConsulta > RegistrosAimprimir) RegistrosAimprimir = FilasConsulta;
                            else if (DatoAimprimir.Tipo == "2" && FilasAdctra > RegistrosAimprimir) RegistrosAimprimir = FilasAdctra;
                            else if (DatoAimprimir.Tipo == "4" && FilasDiariosCtb > RegistrosAimprimir) RegistrosAimprimir = FilasDiariosCtb;
                            else if (DatoAimprimir.Tipo == "7" && FilasRetenciones > RegistrosAimprimir) RegistrosAimprimir = FilasRetenciones;


                            if (DatoAimprimir.Numlineas > linPorHoja)  // 999 indica columna inicial de renglones, para saber linea que incia
                            {
                                linPorHoja = DatoAimprimir.Numlineas;
                                //}
                                //if (PropiedadesCampo.Numlineas == 999)
                                //{
                                if (DatoAimprimir.Ftop > LinIniciaRenglones)
                                {
                                    LinIniciaRenglones = DatoAimprimir.Ftop;
                                    AltoLinea = DatoAimprimir.FHeight;
                                }
                            }
                        }
                    }
                }
            }


            EspacioDeRenglones = AltoLinea * RegistrosAimprimir;
            LinFinalizaRenglones = LinIniciaRenglones + EspacioDeRenglones;

            LinIniciaPiePagina = 0 ;

            foreach (DataRow row in DataFormaDoc.Rows)
            {
                leerDefinicionFormato.LeerLinea(row["l1"].ToString(), ref DatoAimprimir, 0,version);

                if (DatoAimprimir.Ftop > LinFinalizaRenglones  && (DatoAimprimir.Ftop <= LinIniciaPiePagina || LinIniciaPiePagina == 0))
                {
                    LinIniciaPiePagina = DatoAimprimir.Ftop;
                }
            }
            LongitudPagina = PosicionLineaMáxima + 10;

            if (esAcordeon)
            {
                linPorHoja = RegistrosAimprimir;
                LongitudPagina = (int)(PosicionLineaMáxima + EspacioDeRenglones + 10);
            }
            if (linPorHoja > 1)
            {
                cuantasPáginas = RegistrosAimprimir / linPorHoja;
                if (RegistrosAimprimir > (cuantasPáginas * linPorHoja)) cuantasPáginas ++;
            }
            if (cuantasPáginas == 0) cuantasPáginas = 1;
            EspacioDeRenglones -= AltoLinea; // para establecer tamaño de espacio real a aumenar en acordeon
        }
        static private Int32 Val(string valor)
        {
            Int32 aux = 0;
            try { aux = Convert.ToInt32(valor); } catch { }
            return aux;
        }
    }
}
